using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using MahwousMobile.Base.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    public class VideosViewModel : BaseViewModel
    {
        private VideoFilter filter;
        private PaginationDetails pagination;
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

        public VideosViewModel() : this(new VideoFilter {SortType=StatusSortType.Random}) { }

        async Task ExecuteLoadMoreVideosCommand()
        {
            if (!IsLoadingMore)
            {
                Debug.WriteLine("Bashir: Loading More");
                IsLoadingMore = true;

                try
                {
                    if (pagination.Page < totalAmountPages)
                    {
                        pagination.Page++;
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
                    pagination.Page = 1;

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
