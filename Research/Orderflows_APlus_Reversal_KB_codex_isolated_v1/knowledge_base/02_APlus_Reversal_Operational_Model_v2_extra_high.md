# A+ Reversal Operational Model v2 Extra High

This v2 turns the synthesis into an implementation-ready scoring model. It separates **hard gates**, **scored evidence**, and **management rules** so the indicator does not become a brittle pile of binary filters.

## Signal Object

Each candidate signal should produce this internal object:

| Field | Meaning |
|---|---|
| `direction` | Bullish or bearish. |
| `primary_family` | Exhaustion, absorption, failed acceptance, delta trap, divergence, imbalance failure, retest rejection, climactic failure. |
| `active_modules` | All modules contributing to score. |
| `edge_price` | Structural level being rejected. |
| `entry_reference` | Close, next-bar trigger, reclaim level, or retest rejection price. |
| `stop_reference` | Signal extreme plus buffer. |
| `hard_gate_status` | Pass/fail reasons. |
| `score_components` | Location, failure, confirmation, risk, timing. |
| `grade` | A+, A, B, C, watch, reject. |
| `evidence_class` | Direct support, interpretation, crude approximation. |

## Hard Gates

These should reject or cap the signal before scoring:

| Gate | Reject or cap condition |
|---|---|
| Data gate | Required volumetric/footprint data missing for enabled module. |
| Location gate | No meaningful edge: not near swing/session/user/value/VWAP/POC level. Cap at B unless testing pure footprint signals. |
| Stop gate | Stop distance above configured max. Cap at C or reject. |
| Confirmation gate | Signal is intrabar preview only. Mark provisional; do not export as confirmed. |
| Acceptance gate | Price has already accepted beyond the proposed reversal edge. Reject. |
| Context gate | Strong trend-day continuation still intact. Cap countertrend signals unless failed acceptance is explicit. |

## Score Model

Use separate bullish and bearish scores. Do not net them too early; a bar can contain competing evidence.

| Component | Max | What earns points |
|---|---:|---|
| Location quality | 25 | HOD/LOD, swing high/low, prior support/resistance, value/POC/VWAP, clean retest, failed breakout/sweep level. |
| Order-flow failure | 30 | Exhaustion, absorption, delta trap, no continuation, failed imbalance, failed acceptance. |
| Confirmation | 20 | Bar close, next-bar directional trade, reclaim/rejection, retest failure, quick MFE. |
| Risk quality | 15 | Tight structural stop, signal bar not oversized, room to first target/reference. |
| Timing/context | 10 | Session quality, not directly before cash open, volatility not hostile, regime matches setup. |

Grades:

- A+: 82-100 and no hard cap.
- A: 72-81.
- B: 62-71.
- C: 50-61.
- Watch/reject: below 50.

V2 raises A+ from 80 to 82 to reduce borderline over-labeling. This is a research default, not a claim from the transcripts.

## Evidence Classes

| Class | Use |
|---|---|
| Direct support | Trader explicitly supports the concept: exhaustion at edge, bar close confirmation, quick response, positive delta can be bearish, negative delta green candle absorption, context matters. |
| Interpretation | Operational proxy for a discretionary idea: absorption score, trapped trader zone, good location, failed acceptance. |
| Crude approximation | Numeric thresholds: 25 swing lookback, 10 edge volume, 3 stacked imbalances, 1-3 bar reclaim, 10-minute timeout. |

## Module Specifications

### Module A: Edge Exhaustion

Variables:

- `edge_volume`: volume at high for bearish, low for bullish.
- `is_edge_level`: swing/session/user/value level boolean.
- `swing_rank`: percentile rank of high/low over lookback.
- `exhaustion_threshold`: configurable edge volume.
- `signal_bar_range_pct`: bar range percentile.

Research rule:

- Bullish if `edge_volume_low <= threshold` and bar low is meaningful edge.
- Bearish if `edge_volume_high <= threshold` and bar high is meaningful edge.

Scoring:

- Low edge volume: 0-12.
- Level quality: 0-10.
- Smaller stop/range: 0-5.
- Prior delta weakening/absorption: 0-8.

Do not hardcode 10 except as default. Test 5, 10, 15, 20 and percentile alternatives.

### Module B: Absorption / Effort Versus Result

Variables:

- `delta_percentile`.
- `price_progress_ticks`.
- `close_location_value`.
- `delta_close_contradiction`.
- `repeated_defense_count`.
- `volume_at_defended_price`.

Research rules:

- Bullish absorption: high selling effort but low downside result at support/low.
- Bearish absorption: high buying effort but low upside result at resistance/high.

Scoring:

- Effort high/result poor: 0-12.
- Close contradiction: 0-6.
- Repeated defense: 0-6.
- Level alignment: 0-6.

Notes:

- This is not directly observable passive liquidity unless DOM is available. Historical footprint implementation is an inference.

### Module C: Failed Acceptance / Reclaim

Variables:

- `break_level_type`.
- `break_distance_ticks`.
- `bars_outside_level`.
- `close_back_inside`.
- `reclaim_speed`.
- `volume_delta_at_break`.

Research rules:

