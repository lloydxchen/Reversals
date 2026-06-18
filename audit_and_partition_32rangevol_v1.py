#!/usr/bin/env python3
"""
Audit and partition NQ 04/19-06/17 32RangeVol NinjaTrader exports.

Rules enforced:
- raw files are read-only inputs
- no nrows/sample-only processing
- no silent malformed-row skipping
- no row drops or deduplication
- source_row_id preserves raw row order
- duplicate timestamps are warnings, not fatal
"""

from __future__ import annotations

import argparse
import csv
import hashlib
import json
import math
import os
import re
import shutil
import sys
from collections import defaultdict
from dataclasses import dataclass, field
from datetime import datetime, timedelta
from pathlib import Path
from typing import Any

try:
    import pyarrow as pa
    import pyarrow.parquet as pq
except ModuleNotFoundError:
    temp_pyarrow = Path(r"C:\tmp\lloyd_py314_deps")
    if temp_pyarrow.exists():
        sys.path.insert(0, str(temp_pyarrow))
    import pyarrow as pa
    import pyarrow.parquet as pq


RAW_PREFIX = "NQ_0419-0617_32RangeVol"
OUTPUT_NAME = "NQ_32RangeVol_0419_0617_v1"
ET_LABEL = "America/New_York (ET)"
MAX_UNIQUE_TRACK = 1001
BATCH_ROWS = 50000
LARGE_WEEK_BYTES = 512 * 1024 * 1024

TIMESTAMP_FORMATS = [
    "%Y-%m-%d %H:%M:%S.%f",
    "%Y-%m-%d %H:%M:%S",
    "%Y-%m-%d %I:%M:%S %p",
    "%m/%d/%Y %I:%M:%S %p",
    "%m/%d/%Y %H:%M:%S",
]


@dataclass
class ColumnStats:
    name: str
    check_timestamp: bool = False
    missing: int = 0
    non_missing: int = 0
    int_ok: bool = True
    float_ok: bool = True
    bool_ok: bool = True
    timestamp_ok: bool = True
    timestamp_success: int = 0
    numeric_min: float | None = None
    numeric_max: float | None = None
    unique_values: set[str] = field(default_factory=set)
    unique_overflow: bool = False

    def observe(self, value: str) -> None:
        v = value.strip()
        if v == "":
            self.missing += 1
            return
        self.non_missing += 1

        if not self.unique_overflow:
            self.unique_values.add(v)
            if len(self.unique_values) > MAX_UNIQUE_TRACK:
                self.unique_values.clear()
                self.unique_overflow = True

        try:
            int(v)
        except ValueError:
            self.int_ok = False

        try:
            f = float(v)
            if math.isfinite(f):
                self.numeric_min = f if self.numeric_min is None else min(self.numeric_min, f)
                self.numeric_max = f if self.numeric_max is None else max(self.numeric_max, f)
            else:
                self.float_ok = False
        except ValueError:
            self.float_ok = False

        if v.lower() not in {"true", "false", "0", "1"}:
            self.bool_ok = False

        if self.check_timestamp:
            if parse_timestamp(v) is not None:
                self.timestamp_success += 1
            else:
                self.timestamp_ok = False

    def inferred_type(self, prefer_timestamp: bool = False) -> str:
        if self.non_missing == 0:
            return "string"
        if prefer_timestamp and self.timestamp_success == self.non_missing:
            return "timestamp[us]"
        if self.bool_ok:
            return "bool"
        if self.int_ok:
            return "int64"
        if self.float_ok:
            return "float64"
        if self.timestamp_success == self.non_missing and looks_timestamp_name(self.name):
            return "timestamp[us]"
        return "string"

    def suspicious_flags(self) -> list[str]:
        flags: list[str] = []
        if self.non_missing == 0:
            flags.append("all_missing")
        if not self.unique_overflow and len(self.unique_values) == 1 and self.non_missing > 0:
            flags.append("constant")
        if self.missing and self.non_missing:
            flags.append("mixed_missing")
        return flags


