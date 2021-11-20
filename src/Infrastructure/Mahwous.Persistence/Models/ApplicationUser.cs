using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
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
        public virtual IList<ImageStatus> ImageStatuses { get; set; }
        public virtual IList<VideoStatus> VideoStatuses { get; set; }
        public virtual IList<QuoteStatus> QuoteStatuses { get; set; }
        public virtual IList<ChatRoom> ChatRooms { get; set; }
    }
}
