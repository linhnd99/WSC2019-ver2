using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019_SS4
{
    public partial class PurchaseOrder : Form
    {
        WSC2019_SS4Entities db;
        public OrderItem selectedOrderItem;
        public PurchaseOrder()
        {
            InitializeComponent();
            db = new WSC2019_SS4Entities();
            selectedOrderItem = null;
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            cbSupplier.DataSource = db.Suppliers.ToList();
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "ID";

            cbWarehouse.DataSource = db.Warehouses.ToList();
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "ID";

            cbPart.DataSource = db.Parts.ToList();
            cbPart.DisplayMember = "Name";
            cbPart.ValueMember = "ID";

            if (selectedOrderItem != null)
            {
                //Load orderitem to dgvPart
                cbSupplier.SelectedValue = selectedOrderItem.Order.SupplierID;
                cbWarehouse.SelectedValue = selectedOrderItem.Order.DestinationWarehouseID;
                txtDate.Text = selectedOrderItem.Order.Date.Value.ToString("dd-MM-yyyy");

                dgvPart.Rows.Clear();
                foreach (OrderItem oi in selectedOrderItem.Order.OrderItems)
                {
                    dgvPart.Rows.Add(oi.Part.Name, oi.BatchNumber, oi.Amount, "Remove",oi.Part.ID,"0");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(txtAmount.Text);
                if (x<=0)
                {
                    MessageBox.Show("Amount is invalid!");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Amount is invalid!");
                return;
            }

            //check is entering batchnumber?
            if ((cbPart.SelectedItem as Part).BatchNumerHasRequired==true && txtBatchNumber.Text.Trim()=="")
            {
                MessageBox.Show("Batchnumber has required");
                return;
            }

            //check exists partname and batchnumber
            int partid = (int)cbPart.SelectedValue;
            string batchNumber = txtBatchNumber.Text;
            OrderItem test = db.OrderItems.Where(x => x.BatchNumber == batchNumber && x.PartID == partid).FirstOrDefault();
            if (test!=null)
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

            dgvPart.Rows.Add((cbPart.SelectedItem as Part).Name, txtBatchNumber.Text, txtAmount.Text, "Remove", (cbPart.SelectedItem as Part).ID,"1");
        }

        private void dgvPart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPart.CurrentCell.ColumnIndex==3) //Remove
            {
                int partid = Convert.ToInt32(dgvPart.CurrentRow.Cells["PartID"].Value);
                OrderItem orderItem = db.OrderItems.Where(x => x.PartID == partid && x.BatchNumber == txtBatchNumber.Text).SingleOrDefault();
                if (orderItem != null)
                {
                    db.OrderItems.Remove(orderItem);
                }
                dgvPart.Rows.Remove(dgvPart.CurrentRow);
                db.SaveChanges();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
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
            
            //new purchase order
            if (selectedOrderItem == null)
            {
                //Add order
                Order order = new Order();
                order.SupplierID = (int?)cbSupplier.SelectedValue;
                order.DestinationWarehouseID = (int?)cbWarehouse.SelectedValue;
                order.SourceWarehouseID = (int?)cbWarehouse.SelectedValue;
                order.TransactionTypeID = 1;
                order.Date = Convert.ToDateTime(txtDate.Text);
                db.Orders.Add(order);
                db.SaveChanges();
                order = db.Orders.Where(x => x.SupplierID == order.SupplierID && order.DestinationWarehouseID == x.DestinationWarehouseID && order.TransactionTypeID == x.TransactionTypeID && x.Date == order.Date).SingleOrDefault();

                //Add orderitem
                for (int i = 0; i < dgvPart.Rows.Count; i++)
                    if (dgvPart.Rows[i].Cells["Flag"].Value.ToString()=="1")
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
                Order order = db.Orders.Where(x => x.ID == selectedOrderItem.OrderID).SingleOrDefault() ;
                order.SupplierID = (int?)cbSupplier.SelectedValue;
                order.DestinationWarehouseID = (int?)cbWarehouse.SelectedValue;
                order.SourceWarehouseID = (int?)cbWarehouse.SelectedValue;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