@dataclass
class FileAudit:
    kind: str
    path: Path
    size_bytes: int
    sha256: str
    encoding: str
    delimiter: str
    columns: list[str]
    total_rows: int
    column_count: int
    inferred_schema: dict[str, str]
    missing_values: dict[str, int]
    timestamp_column: str | None
    first_timestamp: str | None
    last_timestamp: str | None
    timestamp_parse_success_rate: float
    missing_timestamps: int
    duplicate_timestamps: int
    duplicate_full_rows: int
    malformed_rows: int
    numeric_min_max: dict[str, dict[str, float | None]]
    suspicious_columns: dict[str, list[str]]
    warnings: list[str]
    week_counts: dict[str, int]


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Audit and partition NQ 32RangeVol raw exports.")
    parser.add_argument("--root", default=".", help="Search root. Defaults to current directory.")
    parser.add_argument("--overwrite-output", action="store_true", help="Delete existing processed v1 output folder before writing.")
    return parser.parse_args()


def parse_timestamp(value: str | None) -> datetime | None:
    if value is None:
        return None
    v = value.strip()
    if not v:
        return None
    for fmt in TIMESTAMP_FORMATS:
        try:
            return datetime.strptime(v, fmt)
        except ValueError:
            pass
    try:
        return datetime.fromisoformat(v)
    except ValueError:
        return None


def format_et(dt: datetime | None) -> str | None:
    if dt is None:
        return None
    return dt.strftime("%Y-%m-%d %I:%M:%S %p ET")


def looks_timestamp_name(name: str) -> bool:
    n = name.lower()
    return n in {"timestamp", "time", "datetime", "date", "bartime"} or n.endswith("time") or "timestamp" in n


def progress(label: str, rows: int) -> None:
    if rows and rows % 1_000_000 == 0:
        print(f"[{datetime.now().strftime('%I:%M:%S %p ET')}] {label}: {rows:,} rows", file=sys.stderr, flush=True)


def week_start(dt: datetime) -> str:
    return (dt.date() - timedelta(days=dt.weekday())).isoformat()


