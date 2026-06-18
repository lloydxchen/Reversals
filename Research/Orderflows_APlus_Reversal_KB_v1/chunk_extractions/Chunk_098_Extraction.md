# Chunk 098 Extraction
- Source chunk: Chunk_098_Orderflows_Transcripts.md
- Transcripts covered:
  - v388 — Learn More About The Bar Gaps Indicator Training Session (2023-09-17)
  - v389 — Market Generated Information Found In The Order Flow Resistance Becomes Support (2023-09-18)
  - v391 — Cumulative Delta In The Order Flow (2023-09-20)
  - v392 — Interesting FED Day Order Flow With Orderflows Trader (2023-09-20)
  - v393 — Cumulative Delta Part 2 When Price And Cumulative Delta Diverge (2023-09-21)
  - v400 — 75 Tick Winning Trade In YM Minidow Futures Thought Process On Trade Management (2023-09-27)
  - v402 — How Orderflows Trader Identifies Supply Coming Into The Market With A Footprint Chart (2023-09-28)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Bar Gaps indicator signals (Type 1 / Type 2)** — a proprietary NinjaTrader 8 indicator that combines a price-action gap pattern (bar 1 / bar 2 / bar 3 "fair value gap" skeleton) with undisclosed complementary order-flow confirmation inside those bars; produces buy/sell triangles on the chart; two variants: Type 1 (more common, green/red) and Type 2 (less common, cyan/magenta). [ONCE] (v388, "Bar Gaps Training Session", [04:46])

- **Bar Gaps zones** — areas drawn by the Bar Gaps indicator marking where the gap plus significant order flow occurred; can be used as stand-alone S/R levels even without the signal triangle; zones persist until tested. [REPEATED] (v388, [12:27])

- **Inverse volume imbalance (Supply/Demand flip)** — bearish setup: buying imbalance appearing on a RED candle = supply absorbing aggressive buyers; bullish mirror: selling imbalance on GREEN candle = demand absorbing aggressive sellers. Used to confirm continuation or warn of reversal. [REPEATED] (v402, [02:08], [05:40])

- **Prominent Point of Control (bearish / bullish)** — POC sitting at or near the HIGH of its bar = bearish ("bearish prominent POC"), POC near LOW = bullish. Marks market-generated supply/demand levels. Used for S/R and as reversal clues. [REPEATED] (v389, [04:26]; v392, [10:22])

- **Delta surge reversal** — strong consecutive positive-delta bars after a new low (e.g., −132 → −7 → +38 → +289) interpreted as momentum reversal candidate; used as entry trigger for the long in v400. [ONCE] (v400, [01:43])

- **Abandoned value area (gap in value)** — one or more bars whose value area does not overlap the prior bar's value area, creating a gap; used both as a continuation signal (price is moving quickly with force) and as a trade-management cue for trailing the stop. [REPEATED] (v400, [05:22], [06:43], [07:14])

- **Cumulative delta divergence setup** — price makes a new low/high while cumulative delta makes a LESS extreme low/high (standard bullish/bearish divergence). Discussed extensively as a bounce/reversal signal, but explicitly conditioned on day type. [REPEATED] (v391, [01:59]; v393, [02:31])

- **Engulfing value area (dark-red bar)** — a red bar whose value area fully engulfs ("engulfs") the prior bar's value area; flagged as a stronger bearish signal than a plain red bar. [ONCE] (v400, [02:49])

---

## B. Tiering / grading language — HIGH PRIORITY

- "**Type 1** is the most common; **Type 2** is less common" — implying Type 1 signals are higher-frequency but both are usable; Type 2 "follows sort of different criteria." No explicit quality tier stated between them. [ONCE] (v388, [08:46])

- **Bigger (thicker) zones vs. thinner zones**: "if it's a thicker Zone it could run into… to get through a thicker Zone in my opinion takes a little bit more effort" — thicker zone is implicitly higher-confidence S/R. [ONCE] (v388, [27:19])

- **Zone held vs. zone failed**: Mike notes bluntly that "not every zone is going to hold" and "if there's no signal [inside the zone] it didn't give confirmation." Zone alone without complementary order flow = lower-quality trade. [REPEATED] (v388, [22:52], [32:55])

