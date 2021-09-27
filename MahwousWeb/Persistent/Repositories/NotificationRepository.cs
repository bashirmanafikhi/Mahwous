using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Models;

namespace MahwousWeb.Persistent.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
