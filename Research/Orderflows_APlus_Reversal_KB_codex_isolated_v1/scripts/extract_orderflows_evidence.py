from __future__ import annotations

import html
import re
from dataclasses import dataclass
from pathlib import Path


INPUT_DIR = Path(r"C:\YTTranscripts\Orderflows_Dedup_v2")
OUTPUT_DIR = Path(
    r"C:\Users\chenk\Desktop\LloydTrading\Reversals\Research\Orderflows_APlus_Reversal_KB_codex_isolated_v1"
)

MAX_ENTRIES_PER_THEME = 80
CONTEXT_LINES = 2


@dataclass(frozen=True)
class Theme:
    slug: str
    title: str
    keywords: tuple[str, ...]


THEMES = (
    Theme(
        "exhaustion",
        "Exhaustion",
        (
            "exhaustion",
            "exhaustion print",
            "exhausted",
            "market exhaustion",
            "price exhaustion",
            "buying exhaustion",
            "selling exhaustion",
            "small delta",
            "min delta",
            "max delta",
            "ratio bounds",
            "stopping volume",
            "can't go higher",
            "can't go lower",
        ),
    ),
    Theme(
        "absorption",
        "Absorption",
        (
            "absorption",
            "absorbed",
            "absorbing",
            "passive buyer",
            "passive seller",
            "passive buying",
            "passive selling",
            "aggressive buying absorbed",
            "aggressive selling absorbed",
            "limit order",
            "value area absorption",
            "iceberg",
            "fresh liquidity",
        ),
    ),
    Theme(
        "stacked_imbalances",
        "Stacked Imbalances",
        (
            "stacked imbalance",
            "stacked imbalances",
            "buy imbalance",
            "sell imbalance",
            "imbalances stacked",
            "multiple imbalances",
            "three imbalances",
            "imbalance reload",
            "inverse imbalance",
            "inverse imbalances",
            "unfinished auction",
        ),
    ),
    Theme(
        "delta_divergence",
        "Delta Divergence",
        (
            "delta divergence",
            "cumulative delta divergence",
            "price and delta",
            "delta diverge",
            "delta diverges",
            "divergence",
            "ratio divergence",
            "delta weakness",
            "positive delta",
            "negative delta",
            "delta reversal",
            "delta flip",
            "max delta",
            "min delta",
        ),
    ),
    Theme(
        "failed_breakouts_stop_runs",
        "Failed Breakouts And Stop Runs",
        (
            "failed breakout",
            "false breakout",
            "breakout failed",
            "break out and fail",
            "stop run",
            "stop runs",
            "running stops",
            "ran the stops",
            "sweep",
            "market sweep",
            "liquidity sweep",
            "take out the high",
            "take out the low",
            "took out the high",
            "took out the low",
            "break above",
            "break below",
            "breakout",
        ),
    ),
    Theme(
        "trapped_traders",
        "Trapped Traders",
        (
            "trapped trader",
            "trapped traders",
            "trapped buyers",
            "trapped sellers",
            "buyers trapped",
            "sellers trapped",
            "retail suck",
            "green delta trap",
            "trap",
            "stuck long",
            "stuck short",
            "short covering",
            "long liquidation",
        ),
    ),
    Theme(
        "entries_confirmation_invalidation",
        "Entries Confirmation Invalidation",
        (
            "entry",
            "entry model",
            "confirmation",
            "confirm",
            "confirmed",
            "invalid",
            "invalidation",
            "stop loss",
            "risk",
            "target",
            "trade location",
            "trigger",
            "setup",
            "trade setup",
            "pullback",
            "reversal",
            "wait for",
        ),
    ),
    Theme(
        "context_filters",
        "Context Filters",
        (
            "context",
            "market context",
            "trend day",
            "range",
            "chop",
            "balance",
            "value area",
            "volume profile",
            "vwap",
            "support",
            "resistance",
            "high of day",
            "low of day",
            "news",
            "fed",
            "holiday",
            "slow market",
            "volatile",
        ),
    ),
    Theme(
        "ninjatrader_indicator_ideas",
        "NinjaTrader Indicator Ideas",
        (
            "ninjatrader",
            "ninja trader",
            "nt8",
            "indicator",
            "orderflows trader",
            "orderflows trader 7",
            "orderflows trader 8",
            "markers",
            "marker",
            "algo",
            "toolbox",
            "reversal scalper",
            "delta scalper",
            "liquidity finder",
            "vol shift",
            "pressure indicator",
            "poc shadows",
            "bar gaps",
            "show hand",
            "read ai",
        ),
    ),
)


