using DTOS.DTO;
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
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class AddEmployeeForm : Form
    {

        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public AddEmployeeForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }
       
        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        

        private async void AddEmployeeSubmitButton_Click(object sender, EventArgs e)
        {
            var employee = new CreateEmployeeDTO
            {
                FirstName = NameTextBox.Text,
                SecondName = SecondNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text
            };

            await _adminClient.AddEmployee(employee);
        }

    }
}
