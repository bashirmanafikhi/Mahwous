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
    public partial class ContactUsTemplate : ContentView
    {
        public ContactUsTemplate()
        {
            InitializeComponent();
        }

        private async void BtnWhats_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://api.whatsapp.com/send?phone=905370466004";
            await Browser.OpenAsync(Uri);
        }

        private async void BtnFace_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://www.facebook.com/mahwousss";
            await Browser.OpenAsync(Uri);
        }

        private async void BtnInsta_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://www.instagram.com/mahwous2020/";
            await Browser.OpenAsync(Uri);
        }

        private async void BtnYoutube_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://www.youtube.com/channel/UCkB4CvaTDA9lWABBmcdi98g";
            await Browser.OpenAsync(Uri);
        }

        private async void BtnTelegram_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://t.me/mahwous2020";
            await Browser.OpenAsync(Uri);
        }

        private async void BtnWebsite_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://www.mahwous.com/";
            await Browser.OpenAsync(Uri);
        }
    }
}