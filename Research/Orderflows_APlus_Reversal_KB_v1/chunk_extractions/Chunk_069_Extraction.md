# Chunk 069 Extraction
- Source chunk: Chunk_069_Orderflows_Transcripts.md
- Transcripts covered:
  - v213 — "Flows Driver: A New Way To Analyze Order Flow With Orderflows" (2021-05-31)
  - v214 — "Orderflows Flowsdriver for Ninjatrader 8 Order Flow analysis made easy day trading futures" (2021-06-24)
- Overall content value: mixed (v213 rich on live reversal reading; v214 mostly indicator-settings demo, thin on model)

> NOTE: Both videos are demos of his "Flows Driver" indicator (buy = blue up-triangle, sell = red down-triangle). v213 has the most live order-flow reasoning, especially a parabolic reversal off a downtrend in British Pound and a bullish reversal off the lows in soy meal. The "reversal" content here is mostly **turn-from-downtrend / turn-off-low / turn-off-high** read live via delta, volume pickup, imbalances, absorption, and migrating POC. He never uses the phrase "A+" in this chunk.

## A. Setup types & names he uses
- **Parabolic move / parabolic reversal** — market stops a downtrend and goes "literally a vertical move straight up." His prime example: British Pound bottomed after lower-high/lower-low sequence then went parabolic up from ~141.85 to ~142.15 (v213, "Flows Driver", [25:32]–[34:06]). [REPEATED]
- **Reversal off the low of the day (bearish→bullish flip)** — soy meal example: at the low, he watches order flow "change from bearish to bullish" and looks to get long (v213, "Flows Driver", [56:51]–[1:01:20]). [REPEATED]
- **Reversal off the high of the day (bullish→bearish flip / failed high)** — silver night session: at the high of the day, no new aggressive buying being attracted → expects market to roll over and go lower (v213, "Flows Driver", [50:09]–[54:32]). [REPEATED]
- **Breakout-with-absorption (continuation, not reversal)** — breaking out of a range while passive bids absorb sellers trying to fade it back in (v213, "Flows Driver", [36:30]–[41:47]). [REPEATED]
- **Scalp that can "turn into a longer-term trade"** — enter as scalp, stay in via order flow if the move develops (v213, "Flows Driver", [34:40]–[35:13]). [ONCE]
- Bullish/bearish direction is specified for each above.

## B. Tiering / grading language  ← HIGH PRIORITY
- **"the worst trades that I take"** = trades that "immediately start going sideways or grinding against me" after entry; as a scalper, if it doesn't move in ~10 minutes it's probably not going to (v213, "Flows Driver", [10:21]–[10:49]). [REPEATED] — distinguishes a bad outcome: time-based failure.
- **"that's the bar that you love to take" / "those bars that you want to participate in"** = the big wide-ranging bar straight up, preceded 2 bars earlier by imbalances + strong positive delta + healthy volume (v213, "Flows Driver", [48:56]–[49:30], [207]–[215]). [REPEATED] — high-quality entry = clues present BEFORE the explosive bar.
- **"a good sign" vs "not a good sign"** — GOOD: POC migrating higher while long (market facilitating trade at higher levels). NOT GOOD: market pokes higher then trades heavier volume at LOWER levels (v213, "Flows Driver", [36:03]–[36:59]). [REPEATED]
- **"the worst thing that can happen"** = get to high of day and volume "just really dries up" → high won't hold, likely comes off sharply (v213, "Flows Driver", [50:50]–[51:21]). [REPEATED]
- **"very bullish if you know what to look for"** — soy meal at the lows where min-deltas shrink and max-deltas dominate (v213, "Flows Driver", [56:51]). [ONCE]
- **"prototypical bearish bar"** = max delta 0, final delta strongly negative (e.g. −55) — but he notes order flow then "changes" and it's NOT a reliable standalone (v213, "Flows Driver", [58:26]–[58:59]). [ONCE]
- **"a strong signal"** — silver flow-driver signal catching a move from 26.12 down to ~25.80/90 at 3-and-2 strength (v214, "Flowsdriver", [26:03 region]/[519]–[521]). [ONCE]
- **"better… you've filtered out a lot of the weaker… paper hand signals"** — higher strength setting (3-and-2) gives fewer but better signals; "the signals you're getting are better" (v214, "Flowsdriver", [25:32]/[517]). [REPEATED] — tiering of SIGNALS via strength setting.
- **Markets graded**: grains/ultra bonds/buns/soy meal described as markets whose moves are "cleaner," "easier to find," follow supply/demand "a lot better"; e-minis & NQ have "algo activity," "hot money," quick reverting moves — "a frustrating market to trade" (v213, "Flows Driver", [19:55]–[23:42], [44:45]–[45:45]). [REPEATED]
- Note: no use of "A+", "textbook," "perfect," "my favorite setup" in a reversal-grading sense (he says soy meal is "one of my favorites" as a *market*, [56:10]). Tier words are about bar quality / signal quality / market quality, not a named reversal grade.

