using PostInstallationRunner.Components;
using PostInstallationRunner.Util;

namespace PostInstallationRunner;

class Program
{
    static void Main(string[] args)
    {
        PyMolComponent tmpPyMolComponent = new PyMolComponent();
        if (!tmpPyMolComponent.IsInstalled())
        {
            WindowsUtil tmpWindowsUtil = new WindowsUtil();
            if (!tmpWindowsUtil.InstallVcRedist())
            {
                Console.WriteLine("Installation of VC_redist failed!");
                Environment.ExitCode = 10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                Environment.Exit(Environment.ExitCode);
            }
            Console.WriteLine("Start installation of PyMOL ...");
            if (!tmpPyMolComponent.Install())
            {
                Console.WriteLine("Installation of PyMOL failed!");
                Environment.ExitCode = 10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                Environment.Exit(Environment.ExitCode);
            }
            Console.WriteLine("Installation of PyMOL finished successfully.");
            Environment.ExitCode = 0; // ERROR_SUCCESS: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
        }
    }
}
