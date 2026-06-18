# A+ Reversal Qualitative Framework v2 Extra High

Source boundary: this refinement uses only the isolated Codex KB/evidence files plus prior targeted checks of raw deduplicated VTTs. It does not use Claude output or other repo research.

## Refined Core Thesis

The trader is not teaching a generic "fade extremes" model. The sharper model is:

**At a meaningful edge, aggressive traders must either run out of fuel, get absorbed, or fail to get continuation. The trade is only A+ when that failure is visible in the footprint, the stop is structurally tight, and price responds quickly.**

The model has four layers:

1. **Location:** high/low of day, swing high/low, prior support/resistance, value/POC/VWAP/session reference, or obvious breakout/sweep level.
2. **Failure mechanism:** exhaustion, absorption, delta failure, trapped traders, failed imbalance, failed breakout, or failed continuation.
3. **Confirmation:** bar close confirms the signal; next bar or reclaim/rejection shows price moving away from the failed edge.
4. **Invalidation/management:** stop beyond the failed edge; if the move stalls, downgrade or scratch.

## Taxonomy Upgrade

V1 listed many setup names. V2 treats them as a hierarchy:

- **Primary A+ family:** exhaustion/absorption reversal at a meaningful edge.
- **Secondary reversal families:** failed acceptance, delta trap/divergence, imbalance failure, retest rejection.
- **Supporting context modules:** session regime, value/POC/VWAP, high/low of day, cash-open timing, volatility.
- **Management modules:** structural stop, quick-response requirement, no-response exit.

This matters because a stop-run, failed breakout, trapped trader, and positive-delta trap can all describe the same event from different angles. The indicator should score the shared failure pattern instead of double-counting every label.

## A+ Versus Mediocre

### A+ Reversal

- Happens at a clean edge, not the middle of noise.
- Has visible aggressive participation into the edge.
- Shows failure of that aggression: exhaustion, absorption, delta weakening, no continuation, or reclaim/rejection.
- Has a compact stop beyond the actual failure point.
- Responds quickly after entry.
- Has no obvious hostile context, such as a strong trend-day breakout still accepting outside value.

### Mediocre Reversal

- Has one good footprint clue but weak location.
- Signal bar is too large, making stop/R poor.
- Confirmation is late or ambiguous.
- Delta is mixed but not clearly failing.
- Price goes sideways after entry.
- Setup appears right before a volatile session transition.

### Bad Reversal

- Mechanical fade of every exhaustion print.
- Fade of strong continuation with no failure.
- Large-volume fade with no proof that volume failed.
- Delta divergence in chop with no level.
- Stop-run assumed from volume alone.
- Trapped-trader label applied to any large order.

## Setup 1: Edge Exhaustion Reversal

**Description:** Very light volume trades at the extreme of a bar at a swing/session edge.

**Order-flow story:** The market reaches an edge but the final push has little actual trade at the extreme. The aggressive side has run out of ammunition.

**Bullish version:** Low/swing low/LOD/support prints very light volume at the low. Sellers previously pushed down but cannot keep trading size at new lows.

**Bearish version:** High/swing high/HOD/resistance prints very light volume at the high. Buyers previously pushed up but cannot keep trading size at new highs.

**Required:**

- Direct support: edge volume at high/low is tiny.
- Direct support: swing high/low or high/low of day matters.
- Direct support: bar close confirms the print.
- Direct support: not every exhaustion print is a trade.

**Confirmation:** Next bar trades in reversal direction or price rejects/reclaims the edge.

**Invalidation:** Signal high/low is breached and accepted; no response after configured time/bars.

**Entry:** Confirmed bar-close signal plus next-bar directional trade is the cleanest research version.

**Stop:** Beyond the signal extreme plus buffer.

**A+ upgrade:** meaningful level, prior delta weakening or absorption, small signal bar, compact stop, quick MFE.

**A+ downgrade:** mid-range print, no prior effort, large bar, no quick response.

