using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    /// <summary>
    /// Used for getting a filtered responces
    /// </summary>
    /// <typeparam name="T">Class Type</typeparam>
    public interface IFilter<T> where T : class
    {
        PaginationDetails Pagination { get; set; }

        IQueryable<T> Filter(IQueryable<T> queryable);
    }
}
