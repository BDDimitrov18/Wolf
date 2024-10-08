﻿using DTOS.DTO;
using WolfClient.inqueries;
using WolfClient.Services.Interfaces;
using WolfClient.TemplateClasses;
using WolfClient.ViewModels;

namespace WolfClient.NewForms
{
    public partial class inqueriesAdminForm : Form
    {
        protected readonly IAdminClient _adminClient;
        protected readonly IUserClient _userClient;
        protected readonly IApiClient _apiClient;
        protected readonly IDataService _dataService;

        protected List<ActivityTypeSelection> _activityTypeSelections;
        protected List<TaskTypeSelection> _taskTypeSelections;

        protected bool _isSelectingAllActivities = false;
        protected List<ActivityTypeSelection> _previouslySelectedActivities;
        protected bool _allItemsManuallySelected = false;
        protected bool _allItemsSelectedBeforeToggle = false;

        protected bool _isSelectingAllTasks = false;
        protected List<TaskTypeSelection> _previouslySelectedTasks;
        protected bool _allTasksManuallySelected = false;
        protected bool _allTasksSelectedBeforeToggle = false;

        protected bool _isSelectingAllEmployees = false;
        protected List<EmployeeListItem> _previouslySelectedEmployees;
        protected bool _allEmployeesManuallySelected = false;
        protected bool _allEmployeesSelectedBeforeToggle = false;

        protected bool _isSelectingAllPaymentStatuses = false;
        protected bool _allPaymentStatusesManuallySelected = false;
        protected bool _allPaymentStatusesSelectedBeforeToggle = false;

        protected bool _isSelectingAllTaskStatuses = false;
        protected bool _allTaskStatusesManuallySelected = false;
        protected bool _allTaskStatusesSelectedBeforeToggle = false;

        protected List<EmployeeListItem> _employeeSelections;

        public inqueriesAdminForm(IUserClient userClient, IApiClient apiClient, IDataService dataService, IAdminClient adminClient)
        {
            InitializeComponent();
            if (GlobalSettings.IconPath != "")
            {
                this.Text = GlobalSettings.FormTitle + " : Справки Админ";
                this.Icon = new Icon(GlobalSettings.IconPath);

                this.KeyPreview = true;

                // Add the KeyDown event handler
                this.KeyDown += new KeyEventHandler(Form_KeyDown);
            }

            _userClient = userClient;
            _apiClient = apiClient;
            _dataService = dataService;
            _adminClient = adminClient;

            _employeeSelections = new List<EmployeeListItem>();

            textBox1.TextChanged += new EventHandler(textBoxActivityTypeFilter_TextChanged);
            textBox2.TextChanged += new EventHandler(textBoxTaskTypeFilter_TextChanged);

            checkedListBox3.ItemCheck += new ItemCheckEventHandler(checkedListBox3_ItemCheck);
            checkedListBox4.ItemCheck += new ItemCheckEventHandler(checkedListBox4_ItemCheck);
            employeesCheckBoxList.ItemCheck += new ItemCheckEventHandler(employeesCheckBoxList_ItemCheck);

            allActivityCheckBox.CheckedChanged += new EventHandler(allActivityCheckBox_CheckedChanged);
            allTasksButton.CheckedChanged += new EventHandler(allTasksButton_CheckedChanged);
            allEmployeesCheckBox.CheckedChanged += new EventHandler(allEmployeesCheckBox_CheckedChanged);

            allPaymentStatusCheckBox.CheckedChanged += new EventHandler(allPaymentStatusCheckBox_CheckedChanged);
            taskStatusAllCheckBox.CheckedChanged += new EventHandler(taskStatusAllCheckBox_CheckedChanged);

            this.Load += new EventHandler(inquiriesAdminForm_Load);

            AllTasksInqueri.Click += ExportFilteredRequests;

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
                ExportFilteredRequests(new object(), new EventArgs());
            }
        }
        public inqueriesAdminForm() : this(null, null, null, null)
        {
            // Optionally, put some designer-specific initialization code here
            // This constructor won't be used in production, only in the designer
        }

        protected async void inquiriesAdminForm_Load(object sender, EventArgs e)
        {
            if (_userClient == null || _apiClient == null || _dataService == null || _adminClient == null)
            {
                return;
            }
            await InitializeForm();
        }

