# Chunk 067 Extraction
- Source chunk: Chunk_067_Orderflows_Transcripts.md
- Transcripts covered:
  - v208 — Orderflows Flowshifts & Markers How To Training (2021-03-27)
  - v209 — How To Easily Understand Order Flow For Better Trading Results (2021-04-16)
  - v210 — How To Enable Tick Replay On NinjaTrader 8 (2021-04-19)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Divergence + ratio trade** (bullish/bearish): price at HOD/LOD with negative/positive delta AND a ratio print signaling exhaustion. Described as "one of my bread and butter trades" and "my favorite." Occurs "most days at least once or twice." (v209, "How To Easily Understand Order Flow", [38:00]) [REPEATED]

- **Absorption at swing low / value-area support** (bullish): heavy sell imbalance at a low (e.g., 196 vs 41) where a passive buyer absorbs all aggressive selling; POC sits at the low; price stops and reverses. (v209, [21:07]) [REPEATED]

- **Selling imbalance cluster at HOD** (bearish): multiple consecutive selling imbalances (7–8 counted) at or near the high of the day, combined with negative delta bars, preceding a sell-off. (v209, [27:04]) [REPEATED]

- **Buying imbalance cluster at LOD + delta flip** (bullish): multiple consecutive buying imbalances (5–6 in a bar, or 6 across consecutive bars) at or near LOD, combined with delta turning from large negative toward positive, preceding a rally. (v209, [24:26]) [REPEATED]

- **FlowShifts signal** (bullish/bearish): Mike's newer indicator (released ~March 2021) that reads different/additional order-flow data points and plots buy/sell signals; can be automated via Markers. Settings for YM 1-min: all detection volatile/normal/low volume, look-back 1, bar delta confirmation enabled, balance strength 1, balance points 2. (v208, [45:40]) [ONCE]

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **"Bread and butter trade"**: divergence + ratio at HOD/LOD. Explicitly "one of my bread and butter trades" — highest-frequency, reliable category. (v209, [38:00]) [REPEATED]

- **"Beautiful"**: used to describe a large drop bar followed by buying imbalances accumulating at the low — "that beautiful bar down." (v209, [30:43]) [ONCE]

- **"Not always crystal clear"**: absorption/support clues "don't always get those crystal clear examples" — implies only some absorption setups are high-grade, rest are marginal or ambiguous. (v209, [23:55]) [ONCE]

- **"Great trade to look at"**: divergence + ratio at HOD/LOD — explicitly graded as "great" and expected to occur "most days at least once or twice." (v209, [38:51]) [ONCE]

- **What moves a setup up a tier**: ratio print appearing on the second (not first) test of HOD/LOD combined with delta divergence. First test may not produce a ratio; second test that does = high-grade. (v209, [38:00]) [ONCE]

- **What moves a setup down a tier / skip**: buying imbalances forming at a low with no follow-through on the very next bar — "not getting the follow through" makes it not yet actionable even if imbalances are there. (v209, [24:26]) [ONCE]

---

## C. Order-flow story & psychology per setup

- **Absorption at low**: "a buyer here absorbing all the aggressive selling" — passive large buyer holds a price while aggressive sellers keep hitting the bid; POC sits at the extreme; when aggressive sellers exhaust, price reverts. "Yeah, sure, you want to sell some more? I'll buy it." (v209, [21:36]) [REPEATED]

- **Divergence at HOD**: "the last buyer has bought" implicit — aggressive buyers have been pushing price up (positive delta, buying imbalances on the way up) but by the time HOD is reached, every bar shows negative delta; the buyers who drove price here have become exhausted sellers, or new sellers are absorbing the remaining buy flow. (v209, [33:54]) [REPEATED]

- **Selling imbalance cluster at HOD**: "aggressive selling up here near the high" — sellers are comfortable selling at these levels, not waiting for a pullback; the supply is overwhelming residual buy demand. (v209, [34:22]) [REPEATED]

