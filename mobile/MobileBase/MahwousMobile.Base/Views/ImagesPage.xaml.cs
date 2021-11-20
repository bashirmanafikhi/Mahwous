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
    public partial class ImagesPage : ContentPage
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

        readonly ImagesViewModel viewModel;

        public ImagesPage(ImagesViewModel viewModel)
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;


            BindingContext = this.viewModel = viewModel;

            viewModel.ImagesFinished += OnImagesFinished;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.LoadInterstitial(Settings.InterstitialAdKey);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadImagesCommand.Execute(null);
        }

        public ImagesPage() : this(new ImagesViewModel()) { }

        private void MyBanner_AdsLoaded(object sender, EventArgs e)
        {
            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                myBanner.HeightRequest = 50;
            }
            else
            {
                myBanner.HeightRequest = 90;
            }
        }
        //private void CollectionView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        //{
        //    if (Device.RuntimePlatform != Device.UWP)
        //    {
        //        return;
        //    }

        //    if (sender is CollectionView cv)
        //    {
        //        var count = cv.ItemsSource.Cast<object>().Count();
        //        if (e.LastVisibleItemIndex + 1 - count + cv.RemainingItemsThreshold >= 0)
        //        {
        //            if (cv.RemainingItemsThresholdReachedCommand.CanExecute(null))
        //                cv.RemainingItemsThresholdReachedCommand.Execute(null);
        //        }
        //    }
        //}
        private void OnImagesFinished(object sender, EventArgs e)
        {
            DisplayAlert("تنبيه", "انتهت الحالات في هذا التصنيف", "حسناً");
        }
    }
}