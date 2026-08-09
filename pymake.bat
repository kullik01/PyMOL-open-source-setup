@echo off
uv run --project "%~dp0." --locked --no-sync python "%~dp0pymakefile.py" %*
exit /b %ERRORLEVEL%
