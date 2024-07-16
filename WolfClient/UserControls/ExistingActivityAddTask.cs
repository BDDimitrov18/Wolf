using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public GetActivityDTO _selectedActivity;
        public ExistingActivityAddTask(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityTypesDTOs = new List<GetActivityTypeDTO>();
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
            ExecitantComboBox.SelectedItem = ActivityComboBox.Text;


            // Set the data source for the ControlComboBox
            ControlComboBox.DataSource = employeesListForControl;
            ControlComboBox.DisplayMember = "FullName";
            ControlComboBox.ValueMember = "EmployeeId";
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

            ActivityTypeLabel.Text = $"Дейност : {selectedActivity.ActivityType.ActivityTypeName}";
            MainExecutantLabel.Text = $"Главен изпълнител : {selectedActivity.mainExecutant.FullName}";
            ParentActivityLabel.Text = $"Произлиза от : {selectedActivity.ParentActivity?.ActivityTypeName}";
            startDateLabel.Text = $"започнато на : {selectedActivity.StartDate}";
            ExpectedDurationLabel.Text = $"завършва на : {selectedActivity.ExpectedDuration}";
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
            if (ValidateTaskComboBox())
            {

                GetTaskTypeDTO taskTypeDTO = TaskComboBox.SelectedItem as GetTaskTypeDTO;
                GetActivityDTO activityDTO = ActivityComboBox.SelectedItem as GetActivityDTO;

                CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                {
                    ActivityId = (int)ActivityComboBox.SelectedValue,
                    Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                    StartDate = startDateDateTimePicker.Value,
                    ExecutantId = (int)ExecitantComboBox.SelectedValue,
                    ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                    Comments = CommentsRichTextBox.Text,
                    TaskTypeId = taskTypeDTO.TaskTypeId,
                    Status = StatusComboBox.Text,
                    executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                    CommentTax = taxCommentRichTexBox.Text,
                    tax = float.Parse(TaxTextBox.Text),
                };

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
                    StartDate = startDateDateTimePicker.Value,
                    ExecutantId = (int)ExecitantComboBox.SelectedValue,
                    ControlId = ControlComboBox.Text == "Няма Контрол" ? null : (int)ControlComboBox.SelectedValue,
                    Comments = CommentsRichTextBox.Text,
                    TaskTypeId = createTaskTypeResponse.ResponseObj.TaskTypes.ElementAt(0).TaskTypeId,
                    Status = StatusComboBox.Text,
                    executantPayment = float.Parse(ExecutantPaymentTextBox.Text),
                    CommentTax = taxCommentRichTexBox.Text,
                    tax = float.Parse(TaxTextBox.Text)
                };

                var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                _dataService.AddActivityToTheList(responseActivityFromTask.ResponseObj);

            }
        }

        private void ExecitantComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
