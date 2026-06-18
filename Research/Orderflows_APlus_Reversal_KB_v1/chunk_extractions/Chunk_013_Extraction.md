# Chunk 013 Extraction
- Source chunk: Chunk_013_Orderflows_Transcripts.md
- Transcripts covered:
  - v417 — Order Flow Opportunities At The Low Of The Day Using Orderflows Trader For NinjaTrader 8 (2024-02-22)
  - v418 — Order Flow Trading Strategy Stopping Volume And Delta Analysis Using Orderflows Trader (2024-02-23)
  - v421 — Delta Divergence With Orderflows Ratios Is Orderflows Trader 7 Improvements (2024-03-07)
  - v423 — The Retail Suck Indicator On Orderflows Trader 7 For NinjaTrader 8 (2024-03-10)
  - v425 — How To Easily Identify Trapped Traders With Orderflows Trader 7 For NinjaTrader 8 (2024-04-10)
  - v427 — Recognizing Accumulation And Distribution In The Order Flow With Orderflows Trader 7 For NinjaTrader (2024-04-12)
  - v428 — Fresh Liquidity In The Order Flow Holding And Failing Using Orderflows Trader 7 For NinjaTrader 8 (2024-04-13)
  - v434 — Trading Stacked Imbalances In Volatile Markets Using Orderflows Trader (2024-08-23)
  - v435 — The Importance Of Order Flow Imbalances In The Footprint Chart Using Orderflows Trader (2024-08-26)
  - v436 — Imbalance Reload On Orderflows Trader An Order Flow Trading Strategy (2024-08-28)
- Overall content value: **rich** (multiple named reversal setups, explicit "context" filtering logic, holding-vs-failing mechanics, several proprietary tools defined)

## A. Setup types & names he uses
- **Stopping volume** — heavy/above-average volume at the END of a move (up or down) that stops the market going further; passive buyers (or sellers) absorb the aggressive flow. (v418, "Stopping Volume And Delta", [00:06], [02:07]) [REPEATED]
- **Delta divergence (bullish/bearish)** — bullish = new-or-equal low + positive Delta + green candle; bearish = new-or-equal high + negative Delta + red candle. (v421, "Delta Divergence Ratios", [00:53], [01:25]) [REPEATED]
- **Divergence + ratio combo** — divergence PLUS an Orderflows "ratio" (price exhaustion or price defense) = his named good trade setup. (v421, "Delta Divergence Ratios", [03:34]; v417, "Low Of The Day", [11:33]) [REPEATED]
- **Imbalance reversal** (= his footprint name for "trapped traders") — excess buying/selling imbalance at a level where traders get trapped, then market reverses. (v425, "Identify Trapped Traders", [03:19], [03:49]) [REPEATED]
- **Retail suck** — order-flow pattern where retail traders are "sucked into" / trapped in losing positions; bullish (green) or bearish (medium orchid). (v423, "Retail Suck Indicator", [00:00], [01:36]) [ONCE]
- **Accumulation / distribution** — institutions gradually building (accum = high-volume buying + absorption of selling) or unloading (distribution = opposite). (v427, "Accumulation And Distribution", [02:30], [03:32]) [REPEATED]
- **Fresh liquidity holding vs failing** — big fresh bid/offer (not resting in book); if it HOLDS → expect reversal up; if it FAILS → expect continuation down. (v428, "Fresh Liquidity Holding And Failing", [01:53], [02:19]) [REPEATED]
- **Stacked imbalances** — 3+ consecutive price levels each with a same-side imbalance, stacked on top of each other. (v434, "Stacked Imbalances Volatile", [02:08]; v435, "Importance Of Imbalances", [03:57]) [REPEATED]
- **Multiple imbalances (spread out)** — 3+ imbalances in one bar but NOT neatly stacked; treated with equal weight. (v435, "Importance Of Imbalances", [04:24], [11:31]) [REPEATED]
- **Imbalance reload** — same-side imbalances spread over TWO consecutive bars at the same level (burst, breathe, burst). (v436, "Imbalance Reload", [04:40], [05:13]) [ONCE]
- **Exhaustion print** — very little volume (opposite of imbalance reversal which is a lot of volume). (v425, "Identify Trapped Traders", [11:46]) [ONCE]
- **Triple bottom / weakening-lows reversal** (descriptive) — repeated tests of a low with shrinking volume per test. (v417, "Low Of The Day", [05:30], [21:21]) [REPEATED]