        protected async Task InitializeForm()
        {
            var response = await _userClient.GetActivityTypes();
            _activityTypeSelections = response.ResponseObj.Select(a => new ActivityTypeSelection
            {
                ActivityTypeID = a.ActivityTypeID,
                ActivityTypeName = a.ActivityTypeName,
                IsSelected = true,
                TaskTypeSelections = a.TaskTypes.Select(t => new TaskTypeSelection
                {
                    TaskTypeId = t.TaskTypeId,
                    TaskTypeName = t.TaskTypeName,
                    IsSelected = true
                }).ToList()
            }).ToList();

            _taskTypeSelections = _activityTypeSelections.SelectMany(a => a.TaskTypeSelections).Distinct().ToList();

            allActivityCheckBox.Checked = true;
            allTasksButton.Checked = true;

            allPaymentStatusCheckBox.Checked = true;
            taskStatusAllCheckBox.Checked = true;

            _previouslySelectedActivities = new List<ActivityTypeSelection>(_activityTypeSelections);
            _previouslySelectedTasks = new List<TaskTypeSelection>(_taskTypeSelections);

            PopulateActivityTypes();
            PopulateTaskTypes();

            var employeesResponse = await _userClient.GetAllEmployees();
            var employeesList = employeesResponse.ResponseObj as List<GetEmployeeDTO>;

            _employeeSelections = employeesList.Select(emp => new EmployeeListItem
            {
                EmployeeId = emp.EmployeeId,
                FullName = emp.FullName,
                IsSelected = true
            }).ToList();

            allEmployeesCheckBox.Checked = true;

            _previouslySelectedEmployees = new List<EmployeeListItem>(_employeeSelections);

            PopulateEmployees();
        }

        protected void PopulateActivityTypes()
        {
            checkedListBox3.Items.Clear();

            checkedListBox3.DisplayMember = "ActivityTypeName";
            checkedListBox3.ValueMember = "ActivityTypeID";

            foreach (var activitySelection in _activityTypeSelections)
            {
                checkedListBox3.Items.Add(activitySelection, activitySelection.IsSelected);
            }

            UpdateTaskTypesBasedOnActivities();
        }

        protected void PopulateTaskTypes()
        {
            checkedListBox4.Items.Clear();

            checkedListBox4.DisplayMember = "TaskTypeName";
            checkedListBox4.ValueMember = "TaskTypeId";

            foreach (var taskSelection in _taskTypeSelections)
            {
                checkedListBox4.Items.Add(taskSelection, taskSelection.IsSelected);
            }
        }

        protected void PopulateEmployees()
        {
            employeesCheckBoxList.Items.Clear();

            employeesCheckBoxList.DisplayMember = "FullName";
            employeesCheckBoxList.ValueMember = "EmployeeId";

            foreach (var employeeSelection in _employeeSelections)
            {
                employeesCheckBoxList.Items.Add(employeeSelection, employeeSelection.IsSelected);
            }
        }

        protected void FilterActivityTypes()
        {
            string filterText = textBox1.Text.ToLower();

            var filteredActivitySelections = _activityTypeSelections
                .Where(a => a.ActivityTypeName.ToLower().Contains(filterText))
                .ToList();

            checkedListBox3.Items.Clear();
            foreach (var activitySelection in filteredActivitySelections)
            {
                checkedListBox3.Items.Add(activitySelection, activitySelection.IsSelected);
            }

            if (allActivityCheckBox.Checked)
            {
                SelectAllActivityTypes(true);
            }

            UpdateTaskTypesBasedOnActivities();
        }

        protected void FilterTaskTypes()
        {
            string filterText = textBox2.Text.ToLower();

            var filteredTaskSelections = _taskTypeSelections
                .Where(t => t.TaskTypeName.ToLower().Contains(filterText))
                .ToList();

            checkedListBox4.Items.Clear();
            foreach (var taskSelection in filteredTaskSelections)
            {
                checkedListBox4.Items.Add(taskSelection, taskSelection.IsSelected);
            }

            if (allTasksButton.Checked)
            {
                SelectAllTaskTypes(true);
            }
        }

        protected void textBoxActivityTypeFilter_TextChanged(object sender, EventArgs e)
        {
            FilterActivityTypes();
        }

        protected void textBoxTaskTypeFilter_TextChanged(object sender, EventArgs e)
        {
            FilterTaskTypes();
        }

