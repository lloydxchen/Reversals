// =============================================================================
// ImbalanceReversal_Claude_v1
// -----------------------------------------------------------------------------
// Orderflows-style "imbalance reversal" detector for Volumetric (BidAsk) charts.
//
// WHAT IT DOES
//   1. On every volumetric bar it reads per-price bid/ask volume and flags
//      DIAGONAL imbalances using the same rule proven in the project exporter:
//        - Buy  imbalance at level i : Ask[i]  >= ratio * Bid[i-1]   (bid one tick BELOW)
//        - Sell imbalance at level i : Bid[i]  >= ratio * Ask[i+1]   (ask one tick ABOVE)
//      with a minimum-volume floor and a configurable ratio (default 3.0).
//   2. CELL HIGHLIGHTS (aggression layer): tints each imbalanced cell -
//        buy imbalance  -> light green   (aggressive buying)
//        sell imbalance -> light red     (aggressive selling)
//   3. REVERSAL SIGNALS (reversal layer): when STACKED imbalances pile up in the
//      extreme zone AND the bar closes against that aggression (a rejection / failure
//      on the same bar -> trapped traders), it marks a causal reversal signal:
//        stacked BUY  imbalances at the HIGH + weak close  -> BEARISH reversal (trapped buyers)
//        stacked SELL imbalances at the LOW  + strong close -> BULLISH reversal (trapped sellers)
//   4. RESEARCH MODE: click a signal to toggle its MFE/MAE excursion bands + a
//      detail card; click it again (or empty space) to hide. Mirrors the
//      Reversal_Hunter_Claude research-mode feature.
//
// CAUSALITY / NO-LOOKAHEAD
//   - Signal detection uses ONLY the current bar's finalized footprint + close.
//   - MFE/MAE is measured strictly on bars AFTER the signal bar and is computed
//     lazily on click, never used to trigger the signal.
//
// STATUS: NOT compiled in NinjaTrader by the author of this file. Treat as a
//         compile-pending draft per the project validation hierarchy.
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

// Enums MUST live at true global scope (NOT inside any namespace) so NinjaTrader's
// generated property partials can resolve them, otherwise CS0246 on the accessors.
public enum IrDisplayMode { Live, Research }
public enum IrHighlightSide { FullCell, ImbalancedHalf }

namespace NinjaTrader.NinjaScript.Indicators.ImbalanceReversal
{
	public class ImbalanceReversal_Claude_v1 : Indicator
	{
		// ---------------------------------------------------------------------
		// Per-cell imbalance record (one price level on one bar)
		// ---------------------------------------------------------------------
		private class CellMark
		{
			public double Price;
			public bool   IsBuy;   // true = buy (ask) imbalance, false = sell (bid) imbalance
		}

		// Per-bar imbalance summary, retained for rendering historical bars.
		private class BarImbalance
		{
			public int    BarIndex;
			public double High;
			public double Low;
			public List<CellMark> Cells = new List<CellMark>();
			public int    StackedBuyTopRun;     // longest run of buy imbalances inside the top zone
			public int    StackedSellBottomRun; // longest run of sell imbalances inside the bottom zone
		}

		// ---------------------------------------------------------------------
		// Clickable signal record (reversal event) + its MFE/MAE
		// ---------------------------------------------------------------------
		private class SignalRecord
		{
			public int      SignalIndex;
			public int      BarIndex;
			public DateTime Time;
			public bool     IsLong;          // bullish reversal = long
			public string   TradeType;       // "Trapped Sellers" / "Trapped Buyers"
			public double   EntryPrice;
			public double   High;
			public double   Low;
			public int      StackRun;
			public double   CloseLocation;

			public bool     MfeCalculated;
			public double   MfePrice, MaePrice;
			public double   MfePoints, MaePoints;
			public int      MfeBarIndex, MaeBarIndex;
		}

		// Rendered badge rectangle, rebuilt each render for exact-hit click testing.
		private struct BadgePlace
		{
			public float X, Y, W, H;
			public SignalRecord Rec;
		}

		// ---------------------------------------------------------------------
		// State
		// ---------------------------------------------------------------------
		private readonly Dictionary<int, BarImbalance> barStore = new Dictionary<int, BarImbalance>();
		private readonly Queue<int>            barOrder    = new Queue<int>();
		private readonly List<SignalRecord>    records     = new List<SignalRecord>();
		private readonly List<SignalRecord>    allSignals  = new List<SignalRecord>(); // uncapped, for CSV export
		private bool      exportedDone;
		private List<BadgePlace>               lastBadgeRects = new List<BadgePlace>();

		private int       signalSeq;
		private int       selectedIndex = -1;   // legacy triangle selection (unused for overlay)
		private int       selectedBarIndex = -1; // bar-based selection for the MFE/MAE overlay
		private double    selEntry, selUpPts, selDownPts;
		private int       selUpBar, selDownBar;
		private bool      selCalc;
		private int       lastBullSignalBar = -10000;
		private int       lastBearSignalBar = -10000;
		private double    tickSize = 0.25;
		private bool      volumetricOk;

		// Diagnostics (surfaced via the debug banner)
		private int       dbgBarsSeen;
		private int       dbgLastCells;
		private string    dbgErr = "";

		private ChartScale cachedScale;
		private ChartPanel mousePanel;
		private bool       mouseHooked;
		private DispatcherTimer researchTimer;
		private DateTime   lastInteraction = DateTime.MinValue;

		private SharpDX.DirectWrite.Factory dwFactory;

		// Frozen WPF brushes (built once in DataLoaded), converted to DX each render.
		private System.Windows.Media.Brush bullFrozen;
		private System.Windows.Media.Brush bearFrozen;
		private System.Windows.Media.Brush cardBgFrozen;
		private System.Windows.Media.Brush cardTextFrozen;

		// =====================================================================
		// Inputs
		// =====================================================================
		[NinjaScriptProperty]
		[Display(Name = "Display mode", Description = "Live = highlights + signal badges only. Research = also click a signal to inspect its MFE/MAE.", Order = 1, GroupName = "0. Mode")]
		public IrDisplayMode DisplayMode { get; set; }

		[NinjaScriptProperty]
		[Range(1.1, 50.0)]
		[Display(Name = "Diagonal imbalance ratio", Description = "Ask[i] >= ratio * Bid[i-1] (buy) / Bid[i] >= ratio * Ask[i+1] (sell). Orderflows commonly uses 4.0.", Order = 1, GroupName = "1. Imbalance")]
		public double DiagonalImbalanceRatio { get; set; }

