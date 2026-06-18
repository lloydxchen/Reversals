# Chunk 049 Extraction
- Source chunk: Chunk_049_Orderflows_Transcripts.md
- Transcripts covered:
  - v164 — Orderflows Bulge For NinjaTrader 8 Analyze Order Flow Volume (2019-07-27)
  - v165 — How To Improve Your Trading Using The 10 Features Of Orderflows Trader Daytrading Software (2019-08-05)
  - v166 — Using Order Flow Delta To Find Market Weakening Demand Or Weak Supply With Orderflows Trader (2019-08-10)
  - v167 — Understanding Order Flow Delta In Context Of The Market (2019-08-11)
  - v168 — How to determine if a high can be taken out based on order flow delta (2019-08-13)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Orderflows Bulge** (v164, [06:46]): larger-than-normal volume at a single price level inside a bar, placed in market-structure context (swing high/low, relative volume, bid/ask composition, ratio filter). Has both bullish (buy arrow) and bearish (sell arrow) variants.
- **Trade Entry Signal / follow-through gate on the Bulge** (v164, [09:32]): confirmation variant of the Bulge — requires price to start moving in the signal direction by at least a user-defined number of ticks over the next N bars before generating the entry arrow. Not a new setup per se, but a gating mechanism for the Bulge.
- **Delta Divergence (with price-action gate)** (v165, [14:06]): sell = new/equal high + negative delta; buy = new/equal low + positive delta. Orderflows variant additionally requires the bar's *candle direction* to confirm reversal (green bar for buy divergence, red bar for sell divergence at the extreme). [REPEATED across chunk]
- **Ratio + Divergence combo** (v165, [16:26]): divergence alone can fail; divergence paired with a qualifying volume ratio = "powerful trade setup" / "my favorite trade." [REPEATED]
- **Three-in-a-row Ratio setup** (v165, [1:10:42]): three consecutive bullish (or bearish) ratio prints, then a pullback bar, between the two POCs of the second and third bars — entry on that pullback. [ONCE]
- **Prominent POC retest** (v165, [35:21]): bearish (magenta/cyan) or bullish prominent POC forms, market retests it; used as entry trigger. Risk = 2 ticks from POC level; target = ~20 ticks. [REPEATED]
- **Zero Print / Market Sweep** (v165, [19:01]): zeros or near-zeros in the footprint at the edge of a bar, indicating a large participant swept the market at a swing high or swing low. Bearish if downward sweep, bullish if upward sweep. [REPEATED]
- **Trapped Traders / Imbalance Reversal** (v165, [18:25]): imbalance where longs are wrong or shorts are in the hole; tool highlights bars with opposing trapped longs (bearish) or trapped shorts (bullish). [REPEATED]
- **Multiple Imbalances** (v165, [56:28]): 3+ imbalances in a single bar that are NOT stacked vertically on top of each other. Triggers earlier than stacked imbalance. Bullish at lows, bearish at highs. [REPEATED]
- **Delta contraction/exhaustion pattern** (v166, [03:42]): sequential weakening of delta magnitude in the direction of the trend, followed by a flip — signals potential reversal. Qualitative pattern, no fixed number. [REPEATED in v166, v167, v168]
- **Passive-seller absorption / positive-delta-on-decline** (v167, [01:28]): market declines with positive delta because passive sellers are absorbing aggressive buyers — NOT a buy signal; signals absorption/supply. [REPEATED]
- **Passive-buyer absorption / negative-delta-on-rally** (v167, [04:47]): market rallies with negative delta because passive buyers are absorbing aggressive sellers — bullish supportive buying, not bearish. [REPEATED]
- **Aggressive-sellers-dry-up pattern at high** (v168, [02:53]): after a double divergence at a high, if negative delta subsequently gets SMALLER (e.g., -1345 → -1217 → -118) instead of larger, sellers are drying up; high is likely to be taken out. [ONCE — live market example]

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"My favorite trade"**: divergence + bullish/bearish ratio together at HOD/LOD — "I'm always looking for these trades. I wish I could get 10 of them a day." (v165, [1:13:03]) [REPEATED]
- **"Powerful trade setup"**: divergence combined with ratio (v165, [16:26]); also used for divergence + ratio at extremes with confluence (v165, [1:13:03]) [REPEATED]
- **"Very bullish sign"**: multiple buying imbalances off the low of the day (v165, [57:04]); also market rally from divergence + bullish ratio (v165, [1:01:55]) [REPEATED]
- **"Bearish sign"** (v165, [06:19]): primary/prominent POC at the high (magenta); also ratio alone at high [REPEATED]
- **"Go take the money out of your piggy bank, put it on getting short here"** — used for divergence + ratio + multiple imbalances + small digit prints all at the high of day (v165, [1:01:55]) — highest grade implied. [ONCE]
- **"Great" / "nice" trades**: individual Bulge signals at swing highs/lows with trade-entry signal enabled (v164, [10:50]) [ONCE]
- **"Legitimate trade" / "losing trade"**: Bulge signal where follow-through is absent = "legitimate trade take but the price action of the trade isn't going in that direction" (v164, [15:10]) — marginal/skip tier. [ONCE]
- **"I don't use it" / messy/too many lines**: unfinished business — Mike explicitly says he does not use it (v165, [53:05]); similarly cumulative delta (v165, [47:06]). Not graded as bad, just not part of his model.
- **Ratio magnitude does NOT affect grade**: "Don't get caught up in how big or how small the ratio is. As long as it's a blue number…I don't care if it's 112 or if it's 29, okay? As long as it's blue." (v165, [1:10:12]) — binary qualifier, not gradient. [ONCE — important nuance]
- **"Nice move" / "good sign"**: multiple imbalances staying on the trade direction after entry used as hold indicator (v165, [58:21]) [ONCE]
- **Stacked imbalance at the low with immediate follow-through**: "Boom, you're in the trade." (v165, [58:01]) — highest-grade entry implication [ONCE]

