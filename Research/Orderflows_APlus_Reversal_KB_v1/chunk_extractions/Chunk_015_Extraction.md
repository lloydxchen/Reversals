# Chunk 015 Extraction
- Source chunk: Chunk_015_Orderflows_Transcripts.md
- Transcripts covered:
  - v449 — The Orderflows Imbalancer Indicator Training (2025-02-03)
  - v451 — Delta Change Analysis Tool On Orderflows Trader 8 (2025-03-10)
  - v452 — Stopping Volume In The Footprint With Orderflows Trader 8 (2025-03-11)
  - v453 — POC Shadows Tool On Orderflows Trader 8 Trading Order Flow Reversals (2025-03-12)
  - v454 — Value Area Absorption On Orderflows Trader 8 (2025-03-13)
  - v457 — Trading Small Min Max Delta With Orderflows Trader 8 (2025-03-19)
  - v461 — Value Area Absorption On Orderflows Trader 8 (2025-05-19)
- Overall content value: rich (product-training/tool-walkthrough heavy, but contains explicit reversal mechanics, follow-through rules, absorption/stopping-volume definitions, and many thresholds)

## A. Setup types & names he uses
- **Imbalance reversal / Trend reversal via Imbalancer** — buy/sell triangle signals; the imbalances that "matter" (in-context, the OPPOSITE-side imbalances) precede the move (v449, "Imbalancer Training", [02:17], [03:57]). [ONCE]
- **Stopping volume reversal** — significant volume increase strong enough to halt then reverse price; "in its purest sense it should be a reversal signal" (v452, "Stopping Volume", [00:00], [04:39]). [REPEATED]
- **POC Shadow reversal** — POC rejection at a swing high/low; "really meant to be a reversal indicator for finding potential reversals" (v453, "POC Shadows", [01:55]). [REPEATED]
- **Value Area Absorption / Distribution reversal** — bullish absorption (dark blue) / bearish distribution (deep pink) in the bar's value area, then price moves away (v454, "Value Area Absorption", [04:47]; v461, "Value Area Absorption", [04:15]). [REPEATED]
- **Abandoned (naked/virgin) value area** — value area the market moves away from and later retests for support/resistance (v461, [02:25], [03:01]). [ONCE]
- **Small Min/Max Delta momentum signal** — bar with ~0 min delta (bullish) or ~0 max delta (bearish) = one side never in control; momentum signal, traded WITH momentum (v457, "Small Min Max Delta", [06:56], [07:50]). [ONCE]
- **Delta-change reversal at swing high/low** — large bar-to-bar Delta change near a high/low flags reversal (v451, "Delta Change", [03:40], [06:16]). [REPEATED]
- Direction: each tool produces both bullish and bearish variants (blue/green = bullish, red/pink = bearish) (v449 [21:37]; v451 [10:00]; v454 [04:47]).

## B. Tiering / grading language  ← HIGH PRIORITY
- "it's not the **quantity** rather the **quality** that matters" — re imbalances; a bar with 4–5 imbalances is NOT automatically strong (v449, [05:27], [04:50]). [REPEATED]
- Imbalancer Level scale (verbatim ranking): 1 = minimum, **2 = default ("moderate")**, 3 = "average", 4–5 = "above average / stronger", **6 = "the strongest" / "incredibly strong"** → higher = fewer but stronger signals (v449, [16:43]–[17:40]). [ONCE]
- Momentum strength scale: 1 = "first signs of momentum", 3 = "average / medium", 4–5 "a little bit stronger" ("not much difference between 4 and 5"), 6 = "strongest" (v449, [17:40]–[18:45]). [ONCE]
- "Turbo boost ... imbalance at **fair value** in a bar ... **carries more importance** than other areas" (v449, [14:54]). [ONCE]
- "I like to use **two and six**" as his go-to non-default Imbalancer/momentum combo for a new market (v449, [27:03]). [ONCE]
- Reversal opportunities graded high: "I think reversals are a **great opportunity** to catch a major move ... sets you up for a **great trading opportunity**" (v451, [06:16]–[06:44]). [REPEATED]
- Value-area absorption tiering: absorption/distribution value areas are "**more powerful**" / "act more as support or resistance" than normal value areas; "the ones that matter the most" vs "most of the time the value areas ... aren't going to matter" (v461, [05:26], [09:25]). [REPEATED]
- Quality-of-signal-by-volume grading (stopping volume): a 45–54% reading on a 138–147-contract bar is dismissed as "kind of light"; he wants "decent volume" ~400–1,000 contracts (v452, [07:43]–[08:51]). [REPEATED]
- Trade-quality asides: "a little bullish trade here. Not the greatest one"; "a nice short here"; "This one would be a nice one" (v457, [09:20]–[09:47]); "there was a nice **beautiful** one here ... at the swing low" (v452, [05:33]); "a **beautiful** one that occurred right off ... the cash open" (v461, [08:09]). [REPEATED]
- What MOVES a setup up a tier: occurs at a swing high/low (swing filter), at fair value, on decent volume, with momentum, AND has follow-through. What moves it DOWN: low volume, mid-bar/non-fair-value location, no follow-through, doji bars. (synthesis across v449/452/453/457) [SPECULATIVE]

