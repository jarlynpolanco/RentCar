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
    public partial class frmVehiculos : Form
    {
        private bool editando = false;
        private int RowIndex = 0;
        
        List<VehicleType> vehicleTypes = new List<VehicleType>();
        List<Brand> brands = new List<Brand>();
        List<Model> models = new List<Model>();
        List<FuelType> fuels = new List<FuelType>();
        List<Vehicle> vehicles = new List<Vehicle>();
        public frmVehiculos()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("MARCA", "MARCA");
            dataGridView1.Columns.Add("MODELO", "MODELO");
            dataGridView1.Columns.Add("TIPOVEHICULO", "TIPOVEHICULO");
            dataGridView1.Columns.Add("TIPOCOMBUSTIBLE", "TIPOCOMBUSTIBLE");
            dataGridView1.Columns.Add("CHASIS", "NO.CHASIS");
            dataGridView1.Columns.Add("NOMOTOR", "NO. MOTOR");
            dataGridView1.Columns.Add("PLACA", "PLACA");

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

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            loadTipoVehiculos();
            loadMarcas();
            loadFuelTypes();
            loadVehiculos();

        }
        private void loadVehiculos()
        {
            using (var context = new MyContext())
            {
                context.Vehicles
                    .Include("Model")
                    .Include("Model.Brand")
                    .Include("FuelType")
                    .Include("VehicleType")
                    .ToList().ForEach(vehicle =>
                {
                    dataGridView1.Rows.Add(vehicle.ID, vehicle.Model.Brand.Name, vehicle.Model.Name, vehicle.VehicleType.Name, vehicle.FuelType.Name, vehicle.Chasis, vehicle.MotorNumber, vehicle.Plate);
                });
            }
        }
        private void loadTipoVehiculos()
        {
            using (var context = new MyContext())
            {
                vehicleTypes = context.VehicleTypes.ToList();
                vehicleTypes.ForEach((b) =>
                {
                    cboTipoVehiculo.Items.Add(b.Name);
                });
            }
        }
        private void loadMarcas()
        {
            using (var context = new MyContext())
            {
                brands = context.Brands.ToList();
                brands.ForEach((b) =>
                {
                    cboMarca.Items.Add(b.Name);
                });
            }
        }
        private void loadFuelTypes()
        {
            using (var context = new MyContext())
            {
                fuels = context.FuelTypes.ToList();
                fuels.ForEach((b) =>
                {
                    cboFuelTypes.Items.Add(b.Name);
                });
            }
        }
        private void loadModelos(int brandId)
        {
            cboModelo.Items.Clear();
            using (var context = new MyContext())
            {
                models = context.Models.Where(x=>x.BrandID==brandId).ToList();
                models.ForEach((b) =>
                {
                    cboModelo.Items.Add(b.Name);
                });
            }
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadModelos(brands[cboMarca.SelectedIndex].ID);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            editando = false;
            RowIndex = 0;
            clearForm();
        }
        private void clearForm()
        {
            cboMarca.SelectedIndex = 0;
            cboTipoVehiculo.SelectedIndex = 0;
            cboFuelTypes.SelectedIndex = 0;
            txtPlaca.Clear();
            txtMotor.Clear();
            txtChasis.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(txtChasis.Text) ||
                string.IsNullOrEmpty(txtMotor.Text) ||
                string.IsNullOrEmpty(txtPlaca.Text) ||
                cboMarca.SelectedItem == null ||
                cboModelo.SelectedItem == null ||
                cboTipoVehiculo.SelectedItem == null ||
                cboFuelTypes.SelectedItem == null
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
                    Vehicle vehicle = new Vehicle
                    {
                        Chasis=txtChasis.Text,
                        MotorNumber=txtMotor.Text,
                        Plate=txtPlaca.Text,
                        FuelTypeID= fuels[cboFuelTypes.SelectedIndex].ID,
                        ModelID=models[cboModelo.SelectedIndex].ID,
                        VehicleTypeID=vehicleTypes[cboTipoVehiculo.SelectedIndex].ID
                    };

                    context.Vehicles.Add(vehicle);
                    context.SaveChanges();

                    int brandId = brands[cboMarca.SelectedIndex].ID;
                    int modelId = models[cboModelo.SelectedIndex].ID;
                    int vehicleTypeId = vehicleTypes[cboTipoVehiculo.SelectedIndex].ID;
                    int fuelId = fuels[cboFuelTypes.SelectedIndex].ID;

                    Brand brand = context.Brands.First(x => x.ID == brandId);
                    Model model = context.Models.First(x => x.ID == modelId);
                    VehicleType vt = context.VehicleTypes.First(x => x.ID == vehicleTypeId);
                    FuelType tc = context.FuelTypes.First(x => x.ID == fuelId);
                    dataGridView1.Rows.Add(vehicle.ID, brand.Name, model.Name, vt.Name,tc.Name, vehicle.Chasis, vehicle.MotorNumber,vehicle.Plate);
                    clearForm();
                }
                else
                {
                    int vehicleId = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var model = context.Vehicles
                        .Where(x => x.ID == vehicleId).FirstOrDefault();


                    model.Chasis = txtChasis.Text;
                    model.MotorNumber = txtMotor.Text;
                    model.Plate = txtPlaca.Text;
                    model.ModelID = models[cboModelo.SelectedIndex].ID;
                    model.FuelTypeID = fuels[cboFuelTypes.SelectedIndex].ID;
                    model.VehicleTypeID = vehicleTypes[cboTipoVehiculo.SelectedIndex].ID;

                    dataGridView1.Rows[RowIndex].Cells["CHASIS"].Value = txtChasis.Text;
                    dataGridView1.Rows[RowIndex].Cells["NOMOTOR"].Value =txtMotor.Text;
                    dataGridView1.Rows[RowIndex].Cells["PLACA"].Value = txtPlaca.Text;

                    dataGridView1.Rows[RowIndex].Cells["MARCA"].Value = brands[cboMarca.SelectedIndex].Name;
                    dataGridView1.Rows[RowIndex].Cells["MODELO"].Value = models[cboModelo.SelectedIndex].Name;
                    dataGridView1.Rows[RowIndex].Cells["TIPOVEHICULO"].Value = vehicleTypes[cboTipoVehiculo.SelectedIndex].Name;
                    dataGridView1.Rows[RowIndex].Cells["TIPOCOMBUSTIBLE"].Value = fuels[cboFuelTypes.SelectedIndex].Name;




                    context.SaveChanges();
                    clearForm();
                    editando = false;
                }
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

                txtChasis.Text = dataGridView1.Rows[RowIndex].Cells["CHASIS"].Value.ToString();
                txtMotor.Text=dataGridView1.Rows[RowIndex].Cells["NOMOTOR"].Value.ToString();
                txtPlaca.Text=dataGridView1.Rows[RowIndex].Cells["PLACA"].Value.ToString();

                cboMarca.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();
                cboModelo.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["MODELO"].Value.ToString();
                cboFuelTypes.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["TIPOCOMBUSTIBLE"].Value.ToString();
                cboTipoVehiculo.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["TIPOVEHICULO"].Value.ToString();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando vehiculo", "Desea eliminar el vehiculo?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        Vehicle vehicle = context.Vehicles.Find(id);
                        context.Vehicles.Remove(vehicle);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBusqueda_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {       }

        private void cboFuelTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
