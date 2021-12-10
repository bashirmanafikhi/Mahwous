using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class GetMobileNotificationDetailsResponse : IMapFrom<MobileNotification>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReturningData { get; set; }
        public int BadgeNumber { get; set; }
        public int RecivedCount { get; set; }
        public int OpenedCount { get; set; }
        public bool IsScheduled { get; set; }
        public DateTime? NotifyTime { get; set; }
        public List<MobileApp> Apps { get; set; }
    }
}
