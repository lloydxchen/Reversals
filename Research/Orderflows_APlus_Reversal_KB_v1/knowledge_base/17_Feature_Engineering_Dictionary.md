# Feature Engineering Dictionary

Concrete features to compute for the model/indicator, with definition, formula sketch, data source / existing repo column, and **mapping quality** (per `AGENTS.md`: blank > wrong). Supports KPI 2/3. `Col` = column already produced by the repo's exporters.

> **Mapping quality:** **High** = direct/objective from data; **Med** = derived with a `[FORCED]` choice; **Subj** = partly subjective, needs validation. Never fill a model-ready column by keyword/guess.

## A. Delta features
| Feature | Definition / formula sketch | Source / `Col` | Quality |
|---|---|---|---|
| `bar_delta` | ask_vol − bid_vol over bar | `BarDelta`,`FootprintDelta` | High |
| `max_delta`,`min_delta` | running intrabar max/min of cumulative delta | `MaxSeenDelta`,`MinSeenDelta` | High |
| `delta_pct` | bar_delta / bar_volume | `DeltaPercent`,`DeltaPerVolume` | High |
| `delta_strong` | \|delta_pct\| > 0.25 (normal 0.05–0.15) | derived | Med `[FORCED]` |
| `delta_conviction` | \|bar_delta\| ≥ 0.95·\|max/min\| (closes near extreme) | derived | Med |
| `delta_weakening_k` | \|delta\| strictly/≈decreasing over last K bars, same sign | derived | Med `[FORCED]` (K, "decrease") |
| `delta_flip` | sign(bar_delta) changes on/after signal bar | derived | High |
| `cvd` / `cvd_divergence` | session cum delta; new price extreme w/o new CVD extreme | `NinjaCVD`,`ExportSessionCVD` | High |
| `intrabar_reversal` | large \|max\| or \|min\| but close-delta opposite/near-0 | derived from max/min + close | Med |
| `neutral_delta` | \|bar_delta\| ≤ ~50 (ES) → no control | derived | Med `[FORCED]` (per-mkt) |

## B. Exhaustion / volume-at-level features
| Feature | Definition | Source | Quality |
|---|---|---|---|
| `exhaustion_print` | volume at bar's extreme level ≤ `ExpVol`, on bid-of-green-low / offer-of-red-high | footprint `BidVol`/`AskVol` at `IsBarLow`/`IsBarHigh` | High |
| `exp_vol_param` | threshold; 3 crude / 5 FX / 9–10 rates-index; or dynamic low-percentile | param | Med `[FORCED]`/dynamic |
| `vol_staircase` | per-bar volume decreasing into the extreme | derived | Med |
| `stopping_vol` | extreme-level vol ≥ `svPct`(30%)·bar_vol AND price halts | footprint + price | Med `[FORCED]` 30% |
| `decreasing_retest_vol` | each retest of a level trades less volume | derived | Med |

## C. Imbalance features
| Feature | Definition | Source / `Col` | Quality |
|---|---|---|---|
| `buy_imb`,`sell_imb` | diagonal ask[i]/bid[i−1] (or bid[i]/ask[i+1]) ≥ `ImbRatio`(4) & ≥ `ImbMinVol`(10) | `BuyDiagonalImbalance`,`SellDiagonalImbalance` | High |
| `stack_max` | longest run of consecutive same-side imbalances | `TopBuyStackMax`,`BottomSellStackMax` | High |
| `imb_count` | imbalances in bar (multiple ≥3) | `BuyImbalanceCount`,`SellImbalanceCount` | High |
| `inverse_imb` | imbalance dir opposite candle color (sell-imb in green / buy-imb in red) | imb flags + `close>open` | High |
| `imb_opposite_color_at_extreme` | failed stack then opposing stack within `ZoneTicks`(5) at swing | derived | Med |
| `imb_stale` | imbalance age > `Decay`(5) bars | bar index | High |
| `imb_closed_beyond` | bar closes beyond the stack (validity) | price + imb | High |

## D. Level / value-area features
| Feature | Definition | Source / `Col` | Quality |
|---|---|---|---|
| `poc_at_extreme` | POC price at bar high/low | `POCPrice`,`POCPosition` | High |
| `prominent_poc` | POC stands out (bullish low / bearish high); "line in the sand" | `POCPrice` + logic | Med (Subj prominence) |
| `value_area_hi/lo` | 70%(68.2%) value area | `TopZone*`/`BottomZone*` or VA build | Med |
| `va_abandoned` | next-bar range ∩ value area = ∅ | VA + next bar | High (binary) |
| `poc_inversion` | volume building above prior POC (R→S flip) | POC history + vol | Med |
| `dist_to_open` | ticks from signal to session open / "unchanged" / prior close | session levels | High |

## E. Location / structure / context features
| Feature | Definition | Source | Quality |
|---|---|---|---|
| `swing_extreme` | new highest-high/lowest-low over `SwingN`(25); or HOD/LOD | OHLC; `RequireNewHighLow` | High |
| `prior_move` | displacement over prior M bars (need a move to reverse) ≥ `MoveMin` | price/ATR | Med `[FORCED]` |
| `bar_range_atr` | (high−low)/ATR; big-bar filter > `BigBarK`(1.75) | OHLC/ATR | High |
| `candle_color` | close>open (green) / <open (red) | OHLC | High |
| `trend_day_state` | failed-divergence count in window ≥3 | derived; `ChopState` | Med `[FORCED]` window |
| `session_state` | in-window / pre-open / news-mute | clock + calendar | High |

## F. Confirmation / outcome (research-only — never feed to live signal)
| Feature | Definition | Quality |
|---|---|---|
| `followthrough` | next 1–2 bars break signal extreme by `Buf` | High |
| `bars_to_confirm` | bars until trigger fills | High |
| `mfe_points`,`mae_points`,`bars_to_mfe` | forward excursion (research/backtest only) | High (leakage risk — keep out of live score) |

## Composite
`aplus_score` = gated weighted sum of B/C/D/A/E dimensions (file 02 §3) → grade A+/A/B/C. **Flagged as a ranking approximation, not his literal method.**

## Engineering cautions (repo "no fake edge")
- Every per-instrument threshold is a **parameter**, not a constant.
- Leave a feature **blank** if data/mapping is uncertain rather than approximating.
- Keep forward/outcome features strictly separate from real-time signal inputs (no leakage).
- Validate `ratio`, `prominent_poc`, "absorption" against his flagged example bars before trusting (Subj items).
