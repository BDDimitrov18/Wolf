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
        public AddPlotToObject(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;

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

        private void AddPlotToObject_Load(object sender, EventArgs e)
        {
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
        }

        private void LoadPlotNumbers()
        {
            var plotNumbers = _dataService.GetEKTViewModels().Select(x => x.EKTNumber).Distinct().ToList();
            PlotNumberComboBox.DataSource = plotNumbers;
        }

        private void PlotNumberComboBox_TextChanged(object sender, EventArgs e)
        {
            string selectedPlotNumber = PlotNumberComboBox.Text as string;

            if (!string.IsNullOrEmpty(selectedPlotNumber))
            {
                var selectedPlot = _dataService.GetAllPlots().FirstOrDefault(x => x.PlotNumber == selectedPlotNumber);
                if (selectedPlot != null)
                {
                    CityTextBox.Text = selectedPlot.City;
                    MunicipalityTextBox.Text = selectedPlot.Municipality;
                    LocalityTextBox.Text = selectedPlot.locality;
                    DesignationComboBox.Text = selectedPlot.designation != null ? selectedPlot.designation : "";
                    RegulatedNumberTextBox.Text = selectedPlot.RegulatedPlotNumber != null ? selectedPlot.RegulatedPlotNumber : "";
                    NeighborhoodTextBox.Text = selectedPlot.neighborhood != null ? selectedPlot.neighborhood : "";
                    StreetTextBox.Text = selectedPlot.Street != null ? selectedPlot.Street : "";
                    StreetNumberTextBox.Text = selectedPlot.StreetNumber != null ? selectedPlot.StreetNumber.ToString() : "";
                }
                else
                {
                    var selectedEKT = _dataService.GetEKTViewModels().FirstOrDefault(x => x.EKTNumber == selectedPlotNumber);

                    if (selectedEKT != null)
                    {
                        CityTextBox.Text = $"{selectedEKT.TypeOfPlace} {selectedEKT.TownName}";
                        LocalityTextBox.Text = selectedEKT.Localitiy;
                        MunicipalityTextBox.Text = selectedEKT.Municipality;
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
                StreetNumber  = int.Parse(StreetNumberTextBox.Text),
                designation = DesignationComboBox.Text,
                locality = LocalityTextBox.Text,
            };

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
