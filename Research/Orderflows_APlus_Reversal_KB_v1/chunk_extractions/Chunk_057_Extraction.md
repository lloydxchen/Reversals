# Chunk 057 Extraction
- Source chunk: Chunk_057_Orderflows_Transcripts.md
- Transcripts covered:
  - v187 — Order Flow Trading Made Easy Orderflows Trader (2020-08-11)
  - v188 — Order Flow Strategies For Today's Trading Environment Orderflows Investor Expos NinjaTrader 8 (2020-09-18)
- Overall content value: thin

---

## A. Setup types & names he uses

- **Reversal at HOD/LOD with exhaustion + divergence + imbalances** (bearish at HOD, bullish at LOD): identified via converging signals — negative/positive delta divergence at the extreme, selling/buying imbalances, prominent POC acting as resistance/support, POC migration in the opposite direction. (v188, "Order Flow Strategies For Today's Trading Environment", [19:14]–[22:36]) [REPEATED]
- **Prominent POC resistance/support**: a visually distinct (highlighted) POC that acts as immediate S/R; used as a location filter for shorting at resistance or buying at support. The software highlights these in a different color. (v187, "Order Flow Trading Made Easy", [28:43]–[30:09]) [REPEATED]
- **Multiple-imbalance bar** (3+ imbalances in a single bar, called "multiple" rather than waiting for stacked): used as an earlier entry signal vs. waiting for classically stacked imbalances. (v187, [37:00]–[38:08]) [REPEATED]
- **Stacked imbalance** (3+ imbalances neatly on consecutive price levels): standard S/R zone definition, acknowledged as sometimes appearing "a bit of foam" (late). (v187, [35:21]–[37:32]) [REPEATED]
- **Delta divergence** (positive delta at LOD or negative delta at HOD): buying at a low = divergence bullish; selling at a high = divergence bearish. (v188, [21:06]–[22:06]) [REPEATED]
- **Market exhaustion** (volume dries up at extremes — "1 contract vs 17 previous bar"): the "last seller has sold / last buyer has bought" concept; identifiable by tiny volume at the edge of a bar. (v188, [20:14]–[20:41]) [REPEATED]

---

## B. Tiering / grading language  ← HIGH PRIORITY

- "planets are aligned" — used to describe a LOD reversal where exhaustion, divergence, aggressive buyers, value moving up, AND multiple buying imbalances all appear simultaneously; this is his implicit A+ / top-tier framing. (v188, [26:22]) [ONCE]
- "probably the low for now" — his stated confidence language when multiple signals converge at a low; softer language used when only one or two signals are present. (v188, [26:22]) [ONCE]
- No explicit A/B/C or A+ grading language in these two videos; tiering is expressed implicitly through signal count: more signals = stronger/more reliable reversal. (v187, v188) [SPECULATIVE]
- "some point controls are more important than others" — prominent POC is his tier-1 POC signal; ordinary POC is lower tier. (v187, [32:44]) [ONCE]
- "a bar with three or more imbalances" > "a bar with one imbalance" > "no imbalances" — explicitly tiered by imbalance count within a single bar. (v187, [37:00]) [REPEATED]

---

## C. Order-flow story & psychology per setup

- At HOD: aggressive buyers bid the market up; once they are exhausted ("last buyer has bought"), delta flips negative, POC migrates lower, selling imbalances appear — sellers are now in control. Market cannot go higher without renewed aggressive buying, which is absent. (v188, [10:47]–[11:14]; v187, [19:50]–[24:56]) [REPEATED]
- At LOD: aggressive sellers drove the market down on negative delta; when exhaustion hits ("last seller has sold"), even a single contract at the extreme may represent the final seller. Then buyers step in aggressively — positive delta appears even while price is still near the low = divergence. (v188, [20:14]–[21:35]) [REPEATED]
- "The big traders are going to be offering it out and putting a cap on the market" — large passive sellers defend a prominent POC from above; aggressive buyers run out of sellers to lift and fail to break through. (v187, [30:40]) [ONCE]
- Absorption implicit: buyers absorbing at a low accumulate a position; positive delta during a nominally down period shows the accumulation; when absorption is complete, aggressive buyers take control and market moves up. (v187, [17:08]) [REPEATED]
- POC as value magnet bar-to-bar: the previous bar's POC acts as the likely pullback target for the next bar; traders "price the market" relative to that value. (v188, [28:57]–[29:55]) [ONCE — see Section R]

