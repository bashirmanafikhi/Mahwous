﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousMobile.Base.ViewModels;
using Mahwous.Core.Models;
using MahwousWeb.Models.Filters;
using System.Linq;
using MarcTron.Plugin;
using MahwousMobile.Base.Helpers;

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
            }
        }

        readonly ImagesViewModel viewModel;

        public ImagesPage(ImagesViewModel viewModel)
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;


            BindingContext = this.viewModel = viewModel;

            viewModel.ImagesFinished += OnImagesFinished;

            CrossMTAdmob.Current.LoadInterstitial(Settings.InterstitialAdKey); 

        }

        public ImagesPage() : this(new ImagesViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (myImagesTemplate.ImagesCount == 0 && viewModel.Filter.Categories.Count > 0)
            {
                myImagesTemplate.SetCategories(viewModel.Filter.Categories.ToArray());
            }

            myImagesTemplate.SortType = this.SortType;
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

        private void OnImagesFinished(object sender, EventArgs e)
        {
            DisplayAlert("تنبيه", "انتهت الحالات في هذا التصنيف", "حسناً");
        }
    }
}