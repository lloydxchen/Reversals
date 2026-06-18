# Chunk 060 Extraction
- Source chunk: Chunk_060_Orderflows_Transcripts.md
- Transcripts covered:
  - v193 — Flowscalper Training Part 1 follow the order flow (2020-12-20)
  - v194 — Flowscalper Training Part 2 market examples with the Orderflows Flowscalper (2020-12-20)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Flowscalper signal (bullish/bearish)** — a multi-factor composite: the indicator combines delta, imbalances, POC, and volume to detect a *change* in order flow direction (not a single-factor trigger). Bullish = blue triangle up; Bearish = red triangle down. (v193, "Flowscalper Training Part 1", [07:05]–[08:43])
- **Momentum mode** (swing filter OFF) — signals fire any time order-flow conditions are met, regardless of swing position. Used for scalping/momentum; produces many signals. (v193, [16:15])
- **Reversal/swing mode** (swing filter ON, period 1–25) — signals fire only at swing highs/swing lows over a defined lookback. Produces cleaner, fewer signals; preferred for reversal hunting. (v193, [16:46]–[17:17])
- **Trade Entry Signal** (confirmation filter) — order flow in the next N bars must move N ticks in the direction of the signal before the entry triangle prints. Separates "signal bar" from "entry bar." (v193, [34:44])
- **Zone mode** — a visual zone is drawn from the signal bar forward (configurable width in bars). Used to track whether order flow in a zone remains directional; useful for trade management. (v193, [37:48]–[38:56])
- **Contango mode** — a separate flow-strength track for physically-settled/commodity markets with high commercial participation vs. retail-heavy cash-settled contracts. Treated the same as normal signals. (v193, [26:21]–[28:49])

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"Nice moves" / "nice trade"** — language used for high-quality directional signals that followed through immediately. (v193, [58:30]; v194, [02:23])
- **"A lot of back and forth" / "cardiac market" / "all over the place"** — negative descriptors for NASDAQ/volatile sessions; context where swing filter is required to extract quality signals. (v193, [1:01:06]–[1:02:00])
- **"Chop" / "choppy" / "going sideways"** — signal to reduce or avoid. "Death by a Thousand Cuts on choppy days." (v194, [36:54]) [REPEATED]
- **"Too many signals" / "messy"** — result of too low a flow-strength setting or no swing filter in volatile markets. Drives use of swing filter or higher strength setting. (v193, [16:15]; [24:52])
- **"Clean" / "nice clean buy" / "nice clean sell"** — high-quality signal after adding swing filter. (v194, [01:54]–[02:23])
- **"Really nice move" / "monster move"** — verbatim for large-magnitude follow-through (e.g., near 2-point Ultra Bond move). (v194, [38:54])
- **"Decent signals"** — moderate quality signals in the evening/Asian session. (v193, [1:14:06])
- **"Noise"** — the back-and-forth in volatile markets that makes low-filter settings produce low-quality signals. "There's a lot of noise so to speak in the market." (v194, [20:01])
- **"Curve fit"** — what he explicitly wants to AVOID when adjusting settings per market. Settings should be adjusted for market/volatility, not over-optimized. (v193, [02:59])
- **What moves a setup up a tier**: swing filter enabled (for volatile markets), flow strength ≥5, trade entry signal confirmation over 2 bars / 2 ticks, occurring after a real directional move (not just profit-taking bounce). (v193, [36:14]–[37:48])
- **What moves a setup down a tier**: signal in a chop/sideways market, low flow strength (1–2), no swing filter on volatile market, signal that doesn't follow through within next 2 bars. (v194, [36:54]; v193, [36:49])

---

## C. Order-flow story & psychology per setup

