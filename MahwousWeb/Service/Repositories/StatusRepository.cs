﻿using MahwousWeb.Models.Models;
using MahwousWeb.Service.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class StatusRepository<TStatus> : Repository<TStatus> where TStatus : Status
    {
        public StatusRepository(IHttpService httpService, string url) : base(httpService, url) { }


        public async Task IncrementDownloads(int id)
        {
            var response = await httpService.Put($"{url}/IncrementDownloads/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task IncrementShares(int id)
        {
            var response = await httpService.Put($"{url}/IncrementShares/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task IncrementLikes(int id)
        {
            var response = await httpService.Put($"{url}/IncrementLikes/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DecrementLikes(int id)
        {
            var response = await httpService.Put($"{url}/DecrementLikes/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<byte[]> Download(int id)
        {
            string urlWithId = $"{url}/Download/{id}";

            return await httpService.GetFile(urlWithId);
        }
    }
}