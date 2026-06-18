# Stop Management & Risk

Supports KPI 1/3. His risk model is the source of his "low-risk" edge claim.

## Stop placement
- **1 tick beyond the signal/print extreme** — below the signal-bar low (bullish) / above the high (bearish). This tight stop *is* the low-risk feature. (Ch017/v493 [09:49], v496 [11:33]) `[REPEATED]`
- **Prefer tight stop + second-chance re-entry over widening:** "one tick becomes two, two becomes three… I'd rather just get out on the one tick." (Ch017/v496 [11:33]) `[REPEATED]`
- On retest-prone highs/lows give "**2–3 ticks** past, not 1" to avoid being ticked out by a tick (older Price-Rejector guidance). (Ch001/v3 [35:12]) — mild tension with the 1-tick rule; reconciled by **setup selection** (small bars).
- **Avoid big signal bars** — a wide bar forces a wide stop → "I'm scared of bars like this." Prefer small bars where the tight stop is feasible. (Ch017/v498 [16:49]) `[REPEATED]`

## Time stop (a distinct risk)
- **~10 minutes:** "I like to give the trade about 10 minutes; if it's not moving, it's not moving — get out." Scratch near break-even rather than wait for the hard stop. "Don't look a gift horse in the mouth." (Ch016/v490 [07:01]) `[REPEATED]`
- Going **sideways/horizontal** = time to leave even before the price stop. (Ch017/v498 [17:52])

## Targets & management
- **Targets are deliberately discretionary** — "it depends on your target"; he refuses fixed targets. Exit on the first sideways/congestion stall, or after a **rotation** (ES ~10–14 pts). (Ch017/v492 [08:46]; Ch016/v490 [11:01]) `NEEDS-OP`
- **Modest, level-to-level** — "not trying to pick the low, picking an *area*… not every trade has to go to infinity." (Ch001/v3 [09:36]) `[REPEATED]`
- **Scale out / take runners**, trail the stop as it moves your way. (Ch001/v4) `[REPEATED]`
- **Thin markets → closer/realistic targets**, ATMs firing fast (pops reverse). (Ch017/v495 [02:51])
- **Don't let a winner turn into a loser.** (Ch001/v3 [36:04]) `[REPEATED]`

## Risk:reward profile
- Small risk, modest-to-large reward: risk ~**5–15 ticks** for **25–60+ ticks**; ES live example 1.5-pt stop / 3-pt target (2:1). Accepts a **string of small stop-outs** because one winner ("one fell swoop") recovers them — *requires the tight-stop discipline + re-entry to be net positive*. (Ch017/v497 [04:24]; Ch001/v5 [02:44]) `[REPEATED]`

## Implementation (file 04)
Stop = signal-extreme ± `Buf`; `TimeStopMin` ≈ 10; targets left to ATM/level logic (do NOT invent fixed targets); one second-chance re-entry; per-instrument tick sizing. **Backtest must model the string-of-small-losses-then-one-winner distribution** — average trade hides it.
