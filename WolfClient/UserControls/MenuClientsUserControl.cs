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
using WolfClient.Events;
using WolfClient.Events.EventArgs;
using WolfClient.NewForms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class MenuClientsUserControl : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        private bool loaded;
        private bool _isRefreshing;

        private List<GetClientDTO> selectedClientsData;
        public MenuClientsUserControl(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            selectedClientsData = new List<GetClientDTO>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AddClientForm form = new AddClientForm(_apiClient, _userClient, _adminClient, true))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GetClientDTO clientDTO = form.returnGetClientResponseObj();
                    _dataService.addClientsToAll(clientDTO);
                }
            }
            UpdateClientDataGridView(_dataService.getAllClients());
        }

        private void MenuClientsUserControl_Load(object sender, EventArgs e)
        {
            if (_apiClient.getLoginStatus())
            {
                loaded = true;
                setClientsDataGridView();
            }
            LogInEvent.logIn += OnUserLoggedIn;
            btnFirstClientsDataGridView.Click += (s, e) => NavigateDataGridView(ClientsDataGridView, "First");
            btnPreviousClientsDataGridView.Click += (s, e) => NavigateDataGridView(ClientsDataGridView, "Previous");
            btnNextClientsDataGridView.Click += (s, e) => NavigateDataGridView(ClientsDataGridView, "Next");
            btnLastClientsDataGridView.Click += (s, e) => NavigateDataGridView(ClientsDataGridView, "Last");
        }
        private async void OnUserLoggedIn(object sender, LogInEventArgs e)
        {
            if (!loaded)
            {
                setClientsDataGridView();
            }
        }
        private void NavigateDataGridView(DataGridView dgv, string direction)
        {
            if (dgv.Rows.Count == 0) return;

            int currentIndex = dgv.CurrentRow != null ? dgv.CurrentRow.Index : -1;

            switch (direction)
            {
                case "First":
                    if (currentIndex != 0) // Only navigate if not already at the first row
                    {
                        dgv.ClearSelection();
                        dgv.Rows[0].Selected = true;
                        dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    }
                    break;
                case "Previous":
                    if (currentIndex > 0)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[currentIndex - 1].Selected = true;
                        dgv.CurrentCell = dgv.Rows[currentIndex - 1].Cells[0];
                    }
                    else if (currentIndex == 0) // Already at the first row, no need to navigate
                    {
                        MessageBox.Show("You are already at the first row.");
                    }
                    break;
                case "Next":
                    if (currentIndex < dgv.Rows.Count - 1)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[currentIndex + 1].Selected = true;
                        dgv.CurrentCell = dgv.Rows[currentIndex + 1].Cells[0];
                    }
                    else if (currentIndex == dgv.Rows.Count - 1) // Already at the last row, no need to navigate
                    {
                        MessageBox.Show("You are already at the last row.");
                    }
                    break;
                case "Last":
                    int lastIndex = dgv.Rows.Count - 1;
                    if (currentIndex != lastIndex) // Only navigate if not already at the last row
                    {
                        dgv.ClearSelection();
                        dgv.Rows[lastIndex].Selected = true;
                        dgv.CurrentCell = dgv.Rows[lastIndex].Cells[0];
                    }
                    break;
            }
        }
        public async void setClientsDataGridView()
        {
            var responseClients = await _userClient.GetAllClients();
            List<GetClientDTO> clientDTOs = responseClients.ResponseObj.ToList();
            _dataService.SetAllClients(clientDTOs);
            UpdateClientDataGridView(_dataService.getAllClients());
        }

        private void UpdateClientDataGridView(List<GetClientDTO> clientDTOs)
        {
            _isRefreshing = true;
            try
            {
                if (clientDTOs == null)
                {
                    throw new ArgumentNullException(nameof(clientDTOs), "clientDTOs is null.");
                }

                // Apply filters to the clientDTOs list
                var filteredList = ApplyClientFilters(clientDTOs);

                if (ClientsDataGridView.InvokeRequired)
                {
                    ClientsDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        UpdateClientGridViewRows(filteredList);
                    }));
                }
                else
                {
                    UpdateClientGridViewRows(filteredList);
                }

                Console.WriteLine("DataSource set successfully with " + filteredList.Count + " items.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateClientDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateClientDataGridView: " + ex.Message);
            }
            finally
            {
                _isRefreshing = false;
            }
        }
        private List<GetClientDTO> ApplyClientFilters(List<GetClientDTO> clientDTOs)
        {
            var filteredList = clientDTOs;

            // Example filter by ClientId (assuming numberTextBox.Text contains a valid integer or is empty)
            if (!string.IsNullOrEmpty(numberTextBox.Text) && int.TryParse(numberTextBox.Text, out int clientId))
            {
                filteredList = filteredList.Where(c => c.ClientId == clientId).ToList();
            }

            // Filter by FullName
            if (!string.IsNullOrEmpty(FullNameTextBox.Text))
            {
                var fullName = FullNameTextBox.Text.ToLower();
                filteredList = filteredList.Where(c => c.FullName.ToLower().Contains(fullName)).ToList();
            }

            // Filter by Email
            if (!string.IsNullOrEmpty(emailTextBox.Text))
            {
                var email = emailTextBox.Text.ToLower();
                filteredList = filteredList.Where(c => c.Email != null && c.Email.ToLower().Contains(email)).ToList();
            }

            // Filter by Phone
            if (!string.IsNullOrEmpty(phoneTextBox.Text))
            {
                var phone = phoneTextBox.Text.ToLower();
                filteredList = filteredList.Where(c => c.Phone != null && c.Phone.ToLower().Contains(phone)).ToList();
            }

            return filteredList;
        }

        private void UpdateClientGridViewRows(List<GetClientDTO> filteredList)
        {
            ClientsDataGridView.AutoGenerateColumns = false;
            ClientsDataGridView.DataSource = null; // Force reset DataSource
            ClientsDataGridView.DataSource = filteredList;
            ClientsDataGridView.Refresh();
        }
        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            setClientsDataGridView();
        }

        private void ClientsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void EditClientButton_Click(object sender, EventArgs e)
        {

            EditCientForm editCientForm = new EditCientForm(_apiClient,_userClient,_adminClient,_dataService);
            editCientForm.Show();
            editCientForm.Disposed += EditClientFormDispose;
        }

        private void EditClientFormDispose(object sender, EventArgs e)
        {
            UpdateClientDataGridView(_dataService.getAllClients());
        }
        private void clientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {

            // Check if any rows are selected
            if (ClientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedClients = new List<GetClientDTO>();

                // Iterate through all selected rows
                foreach (DataGridViewRow selectedRow in ClientsDataGridView.SelectedRows)
                {
                    // Check if the DataBoundItem is of type GetClientDTO
                    if (selectedRow.DataBoundItem is GetClientDTO clientDto)
                    {
                        // Add the client DTO to the list
                        selectedClients.Add(clientDto);
                    }
                }

                // Check if there are any selected clients
                if (selectedClients.Count > 0)
                {
                    _dataService.SetSelectedClients(selectedClients);
                }
            }
        }
    }
}
