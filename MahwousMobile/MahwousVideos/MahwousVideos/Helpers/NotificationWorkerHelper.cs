using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Repositories;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousVideos.Helpers
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

                Notification notificationData = await repositories.NotificationsRepository.GetLastNotification(packageName);

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
                    NotifyTime = notificationData.IsScheduled ? notificationData.NotifyTime : null
                };

                NotificationCenter.Current.Show(notification);


                Preferences.Set("last_notification_id", notificationData.Id);

                await repositories.NotificationsRepository.IncrementRecived(notificationData.Id);


            }
            catch { }

        }
    }
}
