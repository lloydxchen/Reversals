# Feature Engineering Dictionary

Features are grouped by trading concept. Use graded variables wherever possible. Hard binary flags are useful for screening but too crude for the full model.

## Price Action

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `swing_extreme_25` | Bar is highest high or lowest low over lookback. | Low is meaningful if lowest low. | High is meaningful if highest high. | OHLC | Compare high/low to last N bars; source mentions 25 for ES exhaustion settings. | Binary/graded | Fixed N may overfit; market/timeframe dependent. |
| `session_extreme_touch` | Bar touches high/low of day. | Low-of-day touch can support long reversal. | High-of-day touch can support short reversal. | OHLC/session | High == session high or low == session low within tick tolerance. | Binary | Trend days punish fades. |
| `level_proximity` | Distance to support/resistance/value/VWAP/open. | Near support improves long. | Near resistance improves short. | OHLC, levels | Ticks from close/extreme to nearest level. | Graded | Level selection can be subjective. |
| `reclaim_after_break` | Price breaks level then closes back through it. | Reclaim above breakdown supports long. | Reclaim below breakout supports short. | OHLC, levels | Break outside then close back inside within K bars. | Binary/graded | Must distinguish wick noise from real sweep. |
| `bar_size_relative` | Signal bar size versus recent bars. | Smaller/tighter signal gives cleaner long risk. | Smaller/tighter signal gives cleaner short risk. | OHLC | Range / median range N. | Graded | Very small bars may be noise; very large bars create poor stops. |
| `sideways_stall` | Price does not move after signal. | Long weak if no upward response. | Short weak if no downward response. | OHLC/time | MFE after K bars/minutes below threshold. | Graded | Some retests develop slowly, but trader says best moves happen quickly. |

## Volume

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `edge_volume` | Volume traded at signal bar high/low. | Very low volume at low suggests sellers exhausted. | Very low volume at high suggests buyers exhausted. | Footprint volume by price | Volume at low/high price level. | Graded | Need true bid/ask/price-level data. |
| `exhaustion_volume_flag` | Edge volume below limit. | Low edge volume at support/swing low. | Low edge volume at resistance/swing high. | Footprint | Edge volume <= threshold; source discusses 10 in ES settings. | Binary/graded | Threshold must vary by market/session. |
| `volume_decline_into_extreme` | Participation shrinks into new extreme. | Selling volume declines into lower low. | Buying volume declines into higher high. | Footprint/OHLCV | Sequence of volume at recent lows/highs decreasing. | Graded | Hard to align price-level sequences cleanly. |
| `climactic_volume_at_extreme` | Large volume spike at edge. | Potential sell climax if no downside continuation. | Potential buy climax if no upside continuation. | OHLCV/footprint | Bar volume percentile and location. | Graded | Big volume can initiate trend. |
| `poc_location` | Point of control location in signal bar. | POC near low can show support/absorption if price lifts. | POC near high can show supply/absorption if price drops. | Footprint | POC price relative to bar range. | Graded | POC alone is not signal. |

## Delta

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `bar_delta` | Ask volume minus bid volume. | Negative delta at low can be absorption if price holds. | Positive delta at high can be trap/absorption if price fails. | Bid/ask volume | AskVol - BidVol. | Graded | Delta sign alone misleads. |
| `delta_weakening_into_extreme` | Delta becomes less aggressive into new prices. | Less negative delta into lower lows supports long. | Less positive delta into higher highs supports short. | Delta/OHLC | Compare current delta to previous same-direction push. | Graded | Needs trend context. |
| `delta_price_divergence` | Price makes extreme but delta does not confirm. | Lower low with higher/less negative delta. | Higher high with lower/less positive delta. | OHLC, delta/cum delta | Price extreme difference vs delta extreme difference. | Graded | Many false positives in chop. |
| `delta_flip_after_extreme` | Delta changes sign after edge test. | Negative selling flips positive after low. | Positive buying flips negative after high. | Delta/OHLC | Sign change within K bars. | Binary/graded | Late confirmation may reduce reward/risk. |
| `max_min_delta_close_quality` | Final delta closes near max/min delta. | Strong selling closing near min delta may need failure before long. | Strong buying closing near max delta may need failure before short. | Intrabar delta | Distance final delta to max/min delta. | Graded | Requires intrabar delta fields. |

