using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousMobile.Base.Views;
using MahwousMobile.Base.ViewModels;
using Mahwous.Core.Models;
using MahwousMobile.Base.Models;

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