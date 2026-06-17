# Flow42 Research Notes

_Last updated: 2026-06-16_

## Purpose

This document explains how Flow42 should be used inside the Reversals research project.

The short version:

```text
Flow42 is useful as a context/filter layer.
Flow42 is not currently a complete exportable reversal-signal dataset.
The strongest reversal engine should still come from our own price, volumetric delta, footprint, and reconstructed order-flow features.
```

This note is intentionally practical. It is meant to help future AI threads, coding sessions, and backtesting passes quickly understand which Flow42-derived variables are trustworthy, which are only diagnostic, and which interesting visual concepts are not yet available as clean model-ready data.

See also: [`flow42_export_data_dictionary_v0_8.pdf`](flow42_export_data_dictionary_v0_8.pdf)

---

## Current Export Context

The current Flow42 export work is based on:

```text
Exporter: Flow42DataCapture_v0_8
Preset: Export_FastAllFlow42
Instrument/run: NQ JUN26
BarsPeriod: 1 Min Volumetric
Rows: 10,000
Preferred delta source: NTVolumetricBidAsk
```

The exporter was configured to prefer NinjaTrader volumetric bid/ask delta. That matters because the most reliable delta columns in this dataset are not Flow42's native VolDelta outputs. They are the exporter/NinjaTrader-derived preferred delta fields.

Important interpretation:

```text
PreferredDelta_* = best available delta wrapper from our exporter
NTVolumetric_* = raw NinjaTrader volumetric bid/ask data
Flow42 native VolDelta_* = diagnostic/proxy-like in the tested run
```

---

## Main Thesis

The v0.8 export contains some genuinely useful Flow42-related information, but it is not a full scrape of Flow42's visual event suite.

The usable exposed layer is mostly:

```text
Flow42 regime / continuation / spike / pressure context
```

It is not a clean export of the full visual-event layer, such as:

```text
AbsorptionMap staged absorption
VolDynamics absorption/exhaustion/push/surge
VolImbalance cluster zones
CloudNotes levels
VolLiqMeter live DOM/liquidity context
```

Therefore, the correct research posture is:

```text
Useful context layer = yes
Complete reversal-signal layer = no
Replacement for our own order-flow engineering = no
```

This is not a negative finding. It means Flow42 can still help, but we should not become dependent on hidden vendor internals or assume chart visuals equal clean historical features.

---

## PreferredDelta, True Delta, and Flow42 Native Delta

### PreferredDelta is our exporter wrapper

`PreferredDelta_*` is not Flow42's proprietary adjusted delta. It is a convenience layer created by the exporter.

In the v0.8 logic:

```text
If NinjaTrader volumetric bid/ask data is available:
    PreferredDelta = NTVolumetricBidAsk
else:
    PreferredDelta = fallback source, with warnings
```

In this run:

```text
PreferredDelta_Source = NTVolumetricBidAsk
PreferredDelta_Delta = NTVolumetric_Delta
PreferredDelta_CVD = NTVolumetric_CVD_Run
PreferredDelta_BuyVolume = NTVolumetric_BuyVolume
PreferredDelta_SellVolume = NTVolumetric_SellVolume
```

### What "true delta" means here

For this project, "true delta" means the best available bid/ask classified traded volume from NinjaTrader volumetric bars:

```text
Delta = Buy/aggressor volume - Sell/aggressor volume
```

It is not perfect or mystical truth, but it is much closer to real order-flow delta than OHLC proxy delta.

### Flow42 native VolDelta looked proxy-like

Flow42 native VolDelta was exposed, but under the tested settings it behaved like a proxy/up-down classification rather than true bid/ask delta.

The warning sign:

```text
abs(Flow42 native Delta) == full bar Volume on roughly 98.6% of rows.
```

That usually implies behavior like:

```text
Up bar   -> most/all volume assigned to buy
Down bar -> most/all volume assigned to sell
Flat bar -> volume split
```

By contrast, the NT volumetric delta version had `abs(Delta) == Volume` on only about 1.5% of rows, which is much more realistic.

Research rule:

```text
Use PreferredDelta_* by default.
Use NTVolumetric_* directly only when intentionally forcing raw NinjaTrader volumetric values.
Do not use Flow42 native VolDelta_Delta / VolDelta_CVD as the primary delta source in this run.
```

---

## Highest-Confidence Feature Families

Use these first for modeling:

```text
1. OHLCV and candle geometry
2. PreferredDelta_* / NTVolumetric_* true bid/ask delta
3. VolDrive continuation signals
4. ChopState state / chop score
5. VolSpike flag, with caution because it fired frequently in this run
```

Be careful with:

```text
1. Flow42 native VolDelta_* as true delta/CVD
2. VolSpike_Flag by itself
3. VolImbalance_Bid / VolImbalance_Ask because they were all zero in this run
```

Currently unavailable or placeholder-only from this run:

```text
AbsorptionMap stage / side / price / strength
VolDynamics absorption / exhaustion / push / surge
VolImbalance cluster details
CloudNotes levels
VolLiqMeter live DOM/liquidity values
Draw-object event columns
```

