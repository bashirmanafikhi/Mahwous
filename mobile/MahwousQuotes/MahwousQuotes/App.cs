using MahwousMobile.Base.Helpers;
using MahwousWeb.Service.Repositories;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

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
            // Todo: replace adds keys
            //Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/6453640828";
            //Settings.BannerAdKey = "ca-app-pub-1685177955120006/3389381831";
            Settings.AppTitle = "حالات كتابية";
        }
    }
}
