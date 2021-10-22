namespace JsROAudio
{
    partial class frmJsROAudio
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
            this.slider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.cmbAudio = new System.Windows.Forms.ComboBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.panelXAudio = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // slider
            // 
            this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slider.Location = new System.Drawing.Point(6, 86);
            this.slider.Maximum = 1000;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(478, 45);
            this.slider.TabIndex = 12;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
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
            // cmbAudio
            // 
            this.cmbAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAudio.FormattingEnabled = true;
            this.cmbAudio.Location = new System.Drawing.Point(102, 12);
            this.cmbAudio.Name = "cmbAudio";
            this.cmbAudio.Size = new System.Drawing.Size(397, 21);
            this.cmbAudio.TabIndex = 13;
            this.cmbAudio.SelectedIndexChanged += new System.EventHandler(this.cmbAudio_SelectedIndexChanged);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 16);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(37, 13);
            this.lblUrl.TabIndex = 10;
            this.lblUrl.Text = "Audio:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(259, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(225, 13);
            this.lblStatus.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDuration);
            this.groupBox1.Controls.Add(this.lblStart);
            this.groupBox1.Controls.Add(this.slider);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Location = new System.Drawing.Point(15, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 137);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDuration.Location = new System.Drawing.Point(380, 60);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(104, 23);
            this.lblDuration.TabIndex = 14;
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(6, 60);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(110, 23);
            this.lblStart.TabIndex = 13;
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelXAudio
            // 
            this.panelXAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelXAudio.Location = new System.Drawing.Point(15, 189);
            this.panelXAudio.Name = "panelXAudio";
            this.panelXAudio.Size = new System.Drawing.Size(490, 40);
            this.panelXAudio.TabIndex = 14;
            // 
            // frmJsROAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 240);
            this.Controls.Add(this.panelXAudio);
            this.Controls.Add(this.cmbAudio);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmJsROAudio";
            this.Text = "JsROAudio";
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ComboBox cmbAudio;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelXAudio;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblStart;
    }
}