## Bid/Ask Imbalance

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `buy_imbalance_count` | Number of buy imbalances in bar. | Supports continuation unless it fails at high. | Failed buy imbalance at high supports short. | Footprint bid/ask | Count ask-dominant price levels over ratio. | Graded | Ratio threshold platform-dependent. |
| `sell_imbalance_count` | Number of sell imbalances in bar. | Failed sell imbalance at low supports long. | Supports continuation unless it fails. | Footprint bid/ask | Count bid-dominant price levels over ratio. | Graded | Needs context. |
| `imbalance_at_extreme` | Imbalance appears at/near bar high or low. | Sell imbalance at low that fails can be bullish. | Buy imbalance at high that fails can be bearish. | Footprint | Imbalance price within X ticks of extreme. | Binary/graded | Can be continuation in trend. |
| `inverse_imbalance_absorption` | Imbalance suggests aggression absorbed against candle/result. | Sell imbalance in green/support candle may show absorbed selling. | Buy imbalance in red/resistance candle may show absorbed buying. | Footprint/OHLC | Imbalance direction opposite close/result. | Graded | Noisy without level filter. |

## Stacked Imbalance

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `stacked_imbalance_direction` | Adjacent imbalances show one-sided pressure. | Sell stack failing at low is bullish. | Buy stack failing at high is bearish. | Footprint | 3+ adjacent imbalances, or platform setting. | Binary | Threshold should be configurable. |
| `stack_follow_through` | Price continues after stack. | Lack of downside follow-through after sell stack supports long. | Lack of upside follow-through after buy stack supports short. | OHLC/footprint | MFE in stack direction over K bars. | Graded | Too short K misses delayed continuation. |
| `stack_reclaim` | Price trades back through failed stack zone. | Reclaim above sell stack. | Reclaim below buy stack. | OHLC/footprint | Close through stack price range. | Binary/graded | Needs precise zone boundaries. |

## Exhaustion

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `exhaustion_print` | Very light volume at bar edge. | At swing low/LOD, sellers may be done. | At swing high/HOD, buyers may be done. | Footprint volume by price | Edge volume <= threshold. | Binary/graded | Do not trade every print. |
| `exhaustion_at_level` | Exhaustion aligns with meaningful level. | Strong long candidate at support/low. | Strong short candidate at resistance/high. | Footprint, OHLC, levels | Exhaustion plus level proximity. | Graded | Level quality matters. |
| `exhaustion_after_absorption` | Exhaustion follows absorbed aggression. | Selling absorbed, then low-volume low. | Buying absorbed, then low-volume high. | Footprint, delta, OHLC | Absorption flag within prior K bars plus exhaustion. | Binary/graded | Absorption flag can be subjective. |
| `time_to_response` | Speed after exhaustion signal. | Long should lift quickly. | Short should drop quickly. | OHLC/time | Favorable excursion after K bars/minutes. | Graded | Too strict can discard slow valid moves. |

## Absorption

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `effort_vs_result_failure` | Aggressive volume/delta does not move price. | Aggressive selling fails at low. | Aggressive buying fails at high. | Delta, OHLC, footprint | Abs(delta percentile) high while price progress low. | Graded | Needs normalization. |
| `negative_delta_green_candle` | Candle closes up/green with negative delta. | Passive buyers absorbed sellers. | Usually not bearish unless context says continuation failed. | OHLC, delta | Close > open and delta < 0. | Binary/graded | Can occur in noisy rotations. |
| `positive_delta_red_candle` | Candle closes down/red with positive delta. | Usually not bullish unless context says sellers failed. | Passive sellers absorbed buyers. | OHLC, delta | Close < open and delta > 0. | Binary/graded | Needs location filter. |
| `repeated_passive_defense` | Same price area holds repeated aggression. | Buyers defend bid/support. | Sellers defend offer/resistance. | Footprint/levels | Multiple tests with failed price progress. | Graded | Requires zone tracking. |

## Trapped Trader / Failure

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `late_aggression_at_edge` | Strong market orders appear after extended move. | Late sellers at low may be trapped. | Late buyers at high may be trapped. | Delta/footprint/levels | Delta percentile high near session/swing extreme. | Graded | Could be true initiative. |
| `no_continuation_after_aggression` | Expected follow-through does not happen. | Sellers fail after strong sell flow. | Buyers fail after strong buy flow. | OHLC/delta | Price progress after K bars below threshold. | Graded | Market may pause before continuation. |
| `trap_zone_reversal` | Price moves back through likely trapped entries. | Reversal above trapped shorts. | Reversal below trapped longs. | OHLC/footprint | Close through aggression zone. | Binary/graded | Identifying entries is approximate. |
| `green_delta_trap` | Strong positive delta at high turns bearish. | Not bullish unless absorbed shorts fail. | Buyers absorbed; short setup. | Delta/OHLC/levels | Positive delta percentile + no continuation + rejection. | Graded | Name is specific; logic generalizes. |

