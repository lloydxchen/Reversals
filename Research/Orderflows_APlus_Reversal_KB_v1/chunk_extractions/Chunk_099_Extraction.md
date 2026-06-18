# Chunk 099 Extraction
- Source chunk: Chunk_099_Orderflows_Transcripts.md
- Transcripts covered:
  - v403 — Order Flow In A Supply Driven Market Using Orderflows Trader Footprint Chart (2023-09-28)
  - v404 — Good Markets To Learn Order Flow Using Orderflows Trader (2023-09-29)
  - v405 — Limit Down Moves And What It Means To Order Flow Analysis (2023-09-29)
  - v407 — Orderflows Trade Setup Encyclopedia (2023-12-18)
  - v409 — The Orderflows Algo Analyze Supply And Demand With Order Flow (2024-02-05)
  - v410 — Strong Order Flow Trading Strategy Using Orderflows Trader For NinjaTrader 8 (2024-02-07)
- Overall content value: mixed (v403 and v410 are rich live-tape reversal reads; v409 is a long but product-pitch-heavy walkthrough that still contains usable supply/demand-zone rules; v404, v405, v407 are thin for reversal modeling)

## A. Setup types & names he uses
- **Supply-driven sell-off / "release valve" reversal (bullish bottom)** — market makes new lows but the lows are absorbed by passive supply; once supply is exhausted, market rallies. He explicitly looks for "that release valve" (v403, "Supply Driven Market", [04:06]). [ONCE]
- **Absorption reversal off a swing low** — green candle with strong positive delta after a string of red-candles-on-positive-delta, signaling supply is gone and aggressive buyers take over (v403, "Supply Driven Market", [11:56]–[13:40]). [ONCE]
- **Strong-order-flow trend continuation / pullback-buy** — buy the pullback when aggressive buyers AND strong bids step in (v410, "Strong Order Flow Strategy", [03:55]–[04:26]). [REPEATED within video]
- **Supply/demand zone retest entry (Orderflows Algo)** — confirmed demand zone (blue up-triangle) is bought on a retest; confirmed supply zone (red down-triangle) is sold on a retest (v409, "Orderflows Algo", [42:39]–[44:36]). [REPEATED]
- **Stacked-imbalance reversal signal** — stacked buy imbalances on a pullback low / stacked sell imbalances at a high mark turning points (v410, [03:55]). [ONCE]
- Named tool feature list (not setups per se): "buying and selling Tales, Divergence, exhaustion prints, imbalance reversals, Market sweeps, Market weakness, sequencing, ratios" (v404, "Good Markets", [06:42]). [ONCE]
- "Imbalance reversals" listed as a named Orderflows Trader signal (v404, [06:42]). [ONCE]
- Trade Setup Encyclopedia: **128 setups** across General (50), Delta (34), Point of Control (22), Imbalance (22) — names not individually given here (v407, "Setup Encyclopedia", [02:23]). [ONCE]

