namespace TestLibConfig
{
    partial class FormAddAuthMethod
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboMethods = new System.Windows.Forms.ComboBox();
            this.TextBoxVirtualPath = new System.Windows.Forms.TextBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cb2FAMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Method:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Virtual Path:";
            // 
            // ComboMethods
            // 
            this.ComboMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMethods.FormattingEnabled = true;
            this.ComboMethods.Items.AddRange(new object[] {
            "Windows Logon",
            "Radius",
            "DUO",
            "SAML",
            "OAuth",
            "External"});
            this.ComboMethods.Location = new System.Drawing.Point(37, 41);
            this.ComboMethods.Name = "ComboMethods";
            this.ComboMethods.Size = new System.Drawing.Size(307, 21);
            this.ComboMethods.TabIndex = 0;
            // 
            // TextBoxVirtualPath
            // 
            this.TextBoxVirtualPath.Location = new System.Drawing.Point(37, 148);
            this.TextBoxVirtualPath.Name = "TextBoxVirtualPath";
            this.TextBoxVirtualPath.Size = new System.Drawing.Size(307, 20);
            this.TextBoxVirtualPath.TabIndex = 2;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(222, 249);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(303, 249);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(37, 95);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(307, 20);
            this.TextBoxName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // Cb2FAMethod
            // 
            this.Cb2FAMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb2FAMethod.FormattingEnabled = true;
            this.Cb2FAMethod.Items.AddRange(new object[] {
            "(none)"});
            this.Cb2FAMethod.Location = new System.Drawing.Point(37, 197);
            this.Cb2FAMethod.Name = "Cb2FAMethod";
            this.Cb2FAMethod.Size = new System.Drawing.Size(307, 21);
            this.Cb2FAMethod.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "2FA Method:";
            // 
            // FormAddAuthMethod
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(390, 284);
            this.Controls.Add(this.Cb2FAMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.TextBoxVirtualPath);
            this.Controls.Add(this.ComboMethods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAddAuthMethod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Authentication Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboMethods;
        private System.Windows.Forms.TextBox TextBoxVirtualPath;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cb2FAMethod;
        private System.Windows.Forms.Label label4;
    }
}