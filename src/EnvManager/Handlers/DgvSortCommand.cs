/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>
   Copyright (C) 2013 evorios <evorioss@gmail.com>

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Windows.Forms;

namespace EnvManager.Handlers
{
    public class DgvSortCommand : DgvCommand
    {
        List<DataGridViewRow> rows;
        List<DataGridViewRow> new_rows;
        int count;

        public DgvSortCommand(DgvHandler dgvHandler, int _count)
            : base(dgvHandler)
        {
            Init();
            this.rows = new List<DataGridViewRow>();
            this.new_rows = new List<DataGridViewRow>();
            this.count = _count;
        }
        private void Init()
        {
            this.name = "Sort Values";
        }
        public override void Execute()
        {
            for (int i = 0; i < this.count; i++)
            {
                rows.Add(dgvHandler.CurrentRow(i));
                new_rows.Add(dgvHandler.CurrentRow(i));
            }
            new_rows.Sort(new comparer());
            Redo();
        }
        public override void Undo()
        {
            dgvHandler.DeleteAllRows();
            dgvHandler.AddRows(rows);
        }
        public override void Redo()
        {
            dgvHandler.DeleteAllRows();
            dgvHandler.AddRows(new_rows);
        }

        class comparer : IComparer<DataGridViewRow>
        {
            public int Compare(DataGridViewRow x, DataGridViewRow y)
            {
                string v1 = x.Cells[1].Value as string;
                string v2 = y.Cells[1].Value as string;
                if (v1 == null) v1 = "";
                if (v2 == null) v2 = "";
                return v1.CompareTo(v2);
            }
        }
    }
}
