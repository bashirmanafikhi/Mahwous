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
            var token = Settings.Token;
            var url = Settings.Configuration.UrlBase;
            var repositories = new MahwousRepositories(url);
            if (token != null)
                repositories.Token = token;
            DependencyService.RegisterSingleton(repositories);
            DependencyService.RegisterSingleton<IChatService>(new ChatService(url, token));
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
