using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormLicense : Form {
        private IServer m_Server;

        public FormLicense(IServer serverConfig) {
            InitializeComponent();
            m_Server = serverConfig;

            if (m_Server.License.ServerUrl != null) {
                int p = m_Server.License.ServerUrl.IndexOf(";");
                if (p < 0) {
                    TxtLicenseServerPrimary.Text = m_Server.License.ServerUrl;
                    TxtLicenseServerBackup.Text = "";
                }
                else {
                    TxtLicenseServerPrimary.Text = m_Server.License.ServerUrl.Substring(0, p);
                    TxtLicenseServerBackup.Text = m_Server.License.ServerUrl.Substring(p + 1);
                }
            }
            UpdateLicenseInfo();
        }

        private void UpdateLicenseInfo() {
            TextLicenseInfo.Text = "";
            TextLicenseInfo.Text += "CustomerID: " + m_Server.License.CustomerID + "\r\n";
            TextLicenseInfo.Text += "Serial    : " + m_Server.License.SerialStr + "\r\n";
            if ((m_Server.License.Expiration != null) && (m_Server.License.Expiration.Length > 0)) {
                TextLicenseInfo.Text += "Expiration: " + m_Server.License.Expiration + "\r\n";
            }
            if (!m_Server.License.IsValid) {
                TextLicenseInfo.Text += "The License is invalid\r\n";
            }
            TextLicenseInfo.Text += "\r\n";
            //TextLicenseInfo.Text += "Limits:\r\n";
            //TextLicenseInfo.Text += m_VirtualUIConfig.License.Limits["Users"].ToString() + " Users\r\n";
            //TextLicenseInfo.Text += m_VirtualUIConfig.License.Limits["Servers"].ToString() + " Servers\r\n";
            //TextLicenseInfo.Text += "\r\n";
            //TextLicenseInfo.Text += "Features:\r\n";
            //TextLicenseInfo.Text += "v2.0 " + (m_VirtualUIConfig.License.Features["v2.0"] > 0 ? "Enabled" : "Disabled") + "\r\n";
        }

        private void ButtonSetLSUrl_Click(object sender, EventArgs e) {
            m_Server.License.ServerUrl = TxtLicenseServerPrimary.Text;
            if (TxtLicenseServerBackup.Text != "") {
                m_Server.License.ServerUrl = m_Server.License.ServerUrl + ";" + TxtLicenseServerBackup.Text;
            }
        }

        private void ButLicActivate_Click(object sender, EventArgs e) {
            ButLicActivate.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            int resCode;
            string resString;
            m_Server.License.Activate(TxtCustomerID.Text, TxtSerial.Text, out resCode, out resString);

            Cursor.Current = Cursors.Default;
            ButLicActivate.Enabled = true;
            MessageBox.Show(resString, "Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateLicenseInfo();
        }

        private void ButDeactivate_Click(object sender, EventArgs e) {
            m_Server.License.Deactivate();
            UpdateLicenseInfo();
        }

        private void BtnGenManualKey_Click(object sender, EventArgs e) {
            BtnGenManualKey.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            m_Server.License.SerialStr = TxtManualSerial.Text;
            TxtManualKey.Text = m_Server.License.GetManualActivationKey();
            Cursor.Current = Cursors.Default;
            BtnGenManualKey.Enabled = true;
        }

        private void BtnActivateManual_Click(object sender, EventArgs e) {
            BtnActivateManual.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            int resCode;
            string resString;
            m_Server.License.ActivateManual(TextLicenseData.Text, out resCode, out resString);

            Cursor.Current = Cursors.Default;
            BtnActivateManual.Enabled = true;
            MessageBox.Show(resString, "Manual Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateLicenseInfo();
        }
    }
}