- **"Great piece of market generated information"** — used to describe bearish/bullish prominent POC at swing extremes. Tiering language for the POC-on-extreme setup. [ONCE] (v389, [01:52])

- **"Nice sign"** — bearish prominent POC + iceberg at 4500 psychological level + ratio ≤0.54 on the same bar: "everything all the alerts are going off in my head of you know a market that's about to turn." Multi-confluence = "nice sign." [ONCE] (v392, [10:22])

- **"Incredible amount of Delta divergence" / "incredibly weak"** — used for gold's all-day sustained negative cumulative delta against rising price; described as giving "a pretty good chance for a sell-off late in the day." [ONCE] (v393, [07:24])

- **Abandoned value area bonus in trade management**: a gap in value that persists through multiple bars is a signal to extend the trade target ("that's my sign to pull back try and get a little bit more"). [REPEATED] (v400, [09:46])

- **Engulfing value area = "stronger bearish value area… darker red as opposed to the normal red"** — explicitly tiered higher than a plain bearish value area. [ONCE] (v400, [02:49])

---

## C. Order-flow story & psychology per setup

- **Bar Gaps setup psychology**: The gap forms because price moved so fast that the market left untested levels. Order flow inside those bars must confirm the directional intent; without it, the gap "might go up and just eventually melted down." [SPECULATIVE inference, but stated] (v388, [41:37])

- **Inverse imbalance / supply absorption story**: A market falling with buying imbalances on red candles = "suppliers in here… Supply coming in at every level." The passive sellers are absorbing the aggressive buying — that's what causes positive delta on a red candle. Once supply dries up (buying imbalances on red candles stop appearing), the bear case weakens. [REPEATED] (v402, [02:08], [08:47])

- **Prominent POC supply story (resistance becomes support)**: When price breaks through a prior bearish prominent POC level with large passive bids (100+ lots on the bid), "previous resistance becomes support" is confirmed by order flow, not just price action. Mike reads 104, 130, 63, 68, 63 on the bid at the breakout and calls it "strong passive buyers." [ONCE] (v389, [10:47])

- **Cumulative delta divergence psychology**: In a downtrend, cumulative delta making a HIGHER low than price's new low means aggressive selling is lessening = "the last sellers are running out of bullets." But on a trend day, bounces from divergence may be small (5–14 points on ES). [REPEATED] (v393, [04:15])

- **Gold divergence story (sustained selling against rising price)**: Supply is parked at the high — passive sellers absorbing aggressive buyers all day; "the easiest place to sell if you've got a lot to sell in a rising market." Once those passive sellers are removed (late in day), price collapses. [ONCE] (v393, [07:55], [11:18])

- **FED-day iceberg supply**: Large iceberg (~4,874 contracts) placed 15 minutes ahead of FED announcement at a round level (44.95 / 4500). Read in the footprint because offer only refreshed 100–180 at a time while 300+ lots traded. Post-announcement flows make pre-announcement context "rear view mirror." [ONCE] (v392, [03:52], [09:53])

---

## D. Exhaustion clues

- Bearish prominent POC sitting at the HIGH of the bar (POC in the upper half) at a swing high = exhaustion of buying; Mike explicitly labels this and watches it as future S/R. [REPEATED] (v389, [04:54]; v392, [10:22])

- Cumulative delta at or near its day-low while price simultaneously makes its day-high = bullish buying "running out of bullets" — an exhaustion read. [ONCE] (v393, [06:58])

- Delta surge up (e.g., −132 → +289 in three bars) followed by a sharp reversal to negative delta (289 → 39 → −13 → −31) = the surge momentum exhausted; supply absorbing the buying surge. [ONCE] (v400, [03:14])

- Positive delta on red candles while market is rising = absorption of aggressive buying by passive sellers; once those passive sellers run out (buying imbalances on red candles disappear), exhaustion completes and decline resumes. [REPEATED] (v402, [08:47], [09:22])

---

## E. Absorption clues

- **Inverse imbalance** (buying imbalance on red candle, or selling imbalance on green candle) = the primary programmatic signal Mike uses in Orderflows Trader to detect absorption. [REPEATED] (v402, [05:40])

