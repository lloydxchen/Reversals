# Flow42 Context for Reversal Research

_Last updated: 2026-06-16_

## Purpose

This note documents how the Flow42 indicator suite should be interpreted inside the reversal-model research workflow.

The key conclusion is nuanced:

```text
Flow42 is useful as a context/filter layer.
Flow42 is not currently a complete exportable reversal-event dataset.
The most reversal-specific Flow42 visual concepts appear only partially exposed or not cleanly exposed.
```

The current exporter work gives us a useful, trustworthy subset of Flow42-related data, but not the entire visual indicator suite in clean data form.

---

## Current exporter context

Current working exporter:

```text
Flow42DataCapture_v0_8
Preset: Export_FastAllFlow42
Chart: NQ JUN26, 1 Min Volumetric
Exporter Delta Mode: AutoPreferNTVolumetricBidAsk
```

Important v0.8 result:

```text
PreferredDelta_Source = NTVolumetricBidAsk on all exported rows
NTVolumetricDelta_Rows = 10,000
NTVolumetricDelta_MissingRows = 0
NTVolumetricDelta_BuySellSumMismatchRows = 0
```

This means the exporter successfully calculated its own true volumetric bid/ask delta from NinjaTrader volumetric bars. This fixed the earlier issue where Flow42 native VolDelta appeared proxy-like.

---

## High-level interpretation

Think of the Flow42 data in four buckets.

```text
1. Not unique but essential:
   OHLCV, candle structure, NT volumetric bid/ask delta, PreferredDelta.

2. Unique and currently usable:
   VolDrive, ChopState, VolSpike, maybe RelativeDeltaPressure.

3. Unique but not currently captured cleanly:
   AbsorptionMap, VolDynamics event states, VolImbalance clusters/zones.

4. Special-case/live-only:
   VolLiqMeter, CloudNotes.
```

The strongest use of Flow42 right now is as a supplementary context layer on top of our own reversal models.

---

## PreferredDelta vs true delta vs Flow42 VolDelta

### PreferredDelta

`PreferredDelta_*` is not a proprietary Flow42 calculation.

It is an exporter-created convenience layer:

```text
If NinjaTrader volumetric bid/ask data is available:
    PreferredDelta = NTVolumetricBidAsk
else:
    PreferredDelta = fallback source, with warnings
```

In the v0.8 run:

```text
PreferredDelta_Delta = NTVolumetric_Delta
PreferredDelta_CVD = NTVolumetric_CVD_Run
PreferredDelta_BuyVolume = NTVolumetric_BuyVolume
PreferredDelta_SellVolume = NTVolumetric_SellVolume
PreferredDelta_Source = NTVolumetricBidAsk
```

For current modeling, use `PreferredDelta_*` by default.

### True / volumetric delta

In this context, true delta means the best available bid/ask classified traded volume from NinjaTrader volumetric bars:

```text
Delta = BuyVolume - SellVolume
```

This is not mystical truth, but it is far better than OHLC proxy delta for order-flow research.

### Flow42 native VolDelta

Flow42 native VolDelta was exposed, but under the tested settings it looked proxy-like:

```text
Flow42 native |Delta| == full bar Volume on roughly 98.6% of rows.
```

That usually means the calculation is behaving like directional-bar volume:

```text
If Close > Open: most/all volume assigned to buy
If Close < Open: most/all volume assigned to sell
If Close == Open: volume split
```

So for serious order-flow backtesting, do not treat Flow42 native `VolDelta_Delta` or `VolDelta_CVD` as true bid/ask delta unless the source is later verified/fixed.

---

## Ranked variable/value list

### Tier S — use first / highest confidence

These are the most useful and cleanly usable variables for reversal-model testing.

| Rank | Variable family | Columns | Why it matters | Unique to Flow42? |
|---:|---|---|---|---|
| 1 | Preferred / NT volumetric delta | `PreferredDelta_Delta`, `PreferredDelta_CVD`, `PreferredDelta_BuyVolume`, `PreferredDelta_SellVolume`, `PreferredDelta_Source`, `NTVolumetric_Delta`, `NTVolumetric_CVD_Run` | Primary order-flow feature set. Use for delta flips, CVD divergence, absorption-style failure, and pressure shifts. | No; this is NinjaTrader/exporter-derived, but very valuable. |
| 2 | OHLCV and candle geometry | `Open`, `High`, `Low`, `Close`, `Volume`, `Body`, `Range`, `UpperWick`, `LowerWick`, `BodyFrac`, `UpperWickFrac`, `LowerWickFrac`, `CloseLocationFrac` | Core structure for reversal logic: rejection, failed highs/lows, wick/body behavior, candle confirmation. | No. |
| 3 | VolDrive continuation state | `VolDrive_Long`, `VolDrive_Short`, `VolDrive_Signal` | Useful as anti-fade context and post-reversal confirmation. If VolDrive is still firing opposite the reversal, be cautious. If it flips into the reversal direction afterward, that may be confirmation. | Yes. |
| 4 | ChopState regime | `ChopState_State`, `ChopState_ChopScore` | Useful for slicing performance by market regime. Reversals may behave differently in chop, trend, failed breakout, and post-chop transition. | Yes-ish. Could be rebuilt, but this is Flow42's version. |

