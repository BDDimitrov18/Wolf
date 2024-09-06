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
        protected readonly IApiClient _apiClient;
        protected readonly IUserClient _userClient;
        protected readonly IAdminClient _adminClient;
        protected readonly IDataService _dataService;
        protected List<CreateClientDTO> _clientsList;
        protected List<GetClientDTO> _availableClientsList;

        protected GetRequestDTO _returnRequest;
        protected List<GetClientDTO> _returnClients;

        protected List<GetClientDTO> _InitialClients;

        protected CreateRequestDTO _requestValidator;



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

            if (GlobalSettings.IconPath != "")
            {
                this.Text = GlobalSettings.FormTitle + " : Редактиране на поръчка";
                this.Icon = new Icon(GlobalSettings.IconPath);


                this.KeyPreview = true;

                // Add the KeyDown event handler
                this.KeyDown += new KeyEventHandler(Form_KeyDown);
            }

            this.SetStyle(ControlStyles.DoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the ESC key was pressed
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Close the form
            }
            if (e.KeyCode == Keys.Enter)
            {
                AddRequestButton_Click(new object(), new EventArgs());
            }
        }


        public EditRequestForm() : this(null, null, null, null)
        {
            // Optionally, put some designer-specific initialization code here
            // This constructor won't be used in production, only in the designer
        }


        protected void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {
                // Clear previous error messages
                RequestErrorProvider.Clear();
                // Clear all error messages if validation passes
                foreach (Control control in Controls)
                {
                    RequestErrorProvider.SetError(control, string.Empty);
                }
                // Bind the form controls to the model properties
                _requestValidator.RequestName = NameOfRequestTextBox.Text;

                if (PriceOfRequestTextBox.Text != "")
                {
                    if (float.TryParse(PriceOfRequestTextBox.Text, out float price))
                    {
                        _requestValidator.Price = price;
                    }
                    else
                    {
                        RequestErrorProvider.SetError(PriceOfRequestTextBox, "Invalid Price format");
                    }
                }

                if (AdvanceTextBox.Text != "")
                {
                    if (float.TryParse(AdvanceTextBox.Text, out float advance))
                    {
                        _requestValidator.Advance = advance;
                    }
                    else
                    {
                        RequestErrorProvider.SetError(AdvanceTextBox, "Invalid Advance format");
                    }
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
            }
            finally
            {
                // Re-enable redrawing
                ResumeLayout();
            }
        }

        protected string GetControlNameForMember(string memberName)
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

        protected void AddNonExistingClientButton_Click(object sender, EventArgs e)
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

        protected virtual async void AddRequestForm_Load(object sender, EventArgs e)
        {
            if(_apiClient == null || _userClient == null || _adminClient == null || _dataService == null)
            {
                return;
            }
           
            var response = await _userClient.GetAllClients();
            if (response.IsSuccess)
            {
                _availableClientsList = response.ResponseObj.ToList();
            }
            if (_dataService.GetSelectedRequest().PaymentStatus != "Неопределен")
            {
                PriceOfRequestTextBox.Text = _dataService.GetSelectedRequest().Price.ToString();
                AdvanceTextBox.Text = _dataService.GetSelectedRequest().Advance.ToString();
            }
            else { 
                if(_dataService.GetSelectedRequest().Price.ToString() == "0")
                {
                    PriceOfRequestTextBox.Text = "";
                }
                else {
                    PriceOfRequestTextBox.Text = _dataService.GetSelectedRequest().Price.ToString();
                }
                if (_dataService.GetSelectedRequest().Advance.ToString() == "0")
                {
                    AdvanceTextBox.Text = "";
                }
                else {
                    AdvanceTextBox.Text = _dataService.GetSelectedRequest().Advance.ToString();
                }
            }
            NameOfRequestTextBox.Text = _dataService.GetSelectedRequest().RequestName;
            CommentsRichTextBox.Text = _dataService.GetSelectedRequest().Comments;

            List<GetClientDTO> clientDTOs = new List<GetClientDTO>(_dataService.getLinkedClients());
            _InitialClients = clientDTOs;
            foreach (var client in clientDTOs)
            {
                AddNewPanelWithUserControlAddClientsFromAvailable(client);
            }
            PathTextBox.Text = _dataService.GetSelectedRequest().Path;

            GetEmployeeDTO employeeDTO = new GetEmployeeDTO();
            employeeDTO.FullName = "";
           
            var employeesResponse = await _userClient.GetAllEmployees();
            List<GetEmployeeDTO> employees = new List<GetEmployeeDTO>(employeesResponse.ResponseObj);
            employees.Insert(0, employeeDTO);

            RequestCreatorComboBox.DataSource = employees;
            RequestCreatorComboBox.DisplayMember = "FullName";
            RequestCreatorComboBox.ValueMember = "EmployeeId";

            if (_dataService.GetSelectedRequest().RequestCreator != null)
            {
                RequestCreatorComboBox.SelectedValue = _dataService.GetSelectedRequest().RequestCreator.EmployeeId;
            }

        }

        protected void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        protected void ChooseClientToAddComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddClientComboBoxButton_Click(object sender, EventArgs e)
        {
            AddNewPanelWithUserControlAddClientsFromAvailable();
        }
        protected void AddNewPanelWithUserControlAddClientsFromAvailable()
        {
            Panel panel = new Panel();
            panel.Size = new Size(412, 28);  // Adjust size according to your needs
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromAvailable userControl = new AddClientFromAvailable(_apiClient, _userClient, _adminClient, _availableClientsList, panel);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            AvailableClientsFlowPanel.Controls.Add(panel);
        }

        protected void AddNewPanelWithUserControlAddClientsFromAvailable(GetClientDTO getClientDTO)
        {
            Panel panel = new Panel();
            panel.Size = new Size(412, 28);  // Adjust size according to your needs
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromAvailable userControl = new AddClientFromAvailable(_apiClient, _userClient, _adminClient, _availableClientsList, panel, getClientDTO);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            AvailableClientsFlowPanel.Controls.Add(panel);
        }

        protected void AddNewPanelWithUserControlAddClientsFromNotAvailable(CreateClientDTO clientDTO)
        {
            Panel panel = new Panel();
            panel.Size = new Size(410, 28);  // Adjust size according to your needs
            panel.BorderStyle = BorderStyle.FixedSingle;

            AddClientFromNotAvalable userControl = new AddClientFromNotAvalable(clientDTO, panel);
            userControl.Dock = DockStyle.Fill;  // Make the user control fill the panel
            panel.Controls.Add(userControl);

            NotAvailableClientsFlowPanel.Controls.Add(panel);
        }

        protected virtual async void AddRequestButton_Click(object sender, EventArgs e)
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
            foreach (GetClientDTO linkedClient in linkedClients)
            {
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
            editRequest.Path = PathTextBox.Text;
            
            editRequest.Price = PriceOfRequestTextBox.Text == "" ? 0 :float.Parse(PriceOfRequestTextBox.Text);
            editRequest.PaymentStatus = createPaymentStatus(AdvanceTextBox.Text, PriceOfRequestTextBox.Text);
            editRequest.Advance = AdvanceTextBox.Text == "" ? 0 : float.Parse(AdvanceTextBox.Text);
            editRequest.Comments = CommentsRichTextBox.Text;
            editRequest.RequestName = NameOfRequestTextBox.Text;
            editRequest.RequestCreatorId = (int)RequestCreatorComboBox.SelectedValue;
            //EditRequestLogic

            var responseRequest = await _userClient.EditRequest(editRequest);
            if (responseRequest.IsSuccess)
            {
                MessageBox.Show("Edited Successfully");
            }
            else
            {
                MessageBox.Show("Not Success");
                return;
            }

            if (!(_InitialClients == null || _InitialClients.Count() == 0))
            {
                await _userClient.DeleteClientRequest(client_RequestRelashionshipDTOs);
            }
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
                _dataService.EditRequest(editRequest);
                _dataService.SetEditedRequestClients(SelectedClients, editRequest);
                _returnRequest = _dataService.GetSelectedRequest();
                _returnClients = SelectedClients;
                DialogResult = DialogResult.OK;

            }
            else
            {
            }
            Close();
        }

        protected string createPaymentStatus(string advance, string price)
        {
            string paymentStatus;

            if (advance == "" || price == "")
            {
                paymentStatus = "Неопределен";
                return paymentStatus;
            }

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

        protected List<GetClientDTO> GetAllComboBoxClients(Panel parentPanel)
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

        protected List<CreateClientDTO> GetAllClientDtoFromLabels(Panel parentPanel)
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

       

        protected void openFilesButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;

                    // Set the PathTextBox.Text to the selected folder path
                    PathTextBox.Text = selectedFolderPath;
                }
            }
        }
    }
}

