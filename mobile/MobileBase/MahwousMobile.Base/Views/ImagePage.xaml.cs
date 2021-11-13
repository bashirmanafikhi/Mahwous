using MahwousMobile.Base.Helpers;
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
            viewModel.ImagesViewModel.LoadImagesCommand.Execute(null);

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.LoadInterstitial(Settings.InterstitialAdKey);

        }

        private void ShowInterstitialAd(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowInterstitial();
        }
    }
}