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
using WolfClient.NewForms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class MenuRequestsUserControlArchive : MenuRequestsUserControlBase
    {
        public MenuRequestsUserControlArchive(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService, IFileUploader fileUploader)
        : base(apiClient, userClient, adminClient, dataService, fileUploader) // Pass parameters to the base class constructor
        {
            InitializeComponent();
            DataGridViewImageColumn statusIconColumn = new DataGridViewImageColumn();
            statusIconColumn.Name = "StatusIcon";
            statusIconColumn.HeaderText = "Status";
            statusIconColumn.Width = 50; // Adjust width as needed

            // Insert the column at the first position (index 0)
            RequestDataGridView.Columns.Insert(0, statusIconColumn);
            RequestDataGridView.MouseDown += RequestDataGridView_MouseDown;
            RequestDataGridView.CellBeginEdit += RequestDataGridView_CellBeginEdit;
        }
        private void RequestDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
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
        public override void OnControlFPressed()
        {
            this.RequestFiltersApplyButton_Click_1(new object(), new EventArgs());
        }
        public override void OnF5Pressed()
        {
            // Implement the behavior specific to Active Requests
            this.RefreshButton_Click(new object(), new EventArgs());
            // Add your custom logic here
        }
        public override void OnShiftF1Pressed()
        {
            this.button1_Click(new object(), new EventArgs());
        }
        public override void OnF1Pressed()
        {
            int tab = GetSelectedTabIndex();

            if (tab == 0)
            {
                this.button1_Click_1(new object(), new EventArgs());
            }
            if (tab == 1)
            {
                this.ActivityAddButton_Click(new object(), new EventArgs());
            }
            if (tab == 2)
            {
                this.PlotsAddButton_Click(new object(), new EventArgs());
            }
            if (tab == 3)
            {
                this.AddOwnersButton_Click(new object(), new EventArgs());
            }
            if (tab == 4)
            {
                this.button3_Click(new object(), new EventArgs());
            }
            // Custom logic for Archived Requests
        }
        public override void OnShiftF2Pressed()
        {
            this.editRequestButton_Click(new object(), new EventArgs());
            // Custom logic for Archived Requests
        }
        public override void OnF2Pressed()
        {
            int tab = GetSelectedTabIndex();

            if (tab == 0)
            {
                this.editClientButton_Click(new object(), new EventArgs());
            }
            if (tab == 1)
            {
                this.editActivityButton_Click(new object(), new EventArgs());
            }
            if (tab == 2)
            {
                this.editPlotButton_Click(new object(), new EventArgs());
            }
            if (tab == 3)
            {
                this.editOwnershipButton_Click(new object(), new EventArgs());
            }
            if (tab == 4)
            {
                this.EditInvoiceButton_Click(new object(), new EventArgs());
            }
        }
        protected override void editRequestButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() != null)
            {
                EditRequestFormArchive editRequestForm = new EditRequestFormArchive(_apiClient, _userClient, _adminClient, _dataService);
                editRequestForm.Show();
                editRequestForm.Disposed += EditRequestFormDispose;
            }
            else
            {
                MessageBox.Show("Please Select A request");
            }
        }



        protected override void UpdateRequestGridViewRows(List<GetRequestDTO> filteredList)
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

            RequestDataGridView.CellPainting -= RequestDataGridView_CellPainting; // Remove existing handler if any
            RequestDataGridView.CellPainting += RequestDataGridView_CellPainting;
        }




        private void RequestDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void RequestDataGridView_MouseDown(object sender, MouseEventArgs e)
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
                        foreach (var line in lines)
                        {
                            float currentX = cellRect.Left + 2;
                            string[] words = line.Split(' ');

                            foreach (var word in words)
                            {
                                bool isHyperlink = Uri.IsWellFormedUriString(word, UriKind.Absolute);

                                // Only consider the word if it's a hyperlink
                                if (isHyperlink)
                                {
                                    // Measure the size of the word
                                    SizeF wordSize = g.MeasureString(word + " ", RequestDataGridView.Font);

                                    // Check if the click is within the bounds of this word
                                    RectangleF wordRect = new RectangleF(currentX, currentY, wordSize.Width, wordSize.Height);
                                    if (wordRect.Contains(e.Location))
                                    {
                                        // Open the link in the default web browser
                                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                        {
                                            FileName = word,
                                            UseShellExecute = true // This ensures the URL opens in the default browser
                                        });
                                        return; // Exit after opening the link
                                    }

                                    // Move the starting point to the next word's position
                                    currentX += wordSize.Width;
                                }
                                else
                                {
                                    // Even if it's not a hyperlink, move to the next word's position
                                    SizeF wordSize = g.MeasureString(word + " ", RequestDataGridView.Font);
                                    currentX += wordSize.Width;
                                }
                            }

                            // Move to the next line
                            currentY += RequestDataGridView.Font.Height;
                        }
                    }
                }
            }
        }

        protected override async void DeleteRequestButton_Click(object sender, EventArgs e)
        {
            // Check if the role is "user"
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete requests.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // If the role is not "user", execute the base method
                base.DeleteRequestButton_Click(sender, e);
            }
        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            // Check if the role is "user"
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add a new request.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // If the role is not "user", execute the base method
                base.button1_Click(sender, e);
            }
        }
        protected override void button1_Click_1(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add a client to the request.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.button1_Click_1(sender, e);
            }
        }
        protected override async void deleteClientsButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete clients from the request.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.deleteClientsButton_Click(sender, e);
            }
        }
        protected override void editClientButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit clients.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.editClientButton_Click(sender, e);
            }
        }
        protected override void ActivityAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add activities.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.ActivityAddButton_Click(sender, e);
            }
        }
        protected override async void DeleteActivityButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete activities.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.DeleteActivityButton_Click(sender, e);
            }
        }

        protected override void editActivityButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit activities.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.editActivityButton_Click(sender, e);
            }
        }

        protected override void PlotsAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add plots.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.PlotsAddButton_Click(sender, e);
            }
        }

        protected override async void DeletePlotsButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete plots.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.DeletePlotsButton_Click(sender, e);
            }
        }

        protected override void editPlotButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit plots.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.editPlotButton_Click(sender, e);
            }
        }
        protected override void AddOwnersButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add owners.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.AddOwnersButton_Click(sender, e);
            }
        }
        protected override async void DeleteOwnershipButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete ownerships.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.DeleteOwnershipButton_Click(sender, e);
        }

        protected override void editOwnershipButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit ownerships.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.editOwnershipButton_Click(sender, e);
        }

        protected override void button3_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add invoices.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.button3_Click(sender, e);
        }

        protected override async void DeleteInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete invoices.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.DeleteInvoiceButton_Click(sender, e);
        }

        protected override void EditInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit invoices.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.EditInvoiceButton_Click(sender, e);
        }

        protected override List<GetRequestDTO> ApplyFilters(List<GetRequestDTO>? requestDTOs)
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
            
            if (ArchiveStatusComboBox.Text == "Активни") {
                filteredList = filteredList.Where(r => r.Status == "Active").ToList();
            }
            else if(ArchiveStatusComboBox.Text == "Архивни")
            {
                filteredList = filteredList.Where(r => r.Status == "Archived").ToList();
            }

            if (_dataService.getRole() != "admin")
            {
                return filteredList;
            }

            List<GetEmployeeDTO> selectedEmployees = GetSelectedEmployees(_allEmployees); // Assuming you have a method to get selected employees
            if (selectedEmployees != null && selectedEmployees.Count > 0)
            {
                filteredList = _dataService.FilterRequestsByEmployeesActivitiesAndTasks(filteredList, selectedEmployees);
            }

            return filteredList;
        }


    }
}
