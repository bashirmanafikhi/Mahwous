using System;
using Xamarin.Forms;
using MahwousQuotes.Views;
using MahwousWeb.Shared.Repositories;
using MahwousWeb.Shared.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Matcha.BackgroundService;
using Plugin.LocalNotification;
using MahwousQuotes.Models;
using MahwousQuotes.Helpers;

namespace MahwousQuotes
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            RegisterServices();


            // Local Notification tap event listener
            NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            //MainPage = new NavigationPage(new SplashPage());
            MainPage = new SplashPage();
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
            DependencyService.Get<Repositories>().CategoryRepository = new CategoryRepository(http);
            DependencyService.Get<Repositories>().QuoteRepository = new QuoteRepository(http);
            DependencyService.Get<Repositories>().NotificationRepository = new NotificationRepository(http);
            DependencyService.Get<Repositories>().AppRepository = new AppRepository(http);
            DependencyService.Get<Repositories>().PostRepository = new PostRepository(http);
        }

        private void OnLocalNotificationTapped(NotificationTappedEventArgs e)
        {
            // your code goes here
            MainPage = new AboutPage();
        }
    }
}
