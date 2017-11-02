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



namespace EnvManager
{
    partial class EnvManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnSnapshotUsrVariables = new System.Windows.Forms.Button();
            this.btnDeleteUsrVariable = new System.Windows.Forms.Button();
            this.btnEditUsrVariable = new System.Windows.Forms.Button();
            this.btnNewUsrVariable = new System.Windows.Forms.Button();
            this.btnSnapshotSysVariables = new System.Windows.Forms.Button();
            this.btnDeleteSysVariable = new System.Windows.Forms.Button();
            this.btnEditSysVariable = new System.Windows.Forms.Button();
            this.btnNewSysVariable = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbUsrVariables = new System.Windows.Forms.ListBox();
            this.cmsSnapshot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSnapshotUsrVariables = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvUsrVariables = new System.Windows.Forms.DataGridView();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSysVariables = new System.Windows.Forms.ListBox();
            this.tbSnapshotSysVariables = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSysVariables = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsSnapshot.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsrVariables)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSysVariables)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnapshotUsrVariables
            // 
            this.btnSnapshotUsrVariables.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSnapshotUsrVariables.Enabled = false;
            this.btnSnapshotUsrVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapshotUsrVariables.Image = ((System.Drawing.Image)(resources.GetObject("btnSnapshotUsrVariables.Image")));
            this.btnSnapshotUsrVariables.Location = new System.Drawing.Point(124, 571);
            this.btnSnapshotUsrVariables.Name = "btnSnapshotUsrVariables";
            this.btnSnapshotUsrVariables.Size = new System.Drawing.Size(24, 26);
            this.btnSnapshotUsrVariables.TabIndex = 16;
            this.toolTip.SetToolTip(this.btnSnapshotUsrVariables, "Snapshot Variables");
            this.btnSnapshotUsrVariables.UseVisualStyleBackColor = true;
            this.btnSnapshotUsrVariables.Click += new System.EventHandler(this.btnSnapshotUsrVariables_Click);
            // 
            // btnDeleteUsrVariable
            // 
            this.btnDeleteUsrVariable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteUsrVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUsrVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUsrVariable.Image")));
            this.btnDeleteUsrVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUsrVariable.Location = new System.Drawing.Point(568, 571);
            this.btnDeleteUsrVariable.Name = "btnDeleteUsrVariable";
            this.btnDeleteUsrVariable.Size = new System.Drawing.Size(85, 26);
            this.btnDeleteUsrVariable.TabIndex = 11;
            this.btnDeleteUsrVariable.Text = "&Delete";
            this.toolTip.SetToolTip(this.btnDeleteUsrVariable, "Delete Variable");
            this.btnDeleteUsrVariable.UseVisualStyleBackColor = true;
            this.btnDeleteUsrVariable.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnEditUsrVariable
            // 
            this.btnEditUsrVariable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditUsrVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUsrVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnEditUsrVariable.Image")));
            this.btnEditUsrVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditUsrVariable.Location = new System.Drawing.Point(468, 571);
            this.btnEditUsrVariable.Name = "btnEditUsrVariable";
            this.btnEditUsrVariable.Size = new System.Drawing.Size(85, 26);
            this.btnEditUsrVariable.TabIndex = 10;
            this.btnEditUsrVariable.Text = "&Edit";
            this.toolTip.SetToolTip(this.btnEditUsrVariable, "Edit Variable");
            this.btnEditUsrVariable.UseVisualStyleBackColor = true;
            this.btnEditUsrVariable.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnNewUsrVariable
            // 
            this.btnNewUsrVariable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewUsrVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUsrVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnNewUsrVariable.Image")));
            this.btnNewUsrVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewUsrVariable.Location = new System.Drawing.Point(368, 571);
            this.btnNewUsrVariable.Name = "btnNewUsrVariable";
            this.btnNewUsrVariable.Size = new System.Drawing.Size(85, 26);
            this.btnNewUsrVariable.TabIndex = 9;
            this.btnNewUsrVariable.Text = "&New";
            this.toolTip.SetToolTip(this.btnNewUsrVariable, "Create New Variable");
            this.btnNewUsrVariable.UseVisualStyleBackColor = true;
            this.btnNewUsrVariable.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnSnapshotSysVariables
            // 
            this.btnSnapshotSysVariables.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSnapshotSysVariables.Enabled = false;
            this.btnSnapshotSysVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapshotSysVariables.Image = ((System.Drawing.Image)(resources.GetObject("btnSnapshotSysVariables.Image")));
            this.btnSnapshotSysVariables.Location = new System.Drawing.Point(124, 571);
            this.btnSnapshotSysVariables.Name = "btnSnapshotSysVariables";
            this.btnSnapshotSysVariables.Size = new System.Drawing.Size(24, 26);
            this.btnSnapshotSysVariables.TabIndex = 17;
            this.toolTip.SetToolTip(this.btnSnapshotSysVariables, "Snapshot Variables");
            this.btnSnapshotSysVariables.UseVisualStyleBackColor = true;
            this.btnSnapshotSysVariables.Click += new System.EventHandler(this.btnSnapshotSysVariables_Click);
            // 
            // btnDeleteSysVariable
            // 
            this.btnDeleteSysVariable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteSysVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSysVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSysVariable.Image")));
            this.btnDeleteSysVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSysVariable.Location = new System.Drawing.Point(569, 571);
            this.btnDeleteSysVariable.Name = "btnDeleteSysVariable";
            this.btnDeleteSysVariable.Size = new System.Drawing.Size(84, 26);
            this.btnDeleteSysVariable.TabIndex = 16;
            this.btnDeleteSysVariable.Text = "De&lete";
            this.toolTip.SetToolTip(this.btnDeleteSysVariable, "Delete Variable");
            this.btnDeleteSysVariable.UseVisualStyleBackColor = true;
            this.btnDeleteSysVariable.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnEditSysVariable
            // 
            this.btnEditSysVariable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditSysVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSysVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSysVariable.Image")));
            this.btnEditSysVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditSysVariable.Location = new System.Drawing.Point(469, 571);
            this.btnEditSysVariable.Name = "btnEditSysVariable";
            this.btnEditSysVariable.Size = new System.Drawing.Size(84, 26);
            this.btnEditSysVariable.TabIndex = 15;
            this.btnEditSysVariable.Text = "Ed&it";
            this.toolTip.SetToolTip(this.btnEditSysVariable, "Edit Variable");
            this.btnEditSysVariable.UseVisualStyleBackColor = true;
            this.btnEditSysVariable.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnNewSysVariable
            // 
            this.btnNewSysVariable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewSysVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSysVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSysVariable.Image")));
            this.btnNewSysVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSysVariable.Location = new System.Drawing.Point(369, 571);
            this.btnNewSysVariable.Name = "btnNewSysVariable";
            this.btnNewSysVariable.Size = new System.Drawing.Size(84, 26);
            this.btnNewSysVariable.TabIndex = 14;
            this.btnNewSysVariable.Text = "Ne&w";
            this.toolTip.SetToolTip(this.btnNewSysVariable, "Create New Variable");
            this.btnNewSysVariable.UseVisualStyleBackColor = true;
            this.btnNewSysVariable.Click += new System.EventHandler(this.BtnClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(828, 637);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(820, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Variables";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(814, 601);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Controls.Add(this.lbUsrVariables, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSnapshotUsrVariables, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbSnapshotUsrVariables, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(151, 601);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbUsrVariables
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lbUsrVariables, 2);
            this.lbUsrVariables.ContextMenuStrip = this.cmsSnapshot;
            this.lbUsrVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsrVariables.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUsrVariables.FormattingEnabled = true;
            this.lbUsrVariables.IntegralHeight = false;
            this.lbUsrVariables.ItemHeight = 21;
            this.lbUsrVariables.Location = new System.Drawing.Point(3, 3);
            this.lbUsrVariables.Name = "lbUsrVariables";
            this.lbUsrVariables.Size = new System.Drawing.Size(145, 562);
            this.lbUsrVariables.TabIndex = 22;
            this.lbUsrVariables.SelectedIndexChanged += new System.EventHandler(this.lbUsrVariables_SelectedIndexChanged);
            // 
            // cmsSnapshot
            // 
            this.cmsSnapshot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsSnapshot.Name = "cmsSnapshot";
            this.cmsSnapshot.Size = new System.Drawing.Size(118, 48);
            this.cmsSnapshot.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSnapshot_Opening);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.activateToolStripMenuItem.Text = "&Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tbSnapshotUsrVariables
            // 
            this.tbSnapshotUsrVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSnapshotUsrVariables.Location = new System.Drawing.Point(3, 571);
            this.tbSnapshotUsrVariables.Name = "tbSnapshotUsrVariables";
            this.tbSnapshotUsrVariables.Size = new System.Drawing.Size(115, 25);
            this.tbSnapshotUsrVariables.TabIndex = 23;
            this.tbSnapshotUsrVariables.TextChanged += new System.EventHandler(this.tbSnapshotUsrVariables_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgvUsrVariables, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDeleteUsrVariable, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnEditUsrVariable, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnNewUsrVariable, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(661, 601);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dgvUsrVariables
            // 
            this.dgvUsrVariables.AllowUserToAddRows = false;
            this.dgvUsrVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.dgvUsrVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsrVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsrVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.Value});
            this.tableLayoutPanel3.SetColumnSpan(this.dgvUsrVariables, 4);
            this.dgvUsrVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsrVariables.Location = new System.Drawing.Point(3, 3);
            this.dgvUsrVariables.Name = "dgvUsrVariables";
            this.dgvUsrVariables.RowHeadersVisible = false;
            this.dgvUsrVariables.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsrVariables.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsrVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsrVariables.Size = new System.Drawing.Size(655, 562);
            this.dgvUsrVariables.TabIndex = 21;
            this.dgvUsrVariables.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCellMouseDoubleClick);
            this.dgvUsrVariables.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvUsrVariables_RowsRemoved);
            this.dgvUsrVariables.SelectionChanged += new System.EventHandler(this.dgvUsrVariables_SelectionChanged);
            this.dgvUsrVariables.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvUsrVariables_UserDeletingRow);
            this.dgvUsrVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUsrVariables_KeyDown);
            // 
            // Variable
            // 
            this.Variable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Variable.FillWeight = 70F;
            this.Variable.HeaderText = "Variable";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            this.Variable.Width = 83;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.FillWeight = 70F;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(820, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "System Variables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(814, 601);
            this.splitContainer2.SplitterDistance = 151;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Controls.Add(this.btnSnapshotSysVariables, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbSysVariables, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbSnapshotSysVariables, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(151, 601);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lbSysVariables
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.lbSysVariables, 2);
            this.lbSysVariables.ContextMenuStrip = this.cmsSnapshot;
            this.lbSysVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSysVariables.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSysVariables.FormattingEnabled = true;
            this.lbSysVariables.IntegralHeight = false;
            this.lbSysVariables.ItemHeight = 21;
            this.lbSysVariables.Location = new System.Drawing.Point(3, 3);
            this.lbSysVariables.Name = "lbSysVariables";
            this.lbSysVariables.Size = new System.Drawing.Size(145, 562);
            this.lbSysVariables.TabIndex = 22;
            this.lbSysVariables.SelectedIndexChanged += new System.EventHandler(this.lbSysbVariables_SelectedIndexChanged);
            // 
            // tbSnapshotSysVariables
            // 
            this.tbSnapshotSysVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSnapshotSysVariables.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSnapshotSysVariables.Location = new System.Drawing.Point(3, 571);
            this.tbSnapshotSysVariables.Name = "tbSnapshotSysVariables";
            this.tbSnapshotSysVariables.Size = new System.Drawing.Size(115, 25);
            this.tbSnapshotSysVariables.TabIndex = 23;
            this.tbSnapshotSysVariables.TextChanged += new System.EventHandler(this.tbSnapshotSysVariables_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvSysVariables, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteSysVariable, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNewSysVariable, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEditSysVariable, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 601);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvSysVariables
            // 
            this.dgvSysVariables.AllowUserToAddRows = false;
            this.dgvSysVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.dgvSysVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSysVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSysVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvSysVariables, 4);
            this.dgvSysVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSysVariables.Location = new System.Drawing.Point(3, 3);
            this.dgvSysVariables.Name = "dgvSysVariables";
            this.dgvSysVariables.RowHeadersVisible = false;
            this.dgvSysVariables.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSysVariables.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSysVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSysVariables.Size = new System.Drawing.Size(655, 562);
            this.dgvSysVariables.TabIndex = 11;
            this.dgvSysVariables.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCellMouseDoubleClick);
            this.dgvSysVariables.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSysVariables_RowsRemoved);
            this.dgvSysVariables.SelectionChanged += new System.EventHandler(this.dgvSysVariables_SelectionChanged);
            this.dgvSysVariables.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvSysVariables_UserDeletingRow);
            this.dgvSysVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSysVariables_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.FillWeight = 30F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Variable";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 83;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 70F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // EnvManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "EnvManager";
            this.Size = new System.Drawing.Size(828, 637);
            this.Load += new System.EventHandler(this.EnvManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.cmsSnapshot.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsrVariables)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSysVariables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox lbUsrVariables;
        private System.Windows.Forms.Button btnSnapshotUsrVariables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvUsrVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btnDeleteUsrVariable;
        private System.Windows.Forms.Button btnEditUsrVariable;
        private System.Windows.Forms.Button btnNewUsrVariable;
        private System.Windows.Forms.TextBox tbSnapshotUsrVariables;
        private System.Windows.Forms.ContextMenuStrip cmsSnapshot;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSnapshotSysVariables;
        private System.Windows.Forms.DataGridView dgvSysVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnDeleteSysVariable;
        private System.Windows.Forms.Button btnNewSysVariable;
        private System.Windows.Forms.Button btnEditSysVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox lbSysVariables;
        private System.Windows.Forms.TextBox tbSnapshotSysVariables;

    }
}