**Source anchors:** `20260302 - Trading Exhaustion Prints In The Order Flow Using Orderflows Trader [FNPJ2cwnvqY].en.vtt`; `20260517 - Order Flow Exhaustion Entry Model Explained [j3CCN6gYZSs].en.vtt`; `20260528 - Understanding The Order Flow Exhaustion Entry Model Setup [IXCXUMo2iDQ].en.vtt`.

## Setup 2: Absorption-To-Exhaustion Reversal

**Description:** The flagship A+ pattern: absorption appears first, then exhaustion marks the final edge.

**Order-flow story:** Passive buyers/sellers absorb aggressive flow. After the aggressive side cannot force continuation, the next edge prints exhaustion.

**Bullish version:** Sellers hit lows; passive buyers absorb them; selling weakens; exhaustion appears at or near the low; price lifts.

**Bearish version:** Buyers lift highs; passive sellers absorb them; buying weakens or flips; exhaustion appears at or near the high; price drops.

**Required:**

- Absorption evidence: effort without result, delta/close contradiction, repeated passive defense, or aggressive flow stalled at a level.
- Exhaustion evidence at edge.
- Meaningful location.

**Confirmation:** Reversal away from absorbed/exhaustion zone; next bar direction or reclaim/rejection.

**Invalidation:** Price accepts through absorbed zone; fresh aggression expands through the edge.

**Entry:** After the exhaustion/absorption bar closes and price starts moving away. Do not enter just because passive activity is suspected.

**Stop:** Beyond the absorbed/exhaustion extreme.

**A+ upgrade:** absorption and exhaustion agree, delta weakens into the edge, stop is tight, response is immediate.

**A+ downgrade:** absorption is guessed from one ambiguous candle, no exhaustion, or level is poor.

**Source anchors:** `20260511 - My Favorite Order Flow Entry Model for ES [kDa3_a4Bezk].en.vtt`; `20260515 - My A+ Trade Setup Using Absorption In Order Flow [xIFiALSmUTk].en.vtt`; `20260518 - A+ Setup Order Flow Absorption [Fpjas21x0Xg].en.vtt`.

## Setup 3: Pure Absorption Reversal

**Description:** Aggressive side appears active but fails without requiring a separate exhaustion print.

**Order-flow story:** Market orders hit resting liquidity. Price does not progress. Passive liquidity wins.

**Bullish version:** Negative delta or selling pressure into low/support, but candle holds/closes green/off-low. Passive buyers are absorbing sellers.

**Bearish version:** Positive delta or buying pressure into high/resistance, but candle rejects/closes red/off-high. Passive sellers are absorbing buyers.

**Required:**

- Direct support: negative delta on a green candle can show passive buyers absorbing sellers.
- Direct support: positive delta at resistance can be bearish when no continuation follows.
- Strong location filter.

**Confirmation:** Price moves away from the absorbed zone; opposite delta or opposite close strengthens it.

**Invalidation:** The aggressive side finally gets continuation through the zone.

**Entry:** Rotation away from absorbed level; conservative version waits for a retest failure.

**Stop:** Beyond absorbed level.

**A+ upgrade:** repeated defense, big effort/small result, visible level, no continuation.

**A+ downgrade:** large volume called absorption without proof of failed progress.

**Source anchors:** `20220912 - Absorption In The Order Flow On Moves Up How To See It In The Delta And Imbalances [n9buSk4fTmg].en.vtt`; `20260505 - Green Delta Trap - Why Positive Delta Can Still Be Bearish [i8oUsL2J9nQ].en.vtt`; `20260518 - A+ Setup Order Flow Absorption [Fpjas21x0Xg].en.vtt`.

## Setup 4: Failed Acceptance Reversal

**Description:** Price breaks or sweeps an obvious level but cannot accept outside it.

**Order-flow story:** Stops or breakout orders trade through the level. The market should continue. It does not. The breakout/sweep becomes failure.

**Bullish version:** Price breaks below a low/support/value area, then reclaims it.

**Bearish version:** Price breaks above a high/resistance/value area, then loses it.

**Required:**

- Obvious level.
- Temporary break/sweep.
- Fast reclaim/rejection or no follow-through.

