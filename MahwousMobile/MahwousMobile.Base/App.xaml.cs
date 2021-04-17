using MahwousMobile.Base.Styles.Themes;
using MahwousWeb.Service.Repositories;
using Plugin.LocalNotification;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousMobile.Base
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterServices();
            CheckTheme();
            SetLocalNotificationsOptions();
        }


        private void CheckTheme()
        {
            if (Preferences.Get("dark_mode", true))
            {
                Current.Resources = new DarkTheme();
            }
        }

        private void RegisterServices()
        {
            DependencyService.Register<MahwousRepositories>();
        }

        private void SetLocalNotificationsOptions()
        {
            // Local Notification tap event listener
            NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            // Local Notification received event listener
            NotificationCenter.Current.NotificationReceived += OnLocalNotificationReceived;

        }

        private void OnLocalNotificationTapped(NotificationTappedEventArgs e)
        {
            // your code goes here
            //DependencyService.Get<IMessage>().LongAlert("Tapped - " + e.Data);
        }

        private void OnLocalNotificationReceived(NotificationReceivedEventArgs e)
        {
            // your code goes here
            //DependencyService.Get<IMessage>().LongAlert("Received - " + e.Title);
        }
    }
}
