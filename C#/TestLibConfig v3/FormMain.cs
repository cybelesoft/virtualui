using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig
{
    public partial class FormMain : Form
    {
        private Server m_VirtualUIConfig = new Server();

        public FormMain() {
            InitializeComponent();
            ComboSectionHide.SelectedIndex = 0;
            ComboSectionShow.SelectedIndex = 0;
            CbServices.SelectedIndex = 0;
            ShowSettings();
        }

        private void ShowSettings() {
            TxtAPIKey.Text = m_VirtualUIConfig.APIKey;
            switch (m_VirtualUIConfig.SetupMode) {
                case SetupMode.SETUP_NONE:          LblSetupMode.Text = "Setup mode: Not installed"; break;
                case SetupMode.SETUP_LOADBALANCING: LblSetupMode.Text = "Setup mode: Load Balancing"; break;
                case SetupMode.SETUP_STANDALONE:    LblSetupMode.Text = "Setup mode: Standalone"; break;
            }
        }

        private void ButHideSection_Click(object sender, EventArgs e) {
            m_VirtualUIConfig.HideSection((ServerSection)(ComboSectionHide.SelectedIndex));
        }

        private void ButShowSection_Click(object sender, EventArgs e) {
            m_VirtualUIConfig.ShowSection((ServerSection)(ComboSectionHide.SelectedIndex));
        }

        private void BtnBindings_Click(object sender, EventArgs e) {
            FormBindings form = new FormBindings(m_VirtualUIConfig);
            form.ShowDialog();
        }

        private void BtnAuthentication_Click(object sender, EventArgs e) {
            FormAuthentication form = new FormAuthentication(m_VirtualUIConfig);
            form.ShowDialog();
        }

        private void BtnBroker_Click(object sender, EventArgs e) {
            FormBroker form = new FormBroker(m_VirtualUIConfig);
            form.ShowDialog();
        }

        private void BtnSessions_Click(object sender, EventArgs e) {
            FormSessions form = new FormSessions(m_VirtualUIConfig.Broker);
            form.ShowDialog();
        }

        private void BtnFolders_Click(object sender, EventArgs e) {
            FormFolders form = new FormFolders(m_VirtualUIConfig.Broker);
            form.ShowDialog();
        }

        private void BtnProfiles_Click(object sender, EventArgs e) {
            FormProfiles form = new FormProfiles(m_VirtualUIConfig);
            form.ShowDialog();
        }

        private void BtnLicense_Click(object sender, EventArgs e) {
            FormLicense form = new FormLicense(m_VirtualUIConfig);
            form.ShowDialog();
        }

        private void BtnBruteForce_Click(object sender, EventArgs e) {
            FormBruteForce form = new FormBruteForce(m_VirtualUIConfig);
            form.ShowDialog();
        }

        private void BtnDiscard_Click(object sender, EventArgs e) {
            m_VirtualUIConfig.Load();
            ShowSettings();
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            m_VirtualUIConfig.Save();
        }

        private void TxtAPIKey_TextChanged(object sender, EventArgs e) {
            m_VirtualUIConfig.APIKey = TxtAPIKey.Text;
        }

        private void BtnEnableService_Click(object sender, EventArgs e) {
            m_VirtualUIConfig.EnableService((Service)(CbServices.SelectedIndex), true);
        }

        private void BtnDisableService_Click(object sender, EventArgs e) {
            m_VirtualUIConfig.EnableService((Service)(CbServices.SelectedIndex), false);
        }
    }
}