## B. Tiering / grading language  ← HIGH PRIORITY
- **"strong" vs "not strong / light / weak" imbalance** is his core grading axis in v410. A stacked sell imbalance is downgraded because "the volumes in here are kind of light" — 67 vs 2, 72 vs 1, 128 vs 1; "would I consider this a strong selling imbalance? well not really" (v410, [05:17]). He says "the intensity of that imbalance stacked imbalance is just not enough for me, I like it to be a bit stronger in terms of volume" (v410, [06:23]). [REPEATED]
- Counter-example of a **strong** stacked buy imbalance: volumes "52, 66, 76, 244, 388" — "above three digits... I would take that as being pretty strong" (v410, [04:26]/[06:49]). [ONCE]
- Conditional upgrade: "if this 285 was an imbalance and 344 I'd probably look at it a little bit differently, but it wasn't" — i.e. a stacked imbalance grades higher when the aggressive-side volumes are larger (v410, [05:17]). [ONCE]
- **Delta % of volume** as a strength grade: "nice Delta... 982 got a nice Delta into volume of 34%... that's why it's colored cyan" — cyan = strong delta-as-%-of-volume (v410, [07:25]). [ONCE]
- Zone strength tiers in the Algo (verbatim strength labels): for **supply/demand strength** "one is the base level... you could go up to 30 or 50... the higher you go obviously the more strength... the less signals" (v409, [21:31]). For **orderflow analysis** strength "one is the strongest, three is normal... average, five is the most liberal" (v409, [37:35]/[1:01:03]). He repeatedly says he personally uses **3** ("I prefer three... most conducive for most markets") and never 5 ("why would I want to use the most liberal") (v409, [41:23]/[55:50]). [REPEATED]
- Zone-thickness grading via "ice" metaphor: "the thicker the ice... the longer you can stay on it; thin ice... eventually it's going to break" → thicker zones (higher Min) are "a little bit more sturdy" (v409, [1:03:18]). [ONCE]
- Zone-quality preference: zones in **close proximity / overlapping** are graded stronger — "you had some Supply come in, market sold off, came back up to your supply zone, then more Supply coming in... those are the zones that I like" (v409, [1:24:44]). [ONCE]
- Bigger zone ≠ automatically better — he resists size as the sole quality cue: "the bigger the zone the more — I don't want to say the more chance it's got to hold" (v409, [1:22:49]). [ONCE]
- Recency tiering: current order flow outranks old zones — "I'll put more belief in that demand that we have currently than that supply that happened three weeks ago" (v409, [1:19:42]). [REPEATED]
- General-channel grading words: gold "is a good buy... gold is always a good buy period" (v403, [14:53]); buying near limit-down is "not a prudent trade to take" / "do you want to be a hero" (v405, [10:32]). [ONCE]

## C. Order-flow story & psychology per setup
- **Supply-driven sell-off (apple-stand analogy)**: the seller has too much inventory ("apples") and keeps offering lower; bargain buyers step in but the seller keeps refilling supply ("wife pulled up with the pickup truck... new shipment"), so price falls on POSITIVE delta. Reversal comes when "he's got no more apples" — supply exhausts and the same buyers who hesitated now chase (v403, [05:17]–[08:29], [11:56]). [REPEATED metaphor]
- Who's trapped/active: aggressive buyers keep hitting offers at the lows but are absorbed by passive supply; passive sellers (prop traders' inventory) cap every rally. "The passive selling, the supply, is basically absorbing whatever aggressive buying there is" (v403, [11:15]). [REPEATED]
- Recognition of non-panic distribution: 6 consecutive red candles making 4 new lows all on positive delta = "people with supply are not panicking but realizing 'I got to get rid of this stuff'" (v403, [10:34]). [ONCE]
- **Strong-uptrend story (v410)**: aggressive buyers lift offers to push price up, but what *holds* the market up is strong passive bidding — "what's holding the market from going down is people bidding and bidding strong volumes." The strong bids at NEW HIGHS are "other time frame traders... Deep Pockets... I got to lock in a position because we're probably going higher" (v410, [11:57]–[13:11]). [REPEATED]
- Auction-theory framing: if the offer is trading for good volume and price still won't go higher, "you got strong sellers in that market" even if they aren't hitting bids; recognizing this is the cue to hit the bid (v403, [16:07]–[16:48]). [ONCE]
- Limit-down psychology: at limit-down there is only selling pressure ("insane selling pressure"); nobody wants to buy; trapped longs can't exit ("you're screwed") (v405, [06:17]/[10:55]). [ONCE]

## D. Exhaustion clues
- **Exhaustion print** (named Orderflows Trader signal) = "volume at the edge of bars that indicates when the last buyer has bought or the last seller has sold" (v404, "Good Markets", [08:13]). Volume threshold is user-set; he likes **9** ("keep it in single digits"), uses smaller in thin markets (e.g. **3**, even **1**, in euro) and larger in thick markets (e.g. **50** in 10-yr) (v404, [08:50]/[12:02]). [REPEATED]
- Supply-exhaustion read: the LAST big offer-side prints ("the 163, the 106") mark the end of supply — "this is probably the last of whatever supply there was... once that is removed... you're going to be looking for the market to rally" (v403, [13:40]–[14:53]). [ONCE]
- Wide green candles appearing = "the aggressive buyers are coming in, but more importantly that supply is missing" (v403, [12:58]). [ONCE]

