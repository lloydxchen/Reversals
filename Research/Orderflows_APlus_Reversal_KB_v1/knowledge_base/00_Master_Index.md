# Master Index — Orderflows A+ Reversal Knowledge Base

Reverse-engineered order-flow reversal model of **Michael "Mike" Valtos (Orderflows)**, built from 499 of his YouTube transcripts (2016→2026) to support a NinjaTrader **A+ reversal** indicator.

## How to use this KB
1. Read **`01`** (the qualitative model + his tiering) → **`02`** (measurable rules + the `[FORCED]` revisit list) → **`03`** (testable rows) → **`04`** (NinjaTrader spec).
2. Use **`05`–`16`** as concept deep-dives, **`17`** as the feature dictionary for coding, **`18`** for source traceability, **`19`** before trusting/forcing anything.
3. Trace any claim: file cites `(ChNNN/v#, [mm:ss])` → open `../chunk_extractions/Chunk_NNN_Extraction.md` → map v# via `../../Orderflows_Transcript_Index_v1.csv` → read `../clean_transcripts/`.

## The three KPIs (what this KB is judged on)
1. **Qualitative A+ reversal framework** → `01` (+ `05`–`16`).
2. **Operational / quantitative model** → `02`, `03`, `17`.
3. **NinjaTrader indicator logic** → `04`.

## File map
| # | File | Purpose |
|---|---|---|
| 00 | this | index, glossary, status |
| 01 | APlus_Reversal_Qualitative_Framework | ★KPI1 — setups, tiering, A+ vs mediocre |
| 02 | APlus_Reversal_Operational_Model | ★KPI2 — variables, thresholds, scoring, **[FORCED] list** |
| 03 | APlus_Reversal_Testable_Hypotheses.csv | ★KPI2 — 24 backtestable rows |
| 04 | NinjaTrader_APlus_Reversal_Indicator_Spec | ★KPI3 — build guide |
| 05 | Order_Flow_Principles | why reversals happen |
| 06 | Reversal_Setup_Taxonomy | the one engine + families map |
| 07 | Exhaustion | his #1 concept |
| 08 | Absorption | incl. A+ value-area absorption |
| 09 | Stacked_Imbalances | imbalance mechanics & rules |
| 10 | Delta_Divergence | divergence, ratio, CVD, surge/weakness, green delta trap |
| 11 | Failed_Breakouts_Stop_Runs | failed signals + his stop-run skepticism |
| 12 | Trapped_Traders | contrarian view |
| 13 | Entry_Triggers | "let the market take you in" |
| 14 | Confirmation_and_Invalidation | the gate |
| 15 | Stop_Management_and_Risk | 1-tick stop, time stop, targets |
| 16 | Context_Filters | location, session, regime, levels, instrument |
| 17 | Feature_Engineering_Dictionary | features → columns → quality |
| 18 | Transcript_Evidence_Map | concept → sources |
| 19 | Open_Questions_and_Contradictions | tensions, undisclosed mechanics, backtest list |

## The model in one line
**Exhaustion/absorption of aggressors at a clean swing extreme, confirmed by the next 1–2 bars trading back through the signal bar — graded A+ by confluence + immediate follow-through + a clean (small-bar) stop.** Everything else is evidence for, or a filter on, that.

## Status & coverage (honest)
- **Pipeline:** 499/499 transcripts cleaned; 115 chunks; quality reports in `../quality_reports/`.
- **Extractions:** **33/115 chunks** — **all 17 T1 teaching chunks + 16 T2 live-application chunks**, spanning 2016→2026. Remaining 82 = lower-tier recaps/product (ledger: `../chunk_extractions/_EXTRACTION_PROGRESS_LEDGER.md`).
- **Why this is sufficient for a first pass:** the model is **redundantly encoded** — the same setups recur for a decade; T1 captures the explicit framework, the T2 sample confirms live application + invalidation across all eras. Concepts seen in only the sampled set are tagged `★`/`[ONCE]` in `18`/`19` and flagged for the full sweep.
- **Confidence:** qualitative framework **high**; thresholds **medium** (per-market, drift — parameters not constants); ratio/absorption mechanics **need reverse-engineering** (`19`).

## Glossary of his vocabulary
- **Exhaustion print / single print** — tiny volume (often 1 contract) at a bar's extreme = last aggressor done.
- **Absorption** — passive resting size eating aggressive orders (counter-delta, no price move).
- **Imbalance** — diagonal bid×ask ≥ ~4:1; **stacked** = 3+ consecutive; **multiple** = 3+ in a bar; **inverse** = opposite candle color (trapped).
- **Ratio** — proprietary single-bar number; ≥30 exhaustion, ≤0.69 defense (formula undisclosed).
- **Divergence** — new/equal extreme with opposite-sign delta.
- **(Prominent) POC** — bar's max-volume price; "line in the sand"; aqua/cyan bullish, magenta/pink bearish.
- **Value-area absorption / abandoned VA** — value area not retraded next bar = his "A+".
- **Delta surge / weakness** — 4 bars rising delta / 3 bars falling delta.
- **Green Delta Trap** — strong positive delta at a high with no continuation = bearish.
- **"Let the market take you in"** — enter only on next-1–2-bar follow-through through the signal bar.
- **"Kiss of death / French kiss"** — the single turn print; also the next-bar-inside failure.
- **"Unchanged"** — session open / prior close line; no-catalyst stay-out zone.
- **Tiering** — A+/my favorite/textbook/perfect → great/beautiful → nice/decent → marginal/half-hearted → skip/"wouldn't qualify" → failed.

## Provenance / honesty
Built by chunk-level extraction agents over the cleaned transcripts; synthesized here. AI inference is flagged `[SPECULATIVE]`; tightened quantifications `[FORCED]`; per the repo `AGENTS.md`, this is research material (validation tier 4–5), to be confirmed by backtest and NinjaTrader behavior, not treated as verified edge.
