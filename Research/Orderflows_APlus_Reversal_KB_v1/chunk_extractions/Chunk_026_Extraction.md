# Chunk 026 Extraction
- Source chunk: Chunk_026_Orderflows_Transcripts.md
- Transcripts covered:
  - v39 — Orderflows Market Analysis May 2 2017 ES CL ZS 6E ZB Futures Day Trading (2017-05-03)
  - v40 — Orderflows Market Analysis May 3 2017 FOMC Day ES ZB ZF CL 6E futures trading (2017-05-04)
  - v41 — Orderflows Market Analysis May 4 2017 ES ZF ZS Futures Day Trading Order Flow Trading (2017-05-05)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta Surge** — reads expanding/increasing delta on range charts; signals when delta builds while price consolidates; designed to detect the moment buyers/sellers take control on quiet/slow markets. Primarily continuation signal but discussed at length. (v39, "May 2 2017", [06:49], [09:09], [27:01])
- **Delta Scalper** — distinct from Delta Surge; reads delta to find shifts in supply/demand at turns (swing highs/lows); fires at reversals. (v39, [16:02], [18:28]; v40, [08:33]; v41, [04:42])
- **Stacked Imbalance (reversal)** — multiple overlapping imbalances at highs/lows; still flagged as best at edges (value area high/low, HOD/LOD, swing extremes) not mid-range. (v40, [09:02], [10:29])
- **Ratio + Divergence** — delta divergence with ratio bounds low or high; bearish at highs, bullish at lows. (v39, [24:02]; v40, [07:02], [13:03]; v41, [03:27], [05:05])
- **Delta Divergence (bar)** — negative delta on a bar closing higher = bullish absorption; positive delta on a bar closing lower = bearish absorption. (v40, [13:27]; v41, [13:52])
- **Point of Control (POC) near extreme** — POC at bottom of bar = support; POC at top = resistance; especially when multiple POCs stack ("four point of controls right in a row"). (v40, [06:46], [07:21]; v41, [07:02])
- **Stacked Buying Imbalance at lows / Stacked Selling Imbalance at highs** — preferred reversal setup; he explicitly says he'd rather take stacked selling imbalance at high than stacked buying imbalance at high. (v40, [22:37]; v41, [04:18])
- **U-Turn** (Volos U-Turn indicator) — used for finding reversals at swing highs/lows. (v39, [24:56]; v40, [20:46]; v40, [27:46])
- **Price Rejector** — given as buy/sell at swing extremes; 4-factor tool (2016 root; previously catalogued). (v40, [20:20]; v41, [05:38])
- **O2 Setup** — low-risk short entry at swing high; stop 1 tick beyond high; failed if market ticks through before moving. (v40, [18:14], [18:35]) [ONCE]
- **Selling Imbalance at bottom of bar → buy** — selling imbalance printed at the bottom of a bar at a low is a bullish reversal clue ("when you get selling imbalances at the bottoms of bars, watch for a move higher"). (v39, [31:19], [31:42]) [ONCE]
- **Delta Declining into Low + Positive Delta Flip** — delta magnitude shrinking on successive bars into a low, then flipping positive = bullish reversal confirmation. (v41, [13:52], [14:26], [14:55])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"Beautiful" / "ideally that's how you want it"** — Delta Surge buy signal on a green candle after a move down into a low, with delta building. "That's what I want to see…it looks beautiful." (v41, [15:19]) [ONCE]
- **"Quite a very high percentage trade"** — stacked imbalances that are overlapped/consecutive ("one right after the other"). (v40, [10:56]) [ONCE]
- **"Nice" / "nice signal"** — Delta Scalper buy right off a swing low, confirmed by green bar. (v40, [08:33])
- **"Not the most going to be effective thing"** — Delta Surge at a high on a red (down) candle. Two negatives: wrong location (at a high, not a low) AND candle color mismatch. (v39, [36:20])
- **"Not a great signal" / "be afraid / be hesitant"** — Delta Surge buy on a red candle (price action of the bar going lower). "Be afraid, be hesitant to do this trade." (v39, [16:23])
- **"Not the best trade location"** — Delta Surge buy signal after a 25-tick move up, 2/3 of the way through the day's range. (v39, [22:32])
- **"I'd rather be taking"** — preference for stacked selling imbalance at the high of the day over stacked buying imbalance at the high. (v40, [22:37])
- **Grade discriminator — candle color agreement**: for a buy signal, the signal bar must close higher (green); for a sell signal, the bar must close lower (red). A signal that contradicts candle color is a lower-tier signal. (v39, [10:04], [16:02]; v40, [30:14]) [REPEATED]
- **Grade discriminator — location at edge vs. mid-range**: stacked imbalances in the middle of value area = lower tier ("you could have the best indicator in the world but…it's not going to be a very effective signal"). Edges (VAH, VAL, HOD, LOD, swing highs/lows) = higher tier. (v40, [09:32]) [REPEATED]
- **Grade discriminator — context after a big move**: buying at 2/3 of day's range after a sustained directional move = reduced quality even if the indicator fires. (v39, [19:56], [21:57])
- **"When I'm staring at something extremely negative and the market doesn't sell off — that's a sign to me"** — failed bearish confluence = bullish re-evaluation signal. Not graded but qualitatively noted as important context. (v40, [23:34]) [ONCE]

