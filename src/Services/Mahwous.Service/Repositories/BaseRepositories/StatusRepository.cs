using Mahwous.Core.Entities;
using Mahwous.Service.Services;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class StatusRepository<TStatus> : RepositoryBase<TStatus> where TStatus : Status
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
            var response = await httpService.GetFile(urlWithId);
            return response;
        }
    }
}
