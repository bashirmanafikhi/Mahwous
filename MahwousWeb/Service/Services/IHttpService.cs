﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Services
{
    public interface IHttpService
    {
        HttpClient HttpClient { get; }

        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<byte[]> GetFile(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
        Task<HttpResponseWrapper<object>> Post(string url);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> PostMultipartContent<T, TResponse>(string url, T data, params KeyValuePair<string, Stream>[] files);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data);
        Task<HttpResponseWrapper<object>> PutMultipartContent<T>(string url, T data, params KeyValuePair<string, Stream>[] files);
        Task<HttpResponseWrapper<object>> Put(string url);
    }
}
