using Cybele.Thinfinity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TestSetImageQualityByWnd
{
    public partial class Form1 : Form
    {
        private VirtualUI vui;
        public Form1()
        {
            vui = new VirtualUI();
            vui.Start(60);
            InitializeComponent();            

            lDefault.Text = "Default (ImageMode: " + (vui.Performance.Encoding.Format).ToString()+" JpegQuality: " +
                    vui.Performance.Encoding.JPEGQuality.ToString()+")";

            Current = new Bitmap(200, 200, PixelFormat.Format32bppArgb);
            Cg = Graphics.FromImage(Current);
            Cg.Clear(Color.White);
            Rnd = new Random();
            timer1 = new System.Timers.Timer() { Interval = 100 };
            timer1.Enabled = true;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(Step);
            
            this.Text = AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName;
            vui.SetImageQualityByWnd((long)panel2.Handle, "", 100);

            UpdatePanel3();
        }

        private Bitmap Current;
        private Graphics Cg;
        private int FLastY = 100;
        private Random Rnd;
        private System.Timers.Timer timer1;
           
        public void Step(object source, ElapsedEventArgs e)        
        {
            Cg.DrawImage(Current, -1, 0);
            
            Brush brush = new SolidBrush(Color.White);
            Cg.FillRectangle(brush, new Rectangle(Current.Width - 1, 0, Current.Width, Current.Height));            

            int NewY = FLastY + Rnd.Next(25) - 12;
            if (NewY < 0) 
              NewY = 0;
            if (NewY > Current.Height)
              NewY = Current.Height;

            Pen pen = new Pen(Color.Red);
            Point from = new Point(Current.Width - 2, FLastY);
            Point to = new Point(Current.Width - 1, NewY);

            Cg.DrawLine(pen, from, to);

            FLastY = NewY;

            DrawOnPanel(panel1, Current);
            DrawOnPanel(panel2, Current);
            DrawOnPanel(panel3, Current);            
        }

        public void DrawOnPanel(Panel panel, Bitmap bmp)
        {
            Graphics g = panel.CreateGraphics();
            g.DrawImage(bmp, new Point(0, 0));
        }

        private void UpdatePanel3()
        {
            int v = trackBar1.Value;
            String s;

            switch (v)
            {
                case 0:
                    s = "Default";
                    break;
                case 100:
                    s = "Highest";
                    break;
                default:
                    s = String.Format("{0}%", v);
                    break;
            }
            label1.Text = "Quality: " + s;
            vui.SetImageQualityByWnd((long)panel3.Handle, "", v);
            vui.FlushWindow((long)panel3.Handle);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdatePanel3();
        }        

    }
}
