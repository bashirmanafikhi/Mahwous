using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousVideos.ViewModels;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Filters;
using System.Linq;
using MarcTron.Plugin;

namespace MahwousVideos.Views
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

            //CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-3940256099942544/1033173712"); //تجريب
            CrossMTAdmob.Current.LoadRewardedVideo("ca-app-pub-1685177955120006/6453640828"); //حقيقي

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
            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
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