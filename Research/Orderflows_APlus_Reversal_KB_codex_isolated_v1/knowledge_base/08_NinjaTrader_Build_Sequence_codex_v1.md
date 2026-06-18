# NinjaTrader Build Sequence Codex v1

Purpose: staged implementation path from the Codex v2 model. Build research/export capability before automation.

## Stage 1: MVP Indicator v1

**What to build**

- Level engine: HOD, LOD, swing high/low, optional user levels.
- Volumetric data access check.
- Edge exhaustion module only.
- Confirm-on-close signal state.
- Basic next-bar trigger flag.
- Structural stop reference.
- Minimal arrows and labels.

**What not to build yet**

- Full A+ score.
- Absorption scoring.
- Trapped trader labels.
- Stop-run labels.
- Imbalance failure.
- Dashboard.
- Auto-trading.

**Required data**

- OHLCV.
- Session high/low.
- Swing high/low.
- Footprint volume at bar high/low.
- Tick size.

**Signal logic**

- Bullish: signal bar low is swing/session/user edge and low-edge volume <= threshold.
- Bearish: signal bar high is swing/session/user edge and high-edge volume <= threshold.
- Signal confirms only after bar close.
- Trigger if next bar trades in signal direction by configurable ticks.

**Output/plot**

- Confirmed bullish/bearish arrow.
- Label: `Exh L` or `Exh S`.
- Plot edge line and stop line.
- Data status text: `Volumetric OK` or `Volumetric Missing`.

**Risks**

- Threshold 10 and swing lookback 25 may not generalize.
- Mid-range signals will overfire if level engine is weak.
- Intrabar previews can mislead, so avoid them in MVP.

## Stage 2: v2 Scoring Engine

**What to build**

- Separate bull/bear candidate objects.
- Score components: location, order-flow failure, confirmation, risk, timing.
- Absorption score.
- Delta trap/failure score.
- Signal bar risk quality.
- No-response timeout state.
- Hard gates and grade caps.

**What not to build yet**

- Imbalance failure.
- Climactic volume.
- Second-chance re-entry.
- Complex dashboards.
- Strategy automation.

**Required data**

- Stage 1 data.
- Bar delta.
- Delta percentile/z-score lookback.
- Close location value.
- MFE/MAE tracking after signal.
- Optional cumulative delta.

**Signal logic**

- Start with VH001, VH002, VH003, VH004, VH005, VH014, VH015, VH018.
- A+ requires meaningful level, failure module, confirmation, acceptable stop, and no hard cap.
- Delta sign alone cannot trigger a signal.
- Absorption is scored through effort-versus-result and close/delta contradiction.

**Output/plot**

- Grade labels: `A+`, `A`, `B`, `C`.
- Reason label: `Exh+Abs`, `DeltaTrap`, `NegDeltaAbs`.
- Hard cap reason in Data Box or small panel.
- Optional bar brush only for A/A+.

**Risks**

- Absorption is inferred without DOM.
- Too many weights can hide bad rules.
- Quick-response timeout may cut delayed winners if made too strict.

## Stage 3: v3 Visualization / Dashboard

**What to build**

- Compact dashboard panel.
- Bull score and bear score.
- Active modules.
- Current state: Preview, ConfirmedSignal, Triggered, Validated, Invalidated.
- Edge zone, stop zone, absorption zone.
- Optional preview markers with hollow style.

**What not to build yet**

- Bulk CSV analytics.
- Optimization logic.
- Automated order submission.
- Lower-confidence modules unless Stage 2 is stable.

**Required data**

- Stage 2 signal object.
- Plot objects for zones/markers.
- State history for last signal.

**Signal logic**

- No new signal logic required.
- Visualization must reflect the scoring/state engine exactly.
- Preview markers must be visually distinct and never confused with confirmed signals.

**Output/plot**

- Dashboard fields: data status, regime, bull score, bear score, grade, active modules, hard cap reason.
- Zones: edge, stop, failed acceptance/reclaim when available.
- Alerts for A/A+ confirmed and invalidation.

**Risks**

- Chart clutter.
- Preview markers can create perceived repainting.
- Too much visual detail makes discretionary use worse.

## Stage 4: v4 CSV / Backtest Export

**What to build**

- CSV export for every confirmed signal and every state update.
- Export MFE/MAE after 1 bar, 3 bars, and timeout window.
- Export all score components and hard cap reasons.
- Export threshold/settings snapshot.
- Optional separate preview export file.

**What not to build yet**

- Automated strategy entries.
- Parameter optimizer inside indicator.
- Re-entry logic.

**Required data**

- Complete signal object.
- Feature columns listed in `09_Feature_Column_Schema_codex_v1.csv`.
- Instrument, timestamp, bar index.
- Forward MFE/MAE tracking.

**Signal logic**

- Export confirmed signals even if low grade, so filters can be tested later.
- Export invalidation/no-response outcomes as updates.
- Keep bull and bear scores separate.

**Output/plot**

- CSV rows keyed by `signal_id`.
- Fields for state transitions.
- Optional chart label with exported signal ID.

**Risks**

- File write performance in real time.
- Duplicated rows if state updates are not keyed cleanly.
- Lookahead bias if MFE/MAE is written as if known at signal time. Separate signal-time fields from outcome fields.

## Stage 5: v5 Refinement After Backtest

**What to build**

- Threshold sensitivity reports from exported CSV.
- Module ablation: exhaustion only, exhaustion+absorption, delta trap only, composite.
- Instrument/session-specific defaults.
- Add failed acceptance/retest module if early results justify.
- Add imbalance failure only after core model is stable.

**What not to build yet**

- Second-chance re-entry unless base stop logic is validated.
- Stop-run/trapped-trader naming as primary labels.
- Full auto-trading without out-of-sample evidence.

**Required data**

- Stage 4 exports.
- Backtest analytics outside the indicator.
- Separate in-sample/out-of-sample date ranges.

**Signal logic**

- Promote only rules that survive threshold changes.
- Keep A+ grade strict.
- Use context filters as caps/weights, not fragile binary blockers.

**Output/plot**

- Updated default settings.
- Reduced module list if weak modules add noise.
- Cleaner A+ labels.

**Risks**

- Overfitting to one instrument/session.
- Optimizing thresholds before confirming data quality.
- Confusing management edge with entry edge.

## Fastest MVP Path

Build only:

1. Volumetric data check.
2. Swing/session edge detection.
3. Edge exhaustion at high/low.
4. Confirm-on-close signal.
5. Next-bar trigger flag.
6. Stop reference.
7. Minimal CSV row.

Then test VH001 and VH014 before adding absorption.

