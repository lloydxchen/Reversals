# Chunk 100 Extraction
- Source chunk: Chunk_100_Orderflows_Transcripts.md
- Transcripts covered:
  - v411 — How To React To Size In The Order Book / Market Depth Map / BookMap And Footprint Chart (2024-02-08)
  - v412 — Order Flow Footprint Chart Types For Traders To Take Advantage Of The Information (2024-02-09)
  - v414 — How to read order flow footprint charts for trading Orderflows on NinjaTrader 8 (2024-02-12)
  - v415 — Order Flow Trading Strategy When The Market Defies You (2024-02-12)
  - v420 — Unlock The Potential of Orderflows Trader 7 Trade Setups (2024-03-03)
  - v422 — Orderflows Gaps Tool On Orderflows Trader 7 For NinjaTrader 8 (2024-03-10)
- Overall content value: rich (v414, v415, v420 especially; v411/v412/v422 mixed-to-thin on reversals but strong on context/filters and tool mechanics)

## A. Setup types & names he uses
- **Stacked imbalance (buying/selling)** — 3+ buying/selling imbalances stacked neatly on top of each other; bullish = stacked buying imbalance → market rallies; bearish = stacked selling imbalance → market sells off (v415, "When The Market Defies You", [01:19]–[01:47]) [REPEATED]
- **"When the market defies you" / failed-signal reversal** — bearish order flow (stack sell imbalance) appears but market refuses to go down → flip and go LONG; the failure itself is the signal (v415, [09:20]–[12:07]) [REPEATED — core reversal idea of chunk]
- **Delta-divergence + ratio setup ("ratio and Divergence", bearish ratio + bearish Divergence)** — his decade-long favorite-class setup; Divergence and ratio in same bar, OR Divergence then ratio in the very next bar (v420, "Orderflows Trader 7", [26:35]–[30:30], [1:06:41]) [REPEATED]
- **POC Wave (PLC wave)** — pattern of point-of-control migrating (green bar, then red w/ higher POC, etc.); trade the breakout of the wave high/low (v420, [07:32]–[14:57]) [ONCE-here]
- **Open Point of Control** — POC migrating higher as price goes higher (bullish) / lower (bearish); best when "abandoned" (not traded back into next bar) (v420, [40:35]–[46:40]) [ONCE-here]
- **Abandoned / "not traded back into" value area** — value area that price moves away from and does not re-enter next bar; he calls it the easiest, most visual setup (v420, [1:09:30], [1:26:09]) [REPEATED]
- **Market Weakness** (Orderflows tool) — bullish/bearish weakness print at swing highs/lows; trade the breakout (v420, [15:30]–[20:14]) [ONCE]
- **Orderflow Gaps** — gap between bar1 and bar2 on footprint; he reads gaps "as reversals" (gap up off a low = strong buying; gap down off a high = move lower) (v422, "Orderflows Gaps Tool", [01:52]–[02:27]) [REPEATED]
- **Exhaustion prints** — exhaustion volume print used after a move at a swing high/low for a potential reversal (v420, [21:16], [1:23:35]) [REPEATED]
- **Accumulation / Distribution (+ "passive traders in control")** — accumulation on the way up, distribution on the way down; "passive traders in control" filter turbocharges it (v420, [48:58]–[50:12], [1:28:38]) [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
- **"My favorite trade setup"** — explicitly DENIED a single favorite: "I don't have a favorite trade setup I sort of have a group of setups that I like to use"; the long-standing one is **ratio and Divergence** (v420, [25:55]–[26:35]) [REPEATED]
- **"The best imbalances don't get traded back into immediately"** — quality discriminator: an imbalance that is NOT re-traded next bar is higher quality; if price pulls back it should *hold* at the imbalance, not get to the other side of it quickly (v412, "Footprint Chart Types", [08:22]–[08:54]) [REPEATED]
- **"Usually a pretty high percentage trade"** — open POC that is **abandoned / not traded back into** in the next bar (v420, [44:57]) [ONCE]
- **"The easiest one I recommend... easiest to see is the abandoned value areas"** / "the easiest trades to take" / "the easiest setup to see is very visual is the abandoned value area" — visual simplicity = his recommended starting/best setup, esp. for S&P and NQ (v420, [1:06:00], [1:26:09]) [REPEATED]
- **"One of my favorites is... the orderflow gaps"** — for scalping quick moves, esp. currencies (v422, [09:15]) [ONCE]
- **"That's a great trade"** — applied to a clean dome short at size that ran 2 pts; conditional on having a wide enough stop (v411, [07:35]) [ONCE]
- **Tier-down language for stacked imbalance**: "if you have two usually that's not enough to qualify... you want to see three or more" (v415, [01:47]) [REPEATED]
- **Failed-setup grading**: he labels a Market-Weakness signal that fails as "set up in the order flow as potentially failing" — i.e. weakening Deltas (80, 65, 84, 54, 12) telegraph low quality / a short instead (v420, [18:12]–[18:40]) [ONCE] NEEDS-OPERATIONALIZATION (the exact Delta sequence is illustrative, not a stated threshold)
- Distinguisher across tiers: **immediate follow-through in his direction**. Highest-quality = market moves his way on the very next bar; lowest = next bar goes "inside" / re-enters the level (v420, [12:11]–[13:54]; v412 [06:16]–[07:49]) [REPEATED]

## C. Order-flow story & psychology per setup
- **Going lower on POSITIVE delta (v414 gold example)** — story: strong *passive sellers* (institutional supply) absorb aggressive buying; "the seller is going to run out of bullets or the buyer's going to run out of bullets"; when aggressive buyers exhaust, market drops naturally; institution doesn't clear bids, "let the retail do that," just steps offers lower (v414, "How to read", [10:11]–[14:38]) [REPEATED]
- **"When the market defies you"** — a bearish stack-sell imbalance that the market ignores is often just *someone getting out of a position* (e.g. ~250 lots), NOT fresh selling, NOT a stop; if it had been important order flow "the market technically should be trading a little bit lower." Market ignoring bearish info = bullish tell → get long (v415, [05:22]–[09:20]) [REPEATED]
- **Trapped traders — debunked as default explanation**: 250 contracts vs a bar trading 3,600 is NOT enough to "trap" anyone; trapped-trader logic only holds if volume is "overwhelming" (he contrasts vs a hypothetical 9,000 contracts) (v415, [06:14]–[06:49]) [REPEATED]
- **POC Wave story**: passive buyers absorb aggressive selling → aggressive selling dries up → aggressive buying steps in → higher POC, healthy move up (v420, [13:54]–[14:57]) [ONCE]
- **Exhaustion psychology**: "imagine you're running a race — you're not going to get exhausted in the first 10 meters... after you run half a mile that's when you start feeling exhausted"; look for exhaustion only AFTER a move, at swing high/low, for a reversal (v420, [1:23:35]–[1:24:48]) [REPEATED]
- **Resting-liquidity / size psychology**: "the market is attracted to size, size acts as a magnet"; big institutional sellers prefer to sell into a *rising* market (easiest to offload supply); so big resting offers in an uptrend are normal, not reliable resistance (v411, [04:44]–[05:45]) [REPEATED]

## D. Exhaustion clues
- **Aggressive buying slowing on the way up** — Deltas getting weaker as price rises (he reads 80 → 65 → 84 → 54 → 12 as fading); next bar fails to make a new high = buying exhausted (v420, [18:12], [20:14]) [ONCE] NEEDS-OPERATIONALIZATION
- **Exhaustion print volume limit** — Orderflows exhaustion-print tool has a "volume limit"; default 9, can be lowered to 3 (3 "a little too tight"); must occur after a move at swing high/low (v420, [21:16]–[22:30], [1:23:35]) [REPEATED] (numbers are tool *settings*, not market thresholds)
- "Aggressive buying starts slowing down, people who were long start taking profits" → the pause/sideways before reversal (v420, [20:14]) [ONCE]

## E. Absorption clues
- **Heaviest volume on the offer side while price rises** — in v414 gold, two heaviest volumes per bar repeatedly on the OFFER (e.g. 176 on offer, 1825, 25/181) = passive sellers absorbing aggressive buying (v414, [11:53]–[12:59]) [REPEATED]
- **Big single passive print** — "the big seller is finally showing his hand here 176" — a large offer volume marks where supply is absorbing (v414, [12:59]) [ONCE]
- **Price not advancing despite aggressive buying / positive delta** = absorption ("supply is coming into the market that's absorbing whatever aggressive buying is taking place") (v414, [10:11]–[10:45]) [REPEATED]
- POC-Wave absorption: "passive buyers in here absorbing whatever aggressive selling... then it's aggressive buying and you move higher" (v420, [13:54]) [ONCE]
- Absorption often hidden on a DOM because icebergs; footprint makes it "very clear" (v414, [13:35]–[14:07]; v411 [07:35] iceberg at 17: 209 then 526 reloading) [REPEATED]

## F. Stacked imbalance ideas
- Definition: 3+ same-side imbalances stacked contiguously; minimum 3, can be 3–7; two does NOT qualify (v415, [01:19]–[01:47]) [REPEATED]
- Cause: "a big order going through the market really quick" — e.g. "buy me 700 e-minis at the market"; institutions pay up, avg price acceptable because order moves the market (v412, [04:50]–[05:21]) [REPEATED]
- Time-frame dependence: stacked imbalances visible on 15s/30s/3-min disappear on 5-min because the market "had plenty of time to fill it in" — order flow is freshest on shorter charts (v412, [03:05]–[10:57]) [REPEATED]
- "Best imbalances don't get traded back into immediately"; on pullback it should HOLD at the imbalance (v412, [08:22]) [REPEATED]
- Default stacked-imbalance tool is among NinjaTrader Orderflows defaults; he toggles it off to declutter (v420, [31:08], [47:12]) [ONCE]

## G. Delta / delta-divergence ideas
- **Delta = aggressive buyers − aggressive sellers in a bar**; positive delta = aggressive buying overwhelming selling, negative = opposite (v414, [04:13]–[08:26]) [REPEATED]
- **"Going lower on positive delta" = supply creeping in** — the marquee reversal/continuation-down tell; he strings 4–5 consecutive positive-delta bars while price falls (e.g. +22, +22, +5, +24, +9, +86, +76) and treats it as supply absorbing buyers; "that should get your attention" (v414, [09:35]–[16:27]) [REPEATED] — strong, but the specific deltas are examples NEEDS-OPERATIONALIZATION
- **Max Delta** — blue color signals delta at its "Max Delta / strongest positive reading yet" while price goes lower = bearish absorption signal (v414, [10:11]; v415 [14:46] "Max M Deltas" listed as usable) [ONCE]
- **Delta Divergence tool** is the *only* default-enabled tool on load in Orderflows Trader 7 (v420, [02:34]–[03:12]) [ONCE]
- **Ratio + Divergence**: ratios set 30 and 69 (his kept defaults); Divergence at swing high/low then ratio same bar or next bar (v420, [26:35]–[30:30]) [REPEATED] — 30/69 are tool ratio settings, record exactly
- It's NOT enough to have one positive-delta bar; you "string bars together" (v414, [15:54]) [REPEATED]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Failed bearish signal → long** (v415 core): stack sell imbalance + market won't break down; next bar can't take out prior low; market starts to rally = "your sign to get long"; produced a 50-pt NQ move (he'd be happy with 20) (v415, [11:05]–[12:07]) [REPEATED]
- **Failed bullish signal → short**: stack buying imbalance up high, next bar opens near high, trades up 2 ticks to bottom of the stack imbalance, then sells off and closes on its low = "not interested in transacting at these prices up here" → short (12–14 pts in 30s) (v415, [12:34]–[13:40]) [REPEATED]
- **Resting liquidity / "jumping in front of size"** — large resting offers (e.g. 758, 782 contracts at 5015) repeatedly traded THROUGH, did not act as resistance; warns against fading size with a tight stop ("like jumping in front of a freight train") (v411, [02:30]–[10:27]) [REPEATED]
- **Iceberg detection at a level** — order reloads as it's hit (17 level: 334 → trades 209 off → another 526 on offer) = iceberg; don't assume it's a wall (v411, [07:35]) [ONCE]
- Possible stop-runs acknowledged but downplayed: "maybe it's a stop just got triggered up here... who knows" — he repeatedly refuses to assume stops without evidence (v415, [11:34], [12:34]) [REPEATED]

