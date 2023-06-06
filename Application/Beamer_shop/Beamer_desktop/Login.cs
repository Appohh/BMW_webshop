using Data;
using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;

namespace Beamer_desktop
{
    public partial class Login : Form
    {
        private IEmployeeFactory _employeeFactory;
        private IEmployeeService _employeeService;
        public Login()
        {
            InitializeComponent();
            _employeeFactory = new EmployeeFactory(new EmployeeService(new EmployeeRepository()));
            _employeeService = _employeeFactory.EmployeeService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)) { MessageBox.Show("Username empty!"); return; }
            if (string.IsNullOrEmpty(txtPassword.Text)) { MessageBox.Show("Password empty!"); return; }


                    Employee? validEmployee = null;
            (string hash, string salt, int id)? output = _employeeService.GetHashSalt(txtUserName.Text);

            if (output != null)
            {
                //validate input hash
                string inputHash = Security.CreateHash(output.Value.salt, txtPassword.Text);
                if (output.Value.hash == inputHash)
                {
                    //User validated
                    validEmployee = _employeeService.GetEmployeeById(output.Value.id);
                }

                //Login good
                if (validEmployee != null)
                {
                    MessageBox.Show("Login good.");

                    //this.Hide();
                    //var Content_Form = new Care_Taker(loggedInUser);
                    //HR_form.Show();

                    return;
                }
                else
                {
                    MessageBox.Show("Login not good.");
                }
            }

            //Login not good

            MessageBox.Show("Error.");
        }
    }
}