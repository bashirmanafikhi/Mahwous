using MahwousMobile.Base;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : ShellBase
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void MenuItem_Rate_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://play.google.com/store/apps/details?id=com.mahwous.mahwouschat";
            await Browser.OpenAsync(Uri);
        }

        private async void MenuItem_ShareApp_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://play.google.com/store/apps/details?id=com.mahwous.mahwouschat",
                Title = "مشاركة تطبيق دردشة مهووس"
            });
        }

        
    }
}