# Chunk 110 Extraction
- Source chunk: Chunk_110_Orderflows_Transcripts.md
- Transcripts covered:
  - v374 — Free Order Flow Trading Course For Gocharting Platform (2023-09-05)
  - v416 — How To Update Your NinjaTrader 8 Platform To The Latest Version For Orderflows Trader (2024-02-13)
  - v419 — Orderflows Trader 7 New Order Flow Trading Software For NT8 (2024-03-02)
  - v430 — Get My Book Trading Order Flow For Free (2024-04-18)
  - v431 — Orderflows Delta Scalper Upgrade That Will Blow Your Mind (2024-07-19)
- Overall content value: mixed (v419 and v431 contain a meaningful density of implementation/tool-logic detail; v374, v416, v430 are thin promotional/housekeeping content)

---

## A. Setup types & names he uses

- **Accumulation / Distribution** (bullish/bearish): new tool in OFT7; identifies passive traders showing their hand; most useful with "passive traders in control" filter enabled; bearish signal = distribution at a high, bullish = accumulation at a low. (v419, "Orderflows Trader 7", [17:54])
- **Aligned Point of Controls** (bullish support / bearish resistance): multiple consecutive bars with the same or migrating POC at the same price; signals sustained willingness to transact; bullish = support, bearish = resistance. (v419, [22:35])
- **Open Point of Control** (bullish/bearish): POC migrating higher bar-over-bar with volume = healthy move; bullish = volume and price both rising. (v419, [44:37])
- **Delta Breakout** (bullish/bearish): new OFT7 tool; looks for growth in delta (positive or negative) above a threshold (default 200 for 1-min E-mini); distinct from Delta Surge/Delta Scalper. (v419, [27:12])
- **Delta Tail** (bullish/bearish): new OFT7 display; existing concept; up-candle with negative delta at bottom price levels and positive all the way up = absorption of aggressive selling (bearish signal top-of-bar = absorption of aggressive buying). (v419, [35:32])
- **Imbalance Reload** (bullish/bearish): new OFT7 tool; same-level imbalance appearing on two consecutive bars = sustained aggressive buying/selling; requires legitimate volume (not light). (v419, [40:43])
- **Volume Decline** (bullish/bearish): decreasing volume on bottom three price levels of a green up-candle (bullish) or top three of a red down-candle (bearish); volume drying up on a move. (v419, [1:14:56])
- **POC Wave** (bullish/bearish): three-bar pattern — neutral bar, then bar with lower POC, then bar with higher POC (bearish); or neutral, lower POC, higher POC (bullish); best used at a swing high/low with confluence. (v419, [56:24])
- **Resting Liquidity** (bullish/bearish): horizontal volume spread over bars; bullish = green, bearish = red; best used quickly, preferably as soon as first signal appears. (v419, [1:00:41])
- **Vertical Liquidity** (bullish/bearish): stacked volume at consecutive price levels above a threshold; think of it as stacked liquidity being removed from the market; cluster size (levels) adjustable. (v419, [1:10:47])
- **Retail Suck** (bullish/bearish): order flow in bar shows volume increasing on the way down in a bearish move or way up in a bullish move, trapping retail; name means retail traders getting sucked into bad positions. (v419, [1:05:55])
- **Price Action Divergence** (bullish/bearish): green candle with negative delta (supply absorbing aggressive buying, or passive buyers bidding up market against aggressive sellers); red candle with positive delta (absorption of aggressive selling). Recommended with swing filter. (v419, [52:23])
- **Orderflow Gaps** (bullish/bearish): new OFT7 tool; gap between two bars on footprint chart; stop goes 1 tick beyond first bar extreme; best with swing filter. (v419, [48:27])
- **Delta Scalper multi-timeframe** (bullish/bearish): upgraded Delta Scalper that plots higher-timeframe (5, 10, 15, 30-min or tick/volume/range) signals onto a lower-timeframe chart; best setups when higher-TF and lower-TF aligned. (v431, [00:27])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"My favorite" / "I like to use a lot"** applied to: swing filter applied to Delta Divergence, Market Weakness, Accumulation/Distribution with "passive traders in control" filter. (v419, [31:59], [18:27], [43:15])
- **"More effective in my opinion"** applied to Orderflow Gaps with swing filter vs. without. (v419, [49:06])
- **"Very powerful"** applied to multi-timeframe Delta Scalper (HTF signal on LTF chart). (v431, [05:07])
- **"Outstanding results"** attributed to multi-timeframe Delta Scalper upgrade. (v431, [00:27])
- **"Highest probability"** applied to: HTF + LTF aligned Delta Scalper setups; setups where "higher time frame and the lower time frame are aligned." (v431, [05:34])
- **"Best setups"** = higher TF and lower TF aligned. (v431, [05:34])
- **"Not happy with"** = Delta Scalper sell signals where the move was counter-trend to HTF; removing those by using 5-min overlay cleaned signals up. (v431, [12:49])
- **"Beautiful move"** described for Resting Liquidity signal on bonds range chart. (v419, [1:08:41])
- **"Great tool to complement footprint"** for Delta Scalper. (v431, [07:41])
- **"Pointless" / "no context"** = Price Action Divergence on bar-by-bar basis without swing filter. (v419, [55:43])
- **"Clean" / "cleaner"** applied to range-based charts vs. time-based for multiple tools; HTF Delta Scalper overlay vs. base chart. (v419, [23:47]; v431, [23:32])

