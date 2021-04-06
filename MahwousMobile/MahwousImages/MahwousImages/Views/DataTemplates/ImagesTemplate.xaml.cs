using MahwousImages.ViewModels;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousImages.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagesTemplate : ContentView
    {
        ImagesViewModel viewModel;
        public StatusSortType SortType
        {
            get => viewModel.Filter.SortType;
            set
            {
                if (viewModel.Images.Count > 0)
                {
                    return;
                }

                viewModel.Filter.SortType = value;
                viewModel.IsBusy = true;
            }
        }

        public int ImagesCount { get => viewModel.Images.Count; }

        public void SetCategories(params Category[] categories)
        {
            viewModel.Filter.Categories.Clear();
            foreach (var category in categories)
            {
                viewModel.Filter.Categories.Add(category);
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