# Chunk 071 Extraction
- Source chunk: Chunk_071_Orderflows_Transcripts.md
- Transcripts covered:
  - v217 — How to profit from order flow trading futures Orderflows Trader 3.0 for NinjaTrader 8 (2021-07-31)
  - v219 — Order Flow Interpretation Trade With More Skill And Consistency (2021-08-27)
- Overall content value: mixed — both videos are primarily sales/intro webinars (T2 live-analysis/trade-recap tier but heavy on introductory pedagogy and product pitch); foundational concepts are repeated clearly and some nuances emerge, but little advanced reversal model content. v217 is richer for definitions and tool concepts; v219 is thin and repetitive.

---

## A. Setup types & names he uses

- **Market exhaustion** — "when the last buyer has bought or the last seller has sold"; shown on individual bars via the Orderflows Trader software highlight at the bottom of bars. Applicable both at highs (bearish) and lows (bullish). (v217, [51:44])
- **Absorption** — big negative delta at a level where price cannot push lower; "someone just sat there and absorbed all that selling." Distinguished from mere sideways action: the sign of absorption is visible *right now* in the bar, not only in retrospect. Bullish if negative delta + market does not move down. (v219, [19:22])
- **Market weakness (bearish)** — market has been moving higher but buying delta is weakening bar over bar (e.g., 400 → 300 → 27); aggressive selling eventually takes over. (v217, [54:13])
- **Market weakness (bullish)** — market has been going lower but selling delta is weakening bar over bar (e.g., 58 → 42 → 39); buyers step up and take control. (v217, [56:16])
- **Market sweep** — a trader takes out several price levels in one trade (buy sweep lifts all offers to a level; sell sweep hits all bids down to a level). A sweep detector is a distinct signal from stacked imbalances; sweeps can occur *before* stacked imbalances form on the same move. (v217, [39:10])
- **Order flow sequencing (bullish/bearish)** — waterfall sequencing where resting liquidity is stacked and taken out; subsequently higher offers lifted (bullish) or subsequently lower bids hit (bearish); a tool within Orderflows Trader 3.0. Used to *stay in* a trade and as an exit/reversal signal when sequencing flips. (v217, [44:41])
- **Stacked imbalance** — 3 or more imbalances stacked neatly on top of each other; acts as support (buying stacked) or resistance (selling stacked). (v217, [33:27]; v219, [32:43])
- **Multiple imbalances** — 3 or more imbalances spread throughout a bar (not necessarily adjacent/stacked); fires *earlier* than stacked imbalance on the same directional move; bullish if multiple buying imbalances appear at a low, bearish if multiple selling imbalances appear at a high. (v217, [56:49]; v219, [32:43])
- **Slingshot point of control** — a named sub-type of the POC signal; highlighted by Orderflows Trader 3.0 software in green (bullish) or as a bearish signal. (v219, [40:06])
- **Value area gap** — gaps in intrabar value area as the market trends; overlapping value areas signal sideways/rotational market; breakaway gaps signal trending/directional move. (v217, [1:01:20])
- **Bullish/bearish bar value area** — within a trend, certain value areas are colored by the software as "very bullish" (blue) or "very bearish" (red); more significant than an average bar value area. (v217, [1:02:16])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **"High confidence" trade** — the phrase he uses for setups where multiple order flow signals align at an extreme (e.g., strong positive delta growing + imbalances in the bar + POC migrating higher) at a key level (HOD/LOD). Contrasted with just seeing bullish signs that are insufficient alone. (v217, [22:30])
- **"So obvious" / "can't miss it"** — his top-tier characterization: "you're looking for those special instances where things are so clear so dominant in the order flow right that it just you just can't miss it right it's like so obvious it just appears right before you." The threshold is dominating, not subtle. (v217, [25:33])
- **"Nice trading opportunity"** — used for multiple buying imbalances appearing at the LOD, in context. Not top-tier language but positive. (v217, [58:25])
- **"Very strong sign"** — multiple buying imbalances at the low of the day; his characterization: "that's a very strong sign it's telling you the aggressive buyers are appearing at the low of the day." (v217, [58:25])
- **"Good sign"** — market-generated support coming in *as* the market rallies (supportive buying during uptrend); allows holding positions longer. (v217, [20:43])
- **"Bearish" / "very bearish"** — used for software-highlighted bar value areas and POC configurations; software colors them red. (v217, [1:02:16])
- **"Bullish" / "very bullish"** — software colors bar value area blue. (v217, [1:02:16])
- **"Simple trade"** — a bar with strong aggressive selling where price cannot go lower; the setup is straightforward and the stop is tight just below. (v219, [22:58])
- **"Not necessarily a whole lot of" / "nothing really to get too excited about"** — his language for thin/below-average order flow with no dominant signal; he passes on these. (v219, [29:35])
- **Tier discriminator — context**: "you're coming into a low you're seeing multiple imbalances that's what you expect to see you're at your low but now you're seeing multiple buying imbalances what do you think that's a good sign or a bad sign well that's a very strong sign." Context at the LOD elevates a multiple-imbalance signal from ordinary to high-confidence. (v217, [58:25])
- **Tier discriminator — timing / being "ahead"**: getting in at the *first* sweep (before stacked imbalance forms) is better than waiting for the stacked imbalance. Being long from 28 vs 29-30 on a 10-cent move matters. Earlier signal = higher tier because less drawdown, better R/R. (v217, [44:41]; v219, [33:14])

