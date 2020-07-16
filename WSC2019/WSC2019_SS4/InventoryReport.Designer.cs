namespace WSC2019_SS4
{
    partial class InventoryReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.rdCurrent = new System.Windows.Forms.RadioButton();
            this.rdReceived = new System.Windows.Forms.RadioButton();
            this.rdOutOf = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Partname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdOutOf);
            this.groupBox1.Controls.Add(this.rdReceived);
            this.groupBox1.Controls.Add(this.rdCurrent);
            this.groupBox1.Location = new System.Drawing.Point(221, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Type";
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(16, 66);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(199, 21);
            this.cbWarehouse.TabIndex = 3;
            // 
            // rdCurrent
            // 
            this.rdCurrent.AutoSize = true;
            this.rdCurrent.Location = new System.Drawing.Point(27, 22);
            this.rdCurrent.Name = "rdCurrent";
            this.rdCurrent.Size = new System.Drawing.Size(90, 17);
            this.rdCurrent.TabIndex = 0;
            this.rdCurrent.TabStop = true;
            this.rdCurrent.Text = "Current Stock";
            this.rdCurrent.UseVisualStyleBackColor = true;
            // 
            // rdReceived
            // 
            this.rdReceived.AutoSize = true;
            this.rdReceived.Location = new System.Drawing.Point(199, 22);
            this.rdReceived.Name = "rdReceived";
            this.rdReceived.Size = new System.Drawing.Size(102, 17);
            this.rdReceived.TabIndex = 1;
            this.rdReceived.TabStop = true;
            this.rdReceived.Text = "Received Stock";
            this.rdReceived.UseVisualStyleBackColor = true;
            // 
            // rdOutOf
            // 
            this.rdOutOf.AutoSize = true;
            this.rdOutOf.Location = new System.Drawing.Point(367, 22);
            this.rdOutOf.Name = "rdOutOf";
            this.rdOutOf.Size = new System.Drawing.Size(83, 17);
            this.rdOutOf.TabIndex = 2;
            this.rdOutOf.TabStop = true;
            this.rdOutOf.Text = "Out of stock";
            this.rdOutOf.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partname,
            this.CurrentStock,
            this.ReceivedStock,
            this.Action});
            this.dataGridView1.Location = new System.Drawing.Point(14, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(750, 166);
            this.dataGridView1.TabIndex = 4;
            // 
            // Partname
            // 
            this.Partname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Partname.HeaderText = "Partname";
            this.Partname.Name = "Partname";
            this.Partname.ReadOnly = true;
            // 
            // CurrentStock
            // 
            this.CurrentStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CurrentStock.HeaderText = "CurrentStock";
            this.CurrentStock.Name = "CurrentStock";
            this.CurrentStock.ReadOnly = true;
            // 
            // ReceivedStock
            // 
            this.ReceivedStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReceivedStock.HeaderText = "ReceivedStock";
            this.ReceivedStock.Name = "ReceivedStock";
            this.ReceivedStock.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 333);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbWarehouse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InventoryReport";
            this.Text = "InventoryReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdOutOf;
        private System.Windows.Forms.RadioButton rdReceived;
        private System.Windows.Forms.RadioButton rdCurrent;
        private System.Windows.Forms.ComboBox cbWarehouse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partname;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedStock;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
    }
}