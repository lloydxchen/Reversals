#region Using declarations
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using NinjaTrader.Cbi;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.DrawingTools;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.BarsTypes;
#endregion

// ============================================================================
// Flow42DataCapture_v0_17
// ----------------------------------------------------------------------------
// One combined Flow.42 inspection + export indicator for NinjaTrader 8. v0.17 keeps v0.8 exporter-calculated NT volumetric bid/ask delta columns and adds chart data-quality checks, dataset-first folders, readable self-describing file names with Tick/NoTick capture token, frozen elapsed timing, and a compact navy glass HUD dashboard.
//
// IMPORTANT INSTALL NOTE
//   Save this file physically here if you want it under your Exporters folder:
//      Documents\NinjaTrader 8\bin\Custom\Indicators\Exporters\Flow42DataCapture_v0_17.cs
//
//   This foldered/UI version uses namespace:
//      NinjaTrader.NinjaScript.Indicators.Exporters
//
//   That is what makes the indicator appear under the Exporters group/folder
//   in NinjaTrader's indicator selector. The enum below remains GLOBAL scope
//   so NinjaTrader's generated Strategy and MarketAnalyzerColumn partials can
//   still resolve it without CS0246 errors.
//
//   The enum below is intentionally in GLOBAL scope, outside the NT namespace.
//   This prevents CS0246 errors in NinjaTrader's generated Strategy and
//   MarketAnalyzerColumn partials.
//
// HOW TO USE
//   1) Load the Flow42 indicator(s) you want to inspect/export on a chart.
//   2) Add this indicator LAST.
//   3) Start with the default Preset = Export_FullResearch. This exports the full loaded chart history by default using the fast research feature-matrix path. Use DeepDiscovery_Safe / DeepDiscovery_PrivateFieldNamesOnly only for discovery.
//   4) Reload chart / wait for historical processing to complete.
//   5) Upload the timestamped run folder or the individual self-describing CSV files.
//
// DEFAULT OUTPUT ROOT
//   Documents\NinjaTrader 8\NinjaTrader 8 - Chart Data Exports\
//
// OUTPUT FILES
//   Flow42_Inventory.csv          = Loaded Flow42 indicators, plots, Values[], public properties, public Series.
//   Flow42_SettingsSnapshot.csv   = Public scalar/enum/string/brush-ish settings discovered on loaded Flow42 indicators.
//   Flow42_PublicMethods.csv      = Public method inventory; known safe API tests such as HasSpikeOnBar when available.
//   Flow42_PlotValues.csv         = Per-bar OHLCV + readable Flow42 plot/series/public-series values.
//   Flow42_DrawObject_Audit.csv   = Deduped raw chart draw-object scrape with inferred Flow42 family/category/direction.
//   Flow42_ReversalFeatures.csv   = Per-bar model-ready feature skeleton from exposed series + draw-object counts.
//   Flow42_LivePanelSnapshot.csv  = Optional realtime current-state snapshots, useful for VolLiqMeter/live-only panels.
//   Flow42_CaptureSummary.csv     = Counts and quality metrics.
//   Flow42_Run_README.txt         = Run notes and active settings.
// ============================================================================

// GLOBAL SCOPE ON PURPOSE. Do not move inside namespace.
public enum Flow42CapturePreset_v0_17
{
    Export_FullResearch,
    DeepDiscovery_Safe,
    DeepDiscovery_PrivateFieldNamesOnly,
    Probe_AllFlow42,
    Probe_OneIndicator,
    Probe_AutomationOutputsOnly,
    Probe_DrawObjectsOnly,
    Probe_LiveVolLiqMeter,
    Export_ReversalFeatureMatrix,
    Export_FastAllFlow42,
    Export_FullAllFlow42,
    Fast_InventoryOnly,
    Fast_AutomationOutputsOnly,
    Fast_DrawObjectsOnly,
    OneIndicator_Fast,
    Custom
}

// GLOBAL SCOPE ON PURPOSE. Used by NinjaTrader generated accessors.
public enum Flow42ExporterDeltaMode_v0_17
{
    AutoPreferNTVolumetricBidAsk,
    NTVolumetricBidAskOnly,
    Flow42VolDeltaOnly,
    Disabled
}

namespace NinjaTrader.NinjaScript.Indicators.Exporters
{
    public class Flow42DataCapture_v0_17 : Indicator
    {
        private class SeriesHandle
        {
            public string IndicatorName;
            public string IndicatorType;
            public string IndicatorFullName;
            public string SourceKind;
            public string SourceName;
            public int SourceIndex;
            public object SeriesObject;
            public string SafeColumnName;
            public string KeyBlob;
        }

        private class DrawEvent
        {
            public string RunId;
            public DateTime ExportTime;
            public string InstrumentName;
            public string BarsPeriodName;
            public DateTime AnchorTime;
            public int BarIndex;
            public DateTime BarTime;
            public double AnchorPrice;
            public string DrawType;
            public string Tag;
            public string Text;
            public string Owner;
            public string Color;
            public int PanelIndex;
            public string InferredIndicator;
            public string InferredCategory;
            public string InferredDirection;
            public string Stage;
            public string DataQuality;
            public string DedupeKey;
            public string TriggeredBy;
            public string Mode;
        }

        // File state
        private string resolvedFolder;
        private string runId;
        private string inventoryPath;
        private string settingsPath;
        private string methodsPath;
        private string plotValuesPath;
        private string drawAuditPath;
        private string reversalFeaturesPath;
        private string liveSnapshotPath;
        private string discoverySamplesPath;
        private string privateFieldNamesPath;
        private string summaryPath;
        private string readmePath;

        // Capture state
        private readonly object writeLock = new object();
        private List<SeriesHandle> seriesHandles;
        private List<DrawEvent> drawEvents;
        private HashSet<string> drawAuditDedupeKeys;
        private HashSet<string> methodTestDedupeKeys;
        private Dictionary<string, SeriesHandle> aliasHandleCache;
        private System.Windows.Threading.DispatcherTimer scanTimer;

        private bool initialized;
        private bool inventoryRequested;
        private bool inventoryWritten;
        private bool settingsWritten;
        private bool methodsWritten;
        private bool plotSnapshotWritten;
        private bool reversalFeaturesWritten;
        private bool liveHeaderWritten;
        private bool summaryWritten;
        private bool scanPending;
        private bool openedFolder;
        private bool loadCompleteScanRequested;
        private bool finalExportCompleted;
        private int barUpdateCount;
        private int plotRowsExported;
        private int drawAuditRowsExported;
        private int reversalFeatureRowsExported;
        private int liveSnapshotRowsExported;
        private int methodsRowsExported;
        private int settingsRowsExported;
        private int matchedIndicatorCount;
        private int skippedNonRelevantDraws;
        private int skippedDuplicateDraws;
        private int cappedDrawObjects;
        private int errorCount;
        private int warningCount;
        private int discoverySampleRowsExported;
        private int privateFieldNameRowsExported;
        private string exportStatus;
        private string lastStatusMessage;
        private string folderOpenStatus;

        // Compact glass HUD dashboard state.
        // This replaces the old top-left Draw.TextFixed wall of text with a small SharpDX chart overlay.
        private const string DashboardLegacyTextTag = "Flow42DataCapture_v0_17_Status";
        private DateTime dashboardStartUtc;
        private DateTime dashboardEndUtc;
        private DateTime dashboardLastRefreshUtc;
        private DateTime dashboardLastFolderClickUtc;
        private double dashboardProgressPercent;
        private double dashboardAnimatedPercent;
        private int dashboardFilesWritten;
        private long dashboardRowsCached;
        private bool dashboardLegacyTextRemoved;
        private string dashboardLastWarningShort;
        private string dashboardLastWarningFull;
        private SharpDX.RectangleF dashboardLastFolderHitRect;
        private ChartControl dashboardHookedChartControl;


        // VolDelta source-quality diagnostics
        private string volDeltaDeltaSourceSetting;
        private string volDeltaCvdModeSetting;
        private string volDeltaCvdResetModeSetting;
        private string volDeltaHistoryCacheSetting;
        private string volDeltaUseHistoryCacheFallbackSetting;
        private string volDeltaPreferCacheOnHistoricalSetting;
        private int volDeltaComparableRows;
        private int volDeltaAbsDeltaEqualsVolumeRows;
        private double volDeltaAbsDeltaEqualsVolumeRate;
        private int volDeltaBuySellComparableRows;
        private int volDeltaBuySellSumMismatchRows;
        private string volDeltaLikelyProxyWarning;
        private bool volDeltaQualityWarningRegistered;

        // Exporter-calculated NT volumetric bid/ask delta diagnostics
        private int ntVolumetricDeltaRows;
        private int ntVolumetricDeltaMissingRows;
        private int ntVolumetricComparableRows;
        private int ntVolumetricBuySellSumMismatchRows;
        private string ntVolumetricDeltaStatus;
        private string ntVolumetricDeltaWarning;
        private bool ntVolumetricQualityWarningRegistered;

        // Active preset values
        private string activeIndicatorFilter;
        private string activeDrawKeywords;
        private bool activeIncludeAllIndicators;
        private bool activeDoExposureProbe;
        private bool activeExportSettingsSnapshot;
        private bool activeExportPublicMethods;
        private bool activeExportPlotValues;
        private bool activeExportDrawAudit;
        private bool activeExportReversalFeatures;
        private bool activeExportLiveSnapshots;
        private bool activeInvokeKnownSafeMethods;
        private bool activeDeepDiscovery;
        private bool activeExportDiscoverySamples;
        private bool activeExportPrivateFieldNames;
        private int activeMaxPlotRows;
        private int activeHistoricalScanEveryNBars;
        private int activeRealtimeScanIntervalSeconds;
        private int activeMaxRawSeriesColumns;
        private int activeMaxDrawObjectsToScan;


        // Keep a short native NinjaTrader indicator label so the script is visible in the chart Indicators list,
        // without dumping the full class name and parameter list across the top-left of the chart.
        public override string DisplayName
        {
            get { return "Flow42 Exporter"; }
        }

        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Name                     = "Flow42 Exporter Full Research v0.17";
                Description              = "Flow42 full research exporter v0.17 with dataset-first folders, chart data quality checks, NT volumetric bid/ask delta, readable self-describing file names with Tick/NoTick capture token, and compact navy glass export dashboard.";
                Calculate                = Calculate.OnBarClose;
                IsOverlay                = true;
                DisplayInDataBox         = false;
                PaintPriceMarkers        = false;
                IsSuspendedWhileInactive = false;

                Preset                   = Flow42CapturePreset_v0_17.Export_FullResearch;
                ExporterDeltaMode        = Flow42ExporterDeltaMode_v0_17.AutoPreferNTVolumetricBidAsk;
                OutputRootFolder         = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"NinjaTrader 8\NinjaTrader 8 - Chart Data Exports");
                ExportParentFolderName   = "Flow42DataCapture";
                UseTimestampedRunFolder  = true;
                RebuildFilesOnLoad       = true;
                OpenFolderWhenDone       = true;
                ShowStatusDashboard      = true;
                FallbackToAllIndicatorsIfNoMatch = false;

                SingleIndicatorNameFilter = "VolDrive";
                CustomIndicatorNameFilter = "Flow42,Flow.42,VolDrive,VolDynamics,ChopState,VolImbalance,VolSpike,CloudNotes,AbsorptionMap,VolLiqMeter,VolDelta";
                CustomDrawKeywords = "Flow42,Flow.42,VolDrive,VolDynamics,Chop,Trend,Protect,Trade,Abs,Absorption,Exhaustion,Edge,Break,Spike,Imbalance,Cluster,Bid,Ask,DOM,Liq,Liquidity,Delta,CVD,Pressure,Warning,Candidate,Provisional,Confirmed,CloudNotes,Level";

                CustomIncludeAllIndicators = false;
                CustomDoExposureProbe = true;
                CustomExportSettingsSnapshot = true;
                CustomExportPublicMethods = true;
                CustomExportPlotValues = true;
                CustomExportDrawAudit = true;
                CustomExportReversalFeatures = true;
                CustomExportLiveSnapshots = false;
                CustomInvokeKnownSafeMethods = true;
                CustomDeepDiscovery = false;
                CustomExportDiscoverySamples = false;
                CustomExportPrivateFieldNames = false;
                CustomMaxPlotRows = 0;
                CustomHistoricalScanEveryNBars = 999999;
                CustomRealtimeScanIntervalSeconds = 0;
                CustomMaxRawSeriesColumns = 60;
                CustomMaxDrawObjectsToScan = 5000;

