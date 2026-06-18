# Chunk 077 Extraction
- Source chunk: Chunk_077_Orderflows_Transcripts.md
- Transcripts covered:
  - v236 — Order Flow Demystified How To Read The Market (2022-03-20)
  - v237 — Orderflows Sequencing Indicator For NT8 Order Flow Analysis For Candlestick Charts On NinjaTrader (2022-03-26)
  - v238 — Bitcoin Analysis With Order Flow Footprint Chart (2022-03-29)
  - v239 — How To Set Up Orderflows Sequencing In Markers For NinjaTrader 8 Order Flow Trading (2022-03-29)
- Overall content value: mixed

---

## A. Setup types & names he uses

1. **Exhaustion print / price rejection** — the edge price on a footprint bar trades a tiny number compared to earlier bars at the same swing; "lack of buying" at a swing high or "lack of selling" at a swing low. Bearish at swing highs, bullish at swing lows. (v236, [14:02]–[15:44])

2. **Double-top with exhaustion confirmation** — price makes two (or three) highs within a tick or two; the second/third attempt shows an exhaustion print or zero print on the offer side, confirming sellers have taken control. (v236, [17:22]–[19:50])

3. **Zero print** — literally zero contracts traded on the offer (for a bearish bar) or bid (for a bullish bar); "nobody was interested in buying lifting the offer." A stronger exhaustion signal than a small number. (v236, [18:55])

4. **Virgin / exposed value area (untested value area)** — a bar's value area that is not overlapped or entered by the immediately subsequent bar; the market "gaps" the value area. These zones act as future S/R when price returns. Bullish or bearish depending on direction of gap. (v236, [32:24]–[35:45])

5. **Value area gap migration (trending context signal)** — on a bar chart, successive value areas that consistently gap in one direction signal a trend; individual bars' POC migrating in one direction confirm momentum. Not a reversal setup per se but a context filter for reversals. (v236, [27:23])

6. **Order flow sequencing (bearish/bullish)** — successive higher volume traded at each price level in one direction; bearish = 12→55→62→80→100→150 selling on bids, bullish = buying eats through stacked offers at successively higher size. Signals institutional directional conviction. (v237, [16:00]–[16:26])

7. **Sequencing reversal / zone retest** — after an order flow sequencing signal fires, the zone left behind acts as potential S/R; price returning to that zone can be faded with a stop just beyond the zone. (v237, [28:04]–[29:34])

8. **Big bid/offer absorption failure (Bitcoin context)** — large passive buyers (or sellers) that absorb initial selling (or buying) but fail to hold; when price returns and the same level cannot sustain, it signals the trapped longs (who bought at support) are now offering out, producing a secondary reversal. (v238, [04:44]–[08:47])

9. **Stop sweep / big-order sweep** — "100+ bitcoin" passive bid (or offer) gets traded straight through with zero counter-trade (all zeros nearby), sweeping liquidity and signaling a weak market. (v238, [10:15]–[12:23])

---

## B. Tiering / grading language  ← HIGH PRIORITY

1. **"Slam dunk"** — the highest verbal grade in v236; "sometimes it's just super duper obvious that yeah it's just what I call a slam dunk … you could just see it developing." Criteria: all pieces align (exhaustion + value area + trend context). (v236, [43:00])

2. **"Very obvious" / "just right here" / "one little number"** — the exhaustion print is described as an obvious/easy-to-read signal; the four-contract exhaustion print at the high is called out explicitly as "telling you people aren't interested anymore." (v236, [13:03]–[21:57])

3. **"Nice turning points"** vs. **"small losses here and there"** — for the sequencing indicator, good signals align with a swing and produce "nice turning points"; signals without a swing context or follow-through are the small-loss trades. (v237, [27:03])

4. **"Fantastic" levels** — sequencing zones that price returns to precisely and reverses strongly; "like here this was ultra bonds came right through that level and shot up." Contrasted with levels the market "just went right through." (v237, [29:34])

5. **Implicit "keep me out" grading** — the trade entry signal (follow-through filter, 2-tick/2-bar) eliminates "seven trades, one of which was a winner" in a stretch; trades without follow-through are explicitly sub-grade / skip. (v237, [31:47]–[33:24])

6. **"Signs of a weak market"** — double big-bid sweeps (111 + 101 BTC swept) = weak market label in crypto context. (v238, [11:20])

---

## C. Order-flow story & psychology per setup

