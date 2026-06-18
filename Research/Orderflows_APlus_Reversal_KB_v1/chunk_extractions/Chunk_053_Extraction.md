# Chunk 053 Extraction
- Source chunk: Chunk_053_Orderflows_Transcripts.md
- Transcripts covered:
  - v178 — Trade Consistently With Order Flow NinjaTrader 8 Day Trading Futures (2020-04-16)
  - v179 — Delta Surge Free Indicator for NinjaTrader 8 Order Flow Analysis NT8 (2020-04-26)
  - v180 — Orderflows Delta Surge Free Indicator For Order Flow Analysis NinjaTrader 8 NT8 (2020-04-26)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta Surge (buy)** — signal fires when positive delta is expanding across multiple consecutive bars (aggressive buying accelerating); bullish bias. (v179, [05:44]; v180, [05:44])
- **Delta Surge (sell)** — signal fires when negative delta is expanding across multiple consecutive bars (aggressive selling accelerating); bearish bias. (v179, [04:01]; v180, [06:23])
- **Stacked buying imbalance off low** — multiple buying imbalances stacking in bars after the market hits a low; bullish reversal context. (v178, [1:17:20])
- **Trapped traders** (bullish / bearish arrow) — software-detected; trapped longs at highs get a red down-arrow, trapped shorts at lows get a green up-arrow. (v178, [43:12]; v178, [44:09])
- **Prominent point of control (bullish/bearish)** — market-generated S/R level highlighted by software; bearish (magenta) acts as resistance, bullish (cyan) acts as support. (v178, [49:28]; v178, [1:18:43])
- **Market sweep** — large trader sweeps through several bid/ask levels to fill a large order; footprint shows near-zero counter-trade vs. large imbalance side. (v178, [45:04]; v178, [46:53])
- **Cumulative delta divergence at lows** — at a retest of a swing low, cumulative delta is not only positive but growing stronger; signals low should hold. (v178, [1:04:17])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **"Nice little" / "nice"** — used for small, clean Delta Surge signals that work out on micro or short-timeframe charts; lower tier, acceptable. (v179, [07:32]; v180, [08:22])
- **"Beautiful ones"** — used for Delta Surge signals that occur at clear swing highs or swing lows with large subsequent moves; highest tier for this tool. (v180, [12:34])
- **"Not gonna be very effective"** — explicitly stated for Delta Surge signals that fire mid-trend, away from a swing extreme (e.g., sell signal after market already sold off most of its range). (v180, [17:52])
- **"More effective signals"** — signals occurring at "clear swing highs or swing lows" vs. signals in the middle of congestion. (v180, [13:48])
- **Preferred context for buys: "near swing lows / low of day"** vs. "buys near the high of the day" (v180, [19:14]; v180, [10:30])
- **Preferred context for sells: "near swing highs / high of day"** vs. "sells near the low of the day" (v180, [19:14])
- **"Tricky"** — signals in mid-range or after a major fast move; lower confidence. (v179, [09:49])
- **"Didn't really do much" / "sort of went sideways"** — failed or flat Delta Surge signals; implicitly lowest tier. (v180, [13:48])

---

## C. Order-flow story & psychology per setup

- **Delta Surge logic (general):** Aggressive buyers (or sellers) are "waking up and getting stronger," stepping in consecutively across bars. The market is being dominated with no meaningful opposition. (v179, [00:56]; v180, [05:44])
- **Delta at highs — trapped buyers story:** At the HOD, max delta is weak (small positive numbers like 102, 35, 218) while min delta surges negative (e.g., –452, –421). Aggressive buyers are being engulfed by aggressive sellers; there is no fuel for further upside; market inclined to sell off. (v178, [25:39]–[28:03])
- **Delta at lows — absorption/support story:** Cumulative delta is positive and growing even as price retests the low; aggressive buyers keep stepping in each time the market dips; sellers cannot push price lower. (v178, [1:04:17]–[1:06:03])
- **Sweep story:** Large institutional/prop trader wants to fill a large order quickly; sweeps through multiple levels with near-zero counter-trade; after fill, market often reverses back to the swept level (POC acts as magnet). (v178, [45:04]–[48:54])
- **Trapped traders story:** Traders caught long at the high or short at the low; their forced exit propels price in the opposite direction, but "often it's just a handful of traders" — the initial reversal may be small. [ONCE] (v178, [42:39])

