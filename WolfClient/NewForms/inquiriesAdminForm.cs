using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;
using WolfClient.TemplateClasses;

namespace WolfClient.NewForms
{
    public partial class inquiriesAdminForm : Form
    {
        private readonly IAdminClient _adminClient;
        private readonly IUserClient _userClient;
        private readonly IApiClient _apiClient;
        private readonly IDataService _dataService;

        private List<ActivityTypeSelection> _activityTypeSelections;
        private List<TaskTypeSelection> _taskTypeSelections;

        private bool _isSelectingAllActivities = false;
        private List<ActivityTypeSelection> _previouslySelectedActivities;
        private bool _allItemsManuallySelected = false;
        private bool _allItemsSelectedBeforeToggle = false;

        private bool _isSelectingAllTasks = false;
        private List<TaskTypeSelection> _previouslySelectedTasks;
        private bool _allTasksManuallySelected = false;
        private bool _allTasksSelectedBeforeToggle = false;

        public inquiriesAdminForm(IUserClient userClient, IApiClient apiClient, IDataService dataService, IAdminClient adminClient)
        {
            InitializeComponent();
            _userClient = userClient;
            _apiClient = apiClient;
            _dataService = dataService;
            _adminClient = adminClient;

            textBox1.TextChanged += new EventHandler(textBoxActivityTypeFilter_TextChanged);
            textBox2.TextChanged += new EventHandler(textBoxTaskTypeFilter_TextChanged);

            checkedListBox3.ItemCheck += new ItemCheckEventHandler(checkedListBox3_ItemCheck);
            checkedListBox4.ItemCheck += new ItemCheckEventHandler(checkedListBox4_ItemCheck);

            allActivityCheckBox.CheckedChanged += new EventHandler(allActivityCheckBox_CheckedChanged);
            allTasksButton.CheckedChanged += new EventHandler(allTasksButton_CheckedChanged);

            // Delay the initialization of the form to ensure all controls are ready
            this.Load += new EventHandler(inquiriesAdminForm_Load);
        }

        private async void inquiriesAdminForm_Load(object sender, EventArgs e)
        {
            // Initialize the form after it has loaded
            await InitializeForm();
        }

        private async Task InitializeForm()
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

            // Initialize the "Всички" checkboxes after everything else
            allActivityCheckBox.Checked = true;
            allTasksButton.Checked = true;

            _previouslySelectedActivities = new List<ActivityTypeSelection>(_activityTypeSelections);
            _previouslySelectedTasks = new List<TaskTypeSelection>(_taskTypeSelections);

            PopulateActivityTypes();
            PopulateTaskTypes();
        }

        private void PopulateActivityTypes()
        {
            checkedListBox3.Items.Clear();

            foreach (var activitySelection in _activityTypeSelections)
            {
                checkedListBox3.Items.Add(activitySelection.ActivityTypeName, activitySelection.IsSelected);
            }

            UpdateTaskTypesBasedOnActivities(); // Ensure task types are updated when activities are populated
        }

        private void PopulateTaskTypes()
        {
            checkedListBox4.Items.Clear();

            foreach (var taskSelection in _taskTypeSelections)
            {
                checkedListBox4.Items.Add(taskSelection.TaskTypeName, taskSelection.IsSelected);
            }
        }

        private void FilterActivityTypes()
        {
            string filterText = textBox1.Text.ToLower();

            var filteredActivitySelections = _activityTypeSelections
                .Where(a => a.ActivityTypeName.ToLower().Contains(filterText))
                .ToList();

            checkedListBox3.Items.Clear();
            foreach (var activitySelection in filteredActivitySelections)
            {
                checkedListBox3.Items.Add(activitySelection.ActivityTypeName, activitySelection.IsSelected);
            }

            if (allActivityCheckBox.Checked)
            {
                SelectAllActivityTypes(true);
            }

            UpdateTaskTypesBasedOnActivities(); // Ensure task types are updated when filtering activities
        }

        private void FilterTaskTypes()
        {
            string filterText = textBox2.Text.ToLower();

            var filteredTaskSelections = _taskTypeSelections
                .Where(t => t.TaskTypeName.ToLower().Contains(filterText))
                .ToList();

            checkedListBox4.Items.Clear();
            foreach (var taskSelection in filteredTaskSelections)
            {
                checkedListBox4.Items.Add(taskSelection.TaskTypeName, taskSelection.IsSelected);
            }

            if (allTasksButton.Checked)
            {
                SelectAllTaskTypes(true);
            }
        }

        private void textBoxActivityTypeFilter_TextChanged(object sender, EventArgs e)
        {
            FilterActivityTypes();
        }

        private void textBoxTaskTypeFilter_TextChanged(object sender, EventArgs e)
        {
            FilterTaskTypes();
        }

