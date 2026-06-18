# A+ Reversal Operational Model

This file translates the qualitative model into testable or semi-testable rules. It intentionally avoids fake precision. Thresholds are included only where the source evidence gives a reason or where they are marked as crude approximations for backtesting.

Rating scale:

- Backtest priority: 1 low, 5 highest.
- Implementation difficulty: 1 easy, 5 hard.
- Transcript evidence strength: 1 weak, 5 strong.

## General Data Requirements

- OHLCV bars.
- Bid/ask volume per price level inside each bar.
- Bar delta, cumulative delta, max delta, min delta.
- Footprint edge volume at high/low.
- Point of control and value area where available.
- Stacked buy/sell imbalance detection.
- Session levels: high/low of day, opening price, prior close, VWAP, initial balance, prior swing highs/lows.
- Timing/session metadata: cash open, premarket, lunch, news windows, holiday/slow sessions.

## Setup Rules

| Setup | Measurable variables | Candidate rules | Scoring ideas | Thresholds | Required data | Confirmation | Invalidation | False-positive filters | Weaknesses | Testability | Priority | Difficulty | Evidence |
|---|---|---|---|---|---|---|---|---|---|---:|---:|---:|---:|
| Exhaustion after absorption | Edge volume, swing high/low, distance to session level, delta sequence, prior absorption flag, bar size, next-bar direction | Long: exhaustion print at swing low/LOD/support after selling pressure weakens. Short: exhaustion at swing high/HOD/resistance after buying pressure weakens. | Score level quality + low edge volume + delta weakening + absorption + tight stop + immediate response. | Directly supported: exhaustion volume limit around 10 and swing filter 25 in 2026 ES settings. Should be relaxed in backtesting by market. | OHLCV, footprint volume at price, bid/ask volume, delta, swing/session levels. | Signal bar closes, next bar trades in reversal direction. | Price takes out signal extreme and accepts; no response after several bars. | Avoid right before cash open; avoid large signal bars; avoid mid-range prints. | Can miss trades if volume limit too strict; market-specific. | Directly testable with footprint data. | 5 | 3 | 5 |
| Absorption reversal | Aggressive delta, price progress per delta, passive volume at bid/offer, close location, repeated tests | Long: negative/aggressive selling but price holds/closes green. Short: positive/aggressive buying but price stalls/closes red. | Score effort-vs-result failure, level, repeated defense, opposite close, delta contradiction. | No hard transcript threshold. Use graded z-scores of delta and volume. | Bid/ask volume, delta, OHLC, POC/value, levels. | Price rotates away from absorbed zone. | Price accepts beyond zone; aggressive side expands. | Do not call all high volume absorption. Require poor price progress. | Passive liquidity is inferred unless DOM data exists. | Partially testable. | 5 | 4 | 5 |
| Failed breakout/breakdown | Break of prior high/low/value, time outside level, delta at break, reclaim speed, close location | Fade only after reclaim/failure. Short failed breakout; long failed breakdown. | Score level importance + emotional break + no continuation + reclaim + trapped flow. | Crude approximation: reclaim within 1-3 bars is stronger; relax during testing. | OHLCV, delta, levels, footprint, imbalances. | Close back inside level or next-bar directional move. | Acceptance outside level; retest holds outside. | Exclude trend-day breakouts with initial balance/range extension confirmation. | Needs robust level definitions. | Directly testable. | 4 | 3 | 4 |
| Stop-run/liquidity sweep | Sweep beyond level, volume spike, delta spike, reclaim, wick ratio | Long below-low sweep that reclaims. Short above-high sweep that rejects. | Score sweep distance + volume spike + fast reclaim + low stop distance. | No hard threshold. Use relative volume/delta versus recent bars. | OHLCV, footprint, delta, session/swing levels. | Reclaim of swept level. | Level flips into support/resistance for continuation. | Do not fade true liquidation/news trend. | Stop volume versus initiative volume is ambiguous. | Testable but noisy. | 4 | 3 | 3 |
| Trapped trader reversal | Aggressive delta at poor location, absorption, lack of follow-through, reversal through entry zone | Identify late buyers/sellers trapped at edge; enter after failure. | Score FOMO location + aggression + no continuation + unwind potential. | No hard threshold. Use delta/volume percentile and price progress failure. | Footprint, bid/ask volume, delta, OHLC, levels. | Price moves through trapped zone against late entrants. | Aggressive side continues and accepts. | Distinguish protective stop-outs from true trapped new positions. | Highly interpretive. | Partially subjective. | 4 | 4 | 4 |
| Delta-divergence reversal | Price extreme, bar delta, cumulative delta, max/min delta, delta slope, price progress | Long if lower low has weaker selling delta or positive absorption. Short if higher high has weaker buying delta or negative response. | Score divergence magnitude + level + absorption/exhaustion confluence. | Avoid fixed delta numbers across products. Use normalized delta versus recent distribution. | OHLCV, delta, cumulative delta, footprint. | Reversal candle or level reclaim after divergence. | Delta re-accelerates and price extends. | Avoid countertrend divergence during strong trend day unless level fails. | Many false positives in chop. | Directly testable. | 4 | 3 | 4 |
| Stacked-imbalance failure | Count of stacked imbalances, direction, location, follow-through distance, reclaim | Fade only after stacked imbalance fails. | Score stack size + edge location + no continuation + opposite close. | Candidate: 3+ adjacent imbalances as common definition; evidence supports stacked concept but not universal threshold. Relax in testing. | Footprint bid/ask volume, imbalance detector, OHLC. | Opposite trade through imbalance zone. | Clean continuation in imbalance direction. | Do not fade fresh trend-day stack. | Imbalance thresholds vary by market/platform. | Directly testable if imbalance data exists. | 3 | 3 | 4 |
| Climactic volume reversal | Volume spike, delta spike, location, price extension, close location, next-bar response | Fade climax only after failure at extreme. | Score relative volume + poor continuation + absorption/exhaustion + level. | Use volume percentile, not absolute volume. | OHLCV, footprint, delta, levels. | Post-spike rejection/rotation. | Spike initiates continuation. | Exclude news impulse unless failure is clear. | Large volume can be trend fuel. | Testable but needs filters. | 3 | 3 | 3 |
| Retest-confirmation reversal | Prior level, retest distance, delta on retest, exhaustion/absorption on retest, second-bar response | Trade second failure at prior level. | Score clean first level + cleaner weaker retest + reversal response. | No hard threshold. Use tick tolerance by market. | OHLCV, delta, footprint, swing/session levels. | Bar close plus next-bar directional trade or retest rejection. | Retest accepts through level. | Avoid levels tested too many times. | Subjective level selection. | Partially testable. | 4 | 3 | 4 |
| Failed-continuation reversal | Expected continuation marker, delta follow-through, next-bar range, time stalled, reversal through trigger bar | Fade when strong flow should continue but does not. | Score strength of initial signal + failure speed + level + reversal close. | Directly supported idea: if no move within about 10 minutes on exhaustion, get out. Use as exit/stall rule, not entry threshold. | OHLCV, delta, footprint, imbalances, time. | Reversal through initiating bar/level. | Pullback resumes trend. | Avoid low-liquidity chop where nothing follows through. | Hard to define "should continue." | Partially subjective. | 4 | 4 | 4 |

