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
using System.IO;
using System.Xml.Serialization;
using EnvManager.Variable;

namespace EnvManager.Snapshot
{
    [Serializable]
    public class EnvironmentSnapshot
    {
        private bool loaded = false;
        private string name = "";
        private EnvironmentVariableTarget target = EnvironmentVariableTarget.User;
        private List<EnvironmentVariable> variables = new List<EnvironmentVariable>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public EnvironmentVariableTarget Target
        {
            get { return target; }
        }
        public List<EnvironmentVariable> Variables
        {
            get
            {
                return variables;
            }
            set
            {
                variables.Clear();
                variables = value;
            }
        }

        public EnvironmentSnapshot()
        {

        }

        public EnvironmentSnapshot(string name, EnvironmentVariableTarget target)
        {
            this.name = name;
            this.target = target;
        }

        public EnvironmentVariable GetVariable(string name)
        {
            return variables.Find(delegate(EnvironmentVariable obj) { return obj.Name.Equals(name); });
        }

        public bool Save(string folder, bool force = true)
        {
            if (name != "" && name != "[Current]")
            {
                try
                {
                    string dir = (target == EnvironmentVariableTarget.User) ? "usr\\" : "sys\\";
                    FileStream file = File.Create(folder + "\\snapshots\\" + dir + name + ".env");
                    XmlSerializer xmlSerializer = new XmlSerializer(GetType());
                    xmlSerializer.Serialize(file, this);
                    file.Close();
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public bool Load(string folder, bool force = true)
        {
            if (!loaded)
            {
                if (name != "" && name != "[Current]")
                {
                    try
                    {
                        string dir = (target == EnvironmentVariableTarget.User) ? "usr\\" : "sys\\";
                        FileStream file = File.OpenRead(folder + "\\snapshots\\" + dir + name + ".env");
                        XmlSerializer xmlSerializer = new XmlSerializer(GetType());
                        var snapshot = (EnvironmentSnapshot)xmlSerializer.Deserialize(file);
                        file.Close();
                        name = snapshot.name;
                        variables = snapshot.variables;
                        loaded = true;
                        return true;
                    }
                    catch (Exception)
                    {
                    }
                }
                return false;
            }
            return true;
        }

        public bool Create(string folder)
        {
            return Save(folder);
        }

        public bool Remove(string folder)
        {
            try
            {
                string dir = (target == EnvironmentVariableTarget.User) ? "usr\\" : "sys\\";
                File.Delete(folder + "\\snapshots\\" + dir + name + ".env");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
