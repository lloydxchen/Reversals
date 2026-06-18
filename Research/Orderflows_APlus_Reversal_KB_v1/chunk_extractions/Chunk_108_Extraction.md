# Chunk 108 Extraction
- Source chunk: Chunk_108_Orderflows_Transcripts.md
- Transcripts covered:
  - v266 — Orderflows & Markers Plus Trading Workshop: Automate Order Flow (2022-09-08)
  - v276 — Price Scalper Workshop: Combine Price Action and Order Flow (2022-09-24)
  - v336 — Introducing Orderflows Trader on GoCharting: A Web-Based Footprint Chart (2023-08-09)
- Overall content value: thin

---

## A. Setup types & names he uses

- **Prominent Point of Control (bullish/bearish)** — described as an almost-automatic trade signal; bullish POC + price-scalper confirmation = high-quality opportunity. (v276, "Price Scalper Workshop", [02:09], [32:42], [41:22])
- **Delta Divergence** — new low with positive delta (bullish divergence); shown as a price-scalper trigger context. (v276, [36:56])
- **Stacked Buying / Selling Imbalance** — mentioned as order-flow confirmation filter for price-scalper signals. (v276, [35:12], [44:36])
- **Multiple Imbalances** — mentioned alongside stacked imbalances as reinforcing the direction. (v276, [44:36])
- **Sequencing** — a separate indicator for "nice levels"; used with price-scalper for confluence. (v276, [32:02], [37:32])
- **Delta Scalper signals** — used as automation input to Markers; interchangeable with Flow Shifts, Stratum, Price Rejector, Turns. (v266, [42:54])
- **Flow Shifts (bullish/bearish)** — used as Pablo's automation example; long/short plots. (v266, [09:33])
- **Stratum** — new indicator (magnitude level=1 baseline); signals automated via Markers. (v266, [57:36])
- **Price Scalper** — combines price action + order flow; deep blue/deep red pre-signal bar, then up/down triangle on next bar as actual signal. Not a bot; does not auto-trade. (v276, [00:01], [20:06])
- **Turns** — momentum indicator; mentioned as complementary to Price Scalper. (v276, [25:53])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **"Almost an automatic trade"** — Prominent POC with follow-through order flow; his strongest grading language in these videos. (v276, [1:07:51], [1:08:19])
- **"Great trading opportunities"** — when price action is backed up by order flow (POC + Price Scalper). (v276, [02:09])
- **"Good trade"** — heavy stopping volume at a level + price action confirming. (v276, [32:42])
- **"Legitimate sign"** — stacked buying/selling imbalance followed (possibly one bar after) by price-scalper signal. (v276, [35:42])
- **"A lot of coincidence"** — multiple order-flow indicators hitting the same bar; he does NOT view this as additive confluence, explicitly skeptical. (v276, [27:41]) [ONCE]
- **"More signals than you want"** (too many) — using lowest swing-filter setting on volatile markets without a trend filter; implies these are lower quality. (v276, [27:41], [28:14])
- **Swing-filter setting as quality gate**: lower = more signals / lower quality; higher = fewer signals / higher selectivity. Specific starting points by market class given (see Section O). (v276, [06:06])

---

## C. Order-flow story & psychology per setup

- Price-scalper pre-signal bar (deep blue / deep red) = "things are manifesting" — a visual heads-up that the conditions are forming but not yet confirmed. The signal itself fires on the next bar only. (v276, [20:06])
- POC with stopping volume: heavy volume arriving at a level = "Traders stepping up to this level." Price action then confirms the order-flow story. (v276, [32:42])
- Delta divergence (new low + positive delta): buyers stepping in aggressively even as price makes a new low — trapped sellers covering; bullish reversal implication. (v276, [36:56])
- Automation (Markers) idea: once in a trade, trader's cognitive load shifts to *managing* the trade (reading live order flow, adjusting stops) rather than *finding* the entry. This is described as "freeing up your brain." (v266, [06:04])

---

## D. Exhaustion clues

- **Market Exhaustion indicator** — mentioned by name as likely working well in combination with Price Scalper. Not described in detail here; described as a standalone order-flow indicator. (v276, [43:10]) [ONCE]
- Delta divergence (new low with positive delta) explicitly described as a pre-signal exhaustion read on a Price Scalper signal bar. (v276, [36:56])

---

## E. Absorption clues

- Prominent POC as stopping volume = absorption: "Prominent point of control indicates stopping volume in the markets." Heavy volume at a level where price is absorbed before reversal. (v276, [32:42]) [REPEATED per v266 and v276]
- Thin prints (GoCharting): single-contract (or very-low volume) cells in the footprint indicate areas of *lack* of absorption — price moved fast with no two-way auction, implying momentum and potential vacuum for price to fill. (v336, [05:39], [06:15])