---

## Ranked Flow42-Related Variable Usefulness

### Tier S — use first

| Rank | Variable family | Columns | Why it matters | Unique to Flow42? |
|---:|---|---|---|---|
| 1 | Preferred / NT volumetric delta | `PreferredDelta_Delta`, `PreferredDelta_CVD`, `PreferredDelta_BuyVolume`, `PreferredDelta_SellVolume`, `PreferredDelta_Source`, `NTVolumetric_Delta`, `NTVolumetric_CVD_Run` | Primary order-flow feature set. Use for delta flips, CVD divergence, absorption-style failure, pressure shifts, and aggression/failure logic. | No. NinjaTrader/exporter-derived, but extremely valuable. |
| 2 | OHLCV and candle geometry | `Open`, `High`, `Low`, `Close`, `Volume`, `Body`, `Range`, `UpperWick`, `LowerWick`, `BodyFrac`, `UpperWickFrac`, `LowerWickFrac`, `CloseLocationFrac` | Core structure for reversal logic: failed highs/lows, wick rejection, body strength, range expansion, and close-location behavior. | No. |
| 3 | VolDrive continuation state | `VolDrive_Long`, `VolDrive_Short`, `VolDrive_Signal` | Useful as anti-fade context and post-reversal confirmation. Opposite-direction VolDrive near entry is a warning; a flip into the reversal direction can be confirmation. | Yes. |
| 4 | ChopState regime | `ChopState_State`, `ChopState_ChopScore` | Useful for slicing results by regime. Reversals may behave differently in chop, trend, failed breakout, and post-chop transition. | Yes-ish. Could be rebuilt, but this is Flow42's version. |

### Tier A — useful, but validate before trusting

| Rank | Variable family | Columns | Why it may help | Caveat |
|---:|---|---|---|---|
| 5 | VolSpike | `VolSpike_Flag` | Can flag high-attention/high-participation bars near failed pushes or rejection. | It fired on a large share of rows in the test run, so it is broad and not a standalone rare-spike signal. |
| 6 | Relative delta pressure | `VolDelta_RelativeDeltaPressure` | Potential vendor-derived pressure normalization that may add information beyond raw delta. | Validate separately because Flow42 native raw delta looked proxy-like. |
| 7 | VolImbalance basic automation outputs | `VolImbalance_Bid`, `VolImbalance_Ask` | Conceptually useful for imbalance/failure context. | They were all zero in the tested run. May need different settings, instrument, or market conditions. |

### Tier B — conceptually valuable, but not cleanly exposed

| Rank | Flow42 concept | Desired variables | Why it may matter | Current status |
|---:|---|---|---|---|
| 8 | AbsorptionMap | `AbsorptionMap_Stage`, `AbsorptionMap_Side`, `AbsorptionMap_Price`, `AbsorptionMap_Strength` | Highly relevant to reversals: aggressive push into a level, failure to continue, defended price, and absorption. | Not cleanly exposed. Private-field discovery suggests richer internal structures may exist, but no trusted public/exportable series was found. |
| 9 | VolDynamics events | `VolDynamics_Absorption`, `VolDynamics_Exhaustion`, `VolDynamics_VolumePush`, `VolDynamics_VolumeSurge` | Could detect event bars where volume/candle structure conflicts with continuation. | Not cleanly exposed. Discovery found settings/baselines, not trustworthy event flags. |
| 10 | VolImbalance clusters/zones | cluster high/low, side, volume, strength, reclaim/fade status | Could be useful as location/context around failed aggression, stacked imbalance, and reclaim zones. | Not cleanly exposed. Better to reconstruct from footprint data or ask vendor about official outputs. |

### Tier C — special-case / not part of current historical feature set

| Variable family | Why not included now | Possible future use |
|---|---|---|
| CloudNotes | Only useful if external/manual/gamma/CSV levels are configured and readable. | Later use for nearest level distance, level touch/reclaim/rejection logic. |
| VolLiqMeter | Mostly live DOM/Level 2 liquidity context, not naturally historical from a static 1-minute export. | Test separately during live RTH/active sessions with Level 2 data. |
| Draw-object event counts | Flow42 visuals were not captured as standard NinjaTrader DrawObjects in the tested setup. | Keep schema placeholders, but do not model them unless a future draw-object-focused run proves real signals are captured. |
| Private fields / OnRender state | Fragile, version-dependent, hard to interpret, and possibly not stable. | Useful only as an investigation map or as a guide for vendor questions. |

---

## How to Use Flow42 in Reversal Research

### Best current architecture

```text
Primary reversal model:
    price structure
    true volumetric delta
    footprint-derived imbalance/absorption/exhaustion
    market-internals confluence
    honest execution assumptions

Flow42 context layer:
    VolDrive
    ChopState
    VolSpike
    possible RelativeDeltaPressure
    possible VolImbalance_Bid/Ask if activated meaningfully
```

Flow42 should help answer questions like:

