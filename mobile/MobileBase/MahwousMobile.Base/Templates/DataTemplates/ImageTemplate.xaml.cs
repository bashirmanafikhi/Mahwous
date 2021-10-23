using Mahwous.Core.Entities;
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
    public partial class ImageTemplate : ContentView
    {
        public ImageTemplate()
        {
            InitializeComponent();
        }


        private async void Item_Tapped(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowInterstitial();

            var layout = (BindableObject)sender;
            var image = (ImageStatus)layout.BindingContext;

            ImageViewModel viewModel = new ImageViewModel(image);
            ImagePage page = new ImagePage(viewModel);

            var previousPage = Navigation.NavigationStack.LastOrDefault();
            await Navigation.PushAsync(page);
            if (previousPage != null && previousPage is ImagePage)
            {
                Navigation.RemovePage(previousPage);
            }

        }
    }
}