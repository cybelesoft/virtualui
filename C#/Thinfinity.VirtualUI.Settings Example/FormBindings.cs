using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormBindings : Form {
        private IServer m_Server;

        public FormBindings(IServer serverConfig) {
            InitializeComponent();
            m_Server = serverConfig;
            LoadBindings();
        }

        private void EnableControls() {
            BtnEdit.Enabled = LVBindings.SelectedItems.Count > 0;
            BtnRemove.Enabled = LVBindings.SelectedItems.Count > 0;
        }

        private void LoadBindings() {
            LVBindings.Items.Clear();
            for (int i = 0; i < m_Server.Bindings.Count; i++) {
                ListViewItem item = new ListViewItem();
                if (m_Server.Bindings[i].Protocol == Protocol.PROTO_HTTP)
                    item.Text = "HTTP";
                else {
                    item.Text = "HTTPS";
                }
                item.SubItems.Add(m_Server.Bindings[i].HostName);
                item.SubItems.Add(m_Server.Bindings[i].Port.ToString());
                item.SubItems.Add(m_Server.Bindings[i].IPAddress);
                if ((m_Server.Bindings[i].Protocol == Protocol.PROTO_HTTPS) && (m_Server.Bindings[i].Certificate != null))
                    item.SubItems.Add(m_Server.Bindings[i].Certificate.DisplayName);
                else {
                    item.SubItems.Add("");
                }
                item.SubItems.Add(m_Server.Bindings[i].RedirectUrl);
                LVBindings.Items.Add(item);
            }
            EnableControls();
        }

        private void LVBindings_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void LVBindings_DoubleClick(object sender, EventArgs e) {
            BtnEdit.PerformClick();
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            IBinding binding = m_Server.Bindings.Add();
            DlgBinding dlg = new DlgBinding(binding);
            if (dlg.ShowDialog() == DialogResult.OK)
                LoadBindings();
            else {
                m_Server.Bindings.Delete(binding);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            if (LVBindings.SelectedItems.Count == 0) return;
            DlgBinding dlg = new DlgBinding(m_Server.Bindings[LVBindings.SelectedItems[0].Index]);
            if (dlg.ShowDialog() == DialogResult.OK)
                LoadBindings();
        }

        private void BtnRemove_Click(object sender, EventArgs e) {
            if (LVBindings.SelectedItems.Count == 0) return;
            m_Server.Bindings.Delete(m_Server.Bindings[LVBindings.SelectedItems[0].Index]);
            LoadBindings();
        }
    }
}
