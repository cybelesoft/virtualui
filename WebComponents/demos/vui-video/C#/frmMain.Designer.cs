namespace JsROVideo
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnGo_xvideo1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.slider = new System.Windows.Forms.TrackBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.panelXVideo = new System.Windows.Forms.Panel();
            this.cmbMp4 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXTagPath = new System.Windows.Forms.TextBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 19);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 4;
            this.lblUrl.Text = "URL:";
            // 
            // btnGo_xvideo1
            // 
            this.btnGo_xvideo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo_xvideo1.Location = new System.Drawing.Point(621, 16);
            this.btnGo_xvideo1.Name = "btnGo_xvideo1";
            this.btnGo_xvideo1.Size = new System.Drawing.Size(34, 20);
            this.btnGo_xvideo1.TabIndex = 6;
            this.btnGo_xvideo1.Text = "GO";
            this.btnGo_xvideo1.UseVisualStyleBackColor = true;
            this.btnGo_xvideo1.Click += new System.EventHandler(this.btnGo_xvideo1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblConsole);
            this.groupBox1.Controls.Add(this.slider);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Location = new System.Drawing.Point(15, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 95);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // slider
            // 
            this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slider.Location = new System.Drawing.Point(6, 45);
            this.slider.Maximum = 1000;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(628, 45);
            this.slider.TabIndex = 12;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(259, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(375, 13);
            this.lblStatus.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Status:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(87, 16);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(6, 16);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // panelXVideo
            // 
            this.panelXVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXVideo.Location = new System.Drawing.Point(15, 168);
            this.panelXVideo.Name = "panelXVideo";
            this.panelXVideo.Size = new System.Drawing.Size(640, 421);
            this.panelXVideo.TabIndex = 8;
            // 
            // cmbMp4
            // 
            this.cmbMp4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMp4.FormattingEnabled = true;
            this.cmbMp4.Location = new System.Drawing.Point(50, 15);
            this.cmbMp4.Name = "cmbMp4";
            this.cmbMp4.Size = new System.Drawing.Size(559, 21);
            this.cmbMp4.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X-Tag Path:";
            // 
            // txtXTagPath
            // 
            this.txtXTagPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXTagPath.Location = new System.Drawing.Point(84, 43);
            this.txtXTagPath.Name = "txtXTagPath";
            this.txtXTagPath.ReadOnly = true;
            this.txtXTagPath.Size = new System.Drawing.Size(525, 20);
            this.txtXTagPath.TabIndex = 11;
            // 
            // lblConsole
            // 
            this.lblConsole.Location = new System.Drawing.Point(19, 77);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(605, 15);
            this.lblConsole.TabIndex = 13;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 601);
            this.Controls.Add(this.txtXTagPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMp4);
            this.Controls.Add(this.panelXVideo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGo_xvideo1);
            this.Controls.Add(this.lblUrl);
            this.Name = "frmMain";
            this.Text = "JsRO Video";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnGo_xvideo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel panelXVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.ComboBox cmbMp4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXTagPath;
        private System.Windows.Forms.Label lblConsole;
    }
}

