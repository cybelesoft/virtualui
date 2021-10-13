namespace RemotePrinterDemoNet
{
    partial class MainForm
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
            this.btnPrintXps = new System.Windows.Forms.Button();
            this.txtFileNameXps = new System.Windows.Forms.TextBox();
            this.txtFileNamePdf = new System.Windows.Forms.TextBox();
            this.btnPrintPdf = new System.Windows.Forms.Button();
            this.btnPrintDirect = new System.Windows.Forms.Button();
            this.btnOpenXps = new System.Windows.Forms.Button();
            this.btnOpenPdf = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.openFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnPrintXps
            // 
            this.btnPrintXps.Location = new System.Drawing.Point(12, 12);
            this.btnPrintXps.Name = "btnPrintXps";
            this.btnPrintXps.Size = new System.Drawing.Size(201, 23);
            this.btnPrintXps.TabIndex = 0;
            this.btnPrintXps.Text = "Print XPS (To Any Default Printer)";
            this.btnPrintXps.UseVisualStyleBackColor = true;
            this.btnPrintXps.Click += new System.EventHandler(this.btnPrintXps_Click);
            // 
            // txtFileNameXps
            // 
            this.txtFileNameXps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNameXps.Location = new System.Drawing.Point(219, 14);
            this.txtFileNameXps.Name = "txtFileNameXps";
            this.txtFileNameXps.Size = new System.Drawing.Size(351, 20);
            this.txtFileNameXps.TabIndex = 4;
            this.txtFileNameXps.Text = "Test1.xps";
            // 
            // txtFileNamePdf
            // 
            this.txtFileNamePdf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNamePdf.Location = new System.Drawing.Point(219, 43);
            this.txtFileNamePdf.Name = "txtFileNamePdf";
            this.txtFileNamePdf.Size = new System.Drawing.Size(351, 20);
            this.txtFileNamePdf.TabIndex = 5;
            this.txtFileNamePdf.Text = "Test1.pdf";
            // 
            // btnPrintPdf
            // 
            this.btnPrintPdf.Location = new System.Drawing.Point(12, 41);
            this.btnPrintPdf.Name = "btnPrintPdf";
            this.btnPrintPdf.Size = new System.Drawing.Size(201, 23);
            this.btnPrintPdf.TabIndex = 7;
            this.btnPrintPdf.Text = "Print PDF (To Any Default Printer)";
            this.btnPrintPdf.UseVisualStyleBackColor = true;
            this.btnPrintPdf.Click += new System.EventHandler(this.btnPrintPdf_Click);
            // 
            // btnPrintDirect
            // 
            this.btnPrintDirect.Location = new System.Drawing.Point(12, 70);
            this.btnPrintDirect.Name = "btnPrintDirect";
            this.btnPrintDirect.Size = new System.Drawing.Size(201, 23);
            this.btnPrintDirect.TabIndex = 8;
            this.btnPrintDirect.Text = "Print Direct PDF / ZPL (Raw to Printer)";
            this.btnPrintDirect.UseVisualStyleBackColor = true;
            this.btnPrintDirect.Click += new System.EventHandler(this.btnPrintDirect_Click);
            // 
            // btnOpenXps
            // 
            this.btnOpenXps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenXps.Location = new System.Drawing.Point(576, 12);
            this.btnOpenXps.Name = "btnOpenXps";
            this.btnOpenXps.Size = new System.Drawing.Size(24, 23);
            this.btnOpenXps.TabIndex = 9;
            this.btnOpenXps.Text = "...";
            this.btnOpenXps.UseVisualStyleBackColor = true;
            this.btnOpenXps.Click += new System.EventHandler(this.btnOpenXps_Click);
            // 
            // btnOpenPdf
            // 
            this.btnOpenPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPdf.Location = new System.Drawing.Point(576, 41);
            this.btnOpenPdf.Name = "btnOpenPdf";
            this.btnOpenPdf.Size = new System.Drawing.Size(24, 23);
            this.btnOpenPdf.TabIndex = 10;
            this.btnOpenPdf.Text = "...";
            this.btnOpenPdf.UseVisualStyleBackColor = true;
            this.btnOpenPdf.Click += new System.EventHandler(this.btnOpenPdf_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(576, 70);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(24, 23);
            this.btnOpenFile.TabIndex = 11;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(219, 72);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(351, 20);
            this.txtFileName.TabIndex = 12;
            this.txtFileName.Text = "Test1.txt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 106);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnOpenPdf);
            this.Controls.Add(this.btnOpenXps);
            this.Controls.Add(this.btnPrintDirect);
            this.Controls.Add(this.btnPrintPdf);
            this.Controls.Add(this.txtFileNamePdf);
            this.Controls.Add(this.txtFileNameXps);
            this.Controls.Add(this.btnPrintXps);
            this.Name = "MainForm";
            this.Text = "Thinfinity RemotePrinter Demo Net - PrintFile (VirtualUI)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintXps;
        private System.Windows.Forms.TextBox txtFileNameXps;
        private System.Windows.Forms.TextBox txtFileNamePdf;
        private System.Windows.Forms.Button btnPrintPdf;
        private System.Windows.Forms.Button btnPrintDirect;
        private System.Windows.Forms.Button btnOpenXps;
        private System.Windows.Forms.Button btnOpenPdf;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.OpenFileDialog openFilesDialog;
    }
}

