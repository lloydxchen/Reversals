# Chunk 109 Extraction
- Source chunk: Chunk_109_Orderflows_Transcripts.md
- Transcripts covered:
  - v338 — Orderflows Trader On GoCharting How To Set Up Orderflows Trader (2023-08-10)
  - v341 — Crypto Order Flow Analysis With Orderflows Trader On GoCharting (2023-08-13)
  - v344 — Unlock the Power of Order Flow Trading on GoCharting (2023-08-14)
  - v348 — GoCharting Orderflows Trader Chart Setup (2023-08-18)
  - v361 — GoCharting Prominent Point Of Control POC Screen Settings (2023-08-27)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Exhaustion print** — last buyer has bought / last seller has sold; fires at the extreme of a bar where the counter-side volume drops to a very small number (e.g., 3 contracts at the low of a bar). Used at swing highs/swing lows. (v344, [26:38])
- **Imbalance reversal** — box signal marking trapped traders; bullish version fires near swing lows, bearish near swing highs. (v344, [28:09])
- **Prominent Point of Control (bearish / bullish)** — POC that acts as resistance/support; strongest version is one where the next bar does NOT trade back into it. Can be combined with delta divergence for a "system." (v344, [36:50]; v361, [00:26])
- **Inverse imbalance** — potential trapped-trader signal at inflection points; should be read at swing highs/lows only, not in sideways middle-of-range action. (v344, [41:49])
- **Multiple imbalances** — imbalances spread through a bar that are not necessarily stacked but still significant. Distinguished from stacked imbalances in that they need not be adjacent price levels. (v344, [43:42])
- **Stacked imbalances** (called "support/resistance zones" in GoCharting) — classic stacked buying/selling imbalances. Default = 3; can be set to 2 or 4. (v344, [21:09]; v348, [05:40])
- **Zero prints / thin prints** — zero volume on one side of the footprint bar internally; marks "bad structure" / fast sweeping action; acts as a potential fill-gap level for price to return to. Tradeable on 15-minute charts. (v344, [39:04]; v344, [48:01])
- **Buying/selling tails** — large stop-run move with no counter-trade follow-through; an institutional-size market order clears all offers/bids in a few ticks and immediately reverts; bearish if a big buyer appears and market reverts back down, bullish for the inverse. (v344, [45:41])
- **Sequencing (bullish/bearish)** — a solidified order book with sequential higher volume at each subsequent level; a strong trader lifts (or hits) each level in sequence for increasing size. Requires follow-through confirmation; does not single-handedly reverse a market. (v344, [33:25])
- **Market weakness (magenta arrow)** — measures weakening intensity of aggressive selling (on a downmove) or buying (on an upmove); a reversal signal. Not "the market is weak" but "the momentum/aggression is weakening." (v344, [31:19])
- **Market sweeps** — large aggressive buyer or seller sweeping through a price area; useful for identifying immediate near-term moves. (v344, [35:35])
- **Slingshot Point of Control** — POC analyzed relative to prior bars' POCs; signals a directional move; requires the next bar to confirm by beginning to trade in the signal direction before entry. (v344, [30:17])
- **Ratios (order flow ratio)** — bullish ratio appears as a blue number below a green bar; bearish ratio as a red number above a red bar. Hard-coded defaults in GoCharting: **27** (bullish) and **0.69** (bearish). Represents price support or price resistance. (v338, [07:23])
- **Delta divergence (bar-level)** — green candle with negative delta, or red candle with positive delta; highlights potential turning points at swing highs/lows. Distinguished from cumulative delta divergence. (v338, [12:32])
- **Value area absorption / value area extension** — extending value areas forward to identify areas of potential support/resistance; overlapping value areas = sideways market; gap between VA low and VA high = trending. (v344, [23:20]; v344, [1:22:50])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"Strongest" / "most powerful" Prominent POC**: the one where the next bar does NOT trade back into it. Explicitly differentiated from POCs that are retested immediately. (v344, [37:55]; v361, [03:13])
- **"Beautiful"**: used for a value area that holds and produces a "nice move up" (v344, [24:27]); used for thin-print level that holds to the tick on a 15-minute chart (v344, [50:24])
- **"Nice" / "nice move"**: a sequencing signal followed by proper continuation (v344, [35:03]); a Market weakness signal producing a reversal (v344, [32:21])
- **"Not going to take"**: a slingshot POC signal where the next bar immediately goes inside (no follow-through) — explicitly skip (v344, [30:50])
- **"Didn't work out"**: bearish slingshot POC where the next bar did not move lower (v344, [30:17])
- **Confirmation / "wait for the next bar to confirm"**: entry grade improves when the signal bar closes, the zero print holds, and the next bar opens and starts moving in the signal direction. Without this, it is a lower-quality, premature entry. (v344, [1:15:25])
- **"Important information" / "important to recognize"**: a zero print in a high-volume market (e.g., 0 contracts on one side of a 15-min ES bar) — implies high-tier structural signal. (v344, [50:24])
- **"One of my favorites"**: Prominent POC. (v344, [36:50])
- **"This one definitely would not be taking"**: a slingshot POC signal that doesn't produce follow-through in the next bar. Explicit skip. (v344, [30:50])
- **Context degrades signals**: "if a market is going sideways and you're getting everything screaming buy, it doesn't mean the market will go up" — in the middle of value, all signals are lower grade. (v344, [1:13:58])
- **Top-3 tools for e-minis (explicit ranked list)**: Prominent Point of Control, Thin Prints, Market Weakness — explicitly named as the three to use for ES day trading. (v344, [1:09:22]; v344, [1:12:21])
- **Top tools for MNQ (explicit list)**: Buying/Selling Tails, Inverse Imbalances, Imbalance Reversal, Slingshot POC (ratios), Market Weakness — sequencing and Market Sweeps were removed/not recommended for MNQ. (v348, [13:08])

