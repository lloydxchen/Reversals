# Chunk 079 Extraction
- Source chunk: Chunk_079_Orderflows_Transcripts.md
- Transcripts covered:
  - v245 — What To Look For In The Order Flow On 10 Minute Footprint Charts Using Orderflows Trader (2022-04-07)
  - v246 — Understanding How Big Orders Trade In The Order Flow Using Orderflows Trader For NinjaTrader 8 (2022-04-08)
  - v247 — Trading The Order Flow Delta Footprint Chart With Orderflows Trader 5 For NinjaTrader (2022-04-12)
  - v248 — What Did The Delta Scalper Do In MES, GC and 6E (2022-04-14)
  - v249 — Order Flow Highlights ES April 18 and 19 2022 NinjaTrader 8 Orderflows Trader 5 (2022-04-19)
  - v250 — How To Set Up Orderflows Delta Scalper With Markers From The Indicator Store (2022-04-20)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Stacked imbalance (buying or selling) — continuation or reversal context**: Three or more imbalances stacked neatly on top of each other. On longer-term charts (10-min) the market will often pull back into the stacked imbalance before continuing in the direction of the imbalance. (v245, "10 Min Footprint Charts", [03:00]) [REPEATED]
- **Exhaustion print — bearish reversal at high / bullish reversal at low**: Very thin volume (≤5 on 10yr, scale-adjusted per market) appearing at swing high or swing low signals sellers/buyers are "getting tired." (v245, [09:00]) [REPEATED]
- **Thin print — confirmation of one-sided momentum**: Inside a running bar, offer side (on down move) or bid side (on up move) prints near-zero, indicating no counter-side interest to slow the move. (v245, [10:34]) [ONCE]
- **Order flow sequencing (bullish/bearish) — entry filter**: Green boxes = bullish order flow inside the bar; red boxes = bearish. Used to confirm direction at swing extremes. (v245, [13:54]) [ONCE]
- **Big size / heavy delta absorption — bullish reversal at low**: Passive big bids absorb aggressive selling at a low; negative delta bar that nonetheless holds support and sets up a long. (v246, "Big Orders", [02:10]) [REPEATED]
- **Big offer appearing at resistance — bearish reversal at high**: Large passive offers appear at a well-defined high after a rally; aggressive buyers lift offers but market fails to advance — supply absorbing buying. (v246, [10:35]) [REPEATED]
- **Delta footprint (horizontal delta) reversal cue**: Very large delta difference at price on the offer side during a down move = sellers driving the market lower (supply present). Large delta difference on the bid side at a low = buyers absorbing selling. (v247, "Delta Footprint", [06:51]) [ONCE]
- **Delta Scalper buy/sell signals**: Algorithmic tool flagging when buyers are drying up / sellers getting stronger (sell signal) or sellers weakening / buyers dominating (buy signal). Analyzed via relationship between sequential delta numbers. (v248, "Delta Scalper", [01:27]) [REPEATED]
- **Multiple imbalances (spread in bar) + prominent POC — bullish reversal**: Multiple buying imbalances spread across several levels within a single bar (not necessarily stacked consecutively) combined with a prominent/sticky POC at the low of a sell-off. The setup differs from stacked imbalance — called "multiple imbalances." (v249, "ES Highlights", [10:57]) [ONCE]
- **Delta shrinkage sequence into a high — bearish reversal**: Delta at new highs declines bar-over-bar (e.g., 1300 → 126 → 39), with a red (down) candle showing positive delta being absorbed by passive supply. Signal requires at least two-bar confirmation before acting. (v249, [15:55]) [ONCE]
- **Negative delta bar at a low that holds support — bullish reversal**: A bar with strongly negative delta that does NOT break below the nearby support level; the negative delta is explained by passive bids absorbing aggressive sellers, not by trend-continuation selling. (v249, [12:28]) [REPEATED]

---

## B. Tiering / grading language  ← HIGH PRIORITY

