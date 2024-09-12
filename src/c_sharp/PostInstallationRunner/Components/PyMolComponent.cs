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
using PostInstallationRunner.Util;

namespace PostInstallationRunner.Components;

/// <summary>
/// Represents a class of the PyMOL component.
/// </summary>
public class PyMolComponent : IComponent
{
    /// <summary>
    /// Installs PyMOL.
    /// </summary>
    /// <returns>
    /// True if installation is successful, otherwise false.
    /// </returns>
    public bool Install()
    {
        if (!SetupPythonEnvironment())
        {
            return false;
        }
        if (!CreateWindowsShortcuts())
        {
            return false;
        }
        if (!PostInstallCleanup())
        {
            return false;
        }
        return true;
    }
    
    #region Helper methods
    /// <summary>
    /// Creates Windows shortcuts for the PyMOL-open-source application.
    /// </summary>
    /// <returns>True if the operation is successful, otherwise false.</returns>
    private bool CreateWindowsShortcuts()
    {
        try
        {
            // Specify the details for the shortcut to be created
            string shortcutName = "PyMOL-open-source";
            string iconPath = ConstantPaths.PYMOL_ICON_FILEPATH;
            // Create desktop icon
            SystemEntryHandler.CreateDesktopShortcut(ConstantPaths.PYMOL_EXE_FILEPATH, shortcutName, iconPath);
            // Create start menu entry
            SystemEntryHandler.CreateStartMenuShortcut(ConstantPaths.PYMOL_EXE_FILEPATH, shortcutName, iconPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        
        return true;
    }

    /// <summary>
    /// Sets up the python virtual environment (.venv).
    /// </summary>
    /// <returns>
    /// True if the python virtual environment is successfully set up, otherwise false.
    /// </returns>
    private bool SetupPythonEnvironment()
    {
        try
        {
            PythonUtil tmpPythonUtil = new PythonUtil();
            if (!tmpPythonUtil.SetupVenv())
            {
                return false;
            }
            if (!tmpPythonUtil.PipWheelInstall($@"{ConstantPaths.TEMP_DIR}\Pmw-2.1.1.tar.gz"))
            {
                return false;
            }
            if (!tmpPythonUtil.PipWheelInstall($@"{ConstantPaths.TEMP_DIR}\pymol-3.0.0-cp311-cp311-win_amd64.whl"))
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Removes all temporary files.
    /// </summary>
    /// <returns>
    /// True if the process was successful, otherwise false.
    /// </returns>
    private bool PostInstallCleanup()
    {
        try
        {
            Directory.Delete(ConstantPaths.TEMP_DIR, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        return true;
    }

    #endregion

    /// <summary>
    /// Uninstalls PyMOL-open-source.
    /// </summary>
    /// <returns>
    /// True if PyMOL-open-source is successfully uninstalled, otherwise false.
    /// </returns>
    public bool Uninstall()
    {
        try
        {
            string shortcutName = "PyMOL-open-source";
            SystemEntryHandler.RemoveShortcut(Environment.SpecialFolder.DesktopDirectory, shortcutName);
            SystemEntryHandler.RemoveShortcut(Environment.SpecialFolder.StartMenu, shortcutName);
            Directory.Delete(ConstantPaths.PYMOL_PROGRAM_DIR, true);
        }
        catch (UnauthorizedAccessException ex)
        {
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if PyMOL is installed.
    /// </summary>
    /// <returns>
    /// True if PyMOL is installed, otherwise false.
    /// </returns>
    public bool IsInstalled()
    {
        try
        {
            return Directory.Exists(ConstantPaths.PYMOL_EXE_FILEPATH);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}
