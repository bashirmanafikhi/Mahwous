using System;
using System.ComponentModel;
using Xamarin.Forms;
using MahwousQuotes.ViewModels;

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

            //BindingContext = this.viewModel = new PostsViewModel();
            this.viewModel = (BindingContext as PostsViewModel);

        }

        protected override void OnAppearing()
        {

            System.Diagnostics.Debug.WriteLine("Bashir OnAppearing Posts");
            //base.OnAppearing();

            if (viewModel.Posts.Count == 0)
            {
                viewModel.LoadPostsCommand.Execute(null);
            }
        }
    }
}