## B. Tiering / grading language  ← HIGH PRIORITY
- **"my favorite"** framing: when asked his favorite tool for order flow, he names **imbalances** as "one of the basic ones … one of the cornerstones of trading with orderflow." (v435, "Importance Of Imbalances", [01:58]) [ONCE]
- **"beautiful Buy Signal" / "nice beautiful"** — the bar AFTER the low (not the low bar itself) that triggers the move all the way to highs of day = his strongest praise for an entry. (v417, "Low Of The Day", [21:59]) [ONCE]
- **"juicier"** is his explicit tier word for momentum quality: one thin print = not enough; "I do think you want something more juicier"; three thin prints stacked neatly = "much juicier." (v417, "Low Of The Day", [18:41], [19:14]) [ONCE]
- **"beautiful trade … best you know most beautiful trade"** (jokingly "like Donald Trump") = an imbalance-reload short where price comes right back to the level then big selloff. (v436, "Imbalance Reload", [09:46]) [ONCE]
- **"decent" / "decent buying opportunity"** — mid-tier; used for moves that worked but only went ~5–7 points on a Fed day. (v417, "Low Of The Day", [05:53], [11:51]) [REPEATED]
- **"nothing" / "no major reason to buy"** — lowest tier; lows with no thin prints, no momentum signs. (v417, "Low Of The Day", [11:04], [18:41], [21:21]) [REPEATED]
- **"a clear sign … of stopping volume"** — the A-grade form: green bar with POC (heaviest volume) at the BOTTOM of the bar + reversal. (v418, "Stopping Volume And Delta", [04:39]) [REPEATED]
- **"that is a signal"** — for divergence, he says it doesn't matter what the ratio NUMBER is "as long as it's a red number on top" (bearish) / bullish ratio below green = signal. (v421, "Delta Divergence Ratios", [04:41]) [REPEATED]
- Tier-DOWN criteria (context): a stacked imbalance in a SIDEWAYS market gets LESS importance than one at a breakout or at a swing high/low; "I don't put as much importance in stacked imbalances … as opposed to when a market starts breaking out." (v434, "Stacked Imbalances Volatile", [03:16]) [REPEATED]
- Tier-DOWN (weak imbalance): "weak imbalances" e.g. 1 vs 8 or 7 vs 0 — technically an imbalance but not "a legitimate strong imbalance"; he wants min volume to count. (v436, "Imbalance Reload", [00:30], [02:02]) [REPEATED]
- Tier-DOWN: a single lone imbalance "I don't usually put too much weight in it because it could just be a big order that hit the market." (v435, "Importance Of Imbalances", [12:07]) [REPEATED]
- "didn't work" / "just went sideways on you" — explicit failure labels he applies even to valid-looking signals (honest about false positives). (v423, "Retail Suck Indicator", [04:52]; v427, "Accumulation And Distribution", [06:28]) [REPEATED]

## C. Order-flow story & psychology per setup
- **Trapped traders (imbalance reversal):** aggressive buyers push price up into a level (e.g. a double top / FOMO breakout attempt); once they "run out of bullets" / buying interest, the natural selling comes in and price drifts down — those late buyers are now trapped in losing longs. (v425, "Identify Trapped Traders", [01:27], [02:00]) [REPEATED]
- **FOMO mechanics:** everyone sees price returning to a prior double top, rushes in expecting a breakout to 117; once they've all bought there's "no more buying interest" → selling moves it lower. (v425, "Identify Trapped Traders", [01:53]) [ONCE]
- **Stopping volume story:** strong aggressive selling into a low, but a big passive bidder absorbs it ("there's a big bid down there, there's passive buyers waiting"); aggressive sellers can't push lower → reversal. (v418, "Stopping Volume And Delta", [02:07], [07:09]) [REPEATED]
- **Accumulation story:** institutions/real-money buy gradually & strategically to avoid moving price; shows as high-volume buying + absorption of selling pressure keeping price stable. (v427, "Accumulation And Distribution", [03:00], [03:32]) [REPEATED]
- **Fresh liquidity (FOMO visualized):** on a holding move, "people are tripping over themselves trying to buy" (thin volume, stacked buy imbalances), then a big buyer sits the bid and sweeps up — "if you're trying to picture what fomo looks like in the order flow, this is what it looks like." (v428, "Fresh Liquidity Holding And Failing", [14:40], [15:44]) [ONCE]
- **Weakening-lows psychology:** repeated probes into a low (306 → 183 → 22 lots) show "are people interested in selling down here? no" → aggressive buying then steps in. (v417, "Low Of The Day", [05:30]) [REPEATED]
- **Contrarian correction:** he explicitly REJECTS the "trapped traders at the low caused the rally / squeeze" story — there's plenty of exit liquidity, a few hundred trapped contracts can't squeeze a market trading thousands per bar. (v425, "Identify Trapped Traders", [08:27], [09:32]) [REPEATED]

