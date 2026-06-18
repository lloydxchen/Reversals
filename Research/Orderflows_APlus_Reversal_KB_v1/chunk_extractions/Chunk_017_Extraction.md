# Chunk 017 Extraction
- Source chunk: Chunk_017_Orderflows_Transcripts.md
- Transcripts covered:
  - v492 — "The Order Flow Exhaustion Entry Model That's Quietly Replacing Everything Else" (2026-05-24)
  - v493 — "Exhaustion Entry Model On Memorial Day Weekend Holiday Trading Slower Markets" (2026-05-25)
  - v495 — "Order Flow Exhaustion Model In YM Mini Dow" (2026-05-27)
  - v496 — "Settings For The Order Flow Exhaustion Entry Model" (2026-05-27)
  - v497 — "Understanding The Order Flow Exhaustion Entry Model Setup" (2026-05-28)
  - v498 — "The Only Order Flow Strategy You Need The Exhaustion Entry Model" (2026-05-30)
  - v499 — "Liquidity Finder For NinjaTrader 8 Score Liquidity Zones" (2026-06-15)
- Overall content value: **rich** — this is the single most concentrated description of his core reversal model in the corpus. v492/v496/v497/v498 give explicit rules + exact settings; v499 is a full spec of a separate scored-zone indicator.

