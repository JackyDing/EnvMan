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

using EnvMan.Properties;
using System.Configuration;

namespace EnvMan
{
    public partial class FormOptions : Form
    {
        private Settings mainFormSettings = Settings.Default;

        public FormOptions()
        {
            InitializeComponent();

            LoadSettings();
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            this.CbOneInstance.Checked = mainFormSettings.OnlyOneInstance;
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            this.mainFormSettings.OnlyOneInstance = CbOneInstance.Checked;

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validate controls
            CancelEventArgs cancelEvent = new CancelEventArgs();
                       
            if (!cancelEvent.Cancel)
            {
                SaveSettings();
                this.Close(); 
            }
        }
    }
}
