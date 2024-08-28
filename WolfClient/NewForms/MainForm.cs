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

        private readonly MenuRequestsUserControlActive _menuRequestsUserControlActive;
        private readonly MenuRequestsUserControlArchive _menuRequestsUserControlArchive;
        private MenuClientsUserControl _clientsUserControl;

        private string _ArchiveStatus;

        public MainForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService,
            IFileUploader fileUploader, WebSocketClientService websocketClientService, string ArchiveStatus)
        {
            InitializeComponent();

            this.Text = GlobalSettings.FormTitle + " : Управление на поръчки";
            this.Icon = new Icon(GlobalSettings.IconPath);

            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;

            MenuClientsUserControl menuClientsUserControl = new MenuClientsUserControl(apiClient, userClient, adminClient, dataService);

            if (ArchiveStatus == "Active")
            {
                _menuRequestsUserControlActive = new MenuRequestsUserControlActive(apiClient, userClient, adminClient, dataService, fileUploader);
                this.Text = "Wolf : Управление на поръчки"; // Change the form's title
            }
            else if (ArchiveStatus == "Archive")
            {
                _menuRequestsUserControlArchive = new MenuRequestsUserControlArchive(apiClient, userClient, adminClient, dataService, fileUploader);
                this.Text = "Wolf Archive : Управление на поръчки"; // Change the form's title
            }



            _clientsUserControl = new MenuClientsUserControl(apiClient, userClient, adminClient, dataService);
            _fileUploader = fileUploader;
            _websocketClientService = websocketClientService;

            _ArchiveStatus = ArchiveStatus;

            LogInEvent.logIn += OnUserLoggedIn;
            UserLabel.TextChanged += ResizePanelToFitLabel;
            RequestToolStripButton_Click(new object { }, new EventArgs());

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
            if (userControl is MenuRequestsUserControlBase requestsUserControl)
            {
                requestsUserControl.UpdateRequestDataGridView(_dataService.getRequests());
            }
        }


        private void RequestToolStripButton_Click(object sender, EventArgs e)
        {
            if (_ArchiveStatus == "Active") {
                this.Text = "Wolf : Управление на поръчки";
                LoadUserControl(_menuRequestsUserControlActive);
            }
            else if(_ArchiveStatus == "Archive")
            {
                this.Text = "Wolf Archive : Управление на поръчки";
                LoadUserControl(_menuRequestsUserControlArchive);
            }
        }

        private void ClientsStripButton_Click(object sender, EventArgs e)
        {
            if (_ArchiveStatus == "Active")
            {
                this.Text = "Wolf : Управление на клиенти";
            }
            else if (_ArchiveStatus == "Archive")
            {
                this.Text = "Wolf Archive : Управление на клиенти";
            }
            LoadUserControl(_clientsUserControl);
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

        private void SpravkiButton_Click(object sender, EventArgs e)
        {
            string role = _dataService.getRole();
            if (role == "admin")
            {
                if (_ArchiveStatus == "Archive")
                {
                    inqueriesAdminForm form = new inqueriesAdminForm(_userClient, _apiClient, _dataService, _adminClient);
                    form.Show();
                }
                else if(_ArchiveStatus == "Active") {
                    inqueriesAdminFormActive form = new inqueriesAdminFormActive(_userClient, _apiClient, _dataService, _adminClient);
                    form.Show();
                }
            }
            else if(role == "user") {
                if (_ArchiveStatus == "Archive")
                {
                    inqueriesUserForm form = new inqueriesUserForm(_userClient, _apiClient, _dataService, _adminClient);
                    form.Show();
                }
                else if (_ArchiveStatus == "Active")
                {
                    inqueriesUserFormActive form = new inqueriesUserFormActive(_userClient, _apiClient, _dataService, _adminClient);
                    form.Show();
                }
            }
        }
    }
}
