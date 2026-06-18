# Remaining-Chunks Delta Report (v2)

**Pass:** extracted the 82 previously-unprocessed chunks (80 in one workflow + 2 retried) → **115/115 chunks now extracted (full corpus).** Each has `../chunk_extractions/Chunk_NNN_Extraction.md`. This report records what the remaining chunks **added/changed/challenged** vs the v1 model — not a re-summary.

> Method: each delta agent compared its chunk to `../scripts/KNOWN_MODEL_DIGEST_v1.md` and returned only NEW / CONTRADICTORY / REFINING items; an Opus consolidation deduped them. Verdict cross-checked against sample extraction files (e.g. Ch082). Citations are chunk numbers (→ `Chunk_NNN_Extraction.md` → v#/[mm:ss]).

---

## 1. Did the remaining chunks materially change the model?
**Yes — but as REFINEMENT, not overhaul.** The v1 spine (exhaustion/absorption of aggressors at a clean swing extreme, confirmed by next-1–2-bar follow-through; "react, don't predict") is **overwhelmingly re-confirmed** — the bulk of every chunk repeats it. Of 80 chunks, 71 were "mixed" and 9 "thin"; **0 overturned the spine.** But **~12 recurring threads** are material enough to update the flagships (below). Net: the model gets **more precise, more conditional, and better-scoped**, and **two genuinely new elements** appear (intrabar Max/Min-delta family; back-to-back-POC + volume-in-value setups).

## 2. New setup types
Distinguishing **genuine new patterns** from **vendor/relabels of known concepts**:
- **Genuinely new / distinct:**
  - **Intrabar "hidden delta flip"** — bar closes near 0/opposite having hit a large intrabar extreme (close −278 after −2,200 = bullish absorption). Mike: "this is the best one because it's hidden in there." (Ch082, also 022,024,030,049,050,055,056,081,083,084,091,092,096,110,111) — *new operative read, see §4.*
  - **Back-to-back POC** — 2+ consecutive bars sharing the exact POC price → magnet S/R; trade the *return* to it after price leaves. (Ch082/v259)
  - **Order-flow Sequencing** — escalating volume eaten through levels = **continuation, not reversal** (a useful anti-signal). (Ch058,059,063,065,071,080)
  - **Volume-in-value (Stratum)** — volume *distribution within the value area*, explicitly **NOT delta-based** — an orthogonal confirmation axis. (Ch082/v257)
- **Mostly relabels / variants of known setups** (flag as such): **O2X** (= 2-tick pullback-to-extreme entry, already in "entry triggers"); **Delta/Buying/Selling Tail** (= single-side exhaustion print); **Market Weakness** (= delta-weakness detector, already v1 §3.10); **Slingshot POC / Value-Area Gap / Build / Abandoned** (= POC/VA family, v1 §3.11–3.12); **near-zero-volume "sore-thumb" HOD/LOD retest** (= exhaustion print, but worth noting he calls it a top pick); **three-failed-divergence breakout** (= v1 trend-day filter, now as an explicit *entry*).

## 3. New A+ vs mediocre/bad distinctions
- **Intrabar delta give-back grades conviction:** close ≈ 95% of Max delta = full conviction; large Max/Min → near-zero close = exhaustion/absorption (higher tier than close-delta alone implies). (Ch082,049,084,111)
- **MULTIPLE imbalances ≥ stacked** for quality/earliness ("if not more important because everybody looks for stacked") — a **tiering inversion** vs assumed stacked-primacy. (Ch033,044,046,049,055,056,066,068,071,072,111)
- **Imbalance *cell-volume* quality gate:** low-volume stacks ("pathetic 146/12/44") are downgraded vs high-volume stacks. (Ch020,021,048)
- **Position-within-bar (top/mid/bottom) has NO predictive edge** — do **not** weight it. (Ch084) *(weakens a plausible-but-unsupported idea.)*
- **"More signals is not better"** — higher tool-magnitude = fewer, higher-quality signals. (Ch082/v257,099)

## 4. New operational variables
- **Intrabar Max Delta / Min Delta vs close delta** (a *family*, elevated from a v1 nuance to a primary variable): close-delta alone is explicitly *misleading* on absorption bars. Sub-rules: close≈Max(~95%)=conviction; Max=0 or Min=0 = aggressor never in control = exhaustion flag; large Min→close recovery = absorption. (15+ chunks)
- **Back-to-back-POC count** (2+ consecutive same-price POCs) and **POC migration/clustering** as trend/reversal filters. (Ch082,090,091, others)
- **Per-bar value-area gap / build** as a regime read (trending = price leads value/gaps; rotational = value contains price). (Ch058,059,063,076,087,090)
- **Volume-distribution-in-value (Stratum)** as an orthogonal signal. (Ch082/v257)

## 5. New thresholds / soft conditions
- **Ratio** refined: high tier **28 = watch / 30 = preferred** (NT Orderflows Trader ships **28**, low **0.7699**); GoCharting hard-codes **27 / 0.69**. The flat v1 "≥30 / ≤0.69" is slightly off; the **27/28/30 spread = evolution + platform calibration, not a hard line.** Ratio is **BINARY** above/below — **magnitude does not grade quality** (a 432 ≠ better than a 52). (Ch025,049,109,111,029,034,036,039,043,084)
- **Thin/exhaustion print is instrument-AND-timeframe-scaled, contradicting "single digits":** 10-yr note ≈ **50**, NQ ≈ **3**, ES ≈ **0**, gold ≤3–7, euro ≤2–7. (Ch064,079,058,093,054)
- **Neutral-delta band:** ±50 default, but **~±25 for FX/thin** and **~±150 on heavy-volume ES bars** (6–9k). (Ch034,038,084,065)
- **Follow-through gate quantified:** "2-tick/2-bar" eliminates **~25–45%** of signals; configurable 1–2 ticks / 1–2 bars (max 5/5).
- **Decay refined to an exit counter:** bar 3 watch, bar 4 start exiting, bar 5 out — and an **opposite next-bar ratio can kill a stacked signal in 1 bar** (faster than ~5-bar decay).

## 6. Contradictions surfaced
1. **Exhaustion "single digits" is wrong for liquid markets** — 10-yr uses ~50. Thresholds are liquidity-scaled, full stop. (Ch064)
2. **Close delta is misleading** — a −278 close can be *bullish* if Min was −2,200. Naive close-delta reading fails. (Ch082)
3. **Time stop is ~1 hour, contextual — not ~10 min.** 30–60 min patience on slow instruments (5-yr, Bunds); the ~10-min figure likely applies only to fast tick charts. Order-flow info has a **~30–60 min freshness shelf-life** and degrades beyond a 5-min chart. (Ch027,029,031,036,042,040,060,073,105)
4. **Multiple ≥ stacked** inverts the assumed stacked-primacy. (many)
5. **Follow-through gate is timeframe-conditional** — disabled on 5-min+ and for ultra bonds/palm oil. (Ch062,105,111) The v1 "always require follow-through" is too absolute.
6. **Ratio is binary**, not graded by magnitude — v1 implied a threshold but didn't stress non-grading.

## 7. Previously weak claims now STRONGER (more independent evidence)
- **Read intrabar Max/Min delta, not final** — now the single most-reconfirmed refinement (15+ chunks).
- **Context-dependent delta sign** (neg-delta-on-green = bullish absorption; pos-delta-on-red = bearish supply) — heavily reconfirmed; promote from "nuance" to a hard branch.
- **Flow-driven regime** (failed divergences → follow, don't fade) — reconfirmed across eras; now also an explicit breakout *entry*.
- **Trapped quantity is small / reject "stop-run"** — reconfirmed.
- **Follow-through gate is the load-bearing quality filter** — quantified impact (~25–45% cull).

## 8. Previously assumed ideas now WEAKER
- **Flat ratio ≥30 / ≤0.69** → softened to 27/28/30 watch-vs-preferred, platform-calibrated.
- **Exhaustion "single digits"** → only true for thin markets; liquid markets far higher.
- **~10-min time stop** → really ~1 hr / context-dependent.
- **~5-bar imbalance decay** → can be 1 bar (opposite ratio) or a graded 3/4/5 exit.
- **Position-within-bar of an imbalance matters** → tested, **no edge** (drop it).
- **"Always require follow-through"** → timeframe-conditional.

## 9. Findings important enough to update the flagships → see v2 files
| Finding | v2 file(s) |
|---|---|
| Intrabar Max/Min-delta family + give-back grading | 02, 03, 04, 10/17 |
| Ratio two-tier soft floor + binary (non-graded) + 27/28/30 calibration | 02, 03, 09/10 |
| Follow-through gate: ~25–45% cull, configurable, **timeframe-conditional** | 02, 04, 14 |
| Multiple ≥ stacked (tiering inversion); count→2 on fast charts; low-vol downgrade; position-no-edge | 01, 02, 09 |
| Stacked invalidation: opposing flips / opposite-ratio-kills-in-1-bar / 3-4-5 exit counter | 02, 09 |
| Delta-sign context branch + pos-delta-at-low disambiguation (bid vs offer volume) | 02, 08, 10 |
| Time stop ~1 hr + order-flow freshness ~30–60 min + degrades >5-min chart | 04, 15, 16 |
| Instrument+timeframe threshold scaling (10yr=50 etc.; neutral ±25/±150) | 02, 03, 16 |
| New setups: back-to-back POC, volume-in-value (Stratum), sequencing=continuation | 01, 02, 04, 06 |
| Zero/near-zero delta = NOISE, not signal | 02, 19 |

## 9b. `[retried 026/032]` Additional minor refinements
- **Ratio in 2017 = exactly 7** ("I use 7") — confirms the older ratio definition is a different scale, not the same number as the later ≥28–30. Reinforces "platform/era calibration." (Ch032/v66 [13:34])
- **Divergence accepts a new OR EQUAL high/low** (not only strictly new). (Ch032/v67 [01:32])
- **Immediate opposite signal on the next bar = very high failure rate** — a stated invalidation (fits "kiss of death"). (Ch032/v67 [10:56])
- **Stacked imbalances appearing AFTER an extended move = low quality / chasing / skip** — location discriminator applied to imbalances. (Ch032/v63 [14:39])
- **Doji bars = neutral / skip** in order flow. (Ch032/v63 [18:28])
- **Candle-direction filter is a MANUAL overlay** he applies by eye, not always coded into the signal — relevant to NT spec (don't assume the detector enforces it). (Ch026/v39 [10:29])
- **One positive-delta bar does not confirm a reversal** — needs the *series* to turn (refines "delta flip"). (Ch026/v41 [06:36])
- **Overlapping/consecutive stacked imbalances ("one right after the other") = higher %** — density sub-criterion. (Ch026/v40 [10:56])
- **Cross-market filter:** if all markets are simultaneously range-bound, don't cherry-pick the one that looks like it's moving. (Ch026/v40 [37:09])
- Minor session numbers: currency session ends ~2 pm CT; crude sweet spot ~5 am–1 pm CT; Asian session ≈10–20% of daily volume; bonds very quiet on Japan/HK holidays. (Ch032/v67; Ch026/v40)

## 10. Merely repetitive (no flagship change)
The vast majority: the spine; "last buyer/seller"; exhaustion print on bid-green-low/offer-red-high; 4:1 imbalance / 3+ stacked; divergence definition; "let the market take you in"; 1-tick stop + re-entry; session/news/"unchanged" filters; pivot-to-liquid-markets; abandoned VA = high confidence; candle-color agreement; "not a red-light/green-light system"; chart-construction dependence; DOM-is-a-magnet. These recurred in dozens of chunks and **strengthen confidence** but change nothing.

## 11. Over-quantification flags (per the quality standard — keep these SOFT)
- Intrabar delta give-back % (80–96% in examples) is **author-flagged NEEDS-OPERATIONALIZATION** — no stated %. Keep as "closes far inside its intrabar extreme," not a hard %.
- "Delta surge" increment size / bar count — no stated minimum. Keep qualitative.
- Flow-driven trigger count (2 vs 3 failed divergences) and window (~30–60 min) — keep a *range*, prefer consecutive-failure count over a clock.
- Follow-through cull % (25–45%) is descriptive, not a tuning target.
- Per-instrument numbers (10yr=50, NQ=3, neutral ±25/±150) are **examples**, implement as per-instrument parameters, never global constants.
