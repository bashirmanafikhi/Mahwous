using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
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

        public event EventHandler ImagesFinished;


        public ObservableCollection<ImageStatus> Images { get; set; }
        public Command LoadImagesCommand { get; set; }
        public Command LoadMoreImagesCommand { get; set; }
        public ImageFilter Filter { get => filter; set => filter = value; }

        public ImagesViewModel(ImageFilter filter)
        {

            Filter = filter;

            Images = new ObservableCollection<ImageStatus>();

            LoadImagesCommand = new Command(async () => await ExecuteLoadImagesCommand());
            LoadMoreImagesCommand = new Command(async () => await ExecuteLoadMoreImagesCommand());
        }

        public ImagesViewModel() : this(new ImageFilter {SortType=StatusSortType.Random}) { }

        async Task ExecuteLoadMoreImagesCommand()
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
                        var paginatedResponse = await Repositories.ImagesRepository.GetFiltered(Filter);
                        foreach (var image in paginatedResponse.Response)
                            Images.Add(image);
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
                    pagination.Page = 1;

                    var paginatedResponse = await Repositories.ImagesRepository.GetFiltered(Filter);
                    totalAmountPages = paginatedResponse.TotalAmountPages;
                    var images = paginatedResponse.Response;
                    foreach (var image in images)
                    {
                        Images.Add(image);
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
