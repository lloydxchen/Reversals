# A+ Reversal Operational Model — v2 (full-corpus)

Supersedes `02_..._Operational_Model.md` (v1 preserved). Now based on **all 115 chunks extracted**. `[v2]` marks changes from v1; everything else is unchanged from v1 and re-confirmed by the remaining 82 chunks. See `20_Remaining_Chunks_Delta_Report_v2.md` for evidence.

> **PRIME DIRECTIVE (unchanged):** stay close to what he says; do NOT force qualitative language into rigid math. `[FORCED]` = we tightened it (revisit list §7). Thresholds are **per-instrument AND per-timeframe parameters**, never global constants. `Col` = an existing repo export column.

## `[v2]` Changes from v1 (summary)
1. New variable family: **intrabar Max/Min delta vs close delta** (the operative exhaustion read; close-delta alone is misleading).
2. **Ratio** = two-tier soft floor (28 watch / 30 preferred; low ~0.69–0.77) and **binary** (magnitude does not grade quality).
3. **Follow-through gate** quantified (~25–45% signal cull) and **timeframe-conditional** (off on ≥5-min; off for ultra bonds/palm oil).
4. **Multiple ≥ stacked** (tiering inversion); stacked count drops to **2** on fast charts; low-cell-volume stacks downgraded; **position-within-bar has no edge**.
5. Stacked invalidation: opposing imbalance flips direction; **an opposite next-bar ratio can kill it in 1 bar**; decay as 3/4/5 exit counter.
6. **Delta-sign is context-dependent** (hard branch) + pos-delta-at-low disambiguation via bid-vs-offer volume.
7. **Time stop ≈ 1 hr / contextual** (not 10 min); order-flow freshness ~30–60 min, degrades >5-min chart.
8. Thresholds explicitly **instrument+timeframe scaled** (exhaustion 10yr≈50 / NQ≈3 / ES≈0; neutral delta ±25 FX / ±150 heavy ES).
9. New setups/variables: **back-to-back POC**, **volume-in-value (Stratum)**, **order-flow sequencing = continuation (anti-signal)**.
10. **Zero/near-zero delta = noise**, not a signal.

---

## 1. Measurable variable dictionary
(v1 rows retained; `[v2]` rows/edits below.)

| His concept | Measurable feature | Col / source | Confidence |
|---|---|---|---|
| Bar delta | signed buy−sell | `BarDelta`,`FootprintDelta` | High |
| `[v2]` **Intrabar delta path** | `MaxSeenDelta`,`MinSeenDelta` AND close `BarDelta`; **give-back** = (Max−close)/Max | `MaxSeenDelta`/`MinSeenDelta`+`BarDelta` | High |
| `[v2]` **Delta give-back / hidden flip** | close ≈ 95% of Max = conviction; Max≈0 or Min≈0 = aggressor never in control = exhaustion; large Min→close recovery = absorption | derived | Med (% = NEEDS-OP) |
| Delta/volume strength | `DeltaPercent`; "strong" >25% (normal 5–15) | `DeltaPercent` | Med `[FORCED]` |
| `[v2]` Neutral-delta band | \|delta\|≤~50 (ES) neutral; **~±25 FX/thin; ~±150 on heavy ES bars (6–9k vol)** | derived | Med `[FORCED]`/per-instr |
| `[v2]` **Zero/near-zero delta** | treat as **noise, not a signal** | `BarDelta` | High (caveat) |
| Cum-delta divergence | new price extreme w/o new CVD extreme | `NinjaCVD` | High |
| Exhaustion print | vol at bar extreme ≤ `ExpVol` | footprint `BidVol`/`AskVol` at `IsBarLow`/`IsBarHigh` | High |
| `[v2]` `ExpVol` scaling | **10yr≈50, NQ≈3, ES≈0, gold ≤3–7, euro ≤2–7** (NOT "single digits" universally) | param | Med `[FORCED]`/per-instr |
| Diagonal imbalance | ask[i]/bid[i−1] (or bid[i]/ask[i+1]) ≥ ratio & ≥ min vol | `BuyDiagonalImbalance`,`SellDiagonalImbalance` | High |
| Stacked (≥3 consec) / `[v2]` ≥2 on fast charts | run length | `TopBuyStackMax`,`BottomSellStackMax` | High |
| Multiple (≥3 in bar) | imbalance count | `BuyImbalanceCount`/`SellImbalanceCount` | High |
| `[v2]` Imbalance cell-volume | per-imbalance volume (downgrade low-vol stacks) | footprint level vol | Med |
| Ratio flag | `[v2]` 28 watch / 30 preferred high; ~0.69–0.77 low; **binary, magnitude not graded** | proprietary (reproduce) | Med `[FORCED]` |
| POC at extreme / prominent POC | `POCPosition` near high/low | `POCPrice`,`POCPosition` | High |
| `[v2]` Back-to-back POC | 2+ consecutive bars same POC price → magnet level | `POCPrice` series | High |
| `[v2]` POC migration / VA gap | POC drifting w/ price (trend) vs containing price (rotation); per-bar value-area gaps | `POCPrice`,VA build | Med |
| Value area & abandoned | next-bar range ∩ VA = ∅ | `TopZone*`/`BottomZone*` | High (binary) |
| `[v2]` Volume-in-value (Stratum) | distribution of volume within the VA (NOT delta-based) — orthogonal | footprint per-level vol | Med (Subj) |
| Swing extreme (location) | new HH/LL over N | OHLC; `RequireNewHighLow` | High |
| Follow-through | next 1–2 bars break signal extreme by buf | OHLC | High |

