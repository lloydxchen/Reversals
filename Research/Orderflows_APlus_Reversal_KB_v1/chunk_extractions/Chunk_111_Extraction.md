# Chunk 111 Extraction
- Source chunk: Chunk_111_Orderflows_Transcripts.md
- Transcripts covered:
  - v432 — The Orderflows Toolbox (2024-08-15)
  - v433 — Orderflows Trader On GoCharting - Order flow analysis tools and strategies (2024-08-19)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Exhaustion print** (bullish/bearish): volume of 9 or lower at the edge of a bar; bullish if green/up candle, bearish if red/down candle. Mentioned as one of his "favorite" tools. (v432, [29:25]; v433, [21:27])
- **Imbalance reversal**: selling imbalances appearing inside green candles, or buying imbalances inside red candles — signals something "not normal" in the order flow, demand/supply coming in against the trend. (v432, [05:27]; v433, [24:21])
- **Order flow critical ratios**: ratio ≥30 = price exhaustion; ratio ≤0.69 = price defense. Prints on bottom of bullish bars, top of bearish bars. (v432, [33:48]; v433, [29:22])
- **Slingshot point of control** (bullish/bearish): two consecutive bars where the second bar's point of control is lower (bullish) despite the market going up — heavy volume on pull-back, people buying the dip. Signals a continuation move. (v433, [32:40])
- **Prominent point of control (PPC)** (bullish/bearish): POC that signals near-term direction; line drawn out from the bar. Mike describes it as "one of my favorite tools." [REPEATED] (v432, [09:17]; v433, [44:52])
- **Market weakness**: delta-based tool; identifies when aggressive buying or aggressive selling is weakening, signaling likely reversal. Bullish or bearish version. (v433, [35:50])
- **Sequencing** (bullish/bearish): subsequent bars show progressively higher volume clearing bids (bearish) or offers (bullish); called an "order flow sequence." (v433, [38:19])
- **Market sweep** (bullish/bearish): large order clears all bids (bearish) or offers (bullish); draws a zone over several bars; used as support/resistance. Threshold default 25, stack count default 3. (v433, [40:14])
- **Zero prints** (bullish/bearish): zero volume at the first or second price level of a bar — "bad structure," aggressive buying/selling with no counter trade. More visible on lower-volume markets (euro currency, not E-minis). (v433, [47:05])
- **Inverse imbalance** (bullish/bearish): buying imbalances anywhere in a red candle, or selling imbalances anywhere in a green candle. Similar to imbalance reversal but not location-dependent — can appear anywhere in the bar. (v433, [49:07])
- **Multiple imbalances**: 3+ imbalances spread out (not necessarily stacked) in a bar. [REPEATED] (v432, [41:26]; v433, [51:46])
- **Stacked imbalances**: 3+ imbalances stacked on top of each other, same as prior definition. [REPEATED] (v432, [47:28]; v433, [51:46])
- **Buying tails / Selling tails**: poor structure — market snaps sharply lower then instantly recovers (buying tail) or vice versa; box drawn around the bar; looked for at swing highs and swing lows as reversal indicators. Better visible on Nasdaq/YM than E-minis due to E-mini volume distribution. (v433, [54:39])
- **Thin prints**: volume below a certain threshold at a price level in a bar (default 5 on GoCharting); sign of momentum, market moving fast with little two-way flow. [REPEATED] (v432, [05:27]; v433, [57:41])
- **Delta percentage / delta threshold**: delta as percentage of bar volume; defaults 95/5/25; cyan color = strong delta closing near max delta (≥95%); magenta = strong negative delta. (v433, [15:56])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"One of my favorite tools"** — used for: prominent point of control (v433, [44:52]), exhaustion prints (v433, [20:54]), thin prints (v433, [57:41]). These are his highest-tier tools.
- **"Great signals"** — a bar combining thin print + 2 buying imbalances + inverse volume imbalance; described as giving "great signals" (v432, [05:27]).
- **"Nice reversal"** — exhaustion print at a swing high, immediately followed by a move down (v433, [22:29]).
- **"Very powerful signal"** — exhaustion print coming in at a swing high (v432, [1:20:51]).
- **"Not a great example"** / "kind of went nowhere" — stacked imbalances that fire away from a swing high or low, or mid-move, are downgraded; stacked imbalances at a swing are better (v432, [48:41]).
- **"Bad trades"** — signals that fire without momentum filter (swing filter + momentum work "opposite each other"; combining reversal tools with momentum filter removes bad trades) (v432, [08:14]; [49:11]).
- **"Doesn't occur that much"** — adding too many conditions simultaneously produces very few signals; described as a liability not a quality enhancer (v432, [44:29]; [43:51]).
- **Combination tiering**: a single bar combining exhaustion print + imbalance reversal + delta threshold (≥95%) + thin prints = one high-quality entry signal; called out specifically as a meaningful confluence event (v432, [1:13:32]).
- **Location discriminator verbatim**: "You got the swing low…got the multiple buying imbalances coming in here. Got a nice little trade to the upside." Multiple imbalances at a swing low = better quality than same imbalances mid-move. (v433, [54:39])
- **Earlier entry = better tier**: multiple imbalances fire 2 bars and ~5 points earlier than stacked imbalances at the same low — described as minimizing risk and preferred. (v433, [53:33])

