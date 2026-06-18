# Chunk 038 Extraction
- Source chunk: Chunk_038_Orderflows_Transcripts.md
- Transcripts covered:
  - v100 — Orderflows Market Analysis Sept 11 Crude Oil Futures Eurocurrency Day Trading Delta Scalper Surge (2017-09-12)
  - v102 — Orderflows Trader Volume Footprint Chart And NinjaTrader 8 NT8 (2017-09-14)
  - v103 — Orderflows Market Analysis September 14 2017 Japanese Yen North Korea Effect Emini SP Delta Scalper (2017-09-15)
  - v104 — Orderflows Market Analysis September 15 2017 Emini SP Mini Dow YM Soybean ZS Futures Day Trading (2017-09-16)
  - v106 — Orderflows Market Analysis September 18 2017 Emini SP Soybeans Day Trading Futures Delta Scalper (2017-09-19)
  - v107 — Orderflows Market Analysis September 21 2017 Huge Volume In The Market Eurocurrency British Pound Bonds (2017-09-22)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Divergence + Ratio (next-bar variant)** — bearish/bullish: divergence fires on bar N, ratio fires on bar N+1. Explicitly stated as the core trade setup, appearing "almost every day" across his regular markets. (v100, "Sept 11 Crude Oil," [02:25]; v103, "Sept 14 Yen," [05:42]; v106, "Sept 18 Emini," [02:18]) [REPEATED]
- **Delta Scalper buy/sell** — a tool signal confirming momentum shift; used in confluence with divergence+ratio. Functions as an additional bonus signal rather than standalone entry. (v100, [01:57]; v103, [05:42]; v106, [03:17]) [REPEATED]
- **Point of Control (POC) on the extreme** — POC at top of bar = bearish; POC at bottom of bar = bullish. Explicit standalone bearish/bullish signal. (v100, [02:55]; v103, [12:59]; v104, [16:51]) [REPEATED]
- **Single print** — thin area of volume that forms at an extreme; used as additional confluence for price rejection. (v100, [02:25]; v103, [06:09]; v104, [12:26]) [REPEATED]
- **Stacked selling/buying imbalance** — directional signal; but immediately countered by an opposite-color ratio = signal fails. (v100, [09:07]; v103, [08:24]) [REPEATED]
- **Multiple imbalances in a bar (non-stacked)** — 3+ imbalances in one bar in the same direction; directional clue; boxed on chart. (v102, "NinjaTrader 8 NT8," [09:38]; v103, [09:07]) [REPEATED]
- **Price Rejector signal** — 4-factor tool; sell signal at highs / buy signal at lows. Used in conjunction with divergence+ratio. (v103, [07:32]; v104, [12:26]; v107, "Huge Volume," [08:06]) [REPEATED]
- **Supportive buying** — large volume absorbed without price moving in the direction of the aggressor; specifically: strong negative delta but green bar turning up = supportive buying (bulls absorbing supply). Cited as a setup type distinct from regular divergence. (v104, [04:27]; v104, [07:22]) [REPEATED]
- **Stacked imbalance followed by opposite stacked imbalance** — when a stacked buying imbalance is immediately followed by a stacked selling imbalance (or vice versa), treated as a directional continuation signal in the direction of the second set. (v103, [10:06]) [ONCE]
- **Delta Surge buy/sell** — free indicator detecting sharp delta spikes; used on Renko and range charts. (v100, [22:39]; v106, [14:14]) [REPEATED]
- **Massive single-price bid/offer volume** — e.g., 1026 lots traded at one price level in euro currency; treated as strong supportive buying signal visible only in footprint. (v107, [01:19]) [ONCE]
- **Heavy offer-side volume on top of red bar (bonds)** — extremely bearish: 1473 on offer vs 1713 on bid on a down candle; described as "very rarely" seen and "extremely bearish." (v107, [07:13]) [ONCE]
- **Three failed divergences = trend day signal** — three divergences that fail in ~1 hour at the same level = look for breakout in direction of trend, not reversal. (v104, [22:18]) [ONCE]

