# Open Risks And Overquantification Warnings

## Highest Risks

1. **Chart construction dependence:** signals can appear/disappear by bar type. This is structural, not cosmetic.
2. **Volumetric data availability:** without true footprint data, the core model is crippled.
3. **Max/Min delta availability:** final model now depends heavily on intrabar delta path, not just close delta.
4. **Absorption inference:** without DOM, passive buyers/sellers are inferred from effort/result, not observed.
5. **Ratio formula unknown:** do not treat ratio module as production until reproduced and validated.
6. **Targets remain discretionary:** transcripts support entries/stops/filters better than targets.
7. **No backtest or compile verification yet.**

## Over-Rigid Concepts

Do not hardcode:

- Edge volume = 10.
- Swing lookback = 25.
- Stack count = 3.
- Follow-through always on.
- Time stop = 10 minutes.
- Time stop = 60 minutes.
- Ratio high = exactly 30.
- Neutral delta = exactly +/-50.
- A+ score = exactly 82.
- Volume spike percentile = exactly 90.

All are parameters or research defaults.

## Concepts That Must Stay Soft / Graded

- Absorption.
- Hidden delta give-back percentage.
- Delta trap.
- Delta divergence.
- Context/regime.
- Sequencing/flow-driven suppressor.
- Imbalance quality.
- POC prominence.
- Volume-in-value.
- Trapped trader interpretation.
- A+ composite score.

## Weak Or Later-Stage Ideas

- Volume-in-value/Stratum: optional confirmation only.
- Back-to-back POC: clean but less confirmed.
- Second-chance re-entry: risky until base stop logic is proven.
- Stop-run labels: use failed acceptance/reclaim first.
- Trapped trader labels: use aggression failure first.

## Things Likely To Break The Model If Mishandled

- Reading close delta without Max/Min delta.
- Fading sequencing/flow-driven continuation.
- Applying fast-chart follow-through rules to 5-minute+ charts.
- Applying 10-minute freshness to slow markets.
- Weighting imbalance position within bar.
- Treating multiple imbalances as inferior to stacked by default.
- Scoring ratio magnitude as stronger because the number is bigger.
- Letting no-location signals become A+ via score.

## Blunt Production Guidance

- Build research indicator first.
- Export every component.
- Use out-of-sample testing.
- Keep A+ rare.
- Promote only rules that survive threshold sensitivity.
- If the indicator cannot access volumetric and Max/Min delta cleanly, do not pretend it implements this model.

