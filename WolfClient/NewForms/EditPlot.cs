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
    public partial class EditPlot : Form
    {
        private readonly IDataService _dataService;
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;

        private CreatePlotDTO plotValidator;
        public EditPlot(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
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
                foreach (Control control in Controls)
                {
                    errorProvider.SetError(control, string.Empty);
                }
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
            GetPlotDTO selectedPlot = _dataService.getSelectedPlotsOnRequestMenu()[0];
            PlotNumberComboBox.Text = selectedPlot.PlotNumber;
            CityTextBox.Text = selectedPlot.City;
            MunicipalityTextBox.Text = selectedPlot?.Municipality;
            LocalityTextBox.Text = selectedPlot?.locality;
            RegulatedNumberTextBox.Text = selectedPlot?.RegulatedPlotNumber;
            NeighborhoodTextBox.Text = selectedPlot?.neighborhood;
            StreetTextBox.Text = selectedPlot?.Street;
            StreetNumberTextBox.Text = selectedPlot?.StreetNumber.ToString();
            DesignationComboBox.Text = selectedPlot?.designation;
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
            GetPlotDTO editPlot = _dataService.getSelectedPlotsOnRequestMenu()[0];

            editPlot.PlotNumber = PlotNumberComboBox.Text;
            editPlot.RegulatedPlotNumber = RegulatedNumberTextBox.Text;
            editPlot.neighborhood = NeighborhoodTextBox.Text;
            editPlot.City = CityTextBox.Text;
            editPlot.Municipality = MunicipalityTextBox.Text;
            editPlot.Street = StreetTextBox.Text;
            editPlot.StreetNumber = int.Parse(StreetNumberTextBox.Text);
            editPlot.designation = DesignationComboBox.Text;
            editPlot.locality = LocalityTextBox.Text;


            await _userClient.EditPlot(editPlot);

            _dataService.EditPlot(editPlot);

            Dispose();
        }

        
    }
}
