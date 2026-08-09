#!/usr/bin/env bash
# Pass all arguments to the Python script located in the same directory.
exec uv run --project "$(dirname "$0")" --locked --no-sync \
    python "$(dirname "$0")/pymakefile.py" "$@"
