namespace PostInstallationRunner.Components;

public interface IComponent
{
    /// <summary>
    /// Install logic for a component
    /// </summary>
    /// <returns>True, if install was successful, Otherwise: false</returns>
    public bool Install();

    /// <summary>
    /// Uninstall logic for a component
    /// </summary>
    /// <returns>True, if install was successful, Otherwise: false</returns>
    public bool Uninstall();

    public bool IsInstalled();
}