---

## C. Order-flow story & psychology per setup

- **Bulge**: oversized institutional activity at a single price level; "big traders are the institutions who are often involved" coming into market supply/demand. Isolated volume only matters in context — must be at a swing level, and must be followed by other buyers/sellers (v164, [07:14]). [REPEATED]
- **Passive sellers vs. aggressive buyers** (v167, [01:28]–[03:51]): large commercials/producers offer their inventory out (passive) to absorb all the aggressive buying. Aggressive buyers eventually exhaust; then market drifts/rips down. "The aggressive buyers are tired, market drifts down." The passive sellers are happy to sell at gradually lower prices — they don't whack bids.
- **Passive buyers vs. aggressive sellers** (v167, [04:47]–[06:47]): passive buyers sit on bids, absorbing all aggressive selling. Aggressive sellers eventually exhaust, market drifts/rallies up.
- **Trapped longs/shorts**: people buying a declining market thinking it's a buying opportunity; supply holds them down, then floor drops (v165, [20:29]).
- **Zero prints / sweeps**: a large institutional participant (e.g., $300M allocation) immediately lifts all available offers or hits all bids in one pass — extremely aggressive, not typical order flow. Signals big conviction at turning points (v165, [19:01]).
- **Delta contraction at a low** (v166, [03:42]): sellers arrive strong (-939, -661, -193) then weaken; aggressive buyers begin appearing (+324). "As we were coming down into this low a potential low was being put in here."
- **Aggressive-sellers-dry-up at a high** (v168, [02:53]): after two divergences near the high, if subsequent negative-delta values SHRINK (-1345 → -1217 → -118), sellers are done. The market will take out the high: "I'm starting to think if we take off this high, we're gonna go much higher."

---

## D. Exhaustion clues

- **Small/single digit print at swing extreme** (v165, [39:10]): price level at the edge of a bar with only 5, 7, 9 contracts traded when the bar itself traded tens of thousands. "Five lots trade in the 10-years. Look at this bar. This bar traded 75,073,000 contracts, but traded just five lots at that high." — last buyers have bought. [REPEATED]
- **Small digit prints as trend confirmation on a move**: on a declining market, small digit prints repeatedly appearing at offer side = no buying interest; confirms hold of short (v165, [43:48]). [ONCE]
- **Multiple/accumulating small digit prints before a collapse** (v165, [45:20]): "high of the day here, start coming off, going sideways right before this big sell-off. Small print, small print, small print. Five, four, three. Lack of buying interest. Come off again…lack of buying interest…market just falls over." [ONCE]
- **Delta contraction into a high**: weaker positive delta on each new probe to the high — "buying really weakening up here every time you poke up to the hi, it's on weaker positive Delta" (v166, [08:48]). [REPEATED]
- **Aggressive sellers drying up at a high (delta shrinkage after divergence)** (v168, [02:53]): -1345 → -1217 → -118 after two bearish divergences; signals sellers exhausted, high will be taken out. [ONCE]
- **Ratio threshold (≥28 bearish / ≤0.69 bullish)**: blue ratio number at the extreme signals price exhaustion or price defense (v165, [1:07:32]). [REPEATED]
- **Single digit print at top of red bar or bottom of green bar** = price exhaustion/rejection threshold; default ≤9 (10-years: user raises to 25–50+ due to liquidity) (v165, [39:38]). [REPEATED]

