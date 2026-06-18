# Chunk 059 Extraction
- Source chunk: Chunk_059_Orderflows_Transcripts.md
- Transcripts covered:
  - v190 — "Digging Deeper Into Order Flow With Michael Valtos For InvestorExpos" (2020-10-28)
  - v191 — "Orderflows Trader 3.0 Order Flow Analysis For NinjaTrader 8 FED Week Election Flows Mon. Nov 2 2020" (2020-11-02)
  - v192 — "Orderflows Trader Low Risk Volume Based Order Flow Trading Strategies Investor Expos" (2020-11-05)
- Overall content value: mixed

---

## A. Setup types & names he uses

1. **Delta divergence (bullish/bearish)** — new or equal high with negative delta (bearish) / new or equal low with positive delta (bullish); described as primary directional signal. (v190, "Digging Deeper", [39:00])
2. **Market weakness signal** — buying stalls / recedes on a move up, or selling stalls / recedes on a move down; delta decreasing across consecutive bars heading into an extreme. (v190, [34:35])
3. **Market sweep** — aggressive trader buys through all offers up to a price level (or sells through bids), visible as clustered volume at adjacent price levels on footprint; precedes directional move. (v190, [46:03])
4. **Stacked imbalances** — multiple same-direction imbalances vertically stacked; often co-occurs with sweeps. (v190, [50:59])
5. **POC Slingshot** — bearish or bullish signal based on POC relationship to prior-bar price action; highlighted by software. (v190, [52:00]; v191, [02:30])
6. **Value area gap** (setup 1 in v192) — each bar's value area gaps above/below the prior bar's value area, signaling momentum continuation or pullback opportunity when gap fills. (v192, [25:23])
7. **Value area build** (setup 2 in v192) — multiple consecutive bars form value at roughly the same price level (horizontal build), then market gaps/breaks out; the build level becomes support/resistance. (v192, [30:23])
8. **Extended Value Area (EVA)** — software-highlighted bullish or bearish value area signal; broader form of bar-by-bar value area analysis. (v191, [02:30]; v192, [36:03])
9. **Order flow sequencing** (bearish/bullish) — named composite signal from the Orderflows Trader software, visually displayed as magenta bars; indicates directional order flow bias. (v191, [02:54])
10. **Value area rejection** — price/bar opens into a prior bar's value area but closes outside it (or vice versa), signaling rejection of that value; used as entry cue. (v192, [16:52])
11. **POC migration** — successive POCs migrating higher (bullish) or lower (bearish) across bars; used to stay on right side of market. (v190, [24:19])

---

## B. Tiering / grading language — HIGH PRIORITY

1. "That's a **great** opportunity to get long" — delta divergence at a low confirmed by strengthening delta (+95 → +558 → +1800) across subsequent bars. (v190, [40:01])
2. "That was a **great** opportunity to get long" — bullish divergence at lows + rising imbalances + delta confirmation. (v190, [40:28])
3. "**Nice** low risk trade" — value area gap-and-go with imbalances, stop placed just under build. (v192, [35:34])
4. "**Very fascinating**" / "this was fascinating" — gold POC pull-back into prior bar's value area, stalls, reverses; used approvingly. (v192, [04:13], [34:30])
5. **"Not always a good thing"** (downgrade) — divergence alone is insufficient; needs order flow confirmation (delta strengthening + imbalances). (v190, [40:01])
6. "**A bullish divergence… but**" (downgrade) — divergence at low followed by weakening delta (+2000, +1600, +10) → market fails and goes sideways → sell-off; flags failed divergence. (v190, [41:24])
7. **"Buy at your own risk"** (skip/avoid) — positive delta at high with decreasing magnitude + red candles; grading language for a weakening extreme that signals reversal incoming. (v190, [36:37])
8. "**More strength to the market**" — value areas consistently forming at new highs (above prior swing high); premium bullish grading for momentum. (v192, [29:26])
9. "**Something's afoot already**" — value area build forming before any delta/imbalance confirmation; early qualitative flag. (v192, [32:07])
10. **Delta that is "stronger then stronger"** (upgrade) vs. delta that is "getting weaker and weaker" (downgrade) — sequential bar-by-bar delta direction determines quality of reversal vs. failed reversal. (v190, [43:00])

---

## C. Order-flow story & psychology per setup

