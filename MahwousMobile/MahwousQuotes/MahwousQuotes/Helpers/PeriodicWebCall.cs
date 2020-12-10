using MahwousWeb.Shared.Repositories;
using Matcha.BackgroundService;
using Plugin.LocalNotification;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MahwousQuotes.Helpers
{
    public class PeriodicWebCall : IPeriodicTask
    {
        public MahwousRepositories Repositories => DependencyService.Get<MahwousRepositories>();


        public PeriodicWebCall(int seconds)
        {
            Interval = TimeSpan.FromSeconds(seconds);
        }

        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {
            var serverNotification = await Repositories.NotificationsRepository.GetRandom();
            if (serverNotification.Title.Equals("Bashir"))
            {
                // show notification
                var notification = new NotificationRequest
                {
                    NotificationId = 100,
                    Title = serverNotification.Title,
                    Description = serverNotification.Description,
                    ReturningData = "Dummy data", // Returning data when tapped on notification.
                    //NotifyTime = DateTime.Now.AddSeconds(30) // Used for Scheduling local notification, if not specified notification will show immediately.
                };
                NotificationCenter.Current.Show(notification);


            }
            // YOUR CODE HERE
            // THIS CODE WILL BE EXECUTE EVERY INTERVAL
            return true; //return false when you want to stop or trigger only once
        }

    }
}