---

## C. Order-flow story & psychology per setup

- **Imbalance reversal psychology**: on an up-trending bar, a selling imbalance signals "somebody bidding the market up, absorbing all the selling" — demand absorbing supply, not capitulation. This is what holds the market higher. (v433, [27:41])
- **Sweep psychology**: institutions clear out resting liquidity simply because "it's in the way" — not targeting stops specifically. Retail traders are "ants." A sweep followed by other confluence means information is flowing into the market from traders with informational edge. (v433, [41:47]; [43:47])
- **Slingshot POC psychology**: pullback inside an up move with heavier volume and lower POC = buyers stepping in on dips; "people buying the dip." (v433, [34:14])
- **Thin print psychology**: market moving fast, one side dominating, little two-way auction = momentum continuation signal. (v433, [58:21])
- **Delta percentage psychology**: market has come down on aggressive selling; aggressive buying now coming in, closing near max delta = demand absorbing supply; signals potential reversal or at minimum a pause. (v433, [18:50])
- **Zero print psychology**: market ticks lower, aggressive buying with no counter trade = instant snap-back; "like a sweep" but very brief. (v433, [56:03])
- **Tail psychology**: tail at a swing low = market sold off quickly then snapped back; not gradual absorption but an aggressive bid. (v433, [56:03])

---

## D. Exhaustion clues

- Exhaustion print (vol ≤9 default) at edge of bar at a swing high/low is primary exhaustion clue. [REPEATED] (v432, [29:25]; v433, [21:27])
- Market strength: a move from swing low to swing high of ~10 points on ES (described as "one rotation"); exhaustion prints then appear at the top, signaling potential reversal. (v433, [22:29])
- Rotation context: Mike notes ES rotations are now ~6–8 points (up from ~3–4 points "two or three years ago"); this scaling affects where exhaustion prints are expected. [ONCE] (v433, [22:29]) NEEDS-OPERATIONALIZATION
- Exhaustion print on the way up during a trend = continuation; exhaustion print at a swing high = potential reversal. Location determines interpretation. (v433, [21:55])
- Delta percentage closing at/near 95% of max delta = "strong" delta; when this occurs at a low after a sell-off, signals buyers absorbing sellers. (v433, [18:50])

---

## E. Absorption clues

- **Selling imbalances inside green candles** (imbalance reversal): demand absorbing supply to keep market elevated — "strong bid absorbing all the selling." (v433, [27:41])
- **Buying imbalances inside red candles** (inverse imbalance, imbalance reversal): supply absorbing buying to cap price.
- **Sweep at support**: big buyer comes in and clears out bids; if the sweep zone holds (price does not trade back through), absorption confirmed. "I like to use these as support and resistance levels because I know there was a big buyer at this level. And to me, it's important to see if it holds." (v433, [43:14])
- **Delta closing near max delta** (≥95%): aggressive buying closing near its intrabar high — signal that buyers are "in control" of the bar. (v433, [18:50])

---

## F. Stacked imbalance ideas