## C. Order-flow story & psychology per setup
- **Stopping volume (long at lows):** aggressive sellers hit "strong resting liquidity"/strong passive buyers who absorb ("soak in") all the selling; once selling pressure is removed, "naturally the market should Rally" (v452, [00:26]–[00:57]). Mirror for shorts at highs (aggressive buying absorbed → reverse down). [REPEATED]
- **Absorption (Delta divergence):** a red candle with positive Delta = "some Traders absorbing whatever aggressive buy is taking place"; heavy volume toward the bottom of the bar = "weak sign of absorption" / "finding liquidity" (v449, [54:57]/[1:08:32]; v451, [07:13]). [REPEATED]
- **Value area absorption/distribution:** accumulation = "people building up a position"; distribution = "people getting a position off their books" (v461, [03:35]). Market moving away from that value = the players have finished and price is released. [ONCE]
- **Small min/max delta:** "tug-of-war" — when one side (e.g. net aggressive selling) "was never in control" the other side (the "herd") dominates; follow "the cumulative herd," meaning retail AND institutional all leaning one way (v457, [03:02], [10:59]–[11:30]). [ONCE]
- Core thesis (repeated): "trade on the side of the institutions" — "if you're getting short but nobody else is getting short ... why would you want to be short" (v453, [09:26]). [REPEATED]

## D. Exhaustion clues
- Delta "petering out" — Deltas still negative but "not really growing in the negative sense ... you often see that as a market starts stalling" (v451, [03:40]). [ONCE]
- Bounces after a sell-off being "shortlived" / "just profit taking coming in" rather than a real reversal — caution against false exhaustion reads (v449, [05:27]). [ONCE]
- Doji bars = "indecision because the bar opens and closes at the same price" — he discounts them (v457, [05:56]). [ONCE]
- (Note: classic exhaustion thresholds not numerically defined here. NEEDS-OPERATIONALIZATION.)

## E. Absorption clues
- Red candle with positive Delta (or green candle with negative Delta) = absorption of the aggressive side (v451, [07:13]; v457, [00:58]). [REPEATED]
- Heavier volume concentrated toward the bottom of a down-bar = "weak sign of absorption"/support (his example: 202, 151 contracts near bottom) (v449, [1:08:32]). [ONCE]
- Stopping volume = liquidity absorbs all aggressive flow at a level ("brick wall") (v452, [00:26]). [REPEATED]
- Value-area absorption: 70%-volume zone exhibiting accumulation (bullish, dark blue) / distribution (bearish, deep pink) — proprietary detection; "the only software that has it ... my own proprietary algorithm" (v454, [04:47]; v461, [13:20]). [REPEATED]
- Key qualifier: absorption only matters if price then MOVES AWAY from the zone; "if the market is just staying inside that absorption ... it could possibly be more absorption" (v454, [06:55]). [REPEATED]

## F. Stacked imbalance ideas
- He does NOT use raw count of stacked imbalances as strength: a bar with 3, 4, or 5 selling imbalances is explicitly NOT the signal — it's the opposite-side (buying) imbalances "in context of the market" that matter (v449, [03:57]–[05:27], [08:39]). [REPEATED]
- Multi-timeframe imbalances: imbalances that hold over a higher timeframe tend to be stronger — "imbalances that occur on a 3 minute time frame ... tend to hold really nicely over time"; but "an imbalance that's holding over 15 minutes ... not necessarily" stronger (v449, [07:40], [08:10], [28:58]). [REPEATED]
- "Evolving bars" setting: detects an imbalance that spans the close of one bar and open of the next (esp. on time/range bars where the bar ends mid-formation) (v449, [15:24]–[16:43]). [ONCE]
- Fair-value location of an imbalance > other locations in the bar (Turbo boost) (v449, [14:54]). [ONCE]

