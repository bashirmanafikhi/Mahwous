using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class NotificationRepository : EntityRepository<MobileNotification, MobileNotificationFilter>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
