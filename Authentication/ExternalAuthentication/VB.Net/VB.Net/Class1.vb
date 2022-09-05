Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports RGiesecke.DllExport

Public Class EldoradoVUIAuthentication
    Private Const NO_ERROR As Int32 = 0
    Private Const ERROR_BAD_USERNAME As Int32 = 2202

    Public Shared Function CurrentAssemblyDirectory() As String
        Dim codeBase As String = Assembly.GetExecutingAssembly().CodeBase
        Dim mypath As String = Path.GetDirectoryName(codeBase)
        Return mypath
    End Function
    '<DllExport("add")>
    'Public Function TestExport(left As Int32, right As Int32) As Int32
    '    Return left + right
    'End Function

    <DllExport("ValidateUser", CallingConvention.StdCall)>
    Public Shared Function ValidateUser(
        <[In](), MarshalAs(UnmanagedType.LPWStr)> lpUserName As String,
        <[In](), MarshalAs(UnmanagedType.LPWStr)> lpPassword As String,
        <[In](), MarshalAs(UnmanagedType.LPWStr)> lpMetadata As String,
        <[In](), [Out](), MarshalAs(UnmanagedType.LPWStr)> lpSecurityRole As StringBuilder,
        <[In](), [Out](), MarshalAs(UnmanagedType.LPWStr)> lpWinUser As StringBuilder,
        <[In](), [Out](), MarshalAs(UnmanagedType.LPWStr)> lpWinPass As StringBuilder,
        <[In](), [Out](), MarshalAs(UnmanagedType.LPWStr)> lpCustomData As StringBuilder,
        <[In](), [Out](), MarshalAs(UnmanagedType.I1)> ByRef pHandled As Boolean) As Int32

        pHandled = True

        ' Get the current DLL pathname
        Dim lpFileName As String = CurrentAssemblyDirectory().Remove(0, 6)
        lpFileName = lpFileName + "\IniFile\AllowedUsers.ini"

        ' Read the stored password for the requested user
        Dim lpStoredPwd As StringBuilder = New StringBuilder()
        If GetPrivateProfileStringA("USERS", lpUserName, "NOTFOUND", lpStoredPwd, 256, lpFileName) = 0 Then Return ERROR_BAD_USERNAME
        If lpStoredPwd.ToString = "NOTFOUND" Then Return ERROR_BAD_USERNAME

        ' Verify if the requested password Is correct
        If lpPassword.CompareTo(lpStoredPwd.ToString()) = 0 Then
            Dim lpStoredRole As StringBuilder = New StringBuilder()
            GetPrivateProfileStringA("ROLES", lpUserName, "", lpStoredRole, 256, lpFileName)
            lpSecurityRole.Append(lpStoredRole)

            ' Custom data is defined by application (optional)
            lpCustomData.Append("{")
            lpCustomData.Append("""Assigned Role"":""")
            lpCustomData.Append(lpStoredRole)
            lpCustomData.Append(""", ")
            lpCustomData.Append("""AuthenticatedBy"":""ExtAuth.IniFiles""")
            lpCustomData.Append("}")

            Return NO_ERROR
        End If

        Return ERROR_BAD_USERNAME
    End Function

    '[DllImport("kernel32")]
    Public Declare Function GetPrivateProfileStringA Lib "kernel32" (ByVal Section As String, ByVal Key As String, ByVal myDefault As String, ByVal RetVal As StringBuilder, ByVal size As Int32, ByVal FilePath As String) As Long

End Class
