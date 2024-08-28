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
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class AddInvoiceForm : Form
    {
        private readonly IAdminClient _adminClient;
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IDataService _dataService;

        CreateInvoiceDTO _invoiceValidation;
        public AddInvoiceForm(IApiClient apiClient, IAdminClient adminClient, IUserClient userClient, IDataService dataService)
        {
            _adminClient = adminClient;
            _apiClient = apiClient;
            _userClient = userClient;
            _dataService = dataService;
            _invoiceValidation = new CreateInvoiceDTO();
            InitializeComponent();
            this.Text = GlobalSettings.FormTitle + " : Добавяне на фактура";
            this.Icon = new Icon(GlobalSettings.IconPath);
        }
        private void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {
                // Clear previous error messages
                InvoiceErrorProvider.Clear();
                // Clear all error messages if validation passes
                foreach (Control control in Controls)
                {
                    InvoiceErrorProvider.SetError(control, string.Empty);
                }
                if (SumTextBox.Text == "") {
                    SumErrorLabel.Text = "Моля попълнете!";
                    InvoiceErrorProvider.SetError(SumTextBox, "Invalid Price format");
                }
                else if (float.TryParse(SumTextBox.Text, out float price))
                {
                    _invoiceValidation.Sum = price;
                }
                else
                {
                    SumErrorLabel.Text = "Моля спазвайте формата!";
                    InvoiceErrorProvider.SetError(SumTextBox, "Invalid Price format");
                }

                
                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(_invoiceValidation);

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
                                    InvoiceErrorProvider.SetError(control, result.ErrorMessage);
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
                nameof(_invoiceValidation.Sum) => "SumTextBox",
                _ => null
            };
        }
        private async void AddButton_Click(object sender, EventArgs e)
        {
            ValidateModel();


            SumErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            bool flag = false;
            ValidateModel();
            if (!string.IsNullOrEmpty(InvoiceErrorProvider.GetError(SumTextBox)))
            {
                SumErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            
            if (flag) { return; }

            CreateInvoiceDTO invoiceDTO = new CreateInvoiceDTO()
            {
                number = NumberTextBox.Text,
                RequestId = _dataService.GetSelectedRequest().RequestId,
                Sum = float.Parse(SumTextBox.Text)
            };

            var response = await _userClient.CreateInvoice(invoiceDTO);

            _dataService.AddInvoice(response.ResponseObj);
            Dispose();
        }
    }
}
