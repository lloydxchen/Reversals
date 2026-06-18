# Trapped Traders

Supports KPI 1/2. **His view is contrarian to popular order-flow teaching — capture it precisely.**

## Definition (his words)
Trapped traders = **aggressors who traded INTO absorption and got stuck** — visible as **inverse imbalances**: **buying imbalances inside a RED candle**, or **selling imbalances inside a GREEN candle**. (Ch006/v176; Ch008/v289 [11:34]) `[REPEATED]`

## The contrarian nuances (most important)
1. **Trapped quantity is usually SMALL** — "31 is nothing vs 1,800"; "58 lots not trapped; 580 yes." It is a **shift signal, not squeeze fuel.** Do **not** scale conviction by trapped size. (Ch013/v425; Ch008/v300; Ch011/v390) `[REPEATED]`
2. **Trapped traders DON'T cause the reversal** — they **signal that liquidity is drying up**; the reversal comes from exhaustion/absorption, not from trapped traders being forced out. (Ch078/v242 [33:14]) `[REPEATED]`
3. He **rejects the "stop-run / big-wick = trapped"** framing as overstated (see file 11). `[REPEATED]`
4. **Two look-alikes:** stop-sweep (already flat — not trapped) vs limit-absorption (real offside longs who must puke). Only the second is genuinely "trapped." (Ch007/v280) `[REPEATED]`

## Psychology
"The easiest way to sell is into a rising market" — big sellers distribute into strength, trapping aggressive late buyers; when those buyers stop buying ("aren't getting paid"), price rolls over (Green Delta Trap). (Ch009/v309 [04:25]; Ch016/v478) `[REPEATED]`

## Operationalization (file 02 §2.9)
- Inverse imbalance vs candle color at a swing extreme + **next bar trades away (not back in)**.
- `[FORCED]`-avoidance note: **do not** weight by trapped contract count (explicit contrarian point); treat as a binary shift tell.
- Inverse-level param 2 (ES) / 3 (YM). Columns: imbalance dir + `close>open` + `BarDelta` sign.

## Failure modes
- Treating a small trapped cohort as a big squeeze setup; trading the trap without exhaustion/absorption confluence; next bar trades back into the bar (no shift confirmed).

## A+ vs mediocre
A+ = inverse imbalance = absorption at a clean swing + exhaustion + follow-through away. Mediocre = lone inverse imbalance mid-move, or sizing conviction off "how many got trapped."
