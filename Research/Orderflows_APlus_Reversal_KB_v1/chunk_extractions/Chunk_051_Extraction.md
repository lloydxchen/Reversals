# Chunk 051 Extraction
- Source chunk: Chunk_051_Orderflows_Transcripts.md
- Transcripts covered:
  - v171 — How To Improve Your Trading With Order Flow Webinar With Investor Expo December 19 2019 (2019-12-20)
  - v174 — Orderflows Strategies That Will Improve Your Trading Webinar With Investor Expos (2020-02-28)
  - v175 — Orderflows Indicator 3 Pack For NinjaTrader 8 Order Flow Analysis Futures Trading (2020-03-01)
- Overall content value: mixed

---

## A. Setup types & names he uses

1. **Delta divergence (ratio + divergence)** — new or equal high/low with negative/positive Delta respectively; bearish ratio appears as a blue number above the bar. Described as "a ratio and divergence… the trade I'm always looking for because it's what got me hooked on order flow many many years ago when I discovered it." [REPEATED] (v174, [05:01]; v171, [25:31])

2. **Prominent/Primary Point of Control (POC)** — a POC that is highlighted (blue/cyan = support, magenta = resistance) by the indicator as a significant S/R node; the market returns to it and reacts. Distinct from plain POC. [REPEATED] (v174, [35:23]; v174, [37:34])

3. **Migrating Points of Control** — three consecutive bars each with a higher (bullish) or lower (bearish) POC than the previous bar, signaling a trend in motion or a new trend starting out of consolidation. Used both for entry and for trend continuation confirmation. [REPEATED] (v174, [30:21]; v174, [33:55])

4. **Buying/Selling imbalances at a turning point** — stacked or multiple imbalances in bars at a price extreme confirming aggressive side is stepping in. Bullish: buying imbalances (blue) at lows; bearish: selling imbalances (red) at highs. [REPEATED] (v171, [15:39]; v174, [17:47])

5. **Aligned Points of Control (multi-bar POC resistance level)** — three or more bars where the POC lands at the same price; creates a market-generated support/resistance zone, not arbitrary. Price trading below such a zone = resistance confirmed. [ONCE] (v171, [22:56]; v171, [27:55])

6. **Ratio and Divergence (Market Flow Trader)** — ratio/divergence used not only at HOD/LOD but also intraday at swing highs/lows. Can fire a signal even without a footprint chart via a standalone NT8 indicator. [REPEATED] (v175, [05:01])

7. **AV Indicator reversal signal** — compares value area in a bar to prior bars; identifies where value is being rejected; appears on bar (or bar after); can provide a visual "zone" used as a stop buffer. Works on a plain bar chart (no footprint required). Bearish/bullish. [ONCE] (v175, [00:27])

8. **Tension Indicator signal** — analyzes bid-side vs offer-side order flow within each bar to find bars where one side finally wins control; can signal both reversals and momentum. Highlighted as a dedicated NT8 indicator. [ONCE] (v175, [08:38])

9. **Double top / second test short** — noted as "maybe a little easier for people" because the prior test already showed rejection; still requires order-flow confirmation. (bullish mirror implied.) [ONCE] (v171, [25:05])

10. **ThinPrint / gap retest** — a thin print (gap) in a large green candle on a 30-min chart = future retest target; market often fills or nears the gap and potentially continues. Cited on NQ 30-min. [ONCE] (v171, [36:22])

---

## B. Tiering / grading language ← HIGH PRIORITY

1. **"High confidence trade"** — used when three confirming signals align simultaneously: migrating POCs (lower) + selling imbalances + negative Delta getting stronger. Verbatim: "This is gonna give me a very high confidence trade right." (v174, [31:16]) [ONCE]

2. **"Very high confidence" vs "kind of mixed"** — when Delta alone is mixed but POC structure is clearly migrating/prominent, he uses the POC as primary and acknowledges the mixed Delta openly: "the deltas which you know are kind of mixed honestly I'm not going to say that oh yeah these are very bullish… but by looking at the point of controls I know there's support." (v174, [39:30]) [ONCE]

