﻿using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private CreateOwnerDTO _ownerValidator;
        private CreateDocumentOfOwnershipDTO _documentOfOwnershipValidator;

        public AddOwnerForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;

            _ownerValidator = new CreateOwnerDTO();
            _documentOfOwnershipValidator = new CreateDocumentOfOwnershipDTO();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {

                // Clear previous error messages
                errorProvider.Clear();
                if (getIdealPart() == -1)
                {
                    errorProvider.SetError(IdealPartsPanel, "Моля въведете стойности");
                }

                int tom;

                _documentOfOwnershipValidator.TypeOfDocument = DocumentTypeComboBox.Text;
                _documentOfOwnershipValidator.NumberOfDocument = DocumentNumberComboBox.Text;
                _documentOfOwnershipValidator.Issuer = Issuer.Text;
                if (int.TryParse(TOMComboBox.Text, out tom))
                {
                    _documentOfOwnershipValidator.TOM = tom;
                }
                else
                {
                    if (TOMComboBox.Text == "")
                    {
                        errorProvider.SetError(TOMComboBox, "Въведете Том");
                        TomValidatorLabel.Text = "Въведете Том";
                    }
                    else
                    {
                        errorProvider.SetError(TOMComboBox, "Том не е число");
                        TomValidatorLabel.Text = "Том не е число";
                    }
                }
                if (int.TryParse(RegisterComboBox.Text, out tom))
                {
                    _documentOfOwnershipValidator.register = tom.ToString();
                }
                else
                {
                    if (RegisterComboBox.Text == "")
                    {
                        errorProvider.SetError(RegisterComboBox, "Въведете регистър");
                        RegisterComboBox.Text = "Въведете регистър";
                    }
                    else
                    {
                        errorProvider.SetError(RegisterComboBox, "Регистър не е число");
                        RegisterValidatorLabel.Text = "Регистър не е число";
                    }
                }

                if (int.TryParse(CaseComboBox.Text, out tom))
                {
                    _documentOfOwnershipValidator.DocCase = tom.ToString();
                }
                else
                {
                    if (CaseComboBox.Text == "")
                    {
                        errorProvider.SetError(CaseComboBox, "Въведете дело");
                        CaseValidatorLabel.Text = "Въведете дело";
                    }
                    else
                    {
                        errorProvider.SetError(CaseComboBox, "Дело не е число");
                        CaseValidatorLabel.Text = "Дело не е число";
                    }
                }

                _documentOfOwnershipValidator.DocCase = CaseComboBox.Text;
                _documentOfOwnershipValidator.DateOfRegistering = registeringDateTimePicker.Value;
                _documentOfOwnershipValidator.DateOfIssuing = IssingDateTimePicker.Value;


                // Bind the form controls to the model properties
                _ownerValidator.EGN = EGNTextBox.Text;
                _ownerValidator.Address = AddressTextBox.Text;
                string[] names = NameTextBox.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (names.Length < 1)
                {
                    errorProvider.SetError(NameTextBox, "Въведете три имена");
                    NameValidatorLabel.Text = "Въведете три имена";
                }
                else if (names.Length == 1)
                {
                    errorProvider.SetError(NameTextBox, "Въведете три имена");
                    NameValidatorLabel.Text = "Въведете три имена";
                }
                else if (names.Length == 2)
                {
                    errorProvider.SetError(NameTextBox, "Въведете три имена");
                    NameValidatorLabel.Text = "Въведете три имена";
                }
                else if (names.Length == 3)
                {
                    _ownerValidator.FirstName = names[0];
                    _ownerValidator.MiddleName = names[1];
                    _ownerValidator.LastName = names[2];
                }
                else if (names.Length > 3)
                {
                    errorProvider.SetError(NameTextBox, "Въведете само 3 имена");
                    NameValidatorLabel.Text = "Въведете саме 3 имена";
                }

                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(_ownerValidator);

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

                memberNameResults = WolfClient.Validators.Validator.Validate(_documentOfOwnershipValidator);

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
                // Owner Validator
                nameof(_ownerValidator.FirstName) => "FirstNameTextBox",
                nameof(_ownerValidator.MiddleName) => "MiddleNameTextBox",
                nameof(_ownerValidator.LastName) => "LastNameTextBox",
                nameof(_ownerValidator.EGN) => "EGNTextBox",
                nameof(_ownerValidator.Address) => "AddressTextBox",

                // Document Of Ownership Validator
                nameof(_documentOfOwnershipValidator.TypeOfDocument) => "DocumentTypeComboBox",
                nameof(_documentOfOwnershipValidator.NumberOfDocument) => "DocumentNumberComboBox",
                nameof(_documentOfOwnershipValidator.Issuer) => "IssuerTextBox",
                nameof(_documentOfOwnershipValidator.TOM) => "TOMComboBox",
                nameof(_documentOfOwnershipValidator.register) => "RegisterComboBox",
                nameof(_documentOfOwnershipValidator.DocCase) => "CaseComboBox",
                nameof(_documentOfOwnershipValidator.DateOfIssuing) => "IssingDateTimePicker",
                nameof(_documentOfOwnershipValidator.DateOfRegistering) => "registeringDateTimePicker",

                _ => null
            };
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
            foreach (Control control in IdealPartsPanel.Controls)
            {
                control.Dispose();
            }
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
            List<GetPlotDTO> plotDTOs = _dataService.GetSelectedPlots();

            plotComboBox.DataSource = plotDTOs;
            plotComboBox.DisplayMember = "DisplayMemberPlot";
            plotComboBox.ValueMember = "PlotId";

            plotComboBox.SelectedIndex = 0;
            DocumentTypeComboBox.SelectedIndex = 0;
            IdealPartsTypeComboBox.SelectedIndex = 0;
            wayOfAcquiringComboBox.SelectedIndex = 0;
            TypeOfOwnership.SelectedIndex = 0;
            Issuer.SelectedIndex = 0;

            DocumentNumberComboBox.DataSource = _dataService.GetDocumentsFromPlots(plotComboBox.SelectedItem as GetPlotDTO);
            DocumentNumberComboBox.DisplayMember = "NumberOfDocument";
            DocumentNumberComboBox.ValueMember = "DocumentId";
            DocumentTypeComboBox.SelectedIndex = 0;

            var matchingDocument = DocumentNumberComboBox.SelectedItem as GetDocumentOfOwnershipDTO;

            if (matchingDocument != null)
            {
                DocumentTypeComboBox.Enabled = true;
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                TOMComboBox.Enabled = true;
                RegisterComboBox.Enabled = true;
                CaseComboBox.Enabled = true;
                IssingDateTimePicker.Enabled = true;
                registeringDateTimePicker.Enabled = true;
                Issuer.Enabled = true;
                TypeOfOwnership.Enabled = true;

                DocumentTypeComboBox.Text = matchingDocument.TypeOfDocument;
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                DocumentTypeComboBox.Enabled = false;
                TOMComboBox.Text = matchingDocument.TOM.ToString();
                TOMComboBox.Enabled = false;
                RegisterComboBox.Text = matchingDocument.register;
                RegisterComboBox.Enabled = false;
                CaseComboBox.Text = matchingDocument.DocCase;
                CaseComboBox.Enabled = false;
                IssingDateTimePicker.Value = matchingDocument.DateOfIssuing;
                IssingDateTimePicker.Enabled = false;
                registeringDateTimePicker.Value = matchingDocument.DateOfRegistering;
                registeringDateTimePicker.Enabled = false;
                Issuer.Text = matchingDocument.Issuer;
                Issuer.Enabled = false;
                TypeOfOwnership.Text = matchingDocument.TypeOfOwnership;
                TypeOfOwnership.Enabled = false;
            }

            PowerOfAttorneyNumber.DataSource = _dataService.GetPowerOfAttorneyFromPlots(plotComboBox.SelectedItem as GetPlotDTO);
            PowerOfAttorneyNumber.DisplayMember = "number";
            PowerOfAttorneyNumber.ValueMember = "PowerOfAttorneyId";
            PowerOfAttorneyNumber.SelectedIndex = 0;

            var matchingDocumentPow = PowerOfAttorneyNumber.SelectedItem as GetPowerOfAttorneyDocumentDTO;
            if (matchingDocumentPow != null)
            {
                PowerOfAttorneyIssuerComboBox.Enabled = true;
                PowerOfAttorneyIssuerComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                PowerOfAttorneyIssuerComboBox.Text = matchingDocumentPow.Issuer;
                PowerOfAttorneyIssuerComboBox.Enabled = false;

                PowerOfAttorneyDatetimePicker.Enabled = true;
                PowerOfAttorneyDatetimePicker.Value = matchingDocumentPow.dateOfIssuing;
                PowerOfAttorneyDatetimePicker.Enabled = false;
            }
            

            DocumentNumberComboBox.TextChanged += DocumentNumberComboBox_TextChanged;
            PowerOfAttorneyNumber.TextChanged += PowerOfAttorneyNumber_TextChanged;

        }

        private void plotComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var plot = plotComboBox.SelectedItem as GetPlotDTO;
            plotTypeLabel.Text = $"предназначение : {plot.designation}";
            plotCityLabel.Text = $"град/село : {plot.City}";
            plotStreetLabel.Text = $"улица : {plot.Street} {plot.StreetNumber}";
            plotLocalityLabel.Text = $"област : {plot.locality}";

            DocumentNumberComboBox.DataSource = _dataService.GetDocumentsFromPlots(plotComboBox.SelectedItem as GetPlotDTO);
            DocumentNumberComboBox.DisplayMember = "NumberOfDocument";
            DocumentNumberComboBox.ValueMember = "DocumentId";

            PowerOfAttorneyNumber.DataSource = _dataService.GetPowerOfAttorneyFromPlots(plotComboBox.SelectedItem as GetPlotDTO);
            PowerOfAttorneyNumber.DisplayMember = "number";
            PowerOfAttorneyNumber.ValueMember = "PowerOfAttorneyId";



            DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            TOMComboBox.Enabled = true;
            RegisterComboBox.Enabled = true;
            CaseComboBox.Enabled = true;
            IssingDateTimePicker.Enabled = true;
            registeringDateTimePicker.Enabled = true;
            DocumentTypeComboBox.Text = "";
            TOMComboBox.Text = "";
            RegisterComboBox.Text = "";
            CaseComboBox.Text = "";
            IssingDateTimePicker.Value = DateTime.Now;
            registeringDateTimePicker.Value = DateTime.Now;

        }


        private bool getIdealPartType()
        {
            if (IdealPartsTypeComboBox.Text == "дроб")
            {
                return true;
            }
            else if (IdealPartsTypeComboBox.Text == "плаваща запетая")
            {
                return false;
            }
            return false;
        }
        private float getIdealPart()
        {
            float first = 1, second = -1;
            if (IdealPartsTypeComboBox.Text == "дроб")
            {
                foreach (IdealPartDrob userControl in IdealPartsPanel.Controls.OfType<IdealPartDrob>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is TextBox)
                        {
                            if (control.Name == "FirstNumberTextBox")
                            {
                                TextBox textBox = control as TextBox;
                                if (textBox.Text != "")
                                {
                                    first = float.Parse(textBox.Text);
                                }
                            }
                            if (control.Name == "SecondNumberTextBox")
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
            else if (IdealPartsTypeComboBox.Text == "плаваща запетая")
            {
                foreach (IdealPartNumber userControl in IdealPartsPanel.Controls.OfType<IdealPartNumber>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is TextBox)
                        {
                            if (control.Name == "numberTextBox")
                            {
                                TextBox textBox = control as TextBox;
                                if (textBox.Text != "")
                                {
                                    return float.Parse(textBox.Text, CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    return -1;
                                }
                            }
                        }
                    }
                }
            }
            return -1;
        }

        private void ResetLabelColors()
        {
            NameValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            EgnValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            AddressValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            IdealPartsValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            WayOfAcquiringLabel.ForeColor = SystemColors.GradientActiveCaption;
            DocumentValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            DocNumberValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            TomValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            RegisterValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            CaseValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
            IdealPartsValidatorLabel.ForeColor = SystemColors.GradientActiveCaption;
        }

        private bool SetValidationLabels()
        {
            bool flag = false;
            if (!string.IsNullOrEmpty(errorProvider.GetError(NameTextBox)))
            {
                NameValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(IdealPartsPanel)))
            {
                IdealPartsValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(errorProvider.GetError(EGNTextBox)))
            {
                EgnValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(AddressTextBox)))
            {
                AddressValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(DocumentTypeComboBox)))
            {
                DocumentValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(DocumentNumberComboBox)))
            {
                DocNumberValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }


            if (!string.IsNullOrEmpty(errorProvider.GetError(TOMComboBox)))
            {
                TomValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(RegisterComboBox)))
            {
                RegisterValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }

            if (!string.IsNullOrEmpty(errorProvider.GetError(CaseComboBox)))
            {
                CaseValidatorLabel.ForeColor = Color.Red;
                flag = true;
            }


            if (flag)
            {
                return true;
            }
            return false;

        }
        private async void SubmitButton_Click(object sender, EventArgs e)
        {

            ValidateModel();
            ResetLabelColors();
            if (SetValidationLabels()) { return; }

            string[] names = NameTextBox.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CreateOwnerDTO createOwnerDTO = new CreateOwnerDTO()
            {
                FirstName = names[0],
                MiddleName = names[1],
                LastName = names[2],
                EGN = EGNTextBox.Text,
                Address = AddressTextBox.Text,
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
                TypeOfOwnership = TypeOfOwnership.Text,
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

            CreatePowerOfAttorneyDocumentDTO createPowerOfAttorneyDTO = new CreatePowerOfAttorneyDocumentDTO()
            {
                number = PowerOfAttorneyNumber.Text,
                Issuer = PowerOfAttorneyIssuerComboBox.Text,
                dateOfIssuing = PowerOfAttorneyDatetimePicker.Value
            };

            var powerOfAttorneyDocument = await _userClient.AddPowerOfAttorney(createPowerOfAttorneyDTO);

            CreateDocumentPlot_DocumentOwnerRelashionshipDTO createDocumentPlot_DocumentOwner = new CreateDocumentPlot_DocumentOwnerRelashionshipDTO()
            {
                DocumentPlotId = PlotDocumentResponse.ResponseObj.DocumentPlotId,
                DocumentOwnerID = DocumentOwnerResponse.ResponseObj.DocumentOwnerID,
                IdealParts = getIdealPart(),
                WayOfAcquiring = wayOfAcquiringComboBox.Text,
                isDrob = getIdealPartType(),
                PowerOfAttorneyId = powerOfAttorneyDocument.ResponseObj.PowerOfAttorneyId
            };

            var DocumentPlotDocumentOwnerResponse = await _userClient.AddPlotOwnerRelashionship(createDocumentPlot_DocumentOwner);

            _dataService.addPlotOwnerRelashionship(DocumentPlotDocumentOwnerResponse.ResponseObj);

            Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        private void DocumentNumberComboBox_TextChanged(object sender, EventArgs e)
        {
            var documents = _dataService.getAllDocuments();
            var matchingDocument = documents.FirstOrDefault(doc => doc.NumberOfDocument == DocumentNumberComboBox.Text);

            if (matchingDocument != null)
            {
                DocumentTypeComboBox.Enabled = true;
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                TOMComboBox.Enabled = true;
                RegisterComboBox.Enabled = true;
                CaseComboBox.Enabled = true;
                IssingDateTimePicker.Enabled = true;
                registeringDateTimePicker.Enabled = true;
                Issuer.Enabled = true;
                TypeOfOwnership.Enabled = true;

                DocumentTypeComboBox.Text = matchingDocument.TypeOfDocument;
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                DocumentTypeComboBox.Enabled = false;
                TOMComboBox.Text = matchingDocument.TOM.ToString();
                TOMComboBox.Enabled = false;
                RegisterComboBox.Text = matchingDocument.register;
                RegisterComboBox.Enabled = false;
                CaseComboBox.Text = matchingDocument.DocCase;
                CaseComboBox.Enabled = false;
                IssingDateTimePicker.Value = matchingDocument.DateOfIssuing;
                IssingDateTimePicker.Enabled = false;
                registeringDateTimePicker.Value = matchingDocument.DateOfRegistering;
                registeringDateTimePicker.Enabled = false;
                Issuer.Text = matchingDocument.Issuer;
                Issuer.Enabled = false;
                TypeOfOwnership.Text = matchingDocument.TypeOfOwnership;
                TypeOfOwnership.Enabled = false;
            }
            else
            {
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                TOMComboBox.Enabled = true;
                RegisterComboBox.Enabled = true;
                CaseComboBox.Enabled = true;
                IssingDateTimePicker.Enabled = true;
                registeringDateTimePicker.Enabled = true;
                DocumentTypeComboBox.Text = "";
                TOMComboBox.Text = "";
                RegisterComboBox.Text = "";
                CaseComboBox.Text = "";
                IssingDateTimePicker.Value = DateTime.Now;
                registeringDateTimePicker.Value = DateTime.Now;
                TypeOfOwnership.Enabled = true;
                Issuer.Enabled = true;
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PowerOfAttorneyNumber_TextChanged(object sender, EventArgs e)
        {
            var powerOfAttorneys = _dataService.GetAllPowerOfAttorneys();
            var matchingDocument = powerOfAttorneys.FirstOrDefault(doc => doc.number == PowerOfAttorneyNumber.Text);
            if (matchingDocument != null)
            {
                PowerOfAttorneyIssuerComboBox.Enabled = true;
                PowerOfAttorneyIssuerComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                PowerOfAttorneyIssuerComboBox.Text = matchingDocument.Issuer;
                PowerOfAttorneyIssuerComboBox.Enabled = false;

                PowerOfAttorneyDatetimePicker.Enabled = true;
                PowerOfAttorneyDatetimePicker.Value = matchingDocument.dateOfIssuing;
                PowerOfAttorneyDatetimePicker.Enabled = false;
            }
            else {
                PowerOfAttorneyIssuerComboBox.Enabled = true;
                PowerOfAttorneyIssuerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                PowerOfAttorneyDatetimePicker.Enabled = true;
            }
        }
    }
}
