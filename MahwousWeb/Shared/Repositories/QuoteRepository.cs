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
    public class QuoteRepository : StatusRepositoryBase, IQuoteRepository
    {

        protected string url = "api/quotes";
        public QuoteRepository(IHttpService httpService) : base(httpService) { }



        public async Task Add(QuoteStatus quote)
        {
            var response = await httpService.Post(url, quote);
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

        public async Task<QuoteStatus> Get(int id)
        {
            var response = await httpService.Get<QuoteStatus>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<QuoteStatus>>> GetQuotes(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<QuoteStatus>>(url, paginationDTO);
        }

        public async Task Update(QuoteStatus quote)
        {
            var response = await httpService.Put(url, quote);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<PaginatedResponse<List<QuoteStatus>>> GetQuotesFiltered(QuoteFilter quoteFilter)
        {
            var responseHTTP = await httpService.Post<QuoteFilter, List<QuoteStatus>>($"{url}/filter", quoteFilter);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<QuoteStatus>>()
            {
                Response = responseHTTP.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }

        public async Task<FilteredInformations> GetInformations(QuoteFilter filter = null)
        {
            if (filter is null)
            {
                var responseHTTP = await httpService.Get<FilteredInformations>($"{url}/count");
                return responseHTTP.Response;
            }
            else
            {
                var responseHTTP = await httpService.Post<QuoteFilter, FilteredInformations>($"{url}/count", filter);
                return responseHTTP.Response;
            }
        }

        public async Task<QuoteStatus> GetRandomQuote()
        {
            var filter = new QuoteFilter() { RecordsPerPage = 1 };
            var responseHTTP = await GetQuotesFiltered(filter);
            var quote = responseHTTP.Response.FirstOrDefault();
            return quote;
        }
    }
}