---

## C. Order-flow story & psychology per setup

- **Absorption story**: Aggressive sellers hit all bids trying to push the market lower; a large passive buyer ("someone absorbing") sits at the level and takes the other side of every sell. Price stalls or reverses. The clue: "strong negative delta the market can't push any lower." Trader identifies the invisible iceberg-buyer by watching what *doesn't* happen (price not going lower despite heavy selling). (v219, [19:22])
- **Sweep story**: A large trader is confident direction will follow, so they sweep multiple price levels at once rather than working bids/offers incrementally. They "are not going to buy the 25s and then see how it reacts and then buy the 50s." The sweep reveals conviction and urgency. A failed sweep (runs into an iceberg bid/offer) is itself a signal — the absorbed sweep shows where big opposing interest lives. (v217, [40:07])
- **Order flow sequencing / trend continuation story**: Big traders working out of a position "finesse" fills by stacking bids/offers at subsequently better prices (e.g., some at 25, more at 24.75, more at 24.5...). When that stacked liquidity gets sequentially absorbed/lifted, it is visible as bullish or bearish sequencing. The visual pattern shows *who is in control bar by bar*. (v217, [45:16])
- **Market weakness / exhaustion story**: "Think of it like a move is a move running out of gas." As market goes higher, if buying delta weakens bar over bar (400 → 300 → 27), there are fewer and fewer aggressive buyers willing to lift offers — "so the market's not going to go any higher." Supply wins by default. The reversal is not driven by aggressive sellers arriving but by aggressive buyers evaporating. (v217, [53:44])
- **Multiple imbalances at an extreme story**: When multiple imbalances appear at/near a HOD or LOD, it signals that aggressive participants are willing to trade against the prior move *right at that extreme*. On a rally: multiple selling imbalances near the HOD = "aggressive sellers are coming in here they think that this is a good area to sell." (v217, [58:56])
- **Stacked imbalance as S/R story**: Big trader comes in, "hits all the bids boom boom boom," market retraces, they reappear and sell more; market continues in the direction of the imbalance. The stacked imbalance level is where they positioned — it acts as support/resistance if price returns. (v217, [34:21])

---

## D. Exhaustion clues

- Low volume at an extreme price in the footprint (e.g., "eight contracts at 38.75" at the low of the bar) — "not a lot of selling interest down here." Light volume at the extreme is the exhaustion print. [REPEATED] (v217, [15:30])
- Delta weakening bar over bar on a directional move — e.g., 400 → 300 → 27 on a rally, or 58 → 42 → 39 on a selloff — "the buying is weakening"; "the selling is just sort of starts tapering off." [REPEATED] (v217, [54:46])
- Market exhaustion highlighted by Orderflows Trader software at the bottom of bars; appears both at tops (bearish) and bottoms (bullish). (v217, [51:44])
- Lower prices being rejected on a rally ("rejection" of lower prices as the market moves up) = bullish sign that selling is exhausted. (v217, [52:46])
- Higher prices being rejected on a down move = bearish sign that buying is exhausted. (v217, [52:46])

---

## E. Absorption clues

