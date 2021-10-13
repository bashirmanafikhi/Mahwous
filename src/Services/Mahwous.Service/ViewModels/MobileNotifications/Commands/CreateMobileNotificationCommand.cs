using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mahwous.Service.ViewModels.MobileNotifications
{
    public class CreateMobileNotificationCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReturningData { get; set; }
        public int BadgeNumber { get; set; }
        public bool IsScheduled { get; set; }
        public DateTime? NotifyTime { get; set; }

        public List<MobileApp> Apps { get; set; }
        public Stream Cover { get; set; }
    }
}
