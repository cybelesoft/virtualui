using Cybele.Thinfinity.Settings.VirtualUI;
using System;
using System.Windows.Forms;

namespace TestLibConfig {
    public partial class DlgCertificate : Form {
        private string m_CertStore = "";
        private string m_Thumbprint = "";

        public string CertStore {
            get { return m_CertStore; }
        }

        public string Thumbprint {
            get { return m_Thumbprint; }
        }

        public DlgCertificate() {
            InitializeComponent();
        }

        private void BtnOpenFile_Click(object sender, EventArgs e) {
            if (OpenFileDialogCert.ShowDialog() == DialogResult.OK) {
                TxtFilename.Text = OpenFileDialogCert.FileName;
            }
        }

        private void BtnImport_Click(object sender, EventArgs e) {
            if (TxtFilename.Text == "") {
                TxtFilename.Focus();
                return;
            }
            CertificateUtils certUtils = new CertificateUtils();
            if (certUtils.ImportCertificate(TxtFilename.Text, TxtPassword.Text, out m_Thumbprint, out m_CertStore))
                DialogResult = DialogResult.OK;
            else {
                MessageBox.Show("Import failed", "Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e) {
            if (TxtCommonName.Text == "") {
                TxtCommonName.Focus();
                return;
            }
            CertificateUtils certUtils = new CertificateUtils();
            if (certUtils.CreateSelfSignedCertificate("", "", TxtCommonName.Text, TxtCountryCode.Text, TxtState.Text, TxtLocality.Text,
                            TxtOrganization.Text, TxtOrganizationalUnit.Text, TxtEmail.Text, 2048, out m_Thumbprint, out m_CertStore))
                DialogResult = DialogResult.OK;
            else {
                MessageBox.Show("Create failed", "Self-signed certificate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
