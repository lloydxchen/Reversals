# Chunk 062 Extraction
- Source chunk: Chunk_062_Orderflows_Transcripts.md
- Transcripts covered:
  - v197 — How To Automate Order Flow With Markers (2021-01-10)
  - v198 — How To Use Order Flow To Follow The Money To Winning Trades (2021-01-15)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Swing-high / swing-low reversal** — flow scalper (and by extension, his reversal model) can be configured to generate signals only at swing highs or swing lows (as opposed to "anytime"), reinforcing location-first thinking. (v197, "How To Automate Order Flow With Markers", [14:55]) [REPEATED]
- **Imbalance-based short at swing high** — delta negative + selling imbalances building + POC migrating lower → short at swing high, tight stop just above the consolidation area. (v198, "How To Use Order Flow To Follow The Money To Winning Trades", [13:16]) [REPEATED]
- **Aggressive-buying-step-back-in / re-test long** — buyers appeared at a price level, market came back to that level, aggressive buyers re-appeared (buying imbalances + positive delta) → long entry. (v198, [24:06]) [REPEATED]
- **Stacked imbalance S/R fade** — draw stacked-imbalance levels forward; when price retraces back to those levels, enter against the extension (short at stacked selling-imbalance shelf, long at stacked buying-imbalance shelf). (v198, [30:05]) [REPEATED]
- **POC-migration trend trade** — POC migrating consistently lower (or higher) across multiple bars is a directional signal, not a fade signal. (v198, [15:13]) [REPEATED]

---

## B. Tiering / grading language — HIGH PRIORITY

- Mike says his own reversal model is about **quality not quantity**: "with trading it's not about quantity taking a lot of trades it's about quality taking good trades." (v198, [35:30]) [REPEATED]
- **Flow scalper "trade entry signal" filter as a quality gate**: enabling the two-tick / two-bar follow-through filter "keeps me out of about 45% of trades that I shouldn't be in." He frames this as cutting out trades that "don't have follow-up order flow." (v197, [20:04]) [ONCE] — the specific "45%" figure is new numerical grounding for the follow-through gate.
- **Trades per direction ("by side") setting**: he personally keeps it at zero (take all signals) but acknowledges setting it to "1" or "2" ensures you take only the first (or first two) signals in one direction before waiting for the opposite — explicitly framed as a guard against "selling selling selling" and ending up short at the bottom. (v197, [1:09:18]) [ONCE]
- No explicit A+/A/B/C grading applied in this chunk; all grading is implicit through context and filter settings.

---

## C. Order-flow story & psychology per setup

- **Aggressive buyers/sellers move markets; retail adds noise.** "The buyer that buys 300 contracts clears out the offer … that's what causes markets to move." Retail size is irrelevant to price; only big-size aggression matters. (v198, [06:23]) [REPEATED]
- **"Swim with the shark"** — big banks, hedge funds, commercials, real-money accounts (central banks, pension funds) are the dominant traders. When imbalances appear it is those players expressing dominance; the correct response is alignment not opposition. (v198, [16:16]) [REPEATED]
- **22 contracts at a swing low after a 2,000-contract-per-bar decline = seller exhaustion.** "Where are the sellers? They're not there." Tiny delta/volume at the swing low after heavy prior negative delta is the footprint of seller absence, not buyer aggression — the buying imbalances that follow then confirm buyer control. (v198, [27:29]) [ONCE — explicit "22 contracts" walkthrough]
- **Negative delta mid-rally is meaningful.** At [28:05], talking about bonds rally, he says: "you got negative delta … that's actually mean something I'm not going to get into it on this presentation … how markets rise on negative delta and how it's important." [ONCE / SPECULATIVE: suggests supply-absorption at intermediate levels is a distinct nuance he teaches elsewhere but does not elaborate here]
- **Markets retrace to prior aggressive-activity zones.** "knowing … if you can reference where the aggressive buying was earlier when you come back down to that area and you see that aggressive buying … low risk trade." Prior imbalance clusters act as magnets for re-test entries. (v198, [24:34]) [REPEATED]

---

## D. Exhaustion clues

- **Volume collapse at a swing extreme after heavy directional flow**: 22 contracts traded at a swing low following large negative deltas (thousands) — contrast in magnitude is the exhaustion signal. "22 against 2000 that's almost 200 percent." (v198, [27:29]) [ONCE — explicit numerical contrast described in a live example]
- **Tiny delta at extreme after large prior delta**: "minus 44 minus 31 minus 108" building at a swing high then market fails to extend — sellers in control, context for getting short. (v198, [13:16]) [REPEATED]
- **No imbalances on a push**: first push down shows selling imbalances; subsequent attempted push shows "no follow through … 22 contracts … trace" — absence of imbalances on a re-test of the extreme is exhaustion. (v198, [27:01]) [REPEATED]