3. **"Great trading opportunities"** — used for prominent POC acting as support/resistance plus migrating POC combination. (v174, [39:00]) [ONCE]

4. **"Low risk high opportunity trades"** — applied to setups using the building blocks together (Delta + imbalances + POC migration). (v174, [42:10]) [ONCE]

5. **"Nice trade" / "decent trade"** — applied to Fibonacci retracement shorts and Head & Shoulders, explicitly contrasted with the earlier (better) order-flow entry: "where would you rather be short from… well you're gonna want to be short from as high a level as possible." (v174, [22:47]) — implies order-flow-first entry > TA-confirmation entry in terms of tier. [ONCE]

6. **Imbalance count within a bar as a quality signal** — one bar with 6 buying imbalances, another with 3, described as "telling me hey there's more to this move." Higher imbalance count = higher quality. (v174, [33:32]) [ONCE]

---

## C. Order-flow story & psychology per setup

1. **Institutional sellers sell INTO a rally before the high is made.** Retail buyers are still bullish; institutions already know the overvalued level. "Institutional traders don't wait for the high to be made and then start selling… they're already there… they start selling as the market is making that high — that's why you see all the negative Delta going up into the high." (v174, [25:26]) [REPEATED]

2. **Commitment vs intention.** The core reason to prefer footprint (traded volume) over DOM (order book): "one shows commitment one shows intention — in my opinion commitment is much more important than intention." (v171, [12:17]) [REPEATED]

3. **Value migration drives trend.** Successive bars with higher POC = market discovering new value to the upside; bearish when POC migrates lower. "Three bullish pointed controls" off a low = demand is being re-established at successively higher levels. (v171, [19:28]) [REPEATED]

4. **Supply absorption at pivot.** When aggressive buyers step in but price does NOT go higher, then aggressive selling resumes → the buyers were absorbed, sellers win: "I see that ok aggressive buyers are stepping up but the market's not going higher then all of a sudden I see aggressive selling coming in… that overrides what I just thought literally five minutes ago." (v171, [27:30]) [ONCE]

5. **Thin prints (gaps) as unfilled auction zones.** Market profile logic applied: a gap in a large candle = unfilled auction; market searches for that value and retests it. (v171, [36:51]) [ONCE]

---

## D. Exhaustion clues

1. **Negative Delta getting stronger (increasingly negative) as price makes a new high** — signals growing aggressive selling pressure at the top; cited multiple times across both v171 and v174. Bearish divergence pattern. [REPEATED] (v171, [21:50]; v174, [14:45])

2. **Delta positive getting stronger into a high, then suddenly aggressive selling resumes** — the brief Delta flip to positive near a high, followed immediately by resumption of negative Delta, is a false bullish signal that confirms exhaustion/absorption of buyers. (v171, [27:00]) [ONCE]

3. **Max Delta / Min Delta intrabar swing** — the spread between max (most positive Delta reached intrabar) and min (most negative) can be enormous, e.g., +3,276 max to −2,466 min (a swing of ~5,742 in one bar). This internal reversal is an exhaustion signal visible only in footprint software. "That's very important information." (v171, [44:43]) [ONCE]

4. **POC going bearish (software colors it) at or near the high** — bearish prominent POC forming in real time as the bar trades = immediate exhaustion / resistance signal. (v171, [35:21]; v174, [37:34]) [ONCE]

---

## E. Absorption clues

1. **Heavy volume at a specific price level on both bid and offer sides** — crude oil example: 685 bid / 784 ask at level 88, total bar ~3,200; returning to that level and seeing 600 contracts again = seller defending = absorption of buyers. "I know this level is being defended." (v171, [31:27]) [ONCE]

2. **Aggressive buyers stepping in but price fails to advance** — buyers absorbed by large passive sellers; followed by selling imbalances and lower POCs. (v171, [27:30]) [ONCE]

