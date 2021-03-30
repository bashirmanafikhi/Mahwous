using MahwousImages.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousImages.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}