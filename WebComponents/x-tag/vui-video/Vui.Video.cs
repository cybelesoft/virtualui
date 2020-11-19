using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cybele.Thinfinity;

namespace Cybele.Thinfinity.WebComponents
{
    class VuiVideo
    {
        private string m_Xtagdir;
        private JSObject m_video;
        private String m_src;

        private VirtualUI vui;

        public VuiVideo()
        {
            vui = new VirtualUI();
            m_Xtagdir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo di = new DirectoryInfo(m_Xtagdir);
            while (di!=null)
            {
                m_Xtagdir = di.FullName +@"\x-tag\";
                if (Directory.Exists(m_Xtagdir)) return;
                di = di.Parent;
            }
        }
        public string Dir
        {
            get
            {
                return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).ToString();
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
        public float Position {
            get
            {
                return m_video.Properties["position"].AsFloat;
            }
            set
            {
                m_video.Properties["position"].AsFloat = value;
            }
        }
        public float Length {
            get
            {
                return m_video.Properties["length"].AsFloat;
            }
        }
        public String State {
            get
            {
                return m_video.Properties["state"].AsString;
            }
        }
        public void Play()
        {
            m_video.Events["play"].Fire();
        }
        public void Pause()
        {
            m_video.Events["pause"].Fire();
        }
        public void Stop()
        {
            m_video.Events["stop"].Fire();
        }
        public void Move(float position)
        {
            m_video.Events["move"].ArgumentAsFloat("Position",position).Fire();
        }
        public String Src
        {
            get
            {
                return m_src;
            }
            set
            {
                m_src = value;
                var url = m_src;
                if (File.Exists(m_src))
                {
                    url = vui.HTMLDoc.GetSafeUrl(m_src, 60);
                }
                m_video.Properties["src"].AsString = url;
            }
        }

        public event EventHandler<EventArgs> OnStateChanged;
        public event EventHandler<EventArgs> OnLengthChanged;
        public event EventHandler<EventArgs> OnPositionChanged;

        public void CreateComponent(Control ctrl)
        {
            vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-video/vui-video.html");
            vui.HTMLDoc.CreateComponent(ctrl.Name, "vui-video", ctrl.Handle);

            // -- The given name, is how the model shown this object in the model reference.
            m_video = new JSObject(ctrl.Name);
            m_video.OnPropertyChange += m_video_OnPropertyChange;
            // -- Adding properties, methods and events.
            m_video.Properties.Add("state").AsString = "";
            m_video.Properties.Add("position").AsFloat = 0.0f;
            m_video.Properties.Add("length").AsFloat = 0.0f;
            m_video.Properties.Add("src").AsString = "";
            m_video.Events.Add("play");
            m_video.Events.Add("pause");
            m_video.Events.Add("stop");
            m_video.Events.Add("move").AddArgument("position",IJSDataType.JSDT_FLOAT);
            m_video.ApplyModel();


        }

        void m_video_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if ((e.Prop.Name == "state") && (OnStateChanged != null)) OnStateChanged(this, new EventArgs());
            if ((e.Prop.Name == "position") && (OnPositionChanged != null)) OnPositionChanged(this, new EventArgs());
            if ((e.Prop.Name == "length") && (OnLengthChanged != null)) OnLengthChanged(this, new EventArgs());
        }
    }
}
