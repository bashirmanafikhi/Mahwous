using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class VideoFilter : StatusFilter<VideoStatus>
    {
        public string Name { get; set; }

        public override IQueryable<VideoStatus> FilterOtherStatusProperties(IQueryable<VideoStatus> queryable)
        {
            // videos title
            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable.Where(v => v.Title.Contains(Name));
            }

            return queryable;
        }
    }
}
