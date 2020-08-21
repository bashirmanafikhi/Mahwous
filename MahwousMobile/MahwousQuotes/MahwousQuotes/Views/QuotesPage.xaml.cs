using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MahwousQuotes.Models;
using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Filters;

namespace MahwousQuotes.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class QuotesPage : ContentPage
    {
        public SortType SortType
        {
            get => viewModel.Filter.SortType;
            set
            {
                viewModel.Filter.SortType = value;
                viewModel.LoadQuotesCommand.Execute(null);
            }
        }


        QuotesViewModel viewModel;

        public QuotesPage(QuotesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            viewModel.QuotesFinished += OnQuotesFinished;

        }

        public QuotesPage() : this(new QuotesViewModel()) { }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Quotes.Count == 0)
                viewModel.IsBusy = true;
        }

        private void OnQuotesFinished(object sender, EventArgs e)
        {
            DisplayAlert("تنبيه", "انتهت الحالات في هذا التصنيف", "حسناً");
        }
    }
}