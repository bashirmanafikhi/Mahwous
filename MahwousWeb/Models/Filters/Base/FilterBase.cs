using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MahwousWeb.Models.Filters
{
    public abstract class FilterBase<T> : IFilter<T> where T : ModelBase
    {

        public FilterBase()
        {
            Pagination = new PaginationDetails();

            ViewsCount = new Range<int>();

            Date = new Range<DateTime>();

            SortType = SortType.Random;
            Visible = true;


            Date.From = new DateTime(2020, 01, 01);
            Date.To = DateTime.UtcNow;


            ViewsCount.To = int.MaxValue;
        }


        public PaginationDetails Pagination { get; set; }

        public bool? Visible { get; set; }

        public SortType SortType { get; set; }

        public Range<int> ViewsCount { get; set; }

        public Range<DateTime> Date { get; set; }

        public virtual IQueryable<T> Filter(IQueryable<T> queryable)
        {


            // other general status properties

            queryable = queryable.Where(v => v.ViewsCount >= ViewsCount.From && v.ViewsCount <= ViewsCount.To);

            queryable = queryable.Where(v => v.Date.Date >= Date.From.Date && v.Date.Date <= Date.To.Date);

            if (Visible.HasValue)
            {
                queryable = queryable.Where(v => v.Visible == Visible);
            }


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
                case SortType.Random:
                    queryable = queryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            return queryable;
        }
    }




    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }
    public enum SortType
    {
        Newest,
        Oldest,
        Views,
        Random
    }
}
