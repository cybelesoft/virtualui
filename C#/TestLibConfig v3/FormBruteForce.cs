using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormBruteForce : Form {
        private IServer m_Server;

        public FormBruteForce(IServer serverConfig) {
            InitializeComponent();
            m_Server = serverConfig;

            CheckEnabled.Checked = m_Server.BruteForceDetection.Enabled;
            UdMaxAttempts.Value = m_Server.BruteForceDetection.MaxLoginAttempts;
            UdBlocktime.Value = m_Server.BruteForceDetection.BlockTime;
            LoadLists();
            EnableControls();
        }

        private void EnableControls() {
            LblMaxAttempts.Enabled = CheckEnabled.Checked;
            UdMaxAttempts.Enabled = CheckEnabled.Checked;
            LblBlocktime.Enabled = CheckEnabled.Checked;
            UdBlocktime.Enabled = CheckEnabled.Checked;
            LblMinutes.Enabled = CheckEnabled.Checked;
            TabControlLists.Enabled = CheckEnabled.Checked;
            BtnRemoveWhite.Enabled = LVWhiteList.SelectedItems.Count > 0;
            BtnRemoveBlack.Enabled = LVBlackList.SelectedItems.Count > 0;
        }

        private void LoadLists() {
            LVWhiteList.Items.Clear();
            for (int i = 0; i < m_Server.BruteForceDetection.WhiteList.Count; i++) {
                ListViewItem item = LVWhiteList.Items.Add(m_Server.BruteForceDetection.WhiteList[i].Address);
                if (m_Server.BruteForceDetection.WhiteList[i].Persistent)
                    item.SubItems.Add("Persistent");
                else {
                    item.SubItems.Add("Runtime");
                }
            }

            LVBlackList.Items.Clear();
            for (int i = 0; i < m_Server.BruteForceDetection.BlackList.Count; i++) {
                ListViewItem item = LVBlackList.Items.Add(m_Server.BruteForceDetection.BlackList[i].Address);
                if (m_Server.BruteForceDetection.BlackList[i].Persistent)
                    item.SubItems.Add("Persistent");
                else {
                    item.SubItems.Add("Runtime");
                }
                item.SubItems.Add(m_Server.BruteForceDetection.BlackList[i].Expiration);
            }
        }

        private void CheckEnabled_CheckedChanged(object sender, EventArgs e) {
            m_Server.BruteForceDetection.Enabled = CheckEnabled.Checked;
            EnableControls();
        }

        private void UdMaxAttempts_ValueChanged(object sender, EventArgs e) {
            m_Server.BruteForceDetection.MaxLoginAttempts = (int)UdMaxAttempts.Value;
        }

        private void UdBlocktime_ValueChanged(object sender, EventArgs e) {
            m_Server.BruteForceDetection.BlockTime = (int)UdBlocktime.Value;
        }

        private void LVWhiteList_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void BtnAddWhite_Click(object sender, EventArgs e) {
            DlgInputText dlg = new DlgInputText("White List", "IP Address/Mask:");
            if (dlg.ShowDialog() == DialogResult.OK) {
                m_Server.BruteForceDetection.WhiteList.Add(dlg.InputValue);
                LoadLists();
            }
        }

        private void BtnRemoveWhite_Click(object sender, EventArgs e) {
            if (LVWhiteList.SelectedItems.Count ==0) return;
            m_Server.BruteForceDetection.WhiteList.Delete(LVWhiteList.SelectedItems[0].Index);
            LoadLists();
        }

        private void LVBlackList_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void BtnAddBlack_Click(object sender, EventArgs e) {
            DlgInputText dlg = new DlgInputText("Black List", "IP Address/Mask:");
            if (dlg.ShowDialog() == DialogResult.OK) {
                m_Server.BruteForceDetection.BlackList.Add(dlg.InputValue);
                LoadLists();
            }
        }

        private void BtnRemoveBlack_Click(object sender, EventArgs e) {
            if (LVBlackList.SelectedItems.Count == 0) return;
            m_Server.BruteForceDetection.BlackList.Delete(LVBlackList.SelectedItems[0].Index);
            LoadLists();
        }
    }
}
