using MahwousQuote.ViewModels;
using MahwousQuotes.Helpers;
using MahwousWeb.Shared.Filters;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public QuotesViewModel() : this(new QuoteFilter { SortType = StatusSortType.Random }) { }

        async Task ExecuteLoadQuotesCommand()
        {
            //if (IsBusy)
            //{
            //    return;
            //}

            Debug.WriteLine("Bashir:  IsBusy true " + Filter.SortType);
            IsBusy = true;

            try
            {
                Quotes.Clear();
                filter.Pagination.Page = 1;

                var paginatedResponse = await Repositories.QuotesRepository.GetFiltered(Filter);
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
                Debug.WriteLine("Bashir: IsBusy false " + Filter.SortType);
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
                    if (Filter.Pagination.Page < totalAmountPages)
                    {
                        Filter.Pagination.Page++;
                        var paginatedResponse = await Repositories.QuotesRepository.GetFiltered(Filter);
                        foreach (var quote in paginatedResponse.Response)
                        {
                            Quotes.Add(new QuoteViewModel(quote) { Liked = database.Exists(quote) });
                        }
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