- Stacked imbalances = 3+ imbalances stacked on top of each other; definition consistent with digest. [REPEATED] (v433, [51:46])
- **Key nuance on location**: stacked imbalances mid-move "kind of went nowhere"; stacked imbalances at a swing low or swing high are higher quality. (v432, [48:41])
- **Multiple imbalances vs stacked**: multiple imbalances (3+ spread out, not necessarily stacked) fire earlier — 2 bars sooner and ~5 points closer to the low in the live example shown. Earlier = less risk. (v433, [53:03])
- Stacked imbalances are a default on GoCharting; available via "support resistance" layer. (v433, [51:46])

---

## G. Delta / delta-divergence ideas

- **Delta percentage threshold**: 95/5/25 defaults; cyan = strong positive delta closing near max; magenta = strong negative delta. (v433, [15:56])
- **Market weakness tool**: analyzes delta to identify when aggressive buying or selling is "getting weak" — divergence signal for reversal. Bearish market weakness = uptrend losing delta momentum; bullish = downtrend losing delta momentum. (v433, [35:50])
- **Delta at lows**: strong positive delta (cyan) coming in at a swing low = aggressive buying absorbing; when combined with other tools "that's a sign of strength." [REPEATED] (v433, [17:50]; [18:22])
- **Delta surge on up bar after sell-off**: "It's 684. It's magenta color. And the reason what makes it so strong is because it's closing near our max delta of 694. It's closing within 95%." This threshold (95%) is stated explicitly as the criterion for "strong." (v433, [18:50])
- Extreme delta threshold tool: adjustable; default threshold discussed at 80 (liberal) in Toolbox demo. (v432, [50:18])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Market sweep as information signal**: large orders clearing resting liquidity may precede a directional move because institutions acting on information they don't have. "Sometimes when you see a big burst of activity in the market, often times it's preceded by a sweep." Not all sweeps produce immediate follow-through (some go sideways first). (v433, [43:47])
- **DOM is not reliable for S/R** (reiterated): bids and offers on the DOM represent "intent" not committed trades; they can be pulled. Footprint (actual traded volume) is more reliable. (v433, [11:10])
- Nothing specifically on failed breakouts or stop-runs as setup types in this chunk beyond sweep discussion.

---

## I. Trapped-trader ideas

- Not explicitly discussed in this chunk beyond the general sweep/psychology section. No new trapped-trader setup mechanics.

---

## J. Entry triggers (the exact "go" event)

- **Trade entry signal** (Toolbox/automated): market must move "two ticks over two bars" (next 1–2 bars break signal-bar extreme by 2 ticks). Applies on minute-based / faster charts; NOT used on longer time frames (5-minute and above) — disabled there. [REPEATED] (v432, [31:28]; [34:27])
- **Signal bar confirmation**: signal fires on the bar that has the qualifying combination; entry signal waits for follow-through of 2 ticks over 2 bars. (v432, [31:28])
- **Multiple imbalance trigger at swing**: entry as close to the low as possible rather than waiting for stacked imbalance ~5 points higher. (v433, [53:33])
- **Combination bar trigger**: single bar with exhaustion print + imbalance reversal + delta ≥95% threshold + thin prints = one combined signal. (v432, [1:13:32])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- "Two ticks over two bars" = minimum follow-through for Toolbox trade entry signal; if not met, no signal is given. (v432, [31:28])
- Market should immediately begin moving in the expected direction: "Market doesn't go any lower. And it goes inside and pokes back up." (v433, [21:55])
- Strong positive delta continuing in the next bar: "The next bar it's a nice big green bar. And it's got a nice strong positive delta 764. It's also cyan color." — sign of strength confirming the reversal. (v433, [19:49])
- Exhaustion prints continuing on the way up during a trend = confirmation of continuation. (v433, [21:55])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Signal not confirmed if market only moves 1 tick over 2 bars (fails the 2-tick/2-bar follow-through test). (v432, [31:28])
- Using reversal tools without swing filter = "bad trades" because signals fire mid-move (not at swing highs/lows). (v432, [08:14])
- Combining too many conditions simultaneously reduces signal frequency to near zero — the combination itself becomes the invalidation risk (over-filtering). (v432, [43:21])
- Momentum filter and swing filter work "opposite each other" — applying both simultaneously invalidates signals. (v432, [10:32])
- Sweep zone that does NOT hold (price re-enters) would invalidate the sweep as support/resistance. (v433, [43:14]) [SPECULATIVE — implied]

