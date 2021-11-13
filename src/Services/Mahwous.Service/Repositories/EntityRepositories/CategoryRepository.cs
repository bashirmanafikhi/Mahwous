using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.Categories;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class CategoryRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public CategoryRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<SearchCategoriesResponse> Search(PaginationDetails pagination)
        {
            return await Search(pagination, null);
        }

        public async Task<SearchCategoriesResponse> Search(PaginationDetails pagination, CategoryFilter filter)
        {
            return await Search(pagination, filter, default);
        }

        public async Task<SearchCategoriesResponse> Search(PaginationDetails pagination, CategoryFilter filter, EntitySortType sortType)
        {
            SearchCategoriesQuery query = new SearchCategoriesQuery
            {
                Filter = filter,
                Pagination = pagination,
                SortType = sortType
            };
            return await Search(query);
        }

        public async Task<SearchCategoriesResponse> Search(SearchCategoriesQuery query)
        {
            string url = this.url + "?" + query.Query;

            return await httpService.GetHelper<SearchCategoriesResponse>(url);
        }

        public async Task<ListCategoriesResponse> List()
        {
            return await List(filter: null);
        }

        public async Task<ListCategoriesResponse> List(CategoryFilter filter)
        {
            return await List(filter, default);
        }

        public async Task<ListCategoriesResponse> List(CategoryFilter filter, EntitySortType sortType)
        {
            ListCategoriesQuery query = new ListCategoriesQuery
            {
                Filter = filter,
                SortType = sortType
            };
            return await List(query);
        }

        public async Task<ListCategoriesResponse> List(ListCategoriesQuery query)
        {
            string url = this.url + "/list?" + query.Query;
            return await httpService.GetHelper<ListCategoriesResponse>(url);
        }

        public async Task<GetCategoryDetailsResponse> GetDetails(int id)
        {
            return await httpService.GetHelper<GetCategoryDetailsResponse>(url + $"/{id }");
        }

        public async Task<GetRandomCategoryResponse> GetRandom()
        {
            return await httpService.GetHelper<GetRandomCategoryResponse>(url + "/random");
        }

        public async Task<int> Create(CreateCategoryCommand command)
        {
            var response = await httpService.PostMultipartContent<CreateCategoryCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task<int> Update(UpdateCategoryCommand command)
        {
            var response = await httpService.PutMultipartContent<UpdateCategoryCommand, int>(url, command);

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
