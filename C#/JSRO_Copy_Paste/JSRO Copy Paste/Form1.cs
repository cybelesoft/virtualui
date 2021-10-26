using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cybele.Thinfinity;

namespace JSRO_Copy_Paste
{
    public partial class Form1 : Form
    {

        VirtualUI vui;
        JSObject ro;

        public Form1()
        {
            vui = new VirtualUI();
            vui.Start();
            InitializeComponent();

            ro = new JSObject("ro");

            ro.Events.Add("JsROCopy");
            ro.Events.Add("JsROPaste");

            ro.Properties.Add("writeText").AsString = "";

            ro.Properties.Add("readText").AsString = "";

            ro.OnPropertyChange += ro_OnPropertyChange;

            ro.ApplyModel();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ro.Properties["writeText"].AsString = textBox1.Text;
            ro.Events["JsROCopy"].Fire();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ro.Events["JsROPaste"].Fire();
        }


        void ro_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if (e.Prop.Name == "readText") ro_OnTextChanged(this, new EventArgs());
        }


        private void ro_OnTextChanged(object sender, EventArgs e)
        {
            string changedText = readText;
            //controlInvokerText(lblPaste, ro.Properties["readText"].AsString);
            controlInvokerText(lblPaste, changedText);
        }

        public String readText
        {
            get
            {
                return ro.Properties["readText"].AsString;
            }
        }

        public void controlInvokerText(Control c, String text)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate { c.Text = text; }));
            }
            else
            {
                c.Text = text;
            }
        }

    }
}
