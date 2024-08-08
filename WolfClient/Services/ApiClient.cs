using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WolfClient.Services.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Wolf.DTO;
using System.Text.Json;
using Wolf.Models;
using DTOS.DTO;

namespace WolfClient.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;
        private bool LoggedIn { get; set; }
        string ip = "";

        public ApiClient(string ip)
        {
            this.ip = ip;
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true // Always return true
            };
            _client = new HttpClient(handler);
        }

        public bool getLoginStatus() {
            return LoggedIn;
        }

        public void SetToken(string token)
        {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                LoggedIn= true;
        }

        public async Task<ClientResponse<TokenResponse>> GetJwtToken(LoginUserDto loginUser)
        {
            var jsonContent = JsonSerializer.Serialize(loginUser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://" + ip + "/api/Authentication/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return new ClientResponse<TokenResponse> { IsSuccess = true, Message = "Token Received!", ResponseObj = tokenResponse };
            }
            else
            {
                Console.WriteLine("Error: " + response.ReasonPhrase);
                return new ClientResponse<TokenResponse> { IsSuccess = false, Message = "Error: " + response.ReasonPhrase };
            }
        }
    }
}
