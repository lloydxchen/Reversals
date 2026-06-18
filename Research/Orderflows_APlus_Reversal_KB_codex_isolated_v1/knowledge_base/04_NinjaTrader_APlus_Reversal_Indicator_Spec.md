# NinjaTrader A+ Reversal Indicator Spec

## Purpose

Build a NinjaTrader 8 indicator that detects and scores A+ order-flow reversal candidates from footprint/volumetric behavior. The indicator should not blindly call tops and bottoms. It should highlight reversals at meaningful edges when aggressive participation fails through exhaustion, absorption, divergence, trapped traders, failed imbalances, failed breakouts, or failed continuation.

Primary use: discretionary confirmation and research signal export.

Secondary use: Strategy Analyzer/backtest input after signal fields are exported and rules are hardened.

## Required Data

Required:

- OHLCV bars.
- Bid volume and ask volume per bar.
- Bid/ask volume by price level inside each bar.
- Bar delta.
- Session time and session high/low.
- Instrument tick size.

Strongly preferred:

- Volumetric bars or equivalent footprint data.
- Max delta and min delta per bar.
- Point of control per bar.
- Value area high/low per bar or session/profile.
- Bid/ask imbalance counts and price levels.
- Cumulative delta.
- VWAP.
- Initial balance high/low.

Optional:

- News/session calendar flags.
- DOM/order book depth for better absorption inference.
- Prior day high/low/close.
- User-defined levels.

## Volumetric / Order-Flow Requirements

The indicator needs true historical bid/ask volume at price. If NinjaTrader Volumetric bars are unavailable, most modules must either be disabled or fed by a custom data source.

Minimum viable module set without full footprint:

- Failed breakout/breakdown.
- Retest confirmation.
- Context/session filters.
- Some delta-divergence if bid/ask delta exists.

Full A+ module set requires:

- Edge volume at high/low.
- Volume at each price level.
- Bid/ask imbalance levels.
- Bar delta and cumulative delta.
- POC/value data if context modules are enabled.

## Signal Direction

Bullish signal:

- Price is at or below a meaningful edge.
- Sellers appear aggressive or recently aggressive.
- Order flow shows sellers failing, exhausting, being absorbed, or trapped.
- Signal confirms after bar close and/or next bar trades upward.
- Stop belongs below the signal low or failed edge.

Bearish signal:

- Price is at or above a meaningful edge.
- Buyers appear aggressive or recently aggressive.
- Order flow shows buyers failing, exhausting, being absorbed, or trapped.
- Signal confirms after bar close and/or next bar trades downward.
- Stop belongs above the signal high or failed edge.

## Setup Modules

### 1. Exhaustion Module

Purpose: detect very low volume at the edge of a bar at a swing/session extreme.

Inputs:

- `SwingLookback`: default 25.
- `ExhaustionMaxEdgeVolume`: default 10 for ES research start.
- `UseSessionHighLow`: true.
- `UseSwingFilter`: true.
- `EdgeLevelToleranceTicks`: default 0-1.

Bullish logic:

- Bar low is swing low, low of day, or within tolerance of support.
- Volume at bar low <= `ExhaustionMaxEdgeVolume`.
- Signal bar closes.
- Optional: next bar trades above signal close/high by `ConfirmationTicks`.

Bearish logic:

- Bar high is swing high, high of day, or within tolerance of resistance.
- Volume at bar high <= `ExhaustionMaxEdgeVolume`.
- Signal bar closes.
- Optional: next bar trades below signal close/low by `ConfirmationTicks`.

Notes:

- The 25/10 defaults are directly supported as one ES setting discussion, not universal constants.
- Make thresholds instrument/session configurable.

### 2. Absorption Module

Purpose: infer passive buyers/sellers absorbing aggressive flow.

Inputs:

- `AbsorptionDeltaPercentileLookback`: default 50 bars.
- `MinDeltaPercentileForAggression`: default 75.
- `MaxPriceProgressTicksForAbsorption`: configurable.
- `UseCloseContradiction`: true.

Bullish logic:

- Negative delta or aggressive selling near low/support.
- Price fails to continue lower.
- Close is green/off-low or next bar lifts.
- Optional: heavy bid-side activity near low with poor downside progress.

Bearish logic:

- Positive delta or aggressive buying near high/resistance.
- Price fails to continue higher.
- Close is red/off-high or next bar drops.
- Optional: heavy offer-side/passive selling evidence near high.

Notes:

- This is partly inferential without DOM.
- Score it; do not make it a brittle binary.

