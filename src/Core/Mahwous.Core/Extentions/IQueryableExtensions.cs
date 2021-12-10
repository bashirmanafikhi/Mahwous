using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System;
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


        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, StatusSortType sortType) where T : Status
        {
            switch (sortType)
            {
                case StatusSortType.Newest:
                    queryable = queryable.OrderByDescending(v => v.CreatedAt);
                    break;
                case StatusSortType.Oldest:
                    queryable = queryable.OrderBy(v => v.CreatedAt);
                    break;
                case StatusSortType.Views:
                    queryable = queryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case StatusSortType.Downloads:
                    queryable = queryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case StatusSortType.Likes:
                    queryable = queryable.OrderByDescending(v => v.LikesCount);
                    break;
                case StatusSortType.Shares:
                    queryable = queryable.OrderByDescending(v => v.SharesCount);
                    break;
                case StatusSortType.Random:
                    queryable = queryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            return queryable;
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, EntitySortType sortType) where T : BaseEntity
        {
            switch (sortType)
            {
                case EntitySortType.Newest:
                    queryable = queryable.OrderByDescending(v => v.CreatedAt);
                    break;
                case EntitySortType.Oldest:
                    queryable = queryable.OrderBy(v => v.CreatedAt);
                    break;
                case EntitySortType.MostViewed:
                    queryable = queryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case EntitySortType.LeastViewed:
                    queryable = queryable.OrderBy(v => v.ViewsCount);
                    break;
                case EntitySortType.Random:
                    queryable = queryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            return queryable;
        }
    }
}
