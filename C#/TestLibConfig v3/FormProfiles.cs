using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormProfiles : Form {
        private IServer m_Server;

        public FormProfiles(IServer serverConfig) {
            InitializeComponent();
            m_Server = serverConfig;
            UpdateProfilesList();
        }

        private void UpdateProfilesList() {
            LVProfiles.Items.Clear();
            for (int i = 0; i < m_Server.Profiles.Count; i++) {
                ListViewItem item = new ListViewItem();
                item.Checked = m_Server.Profiles[i].Enabled;
                item.Text = m_Server.Profiles[i].Name;
                if (m_Server.Profiles[i].ProfileKind == ProfileKind.PROFILE_APP)
                    item.SubItems.Add(m_Server.Profiles[i].FileName);
                else {
                    item.SubItems.Add(m_Server.Profiles[i].WebLink);
                }
                LVProfiles.Items.Add(item);
            }
            BtnEdit.Enabled = false;
            BtnRemove.Enabled = false;
        }

        private void LVProfiles_ItemChecked(object sender, ItemCheckedEventArgs e) {
            m_Server.Profiles[e.Item.Index].Enabled = e.Item.Checked;
        }

        private void LVProfiles_SelectedIndexChanged(object sender, EventArgs e) {
            BtnEdit.Enabled = LVProfiles.SelectedItems.Count > 0;
            BtnRemove.Enabled = LVProfiles.SelectedItems.Count > 0;
        }

        private void BtnNew_Click(object sender, EventArgs e) {
            IProfile p = m_Server.Profiles.Add();
            DlgProfile dlg = new DlgProfile(m_Server, p);
            if (dlg.ShowDialog() == DialogResult.OK)
                UpdateProfilesList();
            else {
                m_Server.Profiles.Delete(p);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            if (LVProfiles.SelectedItems.Count == 0) return;
            IProfile p = m_Server.Profiles[LVProfiles.SelectedItems[0].Index];
            DlgProfile dlg = new DlgProfile(m_Server, p);
            if (dlg.ShowDialog() == DialogResult.OK) {
                LVProfiles.SelectedItems[0].Checked = p.Enabled;
                LVProfiles.SelectedItems[0].Text = p.Name;
                if (p.ProfileKind == ProfileKind.PROFILE_APP)
                    LVProfiles.SelectedItems[0].SubItems[1].Text = p.FileName;
                else {
                    LVProfiles.SelectedItems[0].SubItems[1].Text = p.WebLink;
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e) {
            if (LVProfiles.SelectedItems.Count == 0) return;
            m_Server.Profiles.Delete(m_Server.Profiles[LVProfiles.SelectedItems[0].Index]);
            LVProfiles.SelectedItems[0].Remove();
        }

        private void LVProfiles_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter: BtnEdit.PerformClick(); break;
                case Keys.Delete: BtnRemove.PerformClick(); break;
            }
        }
    }
}
