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
    
        public async Task<ClientResponse<GetPlotDTO>> AddPlot(CreatePlotDTO plotDto) {
            var jsonContent = JsonSerializer.Serialize(plotDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreatePlot", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Plot added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetPlotDTO>(jsonResponse, options);
                    return new ClientResponse<GetPlotDTO> { IsSuccess = true, Message = "Plot Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetPlotDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add Task: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetPlotDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetPlotDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetPlotDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<GetActivity_PlotRelashionshipDTO>>> AddActivity_PlotRelashionship(List<CreateActivity_PlotRelashionshipDTO> activity_PlotRelashionshipDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(activity_PlotRelashionshipDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateActivity_PlotRelashionship", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Relashionships added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<List<GetActivity_PlotRelashionshipDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetActivity_PlotRelashionshipDTO>> { IsSuccess = true, Message = "Relashionships Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetActivity_PlotRelashionshipDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add Task: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetActivity_PlotRelashionshipDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetActivity_PlotRelashionshipDTO>> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetActivity_PlotRelashionshipDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<GetDocumentOfOwnershipDTO>> AddDocumentOfOwnership(CreateDocumentOfOwnershipDTO documentOfOwnershipDTO) {
            var jsonContent = JsonSerializer.Serialize(documentOfOwnershipDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateDocumentOfOwnership", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Document added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetDocumentOfOwnershipDTO>(jsonResponse, options);
                    return new ClientResponse<GetDocumentOfOwnershipDTO> { IsSuccess = true, Message = "Document Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetDocumentOfOwnershipDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add Document: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetDocumentOfOwnershipDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetDocumentOfOwnershipDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetDocumentOfOwnershipDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<GetOwnerDTO>> AddOwner(CreateOwnerDTO ownerDTO)
        {
            var jsonContent = JsonSerializer.Serialize(ownerDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateOwner", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Owner added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetOwnerDTO>(jsonResponse, options);
                    return new ClientResponse<GetOwnerDTO> { IsSuccess = true, Message = "Owner Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetOwnerDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add Owner: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetOwnerDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetOwnerDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetOwnerDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO>> AddDocumentOwnerRelashionship(CreateDocumentOfOwnership_OwnerRelashionshipDTO DocumentOwnerRelashionship) {
            var jsonContent = JsonSerializer.Serialize(DocumentOwnerRelashionship);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateDocumentOwnerRelashionship", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("DocumentOwner added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetDocumentOfOwnership_OwnerRelashionshipDTO>(jsonResponse, options);
                    return new ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO> { IsSuccess = true, Message = "DocumentOwner Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add DocumentOwner: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetDocumentOfOwnership_OwnerRelashionshipDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO>> AddPlotDocumentRelashionship(CreatePlot_DocumentOfOwnershipRelashionshipDTO PlotDocumentRelashionship) {
            var jsonContent = JsonSerializer.Serialize(PlotDocumentRelashionship);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreateDocumentPlotRelashionship", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("PlotDocument added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetPlot_DocumentOfOwnershipRelashionshipDTO>(jsonResponse, options);
                    return new ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO> { IsSuccess = true, Message = "PlotDocument Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add PlotDocument: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetPlot_DocumentOfOwnershipRelashionshipDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }
    
        public async Task<ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> AddPlotOwnerRelashionship(CreateDocumentPlot_DocumentOwnerRelashionshipDTO relashionshipDTO) {
            var jsonContent = JsonSerializer.Serialize(relashionshipDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreatePlotOwnerRelashionship", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("PlotOwner added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetDocumentPlot_DocumentOwnerRelashionshipDTO>(jsonResponse, options);
                    return new ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO> { IsSuccess = true, Message = "PlotOwner Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add PlotOwner: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetDocumentPlot_DocumentOwnerRelashionshipDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>>> GetLinkedPlotOwnerRelashionships(List<GetPlotDTO> plots) {
            var jsonContent = JsonSerializer.Serialize(plots);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/GetLinkedPlotOwnerRelashionships", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("PlotOwner retrieved successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>>(jsonResponse, options);
                    return new ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> { IsSuccess = true, Message = "PlotOwners Retrieved Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to retrieve PlotOwners: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<List<GetDocumentPlot_DocumentOwnerRelashionshipDTO>> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<HttpResponseMessage>> DeleteRequest(List<GetRequestDTO> requestDTO) {
            var jsonContent = JsonSerializer.Serialize(requestDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/DeleteRequest", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Request Deleted successfully!");
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Request Deleted successfully!", ResponseObj = response };
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
                        MessageBox.Show($"Failed to delete Request: {response.ReasonPhrase}\nDetails: {error}");
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
    
        public async Task<ClientResponse<HttpResponseMessage>> DeleteClientRequest(List<GetClient_RequestRelashionshipDTO> clientDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(clientDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/DeleteClientRequestRelashionships", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("ClientRequestRelashionship Deleted successfully!");
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "ClientRequestRelashionship Deleted successfully!", ResponseObj = response };
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
                        MessageBox.Show($"Failed to delete ClientRequestRelashionship: {response.ReasonPhrase}\nDetails: {error}");
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
    
        public async Task<ClientResponse<HttpResponseMessage>> DeleteTasks(List<GetTaskDTO> tasks) {
            var jsonContent = JsonSerializer.Serialize(tasks);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/DeleteTasks", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tasks Deleted successfully!");
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Tasks Deleted successfully!", ResponseObj = response };
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
                        MessageBox.Show($"Failed to delete Tasks: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> DeleteActivities(List<GetActivityDTO> activities)
        {
            var jsonContent = JsonSerializer.Serialize(activities);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/DeleteActivities", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Activities Deleted successfully!");
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Activities Deleted successfully!", ResponseObj = response };
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
                        MessageBox.Show($"Failed to delete Activities: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<GetPowerOfAttorneyDocumentDTO>> AddPowerOfAttorney(CreatePowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO)
        {
            var jsonContent = JsonSerializer.Serialize(powerOfAttorneyDocumentDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/CreatePowerOfAttorney", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("PowerOfAttorneyDocument added successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseTasks = JsonSerializer.Deserialize<GetPowerOfAttorneyDocumentDTO>(jsonResponse, options);
                    return new ClientResponse<GetPowerOfAttorneyDocumentDTO> { IsSuccess = true, Message = "PowerOfAttorneyDocument Created Successfully", ResponseObj = responseTasks };
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Optionally refresh the token and retry
                        MessageBox.Show("You are not authorized or your session has expired.");
                        return new ClientResponse<GetPowerOfAttorneyDocumentDTO> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add PowerOfAttorneyDocument: {response.ReasonPhrase}\nDetails: {error}");
                        return new ClientResponse<GetPowerOfAttorneyDocumentDTO> { IsSuccess = false, Message = "Error", ResponseObj = null };
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}");
                return new ClientResponse<GetPowerOfAttorneyDocumentDTO> { IsSuccess = false, Message = "Network Error", ResponseObj = null };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred: {ex.Message}");
                return new ClientResponse<GetPowerOfAttorneyDocumentDTO> { IsSuccess = false, Message = ex.Message, ResponseObj = null };
            }
        }

        public async Task<ClientResponse<HttpResponseMessage>> activityPlotRelashionshipRemove(List<GetActivity_PlotRelashionshipDTO> relashionshipDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(relashionshipDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/ActivityPlotOnPlotRemove", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Plots Removed successfully!");
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Plots Removed successfully!", ResponseObj = response };
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
                        MessageBox.Show($"Failed to remove Plots: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> deletePlotOwnerRelashionships(List<GetDocumentPlot_DocumentOwnerRelashionshipDTO> relashionshipDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(relashionshipDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/deletePlotOwnerRelashionships", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Relashionship Removed successfully!");
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Relashionship Removed successfully!", ResponseObj = response };
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
                        MessageBox.Show($"Failed to remove Plots: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditRequest(GetRequestDTO requestDTOs)
        {
            var jsonContent = JsonSerializer.Serialize(requestDTOs);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditRequest", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Requests edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Requests Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit requests: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditClient(GetClientDTO clientDTO)
        {
            var jsonContent = JsonSerializer.Serialize(clientDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditClient", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Client edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Client Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit client: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditActivity(GetActivityDTO activityDTO)
        {
            var jsonContent = JsonSerializer.Serialize(activityDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditActivity", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Activity edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Activity Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit activity: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditTask(GetTaskDTO taskDTO)
        {
            var jsonContent = JsonSerializer.Serialize(taskDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditTask", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Task Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit task: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditPlot(GetPlotDTO plotDTO)
        {
            var jsonContent = JsonSerializer.Serialize(plotDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditPlot", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Plot edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Plot Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit plot: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditOwner(GetOwnerDTO ownerDto)
        {
            var jsonContent = JsonSerializer.Serialize(ownerDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditOwner", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Owner edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "Owner Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit owner: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditDocumentOfOwnership(GetDocumentOfOwnershipDTO documentOfOwnershipDTO)
        {
            var jsonContent = JsonSerializer.Serialize(documentOfOwnershipDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditDocumentOfOwnership", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("DocumentOfOwnership edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "DocumentOfOwnership Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit documentOfOwnership: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditPowerOfAttorney(GetPowerOfAttorneyDocumentDTO powerOfAttorneyDocumentDTO)
        {
            var jsonContent = JsonSerializer.Serialize(powerOfAttorneyDocumentDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditPowerOfAttorneyDocument", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("PowerOfAttorney edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "powerOfAttorney Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit powerOfAttorney: {response.ReasonPhrase}\nDetails: {error}");
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

        public async Task<ClientResponse<HttpResponseMessage>> EditPlotOwnerRelashionship(GetDocumentPlot_DocumentOwnerRelashionshipDTO documentPlot_DocumentOwnerRelashionshipDTO)
        {
            var jsonContent = JsonSerializer.Serialize(documentPlot_DocumentOwnerRelashionshipDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("https://localhost:44359/api/User/EditDocumentPlotOwnerRelationship", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("PlotOwnerRelashionship edited successfully!");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseRequests = JsonSerializer.Deserialize<HttpResponseMessage>(jsonResponse, options);
                    return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "PlotOwnerRelashionship Edited Successfully", ResponseObj = responseRequests };
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
                        MessageBox.Show($"Failed to edit PlotOwnerRelashionship: {response.ReasonPhrase}\nDetails: {error}");
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
    }
}