### Tier A — useful, but needs validation/tuning

| Rank | Variable family | Columns | Why it matters | Caveat |
|---:|---|---|---|---|
| 5 | VolSpike | `VolSpike_Flag` | Flow42's spike/context flag may help identify high-attention bars around failed pushes or rejection. | It fired very frequently in the test run, so it is not automatically a rare spike. Needs tuning or interaction terms. |
| 6 | Relative delta pressure | `VolDelta_RelativeDeltaPressure` | Could be a vendor-derived normalized pressure feature that may add information beyond raw delta. | Validate empirically. Flow42 native raw delta looked proxy-like, but this pressure measure might still be useful. |
| 7 | VolImbalance basic automation outputs | `VolImbalance_Bid`, `VolImbalance_Ask` | These are Flow42's exposed BloodHound-style imbalance signals. Conceptually useful for failed aggression / imbalance context. | They were all zero in the tested run. May require different settings or conditions. |

### Tier B — potentially valuable, but not currently cleanly exposed

These may be the most conceptually reversal-specific Flow42 features, but they were not exported as clean public series/plots in the current discovery runs.

| Rank | Flow42 concept | Desired variables | Why it may matter | Current status |
|---:|---|---|---|---|
| 8 | AbsorptionMap | `AbsorptionMap_Stage`, `AbsorptionMap_Side`, `AbsorptionMap_Price`, `AbsorptionMap_Strength` | Highly relevant to reversals: aggressive push into a level, failure to continue, defended price/absorption. | Not cleanly exposed. Private-field discovery suggests internal state exists, but values were not read/exported. |
| 9 | VolDynamics events | `VolDynamics_Absorption`, `VolDynamics_Exhaustion`, `VolDynamics_VolumePush`, `VolDynamics_VolumeSurge` | Could help detect event bars where volume/candle structure conflicts with continuation. | Not cleanly exposed. Discovery found settings/baselines, not trustworthy event flags. |
| 10 | VolImbalance clusters/zones | cluster high/low, side, volume, strength, reclaim/fade status | Could be useful as location/context around failed aggression and reclaim zones. | Not cleanly exposed. Better to reconstruct from footprint/volumetric data or ask vendor about official outputs. |

### Tier C — special-case / not part of the current historical feature set

| Variable family | Why not included now | Possible future use |
|---|---|---|
| CloudNotes | Only useful if external levels are configured and readable. | Use later for nearest gamma/manual/session/CSV level distance, level touch/reclaim/reject logic. |
| VolLiqMeter | Mostly live DOM/Level 2 context. Not naturally historical from a static 1-minute chart. | Test separately during live RTH/active session with Level 2 data. |
| DrawObject event counts | Flow42 visual markers were not captured as standard NinjaTrader DrawObjects in the current setup. | Keep as schema placeholders, but do not rely on them unless a draw-object-focused run proves real signals are captured. |
| Private field names | Useful awareness map only. | Can guide reconstruction or vendor-support questions, but should not be treated as model data. |

---

## What is unique and valuable from Flow42 right now?

The most useful Flow42-specific exposed data is probably:

```text
1. VolDrive_Signal
2. ChopState_State
3. ChopState_ChopScore
4. VolSpike_Flag
5. VolDelta_RelativeDeltaPressure
6. VolImbalance_Bid / VolImbalance_Ask if we can make them fire meaningfully
```

The strongest non-Flow42 but essential features are:

```text
1. PreferredDelta_Delta
2. PreferredDelta_CVD
3. PreferredDelta_BuyVolume / SellVolume
4. OHLCV and candle geometry
```

This means Flow42 is not useless, but the primary statistical edge probably should not depend only on Flow42. The better architecture is:

```text
Primary reversal model:
    raw price + true volumetric delta + footprint/reconstructed order-flow logic

Flow42 context layer:
    VolDrive + ChopState + VolSpike + possible pressure/imbalance features
```

---

## Concern: Are the best Flow42 features hidden/unexposed?

Possibly yes.

The most reversal-specific Flow42 visual concepts are likely:

```text
AbsorptionMap staged absorption
VolDynamics absorption/exhaustion/push/surge
VolImbalance clusters/zones
```

These could be valuable. They map directly to reversal logic:

```text
location -> aggressive push -> failure -> absorption/delta disagreement -> confirmation
```

However, the exporter did not find clean public outputs for them. That means they may be:

```text
private/internal state
OnRender-only visuals
obfuscated vendor objects
cached custom structures
settings-dependent outputs that were not enabled
not exposed for automation in the installed build
```

Do not assume these are available just because the chart visually shows something.

---

## Realistic paths to get the missing data

### Path A — Use exposed Flow42 context now

Use the current clean features:

```text
VolDrive_Signal
ChopState_State
ChopState_ChopScore
VolSpike_Flag
VolDelta_RelativeDeltaPressure
PreferredDelta_*
OHLCV / candle geometry
```

This is low-friction and model-ready.

### Path B — Reconstruct missing concepts ourselves

