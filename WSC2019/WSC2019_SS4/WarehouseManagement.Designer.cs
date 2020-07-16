namespace WSC2019_SS4
{
    partial class WarehouseManagement
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.cbBatchNumber = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.dgvPart = new System.Windows.Forms.DataGridView();
            this.Partname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source warehouse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination warehouse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPart);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.cbBatchNumber);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cbPart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 212);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part list";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Part name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Batch number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Amount";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(702, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add to list";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(49, 36);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(185, 21);
            this.cbSource.TabIndex = 4;
            // 
            // cbPart
            // 
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Location = new System.Drawing.Point(100, 31);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(126, 21);
            this.cbPart.TabIndex = 5;
            // 
            // cbDestination
            // 
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Location = new System.Drawing.Point(380, 36);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(185, 21);
            this.cbDestination.TabIndex = 6;
            // 
            // cbBatchNumber
            // 
            this.cbBatchNumber.FormattingEnabled = true;
            this.cbBatchNumber.Location = new System.Drawing.Point(372, 28);
            this.cbBatchNumber.Name = "cbBatchNumber";
            this.cbBatchNumber.Size = new System.Drawing.Size(129, 21);
            this.cbBatchNumber.TabIndex = 8;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(572, 31);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 9;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(108, 68);
            this.txtDate.Mask = "00/00/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(126, 20);
            this.txtDate.TabIndex = 7;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            // 
            // dgvPart
            // 
            this.dgvPart.AllowUserToAddRows = false;
            this.dgvPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partname,
            this.BatchNumber,
            this.Amount,
            this.Action});
            this.dgvPart.Location = new System.Drawing.Point(6, 65);
            this.dgvPart.Name = "dgvPart";
            this.dgvPart.Size = new System.Drawing.Size(770, 146);
            this.dgvPart.TabIndex = 10;
            // 
            // Partname
            // 
            this.Partname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Partname.HeaderText = "Partname";
            this.Partname.Name = "Partname";
            this.Partname.ReadOnly = true;
            // 
            // BatchNumber
            // 
            this.BatchNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BatchNumber.HeaderText = "BatchNumber";
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
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
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(320, 346);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(423, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // WarehouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 381);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.cbDestination);
            this.Controls.Add(this.cbSource);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WarehouseManagement";
            this.Text = "Warehouse Management";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPart;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cbBatchNumber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partname;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}