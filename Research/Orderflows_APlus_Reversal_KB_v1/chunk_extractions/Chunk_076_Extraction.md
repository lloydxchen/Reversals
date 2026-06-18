# Chunk 076 Extraction
- Source chunk: Chunk_076_Orderflows_Transcripts.md
- Transcripts covered:
  - v232 — How To Automate Orderflows Indicators With Markers From The Indicator Store (2022-02-08)
  - v233 — Orderflows FlowBreaks Set Up With Markers From The Indicator Store (2022-02-14)
  - v235 — Orderflows Trader 5.0 Trading Value Area Zones With OFT5.0 For NinjaTrader 8 (2022-02-25)
- Overall content value: mixed

---

## A. Setup types & names he uses

- **Value Area Zone reversal** (bearish): price rallies into an exposed/virgin red value area zone drawn from a prior red candle; POC near bottom of that candle; zone acts as resistance; look for market to test and reject zone from below. (v235, "Trading Value Area Zones", [14:20]) [ONCE]
- **Value Area Zone reversal** (bullish): price pulls back into an exposed green value area zone from a prior green candle; zone acts as support; look for market to test and hold, then move up. (v235, [13:48]) [ONCE]
- **Bullish EVA (Exposed/Exceptional Value Area)** — blue-colored zone in OFT5.0; distinct from standard green zone; specifically noted as a separate grade of bullish setup. (v235, [22:45]) [ONCE]
- **Bearish EVA** — drawn in darker red (opacity 50 vs 20 for normal zones); signals higher-quality bearish reversal off value area. (v235, [23:25]) [ONCE]
- **Bearish Slingshot POC within a value area zone** — combination of slingshot POC and zone drawn out together in same bar; noted as a compound confirmation. (v235, [18:00]) [ONCE]
- **Two consecutive same-color value area gaps ("gap and go")** — two bars in a row with no overlap between value areas (gap between them); this is a directional trigger. (v235, [05:15]) [REPEATED]
- **Exhaustion print at zone** — when price tries to re-enter a value area zone and produces an exhaustion print (small number e.g. "five"), confirms rejection; textbook combination. (v235, [18:00]) [ONCE]
- **Failed indicator signal / order-flow divergence during live trade** — positive delta while short; rising POC while short; buying imbalances while short = exit signal, not a new setup per se. (v232, [10:11]) [REPEATED]
- **Automated entry via Markers ("partially automated")** — using Markers Plus/Force + Markers Copy to execute signal entries automatically while managing the trade manually. (v232, [03:32]) [REPEATED]

---

## B. Tiering / grading language ← HIGH PRIORITY

- **"The type of bar you want"** / **"those are the good trades to have"** — description of bars where entry is taken and take-profit fills within the same bar, or within 10 seconds; implies these are A+ quality. (v235, [27:04]) [ONCE]
- **"A nice trade setup"** — bullish EVA + slingshot POC together; explicitly called this. (v235, [27:35]) [ONCE]
- **"Generally pretty clear which way you should be"** — when two consecutive value area gaps appear in same direction, direction confidence is high. (v235, [05:15]) [ONCE]
- **"A little bit more effective when there's space in between"** — zones with a gap between two consecutive same-colored bars are preferred over single-bar zones. (v235, [15:25]) [ONCE]
- **"I just find them a little bit more effective"** / preference for multi-bar zones vs single-bar zones; single-bar zone could just be market going sideways. (v235, [15:25]) [ONCE]
- **Zone invalidation language**: "invalidated right away" — if bar closes on the wrong side of a stacked imbalance or zone, signal is immediately dead. (v235, [09:06]) [REPEATED]
- **"Zones work great in normal market conditions"** — explicit caveat that value area zones degrade in high-volatility regimes. (v235, [32:46]) [ONCE]
- **"Borderline" / not enough follow-through** — when a nice bullish signal (positive delta, slingshot POC) produces no upward price movement the next bar, labeled as failing; not a graded tier per se but pattern of disqualification. (v235, [20:41]) [ONCE]
- Partially automated vs fully automated framing: Mike explicitly prefers "partially automated" (auto entry, manual exit) as superior; "fully automated" = drawdown risk, no reading of road signs. (v232, [03:32]) [REPEATED]

