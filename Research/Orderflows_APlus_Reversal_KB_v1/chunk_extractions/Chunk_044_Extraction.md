# Chunk 044 Extraction
- Source chunk: Chunk_044_Orderflows_Transcripts.md
- Transcripts covered:
  - v139 — Orderflows 2.0 Trading In Sync With The Market Webinar June 7 2018 Investor Inspiration (2018-06-10)
  - v140 — Orderflows Delta Scalper Settings July 5th (2018-07-05)
  - v141 — Delta Scalper Using Order Flow Delta Analysis In Your Trading (2018-07-08)
  - v142 — Free Order Flow Webinar Identify Market Turning Points As They Happen (2018-07-08)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Divergence + Ratio** ("bread and butter trade"): bearish/bullish ratio appearing on the bar making the new high/new low, with delta divergence on that same bar; considered valid even without additional confluence (v139, [21:50])
- **Divergence + Prominent POC**: delta divergence at a swing extreme that coincides with a prominent POC; described as "go time" (v139, [22:17])
- **Multiple Imbalances** at a swing low/high: three or more order-flow imbalances in a bar (non-stacked permitted); treated equivalently to stacked imbalances as a reversal signal (v139, [16:00])
- **Market Sweep** reversal: large trader sweeps through multiple price levels creating a directional impulse; highlighted by dark green/dark red arrow in Orderflows Trader 2.0 (v139, [13:36])
- **Prominent POC** support/resistance: POC highlighted by software as structurally significant; acts as S/R in range-bound and trending markets; can signal trend end or trend beginning (v139, [11:41])
- **Trap Traders** (enhanced): buyers/sellers trapped long/short at a level where the market reverses; Orderflows Trader 2.0 includes enhanced version (v139, [16:52], [28:57])
- **Ratio + Divergence + Prominent POC** (three-factor confluence): highest-tier entry described in the webinar (v139, [22:50])
- **Delta Scalper signal** (reversal mode, look-back filter ON): fires on higher high or lower low over look-back period; used as a standalone reversal indicator on any bar-chart type (v140, [04:13], v141, [00:00])
- **Delta build / Delta drying up at swing** (manual Delta reading): watching the max/min delta intrabar transition from heavy selling to buying — selling dries up, buying starts dominating — as an analog/manual version of what the Delta Scalper automates (v141, [22:29])
- **"Three bearish ratios in a row"** at a resistance area: described as "a setup I like just with the ratios" (v139, [32:31])
- **Alternating bullish/bearish ratios** (sideways identifier): bullish → bearish → bullish at the same price level signals a rotational/sideways market rather than a reversal (v139, [35:10])

---

## B. Tiering / grading language  ← HIGH PRIORITY

- **"Bread and butter trade"**: divergence + ratio; he "still looks at it today" even without additional tools — baseline reliable setup (v139, [37:32])
- **"Go time"**: used explicitly for (a) divergence + prominent POC, and (b) multiple imbalances off a high/low, and (c) ratio alone — any one of these is a valid go trigger; combining them is stronger (v139, [22:17])
- **"All systems go"**: multiple imbalances plus a market sweep plus delta surge, all appearing together; the strongest phrasing in the chunk (v139, [20:00])
- **"Screaming at you"**: prominent POC + multiple imbalances + sweep at a low — maximum confluence phrasing (v139, [37:03])
- **"Nice trade" / "nice little trade"**: single Delta Scalper signal with directional follow-through; solid but not extraordinary (v140, [06:31])
- **"Decent signals"**: Delta Scalper signals that produce partial or modest moves; below-average tier (v140, [11:50])
- **"Little loser" / "didn't work out"**: signals that stopped out; explicitly normalized as part of any method (v140, [13:52])
- **"Not a great" / "crappy signal"**: too many signals when look-back filter is disabled (v140, [04:13]) — more = worse quality
- **"It depends on your trading style"**: repeated qualifier; not a tiering word but a deliberate hedge against over-specifying quality (v140, multiple)
- **Grade-up criteria**: ratio + divergence + prominent POC together = highest tier; each additional element from {multiple imbalances, market sweep, Delta surge, trap traders} adds to the grade (v139, [22:50], [38:58])
- **Grade-down criteria**: signals taken (a) at a wrong location (after a down move to get short, instead of after an up move), (b) near news events (NFP/CPI), (c) in overnight low-volume sessions, (d) with look-back filter OFF (too many signals) (v139, [29:22], v141, [03:31])

