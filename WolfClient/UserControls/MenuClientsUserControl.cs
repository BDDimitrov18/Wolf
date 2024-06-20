using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.NewForms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class MenuClientsUserControl : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public MenuClientsUserControl(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClientForm addClientFrom = new AddClientForm(_apiClient, _userClient, _adminClient,true);
            addClientFrom.Show();
        }

        private void MenuClientsUserControl_Load(object sender, EventArgs e)
        {

        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var response = await _userClient.GetAllClients();
            if (response.IsSuccess)
            {
                var clients = response.ResponseObj;
                ClientsDataGridView.AutoGenerateColumns = false;
                ClientsDataGridView.DataSource = clients;
                ClientsDataGridView.Refresh();
            }
        }

        private void ClientsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
