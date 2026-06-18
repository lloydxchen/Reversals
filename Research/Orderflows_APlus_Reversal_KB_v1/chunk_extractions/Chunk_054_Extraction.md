# Chunk 054 Extraction
- Source chunk: Chunk_054_Orderflows_Transcripts.md
- Transcripts covered:
  - v181 — "Uncovering Hidden Trading Opportunities With Order Flow May 7th 2020" (2020-05-07)
  - v182 — "Unusual Order Flow Activity - How To Spot It And Trade It - Ninjatrader 8 Order Flow" (2020-05-28)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Imbalance Reversal** (bullish and bearish): bar that started out moving one direction but conditions changed mid-bar — early aggressive buying met with aggressive selling (or vice versa), leaving an imbalance footprint from the "wrong" direction at a high or low. Signaled by a green arrow (bullish imbalance reversal) or red arrow (bearish imbalance reversal) on the chart. (v181, [16:58]; v182, [14:39])
- **Multiple Imbalances** (bullish or bearish): three or more buying or selling imbalances in a single bar — not necessarily stacked (can be spread out in the bar), but the sheer count signals control by one side. Software draws a violet/magenta box around the bar. Contrasted with stacked imbalances. (v181, [20:02]; v182, [48:13])
- **Stacked Imbalances** (bullish or bearish): three or more imbalances stacked neatly on top of each other in a bar. Distinguished from multiple imbalances (stacked = neatly aligned, multiple = spread). Both get software boxes, but stacked is the higher-priority signal. (v181, [13:15]; v182, [11:56])
- **Prominent Point of Control (POC)** (bullish or bearish): a point of control that acts as support or resistance — not every bar's POC qualifies, only those the software detects as "prominent." Bullish prominent POC = support; bearish prominent POC = resistance. (v181, [20:33]; v182, [22:35])
- **POC Cluster / Migrating POC**: multiple bars where the second and/or third points of control converge at or near the same price zone, indicating strong support or resistance. Seven or eight out of nine possible POC levels aligned = "important information." Value migrating lower across bars = supply present, likely move down. (v181, [29:40]; v181, [30:16])
- **Small Print / Small Digit** (bullish or bearish): a single very low-volume print at the extreme of a bar — e.g., one contract traded at the high of the bar — indicating price rejection or exhaustion ("buyers aren't interested anymore at this level"). Bearish small prints appear at swing highs; bullish small prints appear at swing lows. Software draws a red or green box around these extreme prints. (v182, [33:45]; v182, [35:18])
- **Market Sweep**: a large order that buys up through multiple offers or sells through multiple bids in one order/moment, leaving a distinctive imbalance footprint with minimal counter-trade. Sign of a large institutional participant with a directional conviction. (v182, [25:43])
- **Positive Delta Down / Negative Context**: market declining with positive delta (buying imbalances visible) — interpreted as hidden passive supply being worked on the offer while aggressive buyers absorb it until they tire out. Advanced concept. (v182, [56:15])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"My favorite trade"**: small print at the daily high or daily low (or swing high/swing low). Described as "fantastic" opportunity when combined with immediate reversal. (v182, [1:03:47]) [ONCE]
- **"Very revealing"**: volume transacted in wicks — specifically when the POC is at the top of a green candle, showing sellers were dominant despite up-close appearance. Explicit critique: "don't ignore the wicks." (v182, [59:08]) [ONCE]
- **"Important information"**: (a) multiple imbalances at a swing low — signals aggressive buyers stepping in; (b) POC cluster with 7–9 out of 9 possible POC levels aligned at same zone; (c) small prints in the context of price rejection. (v181, [29:40]; v182, [48:45]) [REPEATED]
- **"Clear signs"**: combination of small print + delta weakening + POC confirming + selling imbalances = "clear" reversal setup vs. ambiguity on candlestick alone. (v182, [37:30]) [REPEATED]
- **"Great/better entries"**: order flow allows earlier entry (near imbalance/POC signal) vs. waiting for breakout confirmation — explicit framing of a trade-off: enter at the signal vs. wait for bar-close break. (v181, [23:37]) [REPEATED]
- **Quality discriminator — context at a low**: a stacked selling imbalance at a swing low is NOT bearish if the prior move was already down; must read in context. "I'd be looking at multiple buying imbalances off a swing low" — the direction of the prior trend changes how the same signal is graded. (v182, [54:05]) [ONCE — important nuance]
- **"Not a great" / "skip" implicit**: when delta confirms only weak buying (e.g., delta 770 then 108, 132) at a swing low and then delta flips negative (–102, –578, –1400 cascade), the setup is "not really" a rally setup even if imbalances exist. (v182, [54:38]) [ONCE]
- **Tiered by confluence**: "you put it together with the multiple selling imbalances here obviously you got the negative deltas as well and the market sells off" — single signals described as insufficient without delta + POC + imbalance convergence. (v181, [20:33]) [REPEATED]