---

## C. Order-flow story & psychology per setup

- **Delta Surge at high after big move** — retail latecomers buying into the move ("retail people are coming in — oh I didn't buy, now they're coming in"); they get stuck when no more buying materializes; become forced sellers; Delta turns large negative as they exit. (v39, [20:23], [21:10])
- **Selling imbalances at the bottom of bars at a low** — indicates aggressive sellers at the low; after the bounce, if price returns to that level and sellers are NOT present in the same quantity at that level, the support is confirmed and a reversal is likely. (v39, [31:42], [35:19])
- **Stacked buying imbalances at lows that fail then resume** — aggressive buyers at lows (buying and balance stacked); market goes sideways; eventually "the sellers lose interest" (how negative delta declines); buyers take control. (v39, [26:30]; v40, [14:22])
- **Negative delta on a rising bar (ZF example)** — "supportive buying" absorbing aggressive sellers; sellers selling into bids but a large passive buyer keeps taking the other side; eventually sellers tire and price lifts. "Sell me more, sell me more, I'm happy to buy down here." (v40, [13:51], [14:22])
- **Aggressive buyers near high** — traders trying to push through a resistance level; when price can't get through and they get stuck, they flip to sellers and accelerate the downdraft. "All these people that were buying it aggressively here are looking to sell…these buyers turn sellers." (v40, [32:03]) [ONCE]
- **Failed bearish confluence → rethink** — when multiple bearish signals appear (stacked sell imbalance, ratio, divergence, POC at top) but price does NOT sell off = "that gives me a sign that you know rethink what's going on." (v40, [23:34]) [ONCE]
- **Delta declining into a low + positive flip** — the series: large negative delta → shrinking negative delta → small positive delta = selling exhausting, buying returning. The mid-bar max delta (as negative as -882) closing at only -41 is a specific clue that buyers overwhelmed intrabar sellers by bar close. (v41, [13:52], [14:26])

---

## D. Exhaustion clues

