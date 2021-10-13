<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.btnOpenPdf = New System.Windows.Forms.Button()
        Me.btnOpenXps = New System.Windows.Forms.Button()
        Me.btnPrintDirect = New System.Windows.Forms.Button()
        Me.btnPrintPdf = New System.Windows.Forms.Button()
        Me.txtFileNamePdf = New System.Windows.Forms.TextBox()
        Me.txtFileNameXps = New System.Windows.Forms.TextBox()
        Me.btnPrintXps = New System.Windows.Forms.Button()
        Me.openFilesDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'txtFileName
        '
        Me.txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileName.Location = New System.Drawing.Point(219, 70)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(330, 20)
        Me.txtFileName.TabIndex = 21
        Me.txtFileName.Text = "Test1.txt"
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenFile.Location = New System.Drawing.Point(555, 68)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(24, 23)
        Me.btnOpenFile.TabIndex = 20
        Me.btnOpenFile.Text = "..."
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'btnOpenPdf
        '
        Me.btnOpenPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenPdf.Location = New System.Drawing.Point(555, 39)
        Me.btnOpenPdf.Name = "btnOpenPdf"
        Me.btnOpenPdf.Size = New System.Drawing.Size(24, 23)
        Me.btnOpenPdf.TabIndex = 19
        Me.btnOpenPdf.Text = "..."
        Me.btnOpenPdf.UseVisualStyleBackColor = True
        '
        'btnOpenXps
        '
        Me.btnOpenXps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenXps.Location = New System.Drawing.Point(555, 10)
        Me.btnOpenXps.Name = "btnOpenXps"
        Me.btnOpenXps.Size = New System.Drawing.Size(24, 23)
        Me.btnOpenXps.TabIndex = 18
        Me.btnOpenXps.Text = "..."
        Me.btnOpenXps.UseVisualStyleBackColor = True
        '
        'btnPrintDirect
        '
        Me.btnPrintDirect.Location = New System.Drawing.Point(12, 68)
        Me.btnPrintDirect.Name = "btnPrintDirect"
        Me.btnPrintDirect.Size = New System.Drawing.Size(201, 23)
        Me.btnPrintDirect.TabIndex = 17
        Me.btnPrintDirect.Text = "Print Direct PDF / ZPL (Raw to Printer)"
        Me.btnPrintDirect.UseVisualStyleBackColor = True
        '
        'btnPrintPdf
        '
        Me.btnPrintPdf.Location = New System.Drawing.Point(12, 39)
        Me.btnPrintPdf.Name = "btnPrintPdf"
        Me.btnPrintPdf.Size = New System.Drawing.Size(201, 23)
        Me.btnPrintPdf.TabIndex = 16
        Me.btnPrintPdf.Text = "Print PDF (To Any Default Printer)"
        Me.btnPrintPdf.UseVisualStyleBackColor = True
        '
        'txtFileNamePdf
        '
        Me.txtFileNamePdf.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileNamePdf.Location = New System.Drawing.Point(219, 41)
        Me.txtFileNamePdf.Name = "txtFileNamePdf"
        Me.txtFileNamePdf.Size = New System.Drawing.Size(330, 20)
        Me.txtFileNamePdf.TabIndex = 15
        Me.txtFileNamePdf.Text = "Test1.pdf"
        '
        'txtFileNameXps
        '
        Me.txtFileNameXps.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileNameXps.Location = New System.Drawing.Point(219, 12)
        Me.txtFileNameXps.Name = "txtFileNameXps"
        Me.txtFileNameXps.Size = New System.Drawing.Size(330, 20)
        Me.txtFileNameXps.TabIndex = 14
        Me.txtFileNameXps.Text = "Test1.xps"
        '
        'btnPrintXps
        '
        Me.btnPrintXps.Location = New System.Drawing.Point(12, 10)
        Me.btnPrintXps.Name = "btnPrintXps"
        Me.btnPrintXps.Size = New System.Drawing.Size(201, 23)
        Me.btnPrintXps.TabIndex = 13
        Me.btnPrintXps.Text = "Print XPS (To Any Default Printer)"
        Me.btnPrintXps.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 106)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.btnOpenPdf)
        Me.Controls.Add(Me.btnOpenXps)
        Me.Controls.Add(Me.btnPrintDirect)
        Me.Controls.Add(Me.btnPrintPdf)
        Me.Controls.Add(Me.txtFileNamePdf)
        Me.Controls.Add(Me.txtFileNameXps)
        Me.Controls.Add(Me.btnPrintXps)
        Me.Name = "MainForm"
        Me.Text = "Thinfinity RemotePrinter Demo VB.NET - PrintFile (VirtualUI)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents txtFileName As TextBox
    Private WithEvents btnOpenFile As Button
    Private WithEvents btnOpenPdf As Button
    Private WithEvents btnOpenXps As Button
    Private WithEvents btnPrintDirect As Button
    Private WithEvents btnPrintPdf As Button
    Private WithEvents txtFileNamePdf As TextBox
    Private WithEvents txtFileNameXps As TextBox
    Private WithEvents btnPrintXps As Button
    Private WithEvents openFilesDialog As OpenFileDialog
End Class
