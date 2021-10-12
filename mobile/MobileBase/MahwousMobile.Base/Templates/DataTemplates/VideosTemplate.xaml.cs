using MahwousMobile.Base.ViewModels;
using Mahwous.Core.Filters;
using Mahwous.Core.Entities;
using MarcTron.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideosTemplate : ContentView
    {
        VideosViewModel viewModel;
        public StatusSortType SortType
        {
            get => viewModel.Filter.SortType;
            set
            {
                if (viewModel.Videos.Count > 0)
                {
                    return;
                }

                viewModel.Filter.SortType = value;
                viewModel.IsBusy = true;
            }
        }

        public int VideosCount { get => viewModel.Videos.Count; }

        public void SetCategories(params Category[] categories)
        {
            viewModel.Filter.Categories.Clear();
            foreach (var category in categories)
            {
                viewModel.Filter.Categories.Add(category);
            }
        }



        public VideosTemplate() : this(new VideosViewModel()) { }

        public VideosTemplate(VideosViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}