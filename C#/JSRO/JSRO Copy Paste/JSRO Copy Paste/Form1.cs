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
        private string webDir;
        VirtualUI vui;
        JSObject ro;

        public Form1()
        {
            vui = new VirtualUI();
            vui.Start();
            InitializeComponent();

            string imagePath = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Thinfinity-Isologo-300x97.png";
            string imgBase64String = GetBase64StringForImage(imagePath);

            comboBox1.SelectedIndex = 0;

            // Creates object with "ro" ID . In the clphandler.js , it's the 'ro = null'.
            ro = new JSObject("ro");

            //Creates all events 
            ro.Events.Add("JsROCopy");
            ro.Events.Add("JsROPaste");
            ro.Events.Add("copyBase64Image");
            ro.Events.Add("readBase64Image");
            ro.Events.Add("fullscreen");
            ro.Events.Add("sendVibration");
            ro.Events.Add("recognitionStart");



            //Creates all properties
            ro.Properties.Add("writeText").AsString = "";
            ro.Properties.Add("readText").AsString = "";
            ro.Properties.Add("base64image").AsString = imgBase64String;
            ro.Properties.Add("imageType").AsString = comboBox1.Text;
            ro.Properties.Add("readBase64image").AsString = "";
            ro.Properties.Add("speechRecognition").AsString = "";


            //Event that handles property change
            ro.OnPropertyChange += ro_OnPropertyChange;

            //Applies model to the browser
            ro.ApplyModel();

            GetWebDir();

            vui.HTMLDoc.CreateSessionURL("/web/", webDir);
            vui.HTMLDoc.LoadScript("web/clphandler.js");



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

        //Fires the 'JsROCopy' event in clphandler.js
        private void button1_Click(object sender, EventArgs e)
        {
            ro.Properties["writeText"].AsString = textBox1.Text;
            ro.Events["JsROCopy"].Fire();
        }

        //Fires the 'JsROPaste' event in clphandler.js

        private void button2_Click(object sender, EventArgs e)
        {
            ro.Events["JsROPaste"].Fire();
        }


        //Fires the 'copyBase64Image' event in clphandler.js
        private void button3_Click(object sender, EventArgs e)
        {
            ro.Properties["imageType"].AsString = comboBox1.Text;
            ro.Events["copyBase64Image"].Fire();
        }



        //Fires the 'fullscreen' event in clphandler.js
        private void button4_Click(object sender, EventArgs e)
        {
            ro.Events["fullscreen"].Fire();
        }


        //Fires the 'sendVibration' event in the clphandler.js . Needs to be modified in the clphandler.js , as it's not enabled by default.
        private void button5_Click(object sender, EventArgs e)
        {
            ro.Events["sendVibration"].Fire();
        }

        //Fires the 'readBase64Image' event in clphandler.js
        private void button6_Click(object sender, EventArgs e)
        {
            ro.Events["readBase64Image"].Fire();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ro.Events["recognitionStart"].Fire();
        }


        //Event that fires when a property is changed, searches for the Property Name ( in this case 'readText' or 'readBase64image' )
        //  and fires the event associated with that property
        void ro_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if (e.Prop.Name == "readText") ro_OnTextChanged(this, new EventArgs());
            if (e.Prop.Name == "readBase64image") ro_OnImageChanged(this, new EventArgs());
            if (e.Prop.Name == "speechRecognition") ro_OnSpeechChanged(this, new EventArgs());
        }


        // Changes lblPaste to ro.readText
        private void ro_OnTextChanged(object sender, EventArgs e)
        {
            string changedText = readText;
            //controlInvokerText(lblPaste, ro.Properties["readText"].AsString);
            controlInvokerText(lblPaste, changedText);
        }

        private void ro_OnImageChanged(object sender, EventArgs e)
        {

            string myTrimedString =   ro.Properties["readBase64image"].AsString;

            //Until TK-1054 is fixed, we have to replace 'spaces' with '+'
            myTrimedString = myTrimedString.Replace(' ', '+');


           panel2.BackgroundImage = Base64ToImage(myTrimedString);

        }

        // Changes label3 to 

        private void ro_OnSpeechChanged(object sender, EventArgs e)
        {
            string changedText = speechRecognition;
            controlInvokerText(label3, changedText);
        }

        public String speechRecognition
        {
            get
            {
                return ro.Properties["speechRecognition"].AsString;
            }
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


        //Converts the image to base64 string
        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }


        //Converts the base64 string to image
        //public static Image LoadBase64(string base64)
        //{
        //    byte[] bytes = Convert.FromBase64String(base64);


        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //    }
        //    return image;
        //}

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            image.Save("PATH", System.Drawing.Imaging.ImageFormat.Png);
            return image;
        }


    }
}