## C. Order-flow story & psychology per setup
- **Parabolic up off a downtrend (British Pound)**: as price breaks out of the range, sellers are trying to "sell it back into the range," but passive bidders absorb the aggressive selling; once sellers "give up" / "no more bullets left," smart traders realize it and aggressive buying + buying imbalances drive it to new highs (v213, "Flows Driver", [37:27]–[39:50]). [REPEATED]
- **Reversal off the low (soy meal)**: at the low, aggressive selling "dries up" (tiny min-deltas), buyers start stepping in; market is "primed to rally" — he stresses it is NOT prediction of the exact low, the order flow simply tells you buying is already present (v213, "Flows Driver", [57:27]–[1:01:20]). [REPEATED]
- **Failed high (silver)**: at high of day, "new buyers aren't being attracted," no FOMO buying, negative deltas appear → no one to push it higher, so it rolls over (v213, "Flows Driver", [52:28]–[54:02]). [REPEATED]
- **Big-trader behavior**: real-money accounts (sovereign/pension funds) work bids AND lift offers to get filled "without trying to move the market" / "not tip their hand"; this finesse shows up as extra volume on bids and as absorption (v213, "Flows Driver", [41:47]–[43:41], [1:06:48]–[1:07:18]). [REPEATED]

## D. Exhaustion clues
- **At the high: volume "really dries up"** with no new aggressive buying → high won't hold, comes off sharply (v213, "Flows Driver", [50:50]–[51:21]). [REPEATED] NEEDS-OPERATIONALIZATION ("dries up").
- **At the high: zero/near-zero max delta** as a new high is made (no point where aggressive buyer is in control) = exhaustion of buyers (v213, "Flows Driver", [52:58]–[53:30]). [REPEATED]
- **At the low: aggressive selling exhausts** — min-deltas go tiny ("minus one minus eight zero zero") = "the selling seemed to have dried up" (v213, "Flows Driver", [57:27]–[57:54]). [REPEATED] NEEDS-OPERATIONALIZATION.
- **Sellers "gave up" / "no more bullets left"** — turning point in the parabolic breakout once absorption defeats the aggressive sellers (v213, "Flows Driver", [39:21]–[39:50]). [REPEATED] NEEDS-OPERATIONALIZATION.

## E. Absorption clues
- **Green (up-closing) bar with NEGATIVE delta = absorption / supportive buyers present**, NOT sellers in control: more sellers than buyers in the bar but it closed higher → someone bidding/absorbing the aggressive selling on the way up (v213, "Flows Driver", [36:59]–[38:00]). [REPEATED] — a core, repeated rule.
- **Up-closing bar with SELLING imbalances = sign of absorption** — sellers trying to fade the breakout back into range, but passive bids absorb; "when you start to see selling imbalances on candles moving higher it's telling you it's a sign of absorption" (v213, "Flows Driver", [40:16]–[41:15]). [REPEATED]
- **POC on the new bar LOWER than prior bar while the bar closes green** = market tried to facilitate trade lower but someone absorbed it and price went higher — he "likes" this (v213, "Flows Driver", [38:27]–[38:53]). [REPEATED]
- Concrete absorption example numbers (Brit Pound green bars): negative deltas −33, −107; selling imbalances 31 and 48 on up-closing bars (v213, "Flows Driver", [37:27], [38:53], [40:16]). [ONCE]
- **Inverse rule (v214)**: down-closing bar with POSITIVE delta = aggressive buyers hitting heavy passive supply = resistance; "you don't want to be buying into supply, or selling into support" (v214, "Flowsdriver", [09:42]–[11:21]). [REPEATED]

