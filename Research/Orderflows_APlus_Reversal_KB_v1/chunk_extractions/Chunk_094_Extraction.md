# Chunk 094 Extraction
- Source chunk: Chunk_094_Orderflows_Transcripts.md
- Transcripts covered:
  - v347 — Prominent Point Of Controls In The Currency Futures And Forex Market With Orderflows Trader (2023-08-17)
  - v349 — Signs In The Delta The Market Is About To Make A Move Using Orderflows Trader On Ninjatrader 8 (2023-08-18)
  - v350 — Decode Delta Into Volume Values To Develop An Order Flow Footprint Trading Strategy (2023-08-20)
  - v351 — Does It Take A Decade To Learn Order Flow Not With Orderflows Trader Fast Track Your Trading (2023-08-21)
  - v352 — The Importance Of Order Flow Delta At The High Of Day Trading Market Context (2023-08-21)
  - v353 — Order Flow Footprint Chart Vs Plain Candlestick Chart Trading (2023-08-22)
  - v354 — Order Flow With VWAP And Technical Patterns Double Bottoms Price Action (2023-08-22)
  - v355 — Trading Value Areas With Order Flow Tips On What To Look For Using Orderflows Trader (2023-08-23)
- Overall content value: rich (v347, v349, v352, v353, v355 strongest; v351 is mostly a motivational rant, thin)

