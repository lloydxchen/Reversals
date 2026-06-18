# NinjaTrader L2/TICK Exporter Implementation Addendum v1

## Purpose

Extend the final A+ reversal exporter so it can support controlled ablations:

- Baseline footprint/order-flow model.
- Baseline + TICK/index internals.
- Baseline + CME Level 2 depth.
- Full combined model.

This addendum is for exporter design. It does not change the baseline model rules.

## Global Export Requirements

Every row needs:

- `signal_id`
- `model_variant`
- `timestamp_signal`
- `timestamp_confirmed`
- `timestamp_triggered`
- `instrument`
- `bar_type`
- `bar_period`
- `session_phase`
- `direction`
- `baseline_signal_id`
- `entry_reference`
- `stop_reference`
- `state`
- `grade`
- `hard_cap_reason`
- `feature_timestamp_policy`

Timestamp policy values:

- `PRE_SIGNAL`
- `AT_SIGNAL`
- `AT_CONFIRMATION`
- `DELAYED_CONFIRMATION`
- `OUTCOME_ONLY`

If a feature is not available until after the baseline entry, the exporter must label it as delayed confirmation or outcome. No silent lookahead.

## Baseline Footprint Module Columns

Keep all final baseline fields:

- `baseline_total_score`
- `baseline_grade`
- `baseline_active_modules`
- `edge_price`
- `edge_level_type`
- `location_score`
- `failure_score`
- `confirmation_score`
- `risk_score`
- `timing_score`
- `edge_volume_low`
- `edge_volume_high`
- `edge_volume_percentile`
- `exhaustion_flag`
- `BarDelta`
- `MaxSeenDelta`
- `MinSeenDelta`
- `DeltaGiveBackPct`
- `absorption_score`
- `effort_result_score`
- `delta_trap_score`
- `failed_acceptance_flag`
- `ImbType`
- `multiple_imbalance_count`
- `stack_count`
- `cell_volume_min`
- `RatioValue`
- `RatioFlag`
- `abandoned_va_flag`
- `back_to_back_poc_flag`
- `sequencing_flag`
- `zero_delta_noise_flag`
- `timeframe_gate_applied`
- `signal_high`
- `signal_low`
- `signal_close`
- `stop_distance_ticks`

## Market Internals / TICK Module

Data assumptions:

- Historical/replay TICK series available.
- Index/top-of-book Level 1 series available and timestamp-aligned.

TICK columns:

- `tick_value_at_signal`
- `tick_value_at_confirm`
- `tick_percentile`
- `tick_extreme_flag`
- `tick_extreme_direction`
- `tick_slope_pre_signal`
- `tick_slope_at_confirm`
- `tick_divergence_score`
- `tick_new_extreme_flag`
- `tick_recovery_at_confirm`
- `tick_recovery_seconds`
- `tick_veto_flag`
- `tick_context_score`

Index/top-of-book columns:

- `index_symbol`
- `index_bid`
- `index_ask`
- `index_mid`
- `index_spread`
- `index_mid_slope`
- `index_quote_velocity`
- `index_risk_context`
- `index_confirm_flag`
- `index_veto_flag`

Implementation notes:

- TICK as context uses values at or before signal/confirmation.
- TICK recovery after sweep is delayed confirmation unless entry waits for it.
- Use separate columns for TICK feature role: `tick_role = context|boost|confirm|veto`.

## Level 2 Depth Module

Data assumptions:

- CME Level 2 market depth/order book available historically/replay.
- Book updates and trade prints can be timestamp-aligned.
- Exporter can create snapshots at named event times.

### Depth Snapshot Columns

For each event window:

- `l2_snapshot_time_pre_signal`
- `l2_snapshot_time_at_signal`
- `l2_snapshot_time_at_confirm`
- `l2_snapshot_time_at_trigger`

Depth columns:

- `l2_bid_depth_1`
- `l2_ask_depth_1`
- `l2_bid_depth_3`
- `l2_ask_depth_3`
- `l2_bid_depth_5`
- `l2_ask_depth_5`
- `l2_bid_depth_10`
- `l2_ask_depth_10`
- `l2_depth_imbalance_1`
- `l2_depth_imbalance_3`
- `l2_depth_imbalance_5`
- `l2_depth_imbalance_10`
- `l2_depth_at_edge_bid`
- `l2_depth_at_edge_ask`
- `l2_depth_behind_edge_bid`
- `l2_depth_behind_edge_ask`

