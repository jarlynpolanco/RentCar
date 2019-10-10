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
    public partial class frmInspeccion : Form
    {
        private bool editando = false;
        private int RowIndex = 0;
        List<Vehicle> vehicles = new List<Vehicle>();
        List<Employee> employee = new List<Employee>();
        List<Client> clients = new List<Client>();
        public frmInspeccion()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("IDVEHICULO", "ID VEHICULO");
            dataGridView1.Columns.Add("IDCLIENTE", "ID CLIENTE");
            dataGridView1.Columns.Add("RALLADURAS", "RALLADURAS");
            dataGridView1.Columns.Add("CANTIDADCOMBUSTIBLE", "CANTIDAD COMBUSTIBLE");
            dataGridView1.Columns.Add("TIENEGOMARESPUESTA", "TIENE GOMA RESPUESTA");
            dataGridView1.Columns.Add("TIENEROTURACRISTAL", "TIENE ROTURA CRISTAL");
            dataGridView1.Columns.Add("ESTADOGOMA", "ESTADO GOMA");
            dataGridView1.Columns.Add("FECHA", "FECHA");
            dataGridView1.Columns.Add("IDEMPLEADO", "ID EMPLEADO");

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
                vehicles = context.Vehicles.ToList();
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

        private void cboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    Inspection inspection = new Inspection
                    {
                        VehicleID = vehicles[cboVehiculo.SelectedIndex].ID,
                        EmployeeID = employee[cboEmpleados.SelectedIndex].ID,
                        ClientID = clients[cboClientes.SelectedIndex].ID,
                        Date = dateTimePicker1.Value,
                        HasScratches = ralladuras.Checked,
                        FuelQuantity = ftQuarter.Checked ? Data.Enums.FuelQuantity.Quarter : ftHalf.Checked ? Data.Enums.FuelQuantity.Half :
                            ftThreeQuarters.Checked ? Data.Enums.FuelQuantity.ThreeQuarters : Data.Enums.FuelQuantity.Full,
                        HasReplacementTire = tieneGoma.Checked,
                        HasBrokenGlasses = tieneRotura.Checked,
                        TiresStatus = "1" + goma1.Checked + "|2" + goma2.Checked + "|3" + goma3.Checked + "|4" + goma4.Checked
                    };

                    context.Inspections.Add(inspection);
                    context.SaveChanges();

                    dataGridView1.Rows.Add(inspection.ID, inspection.VehicleID, inspection.ClientID, inspection.HasScratches, inspection.FuelQuantity,
                        inspection.HasJack, inspection.HasBrokenGlasses, inspection.TiresStatus, inspection.Date, inspection.EmployeeID);
                    clearForm();
                    loadEmployees();
                }
                else
                {
                    int inspectioId = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var model = context.Inspections
                        .Where(x => x.ID == inspectioId).FirstOrDefault();


                    model.VehicleID = vehicles[cboVehiculo.SelectedIndex].ID;
                    model.EmployeeID = employee[cboEmpleados.SelectedIndex].ID;
                    model.ClientID = clients[cboClientes.SelectedIndex].ID;
                    model.Date = dateTimePicker1.Value;
                    model.HasScratches = ralladuras.Checked;
                    model.FuelQuantity = ftQuarter.Checked ? Data.Enums.FuelQuantity.Quarter : ftHalf.Checked ? Data.Enums.FuelQuantity.Half :
                        ftThreeQuarters.Checked ? Data.Enums.FuelQuantity.ThreeQuarters : Data.Enums.FuelQuantity.Full;
                    model.HasReplacementTire = tieneGoma.Checked;
                    model.HasBrokenGlasses = tieneRotura.Checked;
                    model.TiresStatus = "1" + goma1.Checked + "|2" + goma2.Checked + "|3" + goma3.Checked + "|4" + goma4.Checked;


                    dataGridView1.Rows[RowIndex].Cells["ID"].Value = inspectioId;
                    dataGridView1.Rows[RowIndex].Cells["IDVEHICULO"].Value = vehicles[cboVehiculo.SelectedIndex].ID;
                    dataGridView1.Rows[RowIndex].Cells["IDCLIENTE"].Value = clients[cboClientes.SelectedIndex].ID;
                    dataGridView1.Rows[RowIndex].Cells["RALLADURAS"].Value = ralladuras.Checked;
                    dataGridView1.Rows[RowIndex].Cells["CANTIDADCOMBUSTIBLE"].Value = ftQuarter.Checked ? Data.Enums.FuelQuantity.Quarter :
                        ftHalf.Checked ? Data.Enums.FuelQuantity.Half :
                        ftThreeQuarters.Checked ? Data.Enums.FuelQuantity.ThreeQuarters : Data.Enums.FuelQuantity.Full;
                    dataGridView1.Rows[RowIndex].Cells["TIENEGOMARESPUESTA"].Value = tieneGoma.Checked;
                    dataGridView1.Rows[RowIndex].Cells["TIENEROTURACRISTAL"].Value = tieneRotura.Checked;
                    dataGridView1.Rows[RowIndex].Cells["ESTADOGOMA"].Value = "1" + goma1.Checked + "|2" + goma2.Checked + "|3" + goma3.Checked + "|4" + goma4.Checked;
                    dataGridView1.Rows[RowIndex].Cells["FECHA"].Value = dateTimePicker1.Value;
                    dataGridView1.Rows[RowIndex].Cells["IDEMPLEADO"].Value = employee[cboEmpleados.SelectedIndex].ID;

                    context.SaveChanges();
                    clearForm();
                    editando = false;
                }
            }
        }

        private void cboEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void frmInspeccion_Load(object sender, EventArgs e)
        {
            loadVehicles();
            loadEmployees();
            loadClients();
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void clearForm()
        {
            cboClientes.SelectedIndex = 0;
            cboEmpleados.SelectedIndex = 0;
            cboVehiculo.SelectedIndex = 0;
            tieneGoma.Checked = false;
            tieneRotura.Checked = false;
            ralladuras.Checked = false;
            goma1.Checked = false;
            goma2.Checked = false;
            goma3.Checked = false;
            goma4.Checked = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editando = false;
            RowIndex = 0;
            clearForm();
        }
    }
}