### 3. Failed Breakout / Breakdown Module

Purpose: detect breaks of meaningful levels that fail.

Inputs:

- `BreakoutLookback`: default 20 bars.
- `ReclaimWindowBars`: default 1-3.
- `LevelToleranceTicks`: default 2.
- Enable levels: session high/low, swing high/low, value area, VWAP, user levels.

Bullish logic:

- Price breaks below support/low.
- Close reclaims above the level within reclaim window.
- Delta/volume fails to expand lower or shows absorption/exhaustion.

Bearish logic:

- Price breaks above resistance/high.
- Close returns below the level within reclaim window.
- Delta/volume fails to expand higher or shows absorption/exhaustion.

### 4. Stop-Run / Liquidity-Sweep Module

Purpose: detect stop sweeps beyond obvious levels that immediately fail.

Inputs:

- `SweepLookback`: default 20 bars.
- `MinSweepTicks`: default 1-4 by instrument.
- `VolumeSpikePercentile`: default 90.
- `ReclaimWindowBars`: default 1-3.

Bullish logic:

- Bar sweeps below prior low.
- Volume/delta spike appears.
- Price reclaims prior low.

Bearish logic:

- Bar sweeps above prior high.
- Volume/delta spike appears.
- Price rejects below prior high.

Notes:

- This module is noisy. Use only with context and confirmation.

### 5. Trapped Traders Module

Purpose: identify late aggressive participants at poor trade location.

Inputs:

- `LateAggressionDeltaPercentile`: default 80.
- `NoContinuationBars`: default 1-3.
- `TrapZoneMode`: signal bar body, signal bar POC, or high/low zone.

Bullish logic:

- Strong selling at/through low.
- Poor downside continuation.
- Price reverses above likely trapped short zone.

Bearish logic:

- Strong buying at/through high.
- Poor upside continuation.
- Price reverses below likely trapped long zone.

Notes:

- Trapped trader detection is psychological/inferential.
- The trader explicitly warns not every stop order is a true trap.

### 6. Delta Divergence Module

Purpose: detect price/delta disagreement at extremes.

Inputs:

- `DivergenceLookback`: default 20 bars.
- `UseCumulativeDelta`: true.
- `UseBarDelta`: true.
- `MinDivergenceScore`: default soft score threshold, not binary.

Bullish logic:

- Price makes lower low or retests low.
- Delta makes higher low, less negative reading, or selling weakens.
- Confirmation from reversal close, reclaim, exhaustion, or absorption.

Bearish logic:

- Price makes higher high or retests high.
- Delta makes lower high, less positive reading, or buying weakens/flips negative.
- Confirmation from reversal close, reclaim, exhaustion, or absorption.

### 7. Stacked Imbalance Failure Module

Purpose: detect failed initiative imbalance stacks.

Inputs:

- `ImbalanceRatio`: default research setting 3.0 or platform default.
- `StackedImbalanceMinLevels`: default 3.
- `StackFollowThroughBars`: default 1-3.
- `StackReclaimRequired`: true for signal.

Bullish logic:

- Stacked sell imbalance appears into low/support.
- Price does not continue lower.
- Price reclaims stack zone.

Bearish logic:

- Stacked buy imbalance appears into high/resistance.
- Price does not continue higher.
- Price loses stack zone.

Notes:

- Do not fade fresh stacks in strong trend context.
- Ratio/min-level thresholds are configurable research defaults.

### 8. Failed Continuation Module

Purpose: detect when strong order-flow initiative should continue but does not.

Inputs:

- `InitiativeDeltaPercentile`: default 80.
- `ContinuationWindowBars`: default 1-3.
- `MinExpectedFollowThroughTicks`: instrument configurable.
- `NoResponseMinutes`: default 10 for 1-minute exhaustion management research.

Bullish logic:

- Strong selling fails to make more lows.
- Price reclaims trigger bar or level.

Bearish logic:

- Strong buying fails to make more highs.
- Price loses trigger bar or level.

### 9. Retest Confirmation Module

Purpose: detect cleaner second-test reversals at known levels.

Inputs:

- `RetestToleranceTicks`: default 2-4.
- `MaxRetestCount`: default 2-3.
- `RequireWeakerDeltaOnRetest`: true.

Bullish logic:

- Prior low/support is retested.
- Retest has weaker selling, absorption, or exhaustion.
- Price rejects upward.

Bearish logic:

- Prior high/resistance is retested.
- Retest has weaker buying, absorption, or exhaustion.
- Price rejects downward.

