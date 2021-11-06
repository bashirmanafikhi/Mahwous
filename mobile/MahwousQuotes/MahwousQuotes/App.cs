using MahwousMobile.Base.Helpers;

namespace MahwousQuotes
{
    public class App : MahwousMobile.Base.App
    {
        public App()
        {
            SetConfigurations();
            MainPage = new AppShell();
        }

        private void SetConfigurations()
        {
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/8482065686";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/7988077793";
            Settings.AppTitle = "حالات كتابية";
        }
    }
}
