using System;
using System.Windows.Forms;
using Cybele.Thinfinity.Settings.VirtualUI;

namespace TestLibConfig
{
    public partial class FormAddAuthMethod : Form
    {
        public AuthenticationMethod Method {
            get {
                return m_Method;
            }
            set {
                m_Method = value;
                ComboMethods.SelectedIndex = (int)value;
            }
        }
        public string MethodName {
            get {
                return m_MethodName;
            }
            set {
                m_MethodName = (value == null ? "" : value);
                TextBoxName.Text = m_MethodName;
            }
        }
        public string VirtualPath {
            get {
                return m_VirtualPath;
            }
            set {
                m_VirtualPath = (value == null ? "" : value);
                TextBoxVirtualPath.Text = m_VirtualPath;
            }
        }
        public string SecondFactorMethod {
            get {
                return m_SecondFactorMethod;
            }
            set {
                m_SecondFactorMethod = (value == null ? "" : value);
                Cb2FAMethod.SelectedIndex = Cb2FAMethod.Items.IndexOf(m_SecondFactorMethod);
                if (Cb2FAMethod.SelectedIndex == -1) {
                    Cb2FAMethod.SelectedIndex = 0;
                }
            }
        }

        private IServer m_Server;
        private AuthenticationMethod m_Method;
        private string m_MethodName = "";
        private string m_VirtualPath = "";
        private string m_SecondFactorMethod;

        public FormAddAuthMethod(IServer serverConfig, bool isNew) {
            InitializeComponent();
            m_Server = serverConfig;
            ComboMethods.SelectedIndex = 0;
            ComboMethods.Enabled = isNew;

            IAuthMethods2FA am = m_Server.Authentication.SecondFactorMethods;
            for (int i = 0; i < am.Count; i++) {
                Cb2FAMethod.Items.Add(am[i].Name);
            }
            Cb2FAMethod.SelectedIndex = 0;
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            if (ComboMethods.SelectedIndex == 1) {
                MessageBox.Show("DUO is no longer supported as primary method. Must be added as 2FA.", "DUO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            m_Method = (AuthenticationMethod)(ComboMethods.SelectedIndex);
            m_MethodName = TextBoxName.Text;
            m_VirtualPath = TextBoxVirtualPath.Text;
            if (Cb2FAMethod.SelectedIndex == 0)
                m_SecondFactorMethod = "";
            else {
                m_SecondFactorMethod = m_Server.Authentication.SecondFactorMethods[Cb2FAMethod.SelectedIndex - 1].Name;   // -1 because "none" it's in list
            }
            DialogResult = DialogResult.OK;
        }
    }
}