1. **Market weakness / pre-reversal narrative**: Buyers are "already bought" — nobody is left to push price higher. Selling stalls similarly — "the last seller has sold." This is the core reversal thesis verbatim. (v190, [34:35])
2. **Delta divergence reversal**: At a swing low, sellers lose control (negative delta reverses to positive delta on the new low), aggressive buyers start stepping in. Story: sellers exhausted, new buyers absorbing remaining supply, market must reverse. (v190, [39:28])
3. **Failed divergence narrative**: Divergence fires at lows, but delta shows 2000 → 1600 → 10 (weakening); market opens into value area and cannot hold it → "if we can't hold that value or get through it to the other side, that's not a good sign." Buyers are not really in control. (v190, [41:57])
4. **Value area gap narrative**: Institutions/aggressive traders are so directional that no two-way trade is being facilitated between bars — value keeps gapping; latecomers chase price higher. (v192, [25:23])
5. **Value area build narrative**: Market finds a "fair price" — buyers and sellers both happy. Large players may be accumulating/distributing within this range. When they are done, the market gaps away from the build. The build becomes orphaned support/resistance. (v192, [30:23])
6. **Market sweep story**: A large informed trader is "buying everything up to a certain price" — not concerned with fill price, only average price. His urgency is readable via the sweep pattern on the footprint. (v190, [46:31])
7. **POC-at-extreme story**: Lower POC in successive bars signals lower prices being "accepted" — value is shifting. Opposite for uptrend. Used to stay on right side of market even if entry was late. (v190, [25:33])

---

## D. Exhaustion clues

1. Delta decreasing in magnitude across consecutive bars heading into a swing high: e.g. 1800 → 500 → 346 → big negative. Labeled "market weakness." (v190, [35:57]) [REPEATED]
2. A positive-delta bar at the high that cannot make a new high vs. the prior bar — "can't even go any higher than your swing high here." (v190, [20:21]) [ONCE]
3. Delta that was strong negative through a decline turns strongly positive on a new low = buyer exhaustion reversal / seller exhaustion. (v190, [39:28]) [REPEATED]
4. Value areas no longer migrating in the trend direction at an extreme — stalling in horizontal build at HOD/LOD implies exhaustion of trend participants. (v192, [29:26]) [ONCE]
5. Pre-cash-open (early morning, e.g. 6 am) imbalance and divergence signals are noted as "a lot clearer during the trading day" — implicitly lower quality at extremes in pre-market thin liquidity. (v190, [44:02]) [ONCE]

---

## E. Absorption clues

1. Large negative delta (-900, -360, -1600, -2000, -3000) appearing while price goes sideways at highs = sellers absorbing buyer interest at that level; "sellers are taking this opportunity to sell at these high prices." Market eventually breaks lower. (v190, [19:16]) [REPEATED]
2. When a bar has the largest negative delta of the sequence but price barely moves lower from the prior bar — absorption of selling by passive buyers at a level. (v190, [20:49]) [ONCE]
3. POC clustering at a level across multiple bars while price rotates — indicates a large actor is transacting at that price: "institutions building up a position or distributing one." (v192, [12:39]) [ONCE — stated explicitly]

---

## F. Stacked imbalance ideas

1. Stacked imbalances and market sweeps "often overlap because they're both very aggressive market behavior." (v190, [50:59]) [ONCE]
2. A sweep can occur WITHOUT stacked imbalances — "here there's no stacked imbalances in these bars"; implies sweep is the earlier/cleaner signal. If only looking for stacked imbalances, the sweep entry would be missed. (v190, [50:59]) [ONCE — refining]
3. Buying imbalances in a bar followed by negative delta in subsequent bars = imbalances that failed to follow through; not a valid setup. (v190, [22:14]) [REPEATED]
4. Strong negative delta + imbalances breaking through a swing low = quality continuation entry (not a reversal). (v190, [22:43]) [ONCE]

---

## G. Delta / delta-divergence ideas

