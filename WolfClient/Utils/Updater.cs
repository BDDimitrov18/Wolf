using System.Diagnostics;
using System.Reflection;

public class Updater
{
    private static string UpdateUrl;
    private static string InstallerUrl;

    public static async Task CheckForUpdatesAsync(string controlType)
    {
        // Set URLs based on ControlType
        SetUrls(controlType);

        string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        string newVersion = await GetLatestVersionAsync();

        if (IsNewVersionAvailable(currentVersion, newVersion))
        {
            await DownloadAndUpdateAsync();
        }
    }

    private static void SetUrls(string controlType)
    {
        if (controlType == "Active")
        {
            UpdateUrl = "https://192.168.0.25:8443/updates/WolfVersion.txt";
            InstallerUrl = "https://192.168.0.25:8443/updates/WolfSetup.exe";
        }
        else if (controlType == "Archive")
        {
            UpdateUrl = "https://192.168.0.25:8443/updates/WolfVersionArchive.txt";
            InstallerUrl = "https://192.168.0.25:8443/updates/WolfSetupArchive.exe";
        }
        else
        {
            throw new InvalidOperationException("Invalid ControlType specified.");
        }
    }

    private static async Task<string> GetLatestVersionAsync()
    {
        using (HttpClient client = CreateHttpClient())
        {
            try
            {
                return await client.GetStringAsync(UpdateUrl);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
        }
    }

    private static bool IsNewVersionAvailable(string currentVersion, string newVersion)
    {
        Version current = new Version(currentVersion);
        Version latest = new Version(newVersion);

        return latest > current;
    }

    private static async Task DownloadAndUpdateAsync()
    {
        string installerPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(InstallerUrl));

        using (HttpClient client = CreateHttpClient())
        {
            try
            {
                using (HttpResponseMessage response = await client.GetAsync(InstallerUrl))
                {
                    response.EnsureSuccessStatusCode();  // Throws if not 200-299
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    using (FileStream fileStream = new FileStream(installerPath, FileMode.Create))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }

                Process.Start(installerPath);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
        }
    }

    private static HttpClient CreateHttpClient()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        };
        return new HttpClient(handler);
    }
}
