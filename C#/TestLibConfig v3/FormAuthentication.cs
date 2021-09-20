using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class FormAuthentication : Form {
        private IServer m_Server;

        public FormAuthentication(IServer serverConfig) {
            InitializeComponent();
            m_Server = serverConfig;
            CheckAllowAnonymous.Checked = m_Server.Authentication.AllowAnonymous;
            CbMethodId.SelectedIndex = 0;
            CbPermissionType.SelectedIndex = 0;
            Cb2FAMethod.SelectedIndex = 0;
            UpdateAuthMethodsList();
            Update2FAMethodsList();
            UpdateMappingsList();
            EnableMappingControls();
        }

        private void UpdateAuthMethodsList() {
            LVAuthMethods.Items.Clear();
            for (int i = 0; i < m_Server.Authentication.AuthMethods.Count; i++) {
                ListViewItem item = new ListViewItem();
                item.Text = m_Server.Authentication.AuthMethods[i].Name;
                item.SubItems.Add(m_Server.Authentication.AuthMethods[i].VirtualPath);
                item.SubItems.Add(m_Server.Authentication.AuthMethods[i].SecondFactorMethod);
                item.Checked = m_Server.Authentication.AuthMethods[i].Enabled;
                LVAuthMethods.Items.Add(item);
            }
            BtnRemoveAuth.Enabled = false;
            BtnEditMethod.Enabled = false;
            BtnApplySettings.Enabled = false;
            TxtSettings.Text = "";
        }

        private void Update2FAMethodsList() {
            LV2FAMethods.Items.Clear();
            for (int i = 0; i < m_Server.Authentication.SecondFactorMethods.Count; i++) {
                ListViewItem item = new ListViewItem();
                item.Text = m_Server.Authentication.SecondFactorMethods[i].Name;
                item.Checked = m_Server.Authentication.SecondFactorMethods[i].Enabled;
                LV2FAMethods.Items.Add(item);
            }
            Enable2FAControls();
            Txt2FASettings.Text = "";
        }

        private void UpdateMappingsList() {
            LVMapMasks.Items.Clear();
            for (int i = 0; i < m_Server.Authentication.SSOUsers.Count; i++) {
                ListViewItem item = new ListViewItem();
                item.Text = m_Server.Authentication.SSOUsers[i].RemoteUser;
                item.SubItems.Add(m_Server.Authentication.SSOUsers[i].MethodId);
                item.Checked = m_Server.Authentication.SSOUsers[i].Enabled;
                LVMapMasks.Items.Add(item);
            }
            LVMapPermissions.Items.Clear();
        }

        private void EnableMappingControls() {
            bool B = LVMapMasks.SelectedItems.Count > 0;
            BtnAddMapPerm.Enabled = B;
            CbPermissionType.Enabled = B;
            TxtPermissionName.Enabled = B;
            LblWinUsername.Enabled = B;
            TxtWinUsername.Enabled = B;
            LblWinPassword.Enabled = B;
            TxtWinPassword.Enabled = B;
            BtnSetWinCredentials.Enabled = B;
            BtnRemoveWinCredentials.Enabled = B;
        }

        void Enable2FAControls() {
            bool sel = LV2FAMethods.SelectedItems.Count > 0;
            BtnRemove2FA.Enabled = sel;
            Lbl2FASettings.Enabled = sel;
            Txt2FASettings.Enabled = sel;
            BtnApply2FA.Enabled = sel;
            Lbl2FAUserName.Enabled = sel;
            Ed2FAUserName.Enabled = sel;
            BtnReset2FAUser.Enabled = sel;
        }

        private void BtnddAuth_Click(object sender, EventArgs e) {
            FormAddAuthMethod form = new FormAddAuthMethod(m_Server, true);
            if (form.ShowDialog() == DialogResult.OK) {
                IAuthMethod am = m_Server.Authentication.AuthMethods.Add(form.Method);
                am.Name = form.MethodName;
                am.VirtualPath = form.VirtualPath;
                am.SecondFactorMethod = form.SecondFactorMethod;
                UpdateAuthMethodsList();
                LVAuthMethods.Items[LVAuthMethods.Items.Count - 1].Selected = true;
            }
        }

        private void BtnEditMethod_Click(object sender, EventArgs e) {
            IAuthMethod am = m_Server.Authentication.AuthMethods[LVAuthMethods.SelectedItems[0].Index];
            FormAddAuthMethod form = new FormAddAuthMethod(m_Server, false);
            form.Method = am.MethodId;
            form.MethodName = am.Name;
            form.VirtualPath = am.VirtualPath;
            form.SecondFactorMethod = am.SecondFactorMethod;
            if (form.ShowDialog() == DialogResult.OK) {
                am.Name = form.MethodName;
                am.VirtualPath = form.VirtualPath;
                am.SecondFactorMethod = form.SecondFactorMethod;
                UpdateAuthMethodsList();
            }
        }

        private void BtnRemoveAuth_Click(object sender, EventArgs e) {
            IAuthMethods am = m_Server.Authentication.AuthMethods;
            am.Remove(am[LVAuthMethods.SelectedItems[0].Index]);
            LVAuthMethods.SelectedItems[0].Remove();
        }

        private void BtnApplySettings_Click(object sender, EventArgs e) {
            m_Server.Authentication.AuthMethods[LVAuthMethods.SelectedItems[0].Index].Settings = TxtSettings.Text;
        }

        private void CheckAllowAnonymous_CheckedChanged(object sender, EventArgs e) {
            m_Server.Authentication.AllowAnonymous = CheckAllowAnonymous.Checked;
        }

        private void LVAuthMethods_ItemChecked(object sender, ItemCheckedEventArgs e) {
            m_Server.Authentication.AuthMethods[e.Item.Index].Enabled = e.Item.Checked;
        }

        private void LVAuthMethods_SelectedIndexChanged(object sender, EventArgs e) {
            BtnRemoveAuth.Enabled = LVAuthMethods.SelectedItems.Count > 0;
            BtnEditMethod.Enabled = LVAuthMethods.SelectedItems.Count > 0;
            BtnApplySettings.Enabled = LVAuthMethods.SelectedItems.Count > 0;
            if (LVAuthMethods.SelectedItems.Count == 0)
                TxtSettings.Text = "";
            else {
                IAuthMethod am = m_Server.Authentication.AuthMethods[LVAuthMethods.SelectedItems[0].Index];
                if (am.IsReadOnly)
                    BtnRemoveAuth.Enabled = false;
                TxtSettings.Text = am.Settings;
                if (TxtSettings.Text == "")
                    BtnApplySettings.Enabled = false;
            }
        }

        private void LVMapMasks_ItemChecked(object sender, ItemCheckedEventArgs e) {
            m_Server.Authentication.SSOUsers[e.Item.Index].Enabled = e.Item.Checked;
        }

        private void LVMapMasks_SelectedIndexChanged(object sender, EventArgs e) {
            LVMapPermissions.Items.Clear();
            if (LVMapMasks.SelectedItems.Count > 0) {
                ISSOUser user = m_Server.Authentication.SSOUsers[LVMapMasks.SelectedItems[0].Index];
                for (int i = 0; i < user.AssociatedUserAccounts.Count; i++) {
                    ListViewItem item = new ListViewItem();
                    item.Text = user.AssociatedUserAccounts[i].SamCompatible;
                    if (user.AssociatedUserAccounts[i].UserType == UserType.UT_GROUP)
                        item.SubItems.Add("Group");
                    else {
                        item.SubItems.Add("User");
                    }
                    LVMapPermissions.Items.Add(item);
                }
                TxtWinUsername.Text = user.WinUsername;
                TxtWinPassword.Text = user.WinPassword;
            }
            else {
                TxtWinUsername.Text = "";
                TxtWinPassword.Text = "";
            }
            EnableMappingControls();
        }

        private void LVMapMasks_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Delete) && (LVMapMasks.SelectedItems.Count > 0)) {
                m_Server.Authentication.SSOUsers.Remove(m_Server.Authentication.SSOUsers[LVMapMasks.SelectedItems[0].Index]);
                LVMapMasks.SelectedItems[0].Remove();
                EnableMappingControls();
            }
        }

        private void LVMapPermissions_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Delete) && (LVMapPermissions.SelectedItems.Count > 0)) {
                ISSOUser user = m_Server.Authentication.SSOUsers[LVMapMasks.SelectedItems[0].Index];
                user.AssociatedUserAccounts.Delete(LVMapPermissions.SelectedItems[0].SubItems[1].Text == "Group" ? UserType.UT_GROUP : UserType.UT_USER,
                                                   LVMapPermissions.SelectedItems[0].Text);
                LVMapPermissions.SelectedItems[0].Remove();
            }
        }

        private void BtnAddMask_Click(object sender, EventArgs e) {
            m_Server.Authentication.SSOUsers.Add(TxtMask.Text, CbMethodId.Text, true);
            UpdateMappingsList();
        }

        private void BtnAddMapPerm_Click(object sender, EventArgs e) {
            if (TxtPermissionName.Text == "")
                return;
            UserType ut = CbPermissionType.Text == "Group" ? ut = UserType.UT_GROUP : UserType.UT_USER;
            if (m_Server.Authentication.SSOUsers[LVMapMasks.SelectedItems[0].Index].AssociatedUserAccounts.Add(ut, TxtPermissionName.Text) == null) {
                MessageBox.Show("Cannot add permission. Check that it's a valid user or group and try again.", "Add user account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem item = new ListViewItem();
            item.Text = TxtPermissionName.Text;
            item.SubItems.Add(CbPermissionType.Text);
            LVMapPermissions.Items.Add(item);
        }

        private void BtnSetWinCredentials_Click(object sender, EventArgs e) {
            ISSOUser user = m_Server.Authentication.SSOUsers[LVMapMasks.SelectedItems[0].Index];
            user.WinUsername = TxtWinUsername.Text;
            user.WinPassword = TxtWinPassword.Text;
        }

        private void BtnRemoveWinCredentials_Click(object sender, EventArgs e) {
            ISSOUser user = m_Server.Authentication.SSOUsers[LVMapMasks.SelectedItems[0].Index];
            user.WinUsername = "";
            user.WinPassword = "";
            TxtWinUsername.Text = "";
            TxtWinPassword.Text = "";
        }

        private void BtnApply2FA_Click(object sender, EventArgs e) {
            m_Server.Authentication.SecondFactorMethods[LV2FAMethods.SelectedItems[0].Index].Settings = Txt2FASettings.Text.Trim();
        }

        private void BtnReset2FAUser_Click(object sender, EventArgs e) {
            if (Ed2FAUserName.Text != "")
                m_Server.Authentication.SecondFactorMethods[LV2FAMethods.SelectedItems[0].Index].ResetKey(Ed2FAUserName.Text);
        }

        private void LV2FAMethods_ItemChecked(object sender, ItemCheckedEventArgs e) {
            m_Server.Authentication.SecondFactorMethods[e.Item.Index].Enabled = e.Item.Checked;
        }

        private void LV2FAMethods_SelectedIndexChanged(object sender, EventArgs e) {
            Enable2FAControls();
            if (LV2FAMethods.SelectedItems.Count == 0)
                Txt2FASettings.Text = "";
            else {
                Txt2FASettings.Text = m_Server.Authentication.SecondFactorMethods[LV2FAMethods.SelectedItems[0].Index].Settings;
            }
        }

        private void BtnRemove2FA_Click(object sender, EventArgs e) {
            IAuthMethods2FA am = m_Server.Authentication.SecondFactorMethods;
            am.Remove(am[LV2FAMethods.SelectedItems[0].Index]);
            LV2FAMethods.SelectedItems[0].Remove();
            UpdateAuthMethodsList();
        }

        private void BtnAdd2FA_Click(object sender, EventArgs e) {
            IAuthMethod2FA m = m_Server.Authentication.SecondFactorMethods.Add((AuthenticationMethod2FA)(Cb2FAMethod.SelectedIndex));
            ListViewItem item = LV2FAMethods.Items.Add(m.Name);
            item.Checked = m.Enabled;
            Enable2FAControls();
        }
    }
}