## A. Setup types & names he uses
- **"Order Flow Exhaustion Entry Model"** (a.k.a. "order flow entry model", "exhaustion entry model", "the exhaustion model") — his named, primary reversal setup. Explicitly "a reversal signal" (v497, "has to be a red bar", [01:01]). Both directions: bullish (reversal up off a low) and bearish (reversal down off a high). [REPEATED — title + body of v492, v493, v495, v496, v497, v498]
- He frames it as **the only strategy you need** and as "quietly replacing everything else" — traders abandon prior methods for it "because of the simplicity" (v492, "Replacing Everything Else", [00:00]; v498 title). [REPEATED]
- Bullish version = **bullish exhaustion print on a green candle at a swing low**; bearish version = **bearish exhaustion print on a red candle at a swing high** (v497, "red bar / green bar", [01:01], [06:38]). [REPEATED]
- Special variant: **"double top with exhaustion"** — when the exhaustion print occurs at a double top (not a fresh new high), the software won't auto-signal it; he "treats it differently" as "a different setup… a double top with less volume on the second test" but still tradeable by eye (v496, "double top", [04:55]–[05:56]). [ONCE]
- Separate tool/setup in v499: **"Liquidity Finder"** indicator — scores supply/demand "liquidity zones"; produces **"launch zones"** (green, "where price rocketed off the bottom") and bearish zones (red), plus **"go zones / go-no-go zone lines"** = the exact trigger level to get long/short (v499, "Liquidity Finder", [05:22], [06:19]). Scans **three liquidity patterns** based on volume + price action. [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
Grading vocabulary (verbatim) and what moves a setup up/down:
- **"beautiful trade" / "beautiful move" / "beautiful one"** — used for clean reversals that work immediately and run far with little/no drawdown (e.g. v492 "beautiful trade right here… 97 down to 96, down to 95" [03:18]; v498 "this was the beautiful move right here" British pound [09:23]; v498 "best type of trade where it doesn't even pull back" [13:53]). [REPEATED]
- **"the best trades are the ones that work immediately"** / "Best moves happen right away" — his single clearest tiering rule: speed of follow-through defines quality (v498, [14:30], [16:14], [19:00], [20:36]). A trade that "goes sideways for 10 minutes and then makes the move" is *low quality / not to be waited on*. [REPEATED]
- **"a great trade"** — long Russell from 20 out at 30 (v492, [15:26]); **"nice trade" / "nice move" / "nice short/long"** — used constantly for valid signals that pay (pervasive across all videos). [REPEATED]
- Downgraders: **"not the greatest trade"** (euro hung around, v495 [01:25]); **"not the best move"** but "could have salvaged something" (v498 [03:29]); **"a bit sketch" / "I'm scared of bars like this"** — a setup off a very big bar is downgraded because risk/stop is too large (v498, [16:49], [17:17], "almost a 100 tick bar"). [REPEATED]
- **"half-hearted move"** — weak follow-through, only ~5 points, drifts back on negative delta = mediocre (v498, [02:39]). [ONCE]
- For Liquidity Finder zones, explicit confidence tiers by score: **"high confidence" = 70–100% (lime/red), "medium confidence" = 34–69% (orange), "lower / weaker confidence" = below 33% (light gray)** (v499, [04:22]–[06:52]). He says the green/red are "the stronger signals… where a lot of traders are going to be focused"; orange/gray you "pair with your own confluence of other tools or order flow." [REPEATED within v499]
- Distinguishing context that *raises* quality: prominent **point of control toward the bottom of the move** + buying imbalances under a bullish exhaustion (v498, [00:30]); strong-then-fading delta sequence into the print (see G). Distinguishing context that *lowers* quality: big/wide signal bar (large stop), low-volume/holiday session, signal right before cash open. [REPEATED]

## C. Order-flow story & psychology per setup
- Core thesis (bullish): on the way down, **the last seller has sold** — "when the last buyer has bought or when the last seller has sold" is the key moment, visible only on a footprint (v492, [16:38], [17:10]). [REPEATED]
- Mechanism: **"Volume is thinning. No new money is coming in to push the move further. That level's going to hold… you have silence from those aggressive traders. They're not interested in moving the market further… once you remove that aggression from the market, the market's just going to naturally move back in the opposite direction."** (v492, [16:38]–[16:55]). [REPEATED — central psychology statement]
- Sellers are "exhausted… they're just tired. They can't sell anymore" by the time price hits the low; then aggressive buyers step in (shown by delta flipping positive + buying imbalances) (v493, [05:48]–[06:56]). [REPEATED]
- Gap/holiday psychology: gap-down → "gap traders… everyone is waiting for us to fill the gap" but no trade until price approaches the gap; thin volume = no edge (v493, [07:36]–[08:07]). [ONCE]
- Opening-price-as-magnet psychology: the yellow opening-price line "is going to act as a magnet"; on quiet days price hangs near open=prior close (v492, [16:00]; v498, [00:54], [06:46]). [REPEATED]

## D. Exhaustion clues
- **The "exhaustion print"** = a bar where the extreme price level traded the **lowest possible volume** — explicitly "one contract" is "the lowest trade volume you can have in a bar," also "two contracts" qualifies (v496, [05:29]–[05:56]; v497, [07:38]). The model's volume limit is **10 contracts** (see settings, section N/O). [REPEATED]
- Located **at the offer/top of a red candle** (bearish) or **at the bid/bottom of a green candle** (bullish): "On a red candle you're going to look at the top offer side. On the green candle it's the bottom bid side." (v497, [06:38]–[07:05]). [REPEATED — important operational detail]
- Must be at a **new swing high/low** over the lookback (his swing filter = 25 bars). An exhaustion print mid-range that isn't a new extreme does NOT count (v497, [07:38]–[08:10]). [REPEATED]
- Secondary confirmation that sellers are exhausted: **delta shrinks** on the way down (e.g. v493 minus 640 → minus 7 → minus 34; v498 British pound minus 748 → minus 298 → … → minus 144, "getting weaker on all the way down") then flips positive (v493, [05:48]–[06:56]; v498, [08:20]). [REPEATED]

## E. Absorption clues
- Not framed as classic "absorption" here; closest is the **imbalance-reversal acting as support/liquidity**: e.g. a *selling* imbalance of 94 inside a green candle at the low = "some liquidity there acting as support" (v497, [05:37]). [ONCE]
- Buying imbalances / stacked buying imbalances appearing right at the exhaustion low signal aggressive buyers stepping in (= the opposite of the prior aggression being absorbed/spent) (v496, [00:29]; v493, [06:23]). [REPEATED]
- — Mostly handled via "exhaustion + delta dries up" rather than an explicit absorption (large resting limit eating market orders) narrative in this chunk —

## F. Stacked imbalance ideas
- **Stacked buying imbalances** under a bullish exhaustion print are a confirming tell: "nice stack buying imbalance, another bunch of buying imbalances here and the market jumped from about 55 all the way up to 70" (v496, [00:29]). [REPEATED]
- On the *failure* side: a setup can have strong stacked selling and still reverse against you — "big aggressive selling four, you got stacked selling [imbalance] of four price levels and another two down here and it just reversed and went up" (v497, [03:01]) — i.e. stacked imbalances pointing one way preceded a reversal the other way (trapped sellers). [ONCE]
- Buying/selling imbalances at the print are part of the visual confirmation of the reversal "starting to form in real time" (v493, [11:29]–[12:01]). [REPEATED]

## G. Delta / delta-divergence ideas
- **Diminishing delta into the extreme** is the key delta tell: strong negative delta that **decreases bar-by-bar** as price makes new lows = sellers losing force (v493 "delta is decreased from minus 600 to just minus seven… then minus 34"; v498 British pound delta laddering down, [08:20]–[08:49]). [REPEATED]
- **Delta flips sign** at the reversal: negative → positive (bullish) confirms aggressive buyers arriving (v493, [06:23]; v496, [00:29] "came back nice strong positive delta"). [REPEATED]
- He defines "huge" delta only **relative to surrounding bars**: "I say huge is relative to we look at the previous bars… in the 30s… the only other big deltas is 113 and 101" then a minus 640 bar (v493, [05:48]). NEEDS-OPERATIONALIZATION — "big/huge delta" is explicitly relative, no fixed threshold. [REPEATED]
- Negative delta *after* a long entry is a bad sign / reason it won't run: "It's not a good sign… it's not going to shoot back up on all this negative delta" (v498, [03:29]). [ONCE]
- Bearish mirror: at a new high, selling delta that was hidden "really shows its hand" with large negative deltas after the bearish exhaustion print, confirming the down move (v498 British pound, [08:49]). [ONCE]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- Implicit stop-run/two-bar mechanic: after a bullish signal, price often **ticks below the entry on the next bar, then the second bar triggers** ("this next bar came down, traded below your entry signal, but the next bar got you in. That's why I say I give it two bars") (v492, [14:55]; v498, [11:53]). [REPEATED]
- He repeatedly notes "you'll get ticked out by a tick then it reverses" — a one-tick stop sweep — and advises **second-chance re-entry**: "Take the second chance entry or if it just ticks you out by a tick, get short again if it comes back down, especially on range charts" (v496, [11:33]–[12:02]; also v496 [04:34] "if your stop is one tick higher you're not [stopped]"). [REPEATED]
- Liquidity Finder explicitly models **resistance→support flips** ("what was previously resistance becomes support… supply demand") as scored zones (v499, [06:52], [07:55]). [REPEATED within v499]
- — No explicit "failed breakout above prior high traps longs" narrative as a named setup here; the exhaustion print at a new extreme IS his version of fading the failed push —

## I. Trapped-trader ideas
- The whole model implicitly traps the last aggressors: the last sellers who hit the low get trapped when no follow-through comes and price reverses up (v492, [16:38]; v493, [05:48]). [REPEATED — inferred framing of his "last seller has sold"]
- Explicit trapped-seller example: stacked selling imbalance of 4 price levels "and it just reversed and went up" — those sellers are now offside (v497, [03:01]). [ONCE]
- — He does not use the word "trapped" much in this chunk; the concept is carried by "exhaustion / silence from aggressive traders" — [SPECULATIVE] mapping —

## J. Entry triggers (the exact "go" event)
**The complete, explicitly stated entry rule (multi-part):**
1. **Exhaustion print** (low-volume extreme, ≤10 contracts) at a **new swing high (bearish) or new swing low (bullish)** over the last **25 bars** (v496, [02:32]; v497, [00:34]). [REPEATED]
2. **Price-action / candle color filter:** bullish signal must be on a **green bar**, bearish on a **red bar** (v497, [01:01], [06:38]). [REPEATED]
3. **Confirmation entry = let the market take you in:** entry is placed **just above the high of the signal bar (bullish)** / **just below the low of the signal bar (bearish)**, and one of the **next two bars must trade beyond that level**. If neither of the next 1–2 bars exceeds the signal bar's high/low, **there is no trade** even if the exhaustion print is valid (v492, [05:55]–[06:31], [18:11]; v493, [04:10]; v496, [08:01]; v498, [09:49]). [REPEATED — stated in almost every video]
- "It's not just about having an exhaustion print… The entry model, you have to let the market start trading up if it's a bullish signal. If it's staying below this level, there's no trade." (v492, [18:11]). [REPEATED]
- He gives **two bars** for the trigger to fire ("I give it two bars to work out", v492 [14:55]).

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **The move should happen immediately.** "Best moves happen right away. They don't just sort of go sideways and then move. They should come down, stop here, it should just start moving." (v498, [19:00]). [REPEATED]
- "If market's going to move off of exhaustion, if it's going to be a reversal off of exhaustion, it should happen sooner rather than later." (v498, [16:49]). [REPEATED]
- Delta should flip in your favor + imbalances appear in the new direction; price should "jump" off the level (v493, [06:56]; v496, [00:29]). [REPEATED]
- Best trades have **little or no drawdown / "doesn't even pull back"** (v493 "never even went against you" [09:11]; v498 [13:53]). [REPEATED]
- Caveat/nuance: occasionally a good one needs 1–3 bars of hanging before dropping (v498 [20:08] "on the third bar is when it really starts dropping") — so "immediately" is within the first ~1–3 bars, not strictly the next tick. [ONCE — softens the "right away" rule]

## L. Invalidation — what should NOT happen / what kills the thesis
- **Going sideways/horizontal instead of vertical** kills it: "It's going this way. It's going horizontal instead of vertical down… this trade is not paying me off, maybe I should get out." (v498, [12:53], [17:52] "It's not till the market starts going horizontal that you should think of getting out"). [REPEATED]
- Spending ~10 minutes at/near break-even = exit (don't wait for the full stop): "If it's spending 10 minutes at break even… I'm not going to wait for it to come down and stop me out. If it's not moving, it's not moving." (v496, [07:34]; v498, [16:14]). [REPEATED]
- **Negative delta after a long entry** (or positive after a short) = thesis weakening, won't run (v498, [03:29]). [ONCE]
- No trigger within the next 1–2 bars = **the setup never becomes a trade** (see J) (v492, [06:31]; v496, [08:01]). [REPEATED]

## M. Stop / risk / target / trade management
- **Stop placement:** just beyond the exhaustion print extreme — "your stop is going to be right about the high of the exhaustion print" (bullish: below the low / green line; bearish: above the high) (v493, [09:49], [15:33]; v495, [04:41]). [REPEATED]
- **One-tick discipline on range charts:** he keeps the tick buffer at **one tick** rather than widening; "I would rather just get out on the one tick than… one tick becomes two, two becomes three" — then take the second-chance re-entry (v496, [11:33]). Some traders ask to widen it; he prefers tight + re-enter. [REPEATED]
- **Risk is small relative to reward:** repeatedly cites risking ~5–15 ticks to make 25–60+ ticks; e.g. "you risk 1 2 3 4 5 ticks… one point when you just had a 15-point move" (v497, [04:24]); accepts a string of small stop-outs because one winner ("one fell swoop") recovers them (v492, [18:11]; v493, [13:48]). [REPEATED] (Numbers are illustrative per-trade, not fixed rules — NEEDS-OPERATIONALIZATION for a universal R multiple.)
- **Avoid big signal bars** — a wide signal bar forces a wide stop; he "prefers to take trades on shorter bars" and is "scared of" ~100-tick bars (v498, [03:04], [15:06], [16:49], [17:17]). This is an explicit *risk filter on setup selection*. [REPEATED]
- **Targets are discretionary / "it depends on your target."** He says repeatedly there's no fixed target: "it depends on what your targets are… I like to be optimistic and try and capture as much as you can" (v492, [08:46], [09:14], [14:26]). Exit when price goes horizontal (v498, [17:52]). NEEDS-OPERATIONALIZATION. [REPEATED]
- **Thin markets need realistic/closer targets:** in YM mini Dow "have realistic targets in thinner markets because it may get up to your target and not quite hit it"; "have the ATMs shooting off as soon as you get long" because pops reverse fast (v495, [02:51]–[03:45]). [REPEATED within v495]
- Scaling not required: "you don't need to like scale up or do anything" — one normal-size winner covers prior small losers (v493, [12:39]). [ONCE]
- Tighter stop appropriate **after** the cash open (orders already flushed) vs. wider tolerance pre-open when "pent-up" orders inflate the move (v495, [05:16]). [ONCE]

## N. Context filters (session/time, regime/volatility, levels, markets)
- **Markets / instruments (same settings across all):** E-mini S&P (ES), bonds & **ultra bonds**, **euro currency (6E)**, **British pound (6B)**, crude oil (CL), **mini Dow (YM)**, gold (MGC/micro gold), mini Russell (RTY). He stresses the model "works just about every market" with the **exact same settings** (v492, [01:23]–[01:54], [05:00]; v498, [20:36]). [REPEATED]
- **Chart type:** primarily **time-based 1-minute** charts; says 30-second, range, or tick also work ("doesn't matter"); currencies & ultra bonds he runs on **range-based** charts (8-range, 10-range mentioned) (v492, [00:58]; v497, [05:03]; v498, [20:36]). Prefers time-based over range/tick because range charts "tick you up a couple ticks then make the move the other way" (v496, [12:02]). NinjaTrader quirk: his "1-minute" sometimes fails but "60-second" works (v492, [10:23]). [REPEATED]
- **Volatility regime:** more volatile markets (RTY vs ES, crude > $100) give **more signals but more stop-outs**; "anytime [crude] is above 100… volatility… much more magnified" (v492, [12:05]; v493, [07:36]; v496, [06:28]). [REPEATED]
- **Session/time:** **Don't trade right before the cash open** (~8:00–8:30 CT) — "I never tell traders to take trades right ahead of the cash open… you're better off just waiting" (v497, [01:29]; v498, [03:58]). [REPEATED]
- **Avoid the cash-open spike bar** in thin markets (YM volume jumps 600→2,000 at 8:30) — "let the market settle down" (v495, [04:13]–[04:41]). [ONCE]
- **Holidays / low-volume sessions:** fewer/smaller setups; "pick your battles," "you don't have to trade," big moves on holidays are "rare"; overnight/Asian/evening bond sessions = "watching paint dry" (v493 entire video; v498, [05:49]). [REPEATED]
- **Lunchtime is choppy** — a known choppy time of day (v499, [20:23]). [ONCE]
- **Levels referenced:** **opening price = magnet** (yellow line) (v492 [16:00]; v498 [00:54]); **point of control** (prominent POC toward bottom of move strengthens a bullish setup) (v498, [00:30]); high/low of day; overnight high/range; gap (v493, [07:36]). [REPEATED]
- **Multi-market / multi-chart monitoring:** keep several markets AND a second chart type (e.g. 10-range) open so signals "jump out"; the market "is going to do what the market's going to do" so watch breadth (v495, [00:00], [05:44]). [REPEATED within v495]

## O. Directly testable / measurable variables
- **Swing filter (lookback) = 25 bars** — print must be the highest high / lowest low over the last 25 bars. He notes alternatives: 25/30/50; 30 = half-hour on a 1-min chart; on range charts it's just bar count, not time (v496, [02:32], [13:15]; v497, [00:34], [08:10]). EXACT.
- **Exhaustion print volume limit = 10 contracts** (the extreme price level must trade ≤10). Previously used **9**; expanded to 10 ~"a couple years ago" to get "a few more trades" — "difference is just one contract" (v496, [02:32], [13:15]; v497, [00:34]). EXACT.
- **Zone size / draw width = 10 price levels** ("set to one… means one price level. But I like to use 10 for all markets because I have a strong swing period"), color opacity 20%, draw green/red until tested (v496, [02:32]). EXACT (settings, software-specific).
- **Trigger window = next 1–2 bars** must exceed signal-bar high/low (v492, [14:55]). EXACT.
- **Candle-color rule:** bullish=green signal bar, bearish=red signal bar (v497, [01:01]). EXACT (boolean).
- **Stop buffer = 1 tick** beyond the print extreme (his preference; some use wider) (v496, [11:33]). EXACT.
- **Exhaustion print = lowest volume in the bar**, "one contract" being the minimum, "two contracts" also shown (v496, [05:29]; v497, [07:38]). EXACT lower bound.
- Qualitative / NEEDS-OPERATIONALIZATION: "delta dries up / gets weaker on the way down" (no fixed number — explicitly relative to prior bars, v493 [05:48]); "big delta," "huge negative delta"; "big bar" risk filter (no tick threshold given except illustrative ~100-tick); targets ("it depends"); "the move should happen right away" (within ~1–3 bars, not quantified).
- **Liquidity Finder (v499) — exact default & suggested settings (separate indicator, NOT the exhaustion model):**
  - Minimum liquidity score: default **50**, max **100**; tiers **70–100 = lime/red (high)**, **34–69 = orange (medium)**, **1–33 = gray (low)**; "75 is good enough"; can go as low as 1 or 5 (5≈1, "negligible" difference); cannot be 0. "Single highest-impact setting." (v499, [01:25], [04:22], [11:32], [16:27], [26:34]). EXACT.
  - Volatility: default **3** (recommended start); "sensible jumps" 3/5/10/15; higher = smoother volatility curve; short (3–5) for fast spiky NQ/gold, longer for bonds (v499, [10:23], [14:48], [19:15]). EXACT.
  - Volume baseline: default **20** (v499, [11:32], [14:48]). EXACT.
  - Learning bars: default **10**; raise to **25** for choppy periods / cleaner stronger zones ("more learning = fewer signals"); shorter learns quick scalps, longer learns slower swings (v499, [09:56], [16:00], [18:36], [20:23]). EXACT.
  - Follow-through threshold: default **1** (a "win" = price travels ≥1× the window distance); can go 1.1/1.2/1.5/2; raise to 2 so engine "only learns from larger moves" (v499, [13:43], [14:17]). EXACT.
  - Memory length: default **25**; can extend to **200** to score against more history (v499, [14:48], [22:33], [26:34]). EXACT.
  - Pattern match depth: **3** default (v499, [14:48]). Zone cool down: **5** default (suggested 2–3 for active scalper, 10–20 for sniper) (v499, [11:32], [14:48]). EXACT.
  - Displacement: default **1** (suggested 1.5); Fractal strength: default **1** (can go to 0.1 = weaker) (v499, [12:13], [14:48], [24:16]). EXACT.
  - Volume surge: default **2** (suggested 1.5–3) (v499, [11:32], [14:48], [28:43]). EXACT.
  - Reaction sensitivity: default **3** (suggested 2) (v499, [14:48], [12:40]). EXACT.
  - Active zones to show: default **6** (can raise to 25/50 to see more history) (v499, [15:27], [31:18]). EXACT.
  - Two preset profiles he gives: **"Active scalper/day-trader"** — min score 35–40, cool down 2–3 bars, reaction sensitivity 2, pattern match depth 1–2; **"Sniper"** — min score 65–75, cool down 10–20 bars, displacement 1.5, volume surge 2 (v499, [11:32], [12:13]). EXACT.
  - **No repainting**; signals confirmed on bar close (v499, [05:22], [33:05]). EXACT (boolean).
  - Defaults are tuned for **equity markets**; bonds/currencies need adjustment (v499, [12:40]). NOTE.

## P. NinjaTrader / indicator implementation ideas
- His tool is **"Orderflows Trader"** with an **"exhaustion template"** (a.k.a. "Order Flows Trader eight exhaustion template"); exhaustion detection = enable Exhaustion Prints + Swing filter, set swing = 25, volume limit = 10, draw zones until tested, opacity 20%, zone size 10 (v492, [01:23]; v496, [02:05]–[03:05]). Directly implementable parameter set. [REPEATED]
- He explicitly says you **don't need his software** — a plain footprint chart + "your eyes" can find the same prints (look for lowest-volume bar at a fresh swing extreme, on the offer side of a red bar / bid side of a green bar) (v496, [02:05], [05:29], [05:56]). Good for spec'ing a from-scratch indicator. [REPEATED]
- Historical context: before his tool he used **MarketDelta (CQG data)** and a **footprint tool by "Gomi"** for NinjaTrader (~2012–2013) (v496, [03:05]). [ONCE]
- **Liquidity Finder for NinjaTrader 8** (v499) is a full second indicator spec — three-stage pipeline: (1) **detect** three liquidity patterns from volume+price action; (2) **score** by building an internal database, checking higher-time-frame context + volume, finding most-similar past bars, and asking "did price actually follow through (hold)?"; (3) **filter/print** only zones meeting the min score, with cool-down + overlap filters. Outputs colored zones (lime/orange/gray), up/down triangles, and "go-zone" trigger lines; no repaint; prefers **close** beyond the go-zone line to trigger (v499, [02:21]–[05:51], [33:05]). [ONCE — but very detailed]
- Implementation insight he stresses: most S/D indicators just pattern-match and "draw zones everywhere," with no idea whether a level recently held or failed — scoring against recent history is the differentiator (v499, [00:27]–[01:25]). Directly relevant design principle for the target A+ indicator. [REPEATED within v499]

## Q. Notable verbatim quotes
1. "When the last buyer has bought or when the last seller has sold, and only the footprint chart allows you to see that. You cannot see that exhaustion on a candlestick chart on a bar chart." (v492, "Replacing Everything Else", [17:10])
2. "Volume is thinning. No new money is coming in to push the move further. That level's going to hold… you have silence from those aggressive traders… once you remove that aggression from the market, the market's just going to naturally move back in the opposite direction." (v492, [16:38])
3. "It's not just about having an exhaustion print… you have to let the market start trading up if it's a bullish signal. If it's staying below this level, there's no trade." (v492, [18:11])
4. "Part of the entry model is letting the next bar or two trade higher than the bar with the entry signal… even though you've got your signal right here, your entry is just going to be right above the high of this bar." (v492, [05:55])
5. "For a reversal using the pure exhaustion print, it would have to be a new high or a new low over the last 25 bars." (v496, "Settings", [05:03])
6. "On a red candle you're going to look at the top offer side. On the green candle it's the bottom bid side." (v497, "Understanding…", [06:38])
7. "Best moves happen right away. They don't just sort of go sideways and then move… It's not till the market starts going horizontal that you should think of getting out." (v498, "The Only Order Flow Strategy", [19:00] / [17:52])
8. "I'd rather just get out on the one tick than… one tick becomes two, two becomes three… Take the second chance entry… get short again if it comes back down." (v496, [11:33])
9. "A level isn't real because it's pretty on your chart… It should be real because it's earned. Liquidity Finder scores every supply demand zone against recent history, hides the noise… and it doesn't repaint." (v499, "Liquidity Finder", [33:05])
10. "These are the same settings whether it is ultra bonds, E-minis, crude oil… you can see how it is transferable into different markets." (v498, [20:36] / v492, [01:54])

## R. Contradictions / nuances
- **"Works right away" vs. "give it 1–3 bars":** he insists best trades move immediately and to bail if it goes sideways ~10 min, yet repeatedly shows winners that triggered on the 2nd bar and "hung around for 1 2 3 bars" before dropping (v498, [20:08]). Resolution: "immediately" = within roughly the first 1–3 bars and never after a long sideways drift. [nuance]
- **Tight 1-tick stop vs. wide stops on big bars:** he champions a 1-tick buffer + re-entry (v496) but also accepts very wide stops behind big signal bars — while simultaneously advising you avoid big-bar setups *because* the stop is too wide (v498, [16:49]). The reconciliation is setup selection: prefer small bars so the tight-stop discipline is feasible. [conditional / "it depends"]
- **"Same settings every market" vs. market-specific behavior:** claims identical settings work everywhere, yet notes volatile markets stop you out more, thin markets need closer targets, and currencies/ultra-bonds he runs on range charts not 1-min (v492 vs v495 vs v498). So "same settings" is true for the *detector*, but *management/targets/chart type* are adapted by market. [conditional]
- **Single-best-strategy framing vs. confluence:** v498 titled "The Only Order Flow Strategy You Need," but in v499 he tells you to pair Liquidity-Finder orange/gray zones "with your own confluence of other tools or even order flow." Slight tension between minimalism and confluence. [nuance]
- **Targets:** he refuses to give a fixed target ("it depends on your target," "I'm not going to say you'd have covered it down here") — deliberately discretionary, which conflicts with the otherwise rule-based detector. NEEDS-OPERATIONALIZATION. [nuance]
- **Double-top exhaustion:** the software intentionally suppresses a signal at a double top (not a fresh extreme), but he says it's still a valid (differently-treated) setup by eye — so the 25-bar new-extreme rule has a discretionary exception (v496, [04:55]). [contradiction with the strict swing-filter rule]

## Coverage note
All seven transcripts were rich and on-topic (all T1). v492, v496, v497, v498 are the core exhaustion-model rule/settings sources; v493 and v495 add session/holiday/thin-market and multi-market management nuance; v499 is a self-contained, highly detailed spec for a separate scored-zone ("Liquidity Finder") NinjaTrader 8 indicator with many exact default settings. Nothing was unparseable; speech-filler ("um", "[sighs]") was ignored. All numeric settings are software parameters quoted verbatim — none invented.
