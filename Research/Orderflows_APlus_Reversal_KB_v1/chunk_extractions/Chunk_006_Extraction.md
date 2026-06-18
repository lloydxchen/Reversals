# Chunk 006 Extraction
- Source chunk: Chunk_006_Orderflows_Transcripts.md
- Transcripts covered:
  - v176 — Reversal Trading With Order Flow Webinar Investor Expos Orderflows Trader For NinjaTrader 8 (2020-03-26)
  - v220 — Part 1 Flowsbounce Workshop Volume Profile Combined With Order Flow (2021-09-24)
- Overall content value: rich (v176 = the cleanest explicit reversal-model teaching in the KB so far; v220 = tool/settings-heavy but contains strong confirmation/zone/profile-context logic)

## A. Setup types & names he uses
- **Reversal Type 1 — "Aggressive traders coming in at a swing high or swing low"** (both directions). Buy at swing low when aggressive BUYERS step in; sell at swing high when aggressive SELLERS step in. (v176, "Reversal Trading Webinar", [21:24]–[22:52]) [REPEATED]
- **Reversal Type 2 — "Trapped traders" (failed break / failed breakout-breakdown)** (both directions). A break-out or break-down fails; traders who got in at bad levels are trapped. (v176, "Reversal Trading Webinar", [21:24], [33:49]–[35:43]) [REPEATED]
- **"Three or more imbalances in a bar"** setup — his software draws a **pink/square box** around a down candle with 3+ selling imbalances (sell) or a green candle with 3+ buying imbalances (buy). Distinct from a classic stacked imbalance. (v176, [18:13]–[19:44]) [REPEATED]
- **Stacked imbalance** — 3+ imbalances stacked neatly on consecutive price levels (normal-direction confirmation). (v176, [18:45], [34:40]) [REPEATED]
- **Flows Bounce setup** (v220 tool) — "combining order flow with aspects of volume profile"; generates buy/sell signals (triangles) plus a "zone". (v220, "Flowsbounce Workshop", [00:01], [01:09], [07:17]) [ONCE — this video]
- **Double top / double bottom** — he reads these via order flow rather than waiting for the price-level break. (v176 [27:58], [29:00]; v220 [12:10]–[12:38], [1:11:29]) [REPEATED]

