using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppTemplate : ContentView
    {
        public AppTemplate()
        {
            InitializeComponent();
        }

        private async void Item_Tapped(object sender, EventArgs e)
        {
            var app = BindingContext as Mahwous.Core.Entities.MobileApp;
            if (!string.IsNullOrEmpty(app.PlayStoreLink))
                await Browser.OpenAsync(app.PlayStoreLink);
        }
    }
}