Imports System.Windows.Forms
Imports System.IO
Public Class Form1
    Inherits Form
#Region "DECLARATIONS AND VARIABLES"
    Private vui As Cybele.Thinfinity.VirtualUI
    Private xvideo1 As Cybele.Thinfinity.JSObject
    'private Cybele.Thinfinity.JSObject xvideo2;

    Private playing As [Boolean] = False
#End Region

    Public Sub New()
        InitializeComponent()
        Initialize()
    End Sub

    Private Sub Initialize()
        Try
            cmbMp4.SelectedIndex = 0

            Dim videocompfile = AppDomain.CurrentDomain.BaseDirectory + "..\x-tag\vui-video\vui-video.html"
            Dim mediafile = AppDomain.CurrentDomain.BaseDirectory + "\vui-video\media\big_buck_bunny_480p_2mb.mp4"
            Dim mediadir = AppDomain.CurrentDomain.BaseDirectory + "\vui-video\media\"
            Dim scriptfile = AppDomain.CurrentDomain.BaseDirectory + "..\x-tag\x-tag-core.min.js"

            vui = New Cybele.Thinfinity.VirtualUI()
            vui.HTMLDoc.LoadScript("/x-tag/x-tag-core.min.js", scriptfile)
            vui.HTMLDoc.ImportHTML("/x-tag/vui-video/vui-video.html", videocompfile)
            vui.Start()

            vui.HTMLDoc.CreateSessionURL("/media/", mediadir)
            cmbMp4.Items.Insert(0, vui.HTMLDoc.GetSafeUrl(mediafile, 60))
            cmbMp4.Items.Insert(0, "/media/big_buck_bunny_480p_2mb.mp4")
            cmbMp4.Items.Insert(0, "/media/Ocean.mp4")

            vui.HTMLDoc.CreateComponent("xvideo_1", "vui-video", panelXVideo.Handle)

            ' -- The given name, is how the model shown this object in the model reference.
            xvideo1 = New Cybele.Thinfinity.JSObject("xvideo_1")
            'xvideo2 = new Cybele.Thinfinity.JSObject("xvideo_2");

            If vui.Active Then
                ' -- Adding properties, methods and events.
                xvideo1.Properties.Add("state").OnSet(New Cybele.Thinfinity.JSBinding( _
                                                      Sub(Parent As Cybele.Thinfinity.IJSObject, Prop As Cybele.Thinfinity.IJSProperty) lblStatus.Text = Prop.AsString)).AsString = ""
                xvideo1.Properties.Add("position").AsFloat = 0.0F
                xvideo1.Properties.Add("currentPosition").OnSet(New Cybele.Thinfinity.JSBinding( _
                                                                Sub(Parent As Cybele.Thinfinity.IJSObject, Prop As Cybele.Thinfinity.IJSProperty)
                                                                    'Me.slider.Scroll -= New System.EventHandler(AddressOf Me.slider_Scroll)
                                                                    slider.Value = Math.Round(Prop.AsFloat * 100)
                                                                    'Me.slider.Scroll += New System.EventHandler(AddressOf Me.slider_Scroll)
                                                                End Sub)).AsFloat = 0.0F
                xvideo1.Properties.Add("length").OnSet(New Cybele.Thinfinity.JSBinding( _
                                                       Sub(Parent As Cybele.Thinfinity.IJSObject, Prop As Cybele.Thinfinity.IJSProperty)
                                                           slider.Maximum = Math.Round(Prop.AsFloat * 100)
                                                       End Sub)).AsFloat = 0.0F
                xvideo1.Properties.Add("src").AsString = ""
                xvideo1.Events.Add("play")
                xvideo1.Events.Add("pause")
                xvideo1.Events.Add("stop")
                xvideo1.ApplyModel()
            Else
                Console.WriteLine("VirtualUI is not ready")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub btnGo_xvideo1_Click(sender As Object, e As EventArgs)
        'axwmp_xvideo1.URL = txtUrl_xvideo1.Text;
        'xvideo1.Events["urlChange"].ArgumentAsString("url", txtUrl_xvideo1.Text).Fire();
        xvideo1.Properties("src").AsString = cmbMp4.Text
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs)
        If Not playing Then
            btnPlay.Text = "Pause"
            xvideo1.Events("Play").Fire()
        Else
            btnPlay.Text = "Play"
            xvideo1.Events("Pause").Fire()
        End If
        playing = Not playing
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs)
        btnPlay.Text = "Play"
        playing = False
        xvideo1.Events("Stop").Fire()
    End Sub

    Private Sub slider_Scroll(sender As Object, e As EventArgs)
        Console.WriteLine("Scroll")
        xvideo1.Properties("position").AsFloat = CSng(slider.Value) / 100
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs)

        Dim s As Size = Me.Size
        Dim p As Point = btnGo_xvideo1.Location
        btnGo_xvideo1.Location = New Point(s.Width - 60, p.Y)

    End Sub
End Class
