using Mahwous.Core.Models;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    public class QuoteFilter : StatusFilterBase<QuoteStatus>
    {
        public string Content { get; set; }

        public override IQueryable<QuoteStatus> Filter(IQueryable<QuoteStatus> queryable)
        {
            queryable = base.Filter(queryable);
            //queryable = base.Filter(queryable).Cast<QuoteStatus>();

            // Quotes Content
            if (!string.IsNullOrWhiteSpace(Content))
            {
                queryable = queryable.Where(v => v.Content.Contains(Content));
            }

            return queryable;
        }
    }
}
