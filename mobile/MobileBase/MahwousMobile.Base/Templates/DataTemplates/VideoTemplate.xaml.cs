using MahwousMobile.Base.ViewModels;
using MahwousMobile.Base.Views;
using MarcTron.Plugin;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
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