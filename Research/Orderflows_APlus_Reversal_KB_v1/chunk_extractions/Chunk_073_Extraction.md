# Chunk 073 Extraction
- Source chunk: Chunk_073_Orderflows_Transcripts.md
- Transcripts covered:
  - v224 — Orderflows Delta Scalper Delta Analysis Tool (2021-10-29)
  - v225 — Part 1 Flowedges Identify Market Moving Order Flow On Plain Charts (2021-11-12)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta Surge (bullish)** — progressive strengthening of positive delta through successive bars (e.g., -91, -18, -40 … then 61, 135, 248); market was showing failed aggression on one side, then aggressive buying takes over; price breaks out of sideways. (v224, [24:52]–[27:23])
- **Delta Surge (bearish / inverse delta surge)** — progressive weakening of positive delta at new highs (333 → 364 → 166 → 34 → negative); signals exhaustion of buying, market reverses lower. (v224, [30:24]–[31:02])
- **Absorption at swing high/low** — small or near-zero delta at a swing extreme despite decent volume; passive seller (or buyer) is absorbing aggressive flow without moving price. (v224, [20:47]–[23:14])
- **Delta Scalper signal** — proprietary indicator signal: rises/declines in delta placed in context of recent market activity (look-back bars); identifies momentum shifts or turning points depending on settings. Bullish/bearish. (v224, [31:34]–[48:00])
- **Flow Edges signal** — second proprietary indicator; identifies where "value and balance" have been established in the order flow and price is beginning to move away; uses flow edge level (1–5) and swing strength (0–∞). Bullish/bearish. (v225, [02:52]–[03:23], [11:11]–[12:20])
- **Momentum mode (Flow Edges, swing=0)** — low flow-edge level + zero swing strength = pure momentum signals, frequent, suited to fast charts. (v225, [27:04]–[28:14])
- **Turning-point / reversal mode (Flow Edges, swing>0)** — adding swing strength filters for swing highs/lows; used to find reversals and turning points rather than momentum entries. (v225, [27:04]–[27:38])

---

## B. Tiering / grading language

- **"The best trades are the ones that happen right away"** — trades that move immediately (within 1–2 bars in the direction of the signal) are the highest-quality; the Trade Entry Signal / Follow-Through filter is specifically designed to keep only those trades. (v224, [42:50]–[43:16]; v225, [15:20]–[16:24])
- **"Nice move"** — used repeatedly for clean directional runs that follow a signal without much drawdown; implies a quality trade but not necessarily the top tier. (v224, [36:52], [37:20]; v225, [33:43], [34:14])
- **"Small stop out" / "get stopped out here fine"** — routine occurrence; not equivalent to invalidation of the model. Acceptable loss. (v224, [39:01]; v225, [35:37]–[36:44])
- **"A lot of signals" / "noise"** — low filter settings (flow edge level=1, swing=0) on volatile markets like NQ/MNQ generate too many signals, many of which are low quality; described as problematic. (v225, [44:53]–[45:31])
- **Cleaner/stricter settings** — higher look-back, higher flow edge level, or higher swing strength = fewer but presumably higher-quality signals; explicitly linked to better trade selection. (v224, [59:38]–[1:01:24]; v225, [18:11]–[18:46])
- **"Beautiful move"** — used for ideal multi-bar directional runs; the highest compliment for a trade outcome. (v224, [40:03]; v225, [34:14])
- **"Crappy"** — overnight/Asian session bars that are too small or flat to generate meaningful order flow analysis; not tradeable. (v225, [59:40])

---

## C. Order-flow story & psychology per setup

