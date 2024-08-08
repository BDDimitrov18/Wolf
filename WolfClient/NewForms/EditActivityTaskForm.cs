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
    public partial class EditActivityTaskForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        public List<GetActivityTypeDTO> _activityTypesDTOs;
        CreateTaskDTO _taskValidator;
        CreateActivityDTO _activityValidator;
        public EditActivityTaskForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityTypesDTOs = new List<GetActivityTypeDTO>();
            _taskValidator = new CreateTaskDTO();
            _activityValidator = new CreateActivityDTO();
            ActivityComboBox.SelectedIndexChanged += ActivityComboBox_SelectedIndexChanged;
        }


        private void label1_Click(object sender, EventArgs e)
        {

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
        }
        private async void EditActivityTaskForm_Load(object sender, EventArgs e)
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

            // Set the data source for the ExecitantComboBox
            ExecitantComboBox.DataSource = employeesListForExecitant;
            ExecitantComboBox.DisplayMember = "FullName";
            ExecitantComboBox.ValueMember = "EmployeeId";

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

            GetActivityDTO selectedActivity = _dataService.GetSelectedActivity();
            GetTaskDTO getTaskDTO = _dataService.GetSelectedTask();

            PaymentMainExecutantTextBox.Text = selectedActivity.employeePayment.ToString();
            CommentsRichTextBox.Text = getTaskDTO.Comments;
            TaxCommentRichTextBox.Text = getTaskDTO.CommentTax;
            TaxTextBox.Text = getTaskDTO.tax.ToString();
            ExecutantPaymentTextBox.Text = getTaskDTO.executantPayment.ToString();
            StatusComboBox.Text = getTaskDTO.Status;

            // Populate the rest of the controls with data from selectedActivity and getTaskDTO
            ActivityComboBox.SelectedValue = selectedActivity.ActivityTypeID;
            MainExecutantComboBox.SelectedValue = selectedActivity.ExecutantId;
            ParentActivityComboBox.SelectedValue = selectedActivity.ParentActivityId ?? 0;
            ExecitantComboBox.SelectedValue = getTaskDTO.ExecutantId;
            if (getTaskDTO.Control != null)
            {
                ControlComboBox.SelectedValue = getTaskDTO.ControlId;
            }
            else
            {
                ControlComboBox.SelectedIndex = 0;
            }
            ActivityStartDatePicker.Value = selectedActivity.StartDate;
            expectedDurationDateTime.Value = selectedActivity.ExpectedDuration;
            taskStartDateTimePicker.Value = getTaskDTO.StartDate;
            DurationNumericUpDown.Value = (decimal)getTaskDTO.Duration.TotalHours;

            StatusComboBox.SelectedIndex = 0;
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
                    GetActivityDTO editActivity = _dataService.GetSelectedActivity();
                    GetTaskDTO editTask = _dataService.GetSelectedTask();
                    if (editActivity != null) {
                        var activityType = ActivityComboBox.SelectedItem as GetActivityTypeDTO;
                        

                        editActivity.RequestId = _dataService.GetSelectedRequest().RequestId;
                        editActivity.ActivityTypeID = activityType.ActivityTypeID;
                        editActivity.ActivityType = activityType;
                        editActivity.ExpectedDuration = expectedDurationDateTime.Value;
                        editActivity.ParentActivityId = ParentActivityComboBox.Text != "Без Произлизаща Дейност" ? (int)ParentActivityComboBox.SelectedValue : null;
                        editActivity.ExecutantId = (int)MainExecutantComboBox.SelectedValue;
                        editActivity.employeePayment = float.Parse(PaymentMainExecutantTextBox.Text);
                        editActivity.StartDate = ActivityStartDatePicker.Value;

                        await _userClient.EditActivity(editActivity);
                        _dataService.editActivity(editActivity);

                        if (editTask != null)
                        {
                            var taskType = TaskComboBox.SelectedItem as GetTaskTypeDTO;
                           

                            editTask.ActivityId = editActivity.ActivityId;
                            editTask.Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value);
                            editTask.StartDate = taskStartDateTimePicker.Value;
                            editTask.ExecutantId = (int)ExecitantComboBox.SelectedValue;
                            editTask.Executant = ExecitantComboBox.SelectedItem as GetEmployeeDTO;
                            editTask.ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue;
                            editTask.Control = ControlComboBox.Text == "Няма Контрол" ? null : ControlComboBox.SelectedItem as GetEmployeeDTO;
                            editTask.Comments = CommentsRichTextBox.Text;
                            editTask.TaskTypeId = taskType.TaskTypeId;
                            editTask.taskType = taskType;
                            editTask.executantPayment = float.Parse(ExecutantPaymentTextBox.Text);
                            editTask.tax = float.Parse(TaxTextBox.Text);
                            editTask.CommentTax = TaxCommentRichTextBox.Text;
                            editTask.FinishDate = startDateDateTimePicker.Value;
                            editTask.Status = StatusComboBox.Text;

                            await _userClient.EditTask(editTask);
                            _dataService.editTask(editTask);
                        }
                    }
                    
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

                    GetActivityDTO editActivity = _dataService.GetSelectedActivity();
                    GetTaskDTO editTask = _dataService.GetSelectedTask();
                    if (editActivity != null)
                    {
                        var activityType = ActivityComboBox.SelectedItem as GetActivityTypeDTO;


                        editActivity.RequestId = _dataService.GetSelectedRequest().RequestId;
                        editActivity.ActivityTypeID = activityType.ActivityTypeID;
                        editActivity.ActivityType = activityType;
                        editActivity.ExpectedDuration = expectedDurationDateTime.Value;
                        editActivity.ParentActivityId = ParentActivityComboBox.Text != "Без Произлизаща Дейност" ? (int)ParentActivityComboBox.SelectedValue : null;
                        editActivity.ExecutantId = (int)MainExecutantComboBox.SelectedValue;
                        editActivity.employeePayment = float.Parse(PaymentMainExecutantTextBox.Text);
                        editActivity.StartDate = ActivityStartDatePicker.Value;

                        var activityResponse = await _userClient.EditActivity(editActivity);
                        _dataService.editActivity(editActivity);
                        if (activityResponse.IsSuccess)
                        {
                            
                        }

                        if (editTask != null)
                        {
                            var taskType = createTaskTypeResponse.ResponseObj.TaskTypes.Where(t => t.TaskTypeName == TaskComboBox.Text).FirstOrDefault();


                            editTask.ActivityId = editActivity.ActivityId;
                            editTask.Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value);
                            editTask.StartDate = taskStartDateTimePicker.Value;
                            editTask.ExecutantId = (int)ExecitantComboBox.SelectedValue;
                            editTask.Executant = ExecitantComboBox.SelectedItem as GetEmployeeDTO;
                            editTask.ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue;
                            editTask.Control = ControlComboBox.Text == "Няма Контрол" ? null : ControlComboBox.SelectedItem as GetEmployeeDTO;
                            editTask.Comments = CommentsRichTextBox.Text;
                            editTask.TaskTypeId = taskType.TaskTypeId;
                            editTask.taskType = taskType;
                            editTask.executantPayment = float.Parse(ExecutantPaymentTextBox.Text);
                            editTask.tax = float.Parse(TaxTextBox.Text);
                            editTask.CommentTax = TaxCommentRichTextBox.Text;
                            editTask.FinishDate = startDateDateTimePicker.Value;
                            editTask.Status = StatusComboBox.Text;

                            await _userClient.EditTask(editTask);
                            _dataService.editTask(editTask);
                        }
                    }
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

                GetActivityDTO editActivity = _dataService.GetSelectedActivity();
                GetTaskDTO editTask = _dataService.GetSelectedTask();
                if (editActivity != null)
                {
                    var activityType = createTaskTypeResponse.ResponseObj;


                    editActivity.RequestId = _dataService.GetSelectedRequest().RequestId;
                    editActivity.ActivityTypeID = activityType.ActivityTypeID;
                    editActivity.ActivityType = activityType;
                    editActivity.ExpectedDuration = expectedDurationDateTime.Value;
                    editActivity.ParentActivityId = ParentActivityComboBox.Text != "Без Произлизаща Дейност" ? (int)ParentActivityComboBox.SelectedValue : null;
                    editActivity.ExecutantId = (int)MainExecutantComboBox.SelectedValue;
                    editActivity.employeePayment = float.Parse(PaymentMainExecutantTextBox.Text);
                    editActivity.StartDate = ActivityStartDatePicker.Value;

                    await _userClient.EditActivity(editActivity);
                    _dataService.editActivity(editActivity);

                    if (editTask != null)
                    {
                        var taskType = createTaskTypeResponse.ResponseObj.TaskTypes.Where(t => t.TaskTypeName == TaskComboBox.Text).FirstOrDefault();


                        editTask.ActivityId = editActivity.ActivityId;
                        editTask.Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value);
                        editTask.StartDate = taskStartDateTimePicker.Value;
                        editTask.ExecutantId = (int)ExecitantComboBox.SelectedValue;
                        editTask.Executant = ExecitantComboBox.SelectedItem as GetEmployeeDTO;
                        editTask.ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue;
                        editTask.Control = ControlComboBox.Text == "Няма Контрол" ? null : ControlComboBox.SelectedItem as GetEmployeeDTO;
                        editTask.Comments = CommentsRichTextBox.Text;
                        editTask.TaskTypeId = taskType.TaskTypeId;
                        editTask.taskType = taskType;
                        editTask.executantPayment = float.Parse(ExecutantPaymentTextBox.Text);
                        editTask.tax = float.Parse(TaxTextBox.Text);
                        editTask.CommentTax = TaxCommentRichTextBox.Text;
                        editTask.FinishDate = startDateDateTimePicker.Value;
                        editTask.Status = StatusComboBox.Text;

                        await _userClient.EditTask(editTask);
                        _dataService.editTask(editTask);
                    }
                }
            }
            Dispose();
        }
    }
}