---

## D. Exhaustion clues

- **Weak max delta at HOD:** Bars making new highs but max delta is small (e.g., 102, 35, 25, zero); aggressive buying is not present to sustain the move. (v178, [26:09])
- **Negative final delta at new high:** Bar closes with negative or near-zero delta at or near price extreme — the bar made a new high but sellers dominated by close. (v178, [27:23])
- **Min delta closing near its extreme at highs:** Final delta = near min delta (e.g., –421 final vs. –421 min delta) = aggressive sellers fully in control at highs. (v178, [27:23])
- **Delta gives back during bar:** Bar reaches a large positive intrabar delta (e.g., +292) then closes near zero (e.g., +12); the buying was absorbed and reversed intrabar. [ONCE] (v178, [1:02:32]–[1:03:07])

---

## E. Absorption clues

- **Cumulative delta positive/growing at price lows:** Despite price being at or near the low of day, cumulative delta is positive and increasing with each retest — buyers are absorbing the selling. (v178, [1:04:17]–[1:05:30])
- **Stacked buying imbalances at the low:** Multiple buying imbalances appearing in consecutive bars at the low; passive sellers absorbed by aggressive buyers. (v178, [1:17:20])
- **Sweep with no counter-trade:** Footprint shows near-zero numbers on the counter side (e.g., 0 vs. 40, 0 vs. 68) — passive liquidity absorbed instantly; no meaningful resistance. (v178, [46:53])

---

## F. Stacked imbalance ideas

- Stacked buying imbalances confirmed at the low and the market then rallies; software shows them in footprint bars as multiple consecutive blue (buying) imbalance cells. (v178, [1:17:20])
- Delta Surge (buying) often accompanies stacked buying imbalances; the two signals reinforce each other. [SPECULATIVE] (v178, [1:17:48])
- 4:1 ratio as the imbalance threshold reiterated; 3:1 or 10:1 also used by others. (v178, [35:33]) [REPEATED]

---

## G. Delta / delta-divergence ideas

- **Four delta data points:** (1) Delta (final/close), (2) Max delta (strongest aggressive buying in bar), (3) Min delta (strongest aggressive selling in bar), (4) Cumulative delta (session running total). All four are used together for context. (v178, [21:11]–[22:11]) [REPEATED]
- **Max delta vs. final delta relationship (strength signal):** When final delta ≈ max delta and min delta ≈ 0, aggressive buyers fully in control with no resistance (e.g., 360 final vs. 366 max, min = 0). (v178, [23:52]–[25:07])
- **Delta surge operationalized:** Indicator default settings = 25% increase in delta over consecutive bars (bar minimum delta difference = 25, default in percentage mode). User can lower to 1% for more signals or raise for fewer. (v179, [10:34]–[11:39])
- **Delta Surge settings (v180 confirmed):** Default = 10 and 10 (10% increase over 3 bars). Two separate parameters: bar minimum and bar C minimum delta difference. (v180, [06:55]–[07:26]) [ONCE — slightly conflicts with v179 which showed 25/25 as default]
- **Cumulative delta divergence (retest):** Price retests the low; cumulative delta is stronger than on the original low = bullish divergence; signals low should hold. (v178, [1:04:17]) [REPEATED concept but with specific numeric example: 3,964 → 7,000 → 7,400 at successive retests of the same low]
- **Delta surge in commodity markets:** Delta surges work in wheat, corn, crude oil, etc., but commodities driven by physical supply/demand may have different dynamics than equity index futures. (v179, [01:30]–[05:15]) [ONCE]
- **Negative delta over multiple bars = sellers in control:** e.g., -12, -75, -164 across successive bars indicates accelerating aggressive selling. (v179, [02:57]–[03:35])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Market sweep (institutional):** Not framed as a "stop run" — framed as institutional order execution technique; after sweeping through levels to fill, market typically returns to the swept level (POC). Distinct from trapped-trader stop-run framing he explicitly rejects. (v178, [45:04]–[48:54])
- He explicitly states "people will say, well, there was a stop run over here" — but he frames it instead as trapped traders + order flow evidence, not as a stop-hunt narrative. (v178, [44:38]) [REPEATED nuance]

