# Chunk 095 Extraction
- Source chunk: Chunk_095_Orderflows_Transcripts.md
- Transcripts covered:
  - v356 — Bearish Order Flow On A Trend Day Down Using Orderflows Trader (2023-08-24)
  - v357 — Identifying Big Buyers Coming Into The Market With Order Flow Using Orderflows Trader Software (2023-08-25)
  - v359 — NQ vs ES Order Flow Which Is Better For Trading Using Orderflows Trader (2023-08-26)
  - v360 — Value Area Analysis In Order Flow Using Orderflows Trader (2023-08-26)
  - v362 — Order Flow Range Based Charts Versus Time Based Charts Using Orderflows Trader (2023-08-27)
  - v364 — All About Delta Footprint Charts Using Orderflows Trader (2023-08-29)
  - v365 — Extreme Point Of Control In Order Flow Analysis Develop A Trading Strategy With Orderflows (2023-08-29)
  - v366 — The Ultimate Pro Pattern Bundle From Ninjacators For NinjaTrader 8 (2023-08-29)
  - v368 — An Unlucky Trade Is There Luck In Trading Order Flow Analysis With Orderflows Trader (2023-08-31)
- Overall content value: mixed (v356, v357, v360, v364, v365 rich for reversal model; v359, v362 chart-type tutorials, thin on reversal triggers; v366 sponsored product ad, mostly off-model; v368 trade-recap/psychology, partial)

## A. Setup types & names he uses
- **Point of Control on the extreme** (his named pattern): green candle with POC at the bottom of the bar = bullish (support/stopping volume); red candle with POC at the top of the bar = bearish (supply). Must appear at a high/low or swing high/low after a move (v365, "Extreme Point Of Control", [03:46]-[07:02]) [REPEATED]
- **Delta tail** (his named pattern, "introduced several years ago"): red candle down with all negative Deltas but a positive Delta at the top = the "tail"; bullish version = green candle with negative Delta on the bottom and all positive Delta above (v364, "All About Delta", [08:44]-[09:11]) [ONCE]
- **Reversal bar at swing low**: strong negative Delta / aggressive selling poking into a swing low, met by absorption, followed immediately by aggressive buying on the offer → "like a reversal bar to me… I'd be looking for this market to pop up" (v364, "All About Delta", [05:18]-[06:16]) [REPEATED]
- **Big-buyer-off-the-low**: fresh large bid (absorption) appearing 3-4 bars off the low of the day, in a price area just traded (v357, "Identifying Big Buyers", [06:44]-[09:48]) [REPEATED]
- **Divergence (new low with positive Delta)**: he explicitly says this alone is NOT a system / not a setup (v356, "Bearish Order Flow", [11:51]-[12:19]) [ONCE] — see R.
- **Untested value area** as directional signal: bullish value area not retested in next bar = long signal; bearish (red) value area not retested = short signal (v360, "Value Area Analysis", [05:11]-[09:17]; v359, [08:23]-[10:04]) [REPEATED]
- **"What you expect to happen doesn't happen, the opposite happens"** setup (his words): red candle that closes ABOVE its value area, next bar holds above and doesn't trade back in → bullish (v360, "Value Area Analysis", [07:21]-[08:49]) [ONCE]
- Cup-and-handle, Elliott-wave 0-1-2-3, double bottom/top (technical patterns layered with order flow for confirmation) (v366, "Ultimate Pro Pattern Bundle", [02:53]-[09:08]) [ONCE] — sponsored, off-model.

