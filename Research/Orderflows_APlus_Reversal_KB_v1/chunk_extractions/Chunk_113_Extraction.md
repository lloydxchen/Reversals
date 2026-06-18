# Chunk 113 Extraction
- Source chunk: Chunk_113_Orderflows_Transcripts.md
- Transcripts covered:
  - v460 — Introducing Orderflows Catalyst (2025-04-15)
  - v463 — Orderflows Delta Scalper Huge Announcement and Upgrade (2025-07-23)
  - v464 — Introducing The Vol Shift Indicator (2025-08-17)
- Overall content value: thin

---

## A. Setup types & names he uses

- No new reversal setup types are introduced. All three videos are product-launch/sales webinars demonstrating new indicator tools (Catalyst, Delta Scalper upgrade, Vol Shift). [ONCE]
- **Catalyst "zone that doesn't come back" trade** (v460, [34:24]): The strongest bullish/bearish signals are those where price immediately moves away from the signal zone and never returns to re-test it. Described as the highest-quality signal expression for the Catalyst indicator. [ONCE]
- **Vol Shift breakout / expansion trade** (v464, [03:10]): a setup that fires when volatility transitions from consolidation/balance to expansion, intended to catch the early part of a directional move out of a balanced zone. Bullish or bearish depending on direction. [ONCE]

---

## B. Tiering / grading language  ← HIGH PRIORITY

- "Strongest signals" = zones that price never returns to test after the signal fires (v460, [34:24]): "the ones the strongest moves are going to come when you have a zone being drawn out where it doesn't even come back and test it at all." [ONCE]
- "Not a good strong signal" used for a Catalyst signal where price reversed back through the zone (v460, [15:25]). [ONCE]
- "Good trades" vs "a couple bad trades" / "iffy" trades: momentum strength setting removes roughly one or two losing trades per day; those filtered-out trades described as lacking "momentum behind it" (v463, [09:01]–[09:30]). [ONCE]
- "High conviction setups" = signals with both distribution discrepancy AND momentum aligned (v463, [01:59]). [ONCE]
- "False starts" = signals that look like they will move but then fail; filtered by raising Catalyst strength (v460, [44:35]). [ONCE]
- "Borderline" signals = all conditions met but no PC movement; PC movement filter eliminates these (v463, [05:04]). [ONCE]
- "Beautiful trend" / "nice move" used descriptively but without grading criteria beyond momentum alignment (v460, v463, v464 passim). [REPEATED]
- No new A+/A/B/C grading rubric beyond what is already known.

---

## C. Order-flow story & psychology per setup

- **Distribution discrepancy (Catalyst concept)**: the key is not just that aggressive traders are present (imbalance), but *how the volume is distributed between aggressive (liquidity-removing) and passive (liquidity-supplying) traders* throughout the entire bar. A lone large order can create an imbalance that means nothing if the surrounding distribution is normal (v460, [03:29]–[09:55]). [ONCE]
- **PC movement as conviction proxy**: when the bar's point of control moves in the direction of the signal (rising POC on a bullish bar, falling POC on a bearish bar), it indicates genuine institutional acceptance of price at new levels. Absence of POC movement in the direction of delta signal = possible large order artifact with no commitment (v463, [03:32]–[05:32]). [ONCE]
- **Sideways/balance ≠ good trading environment**: big orders frequently arrive in the middle of sideways activity simply to facilitate transfer of risk; these orders spike delta without any directional intent. The PC movement filter explicitly catches this (v463, [05:04]–[05:32]). [ONCE]
- **Volatility expansion = institutional + retail convergence**: when both institutional and retail flow align in direction, you get the large directional moves worth trading; the Vol Shift indicator is designed to detect this convergence (v464, [04:18]–[04:52]). [ONCE]

---

## D. Exhaustion clues

- Nothing specific to exhaustion in this chunk beyond generic references to "the market doesn't follow through." No new exhaustion criteria. [ONCE]
- Trade entry signal (present on Catalyst, Delta Scalper, Vol Shift): requires at least 2 ticks (default) of follow-through within 3 bars (default) of the signal bar; absence = no confirmation, trade skipped. This functions as an anti-exhaustion filter (v460, [23:00]–[23:31]; v463, [10:23]–[11:21]). [REPEATED across tools]

---

## E. Absorption clues

- Nothing directly about absorption in this chunk. [NOTHING IN THIS CHUNK]

---

## F. Stacked imbalance ideas

- Nothing directly about stacked imbalances in this chunk. [NOTHING IN THIS CHUNK]

---

## G. Delta / delta-divergence ideas