		[NinjaScriptProperty]
		[Range(0, 1000000)]
		[Display(Name = "Min imbalance volume", Description = "Minimum volume on the dominant side before a cell can flag an imbalance.", Order = 2, GroupName = "1. Imbalance")]
		public long MinImbalanceVolume { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Count zero-denominator as imbalance", Description = "If the diagonal side has zero volume, treat the dominant side as an imbalance.", Order = 3, GroupName = "1. Imbalance")]
		public bool AllowZeroDenominatorImbalances { get; set; }

		[NinjaScriptProperty]
		[Range(1, 200)]
		[Display(Name = "Extreme zone ticks", Description = "How many ticks from the bar high/low count as the absorption/extreme zone for stacked-run detection.", Order = 4, GroupName = "1. Imbalance")]
		public int ExtremeZoneTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show cell highlights", Description = "Tint imbalanced cells (green = buy, red = sell).", Order = 1, GroupName = "2. Cell highlights")]
		public bool ShowCellHighlights { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Highlight side", Description = "FullCell tints the whole price row; ImbalancedHalf tints only the dominant side (ask=right, bid=left).", Order = 2, GroupName = "2. Cell highlights")]
		public IrHighlightSide HighlightSide { get; set; }

		[NinjaScriptProperty]
		[Range(1, 100)]
		[Display(Name = "Highlight opacity %", Description = "Opacity of the cell highlight tint.", Order = 3, GroupName = "2. Cell highlights")]
		public int HighlightOpacityPct { get; set; }

		[XmlIgnore]
		[Display(Name = "Bullish color (buy imbalance / long signal)", Order = 4, GroupName = "2. Cell highlights")]
		public System.Windows.Media.Brush BullishBrush { get; set; }
		[Browsable(false)]
		public string BullishBrushSerialize { get { return Serialize.BrushToString(BullishBrush); } set { BullishBrush = Serialize.StringToBrush(value); } }

		[XmlIgnore]
		[Display(Name = "Bearish color (sell imbalance / short signal)", Order = 5, GroupName = "2. Cell highlights")]
		public System.Windows.Media.Brush BearishBrush { get; set; }
		[Browsable(false)]
		public string BearishBrushSerialize { get { return Serialize.BrushToString(BearishBrush); } set { BearishBrush = Serialize.StringToBrush(value); } }

		[NinjaScriptProperty]
		[Display(Name = "Show signal badges", Description = "Draw a marker at each detected imbalance-reversal signal.", Order = 1, GroupName = "3. Reversal signals")]
		public bool ShowSignalBadges { get; set; }

		[NinjaScriptProperty]
		[Range(2, 50)]
		[Display(Name = "Min stacked run for signal", Description = "Required length of a stacked imbalance run inside the extreme zone to qualify a reversal signal.", Order = 2, GroupName = "3. Reversal signals")]
		public int MinStackedRunForSignal { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Require rejection close", Description = "Only fire when the bar closes against the imbalance (weak close at a high / strong close at a low). This is the causal 'failure on the bar' condition.", Order = 3, GroupName = "3. Reversal signals")]
		public bool RequireRejectionClose { get; set; }

		[NinjaScriptProperty]
		[Range(0.0, 1.0)]
		[Display(Name = "Rejection close fraction", Description = "Bearish needs Close in lower fraction of the bar; bullish needs Close in upper fraction. 0.5 = closes past the midpoint.", Order = 4, GroupName = "3. Reversal signals")]
		public double RejectionCloseFraction { get; set; }

		[NinjaScriptProperty]
		[Range(0, 500)]
		[Display(Name = "Signal cooldown bars", Description = "Minimum bars between two same-direction signals (prevents clustering spam).", Order = 5, GroupName = "3. Reversal signals")]
		public int SignalCooldownBars { get; set; }

		[NinjaScriptProperty]
		[Range(1, 5000)]
		[Display(Name = "MFE/MAE lookahead bars", Description = "Bars after a signal used to measure max favorable/adverse excursion (research mode).", Order = 1, GroupName = "4. Research")]
		public int MaxMfeLookaheadBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show MAE too", Description = "Also draw the adverse-excursion band when a signal is selected.", Order = 2, GroupName = "4. Research")]
		public bool ShowMaeToo { get; set; }

		[NinjaScriptProperty]
		[Range(1, 100000)]
		[Display(Name = "Max stored signals", Description = "Cap on retained signals (oldest dropped first).", Order = 3, GroupName = "4. Research")]
		public int MaxStoredSignals { get; set; }

		[NinjaScriptProperty]
		[Range(100, 1000000)]
		[Display(Name = "Max stored bars (highlights)", Description = "Cap on bars whose imbalance highlights are retained for rendering when scrolling back.", Order = 4, GroupName = "4. Research")]
		public int MaxStoredBars { get; set; }

		[NinjaScriptProperty]
		[Range(4, 400)]
		[Display(Name = "Click hitbox (px vertical)", Description = "Vertical click tolerance when selecting a signal.", Order = 5, GroupName = "4. Research")]
		public int ClickHitboxPixels { get; set; }

		[NinjaScriptProperty]
		[Range(4, 800)]
		[Display(Name = "Click hitbox (px horizontal)", Description = "Horizontal click tolerance when selecting a signal.", Order = 6, GroupName = "4. Research")]
		public int LabelHitHalfWidthPixels { get; set; }

		[NinjaScriptProperty]
		[Range(0, 600)]
		[Display(Name = "Research auto-off minutes", Description = "Auto-clear the selected overlay after this many idle minutes (0 = never).", Order = 7, GroupName = "4. Research")]
		public int ResearchAutoOffMinutes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Point value per contract ($)", Description = "Used for the dollar figure on the detail card. NQ=20, MNQ=2. 0 = use instrument PointValue.", Order = 8, GroupName = "4. Research")]
		public double PointValueOverride { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Export signals CSV", Description = "On historical-complete (and on chart close), write every detected signal + its forward MFE/MAE to a CSV for Python validation.", Order = 1, GroupName = "5. Export")]
		public bool ExportSignalsCsv { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Export folder", Description = "Destination folder for the CSV + summary file.", Order = 2, GroupName = "5. Export")]
		public string ExportFolder { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show debug banner", Description = "Top-left status line: volumetric state, bars seen, imbalanced cells on last bar, signal count, last error. Turn off once everything works.", Order = 1, GroupName = "6. Debug")]
		public bool ShowDebugBanner { get; set; }

		// =====================================================================
		// Lifecycle
		// =====================================================================
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description = "Orderflows-style diagonal imbalance highlights + trapped-trader reversal signals with click-to-inspect MFE/MAE.";
				Name        = "ImbalanceReversal_Claude_v1";
				Calculate   = Calculate.OnBarClose;
				IsOverlay   = true;
				DisplayInDataBox = false;
				DrawOnPricePanel = true;
				PaintPriceMarkers = false;
				IsSuspendedWhileInactive = false;

				DisplayMode                    = IrDisplayMode.Research;
				DiagonalImbalanceRatio         = 3.0;
				MinImbalanceVolume             = 20;
				AllowZeroDenominatorImbalances = false;
				ExtremeZoneTicks               = 8;

				ShowCellHighlights = true;
				HighlightSide      = IrHighlightSide.FullCell;
				HighlightOpacityPct = 50;
				BullishBrush = System.Windows.Media.Brushes.LimeGreen;
				BearishBrush = System.Windows.Media.Brushes.Red;

				ShowSignalBadges       = false; // highlights ARE the signal; triangles are an optional extra layer
				MinStackedRunForSignal = 2;
				RequireRejectionClose  = true;
				RejectionCloseFraction = 0.5;
				SignalCooldownBars     = 3;

				MaxMfeLookaheadBars     = 60;
				ShowMaeToo              = true;
				MaxStoredSignals        = 500;
				MaxStoredBars           = 20000;
				ClickHitboxPixels       = 28;
				LabelHitHalfWidthPixels = 60;
				ResearchAutoOffMinutes  = 20;
				PointValueOverride      = 0;

				ExportSignalsCsv = true;
				ExportFolder     = DefaultExportFolder();
				ShowDebugBanner  = true;
			}
			else if (State == State.Configure)
			{
				// Requires the PRIMARY chart series to be a Volumetric (BidAsk) bar type.
				// No AddVolumetric here: we read the chart's own footprint directly.
			}
			else if (State == State.DataLoaded)
			{
				tickSize = (Instrument != null && Instrument.MasterInstrument != null && Instrument.MasterInstrument.TickSize > 0)
					? Instrument.MasterInstrument.TickSize
					: (TickSize > 0 ? TickSize : 0.25);

				barStore.Clear();
				barOrder.Clear();
				records.Clear();
				allSignals.Clear();
				exportedDone = false;
				dbgBarsSeen = 0; dbgLastCells = 0; dbgErr = "";
				lastBadgeRects = new List<BadgePlace>();
				signalSeq = 0;
				selectedIndex = -1;
				selectedBarIndex = -1;
				selCalc = false;
				lastBullSignalBar = -10000;
				lastBearSignalBar = -10000;

				bullFrozen     = FreezeCopy(BullishBrush ?? System.Windows.Media.Brushes.LimeGreen);
				bearFrozen     = FreezeCopy(BearishBrush ?? System.Windows.Media.Brushes.Red);
				cardBgFrozen   = FreezeCopy(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(24, 26, 32)));
				cardTextFrozen = FreezeCopy(System.Windows.Media.Brushes.Gainsboro);

				HookMouse();
			}
			else if (State == State.Realtime)
			{
				// Historical processing is complete here: all bars are loaded, so MFE/MAE
				// windows are fully available. Write the validation CSV once.
				if (ExportSignalsCsv) ExportSignalsToCsv();
			}
			else if (State == State.Terminated)
			{
				if (ExportSignalsCsv) ExportSignalsToCsv(); // fallback if Realtime was never reached
				UnhookMouse();
				if (dwFactory != null) { try { dwFactory.Dispose(); } catch { } dwFactory = null; }
			}
		}

		private static System.Windows.Media.Brush FreezeCopy(System.Windows.Media.Brush b)
		{
			try { System.Windows.Media.Brush c = b.Clone(); if (c.CanFreeze) c.Freeze(); return c; }
			catch { return b; }
		}

		private void HookMouse()
		{
			if (mouseHooked || ChartControl == null || ChartControl.ChartPanels == null || ChartControl.ChartPanels.Count == 0)
				return;
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
		// Per-bar computation
		// =====================================================================
		protected override void OnBarUpdate()
		{
			if (BarsInProgress != 0) return;
			if (CurrentBar < 0) return;

			VolumetricBarsType vol = (Bars != null && Bars.BarsSeries != null)
				? Bars.BarsSeries.BarsType as VolumetricBarsType
				: null;

			volumetricOk = vol != null && vol.Volumes != null && CurrentBar < vol.Volumes.Length;
			dbgBarsSeen = CurrentBar + 1;
			if (!volumetricOk)
				return; // OnRender draws a "needs volumetric chart" note.

			double low  = Low[0];
			double high = High[0];
			double tick = tickSize > 0 ? tickSize : 0.25;
			int steps = (int)Math.Round((high - low) / tick, MidpointRounding.AwayFromZero);
			if (steps < 0) steps = 0;
			if (steps > 5000) steps = 5000; // safety clamp on pathological bars

			// 1) Read per-price bid/ask volume, low -> high.
			int n = steps + 1;
			double[] price = new double[n];
			long[]   bid   = new long[n];
			long[]   ask   = new long[n];
			for (int i = 0; i <= steps; i++)
			{
				double p = RoundToTick(low + i * tick, tick);
				long b = 0, a = 0;
				try { b = vol.Volumes[CurrentBar].GetBidVolumeForPrice(p); } catch { b = 0; }
				try { a = vol.Volumes[CurrentBar].GetAskVolumeForPrice(p); } catch { a = 0; }
				price[i] = p; bid[i] = b; ask[i] = a;
			}

			// 2) Diagonal imbalances + stacked runs inside the extreme zones.
			double bottomCutoff = low  + ExtremeZoneTicks * tick;
			double topCutoff    = high - ExtremeZoneTicks * tick;

			BarImbalance bi = new BarImbalance { BarIndex = CurrentBar, High = high, Low = low };
			int buyRunTop = 0, sellRunBot = 0, buyTopMax = 0, sellBotMax = 0;

			for (int i = 0; i <= steps; i++)
			{
				long lowerBid  = i > 0     ? bid[i - 1] : 0; // bid one tick below
				long higherAsk = i < steps ? ask[i + 1] : 0; // ask one tick above

				bool buyImb  = IsImbalance(ask[i], lowerBid);
				bool sellImb = IsImbalance(bid[i], higherAsk);

				if (buyImb)  bi.Cells.Add(new CellMark { Price = price[i], IsBuy = true });
				if (sellImb) bi.Cells.Add(new CellMark { Price = price[i], IsBuy = false });

				bool inTop    = price[i] >= topCutoff    - tick * 0.5;
				bool inBottom = price[i] <= bottomCutoff + tick * 0.5;

				if (buyImb && inTop) { buyRunTop++; if (buyRunTop > buyTopMax) buyTopMax = buyRunTop; }
				else buyRunTop = 0;

				if (sellImb && inBottom) { sellRunBot++; if (sellRunBot > sellBotMax) sellBotMax = sellRunBot; }
				else sellRunBot = 0;
			}
			bi.StackedBuyTopRun     = buyTopMax;
			bi.StackedSellBottomRun = sellBotMax;
			dbgLastCells = bi.Cells.Count;

			StoreBar(bi);

			// 3) Causal reversal signal: stacked imbalance at the extreme + rejection close.
			double rng = Math.Max(high - low, tick);
			double closeLoc = (Close[0] - low) / rng; // 0 = at low, 1 = at high
			bool weakClose   = closeLoc <= RejectionCloseFraction;        // closed in lower part
			bool strongClose = closeLoc >= (1.0 - RejectionCloseFraction); // closed in upper part

			// Trapped buyers at the high -> BEARISH reversal (short)
			if (buyTopMax >= MinStackedRunForSignal
				&& (!RequireRejectionClose || weakClose)
				&& (CurrentBar - lastBearSignalBar) >= SignalCooldownBars)
			{
				AddSignal(false, "Trapped Buyers", buyTopMax, closeLoc);
				lastBearSignalBar = CurrentBar;
			}
			// Trapped sellers at the low -> BULLISH reversal (long)
			else if (sellBotMax >= MinStackedRunForSignal
				&& (!RequireRejectionClose || strongClose)
				&& (CurrentBar - lastBullSignalBar) >= SignalCooldownBars)
			{
				AddSignal(true, "Trapped Sellers", sellBotMax, closeLoc);
				lastBullSignalBar = CurrentBar;
			}
		}

		private bool IsImbalance(long numerator, long denominator)
		{
			if (numerator < MinImbalanceVolume) return false;
			if (denominator <= 0) return AllowZeroDenominatorImbalances;
			return (double)numerator >= DiagonalImbalanceRatio * (double)denominator;
		}

		private double RoundToTick(double p, double tick)
		{
			if (tick <= 0) return p;
			return Math.Round(p / tick, MidpointRounding.AwayFromZero) * tick;
		}

		private void StoreBar(BarImbalance bi)
		{
			if (!barStore.ContainsKey(bi.BarIndex))
				barOrder.Enqueue(bi.BarIndex);
			barStore[bi.BarIndex] = bi;
			while (barOrder.Count > MaxStoredBars)
			{
				int old = barOrder.Dequeue();
				barStore.Remove(old);
			}
		}

		private void AddSignal(bool isLong, string type, int run, double closeLoc)
		{
			SignalRecord r = new SignalRecord
			{
				SignalIndex = signalSeq++,
				BarIndex    = CurrentBar,
				Time        = Time[0],
				IsLong      = isLong,
				TradeType   = type,
				EntryPrice  = Close[0],
				High        = High[0],
				Low         = Low[0],
				StackRun    = run,
				CloseLocation = closeLoc
			};
			records.Add(r);
			if (records.Count > MaxStoredSignals)
			{
				records.RemoveAt(0);
				if (selectedIndex >= 0) selectedIndex--; // keep selection pointing at the same record
			}
			if (allSignals.Count < 1000000) allSignals.Add(r); // same reference; safety cap only
		}

		// MFE/MAE measured strictly on bars AFTER the signal bar (lazy, cached).
		private void ComputeMfeMae(SignalRecord r)
		{
			int last = (Bars != null ? Bars.Count - 1 : CurrentBar);
			int end = Math.Min(r.BarIndex + MaxMfeLookaheadBars, last);
			double hh = r.EntryPrice, ll = r.EntryPrice;
			int hhIdx = r.BarIndex, llIdx = r.BarIndex;
			for (int i = r.BarIndex + 1; i <= end && i <= Bars.Count - 1; i++)
			{
				double h = Bars.GetHigh(i);
				double l = Bars.GetLow(i);
				if (h > hh) { hh = h; hhIdx = i; }
				if (l < ll) { ll = l; llIdx = i; }
			}
			if (r.IsLong)
			{
				r.MfePrice = hh; r.MfeBarIndex = hhIdx; r.MfePoints = hh - r.EntryPrice;
				r.MaePrice = ll; r.MaeBarIndex = llIdx; r.MaePoints = r.EntryPrice - ll;
			}
			else
			{
				r.MfePrice = ll; r.MfeBarIndex = llIdx; r.MfePoints = r.EntryPrice - ll;
				r.MaePrice = hh; r.MaeBarIndex = hhIdx; r.MaePoints = hh - r.EntryPrice;
			}
			r.MfeCalculated = true;
		}

		private double PointValuePerContract()
		{
			if (PointValueOverride > 0) return PointValueOverride;
			try { if (Instrument != null && Instrument.MasterInstrument != null) return Instrument.MasterInstrument.PointValue; }
			catch { }
			return 1.0;
		}

		// =====================================================================
		// Click an imbalanced bar -> forward excursion (MFE/MAE) overlay
		// =====================================================================
		private int NearestImbalancedBar(double px)
		{
			if (ChartControl == null || ChartBars == null) return -1;
			int from = Math.Max(ChartBars.FromIndex, 0);
			int to   = Math.Min(ChartBars.ToIndex, CurrentBar);
			float halfW = (float)Math.Max(6.0, ChartControl.GetBarPaintWidth(ChartBars) / 2.0 + 2.0);
			int best = -1; double bestDx = double.MaxValue;
			for (int b = from; b <= to; b++)
			{
				BarImbalance bi;
				if (!barStore.TryGetValue(b, out bi) || bi.Cells.Count == 0) continue;
				float x = ChartControl.GetXByBarIndex(ChartBars, b);
				double dx = Math.Abs(px - x);
				if (dx <= halfW && dx < bestDx) { bestDx = dx; best = b; }
			}
			return best;
		}

		private void ComputeBarExcursion(int bar)
		{
			selCalc = true;
			try
			{
				int last = (Bars != null) ? Bars.Count - 1 : bar;
				selEntry = Bars.GetClose(bar);
				int end = Math.Min(bar + MaxMfeLookaheadBars, last);
				double hh = selEntry, ll = selEntry;
				selUpBar = bar; selDownBar = bar;
				for (int i = bar + 1; i <= end; i++)
				{
					double h = Bars.GetHigh(i), l = Bars.GetLow(i);
					if (h > hh) { hh = h; selUpBar = i; }
					if (l < ll) { ll = l; selDownBar = i; }
				}
				selUpPts = hh - selEntry;
				selDownPts = selEntry - ll;
			}
			catch { selUpPts = 0; selDownPts = 0; }
		}

		private void RenderSelectedBarExcursion(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.DirectWrite.TextFormat tf, SharpDX.DirectWrite.TextFormat tfSmall,
			SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear,
			SharpDX.Direct2D1.Brush cardBg, SharpDX.Direct2D1.Brush cardTxt)
		{
			if (selectedBarIndex < 0) return;
			if (!selCalc) ComputeBarExcursion(selectedBarIndex);

			float exX, upX, dnX;
			try
			{
				exX = cc.GetXByBarIndex(ChartBars, selectedBarIndex);
				upX = cc.GetXByBarIndex(ChartBars, selUpBar);
				dnX = cc.GetXByBarIndex(ChartBars, selDownBar);
			}
			catch { return; }
			float eY  = cs.GetYByValue(selEntry);
			float upY = cs.GetYByValue(selEntry + selUpPts);
			float dnY = cs.GetYByValue(selEntry - selDownPts);

			DrawBand(rt, tfSmall, exX, eY, upX, upY, bull, cardTxt, string.Format("+{0:0.00} up", selUpPts));
			DrawBand(rt, tfSmall, exX, eY, dnX, dnY, bear, cardTxt, string.Format("-{0:0.00} dn", selDownPts));
			rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(exX, eY), 4.5f, 4.5f), cardTxt);

			int buyc = 0, sellc = 0;
			BarImbalance bi;
			if (barStore.TryGetValue(selectedBarIndex, out bi))
				for (int i = 0; i < bi.Cells.Count; i++) { if (bi.Cells[i].IsBuy) buyc++; else sellc++; }

			double pv = PointValuePerContract();
			DateTime bt = (selectedBarIndex >= 0 && selectedBarIndex < Bars.Count) ? Bars.GetTime(selectedBarIndex) : DateTime.MinValue;
			string[] lines =
			{
				"Imbalance bar  " + bt.ToString("yyyy-MM-dd HH:mm:ss"),
				string.Format("Close: {0:0.00}    window: {1} bars", selEntry, MaxMfeLookaheadBars),
				string.Format("Fwd up:   +{0:0.00} pt  (${1:0})", selUpPts, selUpPts * pv),
				string.Format("Fwd down: -{0:0.00} pt  (${1:0})", selDownPts, selDownPts * pv),
				string.Format("Buy-imb cells: {0}    Sell-imb cells: {1}", buyc, sellc)
			};
			DrawCard(rt, tf, tfSmall, cardBg, cardTxt, bull, exX + 14f, eY, lines);
		}

		private void DrawCard(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			SharpDX.DirectWrite.TextFormat tfSmall, SharpDX.Direct2D1.Brush bg, SharpDX.Direct2D1.Brush txt,
			SharpDX.Direct2D1.Brush accent, float anchorX, float anchorY, string[] lines)
		{
			if (dwFactory == null || tf == null) return;
			float cardW = 320f, lineH = 22f, padX = 9f, padY = 7f;
			float cardH = padY * 2 + lineH * lines.Length;
			float cx = anchorX, cy = anchorY - cardH - 10f;
			if (cy < 4f) cy = anchorY + 14f;
			SharpDX.Direct2D1.RoundedRectangle card = new SharpDX.Direct2D1.RoundedRectangle
			{ Rect = new SharpDX.RectangleF(cx, cy, cardW, cardH), RadiusX = 6f, RadiusY = 6f };
			rt.FillRoundedRectangle(card, bg);
			rt.DrawRoundedRectangle(card, accent, 1.4f);
			for (int i = 0; i < lines.Length; i++)
			{
				SharpDX.DirectWrite.TextFormat use = (i == 0) ? tf : tfSmall;
				SharpDX.DirectWrite.TextLayout tl = null;
				try
				{
					tl = new SharpDX.DirectWrite.TextLayout(dwFactory, lines[i], use, cardW - padX * 2, lineH);
					rt.DrawTextLayout(new SharpDX.Vector2(cx + padX, cy + padY + i * lineH), tl, (i == 0) ? accent : txt);
				}
				catch { }
				finally { if (tl != null) tl.Dispose(); }
			}
		}

		// =====================================================================
		// CSV export for Python validation
		// =====================================================================
		private string DefaultExportFolder()
		{
			try { return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NinjaTrader 8", "ImbalanceReversal Exports"); }
			catch { return "ImbalanceReversal Exports"; }
		}

		private static string F(double v, int dec)
		{
			if (double.IsNaN(v) || double.IsInfinity(v)) return "";
			return v.ToString("F" + dec, System.Globalization.CultureInfo.InvariantCulture);
		}

		private static string Csv(string s)
		{
			if (string.IsNullOrEmpty(s)) return "";
			if (s.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0)
				return "\"" + s.Replace("\"", "\"\"") + "\"";
			return s;
		}

		private void ExportSignalsToCsv()
		{
			if (exportedDone) return;
			exportedDone = true; // attempt once per load; set early to prevent re-entry
			try
			{
				if (allSignals.Count == 0) { Print("[ImbalanceReversal] No signals to export."); return; }

				int lastIdx = (Bars != null) ? Bars.Count - 1 : -1;
				for (int i = 0; i < allSignals.Count; i++)
					if (!allSignals[i].MfeCalculated) ComputeMfeMae(allSignals[i]);

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
					w.WriteLine("SignalIndex,BarIndex,Timestamp,Direction,TradeType,EntryPrice,BarHigh,BarLow,CloseLocation,StackRun,"
						+ "MfePoints,MaePoints,MfePrice,MaePrice,MfeBarIndex,MaeBarIndex,MfeBarsToHit,MaeBarsToHit,RMultiple,MfeDollar,MaeDollar,"
						+ "LookaheadBarsAvailable,LookaheadComplete");

					for (int i = 0; i < allSignals.Count; i++)
					{
						SignalRecord r = allSignals[i];
						int avail = Math.Max(0, lastIdx - r.BarIndex);
						bool complete = (r.BarIndex + MaxMfeLookaheadBars) <= lastIdx;
						double rmult = r.MaePoints > 1e-9 ? r.MfePoints / r.MaePoints : 0.0;

						w.WriteLine(string.Join(",", new string[]
						{
							r.SignalIndex.ToString(inv),
							r.BarIndex.ToString(inv),
							Csv(r.Time.ToString("yyyy-MM-dd HH:mm:ss", inv)),
							r.IsLong ? "Long" : "Short",
							Csv(r.TradeType),
							F(r.EntryPrice, 2), F(r.High, 2), F(r.Low, 2), F(r.CloseLocation, 4),
							r.StackRun.ToString(inv),
							F(r.MfePoints, 2), F(r.MaePoints, 2), F(r.MfePrice, 2), F(r.MaePrice, 2),
							r.MfeBarIndex.ToString(inv), r.MaeBarIndex.ToString(inv),
							(r.MfeBarIndex - r.BarIndex).ToString(inv), (r.MaeBarIndex - r.BarIndex).ToString(inv),
							F(rmult, 3), F(r.MfePoints * pv, 2), F(r.MaePoints * pv, 2),
							avail.ToString(inv), complete ? "1" : "0"
						}));
					}
				}

				using (var w = new System.IO.StreamWriter(sumPath, false, new System.Text.UTF8Encoding(false)))
				{
					w.WriteLine("ImbalanceReversal_Claude_v1 export summary");
					w.WriteLine("GeneratedLocal: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", inv));
					w.WriteLine("Instrument: " + instr);
					w.WriteLine("Signals: " + allSignals.Count.ToString(inv));
					w.WriteLine("BarsLoaded: " + (lastIdx + 1).ToString(inv));
					w.WriteLine("DiagonalImbalanceRatio: " + F(DiagonalImbalanceRatio, 3));
					w.WriteLine("MinImbalanceVolume: " + MinImbalanceVolume.ToString(inv));
					w.WriteLine("AllowZeroDenominatorImbalances: " + AllowZeroDenominatorImbalances);
					w.WriteLine("ExtremeZoneTicks: " + ExtremeZoneTicks.ToString(inv));
					w.WriteLine("MinStackedRunForSignal: " + MinStackedRunForSignal.ToString(inv));
					w.WriteLine("RequireRejectionClose: " + RequireRejectionClose);
					w.WriteLine("RejectionCloseFraction: " + F(RejectionCloseFraction, 3));
					w.WriteLine("SignalCooldownBars: " + SignalCooldownBars.ToString(inv));
					w.WriteLine("MaxMfeLookaheadBars: " + MaxMfeLookaheadBars.ToString(inv));
					w.WriteLine("PointValuePerContract: " + F(pv, 2));
					w.WriteLine("TimestampTimezone: chart/bar timezone as configured in NinjaTrader (no conversion applied)");
					w.WriteLine("Note: MFE/MAE use bars AFTER the signal bar only. Rows with LookaheadComplete=0 had fewer than MaxMfeLookaheadBars forward bars and are right-censored.");
				}

				Print(string.Format("[ImbalanceReversal] Wrote {0} signals -> {1}", allSignals.Count, csvPath));
			}
			catch (Exception ex)
			{
				Print("[ImbalanceReversal] CSV export ERROR: " + ex.Message);
			}
		}

		// =====================================================================
		// Rendering
		// =====================================================================
		protected override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
			base.OnRender(chartControl, chartScale);
			cachedScale = chartScale;
			if (chartControl == null || chartScale == null || ChartBars == null) return;

			if (dwFactory == null)
			{
				try { dwFactory = new SharpDX.DirectWrite.Factory(); } catch { dwFactory = null; }
			}

			SharpDX.Direct2D1.RenderTarget rt = RenderTarget;
			if (rt == null) return;

			if (ShowDebugBanner)
				DrawBanner(rt, string.Format("ImbalanceReversal v1 | vol={0} barsSeen={1} cells@last={2} signals={3} mode={4} err={5}",
					volumetricOk ? "OK" : "NO", dbgBarsSeen, dbgLastCells, allSignals.Count, DisplayMode,
					string.IsNullOrEmpty(dbgErr) ? "-" : dbgErr));

			if (!volumetricOk)
			{
				DrawNote(rt, chartControl, "ImbalanceReversal: set this chart to a Volumetric (BidAsk) bar type.");
				return;
			}

			float op = Math.Max(0.02f, Math.Min(1f, HighlightOpacityPct / 100f));
			SharpDX.Direct2D1.Brush bull = null, bear = null, cardBg = null, cardTxt = null;
			SharpDX.DirectWrite.TextFormat tf = null, tfSmall = null;
			try
			{
				bull    = (bullFrozen     ?? System.Windows.Media.Brushes.LimeGreen).ToDxBrush(rt);
				bear    = (bearFrozen     ?? System.Windows.Media.Brushes.Red).ToDxBrush(rt);
				cardBg  = (cardBgFrozen   ?? System.Windows.Media.Brushes.Black).ToDxBrush(rt); cardBg.Opacity = 0.95f;
				cardTxt = (cardTextFrozen ?? System.Windows.Media.Brushes.Gainsboro).ToDxBrush(rt);
				if (dwFactory != null)
				{
					tf      = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", 12f);
					tfSmall = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", 10f);
				}

				if (ShowCellHighlights)
					RenderCellHighlights(rt, chartControl, chartScale, bull, bear, op);

				if (ShowSignalBadges)
					RenderSignalBadges(rt, chartControl, chartScale, bull, bear);
				else
					lastBadgeRects = new List<BadgePlace>();

				if (DisplayMode == IrDisplayMode.Research)
					RenderSelectedBarExcursion(rt, chartControl, chartScale, tf, tfSmall, bull, bear, cardBg, cardTxt);
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

		private void RenderCellHighlights(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear, float op)
		{
			int from = Math.Max(ChartBars.FromIndex, 0);
			int to   = Math.Min(ChartBars.ToIndex, CurrentBar);
			float halfW = (float)Math.Max(2.0, cc.GetBarPaintWidth(ChartBars) / 2.0);
			float halfTickPx;
			{
				float y0 = cs.GetYByValue(0);
				float y1 = cs.GetYByValue(tickSize);
				halfTickPx = Math.Max(1f, Math.Abs(y0 - y1) / 2f);
			}

			for (int b = from; b <= to; b++)
			{
				BarImbalance bi;
				if (!barStore.TryGetValue(b, out bi)) continue;
				float xc = cc.GetXByBarIndex(ChartBars, b);
				for (int k = 0; k < bi.Cells.Count; k++)
				{
					CellMark cell = bi.Cells[k];
					float yc = cs.GetYByValue(cell.Price);
					float left, width;
					if (HighlightSide == IrHighlightSide.ImbalancedHalf)
					{
						if (cell.IsBuy) { left = xc;          width = halfW; }   // ask = right half
						else            { left = xc - halfW;  width = halfW; }   // bid = left half
					}
					else { left = xc - halfW; width = halfW * 2f; }

					SharpDX.Direct2D1.Brush br = cell.IsBuy ? bull : bear;
					float prev = br.Opacity;
					br.Opacity = op;
					rt.FillRectangle(new SharpDX.RectangleF(left, yc - halfTickPx, width, halfTickPx * 2f), br);
					br.Opacity = prev;
				}
			}
		}

		private void RenderSignalBadges(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear)
		{
			List<BadgePlace> places = new List<BadgePlace>();
			int from = Math.Max(ChartBars.FromIndex, 0);
			int to   = Math.Min(ChartBars.ToIndex, CurrentBar);
			float pad = (float)Math.Max(4.0, cc.GetBarPaintWidth(ChartBars) / 3.0);

			for (int i = 0; i < records.Count; i++)
			{
				SignalRecord r = records[i];
				if (r.BarIndex < from || r.BarIndex > to) continue;
				float x = cc.GetXByBarIndex(ChartBars, r.BarIndex);
				SharpDX.Direct2D1.Brush br = r.IsLong ? bull : bear;

				// Triangle pointing toward the expected move: below the low (long) / above the high (short).
				float size = 9f;
				float tipY, baseY;
				if (r.IsLong) { float yLow = cs.GetYByValue(r.Low); baseY = yLow + pad; tipY = baseY + size; }
				else          { float yHigh = cs.GetYByValue(r.High); baseY = yHigh - pad; tipY = baseY - size; }

				bool selected = (i == selectedIndex);
				using (SharpDX.Direct2D1.PathGeometry pg = new SharpDX.Direct2D1.PathGeometry(rt.Factory))
				{
					using (SharpDX.Direct2D1.GeometrySink sink = pg.Open())
					{
						sink.BeginFigure(new SharpDX.Vector2(x, tipY), SharpDX.Direct2D1.FigureBegin.Filled);
						sink.AddLine(new SharpDX.Vector2(x - size, baseY));
						sink.AddLine(new SharpDX.Vector2(x + size, baseY));
						sink.EndFigure(SharpDX.Direct2D1.FigureEnd.Closed);
						sink.Close();
					}
					rt.FillGeometry(pg, br);
					if (selected) rt.DrawGeometry(pg, br, 2.5f);
				}

				float top = Math.Min(tipY, baseY), h = Math.Abs(tipY - baseY);
				places.Add(new BadgePlace { X = x - size, Y = top, W = size * 2f, H = h, Rec = r });
			}
			lastBadgeRects = places;
		}

		private void RenderSelectedOverlay(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.DirectWrite.TextFormat tf, SharpDX.DirectWrite.TextFormat tfSmall,
			SharpDX.Direct2D1.Brush bull, SharpDX.Direct2D1.Brush bear,
			SharpDX.Direct2D1.Brush cardBg, SharpDX.Direct2D1.Brush cardTxt)
		{
			if (selectedIndex < 0 || selectedIndex >= records.Count) return;
			SignalRecord r = records[selectedIndex];
			if (!r.MfeCalculated) ComputeMfeMae(r);

			SharpDX.Direct2D1.Brush favBr = r.IsLong ? bull : bear; // favorable = direction of the reversal
			SharpDX.Direct2D1.Brush advBr = r.IsLong ? bear : bull;

			float exX, mfeX, maeX;
			try
			{
				exX  = cc.GetXByBarIndex(ChartBars, r.BarIndex);
				mfeX = cc.GetXByBarIndex(ChartBars, Math.Max(r.MfeBarIndex, r.BarIndex));
				maeX = cc.GetXByBarIndex(ChartBars, Math.Max(r.MaeBarIndex, r.BarIndex));
			}
			catch { return; }
			float eY   = cs.GetYByValue(r.EntryPrice);
			float mfeY = cs.GetYByValue(r.MfePrice);
			float maeY = cs.GetYByValue(r.MaePrice);

			DrawBand(rt, tfSmall, exX, eY, mfeX, mfeY, favBr, cardTxt, string.Format("MFE +{0:0.00}", r.MfePoints));
			if (ShowMaeToo)
				DrawBand(rt, tfSmall, exX, eY, maeX, maeY, advBr, cardTxt, string.Format("MAE -{0:0.00}", r.MaePoints));

			// entry node
			rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(exX, eY), 4.5f, 4.5f), favBr);

			DrawDetailCard(rt, tf, tfSmall, r, cardBg, cardTxt, favBr, exX, eY);
		}

