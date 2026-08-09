#!/usr/bin/env python3
# pymake - A zero-dependency, Python-based task runner
# -------------------------------------------------------------------
# This file contains source code for the pymake computer program
# Copyright (C) 2025 Martin Urban (martin.urban@studmail.w-hs.de)
# Source code is available at <https://github.com/urban233/pymake>
# -------------------------------------------------------------------
# It is unlawful to modify or remove this copyright notice.
# -------------------------------------------------------------------
# Please see the accompanying LICENSE file for further information.
# -------------------------------------------------------------------
# Additional authors of this source file include:
#
# ==============================================================================
#
"""Standalone Python task runner.

A zero-dependency, production-ready task runner that replicates the ergonomics
of tools like ``invoke`` or GNU ``make`` using only the Python standard library.
Tasks are plain Python functions decorated with ``@task``; the CLI dispatcher
parses positional and keyword arguments and routes execution accordingly.

Typical usage::

    chmod +x pymake.bat/sh

    ./pymake.bat/sh                   # Print the help menu
    ./pymake.bat/sh test              # Run with defaults
    ./pymake.bat/sh test verbose=true # Pass keyword argument
    ./pymake.bat/sh build env=prod    # Override default keyword argument

Design principles:
    - **Portability**: Only the Python standard library is used (Python ≥ 3.8).
    - **Discoverability**: ``--help`` / ``-h`` renders a formatted task menu
      derived from each task's docstring automatically.
    - **Composability**: Tasks are ordinary functions; calling one task from
      another is idiomatic Python—no special API is required.
    - **Fail-fast**: Shell commands raise immediately on non-zero exit codes
      unless ``check=False`` is explicitly requested.
    - **Style compliance**: Follows the `Google Python Style Guide
      <https://google.github.io/styleguide/pyguide.html>`_ throughout.
"""

import inspect
import shlex
import subprocess

import sys
import textwrap
from typing import Callable, Dict, List, Optional, Tuple

# <editor-fold desc="pymake">
# <editor-fold desc="Type aliases">
# A task callable as stored in the registry.
_TaskFunc = Callable[..., None]
# </editor-fold>

# <editor-fold desc="Module-level task registry">
# Maps task name → registered callable.  Insertion order is preserved (Python
# 3.7+) so the help menu reflects the order tasks are declared in the file.
_TASKS: Dict[str, _TaskFunc] = {}
# </editor-fold>

# <editor-fold desc="ANSI color helpers">
# Colour codes used for terminal output.  These are intentionally kept as
# simple constants rather than a third-party library to preserve portability.
_COLOR_GREY = "\033[90m"
_COLOR_RED = "\033[91m"
_COLOR_GREEN = "\033[92m"
_COLOR_YELLOW = "\033[93m"
_COLOR_RESET = "\033[0m"
# </editor-fold>


def _colorize(text: str, color_code: str) -> str:
  """Wraps ``text`` in the given ANSI ``color_code`` and a reset sequence.

  When stdout is not a TTY (e.g. a CI log file or a pipe) the raw text is
  returned unchanged so log output stays human-readable without escape noise.

  Args:
      text: The string to colorise.
      color_code: An ANSI escape sequence string, e.g. ``"\\033[90m"``.

  Returns:
      The colorised string when connected to a TTY; otherwise ``text``
      unchanged.
  """
  if sys.stdout.isatty():
    return f"{color_code}{text}{_COLOR_RESET}"
  return text


def task(func: _TaskFunc) -> _TaskFunc:
  """Registers a callable as a named CLI task.

  The function name becomes the task's CLI name.  Its signature drives
  argument parsing and its docstring populates the ``--help`` output.

  Example:

      @task
      def lint(fix: str = "false") -> None:
          '''Lint the codebase. Pass fix=true to auto-fix issues.'''
          run(f"ruff check {'--fix' if fix == 'true' else ''} .")

  Args:
      func: The function to register.  Must accept only positional and/or
          keyword parameters with default values; ``*args`` / ``**kwargs``
          are unsupported.

  Returns:
      The original ``func`` unmodified (the decorator is transparent).

  Raises:
      ValueError: If a task with the same name has already been registered,
          which typically indicates a copy-paste error in the task file.
  """
  if func.__name__ in _TASKS:
    raise ValueError(
      f"Duplicate task name '{func.__name__}': a task with this name is "
      "already registered.  Rename one of the conflicting functions."
    )
  _TASKS[func.__name__] = func
  return func


