using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cybele.Thinfinity;



namespace CSharp_JQueryUI
{
    public partial class Form1 : Form
    {
        public bool jsLoaded = false;
        private VirtualUI vui = new VirtualUI();
        private JSObject JsObj = new JSObject("dlg");

        private IJSEvent Event1;

        public Form1()
        {

            vui.Start();
            InitializeComponent();
            LoadDialogScript();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsObj.Events["showModalDlg"].ArgumentAsString("msg", textBox1.Text).Fire();
        }


        public void LoadDialogScript()
        {
            if (jsLoaded == false)
            {

                vui.HTMLDoc.LoadScript("/JqueryUiDlg.js", "");

                Event1 = JsObj.Events.Add("showModalDlg");

                Event1.AddArgument("msg", IJSDataType.JSDT_STRING);

                JsObj.ApplyModel();

                Thread.Sleep(250);

                jsLoaded = true;

            }
        }

    }








}
