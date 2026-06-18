# NinjaTrader A+ Reversal Indicator Spec (KPI 3)

A practical NinjaScript build guide that turns the operational model (file 02) into an indicator that **detects, grades, plots, alerts on, and exports** Mike Valtos's order-flow reversal setups. Written to align with this repo's existing volumetric exporters, the `Reversal_Hunter` grade scale, and `AGENTS.md` (signal logic in `OnBarUpdate`, render-only in `OnRender`, no lookahead, SharpDX, versioned filenames).

> **Scope note:** this is a *spec*, not compiled code. Per `AGENTS.md`, nothing here is compile-verified; the build must be validated in NinjaTrader. Preserve existing indicators — deliver this as a **new** file/class (suggested `OrderflowAplusReversal_v1`).

---

## 1. Indicator purpose
Detect **A+ order-flow reversal candidates** at swing extremes (exhaustion / absorption / imbalance / divergence confluence), **grade** them A+/A/B/C, **confirm** them with a follow-through gate, plot non-cluttering visuals, fire alerts, and export per-signal rows with MFE/MAE for backtest research. It encodes the **gate → confluence-score → follow-through** logic of file 02, not a single pattern.

## 2. Required & optional data series
**Required**
- A **Volumetric (footprint) bar series** — `AddVolumetric(Instrument.FullName, BarsPeriodType.Volumetric, baseType, basePeriod, ticksPerLevel)` or run on a volumetric primary. Gives per-price `GetBidVolumeForPrice` / `GetAskVolumeForPrice` / `GetDeltaForPrice`, bar delta, POC.
- OHLC of the primary series; instrument tick size; session iterator (open / prior close / "unchanged").

