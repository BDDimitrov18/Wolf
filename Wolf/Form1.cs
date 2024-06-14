using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolf.DTO;
using Wolf.Services;
using Wolf.Services.Interfaces;

namespace Wolf
{
    public partial class Form1 : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IUserClient _userClient;
        private readonly IAdminClient _adminClient;
        public Form1(IApiClient apiClient,IUserClient userClient, IAdminClient adminClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _userClient = userClient;
            _adminClient = adminClient;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PlotsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            panelContent.Controls.Clear();

            // Set the Dock property to Fill to make it responsive
            userControl.Dock = DockStyle.Fill;

            // Add the new UserControl
            panelContent.Controls.Add(userControl);
        }
        

        private void RequestToolStripButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(new MenuRequestsUserControl());
        }

        private void ObjectToolStripButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(new MenuObjectsUserControl());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientsStripButton_Click(object sender, EventArgs e)
        {
            LoadUserControl(new MenuClientsUserControl());
        }

        private void EmployeesStripLabel_Click(object sender, EventArgs e)
        {
            LoadUserControl(new MenuEmployeesUserControl());
        }
    }
}
