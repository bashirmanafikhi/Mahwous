using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class MobileAppFilter : EntityFilter<MobileApp>
    {
        public string Name { get; set; }


        public override IQueryable<MobileApp> FilterOtherEntityProperties(IQueryable<MobileApp> queryable)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable.Where(v => v.Name.Contains(Name));
            }

            return queryable;
        }
    }
}
