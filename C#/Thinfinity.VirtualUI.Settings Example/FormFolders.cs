using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormFolders : Form {
        private IBroker m_Broker;

        public FormFolders(IBroker broker) {
            InitializeComponent();
            m_Broker = broker;
            TxtSharedFolder.Text = m_Broker.TmpFiles.Path;
            TxtUsername.Text = m_Broker.TmpFiles.UserName;
            TxtPassword.Text = m_Broker.TmpFiles.Password;
        }

        private void TxtSharedFolder_TextChanged(object sender, EventArgs e) {
            m_Broker.TmpFiles.Path = TxtSharedFolder.Text;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e) {
            m_Broker.TmpFiles.UserName = TxtUsername.Text;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e) {
            m_Broker.TmpFiles.Password = TxtPassword.Text;
        }
    }
}
