VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Dojo Dialog Demo"
   ClientHeight    =   3960
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   4935
   LinkTopic       =   "Form1"
   ScaleHeight     =   3960
   ScaleWidth      =   4935
   StartUpPosition =   2  'CenterScreen
   Begin VB.TextBox Text1 
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Text            =   "Blipverts in action!"
      Top             =   240
      Width           =   2775
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Show Dialog"
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   840
      Width           =   2055
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public JsObj As Thinfinity.JSObject
Public VUI As Variant
Public jsLoaded As Boolean

Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

Private Sub LoadDialogScript()
    If Not jsLoaded Then
        ' Create JSObject
        Set JsObj = CreateObject("Thinfinity.JSObject")
        JsObj.Id = "dlg"
                
        ' Add event sendToWeb
        Dim Event1 As Thinfinity.IJSEvent
        Set Event1 = JsObj.Events.Add("showModalDlg")
        Event1.AddArgument "msg", Thinfinity.JSDT_STRING
            
        JsObj.ApplyModel
        Sleep 250
        jsLoaded = True
    End If
End Sub

Private Sub Command1_Click()
    JsObj.Events("showModalDlg").ArgumentAsString("msg", Text1.Text).Fire
End Sub

Private Sub Form_Load()
    Set VUI = CreateObject("VirtualUI.VirtualUI")
    VUI.Start (60)
    LoadDialogScript
End Sub