---

## M. Stop / risk / target / trade management

- **Stop placement**: "If you were to buy as close to the low as possible rather than another five points away, that's just an extra five points of risk." — risk is minimized by entering as close to the extreme as possible. (v433, [54:10])
- **Stop below the swing low** implied: "what is your stop going to be? Well, it's going to be probably just below the low." (v433, [54:10])
- **Targets**: "it depends on you as a trader…you can test it to find what you're comfortable with…every trader trades different." No specific target rule given. (v432, [23:14])
- **Time frame for order flow**: "order flow is best used as fresh as possible"; 15 minutes is about as far out as he would go; 1-minute preferred for order flow signals. 4-hour or longer = not recommended. (v433, [1:17:25]; [1:18:41])
- Nothing materially new on stop size beyond "just below the low" and minimize risk by entering near extreme.

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Instrument breadth**: mentions ~40 tradeable markets; encourages traders to find the market that suits them rather than defaulting to ES/NQ. Grains offer "great trading opportunities." Ultra bonds move a lot. (v432, [59:34]; [1:00:39])
- **E-mini tick aggregation**: NQ has large intrabar price ranges; some traders aggregate 4 ticks into 1 for footprint readability. (v433, [08:27]) NEEDS-OPERATIONALIZATION
- **Time frame preference**: 1-minute chart preferred for order flow; 5-minute also used but trade entry signal disabled there; 15-minute about as far out as he'd use order flow; 1-hour/4-hour used only for specific tools (thin prints, prominent POC); 4-hour+ not recommended. (v433, [1:17:25]; [1:18:41])
- **Swing high/swing low filter**: reversal tools should be filtered to swing highs/lows; momentum tools used when market is moving. These two filters should NOT be combined. (v432, [07:44]; [10:32])
- **Order flow is "best used as fresh as possible"**: the shorter the time frame the more useful the signal. (v433, [39:59])
- **Crypto**: use critical ratios, multiple imbalance, inverse imbalance, prominent POC; thin prints need volume threshold adjustment; time frames 15-minute or 30-minute for crypto swing points. (v433, [1:06:57])
- **Aggregating ticks on GoCharting**: for NQ-style instruments, set tick size to 4 ticks aggregated to manage footprint readability. (v433, [08:27])

---

## O. Directly testable / measurable variables

