using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient httpClient;

        public HttpClient HttpClient => httpClient;

        private JsonSerializerOptions DefaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


        public HttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public HttpService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(@"https://www.mahwous.com/")
            };
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            try
            {
                var responseHTTP = await httpClient.GetAsync(url);

                if (responseHTTP.IsSuccessStatusCode)
                {
                    var response = await Deserialize<T>(responseHTTP, DefaultJsonSerializerOptions);
                    return new HttpResponseWrapper<T>(response, true, responseHTTP);
                }
                else
                {
                    return new HttpResponseWrapper<T>(default, false, responseHTTP);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data, data.GetType());
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data, data.GetType());
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> PutMultipartContent<T>(string url, T data, params KeyValuePair<string, Stream>[] files)
        {
            var dataJson = JsonSerializer.Serialize(data, data.GetType());
            var stringContent = new StringContent(dataJson);

            var multipartContent = new MultipartFormDataContent();

            multipartContent.Headers.ContentType.MediaType = "multipart/form-data";
            multipartContent.Add(stringContent, "serializedObject");
            foreach (var file in files)
            {
                if (file.Value != null && file.Value.Length > 0)
                    multipartContent.Add(new StreamContent(file.Value), file.Key, file.Key);
            }

            var response = await httpClient.PutAsync(url, multipartContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data, data.GetType());
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, DefaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }
            return new HttpResponseWrapper<TResponse>(default, false, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> PostMultipartContent<T, TResponse>(string url, T data, params KeyValuePair<string, Stream>[] files)
        {
            var dataJson = JsonSerializer.Serialize(data, data.GetType());
            var stringContent = new StringContent(dataJson);

            var multipartContent = new MultipartFormDataContent();

            multipartContent.Headers.ContentType.MediaType = "multipart/form-data";
            multipartContent.Add(stringContent, "serializedObject");
            foreach (var file in files)
            {
                if (file.Value != null && file.Value.Length > 0)
                    multipartContent.Add(new StreamContent(file.Value), file.Key, file.Key);
            }

            var response = await httpClient.PostAsync(url, multipartContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, DefaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }
            return new HttpResponseWrapper<TResponse>(default, false, response);
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);

            return new HttpResponseWrapper<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }

        public async Task<HttpResponseWrapper<object>> Post(string url)
        {
            var response = await httpClient.PostAsync(url, null);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> Put(string url)
        {
            var response = await httpClient.PutAsync(url, null);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<byte[]> GetFile(string url)
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
