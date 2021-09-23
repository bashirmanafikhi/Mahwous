namespace Mahwous.Core.Models
{
    public class NotificationApps
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }

        public int AppId { get; set; }
        public MobileApp App { get; set; }
    }
}
