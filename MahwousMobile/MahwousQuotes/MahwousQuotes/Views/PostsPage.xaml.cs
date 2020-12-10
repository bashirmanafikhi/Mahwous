using MahwousQuotes.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousQuotes.Views
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
                viewModel.LoadPostsCommand.Execute(null);
            }
        }
    }
}