namespace TestLibConfig {
    partial class FormBroker {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtPoolName = new System.Windows.Forms.TextBox();
            this.LblPoolName = new System.Windows.Forms.Label();
            this.UdUsersLimit = new System.Windows.Forms.NumericUpDown();
            this.LblUsersLimit = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LVGateways = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNetworkID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RbPrimary = new System.Windows.Forms.RadioButton();
            this.RbSecondary = new System.Windows.Forms.RadioButton();
            this.LblPoolList = new System.Windows.Forms.Label();
            this.LvPools = new System.Windows.Forms.ListView();
            this.BtnAddPool = new System.Windows.Forms.Button();
            this.BtnEditPool = new System.Windows.Forms.Button();
            this.BtnRemovePool = new System.Windows.Forms.Button();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdUsersLimit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnRemovePool);
            this.groupBox1.Controls.Add(this.BtnEditPool);
            this.groupBox1.Controls.Add(this.BtnAddPool);
            this.groupBox1.Controls.Add(this.LvPools);
            this.groupBox1.Controls.Add(this.LblPoolList);
            this.groupBox1.Controls.Add(this.RbSecondary);
            this.groupBox1.Controls.Add(this.RbPrimary);
            this.groupBox1.Controls.Add(this.TxtPoolName);
            this.groupBox1.Controls.Add(this.LblPoolName);
            this.groupBox1.Controls.Add(this.UdUsersLimit);
            this.groupBox1.Controls.Add(this.LblUsersLimit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Broker options";
            // 
            // TxtPoolName
            // 
            this.TxtPoolName.Location = new System.Drawing.Point(81, 262);
            this.TxtPoolName.Name = "TxtPoolName";
            this.TxtPoolName.Size = new System.Drawing.Size(238, 20);
            this.TxtPoolName.TabIndex = 7;
            this.TxtPoolName.TextChanged += new System.EventHandler(this.TxtPoolName_TextChanged);
            // 
            // LblPoolName
            // 
            this.LblPoolName.AutoSize = true;
            this.LblPoolName.Location = new System.Drawing.Point(44, 265);
            this.LblPoolName.Name = "LblPoolName";
            this.LblPoolName.Size = new System.Drawing.Size(31, 13);
            this.LblPoolName.TabIndex = 4;
            this.LblPoolName.Text = "Pool:";
            // 
            // UdUsersLimit
            // 
            this.UdUsersLimit.Location = new System.Drawing.Point(107, 53);
            this.UdUsersLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UdUsersLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UdUsersLimit.Name = "UdUsersLimit";
            this.UdUsersLimit.Size = new System.Drawing.Size(72, 20);
            this.UdUsersLimit.TabIndex = 1;
            this.UdUsersLimit.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UdUsersLimit.ValueChanged += new System.EventHandler(this.UdUsersLimit_ValueChanged);
            // 
            // LblUsersLimit
            // 
            this.LblUsersLimit.AutoSize = true;
            this.LblUsersLimit.Location = new System.Drawing.Point(44, 55);
            this.LblUsersLimit.Name = "LblUsersLimit";
            this.LblUsersLimit.Size = new System.Drawing.Size(57, 13);
            this.LblUsersLimit.TabIndex = 2;
            this.LblUsersLimit.Text = "Users limit:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnRemove);
            this.groupBox2.Controls.Add(this.BtnAdd);
            this.groupBox2.Controls.Add(this.LVGateways);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtNetworkID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 232);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gateways";
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(318, 149);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(318, 120);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LVGateways
            // 
            this.LVGateways.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LVGateways.FullRowSelect = true;
            this.LVGateways.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LVGateways.HideSelection = false;
            this.LVGateways.Location = new System.Drawing.Point(19, 101);
            this.LVGateways.Name = "LVGateways";
            this.LVGateways.Size = new System.Drawing.Size(293, 112);
            this.LVGateways.TabIndex = 1;
            this.LVGateways.UseCompatibleStateImageBehavior = false;
            this.LVGateways.View = System.Windows.Forms.View.Details;
            this.LVGateways.SelectedIndexChanged += new System.EventHandler(this.LVGateways_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 272;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Gateways:";
            // 
            // TxtNetworkID
            // 
            this.TxtNetworkID.Location = new System.Drawing.Point(19, 45);
            this.TxtNetworkID.Name = "TxtNetworkID";
            this.TxtNetworkID.Size = new System.Drawing.Size(374, 20);
            this.TxtNetworkID.TabIndex = 0;
            this.TxtNetworkID.TextChanged += new System.EventHandler(this.TxtNetworkID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Network ID:";
            // 
            // RbPrimary
            // 
            this.RbPrimary.AutoSize = true;
            this.RbPrimary.Checked = true;
            this.RbPrimary.Location = new System.Drawing.Point(19, 30);
            this.RbPrimary.Name = "RbPrimary";
            this.RbPrimary.Size = new System.Drawing.Size(92, 17);
            this.RbPrimary.TabIndex = 0;
            this.RbPrimary.TabStop = true;
            this.RbPrimary.Text = "Primary broker";
            this.RbPrimary.UseVisualStyleBackColor = true;
            this.RbPrimary.CheckedChanged += new System.EventHandler(this.RbPrimary_CheckedChanged);
            // 
            // RbSecondary
            // 
            this.RbSecondary.AutoSize = true;
            this.RbSecondary.Location = new System.Drawing.Point(19, 235);
            this.RbSecondary.Name = "RbSecondary";
            this.RbSecondary.Size = new System.Drawing.Size(109, 17);
            this.RbSecondary.TabIndex = 6;
            this.RbSecondary.TabStop = true;
            this.RbSecondary.Text = "Secondary broker";
            this.RbSecondary.UseVisualStyleBackColor = true;
            this.RbSecondary.CheckedChanged += new System.EventHandler(this.RbSecondary_CheckedChanged);
            // 
            // LblPoolList
            // 
            this.LblPoolList.AutoSize = true;
            this.LblPoolList.Location = new System.Drawing.Point(44, 83);
            this.LblPoolList.Name = "LblPoolList";
            this.LblPoolList.Size = new System.Drawing.Size(137, 13);
            this.LblPoolList.TabIndex = 8;
            this.LblPoolList.Text = "Secondary brokers pool list:";
            // 
            // LvPools
            // 
            this.LvPools.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LvPools.FullRowSelect = true;
            this.LvPools.HideSelection = false;
            this.LvPools.Location = new System.Drawing.Point(47, 99);
            this.LvPools.MultiSelect = false;
            this.LvPools.Name = "LvPools";
            this.LvPools.Size = new System.Drawing.Size(346, 93);
            this.LvPools.TabIndex = 2;
            this.LvPools.UseCompatibleStateImageBehavior = false;
            this.LvPools.View = System.Windows.Forms.View.Details;
            this.LvPools.SelectedIndexChanged += new System.EventHandler(this.LvPools_SelectedIndexChanged);
            this.LvPools.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvPools_MouseDoubleClick);
            // 
            // BtnAddPool
            // 
            this.BtnAddPool.Location = new System.Drawing.Point(156, 198);
            this.BtnAddPool.Name = "BtnAddPool";
            this.BtnAddPool.Size = new System.Drawing.Size(75, 23);
            this.BtnAddPool.TabIndex = 3;
            this.BtnAddPool.Text = "Add";
            this.BtnAddPool.UseVisualStyleBackColor = true;
            this.BtnAddPool.Click += new System.EventHandler(this.BtnAddPool_Click);
            // 
            // BtnEditPool
            // 
            this.BtnEditPool.Location = new System.Drawing.Point(237, 198);
            this.BtnEditPool.Name = "BtnEditPool";
            this.BtnEditPool.Size = new System.Drawing.Size(75, 23);
            this.BtnEditPool.TabIndex = 4;
            this.BtnEditPool.Text = "Edit";
            this.BtnEditPool.UseVisualStyleBackColor = true;
            this.BtnEditPool.Click += new System.EventHandler(this.BtnEditPool_Click);
            // 
            // BtnRemovePool
            // 
            this.BtnRemovePool.Location = new System.Drawing.Point(318, 198);
            this.BtnRemovePool.Name = "BtnRemovePool";
            this.BtnRemovePool.Size = new System.Drawing.Size(75, 23);
            this.BtnRemovePool.TabIndex = 5;
            this.BtnRemovePool.Text = "Remove";
            this.BtnRemovePool.UseVisualStyleBackColor = true;
            this.BtnRemovePool.Click += new System.EventHandler(this.BtnRemovePool_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 132;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Users Limit";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Load-Balancing";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Default";
            this.columnHeader5.Width = 50;
            // 
            // FormBroker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBroker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Broker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UdUsersLimit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtPoolName;
        private System.Windows.Forms.Label LblPoolName;
        private System.Windows.Forms.NumericUpDown UdUsersLimit;
        private System.Windows.Forms.Label LblUsersLimit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ListView LVGateways;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNetworkID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RadioButton RbPrimary;
        private System.Windows.Forms.RadioButton RbSecondary;
        private System.Windows.Forms.Button BtnRemovePool;
        private System.Windows.Forms.Button BtnEditPool;
        private System.Windows.Forms.Button BtnAddPool;
        private System.Windows.Forms.ListView LvPools;
        private System.Windows.Forms.Label LblPoolList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}