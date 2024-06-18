using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolf.DTO;
using WolfClient.Models;
using WolfClient.Services;
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
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


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }


        private async void LogInButton_Click(object sender, EventArgs e)
        {
            var username = userNameTextBox.Text;
            var password = PasswordTextBox.Text;

            if (await ValidateCredentials(username, password))
            {
                MessageBox.Show("LoggedIn");
                
            }
            else
            {
                MessageBox.Show("Not logged In");
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
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(response.ResponseObj);
                _adminClient.SetToken(tokenResponse.token);
                _apiClient.SetToken(tokenResponse.token);
                return true;
            }
            return false;
        }

       
    }
}