- "**nice stacked imbalance**" — three clean consecutive imbalances with the market returning to the imbalance level and continuing. (v245, [03:00]) [REPEATED]
- "**nice actionable stacked buying imbalance that you can trade off of**" — criterion: occurs inside the day's range (not at a new high/low breakout), on a longer-term chart. (v245, [05:57])
- Not graded as A+ on 10-min charts if: the stacked imbalance appears as the market is "taking out new highs" (breakout continuation); Mike says he is NOT looking for those on 10-min charts, only imbalances that form within the day's range. [ONCE] (v245, [13:21])
- "**interesting size**" (gold ~30+ lots at time of day, euro ~100+, e-mini 231–579+) — the bar with above-average delta/volume that catches his eye for a potential reversal. (v246, [01:33]; v247, [13:34])
- "**just having one bar with a big order in there that trades through is not always enough to go on**" — single-bar big volume is not A+; he waits for context and follow-through. (v246, [10:08]) [REPEATED]
- "**this one bar by itself just not enough to go off of — wait for the next bar**" — confirmed two-bar pattern requirement for delta divergence at high. (v249, [15:02]) [REPEATED]
- "**this positive delta of three might as well be minus 300 for all intents and purposes**" — near-zero positive delta in the context of a high is functionally bearish. (v249, [15:30]) [ONCE]
- "**boom the bottom just drops out**" — describes strong follow-through after delta exhaustion at high (minus 1300 after a 1300 → 126 → 39 shrinkage). (v249, [17:32])
- Mediocre / skip criteria: volatile markets (e.g., stock indices on 10-min) with "much bigger risk tolerance" required; no clear stop level. (v245, [03:54]) [ONCE]

---

## C. Order-flow story & psychology per setup

- **Stacked imbalance at HOD/LOD — continuation or support/resistance**: "This is where you had aggressive buying earlier" — markets pull back to imbalance levels because natural buyers/sellers remain at those prices. The memory of aggressive volume creates the S/R. (v245, [16:27]) [REPEATED]
- **Big passive bid absorbing aggressive sellers at a low**: Sellers hit bids thinking price is going lower; passive buyer absorbs everything. When aggressive selling stops, aggressive buying takes over. "Not much on the aggressive buying to move the market higher" — the passive absorption does the work, not a large aggressive buyer. (v246, [08:03]) [REPEATED]
- **Supply absorbing buying at a high**: "Smart money" loaded with supply, happy to sell to "dumb money" aggressive buyers who are convinced market will break out. Once aggressive buyers "realize they can't get it to go higher, they start selling." The bar reverses quickly. (v249, [05:36]) [REPEATED]
- **Negative delta at low ≠ bearish**: When negative delta at a low is caused by passive bids absorbing aggressive sellers, it signals support, not continuation lower. "I'm not panicking at oh negative delta minus 500 should be looking to get short — no, why is it negative? Because you have people coming in there absorbing that selling." (v249, [12:28]) [ONCE — explicit verbatim explanation]
- **Delta shrinkage at HOD**: Buyers "running out of bullets." After successive new highs with declining delta, supply absorbs the final wave of aggressive buyers; the bar reverses and sells off sharply. (v249, [04:40]) [ONCE]
- **Delta footprint — offer side during down move**: Big offer-side delta in down bars = sellers "dumping it because they think price is going lower," not just passive bids getting hit. Confirms trend or signals further selling ahead. (v247, [07:52]) [ONCE]

---

## D. Exhaustion clues

- Exhaustion print threshold on 10yr (10-min chart): **≤5 lots** (could be 5, 4, 3, 2, or 1). This contrasts with normal 10yr volume of "thousands" per level — the extreme contrast makes the signal meaningful. (v245, [09:00]) [REPEATED]
- Exhaustion prints in "normal market hours" (European open to US close) carry more weight; less emphasis on Asian session exhaustion prints. (v245, [18:28]) [ONCE]
- On 10-min chart: "ideally you want to see them at swing highs or swing lows" — exhaustion prints in the middle of a move carry less weight. (v245, [09:44]) [REPEATED]
- Delta "dries up" at a high: After a run to new highs with delta declining (1300 → 126 → 39), the final bar in the sequence represents exhaustion of buying — "the buying just dried up." (v249, [15:55]) [REPEATED]
- Near-zero positive delta at a high ("positive delta of three") = functionally exhaustion even if not an exhaustion print in the traditional sense. (v249, [15:30]) [ONCE]

