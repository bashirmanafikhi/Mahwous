using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MahwousVideos.Models;
using MahwousVideos.Views;
using MahwousVideos.ViewModels;
using MahwousWeb.Shared.Models;

namespace MahwousVideos.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categories.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}