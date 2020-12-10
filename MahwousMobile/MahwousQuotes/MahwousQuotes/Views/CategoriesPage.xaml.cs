using MahwousQuotes.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousQuotes.Views
{
    [DesignTimeVisible(false)]
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            viewModel = (BindingContext as CategoriesViewModel);


            viewModel.GetInformationsCommand.Execute(null);
            viewModel.LoadCategoriesCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categories.Count == 0)
            {
                viewModel.IsBusy = true;
            }
        }
    }
}