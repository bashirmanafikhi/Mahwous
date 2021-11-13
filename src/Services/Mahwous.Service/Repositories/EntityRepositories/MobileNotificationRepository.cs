using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.MobileNotifications;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class MobileNotificationRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public MobileNotificationRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchMobileNotificationsResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchMobileNotificationsResponse> Search(PaginationDetails pagination, MobileNotificationFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchMobileNotificationsResponse> Search(PaginationDetails pagination, MobileNotificationFilter filter, EntitySortType sortType)
        {
            SearchMobileNotificationsQuery query = new SearchMobileNotificationsQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchMobileNotificationsResponse> Search(SearchMobileNotificationsQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchMobileNotificationsResponse>(url);
        }

        public async Task<ListMobileNotificationsResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListMobileNotificationsResponse> List(MobileNotificationFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListMobileNotificationsResponse> List(MobileNotificationFilter filter, EntitySortType sortType)
        {
            ListMobileNotificationsQuery query = new ListMobileNotificationsQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListMobileNotificationsResponse> List(ListMobileNotificationsQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListMobileNotificationsResponse>(url);
        }

        public async Task<GetMobileNotificationDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetMobileNotificationDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomMobileNotificationResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomMobileNotificationResponse>(url + "/random");
        }

        public async Task<int> Create(CreateMobileNotificationCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateMobileNotificationCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateMobileNotificationCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateMobileNotificationCommand, int>(url, command);

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
