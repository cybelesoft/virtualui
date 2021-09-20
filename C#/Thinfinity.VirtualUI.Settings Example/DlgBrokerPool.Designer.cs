namespace TestLibConfig {
    partial class DlgBrokerPool {
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
            this.TxtPoolName = new System.Windows.Forms.TextBox();
            this.LblPoolName = new System.Windows.Forms.Label();
            this.UdUsersLimit = new System.Windows.Forms.NumericUpDown();
            this.LblUsersLimit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckDefault = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbBreadthFirst = new System.Windows.Forms.RadioButton();
            this.RbDepthFirst = new System.Windows.Forms.RadioButton();
            this.BtnSessions = new System.Windows.Forms.Button();
            this.BtnFolders = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UdUsersLimit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtPoolName
            // 
            this.TxtPoolName.Location = new System.Drawing.Point(78, 22);
            this.TxtPoolName.Name = "TxtPoolName";
            this.TxtPoolName.Size = new System.Drawing.Size(257, 20);
            this.TxtPoolName.TabIndex = 9;
            this.TxtPoolName.TextChanged += new System.EventHandler(this.TxtPoolName_TextChanged);
            // 
            // LblPoolName
            // 
            this.LblPoolName.AutoSize = true;
            this.LblPoolName.Location = new System.Drawing.Point(12, 25);
            this.LblPoolName.Name = "LblPoolName";
            this.LblPoolName.Size = new System.Drawing.Size(60, 13);
            this.LblPoolName.TabIndex = 8;
            this.LblPoolName.Text = "Pool name:";
            // 
            // UdUsersLimit
            // 
            this.UdUsersLimit.Location = new System.Drawing.Point(78, 55);
            this.UdUsersLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UdUsersLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdUsersLimit.Name = "UdUsersLimit";
            this.UdUsersLimit.Size = new System.Drawing.Size(72, 20);
            this.UdUsersLimit.TabIndex = 10;
            this.UdUsersLimit.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UdUsersLimit.ValueChanged += new System.EventHandler(this.UdUsersLimit_ValueChanged);
            // 
            // LblUsersLimit
            // 
            this.LblUsersLimit.AutoSize = true;
            this.LblUsersLimit.Location = new System.Drawing.Point(15, 57);
            this.LblUsersLimit.Name = "LblUsersLimit";
            this.LblUsersLimit.Size = new System.Drawing.Size(57, 13);
            this.LblUsersLimit.TabIndex = 11;
            this.LblUsersLimit.Text = "Users limit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "per broker";
            // 
            // CheckDefault
            // 
            this.CheckDefault.AutoSize = true;
            this.CheckDefault.Location = new System.Drawing.Point(249, 57);
            this.CheckDefault.Name = "CheckDefault";
            this.CheckDefault.Size = new System.Drawing.Size(83, 17);
            this.CheckDefault.TabIndex = 13;
            this.CheckDefault.Text = "Default pool";
            this.CheckDefault.UseVisualStyleBackColor = true;
            this.CheckDefault.CheckedChanged += new System.EventHandler(this.CheckDefault_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbDepthFirst);
            this.groupBox1.Controls.Add(this.RbBreadthFirst);
            this.groupBox1.Location = new System.Drawing.Point(18, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 94);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load-balancing method";
            // 
            // RbBreadthFirst
            // 
            this.RbBreadthFirst.AutoSize = true;
            this.RbBreadthFirst.Checked = true;
            this.RbBreadthFirst.Location = new System.Drawing.Point(28, 31);
            this.RbBreadthFirst.Name = "RbBreadthFirst";
            this.RbBreadthFirst.Size = new System.Drawing.Size(84, 17);
            this.RbBreadthFirst.TabIndex = 0;
            this.RbBreadthFirst.TabStop = true;
            this.RbBreadthFirst.Text = "Breadth-First";
            this.RbBreadthFirst.UseVisualStyleBackColor = true;
            this.RbBreadthFirst.CheckedChanged += new System.EventHandler(this.RbBreadthFirst_CheckedChanged);
            // 
            // RbDepthFirst
            // 
            this.RbDepthFirst.AutoSize = true;
            this.RbDepthFirst.Location = new System.Drawing.Point(27, 54);
            this.RbDepthFirst.Name = "RbDepthFirst";
            this.RbDepthFirst.Size = new System.Drawing.Size(76, 17);
            this.RbDepthFirst.TabIndex = 1;
            this.RbDepthFirst.TabStop = true;
            this.RbDepthFirst.Text = "Depth-First";
            this.RbDepthFirst.UseVisualStyleBackColor = true;
            this.RbDepthFirst.CheckedChanged += new System.EventHandler(this.RbDepthFirst_CheckedChanged);
            // 
            // BtnSessions
            // 
            this.BtnSessions.Location = new System.Drawing.Point(18, 199);
            this.BtnSessions.Name = "BtnSessions";
            this.BtnSessions.Size = new System.Drawing.Size(124, 23);
            this.BtnSessions.TabIndex = 15;
            this.BtnSessions.Text = "Sessions settings";
            this.BtnSessions.UseVisualStyleBackColor = true;
            this.BtnSessions.Click += new System.EventHandler(this.BtnSessions_Click);
            // 
            // BtnFolders
            // 
            this.BtnFolders.Location = new System.Drawing.Point(148, 199);
            this.BtnFolders.Name = "BtnFolders";
            this.BtnFolders.Size = new System.Drawing.Size(124, 23);
            this.BtnFolders.TabIndex = 16;
            this.BtnFolders.Text = "Folder settings";
            this.BtnFolders.UseVisualStyleBackColor = true;
            this.BtnFolders.Click += new System.EventHandler(this.BtnFolders_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Location = new System.Drawing.Point(184, 247);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 17;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(265, 247);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // DlgBrokerPool
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(352, 278);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnFolders);
            this.Controls.Add(this.BtnSessions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CheckDefault);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UdUsersLimit);
            this.Controls.Add(this.LblUsersLimit);
            this.Controls.Add(this.TxtPoolName);
            this.Controls.Add(this.LblPoolName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DlgBrokerPool";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Secondary Broker Pool";
            ((System.ComponentModel.ISupportInitialize)(this.UdUsersLimit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPoolName;
        private System.Windows.Forms.Label LblPoolName;
        private System.Windows.Forms.NumericUpDown UdUsersLimit;
        private System.Windows.Forms.Label LblUsersLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckDefault;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbDepthFirst;
        private System.Windows.Forms.RadioButton RbBreadthFirst;
        private System.Windows.Forms.Button BtnSessions;
        private System.Windows.Forms.Button BtnFolders;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
    }
}