## E. Absorption clues
- Core absorption tell: **red candle closing down but with POSITIVE delta** = aggressive selling hitting bids, yet passive supply on the offer is absorbing aggressive buying and keeping price from rallying (v403, [06:41]–[07:57]). [REPEATED]
- Offer-side volume > bid-side volume inside a down candle = supply being distributed through the bar (v403, [07:16]/[09:55]). [REPEATED]
- Strong bid present but price goes nowhere, next bar red-on-positive-delta = "more supply on the offer side... supply is being distributed throughout this bar" (v403, [09:26]). [ONCE]
- Cumulative-delta-vs-price divergence as absorption proof (see G). [REPEATED]
- Absorption (inverse, bullish): on the way UP, strong/heaviest volume on the BID side while price rises = passive bids absorbing/supporting; "becoming bid here at higher prices for a heavier volume" (v410, [09:32]–[10:47]). [REPEATED]

## F. Stacked imbalance ideas
- Imbalance definition: bid- or offer-side volume greater than the other side by a ratio "usually 4:1, some people use 3:1, I like 4:1, I've always used 4:1... forever" (v410, "Strong Order Flow", [01:17]). [REPEATED] — this is a hard, citable threshold.
- Color coding: red number = selling imbalance, blue number = buying imbalance, black = normal two-way order flow (v410, [01:49]). [REPEATED]
- A "stack" = three imbalances stacked neatly on top of each other (v410, [05:17]). Example bullish stack spanned **5 levels** (v410, [03:55]). [ONCE]
- Quality of a stack depends on the aggressive-side VOLUME, not just the stacking (see B). Light-volume stacks are discounted (v410, [05:17]/[06:23]). [REPEATED]
- **Multiple (non-stacked) imbalances in one bar** (two or more) is also an important sign — "aggressive bids just not coming in [at one bunch], it's being spread out" (v410, [07:55]). [ONCE]
- On a 4-range chart (only 5 price levels) getting 3 stacked imbalances "is going to be a stretch"; on short bars he'd use a 2-stack setting instead of 3 (v404, "Good Markets", [10:17]). [ONCE]

## G. Delta / delta-divergence ideas
- **Cumulative-delta vs price divergence is his headline reversal signal (bullish bottom)**: price made new lows ($15 lower) yet cumulative delta was DOUBLE its earlier value / near day-high (~+2,000 to +4,000) — "we're $15 lower, yet cumulative delta is quite strong" → strong buying at lower prices, market should rally (v403, [03:26]–[04:38], [14:53]). [REPEATED]
- Explicit logic: in a sell-off you'd EXPECT cumulative delta to fall; if it stays flat-to-up while price drops, aggressive buying is being met by passive supply — once supply lifts, price pops (v403, [15:26]–[16:07]). [REPEATED]
- He flags the symmetric bearish case as having happened "last week": price at day-highs but cumulative delta NEGATIVE (v403, [18:32]). [ONCE]
- "Delta drops a lot in one bar" then goes sideways while price keeps making new lows = supply absorbing (v403, [02:51]). [ONCE]
- Delta-as-%-of-volume (34% example) used as a strength gauge; cyan coloring flags strong delta% (v410, [07:25]). [ONCE]
- "Divergence" is a named Orderflows Trader tool (v404, [06:42]). [ONCE]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- Closest analog: new lows that FAIL to follow through because supply (not demand) was driving them; the "failure" is price making lows on positive delta and then reversing once supply dries (v403, [10:34]–[14:53]). [ONCE — framed as supply exhaustion, not a classic stop-run]
- Limit-down "failed bounce": after hitting limit-down, there were brief bounces (a couple minutes, ~15 min later) but then "just everyone coming in joining the offer" — no real reversal while supply overwhelms (v405, [05:20]). [ONCE]
- Zones that "fail": a supply/demand zone can form and then fail; light-blue zones in the Algo = "tested and failed" (traded back into) vs dark zones not yet retested (v409, [11:33]/[27:16]). He stresses other vendors' tools dishonestly ERASE failed/traded-through zones; he keeps drawing them (v409, [27:16]–[28:25]). [REPEATED]
- No explicit liquidity-sweep / stop-run vocabulary in this chunk. — minimal here —