---

## C. Order-flow story & psychology per setup

- **Imbalance Reload story**: aggressive buyers (or sellers) move market; market pulls back; same aggressive buyers return at the exact same price level — sustained conviction signal. (v419, [40:43])
- **Delta Tail story (bearish at top)**: green up-candle with negative delta at bottom levels — aggressive buying is being absorbed by passive sellers (near-term absorption signal). (v419, [35:32])
- **Price Action Divergence story**: green candle, negative delta = passive buyers bidding up the market, absorbing whatever aggressive selling is taking place; red candle, positive delta = supply is up there absorbing aggressive buying. (v419, [52:23])
- **Retail Suck story**: retail traders being trapped into bad positions as volume increases in the direction of a move; opposite of a healthy move signature. (v419, [1:05:55])
- **Resting Liquidity story**: liquidity that actually traded; market eats through one liquidity level → going to look for next liquidity level; get in after first level is taken out, before second is reached. (v419, [1:04:56])
- **Accumulation / Distribution story**: passive traders are "showing their hands"; e.g., distribution on uptrend = someone puking out a position; accumulation = institutional buyers quietly bidding the market. (v419, [19:01])
- **Delta Scalper multi-TF story**: iceberg orders hidden in DOM get revealed once they trade; HTF structure = "older/bigger brother bullies the younger"; LTF trend may lead briefly but HTF wins. (v431, [00:53], [05:07])

---

## D. Exhaustion clues

- Exhaustion prints: existing tool, swing filter now available in OFT7. (v419, [40:03])
- Failed Delta Divergences: multiple in short period = trend day, don't fade. (v419, [32:25]) [REPEATED — already in digest, noting here for completeness]
- "A lot of failed divergences in one direction consistently" with new highs/lows = trend day indicator. (v419, [33:07])

---

## E. Absorption clues

- **Delta Tail**: aggressive buying being absorbed at the top of a bar (bearish); aggressive selling absorbed at bottom (bullish). This is the explicit "near-term absorption" signal for OFT7. (v419, [36:03]) [ONCE]
- **Price Action Divergence**: green candle / negative delta = passive buyers absorbing aggressive sellers; red candle / positive delta = passive sellers absorbing aggressive buyers at supply. (v419, [52:23]) [ONCE]
- **Accumulation/Distribution with "passive traders in control" filter**: passive traders absorbing what aggressors throw at them; e.g., big seller at 1778 "puked out a position" and market ran up from there. (v419, [19:33]) [ONCE]

---

## F. Stacked imbalance ideas

- Swing filter now available for Stacked Imbalances in OFT7 — use to isolate stacked imbalances appearing at swing highs or swing lows only. (v419, [1:09:24])
- Volume Imbalance (multiple imbalance) also gets swing filter in OFT7; default ratio setting stated as 4:1 (400%). (v419, [1:18:04])
- **Imbalance Reload**: two consecutive bars with imbalance at the same price level = sustained aggressive buying/selling; requires strong volume (not light, e.g., "2011" contracts cited as example of strong, "3671" cited as needing strong volume). (v419, [41:16]) [ONCE]

---

## G. Delta / delta-divergence ideas