---

## B. Tiering / grading language — HIGH PRIORITY

- **"Beautiful one"** — setup at [06:09] of v103 (Yen): divergence + ratio + Delta scalper + POC near high all on the same bar at a swing high. The only thing missing that would make it "look a lot nicer" = stacked selling imbalances. Explicitly grades the absence of stacked imbalances as the difference between "beautiful" and perfect. [ONCE]
- **"Worth the shot"** — used for a trade that has a legitimate reason (divergence + ratio) even if not all boxes checked. (v100, [06:57]) [ONCE]
- **"Nice / nice positive Delta"** — delta of 356–500+ on e-mini context (2017); 79 is "on the weak side / borderline neutral"; ~50 = neutral; these are the thresholds he uses at the moment of entry to grade delta quality. (v100, [02:25]) [ONCE]
- **"Not the greatest" / "nothing to get too excited about"** — divergence with no ratio; not tradeable, just a flag. (v106, [01:50]) [REPEATED]
- **"Halted / half-hearted move"** — bonds signal that only got 4 ticks: "nothing major, half-hearted move." (v100, [17:52]) [ONCE]
- **"Textbook" / "these trade setups happen every day"** — divergence+ratio+Delta scalper = the recurring bread-and-butter setup; not graded A+ here but implied as grade A. (v100, [13:34]) [REPEATED]
- **"Interesting" but not tradeable** — divergence+bullish ratio+bearish bar at bond low: "can you take that trade, yeah… it's just unfortunate that next bar it got slammed again." (v100, [15:55]) [ONCE]
- **"Sketchy"** — alternating positive/negative deltas at a low off failed signals; requires additional stack imbalance + Delta scalper for conviction. (v106, [16:13]) [ONCE]
- **"Should feel a little bit confident"** — stacked buying imbalance + Delta scalper after 2 prior failed signals = confidence is building but still not A+. (v106, [17:39]) [ONCE]
- **"This one here was worth the shot"** — any trade with "a legitimate reason to buy off the low" is worth the shot; context: divergence+ratio. (v100, [06:57]) [ONCE]
- **What makes difference up a tier**: stacked imbalances in addition to divergence+ratio pushes from "beautiful" to "perfect/A+." POC on extreme is a downgrade if it conflicts with the signal direction (v103 bonds, [14:13]). Opposing ratio in next bar after stacked imbalance = kill signal. (v103, [08:24]; v103, [10:06]) [REPEATED]

---

## C. Order-flow story & psychology per setup

- **Long trapped at high (POC on extreme, bearish ratio, single print)**: "buyers bought 500, 300… why aren't they buying anything else up here and taking the market higher? Instead these people are caught off sides and the market starts ticking down, they become sellers hitting bids." Classic trapped-longs narrative. (v100, [03:42]) [REPEATED]
- **Supportive buying story** — negative delta + up bar or bar turning up = strong buyers bidding the market, absorbing aggressor selling. Market "doesn't sell off" despite strong negative delta because big buyers are defending. The question to ask: "Why isn't the market selling off with strong negative delta? Because you've got strong buyers up here." (v104, [07:22]; v104, [04:27]) [REPEATED]
- **Stacked imbalance invalidated by immediate counter-ratio**: After stacked selling imbalances, a bullish ratio in the very next bar means "the sellers aren't in control, the argument for short is falling apart." Market retraced almost immediately. (v103, [08:24]) [REPEATED]
- **Retail vs. institutional reaction to news** — "people that are reacting to [geopolitical news] are the retail traders; dealers and bank traders are discounting it." Market gives back two-thirds of geopolitical spike in three minutes. (v103, [01:02]) [ONCE]
- **Sellers defending prices** — Mike distinguishes between "buyers rejecting prices" (early bounce attempt fails) vs. "sellers defending prices" (sellers step in and hold): 2nd test of a high with sellers willing to work offers = defense. Uses term "defense" not "resistance." (v104, [17:17]) [ONCE]

