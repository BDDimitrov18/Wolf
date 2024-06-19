using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class AddClientForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public AddClientForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {

        }

        private async void AddClientButton_Click(object sender, EventArgs e)
        {
            

            var client = new CreateClientDTO
            {
                FirstName = NameTextBox.Text,
                MiddleName = SecondNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text,
                Address = AddressTextBox.Text,
                ClientLegalType = LegalTypeTextBox.Text
            };

            await _userClient.AddClient(client);
        }
    }
}
