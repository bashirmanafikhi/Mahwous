using MahwousMobile.Base.Models;
using MahwousMobile.Base.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousMobile.Base.Views
{
    [DesignTimeVisible(false)]
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;

        public CategoriesPage()
        {
            InitializeComponent();
        }

        public StatusType? StatusType
        {
            set
            {
                viewModel = new CategoriesViewModel(value);
                viewModel.GetInformationsCommand.Execute(null);
                viewModel.LoadCategoriesCommand.Execute(null);
                BindingContext = viewModel;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel?.Categories?.Count == 0)
            {
                viewModel.IsBusy = true;
            }
        }
    }
}