---

## C. Order-flow story & psychology per setup

- **Zones as supply/demand memory**: Prior value areas represent where transactions occurred; unfilled/exposed zones attract price back because traders who transacted there are underwater or need to re-engage. (v235, [01:33]) [REPEATED]
- **"Looking for liquidity"**: In fast/volatile moves, price slices through zones because there's insufficient size on the other side — "people are just buying whatever's there." Thin volume at price level = zone doesn't hold. (v235, [35:00]) [ONCE]
- **Absorption at prominent POC at extreme**: 2,500–3,500 contracts at 4330 (ES); described as bearish stopping volume; market came off, but then tested that level three times before breaking through. (v235, [39:34]) [ONCE]
- **Positive delta while short = bearish trade failing**: POC moving higher, buying imbalances appearing, and no aggressive selling delta = trapped short; "you're not getting paid." Exit early rather than ride to stop. (v232, [10:11]) [REPEATED]
- **Order-flow "road signs"**: When you're in a trade, the order flow tells you whether the thesis is alive; positive delta on a short = bearish thesis dying even if price hasn't moved against you yet. (v232, [09:41]) [REPEATED]

---

## D. Exhaustion clues

- **Exhaustion print of "five" at zone**: price tries to re-enter a bearish value area zone, produces exhaustion print of 5 on the attempt, fails to close back inside zone = confirmation of rejection. (v235, [18:00]) [ONCE]
- **"Couldn't muster a rally"** after bullish signals — nice strong positive delta bar (+1200) followed by bar that can't go higher and stays inside previous bar's value area = exhaustion/failure of bullish aggression. (v235, [20:41]) [ONCE]
- **Red bar exhaustion print "four"** at end of attempted rally — explicitly called out: "red bar but a red bar with an exhaustion print four." (v235, [21:17]) [ONCE]
- Prior exhaustion clues from digest remain valid; these add context of exhaustion specifically at value area zone tests.

---

## E. Absorption clues

- **Big size at extreme POC** — 2,500–3,500 contracts at a single price level (ES); bearish prominent POC + bearish ratio = stopping volume + absorption. Market tested 3x before breaking. (v235, [39:34]) [ONCE]
- **Light volume blowing through a level** — imbalances of "1 vs 10", "3 vs 41", "11 vs 17" in ES during volatile move = no absorption, no defense; market moving on thin liquidity, zones will not hold. (v235, [34:20]) [ONCE] NEEDS-OPERATIONALIZATION (specific number given for ES context only)
- Absorption rule from digest (positive delta at a low = supply absorbing) reinforced by v235 trade management examples.

---

## F. Stacked imbalance ideas

- **Stacked imbalance validation rule restated explicitly**: "If I have a stacked buying imbalance I expect the next bar to be trading above it. If the next bar is trading below it, that signal is invalidated right away." (v235, [12:48]) [REPEATED]
- **Stacked buying imbalance shown for directional confirmation** on a downtrending chart — used to show context where the signal fails (next bar below it = not a buy signal in that context). (v235, [12:14]) [ONCE]
- **Analogy drawn**: value area zones behave like stacked imbalances in terms of next-bar validation logic. (v235, [09:06]) [ONCE]

---

## G. Delta / delta-divergence ideas

- **Positive delta while short = exit signal**: string of positive deltas over 30 minutes while holding a short position = "a negative sign for your position." Should exit rather than wait for full stop. (v232, [19:17]) [REPEATED]
- **Delta surge example**: "nice strong positive delta of plus 1200 but the next bar couldn't even go any higher and it just stayed inside the previous bar's value area — that's not bullish." Strong delta alone is insufficient without price follow-through. (v235, [20:41]) [ONCE]
- **POC moving higher while short** = directional confirmation against the position; used alongside delta to decide early exit. (v232, [10:42]) [REPEATED]
- **"Delta's going up, point of controls going up, delta surge going on"** as trend confirmation (bullish trend identification, not a reversal signal). (v235, [04:08]) [ONCE]
- **Bearish prominent POC** explicitly used to stay in a short trade: "I can stay in the trade... comes down makes a new lower low." (v235, [19:33]) [ONCE]

