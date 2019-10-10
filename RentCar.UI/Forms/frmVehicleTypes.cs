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
    public partial class frmVehicleTypes : Form
    {
        public frmVehicleTypes()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("TIPOVEHICULO", "TIPO VEHICULO");



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
        private bool editando = false;
        private int RowIndex = 0;

        private void frmVehicleTypes_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            loadBrands();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBrand.Text))
            {
                MessageBox.Show("El campo debe contener datos para guardar!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var context = new MyContext())
            {
                if (!editando)
                {
                    VehicleType vtype = new VehicleType { Name = textBoxBrand.Text };
                    context.VehicleTypes.Add(vtype);
                    context.SaveChanges();
                    dataGridView1.Rows.Add(vtype.ID, vtype.Name);
                    textBoxBrand.Clear();
                }
                else
                {
                    int id = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var brand = context.VehicleTypes.Where(x => x.ID == id).FirstOrDefault();
                    brand.Name = textBoxBrand.Text;

                    dataGridView1.Rows[RowIndex].Cells["TIPOVEHICULO"].Value = textBoxBrand.Text;

                    context.SaveChanges();
                    textBoxBrand.Clear();
                    editando = false;
                }
            }

        }
        private void loadBrands()
        {
            using (var context = new MyContext())
            {
                context.VehicleTypes.ToList().ForEach(vtype =>
                {
                    dataGridView1.Rows.Add(vtype.ID, vtype.Name);
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
                textBoxBrand.Text = dataGridView1.Rows[e.RowIndex].Cells["TIPOVEHICULO"].Value.ToString();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando tipo de vehiculo", "Desea eliminar el tipo de vehiculo?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        VehicleType brandToDelete = context.VehicleTypes.Find(id);
                        context.VehicleTypes.Remove(brandToDelete);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
