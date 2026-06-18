# Chunk 114 Extraction
- Source chunk: Chunk_114_Orderflows_Transcripts.md
- Transcripts covered:
  - v465 — Markers Unleashed: From Charting to Automation (2025-10-24)
  - v467 — Orderflows FlowsTips Workshop (2026-01-08)
  - v474 — Introducing The Orderflows Pressure Indicator Presentation (2026-03-18)
  - v475 — How To Use Order Flow Read AI For Chart Analysis (2026-03-22)
  - v476 — Order Flow Reader AI - Order Flow Analyzed And More (2026-03-22)
  - v477 — Order Flow Reader AI versus ChatGPT (2026-03-23)
- Overall content value: thin

---

## A. Setup types & names he uses

- **FlowsTips signal** (bullish/bearish): tipping-point detector — flags the bar where aggressive/passive balance tips before price reacts. Uses a 1–6 "tips level" scale and a momentum-strength setting. Not a traditional footprint reversal; plots on any bar chart. (v467, "FlowsTips Workshop", [03:56])
- **Pressure signal** (buy pressure / sell pressure): passive-absorption detector — buy pressure = increasing bid volume at successively lower price levels; sell pressure = increasing offer volume at successively higher price levels. Distinct from exhaustion/imbalance setups already catalogued; focuses on the passive side of the book. (v474, "Pressure Indicator", [00:54])
- **Trade Entry Signal** (flow tips implementation detail): signal fires only when price moves ≥1 tick beyond the signal-bar extreme within a configurable "validity" window (default 5 bars). Suppresses signals with no follow-through. (v467, [33:52])
- **Automation of existing setups via Markers** (Volume Shift, Toolbox, Delta Scalper): treats each indicator's long/short output as an automatable signal; not a new setup type, but a deployment mode for existing ones. (v465, [24:23])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **FlowsTips tips level 1 = "good for most markets to start with" / "good on slower markets"**; tips level 3 = "kind of mid-range" / "three and three is also good"; tips level 6 = "really strong tips levels" but "probably too strong" on a trending market in live demo. (v467, [10:47])
- **Momentum strength 0 = "disable"**; 1 = "minimum" / "I like a little bit of momentum"; 3 = "average"; 6 = "strongest." He leans toward 1 or 3 in practice; calls 6 on RV/Renko charts unnecessary ("it's a momentum chart by itself"). (v467, [13:12])
- On signal quality: "there's going to be some signals that work excellent. There's going to be some signals that struggle." — acknowledges the spectrum but does not apply A+/B/C grading vocabulary to FlowsTips or Pressure in these videos. (v467, [22:47]) [ONCE]
- **No A+ grading language** applied to the new indicators in these presentations. Grading is implicit in the settings dial (higher tips level / momentum strength = stricter = fewer but higher quality signals). [SPECULATIVE — implied, not stated]
- On Pressure Indicator: "fewer signals, but significantly higher quality signals" when momentum filter is active (momentum strength 3 = "recommended starting point"). (v474, [14:14]) [ONCE]
- Momentum filter OFF with swing filter ON: "working against each other" → effectively a tier-killer combination — swing filter seeks highs/lows, momentum filter seeks trends, combining them means almost no signals fire. (v467, [42:00]) [ONCE]

---

## C. Order-flow story & psychology per setup

- **Pressure Indicator narrative**: aggressive sellers push price lower → passive buyers scale in at successively lower levels, each lower level absorbs more volume than the last → aggressive sellers exhaust against a "wall of passive buying" → market stabilizes and rallies. Mirror logic for sell pressure. (v474, [03:53])
- **FlowsTips narrative**: "every bar is a negotiation between passive and aggressive traders." Aggressive traders move the market; passive traders support it, resist it, and "when they back off, what's left to stop the market?" FlowsTips detects the tipping point of control shift per bar. (v467, [02:54])
- **Trapped trader / stop-tag psychology** (contextual, not a discrete setup): "your stops get tagged to the tick" — Mike frames this as an information problem, not a psychology failure; the trader sensed something in the order flow but couldn't see it clearly. OrderFlow Reader AI is proposed as the post-trade autopsy tool. (v476, [01:40])
- Automation philosophy: "if things change in the order flow, I want to get out. I don't need to get stopped out to get out of a trade." Semi-automated = machine entry, human exit discretion based on live order-flow changes. (v465, [09:08])

