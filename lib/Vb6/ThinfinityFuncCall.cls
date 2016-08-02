VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ThinfinitycFuncCall"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Public Enum DECLSPEC
    eStdCall
    eCDecl
End Enum

'***********************************************
'* This class module use excelent solution from
'* http://www.vbdotcom.com/FreeCode.htm
'* how to implement assembly calls directly
'* into VB code.
'***********************************************

Private Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Long
Private Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Long, ByVal lpProcName As String) As Long
Private Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Long, ByVal hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
Private Declare Function FreeLibrary Lib "kernel32" (ByVal hLibModule As Long) As Long
Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (lpDest As Any, lpSource As Any, ByVal cBytes As Long)
Private m_lParameters() As Long 'list of parameters
Private m_lpFn As Long 'address of function to call
Private m_abCode() As Byte 'buffer for assembly code
Private m_lCP As Long 'used to keep track of latest byte added to code
Private m_hLib As Long
Private m_CallType As DECLSPEC

Public Property Let LibraryName(ByVal sData As String)
   If m_hLib Then FreeLibrary m_hLib
   m_hLib = LoadLibrary(sData)
   If m_hLib = 0 Then MsgBox "Can not find library " & Chr(34) & sData & Chr(34), vbCritical, "Function call error"
End Property

Public Property Let FunctionName(ByVal sData As String)
   Dim sMsg As String
   m_lpFn = GetProcAddress(m_hLib, sData)
   If m_lpFn = 0 Then
      sMsg = "Can not find function entry point for " & Chr(34) & sData & Chr(34)
      sMsg = sMsg & vbCrLf & "Note: function names are case sensitive, check out you function spelling!"
      MsgBox sMsg, vbCritical, "Function call error"
   End If
End Property

Public Property Let CallType(ByVal lData As DECLSPEC)
   m_CallType = lData
End Property

Public Function CallFunction(ParamArray FuncParams()) As Long
   Dim i As Long
   If m_lpFn = 0 Then
      MsgBox "Function not defined!", vbCritical, "Call function error"
      Exit Function
   End If
   ReDim m_abCode(0)
   ReDim m_lParameters(UBound(FuncParams) + 1)
   ReDim m_abCode(18 + 32 + 6 * UBound(m_lParameters))
   For i = 1 To UBound(m_lParameters)
      m_lParameters(i) = CLng(FuncParams(i - 1))
   Next i
   CallFunction = CallWindowProc(PrepareCode, 0, 0, 0, 0)
   m_lpFn = 0
End Function

Private Function PrepareCode() As Long
    Dim i As Long, codeStart As Long
    codeStart = GetAlignedCodeStart(VarPtr(m_abCode(0)))
    m_lCP = codeStart - VarPtr(m_abCode(0))
    For i = 0 To m_lCP - 1
        m_abCode(i) = &HCC
    Next
    PrepareStack
    For i = UBound(m_lParameters) To 1 Step -1
        AddByteToCode &H68 'push wwxxyyzz
        AddLongToCode m_lParameters(i)
    Next
    AddCallToCode m_lpFn
    If m_CallType = eCDecl Then ClearStack
    AddByteToCode &HC3
    AddByteToCode &HCC
    PrepareCode = codeStart
End Function

Private Sub AddCallToCode(ByVal dwAddress As Long)
    AddByteToCode &HE8
    AddLongToCode dwAddress - VarPtr(m_abCode(m_lCP)) - 4
End Sub

Private Sub AddLongToCode(ByVal lng As Long)
    Dim i As Integer
    Dim byt(3) As Byte
    CopyMemory byt(0), lng, 4
    For i = 0 To 3
        AddByteToCode byt(i)
    Next
End Sub

Private Sub AddByteToCode(ByVal byt As Byte)
    m_abCode(m_lCP) = byt
    m_lCP = m_lCP + 1
End Sub

Private Function GetAlignedCodeStart(ByVal dwAddress As Long) As Long
    GetAlignedCodeStart = dwAddress + (15 - (dwAddress - 1) Mod 16)
    If (15 - (dwAddress - 1) Mod 16) = 0 Then GetAlignedCodeStart = GetAlignedCodeStart + 16
End Function

Private Sub PrepareStack()
    AddByteToCode &H58 'pop eax -  pop return address
    AddByteToCode &H59 'pop ecx -  kill hwnd
    AddByteToCode &H59 'pop ecx -  kill wmsg
    AddByteToCode &H59 'pop ecx -  kill wParam
    AddByteToCode &H59 'pop ecx -  kill lParam
    AddByteToCode &H50 'push eax - put return address back
End Sub

Private Sub ClearStack()
   Dim i As Long
   For i = 1 To UBound(m_lParameters)
       AddByteToCode &H59 'pop ecx - remove params from stack
   Next
End Sub

Private Sub Class_Initialize()
   m_CallType = eStdCall
End Sub

Private Sub Class_Terminate()
   If m_hLib Then FreeLibrary m_hLib
End Sub