---

## C. Order-flow story & psychology per setup

- **Exhaustion print**: the last aggressive buyer/seller has entered; no more interest in continuing the move; counter side is now free to push price back. The volume collapses to a handful of contracts. (v344, [26:38])
- **Bar delta divergence (green bar, negative delta)**: strong passive bidder absorbed aggressive sellers as price moved down; buyers dominated passively, driving price up again. (v338, [14:10])
- **Bar delta divergence (red bar, positive delta)**: large passive seller offered supply into aggressive buying; price could not advance despite aggression; bearish. (v338, [13:38])
- **Buying/selling tail**: an institutional-size order clears all resting orders on one side in a few ticks (e.g., "a big buyer buying 50 lots at once"); if no follow-through buyers appear behind them, the move fails and the market reverts — the institutional buyer was a stop sweep, not a genuine demand signal. (v344, [46:23])
- **Thin print / zero print**: a strong aggressive player swept right through a price level so fast there was no counter-trade — "the market didn't even have time to fill that in." That unfilled level becomes a magnet for price to return and test. (v344, [48:37])
- **Inverse imbalance**: aggressive traders on one side get overextended at a swing extreme; the level signals that those trapped traders will eventually need to cover. Only meaningful at clear inflection points, not in sideways chop. (v344, [41:49])
- **Sequencing**: a single large (institutional) participant is working through resting orders sequentially — "hitting this bid, hitting this bid, hitting this bid, each level for more and more volume until finally cleared." A momentum signal requiring follow-through, not a reversal signal. (v344, [35:03])

---

## D. Exhaustion clues

- Exhaustion print threshold: **default = 9** on GoCharting (matches NT version). Can be adjusted lower (e.g., 5) or higher. (v338, [06:18])
- At the low of a sell-off: if the bottom of the bar has only 3 contracts traded on the offer side, sellers are exhausted and price rises. (v344, [27:39])
- Exhaustion prints should be sought at swing highs or swing lows, or "even in moves" to indicate building momentum (mid-move context is lower quality). (v344, [26:38])
- Nothing new on cumulative exhaustion criteria vs. digest. [REPEATED]

