//
// PyMOL-open-source-setup
// Copyright (C) 2024
// Hannah Kullik (hannah.kullik@studmail.w-hs.de)
//
// Source code is available at <https://github.com/kullik01/PyMOL-open-source-setup>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
namespace PostInstallationRunner.Util;

public class ConstantPaths
{
    /// <summary>
    /// Path of the AppData directory.
    /// </summary>
    public static readonly string APP_DATA_DIR = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    /// <summary>
    /// Program folder of PyMOL-open-source.
    /// </summary>
    public static readonly string PYMOL_PROGRAM_DIR = $@"{APP_DATA_DIR}\PyMOL-open-source";
    /// <summary>
    /// Path of the global temp directory.
    /// </summary>
    public static readonly string TEMP_DIR = $@"{PYMOL_PROGRAM_DIR}\temp";
    /// <summary>
    /// Filepath of the VC_redist.x64.exe for PyMOL-open-source.
    /// </summary>
    public static readonly string VC_REDIST_EXE = $@"{TEMP_DIR}\VC_redist.x64.exe";
    /// <summary>
    /// Filepath of the windows_package.zip for PyMOL-open-source.
    /// </summary>
    public static readonly string WINDOWS_PACKAGE_ZIP = $@"{TEMP_DIR}\windows_package.zip";
    /// <summary>
    /// Filepath of the PyMOL-open-source windows icon.
    /// </summary>
    public static readonly string PYMOL_ICON_FILEPATH = $@"{PYMOL_PROGRAM_DIR}\assets\logo.ico";
    /// <summary>
    /// Program folder of PyMOL-open-source.
    /// </summary>
    public static readonly string PYMOL_PROGRAM_BIN_DIR = $@"{PYMOL_PROGRAM_DIR}\bin";
    /// <summary>
    /// File for batch of PyMOL-open-source.
    /// </summary>
    public static readonly string SETUP_PYTHON_BAT = $@"{PYMOL_PROGRAM_BIN_DIR}\setup_python_for_pymol\setup_python.bat";
    /// <summary>
    /// Path of the pymol.exe file.
    /// </summary>
    public static readonly string PYMOL_EXE_FILEPATH = $@"{PYMOL_PROGRAM_BIN_DIR}\.venv\Scripts\pymol.exe";
    /// <summary>
    /// Filepath of the pip executable file.
    /// </summary>
    public static readonly string PIP_FILEPATH = $@"{PYMOL_PROGRAM_BIN_DIR}\.venv\Scripts\pip.exe";
}
