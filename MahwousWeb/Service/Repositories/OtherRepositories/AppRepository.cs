using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using MahwousWeb.Service.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class AppRepository : RepositoryBase<App>
    {
        public AppRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(App app, Stream coverFile)
        {
            var response = await httpService.PostMultipartContent<App, int>(url, app,
                new KeyValuePair<string, Stream>("coverFile", coverFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(App app, Stream coverFile)
        {
            var response = await httpService.PutMultipartContent(url, app, 
                new KeyValuePair<string, Stream>("coverFile", coverFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
