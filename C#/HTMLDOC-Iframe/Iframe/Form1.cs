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

        public Form1()
        {

            vui = new VirtualUI();
            vui.Start();
            vui.AllowExecute(".+");

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Url = textBox1.Text;

            // CreateForwarding acts as a Reverse Proxy . For acessing internal resources from outside your LAN
            //string myForward = vui.HTMLDoc.CreateForwarding(Url);
            vui.HTMLDoc.CreateComponent(
                
                "iframe1",
                "<iframe style=margin:0;padding:0;border:none;width:100%;height:100%;background-color:white src=" + Url + "></iframe>", 
                panel1.Handle);
        }
    }
}
