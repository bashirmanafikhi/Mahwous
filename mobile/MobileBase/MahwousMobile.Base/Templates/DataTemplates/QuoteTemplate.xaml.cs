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
    public partial class QuoteTemplate : ContentView
    {
        public QuoteTemplate()
        {
            InitializeComponent();
        }


        private async void Item_Tapped(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowInterstitial();

            var layout = (BindableObject)sender;
            QuoteViewModel viewModel = (QuoteViewModel)layout.BindingContext;

            QuotePage page = new QuotePage(viewModel);

            var previousPage = Navigation.NavigationStack.LastOrDefault();
            await Navigation.PushAsync(page);
            if (previousPage != null && previousPage is QuotePage)
            {
                Navigation.RemovePage(previousPage);
            }

        }
    }
}