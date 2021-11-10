using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using MarcTron.Plugin;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {

        public VideoPage(VideoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.VideosViewModel.LoadVideosCommand.Execute(null);

            mediaElement.MediaOpened += MediaPlayed;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.LoadRewardedVideo(Settings.RewardedAdKey);
        }

        private void MediaPlayed(object sender, EventArgs e)
        {
            loadingIndicator.IsVisible = false;
        }

        private void DownloadButton_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowRewardedVideo();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            mediaElement.Stop();
        }
    }
}