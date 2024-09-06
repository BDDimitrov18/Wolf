using DTOS.DTO;
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
        private List<GetOwnerDTO> owners;

        public AddOwnerForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            owners = new List<GetOwnerDTO>();
            _ownerValidator = new CreateOwnerDTO();
            _documentOfOwnershipValidator = new CreateDocumentOfOwnershipDTO();
            EGNTextBox.TextChanged += EGNTextBox_TextChanged;

            this.Text = GlobalSettings.FormTitle + " : Добавяне на собственост";
            this.Icon = new Icon(GlobalSettings.IconPath);
            this.KeyPreview = true;

            // Add the KeyDown event handler
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the ESC key was pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Close the form
            }
            if (e.KeyCode == Keys.Enter) {
                SubmitButton_Click(new object(), new EventArgs());
            }
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
                // Clear all error messages if validation passes
                foreach (Control control in Controls)
                {
                    errorProvider.SetError(control, string.Empty);
                }
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

        private async void AddOwnerForm_Load(object sender, EventArgs e)
        {
            var ownersResponse = await _userClient.GetAllOwners();
            owners = ownersResponse.ResponseObj;
            List<GetPlotDTO> plotDTOs = _dataService.GetSelectedPlots();

            EGNTextBox.DataSource = owners;
            EGNTextBox.DisplayMember = "EGN";
            EGNTextBox.ValueMember = "OwnerID";

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
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;

                DocumentTypeComboBox.Text = matchingDocument.TypeOfDocument;
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                TOMComboBox.Text = matchingDocument.TOM.ToString();
                RegisterComboBox.Text = matchingDocument.register;
                CaseComboBox.Text = matchingDocument.DocCase;
                IssingDateTimePicker.Value = matchingDocument.DateOfIssuing;
                registeringDateTimePicker.Value = matchingDocument.DateOfRegistering;
                Issuer.Text = matchingDocument.Issuer;
                TypeOfOwnership.Text = matchingDocument.TypeOfOwnership;
            }
            var powerOfattorneys = _dataService.GetPowerOfAttorneyFromPlots(plotComboBox.SelectedItem as GetPlotDTO);
            if (powerOfattorneys != null && powerOfattorneys.Count() > 0)
            {
                PowerOfAttorneyNumber.DataSource = _dataService.GetPowerOfAttorneyFromPlots(plotComboBox.SelectedItem as GetPlotDTO);
                PowerOfAttorneyNumber.DisplayMember = "number";
                PowerOfAttorneyNumber.ValueMember = "PowerOfAttorneyId";
                PowerOfAttorneyNumber.SelectedIndex = 0;

                var matchingDocumentPow = PowerOfAttorneyNumber.SelectedItem as GetPowerOfAttorneyDocumentDTO;
                if (matchingDocumentPow != null)
                {
                    PowerOfAttorneyIssuerComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    PowerOfAttorneyIssuerComboBox.Text = matchingDocumentPow.Issuer;

                    PowerOfAttorneyDatetimePicker.Value = matchingDocumentPow.dateOfIssuing;
                }

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
            DocumentTypeComboBox.Text = "";
            TOMComboBox.Text = "";
            RegisterComboBox.Text = "";
            CaseComboBox.Text = "";
            IssingDateTimePicker.Value = GlobalSettings.GetCurrentTime();
            registeringDateTimePicker.Value = GlobalSettings.GetCurrentTime();

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
                                    return float.Parse(textBox.Text);
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
                FullName = NameTextBox.Text,    
                EGN = EGNTextBox.Text,
                Address = AddressTextBox.Text,
            };
            int.Parse(DocumentNumberComboBox.Text);
            var OwnerResponse = await _userClient.AddOwner(createOwnerDTO);

            GetOwnerDTO OWNERTOEDIT = owners.Where(ow => ow.EGN == OwnerResponse.ResponseObj.EGN).FirstOrDefault();
            if (OWNERTOEDIT != null)
            {
                // Compare all relevant fields to check for differences
                bool isDifferent = OwnerResponse.ResponseObj.FullName != OWNERTOEDIT.FullName ||
                                   OwnerResponse.ResponseObj.Address != OWNERTOEDIT.Address;

                if (isDifferent)
                {

                    _dataService.EditOwner(OwnerResponse.ResponseObj);
                }
            }
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
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;

                DocumentTypeComboBox.Text = matchingDocument.TypeOfDocument;
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                TOMComboBox.Text = matchingDocument.TOM.ToString();
                RegisterComboBox.Text = matchingDocument.register;
                CaseComboBox.Text = matchingDocument.DocCase;
                IssingDateTimePicker.Value = matchingDocument.DateOfIssuing;
                registeringDateTimePicker.Value = matchingDocument.DateOfRegistering;
                Issuer.Text = matchingDocument.Issuer;
                TypeOfOwnership.Text = matchingDocument.TypeOfOwnership;
            }
            else
            {
                DocumentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                DocumentTypeComboBox.Text = "";
                TOMComboBox.Text = "";
                RegisterComboBox.Text = "";
                CaseComboBox.Text = "";
                IssingDateTimePicker.Value = GlobalSettings.GetCurrentTime();
                registeringDateTimePicker.Value = GlobalSettings.GetCurrentTime();
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
                PowerOfAttorneyIssuerComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                PowerOfAttorneyIssuerComboBox.Text = matchingDocument.Issuer;

                PowerOfAttorneyDatetimePicker.Value = matchingDocument.dateOfIssuing;
            }
            else
            {
                PowerOfAttorneyIssuerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void EGNTextBox_TextChanged(object sender, EventArgs e)
        {
            string selectedEGN = EGNTextBox.Text;

            // Temporarily remove the event handler to prevent it from firing while updating the items
            EGNTextBox.TextChanged -= EGNTextBox_TextChanged;

            // Filter the list based on the text input or show all items if the text is empty
            List<GetOwnerDTO> filteredOwners;
            if (string.IsNullOrWhiteSpace(selectedEGN))
            {
                // If the text is empty, display all plots
                filteredOwners = owners;
            }
            else
            {
                // Get the list of plots and filter based on the text input
                filteredOwners = owners
                    .Where(owner => owner.EGN.IndexOf(selectedEGN, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(owner => owner.EGN)
                    .ToList();
            }

            // Update the ComboBox DataSource
            EGNTextBox.DataSource = filteredOwners;
            EGNTextBox.DisplayMember = "EGN";
            EGNTextBox.ValueMember = "OwnerID";

            // Restore the user's text and keep the ComboBox open
            EGNTextBox.Text = selectedEGN;
            EGNTextBox.SelectionStart = selectedEGN.Length;

            // Reattach the event handler
            EGNTextBox.TextChanged += EGNTextBox_TextChanged;


            string egn = EGNTextBox.Text;
            GetOwnerDTO owner = owners.Where(ow => ow.EGN == egn).FirstOrDefault();
            if (owner != null)
            {
                NameTextBox.Text = owner.FullName;
                AddressTextBox.Text = owner.Address;
            }

        }

        private void Issuer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
