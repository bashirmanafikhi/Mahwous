using MahwousMobile.Base.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
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