using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class ReportFilter : EntityFilter<Report>
    {
        public string Details { get; set; }
        public string ViolatorId { get; set; }

        public override IQueryable<Report> FilterOtherEntityProperties(IQueryable<Report> queryable)
        {
            if (!string.IsNullOrEmpty(Details))
                queryable = queryable.Where(x => x.Details.Contains(Details));

            if (!string.IsNullOrEmpty(ViolatorId))
                queryable = queryable.Where(x => x.ViolatorId.Equals(ViolatorId));

            return queryable;
        }
    }
}
