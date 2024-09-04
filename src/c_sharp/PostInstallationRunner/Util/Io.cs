using System.Net;

namespace PostInstallationRunner.Util;

/// <summary>
/// Class that contains static methods for IO.
/// </summary>
public class Io
{
    /// <summary>
    /// Downloads a file in a synchronous manner.
    /// </summary>
    /// <param name="anUrl">The url to download the file from.</param>
    /// <param name="aFilepath">The filepath to save the downloaded file.</param>
    /// <returns>A boolean indicating if the download was successful.</returns>
    /// <exception cref="ArgumentException">Gets thrown if any of the arguments are null.</exception>
    public static bool DownloadFile(string anUrl, string aFilepath)
    {
        #region Checks

        if (anUrl == null)
        {
            throw new ArgumentException("anUrl is null.");
        }
        if (aFilepath == null)
        {
            throw new ArgumentException("aFilepath is null.");
        }

        #endregion
        
        WebClient tmpClient = new WebClient();
        try
        {
            tmpClient.DownloadFile(anUrl, aFilepath);
        }
        catch
        {
            return false;
        }

        if (File.Exists(aFilepath))
        {
            return true;
        }

        return false;
    }
}