**Optional (improve grading / filters)**
- ATR (bar-size & move filters).
- Higher-timeframe / value-area series (value-area & POC build) — or reuse the repo's zone fields.
- ES/TICK/VIX context series (the repo's `Reversal_Hunter` already does this) for an optional confluence boost.
- Economic-calendar gate (news suppression) — manual input list if no feed.

## 3. Order Flow / Volumetric requirements
- **Footprint per-level volume** (bid×ask) — for exhaustion prints, diagonal imbalances, stopping volume, POC-at-extreme.
- **Bar delta + intrabar max/min delta** — `BarDelta`, `MaxSeenDelta`, `MinSeenDelta` (read intrabar extremes, not just final).
- **Cumulative delta** (`NinjaCVD`) — divergence radar.
- **Diagonal imbalance** flags (`BuyDiagonalImbalance`/`SellDiagonalImbalance`) with configurable ratio & min volume.
- Tick Replay **must be enabled** for accurate historical bid/ask delta (he stresses this; repo methodology requires it).

## 4. Core signal architecture (gate → score → confirm)
```
OnBarUpdate (Calculate = OnBarClose, or OnEachTick but only ACT on confirmed bars):
  1. On each CLOSED bar i:
     a. Compute features (delta, intrabar max/min, per-level vol, imbalances, POC/VA, swing flags).
     b. GATE: is bar i within tol ticks of a new N-bar swing extreme / HOD-LOD,
        after a prior move >= moveMin, away from open/unchanged, range <= k*ATR? 
        If not -> no candidate.
     c. PATTERN: does bar i show >=1 reversal trigger (exhaustion print / ratio+div /
        opposite-color stacked|multiple imbalance / absorption / green-delta-trap)?
     d. SCORE: sum weighted confluence dimensions -> raw score; apply trend-day & penalty filters.
     e. If gates pass & score >= Cmin -> register a CANDIDATE at bar i (direction, grade,
        signalHigh/Low, stop level). Draw "candidate" marker. DO NOT call it a trade yet.
  2. FOLLOW-THROUGH: for each open candidate, if within the next 1-2 bars price trades beyond
     signalHigh+buf (bull) / signalLow-buf (bear): promote to CONFIRMED signal, fire alert,
     export row, draw confirmed arrow + zone. Else after window -> cancel candidate.
  3. INVALIDATION / management: track inside-bar void, opposite delta, ~10-min time stop,
     stop breach; update MFE/MAE for research.
```
Separate **long** and **short** logic paths (per repo methodology — different mechanics).

## 5. Bullish signal logic (reference)
- **Gate:** `Low[0]` is lowest low over `SwingN` (or = LOD) within `Tol` ticks; prior down-move ≥ `MoveMin` (ATR-relative); not within `OpenTol` ticks of open/unchanged; `High[0]-Low[0] ≤ BigBarK*ATR`.
- **Triggers (any, scored):** exhaustion print = bid volume at `Low[0]` level ≤ `ExpVol` on a green bar (close>open); OR ratio≤0.69 with positive `BarDelta` (divergence); OR `BottomSellStackMax≥3` opposite-color; OR ≥3 multiple imbalances; OR green bar with strongly negative `MinSeenDelta` but close-delta≥0 (absorption); OR bullish PPOC/abandoned VA.
- **Confirm:** one of next 1–2 bars trades `> High[0] + Buf`.
- **Stop:** `Low[signalBar] - Buf`.

## 6. Bearish signal logic
Mirror of §5: new `SwingN` high / HOD, red bar, offer-side exhaustion print, ratio≥30 with negative delta, `TopBuyStackMax≥3` opposite-color, absorption (positive `MaxSeenDelta`, close-delta≤0), Green Delta Trap, bearish PPOC/VA. Confirm on next-1–2-bar break below `Low[0]-Buf`; stop `High[signalBar]+Buf`.

## 7. Scoring system & grades
- Compute the **gated weighted score** from file 02 §3 (exhaustion 2, absorption/abandoned-VA 2, delta weaken→flip 1.5, opposite-color stacked/multiple 1.5, ratio 1, strong-confirm-delta 1, CVD divergence 1, clean swing 1; penalties big-bar −1.5, trend-day −3).
- **Grade map (tunable; aligns to repo `Reversal_Hunter`):** **A+** = score ≥ `AplusMin` (default ~7) **and absorption present**; **A** ≥ ~5.5; **B** ≥ ~4; **C** ≥ ~2.5; below `Cmin` → no print.
- Expose `MinGradeToPrint` (default B) and `MinGradeToAlert` (default A) to cut clutter.
- ⚠️ Surface in tooltip that the score is a **ranking approximation** of his confluence reading, not a literal formula ("not a red-light/green-light system").

## 8. Context / session / volatility / volume-delta filters
- **Session/time:** tradable window param (default 07:00–15:00 CT); suppress pre-cash-open spike and last ~30 min; lunchtime de-emphasis.
- **News:** suppress `NewsMute` minutes after CPI/PPI/NFP/inventories (input list or feed).
- **Catalyst:** suppress within `OpenTol` ticks of open/unchanged.
- **Volatility:** `BigBarK*ATR` bar-size cap; optional ATR regime scaling of thresholds.
- **Volume/delta:** min bar volume; `DeltaPercent`/`MaxSeenDelta` for strong-bar confirmation.
- **Trend-day:** rolling failed-divergence counter ≥3 → suppress fades (prefer consecutive-count over clock).

## 9. Module specs (each = a toggle + params)
- **Exhaustion:** `ExpVol` (per-instrument; or dynamic low-percentile), bid/offer-side at extreme, `SwingN`.
- **Absorption:** green-bar-negative-delta / max-delta-near-0 / value-area-abandoned (next bar no re-entry).
- **Stacked/multiple imbalance:** `ImbRatio` (4:1 default; 2.5/3/3.5/10 alts), `ImbMinVol` (~10; per-instrument), `StackMin` 3, `ZoneTicks` ≤5, `Decay` 5 bars, **same-color = continuation (suppressed as reversal)**.
- **Trapped/inverse imbalance:** imbalance-vs-candle-color; require next bar trades away; **do not weight by trapped size**.
- **Failed-continuation/holding-vs-failing:** fresh-level held vs traded-through-fast.
- **Divergence/CVD:** per-bar & cumulative; radar only (needs paired trigger).

## 10. Confirmation & invalidation (implementation)
- **Confirmation = follow-through** (next 1–2 bars break extreme by `Buf`) — implemented either as a stop-entry order (live) or a post-close check (research). This gate is mandatory.
- **Invalidation:** inside-bar void within window; opposite delta/imbalance after confirm; ~10-min time stop (`TimeStopMin`); stop/level breach. Allow **one** second-chance re-entry if order-flow state unchanged (toggle).

## 11. Repainting & intrabar concerns ⚠️
- **Confirm everything on bar CLOSE.** Mike explicitly notes the exhaustion print/signal "can disappear before the bar closes" — so a forming-bar signal is *provisional*. Lock features on close. (Ch001/v4 [03:09]; Ch017/v499 no-repaint design)
- Run `Calculate.OnBarClose` for signal logic, OR `OnEachTick` but only register/confirm using **completed** bars (`if (IsFirstTickOfBar)` evaluate bar `[1]`).
- Follow-through across the next 1–2 bars is inherently forward-looking → either (a) live: place a real stop order at the trigger level; (b) research/backtest: only mark CONFIRMED after the trigger bar closes, and **timestamp the confirmed bar**, never back-date to the signal bar (no lookahead — repo `AGENTS.md`).
- MFE/MAE and "did it work" stats are **research-only** forward fields — never feed them back into real-time signal/score (leakage).
- Do not recompute history in `OnRender`; compute state in `OnBarUpdate`, store per-signal objects, render from them.

## 12. Alerts
- On **CONFIRMED** signal (default ≥ grade A): `Alert()` + optional sound, with text `"{Grade} {Long/Short} reversal {instrument} {price}"`.
- Optional second alert on **candidate** (pre-confirm) for discretionary traders (default off, to avoid noise).
- Optional Telegram/notification hook (preserve repo's existing notification pattern if reused).

## 13. Visual output (clean by default; per repo VISUAL_STYLE rules)
- **Arrow** at the signal/confirm bar pointing to the **exact entry bar & price** (keep `entryPrice` separate from `labelPrice`; leader line to the bar).
- **Grade badge** (A+/A/B/C) — small, offset so it does not cover candles/wicks.
- **Zone box** drawn from the signal level "**until tested**" (his own visual), faded ~20% opacity, green (bull)/red (bear).
- **Stop line** (1 tick beyond extreme) optional.
- **Dashboard panel** (Research mode): current bias, last signal grade, score breakdown (which dimensions fired), trend-day state, session/news state, count of signals today.
- **Live Mode = minimal** (arrow + badge); **Research/Review Mode = heavy** (zones, score breakdown, MFE/MAE boxes, click-to-inspect) — per `AGENTS.md`.
- Use **SharpDX/Direct2D/DirectWrite**, not SkiaSharp.

## 14. CSV export fields (align with `ResearchDataExporterV1`)
Per-signal row (one file per instrument/contract/run, repo path convention):
`SignalIndex, Timestamp(confirmed bar), SignalBarTime, Instrument, Direction, Grade, RawScore, ScoreBreakdown(json),
EntryPrice, StopPrice, SignalBarHigh, SignalBarLow, SignalBarClose,
TriggerType(exhaustion/ratio/imbalance/absorption/...), ExhaustVolAtExtreme, ImbalanceCount, StackMax,
BarDelta, MaxSeenDelta, MinSeenDelta, DeltaPercent, CVD, CvdDivergence(bool), POCPrice, POCPosition, ValueAreaAbandoned(bool),
SwingN_NewExtreme(bool), DistToOpenTicks, BarRangeTicks, ATR, TrendDayState,
Confirmed(bool), BarsToConfirm, MFE_Points, MAE_Points, BarsToMFE, ExitReason`
- Keep model-ready columns to a **strict known map** (repo "no fake edge" rule); leave blank rather than guess.

## 15. Backtesting fields
- `MFE_Points`, `MAE_Points`, `BarsToMFE`, `BarsToHit`, time-to-confirm, outcome at fixed horizons (e.g. +5/+10/+20 bars), R-multiple vs the 1-tick stop. (research-only; computed forward, never fed to live signal.)

## 16. Input parameters & smart defaults
| Param | Default | Notes |
|---|---|---|
| `SwingN` | 25 | alts 5/30/50; per market |
| `ExpVol` | 9 (rates/index), 5 (FX), 3 (crude) | or dynamic low-percentile |
| `ImbRatio` | 4.0 | 2.5/3/3.5/10 alts |
| `ImbMinVol` | 10 | per-instrument (was ~50 e-mini 2017) |
| `StackMin` | 3 | "three is the magic number" |
| `ZoneTicks` | 5 | opposing-imbalance overlap |
| `Decay` | 5 bars | imbalance staleness |
| `RatioHigh / RatioLow` | 30 / 0.69 | binary flags; formula TBD |
| `NeutralDeltaBand` | 50 | small-delta neutrality |
| `StrongDeltaPct` | 25 | normal 5–15 |
| `Buf` | 1 tick | follow-through & stop buffer |
| `ConfirmBars` | 2 | follow-through window |
| `TimeStopMin` | 10 | sideways exit |
| `BigBarK` | 1.75 | × ATR bar-size cap |
| `MoveMin` | 1.5×ATR | prior-move requirement (FORCED) |
| `OpenTol` | instrument-specific | catalyst filter |
| `MinGradeToPrint / Alert` | B / A | clutter control |
| Mode | Live / Research | visual heaviness |

All thresholds **per-instrument-overridable** (he refuses universal constants).

## 17. Known limitations & implementation risks
1. **Ratio formula undisclosed** — the Orderflows "ratio" (≥30/≤0.69) is proprietary; must be reproduced from footprint and validated against his flagged bars, or shipped as a placeholder. (2017 hinted ~7 → older/different definition.)
2. **Absorption & "clean swing" are partly subjective** — value-area-abandonment is clean/binary; generic "absorption" and "space to the left" are heuristics that may differ from his eye.
3. **Chart-construction dependence** — signals exist/vanish across bar types (range/tick/time/volume); a single-chart indicator will miss or fabricate signals another resolution would (not) show. Consider multi-series confirmation; warn the user.
4. **Score is an approximation** — he says confluence is "not a red-light/green-light system." Risk of over-trusting the number; validate ranking vs his verbal tiers before trading.
5. **Threshold drift / per-market scaling** — hard-coding `ExpVol`/`ImbMinVol`/`SwingN` will degrade across instruments and eras; must be parameters (see §7 [FORCED] list, file 02).
6. **Tick Replay & data quality** — wrong/missing bid-ask delta if Tick Replay off; bar delta becomes a proxy (repo flags this).
7. **Repaint/lookahead traps** — provisional intrabar prints; forward MFE/MAE leakage; back-dating confirmed signals. Handle per §11.
8. **Targets undefined** — he keeps targets discretionary ("it depends"); the indicator should signal entries/stops and leave targets to ATM/level logic, not invent fixed targets.
9. **Does not catch every turn** — by his own admission; expect misses; quiet sessions are normal, not a bug.

→ Features detailed in `17_Feature_Engineering_Dictionary.md`; rules/thresholds in `02_...Operational_Model.md`; testable rows in `03_...csv`.
