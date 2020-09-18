using MahwousVideos.ViewModels;
using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousVideos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        public VideoPage(VideoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.Repositories.VideoRepository.IncrementViews(viewModel.Video.Id);

            CrossMediaManager.Current.Init();
            
            Task.Run(async () =>
            {
                await CrossMediaManager.Current.Play(viewModel.Video.VideoPath);
            });

        }
    }
}