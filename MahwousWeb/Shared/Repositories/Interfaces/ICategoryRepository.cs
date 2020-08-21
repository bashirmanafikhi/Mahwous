using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task Add(Category category);
        Task<Category> Get(int id);
        Task<PaginatedResponse<List<Category>>> GetCategories(PaginationDTO paginationDTO);
        Task Update(Category category);
        Task Delete(int Id);
        Task<PaginatedResponse<List<Category>>> GetCategoriesFiltered(CategoryFilter categoryFilter);
    }
}
