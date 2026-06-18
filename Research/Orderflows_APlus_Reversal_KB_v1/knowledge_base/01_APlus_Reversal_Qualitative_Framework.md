# A+ Reversal Qualitative Framework (KPI 1)

**Subject:** Michael "Mike" Valtos (Orderflows). **Evidence base:** 33 of 115 transcript chunks extracted = **all 17 T1 teaching chunks + 16 T2 live-application chunks spanning 2016→2026** (structured extractions in `../chunk_extractions/`). The remaining 82 chunks are lower-tier live recaps / product videos (see ledger); the model is redundantly encoded, so this framework is well-supported, with single-source items flagged.

> Evidence tags: `[REPEATED]` many videos · `[ONCE]` single mention · `[SPECULATIVE]` our inference · `[FORCED]` qualitative idea tightened into a number/binary. `NEEDS-OP` = he deliberately keeps it qualitative. Citations: `(ChNNN / v#, [mm:ss])`.

This file extracts his **model of A+ reversals** — not a video summary. It answers: what setups he teaches, the order-flow story/psychology, how he grades them, and what makes one A+ versus mediocre.

---

## 0. The one-paragraph model
A reversal is the moment **"the last buyer has bought or the last seller has sold."** Price pushes to an extreme; the aggressive side that was *moving* price runs out of ammunition; their aggression goes **silent**; with nothing left to push the move, price "naturally moves back the opposite direction." You do **not** predict the turn — you **read exhaustion/absorption at a location, then let the market confirm it by trading back through the signal bar**, and you get paid quickly or get out. (Ch016/v485 [00:27]; Ch017/v492 [16:38]; Ch001/v4 [00:33]) `[REPEATED — the spine of everything]`

Every setup below is a variation on, or confirmation of, that single idea.

---

## 1. His grading / tiering system

