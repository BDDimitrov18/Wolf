using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using WolfClient.NewForms;
using WolfClient.Services;
using WolfClient.Services.Interfaces;
using WolfClient.UserControls;

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
            // Set up configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();

            string environment = configuration["Environment"] ?? "Production";
            string pdfiumDllPath = configuration["Paths:PdfiumDll"];
            string relativePath = configuration["Paths:RelativePath"];
            string webSocketUrl = configuration["WebSocketClientService:Url"];
            string apiBaseUrl = configuration["Api:BaseUrl"];
            string controlType = configuration["ControlSettings:ControlType"] ?? "Active";

            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

            IApiClient apiClient = new ApiClient(apiBaseUrl);
            IUserClient userClient = new UserClient(apiBaseUrl);
            IAdminClient adminClient = new AdminClient(apiBaseUrl);
            IDataService dataService = new DataService();
            IReadExcel readExcel = new ReadExcel();
            IFileUploader fileUploader = new FileUploader(apiBaseUrl);
            _webSocketClientService = new WebSocketClientService(webSocketUrl, dataService);

            dataService.SetEKTViewModels(readExcel.ReadExcelFile(filePath));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run updates only in production environment
            if (environment == "Production")
            {
               Task.Run(async () => await Updater.CheckForUpdatesAsync()).Wait();
            }

            
            Application.Run(new MainForm(apiClient, userClient, adminClient, dataService, fileUploader, _webSocketClientService, controlType));
        }

        public static async Task ConnectWebSocketAsync(string token)
        {
            _webSocketClientService.SetToken(token);
            await _webSocketClientService.ConnectAsync();
        }
    }
}
