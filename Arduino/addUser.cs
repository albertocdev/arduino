using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Arduino
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void addUser_Load(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Users usersCtrl = new Users();
            if (txtPassword.Text == txtPasswordC.Text)
            {
                usersCtrl.addUser(txtName.Text, txtUser.Text, txtPassword.Text, cboLevel.Text);
                this.Hide();
                frmAdmin vAdmin = new frmAdmin();
                vAdmin.Show();
            }
            else
            {
                MessageBox.Show("Las contraseñas ingresadas no coincides.");
                txtPassword.Focus();
            }
            
        }

        private void txtPasswordC_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordC.Text) {
                txtPasswordC.Focus();
            }
        }
    }
}
