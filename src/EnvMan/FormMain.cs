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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using EnvManager;

namespace EnvMan
{
    public partial class FormMain : Form
    {
        #region Form Functions

        public FormMain()
        {
            InitializeComponent();

            this.Text += " " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.MinimumSize = new Size(472, 504);

            LoadSettings();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
        }

        private void TsmiClick(object sender, EventArgs e)
        {
            if (sender.Equals(tsmiExit))
            {
                Application.Exit();
            }
            else if (sender.Equals(tsmiAbout))
            {
                FormAbout aboutForm = new FormAbout();
                aboutForm.ShowDialog();
                aboutForm.Dispose();
            }
            else if (sender.Equals(TsmiSettings))
            {
                FormOptions settingsForm = new FormOptions();
                settingsForm.ShowDialog();
                settingsForm.Dispose();
            }
        }

        #endregion Form Functions

        #region Form Settings

        private Properties.Settings settings = Properties.Settings.Default;
        private void LoadSettings()
        {
            if (settings.FrmWindowState == FormWindowState.Normal)
            {
                this.Location = settings.FrmWindowLocation;
                this.Width = settings.FrmSize.Width;
                this.Height = settings.FrmSize.Height;
            }
            else
            {
                this.WindowState = settings.FrmWindowState;
            }
        }
        private void SaveSettings()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                settings.FrmWindowLocation = this.Location;
                settings.FrmSize = this.Size;
            }
            else
            {
                settings.FrmWindowState = this.WindowState;
            }

            settings.Save();
        }

        #endregion Form Settings
    }
}
