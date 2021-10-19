using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.VideoStatuses;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class VideoStatusRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public VideoStatusRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchVideoStatusesResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchVideoStatusesResponse> Search(PaginationDetails pagination, VideoFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchVideoStatusesResponse> Search(PaginationDetails pagination, VideoFilter filter, StatusSortType sortType)
        {
            SearchVideoStatusesQuery query = new SearchVideoStatusesQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchVideoStatusesResponse> Search(SearchVideoStatusesQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchVideoStatusesResponse>(url);
        }

        public async Task<ListVideoStatusesResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListVideoStatusesResponse> List(VideoFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListVideoStatusesResponse> List(VideoFilter filter, StatusSortType sortType)
        {
            ListVideoStatusesQuery query = new ListVideoStatusesQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListVideoStatusesResponse> List(ListVideoStatusesQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListVideoStatusesResponse>(url);
        }

        public async Task<GetVideoStatusDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetVideoStatusDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomVideoStatusResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomVideoStatusResponse>(url + "/random");
        }

        public async Task<int> Create(CreateVideoStatusCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateVideoStatusCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateVideoStatusCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateVideoStatusCommand, int>(url, command);

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

        public Task<byte[]> Download(int id)
        {
            throw new NotImplementedException();
        }
    }
}