- **Strong negative delta + price does not move lower** — the primary absorption signature. "When you see strong negative delta and the market's not moving down that's absorption." [REPEATED] (v219, [19:22])
- **Iceberg order hit by a sweep** — if a buy sweep runs into an iceberg bid, the whole sweep is absorbed at that price and the market stays bid; the price level of absorption is revealed. [ONCE] (v217, [41:30])
- **Supportive buying during a rally** — buying imbalances and support highlighted by software *as* the market is rallying; this is absorption of selling pressure keeping the up-move intact. "That support is going to hold up the market and then keep going up." (v217, [20:43]) [ONCE — framed as trend continuation context, not reversal]
- POC migration as absorption proxy: when POC starts migrating higher bar over bar, "people are accepting higher prices," meaning lower-price selling is being absorbed. (v217, [17:26]) [SPECULATIVE]

---

## F. Stacked imbalance ideas

- Definition confirmed: 3 or more imbalances stacked *neatly* on top of each other (adjacent price levels). Acts as support (buying stacked) or resistance (selling stacked). [REPEATED] (v217, [33:27]; v219, [32:43])
- **Sweep can precede stacked imbalance on the same move** — sweep at 64.00, stacked selling imbalance at 63.85 on the same bar/move; the sweep gives an earlier, better entry. "Where would you rather be short from up in here at 64.00 or short down here at 63.85 after the sweep occurred?" [ONCE] (v217, [44:10])
- **Multiple imbalances fire before stacked imbalances** — "you don't get a stacked imbalance until way up here but you're already alerted to hey you know what there's a lot of selling coming in now" several ticks ahead of the stacked imbalance. (v219, [33:14]) [REPEATED — consistent with prior extractions]
- Standard 4:1 ratio confirmed again. Some use 10:1, 5:1, or 3:1. (v217, [31:28])

---

## G. Delta / delta-divergence ideas

- **Positive delta at a declining low = absorption/reversal** — the green bar with negative delta or the bar with big sell-side volume that cannot push price lower is the key signal. Conversely, "strong negative delta + market can't go lower" → big buyer absorbing. (v219, [18:55])
- **Delta weakening bar over bar as exhaustion** — quantified example: 400 → 300 → 27 is bearish market weakness on a rally; 58 → 42 → 39 is bullish market weakness on a selloff. NEEDS-OPERATIONALIZATION: what count of consecutive weakening bars triggers the signal? (v217, [55:14])
- **Max/min delta within the bar** — he tracks *max delta* and *min delta* displayed below the bar; "strong buying" = max delta reaching near 95% of bar high (digest figure); useful for knowing how strong the buying was at one point inside the bar. (v219, [18:00])
- Delta near zero on a time-based chart: "when it lands on zero is just you know especially if you're using a minute-based chart the bar just closed right it doesn't mean anything in that sense." Near-zero delta is coincidental on time-based charts, not a meaningful neutral signal. [ONCE] (v219, [18:28])
- Negative delta on an up bar (green candle) is meaningful: "it's telling you that there was probably some volume down here to stop this move down." — counterintuitive delta-color divergence is a genuine signal. (v219, [18:55]) [REPEATED — consistent with digest]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Sweep as a distinct signal type**: a buy/sell sweep is explicitly not the same as a stacked imbalance; sweeps reveal conviction and urgency not visible on a standard footprint. A failed sweep (absorbed by an iceberg) is a reversal signal showing hidden large opposing interest. (v217, [39:10])
- **Sweep detector** in Orderflows Trader 3.0 highlights sweep occurrences; standard footprint users would miss this. (v217, [43:19])
- "For a sweep to be effective right and move the market there needs to be a lack of resting liquidity" — if resting liquidity absorbs the sweep, the sweep fails and price holds at the absorption level. [ONCE] (v217, [41:56])

---

## I. Trapped-trader ideas

- People who stacked bids/offers expecting a move that didn't materialize become trapped; "people working offers they pull them as the market starts getting closer." The DOM is not reliable because working orders are pulled as price approaches. [ONCE — not a reversal signal per se, just context for why DOM is unreliable] (v217, [11:43])
- No explicit trapped-trader reversal setups named in this chunk beyond what is in the digest.

---

## J. Entry triggers (the exact "go" event)

