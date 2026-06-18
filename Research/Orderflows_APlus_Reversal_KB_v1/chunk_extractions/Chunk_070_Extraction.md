# Chunk 070 Extraction
- Source chunk: Chunk_070_Orderflows_Transcripts.md
- Transcripts covered:
  - v215 — "Orderflows Power Bar For Trading Value and Order Flow With Futures Stocks and Crypto" (2021-06-24)
  - v216 — "Find Winning Trades In The Order Flow Investor Expos July 8 2021 Orderflows Trader" (2021-07-09)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Power Bar** (bullish/bearish): a bar whose order flow (value + directional intensity) meets a configurable strength threshold; colored cyan (bullish) or magenta (bearish) on the NinjaTrader bar chart. Not a footprint-exclusive tool — runs on a standard bar chart, no tick replay required. [REPEATED] (v215, "Power Bar...", [11:14])
- **Power Bar + Trade Entry Signal (confirmed Power Bar)**: A Power Bar that has printed a follow-through triangle — meaning price moved ≥ 2 ticks in the signal direction within the next 2 bars. This is the entry-ready version; a Power Bar without the triangle is noted but not acted on unless scalping. [REPEATED] (v215, [11:53])
- **Multiple Imbalances in a Bar** (bullish/bearish): 3 or more imbalances of the same direction within a single bar, flagging strong directional order flow. Treated as a standalone entry trigger. [REPEATED] (v216, [26:24])
- **Delta Surge** (bullish/bearish): sequential increase in delta (absolute magnitude) across several consecutive bars in the same direction; signals large-player order accumulation/distribution. Treated as a standalone entry trigger. [REPEATED] (v216, [32:28])
- **POC Migration** (bullish/bearish): tracking whether the bar-level point of control is moving consistently higher (bullish) or lower (bearish) across a series of bars, used as a trade-management/confirmation filter rather than a standalone trigger. [REPEATED] (v216, [13:44])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **Confirmed Power Bar (triangle present)** is the tradeable-grade signal; unconfirmed Power Bar (no triangle) = "not a trade you want to take" / "you're going to get chopped up." [REPEATED] (v215, [15:31])
- Grading by follow-through: "follow through order flow" = bullish/bearish grade; absence of follow-through = disqualifier regardless of the power of the signal bar itself. (v215, [13:33])
- Grading by context for Multiple Imbalances: imbalances at/near **highs or lows of day, swing highs/lows, or at edges of sideways consolidation** = "trade them"; imbalances in the middle of a trend = implied lower priority. (v216, [29:44])
- Delta Surge grading: surge **in a sideways market** = "ideally" / highest-quality version; surges can appear anywhere but sideways is the preferred context. (v216, [38:20])
- "3 four-point moves a day in e-minis" framed as a transformative result — implying that multiple-imbalance / delta-surge setups are high-frequency enough to be daily bread-and-butter. (v216, [28:20]) [ONCE]
- Power Bar strength parameter range: **10–85** usable; **50 = moderate / midpoint**; ≥75 is "as high as I would go" for most purposes; 10 = very loose (many signals, use swing filter with it); 75–85 = fewer, stronger signals suited to scalping immediate ticks only. [REPEATED] (v215, [21:37])
- Swing strength at **zero = disabled**; setting it to 1 with low power-bar-strength (e.g., 10+1) helps filter the excess signals in volatile markets. (v215, [35:13])

---

## C. Order-flow story & psychology per setup

**Power Bar / follow-through:**
- A large order hitting the market (e.g., "buy me 500 ultra bonds") can create a big bar without lasting directional intent; without subsequent follow-through, small traders get "stuffed" if they chase. (v215, [16:21])
- If there IS genuine institutional intent behind the Power Bar, aggressive follow-up buying/selling will materialise in the next 1–2 bars; that is the trade entry signal. (v215, [12:28])

