using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormSessions : Form {
        private IBroker m_Broker;

        public FormSessions(IBroker broker) {
            InitializeComponent();
            m_Broker = broker;

            if (m_Broker.Primary)
                CbSessionMode.SelectedIndex = (int)m_Broker.RDS.SessionMode;
            else {
                CbSessionMode.SelectedIndex = 1;
                CbSessionMode.Enabled = false;
            }
            CheckThirdPartyApps.Checked = m_Broker.RDS.ThirdPartyApps;

            switch (m_Broker.RDS.SessionAccount) {
                case SessionAccount.SESSION_ACCOUNT_CUSTOM: RbCustomAccount.Checked = true; break;
                case SessionAccount.SESSION_ACCOUNT_LOGGED: RbLoggedUserAccount.Checked = true; break;
                case SessionAccount.SESSION_ACCOUNT_CONSOLE: RbConsoleSession.Checked = true; break;
            }

            CheckEnableAL.Checked = m_Broker.RDS.AutoLogon.Enabled;
            TxtALUser.Text = m_Broker.RDS.AutoLogon.UserName;
            TxtALPass.Text = m_Broker.RDS.AutoLogon.Password;
            TxtALShell.Text = m_Broker.RDS.AutoLogon.Shell;

            TxtUsername.Text = m_Broker.RDS.UserName;
            TxtPassword.Text = m_Broker.RDS.Password;
            EnableControls();
        }

        private bool OneSessionAndBrokerSecondary() {
            return (m_Broker.UsersLimit == 1) && (!m_Broker.Primary);
        }

        private void EnableControls() {
            CheckThirdPartyApps.Enabled = CbSessionMode.SelectedIndex == 1;

            RbLoggedUserAccount.Enabled = CbSessionMode.SelectedIndex == 1;
            if (RbLoggedUserAccount.Checked && !RbLoggedUserAccount.Enabled)
                RbCustomAccount.Checked = true;

            RbConsoleSession.Enabled = (CbSessionMode.SelectedIndex == 0) || OneSessionAndBrokerSecondary();
            if (RbConsoleSession.Checked && !RbConsoleSession.Enabled)
                RbCustomAccount.Checked = true;

            LblUsername.Enabled = RbCustomAccount.Checked;
            TxtUsername.Enabled = RbCustomAccount.Checked;
            LblPassword.Enabled = RbCustomAccount.Checked;
            TxtPassword.Enabled = RbCustomAccount.Checked;

            CheckEnableAL.Enabled = RbConsoleSession.Checked;
            LblALUser.Enabled = RbConsoleSession.Checked && CheckEnableAL.Checked;
            TxtALUser.Enabled = RbConsoleSession.Checked && CheckEnableAL.Checked;
            LblALPass.Enabled = RbConsoleSession.Checked && CheckEnableAL.Checked;
            TxtALPass.Enabled = RbConsoleSession.Checked && CheckEnableAL.Checked;
            LblALShell.Enabled = RbConsoleSession.Checked && CheckEnableAL.Checked;
            TxtALShell.Enabled = RbConsoleSession.Checked && CheckEnableAL.Checked;
        }

        private void RbLoggedUserAccount_CheckedChanged(object sender, EventArgs e) {
            m_Broker.RDS.SessionAccount = SessionAccount.SESSION_ACCOUNT_LOGGED;
            EnableControls();
        }

        private void RbCustomAccount_CheckedChanged(object sender, EventArgs e) {
            m_Broker.RDS.SessionAccount = SessionAccount.SESSION_ACCOUNT_CUSTOM;
            EnableControls();
        }

        private void RbConsoleSession_CheckedChanged(object sender, EventArgs e) {
            m_Broker.RDS.SessionAccount = SessionAccount.SESSION_ACCOUNT_CONSOLE;
            EnableControls();
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e) {
            m_Broker.RDS.UserName = TxtUsername.Text;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e) {
            m_Broker.RDS.Password = TxtPassword.Text;
        }

        private void CbSessionMode_SelectedIndexChanged(object sender, EventArgs e) {
            m_Broker.RDS.SessionMode = (SessionMode)(CbSessionMode.SelectedIndex);
            EnableControls();
        }

        private void CheckThirdPartyApps_CheckedChanged(object sender, EventArgs e) {
            m_Broker.RDS.ThirdPartyApps = CheckThirdPartyApps.Checked;
        }

        private void CheckEnableAL_CheckedChanged(object sender, EventArgs e) {
            m_Broker.RDS.AutoLogon.Enabled = CheckEnableAL.Checked;
            EnableControls();
        }

        private void TxtALUser_TextChanged(object sender, EventArgs e) {
            m_Broker.RDS.AutoLogon.UserName = TxtALUser.Text;
        }

        private void TxtALPass_TextChanged(object sender, EventArgs e) {
            m_Broker.RDS.AutoLogon.Password = TxtALPass.Text;
        }

        private void TxtALShell_TextChanged(object sender, EventArgs e) {
            m_Broker.RDS.AutoLogon.Shell = TxtALShell.Text;
        }
    }
}
