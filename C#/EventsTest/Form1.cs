using Cybele.Thinfinity;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VirtualUIEvents
{
    public partial class Form1 : Form {
        private VirtualUI Vui;

        private string AppPath;
        private string m_TestDir;
        private string m_LogfileName;

        private void PrepareTestDir() {
            m_TestDir = Path.Combine(AppPath, "test_" + Process.GetCurrentProcess().Id.ToString());
            LblTestDir.Text = "Test directory: " + m_TestDir;

            // Create test directory:
            Directory.CreateDirectory(m_TestDir);

            // Create subdir for uploads:
            Directory.CreateDirectory(Path.Combine(m_TestDir, "Uploads"));

            // Create text file to be downloaded:
            StreamWriter file = new StreamWriter(Path.Combine(m_TestDir, "test.txt"));
            file.WriteLine("File to download by PID " + Process.GetCurrentProcess().Id.ToString());
            file.Close();
        }

        private void RemoveTestDir() {
            if (!String.IsNullOrEmpty(m_TestDir)) {
                Directory.Delete(m_TestDir, true);
            }
        }

        private void Log(string data) {
            TxtLog.AppendText(data + "\r\n");
            if (CheckSaveLog.Checked) {
                StreamWriter file = new StreamWriter(m_LogfileName, true);
                file.WriteLine(data);
                file.Close();
            }
        }

        public Form1() {
            InitializeComponent();
            AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            if (AppPath.StartsWith("file:")) {
                AppPath = AppPath.Substring(6);
            }
            
            Vui = new VirtualUI();
            Vui.Start();
            Vui.AllowExecute(".+");

            //Deprecated
            Vui.OnDragFile += Vui_OnDragFile;
            Vui.OnDragFile2 += Vui_OnDragFile2;
            Vui.OnDropFile += Vui_OnDropFile;
            Vui.OnDownloadEnd += Vui_OnDownloadEnd;
            Vui.OnUploadEnd += Vui_OnUploadEnd;
            Vui.OnGetUploadDir += Vui_OnGetUploadDir;
            Vui.OnClose += Vui_OnClose;
            Vui.OnBrowserResize += Vui_OnBrowserResize;
            Vui.OnSaveDialog += Vui_OnSaveDialog;

            // Currently not tested on this app:
            Vui.OnReceiveMessage += Vui_OnReceiveMessage;
            Vui.OnRecorderChanged += Vui_OnRecorderChanged;




            Vui.BrowserInfo.SetCookie("test2", "Hello2", "");

            GetCookieLabel.Text = Vui.BrowserInfo.GetCookie("test1");
            GetCookieLabel2.Text = Vui.BrowserInfo.GetCookie("test2");


            PrepareTestDir();
            m_LogfileName = Path.Combine(AppPath, String.Format("VirtualUI_Events_{0}.txt", Process.GetCurrentProcess().Id));
            CheckSaveLog.Text = "Save log to " + Path.GetFileName(m_LogfileName);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if (CheckRemoveTestDir.Checked) {
                RemoveTestDir();
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e) {
            Vui.DownloadFile(Path.Combine(m_TestDir, "test.txt"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.Title = ".NET Open Dialog";
            saveFileDialog1.Filter = "Image files (*.png;*.jpeg;*.bmp)|*.png;*.jpg;*.bmp|Text files (*.txt;*.log;*.ini)|*.txt;*.log;*.ini|PDF Files (*.pdf)|*.pdf ";
            saveFileDialog1.FilterIndex = 3;
            saveFileDialog1.FileName = "sample.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.ShowHelp = true;
            //saveFileDialog1.ShowReadOnly = true;
            saveFileDialog1.InitialDirectory = ".\\";
            saveFileDialog1.SupportMultiDottedExtensions = true;
            
           

            saveFileDialog1.ShowDialog();

            
            //StreamWriter PDFfile = new StreamWriter(saveFileDialog1.FileName);

            StreamWriter Test = new StreamWriter(Path.Combine(m_TestDir, saveFileDialog1.FileName));
            Test.WriteLine("File to download by PID " + Process.GetCurrentProcess().Id.ToString());
            Test.Close();


            Vui.DownloadFile(saveFileDialog1.FileName);
            

            

        }

        private void BtnUpload_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = ".NET Open Dialog";
            openFileDialog1.Filter = "Image files (*.png;*.jpeg;*.bmp)|*.png;*.jpg;*.bmp|Text files (*.txt;*.log;*.ini)|*.txt;*.log;*.ini|PDF Files (*.pdf)|*.pdf ";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.FileName = "test.pdf";
            openFileDialog1.DefaultExt = "txt";

            openFileDialog1.InitialDirectory = ".\\";

            openFileDialog1.Multiselect = true;


            //openFileDialog1.ShowHelp = true;
            //openFileDialog1.SupportMultiDottedExtensions = true;


            openFileDialog1.ShowDialog();

            //Vui.UploadFile();
        }

        private void Vui_OnSaveDialog(object sender, SaveDialogArgs e) {
            Log("OnSaveDialog: " + e.Filename);
        }

        private void Vui_OnRecorderChanged(object sender, RecorderChangedArgs e) {
            Log("OnRecorderChanged");
        }

        private void Vui_OnReceiveMessage(object sender, ReceiveMessageArgs e) {
            Log("OnReceiveMessage: " + e.Data);
        }

        private void Vui_OnBrowserResize(object sender, BrowserResizeEventArgs e) {
            Log(String.Format("OnBrowserResize: {0}x{1}", e.Width, e.Height));
        }

        private void Vui_OnClose(object sender, CloseArgs e) {
            Log("OnClose");
            Close();
        }

        private void Vui_OnGetUploadDir(object sender, GetUploadDirEventArgs e) {
            e.Directory = Path.Combine(m_TestDir, "Uploads");
            e.Handled = true;
            Log("OnGetUploadDir: Set " + e.Directory);
        }

        private void Vui_OnUploadEnd(object sender, UploadEndArgs e) {
            Log("OnUploadEnd: " + e.Filename);
        }

        private void Vui_OnDownloadEnd(object sender, DownloadEndArgs e) {
            Log("OnDownloadEnd: " + e.Filename);
        }

        private void Vui_OnDragFile(object sender, DragFileArgs e) {
            // Using OnDragfile2
        }

        private void Vui_OnDragFile2(object sender, DragFile2Args e) {
            string actionStr = "Unknown";
            switch (e.Action) {
                case Cybele.Thinfinity.DragAction.Start:
                    actionStr = "Start";
                    break;
                case Cybele.Thinfinity.DragAction.Over:
                    actionStr = "Over";
                    break;
                case Cybele.Thinfinity.DragAction.Drop:
                    actionStr = "Drop";
                    break;
                case Cybele.Thinfinity.DragAction.Error:
                    actionStr = "Error";
                    break;
                case Cybele.Thinfinity.DragAction.Cancel:
                    actionStr = "Cancel";
                    break;
            }

            string eventData = String.Format("{0} on {1}.{2}", actionStr, e.ScreenX, e.ScreenY);
            if (!String.IsNullOrEmpty(e.Filenames)) {
                eventData += " (Files: " + e.Filenames + ")";
            }
            Log("OnDragFile2: " + eventData);

            e.Accept = true;
        }

        private void Vui_OnDropFile(object sender, DropFileArgs e) {
            string eventData = String.Format("{0}.{1}", e.ScreenX, e.ScreenY);
            if (!String.IsNullOrEmpty(e.Filenames)) {
                eventData += " (Files: " + e.Filenames + ")";
            }
            if (!String.IsNullOrEmpty(e.FileSizes)) {
                eventData += " (Sizes: " + e.FileSizes + ")";
            }
            Log("OnDropFile: " + eventData);

            //TODO: Test IgnoreFiles (Set in the form: "ignore1.txt|ignore2.log|ignoreN.exe")
            Vui.UploadFile();
        }


    }
}
