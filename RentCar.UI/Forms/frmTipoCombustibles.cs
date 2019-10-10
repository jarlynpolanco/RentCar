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
    public partial class frmTipoCombustibles : Form
    {
        private bool editando = false;
        private int RowIndex = 0;
        public frmTipoCombustibles()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("TIPOCOMBUSTIBLE", "TIPO COMBUSTIBLE");



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
        private void loadBrands()
        {
            using (var context = new MyContext())
            {
                context.FuelTypes.ToList().ForEach(brand =>
                {
                    dataGridView1.Rows.Add(brand.ID, brand.Name);
                });
            }
        }
        private void frmTipoCombustibles_Load(object sender, EventArgs e)
        {
            loadBrands();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.editando = false;
            this.textBoxBrand.Clear();
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
                textBoxBrand.Text = dataGridView1.Rows[e.RowIndex].Cells["TIPOCOMBUSTIBLE"].Value.ToString();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando tipo combustible", "Desea eliminar el tipo combustible?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        FuelType brandToDelete = context.FuelTypes.Find(id);
                        context.FuelTypes.Remove(brandToDelete);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxBrand.Text))
            {
                MessageBox.Show("El campo debe contener datos para guardar!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            using (var context = new MyContext())
            {
                if (!editando)
                {
                    FuelType fuelType = new FuelType { Name = textBoxBrand.Text };
                    context.FuelTypes.Add(fuelType);
                    context.SaveChanges();
                    dataGridView1.Rows.Add(fuelType.ID, fuelType.Name);
                    textBoxBrand.Clear();
                }
                else
                {
                    int id = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var fuelType = context.FuelTypes.Where(x => x.ID == id).FirstOrDefault();
                    fuelType.Name = textBoxBrand.Text;

                    dataGridView1.Rows[RowIndex].Cells["TIPOCOMBUSTIBLE"].Value = textBoxBrand.Text;

                    context.SaveChanges();
                    textBoxBrand.Clear();
                    editando = false;
                }
            }
        }
    }
}
