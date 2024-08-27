using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.NewForms
{
    public partial class EditRequestFormArchive : EditRequestForm
    {
        public EditRequestFormArchive(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        : base(apiClient, userClient, adminClient, dataService)
        {
            InitializeComponent();
        }

        protected override async void AddRequestForm_Load(object sender, EventArgs e)
        {
            if (_apiClient == null || _userClient == null || _adminClient == null || _dataService == null)
            {
                return;
            }

            var response = await _userClient.GetAllClients();
            if (response.IsSuccess)
            {
                _availableClientsList = response.ResponseObj.ToList();
            }
            PriceOfRequestTextBox.Text = _dataService.GetSelectedRequest().Price.ToString();
            AdvanceTextBox.Text = _dataService.GetSelectedRequest().Advance.ToString();
            NameOfRequestTextBox.Text = _dataService.GetSelectedRequest().RequestName;
            CommentsRichTextBox.Text = _dataService.GetSelectedRequest().Comments;
            ArchiveStatusComboBox.SelectedItem = _dataService.GetSelectedRequest().Status;
            List<GetClientDTO> clientDTOs = new List<GetClientDTO>(_dataService.getLinkedClients());
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

        protected override async void AddRequestButton_Click(object sender, EventArgs e)
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
            editRequest.Price = float.Parse(PriceOfRequestTextBox.Text);
            editRequest.PaymentStatus = createPaymentStatus(AdvanceTextBox.Text, PriceOfRequestTextBox.Text);
            editRequest.Advance = float.Parse(AdvanceTextBox.Text);
            editRequest.Comments = CommentsRichTextBox.Text;
            editRequest.RequestName = NameOfRequestTextBox.Text;
            editRequest.RequestCreatorId = (int)RequestCreatorComboBox.SelectedValue;
            editRequest.Status = ArchiveStatusComboBox.SelectedItem.ToString();
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
                _dataService.SetEditedRequestClients(SelectedClients, editRequest);
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
    }
}