## D. Exhaustion clues
- **Ratio "bounds high" = price exhaustion**; ratio "bounds low" = price defense. After a run up, a ratio-bounds-high at the new high signals exhaustion. (v421, "Delta Divergence Ratios", [03:34], [04:12]) [REPEATED]
- Exhaustion in practice = aggressive sellers getting WEAKER while aggressive buyers get stronger (at a low) → "chances are the market's going to go higher." (v421, "Delta Divergence Ratios", [06:32]) [REPEATED]
- **Shrinking volume on successive tests of a low** = selling exhaustion ("the selling into this low was getting weaker just by watching the volumes traded at those lows"). (v417, "Low Of The Day", [06:27]) [REPEATED]
- **Exhaustion print** = a bar/level with very LITTLE volume after a move = lack of interest = potential reversal; opposite of high-volume imbalance reversal. (v425, "Identify Trapped Traders", [11:46], [12:21]) [ONCE]
- **Thin prints / single prints** at a low = sign of MOMENTUM (price moving fast through with little counter-trade), a go-signal off the low. (v417, "Low Of The Day", [09:01], [13:37]) [REPEATED]
- Delta sequence showing exhaustion: at a low he reads −97 → −304 → −162 → +399 = "aggressive selling, less aggressive selling, lesser aggressive selling, aggressive buying." (v418, "Stopping Volume And Delta", [09:18]) [ONCE]

## E. Absorption clues
- **Selling imbalances inside GREEN candles** = absorption ("it's volume that is absorbing whatever aggressive selling is taking place"); cited 194 vs 45, 130 vs 5 as "little signs." (v417, "Low Of The Day", [14:11]) [REPEATED]
- **Stopping volume IS absorption:** strong passive buyers "basically absorbing whatever aggressive selling is taking place" at the low. (v418, "Stopping Volume And Delta", [07:09]) [REPEATED]
- **Accumulation absorption:** heaviest volume in the bar on the BID side (e.g. 4,270) under a green candle = passive buyers absorbing selling, keeps price stable; "maybe we get through the absorption by a tick or two but if it's holding … that is a sign of absorption." (v427, "Accumulation And Distribution", [03:32], [04:07], [04:46]) [REPEATED]
- Absorption + aggressive trading together = the accumulation signature (he filters his Accum/Dist tool by "passive traders in control"). (v427, "Accumulation And Distribution", [05:49]) [REPEATED]

## F. Stacked imbalance ideas
- Definition: 3+ consecutive price levels with same-side imbalances stacked on top of each other; very visual in footprint. (v435, "Importance Of Imbalances", [03:57]) [REPEATED]
- Usually caused by a "big burst … maybe a big order going through the market" in one shot. (v435, "Importance Of Imbalances", [05:24]; v434, "Stacked Imbalances Volatile", [07:13]) [REPEATED]
- **Context is everything:** a stacked imbalance at a SWING LOW after a selloff = buyers attracted in to push higher; at a swing HIGH after a ~20-point rally = sellers to take advantage of. In a sideways market = discount it. (v434, "Stacked Imbalances Volatile", [03:16], [10:54]) [REPEATED]
- **Bullish confluence (rare, strong):** stacked SELLING imbalance area, then aggressive BUYING comes in at the SAME price level — "not something you see very often … that's actually a nice bullish sign" (short-term). (v434, "Stacked Imbalances Volatile", [05:16]) [ONCE]
- **Prefer the imbalance close to the swing:** he repeatedly says he'd prefer the stacked imbalance be within a few minutes of the swing low/high, not 4–5 minutes removed. (v434, "Stacked Imbalances Volatile", [08:18], [08:45], [09:09]) [REPEATED]
- **Market-generated S/R:** zones where aggressive buying started become support to watch on a retest. (v434, "Stacked Imbalances Volatile", [04:19], [04:46]) [REPEATED]
- He treats **stacked AND spread-out (multiple) imbalances with EQUAL importance** — both = aggressive buying, one just "massaged into the market" via execution algos (time slicer). (v435, "Importance Of Imbalances", [05:51], [11:31]) [REPEATED]

