using RentCar.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.UI
{
    public partial class RentCar : Form
    {
        public RentCar()
        {
            InitializeComponent();
        }

        private void RentCar_Load(object sender, EventArgs e)
        {
            using (var context = new MyContext())
            {
                var fuelTypes = context.FuelTypes.ToList();
                comboBox1.Items.Add(fuelTypes);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
