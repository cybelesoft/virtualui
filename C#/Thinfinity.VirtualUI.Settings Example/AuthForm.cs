using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;
using System.Runtime.InteropServices; // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions; // PermissionSetAttribute

namespace TestLibConfig
{
    public partial class AuthForm : Form
    {
        // obtains user token
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        // closes open handes returned by LogonUser
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        private static string CUSTOM_ACCOUNT_PREFIX = "VirtualUI";
        private static int LOGON32_PROVIDER_DEFAULT = 0;
        private static int LOGON32_LOGON_NETWORK = 3;

        private Server m_VirtualUIConfig = null;

        public static bool IsCustomAccount(string UserName)
        {
            return UserName.StartsWith(CUSTOM_ACCOUNT_PREFIX) ||
                   UserName.StartsWith(System.Environment.MachineName + "\\" + CUSTOM_ACCOUNT_PREFIX);
        }

        public AuthForm(Server Server)
        {
            m_VirtualUIConfig = Server;
            InitializeComponent();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            bool found;
            string U;
            int find = 1;
            do
            {
                found = false;
                U = System.Environment.MachineName + "\\" + CUSTOM_ACCOUNT_PREFIX + find.ToString();
                for (int i=0; i < m_VirtualUIConfig.RDSAccounts.Count; i++)
                    if (m_VirtualUIConfig.RDSAccounts[i].UserName.Equals(U))
                    {
                        found = true;
                        break;
                    }
                find++;
            } while (found);
            EditRDSUserName.Text = U;
            EditRDSPassword.Text = Guid.NewGuid().ToString();
            CheckRDSCreateAccount.Checked = true;
            EditRDSUserName_TextChanged(null, null);
        }

        private void EditRDSUserName_TextChanged(object sender, EventArgs e)
        {
            CheckRDSCreateAccount.Enabled = IsCustomAccount(EditRDSUserName.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string domain, username, password;
            IntPtr token = IntPtr.Zero;

            int i = EditRDSUserName.Text.IndexOf("\\");
            if (i < 0)
            {
                domain = System.Environment.MachineName;
                username = EditRDSUserName.Text;
            }
            else
            {
                domain = EditRDSUserName.Text.Substring(0, i);
                username = EditRDSUserName.Text.Substring(i + 1);
            }
            password = EditRDSPassword.Text;
            if (CheckRDSCreateAccount.Enabled && CheckRDSCreateAccount.Checked)
            {
                EditRDSUserName.Text = domain.ToUpper() + "\\" + username;
                DialogResult = DialogResult.OK;
            }
            else if (LogonUser(username, domain, password, LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, ref token))
            {
                EditRDSUserName.Text = domain.ToUpper() + "\\" + username;
                DialogResult = DialogResult.OK;
                CloseHandle(token);
            }
            else MessageBox.Show("Error: " + Marshal.GetLastWin32Error().ToString());
        }
    }
}
