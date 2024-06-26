
using WolfClient.Services.Interfaces;
using WolfClient.Services;
using WolfClient.NewForms;
using WolfClient.UserControls;

namespace WolfClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IApiClient apiClient = new ApiClient(); // Replace SomeApiClient with your actual implementation
            IUserClient userClient = new UserClient(); // Replace SomeUserClient with your actual implementation
            IAdminClient adminClient = new AdminClient(); // Replace SomeAdminClient with your actual implementation
            IDataService dataService = new DataService(); // Replace SomeAdminClient with your actual implementation

            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuRequestsUserControl menuRequestsUserControl = new MenuRequestsUserControl(apiClient, userClient, adminClient, dataService);
            MenuClientsUserControl menuClientsUserControl = new MenuClientsUserControl(apiClient, userClient, adminClient);
            MenuEmployeesUserControl menuEmployeesUserControl = new MenuEmployeesUserControl(apiClient, userClient, adminClient,dataService);
            Application.Run(new MainForm(apiClient, userClient, adminClient, dataService, menuRequestsUserControl, menuClientsUserControl, menuEmployeesUserControl));
        }
    }
}