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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Json;



namespace SetClipboardCSharp
{
    public partial class Form1 : Form
    {

        VirtualUI vui;

        public class ClipboardMessage
        {
            public string Action { get; set; }
            public string Type { get; set; }
            public string Text { get; set; }
        }



        public Form1()
        {

            vui = new VirtualUI();
            vui.Start();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);

            ClipboardMessage cm = new ClipboardMessage();
            cm.Action = "copy";
            cm.Type = "text/plain";
            cm.Text = textBox1.Text;

            string serializedCM = JsonSerializer.Serialize(cm);
            vui.SendMessage(serializedCM);
        }

    }
}
