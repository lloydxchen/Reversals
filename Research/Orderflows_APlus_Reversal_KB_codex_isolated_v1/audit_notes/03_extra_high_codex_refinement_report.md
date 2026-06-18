# Extra High Codex Refinement Report

## Files Created

- `knowledge_base\01_APlus_Reversal_Qualitative_Framework_v2_extra_high.md`
- `knowledge_base\02_APlus_Reversal_Operational_Model_v2_extra_high.md`
- `knowledge_base\03_APlus_Reversal_Testable_Hypotheses_v2_extra_high.csv`
- `knowledge_base\04_NinjaTrader_APlus_Reversal_Indicator_Spec_v2_extra_high.md`
- `audit_notes\03_extra_high_codex_refinement_report.md`

No v1 files were overwritten.

## Main Refinements

- Sharpened taxonomy from many named setups into a decision stack: location, failure mechanism, confirmation, invalidation, management.
- Separated primary A+ family from lower-confidence supporting modules.
- Removed generic "large volume means reversal" logic. Volume only matters after failure.
- Made delta logic stricter: positive delta is bearish only when absorbed/no continuation at resistance; negative delta is bullish only when absorbed/no continuation at support.
- Changed scoring from one blended idea to separate bullish/bearish candidate scoring.
- Added hard gates and grade caps so weak data or weak context cannot become A+ by accident.
- Made intrabar/confirmed/triggered/validated/invalidated states explicit for NinjaTrader implementation.

## Strongest Refined Hypotheses

- VH001: edge exhaustion after bar close at meaningful level.
- VH002: absorption-to-exhaustion as the flagship A+ model.
- VH003/VH005: absorption measured by effort-versus-result and delta/close contradiction.
- VH004: positive delta trap at highs/resistance.
- VH014: quick-response/no-response exit.
- VH018: composite A+ confluence score.

## Biggest Uncertainties Preserved

- Absorption is partly inferred without DOM.
- Trapped traders are partly psychological and should not be over-labeled.
- Stop-runs and sweeps are under-sampled in the capped evidence.
- Climactic volume failure is weaker as a standalone module.
- Exact thresholds are not proven across markets.

## Over-Rigid Quantification Flagged

- `SwingLookback = 25`
- `EdgeVolumeLimit = 10`
- `StackMinLevels = 3`
- `ReclaimWindow = 1-3 bars`
- `NoResponseMinutes = 10`
- `VolumeSpikePercentile = 90`

All are research defaults, not production rules.

## Soft / Graded Concepts Improved

- Absorption score instead of absorption boolean.
- Delta trap score instead of delta sign.
- Failed acceptance state instead of generic breakout failure.
- Context as cap/weight instead of hard blocker.
- No-response as management/invalidation instead of entry condition.
- A+ as confluence score with hard caps.

## Recommended Next Step

Build the NinjaTrader indicator/exporter in phases:

1. Level engine plus edge exhaustion.
2. Absorption and delta-trap scoring.
3. Confirmation/invalidation state machine.
4. CSV export.
5. Threshold sensitivity tests.

Do not implement trapped trader, stop-run, climactic volume, or second-chance re-entry as primary modules until the first build proves the core exhaustion/absorption edge.

## Source Boundary

This refinement used only the isolated Codex files and evidence layer inside `Orderflows_APlus_Reversal_KB_codex_isolated_v1`. No Claude files, no other Reversals repo files, and no raw VTT edits were used.

