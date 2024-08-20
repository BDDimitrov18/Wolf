using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.Services.Interfaces;



namespace WolfClient.UserControls
{
    public partial class NonExistingActivityAddTask : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        public List<GetActivityTypeDTO> _activityTypesDTOs;
        CreateActivityDTO _activityValidator;
        CreateTaskDTO _taskValidator;

        private List<GetTaskTypeDTO> _getTaskTypeDTO;

        public event EventHandler DisposeRequested;
        public NonExistingActivityAddTask(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityValidator = new CreateActivityDTO();
            _taskValidator = new CreateTaskDTO();
            _activityTypesDTOs = new List<GetActivityTypeDTO>();
            _getTaskTypeDTO = new List<GetTaskTypeDTO>();
            ActivityComboBox.TextChanged += ActivityComboBox_TextChanged;
        }

        

        private async void AddActivityTaskForm_Load(object sender, EventArgs e)
        {
            // Get activity types and set the data source for the ActivityComboBox
            var response = await _userClient.GetActivityTypes();
            _dataService.SetActivityTypes(response.ResponseObj);
            ActivityComboBox.DataSource = _dataService.GetActivityTypeDTOs();
            ActivityComboBox.DisplayMember = "ActivityTypeName";
            ActivityComboBox.ValueMember = "ActivityTypeID";

            // Get employees
            var employeesResponse = await _userClient.GetAllEmployees();
            var employeesList = employeesResponse.ResponseObj as List<GetEmployeeDTO>;

            
            // Create separate copies of the employee list for each ComboBox
            var employeesListForExecitant = new List<GetEmployeeDTO>(employeesList);
            var employeesListForControl = new List<GetEmployeeDTO>(employeesList);
            var employeeListForMainExecutant = new List<GetEmployeeDTO>(employeesList);

            MainExecutantComboBox.DataSource = employeeListForMainExecutant;
            MainExecutantComboBox.DisplayMember = "FullName";
            MainExecutantComboBox.ValueMember = "EmployeeId";

            MainExecutantComboBox.SelectedValue = _dataService.getLoggedEmployee().EmployeeId;

            // Set the data source for the ExecitantComboBox
            ExecitantComboBox.DataSource = employeesListForExecitant;
            ExecitantComboBox.DisplayMember = "FullName";
            ExecitantComboBox.ValueMember = "EmployeeId";

            ExecitantComboBox.SelectedValue = _dataService.getLoggedEmployee().EmployeeId;

            GetEmployeeDTO employeeDTO = new GetEmployeeDTO();
            employeeDTO.FullName = "Няма Контрол";

            employeesListForControl.Insert(0, employeeDTO);

            // Set the data source for the ControlComboBox
            ControlComboBox.DataSource = employeesListForControl;
            ControlComboBox.DisplayMember = "FullName";
            ControlComboBox.ValueMember = "EmployeeId";

            // Get the selected request and linked requests
            var selected = _dataService.GetSelectedRequest();
            var linkedRequests = _dataService.GetFetchedLinkedRequests();

            // Find the activity DTOs for the selected request
            List<GetActivityDTO> activityDTOs = new List<GetActivityDTO>();
            foreach (var linkedRequest in linkedRequests)
            {
                if (selected.RequestId == linkedRequest.requestDTO.RequestId)
                {
                    activityDTOs = new List<GetActivityDTO>(linkedRequest.activityDTOs);
                }
            }
            GetActivityDTO blankActivity = new GetActivityDTO();
            blankActivity.ActivityTypeName = "Без Произлизаща Дейност";
            activityDTOs.Insert(0, blankActivity);
            // Set the data source for the ParentActivityComboBox
            ParentActivityComboBox.DataSource = activityDTOs;
            ParentActivityComboBox.DisplayMember = "ActivityTypeName";
            ParentActivityComboBox.ValueMember = "ActivityId";

            StatusComboBox.SelectedIndex = 0;

            TaskComboBox.TextChanged += TaskComboBox_textChanged;
        }

