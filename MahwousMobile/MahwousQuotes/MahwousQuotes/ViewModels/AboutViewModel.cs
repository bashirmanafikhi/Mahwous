using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "عن التطبيق";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.mahwous.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}