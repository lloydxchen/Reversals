#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

// =============================================================================
//  Reversal_Hunter_Claude_v0_2
//  Comprehensive signal lab. INDICATOR ONLY - never places orders.
//  Builds the validated three-tier architecture as RULES (no trained ML score):
//     TIER 1 RADAR  : rule-based watch zone (fresh extreme + leg + climax flow)
//     TIER 2 SIGNAL : displacement-FVG (Confirmed) | CISD (Early) trigger
//     TIER 3 ELITE  : strongest setups -> most salient paint (crown)
//   + ORB Failure Long module (validated companion, OR15 active)
//   + TICK-momentum confidence badges (short gate + ORB-long size-up)
//   + ES "hard-against" veto -> renders signal DIM, not hidden (preserves
//        species-2 short visibility) ; VIX context optional/fragile toggle
//   + visual-only exit-plan overlay (G/E/A) for shadow-logging trade plans
//
// -----------------------------------------------------------------------------
//  RUNNING "UNCERTAIN / MAY-CHANGE / VERIFY-LIVE" LIST  (track across versions)
//  [P] = on probation at next walk-forward checkpoint (needs ~10 new labeled days)
//   1. [P] CISD-early entry            - toggle UseCisdEarly (default on in Default preset)
//   2. [P] 15-min trigger window       - input TriggerWindowMin (was 25)
//   3. [P] 0.75-ATR displacement       - input FvgDisplacementAtr (was 1.0)
//   4. [P] FVG-OR-absorption coverage  - toggle UseAbsorptionCoverage (Aggressive preset)
//   5. [P] TICK-momentum SHORT gate    - n=10 in backtest; PROMISING not proven. UseTickConfirmation
//   6. [P] TR Vol+Imb long feature     - NOT in indicator (needs footprint feed live). v0.3.
//   7. Weekly algorithmic pivots       - DEFERRED to v0.3 (small +; UsePivotsPreview stub only)
//   8. Trained 40-feat LEAN score      - NOT ported (option A = rules). Possible v0.3 coeff export.
//   9. VIX context                     - FRAGILE (symbol/feed); default OFF. Verify symbol live.
//  10. Absorption here = 1-min PROXY   - real footprint (TR Vol/Imb) is live-only, not in backtest edge
//  11. Radar climax-flow threshold     - using BarDelta cumsum proxy for cvd_m15<=-2; verify vs research
//  12. Exit-plan levels are VISUAL ONLY - no orders; for shadow-log comparison
//  VERIFY-LIVE: TICK/ES/VIX symbols resolve; OR windows stamp correctly; no repaint.
// -----------------------------------------------------------------------------
//  SIZING REMINDER (not enforced, just notes): starter size; budget 550-700 pts
//   DD per MNQ; expect 7-10 consecutive losers as NORMAL at ~32% win.
// =============================================================================

// Enums at GLOBAL scope. NinjaScript's code generator emits accessor partials into
// the Strategies and MarketAnalyzerColumns namespaces in addition to Indicators;
// those partials cannot see types scoped inside NinjaTrader.NinjaScript.Indicators,
// which is what caused CS0246 ('RhPreset'/'RhExitMode' not found). Global scope is
// visible to all generated partials and to the indicator class below.
public enum RhPreset
{
	Conservative,   // radar + displacement-FVG only, exit-A, no early
	Default,        // radar + FVG + CISD-early, exit-G, TICK badges  (validated Signal tier)
	Aggressive      // + absorption-coverage proxy, wider window, exit-G
}

public enum RhExitMode
{
	G_Default,      // 60 stop -> BE@+100 -> half@+200 -> runner
	E_Elite,        // 80 stop -> BE@+200 -> full runner
	A_Conservative  // half@+100, cap 600
}

// v0.3: Live = clean trading visuals only. Research = (next step) click a signal to inspect MFE/MAE.
public enum RhDisplayMode
{
	Live,
	Research
}

// $ per point per contract source for Research-mode dollar table
public enum RhDollarInstrument
{
	Auto,
	MNQ,
	NQ
}

// Badge visual presets for the render-time labels.
public enum RhLabelStyle
{
	Classic,   // solid direction capsule + dividers (baseline)
	Accent,    // direction base + blue/purple grade pill + accent TICK (multi-color)
	Glow,      // direction base + outer glow + 3D sheen, bold
	Dark,      // dark container + direction tint (medium) + white text + glowing halo + blue/purple grade
	Frost,     // same as Dark but a lighter, more saturated container
	Midnight   // same as Dark but a deeper, darker container
}

public enum RhEntryMarker
{
	Crosshair,   // target ring + ticks + center dot
	Arrowhead,   // direction-aware chevron pointing the trade way
	Dot          // small dot inside a ring
}

// Dashboard snap positions. Kept global-scope so NT generated code can see it if needed.
public enum RhDashboardAnchor
{
	TopLeft,
	TopRight,
	BottomLeft,
	BottomRight
}

// Sub-namespace ".ReversalHunter" -> NT8 lists this indicator under a "ReversalHunter"
// folder in the indicator picker. The folder is driven by the namespace, NOT the filename.
namespace NinjaTrader.NinjaScript.Indicators.ReversalHunter
{
	public class Reversal_Hunter_Claude : Indicator
	{
		#region Inputs
		[NinjaScriptProperty]
		[Display(Name = "DisplayMode", Description = "Live = clean trading visuals. Research = click a signal to inspect its MFE/MAE (interactive layer lands next update; currently behaves as Live).", Order = 1, GroupName = "0. Mode")]
		public RhDisplayMode DisplayMode { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Preset", Description = "Conservative=FVG only/exitA. Default=validated Signal tier (FVG+CISD/exitG/TICK). Aggressive=+absorption coverage proxy. Sets defaults; manual toggles still apply.", Order = 1, GroupName = "0. Preset")]
		public RhPreset Preset { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ApplyPresetDefaults", Description = "If true, the chosen Preset overrides the individual toggles below on reload. Turn OFF to hand-tune.", Order = 2, GroupName = "0. Preset")]
		public bool ApplyPresetDefaults { get; set; }

		// ---- session ----
		[NinjaScriptProperty]
		[Display(Name = "RthStartTime (HHmmss)", Order = 1, GroupName = "1. Session")]
		public int RthStartTime { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "RthEndTime (HHmmss)", Order = 2, GroupName = "1. Session")]
		public int RthEndTime { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "FlattenTime (HHmmss)", Description = "EOD flatten reference for exit-plan overlay (visual only)", Order = 3, GroupName = "1. Session")]
		public int FlattenTime { get; set; }

		// ---- radar (Tier 1) ----
		[NinjaScriptProperty]
		[Range(5, int.MaxValue)]
		[Display(Name = "ExtremeLookback", Description = "Fresh N-bar high/low for radar (research: 30)", Order = 1, GroupName = "2. Radar")]
		public int ExtremeLookback { get; set; }

		[NinjaScriptProperty]
		[Range(0.1, 10)]
		[Display(Name = "MinLegAtr", Description = "Min faded-move size in ATR (research: 1.5)", Order = 2, GroupName = "2. Radar")]
		public double MinLegAtr { get; set; }

		[NinjaScriptProperty]
		[Range(1, 200)]
		[Display(Name = "AtrPeriod", Order = 3, GroupName = "2. Radar")]
		public int AtrPeriod { get; set; }

		[NinjaScriptProperty]
		[Range(1, 100)]
		[Display(Name = "ClimaxCvdLookback", Description = "Bars for climax-flow (BarDelta cumsum) proxy", Order = 4, GroupName = "2. Radar")]
		public int ClimaxCvdLookback { get; set; }

		[NinjaScriptProperty]
		[Range(0, int.MaxValue)]
		[Display(Name = "EpisodeCooldownMin", Description = "Radar episode merge cooldown (research: 15)", Order = 5, GroupName = "2. Radar")]
		public int EpisodeCooldownMin { get; set; }

		// ---- triggers (Tier 2) ----
		[NinjaScriptProperty]
		[Range(1, 120)]
		[Display(Name = "TriggerWindowMin", Description = "[PROBATION] Minutes after radar arm to allow a trigger (was 25, now 15)", Order = 1, GroupName = "3. Triggers")]
		public int TriggerWindowMin { get; set; }

