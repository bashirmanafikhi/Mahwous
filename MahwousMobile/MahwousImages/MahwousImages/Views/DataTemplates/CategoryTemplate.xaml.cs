using MahwousImages.ViewModels;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousImages.Views.DataTemplates
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



            ImageFilter filter = new ImageFilter();
            filter.Categories.Add(viewModel.Category);



            await Navigation.PushAsync(new ImagesPage(new ImagesViewModel(filter)));
        }
    }
}