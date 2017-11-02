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
    public class DgvDeleteDupesCommand : DgvCommand
    {
        List<DataGridViewRow> rows;
        List<int> indexes;

        public DgvDeleteDupesCommand(DgvHandler dgvHandler, List<int> _indexes)
            : base(dgvHandler)
        {
            Init();
            this.indexes = _indexes;
            this.rows = new List<DataGridViewRow>();
        }
        private void Init()
        {
            this.name = "Delete Duplicated Values";
        }
        public override void Execute()
        {
            // execute only when row is not set, i.e. not deleted
            for (int i = 0; i < indexes.Count; i++)
            {
                rows.Add(dgvHandler.CurrentRow(indexes[i]));
            }
            Redo();
        }
        public override void Undo()
        {
            for (var i = 0; i < indexes.Count; i++)
            {
                dgvHandler.InsertRow(indexes[i], rows[i]);
            }
        }
        public override void Redo()
        {
            for (var i = indexes.Count - 1; i >= 0; i--)
            {
                dgvHandler.DeleteRow(indexes[i]);
            }
        }
    }
}
