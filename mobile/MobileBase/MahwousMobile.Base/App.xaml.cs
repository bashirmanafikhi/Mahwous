using Mahwous.Service.Repositories;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Styles.Themes;
using Plugin.LocalNotification;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousMobile.Base
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                //Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental" });
                RegisterServices();
                CheckTheme();
                SetLocalNotificationsOptions();
            }
            catch (System.Exception ex)
            {
                DependencyService.Get<IMessage>().LongAlert("Parent: " + ex.Message);
            }
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
            var token = Settings.Token;
            if (token != null)
            {
                var repos = DependencyService.Get<MahwousRepositories>();
                repos.Token = token;
            }
        }

        private void SetLocalNotificationsOptions()
        {

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                // Local Notification tap event listener
                NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

                // Local Notification received event listener
                NotificationCenter.Current.NotificationReceived += OnLocalNotificationReceived;
            }

        }

        private void OnLocalNotificationTapped(NotificationEventArgs e)
        {
            // your code goes here
            //DependencyService.Get<IMessage>().LongAlert("Tapped - " + e.Data);
        }

        private void OnLocalNotificationReceived(NotificationEventArgs e)
        {
            // your code goes here
            //DependencyService.Get<IMessage>().LongAlert("Received - " + e.Title);
        }
    }
}
