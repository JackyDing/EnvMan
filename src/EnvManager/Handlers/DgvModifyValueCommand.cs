/*
   EnvMan - The Open-Source Windows Environment Variables Manager
   Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>

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

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EnvManager.Handlers
{
    public class DgvModifyValueCommand : DgvCommand
    {
        protected DataGridViewRow currentRow = null;
        protected DataGridViewRow newRow = null;

        public DgvModifyValueCommand(DgvHandler dgvHandler)
            : base(dgvHandler)
        {

        }

        protected DataGridViewRow CloneRow(DataGridViewRow row)
        {
            DataGridViewRow newRow = row.Clone() as DataGridViewRow;
            newRow.Cells[0].Value = new Bitmap(row.Cells[0].Value as Bitmap);
            newRow.Cells[1].Value = string.Copy(row.Cells[1].Value as String);

            return newRow;
        }

        public override void Undo()
        {
            Console.WriteLine("Undo New Row: " + newRow.Cells[1].Value.ToString());
            dgvHandler.DeleteRow(newRowIndex);
            if (currentRow != null)
            {
                Console.WriteLine("Write Old Row: " + currentRow.Cells[1].Value.ToString());
                dgvHandler.InsertRow(curRowIndex, CloneRow(currentRow));
            }
        }
        public override void Redo()
        {
            if (currentRow != null)
            {
                dgvHandler.DeleteRow(curRowIndex);
            }
            dgvHandler.InsertRow(newRowIndex, CloneRow(newRow));
        }

        public DataGridViewRow CurrentRow
        {
            get
            {
                return currentRow;
            }
        }
        public DataGridViewRow NewRow
        {
            set
            {
                newRow = CloneRow(value);
                newRowIndex = value.Index;
            }
        }
    }
}
