using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;

namespace WolfClient.Services
{
    public class AdminClient : IAdminClient
    {
        private readonly HttpClient _client;

        public AdminClient()
        {
            _client = new HttpClient();
        }

        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task AddEmployee(CreateEmployeeDTO employee)
        {
            var jsonContent = JsonSerializer.Serialize(employee);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/Admin/CreateEmployee", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Employee added successfully!");
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add employee: {response.ReasonPhrase}\nDetails: {error}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
            }
        }
    }
}
