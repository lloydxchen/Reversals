# Chunk 105 Extraction
- Source chunk: Chunk_105_Orderflows_Transcripts.md
- Transcripts covered:
  - v207 — Introducing Orderflows Flowshifts (2021-03-27)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Flow Shifts signal** (bullish/bearish): a bar-level pattern the Flowshifts indicator detects based on volume-at-price, bar direction, delta confirmation, market structure ("balance"), and whether longer-term traders are participating. Not a named reversal setup in the model-building sense — it is a detector output. (v207, [03:27]–[04:31])
- **Prominent POC as support/resistance**: a POC that has acted as S/R, used as an optional filter on Flowshifts. Described as a "level the market reacts to immediately or returns to for support/resistance." (v207, [21:20]–[21:45])
- **Balance-to-balance move**: the structural move the indicator is designed to catch — market moves from a "balanced area" to a new "balanced area," with the signal appearing at the transition out of balance. (v207, [1:14:53]–[1:15:27])
- **Groupings / clusters of signals**: when Flow Shifts and Flow Scalper signals appear within 1–2 bars of each other, Mike calls this a "grouping" and considers it higher quality than an isolated signal. (v207, [43:44]–[44:16]) [ONCE]

---

## B. Tiering / grading language — HIGH PRIORITY

- **Follow-through order flow present = trade you want; absent = skip.** The trade entry signal filter is the hard gate: "the trades you want right the trades that are going to have the higher chance of winning are the trades that have that follow-through order flow." (v207, [51:42]–[52:15]) [REPEATED]
- **"Good signals, reliable signals"** is the grading benchmark Mike uses for his tool in live markets. (v207, [33:47])
- **Signal with low bar volume = "probably not going to be very effective"** (not graded as A+/A; implicitly lower quality). At night on MES/MNQ he suggests minimum bar volume filters (100 for MES, ~50 for MNQ). (v207, [13:34]–[14:01]) [ONCE]
- **Market going sideways after entry = exit; not a good trade.** "After about five minutes of the market going sideways that's not a good trade to be in." (v207, [31:23]–[31:54]) [REPEATED — consistent with digest's "works immediately" gate]
- **"Groupings" (two different tool signals within 1–2 bars)** = implied higher quality than solo signal. Opposite groupings (one buy + one sell from different tools close together) = "you don't pay attention to them." (v207, [43:44]–[44:16]) [ONCE]
- **Signal without follow-through at cash open = be careful**: cash open creates 5× normal volume distorting calculations; signals there should be skipped or treated with caution. (v207, [47:17]–[47:47])
- No explicit A+/A/B/C grading of Flowshifts signals in this video; tiering is expressed via: trade-entry-signal filter ON/OFF, balance strength & points settings, and follow-through gate.

---

## C. Order-flow story & psychology per setup

- **Long-term vs. short-term trader distinction**: the key differentiator for Flowshifts. "Long-term traders when they step into the market they've got the big deep pockets — they're the ones that are going to help move the market in a direction, stop a move and start the other move." Short-term traders will exit quickly; long-term will hold inventory. The indicator tries to detect long-term participation. (v207, [06:27]–[07:30]) [ONCE — NEW FRAMING vs. digest]
- **Absorption/stopping by long-term traders**: when a big, sustained move has been running, the appearance of long-term-trader participation at the extreme is the bullish/bearish signal. "If that volume has some strength behind it that's able to arrest the move down or stop a move that's been going up." (v207, [08:01]–[08:30])
- **Follow-through order flow from other participants**: after entry, the trader can't do anything to push the market; the trade only works if other order flow arrives in the same direction. (v207, [18:49]–[19:14])
- **Aggressive buying on a down-move = exit warning if already short**: "I see all this aggressive buying coming in — that's my sign to get out." Mike uses live footprint reading to manage exits even when using signal-based entries. (v207, [1:10:59]–[1:11:32])

---

## D. Exhaustion clues

- No explicit exhaustion language in this chunk. The balance-strength/balance-point concept touches on order-flow exhaustion implicitly (market moving out of a balanced state), but no specific exhaustion thresholds are stated.
- Indirectly: low subsequent volume / market going sideways post-signal = trade has no fuel, implying exhaustion of the trigger move. (v207, [31:23]–[31:54]) NEEDS-OPERATIONALIZATION

---

## E. Absorption clues

- **Volume "with strength" that arrests a move** is the absorption analog in Flowshifts: "you want to see a certain type of volume, you want to see the big traders stepping into the market." The indicator reads this via volume-at-price and how volume distributed within the bar. (v207, [06:59]–[08:01]) NEEDS-OPERATIONALIZATION
- **Volume appearing at edges of bars** (near tops or bottoms of the bar range, not centered) is an important absorption/stopping signal: "when it starts appearing at edges of the bars — that's where you can find some value in looking at the volume." (v207, [04:31]–[05:01]) [ONCE — specific edge-of-bar observation]

---

## F. Stacked imbalance ideas

- — nothing in this chunk — (Flowshifts uses "balance strength" and "balance points" — a different framework from the stacked-imbalance concept in the model. Not explicitly linked here.)

---

## G. Delta / delta-divergence ideas

- **Bar delta confirmation (preferred default)**: if bar is up, delta must be positive; if bar is down, delta must be negative. Mike keeps this ON by default. "Bar delta confirmation — if the bar is an up bar it's got to have positive delta, if it's a down bar it's got to have negative delta." (v207, [14:01]–[14:31]) [REPEATED — consistent with digest]
- **Bar delta divergence (opposite filter)**: up bar with negative delta, or down bar with positive delta. Turning this on gives "a lot less signals" because it is asking for divergence; Mike does not prefer this mode for general use. (v207, [14:31]–[14:55]) [ONCE]
- **Disabling delta entirely**: if both confirmation and divergence are unchecked, delta is ignored; signal purely based on volume/balance. (v207, [14:55]–[15:08]) [ONCE]
- **Delta not relevant for ultra bonds / palm oil** (two exceptions where Mike turns off trade-entry-signal and apparently is more relaxed about delta filter because he wants every alert): "that market trades a little bit differently and I want to be alert to whenever the signal's here." (v207, [17:46]–[20:18]) [ONCE — market-specific nuance]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- — nothing in this chunk — (not discussed in this product-launch webinar)

---

## I. Trapped-trader ideas

- **Implicit**: "how many times have you bought something and the market immediately went the opposite way" — the trade-entry filter (follow-through within 2 bars) is designed to prevent the trader themselves from being trapped into a no-momentum trade. The framing is from the entering trader's perspective, not the squeeze victim. (v207, [19:48]–[20:18]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

- **Trade entry signal ON (default for most markets)**: after a signal bar prints a zone/condition, the actual entry arrow only plots when price moves at least **2 ticks in the direction of the signal within the next 2 bars**. Parameters: "trade price level and ticks = 2, trade validity in bars = 2." (v207, [17:46]–[18:19]) [REPEATED]
- **Trade entry signal OFF (ultra bonds, palm oil)**: arrow plots as soon as bar conditions are met intrabar; no follow-through confirmation required. (v207, [17:46]–[18:19]) [ONCE]
- **Intrabar vs. bar-close behavior**: with trade-entry-signal OFF, the arrow can appear and disappear intrabar as conditions change; once bar closes, the state is permanent. With trade-entry-signal ON, the arrow plots on the next bar and does not repaint after it is drawn. (v207, [1:16:39]–[1:17:50]) [REPEATED — important for NT implementation]
- **Mike personally always waits for bar close** even when signal appears mid-bar: "I've always waited for the bar to close because bars change." (v207, [1:18:56]–[1:19:26])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **2 ticks in 2 bars** is the built-in follow-through confirmation (trade entry signal parameter). (v207, [18:19]–[18:49])
- **Market should move "sooner rather than later"**: "I want it to start happening sooner rather than later — I don't want to sit here looking at my watch." (v207, [32:20]–[32:47]) [REPEATED — aligns with digest "works immediately"]
- **5-minute time stop / sideways = exit**: "after about five minutes of the market going sideways that's not a good trade to be in." Practical time stop is approximately 5 minutes. (v207, [31:23]–[31:54]) [ONCE — more specific than digest's ~10-min stop]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **No follow-through within 2 bars** = trade entry signal does not fire = signal is implicitly invalidated (no entry is taken). (v207, [18:19]–[20:18])
- **Market goes sideways for ~5 minutes after entry** = exit: conditions changed, the long-term participation thesis is no longer supported. (v207, [31:23]–[31:54])
- **Aggressive opposing order flow appears on footprint** after entry = exit signal. "I see all this aggressive buying coming in — that's my sign to get out." (v207, [1:10:59]–[1:11:32])
- **Signal on cash open**: "you always got to be careful around cash open because the amount of volume that comes in on the cash open distorts the calculations." Signals at/immediately after the cash open have lower validity. (v207, [47:17]–[47:47])

---

## M. Stop / risk / target / trade management

- **Stop placement**: "I use wider stops especially now in these market environments. The average rotation in the e-minis is about four to four-and-a-half points — if you're within that rotation you can get stopped out pretty easily." No specific tick-number given; contextual stop needed. (v207, [1:29:32]–[1:30:15]) NEEDS-OPERATIONALIZATION
- **Exit management via live footprint**: Mike exits discretionarily when aggressive opposing order flow appears — does not always wait for profit target or stop. (v207, [1:10:30]–[1:11:32])
- **Scalping targets mentioned by users**: "two ticks," "two points," "eight ticks" on ES mentioned as user scalp targets; "five ticks = $150" in ultra bonds; "30 points" on MNQ mentioned as a viable overnight move. (v207, [57:45]–[58:12], [33:47], [55:28]) — discretionary, not programmed.
- **Targets are discretionary**, not hard-coded into Flowshifts. No automated take-profit logic in the indicator itself. (v207, [general])

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Cash open avoidance** (5× normal volume distorts signal calculations): "let the market find its footing, give it a few minutes." Consistent with digest. (v207, [47:17]–[47:47])
- **Night session / low volume markets** = use "low volume markets" detection level; also applicable to grain markets (wheat, oilseeds) and overseas markets with thin volume. (v207, [10:37]–[11:14]) [ONCE — grain/overseas extension is new context for this filter]
- **Minimum bar volume filter** for night session: MES ≈ 100, MNQ ≈ 50 minimum bar volume to ensure signal reliability. (v207, [12:56]–[14:01]) [ONCE — specific numbers for night-session filter]
- **Volatile markets setting** only for genuinely volatile instruments: NQ/MNQ, possibly YM/FDAX, ultra bonds. On low-volatility markets it makes negligible difference. (v207, [11:14]–[11:54], [1:46:42]–[1:47:08])
- **Order flow is time-sensitive ("freshness")**: signals on 15-minute charts are stale because the trigger condition may have occurred in the first 3 minutes of the bar. "Order flow — you're trading the freshness of the information." Practical upper limit for Mike is 5-minute chart. (v207, [1:34:01]–[1:35:49]) [ONCE — explicit freshness principle]
- **London session**: "volume really picks up during the London session — it's not as good as when Europe and US cash markets are open but it trades good volume." London session viable for most futures markets. (v207, [1:37:28]) [ONCE]
- **15-second charts**: not viable for point-and-click trading due to latency; Mike's practical lower bound is 30 seconds. (v207, [1:37:28]–[1:39:14]) [ONCE]
- **Range-based charts (4-range, 7-range, etc.)**: Mike disfavors them on fast markets (NQ) because a single fast bar covers too many points, making entries impractical. Prefers time-based charts. Swing filter should generally be OFF on range charts. (v207, [1:07:25]–[1:12:28]) [ONCE]
- **Prior day open/high/low**: mentioned as reference levels Mike keeps on chart via NT's built-in "Current Day Open High Low Close" and "Prior Day Open High Low Close" indicators. Not a direct signal filter, but a structural reference. (v207, [1:31:50]–[1:32:22]) [ONCE]
- **Instruments specifically discussed**: ES/MES (e-minis), MNQ/NQ, YM, ultra bonds (ZB), crude oil (CL), FDAX, BUND, wheat, EUR/USD (6E), palm oil. (v207, [general])

---

## O. Directly testable / measurable variables

- **Balance strength**: integer 1–5; minimum 1 (zero not permitted). Higher = fewer but stronger signals. Default for ES = 3. (v207, [15:38]–[16:50])
- **Balance points**: integer 1–5; minimum 1. Higher = fewer signals. Default for ES = 2 ("three and two" is the stated default for ES 1-min). (v207, [16:11]–[17:17], [1:02:40])
- **Balance strength + balance points combinations tested in video**:
  - Ultra bonds: 3 and 1 (strength 3, points 1) on footprint
  - Crude oil: 1 and 1 (basic); compared to 3 and 1 (tighter)
  - YM: 1 and 2
  - MNQ (tighter): 3 and 1
  - MNQ (looser): 1 and 3
  - ES default: 3 and 2
  - ES tighter demo: 3 and 3
  - 7-range ES: 1 and 2
  - 1597-tick ES: 1 and 2
  (v207, [35:24], [44:52], [46:08]–[48:16], [1:02:40], [1:12:28]) [ONCE per market — useful calibration data]
- **Trade price level (ticks)**: 2 ticks (default). (v207, [17:46]–[18:19])
- **Trade validity (bars)**: 2 bars (default). (v207, [17:46]–[18:19])
- **Swing filter period**: integer ≥1; zero = disabled. For most markets Mike uses it OFF or at low values (1–2). For MNQ he uses values as high as 10–20 to find cleaner swing points. (v207, [12:25]–[12:56], [46:08])
- **Minimum bar volume**: default = no filter (0). Night session MES ≈ 100; night session MNQ ≈ 50. (v207, [12:56]–[14:01])
- **Detection levels (3 checkboxes)**: Low Volume Markets, Normal Markets, Volatile Markets — independent toggles; can run any combination. (v207, [10:37]–[11:14])
- **Prominent POC filter**: optional boolean; reduces signals significantly (on 1-min ES may leave 0–2 signals/session). (v207, [15:08]–[15:38])
- **Bar delta confirmation / divergence / disabled**: three-state toggle. Confirmation = default. (v207, [14:01]–[15:08])
- **Time freshness threshold (qualitative)**: order flow signals degrade above 5-minute chart; Mike's upper bound = 5 min. NEEDS-OPERATIONALIZATION (v207, [1:34:01]–[1:35:49])
- **Post-entry time stop**: ~5 minutes of sideways = exit. (v207, [31:23]–[31:54]) — more specific than digest's ~10 min; may be instrument/context-dependent. NEEDS-OPERATIONALIZATION

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Signal plots on bar close after trade-entry confirmation**: the zone/condition is identified intrabar but the entry arrow only finalizes on the bar that achieves 2-tick follow-through within 2 bars. Confirmed: "it's appearing on the bar afterwards because it's the bar afterwards that's got the confirming order flow." No repainting after arrow is drawn. (v207, [1:17:16]–[1:17:50])
- **Intrabar signals with trade-entry-signal OFF can repaint**: arrow/zone can disappear during the bar if conditions change; permanent only at bar close. (v207, [1:16:39]–[1:18:26])
- **Tick replay must be enabled** in NT8 for historical bars to display correctly; without it, signals only show on new live bars. (v207, [1:28:10]–[1:29:08])
- **Markers (third-party, "indicator store") integration**: reads the up/down triangle arrow (not the zone) to automate trade entries. Zone = condition alert only; triangle = confirmed entry arrow. This distinction matters for automated systems. (v207, [50:01]–[50:44])
- **NT8 free version**: runs Flowshifts; ATM strategies (auto stop/target on entry) require the paid version. (v207, [1:04:48]–[1:06:22])
- **ATM strategies in NT8 paid**: "as soon as you enter a trade you can have stop loss and take profit pre-programmed via ATM — OCO orders for trade entry." (v207, [1:06:22]–[1:06:55])
- **Multiple Flowshifts + Flowscalper on same chart**: no built-in logic for combining; Mike manually looks for "groupings" of signals from different tools near the same bar. No NT indicator combining logic described. (v207, [43:07]–[44:16])
- **NinjaTrader built-in "order flow suite"**: just a basic footprint + delta + POC; does NOT include exhaustion prints, imbalance reversals, delta divergence, market sweeps, order flow sequencing, or prominent POCs — those are exclusive to Orderflows Trader. (v207, [1:48:12]–[1:49:19])
- **Renko charts incompatible** with Flowshifts (and presumably other Orderflows tools) due to bar construction preventing reliable backtesting. (v207, [1:42:36]) [ONCE]
- **Flowshifts, Flowscalper, Pulse — three distinct tools reading different parts of order flow**; not redundant. Runs on footprint or regular bar chart. (v207, [20:50]–[26:32])

---

## Q. Notable verbatim quotes

1. "Long-term traders when they step into the market — they've got the big deep pockets, they're the ones that are going to help move the market in a direction, stop a move that's been going on and help start the other move." (v207, [06:27])

2. "You want to see a certain type of volume — you want to see the big traders stepping into the market — because the people with the deep pockets, they're not the ones that are going to be getting out quickly." (v207, [06:59])

3. "The trades you want — the trades that are going to have the higher chance of winning — are the trades that have that follow-through order flow." (v207, [51:42])

4. "You need basically you need follow-through order flow from when you get into a trade — once you get into a trade there's nothing else you can do as a trader to make the market go in that direction." (v207, [18:49])

5. "After about five minutes of the market going sideways that's not a good trade to be in — I know some people say well the market can turn around and go up — well it can just as easily turn around and go down." (v207, [31:23])

6. "Order flow — you're basically trading the freshness of the information — when you're looking at a 15-minute chart you're taking a step back — as far as I personally go is five minutes." (v207, [1:34:01])

7. "When it starts appearing at edges of the bars — near the bottom or near the top — that's where as a trader you can find some value in looking at the volume." (v207, [04:31])

8. "I see all this aggressive buying coming in — that's my sign to get out — I'm not going to wait till it takes me out at break even or worse." (v207, [1:11:32])

9. "I've always waited for the bar to close because bars change — even if I know a signal is forming I still wait for the bar to close." (v207, [1:18:56])

---

## R. Contradictions / nuances

- **5-minute practical time stop vs. digest's ~10-minute time stop**: Mike states "after about five minutes of the market going sideways that's not a good trade to be in" (v207, [31:23]). The digest says "~10-min time stop." The ~5-min figure here is instrument-context specific (ultra bonds, around cash open discussion), but is a potentially tighter operationalization. NEEDS-OPERATIONALIZATION to determine if 5 vs. 10 is market-specific.

- **"Same settings every market" vs. per-market calibration**: the digest says "same settings every market applies to detector only." This chunk reinforces the nuance: balance strength/points, swing filter, minimum bar volume, and detection level checkboxes all differ substantially per market. E.g., ultra bonds = 3 & 1 footprint; crude = 1 & 1; ES = 3 & 2. Not contradictory to digest but provides concrete calibration data. (v207, [09:32]–[10:03])

- **Bar-close discipline vs. intrabar signal display**: Flowshifts CAN show a signal intrabar (trade-entry-signal OFF mode), but Mike personally always waits for bar close. The indicator's default (trade-entry-signal ON) enforces bar-close timing automatically by requiring next-bar follow-through. Both paths converge on no-repaint-after-close, consistent with digest. (v207, [1:16:39]–[1:19:26])

- **Ultra bonds and palm oil exceptions to follow-through rule**: on these two markets only, Mike turns off the trade-entry-signal (2-tick/2-bar confirmation) and trades raw signals. This is a market-specific exception not previously detailed in the digest. (v207, [17:46]–[20:18]) [ONCE]

- **Renko incompatible with backtesting**: Mike explicitly states "you can't really backtest renko charts" — implied consequence for any research workflow using Renko bars. (v207, [1:42:36])

- **Order flow loses "freshness" above 5-minute chart**: the concept of freshness degradation with timeframe is explicit here. Mike goes as high as 5 minutes; anyone using the model on 15-min or higher timeframes is working against this principle. (v207, [1:34:01]–[1:35:49])

---

## Coverage note

v207 is a product-launch webinar for the "Flowshifts" indicator (March 2021). It is rich for NinjaTrader implementation details, per-market parameter calibration, and the long-term vs. short-term trader framing, but thin on pure reversal model content (no footprint walkthrough, no exhaustion/imbalance deep dives). The video is T3 (product launch) but contains useful operationalization data for the follow-through confirmation gate and time-freshness filter. About one-third of the content is sales/Q&A filler with no model value.
