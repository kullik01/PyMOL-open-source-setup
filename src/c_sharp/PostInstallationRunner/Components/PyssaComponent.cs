using System.IO.Compression;
using PostInstallationRunner.Util;

namespace PostInstallationRunner.Components;

public class PyssaComponent : IComponent
{
    /// <summary>
    /// Installs PySSA.
    /// </summary>
    /// <returns>
    /// True if installation is successful, otherwise false.
    /// </returns>
    public bool Install()
    {
        if (!File.Exists(ConstantPaths.WINDOWS_PACKAGE_ZIP))
        {
            return false;
        }
        if (!UnzipWindowsPackage())
        {
            return false;
        }
        if (!CreateWindowsShortcuts())
        {
            return false;
        }
        if (!SetupPythonEnvironment())
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
    /// Unzips the windows_package.zip file to the specified directory.
    /// </summary>
    /// <returns>0 if successful, 1 if any error occurs during extraction or file deletion.</returns>
    private bool UnzipWindowsPackage()
    {
        // Unzip package definitions
        string zipFilePath = ConstantPaths.WINDOWS_PACKAGE_ZIP;
        string extractPath = ConstantPaths.PYSSA_PROGRAM_DIR;

        // Ensure the zip archive exists
        if (!File.Exists(zipFilePath))
        {
            return false;
        }

        // Ensure the extract directory exists
        if (!Directory.Exists(extractPath))
        {
            Directory.CreateDirectory(extractPath);
        }

        // Unzip the archive
        try
        {
            ZipFile.ExtractToDirectory(zipFilePath, extractPath, overwriteFiles: true);
        }
        catch (Exception ex)
        {
            // Catches error while extracting windows package therefore return 1
            return false;
        }

        try
        {
            File.Delete(zipFilePath);
        }
        catch (Exception ex)
        {
            // Catches error while deleting windows package therefore return 1
            return false;
        }

        return true;
    }

    /// <summary>
    /// Creates Windows shortcuts for the PyMOL-PySSA application.
    /// </summary>
    /// <returns>0 if the operation is successful, otherwise 1.</returns>
    private bool CreateWindowsShortcuts()
    {
        try
        {
            // Specify the details for the shortcut to be created
            string executablePath = ConstantPaths.PYSSA_WINDOW_ARRANGEMENT_EXE_FILEPATH;
            string shortcutName = "PySSA";
            string iconPath = ConstantPaths.PYSSA_ICON_FILEPATH;
            // Create desktop icon
            SystemEntryHandler.CreateDesktopShortcut(executablePath, shortcutName, iconPath);
            // Create start menu entry
            SystemEntryHandler.CreateStartMenuShortcut(executablePath, shortcutName, iconPath);
        }
        catch (Exception ex)
        {
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
            if (!tmpPythonUtil.PipWheelInstall($@"{ConstantPaths.PYSSA_PROGRAM_DIR}\Pmw-2.1.1.tar.gz"))
            {
                return false;
            }
            if (!tmpPythonUtil.PipWheelInstall($@"{ConstantPaths.PYSSA_PROGRAM_DIR}\pymol-3.0.0-cp311-cp311-win_amd64.whl"))
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
            File.Delete(@"C:\ProgramData\IBCI\PySSA\Pmw-2.1.1.tar.gz");
            File.Delete(@"C:\ProgramData\IBCI\PySSA\pymol-3.0.0-cp311-cp311-win_amd64.whl");
            Directory.Delete(@"C:\ProgramData\IBCI\PySSA\bin\setup_python_for_pyssa", true);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    #endregion

    /// <summary>
    /// Uninstalls PySSA.
    /// </summary>
    /// <returns>
    /// True if PySSA is successfully uninstalled, otherwise false.
    /// </returns>
    public bool Uninstall()
    {
        try
        {
            string shortcutName = "PySSA";
            SystemEntryHandler.RemoveShortcut(Environment.SpecialFolder.DesktopDirectory, shortcutName);
            SystemEntryHandler.RemoveShortcut(Environment.SpecialFolder.StartMenu, shortcutName);
            Directory.Delete($@"{ConstantPaths.PYSSA_PROGRAM_DIR}\win_start", true);
            Directory.Delete(ConstantPaths.PYSSA_PROGRAM_BIN_DIR, true);
        }
        catch (UnauthorizedAccessException ex)
        {
            return true;
        }
        catch (Exception ex)
        {
            // Error occured during one of the function calls therefore return false
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if PySSA is installed or not on the system.
    /// </summary>
    /// <returns>
    /// True if PySSA is installed, otherwise false.
    /// </returns>
    public bool IsInstalled()
    {
        if (Directory.Exists(ConstantPaths.PYSSA_PLUGIN_PATH))
        {
            return true;
        }
        return false;
    }
}