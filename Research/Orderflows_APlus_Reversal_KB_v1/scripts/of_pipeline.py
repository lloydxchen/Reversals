#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Orderflows A+ Reversal KB — Transcript Pipeline
================================================

Reproducible pipeline that turns the deduplicated Orderflows YouTube VTT
captions into cleaned Markdown transcripts, a master index CSV, word-budgeted
chunk files for LLM extraction, and quality reports.

It is intentionally read-only on the raw VTT folder: it never modifies, moves,
or deletes anything in INPUT_DIR. All output is written under OUTPUT_BASE.

Subcommands
-----------
    python of_pipeline.py clean      # VTT -> cleaned Markdown + index CSV
    python of_pipeline.py chunk      # cleaned MD -> chunk files (--words N)
    python of_pipeline.py reports    # quality reports (needs clean+chunk first)
    python of_pipeline.py all        # clean -> chunk -> reports

Design notes
------------
* YouTube auto-caption ("rolling") format: each caption line is shown first as
  a partial line carrying inline <00:00:00.000><c> word</c> timing tags, then as
  a settled plain line, then re-shown as a carry-over on the next cue. We strip
  the inline tags and drop any line equal to the previously emitted line, which
  collapses the rolling-window duplication while preserving real content.
* Timestamp traceability is preserved by emitting [mm:ss] anchors at the start
  of each paragraph (a new paragraph begins every PARA_SECONDS seconds or every
  MAX_PARA_WORDS words), so extractions can cite approximate locations.
