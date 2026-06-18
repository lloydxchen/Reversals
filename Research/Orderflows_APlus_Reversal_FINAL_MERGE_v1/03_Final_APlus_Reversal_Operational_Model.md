# Final A+ Reversal Operational Model

## Signal Object

Every signal candidate should carry:

| Field | Meaning |
|---|---|
| `direction` | Bullish or bearish. |
| `primary_family` | Exhaustion, absorption, hidden flip, delta trap, failed acceptance, imbalance failure, POC/VA, retest. |
| `edge_price` | Structural price being rejected. |
| `edge_level_type` | HOD, LOD, swing, value, POC, VWAP, user, sweep, none. |
| `entry_reference` | Close, next-bar trigger, reclaim/rejection price. |
| `stop_reference` | Signal extreme plus buffer. |
| `state` | Preview, ConfirmedSignal, Triggered, Validated, Invalidated. |
| `score_components` | Location, failure, confirmation, risk, timing/context. |
| `hard_cap_reason` | Data missing, no location, trend sequencing, stop too wide, preview only, etc. |

## Hard Gates

Reject or cap before scoring:

- No meaningful edge: cap at B or reject.
- Required volumetric data missing for enabled footprint module: disable module or cap grade.
- Signal is intrabar preview only: not final.
- Stop distance too wide: cap at C or reject.
- Price already accepted beyond reversal edge: reject.
- Sequencing/flow-driven continuation against the reversal: suppress or cap.

## Scoring

Use separate bullish and bearish scores.

| Component | Max | Notes |
|---|---:|---|
| Location | 25 | Clean edge dominates. |
| Order-flow failure | 30 | Exhaustion, absorption, hidden flip, delta trap, failed acceptance, imbalance failure. |
| Confirmation | 20 | Bar close, next-bar trigger, reclaim/rejection, follow-through, quick/appropriate response. |
| Risk | 15 | Tight stop, signal bar size, room to first target/reference. |
| Timing/context | 10 | Session phase, chart speed, regime, volatility, freshness. |

Grades:

- A+: 82+ and no hard cap.
- A: 72-81.
- B: 62-71.
- C: 50-61.
- Watch/reject: below 50.

## Core Variables

### Location

- `swing_extreme_rank`
- `session_extreme_flag`
- `level_proximity_ticks`
- `edge_level_type`
- `range_location`
- `vwap_distance_ticks`
- `poc_value_context`

### Exhaustion

- `edge_volume_high`
- `edge_volume_low`
- `exhaustion_flag`
- `edge_volume_percentile`
- `exp_vol_param`

Policy: prefer dynamic low percentile plus instrument defaults. Treat examples like ES around 0, NQ around 3, 10yr around 50 as starting points, not universal constants.

### Intrabar Delta Path

- `MaxSeenDelta`
- `MinSeenDelta`
- `BarDelta`
- `DeltaGiveBackPct`
- `DeltaCloseNearExtreme`

Policy: hidden flip is a core module. Keep percentage soft until validated.

### Absorption

- `effort_result_score`
- `price_delta_efficiency`
- `delta_contradiction_flag`
- `repeated_defense_count`
- `bid_ask_at_extreme`

Policy: without DOM, absorption is inferred. Score it, do not hard-binarize.

### Imbalance

- `multiple_imbalance_count`
- `stack_count`
- `imbalance_direction`
- `cell_volume_min`
- `imbalance_zone_reclaim`
- `opposing_imbalance_flag`

Policy: multiple imbalances are not subordinate to stacked. Ignore position-within-bar. Downgrade low cell-volume stacks.

### Ratio

- `RatioValue`
- `RatioFlag`
- `RatioTier`

Policy: binary/soft-tier flag only. Do not grade magnitude. Formula still needs validation.

### Continuation Suppressors

- `sequencing_flag`
- `flow_driven_flag`
- `zero_delta_noise_flag`
- `trend_acceptance_flag`

Policy: these suppress countertrend reversal signals.

## Confirmation

Use chart-speed conditional confirmation:

- Fast charts: follow-through gate enabled; next 1-2 bars should break/continue in signal direction.
- 5-minute+ and slow instruments: relax/disable strict follow-through; use bar close plus order-flow confirmation.
- Candle color agreement is useful but should be a toggle, not mandatory.

Signal states:

1. `Preview`: intrabar condition visible, can repaint.
2. `ConfirmedSignal`: bar closed and condition remains.
3. `Triggered`: next-bar/reclaim/rejection trigger fires.
4. `Validated`: early MFE or appropriate response occurs.
5. `Invalidated`: stop, acceptance, no response, or opposite signal.

## Invalidation

Hard:

- Long trades below signal low/edge plus buffer.
- Short trades above signal high/edge plus buffer.
- Acceptance beyond failed level.
- Opposite next-bar signal or ratio invalidates imbalance thesis.

Soft:

- No response by chart-speed freshness window.
- Fresh initiative against signal.
- Sequencing/flow-driven regime appears.
- Signal bar too large.

Time/freshness policy:

- Do not use 10 minutes globally.
- Test chart-speed tiers: fast charts 5-10 minutes; slower bars/instruments 30-60 minutes.
- Order-flow freshness decays roughly 30-60 minutes and worsens beyond 5-minute chart context.

## Backtest Priorities

1. Edge exhaustion at location.
2. Hidden delta flip and absorption overlay.
3. Follow-through gate by timeframe.
4. No-response/freshness by chart speed.
5. Delta trap at HOD/LOD/resistance/support.
6. Failed acceptance/reclaim.
7. Multiple/stacked imbalance family.
8. Sequencing suppressor.
9. POC/value family.
10. Volume-in-value.

