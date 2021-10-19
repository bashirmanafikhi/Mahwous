using MahwousMobile.Base.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousMobile.Base.Views
{

    [DesignTimeVisible(false)]
    public partial class QuotePage : ContentPage
    {
        private readonly QuoteViewModel viewModel;

        public QuotePage(QuoteViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

    }
}