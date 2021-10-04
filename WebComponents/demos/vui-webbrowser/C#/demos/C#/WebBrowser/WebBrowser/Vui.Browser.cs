using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cybele.Thinfinity;

namespace WebBrowser
{
    class VuiBrowser
    {
        private string XtagDir;
        private string Address;
        private int HistoryIndex;
        private Array History;
        public JSObject RemoteBrowser;
        public VirtualUI vui;



        public VuiBrowser()
        {
            vui = new VirtualUI();

            RemoteBrowser = new JSObject("browser1");
            RemoteBrowser.Properties.Add("url").AsString = "";
            RemoteBrowser.Events.Add("go").AddArgument("url", IJSDataType.JSDT_STRING);
            RemoteBrowser.ApplyModel();

            XtagDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(XtagDir);
            while (di != null)
            {
                XtagDir = di.FullName + @"\x-tag\";
                if (Directory.Exists(XtagDir)) return;
                di = di.Parent;
            }

            //RemoteBrowser.Methods.Add("loadEnd").AddArgument("url", IJSDataType.JSDT_STRING).OnCall(
            //    new JSCallback(delegate (IJSObject Parent, IJSMethod Method)
            //    {
            //        History.Add(Method.Arguments['url'].AsString);
            //        HistoryIndex:= FHistory.Count - 1;
            //        Address:= History[HistoryIndex];
            //    }
            //    )
            // );

        }

        public void CreateComponent(Control ctrl)
        {
            vui.HTMLDoc.CreateSessionURL("/x-tag/", XtagDir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-browser/vui-browser.html");
            vui.HTMLDoc.CreateComponent("browser1", "vui-browser", ctrl.Handle);
        }

        public void Go(string Url)
        {
            RemoteBrowser.Events["go"].ArgumentAsString("url", Url).Fire();
        }

    }
}
