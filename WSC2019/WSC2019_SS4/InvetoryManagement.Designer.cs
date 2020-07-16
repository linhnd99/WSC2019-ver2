namespace WSC2019_SS4
{
    partial class InvetoryManagement
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaseOrderManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvManagement = new System.Windows.Forms.DataGridView();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Action2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.OrderItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderManagementToolStripMenuItem,
            this.warehouseManagementToolStripMenuItem,
            this.inventoryReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // purchaseOrderManagementToolStripMenuItem
            // 
            this.purchaseOrderManagementToolStripMenuItem.Name = "purchaseOrderManagementToolStripMenuItem";
            this.purchaseOrderManagementToolStripMenuItem.Size = new System.Drawing.Size(174, 20);
            this.purchaseOrderManagementToolStripMenuItem.Text = "Purchase Order Management";
            this.purchaseOrderManagementToolStripMenuItem.Click += new System.EventHandler(this.purchaseOrderManagementToolStripMenuItem_Click);
            // 
            // warehouseManagementToolStripMenuItem
            // 
            this.warehouseManagementToolStripMenuItem.Name = "warehouseManagementToolStripMenuItem";
            this.warehouseManagementToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.warehouseManagementToolStripMenuItem.Text = "Warehouse Management";
            // 
            // inventoryReportToolStripMenuItem
            // 
            this.inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            this.inventoryReportToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.inventoryReportToolStripMenuItem.Text = "Inventory Report";
            // 
            // dgvManagement
            // 
            this.dgvManagement.AllowUserToAddRows = false;
            this.dgvManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartName,
            this.TransactionType,
            this.Date,
            this.Amount,
            this.Source,
            this.Destination,
            this.Action,
            this.Action2,
            this.OrderItemID,
            this.TransactionTypeID});
            this.dgvManagement.Location = new System.Drawing.Point(2, 38);
            this.dgvManagement.Name = "dgvManagement";
            this.dgvManagement.Size = new System.Drawing.Size(899, 477);
            this.dgvManagement.TabIndex = 1;
            this.dgvManagement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagement_CellContentClick);
            // 
            // PartName
            // 
            this.PartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartName.HeaderText = "PartName";
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            // 
            // TransactionType
            // 
            this.TransactionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TransactionType.HeaderText = "TransactionType";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Source
            // 
            this.Source.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // Destination
            // 
            this.Destination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
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
            // Action2
            // 
            this.Action2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action2.HeaderText = "Action";
            this.Action2.Name = "Action2";
            this.Action2.ReadOnly = true;
            // 
            // OrderItemID
            // 
            this.OrderItemID.HeaderText = "OrderItemID";
            this.OrderItemID.Name = "OrderItemID";
            this.OrderItemID.Visible = false;
            // 
            // TransactionTypeID
            // 
            this.TransactionTypeID.HeaderText = "TransactionTypeID";
            this.TransactionTypeID.Name = "TransactionTypeID";
            this.TransactionTypeID.Visible = false;
            // 
            // InvetoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 515);
            this.Controls.Add(this.dgvManagement);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InvetoryManagement";
            this.Text = "Inventory Management";
            this.Load += new System.EventHandler(this.InvetoryManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvManagement;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.DataGridViewLinkColumn Action2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionTypeID;
    }
}

