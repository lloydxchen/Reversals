# Entry Triggers

Supports KPI 1/2/3. The exact "go" event. His entry method is remarkably consistent for a decade.

## The universal trigger: "let the market take you in"
- The signal/exhaustion bar must **CLOSE** (confirms the print). Then place a **buy-stop just above the signal-bar high** (bullish) / **sell-stop just below the low** (bearish). **One of the next 1–2 bars must trade through that level** or **there is no trade**. (Ch016/v490 [03:11]; Ch017/v492 [05:55], [18:11]; Ch078/v242 [40:07]) `[REPEATED — stated in nearly every video]`
- **Never anticipate** — "better to be stopped out than to enter early." If you must err, err on being late, not early. (Ch016/v489 [06:19]) `[REPEATED]`
- His tools encode this as **"2 ticks over 2 bars" (a.k.a. "2-and-2")** — the trade-entry signal shifts one bar to filter bad trades and **does not repaint after bar close**. (Ch006/v220 [1:02:17]; Ch069/v214 [33:12]; Ch015/v449) `[REPEATED]`
- Stop-entry doubles as a regime read: "if it doesn't fill, the market's not taking you in — it's reversing [against you]." (Ch028/v46 [27:13])

## Setup-specific trigger notes
- **Exhaustion / single print:** as above; print on bid-of-green-low / offer-of-red-high.
- **Ratio + divergence:** "automatic as long as the next bar starts trading higher." (Ch012/v395)
- **Stacked/multiple imbalance:** enter on follow-through; for opposing stacks, go with the **second** imbalance; bar must **close beyond** the stack.
- **Inverse imbalance:** a tick beyond the bar, **only if the next bar trades away (not back in).** (Ch010/v340)
- **Delta surge:** enter on the 4th increasing-delta bar.
- **Liquidity Finder (his NT8 tool):** prefers a **close** beyond the "go-zone" trigger line. (Ch017/v499)

## Operationalization (file 02 §4; file 04 §10–11)
- `Buf` = 1 tick; `ConfirmBars` = 2; evaluate on bar close; live = real stop order, research = mark CONFIRMED only after the trigger bar closes (no back-dating → no lookahead).
- Second-chance re-entry allowed once if order flow unchanged.

## What makes a trigger A+
Immediate fill + immediate continuation (little/no drawdown). A trigger that fills then stalls/goes inside = downgrade/void.
