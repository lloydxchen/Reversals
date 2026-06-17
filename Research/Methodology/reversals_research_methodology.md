# Reversals Research Methodology

This file is the central research-methodology hub for the Reversals project.

The goal is to keep the core research philosophy, modeling assumptions, open hypotheses, and testing priorities in one durable place so ideas do not get scattered across separate AI threads, chats, notebooks, or one-off experiments.

## Working Purpose

Build reversal models that are honest, testable, and useful in live trading conditions.

The focus is not to find one magical universal reversal signal. The better working assumption is that reversals may come from several different market mechanisms, and those mechanisms may need to be modeled separately.

## Companion Methodology Files

- [`execution_lookahead_guardrail.md`](execution_lookahead_guardrail.md) — reusable post-mortem and checklist for detecting fill/execution lookahead, especially when a strategy mixes close-based confirmation with intrabar/level-based fills.

## Core Research Principles

### 1. Separate longs and shorts

Model long reversals and short reversals separately.

Longs and shorts may not be mirror images of each other. They can have different order-flow behavior, volatility context, trap structure, liquidity dynamics, and follow-through profiles.

Research should therefore track performance separately for:

- Long models
- Short models
- Combined portfolio behavior

A combined result should not hide the fact that one side is working and the other side is weak.

### 2. Use multiple models per direction

Use multiple models for longs and multiple models for shorts.

The working hypothesis is that there are different types of long reversals and different types of short reversals. A single universal model may become mediocre because it tries to predict too many different reversal animals at once.

Possible model families may include, but are not limited to:

- Liquidity sweep reversals
- Absorption-driven reversals
- Delta-flip reversals
- Exhaustion reversals
- Failed-breakout / trap reversals
- Reclaim / rejection reversals

These should be treated as separate hypotheses until the data proves they should be combined.

### 3. Test market-internals confluence

Test whether ES reversal signals improve when filtered or scored with broader market confluence.

Priority confluence inputs to test:

- ES context
- VIX context
- TICK context

Lower-priority confluence input:

- ADD, if reliable data is available

ADD is lower priority for now because data availability and synchronization may be harder, but it may still be useful if clean data can be obtained.

### 4. Avoid universal-model overfitting

Do not assume that the best research target is one all-purpose reversal equation.

A universal model can look elegant but fail practically because it averages together setups with different causes, timing, confirmation requirements, and failure modes.

The research process should allow specialization first, then only combine models later if the combined version is demonstrably better.

### 5. Preserve causality and avoid lookahead

Every feature used in a test must be available at or before the decision point.

Avoid any model logic that accidentally uses future information, completed bars that would not have been complete yet, future session profile levels, or hindsight-selected zones.

If a model only works when it uses information that would not have been available live, treat the edge as invalid.

Execution/fill timing is part of causality. A fill is only valid if both the trigger and the fill price were knowable at or before the moment of the fill. Do not mix the favorable price of one order type with the favorable selectivity of another.

### 6. Compare models by mechanism, not just headline stats

Do not only rank models by win rate or profit factor.

Also evaluate:

- What market behavior the model is trying to capture
- Whether the entry logic makes causal sense
- Whether the edge survives removing suspicious filters
- Whether the model works across enough days and regimes
- Whether the failure cases are understandable
- Whether it is usable in live trading without too much discretion

A model with slightly lower stats but cleaner logic may be better than a model with stronger-looking stats but fragile or suspicious assumptions.

## Current Research Notes

### Immediate hypothesis notes

- Test ES, VIX, and TICK confluence.
- Maybe test ADD if data is available, but keep it lower priority.
- Model longs and shorts separately.
- Use multiple long models and multiple short models.
- Treat reversal setups as different subtypes instead of forcing everything into one universal reversal model.
- Assume different reversal mechanisms may need different confirmations.

### Key working belief

The reversal problem is probably not one problem.

It is likely a family of related problems:

- When does selling exhaustion create a long reversal?
- When does buying exhaustion create a short reversal?
- When does a liquidity sweep actually trap participants instead of continuing?
- When does absorption matter?
- When does delta confirmation help?
- When do broader internals confirm or invalidate the setup?

The research process should identify which mechanism is being tested before optimizing filters.

## Things to Consider / Parking Lot

This section is for ideas that are worth preserving but are not yet proven priorities. These notes should stop good ideas from getting lost without forcing them into the active research plan too early.

### Flow42 indicator data

Consider using Flow42 indicator outputs as possible context variables, but do not assume the full Flow42 visual suite is cleanly available as model-ready data.

Current working interpretation:

