using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private VirtualUI vui;
        public MainForm()
        {
            vui = new VirtualUI();
            vui.StdDialogs = true;
            vui.Start();
            remotePrinter = new RemotePrinter();
            InitializeComponent();
        }

        private void btnOpenXps_Click(object sender, EventArgs e)
        {
            openFilesDialog.Title = "Select a XPS File";
            openFilesDialog.InitialDirectory = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetEntryAssembly().Location);            
            openFilesDialog.Filter = "Xps files (*.xps)|*.xps|Oxps files(*.oxps)|*.oxps|All files (*.*)|*.*";
            openFilesDialog.FilterIndex = 1;
            openFilesDialog.DefaultExt = "xps";
            openFilesDialog.CheckFileExists = true;

            if (openFilesDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileNameXps.Text = openFilesDialog.FileName;
            }
        }

        private void btnOpenPdf_Click(object sender, EventArgs e)
        {
            openFilesDialog.Title = "Select a PDF File";
            openFilesDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            openFilesDialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFilesDialog.FilterIndex = 1;
            openFilesDialog.DefaultExt = "pdf";
            openFilesDialog.CheckFileExists = true;

            if (openFilesDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileNamePdf.Text = openFilesDialog.FileName;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFilesDialog.Title = "Select a RAW File";
            openFilesDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            openFilesDialog.Filter = "All files (*.*)|*.*";
            openFilesDialog.FilterIndex = 1;            
            openFilesDialog.CheckFileExists = true;

            if (openFilesDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFilesDialog.FileName;
            }
        }

        private bool CheckFileExists(string FileName)
        {
            if (!File.Exists(FileName))
            {

                MessageBox.Show(String.Format("File \"{0}\" does not exist", Path.GetFileName(FileName)),
                    "Loading File...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnPrintXps_Click(object sender, EventArgs e)
        {
            if (!CheckFileExists(txtFileNameXps.Text)) { return; }

            if (!remotePrinter.PrintFile((int)PrintType.PRINT_TYPE_XPS, txtFileNameXps.Text, String.Empty))
            {
                string errMsg;
                int errCode;
                remotePrinter.LastError(out errCode, out errMsg);
                MessageBox.Show(errMsg);
            }
            else
            {
                MessageBox.Show("done.");
            }
        }

        private void btnPrintPdf_Click(object sender, EventArgs e)
        {
            if (!CheckFileExists(txtFileNamePdf .Text)) { return; }

            if (!remotePrinter.PrintFile((int)PrintType.PRINT_TYPE_PDF, txtFileNamePdf.Text, String.Empty))
            {
                string errMsg;
                int errCode;
                remotePrinter.LastError(out errCode, out errMsg);
                MessageBox.Show(errMsg);
            }
            else
            {
                MessageBox.Show("done.");
            }
        }

        private void btnPrintDirect_Click(object sender, EventArgs e)
        {
            if (!CheckFileExists(txtFileName.Text)) { return; }

            if (!remotePrinter.PrintFile((int)PrintType.PRINT_TYPE_DIRECT, txtFileName.Text, String.Empty))
            {
                string errMsg;
                int errCode;
                remotePrinter.LastError(out errCode, out errMsg);
                MessageBox.Show(errMsg);
            }
            else
            {
                MessageBox.Show("done.");
            }
        }

       
    }
}
