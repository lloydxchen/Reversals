# Chunk 012 Extraction
- Source chunk: Chunk_012_Orderflows_Transcripts.md
- Transcripts covered:
  - v395 — "Market Exhaustion With Orderflows Ratios Ratio Bounds High Price Exhaustion" (2023-09-22)
  - v396 — "Stopping Volume In The Order Flow Using Orderflows Trader" (2023-09-24)
  - v397 — "Stacked Imbalances In The Order Flow How To Trade Them With Orderflows Trader" (2023-09-25)
  - v398 — "Market Sweeps In Action How To Interpret The Order Flow Coming Into The Market Right Now" (2023-09-26)
  - v399 — "Stopping Volume Using Orderflows Trader For Gocharting" (2023-09-26)
  - v401 — "Order Flow That Can Determine When A Market Can Bounce Off Lows Using Orderflows Trader" (2023-09-27)
  - v406 — "I'm Back Reading Order Flow Delta Weakness and the Orderflows Algo" (2023-11-07)
  - v408 — "Exhaustion Prints In The Order Flow Using Orderflows Trader For NinjaTrader" (2024-02-05)
  - v413 — "Understanding Market Weakness In The Order Flow And How To Trade It With Orderflows Trader For NT8" (2024-02-10)
- Overall content value: **rich**

