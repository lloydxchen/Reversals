# Backtest Priority Ranking

## Tier 1: Build First

| Rank | Hypothesis | Why |
|---:|---|---|
| 1 | F01 Edge exhaustion at location | Core, direct, implementable, convergence. |
| 2 | F03 Intrabar hidden delta flip | Claude full-corpus says this is core; likely biggest upgrade over naive delta. |
| 3 | F02 Absorption to exhaustion | Flagship A+ structure; depends on absorption proxy. |
| 4 | F04 Follow-through timeframe conditional | Load-bearing quality filter; must avoid wrong timeframe use. |
| 5 | F17 Freshness/time stop | Needed for management; corrects Codex 10-min overfit. |

## Tier 2: Add After Baseline

| Rank | Hypothesis | Why |
|---:|---|---|
| 6 | F05 Absorption effort vs result | Core but inferred; use as score. |
| 7 | F06 Positive delta trap at high | Strong and practical at resistance/HOD. |
| 8 | F07 Negative delta absorption at low | Strong mirror at support/LOD. |
| 9 | F08 Failed acceptance/reclaim | Very testable and not fully footprint-dependent. |
| 10 | F18 Composite A+ score | Needed once modules exist; do not build first. |

## Tier 3: Context And False-Positive Filters

| Rank | Hypothesis | Why |
|---:|---|---|
| 11 | F11 Sequencing suppressor | Important anti-fade filter. |
| 12 | F13 Zero-delta noise filter | Easy and low risk. |
| 13 | F14 Big-bar risk filter | Protects R quality. |
| 14 | F19 Flow-driven divergence inversion | Useful but more complex. |
| 15 | F22 Candle color toggle | Helpful but should not be hard universal. |

## Tier 4: Footprint Refinements

| Rank | Hypothesis | Why |
|---:|---|---|
| 16 | F09 Multiple/stacked imbalance failure | Full-corpus strong, but needs reliable imbalance engine. |
| 17 | F10 Delta context branch via bid/offer at extreme | Important if data exists; implementation dependent. |
| 18 | F12 Ratio binary flag | Potentially important, but formula is undisclosed. |
| 19 | F15 POC/value abandonment | Useful context; more complex profile logic. |
| 20 | F16 Back-to-back POC magnet | Less confirmed but clean to test after POC engine exists. |

## Tier 5: Defer

| Rank | Hypothesis | Why |
|---:|---|---|
| 21 | F20 Volume-in-value | Orthogonal but weak/subjective and later-stage. |
| 22 | F21 Second-chance re-entry | Can encode revenge trading; validate core entries first. |

## Fastest Valid MVP

Build:

1. Volumetric data check.
2. Level engine: HOD/LOD and swing high/low.
3. Edge volume high/low.
4. Confirmed edge exhaustion.
5. Max/Min delta fields if available.
6. Basic state machine.
7. Stop reference.
8. CSV export.

Test first:

- F01 alone.
- F01 plus F03.
- F01 plus F02/F05.
- F01 plus F04/F17 management.

## What Not To Test First

- Full composite score with every module.
- Ratio logic before formula validation.
- Trapped trader labels.
- Second-chance re-entry.
- Volume-in-value.
- Auto-trading.

