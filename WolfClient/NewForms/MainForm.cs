using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolf;
using WolfClient.Services;
using WolfClient.Services.Interfaces;
using WolfClient.UserControls;

namespace WolfClient.NewForms
{
    public partial class MainForm : Form
    {

        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        private MenuRequestsUserControl _requestsUserControl;
        private MenuClientsUserControl _clientsUserControl;
        private MenuEmployeesUserControl _employeesUserControl;

        public MainForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService, 
            MenuRequestsUserControl requestsUserControl, MenuClientsUserControl clientsUserControl, MenuEmployeesUserControl employeesUserControl)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;

            _requestsUserControl = requestsUserControl;
            _clientsUserControl = clientsUserControl;
            _employeesUserControl = employeesUserControl;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }



        private void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            panelContent.Controls.Clear();

            // Set the Dock property to Fill to make it responsive
            userControl.Dock = DockStyle.Fill;

            // Add the new UserControl
            panelContent.Controls.Add(userControl);
        }


        private void RequestToolStripButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(_requestsUserControl);
        }

        

        private void ClientsStripButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(_clientsUserControl);
        }

        private void EmployeesStripLabel_Click(object sender, EventArgs e)
        {
            LoadUserControl(_employeesUserControl);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(_apiClient, _userClient, _adminClient);
            loginForm.Show();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