---

## C. Order-flow story & psychology per setup

- **Imbalance Reversal psychology**: trader who "sold the low of the move" or "got long at the high" — trapped in the wrong direction. The imbalance reversal documents the footprint of the trapped traders' entry. "Conditions change mid-bar" — the bar started one direction (bullish) but the reversal is already embedded in the early prints of that bar before it closes. (v182, [17:36]; v182, [22:07])
- **Small print exhaustion story**: buyers (or sellers) have been trying repeatedly — "they tried once twice three times already and on the third time there was only one person interested." The diminishing participation at an extreme is the story of exhaustion, not just one signal. (v182, [38:04])
- **Positive delta while price falls**: buyers think the market is cheap and step in aggressively, but they are absorbing passive supply being offered out at the ask. Supply is "hidden" in positive delta — sellers are not hitting bids but working offers, so delta appears positive while the market drifts lower. Once buyers tire, price falls freely. (v182, [56:45]; v182, [57:42])
- **Market sweep psychology**: large trader with a directional conviction sweeps through multiple price levels in one action. "Because he knows that his buying is going to help move the market up that's why traders sweep the market." Not inside information — just size + conviction + speed. When a sweep does not retrace and fill back in, it's a directional sign. (v182, [27:20]; v182, [32:17])
- **POC cluster / migrating value**: "buyers are happy to start trading their size at lower levels … the market is migrating lower where people are happy to start selling more." POC migration across bars in one direction telegraphs where value is moving before price breaks out. (v181, [30:16])
- **Prominent POC as magnet**: price returns to prominent POC levels because that is where the most volume/value was established earlier. Explains why price came back to a specific level (not the high or low of prior range) — "not this level up here, not a lower level, came back here." (v181, [33:54])

---

## D. Exhaustion clues

- **Small print / single contract at extreme**: one (or very few) contracts traded at the high or low of a bar = "buyers aren't interested anymore at this level." Threshold in examples: software set to ≤9 (examples: 1, 2, 3, 4, 5, 6 shown as qualifying). (v182, [35:18]; v182, [36:22]) [REPEATED]
- **Diminishing volume at a repeated extreme**: market tests same level multiple times with declining volume per attempt — e.g., 366, then 13, then 126, then 1 contract. The declining sequence signals exhaustion of the aggressive side. (v182, [36:22]) [ONCE — clear example]
- **Delta dries up at swing extreme**: delta transitions from strong (770) to near-zero (108, 132) at the same price zone before turning negative (-102, -578, -1400). The sequence of weakening delta is the exhaustion read, not just the final negative delta bar. (v182, [54:38]) [ONCE]
- **Multiple small prints in sequence at top**: "small print here small print here as the market is going lower" — the repeated appearance of small prints in consecutive bars at the extreme confirms the exhaustion is sustained, not a one-bar fluke. (v182, [59:43]) [REPEATED]

---

## E. Absorption clues