---

## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas

- **Zone invalidation on close above/below**: red zone (resistance) becomes irrelevant if bar closes above it; green zone (support) becomes irrelevant if bar closes below it. Trade above resistance = invalidated. (v235, [09:06]) [REPEATED]
- **Momentum blowing through zones on thin volume**: during Biden-era news shock (ES 2pm), 15–20 point bars on very thin volume blew through multiple zones; explicitly warns: zones don't hold in such conditions. (v235, [35:00]) [ONCE]
- **"Three times tested"** at prominent POC (3,500 lot level): market tests 3x, finally breaks through on the 3rd attempt. Pattern noted but not given a grading word. (v235, [40:14]) [ONCE]

---

## I. Trapped-trader ideas

- **Positive delta while short = trader is trapped**: Mike explicitly frames himself as potentially trapped when delta stays positive while he's short — "you're not getting paid." (v232, [10:11]) [REPEATED]
- **"Fully automated trader" gets stopped out vs partial trader exits early**: fully automated trader who doesn't read order flow gets stopped at full loss; partial trader exits 1 point earlier by reading road signs. (v232, [11:13]) [REPEATED]
- No new trapped-counterparty squeeze mechanics beyond digest.

---

## J. Entry triggers (the exact "go" event)

- **Two consecutive same-direction value area gaps** (both red, or both green, with a gap between value areas) = directional trigger; aggressive entry is when 2nd gap bar is forming (before it closes): "you can just get in right away... I already got strong signs." (v235, [26:03]) [ONCE]
- **Value area zone test from correct side** (market moves away, then returns and tests zone from the "right" direction) = entry trigger; entry is when zone is hit/tested. (v235, [14:20]) [ONCE]
- **Exhaustion print at zone** = additional confirmation for entry at zone test. (v235, [18:00]) [ONCE]
- **Automated entry via Markers**: Flow Breaks indicator uses "triangle up" (blue) for longs, "triangle down" (dark red) for shorts; Markers Copy set to "calculate on each tick" triggers entry at market. (v233, [03:08]) [ONCE]
- **For partially automated**: "set semi-automatic" on Markers so only the next signal fires, then Markers auto-resets. (v232, [29:12]) [ONCE]

---

## K. Confirmation — what SHOULD happen quickly after entry/trigger

- **"Follow-through order flow"**: "You need the next bar to have that follow-through order flow... preferably in the next bar, if not the next bar then the bar after it. I usually give it two bars." (v235, [20:06]) [REPEATED]
- **Three-bar grace period in evening session**: "if it's a slow market or if it's at night/evening session I'll give it three bars because a lot of times at night session there's just not much activity." (v235, [20:41]) [ONCE — specific to night/evening session]
- **Next bar should close on the correct side of a value area zone**: if long, next bar should be above zone; if short, next bar should be below zone — same logic as stacked imbalance validation. (v235, [12:48]) [ONCE]
- **Instant fill at take profit within same bar** = ideal confirmation ("those are the good trades to have"). (v235, [27:04]) [ONCE]
- **Slope of EMAs/price series** as trade management filter: if slope stays negative while short, stay in trade; if slope turns positive, consider exit. (v232, [53:40]) [ONCE]

---

## L. Invalidation — what should NOT happen / what kills the thesis

- **Bar closes above a red zone** = resistance invalidated; no longer looking for short. (v235, [09:06]) [REPEATED]
- **Bar closes below a green zone** = support invalidated. (v235, [13:17]) [REPEATED]
- **Positive delta while short, sustained over multiple bars** = thesis invalidated; exit early. "For a half hour being in the trade you know that's a negative sign." (v232, [19:52]) [REPEATED]
- **POC moving in wrong direction while in trade** = invalidation signal (rising POC while short). (v232, [10:42]) [REPEATED]
- **Imbalances in wrong direction** while in trade (buying imbalances appearing while short). (v232, [10:11]) [REPEATED]
- **Strong bullish delta + slingshot POC + no higher price** = bullish signal failed; "no bullish follow-through order flow." (v235, [20:41]) [ONCE]
- **Extreme volatility / thin volume bars** = zone-based levels not reliable; "when the monopoly board is thrown off the table, things can get wild." (v235, [32:46]) [ONCE]
- **"Doji candle" (open = close)** = zone drawn in gray, not directional; cannot use as bullish or bearish zone. (v235, [10:06]) [ONCE]