---

## D. Exhaustion clues

- **Declining delta across consecutive bars approaching a high** — e.g., 633 → 27 → 23 (positive but shrinking to near-neutral) into a swing high. Even if delta stays technically positive, the shrinkage is exhaustion. "Delta is weakening, it's getting lesser." (v106, [10:53]; v106, [13:13]) [REPEATED]
- **Delta drops -300 per bar in a consistent staircase** — crude oil example: each bar loses ~300 aggressive buy contracts; this methodical decline is cleaner exhaustion than an abrupt flip. (v106, [14:16]) [ONCE]
- **Single print + ratio + POC near extreme at swing high** — the triple-confluence exhaustion footprint. (v103, [06:09]; v100, [02:25]) [REPEATED]
- **"Sooner or later… making new lows with positive delta, the market is going to bounce"** — persistent positive delta at new lows = buy-side exhaustion of sellers; eventually force a bounce. (v100, [17:22]) [ONCE]
- **Volume declining on retests of high/low** — 2nd test of high: 35 lots → 3rd test: 3 lots = sign of price rejection and buyer exhaustion at that level. "Every time you hit a high or low and get less volume, it's telling me signs of price rejection." (v104, [12:26]) [REPEATED]

---

## E. Absorption clues

- **Strong negative delta but bar closes green / market turns up** — paradigm example of supply absorption: "just because you got one bar with negative delta doesn't mean it's the end of the world… you got supportive buying and it turned back up, that's actually bullish." (v100, [08:19]) [REPEATED]
- **Massive volume at a single price in footprint** — 1026 lots at one euro currency price level = "very strong supportive buying, people stepping up at this price level saying I'm a bidder here, I'll buy everything." Invisible on a bar chart. (v107, [01:19]; v107, [01:51]) [ONCE]
- **Large volume at or near prior buying zone** — pre-cash aggressive buying zone coincides with later strong negative delta; market doesn't sell off = the prior buyers are absorbing the selling. (v104, [04:27]) [ONCE]
- **Very high volume with no directional follow-through** — "spinning your wheels… trading huge volumes 49,000–61,000 [on 4-range] and the market isn't budging" = absorption at lifetime high. (v104, [08:11]) [ONCE]

---

## F. Stacked imbalance ideas

- **Stacked imbalance followed by opposite-colored ratio in next bar = signal failure**: "when you see stacked imbalances and you come right back with a bullish ratio [i.e., opposing ratio] in the next bar after your stacked imbalance, it's not going to be very effective." Applies both ways (bullish stack + bearish ratio = fail; bearish stack + bullish ratio = fail). (v103, [08:48]; v103, [10:06]) [REPEATED]
- **Stacked imbalance in direction of move + Delta scalper = confidence signal** — stacked buying imbalance off low after prior failed signals = "should feel a little bit confident." (v106, [17:39]) [ONCE]
- **Stacked imbalance followed immediately by opposite stacked imbalance** — explicitly "not a good thing if you're long; the best thing to do is go with the direction of the next [second] stacked imbalance or do nothing." (v103, [10:30]) [ONCE]
- **Minimum volume threshold for stacked imbalance** — he uses 50 as default minimum volume per imbalance cell; notes if set at 38 or lower would have counted a near-stack. Choosing threshold affects what counts as stacked. (v104, [15:32]) [ONCE]

---

## G. Delta / delta-divergence ideas