- **Flowscalper core thesis**: "Big traders don't necessarily just pile into the market — they finesse their order without moving the market. When several big traders do this simultaneously it shows up in the order flow as a subtle but detectable change." The tool detects that *change*, not just a single spike. (v193, [07:38]–[08:04])
- **"The current / undertow of the market"**: order flow as a directional undercurrent; experienced traders internalize this; the Flowscalper externalizes it as a signal. (v193, [09:08])
- **Profit-taking bounce trap**: on a downtrend, buying looks bullish but it is just short-covering. "Once those people cover their shorts there's no more buying and the market just keeps dropping." Trade Entry Signal helps stay out of these false-bullish signals. (v193, [37:21]–[37:48])
- **Contango / commercial participant story**: physically-settled commodity markets have a different order-flow character because commercial (non-retail) money dominates. "When they come in they can come in quite strong." Retail-heavy markets (micros, e-minis) have more back-and-forth noise. (v193, [27:39]–[28:49])
- **"Tight markets" psychology**: in markets trading sideways at bid/ask (1-tick range), there is still sub-surface order flow. Tight Markets filter surfaces it; disabling it throws that activity out. Most relevant in overnight session (5 PM – 6 AM CT). (v193, [29:23]–[31:03])

---

## D. Exhaustion clues

— nothing specifically labeled "exhaustion" in this chunk (Flowscalper aggregates multiple signals; it does not expose individual exhaustion conditions in this training context) —

---

## E. Absorption clues

- **Zone mode as absorption tracker**: when a bullish/bearish zone is drawn and price re-enters it, the trader looks at whether current order flow is still directional or has turned. A confirming signal inside the zone = absorption still active; opposite signal = exit/re-evaluate. (v193, [48:13]–[48:39]; v194, [09:15]–[09:38])
- **Short-covering vs. genuine demand**: in a downtrend, seeing some bullish order flow in zones is *not* absorption of supply — it is short-covering. "Maybe it's just short covering right." He stays short. Once the bounce fades and flow turns bearish again, bias is confirmed. (v194, [09:38])

---

## F. Stacked imbalance ideas

— nothing in this chunk —

---

## G. Delta / delta-divergence ideas

- **Flowscalper is NOT a single-delta signal**: it synthesizes delta, imbalances, volume, and POC. Distinguishes it from the Delta Scalper and Pulse, which focus on specific single order-flow features. (v193, [07:05]; [17:17]) [REPEATED]
- Delta is one of several inputs to the composite score; it is not discussed in isolation in this chunk.

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Trade Entry Signal as "failed follow-through" filter**: if signal conditions are met on bar close but no follow-through occurs in next 2 bars / 2 ticks, the signal never prints. Implicitly, this filters out false breakouts and dead-cat bounces. (v193, [35:15]–[36:14]) [SPECULATIVE inference from mechanism]
- **"Market not going anywhere" = get out early**: on a 5-minute chart, if you are in a trade and after 3–4 bars the market just goes sideways, "rather than let the market stop you out…you gotta earn your money as a Trader." He reads order flow intrabar to exit before stop. (v193, [1:11:13]–[1:11:42])

---

## I. Trapped-trader ideas

- **Profit-taking trap (short-covering)**: described above in Section C. Traders who cover shorts look bullish on footprint but have no follow-through. If a buy signal in a downtrend disappears because flow turns bearish in the same bar, that is the trap firing. (v193, [37:21]–[37:48])
- No specific trapped-trader setup language beyond the above in this chunk.

---

## J. Entry triggers (the exact "go" event)