- **Rally anatomy**: to sustain a rally, "you're going to need to string together bars with strong positive delta"; POCs must be consecutively higher; buying imbalances should appear on the way up. (v209, [25:59]) [REPEATED]

- **Aggressive vs. passive framing**: aggressive buyers lift the best offer and take the next; aggressive sellers sell into the best bid and look for the next bid. The direction of price depends entirely on who is being aggressive. (v209, [08:52], [18:13]) [REPEATED]

---

## D. Exhaustion clues

- **Ratio print appearing on second (not first) test**: at HOD first time "there wasn't" a ratio; second time at identical HOD "based on the order flow in this bar is telling you there's price exhaustion." The ratio only fires when the volume pattern inside the bar meets the exhaustion threshold. (v209, [38:00]) [REPEATED]

- **Delta collapsing at extreme**: on a sell-off, large negative delta (−1200, −1500, −3500) then shrinks to (−118, −500, −257) as price approaches LOD — "selling weakening in terms of the negative delta…tends to get smaller." (v209, [25:59]) [REPEATED]

- **POC clustering / non-progression at extreme**: at HOD, POCs "migrate a bit higher…kind of mixed…then they drop off lower" — stagnation of POC progression signals exhaustion of upward aggression. (v209, [34:47]) [ONCE]

- **Negative delta on green bars**: a green candle with large negative delta ("big negative delta") signals hidden selling within an apparent upbar — a warning of weakness / exhaustion of buy aggression. (v209, [13:40]) [REPEATED]

---

## E. Absorption clues

- **Heavy sell imbalance at a low where price stops**: 196 vs 41 sell imbalance at the LOD — normally bearish, but context is "a buyer that's absorbing all the aggressive selling." POC sits at the low of the bar. Price does not break lower despite heavy aggressor selling. (v209, [21:07]) [REPEATED]

- **Second test with lower imbalance size but same price hold**: after the 196v41 example, market comes back down and sees 63v21 — a smaller imbalance but price still holds, confirming the absorption is real and not a fluke. (v209, [21:36]) [ONCE]

- **"Think outside the box"**: high sell-side imbalance at a low does NOT automatically mean bearish; check the context — is price holding? is there a POC at the low? That's absorption. (v209, [21:07]) [REPEATED]

---

## F. Stacked imbalance ideas

- **Multiple buying imbalances within a single bar** at low: 5–6 buying imbalances in one bar described as confirmation of aggressive buying accumulation at the low. "You've got five buying imbalances in this bar…you see the delta." (v209, [31:33]) [REPEATED]

- **Multiple selling imbalances in single bar at high**: 5 selling imbalances in one bar at HOD, followed by a bar with 3 more = signal that supply is overwhelming. (v209, [34:22]) [REPEATED]

- **Count matters — more is better**: 7–8 selling imbalances across consecutive bars before a big red bar with 3 more = high-conviction bearish. Single imbalances are "normal order flow." (v209, [27:04]) [REPEATED]

- **Sequential imbalances on a directional move**: on a strong sell-off, selling imbalances appear consecutively; on a strong rally, buying imbalances appear consecutively. This directionality of imbalances is a confirmation of the move, not a reversal signal. (v209, [18:13]) [REPEATED]

---

## G. Delta / delta-divergence ideas

- **Positive delta at LOD = bullish divergence**: "if you make a new or equal low, and you've got positive delta…you've got buyers coming into the market…that's a divergence in the order flow." (v209, [31:33]) [REPEATED]

- **Negative delta at HOD = bearish divergence**: "every bar up here [at HOD] it's got negative delta…you got aggressive selling at the high of the day." (v209, [34:47]) [REPEATED]

- **Delta size as conviction gauge**: during a strong directional move, look for large absolute delta (−3500, +1271); "small" delta treated as neutral (±22, ±135, ±16 explicitly called neutral/small). NEEDS-OPERATIONALIZATION for precise neutral threshold, though ±50 cited elsewhere. (v209, [27:04]) [REPEATED]