- Flow42 may provide useful exposed context features, especially regime, continuation, chop, volume-spike, and pressure-style outputs.
- Some of the most interesting reversal-specific Flow42 concepts appear harder to access cleanly, including staged absorption, VolDynamics-style absorption/exhaustion/push/surge events, and VolImbalance cluster zones.
- Some values may be private, obfuscated, or painted through rendering rather than exposed as clean public series.
- OnRender/private-field scraping should be treated as fragile and lower priority, not as a serious foundation for the research pipeline.
- Flow42 should be treated as a possible context/filter layer, not as a replacement for our own order-flow feature engineering.

Potentially useful exposed Flow42-style context variables to evaluate:

- VolDrive / continuation context
- ChopState / chop-regime context
- VolSpike / volume-spike context
- RelativeDeltaPressure-style pressure normalization
- Any VolImbalance outputs only if they can be made to fire reliably and interpreted cleanly

Potentially useful but not cleanly exposed concepts to reconstruct ourselves from raw footprint/volumetric data:

- Absorption
- Exhaustion
- Failed aggression
- Delta divergence
- Stacked imbalance
- Imbalance-cluster failure/reclaim
- Sweep + reclaim behavior

### Preferred delta versus Flow42/native proxy delta

If Flow42-derived delta values are used, validate them before trusting them.

In prior exported data, the Flow42-native delta behavior looked proxy-like rather than true bid/ask classified delta. For modeling, prefer our own `PreferredDelta_*` / NinjaTrader volumetric bid-ask delta when available, because it is closer to true aggressor-volume delta.

Working rule:

- Use `PreferredDelta_*` / NT volumetric bid-ask fields as the primary delta source when available.
- Treat Flow42-native delta/CVD as diagnostic only unless it passes validation.
- Do not let vendor labels create false confidence. If a column claims to be delta, test whether it behaves like real bid/ask delta.

## Candidate Research Backlog

### Market-internals confluence tests

Test whether reversal models improve when adding:

- VIX rising / falling context
- VIX spike or compression behavior
- TICK extreme and recovery behavior
- TICK divergence versus ES price
- ADD breadth confirmation, if available
- ES trend / range / volatility regime context

### Direction-specific modeling

For every promising setup, report results separately for:

- Longs only
- Shorts only
- RTH only
- ETH only, if relevant
- By time of day
- By volatility regime
- By instrument, if testing beyond ES

### Subtype-model exploration

Potential subtype buckets to test:

- Liquidity sweep + reclaim
- Absorption + delta flip
- Exhaustion + failed continuation
- Prior high / low sweep reversal
- Opening range trap
- VWAP / value-area rejection
- Trend-pullback failure
- News / volatility shock reversal, only if data supports it

These are only hypotheses, not conclusions.

## Potential Pitfalls and Guardrails

### Execution lookahead / fill bias

Watch for strategies that decide using information from the end of a bar but fill at a price that occurred earlier inside that same bar.

Core rule:

> A backtest fill is only valid if everything used to justify it — the trigger and the price — was knowable at or before the moment of the fill.

Invalid pattern:

```text
Wait for a bar to close through a level,
but give the trade a fill back at the level inside that same bar.
```

That combines two incompatible benefits:

- The good price of a resting order.
- The selectivity of a confirmation strategy.

Honest alternatives:

- Resting order model: place the order before price arrives, fill every touch, and do not use a future close filter.
- Confirmation/chase model: wait for confirmation, then fill at the next bar open or another realistically available post-confirmation price.

Reusable stress tests:

- Force entries to the next bar open.
- Re-run using the honest version of the claimed order type.
- Check whether honest fills create more trades than the reported version.
- If the edge collapses or flips sign after the honest-fill test, assume the original edge was not real.

See the companion file [`execution_lookahead_guardrail.md`](execution_lookahead_guardrail.md) for the full post-mortem and checklist.

### Black-box vendor-feature dependence

Do not build the core research pipeline around hidden or poorly understood vendor internals.

Vendor features can be useful, but they should be validated and treated as optional context unless they are:

- Cleanly exposed
- Stable across versions
- Interpretable
- Available historically
- Causal at the decision point
- Measurably helpful after honest testing

If a vendor concept is promising but not cleanly accessible, prefer reconstructing a transparent version from raw OHLCV, footprint, volumetric, and market-internals data.

### Pretty visuals are not model-ready data

A chart visual can be useful to a human trader but still be hard to use in a systematic model.

Before treating a visual indicator concept as a feature, confirm:

- The value exists as a historical series, not only as a rendered object.
- The value is timestamped cleanly.
- The value does not repaint.
- The value is available before the trade decision.
- The value can be exported consistently.
- The value means what the label appears to mean.

## Research Discipline

Keep research honest by separating:

- Hypothesis generation
- Feature construction
- Backtest design
- Model ranking
- Out-of-sample validation
- Live-simulation review

Do not let a good-looking backtest become trusted until the setup is tested for leakage, sample-size weakness, regime dependence, live usability, and honest execution/fill assumptions.

## Status

Living document. Add quick notes here whenever a research idea, modeling rule, or testing principle comes up in another AI thread or trading session.