---

## F. Stacked imbalance ideas

1. **Multiple buying imbalances in a single bar = bullish momentum signal** — 3 buying imbalances in one bar and 2 in the next (five-minute NQ) described as confirming the rally. The count of imbalances within a bar is relevant to signal strength. (v171, [19:59]) [ONCE]

2. **Selling imbalances persisting across bars at a high** — "a flurry of aggressive sellers coming in" at a high confirms the reversal. (v171, [15:39]) [REPEATED]

3. **Grain markets** — noted as "great markets for trading with order flow" and produce clear multiple imbalances; heavy volume at price means imbalances are meaningful. Buying imbalances at LOD in wheat alongside positive Delta and migrating POCs = buy signal on 5-min. (v174, [41:02]) [ONCE]

---

## G. Delta / delta-divergence ideas

1. **Negative Delta getting stronger at price high (bars 1–9 at HOD)** — persisting negative Delta for an hour (9 bars on 5-min) at the high of day means "aggressive selling is weighing on the market." Count of consecutive negative-Delta bars is meaningful. (v171, [21:50]) [REPEATED]

2. **Three consecutive positive Delta bars strung together** = decisive shift from choppy to demand-driven; a market that produces only 1-2 positive then 1-2 negative Delta bars repeatedly is churning; once you get 5-of-6 positive Delta = trend beginning. (v174, [19:47]) [ONCE]

3. **Delta as a speedometer analogy** — "in your car you have a speedometer tells you how fast you're accelerating or slowing down — [Delta] tells you how the market is moving up or moving down." (v171, [17:13]) [ONCE] — pedagogical framing, not a new rule, but useful for NT grade logic.

4. **Min/Max Delta intrabar** — Max Delta = highest point of positive Delta reached intrabar; Min Delta = lowest (most negative) point intrabar. Key diagnostic: if Max Delta is very high but final Delta is near Min (deeply negative), the bar experienced a massive internal reversal — a powerful exhaustion/absorption signal. (v171, [44:12]) [ONCE]

5. **Ratio + divergence: described as the "trade I'm always looking for"** — single most favored pattern. Mike's software was stated to be the first to display ratio numbers on footprint charts; other vendors copied without understanding application. (v175, [05:29]) [REPEATED]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

1. **Market makes new high by "about a point" then goes sideways** — not a failed breakout proper, but signals exhaustion: even though price edged to a new high, the lack of follow-through plus negative Delta re-emerging is the tell. (v171, [26:33]) [ONCE]

2. **Fibonacci / Head & Shoulders levels as inferior entry points** — contrasted with order-flow entry: selling at 50% retracement or H&S neckline break is legitimate but gives a lower entry than catching the actual high via order flow. Order flow = get short 30–50 cents higher than TA entry. Implies the TA trigger is essentially a late-entry / confirmation trap. (v174, [22:47]) [ONCE]

---

## I. Trapped-trader ideas

1. **Retail buyers still bullish as institutions sell into the rally** — retail buyers at the high are effectively trapped long; the institutional selling is what causes the eventual reversal, trapping latecomers. (v174, [25:57]) [ONCE]

