using Mahwous.Core.Models;
using MahwousWeb.Models.Pagination;
using System;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    /// <summary>
    /// Used for getting a filtered responces
    /// </summary>
    /// <typeparam name="T">Class Type</typeparam>
    public interface IFilter<T> where T : ModelBase
    {
        PaginationDetails Pagination { get; set; }

        bool? Visible { get; set; }

        SortType SortType { get; set; }

        Range<int> ViewsCount { get; set; }

        Range<DateTime> Date { get; set; }

        IQueryable<T> Filter(IQueryable<T> queryable);
    }
}
