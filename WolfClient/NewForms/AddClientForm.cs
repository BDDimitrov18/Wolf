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
    public partial class AddClientForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;

        private readonly bool _canCreate;

        private CreateClientDTO _clientDTO;
        private GetClientDTO _getClientDTO;

        private CreateClientDTO _clientValidator;
        public AddClientForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, bool canCreate)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _canCreate = canCreate;
            _getClientDTO = new GetClientDTO();

            _clientValidator = new CreateClientDTO();

            this.Text = GlobalSettings.FormTitle + " : Добавяне на клиент";
            this.Icon = new Icon(GlobalSettings.IconPath);

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
            
            var client = new CreateClientDTO
            {
                FirstName = NameTextBox.Text,
                MiddleName = SecondNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text,
                Address = AddressTextBox.Text,
                ClientLegalType = LegalTypeTextBox.Text
            };
            if (!_canCreate)
            {
                _clientDTO = client;
                DialogResult = DialogResult.OK;
            }
            else {
                List<CreateClientDTO> clientsList = new List<CreateClientDTO>();
                clientsList.Add(client);
                var responseClient = await _userClient.AddClients(clientsList);
                _getClientDTO = responseClient.ResponseObj[0];
                DialogResult = DialogResult.OK;
            }
            Close();
        }

        public CreateClientDTO getClientResponseObj() {
            return _clientDTO;
        }
        public GetClientDTO returnGetClientResponseObj() {
            return _getClientDTO;
        }

    }
}