- **Without Trade Entry Signal**: signal fires on signal bar the moment conditions are met; can disappear before bar close; final state printed on bar close is the trigger. (v193, [44:15]; v194, [13:53])
- **With Trade Entry Signal (preferred setting)**: triangle prints on a *subsequent* bar after signal bar close, once the market has moved ≥2 ticks in the signal direction within the next 2 bars. That print = entry trigger. "The follow-up order flow confirms it." (v193, [43:21]–[43:49]) [REPEATED]
- **Settings for Trade Entry Signal**: default and preferred = **2 ticks, 2 bars** ("22"). Range-based charts: min 2 ticks (avoid 1-tick due to 1-tick reversals). Volatile markets (NASDAQ, March 2020): can go to 3 or even 5 ticks. Max he has tested = 5. (v193, [35:15]; v194, [24:26]–[25:25])
- **Intrabar provisional signals**: if NOT using trade entry signal, signal can appear intrabar mid-bar and disappear. "Some people get lost in that — you don't necessarily want to jump the gun." Wait for bar close. (v193, [45:37]–[46:36])

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **Continued directional order flow in next bars**: if long, the tool should continue showing bullish signals/zones. "As long as this order flow was bearish on the way down I can stay in the trade." (v193, [14:52]–[15:18])
- **Zone persistence**: if zones are drawn and price is trading inside a bullish zone with no opposite signal, that is confirmation to hold. "Still bullish…still bullish…still bullish." (v194, [06:44]–[07:10]) [REPEATED across both videos]
- **"Works immediately"** implicit: Trade Entry Signal's 2-bar/2-tick rule enforces near-immediate move. If the market doesn't move 2 ticks in 2 bars, no entry — the setup is invalid for this timeframe. (v193, [35:15])

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Opposite signal while in trade**: if short and a bullish Buy Signal fires with confirming follow-through, "that's where I got to pay attention to the market." If a bullish zone AND a bullish entry triangle appear → must exit/reconsider. (v194, [09:15]–[09:38])
- **Trade Entry Signal never triggers**: if conditions were met on signal bar but market does not move 2 ticks in 2 bars → signal never printed → trade was not taken. (v193, [35:43]–[36:14])
- **Order flow flip mid-bar**: if using momentum mode (no trade entry signal), signal can fire and then disappear by bar close. Disappearance = invalid. (v193, [46:06]–[46:36])
- **10-minute time stop** (implied from product Q&A): he mentions cutting trades when market goes nowhere after a few bars rather than waiting for full stop. (v193, [1:10:48]–[1:11:42]) — consistent with known ~10-min time stop from digest.

---

## M. Stop / risk / target / trade management

- **Stop = ATM stop; always use one**: "you've got to use an ATM period whether you're trading manually or auto." (v194, [32:11])
- **E-minis ATM default**: ~4 points on each side (stop and take-profit set as 16 ticks = 4 points). He then adjusts manually based on order flow reading. (v194, [33:17]–[33:52])
- **Trade management by order flow**: once in, he reads footprint and zones to manage. "If I see the market going nowhere then I'll move my stop up or maybe move my take profit down or just get out." Does not "set and forget." (v194, [33:52])
- **Zones for stay-in decisions**: continuing bearish zones = stay short; continuing bullish zones = stay long. "I know the order flow is still bearish OK so I can stay in." (v193, [15:18])
- **Exit on opposite signal**: if short and gets bullish confirmation signal → start planning exit or tighten stop. Not an automatic exit but a "pay attention" trigger. (v194, [09:15])
- **Order flow confirming continuation is the exit trigger**: when order flow finally turns, not an arbitrary time/target exit. (v193, [14:52]; v194, [07:10])

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Session hours — currencies**: "with currencies I don't really get involved after 2:00 [PM CT]. Most contracts except e-minis and micros you can trade up to 3:00 but a lot of these markets liquidity really dries up after 2 o'clock — the old floor hours." (v194, [03:28]) [ONCE] — REFINES/NARROWS known filter of 07:00–15:00 CT with a currency-specific 14:00 cutoff.
- **Overnight/evening session is viable**: "Don't discount the evening sessions. A lot of people discount them. There's some great movements in the evening sessions. Almost — I'll say almost — better than the day session." Most 2020 new highs/lows made in night session. Evening session = ~17:00 CT reopen to ~06:00 CT. (v193, [1:13:33]–[1:14:06]) [REPEATED]
- **Asian session (tight markets mode)**: overnight 17:00–06:00 CT. Tight Markets filter recommended. Without it, sideways flat-line activity is thrown out. (v193, [29:58]–[31:03])
- **End-of-year avoidance**: "Now is not a time to be trading [end of December]. Markets are going to be choppy, going to be volatile." (v194, [59:22]–[59:55]) [ONCE]
- **FED announcement days**: big exogenous move during FOMC; example shown where bunds made a massive push. (v194, [07:10]) — consistent with known news-avoidance filter.
- **Volatile markets → swing filter required**: NASDAQ, NQ, DAX, Silver = "cardiac markets." Use swing filter of 5 (5-period). Without it, produces too many noise signals. (v193, [1:01:06]; v194, [20:31])
- **Stable/trending markets → swing filter optional/off**: Ultra Bonds, 10yr, bunds, KL (Malaysia), palm oil. These markets "trend nicely" and momentum signals are valid without swing filtering. (v193, [1:06:19]–[1:07:27])
- **Longer time frames (5-min+) → swing filter OFF**: "On a 5-minute chart you may want to see more signals due to momentum as well as reversal, so I would remove the swing filter on longer time frame charts." (v194, [08:11]) [ONCE]
- **Order flow utility degrades beyond 5–10 min**: "When you start going out on longer time frames on order flow you're giving up a lot of the utility…if the first minute is very bullish but you're on a 5-minute bar it just closes sideways you're not taking advantage of that order flow." Max useful = 5–15 min timeframe. (v193, [1:09:42]–[1:10:16]) [ONCE — REFINES known model]
- **Range-based charts**: use swing filter even at low settings (period 1+) due to 1-tick reversals. Not recommended with 1-tick trade entry signal on range bars. (v193, [42:59]; v194, [07:36]–[08:11])
- **Market instrument selection**: physically-settled / commodity markets with commercial dominance (grains, palm oil, Ultra Bond, bunds) = cleaner, stronger moves; enable Contango mode. Retail-heavy cash-settled (e-minis, micros) = more noise; Contango at lower setting or off. (v193, [26:57]–[28:49])
- **Lumber = avoid**: too thin, controlled by few participants, not enough order flow even on 5-minute. (v194, [27:31]–[28:08]) [ONCE]
- **Forex spot data = inferior**: "Forex data is kind of crap, comes from everywhere." Use CME Futures (6B, 6E, 6J) for order flow; execute on Forex spot if preferred. (v194, [40:03])
- **Minimum bar volume filter**: thin/overnight markets should use ≥10 contracts minimum bar volume to suppress noise signals. US major contracts during day session: not needed. (v193, [22:12]–[23:46])

