import sys
import tempfile
import unittest
from pathlib import Path
from unittest import mock

import pymakefile


class PymakeBuildTaskTest(unittest.TestCase):

  def test_platform_build_paths(self) -> None:
    with mock.patch.object(pymakefile.platform, "system", return_value="Darwin"):
      with mock.patch.object(
          pymakefile.sysconfig,
          "get_path",
          return_value="/tmp/venv/lib/python3.11/site-packages",
      ):
        platform_dir, package_dir, build_command = (
          pymakefile._platform_build_paths()
        )

    self.assertEqual(platform_dir, pymakefile._PROJECT_ROOT / "os_specific/macos")
    self.assertEqual(
      package_dir,
      Path("/tmp/venv/lib/python3.11/site-packages/pymol"),
    )
    self.assertEqual(build_command, "bdist_mac")

  def test_build_app_copies_customizations_and_artifacts(self) -> None:
    with tempfile.TemporaryDirectory() as temporary_directory:
      root = Path(temporary_directory)
      package_dir = root / "venv/lib/python3.11/site-packages/pymol"
      (package_dir / "data/pymol/icons").mkdir(parents=True)
      (package_dir.parent / "pmg_qt").mkdir()
      (root / "edited/pmg_qt").mkdir(parents=True)
      (root / "edited/pymol/data/pymol").mkdir(parents=True)
      (root / "alternative_design").mkdir()
      (root / "os_specific/linux").mkdir(parents=True)
      (root / "os_specific/linux/build").mkdir()
      (root / "os_specific/linux/build/artifact").write_text("built")

      source_paths = (
        root / "edited/pmg_qt/pymol_qt_gui.py",
        root / "edited/pymol/data/pymol/base.css",
        root / "edited/pymol/__init__.py",
        root / "edited/pymol/startup_wrapper.py",
        root / "alternative_design/alt_logo.png",
        root / "os_specific/linux/splash.png",
      )
      for source_path in source_paths:
        source_path.write_text(source_path.name)

      with mock.patch.object(pymakefile, "_PROJECT_ROOT", root):
        with mock.patch.object(
            pymakefile.platform, "system", return_value="Linux"
        ):
          with mock.patch.object(
              pymakefile.sysconfig,
              "get_path",
              return_value=str(package_dir.parent),
          ):
            with mock.patch.object(pymakefile, "_run_process") as run_process:
              pymakefile.build_app()

      self.assertTrue((package_dir / "base.css").exists())
      self.assertTrue((package_dir / "startup_wrapper.py").exists())
      self.assertTrue((package_dir / "data/pymol/splash.png").exists())
      self.assertTrue((root / "dist/artifact").exists())
      run_process.assert_called_once()
      self.assertEqual(run_process.call_args.kwargs["cwd"], root / "os_specific/linux")

  def test_prepare_inno_setup_creates_staging_tree(self) -> None:
    with tempfile.TemporaryDirectory() as temporary_directory:
      root = Path(temporary_directory)
      app_build = root / f"dist/exe.win-amd64-{sys.version_info.major}.{sys.version_info.minor}"
      app_build.mkdir(parents=True)
      (app_build / "Open-Source-PyMOL.exe").write_text("built")
      (root / "os_specific/windows").mkdir(parents=True)
      (root / "os_specific/windows/logo.ico").write_text("logo")
      (root / "vendor/microsoft").mkdir(parents=True)
      (root / "vendor/microsoft/VC_redist.x64.exe").write_text("redist")

      with mock.patch.object(pymakefile, "_PROJECT_ROOT", root):
        pymakefile._prepare_inno_setup_environment()

      staging = root / "inno-build-release"
      self.assertTrue(
        (staging / "inno-sources/Open-Source-PyMOL.exe").exists()
      )
      self.assertTrue(
        (staging / "inno-sources/VC_redist.x64.exe").exists()
      )
      self.assertTrue((staging / "inno-assets/logo.ico").exists())

  def test_build_inno_setup_rejects_unknown_architecture(self) -> None:
    with mock.patch.object(pymakefile.platform, "system", return_value="Windows"):
      with self.assertRaises(ValueError):
        pymakefile.build_inno_setup("arm64")

  def test_run_accepts_explicit_working_directory(self) -> None:
    with mock.patch.object(pymakefile.subprocess, "run") as run_process:
      pymakefile.run("pytest", cwd=pymakefile._PROJECT_ROOT)

    self.assertEqual(
      run_process.call_args.kwargs["cwd"],
      pymakefile._PROJECT_ROOT,
    )


if __name__ == "__main__":
  unittest.main()
