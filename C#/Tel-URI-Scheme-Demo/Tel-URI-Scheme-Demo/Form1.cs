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

namespace Tel_URI_Scheme_Demo
{
    public partial class Form1 : Form
    {

        VirtualUI vui;

        public Form1()
        {
            vui = new VirtualUI();
            vui.Start();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vui.OpenLinkDlg($"tel:{textBox1.Text}", "Make Phonecall");
        }
    }
}
