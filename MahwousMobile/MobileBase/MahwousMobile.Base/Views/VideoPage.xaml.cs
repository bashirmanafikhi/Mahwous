using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using MarcTron.Plugin;
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

            CrossMTAdmob.Current.LoadRewardedVideo(Settings.RewardedAdKey); 
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

        private void DownloadButton_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowRewardedVideo();
        }
    }
}