---

## O. Directly testable / measurable variables

- **Flow Strength setting**: scale 1–10. 1 = bare minimum (lots of signals, scalping only), 2 = weak starting point, 3 = mid-average, 4–5 = average (recommended starting point), 7 = pretty strong, 10 = strongest (may produce zero signals on liquid markets like e-minis). (v193, [24:14]–[25:49])
- **Swing Period**: 0 (disabled), 1, 5, 10 (rarely), 25 (very volatile). He uses 0 or 5 most often; rarely beyond 10. (v193, [21:41]–[22:12])
- **Contango Strength**: same 1–10 scale as normal flow strength. For most commodity/physical markets: set to 1 as starting point; does not need to match normal flow strength. (v193, [40:27]–[41:01]; v194, [21:27])
- **Trade Entry Signal ticks**: default = 2; range = 1–5. Use 2 for most markets. Slower markets (treasuries): can use 1. Volatile markets: 3–5. Max = 5. Do NOT set above 5. (v193, [42:59]; v194, [24:26]–[25:25]) NEEDS-OPERATIONALIZATION for "what is volatile enough to use 3 vs 5."
- **Trade Entry Signal bars**: default = 2; range = 1–5. Must move within next 2 bars. Max he tested = 5 (during March 2020 extreme volatility). (v193, [43:21]; v194, [24:59]–[25:25])
- **Minimum Bar Volume**: default 0 (no filter); recommended ≥10 for thin/overnight markets; up to 50–100 for very thin. US major day-session = not needed. (v193, [22:49]–[23:46])
- **Swing filter ON vs. OFF**: binary. Off = momentum mode. On = reversal/swing mode. (v193, [16:15]–[16:46])
- **Tight Markets ON vs. OFF**: binary. ON = include flat-range sessions. OFF = exclude sideways/tight-market activity. Recommended ON for overnight analysis. (v193, [29:23]–[31:03])
- **Zone width in bars**: 0 = off; 5 = short; 25–50 = long (for pullback/re-entry use). (v193, [38:26]–[38:56])
- **Signal box opacity**: 25 (default = light). (v193, [38:26])
- **Sound alert re-arm**: 30 seconds between alerts. (v193, [33:04])
- **E-minis ATM stop/target**: 4 points / 16 ticks each side as starting ATM. Adjusted manually from there. (v194, [33:17]–[33:52]) NEEDS-OPERATIONALIZATION for other markets.
- **NinjaTrader tick replay**: required for historical signal display. Must enable: Tools → Options → Market Data → Tick Replay. (v193, [04:57]; v194, [12:19]–[12:46])
- **Currency session cutoff**: 14:00 CT (v194, [03:28])

