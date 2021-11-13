using Mahwous.Core.Filters;
using System;
using System.Collections.Generic;

namespace Mahwous.Core.Entities
{
    public class MobileNotification : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReturningData { get; set; }
        public int BadgeNumber { get; set; }
        public int RecivedCount { get; set; }
        public int OpenedCount { get; set; }
        public bool IsScheduled { get; set; }
        public DateTime? NotifyTime { get; set; }

        // Virtuals
        public virtual IList<MobileApp> Apps { get; set; }

        // Get Properties
        public new Type FilterType => typeof(MobileNotificationFilter);
    }
}