---

## E. Absorption clues

- **Big passive bid absorbing aggressive sellers**: Negative delta bar at a low with above-average bid-side volume. The bid-side volume number is the tell — "1574 on the bid side right at this area of 43 65 and a half." (v249, [12:28]) [REPEATED]
- **Supply absorbing at a high (passive offers)**: Green candle with positive delta but market reverses — indicates passive sellers (offers) absorbing aggressive buyers at resistance. "Supply is now coming into the market." (v249, [04:09]) [REPEATED]
- **Delta footprint absorption indicator**: On a delta footprint chart, large offer-side delta during a down move indicates supply absorbing buying attempts (sellers offering into bounces). Positive bid-side delta during bounce attempts that keeps failing = supply has not been cleared. (v247, [09:16]) [ONCE]
- "I don't want to use the term absorption because that term gets distorted a lot nowadays in order flow" — he uses it but is careful to distinguish passive bid/offer action from aggressive action. (v247, [09:45]) [ONCE — important nuance]

---

## F. Stacked imbalance ideas

- On **longer-term charts (10-min, 15-min)**: stacked imbalances still form the primary order-flow signal; the limitation is timing — by the time a 10-min bar closes, the "nice 10-point move" off the imbalance has already occurred. He favors shorter charts specifically to act on stacked imbalances faster. (v245, [05:57]) [ONCE]
- **Overlapping stacked imbalances** (volatile markets like e-mini): the next bar overlaps the stacked imbalance area rather than holding precisely; this is normal behavior in more volatile markets. The setup still works but requires "let the market start going in the direction of that imbalance." (v245, [04:27]) [ONCE]
- **Pullback-to-imbalance entry**: "One of the ways to play stacked buying or selling imbalances is for a pullback to that imbalance — you just sit there with a bid" above the imbalance (a tick or two above the top of the imbalance). (v245, [06:55]) [REPEATED]
- Stacked imbalance as **S/R reference**: "People always wonder why does the market come back to this level — that's where you had aggressive buying earlier." The imbalance zone acts as support on pullbacks. (v245, [16:27]) [REPEATED]
- He explicitly distinguishes **"stacked imbalance"** (3+ consecutive levels) from **"multiple imbalances"** (buying imbalances spread non-consecutively within a bar). The multiple-imbalance in v249 is NOT a stacked imbalance even though it triggers the magenta box signal. (v249, [10:57]) [ONCE]

---

## G. Delta / delta-divergence ideas