---

## I. Trapped-trader ideas

- Software flags trapped traders with colored arrows: green up-arrow = trapped shorts at lows, red down-arrow = trapped longs at highs. (v178, [43:12])
- "Often it's just a handful of traders" — size of trapped quantity is small; the initial reversal force from their exit may be limited. (v178, [42:39]) [REPEATED]
- Trapped traders detected in context of stacked imbalances and POC levels: e.g., market sweeps up into trapped longs area, then returns to POC, then springs up again. (v178, [43:38])

---

## J. Entry triggers (the exact "go" event)

- **Delta Surge signal bar:** The indicator fires when delta increases by the threshold % (default 25/25 in v179 or 10/10 in v180) across consecutive bars — this is the entry signal. (v179, [10:34]; v180, [06:55])
- **Delta Surge context filter for entry quality:** Prefer signals near swing highs (sells) or swing lows (buys); avoid signals mid-range or after the move has already occurred. (v180, [13:48]; v180, [19:14])
- **Stacked buying imbalances + positive delta reappearing** as entry trigger off a low (in combination): v178, [1:17:20]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- After a Delta Surge buy signal at a swing low, market should continue up without returning to the signal area. (v180, [10:30])
- After a sweep (buy), market should hold the swept-level POC on any pullback and resume in the sweep direction. (v178, [47:27])
- After cumulative delta divergence at low, market should move back up and make higher prices without retesting the divergence low. (v178, [1:05:30])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Delta Surge buy signal invalidated if: market was already deep into a move (new highs) when signal fires; or if a sell signal comes quickly after (opposite surge). (v180, [10:30]; v180, [17:52])
- Cumulative delta divergence bull thesis killed if cumulative delta turns negative / fails to grow on retests. [SPECULATIVE — implied, not stated explicitly]
- Delta at high thesis (bearish): invalidated if max delta begins to surge (aggressive buyers return in force) on a retest of the high. (v178, [26:09]) [SPECULATIVE]

---

## M. Stop / risk / target / trade management

- "Take your small losses" so you can stay in the game for the big moves — loss management philosophy, not a specific stop level. (v180, [17:22]; v180, [18:46])
- Delta Surge is not described with a specific stop level in these videos; trade management is discretionary. NEEDS-OPERATIONALIZATION.
- For buys: target is left discretionary; implied exit = when opposite Delta Surge fires or at a swing high. (v180, [18:19]) [SPECULATIVE]
- Sweep trades: POC of the swept bar acts as near-term support/target re-entry; trade continues in direction of sweep. (v178, [47:27]) [implied]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Prefer buys near swing lows / LOD, prefer sells near swing highs / HOD** — do not take Delta Surge buys at/near HOD or Delta Surge sells at/near LOD. (v180, [19:14]) [ONCE — specific to Delta Surge, refines general guidance]
- **High VIX context:** VIX ~39 noted as "still some volatility" during April 2020; on 30-second chart instead of 1-minute in high-vol environments. (v180, [08:53]) [ONCE]
- **Commodity markets vs. equity index futures:** Delta surges work in both but commodity supply/demand dynamics differ; he is "not afraid to sell new highs or new lows in commodities" but "a little bit hesitant to buy new highs or sell new lows in equities." (v179, [05:15]–[08:39]) [ONCE — new nuance on cross-market filter]
- **Thinly traded equities:** Order flow analysis requires volume; thinly traded stocks/equities will not provide enough information. (v178, [1:25:35])
- **FX spot vs. FX futures:** Spot forex data is not centralized, may not include all volume; prefer CME FX futures (e.g., 6E) for order flow analysis. (v178, [1:21:53]) [REPEATED]
- **Chart type:** 1-minute, 30-second, 5-minute, range, volume, tick charts all work with same settings on Delta Surge indicator — time frame choice is personal preference. (v180, [10:58]–[11:57])
- **Signals in congestion zones are less effective** — prefer signals that break out of congestion, not signals fired while market chops sideways. (v180, [13:48])