---

## F. Stacked imbalance ideas

- Stacked buying imbalance used as an order-flow confirmation for a Price Scalper signal. He does NOT require it to fire on the same bar; proximity is sufficient. (v276, [35:12])
- Multiple imbalances: mentioned alongside stacked imbalances as reinforcement. (v276, [44:36])
- No new threshold or ratio information beyond what is already captured in the digest.

---

## G. Delta / delta-divergence ideas

- Delta divergence (new low + positive delta) shown as the context for a Price Scalper bullish signal. Explicitly called out: "you got divergence here, you got a new low with positive delta." (v276, [36:56])
- Automation potential: cumulative delta slope (rising/falling) mentioned as a possible filter for Markers — only take longs if cumulative delta is rising relative to prior bars, or if POC averages are rising. Not yet released at time of recording. (v266, [46:39]) [ONCE, SPECULATIVE/future feature]
- Delta scalper is named as interchangeable with Flow Shifts, Stratum, Price Rejector in automation setups. (v266, [42:54])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

— nothing in this chunk beyond what is already in the digest —

---

## I. Trapped-trader ideas

— nothing substantively new in this chunk; automation context only —

---

## J. Entry triggers (the exact "go" event)

- **Price Scalper**: signal is NOT on the pre-signal bar (deep blue/red "manifesting" bar). The actual signal (up/down triangle) prints on the bar *after* conditions are met — i.e., bar-close confirmation. Entry on the confirmation bar or next bar. (v276, [20:06], [20:37], [40:46])
- **Combined entry (Price Scalper + POC)**: wait for bullish/bearish Prominent POC, then wait for Price Scalper signal to fire. Example: POC at low, price scalper confirms → long entry. (v276, [41:22])
- **Markers automation (Delta Scalper / Flow Shifts / Stratum)**: signal fires on bar close (or each tick for copies); Markers takes the trade automatically via stop order at signal price. (v266, [16:54], [42:24])
- **Trend filter required**: with HMA (or WMA) slope filter, longs only when line slopes up, shorts only when slopes down — otherwise signal is suppressed. (v266, [43:30], [46:06]; v276, [11:44])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- After Price Scalper entry at a POC: "quick six points out of the market" cited as example. (v276, [41:22])
- "If it's not going in your favor, cut it as soon as you can." The flip side: immediate adverse movement is a reason to exit quickly. (v276, [18:33])
- No new "follow-through within N bars" threshold stated beyond what is in the digest.

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Price Scalper**: "if we're starting trading below the signal bar [on a long] that's where I'd be looking to get out." Signal bar is the invalidation reference (not the trigger bar). (v276, [45:46])
- "Don't need it to sell off 20 ticks — if it's trading below the signal bar, I'm getting out." Speed of invalidation implied quickly. (v276, [45:46])
- **Trend filter**: any signal fired against the HMA/WMA slope direction is automatically suppressed — not even considered. (v266, [52:34])

---

## M. Stop / risk / target / trade management

- **Price Scalper demo stop**: "definitely below the signal bar" (not the trigger bar) for longs. (v276, [45:46])
- **Markers ATM example (e-mini, 3 lots)**:
  - Target 1: 16 ticks, 2 contracts
  - Target 2: 24 ticks (runner), 1 contract
  - Stop: 8 ticks (both contracts) → ratio 2:1 (first target), 3:1 (runner) (v266, [44:00]) [ONCE]