## G. Delta / delta-divergence ideas
- Delta defined: net aggressive buying − net aggressive selling per bar; green→positive, red→negative typically (v451, [00:53]; v457, [00:26]). [REPEATED]
- **Delta change** (bar-to-bar): not the min/max, but the change in Delta from bar N to bar N+1; example chain 437→44 = −393, then →−718 = −762 (v451, [01:56]–[03:03]). [ONCE]
- Use Delta change at swing highs/lows to flag reversals; large negative change right AFTER a swing high (e.g. −393 then −762) precedes a sell-off (v451, [03:40]–[04:41]). [REPEATED]
- Delta-change THRESHOLD defaults: **750 for e-minis**, **500 for Ultra Bonds** ("if you're trading e-mini 750 is good ... Ultra bonds I think 500 is good") (v451, [09:30]). [ONCE]
- Max delta = strongest positive delta reached in a bar; Min delta = strongest negative (v457, [01:22]–[01:59]). [ONCE]
- **Small min/max delta**: when min delta ≈ 0, "net aggressive selling was never in control" → bullish momentum; mirror for max delta ≈ 0 → bearish (v457, [02:27], [07:23]). Threshold default **3** (absolute: 0,1,2,3 or 0,−1,−2,−3) (v457, [04:05], [05:28]). [ONCE]
- Divergence: red candle with positive Delta = absorption (v451, [07:13]; v457, [00:58]). [REPEATED]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- — nothing explicit in this chunk — (closest is stopping volume as failed continuation / absorption at extremes, covered in D/E). [SPECULATIVE]

## I. Trapped-trader ideas
- Implicit only: aggressive buyers who get absorbed at a high (stopping volume) are effectively trapped and must reverse the market; "you removed the aggressive buying from the market so now naturally the market should reverse" (v452, [00:26]–[00:57]). [SPECULATIVE]
- Warns AGAINST being the trapped trader: seeing many sell imbalances and shorting into a rising market is the trap the Imbalancer is meant to prevent (v449, [03:57]). [ONCE]

