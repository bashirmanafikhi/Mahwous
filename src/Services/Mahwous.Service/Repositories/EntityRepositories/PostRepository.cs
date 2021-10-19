using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.Posts;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class PostRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public PostRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchPostsResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchPostsResponse> Search(PaginationDetails pagination, PostFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchPostsResponse> Search(PaginationDetails pagination, PostFilter filter, EntitySortType sortType)
        {
            SearchPostsQuery query = new SearchPostsQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchPostsResponse> Search(SearchPostsQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchPostsResponse>(url);
        }

        public async Task<ListPostsResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListPostsResponse> List(PostFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListPostsResponse> List(PostFilter filter, EntitySortType sortType)
        {
            ListPostsQuery query = new ListPostsQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListPostsResponse> List(ListPostsQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListPostsResponse>(url);
        }

        public async Task<GetPostDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetPostDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomPostResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomPostResponse>(url + "/random");
        }

        public async Task<int> Create(CreatePostCommand command)
        {
            var response = await httpService.PostMultipartContent<CreatePostCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdatePostCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdatePostCommand, int>(url, command);

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
