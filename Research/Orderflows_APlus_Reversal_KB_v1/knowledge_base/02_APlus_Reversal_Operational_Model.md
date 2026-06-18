# A+ Reversal Operational Model (KPI 2)

Translates the qualitative framework (file 01) into **measurable variables, candidate rules, thresholds, scoring, confirmation/invalidation, and false-positive filters**. It is a **first-pass operational hypothesis set**, not a finished model.

> **PRIME DIRECTIVE (per the user + repo `AGENTS.md` "no fake edge"):** stick as close as possible to what he actually says. Where his language is qualitative ("delta dries up", "big volume", "strong"), the operationalization is a *candidate* and is tagged `[FORCED]` (we tightened it) so §7 lists every place to revisit first if the model underperforms. **Blank/qualitative is better than a wrong precise rule.** Most of his thresholds are explicitly **per-market/liquidity-scaled** — implement as *parameters*, never hard-coded constants.

Column names in `Backticks` refer to fields the repo's exporters already produce (see file 17 and the recon in the README), so these rules are implementable today.

---

## 1. Measurable variable dictionary
His concept → measurable feature → data source / available column → mapping confidence.

| His concept | Measurable feature | Column / source | Confidence |
|---|---|---|---|
| Bar delta | signed buy−sell at bar | `BarDelta`, `FootprintDelta` | High |
| Intrabar delta extremes ("read max/min, not final") | running max & min delta within bar | `MaxSeenDelta`, `MinSeenDelta` (a.k.a. MaxPositiveDelta/MaxNegativeDelta) | High |
| "Delta dries up / weakening into the low" | monotone decrease of \|delta\| over last K bars, same sign | derived from `BarDelta` series | Med (`[FORCED]` on K & "decrease") |
| "Delta flips" | sign change of `BarDelta` on/after signal bar | `BarDelta` | High |
| Strong vs neutral delta | `DeltaPercent` = delta/volume; "strong" >25%, neutral band ±~50 contracts | `DeltaPercent`, `BarDelta` | Med (`[FORCED]` cutoffs are his examples) |
| "Final delta within 95% of max" (conviction) | `BarDelta`/`MaxSeenDelta` ≥ 0.95 (or ≤ for shorts) | derived | Med |
| Cumulative-delta divergence | `NinjaCVD`/`ExportSessionCVD` makes new extreme while price does not (or vice-versa) | `NinjaCVD`, price | High |
| Exhaustion print ("≤N contracts at the extreme") | volume at bar's extreme price level ≤ threshold | footprint `BidVol`/`AskVol` at `IsBarLow`/`IsBarHigh` level | High |
| Diagonal imbalance (≥4:1) | per-level ask[i] vs bid[i-1] (buy) / bid[i] vs ask[i+1] (sell) ≥ ratio & ≥ min vol | `BuyDiagonalImbalance`, `SellDiagonalImbalance` flags | High |
| Stacked imbalance (≥3 consecutive) | run length of consecutive imbalances | `TopBuyStackMax`, `BottomSellStackMax`, `BuyImbalanceCount`, `SellImbalanceCount` | High |
| Multiple imbalances (≥3 non-consecutive in bar) | count of imbalances in bar | `BuyImbalanceCount`/`SellImbalanceCount` | High |
| Inverse imbalance (buy-imb in red / sell-imb in green) | imbalance dir vs candle color | imbalance flags + bar close vs open | High |
| POC at extreme / prominent POC | `POCPosition` near bar high/low; POC at day extreme | `POCPrice`, `POCPosition` | High |
| Value area & "abandoned" (not retraded next bar) | value-area hi/lo; next bar's range ∩ VA = ∅ | `TopZone*`/`BottomZone*`, or VA from footprint | Med (VA build needed) |
| Stopping volume | volume at extreme ≥ X% of bar volume, price halts | footprint level vol; `DeltaPerVolume` | Med (`[FORCED]` 30%) |
| Swing high/low (location gate) | new highest-high / lowest-low over N bars | OHLC; existing `RequireNewHighLow` flag | High |
| Follow-through ("let the market take you in") | next 1–2 bars trade ≥ buffer beyond signal-bar extreme | OHLC | High |
| "Move into the level" (prior move exists) | run/displacement over prior M bars ≥ threshold | price/ATR | Med (`[FORCED]` threshold) |
| "Unchanged"/open magnet (catalyst filter) | distance of signal to session open / prior close | session levels | High |
| Time stop (~10 min) | bars-since-entry without target progress | bar count + time | High |
| Big-bar risk filter | signal-bar range vs ATR | OHLC/ATR | Med |
| Regime: trend vs rotation | value migrating (price leads value) vs value contains price; `ChopState` | `ChopState_State`, POC migration | Med |

