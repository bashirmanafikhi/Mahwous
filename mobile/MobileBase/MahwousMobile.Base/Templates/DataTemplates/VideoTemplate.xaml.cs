using Mahwous.Core.Entities;
using MahwousMobile.Base.ViewModels;
using MahwousMobile.Base.Views;
using MarcTron.Plugin;
using System;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
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
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowRewardedVideo();

            var layout = (BindableObject)sender;
            VideoViewModel viewModel = (VideoViewModel)layout.BindingContext;

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