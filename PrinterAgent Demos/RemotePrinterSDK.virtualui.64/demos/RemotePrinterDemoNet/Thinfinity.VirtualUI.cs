using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Cybele.Thinfinity
{
    /*
     * *********************************************************************************************
     *  Thinfinity_TLB translation
     * *********************************************************************************************
     */

    [Guid("4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), ComImport]
    public interface IVirtualUI
    {
        bool Start(int timeout);
        void Stop();
        void DownloadFile(string LocalFilename);
        void DownloadFile(string LocalFilename, string RemoteFilename);
        void DownloadFile(string LocalFilename, string RemoteFilename, string MimeType);
        void PrintPdf(string FileName);
        void PreviewPdf(string FileName);
        void OpenLinkDlg(string Url, string Caption);
        void SendMessage(string Data);
        void AllowExecute(string Filename);
        void SetImageQualityByWnd(long Wnd, string Classname, int Quality);
        void UploadFile(string ServerDirectory);
        bool UploadFileEx(string ServerDirectory, out string FileName);
        void Suspend();
        void Resume();
        bool FlushWindow(long Wnd);
        bool TakeScreenshot(long Wnd, string FileName);
        void ShowVirtualKeyboard();
        bool Active { get; }
        bool Enabled { get; set; }
        bool DevMode { get; set; }
        bool StdDialogs { get; set; }
        uint Options { get; set; }
        IBrowserInfo BrowserInfo { get; }
        IDevServer DevServer { get; }
        IClientSettings ClientSettings { get; }
        IRecorder Recorder { get; }
        IFileSystemFilter FileSystemFilter { get; }
        IRegistryFilter RegistryFilter { get; }
        IHTMLDoc HTMLDoc { get; }
    }

    [ComVisible(true), Guid("1C5700BC-2317-4062-B614-0A4E286CFE68"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IEvents
    {
        [DispId(101)]
        void OnGetUploadDir(ref string Directory, ref bool Handled);
        [DispId(102)]
        void OnBrowserResize(ref int Width, ref int Height, ref bool ResizeMaximized);
        [DispId(103)]
        void OnClose();
        [DispId(104)]
        void OnReceiveMessage(string Data);
        [DispId(105)]
        void OnDownloadEnd(string Filename);
        [DispId(106)]
        void OnRecorderChanged();
        [DispId(107)]
        void OnUploadEnd(string Filename);
        [DispId(201)]
        void OnDragFile(DragAction Action, Int32 X, Int32 Y, string Filenames);
        [DispId(202)]
        void OnSaveDialog(string Filename);
    }

    public enum Options
    {     
        OPT_APPINVISIBLE = 1,
        OPT_IGNORE_MOUSEMOVE = 2,
        OPT_NODEFAULT_PRINTER = 4,
        OPT_NOHTML_DRAG = 16,
        OPT_NOHTML_SIZE = 64,
        OPT_JSRO_SYNCCALLS = 32,
        OPT_CLIPBOARD_LOCAL = 256,
        OPT_SUPRESS_PRINT_DIALOG = 512,
        OPT_AUTODOWNLOAD = 4096
    }

    public enum DragAction
    {
        Start = 0,
        Over = 1,
        Drop = 2,
        Cancel = 3,
        Error = 99
    }

    [Guid("4D9F5347-460B-4275-BDF2-F2738E7F6757"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IBrowserInfo
    {
        int ViewWidth { get; set; }
        int ViewHeight { get; set; }
        int BrowserWidth { get; }
        int BrowserHeight { get; }
        int ScreenWidth { get; }
        int ScreenHeight { get; }
        string Username { get; }
        string IPAddress { get; }
        string UserAgent { get; }
        int ScreenResolution { get; }
        BrowserOrientation Orientation { get; }
        string UniqueBrowserId { get; }
        string Location { get; }
        string CustomData { get; set; }
        string GetCookie(string Name);
        void SetCookie(string Name, string Value, string Expires);
        string SelectedRule { get; }
        string ExtraData { get; }
        string GetExtraDataValue(string Name);
    }

    [Guid("A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDoc
    {
        void CreateSessionURL(string url, string filename);
        void CreateComponent(string Id, string Html, IntPtr ReplaceWnd);
        string GetSafeUrl(string filename, int minutes);
        void LoadScript(string url, string filename);
        void ImportHTML(string url, string filename);
    }

    [Guid("B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IDevServer
    {
        bool Enabled { get; set; }
        int Port { get; set; }
        bool StartBrowser { get; set; }
    }

    [Guid("439624CA-ED33-47BE-9211-91290F29584A"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IClientSettings
    {
        MouseMoveGestureStyle MouseMoveGestureStyle { get; set; }
        MouseMoveGestureAction MouseMoveGestureAction { get; set; }
        bool CursorVisible { get; set; }
        int MouseWheelStepValue { get; set; }
        int MouseWheelDirection { get; set; }
        bool MousePressAsRightButton { get; set; }
    }

    public enum IJSDataType
    {
        JSDT_NULL = 0,
        JSDT_STRING = 1,
        JSDT_INT = 2,
        JSDT_BOOL = 3,
        JSDT_FLOAT = 4,
        JSDT_JSON = 5
    }

    public enum BrowserOrientation
    {
        PORTRAIT = 0,
        LANDSCAPE = 1
    }

    public enum MouseMoveGestureStyle
    {
        MM_STYLE_RELATIVE = 0,
        MM_STYLE_ABSOLUTE = 1
    }

    public enum MouseMoveGestureAction
    {
        MM_ACTION_MOVE = 0,
        MM_ACTION_WHEEL = 1
    }

    [Guid("6DE2E6A0-3C3A-47DC-9A93-928135EDAC90"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSValue
    {
        IJSDataType DataType { set; get; }
        object RawValue { set; get; }
        string AsString { set; get; }
        int AsInt { set; get; }
        bool AsBool { set; get; }
        float AsFloat { set; get; }
        string AsJSON { set; get; }
    }

    [Guid("E492419B-00AC-4A91-9AE9-9A82B07E89AE"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSNamedValue : IJSValue
    {
        string Name { set; get; }
    }

    [Guid("59342310-79A7-4B14-8B63-6DF05609AE30"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSObject
    {
        void FireEvent(string Name, IJSArguments Arguments);
        void ApplyChanges();
        void ApplyModel();
        string Id { get; set; }
        IJSProperties Properties { get; }
        IJSMethods Methods { get; }
        IJSEvents Events { get; }
        IJSObjects Objects { get; }

        event EventHandler<JSExecuteMethodEventArgs> OnExecuteMethod;
        event EventHandler<JSPropertyChangeEventArgs> OnPropertyChange;
    }

    [ComVisible(true), Guid("A3D640E8-CD18-4196-A1A2-C87C82B0F88B"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSObjectEvents
    {
        [DispId(101)]
        void OnExecuteMethod(IJSObject Sender, IJSMethod Method);
        [DispId(102)]
        void OnPropertyChange(IJSObject Sender, IJSProperty Prop);
    }

    [Guid("C2406011-568E-4EAC-B95C-EF29E4806B86"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSObjects
    {
        int Count { get; }
        IJSObject this[object Index] { get; }
        //IJSObject Find(string Id);
        void Clear();
        IJSObject Add(string Id);
        void Remove(IJSObject Item);
    }

    [Guid("1F95C0E9-E7BF-48C9-AA35-88AD0149109B"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSProperty : IJSNamedValue
    {
        IJSProperty OnGet(IJSBinding Binding);
        IJSProperty OnSet(IJSBinding Binding);
    }

    [Guid("FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSProperties
    {
        int Count { get; }
        IJSProperty this[object Index] { get; }
        //IJSProperty Find(string Name);
        void Clear();
        IJSProperty Add(string Name);
        void Remove(IJSProperty Item);
    }

    [Guid("8F8C4462-D7B5-4696-BAD5-16DFAA6E2601"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSArgument : IJSNamedValue
    {
    }

    [Guid("FC097EF5-6D8A-4C80-A2AD-382FDC75E901"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSArguments
    {
        int Count { get; }
        IJSArgument this[object Index] { get; }
        //IJSArgument Find(string Name);
        void Clear();
        IJSArgument Add(string Name);
        void Remove(IJSArgument Item);
    }

    [Guid("C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSMethod
    {
        IJSMethod AddArgument(string Name, IJSDataType DataType);
        IJSMethod OnCall(IJSCallback Callback);
        string Name { set; get; }
        IJSArguments Arguments { get; }
        IJSValue ReturnValue { get; }
    }

    [Guid("E4CB461F-586E-4121-ABD7-345B87BC423A"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSMethods
    {
        int Count { get; }
        IJSMethod this[object Index] { get; }
        //IJSMethod Find(string Name);
        void Clear();
        IJSMethod Add(string Name);
        void Remove(IJSMethod Item);
    }

    [Guid("8B66EACD-9619-43CF-9196-DCDA17F5500E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSEvent
    {
        IJSEvent AddArgument(string Name, IJSDataType DataType);
        IJSEvent ArgumentAsNull(object Index);
        IJSEvent ArgumentAsString(object Index, string Value);
        IJSEvent ArgumentAsInt(object Index, int Value);
        IJSEvent ArgumentAsBool(object Index, bool Value);
        IJSEvent ArgumentAsFloat(object Index, float Value);
        IJSEvent ArgumentAsJSON(object Index, string Value);
        void Fire();
        string Name { set; get; }
        IJSArguments Arguments { get; }

    }

    [Guid("6AE952B3-B6DA-4C81-80FF-D0A162E11D02"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSEvents
    {
        int Count { get; }
        IJSEvent this[object Index] { get; }
        //IJSEvent Find(string Name);
        void Clear();
        IJSEvent Add(string Name);
        void Remove(IJSEvent Item);
    }

    [ComVisible(true), Guid("ACFC2953-37F1-479E-B405-D0BB75E156E6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSBinding
    {
        void Set(IJSObject Parent, IJSProperty Prop);
    }

    [ComVisible(true), Guid("ADD570A0-491A-4E40-8120-57B4D1245FD3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IJSCallback
    {
        void Callback(IJSObject Parent, IJSMethod Method);
    }

    public enum RecorderState
    {
        Inactive = 0,
        Recording = 1,
        Playing = 2
    }

    [ComVisible(true), Guid("D89DA2B6-B7BF-4065-80F5-6D78B331C7DD"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRecorder
    {
        string Filename { set; get; }
        int Position { get; }
        int Count { get; }
        RecorderState State { get; }
        long Options { set; get; }
        IRecTracks Tracks { get; }
        void Rec(string Label);
        void Play(int From, int To);
        void Stop();
    }

    [ComVisible(true), Guid("D4744AE1-70CB-43DD-BEA5-A5310B2E24C6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRecTrack
    {
        string Name { get; }
        int Position { get; }
    }

    [ComVisible(true), Guid("AB45B615-9309-471E-A455-3FE93F88E674"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRecTracks {
        IRecTrack this[object Index] { get; }
        int Count { get; }
    }


    [ComVisible(true), Guid("3FE99D2F-0CFC-43D1-B762-0C7C15EB872E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IFileSystemFilter
    {
        string User { set; get; }
        string CfgFile { set; get; }
        bool Active { set; get; }
    }

    [ComVisible(true), Guid("4834F840-915B-488B-ADEA-98890A04CEE6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRegistryFilter
    {
        string User { set; get; }
        string CfgFile { set; get; }
        bool Active { set; get; }
    }

    /*
     * *********************************************************************************************
     *  VirtualUILibrary. Base class which loads the Thinfinity.VirtualUI.dll
     * *********************************************************************************************
     */

    public class VirtualUILibrary
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        protected static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        protected static IntPtr LibHandle = IntPtr.Zero;

        public VirtualUILibrary()
        {
            if (LibHandle == IntPtr.Zero)
            {
                string TargetDir = GetDLLDir();
                if (TargetDir != null)
                {
                    string LibFilename = TargetDir + @"\Thinfinity.VirtualUI.DLL";
                    LibHandle = LoadLibrary(LibFilename);
                    if (LibHandle != IntPtr.Zero)
                    {
                    }
                }
            }
        }

        private static string GetDLLDir()
        {
            RegistryKey RegKey = null;
            string IniFileName = AppDomain.CurrentDomain.BaseDirectory + "\\OEM.ini";
            if (File.Exists(IniFileName)) {
                StringBuilder sbOEMKey32 = null;
                StringBuilder sbOEMKey64 = null;
                sbOEMKey32 = new StringBuilder(1024);
                sbOEMKey64 = new StringBuilder(1024);
                GetPrivateProfileString("PATHS", "Key32", "", sbOEMKey32, sbOEMKey32.Capacity, IniFileName);
                GetPrivateProfileString("PATHS", "Key64", "", sbOEMKey64, sbOEMKey64.Capacity, IniFileName);
                if (sbOEMKey32.ToString() != "" && RegKey == null)
                {
                    string oemKey32 = sbOEMKey32.ToString();
                    if (oemKey32.StartsWith("\\"))
                        oemKey32 = oemKey32.Substring(1);
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey32, false);
                }

                if (sbOEMKey64.ToString() != "" && RegKey == null)
                {
                    string oemKey64 = sbOEMKey64.ToString();
                    if (oemKey64.StartsWith("\\"))
                        oemKey64 = oemKey64.Substring(1);
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey64, false);
                }
            }
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\VirtualUI\Dev", false);
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cybele Software\Setups\Thinfinity\VirtualUI\Dev", false);
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\VirtualUI", false);
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cybele Software\Setups\Thinfinity\VirtualUI", false);
            if (RegKey != null)
            {
                if (IntPtr.Size == 8)
                    return (string)RegKey.GetValue("TargetDir_x64", null);
                else
                    return (string)RegKey.GetValue("TargetDir_x86", null);
            }
            else return ".";
        }
    }

    /*
     * *********************************************************************************************
     *  ClientSettings
     * *********************************************************************************************
     */

    /// <summary>
    /// Allows to set some client settings.
    /// </summary>
    public class ClientSettings : IClientSettings, IDisposable
    {
        private IVirtualUI m_VirtualUI;

        public ClientSettings(IVirtualUI virtualUI)
        {
            m_VirtualUI = virtualUI;
        }

        ~ClientSettings()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_VirtualUI != null)
                Marshal.ReleaseComObject(m_VirtualUI);
            m_VirtualUI = null;
        }

        /// <summary>
        /// Valid for touch devices. Specifies whether the mouse pointer
        /// is shown and acts on the exact spot of the finger touch
        /// (absolute) or its position is managed relatively to the
        /// movement of the finger touch (relative).
        /// </summary>
        public MouseMoveGestureStyle MouseMoveGestureStyle
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.ClientSettings.MouseMoveGestureStyle;
                return MouseMoveGestureStyle.MM_STYLE_ABSOLUTE;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.ClientSettings.MouseMoveGestureStyle = value;
            }
        }

        /// <summary>
        /// Specifies whether the &quot;mouse move&quot; simulation on a
        /// touch device is interpreted as a mouse move or as a mouse
        /// wheel.
        /// </summary>
        public MouseMoveGestureAction MouseMoveGestureAction
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.ClientSettings.MouseMoveGestureAction;
                return MouseMoveGestureAction.MM_ACTION_MOVE;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.ClientSettings.MouseMoveGestureAction = value;
            }
        }

        /// <summary>
        /// Hides/shows the mouse pointer.
        /// </summary>
        public bool CursorVisible
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.ClientSettings.CursorVisible;
                return true;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.ClientSettings.CursorVisible = value;
            }
        }

    	/// <summary>
    	/// Specifies the scroll speed when the "mouse move" simulation on a
        /// touch device is interpreted as a mouse wheel. Default value is
    	/// 120. Lower values results in a smooth scrolling.
        /// </summary>
        public int MouseWheelStepValue
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.ClientSettings.MouseWheelStepValue;
                return 120;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.ClientSettings.MouseWheelStepValue = value;
            }
        }

        /// <summary>
        /// Specifies the scroll direction when the "mouse move" simulation on a
        /// touch device is interpreted as a mouse wheel. Set this to 1 (default)
        /// to normal direction, or -1 to invert.
        /// </summary>
        public int MouseWheelDirection {
            get {
                if (m_VirtualUI != null)
                    return m_VirtualUI.ClientSettings.MouseWheelDirection;
                return 1;
            }
            set {
                if (m_VirtualUI != null)
                    m_VirtualUI.ClientSettings.MouseWheelDirection = value;
            }
        }

        /// <summary>
        /// Mouse click as context menu.
        /// </summary>
        public bool MousePressAsRightButton
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.ClientSettings.MousePressAsRightButton;
                return false;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.ClientSettings.MousePressAsRightButton = value;
            }
        }
    }

    /*
     * *********************************************************************************************
     *  BrowserInfo
     * *********************************************************************************************
     */

    /// <summary>
    /// Contains information regarding the end-user's screen, web
    /// browser, the window containing VirtualUI Viewer and VirtualUI
    /// Viewer itself. The VirtualUI Viewer tuns inside an HTML DIV
    /// element contained in a frame o browser window on the
    /// end-user's application page.
    /// </summary>
    public class BrowserInfo : IBrowserInfo, IDisposable
    {
        private IVirtualUI m_VirtualUI;

        public BrowserInfo(IVirtualUI virtualUI)
        {
            m_VirtualUI = virtualUI;
        }

        ~BrowserInfo()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_VirtualUI != null)
                Marshal.ReleaseComObject(m_VirtualUI);
            m_VirtualUI = null;
        }

        /// <summary>
        /// \Returns the width of the VirtualUI Viewer.
        /// </summary>
        public int ViewWidth
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.ViewWidth;
                return 0;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.BrowserInfo.ViewWidth = value;
            }
        }

        /// <summary>
        /// \Returns the height of the VirtualUI Viewer.
        /// </summary>
        public int ViewHeight
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.ViewHeight;
                return 0;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.BrowserInfo.ViewHeight = value;
            }
        }

        /// <value>
        /// \Returns the width of the HTML element containing the
        /// VirtualUI Viewer.
        /// </value>
        public int BrowserWidth
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.BrowserWidth;
                return 0;
            }
        }

        /// <summary>
        /// \Returns the height of the HTML element containing the
        /// VirtualUI Viewer.
        /// </summary>
        public int BrowserHeight
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.BrowserHeight;
                return 0;
            }
        }

        /// <summary>
        /// \Returns the width of the end-user's monitor screen.
        /// </summary>
        public int ScreenWidth
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.ScreenWidth;
                return 0;
            }
        }

        /// <summary>
        /// \Returns the height of the end-user's monitor screen.
        /// </summary>
        public int ScreenHeight
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.ScreenHeight;
                return 0;
            }
        }

        /// <summary>
        /// \Returns the logged-on Username.
        /// </summary>
        public string Username
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.Username;
                return "";
            }
        }

        /// <summary>
        /// \Returns the client's IP address.
        /// </summary>
        public string IPAddress
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.IPAddress;
                return "";
            }
        }

        /// <summary>
        /// \Returns the browser's User Agent string.
        /// </summary>
        public string UserAgent
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.UserAgent;
                return "";
            }
        }

        /// <summary>
        /// \UniqueBrowserId identifies an instance of a Web Browser. Each time
        /// an end-user opens the application from a different browser window,
        /// this ID will have a different value.
        /// </summary>
        public string UniqueBrowserId
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.UniqueBrowserId;
                return "";
            }
        }

        /// <summary>
        /// \Returns the URL of the current application.
        /// </summary>
        public string Location
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.Location;
                return "";
            }
        }

        /// <summary>
        /// Gets or sets custom application data.
        /// </summary>
        public string CustomData {
            get {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.CustomData;
                return "";
            }
            set {
                if (m_VirtualUI != null)
                    m_VirtualUI.BrowserInfo.CustomData = value;
            }
        }

        /// <summary>
        /// \Returns the application screen resolution defined in the
        /// application profile.
        /// </summary>
        public int ScreenResolution
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.ScreenResolution;
                return 0;
            }
        }

        /// <summary>
        /// \Returns the browser's orientation.
        /// </summary>
        public BrowserOrientation Orientation
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.Orientation;
                return 0;
            }
        }

        /// <summary>
        /// \Returns a browser's cookie value.
        /// </summary>
        public string GetCookie(string Name)
        {
            if (m_VirtualUI != null)
                return m_VirtualUI.BrowserInfo.GetCookie(Name);
            return "";
        }

        /// <summary>
        /// \Sets a cookie in the browser.
        /// </summary>
        public void SetCookie(string Name, string Value, string Expires)
        {
            if (m_VirtualUI != null)
                m_VirtualUI.BrowserInfo.SetCookie(Name, Value, Expires);
        }
        /// <summary>
        /// \Returns the selected Browser Rule.
        /// </summary>
        public string SelectedRule
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.SelectedRule;
                return "";
            }
        }

        /// <summary>
        /// \Returns aditional data from Browser (JSON format).
        /// </summary>
        public string ExtraData {
            get {
                if (m_VirtualUI != null)
                    return m_VirtualUI.BrowserInfo.ExtraData;
                return "";
            }
        }

        /// <summary>
        /// \Returns a specific value from ExtraData by it's name.
        /// </summary>
        /// <param name="Name">Name of value to return.</param>
        public string GetExtraDataValue(string Name) {
            if (m_VirtualUI != null)
                return m_VirtualUI.BrowserInfo.GetExtraDataValue(Name);
            return "";
        }
    }

    /*
   * *********************************************************************************************
   *  DevServer
   * *********************************************************************************************
   */

    /// <summary>
    /// Contains properties to manage the VirtualUI Development
    /// Server as well as the access from the developer's web
    /// browser.
    /// </summary>
    public class HTMLDoc : IHTMLDoc, IDisposable
    {
        private IVirtualUI m_VirtualUI;

        public HTMLDoc(IVirtualUI virtualUI)
        {
            m_VirtualUI = virtualUI;
        }

        ~HTMLDoc()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_VirtualUI != null)
                Marshal.ReleaseComObject(m_VirtualUI);
            m_VirtualUI = null;
        }

        /// <summary>
        ///   Inserts an HTML. Used to insert regular HTML elements or WebComponents with custom elements.
        /// </summary>
        public void CreateComponent(string Id, string Html, IntPtr ReplaceWnd)
        {
            if (m_VirtualUI != null)
                m_VirtualUI.HTMLDoc.CreateComponent(Id, Html, ReplaceWnd);
        }

        /// <summary>
        ///   Creates an url pointing to a local filename. This url is valid during the session lifetime and its private to this session.
        /// </summary>
        public void CreateSessionURL(string url, string filename)
        {
            if (m_VirtualUI != null)
                m_VirtualUI.HTMLDoc.CreateSessionURL(url, filename);
        }

        /// <summary>
        ///   Loads a script from url.
        /// </summary>
        public void LoadScript(string url)
        {
            LoadScript(url, "");
        }

        /// <summary>
        ///  Loads a script from URL. If Filename is specified, creates a session
        ///  URL first and then load the script from that Filename.
        /// </summary>
        public void LoadScript(string url, string filename)
        {
            if (m_VirtualUI != null)
                m_VirtualUI.HTMLDoc.LoadScript(url, filename);
        }

        /// <summary>
        ///  Imports an HTML from URL. If Filename is specified, creates a session
        ///  URL first and then imports the html file from that Filename.
        /// </summary>
        public void ImportHTML(string url)
        {
            ImportHTML(url, "");
        }

        /// <summary>
        ///   Imports an HTML file from disk and assigns a session url.
        /// </summary>
        public void ImportHTML(string url, string filename)
        {
            if (m_VirtualUI != null)
                m_VirtualUI.HTMLDoc.ImportHTML(url, filename);
        }

        /// <summary>
        ///   Gets a safe, temporary and unique URL to access any file in the disk.
        /// </summary>
        public string GetSafeUrl(string filename)
        {
            return GetSafeUrl(filename, 60);
        }

        /// <summary>
        ///   Gets a safe, temporary and unique URL to access any file in the disk.
        /// </summary>
        public string GetSafeUrl(string filename, int minutes)
        {
            if (m_VirtualUI != null)
                return m_VirtualUI.HTMLDoc.GetSafeUrl(filename, minutes);
            else return "";
        }

    }

     /*
     * *********************************************************************************************
     *  DevServer
     * *********************************************************************************************
     */

    /// <summary>
    /// Contains properties to manage the VirtualUI Development
    /// Server as well as the access from the developer's web
    /// browser.
    /// </summary>
    public class DevServer : IDevServer, IDisposable
    {
        private IVirtualUI m_VirtualUI;

        public DevServer(IVirtualUI virtualUI)
        {
            m_VirtualUI = virtualUI;
        }

        ~DevServer()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_VirtualUI != null)
                Marshal.ReleaseComObject(m_VirtualUI);
            m_VirtualUI = null;
        }

        /// <summary>
        /// Enables/disables the Development Server.
        /// </summary>
        public bool Enabled
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.DevServer.Enabled;
                return false;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.DevServer.Enabled = value;
            }
        }
        /// <summary>
        /// Gets/sets the Development Server's TCP/IP listening port.
        /// </summary>
        public int Port
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.DevServer.Port;
                return 0;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.DevServer.Port = value;
            }
        }
        /// <summary>
        /// Instructs VirtualUI whether start or not the local web
        /// browser upon VirtualUI activation.
        /// </summary>
        public bool StartBrowser
        {
            get
            {
                if (m_VirtualUI != null)
                    return m_VirtualUI.DevServer.StartBrowser;
                return false;
            }
            set
            {
                if (m_VirtualUI != null)
                    m_VirtualUI.DevServer.StartBrowser = value;
            }
        }
    }

    /*
     * *********************************************************************************************
     *  VirtualUI
     * *********************************************************************************************
     */

    public class BrowserResizeEventArgs : EventArgs
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool ResizeMaximized { get; set; }
    }

    public class GetUploadDirEventArgs : EventArgs
    {
        public string Directory { get; set; }
        public bool Handled { get; set; }
    }

    public class DownloadEndArgs : EventArgs
    {
        public string Filename { get; set; }
    }

    public class UploadEndArgs : EventArgs
    {
        public string Filename { get; set; }
    }
    public class SaveDialogArgs : EventArgs
    {
        public string Filename { get; set; }
    }
    public class DragFileArgs: EventArgs
    {
        public DragAction Action { get; set; }
        public Int32 X {get;set;}
        public Int32 Y {get;set;}
        public String Filenames {get;set;}
    }

    public class CloseArgs : EventArgs
    {
    }

    public class ReceiveMessageArgs : EventArgs
    {
        public string Data { get; set; }
    }

    public class RecorderChangedArgs : EventArgs
    {
    }


    [ClassInterface(ClassInterfaceType.AutoDual), ComSourceInterfaces(typeof(IEvents))]
    internal sealed class VirtualUISink : IEvents
    {
        #region VirtualUISink Members
        private VirtualUI m_VirtualUI;
        public void OnGetUploadDir(ref string Directory, ref bool Handled)
        {
            m_VirtualUI.OnGetUploadDirEventHandler(ref Directory, ref Handled);
        }
        public void OnBrowserResize(ref int Width, ref int Height, ref bool ResizeMaximized)
        {
            m_VirtualUI.OnBrowserResizeEventHandler(ref Width, ref Height, ref ResizeMaximized);
        }
        public void OnClose()
        {
            m_VirtualUI.OnCloseEventHandler();
        }
        public void OnReceiveMessage(string Data)
        {
            m_VirtualUI.OnReceiveMessageEventHandler(Data);
        }
        public void OnDownloadEnd(string Filename)
        {
            m_VirtualUI.OnDownloadEndEventHandler(Filename);
        }
        public void OnUploadEnd(string Filename) {
            m_VirtualUI.OnUploadEndEventHandler(Filename);
        }
        public void OnSaveDialog(string Filename) {
            m_VirtualUI.OnSaveDialogEventHandler(Filename);
        }
        public void OnDragFile(DragAction Action, Int32 X, Int32 Y, String Filenames) {
            m_VirtualUI.OnDragFileEventHandler(Action, X, Y, Filenames == null ? "" : Filenames);
        }
        public void OnRecorderChanged() {
            m_VirtualUI.OnRecorderChangedEventHandler();
        }
        #endregion

        internal VirtualUISink(VirtualUI virtualUI)
        {
            m_VirtualUI = virtualUI;
        }
    }

    /// <summary>
    /// Main class. Has methods, properties and events to allow the
    /// activation and control the behavior of VirtualUI.
    /// </summary>
    public class VirtualUI : VirtualUILibrary,  IDisposable
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int funcGetInstance(ref IVirtualUI vui);
        private funcGetInstance GetInstance;

        private static VirtualUI g_virtualUI;
        private static bool g_virtualUIExists;

        private IVirtualUI m_VirtualUI;
        private BrowserInfo m_BrowserInfo;
        private DevServer m_DevServer;
        private HTMLDoc m_HTMLDoc;

        private VirtualUISink virtualUIEventSink;
        private System.Runtime.InteropServices.ComTypes.IConnectionPointContainer connectionPointContainer;
        private System.Runtime.InteropServices.ComTypes.IConnectionPoint connectionPoint;
        private int connectionCookie;

        public VirtualUI()
            : base()
        {
            if (!g_virtualUIExists)
            {
                g_virtualUIExists = true;
                g_virtualUI = new VirtualUI();
            }
            if (LibHandle != IntPtr.Zero)
            {
                IntPtr pAddressOfFunctionToCall = GetProcAddress(LibHandle, "DllGetInstance");
                GetInstance = (funcGetInstance)Marshal.GetDelegateForFunctionPointer(
                    pAddressOfFunctionToCall,
                    typeof(funcGetInstance));
                GetInstance(ref m_VirtualUI);

                if (g_virtualUIExists && g_virtualUI != null)
                {
                    virtualUIEventSink = g_virtualUI.virtualUIEventSink;
                    connectionPointContainer = g_virtualUI.connectionPointContainer;
                    connectionPoint = g_virtualUI.connectionPoint;
                    //if (connectionPoint != null)
                    //    connectionPoint.Advise((IEvents)virtualUIEventSink, out connectionCookie);
                }
                else
                {
                    virtualUIEventSink = new VirtualUISink(this);
                    connectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)m_VirtualUI;
                    Guid virtualUIEventsInterfaceId = typeof(IEvents).GUID;
                    connectionPointContainer.FindConnectionPoint(ref virtualUIEventsInterfaceId, out connectionPoint);
                    if (connectionPoint != null)
                        connectionPoint.Advise((IEvents)virtualUIEventSink, out connectionCookie);
                }
            }
            m_BrowserInfo = new BrowserInfo(m_VirtualUI);
            m_DevServer = new DevServer(m_VirtualUI);
            m_HTMLDoc = new HTMLDoc(m_VirtualUI);
        }

        ~VirtualUI()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_VirtualUI != null)
            {
                Marshal.ReleaseComObject(m_VirtualUI);
            }
            if (m_BrowserInfo != null)
            {
                ((IDisposable)m_BrowserInfo).Dispose();
            }
            if (m_DevServer != null)
            {
                ((IDisposable)m_DevServer).Dispose();
            }
            if (m_HTMLDoc != null)
            {
                ((IDisposable)m_HTMLDoc).Dispose();
            }
            m_VirtualUI = null;
            m_BrowserInfo = null;
            m_DevServer = null;
            m_HTMLDoc = null;
        }

        /// <summary>
        /// Starts the VirtualUI's activation process. Returns true if
        /// VirtualUI was fully activated or false if the timeout
        /// expired. The timeout is 60 seconds.
        /// </summary>
        public bool Start()
        {
            return Start(60000);
        }

        /// <summary>
        /// Starts the VirtualUI's activation process. Returns true if
        /// VirtualUI was fully activated or false if the passed timeout
        /// expired.
        /// </summary>
        /// <param name="Timeout">Maximum time, in seconds, until the
        ///                       activation process is canceled.
        ///                       Defaults to 60 seconds. </param>
        /// <remarks>
        /// To fully activate VirtualUI, the connection with the
        /// end-user's web browser must established within the time
        /// specified by Timeout parameter.
        /// </remarks>
        public bool Start(int timeout)
        {
            if (m_VirtualUI != null)
                return m_VirtualUI.Start(timeout);
            return false;
        }

        /// <summary>
        /// Deactivates VirtualUI, closing the connection with the
        /// end-user's web browser.
        /// </summary>
        public void Stop()
        {
            if (m_VirtualUI != null) m_VirtualUI.Stop();
        }

        /// <summary>
        /// Sends the specified file to the end-user's web browser for
        /// saving it in the remote machine.
        /// </summary>
        /// <param name="LocalFilename">Name of both the local and
        ///                             remote file . </param>
        public void DownloadFile(string LocalFilename)
        {
            DownloadFile(LocalFilename, "", "");
        }

        /// <summary>
        /// Sends the specified file to the end-user's web browser for
        /// saving it in the remote machine.
        /// </summary>
        /// <param name="LocalFilename">Name of the local file to be
        ///                             sent. </param>
        /// <param name="RemoteFilename">Name of the file in the remote
        ///                              machine. </param>
        public void DownloadFile(string LocalFilename, string RemoteFilename)
        {
            DownloadFile(LocalFilename, RemoteFilename, "");
        }

        /// <summary>
        /// Sends the specified file to the end-user's web browser for
        /// saving it in the remote machine.
        /// </summary>
        /// <param name="LocalFilename">Name of the local file to be
        ///                             sent. </param>
        /// <param name="RemoteFilename">Name of the file in the remote
        ///                              machine. </param>
        /// <param name="MimeType">content-type of the file. If specified,
        ///                        the content will be handled by browser.
        ///                        Leave blank to force download.</param>
        public void DownloadFile(string LocalFilename, string RemoteFilename, string MimeType)
        {
            if (m_VirtualUI != null) m_VirtualUI.DownloadFile(LocalFilename, RemoteFilename, MimeType);
        }

        /// <summary>
        /// Sends the specified PDF file to be shown on the end-user's
        /// web browser.
        /// </summary>
        /// <param name="AFileName">Name of the PDF file. </param>
        /// <remarks>
        /// PrintPDF is similar to DownloadFile, except that it downloads
        /// the file with a content-type: application/pdf.
        /// </remarks>
        public void PrintPdf(string FileName)
        {
            if (m_VirtualUI != null) m_VirtualUI.PrintPdf(FileName);
        }

        /// <summary>
        /// Sends the specified PDF file to be shown on the end-user's
        /// web browser. It's similar to PrintPdf, except that disables
        /// the printing options in the browser. Built\-in browser printing
        /// commands will be available.
        /// </summary>
        /// <param name="AFileName">Name of the PDF file. </param>
        public void PreviewPdf(string FileName) {
            if (m_VirtualUI != null) m_VirtualUI.PreviewPdf(FileName);
        }

        /// <summary>
        ///   Displays a popup with a button to open a web link.
        /// </summary>
        /// <param name="url">Link to open.</param>
        /// <param name="caption">Text to display in popup.</param>
        public void OpenLinkDlg(string Url, string Caption)
        {
            if (m_VirtualUI != null) m_VirtualUI.OpenLinkDlg(Url, Caption);
        }

        /// <summary>
        /// Sends a data string to the web browser.
        /// </summary>
        /// <remarks>
        /// This method is used to send custom data to the browser for
        /// custom purposes.
        /// </remarks>
        public void SendMessage(string Data)
        {
            if (m_VirtualUI != null) m_VirtualUI.SendMessage(Data);
        }

        /// <summary>
        /// Allows the execution of the passed application.
        /// </summary>
        /// <param name="Filename">regular expression specifying the
        ///                        filename(s) of the applications
        ///                        allowed to run. </param>
        /// <remarks>
        /// Under VirtualUI environment, only applications precompiled
        /// with VirtualUI SDK should be allowed to run. Applications not
        /// under VirtualUI control, cannot be controlled.
        /// </remarks>
        public void AllowExecute(string Filename)
        {
            if (m_VirtualUI != null) m_VirtualUI.AllowExecute(Filename);
        }

        /// <summary>
        /// Allows to the the image quality for the specified window.
        /// </summary>
        /// <param name="Wnd">Window handle. </param>
        /// <param name="Class">Window classname. </param>
        /// <param name="Quality">Quality from 0 to 100. </param>
        public void SetImageQualityByWnd(long Wnd, string Classname, int Quality)
        {
            if (m_VirtualUI != null) m_VirtualUI.SetImageQualityByWnd(Wnd, Classname, Quality);
        }

        /// <summary>
        ///   Selects a file from client machine, and it's uploaded to
        ///   ServerDirectory
        /// </summary>
        /// <param name="ServerDirectory">Destination directory in Server.</param>
        public void UploadFile(string ServerDirectory)
        {
            if (m_VirtualUI != null) m_VirtualUI.UploadFile(ServerDirectory);
        }

        /// <summary>
        ///   Selects a file from client machine, and it's uploaded to VirtualUI
        ///   public path.
        /// </summary>
        public void UploadFile()
        {
            UploadFile("");
        }

        public bool UploadFileEx(string ServerDirectory, out string FileName) {
            if (m_VirtualUI != null)
                return m_VirtualUI.UploadFileEx(ServerDirectory, out FileName);
            else {
                FileName = "";
                return false;
            }
        }

        public bool UploadFileEx(out string FileName) {
            return UploadFileEx("", out FileName);
        }

        /// <summary>
        ///   Suspends the UI streaming to the web browser
        /// </summary>
        public void Suspend()
        {
            if (m_VirtualUI != null) m_VirtualUI.Suspend();
        }
        /// <summary>
        ///   Resumes the UI streaming to the web browser
        /// </summary>
        public void Resume()
        {
            if (m_VirtualUI != null) m_VirtualUI.Resume();
        }

        /// <summary>
        ///   Flushes immediately the paintings of a window to the browser.
        ///   This is meant to be used in situations where the window's thread
        ///   is busy doing some heavy work. Splash windows in initialization
        ///   is one of those cases.
        /// </summary>
        /// <param name="Wnd">The Window to be flushed</param>
        /// <returns>
        ///   True if ok, False if error.
        /// </returns>
        public bool FlushWindow(long Wnd)
        {
            if (m_VirtualUI != null) 
                return m_VirtualUI.FlushWindow(Wnd);
            else
                return false;
        }

        /// <summary>
        ///   Takes a screenshot of a Window.
        /// </summary>
        /// <param name="Wnd">The Window to capture.</param>
        /// <param name="FileName">Full path of file to save screenshot.
        ///                        Extensions allowed: jpg, bmp, png.</param>
        public bool TakeScreenshot(long Wnd, string FileName)
        {
            if (m_VirtualUI != null)
                return m_VirtualUI.TakeScreenshot(Wnd, FileName);
            else
                return false;
        }

        /// <summary>
        ///   In mobile, shows the keyboard.
        /// </summary>
        public void ShowVirtualKeyboard() {
            if (m_VirtualUI != null)
                m_VirtualUI.ShowVirtualKeyboard();
        }


        /// <summary>
        /// \Returns the VirtualUI's state.
        /// </summary>
        public bool Active
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.Active; else return false;
            }
        }

        /// <summary>
        /// Enables/disables VirtualUI for the container application.
        /// </summary>
        public bool Enabled
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.Enabled; else return false;
            }
            set
            {
                if (m_VirtualUI != null) m_VirtualUI.Enabled = value;
            }
        }

        /// <summary>
        /// Gets/sets the development mode.
        /// </summary>
        /// <remarks>
        /// When in development mode, applications executed under the
        /// IDE, connect to the Development Server, allowing the access
        /// to the application from the browser while in debugging.
        /// </remarks>
        public bool DevMode
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.DevMode; else return false;
            }
            set
            {
                if (m_VirtualUI != null) m_VirtualUI.DevMode = value;
            }
        }

        /// <summary>
        /// Enables/disables the use of standard dialogs.
        /// </summary>
        /// <remarks>
        /// When set to false, the standard save, open and print dialogs
        /// are replaced by native browser ones, enabling you to extend
        /// the operations to the remote computer.
        /// </remarks>
        public bool StdDialogs
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.StdDialogs; else return false;
            }
            set
            {
                if (m_VirtualUI != null) m_VirtualUI.StdDialogs = value;
            }
        }

        /// <summary>
        /// Gets/sets the option flags
        /// </summary>
        public uint Options
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.Options; else return 0;
            }
            set
            {
                if (m_VirtualUI != null) m_VirtualUI.Options = value;
            }
        }

        /// <summary>
        /// Contains information regarding the end-user's environment.
        /// </summary>
        public BrowserInfo BrowserInfo
        {
            get
            {
                return m_BrowserInfo;
            }
        }

        /// <summary>
        ///   Contains methods to modify the behavior on the HTML page.
        /// </summary>
        public HTMLDoc HTMLDoc
        {
            get
            {
                return m_HTMLDoc;
            }
        }

        /// <summary>
        /// Allows for managing the Development Server.
        /// </summary>
        public DevServer DevServer
        {
            get
            {
                return m_DevServer;
            }
        }

        /// <summary>
        /// Controls some working parameters on the client side.
        /// </summary>
        public IClientSettings ClientSettings
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.ClientSettings;
                return null;
            }
        }

        /// <summary>
        /// Session recording and playback.
        /// </summary>
        /// <remarks>
        /// To record a session:
        ///
        /// \- Set the Recorder.Filename property with the path and name
        /// of the session file to be used. No extension is needed; the
        /// recorder will generate two files, with extensions idx and
        /// dat.
        ///
        /// \- Call Recorder.Play, passing a track name. This name will
        /// allow to play different recordings in the same session.
        ///
        /// To stop recording:
        ///
        /// \- Call Recorder.Stop.
        ///
        /// To play a recorded session:
        ///
        /// \- Set the Filename property with the path and name of the
        /// session file to be played (the file with idx extension).
        ///
        /// \- Call Play with the range of entries to play.
        ///
        /// To play an entire session, pass 0 and the Count property.
        ///
        /// To play only a specific track, pass the Position of track to
        /// reproduce as From, and the Position of next track as To. For
        /// the last track, the To parameter must be the Count property
        /// of recorder.
        /// </remarks>
        public IRecorder Recorder {
            get {
                if (m_VirtualUI != null) return m_VirtualUI.Recorder;
                return null;
            }
        }

        public IFileSystemFilter FileSystemFilter
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.FileSystemFilter;
                return null;
            }
        }

        public IRegistryFilter RegistryFilter
        {
            get
            {
                if (m_VirtualUI != null) return m_VirtualUI.RegistryFilter;
                return null;
            }
        }

        /// <summary>
        /// Fires when the VirtualUI Viewer's container window resizes.
        /// Normally, when the browser resizes.
        /// </summary>
        /// <remarks>
        /// Allows you to take action when the  VirtualUI Viewer's
        /// container window resizes. Set Handled to true to disable the
        /// default processing, which resizing all maximized windows.
        /// </remarks>
        private event EventHandler<BrowserResizeEventArgs> m_OnBrowserResize;
        public event EventHandler<BrowserResizeEventArgs> OnBrowserResize
        {
            add {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnBrowserResize += value;
                    return;
                }
                m_OnBrowserResize += value;
            }
            remove {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnBrowserResize -= value;
                    return;
                }
                m_OnBrowserResize -= value;
            }
        }

        /// <summary>
        /// Fires during an upload request, allowing you to change the
        /// save folder.
        /// </summary>
        private event EventHandler<GetUploadDirEventArgs> m_OnGetUploadDir;
        public event EventHandler<GetUploadDirEventArgs> OnGetUploadDir
        {
            add
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnGetUploadDir += value;
                    return;
                }
                m_OnGetUploadDir += value;
            }
            remove
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnGetUploadDir -= value;
                    return;
                }
                m_OnGetUploadDir -= value;
            }
        }

        /// <summary>
        ///   Fires when the browser window is about to close.
        /// </summary>
        private event EventHandler<CloseArgs> m_OnClose;
        public event EventHandler<CloseArgs> OnClose
        {
            add
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnClose += value;
                    return;
                }
                m_OnClose += value;
            }
            remove
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnClose -= value;
                    return;
                }
                m_OnClose -= value;
            }
        }

        /// <summary>
        ///   Fires when a custom data string is sent from the web browser page.
        /// </summary>
        private event EventHandler<ReceiveMessageArgs> m_OnReceiveMessage;
        public event EventHandler<ReceiveMessageArgs> OnReceiveMessage
        {
            add
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnReceiveMessage += value;
                    return;
                }
                m_OnReceiveMessage += value;
            }
            remove
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnReceiveMessage -= value;
                    return;
                }
                m_OnReceiveMessage -= value;
            }
        }

        /// <summary>
        ///   Fires when the file has been sent.
        /// </summary>
        private event EventHandler<DownloadEndArgs> m_OnDownloadEnd;
        public event EventHandler<DownloadEndArgs> OnDownloadEnd
        {
            add
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnDownloadEnd += value;
                    return;
                }
                m_OnDownloadEnd += value;
            }
            remove
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnDownloadEnd -= value;
                    return;
                }
                m_OnDownloadEnd -= value;
            }
        }

        /// <summary>
        ///   Fires when the UploadFile method ends.
        /// </summary>
        private event EventHandler<UploadEndArgs> m_OnUploadEnd;
        public event EventHandler<UploadEndArgs> OnUploadEnd {
            add {
                if (g_virtualUI != this) {
                    g_virtualUI.OnUploadEnd += value;
                    return;
                }
                m_OnUploadEnd += value;
            }
            remove {
                if (g_virtualUI != this) {
                    g_virtualUI.OnUploadEnd -= value;
                    return;
                }
                m_OnUploadEnd -= value;
            }
        }
        
        /// <summary>
        ///   Fires when the Save Dialog is Accepted.
        /// </summary>
        private event EventHandler<SaveDialogArgs> m_OnSaveDialog;
        public event EventHandler<SaveDialogArgs> OnSaveDialog
        {
            add
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnSaveDialog += value;
                    return;
                }
                m_OnSaveDialog += value;
            }
            remove
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnSaveDialog -= value;
                    return;
                }
                m_OnSaveDialog -= value;
            }
        }

        /// <summary>
        ///   Fires when the DragFile method.
        /// </summary>
        private event EventHandler<DragFileArgs> m_OnDragFile;
        public event EventHandler<DragFileArgs> OnDragFile {
            add {
                if (g_virtualUI != this) {
                    g_virtualUI.OnDragFile += value;
                    return;
                }
                m_OnDragFile += value;
            }
            remove {
                if (g_virtualUI != this) {
                    g_virtualUI.OnDragFile -= value;
                    return;
                }
                m_OnDragFile -= value;
            }
        }

        /// <summary>
        ///   Fires when there is a change in the recording or playback status.
        /// </summary>
        private event EventHandler<RecorderChangedArgs> m_OnRecorderChanged;
        public event EventHandler<RecorderChangedArgs> OnRecorderChanged
        {
            add
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnRecorderChanged += value;
                    return;
                }
                m_OnRecorderChanged += value;
            }
            remove
            {
                if (g_virtualUI != this)
                {
                    g_virtualUI.OnRecorderChanged -= value;
                    return;
                }
                m_OnRecorderChanged -= value;
            }
        }

        internal void OnBrowserResizeEventHandler(ref int Width, ref int Height, ref bool ResizeMaximized)
        {
            if (m_OnBrowserResize != null)
            {
                BrowserResizeEventArgs args = new BrowserResizeEventArgs();
                args.Width = Width;
                args.Height = Height;
                args.ResizeMaximized = ResizeMaximized;
                m_OnBrowserResize(this, args);
                Width = args.Width;
                Height = args.Height;
                ResizeMaximized = args.ResizeMaximized;
            }
        }

        internal void OnGetUploadDirEventHandler(ref string Directory, ref bool Handled)
        {
            if (m_OnGetUploadDir != null)
            {
                GetUploadDirEventArgs args = new GetUploadDirEventArgs();
                args.Directory = Directory;
                args.Handled = Handled;
                m_OnGetUploadDir(this, args);
                Directory = args.Directory;
                Handled = args.Handled;
            }
        }

        internal void OnCloseEventHandler()
        {
            if (m_OnClose != null)
            {
                CloseArgs args = new CloseArgs();
                m_OnClose(this, args);
            }
        }

        internal void OnReceiveMessageEventHandler(string Data)
        {
            if (m_OnReceiveMessage != null)
            {
                ReceiveMessageArgs args = new ReceiveMessageArgs();
                args.Data = Data;
                m_OnReceiveMessage(this, args);
            }
        }

        internal void OnDownloadEndEventHandler(string Filename)
        {
            if (m_OnDownloadEnd != null)
            {
                DownloadEndArgs args = new DownloadEndArgs();
                args.Filename = Filename;
                m_OnDownloadEnd(this, args);
            }
        }

        internal void OnUploadEndEventHandler(string Filename) {
            if (m_OnUploadEnd != null) {
                UploadEndArgs args = new UploadEndArgs();
                args.Filename = Filename;
                m_OnUploadEnd(this, args);
            }
        }
        
        internal void OnSaveDialogEventHandler(string Filename)
        {
            if (m_OnSaveDialog != null)
            {
                SaveDialogArgs args = new SaveDialogArgs();
                args.Filename = Filename;
                m_OnSaveDialog(this, args);
            }
        }

        internal void OnDragFileEventHandler(DragAction Action, Int32 X, Int32 Y, string Filenames){
            if (m_OnDragFile != null){
                DragFileArgs args = new DragFileArgs();
                args.Action = Action;
                args.X = X;
                args.Y = Y;
                args.Filenames = Filenames;
                m_OnDragFile(this, args);
            }
        }

        internal void OnRecorderChangedEventHandler() {
            if (m_OnRecorderChanged != null)
            {
                RecorderChangedArgs args = new RecorderChangedArgs();
                m_OnRecorderChanged(this, args);
            }
        }
    }

    /*
     * *********************************************************************************************
     *  JSObject
     * *********************************************************************************************
     */

    public class JSExecuteMethodEventArgs : EventArgs
    {
        public IJSObject Sender { get; set; }
        public IJSMethod Method { get; set; }
    }

    public class JSPropertyChangeEventArgs : EventArgs
    {
        public IJSObject Sender { get; set; }
        public IJSProperty Prop { get; set; }
    }

    [ClassInterface(ClassInterfaceType.AutoDual), ComSourceInterfaces(typeof(IJSObjectEvents))]
    internal sealed class JSObjectSink : IJSObjectEvents
    {
        #region JSObjectSink Members
        private JSObject m_JSObject;
        public void OnExecuteMethod(IJSObject Sender, IJSMethod Method)
        {
            m_JSObject.OnExecuteMethodEventHandler(Sender, Method);
        }
        public void OnPropertyChange(IJSObject Sender, IJSProperty Prop)
        {
            m_JSObject.OnOnPropertyChangeEventHandler(Sender, Prop);
        }
        #endregion

        internal JSObjectSink(JSObject jsObject)
        {
            m_JSObject = jsObject;
        }
    }

    /// <summary>
    /// Represents a custom remotable object.
    /// </summary>
    /// <remarks>
    /// JSObject allows you to define an object model that is
    /// mirrored on the client side, and allows for an easy, powerful
    /// and straight-forward way to connect the web browser client
    /// application and the remoted Windows application.
    ///
    /// JSObject can contain properties (IJSProperties), methods
    /// (IJSMethods), events (IJSEvents) and children objects.
    /// Changes to properties values are propagated in from server to
    /// client and viceversa, keeping the data synchronized.
    ///
    /// JSObject is defined as a model seen from the client
    /// perspective. A method (IJSMethod) is called on the client
    /// side and executed on the server side. An event (IJSEvent) is
    /// called on the server side and raised on the client side.
    /// </remarks>
    public class JSObject : VirtualUILibrary, IJSObject, IDisposable
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int funcDllCreateJSObject(ref IJSObject obj);
        private funcDllCreateJSObject DllCreateJSObject;
        private IJSObject m_JSObject;

        private JSObjectSink jsObjectEventSink;
        private System.Runtime.InteropServices.ComTypes.IConnectionPointContainer connectionPointContainer;
        private System.Runtime.InteropServices.ComTypes.IConnectionPoint connectionPoint;
        private int connectionCookie;

        public JSObject(string Id)
            : base()
        {
            if (LibHandle != IntPtr.Zero)
            {
                IntPtr pAddressOfFunctionToCall = GetProcAddress(LibHandle, "DllCreateJSObject");
                DllCreateJSObject = (funcDllCreateJSObject)Marshal.GetDelegateForFunctionPointer(
                    pAddressOfFunctionToCall,
                    typeof(funcDllCreateJSObject));
                DllCreateJSObject(ref m_JSObject);

                jsObjectEventSink = new JSObjectSink(this);
                connectionPointContainer = (System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)m_JSObject;
                Guid virtualUIEventsInterfaceId = typeof(IJSObjectEvents).GUID;
                connectionPointContainer.FindConnectionPoint(ref virtualUIEventsInterfaceId, out connectionPoint);
                if (connectionPoint != null)
                    connectionPoint.Advise((IJSObjectEvents)jsObjectEventSink, out connectionCookie);
            }
            this.Id = Id;
        }

        ~JSObject()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (connectionPoint != null)
            {
                try
                {
                    //connectionPoint.Unadvise(connectionCookie);
                }
                catch (Exception)
                {
                }
                connectionPoint = null;
                connectionCookie = 0;
            }
            if (m_JSObject != null)
                Marshal.ReleaseComObject(m_JSObject);
            m_JSObject = null;
        }

        public void FireEvent(string Name, IJSArguments Arguments)
        {
            if (m_JSObject != null)
                m_JSObject.FireEvent(Name, Arguments);
        }

        /// <summary>
        /// When this method called, all properties getters are
        /// internally called looking for changes. Any change to the
        /// property value is sent to the client.
        /// </summary>
        public void ApplyChanges()
        {
            if (m_JSObject != null)
                m_JSObject.ApplyChanges();
        }

        /// <summary>
        /// Propagates the whole JSObject definition to the javascript
        /// client.
        /// </summary>
        public void ApplyModel()
        {
            if (m_JSObject != null)
                m_JSObject.ApplyModel();
        }

        /// <summary>
        /// Identifier of the object. It must be unique among siblings
        /// objects.
        /// </summary>
        public string Id
        {
            get
            {
                if (m_JSObject != null)
                    return m_JSObject.Id;
                return "";
            }
            set
            {
                if (m_JSObject != null)
                    m_JSObject.Id = value;
            }
        }

        /// <summary>
        /// List containing all properties of this object.
        /// </summary>
        public IJSProperties Properties
        {
            get
            {
                if (m_JSObject != null)
                    return m_JSObject.Properties;
                return null;
            }
        }

        /// <summary>
        /// List containing all methods of this object.
        /// </summary>
        public IJSMethods Methods
        {
            get
            {
                if (m_JSObject != null)
                    return m_JSObject.Methods;
                return null;
            }
        }

        /// <summary>
        /// List containing all events of this object.
        /// </summary>
        public IJSEvents Events
        {
            get
            {
                if (m_JSObject != null)
                    return m_JSObject.Events;
                return null;
            }
        }

        /// <summary>
        /// List containing all events of this object.
        /// </summary>
        public IJSObjects Objects
        {
            get
            {
                if (m_JSObject != null)
                    return m_JSObject.Objects;
                return null;
            }
        }

        /// <summary>
        /// Fired when a method is executed on the remote object.
        /// </summary>
        public event EventHandler<JSExecuteMethodEventArgs> OnExecuteMethod;
        /// <summary>
        /// Fired when a property value has been changed on the remote
        /// object.
        /// </summary>
        public event EventHandler<JSPropertyChangeEventArgs> OnPropertyChange;

        internal void OnExecuteMethodEventHandler(IJSObject Sender, IJSMethod Method)
        {
            if (OnExecuteMethod != null)
            {
                JSExecuteMethodEventArgs args = new JSExecuteMethodEventArgs();
                args.Sender = Sender;
                args.Method = Method;
                OnExecuteMethod(this, args);
            }
        }

        internal void OnOnPropertyChangeEventHandler(IJSObject Sender, IJSProperty Prop)
        {
            if (OnPropertyChange != null)
            {
                JSPropertyChangeEventArgs args = new JSPropertyChangeEventArgs();
                args.Sender = Sender;
                args.Prop = Prop;
                OnPropertyChange(this, args);
            }
        }
    }

    /*
     * *********************************************************************************************
     *  JSBinding
     * *********************************************************************************************
     */
    public delegate void JSPropertySet(IJSObject Parent, IJSProperty Prop);

    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(IJSBinding))]
    public class JSBinding : IJSBinding, IDisposable
    {
        private JSPropertySet m_Proc;

        public JSBinding(JSPropertySet Proc)
        {
            m_Proc = Proc;
        }
        ~JSBinding()
        {
            Dispose();
        }
        public void Dispose()
        {
        }

        public void Set(IJSObject Parent, IJSProperty Prop)
        {
            if (m_Proc != null)
                m_Proc(Parent, Prop);
        }
    }

    /*
     * *********************************************************************************************
     *  JSCallback
     * *********************************************************************************************
     */
    public delegate void JSMethodCallback(IJSObject Parent, IJSMethod Method);

    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(IJSCallback))]
    public class JSCallback : IJSCallback, IDisposable
    {
        private JSMethodCallback m_Proc;

        public JSCallback(JSMethodCallback Proc)
        {
            m_Proc = Proc;
        }
        ~JSCallback()
        {
            Dispose();
        }
        public void Dispose()
        {
        }

        public void Callback(IJSObject Parent, IJSMethod Method)
        {
            if (m_Proc != null)
                m_Proc(Parent, Method);
        }
    }
}
