namespace VirtualUIEvents {
    partial class Form1 {
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
            this.LblTestDir = new System.Windows.Forms.Label();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.CheckRemoveTestDir = new System.Windows.Forms.CheckBox();
            this.CheckSaveLog = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.GetCookieLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GetCookieLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblTestDir
            // 
            this.LblTestDir.AutoSize = true;
            this.LblTestDir.Location = new System.Drawing.Point(12, 9);
            this.LblTestDir.Name = "LblTestDir";
            this.LblTestDir.Size = new System.Drawing.Size(74, 13);
            this.LblTestDir.TabIndex = 0;
            this.LblTestDir.Text = "Test directory:";
            // 
            // BtnDownload
            // 
            this.BtnDownload.Location = new System.Drawing.Point(11, 41);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(108, 23);
            this.BtnDownload.TabIndex = 1;
            this.BtnDownload.Text = "DownloadFile";
            this.BtnDownload.UseVisualStyleBackColor = true;
            this.BtnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(125, 41);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(108, 23);
            this.BtnUpload.TabIndex = 2;
            this.BtnUpload.Text = "UploadFile";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(125, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "(or drop files to browser)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Events log:";
            // 
            // TxtLog
            // 
            this.TxtLog.Location = new System.Drawing.Point(11, 108);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(593, 209);
            this.TxtLog.TabIndex = 5;
            // 
            // CheckRemoveTestDir
            // 
            this.CheckRemoveTestDir.AutoSize = true;
            this.CheckRemoveTestDir.Checked = true;
            this.CheckRemoveTestDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckRemoveTestDir.Location = new System.Drawing.Point(6, 323);
            this.CheckRemoveTestDir.Name = "CheckRemoveTestDir";
            this.CheckRemoveTestDir.Size = new System.Drawing.Size(176, 17);
            this.CheckRemoveTestDir.TabIndex = 6;
            this.CheckRemoveTestDir.Text = "Remove Test directory on close";
            this.CheckRemoveTestDir.UseVisualStyleBackColor = true;
            // 
            // CheckSaveLog
            // 
            this.CheckSaveLog.AutoSize = true;
            this.CheckSaveLog.Checked = true;
            this.CheckSaveLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSaveLog.Location = new System.Drawing.Point(278, 323);
            this.CheckSaveLog.Name = "CheckSaveLog";
            this.CheckSaveLog.Size = new System.Drawing.Size(200, 17);
            this.CheckSaveLog.TabIndex = 7;
            this.CheckSaveLog.Text = "Save log to VirtualUI_Events_PID.txt";
            this.CheckSaveLog.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "DownloadFile2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "GetCookie:";
            // 
            // GetCookieLabel
            // 
            this.GetCookieLabel.AutoSize = true;
            this.GetCookieLabel.Location = new System.Drawing.Point(89, 363);
            this.GetCookieLabel.Name = "GetCookieLabel";
            this.GetCookieLabel.Size = new System.Drawing.Size(0, 13);
            this.GetCookieLabel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "GetCookie2:";
            // 
            // GetCookieLabel2
            // 
            this.GetCookieLabel2.AutoSize = true;
            this.GetCookieLabel2.Location = new System.Drawing.Point(89, 391);
            this.GetCookieLabel2.Name = "GetCookieLabel2";
            this.GetCookieLabel2.Size = new System.Drawing.Size(35, 13);
            this.GetCookieLabel2.TabIndex = 13;
            this.GetCookieLabel2.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 464);
            this.Controls.Add(this.GetCookieLabel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GetCookieLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckSaveLog);
            this.Controls.Add(this.CheckRemoveTestDir);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.LblTestDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "VirtualUI - Events test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTestDir;
        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.CheckBox CheckRemoveTestDir;
        private System.Windows.Forms.CheckBox CheckSaveLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label GetCookieLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label GetCookieLabel2;
    }
}

