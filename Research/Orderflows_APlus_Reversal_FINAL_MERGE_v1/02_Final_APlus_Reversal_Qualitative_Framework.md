# Final A+ Reversal Qualitative Framework

## One-Sentence Model

A+ reversal = a meaningful edge where aggressive traders fail, that failure is visible in footprint/order-flow, the stop is tight behind the failed edge, and price confirms before the information goes stale.

## Decision Stack

1. **Location:** swing high/low, HOD/LOD, value/POC/VWAP, support/resistance, failed breakout/sweep level, or user-defined level.
2. **Failure mechanism:** exhaustion, absorption, hidden delta flip, delta trap, failed acceptance, imbalance failure, or retest rejection.
3. **Confirmation:** closed-bar signal plus follow-through/reclaim/rejection appropriate to timeframe.
4. **Risk:** stop beyond the failed edge; signal bar not too large.
5. **Freshness:** fast charts should move quickly; slower markets can take longer, but order-flow information decays.

## A+ vs Mediocre vs Bad

### A+

- Clean edge after a real move.
- Aggressive participation into the edge.
- Failure is visible: exhaustion, absorption, hidden delta flip, failed acceptance, or no continuation.
- Signal bar allows a compact stop.
- Follow-through appears within the appropriate chart-speed window.
- No sequencing/flow-driven continuation against the signal.

### Mediocre

- One strong clue but weak location.
- Signal bar too large.
- Delta read depends only on close delta.
- Follow-through late or unclear.
- Setup occurs near cash open/news/lunch without extra confirmation.
- Context is mixed.

### Bad

- Fade every exhaustion print.
- Fade strong continuation without failure.
- Treat high volume as reversal by itself.
- Treat zero delta as a signal.
- Treat delta divergence in chop as A+.
- Weight imbalance position-in-bar.
- Label every large order as trapped traders.

## Setup Families

### 1. Edge Exhaustion

Very light volume at the bar extreme at a clean swing/session/value edge.

- Bullish: low-volume low at support/LOD/swing low.
- Bearish: low-volume high at resistance/HOD/swing high.
- Important correction: exhaustion volume is instrument/timeframe-scaled. Use per-instrument parameter or dynamic low percentile, not global 10.
- Confirmation: bar closes, then next bar/reclaim/rejection confirms according to timeframe.
- Stop: beyond signal extreme.

### 2. Absorption To Exhaustion

The flagship family. Aggressive traders are absorbed first, then exhaustion marks the final failed edge.

- Bullish: sellers hit lows, passive buyers absorb, Min delta gives back or price holds, then exhaustion/rejection appears.
- Bearish: buyers lift highs, passive sellers absorb, Max delta gives back or price rejects, then exhaustion/rejection appears.
- A+ when absorption, exhaustion, level, stop, and follow-through all agree.

### 3. Hidden Delta Flip / Intrabar Give-Back

Close delta alone is not enough. A bar that hit a large intrabar Max/Min delta and closes far back toward zero/opposite can reveal absorption.

- Bullish: large negative MinSeenDelta at low, but close delta recovers strongly.
- Bearish: large positive MaxSeenDelta at high, but close delta gives back strongly.
- Keep give-back percentage soft. Do not hardcode 80-96%.

### 4. Delta Trap / Contextual Delta Failure

Delta sign is not control. It is effort. Effort only matters if price confirms.

- Positive delta at resistance/HOD can be bearish if there is no continuation.
- Negative delta at support/LOD can be bullish if selling is absorbed.
- Positive delta at a new low needs bid/offer disambiguation before calling it bullish.
- Zero/near-zero delta is noise.

### 5. Failed Acceptance / Sweep Reversal

Price breaks or sweeps an obvious level but cannot accept outside it.

- Bullish: break below support/low/value then reclaim.
- Bearish: break above resistance/high/value then reject.
- Enter on reclaim/rejection, not on the first poke.
- Treat as strong only when the level is obvious and failure is fast.

### 6. Imbalance Failure Family

Imbalances show initiative until they fail.

- Multiple imbalances can be equal or superior to stacked and may fire earlier.
- Stacked count is timeframe-sensitive: 3+ generally, 2 on fast charts.
- Low cell-volume stacks are weak.
- Position within bar has no edge; do not score it.
- Opposing imbalance/ratio can invalidate quickly.

### 7. Retest Rejection

The second test of a level is useful when the attacking side is weaker.

- Bullish: retest support/low with weaker selling, exhaustion, absorption, or hidden flip.
- Bearish: retest resistance/high with weaker buying, exhaustion, absorption, or hidden flip.
- Too many tests degrade the level.

### 8. POC / Value Area Family

Useful but not all first-build.

- Abandoned value/POC: high-confidence context when next bar does not retrade the area.
- Back-to-back POC: 2+ consecutive bars share exact POC, creating magnet/support/resistance; trade return after price leaves.
- Volume-in-value/Stratum: orthogonal confirmation, not delta-based, optional later.

### 9. Sequencing / Flow-Driven Continuation

This is not a reversal setup. It is a suppressor.

Escalating volume eaten through successive levels means continuation. Do not fade it just because one reversal clue appears.

## Practical Ranking

1. Edge exhaustion with location.
2. Absorption to exhaustion.
3. Hidden delta flip / intrabar give-back.
4. Delta trap at edge.
5. Failed acceptance/reclaim.
6. Multiple/stacked imbalance failure.
7. Retest rejection.
8. POC/VA family.
9. Volume-in-value.
10. Second-chance re-entry.

