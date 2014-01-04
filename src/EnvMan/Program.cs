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
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace EnvMan
{
    // <summary>
    // This code is borrowed from Code Project post by Michael Potter
    // http://www.codeproject.com/KB/cs/cssingprocess.aspx
    //
    // SingleProgamInstance uses a mutex synchronization object
    // to ensure that only one copy of process is running at
    // a particular time.  It also allows for UI identification
    // of the intial process by bring that window to the foreground.
    // </summary>
    public class SingleProgramInstance : IDisposable
    {
        //Win32 API calls necesary to raise an unowned processs main window
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        //private members 
        private Mutex _processSync;
        private bool _owned = false;

        public SingleProgramInstance()
        {
            //Initialize a named mutex and attempt to
            // get ownership immediatly 
            _processSync = new Mutex(
                true, // desire intial ownership
                Assembly.GetExecutingAssembly().GetName().Name,
                out _owned);
        }

        public SingleProgramInstance(string identifier)
        {
            //Initialize a named mutex and attempt to
            // get ownership immediately.
            //Use an addtional identifier to lower
            // our chances of another process creating
            // a mutex with the same name.
            _processSync = new Mutex(
                true, // desire intial ownership
                Assembly.GetExecutingAssembly().GetName().Name + identifier,
                out _owned);
        }

        ~SingleProgramInstance()
        {
            //Release mutex (if necessary) 
            //This should have been accomplished using Dispose() 
            Release();
        }

        public void Dispose()
        {
            //release mutex (if necessary) and notify 
            // the garbage collector to ignore the destructor
            Release();
            GC.SuppressFinalize(this);
        }

        public void Raise()
        {
            Process proc = Process.GetCurrentProcess();
            // Using Process.ProcessName does not function properly when
            // the name exceeds 15 characters. Using the assembly name
            // takes care of this problem and is more accruate than other
            // work arounds.
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
            {
                //ignore this process
                if (proc.Id != otherProc.Id)
                {
                    // Found a "same named process".
                    // Assume it is the one we want brought to the foreground.
                    // Use the Win32 API to bring it to the foreground.
                    IntPtr hWnd = otherProc.MainWindowHandle;
                    if (IsIconic(hWnd))
                    {
                        ShowWindowAsync(hWnd, SW_RESTORE);
                    }
                    SetForegroundWindow(hWnd);
                    return;
                }
            }
        }

        public bool IsSingleInstance
        {
            //If we don't own the mutex than
            // we are not the first instance.
            get { return _owned; }
        }

        private void Release()
        {
            if (_owned)
            {
                //If we owne the mutex than release it so that
                // other "same" processes can now start.
                _processSync.ReleaseMutex();
                _owned = false;
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main(string[] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (SingleProgramInstance spi = new SingleProgramInstance())
            {
                if (Properties.Settings.Default.OnlyOneInstance)
                {
                    if (spi.IsSingleInstance)
                    {
                        Application.Run(new FormMain());
                    }
                    else
                    {
                        spi.Raise();
                    }
                }
                else
                {
                    Application.Run(new FormMain());
                }
            }
        }
    }
}
