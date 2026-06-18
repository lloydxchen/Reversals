# Codex Synthesis Limitations

## Evidence Extraction Limitations

- The evidence layer was keyword/theme based and capped at 80 entries per theme. It is strong enough to synthesize a model, but not full-corpus proof.
- Some evidence files overweight videos whose filenames and captions repeat the target keyword. Example: exhaustion evidence heavily surfaces explicit exhaustion-title videos.
- Caption fragments are noisy. Minimal VTT cleaning preserved wording but did not reconstruct perfect sentences.
- Nearby context is local caption context, not full argument context.
- The synthesis selectively checked raw VTTs for May 2026 exhaustion/absorption source support, but did not re-read every raw file.

## Under-Sampled Themes

- Stop-run/liquidity-sweep reversals are present but less cleanly supported than exhaustion and absorption.
- Climactic volume reversals need more raw source checking. Current evidence supports "large volume must be interpreted in context," not a precise standalone reversal rule.
- Retest-confirmation is inferred from repeated level/signal behavior and confirmation comments, but it is less explicitly named as a standalone model.
- Failed-continuation is strongly implied by "no follow-through" logic, but not always labeled as a formal setup.
- Stacked-imbalance failure is supported, but the exact imbalance threshold and failure timing remain platform/market dependent.

## Uncertain Concepts

- Absorption detection without DOM/order book data is inferred from footprint results. The trader talks about passive buyers/sellers, but historical backtests will approximate this through effort-vs-result, delta/close contradiction, and volume-at-price behavior.
- Trapped trader identification is partly psychological. The trader explicitly warns that not every stop or large order is a true trapped trader.
- Stop-run versus true initiative breakout is hard to separate without post-event confirmation.
- Value area, prominent POC, abandoned value area, and market profile ideas appear as context filters, but this phase did not build a full volume-profile methodology.
- "A+" is qualitative. The best operational equivalent is a confluence score, not a single hard trigger.

## Ideas At Risk Of Over-Quantification

- Exhaustion volume limit of 10: directly supported in the 2026 ES settings discussion, but too strict as a universal rule.
- Swing period of 25: directly supported for the trader's chosen setting, but should be tested across markets/timeframes.
- "If not moving in 10 minutes, exit": directly supported as trade-management logic in one context. Treat as principle, not universal law.
- Stacked imbalance threshold: 3+ adjacent imbalances is a common operational choice, but the evidence here does not prove one universal threshold.
- Delta divergence: easy to calculate, easy to overfit. Divergence needs level/context/failure.

## Too Subjective To Operationalize Cleanly

- "Good trade location" can be approximated with distance to levels, but the trader's discretionary level selection is broader than any simple formula.
- "Passive buyers/sellers are present" is visible to a trained footprint reader but only indirectly measurable from historical bar/footprint data.
- "Traders are puking" or "FOMOing" is psychology inferred from order-flow behavior, not directly observed.
- "This bar is bearish/bullish to me" often combines several visual details: delta, POC, thin prints, imbalances, close location, and context.
- "Suspicious activity" in crude oil/order book examples is not a clean systematic reversal rule.

## What Should Be Checked Against Claude Later

- Whether Claude independently found the same flagship model: exhaustion after absorption at swing/session levels.
- Whether Claude found additional setup types missing from capped evidence, especially value area/abandoned POC reversals.
- Whether Claude extracted more precise Orderflows Trader settings for exhaustion, ratios, imbalance thresholds, and swing filters.
- Whether Claude has stronger examples of failed breakout/breakdown and stop-run reversals.
- Whether Claude distinguishes trade entry, management, and target logic more cleanly.
- Whether Claude found market-specific guidance for ES/NQ/YM/bonds/crude/currencies.

## Bottom Line

The cleanest supported model is:

**Trade reversals at meaningful edges when aggressive participants run out of fuel or are absorbed, using footprint exhaustion/absorption/delta failure as the trigger, with a stop beyond the edge and an expectation of quick movement.**

Everything beyond that should be treated as confluence, scoring, and test design, not as proven fixed rules.

