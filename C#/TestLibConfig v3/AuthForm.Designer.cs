namespace TestLibConfig
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EditRDSPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.EditRDSUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckRDSCreateAccount = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditRDSPassword
            // 
            this.EditRDSPassword.Location = new System.Drawing.Point(21, 74);
            this.EditRDSPassword.Name = "EditRDSPassword";
            this.EditRDSPassword.PasswordChar = '*';
            this.EditRDSPassword.Size = new System.Drawing.Size(255, 20);
            this.EditRDSPassword.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Password:";
            // 
            // EditRDSUserName
            // 
            this.EditRDSUserName.Location = new System.Drawing.Point(21, 30);
            this.EditRDSUserName.Name = "EditRDSUserName";
            this.EditRDSUserName.Size = new System.Drawing.Size(255, 20);
            this.EditRDSUserName.TabIndex = 8;
            this.EditRDSUserName.TextChanged += new System.EventHandler(this.EditRDSUserName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "UserName:";
            // 
            // CheckRDSCreateAccount
            // 
            this.CheckRDSCreateAccount.AutoSize = true;
            this.CheckRDSCreateAccount.Location = new System.Drawing.Point(177, 100);
            this.CheckRDSCreateAccount.Name = "CheckRDSCreateAccount";
            this.CheckRDSCreateAccount.Size = new System.Drawing.Size(99, 17);
            this.CheckRDSCreateAccount.TabIndex = 6;
            this.CheckRDSCreateAccount.Text = "Create account";
            this.CheckRDSCreateAccount.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 143);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(201, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AuthForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(301, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.EditRDSPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.EditRDSUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CheckRDSCreateAccount);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Account";
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox EditRDSPassword;
        public System.Windows.Forms.TextBox EditRDSUserName;
        public System.Windows.Forms.CheckBox CheckRDSCreateAccount;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}