- **Delta Divergence swing filter update (OFT7)**: default was HOD/LOD only; swing filter now allows divergence at any swing high/low, not just HOD/LOD. He considers this important because divergence at a swing high mid-day can also be significant. (v419, [31:59]) [ONCE — refines digest]
- **Delta Breakout tool**: looks for growth (positive or negative) in delta above threshold; default 200 for 1-min E-mini; 200 may be "too weak" for e.g. grains or currencies; use higher values (500+) on range/slower charts or 5-min charts. (v419, [27:12]) [ONCE]
- **Delta Scalper multi-timeframe**: overlay 5, 10, 15, 30-min signals on 1-min chart; positive/negative Delta strength settings: base=1, doubling scale (1→2 = 2x, 2→3 = 4x from base); momentum strength 1–6 (disable if using swing filter for reversals; use 3 as middle-of-road for trend-following). (v431, [08:09])
- Failed divergences: "recognizing a trend day early is on the back of a lot of failed divergences." (v419, [33:07])

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Resting Liquidity sequence**: market takes out one liquidity area → will seek next liquidity area; entry is after first level is taken, before second is reached. (v419, [1:04:56]) [ONCE]
- **Vertical Liquidity**: consecutive price levels with volume above threshold "being removed from the market" on a trending move; successive higher levels taken out = trend confirmation. (v419, [1:12:10])
- **Orderflow Gaps**: gap between two bars with stop just beyond the first bar; swing filter separates valid setups from noise. (v419, [49:06])

---

## I. Trapped-trader ideas

- **Retail Suck**: explicitly a trap-trader setup — increasing volume in direction of move traps retail into bad positions; counterpart to institutional absorption setups. (v419, [1:05:55]) [ONCE]
- **Delta Tail (bearish)**: "aggressive buying is being absorbed" = buyers at the top are trapped; near-term signal. (v419, [36:03])
- **Price Action Divergence**: red candle / positive delta at a swing high = "absorption taking place up there" — buyers trapped above. (v419, [53:37])

---

## J. Entry triggers (the exact "go" event)

