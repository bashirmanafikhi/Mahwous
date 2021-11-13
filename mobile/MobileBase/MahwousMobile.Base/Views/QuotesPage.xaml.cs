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
    public partial class QuotesPage : ContentPage
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

        private readonly QuotesViewModel viewModel;

        public QuotesPage(QuotesViewModel viewModel)
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;

            BindingContext = this.viewModel = viewModel;
            //viewModel.LoadQuotesCommand.Execute(null);

            viewModel.QuotesFinished += OnQuotesFinished;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.LoadInterstitial(Settings.InterstitialAdKey);

        }

        public QuotesPage() : this(new QuotesViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadQuotesCommand.Execute(null);
        }
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

        private void OnQuotesFinished(object sender, EventArgs e)
        {
            DisplayAlert("تنبيه", "انتهت الحالات في هذا التصنيف", "حسناً");
        }
    }
}