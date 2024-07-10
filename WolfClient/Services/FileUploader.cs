using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Wolf.Models;
using WolfClient.Services.Interfaces;

namespace WolfClient.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly HttpClient _client;
        public FileUploader()
        {
            _client = new HttpClient();
        }
        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<ClientResponse<HttpResponseMessage>> UploadFileAsync(string filePath)
        {
            using (var content = new MultipartFormDataContent())
            {
                var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                content.Add(fileContent, "file", Path.GetFileName(filePath));

                try
                {
                    var response = await _client.PostAsync("https://localhost:44359/api/Files/upload", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("File uploaded successfully!");
                        return new ClientResponse<HttpResponseMessage> { IsSuccess = true, Message = "File uploaded successfully!", ResponseObj = response };
                    }
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MessageBox.Show("You are not authorized or your session has expired.");
                            return new ClientResponse<HttpResponseMessage> { IsSuccess = false, Message = "Unauthorized", ResponseObj = null };
                        }
                        else
                        {
                            var error = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Failed to upload file: {response.ReasonPhrase}\nDetails: {error}");
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
}
