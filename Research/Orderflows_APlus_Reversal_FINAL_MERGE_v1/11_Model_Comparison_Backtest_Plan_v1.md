# Model Comparison Backtest Plan v1

## Objective

Measure whether TICK/index internals and CME Level 2 depth add predictive value to the final transcript-derived A+ reversal model.

Baseline must remain intact and separately reported.

## Model Comparisons

### 1. Baseline vs Baseline + TICK

Compare:

- `A_BASELINE`
- `B_BASELINE_TICK_CONTEXT`
- `B_BASELINE_TICK_VETO`

Questions:

- Does TICK improve expectancy as a soft score?
- Does TICK reduce false positives as a veto?
- Does TICK recovery after sweep justify delayed confirmation?
- Does TICK help more on ES/NQ/YM than non-index futures?

### 2. Baseline vs Baseline + L2

Compare:

- `A_BASELINE`
- `C_BASELINE_L2_SOFT`
- `C_BASELINE_L2_CONFIRM`
- `C_BASELINE_L2_VETO`
- `C_BASELINE_L2_TIMING`
- `C_BASELINE_L2_CONFIRM_INVALIDATE`

Questions:

- Does depth imbalance improve absorption/exhaustion signals?
- Does replenishment after aggressive trades predict reversals?
- Does book flip after sweep improve failed acceptance trades?
- Does L2 timing reduce MAE enough to justify delayed/more complex entries?
- Are hard L2 vetoes better than soft score penalties?

### 3. Baseline vs Full Model

Compare:

- `A_BASELINE`
- `D_FULL_SOFT`
- `D_FULL_HARD_VETO`

Questions:

- Do TICK and L2 add independent lift or duplicate each other?
- Does the full model become too selective?
- Does the full model reduce drawdown without killing signal frequency?

### 4. Strict vs Soft Filters

Compare:

- Soft score boosts.
- Hard vetoes.
- Grade caps.
- Delayed confirmation.

Principle:

Soft first. Hard filters only survive if they improve expectancy, drawdown, and false positives without unacceptable frequency loss.

### 5. Trigger vs Confirmation vs Veto

For each enhancement, test separately:

- As score boost.
- As confirmation.
- As veto.
- As timing trigger.
- As invalidation.

Do not mix roles in the first pass.

### 6. A+ Only vs Broader Graded Signals

Compare:

- `E_STRICT_A_PLUS`
- `E_BROAD_A_B`

Metrics must include both expectancy and total opportunity. A+ can have higher win rate but lower total usable edge if too rare.

## Required Metrics

### Core Trade Metrics

- Win rate.
- Average win.
- Average loss.
- Expectancy per trade.
- Profit factor.
- Median R.
- Average R.
- Net points/ticks.
- Commission/slippage-adjusted expectancy.

### Signal Quality Metrics

- Signal frequency.
- False positive rate.
- Time-to-follow-through.
- Failure speed.
- Bars to trigger.
- Bars to invalidation.
- Percentage invalidated by no response.
- Percentage invalidated by stop.
- Percentage invalidated by acceptance through edge.

### Excursion Metrics

- MFE at 1/3/5 bars.
- MAE at 1/3/5 bars.
- MFE/MAE at freshness timeout.
- MFE before MAE ordering.
- MAE reduction from L2 timing.

### Risk Metrics

- Max drawdown.
- Average drawdown after signal.
- Consecutive losers.
- Tail loss.
- Stop distance distribution.
- Signal bar range distribution.

### Robustness Metrics

Break out results by:

- Instrument: ES, MES, NQ, MNQ, YM, RTY, CL, GC, etc. where data exists.
- Session: premarket, open, morning, lunch, afternoon, overnight.
- Bar type: minute, tick, range, volumetric.
- Volatility regime.
- Trend/rotation/flow-driven regime.
- TICK regime.
- L2 liquidity regime.

## No-Lookahead Enforcement

Rules:

1. Signal-time features can only use data at or before `timestamp_signal`.
2. Confirmation features can only use data at or before `timestamp_confirmed`.
3. Delayed-confirmation entries must use delayed entry prices.
4. MFE/MAE and future TICK/L2 recovery are outcome fields unless the entry is explicitly delayed.
5. Every row must include `feature_timestamp_policy`.
6. Every enhanced model must include `entry_delay_ms` and `entry_delay_bars`.

## Test Design

### Phase 1: Baseline Sanity

Run:

- F01 edge exhaustion.
- F01 + F03 hidden delta flip.
- F01 + F02 absorption-to-exhaustion.
- F04/F17 follow-through/freshness variants.

Goal:

Know baseline expectancy before adding external data.

### Phase 2: TICK Additions

Run:

- TICK context as score boost.
- TICK divergence as score boost.
- TICK recovery as delayed confirmation.
- TICK hard veto.

Goal:

Find whether TICK is a context enhancer or a real gate.

### Phase 3: L2 Additions

Run:

- Depth imbalance as score boost.
- Passive replenishment as confirmation.
- Book flip after sweep as confirmation.
- Liquidity pull as veto.
- L2-assisted timing.
- Spread/churn as risk penalty.

Goal:

Find whether L2 improves timing, validation, or invalidation.

### Phase 4: Full Model

Run:

- Full soft model.
- Full hard-veto model.
- Strict A+.
- Broader A/B.

Goal:

Find the best production candidate by expectancy, drawdown, and robustness.

## Acceptance Criteria

An enhancement is useful if it shows at least one of:

- Higher expectancy with similar frequency.
- Similar expectancy with lower drawdown.
- Lower MAE without worse MFE.
- Faster follow-through.
- Lower false-positive rate without deleting too many trades.
- Robust improvement across at least two instruments or sessions.

Reject or downgrade if:

- It only improves win rate by killing frequency.
- It works only on one instrument/session.
- It relies on delayed confirmation but reports baseline entry price.
- It increases drawdown or tail losses.
- It is too sensitive to one threshold.

## Reporting Tables

For each model variant report:

- Signals.
- Trades taken.
- Win rate.
- Expectancy.
- Profit factor.
- Avg MFE.
- Avg MAE.
- Median time-to-follow-through.
- False positive rate.
- Max drawdown.
- Avg entry delay.
- Frequency per session.
- Best/worst instruments.

## Blunt Initial Hypothesis

L2 is most likely to help absorption and timing. TICK is most likely to help context and veto. Neither should be allowed to override a bad baseline location. The full model should be better only if it reduces false positives without starving the strategy.

