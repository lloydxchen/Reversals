# Chunk 096 Extraction
- Source chunk: Chunk_096_Orderflows_Transcripts.md
- Transcripts covered:
  - v369 — Finding Your Best Chart For Trading Range Charts Or Time Charts (2023-08-31)
  - v370 — Max And Min Delta How To Use It And What It Means In The Order Flow (2023-09-01)
  - v373 — Delta Flips In The Order Flow And How To Effectively Trade Them (2023-09-05)
  - v377 — Think Like An Institutional Trader To Understand What The Big Trades In The Market Really Mean (2023-09-07)
  - v378 — What Is The Ideal Chart For Trading Order Flow (2023-09-08)
  - v379 — Orderflows Trader vs NinjaTrader Volumetric Charts What Are The Differences (2023-09-09)
  - v380 — NinjaTrader Volumetric Charts Point Of Control And Cumulative Delta Candles (2023-09-10)
  - v381 — Trading Without Volume Footprint Charts Like ICT Or Using Orderflows Trader (2023-09-10)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta Flip** (bullish and bearish variants): A two-bar pattern using max/min delta. Bullish: red bar with zero or near-zero Max Delta (aggressive buyers never in control), followed by a green bar with zero or near-zero Min Delta, where the green bar's final Delta closes near its Max Delta. Bearish: inverse. Previously had an NT7 indicator; never ported to NT8. (v373, "Delta Flips In The Order Flow", [01:15], [04:18])
