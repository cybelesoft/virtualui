Imports System.IO

Public Class MainForm
    Private vui As Cybele.Thinfinity.VirtualUI
    Private remotePrinter As Cybele.Thinfinity.RemotePrinter
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vui = New Cybele.Thinfinity.VirtualUI()
        vui.StdDialogs = True
        vui.Start()
        remotePrinter = New Cybele.Thinfinity.RemotePrinter()
    End Sub

    Private Sub btnOpenXps_Click(sender As Object, e As EventArgs) Handles btnOpenXps.Click
        openFilesDialog.Title = "Select a XPS File"
        openFilesDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
        openFilesDialog.Filter = "Xps files (*.xps)|*.xps|Oxps files(*.oxps)|*.oxps|All files (*.*)|*.*"
        openFilesDialog.FilterIndex = 1
        openFilesDialog.DefaultExt = "xps"
        openFilesDialog.CheckFileExists = True
        If (openFilesDialog.ShowDialog() = DialogResult.OK) Then
            txtFileNameXps.Text = openFilesDialog.FileName
        End If
    End Sub

    Private Sub btnOpenPdf_Click(sender As Object, e As EventArgs) Handles btnOpenPdf.Click
        openFilesDialog.Title = "Select a PDF File"
        openFilesDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
        openFilesDialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*"
        openFilesDialog.FilterIndex = 1
        openFilesDialog.DefaultExt = "pdf"
        openFilesDialog.CheckFileExists = True
        If (openFilesDialog.ShowDialog() = DialogResult.OK) Then
            txtFileNamePdf.Text = openFilesDialog.FileName
        End If
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        openFilesDialog.Title = "Select a RAW File"
        openFilesDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
        openFilesDialog.Filter = "All files (*.*)|*.*"
        openFilesDialog.FilterIndex = 1
        openFilesDialog.CheckFileExists = True
        If (openFilesDialog.ShowDialog() = DialogResult.OK) Then
            txtFileName.Text = openFilesDialog.FileName
        End If
    End Sub

    Function CheckFileExists(FileName As String) As Boolean

        If Not File.Exists(FileName) Then
            MessageBox.Show(String.Format("File {0} does not exist", Path.GetFileName(FileName)),
                    "Loading File...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub btnPrintXps_Click(sender As Object, e As EventArgs) Handles btnPrintXps.Click
        Dim ErrMsg As String = String.Empty
        Dim ErrCode As Integer = 0

        If (Not CheckFileExists(txtFileNameXps.Text)) Then
            Return
        End If

        If (Not remotePrinter.PrintFile(CInt(Cybele.Thinfinity.PrintType.PRINT_TYPE_XPS), txtFileNameXps.Text, String.Empty)) Then
            remotePrinter.LastError(ErrCode, ErrMsg)
            MessageBox.Show(ErrMsg)
        Else
            MessageBox.Show("done.")
        End If
    End Sub

    Private Sub btnPrintPdf_Click(sender As Object, e As EventArgs) Handles btnPrintPdf.Click
        Dim ErrMsg As String = String.Empty
        Dim ErrCode As Integer = 0

        If (Not CheckFileExists(txtFileNamePdf.Text)) Then
            Return
        End If

        If (Not remotePrinter.PrintFile(CInt(Cybele.Thinfinity.PrintType.PRINT_TYPE_PDF), txtFileNamePdf.Text, String.Empty)) Then
            remotePrinter.LastError(ErrCode, ErrMsg)
            MessageBox.Show(ErrMsg)
        Else
            MessageBox.Show("done.")
        End If
    End Sub

    Private Sub btnPrintDirect_Click(sender As Object, e As EventArgs) Handles btnPrintDirect.Click
        Dim ErrMsg As String = String.Empty
        Dim ErrCode As Integer = 0

        If (Not CheckFileExists(txtFileName.Text)) Then
            Return
        End If

        If (Not remotePrinter.PrintFile(CInt(Cybele.Thinfinity.PrintType.PRINT_TYPE_DIRECT), txtFileName.Text, String.Empty)) Then
            remotePrinter.LastError(ErrCode, ErrMsg)
            MessageBox.Show(ErrMsg)
        Else
            MessageBox.Show("done.")
        End If
    End Sub
End Class
