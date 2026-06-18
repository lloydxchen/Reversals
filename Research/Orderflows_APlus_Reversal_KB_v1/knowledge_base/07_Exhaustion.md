# Exhaustion

His single most important and most-repeated reversal concept (the basis of the flagship Exhaustion Entry Model). Supports KPI 1/2.

## Definition (his words)
"Very light volume trading at the edge of a bar at a swing high or a swing low… the high of the day or the low of the day." It marks **"the last buyer has bought or the last seller has sold."** (Ch016/v472 [00:55]; Ch017/v492 [17:10]) `[REPEATED]`

## Tells
- **Exhaustion / single print:** the extreme price level trades the **lowest possible volume** — 1 contract is the strongest read; ≤ threshold qualifies. Located **on the bid/bottom of a green candle** (bullish) or **offer/top of a red candle** (bearish). (Ch017/v496 [05:29], v497 [06:38]) `[REPEATED]`
- **Volume staircase down into the extreme:** "423, 398, 161, 103… capped off with just the five." (Ch016/v481 [02:40]) `[REPEATED]`
- **Counter-delta weakening then flipping:** e.g. −386→−337→−220→−63 then positive. (Ch016/v482 [05:53]) `[REPEATED]`
- **High volume but no progress** (decreasing momentum): lots of volume at the top but price can't advance. (Ch016/v462 [01:32]) `[REPEATED]`
- Reads **cleanest in high-volume-at-price markets** (bonds, tens, ultra bonds); "harder to see" in NASDAQ where volume is spread out. (Ch016/v462 [03:25]) `[REPEATED]`

## Operationalization (see file 02 §2.1–2.2, file 17)
- `ExpVol` threshold at the extreme level (per-instrument: ~1–3 crude, 5 FX, 9–10 rates/indices; historically "single digits"). **Drifts → parameter, or dynamic low-percentile.** `[FORCED on single threshold]`
- Swing filter `SwingN` ≈ 25 (alts 5/30/50); must be a **new extreme**.
- Candle-color gate; follow-through gate (next 1–2 bars break the signal bar).

## Failure modes
- **No follow-through** ("kiss of death" — next bar inside) → never a trade.
- Mid-move (not a swing extreme) → meaningless.
- "Residual/leftover" one bar of opposite aggression ticks you out, then it reverses → re-enter.
- Double-top exhaustion: software suppresses (not a fresh new high) but he treats it by eye → a discretionary exception to the strict swing rule. (Ch017/v496 [04:55])

## What makes exhaustion A+ vs mediocre
A+ = exhaustion **following absorption** (POC/value-area not retraded) at a *clean* swing, delta weakening→flipping, **immediate** follow-through, small signal bar. Mediocre = lone print, mid-move, big bar, no catalyst, slow/sideways reaction. (Ch016/v482, v485, v487)