## 2. Per-setup operationalization
(Unchanged setups from v1 retained; `[v2]` edits below. Scores P/D/E = priority/difficulty/evidence 1–5.)

### 2.1 Exhaustion Entry Model ★ `[v2]`
- v1 rule retained. **`[v2]` Add intrabar read:** prefer bars where close-delta has given back most of its intrabar extreme (Min very negative → close ≈0/positive at a low). Close-delta alone is misleading — require the Max/Min context. `ExpVol` per-instrument (10yr≈50 … ES≈0). **P5/D3/E5.**

### 2.3 Ratio + Divergence `[v2]`
- v1 retained. **`[v2]`** Ratio is a **two-tier soft floor** (`RatioHigh`: 28 watch / 30 preferred; `RatioLow`: ~0.69, NT default 0.7699) and **BINARY** — do NOT scale conviction by ratio magnitude (a 432 ≠ better than a 52). Treat 27/28/30 as platform/era calibration, not a hard line. **P4/D4/E5.**

### 2.7 Stacked-imbalance reversal `[v2]` (now a tiered family)
- **`[v2]` MULTIPLE imbalances (3+ non-consecutive in a bar) rank EQUAL-OR-ABOVE stacked** and fire ~2 bars / ~5 pts earlier ("everybody looks for stacked"). Prefer multiple where present.
- **`[v2]`** Min count is **3+ on minute/range charts, drops to 2 on fast (4-range / fast tick) charts.**
- **`[v2]`** Downgrade **low cell-volume** stacks (e.g. 146/12/44 = "pathetic") vs high-volume stacks.
- **`[v2]`** **Position-within-bar (top/mid/bottom) has NO predictive edge — do not weight it.**
- **`[v2]` Invalidation:** an **opposing** stacked/multiple imbalance in the zone flips direction (trade the second); an **opposite-direction next-bar ratio can negate the signal in 1 bar** (faster than ~5-bar decay). Decay = explicit exit counter: bar 3 watch, bar 4 exiting, bar 5 out. **P4/D3/E5.**

### `[v2]` 2.14 Back-to-back POC reversal/magnet
- 2+ consecutive bars share the exact POC price → mark the level; trade the **return** to it after price leaves (not while it sits there). Stop a few ticks beyond the level. Fails sometimes → stop mandatory. **P3/D3/E3** (single-source-rich: Ch082/v259, supporting POC-migration chunks).

