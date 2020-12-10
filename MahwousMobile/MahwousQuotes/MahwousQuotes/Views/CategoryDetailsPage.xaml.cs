using MahwousQuotes.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailsPage : ContentPage
    {
        private readonly CategoryViewModel viewModel;

        public CategoryDetailsPage(CategoryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (myQuotesTemplate.QuotesCount == 0)
            {
                myQuotesTemplate.SetCategories(viewModel.Category);
            }
        }
    }
}