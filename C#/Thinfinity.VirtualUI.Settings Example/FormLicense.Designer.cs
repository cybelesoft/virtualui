namespace TestLibConfig {
    partial class FormLicense {
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
            this.ButtonSetLSUrl = new System.Windows.Forms.Button();
            this.TxtLicenseServerBackup = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.TxtLicenseServerPrimary = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.TextLicenseInfo = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ButDeactivate = new System.Windows.Forms.Button();
            this.ButLicActivate = new System.Windows.Forms.Button();
            this.TxtSerial = new System.Windows.Forms.TextBox();
            this.TxtCustomerID = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.BtnActivateManual = new System.Windows.Forms.Button();
            this.TextLicenseData = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.TxtManualKey = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.BtnGenManualKey = new System.Windows.Forms.Button();
            this.TxtManualSerial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonSetLSUrl
            // 
            this.ButtonSetLSUrl.Location = new System.Drawing.Point(547, 22);
            this.ButtonSetLSUrl.Name = "ButtonSetLSUrl";
            this.ButtonSetLSUrl.Size = new System.Drawing.Size(76, 25);
            this.ButtonSetLSUrl.TabIndex = 13;
            this.ButtonSetLSUrl.Text = "Set";
            this.ButtonSetLSUrl.UseVisualStyleBackColor = true;
            this.ButtonSetLSUrl.Click += new System.EventHandler(this.ButtonSetLSUrl_Click);
            // 
            // TxtLicenseServerBackup
            // 
            this.TxtLicenseServerBackup.Location = new System.Drawing.Point(281, 25);
            this.TxtLicenseServerBackup.Name = "TxtLicenseServerBackup";
            this.TxtLicenseServerBackup.Size = new System.Drawing.Size(260, 20);
            this.TxtLicenseServerBackup.TabIndex = 12;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(278, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 13);
            this.label30.TabIndex = 17;
            this.label30.Text = "Backup:";
            // 
            // TxtLicenseServerPrimary
            // 
            this.TxtLicenseServerPrimary.Location = new System.Drawing.Point(15, 25);
            this.TxtLicenseServerPrimary.Name = "TxtLicenseServerPrimary";
            this.TxtLicenseServerPrimary.Size = new System.Drawing.Size(260, 20);
            this.TxtLicenseServerPrimary.TabIndex = 11;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(106, 13);
            this.label29.TabIndex = 16;
            this.label29.Text = "License Server URL:";
            // 
            // TextLicenseInfo
            // 
            this.TextLicenseInfo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextLicenseInfo.Location = new System.Drawing.Point(12, 425);
            this.TextLicenseInfo.Multiline = true;
            this.TextLicenseInfo.Name = "TextLicenseInfo";
            this.TextLicenseInfo.ReadOnly = true;
            this.TextLicenseInfo.Size = new System.Drawing.Size(618, 99);
            this.TextLicenseInfo.TabIndex = 15;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(12, 56);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(622, 367);
            this.tabControl2.TabIndex = 14;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ButDeactivate);
            this.tabPage4.Controls.Add(this.ButLicActivate);
            this.tabPage4.Controls.Add(this.TxtSerial);
            this.tabPage4.Controls.Add(this.TxtCustomerID);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(614, 341);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Online";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ButDeactivate
            // 
            this.ButDeactivate.Location = new System.Drawing.Point(112, 155);
            this.ButDeactivate.Name = "ButDeactivate";
            this.ButDeactivate.Size = new System.Drawing.Size(75, 23);
            this.ButDeactivate.TabIndex = 11;
            this.ButDeactivate.Text = "Deactivate";
            this.ButDeactivate.UseVisualStyleBackColor = true;
            this.ButDeactivate.Click += new System.EventHandler(this.ButDeactivate_Click);
            // 
            // ButLicActivate
            // 
            this.ButLicActivate.Location = new System.Drawing.Point(31, 155);
            this.ButLicActivate.Name = "ButLicActivate";
            this.ButLicActivate.Size = new System.Drawing.Size(75, 23);
            this.ButLicActivate.TabIndex = 10;
            this.ButLicActivate.Text = "Activate";
            this.ButLicActivate.UseVisualStyleBackColor = true;
            this.ButLicActivate.Click += new System.EventHandler(this.ButLicActivate_Click);
            // 
            // TxtSerial
            // 
            this.TxtSerial.Location = new System.Drawing.Point(31, 103);
            this.TxtSerial.Name = "TxtSerial";
            this.TxtSerial.Size = new System.Drawing.Size(418, 20);
            this.TxtSerial.TabIndex = 9;
            // 
            // TxtCustomerID
            // 
            this.TxtCustomerID.Location = new System.Drawing.Point(31, 48);
            this.TxtCustomerID.Name = "TxtCustomerID";
            this.TxtCustomerID.Size = new System.Drawing.Size(418, 20);
            this.TxtCustomerID.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Serial:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Customer ID:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.BtnActivateManual);
            this.tabPage5.Controls.Add(this.TextLicenseData);
            this.tabPage5.Controls.Add(this.label24);
            this.tabPage5.Controls.Add(this.label23);
            this.tabPage5.Controls.Add(this.TxtManualKey);
            this.tabPage5.Controls.Add(this.label22);
            this.tabPage5.Controls.Add(this.BtnGenManualKey);
            this.tabPage5.Controls.Add(this.TxtManualSerial);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(614, 341);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Manual";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // BtnActivateManual
            // 
            this.BtnActivateManual.Location = new System.Drawing.Point(33, 304);
            this.BtnActivateManual.Name = "BtnActivateManual";
            this.BtnActivateManual.Size = new System.Drawing.Size(116, 23);
            this.BtnActivateManual.TabIndex = 18;
            this.BtnActivateManual.Text = "Activate License";
            this.BtnActivateManual.UseVisualStyleBackColor = true;
            this.BtnActivateManual.Click += new System.EventHandler(this.BtnActivateManual_Click);
            // 
            // TextLicenseData
            // 
            this.TextLicenseData.Location = new System.Drawing.Point(33, 200);
            this.TextLicenseData.Multiline = true;
            this.TextLicenseData.Name = "TextLicenseData";
            this.TextLicenseData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextLicenseData.Size = new System.Drawing.Size(555, 98);
            this.TextLicenseData.TabIndex = 17;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(30, 180);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(339, 13);
            this.label24.TabIndex = 16;
            this.label24.Text = "3. Enter the license data received from Server and activate the license";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(30, 157);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(380, 13);
            this.label23.TabIndex = 15;
            this.label23.Text = "2. Use Serial an Manual Key to get activation data from Server with OEM library";
            // 
            // TxtManualKey
            // 
            this.TxtManualKey.Location = new System.Drawing.Point(33, 116);
            this.TxtManualKey.Name = "TxtManualKey";
            this.TxtManualKey.ReadOnly = true;
            this.TxtManualKey.Size = new System.Drawing.Size(418, 20);
            this.TxtManualKey.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(30, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(116, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "Manual Activation Key:";
            // 
            // BtnGenManualKey
            // 
            this.BtnGenManualKey.Location = new System.Drawing.Point(457, 65);
            this.BtnGenManualKey.Name = "BtnGenManualKey";
            this.BtnGenManualKey.Size = new System.Drawing.Size(131, 23);
            this.BtnGenManualKey.TabIndex = 12;
            this.BtnGenManualKey.Text = "Generate Manual Key";
            this.BtnGenManualKey.UseVisualStyleBackColor = true;
            this.BtnGenManualKey.Click += new System.EventHandler(this.BtnGenManualKey_Click);
            // 
            // TxtManualSerial
            // 
            this.TxtManualSerial.Location = new System.Drawing.Point(33, 67);
            this.TxtManualSerial.Name = "TxtManualSerial";
            this.TxtManualSerial.Size = new System.Drawing.Size(418, 20);
            this.TxtManualSerial.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Serial:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(349, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "1. Enter the license Serial number to generate the Manual Activation Key";
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 536);
            this.Controls.Add(this.ButtonSetLSUrl);
            this.Controls.Add(this.TxtLicenseServerBackup);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.TxtLicenseServerPrimary);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.TextLicenseInfo);
            this.Controls.Add(this.tabControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLicense";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License";
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSetLSUrl;
        private System.Windows.Forms.TextBox TxtLicenseServerBackup;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox TxtLicenseServerPrimary;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox TextLicenseInfo;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button ButDeactivate;
        private System.Windows.Forms.Button ButLicActivate;
        private System.Windows.Forms.TextBox TxtSerial;
        private System.Windows.Forms.TextBox TxtCustomerID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button BtnActivateManual;
        private System.Windows.Forms.TextBox TextLicenseData;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox TxtManualKey;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button BtnGenManualKey;
        private System.Windows.Forms.TextBox TxtManualSerial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}