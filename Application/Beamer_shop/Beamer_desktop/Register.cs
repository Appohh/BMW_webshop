using Data;
using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamer_desktop
{
    public partial class Register : Form
    {
        IEmployeeFactory _employeeFactory;
        public Register()
        {
            InitializeComponent();
            _employeeFactory = new EmployeeFactory(new EmployeeService(new EmployeeRepository()));
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            RegisterEmployee employee = new RegisterEmployee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.BirthDate = txtBirthDate.Text;
            employee.Email = txtEmail.Text;
            employee.Phone = txtPhone.Text;
            employee.BSN = txtBSN.Text;
            employee.Password = txtPassword.Text;



            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(employee);
            Validator.TryValidateObject(employee, validationContext, validationResults);

            if (validationResults.Any()) { MessageBox.Show("Fill in everything correctly."); return; }

                //Hash
                (string Salt, string HashedPassword) output = Security.CreateSaltAndHash(employee.Password);
                employee.Salt = output.Salt;
                employee.Hash = output.HashedPassword;
            //Send
            if (_employeeFactory.EmployeeService.RegisterEmployee(employee))
            {
                MessageBox.Show("Succes");
            }
            else MessageBox.Show("Error");


        }
    }
}
