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

namespace JSROTest
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

            ro.Properties.Add("myProperty").AsString = "";


            ro.OnPropertyChange += ro_OnPropertyChange;

            ro.ApplyModel();


        }

        void ro_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if (e.Prop.Name == "myProperty") ro_OnTextChanged(this, new EventArgs());

        }

        private void ro_OnTextChanged(object sender, EventArgs e)
        {
            string changedText = readText;
            //controlInvokerText(lblPaste, ro.Properties["readText"].AsString);
            controlInvokerText(label2, changedText);
        }


        public String readText
        {
            get
            {
                return ro.Properties["myProperty"].AsString;
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