## I. Trapped-trader ideas
- Limit-down trapped longs: a trader who buys near the limit and is wrong "might not be able to get out" — if it goes limit-offered with "a thousand in front of you," "you're screwed"; historical limit moves lasted "several days against them... Margin Call Margin Call" (v405, [09:30]–[10:55], [12:35]). [REPEATED]
- Implied trapped bargain-buyers in supply-driven sell-off: buyers who bought the "cheap" dip keep getting filled by fresh supply until the bottom (v403, apple analogy, [05:43]–[08:29]). [ONCE, metaphorical]

## J. Entry triggers (the exact "go" event)
- **Algo confirmation trigger**: the blue up-triangle (buy) / red down-triangle (sell) printing on a zone IS the confirmation/"go" — "that is the confirmation right, that is confirmation of taking the trade" (v409, [45:37]). The zone box can draw without a triangle = not confirmed (v409, [1:11:08]). [REPEATED]
- **Retest-into-zone entry**: enter (or add) anywhere between the two boundaries of a confirmed zone on a pullback — "anytime it tests it" you drop a bid in the demand zone (v409, [42:39]–[44:36]). [REPEATED]
- **Supply-removal trigger (manual)**: when you can conclude the last big offer-side prints are gone, look for the rally (v403, [13:40]). NEEDS-OPERATIONALIZATION — judged by eye, no numeric trigger. [ONCE]
- **Strong-flow pullback-buy trigger**: on a pullback, a stacked BUY imbalance with strong (3-digit) volumes + positive delta + heaviest volume on the bid side = the go (v410, [03:55]–[10:47]). NEEDS-OPERATIONALIZATION (no single trigger bar defined). [REPEATED]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- After a real demand zone, the Algo triangle should print "right around the time the zone is drawn"; if order flow takes too long to confirm, the zone stays un-triangled (v409, [11:49]/[1:11:49]). [REPEATED]
- He likes confirmation that prints "a few moments after the high of the day has been made... which is what you like to see" (v409, [29:00]). [ONCE]
- After a supply-driven bottom, you should quickly see wider green candles + positive delta + absence of large offer-side prints (v403, [12:58]). [ONCE]
- In a strong uptrend, continuation is confirmed by successive bars holding positive delta with heaviest/strong volume on the bid side at progressively higher prices (v410, [09:32]–[11:24]). [REPEATED]

## L. Invalidation — what should NOT happen / what kills the thesis
- Reversal-up thesis is invalidated while big offer-side prints keep appearing / new heavy supply keeps refilling (the "new shipment of apples") — price keeps making lows on positive delta (v403, [07:57]/[10:34]). [REPEATED]
- Strong-bid bullish thesis weakens if imbalances are light-volume (1- and 2-contract opposite sides) — "not enough for me" to flip short or to trust the move (v410, [05:17]/[06:23]). [REPEATED]
- Zone thesis killed when price trades THROUGH the zone (not just into it) — boundary = stop (v409, [27:16]/[1:04:57]). [REPEATED]
- "Buy the dip... the dip could keep dipping; sell the rally... the rally could keep rallying" — you can't hold the thesis without a stop (v409, [45:00]/[1:04:25]). [REPEATED]
- Limit-down: a long thesis is effectively un-exitable; being wrong there is uniquely dangerous (v405, [10:32]). [ONCE]

