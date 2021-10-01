using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System.Linq;

namespace Mahwous.Core.Extentions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDetails paginationDTO)
        {
            if (paginationDTO != null)
            {
                queryable = queryable
                    .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)
                    .Take(paginationDTO.RecordsPerPage);
            }

            return queryable;
        }


        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, IFilter<T> filter) where T : BaseEntity
        {
            if (filter != null)
            {
                queryable = filter.Filter(queryable);
            }

            return queryable;
        }
    }
}
