VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "ShowFile and Upload demo"
   ClientHeight    =   2490
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4110
   LinkTopic       =   "Form1"
   ScaleHeight     =   2490
   ScaleWidth      =   4110
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "VirtualUI.FileUpload"
      Height          =   495
      Left            =   240
      TabIndex        =   1
      Top             =   720
      Width           =   3615
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3360
      Top             =   1920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton Command1 
      Caption         =   "CommonDialog.ShowFile"
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   120
      Width           =   3615
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public WithEvents VUI As Thinfinity.VirtualUI
Attribute VUI.VB_VarHelpID = -1

Private Sub Command1_Click()
    CommonDialog1.ShowOpen
    MsgBox CommonDialog1.Filename
End Sub

Private Sub Command2_Click()
    VUI.UploadFile ""
End Sub

Private Sub Form_Load()
    Set VUI = CreateObject("Thinfinity.VirtualUI")
    VUI.Start 60
End Sub

Private Sub VUI_OnUploadEnd(ByVal Filename As String)
    MsgBox Filename
End Sub