- Cumulative delta going DOWN while price goes UP = passive limit bids absorbing aggressive selling. Footprint shows large bid-side volumes (e.g., 116, 127, 126, 86, 114, 92 lots on the bid in consecutive bars) while price inches higher. [REPEATED] (v391, [06:56], [07:38])

- Post-breakout supportive buying: once price clears a prior bearish prominent POC, the appearance of 100+ lot bids at that level is Mike's confirmation that "what was resistance should become support." [ONCE] (v389, [10:47])

- Iceberg detection on DOM: offer size refreshes at a consistent small amount (100–180 lots showing) while much larger volume trades through = passive seller absorbing with iceberg. Read on footprint + depth map. [ONCE] (v392, [05:03], [08:11])

---

## F. Stacked imbalance ideas

- Stack buying imbalance in v400 YM trade: Mike saw a "stacked buying imbalance" off the prior low and used it as a support level when entering short — he watched whether price could "at least hold this buying imbalance." The stack acts as a reference S/R level for the short thesis (if it breaks through, the bearish case strengthens). [ONCE] (v400, [04:44])

- Inverse imbalance cluster (multiple inverse imbalances stacked): not explicitly called "stacked" but described as multiple buying imbalances appearing on consecutive red candles on the way down = persistent supply. The more inverse imbalances appear in sequence, the more supply is confirmed. [REPEATED] (v402, [08:20])

---

## G. Delta / delta-divergence ideas

- **Cumulative delta "normal" vs. "divergent" behavior**: "when price is declining cumulative delta should decline; if price is generally moving up cumulative delta should be moving up." Divergence = abnormal = absorption clue. [REPEATED] (v391, [03:06]; v393, [01:24])

- **Trend day qualifier for divergence signals**: On a trend day down, cumulative delta divergence produces bounces of varying size (one ~14 pts, one ~9 pts, one ~5.5 pts on ES). Mike says "understanding the type of day that you're in is going to make a difference in how you're trading it." Divergence on a trend day = fades are smaller and risky. [ONCE] (v393, [04:15], [05:12]) [NEEDS-OPERATIONALIZATION — no explicit rule for identifying trend day vs. rotational, only that "big push in delta through new lows in first 30 minutes" is a clue]

- **Intraday delta shift sign**: Delta going from positive (surge up) to flat/negative across 4–5 bars at a swing high = momentum shift, sets up short. (v400: +289 → +39 → −13 → −31 → +12) [ONCE] (v400, [03:14])

- **Gold sustained-divergence pattern**: Gold can maintain all-day negative cumulative delta against a slow rising price, with the supply finally exhausting near a prominent level late in the day. Observed "more often than not" in Gold specifically. [ONCE] (v393, [10:50]) [NEEDS-OPERATIONALIZATION]

- **Delta turning negative at a high after positive cumulative = confirmation**: v392 explicitly marks cumulative delta turning negative at 8:58 after being positive, alongside green candles with large bid-side volumes, as the confirmation that absorption is driving the price, not genuine demand. [ONCE] (v391, [05:33])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **False breakout from bar-gap zone**: Mike shows a bar-gap zone where the market trades slightly through the other side by "a couple ticks" but no signal fires = weak breakout, likely to fail. "Expecting a market to come down literally to the tick and then bounce up from" after a big sell-off is "asking a lot." [ONCE] (v388, [27:49])

- **Failed breakout vs. legitimate breakout**: A breakout through a prior bearish prominent POC is "legitimate" only if confirmed by supportive (passive) buying on the bid at that level after the break; without it, breakouts often fail. [ONCE] (v389, [09:31], [10:08])

- **Breakout retest / resistance becomes support**: If breakout is legitimate (passive bids visible at the level), Mike expects price to pull back to the prior resistance — now support — and hold above it before continuation. The level is precise ("literally right down to 4920"). [ONCE] (v389, [11:29])

---

## I. Trapped-trader ideas

- **Supply absorbing buying surge (trapped longs)**: After a delta surge up (+289) quickly reverses to negative delta, the aggressive buyers from the surge are trapped. Red candle + positive delta near the swing high is the clue supply is still there and those buyers are "sitting in supply." [ONCE] (v400, [03:47])