## B. Tiering / grading language  ← HIGH PRIORITY
- **"strong"** vs not — the dominant grading axis for volume/Delta/bids. Always RELATIVE: "is 1286 strong… I'm comparing it to what's happening in recent history… the last 10 or 15 minutes" (v356, "Bearish Order Flow", [06:28]-[06:53]) [REPEATED]; "volume is relative" (v364, [14:43]).
- **"sticks out like a sore thumb"** = the highest-conviction read of a big bid/offer: the 2522 and 1278 contracts at/near the low "stick out like a sore thumb… you should have been noticing this" (v357, "Identifying Big Buyers", [09:48]-[10:21]) [REPEATED].
- **"double, triple, five times the amount of volume"** = how he calls a level strong vs surrounding prints (v357, "Identifying Big Buyers", [10:51]) [ONCE].
- **"the best part… right off the low of the day"** — location grading: a bullish bid signal is best within ~5 handles of the low, "I'd rather see the sign coming in here five handles off the low than 15 handles" (v357, "Identifying Big Buyers", [10:51]-[11:25], [14:12]-[14:37]) [REPEATED]. Same idea for POC-on-extreme: "in context… after a move," not in sideways activity (v365, [05:13]-[06:07]).
- **"the cherry on top" / "extra bonus"** — seeing strong supportive bids (negative Delta at price) coming in on the way UP, not just offers being lifted, is the bonus confirmation (v364, "All About Delta", [12:42]-[15:44]) [ONCE].
- **"that's nothing… doesn't mean anything to me"** — lowest tier: mixed positive/negative Delta in the middle of a bar = normal trading, no signal (v364, "All About Delta", [06:16]-[06:45]).
- **"halfway decent bounce" / "nice little bounce" / "decent move"** — mid-tier qualitative grades for counter-trend rallies he ultimately fades (v356, "Bearish Order Flow", [01:37], [12:19], [03:24]).
- ES graded **"a very mature market… distributes volume excellent"**; NQ **"a different creature… more wild," "great market if you have the balls/cojones"** (v359, "NQ vs ES", [00:54]-[04:35]) [ONCE].
- Lean hogs: **"a great market to trade order flow… not as sexy as the e-minis"** (v362, "Range vs Time", [15:01]-[15:30]) [ONCE].
- Note: NO explicit "A+ / textbook / my favorite / perfect" grading words appear in this chunk. NEEDS-OPERATIONALIZATION on all "strong" thresholds (relative, not fixed).

## C. Order-flow story & psychology per setup
- **Trend-day-down (v356)**: market is "flow driven," blows through psychological/technical levels "with impunity"; "there's just no buyers out there." When price sweeps a level with no counter-trade, that's bigger participants in control (v356, "Bearish Order Flow", [09:43]-[10:48]) [REPEATED].
- **Big buyer off the low (v357)**: at the low "that's where a lot of people are going to sell," and a passive buyer sits on the bid absorbing all that selling (1200+ contracts), creating support; this is the side stepping up (v357, "Identifying Big Buyers", [08:42]-[09:13]) [REPEATED].
- **Resistance→support flip (v357)**: fresh shorts who sold into a breakout above old resistance must "scramble to cover," some "scratch to break even" → that covering pushes price up and turns old resistance into support (v357, [13:07]-[13:41]) [ONCE].
- **Profit-taking at lows**: buying at a new low can simply be shorts-from-above taking money off the table (aggressive buying), which is why a bare divergence isn't a setup (v356, "Bearish Order Flow", [11:51]-[12:19]) [ONCE].
- **Exhaustion of sellers at a low (v365)**: at the low "the sellers… had no more to do, they gave up… they got no more bullets, their gun is empty," so even small stopping volume reverses it (v365, "Extreme POC", [14:29]-[15:02]) [REPEATED].

## D. Exhaustion clues
- **Thin prints** near a resistance test = bearish exhaustion: "we see this exhaustion print one here… the thin print… 1 and 1, 7 and 6… as you're coming back in to test the resistance level is bearish" (v356, "Bearish Order Flow", [17:01]-[17:37]) [ONCE].
- **Stopping volume at extreme = aggressive side exhausted**: small POC volume (17 lots, 41 contracts) at a high/low "was enough… that the aggressive buying is now done"; sellers have "no more bullets" (v365, "Extreme POC", [10:02]-[10:30], [11:40]-[12:14], [14:29]-[15:02]) [REPEATED].
- **Blow-off Delta cluster**: alternating large +/- Deltas that "cancel each other out" at a swing high (-592 / +627 / -663) = the blow-off top (v356, "Bearish Order Flow", [04:23]-[04:54]) [ONCE].

## E. Absorption clues
- **All-negative Delta at price inside a GREEN candle** = passive buyers absorbing aggressive selling (Delta footprint) → form of absorption in that bar (v364, "All About Delta", [04:20]-[04:46], [09:11]) [REPEATED].
- **Poke below a recent low + strong negative Delta at price, then back up** = aggressive selling "met with absorption," passive buyers there (e.g. -507 on the bid) (v364, "All About Delta", [07:18]-[08:12]) [REPEATED].
- **Big fresh bid sitting at/just above the low** absorbing selling (1278 / 917 / 2522) = support (v357, "Identifying Big Buyers", [08:13]-[09:13]) [REPEATED].
- **POC on the extreme = enough stopping/absorbing volume** to "arrest this move down and potentially reverse it," even when raw contracts look small (e.g. 2700+1203 at low in tens; 103 lots on the offer at a low in crude) (v365, "Extreme POC", [08:25]-[08:54], [14:29]-[15:02]) [REPEATED].