---

## C. Order-flow story & psychology per setup

- **Multiple imbalances at a low**: "market is coming in for its landing" — traders recognize low prices as buying opportunity, start getting aggressive; imbalances show aggressive buying beginning (v139, [16:28])
- **Trap Traders at a resistance**: price-action traders buy the pullback thinking the market is going back up; instead they're "long and wrong"; market attempts to lift but fails; trapped longs ultimately puke (v139, [33:00])
- **Market Sweep origin**: a big physical-market participant sweeps all offers/bids from one price level to another in a single trade; this is a directional impulse, not a gradual build-up; shows up as a jump in volume across multiple consecutive price levels (v139, [13:36])
- **Delta drying up → reversal**: on the way down to a swing low, bars show heavy negative delta (−121, −120, −77); then one bar shows conflicted/near-zero delta (−17 with intrabar max of +0); next bar opens with delta turning strongly positive (+131, +143 max) — sellers exhausted, buyers dominating (v141, [22:29])
- **Big-player pullback dynamic** (Delta Scalper): large buyers create the initial surge → let the market breathe and pull back to their area → re-enter aggressively again; patient traders can enter on the pullback into the Delta Scalper zone rather than chasing the initial signal (v140, [30:52])
- **Alternating ratios = sideways**: bullish/bearish/bullish ratios with POCs at the same price = neither side has conviction; market is in balance (v139, [35:10])

---

## D. Exhaustion clues

- Max/min delta transition: watching the most positive vs. most negative delta reached INTRABAR on successive bars; when a strong negative delta bar (e.g., −120) is followed by a bar where max delta never reaches that level (−17 final, one brief positive spike intrabar), selling is exhausting (v141, [22:29]) [ONCE]
- Delta that is "all negative" at a high: in the webinar, he points to the fact that at a resistance high all bars show negative delta as confirmation sellers are dominating — even without divergence signal, negative delta at extreme = bearish exhaustion for buyers (v139, [22:17]) [REPEATED]
- Ratio + divergence on the bar making the new high or low: the delta failed to make a new extreme despite price making a new high/low — classic divergence as exhaustion (v139, [21:21]) [REPEATED]
- Low volume at a price level ("three lots trade, 465, 206 — that's like nothing in bonds"): market got "slapped" at resistance with almost no volume absorbing the selling — thin response at extreme = exhaustion / rejection (v139, [34:42]) [ONCE]

---

## E. Absorption clues

- Prominent POC at a swing extreme: the presence of a prominent POC at the high or low indicates heavy volume was traded at that level — absorption of either buyers or sellers depending on direction (v139, [12:08]) [REPEATED]
- Multiple imbalances at a swing low: aggressive buying coming in that is showing up as imbalances — buyers absorbing the remaining sellers (v139, [16:28]) [REPEATED]
- Delta build after a sell-off: successive bars of increasing positive delta after a decline = buyers absorbing and becoming dominant (v142, [01:47]) [REPEATED]

---

## F. Stacked imbalance ideas

- **Multiple imbalances treated as equivalent to stacked imbalances**: three or more imbalances in a single bar, not necessarily neatly stacked on consecutive price levels, are treated the same as stacked imbalances for reversal purposes (v139, [16:00]) [REPEATED from digest but with explicit minimum = 3]
- Multiple imbalances appear as a "purple box around the bar" in Orderflows Trader 2.0 (v139, [22:17]) [ONCE — implementation detail]
- Example: four imbalances in a bar at a swing low (not all adjacent) → market reversal upward (v139, [16:28]) [ONCE]
- In a trend: multiple imbalances can also signal continuation (shown in a trending Nasdaq example), not only reversal; context/location determines interpretation (v139, [19:03]) [ONCE — nuance]

---

## G. Delta / delta-divergence ideas

