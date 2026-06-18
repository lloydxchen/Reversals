# Confirmation & Invalidation

Supports KPI 1/2/3. What SHOULD happen fast, and what KILLS the thesis. This is the gate that turns a pattern into a trade.

## Confirmation — what SHOULD happen (quickly)
1. **Follow-through:** one of the next **1–2 bars** trades beyond the signal-bar extreme by ≥1 tick. (Ch016/v490 [03:11]) `[REPEATED]`
2. **Speed — "the best trades work immediately."** A+ "rips right off the low" with **little/no drawdown** ("doesn't even pull back"). (Ch017/v498 [19:00]; Ch016/v483) `[REPEATED]`
   - *Nuance:* "immediately" = within ~1–3 bars, not strictly the next tick; occasionally hangs 1–3 bars then goes. (Ch017/v498 [20:08])
3. **Order-flow confirm:** delta **flips** into the trade direction; imbalances appear in the new direction; absorption level **not retraded**; "other traders join" (bid after bid cleared). (Ch016/v482 [02:01], v490 [09:22]) `[REPEATED]`
4. **Strong confirming bar:** `DeltaPercent` > 25% and final delta near its max. (Ch089/v308)

## Invalidation — what must NOT happen
1. **Next bar trades INSIDE the signal bar** (no break) = "**kiss of death**" → no trade / void. (Ch016/v485 [01:55]) `[REPEATED — primary]`
2. **Opposite delta/imbalance reappears** after entry. (Ch016/v485 [02:24]) `[REPEATED]`
3. **Sideways/horizontal** instead of vertical → failing; apply the **~10-minute time stop** and scratch. (Ch017/v498 [17:52]; Ch016/v490 [07:01]) `[REPEATED]`
4. **Level breached:** PPOC/value area traded back into; stack closed back inside; building volume flips the level. (Ch061/v196; Ch085/v285) `[REPEATED]`
5. **At "unchanged"/open** (no catalyst) → not a valid context. (Ch016/v487) `[REPEATED]`

## The crucial non-invalidation
A **single 1-tick stop-out does NOT invalidate** the read — "residual/leftover" opposite aggression often ticks you out before the real move. **Re-enter once** if order flow is unchanged. (Ch016/v481 [06:19], v483 [08:53]) `[REPEATED]`

## Operationalization (file 02 §4–5)
Follow-through (1–2 bars, 1-tick buf) on bar close; inside-bar void; opposite-delta check; `TimeStopMin` ≈ 10; level-breach check; one second-chance re-entry toggle. **No-lookahead:** confirmation is only known on subsequent closed bars — timestamp the confirmed bar, never the signal bar.
