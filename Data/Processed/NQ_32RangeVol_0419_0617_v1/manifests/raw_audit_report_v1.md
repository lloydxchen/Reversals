# Raw Audit Report v1

Generated: 2026-06-17 08:06:14 PM ET
Timezone for human-readable timestamps: America/New_York (ET)

## bars

- Path: `C:\Users\chenk\Desktop\LloydTrading\Reversals\Data\NQ\32Range\NQ_0419-0617_32RangeVol_bars.csv`
- Size: 73,328,550 bytes
- SHA256: `c58afae5e0b2212c1b96571eaa560e25d2ca8f8ade30342a49307372d252111c`
- Encoding: `utf-8-sig`
- Delimiter: `,`
- Rows: 152,241
- Columns: 74
- Timestamp column: `Timestamp`
- First timestamp: 2026-04-19 06:00:00 PM ET
- Last timestamp: 2026-06-17 07:02:49 PM ET
- Timestamp parse success rate: 100.000000%
- Missing timestamps: 0
- Duplicate timestamp rows: 11,270
- Duplicate full rows: 0
- Malformed rows: 0

### Columns

`ExportRunId`, `Timestamp`, `InstrumentMaster`, `InstrumentFull`, `ChartTag`, `BarsPeriodType`, `BarsPeriodValue`, `BarIndex`, `IsFirstBarOfSession`, `Open`, `High`, `Low`, `Close`, `Volume`, `RangePoints`, `RangeTicks`, `BodyTicks`, `UpperWickTicks`, `LowerWickTicks`, `CloseLocation`, `BarDelta`, `DeltaPerVolume`, `NinjaCVD`, `ExportSessionCVD`, `TotalBuyingVolume`, `TotalSellingVolume`, `DeltaPercent`, `Trades`, `MaxSeenDelta`, `MinSeenDelta`, `DeltaSinceHigh`, `DeltaSinceLow`, `MaxPositiveDelta`, `MaxNegativeDelta`, `POCPrice`, `POCVolume`, `POCPosition`, `MaxAskPrice`, `MaxAskVolume`, `MaxBidPrice`, `MaxBidVolume`, `FootprintTotalBid`, `FootprintTotalAsk`, `FootprintTotalVolume`, `FootprintDelta`, `FootprintNonZeroLevels`, `FootprintVolumeMismatch`, `BottomZoneTicks`, `BottomZoneBid`, `BottomZoneAsk`, `BottomZoneVolume`, `BottomZoneDelta`, `BottomZoneVolShare`, `TopZoneBid`, `TopZoneAsk`, `TopZoneVolume`, `TopZoneDelta`, `TopZoneVolShare`, `StackedBuyMaxRun`, `StackedSellMaxRun`, `BuyImbalanceCount`, `SellImbalanceCount`, `TopBuyImbalanceCount`, `BottomSellImbalanceCount`, `TopBuyStackMax`, `BottomSellStackMax`, `DeltaSource`, `ExportErrorCountAtBar`, `PrimaryDataType`, `IsPrimaryVolumetric`, `DeltaSourceDetail`, `DataQualityStatus`, `DataQualityWarning`, `OutputRunFolder`

### Major warnings

- 11270 duplicate timestamp rows; allowed for range/volumetric data.

## footprint

- Path: `C:\Users\chenk\Desktop\LloydTrading\Reversals\Data\NQ\32Range\NQ_0419-0617_32RangeVol_footprint.csv`
- Size: 747,377,365 bytes
- SHA256: `55e4e2b6534960e1fb819e2c18d6b67bc081ccc5aff7d93542bf1dfc2dab9d37`
- Encoding: `utf-8-sig`
- Delimiter: `,`
- Rows: 3,805,294
- Columns: 30
- Timestamp column: `Timestamp`
- First timestamp: 2026-04-19 06:00:00 PM ET
- Last timestamp: 2026-06-17 07:02:49 PM ET
- Timestamp parse success rate: 100.000000%
- Missing timestamps: 0
- Duplicate timestamp rows: 3,664,331
- Duplicate full rows: 0
- Malformed rows: 0

### Columns

`ExportRunId`, `Timestamp`, `InstrumentMaster`, `InstrumentFull`, `ChartTag`, `BarsPeriodType`, `BarsPeriodValue`, `BarIndex`, `Open`, `High`, `Low`, `Close`, `Volume`, `BarDelta`, `ExportSessionCVD`, `PriceLevel`, `TickIndexFromLow`, `PricePosition`, `TotalVol`, `BidVol`, `AskVol`, `LevelDelta`, `IsBarHigh`, `IsBarLow`, `InBottomZone`, `InTopZone`, `BuyDiagonalImbalance`, `SellDiagonalImbalance`, `VolumetricSource`, `VolumetricSourceTime`

### Major warnings

- 3664331 duplicate timestamp rows; allowed for range/volumetric data.

## manifest

- Path: `C:\Users\chenk\Desktop\LloydTrading\Reversals\Data\NQ\32Range\NQ_0419-0617_32RangeVol_manifest.csv`
- Size: 1,966 bytes
- SHA256: `88bfb560674d01c233e231eac6dc2432bbdafb766aad9c87af1bfbf7869b1d69`
- Encoding: `utf-8-sig`
- Delimiter: `,`
- Rows: 41
- Columns: 2
- Timestamp column: `None`
- First timestamp: None
- Last timestamp: None
- Timestamp parse success rate: 0.000000%
- Missing timestamps: 0
- Duplicate timestamp rows: 0
- Duplicate full rows: 0
- Malformed rows: 0

### Columns

`Key`, `Value`

### Major warnings

- None

## Validation

- Status: PASS
- Bars raw vs processed rows: 152241 / 152241
- Footprint raw vs processed rows: 3805294 / 3805294
- Empty partitions: 0
