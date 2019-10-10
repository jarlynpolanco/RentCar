using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.UI.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }  
        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBoxUser.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar los campos usuario y contraseña para poder iniciar.", "WARNING",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (user == "Admin" && password == "Admin")
            {
                frmPrincipal frm = new frmPrincipal();
                frm.Show();
                Hide();
            }
            else 
            {
                MessageBox.Show("El usuario o contraseña son incorrectos.", "WARNING",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxUser.Text = string.Empty;
                textBoxPassword.Text = string.Empty;

                return;
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