        private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isSelectingAllActivities) return;

            var activityName = checkedListBox3.Items[e.Index].ToString();
            var activitySelection = _activityTypeSelections.FirstOrDefault(a => a.ActivityTypeName == activityName);

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

            UpdateTaskTypesBasedOnActivities(); // Ensure task types are updated immediately when activities are checked/unchecked
        }

        private void checkedListBox4_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isSelectingAllTasks) return;

            var taskName = checkedListBox4.Items[e.Index].ToString();
            var taskSelection = _taskTypeSelections.FirstOrDefault(t => t.TaskTypeName == taskName);

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

        private void allActivityCheckBox_CheckedChanged(object sender, EventArgs e)
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
                    var isVisible = checkedListBox3.Items.Contains(activitySelection.ActivityTypeName);
                    if (isVisible)
                    {
                        activitySelection.IsSelected = true;
                        int index = checkedListBox3.Items.IndexOf(activitySelection.ActivityTypeName);
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
                        var isVisible = checkedListBox3.Items.Contains(activitySelection.ActivityTypeName);
                        if (isVisible)
                        {
                            activitySelection.IsSelected = false;
                            int index = checkedListBox3.Items.IndexOf(activitySelection.ActivityTypeName);
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

            UpdateTaskTypesBasedOnActivities(); // Ensure task types are updated when "Всички" is toggled for activities
        }

        private void allTasksButton_CheckedChanged(object sender, EventArgs e)
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
                    var isVisible = checkedListBox4.Items.Contains(taskSelection.TaskTypeName);
                    if (isVisible)
                    {
                        taskSelection.IsSelected = true;
                        int index = checkedListBox4.Items.IndexOf(taskSelection.TaskTypeName);
                        checkedListBox4.SetItemChecked(index, true);
                    }
                }

                _allTasksManuallySelected = false;
            }
            else
            {
                // Unselect all visible items immediately when "Всички" is unchecked
                foreach (var taskSelection in _taskTypeSelections)
                {
                    var isVisible = checkedListBox4.Items.Contains(taskSelection.TaskTypeName);
                    if (isVisible)
                    {
                        taskSelection.IsSelected = false;
                        int index = checkedListBox4.Items.IndexOf(taskSelection.TaskTypeName);
                        checkedListBox4.SetItemChecked(index, false);
                    }
                }

                _previouslySelectedTasks.Clear(); // Clear previous state after unchecking
                _allTasksManuallySelected = false;
            }

            _isSelectingAllTasks = false;
        }

        private void SelectAllActivityTypes(bool select)
        {
            foreach (var activitySelection in _activityTypeSelections)
            {
                var isVisible = checkedListBox3.Items.Contains(activitySelection.ActivityTypeName);
                if (isVisible)
                {
                    activitySelection.IsSelected = select;
                    int index = checkedListBox3.Items.IndexOf(activitySelection.ActivityTypeName);
                    checkedListBox3.SetItemChecked(index, select);
                }
            }

            UpdateTaskTypesBasedOnActivities(); // Ensure task types are updated when all activities are selected
        }

        private void SelectAllTaskTypes(bool select)
        {
            foreach (var taskSelection in _taskTypeSelections)
            {
                var isVisible = checkedListBox4.Items.Contains(taskSelection.TaskTypeName);
                if (isVisible)
                {
                    taskSelection.IsSelected = select;
                    int index = checkedListBox4.Items.IndexOf(taskSelection.TaskTypeName);
                    checkedListBox4.SetItemChecked(index, select);
                }
            }
        }

        private void UpdateTaskTypesBasedOnActivities()
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

            // Remove unselected tasks from the checkedListBox4
            checkedListBox4.Items.Clear();
            foreach (var taskSelection in selectedTaskTypes)
            {
                checkedListBox4.Items.Add(taskSelection.TaskTypeName, taskSelection.IsSelected);
            }
        }

        private void RestorePreviousActivitySelections()
        {
            foreach (var activitySelection in _activityTypeSelections)
            {
                var previousSelection = _previouslySelectedActivities.FirstOrDefault(a => a.ActivityTypeID == activitySelection.ActivityTypeID);
                activitySelection.IsSelected = previousSelection != null;
            }

            PopulateActivityTypes();
        }

        private void RestorePreviousTaskSelections()
        {
            foreach (var taskSelection in _taskTypeSelections)
            {
                var previousSelection = _previouslySelectedTasks.FirstOrDefault(t => t.TaskTypeId == taskSelection.TaskTypeId);
                taskSelection.IsSelected = previousSelection != null;
            }

            PopulateTaskTypes();
        }

        private bool AreAllItemsCurrentlySelected()
        {
            return checkedListBox3.Items.Count == checkedListBox3.CheckedItems.Count;
        }

        private bool AreAllTasksCurrentlySelected()
        {
            return checkedListBox4.Items.Count == checkedListBox4.CheckedItems.Count;
        }
    }

}