1. **Exhaustion / double-top psychology**: Buyers who were active at lower prices keep returning to swing highs. By the third attempt "people are tired of buying … rejecting these higher prices." Volume drops from triple digits to single digits. The last buyers have bought. Price reverses. (v236, [15:44]–[21:57])

2. **Zero print psychology**: On the second attempt up to a prior high, the bar opens and "nobody was interested in buying lifting the offer — everyone was just interested in selling." Aggressive selling into passively resting bids. The follow-on bar has zero offer-side volume = no new aggressive buyers at all. (v236, [18:22]–[19:22])

3. **Virgin value area psychology**: A bar that gaps its value area over the prior bar's VA-High (or below VA-Low) signals "value has moved"; the market "needs to come back and test" that exposed zone. When it returns and exhaustion/rejection appears at the zone boundary, the trade is valid. (v236, [29:59]–[36:46])

4. **Sequencing psychology**: A large institutional order is worked in pieces (PoV algo, liquidity-seeking algo) at successive price levels. Bullish sequencing = algo eating through stacked offers at higher and higher size = more conviction with each level, forcing price higher. Bearish = algo systematically selling into bids. Retail should trade with, not against, this flow. (v237, [08:28]–[16:26])

5. **Trapped buyer/absorption-failure psychology (Bitcoin)**: Big passive buyers absorb an initial down-move; when price rallies back to breakeven the trapped longs "take their opportunity to get out … offering out 55, 54" — not aggressively hitting bids (which would tank the market) but passively offering into buy flow, keeping a "foot on the neck of the market." This produces a secondary rejection and a clean short opportunity. (v238, [05:46]–[09:41])

6. **Big-bid sweep psychology**: When passive bids of 111+101 BTC fail to hold (both swept straight through), it signals "the market is stronger than the passive buying"; aggressive sellers dominate and the market is in a weak state. (v238, [10:15]–[11:53])

---

## D. Exhaustion clues

1. **Tiny ask volume at a swing high** — volume drops from triple/double digits earlier in the move to single digits (e.g., 134→71→6) at the bar that prints the new high. The absolute level is relative to the session's normal volume, not a fixed threshold. (v236, [14:35]–[15:14]) [REPEATED]

2. **Zero print on the offer** — literally 0 contracts traded on the ask side at a swing high bar (or bid side at a swing low); "tells you there was no cross-trade … nobody interested in buying." (v236, [18:55]) [REPEATED]

3. **Volume in single digits at a swing point** — used as a qualitative anchor: "normally you're going to have volumes in double digits … 20, 30, 40, 50, 60, 80, 100… 4." Single digits = exhaustion. (v236, [21:57]) [REPEATED] NEEDS-OPERATIONALIZATION (no fixed absolute threshold stated)

4. **Exhaustion at a virgin value area boundary** — when price returns to an untested value area and the first prints at the zone top (or bottom) are exhaustion-level volume, the signal is reinforced. (v236, [35:08]) [ONCE]

---

## E. Absorption clues

1. **Large passive bid absorbed then overrun** — a known large bid (e.g., 166 BTC, then 100+ BTC) absorbs initial selling but fails to turn the market; when price comes back and the same level cannot rally, the original buyer is now a trapped seller. (v238, [04:08]–[05:46]) [ONCE]

2. **Big buy-side volume at a low with no follow-through** — market has 200+ BTC absorbed in a tight range; "you would think that would be supportive … but it couldn't hold up the market." When subsequent bars show no continuation of aggressive buying, the absorption is exhausted. (v238, [04:44]) [ONCE]

3. **Passive offer absorption at a swing high (sequencing context)** — in sequencing, "someone with supply to sell" works big size passively on the offer; buyers keep lifting but eventually "can't buy anymore." The sequencing indicator catches the point where supply overwhelms demand. (v237, [13:08]–[23:45]) [ONCE]

---

## F. Stacked imbalance ideas

— nothing specifically new in this chunk beyond the sequencing concept described in Section A (order flow sequencing is not footprint imbalances but DOM sequencing) —

1. **Order flow sequencing = DOM-level stacking** — sequential higher volume at successive price levels in one direction on the footprint (not the delta imbalance diagonal) constitutes "sequencing." Cluster size default = 5 (E-mini, volatile markets); 3 for less volatile markets (interest rates). Swing filter: recent high/low qualification toggle. (v237, [26:35]–[27:31]) [ONCE]