- **Delta surge (bullish)**: Sellers press the market but can't sustain; sellers who were short must cover as the market fails to follow their aggression. Aggressive buyers step in and reward their effort; former sellers become new buyers = cascade. (v224, [27:23]–[27:51])
- **Absorption at swing extreme**: A large passive seller (or buyer) sits hidden on the offer (or bid) and absorbs all aggressive buying (or selling) at the extreme, keeping delta small despite decent volume. When the absorbing entity finishes or the aggressive side exhausts, price drops (or rallies) sharply. "Hiding their intentions" by keeping delta directionally small. (v224, [22:22]–[23:41])
- **Inverse delta surge / exhaustion at highs**: FOMO buyers pile in as market rallies; delta peaks and then progressively weakens at each new high (364→166→34). The last buyer has bought; no new fuel; market reverses. (v224, [29:50]–[31:02])
- **Flow Edges turning point**: Market establishes value/balance; when order flow shifts away from that balance, a directional move begins. Other time-frame (OTF) traders — funds holding multi-day positions — are the force behind meaningful moves, not intraday scalpers. (v225, [04:34]–[05:41])
- **Follow-through confirmation logic**: A signal without follow-through order flow means "everyone else has other ideas"; a big institutional buyer can override any bearish analysis if they simply step in and buy. The trade entry signal ensures consensus. (v225, [22:40]–[26:29])

---

## D. Exhaustion clues

- Progressive weakening of positive delta at new highs (delta divergence): 333 → 364 → 166 → 34 → negative, while price continues to make new highs. Final bar shows weakest delta of the sequence. [REPEATED] (v224, [30:24]–[31:02])
- Declining negative delta during a sell-off: aggressive selling is weakening even as price still ticks lower; market forms a bottom, sets up for bounce. [REPEATED] (v224, [28:30]–[29:50])
- At a swing high: small/neutral absolute delta at decent volume = exhaustion of aggressive buying (someone absorbing); quick reversal bar with strong negative delta often absent. [ONCE] (v224, [21:22]–[22:22])
- Doji bar with negative delta that cannot push price lower: bar opens/closes same price, goes only 1 tick lower despite negative delta — buying stepping up. [ONCE] (v224, [26:01]–[26:55])

---

## E. Absorption clues

- Small directional delta at a swing extreme despite normal-to-above-normal volume; passive entity absorbing all aggressive flow while keeping price pinned. (v224, [20:47]–[23:14]) [REPEATED]
- Market going up but negative delta (absorption of selling by passive buyer): big buyer saying "sell me everything you have." (v224, [16:01]–[16:29]) [REPEATED concept]
- Positive delta at a high followed by market drop: "bearish sign" — aggressive buying was absorbed by passive sellers; the delta looks positive because the buying was absorbed, not because it moved price. (v224, [19:43]–[20:13]) [REPEATED — reinforces digest nuance]

---

## F. Stacked imbalance ideas

— nothing in this chunk —

---

## G. Delta / delta-divergence ideas

- **Bar delta** = (volume at ask) − (volume at bid); always per-bar arithmetic, not a formula secret. (v224, [03:58]–[04:27]) [REPEATED]
- **Max delta** = strongest positive delta reading within a single bar (the peak of aggressive buying in that bar). Min delta = most negative reading within the bar (peak of aggressive selling). These are intrabar extremes, not the close delta. (v224, [06:44]–[07:21]) [ONCE — adds precision to digest]
- **Cumulative delta** = running sum of bar deltas from session open (analogous to cumulative volume); can be positive or negative. (v224, [05:31]–[06:07]) [REPEATED]
- **Delta of zero** = statistical coincidence, not a tradeable signal by itself; found no edge in zero-delta bars vs. non-zero. (v224, [10:18]–[10:49]) [ONCE]
- **Delta in context of market structure**: small absolute delta on its own is neutral; the same small delta AT A SWING HIGH/LOW becomes analytically significant. Location transforms interpretation. (v224, [09:15]–[09:47], [23:14]–[23:41]) [REPEATED — reinforces location-first principle]
- **Delta surge = progressive delta acceleration**: not a single big bar, but a sequence of bars where delta is getting stronger bar-by-bar, aligning with price momentum. Inverse delta surge = progressive weakening. (v224, [24:52]–[26:01]) [ONCE — adds sequential/pattern precision]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- Delta surge that fails: market produces a burst of positive or negative delta, price attempts to move, but the *next* bar does nothing (doji) or reverses — "delta surge but no follow-through." This is the failed breakout in delta terms; wait for the *follow-through* confirmation before acting. (v224, [26:01]–[27:23]) [ONCE]
- Flow Edges signal with no follow-through order flow: order flow conditions met but the next 2 bars don't move 2 ticks in the signal direction → no trade signal printed; bars colored but no triangle. This filter removes false breakouts at the signal level. (v225, [13:01]–[14:21]) [REPEATED concept via different indicator]

