using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousImages.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "عن التطبيق";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.mahwous.com"));
            OpenGooglePlayCommand = new Command(async () => await Browser.OpenAsync("https://play.google.com/store/apps/dev?id=6211596474485889451"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenGooglePlayCommand { get; }
    }
}