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

        private readonly bool _canCreate;

        private CreateClientDTO _clientDTO;
        public AddClientForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, bool canCreate)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _canCreate = canCreate;
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
            if (!_canCreate)
            {
                _clientDTO = client;
                DialogResult = DialogResult.OK;
            }
            else {
                List<CreateClientDTO> clientsList = new List<CreateClientDTO>();
                clientsList.Add(client);
                await _userClient.AddClients(clientsList);
            }
            Close();
        }

        public CreateClientDTO getClientResponseObj() {
            return _clientDTO;
        }

    }
}
