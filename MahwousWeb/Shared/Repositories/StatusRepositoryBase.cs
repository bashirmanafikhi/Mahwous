using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Repositories.Interfaces;
using MahwousWeb.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories
{
    public class StatusRepositoryBase : IStatusRepositoryBase
    {
        private readonly string url = "api/statuses";

        protected readonly IHttpService httpService;

        public StatusRepositoryBase(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task IncrementViews(int id)
        {
            var response = await httpService.Post($"{url}/incrementviews/{id}");
            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }

        public async Task IncrementDownloads(int id)
        {
            var response = await httpService.Post($"{url}/incrementdownloads/{id}");
            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }

        public async Task IncrementLikes(int id)
        {
            var response = await httpService.Post($"{url}/incrementlikes/{id}");
            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
