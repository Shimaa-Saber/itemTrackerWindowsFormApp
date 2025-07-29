using itemTracker.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itemTracker.UI
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }

            var user = _authService.Login(username, password);
            if (user != null)
            {
                lblError.Text = "";

                if (user.Role == "Admin")
                {
                    MessageBox.Show("Welcome Admin!");
                     var reportForm = new AdminLogsForm(user);
                     reportForm.Show();
                }
                else
                {
                    MessageBox.Show("Welcome " + user.Username);
                     var itemForm = new ItemManagementForm(user);
                     itemForm.Show();
                }

                this.Hide();
            }
            else
            {
                lblError.Text = "Invalid username or password.";
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regForm = new RegisterForm();
            regForm.Show();

        }
    }
}
