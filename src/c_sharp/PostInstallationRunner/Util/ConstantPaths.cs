namespace PostInstallationRunner.Util;

public class ConstantPaths
{
    /// <summary>
    /// Name of the plugin.
    /// </summary>
    public static readonly string PLUGIN_NAME = "PySSA";
    /// <summary>
    /// Path of the global temp directory.
    /// </summary>
    public static readonly string TEMP_DIR = @"C:\ProgramData\IBCI\temp";
    /// <summary>
    /// Filepath of the windows_package.zip for PySSA.
    /// </summary>
    public static readonly string WINDOWS_PACKAGE_ZIP = $@"{TEMP_DIR}\windows_package.zip";
    /// <summary>
    /// Program folder of PySSA.
    /// </summary>
    public static readonly string PYSSA_PROGRAM_DIR = @"C:\ProgramData\IBCI\PySSA";
    /// <summary>
    /// Program folder of PySSA.
    /// </summary>
    public static readonly string PYSSA_PROGRAM_BIN_DIR = @"C:\ProgramData\IBCI\PySSA\bin";
    /// <summary>
    /// Path of the PySSA plugin.
    /// </summary>
    public static readonly string PYSSA_PLUGIN_PATH = $@"{PYSSA_PROGRAM_BIN_DIR}\{PLUGIN_NAME}";
    /// <summary>
    /// Filepath of the static constants.py of PySSA.
    /// </summary>
    public static readonly string PYSSA_PLUGIN_CONSTANTS_FILEPATH = $@"{PYSSA_PROGRAM_BIN_DIR}\{PLUGIN_NAME}\src\pyssa\util\constants.py";
    /// <summary>
    /// Filepath of the windows arrangement winbatch executable.
    /// </summary>
    public static readonly string PYSSA_WINDOW_ARRANGEMENT_EXE_FILEPATH = $@"{PYSSA_PROGRAM_DIR}\win_start\vb_script\window_arrangement.exe";
    /// <summary>
    /// Filepath of the PySSA windows icon.
    /// </summary>
    public static readonly string PYSSA_ICON_FILEPATH = $@"{PYSSA_PROGRAM_DIR}\win_start\images\logo.ico";
    /// <summary>
    /// Filepath of the PyMOL configuration file (pymolrc).
    /// </summary>
    public static readonly string PYSSA_PYMOLRC_FILEPATH = $@"{PYSSA_PROGRAM_DIR}\win_start\vb_script\.pymolrc.py";
    /// <summary>
    /// Filepath of the pip executable file.
    /// </summary>
    public static readonly string PIP_FILEPATH = $@"{PYSSA_PROGRAM_BIN_DIR}\.venv\Scripts\pip.exe";
    /// <summary>
    /// Path of the pymol.exe file.
    /// </summary>
    public static readonly string PymolExeFilepath = @"C:\ProgramData\IBCI\PySSA\bin\.venv\Scripts\pymol.exe";
    /// <summary>
    /// Program path of the installer.
    /// </summary>
    public static readonly string InstallerProgramPath = @"C:\ProgramData\IBCI\PySSA-Installer";
    /// <summary>
    /// Path of temporary file for the installer.
    /// </summary>
    public static readonly string InstallerTempPath = $@"{InstallerProgramPath}\temp";
    /// <summary>
    /// Filepath of the BCUninstaller zip archive.
    /// </summary>
    public static readonly string InstallerBCUZipFilepath = $@"{InstallerTempPath}\BCUninstaller_5.6_portable.zip";
    /// <summary>
    /// Program path of the BCUninstaller.
    /// </summary>
    public static readonly string InstallerBCUPath = $@"{InstallerTempPath}\BCUninstaller_5.6_portable";
    /// <summary>
    /// Filepath of the store helper exe file of the BCUinstaller.
    /// </summary>
    public static readonly string InstallerBCUStoreHelperFilepath = $@"{InstallerBCUPath}\win-x64\StoreAppHelper.exe";
    /// <summary>
    /// Path of the installer log files.
    /// </summary>
    public static readonly string InstallerLogPath = $@"{InstallerProgramPath}\logs";
    
    // TODO: The constants below are outdated and need to removed in an upcoming update!
    /// <summary>
    /// Path of the temporary folder in the PySSA-Installer program root folder.
    /// </summary>
    public static readonly string PYSSA_INSTALLER_TEMP_DIR = InstallerTempPath;
    /// <summary>
    /// Filepath of the version history xml.
    /// </summary>
    public static readonly string PYSSA_INSTALLER_VERSION_HISTORY_FILEPATH = $@"{InstallerTempPath}\version_history.xml";
    /// <summary>
    /// Filepath of the version file of ColabFold.
    /// </summary>
    public static readonly string COLABFOLD_LOCAL_VERSION_FILEPATH = "C:\\ProgramData\\localcolabfold\\version.txt";
    /// <summary>
    /// Filepath of the alma linux rootfs.
    /// </summary>
    public static readonly string TEMP_ALMALINUX_TAR_FILEPATH = $@"{InstallerTempPath}\alma-colabfold-9-rootfs.tar";
    

