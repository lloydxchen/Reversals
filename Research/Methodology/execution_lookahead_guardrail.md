# Execution Lookahead — Post-Mortem & Reusable Guardrail

**One-line summary:** The HVN/LVN traverse looked like a +10 pts/trade edge but was invalid.
The entry filled at a price (the volume node) that was only knowable to be a *good* entry
*after* the bar closed — i.e. the fill used information that did not exist yet at the fill
moment. Fixed, the edge flipped to **negative**. This is a fill / execution lookahead bug.

---

## 1. The bug, exactly

The traverse entered an upside break like this (paraphrased from the code):

```python
# DECISION used the bar's CLOSE:
if C[t-1] <= node and C[t] > node + 2:      # only "take" the trade if the bar
                                            # CLOSED decisively above the node
    entry = node + 0.5                      # but FILL back at the NODE price
    stop  = node - 20
    target = next_node_above
    # ... then walk forward for stop/target ...
```

Two pieces of information are in conflict here:

- The **decision** (`C[t] > node + 2`) uses the bar's **close** — known only at the *end* of bar `t`.
- The **fill** (`entry = node`) is a price that occurred *earlier* in that same bar — price had
  to pass *up through* the node on its way to closing above `node + 2`.

So the backtest filled at the node on the **assumption the bar would close strong**, using the
close (end-of-bar info) to justify a fill that happened before the close existed. No real order
can do that.

## 2. Why it inflated the results (three ways to see the same flaw)

1. **Information-timing violation.** At the instant a real resting order would fill (when price
   *touches* the node, mid-bar), you do **not** know the bar will close above `node + 2`. You
   cannot place an order whose *fill price* is the node but whose *existence* depends on a close
   that hasn't happened.

2. **Cherry-picking by omission (survivorship).** Requiring `C[t] > node + 2` silently **deletes
   every failed poke** — where price tags the node (a real resting order *fills* you), then
   reverses, and the bar closes back below. Those are losers a real resting order **cannot
   avoid**. The backtest kept only the breaks that worked and still credited itself the good
   node-price entry on all of them.

3. **Best-of-both-worlds fill.** It took the **good entry price** of a resting order (fill at the
   node) *and* the **good selectivity** of a confirmation strategy (only confirmed breaks). Those
   two are mutually exclusive in reality: a resting order fills on every touch (no selectivity); a
   confirmation order enters at the close (worse price). Mixing them is the cheat.

## 3. The magnitude (proof it mattered)

| Version | Trades/day | Win % | EV/trade | Profit factor | Net |
|---|---|---|---|---|---|
| **As reported (the cheat)** | 27 | 50% | **+10.0** | 1.91 | +3,510 |
| Honest: resting stop at node, fill on **every** touch | 38 | 31% | **−1.7** | 0.89 | −837 |
| Honest: chase — enter at the confirming close | 31 | 33% | **−4.4** | 0.69 | −1,786 |

The honest version produced **more** trades (38 vs 27/day). Those extra ~11/day are exactly the
failed pokes the close-filter was hiding — and they flip the edge from +10 to negative.

---

## 4. Root cause / the general principle

> **The entry trigger and the fill price must both be knowable at the same instant, and that
> instant must be at or before the fill.**

The canonical form of this bug: **deciding to enter based on a bar's CLOSE (or high/low, or any
end-of-bar value) while filling at an INTRABAR price** (the open, a specific level, a node, a
moving-average value, a prior high) that occurred *before* the close. The fill price secretly
depends on information that postdates the fill.

This is a specific case of lookahead bias, often called **fill bias** or **execution lookahead**.

## 5. The correct fixes — pick ONE order model and live with ALL its consequences

For any entry at a specific price *level* (not the bar close), there are exactly two honest models:

**A. Resting order at the level (limit or stop).** Placed *before* price arrives; fills on the
**first touch**, on **every** touch, no matter how the bar closes.
```python
if (Low[t] <= level <= High[t]) and (came_from_correct_side):   # price reached the level
    entry = level + slippage          # or Open[t] + slippage if the bar GAPPED past the level
    # NO close-confirmation filter allowed — you can't condition a resting order on a future close.
    # You MUST include every fill: failed pokes, instant reversals, all of them.
```
Gives the good price, but you eat every bad fill. *This is what the traverse should have done.*

