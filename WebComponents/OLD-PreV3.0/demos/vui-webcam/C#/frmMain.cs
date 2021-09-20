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

namespace VuiWebcamTest
{
    public partial class frmMain : Form
    {
        private VirtualUI vui;
        private VuiWebcam webcam;
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

            webcam = new VuiWebcam();
            webcam.OnBitmapChanged += BitmapChanged;
            webcam.CreateComponent(pnlWebcam);
        }

 
        private void bAttach_Click(object sender, EventArgs e)
        {
            webcam.Attach(pnlWebcam.Width,pnlWebcam.Height);
        }

        private void bFreeze_Click(object sender, EventArgs e)
        {
            if (bFreeze.Text == "Freeze")
            {
                bFreeze.Text = "Unfreeze";
                webcam.Freeze();
            }
            else
            {
                bFreeze.Text = "Freeze";
                webcam.Unfreeze();
            }

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            webcam.Save();
        }

        private void BitmapChanged(object sender, EventArgs e)
        {
            frmPhoto f = new frmPhoto();
            f.SetImage(webcam.Photo);
            f.Show();
        }
    }
}
