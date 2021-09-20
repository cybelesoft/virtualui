using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class DlgBinding : Form {
        private IBinding m_Binding;
        private ICertificateInfoList m_Certificates;

        public DlgBinding(IBinding binding) {
            InitializeComponent();
            m_Binding = binding;
            LoadBinding();
        }

        private void LoadBinding() {
            CbProtocol.SelectedIndex = (int)(m_Binding.Protocol);
            TxtIP.Text = m_Binding.IPAddress;
            TxtPort.Text = m_Binding.Port.ToString();
            TxtHostname.Text = m_Binding.HostName;
            CheckRedirect.Checked = (m_Binding.RedirectUrl != null) && (m_Binding.RedirectUrl.Length > 0);
            TxtRedirectUrl.Text = m_Binding.RedirectUrl;
            switch (m_Binding.RedirectStatusCode) {
                case 301: CbStatusCode.SelectedIndex = 1; break;
                case 307: CbStatusCode.SelectedIndex = 2; break;
                case 308: CbStatusCode.SelectedIndex = 3; break;
                default: CbStatusCode.SelectedIndex = 0; break;
            }
            if (m_Binding.Certificate == null)
                LoadCertificates("", "");
            else {
                LoadCertificates(m_Binding.Certificate.CertificateStore, m_Binding.Certificate.Thumbprint);
            }
            EnableControls();
        }

        private void LoadCertificates(string selectedStore, string selectedThumprint) {
            CbCertificate.Items.Clear();
            CbCertificate.Items.Add("(none)");
            CertificateUtils certUtils = new CertificateUtils();
            m_Certificates = certUtils.GetCertificates();
            for (int i = 0; i < m_Certificates.Count; i++) {
                CbCertificate.Items.Add(m_Certificates[i].DisplayName);
                if ((m_Certificates[i].CertificateStore == selectedStore) && (m_Certificates[i].Thumbprint == selectedThumprint)) {
                    CbCertificate.SelectedIndex = CbCertificate.Items.Count - 1;
                }
            }
            if (CbCertificate.SelectedIndex == -1) {
                CbCertificate.SelectedIndex = 0;
            }
        }
  
        private void EnableControls() {
            CbCertificate.Enabled = CbProtocol.SelectedIndex == 1;
            BtnAddCert.Enabled = CbProtocol.SelectedIndex == 1;
            TxtRedirectUrl.Enabled = CheckRedirect.Checked;
            CbStatusCode.Enabled = CheckRedirect.Checked;
        }

        private void CbProtocol_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void CheckRedirect_CheckedChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void BtnOk_Click(object sender, EventArgs e) {
            m_Binding.Protocol = (Protocol)(CbProtocol.SelectedIndex);
            m_Binding.IPAddress = TxtIP.Text;
            m_Binding.Port = Int32.Parse(TxtPort.Text);
            m_Binding.HostName = TxtHostname.Text;
            if (CheckRedirect.Checked) {
                m_Binding.RedirectUrl = TxtRedirectUrl.Text;
                switch (CbStatusCode.SelectedIndex) {
                    case 0: m_Binding.RedirectStatusCode = 302; break;
                    case 1: m_Binding.RedirectStatusCode = 301; break;
                    case 2: m_Binding.RedirectStatusCode = 307; break;
                    case 3: m_Binding.RedirectStatusCode = 308; break;
                }
            }
            else {
                m_Binding.RedirectUrl = "";
                m_Binding.RedirectStatusCode = 0;
            }
            if (m_Binding.Protocol == Protocol.PROTO_HTTP)
                m_Binding.Certificate = null;
            else {
                if (CbCertificate.SelectedIndex > 0)
                    m_Binding.Certificate = m_Certificates[CbCertificate.SelectedIndex - 1];    // -1 because 0 is "(none)"
                else {
                    MessageBox.Show("Please select certificate", "HTTPS Binding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void BtnAddCert_Click(object sender, EventArgs e) {
            DlgCertificate dlg = new DlgCertificate();
            if (dlg.ShowDialog() == DialogResult.OK) {
                LoadCertificates(dlg.CertStore, dlg.Thumbprint);
            }
        }
    }
}
