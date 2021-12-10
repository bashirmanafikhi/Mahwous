using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous.Core.Interfaces.Identity
{
    public interface IUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }


        IList<Category> Categories { get; set; }
        IList<Post> Posts { get; set; }
        IList<MobileApp> MobileApps { get; set; }
        IList<Status> Statuses { get; set; }
        IList<ChatRoom> ChatRooms { get; set; }
        IList<ExternalLink> ExternalLinks { get; set; }
        IList<MobileNotification> MobileNotifications { get; set; }
    }
}
