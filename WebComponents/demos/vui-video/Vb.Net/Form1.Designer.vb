<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbMp4 = New System.Windows.Forms.ComboBox()
        Me.panelXVideo = New System.Windows.Forms.Panel()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.slider = New System.Windows.Forms.TrackBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnGo_xvideo1 = New System.Windows.Forms.Button()
        Me.lblUrl = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        CType(Me.slider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbMp4
        '
        Me.cmbMp4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMp4.FormattingEnabled = True
        Me.cmbMp4.Items.AddRange(New Object() {"http://www.sample-videos.com/video/mp4/480/big_buck_bunny_480p_2mb.mp4", "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_72" & _
                "00K.MP4", "http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_72" & _
                "00K_short.MP4", "http://download.openbricks.org/sample/H264/h264_Linkin_Park-Leave_Out_All_The_Res" & _
                "t.mp4", "http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Media/H264_test1_Tal" & _
                "kinghead_mp4_480x360.mp4", "http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Media/H264_test3_Tal" & _
                "kingheadclipped_mp4_480x360.mp4"})
        Me.cmbMp4.Location = New System.Drawing.Point(68, 23)
        Me.cmbMp4.Name = "cmbMp4"
        Me.cmbMp4.Size = New System.Drawing.Size(559, 21)
        Me.cmbMp4.TabIndex = 14
        '
        'panelXVideo
        '
        Me.panelXVideo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelXVideo.Location = New System.Drawing.Point(33, 158)
        Me.panelXVideo.Name = "panelXVideo"
        Me.panelXVideo.Size = New System.Drawing.Size(640, 360)
        Me.panelXVideo.TabIndex = 13
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.slider)
        Me.groupBox1.Controls.Add(Me.lblStatus)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.btnStop)
        Me.groupBox1.Controls.Add(Me.btnPlay)
        Me.groupBox1.Location = New System.Drawing.Point(33, 57)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(640, 95)
        Me.groupBox1.TabIndex = 12
        Me.groupBox1.TabStop = False
        '
        'slider
        '
        Me.slider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.slider.Location = New System.Drawing.Point(6, 45)
        Me.slider.Maximum = 1000
        Me.slider.Name = "slider"
        Me.slider.Size = New System.Drawing.Size(628, 45)
        Me.slider.TabIndex = 12
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Location = New System.Drawing.Point(259, 21)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(375, 13)
        Me.lblStatus.TabIndex = 11
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(213, 21)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 13)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Status:"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(87, 16)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(6, 16)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(75, 23)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnGo_xvideo1
        '
        Me.btnGo_xvideo1.Location = New System.Drawing.Point(639, 24)
        Me.btnGo_xvideo1.Name = "btnGo_xvideo1"
        Me.btnGo_xvideo1.Size = New System.Drawing.Size(34, 20)
        Me.btnGo_xvideo1.TabIndex = 11
        Me.btnGo_xvideo1.Text = "GO"
        Me.btnGo_xvideo1.UseVisualStyleBackColor = True
        '
        'lblUrl
        '
        Me.lblUrl.AutoSize = True
        Me.lblUrl.Location = New System.Drawing.Point(30, 27)
        Me.lblUrl.Name = "lblUrl"
        Me.lblUrl.Size = New System.Drawing.Size(32, 13)
        Me.lblUrl.TabIndex = 10
        Me.lblUrl.Text = "URL:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 540)
        Me.Controls.Add(Me.cmbMp4)
        Me.Controls.Add(Me.panelXVideo)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnGo_xvideo1)
        Me.Controls.Add(Me.lblUrl)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.slider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cmbMp4 As System.Windows.Forms.ComboBox
    Private WithEvents panelXVideo As System.Windows.Forms.Panel
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents slider As System.Windows.Forms.TrackBar
    Private WithEvents lblStatus As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents btnPlay As System.Windows.Forms.Button
    Private WithEvents btnGo_xvideo1 As System.Windows.Forms.Button
    Private WithEvents lblUrl As System.Windows.Forms.Label

End Class
