using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
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
