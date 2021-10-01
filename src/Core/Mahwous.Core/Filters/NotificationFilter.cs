using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class NotificationFilter : EntityFilter<Notification>
    {
        public override IQueryable<Notification> FilterOtherEntityProperties(IQueryable<Notification> queryable)
        {
            return queryable;
        }
    }
}