## M. Stop / risk / target / trade management
- **Zone boundary = stop**: for a blue (demand) zone the LOWER edge is the stop; for a red (supply) zone the TOP edge is the stop. The Algo prints "Zone end price = stop price" and "Zone start price = add-on price" (v409, [33:35]/[42:39]/[43:17]). [REPEATED]
- **Add-ons**: add to a winning position anywhere inside the confirmed zone on each retest — "adding on to a winning position is something you always really want to do" (v409, [42:39]). [REPEATED]
- **Zone-width = risk control**: keep zones roughly **2–25 price levels**; he dislikes very wide zones (M/NQ can be >50 ticks) because the stop distance is too large — "really want to risk 20 full points / 80 ticks? I don't think it's worth it" (v409, [33:03]/[35:31]/[1:00:21]). Example stops cited: a 23-tick zone (7393→7370), a 29-tick zone (4977→bottom = risking 25 ticks) (v409, [30:19]/[34:14]). [REPEATED]
- Min zone thickness setting: he likes a **minimum of 2** price levels (avoid 1-level zones in slow tape); use higher (e.g. 5) only in volatile markets like M/NQ (v409, [31:45]/[59:41]). [REPEATED]
- Max zone setting **25** default; bump to **50** only for NQ/MQ/(YM) volatility (v409, [1:00:21]/[1:01:03]). [REPEATED]
- Always use stops; you can't trade the buy-the-dip concept without one (v409, [45:00]). [REPEATED]
- Targets: not numerically specified in this chunk. — nothing specific —

## N. Context filters (session/time, regime/volatility, levels)
- **Instruments**: gold (GC), 10-yr (ZN/TY), euro (6E), lean hogs (HE), crude (CL), e-mini S&P (ES), M/NQ, MES/MNQ, bonds, copper, nat gas, soy meal, British pound, JPY. He is "partial to commodities" (career at Cargill, JP Morgan, EDF Man) and thinks commodity markets may follow supply/demand better but admits he hasn't done "the hardcore analysis" — [SPECULATIVE on his part] (v409, [48:50]–[51:44]). [ONCE]
- **Beginner market choice**: ES is OK but can be too fast; NQ/MNQ too big for beginners (20-pt bars in 30s); recommends **10-yr treasuries** and euro currency for learning order flow because they move enough yet are readable and liquid (v404, [02:34]–[05:40]). [REPEATED]
- **Chart type**: prefers range/volume charts over time when bars would "flatline"; uses a **4-range** chart on treasuries (>10 yrs), considers 5-min, 1-min, 30-sec; says you "need price movement in a bar" to see volume distributed (v404, [04:10]–[06:12]; v409 various). [REPEATED]
- **Session**: references US day session for commodities (re-open 8:30 after 7:45 close for soy meal), cash open 8:30/9:30 for ES; notes overnight/evening tape is choppy and needs stronger settings (v409, [22:08]/[39:40]/[50:32]). [REPEATED]
- **News filter**: explicitly stands aside around major releases — "I don't advocate ever trading right ahead of a major release"; on NFP "I'm just going to stand on the sidelines" (v409, [52:22]/[53:29]/[1:08:16-context]). [REPEATED]
- **Volatility regime**: use stronger strength settings on volatile markets (M/NQ, nat gas); base/low settings flood signals (v409, [25:28]/[35:31]/[59:41]). [REPEATED]
- **Levels**: previous-day high/low are "the most obvious supply and demand zones"; mid-range zones matter too and need rules (v409, [10:36]/[54:51]). Prominent Point of Control (Level 1/2) used for support/resistance (v404, [07:40]). Psychological levels noted but de-emphasized (5,000 ES; 108 euro; <$1,900 gold) (v403/v409/v410). [REPEATED]
- **Daily price limits** as a hard context filter: hogs limit = 0.037 (3.75 / ~5%); check CME website for which markets have limits (grains, meats, etc.). Don't buy "dangerously close to the daily price limit" (v405, [02:31]–[03:41], [09:58]). [ONCE]