## F. Stacked imbalance ideas
- **Stacked SELLING imbalances** (6-11 at a level) confirm strong supply / bearish bars (v356, [05:54]-[06:28]; v362, "Range vs Time", [05:44]) [REPEATED].
- **Stacked BUYING imbalances** off a low confirm bullish order flow, BUT he downgrades them when weak: at one bounce "stack buying imbalance coming in here although it's kind of weak right, it's 39 34 115" (v356, "Bearish Order Flow", [12:54]) [REPEATED].
- **Buying imbalances appearing in a RED candle near resistance** = sign of SUPPLY coming in (contrarian read): "when I see buying imbalances like this it's a sign to me… Supply coming into the market" (v356, "Bearish Order Flow", [15:21]-[15:57]) [ONCE] — see R.
- On a Delta footprint, imbalances are read as Delta-at-price sign (negative on bid side, positive on offer side) rather than diagonal (v364, "All About Delta", [03:23]-[03:55]) [ONCE].

## G. Delta / delta-divergence ideas
- **Delta should keep expanding in the direction of the move**: on a rally he wants the later bar's Delta bigger than the earlier (e.g. want 232→960, "you want to see the Delta keep expanding if positive"); a move where Delta shrinks/reverses is "weakening / shaky" (v356, "Bearish Order Flow", [03:50]-[04:54]) [REPEATED].
- **Into new lows you WANT strong negative Delta** confirming: "you're going into lows you want to see negative Delta… a strong negative Delta… -1286 was pretty strong" (v356, "Bearish Order Flow", [06:28]) [REPEATED].
- **Small Delta dismissed**: "minus seven… I'm not putting too much weight in it… one minute chart, an extra nanosecond it could have been positive five" (v356, "Bearish Order Flow", [04:54]-[05:27]) [ONCE].
- **Delta footprint = horizontal Delta-at-price** (bid vol minus offer vol at each level, NOT diagonal two-way). He prefers plain Delta-at-price over diagonal Delta (v364, "All About Delta", [01:01]-[02:45]) [REPEATED].
- **Supportive negative Delta on the way up** ("strong bids coming in," e.g. -349, -320, -304, -300 at highs) = bonus confirmation a rally won't drop; offers being lifted alone is "just one part of the equation" (v364, "All About Delta", [12:42]-[15:44]) [REPEATED].
- **Range-bar vs minute Delta can diverge**: same move showed positive Delta on an 8-range bar but negative Delta (a divergence) on the 1-minute bar — chart construction changes the Delta read (v362, "Range vs Time", [05:14]-[06:17]) [ONCE].
- **"Delta still matters"** — pushes back on a viewer who said Delta doesn't matter anymore, citing the failed early rally read (v356, "Bearish Order Flow", [19:18]) [ONCE].

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
- **Sweep through a psychological level with no counter-trade = bullish/bearish continuation signal**: "how do I know that's a sweep, because there's no counter trade" (40 vs 0, 64 vs 1); sweeping 4450 to the downside = "a good sign… I'd be excited" for more downside (v356, "Bearish Order Flow", [07:55]-[08:29]) [REPEATED].
- **Market finds liquidity → stops → reverses to hit it (fast market)**: "in a fast market, markets will stop when it finds liquidity then it's going to reverse and hit that liquidity" (v365, "Extreme POC", [07:02]-[07:28]) [REPEATED].
- **Resistance becomes support after a hold-above + retest-reject** (failed pullback into old resistance) (v357, "Identifying Big Buyers", [13:07]-[13:41]) [ONCE].
- **Failed breakdown / "what you expect doesn't happen"**: red value-area bar that instead closes & holds ABOVE its value area → rips up (v360, "Value Area Analysis", [07:21]-[08:49]) [ONCE].

