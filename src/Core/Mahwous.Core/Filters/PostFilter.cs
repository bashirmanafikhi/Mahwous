using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class PostFilter : EntityFilter<Post>
    {
        public override IQueryable<Post> FilterOtherEntityProperties(IQueryable<Post> queryable)
        {
            return queryable;
        }
    }
}
