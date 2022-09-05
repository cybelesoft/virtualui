Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Reflection
Public Class EldoradoVUIAuthentication
    Private Const NO_ERROR As Int32 = 0
    Private Const ERROR_BAD_USERNAME As Int32 = 2202

    Public Shared Function CurrentAssemblyDirectory() As String
        Dim codeBase As String = Assembly.GetExecutingAssembly().CodeBase
        Dim mypath As String = Path.GetDirectoryName(codeBase)
        Return mypath
    End Function


    '[DllExport("ValidateUser", CallingConvention = CallingConvention.StdCall)]
    '[return: MarshalAs(UnmanagedType.I4)]
    Public Shared Function ValidateUser(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpUserName As String,
                    <MarshalAs(UnmanagedType.LPWStr)> ByVal lpPassword As String,
                    <MarshalAs(UnmanagedType.LPWStr)> ByVal lpMetadata As String,
                    <MarshalAs(UnmanagedType.LPWStr)> ByRef lpSecurityRole As StringBuilder,
                    <MarshalAs(UnmanagedType.LPWStr)> ByRef lpWinUser As StringBuilder,
                    <MarshalAs(UnmanagedType.LPWStr)> ByRef lpWinPass As StringBuilder,
                    <MarshalAs(UnmanagedType.LPWStr)> ByRef lpCustomData As StringBuilder,
                    <MarshalAs(UnmanagedType.I1)> ByRef pHandled As Boolean) As Int32

        pHandled = True

        ' Get the current DLL pathname
        Dim lpFileName As String = CurrentAssemblyDirectory().Remove(0, 6)
        lpFileName = Path.GetDirectoryName(lpFileName)
        lpFileName = Path.GetDirectoryName(lpFileName)
        lpFileName = lpFileName + "\IniFile\AllowedUsers.ini"

        ' Read the stored password for the requested user
        Dim lpStoredPwd As StringBuilder = New StringBuilder()
        If GetPrivateProfileString("USERS", lpUserName, "NOTFOUND", lpStoredPwd, 256, lpFileName) <> 0 Then Return ERROR_BAD_USERNAME
        If lpStoredPwd.ToString = "NOTFOUND" Then Return ERROR_BAD_USERNAME

        ' Verify if the requested password Is correct
        If lpPassword.CompareTo(lpStoredPwd.ToString()) = 0 Then

            Dim lpStoredRole As StringBuilder = New StringBuilder()
            GetPrivateProfileString("ROLES", lpUserName, "", lpStoredRole, 256, lpFileName)
            lpSecurityRole.Append(lpStoredRole)

            lpCustomData.Append("{")
            'lpCustomData.Append("\"Assigned Role\":\""+ lpStoredRole + "\", ")
            'lpCustomData.Append("\"AuthenticatedBy\":\"ExtAuth.IniFiles\"")
            lpCustomData.Append("}")

            Return NO_ERROR
        End If

        Return ERROR_BAD_USERNAME
    End Function

    '[DllImport("kernel32")]
    'Private Static extern int GetPrivateProfileString(String Section, String Key, String Default, StringBuilder RetVal, int Size, String FilePath);
    'changed to Public declare Function 7/28/22 after 10:15pm
    Public Declare Function GetPrivateProfileString Lib "kernel32" (ByVal Section As String, ByVal Key As String, ByVal myDefault As String, ByVal RetVal As StringBuilder, ByVal size As Int32, ByVal FilePath As String) As Long

End Class
