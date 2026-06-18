# NinjaTrader A+ Reversal Indicator Spec v2 Extra High

## Purpose

Build a NinjaTrader 8 research indicator that detects, scores, displays, alerts, and exports A+ order-flow reversal candidates.

It should **not** be an auto-trader in v1 implementation. Its first job is to create clean, timestamped signal data for validation.

Core behavior:

- Detect meaningful edge locations.
- Detect order-flow failure at those edges.
- Confirm or reject the signal through staged states.
- Grade the signal without over-hardcoding transcript numbers.
- Export enough fields to audit every signal.

## Required Data

Minimum:

- OHLCV bars.
- Session time, session high/low, prior swing high/low.
- Instrument tick size.
- Bar bid volume, ask volume, and delta.

Full implementation:

- Volumetric/footprint volume at each price level.
- Volume at bar high/low.
- Max delta and min delta.
- Cumulative delta.
- Bid/ask imbalance levels.
- Bar POC and optional value area.
- VWAP and initial balance.
- User-defined levels.

Fallback policy:

- If footprint volume-at-price is unavailable, disable exhaustion and imbalance modules.
- If only bar delta is available, allow delta trap/divergence modules but cap max grade at B.
- If no delta is available, this is not the intended indicator.

## Internal Architecture

### Processing Pipeline

1. Build/update levels:
   - HOD/LOD.
   - Swing high/low.
   - VWAP.
   - Initial balance.
   - POC/value levels if available.
   - User levels.

2. Compute bar footprint features:
   - Delta.
   - Cumulative delta.
   - Edge volume high/low.
   - POC location.
   - Imbalance levels/stacks.
   - Close location value.
   - Range and stop distance.

3. Create directional candidates:
   - One bullish candidate.
   - One bearish candidate.
   - Do not net them until final scoring.

4. Run modules:
   - Edge exhaustion.
   - Absorption.
   - Failed acceptance.
   - Delta trap.
   - Delta weakness/divergence.
   - Imbalance failure.
   - Retest rejection.
   - Climactic volume failure.

5. Apply hard gates/caps.

6. Score components.

7. Assign state:
   - Preview.
   - ConfirmedSignal.
   - Triggered.
   - Validated.
   - Invalidated.

8. Plot/alert/export.

## Candidate State Machine

| State | Meaning | Export? |
|---|---|---|
| `Preview` | Intrabar condition visible but can disappear. | Optional preview export only. |
| `ConfirmedSignal` | Bar closed and signal condition remains. | Yes. |
| `Triggered` | Next bar trades in direction or reclaim/rejection completes. | Yes. |
| `Validated` | Early MFE appears before timeout. | Yes/update. |
| `Invalidated` | Stop, acceptance, no-response, or opposite initiative. | Yes/update. |

Default official signal mode: `ConfirmedSignal` on bar close. Intrabar visuals must be visually different and never counted as final unless user enables preview mode.

## Hard Gates And Grade Caps

Reject:

- Required data missing for enabled primary module.
- Signal has no meaningful edge.
- Price has already accepted beyond the reversal edge.
- Stop distance exceeds hard maximum.

Cap at B:

- No footprint data.
- Delta-only signal without exhaustion/absorption/reclaim.
- Countertrend signal during intact trend-day acceptance.

Cap at C:

- Signal bar too large.
- Signal directly before cash open without later confirmation.
- No response before timeout.

## Scoring

Score bullish and bearish independently.

| Component | Max | Implementation |
|---|---:|---|
| Location | 25 | Weighted level proximity and level type. HOD/LOD/swing/user/value/VWAP score higher than internal noise. |
| Order-flow failure | 30 | Exhaustion, absorption, delta trap, failed imbalance, failed acceptance, no continuation. |
| Confirmation | 20 | Bar close, next-bar trigger, reclaim/rejection, retest rejection, quick MFE. |
| Risk | 15 | Stop distance, signal bar size, room to first reference target. |
| Timing/context | 10 | Session phase, regime, volatility, volume quality. |

Grades:

- A+: `score >= 82` and no cap.
- A: `72-81`.
- B: `62-71`.
- C: `50-61`.
- Watch/reject: `< 50`.

Why score instead of binary:

- The trader's model is confluence-based.
- Absorption/trapped traders are partly inferential.
- Fixed thresholds like 25 lookback and 10 edge volume are defaults, not universal truths.

## Module Logic

### 1. Edge Exhaustion Module