## Confirmation

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `signal_bar_closed` | Footprint signal is final. | Long signal confirmed after close. | Short signal confirmed after close. | Bar data | Bar close event. | Binary | Intrabar signals can disappear. |
| `next_bar_directional_trade` | Next bar trades in signal direction. | Next bar lifts after long signal. | Next bar drops after short signal. | OHLC/tick | Next bar high/low exceeds trigger by X ticks. | Binary/graded | Late entries if X too large. |
| `reversal_close` | Bar closes away from extreme. | Close off low supports long. | Close off high supports short. | OHLC | Close location value. | Graded | Some good exhaustion bars close near extreme. |
| `quick_mfe` | Favorable move soon after entry. | Early upward MFE validates long. | Early downward MFE validates short. | OHLC/time | MFE over first K bars/minutes. | Graded | Better as management than entry. |

## Invalidation

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `signal_extreme_breach` | Price breaks signal extreme. | Long invalid below signal low. | Short invalid above signal high. | OHLC/tick | Trade beyond extreme plus buffer. | Binary | One-tick stop-outs happen. |
| `acceptance_beyond_level` | Price holds beyond failed/reversal level. | Invalidates long if below support. | Invalidates short if above resistance. | OHLC/levels | Consecutive closes beyond level. | Graded | Too much delay increases loss. |
| `no_response_timeout` | Trade does not move soon enough. | Exit/scratch weak long. | Exit/scratch weak short. | Time/OHLC | No meaningful MFE after minutes/bars. | Graded | Time threshold market-dependent. |
| `opposite_initiative_flow` | Fresh strong flow against trade. | Strong selling after long is bad. | Strong buying after short is bad. | Delta/imbalance | Delta/imbalance expansion against position. | Graded | Can be absorbed; check price result. |

## Context / Session

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `trend_day_filter` | Market shows trend-day structure. | Countertrend longs lower quality unless at strong low failure. | Countertrend shorts lower quality unless high failure. | OHLC, IB, VWAP | Initial balance break/range extension/VWAP slope. | Graded | Overfiltering can miss reversals. |
| `rotational_day_filter` | Market is range/rotation. | Reversal setups at range lows improve. | Reversal setups at range highs improve. | OHLC/levels | Range containment, VWAP mean reversion. | Graded | Rotation can become trend. |
| `cash_open_proximity` | Trade occurs near cash open. | Avoid directly before cash open. | Avoid directly before cash open. | Time/session | Minutes to open. | Binary/graded | Some open trades are valid but volatile. |
| `slow_market_flag` | Holiday/lunch/low volatility. | Need smaller expectations. | Need smaller expectations. | Time, volume, range | Volume/range percentile low. | Graded | Low volume can create false exhaustion. |
| `news_window_flag` | Major economic/news period. | Require stronger confirmation. | Require stronger confirmation. | Calendar/time | Manual or scheduled event window. | Binary | Source mentions news contexts but no calendar rules. |

## Risk / Stop

| Feature | Meaning | Bullish interpretation | Bearish interpretation | Required data | Possible calculation | Type | Pitfalls |
|---|---|---|---|---|---|---|---|
| `stop_distance_ticks` | Distance from entry to invalidation. | Smaller stop at low improves R. | Smaller stop at high improves R. | Entry, OHLC | Abs(entry - stop) / tick size. | Graded | Too tight gets clipped. |
| `structural_stop_quality` | Stop hides beyond real level. | Below absorbed/exhaustion low. | Above absorbed/exhaustion high. | OHLC/levels | Stop beyond signal extreme/level. | Graded | Needs buffer by volatility. |
| `early_scratch_rule` | Exit if no response. | Prevents long decay. | Prevents short decay. | OHLC/time | Exit if no MFE after K bars/minutes. | Rule | Can scratch before delayed winner. |
| `reward_to_first_target` | Distance to likely first exit. | Need room to prior POC/VWAP/high. | Need room to prior POC/VWAP/low. | OHLC/levels | Target distance / stop distance. | Graded | Targets not fully specified in evidence. |

