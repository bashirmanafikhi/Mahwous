using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System.Linq;

namespace Mahwous.Core.Extentions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDetails pagination)
        {
            if (pagination != null)
            {
                queryable = queryable
                    .Skip((pagination.PageIndex - 1) * pagination.PageSize)
                    .Take(pagination.PageSize);
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
