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

namespace JsROAudio
{
    public partial class frmJsROAudio : Form
    {
        private VirtualUI vui;
        private VuiAudio vuiaudio;
        private Boolean playing = false;

        public frmJsROAudio()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            vui = new VirtualUI();
            vui.Start();

            vuiaudio = new VuiAudio();
            vuiaudio.OnStateChanged += audio_OnStateChanged;
            vuiaudio.OnPositionChanged += audio_OnPositionChanged;
            vuiaudio.OnLengthChanged += audio_OnLengthChanged;
            vuiaudio.OnDurationChanged += audio_OnDurationChanged;
            vuiaudio.OnDisableSlider += audio_OnDisableSlider;
            vuiaudio.CreateComponent(panelXAudio);
            addLocalMediaFiles();
            //addInternetMedia();

        }

        private void addLocalMediaFiles()
        {
            String targetDirectory = vuiaudio.Dir + @"media";
            if (Directory.Exists(targetDirectory))
            {
                String[] fileEntries = Directory.GetFiles(targetDirectory, "*.mp3");
                foreach (String fileName in fileEntries)
                {
                    cmbAudio.Items.Insert(cmbAudio.Items.Count, fileName);
                }
                cmbAudio.SelectedIndex = 0;
            }
        }

        private void sliderMaximum(Int32 value) {
            if (slider.InvokeRequired)
            {
                slider.Invoke(new MethodInvoker(delegate { slider.Maximum = value; }));
            }
            else
            {
                slider.Maximum = value;
            }
        }
        private void sliderValue(Int32 value)
        {
            if (slider.InvokeRequired)
            {
                slider.Invoke(new MethodInvoker(delegate { slider.Value = value; }));
            }
            else
            {
                slider.Value = value;
            }
        }
        private void controlInvoker(Control c, String text)
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

        private void audio_OnLengthChanged(object sender, EventArgs e)
        {
            sliderMaximum((Int32)(vuiaudio.Length * 100));
            controlInvoker(lblDuration, "0");
            controlInvoker(lblStart, "0");
        }

        private void audio_OnDurationChanged(object sender, EventArgs e)
        {
            controlInvoker(lblDuration,new TimeSpan((long)vuiaudio.Duration * 10000000).ToString(@"hh\:mm\:ss\.fff"));
        }

        private void audio_OnStateChanged(object sender, EventArgs e)
        {
            controlInvoker(lblStatus, vuiaudio.State);
            if (vuiaudio.State.ToLower() == "ended")
            {
                controlInvoker(btnPlay,"Play");
                vuiaudio.Stop();
            }
        }

        private void audio_OnPositionChanged(object sender, EventArgs e)
        {
            this.slider.Scroll -= new System.EventHandler(this.slider_Scroll);
            sliderValue((Int32)(vuiaudio.Position * 100));
            controlInvoker(lblStart, new TimeSpan((long)vuiaudio.Position * 10000000).ToString(@"hh\:mm\:ss\.fff"));
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
        }

        private void audio_OnDisableSlider(object sender, EventArgs e)
        {
            slider.Visible = vuiaudio.Slider;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                controlInvoker(btnPlay, "Pause");
                vuiaudio.Play();
            }
            else
            {
                controlInvoker(btnPlay, "Play");
                vuiaudio.Pause();
            }
            playing = !playing;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            controlInvoker(btnPlay, "Play");
            playing = false;
            controlInvoker(lblStatus, "Stopped");
            vuiaudio.Stop();
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine("Scroll");
            vuiaudio.Move(((float)slider.Value) / 100);
        }

        private void cmbAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            vuiaudio.Src = cmbAudio.Text;
            playing = false;
            controlInvoker(lblStatus, "Stopped");
            vuiaudio.Stop();
            controlInvoker(btnPlay, "Play");
            //vuiaudio.Play();
        }
    }
}
