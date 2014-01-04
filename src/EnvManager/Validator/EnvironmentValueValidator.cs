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
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using EnvManager.Handlers;

namespace EnvManager.Validator
{
    public enum EnvironmentValueType
	{
	    Number,
        String,
        Folder,
        File,
        Error
    }
    /// <summary>
    /// Validates Environment Variable Value
    /// </summary>
    public class EnvironmentValueValidator
    {
        /// <summary>
        /// Check the type of the Environment Variable.
        /// </summary>
        /// <param name="varValue">The Variable Value.</param>
        /// <returns>Variable Type</returns>
        public EnvironmentValueType ValueType(string varValue)
        {
            EnvironmentValueType type = EnvironmentValueType.String;

            if (IsNumber(varValue))
            {
                type = EnvironmentValueType.Number;
            }
            else if (varValue.Length >= 3 && varValue.Substring(0, 3).Contains(@":\"))
            {   // Make sure that path starts with "C:\" where "C" is a drive letter
                if (System.IO.File.Exists(varValue))
                {
                    type = EnvironmentValueType.File;
                }
                else if (System.IO.Directory.Exists(varValue))
                {
                    type = EnvironmentValueType.Folder;
                }
                else
                {
                    type = EnvironmentValueType.Error;
                }
            }

            return type;
        }

        // Function to test whether the string is valid number or not
        /// <summary>
        /// Determines whether the specified string is number.
        /// </summary>
        /// <param name="strNumber">The string to check.</param>
        /// <returns>
        /// 	<c>true</c> if the specified string is number; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }

        /// <summary>
        /// Validates the specified variable value.
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        /// <returns>True if valid and False if not</returns>
        public bool Validate(string varValue)
        {
            bool result = true;

            string[] values = varValue.Split(DgvHandler.SEPARATOR);
            string value = string.Empty;

            foreach (string currentValue in values)
            {
                value = Environment.ExpandEnvironmentVariables(currentValue);
                if (ValueType(value) == EnvironmentValueType.Error )
                {
                    result = false;
                    break;
                }   
            }

            return result;
        }
    }
}