                VerbosePrint = true;
            }
            else if (State == State.DataLoaded)
            {
                try
                {
                    ApplyPreset();

                    seriesHandles = new List<SeriesHandle>();
                    drawEvents = new List<DrawEvent>();
                    drawAuditDedupeKeys = new HashSet<string>();
                    methodTestDedupeKeys = new HashSet<string>();
                    aliasHandleCache = new Dictionary<string, SeriesHandle>();

                    initialized = false;
                    inventoryRequested = false;
                    inventoryWritten = false;
                    settingsWritten = false;
                    methodsWritten = false;
                    plotSnapshotWritten = false;
                    reversalFeaturesWritten = false;
                    liveHeaderWritten = false;
                    summaryWritten = false;
                    scanPending = false;
                    openedFolder = false;
                    loadCompleteScanRequested = false;
                    finalExportCompleted = false;
                    barUpdateCount = 0;
                    plotRowsExported = 0;
                    drawAuditRowsExported = 0;
                    reversalFeatureRowsExported = 0;
                    liveSnapshotRowsExported = 0;
                    methodsRowsExported = 0;
                    settingsRowsExported = 0;
                    matchedIndicatorCount = 0;
                    skippedNonRelevantDraws = 0;
                    skippedDuplicateDraws = 0;
                    cappedDrawObjects = 0;
                    errorCount = 0;
                    warningCount = 0;
                    discoverySampleRowsExported = 0;
                    privateFieldNameRowsExported = 0;
                    exportStatus = "Initializing";
                    lastStatusMessage = "Preparing Flow42 export.";
                    folderOpenStatus = "Not opened yet";
                    dashboardStartUtc = DateTime.UtcNow;
                    dashboardEndUtc = DateTime.MinValue;
                    dashboardLastRefreshUtc = DateTime.MinValue;
                    dashboardLastFolderClickUtc = DateTime.MinValue;
                    dashboardProgressPercent = 0;
                    dashboardAnimatedPercent = 0;
                    dashboardFilesWritten = 0;
                    dashboardRowsCached = 0;
                    dashboardLegacyTextRemoved = false;
                    dashboardLastWarningShort = "";
                    dashboardLastWarningFull = "";
                    dashboardLastFolderHitRect = new SharpDX.RectangleF();
                    volDeltaDeltaSourceSetting = "";
                    volDeltaCvdModeSetting = "";
                    volDeltaCvdResetModeSetting = "";
                    volDeltaHistoryCacheSetting = "";
                    volDeltaUseHistoryCacheFallbackSetting = "";
                    volDeltaPreferCacheOnHistoricalSetting = "";
                    volDeltaComparableRows = 0;
                    volDeltaAbsDeltaEqualsVolumeRows = 0;
                    volDeltaAbsDeltaEqualsVolumeRate = 0;
                    volDeltaBuySellComparableRows = 0;
                    volDeltaBuySellSumMismatchRows = 0;
                    volDeltaLikelyProxyWarning = "";
                    volDeltaQualityWarningRegistered = false;
                    ntVolumetricDeltaRows = 0;
                    ntVolumetricDeltaMissingRows = 0;
                    ntVolumetricComparableRows = 0;
                    ntVolumetricBuySellSumMismatchRows = 0;
                    ntVolumetricDeltaStatus = "Not checked";
                    ntVolumetricDeltaWarning = "";
                    ntVolumetricQualityWarningRegistered = false;

                    resolvedFolder = ResolveRunFolder(OutputRootFolder);
                    Directory.CreateDirectory(resolvedFolder);
                    runId = Path.GetFileName(resolvedFolder);

                    string fileBase = BuildFileBaseName();

                    inventoryPath         = Path.Combine(resolvedFolder, fileBase + "_Flow42_Inventory.csv");
                    settingsPath          = Path.Combine(resolvedFolder, fileBase + "_Flow42_SettingsSnapshot.csv");
                    methodsPath           = Path.Combine(resolvedFolder, fileBase + "_Flow42_PublicMethods.csv");
                    plotValuesPath        = Path.Combine(resolvedFolder, fileBase + "_Flow42_PlotValues.csv");
                    drawAuditPath         = Path.Combine(resolvedFolder, fileBase + "_Flow42_DrawObject_Audit.csv");
                    reversalFeaturesPath  = Path.Combine(resolvedFolder, fileBase + "_Flow42_ReversalFeatures.csv");
                    liveSnapshotPath      = Path.Combine(resolvedFolder, fileBase + "_Flow42_LivePanelSnapshot.csv");
                    discoverySamplesPath  = Path.Combine(resolvedFolder, fileBase + "_Flow42_DiscoverySamples.csv");
                    privateFieldNamesPath = Path.Combine(resolvedFolder, fileBase + "_Flow42_PrivateFieldNames.csv");
                    summaryPath           = Path.Combine(resolvedFolder, fileBase + "_Flow42_CaptureSummary.csv");
                    readmePath            = Path.Combine(resolvedFolder, fileBase + "_Flow42_Run_README.txt");

                    if (RebuildFilesOnLoad)
                    {
                        SafeDelete(inventoryPath);
                        SafeDelete(settingsPath);
                        SafeDelete(methodsPath);
                        SafeDelete(plotValuesPath);
                        SafeDelete(drawAuditPath);
                        SafeDelete(reversalFeaturesPath);
                        SafeDelete(liveSnapshotPath);
                        SafeDelete(discoverySamplesPath);
                        SafeDelete(privateFieldNamesPath);
                        SafeDelete(summaryPath);
                        SafeDelete(readmePath);
                    }

                    EnsureBaseHeaders();
                    WriteReadme();
                    initialized = true;
                    SetStatus("Idle", "Loaded. Waiting for first eligible bar to run export.");

                    Print("[Flow42DataCapture] Loaded.");
                    Print("[Flow42DataCapture] Preset: " + Preset);
                    Print("[Flow42DataCapture] Output folder: " + resolvedFolder);
                    Print("[Flow42DataCapture] Add this indicator LAST on a chart where Flow42 indicators are already loaded.");
                }
                catch (Exception ex)
                {
                    RecordError("[Flow42DataCapture] DataLoaded init error: " + ex);
                }
            }
            else if (State == State.Realtime)
            {
                if (ChartControl != null)
                {
                    ChartControl.Dispatcher.InvokeAsync(() =>
                    {
                        try
                        {
                            if (!loadCompleteScanRequested)
                            {
                                loadCompleteScanRequested = true;
                                RequestDrawScan("LOAD_COMPLETE_SCAN", true);
                            }

                            if (activeRealtimeScanIntervalSeconds > 0)
                            {
                                scanTimer = new System.Windows.Threading.DispatcherTimer
                                {
                                    Interval = TimeSpan.FromSeconds(Math.Max(1, activeRealtimeScanIntervalSeconds))
                                };
                                scanTimer.Tick += (s, e) =>
                                {
                                    RequestDrawScan("TIMER_RT", true);
                                    if (activeExportLiveSnapshots)
                                        WriteLiveSnapshot("TIMER_RT");
                                };
                                scanTimer.Start();
                            }
                        }
                        catch (Exception ex)
                        {
                            RecordError("[Flow42DataCapture] Realtime init error: " + ex.Message);
                        }
                    });
                }
            }
            else if (State == State.Terminated)
            {
                RemoveDashboardMouseHook();

                if (scanTimer != null)
                {
                    try { scanTimer.Stop(); } catch { }
                    scanTimer = null;
                }

                try
                {
                    FinalizeSnapshots("TERMINATED");
                }
                catch (Exception ex)
                {
                    RecordError("[Flow42DataCapture] Final write error: " + ex.Message);
                }

                if (VerbosePrint)
                {
                    Print("[Flow42DataCapture] Terminated.");
                    Print("[Flow42DataCapture] Output folder: " + resolvedFolder);
                    Print("[Flow42DataCapture] Matched indicators: " + matchedIndicatorCount);
                    Print("[Flow42DataCapture] Readable series handles: " + (seriesHandles == null ? 0 : seriesHandles.Count));
                    Print("[Flow42DataCapture] Plot rows: " + plotRowsExported);
                    Print("[Flow42DataCapture] Draw audit rows: " + drawAuditRowsExported);
                    Print("[Flow42DataCapture] Reversal feature rows: " + reversalFeatureRowsExported);
                    Print("[Flow42DataCapture] Live snapshot rows: " + liveSnapshotRowsExported);
                }
            }
        }

        protected override void OnBarUpdate()
        {
            if (!initialized)
                return;

            if (BarsInProgress != 0)
                return;

            if (CurrentBar < 5)
                return;

            barUpdateCount++;

            if (barUpdateCount == 1 || barUpdateCount % 250 == 0)
                UpdateDashboardSafe();

            if (ChartControl == null)
            {
                if (CurrentBar == 5)
                    Print("[Flow42DataCapture] ChartControl is null. Run this on a chart, not Strategy Analyzer.");
                return;
            }

            if (activeDoExposureProbe && !inventoryWritten && !inventoryRequested)
            {
                inventoryRequested = true;

                ChartControl.Dispatcher.InvokeAsync(() =>
                {
                    try
                    {
                        SetStatus("Exporting", "Building Flow42 inventory/settings/method discovery.");
                        BuildInventorySettingsMethods(false);

                        if (seriesHandles.Count == 0 && FallbackToAllIndicatorsIfNoMatch && !activeIncludeAllIndicators)
                        {
                            AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), "", "", "", "", "FALLBACK", "", "No Flow42 series found", "", "", "Retrying all chart indicators except this exporter."));
                            BuildInventorySettingsMethods(true);
                        }

                        DeduplicateSeriesHandles();
                        inventoryWritten = true;

                        Print("[Flow42DataCapture] Inventory/settings/methods written.");
                        Print("[Flow42DataCapture] Matched indicators: " + matchedIndicatorCount);
                        Print("[Flow42DataCapture] Readable plot/series handles found: " + seriesHandles.Count);

                        if (activeExportPlotValues)
                            WritePlotValuesSnapshot("INVENTORY_COMPLETE");

                        if (activeExportDiscoverySamples)
                            WriteDiscoverySamplesSnapshot("INVENTORY_COMPLETE");

                        if (activeExportLiveSnapshots)
                            WriteLiveSnapshot("INVENTORY_COMPLETE");

                        if (!NeedsPostInventoryScanOrSnapshotPass())
                            FinalizeSnapshots("INVENTORY_COMPLETE");
                        else
                        {
                            WriteSummary();
                            UpdateDashboardSafe();
                        }
                    }
                    catch (Exception ex)
                    {
                        RecordError("[Flow42DataCapture] Inventory error: " + ex);
                    }
                });
            }

            bool finalHistoricalBar = false;
            try { finalHistoricalBar = (State == State.Historical && Bars != null && CurrentBar >= Bars.Count - 3); }
            catch { finalHistoricalBar = false; }

            bool shouldDrawScan;
            if (State == State.Historical)
            {
                int n = Math.Max(1, activeHistoricalScanEveryNBars);
                shouldDrawScan = barUpdateCount == 1 || CurrentBar % n == 0 || finalHistoricalBar;
            }
            else
            {
                shouldDrawScan = true;
            }

            if ((activeExportDrawAudit || activeExportReversalFeatures || activeExportLiveSnapshots) && shouldDrawScan)
                RequestDrawScan(finalHistoricalBar ? "BAR_HIST_FINAL" : (State == State.Realtime ? "BAR_RT" : "BAR_HIST"), finalHistoricalBar);
        }

        // --------------------------------------------------------------------
        // Presets
        // --------------------------------------------------------------------
        private void ApplyPreset()
        {
            activeIndicatorFilter = CustomIndicatorNameFilter;
            activeDrawKeywords = CustomDrawKeywords;
            activeIncludeAllIndicators = CustomIncludeAllIndicators;
            activeDoExposureProbe = CustomDoExposureProbe;
            activeExportSettingsSnapshot = CustomExportSettingsSnapshot;
            activeExportPublicMethods = CustomExportPublicMethods;
            activeExportPlotValues = CustomExportPlotValues;
            activeExportDrawAudit = CustomExportDrawAudit;
            activeExportReversalFeatures = CustomExportReversalFeatures;
            activeExportLiveSnapshots = CustomExportLiveSnapshots;
            activeInvokeKnownSafeMethods = CustomInvokeKnownSafeMethods;
            activeDeepDiscovery = CustomDeepDiscovery;
            activeExportDiscoverySamples = CustomExportDiscoverySamples;
            activeExportPrivateFieldNames = CustomExportPrivateFieldNames;
            activeMaxPlotRows = CustomMaxPlotRows;
            activeHistoricalScanEveryNBars = CustomHistoricalScanEveryNBars;
            activeRealtimeScanIntervalSeconds = CustomRealtimeScanIntervalSeconds;
            activeMaxRawSeriesColumns = CustomMaxRawSeriesColumns;
            activeMaxDrawObjectsToScan = CustomMaxDrawObjectsToScan;

            if (Preset != Flow42CapturePreset_v0_17.Custom)
            {
                activeDeepDiscovery = false;
                activeExportDiscoverySamples = false;
                activeExportPrivateFieldNames = false;
            }

            if (Preset == Flow42CapturePreset_v0_17.DeepDiscovery_Safe)
            {
                // Safe exhaustive surface discovery: inventory every public Flow42 surface and sample series values without full raw matrices.
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = false;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = false;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = true;
                activeDeepDiscovery = true;
                activeExportDiscoverySamples = true;
                activeExportPrivateFieldNames = false;
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 3000;
            }
            else if (Preset == Flow42CapturePreset_v0_17.DeepDiscovery_PrivateFieldNamesOnly)
            {
                // Metadata-only private/non-public field scan. Does NOT read private values.
                // Purpose: reveal possible hidden calculation names/types without heavy or risky extraction.
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = "";
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = false;
                activeExportPublicMethods = false;
                activeExportPlotValues = false;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = false;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeDeepDiscovery = false;
                activeExportDiscoverySamples = false;
                activeExportPrivateFieldNames = true;
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Probe_AllFlow42)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = true;
                activeMaxPlotRows = 10000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Probe_OneIndicator)
            {
                activeIndicatorFilter = SingleIndicatorNameFilter;
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = true;
                activeMaxPlotRows = 10000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Probe_AutomationOutputsOnly)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = "";
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = true;
                activeMaxPlotRows = 20000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Probe_DrawObjectsOnly)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = false;
                activeExportSettingsSnapshot = false;
                activeExportPublicMethods = false;
                activeExportPlotValues = false;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Probe_LiveVolLiqMeter)
            {
                activeIndicatorFilter = "Flow42,Flow.42,VolLiqMeter,LiqMeter,Liquidity,DOM";
                activeDrawKeywords = "VolLiqMeter,LiqMeter,Liquidity,DOM,Bid,Ask,Aggressor,Buy,Sell,Imbalance,Depth,Book";
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = true;
                activeInvokeKnownSafeMethods = true;
                activeMaxPlotRows = 2000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 2;
            }

            else if (Preset == Flow42CapturePreset_v0_17.Export_FullResearch)
            {
                // Default full research export.
                // Purpose: export the full loaded chart history into the model-ready reversal feature matrix
                // without raw diagnostic bloat. Use this for normal research / ML export runs.
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = false;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeDeepDiscovery = false;
                activeExportDiscoverySamples = false;
                activeExportPrivateFieldNames = false;
                activeMaxPlotRows = 0; // 0 = no row cap; export all loaded bars.
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 5000;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Export_FastAllFlow42)
            {
                // Low-lag full-history research export: captures inventory/settings/methods plus model-ready reversal features.
                // It still scans draw objects for feature counts, but skips huge raw plot and raw draw-audit files.
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = false;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                // v0.17: no row cap for the fast feature export. This preset skips raw/heavy files,
                // so it should export the full loaded chart history by default.
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 5000;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Export_FullAllFlow42)
            {
                // Heavy legacy-style full export. Use only with small date ranges or after fast export proves stable.
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = true;
                activeMaxPlotRows = 50000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 120;
                activeMaxDrawObjectsToScan = 20000;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Fast_InventoryOnly)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = "";
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = false;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = false;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Fast_AutomationOutputsOnly)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = "";
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = false;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeMaxPlotRows = 10000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 60;
                activeMaxDrawObjectsToScan = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Fast_DrawObjectsOnly)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = false;
                activeExportSettingsSnapshot = false;
                activeExportPublicMethods = false;
                activeExportPlotValues = false;
                activeExportDrawAudit = true;
                activeExportReversalFeatures = false;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 5000;
            }
            else if (Preset == Flow42CapturePreset_v0_17.OneIndicator_Fast)
            {
                activeIndicatorFilter = SingleIndicatorNameFilter;
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = true;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = false;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                activeMaxPlotRows = 10000;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 80;
                activeMaxDrawObjectsToScan = 0;
            }
            else if (Preset == Flow42CapturePreset_v0_17.Export_ReversalFeatureMatrix)
            {
                activeIndicatorFilter = DefaultFlow42IndicatorFilter();
                activeDrawKeywords = DefaultFlow42DrawKeywords();
                activeIncludeAllIndicators = false;
                activeDoExposureProbe = true;
                activeExportSettingsSnapshot = true;
                activeExportPublicMethods = true;
                activeExportPlotValues = false;
                activeExportDrawAudit = false;
                activeExportReversalFeatures = true;
                activeExportLiveSnapshots = false;
                activeInvokeKnownSafeMethods = false;
                // v0.17: no row cap for the reversal feature matrix export.
                activeMaxPlotRows = 0;
                activeHistoricalScanEveryNBars = 999999;
                activeRealtimeScanIntervalSeconds = 0;
                activeMaxRawSeriesColumns = 0;
                activeMaxDrawObjectsToScan = 5000;
            }
            // Custom leaves custom settings.
        }

        private string DefaultFlow42IndicatorFilter()
        {
            return "Flow42,Flow.42,VolDrive,VolDynamics,ChopState,VolImbalance,VolSpike,CloudNotes,AbsorptionMap,VolLiqMeter,VolDelta";
        }

        private string DefaultFlow42DrawKeywords()
        {
            return "Flow42,Flow.42,VolDrive,VolDynamics,Chop,Trend,Protect,Trade,Abs,Absorption,Exhaustion,Edge,Break,Spike,Imbalance,Cluster,Bid,Ask,DOM,Liq,Liquidity,Delta,CVD,Pressure,Warning,Candidate,Provisional,Confirmed,CloudNotes,Level";
        }

        // --------------------------------------------------------------------
        // Inventory, settings, methods
        // --------------------------------------------------------------------
        private void BuildInventorySettingsMethods(bool forceAllIndicators)
        {
            IList<object> indicators = GetLoadedChartIndicators();

            if (indicators == null || indicators.Count == 0)
            {
                AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), "", "", "", "", "ERROR", "", "No indicators found", "", "", "Could not find loaded chart indicators."));
                return;
            }

            int index = 0;
            int matchedThisPass = 0;

            foreach (object ind in indicators)
            {
                index++;
                if (ind == null || object.ReferenceEquals(ind, this))
                    continue;

                string typeName = ind.GetType().Name;
                string typeFull = ind.GetType().FullName ?? "";
                string toString = SafeToString(ind);
                string blob = typeName + " " + typeFull + " " + toString;

                bool include = forceAllIndicators || activeIncludeAllIndicators || MatchesAnyFilter(blob, activeIndicatorFilter);
                if (!include)
                    continue;

                matchedThisPass++;
                matchedIndicatorCount++;

                AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), index, typeName, typeFull, toString, "INDICATOR", "", typeName, typeFull, "", forceAllIndicators ? "Fallback/all-chart scan" : "Matched preset filter"));

                CaptureKnownScalarSettingsForDiagnostics(ind, typeName);
                InspectPlotsAndValues(ind, index, typeName, typeFull, toString);
                InspectPublicProperties(ind, index, typeName, typeFull, toString);
                if (activeDeepDiscovery)
                    InspectPublicFields(ind, index, typeName, typeFull, toString);

                if (activeExportPrivateFieldNames)
                    InspectPrivateFieldNamesOnly(ind, index, typeName, typeFull, toString);

                if (activeExportSettingsSnapshot && !settingsWritten)
                    InspectSettingsSnapshot(ind, index, typeName, typeFull, toString);

                if (activeExportPublicMethods && !methodsWritten)
                    InspectPublicMethods(ind, index, typeName, typeFull, toString);
            }

            AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), "", "", "", "", "SUMMARY", "", "MatchedIndicatorsThisPass", "", matchedThisPass, "Total chart indicators scanned=" + indicators.Count));
            settingsWritten = activeExportSettingsSnapshot;
            methodsWritten = activeExportPublicMethods;
        }

        private IList<object> GetLoadedChartIndicators()
        {
            var results = new List<object>();
            var seen = new HashSet<object>();

            TryCollectIndicatorsFromProperty(ChartControl, "Indicators", results, seen);

            if (results.Count == 0)
            {
                try
                {
                    PropertyInfo[] props = ChartControl.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (PropertyInfo p in props)
                    {
                        if (p == null || !p.CanRead || p.GetIndexParameters().Length > 0)
                            continue;

                        if (!typeof(IEnumerable).IsAssignableFrom(p.PropertyType) || p.PropertyType == typeof(string))
                            continue;

                        object val = null;
                        try { val = p.GetValue(ChartControl, null); }
                        catch { continue; }

                        IEnumerable en = val as IEnumerable;
                        if (en == null)
                            continue;

                        foreach (object item in en)
                        {
                            if (IsIndicatorLike(item) && !seen.Contains(item))
                            {
                                seen.Add(item);
                                results.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Print("[Flow42DataCapture] ChartControl indicator scan error: " + ex.Message);
                }
            }

            return results;
        }

        private void TryCollectIndicatorsFromProperty(object obj, string propName, List<object> results, HashSet<object> seen)
        {
            try
            {
                if (obj == null)
                    return;

                PropertyInfo p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (p == null || !p.CanRead || p.GetIndexParameters().Length > 0)
                    return;

                object val = p.GetValue(obj, null);
                IEnumerable en = val as IEnumerable;
                if (en == null)
                    return;

                foreach (object item in en)
                {
                    if (IsIndicatorLike(item) && !seen.Contains(item))
                    {
                        seen.Add(item);
                        results.Add(item);
                    }
                }
            }
            catch { }
        }

        private bool IsIndicatorLike(object item)
        {
            if (item == null)
                return false;

            if (object.ReferenceEquals(item, this))
                return false;

            Type t = item.GetType();
            string full = t.FullName ?? "";
            string name = t.Name ?? "";

            if (item is Indicator)
                return true;

            if (full.IndexOf("NinjaTrader.NinjaScript.Indicators", StringComparison.OrdinalIgnoreCase) >= 0)
                return true;

            if (name.IndexOf("Flow", StringComparison.OrdinalIgnoreCase) >= 0 ||
                name.IndexOf("Vol", StringComparison.OrdinalIgnoreCase) >= 0 ||
                name.IndexOf("Chop", StringComparison.OrdinalIgnoreCase) >= 0 ||
                name.IndexOf("Absorption", StringComparison.OrdinalIgnoreCase) >= 0 ||
                name.IndexOf("CloudNotes", StringComparison.OrdinalIgnoreCase) >= 0)
                return true;

            return false;
        }

        private void InspectPlotsAndValues(object ind, int indicatorIndex, string typeName, string typeFull, string toString)
        {
            try
            {
                var plotNames = new List<string>();

                object plotsObj = SafeGetPropertyValue(ind, "Plots");
                IEnumerable plots = plotsObj as IEnumerable;

                if (plots != null)
                {
                    int pIndex = 0;
                    foreach (object plot in plots)
                    {
                        string pName = SafeGetStringProperty(plot, "Name");
                        if (string.IsNullOrEmpty(pName))
                            pName = "Plot_" + pIndex;

                        plotNames.Add(pName);

                        AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "PLOT", pIndex, pName, SafeTypeName(plot), "", ""));
                        pIndex++;
                    }
                }
                else
                {
                    AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "PLOT_INFO", "", "No Plots enumerable found", "", "", ""));
                }

                object valuesObj = SafeGetPropertyValue(ind, "Values");
                IEnumerable values = valuesObj as IEnumerable;

                if (values != null)
                {
                    int vIndex = 0;
                    foreach (object series in values)
                    {
                        string sName = vIndex < plotNames.Count ? plotNames[vIndex] : "Value_" + vIndex;
                        string currentVal = ReadSeriesCurrentAsString(series);

                        AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "VALUES_SERIES", vIndex, sName, SafeTypeName(series), currentVal, "From Values[]"));

                        if (CanReadAsSeries(series))
                        {
                            seriesHandles.Add(new SeriesHandle
                            {
                                IndicatorName = toString,
                                IndicatorType = typeName,
                                IndicatorFullName = typeFull,
                                SourceKind = "Values",
                                SourceName = sName,
                                SourceIndex = vIndex,
                                SeriesObject = series,
                                SafeColumnName = MakeSafeName(typeName + "__Values" + vIndex + "__" + sName),
                                KeyBlob = MakeSearchBlob(typeName, typeFull, toString, "Values", sName)
                            });
                        }
                        vIndex++;
                    }
                }
                else
                {
                    AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "VALUES_INFO", "", "No Values enumerable found", "", "", ""));
                }
            }
            catch (Exception ex)
            {
                AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "ERROR", "", "InspectPlotsAndValues", "", "", ex.Message));
            }
        }

        private void InspectPublicProperties(object ind, int indicatorIndex, string typeName, string typeFull, string toString)
        {
            try
            {
                PropertyInfo[] props = ind.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in props)
                {
                    if (prop == null || !prop.CanRead || prop.GetIndexParameters().Length > 0)
                        continue;

                    string propName = prop.Name;
                    if (propName == "Plots" || propName == "Values" || propName == "ChartControl" || propName == "ChartBars" || propName == "BarsArray")
                        continue;

                    Type t = prop.PropertyType;
                    string kind = ClassifyPropertyKind(t);
                    string currentVal = "";
                    string notes = "";

                    object val = null;
                    bool gotValue = false;
                    try
                    {
                        val = prop.GetValue(ind, null);
                        gotValue = true;
                    }
                    catch (Exception ex)
                    {
                        notes = "GetValue failed: " + ex.Message;
                    }

                    if (gotValue && val != null)
                    {
                        if (CanReadAsSeries(val))
                        {
                            currentVal = ReadSeriesCurrentAsString(val);
                            notes = "Series-like public property";
                            seriesHandles.Add(new SeriesHandle
                            {
                                IndicatorName = toString,
                                IndicatorType = typeName,
                                IndicatorFullName = typeFull,
                                SourceKind = "PublicProperty",
                                SourceName = propName,
                                SourceIndex = -1,
                                SeriesObject = val,
                                SafeColumnName = MakeSafeName(typeName + "__Prop__" + propName),
                                KeyBlob = MakeSearchBlob(typeName, typeFull, toString, "PublicProperty", propName)
                            });
                        }
                        else if (IsSimpleReportableType(t) || t.IsEnum)
                        {
                            currentVal = SafeToString(val);
                        }
                        else if (val is Brush || val.GetType().Name.IndexOf("Stroke", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            currentVal = SafeToString(val);
                        }
                        else if (val is IEnumerable && !(val is string))
                        {
                            currentVal = "Enumerable";
                        }
                    }

                    bool likelyUseful =
                        kind == "Scalar" || kind == "Enum" || kind == "SeriesLike" ||
                        ContainsAny(propName, "Delta,CVD,Pressure,Abs,Absorption,Div,Divergence,Signal,Imb,Imbalance,Buy,Sell,Bid,Ask,Plot,Spike,Surge,Push,Exhaust,Chop,Trend,Regime,Liq,Liquidity,DOM,Cluster,Stage,Score,Ratio,ZScore");

                    if (likelyUseful || activeDeepDiscovery)
                    {
                        AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "PUBLIC_PROPERTY_" + kind, "", propName, t.FullName, currentVal, notes));
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "ERROR", "", "InspectPublicProperties", "", "", ex.Message));
            }
        }

        private void InspectPublicFields(object ind, int indicatorIndex, string typeName, string typeFull, string toString)
        {
            try
            {
                FieldInfo[] fields = ind.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                foreach (FieldInfo field in fields)
                {
                    if (field == null)
                        continue;

                    string fieldName = field.Name;
                    Type t = field.FieldType;
                    string kind = ClassifyPropertyKind(t);
                    string currentVal = "";
                    string notes = "Public field discovered in DeepDiscovery_Safe.";

                    object val = null;
                    bool gotValue = false;
                    try
                    {
                        val = field.GetValue(ind);
                        gotValue = true;
                    }
                    catch (Exception ex)
                    {
                        notes = "GetValue failed: " + ex.Message;
                    }

                    if (gotValue && val != null)
                    {
                        if (CanReadAsSeries(val))
                        {
                            currentVal = ReadSeriesCurrentAsString(val);
                            notes = "Series-like public field";
                            seriesHandles.Add(new SeriesHandle
                            {
                                IndicatorName = toString,
                                IndicatorType = typeName,
                                IndicatorFullName = typeFull,
                                SourceKind = "PublicField",
                                SourceName = fieldName,
                                SourceIndex = -1,
                                SeriesObject = val,
                                SafeColumnName = MakeSafeName(typeName + "__Field__" + fieldName),
                                KeyBlob = MakeSearchBlob(typeName, typeFull, toString, "PublicField", fieldName)
                            });
                        }
                        else if (IsSimpleReportableType(t) || t.IsEnum || val is Brush || val.GetType().Name.IndexOf("Stroke", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            currentVal = SafeToString(val);
                        }
                        else if (val is IEnumerable && !(val is string))
                        {
                            currentVal = "Enumerable";
                        }
                    }

                    AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "PUBLIC_FIELD_" + kind, "", fieldName, t.FullName, currentVal, notes));
                }
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] InspectPublicFields error: " + ex.Message);
                AppendLine(inventoryPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "ERROR", "", "InspectPublicFields", "", "", ex.Message));
            }
        }

        private void InspectPrivateFieldNamesOnly(object ind, int indicatorIndex, string typeName, string typeFull, string toString)
        {
            try
            {
                Type indicatorType = ind == null ? null : ind.GetType();
                if (indicatorType == null)
                    return;

                FieldInfo[] fields = indicatorType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);

                foreach (FieldInfo field in fields)
                {
                    if (field == null)
                        continue;

                    string fieldName = field.Name ?? "";
                    Type fieldType = field.FieldType;
                    string fieldTypeName = fieldType == null ? "" : (fieldType.FullName ?? fieldType.Name);
                    string declaringType = field.DeclaringType == null ? "" : (field.DeclaringType.FullName ?? field.DeclaringType.Name);
                    string searchBlob = fieldName + " " + fieldTypeName;
                    string relevanceHint = PrivateFieldRelevanceHint(searchBlob);
                    bool likelyRelevant = !string.IsNullOrEmpty(relevanceHint);

                    AppendLine(privateFieldNamesPath, Csv(
                        DateTime.Now,
                        SafeInstrument(),
                        SafeBarsPeriod(),
                        indicatorIndex,
                        typeName,
                        typeFull,
                        toString,
                        declaringType,
                        fieldName,
                        fieldTypeName,
                        field.IsStatic ? "1" : "0",
                        field.IsInitOnly ? "1" : "0",
                        field.IsLiteral ? "1" : "0",
                        field.Attributes.ToString(),
                        likelyRelevant ? "1" : "0",
                        relevanceHint,
                        "Name/type only. Private value intentionally not read."));

                    privateFieldNameRowsExported++;
                }
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] InspectPrivateFieldNamesOnly error: " + ex.Message);
                AppendLine(privateFieldNamesPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "", "ERROR", "", "", "", "", "", "", "", ex.Message));
            }
        }

        private string PrivateFieldRelevanceHint(string blob)
        {
            if (string.IsNullOrEmpty(blob))
                return "";

            var hints = new List<string>();
            if (ContainsAny(blob, "Abs,Absorption,Absorb")) hints.Add("absorption");
            if (ContainsAny(blob, "Exhaust,Exhaustion")) hints.Add("exhaustion");
            if (ContainsAny(blob, "Imb,Imbalance,Cluster,Zone")) hints.Add("imbalance/cluster/zone");
            if (ContainsAny(blob, "Delta,CVD,Pressure")) hints.Add("delta/pressure");
            if (ContainsAny(blob, "Signal,Marker,Arrow,Event,Stage,State")) hints.Add("signal/marker/state");
            if (ContainsAny(blob, "Bid,Ask,Buy,Sell,Aggressor")) hints.Add("bid/ask/aggression");
            if (ContainsAny(blob, "Liq,Liquidity,DOM,Depth,Book")) hints.Add("liquidity/DOM");
            if (ContainsAny(blob, "Spike,Surge,Push,Volume,Vol")) hints.Add("volume/spike/push");
            if (ContainsAny(blob, "Chop,Regime,Trend,Score,Ratio")) hints.Add("regime/score/ratio");
            if (ContainsAny(blob, "Cache,History,Historical,Store,Buffer,List,Dictionary,Queue")) hints.Add("cache/collection");

            if (hints.Count == 0)
                return "";
            return string.Join(";", hints.Distinct().ToArray());
        }

        private void InspectSettingsSnapshot(object ind, int indicatorIndex, string typeName, string typeFull, string toString)
        {
            try
            {
                PropertyInfo[] props = ind.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    if (prop == null || !prop.CanRead || prop.GetIndexParameters().Length > 0)
                        continue;

                    string propName = prop.Name;
                    if (propName == "Plots" || propName == "Values" || propName == "ChartControl" || propName == "ChartBars" || propName == "BarsArray")
                        continue;

                    Type t = prop.PropertyType;
                    bool report = IsSimpleReportableType(t) || t.IsEnum || typeof(Brush).IsAssignableFrom(t) || t.Name.IndexOf("Stroke", StringComparison.OrdinalIgnoreCase) >= 0;
                    if (!report)
                        continue;

                    string val = "";
                    string err = "";
                    try
                    {
                        object obj = prop.GetValue(ind, null);
                        val = SafeToString(obj);
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                    }

                    AppendLine(settingsPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, propName, t.FullName, val, err));
                    settingsRowsExported++;
                }
            }
            catch (Exception ex)
            {
                AppendLine(settingsPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "ERROR", "", "", ex.Message));
            }
        }

        private void InspectPublicMethods(object ind, int indicatorIndex, string typeName, string typeFull, string toString)
        {
            try
            {
                MethodInfo[] methods = ind.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (MethodInfo m in methods)
                {
                    if (m == null || m.IsSpecialName)
                        continue;
                    if (m.DeclaringType == typeof(object))
                        continue;

                    string methodName = m.Name;
                    if (methodName == "Equals" || methodName == "GetHashCode" || methodName == "GetType" || methodName == "ToString")
                        continue;

                    ParameterInfo[] pars = m.GetParameters();
                    string sig = string.Join(";", pars.Select(p => p.ParameterType.Name + " " + p.Name).ToArray());
                    string knownSafe = IsKnownSafeMethod(methodName, m) ? "1" : "0";
                    string test0 = "";
                    string test1 = "";
                    string notes = "";

                    if (activeInvokeKnownSafeMethods && knownSafe == "1")
                    {
                        string key = typeFull + "|" + methodName + "|" + sig;
                        if (!methodTestDedupeKeys.Contains(key))
                        {
                            methodTestDedupeKeys.Add(key);
                            TryInvokeKnownSafeMethod(ind, m, out test0, out test1, out notes);
                        }
                    }

                    AppendLine(methodsPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, methodName, m.ReturnType.FullName, sig, knownSafe, test0, test1, notes));
                    methodsRowsExported++;
                }
            }
            catch (Exception ex)
            {
                AppendLine(methodsPath, Csv(DateTime.Now, SafeInstrument(), SafeBarsPeriod(), indicatorIndex, typeName, typeFull, toString, "ERROR", "", "", "", "", "", ex.Message));
            }
        }

        private bool IsKnownSafeMethod(string methodName, MethodInfo m)
        {
            if (string.IsNullOrEmpty(methodName) || m == null)
                return false;

            ParameterInfo[] pars = m.GetParameters();
            if (pars.Length == 1 && pars[0].ParameterType == typeof(int) && m.ReturnType == typeof(bool))
            {
                if (methodName.Equals("HasSpikeOnBar", StringComparison.OrdinalIgnoreCase))
                    return true;
                if (methodName.Equals("IsSpikeOnBar", StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private void TryInvokeKnownSafeMethod(object ind, MethodInfo m, out string test0, out string test1, out string notes)
        {
            test0 = "";
            test1 = "";
            notes = "";
            try
            {
                object v0 = m.Invoke(ind, new object[] { 0 });
                test0 = SafeToString(v0);
            }
            catch (Exception ex)
            {
                notes = "barsAgo0 error: " + ex.Message;
            }

            try
            {
                object v1 = m.Invoke(ind, new object[] { 1 });
                test1 = SafeToString(v1);
            }
            catch (Exception ex)
            {
                notes = string.IsNullOrEmpty(notes) ? "barsAgo1 error: " + ex.Message : notes + " | barsAgo1 error: " + ex.Message;
            }
        }

        private void DeduplicateSeriesHandles()
        {
            var seen = new HashSet<string>();
            var clean = new List<SeriesHandle>();

            foreach (var h in seriesHandles)
            {
                if (h == null)
                    continue;

                string key = h.SafeColumnName;
                if (string.IsNullOrEmpty(key))
                    key = "Series";

                if (seen.Contains(key))
                {
                    int suffix = 2;
                    string baseName = key;
                    while (seen.Contains(baseName + "_" + suffix))
                        suffix++;
                    h.SafeColumnName = baseName + "_" + suffix;
                }

                seen.Add(h.SafeColumnName);
                clean.Add(h);
            }

            seriesHandles = clean;
            aliasHandleCache = new Dictionary<string, SeriesHandle>();
        }

        private List<SeriesHandle> RawSeriesHandlesForExport()
        {
            if (seriesHandles == null || seriesHandles.Count == 0)
                return new List<SeriesHandle>();

            if (activeMaxRawSeriesColumns <= 0 || seriesHandles.Count <= activeMaxRawSeriesColumns)
                return seriesHandles;

            // Keep deterministic order and cap the huge raw matrix. Inventory still records all handles.
            return seriesHandles.Take(activeMaxRawSeriesColumns).ToList();
        }

        // --------------------------------------------------------------------
        // Plot values snapshot
        // --------------------------------------------------------------------
        private void WritePlotValuesSnapshot(string triggeredBy)
        {
            try
            {
                if (plotSnapshotWritten)
                    return;

                int lastBar = CurrentBar;
                if (lastBar < 1)
                    return;

                int firstBar = 0;
                if (activeMaxPlotRows > 0 && lastBar + 1 > activeMaxPlotRows)
                    firstBar = Math.Max(0, lastBar - activeMaxPlotRows + 1);

                var rawHandles = RawSeriesHandlesForExport();

                var headers = new List<string>
                {
                    "RunId","ExportTime","TriggeredBy","Instrument","BarsPeriod","BarIndex","BarTime","Open","High","Low","Close","Volume"
                };

                foreach (var h in rawHandles)
                    headers.Add(h.SafeColumnName);

                using (var sw = new StreamWriter(plotValuesPath, false, Encoding.UTF8))
                {
                    sw.WriteLine(string.Join(",", headers.Select(EscapeCsv).ToArray()));

                    for (int i = firstBar; i <= lastBar; i++)
                    {
                        var fields = BaseBarFields(triggeredBy, i);
                        foreach (var h in rawHandles)
                            fields.Add(ReadSeriesValueAtAsString(h.SeriesObject, i));

                        sw.WriteLine(Csv(fields.ToArray()));
                        plotRowsExported++;
                    }
                }

                plotSnapshotWritten = true;

                if (VerbosePrint)
                    Print("[Flow42DataCapture] Plot values snapshot written: " + plotValuesPath + " rows=" + plotRowsExported + " columns=" + rawHandles.Count);
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] WritePlotValuesSnapshot error: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // Deep discovery sample snapshot
        // --------------------------------------------------------------------
        private void WriteDiscoverySamplesSnapshot(string triggeredBy)
        {
            try
            {
                if (seriesHandles == null || seriesHandles.Count == 0)
                    return;

                int[] barsAgoSamples = new int[] { 0, 1, 2, 5, 10, 20, 50 };
                foreach (var h in seriesHandles)
                {
                    if (h == null)
                        continue;

                    foreach (int barsAgo in barsAgoSamples)
                    {
                        int barIndex = CurrentBar - barsAgo;
                        if (barIndex < 0)
                            continue;

                        string value = ReadSeriesValueAtAsString(h.SeriesObject, barIndex);
                        AppendLine(discoverySamplesPath, Csv(runId,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                            triggeredBy,
                            SafeInstrument(),
                            SafeBarsPeriod(),
                            h.IndicatorType,
                            h.IndicatorFullName,
                            h.IndicatorName,
                            h.SourceKind,
                            h.SourceName,
                            h.SourceIndex,
                            h.SafeColumnName,
                            barsAgo,
                            barIndex,
                            SafeBarTime(barIndex).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                            value));
                        discoverySampleRowsExported++;
                    }
                }

                if (VerbosePrint)
                    Print("[Flow42DataCapture] Discovery samples written: " + discoverySamplesPath + " rows=" + discoverySampleRowsExported);
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] WriteDiscoverySamplesSnapshot error: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // Draw scan
        // --------------------------------------------------------------------
        private void RequestDrawScan(string triggeredBy, bool writeAfter)
        {
            if (scanPending)
                return;

            scanPending = true;

            if (ChartControl != null)
            {
                ChartControl.Dispatcher.InvokeAsync(() =>
                {
                    try
                    {
                        ScanAndExportDrawObjects(triggeredBy);
                        if (writeAfter)
                            FinalizeSnapshots(triggeredBy);
                    }
                    catch (Exception ex)
                    {
                        RecordError("[Flow42DataCapture] Draw scan error: " + ex.Message);
                    }
                    finally
                    {
                        scanPending = false;
                    }
                });
            }
            else
            {
                try
                {
                    ScanAndExportDrawObjects(triggeredBy);
                    if (writeAfter)
                        FinalizeSnapshots(triggeredBy);
                }
                catch (Exception ex)
                {
                    RecordError("[Flow42DataCapture] Draw scan error: " + ex.Message);
                }
                finally
                {
                    scanPending = false;
                }
            }
        }

        private bool NeedsPostInventoryScanOrSnapshotPass()
        {
            return activeExportDrawAudit || activeExportReversalFeatures || activeExportLiveSnapshots;
        }

        private void FinalizeSnapshots(string triggeredBy)
        {
            if (activeExportReversalFeatures)
                WriteReversalFeaturesSnapshot(triggeredBy);
            if (activeExportLiveSnapshots)
                WriteLiveSnapshot(triggeredBy);

            SetStatus(errorCount > 0 ? "Error" : (warningCount > 0 ? "Warning" : "Complete"), "Export finalized by " + triggeredBy + ".");
            MaybeOpenFolder(triggeredBy);
            finalExportCompleted = true;

            // Write the summary after status/folder-open state is finalized so CSV does not
            // incorrectly show Exporting / Not opened yet for inventory-only or private-field runs.
            WriteSummary();

            // Freeze dashboard elapsed time after all final file writes have completed.
            if (dashboardEndUtc == DateTime.MinValue)
                dashboardEndUtc = DateTime.UtcNow;

            UpdateDashboardSafe();
        }

        private void ScanAndExportDrawObjects(string triggeredBy)
        {
            var snapshot = SnapshotDrawObjects();

            if (VerbosePrint && (barUpdateCount == 1 || barUpdateCount % 250 == 0 || triggeredBy.Contains("FINAL") || triggeredBy.Contains("LOAD")))
                Print("[Flow42DataCapture] Draw scan " + triggeredBy + " found objects: " + snapshot.Count);

            foreach (var pair in snapshot)
            {
                IDrawingTool draw = pair.Item1;
                int panelIndex = pair.Item2;
                if (draw == null)
                    continue;

                string tag = draw.Tag ?? "";
                string text = SafeGetText(draw);
                string drawType = draw.GetType().Name;
                string owner = SafeGetOwner(draw);
                DateTime anchorTime = SafeGetTime(draw);
                double anchorPrice = SafeGetPrice(draw);
                string color = SafeGetColor(draw);
                string blob = tag + " " + text + " " + drawType + " " + owner;

                bool relevant = string.IsNullOrEmpty(activeDrawKeywords) || MatchesAnyFilter(blob, activeDrawKeywords) || MatchesAnyFilter(blob, activeIndicatorFilter) || LooksFlow42Related(blob);
                if (!relevant)
                {
                    skippedNonRelevantDraws++;
                    continue;
                }

                string dedupeKey = MakeDrawDedupeKey(drawType, tag, text, anchorTime, anchorPrice, panelIndex);
                if (drawAuditDedupeKeys.Contains(dedupeKey))
                {
                    skippedDuplicateDraws++;
                    continue;
                }

                int barIdx = anchorTime > DateTime.MinValue ? SafeBarsGetBar(anchorTime) : CurrentBar;
                if (barIdx < 0)
                    barIdx = CurrentBar;
                if (barIdx > CurrentBar)
                    barIdx = CurrentBar;

                var ev = new DrawEvent
                {
                    RunId = runId,
                    ExportTime = DateTime.Now,
                    InstrumentName = SafeInstrument(),
                    BarsPeriodName = SafeBarsPeriod(),
                    AnchorTime = anchorTime,
                    BarIndex = barIdx,
                    BarTime = SafeBarTime(barIdx),
                    AnchorPrice = anchorPrice,
                    DrawType = drawType,
                    Tag = tag,
                    Text = text,
                    Owner = owner,
                    Color = color,
                    PanelIndex = panelIndex,
                    InferredIndicator = InferFlow42Indicator(blob),
                    InferredCategory = InferFlow42Category(blob),
                    InferredDirection = InferDirection(blob, color),
                    Stage = InferStage(blob),
                    DataQuality = BuildDrawDataQuality(anchorTime, anchorPrice, owner, text, tag),
                    DedupeKey = dedupeKey,
                    TriggeredBy = triggeredBy,
                    Mode = State == State.Realtime ? "RT" : "HIST"
                };

                drawEvents.Add(ev);
                drawAuditDedupeKeys.Add(dedupeKey);

                if (activeExportDrawAudit)
                {
                    AppendLine(drawAuditPath, Csv(ev.RunId, ev.ExportTime.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), ev.InstrumentName, ev.BarsPeriodName,
                        ev.AnchorTime == DateTime.MinValue ? "" : ev.AnchorTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), ev.BarIndex, ev.BarTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), Fmt(ev.AnchorPrice),
                        ev.DrawType, ev.Tag, ev.Text, ev.Owner, ev.Color, ev.PanelIndex, ev.InferredIndicator, ev.InferredCategory, ev.InferredDirection, ev.Stage, ev.DataQuality, ev.TriggeredBy, ev.Mode));
                    drawAuditRowsExported++;
                }
            }
        }

        private List<Tuple<IDrawingTool, int>> SnapshotDrawObjects()
        {
            var list = new List<Tuple<IDrawingTool, int>>();
            var seen = new HashSet<IDrawingTool>();

            try
            {
                if (ChartControl != null && ChartControl.ChartPanels != null)
                {
                    int panelIndex = -1;
                    foreach (var panel in ChartControl.ChartPanels)
                    {
                        panelIndex++;
                        if (panel == null || panel.ChartObjects == null)
                            continue;

                        object[] panelObjects;
                        try { panelObjects = panel.ChartObjects.Cast<object>().ToArray(); }
                        catch
                        {
                            try { panelObjects = panel.ChartObjects.Cast<object>().ToArray(); }
                            catch { continue; }
                        }

                        foreach (object obj in panelObjects)
                        {
                            IDrawingTool draw = obj as IDrawingTool;
                            if (draw != null && !seen.Contains(draw))
                            {
                                seen.Add(draw);
                                list.Add(Tuple.Create(draw, panelIndex));
                                if (activeMaxDrawObjectsToScan > 0 && list.Count >= activeMaxDrawObjectsToScan)
                                {
                                    cappedDrawObjects++;
                                    return list;
                                }
                            }
                        }
                    }
                }

                if (DrawObjects != null)
                {
                    object[] ownObjects;
                    try { ownObjects = DrawObjects.Cast<object>().ToArray(); }
                    catch { ownObjects = new object[0]; }

                    foreach (object obj in ownObjects)
                    {
                        IDrawingTool draw = obj as IDrawingTool;
                        if (draw != null && !seen.Contains(draw))
                        {
                            seen.Add(draw);
                            list.Add(Tuple.Create(draw, -1));
                            if (activeMaxDrawObjectsToScan > 0 && list.Count >= activeMaxDrawObjectsToScan)
                                return list;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] SnapshotDrawObjects error: " + ex.Message);
            }

            return list;
        }

        // --------------------------------------------------------------------
        // Reversal feature export
        // --------------------------------------------------------------------
        private void WriteReversalFeaturesSnapshot(string triggeredBy)
        {
            try
            {
                if (reversalFeaturesWritten)
                    return;

                int lastBar = CurrentBar;
                if (lastBar < 1)
                    return;

                int firstBar = 0;
                if (activeMaxPlotRows > 0 && lastBar + 1 > activeMaxPlotRows)
                    firstBar = Math.Max(0, lastBar - activeMaxPlotRows + 1);

                var headers = new List<string>
                {
                    "RunId","ExportTime","TriggeredBy","Instrument","BarsPeriod","BarIndex","BarTime","Open","High","Low","Close","Volume",
                    "Body","Range","UpperWick","LowerWick","BodyFrac","UpperWickFrac","LowerWickFrac","CloseLocationFrac",
                    "VolDrive_Long","VolDrive_Short","VolDrive_Signal",
                    "VolDelta_BuyVolume","VolDelta_SellVolume","VolDelta_Delta","VolDelta_CVD","VolDelta_RelativeDeltaPressure","VolDelta_SourceOrMode","VolDelta_DeltaSourceSetting","VolDelta_CvdMode","VolDelta_CvdResetMode","VolDelta_AbsDeltaEqualsVolumeFlag","VolDelta_BuySellSumMinusVolume",
                    "NTVolumetric_BuyVolume","NTVolumetric_SellVolume","NTVolumetric_Delta","NTVolumetric_CVD_Run","NTVolumetric_Available","NTVolumetric_SourceStatus","NTVolumetric_BuySellSumMinusVolume",
                    "PreferredDelta_BuyVolume","PreferredDelta_SellVolume","PreferredDelta_Delta","PreferredDelta_CVD","PreferredDelta_Source",
                    "ChopState_State","ChopState_ChopScore","ChopState_ER","ChopState_Overlap","ChopState_BoxPositionOrEdge",
                    "VolSpike_Flag","VolSpike_RatioOrZScore","VolSpike_Mode",
                    "VolDynamics_Absorption","VolDynamics_Exhaustion","VolDynamics_VolumePush","VolDynamics_VolumeSurge",
                    "VolImbalance_Bid","VolImbalance_Ask","VolImbalance_ClusterCount","VolImbalance_ClusterVolume","VolImbalance_ClusterSideOrStrength",
                    "AbsorptionMap_Stage","AbsorptionMap_Side","AbsorptionMap_ScoreOrStrength","AbsorptionMap_Price",
                    "VolLiqMeter_AggressorBuy","VolLiqMeter_AggressorSell","VolLiqMeter_Imbalance","VolLiqMeter_AvgLiquidity",
                    "CloudNotes_NearestLevelOrDistance","CloudNotes_LevelType",
                    "DrawEvents_SameBar_Total","DrawEvents_SameBar_AbsorptionMap","DrawEvents_SameBar_VolImbalance","DrawEvents_SameBar_VolDynamics","DrawEvents_SameBar_VolSpike","DrawEvents_SameBar_VolDrive","DrawEvents_SameBar_VolDelta","DrawEvents_SameBar_ChopState","DrawEvents_SameBar_CloudNotes","DrawEvents_SameBar_VolLiqMeter",
                    "DrawEvents_Last3_Total","DrawEvents_Last3_Candidate","DrawEvents_Last3_Provisional","DrawEvents_Last3_Confirmed","DrawEvents_Last3_LiveWarning","DrawEvents_Last3_Absorption","DrawEvents_Last3_Exhaustion","DrawEvents_Last3_Imbalance","DrawEvents_Last3_Spike","DrawEvents_Last3_DeltaOrCVD","DrawEvents_Last3_Up","DrawEvents_Last3_Down"
                };

                Dictionary<int, List<DrawEvent>> drawIndex = BuildDrawIndexByBar();

                double ntVolumetricCvdRun = 0.0;

                using (var sw = new StreamWriter(reversalFeaturesPath, false, Encoding.UTF8))
                {
                    sw.WriteLine(string.Join(",", headers.Select(EscapeCsv).ToArray()));

                    for (int i = firstBar; i <= lastBar; i++)
                    {
                        var fields = BaseBarFields(triggeredBy, i);
                        double o = SafeOpen(i);
                        double h = SafeHigh(i);
                        double l = SafeLow(i);
                        double c = SafeClose(i);
                        double range = h - l;
                        double body = Math.Abs(c - o);
                        double upper = h - Math.Max(o, c);
                        double lower = Math.Min(o, c) - l;
                        double bodyFrac = range > 0 ? body / range : 0;
                        double upperFrac = range > 0 ? upper / range : 0;
                        double lowerFrac = range > 0 ? lower / range : 0;
                        double closeLoc = range > 0 ? (c - l) / range : 0.5;

                        fields.Add(Fmt(body));
                        fields.Add(Fmt(range));
                        fields.Add(Fmt(upper));
                        fields.Add(Fmt(lower));
                        fields.Add(Fmt(bodyFrac));
                        fields.Add(Fmt(upperFrac));
                        fields.Add(Fmt(lowerFrac));
                        fields.Add(Fmt(closeLoc));

                        // v0.3: strict known-output mapping.
                        // We intentionally do NOT do broad keyword fallback here, because broad fallback can
                        // accidentally map settings/generic series (Volume, ThresholdAbs, Close, etc.) into
                        // model columns and create fake features.
                        fields.Add(KnownOutputValueAt(i, "Flow42VolDrive", "VolDriveLong"));
                        fields.Add(KnownOutputValueAt(i, "Flow42VolDrive", "VolDriveShort"));
                        fields.Add(KnownOutputValueAt(i, "Flow42VolDrive", "VolDriveSignal"));

                        string volDeltaBuy = KnownOutputValueAt(i, "Flow42VolDelta", "BuyVolume");
                        string volDeltaSell = KnownOutputValueAt(i, "Flow42VolDelta", "SellVolume");
                        string volDeltaDelta = KnownOutputValueAt(i, "Flow42VolDelta", "Delta");
                        string volDeltaCvd = KnownOutputValueAt(i, "Flow42VolDelta", "CVD");
                        string volDeltaPressure = KnownOutputValueAt(i, "Flow42VolDelta", "RelativeDeltaPressure");
                        string volDeltaAbsEqFlag;
                        string volDeltaBuySellMinusVolume;
                        UpdateVolDeltaQualityCounters(i, volDeltaBuy, volDeltaSell, volDeltaDelta, out volDeltaAbsEqFlag, out volDeltaBuySellMinusVolume);

                        fields.Add(volDeltaBuy);
                        fields.Add(volDeltaSell);
                        fields.Add(volDeltaDelta);
                        fields.Add(volDeltaCvd);
                        fields.Add(volDeltaPressure);
                        fields.Add(VolDeltaSourceSummary());
                        fields.Add(volDeltaDeltaSourceSetting);
                        fields.Add(volDeltaCvdModeSetting);
                        fields.Add(volDeltaCvdResetModeSetting);
                        fields.Add(volDeltaAbsEqFlag);
                        fields.Add(volDeltaBuySellMinusVolume);

                        double ntBuy;
                        double ntSell;
                        double ntDelta;
                        bool ntOk = TryGetNTVolumetricBidAskDelta(i, out ntBuy, out ntSell, out ntDelta);
                        string ntBuyText = ntOk ? Fmt(ntBuy) : "";
                        string ntSellText = ntOk ? Fmt(ntSell) : "";
                        string ntDeltaText = ntOk ? Fmt(ntDelta) : "";
                        if (ntOk)
                            ntVolumetricCvdRun += ntDelta;
                        string ntCvdText = ntOk ? Fmt(ntVolumetricCvdRun) : "";
                        string ntAvailableText = ntOk ? "1" : "0";
                        string ntSumMinusVolumeText = UpdateNTVolumetricQualityCounters(i, ntOk, ntBuy, ntSell);

                        string preferredBuy;
                        string preferredSell;
                        string preferredDelta;
                        string preferredCvd;
                        string preferredSource;
                        ChoosePreferredDeltaSource(ntOk, ntBuyText, ntSellText, ntDeltaText, ntCvdText, volDeltaBuy, volDeltaSell, volDeltaDelta, volDeltaCvd, out preferredBuy, out preferredSell, out preferredDelta, out preferredCvd, out preferredSource);

                        fields.Add(ntBuyText);
                        fields.Add(ntSellText);
                        fields.Add(ntDeltaText);
                        fields.Add(ntCvdText);
                        fields.Add(ntAvailableText);
                        fields.Add(ntVolumetricDeltaStatus);
                        fields.Add(ntSumMinusVolumeText);

                        fields.Add(preferredBuy);
                        fields.Add(preferredSell);
                        fields.Add(preferredDelta);
                        fields.Add(preferredCvd);
                        fields.Add(preferredSource);

                        fields.Add(KnownOutputValueAt(i, "Flow42ChopState", "IsChoppy"));
                        fields.Add(KnownOutputValueAt(i, "Flow42ChopState", "ChopScore"));
                        fields.Add(KnownOutputValueAt(i, "Flow42ChopState", "ER"));
                        fields.Add("");
                        fields.Add("");

                        fields.Add(KnownOutputValueAt(i, "Flow42VolSpike", "HasSpikeOnBar"));
                        fields.Add("");
                        fields.Add("");

                        // VolDynamics did not expose clean event-output series in the first NQ volumetric run.
                        // Leave these blank unless a future Flow42 build exposes exact output series or draw events are captured.
                        fields.Add("");
                        fields.Add("");
                        fields.Add("");
                        fields.Add("");

                        fields.Add(KnownOutputValueAt(i, "Flow42VolImbalance", "BloodHoundBIDImbalanceSignal"));
                        fields.Add(KnownOutputValueAt(i, "Flow42VolImbalance", "BloodHoundASKImbalanceSignal"));
                        fields.Add("");
                        fields.Add("");
                        fields.Add("");

                        // AbsorptionMap did not expose clean per-bar output series in the first run.
                        fields.Add("");
                        fields.Add("");
                        fields.Add("");
                        fields.Add("");

                        // VolLiqMeter and CloudNotes are only populated if those indicators expose exact series in the chart.
                        fields.Add(KnownOutputValueAt(i, "Flow42VolLiqMeter", "AggressorBuy"));
                        fields.Add(KnownOutputValueAt(i, "Flow42VolLiqMeter", "AggressorSell"));
                        fields.Add(KnownOutputValueAt(i, "Flow42VolLiqMeter", "Imbalance"));
                        fields.Add(KnownOutputValueAt(i, "Flow42VolLiqMeter", "AvgLiquidity"));

                        fields.Add(KnownOutputValueAt(i, "Flow42CloudNotes", "NearestLevel"));
                        fields.Add(KnownOutputValueAt(i, "Flow42CloudNotes", "LevelType"));

                        AddDrawCountsForBar(fields, i, drawIndex);

                        sw.WriteLine(Csv(fields.ToArray()));
                        reversalFeatureRowsExported++;
                    }
                }

                FinalizeVolDeltaQualityDiagnostics();
                FinalizeNTVolumetricDeltaDiagnostics();

                reversalFeaturesWritten = true;

                if (VerbosePrint)
                    Print("[Flow42DataCapture] Reversal features written: " + reversalFeaturesPath + " rows=" + reversalFeatureRowsExported + " drawEvents=" + (drawEvents == null ? 0 : drawEvents.Count));
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] WriteReversalFeaturesSnapshot error: " + ex.Message);
            }
        }

        private Dictionary<int, List<DrawEvent>> BuildDrawIndexByBar()
        {
            var dict = new Dictionary<int, List<DrawEvent>>();
            if (drawEvents == null)
                return dict;

            foreach (var e in drawEvents)
            {
                if (e == null)
                    continue;

                List<DrawEvent> list;
                if (!dict.TryGetValue(e.BarIndex, out list))
                {
                    list = new List<DrawEvent>();
                    dict[e.BarIndex] = list;
                }
                list.Add(e);
            }

            return dict;
        }

        private void AddDrawCountsForBar(List<string> fields, int barIndex, Dictionary<int, List<DrawEvent>> drawIndex)
        {
            List<DrawEvent> same;
            if (drawIndex == null || !drawIndex.TryGetValue(barIndex, out same))
                same = new List<DrawEvent>();

            var last3 = new List<DrawEvent>();
            if (drawIndex != null)
            {
                for (int b = barIndex - 3; b <= barIndex; b++)
                {
                    List<DrawEvent> tmp;
                    if (drawIndex.TryGetValue(b, out tmp) && tmp != null)
                        last3.AddRange(tmp);
                }
            }

            fields.Add(same.Count.ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "AbsorptionMap", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "VolImbalance", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "VolDynamics", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "VolSpike", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "VolDrive", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "VolDelta", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "ChopState", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "CloudNotes", "", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(same, "VolLiqMeter", "", "").ToString(CultureInfo.InvariantCulture));

            fields.Add(last3.Count.ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "", "Candidate").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "", "Provisional").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "", "Confirmed").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "", "LiveWarning").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "Absorption", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "Exhaustion", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "Imbalance", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "Spike", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "VolDelta", "Delta", "").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "", "", "UP").ToString(CultureInfo.InvariantCulture));
            fields.Add(CountDraws(last3, "", "", "", "DOWN").ToString(CultureInfo.InvariantCulture));
        }

        private int CountDraws(List<DrawEvent> list, string indicator, string category, string stage)
        {
            return CountDraws(list, indicator, category, stage, "");
        }

        private int CountDraws(List<DrawEvent> list, string indicator, string category, string stage, string direction)
        {
            if (list == null)
                return 0;

            return list.Count(e =>
                (string.IsNullOrEmpty(indicator) || Eq(e.InferredIndicator, indicator)) &&
                (string.IsNullOrEmpty(category) || ContainsAny(e.InferredCategory, category)) &&
                (string.IsNullOrEmpty(stage) || Eq(e.Stage, stage)) &&
                (string.IsNullOrEmpty(direction) || Eq(e.InferredDirection, direction)));
        }

        private string KnownOutputValueAt(int barIndex, string indicatorType, string sourceName)
        {
            try
            {
                SeriesHandle h = FindKnownOutputHandle(indicatorType, sourceName);
                if (h == null)
                    return "";

                return ReadSeriesValueAtAsString(h.SeriesObject, barIndex);
            }
            catch { }

            return "";
        }

        private SeriesHandle FindKnownOutputHandle(string indicatorType, string sourceName)
        {
            if (seriesHandles == null || seriesHandles.Count == 0)
                return null;

            string cacheKey = "KNOWN||" + (indicatorType ?? "") + "||" + (sourceName ?? "");
            SeriesHandle cached;
            if (aliasHandleCache == null)
                aliasHandleCache = new Dictionary<string, SeriesHandle>();
            if (aliasHandleCache.TryGetValue(cacheKey, out cached))
                return cached;

            // Prefer actual Values[] plot outputs over duplicate public-property wrappers.
            foreach (var h in seriesHandles)
            {
                if (h == null)
                    continue;

                if (Eq(h.IndicatorType, indicatorType) && Eq(h.SourceName, sourceName) && Eq(h.SourceKind, "Values"))
                {
                    aliasHandleCache[cacheKey] = h;
                    return h;
                }
            }

            foreach (var h in seriesHandles)
            {
                if (h == null)
                    continue;

                if (Eq(h.IndicatorType, indicatorType) && Eq(h.SourceName, sourceName) && IsTrustedKnownOutput(h))
                {
                    aliasHandleCache[cacheKey] = h;
                    return h;
                }
            }

            aliasHandleCache[cacheKey] = null;
            return null;
        }

        private bool IsTrustedKnownOutput(SeriesHandle h)
        {
            if (h == null)
                return false;

            string ind = h.IndicatorType ?? "";
            string src = h.SourceName ?? "";

            if (Eq(ind, "Flow42VolDrive") &&
                (Eq(src, "VolDriveLong") || Eq(src, "VolDriveShort") || Eq(src, "VolDriveSignal")))
                return true;

            if (Eq(ind, "Flow42VolDelta") &&
                (Eq(src, "BuyVolume") || Eq(src, "SellVolume") || Eq(src, "Delta") || Eq(src, "CVD") || Eq(src, "RelativeDeltaPressure")))
                return true;

            if (Eq(ind, "Flow42VolImbalance") &&
                (Eq(src, "BloodHoundBIDImbalanceSignal") || Eq(src, "BloodHoundASKImbalanceSignal")))
                return true;

            if (Eq(ind, "Flow42ChopState") &&
                (Eq(src, "IsChoppy") || Eq(src, "ChopScore") || Eq(src, "ER") || Eq(src, "EfficiencyRatio") || Eq(src, "EfficiencyRatioValue")))
                return true;

            if (Eq(ind, "Flow42VolSpike") && Eq(src, "HasSpikeOnBar"))
                return true;

            // Future-proof exact VolLiqMeter / CloudNotes outputs if a build exposes them with these names.
            if (Eq(ind, "Flow42VolLiqMeter") &&
                (Eq(src, "AggressorBuy") || Eq(src, "AggressorSell") || Eq(src, "Imbalance") || Eq(src, "AvgLiquidity")))
                return true;

            if (Eq(ind, "Flow42CloudNotes") &&
                (Eq(src, "NearestLevel") || Eq(src, "LevelType")))
                return true;

            return false;
        }

        private string AliasValueAt(int barIndex, string indicatorKeywords, string valueKeywords)
        {
            try
            {
                if (seriesHandles == null || seriesHandles.Count == 0)
                    return "";

                if (aliasHandleCache == null)
                    aliasHandleCache = new Dictionary<string, SeriesHandle>();

                string cacheKey = indicatorKeywords + "||" + valueKeywords;
                SeriesHandle cached;
                if (!aliasHandleCache.TryGetValue(cacheKey, out cached))
                {
                    cached = FindAliasHandle(indicatorKeywords, valueKeywords);
                    aliasHandleCache[cacheKey] = cached; // null is intentional: remember no-match so we do not rescan every bar.
                }

                if (cached == null)
                    return "";

                return ReadSeriesValueAtAsString(cached.SeriesObject, barIndex);
            }
            catch { }

            return "";
        }

        private SeriesHandle FindAliasHandle(string indicatorKeywords, string valueKeywords)
        {
            if (seriesHandles == null || seriesHandles.Count == 0)
                return null;

            string[] indKeys = SplitFilter(indicatorKeywords);
            string[] valKeys = SplitFilter(valueKeywords);

            foreach (var h in seriesHandles)
            {
                if (h == null)
                    continue;

                string blob = h.KeyBlob ?? "";
                if (MatchesAny(blob, indKeys) && MatchesAny(blob, valKeys) && !IsDangerousGenericSeriesHandle(h))
                    return h;
            }

            // v0.3: no global fallback. A value keyword match without the intended Flow42 indicator
            // is more dangerous than a blank column because it can create fake model features.
            return null;
        }

        private bool IsDangerousGenericSeriesHandle(SeriesHandle h)
        {
            if (h == null)
                return true;

            string n = h.SourceName ?? "";
            if (Eq(n, "Open") || Eq(n, "High") || Eq(n, "Low") || Eq(n, "Close") ||
                Eq(n, "Input") || Eq(n, "InputUI") || Eq(n, "Median") || Eq(n, "Typical") ||
                Eq(n, "Weighted") || Eq(n, "Time") || Eq(n, "Volume") || Eq(n, "Value") ||
                Eq(n, "BackBrushes") || Eq(n, "BackBrushesAll") || Eq(n, "BarBrushes") ||
                Eq(n, "CandleOutlineBrushes") || Eq(n, "DrawObjects") || Eq(n, "TrackedOrders"))
                return true;

            if (ContainsAny(n, "Threshold,Baseline,Setting,Color,Brush,Serializable"))
                return true;

            return false;
        }

        // --------------------------------------------------------------------
        // Live snapshot export
        // --------------------------------------------------------------------
        private void WriteLiveSnapshot(string triggeredBy)
        {
            try
            {
                if (!activeExportLiveSnapshots)
                    return;

                if (!liveHeaderWritten)
                {
                    var headers = new List<string> { "RunId", "ExportTime", "TriggeredBy", "Mode", "Instrument", "BarsPeriod", "CurrentBar", "BarTime", "Open", "High", "Low", "Close", "Volume" };
                    if (seriesHandles != null)
                    {
                        foreach (var h in seriesHandles)
                            headers.Add("Current__" + h.SafeColumnName);
                    }
                    headers.Add("DrawEvents_TotalSoFar");
                    headers.Add("DrawEvents_CurrentBar");
                    headers.Add("DrawEvents_Last3Bars");
                    File.WriteAllText(liveSnapshotPath, string.Join(",", headers.Select(EscapeCsv).ToArray()) + Environment.NewLine);
                    liveHeaderWritten = true;
                }

                int i = CurrentBar;
                var fields = new List<string>
                {
                    runId,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    triggeredBy,
                    State == State.Realtime ? "RT" : "HIST",
                    SafeInstrument(),
                    SafeBarsPeriod(),
                    i.ToString(CultureInfo.InvariantCulture),
                    SafeBarTime(i).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    Fmt(SafeOpen(i)),
                    Fmt(SafeHigh(i)),
                    Fmt(SafeLow(i)),
                    Fmt(SafeClose(i)),
                    Fmt(SafeVolume(i))
                };

                if (seriesHandles != null)
                {
                    foreach (var h in seriesHandles)
                        fields.Add(ReadSeriesCurrentAsString(h.SeriesObject));
                }

                int total = drawEvents == null ? 0 : drawEvents.Count;
                int current = drawEvents == null ? 0 : drawEvents.Count(e => e.BarIndex == i);
                int last3 = drawEvents == null ? 0 : drawEvents.Count(e => e.BarIndex >= i - 3 && e.BarIndex <= i);
                fields.Add(total.ToString(CultureInfo.InvariantCulture));
                fields.Add(current.ToString(CultureInfo.InvariantCulture));
                fields.Add(last3.ToString(CultureInfo.InvariantCulture));

                AppendLine(liveSnapshotPath, Csv(fields.ToArray()));
                liveSnapshotRowsExported++;
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] WriteLiveSnapshot error: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // Base headers / summary / readme
        // --------------------------------------------------------------------
        private void EnsureBaseHeaders()
        {
            try
            {
                File.WriteAllText(inventoryPath, "ExportTime,Instrument,BarsPeriod,IndicatorIndex,IndicatorType,IndicatorFullName,IndicatorToString,ItemKind,SourceIndex,SourceName,SourceTypeOrFullName,CurrentValue,Notes" + Environment.NewLine);
                File.WriteAllText(settingsPath, "ExportTime,Instrument,BarsPeriod,IndicatorIndex,IndicatorType,IndicatorFullName,IndicatorToString,PropertyName,PropertyType,Value,Error" + Environment.NewLine);
                File.WriteAllText(methodsPath, "ExportTime,Instrument,BarsPeriod,IndicatorIndex,IndicatorType,IndicatorFullName,IndicatorToString,MethodName,ReturnType,ParameterSignature,KnownSafeToInvoke,TestBarsAgo0,TestBarsAgo1,Notes" + Environment.NewLine);
                File.WriteAllText(drawAuditPath, "RunId,ExportTime,Instrument,BarsPeriod,AnchorTime,BarIndex,BarTime,AnchorPrice,DrawType,Tag,Text,Owner,Color,PanelIndex,InferredIndicator,InferredCategory,InferredDirection,Stage,DataQuality,TriggeredBy,Mode" + Environment.NewLine);
                File.WriteAllText(discoverySamplesPath, "RunId,ExportTime,TriggeredBy,Instrument,BarsPeriod,IndicatorType,IndicatorFullName,IndicatorName,SourceKind,SourceName,SourceIndex,SafeColumnName,BarsAgo,BarIndex,BarTime,Value" + Environment.NewLine);
                File.WriteAllText(privateFieldNamesPath, "ExportTime,Instrument,BarsPeriod,IndicatorIndex,IndicatorType,IndicatorFullName,IndicatorToString,DeclaringType,FieldName,FieldType,IsStatic,IsReadonly,IsLiteral,Attributes,LikelyRelevant,RelevanceHint,Notes" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] EnsureBaseHeaders error: " + ex.Message);
            }
        }

        private void CaptureKnownScalarSettingsForDiagnostics(object ind, string typeName)
        {
            try
            {
                if (!Eq(typeName, "Flow42VolDelta"))
                    return;

                volDeltaDeltaSourceSetting = SafeGetPropertyAsText(ind, "DeltaSource");
                volDeltaCvdModeSetting = SafeGetPropertyAsText(ind, "CvdMode");
                volDeltaCvdResetModeSetting = SafeGetPropertyAsText(ind, "CvdResetMode");
                volDeltaHistoryCacheSetting = SafeGetPropertyAsText(ind, "HistoryCache");
                volDeltaUseHistoryCacheFallbackSetting = SafeGetPropertyAsText(ind, "UseHistoryCacheFallback");
                volDeltaPreferCacheOnHistoricalSetting = SafeGetPropertyAsText(ind, "PreferCacheOnHistorical");
            }
            catch { }
        }

        private string SafeGetPropertyAsText(object obj, string propName)
        {
            try
            {
                object v = SafeGetPropertyValue(obj, propName);
                return v == null ? "" : SafeToString(v);
            }
            catch { return ""; }
        }

        private string VolDeltaSourceSummary()
        {
            var parts = new List<string>();
            if (!string.IsNullOrEmpty(volDeltaDeltaSourceSetting)) parts.Add("DeltaSource=" + volDeltaDeltaSourceSetting);
            if (!string.IsNullOrEmpty(volDeltaCvdModeSetting)) parts.Add("CvdMode=" + volDeltaCvdModeSetting);
            if (!string.IsNullOrEmpty(volDeltaCvdResetModeSetting)) parts.Add("Reset=" + volDeltaCvdResetModeSetting);
            return parts.Count == 0 ? "" : string.Join(";", parts.ToArray());
        }

        private void UpdateVolDeltaQualityCounters(int barIndex, string buyText, string sellText, string deltaText, out string absDeltaEqualsVolumeFlag, out string buySellSumMinusVolumeText)
        {
            absDeltaEqualsVolumeFlag = "";
            buySellSumMinusVolumeText = "";

            double delta;
            if (TryParseFlexibleDouble(deltaText, out delta))
            {
                double volume = SafeVolume(barIndex);
                if (!double.IsNaN(volume) && !double.IsInfinity(volume) && volume >= 0)
                {
                    volDeltaComparableRows++;
                    bool eq = NearlyEqual(Math.Abs(delta), volume, Math.Max(0.000001, Math.Max(1.0, volume) * 0.000001));
                    if (eq)
                        volDeltaAbsDeltaEqualsVolumeRows++;
                    absDeltaEqualsVolumeFlag = eq ? "1" : "0";
                }
            }

            double buy;
            double sell;
            if (TryParseFlexibleDouble(buyText, out buy) && TryParseFlexibleDouble(sellText, out sell))
            {
                double volume = SafeVolume(barIndex);
                if (!double.IsNaN(volume) && !double.IsInfinity(volume))
                {
                    double diff = (buy + sell) - volume;
                    buySellSumMinusVolumeText = Fmt(diff);
                    volDeltaBuySellComparableRows++;
                    if (!NearlyEqual(diff, 0, Math.Max(0.000001, Math.Max(1.0, Math.Abs(volume)) * 0.000001)))
                        volDeltaBuySellSumMismatchRows++;
                }
            }
        }

        private void FinalizeVolDeltaQualityDiagnostics()
        {
            try
            {
                volDeltaAbsDeltaEqualsVolumeRate = volDeltaComparableRows > 0
                    ? (double)volDeltaAbsDeltaEqualsVolumeRows / (double)volDeltaComparableRows
                    : 0.0;

                if (volDeltaComparableRows >= 100 && volDeltaAbsDeltaEqualsVolumeRate >= 0.90)
                {
                    volDeltaLikelyProxyWarning = "High |Delta|==Volume rate. VolDelta may be using OHLC/up-down/proxy-style classification or all-volume-direction assignment in this historical export. Verify DeltaSource/VolumetricBidAsk before treating as true bid/ask delta.";
                    if (!volDeltaQualityWarningRegistered)
                    {
                        warningCount++;
                        volDeltaQualityWarningRegistered = true;
                    }
                }
                else
                {
                    volDeltaLikelyProxyWarning = "";
                }
            }
            catch { }
        }

        private bool TryGetNTVolumetricBidAskDelta(int barIndex, out double buyVolume, out double sellVolume, out double delta)
        {
            buyVolume = double.NaN;
            sellVolume = double.NaN;
            delta = double.NaN;

            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Disabled || ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Flow42VolDeltaOnly)
            {
                ntVolumetricDeltaStatus = "Disabled by ExporterDeltaMode";
                return false;
            }

            try
            {
                if (BarsArray == null || BarsArray.Length == 0 || BarsArray[0] == null)
                {
                    ntVolumetricDeltaStatus = "BarsArray unavailable";
                    return false;
                }

                VolumetricBarsType barsType = BarsArray[0].BarsType as VolumetricBarsType;
                if (barsType == null)
                {
                    ntVolumetricDeltaStatus = "Primary BarsType is not Volumetric";
                    return false;
                }

                if (barsType.Volumes == null)
                {
                    ntVolumetricDeltaStatus = "Volumetric volumes unavailable";
                    return false;
                }

                if (barIndex < 0 || barIndex > CurrentBar)
                {
                    ntVolumetricDeltaStatus = "Bar index outside loaded range";
                    return false;
                }

                var barVolume = barsType.Volumes[barIndex];
                if (barVolume == null)
                {
                    ntVolumetricDeltaStatus = "Volumetric bar volume missing";
                    return false;
                }

                buyVolume = Convert.ToDouble(barVolume.TotalBuyingVolume, CultureInfo.InvariantCulture);
                sellVolume = Convert.ToDouble(barVolume.TotalSellingVolume, CultureInfo.InvariantCulture);
                delta = Convert.ToDouble(barVolume.BarDelta, CultureInfo.InvariantCulture);
                ntVolumetricDeltaStatus = "NT Volumetric BidAsk";
                return true;
            }
            catch (Exception ex)
            {
                ntVolumetricDeltaStatus = "NT volumetric read failed: " + ex.Message;
                return false;
            }
        }

        private string UpdateNTVolumetricQualityCounters(int barIndex, bool hasValue, double buyVolume, double sellVolume)
        {
            if (!hasValue)
            {
                ntVolumetricDeltaMissingRows++;
                return "";
            }

            ntVolumetricDeltaRows++;
            double volume = SafeVolume(barIndex);
            if (double.IsNaN(volume) || double.IsInfinity(volume))
                return "";

            double diff = (buyVolume + sellVolume) - volume;
            ntVolumetricComparableRows++;
            if (!NearlyEqual(diff, 0, Math.Max(0.000001, Math.Max(1.0, Math.Abs(volume)) * 0.000001)))
                ntVolumetricBuySellSumMismatchRows++;
            return Fmt(diff);
        }

        private void ChoosePreferredDeltaSource(
            bool ntOk,
            string ntBuy,
            string ntSell,
            string ntDelta,
            string ntCvd,
            string flowBuy,
            string flowSell,
            string flowDelta,
            string flowCvd,
            out string preferredBuy,
            out string preferredSell,
            out string preferredDelta,
            out string preferredCvd,
            out string preferredSource)
        {
            preferredBuy = "";
            preferredSell = "";
            preferredDelta = "";
            preferredCvd = "";
            preferredSource = "";

            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Disabled)
            {
                preferredSource = "Disabled";
                return;
            }

            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Flow42VolDeltaOnly)
            {
                preferredBuy = flowBuy;
                preferredSell = flowSell;
                preferredDelta = flowDelta;
                preferredCvd = flowCvd;
                preferredSource = "Flow42VolDelta";
                return;
            }

            if (ntOk)
            {
                preferredBuy = ntBuy;
                preferredSell = ntSell;
                preferredDelta = ntDelta;
                preferredCvd = ntCvd;
                preferredSource = "NTVolumetricBidAsk";
                return;
            }

            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.AutoPreferNTVolumetricBidAsk)
            {
                preferredBuy = flowBuy;
                preferredSell = flowSell;
                preferredDelta = flowDelta;
                preferredCvd = flowCvd;
                preferredSource = "Flow42VolDeltaFallback";
                return;
            }

            preferredSource = "NTVolumetricUnavailable";
        }

        private void FinalizeNTVolumetricDeltaDiagnostics()
        {
            try
            {
                if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Disabled || ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Flow42VolDeltaOnly)
                    return;

                if (ntVolumetricDeltaRows == 0)
                {
                    ntVolumetricDeltaWarning = "No NT volumetric bid/ask delta rows were available. Use a 1-minute Volumetric chart for exporter-calculated true bid/ask delta; otherwise PreferredDelta may fall back to Flow42 VolDelta in Auto mode.";
                    if (!ntVolumetricQualityWarningRegistered)
                    {
                        warningCount++;
                        ntVolumetricQualityWarningRegistered = true;
                    }
                }
                else if (ntVolumetricComparableRows > 0 && ntVolumetricBuySellSumMismatchRows > ntVolumetricComparableRows * 0.05)
                {
                    ntVolumetricDeltaWarning = "NT volumetric buy+sell differed from bar volume on more than 5% of comparable rows. Review data/feed/session assumptions before treating NTVolumetric_* as exact total-volume split.";
                    if (!ntVolumetricQualityWarningRegistered)
                    {
                        warningCount++;
                        ntVolumetricQualityWarningRegistered = true;
                    }
                }
                else
                {
                    ntVolumetricDeltaWarning = "";
                }
            }
            catch { }
        }

        private bool TryParseFlexibleDouble(string text, out double value)
        {
            value = double.NaN;
            if (string.IsNullOrWhiteSpace(text))
                return false;

            string s = text.Trim();
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                return true;
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                return true;
            return false;
        }

        private bool NearlyEqual(double a, double b, double tolerance)
        {
            if (double.IsNaN(a) || double.IsNaN(b) || double.IsInfinity(a) || double.IsInfinity(b))
                return false;
            return Math.Abs(a - b) <= Math.Abs(tolerance);
        }

        private void WriteSummary()
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Metric,Value");
                sb.AppendLine(Csv("RunId", runId));
                sb.AppendLine(Csv("Instrument", SafeInstrument()));
                sb.AppendLine(Csv("BarsPeriod", SafeBarsPeriod()));
                sb.AppendLine(Csv("PrimaryDataQuality", PrimaryDataQualityLabel()));
                sb.AppendLine(Csv("DeltaSourceQuality", DeltaSourceQualityLabel()));
                sb.AppendLine(Csv("TickCapture", SafeTickCaptureFolderToken()));
                sb.AppendLine(Csv("LoadedDataStart", SafeFirstLoadedBarTime() == DateTime.MinValue ? "" : SafeFirstLoadedBarTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)));
                sb.AppendLine(Csv("LoadedDataEnd", SafeLastLoadedBarTime() == DateTime.MinValue ? "" : SafeLastLoadedBarTime().ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)));
                sb.AppendLine(Csv("Preset", Preset.ToString()));
                sb.AppendLine(Csv("OutputFolder", resolvedFolder));
                sb.AppendLine(Csv("ExportParentFolderName", ExportParentFolderName));
                sb.AppendLine(Csv("DashboardState", exportStatus));
                sb.AppendLine(Csv("FolderOpenStatus", folderOpenStatus));
                sb.AppendLine(Csv("DashboardElapsedSeconds", dashboardStartUtc == DateTime.MinValue ? "" : ((dashboardEndUtc != DateTime.MinValue ? dashboardEndUtc : DateTime.UtcNow) - dashboardStartUtc).TotalSeconds.ToString("0.0", CultureInfo.InvariantCulture)));
                sb.AppendLine(Csv("DashboardStartUtc", dashboardStartUtc == DateTime.MinValue ? "" : dashboardStartUtc.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)));
                sb.AppendLine(Csv("DashboardEndUtc", dashboardEndUtc == DateTime.MinValue ? "" : dashboardEndUtc.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)));
                sb.AppendLine(Csv("InventoryWritten", inventoryWritten ? "1" : "0"));
                sb.AppendLine(Csv("SettingsWritten", settingsWritten ? "1" : "0"));
                sb.AppendLine(Csv("MethodsWritten", methodsWritten ? "1" : "0"));
                sb.AppendLine(Csv("MatchedIndicators", matchedIndicatorCount));
                sb.AppendLine(Csv("ReadableSeriesHandles", seriesHandles == null ? 0 : seriesHandles.Count));
                sb.AppendLine(Csv("PlotRowsExported", plotRowsExported));
                sb.AppendLine(Csv("DrawAuditRowsExported", drawAuditRowsExported));
                sb.AppendLine(Csv("DrawEventsStored", drawEvents == null ? 0 : drawEvents.Count));
                sb.AppendLine(Csv("ReversalFeatureRowsExported", reversalFeatureRowsExported));
                sb.AppendLine(Csv("LiveSnapshotRowsExported", liveSnapshotRowsExported));
                sb.AppendLine(Csv("DiscoverySampleRowsExported", discoverySampleRowsExported));
                sb.AppendLine(Csv("PrivateFieldNameRowsExported", privateFieldNameRowsExported));
                sb.AppendLine(Csv("MethodRowsExported", methodsRowsExported));
                sb.AppendLine(Csv("SettingsRowsExported", settingsRowsExported));
                sb.AppendLine(Csv("SkippedNonRelevantDraws", skippedNonRelevantDraws));
                sb.AppendLine(Csv("SkippedDuplicateDraws", skippedDuplicateDraws));
                sb.AppendLine(Csv("CappedDrawObjectScans", cappedDrawObjects));
                sb.AppendLine(Csv("ErrorCount", errorCount));
                sb.AppendLine(Csv("WarningCount", warningCount));
                sb.AppendLine(Csv("FilesWritten", CountExistingOutputFiles()));
                sb.AppendLine(Csv("VolDelta_DeltaSourceSetting", volDeltaDeltaSourceSetting));
                sb.AppendLine(Csv("VolDelta_CvdModeSetting", volDeltaCvdModeSetting));
                sb.AppendLine(Csv("VolDelta_CvdResetModeSetting", volDeltaCvdResetModeSetting));
                sb.AppendLine(Csv("VolDelta_HistoryCacheSetting", volDeltaHistoryCacheSetting));
                sb.AppendLine(Csv("VolDelta_UseHistoryCacheFallback", volDeltaUseHistoryCacheFallbackSetting));
                sb.AppendLine(Csv("VolDelta_PreferCacheOnHistorical", volDeltaPreferCacheOnHistoricalSetting));
                sb.AppendLine(Csv("VolDelta_ComparableRows", volDeltaComparableRows));
                sb.AppendLine(Csv("VolDelta_AbsDeltaEqualsVolumeRows", volDeltaAbsDeltaEqualsVolumeRows));
                sb.AppendLine(Csv("VolDelta_AbsDeltaEqualsVolumeRate", volDeltaAbsDeltaEqualsVolumeRate.ToString("0.000000", CultureInfo.InvariantCulture)));
                sb.AppendLine(Csv("VolDelta_BuySellComparableRows", volDeltaBuySellComparableRows));
                sb.AppendLine(Csv("VolDelta_BuySellSumMismatchRows", volDeltaBuySellSumMismatchRows));
                sb.AppendLine(Csv("VolDelta_SourceQualityWarning", volDeltaLikelyProxyWarning));
                sb.AppendLine(Csv("ExporterDeltaMode", ExporterDeltaMode.ToString()));
                sb.AppendLine(Csv("NTVolumetricDelta_Status", ntVolumetricDeltaStatus));
                sb.AppendLine(Csv("NTVolumetricDelta_Rows", ntVolumetricDeltaRows));
                sb.AppendLine(Csv("NTVolumetricDelta_MissingRows", ntVolumetricDeltaMissingRows));
                sb.AppendLine(Csv("NTVolumetricDelta_ComparableRows", ntVolumetricComparableRows));
                sb.AppendLine(Csv("NTVolumetricDelta_BuySellSumMismatchRows", ntVolumetricBuySellSumMismatchRows));
                sb.AppendLine(Csv("NTVolumetricDelta_Warning", ntVolumetricDeltaWarning));
                sb.AppendLine(Csv("ActiveIndicatorFilter", activeIndicatorFilter));
                sb.AppendLine(Csv("ActiveDrawKeywords", activeDrawKeywords));
                sb.AppendLine(Csv("ActiveMaxPlotRows", activeMaxPlotRows));
                sb.AppendLine(Csv("ActiveHistoricalScanEveryNBars", activeHistoricalScanEveryNBars));
                sb.AppendLine(Csv("ActiveRealtimeScanIntervalSeconds", activeRealtimeScanIntervalSeconds));
                sb.AppendLine(Csv("ActiveDeepDiscovery", activeDeepDiscovery));
                sb.AppendLine(Csv("ActiveExportDiscoverySamples", activeExportDiscoverySamples));
                sb.AppendLine(Csv("ActiveExportPrivateFieldNames", activeExportPrivateFieldNames));
                sb.AppendLine(Csv("ActiveMaxRawSeriesColumns", activeMaxRawSeriesColumns));
                sb.AppendLine(Csv("ActiveMaxDrawObjectsToScan", activeMaxDrawObjectsToScan));
                sb.AppendLine();

                sb.AppendLine("SeriesColumn,IndicatorType,SourceKind,SourceName,IndicatorName");
                if (seriesHandles != null)
                {
                    foreach (var h in seriesHandles)
                        sb.AppendLine(Csv(h.SafeColumnName, h.IndicatorType, h.SourceKind, h.SourceName, h.IndicatorName));
                }

                sb.AppendLine();
                sb.AppendLine("DrawIndicator,DrawCategory,Stage,Direction,Count");
                if (drawEvents != null)
                {
                    var groups = drawEvents.GroupBy(e => (e.InferredIndicator ?? "") + "|" + (e.InferredCategory ?? "") + "|" + (e.Stage ?? "") + "|" + (e.InferredDirection ?? ""));
                    foreach (var g in groups.OrderByDescending(g => g.Count()))
                    {
                        string[] parts = g.Key.Split('|');
                        sb.AppendLine(Csv(parts.Length > 0 ? parts[0] : "", parts.Length > 1 ? parts[1] : "", parts.Length > 2 ? parts[2] : "", parts.Length > 3 ? parts[3] : "", g.Count()));
                    }
                }

                File.WriteAllText(summaryPath, sb.ToString());
                summaryWritten = true;
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] WriteSummary error: " + ex.Message);
            }
        }

        private void WriteReadme()
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Flow42DataCapture_v0_17");
                sb.AppendLine("Run created: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.AppendLine("Preset: " + Preset);
                sb.AppendLine("Instrument: " + SafeInstrument());
                sb.AppendLine("BarsPeriod: " + SafeBarsPeriod());
                sb.AppendLine("Output folder: " + resolvedFolder);
                sb.AppendLine();
                sb.AppendLine("Install note:");
                sb.AppendLine("- Physical file location can be Documents\\NinjaTrader 8\\bin\\Custom\\Indicators\\Exporters\\Flow42DataCapture_v0_17.cs.");
                sb.AppendLine("- Namespace is NinjaTrader.NinjaScript.Indicators.Exporters so it appears under the Exporters UI folder.");
                sb.AppendLine("- Flow42CapturePreset_v0_17 enum is global-scope on purpose to avoid generated-code CS0246 errors.");
                sb.AppendLine();
                sb.AppendLine("Default workflow:");
                sb.AppendLine("1. Put Flow42 indicators on the chart first.");
                sb.AppendLine("2. Add Flow42DataCapture_v0_17 LAST.");
                sb.AppendLine("3. Default mode is Export_FullResearch: full loaded chart history, fast feature-matrix path, no row cap.");
                sb.AppendLine("4. Use DeepDiscovery_Safe once when you want near-exhaustive script-visible inspection without full raw matrices.");
                sb.AppendLine("5. Use DeepDiscovery_PrivateFieldNamesOnly when you only want private/non-public field names/types, without reading private values.");
                sb.AppendLine("6. Use OneIndicator_Fast if the full chart is too heavy or if a specific Flow42 tool needs diagnosis.");
                sb.AppendLine("7. For live-only DOM/liquidity context, use Probe_LiveVolLiqMeter during an active live session.");
                sb.AppendLine();
                sb.AppendLine("File interpretation:");
                sb.AppendLine("- Flow42_Inventory.csv: best first file. Look for PLOT, VALUES_SERIES, PUBLIC_PROPERTY_SeriesLike.");
                sb.AppendLine("- Flow42_PlotValues.csv: research-grade if the columns populate historically.");
                sb.AppendLine("- Flow42_DrawObject_Audit.csv: visual marker scrape. Useful, but weaker than Values[]/public Series.");
                sb.AppendLine("- Flow42_PublicMethods.csv: identifies public APIs; only known safe methods like HasSpikeOnBar are invoked.");
                sb.AppendLine("- Flow42_ReversalFeatures.csv: fixed feature skeleton for NQ reversal research; blanks mean no exposed matching source was found.");
                sb.AppendLine("  v0.17 keeps Flow42 VolDelta diagnostics plus exporter-calculated NT volumetric bid/ask delta / CVD, preferred-delta columns, chart data-quality dashboard checks, cleaner run folder names, and frozen elapsed time after final write.");
                sb.AppendLine("- Flow42_LivePanelSnapshot.csv: optional live capture, especially for VolLiqMeter/DOM style values.");
                sb.AppendLine("- Flow42_DiscoverySamples.csv: DeepDiscovery_Safe sample values for every discovered readable series/field/property.");
                sb.AppendLine("- Flow42_PrivateFieldNames.csv: metadata-only private/non-public field names/types; values are intentionally not read.");
                sb.AppendLine();
                sb.AppendLine("Active settings:");
                sb.AppendLine("ExporterDeltaMode=" + ExporterDeltaMode);
                sb.AppendLine("activeIndicatorFilter=" + activeIndicatorFilter);
                sb.AppendLine("activeDrawKeywords=" + activeDrawKeywords);
                sb.AppendLine("activeIncludeAllIndicators=" + activeIncludeAllIndicators);
                sb.AppendLine("activeDoExposureProbe=" + activeDoExposureProbe);
                sb.AppendLine("activeExportSettingsSnapshot=" + activeExportSettingsSnapshot);
                sb.AppendLine("activeExportPublicMethods=" + activeExportPublicMethods);
                sb.AppendLine("activeExportPlotValues=" + activeExportPlotValues);
                sb.AppendLine("activeExportDrawAudit=" + activeExportDrawAudit);
                sb.AppendLine("activeExportReversalFeatures=" + activeExportReversalFeatures);
                sb.AppendLine("activeExportLiveSnapshots=" + activeExportLiveSnapshots);
                sb.AppendLine("activeInvokeKnownSafeMethods=" + activeInvokeKnownSafeMethods);
                sb.AppendLine("activeDeepDiscovery=" + activeDeepDiscovery);
                sb.AppendLine("activeExportDiscoverySamples=" + activeExportDiscoverySamples);
                sb.AppendLine("activeExportPrivateFieldNames=" + activeExportPrivateFieldNames);
                sb.AppendLine("activeMaxPlotRows=" + activeMaxPlotRows);
                sb.AppendLine("activeHistoricalScanEveryNBars=" + activeHistoricalScanEveryNBars);
                sb.AppendLine("activeRealtimeScanIntervalSeconds=" + activeRealtimeScanIntervalSeconds);

                File.WriteAllText(readmePath, sb.ToString());
            }
            catch (Exception ex)
            {
                RecordError("[Flow42DataCapture] WriteReadme error: " + ex.Message);
            }
        }

        // --------------------------------------------------------------------
        // Reflection / series helpers
        // --------------------------------------------------------------------
        private object SafeGetPropertyValue(object obj, string propName)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(propName))
                    return null;
                PropertyInfo p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (p == null || !p.CanRead || p.GetIndexParameters().Length > 0)
                    return null;
                return p.GetValue(obj, null);
            }
            catch { return null; }
        }

        private string SafeGetStringProperty(object obj, string propName)
        {
            try
            {
                object v = SafeGetPropertyValue(obj, propName);
                return v == null ? "" : v.ToString();
            }
            catch { return ""; }
        }

        private bool CanReadAsSeries(object obj)
        {
            if (obj == null)
                return false;
            try
            {
                Type t = obj.GetType();
                MethodInfo m = t.GetMethod("GetValueAt", new Type[] { typeof(int) });
                if (m != null)
                    return true;

                PropertyInfo item = t.GetProperty("Item");
                if (item != null && item.GetIndexParameters().Length == 1)
                    return true;
            }
            catch { }
            return false;
        }

        private string ReadSeriesCurrentAsString(object series)
        {
            return ReadSeriesValueAtAsString(series, CurrentBar);
        }

        private string ReadSeriesValueAtAsString(object series, int barIndex)
        {
            try
            {
                if (series == null)
                    return "";

                Type t = series.GetType();
                MethodInfo m = t.GetMethod("GetValueAt", new Type[] { typeof(int) });
                if (m != null)
                {
                    object val = m.Invoke(series, new object[] { barIndex });
                    return FormatAnyValue(val);
                }

                PropertyInfo item = t.GetProperty("Item");
                if (item != null && item.GetIndexParameters().Length == 1)
                {
                    int barsAgo = Math.Max(0, CurrentBar - barIndex);
                    object val = item.GetValue(series, new object[] { barsAgo });
                    return FormatAnyValue(val);
                }
            }
            catch { }
            return "";
        }

        private string FormatAnyValue(object val)
        {
            if (val == null)
                return "";
            if (val is double)
                return Fmt((double)val);
            if (val is float)
                return ((float)val).ToString("0.########", CultureInfo.InvariantCulture);
            if (val is decimal)
                return ((decimal)val).ToString(CultureInfo.InvariantCulture);
            if (val is int || val is long || val is short || val is byte)
                return Convert.ToString(val, CultureInfo.InvariantCulture);
            if (val is bool)
                return ((bool)val) ? "1" : "0";
            if (val is DateTime)
                return ((DateTime)val).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            return SafeToString(val);
        }

        private string ClassifyPropertyKind(Type t)
        {
            if (t == null)
                return "Unknown";
            if (t.IsEnum)
                return "Enum";
            if (IsSimpleReportableType(t))
                return "Scalar";
            if (typeof(IEnumerable).IsAssignableFrom(t) && t != typeof(string))
                return "Enumerable";
            if (t.FullName != null && (t.FullName.IndexOf("Series", StringComparison.OrdinalIgnoreCase) >= 0 || t.FullName.IndexOf("ISeries", StringComparison.OrdinalIgnoreCase) >= 0))
                return "SeriesLike";
            return "Object";
        }

        private bool IsSimpleReportableType(Type t)
        {
            if (t == null)
                return false;
            return t == typeof(double) || t == typeof(float) || t == typeof(decimal) ||
                   t == typeof(int) || t == typeof(long) || t == typeof(short) || t == typeof(byte) ||
                   t == typeof(bool) || t == typeof(string) || t == typeof(DateTime) ||
                   t == typeof(TimeSpan);
        }

        private string SafeTypeName(object o)
        {
            return o == null ? "" : (o.GetType().FullName ?? o.GetType().Name);
        }

        private string SafeToString(object o)
        {
            try { return o == null ? "" : o.ToString(); }
            catch { return ""; }
        }

        // --------------------------------------------------------------------
        // Draw extraction helpers
        // --------------------------------------------------------------------
        private string SafeGetText(IDrawingTool draw)
        {
            try
            {
                var asText = draw as NinjaTrader.NinjaScript.DrawingTools.Text;
                if (asText != null)
                    return asText.DisplayText ?? "";

                string[] candidates = { "DisplayText", "Text", "Label", "Caption", "Name", "Content" };
                foreach (string propName in candidates)
                {
                    object v = SafeGetPropertyValue(draw, propName);
                    if (v is string && !string.IsNullOrEmpty((string)v))
                        return (string)v;
                }
            }
            catch { }
            return "";
        }

        private double SafeGetPrice(IDrawingTool draw)
        {
            try
            {
                if (draw.Anchors != null && draw.Anchors.Count() > 0)
                {
                    var anchor = draw.Anchors.First();
                    if (anchor != null)
                        return anchor.Price;
                }
            }
            catch { }
            return 0;
        }

        private DateTime SafeGetTime(IDrawingTool draw)
        {
            try
            {
                if (draw.Anchors != null && draw.Anchors.Count() > 0)
                {
                    var anchor = draw.Anchors.First();
                    if (anchor != null)
                        return anchor.Time;
                }
            }
            catch { }
            return DateTime.MinValue;
        }

        private string SafeGetOwner(IDrawingTool draw)
        {
            try
            {
                object owner = SafeGetPropertyValue(draw, "Owner");
                if (owner == null)
                    return "";
                return owner.GetType().Name + ":" + SafeToString(owner);
            }
            catch { return ""; }
        }

        private string SafeGetColor(IDrawingTool draw)
        {
            string[] brushProps = { "TextBrush", "Stroke", "OutlineStroke", "AreaBrush", "Brush", "BackBrush", "BorderBrush" };
            foreach (string name in brushProps)
            {
                try
                {
                    object val = SafeGetPropertyValue(draw, name);
                    if (val == null)
                        continue;

                    object brushObj = val;
                    PropertyInfo brushProp = val.GetType().GetProperty("Brush");
                    if (brushProp != null)
                        brushObj = brushProp.GetValue(val, null);

                    SolidColorBrush brush = brushObj as SolidColorBrush;
                    if (brush != null)
                    {
                        var c = brush.Color;
                        return string.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
                    }
                }
                catch { }
            }
            return "";
        }

        private string InferFlow42Indicator(string blob)
        {
            if (ContainsAny(blob, "AbsorptionMap,Absorption Map")) return "AbsorptionMap";
            if (ContainsAny(blob, "VolImbalance,Imbalance")) return "VolImbalance";
            if (ContainsAny(blob, "VolDynamics,Dynamics")) return "VolDynamics";
            if (ContainsAny(blob, "VolDrive,Drive")) return "VolDrive";
            if (ContainsAny(blob, "ChopState,Chop")) return "ChopState";
            if (ContainsAny(blob, "VolSpike,Spike")) return "VolSpike";
            if (ContainsAny(blob, "VolLiqMeter,LiqMeter,Liquidity,DOM")) return "VolLiqMeter";
            if (ContainsAny(blob, "VolDelta,CVD,Delta,RelativeDeltaPressure")) return "VolDelta";
            if (ContainsAny(blob, "CloudNotes,Cloud Notes,Cloud,Level")) return "CloudNotes";
            if (ContainsAny(blob, "Flow42,Flow.42")) return "Flow42Unknown";
            return "Unknown";
        }

        private string InferFlow42Category(string blob)
        {
            if (ContainsAny(blob, "Absorption,Absorb,Absorbed,Abs")) return "Absorption";
            if (ContainsAny(blob, "Exhaustion,Exhaust,Exh")) return "Exhaustion";
            if (ContainsAny(blob, "Imbalance,Imb,Cluster,Stacked")) return "Imbalance";
            if (ContainsAny(blob, "Spike,ZScore,Z-Score")) return "Spike";
            if (ContainsAny(blob, "Surge,VolumeSurge")) return "Surge";
            if (ContainsAny(blob, "Push,VolumePush,BreakOut,Initiation")) return "VolumePush";
            if (ContainsAny(blob, "Delta,CVD,RelativeDeltaPressure,Pressure")) return "DeltaCVD";
            if (ContainsAny(blob, "Chop,Trend,Regime,Breakout")) return "Regime";
            if (ContainsAny(blob, "Liquidity,Liq,DOM,Depth,Book,Aggressor")) return "Liquidity";
            if (ContainsAny(blob, "CloudNotes,Level,PDH,PDL,ONH,ONL,VWAP,Gamma")) return "Level";
            if (ContainsAny(blob, "Long,Short,Signal,Arrow,Buy,Sell")) return "Signal";
            return "Unknown";
        }

        private string InferStage(string blob)
        {
            if (ContainsAny(blob, "LiveWarning,Live Warning,Warning")) return "LiveWarning";
            if (ContainsAny(blob, "Candidate,Cand")) return "Candidate";
            if (ContainsAny(blob, "Provisional,Prov")) return "Provisional";
            if (ContainsAny(blob, "Confirmed,Confirm")) return "Confirmed";
            if (ContainsAny(blob, "Weak")) return "Weak";
            if (ContainsAny(blob, "Strong")) return "Strong";
            return "";
        }

        private string InferDirection(string blob, string color)
        {
            string s = blob ?? "";
            if (s.IndexOf("▲", StringComparison.OrdinalIgnoreCase) >= 0 || s.IndexOf("↑", StringComparison.OrdinalIgnoreCase) >= 0) return "UP";
            if (s.IndexOf("▼", StringComparison.OrdinalIgnoreCase) >= 0 || s.IndexOf("↓", StringComparison.OrdinalIgnoreCase) >= 0) return "DOWN";
            if (ContainsAny(s, "Long,Bull,Bullish,Buy,Up,Ask Absorbed,Sell Absorbed")) return "UP";
            if (ContainsAny(s, "Short,Bear,Bearish,Sell,Down,Bid Absorbed,Buy Absorbed")) return "DOWN";
            return "";
        }

        private string BuildDrawDataQuality(DateTime t, double price, string owner, string text, string tag)
        {
            var notes = new List<string>();
            if (t == DateTime.MinValue) notes.Add("NO_TIME");
            if (price == 0) notes.Add("NO_PRICE");
            if (string.IsNullOrEmpty(owner)) notes.Add("NO_OWNER");
            if (string.IsNullOrEmpty(text)) notes.Add("NO_TEXT");
            if (string.IsNullOrEmpty(tag)) notes.Add("NO_TAG");
            return notes.Count == 0 ? "OK" : string.Join("|", notes.ToArray());
        }

        // --------------------------------------------------------------------
        // General helpers
        // --------------------------------------------------------------------
        private List<string> BaseBarFields(string triggeredBy, int barIndex)
        {
            return new List<string>
            {
                runId,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                triggeredBy,
                SafeInstrument(),
                SafeBarsPeriod(),
                barIndex.ToString(CultureInfo.InvariantCulture),
                SafeBarTime(barIndex).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                Fmt(SafeOpen(barIndex)),
                Fmt(SafeHigh(barIndex)),
                Fmt(SafeLow(barIndex)),
                Fmt(SafeClose(barIndex)),
                Fmt(SafeVolume(barIndex))
            };
        }

        private double SafeOpen(int i) { try { return Opens[0].GetValueAt(i); } catch { return double.NaN; } }
        private double SafeHigh(int i) { try { return Highs[0].GetValueAt(i); } catch { return double.NaN; } }
        private double SafeLow(int i) { try { return Lows[0].GetValueAt(i); } catch { return double.NaN; } }
        private double SafeClose(int i) { try { return Closes[0].GetValueAt(i); } catch { return double.NaN; } }
        private double SafeVolume(int i) { try { return Volumes[0].GetValueAt(i); } catch { return double.NaN; } }

        private DateTime SafeBarTime(int i)
        {
            try { return Bars.GetTime(i); }
            catch { return DateTime.MinValue; }
        }

        private int SafeBarsGetBar(DateTime t)
        {
            try { return Bars.GetBar(t); }
            catch { return -1; }
        }

        private string SafeInstrument()
        {
            try { return Instrument == null ? "" : Instrument.FullName; }
            catch { return ""; }
        }

        private string SafeBarsPeriod()
        {
            try
            {
                string baseText = SafeBarsPeriodTypeText();
                if (IsPrimaryVolumetricBarsType() && baseText.IndexOf("Volumetric", StringComparison.OrdinalIgnoreCase) < 0)
                    return baseText + " Volumetric";
                return baseText;
            }
            catch
            {
                try { return BarsPeriod == null ? "" : BarsPeriod.ToString(); }
                catch { return ""; }
            }
        }

        private bool IsPrimaryVolumetricBarsType()
        {
            try
            {
                if (BarsArray == null || BarsArray.Length == 0 || BarsArray[0] == null)
                    return false;

                return BarsArray[0].BarsType is VolumetricBarsType;
            }
            catch
            {
                return false;
            }
        }

        private string SafeBarsPeriodTypeText()
        {
            try
            {
                if (BarsPeriod == null)
                    return "Unknown";

                if (IsPrimaryVolumetricBarsType() || BarsPeriod.BarsPeriodType.ToString().IndexOf("Volumetric", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string baseType = TryReadBarsPeriodString("BaseBarsPeriodType", "Minute");
                    int baseValue = TryReadBarsPeriodInt("BaseBarsPeriodValue", BarsPeriod.Value);
                    if (baseValue <= 0)
                        baseValue = BarsPeriod.Value > 0 ? BarsPeriod.Value : 1;

                    return SafeBarsDescriptorText(baseType, baseValue);
                }

                return SafeBarsDescriptorText(BarsPeriod.BarsPeriodType.ToString(), BarsPeriod.Value);
            }
            catch
            {
                return "Unknown";
            }
        }

        private string SafeBarsDescriptorText(string typeText, int value)
        {
            try
            {
                if (value <= 0)
                    value = 1;

                string t = string.IsNullOrWhiteSpace(typeText) ? "" : typeText.Trim();

                if (t.IndexOf("Minute", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Min";
                if (t.IndexOf("Second", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Sec";
                if (t.IndexOf("Tick", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Tick";
                if (t.IndexOf("Volume", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Volume";
                if (t.IndexOf("Range", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Range";
                if (t.IndexOf("Day", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Day";
                if (t.IndexOf("Week", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Week";
                if (t.IndexOf("Month", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Month";
                if (t.IndexOf("Year", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + " Year";

                return value.ToString(CultureInfo.InvariantCulture) + " " + t;
            }
            catch
            {
                return value.ToString(CultureInfo.InvariantCulture) + " Bars";
            }
        }

        private string SafeBarsDescriptorFolder(string typeText, int value)
        {
            try
            {
                if (value <= 0)
                    value = 1;

                string t = string.IsNullOrWhiteSpace(typeText) ? "" : typeText.Trim();

                if (t.IndexOf("Minute", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Min";
                if (t.IndexOf("Second", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Sec";
                if (t.IndexOf("Tick", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Tick";
                if (t.IndexOf("Volume", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Volume";
                if (t.IndexOf("Range", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Range";
                if (t.IndexOf("Day", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Day";
                if (t.IndexOf("Week", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Week";
                if (t.IndexOf("Month", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Month";
                if (t.IndexOf("Year", StringComparison.OrdinalIgnoreCase) >= 0)
                    return value.ToString(CultureInfo.InvariantCulture) + "Year";

                return value.ToString(CultureInfo.InvariantCulture) + MakeSafeFolderName(t);
            }
            catch
            {
                return value.ToString(CultureInfo.InvariantCulture) + "Bars";
            }
        }

        private string SafeBarsFolderToken()
        {
            try
            {
                string baseToken;
                if (BarsPeriod == null)
                    baseToken = "UnknownBars";
                else if (IsPrimaryVolumetricBarsType() || BarsPeriod.BarsPeriodType.ToString().IndexOf("Volumetric", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string baseType = TryReadBarsPeriodString("BaseBarsPeriodType", "Minute");
                    int baseValue = TryReadBarsPeriodInt("BaseBarsPeriodValue", BarsPeriod.Value);
                    if (baseValue <= 0)
                        baseValue = BarsPeriod.Value > 0 ? BarsPeriod.Value : 1;

                    baseToken = SafeBarsDescriptorFolder(baseType, baseValue);
                }
                else
                {
                    baseToken = SafeBarsDescriptorFolder(BarsPeriod.BarsPeriodType.ToString(), BarsPeriod.Value);
                }

                string dataMode;
                if (IsPrimaryVolumetricBarsType())
                    dataMode = "Volumetric";
                else if (BarsPeriod != null && BarsPeriod.BarsPeriodType == BarsPeriodType.Minute)
                    dataMode = "Candle";
                else if (BarsPeriod != null && BarsPeriod.BarsPeriodType == BarsPeriodType.Range)
                    dataMode = "Range";
                else
                    dataMode = "Standard";

                return MakeSafeFolderName(baseToken + "_" + dataMode);
            }
            catch
            {
                return MakeSafeFolderName(SafeBarsPeriod()).Replace(" ", "");
            }
        }

        private string TryReadBarsPeriodString(string propertyName, string fallback)
        {
            try
            {
                if (BarsPeriod == null || string.IsNullOrWhiteSpace(propertyName))
                    return fallback;

                var prop = BarsPeriod.GetType().GetProperty(propertyName);
                if (prop == null)
                    return fallback;

                object value = prop.GetValue(BarsPeriod, null);
                return value == null ? fallback : value.ToString();
            }
            catch
            {
                return fallback;
            }
        }

        private int TryReadBarsPeriodInt(string propertyName, int fallback)
        {
            try
            {
                if (BarsPeriod == null || string.IsNullOrWhiteSpace(propertyName))
                    return fallback;

                var prop = BarsPeriod.GetType().GetProperty(propertyName);
                if (prop == null)
                    return fallback;

                object value = prop.GetValue(BarsPeriod, null);
                if (value == null)
                    return fallback;

                int parsed;
                if (int.TryParse(value.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out parsed))
                    return parsed;

                return fallback;
            }
            catch
            {
                return fallback;
            }
        }

        private string SafeInstrumentFolderToken()
        {
            try
            {
                string instrument = SafeInstrument();
                if (string.IsNullOrWhiteSpace(instrument))
                    return "UnknownInstrument";

                instrument = instrument.Trim().Replace(" ", ".");
                return MakeSafeFolderName(instrument);
            }
            catch
            {
                return "UnknownInstrument";
            }
        }

        private string SafeInstrumentFileShortToken()
        {
            try
            {
                string instrument = SafeInstrumentFolderToken();
                if (string.IsNullOrWhiteSpace(instrument))
                    return "UnknownInstrument";

                return MakeSafeFolderName(instrument).Replace(".", "").Replace("-", "").Replace("_", "");
            }
            catch
            {
                return "UnknownInstrument";
            }
        }

        private string SafeDateRangeFileCompactToken()
        {
            try
            {
                DateTime first = SafeFirstLoadedBarTime();
                DateTime last = SafeLastLoadedBarTime();

                if (first == DateTime.MinValue || last == DateTime.MinValue)
                    return "UnknownDates";

                return first.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "-" +
                    last.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return "UnknownDates";
            }
        }

        private string SafeExportFileStampToken()
        {
            return DateTime.Now.ToString("yyyyMMdd-hmmtt", CultureInfo.InvariantCulture);
        }

        private string SafeBarsFileToken()
        {
            try
            {
                string token = SafeBarsFolderToken();
                if (string.IsNullOrWhiteSpace(token))
                    return "UnknownBars";

                token = token.Replace("_Volumetric", "Vol")
                             .Replace("_Candle", "Candle")
                             .Replace("_Range", "Range")
                             .Replace("_Standard", "Std");

                return MakeSafeFolderName(token).Replace(".", "").Replace("-", "").Replace("_", "");
            }
            catch
            {
                return "UnknownBars";
            }
        }

        private string SafeTickCaptureFolderToken()
        {
            // This exporter does not currently write raw historical tick-event files.
            // Volumetric bid/ask footprint data is still exported when the primary chart
            // is Order Flow Volumetric, but that is not the same as a raw tick tape export.
            // Keep this explicit in folder names so downstream research threads know whether
            // a separate tick-level dataset was recorded.
            return "NoTick";
        }

        private string TickCaptureQualityLabel()
        {
            return "Tick: " + SafeTickCaptureFolderToken();
        }

        private string SafePresetFolderToken()
        {
            try
            {
                string preset = Preset.ToString();
                preset = preset.Replace("Export_", "").Replace("Probe_", "");
                preset = preset.Replace("FullResearch", "FullResearch");
                return MakeSafeFolderName(preset).Replace("_", "");
            }
            catch
            {
                return "Preset";
            }
        }

        private DateTime SafeFirstLoadedBarTime()
        {
            try
            {
                if (Bars != null && Bars.Count > 0)
                    return Bars.GetTime(0);
            }
            catch { }
            return DateTime.MinValue;
        }

        private DateTime SafeLastLoadedBarTime()
        {
            try
            {
                if (Bars != null && Bars.Count > 0)
                    return Bars.GetTime(Bars.Count - 1);
            }
            catch { }
            return DateTime.MinValue;
        }

        private string SafeDateRangeFolderToken()
        {
            try
            {
                DateTime first = SafeFirstLoadedBarTime();
                DateTime last = SafeLastLoadedBarTime();

                if (first == DateTime.MinValue || last == DateTime.MinValue)
                    return "UnknownDates";

                return first.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture) + "_to_" +
                    last.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return "UnknownDates";
            }
        }

        
private string BuildRunFolderName()
        {
            // v0.17: dataset details live in parent folders. The run folder is just the export timestamp.
            return MakeSafeFolderName(SafeExportStampToken());
        }

        private string BuildFileBaseName()
        {
            // Compact self-describing file base for AI uploads.
            string fileBase = SafeInstrumentFileShortToken() + "_" +
                SafeDateRangeFileCompactToken() + "_" +
                SafeBarsFileToken() + "_" +
                SafeTickCaptureFolderToken() + "_" +
                SafePresetFolderToken() + "_" +
                SafeExportFileStampToken();

            return MakeSafeFolderName(fileBase);
        }

        private string SafeExportStampToken()
        {
            return DateTime.Now.ToString("yyyy.MM.dd-h.mmtt", CultureInfo.InvariantCulture);
        }

        private string SafeExportDateFolderToken()
        {
            return DateTime.Now.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
        }

        private string SafeInstrumentFamilyFolderToken()
        {
            try
            {
                string instrument = SafeInstrument();
                if (!string.IsNullOrWhiteSpace(instrument))
                {
                    string first = instrument.Trim().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (!string.IsNullOrWhiteSpace(first))
                        return MakeSafeFolderName(first).ToUpperInvariant();
                }
            }
            catch { }

            return "Instrument";
        }

        private string SafeShortDateRangeFileToken()
        {
            return SafeDateRangeFileCompactToken();
        }


        private string PrimaryDataQualityLabel()
        {
            bool vol = IsPrimaryVolumetricBarsType();
            string period = SafeBarsPeriodTypeText();

            if (vol)
                return "Data Type: " + period + " Volumetric ✓";

            return "Data Type: " + period + " Standard ⚠";
        }

        private string DeltaSourceQualityLabel()
        {
            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Disabled)
                return "Delta: Disabled";
            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.Flow42VolDeltaOnly)
                return "Delta: Flow42 VolDelta";

            if (IsPrimaryVolumetricBarsType())
                return "Delta: Chart Bid/Ask ✓";

            if (ExporterDeltaMode == Flow42ExporterDeltaMode_v0_17.NTVolumetricBidAskOnly)
                return "Delta: Missing NT Volumetric ⚠";

            return "Delta: Flow42 fallback ⚠";
        }

        private string DashboardDataQualityLine()
        {
            return PrimaryDataQualityLabel() + "   " + DeltaSourceQualityLabel() + "   " + TickCaptureQualityLabel();
        }

        
private string ResolveRunFolder(string root)
        {
            if (string.IsNullOrWhiteSpace(root))
                root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"NinjaTrader 8\NinjaTrader 8 - Chart Data Exports");

            string rootFull = Path.GetFullPath(root);
            string instrumentFamilyFolder = SafeInstrumentFamilyFolderToken();
            string contractFolder = SafeInstrumentFolderToken();
            string dateRangeFolder = SafeDateRangeFolderToken();
            string barsDataFolder = SafeBarsFolderToken();
            string parentName = string.IsNullOrWhiteSpace(ExportParentFolderName) ? "Flow42DataCapture" : ExportParentFolderName.Trim();
            string exporterFolder = MakeSafeFolderName(parentName);
            string exportTypeFolder = MakeSafeFolderName(SafePresetFolderToken() + "_" + SafeTickCaptureFolderToken());

            // Dataset-first layout:
            // Chart Data Exports\<InstrumentFamily>\<Contract>\<DataStart_to_DataEnd>\<Bars_DataMode>\<Flow42DataCapture>\<Preset_TickMode>\<ExportTimestamp>
            string parentFolder = Path.Combine(rootFull, instrumentFamilyFolder, contractFolder, dateRangeFolder, barsDataFolder, exporterFolder, exportTypeFolder);

            if (!UseTimestampedRunFolder)
                return parentFolder;

            return MakeUniqueOutputFolder(parentFolder, BuildRunFolderName());
        }

        private string MakeUniqueOutputFolder(string parentFolder, string runFolderName)
        {
            string safeRunFolderName = MakeSafeFolderName(runFolderName);
            if (string.IsNullOrWhiteSpace(safeRunFolderName))
                safeRunFolderName = DateTime.Now.ToString("yyyy.MM.dd-h.mmtt", CultureInfo.InvariantCulture) + "-Flow42Export";

            string candidate = Path.Combine(parentFolder, safeRunFolderName);

            int n = 2;
            while (Directory.Exists(candidate))
            {
                candidate = Path.Combine(parentFolder, safeRunFolderName + "-Run" + n.ToString(CultureInfo.InvariantCulture));
                n++;
            }

            return candidate;
        }

        private void MaybeOpenFolder(string triggeredBy)
        {
            if (!OpenFolderWhenDone || openedFolder)
                return;

            try
            {
                if (Directory.Exists(resolvedFolder))
                {
                    Process.Start("explorer.exe", "\"" + resolvedFolder + "\"");
                    openedFolder = true;
                    folderOpenStatus = "Opened after " + triggeredBy;
                    Print("[Flow42DataCapture] Opened output folder after " + triggeredBy + ": " + resolvedFolder);
                    UpdateDashboardSafe();
                }
                else
                {
                    warningCount++;
                    folderOpenStatus = "Folder missing; path logged";
                    Print("[Flow42DataCapture] Output folder did not exist when attempting to open: " + resolvedFolder);
                    UpdateDashboardSafe();
                }
            }
            catch (Exception ex)
            {
                warningCount++;
                folderOpenStatus = "Open failed; path logged";
                Print("[Flow42DataCapture] Could not open output folder. Path: " + resolvedFolder + " | Error: " + ex.Message);
                UpdateDashboardSafe();
            }
        }

        private int CountExistingOutputFiles()
        {
            try
            {
                int count = 0;
                string[] paths = new string[] { inventoryPath, settingsPath, methodsPath, plotValuesPath, drawAuditPath, reversalFeaturesPath, liveSnapshotPath, discoverySamplesPath, privateFieldNamesPath, summaryPath, readmePath };
                foreach (string p in paths)
                {
                    if (!string.IsNullOrEmpty(p) && File.Exists(p) && new FileInfo(p).Length > 0)
                        count++;
                }
                return count;
            }
            catch { return 0; }
        }

        private string MakeSafeFolderName(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "";
            string s = raw.Trim();
            foreach (char c in Path.GetInvalidFileNameChars())
                s = s.Replace(c, '_');
            s = s.Replace(':', '-');
            while (s.Contains("  "))
                s = s.Replace("  ", " ");
            return s.Trim();
        }

        private void SetStatus(string state, string message)
        {
            exportStatus = string.IsNullOrWhiteSpace(state) ? exportStatus : state;
            lastStatusMessage = message ?? "";
            UpdateDashboardSafe();
        }

        private void RecordError(string message)
        {
            errorCount++;
            exportStatus = "Error";
            lastStatusMessage = message ?? "";
            try { Print(message); } catch { }
            UpdateDashboardSafe();
        }

        private void UpdateDashboardSafe()
        {
            try
            {
                if (!ShowStatusDashboard)
                    return;

                // Remove legacy fixed text from this script instance. This keeps the chart clean.
                if (!dashboardLegacyTextRemoved)
                {
                    try { RemoveDrawObject(DashboardLegacyTextTag); } catch { }
                    dashboardLegacyTextRemoved = true;
                }

                dashboardProgressPercent = CalculateDashboardProgressPercent();
                dashboardFilesWritten = CountExistingOutputFiles();
                dashboardRowsCached = DashboardTotalRowsExported();

                RequestDashboardRefresh(false);
            }
            catch { }
        }

        // --------------------------------------------------------------------
        // Compact navy-glass export HUD
        // --------------------------------------------------------------------
        protected override void OnRender(ChartControl chartControl, ChartScale chartScale)
        {
            base.OnRender(chartControl, chartScale);

            try
            {
                if (!ShowStatusDashboard || ChartPanel == null || RenderTarget == null)
                    return;

                EnsureDashboardMouseHooked();

                string status = string.IsNullOrEmpty(exportStatus) ? "Idle" : exportStatus;
                string title = DashboardTitle(status);
                string message = DashboardMessage(status);
                string stats = DashboardStatsLine();
                string dataLine = DashboardDataQualityLine();
                string fileLocation = DashboardLocationLine();

                double target = ClampDashboard(CalculateDashboardProgressPercent(), 0, 100);
                dashboardProgressPercent = target;

                if (double.IsNaN(dashboardAnimatedPercent) || double.IsInfinity(dashboardAnimatedPercent))
                    dashboardAnimatedPercent = target;

                // Smooth fill motion; no export logic depends on the animated value.
                dashboardAnimatedPercent += (target - dashboardAnimatedPercent) * 0.22;
                if (Math.Abs(dashboardAnimatedPercent - target) < 0.20)
                    dashboardAnimatedPercent = target;

                bool complete = finalExportCompleted || string.Equals(status, "Complete", StringComparison.OrdinalIgnoreCase);
                bool isError = errorCount > 0 || string.Equals(status, "Error", StringComparison.OrdinalIgnoreCase);
                bool isWarning = !isError && (warningCount > 0 || string.Equals(status, "Warning", StringComparison.OrdinalIgnoreCase));

                float panelW = 520f;
                float panelH = 150f;
                float marginX = 22f;
                float marginY = 30f;
                float radius = 18f;

                float x = (float)(ChartPanel.X + ChartPanel.W) - panelW - marginX;
                float y = (float)ChartPanel.Y + marginY;

                // Keep the HUD visible on very narrow panes.
                if (x < ChartPanel.X + 8)
                    x = (float)ChartPanel.X + 8;

                SharpDX.RectangleF panelRect = new SharpDX.RectangleF(x, y, panelW, panelH);
                SharpDX.RectangleF shadowRect = DashboardOffset(panelRect, 0, 5);
                SharpDX.RectangleF glowRect = DashboardInflate(panelRect, 4, 4);

                SharpDX.RectangleF titleRect = new SharpDX.RectangleF(x + 18, y + 12, panelW - 158, 22);
                SharpDX.RectangleF pctRect = new SharpDX.RectangleF(x + panelW - 136, y + 12, 74, 22);
                SharpDX.RectangleF messageRect = new SharpDX.RectangleF(x + 18, y + 37, panelW - 36, 18);
                SharpDX.RectangleF dataRect = new SharpDX.RectangleF(x + 18, y + 58, panelW - 36, 16);
                SharpDX.RectangleF trackRect = new SharpDX.RectangleF(x + 18, y + 84, panelW - 36, 13);
                SharpDX.RectangleF statsRect = new SharpDX.RectangleF(x + 18, y + 105, panelW - 36, 15);
                SharpDX.RectangleF locationRect = new SharpDX.RectangleF(x + 18, y + 127, panelW - 36, 15);
                dashboardLastFolderHitRect = new SharpDX.RectangleF(locationRect.X, locationRect.Y - 6, locationRect.Width, locationRect.Height + 12);

                float fillWidth = (float)(trackRect.Width * ClampDashboard(dashboardAnimatedPercent, 0, 100) / 100.0);
                SharpDX.RectangleF fillRect = new SharpDX.RectangleF(trackRect.X, trackRect.Y, Math.Max(0, fillWidth), trackRect.Height);

                SharpDX.Color4 accentA = isError
                    ? new SharpDX.Color4(1.00f, 0.36f, 0.48f, 1.00f)
                    : isWarning
                        ? new SharpDX.Color4(1.00f, 0.80f, 0.34f, 1.00f)
                        : new SharpDX.Color4(0.74f, 1.00f, 0.43f, 1.00f);

                SharpDX.Color4 accentB = isError
                    ? new SharpDX.Color4(1.00f, 0.58f, 0.68f, 1.00f)
                    : isWarning
                        ? new SharpDX.Color4(1.00f, 0.95f, 0.56f, 1.00f)
                        : new SharpDX.Color4(0.42f, 1.00f, 0.84f, 1.00f);

                SharpDX.Color4 panelTop = new SharpDX.Color4(0.055f, 0.175f, 0.290f, 0.91f);   // lighter premium navy
                SharpDX.Color4 panelBottom = new SharpDX.Color4(0.025f, 0.075f, 0.145f, 0.93f);
                SharpDX.Color4 border = new SharpDX.Color4(0.52f, 0.84f, 0.95f, 0.40f);

                using (SharpDX.Direct2D1.SolidColorBrush shadowBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(0f, 0f, 0f, 0.26f)))
                using (SharpDX.Direct2D1.SolidColorBrush glowBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(accentA.Red, accentA.Green, accentA.Blue, 0.12f)))
                using (SharpDX.Direct2D1.SolidColorBrush borderBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, border))
                using (SharpDX.Direct2D1.SolidColorBrush topHighlightBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(1f, 1f, 1f, 0.12f)))
                using (SharpDX.Direct2D1.SolidColorBrush trackBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(0.13f, 0.23f, 0.32f, 0.74f)))
                using (SharpDX.Direct2D1.SolidColorBrush trackBorderBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(1f, 1f, 1f, 0.16f)))
                using (SharpDX.Direct2D1.SolidColorBrush textBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(0.98f, 0.99f, 1.00f, 1.00f)))
                using (SharpDX.Direct2D1.SolidColorBrush mutedBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(0.78f, 0.84f, 0.91f, 0.94f)))
                using (SharpDX.Direct2D1.SolidColorBrush linkBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(accentB.Red, accentB.Green, accentB.Blue, 0.96f)))
                using (SharpDX.DirectWrite.TextFormat titleFormat = new SharpDX.DirectWrite.TextFormat(NinjaTrader.Core.Globals.DirectWriteFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.Bold, SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 14.5f))
                using (SharpDX.DirectWrite.TextFormat smallFormat = new SharpDX.DirectWrite.TextFormat(NinjaTrader.Core.Globals.DirectWriteFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.Normal, SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 11.2f))
                using (SharpDX.DirectWrite.TextFormat tinyFormat = new SharpDX.DirectWrite.TextFormat(NinjaTrader.Core.Globals.DirectWriteFactory, "Segoe UI", SharpDX.DirectWrite.FontWeight.Normal, SharpDX.DirectWrite.FontStyle.Normal, SharpDX.DirectWrite.FontStretch.Normal, 10.0f))
                {
                    SharpDX.Direct2D1.GradientStop[] panelStops = new SharpDX.Direct2D1.GradientStop[]
                    {
                        new SharpDX.Direct2D1.GradientStop { Position = 0.0f, Color = panelTop },
                        new SharpDX.Direct2D1.GradientStop { Position = 1.0f, Color = panelBottom }
                    };

                    using (SharpDX.Direct2D1.GradientStopCollection panelStopCollection = new SharpDX.Direct2D1.GradientStopCollection(RenderTarget, panelStops))
                    using (SharpDX.Direct2D1.LinearGradientBrush panelBrush = new SharpDX.Direct2D1.LinearGradientBrush(
                        RenderTarget,
                        new SharpDX.Direct2D1.LinearGradientBrushProperties
                        {
                            StartPoint = new SharpDX.Vector2(panelRect.Left, panelRect.Top),
                            EndPoint = new SharpDX.Vector2(panelRect.Left, panelRect.Bottom)
                        },
                        panelStopCollection))
                    {
                        DashboardDrawRounded(glowRect, radius + 5, glowBrush, true, 0);
                        DashboardDrawRounded(shadowRect, radius, shadowBrush, true, 0);
                        DashboardDrawRounded(panelRect, radius, panelBrush, true, 0);
                        DashboardDrawRounded(panelRect, radius, borderBrush, false, 1.0f);
                    }

                    RenderTarget.DrawLine(new SharpDX.Vector2(x + radius + 4, y + 1.1f), new SharpDX.Vector2(x + panelW - radius - 4, y + 1.1f), topHighlightBrush, 0.8f);

                    DashboardDrawStatusOrb(x + 18, y + 23, complete, isError, isWarning, accentA);

                    titleRect.X += 14;
                    titleRect.Width -= 14;
                    DashboardDrawTextClipped(DashboardTrim(title, 46), titleFormat, titleRect, textBrush);

                    titleFormat.TextAlignment = SharpDX.DirectWrite.TextAlignment.Trailing;
                    DashboardDrawTextClipped(complete ? "100%" : target.ToString("0", CultureInfo.InvariantCulture) + "%", titleFormat, pctRect, textBrush);
                    titleFormat.TextAlignment = SharpDX.DirectWrite.TextAlignment.Leading;

                    DashboardDrawTextClipped(DashboardTrim(message, 76), smallFormat, messageRect, isWarning ? linkBrush : mutedBrush);
                    DashboardDrawTextClipped(DashboardTrim(dataLine, 96), tinyFormat, dataRect, IsPrimaryVolumetricBarsType() ? linkBrush : mutedBrush);

                    DashboardDrawRounded(trackRect, trackRect.Height / 2f, trackBrush, true, 0);

                    if (fillRect.Width > 1f)
                    {
                        SharpDX.RectangleF fillGlowRect = DashboardInflate(fillRect, 3, 3);
                        using (SharpDX.Direct2D1.SolidColorBrush fillGlowBrush = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(accentA.Red, accentA.Green, accentA.Blue, 0.22f)))
                            DashboardDrawRounded(fillGlowRect, fillGlowRect.Height / 2f, fillGlowBrush, true, 0);

                        SharpDX.Direct2D1.GradientStop[] stops = new SharpDX.Direct2D1.GradientStop[]
                        {
                            new SharpDX.Direct2D1.GradientStop { Position = 0.0f, Color = accentA },
                            new SharpDX.Direct2D1.GradientStop { Position = 1.0f, Color = accentB }
                        };

                        using (SharpDX.Direct2D1.GradientStopCollection stopCollection = new SharpDX.Direct2D1.GradientStopCollection(RenderTarget, stops))
                        using (SharpDX.Direct2D1.LinearGradientBrush fillBrush = new SharpDX.Direct2D1.LinearGradientBrush(
                            RenderTarget,
                            new SharpDX.Direct2D1.LinearGradientBrushProperties
                            {
                                StartPoint = new SharpDX.Vector2(fillRect.Left, fillRect.Top),
                                EndPoint = new SharpDX.Vector2(fillRect.Right, fillRect.Top)
                            },
                            stopCollection))
                        {
                            DashboardDrawRounded(fillRect, trackRect.Height / 2f, fillBrush, true, 0);
                        }
                    }

                    DashboardDrawRounded(trackRect, trackRect.Height / 2f, trackBorderBrush, false, 0.8f);
                    DashboardDrawTextClipped(DashboardTrim(stats, 86), tinyFormat, statsRect, mutedBrush);

                    if (!string.IsNullOrWhiteSpace(fileLocation))
                    {
                        DashboardDrawTextClipped(DashboardTrim(fileLocation, 86), tinyFormat, locationRect, linkBrush);
                        RenderTarget.DrawLine(new SharpDX.Vector2(locationRect.X, locationRect.Bottom - 1.0f), new SharpDX.Vector2(locationRect.Right, locationRect.Bottom - 1.0f), linkBrush, 0.55f);
                    }

                    if (complete)
                        DashboardDrawCheckMark(x + panelW - 26, y + 23, accentA);

                    DashboardDrawSparkle(x + panelW - 31, y + panelH - 18, accentB);
                }
            }
            catch
            {
                // Rendering must never break the exporter.
            }
        }

        private void RequestDashboardRefresh(bool force)
        {
            try
            {
                if (ChartControl == null)
                    return;

                DateTime now = DateTime.UtcNow;
                if (!force && dashboardLastRefreshUtc != DateTime.MinValue && (now - dashboardLastRefreshUtc).TotalMilliseconds < 220)
                    return;

                dashboardLastRefreshUtc = now;

                System.Windows.Threading.Dispatcher dispatcher = ChartControl.Dispatcher;
                if (dispatcher == null)
                    return;

                if (dispatcher.CheckAccess())
                {
                    ForceRefresh();
                }
                else
                {
                    dispatcher.InvokeAsync(() =>
                    {
                        try { ForceRefresh(); }
                        catch { }
                    });
                }
            }
            catch { }
        }

        private double CalculateDashboardProgressPercent()
        {
            try
            {
                if (finalExportCompleted || string.Equals(exportStatus, "Complete", StringComparison.OrdinalIgnoreCase))
                    return 100;

                if (string.Equals(exportStatus, "Error", StringComparison.OrdinalIgnoreCase) && dashboardProgressPercent > 0)
                    return Math.Min(99, Math.Max(8, dashboardProgressPercent));

                if (!initialized)
                    return 3;

                double progress = 8;

                if (inventoryRequested)
                    progress = 13;
                if (inventoryWritten)
                    progress = 28;
                if (settingsWritten)
                    progress = Math.Max(progress, 34);
                if (methodsWritten)
                    progress = Math.Max(progress, 40);

                if (activeExportPlotValues || activeExportReversalFeatures || activeExportDrawAudit || activeExportDiscoverySamples || activeExportPrivateFieldNames)
                {
                    long totalRows = Math.Max(1, EstimateDashboardBarRows());
                    long doneRows = Math.Min(totalRows, Math.Max(0, dashboardRowsCached));

                    if (doneRows > 0)
                        progress = Math.Max(progress, 40 + 48.0 * doneRows / totalRows);
                }

                if (summaryWritten)
                    progress = Math.Max(progress, 94);

                return ClampDashboard(progress, 0, 99);
            }
            catch
            {
                return dashboardProgressPercent > 0 ? dashboardProgressPercent : 8;
            }
        }

        private long EstimateDashboardBarRows()
        {
            try
            {
                int lastBar = Bars == null ? CurrentBar : Math.Max(CurrentBar, Bars.Count - 1);
                if (lastBar < 1)
                    return 1;

                int firstBar = 0;
                if (activeMaxPlotRows > 0 && lastBar + 1 > activeMaxPlotRows)
                    firstBar = Math.Max(0, lastBar - activeMaxPlotRows + 1);

                return Math.Max(1, lastBar - firstBar + 1);
            }
            catch
            {
                return 1;
            }
        }

        private string DashboardTitle(string status)
        {
            if (string.Equals(status, "Complete", StringComparison.OrdinalIgnoreCase) || finalExportCompleted)
            {
                if (errorCount > 0)
                    return "Export Complete with Errors";
                if (warningCount > 0)
                    return "Export Complete with Warnings";
                return "Export Complete";
            }

            if (string.Equals(status, "Error", StringComparison.OrdinalIgnoreCase))
                return "Export Needs Attention";
            if (string.Equals(status, "Warning", StringComparison.OrdinalIgnoreCase))
                return "Export Finished with Warnings";
            if (string.Equals(status, "Initializing", StringComparison.OrdinalIgnoreCase))
                return "Preparing Flow42 Export";
            if (string.Equals(status, "Idle", StringComparison.OrdinalIgnoreCase))
                return "Flow42 Export Ready";

            return "Exporting Flow42 Data";
        }

        private string DashboardMessage(string status)
        {
            string msg = string.IsNullOrWhiteSpace(lastStatusMessage) ? "" : lastStatusMessage.Trim();

            if (finalExportCompleted)
            {
                if (errorCount > 0)
                    return "Finished with " + errorCount + " error" + (errorCount == 1 ? "" : "s") + ". Check NinjaScript Output.";
                if (warningCount > 0)
                {
                    string warning = DashboardShortWarning();
                    return string.IsNullOrWhiteSpace(warning)
                        ? "Finished with " + warningCount + " warning" + (warningCount == 1 ? "" : "s") + "."
                        : "Warning: " + warning;
                }
                return "All files finalized cleanly.";
            }

            if (!string.IsNullOrEmpty(msg))
                return msg;

            if (scanPending)
                return "Scanning chart draw objects...";

            return status;
        }

        private string DashboardStatsLine()
        {
            int files = dashboardFilesWritten;
            long rows = dashboardRowsCached;

            string elapsed = "";
            try
            {
                if (dashboardStartUtc != DateTime.MinValue)
                {
                    DateTime elapsedEndUtc = dashboardEndUtc != DateTime.MinValue ? dashboardEndUtc : DateTime.UtcNow;
                    TimeSpan ts = elapsedEndUtc - dashboardStartUtc;
                    string timeText = ts.TotalMinutes >= 1
                        ? ((int)ts.TotalMinutes).ToString(CultureInfo.InvariantCulture) + "m " + ts.Seconds.ToString(CultureInfo.InvariantCulture) + "s"
                        : Math.Max(0, (int)ts.TotalSeconds).ToString(CultureInfo.InvariantCulture) + "s";

                    elapsed = "   Elapsed " + timeText;
                }
            }
            catch { }

            return "Rows " + rows.ToString("n0", CultureInfo.InvariantCulture) +
                "   Files " + files.ToString(CultureInfo.InvariantCulture) +
                "   Errors " + errorCount.ToString(CultureInfo.InvariantCulture) +
                "   Warnings " + warningCount.ToString(CultureInfo.InvariantCulture) +
                elapsed;
        }

        private string DashboardShortWarning()
        {
            if (!string.IsNullOrWhiteSpace(dashboardLastWarningShort))
                return dashboardLastWarningShort.Trim();

            if (!string.IsNullOrWhiteSpace(volDeltaLikelyProxyWarning))
                return "VolDelta proxy-style historical delta detected.";

            if (!string.IsNullOrWhiteSpace(ntVolumetricDeltaWarning))
                return "NT volumetric delta warning.";

            if (!IsPrimaryVolumetricBarsType() &&
                ExporterDeltaMode != Flow42ExporterDeltaMode_v0_17.Disabled &&
                ExporterDeltaMode != Flow42ExporterDeltaMode_v0_17.Flow42VolDeltaOnly)
                return "Chart is not Order Flow Volumetric; true NT bid/ask delta unavailable.";

            return "";
        }

        private string DashboardLocationLine()
        {
            string shortPath = DashboardShortFolderPath();
            if (string.IsNullOrWhiteSpace(shortPath))
                return "";

            return "File Location: " + shortPath;
        }

        private string DashboardShortFolderPath()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(resolvedFolder))
                    return "";

                string full = resolvedFolder.Trim();
                const string marker = "NinjaTrader 8 - Chart Data Exports";
                int markerIndex = full.IndexOf(marker, StringComparison.OrdinalIgnoreCase);

                if (markerIndex >= 0)
                {
                    string rel = full.Substring(markerIndex + marker.Length)
                        .TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                    return string.IsNullOrWhiteSpace(rel) ? marker : rel;
                }

                if (!string.IsNullOrWhiteSpace(OutputRootFolder))
                {
                    string root = Path.GetFullPath(OutputRootFolder.Trim()).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                    string fullPath = Path.GetFullPath(full);

                    if (fullPath.StartsWith(root, StringComparison.OrdinalIgnoreCase))
                    {
                        string rel = fullPath.Substring(root.Length)
                            .TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                        return rel;
                    }
                }

                return Path.GetFileName(full);
            }
            catch
            {
                return "";
            }
        }

        private long DashboardTotalRowsExported()
        {
            return (long)plotRowsExported +
                drawAuditRowsExported +
                reversalFeatureRowsExported +
                liveSnapshotRowsExported +
                discoverySampleRowsExported +
                privateFieldNameRowsExported +
                methodsRowsExported +
                settingsRowsExported;
        }

        private void EnsureDashboardMouseHooked()
        {
            try
            {
                if (ChartControl == null)
                    return;

                if (dashboardHookedChartControl == ChartControl)
                    return;

                RemoveDashboardMouseHook();

                dashboardHookedChartControl = ChartControl;
                dashboardHookedChartControl.PreviewMouseDown += DashboardChartMouseDown;
                dashboardHookedChartControl.MouseDown += DashboardChartMouseDown;
            }
            catch
            {
            }
        }

        private void RemoveDashboardMouseHook()
        {
            try
            {
                if (dashboardHookedChartControl != null)
                {
                    dashboardHookedChartControl.PreviewMouseDown -= DashboardChartMouseDown;
                    dashboardHookedChartControl.MouseDown -= DashboardChartMouseDown;
                }
            }
            catch
            {
            }
            finally
            {
                dashboardHookedChartControl = null;
            }
        }

        private void DashboardChartMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!ShowStatusDashboard || e == null || e.ChangedButton != System.Windows.Input.MouseButton.Left)
                    return;

                // Use Ctrl+Click so we do not fight NinjaTrader's normal double-click-to-edit indicator behavior.
                if ((System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Control) != System.Windows.Input.ModifierKeys.Control)
                    return;

                if (dashboardLastFolderHitRect.Width <= 0 || string.IsNullOrWhiteSpace(resolvedFolder))
                    return;

                ChartControl cc = dashboardHookedChartControl ?? ChartControl;
                if (cc == null)
                    return;

                System.Windows.Point pWpf = e.GetPosition(cc);
                System.Windows.Point pPx = DashboardMouseToChartPixelPoint(cc, pWpf);

                bool inHitRect =
                    DashboardPointInRect((float)pPx.X, (float)pPx.Y, dashboardLastFolderHitRect) ||
                    DashboardPointInRect((float)pWpf.X, (float)pWpf.Y, dashboardLastFolderHitRect);

                if (!inHitRect)
                    return;

                e.Handled = true;

                if ((DateTime.UtcNow - dashboardLastFolderClickUtc).TotalMilliseconds < 750)
                    return;

                dashboardLastFolderClickUtc = DateTime.UtcNow;
                OpenOutputFolderFromDashboardClick();
            }
            catch
            {
            }
        }

        private System.Windows.Point DashboardMouseToChartPixelPoint(ChartControl cc, System.Windows.Point p)
        {
            try
            {
                System.Windows.PresentationSource source = System.Windows.PresentationSource.FromVisual(cc);
                if (source != null && source.CompositionTarget != null)
                {
                    p.X *= source.CompositionTarget.TransformToDevice.M11;
                    p.Y *= source.CompositionTarget.TransformToDevice.M22;
                }
            }
            catch
            {
            }

            return p;
        }

        private bool DashboardPointInRect(float x, float y, SharpDX.RectangleF rect)
        {
            return x >= rect.Left && x <= rect.Right && y >= rect.Top && y <= rect.Bottom;
        }

        private void OpenOutputFolderFromDashboardClick()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(resolvedFolder) || !Directory.Exists(resolvedFolder))
                {
                    warningCount++;
                    folderOpenStatus = "Folder missing; path logged";
                    dashboardLastWarningShort = "Output folder missing.";
                    dashboardLastWarningFull = "Output folder missing or not created yet: " + resolvedFolder;
                    try { Print("[Flow42DataCapture] Dashboard Ctrl+Click could not open missing output folder: " + resolvedFolder); } catch { }
                    UpdateDashboardSafe();
                    return;
                }

                Process.Start("explorer.exe", "\"" + resolvedFolder + "\"");
                openedFolder = true;
                folderOpenStatus = "Opened from dashboard Ctrl+Click";
                try { Print("[Flow42DataCapture] Dashboard Ctrl+Click opened output folder: " + resolvedFolder); } catch { }
                UpdateDashboardSafe();
            }
            catch (Exception ex)
            {
                warningCount++;
                folderOpenStatus = "Open failed; path logged";
                dashboardLastWarningShort = "Could not open output folder.";
                dashboardLastWarningFull = "Dashboard Ctrl+Click could not open output folder. Path: " + resolvedFolder + " | Error: " + ex.Message;
                try { Print("[Flow42DataCapture] Dashboard Ctrl+Click could not open output folder. Path: " + resolvedFolder + " | Error: " + ex.Message); } catch { }
                UpdateDashboardSafe();
            }
        }

        private void DashboardDrawTextClipped(string text, SharpDX.DirectWrite.TextFormat textFormat, SharpDX.RectangleF layoutRect, SharpDX.Direct2D1.Brush brush)
        {
            if (string.IsNullOrEmpty(text) || textFormat == null || brush == null || RenderTarget == null)
                return;

            try
            {
                // SharpDX DrawText can wrap long strings onto another line.  This clip keeps the HUD
                // aesthetically clean by preventing any overflow from spilling outside the one-line box.
                RenderTarget.PushAxisAlignedClip(layoutRect, SharpDX.Direct2D1.AntialiasMode.PerPrimitive);
                RenderTarget.DrawText(text, textFormat, layoutRect, brush);
            }
            catch
            {
                try
                {
                    RenderTarget.DrawText(text, textFormat, layoutRect, brush);
                }
                catch { }
            }
            finally
            {
                try
                {
                    RenderTarget.PopAxisAlignedClip();
                }
                catch { }
            }
        }

        private string DashboardTrim(string value, int maxChars)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            string s = value.Replace(Environment.NewLine, " ").Replace("\r", " ").Replace("\n", " ").Trim();
            while (s.Contains("  "))
                s = s.Replace("  ", " ");

            if (maxChars <= 3 || s.Length <= maxChars)
                return s;

            return s.Substring(0, maxChars - 1) + "…";
        }

        private double ClampDashboard(double value, double min, double max)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                return min;

            return Math.Max(min, Math.Min(max, value));
        }

        private SharpDX.RectangleF DashboardInflate(SharpDX.RectangleF rect, float x, float y)
        {
            return new SharpDX.RectangleF(rect.X - x, rect.Y - y, rect.Width + x * 2f, rect.Height + y * 2f);
        }

        private SharpDX.RectangleF DashboardOffset(SharpDX.RectangleF rect, float x, float y)
        {
            return new SharpDX.RectangleF(rect.X + x, rect.Y + y, rect.Width, rect.Height);
        }

        private void DashboardDrawRounded(SharpDX.RectangleF rect, float radius, SharpDX.Direct2D1.Brush brush, bool fill, float strokeWidth)
        {
            SharpDX.Direct2D1.RoundedRectangle rr = new SharpDX.Direct2D1.RoundedRectangle
            {
                Rect = rect,
                RadiusX = radius,
                RadiusY = radius
            };

            if (fill)
                RenderTarget.FillRoundedRectangle(rr, brush);
            else
                RenderTarget.DrawRoundedRectangle(rr, brush, strokeWidth);
        }

        private void DashboardDrawStatusOrb(float cx, float cy, bool complete, bool isError, bool isWarning, SharpDX.Color4 accent)
        {
            float r = complete ? 4.8f : 3.9f;

            using (SharpDX.Direct2D1.SolidColorBrush glow = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(accent.Red, accent.Green, accent.Blue, 0.25f)))
            using (SharpDX.Direct2D1.SolidColorBrush dot = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, accent))
            using (SharpDX.Direct2D1.SolidColorBrush core = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(1f, 1f, 1f, 0.50f)))
            {
                RenderTarget.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r + 5.5f, r + 5.5f), glow);
                RenderTarget.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), r, r), dot);
                RenderTarget.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx - 1.2f, cy - 1.2f), 1.4f, 1.4f), core);
            }
        }

        private void DashboardDrawCheckMark(float cx, float cy, SharpDX.Color4 accent)
        {
            using (SharpDX.Direct2D1.SolidColorBrush glow = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(accent.Red, accent.Green, accent.Blue, 0.24f)))
            using (SharpDX.Direct2D1.SolidColorBrush circle = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, accent))
            using (SharpDX.Direct2D1.SolidColorBrush check = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(0.05f, 0.08f, 0.07f, 1f)))
            {
                RenderTarget.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), 11.5f, 11.5f), glow);
                RenderTarget.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), 8.6f, 8.6f), circle);
                RenderTarget.DrawLine(new SharpDX.Vector2(cx - 4.1f, cy + 0.2f), new SharpDX.Vector2(cx - 1.2f, cy + 3.2f), check, 2.0f);
                RenderTarget.DrawLine(new SharpDX.Vector2(cx - 1.2f, cy + 3.2f), new SharpDX.Vector2(cx + 5.2f, cy - 4.1f), check, 2.0f);
            }
        }

        private void DashboardDrawSparkle(float cx, float cy, SharpDX.Color4 accent)
        {
            using (SharpDX.Direct2D1.SolidColorBrush sparkle = new SharpDX.Direct2D1.SolidColorBrush(RenderTarget, new SharpDX.Color4(accent.Red, accent.Green, accent.Blue, 0.34f)))
            {
                RenderTarget.DrawLine(new SharpDX.Vector2(cx - 3.0f, cy), new SharpDX.Vector2(cx + 3.0f, cy), sparkle, 0.9f);
                RenderTarget.DrawLine(new SharpDX.Vector2(cx, cy - 3.0f), new SharpDX.Vector2(cx, cy + 3.0f), sparkle, 0.9f);
                RenderTarget.FillEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(cx, cy), 1.2f, 1.2f), sparkle);
            }
        }

                private void SafeDelete(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                warningCount++;
                try { Print("[Flow42DataCapture] Could not delete " + path + ": " + ex.Message); } catch { }
            }
        }

        private void AppendLine(string path, string line)
        {
            lock (writeLock)
            {
                try
                {
                    if (!string.IsNullOrEmpty(path))
                        File.AppendAllText(path, line + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    errorCount++;
                    try { Print("[Flow42DataCapture] CSV write error for " + path + ": " + ex.Message); } catch { }
                }
            }
        }

        private string Csv(params object[] fields)
        {
            var parts = new List<string>();
            if (fields != null)
            {
                foreach (object f in fields)
                    parts.Add(EscapeCsv(f == null ? "" : f.ToString()));
            }
            return string.Join(",", parts.ToArray());
        }

        private string EscapeCsv(string s)
        {
            if (s == null)
                s = "";
            bool needsQuotes = s.IndexOf(',') >= 0 || s.IndexOf('"') >= 0 || s.IndexOf('\r') >= 0 || s.IndexOf('\n') >= 0;
            s = s.Replace("\"", "\"\"").Replace("\r", " ").Replace("\n", " ");
            return needsQuotes ? "\"" + s + "\"" : s;
        }

        private string Fmt(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x))
                return "";
            return x.ToString("0.########", CultureInfo.InvariantCulture);
        }

        private string MakeSafeName(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "NA";
            var sb = new StringBuilder();
            foreach (char ch in s)
            {
                if (char.IsLetterOrDigit(ch) || ch == '_')
                    sb.Append(ch);
                else
                    sb.Append('_');
            }
            string output = sb.ToString();
            while (output.Contains("__"))
                output = output.Replace("__", "_");
            return output.Trim('_');
        }

        private string MakeSearchBlob(params string[] parts)
        {
            if (parts == null)
                return "";
            return string.Join(" ", parts.Where(p => !string.IsNullOrEmpty(p)).ToArray());
        }

        private bool LooksFlow42Related(string s)
        {
            return ContainsAny(s, DefaultFlow42IndicatorFilter()) || ContainsAny(s, DefaultFlow42DrawKeywords());
        }

        private bool MatchesAnyFilter(string haystack, string csvNeedles)
        {
            return MatchesAny(haystack, SplitFilter(csvNeedles));
        }

        private bool MatchesAny(string haystack, string[] needles)
        {
            if (string.IsNullOrEmpty(haystack) || needles == null || needles.Length == 0)
                return false;

            foreach (string n in needles)
            {
                if (!string.IsNullOrEmpty(n) && haystack.IndexOf(n, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }
            return false;
        }

        private bool ContainsAny(string haystack, string csvNeedles)
        {
            return MatchesAnyFilter(haystack, csvNeedles);
        }

        private bool Eq(string a, string b)
        {
            return string.Equals(a ?? "", b ?? "", StringComparison.OrdinalIgnoreCase);
        }

        private string[] SplitFilter(string csv)
        {
            if (string.IsNullOrEmpty(csv))
                return new string[0];
            return csv.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }

        private string MakeDrawDedupeKey(string drawType, string tag, string text, DateTime time, double price, int panelIndex)
        {
            return string.Join("|", new string[]
            {
                drawType ?? "",
                tag ?? "",
                text ?? "",
                time == DateTime.MinValue ? "" : time.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                Fmt(price),
                panelIndex.ToString(CultureInfo.InvariantCulture)
            });
        }

        // --------------------------------------------------------------------
        // User properties
        // --------------------------------------------------------------------
        [NinjaScriptProperty]
        [Display(Name = "Preset", Order = 0, GroupName = "0) Main")]
        public Flow42CapturePreset_v0_17 Preset { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Exporter Delta Mode", Order = 1, GroupName = "0) Main")]
        public Flow42ExporterDeltaMode_v0_17 ExporterDeltaMode { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Output Root Folder", Order = 1, GroupName = "1) Output")]
        public string OutputRootFolder { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Clean Export Parent Folder", Order = 2, GroupName = "1) Output")]
        public string ExportParentFolderName { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Use Run Subfolder", Order = 3, GroupName = "1) Output")]
        public bool UseTimestampedRunFolder { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Rebuild Files On Load", Order = 4, GroupName = "1) Output")]
        public bool RebuildFilesOnLoad { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Open Folder When Done", Order = 5, GroupName = "1) Output")]
        public bool OpenFolderWhenDone { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Show Status Dashboard", Order = 6, GroupName = "1) Output")]
        public bool ShowStatusDashboard { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Fallback To All Indicators If No Match", Order = 7, GroupName = "1) Output")]
        public bool FallbackToAllIndicatorsIfNoMatch { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Single Indicator Name Filter", Order = 1, GroupName = "2) Probe One Indicator")]
        public string SingleIndicatorNameFilter { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Indicator Name Filter", Order = 1, GroupName = "9) Custom Only")]
        public string CustomIndicatorNameFilter { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Draw Keywords", Order = 2, GroupName = "9) Custom Only")]
        public string CustomDrawKeywords { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Include All Indicators", Order = 3, GroupName = "9) Custom Only")]
        public bool CustomIncludeAllIndicators { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Do Exposure Probe", Order = 4, GroupName = "9) Custom Only")]
        public bool CustomDoExposureProbe { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Settings Snapshot", Order = 5, GroupName = "9) Custom Only")]
        public bool CustomExportSettingsSnapshot { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Public Methods", Order = 6, GroupName = "9) Custom Only")]
        public bool CustomExportPublicMethods { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Plot Values", Order = 7, GroupName = "9) Custom Only")]
        public bool CustomExportPlotValues { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Draw Audit", Order = 8, GroupName = "9) Custom Only")]
        public bool CustomExportDrawAudit { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Reversal Features", Order = 9, GroupName = "9) Custom Only")]
        public bool CustomExportReversalFeatures { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Live Snapshots", Order = 10, GroupName = "9) Custom Only")]
        public bool CustomExportLiveSnapshots { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Invoke Known Safe Methods", Order = 11, GroupName = "9) Custom Only")]
        public bool CustomInvokeKnownSafeMethods { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Deep Discovery", Order = 12, GroupName = "9) Custom Only")]
        public bool CustomDeepDiscovery { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Discovery Samples", Order = 13, GroupName = "9) Custom Only")]
        public bool CustomExportDiscoverySamples { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Custom Export Private Field Names", Order = 14, GroupName = "9) Custom Only")]
        public bool CustomExportPrivateFieldNames { get; set; }

        [NinjaScriptProperty]
        [Range(0, 1000000)]
        [Display(Name = "Custom Max Plot Rows", Order = 15, GroupName = "9) Custom Only")]
        public int CustomMaxPlotRows { get; set; }

        [NinjaScriptProperty]
        [Range(1, 1000000)]
        [Display(Name = "Custom Historical Scan Every N Bars", Order = 16, GroupName = "9) Custom Only")]
        public int CustomHistoricalScanEveryNBars { get; set; }

        [NinjaScriptProperty]
        [Range(0, 60)]
        [Display(Name = "Custom Realtime Scan Interval Seconds", Order = 17, GroupName = "9) Custom Only")]
        public int CustomRealtimeScanIntervalSeconds { get; set; }

        [NinjaScriptProperty]
        [Range(0, 1000)]
        [Display(Name = "Custom Max Raw Series Columns", Order = 18, GroupName = "9) Custom Only")]
        public int CustomMaxRawSeriesColumns { get; set; }

        [NinjaScriptProperty]
        [Range(0, 1000000)]
        [Display(Name = "Custom Max Draw Objects To Scan", Order = 19, GroupName = "9) Custom Only")]
        public int CustomMaxDrawObjectsToScan { get; set; }

        [NinjaScriptProperty]
        [Display(Name = "Verbose Output Logging", Order = 1, GroupName = "10) Debug")]
        public bool VerbosePrint { get; set; }
    }
}
