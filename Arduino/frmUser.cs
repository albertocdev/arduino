using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Arduino
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
            portCOM.PortName = "COM1";
            portCOM.BaudRate = 9600;
            portCOM.Open(); 
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acerca vAcerca = new acerca();
            vAcerca.ShowDialog();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin vLogin = new frmLogin();
            vLogin.Show();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
        }

  

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (portCOM.IsOpen)
                portCOM.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            portCOM.Write("0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            portCOM.Write("1");
        }

    }
}
