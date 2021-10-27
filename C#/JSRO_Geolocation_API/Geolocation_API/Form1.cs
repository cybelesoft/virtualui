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

namespace Geolocation_API
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

            ro.Properties.Add("latitude").AsFloat = 0;
            ro.Properties.Add("longitude").AsFloat = 0;
            ro.Properties.Add("accuracy").AsFloat = 0;
            ro.Events.Add("getGeoLocation");

            ro.OnPropertyChange += ro_OnPropertyChange;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ro.Events["getGeoLocation"].Fire();
        }

        void ro_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if (e.Prop.Name == "latitude") ro_OnTextChanged(this, new EventArgs());
            if (e.Prop.Name == "longitude") ro_OnTextChanged(this, new EventArgs());
            if (e.Prop.Name == "accuracy") ro_OnTextChanged(this, new EventArgs());
        }

        private void ro_OnTextChanged(object sender, EventArgs e)
        {
            string latitudeLBL = latitude;
            string longitudeLBL = longitude;
            string accuracyLBL = accuracy;
            //controlInvokerText(lblPaste, ro.Properties["readText"].AsString);
            controlInvokerText(label1, latitudeLBL);
            controlInvokerText(label2, longitudeLBL);
            controlInvokerText(label3, accuracyLBL);

        }

        public String latitude
        {
            get
            {
                return ro.Properties["latitude"].AsString;
            }
        }
        public String longitude
        {
            get
            {
                return ro.Properties["longitude"].AsString;
            }
        }
        public String accuracy
        {
            get
            {
                return ro.Properties["accuracy"].AsString;
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
