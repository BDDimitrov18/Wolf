using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;
using WolfClient.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WolfClient.NewForms
{
    public partial class AddActivityTaskForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        public List<GetActivityTypeDTO> _activityTypesDTOs;
        private ExistingActivityAddTask currentExisting;
        private NonExistingActivityAddTask currentNonExisting;
        private bool existing = false;
        public AddActivityTaskForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityTypesDTOs = new List<GetActivityTypeDTO>();

            this.Text = GlobalSettings.FormTitle + " : Добавяне на дейности и задачи";
            this.Icon = new Icon(GlobalSettings.IconPath);

            ActivityChoiceComboBox.SelectedIndex = 1;

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
                if (existing)
                {
                    currentExisting.AddActivitySubmit_Click(new object(), new EventArgs());
                }
                else {
                    currentNonExisting.AddActivitySubmit_Click(new object(), new EventArgs());
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ActivityChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = ActivityChoiceComboBox.SelectedItem.ToString();
            UserControl selectedControl = null;

            switch (selectedItem)
            {
                case "От Налични Дейности":
                    var existingActivityControl = new ExistingActivityAddTask(_apiClient, _userClient, _adminClient, _dataService);
                    existingActivityControl.DisposeRequested += OnControlDisposeRequested;
                    selectedControl = existingActivityControl;
                    currentExisting = existingActivityControl;
                    existing = true;
                    break;

                case "Към Нова дейност":
                    var nonExistingActivityControl = new NonExistingActivityAddTask(_apiClient, _userClient, _adminClient, _dataService);
                    nonExistingActivityControl.DisposeRequested += OnControlDisposeRequested;
                    selectedControl = nonExistingActivityControl;
                    currentNonExisting = nonExistingActivityControl;
                    existing = false;
                    break;
            }

            LoadUserControl(selectedControl);
        }


        public void OnControlDisposeRequested(object sender, EventArgs e)
        {
            Dispose();
        }
        private void LoadUserControl(UserControl userControl)
        {
            if (AvailableChoicePanel.Controls.Count > 0)
            {
                AvailableChoicePanel.Controls[0].Dispose();
                AvailableChoicePanel.Controls.Clear();
            }

            if (userControl != null)
            {
                userControl.Dock = DockStyle.Fill;
                AvailableChoicePanel.Controls.Add(userControl);
            }
        }

        private void AddActivityTaskForm_Load(object sender, EventArgs e)
        {
        }
    }
}
