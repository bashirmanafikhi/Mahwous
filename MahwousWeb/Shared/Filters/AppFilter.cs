using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class AppFilter : IFilter<App>
    {
        public string Name { get; set; }
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();

        public IQueryable<App> Filter(IQueryable<App> queryable)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable.Where(v => v.Name.Contains(Name));
            }

            return queryable;
        }
    }
}
