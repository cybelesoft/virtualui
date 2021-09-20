namespace QzPrint
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
            this.bInit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrinters = new System.Windows.Forms.ComboBox();
            this.bPrintZPL = new System.Windows.Forms.Button();
            this.bPrintPDF = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bInit
            // 
            this.bInit.Location = new System.Drawing.Point(33, 22);
            this.bInit.Name = "bInit";
            this.bInit.Size = new System.Drawing.Size(244, 27);
            this.bInit.TabIndex = 0;
            this.bInit.Text = "Init";
            this.bInit.UseVisualStyleBackColor = true;
            this.bInit.Click += new System.EventHandler(this.bInit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbPrinters);
            this.panel1.Controls.Add(this.bPrintZPL);
            this.panel1.Controls.Add(this.bPrintPDF);
            this.panel1.Controls.Add(this.bSettings);
            this.panel1.Location = new System.Drawing.Point(1, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 154);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Available Printers:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.FormattingEnabled = true;
            this.cbPrinters.Location = new System.Drawing.Point(137, 17);
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(139, 21);
            this.cbPrinters.TabIndex = 9;
            this.cbPrinters.Click += new System.EventHandler(this.cbPrinters_Click);
            // 
            // bPrintZPL
            // 
            this.bPrintZPL.Location = new System.Drawing.Point(182, 118);
            this.bPrintZPL.Name = "bPrintZPL";
            this.bPrintZPL.Size = new System.Drawing.Size(94, 27);
            this.bPrintZPL.TabIndex = 8;
            this.bPrintZPL.Text = "Print ZPL";
            this.bPrintZPL.UseVisualStyleBackColor = true;
            this.bPrintZPL.Click += new System.EventHandler(this.bPrintZPL_Click);
            // 
            // bPrintPDF
            // 
            this.bPrintPDF.Location = new System.Drawing.Point(32, 118);
            this.bPrintPDF.Name = "bPrintPDF";
            this.bPrintPDF.Size = new System.Drawing.Size(90, 27);
            this.bPrintPDF.TabIndex = 7;
            this.bPrintPDF.Text = "Print PDF";
            this.bPrintPDF.UseVisualStyleBackColor = true;
            this.bPrintPDF.Click += new System.EventHandler(this.bPrintPDF_Click);
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(32, 76);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(244, 27);
            this.bSettings.TabIndex = 6;
            this.bSettings.Text = "Show Settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 212);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(311, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 234);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bInit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bInit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPrinters;
        private System.Windows.Forms.Button bPrintZPL;
        private System.Windows.Forms.Button bPrintPDF;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