- Delta magnitude declining on successive bars into a swing extreme (each bar's net delta is less negative/positive than the prior bar). (v41, [13:52], [14:26]) [REPEATED]
- Blowoff volume reference: "as you get near a high you get blowoff volume, big delta" — but this is at an extended location after a big move; he's wary of taking that signal. (v39, [19:56]) [ONCE]
- Delta going large negative (-1,497 → -1,419 → -636 → positive 41 → positive 1,197) — shrinking then flipping; he calls this "selling drying up." (v41, [13:52])
- Mid-bar max/min delta vs. close delta: bar with mid-delta of -882 that closes at -41 = intrabar recovery; buying overwhelmed selling within the bar. (v41, [14:26]) NEEDS-OPERATIONALIZATION

---

## E. Absorption clues

- Negative delta on an up-closing bar = "supportive buying"; passive buyer absorbing aggressive sell-side flow at a low. (v40, [13:27], [14:22]) [REPEATED]
- Large volume at a price level that price cannot penetrate after multiple tests = absorption ("there's support there"; "a decent bid whether it's shown or Iceberg"). (v41, [09:20], [10:22])
- ~40,000 contracts traded in two bars at a swing low (ZF example) = clear absorption footprint ("that tells you hey there is support there, there are buyers"). (v41, [17:32], [18:05])
- After absorption at a level: when price returns, same-magnitude selling is absent = confirmation the level holds ("where's the aggressive sellers…they're not there"). (v41, [10:53])

---

## F. Stacked imbalance ideas

- Stacked imbalances are most effective at edges: VAH, VAL, HOD, LOD, swing highs/lows. Mid-value-area stacked imbalances are explicitly lower-tier: "you could have the best indicator in the world but if you're trading in an area of consolidation it's not going to be effective." (v40, [09:32]) [REPEATED]
- Overlapping stacked imbalances ("one right after the other") = "quite a very high percentage trade." (v40, [10:56]) [ONCE — new nuance on stacking density]
- He prefers stacked selling imbalance at a high over stacked buying imbalance at the same high. (v40, [22:37])
- Stacked imbalances with a ratio signal afterward = preferred combination. "I always say look for the stacked imbalances with the ratio afterwards." (v40, [33:00])
- Selling imbalance at the bottom of a bar at a low = watch for reversal higher (reversal signal, not continuation). (v39, [31:19]) [ONCE]
- Stack imbalance triggered by a stop = cascading, fast, directional move (what he was hoping for at 48.50 in crude). "This is what a stack imbalance triggered by a stop looks like." (v39, [33:38]) [ONCE]

---

## G. Delta / delta-divergence ideas

- Delta divergence (multiple failed divergences): three failed bearish divergences in a rally = trending market; "on a market that's going to trend higher you're going to have failed divergences on the upside." (v39, [37:12]) [REPEATED — confirming digest item]
- Delta Surge: indicator of expanding delta on slow/range-bound markets; signals that the market is about to make a directional move. Does NOT fire at same price levels as Delta Scalper. (v39, [09:09], [18:28])
- Delta Surge filter: for a buy signal, the signal bar must be a green (up-closing) candle; for a sell signal, must be red (down-closing). Red candle on a buy signal = "be afraid, be hesitant." (v39, [10:04], [16:23]) [REPEATED]
- Delta Surge vs. Delta Scalper: both read delta but "how they read delta is different"; you "very rarely ever get" both at the same price level; Delta Scalper finds supply/demand shifts at turns; Delta Surge finds delta building in slow markets. (v39, [18:28]) [ONCE — explicit distinction]
- Intrabar delta tracking: mid-bar max/min delta vs. closing delta reveals intrabar conviction; a bar that peaks at -882 but closes at -41 shows aggressive buy absorption intrabar. (v41, [14:26]) NEEDS-OPERATIONALIZATION
- "Strong" delta (already in digest: >25%); here he discusses the series: -1497 → -1419 → -636 → +41 → +1197 as a textbook declining-delta-into-low series. (v41, [13:52])
- Positive delta in the middle of a series of negative delta bars: "if it's a Delta Surge sell with negative deltas in the middle of a bunch of bars with all negative Deltas I'd expect the market to go lower" — one contrary bar in a trend does not flip the bias; must see the series reverse. (v39, [25:26], [26:03]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Stack imbalance triggered by a stop** (crude oil, 48.50): a stop-triggered cascade through a support level looks like a very fast, one-directional stack imbalance; this is what he was looking for at 48.50 but it appeared later at a lower level. (v39, [33:38]) [ONCE]
- **Breakout below support with no follow-through sellers**: crude oil breaks to new low, but no aggressive selling at the next level (no imbalances below, no large volume on offer) → "all the selling is gone"; reversal. (v41, [10:22], [10:53])
- **"Tried to trigger stops"**: he personally pokes at levels to trigger stops with a single lot; only takes one lot. (v39, [30:47]) [ONCE — confirms his style but no actionable rule]
- **O2 Setup failed by 2 ticks**: setup targets a single tick stop beyond the high; if market ticks through before moving, it's a stop-out; he immediately reassesses and finds the next signal. (v40, [18:35])

---

## I. Trapped-trader ideas

- Retail latecomers buying a high after a 25-tick move up → stuck when no more buying comes → become forced sellers → delta turns large negative. (v39, [20:23], [21:10]) [REPEATED]
- Aggressive buyers near a resistance level failing to break through → flip to sellers → accelerate selling ("these buyers turn sellers"). (v40, [32:03])
- Buying imbalances into a high (multiple bars), followed by selling imbalances, followed by selling imbalance → buyers trapped, selling accelerates. (v39, [21:10], [21:32])
- "I hate to use the term trapped traders but traders are stuck in a position — that's what it looks like." (v39, [21:32])

---

## J. Entry triggers (the exact "go" event)

- **Delta Surge buy entry**: bar closes green (higher than open) + delta is visibly expanding + price is near the low of the day structure (not after a big move up). (v39, [10:04], [27:01])
- **Delta declining into low → flip positive**: series of declining negative deltas culminating in a small positive delta bar; next bar also positive → entry signal. "If you're getting long in this bar where you have the delta surge and ratio." (v41, [14:55])
- **Stacked selling imbalance at high**: direct entry short at the formation of the stack at the high. (v40, [22:37])
- **O2 Setup**: entry short right around the high level after Divergence + Ratio forms; stop 1 tick above high. (v40, [18:14])
- **After level break with no follow-through**: aggressive selling absent at the next level down after a breakdown → buy as selling evaporates ("you see it's just a support level"). (v41, [10:53])
- **Ratio Bounds Low + Delta Scalper buy**: at swing low, Delta Scalper fires on a green bar. (v40, [08:33]; v41, [05:38])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Price should move in the signal direction immediately ("works immediately" — already in digest).
- For a Delta Surge buy: bar after entry should be green and positive delta; "if this bar was green…I would be a lot more interested in thinking this market can start to rally again." (v41, [06:36])
- For the declining-delta bottom: the bar after entry should have a larger positive delta than the entry bar (v41 example: +41 → +1,197). (v41, [14:55])
- Stacked buying imbalance at new highs shows momentum: aggressive buyers coming in as price breaks out = "that's what you want to see…it just looks better visually." (v41, [04:18]) [ONCE]
- For absorption at a level: on the next retest of the support level, price should reject quickly with even less selling volume than on the first test. (v41, [10:53])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Signal bar closes against the direction**: buy signal on a red (down-closing) candle is a major warning. "Be afraid, be hesitant." (v39, [16:23]) [REPEATED]
- **Buy signal after a large sustained move in the same direction**: signal is context-wrong; "you're getting a buy signal after a 25-tick move in the euro currency" — likely a blow-off, not a reversal low. (v39, [21:57])
- **Sell signal at a level where bearish confluence persisted but market refused to sell**: when "staring at something extremely negative and the market doesn't sell off," the bearish thesis must be abandoned. (v40, [23:34])
- **Positive delta bar in a downtrend doesn't stop the decline**: one positive delta bar in a series of negatives is not sufficient; selling must actually dry up across multiple bars. (v41, [06:36])
- **Delta Surge or Delta Scalper buy met immediately by a sell signal in the same area**: alternating buy/sell signals = quiet/directionless market, do not trade. (v40, [38:31])
- **Stop-out does not mean thesis is wrong**: O2 failed by 2 ticks but the next setup appeared "immediately right after." (v40, [18:35])

---

## M. Stop / risk / target / trade management

- O2 Setup: stop is 1 tick beyond the swing high. (v40, [18:14]) [REPEATED — confirms digest]
- Delta Surge context filter for stop: if taking a buy, entry should be near the low of the day; a 7-point day in ES, buying near 84, target up to 87 = "catching half the range." (v39, [27:26]) NEEDS-OPERATIONALIZATION
- Time stop: "by 3:00 you're not going to be looking to still be trading crude oil especially after how much activity there was earlier." (v40, [33:22]) NEEDS-OPERATIONALIZATION
- FOMC day: explicitly do not trade around the announcement; "you don't have to trade every single day." (v40, [40:05], [40:31])
- NFP and FOMC days: "days that I stay away from." (v40, [40:05])
- Targets are discretionary/range-based (confirmed again — "catching half the range"). (v39, [27:26])
- ZF (5-Year Note): "4 to 8 ticks on a move is good" for that contract. (v41, [19:57]) [ONCE — contract-specific target range, new data point]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Avoid first bars after the reopen** (beans at 8:30): stacked imbalance right at the open — "I still consider that part of the opening." (v40, [22:13]) [REPEATED]
- **Avoid FOMC announcement** (1:00 CT): explicitly do not trade around the announcement in any market. (v40, [11:23], [40:05])
- **Avoid NFP and FOMC days entirely**: "days that I stay away from." (v40, [40:05]) [REPEATED]
- **Avoid 7:30 CT signals on most markets** unless context is exceptional. (v40, [13:03]) [REPEATED]
- **Lunch hour (12:00–12:45 CT)**: "you're probably not interested in taking this trade." (v40, [20:46])
- **After 1:00 CT in crude**: "by 3:00 you're not going to be looking to still be trading crude." (v40, [33:22])
- **Japan/Asian holiday**: US bonds (ZB/ZF) extremely quiet when Japan and Hong Kong are closed; starts at ~3:00 AM CT; "you're better off just watching TV or something." (v40, [17:40]) [ONCE — specific nuance on Asia holiday effect on US bonds]
- **French election / weekend event risk**: avoid holding positions over the weekend before a major political event; positions going into the weekend before French election cited. (v39, [06:12]; v41, [00:59])
- **Asset class correlation**: if bonds, equities, and FX are all in tight ranges, the one market that appears to be moving may be a "false trap" — it will also become directionless. "Don't think all of a sudden I found the one market where things are moving." (v40, [37:09]) [ONCE]
- **Asian session volume**: ~10–20% of daily US market volume occurs during Asian session; not worth staying up for most instruments. (v40, [06:20]) [ONCE — gives rough percentage]
- **Charts open from 3:00 AM CT**: data collected from 3 AM; footprint charts are inaccurate on historical replay in NT7 if chart wasn't open during that session. (v40, [05:46]) [ONCE — implementation note]
- **"Unchanged" line**: already in digest.
- **Value area mid-range**: avoid signals in the middle of value; market structure context is the dominant filter. (v40, [09:02], [10:00]) [REPEATED]
- **After 11:00 CT in thin markets**: he did not watch markets after 11:00 on a low-volatility day (v41). Consistent with session 07:00–15:00 CT filter already in digest.

---

## O. Directly testable / measurable variables

- Delta Surge signal bar must close green (for buy) or red (for sell) — candle-direction alignment. [BINARY] (v39, [10:04])
- Delta Surge buy signal location: should be near the low of the day's price structure, not after a sustained directional move up. NEEDS-OPERATIONALIZATION for "near the low" (v39, [22:32])
- Stacked selling imbalance overlap: "one right after the other" (consecutive bar overlap) = "quite a very high percentage trade." NEEDS-OPERATIONALIZATION for overlap definition. (v40, [10:56])
- Delta declining across successive bars into a low (each bar's absolute net delta smaller than the prior bar) then flipping positive. [MEASURABLE] (v41, [13:52])
- Mid-bar max delta vs. closing delta disparity: bar with large intrabar negative delta that closes near zero or positive = absorption signal. NEEDS-OPERATIONALIZATION for threshold. (v41, [14:26])
- Multiple consecutive POCs (4 in a row) at a price level = significant market-generated support/resistance. (v40, [06:46]) [NEEDS-OPERATIONALIZATION for "multiple"]
- ~40,000 contracts in 2 bars at swing low (ZF) = heavy absorption. NEEDS-OPERATIONALIZATION (market-specific). (v41, [17:32])
- For ZF: 4–8 ticks target range on a typical move. (v41, [19:57])
- Session/time filters: avoid 7:30 CT; avoid open (first bars); avoid lunch (12:00–12:45 CT); avoid FOMC 1:00 CT; avoid NFP day; avoid crude after 3:00 PM CT. [BINARY]
- Asian session = ~10–20% of daily volume. NEEDS-OPERATIONALIZATION for threshold. (v40, [06:20])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **NT7 data limitation**: footprint chart data is only accurate from when the chart was opened; historical replay is inaccurate for data before the chart was opened. Charts should be opened by 3:00 AM CT at the latest. (v40, [04:10], [05:46])
- **Restart NT after indicator install**: "please restart NinjaTrader" — installation of any indicator requires restart before accurate data collection begins. (v39, [07:18])
- **Delta Surge indicator**: available for free on website; runs on NT7; reads delta and highlights momentum-building conditions in slow markets. (v39, [06:49], [10:54])
- **Delta Scalper indicator**: separate from Delta Surge; reads delta to find supply/demand shifts at turns; does not fire at same level as Delta Surge. (v39, [18:28])
- **Implication**: candle-direction filter for signals could be added directly in Pine/NT logic: "I could have programmed it in there to say only kick off buys when the bar closes higher than the open — I didn't put it in there." This is an explicit, actionable implementation improvement he chose not to make. (v39, [10:29]) [ONCE — clear NT logic hook]

---

## Q. Notable verbatim quotes

1. "Be afraid, be hesitant to do this trade" — re: taking a buy signal on a red (down-closing) candle. (v39, "May 2 2017", [16:23])

2. "You could have the best indicator in the world but if you're trading in an area of consolidation it's not going to be a very effective signal." (v40, "FOMC Day", [09:32])

3. "Sell me more, sell me more, I'm happy to buy down here — and eventually the sellers lose interest." — describing passive absorption at a swing low with negative delta on an up bar. (v40, "FOMC Day", [14:22])

4. "This is what a stack imbalance triggered by a stop looks like." — re: the fast cascade in crude oil after breaking 48.50. (v39, "May 2 2017", [33:38])

5. "When I'm staring at something extremely negative and the market doesn't sell off — that sort of gives me a sign that you know rethink what's going on here." (v40, "FOMC Day", [23:34])

6. "I could have programmed it in there to say only kick off buys when the bar closes higher than the open — I didn't put it in there — to me it was just a common sense thing." (v39, "May 2 2017", [10:29])

7. "Where's the aggressive sellers — where's the other traders coming in here to start selling — they're not there." — confirming reversal from a support level after a failed breakdown. (v41, "May 4 2017", [10:53])

8. "If you have to even think about it you know it's wrong — same is with trading — if you've got to sit there and try and justify taking this trade you should know by looking at the delta declining." (v41, "May 4 2017", [24:11])

9. "I'd rather trade when everyone talks about having an edge in the market — I'd rather trade under normal conditions where I have an edge rather than volatile conditions where the market is moving too fast to take advantage of it." (v40, "FOMC Day", [40:31])

---

## R. Contradictions / nuances

- **Delta Surge is NOT a green-light/red-light system** (reinforced): he explicitly states he did not code the candle-direction filter into the Delta Surge indicator even though he knows it would improve signal quality. The indicator fires without it; trader must apply the filter manually. This nuances the digest — the Delta Surge itself is not the full signal; candle direction is a *manual* overlay the trader must apply. (v39, [10:04], [10:29])

- **"Same settings every market" — minor nuance**: he says "same settings" for detection but then gives ZF-specific target range of 4–8 ticks and discusses that ZF is a "safer contract" with "not a lot of volatility" — implying that while detection parameters are consistent, risk/target context must be adapted per instrument. (v41, [19:57], [20:49])

- **One positive delta bar in a downtrend does NOT mean reversal**: "just because you have one bar with positive delta in a down move all of a sudden doesn't mean the entire move is over." Must see the *series* of declining delta across multiple bars. This nuances the digest's "delta weaken→flip" — the flip needs to be confirmed across consecutive bars, not just one. (v41, [06:36])

- **Failed bearish confluence = reassessment, not automatic buy**: when multiple bearish signals appear but the market does not sell off, that specific scenario is a warning to reassess (not an automatic buy signal). He watches and waits to see how price responds, not an entry trigger. (v40, [23:34])

- **Asset-class correlation filter**: if all markets are in tight ranges simultaneously, do not selectively trade the one that appears to be moving — it is likely also directionless. This is a cross-market context check not explicitly mentioned in the digest. (v40, [37:09])

- **FOMC Day = explicitly avoid trading**: stronger than general "avoid news" — he says "if there are certain days of the month not to be trading, FOMC days is one." He also states he does not watch markets on these days. This reinforces but slightly strengthens the existing digest entry on FOMC avoidance. (v40, [40:05])

---

## Coverage note

v39 is the richest of the three — detailed walkthrough of Delta Surge mechanics, candle-direction filter logic, trapped-trader psychology in euro, and stacked imbalance stop-triggered cascade in crude. v40 (FOMC day) is medium-value — useful on POC-stacking logic, absorption psychology, the "failed bearish confluence = reassess" nuance, and stacked imbalance edge-vs-mid-range distinction. v41 is thin overall but contains the most explicit delta-declining-into-low series with actual numbers (-1497 → -1419 → -636 → +41 → +1197), a notable mid-bar delta disparity example, and the ZF contract-specific 4–8 tick target range. Much of the content repeats established digest items (candle-direction, edge location, divergence in trends). One transcript section in v39 (first ~6 minutes) is preamble/political commentary with no model content.
