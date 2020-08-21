using System;
using System.ComponentModel;
using Xamarin.Forms;
using MahwousPosts.ViewModels;

namespace MahwousQuotes.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PostsPage : ContentPage
    {
        PostsViewModel viewModel;

        public PostsPage()
        {
            InitializeComponent();

            BindingContext = this.viewModel = new PostsViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Posts.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}