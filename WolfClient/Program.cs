
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
            // Print the current working directory
            IApiClient apiClient = new ApiClient(); 
            IUserClient userClient = new UserClient(); 
            IAdminClient adminClient = new AdminClient(); 
            IDataService dataService = new DataService();
            IReadExcel readExcel = new ReadExcel();
            IFileUploader fileUploader = new FileUploader();
            dataService.SetEKTViewModels(readExcel.ReadExcelFile(filePath));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuRequestsUserControl menuRequestsUserControl = new MenuRequestsUserControl(apiClient, userClient, adminClient, dataService,fileUploader);
            MenuClientsUserControl menuClientsUserControl = new MenuClientsUserControl(apiClient, userClient, adminClient);
            MenuEmployeesUserControl menuEmployeesUserControl = new MenuEmployeesUserControl(apiClient, userClient, adminClient,dataService);
            Application.Run(new MainForm(apiClient, userClient, adminClient, dataService, menuRequestsUserControl, menuClientsUserControl, menuEmployeesUserControl, fileUploader));
        }
    }
}