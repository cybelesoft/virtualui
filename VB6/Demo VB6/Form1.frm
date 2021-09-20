VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "First Activity..."
   ClientHeight    =   3330
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   4575
   LinkTopic       =   "Form1"
   Moveable        =   0   'False
   ScaleHeight     =   3330
   ScaleWidth      =   4575
   StartUpPosition =   2  'CenterScreen
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3960
      Top             =   2760
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CheckBox StandardDialogCheckbox 
      Caption         =   "StandardDialog"
      Height          =   375
      Left            =   240
      TabIndex        =   10
      Top             =   2640
      Value           =   1  'Checked
      Width           =   1575
   End
   Begin VB.CommandButton DownloadFile 
      Caption         =   "DownloadFile"
      Height          =   375
      Left            =   1680
      TabIndex        =   9
      Top             =   1920
      Width           =   1215
   End
   Begin VB.CommandButton UploadFile 
      Caption         =   "UploadFile"
      Height          =   375
      Left            =   3120
      TabIndex        =   8
      Top             =   1920
      Width           =   1095
   End
   Begin VB.CommandButton PrintPDF 
      Caption         =   "PrintPDF"
      Height          =   375
      Left            =   1680
      TabIndex        =   7
      Top             =   1320
      Width           =   1215
   End
   Begin VB.CheckBox CursorVisible 
      Caption         =   "CursorVisible"
      Height          =   615
      Left            =   240
      TabIndex        =   6
      Top             =   1920
      Value           =   1  'Checked
      Width           =   1335
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Username"
      Height          =   375
      Left            =   3120
      TabIndex        =   5
      Top             =   1320
      Width           =   1095
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Shell"
      Height          =   375
      Left            =   360
      TabIndex        =   4
      Top             =   1320
      Width           =   1095
   End
   Begin VB.TextBox txtShow 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.5
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   4335
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3000
      TabIndex        =   2
      Top             =   720
      Width           =   1215
   End
   Begin VB.CommandButton cmdClear 
      Caption         =   "Clear"
      Height          =   375
      Left            =   1680
      TabIndex        =   1
      Top             =   720
      Width           =   1215
   End
   Begin VB.CommandButton cmdShow 
      Caption         =   "Show"
      Height          =   375
      Left            =   360
      TabIndex        =   0
      Top             =   720
      Width           =   1215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Private VirtualUI As New ThinfinityVirtualUI
    Dim VUI As Variant
Private Sub cmdClear_Click()
txtShow.Text = ""
End Sub

Private Sub cmdExit_Click()
If MsgBox("Are you sure you want to close the application?", vbQuestion + vbYesNo, "Confirm") = vbYes Then
    End
Else
    cmdShow.SetFocus
End If
End Sub

Private Sub cmdShow_Click()

    txtShow.Text = "Hello World!"
    
End Sub

Private Sub Command1_Click()

   Shell (App.Path + "\Project1.exe"), vbNormalFocus
  
End Sub

Private Sub Command2_Click()

    'BrowserInfo Class
    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00141.html
    
    MsgBox (VUI.BrowserInfo.Username & Chr(13) & Chr(10) & VUI.BrowserInfo.IPAddress)
    
End Sub

Private Sub DownloadFile_Click()

    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00654.html
    
    
    CommonDialog1.ShowOpen
    
    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00648.html
    VUI.DownloadFile CommonDialog1.Filename, "", ""
    
End Sub

'Fires after a Download is finished
'https://files.cybelesoft.com/manuals/symbolreference/index.html?00389.html

Private Sub VUI_OnDownloadEnd(ByVal Filename As String)

    MsgBox Filename & "  downloaded successfully!"
    
End Sub

Private Sub StandardDialogCheckbox_Click()
         
    If StandardDialogCheckbox.Value = 1 Then
        VUI.StdDialogs = True
    Else
         VUI.StdDialogs = False
    End If


End Sub

Private Sub UploadFile_Click()
    
    'Upload File method
    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00657.html
    VUI.UploadFile (App.Path)
    
End Sub



Private Sub PrintPDF_Click()

    'PrintPDF Method
    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00648.html
    
    VUI.PrintPDF (App.Path + "\Microsoft.pdf")
    

End Sub

Private Sub CursorVisible_Click()
    
    'ClientSettings Class
    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00279.html
    
     'CursorVisible Property
     'https://files.cybelesoft.com/manuals/symbolreference/index.html?00281.html
     
     'https://www.cybelesoft.com/blog/using-javascript-clientsettings-object/
     
     'https://www.cybelesoft.com/blog/change-browser-behavior-using-clientsettings/
     
     
     
    If CursorVisible.Value = 1 Then
        VUI.ClientSettings.CursorVisible = True
    Else
         VUI.ClientSettings.CursorVisible = False
    End If
    
End Sub

Private Sub Form_Load()
    
    Set VUI = CreateObject("VirtualUI.VirtualUI")
    VUI.Start (60)
    
    VUI.StdDialogs = True
    
    'Allow Execute Method
    'https://files.cybelesoft.com/manuals/symbolreference/index.html?00636.html
    VUI.AllowExecute (".+")


End Sub




Private Sub Form_Unload(Cancel As Integer)
    Set VUI = Nothing
End Sub
