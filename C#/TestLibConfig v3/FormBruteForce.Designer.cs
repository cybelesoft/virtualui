namespace TestLibConfig {
    partial class FormBruteForce {
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
            this.CheckEnabled = new System.Windows.Forms.CheckBox();
            this.LblMaxAttempts = new System.Windows.Forms.Label();
            this.LblBlocktime = new System.Windows.Forms.Label();
            this.UdMaxAttempts = new System.Windows.Forms.NumericUpDown();
            this.UdBlocktime = new System.Windows.Forms.NumericUpDown();
            this.LblMinutes = new System.Windows.Forms.Label();
            this.TabControlLists = new System.Windows.Forms.TabControl();
            this.TabWhiteList = new System.Windows.Forms.TabPage();
            this.BtnRemoveWhite = new System.Windows.Forms.Button();
            this.BtnAddWhite = new System.Windows.Forms.Button();
            this.LVWhiteList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabBlackList = new System.Windows.Forms.TabPage();
            this.BtnRemoveBlack = new System.Windows.Forms.Button();
            this.BtnAddBlack = new System.Windows.Forms.Button();
            this.LVBlackList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.UdMaxAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdBlocktime)).BeginInit();
            this.TabControlLists.SuspendLayout();
            this.TabWhiteList.SuspendLayout();
            this.TabBlackList.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckEnabled
            // 
            this.CheckEnabled.AutoSize = true;
            this.CheckEnabled.Location = new System.Drawing.Point(12, 22);
            this.CheckEnabled.Name = "CheckEnabled";
            this.CheckEnabled.Size = new System.Drawing.Size(160, 17);
            this.CheckEnabled.TabIndex = 0;
            this.CheckEnabled.Text = "Enable brute force detection";
            this.CheckEnabled.UseVisualStyleBackColor = true;
            this.CheckEnabled.CheckedChanged += new System.EventHandler(this.CheckEnabled_CheckedChanged);
            // 
            // LblMaxAttempts
            // 
            this.LblMaxAttempts.AutoSize = true;
            this.LblMaxAttempts.Location = new System.Drawing.Point(25, 56);
            this.LblMaxAttempts.Name = "LblMaxAttempts";
            this.LblMaxAttempts.Size = new System.Drawing.Size(101, 13);
            this.LblMaxAttempts.TabIndex = 1;
            this.LblMaxAttempts.Text = "Max. login attempts:";
            // 
            // LblBlocktime
            // 
            this.LblBlocktime.AutoSize = true;
            this.LblBlocktime.Location = new System.Drawing.Point(43, 82);
            this.LblBlocktime.Name = "LblBlocktime";
            this.LblBlocktime.Size = new System.Drawing.Size(83, 13);
            this.LblBlocktime.TabIndex = 2;
            this.LblBlocktime.Text = "Re-enable after:";
            // 
            // UdMaxAttempts
            // 
            this.UdMaxAttempts.Location = new System.Drawing.Point(132, 54);
            this.UdMaxAttempts.Name = "UdMaxAttempts";
            this.UdMaxAttempts.Size = new System.Drawing.Size(61, 20);
            this.UdMaxAttempts.TabIndex = 3;
            this.UdMaxAttempts.ValueChanged += new System.EventHandler(this.UdMaxAttempts_ValueChanged);
            // 
            // UdBlocktime
            // 
            this.UdBlocktime.Location = new System.Drawing.Point(132, 80);
            this.UdBlocktime.Name = "UdBlocktime";
            this.UdBlocktime.Size = new System.Drawing.Size(61, 20);
            this.UdBlocktime.TabIndex = 4;
            this.UdBlocktime.ValueChanged += new System.EventHandler(this.UdBlocktime_ValueChanged);
            // 
            // LblMinutes
            // 
            this.LblMinutes.AutoSize = true;
            this.LblMinutes.Location = new System.Drawing.Point(199, 82);
            this.LblMinutes.Name = "LblMinutes";
            this.LblMinutes.Size = new System.Drawing.Size(43, 13);
            this.LblMinutes.TabIndex = 5;
            this.LblMinutes.Text = "minutes";
            // 
            // TabControlLists
            // 
            this.TabControlLists.Controls.Add(this.TabWhiteList);
            this.TabControlLists.Controls.Add(this.TabBlackList);
            this.TabControlLists.Location = new System.Drawing.Point(12, 120);
            this.TabControlLists.Name = "TabControlLists";
            this.TabControlLists.SelectedIndex = 0;
            this.TabControlLists.Size = new System.Drawing.Size(498, 291);
            this.TabControlLists.TabIndex = 6;
            // 
            // TabWhiteList
            // 
            this.TabWhiteList.Controls.Add(this.BtnRemoveWhite);
            this.TabWhiteList.Controls.Add(this.BtnAddWhite);
            this.TabWhiteList.Controls.Add(this.LVWhiteList);
            this.TabWhiteList.Location = new System.Drawing.Point(4, 22);
            this.TabWhiteList.Name = "TabWhiteList";
            this.TabWhiteList.Padding = new System.Windows.Forms.Padding(3);
            this.TabWhiteList.Size = new System.Drawing.Size(490, 265);
            this.TabWhiteList.TabIndex = 0;
            this.TabWhiteList.Text = "White List";
            this.TabWhiteList.UseVisualStyleBackColor = true;
            // 
            // BtnRemoveWhite
            // 
            this.BtnRemoveWhite.Location = new System.Drawing.Point(402, 65);
            this.BtnRemoveWhite.Name = "BtnRemoveWhite";
            this.BtnRemoveWhite.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveWhite.TabIndex = 2;
            this.BtnRemoveWhite.Text = "Remove";
            this.BtnRemoveWhite.UseVisualStyleBackColor = true;
            this.BtnRemoveWhite.Click += new System.EventHandler(this.BtnRemoveWhite_Click);
            // 
            // BtnAddWhite
            // 
            this.BtnAddWhite.Location = new System.Drawing.Point(402, 36);
            this.BtnAddWhite.Name = "BtnAddWhite";
            this.BtnAddWhite.Size = new System.Drawing.Size(75, 23);
            this.BtnAddWhite.TabIndex = 1;
            this.BtnAddWhite.Text = "Add";
            this.BtnAddWhite.UseVisualStyleBackColor = true;
            this.BtnAddWhite.Click += new System.EventHandler(this.BtnAddWhite_Click);
            // 
            // LVWhiteList
            // 
            this.LVWhiteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LVWhiteList.FullRowSelect = true;
            this.LVWhiteList.HideSelection = false;
            this.LVWhiteList.Location = new System.Drawing.Point(14, 16);
            this.LVWhiteList.Name = "LVWhiteList";
            this.LVWhiteList.Size = new System.Drawing.Size(382, 233);
            this.LVWhiteList.TabIndex = 0;
            this.LVWhiteList.UseCompatibleStateImageBehavior = false;
            this.LVWhiteList.View = System.Windows.Forms.View.Details;
            this.LVWhiteList.SelectedIndexChanged += new System.EventHandler(this.LVWhiteList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address/Mask";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Source";
            this.columnHeader2.Width = 90;
            // 
            // TabBlackList
            // 
            this.TabBlackList.Controls.Add(this.BtnRemoveBlack);
            this.TabBlackList.Controls.Add(this.BtnAddBlack);
            this.TabBlackList.Controls.Add(this.LVBlackList);
            this.TabBlackList.Location = new System.Drawing.Point(4, 22);
            this.TabBlackList.Name = "TabBlackList";
            this.TabBlackList.Padding = new System.Windows.Forms.Padding(3);
            this.TabBlackList.Size = new System.Drawing.Size(490, 265);
            this.TabBlackList.TabIndex = 1;
            this.TabBlackList.Text = "Black List";
            this.TabBlackList.UseVisualStyleBackColor = true;
            // 
            // BtnRemoveBlack
            // 
            this.BtnRemoveBlack.Location = new System.Drawing.Point(402, 65);
            this.BtnRemoveBlack.Name = "BtnRemoveBlack";
            this.BtnRemoveBlack.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveBlack.TabIndex = 5;
            this.BtnRemoveBlack.Text = "Remove";
            this.BtnRemoveBlack.UseVisualStyleBackColor = true;
            this.BtnRemoveBlack.Click += new System.EventHandler(this.BtnRemoveBlack_Click);
            // 
            // BtnAddBlack
            // 
            this.BtnAddBlack.Location = new System.Drawing.Point(402, 36);
            this.BtnAddBlack.Name = "BtnAddBlack";
            this.BtnAddBlack.Size = new System.Drawing.Size(75, 23);
            this.BtnAddBlack.TabIndex = 4;
            this.BtnAddBlack.Text = "Add";
            this.BtnAddBlack.UseVisualStyleBackColor = true;
            this.BtnAddBlack.Click += new System.EventHandler(this.BtnAddBlack_Click);
            // 
            // LVBlackList
            // 
            this.LVBlackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LVBlackList.FullRowSelect = true;
            this.LVBlackList.HideSelection = false;
            this.LVBlackList.Location = new System.Drawing.Point(14, 16);
            this.LVBlackList.Name = "LVBlackList";
            this.LVBlackList.Size = new System.Drawing.Size(382, 233);
            this.LVBlackList.TabIndex = 3;
            this.LVBlackList.UseCompatibleStateImageBehavior = false;
            this.LVBlackList.View = System.Windows.Forms.View.Details;
            this.LVBlackList.SelectedIndexChanged += new System.EventHandler(this.LVBlackList_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Address/Mask";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Source";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Expiration";
            this.columnHeader5.Width = 120;
            // 
            // FormBruteForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 420);
            this.Controls.Add(this.TabControlLists);
            this.Controls.Add(this.LblMinutes);
            this.Controls.Add(this.UdBlocktime);
            this.Controls.Add(this.UdMaxAttempts);
            this.Controls.Add(this.LblBlocktime);
            this.Controls.Add(this.LblMaxAttempts);
            this.Controls.Add(this.CheckEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBruteForce";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brute force detection";
            ((System.ComponentModel.ISupportInitialize)(this.UdMaxAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdBlocktime)).EndInit();
            this.TabControlLists.ResumeLayout(false);
            this.TabWhiteList.ResumeLayout(false);
            this.TabBlackList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckEnabled;
        private System.Windows.Forms.Label LblMaxAttempts;
        private System.Windows.Forms.Label LblBlocktime;
        private System.Windows.Forms.NumericUpDown UdMaxAttempts;
        private System.Windows.Forms.NumericUpDown UdBlocktime;
        private System.Windows.Forms.Label LblMinutes;
        private System.Windows.Forms.TabControl TabControlLists;
        private System.Windows.Forms.TabPage TabWhiteList;
        private System.Windows.Forms.Button BtnRemoveWhite;
        private System.Windows.Forms.Button BtnAddWhite;
        private System.Windows.Forms.ListView LVWhiteList;
        private System.Windows.Forms.TabPage TabBlackList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnRemoveBlack;
        private System.Windows.Forms.Button BtnAddBlack;
        private System.Windows.Forms.ListView LVBlackList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}