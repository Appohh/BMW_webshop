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
    public partial class HR : Form
    {
        IEmployeeFactory _employeeFactory;
        public HR()
        {
            InitializeComponent();
            _employeeFactory = new EmployeeFactory(new EmployeeService(new EmployeeRepository()));
        } 

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!validateRegisterFields()) { return; }
            RegisterEmployee employee = new RegisterEmployee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.BirthDate = dtpBirthdate.Value.Date.ToString("yyyy-MM-dd");
            employee.Email = txtEmail.Text;
            employee.Phone = txtPhone.Text;
            employee.BSN = txtBSN.Text;
            employee.Password = txtPassword.Text;
            employee.Role = Convert.ToInt32(nudRole.Value);



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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void RefreshData()
        {
            lbView.DataSource = null;
            lbView.DataSource = _employeeFactory.EmployeeService.GetAllEmployees();
            lbView.DisplayMember = "LastName";
        }

        private void lbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbView.SelectedItem != null)
            {
                Employee em = (Employee)lbView.SelectedItem;
                lblProductInfo.Text = em.FirstName + " " + em.LastName + "\n" + em.BirthDate + "\n" + em.Email + "\n" + em.Phone + "\n" + em.BSN;
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
                Employee selectedEmployee = (Employee)lbView.SelectedItem;
                if (_employeeFactory.EmployeeService.DeleteEmployee(selectedEmployee))
                {
                    MessageBox.Show(selectedEmployee.FirstName + " " + selectedEmployee.LastName + " deleted succesfully.");
                }
                else { MessageBox.Show("An error has occured while deleting employee."); }
            }
            else { MessageBox.Show("An error has occured while deleting employee."); }

            RefreshData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private bool validateRegisterFields()
        {
            if (txtFirstName.Text.Length < 1)
            {
                MessageBox.Show("Fill firstname.");
                return false;
            }

            if (txtLastName.Text.Length < 1)
            {
                MessageBox.Show("Fill lastname.");
                return false;
            }

            if (txtEmail.Text.Length < 1)
            {
                MessageBox.Show("Fill email.");
                return false;
            }

            if (txtBSN.Text.Length < 1)
            {
                MessageBox.Show("Fill BSN.");
                return false;
            }

            if (txtPassword.Text.Length < 1)
            {
                MessageBox.Show("Fill password.");
                return false;
            }

            if (txtPhone.Text.Length < 1)
            {
                MessageBox.Show("Fill phone.");
                return false;
            }

            return true;
        }

    }
}
