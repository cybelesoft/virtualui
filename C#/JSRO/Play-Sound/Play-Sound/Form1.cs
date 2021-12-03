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

namespace Play_Sound
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

            ro.Events.Add("playBeep");
            ro.Properties.Add("myBeepURL").AsString = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mySafeUrl = vui.HTMLDoc.GetSafeUrl(AppDomain.CurrentDomain.BaseDirectory +"\\beep.mp3");

            ro.Properties["myBeepURL"].AsString = mySafeUrl;

            ro.Events["playBeep"].Fire();

        }
    }
}