- **Positive delta with falling price**: aggressive buyers absorbing passive supply at the ask — the positive delta represents the absorbed demand. Supply is "hidden." When buyers are exhausted, the absorbed supply wins and price falls. (v182, [56:45]) [ONCE — novel framing]
- **Buying imbalances at a swing low with price holding**: multiple buying imbalances appearing after a down move signals "aggressive buyers attracted to cheap price." The market "finding" buyers who are willing to be aggressive = absorption of the sell-side supply. (v182, [48:13]) [REPEATED]
- **Strong volume at the wick with POC at wick extreme**: POC near the top of a green candle with large volume numbers at that level (e.g., 310, 416, 224, 176 in wick = sellers were absorbing the buying pressure up there). "Strong selling into that bid" — absorption by sellers in a wick zone. (v182, [59:08]) [ONCE]
- **Stack selling imbalance at a low that doesn't follow through bearishly**: signals supply is present but is being absorbed by demand. Example: gold chart with stack selling imbalance at the low — price rejected DOWN despite the bearish signal, then rallied. (v182, [15:37]) [ONCE]

---

## F. Stacked imbalance ideas

- **Stacked selling imbalance at a LOW can be bullish** (price rejection down): "yeah you have a stack selling imbalance market rebounded up so price is being rejected down here." The selling imbalance at the very low of the move represents sellers who can't push through — price rejection interpretation. Contrasted with: stacked selling imbalance mid-range or at a high = bearish. (v182, [15:37]) [REPEATED — but with a clearer example context]
- **Stacked selling imbalance at a HIGH confirms resistance**: "stack buying imbalance and the bar closes down … you have a reversal forming up in here." The stacked imbalance on the UP side of a bar at a high (buying imbalance) followed by price reversal = confirms resistance. (v182, [18:21]) [REPEATED]
- **Stacked vs. multiple — graded distinction**: stacked = neatly on top of each other (higher-grade signal, pink box per v181); multiple = three+ imbalances spread out in a bar (also significant, violet/magenta box). (v181, [13:15]; v182, [11:56]) [REPEATED]
- **Multiple imbalances at a swing low after a down move**: specifically "after you're coming down into a low you know is there signs of life that this market is going to start to rally — one of the first signs of life is you're going to start seeing aggressive buying coming in in the form of buying imbalances." Multiple (not necessarily stacked) buying imbalances at a swing low = early sign of reversal. (v182, [51:41]) [REPEATED]

---

## G. Delta / delta-divergence ideas

