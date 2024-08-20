using DocumentFormat.OpenXml.Drawing.Charts;
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
    public partial class EditOwnerForm : Form
    {

        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        private CreateOwnerDTO _ownerValidator;
        private CreateDocumentOfOwnershipDTO _documentOfOwnershipValidator;

        public EditOwnerForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
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
                foreach (Control control in Controls)
                {
                    errorProvider.SetError(control, string.Empty);
                }
                // Clear previous error messages
                errorProvider.Clear();
                if (getIdealPart() == -1)
                {
                    errorProvider.SetError(IdealPartsPanel, "Моля въведете стойности");
                }

                int tom;

                _documentOfOwnershipValidator.TypeOfDocument = DocumentTypeComboBox.Text;
                _documentOfOwnershipValidator.NumberOfDocument = DocumentNumberTextBox.Text;
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

        private string ConvertFloatToFraction(float value)
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

        private void AddOwnerForm_Load(object sender, EventArgs e)
        {
            int relashionshipId = _dataService.GetSelectedOwnershipViewModelsRequestMenu()[0].PlotOwnerID;
            GetDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO = _dataService.GetPlotOwnerById(relashionshipId);
            GetPlotDTO selectedPlot = _dataService.getPlotFromPlotOwnerID(relashionshipId);
            plotTypeLabel.Text = $"предназначение : {selectedPlot.designation}";
            plotCityLabel.Text = $"град/село : {selectedPlot.City}";
            plotStreetLabel.Text = $"улица : {selectedPlot.Street} {selectedPlot.StreetNumber}";
            plotLocalityLabel.Text = $"област : {selectedPlot.locality}";

            EGNTextBox.Text = relashionshipDTO.DocumentOwner.Owner.EGN;
            NameTextBox.Text = relashionshipDTO.DocumentOwner.Owner.FirstName + " " +
            relashionshipDTO.DocumentOwner.Owner.MiddleName + " " +
            relashionshipDTO.DocumentOwner.Owner.LastName;
            AddressTextBox.Text = relashionshipDTO.DocumentOwner.Owner.Address;

            DocumentTypeComboBox.Text = relashionshipDTO.DocumentOwner.Document.TypeOfDocument;
            DocumentNumberTextBox.Text = relashionshipDTO.DocumentOwner.Document.NumberOfDocument;
            TOMComboBox.Text = relashionshipDTO.DocumentOwner.Document.TOM.ToString();
            CaseComboBox.Text = relashionshipDTO.DocumentOwner.Document.DocCase;
            RegisterComboBox.Text = relashionshipDTO.DocumentOwner.Document.register;
            IssingDateTimePicker.Value = relashionshipDTO.DocumentOwner.Document.DateOfIssuing;
            registeringDateTimePicker.Value = relashionshipDTO.DocumentOwner.Document.DateOfRegistering;
            Issuer.Text = relashionshipDTO.DocumentOwner.Document.Issuer;

            int typeOfOwnershipIndex = TypeOfOwnership.FindStringExact(relashionshipDTO.DocumentOwner.Document.TypeOfOwnership);
            TypeOfOwnership.SelectedIndex = typeOfOwnershipIndex;

            int issuerIndex = Issuer.FindStringExact(relashionshipDTO.DocumentOwner.Document.Issuer);
            Issuer.SelectedIndex = issuerIndex;

            PowerOfAttorneyNumberTextBox.Text = relashionshipDTO.powerOfAttorneyDocumentDTO.number;
            int issuerOfPowerOfAttorneyIdex = PowerOfAttorneyIssuerComboBox.FindStringExact(relashionshipDTO.powerOfAttorneyDocumentDTO.Issuer);
            PowerOfAttorneyIssuerComboBox.SelectedIndex = issuerOfPowerOfAttorneyIdex;

            PowerOfAttorneyDatetimePicker.Value = relashionshipDTO.powerOfAttorneyDocumentDTO.dateOfIssuing;

            string idealPartstype = relashionshipDTO.isDrob ? "дроб" : "плаваща запетая";
            int idealPartsTypeIndex = IdealPartsTypeComboBox.FindStringExact(idealPartstype);
            IdealPartsTypeComboBox.SelectedIndex = idealPartsTypeIndex;

            IdealPartsPanel.Controls.Clear();
            if (IdealPartsTypeComboBox.Text == "дроб")
            {
                IdealPartDrob drob = new IdealPartDrob();
                LoadUserControl(drob);

                // Set the values in the IdealPartDrob control
                foreach (Control control in drob.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (textBox.Name == "FirstNumberTextBox")
                        {
                            var fraction = ConvertFloatToFraction(relashionshipDTO.IdealParts);
                            var parts = fraction.Split('/');
                            textBox.Text = parts[0]; // First part of the fraction
                        }
                        if (textBox.Name == "SecondNumberTextBox")
                        {
                            var fraction = ConvertFloatToFraction(relashionshipDTO.IdealParts);
                            var parts = fraction.Split('/');
                            textBox.Text = parts[1]; // Second part of the fraction
                        }
                    }
                }
            }
            else if (IdealPartsTypeComboBox.Text == "плаваща запетая")
            {
                IdealPartNumber number = new IdealPartNumber();
                LoadUserControl(number);

                // Set the value in the IdealPartNumber control
                foreach (Control control in number.Controls)
                {
                    if (control is TextBox textBox && textBox.Name == "numberTextBox")
                    {
                        textBox.Text = relashionshipDTO.IdealParts.ToString(CultureInfo.InvariantCulture);
                    }
                }
            }

            int WayOfAquiringIndex = wayOfAcquiringComboBox.FindStringExact(relashionshipDTO.WayOfAcquiring);
            wayOfAcquiringComboBox.SelectedIndex = WayOfAquiringIndex;
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

            if (!string.IsNullOrEmpty(errorProvider.GetError(DocumentNumberTextBox)))
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
            int relashionshipId = _dataService.GetSelectedOwnershipViewModelsRequestMenu()[0].PlotOwnerID;
            GetDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO = _dataService.GetPlotOwnerById(relashionshipId);
            GetOwnerDTO editOwner = relashionshipDTO.DocumentOwner.Owner;
            editOwner.FullName = NameTextBox.Text;  
            editOwner.EGN = EGNTextBox.Text;
            editOwner.Address = AddressTextBox.Text;

            await _userClient.EditOwner(editOwner);
            _dataService.EditOwner(editOwner);
            GetDocumentOfOwnershipDTO editDocumentOfOwnershipDTO = relashionshipDTO.DocumentOwner.Document;


            editDocumentOfOwnershipDTO.TypeOfDocument = DocumentTypeComboBox.Text;
            editDocumentOfOwnershipDTO.NumberOfDocument = DocumentNumberTextBox.Text;
            editDocumentOfOwnershipDTO.Issuer = Issuer.Text;
            editDocumentOfOwnershipDTO.TOM = int.Parse(TOMComboBox.Text);
            editDocumentOfOwnershipDTO.register = RegisterComboBox.Text;
            editDocumentOfOwnershipDTO.DocCase = CaseComboBox.Text;
            editDocumentOfOwnershipDTO.DateOfRegistering = registeringDateTimePicker.Value;
            editDocumentOfOwnershipDTO.DateOfIssuing = IssingDateTimePicker.Value;
            editDocumentOfOwnershipDTO.TypeOfOwnership = TypeOfOwnership.Text;

            await _userClient.EditDocumentOfOwnership(editDocumentOfOwnershipDTO);
            _dataService.EditDocument(editDocumentOfOwnershipDTO);


            GetPowerOfAttorneyDocumentDTO EditPowerOfAttorneyDocumentDTO = relashionshipDTO.powerOfAttorneyDocumentDTO;
            EditPowerOfAttorneyDocumentDTO.number = PowerOfAttorneyNumberTextBox.Text;
            EditPowerOfAttorneyDocumentDTO.Issuer = PowerOfAttorneyIssuerComboBox.Text;
            EditPowerOfAttorneyDocumentDTO.dateOfIssuing = PowerOfAttorneyDatetimePicker.Value;


            await _userClient.EditPowerOfAttorney(EditPowerOfAttorneyDocumentDTO);
            _dataService.EditPowerOfAttorney(EditPowerOfAttorneyDocumentDTO);

            relashionshipDTO.IdealParts = getIdealPart();
            relashionshipDTO.WayOfAcquiring = wayOfAcquiringComboBox.Text;
            relashionshipDTO.isDrob = getIdealPartType();


            await _userClient.EditPlotOwnerRelashionship(relashionshipDTO);
            _dataService.EditPlotOwnerRelashionship(relashionshipDTO);
            Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Issuer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
