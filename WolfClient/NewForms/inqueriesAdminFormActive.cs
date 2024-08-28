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
using WolfClient.ViewModels;

namespace WolfClient.NewForms
{
    public partial class inqueriesAdminFormActive : inqueriesAdminForm
    {
        public inqueriesAdminFormActive(IUserClient userClient, IApiClient apiClient, IDataService dataService, IAdminClient adminClient)
        : base(userClient, apiClient, dataService, adminClient)
        {
            InitializeComponent();
            this.Text = GlobalSettings.FormTitle + " : Справки Админ";
            this.Icon = new Icon(GlobalSettings.IconPath);
        }

        public override List<RequestWithClientsDTO> ApplyFilters()
        {
            var selectedPaymentStatuses = paymentStatusCheckBoxList.CheckedItems.Cast<string>().ToList();
            var selectedActivityTypeIds = checkedListBox3.CheckedItems.Cast<ActivityTypeSelection>().Select(a => a.ActivityTypeID).ToList();
            var selectedTaskTypeIds = checkedListBox4.CheckedItems.Cast<TaskTypeSelection>().Select(t => t.TaskTypeId).ToList();
            var selectedEmployeeIds = employeesCheckBoxList.CheckedItems.Cast<EmployeeListItem>().Select(e => e.EmployeeId).ToList();
            var selectedTaskStatuses = taskStatusCheckBoxList.CheckedItems.Cast<string>().ToList();

            // Initial filtering based on the selected criteria
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
