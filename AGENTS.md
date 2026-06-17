# AGENTS.md — Reversals Project

This repo is for reversal-model research, NinjaTrader indicator work, Flow42/exporter experiments, and validation artifacts.

This file is intentionally short. It is a project-specific adapter, not a fork of the broader NinjaTrader AI documentation.

## Canonical NinjaTrader docs

Use the canonical NinjaTrader AI-agent documentation from:

`trading-system-hq/NinjaTrader/README_FOR_AI_AGENTS.md`

Then use the relevant supporting docs from that same folder:

- `AI_RULES_QUICKSTART.md`
- `OFFICIAL_NT_REFERENCE_USAGE.md`
- `BUGS_AND_SOLUTIONS_ANTHOLOGY.md`
- `EXPORTER_DESIGN_GUIDE.md`
- `VISUAL_STYLE_GUIDE.md`
- `VISUAL_DASHBOARD_AND_LABEL_PATTERN_LIBRARY.md`
- `PROMPTS_AND_WORKFLOWS.md`

Do not copy or fork those general NinjaTrader rules into this repo unless the user explicitly asks. Keep `trading-system-hq/NinjaTrader` as the source of truth for reusable NinjaTrader coding rules.

If this Codex workspace does not include `trading-system-hq`, do not pretend those docs were read. Either use the GitHub connector/plugin to fetch the exact files, ask the user to attach/open the sibling repo, or proceed only with the local Reversals-specific rules and state the limitation.

## Official NinjaTrader reference rule

Do not rely on model memory for non-trivial NinjaTrader API behavior. For new or fragile NinjaTrader mechanics, do targeted reference lookup before coding.

Preferred lookup order:

1. Search the fast text companion: `NinjaTrader8GuideManualtxtversion.txt`.
2. Verify against `NinjaTrader8_Guide_Manual_Official.pdf` when TXT extraction is unclear, incomplete, badly formatted, or signature/example-sensitive.
3. Use curated/condensed NinjaTrader reference notes only as a convenience layer, not as the canonical source.

Do not read the whole manual every time. Search exact concepts such as `OnStateChange`, `AddVolumetric`, `Draw.Text`, `OnRender`, `ChartScale`, `BarsInProgress`, `CurrentBars`, `StreamWriter`, or the specific compile error.

## Condensed Codex reference pack policy

The condensed NinjaTrader Codex reference pack is optional support material, not a permanent fork.

Default rule:

- Do not vendor the full condensed reference pack into `Reversals`.
- Keep reusable NinjaTrader rules in `trading-system-hq/NinjaTrader`.
- Keep official PDF/TXT references available wherever Codex can search them.
- Use condensed notes only when they reduce context load for a specific coding task.

If a future Codex session cannot access the canonical docs or official manual, a temporary local copy of the condensed pack may be used for that session, but it should not become the authoritative Reversals documentation.

## Reversals-specific mission

This project is not just indicator coding. It is a research system for finding, validating, and documenting intraday reversal setups.

Core priorities:

- avoid fake edges,
- preserve raw evidence,
- preserve signal-generation telemetry,
- separate discovery from model-ready data,
- keep coding changes conservative and versioned,
- keep research methodology documented,
- validate claims with NinjaTrader compile/runtime checks and Python/statistical review.

## Validation hierarchy

Treat these as sources of truth, in order:

1. Actual NinjaTrader compile/runtime behavior.
2. Exported data and telemetry from the indicator/chart.
3. Python/backtest/statistical validation.
4. Methodology documents and experiment notes.
5. AI reasoning or hypotheses.

Do not present an uncompiled NinjaScript edit as compile-verified. If NinjaTrader was not run, say that clearly.

## No fake edge rule

This repo is especially vulnerable to false confidence from bad feature mapping, leakage, or overfit reversals.

Required standards:

- Do not populate model-ready columns using loose keyword or substring matching.
- Blank feature columns are better than wrong filled columns.
- Discovery output is not model-ready data.
- Any feature used for modeling must have a clear source, timing, and mapping-quality status.
- Do not use future information to label or trigger a real-time signal.
- Preserve the exact signal-generation recipe and telemetry whenever testing a setup.
- If a strategy edge depends on lookahead, repainting, future session structure, or post-entry knowledge, flag it immediately.

## Preserve-by-default rule

