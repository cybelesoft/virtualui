using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ExtAuth.IniFiles
{
    public class Class1
    {
        private static int NO_ERROR = 0;
        private static int ERROR_BAD_USERNAME = 2202;

        private static string CurrentAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string path = Path.GetDirectoryName(codeBase);
            return path;
        }

        [DllExport("ValidateUser", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static Int32 ValidateUser(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpUserName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpPassword,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpMetadata,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpSecurityRole,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpWinUser,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpWinPass,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpCustomData,
            [In, Out, MarshalAs(UnmanagedType.I1)] ref bool pHandled)
        {
            pHandled = true;

            // Get the current DLL pathname
            string lpFileName = CurrentAssemblyDirectory().Remove(0, 6);
            lpFileName = Path.GetDirectoryName(lpFileName);
            lpFileName = Path.GetDirectoryName(lpFileName);
            lpFileName = Path.GetDirectoryName(lpFileName);
            lpFileName = lpFileName + @"\IniFile\AllowedUsers.ini";

            // Read the stored password for the requested user
            StringBuilder lpStoredPwd = new StringBuilder();
            if (GetPrivateProfileString("USERS", lpUserName, "", lpStoredPwd, 256, lpFileName) == 0)
            {
                return ERROR_BAD_USERNAME;
            };

            // Verify if the requested password is correct
            if (lpPassword.CompareTo(lpStoredPwd.ToString()) == 0)
            {
                StringBuilder lpStoredRole = new StringBuilder();
                GetPrivateProfileString("ROLES", lpUserName, "", lpStoredRole, 256, lpFileName);
                lpSecurityRole.Append(lpStoredRole);

                lpCustomData.Append("{");
                lpCustomData.Append("\"Assigned Role\":\""+ lpStoredRole + "\", ");
                lpCustomData.Append("\"AuthenticatedBy\":\"ExtAuth.IniFiles\"");
                lpCustomData.Append("}");

                return NO_ERROR;
            }

            return ERROR_BAD_USERNAME;
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}
