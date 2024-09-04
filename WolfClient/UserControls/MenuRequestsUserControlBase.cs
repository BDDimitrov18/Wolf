using DocumentFormat.OpenXml.Drawing.Wordprocessing;
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

    public partial class MenuRequestsUserControlBase : UserControl
    {
        protected readonly IApiClient _apiClient;
        protected readonly IUserClient _userClient;
        protected readonly IAdminClient _adminClient;
        protected readonly IDataService _dataService;
        protected readonly IFileUploader _fileUploader;

        protected bool _isSelectedRequest;

        protected bool loaded;

        protected bool _isRefreshing = false;
        protected bool _filterState = false;

        protected Panel draggablePanel;
        protected Point dragOffset;
        protected bool isDragging = false;

        protected List<GetEmployeeDTO> _allEmployees;
        public MenuRequestsUserControlBase(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService, IFileUploader fileUploader)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _isSelectedRequest = false;
            _dataService = dataService;
            _fileUploader = fileUploader;
            LogInEvent.logIn += OnUserLoggedIn;
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
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            _allEmployees = new List<GetEmployeeDTO>();

            RequestDataGridView.MouseDown += RequestDataGridView_MouseDown;
            RequestDataGridView.CellBeginEdit += RequestDataGridView_CellBeginEdit;
            RequestDataGridView.CellPainting += RequestDataGridView_CellPainting;

        }


        protected void RequestDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                // Example: Perform checks or adjustments before the cell enters edit mode
                if (e.ColumnIndex == RequestDataGridView.Columns["Comments"].Index)
                {
                    // Ensure that the cell's font is properly set, or perform any other necessary actions
                    var cell = RequestDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Style.Font = new Font("Segoe UI", 9); // Ensure a consistent font
                }

                // Additional logic to handle specific cells or conditions can be added here
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                MessageBox.Show("Error in CellBeginEdit: " + ex.Message);

                // Optionally, cancel the edit operation if something goes wrong
                e.Cancel = true;
            }
        }
        protected void RequestDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if we're in the "Comments" column and the row index is valid
            if (e.ColumnIndex == RequestDataGridView.Columns["Comments"].Index && e.RowIndex >= 0)
            {
                string cellValue = e.FormattedValue?.ToString() ?? string.Empty;

                // Check if the cell contains any hyperlinks
                bool containsHyperlink = cellValue.Split(' ').Any(word => Uri.IsWellFormedUriString(word, UriKind.Absolute));

                // If the cell contains hyperlinks, apply custom painting
                if (containsHyperlink)
                {
                    // If the cell is in edit mode, skip custom painting to avoid interfering with editing logic
                    if (RequestDataGridView.CurrentCell != null &&
                        RequestDataGridView.CurrentCell.RowIndex == e.RowIndex &&
                        RequestDataGridView.CurrentCell.ColumnIndex == e.ColumnIndex &&
                        RequestDataGridView.IsCurrentCellInEditMode)
                    {
                        // Let the default painting handle this situation
                        return;
                    }

                    // Custom painting logic
                    e.PaintBackground(e.ClipBounds, true);

                    // Split the text into lines first, then process each line
                    string[] lines = cellValue.Split(new[] { '\n' }, StringSplitOptions.None);

                    TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.NoPadding;
                    Rectangle textRect = new Rectangle(e.CellBounds.Left + 2, e.CellBounds.Top + 2, e.CellBounds.Width - 4, e.CellBounds.Height - 4);

                    using (Font regularFont = e.CellStyle.Font)
                    using (Font linkFont = new Font(e.CellStyle.Font, FontStyle.Underline))
                    {
                        int currentY = textRect.Top;

                        foreach (var line in lines)
                        {
                            int currentX = textRect.Left;
                            int lineHeight = 0;

                            // Split the line into words for processing
                            string[] words = line.Split(' ');

                            foreach (var word in words)
                            {
                                bool isHyperlink = Uri.IsWellFormedUriString(word, UriKind.Absolute);

                                Font fontToUse = isHyperlink ? linkFont : regularFont;
                                Color colorToUse = isHyperlink ? Color.Blue : e.CellStyle.ForeColor;

                                Size wordSize = TextRenderer.MeasureText(word + " ", fontToUse, new Size(int.MaxValue, int.MaxValue), flags);

                                // Move to the next line if the word doesn't fit in the current line
                                if (currentX + wordSize.Width > textRect.Right)
                                {
                                    currentX = textRect.Left;
                                    currentY += lineHeight;
                                    lineHeight = 0;
                                }

                                // Update the line height based on the tallest word in the line
                                lineHeight = Math.Max(lineHeight, wordSize.Height);

                                TextRenderer.DrawText(e.Graphics, word + " ", fontToUse, new Rectangle(currentX, currentY, wordSize.Width, wordSize.Height), colorToUse, flags);

                                currentX += wordSize.Width;
                            }

                            // After processing all words in the current line, move to the next line
                            currentY += lineHeight;
                        }
                    }

                    // Draw the border around the cell
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
                    e.Handled = true;
                }
                else
                {
                    // If there are no hyperlinks, use default painting
                    e.Handled = false;
                }
            }
            else
            {
                // For all other cells, use default painting
                e.Handled = false;
            }
        }

        protected void RequestDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            var hitTestInfo = RequestDataGridView.HitTest(e.X, e.Y);

            // Ensure the click was on a valid cell in the "Comments" column
            if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == RequestDataGridView.Columns["Comments"].Index)
            {
                var cell = RequestDataGridView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                var cellValue = cell?.Value?.ToString();

                // Proceed only if the cell value is not null or empty
                if (!string.IsNullOrEmpty(cellValue))
                {
                    // Split the text into lines and then into words to identify URLs
                    string[] lines = cellValue.Split(new[] { '\n' }, StringSplitOptions.None);

                    // Get the cell's display rectangle and adjust for scrolling
                    var cellRect = RequestDataGridView.GetCellDisplayRectangle(hitTestInfo.ColumnIndex, hitTestInfo.RowIndex, false);
                    float currentY = cellRect.Top + 2;

                    using (Graphics g = RequestDataGridView.CreateGraphics())
                    {
                        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.NoPadding;

                        foreach (var line in lines)
                        {
                            float currentX = cellRect.Left + 2; // Start with a small padding
                            int lineHeight = 0;

                            // Split the line into words
                            string[] words = line.Split(' ');

                            foreach (var word in words)
                            {
                                bool isHyperlink = Uri.IsWellFormedUriString(word, UriKind.Absolute);

                                // Measure the size of the word using the same logic as in CellPainting
                                Size wordSize = TextRenderer.MeasureText(word + " ", RequestDataGridView.Font, new Size(int.MaxValue, int.MaxValue), flags);

                                // Check if the word fits within the current line, if not move to the next line
                                if (currentX + wordSize.Width > cellRect.Right)
                                {
                                    currentX = cellRect.Left + 2; // Reset X to the left with padding
                                    currentY += lineHeight;      // Move Y to the next line
                                    lineHeight = 0;
                                }

                                // Update the line height to account for wrapped text
                                lineHeight = Math.Max(lineHeight, wordSize.Height);

                                // If the word is a hyperlink, check if the mouse click is within this word's bounds
                                if (isHyperlink)
                                {
                                    RectangleF wordRect = new RectangleF(currentX, currentY, wordSize.Width, wordSize.Height);

                                    // Convert the mouse position to the cell's coordinate system
                                    Point clickPoint = new Point(e.X, e.Y);
                                    if (wordRect.Contains(clickPoint))
                                    {
                                        // Open the link in the default web browser
                                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                        {
                                            FileName = word,
                                            UseShellExecute = true // This ensures the URL opens in the default browser
                                        });
                                        return; // Exit after opening the link
                                    }
                                }

                                // Move to the next word's position
                                currentX += wordSize.Width;
                            }

                            // Move to the next line after processing all words in the current line
                            currentY += lineHeight;
                        }
                    }
                }
            }
        }


        public virtual void OnShiftF2Pressed()
        {
            // Default behavior (optional, can be empty)
        }
        public virtual void OnShiftF1Pressed()
        {
            // Default behavior (optional, can be empty)
        }

        public virtual void OnControlFPressed()
        {
            // Default behavior (can be empty or have a generic implementation)
        }

        public virtual void OnF5Pressed()
        {
            // Default behavior (can be empty or have a generic implementation)
        }
        public virtual void OnF1Pressed()
        {
            // Default behavior (optional, can be empty)
        }
        public virtual void OnF2Pressed()
        {
            // Default behavior (optional, can be empty)
        }
        protected virtual int GetSelectedTabIndex()
        {
            // Assuming you have a TabControl named "tabControl1"
            if (DocumentsOfOwnershipTab.SelectedTab != null)
            {
                return DocumentsOfOwnershipTab.SelectedIndex;  // Returns the index of the selected tab
            }
            else
            {
                return -1;  // Return -1 if no tab is selected
            }
        }
        public MenuRequestsUserControlBase() : this(null, null, null, null, null)
        {
            // Optionally, put some designer-specific initialization code here
            // This constructor won't be used in production, only in the designer
        }
        // Parameterless constructor for Designer

        public async  void MenuRequestsUserControl_Load(object sender, EventArgs e)
        {
            if (_apiClient == null || _userClient == null || _adminClient == null || _dataService == null || _fileUploader == null)
            {
                return;
            }

            RequestDataGridView.SelectionChanged += RequestDataGridView_SelectionChanged;
            clientsDataGridView.SelectionChanged += clientsDataGridView_SelectionChanged;
            PlotsDataGridView.SelectionChanged += PlotsDataGridView_SelectionChanged;
            OwnershipDataGridView.SelectionChanged += OwnershipDataGridView_SelectionChanged;
            InvoicesDataGridView.SelectionChanged += invoiceDataGridView_SelectionChanged;

            // Enable double buffering to reduce flickering
            

            filtersPanel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            filtersPanel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            filtersPanel.MouseUp += new MouseEventHandler(Panel_MouseUp);

            //employee filter logic: 

            // Get employees

            
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

            starRequestButton.MouseDown += starRequestButton_MouseDown;

            // Attach event handler for the "Choose Color" menu item click
            ChooseColor.Click += ChooseColor_Click;

            // Attach event handler for populating the "Available Colors" menu
            AvailableColors.DropDownOpening += (s, e) => PopulateUsedColorsMenu();
        }
        protected void AdjustPanelSize()
        {
            filtersPanel.PerformLayout();
            filtersPanel.Invalidate();
            filtersPanel.Update();
        }

        protected async void setRequestsDataGridView()
        {
            var employeesResponse = await _userClient.GetAllEmployees();
            var employeesList = employeesResponse.ResponseObj as List<GetEmployeeDTO>;
            _allEmployees = employeesList;

            List<EmployeeListItem> employeeItems = employeesList.Select(emp => new EmployeeListItem
            {
                EmployeeId = emp.EmployeeId,
                FullName = emp.FullName
            }).ToList();

            EmployeesFilterCheckBoxList.DataSource = employeeItems;
            EmployeesFilterCheckBoxList.DisplayMember = "FullName";
            EmployeesFilterCheckBoxList.ValueMember = "EmployeeId";

            if (_dataService.getRole() != "admin") {
                EmployeesFilterCheckBoxList.Dispose();
                EmployeesFilterLabel.Dispose();
                filtersPanel.Controls.Remove(EmployeesFilterCheckBoxList);
                filtersPanel.Controls.Remove(EmployeesFilterLabel);
            }
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

        protected void OnRequestsUpdated(List<GetRequestDTO> requests)
        {
            UpdateRequestDataGridView(_dataService.getRequests());
        }

        protected void OnInvoicesUpdated(List<GetInvoiceDTO> requests)
        {
            UpdateInvoicessDataGridView();
        }

        protected void OnClientRelationshipsUpdated(List<GetClient_RequestRelashionshipDTO> clientRelationships)
        {
            UpdateClientsDataGridView();
        }

        protected void OnTasksUpdated(List<GetTaskDTO> tasks)
        {
            UpdateActivityDataGridView();
        }

        protected void OnActivitiesUpdated(List<GetActivityDTO> activities)
        {
            UpdateActivityDataGridView();
        }

        protected void OnActivityPlotRelationshipsUpdated(List<GetActivity_PlotRelashionshipDTO> activityPlotRelationships)
        {
            UpdateActivityDataGridView();
            UpdatePlotsDataGridView();
        }

        protected void OnDocumentPlotOwnerRelationshipsUpdated(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> documentPlotOwnerRelationships)
        {
            UpdateOwnershipDataGridView();
        }

        protected void OnActivityTypeUpdated(GetActivityTypeDTO activityType)
        {
            // Add your logic here if needed to handle activity type updates
        }

        protected void OnEmployeesUpdated(List<GetEmployeeDTO> employees)
        {
            // Add your logic here if needed to handle employee updates
        }

        protected void OnClientsUpdated(List<GetClientDTO> clients)
        {
            // Add your logic here if needed to handle client updates
        }
        protected async void OnUserLoggedIn(object sender, LogInEventArgs e)
        {
            if (_apiClient == null || _userClient == null || _adminClient == null || _dataService == null || _fileUploader == null)
            {
                return;
            }
            if (!loaded)
            {
                setRequestsDataGridView();
            }
        }

        protected void label1_Click(object sender, EventArgs e)
        {

        }

        protected void label1_Click_1(object sender, EventArgs e)
        {

        }

        protected void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected void label2_Click(object sender, EventArgs e)
        {

        }

        protected void label3_Click(object sender, EventArgs e)
        {

        }

        protected void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        protected void RequestDataGridView_SelectionChanged(object sender, EventArgs e)
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
        protected void UpdatePathLink()
        {
            PathLink.Text = _dataService.GetSelectedRequest().Path;
        }
        protected void clientsDataGridView_SelectionChanged(object sender, EventArgs e)
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

        protected void invoiceDataGridView_SelectionChanged(object sender, EventArgs e)
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

        protected void UpdateOwnershipDataGridView()
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

        protected void OwnershipDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        protected void PlotsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        protected void ActivityDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Define the indexes for the existing and new columns
            int activityColumnIndex = ActivityDataGridView.Columns["Activity"].Index;
            int parentActivityColumnIndex = ActivityDataGridView.Columns["ParentActivity"].Index;
            int plotsColumnIndex = ActivityDataGridView.Columns["Plots"].Index;
            int mainExecutantNameIndex = ActivityDataGridView.Columns["MainExecutantName"].Index;
            int mainExecutantPaymentIndex = ActivityDataGridView.Columns["MainExecutantPayment"].Index;
            int startDateIndex = ActivityDataGridView.Columns["StartDate"].Index;
            int activityEndDateIndex = ActivityDataGridView.Columns["ActivityEndDate"].Index;

            // Check if the current column is one of the columns we're interested in
            if (e.RowIndex < 0 ||
                (e.ColumnIndex != activityColumnIndex &&
                 e.ColumnIndex != parentActivityColumnIndex &&
                 e.ColumnIndex != plotsColumnIndex &&
                 e.ColumnIndex != mainExecutantNameIndex &&
                 e.ColumnIndex != mainExecutantPaymentIndex &&
                 e.ColumnIndex != startDateIndex &&
                 e.ColumnIndex != activityEndDateIndex))
                return;

            // Get the value of the current cell
            var cellValue = e.Value as string;

            // Define the key cell value from the 'Activity' column (common reference)
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



        protected string ConvertFloatToFraction(float value)
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
        protected List<OwnershipViewModel> GetOwnershipViewModels(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
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
                                NumberTypeOwner = $"{owner.OwnerID} {owner.FullName}",
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

        protected void BindOwnershipDataGridView(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
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

        protected void UpdateClientsDataGridView()
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

        protected void BindPlotDataGridView(RequestWithClientsDTO matchingRequestWithClients)
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
                            locality = plot.locality,
                            ActivityId = activityDTO.ActivityId,
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
        protected void BindClientsDataGridView(RequestWithClientsDTO matchingRequestWithClients)
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

        protected void UpdateInvoicessDataGridView()
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

        protected void BindInvoicesDataGridView(RequestWithClientsDTO matchingRequestWithClients)
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

        protected List<GetActivityDTO> ApplyActivityFilters(List<GetActivityDTO>? activityDTOs)
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
                        if (!(task.FinishDate >= startOfWeek && task.FinishDate < endOfWeek) && task.Status != "Зададена")
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
            if (overdueTasksFilter.Checked)
            {
                var activitiesToRemove = new List<GetActivityDTO>();
                DateTime today = DateTime.Today;

                foreach (var activity in filteredList)
                {
                    bool toRemove = true;
                    var tasksToRemove = new List<GetTaskDTO>();

                    foreach (var task in activity.Tasks)
                    {
                        // Check if the task is overdue
                        if (task.Status == "Зададена" && task.FinishDate < today)
                        {
                            toRemove = false; // Do not remove this activity if there is at least one overdue task
                        }
                        else
                        {
                            tasksToRemove.Add(task); // Mark task for removal if it's not overdue
                        }
                    }

                    // Remove the non-overdue tasks after iterating over them
                    foreach (var task in tasksToRemove)
                    {
                        activity.Tasks.Remove(task);
                    }

                    // If there are no tasks left in the activity, mark the activity for removal
                    if (activity.Tasks.Count == 0)
                    {
                        toRemove = true;
                    }

                    if (toRemove)
                    {
                        activitiesToRemove.Add(activity);
                    }
                }

                // Remove the activities that have no overdue tasks
                foreach (var activity in activitiesToRemove)
                {
                    filteredList.Remove(activity);
                }
            }


            return filteredList;
        }

        protected void BindActivityDataGridView(List<GetActivityDTO> activityDTOs)
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
                        StartDate = first ? activity.StartDate.ToString() : "",
                        Duration = task.Duration,
                        ControlFullName = task.Control?.FullName,
                        Comments = task.Comments,
                        Identities = first ? Identities : "",
                        ParentActivity = first ? activity.ParentActivity == null ? "" : activity.ParentActivity.ActivityTypeName : "",
                        tax = task.tax.ToString(),
                        taxComment = task.CommentTax,
                        Status = task.Status,
                        MainExecutantPayment = first ? activity.employeePayment.ToString() : "",
                        ActivityEndDate = first ? activity.ExpectedDuration.ToString() : "",
                        TaskEndDate = task.FinishDate,
                        TaskStartDate = task.StartDate,
                        TaskExecutantPayment = task.executantPayment.ToString(),
                        MainExecutantName = first ? activity.mainExecutant.FullName : ""
                    };

                    activityViewModels.Add(viewModel);
                    first = false;
                }
            }

            ActivityDataGridView.DataSource = activityViewModels;
            ActivityDataGridView.Refresh();
        }


        protected void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            using (AddRequestForm form = new AddRequestForm(_apiClient, _userClient, _adminClient, _dataService))
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

        protected void button2_Click(object sender, EventArgs e)
        {
            AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);
            addActivityTaskForm.Show();
            UpdateActivityDataGridView();
        }

        protected virtual void button3_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select a request");
            }

            AddInvoiceForm addInvoiceForm = new AddInvoiceForm(_apiClient, _adminClient, _userClient, _dataService);
            addInvoiceForm.Show();
            addInvoiceForm.Disposed += InvoiceForm_Disposed;
        }
        protected void InvoiceForm_Disposed(object sender, EventArgs e)
        {
            UpdateInvoicessDataGridView();
        }
        protected virtual void button1_Click_1(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }

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

        protected void UpdatePlotsDataGridView()
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

        protected void UpdateActivityDataGridView()
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
                else
                {
                    ActivityDataGridView.DataSource = null;
                    ActivityDataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateActivityDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateActivityDataGridView: " + ex.Message);
            }
        }


        protected async void RefreshButton_Click(object sender, EventArgs e)
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
        protected List<GetClientDTO> GetAllComboBoxClients(Panel parentPanel)
        {
            List<GetClientDTO> comboBoxClients = new List<GetClientDTO>();
            foreach (Panel panel in parentPanel.Controls.OfType<Panel>()) // Assuming 'parentPanel' is your main container panel
            {
                foreach (AddClientFromAvailable userControl in panel.Controls.OfType<AddClientFromAvailable>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is ComboBox)
                        {
                            ComboBox comboBox = control as ComboBox;
                            if (comboBox.SelectedItem != null)
                            {
                                // Assuming the value is the object itself or perhaps the Tag property is used
                                GetClientDTO item = comboBox.SelectedItem as GetClientDTO;
                                comboBoxClients.Add(item);
                            }
                        }
                    }

                }
            }
            return comboBoxClients;
        }
        protected List<GetOwnerDTO> GetAllComboBoxOwners(Panel parentPanel)
        {
            List<GetOwnerDTO> comboBoxClients = new List<GetOwnerDTO>();
            foreach (Panel panel in parentPanel.Controls.OfType<Panel>()) // Assuming 'parentPanel' is your main container panel
            {
                foreach (AddOwnerFromAvailable userControl in panel.Controls.OfType<AddOwnerFromAvailable>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is ComboBox)
                        {
                            ComboBox comboBox = control as ComboBox;
                            if (comboBox.SelectedItem != null)
                            {
                                // Assuming the value is the object itself or perhaps the Tag property is used
                                GetOwnerDTO item = comboBox.SelectedItem as GetOwnerDTO;
                                comboBoxClients.Add(item);
                            }
                        }
                    }

                }
            }
            return comboBoxClients;
        }
        protected List<GetEmployeeDTO> GetSelectedEmployees(List<GetEmployeeDTO> allEmployees)
        {
            List<GetEmployeeDTO> selectedEmployees = new List<GetEmployeeDTO>();

            foreach (var item in EmployeesFilterCheckBoxList.CheckedItems)
            {
                if (item is EmployeeListItem employeeItem)
                {
                    GetEmployeeDTO selectedEmployee = allEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeItem.EmployeeId);
                    if (selectedEmployee != null)
                    {
                        selectedEmployees.Add(selectedEmployee);
                    }
                }
            }

            return selectedEmployees;
        }
        protected virtual List<GetRequestDTO> ApplyFilters(List<GetRequestDTO>? requestDTOs)
        {
            if (requestDTOs == null || requestDTOs.Count() == 0) return requestDTOs;

            var filteredList = requestDTOs;


            List<GetClientDTO> filterClients = GetAllComboBoxClients(clientsFlowLayoutPanel);
            List<GetOwnerDTO> filterOwners = GetAllComboBoxOwners(OwnersFlowLayoutPanelFilter);

            if (filterClients != null && filterClients.Count > 0)
            {
                filteredList = _dataService.filterRequestsByClients(filteredList, filterClients);
            }

            if (filterOwners != null && filterOwners.Count > 0)
            {
                filteredList = _dataService.filterRequestsByOwner(filteredList, filterOwners);
            }

            if (!string.IsNullOrEmpty(txtNumber.Text) && int.TryParse(txtNumber.Text, out int requestId))
            {
                filteredList = filteredList.Where(r => r.RequestId == requestId).ToList();
            }

            if (!string.IsNullOrEmpty(plotNumberTextBox.Text))
            {
                filteredList = _dataService.filterRequestByPlotId(filteredList, plotNumberTextBox.Text);
            }

            if (!string.IsNullOrEmpty(UPITextBox.Text))
            {
                filteredList = _dataService.filterRequestByPlotUPI(filteredList, UPITextBox.Text);
            }

            if (!string.IsNullOrEmpty(CityTextBox.Text))
            {
                filteredList = _dataService.filterRequestByPlotCity(filteredList, CityTextBox.Text);
            }

            if (!string.IsNullOrEmpty(neighborhoodTextBox.Text))
            {
                filteredList = _dataService.filterRequestByPlotNeighborhood(filteredList, neighborhoodTextBox.Text);
            }

            if (!string.IsNullOrEmpty(CommentsTextBox.Text))
            {
                filteredList = _dataService.filterRequestsByComments(filteredList, CommentsTextBox.Text);
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

            if (overdueFilter.Checked)
            {
                filteredList = _dataService.FilterRequestByOverdueActivitiesAndTasks(filteredList);
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

            if (_dataService.getRole() != "admin")
            {
                return filteredList;
            }

            List<GetEmployeeDTO> selectedEmployees = GetSelectedEmployees(_allEmployees); // Assuming you have a method to get selected employees
            if (selectedEmployees != null && selectedEmployees.Count > 0 )
            {
                filteredList = _dataService.FilterRequestsByEmployeesActivitiesAndTasks(filteredList, selectedEmployees);
            }

            return filteredList;
        }

        public virtual void UpdateRequestDataGridView(List<GetRequestDTO> requestDTOs)
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

        protected void RestoreSelectedRow(int? previousSelectedRequestId)
        {
            _isRefreshing = false;
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

        protected int FindRowIndexByRequestId(int requestId)
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

        protected virtual void UpdateRequestGridViewRows(List<GetRequestDTO> filteredList)
        {

            RequestDataGridView.AutoGenerateColumns = false;
            RequestDataGridView.DataSource = null; // Force reset DataSource

            List<GetRequestDTO> fliteredListNew = new List<GetRequestDTO>();

            foreach (var request in filteredList)
            {
                GetRequestDTO tempRequest = new GetRequestDTO();
                tempRequest.RequestId = request.RequestId;
                tempRequest.RequestName = request.RequestName;
                tempRequest.Price = request.Price;
                tempRequest.Advance = request.Advance;
                tempRequest.PaymentStatus = request.PaymentStatus;
                tempRequest.Comments = request.Comments;
                tempRequest.Path = request.Path;

                List<GetPlotDTO> plots = _dataService.getLinkedPlotsToRequest(request);
                foreach (var plot in plots)
                {
                    tempRequest.PlotsInfo += $"Поземлен имот:{plot.PlotNumber}, {plot.City}, Упи: {plot.RegulatedPlotNumber}, кв: {plot.neighborhood};";
                }
                fliteredListNew.Add(tempRequest);
            }
            RequestDataGridView.DataSource = fliteredListNew;


            RequestDataGridView.Refresh();
            _isRefreshing = false;
            if (filteredList != null && filteredList.Count() < 2)
            {
                RequestDataGridView_SelectionChanged(new object { }, new EventArgs());
            }

            // Fetch the starred requests
            var starredRequests = _dataService.GetStarredRequests();

            // Paint the rows that match the requestId in starred requests
            foreach (DataGridViewRow row in RequestDataGridView.Rows)
            {
                var requestDTO = row.DataBoundItem as GetRequestDTO;

                if (requestDTO != null)
                {
                    // Find the corresponding starred request
                    var starredRequest = starredRequests.FirstOrDefault(s => s.RequestId == requestDTO.RequestId);

                    if (starredRequest != null)
                    {
                        // Convert the stored color string to a System.Drawing.Color
                        System.Drawing.Color starColor = System.Drawing.ColorTranslator.FromHtml(starredRequest.StarColor);

                        // Set the row background color to the star color
                        row.DefaultCellStyle.BackColor = starColor;
                    }
                    else
                    {
                        // Set the row background color to the default color if not starred
                        row.DefaultCellStyle.BackColor = RequestDataGridView.DefaultCellStyle.BackColor;
                    }
                }
            }
        }

        protected virtual void ActivityAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }

            if (_dataService.GetSelectedRequest() != null)
            {
                AddActivityTaskForm addActivityTaskForm = new AddActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);

                // Subscribe to the FormClosed event
                addActivityTaskForm.Disposed += AddActivityTaskForm_Disposed;

                addActivityTaskForm.Show();
            }
        }

        protected void AddActivityTaskForm_Disposed(object sender, EventArgs e)
        {
            var selectedRequest = _dataService.GetSelectedRequest();
            // Invoke the method to update the DataGridView
            UpdateActivityDataGridView();
        }

        protected void PlotsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected void InvoicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected virtual void PlotsAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }


            AddPlotToObject plotForm = new AddPlotToObject(_apiClient, _userClient, _adminClient, _dataService);
            plotForm.Show();
            plotForm.Disposed += PlotFormDispose;
        }
        protected void PlotFormDispose(object sender, EventArgs e)
        {
            UpdatePlotsDataGridView();
            UpdateActivityDataGridView();
            UpdateOwnershipDataGridView();
        }
        protected void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        protected virtual void AddOwnersButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }


            AddOwnerForm ownerForm = new AddOwnerForm(_apiClient, _userClient, _adminClient, _dataService);
            ownerForm.Show();
            ownerForm.Disposed += OwnershipFormDispose;
        }
        protected void OwnershipFormDispose(object sender, EventArgs e)
        {
            UpdateOwnershipDataGridView();
        }
        protected virtual async void DeleteRequestButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please Select A Request");
                return;
            }
            DialogResult result = MessageBox.Show("Искате ли да изтриете поръчката?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
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

        protected virtual async void deleteClientsButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }
            if (!(_dataService.getSelectedCLients() != null && _dataService.getSelectedCLients().Count() > 0))
            {
                MessageBox.Show("Please select a client");
                return;
            }

            DialogResult result = MessageBox.Show("Искате ли да изтриете клиента от поръчката?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

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

        protected virtual async void DeleteActivityButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }

            if (!(_dataService.getTasksFromViewModel() != null && _dataService.getTasksFromViewModel().Count() > 0))
            {
                MessageBox.Show("Please select an task");
                return;
            }

            DialogResult result = MessageBox.Show("Искате ли да изтриете задачата?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

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

        protected void CreateDocumentButton_Click(object sender, EventArgs e)
        {
            CreateDocument createDocumentForm = new CreateDocument(_dataService, _fileUploader);
            createDocumentForm.Show();
        }

        protected void ActivityDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected void ActivityDataGridView_SelectionChanged(object sender, EventArgs e)
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

        protected void PlotsDataGridView_SelectionChanged(object sender, EventArgs e)
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

        protected void OwnershipDataGridView_SelectionChanged(object sender, EventArgs e)
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

        protected virtual async void DeletePlotsButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }

            if (!(_dataService.getSelectedPlotsOnRequestMenu() != null && _dataService.getSelectedPlotsOnRequestMenu().Count > 0))
            {
                MessageBox.Show("Please select plots");
                return;
            }

            DialogResult result = MessageBox.Show("Искате ли да изтриете имота/имотите от дейността?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

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

            List<GetActivity_PlotRelashionshipDTO> relashionshipDTOs = new List<GetActivity_PlotRelashionshipDTO>();
            foreach (var viewModel in viewModels)
            {
                GetActivity_PlotRelashionshipDTO relashionshipDTO = new GetActivity_PlotRelashionshipDTO()
                {
                    ActivityId = viewModel.ActivityId,
                    PlotId = viewModel.PlotId
                };
                relashionshipDTOs.Add(relashionshipDTO);
            }

            var response = await _userClient.activityPlotRelashionshipRemove(relashionshipDTOs);
            if (response.IsSuccess)
            {
                _dataService.removeActivityPlotRelashionships(relashionshipDTOs);
                UpdatePlotsDataGridView();
                UpdateOwnershipDataGridView();
                UpdateActivityDataGridView();
            }

        }

        protected virtual async void DeleteOwnershipButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }
            if (!(_dataService.GetSelectedOwnershipViewModelsRequestMenu() != null && _dataService.GetSelectedOwnershipViewModelsRequestMenu().Count() > 0))
            {
                MessageBox.Show("Please select Ownerships");
                return;
            }

            DialogResult resultConfirm = MessageBox.Show("Искате ли да изтриете собствеността?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultConfirm == DialogResult.No)
            {
                return;
            }

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

        protected virtual void editRequestButton_Click(object sender, EventArgs e)
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

        protected void EditRequestFormDispose(object sender, EventArgs e)
        {
            UpdateRequestDataGridView(_dataService.getRequests());
        }

        protected virtual void editClientButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }

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

        protected void EditClientFormDispose(object sender, EventArgs e)
        {
            UpdateClientsDataGridView();
        }

        protected virtual void editActivityButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }
            if (!(_dataService.getTasksFromViewModel() != null && _dataService.getTasksFromViewModel().Count() > 0))
            {
                MessageBox.Show("Please select an task");
                return;
            }

            EditActivityTaskForm editActivityTaskForm = new EditActivityTaskForm(_apiClient, _userClient, _adminClient, _dataService);
            editActivityTaskForm.Show();
            editActivityTaskForm.Disposed += EditActivityFormDispose;
        }
        protected void EditActivityFormDispose(object sender, EventArgs e)
        {
            UpdateActivityDataGridView();
        }

        protected void button4_Click(object sender, EventArgs e)
        {

        }

        protected virtual void editPlotButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }

            if (!(_dataService.getSelectedPlotsOnRequestMenu() != null && _dataService.getSelectedPlotsOnRequestMenu().Count > 0))
            {
                MessageBox.Show("Please select plots");
                return;
            }

            EditPlot editPlot = new EditPlot(_apiClient, _userClient, _adminClient, _dataService);
            editPlot.Show();
            editPlot.Disposed += EditPlotFormDispose;
        }

        protected void EditPlotFormDispose(object sender, EventArgs e)
        {
            UpdateActivityDataGridView();
            UpdatePlotsDataGridView();
            UpdateOwnershipDataGridView();
        }

        protected virtual void editOwnershipButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select an request");
                return;
            }
            if (!(_dataService.GetSelectedOwnershipViewModelsRequestMenu() != null && _dataService.GetSelectedOwnershipViewModelsRequestMenu().Count() > 0))
            {
                MessageBox.Show("Please select Ownerships");
                return;
            }


            EditOwnerForm editOwnerForm = new EditOwnerForm(_apiClient, _userClient, _adminClient, _dataService);
            editOwnerForm.Show();
            editOwnerForm.Disposed += EditOwnershipFormDispose;
        }
        protected void EditOwnershipFormDispose(object sender, EventArgs e)
        {
            UpdateOwnershipDataGridView();
        }

        protected void NavigateDataGridView(DataGridView dgv, string direction)
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


        protected void ApplyActivityFiltersButton_Click(object sender, EventArgs e)
        {
            UpdateActivityDataGridView();
        }

        protected void label7_Click(object sender, EventArgs e)
        {

        }

        protected async void starRequestButton_Click(object sender, EventArgs e)
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
                    StarColor = System.Drawing.ColorTranslator.ToHtml(_dataService.getCurrentStarColor()) // Convert Color to hex string
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

        protected void PathLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        protected virtual void EditInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select a request");
            }
            if (_dataService.getSelectedInvoices().Count == 0 || _dataService.getSelectedInvoices() == null)
            {
                MessageBox.Show("Please select invoices");
                return;
            }
            EditInvoiceForm editInvoiceForm = new EditInvoiceForm(_apiClient, _adminClient, _userClient, _dataService);
            editInvoiceForm.Show();
            editInvoiceForm.Disposed += InvoiceForm_Disposed;
        }

        protected virtual async void DeleteInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() == null)
            {
                MessageBox.Show("Please select a request");
            }

            if (_dataService.getSelectedInvoices().Count == 0 || _dataService.getSelectedInvoices() == null)
            {
                MessageBox.Show("Please select invoices");
                return;
            }

            DialogResult result = MessageBox.Show("Искате ли да изтриете фактурата?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            await _userClient.DeleteInvoices(_dataService.getSelectedInvoices());
            _dataService.DeleteInvoices(_dataService.getSelectedInvoices());
            UpdateInvoicessDataGridView();
        }

        protected void tabPage3_Click(object sender, EventArgs e)
        {

        }

        protected void statusCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RequestFiltersApplyButton_Click_1(object sender, EventArgs e)
        {
            if (_filterState)
            {
                _filterState = false;
                UpdateRequestDataGridView(_dataService.getRequests());
                filtersPanel.Visible = false;
            }
            else
            {
                _filterState = true;
                filtersPanel.Visible = true;
            }
        }

        protected void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragOffset = e.Location; // Store mouse position relative to panel
            }
        }

        protected void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate new location for the panel based on the mouse movement
                Point newLocation = new Point(
                    e.X + filtersPanel.Left - dragOffset.X,
                    e.Y + filtersPanel.Top - dragOffset.Y);

                filtersPanel.Location = newLocation;

                // Invalidate the form to prevent dragging artifacts
                this.Invalidate(); // Or, this.Invalidate(new Rectangle(newLocation, draggablePanel.Size));
            }
        }

        protected void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        protected void AddClientButton_Click(object sender, EventArgs e)
        {
            AddNewPanelWithUserControlAddClientsFromAvailable();
        }

        protected async void AddNewPanelWithUserControlAddClientsFromAvailable()
        {
            var responseClients = await _userClient.GetAllClients();
            List<GetClientDTO> clientDTOs = responseClients.ResponseObj.ToList();
            _dataService.SetAllClients(clientDTOs);

            Panel panel = new Panel();
            panel.Size = new Size(412, 28);
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromAvailable userControl = new AddClientFromAvailable(_apiClient, _userClient, _adminClient, clientDTOs, panel);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            clientsFlowLayoutPanel.Controls.Add(panel);
        }

        protected void button2_Click_1(object sender, EventArgs e)
        {
            AddNewPanelWithUserControlAddOwnersFromAvailable();
        }

        protected async void AddNewPanelWithUserControlAddOwnersFromAvailable()
        {
            var ownersResponse = await _userClient.GetAllOwners();
            List<GetOwnerDTO> owners = ownersResponse.ResponseObj;

            Panel panel = new Panel();
            panel.Size = new Size(412, 28);
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddOwnerFromAvailable userControl = new AddOwnerFromAvailable(_apiClient, _userClient, _adminClient, owners, panel);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            OwnersFlowLayoutPanelFilter.Controls.Add(panel);
        }

        protected void PopulateUsedColorsMenu()
        {

            // Assume you have a list of used colors, for example:
            List<Color> usedColors = _dataService.getStaredColorsDistc(); // This should be your method to retrieve used colors.

            // Clear any existing items in the submenu
            AvailableColors.DropDownItems.Clear();

            // Add each color to the menu
            foreach (var color in usedColors)
            {
                ToolStripMenuItem colorItem = new ToolStripMenuItem();
                colorItem.Text = color.Name; // Or set this to some identifier for the color
                colorItem.BackColor = color; // Set the background to the color
                colorItem.Click += (sender, e) => { starRequestButton.BackColor = color; _dataService.setCurrentStarColor(color); }; // Change star color when clicked
                AvailableColors.DropDownItems.Add(colorItem);
            }
        }

        protected void ChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Optionally, set the current color of the star button as the initial color
                colorDialog.Color = starRequestButton.BackColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Change the star button's background color
                    starRequestButton.BackColor = colorDialog.Color;

                    // Optionally save the selected color to your used colors list

                    _dataService.setCurrentStarColor(colorDialog.Color);
                }
            }
        }

        protected void starRequestButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Populate the "Налични цветове" menu with the current colors
                PopulateUsedColorsMenu();

                // Show the context menu at the current mouse position
                StarContextMenuStrip.Show(Cursor.Position);
            }
        }

        
    }
}
