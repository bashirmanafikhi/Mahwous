using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class QuoteFilter : StatusFilter<QuoteStatus>
    {
        public string Content { get; set; }

        public override IQueryable<QuoteStatus> FilterOtherStatusProperties(IQueryable<QuoteStatus> queryable)
        {

            // Quotes Content
            if (!string.IsNullOrWhiteSpace(Content))
            {
                queryable = queryable.Where(v => v.Content.Contains(Content));
            }

            return queryable;
        }
    }
}
