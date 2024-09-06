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
        string ip = "";
        public AdminClient(string ip)
        {
            this.ip = ip;
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true // Always return true
            };
            _client = new HttpClient(handler);
        }

        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ClientResponse<HttpResponseMessage>> EditEmployee(GetEmployeeDTO employeeDTO)
        {
            var jsonContent = JsonSerializer.Serialize(employeeDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://" + ip + "/api/Admin/EditEmployee", content);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Employee Edited Successfully", ResponseObj = responseRequests };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<HttpResponseMessage> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to edit employee: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<HttpResponseMessage> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<HttpResponseMessage> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<HttpResponseMessage> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<GetEmployeeDTO>?>> AddEmployee(List<CreateEmployeeDTO> employee)
        {
            var jsonContent = JsonSerializer.Serialize(employee);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


            try
            {
                var response = await _client.PostAsync("https://" + ip + "/api/Admin/CreateEmployee", content);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseClients = JsonSerializer.Deserialize<List<GetEmployeeDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetEmployeeDTO>?> { IsSuccess = true, Message = "Employee Created Successfully", ResponseObj = responseClients };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetEmployeeDTO>?> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add Employees: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetEmployeeDTO>?> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetEmployeeDTO>?> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetEmployeeDTO>?> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }


        }
    }
}
