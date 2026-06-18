#region Using declarations
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using NinjaTrader.Data;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.Tools;
using NinjaTrader.NinjaScript;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.BarsTypes;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

// =============================================================================
// ResearchDataExporterV1 v1.9
// Safer NT8 master research exporter with navy-glass data-quality dashboard
// Foldered under Indicators > Exporters via namespace NinjaTrader.NinjaScript.Indicators.Exporters for 1-minute / volumetric reversal research.
// v1.1 fix: do not rely on State == Historical inside OnBarUpdate, and warn when zero rows are exported.
// v1.2 update: navy-glass SharpDX dashboard, Ctrl+Click folder link, and organized per-run folders under 00_Main_Data_Exports.
// v1.3 update: research presets, hidden 1-minute volumetric option, dashboard data-quality checks, cleaner folder/file naming, and frozen elapsed timer.
// v1.4 update: adds an explicit Tick/NoTick capture token to run folder/file names, dashboard context, and manifest output.
// v1.5 fix: avoids Windows path-length failures by using short file names inside long descriptive run folders and stops retry storms if writer creation fails.
// v1.6 update: instrument/date folder organization and readable file names.
// v1.9 update: dataset-first organization: instrument -> contract -> data range -> bars/data mode -> exporter -> preset/tick mode -> export timestamp.
//
// Main design goals:
//   1. NO APPEND BY DEFAULT. Re-runs overwrite cleanly or write to a timestamped
//      run folder, so old runs cannot silently contaminate new exports.
//   2. Two main files per chart/instrument: one *_bars.csv and one *_footprint.csv.
//   3. Full instrument identity: MasterInstrument + FullName, so contracts do not
//      silently collide.
//   4. Session-aware exported CVD using Bars.IsFirstBarOfSession, plus NinjaTrader's
//      volumetric CumulativeDelta when available.
//   5. No silent failures: errors are counted, printed, and optionally summarized
//      in a small manifest file.
//   6. Useful raw-ish research columns added at export time: close location, wick
//      ratios, delta/volume, footprint POC, extreme-zone volume/delta, and diagonal
//      stacked imbalance counts.
//
// Recommended use:
//   - Add to a chart that already has the exact historical range loaded.
//   - For footprint export, the primary chart BarsType must be Order Flow Volumetric.
//   - Leave OverwriteExistingFiles = true for clean re-exporting.
//   - If you want to preserve multiple runs, set CreateTimestampedRunFolder = true.
//
// Output folder default:
//   Documents\NinjaTrader 8\NinjaTrader 8 - Chart Data Exports\<Instrument>\<Contract>\<DataStart_to_DataEnd>\<Bars_DataMode>\ResearchDataExporterV1\<Preset_TickMode>\<ExportTimestamp>
// =============================================================================

namespace NinjaTrader.NinjaScript.Indicators.Exporters
{
    public enum ResearchDataExportPresetV1
    {
        FullResearch_AutoVolumetric,
        FullResearch_ChartVolumetric,
        FullResearch_Hidden1MinVolumetric,
        FullResearch_CandleOnly,
        FullResearch_RangeVolumetric
    }

    public class ResearchDataExporterV1 : Indicator
    {
        private StreamWriter barWriter;
        private StreamWriter fpWriter;

        private string runId = string.Empty;
        private string outputFolder = string.Empty;
        private string barPath = string.Empty;
        private string footprintPath = string.Empty;
        private string manifestPath = string.Empty;
        private string instrumentMaster = string.Empty;
        private string instrumentFull = string.Empty;
        private string instrumentFileSafe = string.Empty;

        private bool writersOpened = false;
        private bool exportFinished = false;
        private bool folderOpened = false;
        private bool hasVolumetric = false;
        private bool hiddenVolumetricRequested = false;
        private bool hiddenVolumetricAdded = false;
        private int hiddenVolumetricBarsIndex = -1;
        private bool dataQualityWarningRecorded = false;
        private string primaryDataTypeLabel = "";
        private string deltaSourceQualityLabel = "";
        private string dataQualityWarning = "";
        private string dataQualityStatus = "Unknown";
        private string activeDataModeFolderToken = "Standard";
        private string activePresetFolderToken = "FullResearch";

        private long barRowsWritten = 0;
        private long footprintRowsWritten = 0;
        private long duplicateTimestampsSkipped = 0;
        private long missingFootprintBars = 0;
        private long footprintMismatchBars = 0;
        private long errorCount = 0;
        private string firstError = string.Empty;
        private string lastError = string.Empty;
        private long warningCount = 0;
        private string firstWarning = string.Empty;
        private string lastWarning = string.Empty;

        // ---------------------------------------------------------------------
        // Navy-glass dashboard state
        // ---------------------------------------------------------------------
        private double dashboardAnimatedPercent = 0.0;
        private double dashboardProgressPercent = 0.0;
        private long dashboardRowsCached = 0;
        private int dashboardFilesCached = 0;
        private DateTime dashboardStartUtc = DateTime.MinValue;
        private DateTime dashboardEndUtc = DateTime.MinValue;
        private DateTime dashboardLastRefreshUtc = DateTime.MinValue;
        private DateTime dashboardLastFolderClickUtc = DateTime.MinValue;
        private SharpDX.RectangleF dashboardLastFolderHitRect = new SharpDX.RectangleF();
        private ChartControl dashboardHookedChartControl = null;
        private string dashboardStatus = "Initializing";
        private string dashboardStatusMessage = "Preparing research export...";
        private const string DashboardLegacyTextTag = "ResearchDataExporterV1_Status";

        private DateTime firstExportedTime = DateTime.MinValue;
        private DateTime lastExportedTime = DateTime.MinValue;
        private DateTime lastWrittenTimestamp = DateTime.MinValue;

        private double exportSessionCvd = 0.0;
        private int barsSinceStatus = 0;

        private const int StatusEveryBars = 500;

        // ---------------------------------------------------------------------
        // User parameters
        // ---------------------------------------------------------------------
        [NinjaScriptProperty]
        [Display(Name="Export Preset", Description="Master export preset. AutoVolumetric uses chart volumetric bars when available, otherwise a hidden 1-minute volumetric series.", Order=0, GroupName="00. Preset")]
        public ResearchDataExportPresetV1 ExportPreset { get; set; }

        [NinjaScriptProperty]
        [Range(1, 60)]
        [Display(Name="Hidden Volumetric Minutes", Description="Minutes used for the hidden Volumetric BidAsk series when the preset uses hidden volumetric context.", Order=1, GroupName="00. Preset")]
        public int HiddenVolumetricMinutes { get; set; }

