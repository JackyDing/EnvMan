/*
 * EnvMan - The Open-Source Windows Environment Variables Manager
 * Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>
 * Copyright (C) 2013 Jacky Ding <jackyfire@gmail.com>
 * Copyright (C) 2013 evorios <evorioss@gmail.com>
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EnvManager.Controls;
using EnvManager.Variable;
using EnvManager.Snapshot;
using EnvManager.Validator;
using EnvManager.Properties;

namespace EnvManager
{
    public partial class EnvManager : UserControl
    {
        private EnvironmentSnapshotManager snapshotManager = new EnvironmentSnapshotManager();
        private FrmEditEnvVar frmEditVariable = null;
        private Settings settings = Settings.Default;

        public EnvManager()
        {
            InitializeComponent();
            LoadEnvironmentVariables();
            lbUsrVariables.SelectedIndex = 0;
            lbSysVariables.SelectedIndex = 0;
            this.HandleDestroyed += new EventHandler(EnvManager_HandleDestroyed);
        }

        #region Load Environment Variables

        private void LoadEnvironmentVariables()
        {
            dgvUsrVariables.Tag = EnvironmentVariableTarget.User;
            lbUsrVariables.Tag = EnvironmentVariableTarget.User;

            lbUsrVariables.Items.Clear();
            foreach (var snapshot in snapshotManager.GetSnapshots((EnvironmentVariableTarget)lbUsrVariables.Tag))
            {
                lbUsrVariables.Items.Add(snapshot.Name);
            }
            
            dgvSysVariables.Tag = EnvironmentVariableTarget.Machine;
            lbSysVariables.Tag = EnvironmentVariableTarget.Machine;

            lbSysVariables.Items.Clear();
            foreach (var snapshot in snapshotManager.GetSnapshots((EnvironmentVariableTarget)lbSysVariables.Tag))
            {
                lbSysVariables.Items.Add(snapshot.Name);
            }
        }

        private void FillEnvironmentVariables(DataGridView dgv, EnvironmentSnapshot snapshot)
        {
            int currentRowIndex = (dgv.CurrentRow != null ? dgv.CurrentRow.Index : 0);
            dgv.Rows.Clear();
            if (snapshot.Variables.Count == 0)
            {
                return;
            }
            EnvironmentValueValidator validator = new EnvironmentValueValidator();
            int rowIndex = 0;
            foreach (var variable in snapshot.Variables)
            {
                string key = variable.Name;
                string value = variable.Value;
                string[] row = { key, value };
                rowIndex = dgv.Rows.Add(row);
                if (!validator.Validate(value))
                {
                    dgv.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Red;
                    dgv.Rows[rowIndex].Cells[1].Style.ForeColor = Color.Red;
                }
            }

            dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            try
            {
                dgv.CurrentCell = dgv[0, currentRowIndex];
                dgv.FirstDisplayedScrollingRowIndex = currentRowIndex;
            }
            catch
            {   // if row was deleted this will set it to first one
                // TODO: Implement this by searching for var name in the grid. 
                // Catching Exceptions makes program slow
                dgv.CurrentCell = dgv[0, 0];
                dgv.FirstDisplayedScrollingRowIndex = 0;
            }
            int widthCol0 = dgv.Columns[0].Width;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns[0].Width = widthCol0;
        }

        #endregion Load Environment Variables

        #region Edit Environment Variables

        private void DeleteEnvVar(ListBox lb, DataGridView dgv)
        {
            var snapshot = DgvSnapshot(lb, dgv);
            var variables = DgvVariables(lb, dgv);
            if (snapshot != null && variables != null && variables.Count > 0)
            {
                if (MessageBox.Show("Are you sure to remove these variables?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (snapshot.Name == "[Current]")
                    {
                        try
                        {
                            EnvironmentVariableManager.Begin(snapshot.Target);
                            foreach (var variable in variables)
                            {
                                EnvironmentVariableManager.DeleteEnvironmentVariable(variable.Name, snapshot.Target);
                                snapshot.Variables.Remove(variable);
                            }
                            EnvironmentVariableManager.End(snapshot.Target);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    snapshotManager.SaveSnapshot(ref snapshot);
                    FillEnvironmentVariables(dgv, snapshot);
                }
            }
        }

        private void ModifyEnvVar(ListBox lb, DataGridView dgv)
        {
            var snapshot = DgvSnapshot(lb, dgv);
            var variable = DgvVariable(lb, dgv);
            if (snapshot != null && variable != null)
            {
                frmEditVariable = new FrmEditEnvVar(ref snapshot, variable);
                frmEditVariable.ShowDialog();
                if (frmEditVariable.DialogResult == DialogResult.OK)
                {
                    variable.Name = frmEditVariable.Variable.Name;
                    variable.Value = frmEditVariable.Variable.Value;
                    FillEnvironmentVariables(dgv, snapshot);
                    snapshotManager.SaveSnapshot(ref snapshot);
                }
                frmEditVariable.Dispose();
            }
        }

        private void CreateEnvVar(ListBox lb, DataGridView dgv)
        {
            var snapshot = DgvSnapshot(lb, dgv);
            var variable = new EnvironmentVariable() { Name = "" };
            if (snapshot != null)
            {
                frmEditVariable = new FrmEditEnvVar(ref snapshot, variable);
                frmEditVariable.ShowDialog();
                if (frmEditVariable.DialogResult == DialogResult.OK)
                {
                    variable.Name = frmEditVariable.Variable.Name;
                    variable.Value = frmEditVariable.Variable.Value;
                    snapshot.Variables.Add(variable);
                    FillEnvironmentVariables(dgv, snapshot);
                    snapshotManager.SaveSnapshot(ref snapshot);
                }
                frmEditVariable.Dispose();
            }
        }

        #endregion Edit Environment Variables

        #region Snapshhot Environment Variables

        private void CreateSnapshot(ListBox lb, string name)
        {
            try
            {
                if (name.Length > 0)
                {
                    EnvironmentSnapshot snapshot = new EnvironmentSnapshot(name, (EnvironmentVariableTarget)lb.Tag);
                    foreach (DictionaryEntry entry in EnvironmentVariableManager.GetEnvironmentVariables((EnvironmentVariableTarget)lb.Tag))
                    {
                        EnvironmentVariable variable = new EnvironmentVariable();
                        variable.Name = entry.Key.ToString();
                        variable.Value = EnvironmentVariableManager.GetEnvironmentVariable(variable.Name, (EnvironmentVariableTarget)lb.Tag);
                        snapshot.Variables.Add(variable);
                    }
                    if (snapshotManager.AppendSnapshot(snapshot))
                    {
                        lb.Items.Add(snapshot.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void DeleteSnapshot(ListBox lb)
        {
            int index = lb.SelectedIndex;
            if (index > 0)
            {
                EnvironmentSnapshot snapshot = snapshotManager.GetSnapshot(index, (EnvironmentVariableTarget)lb.Tag, false);
                if (snapshotManager.RemoveSnapshot(snapshot))
                {
                    lb.Items.RemoveAt(index);
                    lb.SelectedIndex = 0;
                }
            }
        }

        private void ActivateSnapshot(ListBox lb)
        {
            int index = lb.SelectedIndex;
            if (index > 0)
            {
                EnvironmentVariableTarget target = (EnvironmentVariableTarget)lb.Tag;
                EnvironmentSnapshot snapshot = snapshotManager.GetSnapshot(index, target);
                EnvironmentSnapshot current = snapshotManager.GetSnapshot(0, target);
                if (snapshot != null)
                {
                    EnvironmentVariableManager.Begin(snapshot.Target);
                    foreach (var variable in current.Variables)
                    {
                        EnvironmentVariableManager.DeleteEnvironmentVariable(variable.Name, target);
                    }
                    current.Variables.Clear();
                    foreach (var variable in snapshot.Variables)
                    {
                        EnvironmentVariableManager.SetEnvironmentVariable(variable.Name, variable.Value, target);
                        current.Variables.Add(variable.Clone() as EnvironmentVariable);
                    }
                    EnvironmentVariableManager.End(snapshot.Target);
                    lb.SelectedIndex = 0;
                }
            }
        }

        private void cmsSnapshot_Opening(object sender, CancelEventArgs e)
        {
            var listBox = (sender as ContextMenuStrip).SourceControl as ListBox;
            if (listBox != null)
            {
                int index = listBox.IndexFromPoint(listBox.PointToClient(Cursor.Position));
                if (index != -1)
                    listBox.SelectedIndex = index;
                e.Cancel = (listBox.SelectedIndex <= 0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivateSnapshot(((sender as ToolStripDropDownItem).GetCurrentParent() as ContextMenuStrip).SourceControl as ListBox);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSnapshot(((sender as ToolStripDropDownItem).GetCurrentParent() as ContextMenuStrip).SourceControl as ListBox);
        }

        private void lbUsrVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbUsrVariables.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                tbSnapshotUsrVariables.Text = (index > 0) ?lbUsrVariables.SelectedItem.ToString() : "";
                FillEnvironmentVariables(dgvUsrVariables, snapshotManager.GetSnapshot(index, (EnvironmentVariableTarget)lbUsrVariables.Tag));
            }
            else
            {
                tbSnapshotUsrVariables.Text = "";
            }
        }

        private void btnSnapshotUsrVariables_Click(object sender, EventArgs e)
        {
            CreateSnapshot(lbUsrVariables, tbSnapshotUsrVariables.Text);
        }

        private void tbSnapshotUsrVariables_TextChanged(object sender, EventArgs e)
        {
            btnSnapshotUsrVariables.Enabled = (tbSnapshotUsrVariables.Text.Length > 0);
        }

        private void lbSysbVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbSysVariables.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                tbSnapshotSysVariables.Text = (index > 0) ? lbSysVariables.SelectedItem.ToString() : "";
                FillEnvironmentVariables(dgvSysVariables, snapshotManager.GetSnapshot(index, (EnvironmentVariableTarget)lbSysVariables.Tag));
            }
            else
            {
                tbSnapshotSysVariables.Text = "";
            }
        }

        private void btnSnapshotSysVariables_Click(object sender, EventArgs e)
        {
            CreateSnapshot(lbSysVariables, tbSnapshotSysVariables.Text);
        }

        private void tbSnapshotSysVariables_TextChanged(object sender, EventArgs e)
        {
            btnSnapshotSysVariables.Enabled = (tbSnapshotSysVariables.Text.Length > 0);
        }

        #endregion

        #region Controls

        private EnvironmentSnapshot DgvSnapshot(ListBox lb, DataGridView dgv)
        {
            var index = lb.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                return snapshotManager.GetSnapshot(index, (EnvironmentVariableTarget)lb.Tag, false);
            }
            return null;
        }

        private EnvironmentVariable DgvVariable(ListBox lb, DataGridView dgv)
        {
            var index = lb.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                var snapshot = snapshotManager.GetSnapshot(index, (EnvironmentVariableTarget)lb.Tag, false);
                var rowindex = dgv.CurrentRow.Index;
                if (rowindex != -1)
                {
                    return snapshot.GetVariable(dgv.Rows[rowindex].Cells[0].Value.ToString());
                }
            }
            return null;
        }

        private List<EnvironmentVariable> DgvVariables(ListBox lb, DataGridView dgv)
        {
            
            var index = lb.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                var snapshot = snapshotManager.GetSnapshot(index, (EnvironmentVariableTarget)lb.Tag, false);
                List<EnvironmentVariable> variables = new List<EnvironmentVariable>();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    variables.Add(snapshot.GetVariable(row.Cells[0].Value.ToString()));
                }
                return variables;
            }
            return null;
        }

        private void EnvManager_HandleDestroyed(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void EnvManager_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            if (sender.Equals(btnEditUsrVariable))
            {
                ModifyEnvVar(lbUsrVariables, dgvUsrVariables);
            }
            else if (sender.Equals(btnEditSysVariable))
            {
                ModifyEnvVar(lbSysVariables, dgvSysVariables);
            }
            else if (sender.Equals(btnNewUsrVariable))
            {
                CreateEnvVar(lbUsrVariables, dgvUsrVariables);
            }
            else if (sender.Equals(btnNewSysVariable))
            {
                CreateEnvVar(lbSysVariables, dgvSysVariables);
            }
            else if (sender.Equals(btnDeleteSysVariable))
            {
                DeleteEnvVar(lbSysVariables, dgvSysVariables);
            }
            else if (sender.Equals(btnDeleteUsrVariable))
            {
                DeleteEnvVar(lbUsrVariables, dgvUsrVariables);
            }
        }

        private void DgvCellMouseDoubleClick (object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            ListBox lb = ((EnvironmentVariableTarget)dgv.Tag == EnvironmentVariableTarget.User) ? lbUsrVariables : lbSysVariables;
            if (e.RowIndex > -1)
            {
                ModifyEnvVar(lb, dgv);
            }
        }

        #endregion Controls Events

        #region Settings

        private void LoadSettings()
        {
        }

        private void SaveSettings()
        {
            settings.Save();
        }

        #endregion Settings

        private void dgvSysVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnEditSysVariable.Enabled = (dgvSysVariables.SelectedRows.Count == 1);
        }

        private void dgvUsrVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnEditUsrVariable.Enabled = (dgvUsrVariables.SelectedRows.Count == 1);
        }

        private EnvironmentSnapshot snapshot = null;

        private void dgvUsrVariables_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (snapshot == null)
            {
                snapshot = DgvSnapshot(lbUsrVariables, dgvUsrVariables);
                if (snapshot.Name == "[Current]")
                {
                    EnvironmentVariableManager.Begin(snapshot.Target);
                }
            }
            var variable = snapshot.Variables[e.Row.Index];
            if (snapshot.Name == "[Current]")
            {
                EnvironmentVariableManager.DeleteEnvironmentVariable(variable.Name, snapshot.Target);
            }
            snapshot.Variables.Remove(variable);
        }

        private void dgvUsrVariables_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (snapshot != null)
            {
                if (snapshot.Name == "[Current]")
                {
                    EnvironmentVariableManager.End(snapshot.Target);
                }
                snapshotManager.SaveSnapshot(ref snapshot);
                FillEnvironmentVariables(dgvUsrVariables, snapshot);
                snapshot = null;
            }
        }

        private void dgvUsrVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = MessageBox.Show("Are you sure to remove these variables?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }

        private void dgvSysVariables_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (snapshot == null)
            {
                snapshot = DgvSnapshot(lbSysVariables, dgvSysVariables);
                if (snapshot.Name == "[Current]")
                {
                    EnvironmentVariableManager.Begin(snapshot.Target);
                }
            }
            var variable = snapshot.Variables[e.Row.Index];
            if (snapshot.Name == "[Current]")
            {
                EnvironmentVariableManager.DeleteEnvironmentVariable(variable.Name, snapshot.Target);
            }
            snapshot.Variables.Remove(variable);
        }

        private void dgvSysVariables_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (snapshot != null)
            {
                if (snapshot.Name == "[Current]")
                {
                    EnvironmentVariableManager.End(snapshot.Target);
                }
                snapshotManager.SaveSnapshot(ref snapshot);
                FillEnvironmentVariables(dgvSysVariables, snapshot);
                snapshot = null;
            }
        }

        private void dgvSysVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = MessageBox.Show("Are you sure to remove these variables?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }
    }
}
