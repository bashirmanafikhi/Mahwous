using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System.Threading.Tasks;

namespace Mahwous.Core.Interfaces.Repositories
{
    public interface IStatusRepository<T, F> : IEntityRepository<T, F>
        where T : Status
        where F : StatusFilter<T>
    {
        Task<PaginatedList<T>> SearchAsync(F filter, PaginationDetails pagination, StatusSortType sortType);
    }
}
