using Mahwous.Core.Models;
using MahwousWeb.Service.Services;
using System;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class QuoteRepository : StatusRepository<QuoteStatus>
    {
        public QuoteRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(QuoteStatus quote)
        {
            var response = await httpService.Post<QuoteStatus, int>(url, quote);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(QuoteStatus quote)
        {
            var response = await httpService.Put(url, quote);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