## G. Delta / delta-divergence ideas
- Bullish Delta divergence = new/equal LOW with POSITIVE delta + green candle; bearish = new/equal HIGH with NEGATIVE delta + red candle. The price-action candle requirement was the v7 upgrade. (v421, "Delta Divergence Ratios", [01:25]) [REPEATED]
- v7 added **swing-high/swing-low divergences** (not just day high/low) — opens "a whole new layer of trades." (v421, "Delta Divergence Ratios", [05:51], [07:40]) [REPEATED]
- **Don't trade divergence alone** — "trying to trade it by itself … a recipe for disaster," especially in a trending market where divergences are just profit-taking and you "can get run over." Pair with a ratio. (v421, "Delta Divergence Ratios", [02:27], [02:58]) [REPEATED]
- Strong negative delta INTO a low (e.g. −685 then −361 at the low) followed by big positive delta = the reversal signature. (v417, "Low Of The Day", [13:03]) [REPEATED]
- Divergence "buy" example at the low: new low with positive Delta on the 3rd test, thin volume (4 and 6), bullish ratios (0.72, 0.44) — "I like that trade setup … the divergence plus a bullish ratio / bullish ratio." (v417, "Low Of The Day", [11:33]) [ONCE]
- Note: lots of buying imbalances will mechanically produce positive delta anyway — so positive delta alone at a low is "nothing." (v417, "Low Of The Day", [11:04]) [ONCE]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Probing for stops:** traders push price down into a prior low to "see, hey, is there going to take out the low, can we trigger some stops, maybe this market could sell off some more" — when it doesn't, it rallies back. (v417, "Low Of The Day", [07:27]) [REPEATED]
- **Fresh-liquidity FAILURE = continuation:** a big fresh bid that gets "whacked" / trades through immediately (vs holding 3 min) signals a flow-driven market that will keep going down; second & third big bids two points lower also fail. (v428, "Fresh Liquidity Holding And Failing", [08:27], [09:00]) [REPEATED]
- **Failed breakout into double top = trapped longs (imbalance reversal):** buyers can't move price above the double top → trapped → market reverses down. (v425, "Identify Trapped Traders", [01:27]) [REPEATED]
- **Scalper-stop cascade:** scalpers front-run a big bid, place stops just below; when the level breaks, their stops add fuel — price dropped from 05 to 02 (3 points, not ticks) on the break. (v428, "Fresh Liquidity Holding And Failing", [07:28], [07:58]) [ONCE]

## I. Trapped-trader ideas
- Definition: traders who entered at unfavorable levels and are stuck in losing positions; "can be identified by significant imbalances or excess buying/selling interest at certain price levels." (v425, "Identify Trapped Traders", [00:26], [01:27]) [REPEATED]
- His footprint name for it = **imbalance reversal** (signature: a buying imbalance like 253 vs 1056 AND a passive selling imbalance / big bid getting sold into, e.g. 1869, right after a double top). (v425, "Identify Trapped Traders", [03:19], [05:04]) [ONCE]
- **Traders can be trapped ANYWHERE, not just at highs/lows** — "people automatically think traders have to be trapped at highs or lows. They don't." (v425, "Identify Trapped Traders", [07:55]) [REPEATED]
- **Anti-pattern he debunks:** "anytime there's a big wick, say oh there's trapped traders — that's just kind of BS." Use order flow, not wicks. (v425, "Identify Trapped Traders", [02:25]) [REPEATED]
- **Retail suck** = retail getting sucked/fooled into trapped positions; best used at reversal points = swing highs/lows. (v423, "Retail Suck Indicator", [00:00], [02:42]) [ONCE]

