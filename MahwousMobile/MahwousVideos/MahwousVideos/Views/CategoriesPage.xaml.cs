using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousVideos.Views;
using MahwousVideos.ViewModels;
using MahwousWeb.Models.Models;

namespace MahwousVideos.Views
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