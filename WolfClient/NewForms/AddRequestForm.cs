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
using System.Xml.Linq;
using WolfClient.Services.Interfaces;
using WolfClient.UserControls;

namespace WolfClient.NewForms
{
    public partial class AddRequestForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private List<CreateClientDTO> _clientsList;
        private List<GetClientDTO> _availableClientsList;
        public AddRequestForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _clientsList = new List<CreateClientDTO>();
            _availableClientsList = new List<GetClientDTO>();
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
            PriceOfRequestTextBox.Text = "0";
            AdvanceTextBox.Text = "0";
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
            string paymentStatus = createPaymentStatus(AdvanceTextBox.Text, PriceOfRequestTextBox.Text);
            CreateRequestDTO createRequestDTO = new CreateRequestDTO()
            {
                Price = float.Parse(PriceOfRequestTextBox.Text),
                PaymentStatus = paymentStatus,
                Advance = float.Parse(AdvanceTextBox.Text),
                Comments = CommentsRichTextBox.Text
            };
            List<CreateRequestDTO> requestDTOs = new List<CreateRequestDTO>();
            requestDTOs.Add(createRequestDTO);

            await _userClient.AddRequests(requestDTOs);

            List<GetClientDTO> SelectedClients = GetAllComboBoxClients(AvailableClientsFlowPanel);
            List<CreateClientDTO> newClientsToAdd = GetAllClientDtoFromLabels(NotAvailableClientsFlowPanel);

            newClientsToAdd.Count();
            if (newClientsToAdd.Count() > 0)
            {
                var response = await _userClient.AddClients(newClientsToAdd);
                if (response.IsSuccess)
                {
                    List<GetClientDTO> allClients = response.ResponseObj;
                    allClients.Concat(SelectedClients);

                }
                else
                {
                    MessageBox.Show("Could Add Nex Clients");
                }
            }
            
            Console.WriteLine("asd");
            Dispose();
        }

        private string createPaymentStatus(string advance, string price) {
            string paymentStatus;
            if (float.Parse(advance) == float.Parse(price))
            {
                paymentStatus = "Paid";
            }
            else if (float.Parse(advance) > 0)
            {
                paymentStatus = "Advance";
            }
            else
            {
                paymentStatus = "NotPaid";
            }

            return paymentStatus;
        }

        private List<GetClientDTO> GetAllComboBoxClients(Panel parentPanel)
        {
            List<GetClientDTO> comboBoxClients = new List<GetClientDTO>();
            foreach (Control panel in parentPanel.Controls) // Assuming 'parentPanel' is your main container panel
            {
                if (panel is Panel) // Check if the control is a Panel
                {
                    foreach (Control control in panel.Controls) // Access each control within the panel
                    {
                        if (control is ComboBox) // Check if the control is a ComboBox
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

        
    }
}

