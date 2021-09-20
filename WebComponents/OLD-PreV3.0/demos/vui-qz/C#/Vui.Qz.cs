using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cybele.Thinfinity;

namespace Cybele.Thinfinity.WebComponents
{
    public class VuiQz
    {
        private string m_Xtagdir;
        private JSObject m_qz;
        private String m_printlines;

        private VirtualUI vui;

        public VuiQz()
        {
            vui = new VirtualUI();
            m_Xtagdir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(m_Xtagdir);
            while (di != null)
            {
                m_Xtagdir = di.FullName + @"\x-tag\";
                if (Directory.Exists(m_Xtagdir)) return;
                di = di.Parent;
            }
        }
        public event EventHandler<EventArgs> OnStateChanged;
        public event EventHandler<EventArgs> OnPrinterChange;

        void m_video_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if ((e.Prop.Name == "state") && (OnStateChanged != null)) OnStateChanged(this, new EventArgs());
            if ((e.Prop.Name == "default") && (OnPrinterChange != null)) OnPrinterChange(this, new EventArgs());
        }

        public void CreateComponent()
        {
            String name = "qzro";
            vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-qz/vui-qz.html");
            vui.HTMLDoc.CreateComponent(name, "vui-qz", 0);

            // -- The given name, is how the model shown this object in the model reference.
            m_qz = new JSObject(name);
            m_qz.OnPropertyChange += m_video_OnPropertyChange;
            // -- Adding properties, methods and events.
            m_qz.Properties.Add("settings").AsJSON = "{}";
            m_qz.Properties.Add("state").AsString = "";
            m_qz.Properties.Add("printers").AsString = "";
            m_qz.Properties.Add("default").AsString = "";
            m_qz.Events.Add("init")
                .AddArgument("certificate", IJSDataType.JSDT_STRING)
                .AddArgument("privateKey", IJSDataType.JSDT_STRING);
            m_qz.Events.Add("print")
                .AddArgument("printer", IJSDataType.JSDT_STRING)
                .AddArgument("contentType", IJSDataType.JSDT_STRING)
                .AddArgument("data", IJSDataType.JSDT_STRING);
            m_qz.ApplyModel();
        }

        public string XTagDir
        {
            get 
            {
                return m_Xtagdir;
            }
            set
            {
                m_Xtagdir = value;
            }
        }
        public String[] Printers { 
            get 
            {
                return m_qz.Properties["printers"].AsString.Split(',');
            } 
        }
        public String Settings { 
            get 
            {
                return m_qz.Properties["settings"].AsJSON; 
            }
        }
        public String State {
            get 
            {
                return m_qz.Properties["state"].AsString; 
            }
        }
        public String Default
        {
            get
            {
                return m_qz.Properties["default"].AsString;
            }
            set
            {
                m_qz.Properties["default"].AsString = value;
            }
        }
        public void Init(String certificate, String privateKey)
        {
            m_qz.Events["init"]
                .ArgumentAsString("certificate", certificate)
                .ArgumentAsString("privateKey", privateKey)
                .Fire();
        }
        public void Print(String printer,String content_type, String data)
        {
            m_qz.Events["print"]
                .ArgumentAsString("printer",printer)
                .ArgumentAsString("contentType", content_type)
                .ArgumentAsString("data", data)
                .Fire();
        }
        public void BeginDoc()
        {
            m_printlines = "";
        }
        public void EndDoc()
        {
            String data = '['+m_printlines +']';
            m_qz.Events["print"]
                .ArgumentAsString("printer",Default)
                .ArgumentAsString("contentType","raw")
                .ArgumentAsString("data",data)
                .Fire();
        }
        public void PrintText(String data)  
        {
            m_printlines = m_printlines + '"' + System.Web.HttpUtility.JavaScriptStringEncode(data) + '"';
        }
        public void PrintF(String data_type,String format, String data)
        {
        }
        public void PrintPDF(String filename)
        {
            var safeurl = vui.HTMLDoc.GetSafeUrl(filename, 10);
            m_qz.Events["print"]
                .ArgumentAsString("printer", Default)
                .ArgumentAsString("contentType","pdf")
                .ArgumentAsString("data", safeurl)
                .Fire();
        }


    }
}
