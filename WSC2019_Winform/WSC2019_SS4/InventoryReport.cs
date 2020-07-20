using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019_SS4
{
    public partial class InventoryReport : Form
    {
        WSC2019_SS4Entities db;
        public InventoryReport()
        {
            InitializeComponent();
            db = new WSC2019_SS4Entities();
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            cbWarehouse.DataSource = db.Warehouses.ToList();
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "ID";
            cbWarehouse.SelectedIndex = 0;
        }

        private void cbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int warehouseid = (cbWarehouse.SelectedItem as Warehouse).ID;
            List<Part> listPart = db.OrderItems.Where(x => x.Order.Warehouse1.ID == warehouseid).Select(x => x.Part).Distinct().ToList();

            dgvResult.Rows.Clear();

            foreach (Part part in listPart)
            {
                int received = db.OrderItems.Where(x => x.PartID == part.ID && x.Order.DestinationWarehouseID == warehouseid && x.Order.TransactionTypeID == 2).ToList().Count;
                int sent = db.OrderItems.Where(x => x.PartID == part.ID && x.Order.SourceWarehouseID == warehouseid && x.Order.TransactionTypeID == 2).ToList().Count;
                int current = db.OrderItems.Where(x => x.PartID == part.ID && x.Order.DestinationWarehouseID == warehouseid && x.Order.TransactionTypeID == 1).ToList().Count + received - sent;
                dgvResult.Rows.Add(part.Name, current, received, "View Batch Number");
            }
        }
    }
}