## O. Directly testable / measurable variables
- Imbalance ratio = **4:1** (his standard; notes some use 3:1) (v410, [01:17]). EXACT.
- Stacked imbalance = **3** consecutive imbalances stacked on adjacent price levels (v410, [05:17]). EXACT (definition).
- "Multiple imbalances in a bar" = **2 or more** non-stacked imbalances as a secondary signal (v410, [07:55]). EXACT.
- Delta-as-%-of-volume example **34%** flagged strong / cyan — threshold for "strong" not given. NEEDS-OPERATIONALIZATION (only one example value).
- Exhaustion-print volume threshold: default **9** (single digits); thin markets **3** or **1**; thick markets up to **50** (v404, [08:50]/[12:02]). EXACT (his preferred values, market-dependent).
- Algo supply/demand **strength value**: he uses **1, 3, 5, 7** (also 2,4 allowed); base = 1; can go to 15/20/30/50; never 5 for orderflow strength (v409, [55:50]/[1:01:03]). EXACT (his choices).
- Algo **orderflow analysis strength** 1–5: 1=strongest, 3=normal/average, 5=most liberal; he uses 1 or 3, prefers 3 (v409, [37:35]/[41:23]). EXACT.
- Zone **Min** thickness: minimum **2** price levels preferred (avoid 1; up to 5 in volatile) (v409, [31:45]/[59:41]). EXACT.
- Zone **Max** thickness: default **25** ticks; **50** for NQ/MQ/YM (v409, [1:00:21]). EXACT.
- Practical risk ceiling: dislikes risking ~20 points / 80 ticks on a wide zone; keeps zones 2–25 levels (v409, [35:31]/[1:00:21]). EXACT-ish (stated as preference).
- Lookback days for historic zones: example "5 days," can extend to "20 days" to capture overhead zones; no fixed optimal — recency preferred (v409, [1:16:18]/[1:16:57]). Qualitative — NEEDS-OPERATIONALIZATION.
- Hog daily limit = **3.75 (≈5%)**, spec 0.037 (v405, [02:31]/[03:10]). EXACT (market mechanic, not a setup param).
- "Strong" cumulative-delta divergence: price $15 lower while cum-delta ~doubled (+1,000 → ~+2,000/+4,000) (v403, [03:26]). Specific example numbers, but threshold qualitative — NEEDS-OPERATIONALIZATION.
- "Strong bid" = heaviest (or 2nd-heaviest, but large) volume on the bid side while delta stays positive; examples 406, 583, 799, 1415 (v410, [09:32]–[11:24]). Qualitative ("relative to volume in the bar") — NEEDS-OPERATIONALIZATION.

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- Platform is **NinjaTrader 8 only** (Orderflows Algo + Vault indicators); not on Sierra Chart / MotiveWave yet (v409, [1:09:57]/[1:27:19]). [REPEATED]
- Orderflows Algo draws **supply/demand zones as colored boxes** (blue=bullish, red=bearish) with **intensity/shade** encoding retest status: light = traded back into & failed, dark = not yet retested (v409, [11:33]/[27:16]). Implementable: zone state machine {untested→tested→through}. [REPEATED]
- **Confirmation arrows**: blue up-triangle = confirmed buy zone, red down-triangle = confirmed sell zone; zone may print without arrow if order flow doesn't confirm in time (v409, [28:25]/[1:11:08]). Implies a two-stage model: (1) geometric S/D zone detection at swing highs/lows, (2) order-flow confirmation gate that fires the arrow. [REPEATED]
- Settings to expose: zone strength value, supply/demand Min (zone thickness floor in ticks/levels), supply/demand Max (ceiling), orderflow-analysis strength (1–5), supplementary zones (trend zones, off by default), longer-time-frame mode, optional higher-TF-onto-lower-TF plotting (v409, [19:08]/[1:13:37]). [REPEATED]
- Auto-label zone boundaries with **stop price (zone end)** and **add-on price (zone start)** drawn as text (v409, [33:35]/[42:39]). [REPEATED]
- Does NOT require tick replay on a normal bar chart (tick replay only needed for footprint) (v409, [16:55]/[18:34]). [ONCE]
- Orderflows Trader footprint signals available to model: buying/selling Tales, Divergence, exhaustion prints, imbalance reversals, market sweeps, market weakness, sequencing, ratios, Prominent POC L1/L2 (v404, [06:42]/[07:40]). [ONCE]
- Footprint-cell logic to encode: per-price bid vs offer volume, per-bar delta, candle close direction, and the "red candle + positive delta" absorption flag (v403). [SPECULATIVE — my synthesis of his manual read]
- He guards the algo's internal calculation ("I'm not going to tell you exactly how it's calculated") — exact formula not recoverable from this chunk (v409, [40:51]). [ONCE]

