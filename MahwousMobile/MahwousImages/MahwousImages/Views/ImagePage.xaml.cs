using MahwousImages.ViewModels;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousImages.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {

        public ImagePage(ImageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            


            //CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-3940256099942544/1033173712"); //تجريب
            CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-1685177955120006/5328698123"); //حقيقي

        }

        protected override async void OnAppearing()
        {
            await ((ImageViewModel)BindingContext).Repositories.ImagesRepository.IncrementViews(((ImageViewModel)BindingContext).Image.Id);
        }

        protected override async void OnDisappearing()
        {
        }

        private void ShowInterstitialAd(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
        }
    }
}