- **Inverse imbalance = trapped buyers**: Buying imbalances on red candles in a falling market represent aggressive buyers who stepped in and are now under water as price continues to fall; this is why supply keeps arriving (those bids get hit, no follow-through). [REPEATED] (v402, [03:19])

---

## J. Entry triggers (the exact "go" event)

- **Bar Gaps signal triangle**: Appears as soon as conditions are met (intrabar); does not wait for bar close. Zone confirmation waits for bar close. Trader can enter on the triangle or fade into the zone. [ONCE] (v388, [1:03:30])

- **Short entry after delta surge failure + engulfing value area**: In v400, Mike shorts after seeing: (1) delta surge up fails (delta turns negative), (2) bearish value area + bearish prominent POC appear, (3) engulfing (dark-red) value area fires. Entry at market ("hit the button to sell"). [ONCE] (v400, [04:17])

- **Abandoned value area extension trigger**: Once in a short, when price leaves a gap in value (abandoned value area) without trading back through it, that is the signal to move the take profit further and trail the stop. [REPEATED] (v400, [05:22], [09:46])

- **Inverse imbalance disappearance as cover trigger**: When buying imbalances on red candles (supply clues) stop appearing and the candles turn green with selling imbalances (demand showing up), that is the signal to cover the short. [ONCE] (v402, [11:01])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Bar Gaps buy/sell signal**: After a buy signal, price "should come right back up" to a zone and hold; after a sell signal, it "should stop and reverse." If the market "chews through" a zone it is not confirming. [ONCE] (v388, [46:51])

- **Breakout confirmation**: After a bullish breakout through a prior bearish prominent POC, passive bids at that level should appear on the footprint within 1–2 bars (100+ lot bids on the bid side). Their appearance = confirmation. [ONCE] (v389, [10:47])

- **Delta surge reversal confirmation**: After entering long on a delta surge, Mike expects price to move higher quickly; in the v400 trade, the short confirmation was "basically no heat — three ticks" of adverse move before the trade moved in favor. Quick, low-heat start = strong signal. [ONCE] (v400, [05:22])

- **Supply clue confirmation for staying short**: Consistent negative delta + abandoned value areas (gaps in value not revisited) = confirmation the short should be extended. "The fact that it was just sort of getting through these levels without much stopping it." [ONCE] (v400, [09:46])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Bar Gaps zone invalidated if price trades through without a signal**: If the zone is violated without any triangles firing, the zone is treated as breached. [ONCE] (v388, [22:52])

- **Bullish order flow without price follow-through = bearish**: "If I'm getting bullish order flow like here and even over here and the market can't rally — to me that's not necessarily a sign of chop, it's a sign of a market that's struggling to make a move. Chances are it's either going to go sideways and then eventually fail." [ONCE] (v392, [12:11])

- **Trend-day divergence bounce threshold**: On a trend day down, a delta divergence bounce is real but limited; if the bounce does not extend beyond the prior swing high, it is NOT a reversal — still a trend day. [ONCE] (v393, [04:45])

- **Delta surge immediately reverting**: When the delta surge up in v400 (to +289) immediately collapsed to +39, −13, then −31 within four bars, Mike treated that as invalidation of the long he was building and flipped to short. [ONCE] (v400, [03:14])

- **Post-news context wipe**: After a major announcement (Fed, NFP, CPI), all pre-announcement order flow context is "rear view mirror" — do not use pre-news prominent POCs, value areas, or supply levels for post-announcement analysis. [ONCE] (v392, [09:53])

---

## M. Stop / risk / target / trade management

- **Base trade ATM: 20-tick stop / 20-tick profit** on YM (v400); explicitly stated as starting parameters, not final outcome. [ONCE] (v400, [10:43])

- **Move to break-even threshold**: Move stop to break-even "when you're in the money by a decent amount" — not after 10 ticks, but after a "decent amount" of favorable movement (in v400, began moving stop when around 25 ticks in the money). [ONCE] (v400, [05:49]) [NEEDS-OPERATIONALIZATION — "decent amount" undefined]

- **Trailing stop rule via abandoned value area**: Each time price leaves a new abandoned value area (gap in value), back off the stop to just behind that abandoned area. Mike progressively moved his stop from 70 → break-even → eventually down to 75 as the market fell through gaps. [ONCE] (v400, [06:11])