**Multiple Imbalances story:**
- Imbalances in a bar = aggressive buyers (or sellers) dominating the two-way auction at multiple price levels within that bar. Three or more = "order flow exhibiting strong directional trade." (v216, [26:24])
- The 4:1 ratio default = at least 400% more aggressive side than passive side at a given price level. (v216, [15:58])
- When selling imbalances appear at HOD after a choppy sideways session, the market "has a strong tendency to sell off." The first instance may "make a new high by a tick" before falling — fakeout acknowledged but still tradeable. (v216, [30:17])

**Delta Surge story:**
- Big firms piece large orders in incrementally: sell some, see if market absorbs, sell more. The sequential delta build (e.g., -12, -33, -48) is the footprint of this accumulation. Other traders notice the tick-down and join, building momentum. (v216, [34:47])
- Surge in a sideways market: "nobody's expecting any movement" — element of surprise amplifies the move. (v216, [38:20])

**General order-flow reversal story (v216 introductory framework):**
- Market sells off, delta weakens toward zero (-7, -23, -7, 0), then flips strongly positive (+115, +127) while buying imbalances appear and POC moves higher — the "all three together" = clearest reversal confirmation. (v216, [21:01])
- Positive delta at a low + higher POC + buying imbalances = "much better bar to be getting long off of" vs. a green candle with still-negative delta and lower POC. [ONCE] (v216, [18:04])

---

## D. Exhaustion clues

- Delta drying up toward zero at a swing extreme after a sustained directional move (e.g., -7, -23, -7, 0 on consecutive bars during a sell-off) = selling exhaustion; watch for the flip. [REPEATED] (v216, [21:01])
- Power Bar with no follow-through triangle = exhaustion-like signal that isn't confirmed — "could have just been a big order they had to fill." Treat as noise until confirmed. [REPEATED] (v215, [16:44])
- Three consecutive bearish Power Bars with no follow-through triangle = "the market is telling you it can't break" — exhaustion of the bearish side; next confirmed bullish Power Bar becomes the trade. [ONCE] (v215, [45:09])

---

## E. Absorption clues

- Rising POC at the extreme of a sell-off (POC migrating higher) while price is still near the low = volume being accepted at that level, potential absorption / base building. (v216, [18:31])
- Buying imbalances appearing while price is still falling (before delta turns positive) = early absorption signal; not a trigger yet, but a warning to cover shorts. (v216, [18:04])
- "Point of control is still lower than the previous points of control" with only a couple of buying imbalances + negative delta = incomplete absorption; wait for all three to align. [ONCE] (v216, [18:04])

---

## F. Stacked imbalance ideas

- Multiple imbalances (3+) in a single bar = the primary setup in v216. Presented as equivalent to "stacked" directional intent within the bar (though the term "stacked" is not explicitly used here). [REPEATED] (v216, [26:24])
- "You also got three buying imbalances" in the next bar after a delta surge = confluent signal, strengthening conviction. (v216, [35:47])
- Context rule: take multiple-imbalance signals at/near highs or lows of day, at swing highs/lows, or at sideways-market breakouts; avoid in the middle of a trend. [REPEATED] (v216, [29:44])

---

## G. Delta / delta-divergence ideas