- Exhaustion print threshold: ≤9 (default); adjustable per instrument. (v433, [21:27])
- Critical ratio thresholds: ≥30 = price exhaustion; ≤0.69 = price defense. (v433, [30:34])
- Delta percentage threshold: 95% of max/min delta = "strong"; 25% delta/volume = "strong" (instrument-scaled). (v433, [15:56])
- Trade entry signal: price must move 2 ticks beyond signal-bar extreme within 2 bars. Applied on minute charts; disabled on 5-minute and above. (v432, [31:28])
- Market sweep thresholds: default 25 volume threshold, stack count 3. Adjustable — for NQ, lower threshold may be needed. (v433, [40:14]) NEEDS-OPERATIONALIZATION (what is appropriate NQ threshold)
- Multiple imbalances: ≥3 spread through bar (non-stacked). Fires earlier than stacked imbalances — demonstrated ~2 bars / ~5 points earlier at a low in ES 1-minute. (v433, [53:03])
- Stacked imbalances: ≥3 stacked on each other. [REPEATED]
- Thin print threshold: ≤5 (GoCharting default). Adjustable. (v433, [57:41])
- Swing filter: 25 default (mentioned briefly). (v432, [29:25])
- ES rotation size: currently ~6–8 points (was ~3–4 points 2–3 years ago). NEEDS-OPERATIONALIZATION (exact current figure varies). (v433, [22:29])
- Order flow effective time range: 1-minute to ~15-minute; 4-hour+ not recommended. (v433, [1:18:41])
- Combination signal quality: thin print + imbalance reversal + delta ≥95% + exhaustion print in one bar = high-quality entry bar. (v432, [1:13:32])
- Multi-time frame overlay: toolbox can display signals from a higher TF (e.g. 5-min) on a lower TF chart (e.g. 1-min or range chart). (v432, [12:08])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Orderflows Toolbox** (NinjaTrader 8 add-on, separate from Orderflows Trader):
  - Combines multiple order-flow signals into a single plot on any chart type (candlestick, range, etc.) without requiring the footprint to be visible.
  - Configurable combinations: exhaustion prints, momentum strength, ratios, sequencing, imbalance reversals, balance reloads, sweeps, weakness, thin prints, delta tails, divergence, breakouts, stacked imbalances, multiple imbalances, inverse imbalances, prominent POC, POC waves, slingshot POC, delta tails, buying/selling tails, zero prints, open POC, resting liquidity, max delta thresholds. (v432, [09:17])
  - Two primary filters: **swing filter** (for reversal setups — swing high/low context) and **momentum** (for continuation setups). These are mutually exclusive — cannot be combined. (v432, [10:32])
  - **Trade entry signal**: automated 2-tick / 2-bar follow-through gate built in; enabled by default; should be disabled on longer TF (5-min+). (v432, [31:28])
  - **Multi-time frame capability**: overlay signals from a different chart type/time frame (tick, volume, range, second, minute) onto your current chart. Not available in Order Flows Trader 7. (v432, [12:08]; [1:08:05])
  - **Momentum filter**: also not in OFT7; exclusive to Toolbox. (v432, [1:08:05])
  - Multiple instances can run simultaneously on the same chart with different color assignments (blue/red defaults; change to avoid conflicts). (v432, [19:03])
  - Requires tick replay (reads footprint data in background even on candlestick chart). (v432, [25:15])
  - Compatible with third-party footprint data providers (NinjaCators, NinjaTrader volumetric); NinjaTrader native volumetric uses up/down tick (different from bid/ask); Orderflows uses actual bid/ask data. (v432, [1:03:57])
  - Can automate / produce machine-readable plot signals for use with automated trading tools (Markers). (v432, [17:48]; [1:18:26])
  - Recommended build approach: start with one simple signal, add filters progressively, do "eye test" on historical bars including overnight session. (v432, [47:28]; [50:59])

- **Orderflows Trader on GoCharting** (web-based, monthly subscription):
  - Tools available: exhaustion prints, imbalance thresholds, ratios, slingshot POC, market weakness, sequencing, market sweeps, prominent POC, zero prints, inverse imbalance, multiple imbalance, buying/selling tails, thin prints. (v433, [14:12])
  - Bar statistics panel (separate add-on "bar statistics"): volume, delta, max delta, min delta, delta percentage. Color coding: cyan = strong positive delta; magenta = strong negative delta. (v433, [15:24])
  - Default imbalances and value area built into GoCharting cluster chart (not exclusive to OFT). (v433, [23:42])
  - Tick manager: auto mode (default for crypto); manual 1-tick for futures; 4-tick aggregation for NQ-style wide-range instruments. (v433, [07:13])
  - Multi-time frame signals not yet available on GoCharting footprint. (v432, [1:08:05])

---

## Q. Notable verbatim quotes

1. "There are certain parts of order flow that are great for identifying reversals. There's other parts of order flow that are great for identifying momentum." (v432, [04:02]) — Establishes the reversal vs momentum tool distinction.

2. "If you have a swing filter, right? You're looking for a swing high or swing low for a reversal…if you're trying to find something that's got momentum behind it, well, it's just not going to work cuz they work opposite each other." (v432, [10:32]) — Defines mutual exclusivity of reversal and momentum filters.

3. "Two ticks over two bars…that's basically the trade entry signal." (v432, [31:28]) — States the follow-through gate numerically.

4. "Stacked imbalances where the market's moving is probably something I want to start focusing on…that's how you start adding in the layers." (v432, [49:11]) — Confirms location discrimination for stacked imbalances.

5. "Multiple buying imbalances coming in the second bar off the low. Your stack buying imbalance doesn't come in till another two bars later. And another five points higher. So where would you rather get in? Closer to the low." (v433, [53:33]) — Explicit statement that multiple imbalances provide earlier, lower-risk entry than stacked imbalances.

