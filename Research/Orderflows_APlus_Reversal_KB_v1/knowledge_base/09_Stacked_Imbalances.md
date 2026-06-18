# Stacked (and Multiple) Imbalances

Supports KPI 1/2. Detail of his most quantified building block.

## Definition (his words)
- **Diagonal imbalance** = aggressor dominance comparing **ask[i] vs bid[i−1]** (buy) / **bid[i] vs ask[i+1]** (sell) at a ratio. Default **4:1 (400%)**; alts 2.5/3/3.5/**10:1** ("my pet favorite"); minimum volume to count ~**10** (era/liquidity-scaled — 2017 used ~50 on e-mini). (Ch006/v176; Ch010/v320; Ch028/v48) `[REPEATED]`
- **Stacked** = **3+ consecutive** imbalances ("three is the magic number"; two "doesn't qualify"). (Ch006/v176; Ch100/v415) `[REPEATED]`
- **Multiple** = **3+ imbalances spread out (non-consecutive) in one bar** — "as important, if not more, than stacked" because they fire **~3 pts earlier**. (Ch005/v173; Ch061/v196 [31:09]) `[REPEATED]`

## The reversal rules (critical)
- **Color decides direction.** Same-color stack (buy-imbalances in a green up-move) = **continuation/weak**. **Opposite-color** at a swing extreme (sell-imbalances in a green candle at a low, or a failed buy-stack followed by a sell-stack within a ≤5-tick zone) = reversal. **"Go with the SECOND (opposing) imbalance."** (Ch001/v8 [03:59]; Ch006/v176) `[REPEATED]`
- **Validity:** the bar must **close beyond** the stack, or it is "invalidated"; a bearish sweep closing back above = rejection. (Ch085/v285 [13:01]) `[REPEATED]`
- **Decay:** stacked imbalances are **immediate-term S/R only (~4–5 bars)** — NOT durable support/resistance (contradicts common belief). "Past the fifth bar all bets are off." (Ch001/v8 [14:06]; Ch018/v13 [09:13]) `[REPEATED — important]`

## Operationalization (file 02 §2.7–2.8, file 17)
`ImbRatio` 4.0 (alts), `ImbMinVol` ~10 (per-instrument), `StackMin` 3, `ZoneTicks` ≤5, `Decay` 5 bars, **same-color → classify as continuation**, require close beyond + follow-through, location gate. Columns: `TopBuyStackMax`, `BottomSellStackMax`, `BuyImbalanceCount`, `SellImbalanceCount`, `BuyDiagonalImbalance`, `SellDiagonalImbalance`.

## Failure modes
- Lone imbalance ("little weight"); same-color treated as reversal; stale (>5 bars) treated as live; mid-move; light volume; chart-resolution makes the imbalance appear/vanish (a 4-range shows it, a 10-range fills it in). (Ch001/v8 [12:01])

## A+ vs mediocre
A+ = 3+ stacked/multiple, high ratio, **opposite-color/failed-stack**, at a clean swing, closes beyond, immediate follow-through, decent volume. Mediocre = 1 imbalance, same-color mid-trend, light volume, stale.
