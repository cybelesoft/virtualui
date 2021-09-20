VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "VB6 Wc1"
   ClientHeight    =   7515
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   7815
   LinkTopic       =   "Form1"
   ScaleHeight     =   7515
   ScaleWidth      =   7815
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   375
      Left            =   600
      TabIndex        =   3
      Text            =   "Hello WebComponent"
      Top             =   2640
      Width           =   3855
   End
   Begin VB.CommandButton BSend 
      Caption         =   "Send to WebComponent"
      Height          =   375
      Left            =   4680
      TabIndex        =   2
      Top             =   2640
      Width           =   2535
   End
   Begin VB.ListBox List1 
      Height          =   2010
      Left            =   600
      TabIndex        =   1
      Top             =   480
      Width           =   6615
   End
   Begin VB.Frame FrameWebComponent 
      Caption         =   "FrameWebComponent"
      Height          =   3375
      Left            =   600
      TabIndex        =   0
      Top             =   3600
      Width           =   6615
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public JsObj As Thinfinity.JSObject
Public VUI As Variant

Implements IJSCallback

Public Sub IJSCallback_Callback(ByVal Parent As Thinfinity.IJSObject, ByVal Method As Thinfinity.IJSMethod)
    
    ' Get "msg" parameter
    Dim arg As Thinfinity.IJSArgument
    Dim msg As String
    
    Set arg = Method.Arguments.Item("msg")
    msg = arg.AsString
    List1.AddItem ("WebComponent says: " + msg)
End Sub

Private Sub BSend_Click()
    ' Fires an event to the web side with a parameter
    JsObj.Events("sendToWeb").ArgumentAsString("msg", Text1.Text).Fire
End Sub

Private Sub Form_Load()
    Set VUI = CreateObject("VirtualUI.VirtualUI")
    VUI.Start (60)
    CreateWebComponent
End Sub

Public Sub CreateWebComponent()
    ' Create temporary url for this session
    r = VUI.HTMLDoc.CreateSessionURL("/wc/", CurDir() + "\wc")
    
    ' Load x-tag and create WebComponent
    r = VUI.HTMLDoc.LoadScript("/wc/x-tag-core.min.js", "")
    r = VUI.HTMLDoc.ImportHTML("/wc/wc1.html", "")
    r = VUI.HTMLDoc.CreateComponent("wc1", "x-wc1", FrameWebComponent.hWnd)
    
    ' Create JSObject
    Set JsObj = CreateObject("Thinfinity.JSObject")
    JsObj.Id = "wc1"
         
    ' Add Method sendMessage and bind to Me
    Dim Method As Thinfinity.IJSMethod
    Set Method = JsObj.Methods.Add("sendMessage")
    Method.AddArgument "msg", Thinfinity.JSDT_STRING    ' Add 1 string parameter
    Set Method = Method.OnCall(Me)                      ' Add the callback (this class implements IJSCallback.Callback)
    
    ' Add event sendToWeb
    Dim Event1 As Thinfinity.IJSEvent
    Set Event1 = JsObj.Events.Add("sendToWeb")
    Event1.AddArgument "msg", Thinfinity.JSDT_STRING
            
    JsObj.ApplyModel
End Sub

