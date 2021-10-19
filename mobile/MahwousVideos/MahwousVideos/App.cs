using MahwousMobile.Base.Helpers;

namespace MahwousVideos
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
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/6453640828";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/3389381831";
            Settings.AppTitle = "فيديو";
        }
    }
}
