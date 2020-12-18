using System;
using Xamarin.Forms;
using MahwousVideos.Views;
using System.Net.Http;
using System.Threading.Tasks;
using MahwousVideos.Helpers;
using MahwousVideos.Styles.Themes;
using MediaManager;
using MahwousWeb.Shared.Repositories;
using Xamarin.Essentials;
using System.Diagnostics;
using Plugin.LocalNotification;

namespace MahwousVideos
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterServices();
            CheckTheme();
            SetMediaManagerOptions();
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



        private void SetMediaManagerOptions()
        {
            CrossMediaManager.Current.ClearQueueOnPlay = true;
            CrossMediaManager.Current.MediaPlayer.VideoAspect = MediaManager.Video.VideoAspectMode.AspectFit;
            CrossMediaManager.Current.MediaPlayer.VideoPlaceholder = (new ActivityIndicator() { IsVisible = true , IsRunning = true});
            CrossMediaManager.Current.Notification.ShowNavigationControls = false;
            CrossMediaManager.Current.Notification.ShowPlayPauseControls = false;
            CrossMediaManager.Current.Notification.Enabled = false;
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
