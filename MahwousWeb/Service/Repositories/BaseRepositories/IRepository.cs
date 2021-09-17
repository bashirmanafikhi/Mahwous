using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public interface IRepository<T> where T : ModelBase
    {
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