- **Multiple imbalances at an extreme (LOD/HOD) in context** — bar with multiple buying imbalances near the LOD is the go-bar for a long. He says: "the bar to be trading it off of is this one right closer to the high of the day" — i.e., the multiple-imbalance bar *closest to the extreme* is the trigger, not a bar that appeared after the market moved away. (v217, [58:56])
- **Bullish sequencing after bearish sequencing at a low** — when sequencing flips from bearish to bullish at an inflection point, that flip is the directional signal. "We hit the low of the day bullish sequencing right as the market starts moving back up." (v217, [49:10])
- **Strong negative delta + price not moving lower** — in a single bar, this is the entry signal for a long: get long, stop just below that bar. "That's a simple trade to take right you just you get long your stop is just right below that." (v219, [22:58])
- **Slingshot POC** — a bullish or bearish POC highlighted green/bearish by software; "right before it takes off you see the bullish [POC]" — the software highlight is the trigger. (v219, [29:35]; v219, [40:06])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Follow-through order flow required**: "in order for a market to move in the direction you expect it to there needs to be follow-through order flow in the direction that you're expecting the market to move." Without it, "the market's not going to move in your direction." [REPEATED] (v219, [24:42])
- **Bullish sequencing continuing** after a long entry = stay in the trade; "there's some bullish sequencing still happening here yeah I could let it run a bit." (v217, [48:08])
- **POC migrating higher** on a long trade = continued acceptance of higher prices = confirmation to stay in. (v217, [17:26])
- **Bearish sequencing flipping on** after a long = exit signal; first bearish sequencing after bullish = time to start cutting. (v217, [48:08])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Sweep absorbed / no follow-through**: if the sweep is absorbed at the same price by an iceberg, the market doesn't move — the directional thesis is wrong. "The sweep is going to be absorbed." (v217, [41:30])
- **Delta strengthens against you**: if you are long and delta continues weakening (approaching zero) rather than reversing upward, the exhaustion thesis is not materializing. (v217, [55:14])
- **Bearish sequencing continues after a bullish trigger**: "uh oh bearish... you should cut out of it already." (v217, [48:34])
- **No follow-through order flow**: market does not produce imbalances / sequencing in your direction after entry = thesis is not validated. (v219, [24:42])

---

## M. Stop / risk / target / trade management

- **Stop just below (or above) the signal bar's extreme**: "your stop is just right below that right so it's not like you know you're taking a fly." The absorption bar or multiple-imbalance bar defines the stop. [REPEATED] (v219, [23:28])
- **Let winners run using real-time order flow**: "if you're in a position how you're going to let it run more if you can't read the market." Specifically: supportive buying imbalances as the market rallies = stay in; bearish sequencing starts = begin reducing. The order flow *replaces* arbitrary take-profit levels. (v217, [21:08])
- **Earlier entry = better risk/reward**: getting in at the first sweep vs waiting for the stacked imbalance = better entry by ~15 ticks (64.00 vs 63.85 example). Similarly multiple imbalances fire ahead of stacked imbalances for better entries. (v217, [44:41]; v219, [33:14])
- No specific target numbers given; targets remain discretionary based on ongoing order flow reading. [REPEATED pattern]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Best entry is at the LOD/HOD**: "the best place to buy with the most profit opportunity is off the low of the day." Being long from 65-70 when the signal fired at 30-40 misses the move. Context = at the extreme, not mid-range. (v217, [24:30])
- **"Trade in context"**: multiple imbalances at the LOD are high-signal; multiple buying imbalances when taking out the HOD are expected (less significant); multiple selling imbalances near the HOD are the signal. Location relative to the day's range determines the tier of the signal. (v217, [58:25])
- **Quiet/event-driven environment**: on days preceding Jackson Hole, "the last couple days S&Ps has been pretty quiet ... you can only trade what the market gives you sometimes the market's going to be quiet sometimes it's going to be bonkers." Reduce expectation on event-anticipation days. (v219, [27:00])
- **Volume requirement for order flow tools**: "order flow looks at volume so if you don't have a lot of volume it's just not going to be very effective right you want stocks that you know trading very tight bid offer." Applies particularly to sequencing tools. Thin markets (Tesla-style) degrade signal quality. (v217, [50:11])
- **Markets confirmed**: e-minis (ES), NQ/Nasdaq, crude oil, soybeans, 6E (euro currency futures), gold, mini Dow (YM), bonds/treasuries, 10yr notes. Sequencing particularly effective in high-volume-at-price markets. (v219, [35:51])
- **Intraday / daytime best**: "the best way to use order flow is right now right trade what's happening right in front of you" — shorter timeframes capture freshest information. 15/30-min charts can work but give up edge. (v219, [30:09])
- **VWAP**: briefly mentioned as an example of a lagging tool; "VWAP taking into account everything that's traded over the last hour or the last week" — his point is order flow is fresher. Not used as a filter per se in these videos. (v217, [01:06])

