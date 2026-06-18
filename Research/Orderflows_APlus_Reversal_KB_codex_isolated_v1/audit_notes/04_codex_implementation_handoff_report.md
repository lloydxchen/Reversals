# Codex Implementation Handoff Report

## Files Created

- `knowledge_base\07_Backtest_Priority_Matrix_codex_v1.csv`
- `knowledge_base\08_NinjaTrader_Build_Sequence_codex_v1.md`
- `knowledge_base\09_Feature_Column_Schema_codex_v1.csv`
- `audit_notes\04_codex_implementation_handoff_report.md`

## Top 5 Hypotheses To Test First

1. `VH001` edge exhaustion at meaningful swing/session edge.
2. `VH014` quick-response/no-response exit overlay.
3. `VH002` absorption-to-exhaustion.
4. `VH003` pure absorption via effort-versus-result.
5. `VH004` positive delta trap at highs/resistance.

These are highest priority because they combine evidence strength, implementation practicality, and direct relevance to the trader's A+ model.

## Fastest MVP Indicator Path

Build only:

- Volumetric data availability check.
- HOD/LOD and swing high/low level engine.
- Edge volume at bar high/low.
- Exhaustion signal on confirmed bar close.
- Next-bar trigger flag.
- Structural stop reference.
- Minimal arrows/labels.
- Minimal CSV row.

This tests `VH001` and creates the shell needed for `VH014`.

## Biggest Implementation Risks

- NinjaTrader volumetric access may limit historical footprint fields depending on bar type/data source.
- Edge volume threshold `10` and swing lookback `25` can overfit if treated as universal.
- Absorption is inferred without DOM, so it must stay scored, not binary.
- Intrabar previews can repaint; confirmed signals should default to bar close.
- MFE/MAE export can introduce lookahead if signal-time and outcome fields are not separated.
- Context filters can overfilter if activated before baseline signals are measured.

## Concepts That Should Stay Soft / Graded

- Absorption.
- Delta trap.
- Delta weakening/divergence.
- Context regime.
- Trapped aggression.
- Imbalance failure.
- Climactic volume failure.
- A+ composite grade.

These are confluence modules, not isolated mechanical triggers.

## Concepts Likely To Break If Too Strict

- `EdgeVolumeLimit = 10`.
- `SwingLookback = 25`.
- `StackMinLevels = 3`.
- Reclaim within exactly `1-3` bars.
- Blocking every signal near cash open.
- No-response timeout fixed at `10` minutes.
- Positive/negative delta percentile cutoffs.
- Requiring absorption before every exhaustion signal.

## Recommended Build Order

1. `VH001` MVP exhaustion indicator.
2. Add `VH014` no-response tracking and export.
3. Add `VH015` risk quality fields.
4. Add `VH003`, `VH004`, and `VH005` absorption/delta-failure scoring.
5. Add `VH018` composite scoring.
6. Only then test `VH007` failed acceptance and `VH013` retest rejection.

Defer trapped trader, liquidity sweep, climactic volume, imbalance failure, and second-chance re-entry until the core edge is measured.

## Source Boundary

This handoff used only Codex isolated v2 files and the feature dictionary inside `Orderflows_APlus_Reversal_KB_codex_isolated_v1`. It did not use Claude files, other Reversals repo files, raw VTT edits, or any transcript-cleaning pipeline.

