using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class NotificationFilter : FilterBase<Notification>
    {
        public override IQueryable<Notification> Filter(IQueryable<Notification> queryable)
        {
            queryable = base.Filter(queryable);
            return queryable;
        }
    }
}
