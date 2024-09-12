//
// PyMOL-open-source-setup
// Copyright (C) 2024
// Hannah Kullik (hannah.kullik@studmail.w-hs.de)
//
// Source code is available at <https://github.com/kullik01/PyMOL-open-source-setup>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
namespace PostInstallationRunner.Components;

/// <summary>
/// Interface for every component.
/// </summary>
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