- **Delta surge** setup defined: sequential bars each showing more aggressive delta in the same direction (e.g., +12, +51, +69 or -12, -33, -48). Not a sudden spike but a building tide. [REPEATED] (v216, [33:25])
- Zero delta = coincidence, no special meaning; "could be the difference of one lot." [ONCE] (v216, [32:28])
- **Delta weakening to near-zero at an extreme** = the precursor reversal signal; then watch for the positive flip + imbalances + rising POC as the confirmation trio. (v216, [21:01])
- Positive delta on an up bar + rising POC + buying imbalances = safe to stay long. Conversely, negative delta + lower POC + selling imbalances = safe to stay short. These are trade-management rules, not entry triggers. [REPEATED] (v216, [19:30])
- Delta coloring: red box = negative delta; green box = positive delta; displayed at the bottom of each bar on Mike's footprint template. (v216, [10:32])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- At a high-of-day with multiple selling imbalances: first instance may "make a new high by a tick" — explicit acknowledgement of the one-tick fakeout at resistance before a breakdown. Still tradeable because the imbalances flagged the move. [ONCE] (v216, [30:43])
- Power Bar without confirmation triangle that retraces back into the power bar and then continues higher = "not uncommon for a bar to pull back into the power bar" — treating the power bar range as a value zone that can be retested and accepted/rejected. [ONCE] (v215, [45:43])
- "If you're just reacting to that big order going through the market, you're going to get hung" — warns against chasing a fake power move caused by a one-off large fill. The trade entry signal (follow-through filter) is specifically designed to avoid this. [REPEATED] (v215, [17:08])

---

## I. Trapped-trader ideas

- Traders who get long off a bullish Power Bar that lacks follow-through are trapped; "you're going to get your head handed back to you on a tray" if a large opposing order comes in. (v215, [12:59])
- Traders who stay short after delta exhaustion (delta drying toward zero) and then a delta flip are "fighting the tape" — explicitly called out as a losing habit. (v216, [24:01])
- Chasing the first multiple-imbalance signal when the market makes a new high by a tick before reversing = trapped longs; the setup still works on the follow-through breakdown. (v216, [30:43])

---

## J. Entry triggers (the exact "go" event)

**Power Bar entry:**
1. Wait for Power Bar bar to close fully (never enter mid-bar). [REPEATED] (v215, [41:07])
2. Trade entry signal enabled: price must move ≥ 2 ticks in signal direction within the next 2 bars → triangle prints → enter at that print. Default: 2 ticks / 2 bars. Configurable. (v215, [14:03])
3. Alternative (scalpers only / trade entry signal OFF): place a stop order 2 ticks beyond the Power Bar extreme; fill = entry. (v215, [42:01])
4. The 2-tick / 2-bar default is Mike's personal setting; "you could use five [bars], I wouldn't go higher than five." One tick / one bar works for slower markets. (v215, [14:33])

**Multiple Imbalances entry:**
- Three or more imbalances of the same direction in one bar at/near HOD/LOD or swing extreme or consolidation edge = trigger to enter in the direction of those imbalances on the next bar (implied). (v216, [26:24])
- No explicit tick-offset or bar-count for this setup beyond "right here" pointing at the imbalance bar. [NEEDS-OPERATIONALIZATION]

**Delta Surge entry:**
- Sequential increase in same-direction delta across 2–3+ bars in a sideways market = trigger. Entry implied at observation of the build; no specific bar-count threshold stated beyond "over several bars." [NEEDS-OPERATIONALIZATION] (v216, [33:25])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Power Bar: triangle must print within 2 bars of the signal bar (the follow-through filter IS the confirmation). After entry, price should continue away from the Power Bar. (v215, [14:03])
- "Follow through order flow, right here, follow through order flow back up, follow through order flow back down" — expects consistent directional continuation bar by bar. (v215, [17:34])
- For multiple imbalances / delta surge: subsequent bars should show POC migrating in the trade direction + delta staying aligned + more imbalances. All three aligning is "much more obvious." (v216, [23:33])
- Reversal confirmation trio: positive delta flip + buying imbalances + higher POC all together = "doesn't get any more obvious." (v216, [21:01])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Power Bar: price retraces to the Power Bar extreme and touches the 1-tick stop. (v215, [23:25])
- Power Bar: "if it's not making that move, [after entry] you've got the bearish power bar, off about four or five ticks, rallies back up, doesn't stop me out, makes another move down, can't break any further" → exit discretionarily before full stop. (v215, [47:06])
- Time stop: "I only give it five or 10 minutes [on a minute-base chart]. I don't wait an hour for it to go in my favor." If price goes nowhere for 5–10 minutes, exit. [REPEATED] (v215, [25:16])
- "If you're short and you start seeing buying imbalances appearing... rising points of controls... strong positive deltas — that's your sign to get out" without waiting for a full stop-out. (v216, [23:02])
- Sideways drift for 20 minutes after entry = "you shouldn't be stuck in a trade for 20 minutes if it's going nowhere." (v215, [44:45])

