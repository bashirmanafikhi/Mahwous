using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class PostFilter : IFilter<Post>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public IQueryable<Post> Filter(IQueryable<Post> queryable)
        {
            return queryable;
        }
    }
}
