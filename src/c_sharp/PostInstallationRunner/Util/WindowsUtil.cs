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
/// Contains utilities for Windows.
/// </summary>
public class WindowsUtil
{
    /// <summary>
    /// Installs the VC_redist.x64.exe.
    /// </summary>
    /// <returns>
    /// True if the process executed without errors, otherwise false. 
    /// </returns>
    public bool InstallVcRedist()
    {
        try
        {
            if (!File.Exists(ConstantPaths.VC_REDIST_EXE))
            {
                return false;
            }
            Process tmpProcess = new Process();
            tmpProcess.StartInfo.FileName = ConstantPaths.VC_REDIST_EXE;
            tmpProcess.Start();
            tmpProcess.WaitForExit();

            if (tmpProcess.ExitCode == 0)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}
