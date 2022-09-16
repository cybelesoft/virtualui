VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5385
   ClientLeft      =   3735
   ClientTop       =   2895
   ClientWidth     =   12165
   LinkTopic       =   "Form1"
   OLEDropMode     =   1  'Manual
   ScaleHeight     =   5385
   ScaleWidth      =   12165
   Begin VB.Label Label1 
      Caption         =   "Drop you a file anywhere on the browser to upload"
      DragMode        =   1  'Automatic
      Height          =   495
      Left            =   4200
      TabIndex        =   0
      Top             =   1560
      Width           =   3735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public WithEvents VUI As Thinfinity.VirtualUI
Attribute VUI.VB_VarHelpID = -1
Dim Filename As String

Private Sub Form_Load()
    Set VUI = CreateObject("Thinfinity.VirtualUI")
    VUI.Start (60)
End Sub

Private Sub VUI_OnDragFile(ByVal Action As Thinfinity.DragAction, ByVal X As Long, ByVal Y As Long, ByVal Filenames As String)
  If Action = Drop Then
    MsgBox "Will upload " & Filenames
    VUI.UploadFile (Filename)
  End If
End Sub

Private Sub VUI_OnUploadEnd(ByVal Filename As String)
  MsgBox " File was uploaded to " & Filename
End Sub
    
