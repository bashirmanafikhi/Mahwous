using Mahwous.Core.Enums;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using MarcTron.Plugin;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace MahwousMobile.Base.Views
{
    [DesignTimeVisible(false)]
    public partial class VideosPage : ContentPage
    {
        private StatusSortType sortType = StatusSortType.Random;
        public StatusSortType SortType
        {
            get => sortType;
            set
            {
                sortType = value;

                if (viewModel != null)
                    viewModel.SortType = value;
            }
        }

        readonly VideosViewModel viewModel;

        public VideosPage(VideosViewModel viewModel)
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;


            BindingContext = this.viewModel = viewModel;

            viewModel.VideosFinished += OnVideosFinished;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.LoadRewardedVideo(Settings.InterstitialAdKey);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadVideosCommand.Execute(null);
        }

        public VideosPage() : this(new VideosViewModel()) { }
        private void MyBanner_AdsLoaded(object sender, EventArgs e)
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                myBanner.HeightRequest = 50;
            }
            else
            {
                myBanner.HeightRequest = 90;
            }
        }

        private void OnVideosFinished(object sender, EventArgs e)
        {
            DisplayAlert("تنبيه", "انتهت الحالات في هذا التصنيف", "حسناً");
        }
    }
}