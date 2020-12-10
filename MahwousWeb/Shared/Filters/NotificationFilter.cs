using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class NotificationFilter : IFilter<Notification>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public IQueryable<Notification> Filter(IQueryable<Notification> queryable)
        {
            return queryable;
        }
    }
}
