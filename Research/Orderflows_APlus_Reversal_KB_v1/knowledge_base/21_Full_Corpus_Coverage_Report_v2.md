# Full-Corpus Coverage Report (v2)

## Headline
**All 115 chunks are now extracted (100%).** The v2 flagship files are based on **full-corpus extraction** of the 499 transcripts (2016→2026).

## Counts
| Metric | Value |
|---|---|
| Total transcripts (cleaned) | 499 |
| Total chunks | 115 (T1=17, T2=86, T3=12) |
| Chunks processed **before** this pass (v1) | 33 (all 17 T1 + 16 T2) |
| Chunks processed **in** this pass | 82 (80 via workflow `wi3gjm9ds` + 2 retried) |
| **Total chunks now processed** | **115 / 115 (100%)** |
| Chunk extraction files on disk | 115 (`chunk_extractions/Chunk_NNN_Extraction.md`) |

## Were any chunks skipped? Why?
**No chunks skipped.** Two chunks (**026, 032**) failed on the first workflow run due to transient API socket errors (not content issues); both were **retried successfully** with standalone agents and their extraction files are present. Verified: 0 chunk files lack a matching extraction file.

## Are the v2 flagships based on full-corpus extraction?
**Yes.** `01/02/03/04 _v2` integrate the consolidated deltas from all 82 remaining chunks (plus the original 33). The delta synthesis is in `20_Remaining_Chunks_Delta_Report_v2.md`. v1 files are preserved unchanged.

## What the full corpus changed (one line)
The v1 **spine was re-confirmed, not overturned** — the corpus is highly redundant. v2 adds **refinement and scoping**: intrabar Max/Min-delta read, ratio as binary two-tier soft floor, follow-through gate quantified + timeframe-conditional, multiple≥stacked tiering inversion, delta-sign context branch, time stop ≈1 hr, instrument+timeframe threshold scaling, and three new/auxiliary setups (back-to-back POC, volume-in-value, sequencing=continuation). Full list: `20_..._Delta_Report_v2.md` §9.

## Coverage quality notes
- **T1 (teaching) = 100%** and **T2/T3 = 100%** now. Earlier `[ONCE]`/`★` single-source flags in v1 files `18`/`19` can now be cross-checked against the full set; most are confirmed (e.g., delta-surge "4 bars", sweep-with-no-stacked-imbalance appear in additional chunks).
- Extraction model mix: the original 33 used Opus; the 82 used Sonnet (verified against sample files, e.g. Ch082 — depth comparable). Both followed the same A–R schema + delta digest.
- Per-chunk content value (this pass): ~0 "rich" / ~71 "mixed" / ~9 "thin" (T3 product/announcement chunks were thinnest, as expected).

## Remaining limitations (unchanged in kind from v1; now full-corpus-confirmed)
1. **Ratio formula still undisclosed** — values now well-bounded (7 in 2017; 27/28/30 high, 0.69/0.7699 low across platforms) and confirmed **binary** (magnitude doesn't grade), but the computation must still be reverse-engineered and validated.
2. **Chart-construction dependence** — confirmed across many chunks; signals exist/vanish by bar type and degrade beyond a ~5-min chart. A single-chart indicator inherits this. **Highest structural risk.**
3. **Many thresholds are deliberately soft / per-instrument / per-timeframe** — author-flagged NEEDS-OPERATIONALIZATION (intrabar give-back %, delta-surge increments, flow-driven count/window). Do **not** harden these into global constants (see `02_v2` §7 FORCED list).
4. **Absorption / "prominent" POC / volume-in-value** remain partly subjective; value-area abandonment and back-to-back-POC are the clean/binary parts.
5. **Targets remain discretionary** — not operationalizable from transcripts; leave to ATM/level logic.
6. **Nothing is backtested or compile-verified** — this is research material (repo `AGENTS.md` validation tier 4–5). The v2 model is a *better-scoped first pass*, to be confirmed by backtest + NinjaTrader behavior.

## Provenance
Workflow `wi3gjm9ds` (82 Sonnet extraction agents + 1 Opus consolidation; 2 retried via standalone agents). Consolidation cross-checked against sample extraction files. Script: `scripts/` (`of_pipeline.py`, `EXTRACTION_INSTRUCTIONS.md`, `KNOWN_MODEL_DIGEST_v1.md`, `make_hypotheses_csv_v2.py`).
