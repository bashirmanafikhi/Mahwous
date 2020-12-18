using MahwousQuote.ViewModels;
using MahwousWeb.Shared.Filters;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousQuotes.Views
{

    [DesignTimeVisible(false)]
    public partial class QuoteDetailsPage : ContentPage
    {
        private readonly QuoteViewModel viewModel;

        public QuoteDetailsPage(QuoteViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            // Todo: move this to viewmodel
            viewModel.Repositories.QuotesRepository.IncrementViews(viewModel.Quote.Id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            myQuotesTemplate.SortType = StatusSortType.Random; //this will excute load quotes command
        }

    }
}