		private void DrawBand(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			float ax, float ay, float bx, float by, SharpDX.Direct2D1.Brush br, SharpDX.Direct2D1.Brush txt, string label)
		{
			float lx = Math.Min(ax, bx), rx = Math.Max(ax, bx);
			float ty = Math.Min(ay, by), byy = Math.Max(ay, by);
			float w = Math.Max(2f, rx - lx), h = Math.Max(2f, byy - ty);
			SharpDX.RectangleF rect = new SharpDX.RectangleF(lx, ty, w, h);
			float prev = br.Opacity;
			br.Opacity = 0.16f; rt.FillRectangle(rect, br); br.Opacity = prev;
			rt.DrawRectangle(rect, br, 1.2f);
			float edgeY = (Math.Abs(ay - ty) < Math.Abs(ay - byy)) ? byy : ty; // the excursion-extreme edge
			rt.DrawLine(new SharpDX.Vector2(lx, edgeY), new SharpDX.Vector2(rx, edgeY), br, 1.6f);
			DrawPill(rt, tf, (lx + rx) / 2f, edgeY, label, br, txt);
		}

		private void DrawPill(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			float cx, float cy, string text, SharpDX.Direct2D1.Brush bg, SharpDX.Direct2D1.Brush txt)
		{
			if (dwFactory == null || tf == null) return;
			SharpDX.DirectWrite.TextLayout tl = null;
			try
			{
				tl = new SharpDX.DirectWrite.TextLayout(dwFactory, text, tf, 300f, 40f);
				float w = tl.Metrics.Width + 10f, h = tl.Metrics.Height + 4f;
				float x = cx - w / 2f, y = cy - h / 2f;
				SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
				{ Rect = new SharpDX.RectangleF(x, y, w, h), RadiusX = 4f, RadiusY = 4f };
				float prev = bg.Opacity; bg.Opacity = 0.9f; rt.FillRoundedRectangle(rr, bg); bg.Opacity = prev;
				rt.DrawTextLayout(new SharpDX.Vector2(x + 5f, y + 2f), tl, txt);
			}
			catch { }
			finally { if (tl != null) tl.Dispose(); }
		}

