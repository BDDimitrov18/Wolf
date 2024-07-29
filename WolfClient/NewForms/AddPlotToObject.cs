using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services;
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class AddPlotToObject : Form
    {
        private readonly IDataService _dataService;
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;

        private CreatePlotDTO plotValidator;
        List<GetPlotDTO> allPlots;

        private int initial = 0;
      
        public AddPlotToObject(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            allPlots = new List<GetPlotDTO>();
            plotValidator = new CreatePlotDTO();
        }

        private void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {
                // Clear previous error messages
                errorProvider.Clear();

                // Bind the form controls to the model properties
                plotValidator.PlotNumber = PlotNumberComboBox.Text;

              
                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(plotValidator);

                if (memberNameResults.Any())
                {
                    foreach (var result in memberNameResults)
                    {
                        foreach (var memberName in result.MemberNames)
                        {
                            // Map property names to control names
                            string controlName = GetControlNameForMember(memberName);
                            if (controlName != null)
                            {
                                Control control = Controls.Find(controlName, true).FirstOrDefault();
                                if (control != null)
                                {
                                    errorProvider.SetError(control, result.ErrorMessage);
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Clear all error messages if validation passes
                    foreach (Control control in Controls)
                    {
                        errorProvider.SetError(control, string.Empty);
                    }
                }
            }
            finally
            {
                // Re-enable redrawing
                ResumeLayout();
            }
        }

        private string GetControlNameForMember(string memberName)
        {
            return memberName switch
            {
                nameof(plotValidator.PlotNumber) => "PlotNumberComboBox",
                _ => null
            };
        }

        private async void AddPlotToObject_Load(object sender, EventArgs e)
        {
            var allPlotsResponse  = await _userClient.GetAllPlots();
            allPlots = allPlotsResponse.ResponseObj;
            var selected = _dataService.GetSelectedRequest();
            var linkedRequests = _dataService.GetFetchedLinkedRequests();
            List<GetActivityDTO> activityDTOs = new List<GetActivityDTO>();
            foreach (var linkedRequest in linkedRequests)
            {
                if (selected.RequestId == linkedRequest.requestDTO.RequestId)
                {
                    activityDTOs = linkedRequest.activityDTOs;
                }
            }

            ActivityComboBox.DataSource = activityDTOs;
            ActivityComboBox.DisplayMember = "ActivityTypeName";
            ActivityComboBox.ValueMember = "ActivityId";

            PlotNumberComboBox.DataSource = allPlots;
            PlotNumberComboBox.DisplayMember = "PlotNumber";
            PlotNumberComboBox.ValueMember = "PlotId";
            PlotNumberComboBox.Text = "";
        }


        private void PlotNumberComboBox_TextChanged(object sender, EventArgs e)
        {
            if (initial <2) 
            { 
                initial++; 
                return; 
            }
            string selectedPlotNumber = PlotNumberComboBox.Text;

            // Temporarily remove the event handler to prevent it from firing while updating the items
            PlotNumberComboBox.TextChanged -= PlotNumberComboBox_TextChanged;

            // Filter the list based on the text input or show all items if the text is empty
            List<GetPlotDTO> filteredPlots;
            if (string.IsNullOrWhiteSpace(selectedPlotNumber))
            {
                // If the text is empty, display all plots
                filteredPlots =allPlots;
            }
            else
            {
                // Get the list of plots and filter based on the text input
                filteredPlots = allPlots
                    .Where(plot => plot.PlotNumber.IndexOf(selectedPlotNumber, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(plot => plot.PlotNumber)
                    .ToList();
            }

            // Update the ComboBox DataSource
            PlotNumberComboBox.DataSource = filteredPlots;
            PlotNumberComboBox.DisplayMember = "PlotNumber";
            PlotNumberComboBox.ValueMember = "PlotId";

            // Restore the user's text and keep the ComboBox open
            PlotNumberComboBox.Text = selectedPlotNumber;
            PlotNumberComboBox.SelectionStart = selectedPlotNumber.Length;
            PlotNumberComboBox.DroppedDown = true;

            // Reattach the event handler
            PlotNumberComboBox.TextChanged += PlotNumberComboBox_TextChanged;

            // Execute the existing logic for handling plot selection
            if (!string.IsNullOrEmpty(selectedPlotNumber))
            {
                var selectedPlot = filteredPlots.FirstOrDefault(x => x.PlotNumber.Equals(selectedPlotNumber, StringComparison.OrdinalIgnoreCase));
                if (selectedPlot != null)
                {
                    CityTextBox.Text = selectedPlot.City;
                    MunicipalityTextBox.Text = selectedPlot.Municipality;
                    LocalityTextBox.Text = selectedPlot.locality;
                    DesignationComboBox.Text = selectedPlot.designation ?? "";
                    RegulatedNumberTextBox.Text = selectedPlot.RegulatedPlotNumber ?? "";
                    NeighborhoodTextBox.Text = selectedPlot.neighborhood ?? "";
                    StreetTextBox.Text = selectedPlot.Street ?? "";
                    StreetNumberTextBox.Text = selectedPlot.StreetNumber?.ToString() ?? "";
                    CityTextBox.Enabled = false;
                    MunicipalityTextBox.Enabled = false;
                    LocalityTextBox.Enabled = false;
                    DesignationComboBox.Enabled = false;
                    RegulatedNumberTextBox.Enabled = false;
                    NeighborhoodTextBox.Enabled = false;
                    StreetTextBox.Enabled = false;
                    StreetNumberTextBox.Enabled = false;
                }
                else
                {
                    CityTextBox.Enabled = true;
                    MunicipalityTextBox.Enabled = true;
                    LocalityTextBox.Enabled = true;
                    DesignationComboBox.Enabled = true;
                    RegulatedNumberTextBox.Enabled = true;
                    NeighborhoodTextBox.Enabled = true;
                    StreetTextBox.Enabled = true;
                    StreetNumberTextBox.Enabled = true;
                    var selectedEKT = _dataService.GetEKTViewModels().FirstOrDefault(x => x.EKTNumber == selectedPlotNumber);

                    if (selectedEKT != null)
                    {
                        CityTextBox.Text = $"{selectedEKT.TypeOfPlace} {selectedEKT.TownName}";
                        LocalityTextBox.Text = selectedEKT.Localitiy;
                        MunicipalityTextBox.Text = selectedEKT.Municipality;
                        CityTextBox.Enabled = false;
                        LocalityTextBox.Enabled = false;
                        MunicipalityTextBox.Enabled = false;
                    }
                }
            }
        }


        private async void AddPlotToObjectSubmitButton_Click(object sender, EventArgs e)
        {
            ValidateModel();

            plotNumberValidationLabel.ForeColor = SystemColors.GradientActiveCaption;
            bool flag = false;
            if (!string.IsNullOrEmpty(errorProvider.GetError(PlotNumberComboBox)))
            {
                plotNumberValidationLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (flag) return;
            CreatePlotDTO newPlot = new CreatePlotDTO() {
                PlotNumber = PlotNumberComboBox.Text,
                RegulatedPlotNumber = RegulatedNumberTextBox.Text,
                neighborhood = NeighborhoodTextBox.Text,
                City = CityTextBox.Text,
                Municipality = MunicipalityTextBox.Text,
                Street = StreetTextBox.Text,
                StreetNumber = int.Parse(StreetNumberTextBox.Text),
                designation = DesignationComboBox.Text,
                locality = LocalityTextBox.Text,
            };
            if (_dataService.ActivityPlotExists(PlotNumberComboBox.Text, ActivityComboBox.SelectedItem as GetActivityDTO)) {
                MessageBox.Show($"Имот с номер {PlotNumberComboBox.Text} вече е добавен към {ActivityComboBox.Text}");
                return;
            }

            var plotResponse = await _userClient.AddPlot(newPlot);

            CreateActivity_PlotRelashionshipDTO relashionshipDTO = new CreateActivity_PlotRelashionshipDTO()
            {
                Activity = ActivityComboBox.SelectedItem as GetActivityDTO,
                Plot = plotResponse.ResponseObj,
            };
            relashionshipDTO.Activity.Request = _dataService.GetSelectedRequest();
            List<CreateActivity_PlotRelashionshipDTO> createActivity_PlotRelashionshipDTOs = new List<CreateActivity_PlotRelashionshipDTO>();
            createActivity_PlotRelashionshipDTOs.Add(relashionshipDTO);

            await _userClient.AddActivity_PlotRelashionship(createActivity_PlotRelashionshipDTOs);

            var fetchedLinkes = _dataService.GetFetchedLinkedRequests();
            var selectedRequest = _dataService.GetSelectedRequest();
            foreach (var fetch in fetchedLinkes) {
                if (fetch.requestDTO.RequestId == selectedRequest.RequestId) { 
                    foreach(var activity in fetch.activityDTOs) { 
                        if(activity.ActivityId == (int)ActivityComboBox.SelectedValue)
                        {
                            activity.Plots.Add(plotResponse.ResponseObj);
                        }
                    }
                }
            }
        }

        
    }
}