This is probably the best serious path.

Rebuild our own versions of:

```text
absorption
exhaustion
failed aggression
delta divergence
stacked imbalance
imbalance cluster zones
reclaim/failure of zones
```

using raw footprint/volumetric data.

This may be better than depending on Flow42 internals because:

```text
we control definitions
we can test variants
we can avoid black-box ambiguity
we can export every intermediate feature
```

Example absorption-style reconstruction:

```text
Long absorption candidate =
    price near local/session low
    + heavy sell delta
    + low fails to extend meaningfully
    + lower wick or reclaim
    + next 1-3 bars fail to continue lower
```

Example imbalance failure reconstruction:

```text
Sell imbalance failure =
    bid-side/ask-side aggressive imbalance near a low
    + no continuation lower
    + reclaim of imbalance zone
    + delta flips positive or selling pressure weakens
```

### Path C — Ask Flow42/vendor support about official outputs

Ask specifically whether these expose BloodHound/BlackBird plots or public NinjaScript series:

```text
AbsorptionMap:
- stage
- side
- price
- strength
- confirmed/provisional/candidate state

VolDynamics:
- absorption event flag
- exhaustion event flag
- volume push flag
- volume surge flag

VolImbalance:
- cluster high/low
- cluster side
- cluster volume/strength
- zone reclaim/fade/break status
```

If official outputs exist, add strict exact mappings in the exporter.

### Path D — Private reflection / OnRender scraping

This is not recommended as the main path.

Private-field discovery found a lot of internal state, but much of it appears obfuscated. Reading private values would be fragile and could break across Flow42 updates.

OnRender scraping is also usually unrealistic. If Flow42 draws pixels directly via SharpDX, another indicator generally cannot convert those pixels back into clean structured values like:

```text
AbsorptionStage = Confirmed
AbsorptionPrice = 21845.25
Side = SellAbsorbed
```

Use private-field discovery as awareness, not as model infrastructure.

---

## Warnings / caveats

### 1. Blank is better than wrong

The exporter intentionally leaves many desired columns blank because no strict trusted source was found.

This is good. It avoids fake columns created from loose matching.

Do not force-fill columns like `VolDynamics_Absorption` from similarly named settings such as `ThresholdAbs` or display parameters.

### 2. Flow42 native VolDelta is not currently the primary delta source

In the v0.8 export, use `PreferredDelta_*` instead.

Flow42 native VolDelta remains diagnostic unless its source mode is changed and verified.

### 3. VolSpike is not automatically rare

`VolSpike_Flag` fired often in the tested export. It may still be useful, but likely as an interaction feature:

```text
VolSpike + wick rejection
VolSpike + failed high/low
VolSpike + delta divergence
VolSpike + level touch/reclaim
```

not as a standalone signal.

### 4. VolDrive is continuation-oriented

Use VolDrive as:

```text
anti-fade warning
post-turn confirmation
trend/continuation context
```

not as the first reversal detector.

### 5. ChopState is not simply good/bad

Chop may hurt continuation trades but help range-edge reversal trades. Test separately.

Suggested slices:

```text
ChopState_State = 1
ChopState_State = 0
ChopState_ChopScore = 1 / 0 / -1
transition into chop
transition out of chop
failed breakout from chop
```

### 6. Private fields are not model features

`Flow42_PrivateFieldNames.csv` is an awareness file only. It tells us what might exist internally, not what is safe to export.

---

## Recommended modeling plan

### First test layer

Start with:

```text
OHLCV / candle geometry
PreferredDelta_Delta
PreferredDelta_CVD
PreferredDelta_BuyVolume
PreferredDelta_SellVolume
VolDrive_Signal
ChopState_State
ChopState_ChopScore
VolSpike_Flag
VolDelta_RelativeDeltaPressure
```

### Then test interactions

Examples:

```text
reversal candidate + VolDrive opposite = worse?
reversal candidate + VolDrive flips with trade = better?
reversal candidate + ChopState_State = 1 vs 0
reversal candidate + VolSpike_Flag = 1
reversal candidate + PreferredDelta flip within 1-3 bars
reversal candidate + CVD divergence
reversal candidate + wick rejection + heavy negative/positive delta
```

### Later reconstruction targets

Build our own versions of:

```text
absorption
exhaustion
failed aggressive imbalance
stacked imbalance zone
imbalance reclaim
CVD divergence
failed breakout from chop/range
```

These reconstructed features may become more valuable than the exposed Flow42 outputs.

---

## Bottom-line thesis

Flow42 should currently be used as a useful context layer, not as a complete reversal model source.

Best current use:

```text
Use Flow42 VolDrive + ChopState + VolSpike + RelativeDeltaPressure as contextual filters/confirmations.
Use our own PreferredDelta/NTVolumetric data as the true order-flow backbone.
Reconstruct the missing reversal-specific features ourselves from raw footprint/volumetric data.
```

The exposed Flow42 data is worth testing, but the strongest edge is likely to come from combining:

```text
raw price structure
+ true bid/ask delta
+ reconstructed absorption/imbalance/failure logic
+ Flow42 regime/continuation/spike context
```
