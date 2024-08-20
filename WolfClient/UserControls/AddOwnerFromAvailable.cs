using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class AddOwnerFromAvailable : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private List<GetOwnerDTO> _clientsList;
        private GetOwnerDTO _defaultClient;

        public AddOwnerFromAvailable(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetOwnerDTO> clientsList, Panel Parent)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _clientsList = clientsList;
            ClientsListComboBox.TextChanged += ClientsListComboBox_textChanged;
        }

        public AddOwnerFromAvailable(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetOwnerDTO> clientsList, Panel Parent, GetOwnerDTO defaultClient)
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
                ClientsListComboBox.SelectedItem = _clientsList.FirstOrDefault(c => c.OwnerID == _defaultClient.OwnerID);
            }
        }

        public void ClientsListComboBox_textChanged(object sender, EventArgs e)
        {
            string text = ClientsListComboBox.Text;

            // Temporarily remove the event handler to prevent it from firing while updating the items
            ClientsListComboBox.TextChanged -= ClientsListComboBox_textChanged;

            // Filter the list based on the text input or show all items if the text is empty
            if (string.IsNullOrWhiteSpace(text))
            {
                // If the text is empty, display all clients
                ClientsListComboBox.Items.Clear();
                ClientsListComboBox.Items.AddRange(_clientsList.ToArray());
            }
            else
            {
                // Get the list of clients and filter based on the text input
                var filteredClients = _clientsList
                    .Where(client => client.FullName.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(client => client.FullName)
                    .ToList();

                // Clear and repopulate the ComboBox with the filtered and sorted list
                ClientsListComboBox.Items.Clear();
                ClientsListComboBox.Items.AddRange(filteredClients.ToArray());
            }

            ClientsListComboBox.DisplayMember = "FullName";

            // Restore the user's text and keep the ComboBox open
            ClientsListComboBox.Text = text;
            ClientsListComboBox.SelectionStart = text.Length;
            ClientsListComboBox.DroppedDown = true;

            // Reattach the event handler
            ClientsListComboBox.TextChanged += ClientsListComboBox_textChanged;
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