When editing NinjaTrader indicators, preserve these unless the user explicitly asks to change them:

- signal logic,
- alerts,
- plots,
- public series,
- CSV/export logic,
- dashboard/status logic,
- Telegram or notification logic,
- virtual-trade logic,
- existing settings/defaults,
- output folder structure,
- model-ready column semantics.

Prefer surgical diffs. Do not rewrite an entire indicator for a small settings, UI, or compile fix.

## Versioning and file-delivery rule

Every revised file returned to Lloyd must use a new, distinct filename/version name.

For NinjaTrader indicators:

- filename and public class name must match,
- C# identifiers cannot contain dots; use underscores,
- display strings may use dotted versions,
- be careful with duplicate active version files if global enums/helpers exist,
- if intentionally keeping a stable class name for in-place replacement, say so clearly and still use a unique delivery/archive name.

## NinjaTrader folder and namespace rule

Physical folder and NinjaTrader picker folder are separate concepts.

For exporter/data-capture indicators, default to:

- physical folder: `Documents\NinjaTrader 8\bin\Custom\Indicators\Exporters\`
- namespace: `NinjaTrader.NinjaScript.Indicators.Exporters`
- export base folder: `Documents\NinjaTrader 8\NinjaTrader 8 - Chart Data Exports\`

Property enums used by NinjaTrader-generated accessors may need to stay at global scope above the namespace.

## Flow42/exporter rules

For Flow42, data-capture, and exporter work:

- default to fast/safe presets,
- make heavy raw exports opt-in,
- cap bars/rows/draw objects when practical,
- keep inventory/discovery separate from model-ready export,
- use strict known-output maps for model-ready columns,
- use `DeepDiscovery_Safe` for sampled/capped exploration,
- use `DeepDiscovery_PrivateFieldNamesOnly` for private metadata awareness only,
- do not read private field values by default,
- every preset must finalize cleanly,
- dashboard/status must reach complete/warning/error instead of staying stuck on exporting,
- output folders should be human-readable, such as `Flow42 Data`, with run metadata in nested folders or summary files.

## Visual/readability rules

For chart visuals:

- labels must not block candles, wicks, or important price areas,
- label/card may float away from price,
- arrow/leader line must point to the exact entry bar and exact entry price,
- keep `entryPrice` separate from `labelPrice`,
- Live Mode should stay clean and fast,
- Research/Review Mode can show heavier diagnostics, MFE/MAE boxes, click-to-inspect overlays, and expanded panels,
- use SharpDX/Direct2D/DirectWrite for NT8 custom rendering, not SkiaSharp,
- calculate signal state in `OnBarUpdate`; use `OnRender` only for rendering,
- do not do heavy historical calculations inside `OnRender`.

## Required preflight before non-trivial code edits

Before editing, identify:

1. File/class being edited.
2. Intended physical folder and namespace.
3. New output filename/version.
4. Features that must be preserved.
5. Whether the edit touches exporter, rendering, lifecycle, multi-series, order-flow, properties, alerts, or file I/O.
6. Which canonical docs or official manual terms were checked.
7. Known compile/runtime risks.
8. Smallest safe change plan.

For tiny cosmetic edits, keep the preflight very short.

## Required post-edit audit

After editing, report:

- changed,
- preserved,
- new filename/version,
- signal logic touched: yes/no,
- alerts/exports/dashboard touched: yes/no,
- folder/namespace/class/file checked: yes/no,
- official NinjaTrader lookup performed: yes/no and terms checked,
- compile verified in NinjaTrader: yes/no,
- remaining risks.

## Repo organization preference

Use clear folders for project artifacts:

- `Indicators/` for source indicators and versioned work.
- `Methodology/` for research logic, setup definitions, validation decisions, and caveats.
- `Errors/` for NinjaTrader compile/runtime error exports.
- `Reference/` only for project-specific references, not copied canonical NinjaTrader docs.
- `Exports/` only for small sample artifacts or schema examples; do not commit huge raw exports unless explicitly needed.

## Operating principle

One master NinjaTrader knowledge base, plus this small Reversals-specific adapter.

Do not create parallel documentation systems that will drift. If a rule is generally useful for all NinjaTrader work, improve `trading-system-hq/NinjaTrader`. If it is specific to reversal-model research, keep it in `Reversals`.