2. **Buyers absorbed and then reversed** — the buyers who stepped up on positive Delta (96 → 192 → 397) were immediately absorbed; market went sideways then sold off hard. Those buyers are trapped. (v171, [27:00]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

1. **Bar close with aligned confirming signals** — for sells: red bar(s) + negative Delta getting stronger + lower POC in each bar + selling imbalances. For buys: green bars + positive Delta increasing + higher POC in each bar + buying imbalances. Entry on the bar after confirmation. (v171, [33:26]) [REPEATED]

2. **Three migrating POCs as entry catalyst** — after seeing 3 bars with consecutively higher (or lower) POCs, the "go" condition is met; works with or without imbalances but is strongest when all three building blocks align. (v174, [30:49]; v174, [33:55]) [REPEATED]

3. **Prominent bearish POC forms on current bar** — as the bar is trading, if the prominent (bearish) POC highlights in real time: "I'm ready that you know if this market if this bar closes… I'm looking to get short right away." (v174, [38:01]) [ONCE]

4. **AV Indicator signal** — signal fires on the bar (or the bar after); optional trade entry triangle sub-signal also available (can be separated from the zone signal). Used as stop placement zone. (v175, [00:54]; v175, [03:21]) [ONCE]

5. **Market Flow Trader (ratio/divergence indicator)** — generates trade entry arrows on a plain bar chart based on ratio + divergence logic; functions both at HOD/LOD and intraday swings. (v175, [05:01]) [ONCE]

6. **Tension Indicator signal** — fires when one side finally wins control of the contested bars; both reversal and momentum mode. (v175, [08:38]) [ONCE]

7. **Re-test of a defended price level** — after identifying a level where heavy volume defended a price (e.g., crude 88), when the market returns to that level: "If it starts rallying okay that possibly is gonna become my support area but I know that we're coming up from down below we're trading up into it so it's my resistance area." Wait for market to stall/turn at the level, then enter in direction of original defense. (v171, [31:55]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

1. **Immediate price movement in the direction of trade** — "you want to have price movement in the direction of your trade right if you're buying… you want to have a green candle." (v171, [33:26]) [REPEATED]

2. **Continued positive Delta** (for longs) or continued negative Delta (for shorts) in the bars following entry. (v171, [33:54]) [REPEATED]

3. **POC migrating in direction of trade** — subsequent bars showing higher POCs (long) or lower POCs (short) after entry. (v171, [19:28]) [REPEATED]

4. **Imbalances appearing in direction of trade** in post-entry bars. (v171, [19:59]) [REPEATED]

5. **Three-signal confluence** — if all three building blocks (Delta + POC + imbalances) continue to align post-entry, the move is likely to persist. (v171, [19:59]) [REPEATED]

---

## L. Invalidation — what should NOT happen / what kills the thesis

1. **Two red (lower POC) bars appear while long** — he notes: "on a multiple position contract I might take some off here or here" when he gets two bars with lower POC; does NOT immediately exit but uses it as a partial exit signal. However, "there's no third bar" = no invalidation, keep the trade. Two lower-POC bars in a row = warning; three = invalidation of the bullish POC case. (v174, [33:55]) [ONCE]

2. **Failure to advance despite aggressive buying** — if buyers step in (positive Delta surging) but price doesn't move higher, this is the absorption signal that inverts the thesis. "The market doesn't go anywhere selling reappears." (v171, [27:30]) [ONCE]

3. **Prominent POC breaks as support** — if the market trades through the prominent support POC and stays below it: "if this support breaks down you know you got to get out of the trade." (v174, [39:58]) [ONCE]

---

## M. Stop / risk / target / trade management

1. **AV Indicator zone used as stop buffer** — the zone printed by the AV indicator is used as stop placement, not just signal. "They'll take the trade on the up triangle or down triangle and they'll use this little zone here this little buffer as their stop placement." (v175, [03:21]) [ONCE]

2. **Order flow monitoring while in trade** — after entry, continue watching order flow: "if I start seeing things in the order flow that aren't conducive to my position then I'm going to cut it — however if I see things in the order flow that look supportive of my position then I'll stay in it longer." (v175, [07:27]) [REPEATED]

3. **Partial exits at POC warning signs** — two consecutive bars with lower POC while long = take partial profit. (v174, [33:55]) [ONCE]

4. **Stopping a loss if defended level breaks** — "if this support breaks down you know you got to get out of the trade" (v174, [39:58]); stop is tied to the structural level (prominent POC), not an arbitrary tick count. [ONCE]

5. **Scaling via micros** — recommended for multi-contract scaling in/out, particularly for retest entries near a gap or ThinPrint zone on a 30-min chart; "it's easier to scale contracts and to catch the move back up." (v171, [37:16]) [ONCE]

6. **Risk/reward framing** — crude example: risking "10–15 ticks max for a potential 100-point move down." Emphasis on using market-generated levels to define risk rather than arbitrary stops. (v171, [24:39]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

1. **Preferred timeframes** — "longest I look at order flow is five minutes… tend to stick to range-based charts and a 1-minute chart; in markets like Nasdaq I go down to a 30-second chart." 30-minute is noted as the outer limit, used for longer-term context. (v171, [20:54]) [ONCE] — NEEDS-OPERATIONALIZATION (30-sec mention for NQ is new vs digest)

2. **Grain markets explicitly endorsed** — wheat and other grains are "great markets for trading with order flow because they're really supply-and-demand-driven." (v174, [41:02]) [ONCE]

3. **10-year Treasury notes (10yr)** — highlighted as a uniquely slow/liquid market: "100 contracts, only need to make 1–2 ticks a day and then they're done." Migrating POCs work well but imbalances are harder to get due to heavy volume. (v174, [34:25]) [ONCE]

4. **Avoid stocks with low volume / penny stocks** — order flow needs actively traded, high-volume securities to be meaningful; large-cap stocks like Apple work; Forex works only via CME futures (decentralized spot FX data is unreliable). (v171, [41:33]; v171, [42:34]) [REPEATED]

5. **Afternoon / 2 pm volume caveat** — "granted this is 2:00 in the afternoon where volumes aren't usually that great" — even 600 contracts at a single level is considered meaningful in that context. Volume interpretation is time-of-day-dependent. (v171, [32:30]) [ONCE]

6. **High volatility / coronavirus week** — explicitly noted that the 3-pack indicators were tested during an extreme volatility week (Feb 23–28, 2020); performance held but required wider stops; "they had to expand their stops." (v175, [12:57]) [ONCE]

7. **HOD / LOD as primary entry locations for ratio+divergence** — "the way I teach people to use them is at the highs and lows of the day but you could also use them intraday in swings." (v175, [05:01]) [REPEATED]

---

## O. Directly testable / measurable variables

1. **Imbalance ratio = 4:1** (industry standard; alternatives: 2:1, 10:1; Mike's default = 4:1) (v171, [15:11]) [REPEATED]

2. **Migrating POC rule: exactly 3 consecutive bars** with each bar's POC higher (bullish) or lower (bearish) than the previous bar = trend signal. Verbatim: "three green candles up with higher each with a higher point control than the previous one for a buy; for a cell it's three red down candles each with a lower point of control." (v174, [34:19]) [REPEATED] — Operationally clean threshold.

3. **Delta direction alignment: 5-of-6 consecutive positive Delta bars** = strong trend start signal vs. alternating 1–2 bar bursts = chop/no trade. (v174, [19:47]) [NEEDS-OPERATIONALIZATION — "most of them" = 5/6 is inferred from transcript context, not a stated threshold]

4. **Max Delta / Min Delta intrabar** — measurable: if final Delta is near Min Delta AND Max Delta was strongly positive (in a bar at a high), this is a bearish exhaustion signal. No stated numeric threshold beyond the illustrative example (Max +3,276; Min −2,466; final +246). (v171, [44:43]) [NEEDS-OPERATIONALIZATION]

5. **Aligned POC: 3+ bars with POC at same price level** = market-generated S/R level. (v171, [22:56]; v171, [27:55]) [ONCE — exact count of "3" from v171 [22:56]]

6. **Prominent/Primary POC** — flagged by indicator algorithm (not manually drawn); acts as support (blue/cyan) or resistance (magenta); market reacts at that level. Specific formula not disclosed; behavior: forms in real time, does not repaint after bar closes. (v174, [35:55]; v174, [38:01]) [REPEATED] NEEDS-OPERATIONALIZATION (formula undisclosed)

7. **Volume at a price level as "heavy volume"** — in crude oil (2 pm): 685 on bid + 784 on offer at a single tick = notable (v171, [31:27]); 600 contracts at a level in thin afternoon = still noteworthy. NEEDS-OPERATIONALIZATION (market- and time-of-day-dependent)

8. **Two lower-POC bars = partial exit; three lower-POC bars = trend potentially reversing** (v174, [33:55]) — directional rule for trade management. NEEDS-OPERATIONALIZATION (stated qualitatively; "third bar" as invalidation implied not explicit)

9. **AV Indicator "zone" = stop buffer zone** — visual zone printed by indicator on bar close; no numeric width given. (v175, [03:21]) NEEDS-OPERATIONALIZATION

10. **Tension Indicator** — bid-side vs offer-side order flow imbalance within bar; no threshold disclosed. (v175, [08:38]) NEEDS-OPERATIONALIZATION

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

1. **Three-indicator "3-Pack" suite** — Orderflows AV Indicator, Market Flow Trader (ratio+divergence), Tension Indicator. All are NT8 add-ons, each runs on standard bar charts (no footprint required), but complement footprint for trade management. Released ~March 2020. (v175, [00:00]) [ONCE]

2. **AV Indicator** — compares value area in current bar vs. prior bars; signals value rejection; can display a "zone" for stop placement; has a separate "trade entry signal" sub-toggle that adds an arrow on the bar after. Can run on plain bar charts or footprint. (v175, [00:27]; v175, [03:21]) [ONCE]

3. **Market Flow Trader** — codifies ratio + divergence into NT8 indicator for plain bar chart; fires trade entry arrows; configurable settings per market. "Default settings" shown; user-adjustable. (v175, [05:01]; v175, [08:00]) [ONCE]

4. **Tension Indicator** — analyzes bid-side vs offer-side order flow traded (not DOM orders); identifies bars where control was contested then one side won; both reversal and momentum modes; NT8 add-on. Can run on the free NT8 version with a third-party real-time data feed (e.g., IQ Feed or Kinetick). (v175, [08:38]; v175, [13:24]) [ONCE]

5. **Prominent/Primary POC coloring** — indicator auto-colors POC levels: blue/cyan for supportive, magenta for resistance. Updates in real time during bar formation; locks on bar close; does not repaint. (v174, [35:55]; v174, [38:01]) [ONCE]

6. **Software highlights prominent POCs, bearish POCs, and Delta divergence** — existing Orderflows Trader footprint chart: colors bearish POC in red/purple; shows Delta divergence with red triangle; shows bearish ratio as blue number above bar. All computed automatically. (v171, [25:31]; v171, [35:21]) [REPEATED]

7. **Market replay compatibility** — "yes it's a market replay so you could watch it, you know you could speed it up — there's like a thousand times as fast." NT8 market replay works with Orderflows Trader software for backstudy. (v171, [41:03]) [ONCE]

8. **Signal bar vs entry bar distinction** — AV Indicator: signal fires on the signal bar; the trade entry arrow appears on the bar AFTER the signal bar. Prevents lookahead. (v175, [01:18]) [ONCE]

9. **3-Pack runs on free NT8 + external data feed** — allows traders on other platforms to use NT8 as a read-only indicator platform. (v175, [13:57]) [ONCE]

---

## Q. Notable verbatim quotes

1. "Institutional traders don't wait for the high to be made and then start selling… they start selling as the market is making that high — that's why you see all the negative Delta going up into the high." (v174, [25:26]) — key psychology of institutional distribution at peaks.

2. "One shows commitment one shows intention — in my opinion commitment is much more important than intention." — footprint (traded) vs DOM (orders). (v171, [12:17])

3. "It went from positive 3,000 aggressive buyers to negative 2,000 aggressive sellers — so it's actually a swing of 5,000. That's very important information." — on Max Delta / Min Delta intrabar reversal. (v171, [44:43])

4. "I see that ok aggressive buyers are stepping up but the market's not going higher then all of a sudden I see aggressive selling coming in… that overrides what I just thought literally five minutes ago." — absorption failure triggering short thesis. (v171, [27:30])

5. "Where would you rather be short from the 50 40 area the 50 10 area or the 49 88 area right — well you know you're gonna want to be short from as high a level as possible and order flow gives you that ability." — order-flow entry superior to TA confirmation entry. (v174, [22:47])

6. "If I start seeing things in the order flow that aren't conducive to my position then I'm going to cut it — however if I see things in the order flow that look supportive of my position then I'll stay in it longer." — active trade management using live order flow. (v175, [07:27])

7. "The deltas which you know are kind of mixed honestly — I'm not going to say that oh yeah these are very bullish — but by looking at the point of controls I know there's support." — POC can be the primary signal even when Delta is ambiguous. (v174, [39:30])

8. "This was a ratio and divergence — the trade I'm always looking for because it's what got me hooked on order flow many many years ago when I discovered it." (v175, [05:29])

9. "Three green candles up with higher each with a higher point control than the previous one for a buy — for a cell it's three red down candles each with a lower point of control." — exact verbatim rule for migrating POC signal. (v174, [34:19])

---

## R. Contradictions / nuances

1. **Delta can be "kind of mixed" at a valid long entry.** If POC structure is clearly supportive (prominent POC + migrating POCs), a trade is viable even without clear positive Delta. This slightly softens the digest's implied requirement for Delta alignment; POC structure can be dominant. (v174, [39:30]) [ONCE]

2. **Two consecutive counter-POC bars ≠ exit; three = reconsider.** The standard "follow-through" framing implies quick confirmation; here he stays in a long through two lower-POC bars and only partially scales, staying in because no third lower-POC bar appears. Suggests POC-based invalidation threshold is three bars, not two. (v174, [33:55]) [ONCE]

3. **Ratio + divergence used intraday at swings, not just HOD/LOD.** Digest notes HOD/LOD as primary location; v175 explicitly states "you could also use them intraday in swings" as an equal alternative. Not a contradiction but a material refinement of scope. (v175, [05:01]) [ONCE]

4. **Imbalances are harder to observe in 10yr notes** — "it's difficult to get a lot of imbalances" due to very heavy volume; yet the market is still tradable via migrating POCs and Delta. Adjusts the "imbalances required" framing for ultra-high-volume instruments. (v174, [34:25]) [ONCE]

5. **NQ preferred timeframe as short as 30 seconds** — v171 mentions "markets like Nasdaq I go down to a 30-minute chart" in one breath and then "I go down to a 30-second chart" in another (note: likely "30-second" at [20:54] is the stated intended range). This is notably shorter than the digest's general framing of range-based and 1-min charts. NEEDS-OPERATIONALIZATION. (v171, [20:54]) [ONCE]

6. **Footprint not required for the new 3-pack indicators** — the Market Flow Trader, AV Indicator, and Tension Indicator all run on plain bar charts. While the footprint remains Mike's preferred trade-management tool, the signal generation itself is independent. This slightly broadens the NT implementation model beyond "footprint only." (v175, [01:50]; v175, [13:24]) [ONCE]

7. **"Markets don't move because price hit a moving average or we crossed an oscillator across zero — it moves on supply and demand."** — strong dismissal of MA/oscillator-based systems; order flow as sufficient. (v174, [09:46]) [ONCE]

---

## Coverage note

v171 (Investor Expo Dec 2019 webinar, 9,070 words) is the richest transcript in this chunk: covers fundamentals, Delta divergence, POC alignment, absorption, and the Max/Min Delta concept in useful detail. v174 (Feb 2020 webinar, 8,064 words) is equally valuable and introduces the migrating POC rule most crisply, along with the "kind of mixed Delta" nuance and prominent POC mechanics. v175 (3-Pack product intro, 2,598 words) is thin on model rules but introduces three named NT8 indicators (AV, Market Flow Trader, Tension) with useful implementation details. All three are largely introductory/educational in style — some repetition of basics — but contain several model-relevant specifics not previously captured.
