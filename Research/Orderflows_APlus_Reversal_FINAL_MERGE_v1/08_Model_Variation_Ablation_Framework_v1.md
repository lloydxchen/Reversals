# Model Variation Ablation Framework v1

## Purpose

Test whether market internals and Level 2 depth improve the transcript-derived A+ reversal model without corrupting the baseline.

The baseline model is the benchmark. L2 and TICK are not gimmicks. They may be more predictive at the exact turn. But they must prove incremental value over the footprint/order-flow model instead of replacing it by assumption.

## Model Ladder

### A. Baseline

**Includes**

- Transcript-derived footprint/order-flow model only.
- Edge exhaustion.
- Absorption/effort-vs-result.
- Intrabar Max/Min delta hidden flip.
- Delta trap/context branch.
- Failed acceptance/reclaim.
- Imbalance family.
- POC/value context where available.
- Sequencing suppressor.
- Follow-through/freshness/risk logic.

**Excludes**

- CME Level 2 depth/order book.
- TICK, market internals, and external index top-of-book.

**Why it exists**

This is the clean benchmark. If enhanced models cannot beat this after costs and robustness checks, the enhancements are not worth implementation complexity.

### B. Baseline + Market Internals

**Includes**

- All baseline features.
- TICK extreme at reversal location.
- TICK divergence versus price.
- TICK recovery after sweep.
- TICK failure to confirm new price extreme.
- Index/top-of-book broad-market confirmation.
- Risk-on/risk-off context.

**Test roles**

- Context filter.
- Score boost.
- Confirmation.
- Veto.

**Why it exists**

Market internals may identify whether the reversal is broad participation or only local footprint noise. It should be tested as context first, then as veto/confirmation only if it materially improves expectancy.

### C. Baseline + Level 2

**Includes**

- All baseline features.
- CME market depth/order book features.
- Bid/ask depth imbalance near the reversal level.
- Depth within 1/3/5/10 price levels.
- Liquidity pull rate.
- Passive replenishment after aggressive trades.
- Book flip after sweep.
- Sweep through visible liquidity.
- Resting liquidity at prior high/low.
- Absorption where aggressive trades fail while passive side replenishes.
- Microprice/book pressure divergence from price.
- Spread/quote instability.
- Quote velocity/order-book churn.
- Before/during/after sweep depth behavior.

**Test roles**

- Confirmation.
- Score boost.
- Veto.
- Timing refinement.
- Invalidation.

**Why it exists**

Depth may show the passive side defending or disappearing before footprint bars finalize. This can improve timing and false-positive filtering, but it must respect no-lookahead and must not front-run a transcript signal unless explicitly tested as an L2-assisted timing variant.

### D. Baseline + Market Internals + Level 2

**Includes**

- Full baseline.
- TICK/index context.
- Level 2 depth/order book.

**Why it exists**

This is the full research model. It tests whether local depth plus broad-market internals add independent signal or merely duplicate what footprint already shows.

### E. Additional Permutations

Test these explicitly:

- Soft L2 scoring versus hard L2 filter.
- TICK as context only versus TICK as veto.
- L2 as confirmation only versus L2 as confirmation plus invalidation.
- Footprint signal first versus L2-assisted timing.
- Strict A+ model versus broader A/B model.
- Follow-through required versus L2-confirmed trigger.
- L2 pre-signal pressure divergence versus post-signal validation.

## Fair Comparison Rules

1. **Same baseline signals:** Enhanced models must be compared on the same time periods, instruments, bar types, and baseline signal IDs.
2. **No lookahead:** Any feature used for signal scoring must be known before or at the signal/confirmation timestamp. Post-signal L2/TICK recovery belongs in outcome or validation fields unless specifically used as a delayed confirmation model.
3. **Separate trigger and outcome:** Do not use MFE/MAE, future TICK recovery, or post-sweep book flip as if known at entry unless the entry is intentionally delayed to that confirmation.
4. **Keep signal frequency visible:** A hard veto can improve win rate by deleting most signals. That is not improvement unless expectancy, drawdown, and frequency remain tradable.
5. **Ablate one change at a time:** Add TICK, then L2, then both. Test role permutations separately.
6. **Do not optimize on one market:** ES, NQ/MNQ, YM, and related instruments may react differently to TICK and depth.
7. **Compare strict and soft variants:** Soft score first. Hard veto only after the soft feature proves monotonic value.

## Model Variant Labels

Use these labels in exports:

- `A_BASELINE`
- `B_BASELINE_TICK_CONTEXT`
- `B_BASELINE_TICK_VETO`
- `C_BASELINE_L2_SOFT`
- `C_BASELINE_L2_CONFIRM`
- `C_BASELINE_L2_VETO`
- `C_BASELINE_L2_TIMING`
- `C_BASELINE_L2_CONFIRM_INVALIDATE`
- `D_FULL_SOFT`
- `D_FULL_HARD_VETO`
- `E_STRICT_A_PLUS`
- `E_BROAD_A_B`

## What Counts As Incremental Value

An enhancement earns its keep only if it improves at least one major metric without destroying the others:

- Higher expectancy.
- Lower MAE.
- Faster follow-through.
- Lower false-positive rate.
- Lower drawdown.
- Better robustness by instrument/session/bar type.
- Similar or acceptable signal frequency.

Win rate alone is not enough.

## Initial Test Order

1. A baseline.
2. A baseline with strict versus soft A+/A/B grades.
3. B TICK as score/context only.
4. B TICK veto.
5. C L2 soft scoring.
6. C L2 confirmation.
7. C L2 veto.
8. C L2 timing refinement.
9. D full soft model.
10. D full hard-veto model.

