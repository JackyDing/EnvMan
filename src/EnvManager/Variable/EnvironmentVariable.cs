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
using System.Xml.Serialization;

namespace EnvManager.Variable
{
    [Serializable]
    public class EnvironmentVariable : ICloneable
    {
        private string name = "";
        private List<string> values = new List<string>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlArray("Values")]
        [XmlArrayItem("Value", typeof(string))]
	    public List<string> Values
        {
            get
            {
                return values;
            }
            set
            {
                values.Clear();
                values = value;
            }
        }

        [XmlIgnore]
        public string Value
        {
            get
            {
                return string.Join(";", values.ToArray());
            }
            set
            {
                values.Clear();
                values.AddRange(value.Split(';'));
            }
        }

        public object Clone()
        {
            EnvironmentVariable variable = new EnvironmentVariable();
            variable.Name = this.name;
            variable.Value = this.Value;
            return variable;
        }
    }
}
