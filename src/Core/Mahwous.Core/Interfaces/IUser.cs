using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous.Core.Interfaces
{
    public interface IUser
    {
        IList<Category> Categories { get; set; }
        IList<Post> Posts { get; set; }
        IList<MobileApp> MobileApps { get; set; }
        IList<ImageStatus> ImageStatuses { get; set; }
        IList<VideoStatus> VideoStatuses { get; set; }
        IList<QuoteStatus> QuoteStatuses { get; set; }
        IList<ChatRoom> ChatRooms { get; set; }
    }
}
