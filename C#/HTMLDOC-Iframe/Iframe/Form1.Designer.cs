
namespace Iframe
{
    partial class Form1
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
            this.iframe = new System.Windows.Forms.Panel();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iframe
            // 
            this.iframe.Location = new System.Drawing.Point(12, 125);
            this.iframe.Name = "iframe";
            this.iframe.Size = new System.Drawing.Size(1002, 501);
            this.iframe.TabIndex = 0;
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(94, 32);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(821, 20);
            this.txtSrc.TabIndex = 2;
            this.txtSrc.Text = "/x-tag/jsro_iframe.html";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(921, 30);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSetColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.txtSrc);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL:";
            // 
            // btnSetColor
            // 
            this.btnSetColor.Location = new System.Drawing.Point(196, 58);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(159, 23);
            this.btnSetColor.TabIndex = 7;
            this.btnSetColor.Text = "Change Color";
            this.btnSetColor.UseVisualStyleBackColor = true;
            this.btnSetColor.Click += new System.EventHandler(this.btnSetColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Current Color:";
            // 
            // txtColor
            // 
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(94, 60);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(94, 20);
            this.txtColor.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 635);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.iframe);
            this.Name = "Form1";
            this.Text = "WinForm Iframe Demo (using JsRO) and WebComponent";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel iframe;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label2;
    }
}

