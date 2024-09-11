using System.Diagnostics;

namespace PostInstallationRunner.Util;


public class WindowsUtil
{
    public bool InstallVcRedist()
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
}
