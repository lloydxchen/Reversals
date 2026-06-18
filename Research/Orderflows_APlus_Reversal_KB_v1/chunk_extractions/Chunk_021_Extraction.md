# Chunk 021 Extraction
- Source chunk: Chunk_021_Orderflows_Transcripts.md
- Transcripts covered:
  - v20 — Order Flow Market Analysis Feb 10 ES ZB 6E Futures Day Trading Orderflows (2017-02-12)
  - v21 — Trade Miner Review By Mike At Orderflows Market Analysis Data Mining Software (2017-02-12)
  - v22 — Orderflows Trade Analysis Feb 13 2017 ES ZB YM CL 6E Futures Daytrading Order Flow (2017-02-14)
  - v23 — Orderflows Market Analysis Feb 14 2017 Order Flow Market Recap ES CL 6E YM ZB Futures (2017-02-15)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Delta divergence** (equal high / new high + negative delta, or equal low / new low + positive delta) — bearish divergence used throughout v20 and v22/v23; primary signal type. (v20, "Order Flow Market Analysis Feb 10", [01:03]; v22, "Trade Analysis Feb 13", [01:32])
- **Divergence + ratio combo** — divergence bar followed by confirming bullish/bearish ratio in the *next* bar; described as a higher-quality version of a plain divergence. (v20, [04:12]; v22, [02:26])
- **Stacked imbalance (buying / selling)** — used as continuation and potential reversal signal; "opposing" stacked imbalance (same-color then opposite-color within ~5 bars) = "very high percentage trade" in the opposite direction. (v20, [02:50]; v23, [19:17])
- **Opposing / counter stacked imbalance reversal** (bearish): stack buying imbalance → within 4 bars a stack selling imbalance appears → go short. Explicitly called "very high percentage trade." (v23, [19:17])
- **Single print + bullish ratio** (bullish) — combination appearing at lows in bonds. (v20, [09:14])
- **POC at bottom / top of candle** — green candle with POC at the bottom or red candle with POC at the top; described as "very potent bars." (v20, [11:08]; v23, [21:34])
- **Delta surge** — free indicator that reads cumulative delta; gives directional buy/sell signals. (v20, [08:18]; v23, [05:12])
- **Three ratios in a row** (bullish) — three consecutive bullish ratios treated as a cluster signal, mentioned alongside stacked imbalance as confluence off a low. (v23, [27:15])
- **Multiple divergences in quick succession (4 in short window) on trend day** — four divergences hitting a high within ~30-40 min signals the market is *still* trending higher, not reversing. (v20, [01:28]; v22, [02:26])
- **Transition Indicator** — proprietary bar-chart indicator detecting supply→demand or demand→supply market transition. Used on 1-min and tick charts. (v20, [17:55]; v22, [00:59])
- **U-Turn Indicator** — proprietary swing-point detector (hash symbol on chart). Settings example: 3 and 25 on bar chart. (v20, [14:23]; v23, [30:30])
- **Flip Indicator** — proprietary signal; arrow-based. Settings example: 5 and 25. (v22, [00:59]; v23, [09:27])
- **Price Rejector** — appears at swing highs/tops as a sell signal (mentioned in passing). (v20, [02:25]; v23, [19:44])
- **"Four divergences rule" on trend days (bearish)** — four new highs with divergences in quick succession → warning to NOT keep shorting divergences; look for fifth as potential final leg. (v20, [01:28]; v22, [02:26])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"Very high percentage trade"** — applied to the opposing/counter stacked imbalance setup (stack buy then stack sell within 4 bars → go short). (v23, [19:17]) [ONCE]
- **"Textbook beautiful day to trade"** — applied to the euro currency on Feb 10, where the Transition indicator gave multiple clean signals without chop. (v20, [25:56]) [ONCE]
- **"Gangbuster signals"** — applied to the euro currency Transition signals on Friday (v20) contrasted against "a bit tougher" on Monday (v22). (v22, [08:42]) [ONCE]
- **"Nice buy / it was straight up"** — applied to a clean euro currency buy that needed no qualification. (v20, [13:22]) [ONCE]
- **"Not that great a day"** — crude oil on Feb 10; small numbers, needed to be in earlier. (v20, [13:53]) [ONCE]
- **"Kind of pathetic numbers"** — stacked imbalance with tiny volume (146, 12, 44 on e-mini) vs. 700–1,500 a few bars later; small-volume stacked imbalance is explicitly downgraded. (v20, [02:50]) [ONCE]
- **"More encouraging"** — stacked imbalance with volumes 3–4× larger than the prior one; upgrades the signal. (v20, [03:44]) [REPEATED — sizing/volume quality of the imbalance matters]
- **"Bullish sign followed immediately by bearish sign → reason for trade is gone"** — explicit invalidation language: if the very next bar negates, exit/skip. (v20, [06:55]) [REPEATED]
- **"Close but no cigar"** — ratio of 74 vs. threshold of 69 (defense ratio); does not meet qualification. (v23, [25:53]) [ONCE]
- **"Not necessarily convinced"** — used when imbalance or divergence appears but follow-through or volume quality is missing. (v20, [02:50]; v22, [03:46]) [REPEATED]
- **"Very potent bars"** — POC at bottom of green candle or top of red candle. (v23, [21:34]) [ONCE]
- **"Quite telling"** — large counter-delta bar that closes green at a low = strong absorption signal. (v23, [17:16]) [ONCE]

