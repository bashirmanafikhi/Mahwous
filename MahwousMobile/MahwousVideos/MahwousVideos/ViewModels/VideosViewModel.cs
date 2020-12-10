using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Repositories;
using Xamarin.Forms;

namespace MahwousVideos.ViewModels
{

    public class VideosViewModel : BaseViewModel
    {
        private VideoFilter filter;
        private int totalAmountPages;


        bool isLoadingMore = false;
        public bool IsLoadingMore
        {
            get { return isLoadingMore; }
            set { SetProperty(ref isLoadingMore, value); }
        }

        private int itemTreshold = 3;
        public int ItemTreshold
        {
            get { return itemTreshold; }
            set { SetProperty(ref itemTreshold, value); }
        }

        public event EventHandler VideosFinished;


        async void Func()
        {

            MahwousRepositories mahwous = new MahwousRepositories();

            var category1 = await mahwous.CategoriesRepository.GetRandom();
            var category2 = await mahwous.CategoriesRepository.GetRandom();

            VideoFilter filter = new VideoFilter();

            filter.SortType = SortType.Random;

            filter.Categories.Add(category1);
            filter.Categories.Add(category2);

            filter.Pagination.Page = 2;
            filter.Pagination.RecordsPerPage = 100;

            filter.Date.From = new DateTime(2020, 11, 01);
            filter.Date.To = DateTime.Now;

            filter.DownloadsCount.From = 1000;

            filter.ViewsCount.From = 500;

            filter.Name = "جرح";


            var videos = await mahwous.VideosRepository.GetFiltered(filter);



        }



        public ObservableCollection<VideoStatus> Videos { get; set; }
        public Command LoadVideosCommand { get; set; }
        public Command LoadMoreVideosCommand { get; set; }
        public VideoFilter Filter { get => filter; set => filter = value; }

        public VideosViewModel(VideoFilter filter)
        {

            Filter = filter;

            Videos = new ObservableCollection<VideoStatus>();

            LoadVideosCommand = new Command(async () => await ExecuteLoadVideosCommand());
            LoadMoreVideosCommand = new Command(async () => await ExecuteLoadMoreVideosCommand());
        }

        public VideosViewModel() : this(new VideoFilter {SortType=SortType.Random}) { }

        async Task ExecuteLoadMoreVideosCommand()
        {
            if (!IsLoadingMore)
            {
                Debug.WriteLine("Bashir: Loading More");
                IsLoadingMore = true;

                try
                {
                    if (Filter.Pagination.Page < totalAmountPages)
                    {
                        Filter.Pagination.Page++;
                        var paginatedResponse = await Repositories.VideosRepository.GetFiltered(Filter);
                        foreach (var video in paginatedResponse.Response)
                            Videos.Add(video);
                    }
                    else
                    {
                        VideosFinished?.Invoke(this, EventArgs.Empty);
                        ItemTreshold = -1;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsLoadingMore = false;
                }
            }
        }

        async Task ExecuteLoadVideosCommand()
        {
                IsBusy = true;

                try
                {
                    Videos.Clear();
                    filter.Pagination.Page = 1;

                    var paginatedResponse = await Repositories.VideosRepository.GetFiltered(Filter);
                    totalAmountPages = paginatedResponse.TotalAmountPages;
                    var videos = paginatedResponse.Response;
                    foreach (var video in videos)
                    {
                        Videos.Add(video);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
        }
    }
}