---

## M. Stop / risk / target / trade management

- **Stop just above/below the zone**: for shorting a red zone — stop just above the zone; for buying a green zone — stop below the zone. Risk = zone width + 1 tick. (v235, [14:50]) [ONCE]
- **Example risk/reward stated verbatim**: selling at 23, stop at 24–25 (2 points), target 5–6 points = "that's 2.5–3 to one." (v235, [14:50]) [ONCE]
- **"Bigger zone = more wiggle room but bigger stop"**: 9–10 point zone in ES = ~9-point stop; 3-point zone = ~3.5-point stop. He notes people often prefer tighter stops. Research on whether bigger zones hold better is "inconclusive." (v235, [43:47]) [ONCE]
- **Partially automated exit management**: once in trade, move stop to break even, watch delta/POC/imbalances; exit at scratch or small loss if order flow turns against you rather than waiting for full stop. (v232, [11:13]) [REPEATED]
- **Limit order fill problem**: using limit orders at take-profit in queue-based system = often don't fill (within 1 tick but not filled); Mike repeatedly demonstrates scratching at break-even rather than missing fill and taking full loss. (v232, [14:32]) [REPEATED]
- **Max daily profit/loss in Markers**: default 500 per side; Mike changes to 5,000 for normal-size contracts; 500 may be "plenty" for micros. (v233, [03:34]) [ONCE]
- **~10-minute time stop for sideways trade** reinforced: position going sideways for "already 15 minutes... just not going anywhere." (v232, [1:00:06]) [REPEATED]
- **One take-profit then re-entry**: after hitting target off first signal, next short signal taken for second trade. (v233, [16:10]) [ONCE]

---

## N. Context filters (session/time, regime/volatility, levels: VWAP, value area, POC, prior high/low, open, news, which markets/instruments)

- **Avoid trading zones in extreme volatility**: "zones work great in normal market conditions but when the monopoly board is thrown off the table, things can get wild." When seeing 15–20 point bars with very thin volume, zones will not hold. (v235, [32:46]) [ONCE]
- **Evening/night session = slower follow-through**: explicitly allows 3-bar grace instead of 2-bar grace at night. (v235, [20:41]) [ONCE]
- **Overhead resistance zones from earlier in the day** must be acknowledged even when entering a long: "I've got areas that the market could struggle to get through... I have to grip my teeth." (v235, [27:35]) [ONCE]
- **News events (Biden speech example at 2pm ET)**: caused massive volatility; zones became unreliable; confirms existing digest note to avoid news. (v235, [32:10]) [ONCE]
- **Zone color = candle color** (red candle → red zone = resistance; green candle → green zone = support; doji → gray zone = non-directional). (v235, [07:28]) [ONCE]
- **Market-selection for automation**: "find the market that resonates with you the most... not everyone can trade Nasdaq... you know when you're using automated trading find the market you can get dialed in on." (v232, [58:29]) [ONCE]
- **NQ volatility warning**: "a lot of traders can't deal with the volatility" of NQ; implies NQ is lower quality for automation. (v232, [58:29]) [ONCE]
- **Crypto order flow compatibility**: Mike notes crypto "follows order flow quite beautifully" and hopes NinjaTrader adds crypto exchange access. (v232, [1:03:04]) [ONCE]

---

## O. Directly testable / measurable variables

