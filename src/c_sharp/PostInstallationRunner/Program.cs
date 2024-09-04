using PostInstallationRunner.Components;

namespace PostInstallationRunner;

class Program
{
    static void Main(string[] args)
    {
        ColabFoldComponent tmpColabFoldComponent = new ColabFoldComponent();
        if (!tmpColabFoldComponent.IsInstalled())
        {
            Console.WriteLine("Start installation of ColabFold ...");
            if (!tmpColabFoldComponent.Install())
            {
                Console.WriteLine("Installation of ColabFold failed!");
                Environment.ExitCode = 10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                Environment.Exit(Environment.ExitCode);
            }
            Console.WriteLine("Installation of ColabFold finished successfully.");
        }

        PyssaComponent tmpPyssaComponent = new PyssaComponent();
        if (!tmpPyssaComponent.IsInstalled())
        {
            Console.WriteLine("Start installation of PySSA ...");
            if (!tmpPyssaComponent.Install())
            {
                Console.WriteLine("Installation of PySSA failed!");
                Environment.ExitCode = 10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                Environment.Exit(Environment.ExitCode);
            }
            Console.WriteLine("Installation of PySSA finished successfully.");
            Environment.ExitCode = 0; // ERROR_SUCCESS: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
        }

        ChimeraXComponent tmpChimeraXComponent = new ChimeraXComponent();
        if (!tmpChimeraXComponent.IsInstalled())
        {
            Console.WriteLine("Start installation of ChimeraX ...");
            if (!tmpChimeraXComponent.Install())
            {
                Console.WriteLine("Installation of ChimeraX failed!");
                Environment.ExitCode = 10; // ERROR_BAD_ENVIRONMENT: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
                Environment.Exit(Environment.ExitCode);
            }
            Console.WriteLine("Installation of ChimeraX finished successfully.");
            Environment.ExitCode = 0; // ERROR_SUCCESS: https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
        }
    }
}
