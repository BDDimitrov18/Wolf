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

        public async Task<ClientResponse<List<GetClientDTO>>> AddClients(List<CreateClientDTO> clients)
        {
            var jsonContent = JsonSerializer.Serialize(clients);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateClient", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Clients added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseClients = JsonSerializer.Deserialize<List<GetClientDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetClientDTO>> { IsSuccess = true, Message = "Client Created Successfully", ResponseObj = responseClients };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetClientDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add clients: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetClientDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetClientDTO>> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetClientDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<GetRequestDTO>>> AddRequests(List<CreateRequestDTO> requestDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(requestDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateWorkRequest", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Requests added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<List<GetRequestDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetRequestDTO>> { IsSuccess = true, Message = "Requests Created Successfully", ResponseObj = responseRequests };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add requests: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<GetClient_RequestRelashionshipDTO>>> LinkClientsWithRequest(GetRequestDTO requestDTO, List<GetClientDTO> _clientsList) {
            var compositeRequest = new RequestWithClientsDTO
            {
                requestDTO = requestDTO,
                clientDTOs = _clientsList,
                activityDTOs = null
            };

            var jsonContent = JsonSerializer.Serialize(compositeRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/LinkClientsAndRequest", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Requests added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<List<GetClient_RequestRelashionshipDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetClient_RequestRelashionshipDTO>> { IsSuccess = true, Message = "Links Created Successfully", ResponseObj = responseRequests };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetClient_RequestRelashionshipDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add links: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetClient_RequestRelashionshipDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetClient_RequestRelashionshipDTO>> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetClient_RequestRelashionshipDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<GetRequestDTO>>> GetAllRequests()
        {
            try
            {
                var response = await _client.GetAsync("https://localhost:44359/api/User/GetAllRequests");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Requests fetched  successfully!");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var employees = JsonSerializer.Deserialize<List<GetRequestDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetRequestDTO>> { IsSuccess = true, Message = "Requests fetched successfully!", ResponseObj = employees };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to fetch requests client: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = "Network error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetRequestDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<RequestWithClientsDTO>>> GetLinked(List<GetRequestDTO> requestDTOs)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(requestDTOs);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("https://localhost:44359/api/User/GetLinkedClients", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Linked Clients fetched  successfully!");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var linkedList = JsonSerializer.Deserialize<List<RequestWithClientsDTO>>(jsonResponse, options);
                    return new ClientResponse<List<RequestWithClientsDTO>>
                    {
                        IsSuccess = true,
                        Message = "Employee Created Successfully",
                        ResponseObj = linkedList
                    };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<RequestWithClientsDTO>>
                        {
                            IsSuccess = false,
                            Message = "Unauthorized",
                            ResponseObj = null
                        };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to fetch Linked Cliens client: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<RequestWithClientsDTO>>
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
                return new ClientResponse<List<RequestWithClientsDTO>>
                {
                    IsSuccess = false,
                    Message = "Network Error",
                    ResponseObj = null
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<RequestWithClientsDTO>>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    ResponseObj = null
                };
            }
        }

        public async Task<ClientResponse<List<GetActivityTypeDTO>>> GetActivityTypes() 
        {

            try
            {
                var response = await _client.GetAsync("https://localhost:44359/api/User/GetActivityTypes");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Activity Types fetched successfully!");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var activityTypeDTOs = JsonSerializer.Deserialize<List<GetActivityTypeDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = true, Message = "ActivityType fetched Successfully", ResponseObj = activityTypeDTOs };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to fetch ActivityTypes client: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = "Network error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<IEnumerable<GetEmployeeDTO>>> GetAllEmployees()
        {
            try
            {
                var response = await _client.GetAsync("https://localhost:44359/api/User/GetAllEmployees");

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

        public async Task<ClientResponse<List<GetActivityTypeDTO>>> AddActivityTypes(List<CreateActivityTypeDTO> activityTypeDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(activityTypeDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateActivityTypes", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("ActivityTypes added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<List<GetActivityTypeDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = true, Message = "ActivityTypes Created Successfully", ResponseObj = responseRequests };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add AddActivityType: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetActivityTypeDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<GetActivityTypeDTO>> AddTaskTypes(List<CreateTaskTypeDTO> taskTypesDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(taskTypesDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateTaskType", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("TaskTypes added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetActivityTypeDTO>(jsonResponse, options);
                    return new ClientResponse<GetActivityTypeDTO> { IsSuccess = true, Message = "TaskTypes Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetActivityTypeDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add TaskType: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetActivityTypeDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetActivityTypeDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetActivityTypeDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<GetActivityDTO>> AddActivity(CreateActivityDTO activityDTO)
        {
            var jsonContent = JsonSerializer.Serialize(activityDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateActivity", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Activity added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseActivity = JsonSerializer.Deserialize<GetActivityDTO>(jsonResponse, options);
                    return new ClientResponse<GetActivityDTO> { IsSuccess = true, Message = "Acitivity Created Successfully", ResponseObj = responseActivity };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add TaskType: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }

        }

        public async Task<ClientResponse<GetActivityDTO>> AddTask(CreateTaskDTO taskDTO) {
            var jsonContent = JsonSerializer.Serialize(taskDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateTask", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tasks added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetActivityDTO>(jsonResponse, options);
                    return new ClientResponse<GetActivityDTO> { IsSuccess = true, Message = "Task Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add Task: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetActivityDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }
    }
}
