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
    public partial class ManagingEMRequestsByAccountableParty : Form
    {
        WSC2019_SS2Entities db;
        public ManagingEMRequestsByAccountableParty()
        {
            InitializeComponent();
            db = new WSC2019_SS2Entities();
        }

        private void ManagingEMRequestsByAccountableParty_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

        void LoadDataFromDB()
        {
            dgvAsset.Rows.Clear();
            foreach (int assetid in db.Assets.Select(x => x.ID).ToList())
            {
                DateTime lastClosedEM = db.EmergencyMaintenances.Where(x => x.AssetID == assetid).Max(x => x.EMEndDate).GetValueOrDefault();
                int number = db.EmergencyMaintenances.Where(x => x.AssetID == assetid && x.EMEndDate != null).Count();
                Asset asset = db.Assets.Where(x => x.ID == assetid).SingleOrDefault();
                dgvAsset.Rows.Add(asset.AssetSN, asset.AssetName, lastClosedEM == null ? "--" : lastClosedEM.ToString("dd/MM/yyyy"), number, assetid);

                if (db.EmergencyMaintenances.Where(x => x.AssetID == assetid && x.EMStartDate != null && x.EMEndDate == null).FirstOrDefault() != null)
                    dgvAsset.Rows[dgvAsset.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                else if (db.EmergencyMaintenances.Where(x => x.AssetID == assetid && x.EMStartDate == null).FirstOrDefault() != null)
                    dgvAsset.Rows[dgvAsset.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gray;
                else
                    dgvAsset.Rows[dgvAsset.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Green;
                    
            }
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            RegisteringEMRequest form2 = new RegisteringEMRequest();
            int assetid = int.Parse(dgvAsset.CurrentRow.Cells["ID"].Value.ToString());
            form2.selectedAsset = db.Assets.Where(x => x.ID == assetid).SingleOrDefault();
            form2.ShowDialog();
            LoadDataFromDB();
        }
    }
}
