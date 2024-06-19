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

namespace WolfClient.NewForms
{
    public partial class AddRequestForm : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public AddRequestForm(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }

        private void AddNonExistingClientButton_Click(object sender, EventArgs e)
        {
            AddClientForm addClientFrom = new AddClientForm(_apiClient, _userClient, _adminClient);
            addClientFrom.Show();
        }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
