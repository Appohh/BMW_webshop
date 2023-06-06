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

namespace Beamer_desktop
{
    public partial class Content_Manager : Form
    {
        IProductFactory _productFactory;
        public Content_Manager()
        {
            InitializeComponent();
            _productFactory = new ProductFactory(new ProductService(new CarRepository(), new AccessoryRepository()));
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            Product car = new Car(txtChassisNumber.Text.ToString(), txtPlate.Text.ToString(), txtBrand.Text.ToString(), txtModel.Text.ToString(), txtMake.Text.ToString(), nudMilage.Value.ToString(), txtEngine.Text.ToString(), Convert.ToInt32(txtFuel.Text), Convert.ToInt32(nudHorsePower.Value), Convert.ToInt32(nudTorque.Value), Convert.ToDecimal(nudTime0To60.Value), Convert.ToInt32(nudTopSpeed.Value), -99, txtName.Text.ToString(), Convert.ToDouble(nudPrice.Value), txtDescription.Text.ToString(), txtImageUrl.Text.ToString(), "null", -99, Convert.ToInt32(nudWeight.Value));
            _productFactory.CreateProduct(car);
        }
    }
}
