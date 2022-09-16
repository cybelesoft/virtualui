VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Form1 
   Caption         =   "ShowFile and Upload demo"
   ClientHeight    =   4185
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4410
   LinkTopic       =   "Form1"
   ScaleHeight     =   4185
   ScaleWidth      =   4410
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "VirtualUI.FileDownload"
      Height          =   495
      Left            =   360
      TabIndex        =   0
      Top             =   360
      Width           =   3615
   End
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3600
      Top             =   3360
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
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
    VUI.DownloadFile CommonDialog1.Filename, "", ""
End Sub

Private Sub Form_Load()
    Set VUI = CreateObject("Thinfinity.VirtualUI")
    VUI.Start 60
    VUI.StdDialogs = True
End Sub

Private Sub VUI_OnDownloadEnd(ByVal Filename As String)
    MsgBox Filename & "  downloaded successfully!"
End Sub
   