## B. Tiering / grading language  ← HIGH PRIORITY
- **"three is sort of like the magic number"** of imbalances traders look for — the bar he WOULD sell (#3) had **three** selling imbalances; the bars he would NOT sell (#1, #2) had zero and one. The count of imbalances is the explicit tier discriminator. (v176, [17:40]–[18:13], [19:44]) [REPEATED]
- **"I like clear trading signals"** / **"clear swing high or clear swing low"** — clarity of the swing is a grading axis. A double bottom where the two candles "share the same bottom" he calls **"borderline"** and **"I wouldn't at this point really consider that reversal."** (v176, [27:58]–[28:28], [21:52]) [REPEATED]
- **"the nice 30 point sell-off"** / **"nice clear swing high"** / **"nice clear low"** — "nice" used repeatedly to mark a setup that produced a clean follow-through move. (v176, [17:15], [29:36], [27:21]) [REPEATED]
- **"sometimes the best trading ideas don't work out … it just went sideways"** — even a qualifying setup can fail; sideways = not graded down beforehand, just didn't pay. (v176, [27:21], [41:49]) [ONCE]
- **"these are the trades you love where it just sells off maybe pulls back a little bit then sells off sharply"** — best-tier outcome description. (v220, [32:18]) [ONCE]
- **"perfect example"** of a double-distribution day (wheat) — describing profile structure quality, not a reversal grade. (v220, [09:43]) [ONCE]
- **Pure setting = "five"** is described as the strongest / "the most obvious" signal level; "one being the weakest." Bounce strength is a 1–5 quality dial (5 = strongest/cleanest, 1 = most signals incl. noise). (v220, [17:42]–[18:17], [21:53]) [REPEATED]
- NEEDS-OPERATIONALIZATION: "much lower … not much lower but a little bit lower" for how far the new swing low must extend — explicitly qualitative, he refuses to pin a number. (v176, [22:24])

## C. Order-flow story & psychology per setup
- **Reversal Type 1 (swing high/low):** at a turning point "the last group of aggressive buyers or sellers has come to the market." The aggressive late buyers exhaust; big passive sellers with "supply" use the high prices to get short, and the market rolls over. (v176, [36:10], [38:43]) [REPEATED]
- **Trapped traders (Type 2):** late entrants buy the high / sell the low out of FOMO ("markets rallying I got to buy") or pain ("I can't take any more heat … I got to get out"); they don't understand context/market structure. While they get long, "all the big sellers are taking this opportunity to get short at these high prices." (v176, [35:12]–[35:43], [37:09]–[37:41]) [REPEATED]
- **Trapped-trader cohort is often SMALL:** "people would have you believe trapped traders are a big quantity of traders — often it's a small quantity, but you're gonna see it in the imbalances." (v176, [37:41]) [ONCE] — important nuance.
- **"I made the print / I made the paper"** — old-trader saying for buying the high or selling the low (being the trapped one). (v176, [36:10]–[36:40]) [ONCE]
- **Exhaustion at the turn:** in Type 1, "the aggressive buyers ran out the bullets … got no more left to buy … but the aggressive sellers got a lot of supply, market sells off." (v176, [40:44]) [REPEATED — exhaustion framing recurs]
- **You must trade WITH the smart money:** "you're trading against the more experienced traders … the all-stars … you want to join them," they have "much deeper pockets" / can withstand "a bigger deeper drawdown." (v220, [12:03]–[13:05]) [REPEATED]
- **Supply/demand analogy:** toilet-paper / soft-soap hoarding = outsized demand at steady price exhausts supply; spotting "very aggressive buyers stepping in at low prices" or "aggressive sellers selling at high prices" is the trade. (v176, [06:14]–[08:46]) [REPEATED]

## D. Exhaustion clues
- At a swing high, aggressive buyers "ran out the bullets … no more power to buy" while sellers still have supply → market sells off. (v176, [40:44]) [ONCE — explicit phrasing]
- On exiting a winning long, "if I see selling imbalances and things like that coming in here … maybe some market exhaustion, that's my sign to get out." (v220, [50:15]–[50:40]) [ONCE]
- Buying/selling-imbalance count drying to zero on a fresh swing = no aggressive participation = not a reversal (bars #1/#2 had 0/1 imbalances → no trade). (v176, [17:40]–[18:13]) [REPEATED]
- NEEDS-OPERATIONALIZATION: "ran out the bullets" / "no more power to buy" — qualitative exhaustion, no metric given.

## E. Absorption clues
- Type-2 (trapped) bar IS an absorption event: aggressive late buying (buying imbalance) in a candle, but big PASSIVE sellers absorb it — "passive sellers came in offering it out but it's met by the aggressive buyers … the aggressive buyers ran out the bullets." Result is a green/up candle that contains selling imbalances, or a red/down candle containing buying imbalances. (v176, [35:12]–[35:43], [40:44]) [REPEATED]
- The diagnostic flag for absorption: imbalances OPPOSITE to the candle's direction (stacked SELLING imbalances in a GREEN up candle; stacked BUYING imbalances in a RED down candle) = trapped traders / absorption. (v176, [34:40]–[35:43]) [REPEATED]
- "someone's defending a price area … that's very important information" — defense/absorption visible on footprint, invisible on bar chart. (v176, [16:22]) [ONCE]

## F. Stacked imbalance ideas
- **Imbalance definition:** compare volume on bid vs offer **diagonally, not horizontally**, in the two-way auction. (v176, [13:38]–[14:08]) [REPEATED]
- **Ratio = 4:1 preferred.** "if the volume traded on the offer is greater than the volume traded on the bid by four to one … you'd consider that a buying imbalance and vice-versa." Explicitly: "four to one is a guideline; some people use three to one, others ten to one, but most traders prefer four to one." (v176, [10:41]–[11:12]) [REPEATED] — EXACT NUMBER: 4:1 (alts 3:1, 10:1).
- **Stacked imbalance = 3+ imbalances neatly on top of each other** (consecutive price levels), normally same-direction as the candle. (v176, [18:45], [34:40]) [REPEATED] — EXACT NUMBER: 3.
- **Box rule (his software):** pink/square box around a candle with **3 or more** imbalances in the bar (not necessarily consecutive) — catches near-misses one level apart that pure stacked-imbalance scanning would miss (his example: "26 against 67" breaking the stack). (v176, [18:13]–[19:44]) [REPEATED] — EXACT NUMBER: 3+.
- Distinction: a stacked imbalance (3 consecutive) is a subset; "3+ imbalances in a bar" is the broader trigger he wants flagged. (v176, [18:45]–[19:13]) [REPEATED]

## G. Delta / delta-divergence ideas
- Delta defined: "the difference between net buyers and sellers in a bar … helps you determine when there's shifts in supply and demand." Explicitly NOT the focus of v176. (v176, [15:23], [15:50]) [ONCE]
- 5-yr note example: at a low-of-day reversal "there's something very bullish in this bar with the divergence, with the ratio, with the zero print, with the one print in there" — names **delta divergence, the ratio, a zero print, a one print** as bullish reversal internals (taught in his courses, not detailed here). (v176, [31:54]–[32:24]) [ONCE] — NEEDS-OPERATIONALIZATION (terms named, not defined).
- v220 lists the order-flow primitives available: "delta … point of control … imbalances … max delta … min delta … bid volume … ask volume … cumulative delta." (v220, [06:06]–[06:40]) [ONCE — inventory only]

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Failed break = trapped traders (his core Type-2).** Euro example: "we broke our low … a lot of these price-action traders … get short … at the same time the bigger traders realize this is my buying opportunity … market makes a nice rally up." (v176, [39:42]–[40:15]) [REPEATED]
- **He explicitly REJECTS the "stop run" label:** "people say well that's a stop run — NO, this is people getting short at bad prices because they don't understand what's happening in the market." (v176, [40:15]) [ONCE] — important framing: he reads it as trapped traders, not a liquidity sweep.
- **Double-top false breakout:** waiting for the support break to confirm a double top is too late — "once you get that confirmation it's a false breakout and the market snaps back; really your opportunity is [at the top]." Order flow lets you short the top, not the break. (v220, [1:11:29]–[1:13:05]) [REPEATED]

## I. Trapped-trader ideas
- Definition: "long and wrong, bought the high of a move," or "short in the hole, sold at the low." (v176, [33:49]–[34:15]) [REPEATED]
- Visible ONLY in order flow as opposite-direction imbalances in the candle (see E/A). "looking at the order flow is gonna give you an advantage over other traders not looking at order flow." (v176, [37:41]) [REPEATED]
- **Context gate:** look for trapped BUYERS at HIGHS (to sell) and trapped SELLERS at LOWS (to buy). A trapped-trader pattern in the middle of an up-move is "an example of a trade NOT to take … you gotta understand market context." (v176, [41:18]–[41:49]) [REPEATED] — key filter.
- v220 confirms order flow's job: spotting when "traders get trapped at a certain price location." (v220, [03:59]) [REPEATED]

## J. Entry triggers (the exact "go" event)
- **Type 1:** (1) clear swing high/low (the swing bar must be the actual extreme, "not a bar before or after," and preferably the low by "a few price levels"); (2) **3+ buying imbalances** in the bar at a swing low (buy) / **3+ selling imbalances** at a swing high (sell). (v176, [21:52]–[22:52]) [REPEATED]
- **Execution timing:** "normally I wait for the next bar to open up and start trading higher before taking a trade." He wants the market moving his way fast on the next bar. (v176, [25:25]–[25:56]) [REPEATED]
- **Type 2:** opposite-direction stacked/3+ imbalances (trapped traders) at a high (sell) or low (buy), in correct context. (v176, [34:40]–[35:43]) [REPEATED]
- **Flows Bounce (v220):** the triangle (blue up = buy, red down = sell) is the automatable signal; it prints on the bar(s) AFTER the signal bar when the **Trade Entry Signal** filter is on (see K). The "zone" draws regardless. (v220, [1:01:23]–[1:05:30], [1:06:35]) [ONCE]

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Follow-through order flow is the confirmation.** "you need other traders to be buying along with you … if there's no follow-through order flow the probability the trade will work out is decreased." (v220, [1:01:50]–[1:02:47]) [REPEATED] — central thesis of v220.
- **Trade Entry Signal filter:** signals only AFTER the signal bar when subsequent bars show "the complementary order flow in the direction of the trade signal." His setting = **"two and two": market must move 2 ticks in the trade's direction over the next 2 bars** or no signal prints. (v220, [1:02:17], [1:03:17]–[1:03:48]) [ONCE] — EXACT NUMBERS: 2 ticks / 2 bars (his personal default; adjustable per market, e.g. 1 tick on slow markets).
- "the trade entry signal is confirmation — it's QUICK confirmation … take advantage of the order flow as quickly as possible." (v220, [1:13:05]) [REPEATED]
- Type 1 confirmation: "oftentimes you see these next bars just explode … in the direction you want to be positioned." (v176, [24:49]) [REPEATED]
- After a buy at a low, "if you get long and the market puts in a red candle and tests the low, that's probably not a good sign." (v176, [25:56]) [ONCE] — early invalidation tell.

## L. Invalidation — what should NOT happen / what kills the thesis
- **No follow-through order flow** → thesis dead: "it started to go here then it just went sideways, there wasn't that order flow to push the market lower." (v220, [24:14], [1:08:55]–[1:09:20]) [REPEATED]
- **Buying a falling market with no turn:** "the last thing you want to do is buy, get stopped out, buy, get stopped out … you want the market to find its low then turn around." A red/doji bar after a buy signal that keeps going lower = don't be long. (v220, [1:05:30]–[1:06:35], [1:08:55]–[1:09:49]) [REPEATED]
- **Not a swing high/low → not a valid reversal**, full stop. Inside bars / bars adjacent to (not at) the extreme are disqualified. (v176, [26:22]–[26:53], [31:18 "I would prefer this red candle to be a swing high"]) [REPEATED]
- "if a trade's not working out after a couple bars you'd get out … get out as small loss, don't be married to it." (v176, [41:49]) [REPEATED]

## M. Stop / risk / target / trade management
- **Stop placement (Type 1):** "normally I put my stop below the low of the signal bar." (v176, [25:25]) [REPEATED] — EXACT RULE (qualitative direction, no tick offset given).
- **Flows Bounce zone as stop:** "I like to use [the zone] as a place where I can hide behind … if it starts trading against me and it violates that zone I should be out of that trade, period." Zone default = **5** (ticks, implied; sentence cut off at chunk end). (v220, [1:05:30], [1:13:42]–[1:13:48]) [ONCE]
- **Tight-stop caveat:** "in this market environment having tight stops sometimes is just going to stop you out" (broke the low by 2 ticks before rallying). (v176, [25:56], [29:00]) [ONCE] — conditional on high volatility.
- **Get in and out FAST:** "in this type of market you really want to get in and out as fast as you can, limit your risk, look for quick trades." (v176, [24:19]–[24:49]) [REPEATED]
- **Targets:** never a fixed number; framed as "let your winners run, keep your losses small," winners bigger than losers, "being right enough of the time." Often "you're done for the day" after one good move. (v220, [11:09 region], [24:47], [33:26]–[33:57], [55:46]) [REPEATED] — NEEDS-OPERATIONALIZATION (no target rule).
- Exit on adverse order flow: selling imbalances/exhaustion appearing against a long = exit (don't wait for price to come all the way back). (v220, [50:15]–[50:40], [49:46]–[50:15]) [REPEATED]

## N. Context filters (session/time, regime/volatility, levels)
- **A clear directional move must precede a reversal:** "in order to trade a reversal there needs to be a clear directional move … you need to have hit a swing high or swing low and the market start turning." Don't hunt reversals when the market hasn't rallied/sold off. (v176, [20:23]–[20:55]) [REPEATED]
- **Timeframes:** sweet spot **30 sec to 5 min**; 5 min "as long as I'll go" (longer fills the footprint and you overlook things); 30-sec preferred in high volatility ("take it down a level"). 15-min usable but "you may get no signals," need 1–2 markets. (v176, [16:22], [37:41], [32:24]; v220, [14:40]–[16:08]) [REPEATED]
- **Instruments:** ES/e-mini, NQ/MNQ mini-Nasdaq, crude oil, euro currency (6E), German Bund, Bobl, DAX, Russell, mini Dow, gold, 5-yr note, ultrabonds, wheat. Crude/SPs/currencies "more stable"; Nasdaq/DAX/mini-Dow most volatile. (v176, [12:44], [22:52], [39:12]; v220, [14:08]–[14:40]) [REPEATED]
- **Pattern shows most on volatile markets:** trapped-trader pattern historically "mainly on the more volatile markets like DAX, Nasdaq, mini Dow, occasionally crude" — appeared in e-minis only because of extreme 2020 volatility. (v176, [39:12]) [ONCE]
- **Volume Profile context (v220 core idea):** use **CURRENT, recent value formation around price** — POC / VAH / VAL are useless when price is trading far above/below them ("what use is that support if you're never going to touch it on the session we're in"). Flows Bounce ties recent profile to live order flow. (v220, [07:56]–[11:37], [27:35]–[29:53]) [REPEATED]
- **News/FED days:** repeatedly cautions "I'm not a big advocate for trading on Fed days … things can turn on a dime"; trade only AFTER the announcement. (v220, [25:17], [48:10]–[48:43], [49:46], [56:19]) [REPEATED]
- **"don't trade based on what happened in the past … base your trading on what's happening now"** — recency over historical patterns. (v220, [11:09]–[12:03]) [REPEATED]
- **Volume-based vs tick vs time charts:** all usable, but "know your markets" — 500 volume in e-mini = 3–4 trades, but 500 volume in wheat could take 5 minutes. (v220, [16:08]–[17:10]) [ONCE]

## O. Directly testable / measurable variables
- **Imbalance ratio = 4:1** bid-vs-offer (diagonal); alternatives 3:1 or 10:1. (v176, [10:41]) — EXACT.
- **Imbalance count threshold = 3** ("magic number"): 3+ imbalances in a bar → box; 3+ consecutive → stacked imbalance. (v176, [17:40], [18:13], [34:40]) — EXACT.
- **Stacked = consecutive price levels; box = 3+ anywhere in the bar (gaps allowed).** (v176, [18:45]–[19:44]) — EXACT (structural).
- **Swing-bar requirement:** the signal bar must be the actual swing extreme (not adjacent); new low/high "preferably by a few price levels." (v176, [21:52]–[22:24]) — partly EXACT, partly NEEDS-OPERATIONALIZATION ("a few price levels").
- **Entry timing:** wait for next bar to open and trade in your direction before entry. (v176, [25:25]) — EXACT (rule).
- **Trade-Entry-Signal confirmation = 2 ticks over 2 bars** (his default; adjustable, e.g. 1 tick slow markets, disabled on ultrabonds/bonds). (v220, [1:03:17]) — EXACT.
- **Stop = below low of signal bar** (Type 1). (v176, [25:25]) — EXACT (direction; no offset).
- **Flows Bounce zone default = 5** (ticks, implied — sentence truncated). (v220, [1:13:42]) — EXACT-ish, verify.
- **Flows Bounce settings (tool-specific, 1–5 dials):** Bounce strength 1–5 (5 strongest/"pure", 1 weakest/most signals); Minimum Difference Level 0=disabled,1–5 (measures current bar vs N-th previous bar; he uses 0–1 normal, 2–4 on Nasdaq/MNQ/YM/DAX); Swing Filter on/off + Swing Period (1, fib numbers, "wouldn't go over 25" — just looks for a lower-low/higher-high, "no big scientific thing"); Enhanced Look-Back Filter (volatile markets only). "Pure setting = 5 and 0, everything else disabled" = his recommended starting point all markets. (v220, [17:42]–[19:24], [29:53]–[31:43], [34:36]–[40:28], [45:23]–[48:10]) — EXACT ranges, but tool-specific not market-physics.
- NEEDS-OPERATIONALIZATION: "big volume," "much lower," "ran out the bullets," "follow-through order flow," "selling coming in," "exhaustion" — all qualitative.

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- All charts generated by **Orderflows Trader on NinjaTrader 8**. (v176, [04:51]) [REPEATED]
- **Auto-box logic:** software draws a **pink/square box** around any down candle with ≥3 selling imbalances (sell) or up candle with ≥3 buying imbalances (buy) — directly implementable: per-bar imbalance counter + candle-color condition. (v176, [18:13]–[19:13]) [REPEATED]
- **Imbalance detection = diagonal bid×offer comparison ≥4:1** per price level — implementable footprint primitive. (v176, [10:41], [13:38]) [REPEATED]
- **Reversal signal = swing-extreme detection AND ≥3 imbalances in the swing bar** (Type 1); + opposite-color-imbalance detection for trapped traders (Type 2). (v176, [21:52]–[22:52], [34:40]) [REPEATED]
- **Confirmation gate (Trade Entry Signal):** signal fires on bar(s) after signal bar only if price advances ≥X ticks over Y bars (default 2/2); should NOT print on the signal bar itself; may appear/disappear intrabar but **does not repaint after bar close**. Important automation note. (v220, [1:01:23]–[1:04:17], [1:06:35]) [ONCE]
- **Zone object** drawn from the signal bar as a hide-behind stop level (default ~5). (v220, [1:05:30], [1:13:42]) [ONCE]
- **Markers / automation:** automated systems "key off the triangle" — the printed triangle is the machine-readable trade event. (v220, [1:08:12]) [ONCE]
- **Profile integration:** weight recent value-area/POC formation NEAR current price (not stale full-session POC) and combine with live order flow. (v220, [29:13]–[29:53]) [ONCE]
- Adjustable strength dials (1–5) per market volatility — implies tunable sensitivity parameter rather than one fixed threshold. (v220, [17:42]–[19:24]) [ONCE]

## Q. Notable verbatim quotes (3–10, each with citation)
1. "with order flow … three is sort of like the magic number that a lot of traders look for in terms of imbalances or stacked imbalances." (v176, "Reversal Trading Webinar", [18:13])
2. "in order to trade a reversal there needs to be a clear directional move … you need to have hit a swing high or a swing low and the market to start turning." (v176, [20:23])
3. "when you have stacked selling imbalances in a green up candle … stacked buying imbalances in a red down candle, that is a result of trapped traders — traders who are late to the party." (v176, [34:40])
4. "those guys got long, but at the same time they're getting long all the big sellers are taking this opportunity to get short at these high prices, and then the market sold off." (v176, [37:09])
5. "people say well that's a stop run — no, this is people getting short at bad prices because they don't understand what's happening in the market." (v176, [40:15])
6. "the aggressive buyers ran out the bullets … got no more left to buy, no more power to buy, but the aggressive sellers got a lot of supply, market sells off." (v176, [40:44])
7. "you need other traders to be buying along with you … if there's no follow-through order flow the probability the trade will work out is decreased." (v220, "Flowsbounce Workshop", [1:02:17])
8. "I use settings of two and two … the market has to move two ticks in the direction of the trade signal over the next two bars, and if it doesn't, there's no trade signal." (v220, [1:03:17])
9. "what use is all this information down there [the profile] … there's got to be a way to use it" — i.e. only recent value near price matters. (v220, [29:13])
10. "if you're waiting until it breaks this support area down here … once you get that confirmation it's a false breakout and the market snaps back; really your opportunity is [up at the double top]." (v220, [1:13:05])

## R. Contradictions / nuances
- **Trapped traders are usually a SMALL cohort, not a big crowd** — contradicts the common "big trapped crowd" belief. (v176, [37:41]) [ONCE]
- **He explicitly rejects "stop run" / liquidity-sweep framing** for failed breaks, reframing them as trapped traders at bad prices. Conflicts with mainstream stop-hunt narrative. (v176, [40:15]) [ONCE]
- **Tight stops are double-edged:** the same setup that works can stop you out on a 2-tick low-break in volatile regimes; he tolerates breaking the level by a couple ticks. Conditional/"it depends." (v176, [25:56], [29:00]) [ONCE]
- **15-min / longer charts:** he says you CAN use order flow there but personally won't, and you'll get few/no signals — conditional endorsement. (v176, [32:24]; v220, [15:12]) [REPEATED]
- **Type-1 wants imbalances SAME direction as candle at the extreme; Type-2 wants imbalances OPPOSITE the candle.** Both are "3+ imbalances" but mean opposite things — must be disambiguated by candle color + location/context, or the model conflates a continuation with a reversal. (v176, [22:24] vs [34:40]) [SPECULATIVE — my synthesis of the two rules]
- **Context overrides the pattern:** a textbook trapped-trader bar mid-trend is "a trade NOT to take." The same footprint signature is valid or invalid purely on location (high vs low vs middle). (v176, [41:18]) [REPEATED]
- **"It depends on your personality":** settings are "starting points," not fixed rules; weaker settings = more signals/scalps, stronger = fewer/cleaner. No single correct threshold. (v220, [32:50]–[33:57], [41:23]) [REPEATED]
- **Order flow does NOT call every turn:** "it doesn't find every single turning point … there's a lot of randomness"; it only flags non-random moments. (v220, [03:31]–[04:32]) [REPEATED] — tempers any "predict all reversals" goal.

## Coverage note
v176 is the richest reversal-model source seen — fully parseable, two named setups with explicit imbalance-count and swing criteria, exact 4:1 ratio and "3 = magic number." v220 is tool/settings-heavy (Flows Bounce dials are tool-specific, not market physics) but contributes the high-value follow-through/confirmation logic (2-ticks-over-2-bars Trade Entry Signal), the zone-as-stop concept, the "recent profile near price only" filter, and the "short the double top, don't wait for the break" idea. One number is truncated at chunk end (zone default "set to five" — sentence cut at [1:13:48]); verify. No unparseable passages.