## F. Stacked imbalance ideas
- Imbalances (buying imbalances clustered on a bar) are a primary clue that "aggressive buyers are stepping in" and precede the pop to new highs (v213, "Flows Driver", [31:36]–[32:13], [39:21]). [REPEATED]
- He reads imbalances together with volume pickup + max/min delta + final delta as a confluence, not alone (v213, "Flows Driver", [32:13]–[32:46]). [REPEATED]
- No explicit numeric imbalance ratio (e.g. 3:1) stated in this chunk. NEEDS-OPERATIONALIZATION.

## G. Delta / delta-divergence ideas
- **Max delta** defined: "what the strongest delta was for a bar"; **min delta** = the most negative. He reads the *internal* max/min delta path, not just final delta (v213, "Flows Driver", [31:04]–[31:36]). [REPEATED]
- **Bullish reversal read**: min-deltas shrinking toward zero AND final/max delta turning positive and closing "on our max delta numbers or very very close to it" = buying present, market primed up (v213, "Flows Driver", [57:54]–[1:00:43]). [REPEATED]
- **Failed-high read**: small positive deltas + appearance of negative deltas (e.g. −13, −24) + max delta 0 at the high = no aggressive buyers (v213, "Flows Driver", [52:28]–[53:30]). [REPEATED]
- **Negative delta on an up bar is bullish (absorption), positive delta on a down bar is bearish (supply)** — his signature delta-vs-price "divergence" reinterpretation (v213 [36:59]; v214 [09:42]–[11:21]). [REPEATED]
- **Mixed bars** (positive final delta but with a notable min delta inside) are read as transitional/indecisive (v213, "Flows Driver", [58:26]–[58:59]). [ONCE]
- Delta-analysis filter (indicator): require up bar to have positive delta, down bar negative delta; filters out "a few" signals (v214, "Flowsdriver", [09:42]–[11:21]). [REPEATED]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Failed high of day** = price reaches HOD but volume dries up and no aggressive buying → high fails, sharp move down (v213, "Flows Driver", [50:50]–[54:32]). [REPEATED]
- He distinguishes a *genuine* breakout (supported by passive buying/absorption underneath) from a FOMO breakout (only aggressive buying chasing new highs) — the supported one is trustworthy, the FOMO one is the trap (v213, "Flows Driver", [41:15]–[42:18]). [REPEATED]
- No explicit "stop-run" / "liquidity sweep" terminology in this chunk. — limited —

## I. Trapped-trader ideas
- **Sellers trapped in a breakout**: traders shorting to fade price back into the range get absorbed by passive bids; when they capitulate, price accelerates up (v213, "Flows Driver", [37:27]–[39:50]). [REPEATED]
- **FOMO buyers at new highs / at the top** are implicitly the ones who get trapped when only aggressive buying (no support) is present (v213, "Flows Driver", [41:15]–[42:18]). [SPECULATIVE — he describes FOMO but does not explicitly say they get trapped here]
- Bitcoin-on-margin aside: people "finding out the reality of trading when the markets don't only go up" (v213, "Flows Driver", [02:50]). [ONCE]