## I. Trapped-trader ideas
- **Trapped shorts on a breakout above resistance** must cover → fuels the up-move (resistance→support) (v357, "Identifying Big Buyers", [13:07]-[13:41]) [ONCE].
- **Trapped buyers at a high**: on a Delta footprint, positive-Delta levels left at the top with aggressive selling underneath = offers lifted then sellers come = buyers stuck up top (implied) (v364, "All About Delta", [09:44]-[10:42]) [SPECULATIVE].
- He explicitly ties Delta-at-price extremes to "absorption or potentially trapped traders… at swing highs or swing lows" (v364, "All About Delta", [06:45]-[07:18]) [REPEATED].

## J. Entry triggers (the exact "go" event)
- **Get short when supply confirms after a failed bounce into resistance**: after inside bars and signs of supply, "it's getting short at 14 and I think is a safe bet… I said get short here at 14 if you could" (v356, "Bearish Order Flow", [15:57]-[16:30]) [ONCE]. NEEDS-OPERATIONALIZATION (level-specific, qualitative trigger).
- **On a range chart, enter as soon as the second bearish bar prints**: "after the second bar you should already be convinced… looking to get short at 108.45" — vs ~108.40 on the time chart, ~5 ticks earlier (v362, "Range vs Time", [06:51]-[07:58]) [REPEATED].
- **Get in BEFORE the expansion bar off the low**: "you should have been noticing this [big bid] to get in in this bar before the market puts in this bar that goes from 76 up to 84" (v357, "Identifying Big Buyers", [10:21]-[10:51]) [ONCE].
- **Untested value area is the "go" signal**: "the next bar doesn't even trade back into that value… that's my go sign to be getting short" (v359, "NQ vs ES", [08:23]-[08:51]) [REPEATED].
- Core principle: **act on order flow the moment you see it, not on a higher time frame** ("the best way to use it is as soon as you see it happening") (v362, "Range vs Time", [07:23]-[07:58]) [REPEATED].

## K. Confirmation — what SHOULD happen quickly after entry/trigger
- **Price should NOT come back to the support/resistance levels you drew**: after big bids off the low, "the market doesn't even come back anywhere near those levels" (73.25, 70) (v357, "Identifying Big Buyers", [10:21]-[10:51]) [REPEATED].
- **The move should happen NOW, not after going sideways**: "you're looking for a move to happen now, not market goes sideways and then makes that shift… the order flow you're seeing has the most importance now" (v359, "NQ vs ES", [06:28]-[06:55]) [REPEATED].
- **After a reversal bar at a swing low, expect price to "pop up"** quickly (v364, "All About Delta", [06:16]) [ONCE].
- **The untested value area should NOT be retested in the very next bar** (his definition of "immediately") (v360, "Value Area Analysis", [05:44]-[06:13]) [REPEATED].

## L. Invalidation — what should NOT happen / what kills the thesis
- **Value area gets traded back into / accepted (next bar)** = not your setup; he only acts on value areas "not retested immediately… in the next bar" (v360, "Value Area Analysis", [05:11]-[06:13]) [REPEATED].
- **Inside bar / doji back inside the prior bar's value after an expansion bar** = "not a good sign," weakens a continuation (v356, "Bearish Order Flow", [13:58]-[14:25]) [ONCE].
- **A POC-on-extreme in the wrong context is invalid**: sideways activity (just-traded level) or a red POC-extreme while still selling INTO the low (not at a swing) = don't take it (v365, "Extreme POC", [05:13]-[06:36]) [REPEATED].
- **Trade taking heat / going sideways for 5-10 min with no follow-through** = get out: "that's my sign, just get out… it's going to suck up trading capital and emotional capital" (v359, "NQ vs ES", [05:28]-[06:55]) [REPEATED].
- **Thesis survives an unlucky stop if the move resumes immediately**: if stopped at 66 and price trades right back down to 45-46, "nothing has really changed… I should still want to be bearish"; but if price stayed up at 60-65 he would NOT re-short (v368, "Unlucky Trade", [05:24]-[06:26], [08:28]-[10:58]) [REPEATED].

