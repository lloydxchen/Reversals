# Chunk 007 Extraction
- Source chunk: Chunk_007_Orderflows_Transcripts.md
- Transcripts covered:
  - v221 — "Part 2 Flowsbounce Workshop: Volume Profile Combined With Order Flow" (2021-09-24)
  - v244 — "Order Flow Analysis: Inverse Imbalances How To Trade Them With NinjaTrader 8" (2022-04-07)
  - v261 — "Stacked Imbalances In The Order Flow: Find Low Risk Trades" (2022-09-03)
  - v262 — "Market Imbalances In The Order Flow: How To Analyze Order Flow Strategies" (2022-09-05)
  - v269 — "Absorption In The Order Flow On Moves Up: How To See It In The Delta And Imbalances" (2022-09-12)
  - v272 — "Stopping Volume In Order Flow: Use POC To Create A Trading Strategy" (2022-09-17)
  - v277 — "Stopping Volume In The Order Flow: How To See It How To Trade It" (2022-09-24)
  - v280 — "How To Recognize Trapped Traders And The Different Types Of Traps In Order Flow" (2022-09-27)
- Overall content value: **rich** (v244/v261/v262/v269/v272/v277/v280 are all directly on the reversal/exhaustion/absorption/trap model with concrete, repeated rules; v221 is mostly a Q&A indicator-settings walkthrough but contains several reusable risk/management rules)

> NOTE: This is a dense T1 chunk. The 2022 cluster (v244, v261, v262, v269, v272, v277, v280) is effectively Mike's reversal-model curriculum stated bar-by-bar: inverse imbalances (trapped aggressors), stacked-imbalance memory levels, absorption (negative delta on up bars), stopping volume / point-of-control on the extreme, and two distinct trap mechanisms. The single most repeated A+ gate across the whole chunk is **"aggressive activity with NO follow-through → fade it."** No explicit letter grade "A+" appears; the tiering is carried by "nice / beautiful / perfect / great level / textbook-style" praise vs. "went sideways on you / nothing special / I'd like it stronger."

---

## A. Setup types & names he uses
- **Inverse imbalance reversal** — a stacked imbalance "with a twist": a **bullish inverse imbalance = stacked SELLING imbalance in an UP bar**; a **bearish inverse imbalance = stacked BUYING imbalance in a DOWN bar** (v244, "Inverse Imbalances", [01:04]–[01:37]). "Generally a sign of traders that are getting trapped… aggressive traders selling into strong passive bids or buying from strong passive offers" (v244, [01:37]–[02:10]). [REPEATED in v244]
- **Stacked imbalance memory-level reversal** — three or more imbalances stacked neatly on successive prices; mark the level; when price returns it "can give you a good opportunity to either get long or get short" because "markets have memory… liquidity has memory" (v261, "Stacked Imbalances", [00:59]–[01:29]). [REPEATED]
- **Absorption reversal / continuation on a move** — supportive buying on moves up (negative delta on green bars) or resistant selling on moves down; the "extra confirmation that the move has strength" (v269, "Absorption", [01:20]–[02:28]). Bullish/bearish per move direction. [REPEATED in v269]
- **Stopping-volume reversal** — "volume that appears in the order flow that essentially stops moves… and often causes a reversal" (v272, "Stopping Volume", [00:00]–[00:31]). [REPEATED across v272 & v277]
- **Point of control on the extreme** — a red bar with POC at the very TOP (bearish reversal) or a green bar with POC at the very BOTTOM (bullish reversal) (v272, [01:04]–[01:31]). [REPEATED]
- **Prominent Point of Control reversal** — POCs "that matter" at swing highs/lows; "potential Market turning points" (v272, [04:26]–[04:55]). Bullish at swing low, bearish at swing high. [REPEATED in v272]
- **Trapped-trader reversal — two types:** (1) trap caused by **stops getting triggered**; (2) trap caused by **liquidity (a big limit absorbing aggressors)** — "the way you trade it is the same but the way you would look at it is slightly different" (v280, "Trapped Traders", [00:00]–[00:27]). [REPEATED in v280]
- **Flowsbounce / trade-entry-signal setup (indicator)** — blue triangle = buy signal, red triangle = sell signal; "trade entry signal" only prints once follow-through order flow confirms in the next 1–2 bars (v221, [03:40]–[19:47]). Tool-specific, not a discretionary pattern.

