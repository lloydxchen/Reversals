# Chunk 061 Extraction
- Source chunk: Chunk_061_Orderflows_Transcripts.md
- Transcripts covered:
  - v195 — How To Make Sense Of Order Flow Trading Order Flow On NinjaTrader 8 (2020-12-26)
  - v196 — Find Winning Trades In The Order Flow with Michael Valtos (2021-01-05)
- Overall content value: rich (heavy applied chart-reading on prior-day footprints; strong on imbalances, sweeps, Delta shifts, prominent POC; weak on exact thresholds/stops — mostly qualitative + sales pitch padding)

## A. Setup types & names he uses
- **Reversal at swing low / low-of-day via multiple buying imbalances** — bullish; aggressive buyers step in after a sell-off and cause buy imbalances clustered over several bars (v195, "Make Sense Of Order Flow", [17:46], [25:48]). [REPEATED]
- **Reversal at swing high / high-of-day via multiple selling imbalances** — bearish; aggressive sellers step in at a high (v195, [22:07], [28:24]). [REPEATED]
- **"Multiple imbalance bar" setup** — his signature: a single bar with 3+ imbalances NOT necessarily stacked, spread across price levels; the early-warning version of a stacked-imbalance setup (v195, [26:00]; v196, "Find Winning Trades", [30:38], [31:09]). [REPEATED]
- **Stacked imbalance setup** — 3+ imbalances neatly stacked on consecutive price levels; he says most traders use this but it fires "after the move" (v196, [30:38], [32:14]). [REPEATED]
- **Market sweep setup** — aggressive trader clears multiple price levels of resting liquidity; "where it gets juicy is when a sweep occurs and there's no stacked imbalance" (v196, [37:41], [44:10]). [REPEATED]
- **Prominent Point of Control (PPOC) reversal / support-resistance** — POC appearing at/near the edge of a bar = resting liquidity / stopping volume that acts as S/R and reverses price (v196, [49:31], [50:00]). [REPEATED]
- **Delta-shift reversal (bottom/top)** — Delta flips from negative-to-positive at a low (or positive-to-negative at a high) signaling exhaustion (v196, [55:06], [1:05:30]). [REPEATED]
- **Bullish / Bearish "Market weakness"** — Delta-based exhaustion tool; named setups (see D) (v196, [1:05:30]). [ONCE in this chunk]
- **Absorption-then-rally** — buyer absorbs offers at a low, no new lows, then Delta turns positive (v196, [1:02:31]). [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
- **"low-risk trade setup" / "low-risk trading opportunity"** — his core quality bar; recurs as the goal. What makes it low-risk: entering at the swing low/high right as aggressive imbalances appear so the stop sits just beyond the extreme (v195, [00:35], [26:27], [38:43]; v196). [REPEATED]
- **"very good buying opportunity" / "great buying opportunity"** — used when buyers come in "with a Vengeance" off a level (v195, [20:05], [37:11]). [ONCE each]
- **"this is the bar you want to be short on" / "the trade you want to take"** — he singles out THE specific bar (the multiple-imbalance or sweep bar) vs adjacent bars (v196, [34:07], [43:08]). [REPEATED]
- **"better entry"** — the swing-low entry is graded better than adding after a move; "the better entry is going to be at the swing low rather than after a move up" (v195, [30:40]). [REPEATED]
- **"where it gets juicy"** — top-grade scenario = a sweep with NO stacked imbalance, because almost no one watches for sweeps (v196, [44:10]). [ONCE]
- **"one of my favorite pictures"** — a chart showing a big trader sweeping the order book (v196, [42:09]). [ONCE]
- **"that's not very helpful" / "what good is that"** — DOWN-grades stacked imbalances that appear only AFTER a 25-cent move; late = low value (v196, [30:38]). [REPEATED idea]
- **Tier distinguisher (verbatim model):** the difference between a good and a poor signal is **WHERE in the move it appears** (early at the swing point = high grade; late/after the move = low grade) and **CONTEXT** ("don't run out and trade every bar with multiple imbalances… put everything in context") (v195, [29:20]; v196, [33:41]). [REPEATED]
- Note: No literal "A+", "textbook", "perfect", "mediocre", "marginal" language in this chunk. The grading axis here is low-risk/early/in-context vs late/out-of-context. NEEDS-OPERATIONALIZATION (what bar-count or distance counts as "early").

## C. Order-flow story & psychology per setup
- Markets move because **aggressive traders** (those who cross the spread and lift offers / hit bids), NOT because there are "more buyers than sellers"; passive bids/offers only create S/R (v195, [09:09], [11:32]; v196, [28:35]). [REPEATED]
- At a low: sellers have pushed price down, then a level "attracts buyers… people thought the market was cheap and came in with a Vengeance" — aggressive buyers eat through resting offers ("damn the torpedoes… offer me more at this price") (v195, [20:05], [37:11]). [REPEATED]
- Distribution at a high: "the market rallied, now people are going to be distributing, getting out of their position, they've got more inventory to sell, happy to sell it on this little rise up" — seen as mostly-negative Delta at a swing high (v196, [58:24]). [ONCE — key tell]
- Exhaustion psychology: "aggressive sellers could be running out of their bullets, they got no more to sell"; selling "is done… they got no more inventory to sell" → market ready to rally (v196, [1:01:03], [1:02:31]). [REPEATED]
- Big-trader behavior (his own desk experience): when you see big size you HIT it / sweep it because your size will move the market — so a big resting bid is NOT bullish (counterintuitive) (v195, [10:38], [11:07]). [REPEATED]
- Why sweeps happen: "we want to get into the market as soon as possible, we think the market's about to move and we don't want to miss anything"; big traders book at average price, not individual levels (v196, [39:46], [40:11]). [REPEATED]

## D. Exhaustion clues
- **Bullish market weakness** = market has been going DOWN but "the selling just tapers off and is exhausted… it's the selling that's getting weak, not the buying," until buyers take control (v196, [1:05:30], [1:06:00]). [REPEATED] NEEDS-OPERATIONALIZATION (how much taper = "weak").
- **Bearish market weakness** = market going UP but "can't sustain the move higher, the buying is weakening… no more strong buyers" (v196, [1:05:30], [1:07:01]). [REPEATED]
- Test for exhaustion: "is the aggressive buying getting stronger or weaker as the market is going up?" — watch Delta magnitude trend (v196, [1:07:27]). [REPEATED]
- v195 mentions the orderflows trader shows **price exhaustion** as a tool but no mechanics given (v195, [40:44]; v196, [1:10:01]). [ONCE]

## E. Absorption clues
- At an e-mini low: strong negative Deltas STOP appearing; price "not really going anywhere, we're not going lower — someone's coming in now and absorbing the selling… they're buying the bid (working bids) but they're also buying the offers right when these sellers are offering it out," then strong positive Delta → rally (v196, [1:02:31]). [ONCE — clearest absorption description in chunk]
- Buyers eating large resting offers = absorption-style: "almost 2,000 contracts on the offer here at '08 but buyers ate through it" (v195, [37:11]). [ONCE]
- Bonds: "19,000… 18,000… 20,000… 12,000" resting on the bid that selling has to chew through — heavy size as absorption capacity (v196, [52:06]). [ONCE]

## F. Stacked imbalance ideas
- Stacked imbalance = "three or more imbalances stacked on each other" on consecutive price levels (v196, [29:59], [32:14]). [REPEATED]
- He DOWN-weights pure stacked imbalances because they often print late, after the bulk of the move (25-cent example) (v196, [30:38]). [REPEATED]
- Prefers **multiple-imbalance bars** (3+ imbalances spread, not neatly stacked) to catch the move "three points… not three ticks… earlier" (v196, [31:09], [33:41]). [REPEATED]
- Imbalance ratio: "industry standard is 4:1, some use 3:1, 5:1, 10:1… 9.87:1… it's up to you"; he runs his shown charts at **3:1** in v195 and cites **4:1** as the default starting point in v196 (v195, [15:04], [15:39]; v196, [24:13]). [REPEATED] — EXACT numbers.
- Imbalance examples (verbatim, applied): 14 vs 139 ≈ "9.8:1"; 6 vs 43; "19 against 56 is NOT 4:1"; 3 vs 34 ≈ "10:1"; 3 vs 19 ≈ "6:1"; 6 vs 42 ≈ "7:1"; "14 against… about 5:1" (v196, [24:13], [31:40]). [ONCE]
- A bar with "literally half the bar is buying imbalances" over 5–7 price levels = aggressive sellers stepped in / expect a rally (v195, [17:15]). [ONCE]

## G. Delta / delta-divergence ideas
- Delta = net difference between aggressive buyers and aggressive sellers in a bar; positive = aggressive buyers in control, negative = aggressive sellers (v195, [14:30]; v196, [20:50], [54:33]). [REPEATED]
- **Delta shift** at extremes signals reversal: at a low, sequence flips from negative to positive (e.g. "-12,000 … -4,000 … -300 … +7,000" in 10yr → long); at a high, positive flips negative (v196, [55:06], [58:55], [1:01:30]). [REPEATED] — numbers are instrument-specific (10yr ZN), not generic thresholds.
- **Neutral Delta** = small values "could be either way," e.g. "-184, -159, -262… -2 is nothing" — he treats near-zero / mixed Delta as no signal (v196, [58:24], [1:03:03]). [ONCE] NEEDS-OPERATIONALIZATION (no numeric neutral band).
- Divergence-style tell: green (up) bars but NEGATIVE Delta at a swing high = distribution / bearish; "still got green bars… but you see negative Delta" (v196, [57:52], [58:24]). [ONCE — important]
- In-trade use: if long and market stalls with negative Delta, "market could be getting heavy, ready for a drop"; exit early rather than take full stop (v196, [57:00], [57:27]). [REPEATED]
- Caveat he flags: Delta sign usually matches direction "but not always… there's cases where it's the opposite, that's a whole another webinar" (v196, [55:34]). [REPEATED] [SPECULATIVE which cases]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Market sweep** = aggressive buyer lifts the offer with the next-best offer behind it, OR aggressive seller hits the bid with next bids below; a single order clearing multiple levels of resting liquidity (v196, [38:40], [38:11]). [REPEATED]
- On time-and-sales a sweep looks like one side clearing consecutive levels in ~1 second (e.g. 86½ bid swept down to 86 even) (v196, [38:40], [19:21]). [ONCE]
- Sweeps + stacked imbalances "can and do overlap because they're both very aggressive market behavior," but the high-value signal is a **sweep with NO stacked imbalance** because almost no one watches sweeps (v196, [44:10]). [REPEATED]
- Sweep in CONTEXT: don't trade every sweep — "if you'd be getting short in here 92 93 it made its nice move down to 83" only because it aligned with the move (v196, [43:40], [44:10]). [REPEATED]
- Pin-bar / hammer false signal: a hammer at a low with NO supportive order flow is a trap — "why should you take this trade if there's nothing in the order flow to tell you to be getting long" (v195, [18:47], [19:10]). [ONCE]
- "Just because you hit the low of the day and got a green bar doesn't automatically mean the market's going to reverse — you need aggressive buyers to come in" (v195, [32:03]). [REPEATED]

## I. Trapped-trader ideas
- Trader who jumps in front of a big resting bid thinking "there's a big buyer, market must go up" gets run over when the big size is actually a seller who hits it — "one of the deadliest things to do" (v195, [10:11], [10:38]). [REPEATED]
- Bias-trapped trader: someone who "had a bias to be long the S&Ps… bought, lost, bought again, lost" by fighting order flow on a down day (v196, [00:32], [47:29]). [REPEATED — recurring anti-pattern]
- Buyer trapped at the wrong spot: buying the bump after the cash open ("pin bar… green bars, looks bullish") while order flow shows aggressive selling/sweeps/weakness → should be shorting (v196, [13:17], [13:43]). [ONCE]

## J. Entry triggers (the exact "go" event)
- **Long trigger:** at a swing low / low-of-day, the appearance of a bar (or cluster of bars) with **multiple buying imbalances** (3+) — ideally the bar right AFTER the actual low — confirming aggressive buyers (v195, [32:34], [34:41]; v196, [33:41]). [REPEATED]
- **Short trigger:** at a swing high / high-of-day, a bar with **multiple selling imbalances** (3+) as price breaks down (v195, [31:35], [34:37]). [REPEATED]
- **Market-sweep trigger:** enter on the bar where the sweep prints (e.g. "getting short here 4830… 4825") in the direction of the sweep, in context (v196, [43:08]). [REPEATED]
- **Delta-shift trigger:** the bar where Delta flips to your direction at an extreme ("you see plus 7,000 in the Delta, you get long here at 28") (v196, [1:01:57]). [ONCE]
- **PPOC trigger:** buy as soon as the bar forms a prominent POC / stopping volume at a low, not after price re-breaks the high ("why wait, get long here at 47 47 rather than 4757") (v196, [54:33]). [REPEATED]
- General principle: "let the market tell you the low/high has been made… I'm not trying to predict/pick the low" — wait for the order-flow confirmation, don't anticipate (v195, [16:11], [35:55]; v196, [1:01:30]). [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- The move should start FAST: "I like my trades to start moving pretty quick"; sweep example "two bars later it's trading 4750/4770" from ~4830 short (v196, [43:08], [43:40]). [REPEATED]
- Follow-through imbalances/Delta should keep appearing in your direction (e.g. after the long trigger, "more aggressive buying coming in 27 against 586… it just moves higher") (v195, [33:04]). [REPEATED]
- After a low-of-day long: should see buying imbalances cluster "over a series of bars" and price rally ~10 points (e-mini example) (v195, [27:01], [26:00]). [ONCE]
- A sweep should give "further confirmation" via a following bar of sweeping/imbalance in the same direction before the big move (v196, [41:39]). [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- If long and you start seeing **selling imbalances** building underneath / against you: "that's not a good sign… conditions have changed" → exit (v196, [23:18], [23:44]). [REPEATED]
- If long and Delta turns/ stays **negative** while price stalls: market "getting heavy," get out early rather than take full stop (v196, [57:00], [36:44]). [REPEATED]
- If short and you see **positive Delta bars** coming in while price no longer falls: sellers "out of bullets," cover — thesis dead (v196, [1:01:03]). [REPEATED]
- A **bullish sweep** appearing after you've gone short (or bearish sweep after long) = cut it: "I better cut it now… cut my losses small" (v196, [45:38], [46:02]). [REPEATED]
- PPOC line as the "Line in the Sand": "if we get past this, the whole reason for being in the trade is over, I could get out" (v196, [54:33]). [ONCE — explicit invalidation rule]
- Order flow turning opposite right after entry: "you get long but then all of a sudden the order flow is bearish… you could get out earlier rather than taking a full stop" (v196, [05:12]). [REPEATED]

## M. Stop / risk / target / trade management
- Stop placement: just beyond the swing extreme. Short example: "getting short at 25, a nice three-point stop… above 28," explicitly preferred over shorting late at 17/18 "having a stop twice as big" (v196, [34:37], [35:10]). [REPEATED] — EXACT (3-point stop example).
- Long PPOC stop: "stop just right below this support area… that's my Line in the Sand" / "below here at 4750, 20 ticks" (v196, [54:33], [56:03]). [ONCE] EXACT (20-tick example, instrument-specific).
- Risk:reward stated qualitatively: "risking a couple points to capture… at least one-to-one, hopefully two-to-one, maybe three-to-one" (v195, [38:43]). [ONCE] — ranges, not a fixed rule. NEEDS-OPERATIONALIZATION.
- Core management edge = **early exit on order-flow reversal** to "cut your risk almost in half" rather than waiting for the hard stop (v196, [37:10], [56:35]). [REPEATED]
- Adding: you "can always add on at various levels on the move up… nothing wrong with that, I do that," but the primary/better entry is the swing point (v195, [30:40]). [ONCE]
- Targets: largely "the whole entire move of the day to potentially capture and more if it keeps continuing" for a reversal caught at the turn (v196, [02:33]). [ONCE] — no fixed target rule. NEEDS-OPERATIONALIZATION.

## N. Context filters (session/time, regime/volatility, levels)
- **Cash open** is a key time for equities — "market's trying to find its footing… which way is the order book leaning"; watch first 5 minutes for the lean (v195, [31:04], [37:43]; v196, [13:17]). [REPEATED]
- Trade WITH the direction of the market; don't fight a trend (down day = look to short) (v196, [00:32], [13:43]). [REPEATED]
- **Market context = puzzle:** buy at swing lows (point C after a down move), short at swing highs; do NOT sell after a big move down or buy after a big move up (v195, [29:47], [30:16]). [REPEATED] — primary filter.
- Instruments where order flow / S&R works BETTER: **physically deliverable** futures (bonds ZB, 10yr ZN, ultra bonds) vs cash-settled (e-mini, NASDAQ micros) "tend to follow support and resistance a bit better" (v196, [51:30]). [ONCE — notable claim]
- Liquidity/volatility caveat: 10yr ZN is huge size but low volatility ("19,000 to get through… people get bored"); thinner markets (gold) need **adjusted sweep settings** vs e-mini/crude (v196, [44:42], [52:06]). [REPEATED idea — settings vary by market]
- Markets discussed (applied, prior-day): e-mini S&P, micro NASDAQ (MNQ), crude oil (CL), Japanese Yen, wheat, gold, bonds (ZB), 10yr (ZN), ultra bonds, euro currency (v195 & v196, throughout). [REPEATED]
- Tools must be tuned per instrument (imbalance ratio, sweep sensitivity); default template = **e-mini 1-minute chart** (v196, [1:10:30]). [ONCE]
- Works "every day in pretty much every single market" and "every time frame" (1-min charts shown most) (v196, [03:24], [33:41]). [REPEATED]

## O. Directly testable / measurable variables
- Imbalance ratio threshold: **3:1** (used in v195 shown charts) and **4:1** (default), with 5:1 / 10:1 mentioned as options (v195, [15:04]; v196, [24:13]). EXACT — directly testable input.
- "Multiple imbalance bar" = a bar with **≥3 imbalances** (not required to be stacked) (v196, [29:59], [33:41]). EXACT count.
- "Stacked imbalance" = **≥3 imbalances on consecutive price levels** (v196, [32:14]). EXACT.
- Buy setup: ≥3 buying imbalances clustered over a series of bars at/after swing low; Sell setup: ≥3 selling imbalances at/after swing high (v195, [26:00], [34:41]). Testable; cluster span NEEDS-OPERATIONALIZATION.
- Delta sign per bar: positive vs negative (control); near-zero = "neutral" (no numeric band given — NEEDS-OPERATIONALIZATION) (v196, [54:33], [1:03:03]).
- Delta shift = sign flip (neg→pos at low, pos→neg at high) at an extreme (v196, [55:06]). Testable as a sign-change detector.
- "Market weakness" = trend of Delta magnitude tapering (decreasing |Delta| against the trend); bullish=selling tapers, bearish=buying tapers (v196, [1:05:30]). NEEDS-OPERATIONALIZATION (no % or bar-count taper threshold).
- Point of Control = price level with most volume in a bar; **Prominent POC** = POC at/near a bar edge (not center) = resting liquidity / stopping volume / S&R (v196, [21:22], [49:31]). Testable: edge-vs-center POC location.
- Market sweep = single order clearing ≥2 consecutive resting price levels on one side (v196, [38:40]); sweep sensitivity must be adjusted for thin markets (gold) (v196, [44:42]). Testable; threshold NEEDS-OPERATIONALIZATION.
- Stop = a few ticks/points beyond swing extreme (3-pt and 20-tick examples; both instrument-specific) (v196, [35:10], [56:03]). NEEDS-OPERATIONALIZATION (no universal multiple).
- R:R = 1:1 to 3:1 target range (v195, [38:43]). NEEDS-OPERATIONALIZATION.

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Platform: **NinjaTrader 8** only (his Orderflows Trader 3.0 add-on); does NOT support TradeStation, thinkorswim, Sierra Chart; works on free NT8 version + data fees (v195, [39:44], [40:44]; v196, [1:09:01], [1:23:34]). [REPEATED]
- **17 pre-programmed order-flow tools** in Orderflows Trader (v195, [40:44]; v196, [1:10:01]). [REPEATED]
- Named tools to replicate: **Multiple Imbalances tool** (draws a box around bars with multiple imbalances — pink/colored box) (v195, [25:27], [27:01]; v196, [31:09]); **Market Sweep** highlight; **Market Weakness** (blue arrow = bullish, indicating consider buying); **Prominent POC** (highlights only POCs that act as S/R); **Price Exhaustion**; **Value Area / value-area setups**; **Support/Resistance** highlighter (v196, [27:44], [49:31], [1:06:30], [1:10:01]). [REPEATED]
- Footprint cell coloring: bid-side selling imbalance = **red** number, ask-side buying imbalance = **blue** number, normal = **black**; buying imbalances cluster on green bars, selling on red bars (v195, [15:39]; v196, [29:29], [31:40]). [REPEATED] — direct rendering spec.
- POC rendered as a **gray rectangle** on each bar (v196, [22:21]). [ONCE]
- Delta plotted along the bottom of the chart for readability (v196, [21:53]). [ONCE]
- Design intent: visual highlighting because "the mind processes images 10,000 times faster than numbers" — push toward boxes/arrows over raw numbers (v195, [25:27]). [ONCE — UX principle]
- Default config = e-mini 1-minute; no template needed (v196, [1:10:30]). [ONCE]
- [SPECULATIVE] An A+ indicator could AND-combine: (swing extreme) + (≥3 imbalances, not-yet-stacked) + (Delta sign-flip) + (sweep) + (edge POC) and grade higher when more conditions co-occur AND fire early in the move.

## Q. Notable verbatim quotes (3–10, each with citation)
1. "I'm not trying to pick a low — I'm letting the market tell me the low has been made or the high has been made. I'm going to be looking for aggressive selling [or buying] coming into the market." (v195, [16:11]) — core philosophy: confirm, don't predict.
2. "When you start seeing a lot of aggressive buying in, that's bullish for the market. It's really simple… you're not trying to build some spaceship here." (v195, [21:40])
3. "Often times you're going to see imbalances coming in in bars that are not neatly stacked… if you're looking for bars with multiple imbalances you could catch the move a lot earlier." (v196, [31:09]) — why he prefers multiple-imbalance over stacked.
4. "Where it gets juicy is when a sweep occurs and there's no stacked imbalance, because most traders are looking for stacked imbalances but practically no one is looking for market sweeps." (v196, [44:10]) — his edge / highest-grade scenario.
5. "You could still be right and wrong at the same time… while there was bullish order flow on the way up, it changed in here — it became bearish — and by watching the Delta especially when you're in a position helps you understand the direction." (v196, [57:00]) — in-trade Delta management.
6. "If we get past this [prominent POC], the whole reason for being in the trade is over, I could get out." (v196, [54:33]) — explicit invalidation level.
7. "Aggressive sellers could be running out of their bullets — they got no more to sell… then boom you see plus 7,000 in the Delta, you get long here at 28." (v196, [1:01:03], [1:01:57]) — exhaustion → entry.
8. "You don't want to be selling after a big move down… you want to be looking for a point like C, the aggressive buying. Just as after a move up you don't necessarily want to be buying." (v195, [30:16]) — context filter.
9. "Markets don't move because more buyers than sellers — it's more aggressive buyers than passive sellers clearing out all the offers." (v195, [09:09]) — foundational mechanic.

## R. Contradictions / nuances
- **Big resting size is NOT directional the way retail thinks:** a big bid can be a seller about to hit it; jumping in front of big size is "deadliest" (contradicts common DOM/heatmap intuition) (v195, [10:38]). [REPEATED]
- **Delta usually matches direction but not always** — "there's cases where it's the opposite" (he defers details) — so a naive "negative Delta = bearish" rule has exceptions (v196, [55:34]). [REPEATED] [SPECULATIVE which exceptions]
- **Stacked imbalances are popular but often too late** — he partly contradicts the standard order-flow teaching by down-grading the very signal most traders rely on, in favor of multiple (un-stacked) imbalance bars and sweeps (v196, [30:38]). [REPEATED]
- **"Don't trade every multiple-imbalance bar / sweep"** — the signal alone is insufficient; context (location in move, swing point) is mandatory. Conditional/"it depends" guard repeated several times (v195, [29:20]; v196, [33:41], [43:40]). [REPEATED]
- **Settings are not universal** — imbalance ratio and sweep sensitivity must be tuned per market (gold thinner than crude/e-mini); same model, different parameters (v196, [44:42]). [REPEATED] — caution against hard-coding thresholds.
- **Cash-settled vs deliverable** — claims deliverable futures (bonds/10yr) honor S/R better than cash-settled (e-mini/NASDAQ), implying the reversal model may be more reliable on ZB/ZN (v196, [51:30]). [ONCE] [SPECULATIVE generality]
- Roughly half of both transcripts is **sales pitch** (price $749, course/Inner Circle bonuses, book offer) with no model content — heavy padding to skip.

## Coverage note
Both v195 and v196 are rich, near-identical applied webinars; v196 is the deeper one (adds Market Sweeps, Prominent POC, Delta shifts, and bullish/bearish Market Weakness with worked examples). v195 is concentrated on multiple-imbalance reversal logic and context. Exact numbers are limited to imbalance ratios (3:1, 4:1) and a few instrument-specific stop/Delta examples (3-pt stop, 20-tick stop, ZN "-12,000→+7,000"); most exhaustion/weakness/sweep thresholds remain qualitative and are flagged NEEDS-OPERATIONALIZATION. The final ~40% of each transcript is promotional and was not parsed for model content.