---

## G. Delta / delta-divergence ideas

1. **Delta at a double-top**: first high = negative delta (−39); second attempt = small delta; third attempt = bar opens positive delta, next bar flips negative → the sequence of delta weakening across the three attempts confirms the bearish case. (v236, [17:49]–[18:55]) [ONCE]

2. **Positive delta at a swing low = buyers stepping in**: briefly mentioned as a bullish clue alongside exhaustion print and value area support; "I've got positive delta on the low so it's telling me buyers are stepping in." (v236, [37:17]) [REPEATED per digest]

3. **Small deltas = quiet / non-trending**: "pretty small deltas in the markets … 12, 6, 8 … trading has kind of quieted down." Small delta = low conviction, avoid entries. (v238, [14:33]) [ONCE] NEEDS-OPERATIONALIZATION

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

1. **Failed rally into untested value area**: market rallies into an exposed/virgin value area, hits the top of that zone with exhaustion prints, and fails to enter the zone. Treated as a bearish continuation signal, not just S/R. (v236, [35:08]–[36:12]) [ONCE]

2. **Big-bid sweep (crypto)**: 111 BTC passive bid at a known support level is swept straight through; market does not bounce. Followed immediately by another 101 BTC bid also swept. Both sweeps = "signs of a weak market." Not a reversal signal but a continuation/capitulation marker. (v238, [10:15]–[11:20]) [ONCE]

3. **DOM resting orders as unreliable S/R**: "looking at a dome doesn't really give you an accurate indication … the dom is just levels people are willing to buy or sell at, doesn't mean the market will trade there." Resting DOM orders can be pulled before price reaches them. (v237, [03:09]–[03:40]) [ONCE]

---

## I. Trapped-trader ideas

1. **Trapped long from failed absorption**: buyers who stepped in at 47,900 BTC with 166 BTC absorbed; market never followed through; on the rally-back to breakeven they become sellers ("offering out 55, 54 … they're probably offering more but that's what traded"). The trapped long becomes the marginal supply capping the rally. (v238, [05:17]–[08:47]) [ONCE]

2. **"Blue zone" as trapped-trader marker (crypto)**: the Orderflows software draws a "big blue zone" where a prior failed absorption occurred; this zone "should hold as support" when price returns, as trapped sellers who shorted at the absorption level will buy to cover. (v238, [13:56]) [ONCE] — refers to the standard trapped-trader indicator zone but in a crypto context.

3. **Third-attempt sellers are trapped shorts**: in the double-top example, after price fails twice and then the third bar opens with zero offer-side volume and heavy bid-hitting, anyone short who was waiting for the breakdown is now seeing their stop threatened momentarily then confirmed; they add to shorts, creating a self-reinforcing move. (v236, [18:55]–[19:50]) [SPECULATIVE inference from context]

---

## J. Entry triggers (the exact "go" event)

1. **Exhaustion print → next bar closes in the direction of rejection**: "recognizing that lack of buying coming in off this double top … and coming back up … it sells off." Entry on the bar that confirms the move, not the exhaustion bar itself. (v236, [19:22]–[20:48]) [REPEATED]

2. **Order flow sequencing "trade entry signal"** — the indicator's built-in filter: price must move ≥2 ticks in the signal direction over ≤2 bars after sequencing fires. The confirmed signal = triangle up/down. No triangle = no trade even if sequencing is present. (v237, [31:17]–[32:45]) [ONCE — specific to sequencing tool]

3. **Value area test + exhaustion combo**: price returns to an untested value area, trades into the zone briefly, volume is exhaustion-level → entry in the zone's direction. Stop = beyond the zone boundary (or at POC if a wide zone). (v236, [35:45]–[41:33]) [ONCE]

4. **Sequencing zone retest**: after sequencing fires, place a limit bid/offer at the zone boundary with a stop just beyond; entry triggered when price returns. Not Mike's primary method ("personally I think you're better off taking the trade initially"). (v237, [28:32]–[29:34]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

1. **Follow-through buying/selling on next 1–2 bars**: "object in motion is going to continue in motion" — after a zero print + big negative delta, "chances are it's going to continue." (v236, [19:22]) [REPEATED]

2. **Trade entry signal (2-tick / 2-bar filter)**: the Sequencing indicator's built-in follow-through gate; confirmed by a triangle on the chart. Absence of triangle = setup exists but lacks confirmation. (v237, [31:17]) [ONCE]