1. **Divergence definition repeated**: new or equal high with aggressive selling (negative delta) / new or equal low with aggressive buying (positive delta). (v190, [39:00]) [REPEATED]
2. **Delta confirmation sequence for a valid bullish divergence**: divergence fires → delta next bar: 95 → 558 → 1800 (each bar stronger than prior). "Aggressive buying is getting stronger." (v190, [40:01]) [ONCE — specific example with numbers]
3. **Failed divergence sequence**: divergence fires → delta: 2000 → 1600 → 10 (each bar weaker). Market comes into value area, cannot hold, reverses lower. (v190, [41:24]) [ONCE — specific example with numbers; important calibration]
4. **Neutral/zero delta**: "Don't read too much into it… it's just coincidence." No signal value from a zero-delta bar. (v190, [18:45]) [ONCE]
5. **Cumulative delta context**: Overall session delta being "mostly negative" since cash open reveals broader directional bias even when individual bars show mixed signals. (v190, [19:16]) [ONCE]
6. **Small deltas in thin/early-morning session**: "In here this is six in the morning you're gonna get small bars… you're seeing buying and selling imbalances — it's a lot clearer during the trading day." Explicit caveat on pre-market signal quality. (v190, [44:02]) [ONCE]
7. **Bearish delta-divergence at high + subsequent sideways = lower quality**: "Even though it's relatively small deltas it's mostly negative" before sell-off from HOD. Does not require a dramatic spike negative. (v190, [43:23]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

1. **Market sweep** (large trader version): aggressive buyer sweeps through offers up to a level, turns market bid. The level they bought to is now potential support. Conversely, selling sweep turns market offered — that level is resistance. (v190, [46:03]) [ONCE — detailed]
2. **Opening range breakout failure**: Market broke above opening range high, went sideways, could not hold — "that's a bad long." Value area gapping lower within the range is the tell. (v190, [32:36]) [ONCE]
3. **HOD test failure**: Market "wasn't interested" in taking out highs / stops; got divergence then went sideways, then sold off. No dramatic wick needed — just failure to sustain. (v191, [03:22]) [ONCE]

---

## I. Trapped-trader ideas

1. Buyers who went long on opening range breakout are now trapped when market fails to hold above the range — their stops are below. (v190, [32:36]) [ONCE — implied]
2. Buyers long at HOD on positive delta are trapped when delta sequentially weakens and market reverses — "buyer beware, buy at your own risk." (v190, [36:37]) [ONCE]
3. Value area build concept: traders who faded the build (sold into it expecting it to break lower) are trapped when market gaps away from the build. (v192, [30:23]) [SPECULATIVE — not stated explicitly]

---

## J. Entry triggers (the exact "go" event)

1. **Divergence + strengthening delta sequence**: after the divergence prints on a new low, entry on the bar where delta is clearly increasing in magnitude (e.g., delta triples from prior bar). Not on the divergence bar itself. (v190, [40:01]) [ONCE — timing implication]
2. **Value area gap-and-go**: when a bar's value area gaps above (bullish) or below (bearish) the prior bar's value area, that is the go signal for the directional move. Entry on bar close or open of next bar. (v192, [25:23]) [ONCE]
3. **Value area build breakout**: after ≥2 bars of overlapping/horizontal value areas, the first bar that gaps its value area above (or below) the build is the trigger. (v192, [31:02]) [ONCE]
4. **Value area rejection entry**: bar opens into prior value area and starts rejecting it (closes outside) — entry as the bar is rejecting, tighter stop possible. (v190, [33:33]; v192, [16:52]) [REPEATED]
5. **EVA (Extended Value Area) signal**: software-flagged bearish or bullish EVA bar is the explicit trigger; trade in flagged direction. (v192, [37:03]) [ONCE]
6. **Multiple confluence at HOD/LOD**: divergence + bearish order flow sequencing + bearish EVA + market weakness signal all on same bar sequence = "go short next bar." (v191, [03:49]) [ONCE — strongest setup described]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

1. **After divergence entry**: subsequent bar deltas must be stronger (larger magnitude in the new direction) — 95 → 558 → 1800 pattern. (v190, [40:01]) [REPEATED]
2. **After value area gap-and-go entry**: next bar should also show a gap in value area (continuation gaps); if not gapping, at minimum value should migrate in trend direction. (v192, [26:46]) [ONCE]
3. **After build breakout entry**: price should not retrace into the build; if it does, market may still hold at build edge, but break through the build = exit. (v192, [33:02]) [ONCE]
4. **After EVA signal**: market should begin moving away from the EVA bar immediately; 10-point move in 5 minutes cited as typical outcome on 1-min e-mini. (v192, [37:34]) [ONCE — qualitative]
5. **POC migration confirmation**: after entry, subsequent POCs should migrate in the direction of the trade; a POC higher than entry (while short) is "not a good sign." (v190, [25:58]) [REPEATED]
6. **Value area migration confirmation**: value areas should continue migrating in trade direction; failure to do so (value area gap reverses) is a warning. (v190, [37:34]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

1. **Delta weakening after divergence entry**: 2000 → 1600 → 10 pattern — buy thesis is dead; if market opens into prior value and cannot hold it, exit. (v190, [41:57]) [ONCE — explicit]
2. **Value area build break**: price retraces through the entire build after a gap-out entry — that level is no longer support/resistance; exit. (v192, [33:02]) [ONCE]
3. **Value area migrating against trade direction**: while short, if value areas start migrating higher — that's a negative signal for the short. (v190, [37:34]) [ONCE]
4. **Opening into a prior bar's value and failing to hold**: "we opened up inside value of the current bar, closed well outside of value" (upward bar) = market rejecting higher value, bearish invalidation of any long. (v192, [16:52]) [ONCE]
5. **Imbalances not followed by directional delta**: buying imbalances in a bar but subsequent bars show negative delta → imbalances failed; no sustained move expected. (v190, [22:14]) [REPEATED]

---

## M. Stop / risk / target / trade management

1. **Stop for value area build setup**: stop is placed just on the other side of the build zone; if market pulls back into build and holds, trade is still valid. If it breaks through, exit there — not at a distant swing low. (v192, [33:02]) [ONCE — explicit stop placement rule]
2. **Tighter stop = lower risk principle**: "The quicker you get into a position based on how you read what's happening in the order flow the tighter your stop is going to be." Early entry from value area read rather than waiting for price to collapse lower. (v192, [34:02]) [ONCE — explicit]
3. **Target: use value area gaps as continuation signal**: while in a winning trade, continuing value area gaps tell you to hold longer vs. exit. A gap in value ahead of price is "how you use order flow to stay in winning trades longer." (v190, [56:37]) [ONCE]
4. **Exit early if value area stalls**: if in a short and value areas stop migrating lower (go sideways), that is a warning to reduce or close. (v190, [56:37]) [ONCE — implied]
5. **General principle**: "the quicker you get into a position… the tighter your stop." This is a restatement of the A+ small-bar rule via the value-area framework. (v192, [34:02]) [REPEATED concept, new framing]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

1. **High-volatility week (election/Fed/NFP)**: "Don't necessarily abandon it" — order flow still works; just pick spots. Brokers may raise margins, which keeps "weak traders" out = cleaner order flow. (v191, [00:31]) [ONCE]
2. **Cash open (8:30 CT) first bars**: "Not too concerned with the first few bars generally of the cash open" — caution on signals in the first 1-2 bars of the cash session due to initial order dump. (v190, [21:18]) [REPEATED concept, explicit statement here]
3. **Pre-market thin bars**: signals in pre-cash-open (e.g., 6 am) are harder to read — "a lot clearer during the trading day." Small bars with only 3-4 price levels make POC analysis "kind of difficult." NEEDS-OPERATIONALIZATION (threshold for bar size not stated). (v190, [44:02]) [ONCE — explicit caveat]
4. **Unchanged / opening price**: "yellow line which is the opening price for the day" — referenced as a key intraday reference level; ideal entry would be near the opening price in this example. (v190, [38:02]) [ONCE]
5. **Value area overlap as balance indicator**: 5-6 bars with overlapping value areas = market in balance; when a gap appears between value areas, balance is broken — that is the directional cue. (v190, [32:06]) [ONCE — explicit count stated]
6. **Multi-market applicability**: "Doesn't matter what market you're looking at, doesn't matter what time frame" for sweeps, value area, imbalances — Euro currency, gold, crude oil, e-minis, NQ, Apple stock all shown. (v190, [50:20]) [REPEATED]
7. **15-minute chart caveat**: "If you're looking at a longer-term chart like a 15-minute chart… you're looking for areas where the market can retrace to rather than moves happening." Shorter timeframes (1-min, 5-min, range, tick, volume) preferred for live order flow signals. (v190, [50:20]) [ONCE — explicit]
8. **VIX context**: referenced but as background (VIX in 20s now considered "low"); no new threshold beyond what digest already has. [REPEATED]

---

## O. Directly testable / measurable variables

1. **Imbalance ratio**: 4:1 (aggressive buyers outnumbering sellers by 4x or more per price level). (v190, [18:18]) [REPEATED — stated explicitly]
2. **Value area percentage**: 70% of bar's volume defines the value area; 68% also acceptable ("not going to make much difference between 70 and 68"). (v190, [30:36]) [REPEATED — stated explicitly]
3. **Delta sequential magnitude check**: bullish divergence valid when delta increases each bar (e.g., 95 → 558 → 1800); invalid when delta decreases (2000 → 1600 → 10). NEEDS-OPERATIONALIZATION (no minimum threshold for "strong enough" delta stated). (v190, [40:01])
4. **POC migration direction**: count of consecutive lower (or higher) POCs across bars; e.g., 4-5 lower POCs = confirmed downtrend pressure. NEEDS-OPERATIONALIZATION (minimum consecutive count not stated). (v190, [24:19])
5. **Value area overlap count**: 5-6 bars of overlapping value areas = balance / consolidation; gap in value area = breakout condition. NEEDS-OPERATIONALIZATION (exact bar count threshold not fixed). (v190, [32:06])
6. **Value area build duration**: build over "four to five bars" (5-min chart) or "seven minutes" (crude oil) before breakout. NEEDS-OPERATIONALIZATION. (v192, [31:02], [32:07])
7. **Bar-by-bar value area gap**: each bar's value area does not overlap the prior bar's value area = gap condition, momentum signal. (v192, [25:23]) [Testable: boolean per bar]
8. **Market sweep**: visible as high volume at consecutive adjacent price levels within a single bar (concentrated buying/selling through the offer/bid stack). NEEDS-OPERATIONALIZATION in footprint terms. (v190, [47:26])
9. **Delta zero**: zero-delta bar has no signal value; ignore. (v190, [18:45])
10. **Minimum imbalance count for significance**: "Two imbalances honestly is nothing to get excited about" — stated minimum is 3+ for meaningful signal (consistent with stacked = 3+). (v190, [22:14]) [ONCE — explicit threshold]
11. **"Smaller delta"** at HOD even without dramatic flip: "relatively small deltas, mostly negative" before sell-off from HOD. Bearish divergence doesn't require large negative delta, just persistent small negative lean. NEEDS-OPERATIONALIZATION. (v190, [43:23])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

1. **Orderflows Trader 3.0 runs on NinjaTrader 8** (not TradeStation, Sierra Chart, or other platforms). (v190, [59:08]; v192, [39:37]) [REPEATED]
2. **17 pre-programmed order flow tools** in Orderflows Trader 3.0 including: value area (bar by bar), POC Slingshot, market sweep detector, extended value area (EVA), order flow sequencing, market weakness arrows. (v190, [59:08]; v191, [01:54]) [ONCE — full list named]
3. **Market weakness arrows**: software auto-draws arrows when buying or selling stalls are detected; directional (blue = bullish, below bar; red = bearish, above bar implied). "Does that mean anytime you see an arrow it's automatic buy or sell? No — you still got to take things in context." (v190, [38:02]) [ONCE]
4. **POC Slingshot**: detects and highlights specific POC-to-prior-bar relationships that precede directional moves; bears and bulls colored separately. (v190, [52:36]; v191, [02:30])
5. **EVA (Extended Value Area)**: colored red (bearish) / blue (bullish); a more prominent/wider value area signal vs. the standard bar value area box. (v191, [02:30]; v192, [36:03])
6. **Order flow sequencing**: magenta-colored bars indicating directional bias of order flow composite; bearish or bullish state. (v191, [02:54])
7. **Default settings**: "Default is good enough to get started… set for your standard one-minute e-mini chart." Minimal parameter changes needed for mini Dow/NQ. (v190, [59:42])
8. **Implementation principle**: signal on bar close; software analyzes order flow and "serves it up on a platter" — human decides whether context justifies a trade. (v190, [38:56])
9. **Value area visualization**: colored box overlay on footprint bar (not a separate profile panel); reduces visual noise vs. drawing a separate bar-by-bar profile. (v190, [30:06])
10. **Bar-by-bar value area gap detector** (implied): code would flag when current bar's value area low > prior bar's value area high (bullish gap) or current bar's value area high < prior bar's value area low (bearish gap). (v192, [25:23]) [SPECULATIVE — implementation inference]

---

## Q. Notable verbatim quotes

1. "The last trader has bought one, the last trader has sold… it can't move anymore in that direction." (v190, [15:17]) — core reversal thesis.
2. "Delta zero — don't read too much into it… I think in all my analysis whenever I see a bar that has zero delta, don't read too much into it." (v190, [18:45]) — explicit null.
3. "Aggressive trading is actually what moves the market… when you have people lifting the offer or selling into the bids." (v190, [15:43]) — aggressor-driven model.
4. "You have a bullish divergence right here in the circle but… delta has decreased from the bar before… getting weaker and weaker… it pops back up but then it gets weaker stays weak and then just goes sideways on you." (v190, [41:24]) — the failed-divergence case in detail.
5. "Buy at your own risk because what you saw here, you saw the buyers in the delta the aggressive buyers decreasing getting weaker and then boom sellers took over." (v190, [36:37]) — explicit downgrade signal.
6. "The quicker you get into a position based on how you read what's happening in the order flow the tighter your stop is going to be, the tighter your stop, the lower your risk is going to be." (v192, [34:02]) — value-area-based early entry rationale.
7. "Just because you have a signal [that says] get long or get short it doesn't necessarily mean the market has to do that right, because you need other traders to also be getting long or getting short." (v190, [40:54]) — confirmation requirement; anti-mechanical.
8. "If you're watching a normal footprint chart if you know what to look for you can sort of see [market weakness] in the market… having software that will highlight to you when there's market weakness is a good thing." (v190, [38:02]) — discretion + software aid.
9. "When you're getting into new territories right new highs of the day or new lows of the day watch where value is forming." (v192, [29:26]) — location filter for value-area HOD/LOD setups.
10. "Value is where trade is being facilitated… where trade is not being facilitated… that's going to be an unfair value." (v192, [15:52]) — definition of value/unfair value pair underlying all build/gap setups.

---

## R. Contradictions / nuances

1. **Divergence alone is explicitly insufficient** — "just taking divergence by itself is not always a good thing." Divergence is a "pay attention" signal, not a trade trigger. Confluence with strengthening delta + imbalances + value area is required. This is a direct anti-mechanical statement. (v190, [39:28]) [REPEATED throughout chunk]
2. **Positive delta at a high can be completely irrelevant** — if subsequent bars show delta weakening and bar makes lower high/lower low, positive delta in a prior bar means nothing. Overrides surface reading of "positive delta = bullish." (v190, [36:37]) — calibrates the simple delta rule.
3. **"Same software works on every market / time frame" with a 15-minute caveat** — explicitly states 15-min chart is for finding retracement zones, not for real-time order flow signals; consistent with the "same settings" nuance already in digest, but the 15-min caveat adds specificity. (v190, [50:20])
4. **Value area 70% vs. 68%**: states both are acceptable, "not going to make much difference." Softens the 70% threshold — it is a convention, not a precise rule. (v190, [30:36])
5. **Pre-cash-open signal quality**: signals before 8:30 CT on thin bars (3-4 price levels per bar) are explicitly called "kind of difficult" — partial degradation of model, not a hard exclusion. (v190, [44:02])
6. **Imbalance minimum count stated explicitly**: "Two imbalances honestly is nothing to get excited about" — two stacked imbalances below the accepted threshold (3+). (v190, [22:14]) Strengthens the 3+ stacked rule.
7. **EVA/POC Slingshot/Order Flow Sequencing are named composite signals**, not raw order flow primitives — they are calculated/proprietary outputs from Orderflows Trader software. Their internal logic is not disclosed. This limits direct NinjaTrader replication unless they are independently derived. (v191, [02:30]; v192, [36:03]) [ONCE — important implementation caveat]
8. **Market sweep can occur without stacked imbalances** — sweep is sometimes the earlier/purer signal; stacked imbalances may follow but are not required for a sweep to be valid. Inversely, stacked imbalances without a sweep = weaker signal. (v190, [50:59])

---

## Coverage note

v190 (InvestorExpos presentation, Oct 2020) is the richest transcript — a structured 60-min training session covering the full model from basics through advanced tools; yields the most extractable model content. v192 (Nov 5 InvestorExpos, "Low Risk Volume Based Strategies") is also moderately rich, introducing three named setups with explicit entry/stop logic. v191 (Nov 2 FED Week brief) is thin — a 7-minute market recap with named tool references but minimal new model logic; primarily confirms that the v191-era software includes EVA, POC Slingshot, and Order Flow Sequencing as named tools. All three transcripts contain substantial sales/marketing content that was filtered out.
