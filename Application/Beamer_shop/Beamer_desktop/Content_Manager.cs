using Data;
using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Beamer_desktop
{
    public partial class Content_Manager : Form
    {
        IProductFactory _productFactory;
        public Content_Manager()
        {
            InitializeComponent();
            _productFactory = new ProductFactory(new ProductService(new CarRepository(), new AccessoryRepository()));
            PopulateComboBoxes();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            Product car = new Car(txtChassisNumber.Text.ToString(), txtPlate.Text.ToString(), txtBrand.Text.ToString(), txtModel.Text.ToString(), txtMake.Text.ToString(), nudMilage.Value.ToString(), txtEngine.Text.ToString(), Convert.ToInt32(cbFuel.SelectedValue), Convert.ToInt32(nudHorsePower.Value), Convert.ToInt32(nudTorque.Value), Convert.ToDecimal(nudTime0To60.Value), Convert.ToInt32(nudTopSpeed.Value), -99, txtName.Text.ToString(), Convert.ToDouble(nudPrice.Value), txtDescription.Text.ToString(), txtImageUrl.Text.ToString(), "null", -99, Convert.ToInt32(nudWeight.Value));
            if (_productFactory.CreateProduct(car)) { MessageBox.Show(car.Name + " Added succesfully!"); return; } else { MessageBox.Show("An error has occured, please try again."); }
        }

        private void Cars_Click(object sender, EventArgs e)
        {
        }


        private void btnAddAccessory_Click(object sender, EventArgs e)
        {
            Product accessory = new Accessory(txtAType.Text, -99, txtAName.Text.ToString(), Convert.ToDouble(nudAPrice.Value), txtADescription.Text.ToString(), txtAImageUrl.Text.ToString(), "null", -99, Convert.ToInt32(nudAWeight.Value));
            if (_productFactory.CreateProduct(accessory)) { MessageBox.Show(accessory.Name + " Added succesfully!"); return; } else { MessageBox.Show("An error has occured, please try again."); }

        }

        private void PopulateComboBoxes()
        {
            Dictionary<int, string> fuelTypes = new Dictionary<int, string>
            {
                { 0, "Petrol" },
                { 1, "Diesel" }
            };

            cbFuel.DataSource = new BindingSource(fuelTypes, null);
            cbFuel.DisplayMember = "Value";
            cbFuel.ValueMember = "Key";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void lbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbView.SelectedItem != null)
            {
                Product selectedProduct = (Product)lbView.SelectedItem;
                lblProductInfo.Text = selectedProduct.getDetails();
                btnDelete.Visible = true;
            }
            else
            {
                lblProductInfo.Text = "An error has occured while retrieving information.";
                btnDelete.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbView.SelectedItem != null)
            {
                Product selectedProduct = (Product)lbView.SelectedItem;
                if (_productFactory.ProductService.DeleteProduct(selectedProduct))
                {
                    MessageBox.Show(selectedProduct.Name + " deleted succesfully.");
                }
                else { MessageBox.Show("An error has occured while deleting product."); }
            }
            else { MessageBox.Show("An error has occured while deleting product."); }
            
            RefreshData();
        }

        private void RefreshData()
        {
            lbView.DataSource = null;
            lbView.DataSource = _productFactory.ProductService.GetAllProducts();
            lbView.DisplayMember = "Name";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
