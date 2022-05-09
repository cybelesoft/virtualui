using Cybele.Thinfinity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iframe
{
    class VuiIframe
    {
        private string m_Xtagdir;
        private JSObject m_iframe;
        private String m_src;
        private string m_color;
        private VirtualUI vui = null;
        public VuiIframe()
        {
            m_Xtagdir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(m_Xtagdir);
            String sdi = di.FullName.ToString();
            if (sdi.EndsWith("\\")) sdi = sdi.Substring(0, sdi.Length - 1);
            while (sdi != null)
            {
                m_Xtagdir = sdi + @"\x-tag\";
                MessageBox.Show(m_Xtagdir);
                if (Directory.Exists(m_Xtagdir)) return;
                di = di.Parent;
            }
        }
        public string XTagDir
        {
            get { return m_Xtagdir; }
            set { m_Xtagdir = value; }
        }
        public string src
        {
            get { return m_src; }
            set {
                m_src = value;
                m_iframe.Properties["src"].AsString = value;
            }
        }
        public string color
        {
            get { return m_color; }
            set {
                m_color = value;
                m_iframe.Properties["color"].AsString = value;
            }
        }
        public string backgroundColor
        {
            get { return m_iframe.Properties["backgroundColor"].AsString ; }
        }
        public event EventHandler<EventArgs> OnBackgroundColorChanged;
        public void CreateComponent(Control ctrl, VirtualUI vuiInstance) {
            vui = vuiInstance;
            MessageBox.Show(m_Xtagdir);
            vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-iframe.html");
            vui.HTMLDoc.CreateComponent(ctrl.Name, "vui-iframe", ctrl.Handle);

            // -- The given name, is how the model shown this object in the model reference.
            m_iframe = new JSObject(ctrl.Name);
            m_iframe.OnPropertyChange += m_iframe_OnPropertyChange;
            // -- Adding properties, methods and events.
            m_iframe.Properties.Add("src").AsString = "";
            m_iframe.Properties.Add("color").AsString = "";
            m_iframe.Properties.Add("backgroundColor").AsString = "";
            m_iframe.ApplyModel();
        }
        void m_iframe_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if (e.Prop.Name == "backgroundColor") OnBackgroundColorChanged(this, new EventArgs());
        }
    }
}