---

## E. Absorption clues

- **Bar-level delta divergence as absorption signal**: negative delta on a green candle = passive bidders absorbing selling aggression (bullish absorption at lows). (v338, [14:10]) [REPEATED concept, but mechanism described with passive bidder framing]
- **Positive delta on a red candle** at resistance = passive seller offering supply to absorb aggressive buying; bearish absorption. (v338, [13:38]) [REPEATED concept]
- **Zero Min Delta** on a bar: aggressive sellers were never in control during that bar. Watching to see if sellers materialize in the next bar — absence of Min Delta before a selloff is a warning sign. (v344, [54:43])
- **Zero Max Delta** on a bar: aggressive buyers were never in control. Precedes continued downside. (v344, [54:08])

---

## F. Stacked imbalance ideas

- GoCharting labels stacked imbalances as "support/resistance zones." Default stacked threshold = **3** imbalances; can be set to 2 (more signals) or 4 (fewer). (v344, [21:09]; v348, [05:40])
- Imbalance ratio set at **400 (= 4:1)** in GoCharting (expressed as a percentage in the platform — "400" means 4x or 400%). Can be set to 300 (3:1) or 1000 (10:1). (v344, [20:39]; v344, [44:59])
- Stacked zones drawn out as visual boxes forward until price trades into them. (v348, [05:40])
- Nothing new on reversal vs. continuation interpretation vs. digest. [REPEATED]

---

## G. Delta / delta-divergence ideas

- **GoCharting's built-in Delta Divergence** (bar/candle level): highlights green bar with negative delta or red bar with positive delta by drawing a colored line through the bar. Explicitly distinguished from Orderflows Trader cumulative delta divergence. "This is more of a bar and delta divergence." (v338, [12:32])
- **Delta percentage threshold**: default = **25%**; flags bars where |delta| / volume ≥ 25% — these are "lopsided" bars indicating a directional imbalance of aggression. Adjustable. (v344, [55:49])
- **Max Delta / Min Delta threshold**: default = **3** (expressed as a small number); highlights bars where max or min delta is at or near that value. Signals strong aggressor control or absence of control during the bar. Adjustable (e.g., set to 5). (v344, [53:31])
- **Delta close near Max/Min Delta**: if final delta ≥ **95%** of the bar's max delta → strong aggressive buying remained dominant to close; signal of buyer conviction. Same logic inverted for min delta. (v344, [52:49])
- **Zero Max Delta / Zero Min Delta**: when one side has a max or min delta of zero, it means that side was never in control during the bar. Precedes reversals — used as an early warning before a sell-off or rally. (v344, [54:08])
- **Delta candle patterns**: Mike references a prior presentation on using delta candle patterns (wick = intrabar max/min, body = final delta relative to open). E.g., a red delta candle with a long lower wick and small body = went negative intrabar but recovered; bullish read. Promises a future video on this. (v348, [16:49])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Buying/selling tail** is explicitly framed as a stop-run / institutional-size sweep that fails to generate follow-through. Bearish version: a big buyer appears, lifts everything a few ticks, then market immediately reverts — because no other buyers follow. "Even though you had a big buyer come in there's zero follow-through." (v344, [46:54])
- Zero print as a failed-sweep artifact: the fast sweep leaves an unfilled level that acts as a gravitational level for price to revisit. (v344, [48:37])
- Nothing new on "market defies you" / failed-signal framing vs. digest. [REPEATED]

---

## I. Trapped-trader ideas

- **Inverse imbalance** is the explicit trapped-trader tool; must appear at a swing high or swing low to be meaningful. Inverse imbalances in the middle of a sideways range should be "ignored." (v344, [41:49]; v344, [42:27])
- **Imbalance reversal box**: marks bars where trapped traders are identified. Bullish = bottom of a move near swing lows; bearish = top of a move near swing highs. (v344, [28:09])
- The quantity of trapped traders is small (consistent with digest nuance); the signal shifts positioning, does not generate a big squeeze. [REPEATED]

