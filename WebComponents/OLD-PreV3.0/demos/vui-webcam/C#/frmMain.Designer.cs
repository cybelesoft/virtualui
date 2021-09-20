namespace VuiWebcamTest
{
    partial class frmMain
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
            this.bFreeze = new System.Windows.Forms.Button();
            this.bAttach = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.pnlWebcam = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bFreeze
            // 
            this.bFreeze.Location = new System.Drawing.Point(174, 258);
            this.bFreeze.Name = "bFreeze";
            this.bFreeze.Size = new System.Drawing.Size(75, 23);
            this.bFreeze.TabIndex = 10;
            this.bFreeze.Text = "Freeze";
            this.bFreeze.UseVisualStyleBackColor = true;
            this.bFreeze.Click += new System.EventHandler(this.bFreeze_Click);
            // 
            // bAttach
            // 
            this.bAttach.Location = new System.Drawing.Point(93, 258);
            this.bAttach.Name = "bAttach";
            this.bAttach.Size = new System.Drawing.Size(75, 23);
            this.bAttach.TabIndex = 9;
            this.bAttach.Text = "Attach";
            this.bAttach.UseVisualStyleBackColor = true;
            this.bAttach.Click += new System.EventHandler(this.bAttach_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(255, 258);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 11;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // pnlWebcam
            // 
            this.pnlWebcam.Location = new System.Drawing.Point(12, 12);
            this.pnlWebcam.Name = "pnlWebcam";
            this.pnlWebcam.Size = new System.Drawing.Size(320, 240);
            this.pnlWebcam.TabIndex = 13;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 289);
            this.Controls.Add(this.pnlWebcam);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bFreeze);
            this.Controls.Add(this.bAttach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMain";
            this.Text = "Webcam";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bFreeze;
        private System.Windows.Forms.Button bAttach;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel pnlWebcam;
    }
}

