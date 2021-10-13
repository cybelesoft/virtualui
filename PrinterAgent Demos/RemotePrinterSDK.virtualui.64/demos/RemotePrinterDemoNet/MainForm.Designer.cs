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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtnGetPrinters = new System.Windows.Forms.Button();
            this.LBoxPrinters = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrinterName = new System.Windows.Forms.TextBox();
            this.txtDocTitle = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnPrintDoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGetPrinters
            // 
            this.BtnGetPrinters.Location = new System.Drawing.Point(12, 12);
            this.BtnGetPrinters.Name = "BtnGetPrinters";
            this.BtnGetPrinters.Size = new System.Drawing.Size(75, 23);
            this.BtnGetPrinters.TabIndex = 0;
            this.BtnGetPrinters.Text = "Get Printers";
            this.BtnGetPrinters.UseVisualStyleBackColor = true;
            this.BtnGetPrinters.Click += new System.EventHandler(this.BtnGetPrinters_Click);
            // 
            // LBoxPrinters
            // 
            this.LBoxPrinters.FormattingEnabled = true;
            this.LBoxPrinters.Location = new System.Drawing.Point(93, 12);
            this.LBoxPrinters.Name = "LBoxPrinters";
            this.LBoxPrinters.Size = new System.Drawing.Size(210, 95);
            this.LBoxPrinters.TabIndex = 1;
            this.LBoxPrinters.SelectedIndexChanged += new System.EventHandler(this.LBoxPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Printer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Doc Title:";
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.Location = new System.Drawing.Point(93, 113);
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.Size = new System.Drawing.Size(210, 20);
            this.txtPrinterName.TabIndex = 4;
            this.txtPrinterName.Text = "ZPL RAW Printer";
            // 
            // txtDocTitle
            // 
            this.txtDocTitle.Location = new System.Drawing.Point(93, 139);
            this.txtDocTitle.Name = "txtDocTitle";
            this.txtDocTitle.Size = new System.Drawing.Size(210, 20);
            this.txtDocTitle.TabIndex = 5;
            this.txtDocTitle.Text = "ZPL RAW Document 1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 165);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(288, 212);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // BtnPrintDoc
            // 
            this.BtnPrintDoc.Location = new System.Drawing.Point(15, 384);
            this.BtnPrintDoc.Name = "BtnPrintDoc";
            this.BtnPrintDoc.Size = new System.Drawing.Size(107, 23);
            this.BtnPrintDoc.TabIndex = 7;
            this.BtnPrintDoc.Text = "Print Document";
            this.BtnPrintDoc.UseVisualStyleBackColor = true;
            this.BtnPrintDoc.Click += new System.EventHandler(this.BtnPrintDoc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 418);
            this.Controls.Add(this.BtnPrintDoc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtDocTitle);
            this.Controls.Add(this.txtPrinterName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBoxPrinters);
            this.Controls.Add(this.BtnGetPrinters);
            this.Name = "MainForm";
            this.Text = "Remote Printer Demo Net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGetPrinters;
        private System.Windows.Forms.ListBox LBoxPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrinterName;
        private System.Windows.Forms.TextBox txtDocTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnPrintDoc;
    }
}