---

## M. Stop / risk / target / trade management

**Stop placement:**
- Power Bar: stop 1 tick beyond the high (bearish) or low (bullish) of the Power Bar. Exact quote: "I use one tick below [the power bar low]. I don't use the exact low." (v215, [24:19])
- "The power bar is my stop" — the range of the signal bar defines risk throughout the trade. [REPEATED] (v215, [46:41])
- Stop does not move to break-even until price has moved sufficiently away; if trade goes sideways, exit before stop is hit rather than wait. (v215, [47:35])

**Targets:**
- No explicit fixed target stated. Exit cues: discretionary based on follow-through fading; time stop 5–10 min; "definitely have a price target in mind" — NEEDS-OPERATIONALIZATION. (v215, [25:49])
- For scalping ultra bonds: "happy to scalp 3 or 4 ticks"; for e-minis: "3 points" moves cited as desirable multiple-times-per-day targets. (v215, [19:18]; v216, [27:17])

**Re-entry / scaling:**
- With micro contracts: scale in — get some at the trigger price, then "stack some bids in here, wait for that pull-back [into the Power Bar]" to average the fill. Stop remains at the Power Bar extreme regardless of average price. [ONCE] (v215, [46:16])

**Time stop:**
- 5–10 minutes on a minute chart; applies regardless of setup type. [REPEATED] (v215, [25:16])

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

**Session / time:**
- "Not advisable to trade the first few minutes of the cash open" — explicitly shown on mini Dow with a 65-point open bar. Wait for "normal bars forming." [REPEATED] (v215, [31:45])
- VWAP becomes effectively flat "late in the day when 80% of the volume is already traded." Use VWAP contextually near the open (8:30 CT), not as a static level late in the session. [ONCE] (v215, [04:27])
- Value (volume profile / Power Bar value) over "the last few minutes, the last 5 minutes, 15 minutes" is what matters; not the all-day value area if price is "30 points away from value." [ONCE] (v215, [06:04])
- Night session (e-minis after midnight) explicitly usable with order flow — "a lot of the big trading firms and funds have night desks." Delta surge and multiple-imbalance setups work after midnight. [ONCE] (v216, [35:17])

**Market / instrument selection:**
- Ultra bonds: "great scalper's market," 4 ticks = ~$125, featured prominently. (v215, [19:18])
- Soybeans: "follows order flow really well"; "more millionaires than any other market" before mini S&Ps. Power Bar works on soybeans. (v215, [30:09])
- Mini Dow (YM): volatile; use lower power bar strength (10) + swing strength 1 to manage signal volume. (v215, [34:40])
- Apple stock: Power Bar works; 1-minute chart with 10/0 settings gives too many signals; 50/0 more suitable. (v215, [54:38])
- Euro/USD (6E-equivalent): 50/0 preferred settings. (v215, [57:45])
- CME Bitcoin: tradeable on 5-minute chart; micro contract too illiquid (2021). (v215, [1:07:48])
- "Futures provide enough opportunity; don't spread yourself thin." Focus over breadth. [ONCE] (v215, [1:10:49])

**Value as a filter:**
- Power Bar indicator is explicitly designed to trade "order flow around value" — the bar's value zone acts as the S/R and stop reference. (v215, [00:32])
- The concept of "recent value" (last 5–15 min) vs. day-start value — suggests using short-window volume profile as context rather than daily VAH/VAL only. [ONCE] (v215, [05:33])

