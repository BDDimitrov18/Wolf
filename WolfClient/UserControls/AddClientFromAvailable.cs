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
    public partial class AddClientFromAvailable : UserControl
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        private List<GetClientDTO> _clientsList;
        public AddClientFromAvailable(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, List<GetClientDTO> clientsList, Panel Parent)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
            _clientsList = clientsList;
        }

        private void AddClientFromAvailable_Load(object sender, EventArgs e)
        {
            foreach (var client in _clientsList)
            {
                ClientsListComboBox.Items.Add(client);
            }
            ClientsListComboBox.DisplayMember = "FullName";
        }

        private void DeleteUserControlButton_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
        }
    }
}
