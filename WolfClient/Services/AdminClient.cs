using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wolf.Models;
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

        public async Task<ClientResponse<HttpResponseMessage?>> AddEmployee(CreateEmployeeDTO employee)
        {
            var jsonContent = JsonSerializer.Serialize(employee);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/Admin/CreateEmployee", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Employee added successfully!");
                    return new ClientResponse<HttpResponseMessage?> { IsSuccess = true, Message = "Employee Created Successfully", ResponseObj = response };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<HttpResponseMessage?> { IsSuccess = false, Message = "Unauthorized", ResponseObj = response };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add employee: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<HttpResponseMessage?> { IsSuccess = false, Message = "Error", ResponseObj = response };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<HttpResponseMessage?> { IsSuccess = false, Message = "Network error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<HttpResponseMessage?> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<IEnumerable<GetEmployeeDTO>>> GetAllEmployees()
        {
            try
            {
                var response = await _client.GetAsync("https://localhost:44359/api/Admin/GetAllEmployees");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Employees fetched  successfully!");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var employees = JsonSerializer.Deserialize<List<GetEmployeeDTO>>(jsonResponse, options);
                    return new ClientResponse<IEnumerable<GetEmployeeDTO>> { IsSuccess = true, Message = "Employee Created Successfully", ResponseObj = employees };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<IEnumerable<GetEmployeeDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to fetch employees client: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<IEnumerable<GetEmployeeDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<IEnumerable<GetEmployeeDTO>> { IsSuccess = false, Message = "Network error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<IEnumerable<GetEmployeeDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }
    }
}
