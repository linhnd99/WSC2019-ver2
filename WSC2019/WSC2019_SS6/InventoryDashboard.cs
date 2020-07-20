using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSC2019_SS6
{
    public partial class Form1 : Form
    {
        WSC2019_SS6Entities db;
        public Form1()
        {
            InitializeComponent();
            db = new WSC2019_SS6Entities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataToEMSpendingByDepartment();
        }

        private void LoadDataToEMSpendingByDepartment()
        {
            //<date,<partid,amount>>
            Dictionary<string, Dictionary<int, double>> emSpending = new Dictionary<string, Dictionary<int, double>>();
            foreach (Order order in db.Orders.ToList())
            {
                foreach (OrderItem orderitem in order.OrderItems.ToList())
                {
                    if (!emSpending.ContainsKey(order.Date.Value.ToString("yyyy-MM"))) emSpending.Add(order.Date.Value.ToString("yyyy-MM"), new Dictionary<int, double>());
                    if (!emSpending[order.Date.Value.ToString("yyyy-MM")].ContainsKey(Convert.ToInt32(orderitem.PartID))) emSpending[order.Date.Value.ToString("yyyy-MM")].Add(Convert.ToInt32(orderitem.PartID), 0);
                    emSpending[order.Date.Value.ToString("yyyy-MM")][Convert.ToInt32(orderitem.PartID)] += Convert.ToDouble(orderitem.Amount);
                }
            }

            DataGridViewColumn col1 = new DataGridViewColumn();
            col1.CellTemplate = new DataGridViewTextBoxCell();
            col1.Name = "Department";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col1.HeaderText = "Department";
            dgvEMSpending.Columns.Add(col1);

            foreach (string date in emSpending.Keys)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = date;
                col.HeaderText = date;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.CellTemplate = new DataGridViewTextBoxCell();

                dgvEMSpending.Columns.Add(col);
            }
            List<string> allKey = emSpending.Keys.ToList();
            foreach (string date in allKey)
                if (date == "Department") continue;
                else
                {
                    dgvEMSpending.Rows.Add();
                    foreach (int partid in emSpending[date].Keys)
                    {
                        dgvEMSpending.Rows[dgvEMSpending.Rows.Count - 1].Cells[0].Value = db.Parts.Where(x => x.ID == partid).SingleOrDefault().Name;
                        for (int i = 1; i < dgvEMSpending.Columns.Count; i++)
                        {
                            if (!emSpending.ContainsKey(dgvEMSpending.Columns[i].Name)) emSpending.Add(dgvEMSpending.Columns[i].Name, new Dictionary<int, double>());
                            if (!emSpending[dgvEMSpending.Columns[i].Name].ContainsKey(partid)) emSpending[dgvEMSpending.Columns[i].Name].Add(partid, 0);
                            double val = emSpending[dgvEMSpending.Columns[i].Name][partid];
                            dgvEMSpending.Rows[dgvEMSpending.RowCount - 1].Cells[i].Value = val;
                        }
                    }
                }

            //Make color
            for (int i = 1; i < dgvEMSpending.ColumnCount; i++)
            {
                int max = 0;
                int min = 0;
                for (int j = 1; j < dgvEMSpending.RowCount; j++)
                {
                    if (Convert.ToDouble(dgvEMSpending.Rows[j].Cells[i].Value) < Convert.ToDouble(dgvEMSpending.Rows[min].Cells[i].Value) && Convert.ToDouble(dgvEMSpending.Rows[j].Cells[i].Value) != 0) 
                        min = j;
                    if (Convert.ToDouble(dgvEMSpending.Rows[j].Cells[i].Value) > Convert.ToDouble(dgvEMSpending.Rows[max].Cells[i].Value) && Convert.ToDouble(dgvEMSpending.Rows[j].Cells[i].Value) != 0 ) 
                        max = j;
                }
                if (min != max)
                {
                    dgvEMSpending.Rows[min].Cells[i].Style.BackColor = Color.Red;
                    dgvEMSpending.Rows[max].Cells[i].Style.BackColor = Color.Green;
                }
            }
        }

        private void LoadDataToMostUsedPart()
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
 