using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class PostFilter : EntityFilter<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public override IQueryable<Post> FilterOtherEntityProperties(IQueryable<Post> queryable)
        {
            if (!string.IsNullOrEmpty(Title))
                queryable = queryable.Where(x => x.Title.Contains(Title));

            if (!string.IsNullOrEmpty(Content))
                queryable = queryable.Where(x => x.Content.Contains(Content));

            return queryable;
        }
    }
}
