
using WolfClient.Services.Interfaces;
using WolfClient.Services;
using WolfClient.NewForms;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(apiClient, userClient, adminClient));
        }
    }
}