import pathlib
import shutil
import subprocess

from invoke import task


@task()
def build(c):
  try:
    tmp_inno_setup_compiler_exe = pathlib.Path("C:/Program Files (x86)/Inno Setup 6/ISCC.exe")
    tmp_project_root_dir = pathlib.Path(__file__).parent.absolute()
    # tmp_input_dir = pathlib.Path(f"{tmp_project_root_dir}/src/inno_setup/input")
    # if not tmp_inno_setup_compiler_exe.exists():
    #   print("Inno Setup Compiler could not be found.")
    #   return
    # tmp_input_dir.mkdir(parents=True, exist_ok=True)
    #
    # tmp_post_installation_runner_exe = pathlib.Path(f"{tmp_project_root_dir}/src/c_sharp/PostInstallationRunner/bin/Release/net8.0/publish/win-x64/PostInstallationRunner.exe")
    # shutil.copyfile(tmp_post_installation_runner_exe, tmp_input_dir / "PostInstallationRunner.exe")
    #
    # tmp_windows_package_zip = pathlib.Path(f"{tmp_input_dir}/windows_package.zip")
    # tmp_powershell_command = f"Compress-Archive -Path {tmp_project_root_dir}\\resources\\* -DestinationPath {tmp_windows_package_zip} -Force"
    # c.run(f"powershell -Command {tmp_powershell_command}")
    #
    # tmp_logo_file = pathlib.Path(f"{tmp_project_root_dir}/assets/logo.ico")
    # shutil.copyfile(tmp_logo_file, tmp_input_dir / "logo.ico")
    subprocess.run([str(tmp_inno_setup_compiler_exe), f"{tmp_project_root_dir}\\src\\inno_setup\\setup.iss"], shell=True, check=True)
  except Exception as e:
    print(e)
  finally:
    # if tmp_input_dir.exists():
    #   print("Cleaning up...")
    #   shutil.rmtree(tmp_input_dir)
    print("Finished task build.")
