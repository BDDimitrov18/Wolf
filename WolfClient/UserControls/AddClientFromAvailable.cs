using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class AddClientFromAvailable : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private List<GetClientDTO> _clientsList;
        private GetClientDTO _defaultClient;

        public AddClientFromAvailable(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetClientDTO> clientsList, Panel Parent)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _clientsList = clientsList;
        }

        public AddClientFromAvailable(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetClientDTO> clientsList, Panel Parent, GetClientDTO defaultClient)
            : this(apiClient, userClient, adminClient, clientsList, Parent)
        {
            _defaultClient = defaultClient;
        }

        private void AddClientFromAvailable_Load(object sender, EventArgs e)
        {
            ClientsListComboBox.Items.AddRange(_clientsList.ToArray());
            ClientsListComboBox.DisplayMember = "FullName";
            if (_defaultClient != null)
            {
                ClientsListComboBox.SelectedItem = _clientsList.FirstOrDefault(c => c.ClientId == _defaultClient.ClientId);
            }
        }

        private void DeleteUserControlButton_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
        }

        private void ClientsListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the selection change if necessary
        }
    }
}
