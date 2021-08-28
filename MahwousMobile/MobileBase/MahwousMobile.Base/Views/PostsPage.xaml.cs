using MahwousMobile.Base.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousMobile.Base.Views
{
    [DesignTimeVisible(false)]
    public partial class PostsPage : ContentPage
    {
        PostsViewModel viewModel;

        public PostsPage()
        {
            InitializeComponent();

            this.viewModel = (BindingContext as PostsViewModel);
        }

        protected override void OnAppearing()
        {
            if (viewModel.Posts.Count == 0)
            {
                //viewModel.LoadPostsCommand.Execute(null);
                viewModel.IsBusy = true;
            }
        }
    }
}