using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class MobileNotificationFilter : EntityFilter<MobileNotification>
    {
        public override IQueryable<MobileNotification> FilterOtherEntityProperties(IQueryable<MobileNotification> queryable)
        {
            return queryable;
        }
    }
}
