using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Cybele.Thinfinity
{
    /*
    * *********************************************************************************************
    *  RemotePrinter_TLB translation
    * *********************************************************************************************
    */
    public enum Encode
    {
        PRINT_ENCODE_ANSI = 0,
        PRINT_ENCODE_UTF8 = 1
    }
    public enum PrintType
    {
        PRINT_TYPE_RAW = 1,
        PRINT_TYPE_XPS = 3,
        PRINT_TYPE_PDF = 4,
        PRINT_TYPE_DIRECT = 5
    }

    [Guid("211F21DB-409D-454A-90BB-F39C489608EA"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), ComImport]
    public interface IPrinter
    {
        bool BeginDoc(int PrintType, string PrinterName, string DocName, int Encoding, out string DocID);
        bool Print(string DocID, string Data);
        bool EndDoc(string DocID);
        bool Abort(string DocID);
        void LastError(out int ErrorCode, out string ErrorMessage);
        bool GetPrinters(string Delimiter, out string Printers);
        bool PrintFile(int PrintType, string FileName, string PrinterName);
    }

    /*
     * *********************************************************************************************
     *  RemotePrinterLibrary. Base class which loads the Thinfinity.RemotePrinter.dll
     * *********************************************************************************************
     */

    public class RemotePrinterLibrary
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        protected static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        protected static IntPtr LibHandle = IntPtr.Zero;

        public RemotePrinterLibrary()
        {
            if (LibHandle == IntPtr.Zero)
            {
                string TargetDir = GetDLLDir();
                if (TargetDir != null)
                {
                    string LibFilename = TargetDir + @"\Thinfinity.RemotePrinter.DLL";
                    LibHandle = LoadLibrary(LibFilename);
                }
            }
        }

        private static string GetDLLDir()
        {
            RegistryKey RegKey = null;
            string IniFileName = AppDomain.CurrentDomain.BaseDirectory + "\\OEM.ini";
            if (File.Exists(IniFileName))
            {
                StringBuilder sbOEMKey32 = null;
                StringBuilder sbOEMKey64 = null;
                sbOEMKey32 = new StringBuilder(1024);
                sbOEMKey64 = new StringBuilder(1024);
                GetPrivateProfileString("PATHS", "Key32", "", sbOEMKey32, sbOEMKey32.Capacity, IniFileName);
                GetPrivateProfileString("PATHS", "Key64", "", sbOEMKey64, sbOEMKey64.Capacity, IniFileName);
                if (sbOEMKey32.ToString() != "" && RegKey == null)
                {
                    string oemKey32 = sbOEMKey32.ToString();
                    if (oemKey32.StartsWith("\\"))
                        oemKey32 = oemKey32.Substring(1);
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey32, false);
                }

                if (sbOEMKey64.ToString() != "" && RegKey == null)
                {
                    string oemKey64 = sbOEMKey64.ToString();
                    if (oemKey64.StartsWith("\\"))
                        oemKey64 = oemKey64.Substring(1);
                    RegKey = Registry.LocalMachine.OpenSubKey(oemKey64, false);
                }
            }
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\RemotePrinter\Dev", false);
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cybele Software\Setups\Thinfinity\RemotePrinter\Dev", false);
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\RemotePrinter", false);
            if (RegKey == null)
                RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cybele Software\Setups\Thinfinity\RemotePrinter", false);
            if (RegKey != null)
            {
                if (IntPtr.Size == 8)
                    return (string)RegKey.GetValue("TargetDir_x64", null);
                else
                    return (string)RegKey.GetValue("TargetDir_x86", null);
            }
            else return ".";
        }
    }

    /// <summary>
    /// Main class. Has methods,and control the behavior of RemotePrinter.
    /// </summary>
    public class RemotePrinter : RemotePrinterLibrary, IDisposable
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int funcGetInstance(ref IPrinter RPrinter);
        private funcGetInstance GetInstance;

        private static RemotePrinter g_RemotePrinter;
        private static bool g_RemotePrinterExists;

        private IPrinter m_RemotePrinter;

        public RemotePrinter()
            : base()
        {
            if (!g_RemotePrinterExists)
            {
                g_RemotePrinterExists = true;
                g_RemotePrinter = new RemotePrinter();
            }
            if (LibHandle != IntPtr.Zero)
            {
                IntPtr pAddressOfFunctionToCall = GetProcAddress(LibHandle, "DllGetInstance");
                GetInstance = (funcGetInstance)Marshal.GetDelegateForFunctionPointer(
                    pAddressOfFunctionToCall,
                    typeof(funcGetInstance));
                GetInstance(ref m_RemotePrinter);
            }
        }

        ~RemotePrinter()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (m_RemotePrinter != null)
            {
                Marshal.ReleaseComObject(m_RemotePrinter);
            }
            m_RemotePrinter = null;
        }

        /// <summary>
        /// BeginDoc to initiate a print job to the remote printer. 
        /// If the print job is sent successfully, this result true.
        /// Otherwise the LastError inform that happend.
        /// the application calls EndDoc to end the print job. 
        /// </summary>
        public bool BeginDoc(int PrintType, string PrinterName, string DocName, int Encoding, out string DocID)
        {
            if (m_RemotePrinter != null)
                return m_RemotePrinter.BeginDoc(PrintType, PrinterName, DocName, Encoding, out DocID);
            else {
                DocID = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Print and send data to remote printer directly
        /// when EndDoc is called the Print Job will start.
        /// </summary>
        public bool Print(string DocID, string Data)
        {
            if (m_RemotePrinter != null)
                return m_RemotePrinter.Print(DocID, Data);
            else
                return false; 
        }

        /// <summary>
        /// EndDoc to start the remote Printer job.
        /// if Sucessfull return true. Otherwise see the error calling LastError.
        /// </summary>
        public bool EndDoc(string DocID)
        {
            if (m_RemotePrinter != null)
                return m_RemotePrinter.EndDoc(DocID);
            else
                return false;
        }

        /// <summary>
        /// You can cancel printing by calling Abort.
        /// In case of error, after StartDoc you must abort.
        /// </summary>
        public bool Abort(string DocID)
        {
            if (m_RemotePrinter != null)
                return m_RemotePrinter.Abort(DocID);
            else
                return false;
        }

        /// <summary>
        /// Its show the last error found.
        /// </summary>
        public void LastError(out int ErrorCode, out string ErrorMessage)
        {
            if (m_RemotePrinter != null)
                m_RemotePrinter.LastError(out ErrorCode, out ErrorMessage);
            else if (LibHandle == IntPtr.Zero )
            {
                ErrorCode = 126;// ERROR_MOD_NOT_FOUND;
                ErrorMessage = String.Format("The The specified module '{0}' could not be found.", "Thinfinity.RemotePrinter.dll");
            }
            else
            {
                ErrorCode = 0;
                ErrorMessage = "Unknown SDK Error";
            }
        }

        /// <summary>
        /// Gets the list of remote printers names.
        /// </summary>
        public bool GetPrinters(string Delimiter, out string Printers)
        {
            if (m_RemotePrinter != null)
                return m_RemotePrinter.GetPrinters(Delimiter, out Printers);
            else {
                Printers = String.Empty;
                return false;
            }
        }
        
        /// <summary>
        /// PrintFile send the file to the print job of the default remote printer. 
        /// If the print job is sent successfully, this result true.
        /// Otherwise the LastError inform that happend.        
        /// </summary>
        public bool PrintFile(int PrintType, string FileName, string PrinterName)
        {
            if (m_RemotePrinter != null)
                return m_RemotePrinter.PrintFile(PrintType, FileName, PrinterName);
            else {
                return false;
            }
        }

    }
}
