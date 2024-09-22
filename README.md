# PyMOL-open-source-setup (Unofficial Windows Setup)
<!-- [![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.12667158.svg)](https://zenodo.org/doi/10.5281/zenodo.12667157) -->
[![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-blue.svg)](http://www.gnu.org/licenses/gpl-3.0)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-blue.svg)](https://GitHub.com/kullik01/PyMOL-open-source-setup/graphs/commit-activity)
[![GitHub issues](https://img.shields.io/github/issues/kullik01/PyMOL-open-source-setup)](https://github.com/kullik01/PyMOL-open-source-setup/issues)
[![GitHub release](https://img.shields.io/github/release/kullik01/PyMOL-open-source-setup)](https://github.com/kullik01/PyMOL-open-source-setup/releases)

## <img src='https://github.com/primer/octicons/blob/main/icons/download-24.svg' width='32'/> [Quick Installation](https://github.com/kullik01/PyMOL-open-source-setup/wiki/Installation-for-Windows-Operating-System)
## Contents of this document
* [Description](#Description)
* [Contents of this repository](#Contents-of-this-repository)
  * [Sources](#Sources)
  * [Assets](#Assets)
* [Installation for Windows OS](#Installation-for-Windows-OS)
    * [Source code](#Source-code)
* [References and useful links](#References-and-useful-links)
* [Acknowledgements](#Acknowledgements)

## Description
PyMOL-open-source-setup is an open project which provides an easy-to-use installation setup for the open-source version of PyMOL.
[PyMOL(tm)](https://pymol.org/) is a software tool for visualizing and analyzing molecular structures such as proteins, nucleic acids, and small molecules in 3D. PyMOL is a trademark of Schrodinger, LLC. 
This repository focuses on simplifying the setup process for open-source PyMOL on the Windows operating system. 
The installation process does not involve the manual configuration of a Python/conda environment, thus facilitating a rapid and straightforward installation.
This allows a broader audience to start using the open-source version of PyMOL for research, teaching, or personal use.

The provided files and setup are unofficial (meaning: informal, no warranty, no liability, provided "as is", no connection to Schrodinger LLC).

## Contents of this repository
### Sources
There are two different languages used in this repository for the setup functionality.

- _c_sharp_
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/src/c_sharp/PostInstallationRunner">PostInstallationRunner</a> directory: Contains the core files for post-installation processing.
    - <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/src/c_sharp/PostInstallationRunner/Components">Components</a> directory: Contains the <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/src/c_sharp/PostInstallationRunner/Components/PyMolComponent.cs">PyMolComponent.cs</a> file.
    - <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/src/c_sharp/PostInstallationRunner/Util">Util</a> directory: Contains utility functions relevant for the PyMolComponent.
    - <a href="https://github.com/kullik01/PyMOL-open-source-setup/blob/main/src/c_sharp/PostInstallationRunner/Program.cs">Program.cs</a> file: Contains the main method of PostInstallationRunner.
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/blob/main/src/c_sharp/c_sharp.sln">c_sharp.sln</a> file: Solution file for setting up and configuring the development environment.
   
- _inno_setup_
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/blob/main/src/inno_setup/LICENSE.txt">LICENSE.txt</a> file: Contains the license information for PyMOL and this repository.
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/blob/main/src/inno_setup/setup.iss">setup.iss</a> file: Script file used for the installation setup of the PyMOL-open-source-setup. 

### Assets
There are two different directories used for images.

- <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets">assets</a> directory
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/convert_to_ico">convert_to_ico</a> directory: Contains a batch script,
which converts the logo.png image into various resolutions (from 16x16 to 256x256) PNG files and a multi-resolution ICO file.
Moreover, the directory includes individual PNG files for each resolution, a generated logo.ico file, and the original logo.png.
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/raw">raw</a> directory: Includes the logo in its original vector format as an SVG file.
  - <a href="https://github.com/kullik01/PyMOL-open-source-setup/tree/main/assets/wiki_images">wiki_images</a> directory: Contains images for wiki.

## Installation for Windows OS
PyMOL-open-source-setup is tested and available for Windows 10 and 11.
To be able to run PyMOL, the **[Microsoft Visual C++ Redistributable packages for Visual Studio 2022](https://learn.microsoft.com/en-US/cpp/windows/latest-supported-vc-redist?view=msvc-170)** are **required**.
The installation of these packages can be carried out during the installation process, when prompted by the setup.

For a convenient and user-friendly installation click [here](https://github.com/kullik01/PyMOL-open-source-setup/wiki/Installation-for-Windows-Operating-System)

### Source code
To modify the source code, download or clone the repository.
The Inno Setup script may then be altered by opening the relevant file, setup.iss, in a text editor of your choice. 
The PostInstallationRunner C# project may also be edited by opening the corresponding solution in an appropriate IDE (e.g. Rider/Visual Studio).

## References and useful links
**PyMOL**
* [Open-source GitHub repository](https://github.com/schrodinger/pymol-open-source)
* [Incentive PyMOL](https://pymol.org/)
* [Open-source Windows Python wheelfiles](https://github.com/cgohlke/pymol-open-source-wheels)

## Acknowledgements
**Developer:**
* Hannah Kullik

**End-user tester:**
* Martin Urban

**I would like to thank the communities behind the open software libraries, Christoph Gohlke for the wheel files to make the PyMOL installation comfortable (and without the hassle of compling PyMOL from source), Martin Urban for end-user testing and especially Warren L. DeLano for their amazing work.**
