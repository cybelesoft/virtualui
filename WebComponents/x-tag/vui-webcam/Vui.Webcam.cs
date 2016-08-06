using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cybele.Thinfinity;
using System.Drawing;


namespace Cybele.Thinfinity.WebComponents
{
    class VuiWebcam
    {
        private string m_Xtagdir;
        private JSObject m_ro;
        private String m_src;

        private VirtualUI vui;

        public VuiWebcam()
        {
            vui = new VirtualUI();
            m_Xtagdir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(m_Xtagdir);
            while (di!=null)
            {
                m_Xtagdir = di.FullName + @"\x-tag\";
                if (Directory.Exists(m_Xtagdir)) return;
                di = di.Parent;                
            }
        }
        public string XTagDir
        {
            get 
            {
                return m_Xtagdir;
            }
            set {
                m_Xtagdir = value;
            }
        }
        public Image Photo
        {
            get
            {
                string data = m_ro.Properties["data"].AsString;
                int idx = data.IndexOf(',');
                if (idx > 0)
                {
                    string header = data.Substring(0, idx);
                    string base64 = data.Substring(idx + 1);
                    return Base64ToImage(base64);
                }
                else return null;
            }
        }
        public void Freeze()
        {
            m_ro.Events["freeze"].Fire();
        }
        public void Unfreeze()
        {
            m_ro.Events["unfreeze"].Fire();
        }
        public void Save()
        {
            m_ro.Events["save"].Fire();
        }
        public void Attach(int width,int height)
        {
            m_ro.Events["attach"].ArgumentAsInt("width", width).ArgumentAsInt("height", height).Fire();
        }
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public event EventHandler<EventArgs> OnBitmapChanged;

        public void CreateComponent(Control ctrl)
        {
            vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-webcam/vui-webcam.html");
            vui.HTMLDoc.CreateComponent(ctrl.Name, "vui-webcam", ctrl.Handle);

            // -- The given name, is how the model shown this object in the model reference.
            m_ro = new JSObject(ctrl.Name);
            m_ro.OnPropertyChange += m_ro_OnPropertyChange;
            // -- Adding properties, methods and events.
            m_ro.Properties.Add("data").AsString = "";
            m_ro.Events.Add("freeze");
            m_ro.Events.Add("unfreeze");
            m_ro.Events.Add("save");
            m_ro.Events.Add("attach").AddArgument("width", IJSDataType.JSDT_INT).AddArgument("height", IJSDataType.JSDT_INT);
            m_ro.ApplyModel();
        }

        void m_ro_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if ((e.Prop.Name == "data") && (OnBitmapChanged != null)) OnBitmapChanged(this, new EventArgs());
        }
    }
}
