using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using MahwousMobile.Base.ViewModels;
using System.Linq;
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
            get => viewModel.SortType;
            set
            {
                if (viewModel.Videos.Count > 0)
                {
                    return;
                }

                viewModel.SortType = value;
                viewModel.IsBusy = true;
            }
        }

        public int VideosCount { get => viewModel.Videos.Count; }

        public void SetCategories(params int[] categories)
        {
            viewModel.Filter.CategoryIds = categories;
        }



        public VideosTemplate() : this(new VideosViewModel()) { }

        public VideosTemplate(VideosViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}