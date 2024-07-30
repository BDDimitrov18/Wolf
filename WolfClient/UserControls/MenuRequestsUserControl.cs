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
        private readonly IFileUploader _fileUploader;

        private bool _isSelectedRequest;

        private bool loaded;

        private bool _isRefreshing = false;
        public MenuRequestsUserControl(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService, IFileUploader fileUploader)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _isSelectedRequest = false;
            _dataService = dataService;
            _fileUploader = fileUploader;
            WebSocketDataUpdate.RequestsUpdated += OnRequestsUpdated;
            WebSocketDataUpdate.ClientRelationshipsUpdated += OnClientRelationshipsUpdated;
            WebSocketDataUpdate.TasksUpdated += OnTasksUpdated;
            WebSocketDataUpdate.ActivitiesUpdated += OnActivitiesUpdated;
            WebSocketDataUpdate.ActivityPlotRelationshipsUpdated += OnActivityPlotRelationshipsUpdated;
            WebSocketDataUpdate.DocumentPlotOwnerRelationshipsUpdated += OnDocumentPlotOwnerRelationshipsUpdated;
            WebSocketDataUpdate.ActivityTypeUpdated += OnActivityTypeUpdated;
            WebSocketDataUpdate.EmployeesUpdated += OnEmployeesUpdated;
            WebSocketDataUpdate.ClientsUpdated += OnClientsUpdated;
            WebSocketDataUpdate.InvoicesUpdated += OnInvoicesUpdated;
        }
        private void MenuRequestsUserControl_Load(object sender, EventArgs e)
        {
            RequestDataGridView.SelectionChanged += RequestDataGridView_SelectionChanged;
            clientsDataGridView.SelectionChanged += clientsDataGridView_SelectionChanged;
            PlotsDataGridView.SelectionChanged += PlotsDataGridView_SelectionChanged;
            OwnershipDataGridView.SelectionChanged += OwnershipDataGridView_SelectionChanged;
            InvoicesDataGridView.SelectionChanged += invoiceDataGridView_SelectionChanged;
            if (_apiClient.getLoginStatus())
            {
                setRequestsDataGridView();
                loaded = true;
            }
            LogInEvent.logIn += OnUserLoggedIn;
            OwnershipDataGridView.CellPainting += OwnershipDataGridView_CellPainting;
            ActivityDataGridView.CellPainting += ActivityDataGridView_CellPainting;
            ActivityDataGridView.SelectionChanged += ActivityDataGridView_SelectionChanged;
            PlotsDataGridView.CellPainting += PlotsDataGridView_CellPainting;

            btnFirstRequestsDataGridView.Click += (s, e) => NavigateDataGridView(RequestDataGridView, "First");
            btnPreviousRequestsDataGridView.Click += (s, e) => NavigateDataGridView(RequestDataGridView, "Previous");
            btnNextRequestsDataGridView.Click += (s, e) => NavigateDataGridView(RequestDataGridView, "Next");
            btnLastRequestsDataGridView.Click += (s, e) => NavigateDataGridView(RequestDataGridView, "Last");

            btnFirstClientsDataGridView.Click += (s, e) => NavigateDataGridView(clientsDataGridView, "First");
            btnPreviousClientsDataGridView.Click += (s, e) => NavigateDataGridView(clientsDataGridView, "Previous");
            btnNextClientsDataGridView.Click += (s, e) => NavigateDataGridView(clientsDataGridView, "Next");
            btnLastClientsDataGridView.Click += (s, e) => NavigateDataGridView(clientsDataGridView, "Last");

            btnFirstActivityDataGridView.Click += (s, e) => NavigateDataGridView(ActivityDataGridView, "First");
            btnPreviousActivityDataGridView.Click += (s, e) => NavigateDataGridView(ActivityDataGridView, "Previous");
            btnNextActivityDataGridView.Click += (s, e) => NavigateDataGridView(ActivityDataGridView, "Next");
            btnLastActivityDataGridView.Click += (s, e) => NavigateDataGridView(ActivityDataGridView, "Last");

            btnFirstPlotsDataGridView.Click += (s, e) => NavigateDataGridView(PlotsDataGridView, "First");
            btnPreviousPlotsDataGridView.Click += (s, e) => NavigateDataGridView(PlotsDataGridView, "Previous");
            btnNextPlotsDataGridView.Click += (s, e) => NavigateDataGridView(PlotsDataGridView, "Next");
            btnLastPlotsDataGridView.Click += (s, e) => NavigateDataGridView(PlotsDataGridView, "Last");

            btnFirstOwnershipDataGridView.Click += (s, e) => NavigateDataGridView(OwnershipDataGridView, "First");
            btnPreviousOwnershipDataGridView.Click += (s, e) => NavigateDataGridView(OwnershipDataGridView, "Previous");
            btnNextOwnershipDataGridView.Click += (s, e) => NavigateDataGridView(OwnershipDataGridView, "Next");
            btnLastOwnershipDataGridView.Click += (s, e) => NavigateDataGridView(OwnershipDataGridView, "Last");
        }

        private async void setRequestsDataGridView()
        {
            var response = await _userClient.GetAllRequests();

            var requestList = response.ResponseObj;
            if (response.ResponseObj.Count() > 0)
            {
                List<GetRequestDTO> _fetchedRequests = new List<GetRequestDTO>();
                GetRequestDTO _selectedRequest = new GetRequestDTO();
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
                var responseStars = await _userClient.GetStarredRequests(_dataService.getLoggedEmployee());
                if (responseStars.IsSuccess)
                {
                    _dataService.SetStarredRequests(responseStars.ResponseObj);
                }
                UpdateRequestDataGridView(_dataService.getRequests());
            }

        }

        private void OnRequestsUpdated(List<GetRequestDTO> requests)
        {
            UpdateRequestDataGridView(_dataService.getRequests());
        }

        private void OnInvoicesUpdated(List<GetInvoiceDTO> requests)
        {
            UpdateInvoicessDataGridView();
        }

        private void OnClientRelationshipsUpdated(List<GetClient_RequestRelashionshipDTO> clientRelationships)
        {
            UpdateClientsDataGridView();
        }

        private void OnTasksUpdated(List<GetTaskDTO> tasks)
        {
            UpdateActivityDataGridView();
        }

        private void OnActivitiesUpdated(List<GetActivityDTO> activities)
        {
            UpdateActivityDataGridView();
        }

        private void OnActivityPlotRelationshipsUpdated(List<GetActivity_PlotRelashionshipDTO> activityPlotRelationships)
        {
            UpdateActivityDataGridView();
            UpdatePlotsDataGridView();
        }

        private void OnDocumentPlotOwnerRelationshipsUpdated(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> documentPlotOwnerRelationships)
        {
            UpdateOwnershipDataGridView();
        }

        private void OnActivityTypeUpdated(GetActivityTypeDTO activityType)
        {
            // Add your logic here if needed to handle activity type updates
        }

        private void OnEmployeesUpdated(List<GetEmployeeDTO> employees)
        {
            // Add your logic here if needed to handle employee updates
        }

        private void OnClientsUpdated(List<GetClientDTO> clients)
        {
            // Add your logic here if needed to handle client updates
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
            if (_isRefreshing)
            {
                return;
            }

            if (RequestDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = RequestDataGridView.SelectedRows[0];
                if (selectedRow.DataBoundItem is GetRequestDTO selectedRequest)
                {
                    _isSelectedRequest = true;
                    _dataService.SetSelectedRequest(selectedRequest);
                    _dataService.SetSelectedActivityViews(null);
                }
            }
            else
            {
                if (_isSelectedRequest)
                {
                    _isSelectedRequest = false;
                    _dataService.SetSelectedRequest(null);
                }
            }

            if (_dataService.GetSelectedRequest() != null)
            {
                UpdatePathLink();
                UpdateClientsDataGridView();
                UpdateActivityDataGridView();
                UpdatePlotsDataGridView();
                UpdateOwnershipDataGridView();
                UpdateInvoicessDataGridView();
            }
        }
        public void UpdatePathLink()
        {
            PathLink.Text = _dataService.GetSelectedRequest().Path;
        }
        private void clientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (clientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedClients = new List<GetClientDTO>();

                // Iterate through all selected rows
                foreach (DataGridViewRow selectedRow in clientsDataGridView.SelectedRows)
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

        private void invoiceDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (InvoicesDataGridView.SelectedRows.Count > 0)
            {
                var selectedInvoices = new List<GetInvoiceDTO>();

                // Iterate through all selected rows
                foreach (DataGridViewRow selectedRow in InvoicesDataGridView.SelectedRows)
                {
                    // Check if the DataBoundItem is of type GetClientDTO
                    if (selectedRow.DataBoundItem is GetInvoiceDTO clientDto)
                    {
                        // Add the client DTO to the list
                        selectedInvoices.Add(clientDto);
                    }
                }

                // Check if there are any selected clients
                if (selectedInvoices.Count > 0)
                {
                    _dataService.SetSelectedInvoices(selectedInvoices);
                }
            }
        }

        private void UpdateOwnershipDataGridView()
        {
            try
            {
                if (_dataService.GetSelectedRequest() == null || _dataService.GetFetchedLinkedRequests() == null)
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
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }

                // Check if the next cell has a value, and if so, paint the bottom border
                if (e.RowIndex < OwnershipDataGridView.RowCount - 1)
                {
                    var nextCellValue = OwnershipDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value as string;
                    if (!string.IsNullOrEmpty(nextCellValue))
                    {
                        // Paint the bottom border with a thicker line
                        using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                        {
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        }
                    }
                }
            }
            else
            {
                // Always paint the right border
                using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }

                // Check if the next cell has a value, and if so, paint the bottom border
                if (e.RowIndex < OwnershipDataGridView.RowCount - 1 &&
                    !string.IsNullOrEmpty(OwnershipDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value as string))
                {
                    // Paint the bottom border with a thicker line
                    using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                }
            }

            // Always paint the bottom border if it is the last row
            if (e.RowIndex == OwnershipDataGridView.RowCount - 1)
            {
                using (Pen gridLinePen = new Pen(OwnershipDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }
        }

        private void PlotsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != PlotsDataGridView.Columns["ActivityName"].Index)
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
                // Adjust the bounds for padding
                Rectangle adjustedBounds = e.CellBounds;
                adjustedBounds.X += 2;
                adjustedBounds.Y += 2;
                adjustedBounds.Width -= 4;
                adjustedBounds.Height -= 4;

                // Paint the text with word wrapping
                TextRenderer.DrawText(e.Graphics, cellValue, e.CellStyle.Font, adjustedBounds, e.CellStyle.ForeColor,
                                      TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.WordBreak);

                // Always paint the right border
                using (Pen gridLinePen = new Pen(PlotsDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }

                // Check if the next cell is not empty and paint the bottom border
                if (e.RowIndex < PlotsDataGridView.RowCount - 1)
                {
                    var nextCellValue = PlotsDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value as string;
                    if (!string.IsNullOrEmpty(nextCellValue))
                    {
                        // Paint the bottom border with a thicker line
                        using (Pen gridLinePen = new Pen(PlotsDataGridView.GridColor)) // Thicker pen
                        {
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        }
                    }
                }
            }
            else
            {
                // Check if the next cell is not empty and paint the bottom border
                if (e.RowIndex < PlotsDataGridView.RowCount - 1 &&
                    !string.IsNullOrEmpty(PlotsDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value as string))
                {
                    // Paint bottom border
                    using (Pen gridLinePen = new Pen(PlotsDataGridView.GridColor))
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                }

                // Always paint the right border
                using (Pen gridLinePen = new Pen(PlotsDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }
            }
        }

        private void ActivityDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Define the indexes for the Activity and ParentActivity columns
            int activityColumnIndex = ActivityDataGridView.Columns["Activity"].Index;
            int parentActivityColumnIndex = ActivityDataGridView.Columns["ParentActivity"].Index;

            if (e.RowIndex < 0 ||
                (e.ColumnIndex != activityColumnIndex &&
                 e.ColumnIndex != parentActivityColumnIndex))
                return;

            // Get the value of the current cell
            var cellValue = e.Value as string;

            // Get the value of the corresponding cell in the Activity column
            var activityCellValue = ActivityDataGridView.Rows[e.RowIndex].Cells[activityColumnIndex].Value as string;

            e.Handled = true;  // Always handle the painting

            // Fill the background
            using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
            }

            // Check if the cell has data and paint accordingly
            if (!string.IsNullOrEmpty(activityCellValue))
            {
                // Adjust the bounds for padding
                Rectangle adjustedBounds = e.CellBounds;
                adjustedBounds.X += 2;
                adjustedBounds.Y += 2;
                adjustedBounds.Width -= 4;
                adjustedBounds.Height -= 4;

                // Paint the text with word wrapping
                TextRenderer.DrawText(e.Graphics, cellValue, e.CellStyle.Font, adjustedBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.WordBreak);

                // Always paint the right border
                using (Pen gridLinePen = new Pen(ActivityDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }

                // Check if the next cell in the Activity column has a value, and if so, paint the bottom border
                if (e.RowIndex < ActivityDataGridView.RowCount - 1)
                {
                    var nextActivityCellValue = ActivityDataGridView.Rows[e.RowIndex + 1].Cells[activityColumnIndex].Value as string;
                    if (!string.IsNullOrEmpty(nextActivityCellValue))
                    {
                        // Paint the bottom border with a thicker line
                        using (Pen gridLinePen = new Pen(ActivityDataGridView.GridColor)) // Thicker pen
                        {
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        }
                    }
                }
            }
            else
            {
                // Always paint the right border
                using (Pen gridLinePen = new Pen(ActivityDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                }

                // Check if the next cell in the Activity column has a value, and if so, paint the bottom border
                if (e.RowIndex < ActivityDataGridView.RowCount - 1 &&
                    !string.IsNullOrEmpty(ActivityDataGridView.Rows[e.RowIndex + 1].Cells[activityColumnIndex].Value as string))
                {
                    // Paint the bottom border with a thicker line
                    using (Pen gridLinePen = new Pen(ActivityDataGridView.GridColor))
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                }
            }

            // Always paint the bottom border if it is the last row
            if (e.RowIndex == ActivityDataGridView.RowCount - 1)
            {
                using (Pen gridLinePen = new Pen(ActivityDataGridView.GridColor))
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }
        }

        private string ConvertFloatToFraction(float value)
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
        public List<OwnershipViewModel> GetOwnershipViewModels(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
        {
            // Initialize the dictionary
            var RelashionshipDictionary = new Dictionary<int, Dictionary<int, List<Dictionary<GetOwnerDTO, string>>>>();

            var plotDictionary = relashionshipDTOs
                .Select(r => r.DocumentPlot.Plot)
                .GroupBy(p => p.PlotId)
                .Select(g => g.First())
                .ToDictionary(p => p.PlotId);

            var documentDictionary = relashionshipDTOs
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

                            // Extract PowerOfAttorneyNumber from the relationship DTO
                            var powerOfAttorneyNumber = relashionshipDTOs
                                .FirstOrDefault(r => r.DocumentPlot.Plot.PlotId == plotEntry.Key
                                                     && r.DocumentPlot.documentOfOwnership.DocumentId == documentEntry.Key
                                                     && r.DocumentOwner.OwnerID == owner.OwnerID)?.powerOfAttorneyDocumentDTO?.number;

                            // Extract PlotOwnerID from the relationship DTO
                            var plotOwnerID = relashionshipDTOs
                                .FirstOrDefault(r => r.DocumentPlot.Plot.PlotId == plotEntry.Key
                                                     && r.DocumentPlot.documentOfOwnership.DocumentId == documentEntry.Key
                                                     && r.DocumentOwner.OwnerID == owner.OwnerID)?.Id;

                            var ownershipViewModel = new OwnershipViewModel()
                            {
                                PlotNumber = isFirstEntryForPlot ? plotDictionary[plotEntry.Key].PlotNumber : string.Empty,
                                NumberTypeDocument = $"{documentDictionary[documentEntry.Key].NumberOfDocument} {documentDictionary[documentEntry.Key].TypeOfDocument}",
                                NumberTypeOwner = $"{owner.OwnerID} {owner.FirstName} {owner.MiddleName} {owner.LastName}",
                                EGN = owner.EGN,
                                Address = owner.Address,
                                IdealParts = idealPartsString,
                                PowerOfAttorneyNumber = powerOfAttorneyNumber,
                                PlotOwnerID = plotOwnerID ?? 0 // Default to 0 if null
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
                if (_dataService.GetSelectedRequest() == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    clientsDataGridView.DataSource = null;
                    clientsDataGridView.Refresh();
                    return;
                }

                var matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _dataService.GetSelectedRequest().RequestId);

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
            PlotsDataGridView.DataSource = null; // Force reset DataSource
            List<PlotViewModel> plotList = new List<PlotViewModel>();

            if (matchingRequestWithClients?.activityDTOs?.Count() > 0)
            {
                foreach (var activityDTO in matchingRequestWithClients.activityDTOs)
                {
                    bool first = true;
                    foreach (var plot in activityDTO.Plots)
                    {
                        PlotViewModel plotViewModel = new PlotViewModel()
                        {
                            ActivityName = first ? activityDTO.ActivityTypeName : "",
                            PlotId = plot.PlotId,
                            PlotNumber = plot.PlotNumber,
                            RegulatedPlotNumber = plot.RegulatedPlotNumber,
                            neighborhood = plot.neighborhood,
                            City = plot.City,
                            Municipality = plot.Municipality,
                            Street = plot.Street,
                            StreetNumber = plot.StreetNumber,
                            designation = plot.designation,
                            locality = plot.locality
                        };
                        plotList.Add(plotViewModel);
                        first = false;
                    }
                }
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

        private void UpdateInvoicessDataGridView()
        {
            try
            {
                if (_dataService.GetSelectedRequest() == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    InvoicesDataGridView.DataSource = null;
                    InvoicesDataGridView.Refresh();
                    return;
                }

                var matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _dataService.GetSelectedRequest().RequestId);

                if (InvoicesDataGridView.InvokeRequired)
                {
                    InvoicesDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        BindInvoicesDataGridView(matchingRequestWithClients);
                    }));
                }
                else
                {
                    BindInvoicesDataGridView(matchingRequestWithClients);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateInvoicessDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateInvoicessDataGridView: " + ex.Message);
            }
        }

        private void BindInvoicesDataGridView(RequestWithClientsDTO matchingRequestWithClients)
        {
            InvoicesDataGridView.AutoGenerateColumns = false;
            InvoicesDataGridView.DataSource = null; // Force reset DataSource

            if (matchingRequestWithClients != null)
            {
                InvoicesDataGridView.DataSource = matchingRequestWithClients.invoiceDTOs;
            }
            else
            {
                InvoicesDataGridView.DataSource = null;
            }

            InvoicesDataGridView.Refresh();
        }

        private List<GetActivityDTO> ApplyActivityFilters(List<GetActivityDTO>? activityDTOs)
        {
            if (activityDTOs == null || activityDTOs.Count() == 0) return activityDTOs;

            var filteredList = activityDTOs;
            var employee = _dataService.getLoggedEmployee();
            // Filter by personal (assuming IsPersonal is a boolean property of GetActivityDTO)
            if (taskSelfCheck.Checked)
            {
                var activitiesToRemove = new List<GetActivityDTO>();

                foreach (var activity in filteredList)
                {
                    bool toRemove = true;
                    var tasksToRemove = new List<GetTaskDTO>();

                    foreach (var task in activity.Tasks)
                    {
                        if (task.ExecutantId != employee.EmployeeId)
                        {
                            tasksToRemove.Add(task);
                        }
                        else
                        {
                            toRemove = false;
                        }
                    }

                    // Remove the tasks after iterating over them
                    foreach (var task in tasksToRemove)
                    {
                        activity.Tasks.Remove(task);
                    }

                    if (activity.Tasks.Count() == 0)
                    {
                        toRemove = true;
                    }

                    if (toRemove)
                    {
                        activitiesToRemove.Add(activity);
                    }
                }

                // Remove the activities after iterating over them
                foreach (var activity in activitiesToRemove)
                {
                    filteredList.Remove(activity);
                }
            }

            // Filter by date (for the day)
            if (taskDayCheck.Checked)
            {
                var activitiesToRemove = new List<GetActivityDTO>();

                foreach (var activity in filteredList)
                {
                    bool toRemove = true;
                    var tasksToRemove = new List<GetTaskDTO>();

                    foreach (var task in activity.Tasks)
                    {
                        if (!(task.FinishDate.Year == DateTime.Now.Year &&
                        task.FinishDate.Month == DateTime.Now.Month &&
                        task.FinishDate.Day == DateTime.Now.Day))
                        {
                            tasksToRemove.Add(task);
                        }
                        else
                        {
                            toRemove = false;
                        }
                    }

                    // Remove the tasks after iterating over them
                    foreach (var task in tasksToRemove)
                    {
                        activity.Tasks.Remove(task);
                    }

                    if (activity.Tasks.Count() == 0)
                    {
                        toRemove = true;
                    }

                    if (toRemove)
                    {
                        activitiesToRemove.Add(activity);
                    }
                }

                // Remove the activities after iterating over them
                foreach (var activity in activitiesToRemove)
                {
                    filteredList.Remove(activity);
                }
            }

            // Filter by date (for the week)
            if (taskWeekCheck.Checked)
            {
                var activitiesToRemove = new List<GetActivityDTO>();

                // Get the start and end date of the current week
                DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                DateTime endOfWeek = startOfWeek.AddDays(7);

                foreach (var activity in filteredList)
                {
                    bool toRemove = true;
                    var tasksToRemove = new List<GetTaskDTO>();

                    foreach (var task in activity.Tasks)
                    {
                        if (!(task.FinishDate >= startOfWeek && task.FinishDate < endOfWeek))
                        {
                            tasksToRemove.Add(task);
                        }
                        else
                        {
                            toRemove = false;
                        }
                    }

                    // Remove the tasks after iterating over them
                    foreach (var task in tasksToRemove)
                    {
                        activity.Tasks.Remove(task);
                    }

                    if (activity.Tasks.Count == 0)
                    {
                        toRemove = true;
                    }

                    if (toRemove)
                    {
                        activitiesToRemove.Add(activity);
                    }
                }

                // Remove the activities after iterating over them
                foreach (var activity in activitiesToRemove)
                {
                    filteredList.Remove(activity);
                }
            }
            if (taskStatusComboBox.SelectedIndex > 0)
            {
                var Status = taskStatusComboBox.SelectedItem.ToString();
                var activitiesToRemove = new List<GetActivityDTO>();

                foreach (var activity in filteredList)
                {
                    bool toRemove = true;
                    var tasksToRemove = new List<GetTaskDTO>();

                    foreach (var task in activity.Tasks)
                    {
                        if (task.Status != Status)
                        {
                            tasksToRemove.Add(task);
                        }
                        else
                        {
                            toRemove = false;
                        }
                    }

                    // Remove the tasks after iterating over them
                    foreach (var task in tasksToRemove)
                    {
                        activity.Tasks.Remove(task);
                    }

                    if (activity.Tasks.Count() == 0)
                    {
                        toRemove = true;
                    }

                    if (toRemove)
                    {
                        activitiesToRemove.Add(activity);
                    }
                }
            }


            return filteredList;
        }

        private void BindActivityDataGridView(List<GetActivityDTO> activityDTOs)
        {
            ActivityDataGridView.AutoGenerateColumns = false;
            ActivityDataGridView.DataSource = null; // Force reset DataSource

            var activityViewModels = new List<ActivityViewModel>();

            foreach (var activity in activityDTOs)
            {
                bool first = true;
                string Identities = "";
                if (activity.Plots.Count() > 0)
                {
                    foreach (var plot in activity.Plots)
                    {
                        string plotInfo = $"Поземлен имот:{plot.PlotNumber}, {plot.City};";
                        Identities += plotInfo;
                    }
                }
                foreach (var task in activity.Tasks)
                {
                    var viewModel = new ActivityViewModel
                    {
                        ActivityTypeName = first ? activity.ActivityType.ActivityTypeName + activity.ActivityId.ToString() : "",
                        ActivityId = activity.ActivityId,
                        TaskTypeName = task.taskType.TaskTypeName,
                        TaskId = task.TaskId,
                        ExecutantFullName = task.Executant.FullName,
                        StartDate = task.StartDate,
                        Duration = task.Duration,
                        ControlFullName = task.Control?.FullName,
                        Comments = task.Comments,
                        Identities = Identities,
                        ParentActivity = first ? activity.ParentActivity == null ? "" : activity.ParentActivity.ActivityTypeName : "",
                        tax = task.tax.ToString(),
                        taxComment = task.CommentTax,
                    };

                    activityViewModels.Add(viewModel);
                    first = false;
                }
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
                        activityDTOs = new List<GetActivityDTO>(),
                        invoiceDTOs = new List<GetInvoiceDTO>()
                    };

                    _dataService.AddSingleRequest(requestWithClients);
                }
            }
            UpdateRequestDataGridView(_dataService.getRequests());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);
            addActivityTaskForm.Show();
            UpdateActivityDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Моля изберете поръчка!");
            }

            AddInvoiceForm addInvoiceForm = new AddInvoiceForm(_apiClient, _adminClient, _userClient, _dataService);
            addInvoiceForm.Show();
            addInvoiceForm.Disposed += InvoiceForm_Disposed;
        }
        private void InvoiceForm_Disposed(object sender, EventArgs e)
        {
            UpdateInvoicessDataGridView();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() != null)
            {
                using (AddClientToRequest form = new AddClientToRequest(_apiClient, _userClient, _adminClient, _dataService.GetSelectedRequest()))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        List<GetClientDTO> getClientDTOs = form.returnClientsList();

                        foreach (RequestWithClientsDTO requestWithClientsDTO in _dataService.GetFetchedLinkedRequests())
                        {
                            if (requestWithClientsDTO.requestDTO.RequestId == _dataService.GetSelectedRequest().RequestId)
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
                if (_dataService.GetSelectedRequest() == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    PlotsDataGridView.DataSource = null;
                    PlotsDataGridView.Refresh();
                    return;
                }

                var matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _dataService.GetSelectedRequest().RequestId);

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
                if (_dataService.GetSelectedRequest() == null || _dataService.GetFetchedLinkedRequests() == null)
                {
                    ActivityDataGridView.DataSource = null;
                    ActivityDataGridView.Refresh();
                    return;
                }
                RequestWithClientsDTO matchingRequestWithClients = new RequestWithClientsDTO();
                matchingRequestWithClients = _dataService.GetFetchedLinkedRequests()
                    .FirstOrDefault(rwc => rwc.requestDTO.RequestId == _dataService.GetSelectedRequest().RequestId);

                if (matchingRequestWithClients != null)
                {
                    matchingRequestWithClients = matchingRequestWithClients.Copy();

                    var filteredActivities = ApplyActivityFilters(matchingRequestWithClients.activityDTOs);

                    if (ActivityDataGridView.InvokeRequired)
                    {
                        ActivityDataGridView.Invoke(new MethodInvoker(delegate
                        {
                            BindActivityDataGridView(filteredActivities);
                        }));
                    }
                    else
                    {
                        BindActivityDataGridView(filteredActivities);
                    }

                    foreach (DataGridViewRow row in ActivityDataGridView.Rows)
                    {
                        row.Height = 60; // Set the height to 60 pixels
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateActivityDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateActivityDataGridView: " + ex.Message);
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
            }
        }

        private List<GetRequestDTO> ApplyFilters(List<GetRequestDTO>? requestDTOs)
        {
            if (requestDTOs == null || requestDTOs.Count() == 0) return requestDTOs;

            var filteredList = requestDTOs;

            // Example filter by RequestId (assuming txtNumber.Text contains a valid integer or is empty)
            if (!string.IsNullOrEmpty(txtNumber.Text) && int.TryParse(txtNumber.Text, out int requestId))
            {
                filteredList = filteredList.Where(r => r.RequestId == requestId).ToList();
            }

            // Filter by PaymentStatus
            if (cmbPaymentStatus.SelectedIndex > 0)
            {
                var selectedPaymentStatus = cmbPaymentStatus.SelectedItem.ToString();
                filteredList = filteredList.Where(r => r.PaymentStatus == selectedPaymentStatus).ToList();
            }

            // Filter by IsPersonal (if applicable)
            if (chkPersonal.Checked)
            {
                filteredList = _dataService.filterRequestsBySelfActivitiesAndTasks(filteredList); // Assuming IsPersonal is a boolean property
            }

            // Filter by date (for the day)
            if (chkForDay.Checked)
            {
                filteredList = _dataService.filterRequestByDaySelfActivitiesAndTasks(filteredList);
            }

            // Filter by date (for the week)
            if (chkForWeek.Checked)
            {
                filteredList = _dataService.FilterRequestByWeekSelfActivitiesAndTasks(filteredList);
            }

            // Filter by IsStarred (if applicable)
            if (chkStarred.Checked)
            {
                var stars = _dataService.GetStarredRequests();

                filteredList = filteredList
                    .Where(request => stars.Any(star => star.RequestId == request.RequestId))
                    .ToList();
            }
            if (statusCheckBox.SelectedIndex > 0)
            {
                var Status = statusCheckBox.SelectedItem.ToString();
                filteredList = _dataService.filterRequestByStatusSelfActivitiesAndTasks(filteredList, Status);
            }

            return filteredList;
        }

        public void UpdateRequestDataGridView(List<GetRequestDTO> requestDTOs)
        {
            int? previousSelectedRequestId = null;
            _isRefreshing = true;
            try
            {
                if (requestDTOs == null)
                {
                    throw new ArgumentNullException(nameof(requestDTOs), "requestDTOs is null.");
                }

                // Step 1: Store the selected RequestId
                if (RequestDataGridView.CurrentRow != null && RequestDataGridView.CurrentRow.DataBoundItem is GetRequestDTO currentRequest)
                {
                    previousSelectedRequestId = currentRequest.RequestId;
                }

                // Apply filters to the requestDTOs list
                var filteredList = ApplyFilters(requestDTOs);

                if (RequestDataGridView.InvokeRequired)
                {
                    RequestDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        UpdateRequestGridViewRows(filteredList);
                        RestoreSelectedRow(previousSelectedRequestId);
                    }));
                }
                else
                {
                    UpdateRequestGridViewRows(filteredList);
                    RestoreSelectedRow(previousSelectedRequestId);
                }

                Console.WriteLine("DataSource set successfully with " + filteredList.Count + " items.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateRequestDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateRequestDataGridView: " + ex.Message);
            }
            finally
            {
                _isRefreshing = false;
            }
        }

        private void RestoreSelectedRow(int? previousSelectedRequestId)
        {
            if (previousSelectedRequestId.HasValue)
            {
                int rowIndex = -1;

                // Find the row with the previously selected RequestId
                foreach (DataGridViewRow row in RequestDataGridView.Rows)
                {
                    if (row.DataBoundItem is GetRequestDTO requestDTO && requestDTO.RequestId == previousSelectedRequestId.Value)
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                // Select the row if it exists
                if (rowIndex >= 0)
                {
                    RequestDataGridView.Rows[rowIndex].Selected = true;
                    RequestDataGridView.CurrentCell = RequestDataGridView.Rows[rowIndex].Cells[0];
                }
                else
                {
                    // Try to select the closest previous row
                    for (int i = previousSelectedRequestId.Value - 1; i >= 0; i--)
                    {
                        rowIndex = FindRowIndexByRequestId(i);
                        if (rowIndex >= 0)
                        {
                            RequestDataGridView.Rows[rowIndex].Selected = true;
                            RequestDataGridView.CurrentCell = RequestDataGridView.Rows[rowIndex].Cells[0];
                            return;
                        }
                    }

                    // Try to select the closest next row
                    for (int i = previousSelectedRequestId.Value + 1; i <= RequestDataGridView.Rows.Count; i++)
                    {
                        rowIndex = FindRowIndexByRequestId(i);
                        if (rowIndex >= 0)
                        {
                            RequestDataGridView.Rows[rowIndex].Selected = true;
                            RequestDataGridView.CurrentCell = RequestDataGridView.Rows[rowIndex].Cells[0];
                            return;
                        }
                    }

                    // If no rows exist, handle appropriately (e.g., deselect all)
                    if (RequestDataGridView.Rows.Count > 0)
                    {
                        RequestDataGridView.Rows[0].Selected = true;
                    }
                    else
                    {
                        RequestDataGridView.ClearSelection();
                    }
                }
            }
        }

        private int FindRowIndexByRequestId(int requestId)
        {
            for (int i = 0; i < RequestDataGridView.Rows.Count; i++)
            {
                if (RequestDataGridView.Rows[i].DataBoundItem is GetRequestDTO requestDTO && requestDTO.RequestId == requestId)
                {
                    return i;
                }
            }
            return -1;
        }

        private void UpdateRequestGridViewRows(List<GetRequestDTO> filteredList)
        {

            RequestDataGridView.AutoGenerateColumns = false;
            RequestDataGridView.DataSource = null; // Force reset DataSource
            RequestDataGridView.DataSource = filteredList;
            RequestDataGridView.Refresh();
            _isRefreshing = false;

            // Fetch the starred requests
            var starredRequests = _dataService.GetStarredRequests();

            // Paint the rows that match the requestId in starred requests
            foreach (DataGridViewRow row in RequestDataGridView.Rows)
            {
                var requestDTO = row.DataBoundItem as GetRequestDTO;
                if (requestDTO != null && starredRequests.Any(s => s.RequestId == requestDTO.RequestId))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = RequestDataGridView.DefaultCellStyle.BackColor;
                }
            }
        }

        private void ActivityAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() != null)
            {
                AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);

                // Subscribe to the FormClosed event
                addActivityTaskForm.Disposed += AddActivityTaskForm_Disposed;

                addActivityTaskForm.Show();
            }
        }

        private void AddActivityTaskForm_Disposed(object sender, EventArgs e)
        {
            var selectedRequest = _dataService.GetSelectedRequest();
            // Invoke the method to update the DataGridView
            UpdateActivityDataGridView();
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
            plotForm.Disposed += PlotFormDispose;
        }
        private void PlotFormDispose(object sender, EventArgs e)
        {
            UpdatePlotsDataGridView();
            UpdateActivityDataGridView();
            UpdateOwnershipDataGridView();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOwnersButton_Click(object sender, EventArgs e)
        {
            AddOwnerForm ownerForm = new AddOwnerForm(_apiClient, _userClient, _adminClient, _dataService);
            ownerForm.Show();
            ownerForm.Disposed += OwnershipFormDispose;
        }
        private void OwnershipFormDispose(object sender, EventArgs e)
        {
            UpdateOwnershipDataGridView();
        }
        private async void DeleteRequestButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please Select A Request");
                return;
            }

            List<GetRequestDTO> requestDTOs = new List<GetRequestDTO>();
            requestDTOs.Add(_dataService.GetSelectedRequest());
            var response = await _userClient.DeleteRequest(requestDTOs);

            if (response.IsSuccess)
            {
                _dataService.OnRequestDelete();
                UpdateRequestDataGridView(_dataService.getRequests());
                UpdateClientsDataGridView();
                UpdateActivityDataGridView();
                UpdatePlotsDataGridView();
                UpdateOwnershipDataGridView();
            }
            else
            {
                // do not delete.
            }
        }

        private async void deleteClientsButton_Click(object sender, EventArgs e)
        {
            List<GetClient_RequestRelashionshipDTO> client_RequestRelashionshipDTOs = new List<GetClient_RequestRelashionshipDTO>();
            var clients = _dataService.getSelectedCLients();
            foreach (var item in clients)
            {
                GetClient_RequestRelashionshipDTO client = new GetClient_RequestRelashionshipDTO()
                {
                    RequestId = _dataService.GetSelectedRequest().RequestId,
                    Request = _dataService.GetSelectedRequest(),
                    Client = item,
                    ClientId = item.ClientId
                };
                client_RequestRelashionshipDTOs.Add(client);
            }
            var response = await _userClient.DeleteClientRequest(client_RequestRelashionshipDTOs);

            if (response.IsSuccess)
            {
                _dataService.OnClientsRequestDelete();
                UpdateClientsDataGridView();
            }
        }

        private async void DeleteActivityButton_Click(object sender, EventArgs e)
        {
            List<GetTaskDTO> taskDTOs = _dataService.getTasksFromViewModel();
            var response = await _userClient.DeleteTasks(taskDTOs);
            if (response.IsSuccess)
            {
                List<GetActivityDTO> activities = _dataService.OnTasksDelete(taskDTOs);
                if (activities.Count > 0)
                {
                    var activityResponse = await _userClient.DeleteActivities(activities);
                    if (activityResponse.IsSuccess)
                    {
                        _dataService.DeleteActivities(activities);

                    }
                }
                UpdateActivityDataGridView();
                UpdatePlotsDataGridView();
                UpdateOwnershipDataGridView();
            }
            else
            {

            }
        }

        private void CreateDocumentButton_Click(object sender, EventArgs e)
        {
            CreateDocument createDocumentForm = new CreateDocument(_dataService, _fileUploader);
            createDocumentForm.Show();
        }

        private void ActivityDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActivityDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (ActivityDataGridView.SelectedRows.Count > 0)
            {
                var selectedActivities = new List<ActivityViewModel>();

                // Iterate through all selected rows
                foreach (DataGridViewRow selectedRow in ActivityDataGridView.SelectedRows)
                {
                    // Check if the DataBoundItem is of type GetClientDTO
                    if (selectedRow.DataBoundItem is ActivityViewModel activityViewModel)
                    {
                        // Add the client DTO to the list
                        selectedActivities.Add(activityViewModel);
                    }
                }

                // Check if there are any selected clients
                if (selectedActivities.Count > 0)
                {
                    _dataService.SetSelectedActivityViews(selectedActivities);
                }
            }
        }

        private void PlotsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (PlotsDataGridView.SelectedRows.Count > 0)
            {
                var selectedPlots = new List<PlotViewModel>();

                // Iterate through all selected rows
                foreach (DataGridViewRow selectedRow in PlotsDataGridView.SelectedRows)
                {
                    // Check if the DataBoundItem is of type GetClientDTO
                    if (selectedRow.DataBoundItem is PlotViewModel activityViewModel)
                    {
                        // Add the client DTO to the list
                        selectedPlots.Add(activityViewModel);
                    }
                }

                // Check if there are any selected clients
                if (selectedPlots.Count > 0)
                {
                    _dataService.SetSelectedPlotsOnRequestMenu(selectedPlots);
                }
            }
        }

        private void OwnershipDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (OwnershipDataGridView.SelectedRows.Count > 0)
            {
                var selectedOwnershipViewModels = new List<OwnershipViewModel>();

                // Iterate through all selected rows
                foreach (DataGridViewRow selectedRow in OwnershipDataGridView.SelectedRows)
                {
                    // Check if the DataBoundItem is of type GetClientDTO
                    if (selectedRow.DataBoundItem is OwnershipViewModel activityViewModel)
                    {
                        // Add the client DTO to the list
                        selectedOwnershipViewModels.Add(activityViewModel);
                    }
                }

                // Check if there are any selected clients
                if (selectedOwnershipViewModels.Count > 0)
                {
                    _dataService.SetSelectedOwnershipViewModelsRequestMenu(selectedOwnershipViewModels);
                }
            }
        }

        private async void DeletePlotsButton_Click(object sender, EventArgs e)
        {
            List<PlotViewModel> viewModels = _dataService.getSelectedPlotsOnRequestMenu();
            List<GetPlotDTO> getPlotDTOs = new List<GetPlotDTO>();
            foreach (var viewModel in viewModels)
            {
                GetPlotDTO plot = new GetPlotDTO()
                {
                    PlotId = viewModel.PlotId,
                    PlotNumber = viewModel.PlotNumber,
                    RegulatedPlotNumber = viewModel.RegulatedPlotNumber,
                    neighborhood = viewModel.neighborhood,
                    City = viewModel.City,
                    Municipality = viewModel.Municipality,
                    Street = viewModel.Street,
                    StreetNumber = viewModel.StreetNumber,
                    designation = viewModel.designation,
                    locality = viewModel.locality
                };
                getPlotDTOs.Add(plot);
            }

            List<GetActivity_PlotRelashionshipDTO> getActivity_PlotRelashionshipDTOs = _dataService.getActivity_PlotRelashionshipDTOs(getPlotDTOs);
            var response = await _userClient.activityPlotRelashionshipRemove(getActivity_PlotRelashionshipDTOs);
            if (response.IsSuccess)
            {
                _dataService.RemovePlots(getPlotDTOs);
                UpdatePlotsDataGridView();
            }

        }

        private async void DeleteOwnershipButton_Click(object sender, EventArgs e)
        {
            List<OwnershipViewModel> ownershipViewModels = _dataService.GetSelectedOwnershipViewModelsRequestMenu();
            List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs = new List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>();
            foreach (var ownershipModel in ownershipViewModels)
            {
                GetDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO = _dataService.GetPlotOwnerById(ownershipModel.PlotOwnerID);
                relashionshipDTOs.Add(relashionshipDTO);
            }
            var result = await _userClient.deletePlotOwnerRelashionships(relashionshipDTOs);
            if (result.IsSuccess)
            {
                _dataService.RemovePlotOwnerRelashionships(relashionshipDTOs);
                UpdateOwnershipDataGridView();
            }
        }

        private void editRequestButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() != null)
            {
                EditRequestForm editRequestForm = new EditRequestForm(_apiClient, _userClient, _adminClient, _dataService);
                editRequestForm.Show();
                editRequestForm.Disposed += EditRequestFormDispose;
            }
            else
            {
                MessageBox.Show("Please Select A request");
            }
        }

        private void EditRequestFormDispose(object sender, EventArgs e)
        {
            UpdateRequestDataGridView(_dataService.getRequests());
        }

        private void editClientButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getSelectedCLients() != null && _dataService.getSelectedCLients().Count() > 0)
            {
                EditCientForm editCientForm = new EditCientForm(_apiClient, _userClient, _adminClient, _dataService);
                editCientForm.Show();
                editCientForm.Disposed += EditClientFormDispose;
            }
            else
            {
                MessageBox.Show("Please Select a client");
            }
        }

        private void EditClientFormDispose(object sender, EventArgs e)
        {
            UpdateClientsDataGridView();
        }

        private void editActivityButton_Click(object sender, EventArgs e)
        {
            EditActivityTaskForm editActivityTaskForm = new EditActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);
            editActivityTaskForm.Show();
            editActivityTaskForm.Disposed += EditActivityFormDispose;
        }
        private void EditActivityFormDispose(object sender, EventArgs e)
        {
            UpdateActivityDataGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void editPlotButton_Click(object sender, EventArgs e)
        {
            EditPlot editPlot = new EditPlot(_apiClient, _userClient, _adminClient, _dataService);
            editPlot.Show();
            editPlot.Disposed += EditPlotFormDispose;
        }

        private void EditPlotFormDispose(object sender, EventArgs e)
        {
            UpdateActivityDataGridView();
            UpdatePlotsDataGridView();
            UpdateOwnershipDataGridView();
        }

        private void editOwnershipButton_Click(object sender, EventArgs e)
        {
            EditOwnerForm editOwnerForm = new EditOwnerForm(_apiClient, _userClient, _adminClient, _dataService);
            editOwnerForm.Show();
            editOwnerForm.Disposed += EditOwnershipFormDispose;
        }
        private void EditOwnershipFormDispose(object sender, EventArgs e)
        {
            UpdateOwnershipDataGridView();
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

        private void RequestFiltersApplyButton_Click(object sender, EventArgs e)
        {
            UpdateRequestDataGridView(_dataService.getRequests());
        }

        private void ApplyActivityFiltersButton_Click(object sender, EventArgs e)
        {
            UpdateActivityDataGridView();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void starRequestButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Моля Изберете поръчка");
                return;
            }
            if (!_dataService.isStarred())
            {
                CreateStarRequest_EmployeeRelashionshipDTO starRequest_EmployeeRelashionshipDTO = new CreateStarRequest_EmployeeRelashionshipDTO()
                {
                    RequestId = _dataService.GetSelectedRequest().RequestId,
                    EmployeeID = _dataService.getLoggedEmployee().EmployeeId,
                };
                var responseStar = await _userClient.AddStar(starRequest_EmployeeRelashionshipDTO);
                GetstarRequest_EmployeeRelashionshipDTO getstarRequest_EmployeeRelashionshipDTO = responseStar.ResponseObj;
                _dataService.addStar(getstarRequest_EmployeeRelashionshipDTO);
            }
            else
            {
                _userClient.DeleteStar(_dataService.getCurrentStar());
                _dataService.removeStar();
            }

            UpdateRequestDataGridView(_dataService.getRequests());
        }

        private void PathLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = PathLink.Text;

            if (Directory.Exists(path) || File.Exists(path))
            {
                // Open the File Explorer at the specified path
                Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("The specified path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Моля изберете поръчка!");
            }
            if (_dataService.getSelectedInvoices().Count == 0 || _dataService.getSelectedInvoices() == null)
            {
                MessageBox.Show("Моля изберете фактура");
                return;
            }
            EditInvoiceForm editInvoiceForm = new EditInvoiceForm(_apiClient, _adminClient, _userClient, _dataService);
            editInvoiceForm.Show();
            editInvoiceForm.Disposed += InvoiceForm_Disposed;
        }

        private async void DeleteInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null) {
                MessageBox.Show("Моля изберете поръчка!");
            }

            if (_dataService.getSelectedInvoices().Count == 0 || _dataService.getSelectedInvoices() == null)
            {
                MessageBox.Show("Моля изберете фактури за изтриване!");
                return;
            }
            await _userClient.DeleteInvoices(_dataService.getSelectedInvoices());
            _dataService.DeleteInvoices(_dataService.getSelectedInvoices());
            UpdateInvoicessDataGridView();
        }
    }
}
