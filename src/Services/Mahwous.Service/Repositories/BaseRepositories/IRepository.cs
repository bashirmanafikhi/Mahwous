using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.General;
using Mahwous.Core.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public interface IRepository<T> where T : BaseEntity
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
