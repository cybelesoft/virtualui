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

namespace Play_Sound
{
    public partial class Form1 : Form
    {
        private string webDir;
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

            ro.ApplyModel();

            GetWebDir();

            vui.HTMLDoc.CreateSessionURL("/web/", webDir);
            vui.HTMLDoc.LoadScript("web/beepPlay.js");

        }

        private void GetWebDir()
        {
            webDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(webDir);
            while (di != null)
            {
                webDir = di.FullName + @"\web\";
                if (Directory.Exists(webDir)) return;
                di = di.Parent;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mySafeUrl = vui.HTMLDoc.GetSafeUrl(AppDomain.CurrentDomain.BaseDirectory +"\\beep.mp3");

            ro.Properties["myBeepURL"].AsString = mySafeUrl;

            ro.Events["playBeep"].Fire();

        }
    }
}