Inputs:

- `SwingLookbackDefault = 25`.
- `EdgeVolumeLimitDefault = 10`.
- `UseEdgeVolumePercentile = true/false`.
- `LevelToleranceTicks`.

Bullish:

- Bar low is near meaningful edge.
- Volume at low <= threshold or below configured percentile.
- Bar closes with signal intact.

Bearish:

- Bar high is near meaningful edge.
- Volume at high <= threshold or below configured percentile.
- Bar closes with signal intact.

Outputs:

- `exhaustion_flag`.
- `exhaustion_edge_volume`.
- `exhaustion_level_type`.
- `exhaustion_score`.

### 2. Absorption Module

Inputs:

- Delta percentile lookback.
- Price-progress-per-delta calculation.
- Close location value.
- Optional repeated defended price detection.

Bullish:

- Selling effort is high but downside result is poor.
- Close is green/off-low or next bar lifts.
- Level supports reversal.

Bearish:

- Buying effort is high but upside result is poor.
- Close is red/off-high or next bar drops.
- Level supports reversal.

Outputs:

- `absorption_score`.
- `effort_result_score`.
- `delta_contradiction_flag`.
- `defended_price`.

Implementation note:

- Without DOM, passive buyers/sellers are inferred. Keep it scored, not hard binary.

### 3. Failed Acceptance Module

Bullish:

- Price breaks below meaningful level.
- Close reclaims above level within reclaim window.

Bearish:

- Price breaks above meaningful level.
- Close returns below level within reclaim window.

Outputs:

- `failed_acceptance_flag`.
- `broken_level_type`.
- `bars_outside_level`.
- `reclaim_speed`.

### 4. Delta Trap Module

Bullish:

- Strong negative delta at low/support.
- Poor downside continuation.
- Price reverses up.

Bearish:

- Strong positive delta at high/resistance.
- Poor upside continuation.
- Price reverses down.

Outputs:

- `delta_trap_score`.
- `delta_percentile`.
- `continuation_failure_score`.

Hard rule:

- Never produce a signal from delta sign alone.

### 5. Delta Weakness / Divergence Module

Bullish:

- Lower low/retest low with less negative delta or cumulative delta non-confirmation.

Bearish:

- Higher high/retest high with less positive delta or cumulative delta non-confirmation.

Outputs:

- `delta_divergence_score`.
- `current_extreme_delta`.
- `prior_extreme_delta`.
- `cum_delta_divergence_flag`.

Cap:

- Divergence alone cannot exceed B.

### 6. Imbalance Failure Module

Bullish:

- Sell imbalances/stack appear near low/support.
- Price does not continue lower.
- Price reclaims imbalance zone.

Bearish:

- Buy imbalances/stack appear near high/resistance.
- Price does not continue higher.
- Price loses imbalance zone.

Settings:

- `ImbalanceRatio`.
- `StackMinLevelsDefault = 3`.
- `FollowThroughWindowBars`.

Outputs:

- `imbalance_failure_score`.
- `stack_count`.
- `imbalance_zone`.
- `zone_reclaim_flag`.

### 7. Retest Rejection Module

Bullish:

- Retest support/low within tolerance.
- Selling is weaker than first test or exhaustion/absorption appears.
- Price rejects upward.

Bearish:

- Retest resistance/high within tolerance.
- Buying is weaker than first test or exhaustion/absorption appears.
- Price rejects downward.

Outputs:

- `retest_score`.
- `test_count`.
- `delta_vs_first_test`.
- `retest_rejection_flag`.

### 8. Climactic Volume Failure Module

Bullish:

- Large sell-volume/delta event at low.
- No continuation.
- Reclaim/reversal.

Bearish:

- Large buy-volume/delta event at high.
- No continuation.
- Rejection/reversal.

Cap:

- Cannot be A+ unless paired with exhaustion, absorption, or failed acceptance.

## Confirmation And Invalidation

Confirmation modes:

- `ConfirmOnClose`: default.
- `ConfirmNextBar`: stricter.
- `ConfirmReclaimReject`: for failed acceptance and sweep logic.
- `PreviewIntrabar`: visual only by default.

Bullish invalidation:

- Trade below signal low plus buffer.
- Acceptance below failed/absorbed level.
- Fresh sell initiative through the edge.
- No-response timeout.

Bearish invalidation:

- Trade above signal high plus buffer.
- Acceptance above failed/absorbed level.
- Fresh buy initiative through the edge.
- No-response timeout.

