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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.BtnGetPrinters = New System.Windows.Forms.Button()
        Me.BtnPrintDoc = New System.Windows.Forms.Button()
        Me.LBoxPrinters = New System.Windows.Forms.ListBox()
        Me.txtPrinterName = New System.Windows.Forms.TextBox()
        Me.txtDocTitle = New System.Windows.Forms.TextBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnGetPrinters
        '
        Me.BtnGetPrinters.Location = New System.Drawing.Point(12, 12)
        Me.BtnGetPrinters.Name = "BtnGetPrinters"
        Me.BtnGetPrinters.Size = New System.Drawing.Size(75, 23)
        Me.BtnGetPrinters.TabIndex = 0
        Me.BtnGetPrinters.Text = "Get Printers"
        Me.BtnGetPrinters.UseVisualStyleBackColor = True
        '
        'BtnPrintDoc
        '
        Me.BtnPrintDoc.Location = New System.Drawing.Point(12, 351)
        Me.BtnPrintDoc.Name = "BtnPrintDoc"
        Me.BtnPrintDoc.Size = New System.Drawing.Size(116, 23)
        Me.BtnPrintDoc.TabIndex = 1
        Me.BtnPrintDoc.Text = "Print Document"
        Me.BtnPrintDoc.UseVisualStyleBackColor = True
        '
        'LBoxPrinters
        '
        Me.LBoxPrinters.FormattingEnabled = True
        Me.LBoxPrinters.Location = New System.Drawing.Point(93, 12)
        Me.LBoxPrinters.Name = "LBoxPrinters"
        Me.LBoxPrinters.ScrollAlwaysVisible = True
        Me.LBoxPrinters.Size = New System.Drawing.Size(176, 82)
        Me.LBoxPrinters.TabIndex = 2
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(93, 101)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.Size = New System.Drawing.Size(176, 20)
        Me.txtPrinterName.TabIndex = 3
        '
        'txtDocTitle
        '
        Me.txtDocTitle.Location = New System.Drawing.Point(93, 127)
        Me.txtDocTitle.Name = "txtDocTitle"
        Me.txtDocTitle.Size = New System.Drawing.Size(176, 20)
        Me.txtDocTitle.TabIndex = 4
        Me.txtDocTitle.Text = "ZPL RAW Document 1"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(12, 153)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(257, 192)
        Me.txtData.TabIndex = 5
        Me.txtData.Text = resources.GetString("txtData.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Printer Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Doc Title:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 383)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.txtDocTitle)
        Me.Controls.Add(Me.txtPrinterName)
        Me.Controls.Add(Me.LBoxPrinters)
        Me.Controls.Add(Me.BtnPrintDoc)
        Me.Controls.Add(Me.BtnGetPrinters)
        Me.Name = "MainForm"
        Me.Text = "Remote Printer Demo VB.NET"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnGetPrinters As Button
    Friend WithEvents BtnPrintDoc As Button
    Friend WithEvents LBoxPrinters As ListBox
    Friend WithEvents txtPrinterName As TextBox
    Friend WithEvents txtDocTitle As TextBox
    Friend WithEvents txtData As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