**Confirmation:** Close back inside level, or next bar moves away from the failed extension.

**Invalidation:** Acceptance outside level; retest holds outside and continues.

**Entry:** On reclaim/rejection, not on first tick beyond the level.

**Stop:** Beyond sweep/break extreme.

**A+ upgrade:** emotional break, large delta/volume, immediate reclaim, absorption/exhaustion at edge.

**A+ downgrade:** fading a real trend-day breakout.

**Source anchors:** `20230113 - Order Flow Value Area Strategy Trading Volatile Markets Breaking Out Of Balance [FJ29ObXIUkE].en.vtt`; `20180725 - Orderflows Trader 2 0 For NT7 Prominent POCs Trapped Trader Market Sweeps [tJSzbSMm_Ro].en.vtt`; `20260507 - Order Flow Surrounding The Suspicious Crude Oil Trades [Swcnspl-ACc].en.vtt`.

## Setup 5: Aggressive Delta Trap

**Description:** Strong delta appears to support continuation, but price action proves the aggressive side is trapped.

**Order-flow story:** Buyers lift offers at highs or sellers hit bids at lows. The effort looks strong, but price cannot continue. The aggressive side has provided liquidity to passive players.

**Bullish version:** Strong negative delta at lows fails to push lower; sellers are absorbed and later cover.

**Bearish version:** Strong positive delta at highs fails to push higher; buyers are absorbed and later liquidate.

**Required:**

- High relative delta at a poor location.
- Poor price progress after the delta.
- Level/context filter.

**Confirmation:** Reversal through the aggressive bar/zone.

**Invalidation:** Delta continues and price extends.

**Entry:** After failure is visible. Delta sign alone is not entry.

**Stop:** Beyond the delta-trap extreme.

**A+ upgrade:** strong positive delta at HOD/resistance with red/rejection response; strong negative delta at LOD/support with green/lift response.

**A+ downgrade:** raw delta fade without absorption/no-continuation proof.

**Source anchors:** `20260505 - Green Delta Trap - Why Positive Delta Can Still Be Bearish [i8oUsL2J9nQ].en.vtt`; `20230105 - Cumulative Delta Divergence In Order Flow Ahead Of FED Minutes Release [qCg4RBTU3Z8].en.vtt`.

## Setup 6: Delta Weakness / Divergence Reversal

**Description:** Price retests or makes a new extreme, but delta no longer confirms the move.

**Order-flow story:** Price is still moving to an edge, but aggressive participation is losing force. Effort and result diverge.

**Bullish version:** Lower low with less negative delta, positive delta response, or cumulative delta divergence.

**Bearish version:** Higher high with less positive delta, negative delta response, or cumulative delta divergence.

**Required:**

- Extreme or retest.
- Delta weakening versus prior push.
- Confirmation from price response.

**Confirmation:** Reversal close, reclaim, exhaustion, or absorption.

**Invalidation:** Delta re-accelerates and price extends.

**Entry:** Divergence plus failure confirmation; never divergence alone.

**Stop:** Beyond divergent price extreme.

**A+ upgrade:** divergence at level plus exhaustion/absorption.

**A+ downgrade:** divergence in chop.

**Source anchors:** `20230105 - Cumulative Delta Divergence In Order Flow Ahead Of FED Minutes Release [qCg4RBTU3Z8].en.vtt`; `20230921 - Cumulative Delta Part 2 When Price And Cumulative Delta Diverge [JX2oAcGoTaw].en.vtt`; `20240904 - Delta Price Action Divergence On Orderflows Trader 7 For NinjaTrader 8 Order Flow Trading Strategy [qsVKn0b-Tjw].en.vtt`.

## Setup 7: Imbalance Failure / Inverse Imbalance Reversal

**Description:** Buy/sell imbalances should show initiative. If they appear at an edge and fail, they become reversal evidence.

**Order-flow story:** One-sided aggression stacks or clusters. If price does not continue, that aggression has been absorbed or mistimed.

