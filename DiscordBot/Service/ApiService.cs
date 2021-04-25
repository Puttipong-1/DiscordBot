using DiscordBot.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class ApiService
    {
        private readonly HttpClient http;
        private const string url="";
        public ApiService(HttpClient _http)
        {
            http = _http;
        }
        private async Task<T> HandleApiResponse<T>(HttpResponseMessage responseMessage)
        {
            var responseJson =await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseObject = JsonSerializer.Deserialize<T>(responseJson);
                return responseObject;
            }
            if (string.IsNullOrWhiteSpace(responseJson)) throw new Exception("Can't deserialize json");
            throw new Exception(responseJson);
        }
        public async Task<T> PostAsync<T>(string apiUrl,object content=null, Dictionary<string, string> queryParam=null)
        {
            try
            {
                StringContent httpContent = null;
                if (content != null)
                {
                    httpContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
                }
                return await HandleApiResponse<T>(await http.PostAsync(BuildUri(apiUrl, queryParam), httpContent));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        private string BuildUri(string apiUrl,Dictionary<string,string> queryParam) 
        {
            UriBuilder baseUri = new UriBuilder($"{url}{apiUrl}");
            if (queryParam != null && queryParam.Count > 0)
            {
                foreach(string key in queryParam.Keys)
                {
                    string query = $"{key}={queryParam[key]}";
                    if (baseUri.Query != null && baseUri.Query.Length > 1)
                        baseUri.Query = baseUri.Query.Substring(1) + "&" + query;
                    else baseUri.Query = query;
                }
            }
            return baseUri.Uri.AbsoluteUri;
        }
    }
}