## M. Stop / risk / target / trade management
- **20-tick stop on YM**: short at 46, stop ~66 (20 ticks); on a re-entry short at 45, stop again ~65 (v368, "Unlucky Trade", [01:25]-[01:56], [09:26]-[09:57]) [REPEATED].
- **Always use a stop to define risk**: without it, "short at 46, trades to 66, next thing it's 80 — instead of a 20-tick loss you're looking at 30-40 ticks" (v368, "Unlucky Trade", [09:26]-[09:57]) [REPEATED].
- **One-tick-better entry would have avoided the stop**: "if I had a one tick better entry at 47, I wouldn't have been stopped out at 66 because my stop would be at 67" (v368, "Unlucky Trade", [10:29]) [ONCE] — entry precision matters at the tick level.
- **More volatile markets (NQ) require WIDER stops**: "if you're trading a market that has more volatility you're going to need wider stops to begin with" (v359, "NQ vs ES", [05:04]-[05:28]) [REPEATED].
- **Time-in-trade as a management metric**: he bases decisions on how long he's been in; 30-second chart chosen partly so he can gauge "5 minutes / 10 minutes" of no progress = exit (v359, "NQ vs ES", [05:28]-[06:28]) [REPEATED].
- **Profit-taking examples were small/quick** (NQ: short 909, target 899.5; ES-style scalps) — illustrative, not rules (v359, "NQ vs ES", [04:35]-[05:04]) [ONCE].
- **Re-entry after sound-analysis stop is legitimate, revenge trading is not**: re-shorting because analysis still says down ≠ revenge; revenge = "jumping in on trades that make no sense" (v368, "Unlucky Trade", [02:22]-[02:54], [06:26]) [REPEATED].

## N. Context filters (session/time, regime/volatility, levels)
- **Psychological / round-number levels** (4400 "the big figure," 4450) are key reference points; on a flow-driven day they get blown through with low volume, which itself confirms strength of the move (v356, "Bearish Order Flow", [01:37]-[02:03], [07:55]-[10:19], [17:37]-[18:51]) [REPEATED].
- **Prominent Points of Control referenced from prior session / pre-open** act as resistance (68.25 area) (v356, "Bearish Order Flow", [02:57]-[03:24]) [ONCE].
- **Opening price** used as a target/pivot ("below this yellow line which was the opening price") (v368, "Unlucky Trade", [04:22]-[04:51]) [ONCE].
- **News/event regime**: Powell at Jackson Hole created a quiet pre-event market then volatility; many examples are FED-driven and he flags fills may be missed in fast markets (v357, [00:00]-[00:53]; v359, [03:34]-[04:06]; v365, [07:02]-[10:02]) [REPEATED]. Pre-NFP (payrolls) Thursday = expecting a quiet session (v368, [06:26]-[06:56]) [ONCE].
- **Instrument selection / chart sizing by market** (see O): ES vs NQ; treasuries (10yr/5yr/bonds/ultras) 4-range exclusively; gold/currencies/ES 8-range; YM 10-range; NQ 30-second time chart (v359; v362; v365) [REPEATED].
- **Value area %**: he uses 70% (purists use 68%); differences are usually 1-2 ticks, more on smaller timeframes (v360, "Value Area Analysis", [00:58]-[04:32]) [REPEATED].
- **Fast-market regime caveat**: in fast markets footprint data overwhelms NinjaTrader ("fire hose"), range bars hide that you're in fast mode, and fills slip 3-6 ticks (v362, "Range vs Time", [07:58]-[11:03]) [REPEATED].

