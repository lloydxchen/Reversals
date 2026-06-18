// =============================================================================
// ImbalanceReversal_Claude_v1
// -----------------------------------------------------------------------------
// Imbalance EXHAUSTION reversal zones for Volumetric (BidAsk) charts.
//
// CORE LOGIC (per the agreed spec)
//   BearishExhaustion = High[0] >= HighestHigh(prev N bars)  AND  a BUY imbalance
//                       exists in the top R rows of the bar  (trapped buyers).
//   BullishExhaustion = Low[0]  <= LowestLow(prev N bars)    AND  a SELL imbalance
//                       exists in the bottom R rows of the bar (trapped sellers).
//
//   A diagonal imbalance at level i:
//     Buy  : Ask[i] dominates Bid[i-1]   (bid one tick below)
//     Sell : Bid[i] dominates Ask[i+1]   (ask one tick above)
//   "dominates" = dom >= ratio*opp AND dom >= MinDominantVol AND (dom-opp) >= MinDiff,
//                 or (opp == 0 AND AllowZeroOppositeSide).
//
//   Optional filters: RequireNewHighLow, RequireCloseRejection, RequireNextBarConfirmation.
//
// DRAWING
//   Each signal draws a ZONE (red = bearish at the high, green = bullish at the low)
//   that EXTENDS RIGHT until a later bar trades back into it ("hits another footprint"),
//   i.e. draw-zone-until-broken. Zone band = exact imbalanced rows, or a fixed tick width.
//
// RESEARCH MODE
//   Click a zone to toggle its forward MFE/MAE (favorable = the reversal direction).
//
// CAUSALITY: detection uses only the current/just-closed bar (+ optional next-bar
//   confirmation); MFE/MAE uses only bars AFTER the signal bar. No lookahead in triggers.
//
// STATUS: compile-pending draft (author did not compile in NinjaTrader).
// =============================================================================

#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.BarsTypes;
#endregion

// Enums MUST be at true global scope (not inside any namespace) so NinjaTrader's
// generated property partials can resolve them (otherwise CS0246 on the accessors).
public enum IrDisplayMode { Live, Research }
public enum IrZoneWidthMode { ExactImbalanceRows, FixedTicks }

namespace NinjaTrader.NinjaScript.Indicators.ImbalanceReversal
{
	public class ImbalanceReversal_Claude_v1 : Indicator
	{
		// ------- exhaustion zone -------
		private class Zone
		{
			public int      Index;
			public int      StartBar;
			public int      EndBar = -1;        // -1 = still extending (not yet hit)
			public bool     IsBearish;          // true = red (buy-imb exhaustion at a high)
			public double   PriceHigh, PriceLow;
			public double   SigHigh, SigLow, SigClose, SigMid;
			public DateTime StartTime;
			public bool     NewExtreme;
			public bool     Confirmed;
			public int      ConfirmedBar = -1;

			public bool     ExCalc;
			public double   Entry, UpPts, DownPts;
			public int      UpBar, DownBar;
		}

		// optional per-cell display
		private class CellMark { public double Price; public bool IsBuy; }
		private class BarCells  { public List<CellMark> Cells = new List<CellMark>(); }

		// ------- state -------
		private readonly List<Zone> zones = new List<Zone>();
		private readonly Dictionary<int, BarCells> cellStore = new Dictionary<int, BarCells>();
		private readonly Queue<int> cellOrder = new Queue<int>();

		private int       zoneSeq;
		private int       selectedZone = -1;
		private double    tickSize = 0.25;
		private bool      volumetricOk;

		// next-bar-confirmation pending candidate (one at a time)
		private bool      pendActive;
		private bool      pendBearish;
		private int       pendBar;
		private double    pendZHi, pendZLo, pendSigHigh, pendSigLow, pendSigClose, pendSigMid;
		private int       lastBearBar = -100000, lastBullBar = -100000;

		// diagnostics
		private int       dbgBarsSeen, dbgLastTopBuy, dbgLastBotSell, dbgZones;
		private string    dbgErr = "";

		private ChartScale cachedScale;
		private ChartPanel mousePanel;
		private bool       mouseHooked;
		private DispatcherTimer researchTimer;
		private DateTime   lastInteraction = DateTime.MinValue;
		private SharpDX.DirectWrite.Factory dwFactory;

		private System.Windows.Media.Brush bullFrozen, bearFrozen, cardBgFrozen, cardTextFrozen;

		// =====================================================================
		// Inputs
		// =====================================================================
		[NinjaScriptProperty]
		[Display(Name = "Display mode", Description = "Live = zones only. Research = also click a zone to inspect its MFE/MAE.", Order = 1, GroupName = "0. Mode")]
		public IrDisplayMode DisplayMode { get; set; }

