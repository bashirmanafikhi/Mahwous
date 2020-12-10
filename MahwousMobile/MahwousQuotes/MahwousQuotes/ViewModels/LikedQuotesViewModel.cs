using MahwousQuote.ViewModels;
using MahwousQuotes.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{

    class LikedQuotesViewModel : BaseViewModel
    {
        public ObservableCollection<QuoteViewModel> Quotes { get; set; }

        public Command LoadQuotesCommand { get; set; }

        public LikedQuotesViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>();
            LoadQuotesCommand = new Command(() => ExecuteLoadQuotesCommand());
        }

        private void ExecuteLoadQuotesCommand()
        {
            IsBusy = true;
            Quotes.Clear();
            try
            {
                QuotesDatabase database = new QuotesDatabase();

                var quotes = database.ReadAllQuotes();
                foreach (var quote in quotes)
                {
                    Quotes.Add(new QuoteViewModel(quote) { Liked = database.Exists(quote) });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
