using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino
{
    public partial class editUser : Form
    {
        public editUser()
        {
            InitializeComponent();
        }

        private void editUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users ctrlUsers = new Users();
            ctrlUsers.deleteUser(int.Parse(this.txtNo.Text));
            this.Hide();
            frmAdmin vAdmin = new frmAdmin();
            vAdmin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users ctrlUsers = new Users();
            ctrlUsers.editUser(int.Parse(txtNo.Text), txtName.Text, txtUser.Text, cboLevel.Text);
            this.Hide();
            frmAdmin vAdmin = new frmAdmin();
            vAdmin.Show();
        }
    }
}
