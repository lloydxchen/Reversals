#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Generate 03_APlus_Reversal_Testable_Hypotheses_v2.csv (full-corpus).

Reads the v1 CSV, keeps all 24 rows verbatim (v1 preserved separately too),
and appends v2 delta rows (H25-H38) from the remaining-82-chunk pass.
Some v2 rows refine a v1 row; the notes field points to it. New free-text is
written via csv.writer so commas/quotes are safe.
"""
import csv
from pathlib import Path

KB = Path(__file__).resolve().parent.parent / "knowledge_base"
V1 = KB / "03_APlus_Reversal_Testable_Hypotheses.csv"
OUT = KB / "03_APlus_Reversal_Testable_Hypotheses_v2.csv"

with V1.open(encoding="utf-8", newline="") as f:
    r = csv.reader(f)
    header = next(r)
    v1_rows = [row for row in r]

# v2 additions (same 16 columns as header)
NEW = []
NEW.append(["H25","Intrabar delta hidden-flip (give-back)",
  "Read intrabar Max/Min delta vs close, not close alone: a bar closing near 0/opposite after a large intrabar extreme = absorption/exhaustion ('hidden flip').",
  "At a swing low: MinSeenDelta strongly negative AND close BarDelta >= ~0 (large give-back) -> bullish; confirm with follow-through.",
  "Mirror at swing high: MaxSeenDelta strongly positive, close BarDelta <= 0.",
  "Footprint intrabar delta, OHLC",
  "MaxSeenDelta; MinSeenDelta; BarDelta; high/low",
  "give-back 'closes far inside extreme' (examples 80-96%); NO hard % (NEEDS-OP)",
  "Follow-through within 1-2 bars; delta builds in trade direction",
  "Close-delta keeps trending in the failed direction (no give-back)",
  "Close delta alone is misleading; intrabar path reveals the flip (most-reconfirmed v2 refinement)",
  "5","3","5","Ch082/v256,Ch049,Ch084,Ch111,Ch022,Ch030,Ch091,Ch092,Ch110",
  "v2 NEW. Keep give-back SOFT ('closes far inside'), not a hard %. Needs MaxSeenDelta/MinSeenDelta capture."])
NEW.append(["H26","Multiple >= stacked imbalance (earlier fire)",
  "Multiple (3+ non-consecutive in a bar) imbalances rank equal-or-ABOVE stacked and fire ~2 bars / ~5 pts earlier.",
  "BuyImbalanceCount>=3 in a bar at a swing low -> enter on follow-through; prefer over waiting for a consecutive stack.",
  "Mirror with SellImbalanceCount.",
  "Footprint imbalance, OHLC",
  "BuyImbalanceCount/SellImbalanceCount; TopBuyStackMax/BottomSellStackMax",
  "count>=3 (>=2 on fast 4-range/tick charts); ratio 4:1; minvol per-instrument",
  "Follow-through",
  "Mid-move; no follow-through",
  "Tiering inversion vs assumed stacked-primacy; earlier entry = smaller stop",
  "4","2","4","Ch033,Ch044,Ch049,Ch055,Ch056,Ch066,Ch068,Ch071,Ch072,Ch111",
  "v2 NEW; refines H09. Backtest the 'earlier/more profitable than stacked' claim."])
NEW.append(["H27","Ratio two-tier soft + binary (non-graded)",
  "Ratio is a binary above/below flag (magnitude does NOT grade quality); high tier 28 watch / 30 preferred; low ~0.69-0.77; platform/era calibrated (2017=7).",
  "Bullish: ratio <= RatioLow (~0.69-0.77) at a new/equal low with positive delta + price action.",
  "Bearish: ratio >= RatioHigh (28 watch / 30 preferred) at a new/equal high with negative delta.",
  "Footprint ratio, delta, OHLC",
  "ratio; BarDelta; high/low",
  "RatioHigh 28(watch)/30(pref); RatioLow ~0.69 (NT 0.7699); binary, magnitude not graded",
  "Next bar follow-through",
  "Divergence/ratio alone; opposite next-bar ratio",
  "Refines the flat v1 >=30/<=0.69 to a calibrated soft floor; stops over-weighting big ratios",
  "4","4","4","Ch025,Ch049,Ch109,Ch111,Ch032/v66,Ch029,Ch034",
  "v2 REFINES H04. Ratio formula still undisclosed -> reproduce + validate; do NOT grade by magnitude."])
NEW.append(["H28","Follow-through gate timeframe-conditional",
  "The 2-tick/2-bar follow-through gate is the load-bearing quality filter (~25-45% cull) but is OFF on >=5-min charts and for ultra bonds/palm oil.",
  "Require next 1-2 bars break signal extreme by buf -> else no trade; DISABLE on >=5-min charts.",
  "Mirror.",
  "OHLC, chart timeframe/instrument",
  "high/low; bar index; timeframe; instrument",
  "1-2 ticks / 1-2 bars (max 5/5); disabled >=5-min and for ultra bonds/palm oil",
  "Self",
  "No break in window (on charts where gate applies)",
  "Quantified ~25-45% signal cull; the single biggest expectancy lever",
  "5","2","5","Ch049,Ch062,Ch070,Ch073,Ch105,Ch111,Ch112",
  "v2 REFINES H03. Timeframe-conditionality is new and important; do not apply gate on >=5-min."])
NEW.append(["H29","Time stop ~1hr / chart-speed scaled",
  "Order-flow trades get ~1 hour (slow instruments) not a fixed 10 min; order-flow info freshness ~30-60 min and degrades beyond a 5-min chart.",
  "Scratch if no progress within TimeStop (scaled by chart speed: ~10 min fast tick, ~30-60 min slow).",
  "Mirror.",
  "Time, OHLC",
  "bars-since-entry; timeframe; instrument",
  "TimeStop ~10 min (fast tick) to ~60 min (slow); freshness window 30-60 min",
  "n/a",
  "n/a",
  "Corrects v1 ~10-min; wrong setting bleeds winners or holds losers",
  "3","2","4","Ch027,Ch029,Ch031,Ch036,Ch040,Ch073,Ch105",
  "v2 CORRECTS the v1 ~10-min time stop. Parameter scaled by chart speed."])
NEW.append(["H30","Back-to-back POC magnet",
  "2+ consecutive bars sharing the exact POC price = a defended level; trade the RETURN to it after price leaves.",
  "Mark level where >=2 consecutive bars share POC price; on return to within X ticks at a swing -> reversal entry.",
  "Mirror.",
  "Footprint POC, OHLC",
  "POCPrice (per-bar series); high/low",
  ">=2 consecutive same POC (3+ = stronger); return within X ticks; stop few ticks beyond",
  "Follow-through on the retest",
  "Price keeps sitting at the level (no leave-and-return); breaks through",
  "New magnet/level setup; clean to detect",
  "3","3","3","Ch082/v259,Ch090,Ch091",
  "v2 NEW. Single-source-rich; confirm in backtest. Only valid after price LEAVES the level."])
NEW.append(["H31","Order-flow sequencing = continuation (suppressor)",
  "Escalating volume eaten THROUGH successive levels = continuation, not reversal; use to suppress counter-trend fades.",
  "If volume is increasing as price clears successive levels -> SUPPRESS bullish/bearish reversal signals (trend regime).",
  "Same (symmetric).",
  "Footprint level volume, OHLC",
  "per-level volume across bars; level breaks",
  "increasing volume through >=2-3 levels",
  "n/a (filter)",
  "n/a",
  "False-positive filter against fading trends",
  "3","3","3","Ch058,Ch059,Ch063,Ch065,Ch071,Ch080",
  "v2 NEW (anti-signal). Related to the flow-driven regime filter."])
NEW.append(["H32","Delta-sign context + pos-delta-at-low disambiguation",
  "Negative delta on a green/rising bar = bullish absorption; positive delta on a red/falling bar = bearish supply. Positive delta at a low can be absorption-bullish OR distribution-bearish.",
  "Disambiguate pos-delta-at-new-low via footprint: offer-side dominance at the low = bearish continuation; bid-side absorption = bullish.",
  "Mirror at highs.",
  "Footprint per-level bid/ask, delta, OHLC",
  "BarDelta; close>open; per-level BidVol/AskVol at extreme",
  "sign(delta) vs candle color (hard branch); bid-vs-offer at extreme",
  "Follow-through agrees with the absorption read",
  "Offer-side dominance at a low keeps trading lower",
  "Most-reconfirmed delta refinement; prevents polarity misreads",
  "4","3","5","Ch030,Ch031,Ch038,Ch042,Ch049,Ch064,Ch079,Ch083,Ch084,Ch087,Ch092,Ch096",
  "v2 NEW (promotes a v1 nuance to a hard branch). Needs per-level bid/ask, not just bar delta."])
NEW.append(["H33","Stacked-imbalance quality refinements",
  "Min count drops to 2 on fast charts; low cell-volume stacks are downgraded; position-within-bar has NO predictive edge.",
  "Accept >=2 stacked on 4-range/fast-tick; require decent cell volume; do NOT weight top/mid/bottom position.",
  "Mirror.",
  "Footprint imbalance + volume, chart timeframe",
  "TopBuyStackMax/BottomSellStackMax; cell volume; timeframe",
  "count>=3 (>=2 fast charts); cell vol >= rolling median; ignore position-in-bar",
  "Close beyond + follow-through",
  "Low-volume 'pathetic' stack; stale (>5 bars)",
  "Refines stacked rule; position-no-edge removes a plausible-but-false feature",
  "3","2","4","Ch020,Ch021,Ch048,Ch062,Ch066,Ch084,Ch093",
  "v2 REFINES H07. Position-within-bar tested = no edge (drop it)."])
NEW.append(["H34","Zero/near-zero delta = noise (filter)",
  "Zero or near-zero delta is noise, not a signal.",
  "Suppress signals whose defining bar has |BarDelta| ~ 0 (within NeutralBand).",
  "Same.",
  "Delta",
  "BarDelta; NeutralBand",
  "NeutralBand ~+/-50 ES (+/-25 FX, +/-150 heavy ES)",
  "n/a (filter)",
  "n/a",
  "Cuts noise bars masquerading as signals",
  "3","1","4","Ch082,Ch065,Ch034,Ch038",
  "v2 NEW. NeutralBand is instrument+timeframe scaled."])
NEW.append(["H35","Immediate opposite next-bar signal = high failure",
  "A buy signal immediately followed by a bearish next-bar signal (or vice versa) has a very high failure rate.",
  "Void a long candidate if the next bar prints an opposing reversal signal/ratio.",
  "Mirror.",
  "OHLC, footprint signals",
  "signal flags per bar; ratio",
  "opposite signal within 1 bar",
  "n/a (invalidation)",
  "Self",
  "Extends 'kiss of death' to opposing-signal case",
  "3","2","4","Ch032/v67",
  "v2 NEW (invalidation). From retried chunk 032."])
NEW.append(["H36","Doji / stacked-after-extended-move = skip",
  "Doji bars are neutral/skip; stacked imbalances appearing AFTER an extended move = chasing, low quality.",
  "Suppress signals on doji bars and stacked imbalances that print after a large prior move (location/over-extension filter).",
  "Same.",
  "OHLC, ATR, footprint",
  "bar body/range; prior-move displacement; imbalance bar",
  "doji body ~0; prior move > over-extension threshold",
  "n/a (filter)",
  "n/a",
  "Two cheap quality filters",
  "2","2","3","Ch032/v63",
  "v2 NEW. Over-extension is the location discriminator applied to imbalances."])
NEW.append(["H37","Exhaustion threshold instrument-scaled (NOT single-digit)",
  "Exhaustion/thin-print threshold scales with liquidity: 10yr ~50, NQ ~3, ES ~0, gold <=3-7, euro <=2-7 (contradicts universal 'single digits').",
  "ExpVol set per-instrument (or dynamic low-percentile of recent per-level volume).",
  "Mirror.",
  "Footprint level volume",
  "BidVol/AskVol at extreme; per-instrument ExpVol",
  "10yr~50; NQ~3; ES~0; gold<=3-7; euro<=2-7; or dynamic low-percentile",
  "Follow-through",
  "n/a",
  "Corrects a contradiction; hard-coding single-digit kills it on liquid markets",
  "4","2","5","Ch064,Ch079,Ch058,Ch093,Ch054",
  "v2 REFINES H01. Strongly per-instrument; prefer dynamic percentile."])
NEW.append(["H38","Volume-in-value (Stratum) orthogonal confirm",
  "Volume distribution within the value area (NOT delta-based) is a separate confirmation axis.",
  "Use a value-area volume-distribution skew as optional confirmation of a delta/imbalance reversal; do not stack mechanically.",
  "Mirror.",
  "Footprint per-level volume, value area",
  "per-level volume within VA; value-area hi/lo",
  "distribution skew (tool magnitude 1-5 per instrument)",
  "Agrees with primary trigger + follow-through",
  "Disagrees / no follow-through",
  "Orthogonal axis; may add lift but he warns against mechanical stacking",
  "2","4","3","Ch082/v257",
  "v2 NEW (Subj). Keep separate from the delta engine; optional."])

with OUT.open("w", encoding="utf-8", newline="") as f:
    w = csv.writer(f)
    w.writerow(header)
    for row in v1_rows:
        w.writerow(row)
    for row in NEW:
        assert len(row) == len(header), f"bad row len {len(row)}"
        w.writerow(row)
print(f"Wrote {len(v1_rows)} v1 rows + {len(NEW)} v2 rows = {len(v1_rows)+len(NEW)} to {OUT.name}")
