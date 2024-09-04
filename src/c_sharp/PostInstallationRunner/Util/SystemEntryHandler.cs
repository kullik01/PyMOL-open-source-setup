namespace PostInstallationRunner.Util;

/// <summary>
/// Provides functionality for creating and removing system entry shortcuts such as desktop and start menu shortcuts.
/// </summary>
public class SystemEntryHandler
{
    /// <summary>
    /// Creates a desktop shortcut.
    /// </summary>
    /// <param name="targetPath">Filepath to the start batch file.</param>
    /// <param name="shortcutName">Name of the shortcut.</param>
    /// <param name="iconPath">Filepath of the icon.</param>
    /// <exception cref="ArgumentException">Gets thrown if any of the arguments are null.</exception>
    public static void CreateDesktopShortcut(string targetPath, string shortcutName, string iconPath)
    {
        #region Checks

        if (targetPath == null)
        {
            throw new ArgumentException("targetPath is null.");
        }
        if (shortcutName == null)
        {
            throw new ArgumentException("shortcutName is null.");
        }
        if (iconPath == null)
        {
            throw new ArgumentException("iconPath is null.");
        }

        #endregion
        
        // Get the path to the desktop folder
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        // Combine the desktop path with the shortcut name
        string shortcutPath = Path.Combine(desktopPath, shortcutName + ".lnk");

        // Create a WshShellClass instance
        dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("WScript.Shell"));

        // Create a shortcut object
        dynamic shortcut = shell.CreateShortcut(shortcutPath);

        // Set the properties of the shortcut
        shortcut.TargetPath = targetPath;
        shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);

        // Set the icon for the shortcut
        if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
        {
            shortcut.IconLocation = iconPath;
        }

        // Save the shortcut
        shortcut.Save();
    }
    
    /// <summary>
    /// Creates a start menu shortcut.
    /// </summary>
    /// <param name="targetPath">Filepath to the start batch file.</param>
    /// <param name="shortcutName">Name of the shortcut.</param>
    /// <param name="iconPath">Filepath of the icon.</param>
    /// <exception cref="ArgumentException">Gets thrown if any of the arguments are null.</exception>
    public static void CreateStartMenuShortcut(string targetPath, string shortcutName, string iconPath)
    {
        #region Checks

        if (targetPath == null)
        {
            throw new ArgumentException("targetPath is null.");
        }
        if (shortcutName == null)
        {
            throw new ArgumentException("shortcutName is null.");
        }
        if (iconPath == null)
        {
            throw new ArgumentException("iconPath is null.");
        }

        #endregion
        
        // Get the path to the Start Menu Programs folder
        string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        string shortcutPath = Path.Combine(startMenuPath, shortcutName + ".lnk");

        // Create a WshShellClass instance
        dynamic shell = Activator.CreateInstance(Type.GetTypeFromProgID("WScript.Shell"));

        // Create a shortcut object
        dynamic shortcut = shell.CreateShortcut(shortcutPath);

        // Set the properties of the shortcut
        shortcut.TargetPath = targetPath;
        shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);

        // Set the icon for the shortcut
        if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
        {
            shortcut.IconLocation = iconPath;
        }

        // Save the shortcut
        shortcut.Save();
    }
    
    /// <summary>
    /// Removes the desktop and start menu shortcut.
    /// </summary>
    /// <param name="specialFolder">Special folder like Desktop or StartMenu.</param>
    /// <param name="shortcutName">Name of the shortcut.</param>
    /// <exception cref="ArgumentException">Gets thrown if any of the arguments are null.</exception>
    public static void RemoveShortcut(Environment.SpecialFolder specialFolder, string shortcutName)
    {
        #region Checks
        
        // The specialFolder cannot be checked against null
        if (shortcutName == null)
        {
            throw new ArgumentException("shortcutName is null.");
        }
        
        #endregion
        
        // Get the folder path based on the specified special folder
        string folderPath = Environment.GetFolderPath(specialFolder);

        // Combine the folder path with the shortcut name
        string shortcutPath = Path.Combine(folderPath, shortcutName + ".lnk");

        // Check if the shortcut file exists before attempting to delete it
        if (File.Exists(shortcutPath))
        {
            // Delete the shortcut file
            File.Delete(shortcutPath);
            Console.WriteLine($"Shortcut removed: {shortcutPath}");
        }
        else
        {
            Console.WriteLine($"Shortcut not found: {shortcutPath}");
        }
    }
}
