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

namespace MS_URI_Scheme_Demo
{
    public partial class Form1 : Form
    {

        public VirtualUI vui;

        public Form1()
        {

            vui = new VirtualUI();
            vui.Start();
            vui.StdDialogs = true;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

 
            if (openFileDialog.FileName != "")
            {
                string mySafeURL = vui.HTMLDoc.GetSafeUrl(openFileDialog.FileName);

                vui.OpenLinkDlg($"ms-excel:ofv|u|http://127.0.0.1:6080/{mySafeURL}", "Open Excel");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();


            if (openFileDialog.FileName != "")
            {
                string mySafeURL = vui.HTMLDoc.GetSafeUrl(openFileDialog.FileName);

                vui.OpenLinkDlg($"ms-word:ofv|u|http://127.0.0.1:6080/{mySafeURL}", "Open Word");
            }

        }
    }
}