- **Resting Liquidity**: enter after the first liquidity level is taken out; do NOT wait for second or third level (too late, like buying Bitcoin at $60k). (v419, [1:01:53])
- **Delta Scalper**: up-triangle = buy signal, down-triangle = sell signal; zone drawn from where signal first appeared = line-in-the-sand / stop reference. (v431, [07:12])
- **Orderflow Gaps (with swing filter)**: enter on gap signal at swing high/low; stop beyond the first bar extreme. (v419, [49:06])
- **POC Wave**: "go time" when market comes to a level and POC Wave appears; can also trade standalone with swing filter. (v419, [56:57])
- **Delta Tail**: bar close showing tail pattern is the trigger. (v419, [35:32])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Delta Scalper**: "works immediately" implied — if higher TF structure is doing its job, lower TF is unlikely to reverse; zone drawn from signal acts as trade management reference. (v431, [05:07])
- **Resting Liquidity**: "best used quickly" / "any order flow is best used quickly" — needs immediate follow-through after level is taken. (v419, [1:01:24])
- **Volume Decline with "until tested" draw mode**: zone remains live; when market comes back to that area you see if it holds, providing a second-chance context. (v419, [1:15:25])
- **Aligned POC (bullish)**: successive blue zones on a range chart confirm a healthy move; used with open POC to confirm directional move has volume support. (v419, [22:35])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Delta Scalper (swing filter off, momentum on)**: momentum strength set to 3 means you are trading WITH momentum — a reversal of that HTF momentum is an implicit invalidation. Turn off momentum strength when using swing filter (because you're now trading reversals, not trend). (v431, [09:01])
- **Resting Liquidity**: if market "eats through" the liquidity rather than reversing = going to next liquidity level, not reversing. (v419, [1:04:26])
- **Imbalance Reload**: low/light volume disqualifies the signal — needs "strong" sustained volume. (v419, [41:57])
- **Price Action Divergence without swing filter**: on a 1-min E-mini chart "you're going to see a lot" of signals — too many to be useful; implicit invalidation = signal not at a swing extreme. (v419, [54:19])

---

## M. Stop / risk / target / trade management

- **Delta Scalper zone**: zone drawn from where the signal first appeared = stop reference line; "that is your sort of your line in the Sand your stop." (v431, [14:21]) [ONCE — specific implementation detail]
- **Orderflow Gaps**: stop placed 1 tick beyond the extreme of the first bar where the gap appears (bullish: stop below first bar; bearish: stop above first bar). (v419, [49:47])
- **Resting Liquidity**: entry timing is critical for risk management — entering after first level taken = smaller risk than entering after third. (v419, [1:02:20])
- Targets: remain discretionary; no explicit target rules in this chunk.

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **GoCharting platform**: web-based, no install; supports footprint charts; suitable for trading on iPad/mobile. Tick manager "auto mode" recommended for Forex/crypto. (v374, [01:21], [05:45])
- **Nifty / Bank Nifty nuances**: "has its own little nuances" different from CME; warrants separate video treatment; not fully covered in this chunk. (v374, [07:01]) [ONCE]
- **Crypto (Coinbase preference for US)**: use coinbase data in GoCharting for US traders; tick size adjustment needed. (v374, [05:45])
- **Overnight / low-volume sessions**: swing filter recommended for Delta Tail during overnight/thin markets; during US hours (normal trading days) prefer no swing filter to capture intraday moves. (v419, [39:22]) [ONCE — new session-specific nuance]
- **Range-based charts vs. time-based**: many tools (Aligned POC, Delta Tail, Volume Decline) perform "better" or look "vastly different" on range charts; bonds especially well-suited to range-based charts. (v419, [23:47], [39:22])
- **Cash open (09:00–09:30 CT)**: expect elevated volume in liquidity tools — not a reliable signal period for Resting/Vertical Liquidity due to order flow noise; explicitly noted. (v419, [1:05:24])
- **E-mini default settings**: Delta Breakout default 200 (1-min chart); may need upward adjustment for 3-min/5-min or range charts. (v419, [28:20])
- **Bonds (range chart)**: multiple tools show "nice trades" on bonds with range chart (Delta Tail, Volume Decline, POC Wave, Resting Liquidity); cited as a preferred market for these tools. (v419, [38:09], [47:08])
- **Delta Scalper multi-TF**: Mike uses 5, 10, 15, 30-min overlays on 1-min chart; hourly not used. (v431, [03:38])
- **Global swing period setting (OFT7)**: single global swing period (default 5) applies to most tools simultaneously; intentional to prevent curve-fitting by using different swing filters per tool. (v419, [20:41])

---

## O. Directly testable / measurable variables

- **OFT7 Ratio Bounds**: High = 30, Low = 69 (displayed as ratio text only when above 30 or below 69); "not set in stone" — 29.8 is a judgment call, not auto-excluded. (v419, [13:23])
- **Swing Period (global)**: default = 5 bars; applies as a universal filter across all OFT7 tools simultaneously. (v419, [14:28])
- **Delta Breakout threshold**: default 200 for 1-min E-mini; NEEDS-OPERATIONALIZATION for other markets/timeframes. (v419, [27:45])
- **Delta Scalper positive/negative strength scale**: base = 1; goes to 2 (doubles base), to 3 (doubles the 2, so 4x base); non-linear doubling. Most users stay at 1. (v431, [08:32])
- **Delta Scalper momentum strength**: 1–6; 0 = disabled; 3 = middle / Mike's default; set to 0 when using swing filter (reversal mode). (v431, [09:01])
- **Imbalance Reload volume requirement**: NEEDS-OPERATIONALIZATION — "strong volume," "not light," "300 321, 454 and then 23" cited as example (23 = too light). (v419, [41:16])
- **Vertical Liquidity cluster size**: number of consecutive price levels (1, 2, or 3); 3 = "quite strong." Volume threshold default 200 for E-mini; probably too light for bonds; 400–500 cited as alternatives. (v419, [1:11:29])
- **Resting Liquidity volume threshold**: default 200 for E-mini 1-min chart; 500 "probably too light" for bonds range chart. (v419, [1:03:02])
- **OFT4/5 original tools (2015)**: ratios, imbalance reversals, delta divergence, zero prints, exhaustion prints = the foundational five from 2015. (v419, [04:12])
- **OFT7 new tools list** (13 new): accumulation distribution, open POC, aligned POC, orderflow gaps, imbalance reload, volume decline, POC wave, delta tail, resting liquidity, vertical liquidity, delta breakout, retail suck, price action divergence. (v419, [12:05])

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **OFT7 requires NT8 version 8.1.2.1** (as of Feb 2024); older versions (8.0.28, 8.1.1.7) cause hanging/crash when loading OFT7 on old chart templates. (v416, [00:29]; v419, [05:18])
- **Fresh chart template required for OFT7 upgrade** from OFT6: clear existing templates from `Documents/NinjaTrader 8/templates/chart/` before loading OFT7; copy old templates to backup folder first. (v419, [09:44])
- **White background recommendation**: Mike uses white background, black text, black crosshair, transparent grid; font size 16 (not default 8). (v419, [07:23])
- **Tick Replay must be enabled** on the chart for OFT7 to function. (v419, [06:22])
- **Global swing period = single parameter**: intentional design decision — prevents per-indicator swing filter curve-fitting; one value governs all tools. (v419, [20:41])
- **Delta Scalper multi-TF implementation**: added "period type" parameter (tick/volume/range/second/minute) and "period value"; set to chart + 0 for same-TF behavior (backward compatible default); multiple instances can be added for multi-TF stack. (v431, [09:27])
- **Delta Scalper zone**: drawn from first signal bar and held until retested; serves as stop reference. Zone persists if not immediately retested. (v431, [14:21])
- **OFT7 defaults on new chart**: Delta Divergence, prominent POC, orderflow ratios, value areas enabled by default; most other tools disabled by default. (v419, [11:28])
- **"Until tested" draw mode**: Volume Decline and Orderflow Gaps both support fixed (show only on signal bar) or "until tested" (zone extends until price comes back to it) draw modes. (v419, [1:15:25], [48:27])
- **Accumulation/Distribution "passive traders in control" sub-filter**: boolean toggle that narrows the signal to only cases where passive traders are dominant; reduces noise especially on high-volume markets like E-mini. (v419, [18:27])
- **Price Action Divergence**: added "literally just earlier this week" before the OFT7 launch (last-minute addition). (v419, [52:06])

---

## Q. Notable verbatim quotes

1. "The best setups are when the higher time frame and the lower time frame are aligned." (v431, "Delta Scalper Upgrade", [05:34])

2. "Higher time frame Trends are longer and harder to reverse, bigger moves are likely to originate from higher time frame levels." (v431, [02:44])

3. "Any order flow is best used quickly." (v419, "Orderflows Trader 7", [1:01:24])

4. "You don't want to just pick light volumes — you want something pretty strong." [on Imbalance Reload] (v419, [41:57])

5. "It's not trying to curve fit it — that's why we've done it that way [global swing period]." (v419, [20:41])

6. "If a higher time frame structure is doing its job then the lower time frame structure is unlikely to reverse." (v431, [05:07])

7. "The problem that I faced with trying to analyze order flow on a higher time frame was sitting through a higher time frame footprint — it's excruciating." (v431, [04:07])

8. "Even here right — you got a Divergence right negative sorry positive Delta on this red candle... you got a Divergence okay so bearish... but this one failed." [Price Action Divergence without context can fail] (v419, [53:37])

9. "You don't get to the point where you know everything — I got a seven-year-old kid and he thinks he knows everything... it's the same way in trading." (v374, [09:51])

10. "The information of what's taking place in the market is there for you to see — it's sort of like peeling back the curtain." (v430, "Get My Book", [05:41])

---

## R. Contradictions / nuances

- **Delta Divergence scope expanded**: digest notes "delta divergence (bar & cumulative)" but OFT7 now adds a swing filter that allows divergence to flag at *any* swing high/low, not just the HOD/LOD. This *refines* (expands) when delta divergence is considered valid — it is not limited to the daily high/low. (v419, [31:59])
- **Momentum strength vs. swing filter are mutually exclusive**: when swing filter is ON (reversal mode) you turn momentum strength to 0/disabled; when momentum is ON (trend-following mode) you turn swing filter OFF. These are two distinct operating modes of the Delta Scalper — not simultaneously usable. (v431, [09:01])
- **"Same settings every market" is nuanced for thresholds**: Mike states the global swing period is the same across tools/markets by design to avoid curve-fitting, but volume thresholds (Delta Breakout, Resting Liquidity, Vertical Liquidity, Imbalance Reload) are explicitly market- and timeframe-dependent. The "same settings" principle applies to ratio/swing logic, not to volume-denominated thresholds. (v419, [28:20], [1:03:02])
- **Ratio text display has a threshold, but the threshold is a display preference, not a hard rule**: ratio 29.8 is below 30 but Mike explicitly says "that's a judgment call I'd like to make" — the 30/69 bounds filter what gets *displayed* (new in OFT7), but the underlying ratio is not invalidated by a near-miss. (v419, [13:23])
- **Range vs. time-based charts alter signal appearance dramatically**: "on a range based chart you get not different signals but the way the bars are formed are much different" — the same tool on a 1-min vs. 8-range chart will look "vastly different." This is a practical caveat for indicator portability. (v419, [24:23])
- **Delta Scalper strength scale is non-linear (doubling)**: going from 1→2→3 is 1x→2x→4x (base doubles, then doubles again), not an arithmetic increment. This matters for parameterization. (v431, [08:32])
- **OFT7 default "enables" are narrower than OFT6**: only Delta Divergence, prominent POC, ratios, and value areas enabled by default — intentionally reduced to avoid overwhelming new users. (v419, [11:28])

---

## Coverage note

v419 (Orderflows Trader 7 launch, ~11,900 words) is the richest source in this chunk — it introduces 13 new OFT7 tools with implementation logic, filtering principles, and inter-tool relationships. v431 (Delta Scalper Upgrade, ~5,000 words) is meaningful specifically for the multi-timeframe HTF/LTF alignment concept and Delta Scalper parameterization. v374, v416, v430 are thin (platform promotional, NT8 update PSA, book giveaway) with negligible model content. No unparseable content; all timestamps are approximate per chunk header.
