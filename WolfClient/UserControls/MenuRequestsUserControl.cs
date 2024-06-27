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
        private readonly IDataService _dataService;
        private GetRequestDTO _selectedRequest;
        private List<GetRequestDTO> _fetchedRequests;
        private bool _isSelectedRequest;

        private bool loaded;
        public MenuRequestsUserControl(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _selectedRequest = null;
            _fetchedRequests = null;
            _isSelectedRequest = false;
            _dataService = dataService;
        }
        private void MenuRequestsUserControl_Load(object sender, EventArgs e)
        {
            RequestDataGridView.SelectionChanged += RequestDataGridView_SelectionChanged;
            if (_apiClient.getLoginStatus())
            {
                setRequestsDataGridView();
                loaded = true;
            }
            LogInEvent.logIn += OnUserLoggedIn;
        }

        private async void setRequestsDataGridView() {
            var response = await _userClient.GetAllRequests();

            var employees = response.ResponseObj;
            if (response.ResponseObj.Count() > 0)
            {
                _fetchedRequests = response.ResponseObj;
                _selectedRequest = _fetchedRequests[0];
                var linkedClientsResponse = await _userClient.GetLinked(_fetchedRequests);
                if (linkedClientsResponse.IsSuccess)
                {
                    _dataService.SetFetchedLinkedRequests(linkedClientsResponse.ResponseObj);
                }
                RequestDataGridView.AutoGenerateColumns = false;
                RequestDataGridView.DataSource = employees;
                RequestDataGridView.Refresh();
            }
        }
        private async void OnUserLoggedIn(object sender, LogInEventArgs e)
        {
            if (!loaded) {
                setRequestsDataGridView();
            }
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
                    _dataService.SetSelectedRequest(_selectedRequest);
                }
            }
            else
            {
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
            try
            {
                if (_selectedRequest == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    clientsDataGridView.DataSource = null;
                    clientsDataGridView.Refresh();
                    return;
                }

                var matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _selectedRequest.RequestId);

                if (clientsDataGridView.InvokeRequired)
                {
                    clientsDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        BindClientsDataGridView(matchingRequestWithClients);
                    }));
                }
                else
                {
                    BindClientsDataGridView(matchingRequestWithClients);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateClientsDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateClientsDataGridView: " + ex.Message);
            }
        }

        private void BindClientsDataGridView(RequestWithClientsDTO matchingRequestWithClients)
        {
            clientsDataGridView.AutoGenerateColumns = false;
            clientsDataGridView.DataSource = null; // Force reset DataSource

            if (matchingRequestWithClients != null)
            {
                clientsDataGridView.DataSource = matchingRequestWithClients.clientDTOs;
            }
            else
            {
                clientsDataGridView.DataSource = null;
            }

            clientsDataGridView.Refresh();
        }




        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AddRequestForm form = new AddRequestForm(_apiClient, _userClient, _adminClient))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GetRequestDTO requestDTO = form.returnRequest();
                    List<GetClientDTO> getClientDTOs = form.returnClients();


                    RequestWithClientsDTO requestWithClients = new RequestWithClientsDTO()
                    {
                        requestDTO = requestDTO,
                        clientDTOs = getClientDTOs,
                    };

                    _dataService.AddSingleRequest(requestWithClients);
                    _fetchedRequests.Add(requestDTO);
                }
            }
            UpdateRequestDataGridView(_fetchedRequests);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient,_userClient,_adminClient,_dataService);
            addActivityTaskForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddInvoiceForm addInvoiceForm = new AddInvoiceForm();
            addInvoiceForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (AddClientToRequest form = new AddClientToRequest(_apiClient, _userClient, _adminClient, _selectedRequest))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    List<GetClientDTO> getClientDTOs = form.returnClientsList();

                    foreach (RequestWithClientsDTO requestWithClientsDTO in _dataService.GetFetchedLinkedRequests())
                    {
                        if (requestWithClientsDTO.requestDTO.RequestId == _selectedRequest.RequestId)
                        {
                            requestWithClientsDTO.clientDTOs.AddRange(getClientDTOs);
                        }
                    }
                }
            }
            UpdateClientsDataGridView();

        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var response = await _userClient.GetAllRequests();
            var linkedResponse = await _userClient.GetLinked(response.ResponseObj);
            _dataService.SetFetchedLinkedRequests(linkedResponse.ResponseObj);
            if (response.IsSuccess)
            {
                var requestDTOs = response.ResponseObj;
                UpdateRequestDataGridView(requestDTOs);
                _fetchedRequests = response.ResponseObj;
            }
        }


        private void UpdateRequestDataGridView(List<GetRequestDTO> requestDTOs)
        {
            try
            {
                if (requestDTOs == null)
                {
                    throw new ArgumentNullException(nameof(requestDTOs), "requestDTOs is null.");
                }

                if (RequestDataGridView.InvokeRequired)
                {
                    RequestDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        RequestDataGridView.AutoGenerateColumns = false;
                        RequestDataGridView.DataSource = null; // Force reset DataSource
                        RequestDataGridView.DataSource = requestDTOs;
                        RequestDataGridView.Refresh();
                    }));
                }
                else
                {
                    RequestDataGridView.AutoGenerateColumns = false;
                    RequestDataGridView.DataSource = null; // Force reset DataSource
                    RequestDataGridView.DataSource = requestDTOs;
                    RequestDataGridView.Refresh();
                }

                Console.WriteLine("DataSource set successfully with " + requestDTOs.Count + " items.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateRequestDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateRequestDataGridView: " + ex.Message);
            }
        }

        private void ActivityAddButton_Click(object sender, EventArgs e)
        {
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient,_userClient,_adminClient,_dataService);
            addActivityTaskForm.Show();
        }

        private void PlotsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InvoicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