Depth imbalance formula:

`(bid_depth - ask_depth) / max(bid_depth + ask_depth, 1)`

### Liquidity Pull / Replenishment Columns

- `l2_bid_pull_rate`
- `l2_ask_pull_rate`
- `l2_bid_replenish_rate`
- `l2_ask_replenish_rate`
- `l2_passive_replenishment_flag`
- `l2_replenishment_side`
- `l2_replenishment_after_aggression_ms`
- `l2_depth_before_trade`
- `l2_depth_after_trade`

### Sweep / Book Flip Columns

- `l2_sweep_flag`
- `l2_sweep_direction`
- `l2_sweep_levels`
- `l2_sweep_visible_liquidity_qty`
- `l2_sweep_trade_volume`
- `l2_book_pressure_pre_sweep`
- `l2_book_pressure_at_sweep`
- `l2_book_pressure_post_sweep`
- `l2_book_flip_flag`
- `l2_book_flip_timestamp`
- `l2_reclaim_after_sweep_flag`

### Resting Liquidity Columns

- `resting_bid_at_prior_low`
- `resting_ask_at_prior_high`
- `resting_liquidity_at_edge`
- `resting_liquidity_distance_ticks`
- `resting_liquidity_pulled_flag`
- `resting_liquidity_replenished_flag`

### Microprice / Quote Instability Columns

- `l2_microprice`
- `l2_microprice_slope`
- `l2_microprice_divergence_score`
- `l2_book_pressure`
- `spread_at_signal`
- `spread_percentile`
- `quote_velocity`
- `order_book_churn`
- `quote_instability_flag`

Implementation notes:

- L2 features must carry a timestamp.
- Book after the baseline signal is not free. If used, it creates a delayed confirmation variant.
- Quote churn/spread instability should start as risk penalty, not hard veto.
- Do not treat displayed liquidity as guaranteed real liquidity; test pull/replenishment behavior.

## Combined Model Columns

For combined variants:

- `model_variant`
- `baseline_total_score`
- `tick_context_score`
- `l2_depth_score`
- `combined_total_score`
- `tick_role`
- `l2_role`
- `tick_veto_flag`
- `l2_veto_flag`
- `combined_veto_reason`
- `entry_timing_mode`

Entry timing modes:

- `BASELINE_ENTRY`
- `TICK_DELAYED_CONFIRM`
- `L2_DELAYED_CONFIRM`
- `L2_TIMING_TRIGGER`
- `FULL_DELAYED_CONFIRM`

## Ablation / Backtest Labels

Required labels:

- `A_BASELINE`
- `B_BASELINE_TICK_CONTEXT`
- `B_BASELINE_TICK_VETO`
- `C_BASELINE_L2_SOFT`
- `C_BASELINE_L2_CONFIRM`
- `C_BASELINE_L2_VETO`
- `C_BASELINE_L2_TIMING`
- `C_BASELINE_L2_CONFIRM_INVALIDATE`
- `D_FULL_SOFT`
- `D_FULL_HARD_VETO`
- `E_STRICT_A_PLUS`
- `E_BROAD_A_B`

Also export:

- `uses_tick_features`
- `uses_l2_features`
- `uses_delayed_confirmation`
- `uses_hard_veto`
- `uses_soft_score`
- `baseline_entry_price`
- `enhanced_entry_price`
- `entry_delay_ms`
- `entry_delay_bars`

## Outcome Fields

Outcome fields must be marked as outcome, not signal-time features:

- `mfe_1bar_ticks`
- `mae_1bar_ticks`
- `mfe_3bar_ticks`
- `mae_3bar_ticks`
- `mfe_5bar_ticks`
- `mae_5bar_ticks`
- `mfe_timeout_ticks`
- `mae_timeout_ticks`
- `time_to_follow_through_ms`
- `bars_to_follow_through`
- `failure_speed_ms`
- `bars_to_invalidation`
- `max_drawdown_after_signal_ticks`
- `first_target_hit_flag`
- `stop_hit_flag`

## Build Order

1. Baseline exporter fields.
2. TICK/index fields.
3. L2 snapshots at signal/confirmation.
4. L2 pull/replenishment.
5. Sweep/book-flip event windows.
6. Combined model labels.
7. Outcome fields.

Do not build hard L2/TICK filters before the exporter can prove soft feature value.