---

## I. Trapped-trader ideas

- Sellers trapped at the base of a delta surge: they sold into the move down, got no reward, and now must cover as aggressive buying takes over. Their covering adds fuel to the reversal. (v224, [27:23]–[27:51]) [SPECULATIVE — implied but stated]
- "Everyone is selling... but if you watch the delta, the selling is getting weaker" — bottom fishers / potential longs are the opposite of trapped sellers; they recognize the trap early. (v224, [28:30]–[29:24]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

- **Delta Scalper**: signal bar conditions met AND market moves ≥2 ticks in signal direction over next ≤2 bars → triangle prints; enter on/after that confirmation bar (not on signal bar). Customizable: 1 tick / 1 bar for immediate confirmation preference. (v224, [41:54]–[43:16]) [REPEATED concept; exact defaults confirmed]
- **Flow Edges**: flow edge conditions met AND market moves ≥2 ticks in signal direction over next ≤2 bars → triangle prints. Same two-tick / two-bar default. (v225, [12:20]–[14:21]) [ONCE — parallel to Delta Scalper logic]
- **Delta surge entry (manual)**: see positive delta acceleration; place buy stop above the current bar's high (e.g., "bar high is 88, if it trades 90, drop a buy stop"); filled on breakout of the signal bar's extreme. (v224, [26:55]–[27:23]) [ONCE]
- **Flow Edges trade entry signal disabled**: signal prints immediately when order flow conditions are met (no follow-through required); more trades, includes lower quality. Explicitly described as inferior. (v225, [15:20]–[15:56]) [REPEATED]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Market must move ≥2 ticks in the signal direction within the next ≤2 bars for the Delta Scalper or Flow Edges trade entry signal to fire. This IS the confirmation gate — if it doesn't move, no signal. (v224, [41:54]–[42:50]; v225, [12:20]–[14:21]) [REPEATED]
- "The best trades are the ones that happen right away" — fast, immediate follow-through is the A+ confirmation; slow or non-existent follow-through = skip or exit quickly. (v224, [42:50]–[43:16]; v225, [14:51]–[15:20]) [REPEATED — strongest verbal confirmation of digest item]
- For a delta surge entry: effort (delta acceleration) should immediately be followed by reward (price breaks the extreme of the signal bar). If effort appears but price goes sideways (doji), wait — it may still come but it's lower quality. (v224, [26:01]–[27:23]) [ONCE]
- Zone (colored box) should stay intact: if price trades back *into* the signal zone, the trade is breaking down — look for exit. (v224, [50:42]–[51:11]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Price trades back into or through the signal zone (Delta Scalper's colored box) — "all bets are off." (v224, [50:42]–[51:11]) [ONCE — specific visual invalidation rule]
- No follow-through order flow within the specified bars/ticks window after the signal bar → trade entry signal never fires → thesis rejected at the entry stage. (v224, [43:49]–[44:27]; v225, [13:41]–[14:21]) [REPEATED]
- Order flow reverses to the other side within 2 bars after a bearish signal: "order flow came back bullish two bars later" — confirms trade should not have been taken (or must be exited immediately). (v225, [23:46]–[24:21]) [ONCE]
- Doji bar with decent volume but no directional movement when one was expected: delta may be strong but price not confirming — do not force direction. (v224, [25:25]–[26:29]) [ONCE]

---

## M. Stop / risk / target / trade management

- Stop: implied to be just beyond the signal zone (the colored box); if price trades back above (for a short) or below (for a long) the zone, exit. (v224, [50:42]–[51:11]) [ONCE — zone acts as stop guide]
- Adding on (pyramiding): when market is moving in your favor and another signal fires in the same direction, load up another unit. e.g., short at 62.5, add at 59-60 area on second bearish signal during same downtrend. Not for every trader; requires the market to keep going in favor. (v225, [47:08]–[47:40]) [ONCE]
- "Every trade starts with a scalp" / trade intraday / short-term: Delta Scalper is designed for intraday scalp-to-swing; not a position-trade tool. (v224, [32:26]–[32:53]) [ONCE]
- No universal target; targets discretionary; the indicator gives you entry, management is your responsibility. (v224, [36:52]–[37:20]) [REPEATED]
- Trail stop if in a strong run: if adding on, trail to protect gains; when market shows sign of coming back, exit both units. (v225, [47:40]–[48:12]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Session preference**: Main/US session preferred for two-and-two strength settings; overnight/Asian session is quieter, use lower strength (1) with swing strength for turning points. European session (01:00–07:00 CT approx.) has moves but is calmer. (v225, [52:46]–[56:08]) [ONCE — specific session/setting pairing is NEW detail]
- **Asian session (approx. midnight–07:00 CT)**: historically quiet, small bars, difficult; best approached with swing-strength filter for turning points, not momentum; 30-second charts too fast for some markets. (v225, [53:21]–[55:34]) [ONCE]
- **Market-type filter**: Commodity/physically-settled markets (crude oil, wheat, soybeans, bonds) have more "real" order flow (users, hedgers); equity indices (S&P, NQ, YM) are more purely speculative and can be noisier/more volatile. Interest rate markets (10yr, 5yr, Bunds, Ultra Bonds) need larger time frames (2-min minimum for ultra bonds/bunds) because 1-min bars are too small to generate meaningful range for order flow analysis. (v224, [1:12:16]–[1:13:56]; v225, [31:24]–[33:05], [51:23]–[52:04]) [ONCE — specific 2-min minimum for rates markets]
- **Volatility / market activity threshold for Flow Edges**: flat-line markets (price trades one tick range repeatedly) provide insufficient order flow information; Flow Edges needs range expansion per bar to function. On 10yr notes, even 2-min may be borderline; go to next increment. (v225, [30:46]–[32:30]) [ONCE]
- **NQ/MNQ specific**: volatile market; base settings produce excessive noise during US session; use higher flow edge level (3–5) or swing strength (9+) to filter. At night/Asian session, level 1 + swing 3 is Mike's stated preference. (v225, [44:53]–[46:08], [52:46]–[55:05]) [ONCE]
- **Delta = zero bars**: no informational edge; statistical coincidence; not a filter criterion per se. (v224, [10:18]–[10:49]) [ONCE]
- **OTF (other time frame) traders** drive meaningful moves, not intraday scalpers; Flow Edges is designed to identify when OTF participants are establishing or abandoning value. (v225, [04:34]–[05:41]) [ONCE — conceptual reinforcement]
- **Chart type**: Time, tick, and volume charts all usable; grain markets (wheat) work well on 25–50 tick; NQ on 30-second only if willing to be very active; 1-minute is a standard baseline for most markets. (v225, [38:19]–[41:56]) [REPEATED]

---

## O. Directly testable / measurable variables

- **Two-tick / two-bar follow-through**: default confirmation gate for both Delta Scalper and Flow Edges; configurable 1–5 ticks, 1–5 bars. Test: does requiring ≥2 ticks over ≤2 bars improve win rate / reduce loss trades vs. no filter? (v224, [41:54]–[42:50]) [REPEATED — explicit default confirmed again]
- **Delta Scalper strength levels**: 1 = base (double per level increase; level 3 = 4x level 1); recommended range 1–3; above 3 risks catching burst institutional orders. Test: level 1 vs. 2 vs. 3 on each market. NEEDS-OPERATIONALIZATION (exact formula undisclosed). (v224, [48:40]–[50:12])
- **Look-back bars (Delta Scalper)**: 0 = every signal (momentum mode); 1, 3, 5, 7 suggested; 9 also used; max useful ~10. Higher = fewer, more selective signals. Test: look-back sweep vs. performance. (v224, [48:11]–[48:40], [1:23:55]–[1:25:26])
- **Flow Edge level**: 1 (base/most signals) to 5 (fewest, strongest); 1, 3, 5 are primary levels; 2 and 4 are midpoints. Test: level sweep per market and session. (v225, [11:49]–[12:20])
- **Swing strength (Flow Edges)**: 0 = momentum mode (most signals); 1, 3, 5, 9 are preferred values; some traders use 20–25; no meaningful difference between 9 and 10 in testing. Higher = fewer, more turning-point-focused signals. Test: sweep 0, 1, 3, 5, 9. (v225, [20:04]–[20:39], [27:38]–[28:14])
- **Max delta / min delta intrabar**: measurable extremes within a bar; max delta shows peak aggressive buying in the bar, min delta shows peak aggressive selling. Both differ from the bar's close delta. NEEDS-OPERATIONALIZATION as a filter condition. (v224, [06:44]–[07:21])
- **Delta surge sequence**: operationalize as N consecutive bars where |delta| is increasing in the direction of trend, with the final bar producing a signal. Test: 2-bar, 3-bar sequences. NEEDS-OPERATIONALIZATION. (v224, [24:16]–[25:25])
- **Inverse delta surge (exhaustion)**: operationalize as N consecutive bars making new price highs/lows while delta monotonically decreases in the trend direction; final bar has weakest delta. Test: 3-bar sequence ending with weakest delta as reversal signal. NEEDS-OPERATIONALIZATION. (v224, [30:24]–[31:02])
- **Minimum bar range for interest rate markets (Flow Edges)**: 1-minute bars on 10yr/5yr/Bunds may be flat (1-tick range); indicator may produce no signal. Minimum useful time frame appears to be 2-minute for these markets. NEEDS-OPERATIONALIZATION (exact range threshold not stated). (v225, [31:24]–[33:05])
- **Signal zone (Delta Scalper)**: colored box drawn at signal bar; height = 2 ticks (default, adjustable); opacity = 25 (default). If price re-enters zone = invalidation trigger. Testable as a stop rule. (v224, [50:12]–[51:11])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Delta Scalper (NT8 indicator)**: reads bid/ask volume tick by tick from footprint data on a normal bar chart; places bid/ask delta in context of recent N bars (look-back); fires buy/sell triangle when delta strength threshold met; optional Trade Entry Signal layer that requires 2-tick/2-bar follow-through before printing — no repaint after bar close. (v224, [31:34]–[44:55])
- **Trade Entry Signal / Follow-Through Gate**: separate sub-module in Delta Scalper and Flow Edges; configurable ticks (1–5) and bars (1–5); when enabled, signal only prints after follow-through confirmed — trades that already happened are never retroactively removed. Critical anti-repaint guarantee. (v224, [41:54]–[44:55]; v225, [12:20]–[16:24])
- **Signal zone (box)**: drawn from signal bar at configurable height (ticks) and opacity; serves as visual stop / invalidation zone. If price re-enters zone, trade is breaking down. (v224, [50:12]–[51:43])
- **Tick Replay requirement**: Delta Scalper requires Tick Replay enabled in NT8 to render historical bars correctly (uses tick-level data, not just OHLCV). Without tick replay, historical signals will not appear. (v224, [1:19:16]–[1:21:04])
- **Flow Edges (NT8 indicator)**: separate product; identifies balance/value areas from order flow on any bar-chart type; signal fired when price moves away from value; flow edge level 1–5 + swing strength 0–∞; same 2-tick/2-bar trade entry signal architecture as Delta Scalper. (v225, [01:08]–[03:23], [11:11]–[15:56])
- **Rendering/calculation note**: Delta Scalper calculates on each tick (intrabar); signal can change while bar is forming; once bar closes, final state is locked (no repaint). The trade entry signal layer is only printed after post-bar follow-through is confirmed. (v224, [44:27]–[44:55])
- **Duplicate-tab approach**: Mike's workflow is to set up one chart perfectly (settings, tick replay, indicator) then "duplicate in new tab" in NT8 rather than reconfiguring each new chart from scratch. (v224, [1:21:04]–[1:21:30])
- **Free version of NT8 compatibility**: Delta Scalper runs on NT8 free version; requires live data feed separately. (v224, [1:21:30]–[1:22:33])
- **"Turns" indicator**: separate range-bound / support-resistance indicator mentioned briefly; different architecture from Delta Scalper/Flow Edges; not covered in detail. (v225, [1:27:43]–[1:28:17]) [ONCE — new product name]

---

## Q. Notable verbatim quotes

1. "Not every delta you see matters. And especially sometimes there's deltas that are kind of neutral in the market... you know, depending on where the bar is coming in market structure, I would treat it as a sort of neutral." (v224, [09:15]–[09:47])

2. "When you start getting up at swing highs or swing lows, that's when you should be paying attention because that's where markets are going to start to turn, you know, after a swing high or after a swing low." (v224, [23:14]–[23:41])

3. "The best trades are the ones that happen right away." (v224, [42:50]; v225, [14:51])

4. "Often what doesn't happen is just as important as what happens." — in context of a failed delta surge at a potential sell-off level. (v224, [25:25])

5. "You can do all the analysis in the world and think that okay yeah the market's got to sell off based on my analysis... once you get into the position it doesn't matter what you think anymore, right? You're sort of you can't control it, it's everybody else that's basically now controlling your outlook of the market." (v225, [23:11]–[23:46])

6. "Flow edges... helps traders know when a market has found value and balance and is beginning to move away from balance." (v225, [02:52]–[03:23])

7. "If you're someone that wants to try and find reversals in the market so to speak, use the swing strength. You know, put a level in there. You really don't need to go over 20 but you know personally I use one three five and nine." (v225, [27:04]–[27:38])

8. "I found is okay yeah I've got something in the order flow that's bearish... but if the market doesn't start moving in that direction then there's no follow-through order flow... that's why I use the trade entry signal." (v225, [23:46]–[24:21])

9. "Generally markets go up on positive delta, markets go down on negative delta. Now, there's going to be instances where a market is going up and you have negative delta. And you're going to scratch your head... Well, the reason for that is a simple one. There's absorption in the market." (v224, [15:36]–[16:29])

---

## R. Contradictions / nuances

- **Positive delta AT A HIGH is bearish, not bullish**: a bar at a swing high with positive delta and decent volume but no price advance = absorption; the market dropped after. "This is actually a bearish sign in the market." (v224, [19:43]–[20:13]) [Reinforces known nuance but stated with unusual directness here]
- **Small/neutral delta is context-dependent**: the same small delta that means nothing in mid-range becomes highly significant at a swing extreme. No universal threshold — location transforms meaning. (v224, [09:15]–[09:47], [23:14]–[23:41])
- **"Same settings every market" is qualified further**: while the architecture is the same, the *strength and look-back settings must be adjusted per market* — NQ needs higher filtering, interest rates need bigger time frames, grains work well on specific tick counts. This contradicts a naive reading of "same settings." (v224, [55:22]–[55:50]; v225, [17:36]–[18:46])
- **Look-back / swing strength = 0 is NOT the same as "no filter"**: zero look-back means "give me every signal the conditions trigger" = momentum mode; it is still detecting delta changes in context of the bar, just without comparing to prior bars. Some traders prefer this. (v224, [56:47]–[57:18]; v225, [27:04]–[28:14])
- **Delta Scalper strength > 3 is counterproductive**: above level 3, signals become too rare AND risk catching one-off institutional burst orders that are not indicative of market direction. Level 2 = double level 1; level 3 = four times level 1 (exponential, not linear). (v224, [48:40]–[49:40])
- **1-minute charts on interest rate markets are often unusable for Flow Edges**: flat/single-price bars contain insufficient order-flow information; minimum meaningful resolution appears to be 2-minute for ultra bonds, bunds, and 10yr notes. (v225, [31:24]–[33:05])
- **Asian session is not a no-trade zone, but requires setting adjustment**: Mike trades NQ, mini Dow, Russell, and crude oil in Asian hours with appropriate settings (Flow Edges level 1, swing strength 3 for turning points). The "avoid overnight" filter in the digest is qualified — it is "use different settings" not "don't trade." (v225, [52:46]–[57:39])

---

## Coverage note

v224 (Delta Scalper presentation) is the richer of the two for model-relevant content: detailed delta mechanics, absorption identification, delta surge as setup, the follow-through confirmation principle, and Delta Scalper indicator implementation specifics. v225 (Flow Edges Part 1) is moderately rich on indicator settings, session/time context filters, and the distinction between momentum mode and reversal/swing mode, but is primarily a product walkthrough. Both together add useful specifics around confirmation gates, indicator parameter guidance, and session-specific context filters not previously detailed in the digest.
