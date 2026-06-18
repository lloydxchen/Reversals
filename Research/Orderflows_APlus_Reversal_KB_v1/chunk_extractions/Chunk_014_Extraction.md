# Chunk 014 Extraction
- Source chunk: Chunk_014_Orderflows_Transcripts.md
- Transcripts covered:
  - v437 — Delta Price Action Divergence On Orderflows Trader 7 For NinjaTrader 8 (2024-09-04)
  - v438 — All About The Orderflows Show Hand (2024-11-12)
  - v440 — Imbalance Reversals In The Footprint Chart An Easy Way To Trade Order Flow (2025-01-08)
  - v441 — Benefits Of Exhaustion Prints In The Order Flow Using Orderflows Trader (2025-01-09)
  - v444 — Order Flow Imbalance Strategy Using Orderflows Trader (2025-01-11)
  - v445 — Delta Reversals & Exhaustion Prints Master Order Flow Analysis (2025-01-14)
  - v446 — Imbalance Trading Strategy In The Order Flow Using Orderflows Trader (2025-01-16)
- Overall content value: **rich** (v438 is a long product webinar, heavy on tool-settings/NEEDS-OPERATIONALIZATION; v440/441/444/445/446 are dense, concrete reversal-model teaching)

## A. Setup types & names he uses
- **Price Action Divergence** (a "Delta anomaly"): green candle with negative Delta (or red candle with positive Delta). Bullish version = green candle / negative Delta absorbed; bearish = inverse. Has both "regular divergence" (reversal) and "hidden divergence" (continuation) sub-types (v437, "Delta Price Action Divergence", [00:25],[00:57]) [REPEATED]
- **Imbalance Reversal**: market moves too fast in too short a time, becomes overextended, then short-term reverses. Bullish = selling imbalances near the BOTTOM of a green candle after a down-move; bearish = buying imbalances near the TOP of a red candle after an up-move (v440, "Imbalance Reversals", [01:13],[02:37],[04:51]) [REPEATED]
- **Exhaustion Prints** (formerly "single prints"): thin/low volume at the edge of a bar (top of red bar / bottom of green bar). Used for reversals AND continuation (v441, "Benefits Of Exhaustion Prints", [05:09],[06:27],[08:26]) [REPEATED]
- **Stacked Imbalance** (3+ imbalances neatly stacked over consecutive price levels): bullish = stacked buying imbalance (support); bearish = stacked selling imbalance (resistance) (v444, "Order Flow Imbalance Strategy", [02:55],[04:27]) [REPEATED]
- **Multiple Imbalances** (in one bar but NOT stacked / spread out): same importance as stacked, "probably more important because people aren't looking for them" (v444, [09:54]; v446 [02:30]) [REPEATED]
- **Imbalance Reload** (horizontal imbalances): same-direction aggressive imbalance recurring at the SAME price level over 2 consecutive bars = "consistent selling/buying" / reloading (v446, "Imbalance Trading Strategy", [03:30],[04:07],[05:13]) [ONCE-as-named-tool]
- **Delta Divergence / Delta Reversal**: aggressive selling appearing at a high (after up-move) or aggressive buying appearing at a low (after down-move) = potential reversal (v445, "Delta Reversals & Exhaustion Prints", [01:33],[01:59]) [REPEATED]
- **Show Hand**: indicator detecting institutional/large-order activity from order flow (volume disparity vs surrounding volume); plots bullish/bearish signals + zones (v438, "Show Hand", [00:31],[03:46]) [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
- Imbalance reversal called **"a great little setup"** and **"a nice little short-term reversal"** (v440, [04:51],[01:13]) [ONCE]
- Combining Delta Divergence + Exhaustion Print called **"quite powerful"** and **"a pretty strong trade setup"**; standalone produces **"very nice trading opportunities"** (v445, [03:28],[13:03],[04:00]) [REPEATED]
- Exhaustion print should **"jump off the page"** if at a swing high/low — i.e. the cleanest ones are visually obvious (v441, [12:47],[13:12]) [REPEATED]
- **Tier-mover (quality up):** the setup occurs at a meaningful LEVEL or EXTREME — "low of the day," "high of the day," new highs/new lows, value-area high/low, prior support/resistance — not just any swing (v441, [12:18],[11:46]; v440 [09:23]) [REPEATED]
- **Tier-mover (quality up):** a real MOVE must have preceded the signal. "Imbalance reversal, it's not called the imbalance momentum" — a 2-tick wiggle does NOT qualify; you need an actual prior run to reverse (v440, [09:23],[09:48],[07:49]) [REPEATED]
- **Tier-mover (quality down):** signals NOT on a swing → noise; he uses the swing filter to discard them ("that's why this buy is gone") (v440, [08:26],[09:48]; v445 [05:29]) [REPEATED]
- **Tier-mover (quality down):** for stacked-imbalance/zone setups, **"the longer the zone is the less important it is"** — too much elapsed time (his example ~20+ min) and the generated support **"already worn off"** (v444, [11:31],[06:23]) [ONCE]
- **Tier-mover (quality up):** exhaustion/imbalance volume must be LEGITIMATE, not a 1-contract fluke — he checks surrounding bar volume to confirm (v441, [09:55] "9,000 is legitimate… not one contract on 150"; v440 [06:47] min reversal volume = 10) [REPEATED]
- **Show Hand confirmation filter "trade entry signal"** described as keeping him **"out of bad trades"** / "out of these areas where the market doesn't follow through"; trades you want are **"explosive"** (v438, [17:22],[22:27],[23:02]) [REPEATED]
- Negation of common belief — declines to over-grade trapped-trader setups: refuses to call light-volume imbalances real trap setups (see R) (v444, [13:06]) [ONCE]
- NOTE: No literal "A+", "my favorite", "textbook", "perfect", "mediocre", "marginal" tokens appear in this chunk.

## C. Order-flow story & psychology per setup
- **Imbalance reversal (bullish):** market drops into liquidity; the LAST sellers sell (selling imbalances at bottom of a green candle) while aggressive selling dries up → no sellers left → aggressive buying takes over and reverses up (v440, [02:37],[03:45]) [REPEATED]
- **Imbalance reversal (bearish):** traders "very optimistic" they'll take out the high, buying imbalances near top of a red candle, but buying is "gone" within a couple ticks of the high → reversal down (v440, [04:51],[05:19]) [REPEATED]
- **Price Action Divergence / absorption story:** strong aggressive selling (large negative Delta) hits a bar but price does NOT drop → someone is absorbing it; a passive buyer "stepping up to the plate… not on my watch, this market's not going to go lower"; once the burst of aggressive selling stops, aggressive buying takes over and price goes to new highs (v437, [06:33],[07:50],[08:23]) [REPEATED]
- **Exhaustion print:** "the last buyer has bought" (at a high) / "the last seller has sold" (at a low) → traders no longer interested in transacting at that price (v441, [03:37]; v445 [03:28]) [REPEATED]
- **Delta Divergence caution:** a green candle / positive Delta at a low can just be SHORTS covering (profit-taking), after which the market simply continues down — psychology of who's exiting matters (v445, [02:28],[02:56]) [REPEATED]
- **Imbalance reload psychology (from his institutional past):** a big trader gets aggressive, others pile on the bandwagon, so he backs off, lets the market calm, then re-hits the SAME level to fill the rest of his order — producing repeated same-price imbalances (v446, [10:20],[10:44]) [ONCE]
- **Multiple imbalances (failure-to-move) story:** aggressive buyers come in expecting higher, market does the opposite → "there's something bigger taking place"; the selling pressure is simply stronger over time (v444, [13:40],[14:08],[14:40]) [REPEATED]
- **Show Hand story:** institutions break big orders into waves/subwaves/icebergs to hide intent; but executed trades still print in time & sales / footprint, revealing the hand; once known, front-running raises their execution cost (v438, [01:00],[03:46],[05:13]) [REPEATED]

## D. Exhaustion clues
- **Thin / low volume at the EDGE of a bar** — top of a red bar, bottom of a green bar (v441, [09:27]; v445 [04:00]) [REPEATED]
- Price returns to a level where decent volume previously traded but now trades only a tiny amount, e.g. comes back to "17" and trades 4 or 6 contracts while the bar itself traded 7,000 (v441, [02:33],[03:07]) [ONCE — numbers are illustrative, NEEDS-OPERATIONALIZATION]
- A test of a new high/low where only **one contract** trades then it sells off = "no interest up there" (v441, [04:38],[05:09]) [REPEATED]
- Default exhaustion threshold: **9** "is good enough for most markets"; thinner markets (MNQ/YM) use **5 or 3**; for crude he set **5** (v441, [06:55]; v445 [05:29]) [REPEATED]
- "Single prints" was the old name; renamed **exhaustion prints** as "more accurate" (v441, [06:27]) [ONCE]
- Combine with zero prints / thin prints / imbalances for strength (v441, [11:11]) [ONCE]

## E. Absorption clues
- **Strong negative Delta but price won't go down = absorption.** "It's not just see strong negative Delta and immediately think this market's going to come off — because if it doesn't, you have absorption" (v437, [06:33]) [REPEATED]
- He reads the FOOTPRINT VOLUME to locate the passive party: e.g. Delta −985 on a green candle because "you have a strong bidder in here"; heaviest bid volume 35,000 vs offer only ~2,800 → strong passive buyer (v437, [07:50],[11:55]) [REPEATED — exact numbers are from his live example, NEEDS-OPERALIZATION as a generic threshold]
- Cumulative strong negative Delta across several bars (his example ~−5,500 over 3–4 bars) with NO downward progress = absorption preceding a push to new highs (v437, [05:55],[06:33]) [ONCE — illustrative numbers]
- Absorption + a divergence inside an uptrend = "rocket fuel" / "lighter fluid to a fire" (continuation, not reversal) (v437, [11:28],[10:59]) [ONCE]

## F. Stacked imbalance ideas
- Definition: **3 (or 4) imbalances stacked neatly one on top of another over consecutive price levels**; buy-stack = green highlight = support; sell-stack = red highlight = resistance (v444, [02:55],[04:27]) [REPEATED]
- Imbalance ratio he uses = **4:1 (400%)**, "the industry standard… used for over a decade." 3:1 (300%) gives "a lot more imbalances"; some use 10:1 (v444, [00:30],[01:00]; v446 [00:56]) [REPEATED]
- A stacked imbalance can simply be one big order, a triggered stop, or many traders entering at once (v444, [03:26]) [ONCE]
- Trade method: draw the zone "until tested"; watch the reaction when price returns. If price returns then moves away → market-generated S/R you can trade around; some traders just rest an order in the zone with a stop on the other side and re-try on the next one (v444, [04:58],[05:54],[06:23]) [REPEATED]
- Reaction usually comes "within the first two or three bars" of the zone forming; longer zone = weaker (see B) (v444, [05:26],[11:31]) [ONCE]
- **Multiple imbalances** (spread out, not stacked) carry "just as much importance… probably more, because people aren't looking for them"; gets you short higher (his example: ~7760 area vs waiting for the stack at ~7720, "40 points you're missing out on") (v444, [09:20],[09:54]) [REPEATED]
- **Horizontal / imbalance reload:** same-side imbalance at the SAME price over 2 consecutive bars = consistent/reloading aggression (v446, [03:30],[05:13]) [ONCE]

## G. Delta / delta-divergence ideas
- **Delta = aggressive buyers − aggressive sellers in a bar.** Normal expectation: green candle/positive Delta, red candle/negative Delta; the move higher is "buy the offer, take out the next offer," the move lower is "sell into the bid" (v437, [00:25],[01:29]) [REPEATED]
- **Price Action Divergence** = green candle with negative Delta (or red/positive). Caused by early strong aggressive selling that then gets absorbed and recovers (e.g. went from −236 to −20 and turned up; another from −796 to −42) (v437, [02:33],[04:37],[05:15]) [REPEATED — example numbers illustrative]
- **Regular divergence → reversal; hidden divergence → continuation** (v437, [00:57]) [ONCE]
- **Delta Divergence as reversal:** aggressive selling at a high / aggressive buying at a low = potential reversal (v445, [01:33]) [REPEATED]
- **Delta divergence ALONE is not enough** — profit-taking / short-covering produces the same single divergent candle and the market continues; must combine with another reversal signal (exhaustion print) (v445, [02:28],[02:56],[03:28]) [REPEATED]
- "Price Action Divergence" is deliberately named separately from "Delta Divergence" — they are different tools/settings in his software (v437, [08:54]; v445 [00:00]) [ONCE]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Test-the-high probe:** traders buy a new high (sometimes 1 contract) "to see if it triggers any stops or gets other traders interested"; if nobody comes in they "just cut it" → fade it short with a stop just above the exhaustion print (v441, [04:10],[04:38],[05:09]) [REPEATED]
- **Failure to extend at the high:** within ~2 ticks of the high the buying is "gone" → reversal (v440, [05:19]) [ONCE]
- **Failed-move via multiple imbalances:** aggressive buyers come in but market does the OPPOSITE of expected = bigger seller present (a failed-push read) (v444, [14:08]) [REPEATED]
- Stacked imbalances themselves can be the footprint of a triggered stop run (v444, [03:56]) [ONCE]

## I. Trapped-trader ideas
- Multiple-buying-imbalance bar where sellers immediately overwhelm → "these guys are caught on the wrong side of the market" (v444, [13:06]) [ONCE]
- **Important nuance / anti-hype:** he "hate[s] using the term trap traders." On a 173-contract bar (buyers ~30/20/50, ~100 on the offer next bar) "it's not like it's 10,000 buyers all trapped scrambling to get out — whoever's trapped could get out very easily" → trapped-trader narrative only matters when the volume is genuinely large (v444, [13:06],[13:40]) [REPEATED] (see R)

## J. Entry triggers (the exact "go" event)
- **Imbalance reversal:** the trigger is the selling imbalance(s) at the bottom of a green candle (long) / buying imbalance(s) at the top of a red candle (short) AFTER a real move, ideally ON a swing low/high; THEN you want follow-through order flow in the very next bar (v440, [02:37],[03:45],[03:45]→[04:17]) [REPEATED]
- **Exhaustion print reversal:** exhaustion print at a swing high → enter short (stop just above the print); at a swing low → long (v441, [05:09]) [REPEATED]
- **Delta Divergence + Exhaustion at same swing:** the combined signal (his gold zone + green box on the same swing) is the go event (v445, [07:31],[08:42]) [REPEATED]
- **Multiple-imbalance reversal:** if a green-candle multiple-imbalance zone is NOT violated (not traded above) in the next bar → "a nice little short opportunity"; mirror for long below a red-candle zone (v444, [11:31],[12:04],[12:33]) [REPEATED]
- **Imbalance reload:** enter on the second same-level imbalance bar / when the zone starts drawing out (he accepts being "a bar late") (v446, [05:47],[08:51]) [ONCE]
- **Show Hand:** the plotted buy/sell arrow is the signal; with "trade entry signal" ON the arrow shifts to the bar that actually starts moving (v438, [21:22],[03:05/1:02:24]) [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Follow-through must be fast.** "When something happens in the order flow, I expect it to happen sooner rather than later" (v438, [21:57]) [REPEATED]
- Show Hand "trade entry signal" operationalizes this: default = price must move **2 ticks within 3 bars** (from high of signal bar for longs / low of signal bar for shorts); configurable 1–5 ticks / 1–5 bars; max bars he caps at 5 (v438, [17:22],[21:22],[34:59]) [REPEATED] — **exact numbers, his tool default**
- Imbalance reversal: want the next bar to follow through "really strong" — his example: bar closes, next opens 7640 and immediately trades up ~3 dollars to 7920 (v440, [04:17]) [ONCE — illustrative]
- A zone "running away" from its level quickly (price not coming back) is itself "a good signal" of a real move (v438, [25:47]) [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- If price does NOT move in your direction within the time window (2 ticks / 3 bars default) the trade is invalid — Show Hand draws an unfilled zone instead of a live signal (v438, [21:22],[22:27]) [REPEATED]
- Imbalance reversal taken WITHOUT a prior move = invalid ("if you're coming off 8240 then hit 8170, that's not a move that's going to reverse"); momentum-only wiggles get stopped out (v440, [07:49],[09:48]) [REPEATED]
- Delta divergence that is merely profit-taking/short-covering: market continues in the prior direction → thesis dead unless exhaustion confirms (v445, [02:28]) [REPEATED]
- Stacked-imbalance support that's too old (zone drawn out too long) has "worn off" → don't trade the retest (v444, [06:23],[11:31]) [ONCE]
- Light-volume "trap"/imbalance where trapped side can exit easily → not a real edge (v444, [13:06]) [ONCE]

## M. Stop / risk / target / trade management
- **Exhaustion-print short:** stop "just above the exhaustion print," "right up here" (v441, [05:09]) [REPEATED]
- Some traders trade the exhaustion-print pullback with stops "almost to the tick" / one tick below — great R:R when right but frequent one-tick stop-outs; he is "not advocating" the 1-tick version for himself (v441, [07:31],[08:00],[08:26]) [ONCE]
- **Stacked imbalance:** rest order in the zone, stop "right on the other side"; if stopped, "fine, just wait for the next one" (v444, [05:54],[06:23]) [REPEATED]
- **Imbalance reload long:** stop "below the low of the green candle" of the first imbalance bar; short = just above the reload zone, "doesn't need to be all the way up at the high of the day" (v446, [06:18],[06:44]) [REPEATED]
- **Targets:** he explicitly does NOT use zones as fixed targets ("don't get fixated… has to come back to exactly that level"), but zones/levels can be areas to take profit or to place stops (v438, [25:47],[01:01:49]) [REPEATED]
- He does NOT give fixed point/tick targets anywhere in this chunk — target management is discretionary/level-based. NEEDS-OPERATIONALIZATION.

## N. Context filters (session/time, regime/volatility, levels)
- **Levels matter most for reversals:** low/high of day, new highs/new lows, swing highs/lows, support/resistance, **value-area high / value-area low, high-volume node**, point of control (v441, [11:46],[12:18]) [REPEATED]
- **Swing filter** is his primary noise filter for reversal tools (period default 5; he often uses 10; some use 25/50). Without it you take non-swing imbalances/exhaustions that fail (v440, [08:26]; v445 [06:01]) [REPEATED]
- **Chart type is flexible** — range (4-range, 5-range, 8-range), tick, volume, 30-sec, 1-min, 5-min all work; "volume is volume… if it appears on one chart it'll appear on others." Pick a chart that helps you understand the order flow (v437, [10:29],[12:25]; v445 [04:30]; v444 [01:55]) [REPEATED]
- **Session:** institutions trade the evening/European session too; volume distributes differently overnight vs day → indicator settings may need adjustment between sessions (v438, [27:32],[53:46]) [REPEATED]
- **Regime:** trending days look better than choppy days; in chop you "get chopped up," signals fail (v438, [22:27],[48:07]) [REPEATED]
- **Volatility/fast markets:** when volume is "spread out" across huge bars (e.g. Dow 60-pt bars) order-flow detection is hard and may miss the move; fast markets need a HIGHER disparity range (v438, [53:12],[29:45]) [REPEATED]
- **Avoid trading right in front of scheduled numbers** (JOLTS example) — won't claim it as a great opportunity (v437, [12:51],[13:21]) [ONCE]
- **Instruments referenced:** bonds (ZB), ultra bonds (UB), 10s (ZN), 5-yr, ES/MES, NQ/MNQ, Dow/YM, crude (CL), gold, euro (6E), yen, Swiss franc, DAX, Bund (German 10y on Eurex), soybean meal, live cattle (LE). He recommends EASY markets for newbies (5-yr, currencies) over Nasdaq; bonds good even overnight (v438, multiple, [38:46],[1:09:24]) [REPEATED]

## O. Directly testable / measurable variables
- Imbalance ratio threshold = **4:1 (400%)** default; alternatives 3:1 (300%), 10:1 (v444, [00:30]; v446 [00:56]) — testable
- Stacked imbalance = **≥3** consecutive imbalanced price levels same direction (v444, [02:55]) — testable
- Exhaustion-print volume threshold default **9**; thin markets **3–5**; crude example **5** (v441, [06:55]; v445 [05:29]) — testable, but "9 good enough" is heuristic → NEEDS-OPERATIONALIZATION per instrument
- Minimum imbalance-reversal volume = **10** contracts (so a 4:1 isn't 1-vs-5 light volume) (v440, [06:47]) — testable
- Swing filter period: default **5**, he commonly uses **10**, others **25/50** (v440 [08:26]; v445 [06:01]) — testable parameter
- Show Hand **disparity range 50–250**, default **150**; 50 = most signals, 250 = fewest; he steps in 25s; mentions fib 89 (v438, [09:47],[10:19],[11:25]) — measures order-flow volume vs surrounding volume → the algo, NOT raw volume ([50:44],[44:48]) — NEEDS-OPERATIONALIZATION (proprietary)
- Show Hand **momentum strength 0–6**, default 6 (strongest), 3 = average, 0 = off (v438, [13:33]) — parameter
- Show Hand **trade-entry-signal:** default move **2 ticks within 3 bars**; range 1–5 ticks / 1–5 bars (v438, [17:22],[34:59]) — directly testable confirmation rule
- "Prominent point of control" filter (bar must have a PoC that "matters") (v438, [12:31]) — qualitative, NEEDS-OPERATIONALIZATION
- Imbalance reload = same-side imbalance at SAME price over **2 consecutive bars** (v446, [03:30]) — testable
- Order-flow tail / **zero print** at the extreme of the move (v440, [03:45]) — testable (presence of a 0-volume cell)
- Multiple-imbalance no-violation-next-bar entry rule (v444, [12:04]) — testable
- Qualitative / NEEDS-OPERATIONALIZATION: "big volume," "strong selling," "aggressive trading drying up," "decent volume," "legitimate" volume, "prominent" PoC, "overextended," "too fast in too short a time," absorption magnitude (all of v437/v440/v441)

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Tools to replicate (all his Orderflows Trader 7 footprint features): **Price Action Divergence**, **Delta Divergence**, **Imbalance Reversal**, **Exhaustion Prints**, **Stacked Imbalance**, **Multiple Imbalances**, **Imbalance Reload**, plus standalone **Show Hand** and **Toolbox** (Delta-Divergence + Exhaustion on a plain candlestick chart) (v437/v440/v441/v444/v445/v446) [REPEATED]
- **Tick replay required** for historical order-flow signals (Show Hand pops a "requires tick replay" message). Renko/line-break only work if the chart variant uses tick replay (v438, [08:43],[16:41],[54:26]) [REPEATED]
- Signals run on candlestick OR footprint identically ("it reads the order flow… not a footprint chart") (v438, [04:43],[08:43]) [REPEATED]
- **Zone draw modes:** "until tested" (extends until price returns to the level) vs "fixed N bars"; set width 0 to disable zones (v438, [23:34],[24:14]; v444 [04:58]; v446 [07:15]) [REPEATED]
- **Plot/marker design:** green = bullish, red = bearish; gold/yellow = exhaustion print, green box = Delta divergence; he enlarges plot size (e.g. 8 or 15) so combined signals "stand out" / "jump off the page" (v445, [08:42],[09:17]; v437 [09:30]) [REPEATED]
- **Swing-filter vs momentum mutually exclusive** in Show Hand (turn momentum to 0 when using swing filter) (v438, [31:48]) [ONCE]
- Implied composite indicator: require (a) at a swing/level, (b) prior move, (c) reversal-direction imbalance/exhaustion/divergence, (d) fast follow-through (2 ticks/3 bars) — combine signals for higher quality (synthesis across v440/441/444/445) [SPECULATIVE]
- Color the bottom cell of a red bar / top cell of a green bar to flag the imbalance; for multiple-imbalance it draws the zone from that cell to detect violation (v444, [08:27],[11:31]) [REPEATED]

## Q. Notable verbatim quotes (3–10)
1. "You don't just see the strong negative Delta and immediately think this market's going to come off, because if it doesn't, you have absorption taking place — someone is there absorbing all that aggressive selling." (v437, "Delta Price Action Divergence", [06:33])
2. "Someone is stepping up to the plate and saying, 'Hey, you know what, not on my watch — this market's not going to go lower.'" (v437, [08:23])
3. "It's the result of a market that moves too fast in too short a time period and it basically becomes overextended… you often get a nice little short-term reversal." (v440, "Imbalance Reversals", [01:13])
4. "You have a combination of the market running into liquidity and the last sellers selling… the last seller has sold, the market starts reversing — that is something you can trade." (v440, [03:45])
5. "Remember, it's called an imbalance reversal, it's not called the imbalance momentum." (v440, [09:48])
6. "With exhaustion prints you're looking for the lesser volume to take place… an exhaustion print should jump off the page if you're at a swing high." (v441, "Benefits Of Exhaustion Prints", [02:05],[13:12])
7. "Delta Divergence by itself sometimes is just not enough… when you combine Delta Divergence with an exhaustion print, it sets you up for very nice trading opportunities." (v445, "Delta Reversals & Exhaustion Prints", [01:59],[04:00])
8. "When you see the market doing the opposite of what you're expecting it to do… it's telling you there's something bigger taking place in the market." (v444, "Order Flow Imbalance Strategy", [14:08])
9. "I hate using the term trap traders… it's not like it's 10,000 buyers here all trapped and scrambling to get out. They can trade 100 in the next bar or two." (v444, [13:06],[13:40])
10. "When something happens in the order flow, I expect it to happen sooner rather than later." (v438, "Show Hand", [21:57])

## R. Contradictions / nuances
- **Same tool, opposite uses:** divergence and exhaustion prints are taught as BOTH reversal AND continuation signals — regular divergence = reversal, hidden divergence = continuation; exhaustion print in a running bar = continuation, at a swing extreme = reversal. The READ depends on location/context (v437, [00:57]; v441, [08:26]) [REPEATED]
- **Anti-"trap trader" stance** contradicts common order-flow hype: light-volume imbalances are NOT meaningful traps because the side can exit easily; he even says he "hates" the term (v444, [13:06]) [REPEATED]
- **Delta divergence skepticism:** contradicts the naive "green candle at a low = reversal" — it may just be short-covering/profit-taking and the trend continues; needs a second confirming signal (v445, [02:28]) [REPEATED]
- **Stacked vs multiple imbalances:** pushes back on the crowd — non-stacked "multiple" imbalances are "just as important, probably more" than the textbook stacked pattern everyone watches (v444, [09:54]; v446 [02:30]) [REPEATED]
- **"It depends":** every market trades different volume; he refuses to give one universal setting and won't say "optimize" but admits tuning disparity range/momentum/swing per market & session (v438, [58:37],[53:46]) [REPEATED]
- **Tick-replay confusion:** he first says Show Hand can run without tick replay, then is corrected by his own software's pop-up that it IS required (a live self-correction) (v438, [15:55],[16:41]) [ONCE]
- **Imbalance vs momentum tension:** a 2-tick "reversal" that keeps going is a stop-out; the swing filter exists precisely because the raw imbalance-at-edge condition over-fires (v440, [09:23],[09:48]) [REPEATED]
- **Zone time-decay:** longer/older zone = weaker support, contradicting the idea that a drawn level is permanently meaningful (v444, [11:31]) [ONCE]

## Coverage note
All 7 transcripts parsed cleanly and are reversal-relevant (T1). Richest model content: v440 (imbalance reversals), v441 (exhaustion), v445 (Delta-divergence + exhaustion combo — the clearest "A+ stacking" logic), v444/v446 (imbalance taxonomy + trap-trader nuance). v438 (Show Hand webinar) is long but ~70% tool-settings/Q&A; its load-bearing model content is the 2-ticks/3-bars confirmation rule and session/regime/fast-market caveats. No literal letter-grade ("A+") vocabulary appears; tiering is expressed via "great/nice/powerful/strong," swing-filtering, level/extreme requirement, prior-move requirement, and volume-legitimacy. Numbers recorded are either explicit parameters (4:1, 9, 10, 5, 150, 2/3 ticks/bars) or flagged illustrative; qualitative magnitudes left un-operationalized as instructed.
