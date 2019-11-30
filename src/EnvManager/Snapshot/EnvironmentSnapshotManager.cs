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
using System.IO;
using System.Xml.Serialization;
using EnvManager.Variable;

namespace EnvManager.Snapshot
{
    public class EnvironmentSnapshotManager
    {
        private string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EnvMan";
        private List<EnvironmentSnapshot> usrSnapshots = new List<EnvironmentSnapshot>();
        private List<EnvironmentSnapshot> sysSnapshots = new List<EnvironmentSnapshot>();

        public string Folder
        {
            get { return appFolder; }
        }

        public EnvironmentSnapshotManager()
        {
            EnvironmentVariableTarget usrTarget = EnvironmentVariableTarget.User;
            EnvironmentSnapshot usrSnapshot = new EnvironmentSnapshot("[Current]", usrTarget);
            foreach (DictionaryEntry entry in EnvironmentVariableManager.GetEnvironmentVariables(usrTarget))
            {
                EnvironmentVariable variable = new EnvironmentVariable();
                variable.Name = entry.Key.ToString();
                variable.Value = EnvironmentVariableManager.GetEnvironmentVariable(variable.Name, usrTarget);
                usrSnapshot.Variables.Add(variable);
            }
            usrSnapshots.Add(usrSnapshot);
            try
            {
                foreach (var file in Directory.GetFiles(appFolder + "\\snapshots\\usr", "*.env", SearchOption.TopDirectoryOnly))
                {
                    EnvironmentSnapshot snapshot = new EnvironmentSnapshot(Path.GetFileNameWithoutExtension(file), usrTarget);
                    usrSnapshots.Add(snapshot);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(appFolder + "\\snapshots\\usr");
            }

            EnvironmentVariableTarget sysTarget = EnvironmentVariableTarget.Machine;
            EnvironmentSnapshot sysSnapshot = new EnvironmentSnapshot("[Current]", sysTarget);
            foreach (DictionaryEntry entry in EnvironmentVariableManager.GetEnvironmentVariables(sysTarget))
            {
                EnvironmentVariable variable = new EnvironmentVariable();
                variable.Name = entry.Key.ToString();
                variable.Value = EnvironmentVariableManager.GetEnvironmentVariable(variable.Name, sysTarget);
                sysSnapshot.Variables.Add(variable);
            }
            sysSnapshots.Add(sysSnapshot);
            try
            {
                foreach (var file in Directory.GetFiles(appFolder + "\\snapshots\\sys", "*.env", SearchOption.TopDirectoryOnly))
                {
                    EnvironmentSnapshot snapshot = new EnvironmentSnapshot(Path.GetFileNameWithoutExtension(file), EnvironmentVariableTarget.Machine);
                    sysSnapshots.Add(snapshot);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(appFolder + "\\snapshots\\sys");
            }
        }

        public EnvironmentSnapshot GetSnapshot(int index, EnvironmentVariableTarget target, bool load = true)
        {
            var snapshots = (target == EnvironmentVariableTarget.User) ? usrSnapshots : sysSnapshots;
            var snapshot = snapshots[index];
            if (load)
            {
                snapshot.Load(appFolder);
            }
            return snapshot;
        }

        public List<EnvironmentSnapshot> GetSnapshots(EnvironmentVariableTarget target)
        {
            return target == EnvironmentVariableTarget.User ? usrSnapshots : sysSnapshots;
        }

        public bool AppendSnapshot(EnvironmentSnapshot snapshot)
        {
            if (snapshot.Create(appFolder))
            {
                var snapshots = (snapshot.Target == EnvironmentVariableTarget.User) ? usrSnapshots : sysSnapshots;
                var result = snapshots.Find(delegate(EnvironmentSnapshot obj) { return obj.Name.Equals(snapshot.Name); });
                if (result == null)
                {
                    snapshots.Add(snapshot);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveSnapshot(EnvironmentSnapshot snapshot)
        {
            if (snapshot.Remove(appFolder))
            {
                var snapshots = (snapshot.Target == EnvironmentVariableTarget.User) ? usrSnapshots : sysSnapshots;
                var result = snapshots.Find(delegate(EnvironmentSnapshot obj) { return obj.Name.Equals(snapshot.Name); });
                if (result != null)
                {
                    snapshots.Remove(snapshot);
                    return true;
                }
            }
            return false;
        }

        public bool SaveSnapshot(ref EnvironmentSnapshot snapshot)
        {
            return snapshot.Save(this.appFolder);
        }

        public bool LoadSnapshot(ref EnvironmentSnapshot snapshot)
        {
            return snapshot.Load(this.appFolder);
        }

        public static void SaveVariable(string file, ref EnvironmentVariable variable)
        {
            try
            {
                FileStream stream = File.Create(file);
                XmlSerializer xmlSerializer = new XmlSerializer(variable.GetType());
                xmlSerializer.Serialize(stream, variable);
                stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LoadVariable(string file, ref EnvironmentVariable variable)
        {
            try
            {
                FileStream stream = File.OpenRead(file);
                XmlSerializer xmlSerializer = new XmlSerializer(variable.GetType());
                variable = (EnvironmentVariable)xmlSerializer.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
