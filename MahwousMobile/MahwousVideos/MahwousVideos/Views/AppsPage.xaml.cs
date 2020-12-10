using MahwousVideos.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousVideos.Views
{ 
    [DesignTimeVisible(false)]
    public partial class AppsPage : ContentPage
    {
        AppsViewModel viewModel;

        public AppsPage()
        {
            InitializeComponent();

            this.viewModel = (BindingContext as AppsViewModel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Apps.Count == 0)
            {
                //viewModel.LoadAppsCommand.Execute(null);
                viewModel.IsBusy = true;
            }
        }
    }
}