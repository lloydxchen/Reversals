#!/usr/bin/env python3
"""
Validate ImbalanceReversal_Claude_v1 signals exported from NinjaTrader.

Usage:
    python validate_imbalance_signals.py [path_to_signals.csv]

If no path is given, it picks the most recent ImbalanceReversal_*_signals.csv
under the default export folder or the current directory.

IMPORTANT CAVEATS (read before trusting any number):
  1. ORDERING IS UNKNOWN. The export gives MFE and MAE extremes over the
     lookahead window but NOT which happened first. So "win = MFE>=target AND
     MAE<=stop" is an OPTIMISTIC upper bound (it assumes you weren't stopped
     before the target). A true triple-barrier label needs the intrabar path
     (use the 1-min or footprint series). Treat these as a screen, not truth.
  2. RIGHT-CENSORING. Rows with LookaheadComplete==0 didn't have a full forward
     window. By default they're excluded from outcome stats.
  3. NO COSTS. Add commission + slippage before believing any edge.
  4. SMALL SAMPLE. With a couple months of data, segment counts get thin fast.
     A high hit-rate on 6 signals is noise.
"""
from __future__ import annotations

import sys
import glob
import os
from pathlib import Path

import numpy as np
import pandas as pd

# --- Tunable evaluation thresholds (points). Set to your real stop/target. ---
TARGET_POINTS = 20.0   # favorable move that counts as a "hit"
STOP_POINTS   = 15.0   # adverse move that counts as "stopped"


def find_latest_csv(arg: str | None) -> Path:
    if arg:
        p = Path(arg)
        if not p.exists():
            sys.exit(f"File not found: {p}")
        return p
    candidates: list[str] = []
    search_dirs = [
        os.path.join(os.path.expanduser("~"), "Documents", "NinjaTrader 8", "ImbalanceReversal Exports"),
        ".",
    ]
    for d in search_dirs:
        candidates.extend(glob.glob(os.path.join(d, "ImbalanceReversal_*_signals.csv")))
    if not candidates:
        sys.exit("No ImbalanceReversal_*_signals.csv found. Pass a path explicitly.")
    latest = max(candidates, key=os.path.getmtime)
    return Path(latest)


def summarize(df: pd.DataFrame, label: str) -> dict:
    n = len(df)
    if n == 0:
        return {"segment": label, "n": 0}
    hit  = (df["MfePoints"] >= TARGET_POINTS)
    stop = (df["MaePoints"] >= STOP_POINTS)
    clean = hit & ~stop  # optimistic: reached target and never breached stop extreme
    return {
        "segment": label,
        "n": n,
        "hit_rate(MFE>=%g)" % TARGET_POINTS: round(hit.mean(), 3),
        "stopped(MAE>=%g)" % STOP_POINTS: round(stop.mean(), 3),
        "clean_win(opt.)": round(clean.mean(), 3),
        "MFE_med": round(df["MfePoints"].median(), 1),
        "MAE_med": round(df["MaePoints"].median(), 1),
        "R_med": round(df["RMultiple"].replace([np.inf, -np.inf], np.nan).median(), 2),
        "MFE_bars_med": int(df["MfeBarsToHit"].median()),
    }


def main() -> int:
    path = find_latest_csv(sys.argv[1] if len(sys.argv) > 1 else None)
    print(f"Loading: {path}\n")
    df = pd.read_csv(path)

    total = len(df)
    complete = df[df["LookaheadComplete"] == 1].copy()
    print(f"Signals total: {total}   |   with full lookahead window: {len(complete)} "
          f"(excluding {total - len(complete)} right-censored)\n")
    print(f"Evaluation thresholds: TARGET={TARGET_POINTS} pts, STOP={STOP_POINTS} pts "
          f"(edit at top of script)\n")

    rows = []
    rows.append(summarize(complete, "ALL"))
    for d in ("Long", "Short"):
        rows.append(summarize(complete[complete["Direction"] == d], f"  {d}"))

    # Condition on stacked-run strength (the imbalance 'conviction').
    if "StackRun" in complete.columns and len(complete):
        runs = sorted(complete["StackRun"].unique())
        for r in runs:
            rows.append(summarize(complete[complete["StackRun"] == r], f"  StackRun={r}"))

    # Condition on rejection strength (CloseLocation): does a stronger failure close help?
    if "CloseLocation" in complete.columns and len(complete):
        # For shorts, weak close (low CloseLocation) is the rejection; for longs, high CloseLocation.
        longs  = complete[complete["Direction"] == "Long"]
        shorts = complete[complete["Direction"] == "Short"]
        rows.append(summarize(shorts[shorts["CloseLocation"] <= 0.25], "  Short close<=0.25 (strong rej)"))
        rows.append(summarize(longs[longs["CloseLocation"] >= 0.75],  "  Long  close>=0.75 (strong rej)"))

    out = pd.DataFrame([r for r in rows if r.get("n", 0) > 0])
    with pd.option_context("display.max_columns", None, "display.width", 200):
        print(out.to_string(index=False))

    print("\nReminder: 'clean_win(opt.)' ignores stop/target ordering and is an UPPER BOUND. "
          "For a real edge estimate, rebuild the label from intrabar path data and subtract costs.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