**VWAP nuance:**
- Institutional use of VWAP = execution benchmark over a defined time window (e.g., 15 min), NOT as a static intraday support/resistance level. Warns retail traders misuse it. [ONCE] (v215, [04:27])

---

## O. Directly testable / measurable variables

- **Power bar strength parameter**: 0–100 scale; recommended range 10–85; 50 = midpoint / moderate. [REPEATED] (v215, [21:14])
- **Swing strength parameter**: 0 = disabled; 1 = minimum active; use with low power-bar-strength (e.g., 10) on volatile markets. (v215, [35:13])
- **Trade entry signal — "valid in number of bars"**: default 2; range 1–5; Mike uses 2; "I wouldn't go higher than five." (v215, [14:03])
- **Trade entry signal — "trade entry in ticks"**: default 2; can use 1 for slower markets. (v215, [14:33])
- **Imbalance ratio**: 4:1 (400%) as standard; 3:1, 5:1, 10:1 also used by different traders; size filter optional (Mike does not filter by volume himself). (v216, [15:58])
- **Multiple imbalances threshold**: 3 or more imbalances of same direction in one bar = setup trigger. [REPEATED] (v216, [26:24])
- **Delta surge pattern**: sequential increase across 2+ bars in same direction; e.g., -12, -33, -48 or +12, +51, +69 cited. No single-bar threshold given. [NEEDS-OPERATIONALIZATION] (v216, [34:47])
- **Stop**: 1 tick beyond Power Bar extreme (high or low). [REPEATED] (v215, [24:19])
- **Time stop**: 5–10 minutes on minute chart. [REPEATED] (v215, [25:16])
- **Follow-through**: 2 ticks over 2 bars (default). (v215, [14:03])
- **Power bar strength upper practical limit**: 75; "75 is about as high as I would go." (v215, [34:07])
- **Tick replay required**: NO for Power Bars indicator (explicitly noted). (v215, [06:57])
- **Bar close required for entry**: YES — never enter mid-bar. (v215, [41:07])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Orderflows Power Bars indicator**: runs on standard bar chart (not footprint), no tick replay required, NinjaTrader 8. Colors: cyan = bullish, magenta = bearish (user-configurable). (v215, [09:43])
- Parameters: `Power Bar Strength` (10–85 range practical), `Swing Strength` (0 = off, 1+ = on), `Trade Entry Signal` (enabled/disabled), `Trade Valid Bars` (default 2), `Trade Entry Ticks` (default 2). (v215, [11:14])
- Triangle signal: printed on bar N+1 or N+2 if price clears the threshold ticks; not painted on the signal bar itself — it appears after confirmation. No repaint after bar close implied. (v215, [40:11])
- License: last-name-based license key entered in NinjaTrader's indicator properties. (v215, [09:43])
- Data feed: works with Continuum and Kinetic (Rithmic-type) feeds; Coinbase feed for crypto (slower, not recommended for active trading). (v215, [52:35])
- **Orderflows Trader 3.0**: footprint chart with 17 pre-programmed order flow indicators; runs on NinjaTrader 8 only (not Sierra Chart, TradeStation). Includes value area tools, delta indicator, POC S/R tools. (v216, [39:16])
- Template: default template set up for e-mini 1-minute chart; user adjusts from there. (v216, [40:17])
- Power Bar indicator can be used on stocks (Apple) and forex (Euro/USD) via Kinetic data feed in NinjaTrader, not just futures. (v215, [52:35])
- For implementation of Power Bar follow-through filter: on bar close of signal bar, set a pending entry order 2 ticks beyond the bar extreme; fill within 2 bars = confirmed entry; if not filled within 2 bars, cancel. (v215, [40:11])

---

## Q. Notable verbatim quotes

