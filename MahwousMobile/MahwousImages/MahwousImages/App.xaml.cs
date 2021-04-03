using System;
using Xamarin.Forms;
using MahwousImages.Views;
using System.Net.Http;
using System.Threading.Tasks;
using MahwousImages.Helpers;
using MahwousImages.Styles.Themes;
using Xamarin.Essentials;
using System.Diagnostics;
using Plugin.LocalNotification;
using MahwousWeb.Shared.Repositories;

namespace MahwousImages
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterServices();
            CheckTheme();
            SetLocalNotificationsOptions();


            MainPage = new AppShell();
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
        protected override void OnStart()
        {
            //Register Periodic Tasks
            //BackgroundAggregatorService.Add(() => new PeriodicWebCall(60));

            //Start the background service
            //BackgroundAggregatorService.StartBackgroundService();
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }

        private void CheckTheme()
        {
            if (Preferences.ContainsKey("dark_mode"))
            {
                Current.Resources = new DarkTheme();
            }
        }

        private void RegisterServices()
        {
            DependencyService.Register<MahwousRepositories>();
        }
    }
}
