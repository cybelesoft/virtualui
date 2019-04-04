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

namespace QzPrint
{
    public partial class Form1 : Form
    {
        private VirtualUI vui;
        private VuiQz qz;
        
        public Form1()
        {
            InitializeComponent();
            EnablePanel(panel1, false);

            vui = new VirtualUI();
            vui.Start();

            qz = new VuiQz();
            qz.CreateComponent();
            qz.OnPrinterChange += qz_OnPrinterChange;
            qz.OnStateChanged += qz_OnStateChanged;
        }

        void qz_OnStateChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = qz.State;
        }

        void qz_OnPrinterChange(object sender, EventArgs e)
        {
            cbPrinters.Items.Clear();
            foreach (string s in qz.Printers)
            {
                cbPrinters.Items.Add(s);
            }
            cbPrinters.SelectedIndex = cbPrinters.Items.IndexOf(qz.Default);
            EnablePanel(panel1,true);
        }

        private void bInit_Click(object sender, EventArgs e)
        {
            qz.Init("");
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show(qz.Settings);
        }

        private void bPrintPDF_Click(object sender, EventArgs e)
        {
            qz.PrintPDF(AppDomain.CurrentDomain.BaseDirectory + @"\vui-qz\assets\pdf_sample.pdf");
        }

        private void bPrintZPL_Click(object sender, EventArgs e)
        {
            PrintZPLFile(AppDomain.CurrentDomain.BaseDirectory + @"\vui-qz\assets\zpl_sample.txt");
        }

        private void PrintZPLFile(String filename)
        {
            string[] lines = File.ReadAllLines(filename);
            qz.BeginDoc();
            foreach (string line in lines)
            {
                qz.PrintText(line);
            }
            qz.EndDoc();
        }

        private void EnablePanel(Control ctrl,bool value)
        {
            foreach(Control ct in ctrl.Controls)
            {
                ct.Enabled = value;
            }
        }

        private void cbPrinters_Click(object sender, EventArgs e)
        {
            qz.Default = cbPrinters.Text;

        }
    }
}
