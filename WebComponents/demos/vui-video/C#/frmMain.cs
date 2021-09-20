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


            vui = new VirtualUI();
            vui.Start();
            video = new VuiVideo();
            txtXTagPath.Text = video.XTagDir;
            lblConsole.Visible = false;
            video.OnLengthChanged += video_OnLengthChanged;
            video.OnStateChanged += video_OnStateChanged;
            video.OnPositionChanged += video_OnPositionChanged;
            video.CreateComponent(panelXVideo);

            groupBox1.Enabled = false;
            addLocalMediaFiles();
            addInternetMedia();
        }
        private void addLocalMediaFiles() {
            String targetDirectory = video.Dir + @"media";
            if (Directory.Exists(targetDirectory))
            {
                String[] fileEntries = Directory.GetFiles(targetDirectory,"*.mp4");
                foreach (String fileName in fileEntries)
                {
                    cmbMp4.Items.Insert(cmbMp4.Items.Count, fileName);
                }
                cmbMp4.SelectedIndex = 0;
            }
        }
        private void addInternetMedia()
        {
            cmbMp4.Items.Insert(cmbMp4.Items.Count, "http://mirror.cessen.com/blender.org/peach/trailer/trailer_720p.mov");
            //cmbMp4.Items.Insert(cmbMp4.Items.Count, "https://www.w3schools.com/html/mov_bbb.mp4");

            //cmbMp4.Items.Insert(0, Path.GetFullPath(video.Dir + @"\media\movie.mp4"));
            //cmbMp4.Items.Insert(1, Path.GetFullPath(video.Dir + @"\media\thinfinity_virtualUI_net.mp4"));
            //cmbMp4.Items.Insert(2, Path.GetFullPath(video.Dir + @"\media\zScope_anywhere_iOS_App.mp4"));

            //cmbMp4.Items.Insert(3, Path.GetFullPath(video.Dir + @"\media\ocean.mp4"));
            //cmbMp4.Items.Insert(4, Path.GOnLengthChangedetFullPath(video.Dir + @"\media\big_buck_bunny_480p_2mb.mp4"));
            //cmbMp4.Items.Insert(5, Path.GetFullPath(video.Dir + @"\media\videoviewdemo.mp4"));
            //cmbMp4.Items.Insert(6, Path.GetFullPath(video.Dir + @"\media\movie.mp4"));
            //cmbMp4.Items.Insert(6, Path.GetFullPath(video.Dir + @"\media\movie.mp4"));
            //cmbMp4.Items.Insert(7, Path.GetFullPath(video.XTagDir + @"..\demos\vui-video\media\big_buck_bunny_480p_2mb.mp4"));
        }
        public void controlInvokerText(Control c, String text)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate { c.Text = text; }));
            }
            else
            {
                c.Text = text;
            }
        }
        private void video_OnLengthChanged(object sender, EventArgs e)
        {
            controlInvokerText(lblConsole, "video_OnLengthChanged");
            Int32 vLen = (Int32)(video.Length * 100);
            if (slider.InvokeRequired) {
                 slider.Invoke(new MethodInvoker(delegate { slider.Maximum = vLen; }));
            } else {
                slider.Maximum =vLen;
            }
            if (groupBox1.InvokeRequired)
            {
                groupBox1.Invoke(new MethodInvoker(delegate { groupBox1.Enabled = true; }));
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void video_OnStateChanged(object sender, EventArgs e)
        {
            string vstate = video.State;
            controlInvokerText(lblStatus, vstate);
            if (vstate == "Ended")
            {
                controlInvokerText(btnPlay, "Play");
                video.Stop();
            }
            controlInvokerText(lblConsole, "video_OnStateChanged");
        }

        private void video_OnPositionChanged(object sender, EventArgs e)
        {
            controlInvokerText(lblConsole, "video_OnPositionChanged");
            this.slider.Scroll -= new System.EventHandler(this.slider_Scroll);
            Int32 iPos = (Int32)(video.Position * 100);
            if (slider.InvokeRequired)
            {
                slider.Invoke(new MethodInvoker(delegate { slider.Value = iPos; }));
            }
            else
            {
                slider.Value = iPos;
            }
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
        }

        private void btnGo_xvideo1_Click(object sender, EventArgs e)
        {
            controlInvokerText(lblConsole, "btnGo_xvideo1_Click");
            video.Src = cmbMp4.Text;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                controlInvokerText(btnPlay, "Pause");
                video.Play();
                controlInvokerText(lblConsole, "btnPlay_Click, Play");
            }
            else
            {
                controlInvokerText(btnPlay, "Play");
                video.Pause();
                controlInvokerText(lblConsole, "btnPlay_Click, Pause");
            }
            playing = !playing;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            controlInvokerText(btnPlay, "Play");
            playing = false;
            controlInvokerText(lblStatus, "Stopped");
            video.Stop();
            controlInvokerText(lblConsole, "btnStop_Click");
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine("Scroll");
            video.Move(((float)slider.Value)/100);
            controlInvokerText(lblConsole, "slider_Scroll");
        }

    }
}
