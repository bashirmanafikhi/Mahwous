using Mahwous.Core.Models;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    public class PostFilter : FilterBase<Post>
    {
        public override IQueryable<Post> Filter(IQueryable<Post> queryable)
        {
            queryable = base.Filter(queryable);
            return queryable;
        }
    }
}
