using WolfClient.Services.Interfaces;
using WolfClient.Services;
using WolfClient.NewForms;
using WolfClient.UserControls;
using System.IO;
using Patagames.Pdf.Net;

namespace WolfClient
{
    internal static class Program
    {
        private static WebSocketClientService _webSocketClientService;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PdfCommon.Initialize(null, @"..\..\..\x64\pdfium.dll");
            string currentDirectory = Directory.GetCurrentDirectory();
            string relativePath = @"..\..\..\EKT\ek_atte.xlsx";
            string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

            IApiClient apiClient = new ApiClient();
            IUserClient userClient = new UserClient();
            IAdminClient adminClient = new AdminClient();
            IDataService dataService = new DataService();
            IReadExcel readExcel = new ReadExcel();
            IFileUploader fileUploader = new FileUploader();
            _webSocketClientService = new WebSocketClientService("wss://localhost:44359/ws", dataService);

            dataService.SetEKTViewModels(readExcel.ReadExcelFile(filePath));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuRequestsUserControl menuRequestsUserControl = new MenuRequestsUserControl(apiClient, userClient, adminClient, dataService, fileUploader);
            MenuClientsUserControl menuClientsUserControl = new MenuClientsUserControl(apiClient, userClient, adminClient, dataService);
            MenuEmployeesUserControl menuEmployeesUserControl = new MenuEmployeesUserControl(apiClient, userClient, adminClient, dataService);
            Application.Run(new MainForm(apiClient, userClient, adminClient, dataService, menuRequestsUserControl, menuClientsUserControl, menuEmployeesUserControl, fileUploader ,_webSocketClientService));
        }

        public static async Task ConnectWebSocketAsync(string token)
        {
            _webSocketClientService.SetToken(token);
            await _webSocketClientService.ConnectAsync();
        }
    }
}
