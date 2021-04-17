using MahwousMobile.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous
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
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/8885310508";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/6318038676";
            Settings.AppTitle = "حالات";
        }
    }
}
