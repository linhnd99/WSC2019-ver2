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
    public partial class RegisteringEMRequest : Form
    {
        WSC2019_SS2Entities db;
        public Asset selectedAsset;
        public RegisteringEMRequest()
        {
            InitializeComponent();
            db = new WSC2019_SS2Entities();
        }

        private void RegisteringEMRequest_Load(object sender, EventArgs e)
        {
            this.lblAssetSN.Text = selectedAsset.AssetSN;
            this.lblAssetName.Text = selectedAsset.AssetName;
            this.lblDepartment.Text = selectedAsset.DepartmentLocation.Department.Name;

            cbPriority.DataSource = db.Priorities.ToList();
            cbPriority.DisplayMember = "Name";
            cbPriority.ValueMember = "ID";

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim()=="" || txtOtherConsiderations.Text.Trim() =="")
            {
                MessageBox.Show("A field is empty!");
                return;
            }
            //check asset is opening or not?
            EmergencyMaintenance temp = db.EmergencyMaintenances.Where(x => x.AssetID == selectedAsset.ID && x.EMReportDate != null && x.EMEndDate == null).FirstOrDefault();
            if (temp!=null)
            {
                MessageBox.Show("This asset is opening on system");
                return;
            }
            EmergencyMaintenance em = new EmergencyMaintenance();
            em.AssetID = this.selectedAsset.ID;
            em.PriorityID = (cbPriority.SelectedItem as Priority).ID;
            em.DescriptionEmergency = txtDescription.Text;
            em.OtherConsiderations = txtOtherConsiderations.Text;
            em.EMReportDate = DateTime.Now;
            db.EmergencyMaintenances.Add(em);
            db.SaveChanges();
            MessageBox.Show("Send request successfully");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