---

## E. Absorption clues

- **Passive sellers absorbing aggressive buyers (positive delta on decline)**: offer side consistently heavier; large passive seller offering out inventory at each price level; market declines despite aggressive buying (v167, [01:58]–[03:51]). NEEDS-OPERATIONALIZATION: no specific offer/bid ratio threshold given for passive vs. active.
- **Passive buyers absorbing aggressive sellers (negative delta on rally)**: bid side consistently heavier; market rallies despite negative delta (v167, [05:46]–[06:11]). NEEDS-OPERATIONALIZATION.
- **Bullish ratio (≤0.69) at lows**: indicates price defense — someone defending a level (v165, [1:07:32], [1:08:39]). [REPEATED]
- **Volume at a prior support level on retest**: heavy volume at the same price on return confirms it's a defended area (v165, [29:17]). Example: 6030 level holds on second approach with same volume cluster.
- **Stacked buying imbalance at the low**: aggressive buyers overwhelming sellers at the extreme; "Boom, you're in the trade" (v165, [58:01]). [REPEATED]
- **Multiple buying imbalances spread across a bar (not stacked) at low**: 3+ non-adjacent imbalances = broader absorption pattern (v165, [57:04]). [REPEATED]

---

## F. Stacked imbalance ideas

- Default cluster size = 3 (industry standard) to qualify as stacked imbalance (v165, [55:32]). Can be lowered to 2 for earlier signals but more noise. [REPEATED]
- Imbalance ratio default = 4:1 (400 in software); some users use 5:1 or 10:1 (1000) for stricter filtering (v165, [55:59]). [REPEATED]
- Shelf life for stacked imbalance as S/R: software default look-back = 5 bars ("I'm looking at this as near-term support or resistance…if it doesn't happen, things in the order flow have probably changed") (v165, [54:36]). [REPEATED]
- Stacked imbalance used as S/R after entry: if already long from lower and market is trading 5 points higher with stacked imbalance on the current bar, that is a reason to hold (v165, [58:21]). [ONCE]
- Multiple imbalances (non-stacked, 3+ in bar) fire **earlier** than stacked imbalance: "You're getting in 4 points earlier before the stacked buying imbalance" (v165, [1:01:24]). [REPEATED]
- Seeing a zero print (sweep) alongside stacked imbalance = especially clear institutional activity (v165, [22:22]). [ONCE]

---

## G. Delta / delta-divergence ideas