- Bullish: break below support/low/value then close back above.
- Bearish: break above resistance/high/value then close back below.

Scoring:

- Level quality: 0-10.
- Reclaim speed: 0-8.
- Aggressive break/no result: 0-8.
- Stop compactness: 0-4.

Avoid:

- Calling every wick a sweep. Require a level and visible failure.

### Module D: Delta Trap / Delta Failure

Variables:

- `delta_zscore`.
- `delta_percentile`.
- `price_delta_efficiency`: price progress per delta unit.
- `next_bar_delta`.
- `continuation_mfe_ticks`.

Research rules:

- Strong positive delta at resistance is bearish only if no continuation.
- Strong negative delta at support is bullish only if no continuation.

Scoring:

- Aggressive delta at poor location: 0-8.
- Poor continuation: 0-10.
- Opposite response: 0-8.
- Absorption/exhaustion confluence: 0-6.

This module should never fire on delta sign alone.

### Module E: Delta Weakness / Divergence

Variables:

- `price_extreme_delta`.
- `prior_extreme_delta`.
- `cum_delta_at_price_extreme`.
- `delta_slope`.
- `divergence_magnitude`.

Research rules:

- Bullish: lower low with less negative delta or cumulative delta non-confirmation.
- Bearish: higher high with less positive delta or cumulative delta non-confirmation.

Scoring:

- Divergence magnitude: 0-10.
- Level alignment: 0-8.
- Confirmation: 0-8.
- Confluence with exhaustion/absorption: 0-6.

No standalone A+ from divergence.

### Module F: Imbalance Failure

Variables:

- `imbalance_direction`.
- `stack_count`.
- `imbalance_zone_high/low`.
- `follow_through_ticks`.
- `zone_reclaim`.

Research rules:

- Bullish: sell stack/cluster into low fails and is reclaimed.
- Bearish: buy stack/cluster into high fails and is lost.

Scoring:

- Stack/cluster strength: 0-8.
- Edge location: 0-8.
- No follow-through: 0-8.
- Reclaim/loss of zone: 0-8.

Threshold note:

- 3 adjacent imbalances is a common candidate, but evidence supports context more strongly than a fixed count.

### Module G: Retest Rejection

Variables:

- `prior_level_price`.
- `retest_distance_ticks`.
- `test_count`.
- `delta_vs_first_test`.
- `retest_rejection_close`.

Research rules:

- Bullish: retest of low/support has weaker selling or exhaustion and rejects up.
- Bearish: retest of high/resistance has weaker buying or exhaustion and rejects down.

Scoring:

- Clean first level: 0-8.
- Controlled retest within tolerance: 0-6.
- Weaker order flow on retest: 0-10.
- Rejection confirmation: 0-8.

Cap:

- Too many tests degrade the level.

### Module H: Climactic Volume Failure

Variables:

- `volume_percentile`.
- `delta_percentile`.
- `edge_location`.
- `post_spike_continuation`.
- `post_spike_reversal`.

Research rule:

- Large volume is not a signal. It becomes relevant only when the market fails after the spike.

Scoring:

- Extreme volume at edge: 0-8.
- No continuation: 0-10.
- Reversal confirmation: 0-8.
- Context confluence: 0-4.

Cap:

- Cannot be A+ without absorption/exhaustion/reclaim.

## Confirmation Logic

Confirmation should be staged:

1. `Preview`: intrabar condition appears. Not final.
2. `ConfirmedSignal`: signal bar closes and condition remains.
3. `Triggered`: next bar trades in direction or level reclaim/rejection completes.
4. `Validated`: early MFE occurs before no-response timeout.
5. `Invalidated`: stop/acceptance/no-response/opposite initiative.

This state model is more implementable than one final boolean.

## Invalidation Logic

Hard invalidation:

- Long: trade below signal low/edge plus buffer.
- Short: trade above signal high/edge plus buffer.
- Acceptance beyond failed level.

Soft invalidation:

- No response by timeout.
- Fresh delta/imbalance expansion against signal.
- Context flips into trend continuation.

No-response rule:

- Use as exit/downgrade, not as an entry filter.
- Test 3, 5, and 10 bars plus time-based versions.

## Backtest Priority

| Priority | Hypothesis group | Reason |
|---:|---|---|
| 1 | Edge exhaustion plus location | Most direct and implementable. |
| 2 | Absorption-to-exhaustion | Strongest qualitative A+ but needs absorption proxy. |
| 3 | Quick-response management | Directly supported and easy to test. |
| 4 | Delta trap/failure | Strong evidence but needs level filter. |
| 5 | Failed acceptance/reclaim | Practical and testable. |
| 6 | Retest rejection | Useful but level definition matters. |
| 7 | Imbalance failure | Needs reliable footprint imbalance engine. |
| 8 | Stop-run/trapped/climax | Keep secondary until better evidence/labels. |

## Threshold Policy

Use three layers:

- **Defaults:** transcript-derived or reasonable research starts.
- **Sensitivity grid:** test broad ranges.
- **Production values:** only after out-of-sample validation.

Do not promote a number to production just because it appeared in a video. The trader's 25/10 exhaustion settings are valuable defaults, not universal law.

