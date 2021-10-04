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
using WebBrowser;

namespace WebBrowser
{
    public partial class Form1 : Form
    {

        VirtualUI vui = new VirtualUI();
        VuiBrowser vuiBrowser;



        public Form1()
        {
            
            vui.Start();


            InitializeComponent();

            vuiBrowser = new VuiBrowser();
            vuiBrowser.CreateComponent(panel1);



        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            vuiBrowser.Go(textBox1.Text);
        }
    }
}
