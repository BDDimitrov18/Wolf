﻿using DTOS.DTO;
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
        public AddActivityTaskForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityTypesDTOs = new List<GetActivityTypeDTO>();
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
                    selectedControl = new ExistingActivityAddTask(_apiClient, _userClient, _adminClient, _dataService);
                    selectedControl.Disposed += onControlDispose;
                    break;
                case "Към Нова дейност":
                    selectedControl = new NonExistingActivityAddTask(_apiClient, _userClient, _adminClient, _dataService);
                    selectedControl.Disposed += onControlDispose;
                    break;
            }

            LoadUserControl(selectedControl);
        }

        public void onControlDispose(object sender, EventArgs e)
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

        
    }
}