- **Do NOT move stop when market is going sideways**: If market pulls back to entry and "starts trading back up to 50 that's not a good sign" — suggests closing rather than widening. [ONCE] (v400, [11:11])

- **Greed/discipline warning**: "Instead of taking 20 ticks on it you're taking an additional 20-tick stop" if you keep moving the stop wider when the market ticks against you. Once profitable, manage down with discipline. [ONCE] (v400, [12:11])

- **Bar-gap zones as potential targets**: "A zone being drawn out is an area where the market can stop — that's one of the reasons why we use these zones… stop and reverse." [ONCE] (v388, [46:51])

- **Time / session**: No-trade around news (NFP, FED) — not because of the signal but because volatility makes risk unmanageable. Mike stayed out on Fed day despite interesting pre-announcement order flow. [REPEATED] (v392, [09:21], [13:14])

---

## N. Context filters (session/time, regime/volatility, levels)

- **Asian session = "dead zone"**: "That Asian time to me is kind of a dead zone — sort of that time from the reopen until about 7–8 o'clock" Chicago time. Bar Gaps indicator does produce signals but Mike discounts them for his own trading. [ONCE] (v388, [1:04:03])

- **Currency pairs have their own "active sessions"**: Euro currency → most active when Europe is open + US session; Aussie dollar → active during Asian session (7 PM Chicago). Signals fire in off-hours but quality is lower in inactive sessions. [ONCE] (v388, [1:04:38], [1:05:10])

- **Market movement requirement**: "You need to have some movement in the chart. Trying to trade a market that's not moving where it's trading one, two, or three ticks… isn't enough movement." Applied to 10-year futures on 1-minute chart (too slow), soybeans on 50-tick chart (too slow), ultra-bonds on 1-minute. Minimum movement NEEDS-OPERATIONALIZATION but the principle is explicit. [REPEATED] (v388, [05:55], [20:10])

- **Fed / CPI / NFP / PPI days**: Stay out entirely. "There are certain days you should stay out of the market… no one's putting a gun to your head." The pre-announcement order flow cannot be used for post-announcement context. [REPEATED] (v392, [13:14])

- **Trend day vs. rotational**: Strong negative delta through new lows in the first 30 minutes = trend day down; delta divergences still appear but bounces are limited (5–14 pts on ES). Do NOT treat divergence bounces as full reversals on a trend day. [ONCE] (v393, [05:12])

- **Chart type flexibility for Bar Gaps**: Works on time-based, tick-based, volume-based, and range-based charts; also on renko (uni-renko), Heikin Ashi, point-and-figure (limited). 4:1 imbalance ratio unchanged across chart types (Bar Gaps uses same ratio). [ONCE] (v388, [20:10])

- **Bullish order flow without follow-through = sideways/bear**: If bullish signals fire and market cannot rally, treat it as a continuation of the bear trend, not a reversal. [ONCE] (v392, [12:11])

---

## O. Directly testable / measurable variables

- **Imbalance ratio for inverse imbalance detection**: 400% (4:1) — "I've used 400 for over a decade." Lower ratios (300%) give more imbalances; higher give fewer. [REPEATED] (v402, [03:56])
- **Bar Gaps Type 1 vs. Type 2**: Two variants with different internal criteria; Type 2 is less frequent than Type 1. [NEEDS-OPERATIONALIZATION — internal criteria undisclosed] (v388, [08:46])
- **Zone opacity setting**: default 30%; can be adjusted. Not a trading variable. (v388, [08:46])
- **Prominent POC level**: Level 1, 2, 3 on the Orderflows Trader; Mike focuses on Level 3 as the most significant. [ONCE] (v389, [04:26]) [NEEDS-OPERATIONALIZATION — threshold for Level 3 vs. 1/2 undisclosed]
- **Bearish prominent POC ratio threshold**: 0.54 ratio cited in v392 as a confirming value for the bearish POC stop-run setup at the FED-day high. [ONCE] (v392, [10:22])
- **Iceberg detection method**: Offer size visibly smaller than volume trading through at a price level; refreshes repeatedly at same price; DOM shows ~100–180 lot offer but 300+ lots trade. [ONCE] (v392, [05:03])
- **Delta surge numbers (YM trade)**: −132 → −7 → +38 → +289 = entry-grade surge; reversal to +39 → −13 → −31 = invalidation. [ONCE] (v400, [01:43], [03:14])
- **Base ATM parameters (YM)**: 20-tick stop, 20-tick profit. [ONCE] (v400, [10:43])
- **Break-even trigger**: Move when "in the money by a decent amount" [NEEDS-OPERATIONALIZATION] (v400, [05:49])
- **Movement threshold for instrument suitability**: Market must trade more than 2–3 ticks per bar for Bar Gaps to be useful. [NEEDS-OPERATIONALIZATION] (v388, [05:55])
- **Cumulative delta trend day signal**: Strong negative delta through new lows in first ~30 minutes = trend day down. [NEEDS-OPERATIONALIZATION — threshold for "strong" and "through new lows"] (v393, [05:12])
- **Inverse imbalance cluster**: minimum 1 inverse imbalance to trigger highlight (adjustable); Mike keeps it at 1. [ONCE] (v402, [05:05])
- **Engulfing value area**: visually darker-red bar = value area of current bar fully engulfs prior bar's value area. [ONCE] (v400, [02:49])

