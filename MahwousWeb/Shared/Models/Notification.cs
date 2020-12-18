using System;
using System.Collections.Generic;

namespace MahwousWeb.Shared.Models
{
    public class Notification : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReturningData { get; set; }
        public int BadgeNumber { get; set; }
        public int RecivedCount { get; set; }
        public int OpenedCount { get; set; }

        public bool IsScheduled{ get; set; }
        public DateTime? NotifyTime { get; set; }


        public IList<NotificationApps> NotificationApps { get; set; }
    }
}