He does **not** use a rigid letter scale in the *videos* (his software and the repo's `Reversal_Hunter` do — §1b). He grades with a **consistent verbal ladder**, and the *words* matter less than the **discriminators** that move a setup up/down (§2). Capture both.

### 1a. The verbal ladder (verbatim, highest → lowest)

| Tier | His words (verbatim) | What earns it |
|---|---|---|
| **A+ / elite** | "**A+**" (reserved for **value-area absorption**), "**my favorite**" / "favorite favorite favorite", "**picture-perfect**", "**classic textbook**", "**perfect / looked perfect**", "**the move you want**", "**gold signal**", "**French kiss**" (the turn print), "**no-brainer**", "**burned into my brain / automatic trade**", "**yum yum**" | Confluence at a clean swing extreme that **works immediately** with little/no drawdown |
| **Great / strong** | "**beautiful**", "**great**", "**very strong signal**", "**bread and butter**", "**high-percentage**", "**slam dunk**" | A clean instance of a core setup that pays promptly |
| **Good / OK** | "**nice**", "**decent**", "**not bad**", "a move (not a great move) but it's a move" | Valid signal, pays modestly, some drawdown |
| **Mediocre / marginal** | "**half-hearted**", "**borderline**", "**marginal at best**", "**not the greatest**", "**a bit sketch / scared of bars like this**", "**this one's okay**" | Weak follow-through, wide stop, off-location, thin confluence |
| **Skip / no-trade** | "**I wouldn't qualify that as a trade**", "**you shouldn't be taking**", "**Big X**", "**terrible sign**", "**kiss of death**" (next-bar-inside), "no reason / nothing happening" | Fails a required gate (location, follow-through, catalyst) |
| **Failed (post-hoc)** | "**it failed**", "**just went sideways**", "**didn't work**", "**met with a red bar**", "**pearshaped**" | Triggered but invalidated |

> Densest in Ch016 (v483/v485/v487/v490), Ch017 (v492/v498), Ch005, Ch002. `[REPEATED]`

### 1b. Numeric/score tiers he *does* state (software)
- **Liquidity Finder** zone confidence: **70–100% high** (lime/red), **34–69% medium** (orange), **1–33% low** (gray). (Ch017/v499 [04:22]) `[ONCE — exact]`
- **Orderflows Algo** strength: **1 = strongest, 3 = normal, 5 = most liberal**; he trades **3**. (Ch099/v409 [37:35])
- **Imbalancer level 1–6** (2 = default, 6 = strongest); **momentum 0–6**. (Ch015)
- The repo's `Reversal_Hunter_Claude` already uses **A+/A/A-/B+/B/B-/C+/C/C-** → adopt for the new indicator (see file 04).

### 1c. CRITICAL framing caveat (do not over-rigidify)
He repeatedly insists order flow is **"not a red-light/green-light system"** and *"I don't pick reversals, I react."* He explicitly warns that **a high confluence count is a SCREEN, not an automatic trigger** ("6 plots ≠ automatic buy"). (Ch004/v158; Ch085/v284 [26:13]) `[REPEATED]`. A score model (file 02) is a *useful approximation* of how he stacks evidence — present it as such, never as his literal method.

---

## 2. Cross-cutting A+ vs. mediocre discriminators (the master tells)
These recur across **every** setup and are the real grading engine, ordered by emphasis.

1. **LOCATION / position-in-the-move (dominant tell).** Signal must sit **at/within ~1 tick of a clean swing high/low or HOD/LOD, after a genuine prior move.** The identical pattern "in the middle of the move" or after an over-extended run = "**not too interested**"/skip. "What's the point of a delta reversal if it's not reversing anything?" Closer to the extreme = more room = higher tier. (Ch004/v145 [08:08]; Ch011; Ch017/v496 [05:03]; Ch001/v5 [10:16]) `[REPEATED — strongest single discriminator]`
2. **CONFLUENCE — "single signals lie, combinations tell the truth."** A+ = several independent dimensions agreeing at one level (exhaustion print **+** absorption/POC **+** decreasing counter-delta **+** stacked/multiple imbalances **+** clean swing). A lone signal (bare divergence, lone imbalance) = "**recipe for disaster**." But confluence is a screen, not arithmetic (§1c). (Ch102/v471; Ch013/v421; Ch016) `[REPEATED]`
3. **FOLLOW-THROUGH / "let the market take you in."** After the signal bar closes, **one of the next 1–2 bars must trade beyond the signal bar's extreme** in your direction, else **no trade** — even on a perfect print. (Ch016/v490 [03:11]; Ch017/v492 [18:11]; Ch078/v242 [40:07]) `[REPEATED — the gate from pattern → trade]`
4. **SPEED — "the best trades work immediately."** A+ "rips right off the low" with little/no drawdown. Sideways/horizontal = failing. (Ch017/v498 [19:00]; Ch009; Ch016/v483) `[REPEATED]`
5. **CANDLE-COLOR agreement.** Bullish on a **green** bar; bearish on a **red** bar. (Ch017/v497 [06:38]; Ch018/v10 [23:58]) `[REPEATED]`
6. **DELTA behaving correctly** — counter-delta *weakening* into the extreme then *flipping*; or (Green Delta Trap) strong delta that *fails to continue*. Read **intrabar Max/Min delta, not just final** (e.g. Max +623 collapsing to close −212 = reversal). (Ch016/v482 [05:53]; Ch094/v352; Ch028/v48 [08:30]) `[REPEATED]`
7. **ABSORPTION / ABANDONMENT bonus.** Best instances have a prominent POC / value area at the level **not traded back into next bar** ("abandoned" — his "highest confidence / French kiss"). (Ch016/v481 [05:49]; Ch102/v479; Ch094/v355) `[REPEATED]`
8. **CATALYST / away from "unchanged".** Price hugging the open/"unchanged" line = no catalyst = stay out. (Ch016/v487 [09:20]) `[REPEATED]`
9. **STOP feasibility (bar size).** A wide signal bar forces a wide stop → downgrade ("scared of bars like this"). Prefer small bars where a 1-tick stop is feasible. (Ch017/v498 [16:49]) `[REPEATED]`

**A+ = location + confluence + immediate follow-through + clean stop.** Drop one → slides down the ladder; drop location or follow-through → skip.

---

## 3. Setup type catalog
Each uses the requested template. Ordered from his **current flagship** outward. Many share the same engine (exhaustion of aggressors at a level); relationships in `06_Reversal_Setup_Taxonomy.md`. Convention: **bullish = reversal UP off a low; bearish = reversal DOWN off a high** (mirror unless noted).

### 3.1 Order Flow Exhaustion Entry Model ★ (current flagship; "the only entry model you'll ever need")
*Ch016 (v472,481,482,485,487,488,489,490), Ch017 (v492,493,495,496,497,498), Ch103. `[REPEATED]`*
- **Plain English.** Find a bar where the **extreme price traded almost no volume** ("exhaustion print") at a **new swing high/low**, then enter only when the **next bar(s) trade back through** the signal bar.
- **Market context.** Needs a real prior move; clean swing extreme/HOD/LOD; away from "unchanged"/open; reads cleanest in high-volume-at-price markets (bonds/tens/ultra bonds), "harder to see" in NASDAQ. (Ch016/v462 [03:25])
- **Order-flow story / psychology.** Aggressors "run out of ammunition" — "the last seller has sold." Volume thins, aggression goes silent, no new money pushes the move → reversion; last aggressors trapped. (Ch017/v492 [16:38])
- **Bullish.** Tiny-volume print on the **bid/bottom of a GREEN candle** at a new swing low; negative delta **weakening** into the low (−386→−337→−220→−63) then flips positive; ideally bullish prominent POC / buying imbalances.
- **Bearish.** Tiny print on the **offer/top of a RED candle** at a new swing high; positive delta weakening then flipping negative; bearish POC / selling imbalances.
- **Required.** (1) exhaustion print ≤ volume threshold at extreme; (2) new swing high/low over lookback (swing ~25 bars); (3) correct candle color; (4) **next 1–2 bars trade beyond the signal-bar extreme**.
- **Confirming.** Delta flips; imbalances appear in the new direction; absorption (POC/value area) not retraded; immediate move.
- **Invalidation.** Next bar trades **inside** ("kiss of death"); opposite delta reappears; goes **sideways** (~10-min time stop); still hugging "unchanged".
- **Entry.** Signal bar **closes**; buy-stop just above its high (sell-stop just below its low); one of next **2 bars** must fill, else cancel. Never anticipate.
- **Stop.** **1 tick** beyond the print extreme; prefers tight stop + **second-chance re-entry** over widening.
- **After.** Move "right away," little/no drawdown; ES rotations ~10–14 pts = logical exits.
- **Failure modes.** "Residual/leftover" one opposite bar ticks you out then it reverses (re-enter); big signal bar; signal at unchanged/open; sideways chop.
- **A+ vs mediocre.** A+ = exhaustion **following absorption** (POC/value-area not retraded) at a clean swing, delta weakening→flipping, immediate follow-through, small bar/tight stop. Mediocre = lone print, mid-move, big bar, no catalyst, slow reaction.

### 3.2 Exhaustion print / "single print" (building block; also stands alone)
*Ch005, Ch009 (v314), Ch010 (v358), Ch011, Ch014, Ch016/v472. `[REPEATED — his "original and favorite"]`*
- **Plain English.** A **single (or near-single) contract** at the bar extreme while neighbors traded heavily → "no interest" → go-sign.
- **Bullish/bearish.** ≤ threshold at the **bid of a new low / offer of a new high**.
- **Thresholds (market-scaled — see FORCED note, file 02).** ~**1–3** crude/volatile-thin, **5** currencies, **9–10** rates/indices; historically "single digits." (Ch016/v481 [08:26]) `[REPEATED]`
- **A+ vs mediocre.** Needs follow-through + location. One thin print = weak; "3 stacked = much juicier." Graded up by stronger confirming delta after.

### 3.3 Orderflows Ratio + Divergence ("bread and butter / automatic")
*Ch002, Ch003, Ch011, Ch012, Ch102/v471. `[REPEATED]`*
- **Divergence (codifiable).** New/equal **high on negative delta = bearish**; new/equal **low on positive delta = bullish**. (Ch003/v143 [02:22])
- **Ratio (proprietary single-bar number).** **≥ 30 = exhaustion (bounds high)**; **0–0.69 = price defense (bounds low)**. Magnitude **NOT graded** → binary flag (a 406 reads same as a 32). (Ch102/v471 [06:22]; Ch012) `[REPEATED]` *(Note: a 2017 video cited a ratio cutoff ~7 — older tool/definition; see file 19.)*
- **Required.** Divergence + ratio at a swing extreme **+ confirming price action in the bar**; divergence ALONE is insufficient ("recipe for disaster"). (Ch045/v144 [14:26]; Ch012/v395)
- **A+ vs mediocre.** A+ = divergence + ratio + matching prominent POC at the same extreme; mediocre = bare divergence / mid-move.

### 3.4 Delta divergence — per-bar & cumulative
*Ch008, Ch009 (v309), Ch099 (v403), Ch100, Ch101 (v442). `[REPEATED]`*
- **Plain English.** Price makes a new extreme but **(cumulative) delta does not** → distribution/absorption warning.
- **Psychology.** "The easiest place to sell is a rising market" — institutions distribute into strength. (Ch101/v442 [07:14])
- **Nuances.** Cumulative-delta divergence is **confirmation/radar, not a trigger** (Ch008/v296). **3 failed divergences within ~1 hr = TREND day → do NOT fade, trade the breakout.** (Ch009/v312 [04:40]) `[REPEATED — vital FP filter]`
- **Polarity trap.** New lows on **positive** delta = supply absorbing aggressive buyers → still bearish until supply exhausts. (Ch099/v403 [10:34]) `[REPEATED]`

### 3.5 Absorption reversal (incl. ★ A+ Value-Area Absorption)
*Ch005, Ch007 (v269), Ch008 (v296), Ch014, Ch015, Ch016, Ch069 (v213), Ch089 (v310), Ch103. `[REPEATED]`*
- **Plain English.** Aggressive orders hit a **wall of resting liquidity** (iceberg/refreshing size) that soaks them up; once aggression is spent, price reverses.
- **Tells.** **Negative delta on a green candle** (or positive on a red candle); **max delta near 0**; strong counter-delta that **fails to move price** ("−455 and it doesn't go lower"); delta "eaten back" (−4,900→−900); absorption runs ~half the bar then reversal aggression. A big passive bid can make a **negative headline delta bullish** (−677 green bar, 1,038-lot bid). (Ch089/v310 [07:55]; Ch085/v287 [09:12])
- **★ A+ Value-Area Absorption.** Value area drawn (blue=bullish, pink=bearish); **strongest when NOT traded into next bar** ("abandoned"). The setup he explicitly calls **"A+."** (Ch016/v485 [05:04]; Ch103)
- **A+ vs mediocre.** A+ = abandoned value area/POC at a clean swing + exhaustion print; mediocre = absorption read with no follow-through, or value area re-entered next bar.

### 3.6 Stopping-volume reversal
*Ch001, Ch007, Ch011, Ch015 (v452). `[REPEATED]`*
- **Plain English.** A move slams into **heavy volume that halts price** ("brick wall"); when pressure is removed, it reverses.
- **Threshold.** Stopping-Volume tool default **30%**; needs *decent* volume (light = ignore). (Ch015)
- **A+ vs mediocre.** A+ = stopping volume at swing extreme + reversal candle + decreasing volume on each retest; mediocre = light volume/mid-range.

### 3.7 Stacked-imbalance reversal
*Ch001 (v8), Ch004, Ch006 (v176), Ch008, Ch010, Ch012, Ch013. `[REPEATED]`*
- **Imbalance.** Diagonal bid×offer ratio **≥ 4:1 (400%)** default; alts 2.5/3/3.5/**10:1** (10:1 = "pet favorite"); **min volume ~10** (era/liquidity-scaled — 2017 used ~50 on e-mini). (Ch006/v176; Ch028/v48)
- **Stacked = 3+ consecutive** ("three is the magic number").
- **Direction rule.** **Same-color** stack = continuation/weak; **opposite-color** (failed bullish stack then bearish stack within ~5-price zone) = "**quite powerful**" reversal → **go with the SECOND (opposing) imbalance.** (Ch001/v8 [03:59])
- **Decay caveat.** Stacked imbalances are **immediate-term S/R only (~4–5 bars)**, NOT durable — contradicts common belief; "past the fifth bar all bets are off." Must **close beyond** to validate. (Ch018/v13 [09:13]; Ch085/v285 [13:01]) `[REPEATED]`
- **A+ vs mediocre.** A+ = 3+ stacked, high ratio, clean swing, opposite-color/failed-stack, follow-through; mediocre = 1 imbalance, same-color mid-trend, light volume, stale.

### 3.8 Multiple-imbalance reversal
*Ch004, Ch005 (v173), Ch008, Ch061 (v196). `[REPEATED]`*
- **Plain English.** **3+ imbalances spread out (non-consecutive) in one bar** — "just as important, if not more, than stacked" because they fire **earlier** (~3 pts earlier; hidden big-trader aggression in waves). (Ch061/v196 [31:09]) Same ratio/min-vol/location/confirmation rules as stacked.

### 3.9 Inverse-imbalance / trapped-trader reversal
*Ch006 (v176), Ch007 (v280), Ch008 (v289), Ch010 (v340), Ch013, Ch078 (v242), Ch085. `[REPEATED]`*
- **Plain English.** **Buying imbalances inside a RED candle**, or **selling imbalances inside a GREEN candle** = aggressors trading **into** absorption and getting trapped (= absorption tell; green+neg delta is *bullish*).
- **Contrarian nuance.** The trapped cohort is **often SMALL** ("31 is nothing vs 1,800") — a **shift signal, not squeeze fuel**. He **rejects** "big wick = trapped" and "stop run" framing; trapped traders **signal liquidity drying up**, they don't cause the reversal. (Ch013/v425; Ch078/v242 [33:14]; Ch006/v176) `[REPEATED]`
- **Two look-alikes.** Stop-sweep (already flat, not trapped) vs limit-absorption (real longs who must puke). (Ch007/v280)
- **Entry.** A tick beyond the bar — only if the next bar trades **away**, not back in. (Ch010/v340)

### 3.10 Delta surge & ★ Market Strength / Weakness
*Ch002, Ch005 (v172), Ch011, Ch012, Ch069 (v213), Ch089 (v308). `[REPEATED]` — "market strength/weakness in context" is a STARRED favorite.*
- **Delta surge.** **4 bars of monotonically increasing delta magnitude → enter on the 4th.** (Ch005/v172 [35:04])
- **Delta/Market weakness.** **≥3 consecutive bars of weakening |delta| (same sign) at an extreme** ("water pressure dying out"). (Ch011/v371 [09:32])
- **Strength quantified.** Final delta within **95% of max/min delta** = "strong"; **delta/volume > 25%** = strong (normal 5–15%); cyan = strong positive, magenta = strong negative, white = no aggression. (Ch089/v308 [13:24]; Ch094/v350)
- **A+ tell.** Strength at/near a swing low (weakness at a swing high) — location elevates it. "That's why I put the star." (Ch089/v308 [57:22])

### 3.11 POC-on-extreme / Prominent POC reversal
*Ch002 (v80), Ch003, Ch007, Ch061 (v196), Ch094, Ch095 (v365). `[REPEATED]`*
- **Plain English.** Bar's **max-volume price (POC) at the bar high/low**, that bar is the day extreme, + a ratio. Bullish POC aqua/cyan near bottom; bearish magenta/pink near top.
- **Validity.** PPOC = "**line in the sand**"; must be **untested in the next bar** to be tradeable; invalidated if breached. POC-on-extreme "obsolete on e-mini" → use Prominent POC. (Ch061/v196 [54:33]; Ch094/v347; Ch007)

### 3.12 Abandoned value-area / POC ("French kiss / gold signal")
*Ch016, Ch094 (v355), Ch097, Ch100 (v420), Ch102 (v479), Ch103. `[REPEATED]`*
- **Plain English.** After the signal, the **value area AND POC are NOT traded back into on the very next bar** ("abandoned"). "Best imbalances don't get traded back into immediately." Two consecutive abandoned value areas = "a strong sign."
- **Grade.** "Highest confidence / favorite / French kiss"; abandoned **open** POC = "high-percentage." Long at swing low / short at swing high; target prior overhead value areas.

### 3.13 Failed signal / "when the market defies you" / holding-vs-failing
*Ch001, Ch013 (v428), Ch069 (v213), Ch100 (v415). `[REPEATED]`*
- **Plain English.** A signal that **fails becomes a signal the other way** — "go with what is happening." A stacked sell imbalance the market ignores → go long.
- **Holding-vs-failing.** Same big fresh bid: **HOLD = reversal up; traded-through-fast = continuation down.** (Ch013/v428 [01:53])
- **Invalidation→flip.** Building volume **above a prior POC** flips it resistance→support. (Ch018/v1 [11:26])

### 3.14 Green Delta Trap (counter-intuitive)
*Ch016/v478, Ch101/v442, Ch097. `[REPEATED]`*
- **Plain English.** **Strong POSITIVE delta at a high with no continuation = bearish** — buyers lifted into resting liquidity that absorbed them; "just because buyers are aggressive doesn't mean they're winning." Mirror at lows.

### 3.15 Price Rejector 4-factor reversal (2016 foundational — historical root)
*Ch001 (v3,v4). `[REPEATED in era]`*
- **Plain English.** His original codified reversal: **(1) a move already occurred + (2) volume decreasing + (3) opposite price action + (4) a market imbalance present.** Fair → unfair price → rejection.
- **Why it matters.** The 2016 definition is the **same engine** as the 2026 Exhaustion Model — evidence the model is stable across a decade.

---

## 4. Common failure modes (all setups)
1. **No follow-through** — prints but next 1–2 bars don't extend ("kiss of death").
2. **Wrong location** — mid-move / not a clean swing.
3. **Trend day** — fading repeated divergences/exhaustion on a one-way day (3 failed divergences in ~1 hr).
4. **No catalyst** — at "unchanged"/open; thin/holiday session.
5. **Big signal bar** — stop too wide.
6. **Lone signal** — single imbalance / bare divergence, no confluence.
7. **Stale level** — imbalance/zone older than ~5 bars treated as live.
8. **Polarity misread** — positive delta at a low assumed bullish when supply is absorbing.
9. **Chart-construction artifact** — signal exists only because of bar type (see file 19).

---

## 5. Guard-rails for the modeler (he is emphatic)
- "**Not a red-light/green-light system**" — react, don't predict; confluence is a screen, not arithmetic. (Ch004; Ch085/v284) `[REPEATED]`
- Thresholds are **market/liquidity-specific**, NOT universal; he refuses to hard-code (the ~1-hr window, "big delta", min-volume drifting 50→10 across eras). (Ch016/v481; Ch011; Ch028) `[REPEATED]`
- A single **stop-out does not invalidate the read** — second-chance re-entry if "nothing changed in the order flow." (Ch016/v481 [06:19]) `[REPEATED]`
- Order flow **does not catch every turn**; quiet ("few exhaustion prints") = normal — pivot markets, don't force. (Ch016/v481 [04:08])

→ See `02_..._Operational_Model.md` for measurable translations + the **[FORCED] revisit list**, and `19_Open_Questions_and_Contradictions.md` for tensions.