---

## 2. Per-setup operationalization
Each setup: measurable inputs → candidate rule (bullish; mirror for bearish) → candidate thresholds → dynamic-threshold idea → data needed → testable? → **Priority / Difficulty / Evidence** (1–5).

### 2.1 Exhaustion Entry Model ★
- **Inputs:** exhaustion-print volume at extreme level; swing flag; candle color; next-1–2-bar break; weakening counter-delta; optional POC/VA absorption.
- **Bullish rule:** `IsBarLow` is a new N-bar low (N≈25) AND bar close>open (green) AND volume at the low price level ≤ `expVol` AND (one of next 2 bars trades > signal-bar high by ≥ `buf`). Optional confluence: negative `BarDelta` weakening over prior K bars then `BarDelta` flips ≥0; bullish `POCPosition` low; VA not retraded.
- **Thresholds:** `expVol` ≈ 3 (crude) / 5 (FX) / 9–10 (rates, indices); N=25 (alts 25/30/50); `buf`=1 tick; trigger window 2 bars; time stop ≈10 min.
- **Dynamic idea:** set `expVol` from a low percentile of recent per-level volume (e.g. ≤5th pct of last 200 level-volumes) instead of a constant → auto-scales by instrument. `[FORCED]`/hypothesis.
- **Data:** footprint (bid/ask per level), OHLC, delta. **Testable:** yes (mostly objective). **P5 / D3 / E5.**

### 2.2 Exhaustion print (standalone)
- As 2.1 minus the absorption confluence. Same `expVol`, swing, follow-through. **P5 / D2 / E5.**

### 2.3 Ratio + Divergence
- **Bullish rule:** new/equal N-low AND `BarDelta`>0 (positive delta at the low = divergence) AND ratio flag (`ratio ≤ 0.69` = bounds-low/defense) AND confirming price action in bar AND next bar trades higher.
- **Thresholds:** ratio bounds **≥30 / ≤0.69** (binary; magnitude not graded). Divergence = strict new/equal extreme with opposite-sign delta.
- **Caveat:** the "ratio" is a proprietary single-bar Orderflows number; its exact formula is **undisclosed** → either reproduce from footprint research or treat as `partially subjective`. **P4 / D4 / E4.**

### 2.4 Delta divergence (per-bar & cumulative)
- **Bullish rule:** price new N-low AND `NinjaCVD` does NOT make a new low (cum-delta divergence) → radar; require a separate trigger (exhaustion/ratio/imbalance) + follow-through.
- **FP filter (critical):** count failed divergences in trailing ~60 min; **if ≥3, flip to trend-mode (do not fade).** `[FORCED]` window — he refuses to fix it; make it a parameter, default 60 min, and prefer a *count of consecutive failures* over a clock.
- **Polarity guard:** new low on positive delta may be **supply absorption** (still bearish) — do not auto-long; require absorption/exhaustion confirmation. **P4 / D3 / E5.**

