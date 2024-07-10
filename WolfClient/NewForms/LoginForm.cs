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
using WolfClient.Events;
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
        private readonly IFileUploader _fileUploader;
        public LoginForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IFileUploader fileUploader)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _fileUploader = fileUploader;
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
                _userClient.SetToken(tokenResponse.token);
                _fileUploader.SetToken(tokenResponse.token);
                LogInEvent.OnLogIn(username, tokenResponse.role[0]);
                return true;
            }
            return false;
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
