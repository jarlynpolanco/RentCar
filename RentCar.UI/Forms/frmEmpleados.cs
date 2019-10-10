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
    public partial class frmEmpleados : Form
    {
        private bool editando = false;
        private int RowIndex = 0;
        public frmEmpleados()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("NOMBRE", "NOMBRE");
            dataGridView1.Columns.Add("CEDULA", "CEDULA");
            dataGridView1.Columns.Add("TANDALABOR", "TANDA LABOR");
            dataGridView1.Columns.Add("PORCIENTOCOMISION", "PORCIENTO COMISION");
            dataGridView1.Columns.Add("FECHAINGRESO", "FECHA INGRESO");


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

        private void loadEmployee()
        {
            using (var context = new MyContext())
            {
                context.Employees.ToList().ForEach(employee =>
                {
                    dataGridView1.Rows.Add(
                        employee.ID,
                        employee.Name,
                        employee.DocumentNumber,
                        employee.Shift,
                        employee.ComissionPorcent, 
                        employee.Date);
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
               string.IsNullOrEmpty(txtCedula.Text) ||
               string.IsNullOrEmpty(txtComision.Text)
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
                    Employee employee = new Employee
                    {
                        Name = txtName.Text,
                        DocumentNumber = txtCedula.Text,
                        Shift = radioButton1.Checked ? Data.Enums.Shift.Morning : radioButton2.Checked ? Data.Enums.Shift.Afternoon : Data.Enums.Shift.Night,
                        ComissionPorcent = Double.Parse(txtComision.Text),
                        Date = fechaEntrada.Value.Date, 
                    };
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    dataGridView1.Rows.Add
                        (employee.ID, employee.Name, employee.DocumentNumber, employee.Shift, employee.ComissionPorcent, employee.Date);
                    txtName.Clear();
                    txtCedula.Clear();
                    txtComision.Clear();
                }
                else
                {
                    int id = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var employee = context.Employees.Where(x => x.ID == id).FirstOrDefault();
                    employee.Name = txtName.Text;
                    employee.DocumentNumber = txtCedula.Text;
                    employee.Shift = radioButton1.Checked ? Data.Enums.Shift.Morning : radioButton2.Checked ? Data.Enums.Shift.Afternoon : Data.Enums.Shift.Night;
                    employee.ComissionPorcent = double.Parse(txtComision.Text);

                    dataGridView1.Rows[RowIndex].Cells["NOMBRE"].Value = txtName.Text;
                    dataGridView1.Rows[RowIndex].Cells["CEDULA"].Value = txtCedula.Text;
                    dataGridView1.Rows[RowIndex].Cells["PORCIENTOCOMISION"].Value = txtComision.Text;
                    dataGridView1.Rows[RowIndex].Cells["TANDALABOR"].Value =
                        radioButton1.Checked == true ? Data.Enums.Shift.Morning : radioButton2.Checked == true ? 
                        Data.Enums.Shift.Afternoon : Data.Enums.Shift.Night;
                    dataGridView1.Rows[RowIndex].Cells["FECHAINGRESO"].Value = fechaEntrada.Text;
                   
                    context.SaveChanges();
                    txtName.Clear();
                    txtCedula.Clear();
                    txtComision.Clear();
                    editando = false;
                }
            }
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            loadEmployee();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtCedula.Clear();
            txtComision.Clear();
            editando = false;
        }

        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
                txtComision.Text = dataGridView1.Rows[RowIndex].Cells["PORCIENTOCOMISION"].Value.ToString();

                if (dataGridView1.Rows[RowIndex].Cells["TANDALABOR"].Value.ToString() == Data.Enums.Shift.Morning.ToString())
                    radioButton1.Checked = true;
                else if (dataGridView1.Rows[RowIndex].Cells["TANDALABOR"].Value.ToString() == Data.Enums.Shift.Afternoon.ToString())
                    radioButton2.Checked = true;
                else
                    radioButton3.Checked = true;
                fechaEntrada.Value = DateTime.Parse(dataGridView1.Rows[RowIndex].Cells["FECHAINGRESO"].Value.ToString());
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando marca", "Desea eliminar la marca?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        Employee employeeToDetele = context.Employees.Find(id);
                        context.Employees.Remove(employeeToDetele);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
