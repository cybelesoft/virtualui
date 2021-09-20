namespace TestLibConfig {
    partial class FormAuthentication {
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
            this.CheckAllowAnonymous = new System.Windows.Forms.CheckBox();
            this.TabCtrlAuth = new System.Windows.Forms.TabControl();
            this.TabMethods = new System.Windows.Forms.TabPage();
            this.TxtSettings = new System.Windows.Forms.TextBox();
            this.BtnApplySettings = new System.Windows.Forms.Button();
            this.BtnRemoveAuth = new System.Windows.Forms.Button();
            this.BtnddAuth = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.LVAuthMethods = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabMappings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnRemoveWinCredentials = new System.Windows.Forms.Button();
            this.BtnSetWinCredentials = new System.Windows.Forms.Button();
            this.TxtWinPassword = new System.Windows.Forms.TextBox();
            this.LblWinPassword = new System.Windows.Forms.Label();
            this.TxtWinUsername = new System.Windows.Forms.TextBox();
            this.LblWinUsername = new System.Windows.Forms.Label();
            this.BtnAddMapPerm = new System.Windows.Forms.Button();
            this.LVMapMasks = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TxtPermissionName = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.CbPermissionType = new System.Windows.Forms.ComboBox();
            this.TxtMask = new System.Windows.Forms.TextBox();
            this.LVMapPermissions = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CbMethodId = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.BtnAddMask = new System.Windows.Forms.Button();
            this.Tab2FA = new System.Windows.Forms.TabPage();
            this.BtnReset2FAUser = new System.Windows.Forms.Button();
            this.Ed2FAUserName = new System.Windows.Forms.TextBox();
            this.Lbl2FAUserName = new System.Windows.Forms.Label();
            this.BtnApply2FA = new System.Windows.Forms.Button();
            this.Txt2FASettings = new System.Windows.Forms.TextBox();
            this.Lbl2FASettings = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnRemove2FA = new System.Windows.Forms.Button();
            this.BtnAdd2FA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LV2FAMethods = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.Cb2FAMethod = new System.Windows.Forms.ComboBox();
            this.BtnEditMethod = new System.Windows.Forms.Button();
            this.TabCtrlAuth.SuspendLayout();
            this.TabMethods.SuspendLayout();
            this.TabMappings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Tab2FA.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckAllowAnonymous
            // 
            this.CheckAllowAnonymous.AutoSize = true;
            this.CheckAllowAnonymous.Location = new System.Drawing.Point(12, 12);
            this.CheckAllowAnonymous.Name = "CheckAllowAnonymous";
            this.CheckAllowAnonymous.Size = new System.Drawing.Size(145, 17);
            this.CheckAllowAnonymous.TabIndex = 0;
            this.CheckAllowAnonymous.Text = "Allow anonymous access";
            this.CheckAllowAnonymous.UseVisualStyleBackColor = true;
            this.CheckAllowAnonymous.CheckedChanged += new System.EventHandler(this.CheckAllowAnonymous_CheckedChanged);
            // 
            // TabCtrlAuth
            // 
            this.TabCtrlAuth.Controls.Add(this.TabMethods);
            this.TabCtrlAuth.Controls.Add(this.TabMappings);
            this.TabCtrlAuth.Controls.Add(this.Tab2FA);
            this.TabCtrlAuth.Location = new System.Drawing.Point(6, 44);
            this.TabCtrlAuth.Name = "TabCtrlAuth";
            this.TabCtrlAuth.SelectedIndex = 0;
            this.TabCtrlAuth.Size = new System.Drawing.Size(613, 540);
            this.TabCtrlAuth.TabIndex = 3;
            // 
            // TabMethods
            // 
            this.TabMethods.Controls.Add(this.BtnEditMethod);
            this.TabMethods.Controls.Add(this.TxtSettings);
            this.TabMethods.Controls.Add(this.BtnApplySettings);
            this.TabMethods.Controls.Add(this.BtnRemoveAuth);
            this.TabMethods.Controls.Add(this.BtnddAuth);
            this.TabMethods.Controls.Add(this.label28);
            this.TabMethods.Controls.Add(this.label27);
            this.TabMethods.Controls.Add(this.LVAuthMethods);
            this.TabMethods.Location = new System.Drawing.Point(4, 22);
            this.TabMethods.Name = "TabMethods";
            this.TabMethods.Padding = new System.Windows.Forms.Padding(3);
            this.TabMethods.Size = new System.Drawing.Size(605, 514);
            this.TabMethods.TabIndex = 0;
            this.TabMethods.Text = "Methods";
            this.TabMethods.UseVisualStyleBackColor = true;
            // 
            // TxtSettings
            // 
            this.TxtSettings.Location = new System.Drawing.Point(21, 289);
            this.TxtSettings.Multiline = true;
            this.TxtSettings.Name = "TxtSettings";
            this.TxtSettings.Size = new System.Drawing.Size(473, 207);
            this.TxtSettings.TabIndex = 8;
            // 
            // BtnApplySettings
            // 
            this.BtnApplySettings.Location = new System.Drawing.Point(510, 305);
            this.BtnApplySettings.Name = "BtnApplySettings";
            this.BtnApplySettings.Size = new System.Drawing.Size(75, 23);
            this.BtnApplySettings.TabIndex = 6;
            this.BtnApplySettings.Text = "Apply";
            this.BtnApplySettings.UseVisualStyleBackColor = true;
            this.BtnApplySettings.Click += new System.EventHandler(this.BtnApplySettings_Click);
            // 
            // BtnRemoveAuth
            // 
            this.BtnRemoveAuth.Location = new System.Drawing.Point(510, 109);
            this.BtnRemoveAuth.Name = "BtnRemoveAuth";
            this.BtnRemoveAuth.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveAuth.TabIndex = 5;
            this.BtnRemoveAuth.Text = "Remove";
            this.BtnRemoveAuth.UseVisualStyleBackColor = true;
            this.BtnRemoveAuth.Click += new System.EventHandler(this.BtnRemoveAuth_Click);
            // 
            // BtnddAuth
            // 
            this.BtnddAuth.Location = new System.Drawing.Point(510, 51);
            this.BtnddAuth.Name = "BtnddAuth";
            this.BtnddAuth.Size = new System.Drawing.Size(75, 23);
            this.BtnddAuth.TabIndex = 4;
            this.BtnddAuth.Text = "Add";
            this.BtnddAuth.UseVisualStyleBackColor = true;
            this.BtnddAuth.Click += new System.EventHandler(this.BtnddAuth_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(18, 273);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 3;
            this.label28.Text = "Settings:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(18, 21);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(122, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "Authentication Methods:";
            // 
            // LVAuthMethods
            // 
            this.LVAuthMethods.CheckBoxes = true;
            this.LVAuthMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader2});
            this.LVAuthMethods.FullRowSelect = true;
            this.LVAuthMethods.HideSelection = false;
            this.LVAuthMethods.Location = new System.Drawing.Point(21, 37);
            this.LVAuthMethods.MultiSelect = false;
            this.LVAuthMethods.Name = "LVAuthMethods";
            this.LVAuthMethods.Size = new System.Drawing.Size(473, 214);
            this.LVAuthMethods.TabIndex = 0;
            this.LVAuthMethods.UseCompatibleStateImageBehavior = false;
            this.LVAuthMethods.View = System.Windows.Forms.View.Details;
            this.LVAuthMethods.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LVAuthMethods_ItemChecked);
            this.LVAuthMethods.SelectedIndexChanged += new System.EventHandler(this.LVAuthMethods_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 240;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Virtual Path";
            this.columnHeader8.Width = 140;
            // 
            // TabMappings
            // 
            this.TabMappings.Controls.Add(this.groupBox1);
            this.TabMappings.Controls.Add(this.BtnAddMapPerm);
            this.TabMappings.Controls.Add(this.LVMapMasks);
            this.TabMappings.Controls.Add(this.TxtPermissionName);
            this.TabMappings.Controls.Add(this.label25);
            this.TabMappings.Controls.Add(this.CbPermissionType);
            this.TabMappings.Controls.Add(this.TxtMask);
            this.TabMappings.Controls.Add(this.LVMapPermissions);
            this.TabMappings.Controls.Add(this.CbMethodId);
            this.TabMappings.Controls.Add(this.label26);
            this.TabMappings.Controls.Add(this.BtnAddMask);
            this.TabMappings.Location = new System.Drawing.Point(4, 22);
            this.TabMappings.Name = "TabMappings";
            this.TabMappings.Padding = new System.Windows.Forms.Padding(3);
            this.TabMappings.Size = new System.Drawing.Size(605, 514);
            this.TabMappings.TabIndex = 1;
            this.TabMappings.Text = "Mappings";
            this.TabMappings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnRemoveWinCredentials);
            this.groupBox1.Controls.Add(this.BtnSetWinCredentials);
            this.groupBox1.Controls.Add(this.TxtWinPassword);
            this.groupBox1.Controls.Add(this.LblWinPassword);
            this.groupBox1.Controls.Add(this.TxtWinUsername);
            this.groupBox1.Controls.Add(this.LblWinUsername);
            this.groupBox1.Location = new System.Drawing.Point(20, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 107);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Windows credentials";
            // 
            // BtnRemoveWinCredentials
            // 
            this.BtnRemoveWinCredentials.Location = new System.Drawing.Point(371, 49);
            this.BtnRemoveWinCredentials.Name = "BtnRemoveWinCredentials";
            this.BtnRemoveWinCredentials.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveWinCredentials.TabIndex = 5;
            this.BtnRemoveWinCredentials.Text = "Remove";
            this.BtnRemoveWinCredentials.UseVisualStyleBackColor = true;
            this.BtnRemoveWinCredentials.Click += new System.EventHandler(this.BtnRemoveWinCredentials_Click);
            // 
            // BtnSetWinCredentials
            // 
            this.BtnSetWinCredentials.Location = new System.Drawing.Point(290, 49);
            this.BtnSetWinCredentials.Name = "BtnSetWinCredentials";
            this.BtnSetWinCredentials.Size = new System.Drawing.Size(75, 23);
            this.BtnSetWinCredentials.TabIndex = 4;
            this.BtnSetWinCredentials.Text = "Set";
            this.BtnSetWinCredentials.UseVisualStyleBackColor = true;
            this.BtnSetWinCredentials.Click += new System.EventHandler(this.BtnSetWinCredentials_Click);
            // 
            // TxtWinPassword
            // 
            this.TxtWinPassword.Location = new System.Drawing.Point(90, 61);
            this.TxtWinPassword.Name = "TxtWinPassword";
            this.TxtWinPassword.Size = new System.Drawing.Size(177, 20);
            this.TxtWinPassword.TabIndex = 3;
            this.TxtWinPassword.UseSystemPasswordChar = true;
            // 
            // LblWinPassword
            // 
            this.LblWinPassword.AutoSize = true;
            this.LblWinPassword.Location = new System.Drawing.Point(26, 64);
            this.LblWinPassword.Name = "LblWinPassword";
            this.LblWinPassword.Size = new System.Drawing.Size(56, 13);
            this.LblWinPassword.TabIndex = 2;
            this.LblWinPassword.Text = "Password:";
            // 
            // TxtWinUsername
            // 
            this.TxtWinUsername.Location = new System.Drawing.Point(90, 35);
            this.TxtWinUsername.Name = "TxtWinUsername";
            this.TxtWinUsername.Size = new System.Drawing.Size(177, 20);
            this.TxtWinUsername.TabIndex = 1;
            // 
            // LblWinUsername
            // 
            this.LblWinUsername.AutoSize = true;
            this.LblWinUsername.Location = new System.Drawing.Point(26, 38);
            this.LblWinUsername.Name = "LblWinUsername";
            this.LblWinUsername.Size = new System.Drawing.Size(58, 13);
            this.LblWinUsername.TabIndex = 0;
            this.LblWinUsername.Text = "Username:";
            // 
            // BtnAddMapPerm
            // 
            this.BtnAddMapPerm.Location = new System.Drawing.Point(361, 349);
            this.BtnAddMapPerm.Name = "BtnAddMapPerm";
            this.BtnAddMapPerm.Size = new System.Drawing.Size(47, 22);
            this.BtnAddMapPerm.TabIndex = 9;
            this.BtnAddMapPerm.Text = "Add";
            this.BtnAddMapPerm.UseVisualStyleBackColor = true;
            this.BtnAddMapPerm.Click += new System.EventHandler(this.BtnAddMapPerm_Click);
            // 
            // LVMapMasks
            // 
            this.LVMapMasks.CheckBoxes = true;
            this.LVMapMasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.LVMapMasks.FullRowSelect = true;
            this.LVMapMasks.HideSelection = false;
            this.LVMapMasks.Location = new System.Drawing.Point(20, 37);
            this.LVMapMasks.MultiSelect = false;
            this.LVMapMasks.Name = "LVMapMasks";
            this.LVMapMasks.Size = new System.Drawing.Size(438, 157);
            this.LVMapMasks.TabIndex = 1;
            this.LVMapMasks.UseCompatibleStateImageBehavior = false;
            this.LVMapMasks.View = System.Windows.Forms.View.Details;
            this.LVMapMasks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LVMapMasks_ItemChecked);
            this.LVMapMasks.SelectedIndexChanged += new System.EventHandler(this.LVMapMasks_SelectedIndexChanged);
            this.LVMapMasks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LVMapMasks_KeyDown);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID Mask";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Method";
            this.columnHeader4.Width = 150;
            // 
            // TxtPermissionName
            // 
            this.TxtPermissionName.Location = new System.Drawing.Point(147, 350);
            this.TxtPermissionName.Name = "TxtPermissionName";
            this.TxtPermissionName.Size = new System.Drawing.Size(208, 20);
            this.TxtPermissionName.TabIndex = 8;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(17, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "Authentication ID mask:";
            // 
            // CbPermissionType
            // 
            this.CbPermissionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPermissionType.FormattingEnabled = true;
            this.CbPermissionType.Items.AddRange(new object[] {
            "User",
            "Group"});
            this.CbPermissionType.Location = new System.Drawing.Point(20, 349);
            this.CbPermissionType.Name = "CbPermissionType";
            this.CbPermissionType.Size = new System.Drawing.Size(121, 21);
            this.CbPermissionType.TabIndex = 7;
            // 
            // TxtMask
            // 
            this.TxtMask.Location = new System.Drawing.Point(20, 200);
            this.TxtMask.Name = "TxtMask";
            this.TxtMask.Size = new System.Drawing.Size(244, 20);
            this.TxtMask.TabIndex = 2;
            // 
            // LVMapPermissions
            // 
            this.LVMapPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.LVMapPermissions.FullRowSelect = true;
            this.LVMapPermissions.HideSelection = false;
            this.LVMapPermissions.Location = new System.Drawing.Point(20, 248);
            this.LVMapPermissions.MultiSelect = false;
            this.LVMapPermissions.Name = "LVMapPermissions";
            this.LVMapPermissions.Size = new System.Drawing.Size(437, 95);
            this.LVMapPermissions.TabIndex = 6;
            this.LVMapPermissions.UseCompatibleStateImageBehavior = false;
            this.LVMapPermissions.View = System.Windows.Forms.View.Details;
            this.LVMapPermissions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LVMapPermissions_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Permission";
            this.columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 100;
            // 
            // CbMethodId
            // 
            this.CbMethodId.FormattingEnabled = true;
            this.CbMethodId.Items.AddRange(new object[] {
            "*",
            "Google",
            "Facebook",
            "LinkedIn",
            "Dropbox",
            "Azure",
            "ForgeRock",
            "Radius",
            "External"});
            this.CbMethodId.Location = new System.Drawing.Point(270, 199);
            this.CbMethodId.Name = "CbMethodId";
            this.CbMethodId.Size = new System.Drawing.Size(131, 21);
            this.CbMethodId.TabIndex = 3;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(17, 232);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(119, 13);
            this.label26.TabIndex = 5;
            this.label26.Text = "Associated permissions:";
            // 
            // BtnAddMask
            // 
            this.BtnAddMask.Location = new System.Drawing.Point(408, 199);
            this.BtnAddMask.Name = "BtnAddMask";
            this.BtnAddMask.Size = new System.Drawing.Size(50, 22);
            this.BtnAddMask.TabIndex = 4;
            this.BtnAddMask.Text = "Add";
            this.BtnAddMask.UseVisualStyleBackColor = true;
            this.BtnAddMask.Click += new System.EventHandler(this.BtnAddMask_Click);
            // 
            // Tab2FA
            // 
            this.Tab2FA.Controls.Add(this.Cb2FAMethod);
            this.Tab2FA.Controls.Add(this.label2);
            this.Tab2FA.Controls.Add(this.BtnRemove2FA);
            this.Tab2FA.Controls.Add(this.BtnAdd2FA);
            this.Tab2FA.Controls.Add(this.label1);
            this.Tab2FA.Controls.Add(this.LV2FAMethods);
            this.Tab2FA.Controls.Add(this.BtnReset2FAUser);
            this.Tab2FA.Controls.Add(this.Ed2FAUserName);
            this.Tab2FA.Controls.Add(this.Lbl2FAUserName);
            this.Tab2FA.Controls.Add(this.BtnApply2FA);
            this.Tab2FA.Controls.Add(this.Txt2FASettings);
            this.Tab2FA.Controls.Add(this.Lbl2FASettings);
            this.Tab2FA.Location = new System.Drawing.Point(4, 22);
            this.Tab2FA.Name = "Tab2FA";
            this.Tab2FA.Padding = new System.Windows.Forms.Padding(3);
            this.Tab2FA.Size = new System.Drawing.Size(605, 514);
            this.Tab2FA.TabIndex = 2;
            this.Tab2FA.Text = "2FA";
            this.Tab2FA.UseVisualStyleBackColor = true;
            // 
            // BtnReset2FAUser
            // 
            this.BtnReset2FAUser.Location = new System.Drawing.Point(232, 478);
            this.BtnReset2FAUser.Name = "BtnReset2FAUser";
            this.BtnReset2FAUser.Size = new System.Drawing.Size(141, 23);
            this.BtnReset2FAUser.TabIndex = 7;
            this.BtnReset2FAUser.Text = "Reset 2FA key for user";
            this.BtnReset2FAUser.UseVisualStyleBackColor = true;
            this.BtnReset2FAUser.Click += new System.EventHandler(this.BtnReset2FAUser_Click);
            // 
            // Ed2FAUserName
            // 
            this.Ed2FAUserName.Location = new System.Drawing.Point(19, 480);
            this.Ed2FAUserName.Name = "Ed2FAUserName";
            this.Ed2FAUserName.Size = new System.Drawing.Size(207, 20);
            this.Ed2FAUserName.TabIndex = 6;
            // 
            // Lbl2FAUserName
            // 
            this.Lbl2FAUserName.AutoSize = true;
            this.Lbl2FAUserName.Location = new System.Drawing.Point(16, 464);
            this.Lbl2FAUserName.Name = "Lbl2FAUserName";
            this.Lbl2FAUserName.Size = new System.Drawing.Size(58, 13);
            this.Lbl2FAUserName.TabIndex = 13;
            this.Lbl2FAUserName.Text = "Username:";
            // 
            // BtnApply2FA
            // 
            this.BtnApply2FA.Location = new System.Drawing.Point(499, 300);
            this.BtnApply2FA.Name = "BtnApply2FA";
            this.BtnApply2FA.Size = new System.Drawing.Size(75, 23);
            this.BtnApply2FA.TabIndex = 5;
            this.BtnApply2FA.Text = "Apply";
            this.BtnApply2FA.UseVisualStyleBackColor = true;
            this.BtnApply2FA.Click += new System.EventHandler(this.BtnApply2FA_Click);
            // 
            // Txt2FASettings
            // 
            this.Txt2FASettings.Location = new System.Drawing.Point(19, 285);
            this.Txt2FASettings.Multiline = true;
            this.Txt2FASettings.Name = "Txt2FASettings";
            this.Txt2FASettings.Size = new System.Drawing.Size(474, 121);
            this.Txt2FASettings.TabIndex = 4;
            // 
            // Lbl2FASettings
            // 
            this.Lbl2FASettings.AutoSize = true;
            this.Lbl2FASettings.Location = new System.Drawing.Point(16, 269);
            this.Lbl2FASettings.Name = "Lbl2FASettings";
            this.Lbl2FASettings.Size = new System.Drawing.Size(48, 13);
            this.Lbl2FASettings.TabIndex = 9;
            this.Lbl2FASettings.Text = "Settings:";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "2FA";
            // 
            // BtnRemove2FA
            // 
            this.BtnRemove2FA.Location = new System.Drawing.Point(499, 61);
            this.BtnRemove2FA.Name = "BtnRemove2FA";
            this.BtnRemove2FA.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove2FA.TabIndex = 3;
            this.BtnRemove2FA.Text = "Remove";
            this.BtnRemove2FA.UseVisualStyleBackColor = true;
            this.BtnRemove2FA.Click += new System.EventHandler(this.BtnRemove2FA_Click);
            // 
            // BtnAdd2FA
            // 
            this.BtnAdd2FA.Location = new System.Drawing.Point(218, 205);
            this.BtnAdd2FA.Name = "BtnAdd2FA";
            this.BtnAdd2FA.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd2FA.TabIndex = 2;
            this.BtnAdd2FA.Text = "Add";
            this.BtnAdd2FA.UseVisualStyleBackColor = true;
            this.BtnAdd2FA.Click += new System.EventHandler(this.BtnAdd2FA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Authentication Methods:";
            // 
            // LV2FAMethods
            // 
            this.LV2FAMethods.CheckBoxes = true;
            this.LV2FAMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LV2FAMethods.FullRowSelect = true;
            this.LV2FAMethods.HideSelection = false;
            this.LV2FAMethods.Location = new System.Drawing.Point(20, 37);
            this.LV2FAMethods.MultiSelect = false;
            this.LV2FAMethods.Name = "LV2FAMethods";
            this.LV2FAMethods.Size = new System.Drawing.Size(473, 161);
            this.LV2FAMethods.TabIndex = 0;
            this.LV2FAMethods.UseCompatibleStateImageBehavior = false;
            this.LV2FAMethods.View = System.Windows.Forms.View.Details;
            this.LV2FAMethods.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LV2FAMethods_ItemChecked);
            this.LV2FAMethods.SelectedIndexChanged += new System.EventHandler(this.LV2FAMethods_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 450;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "2FA Method:";
            // 
            // Cb2FAMethod
            // 
            this.Cb2FAMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb2FAMethod.FormattingEnabled = true;
            this.Cb2FAMethod.Items.AddRange(new object[] {
            "TOTP",
            "DUO"});
            this.Cb2FAMethod.Location = new System.Drawing.Point(91, 206);
            this.Cb2FAMethod.Name = "Cb2FAMethod";
            this.Cb2FAMethod.Size = new System.Drawing.Size(121, 21);
            this.Cb2FAMethod.TabIndex = 1;
            // 
            // BtnEditMethod
            // 
            this.BtnEditMethod.Location = new System.Drawing.Point(510, 80);
            this.BtnEditMethod.Name = "BtnEditMethod";
            this.BtnEditMethod.Size = new System.Drawing.Size(75, 23);
            this.BtnEditMethod.TabIndex = 9;
            this.BtnEditMethod.Text = "Edit";
            this.BtnEditMethod.UseVisualStyleBackColor = true;
            this.BtnEditMethod.Click += new System.EventHandler(this.BtnEditMethod_Click);
            // 
            // FormAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 589);
            this.Controls.Add(this.TabCtrlAuth);
            this.Controls.Add(this.CheckAllowAnonymous);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAuthentication";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authentication";
            this.TabCtrlAuth.ResumeLayout(false);
            this.TabMethods.ResumeLayout(false);
            this.TabMethods.PerformLayout();
            this.TabMappings.ResumeLayout(false);
            this.TabMappings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Tab2FA.ResumeLayout(false);
            this.Tab2FA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckAllowAnonymous;
        private System.Windows.Forms.TabControl TabCtrlAuth;
        private System.Windows.Forms.TabPage TabMethods;
        private System.Windows.Forms.TextBox TxtSettings;
        private System.Windows.Forms.Button BtnApplySettings;
        private System.Windows.Forms.Button BtnRemoveAuth;
        private System.Windows.Forms.Button BtnddAuth;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ListView LVAuthMethods;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TabPage TabMappings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnRemoveWinCredentials;
        private System.Windows.Forms.Button BtnSetWinCredentials;
        private System.Windows.Forms.TextBox TxtWinPassword;
        private System.Windows.Forms.Label LblWinPassword;
        private System.Windows.Forms.TextBox TxtWinUsername;
        private System.Windows.Forms.Label LblWinUsername;
        private System.Windows.Forms.Button BtnAddMapPerm;
        private System.Windows.Forms.ListView LVMapMasks;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox TxtPermissionName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox CbPermissionType;
        private System.Windows.Forms.TextBox TxtMask;
        private System.Windows.Forms.ListView LVMapPermissions;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox CbMethodId;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button BtnAddMask;
        private System.Windows.Forms.TabPage Tab2FA;
        private System.Windows.Forms.Button BtnReset2FAUser;
        private System.Windows.Forms.TextBox Ed2FAUserName;
        private System.Windows.Forms.Label Lbl2FAUserName;
        private System.Windows.Forms.Button BtnApply2FA;
        private System.Windows.Forms.TextBox Txt2FASettings;
        private System.Windows.Forms.Label Lbl2FASettings;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox Cb2FAMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnRemove2FA;
        private System.Windows.Forms.Button BtnAdd2FA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LV2FAMethods;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button BtnEditMethod;
    }
}