## A. Setup types & names he uses
- **Ratio + Divergence** ("ratio and Divergence") — his "bread and butter" setup; a new/equal swing-high (or low) where a ratio prints AND delta diverges. Bearish = new high + bearish ratio + negative delta; bullish = new/equal low + bullish ratio + positive delta (v395, "Ratio Bounds High", [07:16],[08:17],[11:31]; v406, "Delta Weakness", [09:43],[10:48]). [REPEATED]
- **Ratio Bounds High** = price exhaustion (number ≥30) (v395, [03:19]; v396, [02:37]; v399, [00:52]). [REPEATED]
- **Ratio Bounds Low** = price defense / stopping volume (number between ~0.75 and 0; default 0.69) (v396, [02:37]; v399, [03:32]). [REPEATED]
- **Exhaustion Print** (formerly "single print") — tiny volume (e.g., 1–3 contracts) at the edge of a bar showing last buyer/seller is done (v408, "Exhaustion Prints", [06:53],[10:35]). [REPEATED]
- **Stopping Volume** — heavy passive volume at a swing high/low that halts a move (v396; v399, [01:26]). [REPEATED]
- **Stacked Imbalance** (stacked buying / stacked selling imbalance) — 3+ imbalances stacked vertically (v397, "Stacked Imbalances", [02:30],[03:01]). [REPEATED]
- **Market Sweep / big order** — large aggressive order sweeping the book (v398, "Market Sweeps", [01:17]). [ONCE-in-chunk]
- **Market Weakness** (bullish weakness / bearish weakness) — aggressive buying OR selling weakening into a swing (v413, "Market Weakness", [01:23],[03:29]). [ONCE-in-chunk]
- **Delta weakness / "rally that gives it all back in two bars"** — repeated little rallies whose positive delta is erased within ~2 bars (v406, [02:46],[06:47]). [REPEATED within video]
- **Absorption (bullish prominent POC)** — negative delta on a green candle = passive buyers absorbing aggressive selling (v401, [16:05]). [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
- **"A+ setup"** — used skeptically/mockingly toward funded-program traders ("why aren't you just taking your a plus setups to begin with... I don't know why you all of a sudden think you're some Master Trader") (v395, [07:16]). He does NOT give a crisp A+ checklist here; the implied premium setup is Ratio+Divergence.
- **"one of my bread and butter setups"** = Ratio + Divergence (v395, [07:16]). [REPEATED concept]
- **"this is one of my favorite trades to take... the bullish Divergence"** — new/equal low + positive delta + bullish ratio (v406, [09:43]). Also "people ask me what's my favorite trade... I don't have one favorite trade I have sort of a handful" (v406, [10:18]).
- **"one of my uh original and favorite trade setups"** = exhaustion prints (v408, [00:01],[16:15]). [REPEATED]
- **"those are great opportunities"** — stacked imbalances that are NOT retested into in the next bar (v397, [12:21]). [ONCE]
- **"I just find those to be the strongest uh potential trading opportunities"** — the Divergence (gold) + ratio combo vs ratio alone (v395, [10:00]). [ONCE]
- Quality DOWN-graders (verbatim): "this is not a great move" (v397, [13:20]); "that's not a good effective trade" / "not be a very effective trade" when it goes sideways after entry (v398, [06:10],[12:03]); "the kiss of death" / "kiss the dot" = the bar after your signal bar goes **inside** (v401, [11:26],[13:41]); "half-hearted move" / "half parted rally" = weak follow-through (v398, [04:39]; v406, [03:15]); "marginal at best" = a delta decline of only ~7 contracts (v406, [06:12]).
- Confidence UP-grader: **"Confluence"** — exhaustion print + market weakness + bullish ratio stacking ("three things going here... should give you a little bit more confidence") (v413, [11:01],[11:37]). He cautions he does NOT trade purely on "three up triangles" (v413, [11:37]).
- Tier distinction (Ratio+Div): a 406 ratio is treated **identically** to a 32 ratio — only thing that matters is it's over threshold 30 / colored (v395, [09:23],[09:23]). NEEDS-OPERATIONALIZATION (binary, not graded by magnitude).
- What moves a stacked imbalance UP a tier: continuation/follow-through in next bar + staying on correct side of zone; what moves it DOWN: immediate trade-back-through and close on the wrong side (v397, [04:27],[08:57]).

## C. Order-flow story & psychology per setup
- **Exhaustion print:** "moves up end when the last buyer has bought, moves down when the last seller has sold." Buyers lose interest at higher prices; after trying to push above a level 5-6-7 times, the 7th attempt prints only 1-2 contracts = no one left to buy → breaks (v408, [02:45],[06:24]). [REPEATED]
- **Ratio Bounds High exhaustion:** at a swing high, the ratio of volume at the top of a red candle (offer side) reveals exhaustion even when raw volumes "just look like normal order flow" (v395, [01:52],[05:44]). [REPEATED]
- **Stopping volume / Ratio Bounds Low:** passive buyers step in at a swing low and "say we're not going to let this price go any lower" and defend it; expect a rally (v396, [13:11]; v399, [07:32]). [REPEATED]
- **Stacked imbalance:** caused by a big order sweeping, or a stop getting triggered (e.g., selling imbalance starting just below a swing low at 4310 under a 4320 low → stops) (v397, [03:34]). It is a sign of strong aggressive buying/selling but needs follow-through "impetus" or the big buyer is "done" (v397, [03:59],[04:53]).
- **Market sweep:** the "great white shark" (big trader) vs "little fish" (dome/heatmap traders jumping in front to pick up scraps). If a 2,500-lot sweep buys and there's zero follow-through and price trades back through the sweep origin, the buyer is gone → fade it / expect continuation the other way (v398, [02:16],[03:07],[07:46]). [REPEATED]
- **Bounce at lows:** coming into a low you expect strong negative delta; the tell is when aggressive selling DRIES UP at the low (deltas shrink / flip positive) while cumulative delta actually rises — sellers exhausted, profit-takers (shorts covering) (v401, [04:47],[07:27]). "reversals start as bounces first before they become reversals" (v401, [10:53]). [REPEATED]
- **Delta weakness (rally-fades-in-two-bars):** every little rally's positive delta momentum is "given all right back within two bars" → buyers can't sustain → sell the little rallies (v406, [02:46],[06:47]). [REPEATED within video]
- **Absorption:** negative delta on a GREEN candle at the low = aggressive sellers being absorbed by strong passive buyers (bullish prominent POC) → be positioned for the bounce (v401, [16:05],[16:37]). [ONCE]

## D. Exhaustion clues
- Ratio Bounds High ≥30 (colored red at top of red candle / blue at bottom of green candle) at a swing high/low = price exhaustion (v395, [03:19],[04:13]). [REPEATED]
- Exhaustion print: tiny volume (1, 2, or 3 contracts) at the bar edge where you'd expect normal 100-200 (v408, [05:47],[06:24]). [REPEATED]
- "moves up end when the last buyer has bought; moves down when the last seller has sold" — can also occur mid-move, not only at extremes (v408, [02:45],[03:13]). [ONCE]
- Watch the EDGES of bars: top of red candles, bottom of green candles — where reversal/last trade shows (v408, [04:21],[16:15]). [REPEATED]
- Magnitude of ratio is irrelevant once over threshold (406 = 32) (v395, [09:23]). [ONCE]

## E. Absorption clues
- Negative delta on a green (up) candle = passive buyers absorbing aggressive selling = "absorption taking place" → bullish prominent POC (magenta line) (v401, [16:05],[16:37]). [ONCE]
- Stopping volume itself is absorption-adjacent: heavy passive bid volume at a low absorbing sellers and halting the move (v399, [01:26],[13:11]). [REPEATED]

## F. Stacked imbalance ideas
- Definition: **3 or more imbalances stacked neatly on top of each other** (cluster size default 3; can set 4 or 5 to be stricter) (v397, [02:30],[03:01],[05:51]). [REPEATED]
- Imbalance = aggressive buying vs aggressive selling diagonal ratio (red number = selling imbalance, blue = buying imbalance) (v397, [00:54]).
- **Minimum imbalance volume** setting (default 10 contracts on heavier side) — "more meat on the bones"; filters thin-market noise like 0-vs-5/6/7 on MNQ/NQ/YM in evenings (v397, [01:25],[02:30]). [ONCE — explicit number 10]
- "imbalance trigger in percent" is the other setting (v397, [01:25]). NEEDS-OPERATIONALIZATION (no % stated).
- Don't pile in immediately — need **follow-through / continuation** in next bar(s); a stacked buying imbalance you buy can "come right back down and stop you out" (v397, [04:27],[04:53]). [REPEATED]
- Three zone-drawing modes: (1) in-bar only (fixed zone size = 1), (2) **until tested**, (3) **fixed 5-bar zone** (he uses 5 because trading back into an imbalance within ~5 bars is "normal"; entry = limit in middle of zone, exit = close on the WRONG side of zone) (v397, [05:22],[08:01],[08:32]).
- Best stacked imbalances: those **NOT retested** in the next bar (go with the move) (v397, [12:21],[14:21]). [REPEATED]
- A stacked buying imbalance immediately followed by a stacked selling imbalance "neutralize each other" (v397, [10:52]). [ONCE]

## G. Delta / delta-divergence ideas
- **Divergence** core to his favorite trade: new/equal swing high with NEGATIVE delta (bearish) or new/equal swing low with POSITIVE delta (bullish) (v395, [08:17]; v406, [09:43]). [REPEATED]
- Delta numbers cited descriptively (e.g., minus 1600, minus 1200 into low, then plus 453 / plus 286 as selling dries) — qualitative pattern: strong selling INTO the low then delta shrinks/flips at the low (v401, [04:47],[05:27]). NEEDS-OPERATIONALIZATION.
- **Cumulative delta rising while price holds the low** = sellers exhausted / shorts covering = bounce signal (v401, [06:06],[07:27]). [REPEATED]
- Caution: cumulative delta gaining back negative on just 1-2 bars where price DOESN'T trade higher = likely just profit-taking, NOT a real reversal (v401, [12:34],[13:11]). [ONCE]
- **Declining delta on a rising move** = weakness — but he flags that a decline of only ~7 contracts (421→414) is "marginal at best," technically declining but tiny (v406, [05:35],[06:12]). NEEDS-OPERATIONALIZATION (he refuses to call 7 contracts meaningful). [ONCE]
- **Rally gives back its positive delta within ~2 bars** = no buying power → fade the rallies (v406, [02:46],[06:47]). [REPEATED within video]
- Min Delta / Max Delta close colors: bar closing on its Min Delta = magenta; closing near Max Delta noted as bullish (v401, [08:34],[09:12]). [ONCE]
- Bullish/bearish VALUE AREA color (green/blue value area = very bullish) reinforces divergence (v401, [09:45]). [ONCE]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Market sweep with zero follow-through** = failed; "Market didn't go any higher than this bar and in fact in the next bar we trade back down into where the sweep took place" → reverses (v398, [02:38],[03:07]). [REPEATED concept]
- Test of whether a sweep level holds: after a big buy at a level, if price trades BELOW and closes below it, "where is my strong buyer, it's not there anymore... we'll probably keep selling off" (v398, [07:14],[07:46]). [REPEATED]
- Removed supply/demand: "if I know that where I had Supply earlier is removed from the market I'm going to look for the market to go higher" (v398, [07:46]). [ONCE]
- Stacked imbalance can be a triggered stop run just below a swing low (v397, [03:34]). [ONCE]
- Failed bounce: little positive delta at low, then next bar goes INSIDE + negative delta returns → bounce won't happen, new lows (v401, [11:26]). [ONCE]
- Exhaustion print at top after price fails above a level repeatedly (5-7 tries) = failed breakout → 10-point break (v408, [06:24],[06:53]). [ONCE]

## I. Trapped-trader ideas
- Dome/heatmap traders ("little fish") who jump in front of a sweep get trapped when there's no follow-through (v398, [02:16],[03:07]). [ONCE]
- Liquidity / triple-top: "obviously there's probably some liquidity right here because you sort of got this one two... triple top" (resting stops above equal highs) (v396, [07:08]). [ONCE]
- Shorts booking profits at new lows create the misleading positive-delta gain-back (not new longs) (v401, [13:11]). [ONCE]
- (No explicit "trapped longs must puke" language in this chunk beyond the sweep-fade story.)

## J. Entry triggers (the exact "go" event)
- **Ratio + Divergence trigger:** "to me that's an automatic trade **as long as the next bar starts trading higher**" (bullish) (v395, [11:58]). [REPEATED — this is the cleanest explicit trigger]
- Bearish version: short below the low of the divergence bar once market confirms direction (v395, [14:57]).
- **Stacked imbalance entry:** drop a limit order in the **middle of the imbalance zone**, but only AFTER market starts moving in your direction / opens on the correct side of the zone — don't get long immediately in the next bar (v397, [08:57],[09:48],[12:51]). [REPEATED]
- If a stacked imbalance is NOT retested → go WITH the move (momentum entry) rather than waiting for a pullback (v397, [14:21]). [ONCE]
- **Sweep/level entry:** want to see the bar AFTER the level "moving away from it," next bar trading above (for support) — not trading back through (v398, [06:44],[11:37]). [REPEATED]
- **Delta-weakness entry:** sell into the little rallies once positive delta is failing ("you could probably sell that in here... maybe these are opportunities for me to sell") (v406, [07:28],[07:59]). [REPEATED within video]
- General: "it's not about trying to predict the low, it's just reacting to what you're seeing in the order flow" (v396, [13:11]). [REPEATED theme]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Next bar must trade in your direction** — the single most repeated confirmation (v395, [11:58]; v398, [06:44]). [REPEATED]
- For a sweep/level: subsequent bars stay on the correct side and the level "holds" (v398, [05:06],[11:37]). [REPEATED]
- For stacked imbalance: continuation imbalances appear in the next bar, price stays away from / on correct side of the zone (v397, [06:23],[06:57]). [REPEATED]
- Move should happen QUICKLY: "when I see a big order... I'm really looking for this Market to make its move quickly" (v398, [03:39]). [ONCE]
- Reassurance (not a fresh entry): a Ratio Bounds Low / price-support print appearing in the direction of your existing trade = confirmation to stay (v395, [10:27]). [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- **The next bar goes INSIDE the signal bar** — "the kiss of death," "I hate getting into a trade and seeing the next bar go inside of the bar that I liked a lot" (v401, [13:41],[14:16]; v398, [12:29],[13:00]). [REPEATED]
- Goes sideways after entry = ineffective; cut it (v398, [05:39],[06:10],[12:03]). [REPEATED]
- Sweep/level: price closes on the OTHER side of the level → strong buyer/seller is gone, thesis dead (v398, [07:14],[08:47]). [REPEATED]
- Stacked imbalance: closing on the wrong side of the zone = "your sign to get out" (v397, [08:57],[09:22]). [REPEATED]
- Ratio+Divergence: if market comes down and takes out the ratio/divergence, "there's no need to be long" (v395, [12:32]). [REPEATED]
- Bounce thesis: strong selling persists / cumulative delta keeps falling and price can't exceed the signal bar = no bounce (v401, [12:34],[13:41]). [ONCE]
- Stopping volume / exhaustion in a SIDEWAYS market (no move to stop/exhaust) = invalid context (v396, [05:23],[06:38]; v399, [03:32],[06:29]). [REPEATED]

## M. Stop / risk / target / trade management
- **Stop placement = just beyond the structure that triggered the trade:** "your stop is right below where the ratio is coming in, a tick or two lower" (v395, [12:32]); short stop "just behind this High 96 and a quarter / 96 and a half" (v395, [14:57]). [REPEATED]
- Example risk: long ~65.5, stop ~62.5 = "three points," move made +5 to ~70s then continued to 85 (v395, [13:03]). NEEDS-OPERATIONALIZATION (example, not a rule).
- **Stacked imbalance = very tight stop just on the other side of the zone, "three four ticks away" / "three ticks"** → "low risk entries... literally just risking three ticks" (v397, [09:22],[09:48],[13:51]). Cites "two to one risk... risking three to maybe get six nine twelve" (v397, [10:22]). [REPEATED — explicit ticks]
- "that's how you keep your losses small" — get stopped, wait for next opportunity (v397, [13:51]). [REPEATED]
- **Time-stop / hold-time matched to chart timeframe:** on a 1-min chart don't hold a 2-hour trade; intraday short-term ideally exit within "15 20 minutes maybe 30 minutes," don't hold 10am short until 1-2pm (v395, [15:23],[15:52]). [ONCE — explicit minutes]
- "take what the Market's going to give you because you're a short-term intraday Trader" (v395, [15:52]). [REPEATED theme]
- Targets framed by bounce magnitude (e.g., ~10-point bounces in SPS) but kept qualitative; "look for the bounce first" then let it build into a reversal (v401, [00:26],[10:53]). NEEDS-OPERATIONALIZATION.
- Supply/demand zone management: add on pullbacks into the zone; "if this Market comes down to this level I'm out" (v406, [17:36],[18:06]). [ONCE]

## N. Context filters (session/time, regime/volatility, levels)
- **Look for ratios/exhaustion/stopping volume ONLY at swing highs / swing lows** (bullish at lows, bearish at highs), NOT mid-congestion (v395, [05:44],[07:16]; v396, [05:23]; v413, [04:35],[04:57]). [REPEATED — central filter]
- Markets that follow order flow best = low retail participation / supply-demand driven: **Ultra Tens (TN), Ultra Bonds (UB)** "blow all these other markets out of the water"; vs heavy-retail NASDAQ/MNQ/NQ which "jump around" (v406, [14:57],[15:28]; v413, [06:02]). [REPEATED]
- Commodities (grains/soybeans) trade differently — physically settled, less speculative; lighter overnight volume; **trade grains during the day session (reopen 8:30 after overnight close ~7:40)** (v396, [08:14],[09:29]). [ONCE]
- Equity indices cash open (8:30 CT) produces big delta numbers — discount the first few bars; "Monday morning... going to do what it's going to do" (v406, [01:43],[04:23]). [ONCE]
- Prefer trading **during US hours** (v413, [07:37]). [ONCE]
- Thin/evening markets (MNQ/NQ/YM at night) generate junk imbalances → use minimum-volume filter (v397, [02:30]). [ONCE]
- Match trade hold time to chart timeframe (see M) (v395, [15:23]). [REPEATED]
- Levels referenced: prior swing high/low, low of day / high of day, point of control (prominent POC), value area, support/resistance from prior sweep/weakness zones (v398; v401; v413, [04:00]). [REPEATED]
- Note: stopping volume does NOT have to coincide with POC ("often it doesn't... the point of control doesn't necessarily have to be down there") (v396, [11:40]; v399, [05:59]). [REPEATED]

## O. Directly testable / measurable variables
- **Ratio Bounds High threshold = ≥ 30** → price exhaustion (he previously used 25) (v395, [03:19],[03:46]). [REPEATED — explicit number]
- **Ratio Bounds Low threshold ≈ 0.69 default, prefers ~0.75, range ~0.75→0, never negative** (some copy at 0.69, others use 1.0) → stopping volume / price defense (v395, [03:19]; v396, [02:37],[03:14]; v399, [03:32]). [REPEATED — explicit numbers]
- Ratio magnitude above threshold is NOT graded (406 treated == 32) → implement as binary flag, not weighted (v395, [09:23]). [ONCE]
- **Stacked imbalance = ≥ 3 imbalances stacked vertically** (cluster size; configurable 3/4/5) (v397, [03:01],[05:51]). [REPEATED — explicit number]
- **Minimum imbalance volume = 10 contracts** on heavier side (default) (v397, [01:25],[02:00]). [ONCE — explicit number]
- **Imbalance trigger percent** exists but no % value given here — NEEDS-OPERATIONALIZATION (v397, [01:25]).
- **Exhaustion print level = 3** (his preference; some use 1, some use 9 or 10; he uses 9 on treasuries/Ultra Bonds) (v408, [11:05],[15:11]; v413, [09:56]). [REPEATED — explicit numbers]
- **Entry confirmation = next bar trades in trade direction** (binary, testable) (v395, [11:58]). [REPEATED]
- **Invalidation = next bar is an INSIDE bar** (binary, testable) (v401, [13:41]). [REPEATED]
- **Stacked-imbalance stop = ~3-4 ticks** beyond zone (v397, [09:48],[13:51]). [REPEATED — explicit]
- **Hold-time cap (short-term/1-min) ≈ 15-30 minutes** (v395, [15:52]). [ONCE — explicit]
- Sweep size examples ~2,500 contracts, smaller ~1,000 — descriptive, market-specific, NEEDS-OPERATIONALIZATION (v398, [01:49],[09:15]).
- Delta values (e.g., -1600, +453, declines of "7 contracts") — explicitly market/bar dependent; he refuses to treat 7-contract decline as significant → keep qualitative, NEEDS-OPERATIONALIZATION (v406, [06:12]; v401, [04:47]).
- Cumulative-delta-rising-into-held-low = bounce signal — directional, testable qualitatively (v401, [07:27]). NEEDS-OPERATIONALIZATION (no fixed amount).
- "Big bid vs small offer" asymmetry (e.g., 1000 bid vs 162 offer would matter; 1000 vs 1000 = normal) → testable bid/offer ratio at level (v398, [10:20]). [ONCE]

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Orderflows Trader (NT8, "version 8.1.2.0") with toggleable detectors, each color-coded and drawable **fixed** or **until tested** (zone drawn from bar until price returns) (v408, [10:35],[11:05]; v413, [01:58],[02:31]). [REPEATED]
- **Order Flows Ratios** numbers above/below bars: black = normal; red = bearish ratio (at top of red candle); blue = bullish ratio (at bottom of green candle); on GoCharting only prints when within threshold (NT prints all) (v395, [01:52]; v399, [02:26]). [REPEATED]
- **Exhaustion Print detector:** configurable level (1/3/9/10), green up-triangle below bar (bullish) / red down-triangle above (bearish), highlight for multi-market scanning (v408, [11:05],[11:35],[12:06]). [REPEATED]
- **Stacked Imbalance detector:** cluster size (3+), minimum imbalance volume (10), imbalance trigger %, zone modes (in-bar=fixed size 1 / until tested / fixed 5-bar) (v397, [01:25],[05:22],[08:01]). [REPEATED]
- **Market Weakness Detector:** bullish (blue-violet) / bearish (dark orange) zones, adjustable opacity + zone size, fixed or until-tested (v413, [01:58],[02:31],[08:08]). [ONCE]
- **Market Sweep detector** mentioned in settings list (v413, [06:33]). [ONCE]
- **Color-blending for confluence:** when multiple detectors fire on one bar the triangle/zone colors mix (e.g., green exhaustion + dark-violet weakness = gray); he reads the combined color as confluence rather than memorizing combos (v413, [10:30],[11:01]). [ONCE — strong implementation cue]
- **Bullish/bearish value area shading** (green/blue value area) and **prominent POC** (magenta line) as separate visual cues (v401, [09:45],[16:37]). [ONCE]
- "Orderflows Algo" in development — deals with supply/demand + which swing highs/lows are **tradable** ("not all swing highs and swing lows are going to be tradable... find the best ones") (v406, [13:09],[13:48]). [ONCE — directly aligned with the A+ "best swings" goal]
- Min/Max Delta close coloring (magenta when closing on Min Delta) (v401, [08:34]). [ONCE]
- Available on GoCharting too; difference noted (threshold-only printing) (v399, [00:52],[02:26]). [ONCE]
- Footprint > DOM/heatmap because footprint = committed traded volume; resting depth gets pulled and a sweep "won't show up as liquidity" because it's current not resting (v398, [13:30],[15:38]; v408, [07:26],[08:31]). [REPEATED]

## Q. Notable verbatim quotes (3–10, each with citation)
- "moves up... end when the last buyer has bought... moves down and when the last seller has sold." (v408, "Exhaustion Prints", [03:13]) — core exhaustion thesis.
- "the ratio the bullish ratio and the Divergence right the gold and the blue to me that's an automatic trade as long as the next bar starts trading higher." (v395, "Ratio Bounds High", [11:58]) — cleanest entry rule.
- "these ratios these thresholds are not set in stone... I used to use 25 for Price exhaustion... I've just sort of honed it in based on my own trading and the markets that I trade." (v395, [03:46]) — thresholds are adaptive, not sacred.
- "reversals start as bounces first before they become reversals." (v401, "Bounce Off Lows", [10:53]) — sequencing of reversal trades.
- "if it's not pulling back into that stacked imbalance that could be your sign you want to go with that move." (v397, "Stacked Imbalances", [14:21]) — not-retested = momentum go.
- "where is my strong buyer it's not there anymore... what do I think is going to happen we're probably going to keep selling off." (v398, "Market Sweeps", [07:14]) — sweep-fade logic.
- "I hate getting into a trade and seeing the next bar go inside of the bar that I liked a lot... that's like the kiss of death." (v401, [13:41]) — inside-bar invalidation.
- "this is one of my favorite trades to take this is the bullish Divergence right the new equal low with positive Delta and a bullish ratio." (v406, "Delta Weakness", [09:43]) — names the premium bullish setup precisely.
- "when you have this Confluence... an exhaustion print to me that's bullish information I can trade off of as opposed to just a normal exhaustion print." (v413, "Market Weakness", [11:37]) — confluence upgrades a signal.
- "it's not about trying to predict the low it's just reacting to what you're seeing in the order flow." (v396, "Stopping Volume", [13:11]) — reactive, not predictive, philosophy.

## R. Contradictions / nuances
- **Ratio magnitude doesn't matter once over threshold** (406 == 32) — contradicts intuition that bigger ratio = stronger signal (v395, [09:23]). [ONCE]
- **Thresholds are flexible/personal** (30 vs old 25; 0.69 vs 0.75 vs 1.0) and partly set to 0.69 just to catch software copycats — so the exact numbers are NOT gospel (v395, [03:46]; v396, [03:14]). Implementation caution.
- **Stopping volume / exhaustion is context-dependent:** identical ratio prints are meaningless in sideways markets ("there's no move to stop"); only valid after a move into a swing high/low (v396, [05:23]; v399, [06:29]). [REPEATED]
- **Stopping volume ≠ POC:** "a lot of times you would think that's where the point of control is going to come in but often it doesn't" (v396, [11:40]). Contradicts common volume-profile assumption.
- **Rising cumulative delta is NOT automatically bullish:** if the gain comes on 1-2 bars where price can't make a higher high, it's likely just short profit-taking, not a reversal (v401, [12:34]). [ONCE]
- **A tiny delta decline (7 contracts) is "marginal at best"** — he explicitly refuses to operationalize small numbers as meaningful, warning against forcing precision (v406, [06:12]). [ONCE]
- **"Market weakness" is directional, not absolute:** bullish weakness = SELLING weakening (not "market is weak so must drop") (v413, [01:23],[13:37]). Counterintuitive naming. [REPEATED within video]
- **Heatmap/DOM skepticism + concession:** big resting bids/offers "get pulled," sweeps don't show as liquidity → footprint preferred; yet he concedes heatmap/book map has "very practical uses," especially resting orders in the night session (v398, [13:30],[16:13]; v408, [08:31]). [ONCE]
- **A+ language is used sarcastically** toward traders who claim to "only take A+ setups" — he implies most aren't disciplined/skilled enough to define them; he reframes his edge as a HANDFUL of favored setups, not one perfect setup (v395, [07:16]; v406, [10:18]). Nuance for the "A+ reversal" goal: the model is a small menu (Ratio+Divergence, exhaustion print, stopping volume, stacked-imbalance-not-retested, sweep-fade, delta-weakness, market-weakness-confluence), graded mainly by CONTEXT (swing high/low), FOLLOW-THROUGH (next bar, no inside bar), and CONFLUENCE (multiple detectors on one bar).
- **Order flow does NOT call every turn:** "markets don't exist for people to read the order flow"; most flow is "just normal Market activity" — only occasionally a clear "moment of brilliance" (soccer analogy) (v399, [08:05],[09:03]; v401, [02:19]). Tempers any all-signal indicator design. [REPEATED]
- **Market selection matters more than setup:** order flow / supply-demand works far better on low-retail instruments (TN, UB) than NASDAQ/MNQ — same setup, different reliability (v406, [15:28]; v413, [06:02]). [REPEATED]

## Coverage note
All 9 transcripts were rich and on-topic (T1). Densest model content: v395 (Ratio+Divergence, the closest thing to an explicit entry rule + stop), v397 (stacked-imbalance mechanics, tightest numeric stop rules), v401 (delta-exhaustion-at-lows + absorption), v406 (favorite bullish-divergence setup + delta-weakness fade + market-selection), v413 (confluence/color-blending). v398 (sweep-fade) and v408 (exhaustion prints) are strong on psychology and invalidation (inside bar). v396/v399 overlap heavily on stopping volume (good for [REPEATED] confirmation). Nothing unparseable. Main caveat: most delta numbers are illustrative per-bar/per-market values, not thresholds — kept qualitative and marked NEEDS-OPERATIONALIZATION.
