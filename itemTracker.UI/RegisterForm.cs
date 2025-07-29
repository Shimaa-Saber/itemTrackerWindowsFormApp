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
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService = new AuthService();
        public RegisterForm()
        {
            InitializeComponent();
            cmbRole.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;
            string role = cmbRole.SelectedItem?.ToString();

            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "All fields are required.";
                return;
            }

            if (password != confirm)
            {
                lblError.Text = "Passwords do not match.";
                return;
            }

            bool success = _authService.Register(username, password, role);

            if (success)
            {
                MessageBox.Show("Registration successful. You can now login.");
                this.Close();
            }
            else
            {
                lblError.Text = "Username already exists.";
            }
        }
    }
    }