		private void DrawDetailCard(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			SharpDX.DirectWrite.TextFormat tfSmall, SignalRecord r, SharpDX.Direct2D1.Brush bg,
			SharpDX.Direct2D1.Brush txt, SharpDX.Direct2D1.Brush accent, float anchorX, float anchorY)
		{
			if (dwFactory == null || tf == null) return;
			double pv = PointValuePerContract();
			double rMult = r.MaePoints > 1e-9 ? r.MfePoints / r.MaePoints : 0.0;
			string[] lines =
			{
				(r.IsLong ? "BULLISH reversal  " : "BEARISH reversal  ") + r.TradeType,
				string.Format("Stacked run: {0}   Entry: {1}", r.StackRun, r.EntryPrice),
				string.Format("MFE: +{0:0.00} pt  (${1:0})", r.MfePoints, r.MfePoints * pv),
				string.Format("MAE: -{0:0.00} pt  (${1:0})", r.MaePoints, r.MaePoints * pv),
				string.Format("MFE/MAE: {0:0.00} R", rMult)
			};

			float cardW = 230f, lineH = 18f, padX = 8f, padY = 6f;
			float cardH = padY * 2 + lineH * lines.Length;
			float cx = anchorX + 14f, cy = anchorY - cardH - 10f;
			try { if (cy < 4f) cy = anchorY + 14f; } catch { }

			SharpDX.Direct2D1.RoundedRectangle card = new SharpDX.Direct2D1.RoundedRectangle
			{ Rect = new SharpDX.RectangleF(cx, cy, cardW, cardH), RadiusX = 6f, RadiusY = 6f };
			rt.FillRoundedRectangle(card, bg);
			rt.DrawRoundedRectangle(card, accent, 1.4f);

			for (int i = 0; i < lines.Length; i++)
			{
				SharpDX.DirectWrite.TextFormat use = (i == 0) ? tf : tfSmall;
				SharpDX.DirectWrite.TextLayout tl = null;
				try
				{
					tl = new SharpDX.DirectWrite.TextLayout(dwFactory, lines[i], use, cardW - padX * 2, lineH);
					rt.DrawTextLayout(new SharpDX.Vector2(cx + padX, cy + padY + i * lineH), tl, (i == 0) ? accent : txt);
				}
				catch { }
				finally { if (tl != null) tl.Dispose(); }
			}
		}