---

## D. Exhaustion clues

- FlowsTips: "if signal doesn't result in a tick move within two bars, it's ignored. No movement, no trade." — This is the follow-through gate embedded as a hard filter, framed as a proxy for exhausted/spent signals. (v467, [25:14]) [ONCE]
- Pressure Indicator: aggressive buyers "exhaust themselves against the wall of passive selling" at defended high; the volume on the offer shows "subsequent increases at higher price levels" (each higher level more volume than the last). This is the exhaustion read embedded in passive detection. (v474, [04:20])
- Nothing new on traditional exhaustion prints, stopping volume, or thin prints in this chunk.

---

## E. Absorption clues

- **Pressure Indicator operationalizes absorption precisely**: buy pressure = increasing bid-side volume at each successive lower price level within the same move — not just big volume but a gradient of increasing passice size. (v474, [01:25]) [ONCE — clearest statement of the gradient criterion]
- OrderFlow Reader AI demo identifies "large volume absorption" and "trapped traders" as key lessons from a bonds chart; the AI flagged "two recent instances of powerful seller absorption around the 1 12 13 – 1 12 14 area" as support for a bullish reading. (v477, [04:46]) [ONCE]
- FlowsTips POC movement filter: "selling stalls despite high volume, a squeeze is brewing" — absorption with high volume at a defended level is the squeeze precursor. (v467, [23:20]) [ONCE]

---

## F. Stacked imbalance ideas

- — nothing new in this chunk — (v465/467/474/475/476/477 are product-launch/tutorial content; stacked imbalances are mentioned in AI output excerpts only as a named concept, not elaborated upon)

---

## G. Delta / delta-divergence ideas

