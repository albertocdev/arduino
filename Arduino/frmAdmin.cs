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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin vLogin = new frmLogin();
            vLogin.Show();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            Users usersCtrl = new Users();
            usersCtrl.getUsers(dataGridView1);
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editUser vEdit = new editUser();
            
            vEdit.txtNo.Text = dataGridView1.Rows[e.RowIndex].Cells["No"].FormattedValue.ToString();
            vEdit.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
            vEdit.txtUser.Text = dataGridView1.Rows[e.RowIndex].Cells["Usuario"].FormattedValue.ToString();
            vEdit.cboLevel.Text = dataGridView1.Rows[e.RowIndex].Cells["Rol"].FormattedValue.ToString();
            this.Hide();
            vEdit.Show();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUser vAddUser = new addUser();
            this.Hide();
            vAddUser.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acerca vAcerca = new acerca();
            vAcerca.ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin vLogin = new frmLogin();
            vLogin.Show();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogs vLogs = new frmLogs();
            vLogs.Show();
        }
    }
}