		private void DrawNote(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, string msg)
		{
			if (dwFactory == null) { try { dwFactory = new SharpDX.DirectWrite.Factory(); } catch { return; } }
			SharpDX.DirectWrite.TextFormat tf = null;
			SharpDX.DirectWrite.TextLayout tl = null;
			SharpDX.Direct2D1.Brush br = null;
			try
			{
				tf = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", 13f);
				tl = new SharpDX.DirectWrite.TextLayout(dwFactory, msg, tf, 600f, 30f);
				br = System.Windows.Media.Brushes.Orange.ToDxBrush(rt);
				rt.DrawTextLayout(new SharpDX.Vector2(12f, 12f), tl, br);
			}
			catch { }
			finally
			{
				if (tl != null) tl.Dispose();
				if (tf != null) tf.Dispose();
				if (br != null) br.Dispose();
			}
		}

		private void DrawBanner(SharpDX.Direct2D1.RenderTarget rt, string msg)
		{
			if (dwFactory == null) { try { dwFactory = new SharpDX.DirectWrite.Factory(); } catch { return; } }
			SharpDX.DirectWrite.TextFormat tf = null;
			SharpDX.DirectWrite.TextLayout tl = null;
			SharpDX.Direct2D1.Brush bg = null, txt = null;
			try
			{
				tf = new SharpDX.DirectWrite.TextFormat(dwFactory, "Consolas", 18f);
				tl = new SharpDX.DirectWrite.TextLayout(dwFactory, msg, tf, 1700f, 48f);
				bg  = System.Windows.Media.Brushes.Black.ToDxBrush(rt);  bg.Opacity = 0.78f;
				txt = System.Windows.Media.Brushes.Yellow.ToDxBrush(rt);
				// Drawn well below NinjaTrader's built-in indicator label so they don't overlap.
				float by = 48f;
				rt.FillRectangle(new SharpDX.RectangleF(6f, by, tl.Metrics.Width + 18f, tl.Metrics.Height + 10f), bg);
				rt.DrawTextLayout(new SharpDX.Vector2(15f, by + 5f), tl, txt);
			}
			catch { }
			finally
			{
				if (tl != null) tl.Dispose();
				if (tf != null) tf.Dispose();
				if (bg != null) bg.Dispose();
				if (txt != null) txt.Dispose();
			}
		}

