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
    public partial class MenuRequestsUserControl : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private GetRequestDTO _selectedRequest;
        private List<RequestWithClientsDTO> _fetchedLinkedClients;
        private List<GetRequestDTO> _fetchedRequests;
        private bool _isSelectedRequest;
        public MenuRequestsUserControl(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _selectedRequest = null;
            _fetchedLinkedClients = null;
            _fetchedRequests = null;
            _isSelectedRequest = false;
        }
        private void MenuRequestsUserControl_Load(object sender, EventArgs e)
        {
            RequestDataGridView.SelectionChanged += RequestDataGridView_SelectionChanged;
            LogInEvent.logIn += OnUserLoggedIn;
        }
        private async void OnUserLoggedIn(object sender, LogInEventArgs e)
        {
            var response = await _userClient.GetAllRequests();
            
            var employees = response.ResponseObj;
            _fetchedRequests = response.ResponseObj;
            _selectedRequest = _fetchedRequests[0];
            var linkedClientsResponse = await _userClient.GetLinkedClients(_fetchedRequests);
            if (linkedClientsResponse.IsSuccess)
            {
                _fetchedLinkedClients = linkedClientsResponse.ResponseObj;
            }
            RequestDataGridView.AutoGenerateColumns = false;
            RequestDataGridView.DataSource = employees;
            RequestDataGridView.Refresh();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void RequestDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (RequestDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = RequestDataGridView.SelectedRows[0];
                if (selectedRow.DataBoundItem is GetRequestDTO selectedRequest)
                {
                    _selectedRequest = selectedRequest;
                    _isSelectedRequest = true;
                }
            }
            else{
                if (_isSelectedRequest)
                {
                    _isSelectedRequest = false;
                    _selectedRequest = null;
                }
            }

            if (_selectedRequest != null)
            {
                UpdateClientsDataGridView();
            }
        }

        private void UpdateClientsDataGridView()
        {
            var matchingRequestWithClients = _fetchedLinkedClients
            .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _selectedRequest.RequestId);

            if (matchingRequestWithClients != null)
            {
                clientsDataGridView.AutoGenerateColumns = false;
                clientsDataGridView.DataSource = matchingRequestWithClients.clientDTOs;
            }
            else
            {
                clientsDataGridView.DataSource = null;
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRequestForm addRequestForm = new AddRequestForm(_apiClient, _userClient, _adminClient);
            addRequestForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm();
            addActivityTaskForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddInvoiceForm addInvoiceForm = new AddInvoiceForm();
            addInvoiceForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           AddClientToRequest addClientsToRequest = new AddClientToRequest(_apiClient, _userClient, _adminClient,_selectedRequest);
           addClientsToRequest.Show();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var response = await _userClient.GetAllRequests();
            if (response.IsSuccess)
            {
                var employees = response.ResponseObj;
                RequestDataGridView.AutoGenerateColumns = false;
                RequestDataGridView.DataSource = employees;
                RequestDataGridView.Refresh();
                _fetchedRequests = response.ResponseObj;
            }
        }
    }
}
