using RentCar.Context;
using RentCar.Data.Entities;
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
    public partial class frmClientes : Form
    {
        private bool editando = false;
        private int RowIndex = 0;
        public frmClientes()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("NOMBRE", "NOMBRE");
            dataGridView1.Columns.Add("CEDULA", "CEDULA");
            dataGridView1.Columns.Add("TARJETA", "TARJETA");
            dataGridView1.Columns.Add("LIMITE", "LIMITE");
            dataGridView1.Columns.Add("TIPOPERSONA", "TIPO PERSONA");


            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Editar";
            btnEdit.Text = "Editar";
            btnEdit.Name = "EDIT";
            btnEdit.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Eliminar";
            btnDelete.Text = "Eliminar";
            btnDelete.Name = "DELETE";
            btnDelete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnDelete);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            loadClients();
        }
        private void loadClients()
        {
            using (var context = new MyContext())
            {
                context.Clients.ToList().ForEach(client =>
                {
                    dataGridView1.Rows.Add(client.ID, client.Name, client.DocumentNumber, client.CreditCardNumber, client.CreditLimit, client.PersonType);
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtCedula.Text) ||
                string.IsNullOrEmpty(txtTarjeta.Text) ||
                string.IsNullOrEmpty(txtLimite.Text)
                )
            {
                MessageBox.Show("El campo debe contener datos para guardar!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!Utilities.Validation.ValidateDocumentNumber(txtCedula.Text)) 
            {
                MessageBox.Show("Debe introducir un documento valido!", "Warning",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                using (var context = new MyContext())
            {
                if (!editando)
                {
                    Client client = new Client { Name = txtName.Text,
                    CreditCardNumber=txtTarjeta.Text,
                    CreditLimit=Convert.ToDouble(txtLimite.Text),
                    DocumentNumber=txtCedula.Text
                    };
                    if (radioButton1.Checked)
                    {
                        client.PersonType = Data.Enums.PersonType.Physical;
                    }else if (radioButton2.Checked)
                    {
                        client.PersonType = Data.Enums.PersonType.Legal;
                    }
                    context.Clients.Add(client);
                    context.SaveChanges();
                    dataGridView1.Rows.Add(client.ID, client.Name, client.DocumentNumber, client.CreditCardNumber, client.CreditLimit, client.PersonType);
                    txtName.Clear();
                    txtCedula.Clear();
                    txtTarjeta.Clear();
                    txtLimite.Clear();
                }
                else
                {
                    int id = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var client = context.Clients.Where(x => x.ID == id).FirstOrDefault();
                    client.Name = txtName.Text;
                    client.DocumentNumber = txtCedula.Text;
                    client.PersonType = radioButton1.Checked ? Data.Enums.PersonType.Physical : Data.Enums.PersonType.Legal;
                    client.CreditCardNumber = txtTarjeta.Text;
                    client.CreditLimit = double.Parse(txtLimite.Text);

                    dataGridView1.Rows[RowIndex].Cells["NOMBRE"].Value = txtName.Text;
                    dataGridView1.Rows[RowIndex].Cells["CEDULA"].Value = txtCedula.Text;
                       
                    dataGridView1.Rows[RowIndex].Cells["TARJETA"].Value = txtTarjeta.Text;
                    dataGridView1.Rows[RowIndex].Cells["LIMITE"].Value = txtLimite.Text;
                    dataGridView1.Rows[RowIndex].Cells["TIPOPERSONA"].Value =
                        radioButton1.Checked == true ? Data.Enums.PersonType.Physical : Data.Enums.PersonType.Legal;

                    context.SaveChanges();
                    txtName.Clear();
                    txtCedula.Clear();
                    txtTarjeta.Clear();
                    txtLimite.Clear();
                    editando = false;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTarjeta_Leave(object sender, EventArgs e)
        {
            //if(txtTarjeta.TextLength != 16) 
            //    MessageBox.Show()
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dataGridView1.Columns["EDIT"].Index)
            {
                editando = true;
                RowIndex = e.RowIndex;

                txtName.Text = dataGridView1.Rows[RowIndex].Cells["NOMBRE"].Value.ToString();
                txtCedula.Text = dataGridView1.Rows[RowIndex].Cells["CEDULA"].Value.ToString();
                txtTarjeta.Text = dataGridView1.Rows[RowIndex].Cells["TARJETA"].Value.ToString();
                txtLimite.Text = dataGridView1.Rows[RowIndex].Cells["LIMITE"].Value.ToString();

                if (dataGridView1.Rows[RowIndex].Cells["TIPOPERSONA"].Value.ToString() == Data.Enums.PersonType.Physical.ToString())
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando marca", "Desea eliminar la marca?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        Client clientToDelete = context.Clients.Find(id);
                        context.Clients.Remove(clientToDelete);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.editando = false;
            this.txtName.Clear();
            this.txtCedula.Clear();
            this.txtTarjeta.Clear();
            this.txtLimite.Clear();
        }
    }
}