- **Divergence fires on the bar of the new high/low**, not the prior bar: "the divergence in the bar the new high or new low AND in the bar afterward with the ratio — I still consider that a valid setup" (v139, [22:50]) [REPEATED]
- **Cumulative delta** context: at a high, looking for predominantly negative delta across multiple bars as bearish confirmation, not just on a single bar (v139, [22:17]) [REPEATED]
- **Max/min delta intrabar reading**: compare max delta vs. min delta (most positive vs. most negative) on successive bars to read whether sellers or buyers are gaining or losing intensity intrabar (v141, [22:29]) [ONCE — specific technique]
- **Delta strength parameter** in Delta Scalper (1 vs. 2): higher strength = fewer signals; each increment doubles the required delta strength; default=1, Mike considers 2 as an alternative; strengths 3+ not recommended (v140, [11:18], [34:57]) [ONCE — specific implementation detail]
- **Delta surge** referenced as a bullish sign when present with multiple imbalances in a trending market (v139, [20:00]) [REPEATED]
- **Order flow described as a "present indicator"** (not leading, not lagging): based strictly on what is happening now (v139, [36:28]) [REPEATED]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Market Sweep** (Orderflows 2.0 feature): large trader sweeps through several price levels in one aggressive trade; this can initiate a trend move or confirm a reversal; the software highlights this with a dark green (buy) or dark red (sell) arrow; described as often coming "out of nowhere" in sideways markets (v139, [13:36], [15:03]) [ONCE for specific implementation detail]
- Trap Traders at a resistance after a rally: price-action buyers get long at the high on what they think is a pullback; market fails to sustain; trapped longs are forced out (v139, [33:00]) [REPEATED]
- He explicitly REJECTS the idea of a "stop run" causing a large price move: trapped quantity is small; it shifts the signal but does not fuel a big squeeze (per KNOWN_MODEL_DIGEST; consistent here — no mention of stop run as fuel in this chunk)

---

## I. Trapped-trader ideas

- "Price action traders are buying it thinking the market is going back up, instead they're stuck there long and wrong; market comes off, they try to move it back up but they're just fighting it — paddling up river against the tide" — describes the psychology of trapped longs at a resistance (v139, [33:00]) [REPEATED]
- When a buy signal appears and you are still holding a short: you must exit the short, not ignore the signal; a new opposing signal = your original trade reason is gone (v139, [30:08]) [ONCE — risk management nuance]
- Trap traders indicator enhanced in Orderflows Trader 2.0 (v139, [10:47]) — mentioned but not fully explained in this chunk

---

## J. Entry triggers (the exact "go" event)

