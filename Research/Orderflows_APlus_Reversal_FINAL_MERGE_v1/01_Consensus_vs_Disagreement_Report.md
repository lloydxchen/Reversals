# Consensus vs Disagreement Report

## Sources Used

Claude full-corpus v2:

- `01_APlus_Reversal_Qualitative_Framework_v2.md`
- `02_APlus_Reversal_Operational_Model_v2.md`
- `03_APlus_Reversal_Testable_Hypotheses_v2.csv`
- `04_NinjaTrader_APlus_Reversal_Indicator_Spec_v2.md`
- `20_Remaining_Chunks_Delta_Report_v2.md`
- `21_Full_Corpus_Coverage_Report_v2.md`

Codex isolated v2:

- `01_APlus_Reversal_Qualitative_Framework_v2_extra_high.md`
- `02_APlus_Reversal_Operational_Model_v2_extra_high.md`
- `03_APlus_Reversal_Testable_Hypotheses_v2_extra_high.csv`
- `04_NinjaTrader_APlus_Reversal_Indicator_Spec_v2_extra_high.md`
- `03_extra_high_codex_refinement_report.md`

Claude has full-corpus coverage: 499 transcripts, 115/115 chunks. Codex is isolated and keyword/evidence-capped, but its v2 structure is cleaner for implementation. Final merge uses Claude for coverage-sensitive details and Codex for architecture/scoring discipline.

## High-Confidence Consensus

1. The spine is the same: A+ reversal = meaningful edge + aggressive participant failure + confirmation + tight structural stop.
2. The trader is not describing a red-light/green-light system. Single signals lie. Confluence screens, not arithmetic certainty.
3. Location dominates: HOD/LOD, swing high/low, support/resistance, value/POC/VWAP, or obvious failed breakout/sweep level.
4. Exhaustion and absorption are the primary reversal family.
5. Delta sign is contextual. Positive delta at resistance can be bearish if absorbed/no continuation. Negative delta at support can be bullish if absorbed/no continuation.
6. Large volume is not a reversal by itself. It matters only when it fails to continue.
7. Stops belong beyond the failed edge/signal extreme.
8. Bad trades include mid-range signals, mechanical exhaustion fades, no confirmation, oversized signal bars, and hostile trend context.
9. Intrabar/repainting concerns matter. Confirmed signals should be based on closed bars.
10. Thresholds must be instrument and timeframe parameters, not global constants.

## Claude Adds Material Full-Corpus Upgrades

These are accepted into the final merge:

- Intrabar Max/Min delta versus close delta is core. Close delta alone can mislead.
- Hidden delta flip/give-back is a primary absorption/exhaustion read.
- Exhaustion threshold is instrument/timeframe-scaled, not universally single digits or 10.
- Follow-through gate is important but timeframe-conditional.
- Time stop is chart-speed/context scaled, often 30-60 minutes; 10 minutes is only a fast-chart/fast-market research setting.
- Multiple imbalances can rank equal to or above stacked imbalances and may fire earlier.
- Imbalance position within bar has no predictive edge; do not weight it.
- Low cell-volume stacks are low quality.
- Ratio is a binary/two-tier soft flag, not graded by magnitude.
- Zero/near-zero delta is noise, not signal.
- Order-flow sequencing is continuation/suppressor, not reversal.
- Back-to-back POC and volume-in-value are real additions, but not first-build core modules.

## Codex Adds Better Implementation Discipline

These are retained:

- Treat the model as a decision stack: location -> failure mechanism -> confirmation -> invalidation -> management.
- Use separate bull and bear candidates; do not net signals too early.
- Use hard gates and grade caps before assigning A+.
- Absorption, trap, context, divergence, and climactic volume stay soft/graded.
- Use a staged signal state machine: Preview, ConfirmedSignal, Triggered, Validated, Invalidated.
- Keep signal-time fields separate from outcome fields to avoid lookahead bias.
- Build research/export indicator first, not auto-trader.

## Key Disagreements And Final Resolution

| Topic | Claude | Codex | Final resolution |
|---|---|---|---|
| Time stop | Contextual, chart-speed scaled, often 30-60 min; 10 min only fast charts | 10 min/no-response emphasized | Use parameterized freshness and no-response. Test 5/10 min only for fast charts; also test 30/60 min. |
| Exhaustion threshold | Per instrument/timeframe; examples: 10yr around 50, NQ around 3, ES around 0 | 10 edge volume / 25 swing default from targeted 2026 source | Use dynamic percentile plus instrument defaults. Do not hardcode 10. |
| Intrabar Max/Min delta | Core full-corpus refinement | Underweighted due isolated evidence | Make core module. |
| Multiple vs stacked imbalances | Multiple >= stacked; earlier fire; low-cell stacks downgraded | Stacked imbalance failure secondary | Use imbalance family: multiple, stacked, inverse; rank by tested performance, not assumption. |
| Follow-through | Load-bearing but timeframe-conditional | Quick response/no-response emphasized | Use staged confirmation. Enable strict follow-through on fast charts; relax >=5-min and slow instruments. |
| Ratio | Binary two-tier soft floor; formula undisclosed | Mostly absent | Include optional module; do not prioritize until formula is implemented/validated. |
| Sequencing | Continuation suppressor | Mostly absent | Include as false-positive filter, not reversal setup. |
| Volume-in-value | Orthogonal, optional, partly subjective | Absent | Optional later confirmation only. |

## Blunt Merge Verdict

- Claude has better evidence coverage.
- Codex has better engineering shape.
- Final model should not be an average of the two. It should be Claude's full-corpus mechanics inside Codex's stricter implementation architecture.
- The first backtest should not include every discovered module. Start with exhaustion, absorption, intrabar delta give-back, location, follow-through/no-response, and risk filters.