## B. Tiering / grading language  ← HIGH PRIORITY
- **"beautiful level"** — top praise for a stacked-imbalance level that holds on the retest and launches: "look at this beautiful level right here… came right down to the level… 88 20 to 25 and a nice move up" (v261, [08:42]). [ONCE, strong]
- **"perfectly" / "held it perfectly then rallied 20 points is… not normal"** — he flags the cleanest example AND immediately warns it is not typical: "to see trades like this work out where it came right down to 74 held it perfectly then rallied 20 points is not normal" (v261, [04:51]–[05:19]). KEY: he explicitly tiers the textbook example as *abnormal*. [ONCE]
- **"nice" / "nice move" / "nice stacked imbalance" / "nice strong delta"** — recurring praise for clean prints that reverse promptly (v244 [02:10]; v261 [02:23]; v269 [04:36]; v277 [09:56]). [REPEATED]
- **"this is what stopping volume looks like" / "that's what price defense really looks like"** — used as the canonical/textbook exemplar of the pattern (v277, [09:56]–[10:29]). [ONCE, exemplar]
- **"these are the ones that are really getting trapped"** — the *better* trap example (liquidity/absorption trap, ~2,500 contracts can't get through) is graded above the stop-triggered trap: "this afternoon there's a much better example here" (v280, [07:19]–[08:57]). KEY TIER CRITERION: absorption traps (real trapped longs who must puke) > stop-out "traps" (those traders are already out). [REPEATED in v280]
- **What moves a setup DOWN a tier:**
  - **Small/weak delta or volume** behind the imbalance: "I'd like it to be a little bit stronger… maybe this is a big order somebody sold 25 contracts, okay nothing happened" (v262, [09:34]–[10:05]); "the volumes aren't that strong honestly it's just 137… 160" (v277, [13:06]). NEEDS-OPERATIONALIZATION.
  - **One lone imbalance** vs. stacked / shifting context: "it's nothing to get excited about just one buying imbalance that's nothing two against 12 that's not big volume" (v262, [08:37]); "don't just take it in isolation" (v262, [17:28]). [REPEATED]
  - **Counter-trade present right before the signal:** "I would have it look a lot nicer if it didn't have that little aggressive selling before it came around" / "the only spanner in the works is this bar here… the two selling imbalances" (v262, [15:35]–[16:06]). [REPEATED]
  - **Wrong candle color:** "normally I'd prefer this to be a red candle… you can only trade what the market is giving you" (v277, [05:27]); "I'd prefer to look at stacked imbalances during the U.S. sessions" (v261, [05:19]). [REPEATED]
  - **Stack imbalance that FAILED:** "here's a stack selling imbalance this one failed it just kept going up… not all trades work out" (v261, [03:27]–[03:57]). [ONCE]
- **Disqualified / fade-it outright:** stacked BUYING imbalance at new highs with **zero follow-through** → he goes SHORT against it, explicitly contradicting "another company selling software that basically just buys stacked buying imbalances" (v280, [04:13]–[04:43]). [REPEATED in v280]
- He repeatedly disclaims perfection-seeking: "if you're searching for perfection you'll never find it"; "there's no holy grail… the holy grail in trading is really consistency" (v221, [45:22]–[46:53]). [REPEATED]

## C. Order-flow story & psychology per setup
- **Inverse imbalance = trapped aggressors:** aggressive sellers hit strong passive bids (or aggressive buyers lift strong passive offers) and get caught offside; the move "snaps back" because "these prices down here are rejected and the market immediately comes back" (v244, [01:37]–[03:51]). [REPEATED]
- **Trapped-trader covering is a SHORT-LIVED fuel source:** a small trapped cohort (e.g., "70 28… about 175 contracts") has "plenty of time… to be covered… it's not like this little amount of trapped traders is going to cause this 10-point rally" (v244, [02:42]–[03:18]). The reversal "is going to be shorter than you think… shorter Trends" (v280, [10:22]–[10:57]). [REPEATED]
- **Two trap mechanisms, different psychology:**
  - *Stop-triggered "trap"*: a buy-stop sweep at the high is usually a stop **protecting a short** getting blown out — "that person's out… they're not trapped… they're smiling all the way to the bank, they sold literally the highs of the day" (v280, [09:25]–[09:50]). NOT a true trap; but "leaves a footprint that would look like trap Traders" (v280, [03:46]).
  - *Liquidity/absorption trap*: aggressive buyers keep hitting a big resting limit offer; "These Guys these are the ones that are really getting trapped because they're being absorbed by a big limit offer" — these are the longs who must eventually "puke out" and add downside pressure (v280, [07:19]–[09:25]). [REPEATED]
- **Absorption story (execution algos):** banks' execution algos "are smart enough… not just going to go in and start lifting every single offer"; they rest bids to accumulate "without moving the market… but it shows up in the footprint" as negative delta on up bars (v269, [05:10]–[06:07]). [ONCE, very concrete]
- **Stopping volume / POC-on-extreme story:** heavy resting offers at the high "absorbing the buying that's going on" → price defense; a red bar with POC at top means "selling is coming in late in the bar" (v272, [07:34]–[08:09]; v277, [10:29]). [REPEATED]
- **Strongest-confluence reversal:** an area where there was strong aggressive **selling earlier** and now strong aggressive **buying** appears at that SAME level (or vice-versa) — "that's an important clue, those are good trades to take" (v262, [13:14]–[13:46]). [REPEATED — this is his clearest "A+" stacked-context rule]
- **Fair/unfair & memory:** "markets have memory… liquidity has memory" — order-flow levels are real because they are "generated by what's actually trading… not based off some mathematical calculation" (v261, [00:59], [06:15]). [REPEATED]

## D. Exhaustion clues
- **Aggressive activity with NO follow-through** = the central exhaustion/fade signal: "strong aggressive buying it needs to be followed through; if it's not followed through it's probably not as strong as you think" (v280, [11:25]–[11:54]); "500 contracts of aggressive buying and Market can't move higher, what's the trade? to the short side" (v280, [04:13]). [REPEATED — most important in chunk]
- **Delta sign-flip bar-to-bar at an extreme:** went "from a bar that was very bullish… Max Delta 2122, Min Delta zero, then the next bar Max Delta zero… final Delta minus 676" — i.e., net aggressive buyer vanishes and aggressive seller appears (v280, [05:46]–[06:19]). [ONCE, very concrete]
- **Inside bars after a big directional bar** = potential move-over: "four inside bars of this big bar down… after the first bar… that's a sign that potentially the move is over" (v262, [07:31]–[08:09]); "big dark bar down and you went inside inside and just sort of went sideways" (v262, [08:09]). [REPEATED]
- **Market can't make the next tick / goes "inside" not "sideways":** rallied to the open at 29 "only gets up to 28 and three quarters and just goes inside on you" → more selling came in (v262, [03:39]–[04:04]). [REPEATED]
- **High "order flow ratio" number = price exhaustion** (vs. low ratio = stopping volume): "if it was a very high number like 58 then [it tells] me it's price exhaustion" (v277, [11:29]–[12:00]). NEEDS-OPERATIONALIZATION (the ratio is his proprietary metric; the 58 is an illustrative value, not a fixed threshold). [ONCE]
- **POC at the top of a red bar / POC poking higher than prior bars then reversing** = exhaustion of the up-probe ("sticking its head up out of its hole… then the market reverses down, closes down near our low") (v272, [07:13]–[07:34]). [REPEATED]

## E. Absorption clues
- **Negative delta on UP (green) bars = supportive passive buying absorbing aggressive selling** (and positive delta on down bars = resistant selling). "Supportive buying on moves up or resistant selling on moves down" (v269, [01:50]–[02:28]). THE core absorption tell. [REPEATED in v269]
- **How to read it on the footprint:** green candle with minus delta → look deeper → big volume on the BID side at a price (e.g., "419 traded on the bid versus 294") = strong passive buyers (v269, [03:31]–[04:00]). Horizontal/at-price delta on the bid side confirms passive bidding (v269, [04:36]–[05:10]). [REPEATED]
- **Small deltas on decent-volume bars = evenly matched / absorption in progress:** "small negative delta so it's telling you the trade is evenly matched… buyers working bids to absorb whatever selling is coming in" (v269, [09:39]–[10:06]); "small deltas… take a look further at what's actually going on… could be a sign of absorption" (v269, [11:03]). [REPEATED]
- **Selling imbalances on GREEN bars during a bounce = absorption** (passive bidders soaking up aggressive sellers as the market lifts) (v269, [09:10]–[09:39]). Overlaps with the inverse-imbalance concept. [ONCE]
- **Stopping volume = absorption at the extreme:** heavy offers at the high "absorbing whatever buying is taking place… the market came off"; the level holds on retest (v277, [06:33]–[08:00]). [REPEATED]
- **Resting/refreshing limit absorbing aggressors:** the liquidity trap — "a big limit offer… someone with Supply… happy to keep my foot on the market" while ~2,300+ contracts trade into it and can't get through (v280, [08:29]–[09:25]). [REPEATED]

## F. Stacked imbalance ideas
- **Definition (stated multiple times):** an imbalance = more aggressive volume on one side by a ratio of usually **4:1** (some use 3:1, 5:1, 6:1, even "9:1 / 987%"); a **stacked imbalance = 3 or more imbalances stacked neatly on successive prices, one right after the other** (v244, [00:32]–[01:04]; v261, [00:27]–[00:59]; v262, [00:28]–[00:55]). "Industry standard if there is one is about 4 to 1." [REPEATED — 4:1 is his stated base]
- **Bullish vs bearish stack:** stacked BUYING imbalances in an up/green candle = bullish; stacked SELLING imbalances in a down/red candle = bearish (v244, [01:04]–[01:37]). [REPEATED]
- **Inverse (the reversal twist):** bullish inverse = stacked SELLING in an UP bar; bearish inverse = stacked BUYING in a DOWN bar → trapped aggressors (v244, [01:04]–[01:37]). [REPEATED]
- **Memory-level use:** mark where the stack occurred; trade the retest — bid just under a bullish stack with a tight stop, or offer at a bearish stack (v261, [02:23]–[03:27]). [REPEATED]
- **Retest behavior — overshoot tolerance:** good levels "overshoot the imbalance by just one tick before again shooting up" / "got past it by just one tick before it sold off" — a one-tick poke through is acceptable, not a failure (v261, [05:45]–[06:45]). NEEDS-OPERATIONALIZATION but the "one tick" is stated concretely. [REPEATED]
- **Context over isolation:** "don't just take it in isolation… is the market shifting from mostly selling imbalances over several bars to buying imbalances over the next several bars" (v262, [17:01]–[17:56]). A regime SHIFT in imbalance polarity is the signal, not a single bar. [REPEATED]
- **Strongest stacked-context A+ rule:** stacked selling earlier + stacked buying NOW at the same level (or reverse) = high-confidence trade (v262, [13:14]–[13:46]). [REPEATED]
- **A stack can fail** (price just blows through and keeps going) — not all stacks hold (v261, [03:27]–[03:57]; v280, [04:43]). [REPEATED]
- **Stacked imbalances appear on any chart type** — tick (50/100/200/233-tick), volume, range, 1-minute — "if there's an inverse imbalance it will appear" (v244, [09:21]–[09:49]). [REPEATED]

## G. Delta / delta-divergence ideas
- **Baseline rule of thumb:** rallies show positive delta (green bars), sell-offs show negative delta (red bars) — "general because it's not always the case" (v269, [00:52]–[01:50]). [REPEATED]
- **Absorption is the EXCEPTION (the high-value read):** green bar + negative delta = passive bid absorption (see E). The exception is the signal (v269, [01:50]–[02:28]). [REPEATED]
- **Delta sign-flip at the extreme** (Max-Delta-positive bar → next bar net aggressive selling) = reversal trigger (v280, [05:46]–[06:19]). [ONCE, concrete]
- **Divergence (new low with positive delta) is necessary but NOT sufficient:** "we got divergence… a new low with positive delta… but the next bar doesn't go any higher just makes a new low… what is the market telling you? it's not ready to rally" (v262, [05:33]–[06:04]). KEY NUANCE: divergence must be confirmed by the market actually pushing the other way. [REPEATED]
- **Zero delta is often meaningless / a coincidence on a time bar:** "people think oh I got zero delta that must mean something, no it's really just a coincidence… a difference of basically one trade that just cut off" (v262, [01:51]–[02:18]). [ONCE — anti-pattern warning]
- **Delta too small to use:** in thin sessions "delta at this point honestly isn't really giving you much… the deltas are just too small" → fall back to imbalance polarity (v262, [11:10]–[11:42]). [REPEATED]
- **Strong negative delta is relative to the session/time-of-day:** "these are strong relative to this time period minus 201 minus 211" (v262, [07:31]); evening volume is "not even a third of the whole day's volume" (v262, [02:47]–[03:12]). Delta/volume thresholds must be normalized by session. [REPEATED]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Stop-run footprint at highs/lows:** a triggered stop "often sweeps right through the market because… it just takes one contract to trigger a stop, the whole order executes as a market order" → leaves a tail/spike that "doesn't even take out that high, then trades sideways" (v280, [02:52]–[03:17]). [REPEATED]
- **Distinguish stop-to-EXIT vs stop-to-ENTER:** a sweep that doesn't follow through is usually a stop protecting an existing position (those traders are now flat, NOT trapped); only a stop-to-enter (FOMO) leaves genuinely trapped traders (v280, [00:57]–[01:27], [03:17]–[03:46]). [REPEATED]
- **Failed push / immediate snap-back = rejection** (inverse-imbalance mechanics): "a quick move down and snaps back… means these prices down here are rejected" → buy the snap-back (v244, [03:18]–[03:51]). [REPEATED]
- **Failed retest of the open** (can't reclaim opening price) → continuation in the prior direction (v262, [03:39]–[04:04]). [ONCE]
- **Five-price-level / five-bar failure rule → flip with the trend:** if a counter-trend buy in a trending market "just fails immediately… within those five bars," that's a sign "don't fight the trend" and he is "willing to get short if it breaks within five points / five bars" (v221, [14:31]–[16:32]). KEY discretionary stop-and-reverse rule (he caveats "not for everybody"). [ONCE, concrete]

## I. Trapped-trader ideas
- **Two types (central thesis of v280):** stop-triggered (footprint only) vs. absorption/liquidity (real trapped longs/shorts). Trade them the same (fade), read them differently (v280, [00:00]–[00:27]). [REPEATED]
- **Who you wait to PUKE:** the absorbed aggressors — "at some point these are the guys you're looking to puke out… they're going to realize the Market's not going any higher and they're going to turn Sellers and get out… add pressure to the market" (v280, [08:57]–[09:25]). [REPEATED]
- **Magnitude expectation:** trapped-trader reversals are SHORTER than people expect — "the reversal is going to be shorter than you think… not an all-day Trend… you can still trade them, Five Points 10 points maybe even more sometimes" (v280, [10:22]–[11:25]). [REPEATED]
- **Trapped-cohort size matters:** small trapped size (~175 contracts) = limited fuel; larger absorbed size (~2,300+ contracts) = the better trade (v244, [02:42]; v280, [08:29]). [REPEATED]
- **Inverse imbalance is the visual signature of trapping** (aggressors caught against passive size) (v244, [01:37]). [REPEATED]

## J. Entry triggers (the exact "go" event)
- **Inverse / stacked imbalance entry — buy-stop above the signal bar:** "wait for this bar to close… drop in a buy stop a couple ticks above the high of the bar before [the imbalance]… let the market take you in"; mirror for shorts (sell stop a couple ticks below the low) (v244, [07:44]–[08:55]). DO NOT just immediately get long off the imbalance — "let the market take you into the trade" (v244, [08:05]–[08:31]). [REPEATED in v244]
- **Stacked-level retest entry:** rest a bid at the stacked-buying level with a stop one tick beyond, let it hold (e.g., "throw in a bid around the 74, a stop at 73") (v261, [02:56]–[03:27]). [REPEATED]
- **Stopping-volume / POC-on-extreme entry:** wait for the bar to close, then go with the next bar as soon as it starts trading in the signal direction — "you don't need to wait for this bar to close… let the market start ticking down… taking out the low of the bar… that's where I'd be looking to get short" (v272, [08:26]–[09:42]); "this is one you can just go with as soon as the bar closes and starts trading down in the next bar" (v277, [11:03]). [REPEATED]
- **No-follow-through fade entry:** when aggressive buying at new highs gets no follow-through and aggressive selling appears, go short (v280, [04:13]–[05:46]). [REPEATED]
- **Flowsbounce trade-entry-signal:** mechanical trigger fires when price moves **two ticks** beyond the signal bar within the next **2 bars** (configurable to 3) — confirms follow-through order flow before signaling (v221, [03:40]–[07:52], [18:35]–[19:47]). [REPEATED] — NOTE: these tick/bar numbers are tied to his proprietary indicator, not a universal rule.

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Immediate follow-through is mandatory:** the move must continue right away; absence of follow-through is itself the disqualifier/reversal trigger (v280, [11:25]–[11:54]). [REPEATED — the dominant theme]
- **Level holds on retest:** stacked level "holding one bar two bars three bars four bars then it rallies" (v261, [02:56]–[03:27]); absorption support "did over the next two bars it pulled back into it a little bit… so I know this support area is holding" (v269, [06:07]–[07:01]). [REPEATED]
- **Quick, clean move after the trigger:** "rallied from 74 all the way up to 94 in about 10 15 minutes"; "a quick five points in five minutes" (v261, [02:56]; v272, [12:10]). [REPEATED] — these are example outcomes, not promised targets.
- **Market starts "ticking" in your direction / takes out the prior bar's extreme** = confirmation to pull the trigger (v272, [08:53]–[09:42]). [REPEATED]
- **POC migrating in your direction / point of controls lining up** = supportive structure (v272, [05:48]–[06:16]; v262, [08:37]–[09:09]). [ONCE]

## L. Invalidation — what should NOT happen / what kills the thesis
- **No follow-through after aggressive activity → thesis dead / flip:** "if I don't get that follow through the trade for me is to the short side" (v280, [01:27]–[01:54]). [REPEATED]
- **Goes "sideways on you" / "inside on you":** repeated invalidation phrase — "just went sideways on you… as a trader you got to decide is this market paying me or is it just going sideways" (v262, [05:45]–[06:15]; v261, [05:19]–[07:14]). [REPEATED]
- **Price trades back THROUGH the heavy/stopping volume → exit:** "if it trades back up above 64 and a half here… my whole idea of being short is violated, I don't want to be short anymore" (v272, [09:42]); "if the Market's going to get past any heavy volume up here I don't want to be short anymore" (v272, [08:53]–[09:17]). [REPEATED]
- **POC/level gets violated → it's "no longer bearish/bullish":** "we traded up through it, it's violated… the whole reason for it being bearish is gone" (v272, [06:43]–[07:13]). [REPEATED]
- **Stacked level fails (blows through and keeps going):** accept it and wait for the next trade (v261, [03:27]–[03:57], [07:42]). [REPEATED]
- **Five-bar failure of a counter-trend entry** = thesis wrong; he may flip with the trend (v221, [14:57]–[16:32]). [ONCE]
- **A trade not working within ~5 price levels / 5 bars** → get out; "if trade is not working out for me within five price levels it's going to fail, period" (v221, [13:55]–[14:57]). [REPEATED in v221]

## M. Stop / risk / target / trade management
- **Stop placement — behind a level the market must work through:** "place your stop behind a level that the market's gotta work to get through… if it gets through that bearish order flow then that's my sign to be getting out" (v221, [31:54]–[32:28]). [REPEATED]
- **Stop just beyond the signal bar's extreme:** short with stop "just above the high of this bar because the point of control is up near the top" / above the stacked buying imbalance (v272, [08:53]–[09:17]; v280, [04:13]); "stop just above 3700" (v277, [13:06]). [REPEATED]
- **Tight risk on retest fades:** "you're just risking two or three ticks" (v272, [11:09]–[11:40]); stacked level "stop at 73" (one tick) (v261, [02:56]). [REPEATED]
- **Targets are modest / scalp-sized:** "I'd been happy to just get five points out of this move" (v277, [13:06]); "a quick five points," "20 points… not normal" (v261, [03:27]–[05:19]). Trapped reversals = "Five Points 10 points maybe even more" (v280, [10:57]). [REPEATED]
- **Five-price-level / five-bar zone as a management tool:** he draws zones 5 price levels × 5 bars; failure within the zone = exit or reverse (v221, [13:55]–[16:32]). [REPEATED in v221]
- **Adjust ATM stops manually:** "the ATM will just throw it in there for you and then I just manually adjust it… there's no law that says you can't adjust your order once it goes in" (v221, [32:28]–[33:02]). [ONCE]
- **Scaling in via micros:** micro contracts let small traders scale in vs. trading a single e-mini lot (v221, [23:47]–[24:28]). [ONCE]
- **Don't over-optimize / curve-fit:** want "a set of parameters you can work around" not a single best value; "the holy grail is consistency" (v221, [42:34]–[46:53]). [REPEATED]

## N. Context filters (session/time, regime/volatility, levels)
- **Prefer U.S. session for imbalances** (more volume); overnight/evening volume is "not even a third of the whole day's volume" so deltas/volumes must be judged relative to session (v261, [05:19]; v262, [02:47]–[03:12]). [REPEATED]
- **Number/news times create the best memory levels:** non-farm payrolls (after 7:30), FOMC, inventory numbers print big stacked imbalances and durable levels — "right around that number time… non-farm payrolls just after 7:30" (v261, [02:23]–[02:56], [08:42]); but he says you're "probably not going to be trading FOMC announcement" itself (v244, [04:54]–[05:27]). [REPEATED]
- **Liquidity slows ~2:00 pm Chicago and ~11pm–1am;** European session (from ~1am Chicago) and Asian session revive specific markets (gold/yen/Aussie/Nikkei) (v221, [09:12]–[12:11]). E-mini European-session volume "is better than some markets trade during US normal hours" (v221, [30:32]–[31:13]). [REPEATED]
- **Opening price as a reference/target level** (e.g., 38.29, 36.68) — acts as resistance/support; reclaiming it is a confirmation/target (v262, [03:12]–[03:39], [13:46]; v280, [07:19]). [REPEATED]
- **Psychological round numbers** (3700 "37 Double O") attract stopping volume / price defense (v277, [09:56]–[10:29]). [ONCE]
- **Prior highs/lows of day = where heavy volume legitimately sits** ("you sell resistance, you buy support"); the high-value tell is heavy volume **away from** expected support/resistance — "when that appears then there's probably something else behind it" (v277, [01:53]–[02:49]). [REPEATED]
- **Volatility regime changes the tools:** modern (2022) markets are "much more volatile," so POC-on-the-extreme is now "very rare" on the e-mini → use Prominent POCs / top-two POCs instead; bonds & rate/commodity markets still show POC-on-extreme (v272, [00:31]–[01:31], [03:57]–[05:22]). [REPEATED]
- **Chart-type/speed must match the market:** range bars move "very far very quickly"; "I would not use a four range chart on the e-minis anymore… moves too quickly"; a 4-range in wheat ≠ a 4-range in 5-years (v221, [27:13]–[30:32], [42:03]–[42:34]). [REPEATED in v221]
- **Order-flow info has a short shelf life:** "after 10 minutes you're really discounting the value of the order flow… even five minutes prior"; use it "as soon as it becomes available" (v221, [07:52]–[08:34]; v261, [09:43]–[10:09]). [REPEATED] — BUT contrast with "markets have memory" levels that work later (see R).
- **Crypto ↔ equities correlation** as a weekend tell for Sunday-open direction (v277, [00:56]–[01:24], [15:43]). [ONCE]

## O. Directly testable / measurable variables
- **Imbalance ratio = 4:1** (his stated default/base; alternatives 3:1, 5:1, 6:1, 9:1 are user choices) (v244 [00:32]; v261 [00:27]; v262 [00:28]). TESTABLE — exact.
- **Stacked imbalance = ≥3 imbalances on consecutive price levels** (v244 [01:04]; v261 [00:59]). TESTABLE — exact (note v8 in other chunks allowed min=2; here he says "three or more").
- **Inverse imbalance = stacked imbalance whose polarity opposes the bar's color** (selling stack in up bar = bullish; buying stack in down bar = bearish) (v244 [01:04]–[01:37]). TESTABLE — exact logical condition.
- **Retest overshoot tolerance ≈ 1 tick** before the level should hold (v261 [05:45]–[06:45]). TESTABLE — exact.
- **POC on the extreme:** POC at the very top of a red bar (bearish) / very bottom of a green bar (bullish) (v272 [01:04]–[01:31]). TESTABLE — exact positional condition.
- **Prominent POC levels** (level 1/2/3) at swing highs/lows (v272 [04:26]–[04:55]). TESTABLE in concept; "prominence" is proprietary → NEEDS-OPERATIONALIZATION.
- **Trade-entry confirmation = price moves 2 ticks beyond signal bar within 2 bars** (configurable to 3) (v221 [06:36]–[07:52], [18:35]). TESTABLE — exact (indicator-specific).
- **Five price levels / five bars** = his max "give it room to work" window; failure inside = exit/reverse (v221 [13:55]–[16:32]). TESTABLE — exact.
- **Order-flow ratio:** LOW value (between 0 and 1, e.g., 0.48) = stopping volume; HIGH value (e.g., 58) = price exhaustion (v277 [11:29]–[12:00]). Proprietary metric; the 58 is illustrative → NEEDS-OPERATIONALIZATION.
- **Stopping-volume concentration (qualitative, but he gives example fractions):** one price level holding ~10–11% of bar volume (561 of 4,310), or ~25% across three levels (~1,000+ of 4,000), or ~6–7% at the high (587 of ~3,900) (v277 [03:54]–[06:00], [10:29]–[12:38]). These are EXAMPLES, not a stated rule → NEEDS-OPERATIONALIZATION (candidate: "single-price or 3-price cluster ≥ ~10–25% of bar volume at an extreme").
- **Absorption tell:** green bar with NEGATIVE delta (or red bar with POSITIVE delta) on decent volume, with bid-side at-price volume dominating (v269 [01:50]–[05:10]). TESTABLE — exact sign condition; "decent volume" NEEDS-OPERATIONALIZATION.
- **Delta sign-flip:** Max-Delta-positive bar immediately followed by a net-negative-delta bar at an extreme (v280 [05:46]–[06:19]). TESTABLE — exact.
- **Trapped-cohort size:** ~175 contracts = weak/limited fuel; ~500 = "not heavy"; ~2,300–2,500 absorbed = strong trap (v244 [02:42]; v280 [08:29]–[10:22]). Instrument-specific (e-mini/micro) → NEEDS-OPERATIONALIZATION (normalize to bar/session volume).
- **Inside-bar count after a big bar:** first inside bar after a big directional bar = possible move-over; he notes "four inside bars" as confirmation (v262 [07:31]–[08:09]). TESTABLE — count is exact but threshold loose.
- **Session-volume normalization:** evening ≈ <⅓ of full-day volume (v262 [02:47]–[03:12]). TESTABLE scaling factor (approximate).

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- **Tick replay REQUIRED** for footprint/flowsbounce order-flow analysis ("you have to use tick replay for this… I'm sorry but you got to use it") (v221, [17:13], [29:16]). Implementation prerequisite.
- **Color-coded inverse-imbalance markers** baked into Orderflows Trader — bearish vs bullish inverse imbalances print on the chart "like a lighthouse shining a light" so you can't miss them (v244, [06:06]–[06:38]). Direct feature to replicate: flag inverse imbalances visually.
- **Order-flow ratios** displayed as blue/black numbers above/below bars; low (0–1) = stopping volume, high = exhaustion (v277, [11:29]–[12:00]). Replicable derived metric.
- **Prominent Point of Control levels** (toggle level 1/2/3) (v272, [04:26]–[04:55]). Replicable: rank per-bar POCs by prominence, surface top swing-high/low ones.
- **Zone-drawing for management:** draw a box 5 price levels × 5 bars from the signal; use as stop/invalidation envelope (v221, [13:55]–[16:32]). Replicable visual + logic.
- **F6 line-draw** to mark stopping-volume levels for retest watching (v277, [12:38]–[13:06]). Native NT workflow.
- **Trade-entry signal logic:** print buy/sell triangle only after price moves 2 ticks beyond the signal bar within 1–2 bars (follow-through gate); signal won't reprint once confirmed (v221, [18:35]–[19:47]). Replicable confirmation filter.
- **Flowsbounce strength settings** 1–5 ("pure"/strong = 0/5/0 at 1; mid = 3; weak = 5) with optional enhanced-lookback filter + minimum-difference level + swing filter (v221, [16:32]–[18:35], [40:00]–[41:22]). Suggests a tunable sensitivity parameter for the reversal indicator. NEEDS-OPERATIONALIZATION (internal meaning not disclosed).
- **NinjaTrader 8 only** for his tools; markers (Indicator Store) used to automate execution off signals (v221, [04:12], [12:48], [26:03]). Context for deployment.
- He filters out bars with too little movement ("doesn't start analyzing the order flow until there's at least price movement… bars that are two ticks there's not going to be anything") (v221, [33:44]–[34:17]). Implementation: skip ultra-narrow bars.

## Q. Notable verbatim quotes (with citation)
1. "When you see an inverse imbalance it is generally a sign of traders that are getting trapped… aggressive traders that are selling into strong passive bids or buying from strong passive offers." (v244, [01:37]–[02:10]) — defines the trap/reversal mechanic.
2. "Strong aggressive buying it needs to be followed through; if it's not followed through it's probably not as strong as you think." (v280, [11:25]–[11:54]) — the chunk's core A+ gate.
3. "Even if you bought this stack buying imbalance… you would have been stopped out. You need that follow through order flow." (v280, [04:43]–[05:16]) — explicit rebuttal of naïve "buy stacked buying imbalance" systems.
4. "If you have point of control at the top of a green bar that's not reversing anything… but when you have the red bar [with] the point of control at the top… the price action is starting to go down." (v272, [01:31]–[02:02]) — POC-on-extreme reversal condition.
5. "If it's a small number… 0.48 is between one and zero, [that's] telling me the stopping volume; if it was the opposite, if it was a very high number like 58 then [it tells] me it's price exhaustion." (v277, [11:29]–[12:00]) — his proprietary ratio distinguishing stopping volume vs exhaustion.
6. "More importantly if it's an area where you had strong aggressive selling earlier and now you're seeing strong aggressive buying come in at that same level, that's an important clue, those are good trades to take." (v262, [13:14]–[13:46]) — highest-confidence stacked-context confluence.
7. "These guys are the ones that are really getting trapped because they're being absorbed by a big limit offer… at some point these are the guys you're looking to puke out." (v280, [08:29]–[09:25]) — the absorption-trap psychology.
8. "Markets have memory right, liquidity has memory, so when a market comes back [to] those levels it can give you a good opportunity." (v261, [00:59]–[01:29]) — why order-flow levels persist.
9. "To see trades like this work out where it came right down to 74 held it perfectly then rallied 20 points is not normal." (v261, [04:51]–[05:19]) — explicit tiering: the textbook case is the exception.
10. "Wait for the bar to close… let the market take you into the trade… there's going to be times where the next bar just goes inside and falls down." (v244, [08:05]–[08:31]) — entry discipline (no anticipatory fills).

## R. Contradictions / nuances
- **Order flow has a short shelf life (5–10 min) vs. "markets/liquidity have memory":** v221 ([07:52]–[08:34]) says order flow loses value after ~5–10 minutes, but v261/v262 build the whole stacked-imbalance method on levels that "have memory" and react hours later. RESOLUTION (implied): the *live signal/momentum* decays fast, but the *price level* where strong order flow occurred persists as S/R. Important to model these as two separate mechanisms.
- **Stacked buying imbalance is bullish — EXCEPT when it has no follow-through, then it's a SHORT.** He directly contradicts the "buy stacked buying imbalance" rule of competing software (v280, [04:13]–[05:16]). The imbalance is only a signal *with* confirmation; without it, it flags trapped longs. [CORE NUANCE]
- **A "trapped trader" footprint may not be a trapped trader at all:** a stop-triggered sweep looks identical to trapping but those traders are flat ("smiling all the way to the bank"); only absorbed FOMO aggressors are truly trapped (v280, [02:52]–[09:50]). Same trade, different read. [CORE NUANCE]
- **Zero delta means nothing on a time bar** (coincidence of where the clock cut), contradicting traders who read significance into it (v262, [01:51]–[02:18]).
- **Divergence alone is insufficient** — a new low with positive delta still failed to rally because "the next bar doesn't go any higher" (v262, [05:33]–[06:04]). Confirmation required.
- **POC-on-the-extreme is largely obsolete on the e-mini** due to volatility (use Prominent/top-two POCs); still valid in bonds/rates/commodities (v272, [00:31]–[05:22]). The tool is regime- and instrument-dependent.
- **He warns AGAINST his own clean examples:** repeatedly says the perfect retest/20-point move is "not normal," "I don't want you thinking all I got to do is buy and sell stacked imbalances… you still got to take market context and risk management" (v261, [04:51]–[05:19], [07:14]–[07:42]). Anti-overfit caution.
- **Wrong-color candle is tolerated:** he'll take a bearish stopping-volume short off a GREEN candle ("normally I'd prefer this to be a red candle… you can only trade what the market is giving you") — color preference is a tier-down, not a disqualifier (v277, [05:27]).
- **Number-time volume is "expected" support/resistance and therefore LESS interesting** than heavy volume appearing away from obvious S/R — yet number-time stacked imbalances also make the best memory levels. Nuance: distinguish *expected* heavy volume (at the day's high/low) from *anomalous* heavy volume (mid-range) (v277, [01:53]–[02:49]).

## Coverage note
Rich chunk overall. The 2022 videos (v244, v261, v262, v269, v272, v277, v280) are each tightly focused single-concept lessons that map directly onto the reversal model — inverse imbalances, stacked-imbalance memory levels, absorption (negative delta on up bars), stopping volume / POC-on-extreme, and the two trap types — with heavy repetition of the "no follow-through → fade" gate. v221 is a 48-minute Q&A workshop that is thin on discrete reversal patterns but yields reusable risk/management rules (5-level/5-bar zone, stop-behind-a-level, tick-replay requirement, 2-tick/2-bar confirmation, optimization caution). All transcripts parsed cleanly; numbers cited are his (ratios, ticks, bars) — most volume/delta figures are session-specific examples, kept qualitative and marked NEEDS-OPERATIONALIZATION.