---

## C. Order-flow story & psychology per setup

- **Trend-day absorption narrative (v22 ES)**: Passive buyers ("people happy to work bids") accumulated ~30,000 lots across multiple bars at support level; aggressive sellers sold into them (9,000, 7,000 lots); once selling exhausted, market had no downward fuel — buyers remained, price lifted. "Once that selling gets exhausted, where's the market going to go? It's going to go up because it's not going to go lower when the selling is exhausted." (v22, [06:37]) [ONCE]
- **Delta exhaust + reversal five-bar structure (v23 6E)**: Delta accelerates downward → peak negative delta → weakens → near-neutral → positive delta accelerates on way back up; described as "strong / less strong / neutral / strong / stronger" pattern. (v23, [02:25]) [ONCE]
- **Opposing imbalance trap (v23 ES)**: Stack buying imbalance appears; within 4 bars a stack selling imbalance forms in same zone — buyers trapped long, sellers now dominant, price sells off. Market "goes with the direction" of the second (opposing) imbalance. (v23, [19:17]) [ONCE]
- **Divergence cluster → trend continuation**: Multiple divergences (3–4) at highs in quick succession on a trending day = trapped shorts squeezed repeatedly, NOT a reversal signal; only look for reversal after the 4th or later. (v20, [01:28]) [REPEATED]
- **Negative delta bar that closes green** (v23 ZB): Bar has −1,100 delta but closes as a green bar → large passive buying absorbed the selling; "quite telling" signal for upside. (v23, [17:16]) [ONCE]

---

## D. Exhaustion clues

- Multiple new highs (4+) with divergences in quick succession on a 3-range chart within ~30-40 min = aggressor buying exhausting at each new high; each divergence = more trapped buyers, but not enough to reverse until 4th+ hit. (v20, [01:28]; v22, [01:58]) [REPEATED]
- Delta goes to near-zero then reverses direction at a swing extreme = aggressor exhaustion (5-bar Delta pattern: strong→weaker→neutral→stronger in opposite direction). (v23, [02:25]) [ONCE]
- Divergence at a low after a large fast move (low-to-high in <1.5 hours) = be cautious — "we literally just went from the low right up to the high"; context matters in interpreting divergences at highs. (v23, [28:12]) [ONCE]
- Stacked imbalance with very small absolute volumes ("pathetic numbers") = weak exhaustion signal; not enough conviction behind the imbalance. (v20, [02:50]) [ONCE]

---

## E. Absorption clues

