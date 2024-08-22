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

namespace WolfClient.UserControls
{
    public partial class AddEmployeeFilter : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private List<GetEmployeeDTO> _clientsList;
        private GetEmployeeDTO _defaultClient;

        public AddEmployeeFilter(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetEmployeeDTO> clientsList, Panel Parent)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _clientsList = clientsList;
            EmployeesComboBox.TextChanged += ClientsListComboBox_textChanged;
        }

        public AddEmployeeFilter(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetEmployeeDTO> clientsList, Panel Parent, GetEmployeeDTO defaultClient)
            : this(apiClient, userClient, adminClient, clientsList, Parent)
        {
            _defaultClient = defaultClient;
        }

        private void AddClientFromAvailable_Load(object sender, EventArgs e)
        {
            EmployeesComboBox.Items.AddRange(_clientsList.ToArray());
            EmployeesComboBox.DisplayMember = "FullName";
            if (_defaultClient != null)
            {
                EmployeesComboBox.SelectedItem = _clientsList.FirstOrDefault(c => c.EmployeeId == _defaultClient.EmployeeId);
            }
        }

        public void ClientsListComboBox_textChanged(object sender, EventArgs e)
        {
            string text = EmployeesComboBox.Text;

            // Temporarily remove the event handler to prevent it from firing while updating the items
            EmployeesComboBox.TextChanged -= ClientsListComboBox_textChanged;

            // Filter the list based on the text input or show all items if the text is empty
            if (string.IsNullOrWhiteSpace(text))
            {
                // If the text is empty, display all clients
                EmployeesComboBox.Items.Clear();
                EmployeesComboBox.Items.AddRange(_clientsList.ToArray());
            }
            else
            {
                // Get the list of clients and filter based on the text input
                var filteredClients = _clientsList
                    .Where(client => client.FullName.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(client => client.FullName)
                    .ToList();

                // Clear and repopulate the ComboBox with the filtered and sorted list
                EmployeesComboBox.Items.Clear();
                EmployeesComboBox.Items.AddRange(filteredClients.ToArray());
            }

            EmployeesComboBox.DisplayMember = "FullName";

            // Restore the user's text and keep the ComboBox open
            EmployeesComboBox.Text = text;
            EmployeesComboBox.SelectionStart = text.Length;
            EmployeesComboBox.DroppedDown = true;

            // Reattach the event handler
            EmployeesComboBox.TextChanged += ClientsListComboBox_textChanged;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
        }
    }
}
