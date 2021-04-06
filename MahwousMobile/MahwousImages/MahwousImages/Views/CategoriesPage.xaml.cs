using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousImages.Views;
using MahwousImages.ViewModels;
using MahwousWeb.Models.Models;

namespace MahwousImages.Views
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