using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolf;
using WolfClient.Events;
using WolfClient.Events.EventArgs;
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
        private readonly IFileUploader _fileUploader;
        private readonly WebSocketClientService _websocketClientService;
        private MenuRequestsUserControl _requestsUserControl;
        private MenuClientsUserControl _clientsUserControl;
        private MenuEmployeesUserControl _employeesUserControl;

        public MainForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService,
            MenuRequestsUserControl requestsUserControl, MenuClientsUserControl clientsUserControl, MenuEmployeesUserControl employeesUserControl,
            IFileUploader fileUploader, WebSocketClientService websocketClientService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;

            _requestsUserControl = requestsUserControl;
            _clientsUserControl = clientsUserControl;
            _employeesUserControl = employeesUserControl;
            _fileUploader = fileUploader;
            _websocketClientService = websocketClientService;

            LogInEvent.logIn += OnUserLoggedIn;
            UserLabel.TextChanged += ResizePanelToFitLabel;
        }
        private async void OnUserLoggedIn(object sender, LogInEventArgs e)
        {
            UserLabel.Text = $"Потребител: {_dataService.getLoggedEmployee().FullName}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void ResizePanelToFitLabel(object sender, EventArgs e)
        {
            // Calculate the new panel width based on the text length
            using (Graphics g = UserLabel.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(UserLabel.Text, UserLabel.Font);
                int newPanelWidth = (int)textSize.Width; // Add padding
                UserLabel.Width = newPanelWidth;
            }

            // Center the label within the panel
            int Previouswidth = UserPanel.Width;
            UserPanel.Width = UserLabel.Width;
            UserPanel.Location = new Point(UserPanel.Location.X + Previouswidth - UserPanel.Width, UserPanel.Location.Y);
        }

        private void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            panelContent.Controls.Clear();

            // Set the Dock property to Fill to make it responsive
            userControl.Dock = DockStyle.Fill;

            // Add the new UserControl
            panelContent.Controls.Add(userControl);

            // If it's a MenuRequestsUserControl, trigger data and style reapplication
            if (userControl is MenuRequestsUserControl requestsUserControl)
            {
                requestsUserControl.UpdateRequestDataGridView(_dataService.getRequests());
            }
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
            LoginForm loginForm = new LoginForm(_apiClient, _userClient, _adminClient, _fileUploader, _websocketClientService, _dataService);
            loginForm.Show();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void DocumentViewer_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