**Bullish version:** Sell imbalances into lows fail; price reclaims the imbalance zone.

**Bearish version:** Buy imbalances into highs fail; price loses the imbalance zone.

**Required:**

- Imbalance or stacked imbalance at/near level.
- No follow-through.
- Opposite response or zone reclaim.

**Confirmation:** Close/trade through failed imbalance zone.

**Invalidation:** Continuation in imbalance direction.

**Entry:** After imbalance failure, not on imbalance print itself.

**Stop:** Beyond imbalance extreme.

**A+ upgrade:** imbalance failure aligns with absorption/exhaustion.

**A+ downgrade:** fading fresh imbalances on a trend day.

**Source anchors:** `20180720 - Orderflows Analysis Understanding Stacked Imbalances In Order Flow [VRexz_F1LTU].en.vtt`; `20230115 - Orderflows Imbalances A Different And Effective Way Of Using Stacked Imbalances [GbYMh8fappw].en.vtt`; `20240823 - Trading Stacked Imbalances In Volatile Markets Using Orderflows Trader [7mQg03s95Ik].en.vtt`.

## Setup 8: Retest Rejection

**Description:** The second test of a level is weaker than the first and rejects.

**Order-flow story:** The first test creates the reference. The retest shows the attacking side cannot improve.

**Bullish version:** Retest of low/support with weaker selling, absorption, exhaustion, or reclaim.

**Bearish version:** Retest of high/resistance with weaker buying, absorption, exhaustion, or rejection.

**Required:**

- Clean first level.
- Retest within tolerance.
- Weaker order flow on retest.

**Confirmation:** Rejection bar or next-bar directional move.

**Invalidation:** Retest accepts through the level.

**Entry:** Retest rejection, not blind level touch.

**Stop:** Beyond retest extreme.

**A+ upgrade:** retest has weaker delta plus exhaustion/absorption and immediate response.

**A+ downgrade:** level has been tested too many times or trend context is hostile.

**Source anchors:** `20230116 - How To Get The Most Out Of The Reversal Scalper For NT8 Analyze Order Flow For Reversals [R7lxd14t4Oc].en.vtt`; `20260511 - My Favorite Order Flow Entry Model for ES [kDa3_a4Bezk].en.vtt`.

## Setup 9: Climactic Volume Failure

**Description:** Very large volume at an extreme is only useful after it fails.

**Order-flow story:** Late activity or stops hit at an edge. If price cannot continue after the volume, the event can become reversal fuel.

**Bullish version:** Large selling volume at lows fails and price reclaims.

**Bearish version:** Large buying volume at highs fails and price rejects.

**Required:**

- Volume spike at an edge.
- Failure/no continuation after the spike.
- Context filter.

**Confirmation:** Post-spike rejection/rotation.

**Invalidation:** Spike initiates continuation.

**Entry:** Only after failure. Never enter from size alone.

**A+ upgrade:** volume climax plus absorption/exhaustion at known level.

**A+ downgrade:** news/trend impulse with no failure.

**Source anchors:** `20230118 - Big Volume In The Order Flow How To Interpret It And Trade It Orderflows Trading Strategy [SDz56_uVduQ].en.vtt`; `20230924 - Stopping Volume In The Order Flow Using Orderflows Trader [RtAq1Xa1fPc].en.vtt`; `20250311 - Stopping Volume In The Footprint With Orderflows Trader 8 [vxtEsl0EDIc].en.vtt`.

## Non-Negotiable Invalidation Themes

- Signal extreme breaks and accepts.
- Expected quick response does not happen.
- Fresh initiative appears in the original direction.
- Context changes from failure to acceptance.
- Stop distance is too large for the expected first target.

## Practical Ranking

1. Exhaustion at edge with absorption/delta weakness.
2. Pure absorption at level.
3. Failed acceptance/reclaim at obvious level.
4. Delta trap/divergence with level confirmation.
5. Retest rejection.
6. Imbalance failure.
7. Stop-run/sweep.
8. Climactic volume failure.

The first three should be built and tested before lower-confidence modules.

