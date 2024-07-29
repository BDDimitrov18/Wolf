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
using System.Xml.Linq;
using WolfClient.Services.Interfaces;
using WolfClient.Validators;
namespace WolfClient.NewForms
{
    public partial class EditCientForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        private CreateClientDTO _clientDTO;

        private CreateClientDTO _clientValidator;
        public EditCientForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;

            _clientValidator = new CreateClientDTO();

            this.SetStyle(ControlStyles.DoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {
                // Clear previous error messages
                UsernameErrorProvider.Clear();
                foreach (Control control in Controls)
                {
                    UsernameErrorProvider.SetError(control, string.Empty);
                }
                // Bind the form controls to the model properties
                _clientValidator.FirstName = NameTextBox.Text;
                _clientValidator.MiddleName = SecondNameTextBox.Text;
                _clientValidator.LastName = LastNameTextBox.Text;
                _clientValidator.Email = !string.IsNullOrEmpty(EmailTextBox.Text) ? EmailTextBox.Text : null;
                _clientValidator.Phone = !string.IsNullOrEmpty(PhoneTextBox.Text) ? PhoneTextBox.Text : null;
                _clientValidator.Address = AddressTextBox.Text;
                _clientValidator.ClientLegalType = LegalTypeTextBox.Text;

                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(_clientValidator);

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
                                    UsernameErrorProvider.SetError(control, result.ErrorMessage);
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
                nameof(_clientValidator.FirstName) => "NameTextBox",
                nameof(_clientValidator.MiddleName) => "SecondNameTextBox",
                nameof(_clientValidator.LastName) => "LastNameTextBox",
                nameof(_clientValidator.Email) => "EmailTextBox",
                nameof(_clientValidator.Phone) => "PhoneTextBox",
                nameof(_clientValidator.Address) => "AddressTextBox",
                nameof(_clientValidator.ClientLegalType) => "LegalTypeTextBox",
                _ => null
            };
        }





        private void AddClientForm_Load(object sender, EventArgs e)
        {
            GetClientDTO selectedClient = _dataService.getSelectedCLients()[0];
            NameTextBox.Text = selectedClient.FirstName;
            SecondNameTextBox.Text = selectedClient.MiddleName;
            LastNameTextBox.Text = selectedClient.LastName;
            PhoneTextBox.Text = selectedClient.Phone;
            AddressTextBox.Text = selectedClient.Address;
            EmailTextBox.Text = selectedClient.Email;
            LegalTypeTextBox.Text = selectedClient.ClientLegalType;
        }

        private async void AddClientButton_Click(object sender, EventArgs e)
        {
            EmailErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            PhoneErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            NameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            bool flag = false;
            ValidateModel();
            if (!string.IsNullOrEmpty(UsernameErrorProvider.GetError(EmailTextBox))) {
                EmailErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(UsernameErrorProvider.GetError(PhoneTextBox)))
            {
                PhoneErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(UsernameErrorProvider.GetError(NameTextBox)))
            {
                NameErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (flag) {
                return;
            }

            GetClientDTO editClient = _dataService.getSelectedCLients()[0];
            editClient.FirstName = NameTextBox.Text;
            editClient.MiddleName = SecondNameTextBox.Text;
            editClient.LastName = LastNameTextBox.Text;
            editClient.Phone = PhoneTextBox.Text;
            editClient.Email = EmailTextBox.Text;
            editClient.Address = AddressTextBox.Text;
            editClient.ClientLegalType = LegalTypeTextBox.Text;


            var result = await _userClient.EditClient(editClient);

            if (result.IsSuccess)
            {
                _dataService.editClient(editClient);
            }
            Close();
        }

        public CreateClientDTO getClientResponseObj() {
            return _clientDTO;
        }

    }
}
