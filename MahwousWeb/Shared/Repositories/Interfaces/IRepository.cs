using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T quote);
        Task Update(T quote);
        Task<T> Get(int id);
        Task Delete(int Id);

        Task<PaginatedResponse<List<T>>> GetPaginated(PaginationDTO paginationDTO);
        Task<PaginatedResponse<List<T>>> GetFiltered(IFilter<T> filter);
        Task<FilteredInformations> GetInformations(IFilter<T> filter = null);
        Task<T> GetRandom();
    }
}
