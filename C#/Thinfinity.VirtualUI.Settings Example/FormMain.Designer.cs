namespace TestLibConfig
{
    partial class FormMain
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.BtnBindings = new System.Windows.Forms.Button();
            this.BtnAuthentication = new System.Windows.Forms.Button();
            this.BtnBroker = new System.Windows.Forms.Button();
            this.BtnProfiles = new System.Windows.Forms.Button();
            this.BtnLicense = new System.Windows.Forms.Button();
            this.BtnBruteForce = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnFolders = new System.Windows.Forms.Button();
            this.BtnSessions = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TxtAPIKey = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ButShowSection = new System.Windows.Forms.Button();
            this.ComboSectionShow = new System.Windows.Forms.ComboBox();
            this.ButHideSection = new System.Windows.Forms.Button();
            this.ComboSectionHide = new System.Windows.Forms.ComboBox();
            this.LblSetupMode = new System.Windows.Forms.Label();
            this.BtnDiscard = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CbServices = new System.Windows.Forms.ComboBox();
            this.BtnEnableService = new System.Windows.Forms.Button();
            this.BtnDisableService = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnBindings
            // 
            this.BtnBindings.Location = new System.Drawing.Point(20, 33);
            this.BtnBindings.Name = "BtnBindings";
            this.BtnBindings.Size = new System.Drawing.Size(90, 23);
            this.BtnBindings.TabIndex = 0;
            this.BtnBindings.Text = "Bindings";
            this.BtnBindings.UseVisualStyleBackColor = true;
            this.BtnBindings.Click += new System.EventHandler(this.BtnBindings_Click);
            // 
            // BtnAuthentication
            // 
            this.BtnAuthentication.Location = new System.Drawing.Point(20, 62);
            this.BtnAuthentication.Name = "BtnAuthentication";
            this.BtnAuthentication.Size = new System.Drawing.Size(90, 23);
            this.BtnAuthentication.TabIndex = 1;
            this.BtnAuthentication.Text = "Authentication";
            this.BtnAuthentication.UseVisualStyleBackColor = true;
            this.BtnAuthentication.Click += new System.EventHandler(this.BtnAuthentication_Click);
            // 
            // BtnBroker
            // 
            this.BtnBroker.Location = new System.Drawing.Point(20, 91);
            this.BtnBroker.Name = "BtnBroker";
            this.BtnBroker.Size = new System.Drawing.Size(90, 23);
            this.BtnBroker.TabIndex = 2;
            this.BtnBroker.Text = "Broker";
            this.BtnBroker.UseVisualStyleBackColor = true;
            this.BtnBroker.Click += new System.EventHandler(this.BtnBroker_Click);
            // 
            // BtnProfiles
            // 
            this.BtnProfiles.Location = new System.Drawing.Point(20, 178);
            this.BtnProfiles.Name = "BtnProfiles";
            this.BtnProfiles.Size = new System.Drawing.Size(90, 23);
            this.BtnProfiles.TabIndex = 5;
            this.BtnProfiles.Text = "Profiles";
            this.BtnProfiles.UseVisualStyleBackColor = true;
            this.BtnProfiles.Click += new System.EventHandler(this.BtnProfiles_Click);
            // 
            // BtnLicense
            // 
            this.BtnLicense.Location = new System.Drawing.Point(20, 207);
            this.BtnLicense.Name = "BtnLicense";
            this.BtnLicense.Size = new System.Drawing.Size(90, 23);
            this.BtnLicense.TabIndex = 6;
            this.BtnLicense.Text = "License";
            this.BtnLicense.UseVisualStyleBackColor = true;
            this.BtnLicense.Click += new System.EventHandler(this.BtnLicense_Click);
            // 
            // BtnBruteForce
            // 
            this.BtnBruteForce.Location = new System.Drawing.Point(20, 236);
            this.BtnBruteForce.Name = "BtnBruteForce";
            this.BtnBruteForce.Size = new System.Drawing.Size(90, 23);
            this.BtnBruteForce.TabIndex = 7;
            this.BtnBruteForce.Text = "Brute force";
            this.BtnBruteForce.UseVisualStyleBackColor = true;
            this.BtnBruteForce.Click += new System.EventHandler(this.BtnBruteForce_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnFolders);
            this.groupBox1.Controls.Add(this.BtnSessions);
            this.groupBox1.Controls.Add(this.BtnBindings);
            this.groupBox1.Controls.Add(this.BtnAuthentication);
            this.groupBox1.Controls.Add(this.BtnBroker);
            this.groupBox1.Controls.Add(this.BtnBruteForce);
            this.groupBox1.Controls.Add(this.BtnProfiles);
            this.groupBox1.Controls.Add(this.BtnLicense);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 283);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage";
            // 
            // BtnFolders
            // 
            this.BtnFolders.Location = new System.Drawing.Point(20, 149);
            this.BtnFolders.Name = "BtnFolders";
            this.BtnFolders.Size = new System.Drawing.Size(90, 23);
            this.BtnFolders.TabIndex = 4;
            this.BtnFolders.Text = "Folders";
            this.BtnFolders.UseVisualStyleBackColor = true;
            this.BtnFolders.Click += new System.EventHandler(this.BtnFolders_Click);
            // 
            // BtnSessions
            // 
            this.BtnSessions.Location = new System.Drawing.Point(20, 120);
            this.BtnSessions.Name = "BtnSessions";
            this.BtnSessions.Size = new System.Drawing.Size(90, 23);
            this.BtnSessions.TabIndex = 3;
            this.BtnSessions.Text = "Sessions";
            this.BtnSessions.UseVisualStyleBackColor = true;
            this.BtnSessions.Click += new System.EventHandler(this.BtnSessions_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BtnDisableService);
            this.groupBox6.Controls.Add(this.BtnEnableService);
            this.groupBox6.Controls.Add(this.CbServices);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.TxtAPIKey);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Location = new System.Drawing.Point(168, 160);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(300, 163);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other Settings";
            // 
            // TxtAPIKey
            // 
            this.TxtAPIKey.Location = new System.Drawing.Point(27, 45);
            this.TxtAPIKey.Name = "TxtAPIKey";
            this.TxtAPIKey.Size = new System.Drawing.Size(244, 20);
            this.TxtAPIKey.TabIndex = 0;
            this.TxtAPIKey.TextChanged += new System.EventHandler(this.TxtAPIKey_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(24, 29);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 13);
            this.label33.TabIndex = 4;
            this.label33.Text = "API Key:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ButShowSection);
            this.groupBox4.Controls.Add(this.ComboSectionShow);
            this.groupBox4.Controls.Add(this.ButHideSection);
            this.groupBox4.Controls.Add(this.ComboSectionHide);
            this.groupBox4.Location = new System.Drawing.Point(167, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 114);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Server Sections";
            // 
            // ButShowSection
            // 
            this.ButShowSection.Location = new System.Drawing.Point(189, 74);
            this.ButShowSection.Name = "ButShowSection";
            this.ButShowSection.Size = new System.Drawing.Size(82, 21);
            this.ButShowSection.TabIndex = 3;
            this.ButShowSection.TabStop = false;
            this.ButShowSection.Text = "Show section";
            this.ButShowSection.UseVisualStyleBackColor = true;
            this.ButShowSection.Click += new System.EventHandler(this.ButShowSection_Click);
            // 
            // ComboSectionShow
            // 
            this.ComboSectionShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSectionShow.FormattingEnabled = true;
            this.ComboSectionShow.Items.AddRange(new object[] {
            "General",
            "RDS",
            "Applications",
            "Licenses",
            "Broker",
            "Authentication",
            "Folders",
            "Brute Force"});
            this.ComboSectionShow.Location = new System.Drawing.Point(27, 74);
            this.ComboSectionShow.Name = "ComboSectionShow";
            this.ComboSectionShow.Size = new System.Drawing.Size(142, 21);
            this.ComboSectionShow.TabIndex = 2;
            // 
            // ButHideSection
            // 
            this.ButHideSection.Location = new System.Drawing.Point(189, 38);
            this.ButHideSection.Name = "ButHideSection";
            this.ButHideSection.Size = new System.Drawing.Size(82, 21);
            this.ButHideSection.TabIndex = 1;
            this.ButHideSection.TabStop = false;
            this.ButHideSection.Text = "Hide section";
            this.ButHideSection.UseVisualStyleBackColor = true;
            this.ButHideSection.Click += new System.EventHandler(this.ButHideSection_Click);
            // 
            // ComboSectionHide
            // 
            this.ComboSectionHide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSectionHide.FormattingEnabled = true;
            this.ComboSectionHide.Items.AddRange(new object[] {
            "General",
            "RDS",
            "Applications",
            "Licenses",
            "Broker",
            "Authentication",
            "Folders",
            "Brute Force"});
            this.ComboSectionHide.Location = new System.Drawing.Point(27, 38);
            this.ComboSectionHide.Name = "ComboSectionHide";
            this.ComboSectionHide.Size = new System.Drawing.Size(142, 21);
            this.ComboSectionHide.TabIndex = 0;
            // 
            // LblSetupMode
            // 
            this.LblSetupMode.AutoSize = true;
            this.LblSetupMode.Location = new System.Drawing.Point(12, 13);
            this.LblSetupMode.Name = "LblSetupMode";
            this.LblSetupMode.Size = new System.Drawing.Size(67, 13);
            this.LblSetupMode.TabIndex = 0;
            this.LblSetupMode.Text = "Setup mode:";
            // 
            // BtnDiscard
            // 
            this.BtnDiscard.Location = new System.Drawing.Point(205, 344);
            this.BtnDiscard.Name = "BtnDiscard";
            this.BtnDiscard.Size = new System.Drawing.Size(128, 23);
            this.BtnDiscard.TabIndex = 1;
            this.BtnDiscard.Text = "Discard all changes";
            this.BtnDiscard.UseVisualStyleBackColor = true;
            this.BtnDiscard.Click += new System.EventHandler(this.BtnDiscard_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(339, 344);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(128, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save all changes";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Service:";
            // 
            // CbServices
            // 
            this.CbServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbServices.FormattingEnabled = true;
            this.CbServices.Items.AddRange(new object[] {
            "Gateway",
            "Broker",
            "Virtualization"});
            this.CbServices.Location = new System.Drawing.Point(27, 94);
            this.CbServices.Name = "CbServices";
            this.CbServices.Size = new System.Drawing.Size(156, 21);
            this.CbServices.TabIndex = 6;
            // 
            // BtnEnableService
            // 
            this.BtnEnableService.Location = new System.Drawing.Point(27, 121);
            this.BtnEnableService.Name = "BtnEnableService";
            this.BtnEnableService.Size = new System.Drawing.Size(75, 23);
            this.BtnEnableService.TabIndex = 7;
            this.BtnEnableService.Text = "Enable";
            this.BtnEnableService.UseVisualStyleBackColor = true;
            this.BtnEnableService.Click += new System.EventHandler(this.BtnEnableService_Click);
            // 
            // BtnDisableService
            // 
            this.BtnDisableService.Location = new System.Drawing.Point(108, 121);
            this.BtnDisableService.Name = "BtnDisableService";
            this.BtnDisableService.Size = new System.Drawing.Size(75, 23);
            this.BtnDisableService.TabIndex = 8;
            this.BtnDisableService.Text = "Disable";
            this.BtnDisableService.UseVisualStyleBackColor = true;
            this.BtnDisableService.Click += new System.EventHandler(this.BtnDisableService_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 377);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDiscard);
            this.Controls.Add(this.LblSetupMode);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VirtualUI Settings API test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnBindings;
        private System.Windows.Forms.Button BtnAuthentication;
        private System.Windows.Forms.Button BtnBroker;
        private System.Windows.Forms.Button BtnProfiles;
        private System.Windows.Forms.Button BtnLicense;
        private System.Windows.Forms.Button BtnBruteForce;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TxtAPIKey;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ButShowSection;
        private System.Windows.Forms.ComboBox ComboSectionShow;
        private System.Windows.Forms.Button ButHideSection;
        private System.Windows.Forms.ComboBox ComboSectionHide;
        private System.Windows.Forms.Label LblSetupMode;
        private System.Windows.Forms.Button BtnSessions;
        private System.Windows.Forms.Button BtnDiscard;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnFolders;
        private System.Windows.Forms.ComboBox CbServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDisableService;
        private System.Windows.Forms.Button BtnEnableService;
    }
}

