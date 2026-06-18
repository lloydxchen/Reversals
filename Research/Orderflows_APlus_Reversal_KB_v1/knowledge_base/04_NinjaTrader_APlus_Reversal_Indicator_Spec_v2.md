# NinjaTrader A+ Reversal Indicator Spec — v2 (full-corpus)

Supersedes `04_..._Indicator_Spec.md` (v1 preserved). Based on **all 115 chunks**. `[v2]` marks changes; unmarked content is v1 and re-confirmed. Build per `AGENTS.md` (signal in `OnBarUpdate`, render-only in `OnRender`, no lookahead, SharpDX, versioned filenames). Suggested class/file: `OrderflowAplusReversal_v2`. Not compile-verified.

## `[v2]` Changes from v1 (summary)
1. **Intrabar Max/Min-delta module** (the "hidden flip"): grade by close-vs-Max/Min give-back, not close-delta alone.
2. **Time stop ≈ 1 hr / chart-speed-scaled** (was ~10 min); add order-flow **freshness window** (~30–60 min; degrades >5-min chart).
3. **Follow-through gate is timeframe-conditional** (off ≥5-min; off ultra bonds/palm oil) and culls ~25–45% of signals; candle-color filter is a **toggle** (he applies it manually).
4. **Ratio** = two-tier soft (28 watch/30 preferred; low 0.69/0.7699) and **binary** (don't grade by magnitude).
5. **Multiple ≥ stacked**; stack count→2 on fast charts; downgrade low cell-volume stacks; **drop position-within-bar** (no edge).
6. **Delta-sign context branch** + pos-delta-at-low disambiguation via **per-level bid vs offer** volume.
7. **Per-instrument AND per-timeframe** parameter tables (exhaustion 10yr≈50/NQ≈3/ES≈0; neutral ±25 FX/±150 heavy ES).
8. New optional modules: **back-to-back POC**, **volume-in-value (Stratum, orthogonal)**, **sequencing = continuation (suppressor)**; **zero-delta = noise** gate.

---

## 1–3. Purpose / data series / OF requirements (unchanged from v1)
Detect/grade/confirm/plot/alert/export A+ reversals at swing extremes. Requires a **Volumetric (footprint)** series (`AddVolumetric`), OHLC, delta, cumulative delta, diagonal-imbalance flags, Tick Replay ON. `[v2]` **Explicitly require per-bar `MaxSeenDelta` & `MinSeenDelta`** (not just close `BarDelta`) and **per-level bid/ask volume at the extreme** (for the delta-sign disambiguation). Optional: ATR, value-area/POC build, ES/TICK/VIX context, news calendar.

## 4. Core architecture (gate → score → confirm) — `[v2]` refinements
Unchanged skeleton (compute on closed bars; candidate → follow-through → confirm/cancel). `[v2]`:
- **Follow-through gate is timeframe-conditional**: apply on <5-min / range / tick; **disable on ≥5-min and for ultra bonds/palm oil** (use bar-close + order-flow confirm instead).
- **Candle-color filter = input toggle** (he applies it by eye; default ON for <5-min).
- Add a **regime/suppressor pre-check**: if order-flow **sequencing** (rising volume through successive levels) or **flow-driven** (≥N failed divergences in window) → suppress counter-trend reversals, optionally enable breakout entries.

## 5–6. Bull / bear signal logic — `[v2]` additions
v1 retained. `[v2]` add to triggers:
- **Hidden-flip:** at a new swing low, `MinSeenDelta` strongly negative but close `BarDelta` ≈0/positive (large give-back) → bullish absorption. (mirror at highs)
- **Delta-sign branch:** negative delta + green bar = bullish absorption; positive delta + red bar = bearish supply. For positive delta at a new low, **disambiguate via per-level bid vs offer**: offer-side dominance at the low = bearish continuation (suppress long); bid-side absorption = bullish.
- **Multiple-imbalance trigger weighted ≥ stacked**; stack count threshold = `StackMin` (3, →2 on fast charts); require decent cell volume; **ignore imbalance position-within-bar**.
- **Back-to-back POC** magnet: mark levels where ≥2 consecutive bars share POC; arm a reversal on the *return* to the level.

## 7. Scoring & grades (unchanged scale; `[v2]` weights)
A+/A/B/C (repo `Reversal_Hunter` scale). `[v2]` add weights: hidden-flip give-back (+1.5), back-to-back-POC/abandoned-VA (+2), multiple-imbalance ≥ stacked, volume-in-value agreement (+0.5 optional). Gate G3 (follow-through) timeframe-conditional. Score remains a **ranking approximation** ("6 plots ≠ buy").

## 8. Filters — `[v2]`
v1 (session 07:00–15:00 CT, avoid open/news/lunch, "unchanged" stay-out, big-bar cap, trend-day) retained. `[v2]` add: **zero/near-zero delta = noise (suppress)**; **sequencing = continuation (suppress fades)**; **cross-market** range check (if all watched markets are range-bound, suppress); per-instrument session nuances (currency ends ~14:00 CT; crude sweet spot ~05:00–13:00 CT; bonds quiet on Japan/HK holidays).

## 9. Module specs — `[v2]` deltas only
- **Exhaustion:** `ExpVol` **per-instrument AND timeframe** (10yr≈50, NQ≈3, ES≈0, gold ≤3–7, euro ≤2–7) or **dynamic low-percentile** of recent per-level volume — **NOT a global single-digit constant**.
- **Imbalance:** `ImbRatio` 4 (alts), `ImbMinVol` per-instrument, `StackMin` 3 (→2 fast charts), cell-volume quality gate, decay = 3-watch/4-exit/5-out, **opposing imbalance flips direction**, **opposite next-bar ratio voids in 1 bar**.
- **Ratio:** `RatioHigh` 28(watch)/30(pref), `RatioLow` 0.69 (NT 0.7699); **binary** (no magnitude grading); reproduce formula + validate.
- **Delta:** `NeutralBand` ±50 (±25 FX / ±150 heavy ES); intrabar give-back (soft, not hard %); strength >25% delta/vol; series-based weakening (one bar ≠ flip).
- **`[v2]` Volume-in-value (Stratum):** optional orthogonal module (volume distribution in VA, not delta); per-instrument magnitude 1–5; **intrabar signal repaints — confirm on close** (use the follow-through "trade entry signal").
- **`[v2]` Back-to-back POC:** track per-bar POC; mark ≥2 consecutive equal; trigger on return.

## 10. Confirmation & invalidation — `[v2]`
Follow-through (timeframe-conditional, ~25–45% cull) + delta build. `[v2]` **Time stop ≈ 1 hr scaled by chart speed** (≈10 min fast tick → ≈60 min slow); **order-flow freshness ~30–60 min**; **immediate opposite next-bar signal = void** (high-failure). Inside-bar void, level breach, second-chance re-entry once — unchanged.

## 11. Repainting & intrabar — `[v2]` reinforced
Confirm on bar close (intrabar prints provisional — Stratum and exhaustion prints explicitly can change before close). Follow-through is forward → live: real stop order; research: timestamp the **confirmed** bar (no back-dating). MFE/MAE forward fields research-only (no leakage). `[v2]` Intrabar Max/Min delta are finalized at close; use closed-bar values for the hidden-flip read.

## 12–13. Alerts / visuals (unchanged + `[v2]`)
v1 retained (arrow at entry bar/price, grade badge, zone "until tested", dashboard, Live=minimal/Research=heavy, SharpDX). `[v2]` dashboard adds: intrabar give-back %, regime (trend/rotation/flow-driven/sequencing), back-to-back-POC levels, per-instrument param set in use, freshness/time-stop countdown.

## 14–15. CSV / backtest fields — `[v2]` additions
v1 columns retained. `[v2]` add: `MaxSeenDelta, MinSeenDelta, DeltaGiveBackPct, RatioValue, RatioFlag, ImbType(stacked|multiple|inverse), StackCount, CellVolMin, DeltaSignContext, BidAskAtExtreme, BackToBackPOC(bool), VolInValueSkew, Regime(trend|rotation|flowdriven|sequencing), TimeframeGateApplied(bool), FreshnessMinsLeft`. MFE/MAE/bars-to-confirm research-only.

## 16. Inputs & smart defaults — `[v2]` (per-instrument AND per-timeframe)
v1 table retained; `[v2]` changes: `ExpVol` per-instrument table (10yr 50 / ES 0 / NQ 3 / gold 5 / euro 5 …) **or** `UseDynamicExpVol`(percentile); `TimeStopMin` chart-speed-scaled (10 fast → 60 slow); `FollowThroughEnabledTimeframeMax`=4min; `CandleColorFilter` toggle (default ON <5min); `RatioHigh` 28/30, `RatioLow` 0.7699; `StackMin` 3 (2 on fast); `WeightMultipleGE Stacked`=true; `IgnoreImbalancePosition`=true; `NeutralBand` per-instrument; `SequencingSuppressor`/`ZeroDeltaSuppressor` toggles.

## 17. Known limitations & risks — `[v2]`
v1 risks stand (ratio undisclosed, absorption subjective, **chart-construction dependence**, score is approximation, threshold drift, tick-replay, repaint/lookahead, targets undefined, doesn't catch every turn). `[v2]` add:
- **Timeframe-conditional logic** must be respected (applying the follow-through gate on ≥5-min, or a 10-min time stop on slow instruments, will degrade the model — see v2 §10, file 02 §7).
- **Per-level bid/ask** is required for the delta-sign disambiguation; without it the polarity guard is weaker.
- **Multiple ≥ stacked** and **back-to-back POC** are newer/less-confirmed — gate behind toggles and backtest before trusting.
- **Volume-in-value (Stratum)** is orthogonal and partly subjective — optional confirmation only; don't stack mechanically.

→ Rules in `02_..._Operational_Model_v2.md`; rows in `03_..._Testable_Hypotheses_v2.csv`; evidence in `20_Remaining_Chunks_Delta_Report_v2.md`.
