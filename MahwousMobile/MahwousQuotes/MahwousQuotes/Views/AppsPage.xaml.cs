using System;
using System.ComponentModel;
using Xamarin.Forms;
using MahwousQuotes.ViewModels;

namespace MahwousQuotes.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AppsPage : ContentPage
    {
        AppsViewModel viewModel;

        public AppsPage()
        {
            InitializeComponent();

            //BindingContext = this.viewModel = new AppsViewModel();
            this.viewModel = (BindingContext as AppsViewModel);
        }

        protected override void OnAppearing()
        {
            System.Diagnostics.Debug.WriteLine("Bashir OnAppearing Apps");
            //base.OnAppearing();

            if (viewModel.Apps.Count == 0)
            {
                viewModel.LoadAppsCommand.Execute(null);
            }
        }
    }
}