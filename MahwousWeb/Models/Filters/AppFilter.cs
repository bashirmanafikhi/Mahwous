using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    public class AppFilter : FilterBase<App>
    {
        public string Name { get; set; }


        public override IQueryable<App> Filter(IQueryable<App> queryable)
        {
            queryable = base.Filter(queryable);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable.Where(v => v.Name.Contains(Name));
            }

            return queryable;
        }
    }
}
