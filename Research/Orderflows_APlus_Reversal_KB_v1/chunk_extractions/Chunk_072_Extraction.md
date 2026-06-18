# Chunk 072 Extraction
- Source chunk: Chunk_072_Orderflows_Transcripts.md
- Transcripts covered:
  - v222 — Get Your Edge In Trading With Order Flow (2021-10-07)
  - v223 — How To Trade The Evening Session With Order Flow Using Orderflows Delta Scalper for NT8 (2021-10-27)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta divergence / weakening delta at extreme** (bullish & bearish): market at a high or low with delta getting weaker (declining positive delta at high, declining negative delta at low) → reversal signal. (v222, [26:06]–[28:54])
- **Stacked/multiple imbalances at a swing low** (bullish): three or more buying imbalances in a bar at LOD — even if not strictly vertically adjacent, 3+ imbalances in the bar is still a bullish sign. (v222, [44:38]–[45:36])
- **Market exhaustion print** (bearish and bullish): single-digit or very small volume at the extreme — e.g., 5 contracts at LOD on crude oil, after a sequence of much larger volume bars, signals sellers have "given up." (v222, [43:07])
- **POC migration signal** (trend and reversal): watching where the POC migrates bar-by-bar — higher for bullish, lower for bearish, sideways for range. Reversal signal when POC migration stops/reverses. (v222, [27:50]–[28:26])
- **Market Weakness Detector (pullback signal)**: proprietary tool (in Orderflows Trader) that identifies when selling in a pullback is weakening — used to confirm continuation in trend, not a reversal per se. (v222, [50:07]–[51:36])
- **Delta Scalper signals** (evening/Asian session): buy/sell signals based on delta conditions across 5-minute bars; used specifically for low-volume/evening sessions. (v223, [06:16]–[07:57])
- **Delta surge / strong aggressive buying at swing low** (bullish): 5–6 buying imbalances in one bar at LOD combined with positive delta, points of control starting to migrate higher — signal that aggressive buyers have appeared. (v222, [31:11]–[32:14])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **"Low-risk trade"**: used for the crude oil exhaustion example — getting in near LOD (77.20 area) with a tight 10-tick stop when exhaustion print appears alongside bullish POC and divergences. Criteria: tight stop, confluence, away from open. (v222, [43:38])
- **"You could be getting short from up here"** vs. "getting short way down here" — implicitly grades entry quality by location: earlier entry at the breakdown start = better; waiting for breakout confirmation = inferior risk/reward. (v222, [28:54]–[29:29])
- **"You could be getting long in here"** — preferred entry in the 4290–4295 zone, described as the better (earlier) entry vs. waiting for breakout above 4296. (v222, [31:41]–[32:45])
- **"Not a sign of a market that's going up"** — used to describe POCs migrating lower; implicit mediocre/bearish grade for a structure expected to rally. (v222, [27:50])
- **"Nothing special"** — used for delta of +400 on the e-mini 1-min chart; labels it as insufficient to grade a bar as bullish. (v222, [34:20]–[34:58])
- **"Pretty much neutral"** — used for delta of -37; grading thematic: small absolute delta (~37 in ES) is effectively noise, not bearish signal. (v222, [30:40])
- **"Not strong yet"** — used for selling imbalances early in a breakdown before the market "really starts selling off." Implies imbalances need to confirm, not just appear. (v222, [29:29])
- **"Sporadic" buying** — used to describe buying that appears in a downtrend but is "followed up by a lot more selling"; qualitatively grades it as insufficient to reverse. (v222, [48:36]–[49:11])
- **Evening session grade**: "not looking for the 100 point move" — explicitly sets expectation lower for Asian/evening session trades; 20-tick catches are the target. (v223, [08:58])

---

## C. Order-flow story & psychology per setup