---

## J. Entry triggers (the exact "go" event)

- **Slingshot POC**: wait for the next bar to begin trading in the signal direction before entry. Do not enter immediately on the signal bar. (v344, [30:50])
- **Zero print**: wait for the signal bar to close and the zero print to "stay there"; then wait for the next bar to open and begin trading in the expected direction before entering. Entry on premature basis (while signal bar still live) risks the zero being filled before bar close. (v344, [1:15:25])
- **Sequencing**: look for continuation in the next bar after the sequencing bar. Strong trader sweeping through levels requires follow-through to confirm. (v344, [35:03])
- **General rule** confirmed: "I always wait for the next bar to confirm" — applies across signal types. (v344, [1:14:59])
- **Prominent POC with value area context**: strongest entry when bearish/bullish POC aligns with an exposed value area that price returns to (e.g., bearish POC inside exposed value area → trades back up to it → sells off). (v344, [1:20:48])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Sequencing signal**: market should keep moving in the direction of the sequencing within 1–2 bars. If next bar goes "inside" (range inside the signal bar), no follow-through — signal fails. (v344, [35:03])
- **Slingshot POC**: next bar should start trading higher (bullish) or lower (bearish) immediately. If it doesn't — skip the trade. (v344, [30:50])
- **Thin/zero print**: after entry, market should continue directionally and not fill back into the zero print level. If it fills, that undermines the setup. (v344, [1:16:26])
- **Prominent POC**: if the market does NOT return to test the POC in the next bar, that is the strongest confirmation of directionality. (v344, [37:55])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Zero print fills in during the signal bar**: if the bar is still live and the zero prints gets filled, the setup is invalidated before entry. Must wait for bar close. (v344, [1:15:25])
- **Slingshot POC — no directional move in next bar**: if the next bar goes inside or fails to trade in the signal direction, do not take the trade. (v344, [30:50])
- **Sequencing — no continuation in next bar**: if next bar collapses or goes inside, the sequencing signal is negated. (v344, [35:03])
- **Prominent POC tested immediately in the next bar**: this degrades the signal from "strongest" to a lower-tier read. (v344, [37:55])
- General invalidation: signals in the middle of a sideways market / middle of value area = lower quality and more likely to fail. (v344, [1:13:58]) [REPEATED]

---

## M. Stop / risk / target / trade management

- **Thin/zero print short entry example**: enter short after bar close; stop a few ticks above the zero print level. Example cited: "risking one point to get five" (4 ticks risk / 20 ticks target) on an ES thin print. (v344, [1:17:34])
- He explicitly rejects the idea of a "1 tick to 165 tick" risk/reward: "honestly there's nothing like that." Order flow provides low-risk entries but not unrealistic ratios. (v344, [1:16:55])
- Nothing additional on time stop or re-entry vs. digest. [REPEATED]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Sideways market identification via overlapping value areas**: if value areas are mostly overlapping across many bars, that is a sideways/rotational market — signals are lower quality and need more context. If value area low of one period is above the value area high of the previous, market is trending. (v344, [1:22:50])
- **POC overlap as sideways filter**: if multiple bars' POCs cluster at the same price level, the market is sideways. (v344, [1:23:19])
- **GoCharting time-based charts only** (as of 2023): range/tick/volume charts NOT yet supported on GoCharting. This is relevant only as a platform limitation, not a model rule. (v344, [1:07:38])
- **Data integrity for crypto**: use Coinbase data feed only (not BitStamp/Binance) for reliable footprint analysis on crypto. (v341, [03:32])
- **Instrument-specific tool selection**: sequencing and Market Sweeps not recommended for MNQ; recommended for ES. Buying/Selling Tails more prevalent in NQ/MNQ and other volatile markets than in ES. (v348, [13:08]; v344, [45:41])
- **Bar-level focus vs. day-level volume**: daily volume total (e.g., "1.8M contracts") is not useful. Focus on per-bar volume — is it normal, light, or heavy for that time of day. (v338, [11:01])