No-response:

- Emit `NoResponseExit` alert/export field.
- Test 3/5/10 bars and 5/10 minutes.

## Context Filters

Use context as cap/weight, not a blind blocker.

Filters:

- `RegimeScore`: trend, range, transition.
- `RangeLocation`: top/middle/bottom.
- `VWAPDistanceTicks`.
- `VWAPSlope`.
- `InitialBalanceState`: inside, breakout, extension.
- `SessionPhase`: premarket, open, morning, lunch, afternoon, overnight.
- `CashOpenProximity`.
- `SlowMarketFlag`.
- `NewsWindowFlag` if supplied manually.

Rules:

- Downscore countertrend fades during intact trend acceptance.
- Allow countertrend reversal if failed acceptance is explicit.
- Downscore signals in the middle of range.
- Downscore directly before cash open unless later confirmed.

## Visuals

Markers:

- Solid green up arrow for confirmed bullish.
- Solid red down arrow for confirmed bearish.
- Hollow marker for preview.
- Grade text: `A+`, `A`, `B`, `C`.

Zones:

- Edge zone.
- Signal bar high/low stop zone.
- Absorption zone.
- Failed acceptance/reclaim level.
- Imbalance failure zone.

Labels:

- Keep short: `A+ L 86 Exh+Abs`, `A S 76 DeltaTrap`.

Dashboard:

- Bull score.
- Bear score.
- Current dominant module.
- Hard cap reason.
- Data availability.
- Regime.
- Last signal state.

## Alerts

Alert on:

- New A+/A confirmed signal.
- Triggered signal.
- Invalidated signal.
- No-response timeout.
- Data unavailable for enabled modules.

Alert payload:

- Instrument, time, direction, grade, score, primary family, active modules, edge price, entry reference, stop reference, hard cap reason.

## CSV Export Fields

Minimum export:

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
- `hard_gate_status`
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
- `signal_delta`
- `edge_volume_high`
- `edge_volume_low`
- `exhaustion_flag`
- `absorption_score`
- `delta_trap_score`
- `delta_divergence_score`
- `failed_acceptance_flag`
- `imbalance_failure_score`
- `retest_score`
- `context_regime`
- `session_phase`
- `minutes_to_cash_open`
- `mfe_1bar_ticks`
- `mae_1bar_ticks`
- `mfe_3bar_ticks`
- `mae_3bar_ticks`
- `mfe_timeout_ticks`
- `invalidation_reason`

## Settings

Core defaults:

- `Calculate = OnBarClose`.
- `SwingLookback = 25`.
- `EdgeVolumeLimit = 10`.
- `UseEdgeVolumePercentile = false initially`.
- `ConfirmationTicks = 1`.
- `StopBufferTicks = 1`.
- `LevelToleranceTicks = 2`.

Scoring:

- `APlusThreshold = 82`.
- `AThreshold = 72`.
- `BThreshold = 62`.
- `CThreshold = 50`.
- `RequireLevelForAPlus = true`.
- `RequireFailureModuleForAPlus = true`.

Delta:

- `DeltaLookback = 50`.
- `AggressiveDeltaPercentile = 80`.
- `ExtremeDeltaPercentile = 90`.

Imbalance:

- `ImbalanceRatio = platform/default configurable`.
- `StackMinLevels = 3`.

Timing:

- `AvoidMinutesBeforeCashOpen = 5`.
- `NoResponseBars = 5`.
- `NoResponseMinutes = 10`.

Risk:

- `MaxSignalRangePercentile = 75`.
- `MaxStopDistanceTicks = instrument-specific`.

## First Build Scope

Build these first:

1. Level engine.
2. Edge exhaustion module.
3. Absorption score.
4. Delta trap/failure score.
5. Confirmation state machine.
6. No-response management/export.
7. CSV export.

Defer:

- Stop-run special labeling.
- Trapped trader labeling.
- Climactic volume module.
- Second-chance re-entry.
- Any automation.

## What To Test First

1. Pure edge exhaustion versus exhaustion+absorption.
2. Edge volume threshold sensitivity: 5/10/15/20 and percentile alternatives.
3. Swing lookback sensitivity: 10/20/25/50.
4. No-response exits: 3/5/10 bars and 5/10 minutes.
5. Positive delta trap at HOD/resistance.
6. Negative delta absorption at LOD/support.
7. Composite A+ score versus single-module signals.