## Scoring And Grades

Use one total score from 0 to 100. Avoid pure binary triggers.

Recommended score buckets:

- Level/context: 0-25.
- Order-flow failure: 0-30.
- Confirmation/response: 0-20.
- Risk quality: 0-15.
- Timing/session filter: 0-10.

Grades:

- A+: 80-100.
- A: 70-79.
- B: 60-69.
- C: 50-59.
- Ignore/watch: below 50.

Hard gates:

- No signal if required footprint data is unavailable for enabled module.
- No A+ if no meaningful level/context.
- No A+ if stop distance is unacceptable.
- No A+ if hard invalidation already occurred.

Suggested module weights:

- Exhaustion at level: up to 25.
- Absorption/failure: up to 25.
- Delta weakening/divergence: up to 15.
- Failed breakout/sweep/trap/imbalance failure: up to 20.
- Confirmation: up to 20.
- Risk/timing adjustments: plus/minus 15.

## Confirmation

Supported confirmation modes:

- `OnBarClose`: signal becomes final only after bar close.
- `NextBarTrade`: next bar trades at least `ConfirmationTicks` in signal direction.
- `ReclaimReject`: price reclaims failed breakdown level or rejects failed breakout level.
- `RetestReject`: level retest fails and price rotates away.

Default:

- Calculate on bar close for official signal.
- Intrabar preview allowed but clearly marked as provisional.

## Invalidation

Bullish invalidation:

- Price breaches signal low plus buffer.
- Price accepts below absorbed/swept/retested level.
- Strong fresh selling delta/stacked sell imbalance continues through the level.
- No favorable movement before timeout.

Bearish invalidation:

- Price breaches signal high plus buffer.
- Price accepts above absorbed/swept/retested level.
- Strong fresh buying delta/stacked buy imbalance continues through the level.
- No favorable movement before timeout.

Management rule:

- If reversal does not start quickly, downgrade score and optionally emit `NoResponseExit`.
- For 1-minute exhaustion research, test 5-minute and 10-minute no-response exits.

## Context / Session / Volatility / Volume / Delta Filters

Context filters:

- Range location: top, middle, bottom of recent range.
- Session high/low proximity.
- Prior swing high/low proximity.
- VWAP distance and slope.
- Initial balance breakout/range extension.
- Value area high/low and POC proximity.
- Prior day high/low/close if available.

Session filters:

- Avoid or downscore signals directly before cash open.
- Track premarket, cash open, lunch, afternoon, overnight.
- Downscore slow holiday/lunch conditions unless target expectations are reduced.

Volatility filters:

- Penalize signal bars that are too large relative to recent median/ATR.
- Penalize stops wider than configured max ticks.
- Adjust level tolerance by volatility.

Volume filters:

- Exhaustion uses low edge volume.
- Absorption/climax uses high relative volume with poor price progress.
- Use percentiles over fixed absolute thresholds except where instrument-specific defaults are explicitly tested.

Delta filters:

- Use normalized delta percentiles.
- Detect delta weakening into extremes.
- Detect positive delta failure at highs and negative delta absorption at lows.
- Avoid treating delta sign alone as bullish/bearish.

## Repainting And Intrabar Concerns

Main issue:

- Footprint signals can appear intrabar and disappear or change before the bar closes.

Rules:

- Official signals should be generated on bar close by default.
- Intrabar preview labels must use different visuals and must not be exported as final backtest signals unless explicitly enabled.
- Exhaustion print is confirmed only after the bar closes.
- Bar-close confirmation reduces repainting but enters later.
- Next-bar confirmation further reduces false positives but may worsen reward/risk.

Implementation setting:

- `SignalMode = PreviewIntrabar | ConfirmOnClose | ConfirmNextBar`
- Default: `ConfirmOnClose`.

## Alerts

Alert types:

- `APlusBullishReversal`
- `APlusBearishReversal`
- `ExhaustionAtLow`
- `ExhaustionAtHigh`
- `AbsorptionBullish`
- `AbsorptionBearish`
- `FailedBreakout`
- `FailedBreakdown`
- `TrapBullish`
- `TrapBearish`
- `NoResponseExit`
- `HardInvalidation`

Each alert should include:

- Instrument.
- Time.
- Direction.
- Grade.
- Total score.
- Trigger module(s).
- Entry reference.
- Stop reference.
- Key level.
- Reason string.

## Visuals

Chart markers:

