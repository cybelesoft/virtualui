using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class DlgBrokerPool : Form {
        private IBroker m_Broker;

        public DlgBrokerPool(IBroker broker) {
            InitializeComponent();
            m_Broker = broker;

            TxtPoolName.Text = m_Broker.PoolName;
            UdUsersLimit.Value = m_Broker.UsersLimit;
            CheckDefault.Checked = m_Broker.Default;
            if (m_Broker.LoadBalancingMethod == LoadBalancingMethod.BREADTH_FIRST)
                RbBreadthFirst.Checked = true;
            else {
                RbDepthFirst.Checked = true;
            }
        }

        private void TxtPoolName_TextChanged(object sender, EventArgs e) {
            m_Broker.PoolName = TxtPoolName.Text;
        }

        private void UdUsersLimit_ValueChanged(object sender, EventArgs e) {
            m_Broker.UsersLimit = (int)(UdUsersLimit.Value);
        }

        private void CheckDefault_CheckedChanged(object sender, EventArgs e) {
            m_Broker.Default = CheckDefault.Checked;
        }

        private void RbBreadthFirst_CheckedChanged(object sender, EventArgs e) {
            m_Broker.LoadBalancingMethod = LoadBalancingMethod.BREADTH_FIRST;
        }

        private void RbDepthFirst_CheckedChanged(object sender, EventArgs e) {
            m_Broker.LoadBalancingMethod = LoadBalancingMethod.DEPTH_FIRST;
        }

        private void BtnSessions_Click(object sender, EventArgs e) {
            FormSessions form = new FormSessions(m_Broker);
            form.ShowDialog();
        }

        private void BtnFolders_Click(object sender, EventArgs e) {
            FormFolders form = new FormFolders(m_Broker);
            form.ShowDialog();
        }
    }
}