- **Delta bar-by-bar sequence at a high (bearish)**: Pattern = new high with strongly positive delta → slightly positive or small positive → near-zero positive → strongly negative. This progression signals buyers are exhausting. The reversal confirmation is: large negative delta bar AFTER the shrinkage sequence. (v249, [15:55], [17:01]) [ONCE — detailed sequence]
- **Delta bar-by-bar sequence at a low (bullish)**: Sustained negative delta (500–875 range) on way down; then small positive deltas appearing (39, 67, 60, 53, 85); then transition to large positive deltas (250, 900, 500); then negative delta again but this time with support (passive bids). Market turns from there. (v249, [07:37], [12:28]) [ONCE]
- **Red candle + positive delta = supply absorbing**: Positive delta on a down candle at a high means passive sellers absorbed aggressive buyers; bullish interpretation of positive delta is wrong in this context. (v249, [04:09]) [REPEATED]
- **Negative delta on up bar does NOT mean it can't go higher**: If the negative delta is caused by passive bids absorbing aggressive selling, the underlying support is bullish. (v246, [07:37]) [REPEATED]
- **Delta footprint chart** (horizontal delta): Shows net delta at each price level (bid minus offer at that price). Above-average delta on the offer side during a down move = supply driving the decline. Above-average delta on the bid side at a low = buyer coming in. (v247, [00:29]) [ONCE]
- **Delta Scalper tool settings**: Default = 7, 1, 1 (lookback 7, negative strength 1, positive strength 1). Practical settings used: 1-1-1, 0-2-2. Strength levels double with each increment (1→2 = 2x, 2→3 = 4x effective, etc.). Higher strength = fewer but more significant signals. Lookback = swing high/low filter; turning it off (0) generates many more signals but loses the swing filter. (v248, [02:25], [05:31]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Multiple failed attempts at HOD — bearish reversal**: ES made 4 attempts at the same high (9:26–9:46 window). Each attempt showed declining or negative delta. The pattern = market testing resistance, supply absorbing each wave, eventually sellers win. (v249, [01:25], [04:40]) [ONCE]
- **Failed breakout signal**: "The last burst of aggressive buying coming in here but it's met with supply in the market — it's met with strong passive sellers." Green candle with positive delta at HOD that closes lower = classic failed breakout. (v249, [05:07]) [REPEATED]

---

## I. Trapped-trader ideas

- **Buyers trapped at HOD**: Aggressive buyers "running out of bullets" after multiple failed attempts to push price higher; when they "realize they can't get it to go higher, they start selling" — trapped longs adding to downside momentum. (v249, [05:36]) [REPEATED]
- **Aggressive sellers trapped at a low**: Sellers hit bids thinking price continues lower, but passive big bids absorb all selling; when aggressive sellers exhaust, aggressive buying takes over and sellers are trapped short. (v246, [03:45]) [REPEATED]

---

## J. Entry triggers (the exact "go" event)

- **Stacked imbalance pullback**: Place limit bid "a tick or two above" the top of the stacked buying imbalance zone when the market pulls back into it. Passive limit entry. (v245, [06:55]) [REPEATED]
- **Big bid confirmation + next-bar continuation**: After seeing a large passive bid print, wait for the market to hold above that bid area (not pull back more than 2 ticks) and then show continued buying in the next bar before entering. "All you got to do is wait for the market to give you some sort of confirmation this could be supportive." (v246, [12:08]) [ONCE]
- **Delta sequence confirmation at high — entry on bar close**: After seeing delta shrink across 2-3 bars at HOD, wait for the bar where "the bottom just drops out" (strongly negative delta); entry on close of the first strongly negative delta bar following the shrinkage sequence. (v249, [17:32]) [ONCE]
- **Multiple imbalances + prominent POC + negative delta with support**: Three conditions together at a low form the "go" event — prominent POC sticking out, magenta box (multiple buying imbalances spread in bar), and negative delta explained by passive bid absorption. (v249, [10:57]) [ONCE]
- **Delta Scalper automated entry**: Signal fires in real time when the delta relationship meets conditions; "allows you to get in at the earliest possible time." Can be automated via Markers (indicator store integration). (v248, [01:27]; v250, [00:00]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- After entering on a stacked imbalance pullback: market should hold the imbalance level (not trade through it) and begin moving in the direction of the imbalance on the next bar. (v245, [04:56]) [REPEATED]
- After seeing big passive bid at a low: "Supportive buying coming in here — the support can hold, the market go higher." Next bar should show continued bid-side action and no expansion below the absorption level. (v246, [11:40]) [REPEATED]
- After delta shrinkage at high and first strongly negative bar: "Market drops, comes back up, makes that attempt to come back up, it's testing this zone here — this value area zone — and just trades right into it then drops back down." The retest-and-fail of the value area on the down move is the confirmation. (v249, [17:32]) [ONCE]
- After multiple-imbalance + prominent-POC reversal: "Came right back into that zone — carbon copy — right into that zone from 65 to 66, this zone is drawn from 66 to 64 and three quarters, and that's where the rally started." Precise zone hold is the confirmation. (v249, [11:57]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Stacked imbalance pullback: If the market trades through the imbalance zone without holding, the thesis is dead. (v245, [07:22]) [REPEATED]
- Big passive bid at a low: If market pulls back significantly below the big-bid level (e.g., more than 2-3 ticks through it), support has failed. "We shouldn't dip much below the 1080 level and it just goes two ticks lower — it didn't come down here to 76 or 75." Two ticks lower = acceptable; more = invalidation. [SPECULATIVE threshold] (v246, [12:36]) [ONCE]
- Delta shrinkage at high: If, after the shrinkage sequence, a new bar shows a return to large positive delta AND the price makes a new high, the thesis is wrong. (v249, [15:02]) [ONCE — implied]
- Thin print: If a thin-print area on the way up is subsequently filled in with normal volume on a retest, the significance diminishes. (v245, [16:54]) [ONCE — implied]

---

## M. Stop / risk / target / trade management

- **Stop on stacked imbalance pullback**: "On the other side" — i.e., just below the bottom of the imbalance zone. (v245, [07:22]) [REPEATED]
- **Delta Scalper ATM settings (playback demo)**: Stop = 13 ticks (MES), take profit = 26 ticks (MES). This is a 1:2 risk-reward. (v250, [08:00]) [ONCE — specific numbers]
- **Discretionary exit based on order flow**: "If the order flow starts changing, that's your sign to get out of the trade… nobody putting a gun to your head that says you have to let it go to your target." He prefers watching the order flow and exiting when it turns rather than holding to automated stop/target. (v250, [06:21]) [REPEATED]
- **Target reference**: At a low reversal, the prior "old business" (where profit-taking occurred on the previous rally) is a natural target; new buyers coming into the market after old sellers exit the prior rally is the setup. (v246, [13:36]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **10-min charts: best traded during cash hours** (US equity session); "stacked imbalances, exhaustion prints, thin prints in normal market hours — or at least from the European open until the US close." Signals during Asian hours are lower quality for most markets except select Asian instruments. (v245, [05:25], [18:28]) [REPEATED]
- **Instrument filter for order flow viability**: He explicitly says "me personally I probably wouldn't look at using order flow on stock indices just because it's kind of volatile" — even though stacked imbalances form, the risk (stop size due to bar size) is too large on e-mini 10-min charts. 10yr is preferred for 10-min order flow work. (v245, [03:54]) [ONCE — new explicit statement]
- **Asian market institutional thin-ness**: "In Asian hours the bigger traders that help move the markets just aren't there as much" for e-mini/index markets; Asian session more relevant for Asian instruments (China, Japan). (v245, [18:28]) [ONCE]
- **Relative volume context required**: What is a "thin print" or "big volume" is market-specific and time-specific. Gold intraday double-digit normal; 10yr thousands normal; e-mini hundreds normal. Must learn the market's typical volume range. (v245, [12:11]; v246, [00:27]) [REPEATED]
- **HOD/LOD as primary location filter**: Trading near HOD → looking for reasons to sell; near LOD → looking for reasons to buy. "I'm always looking for reasons for potentially selling" at HOD, "sure the market can keep going higher but if I'm at the high of the day sooner or later you're going to put in the high of the day." (v245, [14:26]) [REPEATED]
- **Value area zone as S/R**: Price that returns to a prior value area zone (drawn from earlier in the session) is a meaningful test; if order flow shows support/resistance at that zone, it provides a high-conviction entry. (v249, [11:25]) [REPEATED]
- **Current Day Open High Low Close reference**: He uses NinjaTrader's free "Current Day Open High Low Close" indicator as a basic intraday reference for HOD/LOD context. (v249, [01:25]) [ONCE — tool tip]

---

## O. Directly testable / measurable variables

- Exhaustion print threshold (10yr, 10-min): ≤5 lots per price level. [REPEATED]
- Thin print threshold: market-relative; in 10yr when normal is 3,000–5,000/level, anything in low double digits (20–30) is not thin; look for single digits or low teens. In gold, ≤3–7. In euro currency, ≤2–7. NEEDS-OPERATIONALIZATION (exact per-instrument cutoff) (v245, [12:11])
- Stacked imbalance: 3+ imbalances consecutive. Already known. [REPEATED]
- Multiple imbalances (non-consecutive in bar): 3+ buying or selling imbalances appearing at different levels within the same bar (triggers magenta box in OFT). (v249, [10:57]) NEEDS-OPERATIONALIZATION (exact detection logic for "spread" vs "stacked")
- Prominent POC: POC highlighted in cyan (vs. normal black) in OFT — signals a POC that "sticks out" from prior session activity and acts as a support/resistance reference. (v249, [09:14]) NEEDS-OPERATIONALIZATION
- Big volume threshold (gold, ~11:30 CT): anything over 30 lots catches attention. (v246, [01:33]) NEEDS-OPERATIONALIZATION (time-of-day dependent)
- Big volume threshold (euro currency, ~9:00 CT): anything above 100 lots. (v246, [09:07]) NEEDS-OPERATIONALIZATION
- Big delta threshold (e-mini, 1-min): 231–579 lots is "decent" to "big." (v247, [13:34]) NEEDS-OPERATIONALIZATION
- Delta Scalper parameters: lookback 0/1/7; strength 1 or 2 (preferred); strength doubles each increment. Settings used: 7-1-1 (default), 1-1-1, 0-2-2. (v248, [02:25], [05:31])
- Delta shrinkage sequence (bearish HOD): Prior bar delta >> next bar delta >> near-zero (e.g., 1300 → 126 → 39 → -1300). No specific ratio defined; directional shrinkage is the signal. NEEDS-OPERATIONALIZATION (ratio or % decline) (v249, [15:55])
- Value area zone reference: Prior session value area zones drawn as horizontal bands on chart; used as S/R. Width ~1–3 ticks in examples shown. (v249, [11:25])
- Delta Scalper stop/target (MES playback demo): 13 ticks stop / 26 ticks target (1:2 R:R). [ONCE — demo context only]

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Order Flow Sequencing indicator** (already in OFT): Green boxes (bullish sequencing) and red boxes (bearish sequencing) inside bars. Can be added to 10-min charts to identify directional momentum shifts at swing extremes. (v245, [13:54]) [ONCE]
- **Four footprint chart types in OFT**: (1) Bid-Ask footprint (standard), (2) Delta footprint (horizontal delta at price — bid delta minus ask delta per price level), (3) Volume footprint (total volume at price), (4) Diagonal delta footprint. Each selectable under "latter content" settings. (v247, [01:36]) [ONCE — implementation detail]
- **Delta footprint (horizontal delta) implementation**: At each price level, show (volume when bid) minus (volume when offered) = horizontal delta. Positive = more aggressive sellers at that price; displayed differently from bid-ask footprint. (v247, [00:29]) [ONCE]
- **Prominent POC rendering**: Cyan color (vs normal black/default) to distinguish prominent POC levels from standard POC. (v249, [09:14]) [ONCE]
- **Multiple imbalances box**: Magenta box drawn around bars containing 3+ buying imbalances (non-consecutive, spread through bar). Pink/magenta = bullish multiple imbalances. (v249, [10:57]) [ONCE]
- **Value area zone drawn from prior bars**: Historical value area zones projected forward as horizontal reference bands. The zone in v249 was drawn from 11:00 AM activity and held as support at ~2:50 PM. (v249, [11:25]) [ONCE]
- **Current Day Open High Low Close (NinjaTrader free tool)**: Referenced as a basic required tool; available free in NT8, used to display HOD/LOD reference lines. (v249, [01:25]) [ONCE]
- **Delta Scalper + Markers automation**: Delta Scalper generates buy/sell plot signals ("positive delta change" = buy, "negative delta change" = sell); Markers (from Indicator Store, by Pablo) reads those plots and automates order entry via ATM strategies. Setup uses two Markers instances (one for longs, one for shorts) referencing the Delta Scalper indicator's data series. Fast signals mode enables real-time signal execution. (v250, [01:25], [02:57]) [ONCE]
- **Markers variable naming convention**: Buy signals variable = "Longs"; sell signals variable = "Shorts"; must match across Markers instances. Calculate on each tick (not bar close) for fast signals. (v250, [01:58]) [ONCE]

---

## Q. Notable verbatim quotes (with citations)

1. "The information that's derived from the order flow is best used as fast as possible — as soon as you get something that looks actionable you should take action, you shouldn't wait for the 10-minute bar to close before you take it." (v245, [00:57])

2. "Stacked imbalances, exhaustion prints, thin prints in normal market hours — that's what you want to be looking for on a 10-minute chart. And sequencing. But when you get into thin prints you should understand the market that you're trading." (v245, [18:58])

3. "It's just not about seeing the big size — it's seeing where the big size came in in relationship to how the market is trading." (v246, [14:09])

4. "I don't want to use the term absorption because that term gets distorted a lot nowadays in order flow." (v247, [09:45])

5. "I'm not panicking at oh negative delta minus 500 I should be looking to get short — well no, why is it negative? Because you have people coming in there absorbing that selling." (v249, [12:56])

6. "This is the smart money up here — they got a lot of supply, they're holding a lot of contracts, they're happy to offer it out up here for all those willing buyers, and once the buyers that are buying the heck out of it trying to get it to go higher realize they can't, they start selling." (v249, [05:36])

7. "You're seeing the delta shrinking: 1300, 126, 39 — that's not the sequence you want to see. You want to see maybe 500, at least three or four hundred here. Instead you're seeing the aggressive selling coming in and then boom the bottom just drops out." (v249, [17:01])

8. "This positive delta of three might as well be minus 300 for all intents and purposes." (v249, [15:30])

9. "Nobody putting a gun to your head that says you have to let the trade go to your target — if the order flow starts changing, that's your sign to get out of the trade." (v250, [06:46])

10. "Each level that you go up from one to two is doubling the strength — so if you go from two to three you're doubling it again; it's not just going up incrementally." (v248, [05:31])

---

## R. Contradictions / nuances (anything that conflicts with common belief, with his other statements, or that is conditional/"it depends")

- **"Negative delta at a low doesn't mean you should get short"**: Explicitly contradicts the naive reading of delta. Negative delta at a support level can be entirely explained by passive bid absorption, making it bullish, not bearish. This is a nuance he flags as frequently misread. (v249, [12:28]) [REPEATED]
- **"Positive delta on a down candle at a high doesn't mean it will go higher"**: When a green-delta bar is a red candle (price closes down), the positive delta is explained by supply (passive offers) absorbing aggressive buyers, NOT by real buying strength. (v249, [04:09]) [REPEATED]
- **He explicitly avoids using the word "absorption" due to distortion**: Despite describing absorption dynamics throughout, he hesitates to use the label in v247, suggesting it has become overused/misused in the order flow community. (v247, [09:45]) [ONCE]
- **10-min chart order flow is structurally suboptimal vs shorter timeframes**: He uses 10-min analysis to teach concepts but explicitly states "the information is best used as fast as possible" — by the time a 10-min bar closes, the actionable move from a stacked imbalance has typically already happened. This creates a tension between his framework (act on bar close) and longer-timeframe use. (v245, [00:57], [05:57])
- **Stock indices (e-mini) are conditionally avoided on 10-min charts**: Despite being the most common futures instrument, he says he "probably wouldn't look at using order flow on stock indices" on 10-min charts due to volatility and risk per bar. 10yr is strongly preferred for 10-min order flow work. This adds an instrument-timeframe interaction that is not explicitly covered in the digest. (v245, [03:54])
- **"Same settings every market" qualifier**: While the digest captures "same settings every market," here he clarifies that thin print thresholds and "big volume" definitions are explicitly market-dependent and time-of-day dependent. The settings (imbalance ratio, etc.) may be universal but the meaning of volume numbers is not. (v245, [12:11]; v246, [00:27])
- **Delta shrinkage is not a one-bar signal**: "One candle by itself probably not enough to go on thinking this market's going to drop — wait for the next bar." The pattern requires at minimum 2-bar (and ideally 3-bar) delta deterioration before acting. (v249, [15:02])

---

## Coverage note

v245 (10-min footprint) and v249 (ES April 18–19 highlights) are the richest for model content — v245 provides the 10-min context filter framework, v249 provides detailed delta-sequence-at-high/low analysis with step-by-step narration. v246 (big orders) contributes useful absorption mechanics. v247 (delta footprint) and v248 (Delta Scalper settings) are primarily tool-demonstration content with limited new model insights. v250 (Markers setup) is almost entirely a platform how-to and contributes only the 13/26-tick stop/target numbers for the MES. All six videos are parseable with no audio quality issues noted.