TIMESTAMP_RE = re.compile(r"^\d{2}:\d{2}:\d{2}\.\d{3}\s+-->\s+\d{2}:\d{2}:\d{2}\.\d{3}")
CUE_ID_RE = re.compile(r"^\d+$")
VIDEO_ID_RE = re.compile(r"\[([^\[\]]+)\]\.en\.vtt$", re.IGNORECASE)
TAG_RE = re.compile(r"<[^>]+>")
SPACE_RE = re.compile(r"\s+")


def normalize_text(text: str) -> str:
    text = html.unescape(text)
    text = TAG_RE.sub(" ", text)
    text = text.replace("\ufeff", "")
    text = SPACE_RE.sub(" ", text)
    return text.strip()


def clean_vtt(path: Path) -> list[str]:
    lines: list[str] = []
    seen_previous = ""

    for raw_line in path.read_text(encoding="utf-8", errors="replace").splitlines():
        line = normalize_text(raw_line)
        if not line:
            continue
        if line.upper().startswith("WEBVTT"):
            continue
        if line.upper().startswith("NOTE"):
            continue
        if TIMESTAMP_RE.match(line):
            continue
        if CUE_ID_RE.match(line):
            continue

        normalized = line.casefold()
        if normalized == seen_previous:
            continue
        if seen_previous and (normalized.startswith(seen_previous) or seen_previous.startswith(normalized)):
            if len(normalized) <= len(seen_previous):
                continue
            if lines:
                lines[-1] = line
                seen_previous = normalized
                continue

        lines.append(line)
        seen_previous = normalized

    return lines


def video_id_from_filename(filename: str) -> str:
    match = VIDEO_ID_RE.search(filename)
    return match.group(1) if match else "unknown"


def matched_terms(text: str, theme: Theme) -> list[str]:
    text = text.casefold()
    found: list[str] = []
    for keyword in theme.keywords:
        if keyword.casefold() in text:
            found.append(keyword)
    return found


def context_for_match(lines: list[str], index: int) -> str:
    start = max(0, index - CONTEXT_LINES)
    end = min(len(lines), index + CONTEXT_LINES + 1)
    return " ".join(lines[start:end])


