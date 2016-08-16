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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Users userCtrl = new Users();
            if (txtUsername.Text != "" || txtPassword.Text != "")
            {
                if (userCtrl.logIn(txtUsername.Text, txtPassword.Text) == true)
                {
                    if (userCtrl.level == 1)
                    {
                        this.Hide();
                        frmAdmin vAdmin = new frmAdmin();
                        vAdmin.Show();
                    }
                    if (userCtrl.level == 2)
                    {
                        this.Hide();
                        frmUser vUser = new frmUser();
                        vUser.Show();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
            