		// =====================================================================
		// Mouse interaction (research mode)
		// =====================================================================
		private void OnChartMouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (DisplayMode != IrDisplayMode.Research) return;
				if (e.ChangedButton != MouseButton.Left) return;
				if (ChartControl == null || cachedScale == null || mousePanel == null || ChartBars == null) return;

				System.Windows.Point raw = e.GetPosition(mousePanel as System.Windows.IInputElement);
				double px = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToHorizontalPixels(raw.X, ChartControl.PresentationSource);

				int bar = NearestImbalancedBar(px);
				lastInteraction = DateTime.Now;

				if (bar < 0)                      selectedBarIndex = -1;            // clicked empty space -> hide
				else if (bar == selectedBarIndex) selectedBarIndex = -1;            // same bar -> toggle off
				else { selectedBarIndex = bar; ComputeBarExcursion(bar); }          // new bar -> show its excursion
			}
			catch { }
			try { ForceRefresh(); } catch { }
		}

		private int HitTest(double px, double py)
		{
			// Exact badge-rectangle pass first.
			List<BadgePlace> bl = lastBadgeRects;
			if (bl != null)
				for (int i = 0; i < bl.Count; i++)
				{
					BadgePlace bp = bl[i];
					if (px >= bp.X && px <= bp.X + bp.W && py >= bp.Y && py <= bp.Y + bp.H)
					{
						int idx = records.IndexOf(bp.Rec);
						if (idx >= 0) return idx;
					}
				}

			// Distance fallback against each signal's entry pixel.
			int best = -1; double bestD = double.MaxValue;
			double hTol = LabelHitHalfWidthPixels, vTol = ClickHitboxPixels;
			for (int i = 0; i < records.Count; i++)
			{
				SignalRecord r = records[i];
				float x = ChartControl.GetXByBarIndex(ChartBars, r.BarIndex);
				float yE = cachedScale.GetYByValue(r.EntryPrice);
				double dx = px - x, dy = py - yE;
				double d = Math.Sqrt(dx * dx + dy * dy);
				if (Math.Abs(dx) <= hTol && Math.Abs(dy) <= vTol && d < bestD) { bestD = d; best = i; }
			}
			return best;
		}

		private void OnResearchTimerTick(object sender, EventArgs e)
		{
			try
			{
				if (DisplayMode != IrDisplayMode.Research || selectedBarIndex < 0) return;
				if (ResearchAutoOffMinutes <= 0) return;
				if ((DateTime.Now - lastInteraction).TotalMinutes >= ResearchAutoOffMinutes)
				{
					selectedBarIndex = -1;
					ForceRefresh();
				}
			}
			catch { }
		}
	}
}