---

## E. Absorption clues

- **Buying imbalances appearing as price retests a prior swing low** (where earlier aggressive selling occurred) = buyers absorbing the residual selling pressure. Specifically: five buying imbalances on first touch, then buying imbalances on second touch of same zone. (v198, [23:37]) [REPEATED]
- **POC staying elevated / migrating higher while price is sideways**: POC higher than previous bar, then higher still, while price consolidates → buying absorption in progress. (v198, [22:08]) [REPEATED]
- "Markets rise on negative delta" — alludes to passive-seller absorption (sellers offering into rising price), a known but here un-elaborated concept. (v198, [28:05]) [ONCE]

---

## F. Stacked imbalance ideas

- **Stacked imbalance minimum on 5-minute chart can be 2 levels** (not 3): "If you're looking at five-minute charts or above trying to get three is difficult honestly if a stacked imbalance of two levels holds over five minutes it's important." (v198, [32:31]) [ONCE — this is a timeframe-dependent threshold, refining the known "3+" default]
- **Draw stacked imbalance levels forward as S/R**: the line drawn from an earlier stacked selling-imbalance became resistance on a later rally to the tick. He explicitly shows this across 1-min, 5-min, and 30-min charts. (v198, [30:05]) [REPEATED]
- Stacked imbalance ratio can be adjusted to 2.5:1, 3:1, 4:1, or 10:1 by setting percent (250, 300, 400, 1000%). He demonstrates on a 5-minute crude oil chart. (v198, [32:31]) [REPEATED]
- **Stacked imbalance from overnight / early session holds relevance at cash open.** "In the middle of the night … got a couple … came right back 3804 04 sells off over the next two bars." (v198, [34:20]) [REPEATED]

---

## G. Delta / delta-divergence ideas

