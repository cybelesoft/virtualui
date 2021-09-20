namespace TestLibConfig {
    partial class DlgCertificate {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgCertificate));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabImport = new System.Windows.Forms.TabPage();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.TxtFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabSelfSigned = new System.Windows.Forms.TabPage();
            this.BtnCancelCreate = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtCommonName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtOrganizationalUnit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtOrganization = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtLocality = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCountryCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenFileDialogCert = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.TabImport.SuspendLayout();
            this.TabSelfSigned.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabImport);
            this.tabControl1.Controls.Add(this.TabSelfSigned);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 295);
            this.tabControl1.TabIndex = 0;
            // 
            // TabImport
            // 
            this.TabImport.Controls.Add(this.BtnCancel);
            this.TabImport.Controls.Add(this.BtnImport);
            this.TabImport.Controls.Add(this.TxtPassword);
            this.TabImport.Controls.Add(this.label2);
            this.TabImport.Controls.Add(this.BtnOpenFile);
            this.TabImport.Controls.Add(this.TxtFilename);
            this.TabImport.Controls.Add(this.label1);
            this.TabImport.Location = new System.Drawing.Point(4, 22);
            this.TabImport.Name = "TabImport";
            this.TabImport.Padding = new System.Windows.Forms.Padding(3);
            this.TabImport.Size = new System.Drawing.Size(377, 269);
            this.TabImport.TabIndex = 0;
            this.TabImport.Text = "Import certificate";
            this.TabImport.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(296, 240);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(215, 240);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(75, 23);
            this.BtnImport.TabIndex = 5;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(26, 101);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(280, 20);
            this.TxtPassword.TabIndex = 4;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password (if required):";
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Location = new System.Drawing.Point(312, 36);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(41, 23);
            this.BtnOpenFile.TabIndex = 2;
            this.BtnOpenFile.TabStop = false;
            this.BtnOpenFile.Text = "...";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // TxtFilename
            // 
            this.TxtFilename.Location = new System.Drawing.Point(26, 38);
            this.TxtFilename.Name = "TxtFilename";
            this.TxtFilename.ReadOnly = true;
            this.TxtFilename.Size = new System.Drawing.Size(280, 20);
            this.TxtFilename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename:";
            // 
            // TabSelfSigned
            // 
            this.TabSelfSigned.Controls.Add(this.BtnCancelCreate);
            this.TabSelfSigned.Controls.Add(this.BtnCreate);
            this.TabSelfSigned.Controls.Add(this.TxtEmail);
            this.TabSelfSigned.Controls.Add(this.label9);
            this.TabSelfSigned.Controls.Add(this.TxtCommonName);
            this.TabSelfSigned.Controls.Add(this.label7);
            this.TabSelfSigned.Controls.Add(this.TxtOrganizationalUnit);
            this.TabSelfSigned.Controls.Add(this.label8);
            this.TabSelfSigned.Controls.Add(this.TxtOrganization);
            this.TabSelfSigned.Controls.Add(this.label5);
            this.TabSelfSigned.Controls.Add(this.TxtLocality);
            this.TabSelfSigned.Controls.Add(this.label6);
            this.TabSelfSigned.Controls.Add(this.TxtState);
            this.TabSelfSigned.Controls.Add(this.label4);
            this.TabSelfSigned.Controls.Add(this.TxtCountryCode);
            this.TabSelfSigned.Controls.Add(this.label3);
            this.TabSelfSigned.Location = new System.Drawing.Point(4, 22);
            this.TabSelfSigned.Name = "TabSelfSigned";
            this.TabSelfSigned.Padding = new System.Windows.Forms.Padding(3);
            this.TabSelfSigned.Size = new System.Drawing.Size(377, 269);
            this.TabSelfSigned.TabIndex = 1;
            this.TabSelfSigned.Text = "Create self-signed";
            this.TabSelfSigned.UseVisualStyleBackColor = true;
            // 
            // BtnCancelCreate
            // 
            this.BtnCancelCreate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelCreate.Location = new System.Drawing.Point(296, 240);
            this.BtnCancelCreate.Name = "BtnCancelCreate";
            this.BtnCancelCreate.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelCreate.TabIndex = 15;
            this.BtnCancelCreate.Text = "Cancel";
            this.BtnCancelCreate.UseVisualStyleBackColor = true;
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(215, 240);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(75, 23);
            this.BtnCreate.TabIndex = 14;
            this.BtnCreate.Text = "Create";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(137, 187);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(193, 20);
            this.TxtEmail.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Email address:";
            // 
            // TxtCommonName
            // 
            this.TxtCommonName.Location = new System.Drawing.Point(137, 161);
            this.TxtCommonName.Name = "TxtCommonName";
            this.TxtCommonName.Size = new System.Drawing.Size(193, 20);
            this.TxtCommonName.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Common name:";
            // 
            // TxtOrganizationalUnit
            // 
            this.TxtOrganizationalUnit.Location = new System.Drawing.Point(137, 135);
            this.TxtOrganizationalUnit.Name = "TxtOrganizationalUnit";
            this.TxtOrganizationalUnit.Size = new System.Drawing.Size(193, 20);
            this.TxtOrganizationalUnit.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Organizational Unit:";
            // 
            // TxtOrganization
            // 
            this.TxtOrganization.Location = new System.Drawing.Point(137, 109);
            this.TxtOrganization.Name = "TxtOrganization";
            this.TxtOrganization.Size = new System.Drawing.Size(193, 20);
            this.TxtOrganization.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Organization:";
            // 
            // TxtLocality
            // 
            this.TxtLocality.Location = new System.Drawing.Point(137, 83);
            this.TxtLocality.Name = "TxtLocality";
            this.TxtLocality.Size = new System.Drawing.Size(193, 20);
            this.TxtLocality.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Locality:";
            // 
            // TxtState
            // 
            this.TxtState.Location = new System.Drawing.Point(137, 57);
            this.TxtState.Name = "TxtState";
            this.TxtState.Size = new System.Drawing.Size(193, 20);
            this.TxtState.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "State:";
            // 
            // TxtCountryCode
            // 
            this.TxtCountryCode.Location = new System.Drawing.Point(137, 31);
            this.TxtCountryCode.Name = "TxtCountryCode";
            this.TxtCountryCode.Size = new System.Drawing.Size(41, 20);
            this.TxtCountryCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Country code:";
            // 
            // OpenFileDialogCert
            // 
            this.OpenFileDialogCert.Filter = resources.GetString("OpenFileDialogCert.Filter");
            // 
            // DlgCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 319);
            this.Controls.Add(this.tabControl1);
            this.Name = "DlgCertificate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgCertificate";
            this.tabControl1.ResumeLayout(false);
            this.TabImport.ResumeLayout(false);
            this.TabImport.PerformLayout();
            this.TabSelfSigned.ResumeLayout(false);
            this.TabSelfSigned.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabImport;
        private System.Windows.Forms.TabPage TabSelfSigned;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.TextBox TxtFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelCreate;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtCommonName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtOrganizationalUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtOrganization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtLocality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCountryCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogCert;
    }
}