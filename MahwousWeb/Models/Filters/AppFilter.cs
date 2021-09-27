using Mahwous.Core.Models;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    public class AppFilter : FilterBase<MobileApp>
    {
        public string Name { get; set; }


        public override IQueryable<MobileApp> Filter(IQueryable<MobileApp> queryable)
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
