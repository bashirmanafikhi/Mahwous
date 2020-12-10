using MahwousVideos.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousVideos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LikedVideosPage : ContentPage
    {
        public LikedVideosPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as LikedVideosViewModel).LoadVideosCommand.Execute(null);
        }
    }
}