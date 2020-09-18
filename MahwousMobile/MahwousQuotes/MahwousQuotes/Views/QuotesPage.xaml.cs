using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MahwousQuotes.Models;
using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Filters;
using System.Diagnostics;

namespace MahwousQuotes.Views
{
    [DesignTimeVisible(false)]
    public partial class QuotesPage : ContentPage
    {
        private SortType sortType;
        public SortType SortType
        {
            get => sortType;
            set
            {
                sortType = value;
            }
        }

        public QuotesPage()
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            myQuotesTemplate.SortType = this.SortType;
        }

        private void MyBanner_AdsLoaded(object sender, EventArgs e)
        {
            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
                myBanner.HeightRequest = 50;
            else
                myBanner.HeightRequest = 90;
        }
    }
}