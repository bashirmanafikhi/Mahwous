using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Views;
using MahwousWeb.Models.Models;
using MahwousWeb.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Mahwous
{
    public class App : MahwousMobile.Base.App
    {
        public App()
        {
            SetConfigurations();
            MainPage = new WelcomeScreenPage();
            //MainPage = new AppShell();


        }

        private async void register()
        {
            MahwousRepositories repos = new MahwousRepositories();
            var res = await repos.AccountsRepository.Register(new MahwousWeb.Models.Models.RegisterUserInfo
            {
                Email = "",
                Password = "",
                ConfirmPassword = ""
            });
        }

        private async void login()
        {
            MahwousRepositories repos = new MahwousRepositories();
            var res = await repos.AccountsRepository.Login(new MahwousWeb.Models.Models.UserInfo
            {
                Email = "",
                Password = ""
            });
        }

        private void SetConfigurations()
        {
            Settings.InterstitialAdKey = "ca-app-pub-1685177955120006/8885310508";
            Settings.BannerAdKey = "ca-app-pub-1685177955120006/6318038676";
            Settings.AppTitle = "حالات";
        }
    }
}