---

## D. Exhaustion clues

- Dramatically reduced volume at the edge of a bar (e.g., "1 contract traded at 75 and a half vs 17 on the bid in the prior bar") — volume collapse at the extreme is the primary exhaustion signal. (v188, [20:14]–[20:41]) [REPEATED]
- "Small volume being traded at the edges of the bar" — his phrasing for exhaustion bars; also described as price reaching an extreme level with minimal participation. (v188, [32:25]) [REPEATED]
- NEEDS-OPERATIONALIZATION: no exact threshold for "small volume" given in these videos; qualitative only.

---

## E. Absorption clues

- Positive delta at a low while price is still declining or at the extreme: aggressive buyers appear while price has not yet turned; their buying is absorbed by passive sellers (or covers are absorbed), building a base. (v187, [17:08]; v188, [19:14]) [REPEATED]
- POC staying stable (clustering at roughly the same price level across multiple bars) = value being established = accumulation/absorption zone. (v187, [16:40]) [REPEATED]
- NEEDS-OPERATIONALIZATION: no exact threshold for absorption magnitude given.

---

## F. Stacked imbalance ideas

- Stacked imbalance defined: 3+ selling (or buying) imbalances neatly on consecutive price levels within one bar. (v187, [35:21]) [REPEATED]
- Limitation explicitly stated: "by the time they appear it's a bit of foam" — stacked imbalances sometimes appear late, after a move has already occurred. (v187, [35:55]–[36:24]) [REPEATED]
- **Multiple-imbalance bar preferred over pure stacked**: a bar with 3+ imbalances (not necessarily at consecutive levels) gives an earlier signal and captures more of the move. (v187, [37:00]–[38:08]) [REPEATED]
- Software puts a box around bars with 3+ imbalances (buying or selling) in either up or down bars. (v187, [38:08]) [REPEATED]

---

## G. Delta / delta-divergence ideas

