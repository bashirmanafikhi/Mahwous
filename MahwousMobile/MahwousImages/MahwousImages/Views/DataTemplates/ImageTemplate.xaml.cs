using MahwousImages.ViewModels;
using MahwousWeb.Models.Models;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousImages.Views.DataTemplates
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
            //CrossMTAdmob.Current.ShowInterstitial();

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