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
using PostInstallationRunner.Components;
using PostInstallationRunner.Util;

namespace PostInstallationRunner;

/// <summary>
/// Contains the main method.
/// </summary>
class Program
{
    /// <summary>
    /// The main method.
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            PyMolComponent tmpPyMolComponent = new PyMolComponent();
            if (!tmpPyMolComponent.IsInstalled())
            {
                WindowsUtil tmpWindowsUtil = new WindowsUtil();
                if (!tmpWindowsUtil.InstallVcRedist())
                {
                    Console.WriteLine("Installation of VC_redist failed!");
                    Environment.ExitCode =
                        10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                    Environment.Exit(Environment.ExitCode);
                }

                Console.WriteLine("Start installation of PyMOL ...");
                if (!tmpPyMolComponent.Install())
                {
                    Console.WriteLine("Installation of PyMOL failed!");
                    Environment.ExitCode =
                        10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                    Environment.Exit(Environment.ExitCode);
                }

                Console.WriteLine("Installation of PyMOL finished successfully.");
                Environment.ExitCode =
                    0; // ERROR_SUCCESS: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-    
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
