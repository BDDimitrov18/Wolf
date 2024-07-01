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
    public partial class NonExistingActivityAddTask : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private readonly IDataService _dataService;

        public List<GetActivityTypeDTO> _activityTypesDTOs;
        public NonExistingActivityAddTask(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _dataService = dataService;
            _activityTypesDTOs = new List<GetActivityTypeDTO>();
        }

        private async void AddActivityTaskForm_Load(object sender, EventArgs e)
        {
            var response = await _userClient.GetActivityTypes();
            _dataService.SetActivityTypes(response.ResponseObj);
            ActivityComboBox.DataSource = _dataService.GetActivityTypeDTOs();
            ActivityComboBox.DisplayMember = "ActivityTypeName";
            ActivityComboBox.ValueMember = "ActivityTypeID";

            var employeesResponse = await _userClient.GetAllEmployees();
            _dataService.SetEmployees(employeesResponse.ResponseObj as List<GetEmployeeDTO>);
            ExecitantComboBox.DataSource = _dataService.GetEmployees();
            ExecitantComboBox.DisplayMember = "FullName";
            ExecitantComboBox.ValueMember = "EmployeeId";

            ControlComboBox.DataSource = _dataService.GetEmployees();
            ControlComboBox.DisplayMember = "FullName";
            ControlComboBox.ValueMember = "EmployeeId";


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

            ParentActivityComboBox.DataSource = activityDTOs;
            ParentActivityComboBox.DisplayMember = "ActivityTypeName";
            ParentActivityComboBox.ValueMember = "ActivityId";
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

        private void ControlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidateActivityComboBox())
            {
                if (ValidateTaskComboBox())
                {
                    //Take the 2 Valid cases
                }
                else
                {
                    //Create new task to the corresponding activityType
                }
            }
            else
            {
                //create new ActivityType with corresponding Task
            }
        }

        private async void AddActivitySubmit_Click(object sender, EventArgs e)
        {
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
                        ParentActivityId = ParentActivityComboBox.SelectedValue != null ? (int)ParentActivityComboBox.SelectedValue : null
                    };

                    //DOESNT MAP THE TASKS PROPERLY
                    var responseActivityDTO = await _userClient.AddActivity(createActivityDTO);

                    CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                    {
                        ActivityId = responseActivityDTO.ResponseObj.ActivityId,
                        Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                        StartDate = startDateDateTimePicker.Value,
                        ExecutantId = (int)ExecitantComboBox.SelectedValue,
                        ControlId = (int)ControlComboBox.SelectedValue,
                        Comments = CommentsRichTextBox.Text,
                        TaskTypeId = taskTypeDTO.TaskTypeId,
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
                        ParentActivityId = ParentActivityComboBox.SelectedValue != null ? (int)ParentActivityComboBox.SelectedValue : null
                    };

                    //DOESNT MAP THE TASKS PROPERLY
                    var responseActivityDTO = await _userClient.AddActivity(createActivityDTO);

                    CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                    {
                        ActivityId = responseActivityDTO.ResponseObj.ActivityId,
                        Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                        StartDate = startDateDateTimePicker.Value,
                        ExecutantId = (int)ExecitantComboBox.SelectedValue,
                        ControlId = (int)ControlComboBox.SelectedValue,
                        Comments = CommentsRichTextBox.Text,
                        TaskTypeId = createTaskTypeResponse.ResponseObj.TaskTypes.ElementAt(0).TaskTypeId,
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
                    ParentActivityId = ParentActivityComboBox.SelectedValue != null ?  (int)ParentActivityComboBox.SelectedValue : null
                };

                //DOESNT MAP THE TASKS PROPERLY
                var responseActivityDTO = await _userClient.AddActivity(createActivityDTO);

                CreateTaskDTO createTaskDTO = new CreateTaskDTO()
                {
                    ActivityId = responseActivityDTO.ResponseObj.ActivityId,
                    Duration = TimeSpan.FromHours((double)DurationNumericUpDown.Value),
                    StartDate = startDateDateTimePicker.Value,
                    ExecutantId = (int)ExecitantComboBox.SelectedValue,
                    ControlId = (int)ControlComboBox.SelectedValue,
                    Comments = CommentsRichTextBox.Text,
                    TaskTypeId = createTaskTypeResponse.ResponseObj.TaskTypes.ElementAt(0).TaskTypeId,
                };

                var responseActivityFromTask = await _userClient.AddTask(createTaskDTO);


                _dataService.AddActivityToTheList(responseActivityFromTask.ResponseObj);


            }
        }
    }
}
