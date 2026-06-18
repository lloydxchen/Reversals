# Absorption

The other half of the engine: passive liquidity *eating* aggression. Includes his explicit **A+ Value-Area Absorption**. Supports KPI 1/2.

## Definition (his words)
Aggressive market orders hit a **wall of resting/refreshing liquidity** that soaks them up; once the aggression is spent, price reverses. He calls value-area absorption "**one of my A+ setups**." (Ch016/v485 [05:04]; Ch089/v310 [07:55]) `[REPEATED]`

## Tells
- **Negative delta on a green candle** (or positive delta on a red candle) = aggression on one side absorbed by passive size on the other → it's the *opposite* of what the headline delta implies. (Ch069/v213 [40:45]; Ch014/v437) `[REPEATED]`
- **Strong counter-delta that fails to move price:** "−455 delta and the market doesn't go lower"; "−700 and we can't push lower." (Ch016/v482 [02:31], v489 [10:23]) `[REPEATED]`
- **Max delta near 0 / delta "eaten back"** (e.g. −4,900 → −900). (Ch005/v173; Ch008/v296) `[REPEATED]`
- **Big passive bid/offer** ("sticks out like a sore thumb," >1000 on 1-min ES, double/triple surrounding prints) 3rd–4th bar off the low. (Ch095/v357 [07:42]) `[REPEATED]`
- **Iceberg / refreshing size** that keeps replenishing; breaking it → "vacuum." (Ch001/v5 [07:55])
- Absorption typically runs **~half the bar**, then reversal aggression (offers all lifted / bids all hit). (Ch089/v310 [07:55])

## ★ A+ Value-Area Absorption (his explicit A+)
Value area drawn (blue=bullish, pink=bearish); the level is strongest when **NOT traded back into on the next bar** ("abandoned"). Two consecutive abandoned value areas = "a strong sign." (Ch016/v485 [05:04]; Ch094/v355 [05:19]; Ch102/v479) `[REPEATED]`

## Operationalization (file 02 §2.5)
- Green bar + negative `BarDelta` + strongly negative `MinSeenDelta` but no price drop, at a swing low.
- Value-area abandonment = next-bar range ∩ value area = ∅ (binary, clean/testable).
- `[FORCED]` on "max delta near 0" and "strong counter-delta with small range" — these are heuristics; generic absorption is `partially subjective`, value-area abandonment is clean.

## Failure modes / nuances
- Value area **retraded next bar** → invalidated.
- Absorption read with no follow-through → no trade.
- Distinguish from a passive bid that's merely a **magnet** (DOM) vs one actually absorbing executed volume (footprint).

## A+ vs mediocre
A+ = abandoned value area / prominent POC at a clean swing **with an exhaustion print** and immediate follow-through. Mediocre = absorption inferred with no confirmation, light volume, or value area re-entered.
