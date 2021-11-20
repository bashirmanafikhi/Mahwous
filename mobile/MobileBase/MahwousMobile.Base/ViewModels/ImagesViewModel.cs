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

    public class ImagesViewModel : BaseViewModel
    {
        private ImageFilter filter;
        private StatusSortType sortType;
        private int totalAmountPages;


        bool isLoadingMore = false;
        public bool IsLoadingMore
        {
            get { return isLoadingMore; }
            set { SetProperty(ref isLoadingMore, value); }
        }

        private int itemTreshold = 3;
        private readonly PaginationDetails pagination = new PaginationDetails();

        public int ItemTreshold
        {
            get { return itemTreshold; }
            set { SetProperty(ref itemTreshold, value); }
        }

        public event EventHandler ImagesFinished;


        public ObservableCollection<ImageViewModel> Images { get; set; }
        public Command LoadImagesCommand { get; set; }
        public Command LoadMoreImagesCommand { get; set; }
        public ImageFilter Filter { get => filter; set => filter = value; }
        public StatusSortType SortType
        {
            get => sortType; set
            {
                sortType = value;
            }
        }
        public ImagesViewModel(ImageFilter filter)
        {

            Filter = filter;

            Images = new ObservableCollection<ImageViewModel>();

            LoadImagesCommand = new Command(async () => await ExecuteLoadImagesCommand());
            LoadMoreImagesCommand = new Command(async () => await ExecuteLoadMoreImagesCommand());


            Title = "صور";
        }

        public ImagesViewModel() : this(new ImageFilter()) { }

        async Task ExecuteLoadMoreImagesCommand()
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
                        var paginatedResponse = await Repositories.ImageStatusRepository.Search(pagination, Filter, SortType);
                        foreach (var image in paginatedResponse.Items)
                            Images.Add(new ImageViewModel(image));
                    }
                    else
                    {
                        ImagesFinished?.Invoke(this, EventArgs.Empty);
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

        async Task ExecuteLoadImagesCommand()
        {
            IsBusy = true;

            try
            {
                Images.Clear();
                pagination.PageIndex = 1;

                var paginatedResponse = await Repositories.ImageStatusRepository.Search(pagination, Filter, SortType);
                totalAmountPages = paginatedResponse.TotalPages;
                var images = paginatedResponse.Items;
                foreach (var image in images)
                {
                    Images.Add(new ImageViewModel(image));
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
