namespace WSC2019_SS2
{
    partial class ManagingEMRequestsByAccountableParty
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
            this.dgvAsset = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.AssetSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastClosedEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfEMs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAsset
            // 
            this.dgvAsset.AllowUserToAddRows = false;
            this.dgvAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssetSN,
            this.AssetName,
            this.LastClosedEM,
            this.NumberOfEMs,
            this.ID});
            this.dgvAsset.Location = new System.Drawing.Point(12, 56);
            this.dgvAsset.Name = "dgvAsset";
            this.dgvAsset.Size = new System.Drawing.Size(776, 289);
            this.dgvAsset.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Assets:";
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(12, 369);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(366, 23);
            this.btnSendRequest.TabIndex = 2;
            this.btnSendRequest.Text = "Send Emergency Maintenance Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // AssetSN
            // 
            this.AssetSN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AssetSN.HeaderText = "AssetSN";
            this.AssetSN.Name = "AssetSN";
            this.AssetSN.ReadOnly = true;
            // 
            // AssetName
            // 
            this.AssetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AssetName.HeaderText = "AssetName";
            this.AssetName.Name = "AssetName";
            this.AssetName.ReadOnly = true;
            // 
            // LastClosedEM
            // 
            this.LastClosedEM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastClosedEM.HeaderText = "LastClosedEM";
            this.LastClosedEM.Name = "LastClosedEM";
            this.LastClosedEM.ReadOnly = true;
            // 
            // NumberOfEMs
            // 
            this.NumberOfEMs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberOfEMs.HeaderText = "NumberOfEMs";
            this.NumberOfEMs.Name = "NumberOfEMs";
            this.NumberOfEMs.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ManagingEMRequestsByAccountableParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAsset);
            this.Name = "ManagingEMRequestsByAccountableParty";
            this.Text = "Emergency Maintenance Management";
            this.Load += new System.EventHandler(this.ManagingEMRequestsByAccountableParty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastClosedEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfEMs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}