        protected void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isSelectingAllActivities) return;

            var activitySelection = checkedListBox3.Items[e.Index] as ActivityTypeSelection;
            if (activitySelection != null)
            {
                activitySelection.IsSelected = e.NewValue == CheckState.Checked;
            }

            if (e.NewValue == CheckState.Unchecked)
            {
                _isSelectingAllActivities = true;
                allActivityCheckBox.Checked = false;
                _isSelectingAllActivities = false;
                _allItemsManuallySelected = false;
                _allItemsSelectedBeforeToggle = false;
            }

            if (checkedListBox3.CheckedItems.Count == checkedListBox3.Items.Count - 1 && e.NewValue == CheckState.Checked && !allActivityCheckBox.Checked)
            {
                _allItemsManuallySelected = true;
            }

            _previouslySelectedActivities = _activityTypeSelections.Where(a => a.IsSelected).ToList();

            UpdateTaskTypesBasedOnActivities();
        }

        protected void checkedListBox4_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isSelectingAllTasks) return;

            var taskSelection = checkedListBox4.Items[e.Index] as TaskTypeSelection;
            if (taskSelection != null)
            {
                taskSelection.IsSelected = e.NewValue == CheckState.Checked;
            }

            if (e.NewValue == CheckState.Unchecked)
            {
                _isSelectingAllTasks = true;
                allTasksButton.Checked = false;
                _isSelectingAllTasks = false;
                _allTasksManuallySelected = false;
                _allTasksSelectedBeforeToggle = false;
            }

            if (checkedListBox4.CheckedItems.Count == checkedListBox4.Items.Count - 1 && e.NewValue == CheckState.Checked && !allTasksButton.Checked)
            {
                _allTasksManuallySelected = true;
            }

            _previouslySelectedTasks = _taskTypeSelections.Where(t => t.IsSelected).ToList();
        }

        protected void employeesCheckBoxList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isSelectingAllEmployees) return;

            var employeeSelection = employeesCheckBoxList.Items[e.Index] as EmployeeListItem;
            if (employeeSelection != null)
            {
                employeeSelection.IsSelected = e.NewValue == CheckState.Checked;
            }

            if (e.NewValue == CheckState.Unchecked)
            {
                _isSelectingAllEmployees = true;
                allEmployeesCheckBox.Checked = false;
                _isSelectingAllEmployees = false;
                _allEmployeesManuallySelected = false;
                _allEmployeesSelectedBeforeToggle = false;
            }

            if (employeesCheckBoxList.CheckedItems.Count == employeesCheckBoxList.Items.Count - 1 && e.NewValue == CheckState.Checked && !allEmployeesCheckBox.Checked)
            {
                _allEmployeesManuallySelected = true;
            }

            _previouslySelectedEmployees = _employeeSelections.Where(e => e.IsSelected).ToList();
        }

        protected void allActivityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSelectingAllActivities) return;

            _isSelectingAllActivities = true;

            if (allActivityCheckBox.Checked)
            {
                if (!_allItemsSelectedBeforeToggle)
                {
                    _previouslySelectedActivities = _activityTypeSelections.Where(a => a.IsSelected).ToList();
                    _allItemsSelectedBeforeToggle = AreAllItemsCurrentlySelected();
                }

                foreach (var activitySelection in _activityTypeSelections)
                {
                    var isVisible = checkedListBox3.Items.Cast<ActivityTypeSelection>().Any(i => i.ActivityTypeID == activitySelection.ActivityTypeID);
                    if (isVisible)
                    {
                        activitySelection.IsSelected = true;
                        int index = checkedListBox3.Items.Cast<ActivityTypeSelection>().ToList().FindIndex(i => i.ActivityTypeID == activitySelection.ActivityTypeID);
                        checkedListBox3.SetItemChecked(index, true);
                    }
                }

                _allItemsManuallySelected = false;
            }
            else
            {
                if (_allItemsManuallySelected || _allItemsSelectedBeforeToggle)
                {
                    foreach (var activitySelection in _activityTypeSelections)
                    {
                        var isVisible = checkedListBox3.Items.Cast<ActivityTypeSelection>().Any(i => i.ActivityTypeID == activitySelection.ActivityTypeID);
                        if (isVisible)
                        {
                            activitySelection.IsSelected = false;
                            int index = checkedListBox3.Items.Cast<ActivityTypeSelection>().ToList().FindIndex(i => i.ActivityTypeID == activitySelection.ActivityTypeID);
                            checkedListBox3.SetItemChecked(index, false);
                        }
                    }

                    _previouslySelectedActivities.Clear();
                    _allItemsManuallySelected = false;
                }
                else
                {
                    RestorePreviousActivitySelections();
                }
            }

            _isSelectingAllActivities = false;

            UpdateTaskTypesBasedOnActivities();
        }

        protected void allTasksButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSelectingAllTasks) return;

            _isSelectingAllTasks = true;

            if (allTasksButton.Checked)
            {
                if (!_allTasksSelectedBeforeToggle)
                {
                    _previouslySelectedTasks = _taskTypeSelections.Where(t => t.IsSelected).ToList();
                    _allTasksSelectedBeforeToggle = AreAllTasksCurrentlySelected();
                }

                foreach (var taskSelection in _taskTypeSelections)
                {
                    var isVisible = checkedListBox4.Items.Cast<TaskTypeSelection>().Any(i => i.TaskTypeId == taskSelection.TaskTypeId);
                    if (isVisible)
                    {
                        taskSelection.IsSelected = true;
                        int index = checkedListBox4.Items.Cast<TaskTypeSelection>().ToList().FindIndex(i => i.TaskTypeId == taskSelection.TaskTypeId);
                        checkedListBox4.SetItemChecked(index, true);
                    }
                }

                _allTasksManuallySelected = false;
            }
            else
            {
                if (_allTasksManuallySelected || _allTasksSelectedBeforeToggle)
                {
                    foreach (var taskSelection in _taskTypeSelections)
                    {
                        var isVisible = checkedListBox4.Items.Cast<TaskTypeSelection>().Any(i => i.TaskTypeId == taskSelection.TaskTypeId);
                        if (isVisible)
                        {
                            taskSelection.IsSelected = false;
                            int index = checkedListBox4.Items.Cast<TaskTypeSelection>().ToList().FindIndex(i => i.TaskTypeId == taskSelection.TaskTypeId);
                            checkedListBox4.SetItemChecked(index, false);
                        }
                    }

                    _previouslySelectedTasks.Clear();
                    _allTasksManuallySelected = false;
                }
                else
                {
                    RestorePreviousTaskSelections();
                }
            }

            _isSelectingAllTasks = false;
        }

        protected void allEmployeesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSelectingAllEmployees) return;

            _isSelectingAllEmployees = true;

            if (allEmployeesCheckBox.Checked)
            {
                if (!_allEmployeesSelectedBeforeToggle)
                {
                    _previouslySelectedEmployees = _employeeSelections.Where(e => e.IsSelected).ToList();
                    _allEmployeesSelectedBeforeToggle = AreAllEmployeesCurrentlySelected();
                }

                foreach (var employeeSelection in _employeeSelections)
                {
                    var isVisible = employeesCheckBoxList.Items.Cast<EmployeeListItem>().Any(i => i.EmployeeId == employeeSelection.EmployeeId);
                    if (isVisible)
                    {
                        employeeSelection.IsSelected = true;
                        int index = employeesCheckBoxList.Items.Cast<EmployeeListItem>().ToList().FindIndex(i => i.EmployeeId == employeeSelection.EmployeeId);
                        employeesCheckBoxList.SetItemChecked(index, true);
                    }
                }

                _allEmployeesManuallySelected = false;
            }
            else
            {
                if (_allEmployeesManuallySelected || _allEmployeesSelectedBeforeToggle)
                {
                    foreach (var employeeSelection in _employeeSelections)
                    {
                        var isVisible = employeesCheckBoxList.Items.Cast<EmployeeListItem>().Any(i => i.EmployeeId == employeeSelection.EmployeeId);
                        if (isVisible)
                        {
                            employeeSelection.IsSelected = false;
                            int index = employeesCheckBoxList.Items.Cast<EmployeeListItem>().ToList().FindIndex(i => i.EmployeeId == employeeSelection.EmployeeId);
                            employeesCheckBoxList.SetItemChecked(index, false);
                        }
                    }

                    _previouslySelectedEmployees.Clear();
                    _allEmployeesManuallySelected = false;
                }
                else
                {
                    RestorePreviousEmployeeSelections();
                }
            }

            _isSelectingAllEmployees = false;
        }

        protected void allPaymentStatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSelectingAllPaymentStatuses) return;

            _isSelectingAllPaymentStatuses = true;

            if (allPaymentStatusCheckBox.Checked)
            {
                if (!_allPaymentStatusesSelectedBeforeToggle)
                {
                    _allPaymentStatusesSelectedBeforeToggle = AreAllPaymentStatusesCurrentlySelected();
                }

                SelectAllPaymentStatuses(true);

                _allPaymentStatusesManuallySelected = false;
            }
            else
            {
                if (_allPaymentStatusesManuallySelected || _allPaymentStatusesSelectedBeforeToggle)
                {
                    SelectAllPaymentStatuses(false);
                    _allPaymentStatusesManuallySelected = false;
                }
                else
                {
                    RestorePreviousPaymentStatusSelections();
                }
            }

            _isSelectingAllPaymentStatuses = false;
        }

        protected void taskStatusAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSelectingAllTaskStatuses) return;

            _isSelectingAllTaskStatuses = true;

            if (taskStatusAllCheckBox.Checked)
            {
                if (!_allTaskStatusesSelectedBeforeToggle)
                {
                    _allTaskStatusesSelectedBeforeToggle = AreAllTaskStatusesCurrentlySelected();
                }

                SelectAllTaskStatuses(true);

                _allTaskStatusesManuallySelected = false;
            }
            else
            {
                if (_allTaskStatusesManuallySelected || _allTaskStatusesSelectedBeforeToggle)
                {
                    SelectAllTaskStatuses(false);
                    _allTaskStatusesManuallySelected = false;
                }
                else
                {
                    RestorePreviousTaskStatusSelections();
                }
            }

            _isSelectingAllTaskStatuses = false;
        }

        protected void SelectAllActivityTypes(bool select)
        {
            foreach (var activitySelection in _activityTypeSelections)
            {
                var isVisible = checkedListBox3.Items.Cast<ActivityTypeSelection>().Any(i => i.ActivityTypeID == activitySelection.ActivityTypeID);
                if (isVisible)
                {
                    activitySelection.IsSelected = select;
                    int index = checkedListBox3.Items.Cast<ActivityTypeSelection>().ToList().FindIndex(i => i.ActivityTypeID == activitySelection.ActivityTypeID);
                    checkedListBox3.SetItemChecked(index, select);
                }
            }

            UpdateTaskTypesBasedOnActivities();
        }

        protected void SelectAllTaskTypes(bool select)
        {
            foreach (var taskSelection in _taskTypeSelections)
            {
                var isVisible = checkedListBox4.Items.Cast<TaskTypeSelection>().Any(i => i.TaskTypeId == taskSelection.TaskTypeId);
                if (isVisible)
                {
                    taskSelection.IsSelected = select;
                    int index = checkedListBox4.Items.Cast<TaskTypeSelection>().ToList().FindIndex(i => i.TaskTypeId == taskSelection.TaskTypeId);
                    checkedListBox4.SetItemChecked(index, select);
                }
            }
        }

        protected void SelectAllEmployees(bool select)
        {
            foreach (var employeeSelection in _employeeSelections)
            {
                var isVisible = employeesCheckBoxList.Items.Cast<EmployeeListItem>().Any(i => i.EmployeeId == employeeSelection.EmployeeId);
                if (isVisible)
                {
                    employeeSelection.IsSelected = select;
                    int index = employeesCheckBoxList.Items.Cast<EmployeeListItem>().ToList().FindIndex(i => i.EmployeeId == employeeSelection.EmployeeId);
                    employeesCheckBoxList.SetItemChecked(index, select);
                }
            }
        }

        protected void SelectAllPaymentStatuses(bool select)
        {
            for (int i = 0; i < paymentStatusCheckBoxList.Items.Count; i++)
            {
                paymentStatusCheckBoxList.SetItemChecked(i, select);
            }
        }

        protected void SelectAllTaskStatuses(bool select)
        {
            for (int i = 0; i < taskStatusCheckBoxList.Items.Count; i++)
            {
                taskStatusCheckBoxList.SetItemChecked(i, select);
            }
        }

        protected void UpdateTaskTypesBasedOnActivities()
        {
            var selectedActivityTypes = _activityTypeSelections.Where(a => a.IsSelected).ToList();

            _taskTypeSelections.ForEach(t => t.IsSelected = false);

            var selectedTaskTypes = new List<TaskTypeSelection>();

            foreach (var activitySelection in selectedActivityTypes)
            {
                foreach (var taskType in activitySelection.TaskTypeSelections)
                {
                    var taskSelection = _taskTypeSelections.FirstOrDefault(t => t.TaskTypeId == taskType.TaskTypeId);
                    if (taskSelection != null)
                    {
                        taskSelection.IsSelected = true;
                        selectedTaskTypes.Add(taskSelection);
                    }
                }
            }

            checkedListBox4.Items.Clear();
            foreach (var taskSelection in selectedTaskTypes)
            {
                checkedListBox4.Items.Add(taskSelection, taskSelection.IsSelected);
            }
        }

        protected void RestorePreviousActivitySelections()
        {
            foreach (var activitySelection in _activityTypeSelections)
            {
                var previousSelection = _previouslySelectedActivities.FirstOrDefault(a => a.ActivityTypeID == activitySelection.ActivityTypeID);
                activitySelection.IsSelected = previousSelection != null;
            }

            PopulateActivityTypes();
        }

        protected void RestorePreviousTaskSelections()
        {
            foreach (var taskSelection in _taskTypeSelections)
            {
                var previousSelection = _previouslySelectedTasks.FirstOrDefault(t => t.TaskTypeId == taskSelection.TaskTypeId);
                taskSelection.IsSelected = previousSelection != null;
            }

            PopulateTaskTypes();
        }

        protected void RestorePreviousEmployeeSelections()
        {
            foreach (var employeeSelection in _employeeSelections)
            {
                var previousSelection = _previouslySelectedEmployees.FirstOrDefault(e => e.EmployeeId == employeeSelection.EmployeeId);
                employeeSelection.IsSelected = previousSelection != null;
            }

            PopulateEmployees();
        }

        protected void RestorePreviousPaymentStatusSelections()
        {
            // Implement logic to restore previous payment status selections if needed
            // For now, resetting all items to unchecked
            SelectAllPaymentStatuses(false);
        }

        protected void RestorePreviousTaskStatusSelections()
        {
            // Implement logic to restore previous task status selections if needed
            // For now, resetting all items to unchecked
            SelectAllTaskStatuses(false);
        }

        protected bool AreAllItemsCurrentlySelected()
        {
            return checkedListBox3.Items.Count == checkedListBox3.CheckedItems.Count;
        }

        protected bool AreAllTasksCurrentlySelected()
        {
            return checkedListBox4.Items.Count == checkedListBox4.CheckedItems.Count;
        }

        protected bool AreAllEmployeesCurrentlySelected()
        {
            return employeesCheckBoxList.Items.Count == employeesCheckBoxList.CheckedItems.Count;
        }

        protected bool AreAllPaymentStatusesCurrentlySelected()
        {
            return paymentStatusCheckBoxList.Items.Count == paymentStatusCheckBoxList.CheckedItems.Count;
        }

        protected bool AreAllTaskStatusesCurrentlySelected()
        {
            return taskStatusCheckBoxList.Items.Count == taskStatusCheckBoxList.CheckedItems.Count;
        }

        public virtual List<RequestWithClientsDTO> ApplyFilters()
        {
            var selectedPaymentStatuses = paymentStatusCheckBoxList.CheckedItems.Cast<string>().ToList();
            var selectedActivityTypeIds = checkedListBox3.CheckedItems.Cast<ActivityTypeSelection>().Select(a => a.ActivityTypeID).ToList();
            var selectedTaskTypeIds = checkedListBox4.CheckedItems.Cast<TaskTypeSelection>().Select(t => t.TaskTypeId).ToList();
            var selectedEmployeeIds = employeesCheckBoxList.CheckedItems.Cast<EmployeeListItem>().Select(e => e.EmployeeId).ToList();
            var selectedTaskStatuses = taskStatusCheckBoxList.CheckedItems.Cast<string>().ToList();

            var filteredRequests = _dataService.FilterRequestsBySelectedCriteria(
                selectedPaymentStatuses,
                selectedActivityTypeIds,
                selectedTaskTypeIds,
                selectedEmployeeIds,
                selectedTaskStatuses,
                firstDate.Value,
                SecondDate.Value
            );
            return filteredRequests;
        }

        public void ExportFilteredRequests(object sender, EventArgs e)
        {
            // Apply filters
            var filteredRequests = ApplyFilters();
            var selectedEmployees = _employeeSelections
        .Where(emp => emp.IsSelected)
        .Select(emp => new GetEmployeeDTO
        {
            EmployeeId = emp.EmployeeId,
            FullName = emp.FullName
            // You can include other fields if necessary
        })
        .ToList();

            // Initialize exporter with filtered requests
            var exporter = new AllTasksInqueri(filteredRequests, selectedEmployees);

            // Export to Excel and open
            exporter.ExportToExcel("path_to_save_file.xlsx");
        }

        
    }
}
