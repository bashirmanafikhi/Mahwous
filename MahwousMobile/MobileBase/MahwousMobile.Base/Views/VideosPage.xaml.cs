﻿using System;
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
    public partial class VideosPage : ContentPage
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


        readonly VideosViewModel viewModel;

        public VideosPage(VideosViewModel viewModel)
        {
            InitializeComponent();
            myBanner.AdsLoaded += MyBanner_AdsLoaded;


            BindingContext = this.viewModel = viewModel;

            viewModel.VideosFinished += OnVideosFinished;

            CrossMTAdmob.Current.LoadRewardedVideo(Settings.InterstitialAdKey);

        }

        public VideosPage() : this(new VideosViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (myVideosTemplate.VideosCount == 0 && viewModel.Filter.Categories.Count > 0)
            {
                myVideosTemplate.SetCategories(viewModel.Filter.Categories.ToArray());
                //myVideosTemplate.SortType = SortType.Random;
                //return;
            }

            myVideosTemplate.SortType = this.SortType;
        }
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