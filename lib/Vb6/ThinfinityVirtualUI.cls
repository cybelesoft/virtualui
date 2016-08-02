VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ThinfinityVirtualUI"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

'===============================================================================
' LIBRARY CALL
'===============================================================================
'Private Declare Function DllAutoRun _
'        Lib "c:\source\appbridge\bin32\Thinfinity.VirtualUI.dll" _
'        (ByVal Timeout As Integer, ByVal ADevMode As Boolean, ByVal ADevPort As Integer) As Long

Private Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Long
Private Declare Function FreeLibrary Lib "kernel32" (ByVal hLibModule As Long) As Long
Private Declare Function GetProcAddress Lib "kernel32· " (ByVal hLibModule As Long, ByVal lpPorcName As String) As Long

'===============================================================================
' REGISTRY
'===============================================================================
Private Const REG_SZ As Long = 1 'REG_SZ represents a fixed-length text string.
Private Const REG_DWORD As Long = 4 'REG_DWORD represents data by a number that is 4 bytes long.

Private Const HKEY_CLASSES_ROOT = &H80000000 'The information stored here ensures that the correct program opens when you open a file by using Windows Explorer.
Private Const HKEY_CURRENT_USER = &H80000001 'Contains the root of the configuration information for the user who is currently logged on.
Private Const HKEY_LOCAL_MACHINE = &H80000002 'Contains configuration information particular to the computer (for any user).
Private Const HKEY_USERS = &H80000003 'Contains the root of all user profiles on the computer.

'Return values for all registry functions
Private Const ERROR_SUCCESS = 0
Private Const ERROR_NONE = 0

Private Const KEY_QUERY_VALUE = &H1 'Required to query the values of a registry key.
Private Const KEY_ALL_ACCESS = &H3F 'Combines the STANDARD_RIGHTS_REQUIRED, KEY_QUERY_VALUE, KEY_SET_VALUE, KEY_CREATE_SUB_KEY, KEY_ENUMERATE_SUB_KEYS, KEY_NOTIFY, and KEY_CREATE_LINK access rights.


'API Calls for writing to Registry
  'Close Registry Key
   Private Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hKey As Long) As Long
  'Create Registry Key
   Private Declare Function RegCreateKey Lib "advapi32.dll" Alias "RegCreateKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, phkResult As Long) As Long
  'Open Registry Key
   Private Declare Function RegOpenKeyEx Lib "advapi32.dll" Alias "RegOpenKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal ulOptions As Long, ByVal samDesired As Long, phkResult As Long) As Long
  'Query a String Value
   Private Declare Function RegQueryValueExString Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, ByVal lpData As String, lpcbData As Long) As Long
  'Query a Long Value
   Private Declare Function RegQueryValueExLong Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, lpData As Long, lpcbData As Long) As Long
  'Query a NULL Value
   Private Declare Function RegQueryValueExNULL Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, ByVal lpData As Long, lpcbData As Long) As Long
  'Enumerate Sub Keys
   Private Declare Function RegEnumKey Lib "advapi32.dll" Alias "RegEnumKeyA" (ByVal hKey As Long, ByVal dwIndex As Long, ByVal lpName As String, ByVal cbName As Long) As Long
  'Store a Value
   Private Declare Function RegSetValueEx Lib "advapi32.dll" Alias "RegSetValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal Reserved As Long, ByVal dwType As Long, lpData As Any, ByVal cbData As Long) As Long
  'Delete Key
   Private Declare Function RegDeleteKey Lib "advapi32.dll" Alias "RegDeleteKeyA" (ByVal hKey As Long, ByVal lpSubKey As String) As Long


Private mvarFnCall As ThinfinitycFuncCall

'===============================================================================
' Thinfinity Virtual UI SDK
'===============================================================================

Private Function GetDLLPathName() As String
    Dim lRetVal As Long      'result of the API functions
    Dim hKey As Long         'handle of opened key
    Dim Data As Long         'setting of queried value's size
    Dim sValue As String     'setting of queried value
    
    'Open Key to Query a value
    lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\Virtual UI", 0, KEY_QUERY_VALUE, hKey)
    If hKey = 0 Then
        lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "SOFTWARE\Cybele Software\Setups\Thinfinity\Virtual UI", 0, KEY_QUERY_VALUE, hKey)
    End If
    If hKey = 0 Then
        lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\Virtual UI\Dev", 0, KEY_QUERY_VALUE, hKey)
    End If
    If hKey = 0 Then
        lRetVal = RegOpenKeyEx(HKEY_LOCAL_MACHINE, "SOFTWARE\Cybele Software\Setups\Thinfinity\Virtual UI\Dev", 0, KEY_QUERY_VALUE, hKey)
    End If
    If hKey = 0 Then
        sValue = ""
    Else
        ' Determine the size and type of data to be read
        lRetVal = RegQueryValueExNULL(hKey, "TargetDir_x86", 0&, REG_SZ, 0&, Data)
        
        If lRetVal = ERROR_NONE Then
            sValue = String(Data, 0)
            'Query (determine) the value stored
            lRetVal = RegQueryValueExString(hKey, "TargetDir_x86", 0&, REG_SZ, sValue, Data)
            If lRetVal = ERROR_NONE Then
               sValue = Left$(sValue, Data - 1)
            Else
                sValue = Empty
            End If
        End If
    End If
    RegCloseKey (hKey) 'Close the Key
    
    If Len(sValue) > 0 And Right(sValue, 1) <> "\" Then
        sValue = sValue & "\"
    End If
    GetDLLPathName = sValue & "Thinfinity.VirtualUI.dll"
End Function

Public Sub AutoStart(Optional ByVal Timeout As Integer = 60)
    mvarFnCall.CallFunction Timeout, False, 0&
     
    'DllAutoRun Timeout, False, 0
End Sub

Public Sub StartDev(ByVal Port As Integer, Optional ByVal Timeout As Integer = 60)
    mvarFnCall.CallFunction Timeout, True, Port
    
    'DllAutoRun Timeout, True, Port
End Sub

Private Sub Class_Initialize()
'Exit Sub
    Set mvarFnCall = New ThinfinitycFuncCall
    mvarFnCall.LibraryName = GetDLLPathName
    mvarFnCall.FunctionName = "DllAutoRun"
    mvarFnCall.CallType = eStdCall
End Sub

