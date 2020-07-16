using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019_SS4
{
    public partial class InvetoryManagement : Form
    {
        WSC2019_SS4Entities db;
        public InvetoryManagement()
        {
            InitializeComponent();
            db = new WSC2019_SS4Entities();
        }

        private void InvetoryManagement_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

        private int Compare(OrderItem a, OrderItem b)
        {
            DateTime aa = a.Order.Date.Value;
            DateTime bb = b.Order.Date.Value;
            if (aa.CompareTo(bb) > 0) return 1;
            else if (aa.CompareTo(bb) < 0) return -1;
            else return a.Order.TransactionType.ID == 1 ? -1 : 1;
        }

        public void LoadDataFromDB()
        {
            List<OrderItem> listOrder = db.OrderItems.ToList();
            dgvManagement.Rows.Clear();
            listOrder.Sort(Compare);
            foreach (OrderItem orderItem in listOrder)
            {
                dgvManagement.Rows.Add(orderItem.Part.Name, orderItem.Order.TransactionType.Name, orderItem.Order.Date.Value.ToString("dd/MM/yyyy"),orderItem.Amount, orderItem.Order.Warehouse.Name, orderItem.Order.Warehouse1.Name,"Edit","Remove",orderItem.ID,orderItem.Order.TransactionTypeID);
                if (orderItem.Order.TransactionTypeID == 1)
                    dgvManagement.Rows[dgvManagement.Rows.Count - 1].Cells["Amount"].Style.BackColor = Color.LightGreen;
            }
        }

        private void purchaseOrderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrder form2 = new PurchaseOrder();
            form2.ShowDialog();
        }

        private void dgvManagement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvManagement.CurrentCell.ColumnIndex == 7) //remove
            {
                if (MessageBox.Show("Do you want to delete this record?","",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                int oiid = Convert.ToInt32(dgvManagement.CurrentRow.Cells["OrderItemID"].Value);
                OrderItem orderitem = db.OrderItems.Where(x => x.ID == oiid).SingleOrDefault();
                db.OrderItems.Remove(orderitem);
                dgvManagement.Rows.Remove(dgvManagement.CurrentRow);
                db.SaveChanges();
            }
            else if (dgvManagement.CurrentCell.ColumnIndex == 6) //edit
            {
                int transactionid = Convert.ToInt32(dgvManagement.CurrentRow.Cells["TransactionTypeID"].Value);
                int oiid = Convert.ToInt32(dgvManagement.CurrentRow.Cells["OrderItemID"].Value);
                if (transactionid == 1) //edit purchase order
                {
                    PurchaseOrder form2 = new PurchaseOrder();
                    form2.selectedOrderItem = db.OrderItems.Where(x => x.ID == oiid).SingleOrDefault();
                    form2.ShowDialog();
                }    
            }
        }
    }
}