- **Delta of near-zero at a high with decent volume = bearish hidden selling**: "delta is small it's eight it's eight … volume i'll show you a delta of 8 is telling you that even though we're going here there's sellers coming in … you've got 500 people buying the offer versus 100 people selling into the bid right that's going to give you a buying imbalance but you're going to look at the delta and say well it's a delta of 300 instead you're seeing a delta of 8." Net-neutral delta at a swing extreme = aggressive selling is matching aggressive buying. NEEDS-OPERATIONALIZATION: how close to zero is "effectively neutral"? Examples: delta 8 on 2,000 volume = ~0.4% ratio. (v182, [19:27]; v182, [20:33]) [ONCE — very explicit]
- **Consecutive small deltas at a swing high then delta turns negative**: delta +8, +8 followed by delta –something on next bar = the turn is the signal. The small prior deltas are the warning. (v182, [24:13]) [ONCE]
- **POC migrating lower + consistently negative delta = short bias**: "delta is consistently negative 270 26 negative 270 negative 262 negative 270" combined with POC migrating lower tick by tick = "if I was looking to trade I'd be looking to trade it on the short side." (v182, [1:01:11]) [ONCE — very explicit multi-bar POC + delta synthesis]
- **Delta surge then rapid collapse = exhaustion sequence**: delta 770 → 108 → 132 → –102 → –578 → –1400. The five-fold jump from –102 to –578 ("it's gone five times") and then to –1400 ("three times as much") = "sellers are back in control." Reading the relative multiplier of delta changes, not just the absolute value. (v182, [55:07]) [ONCE — clear ratio language]
- **Negative delta with buying imbalances visible = supply being worked passively**: advanced concept — sellers offering at ask (not hitting bids), so delta appears positive (buyers lifting offers) while price falls. The positive delta is the absorbed demand, not bullish. (v182, [56:15]) [ONCE]
- **Delta weakening on pullback = stay long**: in a bullish setup after a swing low, delta "consistently negative" small values (270, 262, 270) on a pullback bar indicate the pullback is not aggressive selling. Contextual: same negative delta values read differently depending on whether you are at a high or in a pullback. NEEDS-OPERATIONALIZATION. (v182, [1:01:11])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Market sweep as a directional tell** (not a trap/stop-run): the sweep is a large institutional order lifting all offers or selling all bids in one move. When the swept market does NOT retrace back to fill the gap, it confirms directional intent. When it does retrace, the sweep "didn't work out." (v182, [31:16]; v182, [32:17]) [ONCE]
- **Stacked buying imbalance at a high that reverses**: bar with stacked buying imbalances closes down → market pokes one tick above the prior bar's high → reverses and sells off. "You get short right, you're risking what a point, short at 11 stop at 12 it only comes up to 11 and three quarters and sells off." The one-tick poke-through above the swing high is the trap confirmation trigger. (v182, [18:21]) [ONCE — explicit trigger description]
- **Bullish candlestick with bearish small prints at top**: market with bullish-looking candlestick bodies (up-close candles) but small prints at the top of each bar = bearish despite appearance. "If you're looking at the candlesticks you're thinking well you know hey these are actually bullish looking candlesticks but if you're looking at the order flow you can see that there's price rejection in these bullish candlesticks." (v182, [40:19]) [ONCE]

---

## I. Trapped-trader ideas

