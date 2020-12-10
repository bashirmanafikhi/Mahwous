using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class StatusFilter : IFilter<Status>
    {
        public PaginationDetails Pagination { get; set; }
        public StatusFilter()
        {
            Pagination = new PaginationDetails();
            Categories = new List<Category>();

            DownloadsCount = new Range<int>();
            ViewsCount = new Range<int>();
            LikesCount = new Range<int>();
            Date = new Range<DateTime>();

            SortType = SortType.Random;
            Visible = true;
            WithoutCategory = false;

            Date.From = new DateTime(2020, 01, 01);
            Date.To = DateTime.Now;

            DownloadsCount.To = int.MaxValue;
            ViewsCount.To = int.MaxValue;
            LikesCount.To = int.MaxValue;
        }

        public bool Visible { get; set; }

        public SortType SortType { get; set; }

        public Range<int> ViewsCount { get; set; }
        public Range<int> DownloadsCount { get; set; }
        public Range<int> LikesCount { get; set; }

        public Range<DateTime> Date { get; set; }
        public bool WithoutCategory { get; set; }
        public IList<Category> Categories { get; set; }



        public IQueryable<Status> Filter(IQueryable<Status> queryable)
        {
            // categories filter
            if (WithoutCategory)
            {
                queryable = queryable.Where(v => v.StatusCategories == null || v.StatusCategories.Count == 0);
            }
            else if (Categories != null && Categories.Count > 0)
            {
                int[] catIds = Categories.Select(c => c.Id).ToArray();

                queryable = queryable.Where(video =>
                    video.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }

            // other general status properties

            queryable = queryable.Where(v => v.ViewsCount >= ViewsCount.From && v.ViewsCount <= ViewsCount.To);
            queryable = queryable.Where(v => v.DownloadsCount >= DownloadsCount.From && v.DownloadsCount <= DownloadsCount.To);
            queryable = queryable.Where(v => v.LikesCount >= LikesCount.From && v.LikesCount <= LikesCount.To);

            queryable = queryable.Where(v => v.Date >= Date.From && v.Date <= Date.To);

            queryable = queryable.Where(v => v.Visible == Visible);

            switch (SortType)
            {
                case SortType.Newest:
                    queryable = queryable.OrderByDescending(v => v.Date);
                    break;
                case SortType.Oldest:
                    queryable = queryable.OrderBy(v => v.Date);
                    break;
                case SortType.Views:
                    queryable = queryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case SortType.Downloads:
                    queryable = queryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case SortType.Likes:
                    queryable = queryable.OrderByDescending(v => v.LikesCount);
                    break;
                case SortType.Random:
                    queryable = queryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            return queryable;
        }
    }

    public enum SortType
    {
        Newest,
        Oldest,
        Views,
        Downloads,
        Likes,
        Random
    }

    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }
}
