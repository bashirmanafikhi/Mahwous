using Mahwous.Core.Filters;
using MahwousMobile.Base.ViewModels;
using MahwousMobile.Base.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryTemplate : ContentView
    {
        public CategoryTemplate()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var viewModel = (CategoryViewModel)layout.BindingContext;

            switch (viewModel.StatusType)
            {
                case Models.StatusType.Image:
                    {
                        ImageFilter filter = new ImageFilter();
                        filter.CategoryIds.Add(viewModel.Category.Id);
                        await Navigation.PushAsync(new ImagesPage(new ImagesViewModel(filter)));
                    }
                    break;
                case Models.StatusType.Video:
                    {
                        VideoFilter filter = new VideoFilter();
                        filter.CategoryIds.Add(viewModel.Category.Id);
                        await Navigation.PushAsync(new VideosPage(new VideosViewModel(filter)));
                    }
                    break;
                case Models.StatusType.Quote:
                    {
                        QuoteFilter filter = new QuoteFilter();
                        filter.CategoryIds.Add(viewModel.Category.Id);
                        await Navigation.PushAsync(new QuotesPage(new QuotesViewModel(filter)));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}