- **Alternative ATM**: 8 tick stop / 14 tick take-profit also cited as "pretty consistent." (v266, [50:47]) [ONCE]
- **Night vs. day session stop note**: 8-tick stop is "okay" overnight; during day session, volatility picks up and 8-tick stop is too tight — wider stop needed during regular hours. (v266, [45:01], [54:15])
- "Trading is a marathon not a sprint" — single stop-outs do not change the plan. (v266, [49:49])
- Active management preference: he prefers to move stops manually into profit rather than set-and-forget. Example: market selling off → move stop down to lock in profit even if it means early exit. (v276, [18:33], [19:10])
- "Automation gets you in the trade, but then you can still trade — do your job as a Trader." (v266, [53:41])
- **Time frame**: he stays within 30-second to 5-minute charts; does not go beyond 5-minute for trading (looks at higher TF but does not trade from it). (v276, [19:36])
- **Time-based charts preferred over range charts** for volatile modern markets: range bars cause late entries on fast moves; time bars allow better trade management because of the time component. (v276, [49:40], [51:33])

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Trend filter (HMA or WMA slope)**: only take longs if moving average is sloping up, shorts if sloping down. HMA-50 used in one Markers demo; WMA-14 in another. (v266, [43:30], [1:00:09]; v276, [53:59])
- **Bar-pattern filter (Markers logic)**: e.g., green-red-red for shorts or red-red-green-bar after signal bar, added as secondary filter in automation. Not a standalone model rule — used to reduce over-trading automation. (v266, [23:54], [34:10])
- **Market class / instrument volatility filter** (Price Scalper swing-filter settings):
  - Slow markets (ZB, ZN, Ultra Bonds, 10-yr): swing filter = 1 (no trend filter needed on slowest moving) (v276, [06:06], [13:59])
  - Normal markets (currencies, ES): swing filter = 5–10 (v276, [06:06])
  - Fast/volatile markets (DAX, NQ, MNQ): swing filter = higher (author mentions 10 for crude, ~same tier as e-mini/euro) (v276, [06:06], [28:14])
  - Dow Jones: swing filter = 25 starting point (v276, [39:34]) [ONCE]
- **Overnight vs. day session**: overnight has quieter conditions; day session has higher volatility → different stop/target parameters needed. (v266, [44:29], [54:15])
- **Centralized futures data preferred over Forex spot** (decentralized/fragmented data); GoCharting supports CME contracts, not NYMEX (crude oil/gold), CBOT, or options. (v276, [16:45]; v336, [14:20], [15:36])
- **GoCharting platform**: web-based; Orderflows Trader features include exhaustion prints, imbalance reversals, ratios, slingshot, POC, market weakness, sequencing, sweeps, prominent POC, inverse imbalance, zero prints, thin prints, tails. Thin prints = low-volume cells in footprint highlighting momentum areas / price discovery gaps. (v336, [02:30], [05:39])

---

## O. Directly testable / measurable variables

- **Price Scalper swing-filter settings by market class**:
  - Slow (bonds, rates): 1 [REPEATED]
  - Normal (currencies, ES, MES): 5–10 [REPEATED]
  - Fast/volatile (NQ, MNQ, DAX): higher (10+ implied) [NEEDS-OPERATIONALIZATION — upper bound not stated]
  - Dow Jones: 25 [ONCE]
  - Crude oil: ~10 [ONCE]
- **Trend filter comparison value (HMA/WMA for Markers)**:
  - Long filter: current_bar_value > previous_bar_value [REPEATED across v266 and v276]
  - Short filter: current_bar_value < previous_bar_value [REPEATED]
