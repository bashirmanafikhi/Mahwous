using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class ExternalLinkFilter : EntityFilter<ExternalLink>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExternalLinkType? LinkType { get; set; }
        public string Url { get; set; }

        public override IQueryable<ExternalLink> FilterOtherEntityProperties(IQueryable<ExternalLink> queryable)
        {
            if (!string.IsNullOrEmpty(Name))
                queryable = queryable.Where(x => x.Name.Contains(Name));

            if (!string.IsNullOrEmpty(Description))
                queryable = queryable.Where(x => x.Description.Contains(Description));

            if (!string.IsNullOrEmpty(Url))
                queryable = queryable.Where(x => x.Url.Contains(Url));

            if (LinkType.HasValue)
                queryable = queryable.Where(x => x.LinkType == LinkType);

            return queryable;
        }
    }
}
