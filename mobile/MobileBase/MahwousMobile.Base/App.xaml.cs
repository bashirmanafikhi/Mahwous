using Mahwous.Service.Chat;
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
                RegisterServices();
                CheckTheme();
                SetLocalNotificationsOptions();
            }
            catch (System.Exception ex)
            {
                DependencyService.Get<IMessage>().LongAlert("Parent: " + ex.ToString());
            }
        }


        private void CheckTheme()
        {
            // Set CurrentTheme
            SetTheme(Current.RequestedTheme);

            // On System Theme Changed
            Current.RequestedThemeChanged += (_, args) =>
                SetTheme(args.RequestedTheme);
        }
        private void SetTheme(OSAppTheme requestedTheme)
        {
            if (requestedTheme == OSAppTheme.Dark)
                Current.Resources = new DarkTheme();
            else if (requestedTheme == OSAppTheme.Light)
                Current.Resources = new WhiteTheme();
        }

        private void RegisterServices()
        {
            var url = Settings.Configuration.UrlBase;
            DependencyService.RegisterSingleton<IChatService>(new ChatService(url));
            DependencyService.RegisterSingleton(new MahwousRepositories(url));
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
