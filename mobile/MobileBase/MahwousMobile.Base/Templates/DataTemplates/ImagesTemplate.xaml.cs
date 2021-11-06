using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using MahwousMobile.Base.ViewModels;
using System.Collections;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagesTemplate : ContentView
    {
        ImagesViewModel viewModel;
        public StatusSortType SortType
        {
            get => viewModel.SortType;
            set
            {
                if (viewModel.Images.Count > 0)
                {
                    return;
                }

                viewModel.SortType = value;
                viewModel.IsBusy = true;
            }
        }

        public int ImagesCount { get => viewModel.Images.Count; }

        public void SetCategories(params int[] categories)
        {
            viewModel.Filter.CategoryIds = categories;
        }


        private void CollectionView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                return;
            }

            if (sender is CollectionView cv)
            {
                var count = cv.ItemsSource.Cast<object>().Count();
                if (e.LastVisibleItemIndex + 1 - count + cv.RemainingItemsThreshold >= 0)
                {
                    if (cv.RemainingItemsThresholdReachedCommand.CanExecute(null))
                        cv.RemainingItemsThresholdReachedCommand.Execute(null);
                }
            }
        }
        public ImagesTemplate() : this(new ImagesViewModel()) { }

        public ImagesTemplate(ImagesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}