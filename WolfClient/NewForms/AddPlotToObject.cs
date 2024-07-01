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


        public AddPlotToObject(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
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
                var selectedEKT = _dataService.GetEKTViewModels().FirstOrDefault(x => x.EKTNumber == selectedPlotNumber);

                if (selectedEKT != null)
                {
                    CityComboBox.Text = $"{selectedEKT.TypeOfPlace} {selectedEKT.TownName}";
                    LocalityComboBox.Text = selectedEKT.Localitiy;
                    MunicipalityComboBox.Text = selectedEKT.Municipality;
                }
            }
        }

        private async void AddPlotToObjectSubmitButton_Click(object sender, EventArgs e)
        {
            CreatePlotDTO newPlot = new CreatePlotDTO() { 
                PlotNumber = PlotNumberComboBox.Text,
                RegulatedPlotNumber = RegulatedNumberTextBox.Text,
                neighborhood = NeighborhoodTextBox.Text,
                City = CityComboBox.Text,
                Municipality = MunicipalityComboBox.Text,
                Street = StreetTextBox.Text,
                StreetNumber  = int.Parse(StreetNumberTextBox.Text),
                designation = DesignationComboBox.Text,
                locality = LocalityComboBox.Text,
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