        public void ActivityComboBox_TextChanged(object sender, EventArgs e)
        {
            
            string activity = ActivityComboBox.Text;

            // Temporarily remove the event handler to prevent it from firing while updating the items
            ActivityComboBox.TextChanged -= ActivityComboBox_TextChanged;

            // Filter the list based on the text input or show all items if the text is empty
            List<GetActivityTypeDTO> filteredActivityTypes;
            if (string.IsNullOrWhiteSpace(activity))
            {
                // If the text is empty, display all plots
                filteredActivityTypes = _dataService.GetActivityTypeDTOs();
            }
            else
            {
                // Get the list of plots and filter based on the text input
                filteredActivityTypes = _dataService.GetActivityTypeDTOs()
                    .Where(activityType => activityType.ActivityTypeName.IndexOf(activity, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(activityType => activityType.ActivityTypeName)
                    .ToList();
            }

            // Update the ComboBox DataSource
            ActivityComboBox.DataSource = filteredActivityTypes;
            ActivityComboBox.DisplayMember = "ActivityTypeName";
            ActivityComboBox.ValueMember = "ActivityTypeID";

            // Restore the user's text and keep the ComboBox open
            ActivityComboBox.Text = activity;
            ActivityComboBox.SelectionStart = activity.Length;

            // Reattach the event handler
            ActivityComboBox.TextChanged += ActivityComboBox_TextChanged;


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
                filteredTasks = _getTaskTypeDTO;

            }
            else
            {
                // Get the list of clients and filter based on the text input
                filteredTasks = _getTaskTypeDTO
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

                if (PaymentMainExecutantTextBox.Text == "")
                {
                    MainExecutantPaymentErrorLabel.Text = "Моля попълнете";
                    ActivityErrorProvider.SetError(PaymentMainExecutantTextBox, "Invalid Price format");
                }
                else if (float.TryParse(PaymentMainExecutantTextBox.Text, out float mainExecutantPayment))
                {
                    _activityValidator.employeePayment = mainExecutantPayment;
                    MainExecutantPaymentErrorLabel.Text = "Моля спазвайте формата";
                }
                else
                {
                    ActivityErrorProvider.SetError(PaymentMainExecutantTextBox, "Invalid Price format");
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

                memberNameResults = WolfClient.Validators.Validator.Validate(_activityValidator);

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
                nameof(_activityValidator.employeePayment) => "PaymentMainExecutantTextBox",
                _ => null
            };
        }
        private void ActivityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedActivity = ActivityComboBox.SelectedItem as GetActivityTypeDTO;
            if (selectedActivity != null)
            {
                TaskComboBox.DataSource = selectedActivity.TaskTypes.ToList();
                TaskComboBox.DisplayMember = "TaskTypeName";
                TaskComboBox.ValueMember = "TaskTypeId";
            }
            _getTaskTypeDTO = selectedActivity.TaskTypes.ToList();
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


        private async void AddActivitySubmit_Click(object sender, EventArgs e)
        {
            ValidateModel();

            MainExecutantPaymentErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            TaxPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            ExecutantPriceErrorLabel.ForeColor = SystemColors.GradientActiveCaption;
            bool flag = false;
            if (!string.IsNullOrEmpty(ActivityErrorProvider.GetError(PaymentMainExecutantTextBox)))
            {
                MainExecutantPaymentErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(ActivityErrorProvider.GetError(TaxTextBox)))
            {
                TaxPriceErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (!string.IsNullOrEmpty(ActivityErrorProvider.GetError(ExecutantPaymentTextBox)))
            {
                ExecutantPriceErrorLabel.ForeColor = Color.Red;
                flag = true;
            }
            if (flag) { return; }



            if (ValidateActivityComboBox())
            {
                if (ValidateTaskComboBox())
                {
                    GetActivityTypeDTO activityTypeDTO = ActivityComboBox.SelectedItem as GetActivityTypeDTO;
                    GetTaskTypeDTO taskTypeDTO = TaskComboBox.SelectedItem as GetTaskTypeDTO;

                    CreateActivityDTO createActivityDTO = new CreateActivityDTO()
                    {
                        RequestId = _dataService.GetSelectedRequest().RequestId,
                        ActivityTypeID = activityTypeDTO.ActivityTypeID,
                        ExpectedDuration = expectedDurationDateTime.Value,
                        ParentActivityId = ParentActivityComboBox.Text != "Без Произлизаща Дейност" ? (int)ParentActivityComboBox.SelectedValue : null,
                        StartDate = DateTime.Now,
                        ExecutantId = (int)MainExecutantComboBox.SelectedValue,
                        employeePayment = float.Parse(PaymentMainExecutantTextBox.Text),
                    };


                    var responseActivityDTO = await _userClient.AddActivity(createActivityDTO);

                    CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                    {
                        ActivityId = responseActivityDTO.ResponseObj.ActivityId,
                        Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                        StartDate = DateTime.Now,
                        ExecutantId = (int)ExecitantComboBox.SelectedValue,
                        ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                        Comments = CommentsRichTextBox.Text,
                        TaskTypeId = taskTypeDTO.TaskTypeId,
                        executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                        tax = float.Parse(TaxTextBox.Text),
                        CommentTax = TaxCommentRichTextBox.Text,
                        FinishDate = startDateDateTimePicker.Value,
                        Status = StatusComboBox.Text,
                    };

                    var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                    _dataService.AddActivityToTheList(responseActivityFromTask.ResponseObj);

                }
                else
                {
                    GetActivityTypeDTO activityTypeDTO = ActivityComboBox.SelectedItem as GetActivityTypeDTO;
                    CreateTaskTypeDTO createTaskTypeDTO = new CreateTaskTypeDTO()
                    {
                        ActivityTypeID = activityTypeDTO.ActivityTypeID,
                        TaskTypeName = TaskComboBox.Text,
                    };
                    List<CreateTaskTypeDTO> listTaksTypesDTO = new List<CreateTaskTypeDTO>();
                    listTaksTypesDTO.Add(createTaskTypeDTO);
                    var createTaskTypeResponse = await _userClient.AddTaskTypes(listTaksTypesDTO);
                    //Create Activity and task Logik

                    CreateActivityDTO createActivityDTO = new CreateActivityDTO()
                    {
                        RequestId = _dataService.GetSelectedRequest().RequestId,
                        ActivityTypeID = activityTypeDTO.ActivityTypeID,
                        ExpectedDuration = expectedDurationDateTime.Value,
                        ParentActivityId = ParentActivityComboBox.Text != "Без Произлизаща Дейност" ? (int)ParentActivityComboBox.SelectedValue : null,
                        ExecutantId = (int)MainExecutantComboBox.SelectedValue,
                        employeePayment = float.Parse(PaymentMainExecutantTextBox.Text),
                        StartDate = DateTime.Now
                    };

                    
                    var responseActivityDTO = await _userClient.AddActivity(createActivityDTO);

                    CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                    {
                        ActivityId = responseActivityDTO.ResponseObj.ActivityId,
                        Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                        StartDate = DateTime.Now,
                        ExecutantId = (int)ExecitantComboBox.SelectedValue,
                        ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                        Comments = CommentsRichTextBox.Text,
                        TaskTypeId = createTaskTypeResponse.ResponseObj.TaskTypes.ElementAt(0).TaskTypeId,
                        executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                        tax = float.Parse(TaxTextBox.Text),
                        CommentTax = TaxCommentRichTextBox.Text,
                        FinishDate = startDateDateTimePicker.Value,
                        Status = StatusComboBox.Text
                    };

                    var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                    _dataService.AddActivityToTheList(responseActivityFromTask.ResponseObj);


                }
            }
            else
            {
                //create new ActivityType with corresponding Task
                CreateActivityTypeDTO activityTypeDTO = new CreateActivityTypeDTO()
                {
                    ActivityTypeName = ActivityComboBox.Text,
                };
                List<CreateActivityTypeDTO> listActivityTypesDTO = new List<CreateActivityTypeDTO>();
                listActivityTypesDTO.Add(activityTypeDTO);
                var createActivityTypeResponse = await _userClient.AddActivityTypes(listActivityTypesDTO);
                CreateTaskTypeDTO createTaskTypeDTO = new CreateTaskTypeDTO()
                {
                    ActivityTypeID = createActivityTypeResponse.ResponseObj[0].ActivityTypeID,
                    TaskTypeName = TaskComboBox.Text,
                };
                List<CreateTaskTypeDTO> listTaksTypesDTO = new List<CreateTaskTypeDTO>();
                listTaksTypesDTO.Add(createTaskTypeDTO);
                var createTaskTypeResponse = await _userClient.AddTaskTypes(listTaksTypesDTO);

                //Create Activity and task Logik
                GetRequestDTO requestDto = _dataService.GetSelectedRequest();

                CreateActivityDTO createActivityDTO = new CreateActivityDTO()
                {
                    RequestId = requestDto.RequestId,
                    ActivityTypeID = createTaskTypeResponse.ResponseObj.ActivityTypeID,
                    ExpectedDuration = expectedDurationDateTime.Value,
                    ParentActivityId = ParentActivityComboBox.Text != "Без Произлизаща Дейност" ? (int)ParentActivityComboBox.SelectedValue : null,
                    ExecutantId = (int)MainExecutantComboBox.SelectedValue,
                    employeePayment = float.Parse(PaymentMainExecutantTextBox.Text),
                    StartDate = DateTime.Now
                };

                //DOESNT MAP THE TASKS PROPERLY
                var responseActivityDTO = await _userClient.AddActivity(createActivityDTO);

                CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                {
                    ActivityId = responseActivityDTO.ResponseObj.ActivityId,
                    Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                    StartDate = DateTime.Now,
                    ExecutantId = (int)ExecitantComboBox.SelectedValue,
                    ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                    Comments = CommentsRichTextBox.Text,
                    TaskTypeId = createTaskTypeResponse.ResponseObj.TaskTypes.ElementAt(0).TaskTypeId,
                    executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                    tax = float.Parse(TaxTextBox.Text),
                    CommentTax = TaxCommentRichTextBox.Text,
                    FinishDate = startDateDateTimePicker.Value,
                    Status = StatusComboBox.Text,
                };

                var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                _dataService.AddActivityToTheList(responseActivityFromTask.ResponseObj);


            }
            DisposeRequested?.Invoke(this, EventArgs.Empty);
            Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
