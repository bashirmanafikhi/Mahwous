using MahwousQuotes.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LikedQuotesPage : ContentPage
    {
        public LikedQuotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as LikedQuotesViewModel).LoadQuotesCommand.Execute(null);
        }
    }
}