- Delta divergence (bullish): at LOD, market makes new lows on strong negative delta (−500, −1500, −360) then touches the low again with positive delta — aggressive buyers appeared at the extreme. (v188, [21:06]–[22:06]) [REPEATED]
- Delta divergence (bearish): at HOD, bar closes near the high with a strong positive delta (660), but next bar is red with negative delta — "not a good sign you're at your high of the day." (v187, [19:50]–[20:16]) [REPEATED]
- Strengthening negative delta sequence (−83, −405, −450) at HOD treated as confirmation of distribution, not a pullback-to-buy signal. (v188, [13:37]) [REPEATED]
- Divergence requires context (at a meaningful HOD/LOD after a real directional move); divergence mid-range is not discussed. (v188, [19:14]) [SPECULATIVE]
- Max/min intrabar delta mentioned briefly: "you can see very little aggressive buying in these bars with the aggressive selling going on, you can see that in the max admin delta." NEEDS-OPERATIONALIZATION — no formula given, just referenced as a visible data point. (v188, [31:54]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

— nothing in this chunk —

---

## I. Trapped-trader ideas

- Implicit: traders who chase a LOD breakdown ("finally the last guy gets to his computer, jumps, hits the sell button, boom, you made a print right there at the low") — the capitulation seller is trapped short immediately as the market reverses. (v188, [20:41]) [ONCE]
- No explicit stop-run or squeeze language in this chunk.

---

## J. Entry triggers (the exact "go" event)

- No explicit entry trigger specified in these videos; entries are implied by signal confluence:
  - At LOD: after exhaustion bar + divergence (positive delta) + buying imbalances + value moving up → buy "somewhere off this low, around 79/80/81 area." (v188, [26:22]) [ONCE]
  - At HOD: after prominent POC + negative delta + selling imbalances + POC migrating lower → short on any pop back to the prominent POC level. (v187, [30:40]) [ONCE]
- No bar-close / tick-above-extreme entry language given.

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Delta should continue in the direction of the trade (positive delta bars for longs, negative delta for shorts). (v188, [22:36]) [REPEATED]
- POC should migrate in the direction of the trade (higher for longs, lower for shorts) on subsequent bars. (v188, [25:16]; v187, [23:55]) [REPEATED]
- If long and order flow turns bearish after entry → "two choices: let the market stop you out or pull the plug early." (v187, [44:20]–[44:48]) [ONCE — see Section M]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- If bearish order flow appears after a long entry (negative delta, selling imbalances, POC migrating lower) = thesis failing; exit early rather than wait for stop. (v187, [44:20]–[44:48]) [ONCE]
- At HOD: any sign of aggressive buying returning (strong positive delta, buying imbalances dominating, POC migrating higher) would invalidate the short. (v188, [22:36]) [SPECULATIVE]
- "Delta of only 13 — for the market to move higher you'd need 300–400 positive deltas, not a delta of 13": weak positive delta at a failed bounce is not bullish — it is not enough to restart upside momentum. (v187, [22:50]–[23:23]) [ONCE — NEW SPECIFICITY, see Section R]

---

## M. Stop / risk / target / trade management

- No specific stop placement discussed in these videos.
- Trade management principle: monitor order flow after entry; if order flow supports the trade direction, hold longer (let winners run); if it contradicts, exit early (cut losers short). (v187, [44:20]–[45:25]) [REPEATED]
- "Not by throwing in an arbitrary stop and take profit based on an average over 20 trades — watch what's happening in the market." (v187, [44:48]) [ONCE]
- ~10-minute time stop not mentioned in these videos.
- Example from v188: 2–3 minutes, 6–7 points out of E-mini on a 30-second chart = representative quick scalp target at LOD exhaustion. (v188, [26:54]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- "High of the day" and "low of the day" as primary reversal locations — HOD/LOD are his key level filters. (v187, v188, throughout) [REPEATED]
- "Right after the Fed announcement we rallied up to new highs" — news event (Fed/FOMC) creates a HOD that is tradable for reversal; the key is reading the order flow at that HOD, not the news itself. (v188, [27:52]) [ONCE]
- Volatility environment: during high-VIX (COVID March–April 2020): "trade order flow the same way — don't widen stops, don't change indicators." (v188, [15:50]–[18:15]) [ONCE — see Section R for nuance]
- Applicable across chart types: 30-second, 1-minute, 5-minute, range, tick, volume-based charts — "you're looking for the same things regardless." (v188, [32:56]–[34:28]) [REPEATED]
- Applicable across markets: E-mini, NQ, crude oil, gold, Euro currency, bonds — same signals. (v187, [31:05]–[32:44]; v188, throughout) [REPEATED]
- Forex caveat: decentralized exchanges (non-CME forex) have non-centralized data = order flow less reliable; CME forex (Euro currency futures) is fine. (v187, [54:59]–[55:39]) [ONCE]
- Stocks: works on high-volume/liquid stocks (bank stocks, AAPL, GOOG, NFLX, FB) — volume is critical. (v187, [55:39]) [ONCE]
- Timeframe: personally uses 1-minute and 30-second charts; does not use anything over 5 minutes for order flow (data becomes stale — "reading order flow from 30 minutes ago isn't useful"). (v187, [56:17]) [ONCE]

---

## O. Directly testable / measurable variables

- **Imbalance ratio**: 4:1 as standard; 3:1 also used in some cases; not fixed ("some use 3:1, some 10:1, some 6:1"). NEEDS-OPERATIONALIZATION for a universal threshold. (v187, [33:50]–[34:17]) [REPEATED]
- **Imbalance bar count threshold**: 3+ imbalances in one bar triggers a "multiple imbalance" box in software; clearly actionable. (v187, [38:08]) [REPEATED]
- **Stacked imbalance**: same 3+ threshold but requires consecutive price levels. (v187, [35:21]) [REPEATED]
- **Delta divergence**: positive delta at LOD while previous bars had strong negative delta (e.g., −500, −1500, −360 then +XX). Measurable as sign change on delta at the extreme. (v188, [21:06]) [REPEATED]
- **Volume exhaustion at bar edges**: qualitative — "1 contract vs 17 in the prior bar" example. NEEDS-OPERATIONALIZATION for a ratio or absolute threshold. (v188, [20:14]) [ONCE]
- **POC migration direction**: sequential POC levels moving lower (bear) or higher (bull) over 3+ bars = directional confirmation. Measurable bar-by-bar. (v188, [28:57]) [REPEATED]
- **Delta magnitude for momentum**: "need 300–400 positive deltas" (on E-mini, presumably) for a market to move higher; a delta of 13 is insufficient. NEEDS-OPERATIONALIZATION (instrument/scale-dependent). (v187, [22:50]) [ONCE]
- **Order flow timeframe**: max 5 minutes; 1-minute and 30-second preferred. (v187, [56:17]) [REPEATED]
- **Max/min intrabar delta** (mentioned as a readable data point on the software): can show "very little aggressive buying" even in a nominally bearish bar. No formula given. NEEDS-OPERATIONALIZATION. (v188, [31:54]) [ONCE]

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- Orderflows Trader 2.0 on NinjaTrader 8: volume footprint chart with 7 pre-programmed order flow indicators. (v187, [06:17]; v188, [37:56]) [REPEATED]
- Software automatically highlights:
  - Prominent POC (displayed in a different/purple color from ordinary POC). (v187, [28:43]) [REPEATED]
  - Bars with 3+ imbalances (buying or selling) — displayed with a pink/colored box around the bar. (v187, [38:08]; v188, mentioned via arrows) [REPEATED]
  - Red arrows above bars / green arrows below bars = bullish/bearish order flow signals for trade management. (v187, [43:51]) [ONCE]
  - Numbers above and below bars generated by software (not explained in detail). (v187, [45:25]) [ONCE]
- Upcoming (as of Sept 2020): Orderflows Trader 3.0 with 5 new indicators (in beta at time of recording). (v188, [38:31]) [ONCE]
- Chart types supported: time-based (1min, 5min), range-based (4 range, 8 range), tick-based (1000 tick), volume-based (2500 vol, 5000 vol). (v187, [29:42]; v188, [33:26]) [REPEATED]

---

## Q. Notable verbatim quotes

1. "A rally will stop when the last buyer has bought. If there's no more buyers in a move up, the buyers are exhausted — what do you expect the market to do? Go higher? No. It's probably gonna stop right there, turn around, and sell off." (v188, "Order Flow Strategies," [10:47])

2. "At the low of the day right we have a sign of market exhaustion — one contract traded at 75 and a half in this bar, the previous bar traded 17 on the bid. Do you think this market is going to go any lower?" (v188, [20:14])

3. "It's like the planets are aligned — you've got a lot of good evidence that yeah, this is probably the low for now." (v188, [26:22])

4. "Order flow is not about trying to predict a high or low. It's about reacting to what's happening in the market." (v188, [26:54])

5. "For the market to move higher you're going to need strong positive deltas — not a delta of 13. You need like 300–400 positive deltas." (v187, "Order Flow Trading Made Easy," [22:50])

6. "Some point controls are more important than others. Having software that shows you point of controls that matter will put you ahead of other traders who can't differentiate one point of control from another." (v187, [32:44])

7. "If you're long and you also see a bunch of bearish order flow, that's not a good sign. You got two choices: one, you could let the market just go stop you out; or two, you can pull the plug on the trade, get out early." (v187, [44:20])

8. "You don't let your winners run and cut your losers short by throwing in an arbitrary stop and take profit based on an average over 20 trades — you watch it by what's happening in the market." (v187, [44:48])

9. "The value in the previous bar — that's where the pullback came to. Imagine being a trader and someone's telling you, yeah, I got a good idea of where the market could pull back to in the next bar based on what is happening in this bar." (v188, [29:55])

10. "In volatile markets, you trade order flow the same way — you're reacting to what the market is telling you." (v188, [32:25])

---

## R. Contradictions / nuances

1. **"Trade order flow the same way in volatile markets" — no stop widening, no indicator changes**: this directly addresses and contradicts the common retail response to high VIX (March–April 2020) of widening stops and adjusting indicators. His position: the method is invariant to volatility regime because it is reactive, not predictive. (v188, [15:50]–[18:15]) [ONCE] — Partially related to digest ("high VIX → pivot to liquid markets") but the explicit "don't widen stops" directive in a VIX 70+ environment is a new nuance.

2. **POC as bar-to-bar intraday magnet**: bars tend to pull back precisely to the previous bar's POC (within 1–2 ticks). This is presented as a near-mechanical rule for where the market goes after a bar closes. (v188, [28:57]–[29:55]) [ONCE] — The digest captures POC as S/R at swing level; this intrabar/adjacent-bar POC-magnet behavior is a more granular, more immediately actionable claim.

3. **Delta of 13 is not bullish on E-mini**: at a failed bounce attempt (bar slightly pops to upside), a delta of only 13 is characterized as insufficient to drive the market higher; he implies a threshold around "300–400 positive deltas" for a meaningful bullish bar. (v187, [22:50]) [ONCE] — The digest captures delta thresholds qualitatively ("strong delta >25% delta/volume"); this gives a rough magnitude anchor for E-mini context but is instrument/scale-dependent.

4. **Forex (decentralized, non-CME) unreliable for order flow**: because data is not centralized, the order flow you see on screen may differ from actual market flow. CME-listed forex contracts (e.g., Euro currency futures) are acceptable. (v187, [54:59]) [ONCE] — Not contradicted in digest but adds specificity to the instruments filter.

5. **Multiple-imbalance bar preferred over stacked imbalance**: while both are valid signals, the multiple-imbalance bar (3+ in one bar, not necessarily consecutive) is preferred because it fires earlier — stacked imbalances sometimes appear "a bit of foam" after the main move. (v187, [36:24]–[37:32]) [REPEATED in digest; emphasis on "foam" language as tiering mechanism is worth noting]

6. **Order flow data staleness above 5 minutes**: using order flow on a 30-minute chart means reading what happened 30 minutes ago — explicitly called out as useless. His personal maximum is 5 minutes; prefers 1-minute and 30-second. (v187, [56:17]) [ONCE] — Digest captures session context but not a specific max-timeframe for order flow relevance.

---

## Coverage note

v187 is a ~60-minute introductory/sales webinar at a third-party event (Online Trader Central); roughly the first 45 minutes cover pedagogical basics (delta, POC, imbalances) with illustrative market examples but without deep A+ signal specificity. v188 is a shorter (~45-minute) Investor Expo presentation with similar pedagogical framing. Both are thin for new model content — they repeat established concepts (exhaustion, divergence, delta, imbalances, prominent POC) without adding new thresholds, setup variants, or grading criteria beyond what is in the digest. A small number of nuances are extractable (POC bar-to-bar magnet, volatile-market "don't change anything" rule, E-mini delta magnitude anchor, timeframe staleness cap). Content value: thin.