- Bullish arrows below signal bar.
- Bearish arrows above signal bar.
- Different arrow color by grade.
- Hollow/transparent marker for provisional intrabar preview.
- Solid marker for confirmed signal.

Labels:

- `A+ Long 86 Exhaustion+Absorption`
- `A Short 74 Failed BO+Trap`
- Keep labels short.

Zones:

- Signal zone from signal extreme to entry reference.
- Stop zone beyond signal high/low.
- Failed breakout/sweep level line.
- Absorption zone.
- Stacked imbalance failure zone.

Dashboard:

- Current grade.
- Bull score / bear score.
- Active modules.
- Context status: trend, rotation, near HOD/LOD, near VWAP/value.
- Data status: volumetric available, delta available, POC/value available.
- Last invalidation reason.

## CSV / Backtest Fields

Export one row per confirmed signal.

Required fields:

- `timestamp`
- `instrument`
- `bar_index`
- `direction`
- `grade`
- `total_score`
- `level_score`
- `orderflow_failure_score`
- `confirmation_score`
- `risk_score`
- `timing_score`
- `active_modules`
- `setup_type_primary`
- `setup_type_secondary`
- `entry_price_reference`
- `stop_price_reference`
- `stop_distance_ticks`
- `target1_reference`
- `signal_high`
- `signal_low`
- `signal_open`
- `signal_close`
- `signal_volume`
- `signal_delta`
- `max_delta`
- `min_delta`
- `edge_volume_high`
- `edge_volume_low`
- `exhaustion_flag`
- `absorption_score`
- `delta_divergence_score`
- `stacked_imbalance_direction`
- `stacked_imbalance_count`
- `failed_breakout_flag`
- `sweep_flag`
- `trap_score`
- `context_regime`
- `session_phase`
- `minutes_to_cash_open`
- `vwap_distance_ticks`
- `hod_distance_ticks`
- `lod_distance_ticks`
- `mfe_1bar_ticks`
- `mae_1bar_ticks`
- `mfe_3bar_ticks`
- `mae_3bar_ticks`
- `mfe_10min_ticks`
- `mae_10min_ticks`
- `invalidation_reason`

## Settings / Smart Defaults

Core:

- `CalculateMode`: OnBarClose.
- `SwingLookback`: 25.
- `ExhaustionMaxEdgeVolume`: 10.
- `ConfirmationTicks`: 1.
- `LevelToleranceTicks`: 2.
- `RetestToleranceTicks`: 2.
- `StopBufferTicks`: 1.

Scoring:

- `APlusThreshold`: 80.
- `AThreshold`: 70.
- `BThreshold`: 60.
- `CThreshold`: 50.
- `MinLevelScoreForAPlus`: 15.
- `MinOrderFlowFailureScoreForAPlus`: 20.

Absorption/delta:

- `DeltaLookback`: 50.
- `AggressiveDeltaPercentile`: 75.
- `ExtremeDeltaPercentile`: 90.
- `UseDeltaWeakening`: true.
- `UseCumulativeDeltaDivergence`: true.

Imbalances:

- `ImbalanceRatio`: configurable, research default 3.0.
- `StackedImbalanceMinLevels`: 3.
- `RequireStackFailureForReversal`: true.

Timing:

- `AvoidMinutesBeforeCashOpen`: 5.
- `NoResponseBars`: 5 for range/tick charts or configurable.
- `NoResponseMinutes`: 10 for 1-minute chart research.

Risk:

- `MaxSignalBarRangePercentile`: 75.
- `MaxStopDistanceTicks`: instrument-specific.
- `RequireRewardRoomToTarget1`: false initially, then test.

## Risks

- Full footprint/volumetric data may not be available historically in all NinjaTrader contexts.
- Absorption and trapped trader modules are approximations without DOM.
- Fixed thresholds will overfit quickly.
- Delta divergence and large volume signals create false positives without level/context.
- Intrabar preview can repaint.
- Trend days punish countertrend reversal modules.
- Signal quality depends heavily on session and instrument.

## What To Test First

1. H001 exhaustion at swing/session extremes with 25/10 defaults, then sensitivity test by instrument.
2. H002 exhaustion after absorption score versus pure exhaustion.
3. H014 no-response exit at 5 and 10 minutes/bars.
4. H005 positive delta failure at highs and H004 negative delta absorption at lows.
5. H017 confluence score versus single-module entries.
6. H006 failed breakout/breakdown reclaim.
7. Only after those: trapped trader, sweep, stacked imbalance failure, and climactic volume modules.

The first build should be an indicator/export tool, not an auto-trader.

