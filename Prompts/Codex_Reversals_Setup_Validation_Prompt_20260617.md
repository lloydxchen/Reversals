# Codex Reversals Setup Validation Prompt — 2026-06-17

Use this prompt in the Codex app before asking Codex to edit NinjaTrader indicator code.

Purpose: confirm that Codex can read the Reversals project rules and the canonical NinjaTrader documentation in `trading-system-hq`, then produce a safe workflow summary before any code changes.

## Ready-to-copy prompt

```text
Read Reversals/AGENTS.md.

Then verify that you can access the canonical NinjaTrader docs in:
trading-system-hq/NinjaTrader/README_FOR_AI_AGENTS.md
trading-system-hq/NinjaTrader/AI_RULES_QUICKSTART.md
trading-system-hq/NinjaTrader/OFFICIAL_NT_REFERENCE_USAGE.md
trading-system-hq/NinjaTrader/BUGS_AND_SOLUTIONS_ANTHOLOGY.md
trading-system-hq/NinjaTrader/EXPORTER_DESIGN_GUIDE.md
trading-system-hq/NinjaTrader/VISUAL_STYLE_GUIDE.md

Do not edit code yet.

First, summarize:
1. What repo-specific rules apply to Reversals.
2. What canonical NinjaTrader rules you found in trading-system-hq.
3. Whether any referenced files are missing or inaccessible.
4. The correct workflow for future NinjaTrader indicator edits in this repo.
5. Any setup problems I should fix before asking you to code.
```

## Optional next prompt after Codex confirms access

Use this only after Codex confirms it can read the Reversals `AGENTS.md` file and the canonical NinjaTrader docs.

```text
/plan

Read Reversals/AGENTS.md and the relevant NinjaTrader docs from trading-system-hq.

I want to start with a small safe NinjaTrader indicator workflow test. Do not edit code yet.

Inspect the Reversals repo structure and recommend where NinjaTrader indicator source files, compile error exports, methodology docs, and Flow42/exporter notes should live. Keep trading-system-hq as the canonical reusable NinjaTrader docs. Do not duplicate those docs into Reversals.

Give me the smallest clean folder/setup plan before any coding begins.
```

## Important guardrail

Do not ask Codex to improve everything or refactor broadly yet. The first pass is only a setup/access validation pass. After that, use Plan Mode for a small, bounded task.