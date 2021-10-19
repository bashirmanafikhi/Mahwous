using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
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
        private StatusSortType sortType;
        private PaginationDetails pagination = new PaginationDetails();
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
        public StatusSortType SortType { get => sortType; set => sortType = value; }

        public VideosViewModel(VideoFilter filter)
        {

            Filter = filter;

            Videos = new ObservableCollection<VideoStatus>();

            LoadVideosCommand = new Command(async () => await ExecuteLoadVideosCommand());
            LoadMoreVideosCommand = new Command(async () => await ExecuteLoadMoreVideosCommand());
        }

        public VideosViewModel() : this(new VideoFilter ()) { }

        async Task ExecuteLoadMoreVideosCommand()
        {
            if (!IsLoadingMore)
            {
                Debug.WriteLine("Bashir: Loading More");
                IsLoadingMore = true;

                try
                {
                    if (pagination.PageIndex < totalAmountPages)
                    {
                        pagination.PageIndex++;
                        var paginatedResponse = await Repositories.VideoStatusRepository.Search(pagination, Filter, SortType);
                        foreach (var video in paginatedResponse.Items)
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
                pagination.PageIndex = 1;

                var paginatedResponse = await Repositories.VideoStatusRepository.Search(pagination, Filter, SortType);
                totalAmountPages = paginatedResponse.TotalPages;
                var videos = paginatedResponse.Items;
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
