using Mahwous.Core.Entities;
using MahwousMobile.Base.ViewModels;
using MahwousMobile.Base.Views;
using MarcTron.Plugin;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExternalLinkTemplate : ContentView
    {
        public ExternalLinkTemplate()
        {
            InitializeComponent();
        }

        private async void Item_Tapped(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowInterstitial();

            var layout = (BindableObject)sender;
            var externalLink = (ExternalLink)layout.BindingContext;

            try
            {
                await Browser.OpenAsync(externalLink.Url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}