## O. Directly testable / measurable variables
- **Value area = 70%** (his default); 68% = statistical alternative (mean ± 1 SD); difference typically 1-2 ticks (v360, [00:58]-[04:32]). TESTABLE (exact).
- **"Strong" big bid/offer threshold on a 1-minute ES chart: > 1000 contracts at one price level** ("anything over a thousand at one price level is big"); examples 1278, 917, 2522, 1985 (v357, "Identifying Big Buyers", [07:42]-[08:13]). TESTABLE but he adds "double/triple/5× the surrounding prints" → relative. NEEDS-OPERATIONALIZATION (recency/context multiplier).
- **He expected >1000 on the bid to defend a psychological level; only 454-856 traded → level failed** (v356, [06:53]-[07:55], [17:37]). Suggests bid-size-vs-level threshold. NEEDS-OPERATIONALIZATION.
- **"Strong" Delta-at-price on an 8-range chart: > ~250 (prefers >200-250); background is 50-150**; examples 370, 422, 320, 304 strong; -147 "on the higher end" (v364, "All About Delta", [13:16]-[15:44]). NEEDS-OPERATIONALIZATION (relative to background).
- **Strong negative Delta into lows: -1286, -1410** judged strong vs "last 10-15 minutes" (v356, [06:28], [08:29]). Relative — NEEDS-OPERATIONALIZATION.
- **"Big bid off the low" location: within ~5 handles of the low (prefer) vs 15 handles (worse); 3rd-4th bar off the low** (v357, [10:51]-[14:37]). TESTABLE (handles + bars off low).
- **Range-bar tick counts**: 8-range = 9 ticks/bar; 4-range used on treasuries/gold/slow markets; 6 or 10 also cited (v362, [03:22]-[03:48], [11:42]; v365, [02:20]-[03:14]). TESTABLE.
- **Tick aggregation = 4** (set in software) to clean up NQ footprint (v359, "NQ vs ES", [11:09]-[12:17]). TESTABLE.
- **Chart choices by instrument**: ES 30-sec or 1-min or 10-range; NQ 20-range or 30-sec; treasuries 4-range; YM 10-range; gold/currency 8-range; euro 8-range (NOT 4) (v359; v362; v365). TESTABLE.
- **Stop size: 20 ticks on YM**; wider for higher-volatility instruments (v368, [01:25]; v359, [05:04]). TESTABLE (instrument-specific).
- **Time-in-trade exit: ~5-10 minutes of no follow-through** (v359, [05:28]-[06:28]). TESTABLE.
- **Sweep detection: aggressive volume at a level with no counter-trade** (e.g. 40 vs 0, 64 vs 1) (v356, [07:55]-[08:29]). TESTABLE (one-sided print).
- **POC-on-extreme: heaviest-volume price level located at the bar high (red) or bar low (green)** (v365, [03:46]). TESTABLE.
- **Delta tail: red bar, negative Delta on all levels except a positive Delta at the top** (and bullish mirror) (v364, [08:44]). TESTABLE.

## P. NinjaTrader / indicator implementation ideas he mentions or implies
- **Delta footprint mode** in Orderflows Trader: Ladder Content → Cell Text → choose Delta (vs Volume vs Diagonal Delta), Apply/OK; negative Delta shown on left (bid) side, positive on right (offer) side (v364, "All About Delta", [02:09]-[03:55]). Implementable: per-price Delta sign/coloring.
- **Tick aggregation setting** (set to 4) to merge ticks into one footprint level for thin markets like NQ (v359, "NQ vs ES", [11:09]-[12:17]).
- **Value area % is a chart input** ("value area in percent," set 70 or 68) on both footprint and volume profile (v360, [02:41]-[05:11]).
- **Auto-detect "untested value area" (not retested in the immediately next bar)** and color it (red=bearish, green=bullish) → his core directional zone (v360, [05:11]-[09:17]; v359, [08:23]). Strong indicator candidate.
- **Detect POC-on-extreme** (POC at bar high on red / bar low on green) AND require it be at a swing high/low after a move (context filter) (v365, [03:46]-[06:07]). Strong indicator candidate; the context gate is essential.
- **Detect Delta tail** pattern (v364, [08:44]). Indicator candidate.
- **Flag big fresh bid/offer** = size > X at one level that is fresh (in a just-traded area near the low) vs resting liquidity (price not traded recently) — needs a "freshness" / recency rule (v357, [08:13]-[12:37]).
- **Fast-market guard**: in fast markets the footprint corrupts and fills slip — implies a volatility/fast-market detector to suppress signals or widen stops (v362, [07:58]-[11:03]).
- Range vs time chart construction materially changes Delta and imbalance reads — indicator results are chart-type dependent (v362, [05:14]-[06:17]). Design caveat.
- (Off-model) Ninjacators "Ultimate Pro Pattern Bundle" — cup-and-handle, Elliott wave, harmonic patterns — used as a SEPARATE pattern screen layered with order flow confirmation (v366, throughout). Sponsored; not his order-flow model.

