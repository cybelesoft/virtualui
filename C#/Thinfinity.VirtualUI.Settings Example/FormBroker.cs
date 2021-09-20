using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormBroker : Form {
        private IServer m_Server;

        public FormBroker(IServer serverConfig) {
            InitializeComponent();
            m_Server = serverConfig;

            if (m_Server.Broker.Primary)
                RbPrimary.Checked = true;
            else {
                RbSecondary.Checked = true;
            }
            UdUsersLimit.Value = m_Server.Broker.UsersLimit;
            TxtPoolName.Text = m_Server.Broker.PoolName;
            LoadPoolList();

            TxtNetworkID.Text = m_Server.NetworkID;
            LVGateways.Items.Clear();
            for (int i = 0; i < m_Server.Gateways.Count; i++) {
                LVGateways.Items.Add(m_Server.Gateways[i]);
            }
            EnableControls();
        }

        private void EnableControls() {
            LblUsersLimit.Enabled = RbPrimary.Checked;
            UdUsersLimit.Enabled = RbPrimary.Checked;
            LblPoolList.Enabled = RbPrimary.Checked;
            LvPools.Enabled = RbPrimary.Checked;
            BtnAddPool.Enabled = RbPrimary.Checked;
            BtnEditPool.Enabled = RbPrimary.Checked;
            BtnRemovePool.Enabled = RbPrimary.Checked;
            BtnEditPool.Enabled = RbPrimary.Checked && (LvPools.SelectedItems.Count > 0);
            BtnRemovePool.Enabled = RbPrimary.Checked && (LvPools.SelectedItems.Count > 0);

            LblPoolName.Enabled = !RbPrimary.Checked;
            TxtPoolName.Enabled = !RbPrimary.Checked;

            BtnRemove.Enabled = LVGateways.SelectedItems.Count > 0;
        }

        private void LoadPoolList() {
            LvPools.Items.Clear();
            for (int i = 0; i < m_Server.SecondaryBrokers.Count; i++) {
                ListViewItem item = new ListViewItem(m_Server.SecondaryBrokers[i].PoolName);
                item.SubItems.Add(m_Server.SecondaryBrokers[i].UsersLimit.ToString());
                item.SubItems.Add(m_Server.SecondaryBrokers[i].LoadBalancingMethod == LoadBalancingMethod.BREADTH_FIRST ? "breadth-first" : "depth-first");
                item.SubItems.Add(m_Server.SecondaryBrokers[i].Default ? "yes" : "");
                LvPools.Items.Add(item);
            }
            EnableControls();
        }

        private void TxtPoolName_TextChanged(object sender, EventArgs e) {
            m_Server.Broker.PoolName = TxtPoolName.Text;
        }

        private void UdUsersLimit_ValueChanged(object sender, EventArgs e) {
            m_Server.Broker.UsersLimit = (int)UdUsersLimit.Value;
        }

        private void TxtNetworkID_TextChanged(object sender, EventArgs e) {
            m_Server.NetworkID = TxtNetworkID.Text;
        }

        private void LVGateways_SelectedIndexChanged(object sender, EventArgs e) {
            BtnRemove.Enabled = LVGateways.SelectedItems.Count > 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            DlgInputText dlg = new DlgInputText("Add Gateway", "Gateway URL:");
            if (dlg.ShowDialog() == DialogResult.OK) {
                m_Server.Gateways.Add(dlg.InputValue);
                LVGateways.Items.Add(dlg.InputValue);
                EnableControls();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e) {
            if (LVGateways.SelectedItems.Count == 0) return;
            m_Server.Gateways.Delete(LVGateways.SelectedItems[0].Index);
            LVGateways.SelectedItems[0].Remove();
            EnableControls();
        }

        private void RbPrimary_CheckedChanged(object sender, EventArgs e) {
            m_Server.Broker.Primary = true;
            EnableControls();
        }

        private void RbSecondary_CheckedChanged(object sender, EventArgs e) {
            m_Server.Broker.Primary = false;
            EnableControls();
        }

        private void LvPools_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void LvPools_MouseDoubleClick(object sender, MouseEventArgs e) {
            BtnEditPool.PerformClick();
        }

        private void BtnAddPool_Click(object sender, EventArgs e) {
            IBroker secBroker = m_Server.SecondaryBrokers.Add();
            secBroker.UsersLimit = 10000;
            DlgBrokerPool dlg = new DlgBrokerPool(secBroker);
            if (dlg.ShowDialog() == DialogResult.OK)
                LoadPoolList();
            else {
                m_Server.SecondaryBrokers.Delete(secBroker);
            }
        }

        private void BtnEditPool_Click(object sender, EventArgs e) {
            if (LvPools.SelectedItems.Count > 0) {
                DlgBrokerPool dlg = new DlgBrokerPool(m_Server.SecondaryBrokers[LvPools.SelectedItems[0].Index]);
                if (dlg.ShowDialog() == DialogResult.OK)
                    LoadPoolList();
            }
        }

        private void BtnRemovePool_Click(object sender, EventArgs e) {
            if (LvPools.SelectedItems.Count > 0) {
                m_Server.SecondaryBrokers.Delete(m_Server.SecondaryBrokers[LvPools.SelectedItems[0].Index]);
                LoadPoolList();
            }
        }
    }
}
