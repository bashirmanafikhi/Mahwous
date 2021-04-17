using MahwousMobile.Base.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LikedImagesPage : ContentPage
    {
        public LikedImagesPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as LikedImagesViewModel).LoadImagesCommand.Execute(null);
        }
    }
}