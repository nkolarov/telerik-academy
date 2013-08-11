// ********************************
// <copyright file="HttpRequester.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace MusicStore.Client
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpRequester
    {
        private string baseUrl;
        private HttpClient client;
        private string mediaType;

        public HttpRequester(string baseUrl, string mediaType = "application/json")
        {
            this.baseUrl = baseUrl;
            this.mediaType = mediaType;
            this.client = new HttpClient();
        }

        public T Get<T>(string serviceUrl)
        {
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Get;

            var response = client.SendAsync(request).Result;

            var returnObj = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(returnObj);
        }

        public T Post<T>(string serviceUrl, object data)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Post;

            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.mediaType);

            var response = client.SendAsync(request).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public void Put<T>(string serviceUrl, object data)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Put;

            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.mediaType);

            var response = client.SendAsync(request).Result;
        }

        public void Delete<T>(string serviceUrl, object data)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Delete;

            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.mediaType);

            var response = client.SendAsync(request).Result;
        }

        public Task<T> CreateGetRequestAsync<T>(string serviceUrl)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Get;

            return client.SendAsync(request).ContinueWith(
                (task) =>
                {
                    var response = task.Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<T>(content);
                    return result;
                });
        }

        public Task<T> PostAsync<T>(string serviceUrl, object data)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Post;

            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.mediaType);

            return client.SendAsync(request).ContinueWith((task) =>
            {
                var response = task.Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            });
        }

        public Task PostAsync(string serviceUrl, object data)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.baseUrl + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
            request.Method = HttpMethod.Post;

            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.mediaType);

            return client.SendAsync(request);
        }
    }
}
