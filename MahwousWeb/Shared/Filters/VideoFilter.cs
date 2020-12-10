using MahwousWeb.Shared.Models;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class VideoFilter : StatusFilter, IFilter<VideoStatus>
    {
        public string Name { get; set; }

        public IQueryable<VideoStatus> Filter(IQueryable<VideoStatus> queryable)
        {
            queryable = base.Filter(queryable).Cast<VideoStatus>();

            // videos title
            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable.Where(v => v.Title.Contains(Name));
            }

            return queryable;
        }
    }
}