## J. Entry triggers (the exact "go" event)
- **Follow-through rule (his universal trigger):** after a bullish signal, "the next bar has to be trading higher than the high of the bar with the signal"; after a bearish signal, "the next bar has to start trading down" (v453, [04:21], [08:57]; v452, [11:33]). [REPEATED]
- **Trade Entry Signal (Imbalancer):** shifts the printed triangle to the NEXT bar; requires "the market has to move at least **two ticks over two bars** for the signal to come in" — explicitly keeps him out of the bad trade and confirms the move (v449, [1:00:34]). [ONCE]
- **Buy-stop above the signal bar high** (stopping-volume long): example "put in a buy stop at 91 just above the high of this bar" where 6690 was the bar high (v452, [11:59]–[12:26]). [ONCE]
- For value-area / abandoned VA: trigger = next bar does NOT trade back into the value area; "if the next bar doesn't trade back into it, that's going to be ... a level to watch" (v461, [07:42]). Then enter on first retest (one tick above VA high / one tick below VA low). [REPEATED]
- Wait for bar close + next bar open before acting on momentum (min/max delta, stopping volume, POC) — never enter mid-bar (v457, [07:50]; v452, [11:33]). [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- The next bar (or "next bar or two") must trade beyond the signal bar in the trade direction; for stopping volume "in the next bar or two start trading lower than the low of the bar with stopping volume; if it's not doing that it's probably not going to be very effective" (v452, [11:07]). [REPEATED]
- Price should MOVE AWAY from the absorption/value-area zone, not pull back into it (v454, [06:55], [07:30]; v461, [09:25]). [REPEATED]
- For abandoned VA support: market returns and the zone HOLDS as support/resistance on first test (v461, [09:52]–[10:23]). [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- No follow-through kills it: a bullish POC/VA signal where "the next bar has zero follow through ... that's not a trade you would be looking to take" (v453, [06:51], [08:57]). [REPEATED]
- Price trading BACK INTO the absorption/value-area zone invalidates (means more absorption, not a release) (v454, [07:56]; v461, [09:25]). [REPEATED]
- For stopping-volume long, the next bar trading LOWER than the signal-bar low (instead of higher) = don't take it; "you got a bullish signal but then the next bar is trading lower ... should you have taken this? No" (v452, [11:33]). [REPEATED]
- Signal on light/thin volume = unreliable (e.g., 138–147 contracts) (v452, [07:43]). [REPEATED]
- Note on repaint behavior: while a bar is forming the signal "could be there, it could not be there ... could go back and forth," but once the bar closes it is fixed — "it's not going to repaint" (v449, [1:02:22], [1:09:42]). [REPEATED]

## M. Stop / risk / target / trade management
- **Stop placement:** at the opposite extreme of the signal bar — long stop at the BOTTOM of the bar / "above the high of the day" for a short reversal (v449, [59:52]; v451, [07:49] "your stop is just going to be above the high of the day"). [REPEATED]
- Value-area low-risk trade: buy one end of the value area, stop on the OTHER end, take-profit far away; explicit example — buy ~5954.5 (VA high +1 tick), stop ~5951 = "3 and 1/2 points," target into the 60s (v461, [11:32]–[12:28]). [ONCE]
- Scaling: "scale in with a tick here ... a tick here," average across the value area expecting a shallow pullback (pullbacks "tend to be concentrated a little bit more towards the top end") (v461, [11:32]–[12:00]). [ONCE]
- **Targets:** either exit on the opposite reversal signal OR use fixed targets based on "normal Market rotations" / "certain price movements that I'm looking for" — admits this keeps him out of the biggest extended bars (v449, [42:05], [42:48]). [ONCE]
- Timeframe-for-management: trade signals off a faster chart (e.g., 4-range or 3-range in bonds) but "manage it on a one minute chart" (v449, [36:09]). [ONCE]
- "If you don't have a stop in there" on NQ "your face ripped off" — emphasizes always using stops in volatile markets (v449, [51:53], [52:24]). [REPEATED]

## N. Context filters (session/time, regime/volatility, levels, instruments)
- **Volume/session filter:** volume-based tools (stopping volume) read poorly in low-volume windows — Asian close→European open "shoulder" period, data releases; only take on decent volume; "I wouldn't go past 2 [pm?]" / keep to "main US session hours" for currencies (v452, [01:55], [09:24], [10:30]). [REPEATED]
- **Volatility regime:** in volatile markets bump Imbalancer/momentum higher (e.g., level 4, momentum 6) or use a longer 3-minute analysis (v449, [46:12], [47:15]). [ONCE]
- **Instrument selection (strong recurring view):** prefers SLOWER, liquid, institutionally-driven markets — Ultra Bonds, Bonds, 5-years, 10-years, grains (soy meal); these have "ample liquidity," solid order book, no "voids of excess." Repeatedly warns AGAINST MNQ/NQ ("seductive," "your face ripped off," "stay out ... unless you got Deep Pockets and a good Constitution") (v449, [32:29]–[33:48], [49:38]–[53:02]; v453, [05:58], [07:24]). [REPEATED]
- Interest rates better traded on RANGE charts than time charts (time charts "just trade the bid and offer for several minutes") (v449, [35:06]). [REPEATED]
- **Swing high/low filter** (level/POC/stopping volume/VA): default swing period **5** (range 1–25); finds signals only at swing points (v449, [18:45]; v452, [05:07]; v453, [02:28]). [REPEATED]
- **Levels:** POC, value area (70% of volume), abandoned/naked value areas as support/resistance; higher-timeframe imbalance levels used "as a potential stopping point," NOT as buy/sell signals (v449, [29:36]; v461, [02:25]). [REPEATED]
- **News:** does NOT advocate trading right ahead of CPI / the number (v453, [03:25]); Trump tariff headlines drive volatility (v449 [00:04]; v454 [00:00]). [REPEATED]
- **Data/platform:** NinjaTrader 8 only; requires Tick Replay; level-1 data sufficient; works on charts that support tick replay (incl. Kinashi/Kinetiq renko, NOT native NT renko); dismisses TradingView footprint data aggregation as inadequate (v449, [10:39], [11:14], [67]/[1:10:22], [12:44]). [REPEATED]

## O. Directly testable / measurable variables
- Imbalancer Level: integer 1–6, default 2 (v449, [16:43]). EXACT.
- Momentum strength: integer 0(off)–6, default 3 (v449, [17:40]). EXACT.
- Swing filter period: default 5, range cited 1–25 (v449, [18:45]). EXACT.
- Trade Entry Signal threshold: "at least 2 ticks over 2 bars" (v449, [1:00:34]). EXACT.
- Stopping-volume strength: default 30%; "good for most markets," thinner markets 50%; "wouldn't go below 30%, maybe 25 about as low as I would go" (v452, [02:48], [03:18]). EXACT.
- Delta-change threshold: default 750; e-mini 750, Ultra Bonds 500 (v451, [09:30]). EXACT.
- Small min/max delta threshold: default 3 (absolute) (v457, [04:05], [05:28]). EXACT.
- Value area = 70% of bar volume (v454, [02:21]; v461, [01:20]). EXACT.
- POC = single price level in the bar with most volume (v453, [00:28]). EXACT (definition).
- Minimum volume imbalance: default 0; thin markets set 5 or 10 contracts (v449, [13:25]). EXACT.
- Multi-timeframe analysis values: 30s favored ("calm in my trading, just fast enough"), 15s "too short," 3-range "about as short as you can go" in bonds; tick examples 100/233/987/1000; uses 90s in e-minis (v449, [30:05], [36:39], [49:05]). EXACT (his preferences).
- Follow-through quantification: "next bar trades higher than the high of the signal bar" (bullish) / lower than the low (bearish) — testable but no tick count given beyond the 2-tick Trade Entry rule (v453, [04:21]; v452, [11:33]). EXACT (directional rule).
- "Big volume / decent volume / light volume" cutoffs for stopping volume — examples 138/147 = light, 339/400/1000 = decent; NO firm contract threshold. NEEDS-OPERATIONALIZATION (v452, [07:43]–[08:51]).
- "Delta petering out," "delta dries up," "shortlived bounce" — qualitative. NEEDS-OPERATIONALIZATION (v451, [03:40]; v449, [05:27]).
- "Heavier volume toward the bottom of the bar = weak absorption" — relative, no ratio. NEEDS-OPERATIONALIZATION (v449, [1:08:32]).

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Requires **Tick Replay** (reads each trade as bid/offer, not time-aggregated) — core data requirement; analyzes ticks live (v449, [10:39], [11:14]). [REPEATED]
- Indicators read the footprint in the background and plot onto a candlestick OR footprint chart (Imbalancer is standalone, NOT in the Orderflows Trader toolbox; stopping volume/Delta-change/POC Shadows/VA absorption/min-max delta are tools INSIDE Orderflows Trader 8, ~56 total tools) (v449, [10:39], [43:20]; v451, [10:32]). [REPEATED]
- **Multi-timeframe overlay:** compute order-flow signals from a different timeframe/chart-type (tick/volume/range/second/minute) and plot on the displayed chart; "period value 0" = underlying chart (v449, [06:37], [12:21]). Implementation idea for the NT indicator. [ONCE]
- **Zone drawing "until tested":** when a signal bar's next bar doesn't trade back in, extend the zone forward until price returns (used for VA absorption and Imbalancer levels) — implement as persistent S/R levels (v454, [06:23]; v449, [21:37]). [REPEATED]
- Zone placement direction options: direction of bar / opposite / both (v451, [09:30]). [ONCE]
- Color scheme convention: bullish = green/dark blue, bearish = red/deep pink; absorption colored distinctly from normal bars (v449, [21:37]; v454, [04:47]). [REPEATED]
- Momentum filter and swing filter are MUTUALLY EXCLUSIVE — "if you're using the swing filter you're going to want to disable the momentum strength, and vice versa ... it goes against each other" (v449, [19:23]). Important logic constraint for the indicator. [ONCE]
- Doji bars suppressed (no signal) in min/max delta (v457, [05:56]). [ONCE]
- Non-repainting: once a bar closes the signal is locked (v449, [1:09:42]). [REPEATED]

## Q. Notable verbatim quotes (3–10, each with citation)
1. "it's not really ... the quantity rather the quality that matters" (re imbalances) (v449, "Imbalancer Training", [05:27]). [REPEATED]
2. "stopping volume ... it's a significant increase in trading volume that's strong enough to Halt then potentially reverse price movement ... think of it like ... running into a brick wall where there's liquidity ... to absorb whatever aggressive buying is taking place" (v452, "Stopping Volume", [00:00]–[00:26]). [REPEATED]
3. "if you're trading a reversal ... you have the order flow in your favor ... but you still need that follow through ... the next bar has to start trading down ... if it's a bullish reversal the next bar has to start trading up" (v453, "POC Shadows", [03:54]–[04:21]). [REPEATED]
4. "what you want to see is the market starting to move away from it ... not just that the bar has a blue value area" (v454, "Value Area Absorption", [07:30]). [REPEATED]
5. "the market has to move at least two ticks over two bars for the signal to come in ... so it's keeping me out of this bad trade and it's confirming this long trade" (v449, "Imbalancer Training", [1:00:34]). [ONCE]
6. "I think reversals are a great opportunity to catch a major move ... it sets you up for a great trading opportunity" (v451, "Delta Change", [06:16]). [REPEATED]
7. "the guys that I know that have been trading the longest tend to stick to markets that move the slowest ... Capital preservation" (v449, "Imbalancer Training", [33:09]). [REPEATED]
8. "if you're getting short but nobody else is getting short ... why would you want to be short ... that's the whole point of orderflow ... trading on the side of the institutions" (v453, "POC Shadows", [09:26]). [REPEATED]
9. "what it's telling me ... once this bar opened, net aggressive selling was not present ... think of it as a tug-of-war" (v457, "Small Min Max Delta", [03:02]). [ONCE]
10. "the ones that matter the most are the ones where the market just starts moving away from that established value" (v461, "Value Area Absorption", [09:52]). [REPEATED]

## R. Contradictions / nuances
- **"Reversal tool" but trade WITH the trend:** stopping volume / POC shadows "in its purest sense should be a reversal signal," yet he repeatedly says "you want to be trading in the direction of the market" and uses a momentum filter to do exactly that — so the tools double as continuation signals when momentum-filtered (v452, [04:15]–[04:39]; v453, [09:26]). Conditional. [REPEATED]
- **More is not better:** contradicts common "stacked imbalance = strong" belief — a bar with 4–5 imbalances may be meaningless; it's the in-context opposite-side imbalance that matters (v449, [05:27], [08:39]). [REPEATED]
- **Longer hold ≠ stronger:** 3-minute imbalances hold well, but a 15-minute imbalance is "not necessarily" stronger — use the 15-min level as a stopping point, not a signal (v449, [08:10], [28:58]). [REPEATED]
- **Against indicator stacking:** explicitly criticizes stacking MACD/ADX/RSI (all "looking at the same piece of information ... bastardized moving averages"); says stacking his own standalone tools (Delta Scalper + Pulse + Turns + Show Hand + Imbalancer) to require 4–5 confirmations is impractical and over-filters you out of good trades — only stack pieces that read DIFFERENT parts of order flow (v449, [1:06:58]–[1:07:32], [1:08:00]). [REPEATED]
- **Terminology nuance:** "bearish value area absorption" is technically DISTRIBUTION, not absorption; he uses "absorption" loosely because traders are more familiar with it ("people will throw stones at me") (v461, [04:52]). [ONCE]
- **No single best timeframe:** "there is no one best time frame ... it comes down to what's best for you and your trading profile" — refuses to give a universal answer (v449, [48:31]–[49:38]). [ONCE]
- **Same settings, different markets:** the default 2/3 (Imbalancer/momentum) is "a great starting point for all markets," but thin/volatile markets need adjustment (min volume, higher level, longer TF) — so defaults are a starting point, not a rule (v449, [41:29], [13:25]). [REPEATED]

## Coverage note
All 7 transcripts are T1 and rich on reversal mechanics. v449 (Imbalancer training, 11.4k words) is the densest — full settings taxonomy, follow-through/Trade-Entry-Signal rules, market-selection philosophy, and anti-stacking views. v452 (stopping volume), v453 (POC shadows), v454/v461 (value-area absorption, overlapping content) all converge on the same core engine: signal → require follow-through → require price moving away from the absorption/value zone → stop at opposite bar extreme. v451 (Delta change) and v457 (min/max delta) add concrete Delta thresholds. Caveat: these are product-walkthrough videos, so many "signals" are tool outputs rather than hand-defined rules; exact volume cutoffs for "decent" vs "light" volume are left qualitative (NEEDS-OPERATIONALIZATION). Nothing unparseable.