def collect_evidence() -> dict[str, list[dict[str, object]]]:
    evidence: dict[str, list[dict[str, object]]] = {theme.slug: [] for theme in THEMES}
    seen_contexts: dict[str, set[str]] = {theme.slug: set() for theme in THEMES}

    for path in sorted(INPUT_DIR.glob("*.vtt")):
        lines = clean_vtt(path)
        filename = path.name
        video_id = video_id_from_filename(filename)

        for index, line in enumerate(lines):
            nearby = context_for_match(lines, index)
            searchable = f"{filename} {line} {nearby}"

            for theme in THEMES:
                terms = matched_terms(searchable, theme)
                if not terms:
                    continue

                excerpt = line
                context = nearby if nearby != line else ""
                fingerprint = SPACE_RE.sub(" ", context or excerpt).casefold()[:500]
                if fingerprint in seen_contexts[theme.slug]:
                    continue
                seen_contexts[theme.slug].add(fingerprint)

                score = len(terms) * 10
                score += 5 if any(term in filename.casefold() for term in terms) else 0
                score += min(5, len(excerpt) // 80)

                evidence[theme.slug].append(
                    {
                        "score": score,
                        "source_filename": filename,
                        "video_id": video_id,
                        "matched_theme": theme.title,
                        "matched_terms": terms,
                        "excerpt": excerpt,
                        "nearby_context": context,
                    }
                )

    for theme in THEMES:
        evidence[theme.slug].sort(
            key=lambda item: (
                -int(item["score"]),
                str(item["source_filename"]),
                str(item["excerpt"]),
            )
        )
        evidence[theme.slug] = evidence[theme.slug][:MAX_ENTRIES_PER_THEME]

    return evidence


def write_evidence_files(evidence: dict[str, list[dict[str, object]]]) -> list[str]:
    evidence_dir = OUTPUT_DIR / "evidence"
    evidence_dir.mkdir(parents=True, exist_ok=True)
    created: list[str] = []

    for theme in THEMES:
        path = evidence_dir / f"{theme.slug}_evidence.md"
        entries = evidence[theme.slug]
        lines = [
            f"# {theme.title} Evidence",
            "",
            "Extraction type: keyword/theme-based snippets from minimally cleaned VTT captions.",
            f"Entries included: {len(entries)}",
            "",
        ]

        if not entries:
            lines.extend(["No keyword/theme matches found.", ""])
        else:
            for number, entry in enumerate(entries, start=1):
                lines.extend(
                    [
                        f"## Evidence {number}",
                        f"- Source filename: {entry['source_filename']}",
                        f"- Video ID: {entry['video_id']}",
                        f"- Matched theme: {entry['matched_theme']}",
                        f"- Matched terms: {', '.join(entry['matched_terms'])}",
                        "",
                        "Relevant cleaned excerpt:",
                        "",
                        f"> {entry['excerpt']}",
                        "",
                    ]
                )
                if entry["nearby_context"]:
                    lines.extend(
                        [
                            "Nearby context:",
                            "",
                            f"> {entry['nearby_context']}",
                            "",
                        ]
                    )

        path.write_text("\n".join(lines).rstrip() + "\n", encoding="utf-8")
        created.append(str(path.relative_to(OUTPUT_DIR)))

    return created


def write_audit_note(created_files: list[str], evidence: dict[str, list[dict[str, object]]]) -> None:
    audit_dir = OUTPUT_DIR / "audit_notes"
    audit_dir.mkdir(parents=True, exist_ok=True)
    path = audit_dir / "01_evidence_extraction_notes.md"
    total_vtts = len(list(INPUT_DIR.glob("*.vtt")))

    lines = [
        "# Evidence Extraction Notes",
        "",
        "## Scope",
        "",
        f"- Input folder: `{INPUT_DIR}`",
        f"- Output folder: `{OUTPUT_DIR}`",
        f"- VTT files scanned: {total_vtts}",
        "- Raw VTT files were not modified.",
        "",
        "## Evidence Files Created",
        "",
    ]
    for file in created_files:
        slug = Path(file).name.replace("_evidence.md", "")
        lines.append(f"- `{file}` ({len(evidence[slug])} entries)")
    lines.extend(
        [
            "",
            "## Extraction Method",
            "",
            "- This was keyword/theme-based extraction.",
            "- Minimal VTT cleaning was applied in memory only: WEBVTT headers removed, timestamp lines ignored, numeric cue IDs ignored, caption tags stripped, whitespace collapsed, and obvious consecutive duplicate caption fragments collapsed.",
            "- Source filename and video ID were preserved for each evidence entry when the ID was available from the filename.",
            "- Evidence snippets were ranked by theme keyword density and lightly capped per theme to keep this phase lightweight.",
            "",
            "## Limitations",
            "",
            "- This is not a full cleaned transcript anthology.",
            "- Keyword/theme matching can miss useful evidence that uses different wording.",
            "- Keyword/theme matching can include false positives where a term is mentioned casually rather than as a trading rule.",
            "- Caption transcription errors remain possible because the raw VTT wording is preserved after minimal cleaning.",
            "- Nearby context is local caption context only, not a full video-level argument reconstruction.",
            "- No final A+ reversal model, rule hierarchy, weighting, or profitability synthesis was created in this phase.",
        ]
    )
    path.write_text("\n".join(lines).rstrip() + "\n", encoding="utf-8")


def main() -> None:
    for folder in ("evidence", "knowledge_base", "audit_notes", "scripts"):
        (OUTPUT_DIR / folder).mkdir(parents=True, exist_ok=True)

    evidence = collect_evidence()
    created_files = write_evidence_files(evidence)
    write_audit_note(created_files, evidence)

    print(f"Scanned {len(list(INPUT_DIR.glob('*.vtt')))} VTT files")
    print(f"Wrote {len(created_files)} evidence files")
    for file in created_files:
        print(file)
    print(r"audit_notes\01_evidence_extraction_notes.md")


if __name__ == "__main__":
    main()