---

## O. Directly testable / measurable variables

- GoCharting imbalance ratio: **400** (= 4:1 expressed as percentage) [CONFIRMED AS DEFAULT; same as NT]
- Stacked imbalance minimum: **3** (default), adjustable to 2 or 4
- Exhaustion print threshold: **9** (default), adjustable (e.g., 5)
- Ratio thresholds hard-coded in GoCharting version: **27** (bullish) / **0.69** (bearish) [NEEDS-OPERATIONALIZATION — direction unclear; 27 appears to be a ratio value equivalent to the ≥30 threshold in NT but slightly softer]
- Delta percentage threshold: **25%** (|delta|/volume ≥ 0.25 = lopsided bar) — NEEDS-OPERATIONALIZATION for signal generation
- Max/Min Delta threshold: **3** (default), adjustable to 5 — small absolute value; NEEDS-OPERATIONALIZATION
- Delta close near max/min: **95%** threshold — if final delta ≥ 95% of bar's max delta, flag as strong conviction close
- Zero Max Delta / Zero Min Delta: binary — zero = aggressor never appeared on that side during the bar
- Prominent POC strongest grade: next bar does NOT trade back into it (binary pass/fail)
- Inverse imbalance context filter: only valid at swing high/swing low, not in range middle (NEEDS-OPERATIONALIZATION of "swing" definition)
- Thin/zero print threshold: default = **5** in GoCharting; set to 0 for strictest (only true zeros); set to 9 for looser. (v344, [48:01])
- Risk/reward example: ~1 point risk / ~5 points target on ES thin print setup (ratio ~1:5) [ONCE]
- Sideways market: value areas overlap across multiple bars / POCs cluster at same price level

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- GoCharting version uses time-based charts only (not range/tick); NT version supports range/tick/volume charts — the NT version remains the primary platform for non-time-based chart traders. [ONCE]
- The GoCharting ratio thresholds (27 / 0.69) are hard-coded, whereas the NT version presumably allows customization — this implies the NT default may differ slightly (27 vs. the ≥30 in digest). [ONCE, NEEDS-OPERATIONALIZATION]
- Bar statistics panel in GoCharting exposes: volume, delta, Max Delta, Min Delta, cumulative delta, delta percentage — all of which Mike monitors on his NT charts as well; confirms these are his core per-bar metrics. (v344, [52:10])
- Delta candle visualization (wick = intrabar max/min, body = final delta) is mentioned as something Mike has presented on previously and implies pattern-recognition potential for NT implementation. (v348, [16:49]) [ONCE]
- Double-sided cluster (bid volume left / ask volume right) is Mike's preferred footprint display — confirmed applies to NT as well. (v348, [02:32])
- Prominent POC: the "virgin/naked" POC (not traded back into next bar) should have a distinct visual marker — the extension line drawn forward until tested. (v348, [08:13])
- The split-screen / multi-chart approach (scrunch a second chart to watch for Prominent POC signals while scrolling the primary) implies that NT implementation should consider alert/notification mode for Prominent POC so traders don't miss signals. (v361, [02:19])

---

## Q. Notable verbatim quotes

1. "The exhaustion print shows when the last buyer has bought in an up move or the last seller sold in a down move — basically the buying is exhausted on the move up, there's no more interest in buying and the market generally will naturally drop." (v344, [26:38])

2. "The strongest Prominent Points of Control are the ones that the next bar doesn't trade back into because it's telling me two things: one, I know this is now acting as my resistance, and two, the market is moving away from it right, it's trading away from this resistance area." (v344, [1:19:28])

3. "I always wait for the next bar to confirm. So for example let me just open this chart up ... I want to see this bar close, confirm that the zero print is going to stay there, the next bar to open and start trading lower. I'm fine to get in short here." (v344, [1:15:25])

4. "Even though you had a big buyer come in there's zero follow-through right, there's zero trade here — the market just jumped up a few ticks and is reverting back down. That's why it's bearish." (v344, [46:54]) [buying/selling tail interpretation]

