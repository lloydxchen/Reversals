# Final NinjaTrader Indicator Spec

## Purpose

Build `OrderflowAplusReversal_Final_v1`, a NinjaTrader 8 research indicator that detects, scores, plots, alerts, and exports A+ order-flow reversal candidates.

Do not build an auto-trader first. Build a signal/export tool that can survive backtest audit.

## Required Data

Minimum:

- OHLCV.
- Session time and session high/low.
- Swing high/low.
- Tick size.
- Bid/ask bar delta.

Full:

- Volumetric/footprint series.
- Bid/ask volume at each price level.
- Volume at bar high/low.
- MaxSeenDelta and MinSeenDelta.
- Cumulative delta.
- Diagonal imbalance flags/counts.
- POC and value area if available.
- VWAP and initial balance.
- User levels.

If footprint data is missing, disable exhaustion/imbalance modules and cap grade at B. If Max/Min delta are missing, disable hidden-flip module and mark data risk.

## Architecture

1. Build levels:
   - HOD/LOD.
   - Swing highs/lows.
   - VWAP.
   - Initial balance.
   - POC/value area if available.
   - User levels.

2. Compute features on closed bars:
   - Edge volume high/low.
   - Bar delta.
   - MaxSeenDelta/MinSeenDelta.
   - Delta give-back.
   - Cumulative delta.
   - Imbalances/multiple/stacked/inverse.
   - POC/value features.
   - Signal bar range and stop distance.

3. Create separate bull and bear candidates.

4. Run modules:
   - Edge exhaustion.
   - Absorption/effort vs result.
   - Intrabar hidden delta flip.
   - Delta trap/context branch.
   - Failed acceptance/reclaim.
   - Imbalance failure.
   - POC/VA context.
   - Sequencing/flow-driven suppressor.

5. Apply gates/caps.

6. Score and assign grade/state.

7. Plot, alert, export.

## State Machine

- `Preview`: intrabar only; optional visual, not official.
- `ConfirmedSignal`: bar closed and condition remains.
- `Triggered`: next-bar or reclaim/rejection trigger fires.
- `Validated`: favorable movement appears inside freshness window.
- `Invalidated`: stop, acceptance, stale/no response, or opposite signal.

Default official signal mode: closed bar. Intrabar previews must be visually distinct.

## Hard Gates And Caps

Reject:

- No meaningful edge.
- Price has accepted through proposed reversal edge.
- Required data missing for chosen primary module.
- Stop exceeds hard max.

Cap at B:

- Delta-only signal with no exhaustion/absorption/reclaim.
- Missing footprint data.
- Countertrend signal during sequencing/flow-driven continuation.

Cap at C:

- Signal bar oversized.
- Directly before major session transition without later confirmation.
- No response inside chart-speed freshness window.

## Scoring

Max 100:

- Location: 25.
- Order-flow failure: 30.
- Confirmation: 20.
- Risk: 15.
- Timing/context: 10.

Grades:

- A+: 82+ and no cap.
- A: 72-81.
- B: 62-71.
- C: 50-61.
- Watch/reject: below 50.

Keep score components exported. Do not hide weak rules inside a total score.

## Module Specs

### Edge Exhaustion

Inputs:

- `UseDynamicExpVol`.
- `ExpVolByInstrument`.
- `EdgeVolumePercentileLookback`.
- `SwingLookback`.
- `LevelToleranceTicks`.

Logic:

- Bullish: low edge volume at qualified low/support.
- Bearish: low edge volume at qualified high/resistance.
- Threshold must be instrument/timeframe scaled.

Outputs:

- `exhaustion_flag`
- `edge_volume_low`
- `edge_volume_high`
- `edge_volume_percentile`
- `exhaustion_score`

### Absorption / Effort vs Result

Inputs:

- Delta percentile/z-score.
- Price progress per delta.
- Close location.
- Bid/ask at extreme if available.

Logic:

- Bullish: selling effort fails at low/support.
- Bearish: buying effort fails at high/resistance.

Outputs:

- `absorption_score`
- `effort_result_score`
- `delta_contradiction_flag`
- `bid_ask_at_extreme`

### Intrabar Hidden Delta Flip

Inputs:

- `MaxSeenDelta`
- `MinSeenDelta`
- `BarDelta`

Logic:

- Bullish: large negative MinSeenDelta gives back toward zero/positive close at low.
- Bearish: large positive MaxSeenDelta gives back toward zero/negative close at high.

Outputs:

- `DeltaGiveBackPct`
- `hidden_flip_flag`
- `delta_path_score`

Keep give-back threshold soft/configurable.

### Delta Trap / Context Branch

Logic:

- Positive delta at high is bearish only when no continuation/rejection.
- Negative delta at low is bullish only when no continuation/absorption.
- Positive delta at low needs per-level bid/offer disambiguation.
- Zero/near-zero delta is noise.

Outputs:

- `DeltaSignContext`
- `delta_trap_score`
- `zero_delta_noise_flag`

### Failed Acceptance / Sweep

Logic:

- Bullish: break below level then reclaim.
- Bearish: break above level then reject.

Outputs:

- `failed_acceptance_flag`
- `broken_level_type`
- `bars_outside_level`
- `reclaim_flag`