		[NinjaScriptProperty]
		[Range(0.1, 5)]
		[Display(Name = "FvgDisplacementAtr", Description = "[PROBATION] Displacement-bar body >= this * ATR (was 1.0, now 0.75)", Order = 2, GroupName = "3. Triggers")]
		public double FvgDisplacementAtr { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseCisdEarly", Description = "[PROBATION] Allow CISD close-beyond-prev-opposite-open as Early entry", Order = 3, GroupName = "3. Triggers")]
		public bool UseCisdEarly { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseAbsorptionCoverage", Description = "[PROBATION] FVG-OR-absorption coverage mode (1-min proxy; real footprint is live-only)", Order = 4, GroupName = "3. Triggers")]
		public bool UseAbsorptionCoverage { get; set; }

		// ---- cross-market ----
		[NinjaScriptProperty]
		[Display(Name = "UseEsContext", Description = "ES 'hard-against' veto -> renders signal DIM not hidden", Order = 1, GroupName = "4. CrossMarket")]
		public bool UseEsContext { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EsSymbol", Order = 2, GroupName = "4. CrossMarket")]
		public string EsSymbol { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseVixContext", Description = "[FRAGILE] VIX context badge. Default OFF - verify symbol/feed before trusting.", Order = 3, GroupName = "4. CrossMarket")]
		public bool UseVixContext { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VixSymbol", Order = 4, GroupName = "4. CrossMarket")]
		public string VixSymbol { get; set; }

		// ---- TICK ----
		[NinjaScriptProperty]
		[Display(Name = "UseTickConfirmation", Description = "[PROBATION n=10] TICK-momentum badge: short gate + ORB-long size-up", Order = 1, GroupName = "5. TICK")]
		public bool UseTickConfirmation { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "TickSymbol", Order = 2, GroupName = "5. TICK")]
		public string TickSymbol { get; set; }

		[NinjaScriptProperty]
		[Range(1, 50)]
		[Display(Name = "TickMomentumBars", Description = "TICK momentum lookback (research: 5)", Order = 3, GroupName = "5. TICK")]
		public int TickMomentumBars { get; set; }

		// ---- ORB module ----
		[NinjaScriptProperty]
		[Display(Name = "ShowOrbModule", Description = "Master switch for the ORB/IB family (failure-long, ORB-short + IB60 research lanes, and OR/IB lines). Turn OFF to declutter; it's a logically separate module. CSV still logs fires.", Order = 0, GroupName = "6. ORB")]
		public bool ShowOrbModule { get; set; }

		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name = "OrbMinutesFast", Description = "Comparison-only fast OR (research best is OR10-15)", Order = 1, GroupName = "6. ORB")]
		public int OrbMinutesFast { get; set; }

		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name = "OrbMinutesStandard", Description = "PRIMARY active OR window (research: 10-15; 15 default)", Order = 2, GroupName = "6. ORB")]
		public int OrbMinutesStandard { get; set; }

		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name = "IbMinutes", Order = 3, GroupName = "6. ORB")]
		public int IbMinutes { get; set; }

		// ---- exits / overlay ----
		[NinjaScriptProperty]
		[Display(Name = "ExitMode", Description = "Visual exit-plan overlay. G=default, E=elite monster, A=conservative", Order = 1, GroupName = "7. ExitPlan")]
		public RhExitMode ExitMode { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowExitPlan", Description = "Paint stop/BE/partial/runner levels (visual only, no orders)", Order = 2, GroupName = "7. ExitPlan")]
		public bool ShowExitPlan { get; set; }

		// ---- general ----
		[NinjaScriptProperty]
		[Range(0, int.MaxValue)]
		[Display(Name = "SignalCooldownMin", Order = 1, GroupName = "8. General")]
		public int SignalCooldownMin { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowOrbLines", Order = 2, GroupName = "8. General")]
		public bool ShowOrbLines { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowRadarZones", Description = "Paint Tier-1 radar watch marks", Order = 3, GroupName = "8. General")]
		public bool ShowRadarZones { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowLabels", Order = 4, GroupName = "8. General")]
		public bool ShowLabels { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowResearchLabels", Order = 5, GroupName = "8. General")]
		public bool ShowResearchLabels { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowDashboard", Order = 6, GroupName = "8. General")]
		public bool ShowDashboard { get; set; }

		[Display(Name = "DashboardAnchor", Description = "Corner snap position for the dashboard. Hold Shift and drag the dashboard header to move it.", Order = 6, GroupName = "8. General")]
		public RhDashboardAnchor DashboardAnchor { get; set; }

		[Display(Name = "EnableShiftDragDashboard", Description = "Hold Shift + drag the dashboard header, then release to snap it to the nearest corner.", Order = 6, GroupName = "8. General")]
		public bool EnableShiftDragDashboard { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EnableShortPrototype", Description = "[PROTOTYPE] simple lower-high reversal short so TICK short gate has something to fire on. NOT the validated model.", Order = 7, GroupName = "8. General")]
		public bool EnableShortPrototype { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EnableCsvLogging", Order = 8, GroupName = "8. General")]
		public bool EnableCsvLogging { get; set; }

		// ---- display / view filters (mix & match: each category independent) ----
		[NinjaScriptProperty]
		[Display(Name = "Show: S-Rank", Description = "Show supreme S-rank signals (elite + confirmed + AM window). The tip-top trades.", Order = 1, GroupName = "9. Display")]
		public bool ShowSRank { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show: Elite", Description = "Show elite signals (confirmed + TICK + ES-ok + flow-ok, not S-rank).", Order = 2, GroupName = "9. Display")]
		public bool ShowElite { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show: Stars (TICK)", Description = "Show TICK-confirmed (⭐) signals that aren't elite.", Order = 3, GroupName = "9. Display")]
		public bool ShowStars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show: Standard", Description = "Show plain tradable Confirmed signals (no TICK, not Early).", Order = 4, GroupName = "9. Display")]
		public bool ShowStandard { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Show: Early", Description = "Show Early (CISD) entries.", Order = 5, GroupName = "9. Display")]
		public bool ShowEarly { get; set; }

		[NinjaScriptProperty]
		[Range(0, 235959)]
		[Display(Name = "SRankCutoffTime (HHmmss)", Description = "S-rank requires the signal at/before this time (edge is morning-loaded; research: <= 11:00).", Order = 6, GroupName = "9. Display")]
		public int SRankCutoffTime { get; set; }

		// ---- v0.3 lollipop visuals ----
		[NinjaScriptProperty]
		[Range(6, 48)]
		[Display(Name = "EntryMarkerFontSize", Description = "Glyph size for the exact-entry marker.", Order = 1, GroupName = "10. Visuals")]
		public int EntryMarkerFontSize { get; set; }

		[NinjaScriptProperty]
		[Range(6, 36)]
		[Display(Name = "LabelFontSize", Order = 2, GroupName = "10. Visuals")]
		public int LabelFontSize { get; set; }

		[NinjaScriptProperty]
		[Range(0, int.MaxValue)]
		[Display(Name = "LabelOffsetTicks", Description = "Min distance (ticks) the label is pushed off price. Final = max(this*TickSize, ATR*AtrOffsetMultiplier).", Order = 3, GroupName = "10. Visuals")]
		public int LabelOffsetTicks { get; set; }

		[NinjaScriptProperty]
		[Range(1, 300)]
		[Display(Name = "LabelSwingLookback", Description = "Labels anchor beyond the swing high/low of the last N bars so they clear clustered price (long connector OK). 0/1 = local bar only.", Order = 4, GroupName = "10. Visuals")]
		public int LabelSwingLookback { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowEntryPriceInLabel", Description = "Show the entry price (e.g. (28,940)) just outside the label box - below for longs, above for shorts.", Order = 5, GroupName = "10. Visuals")]
		public bool ShowEntryPriceInLabel { get; set; }

		[NinjaScriptProperty]
		[Range(6, 16)]
		[Display(Name = "EntryPriceFontSize", Description = "Font size for the entry-price text outside the box (kept small).", Order = 6, GroupName = "10. Visuals")]
		public int EntryPriceFontSize { get; set; }

		[NinjaScriptProperty]
		[Range(1, 100)]
		[Display(Name = "LabelMinBarGap", Description = "Two same-direction labels within this many bars are stacked into separate rows so they never overlap.", Order = 7, GroupName = "10. Visuals")]
		public int LabelMinBarGap { get; set; }

		[NinjaScriptProperty]
		[Range(2, 200)]
		[Display(Name = "LabelRowGapTicks", Description = "Vertical spacing (ticks) between stacked label rows. Increase if stacked labels still touch.", Order = 8, GroupName = "10. Visuals")]
		public int LabelRowGapTicks { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseAtrLabelOffset", Description = "Also space labels by ATR so they scale with volatility.", Order = 4, GroupName = "10. Visuals")]
		public bool UseAtrLabelOffset { get; set; }

		[NinjaScriptProperty]
		[Range(0.0, 5.0)]
		[Display(Name = "AtrOffsetMultiplier", Order = 5, GroupName = "10. Visuals")]
		public double AtrOffsetMultiplier { get; set; }

		[NinjaScriptProperty]
		[Range(1, 10)]
		[Display(Name = "ConnectorWidth", Description = "Thickness of the lollipop connector line (label -> entry).", Order = 6, GroupName = "10. Visuals")]
		public int ConnectorWidth { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "ConnectorOpacity", Order = 7, GroupName = "10. Visuals")]
		public int ConnectorOpacity { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EntryMarkerHalo", Description = "Draw a contrasting backdrop behind the entry glyph so it pops off candles.", Order = 8, GroupName = "10. Visuals")]
		public bool EntryMarkerHalo { get; set; }

		[NinjaScriptProperty]
		[Range(1, 8)]
		[Display(Name = "EntryMarkerHaloOffset", Description = "Backdrop glyph is this many font-units larger.", Order = 9, GroupName = "10. Visuals")]
		public int EntryMarkerHaloOffset { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "EarlyOpacityPercent", Order = 10, GroupName = "10. Visuals")]
		public int EarlyOpacityPercent { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "StandardOpacityPercent", Order = 11, GroupName = "10. Visuals")]
		public int StandardOpacityPercent { get; set; }

		[XmlIgnore]
		[Display(Name = "LongSignalBrush", Description = "Color for long signals (label, connector, marker).", Order = 12, GroupName = "10. Visuals")]
		public Brush LongSignalBrush { get; set; }
		[Browsable(false)]
		public string LongSignalBrushSerialize
		{
			get { return Serialize.BrushToString(LongSignalBrush); }
			set { LongSignalBrush = Serialize.StringToBrush(value); }
		}

		[XmlIgnore]
		[Display(Name = "ShortSignalBrush", Description = "Color for short signals (label, connector, marker).", Order = 13, GroupName = "10. Visuals")]
		public Brush ShortSignalBrush { get; set; }
		[Browsable(false)]
		public string ShortSignalBrushSerialize
		{
			get { return Serialize.BrushToString(ShortSignalBrush); }
			set { ShortSignalBrush = Serialize.StringToBrush(value); }
		}

		// ---- v0.4 Research Mode (MFE/MAE inspection) ----
		[NinjaScriptProperty]
		[Range(1, 1000)]
		[Display(Name = "MaxMfeLookaheadBars", Description = "Bars after entry to scan for MFE/MAE (research only).", Order = 1, GroupName = "11. Research")]
		public int MaxMfeLookaheadBars { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowMaeToo", Description = "Also draw the MAE (adverse) box for the selected signal.", Order = 2, GroupName = "11. Research")]
		public bool ShowMaeToo { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "MfeBoxOpacity", Order = 3, GroupName = "11. Research")]
		public int MfeBoxOpacity { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "MaeBoxOpacity", Order = 4, GroupName = "11. Research")]
		public int MaeBoxOpacity { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowPointsInsideMfeBox", Description = "Print MFE/MAE pts + $ (1 contract) centered inside each box.", Order = 5, GroupName = "11. Research")]
		public bool ShowPointsInsideMfeBox { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowDollarTablePanel", Description = "Show the fixed MFE/MAE dollar table panel for the selected signal.", Order = 6, GroupName = "11. Research")]
		public bool ShowDollarTablePanel { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "DollarInstrument", Description = "$/point/contract source. Auto: MNQ=$2, NQ=$20, else MasterInstrument.PointValue.", Order = 7, GroupName = "11. Research")]
		public RhDollarInstrument DollarInstrument { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "MfeMaePanelPosition", Order = 8, GroupName = "11. Research")]
		public TextPosition MfeMaePanelPosition { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "MfeMaePanelOpacity", Order = 9, GroupName = "11. Research")]
		public int MfeMaePanelOpacity { get; set; }

		[NinjaScriptProperty]
		[Range(6, 28)]
		[Display(Name = "MfeMaePanelFontSize", Order = 10, GroupName = "11. Research")]
		public int MfeMaePanelFontSize { get; set; }

		[NinjaScriptProperty]
		[Range(0, 120)]
		[Display(Name = "ResearchAutoOffMinutes", Description = "Clear the selected MFE/MAE overlay after this many minutes of no clicks (0 = never).", Order = 11, GroupName = "11. Research")]
		public int ResearchAutoOffMinutes { get; set; }

		[NinjaScriptProperty]
		[Range(10, 5000)]
		[Display(Name = "MaxStoredSignals", Description = "Cap on retained clickable signal records (oldest dropped).", Order = 12, GroupName = "11. Research")]
		public int MaxStoredSignals { get; set; }

		[NinjaScriptProperty]
		[Range(5, 200)]
		[Display(Name = "ClickHitboxPixels", Description = "Vertical click tolerance (pixels) around a signal's marker / label to select it.", Order = 13, GroupName = "11. Research")]
		public int ClickHitboxPixels { get; set; }

		[NinjaScriptProperty]
		[Range(20, 400)]
		[Display(Name = "LabelHitHalfWidthPixels", Description = "Horizontal click tolerance (pixels). Labels are wide, so this is generous; the nearest signal at your click height is selected.", Order = 14, GroupName = "11. Research")]
		public int LabelHitHalfWidthPixels { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowClickReadout", Description = "Show the bottom-right click-coordinates debug readout (for calibrating clicks if needed). Off by default.", Order = 15, GroupName = "11. Research")]
		public bool ShowClickReadout { get; set; }

		// ---- v0.5 true order-flow delta ----
		[NinjaScriptProperty]
		[Display(Name = "UseTrueDelta", Description = "Use a hidden 1-min Volumetric (BidAsk) series for REAL BarDelta/CVD instead of the signed-volume proxy. Falls back to proxy if unavailable.", Order = 1, GroupName = "12. OrderFlow")]
		public bool UseTrueDelta { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "VolumetricInstrument", Description = "Instrument for the hidden volumetric series. Blank = chart instrument (auto). Set e.g. 'MNQ 06-26' for historical testing or 'MNQ 09-26' for live front month.", Order = 2, GroupName = "12. OrderFlow")]
		public string VolumetricInstrument { get; set; }

		// ---- Phase 1-3: render-time premium visual layer ----
		[NinjaScriptProperty]
		[Display(Name = "UseRenderTimeLabels", Description = "Draw signal badges at render time in pixel space (the new premium layer). Solves overlap that data-anchored labels can't.", Order = 1, GroupName = "13. Premium Visual Layer")]
		public bool UseRenderTimeLabels { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseLegacyDrawTextLabels", Description = "Fallback: also draw the old Draw.Text lollipop labels. Off by default; turn on only if the render layer misbehaves.", Order = 2, GroupName = "13. Premium Visual Layer")]
		public bool UseLegacyDrawTextLabels { get; set; }

		[NinjaScriptProperty]
		[Range(0, 200)]
		[Display(Name = "LabelBaseGapPx", Description = "Pixels between price and the first badge lane (longs below / shorts above).", Order = 3, GroupName = "13. Premium Visual Layer")]
		public int LabelBaseGapPx { get; set; }

		[NinjaScriptProperty]
		[Range(8, 80)]
		[Display(Name = "LabelLaneStepPx", Description = "Vertical pixel step between stacked badge lanes (used by the collision engine in a later phase).", Order = 4, GroupName = "13. Premium Visual Layer")]
		public int LabelLaneStepPx { get; set; }

		[NinjaScriptProperty]
		[Range(0, 30)]
		[Display(Name = "LabelCornerRadius", Description = "Rounded-corner radius (pixels) of the badge capsule.", Order = 5, GroupName = "13. Premium Visual Layer")]
		public int LabelCornerRadius { get; set; }

		[NinjaScriptProperty]
		[Range(0, 40)]
		[Display(Name = "LabelPaddingX", Description = "Horizontal padding (pixels) inside the badge.", Order = 6, GroupName = "13. Premium Visual Layer")]
		public int LabelPaddingX { get; set; }

		[NinjaScriptProperty]
		[Range(0, 40)]
		[Display(Name = "LabelPaddingY", Description = "Vertical padding (pixels) inside the badge.", Order = 7, GroupName = "13. Premium Visual Layer")]
		public int LabelPaddingY { get; set; }

		[NinjaScriptProperty]
		[Range(0, 100)]
		[Display(Name = "LabelOpacity", Description = "Opacity (0-100) of the badge's translucent dark base.", Order = 8, GroupName = "13. Premium Visual Layer")]
		public int LabelOpacity { get; set; }

		// ---- Phase 4: segmented badges + configurable icon/glyph mapping ----
		[NinjaScriptProperty]
		[Display(Name = "UseSegmentedBadges", Description = "Draw badges as segmented capsules (icon | identity | mode | grade) with divider lines. Off = single compact label.", Order = 9, GroupName = "13. Premium Visual Layer")]
		public bool UseSegmentedBadges { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowTradeIcons", Description = "Show a leading tier/direction icon in each badge.", Order = 10, GroupName = "13. Premium Visual Layer")]
		public bool ShowTradeIcons { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseEmojiIcons", Description = "Use full emoji icons (crown/diamond/etc). NOTE: color emoji often render as mono/boxes in NinjaTrader's chart text - leave OFF if they look wrong.", Order = 11, GroupName = "13. Premium Visual Layer")]
		public bool UseEmojiIcons { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseFallbackGlyphIcons", Description = "When emoji are off, use crisp monochrome glyphs (star/diamond/check/triangle) that always render.", Order = 12, GroupName = "13. Premium Visual Layer")]
		public bool UseFallbackGlyphIcons { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "SRankIcon", Description = "Emoji/glyph for S-Rank (used when UseEmojiIcons is on).", Order = 13, GroupName = "13. Premium Visual Layer")]
		public string SRankIcon { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EliteIcon", Description = "Emoji/glyph for Elite.", Order = 14, GroupName = "13. Premium Visual Layer")]
		public string EliteIcon { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "TickIcon", Description = "Emoji/glyph for TICK-confirmed.", Order = 15, GroupName = "13. Premium Visual Layer")]
		public string TickIcon { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "StandardLongIcon", Description = "Emoji/glyph for standard long.", Order = 16, GroupName = "13. Premium Visual Layer")]
		public string StandardLongIcon { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "StandardShortIcon", Description = "Emoji/glyph for standard short.", Order = 17, GroupName = "13. Premium Visual Layer")]
		public string StandardShortIcon { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EarlyIcon", Description = "Emoji/glyph for early signals.", Order = 18, GroupName = "13. Premium Visual Layer")]
		public string EarlyIcon { get; set; }

		// ---- Phase 5: collision lanes + candle protection ----
		[NinjaScriptProperty]
		[Range(1, 24)]
		[Display(Name = "MaxLabelLanes", Description = "Max stacked lanes a badge may be pushed into before it compacts or hides.", Order = 19, GroupName = "13. Premium Visual Layer")]
		public int MaxLabelLanes { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ProtectCandles", Description = "Keep badges off the candles/wicks in their horizontal span (longs stay below local lows, shorts above local highs).", Order = 20, GroupName = "13. Premium Visual Layer")]
		public bool ProtectCandles { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "UseCompactLabelsWhenCrowded", Description = "If a full badge can't fit any lane, shrink it to an icon-only chip.", Order = 21, GroupName = "13. Premium Visual Layer")]
		public bool UseCompactLabelsWhenCrowded { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "HideLowPriorityLabelsWhenCrowded", Description = "If even a compact chip can't fit, hide the lowest-priority signals rather than overlap.", Order = 22, GroupName = "13. Premium Visual Layer")]
		public bool HideLowPriorityLabelsWhenCrowded { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowGlyphOnlyMarkers", Description = "Always render badges as tiny icon-only chips (ultra-compact mode).", Order = 23, GroupName = "13. Premium Visual Layer")]
		public bool ShowGlyphOnlyMarkers { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowLeaderLines", Description = "Draw a connector from each badge to its entry, with a marker at the entry.", Order = 24, GroupName = "13. Premium Visual Layer")]
		public bool ShowLeaderLines { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EntryMarkerStyle", Description = "Shape drawn at each signal's exact entry: Crosshair (precise), Arrowhead (points the trade way), or Dot.", Order = 24, GroupName = "13. Premium Visual Layer")]
		public RhEntryMarker EntryMarkerStyle { get; set; }

		[NinjaScriptProperty]
		[Range(0, 40)]
		[Display(Name = "BadgeGapPx", Description = "Minimum whitespace (pixels) enforced between any two badges.", Order = 25, GroupName = "13. Premium Visual Layer")]
		public int BadgeGapPx { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EntryArrowLong", Description = "Glyph drawn at a long's entry (placeholder; swap for an emoji later).", Order = 26, GroupName = "13. Premium Visual Layer")]
		public string EntryArrowLong { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "EntryArrowShort", Description = "Glyph drawn at a short's entry.", Order = 27, GroupName = "13. Premium Visual Layer")]
		public string EntryArrowShort { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "ShowContractTable", Description = "Add the per-contract (1/2/3/5/10) MFE$/MAE$ rows to the detail card.", Order = 28, GroupName = "13. Premium Visual Layer")]
		public bool ShowContractTable { get; set; }

		[NinjaScriptProperty]
		[Display(Name = "Label Style", Description = "Badge preset: Classic, Accent, Glow, Dark (white text + blue/purple grade + halo), Frost (lighter), Midnight (darker). Switch to compare.", Order = 1, GroupName = "0. Label Style")]
		public RhLabelStyle LabelStyle { get; set; }
		#endregion

		#region State variables
		// indicator-internal series
		private ATR atr;
		private double cvdRun;                 // running cumulative BarDelta (true if available, else proxy) per session
		private Series<double> cvdSeries;      // cumulative delta as a Series for lookbacks
		private int volIdx = -1;               // BarsArray index of the hidden volumetric series
		private bool trueDeltaActive;          // true on bars where real volumetric delta was read
		private string volInstrUsed = "";      // resolved volumetric instrument name

		// ORB
		private double or5High, or5Low, or15High, or15Low, ib60High, ib60Low;
		private bool or5Done, or15Done, ib60Done;
		private bool or15BrokeBelow, or15BrokeAbove, ib60BrokeAbove, ib60BrokeBelow;
		private DateTime sessionDate = Core.Globals.MinDate;
		private DateTime orWindowStart = Core.Globals.MinDate;

		// radar episodes
		private DateTime lastRadarLong  = Core.Globals.MinDate;
		private DateTime lastRadarShort = Core.Globals.MinDate;
		private int      radarArmedBarLong  = -1;
		private int      radarArmedBarShort = -1;
		private DateTime radarArmTimeLong  = Core.Globals.MinDate;
		private DateTime radarArmTimeShort = Core.Globals.MinDate;
		private double   radarExtremeLong  = 0;   // the low we're trying to fade (long)
		private double   radarExtremeShort = 0;   // the high we're trying to fade (short)

		// signal cooldowns
		private DateTime lastSigLong  = Core.Globals.MinDate;
		private DateTime lastSigShort = Core.Globals.MinDate;
		private DateTime lastOrbFailLong  = Core.Globals.MinDate;
		private DateTime lastOrbFailShort = Core.Globals.MinDate;
		private DateTime lastShortProto   = Core.Globals.MinDate;
		private DateTime lastIb60Long  = Core.Globals.MinDate;
		private DateTime lastIb60Short = Core.Globals.MinDate;

		// secondary series indices
		private int tickIdx = -1, esIdx = -1, vixIdx = -1;
		private bool tickAvail, esAvail, vixAvail;
		private double tickMom, tickC0, tickC5;
		private double esMom5;
		private double vixMom5;

		// logging / dashboard
		private string logPath = string.Empty;
		private bool logHeaderWritten;
		private string lastSignalText = "(none)";
		private int tickBarsNeeded;

		// label anti-collision: remember placed labels so clustered same-direction labels stack into rows
		private class PlacedLabel { public int Bar; public bool IsLong; public int Row; public int HalfWidthBars; }

		// Phase 5: a resolved badge rectangle in pixel space (after lane/collision placement)
		private class BadgePlace
		{
			public SignalRecord Rec;
			public float X, Y, W, H;   // X = left, Y = top, W/H pixel size
			public float EntryX, EntryY;
			public bool IsLong, Compact, Hidden;
			public List<SegItem> Segs;
		}

		// one segment of a badge. Accent => tier icon color (Classic). Role: 0 icon, 1 identity, 2 mode, 3 grade.
		private class SegItem
		{
			public string Text; public bool Accent; public int Role;
			public SegItem(string t, bool a) { Text = t; Accent = a; Role = 1; }
			public SegItem(string t, bool a, int role) { Text = t; Accent = a; Role = role; }
		}
		private List<PlacedLabel> placedLabels = new List<PlacedLabel>();

		// ---- v0.4 Research Mode ----
		private class SignalRecord
		{
			public int SignalIndex;
			public int BarIndex;
			public DateTime Time;
			public bool IsLong;
			public string TradeType;
			public double EntryPrice;
			public double LabelPrice;   // y of the label box (for click hit-testing)
			public string LabelText;
			public bool MfeCalculated;
			public double MfePrice, MaePrice;
			public double MfePoints, MaePoints;
			public int MfeBarIndex, MaeBarIndex;
			public DateTime MfeTime, MaeTime;
			// Phase 2 visual-model additions
			public double High, Low;        // signal bar extremes (badge anchors)
			public string Grade;            // A+/A/A-/B+ ... derived from tier
			public bool TickConfirmed;
			public int Priority;            // higher = more important when crowded
			public string CompactText;      // short badge text (Phase 3); full segmented form in Phase 4
		}
		private List<SignalRecord> records = new List<SignalRecord>();
		private List<BadgePlace> lastBadgeRects = new List<BadgePlace>();   // latest rendered badges, for click hit-testing
		private int signalSeq;
		private int selectedIndex = -1;
		private ChartScale cachedScale;
		private DispatcherTimer researchTimer;
		private DateTime lastInteraction = DateTime.MinValue;
		private bool mouseHooked;
		private NinjaTrader.Gui.Chart.ChartPanel mousePanel;
		private string clickDebug = "Click: (none)";

		// Dashboard drag/snap state. The HUD is SharpDX pixels, so drag is handled manually.
		private SharpDX.RectangleF dashboardRect = new SharpDX.RectangleF();
		private SharpDX.RectangleF dashboardDragRect = new SharpDX.RectangleF();
		private bool dashboardDragging;
		private float dashboardDragX;
		private float dashboardDragY;
		private double dashboardDragOffsetX;
		private double dashboardDragOffsetY;

		// Phase 3: render-time badge resources (SharpDX)
		private SharpDX.DirectWrite.Factory dwFactory;
		private Brush badgeBaseBrush, badgeTextBrush, selGlowBrush;
		private Brush badgeTextDark;
		private Brush dividerBrush;
		private Brush accGold, accCyan, accAmber, leaderBrush;
		private Brush accBlue, accPurple;   // grade accent: blue for longs, purple for shorts
		private Brush rowLabelBrush;
		private const string OV = "rh_ov_";   // research overlay tag prefix
		#endregion

		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description = "Reversal Hunter (stable name; version shown in dashboard) - Phase 5: pixel-space lane collision + candle protection so badges stop overlapping and covering price. Indicator only, no orders.";
				Name        = "Reversal_Hunter_Claude";
				Calculate   = Calculate.OnBarClose;
				IsOverlay   = true;
				DisplayInDataBox = false;
				DrawOnPricePanel = true;
				PaintPriceMarkers = false;
				IsSuspendedWhileInactive = true;

				DisplayMode         = RhDisplayMode.Research;
				Preset              = RhPreset.Default;
				ApplyPresetDefaults = true;

				RthStartTime = 93000;
				RthEndTime   = 160000;
				FlattenTime  = 155900;

				ExtremeLookback   = 30;
				MinLegAtr         = 1.5;
				AtrPeriod         = 14;
				ClimaxCvdLookback = 15;
				EpisodeCooldownMin = 15;

				TriggerWindowMin    = 15;
				FvgDisplacementAtr  = 0.75;
				UseCisdEarly        = true;
				UseAbsorptionCoverage = false;

				UseEsContext = true;
				EsSymbol     = "ES 06-26";
				UseVixContext = false;
				VixSymbol     = "^VIX";

				UseTickConfirmation = true;
				TickSymbol          = "^TICK";
				TickMomentumBars    = 5;

				OrbMinutesFast     = 5;
				OrbMinutesStandard = 15;
				IbMinutes          = 60;

				ExitMode     = RhExitMode.G_Default;
				ShowExitPlan = false;   // v0.3: hidden by default (declutter)

				SignalCooldownMin  = 15;
				ShowOrbLines       = true;
				ShowRadarZones     = true;
				ShowLabels         = true;
				ShowResearchLabels = false; // v0.3: hidden by default (proto/IB/ORB-short)
				ShowDashboard      = true;
				DashboardAnchor    = RhDashboardAnchor.TopRight;
				EnableShiftDragDashboard = true;
				EnableShortPrototype = true;
				EnableCsvLogging   = true;

				ShowOrbModule  = false; // v0.3: separate module, hidden by default
				ShowSRank      = true;
				ShowElite      = true;
				ShowStars      = true;
				ShowStandard   = true;
				ShowEarly      = true;
				SRankCutoffTime = 110000;

				EntryMarkerFontSize = 18;
				LabelFontSize       = 13;
				LabelOffsetTicks    = 40;
				LabelSwingLookback  = 20;
				ShowEntryPriceInLabel = true;
				EntryPriceFontSize  = 9;
				LabelMinBarGap      = 12;
				LabelRowGapTicks    = 20;
				UseAtrLabelOffset   = true;
				AtrOffsetMultiplier = 0.35;
				ConnectorWidth      = 3;
				ConnectorOpacity    = 85;
				EntryMarkerHalo     = true;
				EntryMarkerHaloOffset = 3;
				EarlyOpacityPercent   = 70;
				StandardOpacityPercent = 85;
				LongSignalBrush  = Brushes.LimeGreen;
				ShortSignalBrush = Brushes.Crimson;

				MaxMfeLookaheadBars = 60;
				ShowMaeToo          = true;
				MfeBoxOpacity       = 18;
				MaeBoxOpacity       = 14;
				ShowPointsInsideMfeBox = true;
				ShowDollarTablePanel   = true;
				DollarInstrument    = RhDollarInstrument.Auto;
				MfeMaePanelPosition = TextPosition.BottomRight;
				MfeMaePanelOpacity  = 80;
				MfeMaePanelFontSize = 13;
				ResearchAutoOffMinutes = 5;
				MaxStoredSignals    = 300;
				ClickHitboxPixels   = 30;
				LabelHitHalfWidthPixels = 150;

				UseRenderTimeLabels    = true;
				UseLegacyDrawTextLabels = false;
				LabelBaseGapPx         = 32;
				LabelLaneStepPx        = 28;
				LabelCornerRadius      = 8;
				LabelPaddingX          = 8;
				LabelPaddingY          = 4;
				LabelOpacity           = 85;

				UseSegmentedBadges     = true;
				ShowTradeIcons         = true;
				UseEmojiIcons          = false;   // color emoji are unreliable in chart text; glyphs by default
				UseFallbackGlyphIcons  = true;
				SRankIcon              = "\U0001F451";  // 👑
				EliteIcon              = "\U0001F48E";  // 💎
				TickIcon               = "\U0001F3AF";  // 🎯
				StandardLongIcon       = "\u25B2";       // ▲
				StandardShortIcon      = "\u25BC";       // ▼
				EarlyIcon              = "\U0001F331";  // 🌱

				MaxLabelLanes                    = 10;
				ProtectCandles                   = true;
				UseCompactLabelsWhenCrowded      = true;
				HideLowPriorityLabelsWhenCrowded = true;
				ShowGlyphOnlyMarkers             = false;
				ShowLeaderLines                  = true;
				BadgeGapPx                       = 8;
				EntryArrowLong                   = "\u25B2";   // ▲
				EntryArrowShort                  = "\u25BC";   // ▼
				ShowContractTable                = false;
				LabelStyle                       = RhLabelStyle.Dark;
				ShowClickReadout                 = false;
				EntryMarkerStyle                 = RhEntryMarker.Crosshair;

				UseTrueDelta        = true;
				VolumetricInstrument = "";   // blank = chart instrument
			}
			else if (State == State.Configure)
			{
				if (ApplyPresetDefaults)
					ApplyPreset();

				// add secondary series defensively; a bad symbol must not block load
				TryAddSeries(TickSymbol, ref tickIdx);
				if (UseEsContext)  TryAddSeries(EsSymbol,  ref esIdx);
				if (UseVixContext) TryAddSeries(VixSymbol, ref vixIdx);

				// hidden 1-min Volumetric (BidAsk) series for TRUE BarDelta/CVD on a clean candle chart.
				// Period args hardcoded per NT guidance; instrument from input (blank = chart instrument).
				if (UseTrueDelta)
				{
					try
					{
						// null instrument = primary (chart) instrument, per NT guidance (avoids runtime-variable warning)
						string vi = string.IsNullOrEmpty(VolumetricInstrument) || VolumetricInstrument.Trim().Length == 0
							? null : VolumetricInstrument.Trim();
						AddVolumetric(vi, BarsPeriodType.Minute, 1, NinjaTrader.Data.VolumetricDeltaType.BidAsk, 1);
						volIdx = BarsArray.Length - 1;
						volInstrUsed = vi == null ? "chart instrument" : vi;
					}
					catch { volIdx = -1; }
				}

				tickBarsNeeded = TickMomentumBars + 1;
			}
			else if (State == State.DataLoaded)
			{
				atr = ATR(AtrPeriod);
				cvdSeries = new Series<double>(this);
				ResetSessionLevels();

				records.Clear();
				signalSeq = 0;
				selectedIndex = -1;
				lastBadgeRects = new List<BadgePlace>();

				// frozen brushes for the render-time badges (premium dark UI)
				badgeBaseBrush = new SolidColorBrush(Color.FromRgb(0x14, 0x18, 0x20)); badgeBaseBrush.Freeze();
				badgeTextBrush = new SolidColorBrush(Color.FromRgb(0xE8, 0xEC, 0xF2)); badgeTextBrush.Freeze();
				badgeTextDark  = new SolidColorBrush(Color.FromRgb(0x0E, 0x14, 0x1A)); badgeTextDark.Freeze();
				dividerBrush   = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF)); dividerBrush.Freeze();
				accGold        = new SolidColorBrush(Color.FromRgb(0xFF, 0xD7, 0x4A)); accGold.Freeze();   // S-Rank
				accCyan        = new SolidColorBrush(Color.FromRgb(0x5B, 0xE1, 0xFF)); accCyan.Freeze();   // Elite
				accAmber       = new SolidColorBrush(Color.FromRgb(0xFF, 0xC9, 0x4A)); accAmber.Freeze();  // TICK
				accBlue        = new SolidColorBrush(Color.FromRgb(0x4D, 0xA3, 0xFF)); accBlue.Freeze();   // long grade
				accPurple      = new SolidColorBrush(Color.FromRgb(0xB0, 0x7C, 0xF0)); accPurple.Freeze(); // short grade
				leaderBrush    = new SolidColorBrush(Color.FromRgb(0x0A, 0x0E, 0x14)); leaderBrush.Freeze();// connector OUTLINE (dark)
				rowLabelBrush  = new SolidColorBrush(Color.FromRgb(0x8A, 0x93, 0xA0)); rowLabelBrush.Freeze();// card row labels (dim)
				selGlowBrush   = new SolidColorBrush(Color.FromRgb(0xFF, 0xD7, 0x4A)); selGlowBrush.Freeze();

				// hook the price panel's MouseDown for Research-mode click selection (proven NT8 pattern)
				if (!mouseHooked && ChartControl != null && ChartControl.ChartPanels != null && ChartControl.ChartPanels.Count > 0)
				{
					try
					{
						mousePanel = ChartControl.ChartPanels[0];
						mousePanel.MouseDown += OnChartMouseDown;
						mousePanel.MouseMove += OnChartMouseMove;
						mousePanel.MouseUp += OnChartMouseUp;
						researchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(20) };
						researchTimer.Tick += OnResearchTimerTick;
						researchTimer.Start();
						mouseHooked = true;
					}
					catch { }
				}
			}
			else if (State == State.Terminated)
			{
				try
				{
					if (mousePanel != null)
					{
						mousePanel.MouseDown -= OnChartMouseDown;
						mousePanel.MouseMove -= OnChartMouseMove;
						mousePanel.MouseUp -= OnChartMouseUp;
					}
					if (researchTimer != null) { researchTimer.Stop(); researchTimer.Tick -= OnResearchTimerTick; researchTimer = null; }
					if (dwFactory != null) { dwFactory.Dispose(); dwFactory = null; }
				}
				catch { }
				mouseHooked = false;
			}
		}

		// cache the active scale each render; then draw the render-time premium badge layer (Phase 3)
		protected override void OnRender(ChartControl chartControl, ChartScale chartScale)
		{
			base.OnRender(chartControl, chartScale);
			cachedScale = chartScale;
			if (UseRenderTimeLabels) RenderSignalBadges(chartControl, chartScale);
			if (ShowDashboard) RenderDashboard(chartControl, chartScale);
		}

		private void TryAddSeries(string sym, ref int idx)
		{
			if (string.IsNullOrEmpty(sym)) { idx = -1; return; }
			try
			{
				AddDataSeries(sym, BarsPeriodType.Minute, 1);
				idx = BarsArray.Length - 1;  // index just added
			}
			catch { idx = -1; }
		}

		private void ApplyPreset()
		{
			switch (Preset)
			{
				case RhPreset.Conservative:
					UseCisdEarly = false;
					UseAbsorptionCoverage = false;
					ExitMode = RhExitMode.A_Conservative;
					TriggerWindowMin = 15;
					FvgDisplacementAtr = 0.75;
					break;
				case RhPreset.Default:
					UseCisdEarly = true;
					UseAbsorptionCoverage = false;
					ExitMode = RhExitMode.G_Default;
					TriggerWindowMin = 15;
					FvgDisplacementAtr = 0.75;
					break;
				case RhPreset.Aggressive:
					UseCisdEarly = true;
					UseAbsorptionCoverage = true;
					ExitMode = RhExitMode.G_Default;
					TriggerWindowMin = 20;
					FvgDisplacementAtr = 0.6;
					break;
			}
		}

		protected override void OnBarUpdate()
		{
			if (BarsInProgress != 0) return;
			if (CurrentBar < Math.Max(ExtremeLookback, AtrPeriod) + 2) return;

			UpdateCrossMarketState();
			UpdateCvd();
			UpdateOrbLevels();

			if (IsInRth(Time[0]))
			{
				UpdateRadar();          // Tier 1
				CheckReversalTriggers(); // Tier 2 + Tier 3 (elite)
				CheckOrbFailureLong();
				CheckResearchLanes();
				if (EnableShortPrototype) CheckShortPrototype();
			}

			if (ShowOrbModule && ShowOrbLines) DrawOrbLines();
			// dashboard now renders in the SharpDX layer (RenderDashboard, called from OnRender)
		}

		#region Cross-market + CVD
		private void UpdateCrossMarketState()
		{
			tickAvail = esAvail = vixAvail = false;
			tickMom = 0; esMom5 = 0; vixMom5 = 0; tickC0 = double.NaN; tickC5 = double.NaN;

			tickAvail = SeriesReady(tickIdx, tickBarsNeeded);
			if (tickAvail)
			{
				tickC0 = Closes[tickIdx][0];
				tickC5 = Closes[tickIdx][TickMomentumBars];
				tickMom = tickC0 - tickC5;
			}
			if (UseEsContext)
			{
				esAvail = SeriesReady(esIdx, 6);
				if (esAvail) esMom5 = Closes[esIdx][0] - Closes[esIdx][5];
			}
			if (UseVixContext)
			{
				vixAvail = SeriesReady(vixIdx, 6);
				if (vixAvail) vixMom5 = Closes[vixIdx][0] - Closes[vixIdx][5];
			}
		}

		private bool SeriesReady(int idx, int need)
		{
			if (idx < 0) return false;
			if (BarsArray.Length <= idx || BarsArray[idx] == null) return false;
			if (CurrentBars[idx] < need) return false;
			return true;
		}

		// cumulative BarDelta proxy, reset each session. Stands in for TR CVD.
		private void UpdateCvd()
		{
			if (Bars.IsFirstBarOfSession) cvdRun = 0;

			double bd;
			bool ok;
			double td = TrueBarDelta(out ok);
			if (UseTrueDelta && ok)
			{
				bd = td;
				trueDeltaActive = true;
			}
			else
			{
				// fallback: signed-volume-by-bar-direction proxy (no tick data needed)
				try { bd = Close[0] >= Open[0] ? Volume[0] : -Volume[0]; } catch { bd = 0; }
				trueDeltaActive = false;
			}
			cvdRun += bd;
			cvdSeries[0] = cvdRun;
		}

		// Real per-bar delta from the hidden volumetric series (BidAsk). ok=false if unavailable.
		private double TrueBarDelta(out bool ok)
		{
			ok = false;
			if (volIdx < 0) return 0;
			try
			{
				NinjaTrader.NinjaScript.BarsTypes.VolumetricBarsType vt =
					BarsArray[volIdx].BarsType as NinjaTrader.NinjaScript.BarsTypes.VolumetricBarsType;
				if (vt == null) return 0;
				int vb = CurrentBars[volIdx];
				if (vb < 0) return 0;
				double d = vt.Volumes[vb].BarDelta;
				ok = true;
				return d;
			}
			catch { ok = false; return 0; }
		}

		// climax flow proxy: net signed-volume delta over last N bars is strongly negative
		// (selling into a low for a long) / positive (buying into a high for a short).
		private double CvdMomentum()
		{
			if (CurrentBar < ClimaxCvdLookback) return 0;
			return cvdSeries[0] - cvdSeries[ClimaxCvdLookback];
		}
		#endregion

		#region TICK / ES confirmation
		private bool TickConfirmsLong()  { return UseTickConfirmation && tickAvail && tickMom > 0; }
		private bool TickConfirmsShort() { return UseTickConfirmation && tickAvail && tickMom < 0; }

		// ES "hard-against": for a long, ES dumping hard (mom very negative) is against;
		// for a short, ES ripping hard up is against. Returns true if ES is HARD AGAINST.
		private bool EsHardAgainst(bool isLong)
		{
			if (!UseEsContext || !esAvail) return false;     // auto-pass when absent (research rule)
			double thr = atr[0] * 0.5;                        // scale to instrument volatility
			if (isLong)  return esMom5 < -thr;
			else         return esMom5 >  thr;
		}
		#endregion

		#region ORB
		private void ResetSessionLevels()
		{
			or5High = or15High = ib60High = double.MinValue;
			or5Low  = or15Low  = ib60Low  = double.MaxValue;
			or5Done = or15Done = ib60Done = false;
			or15BrokeBelow = or15BrokeAbove = ib60BrokeAbove = ib60BrokeBelow = false;
		}

		private void UpdateOrbLevels()
		{
			DateTime t = Time[0];
			DateTime today = t.Date;
			DateTime startToday = SessionStart(today);

			if (today != sessionDate && t >= startToday)
			{
				sessionDate   = today;
				orWindowStart = startToday;
				ResetSessionLevels();
			}
			if (sessionDate == Core.Globals.MinDate || t < orWindowStart) return;

			double mins = (t - orWindowStart).TotalMinutes;

			if (mins <= OrbMinutesFast) { or5High = Math.Max(or5High, High[0]); or5Low = Math.Min(or5Low, Low[0]); }
			else if (!or5Done && or5High > double.MinValue) or5Done = true;

			if (mins <= OrbMinutesStandard) { or15High = Math.Max(or15High, High[0]); or15Low = Math.Min(or15Low, Low[0]); }
			else if (!or15Done && or15High > double.MinValue) or15Done = true;

			if (mins <= IbMinutes) { ib60High = Math.Max(ib60High, High[0]); ib60Low = Math.Min(ib60Low, Low[0]); }
			else if (!ib60Done && ib60High > double.MinValue) ib60Done = true;
		}

		private bool StrongCloseLong()
		{
			double rng = High[0] - Low[0];
			if (rng <= 0) return Close[0] > Open[0];
			return (Close[0] - Low[0]) / rng >= 0.60 || Close[0] > Open[0];
		}
		private bool StrongCloseShort()
		{
			double rng = High[0] - Low[0];
			if (rng <= 0) return Close[0] < Open[0];
			return (Close[0] - Low[0]) / rng <= 0.40 || Close[0] < Open[0];
		}
		#endregion

		#region Tier 1 RADAR
		// Rule-based watch zone. Arms a long-radar when we have a fresh N-bar LOW,
		// a faded leg >= MinLegAtr, momentum pushing INTO the low, and climax selling.
		private void UpdateRadar()
		{
			double a = atr[0];
			if (a <= 0) return;

			// fresh extreme test (the just-closed bar prints the lowest low / highest high of lookback)
			double lowN  = MIN(Low, ExtremeLookback)[0];
			double highN = MAX(High, ExtremeLookback)[0];
			bool freshLow  = Low[0]  <= lowN  + (TickSize * 0.5);
			bool freshHigh = High[0] >= highN - (TickSize * 0.5);

			// leg size: distance from a recent opposite swing into this extreme, in ATR
			double legDownAtr = (MAX(High, ExtremeLookback)[0] - Low[0]) / a;   // for long
			double legUpAtr   = (High[0] - MIN(Low, ExtremeLookback)[0]) / a;   // for short

			double cvdMom = CvdMomentum();

			// LONG radar arm: fresh low, big down leg, selling climax (cvdMom strongly negative)
			if (freshLow && legDownAtr >= MinLegAtr && cvdMom < 0 && MomentumInto(true))
			{
				if (CooldownOk(lastRadarLong, EpisodeCooldownMin))
				{
					radarArmedBarLong = CurrentBar;
					radarArmTimeLong  = Time[0];
					radarExtremeLong  = Low[0];
					lastRadarLong     = Time[0];
					if (ShowRadarZones) PaintRadar(true);
				}
			}

			// SHORT radar arm
			if (freshHigh && legUpAtr >= MinLegAtr && cvdMom > 0 && MomentumInto(false))
			{
				if (CooldownOk(lastRadarShort, EpisodeCooldownMin))
				{
					radarArmedBarShort = CurrentBar;
					radarArmTimeShort  = Time[0];
					radarExtremeShort  = High[0];
					lastRadarShort     = Time[0];
					if (ShowRadarZones) PaintRadar(false);
				}
			}
		}

		// momentum into the extreme over ~ClimaxCvdLookback bars (price falling for long / rising for short)
		private bool MomentumInto(bool isLong)
		{
			int lb = Math.Min(ClimaxCvdLookback, CurrentBar);
			double chg = Close[0] - Close[lb];
			if (isLong)  return chg < 0;   // price fell into the low
			else         return chg > 0;   // price rose into the high
		}

		private bool RadarActive(bool isLong)
		{
			if (isLong)
			{
				if (radarArmedBarLong < 0) return false;
				return (Time[0] - radarArmTimeLong).TotalMinutes <= TriggerWindowMin;
			}
			else
			{
				if (radarArmedBarShort < 0) return false;
				return (Time[0] - radarArmTimeShort).TotalMinutes <= TriggerWindowMin;
			}
		}
		#endregion

		#region Tier 2/3 reversal triggers
		// Displacement-FVG: 3-bar gap where bar[2].low > bar[0].high (bullish FVG, for long)
		// and the displacement bar (middle) body >= FvgDisplacementAtr * ATR.
		private bool DisplacementFvgLong()
		{
			if (CurrentBar < 3) return false;
			double body = Math.Abs(Close[1] - Open[1]);
			bool gap = Low[0] > High[2];
			return gap && body >= FvgDisplacementAtr * atr[0];
		}
		private bool DisplacementFvgShort()
		{
			if (CurrentBar < 3) return false;
			double body = Math.Abs(Close[1] - Open[1]);
			bool gap = High[0] < Low[2];
			return gap && body >= FvgDisplacementAtr * atr[0];
		}

		// CISD (Early): close beyond the open of the most recent opposite-color candle.
		private bool CisdLong()
		{
			if (!UseCisdEarly) return false;
			for (int k = 1; k <= 6 && k < CurrentBar; k++)
			{
				if (Close[k] < Open[k]) // most recent bearish candle
					return Close[0] > Open[k];
			}
			return false;
		}
		private bool CisdShort()
		{
			if (!UseCisdEarly) return false;
			for (int k = 1; k <= 6 && k < CurrentBar; k++)
			{
				if (Close[k] > Open[k]) // most recent bullish candle
					return Close[0] < Open[k];
			}
			return false;
		}

		// 1-min absorption proxy (coverage mode only; real footprint is live-only)
		private bool AbsorptionLong()
		{
			if (!UseAbsorptionCoverage) return false;
			double rng = High[0] - Low[0];
			if (rng <= 0) return false;
			double clv = (Close[0] - Low[0]) / rng;
			bool sellingButHeld = (Close[0] < Open[0] || Volume[0] > 0) && clv >= 0.55 && (Open[0] - Low[0]) <= 0.8 * atr[0];
			return sellingButHeld;
		}
		private bool AbsorptionShort()
		{
			if (!UseAbsorptionCoverage) return false;
			double rng = High[0] - Low[0];
			if (rng <= 0) return false;
			double clv = (Close[0] - Low[0]) / rng;
			bool buyingButHeld = clv <= 0.45 && (High[0] - Open[0]) <= 0.8 * atr[0];
			return buyingButHeld;
		}

		private void CheckReversalTriggers()
		{
			// ---- LONG side ----
			if (RadarActive(true) && CooldownOk(lastSigLong, SignalCooldownMin))
			{
				bool confirmed = DisplacementFvgLong() || AbsorptionLong();
				bool early     = CisdLong();
				if (confirmed || early)
				{
					bool dim   = EsHardAgainst(true);          // ES against -> dim, not hidden
					bool tick  = TickConfirmsLong();
					bool elite = IsElite(true, confirmed, tick);
					bool srank = elite && confirmed && IsAmWindow();
					string mode = confirmed ? "Confirmed" : "Early";
					string nm = srank ? "S-RANK Reversal Long" : (elite ? "ELITE Reversal Long" : ("Reversal Long " + mode));
					PaintSignal(nm, true, false, tick, dim, elite, Close[0], false, srank);
					lastSigLong = Time[0];
				}
			}

			// ---- SHORT side ----
			if (RadarActive(false) && CooldownOk(lastSigShort, SignalCooldownMin))
			{
				bool confirmed = DisplacementFvgShort() || AbsorptionShort();
				bool early     = CisdShort();
				if (confirmed || early)
				{
					bool dim   = EsHardAgainst(false);
					bool tick  = TickConfirmsShort();          // [PROBATION] short TICK gate as badge
					bool elite = IsElite(false, confirmed, tick);
					bool srank = elite && confirmed && IsAmWindow();
					string mode = confirmed ? "Confirmed" : "Early";
					string nm = srank ? "S-RANK Reversal Short" : (elite ? "ELITE Reversal Short" : ("Reversal Short " + mode));
					// TICK badge highlight on shorts per research
					if (tick && !elite && !srank) nm = "Reversal Short - TICK";
					PaintSignal(nm, false, false, tick, dim, elite, Close[0], false, srank);
					lastSigShort = Time[0];
				}
			}
		}

		// ELITE = confirmed trigger + cross-market agreement + TICK confirm (proxy for "score clears
		// prior-days floor"). Rules stand-in for the trained elite badge. [verify-live]
		private bool IsElite(bool isLong, bool confirmed, bool tick)
		{
			if (!confirmed) return false;
			bool esOk  = !EsHardAgainst(isLong);
			bool flowOk = isLong ? CvdMomentum() < 0 : CvdMomentum() > 0;
			return confirmed && tick && esOk && flowOk;
		}

		// S-RANK = elite that also lands in the morning high-edge window (edge is morning-loaded
		// per research). The supreme, take-it trades. [verify-live]
		private bool IsAmWindow()
		{
			int hms = Time[0].Hour * 10000 + Time[0].Minute * 100 + Time[0].Second;
			return hms <= SRankCutoffTime;
		}
		#endregion

		#region ORB signals
		private void CheckOrbFailureLong()
		{
			if (!or15Done || or15Low == double.MaxValue) return;
			if (Low[0] < or15Low) or15BrokeBelow = true;

			if (or15BrokeBelow && Close[0] > or15Low && StrongCloseLong() && CooldownOk(lastOrbFailLong, SignalCooldownMin))
			{
				bool tick = TickConfirmsLong();
				bool dim  = EsHardAgainst(true);
				string nm = tick ? "ORB Failure Long - TICK" : "ORB Failure Long";
				PaintSignal(nm, true, false, tick, dim, false, Close[0], true, false);
				lastOrbFailLong = Time[0];
				or15BrokeBelow = false;
			}
		}

		private void CheckResearchLanes()
		{
			if (!ShowResearchLabels) return;

			if (or15Done && or15High > double.MinValue)
			{
				if (High[0] > or15High) or15BrokeAbove = true;
				if (or15BrokeAbove && Close[0] < or15High && StrongCloseShort() && CooldownOk(lastOrbFailShort, SignalCooldownMin))
				{
					PaintSignal("ORB Failure Short - Research", false, true, false, false, false, Close[0], true, false);
					lastOrbFailShort = Time[0];
					or15BrokeAbove = false;
				}
			}

			if (ib60Done && ib60High > double.MinValue)
			{
				if (Close[0] > ib60High && !ib60BrokeAbove && CooldownOk(lastIb60Long, SignalCooldownMin))
				{
					PaintSignal("IB60 Breakout Long - Research", true, true, false, false, false, Close[0], true, false);
					lastIb60Long = Time[0]; ib60BrokeAbove = true;
				}
				if (Close[0] < ib60Low && !ib60BrokeBelow && CooldownOk(lastIb60Short, SignalCooldownMin))
				{
					PaintSignal("IB60 Breakout Short - Research", false, true, false, false, false, Close[0], true, false);
					lastIb60Short = Time[0]; ib60BrokeBelow = true;
				}
			}
		}

		// PROTOTYPE short - research only, gives TICK short gate something to fire on.
		private void CheckShortPrototype()
		{
			if (CurrentBar < 6) return;
			double recentHigh = MAX(High, 5)[1];
			bool lowerHigh = High[0] < recentHigh;
			bool rejection = StrongCloseShort();
			bool pushedUp  = High[0] > High[1];
			if (lowerHigh && rejection && pushedUp && CooldownOk(lastShortProto, SignalCooldownMin))
			{
				bool tick = TickConfirmsShort();
				string nm = tick ? "Short - TICK Confirmed" : "Reversal Short - Proto (Research)";
				PaintSignal(nm, false, !tick, tick, false, false, Close[0], false, false);
				lastShortProto = Time[0];
			}
		}

		private bool CooldownOk(DateTime last, int mins)
		{
			if (last == Core.Globals.MinDate) return true;
			return (Time[0] - last).TotalMinutes >= mins;
		}
		#endregion

		#region Drawing
		private void PaintRadar(bool isLong)
		{
			string tag = "radar_" + CurrentBar + (isLong ? "L" : "S");
			double y = isLong ? Low[0] - TickSize * 14 : High[0] + TickSize * 14;
			Brush c = isLong ? Brushes.MediumAquamarine : Brushes.LightCoral;
			Draw.Dot(this, tag, false, 0, isLong ? Low[0] - TickSize * 2 : High[0] + TickSize * 2, c);
		}

		// isLong, isResearch, tickConfirmed, dim (ES against), elite, entryPx, isOrb (ORB/IB family), srank (supreme)
		private void PaintSignal(string signalName, bool isLong, bool isResearch, bool tickConfirmed, bool dim, bool elite, double entryPx, bool isOrb, bool srank)
		{
			// CSV records every fire, independent of view filters (full shadow log)
			if (EnableCsvLogging)
				LogSignal(signalName, isLong ? "LONG" : "SHORT", isResearch, tickConfirmed, dim, elite, entryPx);

			// ---- visual gating only ----
			if (isOrb && !ShowOrbModule) return;
			bool isEarly = signalName.IndexOf("Early", StringComparison.OrdinalIgnoreCase) >= 0;
			if (!PassesFilter(isResearch, tickConfirmed, elite, srank, isEarly)) return;

			lastSignalText = string.Format("{0} @ {1:h:mm tt}", signalName, Time[0]);

			// ---- Phase 2: store the signal-visual record (drives the render-time badges) ----
			// Created here (not in the label drawer) so records exist regardless of label mode.
			string tier = srank ? "S-Rank" : elite ? "Elite" : tickConfirmed ? "Stars/TICK" : isEarly ? "Early" : isResearch ? "Research" : "Standard";
			SignalRecord rec = new SignalRecord();
			rec.SignalIndex   = signalSeq++;
			rec.BarIndex      = CurrentBar;
			rec.Time          = Time[0];
			rec.IsLong        = isLong;
			rec.TradeType     = tier;
			rec.EntryPrice    = entryPx;
			rec.LabelPrice    = entryPx;                 // refined by the legacy lollipop if it runs
			rec.LabelText     = signalName;
			rec.High          = High[0];
			rec.Low           = Low[0];
			rec.Grade         = GradeFromTier(tier);
			rec.TickConfirmed = tickConfirmed;
			rec.Priority      = PriorityFromTier(tier);
			rec.CompactText   = BuildCompactText(isLong, tier, rec.Grade);
			records.Add(rec);
			if (records.Count > MaxStoredSignals) records.RemoveAt(0);

			// legacy Draw.Text labels: only if explicitly enabled (off by default)
			if (ShowLabels && UseLegacyDrawTextLabels)
				PaintLollipop(signalName, isLong, entryPx, isResearch, tickConfirmed, elite, srank, dim, rec);

			if (ShowExitPlan && !isResearch)
				DrawExitPlan(isLong, entryPx, elite || srank);
		}

		// tier -> letter grade (starting mapping; configurable later)
		private string GradeFromTier(string tier)
		{
			switch (tier)
			{
				case "S-Rank":     return "A+";
				case "Elite":      return "A";
				case "Stars/TICK": return "A-";
				case "Early":      return "B";
				case "Research":   return "B-";
				default:           return "B+";
			}
		}

		// tier -> priority (higher wins when crowded; selection handled separately)
		private int PriorityFromTier(string tier)
		{
			switch (tier)
			{
				case "S-Rank":     return 100;
				case "Elite":      return 90;
				case "Stars/TICK": return 70;
				case "Standard":   return 50;
				case "Early":      return 30;
				default:           return 20;   // Research
			}
		}

		// compact one-line badge text for Phase 3 (full segmented badges arrive in Phase 4)
		private string BuildCompactText(bool isLong, string tier, string grade)
		{
			string dirGlyph = isLong ? "\u25B2" : "\u25BC";   // ▲ / ▼
			string core;
			switch (tier)
			{
				case "S-Rank":     core = "S-Rank"; break;
				case "Elite":      core = "Elite";  break;
				case "Stars/TICK": core = "TICK";   break;
				case "Early":      core = (isLong ? "Long" : "Short") + " Early"; break;
				case "Research":   core = "Rsch";   break;
				default:           core = isLong ? "Long" : "Short"; break;
			}
			return dirGlyph + " " + core + "  " + grade;
		}

		// Resolve the leading icon for a signal from the configurable mapping (emoji or fallback glyph).
		private string IconFor(SignalRecord r)
		{
			if (!ShowTradeIcons) return "";
			string tier = r.TradeType;
			if (UseEmojiIcons)
			{
				switch (tier)
				{
					case "S-Rank":     return SRankIcon;
					case "Elite":      return EliteIcon;
					case "Stars/TICK": return TickIcon;
					case "Early":      return EarlyIcon;
					default:           return r.IsLong ? StandardLongIcon : StandardShortIcon;
				}
			}
			if (UseFallbackGlyphIcons)
			{
				switch (tier)   // crisp monochrome glyphs that always render
				{
					case "S-Rank":     return "\u2605";                       // ★
					case "Elite":      return "\u25C6";                       // ◆
					case "Stars/TICK": return "\u2713";                       // ✓
					case "Early":      return "\u25CF";                       // ●
					default:           return r.IsLong ? "\u25B2" : "\u25BC"; // ▲ ▼
				}
			}
			return "";
		}

		// Build ordered badge segments: [icon] [identity] [mode] [grade]. Icon is its own accent-colored chip.
		private List<SegItem> BuildBadgeSegments(SignalRecord r)
		{
			List<SegItem> segs = new List<SegItem>(4);
			bool isRev = !string.IsNullOrEmpty(r.LabelText) && r.LabelText.IndexOf("Reversal", StringComparison.OrdinalIgnoreCase) >= 0;
			bool special = r.TradeType == "S-Rank" || r.TradeType == "Elite" || r.TradeType == "Stars/TICK" || r.TradeType == "Early";

			if (ShowTradeIcons) segs.Add(new SegItem("", special, 0));   // vector tier icon (rendered in DrawBadgeAt)

			string identity;
			switch (r.TradeType)
			{
				case "S-Rank": identity = "S-Rank"; break;
				case "Elite":  identity = "Elite";  break;
				default:       identity = (isRev ? "Rev " : "") + (r.IsLong ? "Long" : "Short"); break;
			}
			segs.Add(new SegItem(identity, false, 1));   // identity

			string mode = r.TickConfirmed ? "TICK \u2713"
						: r.TradeType == "Early" ? "Early"
						: r.TradeType == "Research" ? "Rsch" : "";
			if (mode.Length > 0) segs.Add(new SegItem(mode, false, 2));   // mode

			segs.Add(new SegItem(string.IsNullOrEmpty(r.Grade) ? "-" : r.Grade, false, 3));   // grade
			return segs;
		}

		// Compact chip content: icon only (or grade if icons are off).
		private List<SegItem> CompactSegments(SignalRecord r)
		{
			List<SegItem> segs = new List<SegItem>(1);
			bool special = r.TradeType == "S-Rank" || r.TradeType == "Elite" || r.TradeType == "Stars/TICK" || r.TradeType == "Early";
			if (ShowTradeIcons) segs.Add(new SegItem("", special, 0));   // vector tier icon
			else segs.Add(new SegItem(string.IsNullOrEmpty(r.Grade) ? "-" : r.Grade, false));
			return segs;
		}

		// Measure a segmented badge's pixel size for the given segments.
		private float MeasureBadge(SharpDX.DirectWrite.Factory f, SharpDX.DirectWrite.TextFormat tf, List<SegItem> segs, out float h)
		{
			float innerW = 0f, maxH = 0f;
			float iconPx = BadgeIconPx();
			for (int k = 0; k < segs.Count; k++)
			{
				if (segs[k].Role == 0)   // vector icon: fixed square, no text measure
				{
					innerW += iconPx;
					if (iconPx > maxH) maxH = iconPx;
					continue;
				}
				SharpDX.DirectWrite.TextLayout tl = null;
				try
				{
					tl = new SharpDX.DirectWrite.TextLayout(f, segs[k].Text, tf, 600f, 60f);
					innerW += tl.Metrics.Width;
					if (tl.Metrics.Height > maxH) maxH = tl.Metrics.Height;
				}
				finally { if (tl != null) tl.Dispose(); }
			}
			float segGap = LabelPaddingX + 4f;
			innerW += (segs.Count - 1) * segGap;
			h = maxH + 2f * LabelPaddingY;
			return innerW + 2f * LabelPaddingX;
		}

		// AABB overlap (with a small gap) against any already-placed rectangle.
		private bool OverlapsAny(SharpDX.RectangleF c, List<SharpDX.RectangleF> rects, float gap)
		{
			for (int i = 0; i < rects.Count; i++)
			{
				SharpDX.RectangleF b = rects[i];
				bool apart = (c.Right + gap <= b.Left) || (c.Left >= b.Right + gap)
						   || (c.Bottom + gap <= b.Top) || (c.Top >= b.Bottom + gap);
				if (!apart) return true;
			}
			return false;
		}

		// Pixel y of the price boundary a badge must clear within its x-span:
		// for longs = lowest low (largest y); for shorts = highest high (smallest y). Falls back to fallbackY.
		private float ProtectedBoundaryY(ChartControl cc, ChartScale cs, bool isLong, float left, float right, int fromIdx, int toIdx, float fallbackY)
		{
			float best = fallbackY;
			bool found = false;
			int lo = Math.Max(0, fromIdx - 1);
			int hi = Math.Min(Bars.Count - 1, toIdx + 1);
			for (int bi = lo; bi <= hi; bi++)
			{
				float bx;
				try { bx = cc.GetXByBarIndex(ChartBars, bi); }
				catch { continue; }
				if (bx < left - 2f || bx > right + 2f) continue;
				double price = isLong ? Bars.GetLow(bi) : Bars.GetHigh(bi);
				float y = cs.GetYByValue(price);
				if (!found) { best = y; found = true; }
				else if (isLong) { if (y > best) best = y; }   // lower low => larger y
				else             { if (y < best) best = y; }   // higher high => smaller y
			}
			return best;
		}

		// Mix-and-match category filter. Each category independent. ShowResearchLabels gates research.
		private bool PassesFilter(bool isResearch, bool tick, bool elite, bool srank, bool isEarly)
		{
			if (srank)      return ShowSRank;        // supreme tier first (it's also elite+confirmed)
			if (elite)      return ShowElite;
			if (isResearch) return ShowResearchLabels;
			if (tick)       return ShowStars;        // TICK-confirmed (not elite)
			if (isEarly)    return ShowEarly;
			return ShowStandard;                     // plain tradable confirmed
		}

		// v0.3 lollipop: offset label + connector stick + prominent glyph marker AT the exact entry.
		// Direction color (green long / red short); tier conveyed by glyph + connector style + opacity.
		private void PaintLollipop(string signalName, bool isLong, double entryPx, bool isResearch, bool tick, bool elite, bool srank, bool dim, SignalRecord rec)
		{
			string tag = "sig_" + CurrentBar + (isLong ? "L" : "S") + "_" + signalName.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
			Brush dir = isLong ? LongSignalBrush : ShortSignalBrush;
			bool isEarly = signalName.IndexOf("Early", StringComparison.OrdinalIgnoreCase) >= 0;

			// glyph + connector style + base opacity per tier
			string glyph;
			DashStyleHelper dash = DashStyleHelper.Solid;
			int op;
			if (srank)           { glyph = "♛"; op = 95; }
			else if (elite)      { glyph = "✧"; op = 95; }
			else if (tick)       { glyph = "✥"; op = 90; }
			else if (isEarly)    { glyph = "⬡"; op = EarlyOpacityPercent; dash = DashStyleHelper.Dash; }
			else                 { glyph = isLong ? "▲" : "▼"; op = StandardOpacityPercent; }
			if (isResearch) op = Math.Min(op, 60);
			if (dim)        op = Math.Min(op, 40);

			// label offset: larger of tick-based and ATR-based spacing
			double tickOff = LabelOffsetTicks * TickSize;
			double atrOff  = (UseAtrLabelOffset && atr != null) ? atr[0] * AtrOffsetMultiplier : 0;
			double offset  = Math.Max(tickOff, atrOff);

			// build the label text first so we can size its horizontal footprint for de-collision
			string dimMark = dim ? " (ES!)" : "";
			string txt = glyph + "  " + signalName + dimMark;
			// estimate footprint in bars (label width is ~text length; clamped, LabelMinBarGap is the floor)
			int fullWidthBars = (int)Math.Round(txt.Length * 0.62 * (LabelFontSize / 11.0));
			fullWidthBars = Math.Max(LabelMinBarGap, Math.Min(80, fullWidthBars));
			int halfWidthBars = Math.Max(2, fullWidthBars / 2);

			// anchor BEYOND the recent swing extreme (open space), then push into a free ROW so
			// labels whose footprints overlap never stack on the same row.
			int look = Math.Max(1, Math.Min(LabelSwingLookback, CurrentBar));
			double swing = isLong ? MIN(Low, look)[0] : MAX(High, look)[0];
			int row = PickLabelRow(CurrentBar, isLong, halfWidthBars);
			double rowOff = offset + row * (LabelRowGapTicks * TickSize);
			double ly = isLong ? swing - rowOff : swing + rowOff;

			// entry marker glyph AT entry (halo backdrop first so the glyph pops off candles)
			SimpleFont mFont = new SimpleFont("Segoe UI Symbol", EntryMarkerFontSize); mFont.Bold = true;
			if (EntryMarkerHalo)
			{
				SimpleFont hFont = new SimpleFont("Segoe UI Symbol", EntryMarkerFontSize + EntryMarkerHaloOffset); hFont.Bold = true;
				Draw.Text(this, tag + "_mh", false, glyph, 0, entryPx, 0, Brushes.White, hFont,
					System.Windows.TextAlignment.Center, Brushes.Transparent, Brushes.Transparent, 0);
			}
			Draw.Text(this, tag + "_m", false, glyph, 0, entryPx, 0, dir, mFont,
				System.Windows.TextAlignment.Center, Brushes.Transparent, Brushes.Transparent, 0);

			// connector stick from label to entry (vertical at this bar)
			Brush conn = WithOpacity(dir, ConnectorOpacity);
			Draw.Line(this, tag + "_c", false, 0, ly, 0, entryPx, conn, dash, ConnectorWidth);

			// offset label box (glyph + name only; price goes OUTSIDE the box)
			SimpleFont lf = new SimpleFont("Segoe UI Symbol", LabelFontSize); lf.Bold = !isResearch;
			Brush fgT = isLong ? Brushes.Black : Brushes.White;
			Draw.Text(this, tag, false, txt, 0, ly, 0, fgT, lf,
				System.Windows.TextAlignment.Center, dir, dir, op);

			// entry price OUTSIDE the box via a fixed PIXEL offset (below longs / above shorts) so the
			// box never covers it at any zoom.
			if (ShowEntryPriceInLabel)
			{
				int pxOff = LabelFontSize + 12;                 // clears half the box + margin
				int yPixOff = isLong ? pxOff : -pxOff;          // +down for longs, -up for shorts
				string ptxt = "(" + ((long)Math.Round(entryPx)).ToString("N0") + ")";
				Brush pcol = isLong ? Brushes.DarkGreen : Brushes.DarkRed;
				Draw.Text(this, tag + "_px", false, ptxt, 0, ly, yPixOff, pcol, new SimpleFont("Arial", EntryPriceFontSize),
					System.Windows.TextAlignment.Center, Brushes.Transparent, Brushes.Transparent, 0);
			}

			// refine the click hit-test anchor to the actual label box position
			rec.LabelPrice = ly;
		}

		// Assign a free stacking row so labels whose horizontal footprints overlap never sit on the same row.
		private int PickLabelRow(int bar, bool isLong, int halfWidthBars)
		{
			placedLabels.RemoveAll(p => bar - p.Bar > 600);
			HashSet<int> taken = new HashSet<int>();
			foreach (PlacedLabel p in placedLabels)
				if (p.IsLong == isLong && Math.Abs(p.Bar - bar) < (halfWidthBars + p.HalfWidthBars))
					taken.Add(p.Row);
			int row = 0;
			while (taken.Contains(row)) row++;
			placedLabels.Add(new PlacedLabel { Bar = bar, IsLong = isLong, Row = row, HalfWidthBars = halfWidthBars });
			return row;
		}

		// Return a frozen copy of a SolidColorBrush at the given opacity percent (for connectors).
		private Brush WithOpacity(Brush b, int pct)
		{
			SolidColorBrush s = b as SolidColorBrush;
			if (s == null) return b;
			byte a = (byte)(Math.Max(0, Math.Min(100, pct)) * 255 / 100);
			SolidColorBrush n = new SolidColorBrush(Color.FromArgb(a, s.Color.R, s.Color.G, s.Color.B));
			n.Freeze();
			return n;
		}

		// Visual-only exit-plan rays. Follows ExitMode. NO ORDERS.
		private void DrawExitPlan(bool isLong, double entry, bool elite)
		{
			int sign = isLong ? 1 : -1;
			double stop, be, partial, cap = 0;
			RhExitMode mode = elite ? RhExitMode.E_Elite : ExitMode;

			switch (mode)
			{
				case RhExitMode.E_Elite:
					stop = entry - sign * 80; be = entry + sign * 200; partial = double.NaN; break;
				case RhExitMode.A_Conservative:
					stop = entry - sign * 60; be = entry; partial = entry + sign * 100; cap = entry + sign * 600; break;
				default: // G
					stop = entry - sign * 60; be = entry + sign * 100; partial = entry + sign * 200; break;
			}

			string p = "exit_" + CurrentBar + (isLong ? "L" : "S");
			// Draw level lines anchored in the PAST (10 bars ago -> now) so they never
			// require future bars. Visual reference only; NO ORDERS.
			int back = Math.Min(10, CurrentBar);
			Draw.Line(this, p + "_stop", false, back, stop, 0, stop, Brushes.Crimson, DashStyleHelper.Solid, 2);
			Draw.Text(this, p + "_stopT", "stop", back, stop, Brushes.Crimson);

			if (!double.IsNaN(be))
			{
				Draw.Line(this, p + "_be", false, back, be, 0, be, Brushes.Goldenrod, DashStyleHelper.Dash, 1);
				Draw.Text(this, p + "_beT", elite ? "BE+200" : "BE+100", back, be, Brushes.Goldenrod);
			}
			if (!double.IsNaN(partial))
			{
				Draw.Line(this, p + "_p", false, back, partial, 0, partial, Brushes.LimeGreen, DashStyleHelper.Dash, 1);
				Draw.Text(this, p + "_pT", mode == RhExitMode.A_Conservative ? "half+100" : "half+200", back, partial, Brushes.LimeGreen);
			}
			if (cap > 0)
			{
				Draw.Line(this, p + "_cap", false, back, cap, 0, cap, Brushes.DeepSkyBlue, DashStyleHelper.Dot, 1);
				Draw.Text(this, p + "_capT", "cap600", back, cap, Brushes.DeepSkyBlue);
			}
		}

		private void DrawOrbLines()
		{
			if (or15Done && or15High > double.MinValue)
			{
				Draw.HorizontalLine(this, "or15H", or15High, Brushes.SteelBlue, DashStyleHelper.Solid, 1);
				Draw.HorizontalLine(this, "or15L", or15Low,  Brushes.SteelBlue, DashStyleHelper.Solid, 1);
			}
			if (or5Done && or5High > double.MinValue)
			{
				Draw.HorizontalLine(this, "or5H", or5High, Brushes.LightSteelBlue, DashStyleHelper.Dash, 1);
				Draw.HorizontalLine(this, "or5L", or5Low,  Brushes.LightSteelBlue, DashStyleHelper.Dash, 1);
			}
			if (ib60Done && ib60High > double.MinValue)
			{
				Draw.HorizontalLine(this, "ib60H", ib60High, Brushes.SlateGray, DashStyleHelper.Dot, 1);
				Draw.HorizontalLine(this, "ib60L", ib60Low,  Brushes.SlateGray, DashStyleHelper.Dot, 1);
			}
		}

		private void DrawDashboard()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Reversal Hunter v0.9  [" + Preset + "]  " + DisplayMode);
			sb.AppendLine("Exit plan: " + ExitMode);
			sb.AppendLine(or15Done ? string.Format("OR15  H {0:F2}  L {1:F2}", or15High, or15Low) : "OR15  forming...");
			sb.AppendLine(or5Done  ? string.Format("OR5   H {0:F2}  L {1:F2}", or5High, or5Low)   : "OR5   forming...");
			sb.AppendLine(ib60Done ? string.Format("IB60  H {0:F2}  L {1:F2}", ib60High, ib60Low) : "IB60  forming...");
			sb.AppendLine(string.Format("Radar L:{0}  S:{1}", RadarActive(true) ? "ARMED" : "-", RadarActive(false) ? "ARMED" : "-"));
			sb.AppendLine(tickAvail ? string.Format("TICK mom{0}: {1:F0}  L={2} S={3}", TickMomentumBars, tickMom, tickMom > 0 ? "Y" : "-", tickMom < 0 ? "Y" : "-") : "TICK: unavailable");
			sb.AppendLine(UseEsContext ? (esAvail ? string.Format("ES mom5: {0:F2}", esMom5) : "ES: unavailable") : "ES: off");
			if (UseVixContext) sb.AppendLine(vixAvail ? string.Format("VIX mom5: {0:F2}", vixMom5) : "VIX: unavailable");
			if (!UseTrueDelta)
				sb.AppendLine("DELTA: proxy (UseTrueDelta off)");
			else if (trueDeltaActive)
				sb.AppendLine("TRUE DELTA: ACTIVE - " + volInstrUsed);
			else
				sb.AppendLine("!! TRUE DELTA UNAVAILABLE - using proxy");
			sb.AppendLine("Last: " + lastSignalText);

			Draw.TextFixed(this, "rh_dash", sb.ToString(), TextPosition.TopRight,
				Brushes.Gainsboro, new SimpleFont("Consolas", 11), Brushes.Black, Brushes.DimGray, 60);
		}

		// Plain-English trading dashboard rendered in the SharpDX layer (dark panel, matches the label style).
		// Rows are chosen for trade decisions and use everyday words (no "ES mom"/"CVD"/"OR15" jargon).
		private void RenderDashboard(ChartControl cc, ChartScale cs)
		{
			SharpDX.Direct2D1.RenderTarget rt = RenderTarget;
			if (rt == null || dwFactory == null) return;

			try
			{
				float pRight = 100f, pTop = 0f;
				try
				{
					if (ChartPanel != null)
					{
						pRight = ChartPanel.X + ChartPanel.W;
						pTop   = ChartPanel.Y;
					}
				}
				catch { }

				// ---- derive plain-English reads from the sensors ----
				double cvdM = CvdMomentum();
				int upVotes = (tickMom > 0 ? 1 : 0) + (esMom5 > 0 ? 1 : 0) + (cvdM > 0 ? 1 : 0);
				int dnVotes = (tickMom < 0 ? 1 : 0) + (esMom5 < 0 ? 1 : 0) + (cvdM < 0 ? 1 : 0);
				int net = upVotes - dnVotes;

				string bias = net >= 2 ? "Bullish" : net <= -2 ? "Bearish" : "Neutral";
				int biasS = net >= 2 ? 1 : net <= -2 ? 2 : 0;

				bool armL = RadarActive(true), armS = RadarActive(false);
				string setup = armL ? "Long Forming" : armS ? "Short Forming" : "None Yet";
				int setupS = armL ? 1 : armS ? 2 : 0;

				int strength = Math.Max(upVotes, dnVotes);            // 0..3 sensors agreeing
				if (armL || armS) strength = Math.Min(4, strength + 1);
				double confidencePct = Math.Max(0, Math.Min(100, 100.0 * strength / 4.0));

				string last = lastSignalText;
				int lastS = last.IndexOf("Long", StringComparison.OrdinalIgnoreCase) >= 0 ? 1
						  : last.IndexOf("Short", StringComparison.OrdinalIgnoreCase) >= 0 ? 2 : 0;

				string mom = !tickAvail ? "No Data" : tickMom > 0 ? "Buyers" : tickMom < 0 ? "Sellers" : "Balanced";
				int momS = !tickAvail ? 0 : tickMom > 0 ? 1 : tickMom < 0 ? 2 : 0;

				string flow = cvdM > 0 ? "Buying" : cvdM < 0 ? "Selling" : "Balanced";
				int flowS = cvdM > 0 ? 1 : cvdM < 0 ? 2 : 0;

				string sp = !UseEsContext ? "Off" : !esAvail ? "No Data" : esMom5 > 0 ? "Up" : esMom5 < 0 ? "Down" : "Flat";
				int spS = (!UseEsContext || !esAvail) ? 0 : esMom5 > 0 ? 1 : esMom5 < 0 ? 2 : 0;

				string vol = !UseVixContext ? "Off" : !vixAvail ? "No Data" : vixMom5 > 0 ? "Rising" : vixMom5 < 0 ? "Falling" : "Steady";
				int volS = (!UseVixContext || !vixAvail) ? 0 : vixMom5 > 0 ? 3 : vixMom5 < 0 ? 1 : 0;   // rising = caution

				string location = "Range forming"; 
				int locS = 0;
				double hi = or15Done ? or15High : or5Done ? or5High : double.NaN;
				double lo = or15Done ? or15Low  : or5Done ? or5Low  : double.NaN;
				string rangeName = or15Done ? "OR15" : or5Done ? "OR5" : "Range";
				if (!double.IsNaN(hi))
				{
					try
					{
						double px = Close[0];
						if (px > hi)
						{
							location = string.Format("{0:0.#} above {1} High", px - hi, rangeName);
							locS = 1;
						}
						else if (px < lo)
						{
							location = string.Format("{0:0.#} below {1} Low", lo - px, rangeName);
							locS = 2;
						}
						else
						{
							double distHigh = hi - px;
							double distLow  = px - lo;
							if (distHigh <= distLow)
								location = string.Format("{0:0.#} below {1} High", distHigh, rangeName);
							else
								location = string.Format("{0:0.#} above {1} Low", distLow, rangeName);
							locS = 0;
						}
					}
					catch { location = "Range forming"; locS = 0; }
				}

				string confidenceWord = strength >= 4 ? "Strong" : strength == 3 ? "Good" : strength == 2 ? "Mixed" : "Weak";
				string reason1 = setupS == 1 ? string.Format("Long setup: {0}; {1} stack.", location, confidenceWord)
					: setupS == 2 ? string.Format("Short setup: {0}; {1} stack.", location, confidenceWord)
					: string.Format("{0} read; no active reversal trigger yet.", bias);
				string reason2 = string.Format("Flow: {0} momentum + {1} order flow; ES {2}.", mom, flow, sp);
				string reason3 = volS == 3 ? string.Format("Caution: volatility {0}; require clean confirmation.", vol)
					: string.Format("Confirm trigger quality; volatility {0}.", vol);

				bool healthy = tickAvail && (!UseEsContext || esAvail) && (!UseVixContext || vixAvail);

				float panelW = 360f;
				float panelH = 314f;
				SharpDX.RectangleF snappedPanel = GetDashboardPanelRect(panelW, panelH);
				float px0 = dashboardDragging ? dashboardDragX : snappedPanel.X;
				float py0 = dashboardDragging ? dashboardDragY : snappedPanel.Y;
				px0 = ClampDashboardX(px0, panelW);
				py0 = ClampDashboardY(py0, panelH);

				SharpDX.RectangleF panel = new SharpDX.RectangleF(px0, py0, panelW, panelH);
				dashboardRect = panel;
				dashboardDragRect = new SharpDX.RectangleF(px0, py0, panelW, 42f);
				SharpDX.RectangleF shadow = new SharpDX.RectangleF(px0, py0 + 4f, panelW, panelH);
				SharpDX.Direct2D1.RoundedRectangle rrPanel = new SharpDX.Direct2D1.RoundedRectangle
				{
					Rect = panel,
					RadiusX = 15f,
					RadiusY = 15f
				};
				SharpDX.Direct2D1.RoundedRectangle rrShadow = new SharpDX.Direct2D1.RoundedRectangle
				{
					Rect = shadow,
					RadiusX = 15f,
					RadiusY = 15f
				};

				SharpDX.Direct2D1.SolidColorBrush bg = null, bgTop = null, shadowBrush = null, border = null, glow = null;
				SharpDX.Direct2D1.SolidColorBrush txt = null, dim = null, muted = null, green = null, red = null, amber = null, cyan = null, gold = null, reasonText = null;
				SharpDX.Direct2D1.SolidColorBrush line = null, chipBg = null, chipStroke = null, starEmpty = null;
				SharpDX.DirectWrite.TextFormat tfTitle = null, tfSmall = null, tfValue = null, tfChip = null, tfStar = null, tfPct = null, tfReason = null;
				try
				{
					// "Navy glass + luxe gold" palette: premium, readable, less debug-like.
					bg          = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.055f, 0.105f, 0.155f, 0.94f));
					bgTop       = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.095f, 0.190f, 0.270f, 0.38f));
					shadowBrush = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.000f, 0.000f, 0.000f, 0.28f));
					border      = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.500f, 1.000f, 0.700f, 0.54f));
					glow        = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.460f, 1.000f, 0.720f, 0.14f));
					txt         = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.955f, 0.985f, 1.000f, 0.98f));
					dim         = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.675f, 0.730f, 0.800f, 0.92f));
					muted       = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.510f, 0.580f, 0.660f, 0.82f));
					gold        = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(1.000f, 0.780f, 0.360f, 0.96f));
					reasonText  = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.890f, 0.940f, 0.965f, 0.94f));
					green       = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.420f, 1.000f, 0.560f, 1.00f));
					red         = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(1.000f, 0.300f, 0.450f, 1.00f));
					amber       = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(1.000f, 0.780f, 0.340f, 1.00f));
					cyan        = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.390f, 1.000f, 0.890f, 1.00f));
					line        = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.750f, 0.900f, 1.000f, 0.18f));
					chipBg      = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.055f, 0.095f, 0.135f, 0.62f));
					chipStroke  = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.700f, 0.950f, 1.000f, 0.18f));
					starEmpty   = new SharpDX.Direct2D1.SolidColorBrush(rt, new SharpDX.Color4(0.760f, 0.840f, 0.900f, 0.24f));

					tfTitle = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.Bold,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 13.5f);
					tfSmall = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.SemiBold,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 10.5f);
					tfValue = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.SemiBold,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 11.5f);
					tfChip = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.SemiBold,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 10.5f);
					tfStar = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI Symbol", SharpDX.DirectWrite.FontWeight.Normal,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 13.5f);
					tfPct = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.Bold,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 11.0f);
					tfPct.TextAlignment = SharpDX.DirectWrite.TextAlignment.Trailing;
					tfReason = new SharpDX.DirectWrite.TextFormat(dwFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.Normal,
						SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 10.5f);

					// Panel: shadow, glow, navy glass, subtle top sheen.
					rt.FillRoundedRectangle(rrShadow, shadowBrush);
					rt.DrawRoundedRectangle(rrPanel, glow, 6.0f);
					rt.FillRoundedRectangle(rrPanel, bg);
					SharpDX.RectangleF sheenRect = new SharpDX.RectangleF(px0 + 1f, py0 + 1f, panelW - 2f, 44f);
					RhFillRounded(rt, sheenRect, 14f, bgTop);
					rt.DrawRoundedRectangle(rrPanel, border, 1.15f);

					float x = px0 + 14f;
					float y = py0 + 12f;
					float right = px0 + panelW - 14f;

					// Header: soft orb + title + state chip.
					SharpDX.Direct2D1.Brush stateBrush = setupS == 1 ? green : setupS == 2 ? red : biasS == 1 ? green : biasS == 2 ? red : dim;
					SharpDX.Direct2D1.Brush chipBrush = RhBrushForState(setupS != 0 ? setupS : biasS, green, red, amber, dim);

					rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(x + 7f, y + 7f), 7.0f, 7.0f), glow);
					rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(x + 7f, y + 7f), 4.3f, 4.3f), stateBrush);
					rt.DrawText("Reversal Hunter", tfTitle, new SharpDX.RectangleF(x + 19f, y - 3f, 160f, 20f), txt);

					string stateText = setupS == 1 ? "LONG FORMING" : setupS == 2 ? "SHORT FORMING" : bias.ToUpper();
					RhDrawChip(rt, tfChip, stateText, right - 126f, y - 2f, 126f, 18f, chipBg, chipStroke, chipBrush);

					// Prime section.
					float yy = y + 30f;
					rt.DrawText("Setup", tfSmall, new SharpDX.RectangleF(x, yy, 92f, 16f), gold);
					RhDrawChip(rt, tfChip, setup, right - 158f, yy - 3f, 158f, 19f, chipBg, chipStroke, chipBrush);

					yy += 25f;
					rt.DrawText("Confidence", tfSmall, new SharpDX.RectangleF(x, yy, 92f, 16f), gold);

					// Star confidence: filled stars plus percentage on the right.
					int filledStars = (int)Math.Round(Math.Max(0, Math.Min(5, confidencePct / 20.0)));
					float starX = right - 125f;
					for (int s = 0; s < 5; s++)
					{
						SharpDX.Direct2D1.Brush sb = s < filledStars ? (strength >= 3 ? green : strength == 2 ? amber : gold) : starEmpty;
						rt.DrawText(s < filledStars ? "★" : "☆", tfStar,
							new SharpDX.RectangleF(starX + s * 13.0f, yy - 3f, 15f, 18f), sb);
					}
					rt.DrawText(string.Format("{0:0}%", confidencePct), tfPct, new SharpDX.RectangleF(right - 40f, yy - 1f, 40f, 16f), txt);

					// Reason section: intentionally detailed enough to help validate the trade idea.
					yy += 26f;
					rt.DrawText("Reason", tfSmall, new SharpDX.RectangleF(x, yy, 66f, 16f), gold);
					float reasonX = x + 66f;
					float reasonW = right - reasonX;
					RhDrawLeftTextClipped(rt, tfReason, reason1, new SharpDX.RectangleF(reasonX, yy - 1f, reasonW, 15f), reasonText);
					yy += 15f;
					RhDrawLeftTextClipped(rt, tfReason, reason2, new SharpDX.RectangleF(reasonX, yy - 1f, reasonW, 15f), reasonText);
					yy += 15f;
					RhDrawLeftTextClipped(rt, tfReason, reason3, new SharpDX.RectangleF(reasonX, yy - 1f, reasonW, 15f), reasonText);

					yy += 24f;
					rt.DrawText("Last Signal", tfSmall, new SharpDX.RectangleF(x, yy, 92f, 16f), gold);
					SharpDX.Direct2D1.Brush lastBrush = RhBrushForState(lastS, green, red, amber, muted);
					RhDrawRightTextClipped(rt, tfValue, string.IsNullOrEmpty(last) ? "None" : last, new SharpDX.RectangleF(x + 98f, yy - 1f, right - (x + 98f), 17f), lastBrush);

					yy += 25f;
					rt.DrawLine(new SharpDX.Vector2(x, yy), new SharpDX.Vector2(right, yy), line, 1f);
					yy += 13f;

					// Detail drivers as chips. These are the confirmation stack, not just debug text.
					RhDrawDriverRow(rt, tfSmall, tfChip, "Momentum",   mom,      momS,  x, yy, right, gold, chipBg, chipStroke, green, red, amber, muted); yy += 24f;
					RhDrawDriverRow(rt, tfSmall, tfChip, "Order Flow", flow,     flowS, x, yy, right, gold, chipBg, chipStroke, green, red, amber, muted); yy += 24f;
					RhDrawDriverRow(rt, tfSmall, tfChip, "ES",         sp,       spS,   x, yy, right, gold, chipBg, chipStroke, green, red, amber, muted); yy += 24f;
					RhDrawDriverRow(rt, tfSmall, tfChip, "Volatility", vol,      volS,  x, yy, right, gold, chipBg, chipStroke, green, red, amber, muted); yy += 24f;
					RhDrawDriverRow(rt, tfSmall, tfChip, "Location",   location, locS,  x, yy, right, gold, chipBg, chipStroke, green, red, amber, muted);

					// Tiny health indicator in the lower-right: subtle, not loud.
					SharpDX.Direct2D1.Brush healthBrush = healthy ? green : amber;
					rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(right - 5f, py0 + panelH - 12f), 3.2f, 3.2f), healthBrush);
				}
				finally
				{
					if (bg != null) bg.Dispose();
					if (bgTop != null) bgTop.Dispose();
					if (shadowBrush != null) shadowBrush.Dispose();
					if (border != null) border.Dispose();
					if (glow != null) glow.Dispose();
					if (txt != null) txt.Dispose();
					if (dim != null) dim.Dispose();
					if (muted != null) muted.Dispose();
					if (green != null) green.Dispose();
					if (red != null) red.Dispose();
					if (amber != null) amber.Dispose();
					if (cyan != null) cyan.Dispose();
					if (gold != null) gold.Dispose();
					if (reasonText != null) reasonText.Dispose();
					if (line != null) line.Dispose();
					if (chipBg != null) chipBg.Dispose();
					if (chipStroke != null) chipStroke.Dispose();
					if (starEmpty != null) starEmpty.Dispose();
					if (tfTitle != null) tfTitle.Dispose();
					if (tfSmall != null) tfSmall.Dispose();
					if (tfValue != null) tfValue.Dispose();
					if (tfChip != null) tfChip.Dispose();
					if (tfStar != null) tfStar.Dispose();
					if (tfPct != null) tfPct.Dispose();
					if (tfReason != null) tfReason.Dispose();
				}
			}
			catch { /* never throw from OnRender */ }
		}

		private void RhFillRounded(SharpDX.Direct2D1.RenderTarget rt, SharpDX.RectangleF rect, float radius, SharpDX.Direct2D1.Brush brush)
		{
			if (rt == null || brush == null) return;
			SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
			{
				Rect = rect,
				RadiusX = radius,
				RadiusY = radius
			};
			rt.FillRoundedRectangle(rr, brush);
		}

		private void RhDrawChip(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf, string text,
			float x, float y, float w, float h,
			SharpDX.Direct2D1.Brush bg, SharpDX.Direct2D1.Brush stroke, SharpDX.Direct2D1.Brush textBrush)
		{
			if (rt == null || tf == null) return;
			SharpDX.RectangleF rect = new SharpDX.RectangleF(x, y, w, h);
			SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
			{
				Rect = rect,
				RadiusX = h / 2f,
				RadiusY = h / 2f
			};

			if (bg != null) rt.FillRoundedRectangle(rr, bg);
			if (stroke != null) rt.DrawRoundedRectangle(rr, stroke, 0.8f);

			SharpDX.RectangleF textRect = new SharpDX.RectangleF(x + 8f, y + 1f, w - 16f, h - 1f);
			rt.PushAxisAlignedClip(textRect, SharpDX.Direct2D1.AntialiasMode.PerPrimitive);
			try { rt.DrawText(string.IsNullOrEmpty(text) ? "" : text, tf, textRect, textBrush); }
			finally { rt.PopAxisAlignedClip(); }
		}

		private void RhDrawDriverRow(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat labelTf, SharpDX.DirectWrite.TextFormat chipTf,
			string label, string value, int state, float left, float y, float right,
			SharpDX.Direct2D1.Brush labelBrush, SharpDX.Direct2D1.Brush chipBg, SharpDX.Direct2D1.Brush chipStroke,
			SharpDX.Direct2D1.Brush green, SharpDX.Direct2D1.Brush red, SharpDX.Direct2D1.Brush amber, SharpDX.Direct2D1.Brush muted)
		{
			if (rt == null) return;
			rt.DrawText(label, labelTf, new SharpDX.RectangleF(left, y, 104f, 16f), labelBrush);
			SharpDX.Direct2D1.Brush valueBrush = RhBrushForState(state, green, red, amber, muted);
			RhDrawChip(rt, chipTf, value, right - 158f, y - 3f, 158f, 19f, chipBg, chipStroke, valueBrush);
		}

		private SharpDX.Direct2D1.Brush RhBrushForState(int state,
			SharpDX.Direct2D1.Brush green, SharpDX.Direct2D1.Brush red, SharpDX.Direct2D1.Brush amber, SharpDX.Direct2D1.Brush muted)
		{
			if (state == 1) return green;
			if (state == 2) return red;
			if (state == 3) return amber;
			return muted;
		}

		private void RhDrawLeftTextClipped(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf, string text,
			SharpDX.RectangleF rect, SharpDX.Direct2D1.Brush brush)
		{
			if (rt == null || tf == null || brush == null) return;
			SharpDX.DirectWrite.TextAlignment oldAlign = tf.TextAlignment;
			tf.TextAlignment = SharpDX.DirectWrite.TextAlignment.Leading;
			rt.PushAxisAlignedClip(rect, SharpDX.Direct2D1.AntialiasMode.PerPrimitive);
			try { rt.DrawText(string.IsNullOrEmpty(text) ? "" : text, tf, rect, brush); }
			finally
			{
				rt.PopAxisAlignedClip();
				tf.TextAlignment = oldAlign;
			}
		}

		private void RhDrawRightTextClipped(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf, string text,
			SharpDX.RectangleF rect, SharpDX.Direct2D1.Brush brush)
		{
			if (rt == null || tf == null || brush == null) return;
			SharpDX.DirectWrite.TextAlignment oldAlign = tf.TextAlignment;
			tf.TextAlignment = SharpDX.DirectWrite.TextAlignment.Trailing;
			rt.PushAxisAlignedClip(rect, SharpDX.Direct2D1.AntialiasMode.PerPrimitive);
			try { rt.DrawText(string.IsNullOrEmpty(text) ? "" : text, tf, rect, brush); }
			finally
			{
				rt.PopAxisAlignedClip();
				tf.TextAlignment = oldAlign;
			}
		}

		// ===== Phase 4: render-time premium SEGMENTED badge layer (SharpDX) =====
		// One rounded capsule per VISIBLE signal, divided into segments (icon+identity | mode | grade)
		// with divider lines. Still no lane/collision (Phase 5), so dense clusters can overlap for now.
		private void RenderSignalBadges(ChartControl cc, ChartScale cs)
		{
			if (cc == null || ChartBars == null || cs == null) return;
			SharpDX.Direct2D1.RenderTarget rt = RenderTarget;
			if (rt == null) return;
			if (records.Count == 0) return;
			if (badgeBaseBrush == null || badgeTextBrush == null) return;

			// snapshot so the live signal list can't mutate mid-render
			SignalRecord[] snap = records.ToArray();
			int fromIdx = ChartBars.FromIndex;
			int toIdx   = ChartBars.ToIndex;

			SignalRecord selRec = (selectedIndex >= 0 && selectedIndex < records.Count) ? records[selectedIndex] : null;

			// panel pixel bounds for vertical clamping
			float panelTop = 0f, panelBottom = float.MaxValue, panelLeft = 0f, panelRight = float.MaxValue;
			try { if (ChartPanel != null) { panelTop = ChartPanel.Y + 2f; panelBottom = ChartPanel.Y + ChartPanel.H - 2f; panelLeft = ChartPanel.X + 2f; panelRight = ChartPanel.X + ChartPanel.W - 2f; } }
			catch { }

			if (dwFactory == null)
			{
				try { dwFactory = new SharpDX.DirectWrite.Factory(); }
				catch { return; }
			}

			// dx resources reused across all badges this pass
			SharpDX.Direct2D1.Brush dxLongFill = null, dxShortFill = null, dxLong = null, dxShort = null;
			SharpDX.Direct2D1.Brush dxTextLight = null, dxTextDark = null, dxSel = null, dxDivider = null;
			SharpDX.Direct2D1.Brush dxGold = null, dxCyan = null, dxAmber = null, dxLeader = null, dxCardBg = null, dxDim = null, dxBlue = null, dxPurple = null;
			SharpDX.DirectWrite.TextFormat tf = null;
			try
			{
				float fillOp = Math.Max(0f, Math.Min(1f, LabelOpacity / 100f));
				dxLongFill  = (LongSignalBrush  ?? Brushes.MediumSpringGreen).ToDxBrush(rt); dxLongFill.Opacity = fillOp;
				dxShortFill = (ShortSignalBrush ?? Brushes.Tomato).ToDxBrush(rt);            dxShortFill.Opacity = fillOp;
				dxLong  = (LongSignalBrush  ?? Brushes.MediumSpringGreen).ToDxBrush(rt);   // full-opacity outline
				dxShort = (ShortSignalBrush ?? Brushes.Tomato).ToDxBrush(rt);
				dxTextLight = badgeTextBrush.ToDxBrush(rt);   // on red (short)
				dxTextDark  = badgeTextDark.ToDxBrush(rt);    // on green (long)
				dxSel   = selGlowBrush.ToDxBrush(rt);
				dxDivider = dividerBrush.ToDxBrush(rt); dxDivider.Opacity = 0.35f;
				dxGold  = accGold.ToDxBrush(rt);
				dxCyan  = accCyan.ToDxBrush(rt);
				dxAmber = accAmber.ToDxBrush(rt);
				dxBlue   = accBlue.ToDxBrush(rt);
				dxPurple = accPurple.ToDxBrush(rt);
				dxLeader = leaderBrush.ToDxBrush(rt); dxLeader.Opacity = 0.85f;   // dark outline for connectors/arrows
				dxCardBg = badgeBaseBrush.ToDxBrush(rt); dxCardBg.Opacity = 0.96f; // detail card panel
				dxDim    = rowLabelBrush.ToDxBrush(rt);   // dim card row labels
				tf = new SharpDX.DirectWrite.TextFormat(dwFactory, "Arial", Math.Max(8, LabelFontSize));

				// ===== Phase 5 pass 1: resolve non-overlapping pixel rectangles =====
				List<SignalRecord> vis = new List<SignalRecord>();
				for (int i = 0; i < snap.Length; i++)
				{
					SignalRecord rr0 = snap[i];
					if (rr0.BarIndex >= fromIdx - 2 && rr0.BarIndex <= toIdx + 2) vis.Add(rr0);
				}
				// priority order: selected first, then Priority desc, then most recent
				vis.Sort(delegate(SignalRecord a, SignalRecord b)
				{
					int sa = object.ReferenceEquals(a, selRec) ? 1 : 0;
					int sb = object.ReferenceEquals(b, selRec) ? 1 : 0;
					if (sa != sb) return sb - sa;
					if (a.Priority != b.Priority) return b.Priority - a.Priority;
					return b.BarIndex - a.BarIndex;
				});

				List<BadgePlace> places = new List<BadgePlace>();
				List<SharpDX.RectangleF> placedRects = new List<SharpDX.RectangleF>();

				for (int i = 0; i < vis.Count; i++)
				{
					SignalRecord r = vis[i];
					float x;
					try { x = cc.GetXByBarIndex(ChartBars, r.BarIndex); }
					catch { continue; }

					bool forceCompact = ShowGlyphOnlyMarkers;
					List<SegItem> segs = forceCompact ? CompactSegments(r)
						: UseSegmentedBadges ? BuildBadgeSegments(r)
						: new List<SegItem> { new SegItem(string.IsNullOrEmpty(r.CompactText) ? r.LabelText : r.CompactText, false) };
					float h;
					float w = MeasureBadge(dwFactory, tf, segs, out h);
					float anchorY = cs.GetYByValue(r.IsLong ? r.Low : r.High);
					float protY = ProtectCandles ? ProtectedBoundaryY(cc, cs, r.IsLong, x - w / 2f, x + w / 2f, fromIdx, toIdx, anchorY) : anchorY;

					BadgePlace bp = TryPlace(r, x, w, h, protY, segs, placedRects, panelTop, panelBottom);

					// crowded: shrink to a compact chip and retry
					if (bp == null && !forceCompact && UseCompactLabelsWhenCrowded)
					{
						segs = CompactSegments(r);
						w = MeasureBadge(dwFactory, tf, segs, out h);
						protY = ProtectCandles ? ProtectedBoundaryY(cc, cs, r.IsLong, x - w / 2f, x + w / 2f, fromIdx, toIdx, anchorY) : anchorY;
						bp = TryPlace(r, x, w, h, protY, segs, placedRects, panelTop, panelBottom);
						if (bp != null) bp.Compact = true;
					}

					// still no fit
					if (bp == null)
					{
						bool selHere = object.ReferenceEquals(r, selRec);
						if (HideLowPriorityLabelsWhenCrowded && !selHere && r.Priority < 70)
							continue;   // hide lowest-priority rather than overlap
						float baseY = r.IsLong ? (protY + LabelBaseGapPx) : (protY - LabelBaseGapPx - h);
						if (baseY < panelTop) baseY = panelTop;
						if (baseY + h > panelBottom) baseY = panelBottom - h;
						bp = new BadgePlace { Rec = r, X = x - w / 2f, Y = baseY, W = w, H = h, IsLong = r.IsLong, Segs = segs, Compact = forceCompact };
					}

					places.Add(bp);
					placedRects.Add(new SharpDX.RectangleF(bp.X, bp.Y, bp.W, bp.H));
					bp.EntryX = x;
					bp.EntryY = cs.GetYByValue(r.EntryPrice);
				}

				// publish the resolved badge rectangles so the mouse handler can hit-test against what's drawn
				lastBadgeRects = places;

				// ===== pass 2a: leader lines (BEHIND all badges) - dark outline then direction color =====
				if (ShowLeaderLines)
				{
					for (int i = 0; i < places.Count; i++)
					{
						BadgePlace bp = places[i];
						SharpDX.Direct2D1.Brush dirBr = bp.IsLong ? dxLong : dxShort;
						float cx = bp.X + bp.W / 2f;
						float edgeY = bp.IsLong ? bp.Y : (bp.Y + bp.H);
						SharpDX.Vector2 p0 = new SharpDX.Vector2(cx, edgeY);
						SharpDX.Vector2 p1 = new SharpDX.Vector2(bp.EntryX, bp.EntryY);
						if (dxLeader != null) rt.DrawLine(p0, p1, dxLeader, 3.4f);   // outline
						rt.DrawLine(p0, p1, dirBr, 1.6f);                            // colored core
					}
				}

				// ===== pass 2b: badges =====
				for (int i = 0; i < places.Count; i++)
				{
					BadgePlace bp = places[i];
					bool sel = object.ReferenceEquals(bp.Rec, selRec);
					DrawBadgeAt(rt, tf, bp, dxLongFill, dxShortFill, dxLong, dxShort, dxTextDark, dxTextLight,
						dxGold, dxCyan, dxAmber, dxBlue, dxPurple, dxCardBg, dxDivider, dxSel, sel);
				}

				// ===== pass 2c: entry markers (ON TOP) - vector shape at the exact entry, cyan + dark outline =====
				if (ShowLeaderLines)
				{
					float emS = Math.Max(12f, EntryMarkerFontSize * 1.15f);
					for (int i = 0; i < places.Count; i++)
					{
						BadgePlace bp = places[i];
						DrawEntryMarker(rt, EntryMarkerStyle, bp.IsLong, bp.EntryX, bp.EntryY, emS, dxCyan, dxLeader);
					}
				}

				// ===== Phase 8: selected-signal MFE/MAE zones + detail card (premium, on top) =====
				RenderSelectedOverlay(rt, cc, cs, tf, dxLongFill, dxShortFill, dxLong, dxShort,
					dxCardBg, dxTextLight, dxLeader, dxDim, panelTop, panelBottom, panelLeft, panelRight);
			}
			catch { /* never throw from OnRender */ }
			finally
			{
				if (tf != null) tf.Dispose();
				if (dxLongFill  != null) dxLongFill.Dispose();
				if (dxShortFill != null) dxShortFill.Dispose();
				if (dxLong  != null) dxLong.Dispose();
				if (dxShort != null) dxShort.Dispose();
				if (dxTextLight != null) dxTextLight.Dispose();
				if (dxTextDark  != null) dxTextDark.Dispose();
				if (dxSel   != null) dxSel.Dispose();
				if (dxDivider != null) dxDivider.Dispose();
				if (dxGold  != null) dxGold.Dispose();
				if (dxCyan  != null) dxCyan.Dispose();
				if (dxAmber != null) dxAmber.Dispose();
				if (dxBlue != null) dxBlue.Dispose();
				if (dxPurple != null) dxPurple.Dispose();
				if (dxLeader != null) dxLeader.Dispose();
				if (dxCardBg != null) dxCardBg.Dispose();
				if (dxDim != null) dxDim.Dispose();
			}
		}

		// Lane search: longs descend below price, shorts ascend above. Returns null if no free, in-panel lane.
		private BadgePlace TryPlace(SignalRecord r, float x, float w, float h, float protY, List<SegItem> segs,
			List<SharpDX.RectangleF> placed, float panelTop, float panelBottom)
		{
			float baseY = r.IsLong ? (protY + LabelBaseGapPx) : (protY - LabelBaseGapPx - h);
			for (int lane = 0; lane < MaxLabelLanes; lane++)
			{
				float y = r.IsLong ? baseY + lane * LabelLaneStepPx : baseY - lane * LabelLaneStepPx;
				if (y < panelTop || y + h > panelBottom) continue;
				SharpDX.RectangleF cand = new SharpDX.RectangleF(x - w / 2f, y, w, h);
				if (!OverlapsAny(cand, placed, BadgeGapPx))
					return new BadgePlace { Rec = r, X = cand.Left, Y = cand.Top, W = w, H = h, IsLong = r.IsLong, Segs = segs };
			}
			return null;
		}

		// ---- vector icon helpers (crisp SharpDX shapes; recolor live, scale clean) ----

		private float BadgeIconPx() { return Math.Max(9f, LabelFontSize * 1.18f); }

		// Fill a closed polygon from normalized points (range ~ -1..1) scaled by hs and centered at (cx,cy).
		private void FillPoly(SharpDX.Direct2D1.RenderTarget rt, SharpDX.Direct2D1.Brush b,
			float cx, float cy, float hs, float[] nx, float[] ny)
		{
			if (b == null || nx == null || nx.Length < 3) return;
			using (SharpDX.Direct2D1.PathGeometry geo = new SharpDX.Direct2D1.PathGeometry(rt.Factory))
			{
				using (SharpDX.Direct2D1.GeometrySink sink = geo.Open())
				{
					sink.BeginFigure(new SharpDX.Vector2(cx + nx[0] * hs, cy + ny[0] * hs), SharpDX.Direct2D1.FigureBegin.Filled);
					for (int i = 1; i < nx.Length; i++) sink.AddLine(new SharpDX.Vector2(cx + nx[i] * hs, cy + ny[i] * hs));
					sink.EndFigure(SharpDX.Direct2D1.FigureEnd.Closed);
					sink.Close();
				}
				rt.FillGeometry(geo, b);
			}
		}

		private void StrokeOutlined(SharpDX.Direct2D1.RenderTarget rt, SharpDX.Vector2 a, SharpDX.Vector2 b,
			SharpDX.Direct2D1.Brush outline, SharpDX.Direct2D1.Brush col, float wOut, float wCol)
		{
			if (outline != null) rt.DrawLine(a, b, outline, wOut);
			if (col != null) rt.DrawLine(a, b, col, wCol);
		}

		// Tier icon: Standard=direction triangle, TICK=star, Elite=blue diamond, S-Rank=crown+diamond.
		private void DrawTierIcon(SharpDX.Direct2D1.RenderTarget rt, string tier, bool isLong,
			float cx, float cy, float s, SharpDX.Direct2D1.Brush gold, SharpDX.Direct2D1.Brush blue,
			SharpDX.Direct2D1.Brush green, SharpDX.Direct2D1.Brush red)
		{
			float hs = s / 2f;
			switch (tier)
			{
				case "S-Rank":
				{
					float[] cxn = { -1.00f, -0.83f, -0.39f, 0.00f, 0.39f, 0.83f, 1.00f };
					float[] cyn = {  0.94f, -0.61f,  0.00f, -1.00f, 0.00f, -0.61f, 0.94f };
					FillPoly(rt, gold, cx, cy, hs, cxn, cyn);                                  // crown body
					float[] gx = { 0.00f, 0.85f, 0.00f, -0.85f };
					float[] gy = { -1.00f, 0.00f, 1.00f, 0.00f };
					FillPoly(rt, blue, cx, cy + 0.40f * hs, hs * 0.30f, gx, gy);               // blue gem on band
					break;
				}
				case "Elite":
				{
					float[] dx = { -0.50f, 0.50f, 0.92f, 0.00f, -0.92f };
					float[] dy = { -0.60f, -0.60f, -0.05f, 1.00f, -0.05f };
					FillPoly(rt, blue, cx, cy, hs, dx, dy);                                    // blue brilliant-cut
					break;
				}
				case "Stars/TICK":
				{
					float[] sx = { 0.00f, 0.247f, 0.951f, 0.40f, 0.588f, 0.00f, -0.588f, -0.40f, -0.951f, -0.247f };
					float[] sy = { -1.00f, -0.34f, -0.309f, 0.13f, 0.809f, 0.42f, 0.809f, 0.13f, -0.309f, -0.34f };
					FillPoly(rt, gold, cx, cy, hs, sx, sy);                                    // star
					break;
				}
				default:
				{
					SharpDX.Direct2D1.Brush b = isLong ? green : red;
					if (isLong) { float[] tx = { 0f, 0.82f, -0.82f }; float[] ty = { -0.82f, 0.7f, 0.7f }; FillPoly(rt, b, cx, cy, hs, tx, ty); }
					else        { float[] tx = { 0f, 0.82f, -0.82f }; float[] ty = { 0.82f, -0.7f, -0.7f }; FillPoly(rt, b, cx, cy, hs, tx, ty); }
					break;
				}
			}
		}

		// Entry marker at the exact entry price; color = cyan, dark outline for pop off candles.
		private void DrawEntryMarker(SharpDX.Direct2D1.RenderTarget rt, RhEntryMarker style, bool isLong,
			float cx, float cy, float s, SharpDX.Direct2D1.Brush col, SharpDX.Direct2D1.Brush outline)
		{
			if (col == null) return;
			float hs = s / 2f;
			switch (style)
			{
				case RhEntryMarker.Crosshair:
				{
					float r = hs * 0.55f;
					if (outline != null) rt.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r, r), outline, 3.6f);
					rt.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r, r), col, 2.0f);
					float t0 = hs * 0.92f, t1 = hs * 0.42f;
					StrokeOutlined(rt, new SharpDX.Vector2(cx, cy - t0), new SharpDX.Vector2(cx, cy - t1), outline, col, 3.6f, 2.0f);
					StrokeOutlined(rt, new SharpDX.Vector2(cx, cy + t1), new SharpDX.Vector2(cx, cy + t0), outline, col, 3.6f, 2.0f);
					StrokeOutlined(rt, new SharpDX.Vector2(cx - t0, cy), new SharpDX.Vector2(cx - t1, cy), outline, col, 3.6f, 2.0f);
					StrokeOutlined(rt, new SharpDX.Vector2(cx + t1, cy), new SharpDX.Vector2(cx + t0, cy), outline, col, 3.6f, 2.0f);
					rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), hs * 0.16f, hs * 0.16f), col);
					break;
				}
				case RhEntryMarker.Arrowhead:
				{
					float d = isLong ? -1f : 1f;                      // long points up, short points down
					SharpDX.Vector2 tip   = new SharpDX.Vector2(cx, cy + d * hs * 0.78f);
					SharpDX.Vector2 wingL = new SharpDX.Vector2(cx - hs * 0.58f, cy + d * hs * 0.02f);
					SharpDX.Vector2 wingR = new SharpDX.Vector2(cx + hs * 0.58f, cy + d * hs * 0.02f);
					SharpDX.Vector2 tail  = new SharpDX.Vector2(cx, cy - d * hs * 0.72f);
					StrokeOutlined(rt, tip, tail,  outline, col, 4.0f, 2.4f);
					StrokeOutlined(rt, wingL, tip, outline, col, 4.0f, 2.4f);
					StrokeOutlined(rt, wingR, tip, outline, col, 4.0f, 2.4f);
					break;
				}
				default:   // Dot
				{
					float r = hs * 0.52f;
					if (outline != null) rt.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r, r), outline, 3.2f);
					rt.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r, r), col, 2.0f);
					rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r * 0.46f, r * 0.46f), col);
					break;
				}
			}
		}

		// Draw a resolved badge as a single capsule. Style preset selects fills/accents/glow.
		// Shorts keep a red base, longs a green base; presets add a gold grade pill + accent colors / glow / dark base.
		private void DrawBadgeAt(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf, BadgePlace bp,
			SharpDX.Direct2D1.Brush longFill, SharpDX.Direct2D1.Brush shortFill, SharpDX.Direct2D1.Brush longSolid,
			SharpDX.Direct2D1.Brush shortSolid, SharpDX.Direct2D1.Brush textDark, SharpDX.Direct2D1.Brush textLight,
			SharpDX.Direct2D1.Brush gold, SharpDX.Direct2D1.Brush cyan, SharpDX.Direct2D1.Brush amber,
			SharpDX.Direct2D1.Brush blue, SharpDX.Direct2D1.Brush purple,
			SharpDX.Direct2D1.Brush cardBg, SharpDX.Direct2D1.Brush divider, SharpDX.Direct2D1.Brush selGlow, bool sel)
		{
			float bx = bp.X, by = bp.Y, w = bp.W, h = bp.H;
			SignalRecord r = bp.Rec;
			bool isLong = r.IsLong;
			SharpDX.Direct2D1.Brush dir     = isLong ? longSolid : shortSolid;
			SharpDX.Direct2D1.Brush dirFill = isLong ? longFill  : shortFill;
			SharpDX.Direct2D1.Brush accent  = isLong ? blue : purple;   // grade pill + TICK accent

			SharpDX.Direct2D1.Brush tierBr = isLong ? textDark : textLight;
			switch (r.TradeType)
			{
				case "S-Rank":     tierBr = gold;  break;
				case "Elite":      tierBr = cyan;  break;
				case "Stars/TICK": tierBr = amber; break;
				case "Early":      tierBr = textLight; break;
			}

			bool showDividers = false, gradePill = false, modeAccent = false, darkBase = false, glow = false, sheen = false, whiteText = false;
			float baseTint = 0.34f;
			switch (LabelStyle)
			{
				case RhLabelStyle.Classic:  showDividers = true; break;
				case RhLabelStyle.Accent:   gradePill = true; modeAccent = true; break;
				case RhLabelStyle.Glow:     gradePill = true; modeAccent = true; glow = true; sheen = true; break;
				case RhLabelStyle.Dark:     gradePill = true; modeAccent = true; darkBase = true; glow = true; sheen = true; whiteText = true; baseTint = 0.34f; break;
				case RhLabelStyle.Frost:    gradePill = true; modeAccent = true; darkBase = true; glow = true; sheen = true; whiteText = true; baseTint = 0.52f; break;
				case RhLabelStyle.Midnight: gradePill = true; modeAccent = true; darkBase = true; glow = true; sheen = true; whiteText = true; baseTint = 0.22f; break;
			}

			SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
			{ Rect = new SharpDX.RectangleF(bx, by, w, h), RadiusX = LabelCornerRadius, RadiusY = LabelCornerRadius };

			// outer glow halo (behind the capsule)
			if (glow)
			{
				float[] gw = { 8f, 5f, 2.5f };
				float[] go = { 0.08f, 0.16f, 0.26f };
				for (int g = 0; g < gw.Length; g++) { dir.Opacity = go[g]; rt.DrawRoundedRectangle(rr, dir, gw[g]); }
				dir.Opacity = 1f;
			}

			// capsule base
			float fillPrev = dirFill.Opacity;
			if (darkBase)
			{
				rt.FillRoundedRectangle(rr, cardBg);
				dirFill.Opacity = baseTint; rt.FillRoundedRectangle(rr, dirFill);   // direction tint over dark
			}
			else
			{
				if (glow) dirFill.Opacity = Math.Min(1f, fillPrev + 0.10f);
				rt.FillRoundedRectangle(rr, dirFill);
			}
			dirFill.Opacity = fillPrev;

			// segments
			List<SegItem> segs = bp.Segs;
			int n = segs.Count;
			SharpDX.DirectWrite.TextLayout[] tls = new SharpDX.DirectWrite.TextLayout[n];
			try
			{
				float segGap = LabelPaddingX + 4f;
				float cursor = bx + LabelPaddingX;
				float iconPx = BadgeIconPx();
				for (int k = 0; k < n; k++)
				{
					int role = segs[k].Role;

					if (role == 0)   // vector tier icon: crown / blue diamond / star / direction triangle
					{
						DrawTierIcon(rt, r.TradeType, isLong, cursor + iconPx / 2f, by + h / 2f, iconPx, gold, blue, longSolid, shortSolid);
						cursor += iconPx;
						if (k < n - 1) cursor += segGap;
						continue;
					}

					tls[k] = new SharpDX.DirectWrite.TextLayout(dwFactory, segs[k].Text, tf, 600f, 60f);
					float segW = tls[k].Metrics.Width;
					float segH = tls[k].Metrics.Height;
					float ty = by + (h - segH) / 2f;

					SharpDX.Direct2D1.Brush txt;
					if (gradePill && role == 3)
					{
						float px0 = cursor - 5f, px1 = cursor + segW + 5f;
						float pinY = by + 2.5f, pinH = h - 5f;
						SharpDX.Direct2D1.RoundedRectangle gp = new SharpDX.Direct2D1.RoundedRectangle
						{ Rect = new SharpDX.RectangleF(px0, pinY, px1 - px0, pinH), RadiusX = pinH / 2f, RadiusY = pinH / 2f };
						rt.FillRoundedRectangle(gp, accent);
						txt = textLight;                                  // white on blue/purple pill
					}
					else if (segs[k].Accent)
						txt = whiteText ? textLight : tierBr;
					else if (modeAccent && role == 2)
						txt = accent;                                     // TICK accent (blue/purple)
					else
						txt = whiteText ? textLight : (isLong ? textDark : textLight);   // identity

					rt.DrawTextLayout(new SharpDX.Vector2(cursor, ty), tls[k], txt);
					cursor += segW;
					if (k < n - 1)
					{
						if (showDividers && divider != null)
						{
							float dvx = cursor + segGap / 2f;
							rt.DrawLine(new SharpDX.Vector2(dvx, by + 3f), new SharpDX.Vector2(dvx, by + h - 3f), divider, 1.0f);
						}
						cursor += segGap;
					}
				}
			}
			finally { for (int k = 0; k < n; k++) if (tls[k] != null) tls[k].Dispose(); }

			// border (bright direction halo)
			float bw = sel ? 2.4f : (darkBase ? 2.0f : (glow ? 1.8f : 1.25f));
			rt.DrawRoundedRectangle(rr, dir, bw);

			// 3D sheen: a soft highlight near the top inside edge
			if (sheen)
			{
				float litPrev = textLight.Opacity; textLight.Opacity = 0.20f;
				rt.DrawLine(new SharpDX.Vector2(bx + LabelCornerRadius, by + 2.5f),
					new SharpDX.Vector2(bx + w - LabelCornerRadius, by + 2.5f), textLight, 1.4f);
				textLight.Opacity = litPrev;
			}

			// selection glow for non-glow styles
			if (sel && !glow)
			{
				SharpDX.Direct2D1.RoundedRectangle gr = new SharpDX.Direct2D1.RoundedRectangle
				{ Rect = new SharpDX.RectangleF(bx - 3f, by - 3f, w + 6f, h + 6f), RadiusX = LabelCornerRadius + 2f, RadiusY = LabelCornerRadius + 2f };
				float[] gw = { 6f, 3.5f };
				float[] go = { 0.10f, 0.20f };
				for (int g = 0; g < gw.Length; g++) { selGlow.Opacity = go[g]; rt.DrawRoundedRectangle(gr, selGlow, gw[g]); }
				selGlow.Opacity = 1f;
			}
		}
		// Phase 8: for the selected signal, draw translucent MFE/MAE bands (with value pills) + a premium detail card.
		private void RenderSelectedOverlay(SharpDX.Direct2D1.RenderTarget rt, ChartControl cc, ChartScale cs,
			SharpDX.DirectWrite.TextFormat tf, SharpDX.Direct2D1.Brush mfeFill, SharpDX.Direct2D1.Brush maeFill,
			SharpDX.Direct2D1.Brush mfeBorder, SharpDX.Direct2D1.Brush maeBorder, SharpDX.Direct2D1.Brush cardBg,
			SharpDX.Direct2D1.Brush cardText, SharpDX.Direct2D1.Brush leaderDark, SharpDX.Direct2D1.Brush dim,
			float panelTop, float panelBottom, float panelLeft, float panelRight)
		{
			if (selectedIndex < 0 || selectedIndex >= records.Count) return;
			SignalRecord r = records[selectedIndex];
			if (!r.MfeCalculated) ComputeMfeMae(r);
			double pv = PointValuePerContract();

			float exA, mfeX, maeX;
			try
			{
				exA  = cc.GetXByBarIndex(ChartBars, r.BarIndex);
				mfeX = cc.GetXByBarIndex(ChartBars, r.MfeBarIndex);
				maeX = cc.GetXByBarIndex(ChartBars, r.MaeBarIndex);
			}
			catch { return; }
			float eY   = cs.GetYByValue(r.EntryPrice);
			float mfeY = cs.GetYByValue(r.MfePrice);
			float maeY = cs.GetYByValue(r.MaePrice);
			SharpDX.Direct2D1.Brush dirAccent = r.IsLong ? mfeBorder : maeBorder;

			SharpDX.Direct2D1.StrokeStyle dash = null;
			try { dash = new SharpDX.Direct2D1.StrokeStyle(rt.Factory, new SharpDX.Direct2D1.StrokeStyleProperties { DashStyle = SharpDX.Direct2D1.DashStyle.Dash }); }
			catch { dash = null; }

			try
			{
				// MFE band (favorable, green) - pill straddles the extreme (top for a long)
				DrawZoneBand(rt, tf, exA, eY, mfeX, mfeY, mfeFill, mfeBorder, leaderDark,
					r.IsLong, string.Format("MFE +{0:0.00}", r.MfePoints));

				// MAE band (adverse, red)
				if (ShowMaeToo)
					DrawZoneBand(rt, tf, exA, eY, maeX, maeY, maeFill, maeBorder, leaderDark,
						!r.IsLong, string.Format("MAE -{0:0.00}", r.MaePoints));

				// entry node where the card connector attaches
				rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(exA, eY), 4.5f, 4.5f), dirAccent);
				rt.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(exA, eY), 4.5f, 4.5f), leaderDark, 1.2f);

				float zoneRight = Math.Max(exA, mfeX);
				if (ShowMaeToo) zoneRight = Math.Max(zoneRight, maeX);

				DrawDetailCard(rt, tf, r, pv, exA, eY, zoneRight, cardBg, cardText, dim, mfeBorder, maeBorder,
					dirAccent, leaderDark, dash, panelTop, panelBottom, panelLeft, panelRight);
			}
			finally { if (dash != null) dash.Dispose(); }
		}

		// translucent excursion band + a brighter edge line + a value pill straddling the extreme edge
		private void DrawZoneBand(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			float ax, float ay, float bx, float by, SharpDX.Direct2D1.Brush fill, SharpDX.Direct2D1.Brush edge,
			SharpDX.Direct2D1.Brush pillText, bool pillTop, string label)
		{
			float lx = Math.Min(ax, bx), rx = Math.Max(ax, bx);
			float ty = Math.Min(ay, by), byy = Math.Max(ay, by);
			float w = Math.Max(2f, rx - lx), h = Math.Max(2f, byy - ty);
			SharpDX.RectangleF rect = new SharpDX.RectangleF(lx, ty, w, h);
			fill.Opacity = 0.16f;
			rt.FillRectangle(rect, fill);
			fill.Opacity = 1f;
			rt.DrawRectangle(rect, edge, 1.0f);
			float ey = pillTop ? ty : byy;                       // price-extreme edge
			rt.DrawLine(new SharpDX.Vector2(lx, ey), new SharpDX.Vector2(rx, ey), edge, 1.6f);
			DrawMiniPill(rt, tf, (lx + rx) / 2f, ey, label, edge, pillText);
		}

		// small rounded pill (filled bg + centered text)
		private void DrawMiniPill(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			float cx, float cy, string text, SharpDX.Direct2D1.Brush bg, SharpDX.Direct2D1.Brush textBr)
		{
			SharpDX.DirectWrite.TextLayout tl = null;
			try
			{
				tl = new SharpDX.DirectWrite.TextLayout(dwFactory, text, tf, 400f, 60f);
				float w = tl.Metrics.Width + 12f, h = tl.Metrics.Height + 6f;
				float x = cx - w / 2f, y = cy - h / 2f;
				SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
				{ Rect = new SharpDX.RectangleF(x, y, w, h), RadiusX = 5f, RadiusY = 5f };
				rt.FillRoundedRectangle(rr, bg);
				rt.DrawTextLayout(new SharpDX.Vector2(x + 6f, y + 3f), tl, textBr);
			}
			finally { if (tl != null) tl.Dispose(); }
		}

		// rounded panel with a faux outer glow (multi-stroke), then fill, then crisp border
		private void DrawGlowRoundedRect(SharpDX.Direct2D1.RenderTarget rt, SharpDX.RectangleF rect, float radius,
			SharpDX.Direct2D1.Brush fill, SharpDX.Direct2D1.Brush glow)
		{
			SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
			{ Rect = rect, RadiusX = radius, RadiusY = radius };
			float[] gw = { 7f, 4.5f, 2.5f };
			float[] go = { 0.06f, 0.12f, 0.20f };
			for (int i = 0; i < gw.Length; i++)
			{
				glow.Opacity = go[i];
				rt.DrawRoundedRectangle(rr, glow, gw[i]);
			}
			glow.Opacity = 1f;
			rt.FillRoundedRectangle(rr, fill);
			rt.DrawRoundedRectangle(rr, glow, 1.6f);
		}

		// premium detail card: icon + title + grade pill header, divider, label/value rows, optional $ table
		private void DrawDetailCard(SharpDX.Direct2D1.RenderTarget rt, SharpDX.DirectWrite.TextFormat tf,
			SignalRecord r, double pv, float entryX, float entryY, float zoneRightX,
			SharpDX.Direct2D1.Brush cardBg, SharpDX.Direct2D1.Brush cardText, SharpDX.Direct2D1.Brush dim,
			SharpDX.Direct2D1.Brush mfeBr, SharpDX.Direct2D1.Brush maeBr, SharpDX.Direct2D1.Brush dirAccent,
			SharpDX.Direct2D1.Brush leaderDark, SharpDX.Direct2D1.StrokeStyle dash,
			float panelTop, float panelBottom, float panelLeft, float panelRight)
		{
			string title = string.IsNullOrEmpty(r.LabelText) ? (r.IsLong ? "Long" : "Short") : r.LabelText;
			string grade = string.IsNullOrEmpty(r.Grade) ? "-" : r.Grade;

			// rows: label, value, kind (0 normal, 2 mfe-green, 3 mae-red, 4 ok-check)
			List<string> rl = new List<string>();
			List<string> rv = new List<string>();
			List<int> rk = new List<int>();
			rl.Add("Entry"); rv.Add(r.EntryPrice.ToString("N2")); rk.Add(0);
			rl.Add("MFE");   rv.Add(string.Format("+{0:0.00}", r.MfePoints)); rk.Add(2);
			if (ShowMaeToo) { rl.Add("MAE"); rv.Add(string.Format("-{0:0.00}", r.MaePoints)); rk.Add(3); }
			rl.Add("TICK");  rv.Add(r.TickConfirmed ? "\u2713" : "\u2014"); rk.Add(r.TickConfirmed ? 4 : 0);
			rl.Add("\u0394 TRUE"); rv.Add(trueDeltaActive ? "\u2713" : "\u2014"); rk.Add(trueDeltaActive ? 4 : 0);

			// optional per-contract $ rows (full width)
			List<string> extra = new List<string>();
			List<int> extraKind = new List<int>();
			if (ShowContractTable)
			{
				extra.Add(string.Format("MFE $  1:+{0:N0}  2:+{1:N0}  3:+{2:N0}  5:+{3:N0}  10:+{4:N0}",
					r.MfePoints * pv, r.MfePoints * pv * 2, r.MfePoints * pv * 3, r.MfePoints * pv * 5, r.MfePoints * pv * 10)); extraKind.Add(2);
				if (ShowMaeToo)
				{
					extra.Add(string.Format("MAE $  1:-{0:N0}  2:-{1:N0}  3:-{2:N0}  5:-{3:N0}  10:-{4:N0}",
						r.MaePoints * pv, r.MaePoints * pv * 2, r.MaePoints * pv * 3, r.MaePoints * pv * 5, r.MaePoints * pv * 10)); extraKind.Add(3);
				}
			}

			float pad = 12f, rowGap = 7f, colGap = 28f;
			SharpDX.DirectWrite.TextLayout tTitle = null, tGrade = null;
			SharpDX.DirectWrite.TextLayout[] tlL = new SharpDX.DirectWrite.TextLayout[rl.Count];
			SharpDX.DirectWrite.TextLayout[] tlV = new SharpDX.DirectWrite.TextLayout[rv.Count];
			SharpDX.DirectWrite.TextLayout[] tlE = new SharpDX.DirectWrite.TextLayout[extra.Count];
			SharpDX.Direct2D1.Brush icoGold = null, icoBlue = null, icoGreen = null, icoRed = null;
			try
			{
				tTitle = new SharpDX.DirectWrite.TextLayout(dwFactory, title, tf, 600f, 60f);
				tGrade = new SharpDX.DirectWrite.TextLayout(dwFactory, grade, tf, 200f, 60f);
				float cardIconPx = Math.Max(12f, tTitle.Metrics.Height);
				float iconW = cardIconPx, titleW = tTitle.Metrics.Width, gradeW = tGrade.Metrics.Width;
				float hH = Math.Max(tTitle.Metrics.Height, cardIconPx);
				float gradePillW = gradeW + 12f;
				float headerW = iconW + 8f + titleW + 16f + gradePillW;
				icoGold  = accGold.ToDxBrush(rt);
				icoBlue  = accBlue.ToDxBrush(rt);
				icoGreen = (LongSignalBrush  ?? Brushes.MediumSpringGreen).ToDxBrush(rt);
				icoRed   = (ShortSignalBrush ?? Brushes.Tomato).ToDxBrush(rt);

				float maxLabel = 0f, maxVal = 0f, rowH = 0f;
				for (int i = 0; i < rl.Count; i++)
				{
					tlL[i] = new SharpDX.DirectWrite.TextLayout(dwFactory, rl[i], tf, 400f, 60f);
					tlV[i] = new SharpDX.DirectWrite.TextLayout(dwFactory, rv[i], tf, 400f, 60f);
					if (tlL[i].Metrics.Width > maxLabel) maxLabel = tlL[i].Metrics.Width;
					if (tlV[i].Metrics.Width > maxVal) maxVal = tlV[i].Metrics.Width;
					if (tlL[i].Metrics.Height > rowH) rowH = tlL[i].Metrics.Height;
				}
				float rowsW = maxLabel + colGap + maxVal;

				float extraW = 0f, extraH = 0f;
				for (int i = 0; i < extra.Count; i++)
				{
					tlE[i] = new SharpDX.DirectWrite.TextLayout(dwFactory, extra[i], tf, 1000f, 60f);
					if (tlE[i].Metrics.Width > extraW) extraW = tlE[i].Metrics.Width;
					extraH += tlE[i].Metrics.Height + rowGap;
				}

				float innerW = Math.Max(headerW, Math.Max(rowsW, extraW));
				float cardW = innerW + 2f * pad;
				float headerBlock = hH + 8f;
				float rowsBlock = rl.Count * (rowH + rowGap);
				float extraBlock = (extra.Count > 0) ? (extraH + 8f) : 0f;
				float cardH = pad + headerBlock + 6f + rowsBlock + extraBlock + pad;

				// placement: keep OFF the bands -> prefer LEFT of entry, else right of the bands; clamp to panel
				float gap = 22f;
				float cx = entryX - gap - cardW;
				if (cx < panelLeft) cx = zoneRightX + gap;
				if (cx + cardW > panelRight) cx = Math.Max(panelLeft, panelRight - cardW);
				float cy = entryY - cardH / 2f;
				if (cy < panelTop + 2f) cy = panelTop + 2f;
				if (cy + cardH > panelBottom - 2f) cy = panelBottom - 2f - cardH;

				// dashed connector: entry node -> card near edge + small node
				bool cardLeft = (cx + cardW) <= entryX + 1f;
				float attachX = cardLeft ? (cx + cardW) : cx;
				float attachY = entryY;
				if (attachY < cy + 10f) attachY = cy + 10f;
				if (attachY > cy + cardH - 10f) attachY = cy + cardH - 10f;
				if (dash != null) rt.DrawLine(new SharpDX.Vector2(entryX, entryY), new SharpDX.Vector2(attachX, attachY), dirAccent, 1.4f, dash);
				else rt.DrawLine(new SharpDX.Vector2(entryX, entryY), new SharpDX.Vector2(attachX, attachY), dirAccent, 1.4f);
				rt.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(attachX, attachY), 3f, 3f), dirAccent);

				// panel with glow
				SharpDX.RectangleF cardRect = new SharpDX.RectangleF(cx, cy, cardW, cardH);
				DrawGlowRoundedRect(rt, cardRect, 13f, cardBg, dirAccent);

				// header: icon + title + grade pill (right)
				float hx = cx + pad, hy = cy + pad;
				DrawTierIcon(rt, r.TradeType, r.IsLong, hx + iconW / 2f, hy + hH / 2f, iconW, icoGold, icoBlue, icoGreen, icoRed);
				rt.DrawTextLayout(new SharpDX.Vector2(hx + iconW + 8f, hy), tTitle, cardText);
				float gpW = gradeW + 12f, gpH = hH + 2f;
				float gpx = cx + cardW - pad - gpW, gpy = hy - 1f;
				SharpDX.Direct2D1.RoundedRectangle gp = new SharpDX.Direct2D1.RoundedRectangle
				{ Rect = new SharpDX.RectangleF(gpx, gpy, gpW, gpH), RadiusX = 5f, RadiusY = 5f };
				rt.FillRoundedRectangle(gp, dirAccent);
				rt.DrawTextLayout(new SharpDX.Vector2(gpx + 6f, hy), tGrade, leaderDark);

				// divider
				float dy = cy + pad + headerBlock;
				rt.DrawLine(new SharpDX.Vector2(cx + pad, dy), new SharpDX.Vector2(cx + cardW - pad, dy), dim, 1.0f);

				// rows (label dim-left, value colored-right)
				float yc = dy + 6f, valRight = cx + cardW - pad;
				for (int i = 0; i < rl.Count; i++)
				{
					rt.DrawTextLayout(new SharpDX.Vector2(cx + pad, yc), tlL[i], dim);
					SharpDX.Direct2D1.Brush vb = cardText;
					if (rk[i] == 2 || rk[i] == 4) vb = mfeBr; else if (rk[i] == 3) vb = maeBr;
					rt.DrawTextLayout(new SharpDX.Vector2(valRight - tlV[i].Metrics.Width, yc), tlV[i], vb);
					yc += rowH + rowGap;
				}

				// optional $ table
				if (extra.Count > 0)
				{
					yc += 2f;
					rt.DrawLine(new SharpDX.Vector2(cx + pad, yc), new SharpDX.Vector2(cx + cardW - pad, yc), dim, 1.0f);
					yc += 6f;
					for (int i = 0; i < extra.Count; i++)
					{
						rt.DrawTextLayout(new SharpDX.Vector2(cx + pad, yc), tlE[i], extraKind[i] == 2 ? mfeBr : maeBr);
						yc += tlE[i].Metrics.Height + rowGap;
					}
				}
			}
			finally
			{
				if (icoGold != null) icoGold.Dispose();
				if (icoBlue != null) icoBlue.Dispose();
				if (icoGreen != null) icoGreen.Dispose();
				if (icoRed != null) icoRed.Dispose();
				if (tTitle != null) tTitle.Dispose();
				if (tGrade != null) tGrade.Dispose();
				for (int i = 0; i < tlL.Length; i++) if (tlL[i] != null) tlL[i].Dispose();
				for (int i = 0; i < tlV.Length; i++) if (tlV[i] != null) tlV[i].Dispose();
				for (int i = 0; i < tlE.Length; i++) if (tlE[i] != null) tlE[i].Dispose();
			}
		}
		#endregion

		#region Dashboard Drag + Snap
		private SharpDX.RectangleF GetDashboardPanelRect(float panelW, float panelH)
		{
			float left = 4f, top = 14f, right = left + panelW, bottom = top + panelH;

			try
			{
				if (ChartPanel != null)
				{
					float margin = 14f;
					float pLeft = ChartPanel.X;
					float pTop = ChartPanel.Y;
					float pRight = ChartPanel.X + ChartPanel.W;
					float pBottom = ChartPanel.Y + ChartPanel.H;

					switch (DashboardAnchor)
					{
						case RhDashboardAnchor.TopLeft:
							left = pLeft + margin;
							top = pTop + margin;
							break;
						case RhDashboardAnchor.BottomLeft:
							left = pLeft + margin;
							top = pBottom - panelH - margin;
							break;
						case RhDashboardAnchor.BottomRight:
							left = pRight - panelW - margin;
							top = pBottom - panelH - margin;
							break;
						case RhDashboardAnchor.TopRight:
						default:
							left = pRight - panelW - margin;
							top = pTop + margin;
							break;
					}
				}
			}
			catch { }

			left = ClampDashboardX(left, panelW);
			top = ClampDashboardY(top, panelH);
			right = left + panelW;
			bottom = top + panelH;
			return new SharpDX.RectangleF(left, top, panelW, panelH);
		}

		private float ClampDashboardX(float x, float w)
		{
			try
			{
				if (ChartPanel != null)
				{
					float min = ChartPanel.X + 4f;
					float max = ChartPanel.X + ChartPanel.W - w - 4f;
					if (max < min) max = min;
					if (x < min) return min;
					if (x > max) return max;
				}
			}
			catch { }
			return x < 4f ? 4f : x;
		}

		private float ClampDashboardY(float y, float h)
		{
			try
			{
				if (ChartPanel != null)
				{
					float min = ChartPanel.Y + 4f;
					float max = ChartPanel.Y + ChartPanel.H - h - 4f;
					if (max < min) max = min;
					if (y < min) return min;
					if (y > max) return max;
				}
			}
			catch { }
			return y < 4f ? 4f : y;
		}

		private bool TryGetMousePixels(MouseEventArgs e, out double px, out double py)
		{
			px = py = 0;
			try
			{
				if (e == null || ChartControl == null || mousePanel == null)
					return false;

				System.Windows.Point raw = e.GetPosition(mousePanel as System.Windows.IInputElement);
				px = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToHorizontalPixels(raw.X, ChartControl.PresentationSource);
				py = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToVerticalPixels(raw.Y, ChartControl.PresentationSource);
				return true;
			}
			catch { return false; }
		}

		private bool PointInRect(double x, double y, SharpDX.RectangleF r)
		{
			return x >= r.X && x <= r.X + r.Width && y >= r.Y && y <= r.Y + r.Height;
		}

		private bool TryStartDashboardDrag(MouseButtonEventArgs e)
		{
			try
			{
				if (!EnableShiftDragDashboard || !ShowDashboard || e == null)
					return false;
				if (e.ChangedButton != MouseButton.Left)
					return false;
				if ((Keyboard.Modifiers & ModifierKeys.Shift) != ModifierKeys.Shift)
					return false;

				double mx, my;
				if (!TryGetMousePixels(e, out mx, out my))
					return false;

				// Header-only hit zone keeps regular chart clicking/selection intact.
				if (!PointInRect(mx, my, dashboardDragRect))
					return false;

				dashboardDragging = true;
				dashboardDragX = dashboardRect.X;
				dashboardDragY = dashboardRect.Y;
				dashboardDragOffsetX = mx - dashboardDragX;
				dashboardDragOffsetY = my - dashboardDragY;
				e.Handled = true;
				try { ForceRefresh(); } catch { }
				return true;
			}
			catch { return false; }
		}

		private void OnChartMouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (!dashboardDragging)
					return;

				double mx, my;
				if (!TryGetMousePixels(e, out mx, out my))
					return;

				dashboardDragX = ClampDashboardX((float)(mx - dashboardDragOffsetX), dashboardRect.Width);
				dashboardDragY = ClampDashboardY((float)(my - dashboardDragOffsetY), dashboardRect.Height);
				e.Handled = true;
				try { ForceRefresh(); } catch { }
			}
			catch { }
		}

		private void OnChartMouseUp(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (!dashboardDragging)
					return;

				double mx, my;
				TryGetMousePixels(e, out mx, out my);

				float centerX = dashboardDragX + dashboardRect.Width / 2f;
				float centerY = dashboardDragY + dashboardRect.Height / 2f;

				try
				{
					if (ChartPanel != null)
					{
						float midX = ChartPanel.X + ChartPanel.W / 2f;
						float midY = ChartPanel.Y + ChartPanel.H / 2f;
						bool left = centerX < midX;
						bool top = centerY < midY;

						if (top && left) DashboardAnchor = RhDashboardAnchor.TopLeft;
						else if (top && !left) DashboardAnchor = RhDashboardAnchor.TopRight;
						else if (!top && left) DashboardAnchor = RhDashboardAnchor.BottomLeft;
						else DashboardAnchor = RhDashboardAnchor.BottomRight;
					}
				}
				catch { }

				dashboardDragging = false;
				if (e != null) e.Handled = true;
				try { ForceRefresh(); } catch { }
			}
			catch
			{
				dashboardDragging = false;
			}
		}
		#endregion

		#region Research Mode (click to inspect MFE/MAE) - VISUAL ONLY, never affects signal logic
		// Left-click in Research mode: select nearest signal (toggle off if same, switch if different,
		// clear if empty space). All drawing here is managed Draw.* (persistent) - no SharpDX, no per-tick redraw.
		private void OnChartMouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (TryStartDashboardDrag(e)) return;
				if (DisplayMode != RhDisplayMode.Research) { return; }
				if (e.ChangedButton != MouseButton.Left) return;
				if (ChartControl == null || cachedScale == null || mousePanel == null || ChartBars == null)
				{
					ShowClickDebug("Click: not ready (null ref)");
					return;
				}

				// raw WPF DIPs -> device pixels (matches GetXByBarIndex / GetYByValue space)
				System.Windows.Point raw = e.GetPosition(mousePanel as System.Windows.IInputElement);
				double px = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToHorizontalPixels(raw.X, ChartControl.PresentationSource);
				double py = NinjaTrader.Gui.Chart.ChartingExtensions.ConvertToVerticalPixels(raw.Y, ChartControl.PresentationSource);

				int hit = HitTest(px, py);
				clickDebug = string.Format("Click {0},{1} hit={2} recs={3} | near#{4} dx={5} dy={6} d={7}",
					(int)px, (int)py, hit, records.Count, lastNearIdx, (int)lastNearDx, (int)lastNearDy, (int)lastNearD);
				lastInteraction = DateTime.Now;

				if (hit < 0)                       { ClearResearchOverlay(); selectedIndex = -1; }
				else if (hit == selectedIndex)     { ClearResearchOverlay(); selectedIndex = -1; }
				else                               { ClearResearchOverlay(); selectedIndex = hit; if (!records[hit].MfeCalculated) ComputeMfeMae(records[hit]); }

				ShowClickDebug(clickDebug);
			}
			catch (Exception ex) { ShowClickDebug("Click ERR: " + ex.Message); }
			try { ForceRefresh(); } catch { }
		}

		// Draw the diagnostic immediately (independent of OnBarUpdate, which won't run on a quiet chart).
		private void ShowClickDebug(string msg)
		{
			clickDebug = msg;
			if (!ShowClickReadout) { try { RemoveDrawObject("rh_clickdbg"); } catch { } return; }
			try
			{
				Draw.TextFixed(this, "rh_clickdbg", msg, TextPosition.BottomRight,
					Brushes.Yellow, new SimpleFont("Consolas", 12), Brushes.Black, Brushes.DimGray, 70);
			}
			catch { }
		}

		private void OnResearchTimerTick(object sender, EventArgs e)
		{
			try
			{
				if (DisplayMode != RhDisplayMode.Research || selectedIndex < 0) return;
				if (ResearchAutoOffMinutes <= 0) return;
				if ((DateTime.Now - lastInteraction).TotalMinutes >= ResearchAutoOffMinutes)
				{
					ClearResearchOverlay();
					selectedIndex = -1;
					ForceRefresh();
				}
			}
			catch { }
		}

		// Box hit-test: generous in X (labels are wide), tight in Y. Picks nearest qualifying signal.
		// Also tracks the global-nearest record for diagnostics. Args = device pixels.
		private int lastNearIdx = -1;
		private double lastNearDx, lastNearDy, lastNearD;
		private int HitTest(double px, double py)
		{
			// prefer the actual rendered badge rectangles (most intuitive click target)
			List<BadgePlace> bl = lastBadgeRects;
			if (bl != null)
				for (int bi = 0; bi < bl.Count; bi++)
				{
					BadgePlace bp = bl[bi];
					if (px >= bp.X && px <= bp.X + bp.W && py >= bp.Y && py <= bp.Y + bp.H)
					{
						int idx = records.IndexOf(bp.Rec);
						if (idx >= 0) { lastNearIdx = idx; lastNearD = 0; lastNearDx = 0; lastNearDy = 0; return idx; }
					}
				}

			int best = -1;
			double bestD = double.MaxValue;
			double vTol = ClickHitboxPixels;
			double hTol = LabelHitHalfWidthPixels;
			int nearI = -1; double nearD = double.MaxValue, nearDx = 0, nearDy = 0;
			for (int i = 0; i < records.Count; i++)
			{
				SignalRecord r = records[i];
				float x = ChartControl.GetXByBarIndex(ChartBars, r.BarIndex);
				float yE = cachedScale.GetYByValue(r.EntryPrice);
				float yL = cachedScale.GetYByValue(r.LabelPrice);
				double dx = px - x;
				double dyE = py - yE, dyL = py - yL;
				double dY = Math.Abs(dyE) <= Math.Abs(dyL) ? dyE : dyL;   // nearer of marker / label height
				double d = Math.Sqrt(dx * dx + dY * dY);

				if (d < nearD) { nearD = d; nearI = i; nearDx = dx; nearDy = dY; }

				if (Math.Abs(dx) <= hTol && Math.Abs(dY) <= vTol && d < bestD) { bestD = d; best = i; }
			}
			lastNearIdx = nearI; lastNearD = nearD; lastNearDx = nearDx; lastNearDy = nearDy;
			return best;
		}

		// scan up to MaxMfeLookaheadBars bars after entry for favorable/adverse excursion
		private void ComputeMfeMae(SignalRecord r)
		{
			int end = Math.Min(r.BarIndex + MaxMfeLookaheadBars, CurrentBar);
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
			try
			{
				r.MfeTime = Bars.GetTime(Math.Min(Math.Max(r.MfeBarIndex, 0), Bars.Count - 1));
				r.MaeTime = Bars.GetTime(Math.Min(Math.Max(r.MaeBarIndex, 0), Bars.Count - 1));
			}
			catch { r.MfeTime = r.Time; r.MaeTime = r.Time; }
			r.MfeCalculated = true;
		}

		private void DrawResearchOverlay(SignalRecord r)
		{
			if (!r.MfeCalculated) ComputeMfeMae(r);
			double pv = PointValuePerContract();

			DateTime entryT = r.Time;

			// MFE = favorable region (green). Time-anchored so it renders from a mouse-click context.
			Draw.Rectangle(this, OV + "mfe", false, entryT, r.EntryPrice, r.MfeTime, r.MfePrice,
				Brushes.SeaGreen, Brushes.SeaGreen, MfeBoxOpacity);
			if (ShowPointsInsideMfeBox)
				DrawBoxText(OV + "mfeTxt", r.BarIndex, r.MfeBarIndex, r.EntryPrice, r.MfePrice,
					string.Format("MFE +{0:0.00} pts\n+${1:0.00} (1 contract)", r.MfePoints, r.MfePoints * pv));

			if (ShowMaeToo)
			{
				Draw.Rectangle(this, OV + "mae", false, entryT, r.EntryPrice, r.MaeTime, r.MaePrice,
					Brushes.Firebrick, Brushes.Firebrick, MaeBoxOpacity);
				if (ShowPointsInsideMfeBox)
					DrawBoxText(OV + "maeTxt", r.BarIndex, r.MaeBarIndex, r.EntryPrice, r.MaePrice,
						string.Format("MAE -{0:0.00} pts\n-${1:0.00} (1 contract)", r.MaePoints, r.MaePoints * pv));
			}

			if (ShowDollarTablePanel) DrawDollarPanel(r, pv);
		}

		// Draw blue text auto-sized to the box's pixel dimensions; skip entirely if even the
		// smallest readable size won't fit (caller's box stays clean rather than crammed).
		private void DrawBoxText(string tag, int bar0, int bar1, double y0, double y1, string text)
		{
			try
			{
				if (ChartControl == null || cachedScale == null) return;
				float x0 = ChartControl.GetXByBarIndex(ChartBars, bar0);
				float x1 = ChartControl.GetXByBarIndex(ChartBars, bar1);
				float yA = cachedScale.GetYByValue(y0);
				float yB = cachedScale.GetYByValue(y1);
				double boxW = Math.Abs(x1 - x0);
				double boxH = Math.Abs(yB - yA);

				string[] lines = text.Split('\n');
				int longest = 0; foreach (string l in lines) if (l.Length > longest) longest = l.Length;

				int font = -1;
				for (int f = 13; f >= 8; f--)
				{
					double w = longest * f * 0.60;     // rough glyph width
					double h = lines.Length * f * 1.35; // line height
					if (w <= boxW * 0.92 && h <= boxH * 0.92) { font = f; break; }
				}
				if (font < 0) return;   // too small to fit -> show nothing

				int midBar = (bar0 + bar1) / 2;
				double midY = (y0 + y1) / 2.0;
				DateTime midT;
				try { midT = Bars.GetTime(Math.Min(Math.Max(midBar, 0), Bars.Count - 1)); }
				catch { return; }
				Draw.Text(this, tag, false, text, midT, midY, 0, Brushes.RoyalBlue,
					new SimpleFont("Arial", font) { Bold = true },
					System.Windows.TextAlignment.Center, Brushes.Transparent, Brushes.Transparent, 0);
			}
			catch { }
		}

		private void DrawDollarPanel(SignalRecord r, double pv)
		{
			int[] qty = { 1, 2, 3, 5, 10 };
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Selected: " + r.TradeType + " " + (r.IsLong ? "Long" : "Short"));
			sb.AppendLine("Entry: " + r.EntryPrice.ToString("N2"));
			sb.AppendLine("");
			sb.AppendLine(string.Format("MFE: +{0:0.00} pts", r.MfePoints));
			foreach (int q in qty)
				sb.AppendLine(string.Format("  {0,2} contract{1}: +${2:N2}", q, q == 1 ? " " : "s", r.MfePoints * pv * q));
			sb.AppendLine("");
			sb.AppendLine(string.Format("MAE: -{0:0.00} pts", r.MaePoints));
			foreach (int q in qty)
				sb.AppendLine(string.Format("  {0,2} contract{1}: -${2:N2}", q, q == 1 ? " " : "s", r.MaePoints * pv * q));

			Draw.TextFixed(this, OV + "panel", sb.ToString(), MfeMaePanelPosition,
				Brushes.Gainsboro, new SimpleFont("Consolas", MfeMaePanelFontSize), Brushes.Black, Brushes.Black, MfeMaePanelOpacity);
		}

		private void ClearResearchOverlay()
		{
			RemoveDrawObject(OV + "mfe");
			RemoveDrawObject(OV + "mfeTxt");
			RemoveDrawObject(OV + "mae");
			RemoveDrawObject(OV + "maeTxt");
			RemoveDrawObject(OV + "panel");
		}

		// $ per point per contract. Auto: MNQ=$2, NQ=$20, else MasterInstrument.PointValue.
		private double PointValuePerContract()
		{
			if (DollarInstrument == RhDollarInstrument.MNQ) return 2.0;
			if (DollarInstrument == RhDollarInstrument.NQ)  return 20.0;
			try
			{
				string n = (Instrument != null && Instrument.FullName != null) ? Instrument.FullName : "";
				if (n.IndexOf("MNQ", StringComparison.OrdinalIgnoreCase) >= 0) return 2.0;
				if (n.IndexOf("NQ", StringComparison.OrdinalIgnoreCase) >= 0)  return 20.0;
				return Instrument.MasterInstrument.PointValue;
			}
			catch { return 2.0; }
		}
		#endregion

		#region Logging
		private void EnsureLogPath()
		{
			if (!string.IsNullOrEmpty(logPath)) return;
			try
			{
				string docs   = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string parent = Path.Combine(docs, "NinjaTrader 8", "NinjaTrader 8 - Chart Data Exports");
				string folder = Path.Combine(parent, "NQ_Reversal_Hunter_v002");
				if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
				logPath = Path.Combine(folder, "ReversalHunter_" + Time[0].ToString("yyyyMMdd") + ".csv");
			}
			catch { logPath = string.Empty; }
		}

		private void LogSignal(string signalName, string direction, bool isResearch, bool tickConfirmed, bool dim, bool elite, double entryPx)
		{
			EnsureLogPath();
			if (string.IsNullOrEmpty(logPath)) return;
			try
			{
				bool isNew = !File.Exists(logPath);
				using (StreamWriter w = new StreamWriter(logPath, true, Encoding.UTF8))
				{
					if (isNew || !logHeaderWritten)
					{
						if (isNew)
							w.WriteLine("Timestamp,Instrument,Preset,SignalName,Direction,Tier,IsResearch,IsElite,IsTickConfirmed,EsDim,Price,Close,High,Low,Atr,CvdMom,OR5High,OR5Low,OR15High,OR15Low,IB60High,IB60Low,TickClose,TickClose5,TickMom,EsMom5,VixMom5,ExitMode,Notes");
						logHeaderWritten = true;
					}
					string instr = (Instrument != null && Instrument.MasterInstrument != null) ? Instrument.MasterInstrument.Name : "NA";
					string tier = elite ? "ELITE" : (isResearch ? "RESEARCH" : "SIGNAL");
					string line = string.Join(",",
						Time[0].ToString("yyyy-MM-dd HH:mm:ss"), instr, Preset.ToString(),
						Esc(signalName), direction, tier,
						isResearch ? "1" : "0", elite ? "1" : "0", tickConfirmed ? "1" : "0", dim ? "1" : "0",
						entryPx.ToString("F2"), Close[0].ToString("F2"), High[0].ToString("F2"), Low[0].ToString("F2"),
						atr[0].ToString("F2"), CvdMomentum().ToString("F0"),
						FmtLevel(or5Done, or5High), FmtLevel(or5Done, or5Low),
						FmtLevel(or15Done, or15High), FmtLevel(or15Done, or15Low),
						FmtLevel(ib60Done, ib60High), FmtLevel(ib60Done, ib60Low),
						tickAvail ? tickC0.ToString("F0") : "NA", tickAvail ? tickC5.ToString("F0") : "NA", tickAvail ? tickMom.ToString("F0") : "NA",
						esAvail ? esMom5.ToString("F2") : "NA", vixAvail ? vixMom5.ToString("F2") : "NA",
						ExitMode.ToString(), "v0.2");
					w.WriteLine(line);
				}
			}
			catch { }
		}

		private string FmtLevel(bool done, double v)
		{
			if (!done || v == double.MinValue || v == double.MaxValue) return "NA";
			return v.ToString("F2");
		}
		private string Esc(string s) { return string.IsNullOrEmpty(s) ? "" : s.Replace(",", ";"); }
		#endregion

		#region Helpers
		private DateTime SessionStart(DateTime day)
		{
			int hh = RthStartTime / 10000, mm = (RthStartTime / 100) % 100, ss = RthStartTime % 100;
			return new DateTime(day.Year, day.Month, day.Day, hh, mm, ss);
		}
		private bool IsInRth(DateTime t)
		{
			int hms = t.Hour * 10000 + t.Minute * 100 + t.Second;
			return hms >= RthStartTime && hms <= RthEndTime;
		}
		#endregion
	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private ReversalHunter.Reversal_Hunter_Claude[] cacheReversal_Hunter_Claude;
		public ReversalHunter.Reversal_Hunter_Claude Reversal_Hunter_Claude(RhDisplayMode displayMode, RhPreset preset, bool applyPresetDefaults, int rthStartTime, int rthEndTime, int flattenTime, int extremeLookback, double minLegAtr, int atrPeriod, int climaxCvdLookback, int episodeCooldownMin, int triggerWindowMin, double fvgDisplacementAtr, bool useCisdEarly, bool useAbsorptionCoverage, bool useEsContext, string esSymbol, bool useVixContext, string vixSymbol, bool useTickConfirmation, string tickSymbol, int tickMomentumBars, bool showOrbModule, int orbMinutesFast, int orbMinutesStandard, int ibMinutes, RhExitMode exitMode, bool showExitPlan, int signalCooldownMin, bool showOrbLines, bool showRadarZones, bool showLabels, bool showResearchLabels, bool showDashboard, bool enableShortPrototype, bool enableCsvLogging, bool showSRank, bool showElite, bool showStars, bool showStandard, bool showEarly, int sRankCutoffTime, int entryMarkerFontSize, int labelFontSize, int labelOffsetTicks, int labelSwingLookback, bool showEntryPriceInLabel, int entryPriceFontSize, int labelMinBarGap, int labelRowGapTicks, bool useAtrLabelOffset, double atrOffsetMultiplier, int connectorWidth, int connectorOpacity, bool entryMarkerHalo, int entryMarkerHaloOffset, int earlyOpacityPercent, int standardOpacityPercent, int maxMfeLookaheadBars, bool showMaeToo, int mfeBoxOpacity, int maeBoxOpacity, bool showPointsInsideMfeBox, bool showDollarTablePanel, RhDollarInstrument dollarInstrument, TextPosition mfeMaePanelPosition, int mfeMaePanelOpacity, int mfeMaePanelFontSize, int researchAutoOffMinutes, int maxStoredSignals, int clickHitboxPixels, int labelHitHalfWidthPixels, bool showClickReadout, bool useTrueDelta, string volumetricInstrument, bool useRenderTimeLabels, bool useLegacyDrawTextLabels, int labelBaseGapPx, int labelLaneStepPx, int labelCornerRadius, int labelPaddingX, int labelPaddingY, int labelOpacity, bool useSegmentedBadges, bool showTradeIcons, bool useEmojiIcons, bool useFallbackGlyphIcons, string sRankIcon, string eliteIcon, string tickIcon, string standardLongIcon, string standardShortIcon, string earlyIcon, int maxLabelLanes, bool protectCandles, bool useCompactLabelsWhenCrowded, bool hideLowPriorityLabelsWhenCrowded, bool showGlyphOnlyMarkers, bool showLeaderLines, RhEntryMarker entryMarkerStyle, int badgeGapPx, string entryArrowLong, string entryArrowShort, bool showContractTable, RhLabelStyle labelStyle)
		{
			return Reversal_Hunter_Claude(Input, displayMode, preset, applyPresetDefaults, rthStartTime, rthEndTime, flattenTime, extremeLookback, minLegAtr, atrPeriod, climaxCvdLookback, episodeCooldownMin, triggerWindowMin, fvgDisplacementAtr, useCisdEarly, useAbsorptionCoverage, useEsContext, esSymbol, useVixContext, vixSymbol, useTickConfirmation, tickSymbol, tickMomentumBars, showOrbModule, orbMinutesFast, orbMinutesStandard, ibMinutes, exitMode, showExitPlan, signalCooldownMin, showOrbLines, showRadarZones, showLabels, showResearchLabels, showDashboard, enableShortPrototype, enableCsvLogging, showSRank, showElite, showStars, showStandard, showEarly, sRankCutoffTime, entryMarkerFontSize, labelFontSize, labelOffsetTicks, labelSwingLookback, showEntryPriceInLabel, entryPriceFontSize, labelMinBarGap, labelRowGapTicks, useAtrLabelOffset, atrOffsetMultiplier, connectorWidth, connectorOpacity, entryMarkerHalo, entryMarkerHaloOffset, earlyOpacityPercent, standardOpacityPercent, maxMfeLookaheadBars, showMaeToo, mfeBoxOpacity, maeBoxOpacity, showPointsInsideMfeBox, showDollarTablePanel, dollarInstrument, mfeMaePanelPosition, mfeMaePanelOpacity, mfeMaePanelFontSize, researchAutoOffMinutes, maxStoredSignals, clickHitboxPixels, labelHitHalfWidthPixels, showClickReadout, useTrueDelta, volumetricInstrument, useRenderTimeLabels, useLegacyDrawTextLabels, labelBaseGapPx, labelLaneStepPx, labelCornerRadius, labelPaddingX, labelPaddingY, labelOpacity, useSegmentedBadges, showTradeIcons, useEmojiIcons, useFallbackGlyphIcons, sRankIcon, eliteIcon, tickIcon, standardLongIcon, standardShortIcon, earlyIcon, maxLabelLanes, protectCandles, useCompactLabelsWhenCrowded, hideLowPriorityLabelsWhenCrowded, showGlyphOnlyMarkers, showLeaderLines, entryMarkerStyle, badgeGapPx, entryArrowLong, entryArrowShort, showContractTable, labelStyle);
		}

		public ReversalHunter.Reversal_Hunter_Claude Reversal_Hunter_Claude(ISeries<double> input, RhDisplayMode displayMode, RhPreset preset, bool applyPresetDefaults, int rthStartTime, int rthEndTime, int flattenTime, int extremeLookback, double minLegAtr, int atrPeriod, int climaxCvdLookback, int episodeCooldownMin, int triggerWindowMin, double fvgDisplacementAtr, bool useCisdEarly, bool useAbsorptionCoverage, bool useEsContext, string esSymbol, bool useVixContext, string vixSymbol, bool useTickConfirmation, string tickSymbol, int tickMomentumBars, bool showOrbModule, int orbMinutesFast, int orbMinutesStandard, int ibMinutes, RhExitMode exitMode, bool showExitPlan, int signalCooldownMin, bool showOrbLines, bool showRadarZones, bool showLabels, bool showResearchLabels, bool showDashboard, bool enableShortPrototype, bool enableCsvLogging, bool showSRank, bool showElite, bool showStars, bool showStandard, bool showEarly, int sRankCutoffTime, int entryMarkerFontSize, int labelFontSize, int labelOffsetTicks, int labelSwingLookback, bool showEntryPriceInLabel, int entryPriceFontSize, int labelMinBarGap, int labelRowGapTicks, bool useAtrLabelOffset, double atrOffsetMultiplier, int connectorWidth, int connectorOpacity, bool entryMarkerHalo, int entryMarkerHaloOffset, int earlyOpacityPercent, int standardOpacityPercent, int maxMfeLookaheadBars, bool showMaeToo, int mfeBoxOpacity, int maeBoxOpacity, bool showPointsInsideMfeBox, bool showDollarTablePanel, RhDollarInstrument dollarInstrument, TextPosition mfeMaePanelPosition, int mfeMaePanelOpacity, int mfeMaePanelFontSize, int researchAutoOffMinutes, int maxStoredSignals, int clickHitboxPixels, int labelHitHalfWidthPixels, bool showClickReadout, bool useTrueDelta, string volumetricInstrument, bool useRenderTimeLabels, bool useLegacyDrawTextLabels, int labelBaseGapPx, int labelLaneStepPx, int labelCornerRadius, int labelPaddingX, int labelPaddingY, int labelOpacity, bool useSegmentedBadges, bool showTradeIcons, bool useEmojiIcons, bool useFallbackGlyphIcons, string sRankIcon, string eliteIcon, string tickIcon, string standardLongIcon, string standardShortIcon, string earlyIcon, int maxLabelLanes, bool protectCandles, bool useCompactLabelsWhenCrowded, bool hideLowPriorityLabelsWhenCrowded, bool showGlyphOnlyMarkers, bool showLeaderLines, RhEntryMarker entryMarkerStyle, int badgeGapPx, string entryArrowLong, string entryArrowShort, bool showContractTable, RhLabelStyle labelStyle)
		{
			if (cacheReversal_Hunter_Claude != null)
				for (int idx = 0; idx < cacheReversal_Hunter_Claude.Length; idx++)
					if (cacheReversal_Hunter_Claude[idx] != null && cacheReversal_Hunter_Claude[idx].DisplayMode == displayMode && cacheReversal_Hunter_Claude[idx].Preset == preset && cacheReversal_Hunter_Claude[idx].ApplyPresetDefaults == applyPresetDefaults && cacheReversal_Hunter_Claude[idx].RthStartTime == rthStartTime && cacheReversal_Hunter_Claude[idx].RthEndTime == rthEndTime && cacheReversal_Hunter_Claude[idx].FlattenTime == flattenTime && cacheReversal_Hunter_Claude[idx].ExtremeLookback == extremeLookback && cacheReversal_Hunter_Claude[idx].MinLegAtr == minLegAtr && cacheReversal_Hunter_Claude[idx].AtrPeriod == atrPeriod && cacheReversal_Hunter_Claude[idx].ClimaxCvdLookback == climaxCvdLookback && cacheReversal_Hunter_Claude[idx].EpisodeCooldownMin == episodeCooldownMin && cacheReversal_Hunter_Claude[idx].TriggerWindowMin == triggerWindowMin && cacheReversal_Hunter_Claude[idx].FvgDisplacementAtr == fvgDisplacementAtr && cacheReversal_Hunter_Claude[idx].UseCisdEarly == useCisdEarly && cacheReversal_Hunter_Claude[idx].UseAbsorptionCoverage == useAbsorptionCoverage && cacheReversal_Hunter_Claude[idx].UseEsContext == useEsContext && cacheReversal_Hunter_Claude[idx].EsSymbol == esSymbol && cacheReversal_Hunter_Claude[idx].UseVixContext == useVixContext && cacheReversal_Hunter_Claude[idx].VixSymbol == vixSymbol && cacheReversal_Hunter_Claude[idx].UseTickConfirmation == useTickConfirmation && cacheReversal_Hunter_Claude[idx].TickSymbol == tickSymbol && cacheReversal_Hunter_Claude[idx].TickMomentumBars == tickMomentumBars && cacheReversal_Hunter_Claude[idx].ShowOrbModule == showOrbModule && cacheReversal_Hunter_Claude[idx].OrbMinutesFast == orbMinutesFast && cacheReversal_Hunter_Claude[idx].OrbMinutesStandard == orbMinutesStandard && cacheReversal_Hunter_Claude[idx].IbMinutes == ibMinutes && cacheReversal_Hunter_Claude[idx].ExitMode == exitMode && cacheReversal_Hunter_Claude[idx].ShowExitPlan == showExitPlan && cacheReversal_Hunter_Claude[idx].SignalCooldownMin == signalCooldownMin && cacheReversal_Hunter_Claude[idx].ShowOrbLines == showOrbLines && cacheReversal_Hunter_Claude[idx].ShowRadarZones == showRadarZones && cacheReversal_Hunter_Claude[idx].ShowLabels == showLabels && cacheReversal_Hunter_Claude[idx].ShowResearchLabels == showResearchLabels && cacheReversal_Hunter_Claude[idx].ShowDashboard == showDashboard && cacheReversal_Hunter_Claude[idx].EnableShortPrototype == enableShortPrototype && cacheReversal_Hunter_Claude[idx].EnableCsvLogging == enableCsvLogging && cacheReversal_Hunter_Claude[idx].ShowSRank == showSRank && cacheReversal_Hunter_Claude[idx].ShowElite == showElite && cacheReversal_Hunter_Claude[idx].ShowStars == showStars && cacheReversal_Hunter_Claude[idx].ShowStandard == showStandard && cacheReversal_Hunter_Claude[idx].ShowEarly == showEarly && cacheReversal_Hunter_Claude[idx].SRankCutoffTime == sRankCutoffTime && cacheReversal_Hunter_Claude[idx].EntryMarkerFontSize == entryMarkerFontSize && cacheReversal_Hunter_Claude[idx].LabelFontSize == labelFontSize && cacheReversal_Hunter_Claude[idx].LabelOffsetTicks == labelOffsetTicks && cacheReversal_Hunter_Claude[idx].LabelSwingLookback == labelSwingLookback && cacheReversal_Hunter_Claude[idx].ShowEntryPriceInLabel == showEntryPriceInLabel && cacheReversal_Hunter_Claude[idx].EntryPriceFontSize == entryPriceFontSize && cacheReversal_Hunter_Claude[idx].LabelMinBarGap == labelMinBarGap && cacheReversal_Hunter_Claude[idx].LabelRowGapTicks == labelRowGapTicks && cacheReversal_Hunter_Claude[idx].UseAtrLabelOffset == useAtrLabelOffset && cacheReversal_Hunter_Claude[idx].AtrOffsetMultiplier == atrOffsetMultiplier && cacheReversal_Hunter_Claude[idx].ConnectorWidth == connectorWidth && cacheReversal_Hunter_Claude[idx].ConnectorOpacity == connectorOpacity && cacheReversal_Hunter_Claude[idx].EntryMarkerHalo == entryMarkerHalo && cacheReversal_Hunter_Claude[idx].EntryMarkerHaloOffset == entryMarkerHaloOffset && cacheReversal_Hunter_Claude[idx].EarlyOpacityPercent == earlyOpacityPercent && cacheReversal_Hunter_Claude[idx].StandardOpacityPercent == standardOpacityPercent && cacheReversal_Hunter_Claude[idx].MaxMfeLookaheadBars == maxMfeLookaheadBars && cacheReversal_Hunter_Claude[idx].ShowMaeToo == showMaeToo && cacheReversal_Hunter_Claude[idx].MfeBoxOpacity == mfeBoxOpacity && cacheReversal_Hunter_Claude[idx].MaeBoxOpacity == maeBoxOpacity && cacheReversal_Hunter_Claude[idx].ShowPointsInsideMfeBox == showPointsInsideMfeBox && cacheReversal_Hunter_Claude[idx].ShowDollarTablePanel == showDollarTablePanel && cacheReversal_Hunter_Claude[idx].DollarInstrument == dollarInstrument && cacheReversal_Hunter_Claude[idx].MfeMaePanelPosition == mfeMaePanelPosition && cacheReversal_Hunter_Claude[idx].MfeMaePanelOpacity == mfeMaePanelOpacity && cacheReversal_Hunter_Claude[idx].MfeMaePanelFontSize == mfeMaePanelFontSize && cacheReversal_Hunter_Claude[idx].ResearchAutoOffMinutes == researchAutoOffMinutes && cacheReversal_Hunter_Claude[idx].MaxStoredSignals == maxStoredSignals && cacheReversal_Hunter_Claude[idx].ClickHitboxPixels == clickHitboxPixels && cacheReversal_Hunter_Claude[idx].LabelHitHalfWidthPixels == labelHitHalfWidthPixels && cacheReversal_Hunter_Claude[idx].ShowClickReadout == showClickReadout && cacheReversal_Hunter_Claude[idx].UseTrueDelta == useTrueDelta && cacheReversal_Hunter_Claude[idx].VolumetricInstrument == volumetricInstrument && cacheReversal_Hunter_Claude[idx].UseRenderTimeLabels == useRenderTimeLabels && cacheReversal_Hunter_Claude[idx].UseLegacyDrawTextLabels == useLegacyDrawTextLabels && cacheReversal_Hunter_Claude[idx].LabelBaseGapPx == labelBaseGapPx && cacheReversal_Hunter_Claude[idx].LabelLaneStepPx == labelLaneStepPx && cacheReversal_Hunter_Claude[idx].LabelCornerRadius == labelCornerRadius && cacheReversal_Hunter_Claude[idx].LabelPaddingX == labelPaddingX && cacheReversal_Hunter_Claude[idx].LabelPaddingY == labelPaddingY && cacheReversal_Hunter_Claude[idx].LabelOpacity == labelOpacity && cacheReversal_Hunter_Claude[idx].UseSegmentedBadges == useSegmentedBadges && cacheReversal_Hunter_Claude[idx].ShowTradeIcons == showTradeIcons && cacheReversal_Hunter_Claude[idx].UseEmojiIcons == useEmojiIcons && cacheReversal_Hunter_Claude[idx].UseFallbackGlyphIcons == useFallbackGlyphIcons && cacheReversal_Hunter_Claude[idx].SRankIcon == sRankIcon && cacheReversal_Hunter_Claude[idx].EliteIcon == eliteIcon && cacheReversal_Hunter_Claude[idx].TickIcon == tickIcon && cacheReversal_Hunter_Claude[idx].StandardLongIcon == standardLongIcon && cacheReversal_Hunter_Claude[idx].StandardShortIcon == standardShortIcon && cacheReversal_Hunter_Claude[idx].EarlyIcon == earlyIcon && cacheReversal_Hunter_Claude[idx].MaxLabelLanes == maxLabelLanes && cacheReversal_Hunter_Claude[idx].ProtectCandles == protectCandles && cacheReversal_Hunter_Claude[idx].UseCompactLabelsWhenCrowded == useCompactLabelsWhenCrowded && cacheReversal_Hunter_Claude[idx].HideLowPriorityLabelsWhenCrowded == hideLowPriorityLabelsWhenCrowded && cacheReversal_Hunter_Claude[idx].ShowGlyphOnlyMarkers == showGlyphOnlyMarkers && cacheReversal_Hunter_Claude[idx].ShowLeaderLines == showLeaderLines && cacheReversal_Hunter_Claude[idx].EntryMarkerStyle == entryMarkerStyle && cacheReversal_Hunter_Claude[idx].BadgeGapPx == badgeGapPx && cacheReversal_Hunter_Claude[idx].EntryArrowLong == entryArrowLong && cacheReversal_Hunter_Claude[idx].EntryArrowShort == entryArrowShort && cacheReversal_Hunter_Claude[idx].ShowContractTable == showContractTable && cacheReversal_Hunter_Claude[idx].LabelStyle == labelStyle && cacheReversal_Hunter_Claude[idx].EqualsInput(input))
						return cacheReversal_Hunter_Claude[idx];
			return CacheIndicator<ReversalHunter.Reversal_Hunter_Claude>(new ReversalHunter.Reversal_Hunter_Claude(){ DisplayMode = displayMode, Preset = preset, ApplyPresetDefaults = applyPresetDefaults, RthStartTime = rthStartTime, RthEndTime = rthEndTime, FlattenTime = flattenTime, ExtremeLookback = extremeLookback, MinLegAtr = minLegAtr, AtrPeriod = atrPeriod, ClimaxCvdLookback = climaxCvdLookback, EpisodeCooldownMin = episodeCooldownMin, TriggerWindowMin = triggerWindowMin, FvgDisplacementAtr = fvgDisplacementAtr, UseCisdEarly = useCisdEarly, UseAbsorptionCoverage = useAbsorptionCoverage, UseEsContext = useEsContext, EsSymbol = esSymbol, UseVixContext = useVixContext, VixSymbol = vixSymbol, UseTickConfirmation = useTickConfirmation, TickSymbol = tickSymbol, TickMomentumBars = tickMomentumBars, ShowOrbModule = showOrbModule, OrbMinutesFast = orbMinutesFast, OrbMinutesStandard = orbMinutesStandard, IbMinutes = ibMinutes, ExitMode = exitMode, ShowExitPlan = showExitPlan, SignalCooldownMin = signalCooldownMin, ShowOrbLines = showOrbLines, ShowRadarZones = showRadarZones, ShowLabels = showLabels, ShowResearchLabels = showResearchLabels, ShowDashboard = showDashboard, EnableShortPrototype = enableShortPrototype, EnableCsvLogging = enableCsvLogging, ShowSRank = showSRank, ShowElite = showElite, ShowStars = showStars, ShowStandard = showStandard, ShowEarly = showEarly, SRankCutoffTime = sRankCutoffTime, EntryMarkerFontSize = entryMarkerFontSize, LabelFontSize = labelFontSize, LabelOffsetTicks = labelOffsetTicks, LabelSwingLookback = labelSwingLookback, ShowEntryPriceInLabel = showEntryPriceInLabel, EntryPriceFontSize = entryPriceFontSize, LabelMinBarGap = labelMinBarGap, LabelRowGapTicks = labelRowGapTicks, UseAtrLabelOffset = useAtrLabelOffset, AtrOffsetMultiplier = atrOffsetMultiplier, ConnectorWidth = connectorWidth, ConnectorOpacity = connectorOpacity, EntryMarkerHalo = entryMarkerHalo, EntryMarkerHaloOffset = entryMarkerHaloOffset, EarlyOpacityPercent = earlyOpacityPercent, StandardOpacityPercent = standardOpacityPercent, MaxMfeLookaheadBars = maxMfeLookaheadBars, ShowMaeToo = showMaeToo, MfeBoxOpacity = mfeBoxOpacity, MaeBoxOpacity = maeBoxOpacity, ShowPointsInsideMfeBox = showPointsInsideMfeBox, ShowDollarTablePanel = showDollarTablePanel, DollarInstrument = dollarInstrument, MfeMaePanelPosition = mfeMaePanelPosition, MfeMaePanelOpacity = mfeMaePanelOpacity, MfeMaePanelFontSize = mfeMaePanelFontSize, ResearchAutoOffMinutes = researchAutoOffMinutes, MaxStoredSignals = maxStoredSignals, ClickHitboxPixels = clickHitboxPixels, LabelHitHalfWidthPixels = labelHitHalfWidthPixels, ShowClickReadout = showClickReadout, UseTrueDelta = useTrueDelta, VolumetricInstrument = volumetricInstrument, UseRenderTimeLabels = useRenderTimeLabels, UseLegacyDrawTextLabels = useLegacyDrawTextLabels, LabelBaseGapPx = labelBaseGapPx, LabelLaneStepPx = labelLaneStepPx, LabelCornerRadius = labelCornerRadius, LabelPaddingX = labelPaddingX, LabelPaddingY = labelPaddingY, LabelOpacity = labelOpacity, UseSegmentedBadges = useSegmentedBadges, ShowTradeIcons = showTradeIcons, UseEmojiIcons = useEmojiIcons, UseFallbackGlyphIcons = useFallbackGlyphIcons, SRankIcon = sRankIcon, EliteIcon = eliteIcon, TickIcon = tickIcon, StandardLongIcon = standardLongIcon, StandardShortIcon = standardShortIcon, EarlyIcon = earlyIcon, MaxLabelLanes = maxLabelLanes, ProtectCandles = protectCandles, UseCompactLabelsWhenCrowded = useCompactLabelsWhenCrowded, HideLowPriorityLabelsWhenCrowded = hideLowPriorityLabelsWhenCrowded, ShowGlyphOnlyMarkers = showGlyphOnlyMarkers, ShowLeaderLines = showLeaderLines, EntryMarkerStyle = entryMarkerStyle, BadgeGapPx = badgeGapPx, EntryArrowLong = entryArrowLong, EntryArrowShort = entryArrowShort, ShowContractTable = showContractTable, LabelStyle = labelStyle }, input, ref cacheReversal_Hunter_Claude);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.ReversalHunter.Reversal_Hunter_Claude Reversal_Hunter_Claude(RhDisplayMode displayMode, RhPreset preset, bool applyPresetDefaults, int rthStartTime, int rthEndTime, int flattenTime, int extremeLookback, double minLegAtr, int atrPeriod, int climaxCvdLookback, int episodeCooldownMin, int triggerWindowMin, double fvgDisplacementAtr, bool useCisdEarly, bool useAbsorptionCoverage, bool useEsContext, string esSymbol, bool useVixContext, string vixSymbol, bool useTickConfirmation, string tickSymbol, int tickMomentumBars, bool showOrbModule, int orbMinutesFast, int orbMinutesStandard, int ibMinutes, RhExitMode exitMode, bool showExitPlan, int signalCooldownMin, bool showOrbLines, bool showRadarZones, bool showLabels, bool showResearchLabels, bool showDashboard, bool enableShortPrototype, bool enableCsvLogging, bool showSRank, bool showElite, bool showStars, bool showStandard, bool showEarly, int sRankCutoffTime, int entryMarkerFontSize, int labelFontSize, int labelOffsetTicks, int labelSwingLookback, bool showEntryPriceInLabel, int entryPriceFontSize, int labelMinBarGap, int labelRowGapTicks, bool useAtrLabelOffset, double atrOffsetMultiplier, int connectorWidth, int connectorOpacity, bool entryMarkerHalo, int entryMarkerHaloOffset, int earlyOpacityPercent, int standardOpacityPercent, int maxMfeLookaheadBars, bool showMaeToo, int mfeBoxOpacity, int maeBoxOpacity, bool showPointsInsideMfeBox, bool showDollarTablePanel, RhDollarInstrument dollarInstrument, TextPosition mfeMaePanelPosition, int mfeMaePanelOpacity, int mfeMaePanelFontSize, int researchAutoOffMinutes, int maxStoredSignals, int clickHitboxPixels, int labelHitHalfWidthPixels, bool showClickReadout, bool useTrueDelta, string volumetricInstrument, bool useRenderTimeLabels, bool useLegacyDrawTextLabels, int labelBaseGapPx, int labelLaneStepPx, int labelCornerRadius, int labelPaddingX, int labelPaddingY, int labelOpacity, bool useSegmentedBadges, bool showTradeIcons, bool useEmojiIcons, bool useFallbackGlyphIcons, string sRankIcon, string eliteIcon, string tickIcon, string standardLongIcon, string standardShortIcon, string earlyIcon, int maxLabelLanes, bool protectCandles, bool useCompactLabelsWhenCrowded, bool hideLowPriorityLabelsWhenCrowded, bool showGlyphOnlyMarkers, bool showLeaderLines, RhEntryMarker entryMarkerStyle, int badgeGapPx, string entryArrowLong, string entryArrowShort, bool showContractTable, RhLabelStyle labelStyle)
		{
			return indicator.Reversal_Hunter_Claude(Input, displayMode, preset, applyPresetDefaults, rthStartTime, rthEndTime, flattenTime, extremeLookback, minLegAtr, atrPeriod, climaxCvdLookback, episodeCooldownMin, triggerWindowMin, fvgDisplacementAtr, useCisdEarly, useAbsorptionCoverage, useEsContext, esSymbol, useVixContext, vixSymbol, useTickConfirmation, tickSymbol, tickMomentumBars, showOrbModule, orbMinutesFast, orbMinutesStandard, ibMinutes, exitMode, showExitPlan, signalCooldownMin, showOrbLines, showRadarZones, showLabels, showResearchLabels, showDashboard, enableShortPrototype, enableCsvLogging, showSRank, showElite, showStars, showStandard, showEarly, sRankCutoffTime, entryMarkerFontSize, labelFontSize, labelOffsetTicks, labelSwingLookback, showEntryPriceInLabel, entryPriceFontSize, labelMinBarGap, labelRowGapTicks, useAtrLabelOffset, atrOffsetMultiplier, connectorWidth, connectorOpacity, entryMarkerHalo, entryMarkerHaloOffset, earlyOpacityPercent, standardOpacityPercent, maxMfeLookaheadBars, showMaeToo, mfeBoxOpacity, maeBoxOpacity, showPointsInsideMfeBox, showDollarTablePanel, dollarInstrument, mfeMaePanelPosition, mfeMaePanelOpacity, mfeMaePanelFontSize, researchAutoOffMinutes, maxStoredSignals, clickHitboxPixels, labelHitHalfWidthPixels, showClickReadout, useTrueDelta, volumetricInstrument, useRenderTimeLabels, useLegacyDrawTextLabels, labelBaseGapPx, labelLaneStepPx, labelCornerRadius, labelPaddingX, labelPaddingY, labelOpacity, useSegmentedBadges, showTradeIcons, useEmojiIcons, useFallbackGlyphIcons, sRankIcon, eliteIcon, tickIcon, standardLongIcon, standardShortIcon, earlyIcon, maxLabelLanes, protectCandles, useCompactLabelsWhenCrowded, hideLowPriorityLabelsWhenCrowded, showGlyphOnlyMarkers, showLeaderLines, entryMarkerStyle, badgeGapPx, entryArrowLong, entryArrowShort, showContractTable, labelStyle);
		}

		public Indicators.ReversalHunter.Reversal_Hunter_Claude Reversal_Hunter_Claude(ISeries<double> input , RhDisplayMode displayMode, RhPreset preset, bool applyPresetDefaults, int rthStartTime, int rthEndTime, int flattenTime, int extremeLookback, double minLegAtr, int atrPeriod, int climaxCvdLookback, int episodeCooldownMin, int triggerWindowMin, double fvgDisplacementAtr, bool useCisdEarly, bool useAbsorptionCoverage, bool useEsContext, string esSymbol, bool useVixContext, string vixSymbol, bool useTickConfirmation, string tickSymbol, int tickMomentumBars, bool showOrbModule, int orbMinutesFast, int orbMinutesStandard, int ibMinutes, RhExitMode exitMode, bool showExitPlan, int signalCooldownMin, bool showOrbLines, bool showRadarZones, bool showLabels, bool showResearchLabels, bool showDashboard, bool enableShortPrototype, bool enableCsvLogging, bool showSRank, bool showElite, bool showStars, bool showStandard, bool showEarly, int sRankCutoffTime, int entryMarkerFontSize, int labelFontSize, int labelOffsetTicks, int labelSwingLookback, bool showEntryPriceInLabel, int entryPriceFontSize, int labelMinBarGap, int labelRowGapTicks, bool useAtrLabelOffset, double atrOffsetMultiplier, int connectorWidth, int connectorOpacity, bool entryMarkerHalo, int entryMarkerHaloOffset, int earlyOpacityPercent, int standardOpacityPercent, int maxMfeLookaheadBars, bool showMaeToo, int mfeBoxOpacity, int maeBoxOpacity, bool showPointsInsideMfeBox, bool showDollarTablePanel, RhDollarInstrument dollarInstrument, TextPosition mfeMaePanelPosition, int mfeMaePanelOpacity, int mfeMaePanelFontSize, int researchAutoOffMinutes, int maxStoredSignals, int clickHitboxPixels, int labelHitHalfWidthPixels, bool showClickReadout, bool useTrueDelta, string volumetricInstrument, bool useRenderTimeLabels, bool useLegacyDrawTextLabels, int labelBaseGapPx, int labelLaneStepPx, int labelCornerRadius, int labelPaddingX, int labelPaddingY, int labelOpacity, bool useSegmentedBadges, bool showTradeIcons, bool useEmojiIcons, bool useFallbackGlyphIcons, string sRankIcon, string eliteIcon, string tickIcon, string standardLongIcon, string standardShortIcon, string earlyIcon, int maxLabelLanes, bool protectCandles, bool useCompactLabelsWhenCrowded, bool hideLowPriorityLabelsWhenCrowded, bool showGlyphOnlyMarkers, bool showLeaderLines, RhEntryMarker entryMarkerStyle, int badgeGapPx, string entryArrowLong, string entryArrowShort, bool showContractTable, RhLabelStyle labelStyle)
		{
			return indicator.Reversal_Hunter_Claude(input, displayMode, preset, applyPresetDefaults, rthStartTime, rthEndTime, flattenTime, extremeLookback, minLegAtr, atrPeriod, climaxCvdLookback, episodeCooldownMin, triggerWindowMin, fvgDisplacementAtr, useCisdEarly, useAbsorptionCoverage, useEsContext, esSymbol, useVixContext, vixSymbol, useTickConfirmation, tickSymbol, tickMomentumBars, showOrbModule, orbMinutesFast, orbMinutesStandard, ibMinutes, exitMode, showExitPlan, signalCooldownMin, showOrbLines, showRadarZones, showLabels, showResearchLabels, showDashboard, enableShortPrototype, enableCsvLogging, showSRank, showElite, showStars, showStandard, showEarly, sRankCutoffTime, entryMarkerFontSize, labelFontSize, labelOffsetTicks, labelSwingLookback, showEntryPriceInLabel, entryPriceFontSize, labelMinBarGap, labelRowGapTicks, useAtrLabelOffset, atrOffsetMultiplier, connectorWidth, connectorOpacity, entryMarkerHalo, entryMarkerHaloOffset, earlyOpacityPercent, standardOpacityPercent, maxMfeLookaheadBars, showMaeToo, mfeBoxOpacity, maeBoxOpacity, showPointsInsideMfeBox, showDollarTablePanel, dollarInstrument, mfeMaePanelPosition, mfeMaePanelOpacity, mfeMaePanelFontSize, researchAutoOffMinutes, maxStoredSignals, clickHitboxPixels, labelHitHalfWidthPixels, showClickReadout, useTrueDelta, volumetricInstrument, useRenderTimeLabels, useLegacyDrawTextLabels, labelBaseGapPx, labelLaneStepPx, labelCornerRadius, labelPaddingX, labelPaddingY, labelOpacity, useSegmentedBadges, showTradeIcons, useEmojiIcons, useFallbackGlyphIcons, sRankIcon, eliteIcon, tickIcon, standardLongIcon, standardShortIcon, earlyIcon, maxLabelLanes, protectCandles, useCompactLabelsWhenCrowded, hideLowPriorityLabelsWhenCrowded, showGlyphOnlyMarkers, showLeaderLines, entryMarkerStyle, badgeGapPx, entryArrowLong, entryArrowShort, showContractTable, labelStyle);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.ReversalHunter.Reversal_Hunter_Claude Reversal_Hunter_Claude(RhDisplayMode displayMode, RhPreset preset, bool applyPresetDefaults, int rthStartTime, int rthEndTime, int flattenTime, int extremeLookback, double minLegAtr, int atrPeriod, int climaxCvdLookback, int episodeCooldownMin, int triggerWindowMin, double fvgDisplacementAtr, bool useCisdEarly, bool useAbsorptionCoverage, bool useEsContext, string esSymbol, bool useVixContext, string vixSymbol, bool useTickConfirmation, string tickSymbol, int tickMomentumBars, bool showOrbModule, int orbMinutesFast, int orbMinutesStandard, int ibMinutes, RhExitMode exitMode, bool showExitPlan, int signalCooldownMin, bool showOrbLines, bool showRadarZones, bool showLabels, bool showResearchLabels, bool showDashboard, bool enableShortPrototype, bool enableCsvLogging, bool showSRank, bool showElite, bool showStars, bool showStandard, bool showEarly, int sRankCutoffTime, int entryMarkerFontSize, int labelFontSize, int labelOffsetTicks, int labelSwingLookback, bool showEntryPriceInLabel, int entryPriceFontSize, int labelMinBarGap, int labelRowGapTicks, bool useAtrLabelOffset, double atrOffsetMultiplier, int connectorWidth, int connectorOpacity, bool entryMarkerHalo, int entryMarkerHaloOffset, int earlyOpacityPercent, int standardOpacityPercent, int maxMfeLookaheadBars, bool showMaeToo, int mfeBoxOpacity, int maeBoxOpacity, bool showPointsInsideMfeBox, bool showDollarTablePanel, RhDollarInstrument dollarInstrument, TextPosition mfeMaePanelPosition, int mfeMaePanelOpacity, int mfeMaePanelFontSize, int researchAutoOffMinutes, int maxStoredSignals, int clickHitboxPixels, int labelHitHalfWidthPixels, bool showClickReadout, bool useTrueDelta, string volumetricInstrument, bool useRenderTimeLabels, bool useLegacyDrawTextLabels, int labelBaseGapPx, int labelLaneStepPx, int labelCornerRadius, int labelPaddingX, int labelPaddingY, int labelOpacity, bool useSegmentedBadges, bool showTradeIcons, bool useEmojiIcons, bool useFallbackGlyphIcons, string sRankIcon, string eliteIcon, string tickIcon, string standardLongIcon, string standardShortIcon, string earlyIcon, int maxLabelLanes, bool protectCandles, bool useCompactLabelsWhenCrowded, bool hideLowPriorityLabelsWhenCrowded, bool showGlyphOnlyMarkers, bool showLeaderLines, RhEntryMarker entryMarkerStyle, int badgeGapPx, string entryArrowLong, string entryArrowShort, bool showContractTable, RhLabelStyle labelStyle)
		{
			return indicator.Reversal_Hunter_Claude(Input, displayMode, preset, applyPresetDefaults, rthStartTime, rthEndTime, flattenTime, extremeLookback, minLegAtr, atrPeriod, climaxCvdLookback, episodeCooldownMin, triggerWindowMin, fvgDisplacementAtr, useCisdEarly, useAbsorptionCoverage, useEsContext, esSymbol, useVixContext, vixSymbol, useTickConfirmation, tickSymbol, tickMomentumBars, showOrbModule, orbMinutesFast, orbMinutesStandard, ibMinutes, exitMode, showExitPlan, signalCooldownMin, showOrbLines, showRadarZones, showLabels, showResearchLabels, showDashboard, enableShortPrototype, enableCsvLogging, showSRank, showElite, showStars, showStandard, showEarly, sRankCutoffTime, entryMarkerFontSize, labelFontSize, labelOffsetTicks, labelSwingLookback, showEntryPriceInLabel, entryPriceFontSize, labelMinBarGap, labelRowGapTicks, useAtrLabelOffset, atrOffsetMultiplier, connectorWidth, connectorOpacity, entryMarkerHalo, entryMarkerHaloOffset, earlyOpacityPercent, standardOpacityPercent, maxMfeLookaheadBars, showMaeToo, mfeBoxOpacity, maeBoxOpacity, showPointsInsideMfeBox, showDollarTablePanel, dollarInstrument, mfeMaePanelPosition, mfeMaePanelOpacity, mfeMaePanelFontSize, researchAutoOffMinutes, maxStoredSignals, clickHitboxPixels, labelHitHalfWidthPixels, showClickReadout, useTrueDelta, volumetricInstrument, useRenderTimeLabels, useLegacyDrawTextLabels, labelBaseGapPx, labelLaneStepPx, labelCornerRadius, labelPaddingX, labelPaddingY, labelOpacity, useSegmentedBadges, showTradeIcons, useEmojiIcons, useFallbackGlyphIcons, sRankIcon, eliteIcon, tickIcon, standardLongIcon, standardShortIcon, earlyIcon, maxLabelLanes, protectCandles, useCompactLabelsWhenCrowded, hideLowPriorityLabelsWhenCrowded, showGlyphOnlyMarkers, showLeaderLines, entryMarkerStyle, badgeGapPx, entryArrowLong, entryArrowShort, showContractTable, labelStyle);
		}

		public Indicators.ReversalHunter.Reversal_Hunter_Claude Reversal_Hunter_Claude(ISeries<double> input , RhDisplayMode displayMode, RhPreset preset, bool applyPresetDefaults, int rthStartTime, int rthEndTime, int flattenTime, int extremeLookback, double minLegAtr, int atrPeriod, int climaxCvdLookback, int episodeCooldownMin, int triggerWindowMin, double fvgDisplacementAtr, bool useCisdEarly, bool useAbsorptionCoverage, bool useEsContext, string esSymbol, bool useVixContext, string vixSymbol, bool useTickConfirmation, string tickSymbol, int tickMomentumBars, bool showOrbModule, int orbMinutesFast, int orbMinutesStandard, int ibMinutes, RhExitMode exitMode, bool showExitPlan, int signalCooldownMin, bool showOrbLines, bool showRadarZones, bool showLabels, bool showResearchLabels, bool showDashboard, bool enableShortPrototype, bool enableCsvLogging, bool showSRank, bool showElite, bool showStars, bool showStandard, bool showEarly, int sRankCutoffTime, int entryMarkerFontSize, int labelFontSize, int labelOffsetTicks, int labelSwingLookback, bool showEntryPriceInLabel, int entryPriceFontSize, int labelMinBarGap, int labelRowGapTicks, bool useAtrLabelOffset, double atrOffsetMultiplier, int connectorWidth, int connectorOpacity, bool entryMarkerHalo, int entryMarkerHaloOffset, int earlyOpacityPercent, int standardOpacityPercent, int maxMfeLookaheadBars, bool showMaeToo, int mfeBoxOpacity, int maeBoxOpacity, bool showPointsInsideMfeBox, bool showDollarTablePanel, RhDollarInstrument dollarInstrument, TextPosition mfeMaePanelPosition, int mfeMaePanelOpacity, int mfeMaePanelFontSize, int researchAutoOffMinutes, int maxStoredSignals, int clickHitboxPixels, int labelHitHalfWidthPixels, bool showClickReadout, bool useTrueDelta, string volumetricInstrument, bool useRenderTimeLabels, bool useLegacyDrawTextLabels, int labelBaseGapPx, int labelLaneStepPx, int labelCornerRadius, int labelPaddingX, int labelPaddingY, int labelOpacity, bool useSegmentedBadges, bool showTradeIcons, bool useEmojiIcons, bool useFallbackGlyphIcons, string sRankIcon, string eliteIcon, string tickIcon, string standardLongIcon, string standardShortIcon, string earlyIcon, int maxLabelLanes, bool protectCandles, bool useCompactLabelsWhenCrowded, bool hideLowPriorityLabelsWhenCrowded, bool showGlyphOnlyMarkers, bool showLeaderLines, RhEntryMarker entryMarkerStyle, int badgeGapPx, string entryArrowLong, string entryArrowShort, bool showContractTable, RhLabelStyle labelStyle)
		{
			return indicator.Reversal_Hunter_Claude(input, displayMode, preset, applyPresetDefaults, rthStartTime, rthEndTime, flattenTime, extremeLookback, minLegAtr, atrPeriod, climaxCvdLookback, episodeCooldownMin, triggerWindowMin, fvgDisplacementAtr, useCisdEarly, useAbsorptionCoverage, useEsContext, esSymbol, useVixContext, vixSymbol, useTickConfirmation, tickSymbol, tickMomentumBars, showOrbModule, orbMinutesFast, orbMinutesStandard, ibMinutes, exitMode, showExitPlan, signalCooldownMin, showOrbLines, showRadarZones, showLabels, showResearchLabels, showDashboard, enableShortPrototype, enableCsvLogging, showSRank, showElite, showStars, showStandard, showEarly, sRankCutoffTime, entryMarkerFontSize, labelFontSize, labelOffsetTicks, labelSwingLookback, showEntryPriceInLabel, entryPriceFontSize, labelMinBarGap, labelRowGapTicks, useAtrLabelOffset, atrOffsetMultiplier, connectorWidth, connectorOpacity, entryMarkerHalo, entryMarkerHaloOffset, earlyOpacityPercent, standardOpacityPercent, maxMfeLookaheadBars, showMaeToo, mfeBoxOpacity, maeBoxOpacity, showPointsInsideMfeBox, showDollarTablePanel, dollarInstrument, mfeMaePanelPosition, mfeMaePanelOpacity, mfeMaePanelFontSize, researchAutoOffMinutes, maxStoredSignals, clickHitboxPixels, labelHitHalfWidthPixels, showClickReadout, useTrueDelta, volumetricInstrument, useRenderTimeLabels, useLegacyDrawTextLabels, labelBaseGapPx, labelLaneStepPx, labelCornerRadius, labelPaddingX, labelPaddingY, labelOpacity, useSegmentedBadges, showTradeIcons, useEmojiIcons, useFallbackGlyphIcons, sRankIcon, eliteIcon, tickIcon, standardLongIcon, standardShortIcon, earlyIcon, maxLabelLanes, protectCandles, useCompactLabelsWhenCrowded, hideLowPriorityLabelsWhenCrowded, showGlyphOnlyMarkers, showLeaderLines, entryMarkerStyle, badgeGapPx, entryArrowLong, entryArrowShort, showContractTable, labelStyle);
		}
	}
}

#endregion