- **Consecutive same-direction value area gaps**: number = 2 sufficient for directional signal; 2 in a row without any overlap = "already pretty clear"; 3rd adds more confirmation. (v235, [05:15]) [ONCE]
- **Value area zone width** (ES context): small zone ~3 points stop; large zone ~9–10 points stop; research on size vs hold rate is "inconclusive." (v235, [43:47]) [ONCE] NEEDS-OPERATIONALIZATION
- **Follow-through window**: 2 bars standard; 3 bars for night/evening session. (v235, [20:06]) [REPEATED]
- **Exhaustion print threshold at zone**: example given = "five" (ES/index context). (v235, [18:00]) [ONCE] — consistent with known digest thresholds of 9–10 for index, 5 for FX
- **Bearish prominent POC + ratio at 30+ tick level**: 2,500–3,500 contracts (ES context); bearish ratio + POC at extreme = stopping volume. (v235, [39:34]) [ONCE]
- **Delta polarity sustained over 30 minutes against position** = exit signal. (v232, [19:52]) [ONCE] NEEDS-OPERATIONALIZATION (30 min is anecdotal example)
- **Light volume at price level** during volatile move: imbalances "1 vs 10", "3 vs 41" (ES) = no liquidity, zones unreliable. (v235, [34:20]) [ONCE] NEEDS-OPERATIONALIZATION
- **Value area zone color (candle-based)**: red candle = red zone = resistance; green = support; doji = gray = non-directional; EVA = blue (bullish) or dark red (opacity 50 vs 20) (bearish). (v235, [07:28]) [ONCE]
- **Markers copy "calculate on each tick"**: required setting for accurate signal replication in automation. (v233, [04:30]) [ONCE]
- **Slope filter for automation**: if slope of a moving average is negative → only shorts; positive → only longs. (v232, [45:45]) [ONCE]

---

## P. NinjaTrader / indicator implementation ideas he mentions or implies

- **OFT5.0 value area zones**: draws colored zones (red/green/gray) per candle color; EVA zones drawn in blue (bullish) or darker red (opacity 50 vs 20 for normal zones). (v235, [23:25]) [ONCE]
- **Zone color logic**: candle color determines zone color; doji (open=close) → gray zone drawn out. (v235, [10:06]) [ONCE]
- **"Two consecutive value area gaps"** is a measurable binary condition that can be coded: check if value area of bar N does not overlap value area of bar N-1, same candle color, two consecutive bars. (v235, [05:15]) [ONCE]
- **Markers Plus / Force + Markers Copy setup for Flow Breaks**: specific step-by-step instructions; use "triangle up" (blue) for long plot, "triangle down" (dark red) for short plot; both calculated "on each tick"; no fast signal mode for Flow Breaks specifically (differs from other indicators). (v233, [01:21]) [ONCE]
- **Flow Breaks does NOT use tick replay** (unlike Order Flow Trader 3.0); can run on normal bar chart; manage trade from separate footprint chart. (v233, [06:57]) [ONCE]
- **Flow Shifts requires tick replay** (Orderflows indicator); affects how historical signals are calculated. (v232, [25:45]) [ONCE]
- **Markers slope indicator**: measures slope of any input series (EMA, VWAP, etc.); can be used as a filter ("slope > 0 → long enabled; slope < 0 → short enabled"). (v232, [43:38]) [ONCE]
- **Semi-automatic mode in Markers**: fires only the next detected signal, then resets; useful for "I need to step away for 5 minutes but want the next signal taken." (v232, [29:12]) [ONCE]
- **Max daily profit/loss parameter** in Markers: disables trading if daily P&L limits hit. (v233, [03:34]) [ONCE]
- **"Tick replay" for historical signal reconstruction**: without tick replay, refreshing chart wipes intrabar signals; workaround is "playback current day" to replay current day tick-by-tick. (v232, [25:45]) [ONCE]
- **Research on zone size vs reliability** is ongoing and currently inconclusive; suggests a future testable variable. (v235, [43:12]) [ONCE]
- **Potential future feature**: automatically "undraw" an invalidated zone when price closes on wrong side (noted as feature request, not yet implemented). (v235, [09:06]) [ONCE]

---

## Q. Notable verbatim quotes

1. "You need to be dialed in on your chart selection, your stock level and take profit. In order to automate order flow you need to identify trade setups — because ultimately what you're doing is telling the computer the reason to buy, the reason to sell." (v232, "Automate Orderflows With Markers", [12:51])