- **HMA period used in live demo**: 50 (v266, [1:01:26]) [ONCE]
- **WMA period used in Price Scalper demo**: 14 (v276, [53:59]) [ONCE]
- **ATM stop (Markers / e-mini, 3-lot)**: 8 ticks [ONCE]
- **ATM target 1**: 16 ticks / 2 contracts [ONCE]
- **ATM target 2 (runner)**: 24 ticks / 1 contract [ONCE]
- **Alternative ATM**: 8 tick stop / 14 tick target [ONCE]
- **Signal confirmation timing (Price Scalper)**: signal prints on bar *after* pre-signal bar (bar-close based); NEEDS-OPERATIONALIZATION for exact look-back criteria
- **Markers timeout threshold**: 5,000 ms (5 seconds) default; can be increased (example given: 100,000 ms = 100 seconds). (v266, [31:29]) [ONCE]
- **Thin print threshold (GoCharting demo)**: 5 contracts (≤5 contracts at a price level = thin print, indicating momentum/price discovery). (v336, [05:39]) [ONCE]
- **Maximum simultaneous markets to trade**: ~5–10 (practical computer limit per Mike). (v266, [1:04:47]) [ONCE, NEEDS-OPERATIONALIZATION]

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Markers automation (third-party, Pablo's tool)**: reads indicator plots (triangle up = long, triangle down = short) as variables; executes ATM strategies automatically. Supports fast-signal mode (each tick) and bar-close mode. (v266, multiple)
- **Tick replay NOT required for live trading**: his NT8 indicators calculate correctly from live tick stream without historical tick replay; tick replay only needed for historical backtesting/visual. (v266, [36:31], [37:26]; v276, [40:06])
- **Markers copy timeout**: 5-second default timeout — if indicator takes >5s to calculate, result returns false and no trade is taken. Can be increased to 100,000ms. Relevant for any CPU-heavy indicator. (v266, [31:29])
- **Signal on bar close, no repaint**: "once they plot they're not supposed to change anymore." (v276, [46:22]) [REPEATED]
- **Bar-width setting in NT (Data Series)**: must be set to "2" on footprint charts to avoid wide candle overlap with Price Scalper triangles. (v276, [09:29])
- **GoCharting / web-based platform**: Orderflows Trader ported to GoCharting (web). Features: exhaustion prints, imbalance reversals, POC, sequencing, sweeps, thin prints, tails, slingshot, inverse imbalance, zero prints, market weakness. (v336, [02:30])
- **New version of Orderflows Trader (coming at time of recording)**: planned to make footprint signals (delta divergence, exhaustion prints, imbalance reversals, POC, stacked imbalances, slingshots, sequencing, market weakness/sweeps) readable by automation tools like Markers. (v266, [04:51], [1:02:55]; v276, [48:18])
- **Cumulative delta slope as filter**: future feature idea — read whether cumulative delta is rising/falling across bars and use as a Markers filter for direction. (v266, [46:39]) [ONCE, SPECULATIVE]
- **POC average rising/falling as filter**: similar future idea. (v266, [46:39]) [ONCE, SPECULATIVE]

---

## Q. Notable verbatim quotes

1. "When you're trading automated, you need to sort of indicatorize your analysis — your form of analysis." (v266, "Automate Order Flow", [03:37])

2. "For me, I prefer I'm a Hands-On guy, I read the order flow and I use a tool [Markers] to help me with the trade entry... once you get into the trade then you could be a Trader — because being a Trader is making those decisions." (v266, [40:28])

3. "Being able to trade a signal like this [Prominent POC] is something that I want to do — for me this is like an automated, almost an automatic trade if things, if the follow-through order flow works." (v276, "Price Scalper Workshop", [1:08:19])

4. "I don't like to think that way [stacking multiple indicators as additive]... a bar could exhibit three or four different things — just like using different indicators can appear three or four different things. I just like to think: yeah, what I'm seeing in the market makes perfect sense." (v276, [27:41])

5. "The signal bar is the invalidation reference — if we're starting trading below the signal bar, that's where I'd be looking to get out. I don't need it to sell off 20 ticks." (v276, [45:46])

6. "Thin prints is something I like to use in my trading... it's just as important to understand those areas where there's lack of volume coming in in the two-way auction." (v336, [06:15])

7. "Automation gets you in the trade, but then you can still trade, do your job as a Trader." (v266, [53:41])

8. "The problem with range-based charts... when a market's moving very fast... you're going to get these bars where you know you're trying to react... for me personally I just found using a time-based chart is something that's going to help me manage my trades better because I put more of a time component into it." (v276, [49:40], [51:33])

---

## R. Contradictions / nuances

- **Multiple order-flow indicators firing simultaneously ≠ stronger signal**: he explicitly dismisses the idea that three or four indicators hitting the same bar is additive confirmation — "I don't like to think that way." This is a direct nuance against a common discretionary belief that confluence of multiple tools always improves quality. (v276, [27:41]) [ONCE]
- **Tick replay NOT required for live trading**: despite its reputation as essential for order-flow accuracy, he states live tick stream is sufficient for his NT8 indicators. Only backtesting/historical requires tick replay. (v266, [36:31]) [REPEATED — reinforces existing digest note]
- **Price Scalper signal bar vs. trigger bar**: invalidation references the *signal bar* (pre-signal, deep blue/red), not the trigger bar (actual triangle). This is a subtle but important distinction for stop placement. (v276, [45:46]) [ONCE]
- **Range charts vs. time charts for volatility**: range-based charts *used* to be his preference (2013–2016) but he has abandoned them for modern volatile markets. Time-based charts preferred now specifically because they allow better trade *management* by incorporating a time component. Not a model rule but relevant to chart-construction. (v276, [49:40]) [ONCE]
- **Trend filter with Price Scalper**: when using a trend filter, he drops the swing-filter to the *lowest* setting (1) and lets the trend filter do the selectivity work. Without a trend filter, a higher swing filter is needed for selectivity. These two settings trade off against each other. (v276, [12:15]) [ONCE]
- **Automation preference (partial vs. full)**: he prefers *partial* automation — computer handles entries, human handles exits. This is a deliberate design choice, not a limitation. (v266, [39:56], [40:28])

---

## Coverage note

v266 and v276 are automation/product workshop sessions (T3) with moderate incidental model content: useful NinjaTrader implementation details, swing-filter thresholds for the Price Scalper by market class, a concrete ATM example, and the POC-as-"almost-automatic-trade" grading. v336 is a brief product announcement for GoCharting with almost no model content beyond a thin-print definition and a list of features ported to the web platform. No transcript parsing issues; all three are fully readable.