def run(
        cmd: str,
        *,
        check: bool = True,
        capture: bool = False,
        env: Optional[Dict[str, str]] = None,
) -> Optional[str]:
  """Executes a shell command, printing it to stdout before running.

  This helper is the primary interface for invoking external processes from
  within tasks.  It mirrors the ergonomics of ``invoke.run`` while remaining
  standard-library-only.

  The command is printed in grey before execution so developers can trace
  exactly which shell invocations a composite task triggers.  When ``check``
  is ``True`` (the default) a non-zero exit code raises
  ``subprocess.CalledProcessError``, which propagates up and terminates the
  runner with a non-zero exit status—consistent with GNU Make semantics.

  Args:
      cmd: The shell command string to execute.  Passed to ``/bin/sh -c``
          (or the platform equivalent) via ``shell=True``.
      check: If ``True`` (default), raise ``subprocess.CalledProcessError``
          on non-zero exit code.  Set to ``False`` to tolerate failures.
      capture: If ``True``, capture stdout and return it as a stripped
          string instead of streaming it to the terminal.  Useful when the
          output of a command is needed programmatically.
      env: Optional mapping of environment variables to pass to the child
          process.  When ``None``, the parent environment is inherited.

  Returns:
      The captured stdout string (stripped of leading/trailing whitespace)
      when ``capture=True``.  ``None`` otherwise.

  Raises:
      subprocess.CalledProcessError: When ``check=True`` and the command
          exits with a non-zero status code.

  Example:

      # Stream output to terminal (most common usage).
      run("pytest -v")

      # Capture and use programmatically.
      git_hash = run("git rev-parse --short HEAD", capture=True)
      print(f"Current commit: {git_hash}")

      # Tolerate failure (e.g. optional clean-up step).
      run("pkill -f my_server", check=False)
  """
  print(_colorize(f"$ {cmd}", _COLOR_GREY))
  result = subprocess.run(
    cmd,
    shell=True,
    check=check,
    capture_output=capture,
    text=True,
    env=env,
  )
  if capture:
    return result.stdout.strip()
  return None


def _parse_args(argv: List[str]) -> Tuple[List[str], Dict[str, str]]:
  """Splits a list of CLI tokens into positional args and keyword args.

  Keyword arguments may be supplied in any of the following formats::

      key=value          # bare assignment
      --key=value        # GNU long-option style

  All other tokens are treated as positional arguments and returned in order.

  Args:
      argv: A list of raw CLI tokens *excluding* the program name and the
          task name (i.e. ``sys.argv[2:]``).

  Returns:
      A two-tuple ``(positional_args, keyword_args)`` where:
          - ``positional_args`` is a ``list[str]`` of values without ``=``.
          - ``keyword_args`` is a ``dict[str, str]`` of stripped key/value
            pairs.

  Example:

      >>> _parse_args(["--env=prod", "extra"])
      (['extra'], {'env': 'prod'})
  """
  positional: List[str] = []
  keyword: Dict[str, str] = {}

  for token in argv:
    if "=" in token:
      # Strip any leading dashes to normalise ``--key=value`` → ``key``.
      raw_key, _, value = token.partition("=")
      key = raw_key.lstrip("-")
      keyword[key] = value
    else:
      positional.append(token)

  return positional, keyword


def _build_help_text() -> str:
  """Constructs the formatted help string for the ``--help`` output.

  Iterates over the task registry in insertion order, extracting each task's
  signature and the first non-blank line of its docstring to build a compact
  usage table.

  Returns:
      A multi-line string ready to be printed to stdout.
  """
  lines: List[str] = [
    "",
    _colorize("Available tasks", _COLOR_GREEN),
    _colorize("=" * 60, _COLOR_GREY),
  ]

  for name, func in _TASKS.items():
    sig = inspect.signature(func)
    params = list(sig.parameters.values())

    # Build a compact parameter hint, e.g. ``[env=dev] [verbose=false]``.
    param_hints: List[str] = []
    for param in params:
      if param.default is inspect.Parameter.empty:
        param_hints.append(f"<{param.name}>")
      else:
        param_hints.append(f"[{param.name}={param.default!r}]")

    usage_suffix = (" " + " ".join(param_hints)) if param_hints else ""
    heading = _colorize(f"  {name}{usage_suffix}", _COLOR_YELLOW)
    lines.append(heading)

    # Emit the full docstring (minus the first line already shown in the
    # heading) indented for readability.
    raw_doc = (func.__doc__ or "").strip()
    if raw_doc:
      # ``textwrap.dedent`` normalises inconsistent indentation from
      # triple-quoted strings.
      doc_lines = textwrap.dedent(raw_doc).splitlines()
      for doc_line in doc_lines:
        lines.append(f"      {doc_line}")

    lines.append("")  # Blank line between tasks.

  lines.append(_colorize("=" * 60, _COLOR_GREY))
  lines.append(f"  Usage: {sys.argv[0]} <task> [positional] [key=value ...]")
  lines.append("")
  return "\n".join(lines)


