using Mahwous.Core.Entities;
using Mahwous.Service.Repositories;
using Plugin.LocalNotification;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MahwousMobile.Base.Helpers
{
    public class NotificationWorkerHelper
    {

        public async Task CheckNotification()
        {
            try
            {

                var current = Connectivity.NetworkAccess;

                if (current != NetworkAccess.Internet)
                {
                    // Connection to internet is not available
                    return;
                }


                // get notification data from server
                var packageName = AppInfo.PackageName;

                MahwousRepositories repositories = new MahwousRepositories();

                MobileNotification notificationData = new MobileNotification();
                //MobileNotification notificationData = await repositories.MobileNotificationsRepository.GetLastNotification(packageName);

                if (notificationData == null)
                {
                    return;
                }


                // when notification is old then return.
                if (Preferences.ContainsKey("last_notification_id"))
                {
                    int last_notification_id = Preferences.Get("last_notification_id", 0);

                    if (notificationData.Id == last_notification_id)
                    {
                        return;
                    }
                }

                // push the notification
                var notification = new NotificationRequest
                {
                    Title = notificationData.Title,
                    Description = notificationData.Description,
                    NotificationId = notificationData.Id,
                    ReturningData = notificationData.ReturningData,
                    BadgeNumber = notificationData.BadgeNumber,
                    Schedule = new NotificationRequestSchedule
                    {
                        NotifyTime = notificationData.IsScheduled ? notificationData.NotifyTime : null
                    }
                };

                await NotificationCenter.Current.Show(notification);


                Preferences.Set("last_notification_id", notificationData.Id);

                //await repositories.MobileNotificationsRepository.IncrementRecived(notificationData.Id);


            }
            catch { }

        }
    }
}
