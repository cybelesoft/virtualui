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
        public JSObject RemoteBrowser;

        public Form1()
        {

            vui = new VirtualUI();
            vui.Start();
            vui.AllowExecute(".+");

            RemoteBrowser = new JSObject("browser1");
            RemoteBrowser.Properties.Add("url").AsString = "";
            RemoteBrowser.Events.Add("go");
            RemoteBrowser.ApplyModel();


            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Url = textBox1.Text;

            vui.HTMLDoc.CreateComponent("browser1", "<iframe id='myIframe' style=margin:0;padding:0;border:none;width:100%;height:100%;background-color:white src=" + Url + "></iframe>", panel1.Handle);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            RemoteBrowser.Properties["url"].AsString = textBox1.Text;

            RemoteBrowser.Events["go"].Fire();

        }
    }
}
