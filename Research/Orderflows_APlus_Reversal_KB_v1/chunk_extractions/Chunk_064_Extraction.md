# Chunk 064 Extraction
- Source chunk: Chunk_064_Orderflows_Transcripts.md
- Transcripts covered:
  - v201 — Everything You Wanted To Know About Orderflows Part 1 Michael Valtos Order Flow Trading (2021-03-07)
  - v202 — Part 2 Everything You Wanted To Know About Orderflows (2021-03-07)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta divergence** (bearish/bullish): new high (or equal high) on a red bar with negative delta = bearish; new low on a green bar with positive delta = bullish. Price-action confirmation (bar direction must agree with delta) is required — divergence alone on a green candle with negative delta is NOT a valid trade. (v201, [38:13]–[39:08])
- **Exhaustion print** (bearish/bullish): buying dries up at the bottom of an up bar (up to 9 contracts on most markets, 3 on NQ, 50 on 10-year); selling dries up at the top of a down bar. Each bar is assessed independently; not looking for selling at top of green bar or buying at bottom of red bar. (v201, [44:38]–[46:11])
- **Imbalance reversal** (bearish/bullish): imbalances appear at specific points within the bar — printed as an arrow (red = bearish, light green = bullish). Signals trapped traders. Requires follow-through in the next bar. (v201, [48:36]–[51:36])
- **Zero print** (bearish/bullish): fast trading at the edges of the bar leaves no volume at a price level. Dark red (bearish) or dark green (bullish). Two-tick/two-bar follow-through rule required. Not reliable on NQ or thin/overnight markets. (v201, [51:36]–[54:56])
- **Stacked imbalance** (support/resistance): 3+ buying or selling imbalances stacked neatly on top of each other. Default 3 levels at 4:1 ratio. Drawn as a zone ("until tested" or "fixed"). Act as price levels to trade when market returns. (v202, [00:00]–[03:56])
- **Multiple imbalance bar** (bullish/bearish): 3+ imbalances anywhere in the bar, NOT necessarily stacked. Violet box around the bar. Context-dependent — only meaningful at swing highs/lows. Earlier signal than stacked imbalances. (v202, [05:44]–[13:21])
- **Inverse imbalance** (trapped-trader setup): stacked buying imbalance in a red bar (bearish inverse imbalance, shown red) or stacked selling imbalance in a green bar (bullish inverse imbalance, shown blue). Indicates aggressive traders on the wrong side getting trapped. Stronger than regular imbalance in Mike's hierarchy. Appears more frequently on volatile markets (NQ, gold). Directional rule: trade in the direction of the imbalance — get long ABOVE a bullish inverse imbalance, short BELOW a bearish inverse imbalance. (v202, [13:21]–[24:22])
- **Unfinished business**: market left an open auction at bar edge. Meant for low-volatility range days; now deprecated by Mike for current volatile conditions. Only useful if space exists between signal bar and completion (completion should happen within ~30 min–1 hour). (v202, [24:22]–[32:26])
- **Market sweep detector** (bullish/bearish): big traders sweep through several price levels in one trade. Green/red zones. Scalp-oriented — "get in quick, don't hold for an hour." Most effective on liquid markets (bonds) and overnight (thinner volume). Not useful on NQ. Directional rule: trade long ABOVE a bullish sweep, short BELOW a bearish sweep — NOT after time has passed. (v202, [33:06]–[38:42])
- **Market weakness detector** (bullish/bearish): measures weakening aggressive flow in the current move direction. Blue = bullish (selling momentum weakening), orange = bearish (buying momentum weakening). Best used when weakness appears AFTER a countertrend move (e.g., orange after a rally near HOD/swing high, blue after a selloff near LOD/swing low). Sequence length = 3. (v202, [38:42]–[45:11])
- **Value area (per-bar)**: the gray zone within a bar representing 70% of volume. Used bar-by-bar (open outside previous bar's value area, then trade through = momentum signal; or open outside and reject = reversal signal). (v202, [45:11]–[50:03])
- **Expanded value area (EVA)**: bullish EVA = blue, bearish EVA = red. Analyzed volume distribution highlights when value is abnormal. Context required: bearish EVA after a rally = reversal signal; bullish EVA after a selloff = reversal signal. Requires follow-through in next 1–2 bars. (v202, [50:03]–[52:14])
- **Delta divergence + ratio combo** ("bread and butter"): delta divergence PLUS a ratio reading is preferred over divergence alone, because lone divergence fails repeatedly on trending/flow-driven days. (v201, [43:07]–[44:05])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"Bread and butter"** = delta divergence + ratio together (not divergence alone). (v201, [43:07])
- **"Not the type of trade you want to take"** = imbalance reversal where next bar opens on the wrong side of the imbalance level; or inverse imbalance where price opens below a bullish level. (v202, [22:22], [23:44])
- **"Weaker signal"** = inverse imbalance set to 2 imbalances at 300% vs 4:1 (he uses the lower settings only for illustration, not in live trading). (v202, [22:22])
- **"Not a great"** / **"not going to be effective"** = using zero prints on NQ or mini-Dow (too thin), or market sweep detector on NQ (skips price levels). (v201, [55:24]; v202, [35:31])
- **"Useful" vs "not useful anymore"** = unfinished business was useful in low-volatility environments (pre-2020 era range days with 15-pt e-mini range); Mike explicitly retired it for current market conditions. (v202, [24:22], [25:01])
- **"Nice" / "good"** = stacked imbalance that holds beautifully on retest. (v202, [03:27])
- **"More effective"** = horizontal delta footprint (over diagonal delta) in Mike's personal practice. (v201, [30:56])
- **"Very important in my opinion"** = multiple imbalances. (v202, [05:44])
- **"Stronger tool"** = inverse imbalance overrides stacked imbalance color because it is higher conviction in Mike's hierarchy. (v202, [13:57]–[14:31])
- **Implicit tiering of follow-through gate**: a signal that doesn't move the next bar "even one tick" beyond signal-bar extreme = skip; "not working immediately" = get out, don't wait for stop. (v201, [51:09]; v202, [10:35])

---

## C. Order-flow story & psychology per setup

- **Delta divergence**: new high/low achieved but delta is opposing → "the market starts to reverse" because price action and aggressive flow are disconnected. Bars that are green with negative delta indicate absorption (supportive buying absorbing aggressive sellers), not divergence — that is a different story. (v201, [38:38], [41:19])
- **Multiple imbalances at swing high**: sellers/buyers showed up aggressively enough to leave 4–6 scattered imbalances inside the bar. Even without neat stacking, those who took the other side are now at a disadvantage if price reverses. (v202, [07:58]–[09:25])
- **Inverse imbalance**: aggressive traders "jumped in front" of the market (e.g., bought into a number), left stacked buying imbalances behind, but then "realized they were stuck and sold off." Trapped aggressors eventually puke, driving price back and then through their entry zone. (v202, [15:43]–[17:11])
- **Market sweep**: "big traders swept through several price levels" — interpreted as directional conviction. Stop-triggers can also cause sweeps (less reliable than mid-bar sweeps). (v202, [33:06], [38:09])
- **Market weakness at LOD**: selling momentum weakens at low of day → buyers step in; reverse for HOD. The key is context: weakness at an extreme is a reversal cue; weakness during a move is just a pause. (v202, [44:37])
- **Flow-driven market**: when divergence fails repeatedly, "the flow coming into the market is what's driving it, not technical levels." Technical levels are respected on normal days, not on flow-driven days. (v201, [44:05])

---

## D. Exhaustion clues

- Exhaustion print = volume at edge of bar dries up (≤9 for most markets). Mike uses **9 for e-mini/bonds-class**, **3 for NQ** (less liquid), **50 for 10-year note** (heavy volume market). [REPEATED across videos; specific numbers = exact, not NEEDS-OPERATIONALIZATION] (v201, [45:11]–[46:42])
- Exhaustion prints stacking at a swing level (multiple sequential prints at same extreme) = signal worth paying attention to; single random exhaustion print during trend = low quality. (v201, [47:12])
- Single print / "price exhaustion" (one lot at swing high) cited in multiple-imbalance reversal example as a supplementary clue. (v202, [09:25])

---

## E. Absorption clues

- Green candle with negative delta at a low = "form of absorption" — supportive buyers absorbing aggressive sellers. NOT a divergence; bar returns higher because absorption absorbs the sell pressure. (v201, [41:19]–[41:49])
- Max delta / min delta relationship at swing low: max delta close to the closing delta (e.g., 1970 max vs 1969 close) = buyers were in control all bar; min delta of zero = "at no point were aggressive sellers in control of this bar" = bullish absorption scenario. (v202, [07:58]–[08:28])

---

## F. Stacked imbalance ideas

- Default: 3 levels stacked, 4:1 ratio. Can be reduced to 2 for range charts or to 3:1 for more frequent signals (he uses 4:1 in live trading). On NQ or volatile markets consider requiring 5 levels to filter noise. (v202, [00:00]–[02:04], [12:11])
- Two display modes: **"until tested"** (zone disappears once price touches it) vs **"fixed"** (stays for a set number of bars). "Until tested" is the mode Mike uses in live analysis — he tracks when price comes back to these levels. (v202, [00:28]–[01:31])
- Stacked imbalances are support/resistance, not entry triggers — "you want to know how the market reacts when it gets back to it." Some hold beautifully, some just run through. (v202, [03:27]–[04:39])
- Long-term stacked imbalances can persist across sessions: example of e-mini imbalance from "way, way back" — price came back to exact tick after major selloff, hit the zone, made HOD, then sold off. (v202, [17:11]–[18:36])

---

## G. Delta / delta-divergence ideas

- **Max delta / min delta / final delta relationships** (intrabar): as market declines, min delta should be growing negative and max delta should be small; as market reverses, max delta grows and min delta weakens. This is the "exhaustion of the prior move" read. (v201, [23:24]–[25:27])
- **Cumulative delta**: growing positive = bullish bias; flipping back and forth before a number = market in indecision. Cumulative delta shifting positive and holding = confirms underlying bid. Not his primary filter but a supporting read. (v201, [21:14], [26:35]–[27:32])
- **Delta divergence is NOT valid on green candle with negative delta** unless price action reverses: "the worst type of trade you can take is to get short on a bar that's trading higher." Requires bar color to match delta signal. (v201, [38:38]–[39:08])
- **"Divergence divergence divergence that fails" = trend day**: 3+ consecutive failed divergences in ~1 hour → "chances are it's going to keep failing" because it is a flow-driven market, not technical. Skip divergence trades on those days. (v201, [43:36]–[44:05])
- **Delta footprint preference**: horizontal delta (delta per price level = bid vs ask at same price) preferred over diagonal delta. Diagonal delta measures the two-way auction cross-level imbalance and is valid for some traders, but Mike finds horizontal more effective in his own practice. (v201, [28:07]–[30:56])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Market sweep detector** identifies large trader sweeps through consecutive price levels. Stops can trigger sweeps (stop-run variant); sweeps in the middle of bars (not at edge) are more reliable than edge sweeps which may be stop-triggers only. (v202, [38:09]–[38:42])
- Sweeps that fail to continue beyond the sweep level ("couldn't even go above the sweep") = no trade; must get follow-through immediately. (v202, [36:59]–[37:31])
- Inverse imbalance is functionally a stop-run/trapped-trader concept: aggressive buyers at a high leave imbalances behind → "realized they were stuck" → puke drives price lower through imbalance. (v202, [16:45]–[17:11])

---

## I. Trapped-trader ideas

- **Inverse imbalance = trapped traders**: stacked buying imbalance inside a red bar = people who bought aggressively are now trapped in a losing long. Stacked selling imbalance in a green bar = trapped shorts. (v202, [13:21]–[14:31])
- **Imbalance reversal** also signals "potentially trapped traders." (v201, [51:36])
- **Directional rule for trading inverse imbalances**: only get long ABOVE a bullish inverse imbalance (blue); only get short BELOW a bearish inverse imbalance (red). Do NOT trade against the zone. (v202, [22:49]–[23:17])
- For short trades off inverse imbalance: "you want to be getting short below this level, not above it" — the trapped buyers' puke takes price through the zone, and that's where you participate. (v202, [22:49])

---

## J. Entry triggers (the exact "go" event)

- **Delta divergence**: entry after confirmation bar (next bar after signal bar) begins moving in signal direction. For bearish: new high + negative delta + red bar = sell signal bar, enter on next bar moving lower. (v201, [40:15]–[40:54])
- **Exhaustion print**: wait for next bar to confirm direction — "what I'm looking for is the follow-through in the next bar." For zero prints: "two ticks over two bars" minimum before entry. (v201, [52:37]–[53:06])
- **Imbalance reversal**: next bar must take out the signal-bar extreme (low for bearish, high for bullish). If next bar doesn't even take out the extreme, skip — "to me that's no trade." (v201, [51:09])
- **Market sweep**: entry immediately on or after the sweep; "you gotta participate right now — you're going to scalp it basically." Not "5 minutes later." (v202, [36:59], [37:31])
- **Market weakness detector**: wait for weakness signal near HOD/LOD or swing extreme, then watch next bar for follow-through breakdown/breakout. (v202, [41:05]–[41:34])
- **Multiple imbalance bar**: "all you got to wait for is the next bar to start showing you some bullish [or bearish] activity." Next bar moving in direction = entry. (v202, [08:57])
- **Inverse imbalance**: trade in the direction of the imbalance from above (bull) or below (bear) the level. Do not enter on the wrong side. (v202, [22:49]–[23:17])
- **EVA (expanded value area)**: requires follow-through in next 1–2 bars ("bearish value area right, and the market sold off"). (v202, [50:34]–[51:40])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Market must move in signal direction within 1–2 bars of signal. "It's not working immediately — that's your time to get out, don't have to sit there and wait till the market stops you out." (v202, [10:35]–[11:05])
- Sweep: "take advantage of it quick" — continuation expected immediately, not after several bars drift. (v202, [37:00])
- Multiple imbalance: after entry, market should "start trading higher" from the zone — within the next bar. (v202, [08:57])
- Weakness signal: next bar after weakness arrow should begin the reversal move. If next bar "can't even take out the high (or low)" of signal bar → no trade. (v202, [41:05], [43:10])
- Value area / EVA: follow-through "two bars later" used as example; "not the next bar" acceptable but limited to 2-bar window. (v202, [51:06])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Next bar goes back the wrong way (doesn't take out signal-bar extreme): "no trade" or exit immediately — applies to imbalance reversals, zero prints, weakness signals, sweeps, EVA. (v201, [51:09]; v202, [10:35])
- Delta divergence that fails three+ times in a row → trend day; stop fading, shift to trend-following or stand aside. (v201, [43:36]–[44:05])
- Inverse imbalance: price opens on the wrong side of the imbalance zone = no trade. "You want to be getting short below this level, not above it." Opening above a bearish inverse imbalance means trapped traders haven't capitulated — wait. (v202, [22:22]–[23:58])
- Sweep failure: price can't go above (bullish) or below (bearish) the sweep level = no continuation, no trade. (v202, [36:59])
- Zero print near HOD or at extremes opposite to desired direction: "I would not be looking to get long at the high of the day" — location context overrides the signal itself. (v201, [54:03])
- Unfinished business that completes in the very next bar = no space, no trade. Need space (several bars) between signal and completion level. (v202, [28:28]–[28:55])

---

## M. Stop / risk / target / trade management

- **Signal-bar low/high = initial stop**: "the signal bar low is my first place I'm going to be looking as my stop." Stop 1 tick beyond signal-bar extreme. (v201, [54:25]–[54:56])
- **Don't wait to be stopped out**: "if the market's going sideways on you, get out." Discretionary time/behavior stop — if market doesn't move within next bar or two, exit manually. (v201, [51:36]; v202, [10:35])
- **Stacked imbalance example risk/reward**: entering near stacked imbalance zone in micros e-mini with 4–5 point stop; potential 20-point retracement move = 4:1 to 5:1 reward/risk. [ONCE; specific trade example, not a universal rule.] (v202, [05:12]–[05:44])
- **Sweep = scalp**: not held for hours. Scalp mentality implied. (v202, [37:31])
- **Market weakness**: "if it doesn't happen then no trade." No specific target stated for weakness signals. [NEEDS-OPERATIONALIZATION for targets]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **HOD/LOD awareness required**: preferred entries for bullish setups = near LOD; for bearish = near HOD. "I'd prefer to get long somewhere near the low of the day." Zero prints / sweeps / weakness signals at the opposite extreme = low quality. (v201, [54:03]; v202, [45:11])
- **Swing high/swing low = preferred location**: multiple imbalances, inverse imbalances, and weakness signals are only context-appropriate at swing extremes. Random bars mid-trend with same signals = skip. (v202, [07:25], [13:21], [44:37])
- **News/economic numbers**: avoid trading during NFP/CPI/PPI/number releases. After number, wait for volume to normalize before re-engaging order flow signals. "Once it settles down, revert back to your analysis." (v201, [47:12])
- **Overnight/night session**: zero prints more frequent (less volume); sweeps more frequent (thinner market). Signals valid but context differs from day session. (v201, [53:32]; v202, [36:31])
- **Market liquidity filter**:
  - NQ/mini-Dow: zero prints not reliable (too many); inverse imbalance less meaningful; sweep not useful. (v201, [55:24]; v202, [35:31])
  - 10-year notes / bonds: high volume → exhaustion threshold = 50; sweep detection meaningful. Moves slowly but size capacity is high. (v201, [46:11])
  - E-mini (ES): standard settings (exhaustion 9, imbalance 4:1). Inverse imbalances rare during day session due to volume. (v202, [17:11])
  - Crude oil: standard settings work; sweeps visible and meaningful. (v202, [21:42])
  - Gold: more volatile; inverse imbalances appear more frequently. (v202, [13:21])
- **"Unchanged" line / opening price**: keep current day open/high/low/close on chart at all times; divergence signals occurring at HOD/LOD have the highest context value. (v201, [39:42])
- **Flow-driven vs technical day**: 3+ failed divergences in ~1 hr → flow-driven day. Technical levels not respected on flow days. Adjust by stopping fade attempts. (v201, [44:05])
- **Value area gaps**: 2 gaps in a row → expect pullback to close both gaps. 3 gaps → definitely anticipate a pullback. (v202, [49:34]–[50:03])
- **Unfinished business**: only valid in low-volatility range-day conditions; effectively deprecated by Mike for post-2020 volatile conditions. (v202, [25:01])

---

## O. Directly testable / measurable variables

- Exhaustion print threshold:
  - Most markets (ES, crude, bonds, etc.): **≤9** [REPEATED]
  - NQ: **≤3** [REPEATED]
  - 10-year note: **≤50** [REPEATED] (v201, [45:11]–[46:42])
- Imbalance ratio default: **4:1 (400%)** [REPEATED]. Alternatives: 3:1 (300%) or 10:1 (1000%) depending on market. (v202, [01:01]–[02:04])
- Stacked imbalance minimum levels: **3** [REPEATED]. For range charts (4–5 tick bars): consider **2**. For volatile markets (NQ, DAX): consider **5**. (v202, [01:31], [12:11])
- Multiple imbalance minimum: **3** imbalances in bar (not necessarily stacked). Default threshold matches the imbalance ratio setting. (v202, [06:51])
- Value area percentage: **70%** (one standard deviation). Can be adjusted to 50%; Mike warns against going above 70%. (v202, [46:16])
- Market sweep levels: **3 sweep levels minimum**; sweep threshold = **10** (adjustable; Mike tries 25 for bonds). Not useful on NQ or thin markets. (v202, [33:41])
- Market weakness sequence length: **3** bars. [ONCE] (v202, [39:57])
- Delta divergence bar-color requirement: signal bar must match direction (red bar for bearish signal, green bar for bullish signal). [REPEATED] (v201, [38:38])
- Zero print follow-through: **2 ticks over 2 bars** minimum before declaring follow-through. [ONCE] (v201, [52:37])
- Value area gaps: **2 consecutive gaps** → expect pullback; **3 consecutive gaps** → higher-confidence pullback expectation. [ONCE; NEEDS-OPERATIONALIZATION for "gap" definition across bar sizes] (v202, [49:34])
- Stacked imbalance zone mode: "until tested" = zone removed on first retest touch (Mike's preferred mode). [ONCE] (v202, [00:28])
- Inverse imbalance strength: **stronger than regular imbalance** in Mike's hierarchy (drawn on top of stacked imbalance color). [ONCE] (v202, [14:31])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- All tools are sub-indicators within the **Orderflows Trader** NinjaTrader 8 add-on, loaded via "Import NinjaScript Add-On." License token required. (v201, [15:16])
- Indicator appears at the **top** of the indicator list (space prefix in name) — not alphabetically within the list. Practical detail for custom NT indicators. (v201, [15:47])
- **Tick replay must be enabled** in the chart for the indicator to backfill historical footprint data. Without it, the footprint starts fresh on chart load only. (v201, [14:47])
- Indicator settings default to **1-minute ES chart** — per-market adjustment needed. (v201, [16:19])
- **Four footprint types available**: bid-ask (Mike's primary), delta (Mike's secondary), diagonal delta, volume. Mike does NOT use diagonal delta or volume footprint. (v201, [27:32]–[36:49])
- Delta footprint (horizontal) shows: delta at each price level (bid side at price vs ask side at price), final delta, max delta, min delta, cumulative delta, volume. All can be toggled independently. (v201, [20:47])
- Exhaustion print box size configurable (how many bars wide the visual highlight extends). Default = 1. Can be set to 10 for zone drawing. (v201, [45:40])
- Inverse imbalance **overrides stacked imbalance color** in the visual — implied priority in rendering logic. (v202, [14:31])
- Market sweep detector: set **sweep levels = 3** and **sweep threshold = 10** as starting point. Disable on NQ. (v202, [33:41])
- Market weakness: set **sequence length = 3**. Blue = bullish weakness; orange = bearish weakness. (v202, [39:57])
- Value area: displayed as a **gray zone within the bar** for the 70% volume region. EVA highlighted in **blue (bullish)** or **red (bearish)**. (v202, [46:16], [50:34])
- Unfinished business: two modes — **"Detect Unfinished Business"** (shows only current open levels) vs **"Draw Broken Levels"** (shows all historical). Mike prefers the first in live trading; the second clutters the chart. (v202, [27:02]–[27:33])
- Imbalance coloring: light green = bullish imbalance reversal arrow; dark green = bullish zero print; blue = bullish inverse imbalance. Distinct color coding distinguishes setup types. (v201, [49:02], [52:12]; v202, [13:57])
- **Per-instrument parameter sets**: exhaustion thresholds, imbalance ratios, stacked minimum levels all adjusted per instrument. Same detector software across all markets but settings must be tuned. (v201, [45:40])

---

## Q. Notable verbatim quotes

1. "I like to have price action involved right — because there's no point in making a new high with negative delta and then the market keeps going higher right, I want to see the market start to reverse." (v201, [38:38])

2. "Why would you get short on a bar that's trading higher right? I mean that's the worst type of trade you can take." (v201, [38:38]–[39:08])

3. "When you see divergence, divergence, divergence that fails — chances are it's going to keep failing right — because what's happening in the market is a bit stronger… the flow that's coming into the market is really what's driving the market, not technical levels." (v201, [43:36]–[44:05])

4. "You see it, you're going to get involved — you're going to scalp it basically — you're not going to buy and hold for an hour or two hours." (v202, [37:31]) [about market sweeps]

5. "It's not working immediately — that's your time to get out, you don't have to sit there and wait till the market stops you out." (v202, [10:35])

6. "You want to be getting short below this level, not above it — that's what you're doing when you're dealing with imbalances — you want to be going in the direction of the imbalance, you don't want to be fighting that imbalance." (v202, [22:49])

7. "Once you understand what's happening in the market right, you don't have to keep changing your plan." (v201, [11:51])

8. "On flow-driven markets they don't get respected [technical levels] — so the next thing I'll talk about is where are we here…" (v201, [44:05])

9. "The beauty of a contract like the 10 years is you can move size in there, it's very liquid, and you can move 100 contracts in there — you're not going to move the market." (v201, [55:57])

10. "If you see two gaps in a row, there's one gap, here's two gaps — we tend to come back in and try to close both of them." (v202, [49:34])

---

## R. Contradictions / nuances

- **Green candle with negative delta ≠ bearish divergence**: Mike explicitly states a green bar with negative delta is "a form of absorption" (supportive buying) NOT a divergence. This distinguishes two superficially similar footprint patterns that have opposite implications. Many traders conflate them. (v201, [41:19])
- **Delta divergence alone is unreliable without ratio**: Mike says he personally requires the ratio to filter divergence trades, but acknowledges other traders just use divergence alone. This is a preference, not a hard rule for others. (v201, [43:07])
- **Inverse imbalance is contextually stronger than stacked imbalance**, but only appears in more volatile/thinner markets. On high-volume markets (ES day session), it rarely fires — making it effectively unavailable where it might be most useful. (v202, [13:21], [17:11])
- **Unfinished business explicitly deprecated** by Mike: he says "I don't use it anymore" under current (post-2020) market conditions. However, the tool remains in the software. Other traders who attended earlier training may still use it. (v202, [25:01], [26:32])
- **Volume profile vs per-bar value area**: Mike says he "doesn't use volume profile so much anymore" since per-bar value area is available. The traditional session-level value area is superseded in his analysis by bar-by-bar value area analysis. (v202, [56:57])
- **"Same settings every market"** caveat: he reiterates that exhaustion thresholds, stacked levels, and imbalance ratios DO vary by market despite being within the same indicator platform. NQ uses 3 for exhaustion, 10-year uses 50. "Same settings" applies to the detection logic/algorithm, not the parameter values. (v201, [45:11]–[46:42])
- **Sweep at bar edge less reliable than mid-bar sweep**: sweeps at highs of green bars or lows of red bars "could just trigger a stop" and are less reliable. Mid-bar sweeps = more genuine institutional flow. [ONCE; NEEDS-OPERATIONALIZATION for "mid-bar" detection] (v202, [38:09])
- **Market weakness at LOD ≠ signal to buy**: only meaningful when it appears AFTER a selling move, at a logical support/extreme. Weakness showing during an already-declining move is "not what you want — it's already going in that direction." (v202, [40:24]–[41:05])
- **Value area percentage = 70%, not 68.2%**: Mike explicitly acknowledges the "68.2% is really one standard deviation" argument but says "70 is fine" — he uses 70% as a practical round number. (v202, [46:16])

---

## Coverage note

v201 is the richer of the two transcripts — a structured webinar systematically walking through all Orderflows Trader tools with live NinjaTrader examples; high extraction value for tool descriptions, thresholds, and market/instrument context filters. v202 continues the walkthrough with stacked imbalances through EVA; somewhat less model-dense due to more chart-navigation narration but still captures the multiple imbalance, inverse imbalance, unfinished business, sweep, weakness, and value area tools. Both are T2 (model-applied) content. Primary limitation: most signals are demonstrated on charts that viewers can see but readers of transcripts cannot; some entry/exit examples are partially described through visual references.
