VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "VirtualUI - JSRO demo"
   ClientHeight    =   5205
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   8205
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5205
   ScaleWidth      =   8205
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox TxtLog 
      Height          =   3855
      Left            =   240
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   3
      Top             =   1080
      Width           =   7695
   End
   Begin VB.CommandButton CmdSend 
      Caption         =   "Send"
      Height          =   375
      Left            =   6840
      TabIndex        =   2
      Top             =   480
      Width           =   1095
   End
   Begin VB.TextBox TxtMessage 
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   480
      Width           =   6495
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "Message:"
      Height          =   195
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   690
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim VirtualUIObj As Thinfinity.VirtualUI
Dim MsgObj As Thinfinity.JSObject

Implements IJSCallback

Private Sub IJSCallback_Callback(ByVal Parent As Thinfinity.IJSObject, ByVal Method As Thinfinity.IJSMethod)
    ' Get "msg" parameter
    Dim arg As Thinfinity.IJSArgument
    Set arg = Method.Arguments.Item("msg")
    
    Dim msg As String
    msg = arg.AsString

    TxtLog.Text = TxtLog.Text + "Recv: " + msg + vbNewLine
End Sub

Private Sub Form_Load()
    ' Create and start VirtualUI
    Set VirtualUIObj = New Thinfinity.VirtualUI
    VirtualUIObj.Start 60
    
    ' Create a JS Remote Object named "msgObject"
    Set MsgObj = New Thinfinity.JSObject
    MsgObj.Id = "msgObject"
    
    ' Add a method to send messages from Javascript
    Dim Method As Thinfinity.IJSMethod
    Set Method = MsgObj.Methods.Add("sendMessage")
    Method.AddArgument "msg", Thinfinity.JSDT_STRING    ' Add 1 string parameter
    Set Method = Method.OnCall(Me)                      ' Add the callback (this class implements IJSCallback.Callback)

    ' Add the "message" event with 1 string argument
    Dim Evt As Thinfinity.IJSEvent
    Set Evt = MsgObj.Events.Add("message")
    Evt.AddArgument "msgText", Thinfinity.JSDT_STRING

    ' Applies the object model and sends it to the web browser
    MsgObj.ApplyModel
End Sub

Private Sub CmdSend_Click()
    ' Fires the remote "message" event
    Dim Evt As Thinfinity.IJSEvent
    Set Evt = MsgObj.Events.Item("message")
    Evt.ArgumentAsString "msgText", TxtMessage.Text
    Evt.Fire

    TxtLog.Text = TxtLog.Text + "Send: " + TxtMessage.Text + vbNewLine
End Sub

