using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MahwousVideos.Models;
using MahwousVideos.ViewModels;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Filters;

namespace MahwousVideos.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class VideosPage : ContentPage
    {
        public SortType SortType
        {
            get => viewModel.Filter.SortType;
            set
            {
                viewModel.Filter.SortType = value;
                viewModel.LoadVideosCommand.Execute(null);
            }
        }


        readonly VideosViewModel viewModel;

        public VideosPage(VideosViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            viewModel.VideosFinished += OnVideosFinished;

        }

        public VideosPage() : this(new VideosViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Videos.Count == 0)
                viewModel.IsBusy = true;
        }

        private void OnVideosFinished(object sender, EventArgs e)
        {
            DisplayAlert("تنبيه", "انتهت الحالات في هذا التصنيف", "حسناً");
        }
    }
}