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
    public partial class frmRent : Form
    {

        private bool editando = false;
        private int RowIndex = 0;
        List<Vehicle> vehicles = new List<Vehicle>();
        List<Employee> employee = new List<Employee>();
        List<Client> clients = new List<Client>();
        public frmRent()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("EMPLEADO", "EMPLEADO");
            dataGridView1.Columns.Add("VEHICULO", "VEHICULO");
            dataGridView1.Columns.Add("CLIENTE", "CLIENTE");
            dataGridView1.Columns.Add("FECHARENTA", "FECHA RENTA");
            dataGridView1.Columns.Add("FECHADEVOLUCION", "FECHA DEVOLUCION");
            dataGridView1.Columns.Add("MONTOPORDIA", "MONTO POR DIA");
            dataGridView1.Columns.Add("CANTIDADDIAS", "CANTIDAD DE DIAS");
            dataGridView1.Columns.Add("COMENTARIO", "COMENTARIO");
            dataGridView1.Columns.Add("ESTADO", "ESTADO");

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

        private void loadVehicles()
        {
            cboVehiculo.Items.Clear();
            using (var context = new MyContext())
            {
                vehicles = context.Vehicles.Where(x => x.StateRent == false).ToList();
                vehicles.ForEach((b) =>
                {
                    cboVehiculo.Items.Add(b.Chasis);
                });
            }
        }
        private void loadEmployees()
        {
            cboEmpleados.Items.Clear();
            using (var context = new MyContext())
            {
                employee = context.Employees.ToList();
                employee.ForEach((b) =>
                {
                    cboEmpleados.Items.Add(b.Name);
                });
            }
        }
        private void loadClients()
        {
            cboClientes.Items.Clear();
            using (var context = new MyContext())
            {
                clients = context.Clients.ToList();
                clients.ForEach((b) =>
                {
                    cboClientes.Items.Add(b.Name);
                });
            }
        }

        private void clearForm() 
        {
            cboClientes.SelectedIndex = 0;
            cboEmpleados.SelectedIndex = 0;
            cboVehiculo.SelectedIndex = 0;
            txtMontoPorDia.Text = string.Empty;
            txtComentario.Text = string.Empty;
            txtCantDias.Text = string.Empty;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (
              cboVehiculo.SelectedItem == null ||
              cboClientes.SelectedItem == null ||
              cboEmpleados.SelectedItem == null
              )
            {
                MessageBox.Show("El campo debe contener datos para guardar!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var context = new MyContext())
            {
                if (!editando)
                {
                    Rent rent = new Rent
                    {
                        VehicleID = vehicles[cboVehiculo.SelectedIndex].ID,
                        EmployeeID = employee[cboEmpleados.SelectedIndex].ID,
                        ClientID = clients[cboClientes.SelectedIndex].ID,
                        Date = dateTimePickerRent.Value,
                        AmountPerDay = double.Parse(txtMontoPorDia.Text),
                        Comment = txtComentario.Text,
                        Days = int.Parse(txtCantDias.Text),
                        ReturnDate = DateTime.Now
                    };
                    Vehicle vehicle = context.Vehicles.Find(rent.VehicleID);
                    vehicle.StateRent = true;
                    context.Rents.Add(rent);
                    context.SaveChanges();

                    dataGridView1.Rows.Add(rent.ID, rent.EmployeeID, rent.VehicleID, rent.ClientID, rent.Date, string.Empty, rent.AmountPerDay,
                        rent.Days, rent.Comment, vehicle.StateRent);
                    clearForm();
                }
                else
                {
                    dateTimePickerDev.Enabled = true;
                    int rentId = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var model = context.Rents
                        .Where(x => x.ID == rentId).FirstOrDefault();

                    model.VehicleID = vehicles[cboVehiculo.SelectedIndex].ID;
                    model.EmployeeID = employee[cboEmpleados.SelectedIndex].ID;
                    model.ClientID = clients[cboClientes.SelectedIndex].ID;
                    model.Date = dateTimePickerRent.Value;
                    model.AmountPerDay = int.Parse(txtCantDias.Text);
                    model.Comment = txtComentario.Text;
                    model.Days = int.Parse(txtCantDias.Text);
                    model.ReturnDate = dateTimePickerDev.Value;
                    Vehicle vehicle = context.Vehicles.Find(model.VehicleID);
                    vehicle.StateRent = false;

                    dataGridView1.Rows[RowIndex].Cells["ID"].Value = rentId;
                    dataGridView1.Rows[RowIndex].Cells["EMPLEADO"].Value = employee[cboClientes.SelectedIndex].ID;
                    dataGridView1.Rows[RowIndex].Cells["VEHICULO"].Value = vehicles[cboVehiculo.SelectedIndex].ID;
                    dataGridView1.Rows[RowIndex].Cells["CLIENTE"].Value = clients[cboClientes.SelectedIndex].ID;
                    dataGridView1.Rows[RowIndex].Cells["FECHARENTA"].Value = dateTimePickerRent.Value;
                    dataGridView1.Rows[RowIndex].Cells["FECHADEVOLUCION"].Value = dateTimePickerDev.Value;
                    dataGridView1.Rows[RowIndex].Cells["MONTOPORDIA"].Value = int.Parse(txtCantDias.Text);
                    dataGridView1.Rows[RowIndex].Cells["CANTIDADDIAS"].Value = int.Parse(txtCantDias.Text);
                    dataGridView1.Rows[RowIndex].Cells["COMENTARIO"].Value = txtComentario.Text;
                    dataGridView1.Rows[RowIndex].Cells["ESTADO"].Value = vehicle.StateRent;

                    context.SaveChanges();
                    clearForm();
                    editando = false;
                }
            }
        }

        private void frmRent_Load(object sender, EventArgs e)
        {
            dateTimePickerDev.Enabled = false;
            loadVehicles();
            loadEmployees();
            loadClients();
            using (var context = new MyContext())
            {
                context.Rents.Include("Vehicle")
                    .ToList().ForEach(rent =>
                    {
                        dataGridView1.Rows.Add(rent.ID,
                            rent.EmployeeID,
                            rent.VehicleID,
                            rent.ClientID,
                            rent.Date,
                            string.Empty,
                            rent.AmountPerDay,
                            rent.Days,
                            rent.Comment,
                            rent.Vehicle.StateRent);
                    });
            }

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
                dateTimePickerDev.Enabled = true;

                cboEmpleados.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["EMPLEADO"].Value.ToString();
                cboVehiculo.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["VEHICULO"].Value.ToString();
                cboClientes.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["CLIENTE"].Value.ToString();
                dateTimePickerRent.Value = DateTime.Parse(dataGridView1.Rows[RowIndex].Cells["FECHARENTA"].Value.ToString());
                txtMontoPorDia.Text = dataGridView1.Rows[RowIndex].Cells["MONTOPORDIA"].Value.ToString();
                txtCantDias.Text = dataGridView1.Rows[RowIndex].Cells["CANTIDADDIAS"].Value.ToString();
                txtComentario.Text = dataGridView1.Rows[RowIndex].Cells["COMENTARIO"].Value.ToString();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando marca", "Desea eliminar la marca?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        Rent rentToDelete = context.Rents.Find(id);
                        context.Rents.Remove(rentToDelete);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
