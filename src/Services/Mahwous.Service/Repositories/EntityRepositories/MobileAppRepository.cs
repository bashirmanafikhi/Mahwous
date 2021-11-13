using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.MobileApps;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class MobileAppRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public MobileAppRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchMobileAppsResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchMobileAppsResponse> Search(PaginationDetails pagination, MobileAppFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchMobileAppsResponse> Search(PaginationDetails pagination, MobileAppFilter filter, EntitySortType sortType)
        {
            SearchMobileAppsQuery query = new SearchMobileAppsQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchMobileAppsResponse> Search(SearchMobileAppsQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchMobileAppsResponse>(url);
        }

        public async Task<ListMobileAppsResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListMobileAppsResponse> List(MobileAppFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListMobileAppsResponse> List(MobileAppFilter filter, EntitySortType sortType)
        {
            ListMobileAppsQuery query = new ListMobileAppsQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListMobileAppsResponse> List(ListMobileAppsQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListMobileAppsResponse>(url);
        }

        public async Task<GetMobileAppDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetMobileAppDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomMobileAppResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomMobileAppResponse>(url + "/random");
        }

        public async Task<int> Create(CreateMobileAppCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateMobileAppCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateMobileAppCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateMobileAppCommand, int>(url, command);

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