def _main() -> None:
  """CLI entry point: parses ``sys.argv`` and dispatches to the named task.

  Flow:
      1. No arguments, ``-h``, or ``--help`` → print the help menu and exit 0.
      2. Unknown task name → print an error and exit 1.
      3. Valid task with well-formed arguments → invoke the task function.
      4. Argument mismatch (``TypeError``) → print a usage hint and exit 1.
      5. ``subprocess.CalledProcessError`` from a ``run()`` call → print the
         failing command and exit with the command's own exit code.
      6. ``KeyboardInterrupt`` → exit 130 (SIGINT convention).

  Raises:
      SystemExit: Always; exit code 0 on success, non-zero on any error.
  """
  # ------------------------------------------------------------------
  # Help / no-argument path
  # ------------------------------------------------------------------
  if len(sys.argv) < 2 or sys.argv[1] in ("-h", "--help"):
    print(_build_help_text())
    sys.exit(0)

  task_name = sys.argv[1]

  # ------------------------------------------------------------------
  # Task lookup
  # ------------------------------------------------------------------
  if task_name not in _TASKS:
    # Offer a helpful suggestion when the name is close to a known task.
    suggestions = [
      name for name in _TASKS if task_name.lower() in name.lower()
    ]
    msg = _colorize(f"Error: Unknown task '{task_name}'.", _COLOR_RED)
    print(msg, file=sys.stderr)
    if suggestions:
      print(
        _colorize(
          f"  Did you mean: {', '.join(suggestions)}?",
          _COLOR_YELLOW,
        ),
        file=sys.stderr,
      )
    else:
      print(
        f"  Run '{sys.argv[0]} --help' to list available tasks.",
        file=sys.stderr,
      )
    sys.exit(1)

  # ------------------------------------------------------------------
  # Argument parsing and dispatch
  # ------------------------------------------------------------------
  positional, keyword = _parse_args(sys.argv[2:])
  func = _TASKS[task_name]

  try:
    func(*positional, **keyword)
  except TypeError as exc:
    # Likely an arity mismatch; print a context-rich usage hint.
    print(
      _colorize(f"Argument error: {exc}", _COLOR_RED),
      file=sys.stderr,
    )
    sig = inspect.signature(func)
    print(
      _colorize(
        f"  Usage: {sys.argv[0]} {task_name}{sig}",
        _COLOR_YELLOW,
      ),
      file=sys.stderr,
    )
    sys.exit(1)
  except subprocess.CalledProcessError as exc:
    # A shell command failed; exit with its own return code so that CI
    # pipelines receive a meaningful exit status.
    print(
      _colorize(
        f"Command failed (exit {exc.returncode}): {exc.cmd}",
        _COLOR_RED,
      ),
      file=sys.stderr,
    )
    sys.exit(exc.returncode)
  except KeyboardInterrupt:
    # Conventional exit code for SIGINT.
    print(_colorize("\nInterrupted.", _COLOR_YELLOW), file=sys.stderr)
    sys.exit(130)


# </editor-fold>

# <editor-fold desc="Tasks">
@task
def format(check: str = "false") -> None:  # noqa: A001  (shadows builtin intentionally)
  """Format the codebase with Ruff.

  Runs `Ruff <https://docs.astral.sh/ruff/>`_ in either reformat or
  check-only mode.

  Args:
      check: Pass ``check=true`` to run Ruff format in ``--check`` mode (exit
          non-zero if any file would be reformatted) without modifying files.
          Useful for CI gating.  Defaults to ``"false"`` (reformat in place).

  Example:

      ./pymake.bat/sh format            # Reformat in place.
      ./pymake.bat/sh format check=true # CI dry-run; fail if changes needed.
  """
  flag = "--check" if check.lower() == "true" else ""
  run(f"ruff format {flag} .")


@task
def lint(fix: str = "false") -> None:
  """Run static analysis with Ruff.

  Executes `Ruff <https://docs.astral.sh/ruff/>`_ across the entire project
  tree using the configuration defined in ``ruff.toml``.

  Args:
      fix: Pass ``fix=true`` to automatically fix lint violations where
          possible.  Defaults to ``"false"``.
  """
  flag = "--fix" if fix.lower() == "true" else ""
  run(f"ruff check {flag} .")


@task
def check_types() -> None:
  """Run static type checking with mypy.

  Executes `mypy <https://mypy-lang.org/>`_ across the project
  to verify type safety based on the configuration in ``mypy.ini``.
  """
  run("mypy")


@task
def test(match: str = "", verbose: str = "false") -> None:
  """Execute the test suite with pytest.

  Runs all tests discovered by ``pytest`` from the current directory.
  Optional filters allow targeted execution during development.

  Args:
      match: A ``-k`` expression passed directly to pytest to select tests
          by name substring or marker expression (e.g. ``match=api``).
          Defaults to ``""`` (run all tests).
      verbose: Pass ``verbose=true`` to enable ``-v`` output, which prints
          each test's full node ID and outcome.  Defaults to ``"false"``.

  Example:

      ./pymake.bat/sh test                       # Run all tests.
      ./pymake.bat/sh test match=auth            # Only tests matching 'auth'.
      ./pymake.bat/sh test verbose=true          # Verbose output.
      ./pymake.bat/sh test match=api verbose=true
  """
  cmd_parts: List[str] = ["pytest"]
  if verbose.lower() == "true":
    cmd_parts.append("-v")
  if match:
    # Use shlex.quote to prevent accidental shell injection from the match
    # expression while still allowing pytest expressions like 'api or db'.
    cmd_parts.extend(["-k", shlex.quote(match)])
  run(" ".join(cmd_parts))

# </editor-fold>

# <editor-fold desc="main">
if __name__ == "__main__":
  _main()
# </editor-fold>