- **Bearish exhaustion at HOD (Bunds example)**: market hits a high, then tests the high again — "only one contract traded," then "two contracts trade." Story: buyers are exhausted; nobody is interested in taking the market higher. Followed by aggressive selling imbalances and negative delta surge. (v222, [47:02]–[48:04])
- **Bullish exhaustion at LOD (crude oil example)**: market pounds the low repeatedly (10 times over), volume per bar declines to just 5 lots at the extreme. Story: sellers "gave up" at the low; once sellers stop, price reverts. (v222, [43:07])
- **Delta weakening at top (ES example)**: market at HOD with delta going from +905 to +179 to +70 to -143. Story: for market to go higher it needs "strong positive delta," not declining delta; the aggressive buying has dried up. (v222, [26:40]–[27:13])
- **Buying dries up at second test (ES double-top)**: after first rally to 4318, market consolidates with deltas of +100, +56, +70 (small), then -749, then -1100. Story: "you don't have strong positive delta, the market's going to sell off" — lack of buying = absence of support, not necessarily presence of selling. (v222, [33:48]–[35:27])
- **Evening session psychology**: Asia is a "big oil trading center" — crude oil sees meaningful volume at 8 PM CT. Legitimate participants enter at Asian session open, generating real delta signals. (v223, [07:57]–[08:27])

---

## D. Exhaustion clues

- **Volume collapse at extreme**: sequence of bars with meaningful volume (55, 106, 58, 79, 43, 90, 13, 104) followed by a single bar with just **5 contracts** at the LOD. Qualitative pattern: dramatically smaller final print. NEEDS-OPERATIONALIZATION (ratio not stated, but contrast is the key). (v222, [43:07]) [ONCE]
- **Single-contract / two-contract test of extreme**: on Bunds 5-min chart, test of prior HOD traded only 1 contract, then subsequent bar had only 2 contracts. Explicit claim: "market's not going to rally if only two people buy it." (v222, [47:02]–[48:04]) [ONCE]
- **Exhaustion confirmed by no follow-through**: "for this market to go higher you're going to need strong positive delta" — if delta is declining not expanding at a test, exhaustion is confirmed. (v222, [27:13]) [REPEATED]

---

## E. Absorption clues

- **Bullish value area + bullish POC at low**: Orderflows Trader color-codes these (blue box = bullish value area; distinguished POC color = bullish POC) as visual absorption signals. Multiple confluence of bullish VA + bullish POC at low = absorption of selling. (v222, [40:09]–[41:09]) [ONCE]
- **Stacked/multiple imbalances at low during sell-off**: 3+ buying imbalances in a bar at the LOD while price is declining = aggressive buyers absorbing the selling. Described as visible "aggressive buying" by specific actors who "think this is a good buying opportunity." (v222, [44:38]–[45:36]) [REPEATED]
- **POC migration stalls and reverses**: after a downtrend with lower POCs each bar, when POC stops migrating lower or begins migrating higher = sign of absorption/value building at new lows. (v222, [30:04]–[31:11]) [REPEATED]

---

## F. Stacked imbalance ideas

- **"3 or more imbalances even if spread out in the bar" = bullish sign** — explicitly states that imbalances do NOT need to be vertically adjacent/stacked to count. When a single bar has 3+ buying imbalances distributed across price levels within the bar, it still qualifies as a bullish multiple-imbalance condition. Orderflows Trader draws a magenta box around such bars. (v222, [44:38]–[45:06]) [ONCE]
- **Selling imbalances appear during sell-off but are "not strong yet"** — initial imbalances in a move are weaker signals; they need to intensify to confirm the trend. (v222, [29:29]) [ONCE]
- **Imbalances + delta + POC confluence at low**: for the crude oil LOD example, combination of (a) stacked imbalances in bar at low, (b) bullish POC, (c) bullish value area, and (d) exhaustion print = highest-confidence reversal. (v222, [44:05]–[45:36]) [ONCE]

---

## G. Delta / delta-divergence ideas

