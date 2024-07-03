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
using WolfClient.Services.Interfaces;
using WolfClient.UserControls;

namespace WolfClient.NewForms
{
    public partial class AddOwnerForm : Form
    {

        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        public AddOwnerForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdealPartsPanel.Controls.Clear();
            if (IdealPartsTypeComboBox.Text == "дроб")
            {
                IdealPartDrob drob = new IdealPartDrob();
                LoadUserControl(drob);
            }
            if (IdealPartsTypeComboBox.Text == "плаваща запетая")
            {
                IdealPartNumber number = new IdealPartNumber();
                LoadUserControl(number);
            }
        }
        private void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            IdealPartsPanel.Controls.Clear();

            // Set the Dock property to Fill to make it responsive
            userControl.Dock = DockStyle.Fill;

            // Add the new UserControl
            IdealPartsPanel.Controls.Add(userControl);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AddOwnerForm_Load(object sender, EventArgs e)
        {
            List<GetPlotDTO> plotDTOs = _dataService.GetAllPlots();

            plotComboBox.DataSource = plotDTOs;
            plotComboBox.DisplayMember = "DisplayMemberPlot";
            plotComboBox.ValueMember = "PlotId";
        }

        private void plotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var plot = plotComboBox.SelectedItem as GetPlotDTO;
            plotTypeLabel.Text = $"предназначение : {plot.designation}";
            plotCityLabel.Text = $"град/село : {plot.City}";
            plotStreetLabel.Text = $"улица : {plot.Street} {plot.StreetNumber}";
            plotLocalityLabel.Text = $"област : {plot.locality}";
        }

        private float getIdealPart() {
            float first =1,second =-1;
            if (IdealPartsTypeComboBox.Text == "дроб")
            {
                foreach (IdealPartDrob userControl in IdealPartsPanel.Controls.OfType<IdealPartDrob>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is TextBox)
                        {
                            if (control.AccessibleName == "FirstNumberTextBox")
                            {
                                TextBox textBox = control as TextBox;
                                if (textBox.Text != "")
                                {
                                    first = float.Parse(textBox.Text);
                                }
                            }
                            if (control.AccessibleName == "SecondNumberTextBox")
                            {
                                TextBox textBox = control as TextBox;
                                if (textBox.Text != "")
                                {
                                    second = float.Parse(textBox.Text);
                                }
                            }
                        }
                    }
                }
                if (first > 0 && second > 0)
                {
                    float result = first / second;

                    return result;
                }
                else return -1;
            }
            else if (IdealPartsTypeComboBox.Text == "плаваща запетая") {
                foreach (IdealPartNumber userControl in IdealPartsPanel.Controls.OfType<IdealPartNumber>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is TextBox)
                        {
                            if (control.AccessibleName == "numberTextBox") {
                                TextBox textBox = control as TextBox;
                                if (textBox.Text != "")
                                {
                                    return float.Parse(textBox.Text);
                                }
                                else {
                                    return -1;
                                }
                            }
                        }
                    }
                }
            }
            return -1;
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            string[] names = NameTextBox.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CreateOwnerDTO createOwnerDTO = new CreateOwnerDTO() { 
                FirstName = names[0],
                MiddleName = names[1],
                LastName = names[2],
                EGN = EGNTextBox.Text,
                Address= AddressTextBox.Text,
            };
            int.Parse(DocumentNumberComboBox.Text);
            var OwnerResponse = await _userClient.AddOwner(createOwnerDTO);
            CreateDocumentOfOwnershipDTO createDocumentOfOwnership = new CreateDocumentOfOwnershipDTO()
            {
                TypeOfDocument = DocumentTypeComboBox.Text,
                NumberOfDocument = DocumentNumberComboBox.Text,
                Issuer = Issuer.Text,
                TOM = int.Parse(TOMComboBox.Text),
                register = RegisterComboBox.Text,
                DocCase = CaseComboBox.Text,
                DateOfRegistering = registeringDateTimePicker.Value,
                DateOfIssuing = IssingDateTimePicker.Value,
            };

            var documentResponse = await _userClient.AddDocumentOfOwnership(createDocumentOfOwnership);

            CreatePlot_DocumentOfOwnershipRelashionshipDTO createPlot_Document = new CreatePlot_DocumentOfOwnershipRelashionshipDTO()
            {
                PlotId = (int)plotComboBox.SelectedValue,
                DocumentOfOwnershipId = documentResponse.ResponseObj.DocumentId
            };

            var PlotDocumentResponse = await _userClient.AddPlotDocumentRelashionship(createPlot_Document);

            CreateDocumentOfOwnership_OwnerRelashionshipDTO CreateDocument_Owner = new CreateDocumentOfOwnership_OwnerRelashionshipDTO()
            {
                DocumentID = documentResponse.ResponseObj.DocumentId,
                OwnerID = OwnerResponse.ResponseObj.OwnerID
            };

            var DocumentOwnerResponse = await _userClient.AddDocumentOwnerRelashionship(CreateDocument_Owner);

            CreateDocumentPlot_DocumentOwnerRelashionshipDTO createDocumentPlot_DocumentOwner = new CreateDocumentPlot_DocumentOwnerRelashionshipDTO()
            {
                DocumentPlotId = PlotDocumentResponse.ResponseObj.DocumentPlotId,
                DocumentOwnerID = DocumentOwnerResponse.ResponseObj.DocumentOwnerID,
                IdealParts = getIdealPart(),
                WayOfAcquiring = wayOfAcquiringComboBox.Text,
            };

            var DocumentPlotDocumentOwnerResponse = await _userClient.AddPlotOwnerRelashionship(createDocumentPlot_DocumentOwner);

            _dataService.addPlotOwnerRelashionship(DocumentPlotDocumentOwnerResponse.ResponseObj);
        }
    }
}
