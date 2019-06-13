using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



namespace SetParent
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string sClass, string sWindow);


        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
        int x, int y, int width, int height, uint uFlags);

        private const uint SHOWWINDOW = 0x0040;
        public Form1()
        {
            InitializeComponent();
        }

        private void resizeWow()
        {
            System.Diagnostics.Process[] itunesProcesses =
                System.Diagnostics.Process.GetProcessesByName("Wow");

            if (itunesProcesses.Length > 0)
            {
                SetWindowPos(itunesProcesses[0].MainWindowHandle, this.Handle,
                    0, 0, pb1.Width,
                    pb1.Height, SHOWWINDOW);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nWinHandle = FindWindow(null, "World of Warcraft");

            if (nWinHandle == 0)
            {
                MessageBox.Show("HATA");
            }
            else {

                resizeWow();
                SetParent((IntPtr)nWinHandle, pb1.Handle);
            }

        }
    }
}
