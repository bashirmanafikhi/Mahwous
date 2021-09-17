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
    public class QuoteRepository : StatusRepository<QuoteStatus>
    {
        public QuoteRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(QuoteStatus quote)
        {
            var response = await httpService.Post<QuoteStatus, int>(url , quote);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(QuoteStatus quote)
        {
            var response = await httpService.Put(url , quote);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