        [NinjaScriptProperty]
        [Range(1, 20)]
        [Display(Name="Hidden Volumetric Ticks Per Level", Description="Ticks per level for the hidden Volumetric BidAsk series.", Order=2, GroupName="00. Preset")]
        public int HiddenVolumetricTicksPerLevel { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Export Bars", Description="Write the bar-level CSV.", Order=1, GroupName="01. Output")]
        public bool ExportBars { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Export Footprint", Description="Write the price-level footprint CSV. Requires a Volumetric chart BarsType.", Order=2, GroupName="01. Output")]
        public bool ExportFootprint { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Export Historical Only", Description="Recommended. Exports historical bars, then stops when chart reaches realtime.", Order=3, GroupName="01. Output")]
        public bool ExportHistoricalOnly { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Overwrite Existing Files", Description="Recommended. Prevents accidental duplicate/appended files on re-runs.", Order=4, GroupName="01. Output")]
        public bool OverwriteExistingFiles { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Create Timestamped Run Folder", Description="If true, each run writes to its own timestamped subfolder instead of overwriting.", Order=5, GroupName="01. Output")]
        public bool CreateTimestampedRunFolder { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Write Manifest", Description="Writes a small run summary / QC file. Turn off if you only want the two main CSVs.", Order=6, GroupName="01. Output")]
        public bool WriteManifest { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Open Folder When Done", Description="Open the export folder when historical processing completes.", Order=7, GroupName="01. Output")]
        public bool OpenFolderWhenDone { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Output Root Folder", Description="Main folder where organized per-run export folders are created.", Order=8, GroupName="01. Output")]
        public string OutputRootFolder { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Output Subfolder", Description="Subfolder under Output Root Folder.", Order=9, GroupName="01. Output")]
        public string OutputSubfolder { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Chart Tag", Description="Filename tag, e.g. 1min, 5min, 32range. Prevents chart-type collisions.", Order=10, GroupName="01. Output")]
        public string ChartTag { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Prevent Duplicate Timestamps", Description="Skips duplicate timestamps within a single run. Useful as a safety net.", Order=1, GroupName="02. Safety")]
        public bool PreventDuplicateTimestamps { get; set; }

        [NinjaScriptProperty]
        [Range(1, 20000)]
        [Display(Name="Max Price Levels Per Bar", Description="Safety cap for malformed bars with absurd high-low range.", Order=2, GroupName="02. Safety")]
        public int MaxPriceLevelsPerBar { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Export Footprint Summary In Bar File", Description="Adds POC, extreme-zone volume/delta, and imbalance summary columns to bars CSV.", Order=3, GroupName="02. Safety")]
        public bool ExportFootprintSummaryInBars { get; set; }

        [NinjaScriptProperty]
        [Range(1, 100)]
        [Display(Name="Extreme Zone Ticks", Description="How many ticks from high/low count as the top/bottom absorption zone.", Order=1, GroupName="03. Footprint Research")]
        public int ExtremeZoneTicks { get; set; }

        [NinjaScriptProperty]
        [Range(1.1, 20.0)]
        [Display(Name="Diagonal Imbalance Ratio", Description="Ask(P) vs Bid(P-tick), Bid(P) vs Ask(P+tick). Common values: 3 or 4.", Order=2, GroupName="03. Footprint Research")]
        public double DiagonalImbalanceRatio { get; set; }

        [NinjaScriptProperty]
        [Range(0, 100000)]
        [Display(Name="Min Imbalance Volume", Description="Minimum numerator volume required before an imbalance can be flagged.", Order=3, GroupName="03. Footprint Research")]
        public int MinImbalanceVolume { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Allow Zero-Denominator Imbalances", Description="If true, numerator over zero can count as an imbalance. False is stricter.", Order=4, GroupName="03. Footprint Research")]
        public bool AllowZeroDenominatorImbalances { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Show Status Dashboard", Description="Show the compact navy-glass export dashboard on the chart.", Order=1, GroupName="04. Dashboard")]
        public bool ShowStatusDashboard { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Show Data Quality On Dashboard", Description="Show chart data type, delta source, loaded/exported range, and potential warnings on the dashboard.", Order=2, GroupName="04. Dashboard")]
        public bool ShowDataQualityOnDashboard { get; set; }

        [NinjaScriptProperty]
        [Display(Name="Use Short Native Chart Label", Description="Use a short chart label instead of the full indicator name to keep the chart clean.", Order=3, GroupName="04. Dashboard")]
        public bool HideNativeChartLabel { get; set; }

        public override string DisplayName
        {
            get { return HideNativeChartLabel ? "Research Exporter" : Name; }
        }

        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Description = "Safer research CSV exporter v1.9: full research presets, dataset-first folders, readable self-describing filenames, hidden/primary volumetric support, Tick/NoTick naming, QC manifest, and compact navy-glass data-quality dashboard.";
                Name = "Research Exporter Full Research v1.9";
                Calculate = Calculate.OnBarClose;
                IsOverlay = true;
                DisplayInDataBox = false;
                PaintPriceMarkers = false;
                IsSuspendedWhileInactive = false;

                ExportPreset = ResearchDataExportPresetV1.FullResearch_AutoVolumetric;
                HiddenVolumetricMinutes = 1;
                HiddenVolumetricTicksPerLevel = 1;

                ExportBars = true;
                ExportFootprint = true;
                ExportHistoricalOnly = true;
                OverwriteExistingFiles = true;
                CreateTimestampedRunFolder = true;
                WriteManifest = true;
                OpenFolderWhenDone = true;
                OutputRootFolder = DefaultMainExportRoot();
                OutputSubfolder = "ResearchDataExporterV1";
                ChartTag = "Auto";

                PreventDuplicateTimestamps = false;
                MaxPriceLevelsPerBar = 5000;
                ExportFootprintSummaryInBars = true;

                ExtremeZoneTicks = 8;
                DiagonalImbalanceRatio = 3.0;
                MinImbalanceVolume = 20;
                AllowZeroDenominatorImbalances = false;

                ShowStatusDashboard = true;
                ShowDataQualityOnDashboard = true;
                HideNativeChartLabel = true;
            }
            else if (State == State.Configure)
            {
                ApplyPresetDefaults();
                TryAddHiddenVolumetricSeriesIfNeeded();
            }
            else if (State == State.DataLoaded)
            {
                runId = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
                dashboardStartUtc = DateTime.UtcNow;
                dashboardEndUtc = DateTime.MinValue;
                dashboardStatus = "Preparing";
                dashboardStatusMessage = "Creating organized run folder...";
                RefreshDataQualityLabels();
                SetupIdentityAndFolder();
                UpdateDashboardSafe(true);
            }
            else if (State == State.Historical)
            {
                // Open the files as soon as historical processing begins.
                // This makes a zero-row run obvious: you will see header-only bars/footprint
                // files instead of only a manifest.
                EnsureWriters();
            }
            else if (State == State.Realtime)
            {
                if (ExportHistoricalOnly)
                {
                    string reason = "Reached realtime; historical export complete.";
                    if ((ExportBars && barRowsWritten == 0) || (ExportFootprint && footprintRowsWritten == 0))
                        reason = "WARNING: Reached realtime with zero rows exported. Chart historical bars were not processed; reload historical data/re-add indicator, or check chart data settings.";
                    FinishExport(reason);
                }
            }
            else if (State == State.Terminated)
            {
                FinishExport("Indicator terminated.");
                RemoveDashboardMouseHook();
            }
        }


        private void ApplyPresetDefaults()
        {
            try
            {
                // Presets are intended to make the export intent explicit without needing to remember
                // every detailed setting. User toggles are still honored except where a preset would
                // be misleading (for example CandleOnly cannot export true footprint rows).
                if (ExportPreset == ResearchDataExportPresetV1.FullResearch_CandleOnly)
                {
                    ExportFootprint = false;
                    ExportFootprintSummaryInBars = false;
                }

                if (string.IsNullOrWhiteSpace(ChartTag) || ChartTag.Trim().Equals("Auto", StringComparison.OrdinalIgnoreCase))
                    ChartTag = "Auto";

                CreateTimestampedRunFolder = true;
                OverwriteExistingFiles = true;
            }
            catch { }
        }

        private void TryAddHiddenVolumetricSeriesIfNeeded()
        {
            hiddenVolumetricRequested =
                ExportPreset == ResearchDataExportPresetV1.FullResearch_AutoVolumetric ||
                ExportPreset == ResearchDataExportPresetV1.FullResearch_Hidden1MinVolumetric;

            if (!hiddenVolumetricRequested)
                return;

            try
            {
                int minutes = Math.Max(1, HiddenVolumetricMinutes);
                int ticksPerLevel = Math.Max(1, HiddenVolumetricTicksPerLevel);

                // null instrument means use the primary/chart instrument. This avoids hardcoding
                // contract names and keeps the exporter reusable across NQ/ES/etc.
                AddVolumetric(null, BarsPeriodType.Minute, minutes, NinjaTrader.Data.VolumetricDeltaType.BidAsk, ticksPerLevel);
                hiddenVolumetricAdded = true;
                hiddenVolumetricBarsIndex = 1;
            }
            catch (Exception ex)
            {
                hiddenVolumetricAdded = false;
                hiddenVolumetricBarsIndex = -1;
                RecordWarning("Hidden volumetric series could not be added: " + (ex == null ? "unknown error" : ex.Message));
            }
        }

        protected override void OnBarUpdate()
        {
            if (BarsInProgress != 0)
                return;
            if (CurrentBar < 0)
                return;
            if (exportFinished)
                return;

            // IMPORTANT v1.1 fix:
            // Do NOT return just because State != State.Historical here. In some NT8
            // add/reload contexts, using the lifecycle State as an OnBarUpdate gate can
            // suppress all loaded bars, producing a manifest with 0 rows.
            // Historical-only mode is still enforced because State.Realtime calls
            // FinishExport() before live bars are written.
            EnsureWriters();
            if (!writersOpened)
                return;

            DateTime timestamp = Time[0];
            if (PreventDuplicateTimestamps && lastWrittenTimestamp != DateTime.MinValue && timestamp == lastWrittenTimestamp)
            {
                duplicateTimestampsSkipped++;
                return;
            }
            lastWrittenTimestamp = timestamp;

            if (firstExportedTime == DateTime.MinValue)
                firstExportedTime = timestamp;
            lastExportedTime = timestamp;

            VolumetricSourceContext volSource = ResolveVolumetricSource();
            hasVolumetric = volSource != null && volSource.Available;

            if (!dataQualityWarningRecorded)
            {
                dataQualityWarningRecorded = true;
                RefreshDataQualityLabels();
                if (!string.IsNullOrWhiteSpace(dataQualityWarning) && dataQualityStatus == "Warning")
                    RecordWarning(dataQualityWarning);
            }

            FootprintSummary fp = null;
            bool needFootprintLoop = hasVolumetric && (ExportFootprint || ExportFootprintSummaryInBars);

            if (needFootprintLoop)
            {
                try
                {
                    fp = BuildFootprintSummary(volSource);
                }
                catch (Exception ex)
                {
                    RecordError("BuildFootprintSummary", ex);
                    fp = null;
                }
            }
            else if (ExportFootprint && !hasVolumetric)
            {
                missingFootprintBars++;
            }

            double barDelta = 0.0;
            double ninjaCvd = 0.0;
            string deltaSource = "NO_TRUE_VOLUMETRIC_DELTA";

            if (hasVolumetric)
            {
                try
                {
                    barDelta = volSource.Volumes.Volumes[volSource.BarIndex].BarDelta;
                    ninjaCvd = volSource.Volumes.Volumes[volSource.BarIndex].CumulativeDelta;
                    deltaSource = volSource.SourceName;
                }
                catch (Exception ex)
                {
                    RecordError("ReadVolumetricBarStats", ex);
                }
            }

            bool isFirstBarOfSession = false;
            try { isFirstBarOfSession = CurrentBar == 0 || Bars.IsFirstBarOfSession; }
            catch { isFirstBarOfSession = CurrentBar == 0; }

            if (isFirstBarOfSession)
                exportSessionCvd = 0.0;
            exportSessionCvd += barDelta;

            if (fp != null)
            {
                double compareVolume = (volSource != null && volSource.Available) ? volSource.SourceVolume : Volume[0];
                double mismatch = Math.Abs(Convert.ToDouble(fp.TotalVolume) - compareVolume);
                if (mismatch > 0.5)
                    footprintMismatchBars++;
            }

            if (ExportBars && barWriter != null)
            {
                try { WriteBarRow(fp, barDelta, ninjaCvd, exportSessionCvd, deltaSource, isFirstBarOfSession); }
                catch (Exception ex) { RecordError("WriteBarRow", ex); }
            }

            if (ExportFootprint && fpWriter != null && fp != null)
            {
                try { WriteFootprintRows(fp, barDelta, exportSessionCvd); }
                catch (Exception ex) { RecordError("WriteFootprintRows", ex); }
            }

            if (++barsSinceStatus >= StatusEveryBars)
            {
                barsSinceStatus = 0;
                DrawStatus(false, "Exporting...");
            }
            else
            {
                UpdateDashboardSafe(false);
            }
        }

        // ------------------------------------------------------------------
        // Footprint summary construction
        // ------------------------------------------------------------------
        private FootprintSummary BuildFootprintSummary(VolumetricSourceContext source)
        {
            if (source == null || !source.Available || source.Volumes == null)
                return null;

            VolumetricBarsType vol = source.Volumes;
            int sourceBarIndex = source.BarIndex;

            FootprintSummary s = new FootprintSummary();
            s.Available = true;
            s.SourceName = source.SourceName;
            s.SourceTime = source.SourceTime;
            s.SourceVolume = source.SourceVolume;

            double tick = TickSize;
            try
            {
                if (Instrument != null && Instrument.MasterInstrument != null && Instrument.MasterInstrument.TickSize > 0)
                    tick = Instrument.MasterInstrument.TickSize;
            }
            catch { }
            if (tick <= 0)
                tick = TickSize > 0 ? TickSize : 0.25;

            double low = source.SourceLow;
            double high = source.SourceHigh;
            double range = Math.Max(high - low, tick);
            int steps = (int)Math.Round((high - low) / tick, MidpointRounding.AwayFromZero);
            if (steps < 0)
                steps = 0;
            if (steps > MaxPriceLevelsPerBar)
            {
                RecordError("MaxPriceLevelsPerBar", new Exception("Bar has " + steps.ToString(CultureInfo.InvariantCulture) + " price levels; capped at " + MaxPriceLevelsPerBar.ToString(CultureInfo.InvariantCulture)));
                steps = MaxPriceLevelsPerBar;
            }

            double bottomCutoff = low + ExtremeZoneTicks * tick;
            double topCutoff = high - ExtremeZoneTicks * tick;

            s.BarDelta = vol.Volumes[sourceBarIndex].BarDelta;
            s.Trades = SafeLong(delegate { return vol.Volumes[sourceBarIndex].Trades; });
            s.TotalBuyingVolume = SafeLong(delegate { return vol.Volumes[sourceBarIndex].TotalBuyingVolume; });
            s.TotalSellingVolume = SafeLong(delegate { return vol.Volumes[sourceBarIndex].TotalSellingVolume; });
            s.DeltaPercent = SafeDouble(delegate { return vol.Volumes[sourceBarIndex].GetDeltaPercent(); });
            s.MaxSeenDelta = SafeLong(delegate { return vol.Volumes[sourceBarIndex].MaxSeenDelta; });
            s.MinSeenDelta = SafeLong(delegate { return vol.Volumes[sourceBarIndex].MinSeenDelta; });
            s.DeltaSinceHigh = SafeLong(delegate { return vol.Volumes[sourceBarIndex].DeltaSh; });
            s.DeltaSinceLow = SafeLong(delegate { return vol.Volumes[sourceBarIndex].DeltaSl; });
            s.MaxPositiveDelta = SafeLong(delegate { return vol.Volumes[sourceBarIndex].GetMaximumPositiveDelta(); });
            s.MaxNegativeDelta = SafeLong(delegate { return vol.Volumes[sourceBarIndex].GetMaximumNegativeDelta(); });

            long maxCombinedVol = -1;
            long maxAskVol = -1;
            long maxBidVol = -1;

            for (int i = 0; i <= steps; i++)
            {
                double price = RoundToTick(low + i * tick, tick);
                long bid = 0;
                long ask = 0;

                try { bid = vol.Volumes[sourceBarIndex].GetBidVolumeForPrice(price); }
                catch { bid = 0; }
                try { ask = vol.Volumes[sourceBarIndex].GetAskVolumeForPrice(price); }
                catch { ask = 0; }

                long total = bid + ask;
                long delta = ask - bid;

                LevelRecord r = new LevelRecord();
                r.Price = price;
                r.TickIndexFromLow = i;
                r.Bid = bid;
                r.Ask = ask;
                r.Total = total;
                r.Delta = delta;
                r.PricePosition = range <= 0 ? 0.0 : (price - low) / range;
                r.IsHigh = Math.Abs(price - high) < tick * 0.5;
                r.IsLow = Math.Abs(price - low) < tick * 0.5;
                r.InBottomZone = price <= bottomCutoff + tick * 0.5;
                r.InTopZone = price >= topCutoff - tick * 0.5;

                s.Levels.Add(r);

                s.TotalBid += bid;
                s.TotalAsk += ask;
                s.TotalVolume += total;
                s.FootprintDelta += delta;
                if (total > 0)
                    s.NonZeroLevels++;

                if (r.InBottomZone)
                {
                    s.BottomBid += bid;
                    s.BottomAsk += ask;
                    s.BottomVolume += total;
                    s.BottomDelta += delta;
                }
                if (r.InTopZone)
                {
                    s.TopBid += bid;
                    s.TopAsk += ask;
                    s.TopVolume += total;
                    s.TopDelta += delta;
                }

                if (total > maxCombinedVol)
                {
                    maxCombinedVol = total;
                    s.PocPrice = price;
                    s.PocVolume = total;
                    s.PocPosition = r.PricePosition;
                }
                if (ask > maxAskVol)
                {
                    maxAskVol = ask;
                    s.MaxAskPrice = price;
                    s.MaxAskVolume = ask;
                }
                if (bid > maxBidVol)
                {
                    maxBidVol = bid;
                    s.MaxBidPrice = price;
                    s.MaxBidVolume = bid;
                }
            }

            ComputeDiagonalImbalances(s);

            if (s.TotalVolume > 0)
            {
                s.BottomVolumeShare = Convert.ToDouble(s.BottomVolume) / Convert.ToDouble(s.TotalVolume);
                s.TopVolumeShare = Convert.ToDouble(s.TopVolume) / Convert.ToDouble(s.TotalVolume);
            }
            else
            {
                s.BottomVolumeShare = 0.0;
                s.TopVolumeShare = 0.0;
            }

            return s;
        }

        private void ComputeDiagonalImbalances(FootprintSummary s)
        {
            int currentBuyRun = 0;
            int currentSellRun = 0;
            int currentTopBuyRun = 0;
            int currentBottomSellRun = 0;

            for (int i = 0; i < s.Levels.Count; i++)
            {
                LevelRecord r = s.Levels[i];
                long lowerBid = i > 0 ? s.Levels[i - 1].Bid : 0;
                long higherAsk = i < s.Levels.Count - 1 ? s.Levels[i + 1].Ask : 0;

                r.BuyDiagonalImbalance = IsImbalance(r.Ask, lowerBid);
                r.SellDiagonalImbalance = IsImbalance(r.Bid, higherAsk);

                if (r.BuyDiagonalImbalance)
                {
                    s.BuyImbalanceCount++;
                    currentBuyRun++;
                    if (currentBuyRun > s.StackedBuyMaxRun)
                        s.StackedBuyMaxRun = currentBuyRun;
                    if (r.InTopZone)
                    {
                        s.TopBuyImbalanceCount++;
                        currentTopBuyRun++;
                        if (currentTopBuyRun > s.TopBuyStackMax)
                            s.TopBuyStackMax = currentTopBuyRun;
                    }
                    else
                        currentTopBuyRun = 0;
                }
                else
                {
                    currentBuyRun = 0;
                    currentTopBuyRun = 0;
                }

                if (r.SellDiagonalImbalance)
                {
                    s.SellImbalanceCount++;
                    currentSellRun++;
                    if (currentSellRun > s.StackedSellMaxRun)
                        s.StackedSellMaxRun = currentSellRun;
                    if (r.InBottomZone)
                    {
                        s.BottomSellImbalanceCount++;
                        currentBottomSellRun++;
                        if (currentBottomSellRun > s.BottomSellStackMax)
                            s.BottomSellStackMax = currentBottomSellRun;
                    }
                    else
                        currentBottomSellRun = 0;
                }
                else
                {
                    currentSellRun = 0;
                    currentBottomSellRun = 0;
                }
            }
        }

        private bool IsImbalance(long numerator, long denominator)
        {
            if (numerator < MinImbalanceVolume)
                return false;
            if (denominator <= 0)
                return AllowZeroDenominatorImbalances;
            return Convert.ToDouble(numerator) >= DiagonalImbalanceRatio * Convert.ToDouble(denominator);
        }

        // ------------------------------------------------------------------
        // Row writers
        // ------------------------------------------------------------------
        private void WriteBarRow(FootprintSummary fp, double barDelta, double ninjaCvd, double sessionCvd, string deltaSource, bool isFirstBarOfSession)
        {
            double range = Math.Max(High[0] - Low[0], TickSize);
            double body = Math.Abs(Close[0] - Open[0]);
            double upperWick = High[0] - Math.Max(Open[0], Close[0]);
            double lowerWick = Math.Min(Open[0], Close[0]) - Low[0];
            double closeLocation = range <= 0 ? 0.0 : (Close[0] - Low[0]) / range;
            double deltaPerVolume = Volume[0] == 0 ? 0.0 : barDelta / Volume[0];

            StringBuilder sb = new StringBuilder(1024);
            AddText(sb, runId);
            AddText(sb, FormatTime(Time[0]));
            AddText(sb, instrumentMaster);
            AddText(sb, instrumentFull);
            AddText(sb, SafeText(ChartTag));
            AddText(sb, BarsPeriod == null ? "" : BarsPeriod.BarsPeriodType.ToString());
            AddNumber(sb, BarsPeriod == null ? 0 : BarsPeriod.Value);
            AddNumber(sb, CurrentBar);
            AddNumber(sb, isFirstBarOfSession ? 1 : 0);
            AddNumber(sb, Open[0]);
            AddNumber(sb, High[0]);
            AddNumber(sb, Low[0]);
            AddNumber(sb, Close[0]);
            AddNumber(sb, Volume[0]);
            AddNumber(sb, range);
            AddNumber(sb, TickSize <= 0 ? 0.0 : range / TickSize);
            AddNumber(sb, TickSize <= 0 ? 0.0 : body / TickSize);
            AddNumber(sb, TickSize <= 0 ? 0.0 : upperWick / TickSize);
            AddNumber(sb, TickSize <= 0 ? 0.0 : lowerWick / TickSize);
            AddNumber(sb, closeLocation);
            AddNumber(sb, barDelta);
            AddNumber(sb, deltaPerVolume);
            AddNumber(sb, ninjaCvd);
            AddNumber(sb, sessionCvd);

            if (fp != null)
            {
                AddNumber(sb, fp.TotalBuyingVolume);
                AddNumber(sb, fp.TotalSellingVolume);
                AddNumber(sb, fp.DeltaPercent);
                AddNumber(sb, fp.Trades);
                AddNumber(sb, fp.MaxSeenDelta);
                AddNumber(sb, fp.MinSeenDelta);
                AddNumber(sb, fp.DeltaSinceHigh);
                AddNumber(sb, fp.DeltaSinceLow);
                AddNumber(sb, fp.MaxPositiveDelta);
                AddNumber(sb, fp.MaxNegativeDelta);
                AddNumber(sb, fp.PocPrice);
                AddNumber(sb, fp.PocVolume);
                AddNumber(sb, fp.PocPosition);
                AddNumber(sb, fp.MaxAskPrice);
                AddNumber(sb, fp.MaxAskVolume);
                AddNumber(sb, fp.MaxBidPrice);
                AddNumber(sb, fp.MaxBidVolume);
                AddNumber(sb, fp.TotalBid);
                AddNumber(sb, fp.TotalAsk);
                AddNumber(sb, fp.TotalVolume);
                AddNumber(sb, fp.FootprintDelta);
                AddNumber(sb, fp.NonZeroLevels);
                AddNumber(sb, Convert.ToDouble(fp.TotalVolume) - Volume[0]);
                AddNumber(sb, ExtremeZoneTicks);
                AddNumber(sb, fp.BottomBid);
                AddNumber(sb, fp.BottomAsk);
                AddNumber(sb, fp.BottomVolume);
                AddNumber(sb, fp.BottomDelta);
                AddNumber(sb, fp.BottomVolumeShare);
                AddNumber(sb, fp.TopBid);
                AddNumber(sb, fp.TopAsk);
                AddNumber(sb, fp.TopVolume);
                AddNumber(sb, fp.TopDelta);
                AddNumber(sb, fp.TopVolumeShare);
                AddNumber(sb, fp.StackedBuyMaxRun);
                AddNumber(sb, fp.StackedSellMaxRun);
                AddNumber(sb, fp.BuyImbalanceCount);
                AddNumber(sb, fp.SellImbalanceCount);
                AddNumber(sb, fp.TopBuyImbalanceCount);
                AddNumber(sb, fp.BottomSellImbalanceCount);
                AddNumber(sb, fp.TopBuyStackMax);
                AddNumber(sb, fp.BottomSellStackMax);
            }
            else
            {
                // Keep column count stable even on non-volumetric charts.
                for (int i = 0; i < 42; i++)
                    AddText(sb, "");
            }

            AddText(sb, deltaSource);
            AddNumber(sb, errorCount);
            AddText(sb, PrimaryDataTypeForExport());
            AddNumber(sb, IsPrimaryVolumetricBarsType() ? 1 : 0);
            AddText(sb, DeltaSourceQualityForExport());
            AddText(sb, dataQualityStatus);
            AddText(sb, dataQualityWarning);
            AddText(sb, string.IsNullOrWhiteSpace(outputFolder) ? "" : Path.GetFileName(outputFolder));

            barWriter.WriteLine(sb.ToString());
            barRowsWritten++;
        }

        private void WriteFootprintRows(FootprintSummary fp, double barDelta, double sessionCvd)
        {
            if (fp == null || fp.Levels == null || fp.Levels.Count == 0)
                return;

            StringBuilder sbAll = new StringBuilder(8192);
            for (int i = 0; i < fp.Levels.Count; i++)
            {
                LevelRecord r = fp.Levels[i];
                if (r.Total == 0)
                    continue;

                StringBuilder sb = new StringBuilder(512);
                AddText(sb, runId);
                AddText(sb, FormatTime(Time[0]));
                AddText(sb, instrumentMaster);
                AddText(sb, instrumentFull);
                AddText(sb, SafeText(ChartTag));
                AddText(sb, BarsPeriod == null ? "" : BarsPeriod.BarsPeriodType.ToString());
                AddNumber(sb, BarsPeriod == null ? 0 : BarsPeriod.Value);
                AddNumber(sb, CurrentBar);
                AddNumber(sb, Open[0]);
                AddNumber(sb, High[0]);
                AddNumber(sb, Low[0]);
                AddNumber(sb, Close[0]);
                AddNumber(sb, Volume[0]);
                AddNumber(sb, barDelta);
                AddNumber(sb, sessionCvd);
                AddNumber(sb, r.Price);
                AddNumber(sb, r.TickIndexFromLow);
                AddNumber(sb, r.PricePosition);
                AddNumber(sb, r.Total);
                AddNumber(sb, r.Bid);
                AddNumber(sb, r.Ask);
                AddNumber(sb, r.Delta);
                AddNumber(sb, r.IsHigh ? 1 : 0);
                AddNumber(sb, r.IsLow ? 1 : 0);
                AddNumber(sb, r.InBottomZone ? 1 : 0);
                AddNumber(sb, r.InTopZone ? 1 : 0);
                AddNumber(sb, r.BuyDiagonalImbalance ? 1 : 0);
                AddNumber(sb, r.SellDiagonalImbalance ? 1 : 0);
                AddText(sb, fp.SourceName);
                AddText(sb, fp.SourceTime == DateTime.MinValue ? "" : FormatTime(fp.SourceTime));
                sbAll.Append(sb.ToString()).Append('\n');
                footprintRowsWritten++;
            }

            if (sbAll.Length > 0)
                fpWriter.Write(sbAll.ToString());
        }


        // ------------------------------------------------------------------
        // Volumetric source resolution + data-quality diagnostics
        // ------------------------------------------------------------------
        private VolumetricSourceContext ResolveVolumetricSource()
        {
            VolumetricSourceContext primary = TryGetPrimaryVolumetricSource();
            bool primaryOk = primary != null && primary.Available;

            if (primaryOk)
                return primary;

            bool allowHidden =
                ExportPreset == ResearchDataExportPresetV1.FullResearch_AutoVolumetric ||
                ExportPreset == ResearchDataExportPresetV1.FullResearch_Hidden1MinVolumetric;

            if (allowHidden)
            {
                VolumetricSourceContext hidden = TryGetHiddenVolumetricSource();
                if (hidden != null && hidden.Available)
                    return hidden;
            }

            return new VolumetricSourceContext
            {
                Available = false,
                SourceName = "NO_TRUE_VOLUMETRIC_DELTA",
                SourceTime = Time[0],
                SourceOpen = Open[0],
                SourceHigh = High[0],
                SourceLow = Low[0],
                SourceClose = Close[0],
                SourceVolume = Volume[0]
            };
        }

        private VolumetricSourceContext TryGetPrimaryVolumetricSource()
        {
            try
            {
                VolumetricBarsType vol = Bars == null || Bars.BarsSeries == null
                    ? null
                    : Bars.BarsSeries.BarsType as VolumetricBarsType;

                if (vol == null || vol.Volumes == null || CurrentBar < 0 || CurrentBar >= vol.Volumes.Length)
                    return null;

                return new VolumetricSourceContext
                {
                    Available = true,
                    Volumes = vol,
                    BarIndex = CurrentBar,
                    BarsInProgressIndex = 0,
                    IsPrimary = true,
                    SourceName = "ChartVolumetricBidAsk",
                    SourceTime = Time[0],
                    SourceOpen = Open[0],
                    SourceHigh = High[0],
                    SourceLow = Low[0],
                    SourceClose = Close[0],
                    SourceVolume = Volume[0]
                };
            }
            catch
            {
                return null;
            }
        }

        private VolumetricSourceContext TryGetHiddenVolumetricSource()
        {
            try
            {
                if (!hiddenVolumetricAdded || hiddenVolumetricBarsIndex < 1)
                    return null;

                if (BarsArray == null || BarsArray.Length <= hiddenVolumetricBarsIndex)
                    return null;

                if (CurrentBars == null || CurrentBars.Length <= hiddenVolumetricBarsIndex || CurrentBars[hiddenVolumetricBarsIndex] < 0)
                    return null;

                VolumetricBarsType vol = BarsArray[hiddenVolumetricBarsIndex].BarsType as VolumetricBarsType;
                int idx = CurrentBars[hiddenVolumetricBarsIndex];

                if (vol == null || vol.Volumes == null || idx < 0 || idx >= vol.Volumes.Length)
                    return null;

                double srcOpen = Open[0];
                double srcHigh = High[0];
                double srcLow = Low[0];
                double srcClose = Close[0];
                double srcVolume = Volume[0];
                DateTime srcTime = Time[0];

                try { srcOpen = Opens[hiddenVolumetricBarsIndex][0]; } catch { }
                try { srcHigh = Highs[hiddenVolumetricBarsIndex][0]; } catch { }
                try { srcLow = Lows[hiddenVolumetricBarsIndex][0]; } catch { }
                try { srcClose = Closes[hiddenVolumetricBarsIndex][0]; } catch { }
                try { srcVolume = Volumes[hiddenVolumetricBarsIndex][0]; } catch { }
                try { srcTime = Times[hiddenVolumetricBarsIndex][0]; } catch { }

                return new VolumetricSourceContext
                {
                    Available = true,
                    Volumes = vol,
                    BarIndex = idx,
                    BarsInProgressIndex = hiddenVolumetricBarsIndex,
                    IsPrimary = false,
                    SourceName = "Hidden1MinVolumetricBidAsk",
                    SourceTime = srcTime,
                    SourceOpen = srcOpen,
                    SourceHigh = srcHigh,
                    SourceLow = srcLow,
                    SourceClose = srcClose,
                    SourceVolume = srcVolume
                };
            }
            catch
            {
                return null;
            }
        }

        private bool IsPrimaryVolumetricBarsType()
        {
            try
            {
                return Bars != null &&
                    Bars.BarsSeries != null &&
                    Bars.BarsSeries.BarsType is VolumetricBarsType;
            }
            catch
            {
                return false;
            }
        }

        private bool IsPrimaryRangeLike()
        {
            try
            {
                return BarsPeriod != null && BarsPeriod.BarsPeriodType == BarsPeriodType.Range;
            }
            catch
            {
                return false;
            }
        }

        private void RefreshDataQualityLabels()
        {
            try
            {
                bool primaryVol = IsPrimaryVolumetricBarsType();
                string barsToken = SafeBarsFolderToken();
                bool hiddenMode =
                    ExportPreset == ResearchDataExportPresetV1.FullResearch_AutoVolumetric ||
                    ExportPreset == ResearchDataExportPresetV1.FullResearch_Hidden1MinVolumetric;

                primaryDataTypeLabel = primaryVol
                    ? "Data Type: " + barsToken + " Volumetric ✓"
                    : "Data Type: " + barsToken + " Standard ⚠";

                dataQualityStatus = primaryVol ? "OK" : "Info";
                dataQualityWarning = "";

                if (ExportPreset == ResearchDataExportPresetV1.FullResearch_CandleOnly)
                {
                    activeDataModeFolderToken = "CandleOnly";
                    deltaSourceQualityLabel = "Delta: Disabled / no true volumetric";
                    dataQualityStatus = "Info";
                    dataQualityWarning = "CandleOnly preset does not export true bid/ask volumetric delta.";
                }
                else if (primaryVol)
                {
                    activeDataModeFolderToken = "Volumetric";
                    deltaSourceQualityLabel = "Delta: Chart Bid/Ask ✓";
                    dataQualityStatus = "OK";
                }
                else if (hiddenMode)
                {
                    activeDataModeFolderToken = "HiddenVol" + Math.Max(1, HiddenVolumetricMinutes).ToString(CultureInfo.InvariantCulture) + "Min";
                    deltaSourceQualityLabel = "Delta: Hidden " + Math.Max(1, HiddenVolumetricMinutes).ToString(CultureInfo.InvariantCulture) + "m Bid/Ask";
                    dataQualityStatus = IsPrimaryRangeLike() ? "Warning" : "OK";

                    if (IsPrimaryRangeLike())
                        dataQualityWarning = "Normal Range chart plus hidden 1-minute volumetric gives time-bucket delta context, not true range-bar footprint. Use Order Flow Volumetric Range for true range-bar delta.";
                }
                else
                {
                    activeDataModeFolderToken = "Standard";
                    deltaSourceQualityLabel = "Delta: Missing true volumetric ⚠";
                    dataQualityStatus = "Warning";
                    dataQualityWarning = "Primary chart is not Order Flow Volumetric and no hidden volumetric series is enabled.";
                }

                if (ExportPreset == ResearchDataExportPresetV1.FullResearch_ChartVolumetric && !primaryVol)
                {
                    dataQualityStatus = "Warning";
                    dataQualityWarning = "ChartVolumetric preset expects an Order Flow Volumetric primary chart.";
                }

                if (ExportPreset == ResearchDataExportPresetV1.FullResearch_RangeVolumetric)
                {
                    if (!primaryVol || !IsPrimaryRangeLike())
                    {
                        dataQualityStatus = "Warning";
                        dataQualityWarning = "RangeVolumetric preset expects an Order Flow Volumetric Range chart.";
                    }
                }

                activePresetFolderToken = SafePresetFolderToken();
            }
            catch
            {
                primaryDataTypeLabel = "Data Type: Unknown";
                deltaSourceQualityLabel = "Delta: Unknown";
                dataQualityStatus = "Unknown";
                dataQualityWarning = "";
                activeDataModeFolderToken = "UnknownData";
                activePresetFolderToken = "FullResearch";
            }
        }

        private string DashboardDataQualityLine()
        {
            if (!ShowDataQualityOnDashboard)
                return "";

            if (string.IsNullOrWhiteSpace(primaryDataTypeLabel) || string.IsNullOrWhiteSpace(deltaSourceQualityLabel))
                RefreshDataQualityLabels();

            return primaryDataTypeLabel + "   " + deltaSourceQualityLabel + "   " + TickCaptureQualityLabel();
        }

        private string DashboardRangeLine()
        {
            if (!ShowDataQualityOnDashboard)
                return "";

            DateTime first;
            DateTime last;
            string rangeText = TryGetLoadedDataRange(out first, out last)
                ? "Range: " + first.ToString("MMM.dd.yy", CultureInfo.InvariantCulture) + " → " + last.ToString("MMM.dd.yy", CultureInfo.InvariantCulture)
                : "Range: Unknown";

            long loaded = EstimateDashboardTotalBars();
            return rangeText + "   Loaded Bars " + loaded.ToString("n0", CultureInfo.InvariantCulture);
        }

        private string PrimaryDataTypeForExport()
        {
            if (string.IsNullOrWhiteSpace(primaryDataTypeLabel))
                RefreshDataQualityLabels();

            return primaryDataTypeLabel;
        }

        private string DeltaSourceQualityForExport()
        {
            if (string.IsNullOrWhiteSpace(deltaSourceQualityLabel))
                RefreshDataQualityLabels();

            return deltaSourceQualityLabel;
        }

        // ------------------------------------------------------------------
        // File lifecycle
        // ------------------------------------------------------------------
        
private void SetupIdentityAndFolder()
        {
            try
            {
                instrumentMaster = "NA";
                instrumentFull = "NA";
                if (Instrument != null)
                {
                    instrumentFull = string.IsNullOrEmpty(Instrument.FullName) ? "NA" : Instrument.FullName;
                    if (Instrument.MasterInstrument != null && !string.IsNullOrEmpty(Instrument.MasterInstrument.Name))
                        instrumentMaster = Instrument.MasterInstrument.Name;
                }

                RefreshDataQualityLabels();

                string root = string.IsNullOrWhiteSpace(OutputRootFolder) ? DefaultMainExportRoot() : Environment.ExpandEnvironmentVariables(OutputRootFolder.Trim());
                string instrumentFamilyFolder = SafeInstrumentFamilyFolderToken();
                string contractFolder = SafeInstrumentContractFolderToken();
                string dateRangeFolder = SafeDateRangeFolderToken();
                string barsDataFolder = SafeBarsDataFolderToken();
                string exporterFolder = string.IsNullOrEmpty(OutputSubfolder) ? "ResearchDataExporterV1" : SafeFileName(OutputSubfolder);
                string exportTypeFolder = SafeExportTypeFolderToken();

                // Dataset-first layout:
                // Chart Data Exports\<InstrumentFamily>\<Contract>\<DataStart_to_DataEnd>\<Bars_DataMode>\<Exporter>\<Preset_TickMode>\<ExportTimestamp>
                string parentFolder = Path.Combine(root, instrumentFamilyFolder, contractFolder, dateRangeFolder, barsDataFolder, exporterFolder, exportTypeFolder);

                string runFolderName = BuildRunFolderName();
                instrumentFileSafe = SafeFileName(runFolderName);

                if (CreateTimestampedRunFolder)
                    outputFolder = MakeUniqueRunFolder(parentFolder, runFolderName);
                else
                    outputFolder = parentFolder;

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                string baseName = BuildFileBaseName();
                if (string.IsNullOrWhiteSpace(baseName))
                    baseName = instrumentFileSafe;

                barPath = Path.Combine(outputFolder, baseName + "_bars.csv");
                footprintPath = Path.Combine(outputFolder, baseName + "_footprint.csv");
                manifestPath = Path.Combine(outputFolder, baseName + "_manifest.csv");

                if (!OverwriteExistingFiles && !CreateTimestampedRunFolder)
                {
                    if (File.Exists(barPath))
                        barPath = Path.Combine(outputFolder, baseName + "_" + runId + "_bars.csv");
                    if (File.Exists(footprintPath))
                        footprintPath = Path.Combine(outputFolder, baseName + "_" + runId + "_footprint.csv");
                    if (File.Exists(manifestPath))
                        manifestPath = Path.Combine(outputFolder, baseName + "_" + runId + "_manifest.csv");
                }
            }
            catch (Exception ex)
            {
                RecordError("SetupIdentityAndFolder", ex);
            }
        }

        
private string DefaultMainExportRoot()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "NinjaTrader 8",
                "NinjaTrader 8 - Chart Data Exports");
        }

        
private string BuildRunFolderName()
        {
            // v1.9: dataset details now live in parent folders. The run folder is just the
            // export timestamp so the directory tree answers: instrument -> contract -> data range -> bar/data type.
            return MakeSafeFolderName(SafeExportStampToken());
        }

        private string BuildFileBaseName()
        {
            // v1.9: self-describing file names for AI uploads, but short enough to avoid path-length issues.
            string fileBase = SafeInstrumentFileShortToken() + "_" +
                SafeDateRangeFileCompactToken() + "_" +
                SafeBarsDataFileToken() + "_" +
                SafeTickCaptureFolderToken() + "_" +
                SafePresetShortToken() + "_" +
                SafeExportFileStampToken();

            return MakeSafeFolderName(fileBase);
        }

        private string SafeExportStampToken()
        {
            return DateTime.Now.ToString("yyyy.MM.dd-h.mmtt", CultureInfo.InvariantCulture);
        }

        private string SafeExportTimeToken()
        {
            return DateTime.Now.ToString("h.mmtt", CultureInfo.InvariantCulture);
        }

        private string SafeExportFileStampToken()
        {
            return DateTime.Now.ToString("yyyyMMdd-hmmtt", CultureInfo.InvariantCulture);
        }

        private string SafeExportDateFolderToken()
        {
            return DateTime.Now.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
        }

        private string SafeInstrumentFamilyFolderToken()
        {
            string family = instrumentMaster;

            if (string.IsNullOrWhiteSpace(family) || family == "NA")
            {
                string inst = string.IsNullOrWhiteSpace(instrumentFull) ? "" : instrumentFull.Trim();
                if (!string.IsNullOrWhiteSpace(inst))
                    family = inst.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            if (string.IsNullOrWhiteSpace(family) || family == "NA")
                family = "Instrument";

            return SafePrettyToken(family).ToUpperInvariant();
        }

        private string SafeInstrumentContractFolderToken()
        {
            string contract = SafeInstrumentFolderToken();
            if (string.IsNullOrWhiteSpace(contract))
                contract = SafeInstrumentFileShortToken();

            return SafePrettyToken(contract);
        }

        private string SafeBarsDataFolderToken()
        {
            string bars = SafeBarsFolderToken();
            string dataMode = SafeDataModeFolderToken();

            if (string.IsNullOrWhiteSpace(bars))
                bars = "UnknownBars";
            if (string.IsNullOrWhiteSpace(dataMode))
                dataMode = "UnknownData";

            return MakeSafeFolderName(bars + "_" + dataMode);
        }

        private string SafeBarsDataFileToken()
        {
            string bars = SafeBarsFolderToken();
            string mode = SafeDataModeFileToken();

            if (string.IsNullOrWhiteSpace(bars))
                bars = "UnknownBars";
            if (string.IsNullOrWhiteSpace(mode))
                mode = "Data";

            string token = bars + mode;
            return MakeSafeFolderName(token).Replace(".", "").Replace("-", "").Replace("_", "");
        }

        private string SafeDateRangeFileCompactToken()
        {
            try
            {
                DateTime first;
                DateTime last;
                if (!TryGetLoadedDataRange(out first, out last))
                    return "UnknownDates";

                return first.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "-" +
                    last.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return "UnknownDates";
            }
        }

        private string SafeExportTypeFolderToken()
        {
            return MakeSafeFolderName(SafePresetFolderToken() + "_" + SafeTickCaptureFolderToken());
        }

        private string SafeShortDateRangeFileToken()
        {
            return SafeDateRangeFileCompactToken();
        }


        private string MakeUniqueRunFolder(string parentFolder, string runFolderName)
        {
            string safeRunFolderName = MakeSafeFolderName(runFolderName);
            if (string.IsNullOrWhiteSpace(safeRunFolderName))
                safeRunFolderName = DateTime.Now.ToString("yyyy.MM.dd-h.mmtt", CultureInfo.InvariantCulture) + "-ResearchExport";

            string candidate = Path.Combine(parentFolder, safeRunFolderName);

            int n = 2;
            while (Directory.Exists(candidate))
            {
                candidate = Path.Combine(parentFolder, safeRunFolderName + "-Run" + n.ToString(CultureInfo.InvariantCulture));
                n++;
            }

            return candidate;
        }

        private string SafeInstrumentFolderToken()
        {
            string instrument = string.IsNullOrWhiteSpace(instrumentFull) || instrumentFull == "NA" ? instrumentMaster : instrumentFull;
            if (string.IsNullOrWhiteSpace(instrument))
                instrument = "Instrument";

            return SafePrettyToken(instrument);
        }

        private string SafeInstrumentFileShortToken()
        {
            string instrument = string.IsNullOrWhiteSpace(instrumentFull) || instrumentFull == "NA" ? instrumentMaster : instrumentFull;
            if (string.IsNullOrWhiteSpace(instrument))
                instrument = "Instrument";

            // File names are easier to scan when contracts are compact, e.g. NQJUN26.
            return SafePrettyToken(instrument).Replace(".", "");
        }

        private string SafeDateRangeFolderToken()
        {
            try
            {
                DateTime first;
                DateTime last;
                if (!TryGetLoadedDataRange(out first, out last))
                    return "UnknownDates";

                return first.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture) + "_to_" +
                    last.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return "UnknownDates";
            }
        }

        private string SafeBarsFolderToken()
        {
            try
            {
                if (BarsPeriod == null)
                    return "UnknownBars";

                // Order Flow Volumetric bars report their outer BarsPeriodType as Volumetric.
                // For folders/files we want the base bar identity, e.g. 1Min or 20Range,
                // while SafeDataModeFolderToken() separately contributes Volumetric.
                if (IsPrimaryVolumetricBarsType() || BarsPeriod.BarsPeriodType.ToString().IndexOf("Volumetric", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string baseType = TryReadBarsPeriodString("BaseBarsPeriodType", "Minute");
                    int baseValue = TryReadBarsPeriodInt("BaseBarsPeriodValue", BarsPeriod.Value);
                    if (baseValue <= 0)
                        baseValue = BarsPeriod.Value > 0 ? BarsPeriod.Value : 1;

                    return SafeBarsDescriptorFromTypeText(baseType, baseValue);
                }

                return SafeBarsDescriptorFromTypeText(BarsPeriod.BarsPeriodType.ToString(), BarsPeriod.Value);
            }
            catch
            {
                return "UnknownBars";
            }
        }

        private string SafeBarsDescriptorFromTypeText(string typeText, int value)
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

        private string SafeDataModeFolderToken()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activeDataModeFolderToken))
                    RefreshDataQualityLabels();

                return SafePrettyToken(activeDataModeFolderToken);
            }
            catch
            {
                return "UnknownData";
            }
        }

        private string SafeDataModeFileToken()
        {
            string mode = SafeDataModeFolderToken();
            if (mode.IndexOf("Volumetric", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Vol";
            if (mode.IndexOf("Candle", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Candle";
            if (mode.IndexOf("Range", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Range";
            return mode;
        }

        private string SafeTickCaptureFolderToken()
        {
            // This exporter currently writes bar-level and volumetric footprint/context rows,
            // but it does not write a separate raw historical tick-event tape file.
            // "NoTick" is intentionally included in run names so analysis threads know that
            // the export did not include raw tick events. If raw tick export is added later,
            // change this method to return "Tick" only for runs where that file is written.
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
                switch (ExportPreset)
                {
                    case ResearchDataExportPresetV1.FullResearch_AutoVolumetric:
                        return "FullResearch.AutoVol";
                    case ResearchDataExportPresetV1.FullResearch_ChartVolumetric:
                        return "FullResearch.ChartVol";
                    case ResearchDataExportPresetV1.FullResearch_Hidden1MinVolumetric:
                        return "FullResearch.HiddenVol1Min";
                    case ResearchDataExportPresetV1.FullResearch_CandleOnly:
                        return "FullResearch.CandleOnly";
                    case ResearchDataExportPresetV1.FullResearch_RangeVolumetric:
                        return "FullResearch.RangeVol";
                    default:
                        return "FullResearch";
                }
            }
            catch
            {
                return "FullResearch";
            }
        }

        private string SafePresetShortToken()
        {
            try
            {
                switch (ExportPreset)
                {
                    case ResearchDataExportPresetV1.FullResearch_AutoVolumetric:
                        return "AutoVol";
                    case ResearchDataExportPresetV1.FullResearch_ChartVolumetric:
                        return "ChartVol";
                    case ResearchDataExportPresetV1.FullResearch_Hidden1MinVolumetric:
                        return "HiddenVol1Min";
                    case ResearchDataExportPresetV1.FullResearch_CandleOnly:
                        return "CandleOnly";
                    case ResearchDataExportPresetV1.FullResearch_RangeVolumetric:
                        return "RangeVol";
                    default:
                        return "FullResearch";
                }
            }
            catch
            {
                return "FullResearch";
            }
        }

        private bool TryGetLoadedDataRange(out DateTime first, out DateTime last)
        {
            first = DateTime.MinValue;
            last = DateTime.MinValue;

            try
            {
                if (Bars == null || Bars.Count <= 0)
                    return false;

                first = Bars.GetTime(0);
                last = Bars.GetTime(Bars.Count - 1);

                return first != DateTime.MinValue && last != DateTime.MinValue;
            }
            catch
            {
                try
                {
                    if (firstExportedTime != DateTime.MinValue && lastExportedTime != DateTime.MinValue)
                    {
                        first = firstExportedTime;
                        last = lastExportedTime;
                        return true;
                    }
                }
                catch { }

                return false;
            }
        }

        private string SafeBarsPeriodText()
        {
            return SafeBarsFolderToken();
        }

        private void EnsureWriters()
        {
            if (writersOpened)
                return;

            try
            {
                if (string.IsNullOrEmpty(outputFolder))
                    SetupIdentityAndFolder();

                if (ExportBars)
                {
                    barWriter = new StreamWriter(barPath, false, Encoding.UTF8); // false = overwrite, never append
                    barWriter.AutoFlush = false;
                    barWriter.WriteLine(BarHeader());
                }

                if (ExportFootprint)
                {
                    fpWriter = new StreamWriter(footprintPath, false, Encoding.UTF8); // false = overwrite, never append
                    fpWriter.AutoFlush = false;
                    fpWriter.WriteLine(FootprintHeader());
                }

                writersOpened = true;
                DrawStatus(false, "Export started.");
            }
            catch (Exception ex)
            {
                RecordError("EnsureWriters", ex);
                writersOpened = false;

                // v1.5: Do not retry writer creation once per historical bar. A file/path/access
                // problem will not fix itself during the same export pass, and retrying creates
                // thousands of identical errors while exporting zero rows.
                exportFinished = true;
                if (dashboardEndUtc == DateTime.MinValue)
                    dashboardEndUtc = DateTime.UtcNow;
                dashboardStatus = "Error";
                dashboardStatusMessage = "Could not open output CSV files. Check path length/permissions and NinjaScript Output.";
                UpdateDashboardSafe(true);
            }
        }

        private void FinishExport(string reason)
        {
            if (exportFinished)
                return;
            exportFinished = true;
            if (dashboardEndUtc == DateTime.MinValue)
                dashboardEndUtc = DateTime.UtcNow;

            try
            {
                if (barWriter != null)
                {
                    barWriter.Flush();
                    barWriter.Close();
                    barWriter.Dispose();
                    barWriter = null;
                }
            }
            catch (Exception ex) { RecordError("CloseBarWriter", ex); }

            try
            {
                if (fpWriter != null)
                {
                    fpWriter.Flush();
                    fpWriter.Close();
                    fpWriter.Dispose();
                    fpWriter = null;
                }
            }
            catch (Exception ex) { RecordError("CloseFootprintWriter", ex); }

            if (!string.IsNullOrEmpty(reason) && reason.StartsWith("WARNING", StringComparison.OrdinalIgnoreCase) && warningCount == 0)
                RecordWarning(reason);

            if (WriteManifest)
                WriteManifestFile(reason);

            DrawStatus(true, reason);

            if (OpenFolderWhenDone && !folderOpened)
            {
                folderOpened = true;
                try
                {
                    if (!string.IsNullOrEmpty(outputFolder) && Directory.Exists(outputFolder))
                        Process.Start("explorer.exe", "\"" + outputFolder + "\"");
                }
                catch (Exception ex) { RecordWarning("Open folder failed: " + (ex == null ? "unknown error" : ex.Message)); }
            }
        }

        private void WriteManifestFile(string reason)
        {
            try
            {
                if (string.IsNullOrEmpty(manifestPath))
                    return;

                using (StreamWriter sw = new StreamWriter(manifestPath, false, Encoding.UTF8))
                {
                    sw.WriteLine("Key,Value");
                    sw.WriteLine("RunId," + Csv(runId));
                    sw.WriteLine("Reason," + Csv(reason));
                    sw.WriteLine("InstrumentMaster," + Csv(instrumentMaster));
                    sw.WriteLine("InstrumentFull," + Csv(instrumentFull));
                    sw.WriteLine("ChartTag," + Csv(SafeText(ChartTag)));
                    sw.WriteLine("ExportPreset," + Csv(ExportPreset.ToString()));
                    sw.WriteLine("PrimaryDataType," + Csv(PrimaryDataTypeForExport()));
                    sw.WriteLine("IsPrimaryVolumetric," + Csv(IsPrimaryVolumetricBarsType().ToString()));
                    sw.WriteLine("DeltaSourceDetail," + Csv(DeltaSourceQualityForExport()));
                    sw.WriteLine("TickCapture," + Csv(SafeTickCaptureFolderToken()));
                    sw.WriteLine("DataQualityStatus," + Csv(dataQualityStatus));
                    sw.WriteLine("DataQualityWarning," + Csv(dataQualityWarning));
                    sw.WriteLine("BarsPeriodType," + Csv(BarsPeriod == null ? "" : BarsPeriod.BarsPeriodType.ToString()));
                    sw.WriteLine("BarsPeriodValue," + Csv(BarsPeriod == null ? "" : BarsPeriod.Value.ToString(CultureInfo.InvariantCulture)));
                    sw.WriteLine("FirstExportedTime," + Csv(firstExportedTime == DateTime.MinValue ? "" : FormatTime(firstExportedTime)));
                    sw.WriteLine("LastExportedTime," + Csv(lastExportedTime == DateTime.MinValue ? "" : FormatTime(lastExportedTime)));
                    sw.WriteLine("LoadedRangeStart," + Csv(ManifestLoadedRangeStart()));
                    sw.WriteLine("LoadedRangeEnd," + Csv(ManifestLoadedRangeEnd()));
                    sw.WriteLine("BarRowsWritten," + barRowsWritten.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("FootprintRowsWritten," + footprintRowsWritten.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("DuplicateTimestampsSkipped," + duplicateTimestampsSkipped.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("MissingFootprintBars," + missingFootprintBars.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("FootprintMismatchBars," + footprintMismatchBars.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("ErrorCount," + errorCount.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("FirstError," + Csv(firstError));
                    sw.WriteLine("LastError," + Csv(lastError));
                    sw.WriteLine("WarningCount," + DashboardWarningCount().ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("FirstWarning," + Csv(firstWarning));
                    sw.WriteLine("LastWarning," + Csv(lastWarning));
                    sw.WriteLine("BarsFile," + Csv(barPath));
                    sw.WriteLine("FootprintFile," + Csv(footprintPath));
                    sw.WriteLine("OutputFolder," + Csv(outputFolder));
                    sw.WriteLine("OutputRunFolderName," + Csv(string.IsNullOrWhiteSpace(outputFolder) ? "" : Path.GetFileName(outputFolder)));
                    sw.WriteLine("WritersOpened," + Csv(writersOpened.ToString()));
                    sw.WriteLine("CurrentBarAtFinish," + Csv(CurrentBar.ToString(CultureInfo.InvariantCulture)));
                    sw.WriteLine("OverwriteExistingFiles," + Csv(OverwriteExistingFiles.ToString()));
                    sw.WriteLine("CreateTimestampedRunFolder," + Csv(CreateTimestampedRunFolder.ToString()));
                    sw.WriteLine("ExtremeZoneTicks," + ExtremeZoneTicks.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("DiagonalImbalanceRatio," + DiagonalImbalanceRatio.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("MinImbalanceVolume," + MinImbalanceVolume.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("AllowZeroDenominatorImbalances," + Csv(AllowZeroDenominatorImbalances.ToString()));
                }
            }
            catch (Exception ex)
            {
                RecordError("WriteManifestFile", ex);
            }
        }

        // ------------------------------------------------------------------
        // Headers
        // ------------------------------------------------------------------
        private string BarHeader()
        {
            return "ExportRunId,Timestamp,InstrumentMaster,InstrumentFull,ChartTag,BarsPeriodType,BarsPeriodValue,BarIndex,IsFirstBarOfSession,Open,High,Low,Close,Volume,RangePoints,RangeTicks,BodyTicks,UpperWickTicks,LowerWickTicks,CloseLocation,BarDelta,DeltaPerVolume,NinjaCVD,ExportSessionCVD,TotalBuyingVolume,TotalSellingVolume,DeltaPercent,Trades,MaxSeenDelta,MinSeenDelta,DeltaSinceHigh,DeltaSinceLow,MaxPositiveDelta,MaxNegativeDelta,POCPrice,POCVolume,POCPosition,MaxAskPrice,MaxAskVolume,MaxBidPrice,MaxBidVolume,FootprintTotalBid,FootprintTotalAsk,FootprintTotalVolume,FootprintDelta,FootprintNonZeroLevels,FootprintVolumeMismatch,BottomZoneTicks,BottomZoneBid,BottomZoneAsk,BottomZoneVolume,BottomZoneDelta,BottomZoneVolShare,TopZoneBid,TopZoneAsk,TopZoneVolume,TopZoneDelta,TopZoneVolShare,StackedBuyMaxRun,StackedSellMaxRun,BuyImbalanceCount,SellImbalanceCount,TopBuyImbalanceCount,BottomSellImbalanceCount,TopBuyStackMax,BottomSellStackMax,DeltaSource,ExportErrorCountAtBar,PrimaryDataType,IsPrimaryVolumetric,DeltaSourceDetail,DataQualityStatus,DataQualityWarning,OutputRunFolder";
        }

        private string FootprintHeader()
        {
            return "ExportRunId,Timestamp,InstrumentMaster,InstrumentFull,ChartTag,BarsPeriodType,BarsPeriodValue,BarIndex,Open,High,Low,Close,Volume,BarDelta,ExportSessionCVD,PriceLevel,TickIndexFromLow,PricePosition,TotalVol,BidVol,AskVol,LevelDelta,IsBarHigh,IsBarLow,InBottomZone,InTopZone,BuyDiagonalImbalance,SellDiagonalImbalance,VolumetricSource,VolumetricSourceTime";
        }

        // ------------------------------------------------------------------
        // Status + error handling
        // ------------------------------------------------------------------
        private void DrawStatus(bool done, string reason)
        {
            try
            {
                // Remove the old fixed-text dashboard if this script was previously loaded with it.
                try { RemoveDrawObject(DashboardLegacyTextTag); } catch { }

                string cleanReason = reason ?? string.Empty;

                if (done)
                {
                    if (errorCount > 0)
                        dashboardStatus = "Error";
                    else if (DashboardWarningCount() > 0 || cleanReason.StartsWith("WARNING", StringComparison.OrdinalIgnoreCase))
                        dashboardStatus = "Warning";
                    else
                        dashboardStatus = "Complete";
                }
                else
                {
                    dashboardStatus = writersOpened ? "Exporting" : "Preparing";
                }

                dashboardStatusMessage = cleanReason;
                UpdateDashboardSafe(true);
            }
            catch { }
        }

        private void RecordError(string context, Exception ex)
        {
            errorCount++;
            string msg = context + ": " + (ex == null ? "unknown error" : ex.Message);
            if (string.IsNullOrEmpty(firstError))
                firstError = msg;
            lastError = msg;
            dashboardStatus = "Error";
            dashboardStatusMessage = msg;
            if (errorCount <= 10)
                Print("ResearchDataExporterV1 ERROR " + errorCount.ToString(CultureInfo.InvariantCulture) + " — " + msg);
            UpdateDashboardSafe(true);
        }

        private void RecordWarning(string message)
        {
            warningCount++;
            string msg = string.IsNullOrWhiteSpace(message) ? "Warning" : message.Trim();
            if (string.IsNullOrEmpty(firstWarning))
                firstWarning = msg;
            lastWarning = msg;
            if (warningCount <= 10)
                Print("ResearchDataExporterV1 WARNING " + warningCount.ToString(CultureInfo.InvariantCulture) + " — " + msg);
            UpdateDashboardSafe(true);
        }

        private void UpdateDashboardSafe(bool force)
        {
            try
            {
                if (!ShowStatusDashboard)
                    return;

                DateTime now = DateTime.UtcNow;
                if (!force && dashboardLastRefreshUtc != DateTime.MinValue && (now - dashboardLastRefreshUtc).TotalMilliseconds < 220)
                    return;

                dashboardProgressPercent = CalculateDashboardProgressPercent();
                dashboardRowsCached = DashboardTotalRowsExported();
                dashboardFilesCached = DashboardFilesWritten();
                RequestDashboardRefresh(force);
            }
            catch { }
        }

        // ------------------------------------------------------------------
        // Compact navy-glass export HUD
        // ------------------------------------------------------------------
        protected override void OnRender(ChartControl chartControl, ChartScale chartScale)
        {
            base.OnRender(chartControl, chartScale);

            try
            {
                if (!ShowStatusDashboard || ChartPanel == null || RenderTarget == null)
                    return;

                EnsureDashboardMouseHooked();

                string title = DashboardTitle();
                string message = DashboardMessage();
                string stats = DashboardStatsLine();
                string dataLine = DashboardDataQualityLine();
                string rangeLine = DashboardRangeLine();
                string fileLocation = DashboardLocationLine();

                double target = ClampDashboard(CalculateDashboardProgressPercent(), 0, 100);
                dashboardProgressPercent = target;

                if (double.IsNaN(dashboardAnimatedPercent) || double.IsInfinity(dashboardAnimatedPercent))
                    dashboardAnimatedPercent = target;

                dashboardAnimatedPercent += (target - dashboardAnimatedPercent) * 0.22;
                if (Math.Abs(dashboardAnimatedPercent - target) < 0.20)
                    dashboardAnimatedPercent = target;

                bool complete = exportFinished || string.Equals(dashboardStatus, "Complete", StringComparison.OrdinalIgnoreCase) || string.Equals(dashboardStatus, "Warning", StringComparison.OrdinalIgnoreCase);
                bool isError = errorCount > 0 || string.Equals(dashboardStatus, "Error", StringComparison.OrdinalIgnoreCase);
                bool isWarning = !isError && DashboardWarningCount() > 0;

                float panelW = 540f;
                float panelH = ShowDataQualityOnDashboard ? 166f : 128f;
                float marginX = 22f;
                float marginY = 30f;
                float radius = 18f;

                float x = (float)(ChartPanel.X + ChartPanel.W) - panelW - marginX;
                float y = (float)ChartPanel.Y + marginY;

                if (x < ChartPanel.X + 8)
                    x = (float)ChartPanel.X + 8;

                SharpDX.RectangleF panelRect = new SharpDX.RectangleF(x, y, panelW, panelH);
                SharpDX.RectangleF shadowRect = DashboardOffset(panelRect, 0, 5);
                SharpDX.RectangleF glowRect = DashboardInflate(panelRect, 4, 4);

                SharpDX.RectangleF titleRect = new SharpDX.RectangleF(x + 18, y + 12, panelW - 170, 22);
                SharpDX.RectangleF pctRect = new SharpDX.RectangleF(x + panelW - 150, y + 12, 74, 22);
                SharpDX.RectangleF messageRect = new SharpDX.RectangleF(x + 18, y + 37, panelW - 36, 18);
                SharpDX.RectangleF dataRect = new SharpDX.RectangleF(x + 18, y + 58, panelW - 36, 16);
                SharpDX.RectangleF rangeRect = new SharpDX.RectangleF(x + 18, y + 75, panelW - 36, 16);
                SharpDX.RectangleF trackRect = ShowDataQualityOnDashboard
                    ? new SharpDX.RectangleF(x + 18, y + 99, panelW - 36, 13)
                    : new SharpDX.RectangleF(x + 18, y + 63, panelW - 36, 13);
                SharpDX.RectangleF statsRect = ShowDataQualityOnDashboard
                    ? new SharpDX.RectangleF(x + 18, y + 120, panelW - 36, 15)
                    : new SharpDX.RectangleF(x + 18, y + 84, panelW - 36, 15);
                SharpDX.RectangleF locationRect = ShowDataQualityOnDashboard
                    ? new SharpDX.RectangleF(x + 18, y + 142, panelW - 36, 15)
                    : new SharpDX.RectangleF(x + 18, y + 106, panelW - 36, 15);
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

                SharpDX.Color4 panelTop = new SharpDX.Color4(0.055f, 0.175f, 0.290f, 0.91f);
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
                    DashboardDrawTextClipped(DashboardTrim(title, 48), titleFormat, titleRect, textBrush);

                    titleFormat.TextAlignment = SharpDX.DirectWrite.TextAlignment.Trailing;
                    DashboardDrawTextClipped(complete ? "100%" : target.ToString("0", CultureInfo.InvariantCulture) + "%", titleFormat, pctRect, textBrush);
                    titleFormat.TextAlignment = SharpDX.DirectWrite.TextAlignment.Leading;

                    DashboardDrawTextClipped(DashboardTrim(message, 82), smallFormat, messageRect, isWarning ? linkBrush : mutedBrush);

                    if (ShowDataQualityOnDashboard)
                    {
                        DashboardDrawTextClipped(DashboardTrim(dataLine, 96), tinyFormat, dataRect, string.Equals(dataQualityStatus, "Warning", StringComparison.OrdinalIgnoreCase) ? linkBrush : mutedBrush);
                        DashboardDrawTextClipped(DashboardTrim(rangeLine, 96), tinyFormat, rangeRect, mutedBrush);
                    }

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
                    DashboardDrawTextClipped(DashboardTrim(stats, 92), tinyFormat, statsRect, mutedBrush);

                    if (!string.IsNullOrWhiteSpace(fileLocation))
                    {
                        DashboardDrawTextClipped(DashboardTrim(fileLocation, 92), tinyFormat, locationRect, linkBrush);
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
                if (exportFinished || string.Equals(dashboardStatus, "Complete", StringComparison.OrdinalIgnoreCase) || string.Equals(dashboardStatus, "Warning", StringComparison.OrdinalIgnoreCase))
                    return 100;

                if (errorCount > 0 && dashboardProgressPercent > 0)
                    return Math.Min(99, Math.Max(8, dashboardProgressPercent));

                if (!writersOpened)
                    return 6;

                long totalBars = EstimateDashboardTotalBars();
                if (totalBars <= 0)
                    return Math.Max(8, dashboardProgressPercent);

                double p = 100.0 * Math.Max(0, CurrentBar + 1) / Convert.ToDouble(totalBars);
                return ClampDashboard(p, 8, 99);
            }
            catch
            {
                return dashboardProgressPercent > 0 ? dashboardProgressPercent : 8;
            }
        }

        private long EstimateDashboardTotalBars()
        {
            try
            {
                if (Bars != null && Bars.Count > 0)
                    return Math.Max(1, Bars.Count);
                return Math.Max(1, CurrentBar + 1);
            }
            catch
            {
                return Math.Max(1, CurrentBar + 1);
            }
        }

        private string DashboardTitle()
        {
            if (exportFinished)
            {
                if (errorCount > 0)
                    return "Research Export Complete with Errors";
                if (DashboardWarningCount() > 0)
                    return "Research Export Complete with Warnings";
                return "Research Export Complete";
            }

            if (errorCount > 0 || string.Equals(dashboardStatus, "Error", StringComparison.OrdinalIgnoreCase))
                return "Research Export Needs Attention";
            if (string.Equals(dashboardStatus, "Preparing", StringComparison.OrdinalIgnoreCase))
                return "Preparing Research Export";
            if (!writersOpened)
                return "Research Export Ready";

            return "Exporting Research Data";
        }

        private string DashboardMessage()
        {
            string msg = string.IsNullOrWhiteSpace(dashboardStatusMessage) ? "" : dashboardStatusMessage.Trim();

            if (exportFinished)
            {
                if (errorCount > 0)
                    return "Finished with " + errorCount.ToString(CultureInfo.InvariantCulture) + " error" + (errorCount == 1 ? "" : "s") + ". Check NinjaScript Output.";
                if (DashboardWarningCount() > 0)
                {
                    string warning = DashboardShortWarning();
                    return string.IsNullOrWhiteSpace(warning)
                        ? "Finished with " + DashboardWarningCount().ToString(CultureInfo.InvariantCulture) + " warning" + (DashboardWarningCount() == 1 ? "" : "s") + "."
                        : "Warning: " + warning;
                }
                return "All files finalized cleanly.";
            }

            if (!string.IsNullOrWhiteSpace(msg))
                return msg;

            return writersOpened ? "Writing CSV rows..." : "Waiting for historical processing...";
        }

        private string DashboardStatsLine()
        {
            string elapsed = "";
            try
            {
                if (dashboardStartUtc != DateTime.MinValue)
                {
                    DateTime elapsedEnd = (exportFinished && dashboardEndUtc != DateTime.MinValue) ? dashboardEndUtc : DateTime.UtcNow;
                    TimeSpan ts = elapsedEnd - dashboardStartUtc;
                    string timeText = ts.TotalMinutes >= 1
                        ? ((int)ts.TotalMinutes).ToString(CultureInfo.InvariantCulture) + "m " + ts.Seconds.ToString(CultureInfo.InvariantCulture) + "s"
                        : Math.Max(0, (int)ts.TotalSeconds).ToString(CultureInfo.InvariantCulture) + "s";

                    elapsed = "   Elapsed " + timeText;
                }
            }
            catch { }

            return "Bars " + barRowsWritten.ToString("n0", CultureInfo.InvariantCulture) +
                "   Footprint " + footprintRowsWritten.ToString("n0", CultureInfo.InvariantCulture) +
                "   Errors " + errorCount.ToString(CultureInfo.InvariantCulture) +
                "   Warnings " + DashboardWarningCount().ToString(CultureInfo.InvariantCulture) +
                elapsed;
        }

        private long DashboardWarningCount()
        {
            long count = warningCount;

            try
            {
                if (exportFinished)
                {
                    if ((ExportBars && barRowsWritten == 0) || (ExportFootprint && footprintRowsWritten == 0))
                        count++;

                    if (ExportFootprint && missingFootprintBars > 0)
                        count++;

                    if (footprintMismatchBars > 0)
                        count++;
                }
            }
            catch { }

            return count;
        }

        private string DashboardShortWarning()
        {
            if (!string.IsNullOrWhiteSpace(dataQualityWarning))
                return DashboardTrim(dataQualityWarning, 72);

            if (!string.IsNullOrWhiteSpace(lastWarning))
                return DashboardTrim(lastWarning, 72);

            if (exportFinished && ((ExportBars && barRowsWritten == 0) || (ExportFootprint && footprintRowsWritten == 0)))
                return "Zero-row export detected. Check chart history/data settings.";

            if (exportFinished && ExportFootprint && missingFootprintBars > 0)
                return "Footprint data missing on one or more bars.";

            if (exportFinished && footprintMismatchBars > 0)
                return "Footprint total volume mismatch detected.";

            return "";
        }

        private long DashboardTotalRowsExported()
        {
            return barRowsWritten + footprintRowsWritten;
        }

        private int DashboardFilesWritten()
        {
            int count = 0;

            try
            {
                if (!string.IsNullOrEmpty(barPath) && File.Exists(barPath) && new FileInfo(barPath).Length > 0)
                    count++;
                if (!string.IsNullOrEmpty(footprintPath) && File.Exists(footprintPath) && new FileInfo(footprintPath).Length > 0)
                    count++;
                if (!string.IsNullOrEmpty(manifestPath) && File.Exists(manifestPath) && new FileInfo(manifestPath).Length > 0)
                    count++;
            }
            catch { }

            return count;
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
                if (string.IsNullOrWhiteSpace(outputFolder))
                    return "";

                string full = outputFolder.Trim();
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

                if ((System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Control) != System.Windows.Input.ModifierKeys.Control)
                    return;

                if (dashboardLastFolderHitRect.Width <= 0 || string.IsNullOrWhiteSpace(outputFolder))
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
                if (string.IsNullOrWhiteSpace(outputFolder) || !Directory.Exists(outputFolder))
                {
                    RecordWarning("Output folder missing or not created yet: " + outputFolder);
                    return;
                }

                Process.Start("explorer.exe", "\"" + outputFolder + "\"");
                folderOpened = true;
                try { Print("ResearchDataExporterV1 dashboard Ctrl+Click opened output folder: " + outputFolder); } catch { }
                UpdateDashboardSafe(true);
            }
            catch (Exception ex)
            {
                RecordWarning("Dashboard Ctrl+Click could not open output folder. Path: " + outputFolder + " | Error: " + (ex == null ? "unknown error" : ex.Message));
            }
        }

        private void DashboardDrawTextClipped(string text, SharpDX.DirectWrite.TextFormat textFormat, SharpDX.RectangleF layoutRect, SharpDX.Direct2D1.Brush brush)
        {
            if (string.IsNullOrEmpty(text) || textFormat == null || brush == null || RenderTarget == null)
                return;

            try
            {
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
                try { RenderTarget.PopAxisAlignedClip(); }
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

        // ------------------------------------------------------------------
        // Formatting helpers
        // ------------------------------------------------------------------
        private void AddText(StringBuilder sb, string value)
        {
            if (sb.Length > 0)
                sb.Append(',');
            sb.Append(Csv(value));
        }

        private void AddNumber(StringBuilder sb, int value)
        {
            if (sb.Length > 0)
                sb.Append(',');
            sb.Append(value.ToString(CultureInfo.InvariantCulture));
        }

        private void AddNumber(StringBuilder sb, long value)
        {
            if (sb.Length > 0)
                sb.Append(',');
            sb.Append(value.ToString(CultureInfo.InvariantCulture));
        }

        private void AddNumber(StringBuilder sb, double value)
        {
            if (sb.Length > 0)
                sb.Append(',');
            if (double.IsNaN(value) || double.IsInfinity(value))
                return;
            sb.Append(value.ToString("0.########", CultureInfo.InvariantCulture));
        }

        private string Csv(string value)
        {
            if (value == null)
                value = string.Empty;
            bool mustQuote = value.IndexOf(',') >= 0 || value.IndexOf('"') >= 0 || value.IndexOf('\n') >= 0 || value.IndexOf('\r') >= 0;
            if (!mustQuote)
                return value;
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        private string SafeText(string s)
        {
            return string.IsNullOrEmpty(s) ? "" : s.Trim();
        }

        private string SafeFileName(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "data";
            foreach (char c in Path.GetInvalidFileNameChars())
                s = s.Replace(c, '_');
            s = s.Replace(' ', '_');
            s = s.Replace('/', '_');
            s = s.Replace('\\', '_');
            while (s.IndexOf("__", StringComparison.Ordinal) >= 0)
                s = s.Replace("__", "_");
            return s.Trim('_');
        }

        private string SafePrettyToken(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "Data";

            string value = s.Trim();

            foreach (char c in Path.GetInvalidFileNameChars())
                value = value.Replace(c, '.');

            value = value.Replace(' ', '.')
                         .Replace('/', '.')
                         .Replace('\\', '.')
                         .Replace('_', '.')
                         .Replace(':', '.');

            while (value.Contains(".."))
                value = value.Replace("..", ".");

            return value.Trim('.');
        }

        private string MakeSafeFolderName(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "ResearchExport";

            string s = raw.Trim();
            foreach (char c in Path.GetInvalidFileNameChars())
                s = s.Replace(c, '.');

            s = s.Replace(':', '.');

            while (s.Contains(".."))
                s = s.Replace("..", ".");

            return s.Trim('.', ' ');
        }

        private string ManifestLoadedRangeStart()
        {
            DateTime first;
            DateTime last;
            return TryGetLoadedDataRange(out first, out last) ? FormatTime(first) : "";
        }

        private string ManifestLoadedRangeEnd()
        {
            DateTime first;
            DateTime last;
            return TryGetLoadedDataRange(out first, out last) ? FormatTime(last) : "";
        }


        private string FormatTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        private double RoundToTick(double price, double tick)
        {
            if (tick <= 0)
                return price;
            return Math.Round(price / tick, MidpointRounding.AwayFromZero) * tick;
        }

        private delegate long LongGetter();
        private delegate double DoubleGetter();

        private long SafeLong(LongGetter getter)
        {
            try { return getter(); }
            catch { return 0; }
        }

        private double SafeDouble(DoubleGetter getter)
        {
            try { return getter(); }
            catch { return 0.0; }
        }

        // ------------------------------------------------------------------
        // Small data containers
        // ------------------------------------------------------------------
        private class LevelRecord
        {
            public double Price;
            public int TickIndexFromLow;
            public long Bid;
            public long Ask;
            public long Total;
            public long Delta;
            public double PricePosition;
            public bool IsHigh;
            public bool IsLow;
            public bool InBottomZone;
            public bool InTopZone;
            public bool BuyDiagonalImbalance;
            public bool SellDiagonalImbalance;
        }

        private class VolumetricSourceContext
        {
            public bool Available;
            public VolumetricBarsType Volumes;
            public int BarIndex;
            public int BarsInProgressIndex;
            public bool IsPrimary;
            public string SourceName;
            public DateTime SourceTime;
            public double SourceOpen;
            public double SourceHigh;
            public double SourceLow;
            public double SourceClose;
            public double SourceVolume;
        }

        private class FootprintSummary
        {
            public bool Available;
            public string SourceName;
            public DateTime SourceTime;
            public double SourceVolume;
            public List<LevelRecord> Levels = new List<LevelRecord>();

            public long BarDelta;
            public long Trades;
            public long TotalBuyingVolume;
            public long TotalSellingVolume;
            public double DeltaPercent;
            public long MaxSeenDelta;
            public long MinSeenDelta;
            public long DeltaSinceHigh;
            public long DeltaSinceLow;
            public long MaxPositiveDelta;
            public long MaxNegativeDelta;

            public long TotalBid;
            public long TotalAsk;
            public long TotalVolume;
            public long FootprintDelta;
            public long NonZeroLevels;

            public double PocPrice;
            public long PocVolume;
            public double PocPosition;
            public double MaxAskPrice;
            public long MaxAskVolume;
            public double MaxBidPrice;
            public long MaxBidVolume;

            public long BottomBid;
            public long BottomAsk;
            public long BottomVolume;
            public long BottomDelta;
            public double BottomVolumeShare;

            public long TopBid;
            public long TopAsk;
            public long TopVolume;
            public long TopDelta;
            public double TopVolumeShare;

            public int StackedBuyMaxRun;
            public int StackedSellMaxRun;
            public int BuyImbalanceCount;
            public int SellImbalanceCount;
            public int TopBuyImbalanceCount;
            public int BottomSellImbalanceCount;
            public int TopBuyStackMax;
            public int BottomSellStackMax;
        }
    }
}
