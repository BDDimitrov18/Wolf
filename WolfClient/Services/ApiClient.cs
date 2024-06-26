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

namespace WolfClient.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;
        private bool LoggedIn { get; set; }

        public ApiClient()
        {
            _client = new HttpClient();
        }

        public bool getLoginStatus() {
            return LoggedIn;
        }

        public void SetToken(string token)
        {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                LoggedIn= true;
        }

        public async Task<ClientResponse<string>> GetJwtToken(LoginUserDto loginUser)
        {
            var jsonContent = JsonSerializer.Serialize(loginUser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:44359/api/Authentication/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response :" + response);
                return new ClientResponse<string> { IsSuccess = true, Message = "Token Received!", ResponseObj = token };
            }
            else
            {
                Console.WriteLine("Error: " + response.ReasonPhrase);
                return new ClientResponse<string> { IsSuccess = false, Message = "Error: " + response.ReasonPhrase };
            }
        }
    }

}
