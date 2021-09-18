using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Mahwous
{
    public class App : MahwousMobile.Base.App
    {
        public App()
        {
            SetConfigurations();
            ShowPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("android=933bf022-696a-44fa-97d1-cc448ce626fd;",
                  typeof(Analytics), typeof(Crashes));
        }

        private void ShowPage()
        {
            Settings.MainShellWindow = new AppShell();
            if (Settings.Token == null)
            {
                MainPage = new NavigationPage(new WelcomeScreenPage());
                return;
            }
            MainPage = Settings.MainShellWindow;
        }

        private void SetConfigurations()
        {
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/8885310508";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/6318038676";
            Settings.RewardedAdKey = "ca-app-pub-1685177955120006/1783050149";
            Settings.AppTitle = "حالات";
        }
    }
}
