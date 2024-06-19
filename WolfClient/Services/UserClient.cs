using DTOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wolf.Models;
using WolfClient.Models;
using WolfClient.Services.Interfaces;
using static System.Windows.Forms.Design.AxImporter;

namespace WolfClient.Services
{
    public class UserClient: IUserClient
    {
        private readonly HttpClient _client;
        public UserClient()
        {
            _client = new HttpClient();
        }
        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ClientResponse<IEnumerable<GetClientDTO>>> GetAllClients() {
            try
            {
                var response = await _client.GetAsync("https://localhost:44359/api/User/GetAllClients");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Clients fetched  successfully!");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var clients = JsonSerializer.Deserialize<List<GetClientDTO>>(jsonResponse, options);
                    return new ClientResponse<IEnumerable<GetClientDTO>>
                    {
                        IsSuccess = true,
                        Message = "Employee Created Successfully",
                        ResponseObj = clients
                    };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<IEnumerable<GetClientDTO>>
                        {
                            IsSuccess = false,
                            Message = "Unauthorized",
                            ResponseObj = null
                        };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to fetch client client: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<IEnumerable<GetClientDTO>>
                        {
                            IsSuccess = false,
                            Message = "Error",
                            ResponseObj = null
                        };
                    }
                }
                
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<IEnumerable<GetClientDTO>>
                {
                    IsSuccess = false,
                    Message = "Network Error",
                    ResponseObj = null
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<IEnumerable<GetClientDTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    ResponseObj = null
                };
            }
        }

        public async Task<ClientResponse<GetClientDTO>> AddClient(CreateClientDTO client)
        {
            var jsonContent = JsonSerializer.Serialize(client);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateClient", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Client added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseClient = JsonSerializer.Deserialize<GetClientDTO>(jsonResponse, options);
                    return new ClientResponse<GetClientDTO> { IsSuccess = true, Message = "Client Created Successfully", ResponseObj = responseClient };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetClientDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add client: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetClientDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetClientDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetClientDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }
    }
}
