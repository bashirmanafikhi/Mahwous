using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.ImageStatuses;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class ImageStatusRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public ImageStatusRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchImageStatusesResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchImageStatusesResponse> Search(PaginationDetails pagination, ImageFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchImageStatusesResponse> Search(PaginationDetails pagination, ImageFilter filter, StatusSortType sortType)
        {
            SearchImageStatusesQuery query = new SearchImageStatusesQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchImageStatusesResponse> Search(SearchImageStatusesQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchImageStatusesResponse>(url);
        }

        public async Task<ListImageStatusesResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListImageStatusesResponse> List(ImageFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListImageStatusesResponse> List(ImageFilter filter, StatusSortType sortType)
        {
            ListImageStatusesQuery query = new ListImageStatusesQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListImageStatusesResponse> List(ListImageStatusesQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListImageStatusesResponse>(url);
        }

        public async Task<GetImageStatusDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetImageStatusDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomImageStatusResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomImageStatusResponse>(url + "/random");
        }

        public async Task<int> Create(CreateImageStatusCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateImageStatusCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateImageStatusCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateImageStatusCommand, int>(url, command);

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

        public async Task<byte[]> Download(int id)
        {
            string urlWithId = $"{url}/download/{id}";
            var response = await httpService.GetFile(urlWithId);
            return response;
        }
    }
}
