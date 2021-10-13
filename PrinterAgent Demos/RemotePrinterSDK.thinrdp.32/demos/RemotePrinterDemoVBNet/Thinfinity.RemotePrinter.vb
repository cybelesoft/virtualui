Imports Microsoft.Win32
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text
Imports System.ComponentModel
Imports System.Threading

Namespace Cybele.Thinfinity
    '
    '     * *********************************************************************************************
    '     *  Thinfinity_TLB translation
    '     * *********************************************************************************************
    '
    Public Enum Encode
        PRINT_ENCODE_ANSI = 0
        PRINT_ENCODE_UTF8 = 1
    End Enum

    Public Enum PrintType
        PRINT_TYPE_RAW = 1
    End Enum

    <Guid("211F21DB-409D-454A-90BB-F39C489608EA"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), ComImport>
    Public Interface IPrinter
        Function BeginDoc(PrintType As Integer, PrinterName As String, DocName As String, Encoding As Integer, ByRef DocID As String) As Boolean
        Function Print(DocID As String, Data As String) As Boolean
        Function EndDoc(DocID As String) As Boolean
        Function Abort(DocID As String) As Boolean
        Sub LastError(ByRef ErrorCode As Integer, ByRef ErrorMessage As String)
        Function GetPrinters(Delimiter As String, ByRef Printers As String)

    End Interface

    '
    '     * *********************************************************************************************
    '     *  VirtualUILibrary. Base class which loads the Thinfinity.VirtualUI.dll
    '     * *********************************************************************************************
    '
    Public Class RemotePrinterLibrary
        <DllImport("kernel32.dll")>
        Private Shared Function LoadLibrary(dllToLoad As String) As IntPtr
        End Function
        <DllImport("kernel32.dll")>
        Protected Shared Function GetProcAddress(hModule As IntPtr, procedureName As String) As IntPtr
        End Function
        <DllImport("kernel32.dll")>
        Private Shared Function FreeLibrary(hModule As IntPtr) As Boolean
        End Function
        <DllImport("kernel32.dll")>
        Private Shared Function GetPrivateProfileString(lpAppName As String,
                    lpKeyName As String,
                    lpDefault As String,
                    lpReturnedString As StringBuilder,
                    nSize As Integer,
                    lpFileName As String) As Integer
        End Function

        Protected Shared LibHandle As IntPtr = IntPtr.Zero
        Public Sub New()
            If LibHandle = IntPtr.Zero Then
                Dim TargetDir As String = GetDLLDir()
                If TargetDir IsNot Nothing Then
                    Dim LibFilename As String = TargetDir & "\Thinfinity.RemotePrinter.DLL"
                    LibHandle = LoadLibrary(LibFilename)
                    If LibHandle <> IntPtr.Zero Then
                    End If
                End If
            End If
        End Sub

        Private Shared Function GetDLLDir() As String
            Dim RegKey As RegistryKey = Nothing
            Dim IniFileName As String
            IniFileName = AppDomain.CurrentDomain.BaseDirectory + "\OEM.ini"
            If File.Exists(IniFileName) Then
                Dim sbOEMKey32 As StringBuilder
                Dim sbOEMKey64 As StringBuilder
                sbOEMKey32 = New StringBuilder(1024)
                sbOEMKey64 = New StringBuilder(1024)
                GetPrivateProfileString("PATHS", "Key32", "", sbOEMKey32, sbOEMKey32.Capacity, IniFileName)
                GetPrivateProfileString("PATHS", "Key64", "", sbOEMKey64, sbOEMKey64.Capacity, IniFileName)
                If sbOEMKey32.ToString() <> "" AndAlso RegKey Is Nothing Then
                    Dim oemKey32 As String = sbOEMKey32.ToString()
                    If oemKey32.StartsWith("\") Then
                        oemKey32 = oemKey32.Substring(1)
                    End If
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey32, False)
                End If
                If sbOEMKey64.ToString() <> "" AndAlso RegKey Is Nothing Then
                    Dim oemKey64 As String = sbOEMKey64.ToString()
                    If oemKey64.StartsWith("\") Then
                        oemKey64 = oemKey64.Substring(1)
                    End If
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey64, False)
                End If
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\RemotePrinter\Dev", False)
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Cybele Software\Setups\Thinfinity\RemotePrinter\Dev", False)
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\RemotePrinter", False)
            End If
            If RegKey Is Nothing Then
                RegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Cybele Software\Setups\Thinfinity\RemotePrinter", False)
            End If
            If RegKey IsNot Nothing Then
                If IntPtr.Size = 8 Then
                    Return DirectCast(RegKey.GetValue("TargetDir_x64", Nothing), String)
                Else
                    Return DirectCast(RegKey.GetValue("TargetDir_x86", Nothing), String)
                End If
            Else
                Return "."
            End If

        End Function
    End Class

    Public Class RemotePrinter
        Inherits RemotePrinterLibrary
        Implements IDisposable
        <UnmanagedFunctionPointer(CallingConvention.StdCall)>
        Private Delegate Function funcGetInstance(ByRef RPrinter As IPrinter) As Integer
        Private GetInstance As funcGetInstance

        Private Shared g_RemotePrinter As RemotePrinter
        Private Shared g_RemotePrinterExists As Boolean

        Private m_RemotePrinter As IPrinter

        Public Sub New()
            MyBase.New()
            If Not g_RemotePrinterExists Then
                g_RemotePrinterExists = True
                g_RemotePrinter = New RemotePrinter()
            End If
            If LibHandle <> IntPtr.Zero Then
                Dim pAddressOfFunctionToCall As IntPtr = GetProcAddress(LibHandle, "DllGetInstance")
                GetInstance = DirectCast(Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, GetType(funcGetInstance)), funcGetInstance)
                GetInstance(m_RemotePrinter)
            End If
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_RemotePrinter IsNot Nothing Then
                Marshal.ReleaseComObject(m_RemotePrinter)
            End If
            m_RemotePrinter = Nothing
        End Sub

        ''' <summary>
        ''' BeginDoc to initiate a print job to the remote printer. 
        ''' If the print job Is sent successfully, this result true.
        ''' Otherwise the LastError inform that happend.
        ''' the application calls EndDoc to end the print job.     
        ''' </summary>
        Public Function BeginDoc(PrintType As Integer, PrinterName As String, DocName As String, Encoding As Integer, ByRef DocID As String) As Boolean
            If m_RemotePrinter IsNot Nothing Then
                Return m_RemotePrinter.BeginDoc(PrintType, PrinterName, DocName, Encoding, DocID)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Print and send data to remote printer directly
        ''' when EndDoc is called the Print Job will start.   
        ''' </summary>
        Public Function Print(DocID As String, Data As String) As Boolean
            If m_RemotePrinter IsNot Nothing Then
                Return m_RemotePrinter.Print(DocID, Data)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' EndDoc to start the remote Printer job.
        ''' if Sucessfull return true. Otherwise see the error calling LastError.  
        ''' </summary>
        Public Function EndDoc(DocID As String) As Boolean
            If m_RemotePrinter IsNot Nothing Then
                Return m_RemotePrinter.EndDoc(DocID)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        '''You can cancel printing by calling Abort.
        ''' In case of error, after StartDoc you must abort.
        ''' </summary>
        Public Function Abort(DocID As String) As Boolean
            If m_RemotePrinter IsNot Nothing Then
                Return m_RemotePrinter.Abort(DocID)
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Its return the last Error found.
        ''' </summary>
        Public Sub LastError(ByRef ErrorCode As Integer, ByRef ErrorMessage As String)
            If m_RemotePrinter IsNot Nothing Then
                m_RemotePrinter.LastError(ErrorCode, ErrorMessage)
            Else
                ErrorCode = 0
                ErrorMessage = String.Empty
            End If
        End Sub


        ''' <summary>
        ''' Gets the list of remote printers names.
        ''' </summary>
        Public Function GetPrinters(Delimiter As String, ByRef Printers As String) As Boolean
            If m_RemotePrinter IsNot Nothing Then
                Return m_RemotePrinter.GetPrinters(Delimiter, Printers)
            Else
                Printers = String.Empty
                Return False
            End If
        End Function
    End Class

End Namespace