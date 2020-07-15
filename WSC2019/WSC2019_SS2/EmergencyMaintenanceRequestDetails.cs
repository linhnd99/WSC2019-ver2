using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019_SS2
{
    public partial class EmergencyMaintenanceRequestDetails : Form
    {
        public EmergencyMaintenance emergencyMaintenance;
        WSC2019_SS2Entities db;
        public EmergencyMaintenanceRequestDetails()
        {
            InitializeComponent();
            db = new WSC2019_SS2Entities();
        }

        private void EmergencyMaintenanceRequestDetails_Load(object sender, EventArgs e)
        {
            this.lblAssetSN.Text = emergencyMaintenance.Asset.AssetSN;
            this.lblAssetName.Text = emergencyMaintenance.Asset.AssetName;
            this.lblDepartment.Text = emergencyMaintenance.Asset.DepartmentLocation.Department.Name;

            if (emergencyMaintenance.EMStartDate != null)
                dpkStartDate.Value = emergencyMaintenance.EMStartDate.Value;
            if (emergencyMaintenance.EMTechinicianNote != null)
                txtNote.Text = emergencyMaintenance.EMTechinicianNote;

            cbPart.DataSource = db.Parts.ToList();
            cbPart.DisplayMember = "Name";
            cbPart.ValueMember = "ID";

            LoadDataFromDB();
        }

        void LoadDataFromDB()
        {
            dgvItem.Rows.Clear();
            List<ChangedPart> changedParts = db.ChangedParts.Where(x=>x.EmergencyMaintenanceID == emergencyMaintenance.ID).ToList();
            foreach (ChangedPart cp in changedParts)
            {
                dgvItem.Rows.Add(cp.Part.Name, cp.Amount, "Remove", cp.ID,0,cp.Part.ID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Part p = (cbPart.SelectedItem as Part);
            try
            {
                double x = double.Parse(txtAmount.Text);
                if (x<0)
                {
                    MessageBox.Show("Amount is invalid!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Amount is invalid!");
                return;
            }

            //check exists
            for (int i=0;i<dgvItem.Rows.Count;i++)
            {
                int pid = Convert.ToInt32(dgvItem.Rows[i].Cells["PartID"].Value);
                if (pid == p.ID)
                {
                    MessageBox.Show("Part existed");
                    return;
                }
            }

            dgvItem.Rows.Add(p.Name, txtAmount.Text, "Remove", null, 1,p.ID);
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = dgvItem.CurrentCell.ColumnIndex;
            if (col == 2) //Click remove
            {
                if (dgvItem.CurrentRow.Cells["Flag"].Value.ToString() == "1")
                    dgvItem.Rows.Remove(dgvItem.CurrentRow);
                else
                {
                    int cpid = Convert.ToInt32(dgvItem.CurrentRow.Cells["ID"].Value);
                    ChangedPart cp = db.ChangedParts.Where(x => x.ID == cpid).SingleOrDefault();
                    if (cp != null)
                        db.ChangedParts.Remove(cp);
                    dgvItem.Rows.Remove(dgvItem.CurrentRow);
                }
            }
        }

        private void tnSubmit_Click(object sender, EventArgs e)
        {
            for (int i=0;i<dgvItem.Rows.Count;i++)
            {
                ChangedPart cp = new ChangedPart();
                cp.EmergencyMaintenanceID = emergencyMaintenance.ID;
                cp.PartID = (cbPart.SelectedItem as Part).ID;
                cp.Amount = Convert.ToDouble(dgvItem.Rows[i].Cells["Amount"].Value);

                db.ChangedParts.Add(cp);
            }
            emergencyMaintenance = db.EmergencyMaintenances.Where(x => x.ID == emergencyMaintenance.ID).SingleOrDefault();
            emergencyMaintenance.EMTechinicianNote = txtNote.Text;
            try
            {
                if (dpkEndDate.Text != "  -  -")
                {
                    DateTime endDate = Convert.ToDateTime(dpkEndDate.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("End date is invalid");
                return;
            }
            emergencyMaintenance.EMStartDate = dpkStartDate.Value;
            if (dpkEndDate.Text!= "  -  -") 
                emergencyMaintenance.EMEndDate = Convert.ToDateTime(dpkEndDate.Text);
            db.SaveChanges();
            MessageBox.Show("Submit successfully");
        }
    }
}
