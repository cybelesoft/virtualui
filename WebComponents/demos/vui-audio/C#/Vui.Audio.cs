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
    class VuiAudio
    {
        private string m_Xtagdir;
        private JSObject m_audio;
        private String m_src;

        private VirtualUI vui;

        public VuiAudio()
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
            set
            {
                m_Xtagdir = value;
            }
        }
        public float Position
        {
            get
            {
                return m_audio.Properties["position"].AsFloat;
            }
            set
            {
                m_audio.Properties["position"].AsFloat = value;
            }
        }
        public float Length
        {
            get
            {
                return m_audio.Properties["length"].AsFloat;
            }
        }
        public String State
        {
            get
            {
                return m_audio.Properties["state"].AsString;
            }
        }
        public void Play()
        {
            m_audio.Events["play"].Fire();
        }
        public void Pause()
        {
            m_audio.Events["pause"].Fire();
        }
        public void Stop()
        {
            m_audio.Events["stop"].Fire();
        }
        public void Move(float position)
        {
            m_audio.Events["move"].ArgumentAsFloat("Position", position).Fire();
        }
        public float Duration
        {
            get
            {
                return m_audio.Properties["duration"].AsFloat;
            }
        }
        public bool Slider
        {
            get
            {
                return m_audio.Properties["slider"].AsBool;
            }
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
                m_audio.Properties["src"].AsString = url;
            }
        }

        public event EventHandler<EventArgs> OnStateChanged;
        public event EventHandler<EventArgs> OnLengthChanged;
        public event EventHandler<EventArgs> OnPositionChanged;
        public event EventHandler<EventArgs> OnDurationChanged;
        public event EventHandler<EventArgs> OnDisableSlider;

        public void CreateComponent(Control ctrl)
        {
            vui.HTMLDoc.CreateSessionURL("/x-tag/", m_Xtagdir);
            vui.HTMLDoc.LoadScript(@"/x-tag/x-tag-core.min.js");
            vui.HTMLDoc.ImportHTML(@"/x-tag/vui-audio/vui-audio.html");
            vui.HTMLDoc.CreateComponent(ctrl.Name, "vui-audio", ctrl.Handle);

            // -- The given name, is how the model shown this object in the model reference.
            m_audio = new JSObject(ctrl.Name);
            m_audio.OnPropertyChange += m_audio_OnPropertyChange;
            // -- Adding properties, methods and events.
            m_audio.Properties.Add("state").AsString = "";
            m_audio.Properties.Add("position").AsFloat = 0.0f;
            m_audio.Properties.Add("length").AsFloat = 0.0f;
            m_audio.Properties.Add("src").AsString = "";
            m_audio.Properties.Add("duration").AsFloat = 0.0f;
            m_audio.Properties.Add("slider").AsBool = true;
            m_audio.Events.Add("play");
            m_audio.Events.Add("pause");
            m_audio.Events.Add("stop");
            m_audio.Events.Add("move").AddArgument("position", IJSDataType.JSDT_FLOAT);
            m_audio.Events.Add("updateDuration").AddArgument("duration", IJSDataType.JSDT_FLOAT);
            m_audio.Events.Add("disableSlider").AddArgument("slider", IJSDataType.JSDT_BOOL);
            m_audio.ApplyModel();
        }

        void m_audio_OnPropertyChange(object sender, JSPropertyChangeEventArgs e)
        {
            if ((e.Prop.Name == "state") && (OnStateChanged != null)) OnStateChanged(this, new EventArgs());
            if ((e.Prop.Name == "position") && (OnPositionChanged != null)) OnPositionChanged(this, new EventArgs());
            if ((e.Prop.Name == "duration") && (OnDurationChanged != null)) OnDurationChanged(this, new EventArgs());
            if ((e.Prop.Name == "length") && (OnLengthChanged != null)) OnLengthChanged(this, new EventArgs());
            if ((e.Prop.Name == "slider") && (OnDisableSlider != null)) OnDisableSlider(this, new EventArgs());
        }
    }
}
