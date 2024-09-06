using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class ExistingActivityAddTask : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        public List<GetActivityTypeDTO> _activityTypesDTOs;
        CreateTaskDTO _taskValidator;
        public GetActivityDTO _selectedActivity;
        public event EventHandler DisposeRequested;

        public List<GetTaskTypeDTO> _getTaskTypeDTOs;
        public ExistingActivityAddTask(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityTypesDTOs = new List<GetActivityTypeDTO>();
            _getTaskTypeDTOs = new List<GetTaskTypeDTO>();
            _taskValidator = new CreateTaskDTO();
            _selectedActivity = null;
        }

        
        private async void AddActivityTaskForm_Load(object sender, EventArgs e)
        {


            var response = await _userClient.GetActivityTypes();
            _dataService.SetActivityTypes(response.ResponseObj);
            var selected = _dataService.GetSelectedRequest();
            var linkedRequests = _dataService.GetFetchedLinkedRequests();
            List<GetActivityDTO> activityDTOs = new List<GetActivityDTO>();
            foreach (var linkedRequest in linkedRequests)
            {
                if (selected.RequestId == linkedRequest.requestDTO.RequestId)
                {
                    activityDTOs = linkedRequest.activityDTOs;
                }
            }

            ActivityComboBox.DataSource = activityDTOs;
            ActivityComboBox.DisplayMember = "ActivityTypeName";
            ActivityComboBox.ValueMember = "ActivityId";

            // Get employees
            var employeesResponse = await _userClient.GetAllEmployees();
            var employeesList = employeesResponse.ResponseObj as List<GetEmployeeDTO>;


            // Create separate copies of the employee list for each ComboBox
            var employeesListForExecitant = new List<GetEmployeeDTO>(employeesList);
            var employeesListForControl = new List<GetEmployeeDTO>(employeesList);
            GetEmployeeDTO employeeDTO = new GetEmployeeDTO();
            employeeDTO.FullName = "Няма Контрол";
            
            employeesListForControl.Insert(0, employeeDTO);
            // Set the data source for the ExecitantComboBox
            ExecitantComboBox.DataSource = employeesListForExecitant;
            ExecitantComboBox.DisplayMember = "FullName";
            ExecitantComboBox.ValueMember = "EmployeeId";
            GetActivityDTO selectedActivity = ActivityComboBox.SelectedItem as GetActivityDTO;
            ExecitantComboBox.SelectedValue = selectedActivity.mainExecutant.EmployeeId;


            // Set the data source for the ControlComboBox
            ControlComboBox.DataSource = employeesListForControl;
            ControlComboBox.DisplayMember = "FullName";
            ControlComboBox.ValueMember = "EmployeeId";

            StatusComboBox.SelectedIndex = 0;

            TaskComboBox.TextChanged += TaskComboBox_textChanged;
        }

        private void ValidateModel()
        {
            // Temporarily disable redrawing to reduce flickering
            SuspendLayout();

            try
            {
                // Clear previous error messages
                ActivityErrorProvider.Clear();
                // Clear all error messages if validation passes
                foreach (Control control in Controls)
                {
                    ActivityErrorProvider.SetError(control, string.Empty);
                }


                if (ExecutantPaymentTextBox.Text == "")
                {
                    ExecutantPriceErrorLabel.Text = "Моля попълнете";
                    ActivityErrorProvider.SetError(ExecutantPaymentTextBox, "Invalid Price format");
                }
                else if (float.TryParse(ExecutantPaymentTextBox.Text, out float price))
                {
                    _taskValidator.executantPayment = price;
                    ExecutantPriceErrorLabel.Text = "Моля спазвайте формата";
                }
                else
                {
                    ActivityErrorProvider.SetError(ExecutantPaymentTextBox, "Invalid Price format");
                }

                if (TaxTextBox.Text == "")
                {
                    TaxPriceErrorLabel.Text = "Моля попълнете";
                    ActivityErrorProvider.SetError(TaxTextBox, "Invalid Price format");
                }
                else if (float.TryParse(TaxTextBox.Text, out float tax))
                {
                    _taskValidator.tax = tax;
                    TaxPriceErrorLabel.Text = "Моля спазвайте формата";
                }
                else
                {
                    ActivityErrorProvider.SetError(TaxTextBox, "Invalid Price format");
                }

               

                // Validate the model
                IList<ValidationResult> memberNameResults = WolfClient.Validators.Validator.Validate(_taskValidator);

                if (memberNameResults.Any())
                {
                    foreach (var result in memberNameResults)
                    {
                        foreach (var memberName in result.MemberNames)
                        {
                            // Map property names to control names
                            string controlName = GetControlNameForMember(memberName);
                            if (controlName != null)
                            {
                                Control control = Controls.Find(controlName, true).FirstOrDefault();
                                if (control != null)
                                {
                                    ActivityErrorProvider.SetError(control, result.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                // Re-enable redrawing
                ResumeLayout();
            }
        }

        private string GetControlNameForMember(string memberName)
        {
            return memberName switch
            {
                nameof(_taskValidator.tax) => "TaxTextBox",
                nameof(_taskValidator.executantPayment) => "ExecutantPaymentTextBox",
                _ => null
            };
        }

        private void ActivityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetActivityDTO? selectedActivity = ActivityComboBox.SelectedItem as GetActivityDTO;
            var activityTypesList = _dataService.GetActivityTypeDTOs();
            List<GetTaskTypeDTO> taskTypes = new List<GetTaskTypeDTO>();
            foreach (var activityType in activityTypesList)
            {
                if (activityType.ActivityTypeID == selectedActivity.ActivityTypeID)
                {
                    taskTypes = activityType.TaskTypes.ToList();
                }
            }
            if (selectedActivity != null)
            {
                TaskComboBox.DataSource = taskTypes.ToList();
                TaskComboBox.DisplayMember = "TaskTypeName";
                TaskComboBox.ValueMember = "TaskTypeId";
            }
            _getTaskTypeDTOs = taskTypes;

            ActivityTypeLabel.Text = $"Дейност : {selectedActivity.ActivityType.ActivityTypeName}";
            MainExecutantLabel.Text = $"Главен изпълнител : {selectedActivity.mainExecutant.FullName}";
            ParentActivityLabel.Text = $"Произлиза от : {selectedActivity.ParentActivity?.ActivityTypeName}";
            startDateLabel.Text = $"започнато на : {selectedActivity.StartDate}";
            ExpectedDurationLabel.Text = $"завършва на : {selectedActivity.ExpectedDuration}";
        }

        public void TaskComboBox_textChanged(object sender, EventArgs e)
        {
            string text = TaskComboBox.Text;

            // Temporarily remove the event handler to prevent it from firing while updating the items
            TaskComboBox.TextChanged -= TaskComboBox_textChanged;

            List<GetTaskTypeDTO> filteredTasks = new List<GetTaskTypeDTO>();
            // Filter the list based on the text input or show all items if the text is empty
            if (string.IsNullOrWhiteSpace(text))
            {
                // If the text is empty, display all clients
                filteredTasks = _getTaskTypeDTOs;

            }
            else
            {
                // Get the list of clients and filter based on the text input
                filteredTasks = _getTaskTypeDTOs
                    .Where(client => client.TaskTypeName.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(client => client.TaskTypeName)
                    .ToList();

                // Clear and repopulate the ComboBox with the filtered and sorted list

            }

            TaskComboBox.DataSource = filteredTasks;
            TaskComboBox.DisplayMember = "TaskTypeName";
            TaskComboBox.ValueMember = "TaskTypeId";



            // Restore the user's text and keep the ComboBox open
            TaskComboBox.Text = text;
            TaskComboBox.SelectionStart = text.Length;

            // Reattach the event handler
            TaskComboBox.TextChanged += TaskComboBox_textChanged;
        }

        private bool ValidateActivityComboBox()
        {
            if (ActivityComboBox.SelectedItem is GetActivityTypeDTO selectedItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateTaskComboBox()
        {
            if (TaskComboBox.SelectedItem is GetTaskTypeDTO selectedItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public async void AddActivitySubmit_Click(object sender, EventArgs e)
        {
            TimeZoneInfo bulgariaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            DateTime utcNow = DateTime.UtcNow;

            // Convert UTC time to Bulgarian time
            DateTime bulgariaTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, bulgariaTimeZone);

            if (ValidateTaskComboBox())
            {

                GetTaskTypeDTO taskTypeDTO = TaskComboBox.SelectedItem as GetTaskTypeDTO;
                GetActivityDTO activityDTO = ActivityComboBox.SelectedItem as GetActivityDTO;



                CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                {
                    ActivityId = (int)ActivityComboBox.SelectedValue,
                    Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                    StartDate = bulgariaTime,
                    ExecutantId = (int)ExecitantComboBox.SelectedValue,
                    ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                    Comments = CommentsRichTextBox.Text,
                    TaskTypeId = taskTypeDTO.TaskTypeId,
                    Status = StatusComboBox.Text,
                    executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                    CommentTax = taxCommentRichTexBox.Text,
                    tax = float.Parse(TaxTextBox.Text),
                    FinishDate = endDateDateTimePicker.Value.AddHours(3 + (double)DurationNumericUpDown.Value)
                };
                createTaskDTO.FinishDate = DateTime.SpecifyKind(createTaskDTO.FinishDate, DateTimeKind.Unspecified);
                var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                _dataService.ReplaceActivity(responseActivityFromTask.ResponseObj);

            }
            else
            {
                GetActivityDTO activityDTO = ActivityComboBox.SelectedItem as GetActivityDTO;
                GetActivityTypeDTO activityTypeDTO = activityDTO.ActivityType;
                CreateTaskTypeDTO createTaskTypeDTO = new CreateTaskTypeDTO()
                {
                    ActivityTypeID = activityTypeDTO.ActivityTypeID,
                    TaskTypeName = TaskComboBox.Text,
                };
                List<CreateTaskTypeDTO> listTaksTypesDTO = new List<CreateTaskTypeDTO>();
                listTaksTypesDTO.Add(createTaskTypeDTO);
                var createTaskTypeResponse = await _userClient.AddTaskTypes(listTaksTypesDTO);
                //Create Activity and task Logik


                CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                {
                    ActivityId = activityDTO.ActivityId,
                    Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                    StartDate = bulgariaTime,
                    ExecutantId = (int)ExecitantComboBox.SelectedValue,
                    ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                    Comments = CommentsRichTextBox.Text,
                    TaskTypeId = createTaskTypeResponse.ResponseObj.TaskTypes.ElementAt(0).TaskTypeId,
                    Status = StatusComboBox.Text,
                    executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                    CommentTax = taxCommentRichTexBox.Text,
                    tax = float.Parse(TaxTextBox.Text),
                    FinishDate = endDateDateTimePicker.Value.AddHours(3 + (double)DurationNumericUpDown.Value)
                };
                createTaskDTO.FinishDate = DateTime.SpecifyKind(createTaskDTO.FinishDate, DateTimeKind.Unspecified);
                var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                _dataService.AddActivityToTheList(responseActivityFromTask.ResponseObj);

            }
            DisposeRequested?.Invoke(this, EventArgs.Empty);
            Dispose();
        }

        private void ExecitantComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
