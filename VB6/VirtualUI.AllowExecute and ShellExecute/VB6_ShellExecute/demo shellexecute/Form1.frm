VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6180
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   9750
   LinkTopic       =   "Form1"
   ScaleHeight     =   6180
   ScaleWidth      =   9750
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   1335
      Left            =   240
      TabIndex        =   0
      Top             =   480
      Width           =   2895
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" _
(ByVal hWnd As Long, ByVal lpOperation As String, ByVal lpFile As String, _
ByVal lpParameters As String, ByVal lpDirectory As String, _
ByVal nShowcmd As Long) As Long

Private VUI As Thinfinity.VirtualUI
'Public WithEvents VUI As Thinfinity.VirtualUI

Private Sub Command1_Click()
    Set VUI = CreateObject("VirtualUI.VirtualUI")
	VUI.AllowExecute("/*.bat")
    'VUI.DevMode = True
    'VUI.DevServer.Port = 6080
    'VUI.DevServer.Enabled = True
    VUI.Start (60)
    
    Dim Handle As Long
    Dim operation As String
    Dim lpFile As String
    Dim lpParam As String
    Dim lpDir As String
    Dim nShowcmd As Long
   
    
    operation = "Open"
    Handle = Me.hWnd
    lpFile = "C:\temp\file.bat"
    lpParam = vbNullString
    lpDir = "C:\temp\"
    nShowcmd = 1
       
    Dim iRet As Long
    iRet = ShellExecute(Handle, operation, lpFile, lpParam, lpDir, nShowcmd)
    If iRet >= 32 Then
        MsgBox ("Error")
    End If
    
    
    
End Sub
