using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.General;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.QuoteStatuses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class QuoteStatusRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public QuoteStatusRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchQuoteStatusesResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchQuoteStatusesResponse> Search(PaginationDetails pagination, QuoteFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchQuoteStatusesResponse> Search(PaginationDetails pagination, QuoteFilter filter, StatusSortType sortType)
        {
            SearchQuoteStatusesQuery query = new SearchQuoteStatusesQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchQuoteStatusesResponse> Search(SearchQuoteStatusesQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchQuoteStatusesResponse>(url);
        }

        public async Task<ListQuoteStatusesResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListQuoteStatusesResponse> List(QuoteFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListQuoteStatusesResponse> List(QuoteFilter filter, StatusSortType sortType)
        {
            ListQuoteStatusesQuery query = new ListQuoteStatusesQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListQuoteStatusesResponse> List(ListQuoteStatusesQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListQuoteStatusesResponse>(url);
        }

        public async Task<GetQuoteStatusDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetQuoteStatusDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomQuoteStatusResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomQuoteStatusResponse>(url + "/random");
        }

        public async Task<int> Create(CreateQuoteStatusCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateQuoteStatusCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateQuoteStatusCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateQuoteStatusCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Delete(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