---

## P. NinjaTrader / indicator implementation ideas

- **Bar Gaps Indicator (NT8 only)**: Proprietary add-on; licensed by email; works with or without tick replay; reads price-action gap pattern + internal order flow (imbalances + volume + POC); fires triangle signal as soon as conditions met (not on bar close); zone drawn on bar close; does NOT need tick replay to function. [REPEATED] (v388, [07:34], [10:18], [35:14])

- **Two-type architecture**: Type 1 (most common) and Type 2 (less common, fewer signals) can be displayed separately or together; color-coded separately for differentiation; can optimize per market/chart type. [ONCE] (v388, [08:46])

- **"Pair up" filter**: An optional (disabled by default) feature that "pairs up something in the order flow" — fires rarely (1–2 extra trades per day). Described as an additional confirmatory filter but not elaborated. [ONCE] (v388, [09:16])

- **Inverse imbalance (supply/demand highlight) in Orderflows Trader**: Toggled by setting imbalance cluster to "1" and display mode to "fixed" or "until tested"; draws colored zones over inverse imbalance bars; helps visually track supply vs. demand pressure without reading every number. [ONCE] (v402, [05:05])

- **Prominent POC levels 1/2/3 in Orderflows Trader**: Three levels of significance for POC prominence; Level 3 = most significant. [ONCE] (v389, [04:26])

- **Delta chart view**: Convert footprint to "delta chart" (shows delta at each price level per bar rather than bid × ask volume) as an alternative view to see absorption/supply without reading raw numbers. [ONCE] (v391, [09:35])

- **Bar Gaps zones as NT objects**: Mike could not confirm whether zones are coded as NT objects or plots; noted to check with programmer. Relevant for strategy/indicator coding. [ONCE] (v388, [1:06:27])

- **Chart types supported**: Time-based, tick, volume, range, renko, Heikin Ashi. Footprint-specific features (inverse imbalance, prominent POC) require footprint/volumetric chart with tick replay for accuracy. Bar Gaps does not require tick replay. [ONCE] (v388, [20:10])

---

## Q. Notable verbatim quotes

1. "Unless you're really looking at a footprint chart you don't know for certain if there is an imbalance in the market. Because by the definition of what an imbalance is, you have more directional trade in one direction than the opposite direction by a certain percentage." (v388, [01:43]) — core rationale for order flow over pure price action

2. "You don't see a signal coming in off of this gap here because you know off the original signal it's going to be bar one bar two bar three where you have this gap in here but it's not giving you a buy signal okay just because it's not following what we're looking for in the order flow taking place in here." (v388, [41:37]) — why order-flow confirmation is required on top of the gap pattern

3. "When I have a zone starting to be drawn out and it's not traded back into — to me that's a sign of a market that's potentially getting ready to move." (v388, [14:36]) — untested gap zone as directional signal

4. "If a breakout is legitimate, what was resistance should become support for the market to go higher. Right here — this was your resistance earlier. Breakout right here, pull back into your now-support to go much higher." (v389, [12:41]) — confirmation sequence for legitimate breakout

