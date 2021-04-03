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
    public partial class AppTemplate : ContentView
    {
        public AppTemplate()
        {
            InitializeComponent();
        }

        private async void Item_Tapped(object sender, EventArgs e)
        {
            var app = BindingContext as MahwousWeb.Shared.Models.App ;
            if(!string.IsNullOrEmpty(app.PlayStoreLink))
                await Browser.OpenAsync(app.PlayStoreLink);
        }
    }
}