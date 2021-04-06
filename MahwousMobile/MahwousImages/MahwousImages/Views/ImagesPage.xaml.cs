using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MahwousImages.ViewModels;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Filters;
using System.Linq;
//using MarcTron.Plugin;

namespace MahwousImages.Views
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

            //CrossMTAdmob.Current.LoadRewardedImage("ca-app-pub-3940256099942544/1033173712"); //تجريب
            //CrossMTAdmob.Current.LoadRewardedImage("ca-app-pub-1685177955120006/6453640828"); //حقيقي

        }

        public ImagesPage() : this(new ImagesViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (myImagesTemplate.ImagesCount == 0 && viewModel.Filter.Categories.Count > 0)
            {
                myImagesTemplate.SetCategories(viewModel.Filter.Categories.ToArray());
                //myImagesTemplate.SortType = SortType.Random;
                //return;
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