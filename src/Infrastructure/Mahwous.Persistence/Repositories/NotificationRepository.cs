using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class NotificationRepository : EntityRepository<MobileNotification, MobileNotificationFilter>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        { }

    }
}
