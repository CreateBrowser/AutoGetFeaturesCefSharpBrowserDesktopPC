using CefSharp;
using System;
using CefSharp.SchemeHandler;
using CefSharp.Internals;
using CefSharp.ModelBinding;
using CefSharp.WinForms;
using ChromiumApplication;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;
using MetroFramework.Forms;

namespace ChromiumApplication
{

    /// <summary>
    ///     public partial class Form1 : MaterialForm
    /// </summary>

    /// <summary>
    ///     public partial class Form1 : MetroSetForm
    /// </summary>

    /// <summary>
    ///     public partial class Form1 : CCSkinMain
    /// </summary>

    /// <summary>
    ///     public partial class WindowsMediaPlayer : MaterialForm
    /// </summary>

    /// <summary>
    ///     public partial class WindowsMediaPlayer : MetroForm
    /// </summary>

    /// <summary>
    ///     public partial class WindowsMediaPlayer : MetroSetForm
    /// </summary>

    /// <summary>
    ///      public partial class AGetWindowsMediaPlayer : Form
    /// </summary>



    public partial class WindowsMediaPlayer : Form
    {

        public WindowsMediaPlayer()
        {
            InitializeComponent();
        }

        private void SetOpenLoad(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Video Files(*.mp4)|*.mp4|Audio File(*.mp3)|*.mp3|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MediaPlayer.URL = openFileDialog1.FileName;
                MediaPlayer.URL = (openFileDialog1.FileName);
            }
        }

        private void PlayerProperties(object sender, EventArgs e)
        {
           MediaPlayer.ShowPropertyPages();
        }

        private void Close(object sender, EventArgs e)
        {
           MediaPlayer.close();
        }

        private void Stop(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.stop();
        }

        private void fullScreen(object sender, EventArgs e)
        {
            MediaPlayer.fullScreen = true;
        }

        private void XButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MNO(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            
        }
    }
}