- **Neutral delta band explicitly stated as ~50 but with leeway to 25** — "anywhere between 50 to 200 or 25 to zero, that's kind of neutral; I'm willing to give it a little bit of leeway." Delta of 23 at a swing high still treated as "weak/neutral" not bullish. (v106, [11:49]) [ONCE]
- **Delta weakening is directional even if still same sign** — positive delta declining from 633→327→23 = "delta is weakening, even though it's still positive." The direction of change matters, not just the sign. (v106, [10:53]) [REPEATED]
- **Negative delta + green bar = supportive buying (bullish)** — "just because you got negative delta and a red candle doesn't mean all the trade is over; watch what's happening… seeing how it turned back up and closed higher is actually bullish." (v100, [08:19]) [REPEATED]
- **Positive delta + red bar = counter-signal** — crude oil: strong positive delta (430) but bar turns down = "offers up here; the bar itself is telling you something completely different." Mixed/bearish signal when delta disagrees with candle direction. (v106, [09:12]) [ONCE]
- **"From minus 988 to basically neutral" = bullish sign** — delta recovering from extreme negative toward neutral (not necessarily positive) counts as bullish sign worth considering a trade. (v100, [15:55]) [ONCE]
- **Shifts in delta across bars as a transition signal** — "I like how you get shifts in delta like this, from nice strong positive to a neutral one to a strong negative — I always treat that as a nice sign" for a reversal. (v103, [16:02]) [ONCE]
- **More volume second time at double top = bearish** — "the one thing that would have convinced me more is if you had less volume [on the second test]; I didn't like the fact we traded more volume the second time." Higher volume retest without clean reversal = less conviction in reversal trade. (v106, [10:02]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Three failed divergences in ~1 hour at same level = buy the breakout** — "watch if it's going to fail or not; okay watch if we're gonna take out the high… I'm looking for this high to keep being tested and to me I'd buy it if it hit that high. It could hit the high and make a new high by 1–2 ticks or then sell off — that's the chance you've got to take. Or hit the high and rally another 20 points." Three failures = trend signal, bias switches to long on breakout. (v104, [22:18]; v104, [22:48]) [ONCE]
- **Signal failure as information** — "a trade that failed on you" is still read for directional info; price came back = bulls still there. (v100, [05:09]) [REPEATED]
- **Double top with declining volume on 2nd test = better reversal** — first hit: no Delta scalper; second hit: Delta scalper kicks in but volume heavier = less convincing. First hit reversal with lighter volume > second hit with heavier volume. (v106, [08:15]) [ONCE]

---

## I. Trapped-trader ideas

- **Long trapped at top / POC + bearish ratio + single print** — buyers who purchased the top of the bar at 500+300 lots are "caught off sides" and become sellers as price ticks down. (v100, [03:42]) [REPEATED]
- **Retail trapped by geopolitical news spike** — traders who piled into JPY on North Korea missile news are trapped as 2/3 of the move evaporates in 3 minutes; "people that react to these things rather than analyze what's going on lose money." (v103, [04:38]) [ONCE]
- **Trapped quantity is small** — Mike does not frame traps as large stop-hunt fuel; he uses them to identify directional pressure change. [REPEATED — digest note]

---

## J. Entry triggers (the exact "go" event)

- **Divergence bar closes then ratio bar closes** — the ratio fires on the bar AFTER the divergence bar. Entry is on close of the ratio bar or on the next bar open. "Your divergence and your ratio in the next bar" = the canonical two-bar entry trigger. (v100, [11:48]; v106, [02:18]) [REPEATED]
- **Delta Scalper signal in conjunction** — adds confidence but alone is not the entry; it is one of the additional "bonuses." (v100, [01:57]) [REPEATED]
- **Price Rejector signal at extreme + divergence + ratio** — all three firing = go. (v104, [12:26]) [REPEATED]
- **Stacked imbalance + Delta scalper after failed prior signals** — entry is acceptable even if "not as clean at 70 [ticks below]… getting in at 90 is better than not getting in on a move all the way back to 50-30." Accepts slightly late entry for confirmation. (v106, [18:35]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Immediate directional movement** — "look for the move to happen right; it's not gonna take you know a couple hours for the move to happen." If short and market just hangs around for an hour, that's a sign to exit. (v104, [24:17]; v104, [24:44]) [REPEATED]
- **Follow-through bars with consistent same-direction delta** — after entry long, want to see "positive delta, positive delta, positive delta" in successive bars without negative delta interruptions. (v100, [08:40]) [REPEATED]
- **Buying imbalances on the way up** — "you get a nice buying imbalance here on the way up" = confirmatory signal during the follow-through. (v100, [09:07]) [ONCE]
- **Aggressive buying (large deltas) appearing in the next 1–3 bars** — crude oil: "+677 positive delta, Delta scalper kicks off… +562 next bar, +1100" = strong confirmation pattern. (v100, [04:43]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **POC on extreme in direction opposite to trade + ratio** — "you got POC bottom of green bar [bullish POC] plus Delta scalper sell signal… it comes right back with a bullish sign" = kills the short thesis even though Delta scalper fired. (v103, [14:13]) [ONCE]
- **Opposite ratio in next bar after stacked imbalance** — "stacked selling imbalance then bullish ratio in next bar = it's not going to be very effective." (v103, [08:48]) [REPEATED]
- **Strong negative delta (–600, –459, –305, –845) stringing together** — if in a long, consecutive heavy negative deltas = exit signal even if original entry was valid. "That's where you'd be looking to get out, not hold it." (v100, [10:22]) [REPEATED]
- **Trade not working after 10–12 minutes** — still in position 12 minutes later "going nowhere… already almost an hour since you entered… that's another sign you should be getting out." Time-based soft stop. (v104, [23:41]) [REPEATED]
- **Positive delta with bar closing lower (bearish candle)** — positive delta cannot overcome the offers; market not going higher despite buyers. (v106, [09:12]) [ONCE]
- **New delta scalper in same direction as original signal but follow-through failing** — a second Delta scalper failure after the first already failed = do not keep holding. (v100, [05:09]) [ONCE]
- **Second stacked imbalance in opposite direction** — if long on stacked buying imbalance and a stacked selling imbalance forms in the next bar, "get out and take your loss and wait for something else." (v103, [10:30]) [ONCE]

---

## M. Stop / risk / target / trade management

- **Stop = 1 tick beyond signal-bar extreme** — implied by "stop would just be below this area here" and "stop you out." (v103, [07:58]) [REPEATED]
- **~10-minute time stop implied** — "if it's giving you the sell signal right here at 10 o'clock and it's still just hanging around that area at 10:37, 10:49, you know it's almost an hour — rather take whatever I can get and be done with it." (v104, [23:41]) [REPEATED]
- **Second chance re-entry once** — "don't give up just because you took a loss; you get your second chance in here." One re-entry after stop-out is accepted practice. (v103, [15:03]) [REPEATED]
- **Read the trade in real time; exit before stop if obvious bearish signs appear** — "you could get out a little bit earlier rather than have it stop you out" when bar is forming bearish POC + ratio + single print. (v100, [05:09]) [REPEATED]
- **Target: discretionary / trail to stacked imbalance area** — "run into this stacked buying imbalance and then going sideways… if you're in that position you might want to think about cutting it." Stacked imbalance in direction of trade = partial/full target. (v100, [09:07]) [REPEATED]
- **Risk-reward cited**: first crude trade ~10-tick loss, second trade +60-tick win. (v100, [09:33]) [ONCE]
- **Soybean examples**: –3 cents / +6 cents / +2 cents / +5 cents moves cited as expected reward range. (v104, [12:54]; v104, [14:37]; v104, [18:12]) [ONCE]
- **Holding through one negative delta bar is acceptable** — "one bar with negative delta and a red candle doesn't mean the trade is over… just watch what's happening, let it unfold; supportive buying visible in the footprint." (v100, [08:19]) [REPEATED]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news)

- **"After 2 o'clock [CT] don't trade currencies"** — "that's when the trading books are closed at the banks so liquidity does get a little bit less." Hard session cutoff for currency futures. (v103, [10:57]) [ONCE]
- **"Friday afternoon at lifetime highs — I wouldn't be a seller"** — end-of-week + contract high = avoid counter-trend short even with bearish signals. (v104, [26:03]) [ONCE]
- **Cash open first bars caveat** — multiple signals right at 8:30–8:31 cash open discounted: "I know this market's going through the cash opening so I'm not really too concerned." (v104, [20:56]) [REPEATED]
- **FOMC week = tight range / muted trading** — "on a week that you have a FOMC meeting it's not surprising to have a tight range; just sort of wait and see." Signal quality lower in pre-FOMC environment. (v106, [01:24]) [ONCE]
- **7:30 news release — give it 5 minutes** — "signals I see are generally with a grain of salt from 7:30 to 7:35." (v103, [14:13]) [REPEATED]
- **Soybeans reopen at 8:30** — there is a break from the overnight session; signals right at 8:30 reopen noted as context. (v104, [12:03]) [ONCE]
- **Double top context** — second test of a prior swing high: "I don't like the fact we traded more volume the second time. If you had less volume / signs of price rejection I'd be more convinced." Volume pattern at retests matters for grading the reversal. (v106, [10:02]) [ONCE]
- **Persistent positive delta at new lows = eventual bounce** — "sooner or later hanging around the lows even making new lows with positive delta, this market is going to bounce." Not a specific time filter but a regime filter. (v100, [17:22]) [ONCE]
- **Geopolitical news spike** — "give the market a chance to relax" after a geopolitical event spike; don't chase the initial reaction. (v103, [01:02]) [ONCE]
- **Markets Mike watches regularly**: crude oil, ES, euro currency, bonds, 5-year note, soybeans, mini-Dow (YM), Japanese yen, British pound, gold, DAX. (v100, [11:48]) [REPEATED]
- **Soybeans as under-rated market** — "follows order flow beautifully… sometimes more beautiful than financial contracts." Grains recommended as cleaner order flow reads because less institutional/retail noise. (v106, [19:58]) [ONCE]

---

## O. Directly testable / measurable variables

- **Delta = 79 → "weak/borderline neutral"; delta ≈ 50 = neutral; delta < 25–50 = neutral band** — stated explicitly in v100 [02:25] and v106 [11:49]. NEEDS-OPERATIONALIZATION (upper bound of neutral band is between 25–100; he uses 50 as a soft cutoff but "gives leeway.")
- **Delta 25–50 range defined as "kind of neutral" with leeway** — stated at v106 [11:49]: "anywhere between 50 to 200 or 25 to zero that's kind of neutral." (Note: "50 to 200" likely means "25 to 50" — context implies neutral band, not 200.) NEEDS-OPERATIONALIZATION
- **Declining delta sequence as exhaustion** — delta sequence –633/–327/–23 across 3 bars = each step loses ~300; "methodical staircase" decline = cleaner signal. Measurable: delta drop ≥ 300 per bar across 3 consecutive bars. (v106, [13:13]) NEEDS-OPERATIONALIZATION
- **Volume at retest declining** — 35 lots → 3 lots on successive tests of same price level = price rejection. Measurable: volume at extreme on 2nd test < volume at extreme on 1st test. (v104, [12:26])
- **Stacked imbalance minimum volume threshold = 50** — default for standard markets; lower (e.g., 38 or 25) for thinner markets. (v104, [15:32])
- **Multiple imbalances (non-stacked) = 3+ in same bar** — triggers a box highlight; directional clue. (v102, [09:38])
- **Heavy volume at single price level** — 1026 contracts on single bid in euro currency = "massive"; visible only in footprint. NEEDS-OPERATIONALIZATION (what is "massive" per market)
- **NinjaTrader 8 data persistence** — tick replay must be enabled globally (Tools → Options → Market Data → Show Tick Replay) AND per chart (Properties → Data Series → Tick Replay). Both must be enabled. (v102, [05:12]; v102, [05:46])
- **NT8 data storage caveat** — saving tick data takes significant disk space (~1 GB per day for many charts). (v107, [10:54])
- **Delta Scalper default settings** — 7, 1, 1, 2, 5, 2 on Union Renko chart. (v100, [18:24])
- **Currencies session end for trading = 2:00 p.m. CT** — hard cutoff (v103, [10:57])
- **7:30–7:35 CT = news-release buffer** — signals in this window carry lower weight. (v103, [14:13])

---

## P. NinjaTrader / indicator implementation ideas

- **NinjaTrader 8 migration** — Mike formally switching to NT8 on a permanent basis (2017). Key difference vs NT7: data handling is "light years ahead." (v102, [00:28]; v102, [04:09]) [ONCE]
- **Tick replay — dual enable required** — must enable "Show Tick Replay" in Tools → Options → Market Data AND in each chart's Data Series properties. If only one is enabled, data may not save/load properly. (v102, [05:12]; v102, [05:46]) [ONCE]
- **Font size configuration** — imbalance numbers and summary numbers are separate font fields in the indicator settings; both must be changed (regular font + volume imbalance font). Recommended size 14–15 for readability. (v102, [07:23]) [ONCE]
- **Multiple-imbalance box highlight** — indicator draws a box around bars with 3+ imbalances in the same direction (non-stacked); already implemented in Orderflows Trader as of Sept 2017. (v102, [09:38]) [ONCE]
- **"INF" ratio display** — when the denominator of the ratio is zero (zero print on extreme), NT8 displays "INF" (infinity). Expected behavior; still prints blue-color highlight. (v102, [12:36]) [ONCE]
- **Delta Scalper does NOT read historical data in NT7** — must be running live to generate signals; cannot backfill signals on a loaded chart. NT8 with tick replay saves data so signals persist on reload. (v107, [09:31]) [ONCE]
- **Delta Surge = free indicator** — available on orderflows.com via email signup. (v100, [23:19]) [ONCE]
- **Orderflows Trader runs on NT7 and NT8** — available since ~2016 on NT8; Mike delayed switch but now permanent. (v102, [00:00]) [ONCE]
- **Chart trader panel in NT8** — can be toggled via Properties; recommended for live trading. (v102, [01:22]) [ONCE]
- **Per-instrument param note** — same detector settings across markets but imbalance minimum threshold can be lowered for thin markets (e.g., 25–38 vs 50 default). (v104, [15:32]) [ONCE]

---

## Q. Notable verbatim quotes

1. "You got the divergence and your ratio in the next bar — you also got your Delta scalper. This time it's in the bar on the low; on the crude it was on the bar right afterwards." — on canonical two-bar divergence+ratio entry with Delta scalper as bonus. (v100, "Sept 11 Crude Oil," [11:48])

2. "79 is still you know it's on the weak side and you've got a couple bearish signs up here — you got the point of control near the top, you've got the bearish ratio, you've got the single print." — on why the setup failed: delta technically positive but too weak + opposing POC+ratio+single print. (v100, [02:25])

3. "This is what I call the point of control on the extreme: it's on the top of the bar, you've got the bearish ratio which is also nice, next bar you've got the Delta scalper kicking in." — textbook triple bearish confluence. (v103, "Sept 14 Yen," [12:59])

4. "When you have stacked imbalances and you come right back with a bullish ratio in the next bar after your stacked imbalance, it's not going to be very effective." — explicit stacked imbalance failure condition. (v103, [08:48])

5. "You got the negative delta and you got the price action of the bar turning up. That tells you there's potentially some support of buying in here." — delta and candle disagree → candle wins / absorption signal. (v106, "Sept 18 Emini," [09:12])

6. "You got strong negative delta. Why isn't the market selling off? You got strong buyers up here, you got strong people bidding this market, supporting this market. You can see it with these bars creeping back up." — defining supportive buying from an order flow perspective. (v104, "Sept 15 SP," [07:22])

7. "Three failed divergences right there and I see we're just hanging around the high — I'm looking for this high to keep being tested and to me I'd buy it if it hit that high." — regime change: three failures → look for breakout not reversal. (v104, [22:18])

8. "Look, you know if you're getting the signals, look for the move to happen right. It's not gonna take a couple hours for the move to happen. If you're seeing a transition from demand to supply, that supply should overwhelm the buyers and the market should sell off." — follow-through speed rule. (v104, [24:17])

9. "1026 — that's massive for the euro currency. It's massive for any currency. People basically stepping up at this price level and saying I'm a bidder here, I'll buy everything. And you can see how the market reacts." — footprint-only absorption signal: large single-price volume. (v107, "Huge Volume," [01:19])

10. "Very rarely do you get that sort of volume on the bid side of a down candle. This type of bar is extremely bearish." — 1473 on offer / 1713 on bid on bonds down candle = extreme bearish supply. (v107, [07:13])

---

## R. Contradictions / nuances

- **Positive delta is NOT automatically bullish** — "don't think just because it's positive it means something; you got to understand how it's forming." Delta of +23 at a swing high is treated as neutral/bearish, not bullish confirmation. Directly conditional. (v106, [11:21]) [REPEATED nuance — see also digest]
- **Negative delta is NOT automatically bearish** — "just because you got negative delta and a red candle doesn't mean you've got to get out; there's supportive buying visible." Conflicts with naive delta-reading. (v100, [08:19]) [REPEATED nuance]
- **Volume at a level can be bullish OR bearish depending on context** — "if this was just a normal number here, you'd have a small negative delta or slightly positive delta; the big negative delta shows support of buying IN this context." Volume interpretation is context-dependent, not mechanical. (v100, [08:19]) [ONCE]
- **Stacked imbalances have ~5-bar half-life (digest) but can be killed in 1 bar** — the immediate-counter-ratio kill is even faster than the ~5 bar decay mentioned in digest. (v103, [08:48]) Refining.
- **"Same settings every market" applies to detector but imbalance min threshold is per-market** — explicitly uses 50 for ES/bonds but would use 25–38 for thinner markets. Not contradicting digest but operationalizing the "per-market scaling" note. (v104, [15:32])
- **POC on extreme conflicts with delta scalper signal** — "even though you got the delta scalper giving you a bearish sign it comes right back with a bullish sign" (POC on bottom of green bar). When POC signal and Delta scalper signal disagree, the POC/footprint signal can override the scalper. (v103, [14:37]) [ONCE]
- **Second-chance re-entry** — digest says "once"; confirmed here. Entry at a worse price than ideal is explicitly acceptable if it captures the bulk of the move. (v106, [18:35]) [REPEATED]
- **Three failed divergences → regime flip** — this is a direct nuance: the same divergence setup that is a reversal signal becomes a breakout-entry trigger after three failures. (v104, [22:18]) [ONCE] — partially captured in digest as "3 failed divergences ≈ trend day (don't fade)" but this chunk adds the positive: you BUY the breakout.
- **Currencies should not be traded after 2:00 p.m. CT** — digest has "avoid open/first bars/news/lunch" but does not specify a hard 2:00 p.m. CT currency cutoff. (v103, [10:57]) Refining.
- **Volume heavier on 2nd test of double top = less conviction for reversal** — more volume at the same high is a negative for the reversal case; contradicts the naive view that "more volume at a level = stronger S/R." (v106, [10:02]) [ONCE]

---

## Coverage note

v100, v103, v104, v106 were the richest transcripts — containing live trade walk-throughs with explicit signal grading, multi-market analysis (crude, ES, soybeans, yen, bonds), and several model-refining nuances (supportive buying, stacked-imbalance kill conditions, three-failure breakout regime). v102 was thin for the model but valuable for NT8 implementation details (tick replay setup, font config, multiple-imbalance box). v107 was short but contained two high-value footprint signals: single-price massive volume as absorption confirmation (euro currency) and extreme offer-side volume as bearish signal (bonds). All transcripts were parseable.
