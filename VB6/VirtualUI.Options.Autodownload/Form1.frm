VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   1275
   ClientLeft      =   60
   ClientTop       =   405
   ClientWidth     =   5580
   LinkTopic       =   "Form1"
   ScaleHeight     =   1275
   ScaleWidth      =   5580
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3120
      Top             =   120
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Save"
      Height          =   375
      Left            =   3840
      TabIndex        =   1
      Top             =   240
      Width           =   1095
   End
   Begin VB.TextBox Text1 
      Height          =   405
      Left            =   120
      TabIndex        =   0
      Text            =   "Text to be saved"
      Top             =   240
      Width           =   3375
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public VUI As Variant
Private Sub Command1_Click()
    CommonDialog1.Filter = "TXT Files (*.txt)|*.txt|All Files (*.*)|*.*"
    CommonDialog1.FileName = "test1.txt"
    CommonDialog1.ShowSave
    
    On Error GoTo errhandler
    file1 = FreeFile
    Open CommonDialog1.FileName For Output As #file1
    Print #file1, Text1.Text
    Close #file1
errhandler:
End Sub

Private Sub Form_Load()
    Set VUI = CreateObject("Thinfinity.VirtualUI")
    VUI.Options = VUI.Options Or OPT_AUTODOWNLOAD
    VUI.Start (60)
End Sub
