# Extraction Progress Ledger

**STATUS: COMPLETE — 115 / 115 chunks extracted (100%, full corpus).**

| Pass | Chunks | Notes |
|---|---|---|
| v1 (initial) | 33 | all 17 T1 teaching + 16 era-spanning T2 |
| v2 (delta pass) | 82 | 80 via workflow `wi3gjm9ds` (Sonnet) + 2 retried (026, 032, socket errors) |
| **Total** | **115** | T1=17, T2=86, T3=12 — verified: 0 chunk files lack an extraction |

Every chunk has `Chunk_NNN_Extraction.md` (schema A–R). The 82 v2 extractions were delta-filtered against `../scripts/KNOWN_MODEL_DIGEST_v1.md` and consolidated into `../knowledge_base/20_Remaining_Chunks_Delta_Report_v2.md`.

## Outcome
- v1 spine **re-confirmed, not overturned** (corpus is highly redundant).
- ~12 material refinement threads → integrated into v2 flagships (`01/02/03/04 _v2`), v1 preserved.
- Coverage report: `../knowledge_base/21_Full_Corpus_Coverage_Report_v2.md`.

## Reproduce / re-run a chunk
Agent prompt: "Read `../scripts/EXTRACTION_INSTRUCTIONS.md` (+ `KNOWN_MODEL_DIGEST_v1.md` for a delta pass), read `../chunks/Chunk_NNN_Orderflows_Transcripts.md` IN FULL, write the A–R extraction to `../chunk_extractions/Chunk_NNN_Extraction.md`." Full re-sweep: `Workflow` over the chunk list (see `scripts/orderflows-remaining-delta-*.js`).
