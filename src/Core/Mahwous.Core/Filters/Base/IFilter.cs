using Mahwous.Core.Entities;
using Mahwous.Core.General;
using System;
using System.Linq;

namespace Mahwous.Core.Filters
{
    /// <summary>
    /// Used for getting a filtered responces
    /// </summary>
    /// <typeparam name="T">Class Type</typeparam>
    public interface IFilter<T> where T : BaseEntity
    {
        bool? IsHidden { get; set; }

        Range<int?> ViewsCount { get; set; }

        Range<DateTime> CreatedDate { get; set; }

        IQueryable<T> Filter(IQueryable<T> queryable);
    }
}