**Market-specific recommended starting settings (0/5/1 notation = swing filter period / flow strength / contango strength):**
- E-minis, Micro E-minis (calm): 0-5-1 (swing filter off) [ONCE]
- NASDAQ, NQ, DAX, Silver (volatile): 5-5-1 (swing filter=5) [ONCE]
- Gold: either 0-5-1 or 5-5-1 depending on conditions [ONCE]
- Ultra Bonds, 10yr, Bunds (momentum markets): 0-5-1, no swing filter [ONCE]
- Crude oil, Nat gas: start at 0-5-1 [ONCE]
- KL (Malaysia): swing filter off, volume filter 10, flow strength 5, contango off [ONCE]
- Currencies (6E, 6B): swing filter optional, contango OFF [ONCE]

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **Flowscalper is a composite multi-factor indicator**: internally combines delta, imbalances, POC, and volume into a single directional score. Does NOT expose individual sub-signals. (v193, [07:05]–[08:43])
- **Signal fires intrabar (provisional) vs. on bar close (final)**: provisional signal can appear/disappear while bar is open; final signal on bar close = permanent, never repaints. This is the non-repaint guarantee. (v193, [44:15]–[44:40]; v194, [13:53]–[15:20])
- **Trade Entry Signal generates the entry triangle on a SUBSEQUENT bar** (not signal bar): once printed, never repaints even if price immediately reverses. (v193, [43:21]–[43:49]; v194, [14:52]–[15:20])
- **Signals exposed as chart markers (plot series)**: readable by external automation software (NinjaTrader Markers, BloodHound-compatible). Not directly accessible via NT strategy API without custom work. (v194, [15:59]–[16:32])
- **Works on all NT8 chart types**: minute, range, tick, volume, Heikin-Ashi (tested), not Renko (tick replay incompatible). (v193, [05:24]–[06:33])
- **Tick replay required**: historical signals require NT8 tick replay enabled (Tools → Options → Market Data). (v193, [04:57]; v194, [12:19]–[12:46])
- **Signal box / zone rendering**: drawn from signal bar; width in bars = configurable. Signal box height in ticks = configurable. Opacity = configurable. These are purely visual; automation software ignores zones, reads only up/down triangles. (v193, [37:48]–[38:56])
- **Per-instrument parameter sets**: the indicator supports storing different settings per market via NinjaTrader's standard properties mechanism. No built-in multi-instrument auto-detection. (v193, [02:03]; [48:39]–[49:39])
- **Licensing**: token-based, machine-ID locked. One license = one NT machine ID. Multi-machine = multiple licenses. (v194, [41:19])
- **"Signals stay up all day"**: signals are persistent once printed; not session-reinitialized during the trading day. (v194, [21:54])
- **Auto-trade integration**: signals can drive automated entries via NinjaTrader Markers (entry automation + daily loss/profit stops). Mike uses: Markers for entry, then manages manually by reading order flow. (v194, [10:44]–[11:07]; [32:11])
- **Implication for A+ reversal indicator**: the Flowscalper's internal composite logic (delta + imbalances + POC + volume weighted into a directional score, filtered by swing high/low detection) is a relevant architecture model. The "swing filter" logic — detecting if current bar is at a swing extreme — is the location-filter that converts a momentum signal into a reversal signal. (v193, [16:15]–[17:17]) [SPECULATIVE]

---

## Q. Notable verbatim quotes

1. "Where the flow scalper differs is it picks up the **change** in the order flow…it doesn't just concentrate on delta or imbalances or point of control or volume — it uses all those different pieces of information and it's measuring where the change is occurring in the market." (v193, [07:05]–[08:04])

2. "Big traders, they don't necessarily want to just all jump in and pile into the market — they want to finesse the market, finesse their order without necessarily moving the market. And when you have several big traders or companies doing that sort of at the same time, it will show up in the order flow." (v193, [07:38])

3. "The hardest part of trading with order flow is putting the pieces together…there's a lot of indicators out there based on order flow but they're really looking at sort of one little piece of information. They're not really taking into account everything that's happening together." (v193, [09:08]–[09:34])