```text
Was the market choppy or directional?
Was there a continuation signal fighting the reversal?
Did continuation flip after the reversal?
Was the bar a high-attention volume spike?
Does vendor pressure context agree or disagree with our own delta?
```

Flow42 should not be treated as the entire reversal model unless its richer visual events become cleanly exportable and validate statistically.

---

## Reconstruct These Concepts Ourselves

The unexposed Flow42 concepts are interesting because they map directly to the reversal framework, but the better research path is likely to rebuild transparent versions ourselves.

Candidate reconstructed features:

```text
Absorption
Exhaustion
Failed aggression
Delta divergence
Stacked imbalance
Imbalance cluster zones
Reclaim / failure of zones
Sweep + reclaim behavior
```

Example long-side absorption candidate:

```text
price makes or approaches local low
+ sell delta is heavy
+ low does not extend much
+ lower wick / reclaim appears
+ next 1-3 bars fail to continue lower
```

Example stacked sell-imbalance failure:

```text
multiple bid-side imbalances near the low
+ price fails to continue down
+ next bar reclaims imbalance zone
+ delta flips positive
```

These definitions are better than black-box vendor scraping because they can be versioned, stress-tested, varied, and validated without guessing what a rendered visual object meant internally.

---

## Realistic Paths Forward

### Path A — Use exposed Flow42 context now

Use the clean features immediately:

```text
VolDrive_Signal
ChopState_State
ChopState_ChopScore
VolSpike_Flag
VolDelta_RelativeDeltaPressure
PreferredDelta_*
NTVolumetric_*
OHLCV / candle geometry
```

This is the lowest-friction path and should be model-ready.

### Path B — Build our own missing order-flow features

Reconstruct absorption, exhaustion, failed aggression, imbalance zones, delta divergence, and sweep/reclaim behavior from footprint/volumetric exports.

This is likely the best serious research path because it avoids dependence on hidden Flow42 internals.

### Path C — Ask Flow42/vendor support about official automation outputs

Ask whether the following expose BloodHound/BlackBird plots, public NinjaScript `Series`, or any stable automation-accessible values:

```text
AbsorptionMap:
- stage
- side
- price
- strength

VolDynamics:
- absorption event
- exhaustion event
- volume push event
- volume surge event

VolImbalance:
- cluster high/low
- cluster side
- cluster strength
- cluster volume
```

If official outputs exist, add exact mappings to the exporter. If they do not, avoid fragile scraping.

### Path D — Private reflection / OnRender scraping

Treat this as a last resort.

Private-field or OnRender scraping is likely:

```text
fragile
version-dependent
thread-unsafe
hard to interpret
not guaranteed to match what the human eye sees
not a stable research foundation
```

Do not make the core research pipeline depend on it.

---

## Validation Rules Before Using Any Flow42 Column

Before a Flow42 column becomes a model feature, confirm:

```text
1. It is populated.
2. It is not a constant or near-constant.
3. It is timestamped cleanly.
4. It does not repaint.
5. It is available before the trade decision.
6. It has a clear interpretation.
7. It survives out-of-sample testing.
8. It improves a transparent baseline after honest execution assumptions.
```

For delta-like columns, also test:

```text
abs(Delta) == Volume frequency
BuyVolume + SellVolume == Volume integrity
correlation with candle direction
comparison versus NTVolumetric_Delta
whether CVD reset behavior matches expectations
```

---

## Practical Modeling Recommendations

### Use first

```text
PreferredDelta_Delta
PreferredDelta_CVD
PreferredDelta_BuyVolume
PreferredDelta_SellVolume
PreferredDelta_Source

NTVolumetric_Delta
NTVolumetric_CVD_Run
NTVolumetric_BuyVolume
NTVolumetric_SellVolume

VolDrive_Signal
VolDrive_Long
VolDrive_Short

ChopState_State
ChopState_ChopScore

VolSpike_Flag

OHLCV / candle-structure columns
```

### Use cautiously

```text
VolDelta_RelativeDeltaPressure
VolSpike_Flag
VolImbalance_Bid
VolImbalance_Ask
```

### Do not use as serious model features from this run

```text
Flow42 native VolDelta_Delta / VolDelta_CVD as true bid/ask delta
AbsorptionMap_* blank columns
VolDynamics_* blank columns
VolImbalance cluster columns
VolLiqMeter_* columns
CloudNotes_* columns
DrawEvents_* columns
```

---

## Final Research Interpretation

Flow42 gave the project a partial but useful feature layer.

It currently helps with:

```text
price/candle structure
true volumetric bid/ask delta through our exporter
CVD/pressure through PreferredDelta
VolDrive continuation context
ChopState regime filtering
VolSpike context
possibly vendor-derived pressure context
```

It does not yet provide clean historical feature versions of:

```text
AbsorptionMap staged absorption events
VolDynamics absorption/exhaustion/push/surge events
VolImbalance cluster/zone details
CloudNotes external levels
VolLiqMeter live DOM/liquidity context
```

The best path is to keep the useful Flow42 context layer while building the real reversal engine from transparent, testable order-flow features that we control.
