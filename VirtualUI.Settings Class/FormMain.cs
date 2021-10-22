using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace VirtualUI_OAuthMethodAPI {
    public partial class FormMain : Form {
        private IServer ServerConfig = new Server();
        private IAuthMethod AuthMethod;

        public FormMain() {
            InitializeComponent();
        }

        private void SaveAuthMethod(IAuthMethod method) {
            string settings = "ClientID=" + TxtClientID.Text + "\r\n" +
                              "SecretKey=" + TxtClientSecret.Text + "\r\n" +
                              "URL=" + TxtAuthURL.Text + "\r\n" +
                              "QueryString=" + TxtAuthParams.Text + "\r\n" +
                              "CustomRedirectURL=" + TxtCustomRedirectURL.Text + "\r\n" +
                              "TokenURL=" + TxtTokenURL.Text + "\r\n" +
                              "TokenParams=" + TxtTokenExtraParams.Text + "\r\n" +
                              "SignOutURL=" + TxtSignoutURL.Text + "\r\n";
            if (RbFromJWT.Checked)
                settings += "ProfileURL=tokenSection:1" + "\r\n";
            else {
                settings += "ProfileURL=" + TxtUserProfileURL.Text + "\r\n" +
                            "ProfileDefaultParams=" + CheckDefaultParams.Checked.ToString() + "\r\n" +
                            "ProfileRequestCustomParams=" + TxtCustomParams.Text + "\r\n" +
                            "ProfileSendAuthHeader=" + CheckBasicAuth.Checked.ToString() + "\r\n";
            }
            settings += "ProfileUserName=" + TxtJsonField.Text;

            method.Enabled = true;
            method.Name = TxtMethodName.Text;
            method.VirtualPath = TxtVirtualPath.Text;
            method.SecondFactorMethod = Txt2FAMethod.Text;
            method.Settings = settings;
        }

        private void RBUserInfo_CheckedChanged(object sender, EventArgs e) {
            TxtUserProfileURL.Enabled = RbFromURL.Checked;
            CheckDefaultParams.Enabled = RbFromURL.Checked;
            LblCustomParams.Enabled = RbFromURL.Checked;
            TxtCustomParams.Enabled = RbFromURL.Checked;
            CheckBasicAuth.Enabled = RbFromURL.Checked;
        }

        private void BtnLoad_Click(object sender, EventArgs e) {
            ServerConfig.Load();
            bool found = false;
            BtnUpdate.Enabled = false;

            for (int i = 0; i < ServerConfig.Authentication.AuthMethods.Count; i++) {
                IAuthMethod method = ServerConfig.Authentication.AuthMethods[i];
                if (method.Name.Equals(TxtExistingMethod.Text, StringComparison.OrdinalIgnoreCase)) {
                    found = true;
                    if (method.MethodId != AuthenticationMethod.AM_OAUTH) {
                        MessageBox.Show("AuthMethod is not OAuth", "Load Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                    TxtMethodName.Text = method.Name;
                    TxtVirtualPath.Text = method.VirtualPath;
                    Txt2FAMethod.Text = method.SecondFactorMethod;

                    string[] settings = method.Settings.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string nameValue in settings) {
                        string name = nameValue.Substring(0, nameValue.IndexOf("="));
                        string value = nameValue.Substring(nameValue.IndexOf("=") + 1);

                        if (name == "ClientID") TxtClientID.Text = value;
                        if (name == "SecretKey") TxtClientSecret.Text = value;

                        if (name == "URL") TxtAuthURL.Text = value;
                        if (name == "QueryString") TxtAuthParams.Text = value;
                        if (name == "CustomRedirectURL") TxtCustomRedirectURL.Text = value;     // NEW
                        if (name == "TokenURL") TxtTokenURL.Text = value;
                        if (name == "TokenParams") TxtTokenExtraParams.Text = value;
                        if (name == "SignOutURL") TxtSignoutURL.Text = value;                   // NEW

                        if (name == "ProfileURL") {
                            if (value.StartsWith("tokenSection:"))
                                RbFromJWT.Checked = true;
                            else {
                                RbFromURL.Checked = true;
                                TxtUserProfileURL.Text = value;
                            }
                        }
                        if (name == "ProfileDefaultParams") CheckDefaultParams.Checked = (value.ToLower() == "true");
                        if (name == "ProfileRequestCustomParams") TxtCustomParams.Text = value;
                        if (name == "ProfileSendAuthHeader") CheckBasicAuth.Checked = (value.ToLower() == "true");
                        if (name == "ProfileUserName") TxtJsonField.Text = value;
                    }

                    AuthMethod = method;
                    BtnUpdate.Enabled = true;
                    break;
                }
            }
            if (!found) {
                MessageBox.Show("AuthMethod not found", "Load Method", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e) {
            SaveAuthMethod(AuthMethod);
            ServerConfig.Save();
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            IAuthMethod newMethod = ServerConfig.Authentication.AuthMethods.Add(AuthenticationMethod.AM_OAUTH);
            SaveAuthMethod(newMethod);
            ServerConfig.Save();
        }
    }
}
