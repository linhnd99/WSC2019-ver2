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
    public partial class ManagingEMRequestsByMaintenanceManager : Form
    {
        WSC2019_SS2Entities db;
        public ManagingEMRequestsByMaintenanceManager()
        {
            InitializeComponent();
            db = new WSC2019_SS2Entities();
        }

        private int Compare(EmergencyMaintenance a, EmergencyMaintenance b)
        {
            if (a.PriorityID < b.PriorityID) return -1;
            else if (a.PriorityID > b.PriorityID) return 1;
            else
            {
                DateTime aa = Convert.ToDateTime(a.EMReportDate);
                DateTime bb = Convert.ToDateTime(b.EMReportDate);
                return aa.CompareTo(bb);
            }
        }

        void LoadDataFromDB()
        {
            List<EmergencyMaintenance> listEM = db.EmergencyMaintenances.Where(x => x.EMEndDate == null).ToList();
            listEM.Sort(Compare);

            dgvAsset.Rows.Clear();
            foreach (EmergencyMaintenance em in listEM)
            {
                dgvAsset.Rows.Add(em.Asset.AssetSN, em.Asset.AssetName, em.EMReportDate.Value.ToString("dd/MM/yyyy"), em.Asset.Employee.FirstName + " " + em.Asset.Employee.LastName, em.Asset.DepartmentLocation.Department.Name, em.ID);
            }
        }

        private void ManagingEMRequestsByMaintenanceManager_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

        private void btnManageRequest_Click(object sender, EventArgs e)
        {
            EmergencyMaintenanceRequestDetails form2 = new EmergencyMaintenanceRequestDetails();
            int emid = Convert.ToInt32(dgvAsset.CurrentRow.Cells["ID"].Value);
            form2.emergencyMaintenance = db.EmergencyMaintenances.Where(x => x.ID == emid).SingleOrDefault();
            form2.ShowDialog();
            LoadDataFromDB();
        }
    }
}