---

## O. Directly testable / measurable variables

- **Delta Surge threshold (v179):** Default bar minimum delta difference = 25 (in percentage mode, 25%). Two parameters: bar minimum and bar C minimum. [ONCE — v179 shows 25/25] (v179, [10:34])
- **Delta Surge threshold (v180):** Default = 10 and 10 (10% increase over 3 bars). [ONCE — slight discrepancy with v179; may reflect different version or different parameter] (v180, [06:55])
- **Consecutive bars for surge:** The indicator looks at increases "over several bars" — minimum 3 bars implied. NEEDS-OPERATIONALIZATION for exact bar count. (v180, [05:44])
- **Cumulative delta at low (numeric example):** 3,964 at first low → 7,000 at retest → 7,400 before breakout (S&P E-mini 1-minute, 2020-04-16). [ONCE] (v178, [1:04:17])
- **Max delta vs. final delta (numeric examples):** Strong bar: final 360 vs. max 366 (gap of 6); another: final 695 vs. max 698 (gap of 3); weak reversal bar: final –74 vs. max +218 at new high = bearish. (v178, [23:52]–[27:23])
- **Min delta closing near extreme (numeric):** Final –421 vs. min –421 = sellers fully in control. (v178, [27:23])
- **4:1 imbalance ratio** reiterated as baseline. (v178, [35:33]) [REPEATED]
- **Delta Surge fires on NinjaTrader 8 with tick replay enabled** — requirement for accurate signal generation. (v179, [12:15])
- **"Prefer sells near swing highs / buys near swing lows"** — qualitative location filter for Delta Surge signals. NEEDS-OPERATIONALIZATION (define what constitutes a swing high/low). (v180, [19:14])
- **VIX ~39 → consider shorter timeframe (30-second) vs. 1-minute.** [ONCE] (v180, [08:53])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Delta Surge indicator (free, NinjaTrader 8 only):** Measures consecutive increases in delta (positive or negative); fires buy/sell arrow signal. Two threshold parameters (bar minimum delta difference and bar C minimum delta difference), settable in percentage mode. Version 3.0.0.02 as of April 2020. (v179, [10:34]; v180, [00:00])
- **Tick replay must be enabled** for Delta Surge to work accurately on NinjaTrader 8. (v179, [12:15])
- **Trapped traders indicator:** Plots green up-arrows (trapped shorts at lows) and red down-arrows (trapped longs at highs) automatically on footprint chart. (v178, [43:12])
- **Prominent POC indicator:** Colors bullish prominent POC cyan, bearish prominent POC magenta on footprint. (v178, [49:28]–[50:28])
- **Market sweep indicator:** Visualizes sweep events on footprint. (v178, [1:12:01])
- **Ratios and divergence indicator:** Part of Orderflows Trader 7-indicator suite. (v178, [1:12:01])
- **Delta Surge works on normal bar charts too** (not only footprint) — can be imported as a standard NinjaTrader indicator. (v180, [01:18]–[01:47])
- **Free version of NinjaTrader 8** supports all Orderflows indicators; only need a data feed. (v178, [1:12:01]; v179, [12:15])
- **Delta Surge does NOT run on ThinkOrSwim (TOS), TradeStation, or Sierra Charts** — NinjaTrader 8 only. (v179, [00:00]; v180, [00:50])
- **Export/research data:** No mention in this chunk.

---

## Q. Notable verbatim quotes

1. "Aggressive buyers are causing market imbalances, so I buy." (v178, [41:42]) — clearest distillation of the aggressor-entry logic.

