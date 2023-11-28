using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class HttpService
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public HttpService(string baseUrl, string apiKey) 
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
        }

        public async Task<T> GetData<T>(string endpoint)
        {
            try
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("X-Yandex-API-Key", _apiKey);
                HttpResponseMessage response = await client.GetAsync(_baseUrl + endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    T? weatherInfo = JsonConvert.DeserializeObject<T>(responseBody);
                    return weatherInfo!;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
