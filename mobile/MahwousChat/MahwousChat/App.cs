using MahwousMobile.Base.Helpers;

namespace MahwousChat
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
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/3487950804";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/2366440824";
            Settings.AppTitle = "دردشة مهووس";
        }
    }
}
