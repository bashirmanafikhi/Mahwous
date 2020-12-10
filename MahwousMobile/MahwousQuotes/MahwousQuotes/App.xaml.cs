using MahwousQuotes.Styles.Themes;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Repositories;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousQuotes
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterServices();
            SetProperties();
            CheckTheme();

            // Local Notification tap event listener
            //NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            MainPage = new AppShell();
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


        private void RegisterServices()
        {
            DependencyService.Register<MahwousRepositories>();
        }

        private void SetProperties()
        {
            //Properties["informations"] = await DependencyService.Get<Repositories>().QuoteRepository.GetInformations();
        }

        private void CheckTheme()
        {
            if (Preferences.ContainsKey("dark_mode"))
            {
                Current.Resources = new DarkTheme();
            }
        }
    }
}
