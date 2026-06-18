# Chunk Extraction Instructions (Orderflows A+ Reversal model)

You are reverse-engineering the **implicit order-flow reversal model** of futures
day-trader **Michael "Mike" Valtos** (Orderflows / orderflows.com) from his YouTube
transcripts. The end goal is a NinjaTrader indicator that predicts **A+ reversal
setups**. Your job is to extract the *model* from one chunk of transcripts — not to
summarize the videos.

He trades order flow primarily via **footprint charts** (bid×ask volume per price),
**delta** (buy−sell), **imbalances/stacked imbalances**, **volume**, and tools he
built (Orderflows Trader, Delta Scalper, Price Rejector, Imbalancer, etc.). Expect
heavy talk of exhaustion, absorption, trapped traders, delta divergence, stopping
volume, POC/value area, supply/demand.

## Non-negotiable principles
1. **Extract the model, not a recap.** Capture his actual *rules, conditions,
   thresholds, and reasoning*.
2. **Cite everything.** For each point, append `(v<video#>, "<short title>", [mm:ss])`
   using the per-transcript header and the nearest `[mm:ss]` anchor in the chunk.
3. **Preserve uncertainty.** Tag each point: `[REPEATED]` (he says it multiple
   times / places), `[ONCE]` (single mention), or `[SPECULATIVE]` (your inference).
4. **Do NOT invent numbers.** If he states a number/threshold, record it *exactly*.
   If he's qualitative ("big volume", "delta dries up", "way more"), keep it
   qualitative and mark `NEEDS-OPERATIONALIZATION`. Never force a vague statement
   into a precise rule. Blank is better than fabricated.
5. **Capture grading/tiering language verbatim** — "A+", "my favorite", "textbook",
   "great", "good", "high-quality", "best", "perfect", "mediocre", "marginal",
   "low quality", "I'd skip", "not a great", etc. — and *what makes the difference*.
   This tiering is a primary deliverable.
6. **Empty categories are fine.** Write "— nothing in this chunk —". Don't pad.

## Output: write a Markdown file to the path I give you, with EXACTLY these sections

```
# Chunk NNN Extraction
- Source chunk: Chunk_NNN_Orderflows_Transcripts.md
- Transcripts covered: <list "v# — title (date)" one per line>
- Overall content value: rich | mixed | thin

## A. Setup types & names he uses
(name each setup; note bullish/bearish if specified)

## B. Tiering / grading language  ← HIGH PRIORITY
(verbatim grading words + the criteria that move a setup up/down a tier)

## C. Order-flow story & psychology per setup
(who is trapped, who is exhausted, where absorption happens, who must puke/cover)

## D. Exhaustion clues
## E. Absorption clues
## F. Stacked imbalance ideas
## G. Delta / delta-divergence ideas
## H. Failed breakout / breakdown / stop-run / liquidity-sweep ideas
## I. Trapped-trader ideas
## J. Entry triggers (the exact "go" event)
## K. Confirmation — what SHOULD happen quickly after entry/trigger
## L. Invalidation — what should NOT happen / what kills the thesis
## M. Stop / risk / target / trade management
## N. Context filters (session/time, regime/volatility, levels: VWAP, value area,
     POC, prior high/low, open, news, which markets/instruments)
## O. Directly testable / measurable variables (bullet each; include any exact
     numbers he gives; mark NEEDS-OPERATIONALIZATION where qualitative)
## P. NinjaTrader / indicator implementation ideas he mentions or implies
## Q. Notable verbatim quotes (3–10, each with citation) — pick the ones that most
     reveal the model
## R. Contradictions / nuances (anything that conflicts with common belief, with
     his other statements, or that is conditional/"it depends")

## Coverage note
(1–3 lines: which transcripts were rich vs thin; anything unparseable.)
```

Be **dense and concrete**, use his vocabulary, and keep each bullet to a specific
claim. Prefer 3 precise bullets over 1 vague paragraph.

## Then return to the orchestrator (NOT written to the file) a compact summary (≤250 words):
- setup type names found
- tiering/grading language found (or "none")
- 3–5 highest-value model insights from this chunk, each with a citation
- content value (rich/mixed/thin) and any chunk-specific caveats