- **POC migration as complementary delta confirmation**: POCs migrating higher = bullish; migrating lower = bearish; sideways = range/neutral. Used alongside delta to construct bias. (v222, [20:24]–[20:56]) [REPEATED]
- **Delta weakening without flipping = sufficient signal**: "you don't necessarily need to have strong negative delta as long as you don't have strong positive delta" — declining positive delta at HOD is enough to anticipate reversal; explicitly does NOT require delta to go negative first. (v222, [35:27]) [ONCE — nuanced version]
- **Delta direction vs. delta magnitude**: crude oil +400 = "big" but ES 1-min +400 = "nothing special." Know your market's baseline delta magnitude. NEEDS-OPERATIONALIZATION per instrument. (v222, [34:20]–[34:58]) [REPEATED]
- **Neutral delta reads**: delta of -37 on ES = "pretty much neutral" even on a red candle. Practical threshold: small absolute value = don't read into the directional sign. NEEDS-OPERATIONALIZATION (specific neutral band not stated in this chunk; -37 is example only). (v222, [30:40]) [ONCE]
- **Evening session delta**: switch from 1-min to 5-min to accumulate enough delta to generate a meaningful read. 1-min deltas of 7, 1, 14, 27 in evening = "not much information"; same period on 5-min = actionable signal. (v223, [05:14]–[06:16]) [ONCE]
- **Delta surge at LOD** (bullish): large positive delta bar appearing after delta accumulation at low — +590 after +300, +168, +223, +1300, +900 = "strong positive delta" confirming buyers. (v222, [31:11]) [ONCE]
- **Max/min delta divergence (evening session)**: on 5-min Bunds/crude oil, "max delta decreasing, min delta increasing as the market is getting ready to sell off." Directional divergence between max/min delta and price. (v223, [05:44]–[06:16]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Double-top holding without follow-through**: ES rallied to 4318, then again to 4318 — second test has small/declining delta, no buying interest. Treated as a failed attempt to break higher rather than a stop-run/liquidity event. No explicit stop-run language used. (v222, [33:17]–[35:27]) [ONCE]
- **Range support/resistance**: LOD holding after 10 tests on crude oil; entry at low is based on order flow, not the break of range. Implicitly, failing to break 77.12 after 10 attempts = trapped sellers below, not liquidity sweep. (v222, [42:07]–[43:38]) [ONCE]

---

## I. Trapped-trader ideas

- **Trapped short sellers at LOD**: crude oil LOD tested 10 times; once selling exhausts (5-lot print), short sellers have no more ammunition and are trapped. (v222, [43:07]) [ONCE]
- **Trapped longs at HOD**: Bunds — buying interest at the high is reduced to 1–2 contracts per test; longs who bought expecting higher are now holding losing positions as selling imbalances emerge. (v222, [47:02]–[48:36]) [ONCE]
- **Accumulation / distribution visible on footprint**: Mike explicitly states you will see "accumulation, distribution, absorption, trap traders, supportive buying, resistant selling" in real time that you cannot see on a bar chart. (v222, [24:05]–[24:33]) [ONCE, marketing context]

---

## J. Entry triggers (the exact "go" event)

- **Bearish trigger (ES top)**: short from 4316 area when POCs begin migrating lower AND delta is declining from peak, before any formal breakdown. Not waiting for a signal bar's low to be broken. (v222, [28:26]–[28:54])
- **Bullish trigger (ES LOD)**: go long "anywhere in this bar" (4290–4295) when you see 5–6 buying imbalances in the bar, POC migrating higher, and positive delta with a large positive bar (+590). (v222, [31:41]–[32:14])
- **Bearish trigger (Bunds HOD)**: get short "somewhere in here around 80" after seeing 1-contract/2-contract tests of the high, followed by large negative delta and selling imbalances. (v222, [47:30]–[48:36])
- **Bullish trigger (crude oil LOD)**: go long "anywhere you know 20 22" after exhaustion print (5 lots), bullish POC, bullish value area, and delta divergences converge at LOD. (v222, [43:38])
- **Evening session trigger (Delta Scalper)**: automated buy/sell signal from Delta Scalper tool fires at 8 PM CT when delta conditions on 5-min chart are met. Entry is on signal bar. (v223, [07:22]–[07:57])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Immediate continuation**: "order flow is going to help you right it's going to help you get in earlier up near the start of the move." Implication: if you got in correctly, price should move in your direction quickly. [NEEDS-OPERATIONALIZATION for exact bar count] (v222, [38:45]–[39:07])
- **POC continuing to migrate in trade direction**: after bullish entry, expect POCs to keep migrating higher each bar. (v222, [31:11]) [SPECULATIVE inference from context]
- **Delta sustaining direction**: after bullish entry, need to see "strong positive delta continuing," not reverting to neutral. (v222, [32:45])
- **Evening session follow-through**: catching "20 ticks here, 20 ticks there" — explicit small-target confirmation expectation for Asian session. (v223, [08:58])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Stop below the "bullish order flow" zone**: "if I have bullish order flow coming in at a certain area and the market starts trading below it well that bullish order flow obviously didn't work." Stop = just below where the bullish signals (imbalances, bullish VA/POC) began. (v222, [41:34]–[42:07]) [ONCE]
- **Strong positive delta NOT appearing at low**: "markets don't rally on strong negative delta, they rally on strong positive delta" — if positive delta doesn't appear after entry, rally thesis is invalidated. (v222, [32:45]–[33:17])
- **Selling failing to dry up**: if selling imbalances and strong negative delta continue or intensify at the low, the reversal is not valid. (v222, [52:09]–[53:15])
- **Evening session: buy signal that "didn't work out"**: explicitly acknowledges signals fail; no specific invalidation criterion stated beyond stop placement above prior swing. (v223, [10:49]–[11:18])

---

## M. Stop / risk / target / trade management

- **Stop placement principle**: "just below this area where the bullish order flow started" — stop is placed below the lowest price where the confluence of bullish signals (imbalances, POC, VA) appeared, not just 1 tick below the bar low. (v222, [41:34]–[42:07])
- **ES bearish example**: short at 4316, stop "just above this high" — not specified in ticks, placed above the swing high. (v222, [28:26]–[28:54])
- **ES bullish example**: long at 4290, stop at 4280 (10-point/40-tick stop on ES). (v222, [32:14])
- **Crude oil bullish example**: long at 77.20–77.22, stop just below 77.12 = 10 ticks. Move went to 77.60 = approximately 48 ticks. Risk/reward not stated as a rule, demonstrated as example. (v222, [43:38]–[44:05])
- **Bunds short example**: short at 78–80, stop "above 85" (approximately 5–7 ticks on Bunds). Target: market sold into the 60s (approximately 15–20 ticks). (v222, [49:11])
- **Early entry advantage**: emphasized repeatedly — earlier entry = same stop location but better entry price = half the risk. Conceptual framework, not a specific R:R ratio rule. (v222, [12:48]–[13:45])
- **Evening session targets**: 20 ticks per move in crude oil; not looking for 100-point moves. (v223, [08:58])
- **Evening session stop**: "above 75–76" for a short entry around 62 in crude oil (approximately 14 ticks). (v223, [09:35])

---

## N. Context filters (session/time, regime/volatility, levels)

- **Evening session (Asian) start time**: 8:00 PM CT is the recommended start for Asian session trading — "that's when more volume is going to come in." Asia is specifically noted as a big crude oil trading center. (v223, [07:57]–[08:27]) [ONCE — specific time anchor]
- **5 PM – 8 PM CT = low volume, avoid or use with caution**: "volumes there is going to be a little bit lighter" and moves will take longer to manifest. (v223, [01:55]–[02:19])
- **European session starts ~1 AM CT**: "European session kicks off around 1 AM Chicago time" — good moves happen there too (cited the nice crude oil move from 50 to 85 during European session). (v223, [00:55]–[01:26]; [10:08]–[10:49])
- **Chart timeframe must match session volume**: 1-min during evening = noisy and confusing; switch to **5-min chart** for evening/Asian session to aggregate volume. Rule: "order flow is about reading the volume and if you're trying to read volume that just isn't there it's going to be difficult." (v223, [03:18]–[05:14]) [ONCE — actionable]
- **Major markets only for evening session**: e-mini, crude oil, gold (to a lesser extent); avoid grains and ultra bonds/bonds until experienced because volume is too light. (v223, [02:48]–[03:18]) [ONCE]
- **ES rotation size context**: "the rotation in the e-minis is about 4 or 5 points" — used to contextualize a pullback as normal profit-taking, not a reversal. (v222, [51:09]) [ONCE — sizing reference]
- **Location at LOD/HOD**: all examples are taken at "the low of the day" or "the high of the day" — location at a genuine swing extreme is the prerequisite filter. (v222, [45:06]) [REPEATED]

---

## O. Directly testable / measurable variables

- **Delta weakening threshold (qualitative)**: positive delta declining from 905 → 179 → 70 → -143 = bearish. NEEDS-OPERATIONALIZATION: no specific percentage decline or absolute threshold stated; pattern is declining magnitude. (v222, [26:40])
- **Small delta = neutral threshold**: -37 on ES 1-min = "pretty much neutral." NEEDS-OPERATIONALIZATION: exact neutral band not given in this chunk (±50 from digest may apply). (v222, [30:40])
- **ES 1-min "nothing special" delta**: +400 = not meaningful for ES. NEEDS-OPERATIONALIZATION: what IS meaningful (digest says >25% delta/volume ratio). (v222, [34:20]–[34:58])
- **Crude oil 1-min "big" delta**: +400 = big for crude oil 1-min. NEEDS-OPERATIONALIZATION: absolute number implied relative to typical crude oil volume. (v222, [34:58])
- **Exhaustion volume**: 5 contracts at LOD after sequence of 55–106 per bar on crude oil 1-min = exhaustion. NEEDS-OPERATIONALIZATION: ratio not stated, only qualitative contrast. (v222, [43:07])
- **Single/two contract print at extreme**: 1 or 2 contracts at test of HOD on Bunds 5-min = exhaustion. Threshold stated qualitatively. (v222, [47:02])
- **Imbalance count per bar (≥3)**: 3 or more buying imbalances in a single bar = bullish; stated explicitly. Does not require vertical adjacency. (v222, [44:38]–[45:06])
- **POC direction**: consecutive POCs migrating lower = bearish; migrating higher = bullish; flat = range. Observable on bar-by-bar basis. (v222, [27:50])
- **Evening session switch**: use 5-min chart at/after 8 PM CT for crude oil and major markets. Actionable rule. (v223, [05:14])
- **Asian session start**: 8:00 PM CT. Actionable time filter. (v223, [07:57])
- **ES pullback rotation**: 4–5 points typical. NEEDS-OPERATIONALIZATION for filtering noise vs. reversal signals. (v222, [51:09])

---

## P. NinjaTrader / indicator implementation ideas

- **Bullish/bearish POC highlighting**: Orderflows Trader colors POC differently when "bullish" — distinct color vs. neutral gray. Implies programmatic logic to identify a "bullish POC" (likely: POC is at upper half of bar + positive delta + imbalances). Implementation detail not disclosed. (v222, [40:09]–[40:35])
- **Bullish/bearish value area box coloring**: blue box = bullish VA, red box = bearish VA, gray = neutral. Same logic as POC highlighting. (v222, [40:09])
- **Magenta box on 3+ imbalance bars**: Orderflows Trader draws a magenta box around any bar containing 3 or more buying imbalances (even non-adjacent). Directly implementable: count buying imbalances per bar, if ≥3 draw box. (v222, [45:06])
- **Market Weakness Detector**: indicator that detects delta weakening in pullbacks. Signal: delta declining in magnitude during a counter-trend move. Proprietary but implementable as: series of negative delta bars where |delta| is decreasing bar over bar. (v222, [50:07]–[51:09])
- **Delta Scalper for evening sessions**: separate indicator generating buy/sell signals based on 5-min delta behavior (swing highs/lows, delta direction, max/min delta). Explicitly recommended for Asian/evening session use. (v223, [06:16]–[07:22])
- **Timeframe adaptation rule**: system should ideally flag or adjust when in low-volume session (post-5 PM CT) to recommend/switch to 5-min chart. (v223, [03:18])
- **POC migration tracking**: bar-by-bar POC direction can be computed; a "higher POC" or "lower POC" flag per bar is testable. (v222, [20:24])

---

## Q. Notable verbatim quotes

1. "For this market to go higher you're going to need strong positive delta not delta getting weaker so instead of getting stronger it's getting weaker as the market starts falling over." (v222, [27:13]) — core delta-weakening = exhaustion rule.

2. "You don't necessarily need to have strong negative delta as long as you don't have strong positive delta the market's going to sell off." (v222, [35:27]) — nuanced: absence of buying = sufficient for bearish thesis, not just presence of selling.

3. "If I have bullish order flow coming in at a certain area and the market starts trading below it well that bullish order flow obviously didn't work and you're not going to hold up a bullish position if you start getting past your bullish order flow." (v222, [41:34]) — explicit invalidation rule for stop placement.

4. "They sell sell sell and they just gave up at this point and once they start giving up that's a sign that the market is going to reverse." (v222, [43:07]) — exhaustion = sellers giving up, 5-lot print.

5. "You see one two three four five six buying imbalances in this bar right off this swing low right points controls moving higher." (v222, [31:11]) — bullish trigger: multiple imbalances + POC direction change together.

6. "Market's not going to rally if only two people buy it." (v222, [48:04]) — exhaustion at HOD; very low volume on test = no buying interest.

7. "Order flow is about reading the volume and if you're trying to read volume that just isn't there it's going to be difficult so why make it harder on yourself." (v223, [12:21]) — context filter: switch timeframe when session volume is thin.

8. "You don't have to right really all the numbers that you see here are just records of the trades that have happened." (v222, [09:35]) — foundational framing: footprint is a ledger of actual transactions, not a predictive algorithm.

9. "If the market is doing something other than what you think it's doing and you're there fighting it you're going to lose money. Why don't you just do what the market is showing you is trying to do." (v222, [23:36]) — reactive, not predictive philosophy, consistent with "not a red-light/green-light system."

10. "The earlier you get into a move the tighter stop you're going to have." (v222, [12:48]) — the core value proposition of order flow early entry: same stop location, better entry = smaller risk.

---

## R. Contradictions / nuances

- **"Absence of buying" = sufficient bearish signal, not just "presence of selling"**: v222 [35:27] explicitly states you don't need strong negative delta for a bearish move — weak/absent positive delta is enough. This is a nuance of delta analysis: the signal is delta declining, not delta going negative. Not contradictory with digest but materially more specific. [ONCE]
- **Non-adjacent imbalances still count if ≥3 per bar**: v222 [44:38] states "even if they're spread out in the bar it's still a bullish sign" — challenges the strict "stacked = vertically adjacent" interpretation. This could conflict with a strict stacked-imbalance definition. [ONCE]
- **Evening session requires timeframe switch**: v223 is entirely about adapting chart timeframe (1-min → 5-min) for low-volume sessions. The digest says "same settings every market" for the detector — but here Mike explicitly says you must change the timeframe during low-volume sessions. This applies to the chart, not necessarily the detector ratios, but it is a meaningful qualification: **same settings ≠ same timeframe in low-volume conditions.** [ONCE]
- **Delta Scalper as a separate evening-session tool**: distinct from the exhaustion model, the Delta Scalper is positioned for scalping in thin conditions — lower conviction, smaller targets (20 ticks), not the same setup quality as a daytime A+ reversal. This suggests a tiering gap: evening session signals are implicitly lower-grade than day session A+ setups. [ONCE]
- **"Candlesticks work about half the time"**: v222 [46:36] — Mike explicitly says candlestick patterns "work about half the time, some work more than others." This directly dismisses candlestick-based entry/confirmation as a systematic edge — consistent with order flow being the primary read. [ONCE]

---

## Coverage note

v222 is a recorded sales/educational webinar (~70 min), rich with applied examples across ES, crude oil, Bunds, and gold — strong on delta, POC migration, exhaustion, and entry/stop logic, but marketing-oriented (30%+ of content is product pitch). v223 is a short (13 min) answer to a viewer question about the evening session — thin but adds one genuinely new context filter (8 PM CT Asian start, 5-min timeframe switch, Delta Scalper tool recommendation). Neither video contains advanced A+ reversal discussion; v222 is introductory-level explanation of order flow basics applied to live examples.
