using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cybele.Thinfinity;

namespace Iframe
{
    public partial class Form1 : Form
    {

        VirtualUI vui;
        private VuiIframe vuiIframe;

        public Form1()
        {
            InitializeComponent();
            InitializeVUI();
        }

        private void InitializeVUI() {
            vui = new VirtualUI();
            vui.Start();
            vui.AllowExecute(".+");

            vuiIframe = new VuiIframe();
            vuiIframe.OnBackgroundColorChanged += VuiIframe_OnBackgroundColorChanged;
            vuiIframe.CreateComponent(iframe, vui);
            vuiIframe.src = txtSrc.Text;
        }

        private void VuiIframe_OnBackgroundColorChanged(object sender, EventArgs e)
        {
            controlInvokerText(txtColor, vuiIframe.color);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            vuiIframe.src = txtSrc.Text;
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK) {
                vuiIframe.color = "rgb(" + MyDialog.Color.R.ToString() + "," + MyDialog.Color.G.ToString() + "," + MyDialog.Color.B.ToString()+")";
            }
        }

        private void controlInvokerText(Control c, String text)
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
    }
}