## Q. Notable verbatim quotes (3–10)
- "This market is making new lows on positive delta. Why? There's too much supply." (v403, "Supply Driven Market", [10:34]) [REPEATED concept]
- "Once you remove that supply that was hanging over this market causing it to go down... you're going to be looking for the market to rally higher. Okay, which it did." (v403, [14:16]) [ONCE]
- "We're $15 lower, yet cumulative delta is quite strong. It's double where it was earlier now that we're $15 lower." (v403, [03:26]) [REPEATED]
- "Imbalances are when the volume in the bid or the offer is greater than the other side by a ratio of usually 4:1... I like 4:1, I've always used 4:1 for basically forever." (v410, "Strong Order Flow", [01:17]) [REPEATED]
- "Would I consider this a strong selling imbalance? Well, not really, because the volumes in here are kind of light... the intensity of that imbalance stacked imbalance is just not enough for me. I like it to be a bit stronger in terms of volume." (v410, [05:17]/[06:23]) [REPEATED]
- "What's holding the market from going down is people bidding and bidding strong volumes... it doesn't necessarily have to be the heaviest volume in the bar, but it should be relative to the volume in the bar." (v410, [11:57]) [REPEATED]
- "The Zone end price is the stop price... the Zone start price is where you would add on." (v409, "Orderflows Algo", [33:35]/[42:39]) [REPEATED]
- "The thicker the ice, technically the longer you can stay on it; the thinner ice... eventually it's going to break. And I like to think of that with supply and demand." (v409, [1:03:18]) [ONCE]
- "I'll put more belief in that demand that we have currently than that supply that happened three weeks ago." (v409, [1:19:42]) [REPEATED]
- "Do you want to be a hero and try to buy it off of down 5%? No... if you're wrong your margin for error to get out... you're not going to be able to get out." (v405, "Limit Down", [10:32]) [ONCE]

## R. Contradictions / nuances
- **Lows made on POSITIVE delta** contradicts the naive "new lows = aggressive selling" belief; he insists it signals SUPPLY (passive selling) absorbing aggressive buying, and is a bullish-reversal precursor once supply lifts (v403, [10:34]/[11:15]). Key nuance for the model.
- A **stacked imbalance is not automatically a strong signal** — stacking is necessary but volume intensity decides quality; a perfectly stacked sell imbalance can be ignored if volumes are light (v410, [05:17]). Contradicts treating "3 stacked imbalances" as a binary trigger.
- **Strong order flow ≠ heavy volume** — "strong order flow doesn't necessarily mean heavy volume; it's how the volume is coming in and being traded" (v410, [02:21]). Nuance against a pure volume filter.
- **Bigger zone is not necessarily stronger/safer** — he likes some thickness ("meat on the bones") but rejects very wide zones for risk reasons, and won't claim size = hold probability (v409, [1:00:21]/[1:22:49]). Conditional.
- **Old/untested zones vs recency**: he respects historical untested zones ("can't dismiss it, it was formed for a reason") but trades off current order flow over 3-week-old levels — explicitly "it depends" (v409, [1:18:20]–[1:20:16]).
- **Supply/demand zones are not absolute** — "aren't absolute in the sense that the market is going to always stop and turn at them... often times they will" (v409, [12:08]). Probabilistic, not deterministic.
- "Commodities may follow supply/demand better" is flagged by him as opinion he "hasn't been able to actually do the hardcore analysis on" — [SPECULATIVE], do not encode as a rule (v409, [48:50]).
- Limit-down lesson is about market mechanics, not order-flow reading — he says "this one didn't really talk a lot about order flow" (v405, [12:35]); low value for the reversal model.

## Coverage note
v403 (gold supply-driven bottom) and v410 (ES strong-flow uptrend) are the richest live-tape reads and carry the most reversal/grading model content. v409 is long but ~70% product walkthrough/Q&A; still yields concrete zone-strength, stop/add-on, and zone-thickness rules. v404 gives exhaustion-print thresholds and market/chart selection but little reversal logic; v405 (limit-down) and v407 (encyclopedia ad) are thin for the model. No unparseable sections; all timestamps approximate per source.