- **Prominent Point of Control (POC)** reversal: Multiple Prominent POCs stacking at the same level signals a significant S/R area; bullish if at lows, bearish if at highs. Used as reversal anchors. (v379, "Orderflows Trader vs NT Volumetric", [14:19])
- **Multiple Imbalances** at a swing low (bullish): Green box around a bar with strong delta into volume (magenta color = 25%+ delta-to-volume ratio) appearing right off a low. (v369, "Finding Your Best Chart", [01:56])
- **Absorption at a low** (bullish): Strong aggressive selling at a low with zero move (price can't decline despite strong negative Delta) — market goes sideways then reverses. Described as a textbook example of what absorption looks like. (v370, "Max And Min Delta", [13:20])
- **Bar Gaps / "Fair Value Gap" hybrid** (unreleased indicator): Mike's proprietary "Bar Gaps" indicator — loosely based on ICT fair value gap concept but filtered by actual order flow (volume, footprint signals). Not a pure price-action setup. [ONCE] (v381, "Trading Without Volume", [06:19])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- Delta flip with follow-through: The flip is only actionable "if the market starts moving in that direction." If price doesn't trade through the low of the prior bar (for a short flip) on the next 1–2 bars: "nine times out of ten the market should start going in that direction" — failing to do so is described as a disqualifier. (v373, "Delta Flips", [09:16])
- Delta flip quality filter: The final Delta of bar 1 should be "closing somewhere near the max Delta" (or Min Delta for bearish). A final Delta of 4 vs a Max Delta of 59 is explicitly rejected: "four no that's not good enough." (v373, "Delta Flips", [07:03])
- Big-volume context quality: Fresh buying as a market is rallying off a low (size coming in as price moves, not in a sideways zone) is described as "strongest," "more appealing," and "more important" vs size hitting in a ranging/sideways area. The latter is characterized as likely covering or exiting, not initiating. (v377, "Think Like An Institutional Trader", [14:34], [17:42])
- "Not a massive move but it starts to come off a little bit" — used as a lower-tier description of a delta flip that is technically valid but lacks vigor. (v373, "Delta Flips", [10:20])
- Absorption at a low + aggressive buying comeback: "It doesn't get any more clearer than that" — top-tier endorsement for the pattern of strong selling being absorbed (price doesn't drop), then aggressive buying takes over. (v370, "Max And Min Delta", [13:49])

---

## C. Order-flow story & psychology per setup

- **Delta Flip psychology**: First bar has relentless aggressive selling (Max Delta zero — buyers never in control). Second bar has relentless aggressive buying (Min Delta zero — sellers never in control, final Delta near Max Delta). Story: one side completely wipes out the other in sequential bars. (v373, "Delta Flips", [04:48], [05:47])
- **Big-bid absorption / swept-out buyer**: A large institutional bid at a price level acts as initial support, but if buyers at that level are absorbed/overwhelmed, when the level breaks decisively "he's done, he's out of the way" — removing the reason to expect further support. Stops of those long become fuel for continuation lower. (v377, "Think Like An Institutional Trader", [09:59])
- **Fresh buying vs covering**: Big bids entering in a sideways/ranging zone are likely distribution or short-covering. Big bids entering as price rallies off a low are characterized as "fresh buying" — a new position being initiated, which is more significant for a sustained reversal. (v377, "Think Like An Institutional Trader", [14:34])
- **Absorption at low**: Repeated strong negative Delta bars that fail to push price lower — sellers being absorbed by passive buyers. When aggressive buying then appears (large positive Delta closing near Max), the trapped sellers are forced to cover, adding fuel. (v370, "Max And Min Delta", [13:20])
- **Small Min/Max Delta at swing lows**: Small Max Delta at a high (aggressive buyers weak near peak) or small Min Delta at a low (aggressive sellers weak near bottom) means "one side of the tug of war never got the flag" — one side completely dominated. Context dependency is critical: these signals must appear near swing extremes, not in middle of range. (v370, "Max And Min Delta", [09:27])

---

## D. Exhaustion clues

- Exhaustion prints visible on range charts, tick charts, volume charts, and time charts — "the same things in the order flow" regardless of chart type. (v369, "Finding Your Best Chart", [05:21])
- On a 200-tick crude chart: delta weakening as price approaches a high — "52 as you're going up towards the high, the negative then 42, right up here at the high, just five and then negative deltas coming in, minus 41, minus 82, minus 72" — sequential weakening followed by flip is an exhaustion signal. [ONCE] (v378, "Ideal Chart For Trading Order Flow", [09:47])
- Small Max Delta / small Min Delta at swing extremes: "you want to see it come in near the high... you want some sort of clue that aggressive selling is coming in near the high... rather than coming in at [mid-range]" — location is essential to reading exhaustion from min/max delta. (v370, "Max And Min Delta", [09:27])

---

## E. Absorption clues

- **White-colored bars (small Min/Max Delta threshold = 3)**: When bars show Max Delta 0–3 or Min Delta 0 to -3 (small min/max delta threshold in OT software, default = 3), the opposing side "was never in control" — absorption is occurring. Seeing multiple consecutive whites means one side is fully absorbing the other. (v370, "Max And Min Delta", [04:59], [05:27])
- **Four consecutive white (zero/small delta) bars at a swing low**: Four zeros in a row at the low of day = strong aggressive selling being absorbed. Described as a misread by novices who think "the market should have sold off" — the correct read is absorption. (v370, "Max And Min Delta", [12:48])
- **Green candle with negative Delta**: A green-closing bar (up candle) with negative final Delta indicates a "strong passive bid" absorbing aggressive selling — bullish. He identifies this as a bar-by-bar delta divergence. (v380, "NT Volumetric Charts POC and Cumulative Delta", [10:21])

---

## F. Stacked imbalance ideas

- Stacked imbalances highlighted in OT software (boxed), not available as a native feature in NT8 Volumetric chart. Stacked imbalances visually cluster multiple consecutive imbalances to show S/R zones. (v379, "Orderflows Trader vs NT Volumetric", [17:47])
- From v369 example: a single bar at a low can have both stacked buying imbalances AND strong delta into volume (magenta 25%) simultaneously — when both appear at a swing low this makes a higher-quality reversal read. (v369, "Finding Your Best Chart", [01:56])
- Stack imbalance three bars visible on range chart that preceded a market rally (v379, [18:29]). No new threshold rules beyond what is already in digest.

---

## G. Delta / delta-divergence ideas

- **Three forms of Delta Divergence** explicitly named in this chunk [NEW taxonomy]:
  1. At new highs or new lows (price/delta divergence — the known form)
  2. Bar-by-bar basis: a green candle with negative Delta (or red candle with positive Delta)
  3. Within cumulative Delta intraday: cumulative delta turning while price still moves in original direction
  (v380, "NT Volumetric Charts POC and Cumulative Delta", [09:45], [10:21], [11:27])
- **Max Delta** (cyan color, ≥95% of Max): signals bar is closing near its strongest aggressive buying — bullish. **Min Delta** (magenta color, ≥95% of Min): bar closing near its strongest aggressive selling — bearish. Both are already captured thresholds (95%) in digest but the color-coding semantics are spelled out explicitly here. (v370, "Max And Min Delta", [03:06], [04:19])
- **Small Min/Max Delta threshold**: default = 3 (0 to +3 for Max Delta, 0 to -3 for Min Delta), colored white in OT software. Identifies bars where one side "was never in control." (v370, "Max And Min Delta", [04:59])
- **Delta Flip setup** (two-bar pattern — detailed mechanics, see Section A): requires: (1) bar 1 final Delta near its own Max or Min Delta, AND (2) bar 2 opposite-side bar with zero or near-zero opposite-side control. (v373, "Delta Flips", [04:48])
- Delta flip "doesn't appear a lot in e-minis"; appears more often in crude oil due to different trader composition (less retail, more commercial/institutional with specific hedging needs). [ONCE] (v373, "Delta Flips", [01:15])
- Cumulative delta + bar-by-bar delta together: "bar by bar delta... getting weaker as it's going down into this low" even while cumulative delta still declining — divergence between bar-level weakening and overall cumulative trend. (v380, [09:14])
- Delta into volume threshold (25%): magenta coloring in OT software = delta/volume ≥ 25% in that bar. Normal range is implied to be lower (14% cited as "just 14%"). (v369, "Finding Your Best Chart", [01:56], [02:27])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- Large bid at a level is tested, partially holds, then broken: "once it stays clearly below this level I could be looking for this Market to potentially go test this low." The buyer being "done" removes support and suggests a test of the prior extreme. (v377, "Think Like An Institutional Trader", [09:59])
- Big-bid sweep: when a large DOM bid is cleared, longs at that level who bought thinking it was support are now trapped — they must cover, providing continuation fuel downward. (v377, [05:46])
- A delta flip that fails to take out the prior bar's extreme "on the next bar... nine times out of ten the market should start going in that direction. If it's not trading lower it's no go." — immediate follow-through required; failure to follow through is the failed-setup signal. (v373, "Delta Flips", [09:16])

---

## I. Trapped-trader ideas

- **Trapped longs at a big bid level**: Traders who buy when a large bid (e.g., 5,000 contracts) is visible in DOM get trapped when bid is absorbed and market breaks below. They must exit → adds selling fuel. (v377, "Think Like An Institutional Trader", [05:46])
- **Delta flip bar 1 implies trapped side**: A red bar with zero Max Delta means buyers never participated — any buying at that bar is immediately overwhelmed. Those who tried to buy against the aggressive selling in bar 1 are now trapped and must cover when bar 2 reverses. [SPECULATIVE] (v373, "Delta Flips", [05:19])
- Small Min Delta at high / small Max Delta at low in context: "you're being alerted to it 20 points higher than down here" — these readings at extremes reveal that the dominant side is losing its ability to push further. Those holding positions in the original direction are becoming trapped. (v370, "Max And Min Delta", [09:27])

---

## J. Entry triggers (the exact "go" event)

- **Delta Flip trigger**: The "go" event is bar 2 closing as the opposite-color candle with zero/small opposite-side delta AND final Delta near its own extreme. The market must then start moving in that direction — "you got to be watching that the market is moving in your direction." Enter on or after that bar 2 close. (v373, "Delta Flips", [08:42], [19:24])
- **Three-bar variant of Delta Flip**: "if you want to get a little bit more fancy you could sort of take it over three bars and disregard the bar in the middle as just sort of market facilitating trade." Bar 1 (directional) + middle bar (neutral/doji allowed) + bar 3 (reversal bar). Less pure. [ONCE] (v373, "Delta Flips", [13:45])
- Big fresh-buying entry: entering when large volume appears "as the market is rallying" (not in a sideways zone) because that is interpreted as new position-taking rather than short-covering. (v377, "Think Like An Institutional Trader", [14:34])
- Range chart advantage: on a range chart, a bullish Prominent POC + multiple imbalances + strong Delta into volume (magenta) can appear on the bar immediately after a low — giving earlier signal than the same event on a time-based chart. (v369, "Finding Your Best Chart", [03:05])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Delta Flip: "the market should start going in that direction" — immediate directional follow-through. If the next bar doesn't trade beyond the signal bar's extreme (in the reversal direction), the flip is failing. "Nine times out of ten the market should start going in that direction." (v373, "Delta Flips", [09:16])
- After absorption pattern (strong selling + white bars + then strong buying): aggressive buying Delta (large positive, closing near Max) should arrive within 1–2 bars of the absorption zone. "521 closing near 544, 1150 closing near 1161" — explicit confirmation bar description. (v370, "Max And Min Delta", [13:49])
- Big-bid fresh-buy scenario: market should continue upward, not revisit the prior low within the next few bars, since the big buyer "thinks the low of the day has been made." (v377, "Think Like An Institutional Trader", [14:02])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Delta Flip invalidation**: "you don't even go lower than this bar, this red candle, that's not a good sign. It's probably not going to work if you can't even take out the low." — price must penetrate signal-bar extreme in the reversal direction within 1–2 bars. (v373, "Delta Flips", [08:10])
- **Big-bid absorption failure**: once a large bid is taken out and price stays clearly below that level, the buyer is "done" — no longer protecting that zone. Invalidates longs based on the presence of that bid. (v377, "Think Like An Institutional Trader", [09:59])
- **Small Min/Max Delta in wrong location**: "it's not going to be effective, we just had a 20-point sell-off, you want to get it as close to the high of the day or a swing high." Small Max Delta signals in the middle of a range or at recent lows are not actionable. (v370, "Max And Min Delta", [09:27])
- **Delta Flip bar-1 quality failure**: Final Delta of bar 1 not close to its own Max/Min Delta (e.g., Delta = 4 vs Max Delta = 59) disqualifies the setup. (v373, "Delta Flips", [07:03])
- **Candle color mismatch on Delta Flip**: Bar 1 must be the directional color (red for bullish flip), bar 2 must be the opposite color (green for bullish flip). A doji or wrong-color bar disqualifies. "The second bar you're going to go in the direction of the color of the candle." (v373, "Delta Flips", [15:33])
- **Delta flip bar 2 covers too few price levels**: "I like to have at least some price movement in a bar rather than just two price levels. I like to see you know the bar cover three four five price levels rather than just two." Bars spanning only 2 price levels are disqualified. (v373, "Delta Flips", [16:55])

---

## M. Stop / risk / target / trade management

- Nothing specific to stops/targets in this chunk beyond general principles already in digest.
- Chart type choice affects stop feasibility: "can you accept quick moves going against you, where you're going to be placing your stop" — chart type (range vs time) dictates which bars form, which determines the stop distance. No new numbers. (v369, "Finding Your Best Chart", [01:27])
- For the delta flip, it is implied that exit comes if the market "can't even take out the low" (or high for bearish) — essentially a time-stop equivalent after 1–2 bars with no follow-through. (v373, "Delta Flips", [09:16])

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Chart type by market liquidity/volatility** (concrete ranges given) [REFINING existing digest]:
  - Bonds (slow): 4-range chart (cannot use 1-min); range chart mandatory for bonds
  - Grains (most): 4-range
  - Crude oil, S&Ps, currencies: 8-range (standard)
  - YM: 10-range (or 8-range if volatility is normal)
  - NQ: 15-range (due to faster/more volatile nature; 15 specifically called out)
  - During extreme volatility (e.g., COVID): scale up (one trader went from 10-range → 50-range on YM)
  - 1-minute time chart = minimum starting point for intraday footprint analysis; "don't really go out beyond a 5-minute chart on the order flow"
  - 30-second time chart: acceptable for crude (about as low as Mike goes in time)
  - 15-second: too fast, latency issues
  - Volume charts: 500-volume for crude is "decent" for morning session; 100-volume is "too small" for crude
  (v369, [03:37]; v378, "Ideal Chart", [04:00], [05:30], [17:13])

- **Delta Flip market filter**: Does not appear frequently in e-minis (too much retail noise); appears more in crude oil, bunds, and markets with commercial/institutional-dominant participation. British pound can show many false flips on low-volume bars — need "decent volume" in bars. [ONCE] (v373, "Delta Flips", [01:15], [12:33])

- **Big-volume location filter**: Large orders/bids entering during sideways/ranging price action (where the market "has been trading for the last 10 minutes") = likely distribution or covering, NOT fresh initiative. Large orders entering as market is trending/moving (e.g., rallying off a low) = potentially fresh position-taking. [REFINING — adds directionality/context to how size should be interpreted] (v377, "Think Like An Institutional Trader", [15:37], [17:42])

- **"Don't really go out beyond a 5-minute chart on the order flow"** — explicitly rejecting multi-timeframe HTF analysis for order flow purposes. "By then you've had so much movement in between that I could have taken advantage of." (v369, "Finding Your Best Chart", [10:50])

---

## O. Directly testable / measurable variables (bullet each; include any exact numbers he gives; mark NEEDS-OPERATIONALIZATION where qualitative)

- **Small Min/Max Delta threshold**: default = 3. Zero to +3 = small Max Delta (colored white in OT software); 0 to -3 = small Min Delta (colored white). Indicator setting: "small min max Delta threshold." (v370, [04:59]) ← EXACT NUMBER
- **Extreme Delta threshold**: 95% — bar's final Delta must be within 95% of its Max Delta (cyan) or Min Delta (magenta) to trigger color. OT software setting: "extreme Delta threshold in percent." (v370, [03:06]) ← EXACT NUMBER (already in digest but confirmed here with setting name)
- **Delta into volume ≥ 25%**: triggers magenta coloring on a bar (strong aggressive buying). Normal delta-to-volume: implied ~14% or less. (v369, [01:56]) ← EXACT NUMBER (already in digest; confirmed)
- **NinjaTrader Volumetric imbalance threshold default**: 1.5 (too low per Mike — "at 1.5 you're gonna get a ton of imbalances"). He recommends at least 3–4. (v379, "Orderflows Trader vs NT Volumetric", [04:26]) ← EXACT NUMBER (NT default = 1.5; Mike's minimum = 3–4)
- **NT Volumetric minimum imbalance volume**: 10 (same as Orderflows Trader default). (v379, [06:12]) ← EXACT NUMBER
- **Delta Flip bar 2 minimum price range**: at least 3–5 price levels (ticks) NEEDS-OPERATIONALIZATION for exact minimum. (v373, [16:55])
- **Delta Flip follow-through window**: must move in reversal direction within next 1–2 bars. NEEDS-OPERATIONALIZATION (no exact bar count given, but "next bar" is the primary check). (v373, [09:16])
- **Chart type range recommendations** (per instrument, see Section N): 4-range (bonds/grains), 8-range (crude/ES/FX), 10-range (YM), 15-range (NQ). ← EXACT VALUES
- **Maximum order flow chart timeframe**: 5-minute (don't go higher for intraday order flow). (v369, [10:50]) ← EXACT NUMBER
- **Minimum order flow chart timeframe (time-based)**: 30-second for crude (not recommended below). (v378, [05:30]) ← APPROXIMATE
- **Volume chart for crude**: 500-volume is "decent"; 100-volume is "too small." (v378, [10:17]) ← EXACT VALUES

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Orderflows Trader exclusive features vs NT8 Volumetric** (full feature comparison given):
  - Prominent POC (drawn as lines until tested): NOT in NT8 Volumetric. Exclusive to OT. Must be coded manually if not using OT. (v379, [14:19])
  - Exhaustion prints: NOT in NT8 Volumetric. OT-exclusive. (v379, [16:26])
  - Stacked imbalances (highlighted as a group): NOT in NT8 Volumetric. OT-exclusive. (v379, [17:47])
  - Delta weakness detector: NOT in NT8 Volumetric. OT-exclusive. (v379, [19:05])
  - Value areas + engulfing value areas: NT8 Volumetric has a basic volume profile (needs "show volume" enabled + "show maximum" for POC); OT has more advanced value area tools. (v380, [02:00])
  - Cumulative Delta candles: Available in NT8 Volumetric paid version (under Order Flow Suite). Can run session delta and bar-by-bar delta simultaneously on separate panels. (v380, [06:00], [07:05])
  - Max/Min Delta coloring (cyan/magenta): OT-exclusive feature on the footprint bars themselves. NT8 does show Max/Min Delta numbers in bar statistics but does not color-code them. (v370, [03:06])
  - Small Min/Max Delta coloring (white): OT-exclusive. (v370, [04:59])

- **NT8 Volumetric imbalance settings** (for any NT-native implementation):
  - Default imbalance ratio: 1.5 (too low; use 3–4 minimum)
  - Default minimum imbalance volume: 10
  - Imbalance direction: diagonal (preferred), not horizontal
  - Show Maximum = POC (yellow by default); "show volume" shows the volume profile per bar (v379, [04:26]; v380, [01:30])

- **Delta Flip indicator**: Mike had a NT7 indicator for this; never ported to NT8. Described as "very visual" and "you can see it yourself." Implementation is straightforward: per bar, track Max Delta, Min Delta, and final Delta; flag pattern when sequential bars show opposite-side dominance. (v373, [01:15])

- **Bar Gaps indicator**: Mike's proprietary unreleased indicator. "Loosely based off of fair value gaps" but filtered by volume/footprint signals. Only mentioned, not described in detail. (v381, [06:19])

- **White background recommendation**: Consistently argues for white background over black for footprint chart readability, especially for imbalance colors (cyan/magenta) and POC (yellow on black hard to see). (v379, [02:54], [03:28])

---

## Q. Notable verbatim quotes (3–10, each with citation)

1. "You want to go as low and as fast as you can go that's giving you information out of the order flow that's actionable. It's not about how fast you can trade." (v378, "Ideal Chart", [09:24])

2. "When you have strong selling and it can't move the market it's being absorbed. That is the definition of absorption." (v370, "Max And Min Delta", [13:20])

3. "Nine times out of ten the market should start going in that direction. If it's not trading lower it's no go." — on delta flip follow-through requirement (v373, "Delta Flips", [09:16])

4. "It doesn't get any more clearer than that" — on strong selling being absorbed then massive buying reversing; 521 closing near 544, 1150 closing near 1161. (v370, "Max And Min Delta", [13:49])

5. "Market is attracted to size... once you become a big Trader you need size to trade against." — explaining why DOM orders are a magnet, not just resistance. (v377, "Think Like An Institutional Trader", [04:15])

6. "Once it stays clearly below this level... I could be looking for this Market to potentially go test this low. I know that this buyer, he's done, he's out of the way." (v377, "Think Like An Institutional Trader", [09:59])

7. "Big size coming in on the bid in a move, to me that's more important than big size coming in on the bid in a sideways market, an area that you've just been trading at for the last 10 minutes." (v377, "Think Like An Institutional Trader", [17:42])

8. "I don't really go out beyond a 5-minute chart on the order flow because by then you know if I'm looking at an hourly chart and this happened at 7:50 and I'm looking at a hourly chart, I'm waiting for things to confirm, you know, by 8:00 you know I've had some there's a lot of movement in between." (v369, "Finding Your Best Chart", [10:50])

9. "You want to take the best ones right... that's what trading is all about right you want to take the higher percentage trades." (v381, "Trading Without Volume", [09:04])

10. "The Delta flip doesn't necessarily appear a lot in say the e-minis... in some of the other markets like crude oil it appears more often." (v373, "Delta Flips", [01:15])

---

## R. Contradictions / nuances (anything that conflicts with common belief, with his other statements, or that is conditional/"it depends")

- **Delta Flip not universal across markets**: Previously, digest implies his setups work similarly across liquid markets with "same settings." The Delta Flip is explicitly stated as *market-specific* — rare in e-minis, more common in crude/bunds. This is a meaningful nuance not in the digest. (v373, "Delta Flips", [01:15])

- **Chart type is a subjective but structured choice, not arbitrary**: While "no ideal chart," he gives a concrete mapping of range sizes to instruments (4/8/10/15) — "it's not like every time I put up a different chart." Caution about "adjusting charts on the fly" based on recency bias (seeking winning charts). Consistency is the principle. (v378, "Ideal Chart", [17:13], [18:42])

- **Big DOM bids are magnets, not resistance**: "Market is attracted to size" — large bids in the DOM attract price rather than repel it. A big bid may hold briefly then be absorbed; what matters is WHAT HAPPENS after price gets there. This contradicts the naive DOM interpretation (big bid = support). Already partially in digest ("DOM is a magnet not resistance") but this chunk provides the fuller narrative. (v377, [04:15], [05:46])

- **Three-bar delta flip vs two-bar**: The "pure" form is two consecutive bars. The three-bar variant (disregarding a middle "facilitating" bar) is described as "a little bit more fancy" and less definitive. No explicit tiering but the language implies lower quality. (v373, [13:45])

- **Green candle + negative Delta = bullish (bar-by-bar divergence)**: Counter-intuitive. A green (up-close) bar with negative final Delta means passive bids absorbed aggressive selling — bullish signal despite the misleading Delta sign. Novices would misread this as bearish. (v380, [10:21])

- **"Not order flow but rather technical analysis 101"**: explicitly distinguishes previous support becoming resistance from order flow analysis. Mike is precise about what is order flow (actual aggressive volume) vs price action (pattern recognition). (v377, [10:32])

- **Delta into volume 25% = magenta, 14% = "just 14%"**: On a range chart the same low printed with 25% delta-to-volume; on a time chart the same bar only showed 14% — the chart type changed whether the OT software flagged it as strong buying. This means **chart type selection directly affects which signals fire**, not just visual formatting. [ONCE, important nuance] (v369, [01:56], [02:27])

---

## Coverage note

- v370 (Max/Min Delta mechanics) and v373 (Delta Flip) are the richest for model extraction — they contain the most precise operational definitions and thresholds.
- v369 (Range vs Time charts) and v378 (Ideal Chart) provide useful per-instrument chart-type calibration rules.
- v377 (Big Institutional Volume) adds important nuance on interpreting large bids in context (fresh vs covering), but is primarily conceptual, not a setup recipe.
- v379, v380, v381 are mostly comparative/software-comparison content with limited new model rules; some NT implementation details extracted.