    #region Offline win package

    /// <summary>
    /// Filepath of the offline win package zip archive.
    /// </summary>
    public static readonly string INSTALLER_OFFLINE_WIN_PACKAGE_ZIP_FILEPATH = $"{PYSSA_INSTALLER_PROGRAM_DIR}\\offline_win_package.zip";
    /// <summary>
    /// Path of for the extra tools of PySSA.
    /// </summary>
    public static readonly string PYSSA_EXTRA_TOOLS_PATH = $"{PYSSA_PROGRAM_DIR}\\extra_tools";
    /// <summary>
    /// Filepath of the help browser executable.
    /// </summary>
    public static readonly string PYSSA_BROWSER_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\extra_tools\\browser.exe";
    /// <summary>
    /// Path of the win start folder.
    /// </summary>
    public static readonly string PYSSA_WIN_START_PATH = $"{PYSSA_PROGRAM_DIR}\\win_start";
    /// <summary>
    /// Path of the images folder for PySSA.
    /// </summary>
    public static readonly string PYSSA_WIN_START_IMAGES_PATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\images";
    /// <summary>
    /// Filepath of the PySSA windows icon.
    /// </summary>
    public static readonly string PYSSA_WIN_START_IMAGES_ICON_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\images\\icon.ico";
    /// <summary>
    /// Path of the start scripts.
    /// </summary>
    public static readonly string PYSSA_WIN_START_VB_SCRIPT_PATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\vb_script";
    /// <summary>
    /// Filepath of the PyMOL configuration file (pymolrc).
    /// </summary>
    public static readonly string PYSSA_WIN_START_VB_SCRIPT_PYMOLRC_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\vb_script\\.pymolrc.py";
    /// <summary>
    /// Filepath of the batch file to start PySSA.
    /// </summary>
    public static readonly string PYSSA_WIN_START_VB_SCRIPT_START_BAT_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\vb_script\\PySSA.bat";
    /// <summary>
    /// Filepath of the start vbs script.
    /// </summary>
    public static readonly string PYSSA_WIN_START_VB_SCRIPT_START_VBS_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\vb_script\\start.vbs";
    /// <summary>
    /// Filepath of the windows arrangement winbatch script executable.
    /// </summary>
    public static readonly string PYSSA_WIN_START_VB_SCRIPT_WINBATCH_EXE_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\win_start\\vb_script\\window_arrangement.exe";
    /// <summary>
    /// Filepath of the PySSA license.
    /// </summary>
    public static readonly string PYSSA_LICENSE_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\License.rtf";
    /// <summary>
    /// Filepath of the PyMOL v3 python wheel file.
    /// </summary>
    public static readonly string PYSSA_PYMOL_WHEEL_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\pymol-3.0.0-cp39-cp39-win_amd64.whl";
    /// <summary>
    /// Filepath of a PyMOL configuration file (as pymol script).
    /// </summary>
    public static readonly string PYSSA_PYMOLRC_PML_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\pymolrc.pml";
    /// <summary>
    /// Filepath of the plugin zip file.
    /// </summary>
    public static readonly string PYSSA_PYSSA_ZIP_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\pyssa.zip";
    /// <summary>
    /// Filepath of the PySSA version (old).  // TODO: Could be removed?!
    /// </summary>
    public static readonly string PYSSA_PYSSA_VERSION_TXT_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\pyssa_version_current.txt";
    /// <summary>
    /// Filepath of the frozen conda environment.
    /// </summary>
    public static readonly string PYSSA_PYSSA_CONDA_ENV_TAR_GZ_FILEPATH = $"{PYSSA_PROGRAM_DIR}\\pyssa_wo_pymol.tar.gz";
    
    /// <summary>
    /// Path of the mamba root folder for the base env and PySSA env.
    /// </summary>
    public static readonly string MAMBA_ENV_PATH = @"C:\ProgramData\pyssa\mambaforge_pyssa";
    /// <summary>
    /// Filepath of the conda batch file.
    /// </summary>
    public static readonly string MAMBA_CONDA_BAT_FILEPATH = @"C:\ProgramData\pyssa\mambaforge_pyssa\base-mamba\condabin\conda.bat";
    /// <summary>
    /// Filepath of the conda activate command batch file.
    /// </summary>
    public static readonly string MAMBA_CONDA_ACTIVATE_BAT_FILEPATH = @"C:\ProgramData\pyssa\mambaforge_pyssa\base-mamba\condabin\activate.bat";
    /// <summary>
    /// Filepath of a python module.
    /// </summary>
    public static readonly string MAMBA_BASE_ENV_ABC_PY_FILE_FILEPATH = @"C:\ProgramData\pyssa\mambaforge_pyssa\base-mamba\Lib\_py_abc.py";
    
    /// <summary>
    /// Program path of the PySSA-Installer.
    /// </summary>
    public static readonly string PYSSA_INSTALLER_PROGRAM_DIR = "C:\\ProgramData\\pyssa-installer";
    

    #endregion
}
