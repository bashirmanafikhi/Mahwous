using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Mahwous.Persistence.Models
{
    public class ApplicationUser : IdentityUser , IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Avatar { get; set; }

        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Post> Posts { get; set; }
        public virtual IList<MobileApp> MobileApps { get; set; }
        public virtual IList<Status> Statuses { get; set; }
        public virtual IList<ChatRoom> ChatRooms { get; set; }
        public virtual IList<ExternalLink> ExternalLinks { get; set; }
        public virtual IList<MobileNotification> MobileNotifications { get; set; }
        public virtual IList<Message> Messages { get; set; }
        public virtual IList<Report> Reports { get; set; }
        public virtual IList<Report> ViolationReports { get; set; }
    }
}