- **PC movement vs. delta divergence**: when price moves one direction but the bar's POC moves the opposite way, Mike flags this as a potential reversal signal (v463, [04:02]): "when price moves one way but PC moves the opposite, you're going to suspect a possible reversal taking place." This is a variant of delta divergence but expressed via POC direction, not delta sign. NEEDS-OPERATIONALIZATION [ONCE]
- **Delta surge ≠ directional signal without distribution context**: a big order can cause a large delta jump in a sideways market without any directional implication. The Catalyst/Delta Scalper tools explicitly filter for distribution discrepancy around the delta signal (v460, [09:55]; v463, [05:04]). [ONCE]
- Delta Scalper upgrade: added PC movement filter and momentum filter to raw delta signals. Momentum set to "average" (mid-range of weak/average/strong scale) as default (v463, [08:09]–[08:33]). [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Vol Shift "false breakout" filter**: trade entry signal on Vol Shift filters out bars where Vol Shift fires but no follow-through occurs (v464, [21:00]–[22:09]): "those are those false breakouts that a lot of traders fall into, right? That's where using the trade entry signal is going to help you." [ONCE]
- **Zone re-tests as reference levels**: when Catalyst or Vol Shift zones persist "until tested," they act as prior volatility/distribution reference levels; if price returns to such a level and a new signal fires, that is noted as potentially tradeable but Mike is non-committal about it (v464, [32:24]–[33:25]). [ONCE]

---

## I. Trapped-trader ideas

- Nothing directly about trapped traders in this chunk. [NOTHING IN THIS CHUNK]

---

## J. Entry triggers (the exact "go" event)

- **Catalyst trade entry signal trigger**: signal bar fires; *then* within N bars (default 3), price moves at least 2 ticks beyond signal bar extreme in the signal direction. Only then is the actual entry signal plotted (v460, [23:00]–[23:31]). [ONCE]
- **Delta Scalper trade entry signal trigger**: same 2-tick / 3-bar structure as Catalyst (v463, [10:23]–[11:21]). [ONCE]
- **Vol Shift trade entry signal trigger**: default is 1 tick within 5 bars (programmer default; Mike normally uses 2 ticks / 2 bars) (v464, [11:06]). [ONCE — and note the parameter discrepancy, see Section R]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Price should immediately move away from the signal zone without returning (the "strongest signal" criterion) (v460, [34:24]). [ONCE]
- Momentum alignment: the broader market should already be trending (or starting to trend) in the signal direction — momentum filter provides this gate (v460, [11:06]; v463, [08:09]). [REPEATED]
- POC should continue to move in the signal direction on subsequent bars (implied by PC movement tracking) (v463, [04:02]). [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Price returning to or trading through the signal zone is the primary invalidation; zones are drawn "until tested" specifically to visualize this level (v460, [43:25]–[43:50]). [ONCE]
- No follow-through (trade entry signal not met) = skip the trade; treat as a false start (v460, [44:35]; v463, [10:52]). [REPEATED]
- PC moving opposite to price direction after entry signals a potential reversal and is an exit/invalidation cue (v463, [04:02]). [ONCE]

---

## M. Stop / risk / target / trade management

- Signal zone boundary = stop level: "I use it as a stop level" — if price gets back to the zone boundary, exit the trade (v460, [43:25]). [ONCE]
- No explicit tick-level stop distances given for new indicators in this chunk.
- "Never hope and hold" — if the trade immediately hits the stop level, exit; Delta Scalper described as providing "immediate feedback if you're wrong" (v463, [11:53]). [ONCE]
- Re-entry mentioned once: a stop-out followed by a re-entry signal on Euro FX in the session (v460, [43:50]). [ONCE]
- Targets remain discretionary; no fixed targets stated for any of the three new tools.

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Market-specific Catalyst settings (new specifics)** (v460, [50:55]–[51:28]):
  - Bonds, currencies, grains: default settings + PC movement at 1, or try 3-range chart [ONCE]
  - Gold, crude: default strength + PC movement enabled (v460, [47:46]–[48:27]) [ONCE]
  - YM, MQ (volatile equity indices): try 25-range chart; PC movement less useful due to bar size (v460, [51:28]) [ONCE]
  - NQ/NASDAQ: prominent POC filter not recommended ("don't get very many prominent point of controls"); momentum strength 6 recommended for US session (v460, [1:01:09]–[1:01:49]) [ONCE]
- **Range-based charts for volatile markets**: for NQ/MNQ/YM/gold/crude, range-based charts (not time-based) recommended because they capture price-based structure rather than time (v460, [48:27]–[49:04]); 25-range for YM/MNQ, 10-range for gold/crude (v460, [50:55]–[51:28]). [ONCE]
- **PC movement not useful on very short/narrow bars**: if bars only span 2–3 ticks, there is insufficient POC movement to use as a filter; applies to short range charts and illiquid markets (v460, [17:57]–[18:24]; v463, [17:36]–[18:02]). [ONCE]
- **Multi-time frame analysis**: analyzing a higher (or lower) time frame on your current chart allows cleaner signals when bars are too small for meaningful POC movement (v460, [21:21]–[22:26]; v464, [28:42]–[29:19]). [REPEATED across tools]
- **Order flow data quality**: Ninja Trader / IQ feed / Kinetic / CQG recommended over Interactive Brokers or TradingView for tick-level order flow because those platforms aggregate data in intervals rather than on a trade-by-trade basis, distorting footprint/delta readings (v464, [48:43]–[49:59]). NEEDS-OPERATIONALIZATION [ONCE]
- **Night session / Asian / European hours for NASDAQ**: more controlled, tradeable moves in NQ/MNQ during off-hours vs US session chaos; practitioners who can't handle intraday NQ volatility advised to consider off-hours (v464, [37:27]–[39:13]). [ONCE]

---

## O. Directly testable / measurable variables

- **Catalyst Strength**: integer 1–6; 1 = most lenient distribution filter, 6 = strictest; default 3 (v460, [24:33]–[25:09]). Testable parameter.
- **Momentum Strength (Catalyst/Delta Scalper/Vol Shift)**: integer 0 (off) to 6; default 2 on Catalyst; Delta Scalper has weak/average/strong scale (not numeric in v463); Vol Shift default 3; 0 = no momentum gate (v460, [25:43]; v463, [08:09]; v464, [05:25]). Testable parameter.
- **PC Movement strength**: integer ≥1 (disabled = off); default 5 on Catalyst and Delta Scalper; values of 1, 3, 5, 10 used by Mike; for narrow bars set to 1 or disable (v460, [26:55]–[27:32]). Testable parameter.
- **Prominent POC filter**: binary on/off; mutually exclusive with PC Movement filter (can't use both simultaneously) (v460, [25:43]–[29:24]; [46:24]–[47:05]). Testable.
- **Trade Entry Signal: ticks**: default 2 ticks (Catalyst/Delta Scalper); 1 tick default on Vol Shift (programmer setting, Mike normally uses 2) (v460, [23:00]; v464, [11:06]). Testable.
- **Trade Entry Signal: bars**: default 3 bars (Catalyst/Delta Scalper); 5 bars default on Vol Shift (v460, [23:00]; v464, [11:06]). Testable.
- **Vol Shift V-Level**: integer 1–3; 1 = loosest, 3 = strictest; start at 1 (v464, [15:46]–[16:26]). Testable.
- **Auction Skew (Vol Shift)**: binary on/off; measures volume distribution skew within bar; enabled = fewer but cleaner signals (v464, [04:52]; [17:04]–[17:46]). Testable.
- **Equals filter (Catalyst)**: binary on/off; handles rare equal-volume edge cases; "difference is minuscule — maybe one or two trades a day" (v460, [25:09]). Low impact.
- **Recommended chart ranges by market** (v460, [50:55]–[51:28]): bonds/currencies/grains = 3-range; gold/crude = 10-range; YM/MNQ = 25-range. NEEDS-OPERATIONALIZATION (these are starting points not fixed rules).
- **Zone "until tested" vs "fixed"**: until-tested persists the zone until price touches it; fixed draws it out for a specified number of bars (default 5) (v460, [34:24]–[36:07]). Visual/management parameter.

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Catalyst architecture**: runs footprint/tick-replay analysis under the hood; can be plotted on any chart type (candlestick, bar, footprint) without needing a visible footprint chart; requires tick replay for historical signal plotting (v460, [19:31]–[20:04]; [55:50]). [ONCE]
- **Multi-time frame overlay on single chart**: all three indicators (Catalyst, Delta Scalper, Vol Shift) support specifying an alternate period type/value; signals from a 3-minute or 30-second analysis plotted on a 1-minute chart (v460, [21:21]–[22:26]; v463, [06:07]–[07:33]; v464, [28:42]–[30:38]). Implementation pattern worth replicating. [REPEATED]
- **Signal zones drawn from bar extreme in opposite direction** (Vol Shift default "opposite direction" mode): bullish signal → zone drawn from bar bottom (acts as stop); bearish signal → zone drawn from bar top. The "bar direction" mode draws from the signal-direction extreme instead. Option to draw both simultaneously (v464, [13:51]–[14:32]; [31:44]–[33:25]). [ONCE]
- **PC movement as a secondary signal gate**: POC must move bullishly (on bullish bar) or bearishly (on bearish bar) within the bar for signal to fire. Applicable to footprint-based indicators (v460, [26:17]–[26:55]; v463, [03:01]–[04:31]). [REPEATED]
- **Swing filter and momentum strength are generally incompatible** when used together: momentum strength is for trend-following; swing filter is for reversal detection; using both simultaneously largely cancels them out (v464, [12:04]–[12:34]). [ONCE]
- **TradingView limitation for order flow**: TradingView aggregates intra-bar data in fixed intervals (1 sec → 1 min → 15 min → 60 min → 1 day) rather than trade-by-trade; this distorts footprint/delta calculations vs. Ninja Trader / Sierra Chart / Go Charting / Motive Wave (v464, [46:37]–[49:20]). Not directly an NT implementation note but relevant to data infrastructure. [ONCE]
- **License token linked to Ninja Trader machine ID**: BIOS/Windows upgrade may generate new machine ID, requiring license reset via a provided reset link (v464, [35:31]–[36:08]). [ONCE]

---

## Q. Notable verbatim quotes

1. "An imbalance by itself could just be a big order that hit the market, right? Nothing more than that. And if there's no follow through, the imbalance doesn't mean anything." (v460, [03:29])

2. "It's not just about looking at, oh, there's a buying imbalance — that's bullish. You can't think that way because again you don't know what's causing it." (v460, [10:30])

3. "The ones the strongest moves are going to come when you have a zone being drawn out where it doesn't even come back and test it at all." (v460, [34:24])

4. "What we've found over the years of trading and analysis is it's not just that there's aggressive traders present — you need to understand how that aggressive trading is being distributed between both the aggressive traders and the passive traders, and when it matters the most." (v460, [05:27])

5. "When price moves one way but PC moves the opposite, you're going to suspect a possible reversal taking place and you catch them early." (v463, [04:02])

6. "A big order can cause delta to jump. But if it's coming in in the middle of sideways activity, right, where traders are happy to transact — that's where you expect the big orders to come." (v463, [05:04])

7. "Momentum aligns with order flow — when both point in the same direction you have the highest probability setups." (v463, [08:09])

8. "If you don't know where a trade should be invalidated, then it's not really a trade you should be taking. If you have to set wide stops, it's probably not really worth the risk." (v463, [12:55])

9. "Bars and movements don't happen in a vacuum. It's related to what just took place in the market." (v464, [09:37])

10. "Swing filter is designed to find swing highs and swing lows for reversal trades. So if you have momentum on, it's pointless to use a swing filter." (v464, [12:04])

---

## R. Contradictions / nuances

- **Vol Shift trade entry signal default differs from Mike's stated preference**: the indicator shipped with 1 tick / 5 bars as default; Mike explicitly states "normally I use two and two" (v464, [11:06]). This contradicts the indicator's own default and implies the shipped default may not reflect his actual practice. [ONCE]
- **Swing filter + momentum = contradictory** (new explicit statement): Mike says using both simultaneously "negates" each other because momentum is trend-following and swing filter is reversal-detecting (v464, [12:04]–[12:34]). This directly constrains indicator logic: a reversal model using a swing filter should NOT also apply a trend-momentum gate (or the gate must be disabled/set to its lowest value). [ONCE]
- **Prominent POC filter and PC movement filter are mutually exclusive** at the indicator level (explicitly stated): they "go against each other" because one is momentum-based and the other is support/resistance-based (v460, [28:45]–[29:24]). This constrains signal-logic design. [ONCE]
- **"Same settings every market" nuance refined**: Mike re-emphasizes that default settings are a starting point for all markets, but explicitly recommends different range chart types per market (3 / 10 / 25 range) and different momentum/PC settings for volatile markets vs. liquid markets — so "same logic" ≠ "identical parameters" (v460, [50:19]–[51:28]; v463, [13:29]–[14:06]). Refines existing digest note.
- **NQ/NASDAQ prominent POC filter explicitly discouraged**: bars are too large for meaningful POC concentrations; prominent POC filter "not one I would worry about" on NASDAQ/YM/MNQ (v460, [1:01:09]–[1:03:27]). Extends the existing digest's per-market context filters.
- **TradingView order flow data not trade-by-trade**: TradingView's footprint aggregates by interval, producing different (less accurate) delta/imbalance readings vs. NT-based platforms; this is a data-quality issue, not a strategy issue (v464, [46:37]–[49:20]). [ONCE]

---

## Coverage note

All three videos (v460, v463, v464) are product-launch webinars — T3 relevance by the chunk's own classification. They contain virtually no new reversal model content; their primary value is (a) the explicit PC movement / POC divergence concept as a reversal/continuation discriminator, (b) confirmation that distribution discrepancy (not just delta or imbalance) is the underlying signal logic, and (c) several concrete parameter/setting details for NinjaTrader implementation. The reversal-specific A+ model content is sparse; the bulk of the transcript is sales pitch and indicator demo.
