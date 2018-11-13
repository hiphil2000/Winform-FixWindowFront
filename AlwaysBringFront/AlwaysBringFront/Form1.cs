using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlwaysBringFront
{
    public partial class Form1 : Form
    {
        #region dllimports
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const Int32 SW_SHOW = 0x0005;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        const Int32 SWP_NOSIZE = 0x0001;
        const Int32 SWP_NOMOVE = 0x0002;
        const Int32 SWP_SHOWWINDOW = 0x0040;
        #endregion

        #region fields
        private bool _isFixed = false;
        private Process _thisProcess = Process.GetCurrentProcess();
        private IntPtr currentFixedHandle;
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();
            ContextMenu context = new ContextMenu();
            context.MenuItems.Add(new MenuItem("Exit", ExitProgram));
            context.MenuItems.Add(new MenuItem("Show", (object o, EventArgs e) =>
            {
                this.Show();
            }));
            notifyIcon1.ContextMenu = context;

        }
        #endregion

        #region events
        private void Combo_ProcessList_DropDown(object sender, EventArgs e)
        {
            Combo_ProcessList.Items.Clear();
            //List<DesktopWindow> windowList = User32Helper.GetDesktopWindows();
            Process[] process = Process.GetProcesses().Where(pro => !string.IsNullOrEmpty(pro.MainWindowTitle) && pro.MainWindowHandle != _thisProcess.MainWindowHandle).ToArray();

            Combo_ProcessList.Items.AddRange(process.Select(pro => $"{pro.ProcessName} : {pro.Id}").ToArray());
        }

        private void Button_Toggle_Click(object sender, EventArgs e)
        {
            if(_isFixed)
            {
                SetWindowPos(currentFixedHandle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE|SWP_NOSIZE);
                currentFixedHandle = IntPtr.Zero;
                _isFixed = false;
                Button_Toggle.Text = "FIX!";
                Combo_ProcessList.Enabled = true;
            }
            else
            {
                if (Combo_ProcessList.SelectedItem == null)
                    return;
                string[] processInfo = Combo_ProcessList.SelectedItem.ToString().Split(':');
                string processName = processInfo[0].Trim();
                string processId = processInfo[1].Trim();

                currentFixedHandle = Process.GetProcessById(int.Parse(processId)).MainWindowHandle;
                if (currentFixedHandle != IntPtr.Zero)
                {
                    ShowWindow(currentFixedHandle, SW_SHOW);
                    SetWindowPos(currentFixedHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                } else
                {
                    MessageBox.Show($"failed to bring front {processName}:{processId}\r\nreason: that window is not available.");
                }
                
                _isFixed = true;
                Button_Toggle.Text = "RELEASE!";
                Combo_ProcessList.Enabled = false;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("set program run on background?", "closing...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }
        #endregion

        #region methods

        #endregion
    }
}
