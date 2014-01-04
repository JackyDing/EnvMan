/*
 * EnvMan - The Open-Source Windows Environment Variables Manager
 * Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>
 * Copyright (C) 2013 Jacky Ding <jackyfire@gmail.com>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
**/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace EnvManager.Variable
{
    public static class EnvironmentVariableManager
    {
        #region Environment Variables Operation

        /// <summary>
        /// Gets all environment variables for given variable type.
        /// </summary>
        /// <param name="target">Type of the variable.</param>
        /// <returns></returns>
        public static IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target)
        {
            return Environment.GetEnvironmentVariables(target);
        }

        /// <summary>
        /// Expand the environment variable.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <returns></returns>
        public static string ExpandEnvironmentVariable(string name)
        {
            return Environment.ExpandEnvironmentVariables(name);
        }
        
        /// <summary>
        /// Gets the environment variable.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="target">Type of the variable.</param>
        /// <returns></returns>
        public static string GetEnvironmentVariable(string name, EnvironmentVariableTarget target)
        {
            return TargetKey(target).GetValue(name).ToString();
        }

        /// <summary>
        /// Begin operate the environment variables.
        /// </summary>
        public static void Begin()
        {
        }

        /// <summary>
        /// Sets the environment variable.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="value">The variable value.</param>
        /// <param name="target">Type of the variable.</param>
        public static void SetEnvironmentVariable(string name, string value, EnvironmentVariableTarget target)
        {
            ValidateVariables(name, value);
            TargetKey(target).SetValue(name, value, value.Contains("%") ? RegistryValueKind.ExpandString : RegistryValueKind.String);
        }

        /// <summary>
        /// Deletes the environment variable.
        /// </summary>
        /// <param name="name">Name of the var.</param>
        /// <param name="target">Type of the var.</param>
        public static void DeleteEnvironmentVariable(string name, EnvironmentVariableTarget target)
        {
            TargetKey(target).DeleteValue(name);
        }

        /// <summary>
        /// End operate the environment variables.
        /// </summary>
        public static void End()
        {
            int result;
            string s = "Environment";
            IntPtr ptrA = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(s);
            IntPtr ptrU = System.Runtime.InteropServices.Marshal.StringToHGlobalUni(s);
            SendMessageTimeout((System.IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, 0, (int)ptrA, SMTO_ABORTIFHUNG, 5000, out result);
            SendMessageTimeout((System.IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, 0, (int)ptrU, SMTO_ABORTIFHUNG, 5000, out result);
        }

        #endregion Environment Variables Operation

        #region Environment Variables Private Operation

        /// <summary>
        /// Gets the registry key for variable type.
        /// </summary>
        /// <param name="target">Type of the variable.</param>
        /// <returns></returns>
        private static RegistryKey TargetKey(EnvironmentVariableTarget target)
        {
            if (target == EnvironmentVariableTarget.User)
            {
                return Registry.CurrentUser.OpenSubKey("Environment", true);
            }
            else
            {
                return Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Control").OpenSubKey("Session Manager").OpenSubKey("Environment", true);
            }
        }
        
        private const int HWND_BROADCAST = 0xffff;
        private const int WM_SETTINGCHANGE = 0x001A;
        private const int SMTO_NORMAL = 0x0000;
        private const int SMTO_BLOCK = 0x0001;
        private const int SMTO_ABORTIFHUNG = 0x0002;
        private const int SMTO_NOTIMEOUTIFNOTHUNG = 0x0008;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SendMessageTimeout(IntPtr hWnd, uint uMsg, int wParam, int lParam, uint uFlags, uint uTimeout, out int lpdwResult);

        #endregion Environment Variables Private Operation

        #region Validation
        /// <summary>
        /// Validates the variable.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="value">The variable value.</param>
        private static void ValidateVariables(string name, string value) 
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Variable Name cannot be blank.");
            }
            if (value != null && value == "")
            {
                throw new ArgumentException("Variable should have a value.");
            }
        }
        #endregion Validation   
    }
}
