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
                    switch (validEmployee.Role)
                    {
                        case 0:
                            this.Hide();
                            var HR_form = new HR();
                            HR_form.Show();
                            break;
                        case 1:
                            this.Hide();
                            var Content_form = new Content_Manager();
                            Content_form.Show();
                            break;
                        //case 2:
                        default:
                            MessageBox.Show("An error has occured");
                            break;
                    }



                    return;
                }
                else
                {
                    MessageBox.Show("Login not good.");
                    return;
                }
            }

            //Login not good

            MessageBox.Show("Error.");
        }
    }
}