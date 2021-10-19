﻿using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using MarcTron.Plugin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {

        public ImagePage(ImageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;




            CrossMTAdmob.Current.LoadInterstitial(Settings.InterstitialAdKey);

        }

        protected override async void OnAppearing()
        {
            try
            {
                //await ((ImageViewModel)BindingContext).Repositories.ImageStatusRepository.IncrementViews(((ImageViewModel)BindingContext).Image.Id);
            }
            catch
            { }
        }

        private void ShowInterstitialAd(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
        }
    }
}