		[NinjaScriptProperty]
		[Range(1.1, 50.0)]
		[Display(Name = "Imbalance ratio", Description = "Dominant side >= ratio * opposite (diagonal). Orderflows commonly uses 3.0 or 4.0.", Order = 1, GroupName = "1. Imbalance")]
		public double DiagonalImbalanceRatio { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100000000)]
		[Display(Name = "Minimum dominant volume", Description = "Dominant side must trade at least this volume to count (instrument-dependent).", Order = 2, GroupName = "1. Imbalance")]
		public long MinimumDominantVolume { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100000000)]
		[Display(Name = "Minimum difference", Description = "Dominant minus opposite must be at least this (instrument-dependent). 0 = off.", Order = 3, GroupName = "1. Imbalance")]
		public long MinimumDifference { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Allow zero opposite side", Description = "If the diagonal opposite side is zero, count the dominant side as an imbalance.", Order = 4, GroupName = "1. Imbalance")]
		public bool AllowZeroOppositeSide { get; set; }

		[NinjaScriptProperty]
		[Range(1, 5000)]
		[Display(Name = "Extreme lookback bars", Description = "Bars back used to define a new high / new low.", Order = 1, GroupName = "2. Exhaustion signal")]
		public int ExtremeLookbackBars { get; set; }

		[NinjaScriptProperty]
		[Range(1, 50)]
		[Display(Name = "Rows to scan at extreme", Description = "How many price rows from the bar high (buy) / low (sell) to scan for the imbalance.", Order = 2, GroupName = "2. Exhaustion signal")]
		public int RowsToScanAtExtreme { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require new high / new low", Description = "Bearish requires bar high >= prior N-bar high; bullish requires bar low <= prior N-bar low.", Order = 3, GroupName = "2. Exhaustion signal")]
		public bool RequireNewHighLow { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require close rejection", Description = "Optional: bearish needs a weak close (lower part of bar); bullish a strong close.", Order = 4, GroupName = "2. Exhaustion signal")]
		public bool RequireCloseRejection { get; set; }

		[NinjaScriptProperty]
		[Range(0.0, 1.0)]
		[Display(Name = "Rejection close fraction", Description = "Used only if Require close rejection is on. 0.5 = close past the midpoint.", Order = 5, GroupName = "2. Exhaustion signal")]
		public double RejectionCloseFraction { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require next-bar confirmation", Description = "Optional: only fire if the NEXT bar closes back through the signal bar midpoint.", Order = 6, GroupName = "2. Exhaustion signal")]
		public bool RequireNextBarConfirmation { get; set; }

		[NinjaScriptProperty]
		[Range(0, 1000)]
		[Display(Name = "Signal cooldown bars", Description = "Minimum bars between two same-direction signals.", Order = 7, GroupName = "2. Exhaustion signal")]
		public int SignalCooldownBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Draw zone until broken", Description = "Extend each zone to the right until a later bar trades back into it.", Order = 1, GroupName = "3. Zone drawing")]
		public bool DrawZoneUntilBroken { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Zone width mode", Description = "ExactImbalanceRows = span the imbalanced rows; FixedTicks = a fixed band off the extreme.", Order = 2, GroupName = "3. Zone drawing")]
		public IrZoneWidthMode ZoneWidthMode { get; set; }

		[NinjaScriptProperty]
		[Range(1, 50)]
		[Display(Name = "Zone width ticks", Description = "Band thickness when Zone width mode = FixedTicks.", Order = 3, GroupName = "3. Zone drawing")]
		public int ZoneWidthTicks { get; set; }

		[NinjaScriptProperty]
		[Range(2, 100)]
		[Display(Name = "Zone opacity %", Description = "Fill opacity of the exhaustion zones.", Order = 4, GroupName = "3. Zone drawing")]
		public int ZoneOpacityPct { get; set; }

		[XmlIgnore]
		[Display(Name = "Bullish color (green)", Order = 5, GroupName = "3. Zone drawing")]
		public System.Windows.Media.Brush BullishBrush { get; set; }
		[Browsable(false)]
		public string BullishBrushSerialize { get { return Serialize.BrushToString(BullishBrush); } set { BullishBrush = Serialize.StringToBrush(value); } }

		[XmlIgnore]
		[Display(Name = "Bearish color (red)", Order = 6, GroupName = "3. Zone drawing")]
		public System.Windows.Media.Brush BearishBrush { get; set; }
		[Browsable(false)]
		public string BearishBrushSerialize { get { return Serialize.BrushToString(BearishBrush); } set { BearishBrush = Serialize.StringToBrush(value); } }

		[NinjaScriptProperty]
		[Display(Name = "Show all imbalance cells", Description = "Optional: also tint every diagonal-imbalance cell (buy=green, sell=red). Off by default.", Order = 7, GroupName = "3. Zone drawing")]
		public bool ShowImbalanceCells { get; set; }

		[NinjaScriptProperty]
		[Range(2, 100)]
		[Display(Name = "Cell tint opacity %", Description = "Opacity for the optional all-imbalance-cell tint.", Order = 8, GroupName = "3. Zone drawing")]
		public int CellTintOpacityPct { get; set; }

		[NinjaScriptProperty]
		[Range(1, 5000)]
		[Display(Name = "MFE/MAE lookahead bars", Description = "Bars after a signal used to measure excursion (research mode + export).", Order = 1, GroupName = "4. Research")]
		public int MaxMfeLookaheadBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show MAE too", Description = "Also draw the adverse band when a zone is selected.", Order = 2, GroupName = "4. Research")]
		public bool ShowMaeToo { get; set; }

		[NinjaScriptProperty]
		[Range(1, 200000)]
		[Display(Name = "Max stored signals", Description = "Cap on retained zones (oldest dropped first).", Order = 3, GroupName = "4. Research")]
		public int MaxStoredSignals { get; set; }

		[NinjaScriptProperty]
		[Range(0, 600)]
		[Display(Name = "Research auto-off minutes", Description = "Auto-clear the selected overlay after this many idle minutes (0 = never).", Order = 4, GroupName = "4. Research")]
		public int ResearchAutoOffMinutes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Point value per contract ($)", Description = "NQ=20, MNQ=2. 0 = use instrument PointValue.", Order = 5, GroupName = "4. Research")]
		public double PointValueOverride { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Export signals CSV", Description = "On historical-complete (and chart close), write all zones + forward MFE/MAE for Python validation.", Order = 1, GroupName = "5. Export")]
		public bool ExportSignalsCsv { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Export folder", Description = "Destination folder for the CSV + summary.", Order = 2, GroupName = "5. Export")]
		public string ExportFolder { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show debug banner", Description = "Top status line for troubleshooting. Turn off when satisfied.", Order = 1, GroupName = "6. Debug")]
		public bool ShowDebugBanner { get; set; }

		// =====================================================================
		// Lifecycle
		// =====================================================================
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description = "Imbalance exhaustion reversal zones (trapped buyers at highs / trapped sellers at lows) for Volumetric charts.";
				Name        = "ImbalanceReversal_Claude_v1";
				Calculate   = Calculate.OnBarClose;
				IsOverlay   = true;
				DisplayInDataBox = false;
				DrawOnPricePanel = true;
				PaintPriceMarkers = false;
				IsSuspendedWhileInactive = false;

				DisplayMode            = IrDisplayMode.Research;

				DiagonalImbalanceRatio = 3.0;
				MinimumDominantVolume  = 20;
				MinimumDifference      = 0;
				AllowZeroOppositeSide  = true;

				ExtremeLookbackBars        = 25;
				RowsToScanAtExtreme        = 2;
				RequireNewHighLow          = true;
				RequireCloseRejection      = false;
				RejectionCloseFraction     = 0.5;
				RequireNextBarConfirmation = false;
				SignalCooldownBars         = 3;

				DrawZoneUntilBroken = true;
				ZoneWidthMode       = IrZoneWidthMode.ExactImbalanceRows;
				ZoneWidthTicks      = 2;
				ZoneOpacityPct      = 28;
				BullishBrush        = System.Windows.Media.Brushes.LimeGreen;
				BearishBrush        = System.Windows.Media.Brushes.Red;
				ShowImbalanceCells  = false;
				CellTintOpacityPct  = 35;

				MaxMfeLookaheadBars    = 60;
				ShowMaeToo             = true;
				MaxStoredSignals       = 2000;
				ResearchAutoOffMinutes = 20;
				PointValueOverride     = 0;

				ExportSignalsCsv = true;
				ExportFolder     = DefaultExportFolder();
				ShowDebugBanner  = true;
			}
			else if (State == State.Configure) { }
			else if (State == State.DataLoaded)
			{
				tickSize = (Instrument != null && Instrument.MasterInstrument != null && Instrument.MasterInstrument.TickSize > 0)
					? Instrument.MasterInstrument.TickSize : (TickSize > 0 ? TickSize : 0.25);

				zones.Clear(); cellStore.Clear(); cellOrder.Clear();
				zoneSeq = 0; selectedZone = -1;
				pendActive = false; lastBearBar = -100000; lastBullBar = -100000;
				dbgBarsSeen = dbgLastTopBuy = dbgLastBotSell = dbgZones = 0; dbgErr = ""; exportedDone = false;

				bullFrozen     = FreezeCopy(BullishBrush ?? System.Windows.Media.Brushes.LimeGreen);
				bearFrozen     = FreezeCopy(BearishBrush ?? System.Windows.Media.Brushes.Red);
				cardBgFrozen   = FreezeCopy(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(24, 26, 32)));
				cardTextFrozen = FreezeCopy(System.Windows.Media.Brushes.Gainsboro);

				HookMouse();
			}
			else if (State == State.Realtime) { if (ExportSignalsCsv) ExportSignalsToCsv(); }
			else if (State == State.Terminated)
			{
				if (ExportSignalsCsv) ExportSignalsToCsv();
				UnhookMouse();
				if (dwFactory != null) { try { dwFactory.Dispose(); } catch { } dwFactory = null; }
			}
		}

		private static System.Windows.Media.Brush FreezeCopy(System.Windows.Media.Brush b)
		{
			try { System.Windows.Media.Brush c = b.Clone(); if (c.CanFreeze) c.Freeze(); return c; } catch { return b; }
		}

		private void HookMouse()
		{
			if (mouseHooked || ChartControl == null || ChartControl.ChartPanels == null || ChartControl.ChartPanels.Count == 0) return;
			try
			{
				mousePanel = ChartControl.ChartPanels[0];
				mousePanel.MouseDown += OnChartMouseDown;
				researchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(20) };
				researchTimer.Tick += OnResearchTimerTick;
				researchTimer.Start();
				mouseHooked = true;
			}
			catch { }
		}

		private void UnhookMouse()
		{
			try
			{
				if (mousePanel != null) mousePanel.MouseDown -= OnChartMouseDown;
				if (researchTimer != null) { researchTimer.Stop(); researchTimer.Tick -= OnResearchTimerTick; researchTimer = null; }
			}
			catch { }
			mouseHooked = false;
		}

		// =====================================================================
		// Per-bar detection
		// =====================================================================
		protected override void OnBarUpdate()
		{
			if (BarsInProgress != 0 || CurrentBar < 0) return;

			VolumetricBarsType vol = (Bars != null && Bars.BarsSeries != null)
				? Bars.BarsSeries.BarsType as VolumetricBarsType : null;
			volumetricOk = vol != null && vol.Volumes != null && CurrentBar < vol.Volumes.Length;
			dbgBarsSeen = CurrentBar + 1;
			if (!volumetricOk) return;

			try
			{
				double low = Low[0], high = High[0];
				double tick = tickSize > 0 ? tickSize : 0.25;
				int steps = (int)Math.Round((high - low) / tick, MidpointRounding.AwayFromZero);
				if (steps < 0) steps = 0;
				if (steps > 5000) steps = 5000;
				int n = steps + 1;

				double[] price = new double[n];
				long[] bid = new long[n], ask = new long[n];
				for (int i = 0; i <= steps; i++)
				{
					double p = RoundToTick(low + i * tick, tick);
					long b = 0, a = 0;
					try { b = vol.Volumes[CurrentBar].GetBidVolumeForPrice(p); } catch { }
					try { a = vol.Volumes[CurrentBar].GetAskVolumeForPrice(p); } catch { }
					price[i] = p; bid[i] = b; ask[i] = a;
				}

				// imbalance flags
				bool[] buyImb = new bool[n], sellImb = new bool[n];
				for (int i = 0; i <= steps; i++)
				{
					long lowerBid  = i > 0     ? bid[i - 1] : 0;
					long higherAsk = i < steps ? ask[i + 1] : 0;
					buyImb[i]  = IsImbalance(ask[i], lowerBid);
					sellImb[i] = IsImbalance(bid[i], higherAsk);
				}

				if (ShowImbalanceCells)
				{
					BarCells bc = new BarCells();
					for (int i = 0; i <= steps; i++)
					{
						if (buyImb[i])  bc.Cells.Add(new CellMark { Price = price[i], IsBuy = true });
						if (sellImb[i]) bc.Cells.Add(new CellMark { Price = price[i], IsBuy = false });
					}
					StoreCells(CurrentBar, bc);
				}

				// buy imbalance in the top R rows / sell imbalance in the bottom R rows
				bool buyTop = false; double bearZoneLo = high;
				for (int i = steps; i >= Math.Max(0, n - RowsToScanAtExtreme); i--)
					if (buyImb[i]) { buyTop = true; bearZoneLo = Math.Min(bearZoneLo, price[i]); }

				bool sellBot = false; double bullZoneHi = low;
				for (int i = 0; i < Math.Min(n, RowsToScanAtExtreme); i++)
					if (sellImb[i]) { sellBot = true; bullZoneHi = Math.Max(bullZoneHi, price[i]); }

				dbgLastTopBuy = buyTop ? 1 : 0;
				dbgLastBotSell = sellBot ? 1 : 0;

				// new high / new low over previous N bars
				bool enoughHist = CurrentBar >= ExtremeLookbackBars;
				double hhPrev = double.MinValue, llPrev = double.MaxValue;
				for (int k = 1; k <= ExtremeLookbackBars && CurrentBar - k >= 0; k++)
				{
					if (High[k] > hhPrev) hhPrev = High[k];
					if (Low[k]  < llPrev) llPrev = Low[k];
				}
				bool newHigh = !RequireNewHighLow || (enoughHist && high >= hhPrev);
				bool newLow  = !RequireNewHighLow || (enoughHist && low  <= llPrev);

				double rng = Math.Max(high - low, tick);
				double closeLoc = (Close[0] - low) / rng;
				bool weakClose   = closeLoc <= RejectionCloseFraction;
				bool strongClose = closeLoc >= (1.0 - RejectionCloseFraction);

				bool bear = newHigh && buyTop && (!RequireCloseRejection || weakClose);
				bool bull = newLow  && sellBot && (!RequireCloseRejection || strongClose);

				// 1) resolve any pending (next-bar confirmation) from the previous bar
				if (pendActive)
				{
					bool confirmed = pendBearish ? (Close[0] < pendSigMid) : (Close[0] > pendSigMid);
					if (confirmed)
						CreateZone(pendBearish, pendBar, pendZHi, pendZLo, pendSigHigh, pendSigLow, pendSigClose, true);
					pendActive = false;
				}

				// 2) new detection (bearish wins ties since it scans the high first)
				if (bear)
				{
					double zHi = ZoneWidthMode == IrZoneWidthMode.FixedTicks ? high : high;
					double zLo = ZoneWidthMode == IrZoneWidthMode.FixedTicks ? high - ZoneWidthTicks * tick : Math.Min(bearZoneLo, high);
					if (RequireNextBarConfirmation) SetPending(true, CurrentBar, zHi, zLo, high, low, Close[0]);
					else CreateZone(true, CurrentBar, zHi, zLo, high, low, Close[0], false);
				}
				else if (bull)
				{
					double zLo = ZoneWidthMode == IrZoneWidthMode.FixedTicks ? low : low;
					double zHi = ZoneWidthMode == IrZoneWidthMode.FixedTicks ? low + ZoneWidthTicks * tick : Math.Max(bullZoneHi, low);
					if (RequireNextBarConfirmation) SetPending(false, CurrentBar, zHi, zLo, high, low, Close[0]);
					else CreateZone(false, CurrentBar, zHi, zLo, high, low, Close[0], false);
				}

				// 3) update active zones: extend until a LATER bar trades back into the band
				if (DrawZoneUntilBroken)
				{
					for (int z = 0; z < zones.Count; z++)
					{
						Zone zo = zones[z];
						if (zo.EndBar >= 0 || zo.StartBar >= CurrentBar) continue;
						if (high >= zo.PriceLow && low <= zo.PriceHigh) zo.EndBar = CurrentBar; // hit
						if (!zo.Confirmed)
						{
							bool c = zo.IsBearish ? (Close[0] < zo.SigMid) : (Close[0] > zo.SigMid);
							if (c) { zo.Confirmed = true; zo.ConfirmedBar = CurrentBar; }
						}
					}
				}

				dbgZones = zones.Count;
			}
			catch (Exception ex) { dbgErr = "OBU: " + ex.Message; }
		}

		private bool IsImbalance(long dom, long opp)
		{
			if (dom < MinimumDominantVolume) return false;
			if (opp <= 0) return AllowZeroOppositeSide;
			if ((dom - opp) < MinimumDifference) return false;
			return (double)dom >= DiagonalImbalanceRatio * (double)opp;
		}

		private void SetPending(bool bearish, int bar, double zHi, double zLo, double sigHigh, double sigLow, double sigClose)
		{
			pendActive = true; pendBearish = bearish; pendBar = bar;
			pendZHi = zHi; pendZLo = zLo; pendSigHigh = sigHigh; pendSigLow = sigLow; pendSigClose = sigClose;
			pendSigMid = (sigHigh + sigLow) / 2.0;
		}

		private void CreateZone(bool bearish, int bar, double zHi, double zLo, double sigHigh, double sigLow, double sigClose, bool confirmedAtCreate)
		{
			if (bearish && (bar - lastBearBar) < SignalCooldownBars) return;
			if (!bearish && (bar - lastBullBar) < SignalCooldownBars) return;

			Zone z = new Zone
			{
				Index = zoneSeq++, StartBar = bar, IsBearish = bearish,
				PriceHigh = Math.Max(zHi, zLo), PriceLow = Math.Min(zHi, zLo),
				SigHigh = sigHigh, SigLow = sigLow, SigClose = sigClose, SigMid = (sigHigh + sigLow) / 2.0,
				StartTime = (bar >= 0 && bar < Bars.Count) ? Bars.GetTime(bar) : Time[0],
				NewExtreme = RequireNewHighLow,
				Confirmed = confirmedAtCreate, ConfirmedBar = confirmedAtCreate ? CurrentBar : -1
			};
			zones.Add(z);
			if (bearish) lastBearBar = bar; else lastBullBar = bar;
			if (zones.Count > MaxStoredSignals)
			{
				zones.RemoveAt(0);
				if (selectedZone >= 0) selectedZone--;
			}
		}

		private double RoundToTick(double p, double tick) { return tick <= 0 ? p : Math.Round(p / tick, MidpointRounding.AwayFromZero) * tick; }

		private void StoreCells(int bar, BarCells bc)
		{
			if (!cellStore.ContainsKey(bar)) cellOrder.Enqueue(bar);
			cellStore[bar] = bc;
			while (cellOrder.Count > 20000) { int old = cellOrder.Dequeue(); cellStore.Remove(old); }
		}

		private void ComputeExcursion(Zone z)
		{
			z.ExCalc = true;
			try
			{
				int last = (Bars != null) ? Bars.Count - 1 : z.StartBar;
				z.Entry = Bars.GetClose(z.StartBar);
				int end = Math.Min(z.StartBar + MaxMfeLookaheadBars, last);
				double hh = z.Entry, ll = z.Entry; z.UpBar = z.StartBar; z.DownBar = z.StartBar;
				for (int i = z.StartBar + 1; i <= end; i++)
				{
					double h = Bars.GetHigh(i), l = Bars.GetLow(i);
					if (h > hh) { hh = h; z.UpBar = i; }
					if (l < ll) { ll = l; z.DownBar = i; }
				}
				z.UpPts = hh - z.Entry; z.DownPts = z.Entry - ll;
			}
			catch { z.UpPts = 0; z.DownPts = 0; }
		}

		private double PointValuePerContract()
		{
			if (PointValueOverride > 0) return PointValueOverride;
			try { if (Instrument != null && Instrument.MasterInstrument != null) return Instrument.MasterInstrument.PointValue; } catch { }
			return 1.0;
		}

		// =====================================================================
		// Rendering
		// =====================================================================
		protected override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
			base.OnRender(chartControl, chartScale);
			cachedScale = chartScale;
			if (chartControl == null || chartScale == null || ChartBars == null) return;
			if (dwFactory == null) { try { dwFactory = new SharpDX.DirectWrite.Factory(); } catch { dwFactory = null; } }
			SharpDX.Direct2D1.RenderTarget rt = RenderTarget;
			if (rt == null) return;

			if (ShowDebugBanner)
				DrawBanner(rt, string.Format("ImbalanceReversal v1 | vol={0} bars={1} topBuyImb@last={2} botSellImb@last={3} zones={4} mode={5} err={6}",
					volumetricOk ? "OK" : "NO", dbgBarsSeen, dbgLastTopBuy, dbgLastBotSell, dbgZones, DisplayMode,
					string.IsNullOrEmpty(dbgErr) ? "-" : dbgErr));

			if (!volumetricOk) { DrawNote(rt, "ImbalanceReversal: set this chart to a Volumetric (BidAsk) bar type."); return; }

			SharpDX.Direct2D1.Brush bull = null, bear = null, cardBg = null, cardTxt = null;
			SharpDX.DirectWrite.TextFormat tf = null, tfSmall = null;
			try
			{
				bull    = (bullFrozen     ?? System.Windows.Media.Brushes.LimeGreen).ToDxBrush(rt);
				bear    = (bearFrozen     ?? System.Windows.Media.Brushes.Red).ToDxBrush(rt);
				cardBg  = (cardBgFrozen   ?? System.Windows.Media.Brushes.Black).ToDxBrush(rt); cardBg.Opacity = 0.95f;
				cardTxt = (cardTextFrozen ?? System.Windows.Media.Brushes.Gainsboro).ToDxBrush(rt);
				if (dwFactory != null) { tf = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", 13f); tfSmall = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", 11f); }

				if (ShowImbalanceCells) RenderCells(rt, chartControl, chartScale, bull, bear);
				RenderZones(rt, chartControl, chartScale, bull, bear, tfSmall, cardTxt);
				if (DisplayMode == IrDisplayMode.Research) RenderSelectedExcursion(rt, chartControl, chartScale, tf, tfSmall, bull, bear, cardBg, cardTxt);
			}
			catch (Exception ex) { dbgErr = "OnRender: " + ex.Message; }
			finally
			{
				if (tf != null) tf.Dispose();
				if (tfSmall != null) tfSmall.Dispose();
				if (bull != null) bull.Dispose();
				if (bear != null) bear.Dispose();
				if (cardBg != null) cardBg.Dispose();
				if (cardTxt != null) cardTxt.Dispose();
			}
		}

		private void RenderZones(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear, SharpDX.DirectWrite.TextFormat tf, SharpDX.Direct2D1.Brush txt)
		{
			int from = Math.Max(ChartBars.FromIndex, 0);
			int to   = Math.Min(ChartBars.ToIndex, CurrentBar);
			float fillOp = Math.Max(0.02f, Math.Min(1f, ZoneOpacityPct / 100f));

			for (int z = 0; z < zones.Count; z++)
			{
				Zone zo = zones[z];
				int endBar = zo.EndBar < 0 ? to : zo.EndBar;
				if (endBar < from || zo.StartBar > to) continue; // not in view
				float x1 = cc.GetXByBarIndex(ChartBars, Math.Max(zo.StartBar, from));
				float x2 = cc.GetXByBarIndex(ChartBars, Math.Min(endBar, to));
				if (x2 < x1) { float t = x1; x1 = x2; x2 = t; }
				float yH = cs.GetYByValue(zo.PriceHigh);
				float yL = cs.GetYByValue(zo.PriceLow);
				float top = Math.Min(yH, yL), h = Math.Max(2f, Math.Abs(yL - yH));
				float w = Math.Max(2f, x2 - x1);

				SharpDX.Direct2D1.Brush br = zo.IsBearish ? bear : bull;
				SharpDX.RectangleF rect = new SharpDX.RectangleF(x1, top, w, h);
				float prev = br.Opacity;
				br.Opacity = fillOp; rt.FillRectangle(rect, br); br.Opacity = prev;
				br.Opacity = zo.Confirmed ? 1f : 0.55f;
				rt.DrawRectangle(rect, br, zo.Confirmed ? 1.6f : 1.0f);
				br.Opacity = prev;

				bool selected = (z == selectedZone);
				if (selected) { rt.DrawRectangle(new SharpDX.RectangleF(x1 - 1, top - 1, w + 2, h + 2), br, 2.4f); }
			}
		}

		private void RenderCells(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs, SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear)
		{
			int from = Math.Max(ChartBars.FromIndex, 0);
			int to   = Math.Min(ChartBars.ToIndex, CurrentBar);
			float halfW = (float)Math.Max(2.0, cc.GetBarPaintWidth(ChartBars) / 2.0);
			float halfTick = Math.Max(1f, Math.Abs(cs.GetYByValue(0) - cs.GetYByValue(tickSize)) / 2f);
			float op = Math.Max(0.02f, Math.Min(1f, CellTintOpacityPct / 100f));
			for (int b = from; b <= to; b++)
			{
				BarCells bc;
				if (!cellStore.TryGetValue(b, out bc)) continue;
				float xc = cc.GetXByBarIndex(ChartBars, b);
				for (int k = 0; k < bc.Cells.Count; k++)
				{
					CellMark cm = bc.Cells[k];
					float yc = cs.GetYByValue(cm.Price);
					SharpDX.Direct2D1.Brush br = cm.IsBuy ? bull : bear;
					float prev = br.Opacity; br.Opacity = op;
					rt.FillRectangle(new SharpDX.RectangleF(xc - halfW, yc - halfTick, halfW * 2f, halfTick * 2f), br);
					br.Opacity = prev;
				}
			}
		}

		private void RenderSelectedExcursion(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.DirectWrite.TextFormat tf, SharpDX.DirectWrite.TextFormat tfSmall,
			SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear, SharpDX.Direct2D1.Brush cardBg, SharpDX.Direct2D1.Brush cardTxt)
		{
			if (selectedZone < 0 || selectedZone >= zones.Count) return;
			Zone z = zones[selectedZone];
			if (!z.ExCalc) ComputeExcursion(z);

			float exX, upX, dnX;
			try { exX = cc.GetXByBarIndex(ChartBars, z.StartBar); upX = cc.GetXByBarIndex(ChartBars, z.UpBar); dnX = cc.GetXByBarIndex(ChartBars, z.DownBar); }
			catch { return; }
			float eY = cs.GetYByValue(z.Entry), upY = cs.GetYByValue(z.Entry + z.UpPts), dnY = cs.GetYByValue(z.Entry - z.DownPts);

			// favorable (the reversal direction) drawn in the signal color; adverse dimmed
			SharpDX.Direct2D1.Brush favBr = z.IsBearish ? bear : bull;
			SharpDX.Direct2D1.Brush advBr = z.IsBearish ? bull : bear;
			double favPts = z.IsBearish ? z.DownPts : z.UpPts;
			double advPts = z.IsBearish ? z.UpPts   : z.DownPts;
			float favX = z.IsBearish ? dnX : upX, favY = z.IsBearish ? dnY : upY;
			float advX = z.IsBearish ? upX : dnX, advY = z.IsBearish ? upY : dnY;

			DrawBand(rt, tfSmall, exX, eY, favX, favY, favBr, cardTxt, string.Format("MFE +{0:0.00}", favPts));
			if (ShowMaeToo) DrawBand(rt, tfSmall, exX, eY, advX, advY, advBr, cardTxt, string.Format("MAE -{0:0.00}", advPts));
			rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(exX, eY), 4.5f, 4.5f), favBr);

			double pv = PointValuePerContract();
			double r = advPts > 1e-9 ? favPts / advPts : 0.0;
			string[] lines =
			{
				(z.IsBearish ? "BEARISH exhaustion (trapped buyers)" : "BULLISH exhaustion (trapped sellers)"),
				string.Format("{0}   close {1:0.00}", z.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), z.Entry),
				string.Format("Zone {0:0.00} - {1:0.00}   {2}", z.PriceLow, z.PriceHigh, z.Confirmed ? "confirmed" : "unconfirmed"),
				string.Format("MFE +{0:0.00} pt (${1:0})   over {2} bars", favPts, favPts * pv, MaxMfeLookaheadBars),
				string.Format("MAE -{0:0.00} pt (${1:0})   MFE/MAE {2:0.00} R", advPts, advPts * pv, r)
			};
			DrawCard(rt, tf, tfSmall, cardBg, cardTxt, favBr, exX + 14f, eY, lines);
		}

		private void DrawBand(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			float ax, float ay, float bx, float by, SharpDX.Direct2D1.Brush br, SharpDX.Direct2D1.Brush txt, string label)
		{
			float lx = Math.Min(ax, bx), rx = Math.Max(ax, bx), ty = Math.Min(ay, by), byy = Math.Max(ay, by);
			SharpDX.RectangleF rect = new SharpDX.RectangleF(lx, ty, Math.Max(2f, rx - lx), Math.Max(2f, byy - ty));
			float prev = br.Opacity; br.Opacity = 0.16f; rt.FillRectangle(rect, br); br.Opacity = prev;
			rt.DrawRectangle(rect, br, 1.2f);
			float edgeY = (Math.Abs(ay - ty) < Math.Abs(ay - byy)) ? byy : ty;
			rt.DrawLine(new SharpDX.Vector2(lx, edgeY), new SharpDX.Vector2(rx, edgeY), br, 1.6f);
			DrawPill(rt, tf, (lx + rx) / 2f, edgeY, label, br, txt);
		}

		private void DrawPill(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf, float cx, float cy, string text, SharpDX.Direct2D1.Brush bg, SharpDX.Direct2D1.Brush txt)
		{
			if (dwFactory == null || tf == null) return;
			SharpDX.DirectWrite.TextLayout tl = null;
			try
			{
				tl = new SharpDX.DirectWrite.TextLayout(dwFactory, text, tf, 300f, 40f);
				float w = tl.Metrics.Width + 10f, h = tl.Metrics.Height + 4f, x = cx - w / 2f, y = cy - h / 2f;
				SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle { Rect = new SharpDX.RectangleF(x, y, w, h), RadiusX = 4f, RadiusY = 4f };
				float prev = bg.Opacity; bg.Opacity = 0.9f; rt.FillRoundedRectangle(rr, bg); bg.Opacity = prev;
				rt.DrawTextLayout(new SharpDX.Vector2(x + 5f, y + 2f), tl, txt);
			}
			catch { } finally { if (tl != null) tl.Dispose(); }
		}

		private void DrawCard(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf, SharpDX.DirectWrite.TextFormat tfSmall,
			SharpDX.Direct2D1.Brush bg, SharpDX.Direct2D1.Brush txt, SharpDX.Direct2D1.Brush accent, float anchorX, float anchorY, string[] lines)
		{
			if (dwFactory == null || tf == null) return;
			float cardW = 330f, lineH = 22f, padX = 9f, padY = 7f, cardH = padY * 2 + lineH * lines.Length;
			float cx = anchorX, cy = anchorY - cardH - 10f; if (cy < 4f) cy = anchorY + 14f;
			SharpDX.Direct2D1.RoundedRectangle card = new SharpDX.Direct2D1.RoundedRectangle { Rect = new SharpDX.RectangleF(cx, cy, cardW, cardH), RadiusX = 6f, RadiusY = 6f };
			rt.FillRoundedRectangle(card, bg); rt.DrawRoundedRectangle(card, accent, 1.4f);
			for (int i = 0; i < lines.Length; i++)
			{
				SharpDX.DirectWrite.TextFormat use = (i == 0) ? tf : tfSmall;
				SharpDX.DirectWrite.TextLayout tl = null;
				try { tl = new SharpDX.DirectWrite.TextLayout(dwFactory, lines[i], use, cardW - padX * 2, lineH); rt.DrawTextLayout(new SharpDX.Vector2(cx + padX, cy + padY + i * lineH), tl, (i == 0) ? accent : txt); }
				catch { } finally { if (tl != null) tl.Dispose(); }
			}
		}

		private void DrawBanner(SharpDX.Direct2D1.RenderTarget rt, string msg)
		{
			if (dwFactory == null) { try { dwFactory = new SharpDX.DirectWrite.Factory(); } catch { return; } }
			SharpDX.DirectWrite.TextFormat tf = null; SharpDX.DirectWrite.TextLayout tl = null;
			SharpDX.Direct2D1.Brush bg = null, txt = null;
			try
			{
				tf = new SharpDX.DirectWrite.TextFormat(dwFactory, "Consolas", 17f);
				tl = new SharpDX.DirectWrite.TextLayout(dwFactory, msg, tf, 1700f, 48f);
				bg = System.Windows.Media.Brushes.Black.ToDxBrush(rt); bg.Opacity = 0.78f;
				txt = System.Windows.Media.Brushes.Yellow.ToDxBrush(rt);
				float by = 48f;
				rt.FillRectangle(new SharpDX.RectangleF(6f, by, tl.Metrics.Width + 18f, tl.Metrics.Height + 10f), bg);
				rt.DrawTextLayout(new SharpDX.Vector2(15f, by + 5f), tl, txt);
			}
			catch { } finally { if (tl != null) tl.Dispose(); if (tf != null) tf.Dispose(); if (bg != null) bg.Dispose(); if (txt != null) txt.Dispose(); }
		}

		private void DrawNote(SharpDX.Direct2D1.RenderTarget rt, string msg)
		{
			if (dwFactory == null) { try { dwFactory = new SharpDX.DirectWrite.Factory(); } catch { return; } }
			SharpDX.DirectWrite.TextFormat tf = null; SharpDX.DirectWrite.TextLayout tl = null; SharpDX.Direct2D1.Brush br = null;
			try { tf = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", 14f); tl = new SharpDX.DirectWrite.TextLayout(dwFactory, msg, tf, 700f, 30f); br = System.Windows.Media.Brushes.Orange.ToDxBrush(rt); rt.DrawTextLayout(new SharpDX.Vector2(12f, 96f), tl, br); }
			catch { } finally { if (tl != null) tl.Dispose(); if (tf != null) tf.Dispose(); if (br != null) br.Dispose(); }
		}

		// =====================================================================
		// Mouse interaction
		// =====================================================================
		private void OnChartMouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (DisplayMode != IrDisplayMode.Research || e.ChangedButton != MouseButton.Left) return;
				if (ChartControl == null || cachedScale == null || mousePanel == null || ChartBars == null) return;
				System.Windows.Point raw = e.GetPosition(mousePanel as System.Windows.IInputElement);
				double px = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToHorizontalPixels(raw.X, ChartControl.PresentationSource);
				double py = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToVerticalPixels(raw.Y, ChartControl.PresentationSource);

				int hit = HitTestZone(px, py);
				lastInteraction = DateTime.Now;
				if (hit < 0) selectedZone = -1;
				else if (hit == selectedZone) selectedZone = -1;
				else { selectedZone = hit; if (!zones[hit].ExCalc) ComputeExcursion(zones[hit]); }
			}
			catch { }
			try { ForceRefresh(); } catch { }
		}

		private int HitTestZone(double px, double py)
		{
			int from = Math.Max(ChartBars.FromIndex, 0);
			int to   = Math.Min(ChartBars.ToIndex, CurrentBar);
			int best = -1;
			for (int z = 0; z < zones.Count; z++) // later zones win (drawn on top)
			{
				Zone zo = zones[z];
				int endBar = zo.EndBar < 0 ? to : zo.EndBar;
				if (endBar < from || zo.StartBar > to) continue;
				float x1 = ChartControl.GetXByBarIndex(ChartBars, Math.Max(zo.StartBar, from));
				float x2 = ChartControl.GetXByBarIndex(ChartBars, Math.Min(endBar, to));
				if (x2 < x1) { float t = x1; x1 = x2; x2 = t; }
				float yH = cachedScale.GetYByValue(zo.PriceHigh), yL = cachedScale.GetYByValue(zo.PriceLow);
				float top = Math.Min(yH, yL), bot = Math.Max(yH, yL);
				if (px >= x1 - 4 && px <= x2 + 4 && py >= top - 6 && py <= bot + 6) best = z;
			}
			return best;
		}

		private void OnResearchTimerTick(object sender, EventArgs e)
		{
			try
			{
				if (DisplayMode != IrDisplayMode.Research || selectedZone < 0 || ResearchAutoOffMinutes <= 0) return;
				if ((DateTime.Now - lastInteraction).TotalMinutes >= ResearchAutoOffMinutes) { selectedZone = -1; ForceRefresh(); }
			}
			catch { }
		}

		// =====================================================================
		// CSV export
		// =====================================================================
		private bool exportedDone;

		private string DefaultExportFolder()
		{
			try { return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NinjaTrader 8", "ImbalanceReversal Exports"); }
			catch { return "ImbalanceReversal Exports"; }
		}

		private static string F(double v, int dec) { return (double.IsNaN(v) || double.IsInfinity(v)) ? "" : v.ToString("F" + dec, System.Globalization.CultureInfo.InvariantCulture); }
		private static string Csv(string s) { if (string.IsNullOrEmpty(s)) return ""; return s.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0 ? "\"" + s.Replace("\"", "\"\"") + "\"" : s; }

		private void ExportSignalsToCsv()
		{
			if (exportedDone) return;
			exportedDone = true;
			try
			{
				if (zones.Count == 0) { Print("[ImbalanceReversal] No zones to export."); return; }
				int lastIdx = (Bars != null) ? Bars.Count - 1 : -1;
				for (int i = 0; i < zones.Count; i++) if (!zones[i].ExCalc) ComputeExcursion(zones[i]);

				string folder = string.IsNullOrWhiteSpace(ExportFolder) ? DefaultExportFolder() : ExportFolder;
				System.IO.Directory.CreateDirectory(folder);
				string stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
				string instr = (Instrument != null && Instrument.MasterInstrument != null) ? Instrument.MasterInstrument.Name : "NA";
				string baseName = string.Format("ImbalanceReversal_{0}_{1}", instr, stamp);
				string csvPath = System.IO.Path.Combine(folder, baseName + "_signals.csv");
				string sumPath = System.IO.Path.Combine(folder, baseName + "_summary.txt");
				double pv = PointValuePerContract();
				var inv = System.Globalization.CultureInfo.InvariantCulture;

				using (var w = new System.IO.StreamWriter(csvPath, false, new System.Text.UTF8Encoding(false)))
				{
					w.WriteLine("SignalIndex,StartBar,Timestamp,Direction,ZoneHigh,ZoneLow,SigHigh,SigLow,SigClose,Confirmed,HitBar,BarsToHit,"
						+ "MfePoints,MaePoints,MfeDollar,MaeDollar,RMultiple,UpPoints,DownPoints,LookaheadComplete");
					for (int i = 0; i < zones.Count; i++)
					{
						Zone z = zones[i];
						double favPts = z.IsBearish ? z.DownPts : z.UpPts;   // favorable = reversal direction
						double advPts = z.IsBearish ? z.UpPts   : z.DownPts;
						double r = advPts > 1e-9 ? favPts / advPts : 0.0;
						bool complete = (z.StartBar + MaxMfeLookaheadBars) <= lastIdx;
						int barsToHit = z.EndBar >= 0 ? z.EndBar - z.StartBar : -1;
						w.WriteLine(string.Join(",", new string[]
						{
							z.Index.ToString(inv), z.StartBar.ToString(inv), Csv(z.StartTime.ToString("yyyy-MM-dd HH:mm:ss", inv)),
							z.IsBearish ? "Bearish" : "Bullish",
							F(z.PriceHigh,2), F(z.PriceLow,2), F(z.SigHigh,2), F(z.SigLow,2), F(z.SigClose,2),
							z.Confirmed ? "1" : "0", z.EndBar.ToString(inv), barsToHit.ToString(inv),
							F(favPts,2), F(advPts,2), F(favPts*pv,2), F(advPts*pv,2), F(r,3), F(z.UpPts,2), F(z.DownPts,2),
							complete ? "1" : "0"
						}));
					}
				}
				using (var w = new System.IO.StreamWriter(sumPath, false, new System.Text.UTF8Encoding(false)))
				{
					w.WriteLine("ImbalanceReversal_Claude_v1 export summary");
					w.WriteLine("GeneratedLocal: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", inv));
					w.WriteLine("Instrument: " + instr);
					w.WriteLine("Zones: " + zones.Count.ToString(inv));
					w.WriteLine("BarsLoaded: " + (lastIdx + 1).ToString(inv));
					w.WriteLine("ImbalanceRatio: " + F(DiagonalImbalanceRatio,3));
					w.WriteLine("MinimumDominantVolume: " + MinimumDominantVolume.ToString(inv));
					w.WriteLine("MinimumDifference: " + MinimumDifference.ToString(inv));
					w.WriteLine("AllowZeroOppositeSide: " + AllowZeroOppositeSide);
					w.WriteLine("ExtremeLookbackBars: " + ExtremeLookbackBars.ToString(inv));
					w.WriteLine("RowsToScanAtExtreme: " + RowsToScanAtExtreme.ToString(inv));
					w.WriteLine("RequireNewHighLow: " + RequireNewHighLow);
					w.WriteLine("RequireCloseRejection: " + RequireCloseRejection + " (frac " + F(RejectionCloseFraction,2) + ")");
					w.WriteLine("RequireNextBarConfirmation: " + RequireNextBarConfirmation);
					w.WriteLine("MaxMfeLookaheadBars: " + MaxMfeLookaheadBars.ToString(inv));
					w.WriteLine("Note: MFE = favorable (reversal-direction) excursion, MAE = adverse, measured on bars AFTER the signal bar. LookaheadComplete=0 means right-censored.");
				}
				Print(string.Format("[ImbalanceReversal] Wrote {0} zones -> {1}", zones.Count, csvPath));
			}
			catch (Exception ex) { Print("[ImbalanceReversal] CSV export ERROR: " + ex.Message); }
		}
	}
}
