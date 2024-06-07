using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolf.DTO;
using Wolf.Services.Interfaces;

namespace Wolf
{
    public partial class LoginForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public LoginForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void LogInButton_Click(object sender, EventArgs e)
        {
            var username = userNameTextBox.Text;
            var password = PasswordTextBox.Text;

            if (await ValidateCredentials(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private async Task<bool> ValidateCredentials(string username, string password)
        {
            LoginUserDto loginUser = new LoginUserDto()
            {
                Username = username,
                Password = password
            };
            var response = await _apiClient.GetJwtToken(loginUser);
            if (response.IsSuccess)
            {
                //do sth with token
                _apiClient.SetToken(response.ResponseObj);
                return true;
            }
            return false;
        }
    }
}
