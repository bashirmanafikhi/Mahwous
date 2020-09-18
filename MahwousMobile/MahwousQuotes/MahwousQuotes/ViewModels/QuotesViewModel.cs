using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MahwousQuote.ViewModels;
using MahwousQuotes.Helpers;
using MahwousQuotes.Models;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{

    public class QuotesViewModel : BaseViewModel
    {
        private QuoteFilter filter;
        private int totalAmountPages;
        private QuotesDatabase database = new QuotesDatabase();


        bool isLoadingMore = false;
        public bool IsLoadingMore
        {
            get { return isLoadingMore; }
            set { SetProperty(ref isLoadingMore, value); }
        }

        private int itemTreshold = 2;
        public int ItemTreshold
        {
            get { return itemTreshold; }
            set { SetProperty(ref itemTreshold, value); }
        }

        public event EventHandler QuotesFinished;



        public ObservableCollection<QuoteViewModel> Quotes { get; set; }
        public Command LoadQuotesCommand { get; set; }
        public Command LoadMoreQuotesCommand { get; set; }
        public QuoteFilter Filter { get => filter; set => filter = value; }

        public QuotesViewModel(QuoteFilter filter)
        {
            Filter = filter;

            Quotes = new ObservableCollection<QuoteViewModel>();

            LoadQuotesCommand = new Command(async () => await ExecuteLoadQuotesCommand());
            LoadMoreQuotesCommand = new Command(async () => await ExecuteLoadMoreQuotesCommand());
        }

        public QuotesViewModel() : this(new QuoteFilter { SortType = SortType.Random }) { }

        async Task ExecuteLoadQuotesCommand()
        {
            if (IsBusy) return;
            Debug.WriteLine("Bashir: Load " + Filter.SortType);
            IsBusy = true;

            try
            {
                Quotes.Clear();
                filter.Page = 1;

                var paginatedResponse = await Repositories.QuoteRepository.GetQuotesFiltered(Filter);
                totalAmountPages = paginatedResponse.TotalAmountPages;
                var quotes = paginatedResponse.Response;
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

        async Task ExecuteLoadMoreQuotesCommand()
        {
            if (!IsLoadingMore)
            {
                IsLoadingMore = true;

                try
                {
                    if (Filter.Page < totalAmountPages)
                    {
                        Filter.Page++;
                        var paginatedResponse = await Repositories.QuoteRepository.GetQuotesFiltered(Filter);
                        foreach (var quote in paginatedResponse.Response)
                            Quotes.Add(new QuoteViewModel(quote) { Liked = database.Exists(quote) });
                    }
                    else
                    {
                        DependencyService.Get<IMessage>().ShortAlert("إنتهت الحالات في هذا القسم");
                        QuotesFinished?.Invoke(this, EventArgs.Empty);
                        ItemTreshold = -1;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsLoadingMore = false;
                }
            }
        }






    }
}
