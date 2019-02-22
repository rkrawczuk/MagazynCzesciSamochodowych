using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazynCzesciSamochodowych
{
    public partial class showForm : Form
    {
        private Part selectedPart;
        public showForm(Part part)
        {
            selectedPart = part;
            InitializeComponent();
        }

        private void showForm_Load(object sender, EventArgs e)
        { 
            partNameLabel.Text = selectedPart.Name;
            partNumberLabel.Text = selectedPart.PartNumber.ToString();
            carBrandLabel.Text = selectedPart.CarBrand;
            carModelLabel.Text = selectedPart.CarModel;
            priceLabel.Text = selectedPart.Price;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