- **Imbalance Reversal = documentation of trapped traders**: explicit definition — "traders are trapped in a market right there long and wrong they're short in the hole … you sold a low of the move you got long at a high you're trapped." The imbalance reversal signal identifies the exact bar where the trap was set. (v181, [17:36]) [REPEATED]
- **Conditions change mid-bar**: traders looking only at OHLC miss that the early part of a bar may show strong buying, but the close of the bar reveals the reversal happened inside the bar. "A bar that started out bullish early but changed during the bar formation and turned bearish." The trapped traders bought the early strength and are now underwater. (v182, [22:07]) [REPEATED]
- **Late buyers at the wick extreme** (small print trap): the "one contract" buyer at the high is the last trapped trader — "only one person interested" at that extreme level; the rest have already stopped buying. (v182, [38:04]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

- **Small print + follow-through selling**: after a small print at a high (bearish), the "go" signal is the next bar opening lower or the selling imbalance appearing in the next bar. Example: "by looking at the clue was here in the small print … on the third time there was only one person interested and the market reversed." (v182, [38:38]) [ONCE]
- **Imbalance reversal signal bar close**: "this is the beauty of the software it does the analysis for you tells you there's an imbalance reversal" — the signal is generated on bar close (software arrow appears). Entry on close of the signal bar or the next bar open. (v181, [16:58]) [REPEATED]
- **Multiple buying imbalances at swing low**: entry as the multiple-imbalance bar closes or on the next bar. "In the next bar … starts working its way back up." (v182, [52:10]) [REPEATED]
- **Delta of near-zero at a swing high + selling imbalances appearing**: "you're just looking for some sort of trigger to come in and tell you to get short the market's not going any higher." The "trigger" is described qualitatively (some additional confirmation), not prescribed specifically. NEEDS-OPERATIONALIZATION. (v182, [24:38]) [ONCE]
- **Bullish prominent POC on pullback in an uptrend**: "if you get long right you're getting long in the next bar you know we're on the 77 area" — entry on the next bar after bullish prominent POC appears during a pullback in an uptrend. (v182, [1:03:17]) [ONCE]
- **Small print at HOD/LOD (daily extreme)**: "one of my favorite trades is the small print at highs or lows or lows of daily are fantastic but they could be swing highs or swing lows." Entry after the small print appears, stop just below the print. (v182, [1:03:47]) [ONCE — explicit favorite]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Immediate directional move (no retest of extreme)**: for the market sweep, "when a sweeping activity where it doesn't come in and retrace it you know it's going to give you an indication of potential market direction." A swept level not being revisited = momentum confirmation. (v182, [32:17]) [ONCE]
- **POC migrating in trade direction**: after entry on a short, the POC on subsequent bars should migrate lower ("lower point of control telling you that people are happy to trade at lower prices"). (v182, [36:56]) [ONCE]
- **Delta turning in trade direction**: after bullish entry, next bar delta should be positive or strengthening; for bearish entry, delta should be negative and growing. Examples: "minus 102 … minus 578 then here minus 1400." (v182, [55:42]) [REPEATED]
- **Price staying above bullish prominent POC on pullback**: "when you take a step back … we had a swing low market is rallying up got a pullback and in this pullback this is that green bar where you had the point of control that mattered right down in here it's coming into an area where it's met support on a move up — that's bullish." (v182, [1:03:17]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Stacked selling imbalance at a swing LOW context**: "I got a stack selling a balance market should go lower but it didn't." Reading the stacked imbalance as bearish without context of the prior move is the error. A stacked selling imbalance at a swing low after a large down move is NOT an automatic short. (v182, [54:05]) [REPEATED — digest nuance reinforced with example]
- **Strong aggressive buying appearing after a bearish small print setup**: "five buying imbalances here you've got a single print here … price rejection … all systems go right well where'd it go — went nowhere, just went up three ticks past the previous bar." When bullish signs appear immediately after bearish small print signals, the bearish thesis is temporarily stalled (but then confirmed by the small print overriding). Lesson: context and sequence matter — small print at the top of bullish imbalance bars = bearish price rejection despite bullish order flow inside bar. (v182, [39:11]) [ONCE]
- **Delta not flipping negative after bearish setup**: the key kill-signal for a bearish thesis is that delta remains strongly positive even after the entry. If buyers keep pushing (large positive delta), the setup has failed. (v182, [55:07]) [IMPLIED]
- **One tick violation of swing extreme (ambiguous)**: market poking one tick above the prior bar's high before reversing — this is described as normal (the trap is set by one tick, not a full breakout). One-tick violation alone does not invalidate; sustained move above does. (v182, [18:21]) [ONCE]

---

## M. Stop / risk / target / trade management

- **Stop for small print at daily low**: "your stop is just right below this small print right here" — 1-tick (or minimal distance) beyond the small print extreme. (v182, [1:04:16]) [ONCE]
- **Stop for multiple-imbalance bullish setup**: "you've got a very tight stop … stop around fifty-five and a half" when entry is around 57–58 = ~2 points stop on ES. (v181, [27:07]) [ONCE]
- **Stop for imbalance-reversal short**: "you're risking what a point, short at 11 stop at 12 it only comes up to 11 and three quarters and sells off." ≈1 point stop on the YM. (v182, [18:52]) [ONCE]
- **Trailing stop behind POC clusters**: "you're trailing your stop right behind … off the second box your stops just right up here, off the third one your stops just right up here." Stop trails just above the most recent POC cluster zone as price moves in favor. (v181, [31:16]) [ONCE — specific trailing mechanism]
- **Target described only as "10–15 ticks or more"**: "order flow shows you areas where the market can back up to and hold before continuing on in its original direction for another 10-15 ticks or more." Qualitative range; no exact formula. NEEDS-OPERATIONALIZATION. (v181, [28:08]) [ONCE]
- **Don't enter off big bars**: "I probably wouldn't have because it's just such a big bar I don't like to get short off of big bars." Explicit avoidance rule for large-range candles regardless of signal. (v182, [1:05:12]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Cash session 8:30–3:00 CT referenced as normal**: "during the trading day cash session you know 8:30 to 3 o'clock Chicago time there's a lot of volume … sweeps are a little hard to see." Overnight session (examples near 10 PM) = lower volume → sweeps more visible. (v182, [29:14]) [REPEATED — reinforces known filter]
- **Overnight session better for spotting sweeps**: "at nighttime sometimes you know this is why I talked about seeing unusual order flow activity … this was last night around just before 10 o'clock right there was a little sweeping action happening." Lower volume overnight makes sweep footprints more distinguishable. (v182, [29:48]) [ONCE — new nuance for sweeps]
- **10-year notes as reference instrument for small prints**: "when you see small prints in the 10 years you really got to pay attention to them because normally at each price level 10 years trade you know what a thousand a couple thousand contracts … you have two here right." In a high-volume instrument, a print of "2" is extreme rejection. Explicitly more significant than in thinner markets. (v182, [43:17]) [ONCE]
- **Swing high / swing low as primary context for all signals**: "any time a market hits a swing higher swing low you should be watching what's happening in the order flow." All signals evaluated in context of whether price is at or near a swing extreme. (v182, [1:01:50]) [REPEATED]
- **VIX commentary** (2020 context): VIX in low 30s at the time; mentions "if we get VIX down into a more manageable 20 you know 15 to 25 area I think the markets will really calm down." Trading in elevated VIX (30+) environment during these presentations. (v181, [45:33]) [ONCE — contextual note, not a filter rule]
- **Daily high/low as highest-priority location for small print**: "lows of daily are fantastic." The daily extreme is the top-tier context for the small print signal. (v182, [1:03:47]) [ONCE]

---

## O. Directly testable / measurable variables

- **Imbalance ratio threshold**: ≥4:1 default (stated as industry standard); 10:1, 5:1, 3:1 also mentioned; 2:1 likely not useful. (v181, [09:01]; v182, [10:04]) [REPEATED — reinforces known value]
- **Stacked/multiple imbalance count**: ≥3 imbalances in a bar = software box (pink = stacked; violet/magenta = multiple). (v181, [13:47]; v182, [11:56]) [REPEATED]
- **Small print threshold**: software parameter — examples show threshold ≤9 contracts triggering a box. One contract at extreme confirmed as valid trigger. (v182, [35:18]) [ONCE — ≤9 threshold stated explicitly for this setting]
- **Delta near-zero at swing extreme**: delta of 8 on volume ~1,000–2,000 = effectively neutral = warning of hidden opposing flow. NEEDS-OPERATIONALIZATION: absolute delta value depends on instrument/volume. The ratio of |delta|/volume is the operative measure. (v182, [19:27])
- **Delta cascade multiplier**: –102 → –578 (5×) → –1400 (2.4×) as sequential bars = trend resuming strongly. NEEDS-OPERATIONALIZATION: no stated threshold for when the cascade becomes "significant." (v182, [55:07])
- **POC alignment score**: 7/9 or 8/9 possible POC levels (across 3 bars × 3 POC levels each) aligned at same zone = "important information." Formula: count of POC levels (main + 2nd + 3rd) from N bars that fall within a defined price range. (v181, [29:40]) NEEDS-OPERATIONALIZATION: range tolerance unstated.
- **Market sweep detectability**: sweeps easier to detect in overnight (low volume) vs. cash session (high volume). No specific volume threshold stated. (v182, [29:14]) NEEDS-OPERATIONALIZATION.
- **Stop distance**: 1 tick beyond extreme for small print; ~1–2 points for ES/YM imbalance setups (from examples). (v182, [1:04:16]; v182, [18:52])
- **Target range**: "10–15 ticks or more" from POC-cluster support/resistance. NEEDS-OPERATIONALIZATION. (v181, [28:08])
- **"Doesn't retrace" (sweep confirmation)**: a sweep that holds and doesn't fill back in = directional confirmation. NEEDS-OPERATIONALIZATION: what constitutes "doesn't retrace" — number of bars, % of move, etc.? (v182, [32:17])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Multiple POC levels (2nd and 3rd POC) per bar**: software can display up to 3 POC levels per bar. Main POC = most volume; 2nd and 3rd POC = second/third most. Colors: green (strongest), yellow (second), red (third) — "traffic light" scheme. Transparency settable. (v181, [27:07]) [ONCE — implementation-level detail]
- **Pink box = stacked imbalance (≥3 stacked)**: hard-coded in software; box drawn around any bar with ≥3 imbalances that are stacked neatly. (v181, [13:47]) [REPEATED]
- **Violet/magenta box = multiple imbalances (≥3 spread)**: drawn around bar with ≥3 buying or selling imbalances regardless of stacking. (v182, [22:35]) [REPEATED]
- **Imbalance reversal arrows (green up / red down)**: software detects condition mid-bar where direction changed and highlights with colored arrow. Fires on bar close (the "footprint that's left early in the bar"). (v181, [16:58]; v182, [21:34]) [REPEATED]
- **Small print box (red for bearish, green for bullish)**: software draws colored box around any print at bar extreme below a volume threshold (settable; examples show ≤9). (v182, [35:18]) [ONCE — box color specification]
- **Prominent POC colored indicator (magenta/red)**: prominent POC displayed in magenta/red color vs. normal POC. Bearish prominent POC = magenta/red; bullish = presumably different color (green implied). (v182, [22:35]; v182, [47:12]) [REPEATED]
- **Sweep detector**: software can highlight "potential sweep" based on criteria (exact criteria undisclosed — "based on you know certain criteria when a sweep occurred"). (v182, [29:14]) [ONCE]
- **Seven pre-programmed indicators** (2020 count): confirmed again — imbalance reversal, multiple imbalances, prominent POC, small prints, sweep detector, volume imbalance, and likely delta divergence/volume ratios among the seven. (v182, [49:18]) [REPEATED]
- **Volume profile / volume profile on the side**: mentioned as a separate tool, less precise than per-bar POC analysis for detecting migrating value. (v181, [31:43]) [ONCE]
- **Imbalance reversal fires "early in bar formation"**: the signal captures order flow that happened before the bar closes. "It takes that footprint that's left early in the bar … it sorts of splits up the bar." Implementation note: the signal must read intrabar data (not just bar close). After bar close, the signal is stable/non-repainting. (v182, [22:36]) [ONCE — implementation timing detail]

---

## Q. Notable verbatim quotes

1. "The market's getting to a certain level and trading has dried up … I call that price rejection some people say well the market is getting exhausted on that move up … there's two ways to look at the same thing." (v182, [33:45]) — defines small print as price rejection AND exhaustion, explicitly treating them as equivalent.

2. "Delta is small it's eight it's eight what's that telling you … you should be looking you know if there wasn't active aggressive sellers selling into the bid … instead you're seeing a delta of 8 and 8. So I know that even though I see the buying and balances the aggressive buying there's also aggressive selling in the bar." (v182, [19:27]) — near-zero delta despite buying imbalances = hidden opposing flow.

3. "Conditions change mid bar right a bar that started out bullish early but changed during the bar formation and turned bearish right … traders oftentimes overlook that part … and it's what makes imbalance reversal so powerful is because it takes that footprint that's left early in the bar." (v182, [22:07]) — the whole imbalance reversal concept in one passage.

4. "You got to take things in context of the market okay yeah I know I got aggressive selling the market's going down so I'm not really concerned with looking at a stack selling a balance or multiple selling balances you know at a swing low I'd be looking at multiple buying imbalances off a swing low." (v182, [54:05]) — explicit context rule: direction of prior trend determines which signals are relevant.

5. "The supply is hidden in here you can't see it you can see it in the delta that's why you got the positive deltas right so the aggressive buyers buy it and they get tired they stop buying let the market breathe comes off some more." (v182, [57:42]) — mechanism of positive-delta-down move.

6. "One of my favorite trades is the small print at highs or lows or lows of daily are fantastic but they could be swing highs or swing lows." (v182, [1:03:47]) — explicit tier-1 setup naming.

7. "Don't ignore the wicks right look at the volume that's transacted in the wicks it's very revealing to what's happening." (v182, [59:08]) — anti-candlestick advice: wick volume > wick shape.

8. "When a sweeping activity where it doesn't come in and retrace it you know it's going to give you an indication of potential market direction." (v182, [32:17]) — sweep validity condition: no retrace = directional.

9. "If you look at the order flow it becomes a lot clearer … you have two points a and point B point a of multiple selling imbalances in the bar they're not stacked so you don't see stacks on a balance in the bar but instead you see one two three imbalances." (v181, [20:02]) — explicit comparison of stacked vs. multiple imbalances as distinct signals.

10. "Any time a market hits a swing higher swing low you should be watching what's happening in the order flow in the volume specifically in the order flow." (v182, [1:01:50]) — universal context rule for signal application.

---

## R. Contradictions / nuances

- **Stacked selling imbalance at LOW = bullish (price rejection down)**: contradicts the surface reading that stacked selling imbalance = bearish. The context (at a swing low after a down move) flips the interpretation. "Market had a stack selling imbalance market rebounded up so price is being rejected down here." (v182, [15:37]) — nuanced, conditional on location.

- **Positive delta while price falls = bearish (not bullish)**: explicitly described as an "advanced concept" — buyers absorbing hidden passive supply. Standard interpretation (positive delta = bullish) is wrong in this context. Only when the passive supply is worked on the offer (not bid) does this occur. (v182, [56:15])

- **Buying imbalances in a bar going DOWN at a swing low does NOT automatically mean reversal**: "I've got a multiple buying imbalances coming in there… but then okay I look at the other parts of the order flow … delta 770 108 132 minus 102 minus 578 minus 1400 stack selling and balance in here … do I think this market is getting ready to rally off the swing low — No." (v182, [54:05]) — multiple buying imbalances overridden by delta deterioration. Contradicts a simple "multiple imbalances at low = buy" rule.

- **Imbalance reversal fires INTRABAR**: the signal documents what happened early in the bar, before bar close. This means the software is reading intrabar order flow, not just bar-close data. After bar close the signal is stable (no repaint). This subtly contradicts any assumption that all order flow signals are purely bar-close readings. (v182, [22:36])

- **Small print at high inside bullish-looking candles = bearish price rejection**: visually bullish (up-close candle, positive delta, buying imbalances) but bearish at the margin because of the tiny print at the top. The visible bullishness masks the exhaustion. Explicitly said: "if you're looking at the candlesticks you're thinking well you know hey these are actually bullish looking candlesticks but if you're looking at the order flow you can see that there's price rejection." (v182, [40:19])

- **Don't get short off big bars**: entry rule that limits signal chase on large-range bearish candles regardless of order flow quality. Tension with "follow the signal" philosophy — sometimes the best order flow signal occurs within a big bar, but the stop placement becomes impractical. (v182, [1:05:12])

- **Sweeps harder to see in cash session**: the "unusual activity" of a sweep is most visible in the overnight/low-volume session. During the cash session, sweeps still happen but are harder to isolate because volume is high. This creates a session-dependent utility for the sweep signal. (v182, [29:14])

---

## Coverage note

- v181 is primarily a webinar/marketing presentation (InvestorExpo, May 7, 2020) covering foundational concepts (delta, POC, imbalances, imbalance reversal, multiple imbalances, POC clusters/migration) with practical e-mini examples. Rich on POC cluster/migration detail and entry-timing discussion, but thinner on direct grading language.
- v182 is a dedicated educational webinar (May 28, 2020) on "unusual order flow activity" and is the richer of the two for novel signals: small prints, market sweeps, positive-delta-down mechanism, and small-print-at-daily-HOD/LOD as the stated favorite setup. Several unique and operationally specific examples.
- Both videos share substantial introductory overlap (Mike's background, three building blocks, software pitch). The model content concentrates in the second halves of each video.