- **Ratio appearing after divergence**: divergence on the new-high/new-low bar, ratio on the subsequent bar = valid entry trigger (v139, [22:50]) [REPEATED]
- **Divergence + prominent POC alone** = "go time"; do not need the ratio if the POC is present (v139, [22:17]) [ONCE — specific pairing]
- **Multiple imbalances alone** at a swing extreme = "go time" (v139, [22:17]) [REPEATED]
- **Delta Scalper signal** at a higher high or lower low (look-back 25): fires on bar close when delta conditions are met; aggressive entry = market order immediately; pullback entry = wait for market to retrace to the Delta Scalper zone box (v140, [04:13], [30:52]) [REPEATED]
- **"All systems go"** phrasing: when multiple imbalances + sweep + delta surge align simultaneously — maximum conviction entry (v139, [20:00]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- Market should move immediately and not look back: "if you get short here you should have been keyed on the prominent POC if you're not then you got multiple imbalances — it's giving you so many signs" (v139, [38:04]) [REPEATED]
- Delta should continue building in the direction of the trade after the reversal bar: "seeing aggressive buyers coming in more and more and more — market has a tendency to start to rally" (v142, [01:47]) [REPEATED]
- For the Delta Scalper pullback approach: after the initial signal fires, large buyers let the market breathe back to the signal zone; confirmation is a second surge of aggressive delta away from that zone (v140, [30:52]) [ONCE — specific to Delta Scalper pullback entry]
- Price follows prominent POC chain: after a reversal from one prominent POC, the market should travel to the next prominent POC in the direction of the trade (v139, [19:32], [41:50]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- Opposing signal after entry: "if you're trading any type of signal and you get a short signal then you get followed up with a buy signal you got to get out of the position" (v139, [30:08]) [REPEATED]
- Prominent POC does NOT guarantee an immediate bounce: "most more often than not it does but it can also go sideways"; must also assess whether the move is over or whether price will go sideways then continue (v139, [33:47]) [REPEATED]
- "Three possible outcomes after a move": (1) reverse, (2) go sideways, (3) go sideways then continue in original direction — trader's job is to notice which one is developing (v139, [33:47]) [ONCE — specific enumeration]
- Alternating bullish/bearish ratios = market is going sideways, NOT reversing; do not take a directional trade in this environment (v139, [35:10]) [ONCE]
- News events (NFP, jobs numbers): "you can't be involved during the number"; no order flow signal can overcome the directional unpredictability of a surprise macro print (v141, [03:31]) [REPEATED]

---

## M. Stop / risk / target / trade management

- **Stop placement**: "I like to keep my stops tight — I'm looking for the pure reversal" (v140, [06:31]) [REPEATED]
- **Do not take a four-point risk on a five range emini chart**: example of stop being too wide relative to chart granularity; stop should match chart type (v140, [15:36]) [ONCE — chart-type risk calibration]
- **Range-based chart stop sizing**: because bar size is fixed (range), stop sizing is more predictable than on time-based charts where bar size varies greatly (v140, [29:32]) [ONCE]
- **Targets**: travel to the next prominent POC in the direction of the trade is the implicit target methodology used throughout the webinar (v139, multiple) [REPEATED — prominent POC as target]
- **Time/session stop**: do not hold interest-rate futures through NFP; be out before the number (v141, [04:02]) [REPEATED]
- **Friday afternoon session**: interest rates after cash bond close (~2pm CT Friday) — "I doubt you'd be looking to take a trade at 3pm on a Friday" (v141, [05:47]) [ONCE — specific session filter]
- **Pareto principle acknowledgment**: "80% of your profits will come from 20% of your trades" — normalizes losing trades as part of methodology; do not demand 80-90% win rate (v140, [35:55]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Session**: European hours to US close preferred for delta analysis; pre-2am CT (European open) = thin/unreliable delta signals (v141, [06:51], [08:49]) [REPEATED — session preference]
- **Volume threshold for delta validity**: delta analysis needs "solid bars of volume"; very low contract counts per bar (7, 13, 19 contracts on a 1-minute NQ bar overnight) = insufficient delta signal (v141, [07:47]) [ONCE — explicit volume-quality floor for delta]
- **NFP / jobs number**: flat before number regardless of signal; re-enter after number digested (v141, [03:31]) [REPEATED]
- **Cash equities close (4pm ET)**: heaviest volume of the day in equity futures; Delta Scalper signals at the close get churned; treat as noisy; "can you take it? of course, but you'd see the churn" (v141, [15:05]) [ONCE — specific close-of-cash session filter]
- **Markets**: bonds/tens = best for prominent POC (high commercial activity, low speculative); eminis work but are more speculative; crude oil = range-based 8 range chart preferred; grains = 4 range chart preferred; euro currency futures (6E) = viable delta market (v139, [12:36], v140, [23:25]) [ONCE — per-instrument chart-type preferences]
- **Range-based chart preferences by market** (SPECIFIC NEW): crude oil → 8 range; emini/grains → 4-5 range; these are his stated preferences, not requirements (v140, [23:25]) [ONCE]
- **Prominent POCs work best in markets with high commercial / low speculative activity**: bonds as best example; eminis work but less cleanly (v139, [12:36]) [ONCE]
- **Overnight session (NQ example)**: delta analysis usable after 2am CT when European cash opens; before that, too illiquid for NQ delta (v141, [08:49]) [ONCE]
- **Trending vs. rotational**: in a trend, multiple imbalances can appear as continuation signals not reversals; alternating ratios + POCs at same levels = rotational/sideways (v139, [19:03], [35:10]) [REPEATED]

---

## O. Directly testable / measurable variables

- **Multiple imbalance minimum = 3** imbalances in a single bar (non-stacked permitted) to qualify (v139, [16:00]) [REPEATED; confirms 3+ minimum]
- **Delta Scalper look-back = 25 bars** (his stated default/preferred setting; default in software = 7) (v141, [01:03]) [ONCE — specific override of software default]
- **Delta strength setting = 1 or 2** (he uses 1, considers 2; doubling = 2x more delta required per increment; settings 3+ not used) (v140, [11:18], [34:57]) [ONCE]
- **Signal box width = 15 bars** (how far the Delta Scalper zone extends to the right) (v141, [01:03]) [ONCE — implementation parameter]
- **Signal mark displacement = 2** price levels off bar high/low for the triangle (v141, [01:03]) [ONCE — implementation parameter]
- **Opacity = 25** for signal box (v141, [01:03]) [ONCE — cosmetic but noted for NT implementation]
- **"Higher high or lower low" filter** (look-back ON): mandatory for reversal use; without it = too many signals, signal quality degrades (v140, [04:13]) [REPEATED]
- **Max delta / min delta intrabar comparison**: for manual delta analysis, compare the most positive vs. most negative delta reached within each bar across successive bars at a swing (v141, [22:29]) NEEDS-OPERATIONALIZATION (specific bars to compare, threshold for "dried up" not given)
- **Ratio threshold**: blue = above the threshold; black = normal; threshold not disclosed in this chunk [REPEATED — already in digest]
- **Overnight NQ volume floor**: bars with 7–13 contracts on a 1-minute chart = "not gonna give much information"; consistent reliable delta starts when most bars exceed ~100 contracts (v141, [07:47]) NEEDS-OPERATIONALIZATION (exact floor not stated; ~100/bar described as "averaging better numbers")
- **Interest rate sensitivity**: bonds highly sensitive to jobs numbers; exit before NFP regardless of signal (v141, [17:01]) [REPEATED]
- **Three-in-a-row bearish/bullish ratios** at a level = setup worth taking standalone (v139, [32:31]) NEEDS-OPERATIONALIZATION (precise definition of "in a row" and price-level proximity not stated)
- **Alternating ratio pattern** = sideways market identifier: bullish ratio → bearish ratio → bullish ratio at/near same POC levels (v139, [35:10]) NEEDS-OPERATIONALIZATION

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Delta Scalper indicator** (NT8): runs on normal bar charts (not just footprint); parameters: look-back bars (prefer 25), delta strength (1 or 2, doubles required delta per increment), positive/negative delta strength as separate inputs, signal box height, signal box opacity, signal box width (bars), signal mark displacement (price levels), "signal only on higher highs/lower lows" boolean filter (v140, v141) [DIRECT]
- **Tick replay must be ENABLED** in NT for Delta Scalper historical signals to be accurate: "if you don't have tick replay enabled nothing's going to happen" (v140, [20:20]) [ONCE — critical NT implementation note]
- **Orderflows Trader 2.0 indicators (NT8)**: prominent POCs (blue=buy/magenta=sell), market sweeps (dark green/dark red arrow), multiple imbalances (purple box), enhanced trap traders, divergence, ratios — all run as layered overlays on a footprint/volumetric chart (v139, [08:21], [12:08]) [REPEATED — 2.0 indicator inventory]
- **Prominent POC coloring**: blue = support, magenta = resistance (v139, [13:07]) [ONCE — color convention for NT indicator]
- **Multiple imbalance visual**: purple box around the bar in Orderflows Trader 2.0 (v139, [22:17]) [ONCE]
- **Range-based charts**: bars form based on price movement not time; suitable for Delta Scalper because bar size is consistent (v140, [08:16]) [REPEATED]
- **Calculate on each tick**: Delta Scalper data series set to calculate on each tick (v141, [01:37]) [ONCE — NT calculation setting]
- **Maximum bars look back = 256** (visual) for Delta Scalper (v141, [01:37]) [ONCE — NT memory parameter]
- **Color convention**: buys = royal blue, sells = magenta (not red, to avoid conflict with other red indicators) (v141, [02:05]) [ONCE]
- **Chart template**: Mike provides his full NT chart template including indicator layout (v139, [13:07]) [contextual]
- **Signal fires on bar close (no repaint)**: consistent with prior digest; Delta Scalper evaluates conditions when the bar that triggered the higher high/lower low closes (v140, [04:13]) [REPEATED]

---

## Q. Notable verbatim quotes

1. "Order flow by itself, it's not a red light green light trading system but when you understand order flow the markets will become very clear for you." (v139, [05:27])

2. "I call it a present indicator — it's based on what's happening right now." (v139, [36:28])

3. "You know divergence and ratio go time; divergence and prominent point of control also go time; multiple imbalances off the high it's also go time — each one of these bars is telling you hey don't get long, get short." (v139, [22:17])

4. "You're at your low and it's just screaming at you get long, get long." [on prominent POC + multiple imbalances + sweep] (v139, [37:03])

5. "You can see how it's all systems go — this is actually the delta surge going on right here." (v139, [20:00])

6. "Three possible outcomes after a move: one it's going to reverse, two it's going to go sideways, three it's going to go sideways and then sell off some more — your job is to notice that." (v139, [33:47])

7. "If you're trading any type of signal and you get a short signal then you get followed up with a buy signal you got to get out of the position and think about getting long — you're not going to stay here and stay short and hope it works out." (v139, [30:08])

8. "You know if you don't have tick replay enabled then nothing's going to happen — you're not gonna get any indications on your chart at all." (v140, [20:20])

9. "The Pareto principle — 80% of your profits will come from 20% of your trades, and that's just how life goes sometimes." (v140, [35:55])

10. "Sellers were dominating here on the way down — now you've seen selling has dried up and buyers are starting to dominate on the way back up — and those are the types of setups that you want to look for." (v141, [24:04])

---

## R. Contradictions / nuances

- **Multiple imbalances as continuation, not just reversal**: in a trend, the same multiple-imbalance signal that acts as a reversal at an extreme also appears mid-trend as a continuation signal; context/location is essential to distinguish the two (v139, [19:03]) — slightly contradicts any strict reading of the model as "multiple imbalances = reversal only"

- **Prominent POC does NOT guarantee immediate bounce**: "most often it does but it can also go sideways" — the POC marks a structurally important level, not a guaranteed turn (v139, [33:47]) — nuance to the common shorthand "POC = reversal"

- **Three possible outcomes at a POC** (reversal / sideways / sideways-then-continuation) are enumerated explicitly — trader must assess which is unfolding rather than automatically expecting a reversal (v139, [33:47])

- **Alternating ratios = sideways, NOT reversal**: bullish/bearish/bullish ratio sequence at the same price level is an identifier of a range-bound/balanced market; taking a directional trade in that pattern is a mistake (v139, [35:10]) — previously only the stacked-same-direction ratio was discussed

- **Delta Scalper look-back default vs. preferred**: software default is 7 bars; Mike's preferred setting is 25 bars — using the default gives materially more signals that he considers lower quality (v140, [04:45], [05:26]) — important for any NT implementation using the indicator

- **Delta strength doubling is non-linear**: going from 1 → 2 doubles the required delta; 1 → 4 is 8x the required delta (not linear) — relevant for anyone calibrating the indicator (v140, [11:18])

- **Tick replay must be enabled**: without it, the Delta Scalper historical calculations are incorrect; this is an NT-specific constraint not previously captured (v140, [20:20])

- **Cash equities close volume surge causes signal noise**: the heaviest volume of the day in equity futures goes through at the 4pm ET cash close; Delta Scalper signals at that time may be valid but are prone to churn due to the volume profile (v141, [15:05])

- **Volume quality floor for delta**: overnight NQ bars with 7–13 contracts/minute are explicitly called out as insufficient for reliable delta analysis; implies a minimum volume threshold is required before delta readings are trustworthy — he does not give an exact number but "averaging better than 100/bar" after European open (v141, [07:47])

- **Pullback vs. aggressive entry trade-off**: aggressive entry (market order on bar close) vs. pullback entry (limit order into the Delta Scalper zone) are presented as equally valid but with different trade-offs; pullback entry misses aggressive gap moves, aggressive entry absorbs wider spread; neither is declared superior (v140, [07:24], [30:25])

---

## Coverage note

v139 (Orderflows 2.0 Webinar, June 2018) is the richest transcript in this chunk — a 55-minute sales/education webinar that walks through every major Orderflows Trader 2.0 indicator with real chart examples. Dense with model-relevant content including tiering language, setup naming, and confluence principles. v140 and v141 are settings/walkthrough videos specifically about the Delta Scalper indicator, valuable for NT implementation parameters (look-back=25, delta strength=1–2, tick replay requirement) but thin on new conceptual model content. v142 is a 3-minute promotional announcement with one useful reversal concept (delta building at a swing low); very thin.
