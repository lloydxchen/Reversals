#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Create the knowledge_base/ skeleton files (Phase 3) and the extraction ledger.

Each file is created with a title + the section scaffold that the synthesis
phases (4-8) will fill. Existing filled files are NOT overwritten unless --force.
"""
import sys
from pathlib import Path

BASE = Path(__file__).resolve().parent.parent
KB = BASE / "knowledge_base"
EXTRACT = BASE / "chunk_extractions"
KB.mkdir(parents=True, exist_ok=True)
EXTRACT.mkdir(parents=True, exist_ok=True)

FORCE = "--force" in sys.argv

CONV = (
    "> Evidence tags: `[REPEATED]` many videos · `[ONCE]` single mention · "
    "`[SPECULATIVE]` our inference · `[FORCED]` qualitative idea tightened into a "
    "number/binary (revisit first if the model breaks). Cite `(video #, title, [mm:ss])`.\n"
)

# filename -> (title, [section headers])
FILES = {
    "00_Master_Index.md": (
        "Master Index — Orderflows A+ Reversal KB",
        ["How to use this KB", "The three KPIs", "File map (00-19)",
         "Reading order", "Status & coverage", "Glossary of his vocabulary"],
    ),
    "01_APlus_Reversal_Qualitative_Framework.md": (
        "A+ Reversal Qualitative Framework (KPI 1)",
        ["Overview: his reversal philosophy", "His grading / tiering system",
         "Setup type catalog (per-type template below)", "Cross-cutting A+ vs mediocre tells",
         "Common failure modes"],
    ),
    "02_APlus_Reversal_Operational_Model.md": (
        "A+ Reversal Operational Model (KPI 2)",
        ["Measurable variable dictionary", "Per-setup operationalization",
         "Scoring model", "Confirmation logic", "Invalidation logic",
         "False-positive filters", "What we FORCED (revisit list)", "Open quant questions"],
    ),
    "04_NinjaTrader_APlus_Reversal_Indicator_Spec.md": (
        "NinjaTrader A+ Reversal Indicator Spec (KPI 3)",
        ["Indicator purpose", "Required & optional data series",
         "Order Flow / Volumetric requirements", "Core signal architecture",
         "Bullish signal logic", "Bearish signal logic", "Scoring & grades (A+/A/B/C)",
         "Context / session / volatility filters", "Exhaustion / absorption / trap / failed-continuation modules",
         "Confirmation & invalidation", "Repainting & intrabar concerns",
         "Alerts", "Visual output (labels/arrows/zones/dashboard)",
         "CSV export fields", "Backtesting fields", "Input parameters & smart defaults",
         "Known limitations & implementation risks"],
    ),
    "05_Order_Flow_Principles.md": ("Order Flow Principles", ["Core principles", "His mental model of why reversals happen"]),
    "06_Reversal_Setup_Taxonomy.md": ("Reversal Setup Taxonomy", ["Setup map", "Relationships between setups"]),
    "07_Exhaustion.md": ("Exhaustion", ["Definition (his words)", "Tells", "Operationalization", "Failure modes"]),
    "08_Absorption.md": ("Absorption", ["Definition (his words)", "Tells", "Operationalization", "Failure modes"]),
    "09_Stacked_Imbalances.md": ("Stacked Imbalances", ["Definition (his words)", "Tells", "Operationalization", "Failure modes"]),
    "10_Delta_Divergence.md": ("Delta Divergence", ["Definition (his words)", "Tells", "Operationalization", "Failure modes"]),
    "11_Failed_Breakouts_Stop_Runs.md": ("Failed Breakouts & Stop Runs", ["Definition (his words)", "Tells", "Operationalization", "Failure modes"]),
    "12_Trapped_Traders.md": ("Trapped Traders", ["Definition (his words)", "Tells", "Operationalization", "Failure modes"]),
    "13_Entry_Triggers.md": ("Entry Triggers", ["Trigger catalog", "Timing", "Operationalization"]),
    "14_Confirmation_and_Invalidation.md": ("Confirmation & Invalidation", ["What should happen fast", "What must NOT happen", "Operationalization"]),
    "15_Stop_Management_and_Risk.md": ("Stop Management & Risk", ["Stop placement", "Targets / management", "Risk sizing"]),
    "16_Context_Filters.md": ("Context Filters", ["Session/time", "Levels (VWAP/VA/POC/PDH-PDL)", "Regime/volatility", "News"]),
    "17_Feature_Engineering_Dictionary.md": ("Feature Engineering Dictionary", ["Feature table (name, definition, data, formula sketch, mapping quality)"]),
    "18_Transcript_Evidence_Map.md": ("Transcript Evidence Map", ["Concept → source videos/timestamps map"]),
    "19_Open_Questions_and_Contradictions.md": ("Open Questions & Contradictions", ["Contradictions", "Single-source claims", "Things needing backtest", "Ambiguities"]),
}


def write(path: Path, body: str):
    if path.exists() and not FORCE:
        print(f"skip (exists): {path.name}")
        return
    path.write_text(body, encoding="utf-8")
    print(f"wrote: {path.name}")


for fname, (title, sections) in FILES.items():
    p = KB / fname
    lines = [f"# {title}", "", "**STATUS: skeleton — to be filled in Phases 4–8.**", "", CONV, ""]
    for s in sections:
        lines += [f"## {s}", "", "_TODO_", ""]
    write(p, "\n".join(lines).rstrip() + "\n")

# CSV deliverable (03) — header row only at skeleton stage.
csv_path = KB / "03_APlus_Reversal_Testable_Hypotheses.csv"
if not csv_path.exists() or FORCE:
    header = ("hypothesis_id,setup_type,qualitative_claim,bullish_rule,bearish_rule,"
              "required_data,feature_columns_needed,candidate_thresholds,confirmation_rule,"
              "invalidation_rule,expected_edge,priority_score_1_to_5,"
              "implementation_difficulty_1_to_5,evidence_strength_from_transcripts_1_to_5,"
              "source_files,notes\n")
    csv_path.write_text(header, encoding="utf-8")
    print("wrote: 03_APlus_Reversal_Testable_Hypotheses.csv (header)")
else:
    print("skip (exists): 03_APlus_Reversal_Testable_Hypotheses.csv")

print("Skeleton done.")