## Q. Notable verbatim quotes (3-10)
1. "You want to see the Delta keep expanding if positive… it's still a positive but it's just not as strong" (v356, "Bearish Order Flow", [04:23]).
2. "How do I know that's a sweep is because there's no counter trade… it sweeps through there, to me that's a good sign, I'd sort of be excited." (v356, "Bearish Order Flow", [08:29]).
3. "This 25-22 sticks out like a sore thumb, this 1278 917 stick out like a sore thumb. You should have been noticing this." (v357, "Identifying Big Buyers", [09:48]).
4. "Really the best part… you want to see it is right off the low of the day, an area you've just been trading… three bars off the low, fourth bar off the low. Those are the trades you've got to pay attention to." (v357, "Identifying Big Buyers", [13:41]-[14:37]).
5. "The next bar doesn't even trade back into that value… I know that this is a bearish sign… that's my go sign to be getting short." (v359, "NQ vs ES", [08:23]).
6. "What you expect to happen doesn't happen but the opposite happens — that's your opportunity." (v360, "Value Area Analysis", [07:51]).
7. "When I got that strong selling going down into a low area… followed up with aggressive buying coming up here, this is like a reversal bar to me… I'd be looking for this market to pop up." (v364, "All About Delta", [05:51]-[06:16]).
8. "Not just the offers being taken out… I'd like to also see bids coming in, strong support of buying… that's the cherry on top of what you're looking for." (v364, "All About Delta", [12:42]-[15:44]).
9. "They got no more bullets, they're done, their gun is empty… and then the market works its way back up." (v365, "Extreme POC", [15:02]).
10. "You want to put it in context… see it coming in after a move… it's not just about taking every single one that appears." (v365, "Extreme POC", [05:39]-[06:07] / [15:38]).

## R. Contradictions / nuances
- **Divergence is NOT a setup**: a new low with positive Delta, by itself, "is not a system" — directly contradicts a common order-flow belief; he says buying at a low is often just profit-taking by shorts (v356, "Bearish Order Flow", [11:51]-[12:19]) [ONCE]. Important: requires absorption + reversal context, not bare divergence.
- **Buying imbalances can be BEARISH**: stacked BUYING imbalances appearing in a RED candle at resistance = SUPPLY entering, not demand (v356, [15:21]-[15:57]) [ONCE] — context (location + candle color) flips the meaning.
- **Small raw volume can be the strongest signal**: 17 lots / 41 contracts / 23 contracts at an extreme can reverse a market because it exhausts the aggressive side — "I'm not saying there's so much selling… it was enough to absorb whatever buying was there" (v365, [10:02]-[12:14]) [REPEATED]. Size is judged by EFFECT and CONTEXT, not absolute.
- **"Strong" is always relative** to the last 10-15 minutes / surrounding prints / the specific market & chart type — no fixed contract threshold transfers across instruments (v356, [06:28]; v364, [14:43]) [REPEATED].
- **Delta reading is chart-construction-dependent**: the same move can show +Delta on a range bar and −Delta (a divergence) on the 1-minute bar (v362, [05:14]-[06:17]) [ONCE].
- **"It depends" on instrument**: chart type and stop width must be tailored per market (ES distributes volume → almost no extreme POCs; treasuries thick → no slippage; NQ thin → slippage, wider stops) (v359; v362; v365) [REPEATED].
- **Luck/randomness caveat**: a sound setup can be stopped to the tick by an unrelated one-lot or a transient big buyer; he refuses to read "stop gunning" into it and re-enters on the SAME thesis when the move resumes immediately (v368, "Unlucky Trade", [01:56]-[09:26]) [REPEATED] — execution noise ≠ thesis failure.
- **Higher-time-frame skepticism**: he argues AGAINST the common "look at higher time frame" advice for order flow — the freshest order flow has the most importance and you should act as soon as you see it (v362, "Range vs Time", [07:23]-[07:58]) [ONCE].

## Coverage note
Rich for the reversal model: v356 (trend-day-down read, Delta expansion, sweeps, psych levels), v357 (big-buyer-off-the-low absorption, sticks-out-like-a-sore-thumb grading, resistance→support), v360 (untested-value-area go-signal, "opposite happens"), v364 (Delta footprint, Delta tail, absorption, reversal bar, cherry-on-top bids), v365 (POC-on-extreme as stopping volume + context gating, exhaustion language). Thin/tutorial: v359 and v362 are chart-type comparisons (useful for instrument/chart-sizing context filters but light on reversal triggers). v366 is a sponsored Ninjacators ad — mostly off-model (technical patterns), only the "order flow as confirmation" framing is on-model. v368 is psychology/trade-management (stops, re-entry, luck) — good for M and L, no new reversal signal. No "A+/textbook/perfect" grading words in this chunk; primary grading axis is relative "strong" + "sticks out like a sore thumb" + location ("off the low," "in context"). All numeric "strong" thresholds are relative and marked NEEDS-OPERATIONALIZATION.
