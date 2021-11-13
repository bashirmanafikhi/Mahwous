using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    class LikedQuotesViewModel : BaseViewModel
    {
        public ObservableCollection<QuoteStatus> Quotes { get; set; }

        public Command LoadQuotesCommand { get; set; }

        public LikedQuotesViewModel()
        {
            Quotes = new ObservableCollection<QuoteStatus>();
            LoadQuotesCommand = new Command(() => ExecuteLoadQuotesCommand());
        }

        private void ExecuteLoadQuotesCommand()
        {
            IsBusy = true;
            Quotes.Clear();
            try
            {
                MahwousSqliteDB<QuoteStatus> database = new MahwousSqliteDB<QuoteStatus>();

                var quotes = database.ReadAll();
                foreach (var quote in quotes)
                {
                    Quotes.Add(quote);
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
