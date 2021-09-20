using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace PrintManyPages
{
    public partial class Form1 : Form
    {
        private Cybele.Thinfinity.VirtualUI vui;
        private StreamReader streamToPrint;
        private Font printFont;
        private int PageCounter;

        public Form1()
        {
            InitializeComponent();
            vui = new Cybele.Thinfinity.VirtualUI();
            vui.Start();
            vui.StdDialogs = false;
            vui.Options = (uint)Cybele.Thinfinity.Options.OPT_SUPRESS_PRINT_DIALOG;
        }


        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            toolStripStatusLabel2.Text = String.Format("Canceled: {0}", ev.Cancel.ToString());

            if (ev.Cancel == true) {
                return;
            } 

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            /*ngambin */
            if (checkBox1.Checked)
            {
                linesPerPage = 1;//ngambin
            }

            // Iterate over the file, printing each line.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;

            PageCounter++;
            toolStripStatusLabel1.Text = String.Format("Last page Printed: {0}", PageCounter);
            toolStripStatusLabel2.Text = String.Format("Canceled: {0}", ev.Cancel.ToString());

            //Application.DoEvents();
        }
        
        public void Printing()
        {
            try
            {                
                streamToPrint = new StreamReader(textBox1.Text);
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                    // Print the document.
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Printing();
        }

    }
}
