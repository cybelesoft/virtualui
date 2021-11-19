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

            //Creates the iframe on the browser side, with id "myIframe". This is used to handle the iframe on a JS side.
            //https://files.cybelesoft.com/manuals/symbolreference/index.html?00293.html
            vui.HTMLDoc.CreateComponent("browser1", "<iframe id='myIframe' style=margin:0;padding:0;border:none;width:100%;height:100%;background-color:white src=" + Url + "></iframe>", panel1.Handle);
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            RemoteBrowser.Properties["url"].AsString = textBox1.Text;
            //Fires jsro.on('browser1', "go", function (url)
            RemoteBrowser.Events["go"].Fire();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Creates a URL that publishes a file
            //https://files.cybelesoft.com/manuals/symbolreference/index.html?00118.html
            string mySafeUrl = vui.HTMLDoc.GetSafeUrl(AppDomain.CurrentDomain.BaseDirectory+"\\big_buck_bunny_480p_2mb.mp4");

            RemoteBrowser.Properties["url"].AsString = mySafeUrl;

            RemoteBrowser.Events["go"].Fire();

        }
    }
}
