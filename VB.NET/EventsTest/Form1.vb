Imports System.IO
Imports System.Reflection

Public Class Form1
    Private Vui As Cybele.Thinfinity.VirtualUI

    Private AppPath As String
    Private m_TestDir As String
    Private m_LogfileName As String

    Private Sub PrepareTestDir()
        m_TestDir = Path.Combine(AppPath, "test_" + Process.GetCurrentProcess.Id.ToString())
        LblTestDir.Text = "Test directory: " + m_TestDir

        ' Create test directory:
        Directory.CreateDirectory(m_TestDir)

        ' Create subdir for uploads:
        Directory.CreateDirectory(Path.Combine(m_TestDir, "Uploads"))

        ' Create text file to be downloaded:
        Dim file As StreamWriter = New StreamWriter(Path.Combine(m_TestDir, "test.txt"))
        file.WriteLine("File to download by PID " + Process.GetCurrentProcess.Id.ToString())
        file.Close()
    End Sub

    Private Sub RemoveTestDir()
        If (Not String.IsNullOrEmpty(m_TestDir)) Then
            Directory.Delete(m_TestDir, True)
        End If
    End Sub

    Private Sub Log(data As String)
        TxtLog.AppendText(data + vbCrLf)
        If (CheckSaveLog.Checked) Then
            Dim file As StreamWriter = New StreamWriter(m_LogfileName, True)
            file.WriteLine(data)
            file.Close()
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
        If (AppPath.StartsWith("file:")) Then
            AppPath = AppPath.Substring(6)
        End If

        Vui = New Cybele.Thinfinity.VirtualUI()
        Vui.Start(60)
        AddHandler Vui.OnDownloadEnd, AddressOf Vui_OnDownloadEnd
        AddHandler Vui.OnUploadEnd, AddressOf Vui_OnUploadEnd
        AddHandler Vui.OnGetUploadDir, AddressOf Vui_OnGetUploadDir
        AddHandler Vui.OnClose, AddressOf Vui_OnClose
        AddHandler Vui.OnBrowserResize, AddressOf Vui_OnBrowserResize
        AddHandler Vui.OnReceiveMessage, AddressOf Vui_OnReceiveMessage
        AddHandler Vui.OnDragFile, AddressOf Vui_OnDragFile
        AddHandler Vui.OnDragFile2, AddressOf Vui_OnDragFile2
        AddHandler Vui.OnDropFile, AddressOf Vui_OnDropFile

        ' Currently not tested on this app:
        AddHandler Vui.OnRecorderChanged, AddressOf Vui_OnRecorderChanged
        AddHandler Vui.OnSaveDialog, AddressOf Vui_OnSaveDialog

        PrepareTestDir()
        m_LogfileName = Path.Combine(AppPath, String.Format("VirtualUI_Events_{0}.txt", Process.GetCurrentProcess.Id))
        CheckSaveLog.Text = "Save log to " + Path.GetFileName(m_LogfileName)
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If (CheckRemoveTestDir.Checked) Then
            RemoveTestDir()
        End If
    End Sub

    Private Sub ButtonDownload_Click(sender As Object, e As EventArgs) Handles ButtonDownload.Click
        Vui.DownloadFile(Path.Combine(m_TestDir, "test.txt"))
    End Sub

    Private Sub ButtonUpload_Click(sender As Object, e As EventArgs) Handles ButtonUpload.Click
        Vui.UploadFile()
    End Sub


    Private Sub Vui_OnBrowserResize(sender As Object, e As Cybele.Thinfinity.BrowserResizeEventArgs)
        Log(String.Format("OnBrowserResize: {0}x{1}", e.Width, e.Height))
    End Sub

    Private Sub Vui_OnClose(Sender As Object, e As Cybele.Thinfinity.CloseArgs)
        Log("OnClose")
        Close()
    End Sub

    Private Sub Vui_OnDownloadEnd(Sender As Object, e As Cybele.Thinfinity.DownloadEndArgs)
        Log("OnDownloadEnd: " + e.Filename)
    End Sub

    Private Sub Vui_OnGetUploadDir(Sender As Object, e As Cybele.Thinfinity.GetUploadDirEventArgs)
        e.Directory = Path.Combine(m_TestDir, "Uploads")
        e.Handled = True
        Log("OnGetUploadDir: Set " + e.Directory)
    End Sub

    Private Sub Vui_OnUploadEnd(Sender As Object, e As Cybele.Thinfinity.UploadEndArgs)
        Log("OnUploadEnd: " + e.Filename)
    End Sub

    Private Sub Vui_OnSaveDialog(Sender As Object, e As Cybele.Thinfinity.OnSaveDialogArgs)
        Log("OnSaveDialog: " + e.Filename)
    End Sub

    Private Sub Vui_OnDragFile(Sender As Object, e As Cybele.Thinfinity.DragFileArgs)
        ' Using OnDragFile2
    End Sub

    Private Sub Vui_OnDragFile2(Sender As Object, e As Cybele.Thinfinity.DragFile2Args)
        Dim actionStr As String = "Unknown"
        Select Case e.Action
            Case Cybele.Thinfinity.DragAction.DRAG_Start
                actionStr = "Start"
            Case Cybele.Thinfinity.DragAction.DRAG_Over
                actionStr = "Over"
            Case Cybele.Thinfinity.DragAction.DRAG_Drop
                actionStr = "Drop"
            Case Cybele.Thinfinity.DragAction.DRAG_Error
                actionStr = "Error"
            Case Cybele.Thinfinity.DragAction.DRAG_Cancel
                actionStr = "Cancel"
        End Select

        Dim eventData As String = String.Format("{0} on {1}.{2}", actionStr, e.ScreenX, e.ScreenY)
        If (Not String.IsNullOrEmpty(e.Filenames)) Then
            eventData = eventData + " (Files: " + e.Filenames + ")"
        End If
        Log("OnDragFile2:" + eventData)

        e.Accept = True
    End Sub

    Private Sub Vui_OnDropFile(Sender As Object, e As Cybele.Thinfinity.DropFileArgs)
        Dim eventData As String = String.Format("{0}.{1}", e.ScreenX, e.ScreenY)
        If (Not String.IsNullOrEmpty(e.Filenames)) Then
            eventData = eventData + " (Files: " + e.Filenames + ")"
        End If
        If (Not String.IsNullOrEmpty(e.FileSizes)) Then
            eventData = eventData + " (Sizes: " + e.FileSizes + ")"
        End If
        Log("OnDropFile: " + eventData)

        'TODO: Test IgnoreFiles (Set in the form: "ignore1.txt|ignore2.log|ignoreN.exe")
        Vui.UploadFile()
    End Sub

    Private Sub Vui_OnReceiveMessage(Sender As Object, e As Cybele.Thinfinity.ReceiveMessageArgs)
        Log("OnReceiveMessage: " + e.Data)
    End Sub

    Private Sub Vui_OnRecorderChanged(Sender As Object, e As Cybele.Thinfinity.RecorderChangedArgs)
        Log("OnRecorderChanged")
    End Sub
End Class