- **Three-component confluence for directional conviction**: delta (direction/magnitude) + POC migration (same direction) + imbalances (same direction) all pointing together = "it's not going to rally / it's going to sell off." He says "I hate to use the term confluence but when everything is bearish … what do you think is going to happen." (v198, [19:18]) [REPEATED]
- **Delta growing / strengthening while price is flat = pre-move signal**: bonds example — delta gradually increasing (39 → 53 → 57 → 164 → 284 → 317) while price goes sideways, then POC moves higher, then imbalances appear = long setup materializing bar-by-bar. (v198, [21:14]) [REPEATED]
- **POC migrating lower + consistently negative delta + selling imbalances** = trend continuation (do not fade). (v198, [15:13]) [REPEATED]
- **Delta at zero on a bar is not a signal**: "I haven't found any relation on when delta landed at zero … that was a precursor to some move or not." Explicitly dismisses zero-delta as meaningful. (v198, [10:42]) [ONCE — explicit dismissal not previously catalogued in detail]
- "Markets rise on negative delta" — unexplained here, referenced as a separate teaching topic. (v198, [28:05]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Range-break fake-out confirmed by imbalances**: bonds market "sort of break out of this range … trades one tick higher from the higher the range … then it falls back down." The imbalance picture (buying imbalances stacking at the range lows, not the breakout bar) was the tell that the breakout was false. (v198, [26:35]) [REPEATED]
- **Price hitting a stacked-imbalance shelf to the tick then reversing**: market rallied exactly to the stacked selling-imbalance level from an earlier session and reversed. He calls this "you could have gotten something out of this move." (v198, [30:34]) [REPEATED]

---

## I. Trapped-trader ideas

- **"They took the short at the breakdown, now the imbalances show buyers"** — implied: shorts who entered on the fake break lower are trapped as buying imbalances and positive delta appear. Mike does not use the word "trapped" explicitly in this chunk but the "what do we know" game at [27:01] implies it. [SPECULATIVE based on context]
- **Reversals after automation**: the "reversals" setting in markers (enable reversals = close current position and enter opposite when new signal fires) is operationally equivalent to acknowledging that staying with a stale position after a contra-signal is a trap. (v197, [1:33:43]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

- **Flow scalper "trade entry signal" (two-tick / two-bar rule)**: signal bar must close with signal; then the next bar (or second bar) must move at least 2 ticks in the signal direction. The signal is painted intrabar the moment the 2-tick move occurs — entry at that exact tick, not at bar close. (v197, [18:03]) [REPEATED — but the 2-tick/2-bar parameters explicitly spelled out]
- **Confirmed signal mode** (trade entry signal enabled): signal is painted intrabar, never repaints after close. Entry is taken at the tick the signal is confirmed (2 ticks into the direction). (v197, [23:57] / [25:22]) [REPEATED]
- **Unconfirmed mode** (trade entry signal disabled): signals paint and repaint intrabar; can use a buy-stop order placed above the bar to enter only if price continues in the direction, allowing an alternative entry method. (v197, [54:44]) [ONCE — buy-stop on unconfirmed signal as an entry method]
- **Buying imbalances + positive delta converging** at a re-test of a prior aggressive-buying zone → market entry on recognition. (v198, [24:34]) [REPEATED]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Follow-through order flow**: "if the order flow … has changed … you don't have to sit there and say oh okay well I got my four-point stop." Confirmation is intrabar order flow continuing in the trade direction. (v197, [10:13]) [REPEATED]
- **Trade entry signal gate itself is the primary confirmation proxy**: "it keeps me out of the trades that don't work out … about 45% of trades." Two-tick follow-through on the next 1–2 bars is the quantified confirmation gate. (v197, [20:04]) [ONCE — "45%" figure]
- **Buying imbalances re-appearing at the same zone on re-test** = confirmation that the zone is active. (v198, [24:06]) [REPEATED]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Contra-flow intrabar**: "bearish flow comes into the market at 3804 then back down … based on what I'm seeing in the order flow can tell me to get out of the trade … you don't have to wait for it to stop you out." (v197, [10:13]) [REPEATED]
- **Signal fires but next 1–2 bars do not move 2 ticks in direction**: trade entry signal not triggered = no entry, thesis dead for that bar. (v197, [18:34]) [REPEATED]
- **Imbalances fail to re-appear on a re-test of a zone** → zone has been consumed; don't enter. (v198, [24:34]) [SPECULATIVE — implied by the logic, not stated explicitly]

---

## M. Stop / risk / target / trade management

- **Automated entry, manual management**: "The way I use it is I manage the trade … I use it to get in … I don't just either let it go directly to my target or stop." Entry is automated; exit is discretionary. (v197, [1:34:26]) [REPEATED]
- **ATM take-profit / stop for automation**: for e-minis during the day he uses "16 by 16" (16-tick stop, 16-tick target) as a default ATM. Night session targets are smaller because "you don't get as many moves at night." (v197, [1:32:36]) [ONCE — "16 by 16" e-mini daytime ATM default]
- **Maximum daily P&L stop built into markers**: default daily limit of $500 (positive or negative); when hit, markers disables further trading for the day. (v197, [40:30]) [ONCE — daily stop operationalized as $500 in the automation layer]
- **Risk/reward example in live market**: 5-tick stop, 25-tick take-profit = 5:1 R:R cited on crude oil stacked-imbalance fade. (v198, [31:05]) [ONCE — 5-tick / 25-tick example]
- **Stacked-imbalance levels as take-profit targets**: implied — when you are short and market retraces to a lower stacked-buying-imbalance level that is your take-profit reference. (v198, [33:54]) [SPECULATIVE]
- **Time-frame-scaled targets**: "My take profits are going to be lesser [at night] … you don't get as many moves at night." Same indicator settings, different ATM strategies for day vs night session. (v197, [21:11]) [REPEATED]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Night session vs day session**: different ATM strategies; night targets are smaller; "tight markets" parameter on flow scalper handles the low-volatility overnight bars. (v197, [15:59] / [21:11]) [REPEATED]
- **Inventory numbers / news**: crude oil example at [30:34] — "I don't know if you'd want to take a trade when the number comes out … let you know have something in after the number." Confirms news avoidance filter. (v198, [30:34]) [REPEATED]
- **Market selection by volatility tolerance**: ES preferred over NQ for Mike personally — "NQ moves are just too fast for me … 20 points in 30 seconds." Flow scalper and markers work on NQ but ES is "path of least resistance." (v197, [1:20:34]) [REPEATED]
- **Physical-settlement vs cash-settlement markets require different "contango" settings** on flow scalper. Grain/oil markets are physically settled and have different price dynamics; the "contango" parameter adjusts signal generation accordingly. (v197, [15:24]) [ONCE — contango parameter as a market-type context filter]
- **Chart type / time frame flexibility**: flow scalper works on minute, range, tick, volume, Heikin-Ashi, Kagi charts. Signals are consistent in concept across chart types, but the specific calibration matters. (v197, [06:26]) [REPEATED]
- **"Follow the money / swim with the shark"**: stay aligned with institutional flow direction; don't fight banks, hedge funds, commercials, central banks, pension funds. (v198, [16:16]) [REPEATED]
- **5-minute stacked imbalance threshold = 2 levels** (vs 3+ on shorter time frames). (v198, [32:31]) [ONCE]

---

## O. Directly testable / measurable variables

- **Follow-through gate**: next 1–2 bars must move ≥2 ticks in signal direction after signal bar close. (v197, [18:03]) [measurable]
- **Trade validity window**: 2 bars. If 2 ticks of follow-through not achieved within 2 bars, signal is void. (v197, [18:34]) [measurable]
- **Follow-through filter eliminates ~45% of signals** (his stated figure for losing-trade reduction). (v197, [20:04]) [ONCE — stated percentage, not independently verified]
- **Stacked imbalance on 5-min chart = 2 levels** (not 3+). (v198, [32:31]) [measurable, timeframe-conditional]
- **Imbalance ratios available**: 2.5:1, 3:1, 4:1, 10:1 (adjustable; his default 4:1 known). (v198, [32:31]) [measurable]
- **Volume collapse at swing extreme**: swing-low volume (22 contracts) vs prior bars (2,000+ contracts) — ratio ≈ 1:100; qualitative signal is "sellers absent." NEEDS-OPERATIONALIZATION for a threshold ratio.
- **Delta growing while price flat**: consecutive bars with increasing absolute positive delta while price range is narrow. NEEDS-OPERATIONALIZATION for "growing" threshold.
- **POC migration direction**: bullish if POC higher bar-over-bar; bearish if lower bar-over-bar. (v198, [15:13]) [measurable — directional, not magnitude-based]
- **ATM default for e-mini day session**: 16-tick stop, 16-tick target. (v197, [1:32:36]) [measurable; stated as personal default]
- **Daily automation stop**: $500 net (profit or loss). (v197, [40:30]) [measurable; stated as marker's default]
- **Night session targets**: smaller than day; no exact figure given. NEEDS-OPERATIONALIZATION.
- **Trades per side**: 0 = unlimited; 1 = first signal only per side; 2 = first two only. He personally uses 0. (v197, [1:08:51]) [measurable]

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Markers Plus integration workflow** (Pablo Mago / indicator-store.com):
  1. Add flow scalper (or any indicator) to chart with tick replay enabled.
  2. Add Markers Copy indicators — one for longs, one for shorts — pointing at the indicator's respective plots (normal buy / normal sell), on each tick, with the same parameters.
  3. Add Markers Force (or Markers Plus main automation tool) with fast-signal mode, naming the variables "go long" / "go short" (global per instrument).
  4. Set working mode to Auto, enable longs/shorts, select ATM, select account.
  5. Optionally: enable reversals (auto-close and flip on contra-signal). (v197, [1:27:16] – [1:35:38])
- **Confirmed vs. unconfirmed signal modes in NinjaTrader indicator**:
  - Confirmed (trade entry signal ON): signal is computed intrabar at the tick the 2-tick follow-through occurs; never repaints after bar close.
  - Unconfirmed (trade entry signal OFF): signal can paint and repaint during the bar; use "copy previous bar" (offset = 1) or a buy-stop entry to handle repaint risk. (v197, [22:31] – [54:44])
- **"Global" signal variables**: when signals from one chart instrument need to drive orders on a different instrument (e.g., copy from NQ to MNQ), set the Markers Copy variable as Global. Markers Force on the second chart reads that global variable. (v197, [1:09:49] – [1:12:34])
- **Tick replay**: required for historical signal replay/visual backtesting; NOT required for live real-time trading. Disabling tick replay improves chart refresh speed in live trading. (v197, [05:57] / [29:24])
- **Filters in Markers**: any indicator output (slope of linear regression, moving average crossover, green/red bar close > open, etc.) can be used as a filter condition within Markers to gate signal execution. Example: enable longs only when linear regression slope histogram > 0. (v197, [55:21] – [59:27])
- **Playback trick (NT 8.22+)**: right-click playback → select "current day" → click "go to" without changing date/time → fast-plays the full day tick-by-tick painting signals without needing tick replay loaded. (v197, [46:57] – [48:17])
- **Flow scalper key settings**: swing filter (default 5 for e-mini; 0 = off), contango (for physically settled markets), tight markets (for low-volatility/overnight sessions), volume minimum filter (for thin markets), trade entry signal (2-tick/2-bar follow-through gate). (v197, [14:55] – [17:26])
- **Multi-instrument automation**: signals generated on one chart can trigger orders on a different chart (e.g., signal on standard futures, execute on micro futures) using global variable naming in Markers Copy. (v197, [1:09:49])
- **Stacked imbalance draw-forward as S/R levels**: implies an indicator feature that extends stacked-imbalance horizontal lines forward in time for use as reference levels. (v198, [30:05])

---

## Q. Notable verbatim quotes (with citations)

1. "Follow the money … you've got to look at what's trading in the market … don't over complicate trading." (v197, [08:34])

2. "If I get long … all of a sudden bearish flow comes into the market at 3804 then back down … based on what I'm seeing in the order flow can tell me to get out of the trade … why wait for it to stop you out if what you're seeing in the order flow has changed." (v197, [10:13])

3. "It keeps me out of about 45% of trades that I shouldn't be in … imagine you could cut out 40% of your losing trades what do you think that's going to do to your bottom line." (v197, [20:04])

4. "Where are the sellers? They're not there … 22 against 2000 that's almost 200 percent." (v198, [27:29])

5. "I hate to use the term confluence but when everything is bearish in the market what do you think is going to happen … it's going to sell off." (v198, [19:18])

6. "POC point of control is migrating higher that's bullish if it's migrating lower that's bearish … keep it simple." (v198, [15:48])

7. "Markets rise on negative delta … I'm not going to get into it on this presentation." (v198, [28:05])

8. "With trading it's not about quantity taking a lot of trades it's about quality taking good trades." (v198, [35:30])

9. "The way I use it is I manage the trade … I use it to get in … I don't just either let it go directly to my target or stop." (v197, [1:34:26])

10. "You can't beat them … join them … swim along with them right." (v198, [16:40])

---

## R. Contradictions / nuances (anything that conflicts with common belief, with his other statements, or that is conditional / "it depends")

1. **Stacked imbalance threshold is time-frame-dependent**: digest says 3+ for stacked/multiple; v198 explicitly states 2 levels is sufficient for 5-minute (and higher) charts. This is a conditional refinement — the 3+ default applies to shorter time frames; 2 is the practical minimum on 5-min+. (v198, [32:31]) [REFINING]

2. **Delta at zero is explicitly not meaningful**: "I haven't found any relation on when delta landed at zero … that was a precursor to some move or not." Contradicts any model element that treats zero-delta as a neutral or signal state. (v198, [10:42]) [ONCE]

3. **"Markets rise on negative delta" is a real and important phenomenon**: he explicitly teases it as a separate teaching topic, implying that positive delta is NOT always required for a bullish setup (absorption at intermediate levels as price rises). This is a nuance that could affect how the indicator grades bullish setups with intermediate negative delta bars. (v198, [28:05]) [ONCE — flagged as IMPORTANT but unexplained here]

4. **45% of signals filtered out by the 2-tick/2-bar follow-through gate**: if this figure is accurate, the raw signal rate from flow scalper is substantially higher than the net tradeable rate. This has implications for NinjaTrader indicator design — the follow-through gate is not cosmetic; it is responsible for a large portion of signal quality improvement. (v197, [20:04])

5. **Optimization / curve-fitting warning**: he cautions that optimizing settings leads to curve-fitting and systems that "worked perfect for everything up to right now … going forward then they wonder why everything failed." Markets keep changing. This is a direct caution against back-testing-driven parameter tuning — the indicator's default parameters should be conservative and market-adaptive, not optimized. (v197, [1:15:17]) [ONCE]

6. **Physical-delivery vs cash-settled markets have different signal characteristics**: physically settled markets (grains, oil) need the "contango" adjustment because their price dynamics differ from cash-settled equity/rate futures. This is a context filter that the NinjaTrader indicator should expose as a parameter. (v197, [15:24]) [ONCE — more explicit than previously catalogued]

7. **POC alignment matters directionally, not just as a point**: he says "don't think of point of control just as a level — think of the direction it's moving." POC as a migration direction indicator (bullish/bearish) is a more nuanced read than simply treating it as a static S/R level. (v198, [15:48]) [REPEATED but worth flagging as explicit]

---

## Coverage note

V197 is a product/automation webinar (flow scalper + Markers Plus) — rich for NinjaTrader implementation mechanics (confirmation modes, global variables, ATM defaults, filter construction) but thin on new reversal-setup logic. V198 is an introductory "follow the money" conference presentation — thin on new concepts versus the digest but provides clear numerical live-example walkthroughs (the "22 contracts" exhaustion example, the 5:1 risk/reward crude trade, the stacked-imbalance 2-level-on-5-min threshold). Neither transcript introduces new setup types. The 45% follow-through-gate efficiency figure and the "markets rise on negative delta" tease are the most actionable new items.
