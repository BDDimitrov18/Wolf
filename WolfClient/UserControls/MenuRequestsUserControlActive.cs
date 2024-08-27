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
    public partial class MenuRequestsUserControlActive : MenuRequestsUserControlBase
    {
        public MenuRequestsUserControlActive(IApiClient apiClient, IUserClient userClient, IAdminClient adminClient, IDataService dataService, IFileUploader fileUploader)
        : base(apiClient, userClient, adminClient, dataService, fileUploader) // Pass parameters to the base class constructor
        {
            InitializeComponent();
        }
        public override void UpdateRequestDataGridView(List<GetRequestDTO> requestDTOs)
        {
            int? previousSelectedRequestId = null;
            _isRefreshing = true;
            try
            {
                if (requestDTOs == null)
                {
                    throw new ArgumentNullException(nameof(requestDTOs), "requestDTOs is null.");
                }

                // Step 1: Store the selected RequestId
                if (RequestDataGridView.CurrentRow != null && RequestDataGridView.CurrentRow.DataBoundItem is GetRequestDTO currentRequest)
                {
                    previousSelectedRequestId = currentRequest.RequestId;
                }

                // Apply filters to the requestDTOs list
                var filteredList = ApplyFilters(requestDTOs);

                // APPLY THE LOGIC HERE: Filter out only requests with Status == "Active"
                filteredList = filteredList.Where(r => r.Status == "Active").ToList();

                if (RequestDataGridView.InvokeRequired)
                {
                    RequestDataGridView.Invoke(new MethodInvoker(delegate
                    {
                        UpdateRequestGridViewRows(filteredList);
                        RestoreSelectedRow(previousSelectedRequestId);
                    }));
                }
                else
                {
                    UpdateRequestGridViewRows(filteredList);
                    RestoreSelectedRow(previousSelectedRequestId);
                }

                Console.WriteLine("DataSource set successfully with " + filteredList.Count + " items.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in UpdateRequestDataGridView: " + ex.Message);
                MessageBox.Show("Exception in UpdateRequestDataGridView: " + ex.Message);
            }
            finally
            {
                _isRefreshing = false;
            }
        }

    }
}
