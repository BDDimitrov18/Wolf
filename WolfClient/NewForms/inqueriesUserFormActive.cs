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
using WolfClient.TemplateClasses;

namespace WolfClient.NewForms
{
    public partial class inqueriesUserFormActive : inqueriesUserForm
    {
        public inqueriesUserFormActive(IUserClient userClient, IApiClient apiClient, IDataService dataService, IAdminClient adminClient)
        : base(userClient, apiClient, dataService, adminClient)
        {
            InitializeComponent();
            this.Text = GlobalSettings.FormTitle + " : Справки потребител";
            this.Icon = new Icon(GlobalSettings.IconPath);
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
        }
        public override List<RequestWithClientsDTO> ApplyFilters()
        {
            var selectedPaymentStatuses = paymentStatusCheckBoxList.CheckedItems.Cast<string>().ToList();
            var selectedActivityTypeIds = checkedListBox3.CheckedItems.Cast<ActivityTypeSelection>().Select(a => a.ActivityTypeID).ToList();
            var selectedTaskTypeIds = checkedListBox4.CheckedItems.Cast<TaskTypeSelection>().Select(t => t.TaskTypeId).ToList();

            var logedEmployee = _dataService.getLoggedEmployee();
            List<int> selectedEmployeeIds = new List<int>();
            selectedEmployeeIds.Add(logedEmployee.EmployeeId);


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

            // Additional filtering based on the Status property of the request
            filteredRequests = filteredRequests.Where(r => r.requestDTO.Status == "Active").ToList();
            return filteredRequests;
        }
    }
}
