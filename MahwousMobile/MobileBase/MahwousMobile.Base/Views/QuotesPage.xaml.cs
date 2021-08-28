using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousMobile.Base.ViewModels;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Filters;
using System.Linq;
using MarcTron.Plugin;
using MahwousMobile.Base.Helpers;

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
            }
        }

        readonly QuotesViewModel viewModel;

        public QuotesPage(QuotesViewModel viewModel)
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;


            BindingContext = this.viewModel = viewModel;

            viewModel.QuotesFinished += OnQuotesFinished;

            CrossMTAdmob.Current.LoadInterstitial(Settings.InterstitialAdKey);

        }

        public QuotesPage() : this(new QuotesViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (myQuotesTemplate.QuotesCount == 0 && viewModel.Filter.Categories.Count > 0)
            {
                myQuotesTemplate.SetCategories(viewModel.Filter.Categories.ToArray());
            }

            myQuotesTemplate.SortType = this.SortType;
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