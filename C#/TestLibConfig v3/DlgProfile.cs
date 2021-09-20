using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig {
    public partial class DlgProfile : Form {
        private IProfile m_Profile;
        private IServer m_Server;

        public DlgProfile(IServer serverConfig, IProfile profile) {
            InitializeComponent();
            m_Server = serverConfig;
            m_Profile = profile;

            CbRestrictionAction.SelectedIndex = 0;
            DPDateFrom.Value = DateTime.Now;
            DPDateTo.Value = DateTime.Now;

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            for (int h = 0; h <= 24; h++) {
                DataGridViewColumn col = new DataGridViewColumn(cell);
                if (h == 0)
                    col.Width = 90;
                else {
                    col.Width = 22;
                    col.HeaderText = (h - 1).ToString();
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                DGHours.Columns.Add(col);
            }
            DGHours.Rows.Add(7);
            DGHours.Rows[0].Cells[0].Value = "Sunday";
            DGHours.Rows[1].Cells[0].Value = "Monday";
            DGHours.Rows[2].Cells[0].Value = "Tuesday";
            DGHours.Rows[3].Cells[0].Value = "Wednesday";
            DGHours.Rows[4].Cells[0].Value = "Thursday";
            DGHours.Rows[5].Cells[0].Value = "Friday";
            DGHours.Rows[6].Cells[0].Value = "Saturday";

            CbAuthMethods.Items.Clear();
            for (int i = 0; i < m_Server.Authentication.AuthMethods.Count; i++) {
                CbAuthMethods.Items.Add(m_Server.Authentication.AuthMethods[i].Name);
            }
            CbAuthMethods.SelectedIndex = 0;

            LoadProfile();
        }

        private void LoadProfile() {
            LblProfileID.Text = m_Profile.ID;
            TxtPublicKey.Text = m_Profile.PublicKey;
            TxtName.Text = m_Profile.Name;
            TxtVirtualPath.Text = m_Profile.VirtualPath;
            TxtHomePage.Text = m_Profile.HomePage;
            CheckDefault.Checked = m_Profile.IsDefault;
            CheckVisible.Checked = m_Profile.Visible;
            CheckEnabled.Checked = m_Profile.Enabled;

            if (m_Profile.ProfileKind == ProfileKind.PROFILE_APP) {
                RBProfileKindApp.Checked = true;
                TxtFileNameOrWebLink.Text = m_Profile.FileName;
            }
            else {
                RBProfileKindWeb.Checked = true;
                TxtFileNameOrWebLink.Text = m_Profile.WebLink;
            }

            if ((m_Profile.IconData == null) || (m_Profile.IconData.Length == 0))
                ImgProfileIcon.Image = null;
            else {
                ImgProfileIcon.Image = ServerUtils.Base64ToIcon(m_Profile.IconData);
            }

            TxtArguments.Text = m_Profile.Arguments;
            CheckAllowBrowserArgs.Checked = m_Profile.AllowBrowserArguments;
            TxtStartDir.Text = m_Profile.StartDir;
            TxtBrowserRules.Text = m_Profile.BrowserRules;
            CbScreenResolution.SelectedIndex = (int)m_Profile.ScreenResolution;
            UdIdleTimeout.Value = m_Profile.IdleTimeout;
            TxtBrokerPool.Text = m_Profile.BrokerPool;

            CbCredentials.SelectedIndex = (int)m_Profile.Credentials;
            TxtUserName.Text = m_Profile.UserName;
            TxtPassword.Text = m_Profile.Password;

            CheckGuest.Checked = m_Profile.GuestAllowed;
            LVPermissions.Items.Clear();
            for (int i = 0; i < m_Profile.Users.Count; i++) {
                ListViewItem item = new ListViewItem(m_Profile.Users[i].SamCompatible);
                if (m_Profile.Users[i].UserType == UserType.UT_USER)
                    item.SubItems.Add("User");
                else {
                    item.SubItems.Add("Group");
                }
                LVPermissions.Items.Add(item);
            }

            CbRestrictionAction.SelectedIndex = (int)m_Profile.RestrictionAction;
            LVIPAddresses.Items.Clear();
            for (int i = 0; i < m_Profile.Restrictions.Count; i++) {
                LVIPAddresses.Items.Add(m_Profile.Restrictions[i]);
            }

            int day = 0;
            int hour = 0;
            char[] accHours = m_Profile.AccessHours.ToCharArray();
            for (int i = 0; i < accHours.Length; i++) {
                if (accHours[i] == '1')
                    DGHours.Rows[day].Cells[hour + 1].Value = '*';
                else {
                    DGHours.Rows[day].Cells[hour + 1].Value = ' ';
                }
                if (hour < 23)
                    hour++;
                else {
                    hour = 0;
                    day++;
                }
            }
            CheckOnlyPeriod.Checked = m_Profile.AccessDateEnabled;
            if (m_Profile.AccessDateEnabled) {
                DPDateFrom.Value = DateTime.ParseExact(m_Profile.AccessDateFrom, "yyyy-MM-dd", null);
                DPDateTo.Value = DateTime.ParseExact(m_Profile.AccessDateTo, "yyyy-MM-dd", null);
            }

            for (int i = 0; i < m_Profile.AllowedAuthMethods.Count; i++) {
                LVAuthMethods.Items.Add(m_Profile.AllowedAuthMethods[i]);
            }
            EnableControls();
        }

        private void UpdateProfile() {
            m_Profile.Name                   = TxtName.Text;
            m_Profile.VirtualPath            = TxtVirtualPath.Text;
            m_Profile.HomePage               = TxtHomePage.Text;
            m_Profile.IsDefault              = CheckDefault.Checked;
            m_Profile.Visible                = CheckVisible.Checked;
            m_Profile.Enabled                = CheckEnabled.Checked;

            if (RBProfileKindApp.Checked) {
                m_Profile.ProfileKind = ProfileKind.PROFILE_APP;
                m_Profile.FileName = TxtFileNameOrWebLink.Text;
            }
            else {
                m_Profile.ProfileKind = ProfileKind.PROFILE_WEBLINK;
                m_Profile.WebLink = TxtFileNameOrWebLink.Text;
            }

            if (ImgProfileIcon.Image == null)
                m_Profile.IconData = "";
            else {
                m_Profile.IconData = ServerUtils.IconToBase64(ImgProfileIcon.Image);
            }

            m_Profile.Arguments              = TxtArguments.Text;
            m_Profile.AllowBrowserArguments  = CheckAllowBrowserArgs.Checked;
            m_Profile.StartDir               = TxtStartDir.Text;
            m_Profile.ScreenResolution       = (ScreenResolution)CbScreenResolution.SelectedIndex;
            m_Profile.BrowserRules           = TxtBrowserRules.Text;
            m_Profile.IdleTimeout            = (int)UdIdleTimeout.Value;
            m_Profile.BrokerPool             = TxtBrokerPool.Text;

            m_Profile.Credentials = (Credentials)CbCredentials.SelectedIndex;
            m_Profile.UserName = TxtUserName.Text;
            if (TxtPassword.Modified) {
                m_Profile.Password = TxtPassword.Text;
            }

            m_Profile.GuestAllowed = CheckGuest.Checked;
            while (m_Profile.Users.Count > 0) {
                m_Profile.Users.Remove(m_Profile.Users[0]);
            }
            if (!CheckGuest.Checked) {
                for (int i = 0; i < LVPermissions.Items.Count; i++) {
                    UserType permType = UserType.UT_USER;
                    if (LVPermissions.Items[i].SubItems[1].Text == "Group") {
                        permType = UserType.UT_GROUP;
                    }
                    m_Profile.Users.Add(permType, LVPermissions.Items[i].Text);
                }
            }

            m_Profile.RestrictionAction = (RestrictionAction)CbRestrictionAction.SelectedIndex;
            while (m_Profile.Restrictions.Count > 0) {
                m_Profile.Restrictions.Delete(0);
            }
            for (int i = 0; i < LVIPAddresses.Items.Count; i++) {
                m_Profile.Restrictions.Add(LVIPAddresses.Items[i].Text);
            }

            string s = "";
            for (int day = 1; day <= 7; day++) {
                for (int hour = 0; hour <= 23; hour++) {
                    if (DGHours.Rows[day - 1].Cells[hour + 1].Value.ToString() == "*")
                        s += "1";
                    else
                        s += "0";
                }
            }
            m_Profile.AccessHours        = s;
            m_Profile.AccessDateEnabled  = CheckOnlyPeriod.Checked;
            m_Profile.AccessDateFrom     = DPDateFrom.Value.ToString("yyyy-MM-dd");
            m_Profile.AccessDateTo       = DPDateTo.Value.ToString("yyyy-MM-dd");

            while (m_Profile.AllowedAuthMethods.Count > 0) {
                m_Profile.AllowedAuthMethods.Delete(0);
            }
            for (int i = 0; i < LVAuthMethods.Items.Count; i++) {
                m_Profile.AllowedAuthMethods.Add(LVAuthMethods.Items[i].Text);
            }
        }

        private void EnableControls() {
            if (RBProfileKindApp.Checked)
                LblFileNameOrWebLink.Text = "Filename:";
            else {
                LblFileNameOrWebLink.Text = "Web URL:";
            }
            PnlAppSettings.Visible = RBProfileKindApp.Checked;

            LblUserName.Enabled = CbCredentials.SelectedIndex == 2;
            TxtUserName.Enabled = CbCredentials.SelectedIndex == 2;
            LblPassword.Enabled = CbCredentials.SelectedIndex == 2;
            TxtPassword.Enabled = CbCredentials.SelectedIndex == 2;

            LVPermissions.Enabled = !CheckGuest.Checked;
            CbPermType.Enabled = !CheckGuest.Checked;
            TxtPermName.Enabled = !CheckGuest.Checked;
            BtnAddPerm.Enabled = !CheckGuest.Checked;
            BtnRemovePerm.Enabled = LVPermissions.SelectedItems.Count > 0;

            BtnRemoveRestriction.Enabled = LVIPAddresses.SelectedItems.Count > 0;

            DPDateFrom.Enabled = CheckOnlyPeriod.Checked;
            DPDateTo.Enabled = CheckOnlyPeriod.Checked;
            LblTo.Enabled = CheckOnlyPeriod.Checked;

            BtnRemoveAuthMethod.Enabled = LVAuthMethods.SelectedItems.Count > 0;
        }

        private void RBProfileKindApp_CheckedChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void RBProfileKindWeb_CheckedChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void CbCredentials_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void CheckGuest_CheckedChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void LVIPAddresses_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void LVPermissions_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void BtnAddPerm_Click(object sender, EventArgs e) {
            if (TxtPermName.Text != "") {
                ListViewItem  item = LVPermissions.Items.Add(TxtPermName.Text);
                item.SubItems.Add(CbPermType.Text);
                EnableControls();
            }
        }

        private void BtnRemovePerm_Click(object sender, EventArgs e) {
            if (LVPermissions.SelectedItems.Count > 0) {
                LVPermissions.SelectedItems[0].Remove();
                EnableControls();
            }
        }

        private void BtnAddRestriction_Click(object sender, EventArgs e) {
            DlgInputText dlg = new DlgInputText("Profile Restrictions", "IP Address:");
            if (dlg.ShowDialog() == DialogResult.OK) {
                LVIPAddresses.Items.Add(dlg.InputValue);
            }
        }

        private void BtnRemoveRestriction_Click(object sender, EventArgs e) {
            if (LVIPAddresses.SelectedItems.Count > 0) {
                LVIPAddresses.SelectedItems[0].Remove();
                EnableControls();
            }
        }

        private void DGHours_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            DataGridViewCell cell = DGHours.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "*")
                cell.Value = " ";
            else {
                cell.Value = "*";
            }
        }

        private void CheckOnlyPeriod_CheckedChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void BtnAddAuthMethod_Click(object sender, EventArgs e) {
            if (LVAuthMethods.FindItemWithText(CbAuthMethods.Text) == null) {
                LVAuthMethods.Items.Add(CbAuthMethods.Text);
                EnableControls();
            }
        }

        private void BtnRemoveAuthMethod_Click(object sender, EventArgs e) {
            if (LVAuthMethods.SelectedItems.Count > 0) {
                LVAuthMethods.SelectedItems[0].Remove();
                EnableControls();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e) {
            UpdateProfile();
            DialogResult = DialogResult.OK;
        }

        private void LVAuthMethods_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void ImgProfileIcon_Click(object sender, EventArgs e) {
            if (OpenFileDlg.ShowDialog() == DialogResult.OK) {
                ImgProfileIcon.Load(OpenFileDlg.FileName);
            }
        }
    }
}
