using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019_SS4
{
    public partial class WarehouseManagement : Form
    {
        WSC2019_SS4Entities db;
        public OrderItem selectedOrderItem;
        public WarehouseManagement()
        {
            InitializeComponent();
            db = new WSC2019_SS4Entities();
            selectedOrderItem = null;
        }

        private void WarehouseManagement_Load(object sender, EventArgs e)
        {
            cbSource.DataSource = db.Warehouses.ToList();
            cbSource.DisplayMember = "Name";
            cbSource.ValueMember = "ID";

            cbDestination.DataSource = db.Warehouses.ToList();
            cbDestination.ValueMember = "ID";
            cbDestination.DisplayMember = "Name";

            cbPart.DataSource = db.Parts.ToList();
            cbPart.DisplayMember = "Name";
            cbPart.ValueMember = "ID";
            cbPart.SelectedIndex = 0;

            int partid = (int)cbPart.SelectedValue;
            cbBatchNumber.DataSource = db.OrderItems.Where(x => x.PartID == partid).Select(x => new
            {
                ID = x.BatchNumber,
                BatchNumber = x.BatchNumber
            }).ToList();
            cbBatchNumber.DisplayMember = "BatchNumber";
            cbBatchNumber.ValueMember = "ID";
        }

        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int partid = (cbPart.SelectedItem as Part).ID;
            cbBatchNumber.DataSource = db.OrderItems.Where(x => x.PartID == partid).Select(x => new
            {
                ID = x.BatchNumber,
                BatchNumber = x.BatchNumber
            }).ToList();
            cbBatchNumber.DisplayMember = "BatchNumber";
            cbBatchNumber.ValueMember = "ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtAmount.Text);
                if (a <= 0)
                {
                    MessageBox.Show("Amount is invalid");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Amount is invalid");
                return;
            }
            //check exists partname and batchnumber
            int partid = (int)cbPart.SelectedValue;
            string batchNumber = cbBatchNumber.SelectedValue.ToString();
            OrderItem test = db.OrderItems.Where(x => x.BatchNumber == batchNumber && x.PartID == partid).FirstOrDefault();
            if (test != null)
            {
                MessageBox.Show("Part and batch number existed");
                return;
            }
            else
            {
                bool ischeck = false;
                for (int i = 0; i < dgvPart.Rows.Count; i++)
                    if (batchNumber == dgvPart.Rows[i].Cells["BatchNumber"].Value.ToString() && partid == Convert.ToInt32(dgvPart.Rows[i].Cells["PartID"].Value))
                    {
                        ischeck = true;
                        break;
                    }
                if (ischeck)
                {
                    MessageBox.Show("Part and batch number existed");
                    return;
                }
            }

            //check same part has same amount
            double amount = double.Parse(txtAmount.Text);
            test = db.OrderItems.Where(x => x.PartID == partid && x.Amount == amount).FirstOrDefault();
            if (test != null)
            {
                MessageBox.Show("This part had this amount");
                return;
            }
            else
            {
                bool ischeck = false;
                for (int i = 0; i < dgvPart.Rows.Count; i++)
                    if (amount == Convert.ToDouble(dgvPart.Rows[i].Cells["Amount"].Value))
                    {
                        ischeck = true;
                        break;
                    }
                if (ischeck)
                {
                    MessageBox.Show("This part had this amount");
                    return;
                }
            }

            dgvPart.Rows.Add((cbPart.SelectedItem as Part).Name, cbBatchNumber.SelectedValue, double.Parse(txtAmount.Text), "Remove", cbPart.SelectedValue);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cbSource.SelectedValue == cbDestination.SelectedValue)
            {
                MessageBox.Show("Source warehouse is like Destination warehouse");
                return;
            }
            if (dgvPart.Rows.Count == 0)
            {
                MessageBox.Show("At least one part needs to be added to the order for it to be valid");
                return;
            }
            if (txtDate.Text == "  -  -")
            {
                MessageBox.Show("Date is empty");
                return;
            }
            try
            {
                Convert.ToDateTime(txtDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Date is invalid");
                return;
            }

            //new Warehouse management
            if (selectedOrderItem == null)
            {
                //Add order
                Order order = new Order();
                //order.SupplierID = (int?)cbSupplier.SelectedValue;
                order.DestinationWarehouseID = (int?)cbSource.SelectedValue;
                order.SourceWarehouseID = (int?)cbDestination.SelectedValue;
                order.TransactionTypeID = 2;
                order.Date = Convert.ToDateTime(txtDate.Text);
                db.Orders.Add(order);
                db.SaveChanges();
                order = db.Orders.Where(x => x.SupplierID == order.SupplierID && order.DestinationWarehouseID == x.DestinationWarehouseID && order.TransactionTypeID == x.TransactionTypeID && x.Date == order.Date).SingleOrDefault();

                //Add orderitem
                for (int i = 0; i < dgvPart.Rows.Count; i++)
                    if (dgvPart.Rows[i].Cells["Flag"].Value.ToString() == "1")
                    {
                        OrderItem orderitem = new OrderItem();
                        orderitem.OrderID = order.ID;
                        orderitem.PartID = Convert.ToInt32(dgvPart.Rows[i].Cells["PartID"].Value);
                        orderitem.BatchNumber = dgvPart.Rows[i].Cells["BatchNumber"].Value.ToString();
                        orderitem.Amount = Convert.ToDouble(dgvPart.Rows[i].Cells["Amount"].Value);
                        db.OrderItems.Add(orderitem);
                    }
                db.SaveChanges();
            }
            else //edit purchase order
            {
                Order order = db.Orders.Where(x => x.ID == selectedOrderItem.OrderID).SingleOrDefault();
                //order.SupplierID = (int?)cbSupplier.SelectedValue;
                order.DestinationWarehouseID = (int?)cbSource.SelectedValue;
                order.SourceWarehouseID = (int?)cbDestination.SelectedValue;
                order.Date = Convert.ToDateTime(txtDate.Text);
                db.SaveChanges();

                //Add orderitem
                for (int i = 0; i < dgvPart.Rows.Count; i++)
                    if (dgvPart.Rows[i].Cells["Flag"].Value.ToString() == "1")
                    {
                        OrderItem orderitem = new OrderItem();
                        orderitem.OrderID = order.ID;
                        orderitem.PartID = Convert.ToInt32(dgvPart.Rows[i].Cells["PartID"].Value);
                        orderitem.BatchNumber = dgvPart.Rows[i].Cells["BatchNumber"].Value.ToString();
                        orderitem.Amount = Convert.ToDouble(dgvPart.Rows[i].Cells["Amount"].Value);
                        db.OrderItems.Add(orderitem);
                    }
                db.SaveChanges();
            }
            MessageBox.Show("Submit successfully");
        }

        private void dgvPart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPart.CurrentCell.ColumnIndex == 3) //Remove
            {
                int partid = Convert.ToInt32(dgvPart.CurrentRow.Cells["PartID"].Value);
                string batchnumber = cbBatchNumber.SelectedValue.ToString();
                OrderItem orderItem = db.OrderItems.Where(x => x.PartID == partid && x.BatchNumber == batchnumber).SingleOrDefault();
                if (orderItem != null)
                {
                    db.OrderItems.Remove(orderItem);
                }
                dgvPart.Rows.Remove(dgvPart.CurrentRow);
                db.SaveChanges();
            }
        }
    }
}
