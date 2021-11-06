﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Mahwous.Service.Services
{
    public interface IHttpService
    {
        HttpClient HttpClient { get; }

        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<byte[]> GetFile(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> PostMultipartContent<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> PutMultipartContent<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<object>> Post(string url);
        Task<HttpResponseWrapper<object>> Put(string url);
    }
}