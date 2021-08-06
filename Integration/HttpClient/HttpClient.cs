﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.HttpClient
{
    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        public HttpClient()
        {
            _httpClient = new System.Net.Http.HttpClient();
        }
        public async Task<HttpResponseMessage> SendPostAsync(string url, string userAccessToken, Dictionary<string, string> data)
        {
            if (data == null)
            {
                data = new Dictionary<string, string>();
            }
            if (!string.IsNullOrEmpty(userAccessToken))
            {
                data.Add("UserAccessToken", userAccessToken);
            }
            HttpResponseMessage response = await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            return response;
        }
        public async Task<HttpResponseMessage> ExternalGetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return response;
        }
    }
}
