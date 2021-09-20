namespace TestLibConfig {
    partial class FormSessions {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CheckEnableAL = new System.Windows.Forms.CheckBox();
            this.TxtALShell = new System.Windows.Forms.TextBox();
            this.LblALShell = new System.Windows.Forms.Label();
            this.TxtALPass = new System.Windows.Forms.TextBox();
            this.LblALPass = new System.Windows.Forms.Label();
            this.TxtALUser = new System.Windows.Forms.TextBox();
            this.LblALUser = new System.Windows.Forms.Label();
            this.RbConsoleSession = new System.Windows.Forms.RadioButton();
            this.RbCustomAccount = new System.Windows.Forms.RadioButton();
            this.RbLoggedUserAccount = new System.Windows.Forms.RadioButton();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.CheckThirdPartyApps = new System.Windows.Forms.CheckBox();
            this.CbSessionMode = new System.Windows.Forms.ComboBox();
            this.LblSessionMode = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CheckEnableAL);
            this.groupBox3.Controls.Add(this.TxtALShell);
            this.groupBox3.Controls.Add(this.LblALShell);
            this.groupBox3.Controls.Add(this.TxtALPass);
            this.groupBox3.Controls.Add(this.LblALPass);
            this.groupBox3.Controls.Add(this.TxtALUser);
            this.groupBox3.Controls.Add(this.LblALUser);
            this.groupBox3.Controls.Add(this.RbConsoleSession);
            this.groupBox3.Controls.Add(this.RbCustomAccount);
            this.groupBox3.Controls.Add(this.RbLoggedUserAccount);
            this.groupBox3.Controls.Add(this.TxtPassword);
            this.groupBox3.Controls.Add(this.LblPassword);
            this.groupBox3.Controls.Add(this.TxtUsername);
            this.groupBox3.Controls.Add(this.LblUsername);
            this.groupBox3.Location = new System.Drawing.Point(12, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 322);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // CheckEnableAL
            // 
            this.CheckEnableAL.AutoSize = true;
            this.CheckEnableAL.Location = new System.Drawing.Point(56, 61);
            this.CheckEnableAL.Name = "CheckEnableAL";
            this.CheckEnableAL.Size = new System.Drawing.Size(109, 17);
            this.CheckEnableAL.TabIndex = 1;
            this.CheckEnableAL.Text = "Enable autologon";
            this.CheckEnableAL.UseVisualStyleBackColor = true;
            this.CheckEnableAL.CheckedChanged += new System.EventHandler(this.CheckEnableAL_CheckedChanged);
            // 
            // TxtALShell
            // 
            this.TxtALShell.Location = new System.Drawing.Point(117, 136);
            this.TxtALShell.Name = "TxtALShell";
            this.TxtALShell.Size = new System.Drawing.Size(204, 20);
            this.TxtALShell.TabIndex = 4;
            this.TxtALShell.TextChanged += new System.EventHandler(this.TxtALShell_TextChanged);
            // 
            // LblALShell
            // 
            this.LblALShell.AutoSize = true;
            this.LblALShell.Location = new System.Drawing.Point(78, 139);
            this.LblALShell.Name = "LblALShell";
            this.LblALShell.Size = new System.Drawing.Size(33, 13);
            this.LblALShell.TabIndex = 10;
            this.LblALShell.Text = "Shell:";
            // 
            // TxtALPass
            // 
            this.TxtALPass.Location = new System.Drawing.Point(117, 110);
            this.TxtALPass.Name = "TxtALPass";
            this.TxtALPass.Size = new System.Drawing.Size(204, 20);
            this.TxtALPass.TabIndex = 3;
            this.TxtALPass.UseSystemPasswordChar = true;
            this.TxtALPass.TextChanged += new System.EventHandler(this.TxtALPass_TextChanged);
            // 
            // LblALPass
            // 
            this.LblALPass.AutoSize = true;
            this.LblALPass.Location = new System.Drawing.Point(55, 113);
            this.LblALPass.Name = "LblALPass";
            this.LblALPass.Size = new System.Drawing.Size(56, 13);
            this.LblALPass.TabIndex = 7;
            this.LblALPass.Text = "Password:";
            // 
            // TxtALUser
            // 
            this.TxtALUser.Location = new System.Drawing.Point(117, 84);
            this.TxtALUser.Name = "TxtALUser";
            this.TxtALUser.Size = new System.Drawing.Size(204, 20);
            this.TxtALUser.TabIndex = 2;
            this.TxtALUser.TextChanged += new System.EventHandler(this.TxtALUser_TextChanged);
            // 
            // LblALUser
            // 
            this.LblALUser.AutoSize = true;
            this.LblALUser.Location = new System.Drawing.Point(53, 87);
            this.LblALUser.Name = "LblALUser";
            this.LblALUser.Size = new System.Drawing.Size(58, 13);
            this.LblALUser.TabIndex = 6;
            this.LblALUser.Text = "Username:";
            // 
            // RbConsoleSession
            // 
            this.RbConsoleSession.AutoSize = true;
            this.RbConsoleSession.Location = new System.Drawing.Point(27, 30);
            this.RbConsoleSession.Name = "RbConsoleSession";
            this.RbConsoleSession.Size = new System.Drawing.Size(240, 17);
            this.RbConsoleSession.TabIndex = 0;
            this.RbConsoleSession.Text = "Use the current interactive session or console";
            this.RbConsoleSession.UseVisualStyleBackColor = true;
            this.RbConsoleSession.CheckedChanged += new System.EventHandler(this.RbConsoleSession_CheckedChanged);
            // 
            // RbCustomAccount
            // 
            this.RbCustomAccount.AutoSize = true;
            this.RbCustomAccount.Checked = true;
            this.RbCustomAccount.Location = new System.Drawing.Point(27, 181);
            this.RbCustomAccount.Name = "RbCustomAccount";
            this.RbCustomAccount.Size = new System.Drawing.Size(130, 17);
            this.RbCustomAccount.TabIndex = 5;
            this.RbCustomAccount.TabStop = true;
            this.RbCustomAccount.Text = "Use these credentials:";
            this.RbCustomAccount.UseVisualStyleBackColor = true;
            this.RbCustomAccount.CheckedChanged += new System.EventHandler(this.RbCustomAccount_CheckedChanged);
            // 
            // RbLoggedUserAccount
            // 
            this.RbLoggedUserAccount.AutoSize = true;
            this.RbLoggedUserAccount.Location = new System.Drawing.Point(27, 280);
            this.RbLoggedUserAccount.Name = "RbLoggedUserAccount";
            this.RbLoggedUserAccount.Size = new System.Drawing.Size(194, 17);
            this.RbLoggedUserAccount.TabIndex = 8;
            this.RbLoggedUserAccount.Text = "Use VirtualUI\'s logged-in credentials";
            this.RbLoggedUserAccount.UseVisualStyleBackColor = true;
            this.RbLoggedUserAccount.CheckedChanged += new System.EventHandler(this.RbLoggedUserAccount_CheckedChanged);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(117, 234);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(204, 20);
            this.TxtPassword.TabIndex = 7;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(55, 237);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(56, 13);
            this.LblPassword.TabIndex = 3;
            this.LblPassword.Text = "Password:";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(117, 208);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(204, 20);
            this.TxtUsername.TabIndex = 6;
            this.TxtUsername.TextChanged += new System.EventHandler(this.TxtUsername_TextChanged);
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Location = new System.Drawing.Point(53, 211);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(58, 13);
            this.LblUsername.TabIndex = 1;
            this.LblUsername.Text = "Username:";
            // 
            // CheckThirdPartyApps
            // 
            this.CheckThirdPartyApps.AutoSize = true;
            this.CheckThirdPartyApps.Location = new System.Drawing.Point(59, 45);
            this.CheckThirdPartyApps.Name = "CheckThirdPartyApps";
            this.CheckThirdPartyApps.Size = new System.Drawing.Size(162, 17);
            this.CheckThirdPartyApps.TabIndex = 1;
            this.CheckThirdPartyApps.Text = "Allow third-party applications ";
            this.CheckThirdPartyApps.UseVisualStyleBackColor = true;
            this.CheckThirdPartyApps.CheckedChanged += new System.EventHandler(this.CheckThirdPartyApps_CheckedChanged);
            // 
            // CbSessionMode
            // 
            this.CbSessionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSessionMode.FormattingEnabled = true;
            this.CbSessionMode.Items.AddRange(new object[] {
            "Multiple browser per session",
            "One browser per session"});
            this.CbSessionMode.Location = new System.Drawing.Point(59, 18);
            this.CbSessionMode.Name = "CbSessionMode";
            this.CbSessionMode.Size = new System.Drawing.Size(254, 21);
            this.CbSessionMode.TabIndex = 0;
            this.CbSessionMode.SelectedIndexChanged += new System.EventHandler(this.CbSessionMode_SelectedIndexChanged);
            // 
            // LblSessionMode
            // 
            this.LblSessionMode.AutoSize = true;
            this.LblSessionMode.Location = new System.Drawing.Point(16, 21);
            this.LblSessionMode.Name = "LblSessionMode";
            this.LblSessionMode.Size = new System.Drawing.Size(37, 13);
            this.LblSessionMode.TabIndex = 11;
            this.LblSessionMode.Text = "Mode:";
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Location = new System.Drawing.Point(298, 411);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // FormSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(383, 442);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.CheckThirdPartyApps);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CbSessionMode);
            this.Controls.Add(this.LblSessionMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormSessions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sessions";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.RadioButton RbCustomAccount;
        private System.Windows.Forms.RadioButton RbLoggedUserAccount;
        private System.Windows.Forms.ComboBox CbSessionMode;
        private System.Windows.Forms.Label LblSessionMode;
        private System.Windows.Forms.RadioButton RbConsoleSession;
        private System.Windows.Forms.CheckBox CheckThirdPartyApps;
        private System.Windows.Forms.CheckBox CheckEnableAL;
        private System.Windows.Forms.TextBox TxtALShell;
        private System.Windows.Forms.Label LblALShell;
        private System.Windows.Forms.TextBox TxtALPass;
        private System.Windows.Forms.Label LblALPass;
        private System.Windows.Forms.TextBox TxtALUser;
        private System.Windows.Forms.Label LblALUser;
        private System.Windows.Forms.Button BtnClose;
    }
}