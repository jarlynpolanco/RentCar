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
    public partial class frmModelos : Form
    {
        private bool editando = false;
        private int RowIndex = 0;

        public List<Brand> Brands = new List<Brand>();
        public frmModelos()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("MARCA", "MARCA");
            dataGridView1.Columns.Add("MODELO", "MODELO");



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
        private void loadModelos()
        {
            using (var context = new MyContext())
            {
                context.Models.Include("Brand").ToList().ForEach(model =>
                {
                    dataGridView1.Rows.Add(model.ID, model.Brand.Name, model.Name);
                });
            }
        }
        private void loadBrands()
        {
            using (var context = new MyContext())
            {
                Brands = context.Brands.ToList();
                Brands.ForEach((b) =>
                {
                    comboBox1.Items.Add(b.Name);
                });
            }
        }
        private void frmModelos_Load(object sender, EventArgs e)
        {
            loadModelos();
            loadBrands();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.editando = false;
            this.txtModelo.Clear();
            comboBox1.SelectedIndex = 0;
            txtModelo.Clear();
            RowIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("El campo debe contener datos para guardar!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var context = new MyContext())
            {
                if (!editando)
                {
                    Model model = new Model { Name = txtModelo.Text,BrandID=Brands[comboBox1.SelectedIndex].ID };
                    context.Models.Add(model);
                    context.SaveChanges();

                    Brand nBrand = context.Brands.First(x => x.ID == model.BrandID);

                    dataGridView1.Rows.Add(model.ID, nBrand.Name, model.Name);
                    txtModelo.Clear();
                }
                else
                {
                    int id = int.Parse(dataGridView1.Rows[RowIndex].Cells["ID"].Value.ToString());
                    var model = context.Models.Where(x => x.ID == id).FirstOrDefault();
                    model.Name = txtModelo.Text;
                    model.BrandID = Brands[comboBox1.SelectedIndex].ID;

                    dataGridView1.Rows[RowIndex].Cells["MODELO"].Value = txtModelo.Text;

                    dataGridView1.Rows[RowIndex].Cells["MARCA"].Value = Brands[comboBox1.SelectedIndex].Name;


                    context.SaveChanges();
                    txtModelo.Clear();
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
                txtModelo.Text = dataGridView1.Rows[e.RowIndex].Cells["MODELO"].Value.ToString();

                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();

            }
            else if (e.ColumnIndex == dataGridView1.Columns["DELETE"].Index)
            {
                DialogResult dialogResult = MessageBox.Show("Eliminando modelo", "Desea eliminar el modelo?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    using (var context = new MyContext())
                    {
                        Model brandToDelete = context.Models.Find(id);
                        context.Models.Remove(brandToDelete);
                        context.SaveChanges();
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
    }
}
