using System;
using Xamarin.Forms;
using MahwousVideos.Views;
using MahwousWeb.Shared.Repositories;
using MahwousWeb.Shared.Services;
using System.Net.Http;
using System.Threading.Tasks;
using MahwousVideos.Models;
using MahwousVideos.Helpers;
using MahwousVideos.Styles.Themes;
using MediaManager;

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

            MainPage = new AppShell();
        }

        private void SetMediaManagerOptions()
        {
            //CrossMediaManager.Current.ClearQueueOnPlay = true;

            CrossMediaManager.Current.MediaPlayer.VideoAspect = MediaManager.Video.VideoAspectMode.AspectFit;
            CrossMediaManager.Current.MediaPlayer.VideoPlaceholder = (new ActivityIndicator()).IsVisible = true;
            CrossMediaManager.Current.Notification.ShowNavigationControls = true;
            CrossMediaManager.Current.Notification.ShowPlayPauseControls = true;
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
            if (Current.Properties.ContainsKey("dark_mode"))
            {
                Current.Resources = new DarkTheme();
            }
        }


        private IHttpService GetHttpService()
        {
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(@"https://www.mahwous.com/")
            };
            IHttpService httpService = new HttpService(httpClient);

            return httpService;
        }

        private void RegisterServices()
        {
            DependencyService.Register<Repositories>();

            var http = GetHttpService();
            var repositories = DependencyService.Get<Repositories>();

            repositories.CategoryRepository = new CategoryRepository(http);
            repositories.VideoRepository = new VideoRepository(http);
            repositories.NotificationRepository = new NotificationRepository(http);
            repositories.AppRepository = new AppRepository(http);
            repositories.PostRepository = new PostRepository(http);
        }
    }
}
