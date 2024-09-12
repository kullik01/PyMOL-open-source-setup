#
# PyMOL-open-source-setup
# Copyright (C) 2024
# Hannah Kullik (hannah.kullik@studmail.w-hs.de)
#
# Source code is available at <https://github.com/kullik01/PyMOL-open-source-setup>
#
# This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <http://www.gnu.org/licenses/>.
#
import pathlib
import subprocess

from invoke import task


@task()
def build(c):
  try:
    tmp_inno_setup_compiler_exe = pathlib.Path("C:/Program Files (x86)/Inno Setup 6/ISCC.exe")
    tmp_project_root_dir = pathlib.Path(__file__).parent.absolute()
    subprocess.run([str(tmp_inno_setup_compiler_exe), f"{tmp_project_root_dir}\\src\\inno_setup\\setup.iss"], shell=True, check=True)
  except Exception as e:
    print(e)
  finally:
    print("Finished task build.")