- **"String together bars with strong positive delta"**: for a rally to begin and sustain, consecutive positive delta bars are required — not just one. Lone positive delta bar within a negative flow is not a reversal signal. (v209, [25:59]) [ONCE]

- **Delta confirmation on FlowShifts**: "bar delta confirmation" is a toggle in FlowShifts settings — when enabled, it adds delta agreement as a filter for signals. Default setting for YM 1-min chart uses this. (v208, [46:15]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Buying imbalances at LOD with no follow-through bar = premature**: market showed 1-2-3 buying imbalances, "but then this next bar, there's no follow through…and obviously you got the negative delta." Market then continued lower before the real reversal. Lesson: wait for follow-through, not just the imbalance pattern. (v209, [24:26]) [ONCE]

- **Breakout chasers getting trapped**: "a lot of traders will trade this like…waiting for it to break out before I get long. You buy that breakout, then it sells off another 20/25 ticks before it goes back up." Order flow reader enters during the base at lower prices; breakout trader gets trapped. (v209, [22:34]) [REPEATED]

---

## I. Trapped-trader ideas

- **Breakout buyers trapped**: traders who buy the breakout above prior high get immediately sold off 20–25 ticks. The order flow reader is already long from the absorption zone below. (v209, [22:34]) [REPEATED]

- **Sellers stuck in a rally**: on a sustained rally, aggressive sellers hit the bid at every level but price keeps moving up because buyers keep lifting the next offer ("aggressive buyers buy from passive sellers"). Sellers who are short must cover as POCs move higher. (v209, [18:13]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

- **Ratio print on second test of HOD/LOD**: ratio number appears (blue or black number above/below bar) coinciding with delta divergence on the second approach to the extreme. This is the explicit trigger for the bread-and-butter divergence+ratio trade. (v209, [38:00]) [REPEATED]

- **FlowShifts buy/sell signal bar close**: FlowShifts plots a buy/sell signal; when used with Markers automation, signal fires at bar close (or each tick if configured that way). (v208, [45:40]) [ONCE]

- **Volume/absorption confirmation at support**: once absorption is confirmed (POC at low, holding on retests, buying imbalances accumulating), entry is taken as price is "stopping" rather than waiting for breakout above prior high. (v209, [22:34]) [REPEATED]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Immediate directional POC shift**: after entry, POCs should begin moving in the direction of the trade — "higher points of control" on a long, "lower points of control" on a short. Multiple consecutive POC moves in the same direction = strong confirmation. (v209, [25:32]) [REPEATED]

- **Delta agreeing**: "to start rallying, you're going to need to string together bars with strong positive delta." After entering long at LOD, see 400, 1200, 600 positive delta bars confirm the move. (v209, [25:59]) [REPEATED]

- **Imbalances in trade direction**: buying imbalances should appear on the way up after a long entry; selling imbalances on the way down after a short. (v209, [29:01]) [REPEATED]

- **Market reads order flow in real time**: "if the trade's not working out I'm going to get out early at a smaller loss rather than let it go and stop me out." If bullish order flow is not materializing after entry, exit before full stop. (v208, [05:28]) [REPEATED]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Negative delta immediately after long entry**: "I'm long but all of a sudden the order flow that's coming in is bearish — then you get out." (v208, [06:22]) [REPEATED]

- **Selling imbalances reappearing at LOD after long entry**: if, after entering long, selling imbalances dominate and buying imbalances disappear, the absorption thesis is broken. (v209, [31:08]) [ONCE]

- **"Double top" price action if trade went to TP once then pulled back**: "chances are it's going to put in a double top and come down and stop you out." If price goes to TP once, pulls back to near entry, makes a second move toward TP but fails to reach it — exit rather than waiting for the third attempt. (v208, [07:23]) [ONCE]

- **Failed follow-through at LOD**: buying imbalances form but next bar has no follow-through and delta is still negative — do NOT enter yet; wait for genuine follow-through. (v209, [24:26]) [ONCE]

---

## M. Stop / risk / target / trade management

- **Stop placement**: not explicitly re-stated in this chunk beyond "25 ticks stop" example in Markers demo (YM 1-min chart ATM: 25 ticks stop, 85 ticks target). These appear to be ATM demo parameters, not universal rules. (v208, [48:35]) [ONCE]

- **Time stop / active management**: "if you find yourself underwater for the next 10 minutes [on a 1-minute chart] chances are it's not going to work out." Active exit before time stop is preferred over waiting. (v208, [06:52]) [REPEATED]

- **"Don't let it be binary"**: "you could get out at break even, plus one, minus one, plus two, minus two…you can get out of a trade at any point." Active discretionary management based on live order flow. (v208, [06:22]) [REPEATED]

- **Target management — double-top risk**: if price attempts TP twice and fails on the second attempt, do not hold for a third; the thesis is weakening. (v208, [07:23]) [ONCE]

- **Daily P&L guard (automation)**: in Markers setup, set daily profit/loss limits (±500 for YM example) — system stops trading when either limit is hit. (v208, [44:04]) [ONCE]

- **"Traces per side" setting in Markers**: limits how many trades the automation takes per direction; Mike uses 0 (first signal only). (v208, [1:05:21]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **HOD/LOD as primary reversal context**: "your high of the day…there's aggressive selling coming in" and "you're at your low of the day, and all of a sudden buyers are coming in." HOD/LOD explicitly named as the key location for reversal trades. (v209, [34:47], [31:33]) [REPEATED]

- **Night session use-case for automation**: Markers can be run fully automated overnight/night session because volume is lower, human focus is harder to maintain, and signals are fewer but tradable. (v208, [04:06]) [ONCE]

- **"Unchanged" / open area**: not mentioned in this chunk.

- **Market selection by volume/liquidity**: Mike explicitly mentions reading order flow "cleanest" in high-volume markets; references ES/E-mini, MNQ (20 range chart), crude, gold as instruments he shows. (v209, [23:55], [32:28]) [REPEATED]

- **POC as market-generated support/resistance**: "market generated support…market generated resistance" from POC levels. Trade FROM these levels, not just around price. (v209, [39:19]) [REPEATED]

- **Imbalance threshold flexibility**: "industry standard 4:1, but a lot of traders use 3:1 or 5:1…I use 3:1 a lot of times…some traders use almost 10:1 (Fibonacci — 987) — 10:1 basically." Confirms the per-user and per-market adjustability. (v209, [21:36]) [REPEATED]

---

## O. Directly testable / measurable variables

- **Imbalance ratio**: default 4:1; alternatives 3:1, 5:1, ~10:1 (987 fib). NEEDS-OPERATIONALIZATION for which market/context. (v209, [21:36])
- **Stacked buying imbalances in a single reversal bar at LOD**: 5–6 in one bar = high-conviction. Count is measurable. (v209, [31:33])
- **Stacked selling imbalances in a single bar at HOD**: 5 in one bar, 3 in next bar = high-conviction short signal. (v209, [34:22])
- **Delta sign at extreme**: positive delta at LOD = bullish divergence; negative delta at HOD = bearish divergence. Binary measurable. (v209, [31:33], [34:47])
- **Delta magnitude described as "small" / neutral**: −22, +16, ±135 called small/neutral in context of 1000+ swings. NEEDS-OPERATIONALIZATION (threshold unclear in this chunk, though ±50 known from digest). (v209, [27:04])
- **Ratio print presence**: binary — ratio number appears or not. Appears on exhaustion bars per algorithm; disclosed that it fires on second test of HOD/LOD more often than first. (v209, [38:00])
- **POC direction sequence**: consecutive POCs moving in same direction (3–5 bars) = directional conviction. Count testable. (v209, [25:32], [33:26])
- **FlowShifts YM 1-min settings**: volatile/normal/low detection, look-back 1, delta confirmation on, balance strength 1, balance points 2. (v208, [45:40])
- **Markers ATM demo (YM 1-min)**: 25-tick stop, 85-tick target; daily P&L guard ±500. These are demo parameters — NEEDS-OPERATIONALIZATION per market. (v208, [48:35])
- **"String together" positive delta bars**: 2–3+ consecutive strong positive delta bars required to confirm rally start. Count testable; "strong" NEEDS-OPERATIONALIZATION. (v209, [25:59])
- **Tick replay required**: Orderflows indicators require tick replay enabled in NT8 to render properly. Binary setup check. (v210, [00:32])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Markers + FlowShifts automation pipeline** (v208): Full step-by-step workflow disclosed:
  1. Add Markers Plus and two Markers Copy instances (one buy, one sell).
  2. In Markers Plus: set working mode to "Auto," enable longs/shorts, fast signal mode, set variable names (e.g., "normal up" / "normal down"), set daily P&L guard.
  3. In each Markers Copy: set variable name, enable fast signal, set input series to FlowShifts with desired settings, set plot to buy signal / sell signal, calculate on "each tick."
  4. Attach ATM strategy; select correct account.
  5. Optional: add AND indicator with HMA/slope filter — longs only when HMA going up, shorts only when going down.
  6. "Traces per side" parameter in Markers to limit entries (Mike uses 0 = first signal only; can set 20-bar minimum gap between signals).
  (v208, [43:28]–[57:41])

- **Indicator nesting compatibility check** (v208): To test if any custom indicator can feed into Markers, nest it inside a Maximum(1) or SMA(1) indicator — if that nests correctly, Markers Copy will work. (v208, [17:42])

- **Fast signal mode vs. drawing-object mode** (v208): Use fast signal mode (NT8 native plots) rather than drawing objects for lower latency. NT8 multi-threading gives plotting a lower priority than trading thread — fast signals bypass this. (v208, [59:53])

- **Tick replay on vs. off trade-off**: Live trading — turn off tick replay to avoid recalculation load; use for backtest/historical only. "Go to" (seek to timestamp) faster than replay for historical analysis without full tick replay enabled. (v208, [13:42])

- **FlowShifts works on**: minute, tick-based, volume-based charts. Does NOT work on range or renko charts. (v208, [1:11:25])

- **Orderflows Trader — 17 pre-programmed order flow indicators**: ratios, delta markers, POC highlighting (bullish=blue, bearish=purple), market weakness arrows (blue). Software built to flag what matters automatically. (v209, [36:05])

- **Ratio indicator**: blue numbers = ratio above bar (bearish exhaustion at HOD); black numbers = ratio below bar (bullish stopping volume / exhaustion at LOD). Exact formula undisclosed. (v209, [37:57])

- **Grade outputs implied**: ratio/divergence combination = signal; software identifies "this point of control matters and it's support/resistance." No explicit A/B/C grade in this chunk. (v209, [15:04])

---

## Q. Notable verbatim quotes

1. "One of my bread and butter trades. Happens all the time in pretty much every market. I'll say all the time, but most days it will happen at least once or twice. So it's a great trade to look at." — on divergence + ratio at HOD/LOD. (v209, [38:51]) [REPEATED]

2. "You have a selling imbalance here, 196 against 41. So you had very strong selling, but there's a buyer here. Yeah, sure, you want to sell some more? I'll buy it." — on absorption at a swing low. (v209, [21:36]) [REPEATED]

3. "Think outside the box. Don't think in terms of 'well, I got aggressive selling, it should be short.'" — on interpreting high sell imbalance at a low as absorption not breakdown. (v209, [21:07]) [REPEATED]

4. "If a trade doesn't start going in your favor relatively soon, chances are it's not going to go in your favor…if you find yourself underwater for the next 10 minutes chances are it's not going to work out." (v208, [06:52]) [REPEATED]

5. "It doesn't have to be binary — it has to be either a profit or a loss. No. You could get out at break even, plus one, minus one…you can get out of a trade at any point." (v208, [06:22]) [REPEATED]

6. "I'm long but all of a sudden the order flow that's coming in is bearish — then you get out." (v208, [06:22]) [REPEATED]

7. "You know, it's not like you have this double top, I'm waiting for it to break out before I get long. You buy that breakout, then it sells off another 20, 25 ticks before it goes back up." — on order flow entry vs. breakout entry. (v209, [22:34]) [REPEATED]

8. "For a market to move in the direction you expect it to, there needs to be follow-through order flow. If there's no follow-through order flow, what reason is there for the market to move?" (v209, [35:13]) [REPEATED]

9. "Having a way to automate my trade entry…it sort of removes that [emotional interference] from me because I know that the way that I trade has a positive expectancy." (v208, [01:05]) [ONCE]

10. "A ratio, right? 45. First time you had your divergence — negative delta 162 at the high of the day. Here you got negative delta 800 at your high of the day, but this time based on the order flow in this bar is telling you there's price exhaustion the second time we hit it. There wasn't the first time." (v209, [38:28]) [ONCE]

---

## R. Contradictions / nuances

- **Selling imbalance at a low is NOT automatically bearish**: a 196v41 sell imbalance at a low = absorption (bullish context), not a breakdown signal. Contradicts the naive "sell imbalance = go short" reading. Explicitly flagged: "think outside the box." (v209, [21:07]) [REPEATED]

- **Buying imbalances without follow-through are NOT a signal**: imbalances appeared at a low but "there's no follow through" bar — market made another leg down before the actual reversal. Warns against entering purely on imbalance count without confirming follow-through. (v209, [24:26]) [ONCE]

- **Ratio fires on the second test, not the first**: at the same HOD, no ratio on first visit ("there wasn't the first time"); ratio appears on second visit. Implies the algorithm is accumulating bar history / a longer lookback, not a single-bar instantaneous trigger. (v209, [38:00]) [ONCE]

- **Automation vs. discretion tension**: Mike describes his "bread and butter" trades as discretionary, yet also demonstrates full automation via Markers + FlowShifts. He explicitly says he "likes to manage the trade" and would exit early on negative order flow — but then says you can "run it on autopilot." The hybrid model (auto entry + discretionary exit) is his preferred mode, not fully automated. (v208, [49:50], [50:19]) [ONCE]

- **3:1 imbalance ratio used frequently**: "I use 3:1 a lot of times" — the known digest default of 4:1 is the "industry standard" but Mike personally uses 3:1 often. For certain contexts/markets 3:1 may be more appropriate. (v209, [21:36]) [ONCE — refines digest]

- **POC at HOD with non-progression vs. POC direction**: on the way up to a top, POCs "migrate a bit higher, kind of mixed, then they drop off lower." This is more nuanced than "POC at extreme = signal" — it is the stagnation and then reversal of POC progression that matters, not a single POC at the extreme. (v209, [34:47]) [ONCE]

---

## Coverage note

- v208 (FlowShifts + Markers training) is rich for NinjaTrader implementation details (automation pipeline, indicator nesting, fast signal mode, tick replay trade-offs) but thin on new reversal model content — nearly all reversal concepts stated are repeats of the known digest.
- v209 (How To Easily Understand Order Flow) is mixed: introductory in tone but contains clear, concrete model examples (absorption with imbalance counts, divergence+ratio second-test nuance, follow-through requirement, 3:1 imbalance usage). The second-test ratio nuance and the 3:1 default are the most extractable refinements.
- v210 (Tick Replay how-to) is thin — purely a 3-minute setup tutorial with no model content.
