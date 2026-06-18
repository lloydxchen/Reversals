# Transcript Evidence Map

Concept → strongest source chunks/videos/timestamps, for traceability (per `AGENTS.md` "preserve raw evidence"). Built from the 33 extracted chunks (17 T1 + 16 T2, 2016→2026). Full per-chunk detail in `../chunk_extractions/Chunk_NNN_Extraction.md`. Video #→title→date is in `../../Orderflows_Transcript_Index_v1.csv`.

> Strength: **★★★** core/explicit & repeated · **★★** solid · **★** single/era-specific.

| Concept | Strength | Best sources (Chunk / v# [mm:ss]) |
|---|---|---|
| Reversal = "last buyer bought / last seller sold" | ★★★ | Ch017/v492 [16:38]; Ch016/v485 [00:27]; Ch001/v4 [00:33] |
| Fair → unfair price → rejection | ★★★ | Ch001/v3 [02:56] |
| **Exhaustion Entry Model** (flagship, full rules) | ★★★ | Ch017/v492,v496,v497,v498; Ch016/v485,v489,v490 |
| Exhaustion print = ≤N vol at bid-green-low / offer-red-high | ★★★ | Ch017/v496 [05:29],v497 [06:38]; Ch016/v472 [00:55] |
| Exhaustion vol threshold (3/5/9–10, drifts, per-mkt) | ★★★ | Ch016/v481 [08:26],v490 [00:51]; Ch094 (default 9) |
| Swing filter (25; alts 2/5/30/50) | ★★★ | Ch017/v496 [02:32]; Ch016/v490 [00:51] |
| Follow-through gate / "let the market take you in" | ★★★ | Ch017/v492 [05:55],[18:11]; Ch016/v490 [03:11]; Ch078/v242 [40:07] |
| "2 ticks over 2 bars" (tool entry signal, no repaint) | ★★★ | Ch006/v220 [1:02:17]; Ch069/v214 [33:12]; Ch015/v449 |
| Best trades work immediately / sideways = fail | ★★★ | Ch017/v498 [19:00]; Ch016/v483; Ch009 |
| Candle-color agreement (green bull / red bear) | ★★★ | Ch017/v497 [01:01]; Ch018/v10 [23:58] |
| Divergence def (new extreme + opposite delta) | ★★★ | Ch003/v143 [02:22]; Ch045/v144 |
| Divergence necessary-not-sufficient | ★★★ | Ch001/v5 [10:42]; Ch013/v421; Ch045/v144 [14:26] |
| Orderflows ratio ≥30 / ≤0.69 (binary) | ★★ | Ch102/v471 [06:22]; Ch012 — *(2017 ~7: Ch028/v48)* |
| Cumulative-delta divergence (radar, not trigger) | ★★★ | Ch008/v296; Ch009/v309 [02:19]; Ch099/v403 [03:26]; Ch101/v442 |
| 3 failed divergences = trend day (don't fade) | ★★★ | Ch009/v312 [04:40]; Ch028/v50 [13:51]; Ch002/v70 |
| Read intrabar max/min delta (not final) | ★★★ | Ch028/v48 [08:30]; Ch094/v352; Ch003/v90 [07:19] |
| Delta surge (4 increasing → 4th bar) | ★★ | Ch005/v172 [35:04]; Ch011; Ch018 |
| Delta/market weakness (3 decreasing at extreme) | ★★★ | Ch011/v371 [09:32]; Ch089/v308 |
| Strong delta = 95% of max / >25% delta-per-vol | ★★ | Ch089/v308 [13:24]; Ch094/v350; Ch085/v284 |
| **Absorption** (neg delta on green, max≈0, no move) | ★★★ | Ch089/v310 [07:55]; Ch007/v269; Ch069/v213 [40:45] |
| ★ A+ Value-Area Absorption (abandoned VA/POC) | ★★★ | Ch016/v485 [05:04]; Ch102/v479; Ch094/v355; Ch103 |
| Stopping volume (30% default, brick wall) | ★★ | Ch015/v452; Ch001/v3 [12:20]; Ch011 |
| Imbalance = 4:1 (alts 2.5/3/3.5/10); minvol ~10 (era 50) | ★★★ | Ch006/v176; Ch010/v320; Ch028/v48; Ch085/v284 |
| Stacked = 3+ ("three is the magic number") | ★★★ | Ch006/v176; Ch100/v415 [01:47] |
| Opposite-color/failed stack → go with 2nd imbalance | ★★★ | Ch001/v8 [03:59] |
| Same-color stack = continuation (not reversal) | ★★ | Ch001/v8 [11:37]; Ch007/v280 |
| Multiple imbalance fires earlier than stacked | ★★ | Ch005/v173; Ch061/v196 [31:09] |
| Imbalances are immediate-term S/R only (~5 bars) | ★★★ | Ch001/v8 [14:06]; Ch018/v13 [09:13] |
| Inverse imbalance = trapped/absorption | ★★★ | Ch006/v176; Ch007/v280; Ch078/v242 [37:50]; Ch085/v284 |
| Trapped qty is SMALL; rejects "stop-run/big-wick" | ★★★ | Ch013/v425 [09:32]; Ch011/v390; Ch078/v242 [33:14]; Ch006/v176 [40:15] |
| POC-on-extreme / prominent POC (untested next bar) | ★★ | Ch002/v80; Ch061/v196 [54:33]; Ch094/v347; Ch095/v365 |
| Green Delta Trap (positive delta at high, no follow) | ★★ | Ch016/v478; Ch101/v442; Ch097 |
| Holding-vs-failing fresh bid asymmetry | ★★ | Ch013/v428 [01:53]; Ch069/v213 |
| Stop 1 tick beyond + second-chance re-entry | ★★★ | Ch017/v496 [11:33]; Ch016/v481 [06:19] |
| ~10-min time stop / scratch on sideways | ★★★ | Ch016/v490 [07:01]; Ch017/v498 [17:52] |
| Targets discretionary / level-to-level | ★★★ | Ch017/v492 [08:46]; Ch016/v490 [11:01]; Ch001/v3 [09:36] |
| "Unchanged"/open = no-catalyst stay-out | ★★★ | Ch016/v487 [09:20]; Ch017/v497 |
| Session/time (07–15 CT, avoid open/news/lunch) | ★★★ | Ch001/v3 [24:17]; Ch017/v495,v497 |
| Pivot to liquid markets (bonds/tens) when quiet | ★★★ | Ch016/v481 [07:19],v488; Ch102/v470 |
| Chart-construction changes signal existence | ★★★ | Ch017/v496 [12:02]; Ch009; Ch001/v8 [12:01] |
| "Not a red-light/green-light system" / react | ★★★ | Ch004/v158; Ch001/v3 [09:36]; Ch085/v284 [26:13] |
| DOM is a magnet, footprint is truth | ★★ | Ch100/v411 [08:47] |
| Price Rejector 4-factor (2016 root) | ★★ | Ch001/v3 [01:29]–[02:24] |

**Coverage note:** every concept above appears across multiple chunks/years (model is redundantly encoded). Single-era or single-source items are marked ★ and flagged in file 19. The 82 un-extracted chunks (T2 recaps / T3 product) would mainly add more *instances*, not new concepts — see ledger.
