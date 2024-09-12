# PyMOL-open-source-setup
[![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.12667158.svg)](https://zenodo.org/doi/10.5281/zenodo.12667157)
[![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](http://www.gnu.org/licenses/gpl-3.0)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-blue.svg)](https://GitHub.com/kullik01/PyMOL-open-source-setup/graphs/commit-activity)
[![GitHub issues](https://img.shields.io/github/issues/kullik01/PyMOL-open-source-setup)](https://github.com/kullik01/PyMOL-open-source-setup/issues)
[![GitHub release](https://img.shields.io/github/release/kullik01/PyMOL-open-source-setup)](https://github.com/kullik01/PyMOL-open-source-setup/releases)

## Contents of this document
* [Description](#Description)
* [Contents of this repository](#Contents-of-this-repository)
  * [Sources](#Sources)
  * [Assets](#Assets)
* [Installation](#Installation)
    * [Source code](#Source-code)
* [Citation](#Citation)
* [References and useful links](#References-and-useful-links)
* [Acknowledgements](#Acknowledgements)

## Description
PyMOL-open-source-setup is an open project which provides a guide for installing the open-source version of PyMOL, a widely-used molecular visualization tool. 
PyMOL is essential for visualizing and analyzing molecular structures such as proteins, nucleic acids, and small molecules in 3D. This repository focuses on simplifying the setup process for users, enabling them to quickly install and start using the open-source version of PyMOL for research, teaching, or personal use.

## Contents of this repository
### Sources
There are five different Python packages that contain functionality for specific aspects of the architecture. 

- _pyssa_ 
  - The package contains Python modules, Qt .ui files and cascading stylesheets.


### Assets
The <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets">assets</a> folder consists of the subfolders <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/convert_to_ico">convert_to_ico</a> 
and <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/raw">raw</a>. 

The <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/convert_to_ico">convert_to_ico</a> folder contains a batch script,
which converts the logo.png image of various resolutions (from 16x16 to 256x256) into a multi-resolution .ico file.
Moreover, the folder includes individual PNG files for each resolution, a generated logo.ico file, and the original logo.png.

The <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/raw">raw</a> subfolder includes the logo in its original vector format as an SVG file.

## Installation for Windows
PyMOL-open-source-setup is tested and available for Windows 10 and 11.

For a convenient and user-friendly installation follow these steps:

1. Download the _pymol-3_0_0-bin-win64.exe_. Click [here](https://zenodo.org/records/12687296/files/full_pyssa_installer_2024.07.2_setup.zip?download=1) to automatically start the download. The download will take several minutes to download depending on your internet connection.

2. After the download finished open a Windows explorer window and navigate to _Downloads_.
   
3. Double-click on the file _pymol-3_0_0-bin-win64.exe_ to start the setup.

4. Agree to the license agreement and click on _Next_.

5. Wait for the installation to finish (This step takes around 1 minute to complete).

6. Agree to the Microsoft Software license agreement and click on _Install_.

7. After the installation process of the Microsoft Software click on _Close_.

8. Wait for the installation of PyMOL-open-source-setup to finish (This step takes around 2 minutes to complete).

9. Click on _OK_ and PyMOL will be launched automatically.

**Important:**
The PyMOL-open-source-setup is unoffical, but was tested by end-user tester.

### Source code
This is a C# project based on a virtual environment. 
To modify the source code, download or clone the repository 
and open it in an IDE that supports virtual environments (e.g. Rider).

## Citation
You can cite this software or this repository as it is defined in the CITATION.cff file.

## References and useful links
**PyMOL**
* [Open-source GitHub repository](https://github.com/schrodinger/pymol-open-source)
* [Commercial PyMOL](https://pymol.org/)
* [Open-source Windows Python wheelfiles](https://github.com/cgohlke/pymol-open-source-wheels)

## Acknowledgements
**Developer:**
* Hannah Kullik

**End-user tester:**
* Martin Urban

**I would like to thank the communities behind the open software libraries, Christoph Gohlke for the wheel files to make the PyMOL installation comfortable (and without the hassle of compling PyMOL from source), Martin Urban for end-user testing and especially Warren L. DeLano for their amazing work.**