### Imbalance Family

Logic:

- Detect multiple, stacked, inverse.
- Multiple can rank equal/above stacked.
- Stack count: 3 generally, 2 on fast charts.
- Downgrade low cell-volume stacks.
- Ignore position-within-bar.
- Opposing imbalance/ratio can void quickly.

Outputs:

- `ImbType`
- `multiple_imbalance_count`
- `stack_count`
- `cell_volume_min`
- `imbalance_zone_reclaim`
- `opposing_imbalance_flag`

### POC / Value Modules

Logic:

- Abandoned value/POC: next bar does not retrade zone.
- Back-to-back POC: 2+ bars share exact POC price; trade return after price leaves.

Outputs:

- `abandoned_va_flag`
- `back_to_back_poc_flag`
- `b2b_poc_price`

### Sequencing Suppressor

Logic:

- Escalating volume eaten through successive levels = continuation.
- Suppress or cap countertrend reversal.

Outputs:

- `sequencing_flag`
- `flow_driven_flag`
- `hard_cap_reason`

## Confirmation

Settings:

- `FollowThroughEnabledTimeframeMax = 4 minutes`.
- Follow-through: 1-2 ticks / 1-2 bars on fast charts.
- Disable/relax on >=5-minute charts and slow instruments.
- Candle color filter toggle, default on for fast charts.

Confirmed signal should never be backdated. MFE/MAE fields are outcome fields only.

## Invalidation

Hard:

- Signal extreme breach plus buffer.
- Acceptance beyond failed level.
- Opposite next-bar ratio/signal for imbalance thesis.

Soft:

- No response inside freshness window.
- Sequencing/flow-driven continuation appears.
- Opposite initiative expands.
- Signal bar/risk too large.

Time stop:

- Fast chart test: 5-10 minutes.
- Slow chart/instrument test: 30-60 minutes.
- Export `FreshnessMinsLeft`.

## Visuals

- Solid arrows for confirmed signals.
- Hollow markers for preview.
- Grade badge: A+, A, B, C.
- Reason label: `Exh+Abs`, `HiddenFlip`, `DeltaTrap`, `FailAccept`, `MultImb`.
- Edge zone.
- Stop zone.
- Reclaim/rejection level.
- Optional POC/value markers.
- Dashboard: score, grade, state, primary family, active modules, hard cap reason, data availability, regime/suppressor.

## Alerts

Alert on:

- A+/A confirmed.
- Triggered.
- Invalidated.
- No-response/stale.
- Data missing for enabled module.

Payload:

- Instrument.
- Time.
- Direction.
- Grade.
- Score.
- Primary family.
- Active modules.
- Edge price.
- Entry reference.
- Stop reference.
- Hard cap reason.

## CSV Export Fields

Export at minimum:

- `signal_id`
- `timestamp`
- `instrument`
- `bar_index`
- `direction`
- `state`
- `grade`
- `total_score`
- `location_score`
- `failure_score`
- `confirmation_score`
- `risk_score`
- `timing_score`
- `primary_family`
- `active_modules`
- `hard_cap_reason`
- `edge_price`
- `edge_level_type`
- `entry_reference`
- `stop_reference`
- `stop_distance_ticks`
- `signal_high`
- `signal_low`
- `signal_open`
- `signal_close`
- `signal_volume`
- `BarDelta`
- `MaxSeenDelta`
- `MinSeenDelta`
- `DeltaGiveBackPct`
- `edge_volume_high`
- `edge_volume_low`
- `exhaustion_flag`
- `absorption_score`
- `delta_trap_score`
- `failed_acceptance_flag`
- `ImbType`
- `multiple_imbalance_count`
- `stack_count`
- `cell_volume_min`
- `RatioValue`
- `RatioFlag`
- `back_to_back_poc_flag`
- `abandoned_va_flag`
- `sequencing_flag`
- `zero_delta_noise_flag`
- `timeframe_gate_applied`
- `mfe_1bar_ticks`
- `mae_1bar_ticks`
- `mfe_3bar_ticks`
- `mae_3bar_ticks`
- `mfe_timeout_ticks`
- `invalidation_reason`

## Smart Defaults

- `Calculate = OnBarClose`.
- `SwingLookback = 25` as starting point only.
- `UseDynamicExpVol = true`.
- `EdgeVolumePercentileLookback = 100`.
- `ConfirmationTicks = 1`.
- `StopBufferTicks = 1`.
- `APlusThreshold = 82`.
- `FollowThroughEnabledTimeframeMax = 4 minutes`.
- `TimeStopFastMinutes = 10`.
- `TimeStopSlowMinutes = 60`.
- `StackMin = 3`, `StackMinFast = 2`.
- `IgnoreImbalancePosition = true`.
- `ZeroDeltaSuppressor = true`.
- `SequencingSuppressor = true`.

## Build Order

1. Data availability and level engine.
2. Edge exhaustion.
3. Max/Min delta hidden flip.
4. Absorption/delta trap.
5. Confirmation/state machine.
6. CSV export.
7. Failed acceptance.
8. Imbalance family.
9. POC/value modules.
10. Sequencing suppressor.

No automation until signal export has been backtested.