- Heavy volume at a price level (e.g., 32,800 traded vs. <1,000 elsewhere in the move) with no corresponding price progress = absorption of aggressive sellers by passive buyers. (v23, [15:11]) [ONCE]
- POC at bottom of green candle = buyers aggressively working the bottom of that bar's range; "support right at the bottom." (v20, [11:08]; v23, [21:34]) [REPEATED]
- Negative delta bar that closes green: market absorbs selling and turns up within the same bar. (v23, [17:16]) [ONCE]
- Large bid volumes in multiple bars near a level (7,000 / 9,000 / 2,300 / 2,600 in successive bars = passive buying on the bid). "People are passively buying it, happy to work bids." (v22, [06:07]) [ONCE]
- Selling imbalance (1,700) near a bounce point + overall large volume at that level = sellers drying up, buyers defending. (v23, [23:34]) [ONCE]

---

## F. Stacked imbalance ideas

- Stacked imbalance volume quality determines signal strength: volumes of 146/12/44 = "kind of pathetic"; 700/1,500/1,300 (3-4× larger) = "more encouraging." Raw imbalance alone is insufficient; the absolute volume in the imbalance cells matters. (v20, [02:50]–[03:44]) [REPEATED]
- Imbalances at a breakout (new high): "I always like to get imbalances when you're breaking through new highs because that's a sign that new buying is coming in." (v20, [04:12]) [ONCE] NEEDS-OPERATIONALIZATION
- **Opposing stacked imbalance** within ~4 bars = "very high percentage trade" — go in direction of the second imbalance. Explicit setup: stack buy imbalance → 1-4 bars later → stack sell imbalance → go short. (v23, [19:17]) [ONCE]
- Stacked imbalance followed by confirming ratio in next bar = "I always like to look for the ratio afterwards." (v20, [04:12]) [REPEATED]
- Selling stacked imbalance with negative delta → bullish ratio next bar = stalled bearish setup; market went sideways then higher. (v20, [05:29]) [ONCE]

---

## G. Delta / delta-divergence ideas

- **Four-divergence rule for trend days**: When 4 new highs each produce a divergence within ~30-40 min, this is a *sign the market can still move higher*, not a reversal. "I've already had four divergences and we're coming in here taking out the high again." Don't fade every divergence on trend days; look for the move after the cluster. (v20, [01:28]; v22, [01:58]) [REPEATED]
- **Divergence + ratio in the same bar** = strongest version; "a buying divergence and a bullish ratio" in one bar, but then immediately negated by bearish ratio next bar = reason for trade gone. (v20, [06:55]) [ONCE]
- **Divergence + ratio in next bar** = standard quality entry; "I always like to look to the next bar to see if there is a ratio." (v20, [08:45]) [REPEATED]
- **Rising delta at a high while still making new highs** = trend continuation, not reversal: "you got delta surge so you got delta increasing right at the high, so buyers are coming in and you just keep making new highs." (v23, [29:15]) [ONCE]
- **Five-bar delta pattern** (for reversal identification):
  1. Strong negative delta (e.g., −92)
  2. Less strong negative delta (e.g., −45)
  3. Near-neutral (e.g., +12 turning up)
  4. Positive delta (e.g., +22)
  5. Stronger positive delta (e.g., +42)
  = "very powerful / strong signal." Explicitly described as what to look for: "getting weaker on the way down, getting stronger on the way up." (v23, [02:25]) [ONCE]
