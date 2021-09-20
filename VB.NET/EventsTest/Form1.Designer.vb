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
        Me.ButtonDownload = New System.Windows.Forms.Button()
        Me.LblTestDir = New System.Windows.Forms.Label()
        Me.ButtonUpload = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtLog = New System.Windows.Forms.TextBox()
        Me.CheckRemoveTestDir = New System.Windows.Forms.CheckBox()
        Me.CheckSaveLog = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ButtonDownload
        '
        Me.ButtonDownload.Location = New System.Drawing.Point(12, 39)
        Me.ButtonDownload.Name = "ButtonDownload"
        Me.ButtonDownload.Size = New System.Drawing.Size(102, 23)
        Me.ButtonDownload.TabIndex = 0
        Me.ButtonDownload.Text = "DownloadFile"
        Me.ButtonDownload.UseVisualStyleBackColor = True
        '
        'LblTestDir
        '
        Me.LblTestDir.AutoSize = True
        Me.LblTestDir.Location = New System.Drawing.Point(12, 9)
        Me.LblTestDir.Name = "LblTestDir"
        Me.LblTestDir.Size = New System.Drawing.Size(74, 13)
        Me.LblTestDir.TabIndex = 1
        Me.LblTestDir.Text = "Test directory:"
        '
        'ButtonUpload
        '
        Me.ButtonUpload.Location = New System.Drawing.Point(120, 39)
        Me.ButtonUpload.Name = "ButtonUpload"
        Me.ButtonUpload.Size = New System.Drawing.Size(102, 23)
        Me.ButtonUpload.TabIndex = 2
        Me.ButtonUpload.Text = "UploadFile"
        Me.ButtonUpload.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(117, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "(or drop files to browser)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Events log:"
        '
        'TxtLog
        '
        Me.TxtLog.Location = New System.Drawing.Point(12, 107)
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtLog.Size = New System.Drawing.Size(570, 189)
        Me.TxtLog.TabIndex = 5
        '
        'CheckRemoveTestDir
        '
        Me.CheckRemoveTestDir.AutoSize = True
        Me.CheckRemoveTestDir.Checked = True
        Me.CheckRemoveTestDir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckRemoveTestDir.Location = New System.Drawing.Point(12, 302)
        Me.CheckRemoveTestDir.Name = "CheckRemoveTestDir"
        Me.CheckRemoveTestDir.Size = New System.Drawing.Size(176, 17)
        Me.CheckRemoveTestDir.TabIndex = 6
        Me.CheckRemoveTestDir.Text = "Remove Test directory on close"
        Me.CheckRemoveTestDir.UseVisualStyleBackColor = True
        '
        'CheckSaveLog
        '
        Me.CheckSaveLog.AutoSize = True
        Me.CheckSaveLog.Checked = True
        Me.CheckSaveLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckSaveLog.Location = New System.Drawing.Point(249, 302)
        Me.CheckSaveLog.Name = "CheckSaveLog"
        Me.CheckSaveLog.Size = New System.Drawing.Size(200, 17)
        Me.CheckSaveLog.TabIndex = 7
        Me.CheckSaveLog.Text = "Save log to VirtualUI_Events_PID.txt"
        Me.CheckSaveLog.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 325)
        Me.Controls.Add(Me.CheckSaveLog)
        Me.Controls.Add(Me.CheckRemoveTestDir)
        Me.Controls.Add(Me.TxtLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonUpload)
        Me.Controls.Add(Me.LblTestDir)
        Me.Controls.Add(Me.ButtonDownload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "VirtualUI - Events test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonDownload As Button
    Friend WithEvents LblTestDir As Label
    Friend WithEvents ButtonUpload As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtLog As TextBox
    Friend WithEvents CheckRemoveTestDir As CheckBox
    Friend WithEvents CheckSaveLog As CheckBox
End Class