## I. Trapped-trader ideas
- He is **skeptical of the trapped-trader narrative** as a default: needs *overwhelming* volume to be real; 250 lots into bars trading 3,600 does not trap anyone (v415, [06:14]–[06:49]) [REPEATED]
- Resting liquidity is often someone *exiting* (taking profit), not a trapped/committed position — "it's nice to think every order is somebody getting into a position, but... people [are] constantly getting out" (v415, [02:42]–[03:39]) [REPEATED]
- Distinguishing exit vs fresh: a sell imbalance in an area "we had just been trading a few minutes before" → likely an exit, "I don't think it's fresh selling" (v415, [05:49]–[06:14]) [ONCE]

## J. Entry triggers (the exact "go" event)
- **"Let the market take you in"** — primary entry philosophy: place a **buy stop a couple/one-or-two ticks above the high** of the signal bar (or sell stop below the low) and let the breakout fill you (v420, [11:40]–[12:11], [18:12], [19:15]; v415 implied) [REPEATED]
- Failed-signal entry: when bearish info is ignored and the next bar starts rallying/can't make new low → go long on that rally (v415, [11:34]–[12:07]) [REPEATED]
- POC-Wave / Market-Weakness / Gaps entry: breakout above wave HIGH (long) / below wave LOW (short) (v420, [11:40], [12:39]–[13:54], [16:53]) [REPEATED]
- Time-based-chart tactic: use NinjaTrader **bar timer**; with ~10 seconds left in the bar and the order flow present, drop the buy/sell stop a tick or two beyond current high/low (v420, [18:40]–[19:43]) [ONCE]
- Stacked-imbalance trigger: take advantage "as soon as possible / the sooner the better" — order flow has a "sell-by date" (v412, [02:32]–[05:21]) [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Follow-through on the very next bar(s)** — "you want to see price go lower right over the next couple of bars"; one big order isn't enough, you need "some form of more aggression coming in" (v412, [06:50]–[07:49]) [REPEATED]
- **Bar should trade beyond the level, then HOLD** — for a short, next bar trades below the imbalance and stays below; "it holds here it holds here... it doesn't trade back into" (v412, [08:22]–[08:54]) [REPEATED]
- **"Going inside or not"** — a confirming bar trades INSIDE / through the level rather than re-entering; bars that "went inside" confirm continuation (v412, [07:20]–[07:49]) [REPEATED]
- For gaps: confirmation = **the SECOND bar must close** (gap is only confirmed once bar2 closes; on a range chart it's confirmed when the new bar opens) (v420, [35:30]–[37:47]; v422 [05:30]) [REPEATED]
- For the failed-signal long: market rallies and "can't even take out the low of the previous bar" then goes up = confirmation (v415, [11:34]) [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- **Signal bar's level gets traded back into immediately** — if a stack sell imbalance prints and the market is "trading above it at least immediately in the next bar... that's not a good sign" (this kills a SHORT, and flips to long) (v415, [08:55]–[09:20]) [REPEATED]
- **Next bar goes "inside"** instead of breaking your way → you're "not getting that follow through"; don't take it (v420, [12:39]–[13:54], [38:22]–[38:57]) [REPEATED]
- **Entering immediately on the open and price goes against you** — "you don't want to take those trades you want to take the trades where the market is moving in your direction" (v420, [38:57]–[39:22]) [REPEATED]
- **Abandoned POC/value-area direction check** — a BLUE (bullish) abandoned open POC must be trading ABOVE it; if price is below it, the long is invalid ("don't be like 'I got a blue abandon... trading below it I'm still going to get long' — no") (v420, [46:40]) [ONCE]
- Going-lower-on-positive-delta can FAIL if buyers don't run out / next bar still buys (he notes the Market-Weakness "potential short" failing because "there was still more buying to come in at that time") (v420, [18:40]) [ONCE]

## M. Stop / risk / target / trade management
- **Stop goes just below the wave/signal low** (for longs) / above the wave high (for shorts); the colored zone at top/bottom of the POC-Wave bar marks where to place the stop, "actually just below that" (v420, [09:12]–[09:48], [13:19]) [REPEATED]
- He repeatedly accepts **getting stopped out 1–3 times** as fine if one trade captures the big move ("even if you get stopped out once twice even a third time you just had a 12-point move") (v422, [03:35]–[04:55]; v420 [33:49]) [REPEATED]
- **Targets left qualitative** — "I'm not saying you'd get 50 points maybe you get 20, that's great"; cites moves like 50-pt NQ, 12-pt/20-pt MES, 12–14 pt 30-sec move, $8 gold move (v415, [12:07], [13:40]; v414 [09:35]; v422 [03:35]) [REPEATED] NEEDS-OPERATIONALIZATION (no fixed target rule)
- **Dome scalpers** typically risk small (2–4 ticks); fading size needs a wide stop (e.g. 2-point / 8-tick) or you get stopped (v411, [04:11]–[06:14], [10:01]) [REPEATED]
- No fixed R-multiple or position-size rule stated; he is "point-and-click," most automation he uses is "markers" (v420, [1:11:25]) [ONCE]

## N. Context filters (session/time, regime/volatility, levels)
- **Trade around the edges — swing highs / swing lows / highs / lows** is his repeated context filter; that's why the swing-period filter matters; exhaustion only counts at a swing extreme after a move (v420, [1:22:55]–[1:24:48]) [REPEATED — explicitly his "biggest thing"]
- **Order flow has a "sell-by date"** — freshest on short time frames; longer frames (5-min) fill in imbalances so you focus on different aspects (delta, POC, value) (v412, [02:32]–[10:57]) [REPEATED]
- **Trending vs technical/sideways regime** — a trending market "will ignore and plow through" technical levels AND order-flow signals; when the market ignores your order flow, "go with what is happening" (v415, [07:44]–[10:01]) [REPEATED]
- **Sideways detection**: overlapping value areas and POCs at the same price level = market going sideways; steadily rising/falling POCs = trend (v420, [1:09:30]–[1:10:45]) [REPEATED]
- **Chart-type per market** (volatility filter): interest rates (Ultra Bonds, 10s) need RANGE charts (time charts flatline); ES/e-mini trades "nicely" on time/short charts; NQ/MNQ too fast → he uses 30s; crude 8-range; he's abandoned 4-range on ES because price doubled (~5000 now) (v412, [00:54]–[09:31]; v420 [03:46]–[05:22], [47:12]) [REPEATED]
- **Session**: night/European session tradeable in rates because of arbitrage (10s vs bonds/Bunds/Gilts) and "strong volumes"; accumulation/distribution valid in European hours (v420, [52:36]–[54:23]) [ONCE]
- **News**: gaps/signals fire ~5–7 min after non-farm payrolls; data comes so fast "NinjaTrader can't even keep up" (v422, [07:53]–[08:34]) [ONCE]
- **Instruments**: ES/MES, NQ/MNQ, crude oil (CL), bonds/Ultra bonds, 10-yr, euro currency (6E), British pound, mini Dow (YM), gold, plus his "pet market" palm oil (Malaysia) (v420 throughout; v414 gold) [REPEATED]
- **Magnet effect**: market is "attracted to size" — big resting orders draw price toward them rather than repelling (v411, [04:44], [08:47]) [REPEATED]

## O. Directly testable / measurable variables
- **Stacked imbalance**: count of contiguous same-side imbalances ≥ 3 (min 3; 2 disqualifies; range 3–7 cited) — TESTABLE (v415, [01:47])
- **Imbalance ratio settings**: 30 and 69 (Orderflows ratio tool defaults he keeps) — record exactly; bullish vs bearish ratio (v420, [27:17]) NEEDS-OPERATIONALIZATION (these are his software's ratio params, not a derived market threshold)
- **Delta sign vs price**: price making lower lows while delta positive (≥4–5 consecutive positive-delta bars) = absorption/supply — TESTABLE direction; magnitude qualitative (v414, [15:54])
- **"Max Delta"**: delta at its highest reading-to-date in a swing while price diverges — TESTABLE if Max-Delta is computed per swing (v414, [10:11])
- **Abandoned / not-traded-back-into**: POC or value area from bar N not re-entered (no trade at that price) in bar N+1 — TESTABLE (v420, [44:57], [1:09:30])
- **Open POC migration**: POC price strictly higher (bullish) / lower (bearish) over a look-back of N bars (separate, non-global look-back) — TESTABLE; N user-set (v420, [40:35]–[42:31])
- **POC Wave**: 3-bar POC pattern (he confirms "looking on a three bar basis") — TESTABLE (v420, [56:52])
- **Orderflow Gap**: price gap between bar1 high/low and bar2 low/high on footprint; confirmed when bar2 closes (time) or new bar opens (range) — TESTABLE (v420, [35:30]; v422 [05:30])
- **Exhaustion print volume limit**: default 9; alt 3 (3 "too tight") — these are tool inputs; TESTABLE as a volume threshold but he doesn't justify a specific market value NEEDS-OPERATIONALIZATION (v420, [21:16], [1:23:35])
- **Swing-period filter**: global; he suggests 5 / 10 / 20 (5 = tight/faster, higher = bigger swings); used to localize signals to swing highs/lows — TESTABLE (v420, [11:05], [16:53], [57:29])
- **Entry trigger**: buy stop 1–2 ticks above signal-bar high (sell stop below low); on range charts may need 2 ticks since next bar already breaks by ≥1 tick — TESTABLE (v420, [12:11], [22:30], [19:15])
- **Follow-through window**: market should move in-direction within next ~1–2 bars (qualitative count) NEEDS-OPERATIONALIZATION (v412, [06:50])

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Detect imbalance per cell (bid vs diagonal ask) and flag **stacked imbalance ≥ 3 contiguous**; expose ratio param (defaults 30/69) and a minimum-stack count (v420, [27:17]; v415 [01:47])
- Compute **per-bar Delta** and a **"going-lower-on-positive-delta"** flag: price LL while delta > 0 for ≥4 consecutive bars (v414, [15:54])
- **"Abandoned" flag** for POC / value area: level from prior bar with zero (or no) trade in current bar → high-probability marker (v420, [44:57])
- **Open POC** module with its OWN look-back (not the global swing period) checking monotonic POC migration (v420, [41:59])
- **POC Wave** = 3-bar POC pattern with a drawn stop zone at top/bottom of the wave bar; "until tested" vs "fixed" draw modes (v420, [09:12], [26:35])
- **Orderflow Gaps** module; confirm on bar2 close; optional **swing filter** to only show gaps at swing highs/lows (v422, [03:02]–[03:35]; v420 [31:08])
- **Trade Entry Signal** logic baked into tools: emit a stop-order entry beyond the signal bar so "the market takes you in" (v420, [11:40]) — directly implementable as an auto-placed stop
- **Swing filter** as a reusable global look-back (5/10/20) applied across tools (Divergence, Market Weakness, Gaps, Accum/Dist) (v420, [09:48], [57:29])
- **Bar timer** display to time entries near bar close on time charts (v420, [19:15])
- **Exhaustion print** with adjustable volume limit + swing filter so it only fires at swing extremes after a move (v420, [1:23:35])
- **Accumulation/Distribution** with a "passive traders in control" qualifier to cut weak signals (v420, [48:58]–[50:12])
- Data: footprint needs only **level 1** on CME/CBOT/NYMEX/COMEX (level 2 not required); he pays ~$66/mo L1+L2; NT data ~$12/mo L1 (v420, [1:14:10]–[1:33:00]) — implementation/feed note
- Footprint draw order set to BACK so other indicators layer on top (NT layering note) (v420, [1:18:09])

## Q. Notable verbatim quotes (3–10)
1. "Stack selling imbalance should be bearish — market keeps going up — what do you think you want to do? You want to be long." (v415, [10:01]) — the failed-signal reversal in one line.
2. "It means that supply is coming into the market that's absorbing whatever aggressive buying is taking place... eventually one or two things is going to happen — that seller is going to run out of bullets or the buyer's going to run out of bullets." (v414, [10:45]–[11:22])
3. "You're going lower on positive Delta... maybe there's some supply creeping into this market that I could take advantage of." (v414, [16:27])
4. "The best imbalances don't get traded back into immediately... if it does pull back it should hold here... it doesn't hold, gets on the other side of it pretty quick." (v412, [08:22]–[08:54])
5. "I don't have a favorite trade setup, I sort of have a group of setups that I like to use — and one I've always talked about... is the ratio and Divergence." (v420, [25:55]–[26:35])
6. "I always like to trade around the edges of the market — meaning highs or lows or swing highs or swing lows." (v420, [1:22:55])
7. "If you're looking for exhaustion, imagine you're running a race — you're not going to get exhausted in the first 10 meters... that's when you're going to look for exhaustion, after the move has taken place, for a potential reversal." (v420, [1:23:35]–[1:24:48])
8. "Let the market take you in to a position... you drop a buy stop in a couple ticks higher than the high of this bar to get long." (v420, [11:40]–[18:12])
9. "Size attracts size, it attracts big traders... don't think you've got to jump in front of it and try to short it." (v411, [08:47]–[11:29])
10. "When what you expect to happen doesn't happen, you go with what is happening." (v415, [10:01])

## R. Contradictions / nuances
- **Order flow is best fresh, BUT** there are "breadcrumbs" on the footprint that swing/longer-frame traders can still use (5-min) — he qualifies his own "freshest = best" rule (v412, [10:28]–[11:27]) [REPEATED nuance]
- **Bearish order flow can be bullish information** — a stack sell imbalance ignored by the market becomes a long signal; the *absence* of expected follow-through is the edge (v415, [08:55]–[12:07]) [core nuance]
- **Anti-DOM stance**: contradicts common "look at the DOM/resting liquidity" belief — resting size is often pulled/iceberged/exiting and acts as a magnet, not resistance; footprint (executed volume) > intentions (v411 whole; v414 [00:00]–[01:01]; v415 [02:42]) [REPEATED]
- **Trapped traders / stops are over-used explanations** — he repeatedly says "who knows," needs *overwhelming* volume before believing the trapped-trader story (v415, [06:14], [11:34]) [REPEATED]
- **Positive delta normally = up**, but his key signal is the EXCEPTION (price down on positive delta) — "markets don't always exhibit common sense" (v414, [08:26]–[09:35]) [nuance]
- **"It depends"** dominates chart choice, swing period, range vs time — explicitly refuses universal numbers: "it's not for me to sit here and say this is what you have to use in this market on this chart type" (v420, [23:27], [59:22]–[1:00:04]) [REPEATED] — strong caveat that most of his numbers are user-tunable, not model constants.
- Range vs time charts change the setup: on a range chart EVERY next bar is a breakout (≥1 tick), so "going inside" invalidation only really applies on time charts; he suggests requiring 2-tick breakout on range charts (v420, [12:11], [22:30], [39:22]) [REPEATED nuance]

## Coverage note
Rich for reversal logic: v414 (going-lower-on-positive-delta / absorption) and v415 (failed-signal "defies you" reversal) are the model core; v420 is a long (14k-word) tool walkthrough — rich on setup *definitions, defaults, and context filters* but most "numbers" are software inputs (ratios 30/69, swing 5/10/20, exhaustion vol 9/3, look-backs) he stresses are user-tunable, not market thresholds, so flagged NEEDS-OPERATIONALIZATION. v411 (resting liquidity / anti-DOM) and v412 (chart types, imbalance freshness) are mixed — strong on context/quality discriminators, light on entries. v422 (gaps) is thin but gives the "gaps as reversals" framing and confirmation-on-bar2-close rule. No unparseable sections.
