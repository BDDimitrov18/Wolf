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
    public partial class MenuRequestsUserControlArchive : MenuRequestsUserControlBase
    {
        public MenuRequestsUserControlArchive(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService, IFileUploader fileUploader)
        : base(apiClient, userClient, adminClient, dataService, fileUploader) // Pass parameters to the base class constructor
        {
            InitializeComponent();
        }

        protected override void editRequestButton_Click(object sender, EventArgs e)
        {
            if (_dataService.GetSelectedRequest() != null)
            {
                EditRequestFormArchive editRequestForm = new EditRequestFormArchive(_apiClient, _userClient, _adminClient, _dataService);
                editRequestForm.Show();
                editRequestForm.Disposed += EditRequestFormDispose;
            }
            else
            {
                MessageBox.Show("Please Select A request");
            }
        }

        protected override async void DeleteRequestButton_Click(object sender, EventArgs e)
        {
            // Check if the role is "user"
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete requests.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // If the role is not "user", execute the base method
                base.DeleteRequestButton_Click(sender, e);
            }
        }
        protected override void button1_Click(object sender, EventArgs e)
        {
            // Check if the role is "user"
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add a new request.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // If the role is not "user", execute the base method
                base.button1_Click(sender, e);
            }
        }
        protected override void button1_Click_1(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add a client to the request.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.button1_Click_1(sender, e);
            }
        }
        protected override async void deleteClientsButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete clients from the request.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.deleteClientsButton_Click(sender, e);
            }
        }
        protected override void editClientButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit clients.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.editClientButton_Click(sender, e);
            }
        }
        protected override void ActivityAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add activities.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.ActivityAddButton_Click(sender, e);
            }
        }
        protected override async void DeleteActivityButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete activities.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.DeleteActivityButton_Click(sender, e);
            }
        }

        protected override void editActivityButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit activities.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.editActivityButton_Click(sender, e);
            }
        }

        protected override void PlotsAddButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add plots.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.PlotsAddButton_Click(sender, e);
            }
        }

        protected override async void DeletePlotsButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete plots.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.DeletePlotsButton_Click(sender, e);
            }
        }

        protected override void editPlotButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit plots.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.editPlotButton_Click(sender, e);
            }
        }
        protected override void AddOwnersButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add owners.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                base.AddOwnersButton_Click(sender, e);
            }
        }
        protected override async void DeleteOwnershipButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete ownerships.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.DeleteOwnershipButton_Click(sender, e);
        }

        protected override void editOwnershipButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit ownerships.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.editOwnershipButton_Click(sender, e);
        }

        protected override void button3_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to add invoices.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.button3_Click(sender, e);
        }

        protected override async void DeleteInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to delete invoices.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.DeleteInvoiceButton_Click(sender, e);
        }

        protected override void EditInvoiceButton_Click(object sender, EventArgs e)
        {
            if (_dataService.getRole() == "user")
            {
                MessageBox.Show("You do not have permission to edit invoices.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            base.EditInvoiceButton_Click(sender, e);
        }


    }
}