**B. Confirmation, then market entry (the "chase").** Wait for the bar to CLOSE confirming the
signal, *then* enter at market — which realistically fills at the **next bar's open**.
```python
if C[t] > level + buffer:             # confirmed at the close of bar t
    entry = Open[t+1] + slippage      # you MISSED the level; price is already past it
                                      # (filling at C[t] is the optimistic limit)
```
Gives the selectivity, but the worse price.

**You may not combine A's fill price with B's selectivity.** That combination is the bug.

*(A fiddly third option — confirm, then rest a limit back at the level — is only honest if you
(a) count fills ONLY when price actually retests the level after the close, and (b) treat breaks
that run away without retesting as MISSES, not fills. The traverse assumed a fill on every
confirmed break including the runners that never came back — the same cheat in a different costume.)*

---

## 6. Detection checklist — run this on every entry, every project

1. **The fill-timing question (decisive).** *"At the exact price and instant I fill, do I already
   know this trade qualifies?"* If the trigger uses any data from after the fill moment — the
   close when filling intrabar, the high/low when filling at the open — it is invalid.

2. **The stress test that catches it.** Re-run the backtest and compare:
   - (a) Force entry to the **next bar's open** (strictly available, no timing ambiguity).
   - (b) Use the **honest version** of whatever order type you claim (resting → fill every touch,
     no close filter; chase → fill at next open).
   - If the edge survives both ≈ unchanged → fill is honest. If it **collapses or flips sign**
     (like +10 → −1.7) → you had a fill cheat. *This exact test exposed the HVN bug and confirmed
     the absorption reversal was clean (its next-open PF 2.64 ≈ close PF 2.77).*

3. **The trade-count test.** If the honest version has **more** trades than your reported version,
   the extra ones are trades your filter secretly excluded. Ask: could I have excluded them in
   real time? If not, you cheated by omission.

4. **Separate decision price from fill price in code.** Make the fill price an explicit input and
   the trigger an explicit boolean. Verify they read the same bar's data and that
   `fill_price` is reachable from where price was *at the trigger instant*.

5. **Within-bar ties must be pessimistic.** When both stop and target sit inside one bar's range,
   assume the **loss** (stop first). The HVN bug had the opposite spirit.

6. **One assumption should never swing everything.** If the result goes from breakeven to
   +12/trade purely by changing the fill model, that's the alarm. A robust edge does not depend
   on the fill being idealized.

## 7. Red-flag smell tests (be suspicious when…)

- The entry price is a **structural level** (node, MA, prior high, VWAP) rather than an actually
  traded price (the close, or the next open).
- The strategy "waits for confirmation" but "enters at the level."
- A **breakout / momentum** strategy shows a high win rate or PF to a *far* target (real breakouts
  are noisy; 50%+ reaching a distant target is suspicious).
- The honest fill produces **more** trades than the tested version.
- A **tight stop next to the entry level** — the same chop that triggers the entry tends to tag a
  stop placed right at the level, so an idealized fill that dodges it is doing a lot of work.

## 8. Related lookahead cousins to also check (same family, different spot)

- **Signal lookahead:** features computed with future data — un-shifted rolling stats, repainting
  indicators, using a bar's own close inside a "prior" calculation. Fix: shift trailing windows so
  bar `t`'s signal uses only bars `≤ t` (and shift again if the value itself shouldn't include `t`).
- **Normalization lookahead:** z-scoring / scaling with stats (mean, std, min, max) computed over a
  window that includes future bars.
- **Label lookahead:** training or *selecting* on hindsight-optimal labels (e.g. "optimal entry").
  Fine for *studying* structure; never let the tradeable signal depend on them — judge the signal
  by forward outcomes under a real stop, label-free.
- **Selection/survivorship:** filtering trades on their *outcome* (keeping the winners). The HVN
  bug was a sneaky version of this — it filtered on the *bar's* outcome (did it close strong).

---

### The summary you actually need to remember

**A backtest fill is only valid if everything used to justify it — the trigger AND the price —
was knowable at or before the moment of the fill. If your entry price is better than what was
available the instant your trigger fired, you are looking forward. Test it by forcing the entry
to the next bar's open and by using the honest version of your order type; if the edge dies, it
was never there.**
