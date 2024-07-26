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
using WolfClient.Services;
using WolfClient.Services.Interfaces;
using WolfClient.UserControls;

namespace WolfClient.NewForms
{
    public partial class EditRequestForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;
        private List<CreateClientDTO> _clientsList;
        private List<GetClientDTO> _availableClientsList;

        private GetRequestDTO _returnRequest;
        private List<GetClientDTO> _returnClients;

        private CreateRequestDTO _requestValidator;



        public EditRequestForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _clientsList = new List<CreateClientDTO>();
            _availableClientsList = new List<GetClientDTO>();

            _dataService = dataService; 
            _requestValidator = new CreateRequestDTO();

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
                RequestErrorProvider.Clear();

                // Bind the form controls to the model properties
                _requestValidator.RequestName = NameOfRequestTextBox.Text;

                if (float.TryParse(PriceOfRequestTextBox.Text, out float price))
                {
                    _requestValidator.Price = price;
                }
                else
                {
                    RequestErrorProvider.SetError(PriceOfRequestTextBox, "Invalid Price format");
                }

                if (float.TryParse(AdvanceTextBox.Text, out float advance))
                {
                    _requestValidator.Advance = advance;
                }
                else
                {
                    RequestErrorProvider.SetError(AdvanceTextBox, "Invalid Advance format");
                }
                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(_requestValidator);

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
                                    RequestErrorProvider.SetError(control, result.ErrorMessage);
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
                        RequestErrorProvider.SetError(control, string.Empty);
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
                nameof(_requestValidator.RequestName) => "NameOfRequestTextBox",
                nameof(_requestValidator.Price) => "PriceOfRequestTextBox",
                nameof(_requestValidator.Advance) => "AdvanceTextBox",
                nameof(_requestValidator.Comments) => "CommentsRichTextBox",
                _ => null
            };
        }

        private void AddNonExistingClientButton_Click(object sender, EventArgs e)
        {
            using (AddClientForm form = new AddClientForm(_apiClient, _userClient, _adminClient, false))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CreateClientDTO clientDTO = form.getClientResponseObj();
                    _clientsList.Add(clientDTO);
                    AddNewPanelWithUserControlAddClientsFromNotAvailable(clientDTO);
                }
            } // 
        }

        private async void AddRequestForm_Load(object sender, EventArgs e)
        {
            var response = await _userClient.GetAllClients();
            if (response.IsSuccess)
            {
                _availableClientsList = response.ResponseObj.ToList();
            }
            PriceOfRequestTextBox.Text = _dataService.GetSelectedRequest().Price.ToString();
            AdvanceTextBox.Text = _dataService.GetSelectedRequest().Advance.ToString();
            NameOfRequestTextBox.Text = _dataService.GetSelectedRequest().RequestName;
            CommentsRichTextBox.Text = _dataService.GetSelectedRequest().Comments;

            List<GetClientDTO> clientDTOs = new List<GetClientDTO>(_dataService.getLinkedClients());
            foreach(var client in clientDTOs) {
                AddNewPanelWithUserControlAddClientsFromAvailable(client);
            }

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void ChooseClientToAddComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddClientComboBoxButton_Click(object sender, EventArgs e)
        {
            AddNewPanelWithUserControlAddClientsFromAvailable();
        }
        private void AddNewPanelWithUserControlAddClientsFromAvailable()
        {
            Panel panel = new Panel();
            panel.Size = new Size(412, 28);  // Adjust size according to your needs
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromAvailable userControl = new AddClientFromAvailable(_apiClient, _userClient, _adminClient, _availableClientsList, panel);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            AvailableClientsFlowPanel.Controls.Add(panel);
        }

        private void AddNewPanelWithUserControlAddClientsFromAvailable(GetClientDTO getClientDTO)
        {
            Panel panel = new Panel();
            panel.Size = new Size(412, 28);  // Adjust size according to your needs
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromAvailable userControl = new AddClientFromAvailable(_apiClient, _userClient, _adminClient, _availableClientsList, panel, getClientDTO);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            AvailableClientsFlowPanel.Controls.Add(panel);
        }

        private void AddNewPanelWithUserControlAddClientsFromNotAvailable(CreateClientDTO clientDTO)
        {
            Panel panel = new Panel();
            panel.Size = new Size(410, 28);  // Adjust size according to your needs
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromNotAvalable userControl = new AddClientFromNotAvalable(clientDTO, panel);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            NotAvailableClientsFlowPanel.Controls.Add(panel);
        }

        private async void AddRequestButton_Click(object sender, EventArgs e)
        {
            ValidateModel();

            NameOfRequestErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            AdvancePriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            FinalPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            bool flag = false;
            ValidateModel();
            if (!string.IsNullOrEmpty(RequestErrorProvider.GetError(NameOfRequestTextBox)))
            {
                NameOfRequestErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(RequestErrorProvider.GetError(PriceOfRequestTextBox)))
            {
                FinalPriceErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(RequestErrorProvider.GetError(AdvanceTextBox)))
            {
                AdvancePriceErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (flag) { return; }

            List<GetClient_RequestRelashionshipDTO> client_RequestRelashionshipDTOs = new List<GetClient_RequestRelashionshipDTO>();
            List<GetClientDTO> linkedClients = _dataService.getLinkedClients();
            foreach (GetClientDTO linkedClient in linkedClients) {
                GetClient_RequestRelashionshipDTO relashionship = new GetClient_RequestRelashionshipDTO()
                {
                    Request = _dataService.GetSelectedRequest(),
                    RequestId = _dataService.GetSelectedRequest().RequestId,
                    Client = linkedClient,
                    ClientId = linkedClient.ClientId
                };

                client_RequestRelashionshipDTOs.Add(relashionship);
            }
            GetRequestDTO editRequest = new GetRequestDTO();
            editRequest = _dataService.GetSelectedRequest();
            editRequest.Price = float.Parse(PriceOfRequestTextBox.Text);
            editRequest.PaymentStatus = createPaymentStatus(AdvanceTextBox.Text, PriceOfRequestTextBox.Text); 
            editRequest.Advance = float.Parse(AdvanceTextBox.Text);
            editRequest.Comments = CommentsRichTextBox.Text;
            editRequest.RequestName = NameOfRequestTextBox.Text;
            //EditRequestLogic

            var responseRequest = await _userClient.EditRequest(editRequest);
            if (responseRequest.IsSuccess)
            {
                MessageBox.Show("Edited Successfully");
            }
            else {
                MessageBox.Show("Not Success");
                return;
            }


            await _userClient.DeleteClientRequest(client_RequestRelashionshipDTOs);
            List<GetClientDTO> SelectedClients = GetAllComboBoxClients(AvailableClientsFlowPanel);
            List<CreateClientDTO> newClientsToAdd = GetAllClientDtoFromLabels(NotAvailableClientsFlowPanel);

            if (newClientsToAdd.Count() > 0)
            {
                var response = await _userClient.AddClients(newClientsToAdd);
                if (response.IsSuccess)
                {
                    SelectedClients.AddRange(response.ResponseObj);
                }
            }
            var linkResponse = await _userClient.LinkClientsWithRequest(_dataService.GetSelectedRequest(), SelectedClients);
            if (linkResponse.IsSuccess)
            {
                MessageBox.Show("Success");
                _dataService.EditRequest(editRequest);
                _dataService.SetEditedRequestClients(SelectedClients,editRequest);
                _returnRequest = _dataService.GetSelectedRequest();
                _returnClients = SelectedClients;
                DialogResult = DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Not Success");
            }
            Close();
        }

        private string createPaymentStatus(string advance, string price)
        {
            string paymentStatus;
            if (float.Parse(advance) == float.Parse(price))
            {
                paymentStatus = "Платен";
            }
            else if (float.Parse(advance) > 0)
            {
                paymentStatus = "Аванс";
            }
            else
            {
                paymentStatus = "Не платен";
            }

            return paymentStatus;
        }

        private List<GetClientDTO> GetAllComboBoxClients(Panel parentPanel)
        {
            List<GetClientDTO> comboBoxClients = new List<GetClientDTO>();
            foreach (Panel panel in parentPanel.Controls.OfType<Panel>()) // Assuming 'parentPanel' is your main container panel
            {
                foreach (AddClientFromAvailable userControl in panel.Controls.OfType<AddClientFromAvailable>())
                {
                    foreach (Control control in userControl.Controls)
                    {
                        if (control is ComboBox)
                        {
                            ComboBox comboBox = control as ComboBox;
                            if (comboBox.SelectedItem != null)
                            {
                                // Assuming the value is the object itself or perhaps the Tag property is used
                                GetClientDTO item = comboBox.SelectedItem as GetClientDTO;
                                comboBoxClients.Add(item);
                            }
                        }
                    }

                }
            }
            return comboBoxClients;
        }

        private List<CreateClientDTO> GetAllClientDtoFromLabels(Panel parentPanel)
        {
            List<CreateClientDTO> clientDTOs = new List<CreateClientDTO>();
            foreach (Panel panel in parentPanel.Controls.OfType<Panel>())
            {
                // Now iterate over user controls within each panel
                foreach (AddClientFromNotAvalable userControl in panel.Controls.OfType<AddClientFromNotAvalable>())
                {
                    // Access the UserData property of each user control
                    CreateClientDTO client = userControl._clientObject;
                    clientDTOs.Add(client);
                }
            }
            return clientDTOs;
        }

        public GetRequestDTO returnRequest()
        {
            return _returnRequest;
        }
        public List<GetClientDTO> returnClients()
        {
            return _returnClients;
        }

        private void AddRequestTitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

