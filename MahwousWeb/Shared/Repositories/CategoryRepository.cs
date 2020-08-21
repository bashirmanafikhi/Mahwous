using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Services;
using MahwousWeb.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        
        private string url = "api/categories";

        private readonly IHttpService httpService;


        public CategoryRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task Add(Category category)
        {
            var response = await httpService.Post(url, category);
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

        public async Task<Category> Get(int id)
        {
            var response = await httpService.Get<Category>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PaginatedResponse<List<Category>>> GetCategories(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<Category>>(url, paginationDTO);
        }

        public async Task Update(Category category)
        {
            var response = await httpService.Put(url, category);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }


        public async Task<PaginatedResponse<List<Category>>> GetCategoriesFiltered(CategoryFilter categoryFilter)
        {
            var responseHTTP = await httpService.Post<CategoryFilter, List<Category>>($"{url}/filter", categoryFilter);
            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<Category>>()
            {
                Response = responseHTTP.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }

    }
}
