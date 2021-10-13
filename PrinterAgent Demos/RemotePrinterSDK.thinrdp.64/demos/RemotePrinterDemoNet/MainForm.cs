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

namespace RemotePrinterDemoNet
{
    public partial class MainForm : Form
    {
        private RemotePrinter remotePrinter;
        public MainForm()
        {
            remotePrinter = new RemotePrinter();
            InitializeComponent();
        }

        private void BtnGetPrinters_Click(object sender, EventArgs e)
        {
            string printers;
            string errMsg;
            int errCode;
            if (!remotePrinter.GetPrinters(";", out printers)) {
                remotePrinter.LastError(out errCode, out errMsg);
                MessageBox.Show(errMsg);
                return;
            }
            String[] elements = printers.Split(';');
            LBoxPrinters.Items.Clear();
            foreach (var element in elements)
            {
                LBoxPrinters.Items.Add(element);
            }
        }

        private void LBoxPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrinterName.Text = LBoxPrinters.SelectedItem.ToString();
        }

        private void BtnPrintDoc_Click(object sender, EventArgs e)
        {
            bool printing = false, done = false;
            string errMsg, docID;
            int errCode;

            if (remotePrinter.BeginDoc((int)PrintType.PRINT_TYPE_RAW, txtPrinterName.Text, txtDocTitle.Text, (int)Encode.PRINT_ENCODE_UTF8, out docID))
            {
                printing = true;

                if (remotePrinter.Print(docID,textBox1.Text))
                {
                    if (remotePrinter.EndDoc(docID))
                    {
                        done = true;
                        printing = false;
                        MessageBox.Show("done");
                    }
                }

                if (!done)
                {
                    remotePrinter.LastError(out errCode, out errMsg);
                    MessageBox.Show(errMsg);
                }

                if (printing)
                {
                    if (!remotePrinter.Abort(docID))
                    {
                        remotePrinter.LastError(out errCode, out errMsg);
                        MessageBox.Show(errMsg);
                    }
                }

            }
        }
    }
}