* Filenames look like:  YYYYMMDD - Title [VIDEOID].en.vtt
"""

import argparse
import csv
import hashlib
import re
import sys
from pathlib import Path

# --------------------------------------------------------------------------- #
# Configuration
# --------------------------------------------------------------------------- #
INPUT_DIR = Path(r"C:\YTTranscripts\Orderflows_Dedup_v2")
OUTPUT_BASE = Path(
    r"C:\Users\chenk\Desktop\LloydTrading\Reversals\Research\Orderflows_APlus_Reversal_KB_v1"
)
CLEAN_DIR = OUTPUT_BASE / "clean_transcripts"
CHUNK_DIR = OUTPUT_BASE / "chunks"
REPORT_DIR = OUTPUT_BASE / "quality_reports"
INDEX_CSV = OUTPUT_BASE / "Orderflows_Transcript_Index_v1.csv"

# A transcript with fewer than this many words is treated as effectively empty
# (no usable spoken content) and flagged has_transcript = False.
MIN_TRANSCRIPT_WORDS = 25

# Paragraph / timestamp-anchor granularity in the cleaned Markdown body.
PARA_SECONDS = 40
MAX_PARA_WORDS = 90

# Default chunk budget (words). Overridable with `chunk --words N`.
DEFAULT_WORDS_PER_CHUNK = 26000

# --------------------------------------------------------------------------- #
# Regexes
# --------------------------------------------------------------------------- #
RE_INLINE_TS = re.compile(r"<\d{2}:\d{2}:\d{2}\.\d{3}>")          # <00:00:01.234>
RE_C_TAG = re.compile(r"</?c[^>]*>", re.IGNORECASE)               # <c> </c> <c.colorE5E5E5>
RE_CUE_TIME = re.compile(
    r"^\s*(\d{2}:\d{2}:\d{2}[.,]\d{3})\s*-->\s*(\d{2}:\d{2}:\d{2}[.,]\d{3})"
)
RE_WS = re.compile(r"\s+")
RE_FILENAME = re.compile(
    r"^(?P<date>\d{8})?\s*-?\s*(?P<title>.*?)\s*\[(?P<vid>[A-Za-z0-9_-]{6,15})\]\.en(?:-orig)?\.vtt$"
)
# Standalone integer cue-id lines (rare in YT auto captions, common in some VTT)
RE_CUE_ID = re.compile(r"^\d{1,6}$")

# --------------------------------------------------------------------------- #
# Relevance tiering (TRIAGE ONLY — decides extraction order, NOT model features)
# --------------------------------------------------------------------------- #
# Tier 1: explicit reversal / exhaustion / absorption / trap teaching videos
#         (densest, highest value for the A+ reversal model -> extract first).
# Tier 3: product launches, platform tutorials, announcements (low model value).
# Tier 2: everything else -> mostly live market-analysis / trade-recap videos
#         where the model is APPLIED in real time (valuable for operationalizing).
RE_TIER1 = re.compile(
    r"(exhaust\w*|absorb\w*|reversal|reverse|trapped|trap\b|divergence|imbalance|"
    r"stopping volume|stopping vol|price reject\w*|rejector|rejection|climax|climactic|"
    r"bounce|accumulation|distribution|stacked|liquidity|sweep|stop[- ]?run|show hand|"
    r"retail suck|weakness|v reversal|poc shadow|value area absorption|low of the day|"
    r"min max delta|delta change|delta reversal|min/max)",
    re.I,
)
RE_TIER3 = re.compile(
    r"(introducing|join strategic|grandfathered|update your|how to update|upgrade|"
    r"announcement|workshop|presentation|preview|toolbox|catalyst|markers unleashed|"
    r"markers plus|chatgpt|reader ai|read ai|get my book|book for free|new features|"
    r"new order flow trading software|huge announcement|gocharting)",
    re.I,
)


def classify_tier(title: str) -> int:
    if RE_TIER1.search(title):
        return 1
    if RE_TIER3.search(title):
        return 3
    return 2


# --------------------------------------------------------------------------- #
# Helpers
# --------------------------------------------------------------------------- #
def hms_to_seconds(ts: str) -> float:
    ts = ts.replace(",", ".")
    h, m, s = ts.split(":")
    return int(h) * 3600 + int(m) * 60 + float(s)


def seconds_to_anchor(sec: float) -> str:
    sec = int(round(sec))
    h, rem = divmod(sec, 3600)
    m, s = divmod(rem, 60)
    if h:
        return f"{h:d}:{m:02d}:{s:02d}"
    return f"{m:02d}:{s:02d}"


def normalize(text: str) -> str:
    return RE_WS.sub(" ", text).strip()


def parse_filename(name: str):
    """Return (date_iso, title, video_id, notes)."""
    notes = []
    m = RE_FILENAME.match(name)
    if not m:
        # Fallback: try to find a [VIDEOID] and a leading date manually.
        vid_m = re.search(r"\[([A-Za-z0-9_-]{6,15})\]", name)
        vid = vid_m.group(1) if vid_m else ""
        date_m = re.match(r"^(\d{8})", name)
        date_iso = ""
        if date_m:
            date_iso = fmt_date(date_m.group(1))
        title = name
        title = re.sub(r"^\d{8}\s*-\s*", "", title)
        title = re.sub(r"\s*\[[A-Za-z0-9_-]{6,15}\]\.en(?:-orig)?\.vtt$", "", title)
        notes.append("filename did not match strict pattern")
        return date_iso, clean_title(title), vid, "; ".join(notes)

    date_raw = m.group("date")
    date_iso = fmt_date(date_raw) if date_raw else ""
    if not date_raw:
        notes.append("no leading YYYYMMDD date in filename")
    title = clean_title(m.group("title"))
    vid = m.group("vid")
    return date_iso, title, vid, "; ".join(notes)


def fmt_date(d8: str) -> str:
    if d8 and len(d8) == 8 and d8.isdigit():
        return f"{d8[0:4]}-{d8[4:6]}-{d8[6:8]}"
    return ""


def clean_title(t: str) -> str:
    # Windows-illegal characters were substituted with fullwidth glyphs at
    # download time; restore the readable forms.
    t = t.replace("：", ":").replace("｜", "|").replace("？", "?")
    t = t.replace("＂", '"').replace("＊", "*").replace("／", "/").replace("＼", "\\")
    return normalize(t)


# --------------------------------------------------------------------------- #
# VTT cleaning
# --------------------------------------------------------------------------- #
def clean_vtt(raw: str):
    """Parse VTT text. Return list of (start_seconds, text) deduped segments."""
    segments = []
    last_norm = None
    cur_start = 0.0
    seen_first_time = False

    for raw_line in raw.splitlines():
        line = raw_line.rstrip("\n")
        stripped = line.strip()

        if not stripped:
            continue
        if stripped.startswith("WEBVTT"):
            continue
        if stripped.startswith("Kind:") or stripped.startswith("Language:"):
            continue
        if stripped.startswith("NOTE") or stripped.startswith("STYLE"):
            continue

        cue = RE_CUE_TIME.match(stripped)
        if cue:
            cur_start = hms_to_seconds(cue.group(1))
            seen_first_time = True
            continue
        if "-->" in stripped:
            continue
        if RE_CUE_ID.match(stripped):
            # Lone numeric cue id line.
            continue

        # Strip inline timing + <c> tags, decode a couple of common entities.
        text = RE_INLINE_TS.sub("", line)
        text = RE_C_TAG.sub("", text)
        text = (
            text.replace("&nbsp;", " ")
            .replace("&amp;", "&")
            .replace("&gt;", ">")
            .replace("&lt;", "<")
            .replace("&#39;", "'")
            .replace("&quot;", '"')
        )
        text = normalize(text)
        if not text:
            continue

        norm = text.lower()
        if norm == last_norm:
            continue
        segments.append((cur_start if seen_first_time else 0.0, text))
        last_norm = norm

    return segments


def build_markdown(meta: dict, segments) -> str:
    """Render cleaned Markdown: frontmatter + header + timestamp-anchored body."""
    fm = [
        "---",
        f"video_number: {meta['video_number']}",
        f"inferred_title: \"{meta['title'].replace(chr(34), chr(39))}\"",
        f"inferred_date: \"{meta['date']}\"",
        f"video_id: \"{meta['video_id']}\"",
        f"source_vtt: \"{meta['source_name'].replace(chr(34), chr(39))}\"",
        f"word_count: {meta['word_count']}",
        f"segment_count: {meta['segment_count']}",
        "---",
        "",
        f"# {meta['title']}",
        f"*Date:* {meta['date'] or 'unknown'}  |  *Video ID:* {meta['video_id'] or 'unknown'}  "
        f"|  *Words:* {meta['word_count']}",
        f"*Source VTT:* `{meta['source_name']}`",
        "",
        "---",
        "",
    ]

    body_lines = []
    para = []
    para_start = None
    para_words = 0

    def flush():
        nonlocal para, para_words
        if para:
            anchor = seconds_to_anchor(para_start)
            body_lines.append(f"[{anchor}] " + " ".join(para))
            body_lines.append("")
            para = []
            para_words = 0

    for start, text in segments:
        if para_start is None:
            para_start = start
        elapsed = start - para_start
        if para and (elapsed >= PARA_SECONDS or para_words >= MAX_PARA_WORDS):
            flush()
            para_start = start
        para.append(text)
        para_words += len(text.split())
    flush()

    return "\n".join(fm + body_lines).rstrip() + "\n"


def count_words(segments) -> int:
    return sum(len(t.split()) for _, t in segments)


def content_hash(segments) -> str:
    joined = " ".join(t.lower() for _, t in segments)
    return hashlib.sha1(joined.encode("utf-8", "replace")).hexdigest()


def safe_stub(date_iso: str, title: str, vid: str) -> str:
    base = (date_iso or "00000000").replace("-", "")
    t = re.sub(r"[^A-Za-z0-9]+", "_", title).strip("_")[:60] or "untitled"
    return f"{base}_{t}_{vid}"


# --------------------------------------------------------------------------- #
# Command: clean
# --------------------------------------------------------------------------- #
def cmd_clean(args):
    CLEAN_DIR.mkdir(parents=True, exist_ok=True)
    vtts = sorted(INPUT_DIR.glob("*.vtt"))
    print(f"Found {len(vtts)} .vtt files in {INPUT_DIR}")

    rows = []
    for vtt in vtts:
        raw = vtt.read_text(encoding="utf-8", errors="replace")
        date_iso, title, vid, notes = parse_filename(vtt.name)
        segments = clean_vtt(raw)
        wc = count_words(segments)
        seg_n = len(segments)
        has_tx = wc >= MIN_TRANSCRIPT_WORDS
        note_list = [notes] if notes else []
        if not has_tx:
            note_list.append(f"near-empty (<{MIN_TRANSCRIPT_WORDS} words)")
        rows.append(
            {
                "source_path": vtt,
                "source_name": vtt.name,
                "date": date_iso,
                "title": title,
                "video_id": vid,
                "segments": segments,
                "word_count": wc,
                "segment_count": seg_n,
                "has_transcript": has_tx,
                "file_size_bytes": vtt.stat().st_size,
                "chash": content_hash(segments) if segments else "",
                "notes": "; ".join([n for n in note_list if n]),
            }
        )

    # Chronological numbering (date, then title) for stable video_number.
    rows.sort(key=lambda r: (r["date"] or "99999999", r["title"].lower()))
    for i, r in enumerate(rows, start=1):
        r["video_number"] = i
        stub = safe_stub(r["date"], r["title"], r["video_id"])
        r["clean_name"] = f"{i:04d}_{stub}.md"

    # Write cleaned Markdown.
    written = 0
    for r in rows:
        meta = {
            "video_number": r["video_number"],
            "title": r["title"],
            "date": r["date"],
            "video_id": r["video_id"],
            "source_name": r["source_name"],
            "word_count": r["word_count"],
            "segment_count": r["segment_count"],
        }
        md = build_markdown(meta, r["segments"])
        (CLEAN_DIR / r["clean_name"]).write_text(md, encoding="utf-8")
        written += 1

    # Write index CSV.
    with INDEX_CSV.open("w", encoding="utf-8", newline="") as f:
        w = csv.writer(f)
        w.writerow(
            [
                "video_number",
                "inferred_date",
                "inferred_title",
                "video_id",
                "source_vtt_path",
                "cleaned_md_path",
                "word_count",
                "line_count",
                "file_size_bytes",
                "has_transcript",
                "notes",
            ]
        )
        for r in rows:
            w.writerow(
                [
                    r["video_number"],
                    r["date"],
                    r["title"],
                    r["video_id"],
                    str(r["source_path"]),
                    str((CLEAN_DIR / r["clean_name"])),
                    r["word_count"],
                    r["segment_count"],
                    r["file_size_bytes"],
                    "TRUE" if r["has_transcript"] else "FALSE",
                    r["notes"],
                ]
            )

    total_words = sum(r["word_count"] for r in rows)
    empties = sum(1 for r in rows if not r["has_transcript"])
    print(f"Wrote {written} cleaned Markdown files to {CLEAN_DIR}")
    print(f"Wrote index CSV: {INDEX_CSV}")
    print(f"Total words across corpus: {total_words:,}")
    print(f"Near-empty transcripts (<{MIN_TRANSCRIPT_WORDS} words): {empties}")
    if rows:
        wcs = sorted(r["word_count"] for r in rows)
        print(
            "Word-count distribution: "
            f"min={wcs[0]} p25={wcs[len(wcs)//4]} median={wcs[len(wcs)//2]} "
            f"p75={wcs[3*len(wcs)//4]} max={wcs[-1]} mean={total_words//len(rows)}"
        )
    return rows


# --------------------------------------------------------------------------- #
# Index / clean-MD reading (for chunk + reports)
# --------------------------------------------------------------------------- #
def read_index():
    if not INDEX_CSV.exists():
        sys.exit("Index CSV not found. Run `clean` first.")
    out = []
    with INDEX_CSV.open(encoding="utf-8", newline="") as f:
        for row in csv.DictReader(f):
            out.append(row)
    return out


def read_clean_body(md_path: Path) -> str:
    """Return the cleaned MD content WITHOUT the YAML frontmatter."""
    text = md_path.read_text(encoding="utf-8")
    if text.startswith("---"):
        parts = text.split("---", 2)
        if len(parts) == 3:
            return parts[2].lstrip("\n")
    return text


def split_body_parts(body: str, max_words: int):
    """Split a too-large body at paragraph boundaries into <= max_words pieces."""
    paras = [p for p in body.split("\n\n") if p.strip()]
    parts, cur, cur_words = [], [], 0
    for p in paras:
        pw = len(p.split())
        if cur and cur_words + pw > max_words:
            parts.append("\n\n".join(cur))
            cur, cur_words = [], 0
        cur.append(p)
        cur_words += pw
    if cur:
        parts.append("\n\n".join(cur))
    return parts


# --------------------------------------------------------------------------- #
# Command: chunk
# --------------------------------------------------------------------------- #
def cmd_chunk(args):
    CHUNK_DIR.mkdir(parents=True, exist_ok=True)
    words_per_chunk = args.words
    idx = read_index()

    # Build packing units (skip near-empty transcripts entirely).
    units = []
    for r in idx:
        if r["has_transcript"] != "TRUE":
            continue
        md_path = Path(r["cleaned_md_path"])
        body = read_clean_body(md_path)
        wc = int(r["word_count"])
        tier = classify_tier(r["inferred_title"])
        header = (
            f"### [{r['video_number']}] {r['inferred_title']}\n"
            f"- Date: {r['inferred_date'] or 'unknown'} | Video ID: {r['video_id'] or 'unknown'} "
            f"| Relevance tier: T{tier}\n"
            f"- Source VTT: `{Path(r['source_vtt_path']).name}`\n"
            f"- Clean MD: `clean_transcripts/{md_path.name}`\n"
        )
        if wc > words_per_chunk * 1.3:
            parts = split_body_parts(body, words_per_chunk)
            n = len(parts)
            for i, part in enumerate(parts, 1):
                units.append(
                    {
                        "vn": r["video_number"], "tier": tier, "date": r["inferred_date"],
                        "words": len(part.split()),
                        "header": header + f"- Part: {i}/{n} of this transcript\n",
                        "body": part,
                    }
                )
        else:
            units.append(
                {
                    "vn": r["video_number"], "tier": tier, "date": r["inferred_date"],
                    "words": wc, "header": header, "body": body,
                }
            )

    # Order by tier (1 = extract first), then chronologically within tier.
    units.sort(key=lambda u: (u["tier"], u["date"] or "99999999", u["vn"]))

    # Pack per-tier: never mix tiers in one chunk (start fresh at tier boundary).
    chunks = []
    cur, cur_words, cur_tier = [], 0, None
    for u in units:
        if cur and (cur_words + u["words"] > words_per_chunk or u["tier"] != cur_tier):
            chunks.append(cur)
            cur, cur_words = [], 0
        cur.append(u)
        cur_words += u["words"]
        cur_tier = u["tier"]
    if cur:
        chunks.append(cur)

    # Clear stale chunk files.
    for old in CHUNK_DIR.glob("Chunk_*_Orderflows_Transcripts.md"):
        old.unlink()

    manifest = []
    for ci, units_in_chunk in enumerate(chunks, 1):
        total_words = sum(u["words"] for u in units_in_chunk)
        vns = [u["vn"] for u in units_in_chunk]
        tier = units_in_chunk[0]["tier"]
        tier_desc = {
            1: "T1 — explicit reversal/exhaustion/absorption/trap teaching (highest model value)",
            2: "T2 — live market-analysis / trade-recap (model applied in real time)",
            3: "T3 — product launches / platform tutorials / announcements (low model value)",
        }[tier]
        head = [
            f"# Chunk {ci:03d} — Orderflows Transcripts",
            "",
            f"- Chunk number: {ci:03d}",
            f"- Relevance tier: **T{tier}** — {tier_desc}",
            f"- Transcripts/parts in chunk: {len(units_in_chunk)}",
            f"- Video numbers: {', '.join(str(v) for v in vns)}",
            f"- Chunk word count: {total_words:,}",
            "",
            "> Cleaned, de-duplicated Orderflows transcript text. `[mm:ss]` markers are "
            "approximate timestamps from the source video for traceability.",
            "",
            "===============================================================",
            "",
        ]
        parts_md = []
        for u in units_in_chunk:
            parts_md.append(u["header"])
            parts_md.append("")
            parts_md.append(u["body"].rstrip())
            parts_md.append("")
            parts_md.append("---------------------------------------------------------------")
            parts_md.append("")
        content = "\n".join(head + parts_md).rstrip() + "\n"
        fname = f"Chunk_{ci:03d}_Orderflows_Transcripts.md"
        (CHUNK_DIR / fname).write_text(content, encoding="utf-8")
        manifest.append(
            {
                "chunk": ci,
                "tier": tier,
                "file": fname,
                "units": len(units_in_chunk),
                "words": total_words,
                "video_numbers": vns,
            }
        )

    print(f"Wrote {len(chunks)} chunk files to {CHUNK_DIR} (budget {words_per_chunk:,} words)")
    if manifest:
        ws = [m["words"] for m in manifest]
        print(f"Chunk word counts: min={min(ws):,} max={max(ws):,} mean={sum(ws)//len(ws):,}")
    # Stash a manifest for the chunking report.
    import json
    (REPORT_DIR).mkdir(parents=True, exist_ok=True)
    (REPORT_DIR / "_chunk_manifest.json").write_text(
        json.dumps(manifest, indent=2), encoding="utf-8"
    )
    return manifest


# --------------------------------------------------------------------------- #
# Command: reports
# --------------------------------------------------------------------------- #
def cmd_reports(args):
    REPORT_DIR.mkdir(parents=True, exist_ok=True)
    idx = read_index()
    n_vtt = len(list(INPUT_DIR.glob("*.vtt")))
    total = len(idx)
    with_tx = [r for r in idx if r["has_transcript"] == "TRUE"]
    without_tx = [r for r in idx if r["has_transcript"] != "TRUE"]
    total_words = sum(int(r["word_count"]) for r in idx)
    dates = [r["inferred_date"] for r in idx if r["inferred_date"]]
    dmin, dmax = (min(dates), max(dates)) if dates else ("?", "?")

    # transcript_count_report.md
    lines = [
        "# Transcript Count Report",
        "",
        f"- Raw `.vtt` files found in input folder: **{n_vtt}**",
        f"- Input folder: `{INPUT_DIR}`",
        f"- Cleaned Markdown transcripts written: **{total}**",
        f"- Transcripts with usable content (>= {MIN_TRANSCRIPT_WORDS} words): **{len(with_tx)}**",
        f"- Near-empty / no-caption transcripts: **{len(without_tx)}**",
        f"- Total words across corpus: **{total_words:,}**",
        f"- Date range (inferred from filenames): **{dmin} → {dmax}**",
        "",
        "## Near-empty transcripts (flagged has_transcript = FALSE)",
        "",
    ]
    if without_tx:
        lines.append("| video_number | date | words | title |")
        lines.append("|---|---|---|---|")
        for r in sorted(without_tx, key=lambda r: int(r["word_count"])):
            lines.append(
                f"| {r['video_number']} | {r['inferred_date']} | {r['word_count']} | {r['inferred_title']} |"
            )
    else:
        lines.append("_None._")
    (REPORT_DIR / "transcript_count_report.md").write_text("\n".join(lines) + "\n", encoding="utf-8")

    # smallest_files_report.md
    smk = sorted(idx, key=lambda r: int(r["word_count"]))[:40]
    lines = [
        "# Smallest Files Report",
        "",
        "Smallest 40 cleaned transcripts by word count. Very small counts usually "
        "mean a near-empty caption file, a teaser/announcement, or a music-only clip. "
        "These are low-value for model extraction and are excluded from chunks when "
        f"below {MIN_TRANSCRIPT_WORDS} words.",
        "",
        "| video_number | date | words | has_transcript | title |",
        "|---|---|---|---|---|",
    ]
    for r in smk:
        lines.append(
            f"| {r['video_number']} | {r['inferred_date']} | {r['word_count']} "
            f"| {r['has_transcript']} | {r['inferred_title']} |"
        )
    (REPORT_DIR / "smallest_files_report.md").write_text("\n".join(lines) + "\n", encoding="utf-8")

    # duplicate_check_report.md  (dup video IDs + dup cleaned content hashes)
    # Recompute hashes from clean bodies for an independent content check.
    from collections import defaultdict

    vid_map = defaultdict(list)
    for r in idx:
        vid_map[r["video_id"]].append(r)
    dup_vids = {k: v for k, v in vid_map.items() if k and len(v) > 1}

    hash_map = defaultdict(list)
    for r in idx:
        body = read_clean_body(Path(r["cleaned_md_path"]))
        h = hashlib.sha1(normalize(body).lower().encode("utf-8", "replace")).hexdigest()
        hash_map[h].append(r)
    dup_content = {k: v for k, v in hash_map.items() if len(v) > 1}

    lines = [
        "# Duplicate Check Report",
        "",
        "The input folder is already a deduplicated set (`Orderflows_Dedup_v2`). "
        "This report independently re-checks for (a) repeated YouTube video IDs and "
        "(b) byte-identical cleaned transcript bodies.",
        "",
        f"- Distinct video IDs: **{len([k for k in vid_map if k])}**",
        f"- Video IDs appearing more than once: **{len(dup_vids)}**",
        f"- Groups of identical cleaned content: **{len(dup_content)}**",
        "",
        "## Repeated video IDs",
        "",
    ]
    if dup_vids:
        for vid, rs in dup_vids.items():
            lines.append(f"- `{vid}`: " + "; ".join(f"#{r['video_number']} {r['inferred_title']}" for r in rs))
    else:
        lines.append("_None — every video ID is unique._")
    lines += ["", "## Identical cleaned content", ""]
    if dup_content:
        for h, rs in dup_content.items():
            lines.append(
                f"- hash `{h[:10]}`: "
                + "; ".join(f"#{r['video_number']} {r['inferred_title']}" for r in rs)
            )
    else:
        lines.append("_None — no two cleaned transcripts are textually identical._")
    (REPORT_DIR / "duplicate_check_report.md").write_text("\n".join(lines) + "\n", encoding="utf-8")

    # chunking_report.md
    import json
    man_path = REPORT_DIR / "_chunk_manifest.json"
    if man_path.exists():
        manifest = json.loads(man_path.read_text(encoding="utf-8"))
        ws = [m["words"] for m in manifest]
        from collections import defaultdict as _dd
        tier_chunks = _dd(int)
        tier_words = _dd(int)
        for m in manifest:
            tier_chunks[m.get("tier", 2)] += 1
            tier_words[m.get("tier", 2)] += m["words"]
        lines = [
            "# Chunking Report",
            "",
            f"- Chunk files created: **{len(manifest)}**",
            f"- Word budget per chunk: **{DEFAULT_WORDS_PER_CHUNK:,}** (whole transcripts packed; "
            "transcripts > 1.3x budget are split into labeled parts; chunks never mix tiers)",
            f"- Total words chunked: **{sum(ws):,}**",
            f"- Words per chunk: min **{min(ws):,}**, max **{max(ws):,}**, mean **{sum(ws)//len(ws):,}**",
            "",
            "## Extraction priority by relevance tier",
            "",
            "Chunks are ordered by tier, so lower chunk numbers = higher model value "
            "and should be extracted first. Tiering is a coarse title-based triage, "
            "**not** a model feature.",
            "",
            "| tier | meaning | chunks | words |",
            "|---|---|---|---|",
            f"| T1 | reversal/exhaustion/absorption/trap teaching | {tier_chunks[1]} | {tier_words[1]:,} |",
            f"| T2 | live market-analysis / trade-recap (model applied) | {tier_chunks[2]} | {tier_words[2]:,} |",
            f"| T3 | product / platform / announcement (low value) | {tier_chunks[3]} | {tier_words[3]:,} |",
            "",
            "| chunk | tier | file | transcripts/parts | words | video_numbers |",
            "|---|---|---|---|---|---|",
        ]
        for m in manifest:
            vns = m["video_numbers"]
            vn_str = f"{vns[0]}–{vns[-1]}" if len(vns) > 2 else ", ".join(str(v) for v in vns)
            lines.append(
                f"| {m['chunk']:03d} | T{m.get('tier',2)} | {m['file']} | {m['units']} "
                f"| {m['words']:,} | {vn_str} |"
            )
        (REPORT_DIR / "chunking_report.md").write_text("\n".join(lines) + "\n", encoding="utf-8")
    else:
        (REPORT_DIR / "chunking_report.md").write_text(
            "# Chunking Report\n\n_Run `chunk` first._\n", encoding="utf-8"
        )

    print(f"Wrote quality reports to {REPORT_DIR}")


# --------------------------------------------------------------------------- #
# CLI
# --------------------------------------------------------------------------- #
def main():
    ap = argparse.ArgumentParser(description="Orderflows transcript pipeline")
    sub = ap.add_subparsers(dest="cmd", required=True)
    sub.add_parser("clean")
    cp = sub.add_parser("chunk")
    cp.add_argument("--words", type=int, default=DEFAULT_WORDS_PER_CHUNK)
    sub.add_parser("reports")
    ap_all = sub.add_parser("all")
    ap_all.add_argument("--words", type=int, default=DEFAULT_WORDS_PER_CHUNK)

    args = ap.parse_args()
    if args.cmd == "clean":
        cmd_clean(args)
    elif args.cmd == "chunk":
        cmd_chunk(args)
    elif args.cmd == "reports":
        cmd_reports(args)
    elif args.cmd == "all":
        cmd_clean(args)
        cmd_chunk(args)
        cmd_reports(args)


if __name__ == "__main__":
    main()