## J. Entry triggers (the exact "go" event)
- **Thin print / single print appearing right off the low** = momentum go-signal; "you want to be buying as close to the low as possible based off of what's taking place in the order flow … take advantage of it as quickly as possible." (v417, "Low Of The Day", [13:37], [16:36]) [REPEATED]
- **The bar AFTER the low** giving a buy signal (doesn't have to be the exact low bar) — "the bar afterwards gives you a nice beautiful Buy Signal to catch that move up." (v417, "Low Of The Day", [21:59]) [ONCE]
- **Divergence + ratio prints** (bullish ratio below a green candle / bearish ratio above red) = the signal. (v421, "Delta Divergence Ratios", [03:34], [04:41]) [REPEATED]
- **Stopping volume:** green bar with POC at the bottom + market reverses = the entry read. (v418, "Stopping Volume And Delta", [04:39]) [REPEATED]
- **Fresh bid holding:** once it holds and price starts trading ABOVE the big bid with positive delta + buy imbalances → go long. (v428, "Fresh Liquidity Holding And Failing", [14:12], [16:12]) [REPEATED]
- **Imbalance reload + breaking away from the zone:** when price "runs away" from the reload zone (not rotating around it) = trigger. (v436, "Imbalance Reload", [07:53], [08:25]) [ONCE]
- **Confluence stack (his preferred method):** wait for multiple tools to "all come together and then you lean on it" — e.g. retail suck + prominent point of control (1/2/3). (v423, "Retail Suck Indicator", [04:12], [09:31]) [REPEATED]
- NEEDS-OPERATIONALIZATION: "as quickly as possible" / "right away" are timing instructions, not a bar-count rule.

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Market must move NEXT bar:** "the part a lot of traders miss" — if you get bullish order flow / thin print but the next bar "can't even go any higher," the thesis is wrong: "why would you be getting long if next bar can't even go any higher?" (v417, "Low Of The Day", [18:14], [18:41]) [REPEATED]
- After stopping volume / absorption, you should see aggressive buying CREEP IN and grow over subsequent bars (e.g. delta +221 → +343 → +359). (v418, "Stopping Volume And Delta", [09:54]) [ONCE]
- A holding fresh bid should see price start trading above it and rally (98¼ → 00¼). (v428, "Fresh Liquidity Holding And Failing", [15:12]) [ONCE]
- Reload/breakout confirmation = price runs away from the zone in the bar afterward ("the clue is going to come in in the bar afterwards"). (v436, "Imbalance Reload", [10:55]) [REPEATED]

## L. Invalidation — what should NOT happen / what kills the thesis
- **Next bar fails to extend** = invalidation (see K). (v417, "Low Of The Day", [18:14]) [REPEATED]
- **Bullish signal but market makes a NEW low instead** = wrong; don't get long just because you saw imbalances/thin print. (v417, "Low Of The Day", [18:41]) [ONCE]
- **Fresh bid getting traded through / failing** invalidates the long (and flips to a continuation-down read). (v428, "Fresh Liquidity Holding And Failing", [02:19], [09:00]) [REPEATED]
- **Strong selling INTO a low ahead of Fed minutes** would make him worried / not turn long; absence of strong selling kept him patient. (v417, "Low Of The Day", [08:02], [08:32]) [ONCE]
- A signal that "just went sideways" = effectively failed even if not a full loss. (v436, "Imbalance Reload", [09:20]; v427, [06:28]) [REPEATED]
- Stacked/multiple imbalance in a SIDEWAYS market = low actionability; "any sort of clue the market's going to give you in sideways activity is going to be hard to act on." (v436, "Imbalance Reload", [05:49]) [REPEATED]

## M. Stop / risk / target / trade management
- **Flow-driven market = wider stops:** "you can't necessarily trade with a tight stop because you're going to get bounces"; a 2-point stop short at 5200 would've been hit (price traded back to 06 before breaking). Give it "more leeway." (v428, "Fresh Liquidity Holding And Failing", [11:08], [11:37]) [REPEATED]
- He does NOT specify a fixed stop or target for reversal setups — targets described qualitatively (5–7 points on a Fed day "decent"; "easy 10 points"; ran "all the way up to the highs of the day"). NEEDS-OPERATIONALIZATION. (v417, [06:00]; v428, [16:12]) [REPEATED]
- **Scalping interest-rate context (others, not him):** some bond traders aim for just 3 ticks (3 ticks × $31.25 = ~$93/contract; 10 contracts = ~$900); he says "I'm not advocating that." (v425, "Identify Trapped Traders", [10:35]) [ONCE] — exact numbers stated, market-specific.
- **Fed-day management rule:** don't trade ahead of FOMC minutes; ask "how long can I hold this — until the Fed starts talking or not?" — it "limits your possibilities." (v417, "Low Of The Day", [20:11], [20:42]) [REPEATED]
- "06 07 is good enough" / "4 or 5 ticks in the bonds" — qualitative small-target framing for imbalance-reversal scalps. (v425, "Identify Trapped Traders", [05:36], [09:58]) [ONCE]

## N. Context filters (session/time, regime/volatility, levels)
- **Trade reversals at the EDGES of the market — the highs or lows of the day.** "Anytime you have a reason to be buying at a low is going to give you a good trading opportunity." (v417, "Low Of The Day", [12:05], [21:59]) [REPEATED]
- **Swing highs/lows** are the preferred reversal context for retail suck and divergence v7 (swing period default 5, adjustable 20/50). (v423, "Retail Suck Indicator", [02:42], [03:12]; v421, [05:51]) [REPEATED]
- **News/event filter:** don't trade ahead of FOMC minutes, CPI, Jackson Hole; wait 15–30 min for the market to settle after the number. (v417, [20:11]; v425, [06:15]; v434, [00:00]) [REPEATED]
- **Volatility regime:** on high-vol days (Fed speaker) bars stretch 8–12 points/min; imbalances come on lighter volume, so "put it in context." (v434, "Stacked Imbalances Volatile", [01:33], [07:49]) [REPEATED]
- **Market-condition regime (sideways vs breakout):** the single most repeated filter — imbalances/reloads matter at breakouts & swings, not in sideways ranges. "If we're in a sideways market, no matter what you do it's not going to be very effective." (v436, "Imbalance Reload", [09:20]) [REPEATED]
- **Flow-driven vs rotational market:** if big bids/offers FAIL instead of acting as S/R, you're in a flow-driven market → trade with the flow, wider stops. (v428, "Fresh Liquidity Holding And Failing", [10:38]) [REPEATED]
- **Instrument selection for tools:** Accumulation/Distribution best on **supply/demand-driven markets — interest rates (bonds, 10yr, 5yr, ultras)** where flow is overwhelmingly institutional; LESS suited to equities (driven by options, retail, politicians). (v427, "Accumulation And Distribution", [07:43], [08:15]) [REPEATED]
- **Chart-type context:** he now favors **time-based** charts but uses range-based too; he traded the examples on S&P 1-min/60-sec, crude 8-range, gold 8-range, bonds 4-range, 10yr/5yr 4-range. Range charts can reveal weakening aggressive selling that time charts hide (and vice versa). (v418, "Stopping Volume And Delta", [01:15], [08:45]; v425, [00:26]; v423, [07:35]) [REPEATED]
- **Min-imbalance-volume filter (thin markets):** in thin markets (Euro FX) require a **minimum volume of 10** in an imbalance to count it; in ES/MES/rates not an issue. (v436, "Imbalance Reload", [01:02], [02:36]) [REPEATED]
- **Timeframe filter:** order flow tools (esp. imbalance reload) don't work well on 5-min+ charts ("you got five minutes to rotate around"); on 4-hour "just follow price, you probably don't need order flow." On longer charts use volume-related signals instead. (v436, "Imbalance Reload", [11:28], [12:33]) [REPEATED]

## O. Directly testable / measurable variables
- **Imbalance ratio = 4:1 (400%)**, his default ("I use 4 to one"); notes others use 3:1 or higher. (v434, [02:08]; v435, [02:26]; v436, [00:30]; v425, [05:04]) [REPEATED] — EXACT.
- **Minimum imbalance volume = 10** (his preferred floor for a "legitimate strong imbalance"). (v436, "Imbalance Reload", [01:02]) [REPEATED] — EXACT.
- **Stacked imbalance = 3 or more** consecutive same-side imbalance levels. (v435, [03:57]) [REPEATED] — EXACT.
- **Multiple imbalances = 3 or more** imbalances in one bar (not stacked). (v435, [11:31]) [REPEATED] — EXACT.
- **Imbalance reload = imbalances over 2 consecutive bars**, same side, same level. (v436, [05:13]) [ONCE] — EXACT (count = 2 bars).
- **Swing period default = 5** (adjustable to 20, 50) for swing-filter tools. (v423, "Retail Suck Indicator", [03:12]) [ONCE] — EXACT.
- **Delta divergence (bullish)** = new-or-equal low + positive delta + green candle (bearish = mirror). (v421, [01:25]) [REPEATED] — testable, fully specified.
- **Stopping volume** = bar volume "above average" / "heavy" at end of move; he reads ~1,000 contracts as strong on ES 1-min (e.g. 997, 1,018) vs recent 700–800. Threshold itself is qualitative → NEEDS-OPERATIONALIZATION (it's relative to recent bars). (v418, [03:38], [04:08]) [REPEATED]
- **Stopping-volume POC location** = heaviest volume (POC) at the BOTTOM of a green bar (top for a red bar). (v418, [04:39]) [REPEATED] — testable geometric rule.
- **Weakening-lows test:** volume per successive test of the same low should DECREASE (306 → 183 → 22 in the example). The decreasing-sequence rule is testable; the specific numbers are example-only → keep qualitative. (v417, [05:30]) [REPEATED]
- **Imbalance-reversal signature:** an aggressive (buy) imbalance + a passive opposite imbalance (big bid sold into) at a swing level. Example numbers 253 vs 1056, 1869 are illustrative only → NEEDS-OPERATIONALIZATION on the "big" passive size. (v425, [05:04]) [ONCE]
- **Fresh liquidity = "big size"** bid/offer NOT in the resting book (detected because price trades THROUGH it rather than it sitting in the DOM). "Big" is qualitative (example ~3,000 ES contracts over 3 min) → NEEDS-OPERATIONALIZATION. (v428, [06:24], [17:08]) [REPEATED]
- **Holding vs failing test:** fresh bid HOLDS if price does not get through it and starts trading above it; FAILS if it trades through quickly. A 1-tick / few-tick break through is tolerable ("not the end of the world"). (v428, [09:00], [14:12], [15:12]) [REPEATED] — testable.
- **Accumulation signature:** green bar where heaviest volume (POC) is on the BID side + buy imbalances + price holding (absorption); filter "passive traders in control." (v427, [03:32], [05:49]) [REPEATED] — testable.
- **Ratio types:** ratio bounds HIGH = price exhaustion; ratio bounds LOW = price defense. (v421, [04:12]) [REPEATED] — exact mechanism, ratio number itself "doesn't matter."
- **Bond tick value = $31.25** (1 tick); $3.125? — stated "3125 a tick" = $31.25. (v425, [10:35]) [ONCE] — EXACT (instrument fact).

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Orderflows Trader is a NinjaTrader 8 footprint with **~31–32 tools** ("Swiss army knife"); user can mix/match and build their own order-flow trading plan. (v423, "Retail Suck Indicator", [06:55], [08:49]) [REPEATED]
- **Thin-print zone drawing:** auto-draws zones for thin prints (volume of 1, settable to 3, 9, 10) so user doesn't have to judge; "draw out those zones for me." Mentions a "fast data processing feature" that must be disabled while drawing zones during testing. (v417, "Low Of The Day", [15:16], [15:59], [19:14]) [REPEATED]
- **Delta Divergence tool:** gold zones; v7 added green/red candle requirement + swing filter (swing-high/low divergences) + daily-high/low toggle. (v421, "Delta Divergence Ratios", [00:53], [05:51]) [REPEATED]
- **Ratios drawing:** only "ratios that matter" shown (bullish ratio below qualifying green candle, bearish above red); option to draw the ratio zone fixed or "until tested" so the red zone butts against the yellow/blue level for visibility. (v421, [03:34], [08:22]) [REPEATED]
- **Retail Suck tool:** colors chartreuse (bullish) / medium orchid (bearish), opacity 35; swing filter (linked to swing period 5); look-back filter; "draw until tested." Combine with Prominent Point of Control (1/2/3). (v423, [00:58], [03:12], [04:12]) [REPEATED]
- **Imbalance Reversal tool** (= trapped traders): uses 4:1 / 400% ratio; one of the original ~10-yr-old tools. (v425, [03:49], [05:04]) [REPEATED]
- **Accumulation/Distribution tool:** colors the price level/box where accum or dist occurs; add filter "passive traders in control." (v427, [05:49]) [REPEATED]
- **Multiple Imbalances tool:** under "Volume Imbalance," "enable multiple imbalances" → draws a box around bars with 3+ imbalances. (v435, [07:14]) [REPEATED]
- **Toolbox** (for candlestick users who won't use footprint): shows bars with 3+ imbalances on a normal candlestick chart. (v435, [10:24]) [ONCE]
- **Imbalance Reload tool:** "until tested," draws bullish/bearish zone over 2-bar reloads. (v436, [04:40], [07:53]) [ONCE]
- Other tools name-dropped (visible in his footprint): exhaustion prints, imbalance reload, sequencing, gap, open point of controls, prominent point of control. (v423, [09:31]; v425, [11:13]) [REPEATED]
- **Design philosophy:** built the software to auto-highlight things he'd otherwise "get lost in and miss"; goal = "put the data into an easy-to-read format" and act "as quickly as possible." (v425, [11:13]; v421, [10:21]) [REPEATED]

## Q. Notable verbatim quotes (3–10)
1. "heavy volume into the low couldn't go any lower strong negative Delta … can't push it lower." (v417, "Low Of The Day", [04:08]) — the core stopping-volume reversal read.
2. "the part that a lot of Traders Miss is … I got to get long and then what happens the market reverses … well why would you be getting long if we next bar can't even go any higher." (v417, "Low Of The Day", [18:14]) — invalidation rule.
3. "ratio bounds High indicates price exhaustion ratio bounds low indicates price defense … it doesn't matter what the ratio is as long as it's a red number on top to me that is a signal." (v421, "Delta Divergence Ratios", [04:12], [04:41]) — the ratio framework.
4. "once these Traders can't move the market higher essentially they're trapped … they run out of buying power and … it's a bit of fomo." (v425, "Identify Trapped Traders", [01:27]) — trapped-trader mechanics.
5. "people think that oh the Traders are trapped here and that causes big Market rally no it doesn't … there's plenty of exit liquidity." (v425, "Identify Trapped Traders", [09:32]) — contrarian nuance.
6. "if fresh liquidity comes in on the bid and it holds you're going to expect the market to go up … and it fails you're going to be looking for the market to go down." (v428, "Fresh Liquidity Holding And Failing", [01:53]) — holding-vs-failing rule.
7. "when a market is going sideways I don't put as much importance in stacked imbalances … as opposed to when a market starts breaking out." (v434, "Stacked Imbalances Volatile", [03:16]) — context-tiering.
8. "if you have a stack buying imbalance coming in at a swing low … the market sold off enough that you've attracted buyers into the market … that want to help take the market higher." (v434, "Stacked Imbalances Volatile", [10:54]) — why swing-context matters.
9. "I like to use a minimum of 10 … you don't want to be looking at imbalances unless they have some significance." (v436, "Imbalance Reload", [02:02]) — quality threshold.
10. "you want to be buying as close to the low as possible based off of what's taking place in the order flow … take advantage of it as quickly as possible." (v417, "Low Of The Day", [16:36]) — entry-timing philosophy.

## R. Contradictions / nuances
- **Anti-squeeze stance:** directly contradicts the common "trapped traders at the low caused the squeeze/rally" belief — markets have ample exit liquidity; a few hundred trapped contracts can't move a market trading thousands per bar. (v425, [08:27], [09:32]) [REPEATED]
- **Wicks ≠ trapped traders:** rejects the popular "big wick = trapped traders" read as "BS"; insists on footprint evidence. (v425, [02:50]) [REPEATED]
- **Holding vs failing asymmetry:** the SAME signal (big fresh bid) means opposite things — a HOLD often = reversal up, a FAIL = continuation down; you must wait to see which. (v428, [02:19]) [REPEATED]
- **Same level, opposite meaning:** stacked SELLING imbalance becoming the spot where aggressive BUYING appears = bullish (resistance-becomes-support), the inverse of treating that level as resistance. (v434, [05:16]) [ONCE]
- **Tool-context dependence:** Accumulation/Distribution works on rates (institutional) but he won't use it on equities; imbalance-reload doesn't work on 5-min+ charts — same concept, different validity by instrument/timeframe ("markets are fractal" but "concepts that only work on one specific chart type don't last very long"). (v427, [07:43]; v436, [11:28]; v427, [11:09]) [REPEATED]
- **Divergence is conditional:** a strong, reliable reversal signal at edges/swings, but "a recipe for disaster" alone in a trending market (just profit-taking). Must be paired with a ratio. (v421, [02:27]) [REPEATED]
- **Stopping-volume threshold is relative, not absolute:** "I understand this market, I know what heavy volume is" — refuses to give a fixed number; it's judged vs recent bars. (v418, [03:38]) [REPEATED]
- **He repeatedly disclaims picking reversals:** for accum/dist "it's not about trying to pick a reversal point, it's letting the market tell you" — yet the whole KB goal is reversal prediction; his framing is "react fast to what's printing now," not predict. (v427, [09:24]) [REPEATED]
- **Tolerance for minor breaks:** price trading 1 tick (sometimes 2–3 ticks) through a level/bid is "not the end of the world" — the level isn't invalidated by a small overshoot. (v428, [14:12], [15:12]) [REPEATED]

## Coverage note
Rich chunk. Richest for the model: v417 (low-of-day reversal reads, thin prints, weakening lows, next-bar confirmation/invalidation), v428 (fresh-liquidity holding-vs-failing — strong asymmetric reversal logic + wider-stop management), v434 (stacked-imbalance CONTEXT tiering at swings vs sideways), v425 (trapped-traders + valuable contrarian anti-squeeze nuance). v421 (divergence + ratio = exhaustion/defense) is dense on the signal framework. v418 (stopping volume) and v427 (accum/dist) give clean absorption definitions. v423 (retail suck), v435, v436 are more tool-demo / definitional but yield the exact numeric defaults (4:1, min vol 10, stacked=3, reload=2 bars, swing=5) and the sideways/breakout + timeframe filters. Nothing unparseable; all timestamps approximate per source.
