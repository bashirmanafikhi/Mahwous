using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Services;
using MahwousWeb.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MahwousWeb.Shared.Filters;
using System.Linq;

namespace MahwousWeb.Shared.Repositories
{
    public class AppRepository : IAppRepository
    {
        protected string url = "api/apps";

        private readonly IHttpService httpService;


        public AppRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task Add(App app)
        {
            var response = await httpService.Post(url, app);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Delete(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<App> Get(int id)
        {
            var response = await httpService.Get<App>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<App>>> GetApps(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<App>>(url, paginationDTO);
        }

        public async Task Update(App app)
        {
            var response = await httpService.Put(url, app);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
