using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Events;
using WolfClient.Events.EventArgs;
using WolfClient.NewForms;
using WolfClient.Services.Interfaces;
using WolfClient.ViewModels;

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
            _selectedRequest = new GetRequestDTO();
            _fetchedRequests = new List<GetRequestDTO>();
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
            OwnershipDataGridView.CellPainting += OwnershipDataGridView_CellPainting;
        }

        private async void setRequestsDataGridView()
        {
            var response = await _userClient.GetAllRequests();

            var requestList = response.ResponseObj;
            if (response.ResponseObj.Count() > 0)
            {
                _fetchedRequests = response.ResponseObj;
                _selectedRequest = _fetchedRequests[0];
                _dataService.SetSelectedRequest(_selectedRequest);
                var linkedClientsResponse = await _userClient.GetLinked(_fetchedRequests);
                if (linkedClientsResponse.IsSuccess)
                {
                    _dataService.SetFetchedLinkedRequests(linkedClientsResponse.ResponseObj);
                }
                var linkedDocs = await _userClient.GetLinkedPlotOwnerRelashionships(_dataService.GetAllPlots());
                _dataService.setPlotOwnersRelashionships(linkedDocs.ResponseObj);
                RequestDataGridView.AutoGenerateColumns = false;
                RequestDataGridView.DataSource = requestList;
                RequestDataGridView.Refresh();
            }
        }
        private async void OnUserLoggedIn(object sender, LogInEventArgs e)
        {
            if (!loaded)
            {
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
                UpdateActivityDataGridView();
                UpdatePlotsDataGridView();
                UpdateOwnershipDataGridView();
            }
        }

        private void UpdateOwnershipDataGridView()
        {
            try
            {
                if (_selectedRequest == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    OwnershipDataGridView.DataSource = null;
                    OwnershipDataGridView.Refresh();
                    return;
                }

                var linkedDocs = _dataService.GetLinkedPlotOwnerRelashionships();

                if (OwnershipDataGridView.InvokeRequired)
                {
                    OwnershipDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        BindOwnershipDataGridView(linkedDocs);
                    }));
                }
                else
                {
                    BindOwnershipDataGridView(linkedDocs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateOwnershipDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateOwnershipDataGridView: " + ex.Message);
            }
        }

        private void OwnershipDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != OwnershipDataGridView.Columns["PlotNumberDocTable"].Index)
                return;

            var cellValue = e.Value as string;

            e.Handled = true;  // Always handle the painting

            // Fill the background
            using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
            }

            // Check if the cell has data and paint accordingly
            if (!string.IsNullOrEmpty(cellValue))
            {
                // Paint the text
                TextRenderer.DrawText(e.Graphics, cellValue, e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

                // Always paint the right border
                using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom-1);
                }

                // Check if the next cell is empty, and if so, clear the bottom border
                if (e.RowIndex < OwnershipDataGridView.RowCount - 1)
                {
                    var nextCellValue = OwnershipDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value as string;
                    if (string.IsNullOrEmpty(nextCellValue))
                    {
                        // Clear the bottom border with a thicker line
                        using (Pen backColorPen = new Pen(e.CellStyle.BackColor)) // Thicker pen
                        {
                            e.Graphics.DrawLine(backColorPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 3, e.CellBounds.Bottom - 1);
                        }
                    }
                }
                else {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                }
            }
            else
            {
                    // Check if the next cell is not empty
                    if (e.RowIndex < OwnershipDataGridView.RowCount - 1 &&
                        !string.IsNullOrEmpty(OwnershipDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value as string))
                    {
                        // Paint bottom border
                        using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                        {
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        }
                    }

                    // Always paint the right border
                    using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom-1);
                    }
            }
            if (!(e.RowIndex < OwnershipDataGridView.RowCount - 1)) {
                // Paint bottom border
                using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }


        }

        private  string ConvertFloatToFraction(float value)
        {
            // Tolerance for floating point comparison
            const double TOLERANCE = 1.0E-6;

            if (value == 0.0)
                return "0/1";

            int sign = Math.Sign(value);
            value = Math.Abs(value);

            int n = (int)Math.Floor(value);
            value -= n;

            if (value < TOLERANCE)
                return $"{sign * n}/1";

            if (1 - value < TOLERANCE)
                return $"{sign * (n + 1)}/1";

            int lower_numerator = 0;
            int lower_denominator = 1;
            int upper_numerator = 1;
            int upper_denominator = 1;

            while (true)
            {
                int middle_numerator = lower_numerator + upper_numerator;
                int middle_denominator = lower_denominator + upper_denominator;

                if (middle_denominator * (value + TOLERANCE) < middle_numerator)
                {
                    upper_numerator = middle_numerator;
                    upper_denominator = middle_denominator;
                }
                else if (middle_numerator < (value - TOLERANCE) * middle_denominator)
                {
                    lower_numerator = middle_numerator;
                    lower_denominator = middle_denominator;
                }
                else
                {
                    return $"{sign * (n * middle_denominator + middle_numerator)}/{middle_denominator}";
                }
            }
        }
        private List<OwnershipViewModel> GetOwnershipViewModels(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
        {
            // Initialize the dictionary
            Dictionary<int, Dictionary<int, List<Dictionary<GetOwnerDTO, string>>>> RelashionshipDictionary =
                new Dictionary<int, Dictionary<int, List<Dictionary<GetOwnerDTO, string>>>>();

            Dictionary<int, GetPlotDTO> plotDictionary = relashionshipDTOs
                .Select(r => r.DocumentPlot.Plot)
                .GroupBy(p => p.PlotId)
                .Select(g => g.First())
                .ToDictionary(p => p.PlotId);

            Dictionary<int, GetDocumentOfOwnershipDTO> documentDictionary = relashionshipDTOs
                .Select(r => r.DocumentPlot.documentOfOwnership)
                .GroupBy(d => d.DocumentId)
                .Select(g => g.First())
                .ToDictionary(d => d.DocumentId);

            foreach (var relashionship in relashionshipDTOs)
            {
                var plotId = relashionship.DocumentPlot.Plot.PlotId;
                var documentId = relashionship.DocumentPlot.documentOfOwnership.DocumentId;
                var owner = relashionship.DocumentOwner.Owner;
                var idealParts = relashionship.IdealParts;

                // Check if the plot is already in the dictionary
                if (!RelashionshipDictionary.ContainsKey(plotId))
                {
                    RelashionshipDictionary[plotId] = new Dictionary<int, List<Dictionary<GetOwnerDTO, string>>>();
                }

                // Check if the document is already in the dictionary for this plot
                if (!RelashionshipDictionary[plotId].ContainsKey(documentId))
                {
                    RelashionshipDictionary[plotId][documentId] = new List<Dictionary<GetOwnerDTO, string>>();
                }

                // Determine the string value for idealParts based on isDrob
                string idealPartsString = relashionship.isDrob ? ConvertFloatToFraction(idealParts) : idealParts.ToString();

                // Create a dictionary for the owner and ideal parts string
                var ownerWithIdealParts = new Dictionary<GetOwnerDTO, string> { { owner, idealPartsString } };

                // Add the owner and ideal parts string to the list for this document
                RelashionshipDictionary[plotId][documentId].Add(ownerWithIdealParts);
            }

            var ownershipViewModels = new List<OwnershipViewModel>();
            foreach (var plotEntry in RelashionshipDictionary)
            {
                bool isFirstEntryForPlot = true;
                foreach (var documentEntry in plotEntry.Value)
                {
                    foreach (var ownerWithIdealParts in documentEntry.Value)
                    {
                        foreach (var ownerEntry in ownerWithIdealParts)
                        {
                            var owner = ownerEntry.Key;
                            var idealPartsString = ownerEntry.Value;

                            OwnershipViewModel ownershipViewModel = new OwnershipViewModel()
                            {
                                PlotNumber = isFirstEntryForPlot ? plotDictionary[plotEntry.Key].PlotNumber : string.Empty,
                                NumberTypeDocument = $"{documentDictionary[documentEntry.Key].NumberOfDocument} {documentDictionary[documentEntry.Key].TypeOfDocument}",
                                NumberTypeOwner = $"{owner.OwnerID} {owner.FirstName} {owner.MiddleName} {owner.LastName}",
                                EGN = owner.EGN,
                                Address = owner.Address,
                                IdealParts = idealPartsString
                            };

                            ownershipViewModels.Add(ownershipViewModel);
                            isFirstEntryForPlot = false;
                        }
                    }
                }
            }

            return ownershipViewModels;
        }
        private void BindOwnershipDataGridView(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
        {
            OwnershipDataGridView.AutoGenerateColumns = false;
            OwnershipDataGridView.DataSource = null; // Force reset DataSource

            if (relashionshipDTOs != null)
            {
                var viewModelList = GetOwnershipViewModels(relashionshipDTOs);
                OwnershipDataGridView.DataSource = viewModelList;
                OwnershipDataGridView.Refresh();
            }
            else
            {
                OwnershipDataGridView.DataSource = null;
            }

            OwnershipDataGridView.Refresh();
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

        private void BindPlotDataGridView(RequestWithClientsDTO matchingRequestWithClients)
        {
            PlotsDataGridView.AutoGenerateColumns = false;
            PlotsDataGridView.DataSource = null;
            List<GetPlotDTO> plotList = new List<GetPlotDTO>();
            foreach (var activityDTO in matchingRequestWithClients.activityDTOs)
            {
                plotList.AddRange(activityDTO.Plots);
            }

            if (matchingRequestWithClients != null)
            {
                PlotsDataGridView.DataSource = plotList;
            }
            else
            {
                PlotsDataGridView.DataSource = null;
            }

            PlotsDataGridView.Refresh();
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

        private void BindActivityDataGridView(RequestWithClientsDTO matchingRequestWithClients)
        {
            ActivityDataGridView.AutoGenerateColumns = false;
            ActivityDataGridView.DataSource = null; // Force reset DataSource

            var activityViewModels = new List<ActivityViewModel>();

            if (matchingRequestWithClients != null)
            {
                if (matchingRequestWithClients.activityDTOs != null)
                {
                    foreach (var activity in matchingRequestWithClients.activityDTOs)
                    {
                        string Identities = "";
                        foreach (var plot in activity.Plots)
                        {
                            string plotInfo = $"Поземлен имот:{plot.PlotNumber}, {plot.City};";
                            Identities += plotInfo;
                        }
                        foreach (var task in activity.Tasks)
                        {
                            var viewModel = new ActivityViewModel
                            {
                                ActivityTypeName = activity.ActivityType.ActivityTypeName + activity.ActivityId.ToString(),
                                TaskTypeName = task.taskType.TaskTypeName,
                                ExecutantFullName = task.Executant.FullName,
                                StartDate = task.StartDate,
                                Duration = task.Duration,
                                ControlFullName = task.Control?.FullName,
                                Comments = task.Comments,
                                Identities = Identities,
                                ParentActivity = activity.ParentActivity == null ? "" : activity.ParentActivity.ActivityTypeName,
                            };

                            activityViewModels.Add(viewModel);
                        }
                    }
                }
            }
            else
            {
                clientsDataGridView.DataSource = null;
            }
            ActivityDataGridView.DataSource = activityViewModels;
            ActivityDataGridView.Refresh();
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
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);
            addActivityTaskForm.Show();
            UpdateActivityDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddInvoiceForm addInvoiceForm = new AddInvoiceForm();
            addInvoiceForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() != null)
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
        }

        public void UpdatePlotsDataGridView()
        {
            try
            {
                if (_selectedRequest == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    PlotsDataGridView.DataSource = null;
                    PlotsDataGridView.Refresh();
                    return;
                }

                var matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _selectedRequest.RequestId);

                if (PlotsDataGridView.InvokeRequired)
                {
                    PlotsDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        BindPlotDataGridView(matchingRequestWithClients);
                    }));
                }
                else
                {
                    BindPlotDataGridView(matchingRequestWithClients);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateClientsDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateClientsDataGridView: " + ex.Message);
            }

        }

        public void UpdateActivityDataGridView()
        {
            try
            {
                if (_selectedRequest == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    ActivityDataGridView.DataSource = null;
                    ActivityDataGridView.Refresh();
                    return;
                }

                var matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _selectedRequest.RequestId);

                if (ActivityDataGridView.InvokeRequired)
                {
                    ActivityDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        BindActivityDataGridView(matchingRequestWithClients);
                    }));
                }
                else
                {
                    BindActivityDataGridView(matchingRequestWithClients);
                }
                foreach (DataGridViewRow row in ActivityDataGridView.Rows)
                {
                    row.Height = 60; // Set the height to 60 pixels
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateClientsDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateClientsDataGridView: " + ex.Message);
            }

        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var response = await _userClient.GetAllRequests();
            var linkedResponse = await _userClient.GetLinked(response.ResponseObj);
            var DocumentPlotOwnerReplashionships = await _userClient.GetLinkedPlotOwnerRelashionships(_dataService.GetAllPlots());
            _dataService.setPlotOwnersRelashionships(DocumentPlotOwnerReplashionships.ResponseObj);
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
            if (_dataService.GetSelectedRequest() != null)
            {
                AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);
                addActivityTaskForm.Show();
                UpdateActivityDataGridView();
            }
        }

        private void PlotsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InvoicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlotsAddButton_Click(object sender, EventArgs e)
        {
            AddPlotToObject plotForm = new AddPlotToObject(_apiClient, _userClient, _adminClient, _dataService);
            plotForm.Show();
            UpdatePlotsDataGridView();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOwnersButton_Click(object sender, EventArgs e)
        {
            AddOwnerForm ownerForm = new AddOwnerForm(_apiClient, _userClient, _adminClient, _dataService);
            ownerForm.Show();
            UpdateOwnershipDataGridView();
        }
    }
}
