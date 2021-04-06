﻿using MahwousWeb.Shared.Filters;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousQuotes.Views
{
    [DesignTimeVisible(false)]
    public partial class QuotesPage : ContentPage
    {
        private StatusSortType sortType;
        public StatusSortType SortType
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
            {
                myBanner.HeightRequest = 50;
            }
            else
            {
                myBanner.HeightRequest = 90;
            }
        }
    }
}