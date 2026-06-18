# Delta & Delta Divergence

Supports KPI 1/2. Covers per-bar divergence, the Orderflows "ratio", cumulative-delta divergence, delta surge/weakness, strong-delta, and the Green Delta Trap.

## Divergence definition (his words, codifiable)
**New/equal HIGH on negative delta = bearish; new/equal LOW on positive delta = bullish.** (Ch003/v143 [02:22]) `[REPEATED]`
- **Necessary but NOT sufficient:** "you can't just buy every divergence… a recipe for disaster." Needs confirming price action + (usually) the ratio. (Ch001/v5 [10:42]; Ch045/v144 [14:26]) `[REPEATED]`

## The Orderflows "ratio"
A proprietary single-bar number: **≥30 = price exhaustion (bounds high)**, **0–0.69 = price defense (bounds low)**. **Magnitude is NOT graded** → treat as a binary flag (a 406 reads the same as a 32). Formula **undisclosed**. (Ch102/v471 [06:22]; Ch012) `[REPEATED]`. *(A 2017 video implied a ~7 cutoff — older/different definition; see file 19.)*

## Read intrabar Max/Min delta, not just final
A bar's path matters: Max +623 collapsing to close −212 = reversal; +5,278 → −578 = buyers overwhelmed. Neutral band: **|delta| ≤ ~50 = evenly matched** (in ES). (Ch094/v352; Ch028/v48 [08:30]; Ch016/v482 [08:53]) `[REPEATED]`

## Cumulative-delta divergence
Price new extreme while **`NinjaCVD` does not** = distribution/absorption warning. **Confirmation/radar, NOT a trigger.** Psychology: "the easiest place to sell is a rising market" → institutions distribute into strength. (Ch008/v296; Ch101/v442 [07:14]) `[REPEATED]`

## Delta surge / weakness / strength
- **Surge:** 4 bars of monotonically increasing |delta| → act on 4th. (Ch005/v172 [35:04])
- **Weakness:** ≥3 consecutive bars of weakening |delta| (same sign) at an extreme ("water pressure dying"). (Ch011/v371 [09:32])
- **Strong bar:** final delta within **95% of max/min** delta; **delta/volume > 25%** (normal 5–15%); cyan=strong+, magenta=strong−, white=no aggression. (Ch089/v308 [13:24]; Ch094/v350)

## Green Delta Trap (counter-intuitive)
**Strong POSITIVE delta at a high with no continuation = bearish** (buyers absorbed/trapped). Mirror at lows. "Just because buyers are aggressive doesn't mean they're winning." (Ch016/v478) `[REPEATED]`

## Critical false-positive filters
- **3 failed divergences in ~1 hr = TREND day → do NOT fade, trade the breakout.** (Ch009/v312 [04:40]) `[REPEATED]`
- **Polarity trap:** new low on **positive** delta may be supply absorbing aggressive buyers → still bearish until supply exhausts (not auto-bullish). (Ch099/v403 [10:34]) `[REPEATED]`

## Operationalization & FORCED notes
See file 02 §2.3–2.4, §2.10, §2.13. `[FORCED]`: strict-monotone weakening, 25%/95% strong-delta cutoffs (his examples), and the binary ratio (formula TBD). Columns: `BarDelta`, `MaxSeenDelta`, `MinSeenDelta`, `DeltaPercent`, `NinjaCVD`.
