# Reversals Research Methodology

This file is the central research-methodology hub for the Reversals project.

The goal is to keep the core research philosophy, modeling assumptions, open hypotheses, and testing priorities in one durable place so ideas do not get scattered across separate AI threads, chats, notebooks, or one-off experiments.

## Working Purpose

Build reversal models that are honest, testable, and useful in live trading conditions.

The focus is not to find one magical universal reversal signal. The better working assumption is that reversals may come from several different market mechanisms, and those mechanisms may need to be modeled separately.

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

## Research Discipline

Keep research honest by separating:

- Hypothesis generation
- Feature construction
- Backtest design
- Model ranking
- Out-of-sample validation
- Live-simulation review

Do not let a good-looking backtest become trusted until the setup is tested for leakage, sample-size weakness, regime dependence, and live usability.

## Status

Living document. Add quick notes here whenever a research idea, modeling rule, or testing principle comes up in another AI thread or trading session.