2. "Often it's just a handful of traders [trapped], but that initial reversal is sometimes enough to cause a move." (v178, [42:39]) — important sizing nuance; trapped-trader effect is small.

3. "Wouldn't you like to know where a point is in the previous [bar] where the market can trade back to and then continue on in its original direction? Well, often times it's the point of control." (v178, [33:01]) — POC-as-S/R logic.

4. "If you see net aggressive buying, i.e., cumulative delta positive at the lows of the day, then the market bounces and retests the lows, and cumulative delta is not only still positive, but stronger, do you think the low is going to hold?" (v178, [1:04:17]) — cumulative delta divergence rule, stated as rhetorical certainty.

5. "The Delta surge is not a tool that's supposed to pick every single market turning point based on the order flow. It's looking for expansion either to the strong side or to the weak side." (v179, [06:58]) — scope limitation of the Delta Surge.

6. "The more effective signals are going to be the ones that occur at clear swing highs or swing lows." (v180, [13:48]) — explicit tiering rule for Delta Surge.

7. "I prefer to take buys somewhere at around the near the low of the day rather than at or on the high of the day." (v180, [19:14]) — directional filter for Delta Surge context.

8. "I'm not afraid to sell new highs or new lows in commodities because I know that underlying what's that force underlying is really supply and demand. I'm a little bit hesitant to buy new highs or sell new lows in equities just because it sort of the market makeup is a bit different." (v179, [08:39]) — cross-market distinction for directional bias.

9. "You have to take it in context with what's happening in the market, right? If just cuz you got a buy signal, right? The market just rallied 20 points and you get a buy signal, do you want to buy it again? Probably not, right? You've already had the move." (v178, [1:25:06]) — context filter over mechanical signal-following.

---

## R. Contradictions / nuances

- **Delta Surge default settings discrepancy:** v179 shows default = 25 and 25 (percentage mode); v180 shows default = 10 and 10. Both videos are from the same week (April 2020) and same indicator version bump. This may reflect Mike showing different settings for different markets/timeframes (v180 explicitly uses 10/10 for all charts shown), or an error in one presentation. (v179, [10:34]; v180, [06:55]) — NEEDS RECONCILIATION.

- **Delta Surge "not a reversal picker" vs. used for reversals:** He explicitly says the Delta Surge is "not a tool that's supposed to pick every single market turning point" (v179, [06:58]), yet the primary use shown throughout both videos is identifying reversals at swing highs/lows. The tool is technically a momentum/expansion detector, but the recommended context (at swing extremes) makes it a de facto reversal filter.

- **Commodity directional bias vs. equity directional bias:** In commodities, he will fade new highs and new lows with Delta Surge; in equity futures, he prefers buys near lows and sells near highs only — not fading new highs aggressively (v179, [08:39]). This is a cross-market conditional that contradicts any universal application of the Delta Surge as a trend-following tool.

- **Trapped traders quantity is "small":** He re-emphasizes that trapped traders are often just "a handful" — consistent with the digest nuance that trapped-trader fuel is small (v178, [42:39]). Not a contradiction, but reinforces the anti-"big squeeze" framing.

- **VWAP dismissed as "bastardized moving average":** He is skeptical of VWAP as commonly used — notes traders use it as a trend line substitute without understanding volume context (v178, [40:15]). This is mildly contradictory to common market-profile use of VWAP as a reference level, though he does not say it is completely worthless.

---

## Coverage note

- v178 is the richest video in the chunk: a full 80-minute webinar covering all foundational order flow concepts with live chart examples; most of the A+ reversal model logic is illustrated but presented at an introductory level with repetition of already-known concepts.
- v179 and v180 are both Delta Surge product/tutorial videos from the same date; they are largely repetitive of each other and cover the indicator mechanics rather than deep model logic. The key new contribution is the explicit operationalization of the Delta Surge threshold parameters and the cross-market directional preference rule.
- No novel setups beyond the digest were introduced. The primary delta value is the Delta Surge parameter details and the commodity vs. equity directional filter nuance.
