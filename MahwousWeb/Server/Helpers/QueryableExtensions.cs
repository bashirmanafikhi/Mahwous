using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDetails paginationDTO)
        {
            return queryable
                .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)
                .Take(paginationDTO.RecordsPerPage);
        }


        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, IFilter<T> filter) where T : ModelBase
        {
            if (filter != null)
            {
                queryable = filter.Filter(queryable);
            }

            return queryable;
        }
    }
}
