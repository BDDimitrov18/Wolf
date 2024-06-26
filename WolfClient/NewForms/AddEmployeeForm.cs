using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class AddEmployeeForm : Form
    {

        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        private CreateEmployeeDTO _employeeValidation;
        public AddEmployeeForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            _employeeValidation = new CreateEmployeeDTO();
        }

        private void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {
                // Clear previous error messages
                EmployeeFormErrorProvider.Clear();

                // Bind the form controls to the model properties
                _employeeValidation.FirstName = NameTextBox.Text;
                _employeeValidation.SecondName = SecondNameTextBox.Text;
                _employeeValidation.LastName = LastNameTextBox.Text;
                _employeeValidation.Email = !string.IsNullOrEmpty(EmailTextBox.Text) ? EmailTextBox.Text : null;
                _employeeValidation.phone = !string.IsNullOrEmpty(PhoneTextBox.Text) ? PhoneTextBox.Text : null;


                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(_employeeValidation);

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
                                    EmployeeFormErrorProvider.SetError(control, result.ErrorMessage);
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
                        EmployeeFormErrorProvider.SetError(control, string.Empty);
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
                nameof(_employeeValidation.FirstName) => "NameTextBox",
                nameof(_employeeValidation.SecondName) => "SecondNameTextBox",
                nameof(_employeeValidation.LastName) => "LastNameTextBox",
                nameof(_employeeValidation.Email) => "EmailTextBox",
                nameof(_employeeValidation.phone) => "PhoneTextBox",
                _ => null
            };
        }



        private async void AddEmployeeSubmitButton_Click(object sender, EventArgs e)
        {
            ValidateModel();
            NameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            SurnameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            LastNameErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            PhoneErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            EmailErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            bool flag = false;
            ValidateModel();
            if (!string.IsNullOrEmpty(EmployeeFormErrorProvider.GetError(NameTextBox)))
            {
                NameErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(EmployeeFormErrorProvider.GetError(SecondNameTextBox)))
            {
                SurnameErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(EmployeeFormErrorProvider.GetError(LastNameTextBox)))
            {
                LastNameErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(EmployeeFormErrorProvider.GetError(PhoneTextBox)))
            {
                PhoneErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(EmployeeFormErrorProvider.GetError(EmailTextBox)))
            {
                EmailErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (flag) { return; }

            var employee = new CreateEmployeeDTO
            {
                FirstName = NameTextBox.Text,
                SecondName = SecondNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                phone = PhoneTextBox.Text,
                Email = EmailTextBox.Text
            };
            List<CreateEmployeeDTO> createEmployeeDTOs = new List<CreateEmployeeDTO>();
            createEmployeeDTOs.Add(employee);
           var response =  await _adminClient.AddEmployee(createEmployeeDTOs);
            _dataService.AddMultipleEmployees(response.ResponseObj);
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void SecondNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LastNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