5. "If I'm getting bullish information bullish order flow like here and even over here and the market can't rally — to me that's not necessarily a sign of chop, it's a sign of a market that's struggling to make a move. Chances are it's either going to go sideways like it did and then eventually fail." (v392, [12:11]) — bullish flow without follow-through = continuation bear signal

6. "If you can identify that you're in a trend day down… any bounce you get — that's not to say you can't buy — of course you can because you are going to get bounces, but sometimes they're not going to be so big." (v393, [04:15]) — trend day qualifier for divergence signals

7. "What really kept me into the trade longer as opposed to just getting 20 ticks out of it… is watching what's happening in the order flow right, trailing it down, watching these value areas, the gaps in the value, right, the value not the market not really trading back into the previous value areas." (v400, [09:46]) — abandoned value areas as trade management tool

8. "Understanding that there is still Supply in the market… anytime you're making these new lows — are you thinking, if you're short, 'okay this is it, I've got to cover'? But you still see Supply in that market, maybe you won't cover, maybe you'll give the trade more room to run." (v402, [09:54]) — inverse imbalance as signal to stay in trade

9. "Just by looking at the cumulative delta going down as price is rising I sort of get in the sense that hey you know what there's probably some absorption taking place in the market right." (v391, [08:19]) — cumulative delta divergence = absorption inference

---

## R. Contradictions / nuances

1. **"After a major announcement the pre-announcement flows are rear view mirror"** — contradicts the general principle that prominent POCs and value areas persist and should be kept in view. Mike explicitly states that for Fed/NFP events, ALL prior levels identified before the release lose their validity: "everything's changed — everybody was waiting for this announcement, they're adjusting their portfolio." (v392, [09:53]) [CONDITIONAL: applies only to scheduled macro catalysts]

2. **Positive delta at new lows is NOT always bullish (supply absorption context)**: In v402, Mike shows consecutive bars with positive delta (buying imbalances) on red candles and markets at new lows — and these are BEARISH, not bullish, because the buying is being absorbed by supply. This is the inverse-imbalance concept. The standard "positive delta at new lows = bullish" rule requires the additional check: are those buying imbalances on red candles? If yes, supply is the driver. [REPEATED, cross-referenced with digest nuance on positive delta at low being bearish]

3. **Trend-day divergence: signals fire but bounces are limited** — cumulative delta divergence still generates valid signals on trend days, but their magnitude is reduced (5–14 points on ES vs. larger on rotational days). Mike does NOT say to ignore divergence on trend days, only to size expectations accordingly. (v393, [04:45]) [NUANCE vs. standard "3 failed divergences = trend day" rule]

4. **Bar Gaps zones: thicker ≠ definitively stronger** — Mike qualifies: "I don't think so — a zone is a zone." But then immediately says thicker zones take more effort to break through. This is a mild internal contradiction: he simultaneously says zone size doesn't matter and that thicker zones are more resistant. (v388, [27:19])

5. **"Same settings every market" applies to Bar Gaps AND to imbalance ratio**: Mike confirms the 4:1 ratio is his 10+ year standard and is applied across markets without market-specific adjustment. But separately concedes that for some markets/chart types, Type 1 vs. Type 2 might perform differently, implying some market-specific optimization exists at the signal type level if not the ratio level. (v402, [03:56]; v388, [40:26])

6. **Pre-news iceberg shows supply but trade is avoided**: Mike identifies a ~4,874-contract iceberg sell ahead of the Fed, a prominent POC, a ratio of 0.54, and "everything all the alerts going off" — a textbook bearish setup — yet explicitly does not trade it because it's Fed day. The model conditions are met; the context filter overrides. This reinforces that context filters (news) can veto even high-confluence setups. (v392, [10:22], [13:14])

---

## Coverage note

v388 (Bar Gaps training session) is the richest transcript — substantial new content on the Bar Gaps indicator, zone mechanics, and order-flow confirmation logic. v389, v400, and v402 add useful model detail on prominent POC, trade management via abandoned value areas, and inverse imbalance supply detection. v391, v392, and v393 are primarily cumulative delta education — mostly reinforcing known absorption/divergence concepts, with v392 adding an important nuance about post-news context invalidation. v393 adds a useful trend-day qualifier for divergence signal magnitude.
