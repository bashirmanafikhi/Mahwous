﻿using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousImages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


        }

        private void MenuItem_Exit_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void MenuItem_Rate_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://play.google.com/store/apps/details?id=com.mahwous.MahwousImages";
            await Browser.OpenAsync(Uri);
        }

        private async void MenuItem_ShareApp_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://play.google.com/store/apps/details?id=com.mahwous.mahwousimages",
                Title = "مشاركة تطبيق مهووس"
            });
        }


        private async void MenuItem_LikedImages_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;

            await Navigation.PushAsync(new LikedImagesPage());
        }


        private bool maybe_exit = false;
        //-------------------------------------------------------------------
        protected override bool OnBackButtonPressed()
        //-------------------------------------------------------------------
        {
            if (Navigation.NavigationStack.Count > 1 || Navigation.ModalStack.Count > 1)
            {
                return base.OnBackButtonPressed();
            }
            //some more custom checks here
            //..

            if (maybe_exit)
            {
                return false; //QUIT
            }

            DependencyService.Get<IMessage>().ShortAlert("إضغط مرة أخرة للخروج من البرنامج!");
            maybe_exit = true;

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                maybe_exit = false; //reset those 2 seconds

                return false;// false - Don't repeat the timer 
            });
            return true; //true - don't process BACK by system
        }
    }
}