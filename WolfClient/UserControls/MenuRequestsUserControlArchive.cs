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

            List<GetRequestDTO> filteredListNew = new List<GetRequestDTO>();

            foreach (var request in filteredList)
            {
                GetRequestDTO tempRequest = new GetRequestDTO
                {
                    RequestId = request.RequestId,
                    RequestName = request.RequestName,
                    Price = request.Price,
                    Advance = request.Advance,
                    PaymentStatus = request.PaymentStatus,
                    Comments = request.Comments,
                    Path = request.Path,
                    Status = request.Status,
                };

                List<GetPlotDTO> plots = _dataService.getLinkedPlotsToRequest(request);
                foreach (var plot in plots)
                {
                    tempRequest.PlotsInfo += $"Поземлен имот:{plot.PlotNumber}, {plot.City}, Упи: {plot.RegulatedPlotNumber}, кв: {plot.neighborhood};";
                }
                filteredListNew.Add(tempRequest);
            }
            RequestDataGridView.DataSource = filteredListNew;

            RequestDataGridView.Refresh();
            _isRefreshing = false;
            if (filteredList != null && filteredList.Count < 2)
            {
                RequestDataGridView_SelectionChanged(new object { }, new EventArgs());
            }

            string projectRootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            // Load icons
            Image activeIcon = Image.FromFile(Path.Combine( "Properties", "icons", "active.ico"));
            Image inactiveIcon = Image.FromFile(Path.Combine("Properties", "icons", "cross.ico"));

            // Paint the rows based on their status and star condition
            foreach (DataGridViewRow row in RequestDataGridView.Rows)
            {
                var requestDTO = row.DataBoundItem as GetRequestDTO;

                if (requestDTO != null)
                {
                    if (requestDTO.Status == "Archived")
                    {
                        row.Cells["StatusIcon"].Value = inactiveIcon;
                    }
                    else
                    {
                        row.Cells["StatusIcon"].Value = activeIcon;
                    }

                    // Handle star color
                    var starredRequest = _dataService.GetStarredRequests()
                        .FirstOrDefault(s => s.RequestId == requestDTO.RequestId);

                    if (starredRequest != null)
                    {
                        System.Drawing.Color starColor = System.Drawing.ColorTranslator.FromHtml(starredRequest.StarColor);
                        row.DefaultCellStyle.BackColor = starColor;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = RequestDataGridView.DefaultCellStyle.BackColor;
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
