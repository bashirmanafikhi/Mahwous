using MahwousMobile.Base.Models;
using MahwousMobile.Base.Styles.Themes;
using MahwousMobile.Base.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public bool IsShortcutsVisible
        {
            set
            {
                shortcutsFrame.IsVisible = value;
            }
        }

        public StatusType? StatusType
        {
            set
            {
                BindingContext = new HomeViewModel(value);
            }
        }

        private async void GoToVideosPage(object sender, System.EventArgs e)
        {
            var route = $"//Videos/{nameof(VideosPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void GoToImagesPage(object sender, System.EventArgs e)
        {
            var route = $"//Images/{nameof(ImagesPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void GoToQuotesPage(object sender, System.EventArgs e)
        {
            var route = $"//Quotes/{nameof(QuotesPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void GoToChatRoomsPage(object sender, System.EventArgs e)
        {
            var route = $"//ChatRooms/{nameof(ChatRoomsPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void GoToPostsPage(object sender, System.EventArgs e)
        {
            var route = $"//Other/{nameof(PostsPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void GoToMobileAppsPage(object sender, System.EventArgs e)
        {
            var route = $"//Other/{nameof(AppsPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async void GoToAboutPage(object sender, System.EventArgs e)
        {
            var route = $"//Other/{nameof(AboutPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}