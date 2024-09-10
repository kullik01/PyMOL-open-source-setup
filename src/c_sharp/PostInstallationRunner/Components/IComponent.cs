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
    /// <returns>True, if uninstall was successful, Otherwise: false</returns>
    public bool Uninstall();

    /// <summary>
    /// Check logic if a component is installed
    /// </summary>
    /// <returns>True, if a component is installed, Otherwise: false</returns>
    public bool IsInstalled();
}