2. "You know if you're in a trade and you're not getting things following through in the order flow... I'm getting short off this bar and then I just see it goes sideways... I see positive delta creep in, I don't see big negative delta, I see point of controls going higher, I see buying imbalances — well that's not what I want to see when I'm in a trade." (v232, [10:11])

3. "For a half hour of being in the trade you know that's a negative sign for your position — if you're short and instead you're seeing positive deltas that's not a good sign of the market going to go in your favor." (v232, [19:52])

4. "Zones work great in normal market conditions but when the monopoly board is thrown off the table, things can get wild." (v235, [32:46])

5. "When I have two of these [consecutive same-direction value area gaps] in a row it's generally pretty clear which way you should be on the market." (v235, [05:15])

6. "Those are the type of bars that you get in and filled in the same bar — that's filled with your take profit not your stop. Those are the good trades to have." (v235, [27:04])

7. "I usually give it two bars [for follow-through], once in a while... if it's a slow market or if it's at night/evening session I'll give it three bars because a lot of times at night session there's just not much activity." (v235, [20:20])

8. "The bigger the zones they tend to hold a bit better but at the same time since it's a bigger area you have more space... it's one of these things where I got nine points of wiggle room and nine points of wiggle room is a lot." (v235, [43:47])

9. "You should be able to recognize that just by seeing — well it's trading above the resistance area, so it's invalidated." (v235, [09:06])

10. "Learn how to read the road signs — because why should you get stopped out up here at 05 when you could just see it going along here... you're not getting paid." (v232, [10:42])

---

## R. Contradictions / nuances (anything that conflicts with common belief, with his other statements, or that is conditional/"it depends")

1. **"Follow-through within 2 bars" has a stated exception for evening/night session** — 3 bars allowed at night due to low activity. This refines the known "2 ticks over 2 bars" rule: it is explicitly session-dependent. (v235, [20:41]) [ONCE]

2. **Red (bearish) candle with hammer pattern** — Mike explicitly warns against automatically treating it as bullish reversal just because candlestick literature calls it a hammer: "this is where using your brain has got to come in handy... people think I should be getting short [because it's a red candle]." Zone color follows candle close color, not candlestick pattern. (v235, [08:01]) [ONCE]

3. **Large zone size vs hold rate is inconclusive** — intuition says bigger = stronger but research is inconclusive; he acknowledges the variable is conflated (bigger zone = more wiggle room = more likely to "hold" trivially). This contradicts the intuitive assumption. (v235, [43:12]) [ONCE]

4. **Zone invalidation is immediate on bar close** — a zone drawn from a red candle is immediately invalidated if the next bar closes above it; no waiting for confirmation bars. This is more aggressive than the typical "wait 2 bars" follow-through rule. (v235, [09:06]) [ONCE]

5. **Strong delta does NOT override price follow-through requirement** — "nice strong positive delta of plus 1200 but the next bar couldn't even go any higher... that's not bullish." Delta strength alone is insufficient; price must respond. Reinforces and sharpens the "confluence" principle. (v235, [20:41]) [ONCE]

6. **Automation is explicitly NOT a full replacement for discretion** — Mike warns against 100% automation: "sometimes you're going to see things happening in the market that go contrary to you getting into the trade." He advocates automation for *entry only*, with human exit management. This explicitly contradicts the view that a purely mechanical indicator can be used end-to-end. (v232, [03:32]) [REPEATED]

7. **Flow Breaks uses NO fast-signal mode in Markers** — unlike other Orderflows indicators (which can use fast signal mode), Flow Breaks specifically requires Markers Copy (not fast signal). Implementation detail that would cause a setup error if wrong path taken. (v233, [01:21]) [ONCE]

---

## Coverage note

- v235 is the richest transcript for the reversal model: substantial discussion of value area zones as reversal/continuation context, invalidation logic, and the "two consecutive gap" directional trigger with concrete price examples.
- v232 is moderately rich for trade management (partial automation, order-flow exit signals during live trade), but is primarily a software demo for Markers automation.
- v233 is thin for the reversal model: purely a step-by-step NinjaTrader setup guide for Flow Breaks + Markers; minimal new model content.