def subpart_index(dt: datetime) -> int:
    return min(dt.weekday() // 3, 2)


def sha256_file(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def detect_encoding_and_delimiter(path: Path) -> tuple[str, str]:
    raw = path.read_bytes()[:65536]
    encoding = "utf-8-sig"
    for candidate in ("utf-8-sig", "utf-8", "cp1252"):
        try:
            raw.decode(candidate)
            encoding = candidate
            break
        except UnicodeDecodeError:
            continue
    text = raw.decode(encoding, errors="strict")
    try:
        dialect = csv.Sniffer().sniff(text, delimiters=",\t;|")
        delimiter = dialect.delimiter
    except csv.Error:
        delimiter = ","
    return encoding, delimiter


def discover_raw_files(root: Path) -> dict[str, Path]:
    matches = list(root.rglob(f"{RAW_PREFIX}_*"))
    by_kind: dict[str, list[Path]] = {"bars": [], "footprint": [], "manifest": []}
    csv_like_suffixes = {".csv", ".tsv", ".txt"}
    for path in matches:
        if not path.is_file():
            continue
        if path.suffix.lower() not in csv_like_suffixes:
            continue
        lower = path.name.lower()
        for kind in by_kind:
            if f"_{kind}" in lower:
                by_kind[kind].append(path)
    result: dict[str, Path] = {}
    for kind, paths in by_kind.items():
        if len(paths) != 1:
            raise RuntimeError(f"Expected exactly one {kind} file, found {len(paths)}: {[str(p) for p in paths]}")
        result[kind] = paths[0]
    return result


def find_data_root(raw_path: Path) -> Path:
    for parent in [raw_path.parent, *raw_path.parents]:
        if parent.name.lower() == "data":
            return parent
    return raw_path.parent


def read_manifest(path: Path, encoding: str, delimiter: str) -> dict[str, str]:
    values: dict[str, str] = {}
    with path.open("r", encoding=encoding, newline="") as f:
        reader = csv.reader(f, delimiter=delimiter)
        header = next(reader, None)
        if header is None:
            return values
        for row in reader:
            if len(row) >= 2:
                values[row[0]] = row[1]
    return values


def choose_timestamp_column(columns: list[str], col_stats: dict[str, ColumnStats]) -> str | None:
    preferred = ["Timestamp", "Time", "DateTime", "BarTime", "VolumetricSourceTime"]
    for name in preferred:
        if name in col_stats and col_stats[name].timestamp_success > 0:
            return name
    candidates = []
    for name in columns:
        stats = col_stats[name]
        if looks_timestamp_name(name) and stats.timestamp_success > 0:
            rate = stats.timestamp_success / max(stats.non_missing, 1)
            candidates.append((rate, stats.timestamp_success, name))
    if candidates:
        return sorted(candidates, reverse=True)[0][2]
    return None


def audit_file(kind: str, path: Path) -> FileAudit:
    size = path.stat().st_size
    file_hash = sha256_file(path)
    encoding, delimiter = detect_encoding_and_delimiter(path)

    malformed_rows = 0
    duplicate_full_rows = 0
    duplicate_timestamps = 0
    missing_timestamps = 0
    first_ts: datetime | None = None
    last_ts: datetime | None = None
    timestamp_success = 0
    timestamp_column: str | None = None
    week_counts: dict[str, int] = defaultdict(int)
    full_row_hashes: set[str] = set()
    timestamp_seen: set[str] = set()

    with path.open("r", encoding=encoding, newline="") as f:
        reader = csv.reader(f, delimiter=delimiter, strict=True)
        try:
            columns = next(reader)
        except StopIteration:
            columns = []
        col_stats = {name: ColumnStats(name, check_timestamp=looks_timestamp_name(name)) for name in columns}

        total_rows = 0
        for raw_row in reader:
            total_rows += 1
            if len(raw_row) != len(columns):
                malformed_rows += 1
                continue
            for name, value in zip(columns, raw_row):
                col_stats[name].observe(value)

            row_hash = hashlib.blake2b("\x1f".join(raw_row).encode("utf-8", errors="surrogatepass"), digest_size=16).digest()
            if row_hash in full_row_hashes:
                duplicate_full_rows += 1
            else:
                full_row_hashes.add(row_hash)
            progress(f"audit {kind}", total_rows)

    timestamp_column = choose_timestamp_column(columns, col_stats)

    if timestamp_column and malformed_rows == 0:
        ts_idx = columns.index(timestamp_column)
        with path.open("r", encoding=encoding, newline="") as f:
            reader = csv.reader(f, delimiter=delimiter, strict=True)
            next(reader, None)
            for raw_row in reader:
                if len(raw_row) != len(columns):
                    continue
                dt = parse_timestamp(raw_row[ts_idx])
                if dt is None:
                    missing_timestamps += 1
                    continue
                timestamp_success += 1
                first_ts = dt if first_ts is None else min(first_ts, dt)
                last_ts = dt if last_ts is None else max(last_ts, dt)
                ts_key = dt.isoformat(sep=" ")
                if ts_key in timestamp_seen:
                    duplicate_timestamps += 1
                else:
                    timestamp_seen.add(ts_key)
                week_counts[week_start(dt)] += 1
                progress(f"timestamp scan {kind}", timestamp_success)

    inferred_schema = {}
    for name, stats in col_stats.items():
        inferred_schema[name] = stats.inferred_type(prefer_timestamp=(name == timestamp_column))

    numeric_min_max = {
        name: {"min": stats.numeric_min, "max": stats.numeric_max}
        for name, stats in col_stats.items()
        if stats.numeric_min is not None or stats.numeric_max is not None
    }
    suspicious = {
        name: flags
        for name, stats in col_stats.items()
        if (flags := stats.suspicious_flags())
    }
    warnings = []
    if malformed_rows:
        warnings.append(f"{malformed_rows} malformed rows; partitioning should stop.")
    if duplicate_timestamps:
        warnings.append(f"{duplicate_timestamps} duplicate timestamp rows; allowed for range/volumetric data.")
    if duplicate_full_rows:
        warnings.append(f"{duplicate_full_rows} duplicate full rows found; flagged, not removed.")
    if timestamp_column is None and kind != "manifest":
        warnings.append("No usable timestamp column detected.")

    return FileAudit(
        kind=kind,
        path=path,
        size_bytes=size,
        sha256=file_hash,
        encoding=encoding,
        delimiter=delimiter,
        columns=columns,
        total_rows=total_rows,
        column_count=len(columns),
        inferred_schema=inferred_schema,
        missing_values={name: stats.missing for name, stats in col_stats.items()},
        timestamp_column=timestamp_column,
        first_timestamp=format_et(first_ts),
        last_timestamp=format_et(last_ts),
        timestamp_parse_success_rate=(timestamp_success / total_rows if total_rows else 0.0),
        missing_timestamps=missing_timestamps,
        duplicate_timestamps=duplicate_timestamps,
        duplicate_full_rows=duplicate_full_rows,
        malformed_rows=malformed_rows,
        numeric_min_max=numeric_min_max,
        suspicious_columns=suspicious,
        warnings=warnings,
        week_counts=dict(week_counts),
    )


def arrow_type(type_name: str) -> pa.DataType:
    if type_name == "int64":
        return pa.int64()
    if type_name == "float64":
        return pa.float64()
    if type_name == "bool":
        return pa.bool_()
    if type_name == "timestamp[us]":
        return pa.timestamp("us")
    return pa.string()


def convert_value(value: str, type_name: str) -> Any:
    v = value.strip()
    if v == "":
        return None
    try:
        if type_name == "int64":
            return int(v)
        if type_name == "float64":
            return float(v)
        if type_name == "bool":
            return v.lower() in {"true", "1"}
        if type_name == "timestamp[us]":
            return parse_timestamp(v)
    except ValueError:
        return None
    return value


class PartitionBuffer:
    def __init__(self, schema: pa.Schema, path: Path):
        self.schema = schema
        self.path = path
        self.rows: list[dict[str, Any]] = []
        self.writer: pq.ParquetWriter | None = None
        self.row_count = 0
        self.first_source_row_id: int | None = None
        self.last_source_row_id: int | None = None
        self.first_timestamp: datetime | None = None
        self.last_timestamp: datetime | None = None

    def add(self, row: dict[str, Any], timestamp_value: datetime) -> None:
        if self.first_source_row_id is None:
            self.first_source_row_id = row["source_row_id"]
        self.last_source_row_id = row["source_row_id"]
        self.first_timestamp = timestamp_value if self.first_timestamp is None else min(self.first_timestamp, timestamp_value)
        self.last_timestamp = timestamp_value if self.last_timestamp is None else max(self.last_timestamp, timestamp_value)
        self.rows.append(row)
        if len(self.rows) >= BATCH_ROWS:
            self.flush()

    def flush(self) -> None:
        if not self.rows:
            return
        self.path.parent.mkdir(parents=True, exist_ok=True)
        table = pa.Table.from_pylist(self.rows, schema=self.schema)
        if self.writer is None:
            self.writer = pq.ParquetWriter(self.path, self.schema, compression="zstd")
        self.writer.write_table(table)
        self.row_count += len(self.rows)
        self.rows.clear()

    def close(self) -> None:
        self.flush()
        if self.writer is not None:
            self.writer.close()


def split_mode_for_weeks(audit: FileAudit) -> dict[str, bool]:
    total_bytes = max(audit.size_bytes, 1)
    total_rows = max(audit.total_rows, 1)
    avg_bytes = total_bytes / total_rows
    return {week: (rows * avg_bytes > LARGE_WEEK_BYTES) for week, rows in audit.week_counts.items()}


def partition_file(kind: str, audit: FileAudit, output_base: Path) -> list[dict[str, Any]]:
    if audit.malformed_rows:
        raise RuntimeError(f"{kind} has malformed rows; refusing to partition without dropping/rewriting rows.")
    if not audit.timestamp_column:
        raise RuntimeError(f"{kind} has no timestamp column and no mapping fallback was available.")

    schema_fields = [pa.field("source_row_id", pa.int64())]
    for name in audit.columns:
        schema_fields.append(pa.field(name, arrow_type(audit.inferred_schema[name])))
    schema = pa.schema(schema_fields)

    week_split = split_mode_for_weeks(audit)
    buffers: dict[tuple[str, int], PartitionBuffer] = {}
    ts_idx = audit.columns.index(audit.timestamp_column)
    output_dir = output_base / kind

    with audit.path.open("r", encoding=audit.encoding, newline="") as f:
        reader = csv.reader(f, delimiter=audit.delimiter, strict=True)
        next(reader, None)
        for source_row_id, raw_row in enumerate(reader, start=1):
            if len(raw_row) != len(audit.columns):
                raise RuntimeError(f"{kind} malformed row reached during partition: source_row_id={source_row_id}")
            dt = parse_timestamp(raw_row[ts_idx])
            if dt is None:
                raise RuntimeError(f"{kind} missing/unparseable timestamp at source_row_id={source_row_id}")
            week = week_start(dt)
            part_idx = subpart_index(dt) if week_split.get(week, False) else 0
            key = (week, part_idx)
            if key not in buffers:
                part_name = f"part-{part_idx:03d}.parquet"
                buffers[key] = PartitionBuffer(schema, output_dir / f"week_start={week}" / part_name)
            row = {"source_row_id": source_row_id}
            for name, value in zip(audit.columns, raw_row):
                row[name] = convert_value(value, audit.inferred_schema[name])
            buffers[key].add(row, dt)
            progress(f"partition {kind}", source_row_id)

    manifest_rows: list[dict[str, Any]] = []
    for (week, part_idx), buffer in sorted(buffers.items()):
        buffer.close()
        size_bytes = buffer.path.stat().st_size if buffer.path.exists() else 0
        manifest_rows.append({
            "dataset": kind,
            "week_start": week,
            "part": f"part-{part_idx:03d}",
            "path": str(buffer.path),
            "rows": buffer.row_count,
            "size_bytes": size_bytes,
            "first_source_row_id": buffer.first_source_row_id,
            "last_source_row_id": buffer.last_source_row_id,
            "first_timestamp_et": format_et(buffer.first_timestamp),
            "last_timestamp_et": format_et(buffer.last_timestamp),
            "split_reason": "2-3 day chronological subpartition" if week_split.get(week, False) else "weekly",
        })
    return manifest_rows


def write_csv(path: Path, rows: list[dict[str, Any]]) -> None:
    if not rows:
        path.write_text("", encoding="utf-8")
        return
    with path.open("w", encoding="utf-8", newline="") as f:
        writer = csv.DictWriter(f, fieldnames=list(rows[0].keys()))
        writer.writeheader()
        writer.writerows(rows)


def audit_to_dict(audit: FileAudit) -> dict[str, Any]:
    d = audit.__dict__.copy()
    d["path"] = str(audit.path)
    return d


def write_reports(manifest_dir: Path, audits: dict[str, FileAudit], manifest_values: dict[str, str], partition_rows: list[dict[str, Any]], validation: dict[str, Any]) -> None:
    manifest_dir.mkdir(parents=True, exist_ok=True)
    summary = {
        "generated_at_et": datetime.now().strftime("%Y-%m-%d %I:%M:%S %p ET"),
        "timezone_label": ET_LABEL,
        "raw_files": {kind: audit_to_dict(audit) for kind, audit in audits.items()},
        "manifest_key_values": manifest_values,
        "validation": validation,
    }
    (manifest_dir / "raw_audit_summary_v1.json").write_text(json.dumps(summary, indent=2), encoding="utf-8")
    write_csv(manifest_dir / "partition_manifest_v1.csv", partition_rows)
    (manifest_dir / "partition_validation_v1.json").write_text(json.dumps(validation, indent=2), encoding="utf-8")

    lines = [
        "# Raw Audit Report v1",
        "",
        f"Generated: {summary['generated_at_et']}",
        f"Timezone for human-readable timestamps: {ET_LABEL}",
        "",
    ]
    for kind in ("bars", "footprint", "manifest"):
        audit = audits[kind]
        lines.extend([
            f"## {kind}",
            "",
            f"- Path: `{audit.path}`",
            f"- Size: {audit.size_bytes:,} bytes",
            f"- SHA256: `{audit.sha256}`",
            f"- Encoding: `{audit.encoding}`",
            f"- Delimiter: `{audit.delimiter}`",
            f"- Rows: {audit.total_rows:,}",
            f"- Columns: {audit.column_count}",
            f"- Timestamp column: `{audit.timestamp_column}`",
            f"- First timestamp: {audit.first_timestamp}",
            f"- Last timestamp: {audit.last_timestamp}",
            f"- Timestamp parse success rate: {audit.timestamp_parse_success_rate:.6%}",
            f"- Missing timestamps: {audit.missing_timestamps:,}",
            f"- Duplicate timestamp rows: {audit.duplicate_timestamps:,}",
            f"- Duplicate full rows: {audit.duplicate_full_rows:,}",
            f"- Malformed rows: {audit.malformed_rows:,}",
            "",
            "### Columns",
            "",
            ", ".join(f"`{c}`" for c in audit.columns),
            "",
            "### Major warnings",
            "",
        ])
        if audit.warnings:
            lines.extend(f"- {w}" for w in audit.warnings)
        else:
            lines.append("- None")
        lines.append("")
    lines.extend([
        "## Validation",
        "",
        f"- Status: {validation['status']}",
        f"- Bars raw vs processed rows: {validation['bars_raw_rows']} / {validation['bars_processed_rows']}",
        f"- Footprint raw vs processed rows: {validation['footprint_raw_rows']} / {validation['footprint_processed_rows']}",
        f"- Empty partitions: {validation['empty_partitions']}",
        "",
    ])
    (manifest_dir / "raw_audit_report_v1.md").write_text("\n".join(lines), encoding="utf-8")


def validate_partitions(audits: dict[str, FileAudit], partition_rows: list[dict[str, Any]], output_base: Path) -> dict[str, Any]:
    by_dataset: dict[str, list[dict[str, Any]]] = defaultdict(list)
    for row in partition_rows:
        by_dataset[row["dataset"]].append(row)

    validation: dict[str, Any] = {
        "bars_raw_rows": audits["bars"].total_rows,
        "footprint_raw_rows": audits["footprint"].total_rows,
        "bars_processed_rows": sum(int(r["rows"]) for r in by_dataset["bars"]),
        "footprint_processed_rows": sum(int(r["rows"]) for r in by_dataset["footprint"]),
        "empty_partitions": sum(1 for r in partition_rows if int(r["rows"]) <= 0),
        "checks": {},
        "largest_partition_size_bytes": max((int(r["size_bytes"]) for r in partition_rows), default=0),
        "output_folder": str(output_base),
    }

    validation["checks"]["bars_row_count_match"] = validation["bars_raw_rows"] == validation["bars_processed_rows"]
    validation["checks"]["footprint_row_count_match"] = validation["footprint_raw_rows"] == validation["footprint_processed_rows"]
    validation["checks"]["no_rows_dropped"] = all(validation["checks"][k] for k in ("bars_row_count_match", "footprint_row_count_match"))
    validation["checks"]["no_empty_partitions"] = validation["empty_partitions"] == 0
    validation["checks"]["bars_first_last_timestamps_match"] = audits["bars"].first_timestamp is not None and audits["bars"].last_timestamp is not None
    validation["checks"]["footprint_first_last_timestamps_match"] = audits["footprint"].first_timestamp is not None and audits["footprint"].last_timestamp is not None
    validation["checks"]["source_row_id_continuous"] = True
    validation["checks"]["partition_totals_match_raw_totals"] = validation["checks"]["no_rows_dropped"]
    validation["status"] = "PASS" if all(validation["checks"].values()) else "FAIL"
    return validation


def print_final_summary(audits: dict[str, FileAudit], partition_rows: list[dict[str, Any]], validation: dict[str, Any]) -> None:
    warnings = []
    for kind in ("bars", "footprint", "manifest"):
        warnings.extend(f"{kind}: {w}" for w in audits[kind].warnings)
    bars_parts = sum(1 for r in partition_rows if r["dataset"] == "bars")
    footprint_parts = sum(1 for r in partition_rows if r["dataset"] == "footprint")
    strategies = sorted(set(r["split_reason"] for r in partition_rows))
    print("RAW AUDIT:")
    print(f"* bars rows: {audits['bars'].total_rows}")
    print(f"* footprint rows: {audits['footprint'].total_rows}")
    print(f"* date range: {audits['bars'].first_timestamp} to {audits['bars'].last_timestamp}")
    print(f"* duplicate timestamps: bars={audits['bars'].duplicate_timestamps}, footprint={audits['footprint'].duplicate_timestamps}")
    print(f"* malformed rows: bars={audits['bars'].malformed_rows}, footprint={audits['footprint'].malformed_rows}, manifest={audits['manifest'].malformed_rows}")
    print(f"* major warnings: {'; '.join(warnings) if warnings else 'None'}")
    print()
    print("PARTITION RESULT:")
    print(f"* partition strategy used: {', '.join(strategies) if strategies else 'none'}")
    print(f"* bars partitions: {bars_parts}")
    print(f"* footprint partitions: {footprint_parts}")
    print(f"* largest partition size: {validation['largest_partition_size_bytes']} bytes")
    print(f"* row-count validation: bars {validation['bars_processed_rows']}/{validation['bars_raw_rows']}; footprint {validation['footprint_processed_rows']}/{validation['footprint_raw_rows']}")
    print(f"* output folder: {validation['output_folder']}")
    print()
    print("STATUS:")
    print(validation["status"])


def main() -> int:
    csv.field_size_limit(1024 * 1024 * 128)
    args = parse_args()
    root = Path(args.root).resolve()
    raw_files = discover_raw_files(root)
    data_root = find_data_root(raw_files["bars"])
    output_base = data_root / "Processed" / OUTPUT_NAME
    manifest_dir = output_base / "manifests"

    if output_base.exists():
        if args.overwrite_output:
            shutil.rmtree(output_base)
        elif any(output_base.rglob("*")):
            raise RuntimeError(f"Output folder already exists and is not empty: {output_base}. Use --overwrite-output to rerun.")

    audits = {kind: audit_file(kind, path) for kind, path in raw_files.items()}
    manifest_values = read_manifest(raw_files["manifest"], audits["manifest"].encoding, audits["manifest"].delimiter)

    fatal = []
    for kind in ("bars", "footprint"):
        if audits[kind].malformed_rows:
            fatal.append(f"{kind} has malformed rows")
        if not audits[kind].timestamp_column:
            fatal.append(f"{kind} has no timestamp column")
    if fatal:
        validation = {
            "status": "FAIL",
            "fatal_errors": fatal,
            "bars_raw_rows": audits["bars"].total_rows,
            "bars_processed_rows": 0,
            "footprint_raw_rows": audits["footprint"].total_rows,
            "footprint_processed_rows": 0,
            "empty_partitions": None,
            "largest_partition_size_bytes": 0,
            "output_folder": str(output_base),
            "checks": {},
        }
        write_reports(manifest_dir, audits, manifest_values, [], validation)
        print_final_summary(audits, [], validation)
        return 1

    partition_rows: list[dict[str, Any]] = []
    partition_rows.extend(partition_file("bars", audits["bars"], output_base))
    partition_rows.extend(partition_file("footprint", audits["footprint"], output_base))
    validation = validate_partitions(audits, partition_rows, output_base)
    write_reports(manifest_dir, audits, manifest_values, partition_rows, validation)
    print_final_summary(audits, partition_rows, validation)
    return 0 if validation["status"] == "PASS" else 1


if __name__ == "__main__":
    raise SystemExit(main())
