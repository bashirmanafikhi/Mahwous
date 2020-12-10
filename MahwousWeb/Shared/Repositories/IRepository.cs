using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(int Id);

        Task<T> Get(int id);
        Task<T> GetRandom();
        Task<ICollection<T>> GetAll();

        Task<PaginatedResponse<ICollection<T>>> GetPaginated(PaginationDetails pagination);
        Task<PaginatedResponse<ICollection<T>>> GetFiltered(IFilter<T> filter);

        Task<int> GetCount();
        Task<int> GetCount(IFilter<T> filter);

        Task<Informations> GetInformations();
        Task<Informations> GetInformations(IFilter<T> filter);

        Task IncrementViews(int id);

    }
}
