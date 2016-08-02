using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cybele.Thinfinity;
using Cybele.Thinfinity.WebComponents;

namespace JsROVideo
{
    public partial class frmMain : Form
    {
        private VirtualUI vui;
        private VuiVideo video;
        private Boolean playing = false;

        public frmMain()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            cmbMp4.SelectedIndex = 0;

            vui = new VirtualUI();
            vui.Start();

            video = new VuiVideo();
            video.OnStateChanged += video_OnStateChanged;
            video.OnPositionChanged += video_OnPositionChanged;
            video.OnLengthChanged += video_OnLengthChanged;
            video.CreateComponent(panelXVideo);

            groupBox1.Enabled = false;

            var mediafile = Path.GetFullPath(video.XTagDir + @"..\demos\vui-video\media\big_buck_bunny_480p_2mb.mp4");

            cmbMp4.Items.Insert(0, mediafile);
        }

        private void video_OnLengthChanged(object sender, EventArgs e)
        {
            slider.Maximum = (Int32)(video.Length * 100);
            groupBox1.Enabled = true;
        }

        private void video_OnStateChanged(object sender, EventArgs e)
        {
            lblStatus.Text = video.State;
        }

        private void video_OnPositionChanged(object sender, EventArgs e)
        {
            this.slider.Scroll -= new System.EventHandler(this.slider_Scroll);
            slider.Value = (Int32)(video.Position * 100);
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
        }

        private void btnGo_xvideo1_Click(object sender, EventArgs e)
        {
            video.Src = cmbMp4.Text;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                btnPlay.Text = "Pause";
                video.Play();
            }
            else
            {
                btnPlay.Text = "Play";
                video.Pause();
            }
            playing = !playing;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnPlay.Text = "Play";
            playing = false;
            video.Stop();
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine("Scroll");
            video.Move(((float)slider.Value)/100);
        }

    }
}
