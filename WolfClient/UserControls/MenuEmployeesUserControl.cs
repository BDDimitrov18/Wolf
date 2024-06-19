using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WolfClient.NewForms;
using WolfClient.Services.Interfaces;

namespace WolfClient.UserControls
{
    public partial class MenuEmployeesUserControl : UserControl
    {

        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public MenuEmployeesUserControl(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm(_apiClient, _userClient, _adminClient);
            addEmployeeForm.Show();
        }

        private void MenuEmployeesUserControl_Load(object sender, EventArgs e)
        {

        }

        private async void Refresh_Click(object sender, EventArgs e)
        {
            var response = await _adminClient.GetAllEmployees();
            if (response.IsSuccess)
            {
                var employees = response.ResponseObj;
                EmployeesDataGridView.AutoGenerateColumns = false;
                EmployeesDataGridView.DataSource = employees;
                EmployeesDataGridView.Refresh();
            }
        }

        private void EmployeesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