---

## O. Directly testable / measurable variables

- **Imbalance ratio**: 4:1 (buying: bid volume on offer ≥ 4× bid volume; selling: bid volume ≥ 4× offer volume). Some use 10:1, 5:1, or 3:1. (v217, [31:28]) [REPEATED]
- **Stacked imbalance threshold**: 3 or more imbalances neatly adjacent. (v217, [33:27]) [REPEATED]
- **Multiple imbalance threshold**: 3 or more imbalances spread through the bar (not adjacent). (v217, [56:49]) [REPEATED]
- **Delta weakening — example values**: 400 → 300 → 27 (bearish weakness on rally); 58 → 42 → 39 (bullish weakness on selloff). NEEDS-OPERATIONALIZATION: no stated minimum number of bars or percentage decline to confirm pattern; these are illustrative examples only. (v217, [55:14])
- **Delta near zero on time-based chart**: not a meaningful signal by itself (coincidental bar close). (v219, [18:28])
- **Absorption condition**: strong negative delta + price not making new lows = absorption. NEEDS-OPERATIONALIZATION: "strong" negative delta threshold not defined here. (v219, [19:22])
- **POC migration direction**: migrating lower on a downtrend, lining up flat in consolidation, migrating higher on an uptrend — measurable with simple logic. (v217, [29:53])
- **Value area overlap**: overlapping bar-by-bar value areas = consolidation; gaps in value area = trending. Testable as a regime filter. (v217, [1:01:20])
- **Sweep definition**: price jumps several price levels with no counter-trade; "where price jumps several price levels with no counter trade." NEEDS-OPERATIONALIZATION: "several" not quantified; could be operationalized as a minimum number of price levels skipped with a minimum volume threshold. (v217, [42:50])
- **Sequencing direction flip** — from bullish to bearish (or vice versa) at a swing high/low; this is the exit/reversal signal. Operationalized in Orderflows Trader 3.0 software; not manually quantified in these videos. (v217, [47:42])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Orderflows Trader 3.0** runs on NinjaTrader 8 (free or paid version); 17 pre-programmed order flow tools; volume footprint chart as the base. (v217, [1:05:50])
- **Sweep detector**: a specific function that highlights where sweeps occur in the market. This is a distinct indicator, not derivable from stacked imbalances alone. Implication for NT implementation: identify bars where price jumps multiple levels with concentrated volume and no counter-trade. (v217, [43:19])
- **Order flow sequencing**: highlights bullish/bearish sequencing; appears as colored arrows/labels on bars. Tracks whether subsequent bids or offers are being taken out at increasing quantities. Tracks waterfall liquidity depletion. (v217, [47:14])
- **Market exhaustion indicator**: highlights at the bottom of bars where exhaustion conditions occur; distinct from the imbalance indicator. (v217, [51:44])
- **Market weakness indicator**: orange/blue arrow on bars where delta is weakening on a directional move. (v217, [56:56])
- **Intrabar value area box**: box within each bar showing where 70% of that bar's volume traded; colored blue (very bullish) or red (very bearish) when conditions warrant. Value area gaps between adjacent bars are visually significant. (v217, [1:00:23])
- **Slingshot POC**: a named indicator for highlighting a specific class of POC signal (green = bullish, presumably red/different = bearish). (v219, [40:06])
- **Multiple imbalance box**: software "puts a nice box around it" to highlight bars with 3+ spread imbalances. (v217, [57:22])
- **Default settings** = Mike's own settings, pre-configured for ES 1-minute chart on install; no template needed in version 3.0. (v219, [40:37])
- **Data feed requirement**: real-time data feed required; Sierra Chart users can install NT8 as charting overlay and execute elsewhere. (v217, [1:05:50])

---

## Q. Notable verbatim quotes

1. "It's not about finding every turning point in the market before it happens right it's about reading the market to find the opportunities that are so obvious that the trade is about as close to a sure thing as possible." (v217, [03:30])

2. "You're looking for those special instances where things are so clear so dominant in the order flow right that it just you just can't miss it right it's like so obvious it just appears right before you right it's not about analyzing well 8 traded here against 61 what does that mean... no it's gonna you'll see I'll show you examples you know of things that are just so obvious just stick out so much that you know to not take the trade you'd be you know you'll look back to god that was so obvious." (v217, [25:33])

