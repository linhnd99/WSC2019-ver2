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
    public partial class Login : Form
    {
        WSC2019_SS2Entities db;
        public Login()
        {
            InitializeComponent();
            db = new WSC2019_SS2Entities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginFunction(txtUsername.Text, txtPassword.Text);
        }

        void LoginFunction(string username, string password)
        {
            Employee em = db.Employees.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            if (em == null)
            {
                MessageBox.Show("Mật khẩu hoặc tài khoản không đúng");
                return;
            }
            else if (em.isAdmin == true)
            {
                ManagingEMRequestsByMaintenanceManager form2 = new ManagingEMRequestsByMaintenanceManager();
                form2.ShowDialog();
            }
            else
            {
                ManagingEMRequestsByAccountableParty form2 = new ManagingEMRequestsByAccountableParty();
                form2.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            LoginFunction("user1", "123");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            LoginFunction("admin", "123");
        }
    }
}
