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
using System.Collections;
using EnvManager.Properties;

namespace EnvManager.Handlers
{
    /// <summary>
    /// Holds list of executed commands for Undo, Redo Functionality
    /// </summary>
    public class CommandStack
    {
        #region Variables
        private List<ICommand> commandsList = null;
        private int currentCommandIndex = -1;   // -1 no command executed
        private string undoMsg = "";
        private string redoMsg = "";
        #endregion Variables

        public CommandStack()
        {
            commandsList = new List<ICommand>();
            SetUndoRedoMessages();
        }

        #region Properties
        public string UndoMsg
        {
            get { return undoMsg; }
        }
        public string RedoMsg
        {
            get { return redoMsg; }
        }
        public bool CanUndo
        {
            get
            {
                return currentCommandIndex != -1;
            }
        }
        public bool CanRedo
        {
            get
            {
                return commandsList.Count > 0
                    && currentCommandIndex != commandsList.Count - 1;
            }
        }
        #endregion Properties

        #region Functions
        /// <summary>
        /// Executes Undo of the current command from the list.
        /// </summary>
        public void Undo()
        {
            ICommand command = commandsList[currentCommandIndex] as ICommand;
            command.Undo();
            currentCommandIndex -= 1;
            SetUndoRedoMessages();
        }
        /// <summary>
        /// Executes Undo of the next command from the list after current.
        /// </summary>
        public void Redo()
        {
            ICommand command = commandsList[++currentCommandIndex] as ICommand;
            command.Redo();
            SetUndoRedoMessages();
        }
        /// <summary>
        /// Adds the specified command to a list.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Add(ICommand command)
        {
            if (commandsList.Count > 0 && currentCommandIndex != commandsList.Count - 1)
            {   // remove all the commands after current
                if(currentCommandIndex == -1)
                {
                    commandsList.RemoveRange(0, commandsList.Count);
                }
                else
                {
                    commandsList.RemoveRange(currentCommandIndex + 1,
                        commandsList.Count - (currentCommandIndex == -1 ? 0 : currentCommandIndex) - 1);
                }   
            }

            // add command to a list and increment index
            commandsList.Add(command);
            currentCommandIndex += 1;
            SetUndoRedoMessages();
        }
        private void SetUndoRedoMessages()
        {
            undoMsg = (this.CanUndo == true
                ? Resources.ToolTipUndo + " " + (commandsList[currentCommandIndex] as ICommand).Name
                : Resources.ToolTipUndo);
            redoMsg = (this.CanRedo == true
                ? Resources.ToolTipRedo + " " + (commandsList[currentCommandIndex + 1] as ICommand).Name
                : Resources.ToolTipRedo);
        }
        #endregion Functions

        /// <summary>
        /// Clears list of commands.
        /// </summary>
        public void Clear()
        {
            this.commandsList.Clear();
            this.currentCommandIndex = -1;
        }
    }
}
