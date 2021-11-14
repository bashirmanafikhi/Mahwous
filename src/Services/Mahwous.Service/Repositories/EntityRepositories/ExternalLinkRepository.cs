using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.ExternalLinks;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class ExternalLinkRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public ExternalLinkRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchExternalLinksResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchExternalLinksResponse> Search(PaginationDetails pagination, ExternalLinkFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchExternalLinksResponse> Search(PaginationDetails pagination, ExternalLinkFilter filter, EntitySortType sortType)
        {
            SearchExternalLinksQuery query = new SearchExternalLinksQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchExternalLinksResponse> Search(SearchExternalLinksQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchExternalLinksResponse>(url);
        }

        public async Task<ListExternalLinksResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListExternalLinksResponse> List(ExternalLinkFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListExternalLinksResponse> List(ExternalLinkFilter filter, EntitySortType sortType)
        {
            ListExternalLinksQuery query = new ListExternalLinksQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListExternalLinksResponse> List(ListExternalLinksQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListExternalLinksResponse>(url);
        }

        public async Task<GetExternalLinkDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetExternalLinkDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomExternalLinkResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomExternalLinkResponse>(url + "/random");
        }

        public async Task<int> Create(CreateExternalLinkCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateExternalLinkCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateExternalLinkCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateExternalLinkCommand, int>(url, command);

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
