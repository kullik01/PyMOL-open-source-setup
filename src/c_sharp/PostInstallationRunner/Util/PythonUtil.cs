using System.Diagnostics;

namespace PostInstallationRunner.Util;

public class PythonUtil
{
    public bool InstallPython()
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
                    Arguments = "/C C:\\ProgramData\\IBCI\\PySSA\\bin\\setup_python_for_pyssa\\setup_python.bat"
                }
            };
            tmpProcess.Start();
            tmpProcess.WaitForExit();
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
    
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
                    Arguments = "/C C:\\ProgramData\\IBCI\\PySSA\\bin\\setup_python_for_pyssa\\setup_python.bat"
                }
            };
            tmpProcess.Start();
            tmpProcess.WaitForExit();
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
    
    /// <summary>
    /// Installs a Python wheel using pip.
    /// </summary>
    /// <param name="aWheelFilepath">The filepath of the wheel file to install.</param>
    /// <exception cref="ArgumentNullException">Thrown if aWheelFilepath is null.</exception>
    /// <exception cref="ArgumentException">Thrown if aWheelFilepath does not exists.</exception>
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
            return false;
        }

        return true;
    }
}