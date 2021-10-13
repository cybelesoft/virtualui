Imports Microsoft.Win32
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text
Imports System.ComponentModel
Imports System.Threading

Namespace Cybele.Thinfinity
    '
    '     * *********************************************************************************************
    '     *  Thinfinity_TLB translation
    '     * *********************************************************************************************
    '


    <Guid("4B85F81B-72A2-4FCD-9A6B-9CAC24B7A511"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), ComImport> _
    Public Interface IVirtualUI
        Function Start(timeout As Integer) As Boolean
        Sub [Stop]()
        Sub DownloadFile(LocalFilename As String)
        Sub DownloadFile(LocalFilename As String, RemoteFilename As String)
        Sub DownloadFile(LocalFilename As String, RemoteFilename As String, MimeType As String)
        Sub PrintPdf(FileName As String)
        Sub OpenLinkDlg(Url As String, Caption As String)
        Sub SendMessage(Data As String)
        Sub AllowExecute(Filename As String)
        Sub SetImageQualityByWnd(Wnd As Long, Classname As String, Quality As Integer)
        Sub UploadFile()
        Sub UploadFile(ServerDirectory As String)
        Function UploadFileEx(FileName As String) As Boolean
        Function UploadFileEx(ServerDirectory As String, FileName As String) As Boolean
        Sub Suspend()
        Sub Resume_()
        Function FlushWindow(Wnd As Long) As Boolean
        Function TakeScreenshot(Wnd As Long, FileName As String) As Boolean
        Sub ShowVirtualKeyboard()
        Sub PreviewPdf(FileName As String)
        ReadOnly Property Active() As Boolean
        Property Enabled() As Boolean
        Property DevMode() As Boolean
        Property StdDialogs() As Boolean
        Property Options As UInteger
        ReadOnly Property BrowserInfo() As IBrowserInfo
        ReadOnly Property DevServer() As IDevServer
        ReadOnly Property ClientSettings() As IClientSettings
        ReadOnly Property Recorder As IRecorder
        ReadOnly Property FileSystemFilter As IFileSystemFilter
        ReadOnly Property RegistryFilter As IRegistryFilter
        ReadOnly Property HTMLDoc() As IHTMLDoc
    End Interface

    <ComVisible(True), Guid("1C5700BC-2317-4062-B614-0A4E286CFE68"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IEvents
        <DispId(101)>
        Sub OnGetUploadDir(ByRef Directory As String, ByRef Handled As Boolean)
        <DispId(102)>
        Sub OnBrowserResize(ByRef Width As Integer, ByRef Height As Integer, ByRef ResizeMaximized As Boolean)
        <DispId(103)>
        Sub OnClose()
        <DispId(104)>
        Sub OnReceiveMessage(Data As String)
        <DispId(105)>
        Sub OnDownloadEnd(Filename As String)
        <DispId(106)>
        Sub OnRecorderChanged()
        <DispId(107)>
        Sub OnUploadEnd(Filename As String)
        <DispId(201)>
        Sub OnDragFile(Action As DragAction, X As Integer, Y As Integer, Filenames As String)
        <DispId(202)>
        Sub OnSaveDialog(Filename As String)
    End Interface

    <Guid("4D9F5347-460B-4275-BDF2-F2738E7F6757"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IBrowserInfo
        Property ViewWidth() As Integer
        Property ViewHeight() As Integer
        ReadOnly Property BrowserWidth() As Integer
        ReadOnly Property BrowserHeight() As Integer
        ReadOnly Property ScreenWidth() As Integer
        ReadOnly Property ScreenHeight() As Integer
        ReadOnly Property Username() As String
        ReadOnly Property IPAddress() As String
        ReadOnly Property UserAgent() As String
        ReadOnly Property ScreenResolution() As Integer
        ReadOnly Property Orientation() As BrowserOrientation
        ReadOnly Property UniqueBrowserId() As String
        ReadOnly Property Location() As String
        Property CustomData() As String
        Function GetCookie(Name As String) As String
        Sub SetCookie(Name As String, Value As String, Expires As String)
        ReadOnly Property SelectedRule() As String
        ReadOnly Property ExtraData() As String
        Function GetExtraDataValue(Name As String) As String
    End Interface

    <Guid("A5A7F58C-D83C-4C89-872E-0C51A9B5D3B0"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IHTMLDoc
        Sub CreateSessionURL(url As String, filename As String)
        Sub CreateComponent(Id As String, Html As String, ReplaceWnd As IntPtr)
        Function GetSafeUrl(filename As String, minutes As Integer) As String
        Sub LoadScript(url As String, filename As String)
        Sub ImportHTML(url As String, filename As String)
    End Interface

    <Guid("B3EAC0CA-D7AB-4AB1-9E24-84A63C8C3F80"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IDevServer
        Property Enabled() As Boolean
        Property Port() As Integer
        Property StartBrowser() As Boolean
    End Interface

    <Guid("439624CA-ED33-47BE-9211-91290F29584A"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IClientSettings
        Property MouseMoveGestureStyle() As MouseMoveGestureStyle
        Property MouseMoveGestureAction() As MouseMoveGestureAction
        Property CursorVisible() As Boolean
        Property MouseWheelStepValue() As Integer
        Property MouseWheelDirection() As Integer
        Property MousePressAsRightButton() As Boolean
    End Interface

    Public Enum IJSDataType
        JSDT_NULL = 0
        JSDT_STRING = 1
        JSDT_INT = 2
        JSDT_BOOL = 3
        JSDT_FLOAT = 4
        JSDT_JSON = 5
    End Enum

    Public Enum Options
        OPT_APPINVISIBLE = 1
        OPT_IGNORE_MOUSEMOVE = 2
        OPT_NODEFAULT_PRINTER = 4
        OPT_NOHTML_DRAG = 16
        OPT_NOHTML_SIZE = 64
        OPT_JSRO_SYNCCALLS = 32
        OPT_CLIPBOARD_LOCAL = 256
        OPT_SUPRESS_PRINT_DIALOG = 512
        OPT_AUTODOWNLOAD = 4096
    End Enum

    Public Enum BrowserOrientation
        PORTRAIT = 0
        LANDSCAPE = 1
    End Enum

    Public Enum MouseMoveGestureStyle
        MM_STYLE_RELATIVE = 0
        MM_STYLE_ABSOLUTE = 1
    End Enum

    Public Enum MouseMoveGestureAction
        MM_ACTION_MOVE = 0
        MM_ACTION_WHEEL = 1
    End Enum

    Public Enum DragAction
        DRAG_Start = 0
        DRAG_Over = 1
        DRAG_Drop = 2
        DRAG_Cancel = 3
        DRAG_Error = 99
    End Enum

    <Guid("6DE2E6A0-3C3A-47DC-9A93-928135EDAC90"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSValue
        Property DataType() As IJSDataType
        Property RawValue() As Object
        Property AsString() As String
        Property AsInt() As Integer
        Property AsBool() As Boolean
        Property AsFloat() As Single
        Property AsJSON() As String
    End Interface

    <Guid("E492419B-00AC-4A91-9AE9-9A82B07E89AE"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSNamedValue
        Inherits IJSValue
        Property Name() As String
    End Interface

    <Guid("59342310-79A7-4B14-8B63-6DF05609AE30"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSObject
        Sub FireEvent(Name As String, Arguments As IJSArguments)
        Sub ApplyChanges()
        Sub ApplyModel()
        Property Id() As String
        ReadOnly Property Properties() As IJSProperties
        ReadOnly Property Methods() As IJSMethods
        ReadOnly Property Events() As IJSEvents
        ReadOnly Property Objects() As IJSObjects

        Event OnExecuteMethod As EventHandler(Of JSExecuteMethodEventArgs)
        Event OnPropertyChange As EventHandler(Of JSPropertyChangeEventArgs)
    End Interface

    <ComVisible(True), Guid("A3D640E8-CD18-4196-A1A2-C87C82B0F88B"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSObjectEvents
        <DispId(101)>
        Sub OnExecuteMethod(Sender As IJSObject, Method As IJSMethod)
        <DispId(102)>
        Sub OnPropertyChange(Sender As IJSObject, Prop As IJSProperty)
    End Interface

    <Guid("C2406011-568E-4EAC-B95C-EF29E4806B86"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSObjects
        ReadOnly Property Count() As Integer
        Default ReadOnly Property Item(Index As Object) As IJSObject
        'IJSObject Find(string Id);
        Sub Clear()
        Function Add(Id As String) As IJSObject
        Sub Remove(Item As IJSObject)
    End Interface

    <Guid("1F95C0E9-E7BF-48C9-AA35-88AD0149109B"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSProperty
        Inherits IJSNamedValue
        Function OnGet(Binding As IJSBinding) As IJSProperty
        Function OnSet(Binding As IJSBinding) As IJSProperty
    End Interface

    <Guid("FCBB688F-8FB2-42C1-86FC-0AAF3B2A500C"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSProperties
        ReadOnly Property Count() As Integer
        Default ReadOnly Property Item(Index As Object) As IJSProperty
        'IJSProperty Find(string Name);
        Sub Clear()
        Function Add(Name As String) As IJSProperty
        Sub Remove(Item As IJSProperty)
    End Interface

    <Guid("8F8C4462-D7B5-4696-BAD5-16DFAA6E2601"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSArgument
        Inherits IJSNamedValue
    End Interface

    <Guid("FC097EF5-6D8A-4C80-A2AD-382FDC75E901"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSArguments
        ReadOnly Property Count() As Integer
        Default ReadOnly Property Item(Index As Object) As IJSArgument
        'IJSArgument Find(string Name);
        Sub Clear()
        Function Add(Name As String) As IJSArgument
        Sub Remove(Item As IJSArgument)
    End Interface

    <Guid("C45D6A8F-AD4A-47BB-AC3A-C125D6D5D27E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSMethod
        Function AddArgument(Name As String, DataType As IJSDataType) As IJSMethod
        Function OnCall(Callback As IJSCallback) As IJSMethod
        Property Name() As String
        ReadOnly Property Arguments() As IJSArguments
        ReadOnly Property ReturnValue() As IJSValue
    End Interface

    <Guid("E4CB461F-586E-4121-ABD7-345B87BC423A"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSMethods
        ReadOnly Property Count() As Integer
        Default ReadOnly Property Item(Index As Object) As IJSMethod
        'IJSMethod Find(string Name);
        Sub Clear()
        Function Add(Name As String) As IJSMethod
        Sub Remove(Item As IJSMethod)
    End Interface

    <Guid("8B66EACD-9619-43CF-9196-DCDA17F5500E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSEvent
        Function AddArgument(Name As String, DataType As IJSDataType) As IJSEvent
        Function ArgumentAsNull(Index As Object) As IJSEvent
        Function ArgumentAsString(Index As Object, Value As String) As IJSEvent
        Function ArgumentAsInt(Index As Object, Value As Integer) As IJSEvent
        Function ArgumentAsBool(Index As Object, Value As Boolean) As IJSEvent
        Function ArgumentAsFloat(Index As Object, Value As Single) As IJSEvent
        Function ArgumentAsJSON(Index As Object, Value As String) As IJSEvent
        Sub Fire()
        Property Name() As String
        ReadOnly Property Arguments() As IJSArguments

    End Interface

    <Guid("6AE952B3-B6DA-4C81-80FF-D0A162E11D02"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSEvents
        ReadOnly Property Count() As Integer
        Default ReadOnly Property Item(Index As Object) As IJSEvent
        'IJSEvent Find(string Name);
        Sub Clear()
        Function Add(Name As String) As IJSEvent
        Sub Remove(Item As IJSEvent)
    End Interface

    <ComVisible(True), Guid("ACFC2953-37F1-479E-B405-D0BB75E156E6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSBinding
        Sub [Set](Parent As IJSObject, Prop As IJSProperty)
    End Interface

    <ComVisible(True), Guid("ADD570A0-491A-4E40-8120-57B4D1245FD3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IJSCallback
        Sub Callback(Parent As IJSObject, Method As IJSMethod)
    End Interface



    Public Enum RecorderState
        Inactive = 0
        Recording = 1
        Playing = 2
    End Enum

    <Guid("D89DA2B6-B7BF-4065-80F5-6D78B331C7DD"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IRecorder
        Property Filename() As String
        ReadOnly Property Position As Integer
        ReadOnly Property Count As Integer
        ReadOnly Property State As RecorderState
        Property Options As Long
        ReadOnly Property Tracks As IRecTracks
        Sub Rec(Label As String)
        Sub Play(From As Integer, [To] As Integer)
        Sub [Stop]()
    End Interface

    <Guid("D4744AE1-70CB-43DD-BEA5-A5310B2E24C6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IRecTrack
        ReadOnly Property Name As String
        ReadOnly Property Position As Integer
    End Interface

    <Guid("AB45B615-9309-471E-A455-3FE93F88E674"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IRecTracks
        ReadOnly Property Item(Index As Integer) As IRecTrack
        ReadOnly Property Count As Integer
    End Interface

    <Guid("3FE99D2F-0CFC-43D1-B762-0C7C15EB872E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IFileSystemFilter
        Property User() As String
        Property CfgFile() As String
        Property Active() As Boolean
    End Interface

    <Guid("4834F840-915B-488B-ADEA-98890A04CEE6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)>
    Public Interface IRegistryFilter
        Property User() As String
        Property CfgFile() As String
        Property Active() As Boolean
    End Interface

    '
    '     * *********************************************************************************************
    '     *  VirtualUILibrary. Base class which loads the Thinfinity.VirtualUI.dll
    '     * *********************************************************************************************
    '


    Public Class VirtualUILibrary
        <DllImport("kernel32.dll")>
        Private Shared Function LoadLibrary(dllToLoad As String) As IntPtr
        End Function
        <DllImport("kernel32.dll")>
        Protected Shared Function GetProcAddress(hModule As IntPtr, procedureName As String) As IntPtr
        End Function
        <DllImport("kernel32.dll")>
        Private Shared Function FreeLibrary(hModule As IntPtr) As Boolean
        End Function
        <DllImport("kernel32.dll")>
        Private Shared Function GetPrivateProfileString(lpAppName As String,
                    lpKeyName As String,
                    lpDefault As String,
                    lpReturnedString As StringBuilder,
                    nSize As Integer,
                    lpFileName As String) As Integer
        End Function

        Protected Shared LibHandle As IntPtr = IntPtr.Zero

        Public Sub New()
            If LibHandle = IntPtr.Zero Then
                Dim TargetDir As String = GetDLLDir()
                If TargetDir IsNot Nothing Then
                    Dim LibFilename As String = TargetDir & "\Thinfinity.VirtualUI.DLL"
                    LibHandle = LoadLibrary(LibFilename)
                    If LibHandle <> IntPtr.Zero Then
                    End If
                End If
            End If
        End Sub

        Private Shared Function GetDLLDir() As String
            Dim RegKey As RegistryKey = Nothing
            Dim IniFileName As String
            IniFileName = AppDomain.CurrentDomain.BaseDirectory + "\OEM.ini"
            If File.Exists(IniFileName) Then
                Dim sbOEMKey32 As StringBuilder
                Dim sbOEMKey64 As StringBuilder
                sbOEMKey32 = New StringBuilder(1024)
                sbOEMKey64 = New StringBuilder(1024)
                GetPrivateProfileString("PATHS", "Key32", "", sbOEMKey32, sbOEMKey32.Capacity, IniFileName)
                GetPrivateProfileString("PATHS", "Key64", "", sbOEMKey64, sbOEMKey64.Capacity, IniFileName)
                If sbOEMKey32.ToString() <> "" AndAlso RegKey Is Nothing Then
                    Dim oemKey32 As String = sbOEMKey32.ToString()
                    If oemKey32.StartsWith("\") Then
                        oemKey32 = oemKey32.Substring(1)
                    End If
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey32, False)
                End If
                If sbOEMKey64.ToString() <> "" AndAlso RegKey Is Nothing Then
                    Dim oemKey64 As String = sbOEMKey64.ToString()
                    If oemKey64.StartsWith("\") Then
                        oemKey64 = oemKey64.Substring(1)
                    End If
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey64, False)
                End If
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\VirtualUI\Dev", False)
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Cybele Software\Setups\Thinfinity\VirtualUI\Dev", False)
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\VirtualUI", False)
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Cybele Software\Setups\Thinfinity\VirtualUI", False)
            End If
            If RegKey IsNot Nothing Then
                If IntPtr.Size = 8 Then
                    Return DirectCast(RegKey.GetValue("TargetDir_x64", Nothing), String)
                Else
                    Return DirectCast(RegKey.GetValue("TargetDir_x86", Nothing), String)
                End If
            Else
                Return Nothing
            End If

        End Function
    End Class

    '
    '     * *********************************************************************************************
    '     *  ClientSettings
    '     * *********************************************************************************************
    '


    Public Class ClientSettings
        Implements IClientSettings
        Implements IDisposable
        Private m_VirtualUI As IVirtualUI

        Public Sub New(virtualUI As IVirtualUI)
            m_VirtualUI = virtualUI
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_VirtualUI IsNot Nothing Then
                Marshal.ReleaseComObject(m_VirtualUI)
            End If
            m_VirtualUI = Nothing
        End Sub

        Public Property MouseMoveGestureStyle() As MouseMoveGestureStyle Implements IClientSettings.MouseMoveGestureStyle
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings.MouseMoveGestureStyle
                End If
                Return MouseMoveGestureStyle.MM_STYLE_ABSOLUTE
            End Get
            Set(value As MouseMoveGestureStyle)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.ClientSettings.MouseMoveGestureStyle = value
                End If
            End Set
        End Property

        Public Property MouseMoveGestureAction() As MouseMoveGestureAction Implements IClientSettings.MouseMoveGestureAction
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings.MouseMoveGestureAction
                End If
                Return MouseMoveGestureAction.MM_ACTION_MOVE
            End Get
            Set(value As MouseMoveGestureAction)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.ClientSettings.MouseMoveGestureAction = value
                End If
            End Set
        End Property

        Public Property CursorVisible() As Boolean Implements IClientSettings.CursorVisible
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings.CursorVisible
                End If
                Return True
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.ClientSettings.CursorVisible = value
                End If
            End Set
        End Property

        Public Property MouseWheelStepValue() As Integer Implements IClientSettings.MouseWheelStepValue
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings.MouseWheelStepValue
                End If
                Return 120
            End Get
            Set(value As Integer)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.ClientSettings.MouseWheelStepValue = value
                End If
            End Set
        End Property

        Public Property MouseWheelDirection() As Integer Implements IClientSettings.MouseWheelDirection
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings.MouseWheelDirection
                End If
                Return 1
            End Get
            Set(value As Integer)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.ClientSettings.MouseWheelDirection = value
                End If
            End Set
        End Property

        Public Property MousePressAsRightButton() As Boolean Implements IClientSettings.MousePressAsRightButton
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings.MousePressAsRightButton
                End If
                Return False
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.ClientSettings.MousePressAsRightButton = value
                End If
            End Set
        End Property
    End Class

    '
    '     * *********************************************************************************************
    '     *  BrowserInfo
    '     * *********************************************************************************************
    '


    Public Class BrowserInfo
        Implements IBrowserInfo
        Implements IDisposable
        Private m_VirtualUI As IVirtualUI

        Public Sub New(virtualUI As IVirtualUI)
            m_VirtualUI = virtualUI
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_VirtualUI IsNot Nothing Then
                Marshal.ReleaseComObject(m_VirtualUI)
            End If
            m_VirtualUI = Nothing
        End Sub

        Public Property ViewWidth() As Integer Implements IBrowserInfo.ViewWidth
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.ViewWidth
                End If
                Return 0
            End Get
            Set(value As Integer)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.BrowserInfo.ViewWidth = value
                End If
            End Set
        End Property

        Public Property ViewHeight() As Integer Implements IBrowserInfo.ViewHeight
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.ViewHeight
                End If
                Return 0
            End Get
            Set(value As Integer)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.BrowserInfo.ViewHeight = value
                End If
            End Set
        End Property

        Public ReadOnly Property BrowserWidth() As Integer Implements IBrowserInfo.BrowserWidth
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.BrowserWidth
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property BrowserHeight() As Integer Implements IBrowserInfo.BrowserHeight
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.BrowserHeight
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property ScreenWidth() As Integer Implements IBrowserInfo.ScreenWidth
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.ScreenWidth
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property ScreenHeight() As Integer Implements IBrowserInfo.ScreenHeight
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.ScreenHeight
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property Username() As String Implements IBrowserInfo.Username
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.Username
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property IPAddress() As String Implements IBrowserInfo.IPAddress
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.IPAddress
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property UserAgent() As String Implements IBrowserInfo.UserAgent
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.UserAgent
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property UniqueBrowserId() As String Implements IBrowserInfo.UniqueBrowserId
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.UniqueBrowserId
                End If
                Return ""
            End Get
        End Property

        Public Property CustomData() As String Implements IBrowserInfo.CustomData
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.CustomData
                End If
                Return ""
            End Get
            Set(value As String)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.BrowserInfo.CustomData = value
                End If
            End Set
        End Property

        Public ReadOnly Property Location() As String Implements IBrowserInfo.Location
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.Location
                End If
                Return ""
            End Get
        End Property

        Public ReadOnly Property ScreenResolution() As Integer Implements IBrowserInfo.ScreenResolution
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.ScreenResolution
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property Orientation() As BrowserOrientation Implements IBrowserInfo.Orientation
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.Orientation
                End If
                Return 0
            End Get
        End Property

        Public Function GetCookie(Name As String) As String Implements IBrowserInfo.GetCookie
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.BrowserInfo.GetCookie(Name)
            End If
            Return ""
        End Function

        Public Sub SetCookie(Name As String, Value As String, Expires As String) Implements IBrowserInfo.SetCookie
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.BrowserInfo.SetCookie(Name, Value, Expires)
            End If
        End Sub

        ''' <summary>
        ''' \Returns the selected Browser Rule.
        ''' </summary>
        Public ReadOnly Property SelectedRule() As String Implements IBrowserInfo.SelectedRule
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.SelectedRule
                End If
                Return ""
            End Get
        End Property

        ''' <summary>
        ''' \Returns aditional data from Browser (JSON format).
        ''' </summary>
        Public ReadOnly Property ExtraData() As String Implements IBrowserInfo.ExtraData
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.BrowserInfo.ExtraData
                End If
                Return ""
            End Get
        End Property

        ''' <summary>
        ''' \Returns a specific value from ExtraData by it's name.
        ''' </summary>
        ''' <param name="Name">Name of value to return.</param>
        Public Function GetExtraDataValue(Name As String) As String Implements IBrowserInfo.GetExtraDataValue
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.BrowserInfo.GetExtraDataValue(Name)
            End If
            Return ""
        End Function
    End Class

    ''' <summary>
    ''' Contains properties to manage the VirtualUI Development
    ''' Server as well as the access from the developer's web
    ''' browser.
    ''' </summary>
    Public Class HTMLDoc
        Implements IHTMLDoc
        Implements IDisposable
        Private m_VirtualUI As IVirtualUI

        Public Sub New(virtualUI As IVirtualUI)
            m_VirtualUI = virtualUI
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_VirtualUI IsNot Nothing Then
                Marshal.ReleaseComObject(m_VirtualUI)
            End If
            m_VirtualUI = Nothing
        End Sub

        ''' <summary>
        '''   Inserts an HTML. Used to insert regular HTML elements or WebComponents with custom elements. 
        ''' </summary>
        Public Sub CreateComponent(Id As String, Html As String, ReplaceWnd As IntPtr) Implements IHTMLDoc.CreateComponent
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.HTMLDoc.CreateComponent(Id, Html, ReplaceWnd)
            End If
        End Sub

        ''' <summary>
        '''   Creates an url pointing to a local filename. This url is valid during the session lifetime and its private to this session.
        ''' </summary>
        Public Sub CreateSessionURL(url As String, filename As String) Implements IHTMLDoc.CreateSessionURL
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.HTMLDoc.CreateSessionURL(url, filename)
            End If
        End Sub

        ''' <summary>
        '''   Loads a script from url.
        ''' </summary>
        Public Sub LoadScript(url As String)
            LoadScript(url, "")
        End Sub

        ''' <summary>
        '''  Loads a script from URL. If Filename is specified, creates a session
        '''  URL first and then load the script from that Filename.
        ''' </summary>
        Public Sub LoadScript(url As String, filename As String) Implements IHTMLDoc.LoadScript
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.HTMLDoc.LoadScript(url, filename)
            End If
        End Sub

        ''' <summary>
        '''  Imports an HTML from URL. If Filename is specified, creates a session
        '''  URL first and then imports the html file from that Filename.
        ''' </summary>
        Public Sub ImportHTML(url As String)
            ImportHTML(url, "")
        End Sub

        ''' <summary>
        '''   Imports an HTML file from disk and assigns a session url.
        ''' </summary>
        Public Sub ImportHTML(url As String, filename As String) Implements IHTMLDoc.ImportHTML
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.HTMLDoc.ImportHTML(url, filename)
            End If
        End Sub

        ''' <summary>
        '''   Gets a safe, temporary and unique URL to access any file in the disk.
        ''' </summary>
        Public Function GetSafeUrl(filename As String) As String
            Return GetSafeUrl(filename, 60)
        End Function

        ''' <summary>
        '''   Gets a safe, temporary and unique URL to access any file in the disk.
        ''' </summary>
        Public Function GetSafeUrl(filename As String, minutes As Integer) As String Implements IHTMLDoc.GetSafeUrl
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.HTMLDoc.GetSafeUrl(filename, minutes)
            Else
                Return ""
            End If
        End Function

    End Class

    '
    '     * *********************************************************************************************
    '     *  DevServer
    '     * *********************************************************************************************
    '


    Public Class DevServer
        Implements IDevServer
        Implements IDisposable
        Private m_VirtualUI As IVirtualUI

        Public Sub New(virtualUI As IVirtualUI)
            m_VirtualUI = virtualUI
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_VirtualUI IsNot Nothing Then
                Marshal.ReleaseComObject(m_VirtualUI)
            End If
            m_VirtualUI = Nothing
        End Sub

        Public Property Enabled() As Boolean Implements IDevServer.Enabled
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.DevServer.Enabled
                End If
                Return False
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.DevServer.Enabled = value
                End If
            End Set
        End Property
        Public Property Port() As Integer Implements IDevServer.Port
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.DevServer.Port
                End If
                Return 0
            End Get
            Set(value As Integer)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.DevServer.Port = value
                End If
            End Set
        End Property
        Public Property StartBrowser() As Boolean Implements IDevServer.StartBrowser
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.DevServer.StartBrowser
                End If
                Return False
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.DevServer.StartBrowser = value
                End If
            End Set
        End Property
    End Class

    '
    '     * *********************************************************************************************
    '     *  VirtualUI
    '     * *********************************************************************************************
    '


    Public Class BrowserResizeEventArgs
        Inherits EventArgs
        Public Property Width() As Integer
            Get
                Return m_Width
            End Get
            Set(value As Integer)
                m_Width = value
            End Set
        End Property
        Private m_Width As Integer
        Public Property Height() As Integer
            Get
                Return m_Height
            End Get
            Set(value As Integer)
                m_Height = value
            End Set
        End Property
        Private m_Height As Integer
        Public Property ResizeMaximized() As Boolean
            Get
                Return m_ResizeMaximized
            End Get
            Set(value As Boolean)
                m_ResizeMaximized = value
            End Set
        End Property
        Private m_ResizeMaximized As Boolean
    End Class

    Public Class GetUploadDirEventArgs
        Inherits EventArgs
        Public Property Directory() As String
            Get
                Return m_Directory
            End Get
            Set(value As String)
                m_Directory = value
            End Set
        End Property
        Private m_Directory As String
        Public Property Handled() As Boolean
            Get
                Return m_Handled
            End Get
            Set(value As Boolean)
                m_Handled = value
            End Set
        End Property
        Private m_Handled As Boolean
    End Class

    Public Class DownloadEndArgs
        Inherits EventArgs
        Public Property Filename() As String
            Get
                Return m_Filename
            End Get
            Set(value As String)
                m_Filename = value
            End Set
        End Property
        Private m_Filename As String
    End Class

    Public Class UploadEndArgs
        Inherits EventArgs
        Public Property Filename() As String
            Get
                Return m_Filename
            End Get
            Set(value As String)
                m_Filename = value
            End Set
        End Property
        Private m_Filename As String
    End Class

    Public Class DragFileArgs
        Inherits EventArgs
        Public Property Action() As DragAction
            Get
                Return m_Action
            End Get
            Set(value As DragAction)
                m_Action = value
            End Set
        End Property
        Private m_Action As DragAction
        Public Property X() As Integer
            Get
                Return m_X
            End Get
            Set(value As Integer)
                m_X = value
            End Set
        End Property
        Private m_X As Integer
        Public Property Y() As Integer
            Get
                Return m_Y
            End Get
            Set(value As Integer)
                m_Y = value
            End Set
        End Property
        Private m_Y As Integer
        Public Property Filenames() As String
            Get
                Return m_Filenames
            End Get
            Set(value As String)
                m_Filenames = value
            End Set
        End Property
        Private m_Filenames As String
    End Class

    Public Class OnSaveDialogArgs
        Inherits EventArgs
        Public Property Filename() As String
            Get
                Return m_Filename
            End Get
            Set(value As String)
                m_Filename = value
            End Set
        End Property
        Private m_Filename As String
    End Class

    Public Class CloseArgs
        Inherits EventArgs
    End Class

    Public Class ReceiveMessageArgs
        Inherits EventArgs
        Public Property Data() As String
            Get
                Return m_Data
            End Get
            Set(value As String)
                m_Data = value
            End Set
        End Property
        Private m_Data As String
    End Class

    Public Class RecorderChangedArgs
        Inherits EventArgs
    End Class

    <ClassInterface(ClassInterfaceType.AutoDual), ComSourceInterfaces(GetType(IEvents))>
    Friend NotInheritable Class VirtualUISink
        Implements IEvents
#Region "VirtualUISink Members"
        Private m_VirtualUI As VirtualUI
        Public Sub OnGetUploadDir(ByRef Directory As String, ByRef Handled As Boolean) Implements IEvents.OnGetUploadDir
            m_VirtualUI.OnGetUploadDirEventHandler(Directory, Handled)
        End Sub
        Public Sub OnBrowserResize(ByRef Width As Integer, ByRef Height As Integer, ByRef ResizeMaximized As Boolean) Implements IEvents.OnBrowserResize
            m_VirtualUI.OnBrowserResizeEventHandler(Width, Height, ResizeMaximized)
        End Sub
        Public Sub OnClose() Implements IEvents.OnClose
            m_VirtualUI.OnCloseEventHandler()
        End Sub
        Public Sub OnReceiveMessage(Data As String) Implements IEvents.OnReceiveMessage
            m_VirtualUI.OnReceiveMessageEventHandler(Data)
        End Sub
        Public Sub OnDownloadEnd(Filename As String) Implements IEvents.OnDownloadEnd
            m_VirtualUI.OnDownloadEndEventHandler(Filename)
        End Sub
        Public Sub OnUploadEnd(Filename As String) Implements IEvents.OnUploadEnd
            m_VirtualUI.OnUploadEndEventHandler(Filename)
        End Sub
        Public Sub OnRecorderChanged() Implements IEvents.OnRecorderChanged
            m_VirtualUI.OnRecorderChangedEventHandler()
        End Sub
        Public Sub OnDragFile(Action As DragAction, X As Integer, Y As Integer, Filenames As String) Implements IEvents.OnDragFile
            m_VirtualUI.OnDragFileEventHandler(Action, X, Y, Filenames)
        End Sub
        Public Sub OnSaveDialog(Filename As String) Implements IEvents.OnSaveDialog
            m_VirtualUI.OnSaveDialogEventHandler(Filename)
        End Sub

#End Region

        Friend Sub New(virtualUI As VirtualUI)
            m_VirtualUI = virtualUI
        End Sub
    End Class

    Public Class VirtualUI
        Inherits VirtualUILibrary
        'Implements IVirtualUI
        Implements IDisposable
        <UnmanagedFunctionPointer(CallingConvention.StdCall)>
        Private Delegate Function funcGetInstance(ByRef vui As IVirtualUI) As Integer
        Private GetInstance As funcGetInstance

        Private Shared g_virtualUI As VirtualUI
        Private Shared g_virtualUIExists As Boolean

        Private m_VirtualUI As IVirtualUI
        Private m_BrowserInfo As IBrowserInfo
        Private m_DevServer As IDevServer
        Private m_HTMLDoc As HTMLDoc

        Private virtualUIEventSink As VirtualUISink
        Private connectionPointContainer As System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
        Private connectionPoint As System.Runtime.InteropServices.ComTypes.IConnectionPoint
        Private connectionCookie As Integer

        Public Sub New()
            MyBase.New()
            If Not g_virtualUIExists Then
                g_virtualUIExists = True
                g_virtualUI = New VirtualUI()
            End If
            If LibHandle <> IntPtr.Zero Then
                Dim pAddressOfFunctionToCall As IntPtr = GetProcAddress(LibHandle, "DllGetInstance")
                GetInstance = DirectCast(Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, GetType(funcGetInstance)), funcGetInstance)
                GetInstance(m_VirtualUI)

                If g_virtualUIExists AndAlso g_virtualUI IsNot Nothing Then
                    virtualUIEventSink = New VirtualUISink(Me)
                    connectionPointContainer = DirectCast(m_VirtualUI, System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)
                    Dim virtualUIEventsInterfaceId As Guid = GetType(IEvents).GUID
                    connectionPointContainer.FindConnectionPoint(virtualUIEventsInterfaceId, connectionPoint)
                    If connectionPoint IsNot Nothing Then
                        connectionPoint.Advise(DirectCast(virtualUIEventSink, IEvents), connectionCookie)
                    End If
                Else
                    virtualUIEventSink = New VirtualUISink(Me)
                    connectionPointContainer = DirectCast(m_VirtualUI, System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)
                    Dim virtualUIEventsInterfaceId As Guid = GetType(IEvents).GUID
                    connectionPointContainer.FindConnectionPoint(virtualUIEventsInterfaceId, connectionPoint)
                    If connectionPoint IsNot Nothing Then
                        connectionPoint.Advise(DirectCast(virtualUIEventSink, IEvents), connectionCookie)
                    End If
                End If
            End If
            m_BrowserInfo = New BrowserInfo(m_VirtualUI)
            m_DevServer = New DevServer(m_VirtualUI)
            m_HTMLDoc = New HTMLDoc(m_VirtualUI)
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_VirtualUI IsNot Nothing Then
                Marshal.ReleaseComObject(m_VirtualUI)
            End If
            If m_BrowserInfo IsNot Nothing Then
                DirectCast(m_BrowserInfo, IDisposable).Dispose()
            End If
            If m_DevServer IsNot Nothing Then
                DirectCast(m_DevServer, IDisposable).Dispose()
            End If
            m_VirtualUI = Nothing
            m_BrowserInfo = Nothing
            m_DevServer = Nothing
        End Sub

        Public Function Start() As Boolean
            Return Start(60000)
        End Function

        Public Function Start(timeout As Integer) As Boolean 'Implements IVirtualUI.Start
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.Start(timeout)
            End If
            Return False
        End Function

        Public Sub [Stop]() 'Implements IVirtualUI.[Stop]
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.[Stop]()
            End If
        End Sub

        Public Sub DownloadFile(LocalFilename As String) 'Implements IVirtualUI.DownloadFile
            DownloadFile(LocalFilename, "", "")
        End Sub

        Public Sub DownloadFile(LocalFilename As String, RemoteFilename As String) 'Implements IVirtualUI.DownloadFile
            DownloadFile(LocalFilename, RemoteFilename, "")
        End Sub

        Public Sub DownloadFile(LocalFilename As String, RemoteFilename As String, MimeType As String) 'Implements IVirtualUI.DownloadFile
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.DownloadFile(LocalFilename, RemoteFilename, MimeType)
            End If
        End Sub

        Public Sub UploadFile() 'Implements IVirtualUI.UploadFile
            UploadFile("")
        End Sub

        Public Sub UploadFile(ServerDirectory As String) 'Implements IVirtualUI.UploadFile
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.UploadFile(ServerDirectory)
            End If
        End Sub

        Public Function UploadFileEx(FileName As String) As Boolean 'Implements IVirtualUI.UploadFileEx
            Return UploadFileEx("", FileName)
        End Function

        Public Function UploadFileEx(ServerDirectory As String, FileName As String) As Boolean 'Implements IVirtualUI.UploadFileEx
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.UploadFileEx(ServerDirectory, FileName)
            End If
            Return False
        End Function

        Public Sub Suspend() 'Implements IVirtualUI.Suspend
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.Suspend()
            End If
        End Sub

        Public Sub Resume_() 'Implements IVirtualUI.Resume
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.Resume()
            End If
        End Sub

        Public Function FlushWindow(Wnd As Long) As Boolean 'Implements IVirtualUI.FlushWindow
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.FlushWindow(Wnd)
            End If
            Return False
        End Function

        Public Function TakeScreenshot(Wnd As Long, FileName As String) As Boolean 'Implements IVirtualUI.TakeScreenshot
            If m_VirtualUI IsNot Nothing Then
                Return m_VirtualUI.TakeScreenshot(Wnd, FileName)
            End If
            Return False
        End Function

        Public Sub ShowVirtualKeyboard() 'Implements IVirtualUI.ShowVirtualKeyboard
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.ShowVirtualKeyboard()
            End If
        End Sub

        Public Sub PrintPdf(FileName As String) 'Implements IVirtualUI.PrintPdf
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.PrintPdf(FileName)
            End If
        End Sub

        Public Sub PreviewPdf(FileName As String) 'Implements IVirtualUI.PreviewPdf
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.PreviewPdf(FileName)
            End If
        End Sub

        Public Sub OpenLinkDlg(Url As String, Caption As String) 'Implements IVirtualUI.OpenLinkDlg
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.OpenLinkDlg(Url, Caption)
            End If
        End Sub

        Public Sub SendMessage(Data As String) 'Implements IVirtualUI.SendMessage
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.SendMessage(Data)
            End If
        End Sub

        Public Sub AllowExecute(Filename As String) 'Implements IVirtualUI.AllowExecute
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.AllowExecute(Filename)
            End If
        End Sub

        Public Sub SetImageQualityByWnd(Wnd As Long, Classname As String, Quality As Integer) 'Implements IVirtualUI.SetImageQualityByWnd
            If m_VirtualUI IsNot Nothing Then
                m_VirtualUI.SetImageQualityByWnd(Wnd, Classname, Quality)
            End If
        End Sub

        Public ReadOnly Property Active() As Boolean 'Implements IVirtualUI.Active
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.Active
                Else
                    Return False
                End If
            End Get
        End Property

        Public Property Enabled() As Boolean 'Implements IVirtualUI.Enabled
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.Enabled
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.Enabled = value
                End If
            End Set
        End Property

        Public Property DevMode() As Boolean 'Implements IVirtualUI.DevMode
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.DevMode
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.DevMode = value
                End If
            End Set
        End Property

        Public Property StdDialogs() As Boolean 'Implements IVirtualUI.StdDialogs
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.StdDialogs
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.StdDialogs = value
                End If
            End Set
        End Property

        Public Property Options As UInteger 'Implements IVirtualUI.Options
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.Options
                Else
                    Return False
                End If
            End Get
            Set(value As UInteger)
                If m_VirtualUI IsNot Nothing Then
                    m_VirtualUI.Options = value
                End If
            End Set
        End Property

        Public ReadOnly Property BrowserInfo() As IBrowserInfo 'Implements IVirtualUI.BrowserInfo
            Get
                Return DirectCast(m_BrowserInfo, IBrowserInfo)
            End Get
        End Property

        ' <summary>
        '   Contains methods to modify the behavior on the HTML page.
        ' </summary>

        Public ReadOnly Property HTMLDoc() As HTMLDoc
            Get
                Return m_HTMLDoc
            End Get
        End Property

        Public ReadOnly Property DevServer() As IDevServer 'Implements IVirtualUI.DevServer
            Get
                Return DirectCast(m_DevServer, IDevServer)
            End Get
        End Property

        Public ReadOnly Property ClientSettings() As IClientSettings 'Implements IVirtualUI.ClientSettings
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.ClientSettings
                End If
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property Recorder() As IRecorder 'Implements IVirtualUI.Recorder
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.Recorder
                End If
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property FileSystemFilter() As IFileSystemFilter 'Implements IVirtualUI.FileSystemFilter
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.FileSystemFilter
                End If
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property RegistryFilter() As IRegistryFilter 'Implements IVirtualUI.RegistryFilter
            Get
                If m_VirtualUI IsNot Nothing Then
                    Return m_VirtualUI.RegistryFilter
                End If
                Return Nothing
            End Get
        End Property

        Private m_Events As EventHandlerList = Nothing
        Protected ReadOnly Property Events() As EventHandlerList
            Get
                If m_Events Is Nothing Then
                    m_Events = New EventHandlerList()
                End If
                Return m_Events
            End Get
        End Property

        'Private Event m_OnBrowserResize As EventHandler(Of BrowserResizeEventArgs)
        Public Custom Event OnBrowserResize As EventHandler(Of BrowserResizeEventArgs)
            AddHandler(ByVal value As EventHandler(Of BrowserResizeEventArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnBrowserResize", value)
                    Return
                End If
                Me.Events.AddHandler("OnBrowserResize", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of BrowserResizeEventArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnBrowserResize", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnBrowserResize", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As BrowserResizeEventArgs)
                If Not IsNothing(Me.Events("OnBrowserResize")) Then
                    CType(Me.Events("OnBrowserResize"), EventHandler(Of BrowserResizeEventArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnGetUploadDir As EventHandler(Of GetUploadDirEventArgs)
            AddHandler(ByVal value As EventHandler(Of GetUploadDirEventArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnGetUploadDir", value)
                    Return
                End If
                Me.Events.AddHandler("OnGetUploadDir", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of GetUploadDirEventArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnGetUploadDir", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnGetUploadDir", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As GetUploadDirEventArgs)
                If Not IsNothing(Me.Events("OnGetUploadDir")) Then
                    CType(Me.Events("OnGetUploadDir"), EventHandler(Of GetUploadDirEventArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnClose As EventHandler(Of CloseArgs)
            AddHandler(ByVal value As EventHandler(Of CloseArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnClose", value)
                    Return
                End If
                Me.Events.AddHandler("OnClose", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of CloseArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnClose", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnClose", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As CloseArgs)
                If Not IsNothing(Me.Events("OnClose")) Then
                    CType(Me.Events("OnClose"), EventHandler(Of CloseArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnReceiveMessage As EventHandler(Of ReceiveMessageArgs)
            AddHandler(ByVal value As EventHandler(Of ReceiveMessageArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnReceiveMessage", value)
                    Return
                End If
                Me.Events.AddHandler("OnReceiveMessage", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of ReceiveMessageArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnReceiveMessage", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnReceiveMessage", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As ReceiveMessageArgs)
                If Not IsNothing(Me.Events("OnReceiveMessage")) Then
                    CType(Me.Events("OnReceiveMessage"), EventHandler(Of ReceiveMessageArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnDownloadEnd As EventHandler(Of DownloadEndArgs)
            AddHandler(ByVal value As EventHandler(Of DownloadEndArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnDownloadEnd", value)
                    Return
                End If
                Me.Events.AddHandler("OnDownloadEnd", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of DownloadEndArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnDownloadEnd", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnDownloadEnd", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As DownloadEndArgs)
                If Not IsNothing(Me.Events("OnDownloadEnd")) Then
                    CType(Me.Events("OnDownloadEnd"), EventHandler(Of DownloadEndArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnUploadEnd As EventHandler(Of UploadEndArgs)
            AddHandler(ByVal value As EventHandler(Of UploadEndArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnUploadEnd", value)
                    Return
                End If
                Me.Events.AddHandler("OnUploadEnd", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of UploadEndArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnUploadEnd", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnUploadEnd", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As UploadEndArgs)
                If Not IsNothing(Me.Events("OnUploadEnd")) Then
                    CType(Me.Events("OnUploadEnd"), EventHandler(Of UploadEndArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnSaveDialog As EventHandler(Of OnSaveDialogArgs)
            AddHandler(ByVal value As EventHandler(Of OnSaveDialogArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnSaveDialog", value)
                    Return
                End If
                Me.Events.AddHandler("OnSaveDialog", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of OnSaveDialogArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnSaveDialog", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnSaveDialog", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As OnSaveDialogArgs)
                If Not IsNothing(Me.Events("OnSaveDialog")) Then
                    CType(Me.Events("OnSaveDialog"), EventHandler(Of OnSaveDialogArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnRecorderChanged As EventHandler(Of RecorderChangedArgs)
            AddHandler(ByVal value As EventHandler(Of RecorderChangedArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnRecorderChanged", value)
                    Return
                End If
                Me.Events.AddHandler("OnRecorderChanged", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of RecorderChangedArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnRecorderChanged", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnRecorderChanged", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As RecorderChangedArgs)
                If Not IsNothing(Me.Events("OnRecorderChanged")) Then
                    CType(Me.Events("OnRecorderChanged"), EventHandler(Of RecorderChangedArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Public Custom Event OnDragFile As EventHandler(Of DragFileArgs)
            AddHandler(ByVal value As EventHandler(Of DragFileArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.AddHandler("OnDragFile", value)
                    Return
                End If
                Me.Events.AddHandler("OnDragFile", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of DragFileArgs))
                If Not Me.Equals(g_virtualUI) Then
                    g_virtualUI.Events.RemoveHandler("OnDragFile", value)
                    Return
                End If
                Me.Events.RemoveHandler("OnDragFile", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal args As DragFileArgs)
                If Not IsNothing(Me.Events("OnDragFile")) Then
                    CType(Me.Events("OnDragFile"), EventHandler(Of DragFileArgs)).Invoke(sender, args)
                End If
            End RaiseEvent
        End Event

        Friend Sub OnBrowserResizeEventHandler(ByRef Width As Integer, ByRef Height As Integer, ByRef ResizeMaximized As Boolean)
            Dim args As New BrowserResizeEventArgs()
            args.Width = Width
            args.Height = Height
            args.ResizeMaximized = ResizeMaximized
            RaiseEvent OnBrowserResize(Me, args)
            Width = args.Width
            Height = args.Height
            ResizeMaximized = args.ResizeMaximized
        End Sub

        Friend Sub OnGetUploadDirEventHandler(ByRef Directory As String, ByRef Handled As Boolean)
            Dim args As New GetUploadDirEventArgs()
            args.Directory = Directory
            args.Handled = Handled
            RaiseEvent OnGetUploadDir(Me, args)
            Directory = args.Directory
            Handled = args.Handled
        End Sub

        Friend Sub OnCloseEventHandler()
            Dim args As New CloseArgs()
            RaiseEvent OnClose(Me, args)
        End Sub

        Friend Sub OnReceiveMessageEventHandler(Data As String)
            Dim args As New ReceiveMessageArgs()
            args.Data = Data
            RaiseEvent OnReceiveMessage(Me, args)
        End Sub

        Friend Sub OnDownloadEndEventHandler(Filename As String)
            Dim args As New DownloadEndArgs()
            args.Filename = Filename
            RaiseEvent OnDownloadEnd(Me, args)
        End Sub

        Friend Sub OnUploadEndEventHandler(Filename As String)
            Dim args As New UploadEndArgs()
            args.Filename = Filename
            RaiseEvent OnUploadEnd(Me, args)
        End Sub

        Friend Sub OnRecorderChangedEventHandler()
            Dim args As New RecorderChangedArgs()
            RaiseEvent OnRecorderChanged(Me, args)
        End Sub

        Friend Sub OnSaveDialogEventHandler(Filename As String)
            Dim args As New OnSaveDialogArgs()
            args.Filename = Filename
            RaiseEvent OnSaveDialog(Me, args)
        End Sub

        Friend Sub OnDragFileEventHandler(Action As DragAction, X As Integer, Y As Integer, Filenames As String)
            Dim args As New DragFileArgs()
            args.Action = Action
            args.X = X
            args.Y = Y
            args.Filenames = Filenames
            RaiseEvent OnDragFile(Me, args)
        End Sub
    End Class

    '
    '     * *********************************************************************************************
    '     *  JSObject
    '     * *********************************************************************************************
    '


    Public Class JSExecuteMethodEventArgs
        Inherits EventArgs
        Public Property Sender() As IJSObject
            Get
                Return m_Sender
            End Get
            Set(value As IJSObject)
                m_Sender = value
            End Set
        End Property
        Private m_Sender As IJSObject
        Public Property Method() As IJSMethod
            Get
                Return m_Method
            End Get
            Set(value As IJSMethod)
                m_Method = value
            End Set
        End Property
        Private m_Method As IJSMethod
    End Class

    Public Class JSPropertyChangeEventArgs
        Inherits EventArgs
        Public Property Sender() As IJSObject
            Get
                Return m_Sender
            End Get
            Set(value As IJSObject)
                m_Sender = value
            End Set
        End Property
        Private m_Sender As IJSObject
        Public Property Prop() As IJSProperty
            Get
                Return m_Prop
            End Get
            Set(value As IJSProperty)
                m_Prop = value
            End Set
        End Property
        Private m_Prop As IJSProperty
    End Class

    <ClassInterface(ClassInterfaceType.AutoDual), ComSourceInterfaces(GetType(IJSObjectEvents))> _
    Friend NotInheritable Class JSObjectSink
        Implements IJSObjectEvents
#Region "JSObjectSink Members"
        Private m_JSObject As JSObject
        Public Sub OnExecuteMethod(Sender As IJSObject, Method As IJSMethod) Implements IJSObjectEvents.OnExecuteMethod
            m_JSObject.OnExecuteMethodEventHandler(Sender, Method)
        End Sub
        Public Sub OnPropertyChange(Sender As IJSObject, Prop As IJSProperty) Implements IJSObjectEvents.OnPropertyChange
            m_JSObject.OnOnPropertyChangeEventHandler(Sender, Prop)
        End Sub
#End Region

        Friend Sub New(jsObject As JSObject)
            m_JSObject = jsObject
        End Sub
    End Class

    Public Class JSObject
        Inherits VirtualUILibrary
        Implements IJSObject
        Implements IDisposable
        <UnmanagedFunctionPointer(CallingConvention.StdCall)> _
        Private Delegate Function funcDllCreateJSObject(ByRef obj As IJSObject) As Integer
        Private DllCreateJSObject As funcDllCreateJSObject
        Private m_JSObject As IJSObject

        Private jsObjectEventSink As JSObjectSink
        Private connectionPointContainer As System.Runtime.InteropServices.ComTypes.IConnectionPointContainer
        Private connectionPoint As System.Runtime.InteropServices.ComTypes.IConnectionPoint
        Private connectionCookie As Integer

        Public Sub New(Id As String)
            MyBase.New()
            If LibHandle <> IntPtr.Zero Then
                Dim pAddressOfFunctionToCall As IntPtr = GetProcAddress(LibHandle, "DllCreateJSObject")
                DllCreateJSObject = DirectCast(Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, GetType(funcDllCreateJSObject)), funcDllCreateJSObject)
                DllCreateJSObject(m_JSObject)

                jsObjectEventSink = New JSObjectSink(Me)
                connectionPointContainer = DirectCast(m_JSObject, System.Runtime.InteropServices.ComTypes.IConnectionPointContainer)
                Dim virtualUIEventsInterfaceId As Guid = GetType(IJSObjectEvents).GUID
                connectionPointContainer.FindConnectionPoint(virtualUIEventsInterfaceId, connectionPoint)
                If connectionPoint IsNot Nothing Then
                    connectionPoint.Advise(DirectCast(jsObjectEventSink, IJSObjectEvents), connectionCookie)
                End If
            End If
            Me.Id = Id
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            If connectionPoint IsNot Nothing Then
                'connectionPoint.Unadvise(connectionCookie);
                Try
                Catch generatedExceptionName As Exception
                End Try
                connectionPoint = Nothing
                connectionCookie = 0
            End If
            If m_JSObject IsNot Nothing Then
                Marshal.ReleaseComObject(m_JSObject)
            End If
            m_JSObject = Nothing
        End Sub

        Public Sub FireEvent(Name As String, Arguments As IJSArguments) Implements IJSObject.FireEvent
            If m_JSObject IsNot Nothing Then
                m_JSObject.FireEvent(Name, Arguments)
            End If
        End Sub

        Public Sub ApplyChanges() Implements IJSObject.ApplyChanges
            If m_JSObject IsNot Nothing Then
                m_JSObject.ApplyChanges()
            End If
        End Sub

        Public Sub ApplyModel() Implements IJSObject.ApplyModel
            If m_JSObject IsNot Nothing Then
                m_JSObject.ApplyModel()
            End If
        End Sub

        Public Property Id() As String Implements IJSObject.Id
            Get
                If m_JSObject IsNot Nothing Then
                    Return m_JSObject.Id
                End If
                Return ""
            End Get
            Set(value As String)
                If m_JSObject IsNot Nothing Then
                    m_JSObject.Id = value
                End If
            End Set
        End Property

        Public ReadOnly Property Properties() As IJSProperties Implements IJSObject.Properties
            Get
                If m_JSObject IsNot Nothing Then
                    Return m_JSObject.Properties
                End If
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property Methods() As IJSMethods Implements IJSObject.Methods
            Get
                If m_JSObject IsNot Nothing Then
                    Return m_JSObject.Methods
                End If
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property Events() As IJSEvents Implements IJSObject.Events
            Get
                If m_JSObject IsNot Nothing Then
                    Return m_JSObject.Events
                End If
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property Objects() As IJSObjects Implements IJSObject.Objects
            Get
                If m_JSObject IsNot Nothing Then
                    Return m_JSObject.Objects
                End If
                Return Nothing
            End Get
        End Property

        Public Event OnExecuteMethod As EventHandler(Of JSExecuteMethodEventArgs) Implements IJSObject.OnExecuteMethod
        Public Event OnPropertyChange As EventHandler(Of JSPropertyChangeEventArgs) Implements IJSObject.OnPropertyChange

        Friend Sub OnExecuteMethodEventHandler(Sender As IJSObject, Method As IJSMethod)
            Dim args As New JSExecuteMethodEventArgs()
            args.Sender = Sender
            args.Method = Method
            RaiseEvent OnExecuteMethod(Me, args)
        End Sub

        Friend Sub OnOnPropertyChangeEventHandler(Sender As IJSObject, Prop As IJSProperty)
            Dim args As New JSPropertyChangeEventArgs()
            args.Sender = Sender
            args.Prop = Prop
            RaiseEvent OnPropertyChange(Me, args)
        End Sub
    End Class

    '
    '     * *********************************************************************************************
    '     *  JSBinding
    '     * *********************************************************************************************
    '

    Public Delegate Sub JSPropertySet(Parent As IJSObject, Prop As IJSProperty)

    <ComVisible(True), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(GetType(IJSBinding))> _
    Public Class JSBinding
        Implements IJSBinding
        Implements IDisposable
        Private m_Proc As JSPropertySet

        Public Sub New(Proc As JSPropertySet)
            m_Proc = Proc
        End Sub
        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub

        Public Sub [Set](Parent As IJSObject, Prop As IJSProperty) Implements IJSBinding.[Set]
            If (Not (m_Proc) Is Nothing) Then
                m_Proc(Parent, Prop)
            End If
        End Sub
    End Class

    '
    '     * *********************************************************************************************
    '     *  JSCallback
    '     * *********************************************************************************************
    '

    Public Delegate Sub JSMethodCallback(Parent As IJSObject, Method As IJSMethod)

    <ComVisible(True), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(GetType(IJSCallback))> _
    Public Class JSCallback
        Implements IJSCallback
        Implements IDisposable
        Private m_Proc As JSMethodCallback

        Public Sub New(Proc As JSMethodCallback)
            m_Proc = Proc
        End Sub
        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub

        Public Sub Callback(Parent As IJSObject, Method As IJSMethod) Implements IJSCallback.Callback
            If (Not (m_Proc) Is Nothing) Then
                m_Proc(Parent, Method)
            End If
        End Sub
    End Class
End Namespace
