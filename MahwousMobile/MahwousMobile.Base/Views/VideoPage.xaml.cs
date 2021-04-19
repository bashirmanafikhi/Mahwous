using MahwousMobile.Base.ViewModels;
using MarcTron.Plugin;
using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            


            CrossMediaManager.Current.Stop();
            CrossMediaManager.Current.StateChanged += MediaPlayer_StateChanged;

            Task.Run(async () =>
            {
                await CrossMediaManager.Current.Play(viewModel.Video.VideoPath);
            });


            //CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/1033173712"); //تجريب
            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-1685177955120006/6453640828"); //حقيقي

        }

        protected override async void OnAppearing()
        {
            try
            {
                await ((VideoViewModel)BindingContext).Repositories.VideosRepository.IncrementViews(((VideoViewModel)BindingContext).Video.Id);
            }
            catch
            { }
        }

        protected override async void OnDisappearing()
        {
            await CrossMediaManager.Current.Pause();
        }

        private void MediaPlayer_StateChanged(object sender, MediaManager.Playback.StateChangedEventArgs e)
        {
            if (e.State == MediaManager.Player.MediaPlayerState.Playing ||
                e.State == MediaManager.Player.MediaPlayerState.Paused)
            {
                loadingIndicator.IsVisible = false;
            }
            else
            {
                loadingIndicator.IsVisible = true;
            }
        }

        private void DownloadButton_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowRewardedVideo();
        }
    }
}