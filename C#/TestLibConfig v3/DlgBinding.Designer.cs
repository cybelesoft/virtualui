namespace TestLibConfig {
    partial class DlgBinding {
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
            this.label1 = new System.Windows.Forms.Label();
            this.CbProtocol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtHostname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CbCertificate = new System.Windows.Forms.ComboBox();
            this.CheckRedirect = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbStatusCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtRedirectUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAddCert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Protocol:";
            // 
            // CbProtocol
            // 
            this.CbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProtocol.FormattingEnabled = true;
            this.CbProtocol.Items.AddRange(new object[] {
            "HTTP",
            "HTTPS"});
            this.CbProtocol.Location = new System.Drawing.Point(100, 22);
            this.CbProtocol.Name = "CbProtocol";
            this.CbProtocol.Size = new System.Drawing.Size(121, 21);
            this.CbProtocol.TabIndex = 1;
            this.CbProtocol.SelectedIndexChanged += new System.EventHandler(this.CbProtocol_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bind to IP:";
            // 
            // TxtIP
            // 
            this.TxtIP.Location = new System.Drawing.Point(100, 49);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(173, 20);
            this.TxtIP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(323, 49);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(46, 20);
            this.TxtPort.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Host name:";
            // 
            // TxtHostname
            // 
            this.TxtHostname.Location = new System.Drawing.Point(100, 75);
            this.TxtHostname.Name = "TxtHostname";
            this.TxtHostname.Size = new System.Drawing.Size(269, 20);
            this.TxtHostname.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Certificate:";
            // 
            // CbCertificate
            // 
            this.CbCertificate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCertificate.FormattingEnabled = true;
            this.CbCertificate.Location = new System.Drawing.Point(100, 101);
            this.CbCertificate.Name = "CbCertificate";
            this.CbCertificate.Size = new System.Drawing.Size(217, 21);
            this.CbCertificate.TabIndex = 9;
            // 
            // CheckRedirect
            // 
            this.CheckRedirect.AutoSize = true;
            this.CheckRedirect.Location = new System.Drawing.Point(20, 141);
            this.CheckRedirect.Name = "CheckRedirect";
            this.CheckRedirect.Size = new System.Drawing.Size(210, 17);
            this.CheckRedirect.TabIndex = 10;
            this.CheckRedirect.Text = "Redirect incoming requests to this URL";
            this.CheckRedirect.UseVisualStyleBackColor = true;
            this.CheckRedirect.CheckedChanged += new System.EventHandler(this.CheckRedirect_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbStatusCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtRedirectUrl);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 136);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // CbStatusCode
            // 
            this.CbStatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbStatusCode.FormattingEnabled = true;
            this.CbStatusCode.Items.AddRange(new object[] {
            "Found (302)",
            "Permanent (301)",
            "Temporary (307)",
            "Permanent Redirect (308)"});
            this.CbStatusCode.Location = new System.Drawing.Point(88, 88);
            this.CbStatusCode.Name = "CbStatusCode";
            this.CbStatusCode.Size = new System.Drawing.Size(269, 21);
            this.CbStatusCode.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Status code:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(85, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Example: https://www.mycompany.com/";
            // 
            // TxtRedirectUrl
            // 
            this.TxtRedirectUrl.Location = new System.Drawing.Point(88, 35);
            this.TxtRedirectUrl.Name = "TxtRedirectUrl";
            this.TxtRedirectUrl.Size = new System.Drawing.Size(269, 20);
            this.TxtRedirectUrl.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "URL:";
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(242, 294);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 12;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(323, 294);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 13;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnAddCert
            // 
            this.BtnAddCert.Location = new System.Drawing.Point(323, 100);
            this.BtnAddCert.Name = "BtnAddCert";
            this.BtnAddCert.Size = new System.Drawing.Size(46, 23);
            this.BtnAddCert.TabIndex = 14;
            this.BtnAddCert.TabStop = false;
            this.BtnAddCert.Text = "Add";
            this.BtnAddCert.UseVisualStyleBackColor = true;
            this.BtnAddCert.Click += new System.EventHandler(this.BtnAddCert_Click);
            // 
            // DlgBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(404, 324);
            this.Controls.Add(this.CheckRedirect);
            this.Controls.Add(this.BtnAddCert);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CbCertificate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtHostname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbProtocol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DlgBinding";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Binding";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbProtocol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtHostname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbCertificate;
        private System.Windows.Forms.CheckBox CheckRedirect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CbStatusCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtRedirectUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnAddCert;
    }
}