1. "The power bar is my stop." (v215, [46:41]) — cleanest statement of the risk management rule.
2. "If you're just trading every signal blind, you're going to get chopped up. You're going to be in trades you shouldn't be taking." (v215, [15:31]) — on the necessity of the follow-through filter.
3. "Not advisable to trade the first few minutes of the cash open, cuz you get a lot of bars... all over the place." (v215, [31:45]) — context filter verbatim.
4. "If it's not making that move, you know, you move your stop to break even... you don't want it to come all the way back up and stop you out." (v215, [47:35]) — active trade management.
5. "The way you cut your losses short is by knowing market conditions have changed and getting out, right — it's not about having tight stops." (v216, [23:02]) — core philosophy on exits.
6. "When you see all three [positive delta + buying imbalances + rising POC] it doesn't get any more obvious." (v216, [23:33]) — A+ reversal confirmation trio.
7. "Just because you see bids and offers, no trade is happening until someone crosses that bid offer level." (v216, [08:50]) — foundational aggressive-buyer/seller definition.
8. "There's about 50 setups but when I say setups it's more of nuances — I don't see them all all day long." (v216, [24:36]) — calibrates expectations on setup frequency.
9. "Value is more important than price action — once you understand value, you understand what something is worth." (v215, [01:32]) — foundational framing for the Power Bar concept.
10. "On bonds, I'm happy to scalp 3 or 4 ticks at a time." (v215, [50:26]) — market-specific target calibration.

---

## R. Contradictions / nuances

1. **VWAP is NOT a retail S/R level**: Mike explicitly says big institutions use VWAP as an execution quality benchmark (fill vs. VWAP over a fixed window), not as support/resistance. Using it as a static intraday level is a "misconception." [ONCE] (v215, [05:02])
2. **Recent value ≠ all-day value**: "I'm not concerned with where value was at 9:00 in the morning when it's 2:00 in the afternoon." The Power Bar computes value over "the last few minutes, 5 to 15 minutes" — explicitly shorter-window than standard daily volume profile. Nuances the "value area" context filter from the digest. [ONCE] (v215, [05:33])
3. **Power Bar does NOT require footprint / tick replay**: The Power Bar indicator runs on a plain bar chart without tick replay — a deliberate design choice that distinguishes it from all his footprint-based tools. This is architecturally distinct from the Exhaustion model. [ONCE] (v215, [06:57])
4. **Multiple imbalances: first signal can fail with a one-tick new-high fakeout**: "the market came back up and made a new high by a tick before it fell over — that happens, that's trading." Doesn't invalidate the setup; second entry on the breakdown is the cleaner trade. Nuances the follow-through gate. [ONCE] (v216, [30:43])
5. **Zero delta has no special meaning**: "I've found it's just more coincidence than anything else — it could be the difference of one lot." Contradicts any model that treats zero-delta bars as S/R or as a specific signal. [ONCE] (v216, [32:28])
6. **Power bar strength is NOT about stop size**: a higher strength setting "doesn't necessarily mean it's going to always go on in that direction to infinity" — higher strength suits scalping immediate ticks, not catching big moves. The relationship between signal strength and target distance is flat, not positive. [ONCE] (v215, [34:07])
7. **Scaling into a trade via micros with averaged fill**: stop remains at the original Power Bar extreme even if you add at better prices during a pullback into the bar. Risk stays constant — the averaging does not widen the stop. [ONCE] (v215, [46:16])

---

## Coverage note

- v215 is rich for Power Bar indicator mechanics, parameter settings, follow-through filter logic, stop placement, and multi-market application (bonds, soybeans, YM, Apple, Forex, Bitcoin). Thin on footprint-level A+ reversal criteria — Power Bars are a bar-chart tool, not the footprint Exhaustion model.
- v216 is moderately rich for two core setups (multiple imbalances, delta surge) and the three-factor reversal confirmation framework (delta + imbalances + POC migration). It is an introductory/sales presentation, so definitions are clean but depth is limited versus dedicated teaching videos.
- No unparseable content; audio quality throughout was good.
