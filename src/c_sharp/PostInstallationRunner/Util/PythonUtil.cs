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
using System.Diagnostics;

namespace PostInstallationRunner.Util;

/// <summary>
/// Contains utilities for python.
/// </summary>
public class PythonUtil
{   
    /// <summary>
    /// Sets up the virtual environment.
    /// </summary>
    /// <returns>
    /// True if the process executed without errors, otherwise false. 
    /// </returns>
    public bool SetupVenv()
    {
        try
        {
            Process tmpProcess = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    CreateNoWindow = Constants.CMD_NO_WINDOW_DEBUG,
                    Arguments = $"/C {ConstantPaths.SETUP_PYTHON_BAT}"
                }
            };
            tmpProcess.Start();
            tmpProcess.WaitForExit();
            if (tmpProcess.ExitCode == 0)
            {
                return true;
            }
            return false;
            // TODO: Add method that checks, if the batch script was successful!
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    
    /// <summary>
    /// Installs a Python wheel using pip.
    /// </summary>
    /// <param name="aWheelFilepath">The filepath of the wheel file to install.</param>
    /// <exception cref="ArgumentNullException">Thrown if aWheelFilepath is null.</exception>
    /// <exception cref="ArgumentException">Thrown if aWheelFilepath does not exist.</exception>
    /// <returns>Returns true if the installation was successful; otherwise, returns false.</returns>
    public bool PipWheelInstall(string aWheelFilepath)
    {
        #region Checks

        if (aWheelFilepath is null)
        {
            throw new ArgumentNullException();
        }

        if (!File.Exists(aWheelFilepath))
        {
            throw new ArgumentException("aWheelFilepath does not exist.");
        }

        #endregion
        
        try
        {
            Process tmpProcess = new Process
            {
                StartInfo =
                {
                    FileName = ConstantPaths.PIP_FILEPATH,
                    UseShellExecute = false,
                    CreateNoWindow = Constants.CMD_NO_WINDOW_DEBUG,
                    Arguments = $"install {aWheelFilepath}"
                }
            };
            tmpProcess.Start();
            tmpProcess.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }

        return true;
    }
}
