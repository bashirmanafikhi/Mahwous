using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using System.Linq;

namespace MahwousWeb.API.Helpers
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