- **Delta divergence definition**: sell = new/equal high + negative delta; buy = new/equal low + positive delta (v165, [14:06]). [REPEATED]
- **Orderflows-specific delta divergence enhancement**: in addition to price and delta diverging, the bar must CLOSE in the direction of the reversal (green bar = buy divergence; red bar = sell divergence). Standard software does not require this. (v165, [1:14:33]) [REPEATED — but here stated more explicitly as a differentiator vs. competing software]
- **Divergence by itself can fail** (v165, [1:13:03]): three examples shown where divergence alone produced no follow-through; divergence paired with ratio = powerful. [REPEATED]
- **Delta contraction pattern** (v166, [03:42]): selling delta shrinks sequentially → flip to positive → potential low. "−939, −661, −193, then +324" — qualitative pattern, not a fixed number. NEEDS-OPERATIONALIZATION. [REPEATED]
- **Delta weakening at a high** (v166, [08:13]): multiple retests of high on progressively weaker positive delta = demand failing. "479… 182… 23… 14… −133" — delta shrinks/flips at resistance. [REPEATED]
- **Aggressive sellers drying up post-divergence** (v168, [02:53]): at a double divergence top, subsequent negative delta becomes very small (−118 vs prior −1345); sellers exhausted, high will be taken out. This is the **opposite of the expected exhaustion signal** — delta shrinkage at a high = bulls win, NOT bears. [ONCE]
- **Cumulative delta**: Mike explicitly does NOT use it ("it lags"; it will cut you out of short trades that are valid because cumulative stays positive) (v165, [47:06]). [ONCE — stated reason]
- **Max delta / min delta**: within-bar extremes of delta; relationships between delta, max delta, min delta discussed in depth in his delta course but not elaborated here (v165, [48:57]). [ONCE]
- **Three building blocks of order flow** (v166, [00:00]): (1) Delta, (2) Point of control, (3) Imbalances. [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Zero print / market sweep** (v165, [19:01]): aggressive participant clears all available liquidity in one direction — bullish or bearish — at swing high/low. Especially important when occurring at swing highs/lows (not just intrabar highs/lows). [REPEATED]
- **Passive sellers creating false-positive delta on decline** (v167, [01:28]): bullish delta does not mean the high will be taken out — passive selling can sustain a downtrend even against aggressive buying. This is a counter-intuitive pattern that can trap naive delta readers. [REPEATED]
- **Aggressive sellers drying up → high taken out** (v168, [02:53]): after two divergences, if delta gets smaller on each bar while price holds near the high, the high is vulnerable to a breakout upward. [ONCE]

---

## I. Trapped-trader ideas

- **Imbalance Reversal / Trapped Traders indicator** (v165, [18:25]): flags bars where buyers are trapped long (expect continuation down) or sellers trapped short (expect continuation up). Color coded dark orange (sell/bearish) and dark blue (buy/bullish). [REPEATED]
- **Context requirement**: "Do you want to be buying going into the high? If you're at a high, you got to be looking for a potential reason to sell" (v165, [21:33]) — trapped buyer signals near HOD are for shorts, not longs. [REPEATED]
- **Passive-buyer/seller absorption**: passive sellers trap aggressive buyers who buy into declining market; once passive sellers stop offering, the floor drops — trapped buyers must cover (v167, [02:58]). [ONCE — explicit mechanism]

---

## J. Entry triggers (the exact "go" event)

- **Bulge with trade entry signal enabled** (v164, [12:44]): entry arrow generated only when (a) Bulge condition met, AND (b) within `trade_validity_bars` bars, price moves at least `trade_price_ticks` ticks in the signal direction. "As soon as you see it, that's when you get into the trade." Default: price level = 1–2 ticks, validity = 1–2 bars (max 5 for both). [ONCE — explicit settings]
- **Divergence + ratio together** at HOD/LOD: when both appear on same bar, that is the entry bar (v165, [16:26], [1:13:03]). [REPEATED]
- **Three-in-a-row ratio + pullback bar** between POCs of bars 2 and 3 (v165, [1:10:42]): entry on the pullback bar, not the signal bar. [ONCE]
- **Prominent POC retest**: short/long at the retest of a prominent POC after it forms; stop 2 ticks away; target ~20 ticks (v165, [37:50]). [ONCE — explicit risk/reward]
- **Delta contraction flip** (v166, [04:11]): aggressive sellers weaken sequentially, then first positive delta bar appears; "that would be like sort of my ghost signal." The positive-delta bar is the entry trigger. [ONCE]
- **Aggressive buying confirms delta-dry-up at a high** (v168, [03:26]): after seller delta shrinks, the next strong positive delta bar (e.g., +1300) near/above the prior high signals long entry. [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Trade entry signal function**: within 1–2 bars (up to 5) the market must move 1–2 ticks (up to 5) in the signal direction to confirm (v164, [12:44]). If no movement, no signal is generated. [ONCE — quantified]
- **"The market just shoots right up"**: the ideal case after a Bulge or divergence+ratio — immediate, clear directional follow-through with no sideways chop (v164, [16:34]). [REPEATED]
- **Small digit prints appearing in direction of trade**: if long and small digit prints are appearing on the bid side (bottom of red bars) = sellers are not interested in taking market lower = hold confirmation (v165, [43:48]). [ONCE]
- **Multiple imbalances in subsequent bars**: if in a long and multiple buying imbalances appear on the next bar, hold the position (v165, [58:43]). [ONCE]
- **Passive buyers absorbing sellers = negative delta on rally**: market rallies while negative delta → confirms passive support = hold long (v167, [07:14]). [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Sideways chop after Bulge signal** (v164, [14:42]): "the price action of the trade isn't going in that direction…you're not getting the follow-through selling." → trade entry signal filter eliminates these. [REPEATED]
- **Aggressive sellers appearing on a long entry** (v164, [10:03]): "if you buy and all of a sudden sellers come into the market your trade's gonna become a loser very quick." [REPEATED]
- **No movement within validity window** (v164, [12:15]): Bulge + trade entry signal — if price doesn't move in direction within `trade_validity_bars`, no signal. Existing zones remain but no entry arrow. [ONCE]
- **Delta NOT contracting at high → high unlikely to hold** (v168, [02:24]): if aggressive selling stays large/growing at a high after divergence, the divergence is more likely to resolve to the downside (continuation of the thesis). If sellers DRY UP, thesis reverses.
- **Positive delta bar failing to break prior high** (v166, [08:13]): each new probe to the high on weaker positive delta = demand is failing; the high is not going to extend. [REPEATED]
- **Cumulative delta staying positive on downmove** does NOT invalidate shorts (v165, [47:06]): explicitly stated — using cumulative delta as a filter cuts out valid short trades. [ONCE]

---

## M. Stop / risk / target / trade management

- **Prominent POC trade**: stop = 2 ticks from POC level; target = ~20 ticks (v165, [38:15]). Risk/reward stated as ~1:10 conceptually; acknowledges 70–80% loss rate but positive expectancy. [ONCE — explicit]
- **Divergence + ratio at extreme**: "My stop is right above the high [for a sell], or if it was a buy, right below the low." (v165, [1:13:31]). [REPEATED]
- **Hold signals**: use multiple imbalances and small digit prints in subsequent bars to decide whether to stay in trade or exit (v165, [58:43]). [ONCE]
- **Volume-at-price as target**: prior high-volume cluster at a price level = potential first target; "you may have to take your profits a little bit early" if support cluster is near (v165, [29:44]). [ONCE]
- **Willing to give up 2–3 ticks** for confirmation via trade entry signal to avoid larger stop-outs (v164, [13:10]). [ONCE]
- **Eliminating 25–30% of losing trades** via follow-through gate = the practical benefit of the trade entry signal function (v164, [19:38]). [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Market context requirement for any signal** (v165, [21:33]): signals near HOD should be looked at for shorts; signals near LOD should be looked at for longs. Signal direction must match market position. [REPEATED]
- **POC as target and support/resistance** (v165, [29:17]): prior high-volume cluster acts as near-term support/resistance. Example: 6030 on crude oil held on return; stop placed just beyond it.
- **Prominent POC as S/R**: prominent (high-distance from top of bar) POC acts as support/resistance; the market often retests them (v165, [35:21]). [REPEATED]
- **Bars with fewer than 4 price levels**: Mike avoids analysis / POC trader less reliable on bars with ≤4 price levels; best on bars with larger ranges (v165, [36:21]). [ONCE]
- **3 POC levels useful for volatile/liquid markets**: for 4-range chart = use 2 POC levels; for 8-range or minute chart on liquid markets = up to 3 POC levels (v165, [34:06]). [ONCE]
- **Evening session valid** for delta analysis (v168, [07:47]): "you can use this during the day session, you can use it in the evening session."
- **Volume profile on trend days**: value area migrating higher/lower confirms trend direction; Mike no longer uses it actively since he only trades mornings and a couple hours after lunch (v165, [1:03:24]). [ONCE]
- **Unfinished business time limit**: effective within ~30–60 minutes of formation; over 1 hour "forget about it" (v165, [50:34]). [ONCE — specific time limit stated]
- **Unfinished business on volatile markets** (post-2019): with Trump-era volatility, unfinished business is less effective; it was designed for rangy/rotational days (5–10 pt S&P range) (v165, [49:29]). [ONCE]

---

## O. Directly testable / measurable variables

- **Bulge volume multiplier**: bar traded "2–3 times as much volume" at a price level compared to surrounding bars. NEEDS-OPERATIONALIZATION (no fixed multiplier given, just "larger than normal relative volume"). (v164, [07:14])
- **Trade entry signal — price level in ticks**: 1–2 ticks default (max 5). Price must move this many ticks in signal direction within the validity window. (v164, [12:44])
- **Trade entry signal — validity in bars**: 1–2 bars default (max 5). (v164, [12:44])
- **Ratio threshold for exhaustion**: ≥28 (blue; was 25 previously) (v165, [1:07:32])
- **Ratio threshold for defense**: ≤0.69 (blue; was 1.0 previously) (v165, [1:07:32])
- **Ratio is binary**: any blue number (above 28 or below 0.69) qualifies — magnitude above/below threshold is irrelevant (v165, [1:10:12])
- **Stacked imbalance cluster minimum size**: 3 (default/industry standard); can be 2 (v165, [55:32])
- **Imbalance ratio default**: 400 = 4:1; alternative 1000 = 10:1 (v165, [55:59])
- **Stacked imbalance look-back**: 5 bars default (v165, [54:36])
- **Small digit print threshold**: default ≤9; for 10-year notes recommended ≤25 or ≤50 depending on bar size (v165, [39:38])
- **Unfinished business shelf life**: ~30–60 min; >1 hour ineffective (v165, [50:34])
- **Delta divergence bar-close direction requirement**: buy divergence bar must close GREEN (higher than open); sell divergence bar must close RED (lower than open) (v165, [1:14:33])
- **Delta contraction pattern**: no fixed threshold — sequence of shrinking absolute delta values followed by a delta-direction flip. NEEDS-OPERATIONALIZATION.
- **Passive absorption**: no specific bid/ask ratio threshold stated. NEEDS-OPERATIONALIZATION.
- **Three building blocks of order flow**: (1) Delta, (2) POC, (3) Imbalances (v166, [00:00])
- **Bars analyzed only if ≥4 price levels** in the bar (v165, [36:21])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Orderflows Bulge indicator** (v164): standalone NT8 indicator. Settings: Bulge value (custom threshold), look-back filter for swings, delta confirmation (same direction as price), delta divergence filter, prominent POC filter. Runs on footprint or candlestick charts. [ONCE]
- **Trade Entry Signal function** within Bulge (v164, [09:32]): embedded in the Bulge indicator. Parameters: `trade_price_level_ticks` (1–5 ticks) and `trade_validity_bars` (1–5 bars). Delays the entry arrow until follow-through conditions met. Max setting = 5 for both. [ONCE — explicit params]
- **Orderflows Trader 2.0 for NT8** — 10 features: (1) delta divergence (with price-action gate), (2) imbalance reversals (trapped traders + zero prints), (3) four ladder types (bid/ask, delta, volume, diagonal delta), (4) POC Trader (prominent POC detector), (5) small digit prints, (6) summary content (delta/max delta/min delta/volume), (7) unfinished business, (8) volume imbalances (stacked + multiple), (9) volume profile, (10) volume ratio. (v165, [09:57])
- **Delta divergence price-action gate**: bar close direction must confirm reversal (green for buy, red for sell) — should be added to NT divergence detection logic (v165, [1:14:33]).
- **Multiple imbalance detector**: 3+ imbalances anywhere within a bar (not stacked); shown separately from stacked imbalance; fires earlier signals (v165, [56:28]).
- **Zero print detection**: count of zeros or near-zero prices at the edge of a bar; indicates a sweep. Can co-occur with stacked imbalances (v165, [19:01]).
- **Three POC levels per bar** (v165, [30:49]): display top 3 by volume within bar; color coded; POC Trader highlights "prominent" ones based on distance from bar extreme (distance threshold configurable as 1/2/3 levels). Level 2 and 3 useful for bars with 5+ price levels; for very short bars stick to level 1–2.
- **Volume Profile on chart**: day's volume profile; shows POC, VAH, VAL, low-volume nodes, high-volume nodes. Mike does not currently use it actively (v165, [1:02:57]).
- **Summary content fields** Mike uses: Delta, Max Delta, Min Delta, Volume (per bar). Explicitly does NOT use: cumulative delta, cumulative delta/volume, bid volume, ask volume separately (v165, [46:35]).
- **Delta ladder chart**: delta per price level within the bar (offer − bid); shows horizontal delta patterns; Mike finds it more powerful than bid/ask for intra-bar analysis (v165, [26:37]).

---

## Q. Notable verbatim quotes

1. "Just as here, highs are made when people are done buying. When the last buyer has bought, the high is put in." — Tom DeMark quote attributed to TDeMark but endorsed by Mike (v165, [42:50])

2. "Don't get caught up in how big or how small the ratio is. As long as it's a blue number, that's all that matters to me. Because it's a ratio, not actual volume numbers." (v165, [1:10:12])

3. "This is my favorite trade. I'm always looking for these trades. I wish I could get 10 of them a day, even if just half were right, I'm fine with it because I know where my stop is — right above the high." — on divergence + ratio combo (v165, [1:13:03])

4. "Go take the money out of your piggy bank, put it on getting short here." — on divergence + ratio + multiple imbalances + small digit prints all at HOD (v165, [1:01:55])

5. "Often times, you don't get stacked imbalances as often as you get multiple [imbalances] and you get them earlier." (v165, [1:00:55])

6. "You can use this during the day session, you can use it in the evening session." — on delta pattern analysis, e.g., around 7:15 PM (v168, [07:47])

7. "The things that don't happen as expected are just as important if not more important than what happens as you expect." — on passive absorption causing unexpected delta behavior (v167, [00:55])

8. "I'm starting to think if we take off this high, we're gonna go much higher. The sellers are drying up here." — on shrinking negative delta post-divergence signaling a breakout, not a reversal (v168, [02:53])

9. "Eliminate 25% to 30% of trades that don't work out…that could be the difference for some people from having a profitable year or a losing year." — on the trade entry signal function (v164, [19:38])

10. "Unfinished business…they were looking for the market to come back there relatively soon, like within an hour, even 30 minutes. If it's over an hour, forget about it." (v165, [50:34])

---

## R. Contradictions / nuances

1. **Ratio magnitude is irrelevant — only binary (blue/not-blue)**: Mike explicitly states the ratio value above 28 or below 0.69 does not matter; 29 is as valid as 112. This contradicts any assumption that a higher ratio = stronger signal (v165, [1:10:12]). [ONCE — stated as explicit rule]

2. **Cumulative delta is NOT used and can be harmful**: Mike explicitly rejects cumulative delta because it will disqualify valid short setups when cumulative delta is positive. This conflicts with common order-flow teaching that references cumulative delta direction as a filter (v165, [47:06]).

3. **Positive delta on a declining market is NOT bullish**: if passive sellers are absorbing buyers, positive delta = supply, not demand. "That's what's causing this positive delta — the supply in there." (v167, [02:58]). This is a direct contradiction of the naive reading: "positive delta = buy."

4. **Negative delta on a rising market is NOT bearish**: passive buyers absorbing sellers = supportive buying. "When you see negative delta in a rising market — pay very close attention to it because what you're seeing is supportive buying." (v167, [07:14]). Contradicts naive: "negative delta = sell."

5. **Sellers drying up at a high = bullish, not bearish**: after two divergences, if the negative delta shrinks from -1345 to -118, Mike interprets this as sellers exhausted and high likely to be taken out to the UPSIDE (v168, [02:53]). This is the reverse of what might be expected (divergence normally = top). Shows that divergence is cancelled by delta-dry-up on the confirming side.

6. **Delta divergence alone often fails**: three examples given where divergence by itself produced nothing; a ratio must pair with it to elevate to a tradeable setup. "These trades where you get divergence by itself, nothing, nothing, divergence + ratio, market sold off." (v165, [1:13:03]).

7. **Unfinished business: shelf life strictly ~30–60 min**: Mike endorses the original inventor's view — used within 30–60 min only. He personally does not use unfinished business at all in current trading (v165, [50:34], [53:05]).

8. **Delta divergence requires candle-direction confirmation**: standard divergence detectors only check price level and delta sign; Orderflows version also requires the bar to close in the reversal direction. Without this, "they're going to be wrong a lot" (v165, [1:14:33]).

9. **Three-in-a-row ratio setup — entry on pullback bar, not signal bar**: entry is not on the bars with ratios but on the pullback bar after three consecutive ratios (v165, [1:10:42]). Non-obvious — most ratio setups imply immediate entry.

---

## Coverage note

- v165 (Orderflows Trader 10 Features, ~75 min) was by far the richest transcript — dense with measurable thresholds, setup descriptions, and grading language. It is the primary source for most of this extraction.
- v164 (Orderflows Bulge) introduced a new indicator (Bulge + Trade Entry Signal) with explicit parameter ranges.
- v166, v167, v168 were short (~1,900–1,100 words each) and focused specifically on delta interpretation; rich for nuances on passive absorption and delta pattern reading but thin on new setups.
- No unparseable content; all transcripts were cleanly formatted.