3. "Where would you rather be short from up in here at 64.00 or short down here at 63.85 after the sweep occurred right you like of course you'd want to be short from 64.00 where the first sweep occurred and that's the real power of order flow." (v217, [44:41])

4. "When you see strong negative delta and the market's not moving down that's absorption." (v219, [19:22])

5. "The best place to buy with the most profit opportunity is off the low of the day so if you have reasons that are valid to be buying off the low of the day it's going to give you a great trading opportunity." (v217, [24:01])

6. "In order for a market to move in the direction you expect it to there needs to be follow-through order flow in the direction that you're expecting the market to move right like I said you know if you don't have that follow-through order flow the market's not going to move in your direction." (v219, [24:42])

7. "You're coming into a low you're seeing multiple imbalances that's what you expect to see you're at your low but now you're seeing multiple buying imbalances what do you think that's a good sign or a bad sign well that's a very strong sign it's telling you the aggressive buyers are appearing at the low of the day." (v217, [58:25])

8. "Delta is kind of neutral so aggressive traders are pretty equal all right again more normal market activity just back and forth." (v217, [37:44]) — defines when *not* to look for a reversal signal.

9. "All the information that matters really can be derived from these three main pieces of information delta appointed control and imbalance." (v219, [16:57])

10. "What you're looking for is what's happening right now and you know really what that means is you're making trading decisions based on the freshest best information available." (v217, [01:06])

---

## R. Contradictions / nuances

- **Sweep ≠ stacked imbalance, and precedes it**: explicitly states "sometimes stacked imbalances overlap sweeps but not always." Sweeps can give an earlier, better-price entry than waiting for stacked imbalances. This is a nuance: the digest captures that stacked imbalances are S/R, but the sweep-first entry is an additional, earlier-firing signal type. (v217, [44:10])
- **Zero delta on a time-based chart is meaningless**: he explicitly states near-zero delta on a minute-based chart is "just you know especially if you're using a minute-based chart the bar just closed right it doesn't mean anything." This nuances the general "neutral delta" concept in the digest — truly neutral (zero) may be coincidental on time-based charts. (v219, [18:28])
- **"Strong negative delta the market's not moving" = ABSORPTION not weakness**: this is subtler than it seems. A naive reading might flag large negative delta as bearish; Mike reads it as "the market can't go lower" = bullish. The *combination* of the delta direction and the price action (not moving in that direction) is what defines absorption. This is repeated in the digest but the exact formulation "strong negative delta + no downward move = absorption" is reinforced here. (v219, [19:22])
- **DOM / order book is unreliable**: "a lot of times people put bids in pull them people work offers they pull them as the market starts getting closer." Working orders in the DOM are not committed; what *traded* is what matters. This is consistent with the digest but explicitly discounts DOM-based analysis. (v217, [11:43])
- **Not all price levels are equal**: "a bar chart leads the trader to believe that all prices are equal when in reality not all prices are equal" — a core principle, not a contradiction but essential nuance for why footprint is needed. (v217, [14:02])
- **Intrabar value area context**: some value areas within the bar are "more bullish or bearish than others" — not all bars with a value area signal are equal; the software grades them by color. NEEDS-OPERATIONALIZATION for what makes a value area "very bullish" vs merely "bullish." (v217, [1:01:45])
- **Fractal / cross-market repeatability**: "their behavior while not exactly 100% repeatable is very fractal in nature right it does repeat itself." He shows the same multiple-imbalance pattern in ES, crude oil, 6E, gold, and soybeans in the same session — implying the signal is instrument-agnostic, consistent with digest. (v219, [37:38])

---

## Coverage note

v217 (2021-07-31) is the richer of the two videos — a 75-minute webinar with extended explanations of sweeps, sequencing, value area, and market weakness with examples; good for reinforcing and adding nuance to existing concepts. v219 (2021-08-27) is a 45-minute webinar that is largely redundant with v217 and the existing digest, focusing on basic footprint concepts and product pitch. Both videos are primarily introductory/sales in nature (T2 tier); they contain conceptual reinforcement and some useful nuance (especially sweep timing vs. stacked imbalance, absorption definition, and zero-delta on time-based charts) but no new advanced reversal setups or specific numerical thresholds beyond those already in the digest.
