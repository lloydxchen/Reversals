# Context Filters

Supports KPI 1/2/3. Context is, in his words, what separates a real signal from noise. These are the gates around every setup.

## Location (the master filter — see file 01 §2)
Signal must be **at/within ~1 tick of a clean swing high/low or HOD/LOD, after a genuine prior move.** Mid-move = skip. This is the strongest single discriminator. (Ch004/v145; Ch017/v496) `[REPEATED]`

## Session / time
- **Tradable window** ~**07:00–15:00 CT**; "Index Hours" ~07:00–16:00 in the early era. (Ch001/v3 [24:17]) `[REPEATED]`
- **Avoid the first bars** (Price-Rejector look-back = 9 bars → avoid first ~9 bars); **don't trade right before the cash open**; avoid the **8:30 open spike** in thin markets (let it settle). (Ch017/v497 [01:29]; Ch017/v495 [04:13]) `[REPEATED]`
- **Wind down after ~13:00**, stop by ~15:00 (cash close); lunchtime is choppy. (Ch001/v3 [14:06]; Ch017/v499 [20:23]) `[REPEATED]`
- **Avoid major-number days/minutes** (NFP, CPI/PPI, crude inventories) — thin/"wonky"/late prints. (Ch001/v3 [31:48]; Ch016/v481 [01:03]) `[REPEATED]`

## Catalyst — the "unchanged"/open filter
Price hugging the **open / "unchanged" line** (or prior close) = no catalyst = **stay out**. He uses a literal yellow "unchanged" line as a go/no-go. "Why take a trade when nothing is happening?" (Ch016/v487 [09:20]) `[REPEATED]`

## Regime
- **Trending vs rotational:** in trends **price leads value** (look for value *gaps*); in rotation **value contains price**. Don't fade a trend. (Ch078/v242 [07:33]) `[REPEATED]`
- **Trend-day filter:** ≥3 failed divergences/exhaustions in ~1 hr → stop fading. (Ch009/v312) `[REPEATED]`
- **Few exhaustion prints = normal/quiet** (facilitation) — pivot markets, don't force. (Ch016/v481 [04:08])
- **`ChopState`** (repo Flow42 field) is an available regime proxy.

## Volatility
- More volatile markets (RTY vs ES, crude >$100) = **more signals but more stop-outs**; high VIX → **switch to deep/liquid markets** (10-yr) and away from thin (NQ/gold). (Ch017/v492 [12:05]; Ch102/v470) `[REPEATED]`
- **Big-bar filter:** signal-bar range > ~1.75×ATR → downgrade/skip (stop too wide).

## Levels referenced
Swing highs/lows, HOD/LOD, **open/"unchanged"/prior close** (magnet), **POC / prominent POC**, **value area** (& abandoned VA), VWAP/std-dev (occasionally), gaps, 50% / 61.8% retracement (continuation pullbacks). (Ch016/v487; Ch094)

## Instrument / market selection
- Reads **cleanest in high-volume-at-price markets** (bonds, tens, ultra bonds, grains) — "exhaustion harder to see in NASDAQ." Some setups (single-print, inverse imbalance) work better on **YM/NQ/gold/rates** than ES. **Pivot markets** when the primary is quiet. (Ch016/v462, v488; Ch010/v358) `[REPEATED]`

## Chart construction (a filter AND a risk — see file 19)
Range/tick/volume vs time charts change **whether a signal exists at all**. He runs currencies/ultra-bonds on range charts, indices on 1-min/30-sec. A single-chart indicator inherits this dependence. (Ch017/v496 [12:02]; Ch009) `[REPEATED]`
