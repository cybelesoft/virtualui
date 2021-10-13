Public Class MainForm
    Private remotePrinter As Cybele.Thinfinity.RemotePrinter
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        remotePrinter = New Cybele.Thinfinity.RemotePrinter()
    End Sub

    Private Sub LBoxPrinters_SelectedValueChanged(sender As Object, e As EventArgs) Handles LBoxPrinters.SelectedValueChanged

        txtPrinterName.Text = LBoxPrinters.SelectedItem.ToString()

    End Sub

    Private Sub BtnGetPrinters_Click(sender As Object, e As EventArgs) Handles BtnGetPrinters.Click
        Dim errCode As Integer = 0
        Dim errMsg As String = String.Empty
        Dim printers As String = String.Empty

        If Not remotePrinter.GetPrinters(";", printers) Then

            remotePrinter.LastError(errCode, errMsg)
            MessageBox.Show(errMsg)
            Return
        End If

        Dim elements() As String = printers.Split(";")
        LBoxPrinters.Items.Clear()
        For Each element As String In elements
            LBoxPrinters.Items.Add(element)
        Next
    End Sub

    Private Sub BtnPrintDoc_Click(sender As Object, e As EventArgs) Handles BtnPrintDoc.Click
        Dim Printing As Boolean = False
        Dim Done As Boolean = False
        Dim ErrMsg As String = String.Empty
        Dim ErrCode As Integer = 0
        Dim DocID As String = String.Empty

        If remotePrinter.BeginDoc(CInt(Cybele.Thinfinity.PrintType.PRINT_TYPE_RAW),
                                  txtPrinterName.Text, txtDocTitle.Text,
                                  CInt(Cybele.Thinfinity.Encode.PRINT_ENCODE_UTF8), DocID) Then
            Printing = True
            If remotePrinter.Print(DocID, txtData.Text) Then
                If remotePrinter.EndDoc(DocID) Then
                    Done = True
                    Printing = False
                    MessageBox.Show("done.")
                End If
            End If
        End If

        If Not Done Then
            remotePrinter.LastError(ErrCode, ErrMsg)
            MessageBox.Show(ErrMsg)
        End If

        If Printing Then
            If Not remotePrinter.Abort(DocID) Then
                remotePrinter.LastError(ErrCode, ErrMsg)
                MessageBox.Show(ErrMsg)
            End If
        End If

    End Sub
End Class
