using Mahwous.Core.Models;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    public class VideoFilter : StatusFilterBase<VideoStatus>
    {
        public string Name { get; set; }

        public override IQueryable<VideoStatus> Filter(IQueryable<VideoStatus> queryable)
        {
            queryable = base.Filter(queryable);
            //queryable = base.Filter(queryable).Cast<VideoStatus>();

            // videos title
            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable.Where(v => v.Title.Contains(Name));
            }

            return queryable;
        }
    }
}
