# Chunk 020 Extraction
- Source chunk: Chunk_020_Orderflows_Transcripts.md
- Transcripts covered:
  - v18 — Order Flow Indicator The Valtos Flip Orderflows Analysis And Setups (2017-02-08)
  - v19 — Order Flow Indicator Valtos Transition Orderflows Analysis Tool (2017-02-11)
- Overall content value: mixed

## A. Setup types & names he uses

- **The Valtos Flip** — an indicator (not a pure discretionary setup) that detects bars where one side (bid or ask) dominates volume by ≥95%, signaling a possible immediate change in market direction (bullish or bearish). The flip fires when "in near total control" — one side has ~95–99.8% of bar volume. (v18, "Valtos Flip", [05:42])
- **The Valtos Transition** — a separate indicator (Mike's stated "personal favorite" of his three) that compares volume and delta changes over a lookback period to detect shifts in supply and demand balance. Signals a supply→demand or demand→supply transition (bullish or bearish). (v19, "Valtos Transition", [01:24])
- **The Valtos U-Turn** — named as part of the three-indicator package but not described in detail in this chunk. (v19, [00:27])
- **Sweeping the market** — large participant comes in and buys/sells everything in the order book across 3–4 price levels to get a position done quickly; "quick accumulation or quick distribution." Not a trade setup name per se, but the underlying mechanism the Flip detects. (v18, [10:19])
- **Trend-day recognition** — both indicators serve to keep a trader on the right side on trend days, generating a sequence of same-direction signals throughout the session. Mentioned explicitly for the Flip on strong trend days. (v18, [01:01:48])

## B. Tiering / grading language — HIGH PRIORITY

- **"One of my personal favorite indicators"** — the Valtos Transition is explicitly graded as Mike's favorite of the three newly released indicators. The reason: it represents "more subtle forces at work — supply and demand, momentum, and public perception about price." (v19, [01:24])
- **"I do think it's a great tool and I do think it's underutilized and misunderstood"** — his overall verdict on the Transition indicator. (v19, [01:14:12])
- **Signal quality language used for the Flip**: "decent signal," "nice move," "nice trade," "nothing really," "failure," "sideways." He makes no explicit A/B/C grading of individual Flip signals in this chunk, but consistently evaluates signals contextually by: (a) time of day, (b) whether market is trending or ranging, (c) whether the signal fires before vs. during news. [ONCE]
- **"Stronger signal" vs. "weaker signal"** — higher intensity number = lower threshold = weaker signal; intensity=1 is "about as strong as you can get." Strength is operationally defined by the threshold for how dominant one side must be. (v18, [30:41])
- **Thin market vs. thick market settings** — signals on thin markets (NQ, YM, EUR/USD on 1-min) produce more noise; he characterizes their month of results as "average at best, maybe break even." Thick markets (5YR, ES) produce cleaner results when settings are properly scaled. (v18, [59:41]) [SPECULATIVE: grading inference from his commentary]
- **"Not going to be very effective on a 15-minute chart"** — Mike explicitly rates orderflow indicators as ineffective on long time frames due to signal frequency drop; effective range is short intraday time frames. (v18, [01:14:58])

## C. Order-flow story & psychology per setup

**Valtos Flip — mechanism:**
- A "big buyer" or "big seller" sweeps the market: ~95%+ of bar volume is on one side (offer for buyers, bid for sellers). "All the buying is aggressive buying and there's nothing being traded on the other side." (v18, [05:42])
- This represents institutional accumulation or distribution: "long-term traders coming into the market, they have a view and they start accumulating a position or if it's at a high they start distributing a position." (v18, [14:21])
- After the sweep, "there's no more sellers" (or buyers), creating a vacuum that causes the market to move — "absence of buyers or sellers" is what causes the market to move after a sweep. (v18, [01:10:46])
- Opposite signals firing immediately (next 1–2 bars) is normal — algos detect mispricing and "snap it back" to fair value quickly. Not a reason to abandon the indicator. (v18, [15:17])

**Valtos Transition — mechanism:**
- Measures when supply/demand balance is shifting: "compares the volume and delta changes over a period of time." (v19, [16:00])
- Based on the concept of **absorption**: "when the market contracts and you trade around value for a while because everyone's happy trading at a certain price... buyers and sellers are evenly matched." A transition fires when this equilibrium breaks. (v19, [22:47])
- Max Balance Volume parameter measures "when buyers or sellers are roughly around evenly matched." When that balance tilts, the signal fires. (v19, [23:20])
- Ratio Balance parameter measures the percentage change in supply/demand tilt: 400% = supply/demand ratio shifts 4x. (v19, [21:11])

## D. Exhaustion clues

- **95%+ bar volume on one side** — the extreme single-bar dominance is the Flip's exhaustion signal; it's exhaustion of the opposite side (no sellers when a big buyer hits the ask, no buyers when a big seller hits the bid). (v18, [05:42]) [ONCE]
- **Market goes "extremely fast"** — the bar closes fast when 95–99.8% on one side; speed itself is a corroborating signal. (v18, [05:42]) [ONCE]
- No other specific exhaustion clues from footprint charts are introduced in this chunk beyond what the indicators automate.

## E. Absorption clues

- The Transition indicator's **Max Balance Volume** parameter directly operationalizes the absorption concept: when the market is ranging/absorbing, delta changes are small (buyers and sellers roughly equal). The Transition fires when this period of equal buying/selling ends. (v19, [22:47])
- **"Trading around value for a while"** / tight value area = absorption phase — price stagnates because both sides are content at current price. This is background context the Transition watches for before signaling a breakout. (v19, [23:20]) [ONCE]

## F. Stacked imbalance ideas

— nothing in this chunk — (Both videos are about the Flip and Transition indicators, not stacked imbalances directly. The Transition ratio balance of 400% mirrors the 4:1 imbalance ratio standard mentioned as a reference point, but is not about stacked imbalances.)

Note: v19 mentions "looking at imbalances in the market, the standard that people use for that is 400%" as a reference to justify the ratio balance setting, but does not add new stacked-imbalance methodology. (v19, [21:42])

## G. Delta / delta-divergence ideas

- The **Flip** is delta-based: "deals with delta, which is the difference between the volume traded on the bid, the volume traded on the offer." Signal fires when delta is extremely one-sided within a bar. (v18, [19:04])
- **Delta threshold (delta 1 / delta 2)** parameter in the Flip: minimum delta required for the indicator's calculations.
  - Thin markets: ~25 (v18, [32:18])
  - Medium markets (crude oil): 75–100 (v18, [32:46])
  - 5-year notes: ~200 (v18, [33:16])
  - Bonds: ~200 (v18, [01:13:15])
  - E-mini (thicker markets): 250 (v18, [30:10])
  - [REPEATED] across multiple markets in the video
- **The Transition** also uses delta changes as part of its calculation: "compares the volume and delta changes over a period of time." (v19, [16:00]) Exact formula not disclosed.
- **Neutral balance zone** — the Transition's max balance volume tracks when delta is near-neutral (buyers ≈ sellers), which is the pre-transition absorption state. (v19, [23:20])

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- Opposite-signal sequences (e.g., Flip buy followed immediately by Flip sell) represent market makers or algos detecting a sweep as mispricing and correcting it within 1–2 bars. Mike calls this normal, not a failed breakout per se — just a snap-back. (v18, [15:17]) [ONCE]
- He does not use the terms "stop-run," "liquidity sweep" (in the trading-concept sense), or "failed breakout" in this chunk.

## I. Trapped-trader ideas

— nothing in this chunk — (Trapped-trader language is not used in either video; focus is on institutional sweeping and supply/demand transitions.)

## J. Entry triggers (the exact "go" event)

**Valtos Flip:**
- Entry trigger: a Flip signal print (triangle up = buy, triangle down = sell) on a bar where one side dominates ≥95% of volume. Enter at or near the signal bar's close (or next bar open). (v18, [05:42])
- Flip A = signal fires on the signal bar itself (immediate); Flip B = signal fires within 1–2 bars afterward if not immediate. He treats them identically for entry purposes. (v18, [29:14])

**Valtos Transition:**
- Entry trigger: Transition signal print after a supply/demand imbalance is detected via the ratio balance and max volume criteria. (v19, [16:00])
- No explicit "exact tick of entry" method described beyond "take the trade when the signal fires."

**Both:**
- Entry is on the signal bar close or the next bar; Mike refers to "entry bar" and "signal bar" as distinct — enter in the bar after the signal bar. (v18, [01:03:25])

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **"Works immediately"** — if you buy and it "comes down against you really quick, really fast," that's evidence you're wrong. Expectation is immediate follow-through. (v18, [18:01]) [REPEATED — consistent with digest]
- **Trailing stop justification** — on the Transition, Mike explicitly calls trailing stops appropriate because the indicator can produce multiple same-direction signals on a trend day, and trailing allows staying in longer. "If you're trailing your stop at least you're getting out somewhere up here rather than down in here." (v19, [50:58])
- On trend days the Flip produces "a sequence of same-direction buy signals" and "keeps you on the right side of the market all day long." The confirmation of a trend-day is simply getting successive same-direction signals. (v18, [01:01:48])

## L. Invalidation — what should NOT happen / what kills the thesis

- **Price violates the signal bar high/low by a few ticks** — "if you violate where your entry is" = wrong. Mike references a 2–3 tick stop beyond the signal bar. "If it's trading up where this carrot is (triangle), that's where your stop is." (v18, [39:05]; [01:02:58])
- **Opposite-direction Flip signal immediately after entry** — he says do NOT be discouraged, but this is effectively an early invalidation warning. If you're short and you get an immediate buy signal, you should re-evaluate. (v18, [15:17])
- **News/announcement period** — taking any signal into a data release (NFP, Fed) is treated as invalid context regardless of signal quality. (v18, [21:30]; v19, [25:29])
- **Pre-cash open on equity markets** — signals before 8:30 CT in NQ and YM are considered invalid/unreliable. (v18, [49:55]; v19, [43:18])
- **After 2:00 PM CT in currencies** — liquidity dries up; signals after this time are "not interested" or at best marginal. (v18, [36:26]; v19, [30:40])

## M. Stop / risk / target / trade management

- **Stop: 1 tick beyond the signal bar extreme (2–3 ticks from entry)** — specifically cited: signal bar low at 91.75, if trading reaches 91.25 = wrong (two ticks of stop). Entry in the next bar at 92.25; stop = 3 ticks. (v18, [01:03:25]) [REPEATED — confirms digest's 1-tick stop]
- **Small losses are explicitly acceptable** — he runs through sequences of 3–4 small losses to catch one big winner as the intended risk/reward structure. "Take small losses, let your winners run." (v18, [04:14]) [REPEATED]
- **Trailing stops recommended for Transition indicator** — "trail your stop… at a minimum." Suggested to lock in profits on moves that can turn quickly. (v19, [50:58]; v18, [55:56]) [ONCE — trailing stop is a direct recommendation here]
- **Time stop (~2 PM cut-off)** — not a formal time stop but he "isn't interested" in trades after 2 PM in currencies and after market-day dwindles. (v18, [36:26])
- **Targets: discretionary** — no fixed targets mentioned. He references "couple points," "couple ticks," "50 point move" as examples of wins, but no rule. [NEEDS-OPERATIONALIZATION]
- **"You should have done something, taken some money off the table"** — partial-profit concept mentioned in passing for positions that run well. (v18, [25:33]) [ONCE]

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

**Session / time:**
- US products: trade 7:00 AM–3:00 PM CT; "outside those times, less volume and underlying cash markets are closed." (v18, [18:34]) [REPEATED]
- Euro currency specifically: effective 7:00 AM–2:00 PM CT; after 2 PM "liquidity really dries up until the Asian session." (v18, [36:26]; v19, [30:40]) [ONCE — 2 PM cut specific to EUR]
- Equity futures (NQ, YM): wait until cash open at 8:30 CT; pre-market signals are unreliable ("slow-moving times," chop). (v18, [49:55]; v19, [43:18]) [REPEATED]
- Dax: tradeable after European cash close because it follows US market direction, essentially becoming a "slave" to the S&P. (v19, [16:29]) [ONCE]

**News / announcements:**
- Avoid all data releases: NFP, Fed, CPI, unemployment number; "volume dries up and you get quick moves in seconds." Wait ~15 minutes post-release to let market settle. (v18, [21:30]; v19, [25:29]) [REPEATED]
- "I give it about 15 minutes" post-NFP before re-engaging. (v18, [25:33]) [ONCE — specific 15-minute post-NFP window confirmed]

**Regime:**
- Trend days: both indicators excel, keep you on the right side; multiple same-direction signals throughout the day. (v18, [01:01:48])
- Ranging/sideways: more noise, more small losses; you must "stick with it." Not a reason to stop trading but expectations lower. (v18, [01:02:58])
- Market is in a range + Flip fires: more likely snap-back opposite signal follows quickly. (v18, [17:13])

**Liquidity / instrument:**
- Thin markets (mini Dow, NQ, EUR 1-min): settings 1 and 25 for Flip; more noise, "average at best." (v18, [59:41])
- Thick markets (ES, 5YR, 10YR): settings 1 and 250 for Flip; cleaner signals. (v18, [30:10])
- Bonds (ZB): Flip delta setting ~200; slightly lower than 5YR. (v18, [01:13:15])
- 5-year notes (ZF): Flip delta ~200; "nice chart to trade, when it trends it moves quite nicely, very liquid." (v18, [01:05:30])
- Order flow "loses effectiveness" over longer durations (15-min, 30-min charts); primarily intraday short-term. (v18, [01:14:58]) [REPEATED]
- For E-mini Transition with max balance volume = 100: almost no signals because "volume of 100 is nothing on a one-minute chart" where bars have 8,000–10,000 contracts. May need 200–500 on ES. (v19, [01:02:30]) [ONCE — explicit scaling issue for ES]

## O. Directly testable / measurable variables

- **Flip intensity parameter** — ranges from 1 (strongest / hardest to trigger) upward; higher = more signals, lower quality. Intensity = 1 is about as strong as possible. (v18, [30:41]) [NEEDS-OPERATIONALIZATION for exact threshold mapping]
- **Flip delta threshold** — minimum bar delta required:
  - Thin (EUR, YM, NQ): 25 (v18, [32:18])
  - Medium (crude): 75–100 (v18, [32:46])
  - 5-year / bonds: 200 (v18, [33:16]; [01:13:15])
  - ES / thick: 250 (v18, [30:10])
- **95% one-side volume threshold** — the operative definition of "total control" for a Flip signal; 99.8% cited as an extreme example. (v18, [05:42]) [NEEDS-OPERATIONALIZATION — is 95% literally the cutoff in the code, or a descriptive number? Not confirmed as exact code value]
- **Flip A vs. Flip B**: A = same bar; B = within next 1–2 bars. Binary on/off per parameter. (v18, [29:14])
- **Transition lookback period** — 3 bars (default/preferred); 5 acceptable; do not exceed ~10 for this specific indicator. (v19, [20:13])
- **Transition ratio balance** — 400 (= 400% shift, i.e., 4:1 ratio change); previously used 300 and 500; settled on 400. (v19, [21:11])
- **Transition max balance volume** — 100 works across most contracts; thin markets: try 50; ES may need 200–500 due to high bar volume. (v19, [23:53]; [01:02:30])
- **Post-NFP wait window** — ~15 minutes before re-engaging. (v18, [25:33])
- **2:00 PM CT cut-off** — currencies; after this time "not interested." (v18, [36:26])
- **8:30 CT cut-off** — equity futures cash open; do not trade NQ/YM pre-cash. (v19, [43:18])
- **Time frame effectiveness floor** — 15-minute charts: "probably not going to be effective"; effective range is intraday short-term (1-min, range charts). (v18, [01:14:58])

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Flip A / Flip B as separate sub-signals** — both are rendered as differently sized triangles (up/down) on bar charts. Can be toggled independently via True/False parameters. (v18, [29:14])
- **Signal renders on bar chart** (not just footprint) — indicators are designed to run on standard bar/candle charts, making footprint unnecessary for the signal itself. This is a deliberate design choice for accessibility. (v18, [10:35]; v19, [10:11])
- **Intensity parameters (1 and 2)** map to internal thresholds; intensity = 1 = tightest. Lowering the number tightens the signal. Avoid intensity = 0 (NinjaTrader behavior unreliable at zero). (v18, [30:41])
- **Per-instrument settings templates** — he saves different templates per instrument/timeframe; "save your template." Settings are not universal defaults. (v19, [27:45])
- **Transition parameter structure** implied: Period (lookback bars), Ratio Balance 1 (supply-to-demand %), Ratio Balance 2 (same), Max Balance Volume (delta neutrality threshold). Four parameters total. (v19, [19:38])
- **Transition on E-mini 1-min: max balance volume needs scaling** — at 100, generates almost no signals on ES 1-min due to bar volume being 8,000–10,000+. Implies need for instrument-aware volume scaling in implementation. (v19, [01:02:30])
- **Range charts vs. time charts** — both indicators work on range charts; Mike notes range charts sometimes work better because bars close on price movement not time, reducing time-based noise. (v18, [45:35])
- **Provisional intrabar behavior not discussed** in these videos; focus is on post-close signal evaluation.
- The three indicators (Flip, U-Turn, Transition) are bundled with the main Orderflows Trader software as of this video; not sold separately at time of recording. (v18, [01:13:44])

## Q. Notable verbatim quotes

1. "In near total control. And you know there are instances where in a bar nearly all the volume, 95%, even in some cases you know 99.8% of the volume is traded on one side." (v18, [05:42]) — defines the Flip threshold.

2. "What causes the market to move is absence of buyers or sellers. And what that means is if you have a big buyer come in and sweep the market, lift up all the sellers, there's no more sellers. And that's how you get this market to move like that." (v18, [01:10:46]) — core mechanism of the Flip.

3. "Order flow over the longer the duration tends to lose its effectiveness... you can use orderflow on a 15-minute chart, a 30-minute chart, but you're going to get very, very few trading signals." (v18, [01:14:58]) — time frame filter.

4. "The Voltos transition... it's actually one of my personal favorite indicators that I had programmed... what they do is they're not necessarily supposed to be black box take every single signal as it occurs." (v19, [01:24]) — grading the Transition; explicit "not a black box" warning.

5. "What this indicator Valtos transition does is becomes a visual representation of the more subtle forces at work: supply and demand, momentum and public perception about price of the market." (v19, [06:09]) — defines the Transition's concept.

6. "When you're in an area of absorption, you know buyers and sellers are evenly matched. And what this max balance volume measures is measuring when buyers or sellers are roughly around evenly matched." (v19, [23:20]) — operationalizes absorption in indicator terms.

7. "I give it about 15 minutes [after NFP] but this is 7:42ish... you get a nice trend now, the trends are going to start to develop." (v18, [25:33]) — specific post-news re-entry timing.

8. "If you violate, you know, where your entry is, right? If it comes down against you really quick, really fast... you know, if we're getting a tick or two below there, three ticks below, I know I'm wrong." (v18, [18:01]; [01:03:25]) — stop logic and invalidation.

9. "After 2 p.m. liquidity really dries up. So be careful if you're trading after 2 p.m." (v18, [36:26]) — EUR currency time filter.

10. "For the E-mini, volume of 100 is very small on a one minute chart. Some of these bars I know got volumes of 8,000, 10,000 so it's going to be very, very rare." (v19, [01:02:30]) — max balance volume scaling issue for ES.

## R. Contradictions / nuances

- **"Same settings for every market" vs. "you can't use the same settings"** — In the digest, "same settings every market" refers to the detector concept. Here, Mike very explicitly and repeatedly states the *opposite* in operational terms: you MUST change settings per market and timeframe. This is not truly contradictory (the concept/model is the same; the parameter values differ per market), but it creates real confusion for users. The nuance: the *indicator logic* is universal; the *parameter values* (delta, intensity, max balance volume) must be scaled to each market's liquidity. (v18, [00:26]; [03:13]; v19, [00:55]) [REPEATED]

- **95% threshold for Flip**: This is described verbally as the defining criterion ("95% or more"), but Mike does not confirm whether 95% is literally coded as the threshold or is descriptive shorthand. The intensity parameter (1–5+) adjusts this threshold indirectly, suggesting 95% is not a hardcoded constant but a description of the extreme case. (v18, [05:42]; [30:41]) [SPECULATIVE]

- **Transition lookback 3 bars vs. Flip's apparent single-bar window**: The Transition explicitly looks back 3 bars (with 5 as acceptable max ~10 outer limit). The Flip appears to be a single-bar event. This means they operate on different temporal scales and are conceptually complementary rather than redundant. (v19, [20:13]; v18, [05:42]) [ONCE]

- **Opposite Flip signals (snap-back) are "not a reason to be discouraged"** — but Mike also says if price violates your stop level "really quick, really fast" that means you're wrong. These are in mild tension: how do you distinguish an algo snap-back (ignore) from a true invalidation (stop out)? Resolution: use the explicit stop level (1–3 ticks beyond signal bar extreme) as the decision rule, not a subsequent opposite signal alone. (v18, [15:17]; [18:01])

- **Thin markets "average at best, maybe break even"**: Mike shows the mini Dow 8-range chart results and explicitly calls them "average at best, maybe break even, maybe a small loss." This is unusually candid about indicator limitations on thin markets and directly grades the instrument as lower-quality context for the Flip. (v18, [59:41]) [ONCE]

- **Transition ratio balance 400% aligns with standard imbalance ratio 4:1**: Mike explicitly connects these two numbers, suggesting the 4:1 (400%) imbalance standard is a foundational number across his entire methodology, not just the stacked-imbalance detector. "Even when you're looking at imbalances in the market, the standard that people use for that is 400% as well." (v19, [21:42]) — This could be useful NT implementation note: the Transition and the footprint imbalance detector share the same underlying ratio threshold concept.

## Coverage note

v18 (Valtos Flip) is moderately rich for indicator mechanics (intensity/delta parameters, market-specific settings, the 95% threshold concept, sweeping mechanism) but relatively thin on pure reversal model content — it is primarily an indicator tutorial with a large portion devoted to showing January 2017 chart walk-throughs across multiple instruments. v19 (Valtos Transition) is similar in structure: valuable for the Transition indicator's parameter details and the absorption/supply-demand-shift concept, but heavy on walk-through commentary with limited new theoretical content. Neither video introduces core A+ reversal criteria beyond confirming known thresholds; both are most useful for indicator implementation details and per-instrument settings calibration.
