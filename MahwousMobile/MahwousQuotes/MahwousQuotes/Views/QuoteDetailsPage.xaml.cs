using MahwousQuote.ViewModels;
using MahwousQuotes.Helpers;
using MahwousQuotes.Models;
using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            viewModel.Repositories.QuoteRepository.IncrementViews(viewModel.Quote.Id);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            myQuotesTemplate.SortType = SortType.Random; //this will excute load quotes command
        }

    }
}