### 2.5 Absorption (incl. ★ A+ value-area absorption)
- **Bullish rule:** green bar (close>open) with negative `BarDelta` AND `MaxSeenDelta`≈0-from-above (i.e. min delta strongly negative but price didn't fall) at a swing low; or value area present and **not retraded next bar**.
- **Thresholds:** "max delta near 0" → `|MaxSeenDelta opposite side|` small; VA abandonment = next-bar range ∩ VA = ∅ (binary). Strong-counter-delta-no-move = large `|BarDelta|` with bar range ≤ X ticks. `[FORCED]` on "near 0" and range.
- **Testable:** value-area abandonment is clean/binary; "absorption" generally is `partially subjective`. **P4 / D4 / E4.**

### 2.6 Stopping volume
- **Bullish rule:** volume at the low level ≥ `svPct` of bar volume AND price fails to extend next bar AND decent absolute volume.
- **Thresholds:** `svPct` default 30%; "decent volume" = ≥ rolling median. `[FORCED]` 30% is a tool default, not a stated edge. **P3 / D3 / E3.**

### 2.7 Stacked-imbalance reversal
- **Bullish rule:** `BottomSellStackMax`≥3 OR (opposing) a failed buy-stack then a sell-stack within a ≤5-tick zone; at a swing low; imbalance ratio ≥ `imbRatio` & level vol ≥ `imbVol`; **bar closes beyond** the stack to validate; not stale (≤ `decay` bars).
- **Thresholds:** `imbRatio`=4:1 (alts 2.5/3/3.5/10); `imbVol`≈10 (era/liquidity-scaled, was ~50 on e-mini 2017); stack≥3; `decay`≈5 bars.
- **Direction rule:** same-color = continuation (suppress as reversal); opposite-color/failed = reversal. **P4 / D3 / E5.**

### 2.8 Multiple-imbalance reversal
- `BuyImbalanceCount`(or Sell)≥3 within one bar at a swing extreme + follow-through. Fires earlier than stacked. **P4 / D2 / E4.**

### 2.9 Inverse-imbalance / trapped-trader
- **Bullish rule:** sell-imbalance(s) inside a green candle at a swing low (absorption) + next bar trades away (not back in). Treat trapped quantity as a **shift signal, not magnitude** (do NOT scale conviction by trapped size). **P3 / D3 / E4.**

### 2.10 Delta surge / market strength-weakness
- **Surge:** 4 consecutive bars with increasing `|BarDelta|` → act on 4th. **Weakness:** ≥3 consecutive bars decreasing `|BarDelta|` same sign at an extreme. **Strong bar:** `DeltaPercent`>25% AND final `BarDelta` ≥95% of `MaxSeenDelta`. Location gate mandatory. **P4 / D3 / E4.**

### 2.11 POC-on-extreme / prominent POC
- `POCPosition` at bar high/low, bar = day extreme, + ratio; PPOC **untested next bar** to remain valid; invalidate if breached. **P3 / D3 / E4.**

### 2.12 Abandoned value area / POC
- VA & POC both untraded next bar after a balancing bar, at a swing extreme; 2 consecutive abandoned VAs = stronger. **P4 / D4 / E4.**

### 2.13 Green Delta Trap
- Strong positive `BarDelta` (high `DeltaPercent`) at a new N-high with **no continuation** (next bar fails to make a higher high / delta doesn't stay strong) → bearish. Mirror at lows. **P4 / D2 / E4.**

---

## 3. Scoring model idea (composite "A+ score")
> **Caveat:** he says order flow is "not a red-light/green-light system" and confluence is a *screen, not arithmetic*. Use this as a **ranking/triage approximation**, validated against his verbal tiers — not as ground truth.

**Gate (must pass, else no signal regardless of score):**
- G1 **Location:** at/within ~1 tick of a new N-bar swing extreme or HOD/LOD.
- G2 **Catalyst:** not within `c` ticks of session open / "unchanged".
- G3 **Follow-through:** next 1–2 bars break the signal-bar extreme by ≥ buf. *(G3 confirms the trade; pre-G3 it is a "candidate".)*

**Weighted confluence (only if gates pass)** — candidate weights to be tuned by backtest:
| Dimension | Signal | Weight |
|---|---|---|
| Exhaustion print at extreme | ≤ `expVol` | 2 |
| Absorption / abandoned VA-POC | binary | 2 |
| Counter-delta weakening then flip | sequence | 1.5 |
| Stacked/multiple imbalance (opposite-color) | ≥3 | 1.5 |
| Ratio flag (≥30 / ≤0.69) | binary | 1 |
| Strong confirming delta after (`DeltaPercent`>25, ≥95% of max) | binary | 1 |
| Cum-delta divergence | binary | 1 |
| Clean swing (space/time to the left) | binary | 1 |
| Penalty: big signal bar (range>`k`·ATR) | − | −1.5 |
| Penalty: trend-day (≥3 failed divergences/~60 min) | − | −3 (often → suppress) |

**Grade mapping (align to repo `Reversal_Hunter` scale, tune cutoffs):** A+ ≥ ~7 with absorption present; A ≥ ~5.5; B ≥ ~4; C ≥ ~2.5; below → no print.

---

## 4. Confirmation logic (what SHOULD happen, fast)
- **Primary:** one of next **1–2 bars** trades beyond the signal-bar extreme by ≥ `buf` (1 tick). No break in window → cancel.
- **Order-flow confirm:** `BarDelta` flips into trade direction; imbalances appear in the new direction; absorption level not retraded.
- **Speed:** meaningful progress within ~1–3 bars; "best trades work immediately, little/no drawdown."
- **Implementation:** all evaluated **on bar close**; entry via stop order at the extreme±buf (see repining notes, file 04).

## 5. Invalidation logic (what should NOT happen)
- Next bar trades **inside** the signal bar (no follow-through) → "kiss of death", void.
- Opposite-direction delta/imbalance reappears after entry.
- **Sideways/horizontal** for ~10 min (time stop) with no progress → scratch (don't wait for hard stop).
- Hard stop: 1 tick beyond the signal-bar/print extreme.
- Level breached: PPOC/VA traded back through; stack closed back inside.
- **Note:** a single stop-out ≠ thesis dead — allow **one second-chance re-entry** if order flow unchanged.

## 6. False-positive filters
1. **Trend-day filter:** ≥3 failed divergences/exhaustions in ~60 min → suppress fades, switch to breakout. `[REPEATED][FORCED window]`
2. **Catalyst filter:** suppress within `c` ticks of open/"unchanged"; suppress right after major numbers (CPI/PPI/NFP/inventories) due to thin/wonky prints.
3. **Location filter:** suppress if not a fresh swing extreme / mid-move.
4. **Bar-size filter:** suppress if signal-bar range > `k`·ATR (stop too wide).
5. **Staleness filter:** ignore imbalance/zone older than ~5 bars.
6. **Same-color stack:** classify as continuation, not reversal.
7. **Polarity guard:** new-extreme-with-same-direction-delta may be absorption (don't fade naively).
8. **Liquidity/instrument:** loosen counts in thin markets; some setups (single-print, inverse) read better on YM/NQ/gold/rates than ES — track per-instrument.
9. **Chart-construction:** require the signal to be robust; flag that bar-type changes signal existence (file 19).

---

## 7. ⚠️ [FORCED] revisit list — check these FIRST if the model is weak
Per the user's explicit instruction: anything below tightened a qualitative idea into a number/binary and is a prime suspect for breaking the model.

1. **"Delta dries up / weakening"** → we modeled as *monotone decrease of |delta| over K bars*. He never fixes K or "how much weaker." Real reads tolerate noise. **Try:** ≥X% drop over K∈{2,3,4}, or slope, not strict monotone.
2. **Exhaustion `expVol`** → single threshold per market. He says it **drifts** (single-digits→9–10) and is liquidity-relative. **Try:** dynamic low-percentile of recent per-level volume.
3. **"Strong delta" = DeltaPercent>25% / ≥95% of max** → these are illustrative examples, not stated rules. **Try:** relative-to-recent-bars z-score.
4. **Trend-day ~60-min window** → he refuses to hard-code it. **Try:** consecutive-failure count instead of a clock.
5. **"Big move into the level" minimum** → no number given. Leaving it out may flood signals; forcing a number may kill good ones. **Try:** ATR-relative, parameter swept.
6. **Ratio ≥30 / ≤0.69 as binary** → he says magnitude isn't graded, but the **formula is undisclosed**; our reproduction may differ (a 2017 video implied a ~7 cutoff — different/older definition). **Try:** reproduce ratio from footprint and validate against his flagged bars.
7. **Stopping-volume 30%** → a tool default, not a stated edge.
8. **Confluence score = weighted sum** → he explicitly says it's NOT arithmetic ("6 plots ≠ buy"). **This is the single biggest [FORCED] simplification.** Validate ranking against his verbal tiers; consider a gate-then-rank or learned model instead.
9. **"Works immediately / ~10-min time stop"** → "immediately" is ~1–3 bars, not the next tick; he softens it. Don't void too early.
10. **Min imbalance volume** (10 vs era-50) and **swing N** (5/25/50) and **inverse-level** (2 ES/3 YM) are all **per-instrument** — never global constants.

---

## 8. Open quantitative questions (for backtest)
- Does requiring **absorption present** materially raise win-rate of exhaustion prints (his "A+" claim)?
- Optimal `expVol` per instrument: fixed vs dynamic-percentile?
- Does the **opposite-color** stacked-imbalance rule beat same-color as a reversal trigger (his strongest discrete claim)?
- Does the **2-bar follow-through** gate improve expectancy vs entering on the signal bar (he claims yes, strongly)?
- Multiple-imbalance vs stacked: does the earlier fire actually pay more (he claims ~3 pts)?
- Trend-day filter: consecutive-failure count vs clock — which preserves more edge?
- Is the composite score monotonic with realized MFE/MAE? (validate the scoring approximation)

→ Testable rows in `03_APlus_Reversal_Testable_Hypotheses.csv`; NT mapping in `04_...Indicator_Spec.md`; per-feature detail in `17_Feature_Engineering_Dictionary.md`.
