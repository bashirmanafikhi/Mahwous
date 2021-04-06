using MahwousVideos.ViewModels;
using MahwousWeb.Models.Models;
using MarcTron.Plugin;
using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousVideos.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoTemplate : ContentView
    {
        public VideoTemplate()
        {
            InitializeComponent();
        }


        private async void Item_Tapped(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowRewardedVideo();

            var layout = (BindableObject)sender;
            var video = (VideoStatus)layout.BindingContext;


            VideoViewModel viewModel = new VideoViewModel(video);
            VideoPage page = new VideoPage(viewModel);


            var previousPage = Navigation.NavigationStack.LastOrDefault();
            await Navigation.PushAsync(page);
            if (previousPage != null && previousPage is VideoPage)
            {
                Navigation.RemovePage(previousPage);
            }

        }
    }
}