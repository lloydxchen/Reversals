# Evidence Extraction Notes

## Scope

- Input folder: `C:\YTTranscripts\Orderflows_Dedup_v2`
- Output folder: `C:\Users\chenk\Desktop\LloydTrading\Reversals\Research\Orderflows_APlus_Reversal_KB_codex_isolated_v1`
- VTT files scanned: 499
- Raw VTT files were not modified.

## Evidence Files Created

- `evidence\exhaustion_evidence.md` (80 entries)
- `evidence\absorption_evidence.md` (80 entries)
- `evidence\stacked_imbalances_evidence.md` (80 entries)
- `evidence\delta_divergence_evidence.md` (80 entries)
- `evidence\failed_breakouts_stop_runs_evidence.md` (80 entries)
- `evidence\trapped_traders_evidence.md` (80 entries)
- `evidence\entries_confirmation_invalidation_evidence.md` (80 entries)
- `evidence\context_filters_evidence.md` (80 entries)
- `evidence\ninjatrader_indicator_ideas_evidence.md` (80 entries)

## Extraction Method

- This was keyword/theme-based extraction.
- Minimal VTT cleaning was applied in memory only: WEBVTT headers removed, timestamp lines ignored, numeric cue IDs ignored, caption tags stripped, whitespace collapsed, and obvious consecutive duplicate caption fragments collapsed.
- Source filename and video ID were preserved for each evidence entry when the ID was available from the filename.
- Evidence snippets were ranked by theme keyword density and lightly capped per theme to keep this phase lightweight.

## Limitations

- This is not a full cleaned transcript anthology.
- Keyword/theme matching can miss useful evidence that uses different wording.
- Keyword/theme matching can include false positives where a term is mentioned casually rather than as a trading rule.
- Caption transcription errors remain possible because the raw VTT wording is preserved after minimal cleaning.
- Nearby context is local caption context only, not a full video-level argument reconstruction.
- No final A+ reversal model, rule hierarchy, weighting, or profitability synthesis was created in this phase.