4. "The order flow is constant — keeps moving bullish bearish bullish bearish. What you want is bullish bullish bullish bullish. And that's where the trade entry signal is going to help." (v193, [35:43])

5. "What was bullish all of a sudden is bearish — so you're not going to get that move you want because all of a sudden there's a big bearish order flow coming into the market." [On why trade entry signal prevents false entries] (v193, [36:14]–[36:49])

6. "When you're doing auto trading sometimes you don't want to see so many signals. But when I'm in a trade right, I want to know: do I want to be cutting it or is this about as far as this market's going to move? If I'm in a trade and I see red down — down — down — I know the order flow is still bearish. I can stay in." (v193, [14:52]–[15:18])

7. "The flow scalper was created to help traders see that current — see that change in the market." (v193, [09:34])

8. "When you start going out on longer time frames on order flow you're really giving up a lot of the utility of the order flow…if you're on a 5-minute bar and the first three minutes are very bullish but the bar just closes sideways you're not taking advantage of that order flow." (v193, [1:09:42])

9. "Don't discount the evening sessions. A lot of people discount them. There's some great movements — it's almost — I'll say almost — better than the day session." (v193, [1:13:33])

10. "Death by a Thousand Cuts on choppy days." (v194, [36:54])

---

## R. Contradictions / nuances

- **Contango for e-minis: contradictory guidance within this chunk**: at v193 [26:57] he implies Contango is mainly for physical/commodity markets. But at v194 [21:00] he says "you don't necessarily need it in the e-minis but I find it gives you a few extra signals…so yeah I would use Contango in e-minis but I'd set it at 1." This is a within-chunk nuance: Contango IS used on e-minis but at minimum strength (1), not the same strength as normal flow. [ONCE]
- **Swing filter on 5-minute charts: contradicts shorter-timeframe guidance**: for 1-minute charts, swing filter is optional (on for volatile, off for stable). But for 5-minute charts, he explicitly recommends REMOVING the swing filter ("I would remove the swing filter on longer time frame charts" — v194, [08:11]). Rationale: on longer bars, you already have a built-in "swing" by the nature of the bar, so extra filtering is not needed. [ONCE]
- **"Same settings every market" vs. per-market adjustments**: in some contexts he says the tool "works on every market with the same settings." In this webinar he gives distinct starting settings for 7+ market categories. Resolution: the architecture/rationale is the same; the specific numeric parameters differ by market volatility and participant structure. The "same settings" claim applies to the logic, not the parameters. (v193, [02:03]; [49:12]–[49:39]) — CONSISTENT with known digest nuance ("same settings every market" applies to detector only).
- **Order flow utility on time frames**: "going out beyond 5–10 minutes is a bit of a stretch" on order flow — yet he shows 5-minute charts as workable. Resolution: 1-minute is optimal; 5-minute is the practical upper bound; 15-minute is marginal. (v193, [1:09:42]–[1:10:16]) [ONCE]
- **"Works immediately" vs. 2-bar trade entry confirmation**: the foundational A+ model says setup "works immediately." The Flowscalper's trade entry signal explicitly gives 2 bars for follow-through. Resolution: the 2-bar window IS the "immediately" operationalization — it is the mechanical definition of "works immediately." (v193, [35:15]–[36:14]) [SPECULATIVE] — CONSISTENT with known "1–3 bars" follow-through window.
- **"React, don't predict" vs. Flowscalper anticipation**: the digest spine is "react, don't predict." But the Flowscalper picks up early, subtle shifts ("before it sells off it's telling me the order flow has turned bearish"). Resolution: it still reacts to measurable order flow data, not to price prediction; the "anticipation" is reaction to micro-structure shift, not prediction. (v193, [10:12]) [SPECULATIVE]

---

## Coverage note

v193 (Flowscalper Training Part 1) is rich on indicator architecture, settings rationale, and philosophical model elements (multi-factor composite, "change in flow" detection, follow-through confirmation). v194 (Part 2) is thin on new model content — primarily Q&A, installation instructions, and per-market chart examples that reiterate Part 1 settings. Both videos are product-focused (sales/training webinar), so reversal model theory is embedded in product explanation rather than stated directly. The deepest model content is at v193 [07:05]–[36:14] and [1:09:42]–[1:14:06].
