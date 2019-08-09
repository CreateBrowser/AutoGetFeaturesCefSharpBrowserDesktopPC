using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsMediaPlayer
{
    public partial class WindowsMediaPlayer : Form
    {
        public WindowsMediaPlayer()
        {
            InitializeComponent();
        }


        private void SetOpenLoad(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files|*.*";
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

        /*  
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
        */
        private void SetOpenLoadMP4(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Video Files(*.mp4)|*.mp4|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MediaPlayer.URL = openFileDialog1.FileName;
                MediaPlayer.URL = (openFileDialog1.FileName);
            }
        }

        private void SetOpenLoadMP3(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Audio File(*.mp3)|*.mp3|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MediaPlayer.URL = openFileDialog1.FileName;
                MediaPlayer.URL = (openFileDialog1.FileName);
            }
        }
        //


    }
}
