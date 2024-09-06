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
    public partial class EditInvoiceForm : Form
    {
        private readonly IAdminClient _adminClient;
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IDataService _dataService;

        CreateInvoiceDTO _invoiceValidation;
        GetInvoiceDTO selectedInvoice;
        public EditInvoiceForm(IApiClient apiClient, IAdminClient adminClient, IUserClient userClient, IDataService dataService)
        {
            _adminClient = adminClient;
            _apiClient = apiClient;
            _userClient = userClient;
            _dataService = dataService;
            selectedInvoice = _dataService.getSelectedInvoices()[0];
            _invoiceValidation = new CreateInvoiceDTO();
            InitializeComponent();

            this.Text = GlobalSettings.FormTitle + " : Редактиране на фактура";
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
                AddButton_Click(new object(), new EventArgs());
            }
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
                if (SumTextBox.Text == "")
                {
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

            selectedInvoice.number = NumberTextBox.Text;
            selectedInvoice.Sum = float.Parse(SumTextBox.Text);

            var response = await _userClient.EditInvoice(selectedInvoice);

            _dataService.EditInvoice(selectedInvoice);
            Dispose();
        }

        private void EditInvoiceForm_Load(object sender, EventArgs e)
        {
            NumberTextBox.Text = selectedInvoice.number;
            SumTextBox.Text = selectedInvoice.Sum.ToString();
        }
    }
}