5. "If a market is going sideways right in the middle of value right, right smack in the middle of value for the day, you get everything screaming buy — doesn't necessarily mean the market's going to go up. You still need the market to sort of start making a move." (v344, [1:14:27])

6. "Analyzing order flow requires a nuanced approach that goes beyond the surface level interpretation — it's just price. You want to look under the hood so to speak." (v344, [13:00])

7. "The thin print gives you some nice levels when they're there for the market to sort of come back and fill — it's kind of an intrabar gap if you will." (v344, [49:05])

8. "For me, if there's one thing you should focus on in order flow ... Prominent Point of Control is one of them. I've seen guys build their whole trading plans around trading with Prominent Point of Controls." (v344, [38:27])

9. "You're not just trading — you're trading against other people and information which is provided in the order flow gives you an advantage over everybody else." (v341, [13:59])

10. "You can have the best — whether it's order flow or anything — you could have five different indicators all firing at once, but if it's in the middle of a value area going sideways, it doesn't make it a good trade. You still want to put it in context." (v344, [1:13:58])

---

## R. Contradictions / nuances

1. **GoCharting ratio hard-code (27) vs. digest threshold (≥30)**: The GoCharting version hard-codes a bullish ratio threshold of **27** (not 30), with bearish at 0.69. This is slightly softer than the ≥30 threshold in the known digest. May represent a different calibration for the web platform, or may indicate the digest's "≥30" is a rounded/conservative figure. [ONCE; potentially contradictory to digest "≥30"]

2. **"Same settings every market" vs. instrument-specific tool selection**: Mike explicitly recommends different tool subsets per instrument (ES: prominent POC + thin prints + market weakness; MNQ: tails + inverse imbalance + imbalance reversal + slingshot; sequencing NOT recommended for MNQ). This refines the digest note that "same settings every market applies to detector only" — it goes further: *which signal types* are active also varies by instrument. (v348, [13:08])

3. **Bar-level delta divergence (GoCharting) vs. cumulative delta divergence (Orderflows Trader)**: Mike explicitly distinguishes these as two separate tools. The digest captures the cumulative version; the bar-level (green bar + negative delta) is the GoCharting built-in and is different in definition and use context. He confirms the bar-level version is "more of a bar and delta divergence" and is used for "potential reversal points" at swings, not necessarily momentum confirmation. (v338, [12:32])

4. **"You don't really need" day's cumulative volume**: Mike explicitly states the total day's volume (e.g., 1.8M contracts) "means nothing to me." He focuses exclusively on per-bar volume relative to typical bar volume. This is a subtle nuance: context filters in the digest reference session volume/activity but Mike here explicitly deprioritizes the raw day total. (v338, [11:01])

5. **Delta percentage threshold = 25% as the "strong" definition**: The digest references ">25% delta/volume (normal 5–15)" as a strong delta definition. Mike confirms the GoCharting default threshold is exactly **25%** and describes bars above this as "lopsided" / "imbalanced." This appears consistent with the digest but provides a precise parametric confirmation. (v344, [55:49])

6. **"Not about adding every single tool"**: Repeated across all 5 videos; Mike is insistent that tool overload degrades judgment. Best setups come from using a small curated subset relevant to the specific instrument. This is consistent with the digest but strongly reinforced here. [REPEATED]

---

## Coverage note

All 5 transcripts (v338, v341, v344, v348, v361) are GoCharting platform tutorial/promotional videos from August 2023 — classified as T3 (product launches / platform tutorials). The richest model content is in v344 (the 90-minute webinar), which contains useful re-explanations of nearly all key tools with visual demonstrations. v338, v341, v348, and v361 are thin on new model content and focus primarily on platform setup. The main extractions of model value come from v344's live walkthrough and Q&A section. No new numerical thresholds are introduced that conflict with the NT version, with the minor exception of the ratio hard-code (27 vs. ≥30). No unparseable content.