- Pressure Indicator has an optional **delta confirmation filter**: delta must be positive (for buy pressure) or negative (for sell pressure) to allow the signal. Filters out bars where delta opposes the passive detection. (v474, [06:28]) [ONCE]
- Pressure Indicator also has a **delta divergence** filter option (listed in features at v474, [15:52]) — not elaborated but named as a selectable filter.
- OrderFlow Reader AI demo: identified "delta reversal pattern" and "cumulative delta divergence" as lessons in the bonds chart. Confirms that the AI model treats these as key reversal concepts. (v477, [04:46])
- "a short delta divergence, microstructure, momentum is fading" — ChatGPT's characterization in v477; Mike comments he doesn't see exhaustion signs and the market actually went up. Implicitly: ChatGPT over-reads delta divergence without context. (v477, [05:19]) [ONCE, NUANCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- Pressure Indicator feature: "confirm breakouts and fake outs by checking for passive defense" — if passive sellers are NOT increasing at a breakout high, it's more likely genuine. If passive sellers ARE increasing (sell pressure), fade the breakout. (v474, [16:28]) [ONCE]
- FlowsTips POC movement filter: "price and POC move in the opposite direction — maybe not a trade that you want to take" — POC divergence from price = conviction absent = fake move. (v474, [11:30]) [ONCE]
- — nothing further in this chunk —

---

## I. Trapped-trader ideas

- OrderFlow Reader AI demo: "trapped traders" explicitly named as a lesson the AI provides from a bonds chart. Mike treats trapped-trader detection as a standard lens. (v477, [08:12])
- No new operational detail on trapped traders beyond what digest already contains.

---

## J. Entry triggers (the exact "go" event)

- **FlowsTips trade entry signal**: go event = price moves ≥ N ticks beyond the signal-bar extreme (default = 1 tick) within the next M bars (default = 5 bars). If no follow-through within M bars, signal is suppressed and no entry fires. (v467, [33:52]) [ONCE — first precise parametric description of this specific confirmation mechanic]
- Markers automation entry: fires at each tick (intrabar) by default; option to wait for bar close, then enter at bar-close only if signal still present. (v465, [35:55]) [ONCE]
- Semi-automated mode in Markers: user can designate direction (long-only or short-only button); the other direction is ignored until re-enabled. (v465, [20:55]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- FlowsTips: "if signal doesn't result in a tick move within two bars, it's ignored" — embedded confirmation gate; broader follow-through is expected to develop within 1–2 bars post-signal. (v467, [25:14])
- Pressure Indicator: "momentum aligns with the pressure signal, it reinforces the validity of the trade" — momentum filter as a same-direction confirmation. (v474, [13:38])
- For automation setup (Markers): after entry, "you're still going to have your ATM in there, right? Your take-profit and your stop-loss." Plus live order-flow monitoring to exit early if dynamics change. (v465, [09:08])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- FlowsTips: signal is killed / no trade fires if price does NOT move ≥1 tick beyond signal-bar extreme within 5 bars (Trade Entry Signal gate). (v467, [33:52])
- Pressure Indicator: "when momentum diverges [from pressure signal], it's telling you to pass" — momentum opposing the passive-absorption signal = stay out. (v474, [14:14])
- FlowsTips + automation: "if things change in the order flow, I want to get out" — live order-flow shift after entry is the exit trigger, before stop is reached. (v465, [09:08])
- Combining swing filter ON + momentum strength ON in FlowsTips: almost no signals fire — they "work against each other." Not an invalidation per se but a configuration invalidation. (v467, [42:00])

---

## M. Stop / risk / target / trade management

- FlowsTips stop zone: "these lines being drawn out is a zone… I use these zones as stop placements." The stop zone is drawn from the signal-bar extreme (the level the Trade Entry Signal monitors). (v467, [32:37]) [ONCE — visual stop-zone concept, not a tick value]
- Targets: "targets are based off of the chart you're trading… the time frame that you're looking at… some traders have very tight targets, some have very wide targets." Explicitly deferred; no number given. (v465, [54:24]) [REPEATED — consistent with digest]
- Trade management philosophy: "would you rather get stopped out at your full amount or stopped out at half or just be happy to scratch the trade?" — semi-automated allows discretionary reduction of loss; full stop not required. (v465, [09:37])
- No new tick/point targets given for any instrument in this chunk.

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Multi-time frame analysis** — FlowsTips and Pressure Indicator both support overlaying higher (or lower) time frame signals on the execution chart. Preferred higher-TF window: 5–15 minutes. "4-hour order flow — I think that's not very useful." (v467, [07:18]; v474, [09:05])
- "When you see the aggregation of the order flow come in [from higher TF], it can give you some nice powerful signals." (v467, [07:24]) [ONCE]
- **Higher TF setting guidance**: if using 5-min or 15-min analysis on a 1-min chart, Mike keeps Tips Level at 1 and Momentum Strength at 1 or 0; stricter tips level (3) suits single-TF charts. (v467, [17:57])
- **Volatile markets** (gold, silver, 2026 context): "you got to cut your losses quick. Don't try to wait it out." Not a filter per se but a regime-specific risk management note. (v467, [51:30]) [ONCE]
- **POC movement as context filter**: POC shifting with price = volume acceptance / conviction behind the move; POC diverging from price = no conviction / potential fake. (v474, [11:02])
- **VWAP/EMA as automation filter** (Markers): adding VWAP or a 200 EMA (or HMA 200) as a directional filter in Markers — only take longs above the filter line, only take shorts below. Demonstrated with HMA 200. (v465, [40:50]) [ONCE — first explicit demo of price-vs-MA as a filter on top of OF signals]
- Overnight session (MEES) mentioned as a period where FlowsTips settings work well (tips level 3, momentum strength 1 example shown). (v467, [15:02]) [ONCE]
- RV (reversal bar) and Renko charts: momentum strength should be 0 or 1 because the chart type itself is momentum-based. (v467, [17:18]) [ONCE]

---

## O. Directly testable / measurable variables

- **FlowsTips Tips Level**: integer 1–6; 1 = lowest threshold (most signals), 6 = highest (fewest signals). 3 = mid-range/recommended starting point. [NEEDS-OPERATIONALIZATION: exact internal threshold not disclosed] (v467, [10:47])
- **FlowsTips Momentum Strength**: 0 = disabled, 1 = minimum, 3 = average, 6 = strongest. [NEEDS-OPERATIONALIZATION: formula undisclosed] (v467, [13:12])
- **FlowsTips Swing Filter (swing period)**: 5 = default; range includes 1, 3, 7, 9; user-defined. Mutually exclusive with Momentum Strength for practical signal generation. (v467, [11:22])
- **FlowsTips Minimum Volume**: default = 5; can be raised to 10–20 for thinner markets (Swiss Franc, agricultural products). (v467, [11:59])
- **FlowsTips POC Movement filter**: 0 = off; 1 = tightest; higher = stronger breakout requirement. [NEEDS-OPERATIONALIZATION] (v467, [31:52])
- **FlowsTips Trade Entry Signal**: Trade Price Level in ticks = 1 (default); Trade Validity in bars = 5 (default). Both configurable. (v467, [33:52])
- **FlowsTips multi-TF**: supports tick, volume, range, second, and minute-based analysis. Renko/RV requires tick replay and can only analyze the same-type chart. (v467, [10:19])
- **Pressure Indicator Momentum Strength**: 0 = disabled, 1 = minimum, 3 = average (recommended starting point), 6 = strongest. Same scale as FlowsTips. (v474, [13:04])
- **Pressure Indicator buy pressure definition**: bid-side volume increases at each successive lower price level within the move. [NEEDS-OPERATIONALIZATION: how many levels, what % increment] (v474, [01:25])
- **Pressure Indicator sell pressure definition**: offer-side volume increases at each successive higher price level within the move. [NEEDS-OPERATIONALIZATION] (v474, [04:20])
- **Markers "Trade Entry Signal" (automation)**: bar-close entry option vs. tick entry; signal persistence check at bar close before firing. (v465, [35:55])
- **Markers filter**: unlimited conditions can be combined (AND logic); examples: close > HMA[0], MACD > threshold, slope of line. (v465, [38:43])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **FlowsTips requires tick replay**: to plot historical signals; real-time does not require tick replay. Same requirement as Imbalancer and other footprint-based indicators. (v467, [27:46])
- **FlowsTips reads footprint data on the backend, plots on bar chart**: "it reads this footprint data as it's coming in… but it's just plotting it on a bar chart." Does the volumetric/footprint calculation internally without needing a footprint chart rendered. (v467, [53:27])
- **Multi-instance approach**: multiple FlowsTips instances with different TF settings and distinct colors on the same chart for multi-TF confluence (e.g., blue = 5-min, orange = 15-min). (v467, [26:33])
- **Markers link ID system**: when automating multiple indicators on the same chart, use distinct Link IDs to avoid variable name collisions even if both use variable names "longs" and "shorts." (v465, [23:00])
- **Separate execution chart (no tick replay)**: recommended to have the tick-replay chart for signal calculation and a separate fast non-tick-replay chart for order execution in Markers. Reduces latency and prevents recalculation delays. (v465, [19:33])
- **Toolbox vs. Orderflows Trader** distinction (implementation): Toolbox only fires when BOTH thin print AND open POC are present simultaneously; Orderflows Trader fires on either alone. The Toolbox is a stricter, combined-condition version of the footprint scanner. (v465, [47:54])
- **OrderFlow Reader AI**: uploads a footprint chart screenshot; AI performs 6-layer analysis (current bar bias, bar-to-bar comparison, bullish/bearish zones, current bar vs. zones, market context, final verdict) plus lessons and PDF export. Trained on Mike's 20 years of institutional experience. Not a NinjaTrader indicator — a standalone web/app tool. (v476, [00:27])
- **Pressure Indicator features list**: multi-TF analysis, POC movement detection, momentum strength filter, trade entry signal, pressure sensitivity levels, POC filter, delta confirmation, delta divergence, visual signal zones, look-back filter, bar threshold volume. (v474, [15:52])

---

## Q. Notable verbatim quotes

1. "Flow tips, pinpoints when the balance tips before price reacts. You know, sometimes the balance tips, but the price doesn't react." — Defines the FlowsTips signal candidly, acknowledging false signals. (v467, [22:13])

2. "If signal doesn't result in a tick move within two bars, it's ignored. No movement, no trade. It's as simple as that." — The hard follow-through gate embedded in FlowsTips. (v467, [25:14])

3. "Every bar is a struggle between buyers and sellers, right? Flow tips pinpoints when the balance tips before price reacts." — Core model statement. (v467, [22:13])

4. "Passive traders determine market outcomes… when aggressive sellers push the market lower and hit a level where passive buyers are absorbing every contract with increasing size — that's the moment reversals begin." — Institutional framing of absorption as the reversal cause. (v474, [02:55])

5. "Selling stalls despite high volume, a squeeze is brewing. When buying dries up, it's time to fade or step aside." — Concise model statement for the absorption-to-reversal logic. (v467, [23:20])

6. "Momentum strength filter… when momentum aligns with a pressure signal, it reinforces validity. Passive absorption and the market has momentum in the same direction. That should give you a higher conviction trade." (v474, [13:38])

7. "Good strategy plus automation equals consistent results. No strategy plus automation equals consistent losses." — Automation framework, not reversal model, but defines the required strategy-first precondition. (v465, [54:51])

8. "Toolbox sort of takes the orderflows trader a step further and allows you to combine different tools from the orderflows trader to generate a trade signal… will only show you signals where you have a thin print plus the open point of control." — Precise specification of Toolbox's conjunction logic vs. Orderflows Trader's disjunction logic. (v465, [47:54])

9. "I don't need to get stopped out to get out of a trade. If things change [in the order flow], I'll get out." — Discretionary order-flow exit as the preferred risk management over mechanical stops. (v465, [09:08])

10. "The Orderflows Pressure Indicator works on your normal candlestick chart… it's reading all that information that goes into forming the footprint chart… and just plots it on a normal candlestick chart." — Key NT implementation concept: footprint analysis without a footprint chart rendered. (v474, [07:33])

---

## R. Contradictions / nuances

- **FlowsTips momentum + swing filter incompatibility**: "if you're using momentum strength with a swing filter, chances are you're not going to see signals simply because they're working against each other, right? Momentum is for catching moves in a trend. Whereas swing filter is for catching swing highs and swing lows." This is a direct operational constraint — combining them in an indicator build would suppress most signals. (v467, [42:00]) [ONCE]
- **POC movement filter framed as breakout filter, not momentum**: "it's probably more on a breakout filter than using the momentum filter." While it looks like a momentum filter (POC must be moving), its functional role is to confirm that volume is moving with price (breakout), not just that price is accelerating. (v467, [28:26]) [ONCE — nuanced distinction]
- **ChatGPT vs. OrderFlow Reader AI diagnosis divergence**: On the same bonds chart, ChatGPT read "buyers exhausted at highs, rotation lower is higher probability" while OrderFlow Reader AI read "bullish (weak)." Market went up. Mike treats this as validation of his AI's training, but it also reveals that generic AI tools can misread OF context. Not a contradiction of Mike's model but a cautionary note about prompt-based generic AI for OF analysis. (v477, [07:02])
- **"Same settings every market" nuanced further**: for FlowsTips, minimum volume filter DOES need adjustment for thin markets (Swiss Franc, agriculturals); for liquid markets (E-mini, bonds) the minimum volume default is fine. This is consistent with the digest's existing nuance but adds the specific example of Swissie/ags needing a higher minimum volume setting. (v467, [11:59])
- **Automation is "semi-automated" preferred over "fully automated"**: Mike repeatedly walks back full automation, preferring human oversight of the live order flow after machine entry. He cites HFT blowup examples. This is consistent with his "react, don't predict" stance but explicitly applies it to automation mode. (v465, [09:08], [55:26])
- **Tips level 6 in live demo deemed "too strong"**: on a trending E-mini, tips level 6 missed the major selloff. Mike reverted to level 3. Confirms the tiering warning: max sensitivity ≠ best quality in practice. (v467, [36:15])

---

## Coverage note

All six transcripts in this chunk are classified T3 (product launches / platform tutorials). v465 covers the Markers automation platform (third-party) with minimal model content; v467 introduces FlowsTips with moderate model content on its settings and follow-through gate; v474 introduces the Pressure Indicator with the clearest new model content (passive-absorption gradient logic, delta confirmation filter); v475–v477 cover OrderFlow Reader AI (a screenshot-analysis tool) with near-zero reversal model content. The chunk is thin for reversal model building, but v474 and v467 contain two genuinely new operationalizable concepts: the passive-absorption gradient (Pressure) and the parametric Trade Entry Signal follow-through gate (FlowsTips).