- **Defense ratio threshold**: 69 (or "I use uh 7 or I think 69" — context suggests ≤0.69 ratio value). A ratio of 74 = "close but no cigar." (v23, [25:53]) [ONCE]
- **Three ratios in a row** = cluster signal; listed alongside stacked imbalance and Delta surge as confluence at a low. (v23, [27:15]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Opposing imbalance reversal** = functional equivalent of a failed breakout: market makes a new high/low through the imbalance zone but immediately encounters the opposing imbalance and reverses. (v23, [19:17]) [ONCE]
- Divergence at a new high where price continues higher rather than reversing = "on days where the market is going to trend higher, you'll often get groups of divergences in quick succession" — the failure of each divergence to produce a reversal is itself a trend-day confirmation signal. (v20, [01:28]) [REPEATED]
- At the cash open: quick down-then-up or up-then-down swing (5-minute range) = "you get these reactions at the open" — wait for it to settle before trading. (v23, [20:42]) [ONCE]

---

## I. Trapped-trader ideas

- **Trend-day divergence trap**: Traders who repeatedly short divergences on a trend day ("you'd have all these losing trades") are trapped short; their covering fuels the continuation. (v20, [05:07]) [ONCE]
- **Opposing imbalance trap**: Buyers who entered on the stack buying imbalance get trapped when the stack selling imbalance fires in the same zone. (v23, [19:17]) [ONCE]
- Passive sellers who sold into the 9,000/7,000 bid volume zone (v22 ES) become trapped when selling exhausts and market lifts: "once that selling gets exhausted… it's going to go up." (v22, [06:37]) [ONCE]

---

## J. Entry triggers (the exact "go" event)

- **Opposing stacked imbalance**: Entry trigger = the stack imbalance in the opposing direction forms. "Go with this direction." (v23, [19:17]) [ONCE]
- **Divergence + ratio combo**: Entry trigger = ratio fires in the bar after the divergence bar; "in this bar it gives you the divergence and in the next bar you have the bullish ratio with the single print." (v20, [09:14]) [REPEATED]
- **Breaking through new highs with imbalances**: Entry trigger (continuation) = imbalance appears in the breakout bar; confirms "new buying coming in." (v20, [04:12]) [ONCE]
- **Four-divergence cluster completion + market still at highs**: Entry trigger (long) = the market takes out the high *again* after 4 divergences; "I got long, I was trying to get in at 2 and a half." (v22, [02:50]) [ONCE]
- **Five-bar delta turn**: Entry in the 3rd or 4th bar as delta weakens toward neutral and then green. (v23, [02:25]) [ONCE] NEEDS-OPERATIONALIZATION (exact bar not specified)
- **POC-at-bottom green candle**: Entry watch = next bar or at the POC level. "Watch for those POCs at the bottom of the bars or at the top." (v20, [12:33]) [REPEATED]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- After divergence + ratio entry: market should break to new highs immediately ("and watch what happens, you start working your way up"). (v20, [09:44]) [REPEATED]
- After opposing stacked imbalance: market should come off and make a new low (in the bearish case). (v23, [19:17]) [ONCE]
- After buy trigger at low: should see "some strong deltas" — rising delta values over subsequent bars. (v23, [16:17]) [ONCE]
- After entering a trend-day long at the high re-test: the market should "not really sell off" — large bid volume at support confirms ongoing demand. (v22, [05:40]) [ONCE]
- Imbalances should appear when price breaks to new highs (breakout confirmation). (v20, [04:12]; v23, [27:47]) [REPEATED]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Bullish sign immediately negated by bearish sign**: "When I get a bullish sign followed up immediately by a bearish sign I'm not that interested in staying in the trade." Specifically: divergence + bullish ratio → next bar bearish ratio = exit/skip. (v20, [06:55]; v23, [22:02]) [REPEATED]
- **Ratio of wrong color in next bar**: POC-at-bottom green candle at 9:00 on v23 ES — "I always find this very bullish *however* this comes right after a bearish ratio so I'm hesitant to take trades where you have a bearish number then a bullish number right in the next bar." (v23, [22:02]) [ONCE]
- **Stacked imbalance with low absolute volume**: "I know that this bar can move very quick so I'm not necessarily convinced." (v20, [02:50]) [REPEATED]
- **Large opposing imbalances appearing after entry**: "When I see big imbalances going against me, usually a sign for me to get out." (v23, [24:54]) [ONCE]
- **Market makes the move too fast for stop management**: fast-moving market after 9:00 = "you got to be trailing your stop." Stop at around 3–4 ticks above the recent high if short. (v23, [23:34]) [ONCE]

---

## M. Stop / risk / target / trade management

- **Stop: 5–10 ticks on mini-Dow, with 10 ticks as the widest acceptable.** "10 ticks would for me be about as wide as I go on this contract." (v20, [23:07]) [ONCE]
- **Trailing stops on trend days**: As price extends, trail the stop to lock in gains; if short and price bounces to 3–3.5 points above entry, tighten stop to that level. (v23, [23:34]) [ONCE]
- **Time/context stop — fast market**: If market moves very fast (v23 ES post-9am), do not give it room to 5-tick stop; trail more aggressively. (v23, [24:01]) [ONCE]
- **First profit target on 3-range e-mini**: "normally I'd be looking at about two to three points" as initial take profit. (v22, [05:16]) [ONCE]
- **Extended target on trend day (3-range e-mini)**: "I was expecting more of a move today — a one-way move — so I put my offer up at 7 and 3/4, about five points." Filled near high of day. (v22, [05:16]) [ONCE]
- **Stop management rule**: Do NOT get short off a divergence at a high when the move was straight from the low to the high ("take things in context — it's not like we just been meandering around for hours"). (v23, [28:12]) [ONCE]
- **Transition indicator trailing example**: In euro 1-min, if long and trailing, cover when price probe reverses and comes back to key level; "below 50 you should have a stop at 50." (v20, [18:44]) [ONCE]
- **"As long as you're just risking 6-7-8 ticks a trade but catching 20-30 tick winners"** — articulates the expected edge; willing to take 7 losses if each is small to capture 1 large winner. (v20, [23:34]) [ONCE]
- **Second-chance re-entry**: Not explicitly mentioned in this chunk; however, staying in a trade through multiple 4-divergence sequences on a trend day implies not exiting on first divergence. (v22, [02:50]) [SPECULATIVE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Cash open filter**: "I don't trade during the cash open. I let it settle down after about 5 minutes and then trade." Specifically mentions 8:30 open, wait 5 min. Reason: "you get these reactions — move down then move up right." (v23, [20:15]) [REPEATED]
- **Mini-Dow (YM)**: "Wait till the cash open. There's no point in trading it in the pre-market." Strong endorsement: "I've become attracted to trading the mini-Dow — I think it's a great contract." (v20, [20:28]) [ONCE]
- **Chart speed selection by market volatility**: "If it's moving fast I'll stick to a 10-range [e-mini]; if it's moving slow I'll go with a shorter duration." (v23, [34:20]) [ONCE]
- **Instruments Mike watches**: Mini-Dow (YM), e-minis (ES), bonds (ZB), crude (CL), euro currency (6E). (v23, [33:41]) [REPEATED]
- **Chart types per instrument**:
  - Mini-Dow: 100-tick and 10-range and 5-range
  - Euro currency: 1-minute, 8-range, 987-tick
  - E-minis: 3-range and 10-range
  - All Commodities watched: similar tick/range combos (v23, [33:41]) [ONCE]
- **Divergences during news/trend days**: "On days where the market is going to trend higher/lower you'll often get groups of divergences" — avoid trading every divergence; filter for trend context. (v20, [01:28]) [REPEATED]
- **S&P and bonds correlation**: "I don't like to be long bonds and long S&P." (v22, [16:40]) [ONCE]
- **Pre-cash imbalances (ahead of 8:30 open)**: "I wouldn't be looking to take any trade like this right ahead of the cash open... you tend not to get these nice moves once you're trading right ahead of the cash open." (v23, [18:21]) [ONCE]
- **Order flow reads better on live data only**: "Don't install it on your chart thinking it's going to plot on historical data. It's got to read the data as it's coming in in real time." (v20, [19:56]) [ONCE]
- **Dollar-related FX pairs (2017 context)**: Extra caution on USD pairs due to political uncertainty; prefer non-USD crosses. (v21, [07:00]) [SPECULATIVE — 2017-specific]

---

## O. Directly testable / measurable variables

- Stacked imbalance absolute volume threshold: "I like to see above a thousand at least one of these numbers" (bonds context). Volumes of 146/12/44 = "pathetic"; 700/1,500/1,300 = acceptable. (v22, [16:40]; v20, [02:50]) — NEEDS-OPERATIONALIZATION (exact minimum varies by instrument/liquidity)
- Stacked/opposing imbalance window: opposing imbalance counts as "very high percentage" if it fires within ~4 bars of the original imbalance. (v23, [19:17]) — 4 bars stated explicitly
- Defense ratio threshold = 69 (or 0.69 expressed as a ratio). Bar with ratio 74 = does not qualify. (v23, [25:53])
- Imbalance ratio for a "confirming ratio" after divergence: bullish = blue number, appears next bar. Bearish = opposite. (v20, [04:12]) — exact numeric threshold not stated here; [NEEDS-OPERATIONALIZATION]
- Five-bar delta structure: delta sequence strong-negative → weaker-negative → near-neutral → positive → stronger-positive = reversal signal. (v23, [02:25]) — NEEDS-OPERATIONALIZATION (no specific delta value thresholds given)
- Four divergences within ~30-40 min on 3-range chart = trend-day cluster signal (do not fade until 4th+). (v20, [01:28])
- Stop on mini-Dow: 5–10 ticks; maximum 10 ticks. (v20, [23:07])
- Initial take profit on 3-range e-mini: 2–3 points; extended target on trend day: 5 points. (v22, [05:16])
- Cash open wait time: ~5 minutes after 8:30 CT before trading. (v23, [20:15])
- Chart type selection: 3-range or 10-range ES depending on speed; 100-tick, 10-range, 5-range YM; 1-min, 8-range, 987-tick 6E. (v23, [33:41])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Order Flow data must be read live**: cannot plot order flow correctly on historical bars — indicator must accumulate tick-by-tick as data arrives. (v20, [19:56]) [REPEATED]
- **Four indicator suite**: Orderflows Trader (footprint), Volto Flip, Volto U-Turn, Volto Transition — all mentioned as the tool set used in this chunk's analysis. (v22, [00:59]) [REPEATED]
- **U-Turn settings**: example "3 and 25" on bar chart; does not pick every swing but identifies higher-quality ones. (v20, [14:23]) [ONCE]
- **Transition Indicator**: detects supply→demand or demand→supply transitions; works on 1-min and tick charts; requires live data; settings example "3, 100, 400" on 1-min 6E and "4, 3, 100, 400" on YM 100-tick. (v20, [14:56]; v20, [21:27]) [ONCE]
- **Flip settings**: "5 and 25" on 5-range YM. (v23, [09:27]) [ONCE]
- **Delta Surge**: free downloadable indicator; reads cumulative delta, plots directional buy/sell arrows; requires restart after install in NinjaTrader; does NOT work correctly on fast 4-range charts. (v23, [05:12]; v23, [06:02]) [ONCE]
- **Price Rejector**: appears at swing tops as a bearish signal; present in multiple markets. (v20, [02:25]; v23, [19:44]) [REPEATED]
- **Implication for A+ indicator**: stacked imbalance volume check = not just count of stacked cells, but the absolute volume in each cell relative to surrounding bars; a low-volume stacked imbalance should receive a lower grade or be filtered. (v20, [02:50]) [SPECULATIVE]
- **Chart construction matters**: using the correct range/tick size per market is essential; too-fast charts (4-range on crude) make all signals nearly untradeable. (v23, [06:02]) [REPEATED]

---

## Q. Notable verbatim quotes

1. "The reason for taking this trade is gone already. When I get a bullish sign followed up immediately by a bearish sign I'm not that interested in staying in the trade." (v20, "Feb 10 ES ZB 6E Analysis", [06:55])

2. "I always like to get imbalances when you're breaking through new highs because that's a sign that there's new buying coming in, that's going to help move the market higher." (v20, [04:12])

3. "Here you've got what I call opposing imbalances — a stack buying imbalance and then within that five bar range you have a stack selling imbalance. Usually this is a very high percentage trade." (v23, "Feb 14 ES Analysis", [19:17])

4. "Once that selling gets exhausted, where's the market going to go? It's going to go up because it's not going to go lower when the selling is exhausted because there's buyers there that are happy to buy it there." (v22, "Trade Analysis Feb 13", [06:37])

5. "This five bar structure is very — I say powerful but it's a strong, usually a strong signal. What you have is you're coming down, delta is picking up, it's very strong, gets weaker, gets kind of neutral right in the middle, and then it starts growing on the way back up. Strong, less strong, neutral, strong, and stronger." (v23, [02:25])

6. "On days where the market is going to trend higher or lower, you'll often get groups of divergences in quick succession — and if they happen within 15 minutes you've got four already. To me that's a sign that we could be bumping up higher later in the session." (v20, [01:28])

7. "146, 12, 44 — those are kind of pathetic numbers. Here you've got 700, 1,500, 1,300 — that's stronger — that's three or four times stronger than what you had back here." (v20, [02:50]–[03:44])

8. "Watch for those POCs — at the bottom of the bars or at the top of bars — for a bottom for a green candle and at the top for a red candle." (v20, [12:33])

9. "I don't trade during the cash open. I let it settle down after about five minutes and then trade — because I know that lots of times you get these reactions." (v23, [20:15])

10. "You have to look at things in context. It's not like we've been meandering around the highs for hours — we literally just went from the low right up to the high. Be careful." (v23, [28:12])

---

## R. Contradictions / nuances (anything that conflicts with common belief, with his other statements, or that is conditional/"it depends")

- **Divergences at highs on trend days are bullish, not bearish**: The same divergence signal that is a sell in a reversal context is explicitly a "stay long / look for more upside" signal when 3-4 fire in quick succession on a trending day. This directly contradicts the reflexive use of divergence as a fade signal. (v20, [01:28]; v22, [02:26]) [REPEATED]
- **Rising delta at a new high = continuation, not exhaustion**: When the Delta Surge fires long (positive delta increasing) at a new high on a trend day, it confirms higher prices, not a reversal. Contradicts the common reading of "high delta at extremes = exhaustion." (v23, [29:15]) [ONCE]
- **Bearish ratio immediately after a bullish ratio = full invalidation**: He does not require 2 failures; a single immediate reversal signal in the very next bar kills the entire thesis. (v20, [06:55]) [REPEATED]
- **POC at bottom of green bar is "very bullish" — UNLESS the prior bar was bearish**: "I always find this very bullish; however, it comes right after a bearish ratio so I don't like to take trades where you have a bearish number then a bullish number right in the next bar." Conditional quality: POC-bottom bar only qualifies if it appears in clean context. (v23, [22:02]) [ONCE]
- **Stacked imbalance with low absolute volume = downgraded or skipped**: The model normally treats stacked imbalance as a strong signal; Mike explicitly downgrades it when the absolute volume in the imbalance cells is tiny relative to surrounding bars. Implied rule: volume quality of imbalance cells is a required qualifier. (v20, [02:50]) [REPEATED]
- **Pre-cash-open imbalances are NOT reliable triggers**: "I wouldn't be looking to take any trade like this right ahead of the cash open." Even a valid stacked imbalance before 8:30 should be discounted. (v23, [18:21]) [ONCE]
- **Order flow data is meaningless on historical bars**: "Don't install it on your chart thinking it's going to plot on historical data. Order flow is about reading the trades that are coming in in real time — that data doesn't accurately reflect what's going on." Implications for backtesting: any historical backtest of footprint signals is inherently compromised. (v20, [19:56]) [ONCE]
- **v21 is entirely a third-party software review** (Trade Miner) with no order flow model content. Should be noted as off-topic for the reversal model.

---

## Coverage note

- v20 (Feb 10 ES/ZB/6E analysis) and v23 (Feb 14 recap) are the richest for the reversal model: v20 covers trend-day divergence clustering and stacked imbalance volume quality in detail; v23 contains the opposing-imbalance setup, five-bar delta pattern, and absorption narrative.
- v22 (Feb 13 recap) adds useful absorption/passive-buying narrative and the trend-day holding trade example; moderate model density.
- v21 is entirely a promotional review of "Trade Miner" (a seasonal-pattern data mining tool) — zero reversal model content; thin/irrelevant for this KB.