## A. Setup types & names he uses
- **Prominent Point of Control (PPOC) reversal** — bullish PPOC (cyan line) at swing lows = support; bearish PPOC (magenta line) at swing highs = resistance. "Untested-in-the-next-bar" PPOC is the tradeable version (v347, "Prominent POCs", [04:25], [05:25]). [REPEATED]
- **Slingshot point of control** — a separate form of POC analysis, green line, bullish or bearish; traded the same way as PPOC (v347, "Prominent POCs", [03:26]; v354, "VWAP/Double Bottoms", [07:35]). [REPEATED]
- **Abandoned / "aversion" value area** (value area not traded back into in next 1–2 bars) — bullish if off a low, bearish if off a high (v349, "Signs In The Delta", [10:18]; v355, "Trading Value Areas", [04:48]). [REPEATED]
- **Value-area gap reversal** ("value gap" — gap from one bar's value-area edge to the next bar's value-area edge; his version of a fair value gap but volume-based) (v349 [08:33]; v355 [03:35]). [REPEATED]
- **Engulfing value area** (bar's value area engulfs prior bar's) — bullish off lows (v349, "Signs In The Delta", [08:06]). [ONCE]
- **Delta-shift reversal at swing extreme** — strong Min/Max Delta that reverses within the bar (e.g. +623 → close −212 at high of day) (v352, "Delta At High Of Day", [05:20]). [REPEATED]
- **Extreme Delta/Volume reversal** — Delta-as-%-of-volume above threshold at a turning point (v350, "Decode Delta Into Volume", [02:47]). [REPEATED]
- **Exhaustion-print setup** at a user's own support/resistance — thin/exhaustion prints signal lack of interest = "go" to fade (v351, "Does It Take A Decade", [11:27]). [ONCE]
- **Double bottom / double top + order flow** — both bottoms showing bullish PPOC = go long on break of validation line (v354, "VWAP/Double Bottoms", [15:23]). [ONCE]
- **VWAP / standard-deviation reversion + order flow** — fade or follow at 1st/2nd/3rd std dev based on order flow (v354, [04:37]). [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
- "**one of my highest, one of my favorite trade setups**" = value area left untested by the next bar, especially when preceded by overlapping/balancing value areas then a breakout (v355, "Trading Value Areas", [05:19], [06:44]). [ONCE]
- "**that's a trade they love to take**" — followers wait for PPOC / slingshot POC to appear AND be untested in the next bar (v347, "Prominent POCs", [05:25]). [REPEATED]
- "**the best ones**" — when price trades back into a value area, rejects it, and moves away **in the same bar** (vs. lingering inside it) (v349, "Signs In The Delta", [11:14]). [ONCE]
- "**a strong sign on its own**" / "**that's a strong sign**" — TWO consecutive abandoned value areas (not traded into over next two bars) (v349, [13:30]). [ONCE]
- "**quite strong**" — a zero print inside the bar (v349 [04:51]; v351 [05:58]). [REPEATED]
- "**borderline**" / "**that's okay**" — a Delta/Volume signal that comes in mid-move rather than at the swing high/low; he'd be "a bit more interested" if it came right at the extreme (v350, "Decode Delta Into Volume", [11:45], [11:18]). [REPEATED]
- He explicitly REFUSES a single "best" setup: "do I have a favorite child? No... you can't just live and die by one setup" (v355, [05:19]). Tiering is situational, not a ranked list. [ONCE]
- Contrast framing he uses to grade: order flow is "**not a Holy Grail, not a trading system by itself**... it's data" (v349, [14:32]); accepts an indicator correct "65 percent of the time" as fine in context (v350, [10:47]). [REPEATED]
- NEEDS-OPERATIONALIZATION: "strong", "quite strong", "decent volume", "nice", "beautiful rally", "half-hearted move" are all qualitative grades with no fixed number.

## C. Order-flow story & psychology per setup
- PPOC = "market-generated information," the result of actual trading; heavy passive buying at a low = "stopping volume," heavy passive selling at a high = stopping volume. Market oscillates between these stopping-volume levels (v347, "Prominent POCs", [07:12], [07:40]). [REPEATED]
- At a NEW HIGH you EXPECT positive Delta / aggressive buying ("339 393 252 291 700 — that's what trading into the highs looks like"); the tell is when that aggressive buying shifts to aggressive selling intrabar (Max +623 collapsing to close −212). The buyers who pushed the high get trapped as sellers take control (v352, "Delta At High Of Day", [05:45], [11:46]). [REPEATED]
- Cash open (8:30 Chicago) = algos and big orders kick off; volume regime changes ("almost a whole new ball game"); overnight lows made "with impunity" on thin size can rebound hard on the open (v349, "Signs In The Delta", [01:22], [02:16]). [REPEATED]
- Aggressive buyers = those who lift the passive offer; aggressive sellers = those who hit the passive bid; passive traders work the bid/offer (v352, [03:42]). [REPEATED]

## D. Exhaustion clues
- **Exhaustion prints** = sign of "lack of interest in buying" at a high (or selling at a low); used as a fade trigger at one's S/R (v351, "Does It Take A Decade", [12:03]; v354, "VWAP/Double Bottoms", [06:33], [12:00]). Default exhaustion-print setting = 9 (v351, [11:27]). [REPEATED]
- Thin prints / zero prints inside the bar at an extreme = exhaustion/lack of participation; market often returns to that thin-volume level (v349, [04:26]; v351, [15:33]). [REPEATED]
- "Ideally I'd love to see the exhaustion print **right at the level**" (his FIB level) — placement at the exact level grades it higher (v354, [12:29]). [ONCE]

## E. Absorption clues
- "**Stopping volume**" — strong passive buying that halts a down-move at a low (and passive selling that halts an up-move at a high); this is what forms the PPOC (v347, "Prominent POCs", [07:12]). [REPEATED]
- Thin/zero print that "holds" — only 2 contracts traded at 43.59 in an 11,770-contract bar and price stayed above it = passive support holding (v349, "Signs In The Delta", [04:26]). [ONCE]
- NEEDS-OPERATIONALIZATION: he infers absorption from "it's holding / staying above that area," not from a delta-vs-price-move ratio.

## F. Stacked imbalance ideas
- **Stacked imbalance = three or more imbalances stacked neatly on top of each other**; tool min cluster size = 3 (v351, "Does It Take A Decade", [05:21], [05:58]). [REPEATED]
- Stacked SELLING imbalance into a high adds to the bearish case (e.g. "126 against 1592... 92 against 1... 182 against 37") (v352, "Delta At High Of Day", [06:49]). [ONCE — exact ratio pairs as transcribed, likely garbled by ASR; NEEDS-OPERATIONALIZATION]
- Stacked BUYING imbalance at/just after a low = aggressive buying confirming a bottom; combined with zero print = strong (v351, [05:58]; v354, [07:35]; v355, [11:04]). [REPEATED]
- Imbalance is treated as a confluence factor stacked with PPOC, thin prints, and Delta — never alone.

## G. Delta / delta-divergence ideas
- **Delta internals matter more than final Delta**: read Max Delta (peak aggressive buying) and Min Delta (peak aggressive selling), not just the close. Intrabar SHIFT is the signal — bar closing near its Min Delta = bearish; near Max Delta = bullish (v349 [02:43]; v352, "Delta At High Of Day", [04:43], [08:24]). [REPEATED]
- **Delta divergence at a new high** = price makes new high but Delta closes negative (e.g. high of day with final Delta −212 after Max +623) (v352, [05:20]; v353, "Footprint vs Candlestick", [04:35] "new high with negative Delta"). [REPEATED]
- **Neutral Delta zone = ±50** in e-mini S&P (treats Delta within plus/minus 50 as effectively neutral because one more trade could flip it); a Delta of −3 he calls neutral (v352, [02:13], [02:43]). [ONCE — EXACT NUMBER]
- **Positive Delta on a red (down) candle is actually bullish** (v353, "Footprint vs Candlestick", [09:18]). [ONCE]
- Pattern of confirmation after a high: a string of consistently negative bar Deltas ("positive, negative, negative, negative, negative") with no need for 10 bars — pick up the signs early (v352, [12:19]). [REPEATED]
- He rebuts the "Delta is useless/doesn't matter anymore" comment in TWO videos — strong conviction Delta still works (v349 [04:26]; v352 [01:44]). [REPEATED]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Resistance-flip on value gap**: a bearish value gap implies price "should" trade lower; when it instead trades ABOVE the gap level, "what was bearish information actually turned to bullish" — treat the level like broken resistance and look for the next target up (v355, "Trading Value Areas", [08:17], [08:55], [09:26]). [ONCE — clearest failed-breakdown logic in the chunk]
- **VWAP std-dev failure**: traders expect a bounce off the 1st std dev back to VWAP, but the deviation band itself is moving down in a downtrend, so price can ride to the 2nd/3rd dev without ever reaching VWAP — don't blindly fade to VWAP (v354, "VWAP/Double Bottoms", [02:40], [03:13]). [ONCE]
- Untested PPOC that price rallies back up to but fails to fill = level "left hanging," abandoned/"aversion" POC (v347, "Prominent POCs", [06:19]). [ONCE]

## I. Trapped-trader ideas
- Buyers who chase a new high get trapped when intrabar Delta flips from strongly positive to negative and aggressive sellers take control (v352, "Delta At High Of Day", [05:45], [09:00]). [REPEATED — implied]
- VWAP/std-dev "bread and butter" faders get trapped/stopped repeatedly when they treat VWAP as a moving average and buy/sell at VWAP itself instead of away from it (v354, [02:11], [05:08]). [ONCE]
- NEEDS-OPERATIONALIZATION: trapped-trader logic is described narratively, no explicit "trapped volume" metric.

## J. Entry triggers (the exact "go" event)
- **PPOC trigger**: PPOC forms in a bar, then you WAIT for that bar to close AND for the NEXT bar to NOT test it; enter near the close of the confirming bar with stop just beyond the extreme. Do NOT enter the instant a PPOC appears (v347, "Prominent POCs", [09:29], [09:53]). [REPEATED]
- Optional stricter PPOC variant: wait for the next bar to be the opposite color (red bar after a bearish PPOC) before entering, or wait for a small pullback (v347, [10:22]). [ONCE]
- **Delta-shift trigger at high of day**: not the inside/engulfing bar right after the high — the "go sign" is when price "starts breaking" lower (a clean red bar moving away from the high), e.g. short around 02–03 area (v352, "Delta At High Of Day", [13:16], [07:18]). [REPEATED]
- **Value-area trigger**: enter on the breakout from a cluster of overlapping/balancing value areas, or when a value area is left untested into the next bar (v355, "Trading Value Areas", [06:44]). [ONCE]
- **Double-bottom trigger**: break of the "validation line" with buying imbalances + thin prints = "Off to the Races" (v354, "VWAP/Double Bottoms", [16:15]). [ONCE]
- **Exhaustion/thin-print trigger** at your own S/R level: print at the level is the "go signal" to fade (v351, [12:03]; v354, [12:29]). [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- Move should happen **soon, not slow**: "I'm really looking for that move to happen sooner rather than later"; don't expect 5 pts → pullback → another 5 pts. Take what you get if subsequent legs are smaller/half-hearted (v350, "Decode Delta Into Volume", [13:26], [14:01]). [REPEATED]
- After breaking away from a high: continued consistent negative Deltas / red candles confirm sellers in control (v352, "Delta At High Of Day", [09:35], [10:07]). [REPEATED]
- Best value-area reject = price rejects the area and moves away IN THE SAME BAR (v349, "Signs In The Delta", [11:14]). [ONCE]
- TWO consecutive abandoned/untested value areas in the direction of the trade = strong confirming sign (v349, [13:30]). [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- For a short off a value-area high: if price trades back INTO the value area and just spends many bars inside (5–6 bars, ending on the high of the area) instead of rejecting and dropping, "you shouldn't be looking for it to sell off — if you're short you've got to cover" (v349, "Signs In The Delta", [11:14], [12:08]). [ONCE]
- For a long off support: "if we break 73 I'm completely wrong" — break of the volume-formed support level invalidates (v353, "Footprint vs Candlestick", [10:22]). [ONCE]
- For a bearish thesis: positive Delta printing in the next bar(s) means market can move back up — be ready to abandon the short (v352, [09:35]). [REPEATED]
- **Time stop**: on a 1-minute chart, if you're in a trade ~15 minutes and it's "not really moving," that's a bad sign — get out (v354, "VWAP/Double Bottoms", [08:32], [09:30]). [ONCE — semi-specific]
- A red candle that is one tick off the high with heavy volume but "nothing really bearish happening" (no bearish PPOC, no sell imbalance, no thin print) is NOT a reversal bar — disqualifies it (v353, [04:02]). [ONCE]

## M. Stop / risk / target / trade management
- **Stop just beyond the swing extreme**: short stop "just above that high" of the PPOC bar; long stop just below the low (v347, "Prominent POCs", [09:53]). [REPEATED]
- Accepts being stopped and waiting for the next setup: "you lose here... fine, just wait for the next trade"; "I'm fine to take this move and get stopped out and wait for the next bigger move" (v347 [09:02]; v350 [10:47]). [REPEATED]
- Targets framed in POINTS, context-dependent: dismisses 2-tick scalps, fine with 2 full points, but prefers setups with "capacity for a bigger trade" (10–30 pt moves cited) (v350, "Decode Delta Into Volume", [08:16], [08:48]). [REPEATED — but ranges are descriptive of past moves, NOT a fixed target rule → NEEDS-OPERATIONALIZATION]
- "You gotta have a stop in the market" — explicit even on VWAP-reversion longs (v354, [08:03]). [ONCE]
- Scale/take partials when the move stalls: by the time of a 3rd smaller leg, "if you're not out already... taking some sort of profits... just be happy with what you got" (v350, [14:01]). [ONCE]

## N. Context filters (session/time, regime/volatility, levels)
- **Cash open 8:30 Chicago time** = busiest, highest-volume window; big orders/algos start then. Pre-open order flow is lower-volume and reads differently (v349 [01:22], [01:49]; v352 [00:49]). [REPEATED]
- **Cash close** also a watch window — new highs/lows develop into it (v349, [12:08]). [ONCE]
- **Regime: "flow-driven market"** — strong one-directional selling/buying; he names it as a distinct condition (v349, "Signs In The Delta", [00:54]). [ONCE]
- **Trend day vs consolidation** must be traded differently — same setup behaves differently; e.g. one-way from cash open to ~1:00 then sideways (v355, "Trading Value Areas", [05:42], [06:15]). [REPEATED]
- **Levels he overlays**: VWAP + standard deviations (1st/2nd/3rd), Fibonacci (favors 50% and 61.8%), volume profile / market profile value areas, opening price (yellow line), prior swing highs/lows, double tops/bottoms (v352 yellow opening-price line [12:33]; v354 VWAP/FIB [04:37],[11:20]). [REPEATED]
- **Instruments**: e-mini S&P (ES) and MES are his core "thick"/decent-volume markets; also Euro currency (EUR), Euro/Yen, British pound, crude oil, bonds/ultra-bonds, mini Dow, lean hogs (HE) and grains as thin-market cautionary examples (v347, v350, v354). [REPEATED]
- **Chart types**: minute-based (he prefers for teaching, "most traders familiar with it"); for currencies an 8-range or 10-range chart; for thin markets a range chart to aggregate volume (v347 [00:52], [01:51]; v350 [06:10]). [REPEATED]

## O. Directly testable / measurable variables
- **Delta/Volume (Delta ÷ Volume) extreme threshold = 25%** default (color magenta if negative, cyan if positive); user-adjustable to 50%, 80%, etc. "I find 25 is good enough for most markets." Thicker markets "a struggle to get above 50%" (v350, "Decode Delta Into Volume", [02:47], [03:23], [03:54], [17:06]). [REPEATED — EXACT]
- **Neutral Delta zone = ±50 contracts** for e-mini S&P (treat |Delta| ≤ 50 as neutral) (v352, [02:13]). [ONCE — EXACT]
- **Thin-print thresholds**: traders use 0, 1, 3, 5, 9; he says e-minis "could use up to 9," mini Dow ~2–3, ag/thin markets keep low; Orderflows Trader default = 9 (v349, "Signs In The Delta", [05:24], [06:41]). [REPEATED — EXACT set of values]
- **Exhaustion-print default = 9** (v351, [11:27]). [ONCE — EXACT]
- **Stacked imbalance min cluster size = 3** (three or more imbalances stacked) (v351, [05:21], [05:58]). [REPEATED — EXACT]
- **Value area = 68.2% / 70% of bar volume** (industry standard he uses for per-bar value areas); his footprint draws the price range covering ~70% of that bar's volume (v355, "Trading Value Areas", [00:54], [02:31]). [REPEATED — EXACT]
- **POC = the single price level within a bar with the most volume** (bid+offer at that level, not two-way auction) (v347, [02:29]). [REPEATED — EXACT definition]
- "Untested in the next bar" / "not traded back into the next 1–2 bars" — a precise, codeable condition for PPOC strength and abandoned value areas (v347 [04:25]; v349 [13:30]). [REPEATED — TESTABLE]
- **Intrabar Delta-shift magnitude** — e.g. Max Delta +623 with close −212 (a ~835-contract swing) at high of day; bar closing within X of Min/Max Delta. The CONCEPT is precise; the trigger threshold is NOT specified → NEEDS-OPERATIONALIZATION (v352, [05:20]).
- "Decent volume" gate before trusting a Delta/Volume signal in thin markets — NO number given → NEEDS-OPERATIONALIZATION (v350, [04:34], [14:59]).
- Time stop ≈ 15 minutes of no movement on a 1-min chart → semi-testable (v354, [08:32]). [ONCE]

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Orderflows Trader settings paths cited: **POC slingshot** (red/green primary POCs until tested; cyan/magenta = Prominent POC level 1 / level 2) (v347, [03:26]); **Extreme Delta/Volume threshold** (default 25, color cyan/magenta) near the bottom of settings (v350, [03:23]); **Stacked imbalance min cluster size = 3** (v351, [05:58]); **Exhaustion prints** default 9 (v351, [11:27]); **Value area / engulfing value area** toggles (v349, [07:40]); **thin-print** value toggle (v349, [05:24]). [REPEATED]
- An A+ reversal indicator should compute per-bar: POC price, value-area high/low (70% volume), Delta, Max Delta, Min Delta, Delta/Volume %, imbalance clusters, and zero/thin prints — then flag confluence at swing highs/lows (synthesizes v349, v350, v352, v355). [SPECULATIVE]
- "Untested next bar" and "abandoned value area (no trade-back in next 1–2 bars)" are state machines requiring look-ahead of 1–2 bars before confirming a signal (v347, v349). [SPECULATIVE — implementation note]
- He cross-references the **go charting** web platform (same tools, bar statistics → Delta/% under order flow studies) as the Forex alternative to NinjaTrader (v347 [12:16]; v350 [03:54]). [ONCE]
- Cautions thresholds must be tuned per instrument by volume (e-mini vs hogs vs bonds) — implies instrument-relative, not absolute, parameters (v350, [05:12], [15:33]). [REPEATED]

## Q. Notable verbatim quotes (3–10, with citation)
- "When I'm looking at Prominent Point of controls I like them to be untested in the next bar... when it's unfilled meaning untested it in my opinion has more strength." (v347, "Prominent POCs", [04:25]) [REPEATED]
- "The best ones are where they trade back into it and reject it in the same bar and move away from it pretty quick." (v349, "Signs In The Delta", [11:14]) [ONCE]
- "Any time you're at the highs of the day going into the high you're expecting to see positive Delta... but when you start coming off from highs... it looks like negative Delta." (v352, "Delta At High Of Day", [11:46]) [REPEATED]
- "It all shifted in this bar — the strong positive Delta of 623 ended up at just minus 212." (v352, "Delta At High Of Day", [11:46]) [ONCE — exact numbers]
- "I find 25 is good enough for most markets." (Delta/Volume extreme threshold) (v350, "Decode Delta Into Volume", [17:06]) [REPEATED]
- "This is one of my highest, one of my favorite trade setups... [a value area] that's left untested by the next bar." (v355, "Trading Value Areas", [05:19]) [ONCE]
- "I'm really looking for that move to happen sooner rather than later." (v350, "Decode Delta Into Volume", [14:01]) [REPEATED]
- "What was bearish information actually turned to bullish because we're trading above that price level." (value gap as flipped resistance) (v355, "Trading Value Areas", [08:55]) [ONCE]
- "Order flow is a great tool... it's not a Holy Grail, it's not a trading system by itself, it's data that you can analyze." (v349, "Signs In The Delta", [14:32]) [REPEATED]

## R. Contradictions / nuances
- **Repeatedly refuses to give a single best setup** ("do I have a favorite child? No") yet elsewhere calls the untested-value-area his "favorite/highest" setup — favorite is plural and context-dependent, not a ranked #1 (v355, [05:19]). Nuance for KB: tiering is confluence-count + location, not one named A+ pattern.
- **Positive Delta on a down candle is bullish** — counter to the naive "green=buy/red=sell" reading; must be coded as Delta-vs-candle-color divergence (v353, [09:18]). [ONCE]
- **Delta near zero is meaningless**: in ES he discards |Delta| ≤ 50 as neutral; a "−3" is not bearish (v352, [02:13]) — contradicts treating any negative Delta as a sell signal.
- **Thin-market caveat overrides Delta/Volume %**: a −63% or −100% Delta/Volume on tiny contract counts (4–38 contracts) is a trap, "don't get seduced" — the same metric that's a signal in ES is noise in hogs/grains (v350, [05:12], [14:59]). [REPEATED]
- **VWAP std-dev mean-reversion is conditional**: the band moves with trend, so "bounce back to VWAP" can fail entirely; he won't blindly fade to VWAP (v354, [02:40]). [ONCE]
- **He distances himself from ICT "fair value gap"** — insists his value gap is volume-based (value-area edges), not the price-based high/low void ICT uses; treats candlestick/wick "price rejection" as unreliable ("works when it works") (v349 [08:33]; v353 [06:45]; v355 [03:35]). [REPEATED]
- Honest about misses: openly notes setups where his expected move "just didn't get there" / he "wasn't expecting 30 points" — model is probabilistic, expects to be stopped (v352 [10:40]; v354 [07:35]). [REPEATED]

## Coverage note
Rich chunk for a T2 tier: v347 (PPOC), v352 (Delta internals at high of day), v353 (footprint-vs-candle confluence), v355 (value areas/gaps) are the strongest applied-model material; v349 and v350 add Delta-shift and Delta/Volume mechanics with real numbers. v351 is ~90% a motivational rant about learning order flow (thin — only thin-print/stacked-imbalance defaults are usable). v354 is mixed (good VWAP-std-dev and value-gap-as-resistance logic, but rambles into tool promos). ASR garbled some imbalance ratio pairs (e.g. "126 against 1592") — treat exact imbalance volumes in v352 [06:49] as unreliable; PPOC/Delta/value-area numbers elsewhere are clean.