## J. Entry triggers (the exact "go" event)
- **Flows Driver signal = the trigger**: blue up-triangle to get long, red down-triangle to get short (v213, "Flows Driver", [48:56], [1:03:07]; v214, "Flowsdriver", [00:32]). [REPEATED]
- **Trade-entry-signal confirmation rule (exact, testable)**: for a signal/triangle to print, the market must "move two ticks in the direction of the trade over the next two bars" (his default 2-and-2). Without that follow-through order flow, the zone forms but NO triangle prints (v214, "Flowsdriver", [33:12]–[35:36]). [REPEATED] — this is the closest thing to an exact "go" event with numbers.
- With trade-entry-signal ON, the triangle appears on the bar where follow-through order flow confirms (often 1 bar after the setup bar); this "kept you out of losing trades" where price didn't follow through (v214, "Flowsdriver", [34:41]–[35:36]). [REPEATED]
- **Manual scalp entry**: on a signal, "buy it on a pullback and scalp" (v213, "Flows Driver", [1:09:43]). [ONCE]
- Setup-bar precursor: the actual buy logic is "based off what's happening in these earlier bars" — imbalances + strong positive delta + healthy volume two bars before the explosive bar (v213, "Flows Driver", [49:30]). [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Two ticks in your direction within two bars** (the trade-validity rule) — otherwise the trade isn't validated (v214, "Flowsdriver", [33:12]–[33:41]). [REPEATED] — exact, testable.
- If long: **green bars**, **POC migrating higher**, **positive delta** (or negative delta WITH higher close = absorption), **higher volume at new levels** (v213, "Flows Driver", [36:03]–[36:59]). [REPEATED]
- As a scalper: the move should "happen right now"; if it goes sideways/grinds, it's likely a dud (v213, "Flows Driver", [10:21]–[10:49]). [REPEATED] NEEDS-OPERATIONALIZATION (he says ~10 minutes as a feel, not a hard rule).
- Long example tolerance: long at 90, "it only trades down to 89 and immediately shoots back up" — minimal adverse excursion is a good confirmation (v213, "Flows Driver", [35:41]–[36:03]). [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- **If long and you see "a bunch of red bars"** next → "chances are it's not going to work out" (v213, "Flows Driver", [36:03]–[36:30]). [REPEATED]
- **Market pokes higher then trades HEAVIER volume at LOWER levels** = thesis broken (POC should be rising) (v213, "Flows Driver", [36:30]–[36:59]). [REPEATED]
- **At a high with volume drying up / no aggressive buying** → long thesis dead, expect reversal down (v213, "Flows Driver", [50:50]–[53:30]). [REPEATED]
- **No follow-through order flow after the setup bar** → no valid trade (zone but no triangle) (v214, "Flowsdriver", [33:41]–[35:36]). [REPEATED]
- **Price trading into / through the signal "zone" on the wrong side** = get out; the zone's far side is the invalidation/stop line (v214, "Flowsdriver", [31:16]–[32:08], [37:34]). [REPEATED]
- Time-stop logic: scalp not moving in his favor "after 10 minutes" is worst-case and probably won't make the move (v213, "Flows Driver", [10:49]). [REPEATED] NEEDS-OPERATIONALIZATION.

## M. Stop / risk / target / trade management
- Every trade has an **ATM with predefined stop and predetermined take profit** attached (NinjaTrader ATM strategy) (v213, "Flows Driver", [1:36:38]–[1:37:19]). [REPEATED]
- Example sizing: short at 98, **3-point take profit at 95, 3-point stop**; "I tend to keep my stop a decent level away… always adjust it closer once it's in" (v213, "Flows Driver", [1:37:19]–[1:37:45]). [ONCE] — note these are illustrative ES points, not a fixed rule.
- **Reason for always-on stop**: "as soon as you get into a trade you don't know if the joker over at Goldman Sachs has got his finger on a button to buy 3,000 right after I get short" — markets can move instantly (v213, "Flows Driver", [1:37:19]–[1:37:45]). [ONCE]
- **Target-trailing by order flow**: if order flow keeps building (grinding higher with steam), he extends the target a point or two; but if it "just goes directly to your take profit," accept it (v213, "Flows Driver", [1:38:11]–[1:39:37]). [REPEATED]
- **Cautionary tale — "finessing yourself out"**: trying to inch the target (e.g. up to 03) can cause missed fills and ending up back at entry; sometimes better to keep initial TP (v213, "Flows Driver", [1:39:07]–[1:40:34]). [REPEATED]
- **Stop placement via signal zone** (indicator): place stop on the far side of the drawn zone; opacity/visibility configurable; signal-box width default 5, zone draw can be off (set to 0) (v214, "Flowsdriver", [30:39]–[32:08], [37:34]–[37:43]). [REPEATED]

## N. Context filters (session/time, regime/volatility, levels, instruments)
- **Day session vs night session**: night session (esp. ~01:00 when Europe opens) has real moves and "you don't have these algos messing around with you" that you see during the day; good for small retail size (v213, "Flows Driver", [46:54]–[47:30], [1:11:39]–[1:12:10]). [REPEATED]
- **Open / opening price as a magnet**: "the opening price acts as a magnet" — coming from above, expect rotation around it; from below, expect it to hang around that area (v213, "Flows Driver", [55:36]–[56:10]). [REPEATED]
- **High of day / low of day as decision points** — at HOD ask "are we going higher or coming off?"; at LOD watch for bearish→bullish flip (v213, "Flows Driver", [50:09], [56:51]). [REPEATED]
- **POC / point of control** migration (higher = bullish facilitation, lower = bearish/absorption-dependent) (v213, "Flows Driver", [36:03]–[38:53]). [REPEATED]
- **Regime matters for indicator choice**: don't use a range-bound indicator in a trend or a momentum indicator in a range; order flow shows you the shift before the move (v213, "Flows Driver", [01:14]–[01:50]). [REPEATED]
- **Volatility → indicator strength**: more volatile markets (NQ, mini Dow) need higher strength (up to 3) to avoid signal spam; deeper/liquid markets (ES) tolerate low settings (v214, "Flowsdriver", [04:58]–[07:38], [24:38]–[25:32]). [REPEATED]
- **Range bars discouraged for fast markets**: with range bars you "get in later than normal" because several bars form during a fast move; he prefers time-based (1-min / 30-sec) charts (v213, "Flows Driver", [1:05:18]–[1:06:48]). [REPEATED]
- **Timeframes he uses**: most trading off the **1-minute or 30-second chart**; NQ specifically on a **30-second** chart due to noise; also looks at 5-min but order flow is "best on a smaller time frame" (v213, "Flows Driver", [1:30:14]–[1:30:51], [1:30:51]–[1:31:31]). [REPEATED]
- **Preferred instruments for order-flow reversals**: currencies (FX futures), grains (soy meal especially, wheat, corn, soybeans), crude, nat gas, gold, silver, bunds, ultra bonds — "cleaner" moves, better supply/demand. AVOID/caution: e-minis & NQ (algos), bitcoin/micro bitcoin (insufficient volume — "you can't" use it on BTC), thin treasuries unless using the "tight markets" filter (v213, "Flows Driver", [22:04]–[23:42], [1:22:29]–[1:25:49]; v214, "Flowsdriver", [12:31]–[15:44]). [REPEATED]
- **News/holiday context**: Memorial Day = quiet, low volume; he repeatedly frames the day as "very quiet" / "a holiday" affecting move quality (v213, "Flows Driver", [00:03], [24:49]). [ONCE]

## O. Directly testable / measurable variables
- **Trade validity = 2 ticks of follow-through within 2 bars** (default "trade price level and ticks" = 2, "trade validity in bars" = 2); configurable e.g. 1 tick over 1 bar, or 2 ticks over 5 bars (v214, "Flowsdriver", [33:12]–[34:41]). EXACT, testable.
- **Up bar + negative delta → absorption / bullish; down bar + positive delta → supply / bearish** (computable per footprint bar) (v213 [36:59]; v214 [09:42]–[11:21]). Testable.
- **POC of current bar vs prior bar**: rising POC = bullish facilitation; current-bar POC lower than prior while bar closes up = absorption (bullish) (v213, "Flows Driver", [36:03]–[38:53]). Testable.
- **Max delta ≈ final delta near a turn-up** (closing on/near max-delta numbers) = buying present (v213, "Flows Driver", [1:00:05]–[1:00:43]). Testable, but "near" NEEDS-OPERATIONALIZATION.
- **Max delta = 0 at a new high** (no aggressive-buyer control) = exhaustion/failed-high flag (v213, "Flows Driver", [52:58]–[53:30]). Testable.
- **Min delta → ~0 at a low** (selling dried up) = bullish-flip flag (v213, "Flows Driver", [57:27]–[57:54]). Testable; threshold NEEDS-OPERATIONALIZATION.
- **Volume pickup vs prior bars** as confirmation — he reads specific bar volumes (e.g. 188, 372, 523 rising) but gives NO fixed threshold; says "average is probably around 30 contracts" on one silver example, calling 48 "a little above average" (v213, "Flows Driver", [30:31], [51:21]–[51:49]). NEEDS-OPERATIONALIZATION (the 30-contract "average" is example-specific, not a rule).
- **Indicator settings (testable knobs)**: Balance (0=off … up to ?); Balance Strength (1 min, 2 avg/default, 3 max); Swing Filter on/off with Swing Period (he likes 1, 3, 5, 9; some use up to 50); Delta Analysis on/off; Tight Markets on/off; Balance Equality on/off; signal-box width (default 5); zone opacity (20 default, 50 strong, not 100); triangle size (8 default). Recommended starts: ES & crude = **1 and 1**; most markets = **2 and 2**; NQ = **3 and 3** on a 30-sec chart; mini Dow more volatile → strength up to 3; grains/soy meal ~ **2 and 0** or **2 and 1**; treasuries/buns → enable Tight Markets (v214, "Flowsdriver", throughout [01:39]–[36:06]; v213 [1:04:11]–[1:05:18], [1:30:51]–[1:31:31]). EXACT settings, but they are indicator-tuning, not market-truth thresholds.

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- **Flows Driver runs on NinjaTrader 8 only** ("it doesn't run on anything else right now"); works on free NT8 with just a data feed (Kinetick / IQFeed / broker feed) (v213, "Flows Driver", [1:18:25], [1:25:49]–[1:26:51]). [REPEATED]
- Plots = blue up-triangle (buy) / red down-triangle (sell), colors and size configurable; works on footprint OR plain bar charts (v214, "Flowsdriver", [00:32]–[01:39]). [REPEATED]
- **Core inputs to model in an indicator**: Balance, Balance Strength, Swing Filter + Swing Period, Delta Analysis (confirming-delta filter), Tight Markets (for low-volatility/liquid markets), Balance Equality (handle exactly-equal bid/ask volume — the "what if delta == 0" programming edge case), Trade Entry Signal (require N ticks over M bars follow-through) (v214, "Flowsdriver", [01:39]–[35:36]). [REPEATED]
- Logic reads **internal volume in the bar relative to overall volume traded** — i.e. strength is volume-normalized, which is why weak-volume markets at a low setting spam signals (v214, "Flowsdriver", [05:30]–[06:06]). [ONCE] — useful design note.
- **Signal "zone" box** = drawn region marking where to enter and where the stop goes (far side of zone) — implies an entry-zone + invalidation-line output (v214, "Flowsdriver", [30:39]–[32:08]). [REPEATED]
- He frames the tool as automating the footprint analysis (imbalances, delta, volume, POC, absorption) so users needn't read footprints manually: "we put a lot of that analysis… already inside the algo" (v213, "Flows Driver", [1:04:46]–[1:05:18]). [REPEATED]
- **Suited for scalpers/day traders only**, explicitly NOT swing/long-term traders (v213, "Flows Driver", [1:03:36], [1:17:52]; v214, [00:32]). [REPEATED]
- Cannot be used on crypto (CME bitcoin / micro bitcoin) due to thin/erratic volume; NT/crypto-exchange data integration is poor (v213, "Flows Driver", [1:22:29]–[1:24:42]). [REPEATED]

## Q. Notable verbatim quotes (3–10, each with citation)
- "Just because you have a green bar with negative delta doesn't necessarily mean sellers are in control… it actually has an opposite meaning, it tells you supportive buyers are present." (v213, "Flows Driver", [36:59]) [REPEATED]
- "When you start to see selling imbalances on candles moving higher, it's telling you it's a sign of absorption." (v213, "Flows Driver", [40:45]) [REPEATED]
- "The sellers finally gave up… once the sellers gave up the smart traders realized the sellers got no more bullets left, and the market starts moving higher." (v213, "Flows Driver", [39:21]) [REPEATED]
- "The worst thing that can happen is you get up to the high of the day and volume just really dries up… if nobody's interested in participating at the high, chances are that high's not going to hold." (v213, "Flows Driver", [50:50]) [REPEATED]
- "It's not trying to predict that we're going to come down… then rally. No, the order flow's telling you that this market is primed to rally." (v213, "Flows Driver", [1:01:20]) [REPEATED]
- "For a signal to occur, for an actual trade to be valid, the market has to move two ticks in the direction of the trade over the next two bars." (v214, "Flowsdriver", [33:12]) [REPEATED]
- "You don't want to be buying into supply, or selling into support." (v214, "Flowsdriver", [11:21]) [REPEATED]
- "As soon as you get into a trade you don't know if the joker over at Goldman Sachs has got his finger on a button to buy 3,000 right after I get short, so you gotta have a stop in there." (v213, "Flows Driver", [1:37:19]) [ONCE]
- "If it's not happening after 10 minutes… those are the worst trades that I take, the trades that I get in and they immediately start going sideways or grinding against me." (v213, "Flows Driver", [10:21]) [REPEATED]

## R. Contradictions / nuances
- **Negative delta is not automatically bearish** (and positive delta not automatically bullish): meaning flips depending on where the bar closes — this contradicts naive delta interpretation and is central to his read (v213 [36:59]; v214 [09:42]). [REPEATED]
- **He explicitly disclaims prediction**: order flow tells you buying/selling is *already present* ("primed to rally"), it does NOT call the exact high/low — he says repeatedly he's "not trying to pick a low/high" (v213, "Flows Driver", [56:51], [1:01:20]). [REPEATED]
- **Settings are deliberately not prescriptive**: he refuses to give firm settings — "every market is different and every trader is different"; even after recommending 1-and-1 for ES he hedges "there's nothing wrong with one and one" (v214, "Flowsdriver", [23:39]–[24:05], [29:35]–[30:03], [36:06]–[36:35]). [REPEATED] — caution against over-fitting fixed thresholds.
- **Time-stop is a feel, not a rule**: "~10 minutes" is how he personally judges a dud scalp, not a hard parameter (v213, "Flows Driver", [10:49]). [ONCE]
- **NQ volatility nuance**: people call NQ "more volatile than ES," but he notes there's a ratio (ES moves 2 ticks, NQ moves 10) and NQ "reverts right back in the next couple of bars" — so apparent volatility ≠ tradability (v213, "Flows Driver", [20:55]–[21:31], [45:12]). [REPEATED]
- **"Tight Markets" filter is a pragmatic kludge**: he admits they "went back and forth" on whether to just hardwire it; it exists for low-volatility/very-liquid markets (treasuries) where otherwise you get no signals (v214, "Flowsdriver", [13:39]–[14:41]). [ONCE]
- **Balance Equality edge case**: a philosophical/programming nuance — what to do when bid vol exactly equals ask vol (delta = 0); "I want to take those" but it's optional (v214, "Flowsdriver", [17:34]–[18:58]). [ONCE]
- These are demos on a **quiet holiday / low-volume sessions**, so move quality and volume numbers are not representative — flagged by him repeatedly (v213, "Flows Driver", [24:49], [42:48]). [SPECULATIVE caveat on data quality]

## Coverage note
v213 is rich for live reversal reading (parabolic-up off a downtrend, bullish flip off the soy-meal low, failed-high in silver) with concrete delta/volume/imbalance/POC/absorption reasoning, plus stop/target management. v214 is thin on model and mostly Flows Driver settings, but yields the one EXACT testable trigger rule (2 ticks / 2 bars follow-through) and the absorption/supply delta rule. Both are product demos on a quiet holiday + overnight sessions, so volume figures are example-specific, not thresholds; no use of the literal "A+" grade in this chunk.
