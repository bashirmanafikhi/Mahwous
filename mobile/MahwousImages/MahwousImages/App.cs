using MahwousMobile.Base.Helpers;

namespace MahwousImages
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
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/5328698123";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/2462861631";
            Settings.AppTitle = "صور";
        }
    }
}