### `[v2]` 2.15 Order-flow sequencing = CONTINUATION (anti-signal)
- Escalating volume eaten *through* successive levels = continuation, **not** reversal. Use as a **suppressor** of counter-trend reversal signals (a false-positive filter, not an entry). **P3/D3/E3.**

### `[v2]` 2.16 Volume-in-value (Stratum) — orthogonal confirmation
- Volume distribution within the value area (NOT delta). Optional **confirmation axis**, not a standalone trigger; fires on bar close, follow-through gate available. Keep separate from the delta/imbalance engine. **P2/D4/E3** (Subj).

## 3. Scoring model (unchanged structure; `[v2]` notes)
- Gates G1 location / G2 catalyst / G3 follow-through retained. **`[v2]` G3 is timeframe-conditional** (relax/disable ≥5-min and for ultra bonds/palm oil).
- Confluence weights: **`[v2]`** add "intrabar give-back/hidden flip" (+1.5) and "back-to-back POC / abandoned VA" (already +2 absorption); "volume-in-value agree" (+0.5, optional). Multiple-imbalance weighted **≥** stacked.
- Still a **ranking approximation**, not arithmetic ("6 plots ≠ buy", re-confirmed Ch082/v257).

## 4. Confirmation logic `[v2]`
- v1 retained. **`[v2]`** The 2-tick/2-bar follow-through gate **culls ~25–45% of raw signals** — it is the single load-bearing quality filter. Configurable 1–2 ticks / 1–2 bars (max 5/5). **Timeframe-conditional:** disable on ≥5-min charts and for ultra bonds / palm oil. **`[v2]`** Confirmation delta should *build* bar-over-bar; an intrabar give-back to near-zero is itself confirmation of the flip.

## 5. Invalidation logic `[v2]`
- v1 retained (inside-bar void, opposite delta, level breach). **`[v2]` Time stop ≈ 1 hour / contextual** (was ~10 min) — 30–60 min patience on slow instruments; ~10 min only on fast tick charts. **`[v2]`** Order-flow signal has a **~30–60 min freshness shelf-life** and degrades beyond a 5-min chart. **`[v2]`** Opposite next-bar ratio kills a stacked-imbalance thesis in 1 bar.

## 6. False-positive filters `[v2]`
(v1 1–9 retained.) **`[v2]` 10.** Zero/near-zero delta = **noise**, never a signal. **`[v2]` 11.** Order-flow **sequencing** (escalating volume through levels) = continuation → suppress counter-trend fades. **`[v2]` 12.** Flow-driven regime (failed divergences) → **invert divergence into a breakout ENTRY**, don't fade.

## 7. ⚠️ [FORCED] revisit list (v1 items retained; `[v2]` additions)
1–10 from v1 stand. **`[v2]` additions:**
11. **Intrabar delta give-back %** (80–96% in examples) — author-flagged NEEDS-OP; keep as "closes far inside its intrabar extreme," not a hard %.
12. **Ratio 28 vs 30 vs 27** — platform/era calibration; don't hard-line; reproduce the formula and validate (still undisclosed).
13. **Follow-through cull % (25–45)** is descriptive, not a tuning target; and the gate is **timeframe-conditional** (don't apply it on ≥5-min).
14. **Multiple-vs-stacked superiority** — backtest before hard-coding the inversion.
15. **Time stop ~1 hr vs ~10 min** — make it a parameter scaled by chart speed; the wrong choice will either bleed winners or hold losers.
16. **Per-instrument numbers** (10yr=50, NQ=3, neutral ±25/±150) — examples, not constants.
17. **Flow-driven trigger count** (2 vs 3 failures) & window (~30–60 min) — keep a range / consecutive-count.

## 8. Open quantitative questions (v1 + `[v2]`)
v1 questions stand. **`[v2]`** add: Does the intrabar give-back read beat close-delta? Does multiple-imbalance actually pay earlier/more than stacked? Optimal time-stop by chart speed? Does sequencing-as-suppressor cut false fades without killing edge? Does volume-in-value add orthogonal lift?

→ Rows in `03_..._Testable_Hypotheses_v2.csv`; NT mapping in `04_..._Indicator_Spec_v2.md`.
