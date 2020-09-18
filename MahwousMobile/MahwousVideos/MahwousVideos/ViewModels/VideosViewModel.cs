using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MahwousVideos.Models;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
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
                    if (Filter.Page < totalAmountPages)
                    {
                        Filter.Page++;
                        var paginatedResponse = await Repositories.VideoRepository.GetVideosFiltered(Filter);
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
                    filter.Page = 1;

                    var paginatedResponse = await Repositories.VideoRepository.GetVideosFiltered(Filter);
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
