Imports System.Net
Imports System.Text.Json

Public Class Form1


    Private Vui As Cybele.Thinfinity.VirtualUI
    Dim cm As ClipboardMessage
    Private serializedCM As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Vui = New Cybele.Thinfinity.VirtualUI()
        Vui.Start(60)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Clipboard.SetText(TextBox1.Text)

        cm = New ClipboardMessage()
        cm.Action = "copy"
        cm.Type = "text/plain"
        cm.Text = TextBox1.Text

        serializedCM = JsonSerializer.Serialize(cm)

        Vui.SendMessage(serializedCM)



    End Sub
End Class

Public Class ClipboardMessage

    Public Property Action() As String
    Public Property Type() As String
    Public Property Text() As String

End Class