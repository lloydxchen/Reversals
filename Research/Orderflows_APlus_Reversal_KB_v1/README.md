# Orderflows A+ Reversal Knowledge Base (v1)

**Goal.** Reverse-engineer the implicit order-flow / reversal model taught by Michael "Mike" Valtos (Orderflows) across ~499 of his YouTube videos, and turn it into practical research assets for building a NinjaTrader indicator that predicts **A+ reversal setups**.

This is **not** a transcript anthology or a content summary. It optimizes for **extracting the model**, **operationalizing the model**, and **building indicator logic** — evaluated against three KPIs:

1. **Qualitative A+ reversal framework** — setup types, tiers (A+/great/good/mediocre/bad), order-flow story, psychology, who is trapped/exhausted, where absorption happens, what validates/invalidates, what strengthens/weakens.
2. **Operational / quantitative model** — measurable variables, candidate + dynamic thresholds, data requirements, scoring, confirmation/invalidation, false-positive filters, hypotheses.
3. **NinjaTrader indicator spec** — what it calculates/plots, when bull/bear signals print, grading, alerts, dashboard, CSV/backtest fields, repainting concerns, implementation risks.

> **Guiding principle (see `Reversals/AGENTS.md` "No fake edge rule").** Stick as close as possible to what he actually says. Do **not** force qualitative statements into rigid math. Where we *do* tighten something into a number or a binary, it is flagged so it is the first thing to revisit if the model underperforms. Blank/qualitative is better than wrong-but-precise.

---

## Inputs (read-only — never modified by this pipeline)

- **Raw transcripts:** `C:\YTTranscripts\Orderflows_Dedup_v2\` — 499 deduplicated `.vtt` files (YouTube auto-captions). The pipeline only *reads* these. The old raw `.en`/`.en-orig` duplicate folder is **not** used.

## Output folder structure

```
Orderflows_APlus_Reversal_KB_v1/
├─ README.md                          ← this file
├─ Orderflows_Transcript_Index_v1.csv ← master index of all 499 transcripts
├─ scripts/                           ← reproducible Python pipeline
│   ├─ of_pipeline.py                 ← clean → index → chunk → reports
│   └─ make_kb_skeleton.py            ← creates the knowledge_base/ file scaffold
├─ clean_transcripts/                 ← 499 cleaned Markdown transcripts (1 per video)
├─ chunks/                            ← word-budgeted chunk files for extraction
│   └─ Chunk_NNN_Orderflows_Transcripts.md
├─ chunk_extractions/                 ← structured model-extraction notes, 1 per chunk
│   ├─ Chunk_NNN_Extraction.md
│   └─ _EXTRACTION_PROGRESS_LEDGER.md ← what is done / remaining + how to continue
├─ knowledge_base/                    ← synthesized deliverables (00–19)
└─ quality_reports/                   ← pipeline QA
    ├─ transcript_count_report.md
    ├─ smallest_files_report.md
    ├─ duplicate_check_report.md
    └─ chunking_report.md
```

---

## Pipeline (reproducible)

All steps are in `scripts/of_pipeline.py`. It is **idempotent** and read-only on the raw VTTs.

```bash
cd scripts
python of_pipeline.py clean     # VTT → cleaned Markdown + Orderflows_Transcript_Index_v1.csv
python of_pipeline.py chunk     # cleaned MD → chunk files (default 26,000 words/chunk)
python of_pipeline.py reports   # quality_reports/*
# or:  python of_pipeline.py all
```

### Step 1 — Clean (`clean`)
For each `.vtt`:
- strip `WEBVTT` / `Kind:` / `Language:` / `NOTE` / `STYLE` headers;
- strip cue timing lines and inline `<00:00:00.000><c>word</c>` word-timing tags;
- collapse the YouTube **rolling-caption duplication** (drop any line equal to the previously emitted line);
- decode common HTML entities; normalize whitespace;
- rebuild readable paragraphs with `[mm:ss]` **timestamp anchors** (a new paragraph every ~40 s or ~90 words) so extractions stay **traceable** to a location in the source video.

Metadata is inferred from the filename pattern `YYYYMMDD - Title [VIDEOID].en.vtt`:
- **date** ← leading `YYYYMMDD`; **title** ← middle (Windows-illegal glyphs like `：` restored); **video_id** ← `[...]`.

Output: one `clean_transcripts/NNNN_<slug>.md` per video (with YAML frontmatter), plus the master index CSV.

### Step 2 — Index (`Orderflows_Transcript_Index_v1.csv`)
Columns: `video_number, inferred_date, inferred_title, video_id, source_vtt_path, cleaned_md_path, word_count, line_count, file_size_bytes, has_transcript, notes`.
`line_count` = number of de-duplicated caption segments. `has_transcript` = `FALSE` if `< 25` words (none in this corpus).

### Step 3 — Chunk (`chunk`)
Whole transcripts are packed into chunk files up to a **word budget** (default 26,000). A transcript is never split unless it alone exceeds 1.3× the budget (none do here). Chunks are **grouped by relevance tier** so the highest-value content is front-loaded:

| Tier | Meaning | Extraction priority |
|---|---|---|
| **T1** | Explicit reversal / exhaustion / absorption / trap **teaching** videos | Highest — extract first |
| **T2** | Live market-analysis / trade-recap (model **applied** in real time) | High — operational nuance |
| **T3** | Product launches, platform tutorials, announcements | Low model value |

> Tiering is a **coarse, title-based triage** to decide *reading order only*. It is **not** a model feature and is never used to label bars or build signals.

### Step 4 — Quality reports
`transcript_count_report.md`, `smallest_files_report.md`, `duplicate_check_report.md`, `chunking_report.md`.

---

## Corpus facts (this build)

- **499** `.vtt` files found → **499** cleaned transcripts (0 near-empty).
- **~2.54 million** words; date range **2016-05-26 → 2026-06-15**.
- **499** unique video IDs, **0** duplicate IDs, **0** byte-identical cleaned bodies.
- **115** chunks @ 26k-word budget: **T1 = 17**, **T2 = 86**, **T3 = 12**.

---

## How to read the knowledge base

Start with the four flagship deliverables, then the supporting files:

1. `knowledge_base/01_APlus_Reversal_Qualitative_Framework.md` — **KPI 1**
2. `knowledge_base/02_APlus_Reversal_Operational_Model.md` — **KPI 2**
3. `knowledge_base/03_APlus_Reversal_Testable_Hypotheses.csv` — **KPI 2 (testable rows)**
4. `knowledge_base/04_NinjaTrader_APlus_Reversal_Indicator_Spec.md` — **KPI 3**

Supporting: `05_Order_Flow_Principles` … `19_Open_Questions_and_Contradictions`, plus `00_Master_Index.md` and `18_Transcript_Evidence_Map.md`.

**Evidence & uncertainty conventions used throughout:**
`[REPEATED]` = stated across many videos · `[ONCE]` = single mention · `[SPECULATIVE]` = our inference, not his words · `[FORCED]` = we tightened a qualitative idea into a number/binary (revisit first if the model breaks). Every substantive claim cites `(video #, short title, [mm:ss])` where possible.

## What this pipeline does NOT do
- Does not modify, move, or delete any raw VTT file.
- Does not edit unrelated repo files, methodology docs, or NinjaTrader indicator code.
- Does not present AI inference as fact (AI reasoning is the *lowest* tier in `AGENTS.md`'s validation hierarchy).