3. **POC migration in signal direction**: "you can see the point of controls in each bar migrating higher … and you can see the signs in the deltas as well" — sequential POC shifts confirm directional intent after value area breakout. (v236, [31:26]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

1. **Price re-entering the virgin value area cleanly**: if price returns to the untested zone and then trades all the way through (the zone does not hold), the thesis is off. "Sometimes you know the levels are fantastic … sometimes the market just went right through." (v237, [27:31]–[29:34]) [REPEATED in softer form]

2. **Sequencing zone violated**: if price trades back into the sequencing zone and keeps going (as shown in the "went right through" examples), the sequence is invalidated. (v237, [28:32]) [ONCE]

3. **Big bid swept without bounce**: when a 100+ lot passive bid is swept straight through with no counter-trade (all zeros on bid side), do not buy — it signals "the market is stronger" to the downside. (v238, [10:48]–[11:20]) [ONCE]

4. **Order flow follow-through absent**: in the sequencing tool, no triangle up/down after the pattern fires = do not enter. "Seven trades, one winner … it kept me out of these losing trades." (v237, [32:11]) [ONCE]

---

## M. Stop / risk / target / trade management

1. **Stop "just right here"** at swing high/low if short/long off exhaustion: "my stop is just right here … if it starts coming back up there I'm going to be wrong." One-tick beyond the extreme implied. (v236, [33:30]) [REPEATED]

2. **Value area zone stop**: stop goes "on the other side of the zone." For wide zones: stop at POC first (mental stop), hard stop at far zone boundary. For narrow zones: use the entire zone width as the stop. (v236, [41:02]–[41:33]) [ONCE — specific detail on wide vs narrow zones]

3. **Sequencing indicator: stop = 5 ticks (ultra bonds), TP = 7 ticks**: shown in the markers automation demo. Explicitly marked as market-specific and ATM-adjusted. (v239, [01:24]–[01:54]) [ONCE]

4. **ATM automation for sequencing**: use Markers Plus Force with fast signal mode, buy and sell copies, ATM set to max daily loss/profit; for micros keep at $500, for ultra bonds set to $5,000. (v239, [00:57]–[01:24]) [ONCE]

5. **Classic double-top entry advantage**: order flow entry at the point where selling begins (on the 2nd/3rd attempt) vs. classic price breakout entry (when prior swing low is taken out) can save "an extra six points." (v236, [20:18]–[20:48]) [ONCE]

6. **Retest trade management**: if in a sequencing trade and price returns to zone, "I may throw a bid or an offer in" for a second entry; but primary preference = take the trade immediately at signal. (v237, [29:34]–[30:07]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

1. **Volatile market session context (2022-03-20 geopolitical)**: in high-volatility periods, volume spreads out across more price levels; single bars may have 4,000 contracts over 7 handles. Exhaustion reads still valid but volumes at individual levels will be more diluted — relative comparison within the session still applies. (v236, [13:32]–[14:35]) [ONCE]

2. **Interest rate markets preferred for sequencing**: cluster size 3 (less volatile); equity indices use cluster size 5 (more volatile). Bonds/tens read sequencing cleanly. (v237, [27:03]) [ONCE]

3. **Market fractal / timeframe agnostic**: value areas on 1-minute and 5-minute charts both give "that insight" and are both valid; "whether you're looking at value on a one minute chart it's going to give you that insight … same on a five minute chart." (v236, [26:58]) [ONCE]

4. **Bitcoin / crypto applicability**: order flow works on BTC (Coinbase feed, free, real-time on NT8); two-way auction structure is the same. Sequencing, absorption, exhaustion all apply. Key caveat: "when you're trading order flow you're trading the now … not buying and holding." (v238, [11:53]) [ONCE]

5. **Afternoon/pre-Asia session**: Mike notes "quiet time before Asia kicks off … pretty small deltas." Low conviction = avoid reversal setups that require follow-through. (v238, [14:33]) [ONCE]

6. **Value areas overlap day-to-day**: "oftentimes value areas are going to overlap one bar to the next, not going to be jumping around." Gaps in value area are the significant signal, not normal overlap. (v236, [24:25]) [ONCE]

7. **DOM orders as magnet, not resistance**: resting large orders on DOM "should hold the market" in theory but often don't because algos pull liquidity before price arrives; "anyone could throw in a big order just to impact the market." DOM is unreliable as a hard S/R level. (v237, [12:41]–[13:46]) — consistent with digest's "DOM is a magnet not resistance" note. [REPEATED]

---

## O. Directly testable / measurable variables

1. **Exhaustion print threshold**: volume at a swing high/low edge that is dramatically lower than recent bars at the same move. Relative, not absolute. He gives qualitative examples: "normally double digits … 20, 30, 40, 50 … 4" or "134 → 71 → 6." NEEDS-OPERATIONALIZATION (no fixed ratio stated for this instrument/time)

2. **Zero print**: offer volume = 0 at a swing high bar (or bid volume = 0 at a swing low bar). Binary, directly testable. (v236, [18:55])

3. **Double-top definition**: within 1–2 ticks of prior swing high/low ("ideally exactly at same price level but 1–2 ticks is fine"). Operationalizable. (v236, [17:22])

4. **Value area gap**: current bar's VA-Low > prior bar's VA-High (bullish gap) or current bar's VA-High < prior bar's VA-Low (bearish gap). Binary signal. (v236, [26:25])

5. **Untested value area / virgin VA**: a bar's value area that has NOT been entered by the immediately following bar's price range. Testable via bar-by-bar VA tracking.

6. **POC migration direction**: successive bars' POC migrating consistently higher or lower across N bars = trending context confirmation. NEEDS-OPERATIONALIZATION (N not stated)

7. **Sequencing cluster size**: default 5 (volatile markets/equity index), 3 (less volatile/rates). Measurable parameter. (v237, [26:35]–[27:03])

8. **Sequencing swing filter**: on/off toggle; when on, signal only fires at a recent swing high or low. (v237, [25:34])

9. **Sequencing follow-through gate (trade entry signal)**: 2-tick move over 2 bars (same as the broader follow-through default). Explicitly confirmed in v237. (v237, [31:17])

10. **Sequencing stop (ultra bonds example)**: 5 ticks. TP: 7 ticks. Market-specific. (v239, [01:24])

11. **Large passive order detection (crypto)**: 50+ BTC in a single transaction identified as "big" vs. 10–20 BTC as "smaller numbers." NEEDS-OPERATIONALIZATION for futures (contract-size equivalent not given)

12. **Small delta threshold**: "12, 6, 8" described as small/quiet. NEEDS-OPERATIONALIZATION

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

1. **Orderflows Sequencing Indicator (NT8 only)**: runs on NT8 candlestick charts (not footprint required); parameters: cluster size (default 5), swing period (on/off), sound alert, trade entry signal (2-tick/2-bar follow-through gate), zone visualization (fixed bars, until-tested, or none). (v237, [25:34]–[26:35])

2. **Markers Plus Force integration**: two instances of Markers Plus Force for automated sequencing trading — one for buys (longs), one for sells (shorts); fast signal mode; data series set to the sequencing indicator; calculate on each tick; ATM linked to each instance. (v239, [00:27]–[05:43])

3. **Zone drawing (sequencing)**: zones drawn out from the sequencing bar for a configurable number of bars or "until tested" — useful as stop reference even if the user does not trade retests. (v237, [27:31]–[28:04])

4. **Untested value area zones (Orderflows Trader 5.0)**: software automatically draws zones from each bar's value area that remain untested by subsequent bars; visually shows exposed VAs as forward-looking S/R zones on the chart. (v236, [35:45]–[44:26])

5. **Exhaustion print highlighting**: software highlights cells at bar edges where volume drops to exhaustion levels; the chart marks these automatically so the trader does not have to scan every number. (v236, [15:44]–[16:16])

6. **Delta displayed per bar**: bid×ask layout with bar-level delta; negative delta bar labels visible in the double-top examples (−39, −228, etc.). Already standard in footprint but confirmed as used intraday. (v236, [17:49])

7. **Coinbase free real-time feed via NT8**: for Bitcoin order flow analysis, NT8's Coinbase connection provides free real-time bid/ask data suitable for footprint analysis. (v238, [02:04]–[02:37])

8. **ATM automation details for sequencing**: for NT8/Markers Plus — max daily loss and profit values must be calibrated per market tick value (ultra bonds = $31.25/tick → use $5,000 daily limits for 5-tick stop; micros → $500). (v239, [01:24])

---

## Q. Notable verbatim quotes

1. "The more complex the methodology the more psychological impediments develop to hinder your trading … simple and obvious is always better than complex and convoluted." (v236, [06:37])

2. "If you're at a swing high and you see lack of buying and you see the market reverse down closes down — what do you think is happening?" (v236, [16:16])

3. "Normally you're going to have volumes in double digits … 20, 30, 40, 50, 60, 80, 100 … 4. Right? On a swing high this is just telling you people aren't interested anymore." (v236, [21:57])

4. "An object in motion is going to continue in motion — what happens? That's your opportunity to get short." (v236, [19:22])

5. "If you're just focusing on price this is where you're gonna be getting short … but if you're reading the order flow you could be getting short right in here as you're starting to break down after attempting that double top." (v236, [20:48])

6. "Seven trades, one of which was a winner … it kept me out of these losing trades. Imagine you can take out a chunk of your losing trades when there's no follow-through order flow." (v237, [32:11])

7. "Sometimes there's sequencing that fails … that's why we draw these zones … you know where you're going to be getting out." (v237, [27:31])

8. "When you're trading order flow you're trading the now … not buying and holding — that's a different type of trading altogether." (v238, [11:53])

9. "You would think that would be supportive and it couldn't hold up the market … the market is stronger than the passive buying." (v238, [04:44]–[11:20])

10. "Sometimes it's just super duper obvious … I call it a slam dunk — you could just see it developing." (v236, [43:00])

---

## R. Contradictions / nuances

1. **DOM stacked orders ≠ reliable S/R**: "a big order should hold the market … but it isn't often times … the opposite is happening — the market is working its way through." This directly nuances the intuitive assumption that large DOM size = support/resistance. Consistent with digest note but elaborated further: algos pull liquidity as price approaches, and what's visible on DOM is often not what trades. (v237, [13:08]–[14:44]) [REPEATED per digest note]

2. **Passive large buying can be bearish**: a large passive buyer (166 BTC, then 100+ BTC) that absorbs selling is often the trapped long who becomes the seller once price rallies back to their entry. The "buying" at support is not bullish if it is absorption-failure buying. Same as digest item but with crypto-specific mechanism described in detail. (v238, [05:17]–[08:47]) [REPEATED — elaborated]

3. **Sequencing signal without a swing filter can produce many false signals**: "If I was just taking any time sequencing occurred … seven trades, one winner … six were losers." The swing filter + follow-through gate combination is mandatory for a high-quality setup. Without them, sequencing is noise. (v237, [31:47]–[33:24]) [ONCE — refines sequencing model]

4. **Retest trades are secondary, not primary**: Mike's explicit preference is to take the sequencing trade at signal time ("personally I think you're better off taking the trade initially") and use the zone for a potential second entry. The until-tested zone approach is offered as an alternative for traders who prefer working limit orders. (v237, [29:34]) [ONCE]

5. **Candlestick patterns (hammer) can be wrong when value area context contradicts**: hammer bar formed at a level with a virgin value area (prior VA) acting as resistance — "the candlestick lost to the resistance based off order flow … I'm seeing signs in the order flow that's still bearish." Candlestick and order flow can directly contradict; order flow wins. (v236, [34:01]–[36:46]) [ONCE — concrete example]

6. **Volume spread in high-volatility conditions**: during extreme volatility (March 2022 geopolitical), a single 5-minute bar can contain 4,000 contracts over 7 handles; the exhaustion print threshold must be evaluated relative to the session's normal per-level volume, not historical averages. (v236, [13:32]–[14:02]) [ONCE]

7. **Value area overlap is normal; gaps are the signal**: "oftentimes value areas are going to overlap one bar to the next — not going to be jumping around." The absence of overlap (gap) is the anomaly and the signal, not the default state. (v236, [24:25]) [ONCE]

---

## Coverage note

v236 is rich — a full 10,000-word introductory webinar covering exhaustion prints, zero prints, double-tops with order flow confirmation, virgin/untested value areas, POC migration, and value-area gap context. High model content. v237 is mixed — introduces the Sequencing indicator (a non-footprint DOM-sequencing tool) with useful operationalizable parameters and an important nuance about the follow-through gate. v238 is thin-to-mixed — Bitcoin walkthrough; useful for absorption-failure and big-bid-sweep mechanics but thin on new reversal setup rules; primarily illustrates known principles in a crypto context. v239 is thin — Markers Plus integration demo; operationally useful for NT8 automation but minimal new model content.