## Global A+ Score

Use a graded score, not a binary checklist. A candidate reversal becomes A+ when multiple independent categories line up.

Suggested scoring:

- Level/context: 0-25 points.
- Order-flow failure: 0-30 points.
- Confirmation/response: 0-20 points.
- Risk quality: 0-15 points.
- Timing/filter quality: 0-10 points.

Interpretation:

- 80-100: A+ candidate.
- 65-79: tradable but not elite.
- 50-64: research/watch only.
- Below 50: pass.

Do not overfit these point values. They are a crude approximation for research.

## Directly Supported Rules

- Exhaustion print is very light volume at the edge of a bar at a swing high/swing low or high/low of day.
- The trader does not sell/buy every exhaustion print.
- Bar close confirms the exhaustion print.
- Next bar trading in the reversal direction is a practical entry trigger.
- Stop belongs beyond the signal extreme or level.
- Best exhaustion reversals should work quickly.
- If an exhaustion trade sits sideways for around 10 minutes, get out/scratch/small loss/small profit.
- Positive delta can be bearish at resistance if absorbed and no continuation follows.
- Negative delta on a green candle can indicate passive buyers absorbing aggressive sellers.
- Stacked imbalances require context and follow-through.
- Trapped trader reversals may be smaller than people expect.

## Interpretations

- Reclaim of failed breakout/breakdown level is the clean operational trigger.
- Absorption can be approximated by high aggressive delta with poor price progress.
- Trapped traders can be approximated by aggressive flow into an edge followed by reversal through their likely entry zone.
- Climactic volume is only useful when paired with failure, not as a standalone fade.

## Too Strict / Should Be Relaxed During Backtesting

- Fixed exhaustion volume limit of 10 across all markets.
- Fixed 25-bar swing filter across all markets and sessions.
- Mandatory absorption before every exhaustion trade.
- Mandatory next-bar entry only; second-chance entries may matter when order flow remains bearish/bullish after a stop-out.
- Fixed 10-minute stall rule across timeframes. Treat it as a principle: good reversals should not take forever.