6. "It's closing within 95%. So I know market's come down on strong aggressive selling. Now it's you got to be thinking, okay, are we going to keep going down, or maybe are we going to go sideways or reverse." (v433, [18:50]) — States 95% threshold as criterion for "strong" delta closing.

7. "Order flow is best used as fresh as possible…15 minutes is about as long out as I would go." (v433, [1:18:03]) — Defines effective time-frame range for order flow signals.

8. "It's a ratio, so you're just going off of, you know, really what the ratio is, not the intensity of it. Okay, so 432 or 911 is much better than 52. No." (v433, [31:56]) — Explicitly states that ratio magnitude above the threshold does NOT grade signal quality; binary (above/below threshold), not continuous.

9. "I see a bearish prominent point of control come in. Yeah, I'm probably going to want to be short." — context: at HOD, can't get higher, bearish PPC fires. (v433, [46:07]) — Describes HOD + bearish PPC as reversal entry trigger.

10. "Sometimes when you see a big burst of activity in the market, often times it's preceded by a sweep…could be somebody got a piece of information that is bullish or bearish." (v433, [43:47]) — Institutional information-flow rationale for sweep setups.

---

## R. Contradictions / nuances (anything that conflicts with common belief, with his other statements, or that is conditional/"it depends")

- **Ratio magnitude does NOT matter**: once a ratio exceeds the threshold (≥30 or ≤0.69), the size of the ratio is irrelevant — 432 is not better than 52. This directly contradicts the intuition that "bigger ratio = stronger signal." [ONCE] (v433, [31:56])
- **Multiple imbalances > stacked imbalances for entry timing**: multiple imbalances (spread out, non-stacked) fire earlier and closer to the extreme, making them *preferable for entry* despite being "less tidy" than stacked. This refines/nuances the digest's relative ranking. (v433, [53:03])
- **Swing filter and momentum filter are mutually exclusive**: explicitly stated — they "work opposite each other." Cannot be combined in a single indicator instance. (v432, [10:32])
- **Trade entry signal is time-frame conditional**: the 2-tick/2-bar follow-through test is only used on minute-based or faster charts; on 5-minute charts and above it is disabled. The digest notes "works immediately ≈ within 1–3 bars" but this chunk adds the explicit time-frame conditional for disabling. (v432, [34:27])
- **Order flow not suitable for swing trading (weeks/months)**: explicitly stated "in my opinion, no." Effective range is intraday to ~15-minute chart. (v433, [1:19:13])
- **Adding too many conditions is counterproductive**: the more conditions required simultaneously, the fewer signals — and this is not a quality improvement. "If you were to add all these things, right? For sure, I'm not going to get anything." Too much confluence ≠ A+. This nuances the digest's emphasis on confluence ("single signals lie"). (v432, [43:21])
- **E-mini exhaustion print threshold context**: on GoCharting, default is 9; Mike uses it as-is. The chunk confirms 9 as the standard for rates/indices (consistent with digest). (v433, [21:27])
- **Thin print ≠ reversal signal by itself**: thin prints are primarily a momentum indicator; using them without momentum context (e.g., with a reversal/swing filter only) produces "bad trades." They need to be in the momentum context OR confirm a reversal in combination with other signals. (v432, [08:14])
- **Order flow is participant behavior, not curve-fitting**: Mike distinguishes order flow indicators (which track actual buying/selling behavior) from price-action/MA-based systems that "curve fit." He argues order flow signals persist because they reflect human market behavior. (v432, [56:25]; [57:31])

---

## Coverage note

v432 ("The Orderflows Toolbox") is a live product-launch webinar; it contains useful implementation and filter-design content (swing vs momentum filter mutual exclusivity, trade entry signal 2-tick/2-bar, multi-TF capability) but limited new model rules. v433 ("Orderflows Trader on GoCharting") is a platform tutorial; richer in concrete tool definitions (delta %, sweeps, slingshot POC, zero prints, tails) and contains the important explicit statement that ratio magnitude above threshold does not matter. Neither video is primarily a trading methodology video; both are T3 (product/platform). Model extraction value is mixed — a few genuinely clarifying items, primarily on ratio grading, multiple vs stacked imbalance entry timing, and trade-entry-signal TF conditional.
