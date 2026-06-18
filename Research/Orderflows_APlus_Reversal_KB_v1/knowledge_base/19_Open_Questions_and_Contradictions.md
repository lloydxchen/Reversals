# Open Questions & Contradictions

Preserves uncertainty per the quality standard (and `AGENTS.md`: AI reasoning is the lowest tier of truth — these need data, not more inference). **If the model underperforms, start here** (and at file 02 §7 `[FORCED]` list).

## A. Internal contradictions / tensions in his own teaching
1. **"Same settings every market" vs market-specific behavior.** He claims identical detector settings work everywhere, yet exhaustion thresholds (3/5/9–10), imbalance min-volume (50 in 2017 → 10 later), chart type (range for FX/bonds, time for indices), and targets all vary by instrument. **Resolution used:** "same settings" applies to the *detector logic*; *thresholds/management/chart* are per-market. Treat all as parameters. (Ch017/v492 vs v495 vs v498)
2. **"Not a red-light/green-light system" vs a deterministic indicator/score.** He insists on reading/reacting, not mechanical signals, and warns "6 plots ≠ automatic buy." Our scoring model (file 02 §3) is an explicit **approximation** — must be validated against his verbal tiers, not assumed correct. (Ch085/v284 [26:13])
3. **"The only entry model you'll ever need" vs multiple A+ setups.** Exhaustion is branded as the whole model, yet he separately calls value-area absorption "A+" and ratio+divergence "bread and butter." **Resolution:** they're meant to be **stacked** (confluence), not alternatives.
4. **"Works immediately" vs "give it 1–3 bars."** Best trades move right away, but he repeatedly shows winners that triggered on bar 2 and hung 1–3 bars. **Resolution:** "immediately" ≈ within 1–3 bars; void only after a *sideways* stretch (~10 min), not after 1 quiet bar. (Ch017/v498 [20:08])
5. **Tight 1-tick stop vs wide stops on big bars.** He champions a 1-tick stop + re-entry but accepts wide stops behind big bars — while also saying to *avoid* big-bar setups. **Resolution:** setup selection (prefer small bars so the tight stop is feasible).
6. **Single stop-out ≠ invalidation vs strict invalidation rules.** "Residual leftover" aggression ticks you out, then it reverses → re-enter. So a stop-out is not a thesis-kill; only an order-flow change is. (Ch016/v481 [06:19])
7. **Double-top exhaustion exception.** The 25-bar new-extreme rule is strict, but he trades a double-top exhaustion (not a fresh extreme) "by eye." A discretionary exception to a hard rule. (Ch017/v496 [04:55])
8. **Targets fully discretionary** in an otherwise rule-based model — "it depends." Cannot be operationalized from the transcripts; leave to ATM/level logic.

## B. Where he contradicts common order-flow belief (capture deliberately)
9. **Stacked imbalances are NOT durable support/resistance** — only ~4–5 bars. (Ch001/v8 [14:06])
10. **Trapped traders don't *cause* reversals** and the trapped quantity is **small** — a tell, not squeeze fuel; he rejects "big wick = stops run." (Ch013/v425; Ch078/v242 [33:14])
11. **Multiple (non-stacked) imbalances ≥ stacked** because they fire earlier — counter to standard "stacked is king" teaching. (Ch061/v196 [31:09])
12. **Positive delta can be bearish / negative delta bullish** (Green Delta Trap; absorption polarity). New lows on positive delta = supply absorbing, still bearish. (Ch016/v478; Ch099/v403)

## C. Undisclosed / unresolved mechanics (need reverse-engineering)
13. **The "ratio" formula is never disclosed.** Thresholds ≥30 / ≤0.69 are stated, but how the number is computed isn't. **A 2017 video implies a ~7 cutoff** — likely an older/different "ratio" definition. *Must reproduce from footprint and validate against his flagged bars.* (Ch102/v471; Ch028/v48)
14. **"Prominent POC" prominence criterion** undisclosed — what makes a POC "prominent" vs ordinary?
15. **"Absorption" detection** beyond value-area-abandonment is partly subjective (resting-size, iceberg/refreshing) — may need DOM data the footprint lacks.
16. **Min/Max-delta "disparity range"** and some tool internals are proprietary (Ch014/v438).
17. **Exhaustion threshold: fixed vs dynamic?** He uses fixed-per-market numbers that drift; a dynamic low-percentile may transfer better — untested.

## D. Chart-construction dependence (a structural risk)
18. **Signals exist or vanish depending on bar type** (range/tick/volume/time). A 4-range shows an imbalance a 10-range "fills in"; range charts show divergences a time chart misses. **A single-chart indicator will both miss and fabricate signals.** Open question: which bar type best matches his reads per instrument; consider multi-series confirmation. (Ch017/v496 [12:02]; Ch009; Ch001/v8 [12:01]) `[HIGH PRIORITY]`

## E. Single-source / era-specific items (lower confidence — confirm in full sweep)
- **Delta Surge "4 bars"** rule — clearly stated but in few places (Ch005/v172). 
- **Sweep-with-no-stacked-imbalance** as an edge — single mention (Ch061/v196).
- **Liquidity Finder** exact defaults — one video (Ch017/v499); it's a *scored-zone* tool, not the exhaustion model.
- **Price Rejector 4-factor** — 2016 era only (Ch001); conceptual ancestor, tooling obsolete.
- **POC-on-extreme "obsolete on e-mini"** → model evolved toward prominent POC (Ch007).

## F. Things that explicitly need backtesting (not resolvable from transcripts)
- Does requiring **absorption** raise exhaustion-print win-rate (the "A+" claim)?
- Does the **2-bar follow-through gate** beat entering on the signal bar?
- **Opposite-color** vs same-color stacked imbalance edge.
- **Multiple vs stacked** earlier-fire profitability.
- Optimal `ExpVol` (fixed-per-market vs dynamic percentile).
- Trend-day filter: **consecutive-failure count vs ~1-hr clock**.
- Is the composite **score monotonic** with realized MFE/MAE?
- Net effect of the **string-of-small-losses → one-winner** distribution (avg trade hides it).

→ Each maps to a row in `03_APlus_Reversal_Testable_Hypotheses.csv`.
